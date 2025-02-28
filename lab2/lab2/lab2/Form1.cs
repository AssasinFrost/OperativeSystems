using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer;
        private Stack<string> pathHistory = new Stack<string>();
        private Dictionary<string, long> previousFreeSpace = new Dictionary<string, long>();

        public Form1()
        {
            InitializeComponent();
            InitializeTimer();
            SetupDataGridView();
            SetupFoldersDataGridView();
            data.SelectionChanged += data_SelectionChanged;
            foldersDataGridView.CellClick += foldersDataGridView_CellClick;
        }

        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 5000; 
            timer.Tick += (s, e) =>
            {
                LoadDiskInfo();
                LogFreeSpaceChanges();
            };
            timer.Start();
        }

        private void SetupDataGridView()
        {
            data.ColumnCount = 5;
            data.Columns[0].Name = "Диск";
            data.Columns[1].Name = "Тип";
            data.Columns[2].Name = "Общий объем";
            data.Columns[3].Name = "Свободно";
            data.Columns[4].Name = "Занято";
            data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetupFoldersDataGridView()
        {
            foldersDataGridView.ColumnCount = 1;
            foldersDataGridView.Columns[0].Name = "Папки";
            foldersDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadDiskInfo()
        {
            data.Rows.Clear();

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    long totalSize = drive.TotalSize;
                    long freeSpace = drive.TotalFreeSpace;
                    long usedSpace = totalSize - freeSpace;

                    if (memory_type.Text == "Гигабайты")
                    {
                        data.Rows.Add(
                            drive.Name, drive.DriveType,
                            $"{totalSize / (1024 * 1024 * 1024)} ГБ",
                            $"{freeSpace / (1024 * 1024 * 1024)} ГБ",
                            $"{usedSpace / (1024 * 1024 * 1024)} ГБ"
                        );
                    }
                    else if (memory_type.Text == "Мегабайты")
                    {
                        data.Rows.Add(
                            drive.Name, drive.DriveType,
                            $"{totalSize / (1024 * 1024)} МБ",
                            $"{freeSpace / (1024 * 1024)} МБ",
                            $"{usedSpace / (1024 * 1024)} МБ"
                        );
                    }
                    else if (memory_type.Text == "Килобайты")
                    {
                        data.Rows.Add(
                            drive.Name, drive.DriveType,
                            $"{totalSize / 1024} КБ",
                            $"{freeSpace / 1024} КБ",
                            $"{usedSpace / 1024} КБ"
                        );
                    }

                    if (!previousFreeSpace.ContainsKey(drive.Name))
                    {
                        previousFreeSpace[drive.Name] = freeSpace;
                    }
                }
            }
        }

        private void LogFreeSpaceChanges()
        {
            try
            {
                string logFile = "logs.txt";
                List<string> logEntries = new List<string>();

                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    if (drive.IsReady)
                    {
                        long freeSpace = drive.TotalFreeSpace;

                        if (previousFreeSpace.ContainsKey(drive.Name) && previousFreeSpace[drive.Name] != freeSpace)
                        {
                            long diff = freeSpace - previousFreeSpace[drive.Name];
                            string sign = diff > 0 ? "+" : "";
                            string logMessage = $"[{DateTime.Now}] Диск {drive.Name} - изменение свободного места: {sign}{diff / (1024 * 1024)} МБ";

                            logEntries.Add(logMessage);
                            previousFreeSpace[drive.Name] = freeSpace;
                        }
                    }
                }

                if (logEntries.Count > 0)
                {
                    File.AppendAllLines(logFile, logEntries);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка записи логов: {ex.Message}");
            }
        }

        private void LoadFoldersInfo(string path)
        {
            try
            {
                foldersDataGridView.Rows.Clear();
                string[] folders = Directory.GetDirectories(path);
                previousFreeSpace.Clear();

                if (pathHistory.Count > 1)
                {
                    foldersDataGridView.Rows.Add(".. (Назад)");
                }

                foreach (string folder in folders)
                {
                    if ((File.GetAttributes(folder) & FileAttributes.Hidden) == 0)
                    {
                        foldersDataGridView.Rows.Add(Path.GetFileName(folder));
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Нет доступа к папке!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке папок: {ex.Message}");
            }
        }

        private void data_SelectionChanged(object sender, EventArgs e)
        {
            if (data.SelectedRows.Count > 0)
            {
                string selectedDisk = data.SelectedRows[0].Cells[0].Value.ToString();
                pathHistory.Clear();
                pathHistory.Push(selectedDisk);
                LoadFoldersInfo(selectedDisk);
            }
        }

        private void foldersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string folderName = foldersDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (folderName == ".. (Назад)")
            {
                if (pathHistory.Count > 1)
                {
                    pathHistory.Pop();
                    LoadFoldersInfo(pathHistory.Peek());
                }
            }
            else
            {
                string currentPath = pathHistory.Peek();
                string newPath = Path.Combine(currentPath, folderName);

                if (Directory.Exists(newPath))
                {
                    pathHistory.Push(newPath);
                    LoadFoldersInfo(newPath);
                }
            }
        }

        private void calculate_button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(memory_type.Text))
            {
                MessageBox.Show("Выберите единицу измерения");
                return;
            }
            LoadDiskInfo();
        }
    }
}
