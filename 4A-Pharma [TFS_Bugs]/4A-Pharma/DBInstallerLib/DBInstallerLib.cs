using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.ConnectionUI;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using System.Windows.Forms;
using System.IO;

namespace DBInstallerLib
{
    public abstract class DBInstallerLib
    {
        private static int StartBatchNo, TargetVersion, MinVersion;

        public static bool InstallDatabase(string DBFilesDirectoryPath, out string ConnectionString, out string ResultMsg, out bool IsExceptionExist, out Exception ResultException)
        {
            bool ResultFlag = false;
            ConnectionString = "";
            IsExceptionExist = false;
            ResultMsg = "";
            ResultException = null;

            try
            {
                DataConnectionDialog dcd = new DataConnectionDialog();
                DataSource.AddStandardDataSources(dcd);

                if (DataConnectionDialog.Show(dcd) == DialogResult.OK)
                {
                    // Get target version number
                    TargetVersion = GetTargetVersion(DBFilesDirectoryPath);

                    if (TargetVersion == -1)
                    {
                        ResultMsg = "Error getting target version number.";
                        return false;
                    }

                    ConnectionString = dcd.ConnectionString;

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
                            StartBatchNo = Convert.ToInt32(SqlUtil.Conn.ExecuteScalar(SPGetCurrentVersion));

                            if (TargetVersion > StartBatchNo)
                            {
                                // Update to target version

                                //lblState.Text = "Current database name: " + SqlUtil.Conn.DatabaseName
                                //           + "Current database version: " + Program.StartBatchNo.ToString() + Environment.NewLine
                                //           + "Will be updated to version: " + Program.TargetVersion.ToString()
                                //           + Environment.NewLine + "Press 'Next' to continue.";

                                UpdateDatabase(DBFilesDirectoryPath, out ResultMsg);
                            }
                            else
                            {
                                // No update
                                ResultMsg = "Your current database is up to date!";
                                if (TargetVersion < StartBatchNo)
                                {
                                    ResultMsg = "Your current database has newer version than available updates!";
                                }
                            }

                        }
                        else
                        {
                            //Version Table Doesn't Exist

                            //lblState.Text = "New database will be created and updated to version: " + Program.TargetVersion.ToString()
                            //               + Environment.NewLine + "Press 'Next' to continue.";

                            StartBatchNo = -1;
                            string UpdateMsg = "";
                            UpdateDatabase(DBFilesDirectoryPath, out UpdateMsg);
                        }
                    }
                    ResultFlag = true;
                }
                else
                    ResultMsg = "No connection string provided.";
            }
            catch (Exception Exp)
            {
                ResultMsg = "Error. Message:" + Exp.Message;
                IsExceptionExist = true;
                ResultException = Exp;
            }

