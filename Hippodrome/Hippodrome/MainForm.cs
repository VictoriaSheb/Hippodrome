﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hippodrome
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

       
        private void btnOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBD_Click(object sender, EventArgs e)
        {
            FormClientIns client = new FormClientIns();
            client.ShowDialog();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            FormIn formIn = new FormIn();
            formIn.ShowDialog();
        }
    }
}
