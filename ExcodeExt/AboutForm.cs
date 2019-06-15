﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExcodeExt
{
    public partial class AboutForm : Form
    {
        public AboutForm() {
            InitializeComponent();
            richTextBox.Rtf = Properties.Resources.About;
        }

        private void ok_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}