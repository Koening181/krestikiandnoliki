﻿using System;
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
    public partial class Pravila : Form
    {
        public Pravila()
        {
            InitializeComponent();
            button1.Parent = pictureBox1;
            button1.BackColor = Color.Transparent;
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                this.Hide();

               menu form1 = new menu();
                form1.Show();

                this.Focus();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
