using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace DBInstaller
{
    abstract class SqlUtil
    {
        static private frmUpdate _frmUpdate;

        static public ServerConnection Conn;

        static public void SetConn(String ConnectionString)
        {
            SqlUtil.Conn = new ServerConnection(new SqlConnection(ConnectionString));
        }

        static public bool RestorBackup(string BackupFile, frmUpdate Sender, out string ReturnMsg)
        {
            bool Result = true;
            ReturnMsg = string.Empty;
            _frmUpdate = Sender;
            string BackupFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            BackupFilePath += Path.DirectorySeparatorChar.ToString() + BackupFile;

            try
            {
                Server Svr = new Server(Conn);
                Database DB = Svr.Databases[Conn.DatabaseName];
                string DBLocation = DB.FileGroups[0].Files[0].FileName;
                string DBLogLocation = Path.GetDirectoryName(DBLocation);
                DBLogLocation += Path.DirectorySeparatorChar.ToString() + Path.GetFileNameWithoutExtension(DBLocation);
                DBLogLocation += "_Log.ldf";

                Restore rstr = new Restore();
                rstr.Database = Conn.DatabaseName;
                rstr.Action = RestoreActionType.Database;
                
                rstr.Devices.AddDevice(BackupFilePath, DeviceType.File);
                rstr.ReplaceDatabase = true;
                rstr.FileNumber = 1;
                rstr.NoRecovery = true;

                rstr.RelocateFiles.Add(new RelocateFile(Conn.DatabaseName, DBLocation));
                rstr.RelocateFiles.Add(new RelocateFile(Conn.DatabaseName + "_Log", DBLogLocation));

                rstr.PercentCompleteNotification = 10;
                rstr.PercentComplete += new PercentCompleteEventHandler(RestorBackupProgressEventHandler);
                rstr.Complete += new ServerMessageEventHandler(RestorBackupCompleteEventHandler);

                _frmUpdate.lblState.Text += Environment.NewLine + "Starting building new database.";

                rstr.SqlRestore(Svr);
                rstr.Wait();

                if (rstr.SqlVerify(Svr, out ReturnMsg))
                {
                    _frmUpdate.lblState.Text += Environment.NewLine + "New build has been verified successfully!";
                }
                else
                {
                    _frmUpdate.lblState.Text += Environment.NewLine + "Error verifying database. " + ReturnMsg;
                    ReturnMsg = "";
                    Result = false;
                }
            }
            catch (Exception Exp)
            {
                ReturnMsg = Exp.Message;
                Result = false;
            }
            finally
            {
                try
                {
                    File.Delete(BackupFilePath);
                }
                catch (Exception Exp)
                {
                    ;
                }
            }

            return Result;
        }

        public static void RestorBackupProgressEventHandler(object sender, PercentCompleteEventArgs e)
        {
            _frmUpdate.lblState.Text += Environment.NewLine + e.Percent.ToString() + "% ...";
        }

        public static void RestorBackupCompleteEventHandler(object sender, ServerMessageEventArgs e)
        {
            _frmUpdate.lblState.Text += Environment.NewLine + "Building completed.";
        }
        
    }
}
