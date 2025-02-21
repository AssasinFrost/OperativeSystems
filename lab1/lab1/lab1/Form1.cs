namespace lab1
{
    public partial class zad1 : Form
    {
        public zad1()
        {
            InitializeComponent();
        }

        private void btnplus10_Click(object sender, EventArgs e)
        {
            if (int.TryParse(ResultNum.Text, out int number))
            {
                number += 10;
                ResultNum.Text = number.ToString();
            }
            else
            {
                MessageBox.Show("¬ведите корректное число!", "ќшибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnminus2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(ResultNum.Text, out int number))
            {
                number -= 2;
                ResultNum.Text = number.ToString();
            }
            else
            {
                MessageBox.Show("¬ведите корректное число!", "ќшибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btndiv2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(ResultNum.Text, out int number))
            {
                number /= 2;
                ResultNum.Text = number.ToString();
            }
            else
            {
                MessageBox.Show("¬ведите корректное число!", "ќшибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void EnterNum_TextChanged(object sender, EventArgs e)
        {
            ResultNum.Text = EnterNum.Text;
        }
    }
}
