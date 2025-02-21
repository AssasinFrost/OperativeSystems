using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class zad2 : Form
    {
        public zad2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Ушел")
            {
                button2.Text = "Пришел";
            }
            else if (button2.Text == "Пришел")
            {
                button2.Text = "Ушел";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Text = "Пришел";
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Text = "Ушел";
        }
    }
}
