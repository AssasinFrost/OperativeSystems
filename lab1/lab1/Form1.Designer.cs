namespace lab1
{
    partial class zad1
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
            btnplus10 = new Button();
            EnterNum = new TextBox();
            ResultNum = new TextBox();
            btnminus2 = new Button();
            btndiv2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // btnplus10
            // 
            btnplus10.Location = new Point(374, 96);
            btnplus10.Name = "btnplus10";
            btnplus10.Size = new Size(75, 23);
            btnplus10.TabIndex = 0;
            btnplus10.Text = "+10";
            btnplus10.UseVisualStyleBackColor = true;
            btnplus10.Click += btnplus10_Click;
            // 
            // EnterNum
            // 
            EnterNum.Location = new Point(216, 96);
            EnterNum.Name = "EnterNum";
            EnterNum.Size = new Size(100, 23);
            EnterNum.TabIndex = 1;
            EnterNum.TextChanged += EnterNum_TextChanged;
            // 
            // ResultNum
            // 
            ResultNum.AcceptsTab = true;
            ResultNum.Location = new Point(216, 192);
            ResultNum.Name = "ResultNum";
            ResultNum.ReadOnly = true;
            ResultNum.Size = new Size(100, 23);
            ResultNum.TabIndex = 2;
            // 
            // btnminus2
            // 
            btnminus2.Location = new Point(374, 125);
            btnminus2.Name = "btnminus2";
            btnminus2.Size = new Size(75, 23);
            btnminus2.TabIndex = 3;
            btnminus2.Text = "-2";
            btnminus2.UseVisualStyleBackColor = true;
            btnminus2.Click += btnminus2_Click;
            // 
            // btndiv2
            // 
            btndiv2.Location = new Point(374, 154);
            btndiv2.Name = "btndiv2";
            btndiv2.Size = new Size(75, 23);
            btndiv2.TabIndex = 4;
            btndiv2.Text = "/2";
            btndiv2.UseVisualStyleBackColor = true;
            btndiv2.Click += btndiv2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(110, 99);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 5;
            label1.Text = "Введите число:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(110, 192);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 6;
            label2.Text = "Результат:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(160, 31);
            label3.Name = "label3";
            label3.Size = new Size(211, 15);
            label3.TabIndex = 7;
            label3.Text = "Попробуйте из числа 10 получить 13";
            // 
            // button1
            // 
            button1.Location = new Point(30, 272);
            button1.Name = "button1";
            button1.Size = new Size(143, 23);
            button1.TabIndex = 8;
            button1.Text = "Открыть задание 2";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(374, 272);
            button2.Name = "button2";
            button2.Size = new Size(153, 23);
            button2.TabIndex = 9;
            button2.Text = "Открыть задание 3";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // zad1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(563, 298);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btndiv2);
            Controls.Add(btnminus2);
            Controls.Add(ResultNum);
            Controls.Add(EnterNum);
            Controls.Add(btnplus10);
            Name = "zad1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnplus10;
        private TextBox EnterNum;
        private TextBox ResultNum;
        private Button btnminus2;
        private Button btndiv2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
    }
}