            return ResultFlag;
        }

        private static int GetTargetVersion(string DBFilesDirectoryPath)
        {
            int MaxNumber = 0;
            int TempNumber = 0;
            MinVersion = 0;

            try
            {
                string[] Files = Directory.GetFiles(DBFilesDirectoryPath, "*.sql", SearchOption.TopDirectoryOnly);
                foreach (string file in Files)
                {
                    if (int.TryParse(Path.GetFileName(file).ToLower().Replace("script.sql", ""), out TempNumber))
                    {
                        MaxNumber = (MaxNumber > TempNumber) ? MaxNumber : TempNumber;
                        MinVersion = (MinVersion < TempNumber) ? MinVersion : TempNumber;
                    }
                }
            }
            catch (Exception)
            {
                MaxNumber = -1;
                MinVersion = -1;
            }

            return MaxNumber;
        }

        private static bool UpdateDatabase(string DBFilesDirectoryPath, out string UpdateMsg)
        {
            UpdateMsg = "";
            bool ResultFlag = false;

            int i = 0;

            try
            {
                string SQlScript = "";
                bool SuccessFlag = true;

                // Check for createing new database
                if (StartBatchNo < 0)
                {
                    string ReturnMsg = string.Empty;

                    StartBatchNo = MinVersion;
                    InitiateDatabase(DBFilesDirectoryPath, ref ReturnMsg, ref SuccessFlag);
                    if (SuccessFlag)
                    {
                        UpdateMsg = "Database backup has been initiated.";

                        RestoreDBScripts(DBFilesDirectoryPath, ref ReturnMsg, ref i, ref SQlScript, ref SuccessFlag);

                        if (SuccessFlag)
                        {
                            UpdateMsg += "Database backup has been restored.";
                        }
                        else
                        {
                            UpdateMsg = "Error restoring full database backup. " + ReturnMsg;
                        }
                    }
                    else
                    {
                        UpdateMsg = "Error initiating database. " + ReturnMsg;
                    }
                }
                else
                {

                    RestoreDBScripts(DBFilesDirectoryPath, ref UpdateMsg, ref i, ref SQlScript, ref SuccessFlag);
                }

                if (SuccessFlag)
                {
                    string SPUpdateVersion = "UPDATE [" + SqlUtil.Conn.DatabaseName + "].[dbo].[DB_Version] SET [VersionID] = " + TargetVersion.ToString();
                    SqlUtil.Conn.ExecuteNonQuery(SPUpdateVersion);

                    UpdateMsg = "All updates has been configured and installed successfully."
                        + Environment.NewLine
                        + "Congratulations!"
                        + Environment.NewLine
                        + UpdateMsg;
                }
            }
            catch (Exception Exp)
            {
                UpdateMsg = Exp.Message;
                UpdateMsg = "Error executing update script no.: "
                                    + i.ToString()
                                    + Environment.NewLine
                                    + UpdateMsg;
            }

            return ResultFlag;
        }

        private static void InitiateDatabase(string DBFilesDirectoryPath, ref string UpdateMsg, ref bool SuccessFlag)
        {
            string SQlScript = "";
            // Read update script from application resources
            if (ReadSQlScript(DBFilesDirectoryPath, "CreateDatabase.sql", out SQlScript))
            {
                // Run update script
                if (SqlUtil.Conn.ExecuteScalar(SQlScript).Equals(1))
                {
                    UpdateMsg = "Database has been created."
                        + Environment.NewLine
                        + UpdateMsg;
                }
                else
                {
                    UpdateMsg = "Error executing \"CreateDatabase.sql\" script.";
                    SuccessFlag = false;
                }
            }
            else
            {
                UpdateMsg = "Error executing \"CreateDatabase.sql\" script.";
                SuccessFlag = false;
            }

            if (SuccessFlag)
            {
                if (ReadSQlScript(DBFilesDirectoryPath, "initial.sql", out SQlScript))
                {
                    // Run update script
                    if (SqlUtil.Conn.ExecuteScalar(SQlScript).Equals(1))
                    {
                        UpdateMsg = "Database has been initialized."
                            + Environment.NewLine
                            + UpdateMsg;
                    }
                    else
                    {
                        UpdateMsg = "Error executing \"initial.sql\" script.";
                        SuccessFlag = false;
                    }
                }
                else
                {
                    UpdateMsg = "Error executing \"initial.sql\" script.";
                    SuccessFlag = false;
                }
            }
        }

        private static void RestoreDBScripts(string DBFilesDirectoryPath, ref string UpdateMsg, ref int i, ref string SQlScript, ref bool SuccessFlag)
        {
            // Iterate for each update version
            for (i = StartBatchNo + 1; i <= TargetVersion; i++)
            {
                // Read update script from application resources
                if (ReadSQlScript(DBFilesDirectoryPath, i, out SQlScript))
                {
                    // Run update script
                    if (SqlUtil.Conn.ExecuteScalar(SQlScript).Equals(1))
                    {
                        UpdateMsg = "Database has been updated to version: "
                            + i.ToString()
                            + Environment.NewLine
                            + UpdateMsg;
                    }
                    else
                    {
                        UpdateMsg = "Error executing update script no.: " + i.ToString() + ".";
                        SuccessFlag = false;
                        break;
                    }
                }
                else
                {
                    UpdateMsg = "Error reading update script no.: " + i.ToString() + ".";
                    SuccessFlag = false;
                    break;
                }
            }
        }

        private static bool ReadSQlScript(string DBFilesDirectoryPath, int ScriptNo, out string ReturnScript)
        {
            ReturnScript = string.Empty;
            try
            {
                string ScriptPath = DBFilesDirectoryPath + Path.DirectorySeparatorChar + ScriptNo.ToString() + "Script.sql";

                if (File.Exists(ScriptPath))
                {
                    ReturnScript = File.ReadAllText(ScriptPath);
                }
                else
                    return false;

                if (ReturnScript.Length == 0)
                    return false;
            }
            catch (Exception Exp)
            {
                ReturnScript = Exp.Message;
                return false;
            }
            return true;
        }

        private static bool ReadSQlScript(string DBFilesDirectoryPath, string ScriptFileName, out string ReturnScript)
        {
            ReturnScript = string.Empty;
            try
            {
                string ScriptPath = DBFilesDirectoryPath + Path.DirectorySeparatorChar + ScriptFileName;

                if (File.Exists(ScriptPath))
                {
                    ReturnScript = File.ReadAllText(ScriptPath);
                }
                else
                    return false;

                if (ReturnScript.Length == 0)
                    return false;
            }
            catch (Exception Exp)
            {
                ReturnScript = Exp.Message;
                return false;
            }
            return true;
        }
    }
}
