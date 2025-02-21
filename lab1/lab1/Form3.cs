using System;
using System.CodeDom;
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
    public partial class Form3 : Form
    {
        private int speedX = 10;
        private int speedY = 10;
        public Form3()
        {
            InitializeComponent();
            timer1.Interval = 50;
            timer1.Tick += new EventHandler(MoveObject);
            timer1.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(counter.Text);
            n++;
            counter.Text = n.ToString();
        }

        private void MoveObject(object sender, EventArgs e)
        {
            label1.Left += speedX;
            label1.Top += speedY;

            if (label1.Left <= 0 || label1.Right >= this.ClientSize.Width)
            {
                speedX = -speedX;
            }

            if (label1.Top <= 0 || label1.Bottom >= this.ClientSize.Height)
            {
                speedY = -speedY;
            }
        }
    }

}
