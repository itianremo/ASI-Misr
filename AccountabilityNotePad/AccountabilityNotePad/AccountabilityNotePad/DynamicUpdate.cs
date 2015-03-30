using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Security.Principal;
using Microsoft.Win32;

namespace AccountabilityNotePad
{
    public class DynamicUpdate
    {
        public DynamicUpdate()
        {
        }
        public static string GetUpdateMode(string ServerName)
        {
            FileAccess.FileAccessService FAS = new AccountabilityNotePad.FileAccess.FileAccessService();
            FAS.Url = "http://" + ServerName + "/FileAccessWS/FileAccessService.asmx";
            string UpdateValue = FAS.GetUpdateMode(Environment.UserName);
            //string UpdateValue = "";
            //try
            //{
            //    string[] AllLines = File.ReadAllLines(GetFilePath(TempPath));
            //    if (AllLines.Length > 0)
            //    {
            //        if (AllLines[0] == "C")
            //        {
            //            UpdateValue = "C";
            //            ClearFile(TempPath);
            //        }
            //    }
            //}
            //catch (Exception Ecp)
            //{
            //    string ErrMsg = Ecp.Message;
            //}
            return UpdateValue;
        }
        private static string GetFilePath(int PathType , string TempFolderPath)
        {
            string FilePath = TempFolderPath;
            if (PathType == 1)
                FilePath += @"\Updates\" + Environment.UserName + ".txt";
            else if (PathType == 0)
                FilePath += @"\Updates\CurrentUsers.txt";
            return FilePath;
        }
        private static string GetFilePath(string TempFolderPath)
        {
            string FPath = TempFolderPath + @"\Updates\";
            string[] AllFiles = Directory.GetFiles(FPath);
            AllFiles = GetAbosluteName(AllFiles);
            bool AlreadyExit = false;
            string FilePath = TempFolderPath + @"\Updates\";
            for (int i = 0; i < AllFiles.Length ; i++)
            {
                if (AllFiles[i] == Environment.UserName + ".txt")
                {
                    AlreadyExit = true;
                    FilePath+= AllFiles[i];
                    break;
                }
            }
            if (!AlreadyExit)
            {
                for (int i = 0; i < AllFiles.Length; i++)
                {
                    string Pattern = AllFiles[i];
                    if (Pattern.Contains("-"))
                    {
                        Pattern = Pattern.Substring(Pattern.LastIndexOf("-"), Pattern.Length - Pattern.LastIndexOf("-"));
                        if (Pattern == "-UpdateUser.txt")
                        {
                            string Name = AllFiles[i].Substring(0, AllFiles[i].LastIndexOf("-"));
                            if (Name == Environment.UserName)
                            {
                                FilePath+= AllFiles[i];
                                break;
                            }
                        }
                    }
                }
            }
            return FilePath;
        }
        private static void ClearFile(string TempPath)
        {
            File.WriteAllText(GetFilePath(1 , TempPath), "");
        }
        public static void UpdateMultipleFiles(string UpdateMode , string TempPath , bool ReloadUsers)
        {
            //if (!ReloadUsers)
            //{
            //    string[] FileNames = Directory.GetFiles(TempPath + @"\Temp");
            //    FileNames = GetAbosluteName(FileNames);
            //    for (int i = 0; i < FileNames.Length; i++)
            //    {
            //        if (!(Directory.Exists(TempPath + @"\Updates")))
            //            Directory.CreateDirectory(TempPath + @"\Updates");
            //        string FilePath = "";
            //        if (FileNames[i].Trim().ToLower() != (Environment.UserName.Trim().ToLower() + ".txt"))
            //        {
            //            FilePath = TempPath + @"\Updates\" + FileNames[i];
            //        }
            //        else
            //        {
            //            FilePath = TempPath + @"\Updates\" + Environment.UserName + "-UpdateUser.txt";
            //        }
            //        File.WriteAllText(FilePath, UpdateMode);
            //    }
            //    //if (FileNames.Length > 0)
            //    //    SaveCurrentUsers(FileNames, TempPath);
            //}
            //else
            //{
            //    string[] UpdateUser = Directory.GetFiles(TempPath + @"\Updates");
            //    UpdateUser = GetAbosluteName(UpdateUser);
            //    string UserFilePath = "";
            //    for (int u = 0; u < UpdateUser.Length; u++)
            //    {
            //        if (UpdateUser[u].Trim().ToLower() != (Environment.UserName.Trim().ToLower() + ".txt"))
            //        {
            //            UserFilePath = TempPath + @"\Updates\" + UpdateUser[u];
            //            File.WriteAllText(UserFilePath, UpdateMode);
            //        }
            //    }
            //}
        }
        private static string[] GetAbosluteName(string[] FileNames)
        {
            string[] AbsFileNames = new string[FileNames.Length];
            for (int i = 0; i < FileNames.Length; i++)
            {
                AbsFileNames[i] = FileNames[i].Substring(FileNames[i].LastIndexOf(@"\") + 1, FileNames[i].Length - (FileNames[i].LastIndexOf(@"\") + 1));
            }
            return AbsFileNames;
        }
        public static void UpdateMultipleFiles(ArrayList UsersList, string UpdateMode)
        {
            try
            {
                string FilePath = "";
                for (int i = 0; i < UsersList.Count; i++)
                {
                    FilePath = Environment.SystemDirectory.Substring(0, 1) + @":\Documents and Settings\" + UsersList[i].ToString().Trim() + @"\UpdateMode.txt";
                    File.WriteAllText(FilePath, UpdateMode);
                }
            } 
            catch (Exception Ecp)
            {
                string ErrMsg = Ecp.Message;
            }
        }
        public static void SaveCurrentUsers(string [] UserList , string TempFolderPath)
        {
            try
            {
                string UserFilePath = GetFilePath(0, TempFolderPath);
                File.WriteAllLines(UserFilePath, UserList);
            }
            catch (Exception Ecp)
            {
                string ErrMsg = Ecp.Message;
            }
        }
        public static ArrayList LoadCurrentUsers()
        {
            ArrayList UsersList = new ArrayList();
            try
            {
                string UserFilePath = ""; //GetFilePath(0);
                if (File.Exists(UserFilePath))
                {
                    string[] NamesList = File.ReadAllLines(UserFilePath);
                    UsersList = new ArrayList();
                    for (int i = 0; i < NamesList.Length; i++)
                    {
                        UsersList.Add(NamesList[i]);
                    }
                }
            }
            catch (Exception Ecp)
            {
                string ErrMsg = Ecp.Message;
            }
            return UsersList;
        }
        public static void RunUdpateService()
        {
            try
            {
                string ProcessPath = GetStringValue(Microsoft.Win32.Registry.LocalMachine, @"SOFTWARE\Accountability Notepad\Path", "") +@"\UpdateService.exe";
                //string ProcessPath = @"D:\AccountabilityNotePad\AccountabilityNotePad\bin\Debug\UpdateService.exe";
                Process.Start(ProcessPath);
            }
            catch (Exception Ecp)
            {
                string ErrMsg = Ecp.Message;
            }
        }
        private static string GetStringValue(RegistryKey hiveKey, string strSubKey, string strValue)
        {
            object objData = null;
            RegistryKey subKey = null;
            string strRegError = "";
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
        private static string SplitUserName(string FullUserName)
        {
            string UserName = "";
            UserName = FullUserName.Substring(FullUserName.IndexOf(@"\") + 1 , FullUserName.Length - (FullUserName.IndexOf(@"\") + 1));
            return UserName;
        }
        public static void RemoveUpdateFile(string ExecutionPath , string ServerName)
        {
            FileAccess.FileAccessService FileAccessSrv = new AccountabilityNotePad.FileAccess.FileAccessService();
            FileAccessSrv.Url = "http://" + ServerName + "/FileAccessWS/FileAccessService.asmx";
            FileAccessSrv.RemoveUpdateFile(Environment.UserName);
            //string UFPath = ExecutionPath + @"\Updates\" + Environment.UserName + "-UpdateUser.txt";
            //if (File.Exists(UFPath))
            //{
            //    File.Delete(UFPath);
            //}
        }
        public static void CloseUpdater()
        {
            Process[] Updaters = Process.GetProcessesByName("WaitingUpdater");
            if (Updaters.Length > 0)
            {
                foreach (Process Prc in Updaters)
                {
                    Prc.Kill();
                }
            }
        }
        public static void RunUpdater(string ExecutionPath)
        {
            string ProcPath = ExecutionPath + @"\WaitingUpdater.exe";
            try
            {
                Process.Start(ProcPath);
            }
            catch(Exception Ecp)
            {
                string ErrMsg = Ecp.Message;
            }
        }
    }
}
