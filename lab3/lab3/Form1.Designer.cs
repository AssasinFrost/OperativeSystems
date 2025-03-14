namespace lab3
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
            txtPath = new TextBox();
            listViewFiles = new ListView();
            btnCreate = new Button();
            btnDelete = new Button();
            btnRename = new Button();
            btnMove = new Button();
            btnRestore = new Button();
            btnUpdate = new Button();
            btnBack = new Button();
            btnRecycle = new Button();
            btnFileInfo = new Button();
            SuspendLayout();
            // 
            // txtPath
            // 
            txtPath.Location = new Point(12, 12);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(600, 23);
            txtPath.TabIndex = 0;
            txtPath.Text = "C:\\";
            // 
            // listViewFiles
            // 
            listViewFiles.Location = new Point(12, 41);
            listViewFiles.Name = "listViewFiles";
            listViewFiles.Size = new Size(1000, 500);
            listViewFiles.TabIndex = 1;
            listViewFiles.UseCompatibleStateImageBehavior = false;
            listViewFiles.View = View.Details;
            listViewFiles.ItemActivate += listViewFiles_ItemActivate;
            listViewFiles.Columns.Add("Имя", 300, HorizontalAlignment.Left);
            listViewFiles.Columns.Add("Размер", 100, HorizontalAlignment.Left);
            listViewFiles.Columns.Add("Дата изменения", 150, HorizontalAlignment.Left);
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(12, 547);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(113, 23);
            btnCreate.TabIndex = 2;
            btnCreate.Text = "Создать";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(131, 547);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(113, 23);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRename
            // 
            btnRename.Location = new Point(250, 547);
            btnRename.Name = "btnRename";
            btnRename.Size = new Size(113, 23);
            btnRename.TabIndex = 4;
            btnRename.Text = "Переименовать";
            btnRename.UseVisualStyleBackColor = true;
            btnRename.Click += btnRename_Click;
            // 
            // btnMove
            // 
            btnMove.Location = new Point(369, 547);
            btnMove.Name = "btnMove";
            btnMove.Size = new Size(113, 23);
            btnMove.TabIndex = 5;
            btnMove.Text = "Переместить";
            btnMove.UseVisualStyleBackColor = true;
            btnMove.Click += btnMove_Click;
            // 
            // btnRestore
            // 
            btnRestore.Location = new Point(488, 547);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(113, 23);
            btnRestore.TabIndex = 6;
            btnRestore.Text = "Восстановить";
            btnRestore.UseVisualStyleBackColor = true;
            btnRestore.Click += RecoveryFile_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(630, 11);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Обновить";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(723, 11);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 8;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnRecycle
            // 
            btnRecycle.Location = new Point(926, 11);
            btnRecycle.Name = "btnRecycle";
            btnRecycle.Size = new Size(75, 23);
            btnRecycle.TabIndex = 9;
            btnRecycle.Text = "Корзина";
            btnRecycle.UseVisualStyleBackColor = true;
            btnRecycle.Click += btnRecycle_Click;
            // 
            // btnFileInfo
            // 
            btnFileInfo.Location = new Point(607, 547);
            btnFileInfo.Name = "btnFileInfo";
            btnFileInfo.Size = new Size(110, 23);
            btnFileInfo.TabIndex = 10;
            btnFileInfo.Text = "Инфо";
            btnFileInfo.UseVisualStyleBackColor = true;
            btnFileInfo.Click += btnFileInfo_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 600);
            Controls.Add(btnFileInfo);
            Controls.Add(btnRecycle);
            Controls.Add(btnBack);
            Controls.Add(btnUpdate);
            Controls.Add(btnRestore);
            Controls.Add(btnMove);
            Controls.Add(btnRename);
            Controls.Add(btnDelete);
            Controls.Add(btnCreate);
            Controls.Add(listViewFiles);
            Controls.Add(txtPath);
            Name = "Form1";
            Text = "File Explorer WinAPI";
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private TextBox txtPath;
        private ListView listViewFiles;
        private Button btnCreate;
        private Button btnDelete;
        private Button btnRename;
        private Button btnMove;
        private Button btnRestore;
        private Button btnUpdate;
        private Button btnBack;
        private Button btnRecycle;
        private Button btnFileInfo;
    }
}
