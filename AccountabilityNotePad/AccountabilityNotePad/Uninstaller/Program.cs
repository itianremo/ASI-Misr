using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;

namespace Uninstaller
{
    class Program
    {
        static void Main(string[] args)
        {
            //Remove User File
            string DirPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\USER";
            RemoveUserFolders(DirPath);

            //Close Running Service
            //CloseUpdateServise();

        }
        private static bool RemoveUserFolders(string UserDataPath)
        {
            try
            {
                string[] DirArray = Directory.GetDirectories(UserDataPath);
                DirArray = GetAbosluteNames(DirArray);
                for (int i = 0; i < DirArray.Length; i++)
                {
                    if (DirArray[i].Trim().Substring(0, 21).ToLower() == "accountabilitynotepad")
                    {
                        Directory.Delete(UserDataPath + @"\" + DirArray[i].Trim(), true);
                    }
                }
                return true;
            }
            catch(Exception Ecp)
            {
                string ErrMsg = Ecp.Message;
                return false;
            }
        }
        private static string[] GetAbosluteNames(string[] FullNames)
        {
            string[] AbsNames = new string[FullNames.Length];
            for (int i = 0; i < FullNames.Length; i++)
            {
                string AbsName = FullNames[i].Substring(FullNames[i].LastIndexOf(@"\") + 1, FullNames[i].Length - (FullNames[i].LastIndexOf(@"\") + 1));
                AbsNames[i] = AbsName;
            }
            return AbsNames;
        }
        private static bool CloseUpdateServise()
        {
            try
            {
                Process[] RunningProc = Process.GetProcessesByName("UpdateService");
                for (int i = 0; i < RunningProc.Length; i++)
                {
                    ((Process)RunningProc[i]).Kill();
                }
                return true;
            }
            catch (Exception Ecp)
            {
                string ErrMsg = Ecp.Message;
                return false;
            }
        }
    }
}