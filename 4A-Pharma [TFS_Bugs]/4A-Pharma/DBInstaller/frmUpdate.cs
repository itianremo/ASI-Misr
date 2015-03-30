using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using System.Resources;
using System.Reflection;
using Microsoft.SqlServer.Management.Common;
using System.IO;
using DBInstallerLib;

namespace DBInstaller
{
    public partial class frmUpdate : Form
    {
        public frmUpdate()
        {
            InitializeComponent();
        }

        private void btnUpdateDB_Click(object sender, EventArgs e)
        {
            int i = 0;

            try
            {
                string SQlScript = "";
                bool SuccessFlag = true;

                // Check for createing new database
                if (Program.StartBatchNo < 0)
                {
                    string ReturnMsg = string.Empty;

                    if (RestorFullDBBackup(out ReturnMsg))
                    {
                        lblState.Text = "Database backup has been restored.";
                    }
                    else
                    {
                        lblResult.Text = "Error restoring full database backup. " + ReturnMsg;
                        SuccessFlag = false;
                    }
                }
                else
                {

                    // Iterate for each update version
                    for (i = Program.StartBatchNo + 1; i <= Program.TargetVersion; i++)
                    {
                        // Read update script from application resources
                        if (ReadSQlScript(i, out SQlScript))
                        {
                            // Run update script
                            if (SqlUtil.Conn.ExecuteScalar(SQlScript).Equals(1))
                            {
                                lblState.Text = "Database has been updated to version: "
                                    + i.ToString()
                                    + Environment.NewLine
                                    + lblState.Text;
                            }
                            else
                            {
                                lblResult.Text = "Error executing update script no.: " + i.ToString() + ".";
                                SuccessFlag = false;
                                break;
                            }
                        }
                        else
                        {
                            lblResult.Text = "Error reading update script no.: " + i.ToString() + ".";
                            SuccessFlag = false;
                            break;
                        }
                    }
                }

                if (SuccessFlag)
                {
                    string SPUpdateVersion = "UPDATE [" + SqlUtil.Conn.DatabaseName + "].[dbo].[DB_Version] SET [VersionID] = " + Program.TargetVersion.ToString();
                    SqlUtil.Conn.ExecuteNonQuery(SPUpdateVersion);

                    lblState.Text = "All updates has been configured and installed successfully."
                        + Environment.NewLine
                        + "Congratulations!"
                        + Environment.NewLine
                        + lblState.Text;
                    btnFinish.Enabled = true;
                    btnUpdateDB.Enabled = false;
                }
            }
            catch (Exception Exp)
            {
                lblResult.Text = Exp.Message;
                lblState.Text = "Error executing update script no.: "
                                    + i.ToString()
                                    + Environment.NewLine
                                    + lblState.Text;
            }
        }

        private bool ReadSQlScript(int ScriptNo, out string ReturnScript)
        {
            ReturnScript = string.Empty;
            try
            {
                ReturnScript = Properties.Resources.ResourceManager.GetString("Script" + ScriptNo.ToString());
                
                if (ReturnScript.Length == 0)
                    return false;
            }
            catch (Exception Exp)
            {
                lblResult.Text = Exp.Message;
                return false;
            }
            return true;
        }

        private bool RestorFullDBBackup(out string ReturnMsg)
        {
            string DumpFile = string.Empty;

            if (PrepareBackupDump(Program.TargetVersion, out DumpFile))
            {
                if (DumpFile.Length > 0)
                {
                    if (!SqlUtil.RestorBackup(DumpFile, this, out ReturnMsg))
                        return false;
                }
                else
                {
                    ReturnMsg = "Can't get dump file.";
                    return false;
                }
            }
            else
            {
                ReturnMsg = DumpFile;
                return false;
            }

            return true;
        }
        
        private bool PrepareBackupDump(int BackupNo, out string ReturnFile)
        {
            ReturnFile = string.Empty;
            try
            {
                string DumpFile = "DB_backup_" + BackupNo.ToString();

                ExtractFromApplicationResource(DumpFile);

                ReturnFile = DumpFile;
            }
            catch (Exception Exp)
            {
                ReturnFile = Exp.Message;
                return false;
            }
            return true;
        }

        private void ExtractFromApplicationResource(string ResourceFile)
        {
            string strPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");
            strPath += Path.DirectorySeparatorChar.ToString() + ResourceFile;
            if (File.Exists(strPath)) File.Delete(strPath);
            Assembly assembly = Assembly.GetExecutingAssembly();
            var input = assembly.GetManifestResourceStream("DBInstaller.Resources." + ResourceFile + ".bak");
            var output = File.Open(strPath, FileMode.CreateNew);
            CopyStream(input, output);
            input.Dispose();
            output.Dispose();
        }

        private void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[32768];
            while (true)
            {
                int read = input.Read(buffer, 0, buffer.Length);
                if (read <= 0)
                    return;
                output.Write(buffer, 0, read);
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}