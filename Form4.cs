using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace krestikiandnoliki
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
            button1.Parent = pictureBox1;
            button1.BackColor = Color.Transparent;
            button2.Parent = pictureBox1;
            button2.BackColor = Color.Transparent;
            button3.Parent = pictureBox1;
            button3.BackColor = Color.Transparent;
            button4.Parent = pictureBox1;
            button4.BackColor = Color.Transparent;
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            menu form1 = new menu();
            form1.Show();

            this.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            bot form5 = new bot();
            form5.Show();

            this.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            komp form6 = new komp();
            form6.Show();

            this.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            DVA form7 = new DVA();
            form7.Show();

            this.Focus();
        }
    }
}
