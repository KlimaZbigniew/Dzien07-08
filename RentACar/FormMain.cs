﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACar
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void mnuLogin_Click(object sender, EventArgs e)
        {
            FormLogin form = new FormLogin();

            form.ShowDialog();
        }

        private void nmuCarList_Click(object sender, EventArgs e)
        {
            FormCarList form = new FormCarList();
            form.ShowDialog();
        }
    }
}
