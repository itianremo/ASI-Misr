using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace ConnTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["ConnTest.Properties.Settings.BMDConnectionString"].ConnectionString;
                SqlConnection Conn = new SqlConnection(strConn);
                Conn.Open();

                SqlCommand Comm = new SqlCommand("Select Top(1) EmpName From BMD_Employees", Conn);

                lblStatus.Text = Comm.ExecuteScalar().ToString();

                Comm.Dispose();
                Conn.Close();

                lblStatus.Text += Environment.NewLine + "Success! ";
            }
            catch (Exception exp)
            {
                lblStatus.Text = "Error: " + exp.Message;
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime.Now.TimeOfDay.ToString();
        }
    }
}
