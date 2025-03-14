using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct WIN32_FIND_DATA
        {
            public uint dwFileAttributes;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftCreationTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftLastAccessTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftLastWriteTime;
            public uint nFileSizeHigh;
            public uint nFileSizeLow;
            public uint dwReserved0;
            public uint dwReserved1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string cFileName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            public string cAlternateFileName;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct SHFILEOPSTRUCT
        {
            public IntPtr hwnd;
            public uint wFunc;
            public string pFrom;
            public string pTo;
            public short fFlags;
            public bool fAnyOperationsAborted;
            public IntPtr hNameMappings;
            public string lpszProgressTitle;
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr FindFirstFile(string lpFileName, out WIN32_FIND_DATA lpFindFileData);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool FindNextFile(IntPtr hFindFile, out WIN32_FIND_DATA lpFindFileData);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FindClose(IntPtr hFindFile);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode,
            IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool MoveFile(string lpExistingFileName, string lpNewFileName);

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int SHFileOperation(ref SHFILEOPSTRUCT lpFileOp);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool CreateDirectory(string lpPathName, IntPtr lpSecurityAttributes);

        private const uint FO_DELETE = 0x0003;
        private const uint FO_MOVE = 0x0001;
        private const short FOF_ALLOWUNDO = 0x0040;

        private string previousPath = "";
        private string lastDeletedFile = "";

        public Form1()
        {
            InitializeComponent();
            txtPath.Text = string.IsNullOrEmpty(txtPath.Text) ? @"C:\" : txtPath.Text;
            LoadFiles();
        }

        // Загрузка списка файлов и папок в текущей директории
        private void LoadFiles()
        {
            listViewFiles.Items.Clear();
            string searchPath = Path.Combine(txtPath.Text, "*");

            if (!Directory.Exists(txtPath.Text))
            {
                MessageBox.Show("Папка не существует.");
                return;
            }

            WIN32_FIND_DATA findData;
            IntPtr hFind = FindFirstFile(searchPath, out findData);

            if (hFind == IntPtr.Zero || hFind.ToInt64() == -1)
            {
                MessageBox.Show($"Ошибка при загрузке файлов: Код ошибки {Marshal.GetLastWin32Error()}");
                return;
            }

            do
            {
                if (findData.cFileName == "." || findData.cFileName == "..")
                    continue;

                bool isDirectory = (findData.dwFileAttributes & 0x10) != 0;
                string sizeStr = isDirectory ? "<DIR>" : FormatSize(((long)findData.nFileSizeHigh << 32) + findData.nFileSizeLow);
                string lastWriteTime = FileTimeToDateTime(findData.ftLastWriteTime).ToString();

                listViewFiles.Items.Add(new ListViewItem(new[] { findData.cFileName, sizeStr, lastWriteTime }));
            } while (FindNextFile(hFind, out findData));

            FindClose(hFind);
        }

        private void txtPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadFiles();
                e.SuppressKeyPress = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e) => LoadFiles();

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string fileName = Prompt.ShowDialog("Введите имя файла:", "Создать файл");
            if (string.IsNullOrEmpty(fileName)) return;

            string fullPath = Path.Combine(txtPath.Text, fileName);
            bool hasExtension = !string.IsNullOrEmpty(Path.GetExtension(fileName));

            if (hasExtension)
            {
                IntPtr hFile = CreateFile(fullPath, 0x40000000, 0, IntPtr.Zero, 2, 0x80, IntPtr.Zero);
                if (hFile != IntPtr.Zero && hFile.ToInt64() != -1)
                {
                    CloseHandle(hFile);
                    LoadFiles();
                    MessageBox.Show("Файл создан!");
                }
                else
                {
                    MessageBox.Show($"Ошибка создания файла: {Marshal.GetLastWin32Error()}");
                }
            }
            else
            {
                bool success = CreateDirectory(fullPath, IntPtr.Zero);
                if (success)
                {
                    LoadFiles();
                    MessageBox.Show("Папка создана!");
                }
                else
                {
                    int errorCode = Marshal.GetLastWin32Error();
                    MessageBox.Show(errorCode == 183 ? "Папка уже существует!" : $"Ошибка создания папки: Код ошибки {errorCode}");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите файл для удаления!");
                return;
            }

            btnDelete.Enabled = false;
            string filePath = Path.Combine(txtPath.Text, listViewFiles.SelectedItems[0].Text);

            if (!File.Exists(filePath) && !Directory.Exists(filePath))
            {
                MessageBox.Show("Файл или папка не существует.");
                btnDelete.Enabled = true;
                return;
            }

            SHFILEOPSTRUCT fileOp = new SHFILEOPSTRUCT
            {
                wFunc = FO_DELETE,
                pFrom = filePath + "\0\0",
                fFlags = FOF_ALLOWUNDO
            };

            int result = SHFileOperation(ref fileOp);
            btnDelete.Enabled = true;

            if (result == 0)
            {
                lastDeletedFile = filePath;
                LoadFiles();
                MessageBox.Show("Файл удален в корзину!");
            }
            else
            {
                MessageBox.Show($"Ошибка удаления: {result}");
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите файл для переименования!");
                return;
            }

            string oldName = listViewFiles.SelectedItems[0].Text;
            string newName = Prompt.ShowDialog("Введите новое имя:", "Переименовать");
            if (string.IsNullOrEmpty(newName)) return;

            string oldPath = Path.Combine(txtPath.Text, oldName);
            string newPath = Path.Combine(txtPath.Text, newName);

            if (MoveFile(oldPath, newPath))
            {
                LoadFiles();
                MessageBox.Show("Файл переименован!");
            }
            else
            {
                MessageBox.Show($"Ошибка переименования: {Marshal.GetLastWin32Error()}");
            }
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите файл для перемещения!");
                return;
            }

            string fileName = listViewFiles.SelectedItems[0].Text;
            string newPath = Prompt.ShowDialog("Введите новый путь:", "Переместить");
            if (string.IsNullOrEmpty(newPath)) return;

            string oldPath = Path.Combine(txtPath.Text, fileName);
            SHFILEOPSTRUCT fileOp = new SHFILEOPSTRUCT
            {
                wFunc = FO_MOVE,
                pFrom = oldPath + "\0\0",
                pTo = newPath + "\0\0",
                fFlags = FOF_ALLOWUNDO
            };

            int result = SHFileOperation(ref fileOp);
            if (result == 0)
            {
                LoadFiles();
                MessageBox.Show("Файл перемещен!");
            }
            else
            {
                MessageBox.Show($"Ошибка перемещения: {result}");
            }
        }

        private void listViewFiles_ItemActivate(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0) return;

            string selectedFileName = listViewFiles.SelectedItems[0].Text;
            string selectedPath = Path.Combine(txtPath.Text, selectedFileName);

            WIN32_FIND_DATA findData;
            IntPtr hFind = FindFirstFile(selectedPath + "\\*", out findData);

            if (hFind != IntPtr.Zero && hFind.ToInt64() != -1 && (findData.dwFileAttributes & 0x10) != 0)
            {
                previousPath = txtPath.Text;
                txtPath.Text = selectedPath;
                LoadFiles();
            }

            FindClose(hFind);
        }

        private void RecoveryFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lastDeletedFile))
            {
                MessageBox.Show("Нет информации о последнем удалённом файле.");
                return;
            }

            try
            {
                dynamic shell = Activator.CreateInstance(Type.GetTypeFromProgID("Shell.Application"));
                dynamic recycleBin = shell.NameSpace(10);

                foreach (dynamic item in recycleBin.Items())
                {
                    if (item.Name.Equals(Path.GetFileName(lastDeletedFile), StringComparison.OrdinalIgnoreCase))
                    {
                        foreach (dynamic verb in item.Verbs())
                        {
                            string verbName = verb.Name.ToLower().Replace("&", "");
                            if (verbName.Contains("восстановить") || verbName.Contains("restore"))
                            {
                                verb.DoIt();
                                MessageBox.Show($"Файл '{item.Name}' восстановлен.");
                                lastDeletedFile = "";
                                LoadFiles();
                                return;
                            }
                        }
                    }
                }
                MessageBox.Show("Файл не найден в корзине или команда восстановления недоступна.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при восстановлении файла: {ex.Message}");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            string currentPath = txtPath.Text.TrimEnd('\\');
            int lastSlashIndex = currentPath.LastIndexOf('\\');

            if (lastSlashIndex > 2)
            {
                txtPath.Text = currentPath.Substring(0, lastSlashIndex);
                LoadFiles();
            }
            else if (lastSlashIndex == 2 && currentPath.Length > 3)
            {
                txtPath.Text = currentPath.Substring(0, 3);
                LoadFiles();
            }
            else if (currentPath.Length == 3)
            {
                MessageBox.Show("Вы уже находитесь в корневой директории.");
            }
        }

        private void btnRecycle_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("explorer.exe", "shell:RecycleBinFolder");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии корзины: {ex.Message}");
            }
        }

        private void btnFileInfo_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите файл для просмотра информации.");
                return;
            }

            string selectedFile = Path.Combine(txtPath.Text, listViewFiles.SelectedItems[0].Text);
            if (!File.Exists(selectedFile) && !Directory.Exists(selectedFile))
            {
                MessageBox.Show("Файл или папка не найдены.");
                return;
            }

            try
            {
                FileInfo fileInfo = new FileInfo(selectedFile);
                string fileSize = fileInfo.Exists ? FormatSize(fileInfo.Length) : "Неизвестно";
                string fileType = fileInfo.Exists ? "Файл" : "Папка";
                string owner = fileInfo.Exists ? fileInfo.GetAccessControl().GetOwner(typeof(System.Security.Principal.NTAccount)).ToString() : "Неизвестно";
                string fileVersion = "Н/Д";

                if (fileInfo.Exists)
                {
                    try
                    {
                        fileVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(selectedFile).FileVersion ?? "Н/Д";
                    }
                    catch
                    {
                        // Игнорируем ошибки получения версии
                    }
                }

                string fileDetails = $"Имя: {fileInfo.Name}\n" +
                                   $"Полный путь: {fileInfo.FullName}\n" +
                                   $"Тип: {fileType}\n" +
                                   $"Размер: {fileSize}\n" +
                                   $"Дата создания: {fileInfo.CreationTime}\n" +
                                   $"Дата последней модификации: {fileInfo.LastWriteTime}\n" +
                                   $"Дата последнего доступа: {fileInfo.LastAccessTime}\n" +
                                   $"Атрибуты: {fileInfo.Attributes}\n" +
                                   $"Владелец: {owner}\n" +
                                   $"Только для чтения: {(fileInfo.IsReadOnly ? "Да" : "Нет")}\n" +
                                   $"Версия файла: {fileVersion}\n" +
                                   $"Расширение: {Path.GetExtension(selectedFile) ?? "Н/Д"}\n" +
                                   $"Скрытый: {(fileInfo.Attributes.HasFlag(FileAttributes.Hidden) ? "Да" : "Нет")}\n" +
                                   $"Сжатый: {(fileInfo.Attributes.HasFlag(FileAttributes.Compressed) ? "Да" : "Нет")}\n" +
                                   $"Зашифрованный: {(fileInfo.Attributes.HasFlag(FileAttributes.Encrypted) ? "Да" : "Нет")}";

                MessageBox.Show(fileDetails, "Информация о файле");
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Нет доступа к файлу: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении информации о файле: {ex.Message}");
            }
        }

        private string FormatSize(long bytes)
        {
            string[] suffixes = { "B", "KB", "MB", "GB" };
            int counter = 0;
            decimal number = bytes;
            while (Math.Round(number / 1024) >= 1)
            {
                number /= 1024;
                counter++;
            }
            return $"{number:n1}{suffixes[counter]}";
        }

        private DateTime FileTimeToDateTime(System.Runtime.InteropServices.ComTypes.FILETIME fileTime)
        {
            long fileTimeLong = ((long)fileTime.dwHighDateTime << 32) + (uint)fileTime.dwLowDateTime;
            return DateTime.FromFileTime(fileTimeLong);
        }
    }

    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form { Width = 300, Height = 150, Text = caption };
            Label textLabel = new Label { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox { Left = 50, Top = 50, Width = 200 };
            Button confirmation = new Button { Text = "OK", Left = 150, Width = 100, Top = 80, DialogResult = DialogResult.OK };
            prompt.Controls.AddRange(new Control[] { textLabel, textBox, confirmation });
            prompt.AcceptButton = confirmation;
            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}