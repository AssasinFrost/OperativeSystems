namespace Kr1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCreateFile = new Button();
            txtFilePath = new TextBox();
            cmbAttributes = new ComboBox();
            label1 = new Label();
            txtFileName = new TextBox();
            label2 = new Label();
            btnCreateFolder = new Button();
            cmbSign = new ComboBox();
            cmbPattern = new ComboBox();
            SuspendLayout();
            // 
            // btnCreateFile
            // 
            btnCreateFile.Location = new Point(503, 56);
            btnCreateFile.Name = "btnCreateFile";
            btnCreateFile.Size = new Size(156, 34);
            btnCreateFile.TabIndex = 0;
            btnCreateFile.Text = "Создать файл";
            btnCreateFile.UseVisualStyleBackColor = true;
            btnCreateFile.Click += btnCreate_Click;
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(39, 57);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(247, 31);
            txtFilePath.TabIndex = 1;
            txtFilePath.Text = System.IO.Path.GetTempPath(); // Путь по умолчанию
            // 
            // cmbAttributes
            // 
            cmbAttributes.AllowDrop = true;
            cmbAttributes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAttributes.FormattingEnabled = true;
            cmbAttributes.Items.AddRange(new object[] { "System", "Hidden", "ReadOnly", "Archive" });
            cmbAttributes.Location = new Point(305, 57);
            cmbAttributes.Name = "cmbAttributes";
            cmbAttributes.Size = new Size(182, 33);
            cmbAttributes.TabIndex = 2;
            cmbAttributes.SelectedIndex = 0; // "System" по умолчанию
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 29);
            label1.Name = "label1";
            label1.Size = new Size(50, 25);
            label1.TabIndex = 3;
            label1.Text = "Путь";
            // 
            // txtFileName
            // 
            txtFileName.Location = new Point(39, 130);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new Size(247, 31);
            txtFileName.TabIndex = 4;
            txtFileName.Text = "TestFile.txt"; // Имя файла по умолчанию
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 102);
            label2.Name = "label2";
            label2.Size = new Size(156, 25);
            label2.TabIndex = 5;
            label2.Text = "Имя файла\\папки";
            // 
            // btnCreateFolder
            // 
            btnCreateFolder.Location = new Point(503, 102);
            btnCreateFolder.Name = "btnCreateFolder";
            btnCreateFolder.Size = new Size(156, 34);
            btnCreateFolder.TabIndex = 6;
            btnCreateFolder.Text = "Создать папку";
            btnCreateFolder.UseVisualStyleBackColor = true;
            btnCreateFolder.Click += btnCreateFolder_Click;
            // 
            // cmbSign
            // 
            cmbSign.DropDownStyle = ComboBoxStyle.DropDownList; // Только выбор из списка
            cmbSign.FormattingEnabled = true;
            cmbSign.Items.AddRange(new object[] {
                "Папка (shell32.dll, 4)",
                "Документ (shell32.dll, 3)",
                "Музыка (shell32.dll, 12)"
            });
            cmbSign.Location = new Point(39, 177);
            cmbSign.Name = "cmbSign";
            cmbSign.Size = new Size(182, 33);
            cmbSign.TabIndex = 7;
            cmbSign.SelectedIndex = 0; // "Папка" по умолчанию
            // 
            // cmbPattern
            // 
            cmbPattern.DropDownStyle = ComboBoxStyle.DropDownList; // Только выбор из списка
            cmbPattern.FormattingEnabled = true;
            cmbPattern.Items.AddRange(new object[] {
                "Крупные значки",
                "Список",
                "Таблица",
                "Плитка"
            });
            cmbPattern.Location = new Point(39, 231);
            cmbPattern.Name = "cmbPattern";
            cmbPattern.Size = new Size(182, 33);
            cmbPattern.TabIndex = 8;
            cmbPattern.SelectedIndex = 0; // "Крупные значки" по умолчанию
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(856, 276);
            Controls.Add(cmbPattern);
            Controls.Add(cmbSign);
            Controls.Add(btnCreateFolder);
            Controls.Add(label2);
            Controls.Add(txtFileName);
            Controls.Add(label1);
            Controls.Add(cmbAttributes);
            Controls.Add(txtFilePath);
            Controls.Add(btnCreateFile);
            ImeMode = ImeMode.Close;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCreateFile;
        private TextBox txtFilePath;
        private ComboBox cmbAttributes;
        private Label label1;
        private TextBox txtFileName;
        private Label label2;
        private Button btnCreateFolder;
        private ComboBox cmbSign;
        private ComboBox cmbPattern;
    }
}