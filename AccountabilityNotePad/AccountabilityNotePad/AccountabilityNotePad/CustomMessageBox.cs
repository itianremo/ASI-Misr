using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AccountabilityNotePad
{
    public partial class CustomMessageBox : Form
    {
        public string ReturnValue = "";
        public CustomMessageBox()
        {
            InitializeComponent();
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            ReturnValue = "Return";
            this.Close();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            ReturnValue = "Exit";
            this.Close();
        }
    }
}