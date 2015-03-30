using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AccountabilityNotePad
{
    public partial class WarnMsg : Form
    {
        public WarnMsg(string msgText, int msgInterval)
        {
            InitializeComponent();
            lblMsg.Text = msgText;
            tmrAutoClose.Interval = msgInterval * 1000;
            tmrAutoClose.Enabled = true;
        }

        private void tmrAutoClose_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}