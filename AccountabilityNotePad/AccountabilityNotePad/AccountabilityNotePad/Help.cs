using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AccountabilityNotePad
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void btnClos_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Help_Resize(object sender, EventArgs e)
        {
            webBrowser1.Size = this.Size;
        }

        private void Help_Load(object sender, EventArgs e)
        {
            AccRoutingServer.AccRouting RServ = new AccountabilityNotePad.AccRoutingServer.AccRouting();
            string MyURL = RServ.GetHelpURL();
            //string MyURL = Application.StartupPath + @"\HelpSite\OverView.htm";
            webBrowser1.Navigate(MyURL);
        }
    }
}