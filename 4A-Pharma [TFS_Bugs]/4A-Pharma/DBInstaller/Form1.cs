using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBInstallerLib;

namespace DBInstaller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConnectionString = "";
            string ResultMsg = "";
            bool IsExceptionExist = false;
            Exception ResultException = null;
            bool Result = DBInstallerLib.DBInstallerLib.InstallDatabase("D:\\4A-Pharma Solution\\BMD\\DBInstallerLib\\DBFiles",
                out ConnectionString,
                out ResultMsg,
                out IsExceptionExist,
                out ResultException);

            lblMsg.Text = "Result: "
                + Result.ToString()
                + Environment.NewLine
                + "ConnectionString: "
                + ConnectionString
                + Environment.NewLine
                + "ResultMsg: "
                + ResultMsg
                + Environment.NewLine
                + "IsExceptionExist: "
                + IsExceptionExist.ToString()
                + Environment.NewLine
                + "ResultException: "
                + ((ResultException == null) ? "Null" : ResultException.StackTrace);
        }
    }
}