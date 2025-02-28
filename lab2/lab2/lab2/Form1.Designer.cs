namespace lab2;

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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        data = new DataGridView();
        label1 = new Label();
        memory_type = new ComboBox();
        label2 = new Label();
        calculate_button = new Button();
        foldersDataGridView = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)data).BeginInit();
        ((System.ComponentModel.ISupportInitialize)foldersDataGridView).BeginInit();
        SuspendLayout();
        // 
        // data
        // 
        data.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        data.Location = new Point(27, 55);
        data.Name = "data";
        data.Size = new Size(645, 280);
        data.TabIndex = 0;
        data.Text = "dataGridView1";
        // 
        // label1
        // 
        label1.Location = new Point(27, 29);
        label1.Name = "label1";
        label1.Size = new Size(150, 23);
        label1.TabIndex = 1;
        label1.Text = "Инофрмация о дисках:";
        // 
        // memory_type
        // 
        memory_type.DropDownStyle = ComboBoxStyle.DropDownList;
        memory_type.FormattingEnabled = true;
        memory_type.ImeMode = ImeMode.NoControl;
        memory_type.Items.AddRange(new object[] { "Килобайты", "Мегабайты", "Гигабайты" });
        memory_type.Location = new Point(678, 81);
        memory_type.Name = "memory_type";
        memory_type.Size = new Size(127, 23);
        memory_type.TabIndex = 2;
        // 
        // label2
        // 
        label2.Location = new Point(678, 55);
        label2.Name = "label2";
        label2.Size = new Size(197, 23);
        label2.TabIndex = 3;
        label2.Text = "Отображаемые еденицы памяти:";
        // 
        // calculate_button
        // 
        calculate_button.Location = new Point(693, 312);
        calculate_button.Name = "calculate_button";
        calculate_button.Size = new Size(112, 23);
        calculate_button.TabIndex = 4;
        calculate_button.Text = "Рассчитать";
        calculate_button.UseVisualStyleBackColor = true;
        calculate_button.Click += calculate_button_Click;
        // 
        // foldersDataGridView
        // 
        foldersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        foldersDataGridView.Location = new Point(27, 425);
        foldersDataGridView.Name = "foldersDataGridView";
        foldersDataGridView.Size = new Size(645, 276);
        foldersDataGridView.TabIndex = 5;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(934, 746);
        Controls.Add(foldersDataGridView);
        Controls.Add(calculate_button);
        Controls.Add(label2);
        Controls.Add(memory_type);
        Controls.Add(label1);
        Controls.Add(data);
        Name = "Form1";
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)data).EndInit();
        ((System.ComponentModel.ISupportInitialize)foldersDataGridView).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button calculate_button;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.ComboBox memory_type;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.DataGridView data;

    #endregion

    private DataGridView foldersDataGridView;
}