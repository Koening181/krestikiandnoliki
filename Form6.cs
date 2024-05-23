using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace krestikiandnoliki
{
    public partial class komp : Form
    {
        private bool isCrossTurn = true;
        private Label[] labels;
        private bool gameEnded = false;
        private bool isSecondPlayerTurn = false;

        public komp()
        {
            InitializeComponent();
            InitializeGameBoard();
            label10.Visible = false;
                label1.Parent = pictureBox1;
                label1.BackColor = Color.Transparent;
                label2.Parent = pictureBox1;
                label2.BackColor = Color.Transparent;
                label3.Parent = pictureBox1;
                label3.BackColor = Color.Transparent;
                label4.Parent = pictureBox1;
                label4.BackColor = Color.Transparent;
                label5.Parent = pictureBox1;
                label5.BackColor = Color.Transparent;
                label6.Parent = pictureBox1;
                label6.BackColor = Color.Transparent;
                label7.Parent = pictureBox1;
                label7.BackColor = Color.Transparent;
                label8.Parent = pictureBox1;
                label8.BackColor = Color.Transparent;
                label9.Parent = pictureBox1;
                label9.BackColor = Color.Transparent;
                label10.Parent = pictureBox1;
                label10.BackColor = Color.Transparent;
                Reload2.Parent = pictureBox1;
                Reload2.BackColor = Color.Transparent;
                Exit2.Parent = pictureBox1;
                Exit2.BackColor = Color.Transparent;
                Rules2.Parent = pictureBox1;
                Rules2.BackColor = Color.Transparent;
            

        }

        private void InitializeGameBoard()
        {
            labels = new Label[] { label1, label2, label3, label4, label5, label6, label7, label8, label9 };
            foreach (Label label in labels)
            {
                label.Font = new Font("segoe script", 48);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Click += Label_Click;
                label.MouseClick += Label_MouseClick;
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            if (!gameEnded && isSecondPlayerTurn)
            {
                Label label = (Label)sender;
                if (label.Text == "")
                {
                    label.Text = "O";
                    isCrossTurn = true;
                    isSecondPlayerTurn = false;

                    CheckForWinner();
                }
            }
        }

        private void Label_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !gameEnded && !isSecondPlayerTurn)
            {
                Label label = (Label)sender;
                if (label.Text == "")
                {
                    label.Text = "X";
                    isCrossTurn = false;
                    isSecondPlayerTurn = true;

                    CheckForWinner();
                }
            }
        }

        private void CheckForWinner()
        {
            if (CheckLine(0, 1, 2) || CheckLine(3, 4, 5) || CheckLine(6, 7, 8) ||
                CheckLine(0, 3, 6) || CheckLine(1, 4, 7) || CheckLine(2, 5, 8) ||
                CheckLine(0, 4, 8) || CheckLine(2, 4, 6))
            {
                gameEnded = true;
                string winner = isCrossTurn ? "Победил Второй игрок" : "Победил Первый игрок";
                MessageBox.Show(winner);

                if (CheckLine(0, 4, 8))
                {
                    label10.BringToFront();
                    label10.Visible = true;
                }
            }
            else if (labels.Count(l => l.Text == "") == 1)
            {
                gameEnded = true;
                MessageBox.Show("Ничья!");
            }
            else if (labels.All(l => l.Text != ""))
            {
                gameEnded = true;
                MessageBox.Show("Ничья!");
            }
        }

        private bool CheckLine(int index1, int index2, int index3)
        {
            return labels[index1].Text != "" && labels[index1].Text == labels[index2].Text && labels[index2].Text == labels[index3].Text;
        }




        private void Exit2_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu form1 = new menu();
            form1.Show();
            this.Focus();
        }

        private void Rules2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pravila form2 = new Pravila();
            form2.Show();
            this.Focus();
        }

        private void Reload2_Click_1(object sender, EventArgs e)
        {
            gameEnded = false;
            isCrossTurn = true;

            foreach (Label label in labels)
            {
                label.Text = "";
            }
        }
    }
}

