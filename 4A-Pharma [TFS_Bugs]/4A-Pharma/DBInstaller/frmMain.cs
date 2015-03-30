using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.ConnectionUI;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;

namespace DBInstaller
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSelectDB_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";

            try
            {
                DataConnectionDialog dcd = new DataConnectionDialog();
                DataSource.AddStandardDataSources(dcd);

                if (DataConnectionDialog.Show(dcd) == DialogResult.OK)
                {
                    lblState.Text = "";
                    // load tables
                    SqlUtil.SetConn(dcd.ConnectionString);
                    
                    using (SqlConnection connection = new SqlConnection(dcd.ConnectionString))
                    {
                        SqlUtil.Conn.Connect();

                        string SPCheckVersion = "IF OBJECT_ID ('[" + SqlUtil.Conn.DatabaseName + "].dbo.DB_Version','U') IS NOT NULL SELECT 1 ELSE SELECT 0";

                        if (SqlUtil.Conn.ExecuteScalar(SPCheckVersion).Equals(1))
                        {
                            //Version Table Exist

                            string SPGetCurrentVersion = "SELECT TOP(1) [VersionID] FROM [" + SqlUtil.Conn.DatabaseName + "].[dbo].[DB_Version]";
                            Program.StartBatchNo = Convert.ToInt32(SqlUtil.Conn.ExecuteScalar(SPGetCurrentVersion));

                            if (Program.TargetVersion > Program.StartBatchNo)
                            {
                                // Update to target version
                                btnNext.Enabled = true;

                                lblState.Text = "Current database name: " + SqlUtil.Conn.DatabaseName
                                           + "Current database version: " + Program.StartBatchNo.ToString() + Environment.NewLine
                                           + "Will be updated to version: " + Program.TargetVersion.ToString()
                                           + Environment.NewLine + "Press 'Next' to continue.";
                            }
                            else
                            {
                                // No update
                                btnNext.Enabled = false;
                                lblState.Text = "Your current database is up to date!";
                            }

                        }
                        else
                        {
                            //Version Table Doesn't Exist
                            btnNext.Enabled = true;

                            lblState.Text = "New database will be created and updated to version: " + Program.TargetVersion.ToString()
                                           + Environment.NewLine + "Press 'Next' to continue.";

                            Program.StartBatchNo = -1;
                        }
                    }
                }
            }
            catch (Exception Exp)
            {
                lblResult.Text = Exp.Message;
            }
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new frmUpdate()).Show();
        }
    }
}