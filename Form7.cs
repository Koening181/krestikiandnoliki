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
using System.IO;

namespace krestikiandnoliki
{
    public partial class DVA : Form
    {
        private bool isCrossTurn = true;
        private Label[] labels;
        private bool gameEnded = false;
        private bool isSecondPlayerTurn = false;
        private const int PortNumber = 2620;
        private TcpClient client;
        private TcpListener server;

        public DVA()
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

        private async void SendDataToOpponent(string data)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(data);
                await stream.WriteAsync(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка отправки данных: " + ex.Message);
            }
        }

        private void ReceiveDataFromOpponent(string data)
        {
            // Логика обработки полученных данных от другого игрока
            if (data == "GameEnded")
            {
                gameEnded = true;
                MessageBox.Show("Игра завершена другим игроком!");
            }
            else
            {
                // Логика обновления игрового поля на основе полученных данных
                UpdateGameBoard(data);
            }
        }

        private void UpdateGameBoard(string data)
        {
            // Реализуйте логику обновления игрового поля на основе полученных данных
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

                    SendDataToOpponent("O" + label.Name); // Пример данных для отправки
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

                    SendDataToOpponent("X" + label.Name); // Пример данных для отправки
                    CheckForWinner();
                }
            }
        }

        private void CheckForWinner()
        {
            // Логика проверки победителя

            if (gameEnded)
            {
                SendDataToOpponent("GameEnded");
            }
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

        private async void button2_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            try
            {
                await client.ConnectAsync(IPAddress.Parse("25.13.31.244"), 2620);
                if (client.Connected)
                {
                    ShowGameUI();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения: " + ex.Message);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            server = new TcpListener(IPAddress.Any, 2620);
            server.Start();
            MessageBox.Show("Сервер запущен. Ожидание подключений...");

            try
            {
                TcpClient client2 = await server.AcceptTcpClientAsync();

                if (client2.Connected)
                {
                    MessageBox.Show("Игрок 2 подключен.");
                    ShowGameUI();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка приема подключения: " + ex.Message);
            }
        }

        private void ShowGameUI()
        {
            button1.Visible = false;
            button2.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            Reload2.Visible = true;
            Exit2.Visible=true;
            Rules2.Visible = true;
        }
    }
}