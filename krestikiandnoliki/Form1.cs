using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace krestikiandnoliki
{
    public partial class menu : Form
    {
        public menu()
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

        }

        private void button2_Click(object sender, EventArgs e)

        {
            this.Hide();

            settings form3 = new settings();
            form3.Show();

            this.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            Pravila form2 = new Pravila();
            form2.Show();

            this.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Завершаем приложение
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            Game form4 = new Game();
            form4.Show();

            this.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
