﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;


namespace krestikiandnoliki
{
    public partial class bot : Form
    {
        private bool isCrossTurn = true;
        private Label[] labels;
        private bool gameEnded = false;

        public bot()
        {
            InitializeComponent();
            InitializeGameBoard();
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
            Reload.Parent = pictureBox1;
            Reload.BackColor = Color.Transparent;
            Exit1.Parent = pictureBox1;
            Exit1.BackColor = Color.Transparent;
            Rules1.Parent = pictureBox1;
            Rules1.BackColor = Color.Transparent;


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
            if (!gameEnded)
            {
                Label label = (Label)sender;
                if (label.Text == "")
                {
                    if (isCrossTurn)
                    {
                        label.Text = "X";
                    }
                    else
                    {
                        label.Text = "O";
                    }
                    isCrossTurn = !isCrossTurn;

                    CheckForWinner();
                    if (!gameEnded && !isCrossTurn)
                    {
                        BotMove();
                    }
                }
            }
        }

        private void Label_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Label label = (Label)sender;
                if (label.Text == "")
                {
                    label.Text = "O";
                    isCrossTurn = true;
                    CheckForWinner();
                    if (!gameEnded && !isCrossTurn)
                    {
                        BotMove();
                    }
                }
            }
        }

        private void BotMove()
        {
            Random random = new Random();
            int index;
            do
            {
                index = random.Next(0, 9);
            } while (labels[index].Text != "");

            labels[index].Text = "O";
            isCrossTurn = true;
            CheckForWinner();
        }

        private void CheckForWinner()
        {
            if (CheckLine(0, 1, 2) || CheckLine(3, 4, 5) || CheckLine(6, 7, 8) ||
                CheckLine(0, 3, 6) || CheckLine(1, 4, 7) || CheckLine(2, 5, 8) ||
                CheckLine(0, 4, 8) || CheckLine(2, 4, 6))
            {
                gameEnded = true;
                string winner = isCrossTurn ? "Победил Бот" : "Ты победил";
                MessageBox.Show("" + winner);
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

        private void Reload_Click(object sender, EventArgs e)
        {
            gameEnded = false;
            isCrossTurn = true;

            foreach (Label label in labels)
            {
                label.Text = "";
            }
        }

        private void Exit1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            menu form1 = new menu();
            form1.Show();
            this.Focus();
        }

        private void Rules1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Pravila form2 = new Pravila();
            form2.Show();
            this.Focus();
        }
    }
}
