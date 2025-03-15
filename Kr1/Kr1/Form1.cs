using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;

namespace Kr1
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern SafeFileHandle CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteFile(SafeFileHandle hFile, byte[] lpBuffer, uint nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten, IntPtr lpOverlapped);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetFileAttributes(string lpFileName, uint dwFileAttributes);

        private const uint GENERIC_WRITE = 0x40000000;
        private const uint FILE_SHARE_WRITE = 0x00000002;
        private const uint CREATE_ALWAYS = 2;
        private const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;
        private const uint FILE_ATTRIBUTE_SYSTEM = 0x00000004;
        private const uint FILE_ATTRIBUTE_HIDDEN = 0x00000002;
        private const uint FILE_ATTRIBUTE_READONLY = 0x00000001;
        private const uint FILE_ATTRIBUTE_ARCHIVE = 0x00000020;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string fullPath = Path.Combine(txtFilePath.Text, txtFileName.Text);
            SafeFileHandle fileHandle = CreateFile(fullPath, GENERIC_WRITE, FILE_SHARE_WRITE, IntPtr.Zero, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);
            if (fileHandle.IsInvalid)
            {
                MessageBox.Show($"Ошибка создания файла. Код: {Marshal.GetLastWin32Error()}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            fileHandle.Close();
            MessageBox.Show($"Файл создан: {fullPath}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            string fullFolderPath = Path.Combine(txtFilePath.Text, txtFileName.Text);
            try
            {
                Directory.CreateDirectory(fullFolderPath);
                string desktopIniPath = Path.Combine(fullFolderPath, "desktop.ini");
                string iconResource = cmbSign.SelectedItem.ToString() switch
                {
                    "Папка (shell32.dll, 4)" => "C:\\Windows\\System32\\shell32.dll,4",
                    "Документ (shell32.dll, 3)" => "C:\\Windows\\System32\\shell32.dll,3",
                    "Музыка (shell32.dll, 12)" => "C:\\Windows\\System32\\shell32.dll,12",
                    _ => "C:\\Windows\\System32\\shell32.dll,4"
                };
                (string mode, string vid) = cmbPattern.SelectedItem.ToString() switch
                {
                    "Крупные значки" => ("1", "{0057D0E0-3573-11CF-AE69-08002B2E1262}"),
                    "Список" => ("3", "{0E1FA5E0-3573-11CF-AE69-08002B2E1262}"),
                    "Таблица" => ("4", "{137E7700-3573-11CF-AE69-08002B2E1262}"),
                    "Плитка" => ("6", "{65F125E5-7BE1-4810-BA9D-D271C5F06579}"),
                    _ => ("4", "{137E7700-3573-11CF-AE69-08002B2E1262}")
                };
                File.WriteAllText(desktopIniPath, $"[.ShellClassInfo]\r\nIconResource={iconResource}\r\n[ViewState]\r\nMode={mode}\r\nVid={vid}\r\n");
                File.SetAttributes(desktopIniPath, FileAttributes.Hidden);
                SetFileAttributes(fullFolderPath, FILE_ATTRIBUTE_SYSTEM);
                MessageBox.Show($"Папка создана: {fullFolderPath}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}