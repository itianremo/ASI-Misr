using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Data;
using System.Diagnostics;
using AccountabilityNotePad.Data;
using Microsoft.Win32;
using System.DirectoryServices;
using System.Security.Principal;

namespace AccountabilityNotePad
{
    public class UpdateManager
    {
        public UpdateManager() //class constructor
        { 
        
        }
        // Declare Needed Variables
        public string strRegError; //this variable contains the error message (null when no error occured)
        private string CurrentfileVer;
        private string ServerfileName;
        private string ServerfileVer;
        private int UpdateMode = -1;
  
        /// <summary>
        /// Sets/creates the specified String value
        /// </summary>
        public void SetStringValue(RegistryKey hiveKey, string strSubKey, string strValue, string strData)
        {
            RegistryKey subKey = null;

            try
            {
                subKey = hiveKey.CreateSubKey(strSubKey);
                if (subKey == null)
                {
                    strRegError = "Cannot create/open the specified sub-key";
                    return;
                }
                subKey.SetValue(strValue, strData);
                subKey.Close();
                hiveKey.Close();
            }
            catch (Exception exc)
            {
                strRegError = exc.Message;
                return;
            }

            strRegError = null;
            return;
        }
        /// <summary>
        /// Retrieves the specified String value. Returns a System.String object
        /// </summary>
        public string GetStringValue(RegistryKey hiveKey, string strSubKey, string strValue)
        {
            object objData = null;
            RegistryKey subKey = null;

            try
            {
                subKey = hiveKey.OpenSubKey(strSubKey);
                if (subKey == null)
                {
                    strRegError = "Cannot open the specified sub-key";
                    return null;
                }
                objData = subKey.GetValue(strValue);
                if (objData == null)
                {
                    strRegError = "Cannot open the specified value";
                    return null;
                }
                subKey.Close();
                hiveKey.Close();
            }
            catch (Exception exc)
            {
                strRegError = exc.Message;
                return null;
            }

            strRegError = null;
            return objData.ToString();
        }
       
        /// <summary>
        /// Get the current running version installed on the user computer
        /// </summary>
        private void GetRunningVer()
        {
            string RegValue = GetStringValue(Microsoft.Win32.Registry.LocalMachine, @"SOFTWARE\Accountability Notepad", "Version");
            if (RegValue != null)
            {
                CurrentfileVer = RegValue.Replace(".", "");
            }
        }
        /// <summary>
        /// Get the current running version installed on the server
        /// </summary>
        /// <returns>bool DirectoryFound</returns>
        private bool GetLatestServerVersion()
        {
            bool result = true;
            string FileExt = "*.exe";
            string UpdateLocation = Properties.Settings.Default.ServerUpdatesLocation;
            dsFilesList dsFilesListInst = new dsFilesList();

            DirectoryInfo dirInfo = new DirectoryInfo(UpdateLocation);
            if (dirInfo.Exists)
            {
                string[] fileCollection = FileSearchpattern.GetFiles(UpdateLocation, FileExt, false);
                if (fileCollection.Length != 0)
                {
                    foreach (string fileName in fileCollection)
                    {
                        dsFilesList.dtFilesListRow row = dsFilesListInst.dtFilesList.NewdtFilesListRow();
                        FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(fileName);
                        //
                        string fileNameWithoutPath = Path.GetFileName(myFileVersionInfo.FileName);
                        row.FileName = fileNameWithoutPath;
                        row.ProductVersion = myFileVersionInfo.ProductVersion;
                        dsFilesListInst.dtFilesList.AdddtFilesListRow(row);
                    }
                    dsFilesListInst.AcceptChanges();
                    string Filter = "FileName like 'Accountability%'";
                    DataRow[] drs = dsFilesListInst.dtFilesList.Select(Filter, "ProductVersion DESC");
                    //// setting variables //
                    ServerfileName = drs[0].ItemArray[0].ToString();
                    ServerfileVer = drs[0].ItemArray[1].ToString().Replace(".","");
                }
            }
            else
            {
                UpdateMode = 0;
                result = false;
            }
            return result;
        }
        /// <summary>
        /// Check if the version installed on the user computer is the last version or not
        /// </summary>
        /// <returns>bool lastversion</returns>
        private bool IsCurrentVersionsIsLast() 
        {
            bool result = true;
            //// Set The Variables by calling this two methods
            GetRunningVer();
            GetLatestServerVersion();
                ////
                //// comparing the two dates of the runnung version and the one on the server //    
                if (CurrentfileVer != null && ServerfileVer != null)
                {
                    if (int.Parse(ServerfileVer) > int.Parse(CurrentfileVer))
                    {
                        result = false; // this indicates that current version is not the last version //
                    }
                }
            return result;
        }
        /// <summary>
        /// Check if the version installed on the user computer is the last version or not, if not, download the last version 
        /// </summary>
        /// <returns>int Downloaded</returns>
        public int DownLoadLatestVerion()
        {
            bool IsAdmin = true;
            using (WindowsIdentity ident = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(ident);
                IsAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            if (IsAdmin)
            {
                if (!IsCurrentVersionsIsLast())
                {
                    UpdateMode = 2; // indicates the progress of download latest version
                    DialogResult dr = MessageBox.Show("New version is available, Update current version?", "Confirm Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        DownLoadLastVersion();
                    }
                }
                else if (UpdateMode != 0)
                {
                    UpdateMode = 1;// indicate That user version is the latest version //
                }
            }
            else
                UpdateMode = -1;
            return UpdateMode;
        }
        /// <summary>
        /// Download the last version to the the user computer 
        /// </summary>
        //private void DownLoadLastVersion(LoginForm CurrentForm , string TempPath , string ServerName)
        private void DownLoadLastVersion()
        {
            Process[] RunningANPs = Process.GetProcessesByName("AccountabilityNotePad");
            if (!(RunningANPs.Length > 1))
            {
                Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = Properties.Settings.Default.ServerUpdatesLocation + "\\" + ServerfileName;
                //LoginForm LFrm = new LoginForm();
                //LFrm.SaveClientDataSet(CurrentForm.AccSet);
                //FileAccess.FileAccessService FAS = new AccountabilityNotePad.FileAccess.FileAccessService();
                //FAS.Url = "http://" + ServerName + "/FileAccessWS/FileAccessService.asmx";
                //FAS.UpdateMultipleFiles("C", false);
                //DynamicUpdate.UpdateMultipleFiles("C", TempPath, false);
                proc.Start();
            }
            else
            {
                MessageBox.Show("You can not run the upgrade now as there are other users running the same application","Upgrade Problem",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
