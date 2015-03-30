using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Pharma.BMD.BLL;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.IO;

public partial class ManageData : MasterClass
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CurrentUserInfo.IsAdminRank)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
    protected void btnGetDB_Click(object sender, EventArgs e)
    {
        try
        {
            string ConnName = (txtConnName.Text.Length > 0) ? txtConnName.Text : "PharmaBkConnectionString";
            ServerConnection Conn = new ServerConnection(new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings[ConnName].ConnectionString));
            Conn.Connect();

            Server srvSql = new Server(Conn);

            Backup bkpDatabase = new Backup();

            // Set the backup type to a database backup
            bkpDatabase.Action = BackupActionType.Database;

            // Set the database that we want to perform a backup on
            bkpDatabase.Database = "BMD";

            string BackupDirectoryPath = "";

            if (cbxBackupOnMis.Checked)
                BackupDirectoryPath = "F:\\MISBackup\\BMD";
            else
                BackupDirectoryPath = Path.Combine(Request.PhysicalApplicationPath, "Temp");

            // Set the backup device to a file
            BackupDeviceItem bkpDevice = new BackupDeviceItem(BackupDirectoryPath + "\\BMD.bak", DeviceType.File);

            // Add the backup device to the backup
            bkpDatabase.Devices.Add(bkpDevice);

            // Perform the backup
            bkpDatabase.SqlBackup(srvSql);

            lblMsg.Text = " „ Ã·» ‰”Œ… »‰Ã«Õ";
        }
        catch (Exception ex)
        {
            string ErrStr = ex.Message;
            Exception innerEx = ex.InnerException;

            while (innerEx != null)
            {
                ErrStr += "<br>" + innerEx.Message;
                innerEx = innerEx.InnerException;
            }

            lblMsg.Text = ErrStr;
        }
    }
    protected void btnSetDB_Click(object sender, EventArgs e)
    {
        int ActiveConn = 0;
        try
        {
            string ConnName = (txtConnName.Text.Length > 0) ? txtConnName.Text : "PharmaBkConnectionString";
            ServerConnection Conn = new ServerConnection(new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings[ConnName].ConnectionString));
            Conn.Connect();

            Server srvSql = new Server(Conn);
            ActiveConn = srvSql.GetActiveDBConnectionCount("BMD");

            //srvSql.Databases["CARSCENTER"].SetOffline();
            if (cbxKillAllConns.Checked)
                srvSql.KillAllProcesses("BMD");
            // Create a new database restore operation

            Restore rstDatabase = new Restore();

            // Set the restore type to a database restore

            rstDatabase.Action = RestoreActionType.Database;

            // Set the database that we want to perform the restore on

            rstDatabase.Database = "BMD";

            string BackupDirectoryPath;

            if (cbxBackupOnMis.Checked)
                BackupDirectoryPath = "F:\\MISBackup\\BMD";
            else
                BackupDirectoryPath = Path.Combine(Request.PhysicalApplicationPath, "Temp");

            // Set the backup device from which we want to restore, to a file

            BackupDeviceItem bkpDevice = new BackupDeviceItem(BackupDirectoryPath + "\\BMD.bak", DeviceType.File);

            // Add the backup device to the restore type

            rstDatabase.Devices.Add(bkpDevice);

            // If the database already exists, replace it

            rstDatabase.ReplaceDatabase = true;

            // Perform the restore

            rstDatabase.SqlRestore(srvSql);

            lblMsg.Text = " „ —›⁄ ‰”Œ… »‰Ã«Õ";
        }
        catch (Exception ex)
        {
            string ErrStr = ex.Message;
            Exception innerEx = ex.InnerException;

            while (innerEx != null)
            {
                ErrStr += "<br>" + innerEx.Message;
                innerEx = innerEx.InnerException;
            }

            lblMsg.Text = ErrStr + "<br>Active conn:" + ActiveConn;
        }
    }
}
