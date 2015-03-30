using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace ConfigurationGenerator
{
    class Program
    {
        private static XmlDocument AppFile;

        static int Main(string[] args)
        {
            int ExitCode = 1;
            try
            {
                //args = new string[2];
                //args[0] = "C:\\Program Files\\TSN\\Accountability Notepad\\2\\AccountabilityNotePad.exe.config";
                //args[1] = "C:\\Program Files\\TSN\\Accountability Notepad\\1\\AccountabilityNotePad.exe.config";
                
                if (args.Length == 2 && args[0].Length != 0 && args[1].Length != 0)
                {
                    args[0] = args[0].Replace("?", " ");
                    args[1] = args[1].Replace("?", " ");

                    // Transfere .Config file from old folder to current folder.
                    AppFile = new XmlDocument();
                    AppFile.Load(args[0]);
                    AppFile.Save(args[1]);

                    // Build 3.
                    // Build_3_Method(args);

                    // Build 4.
                    // Build_4_Method(args);

                    // Build 5.
                    // Build_5_Method(args);
                }
                else
                {
                    File.AppendAllText("Error.log", "Invalid arguments.");
                    File.AppendAllText("Error.log", "Arg(0): " + args[0]);
                    File.AppendAllText("Error.log", "Arg(1): " + args[1]);
                }
            }
            catch(Exception ex)
            {
                File.WriteAllText("Error.log", ex.Message + "\n" + ex.Data);
                ExitCode = 0;
            }
            return ExitCode;
        }

        private static void Build_5_Method(string[] args)
        {
            // Stop AUUW to prepare for replacing new AUUW's files.
            Process[] AllProcesses = Process.GetProcessesByName("ANPUpdaterUtilityService");
            foreach (Process proc in AllProcesses)
                proc.Kill();

            System.Threading.Thread.Sleep(1300);

            File.WriteAllText("log.log", "Stop AUUW to prepare for replacing new AUUW's files", System.Text.Encoding.UTF8);

            // Replace new files for AUUW
            string AnpPath = args[1].Replace("AccountabilityNotePad.exe.config", "ANPUpdaterUtilityService.XmlSerializers.dll");
            string Auuw_Auua_Path = AnpPath.Replace("1", "").Replace("2", "").Replace("Accountability Notepad\\", "AUUW");

            File.AppendAllText("log.log", "\nReplace new files for AUUW", System.Text.Encoding.UTF8);
            File.AppendAllText("log.log", "\nAnpPath: " + AnpPath);
            File.AppendAllText("log.log", "\nAuuw_Auua_Path: " + Auuw_Auua_Path);

            File.SetAttributes(Auuw_Auua_Path, FileAttributes.Normal);
            File.SetAttributes(AnpPath, FileAttributes.Normal);
            File.Delete(Auuw_Auua_Path);
            File.Copy(AnpPath, Auuw_Auua_Path);
            File.Delete(AnpPath);

            AnpPath = AnpPath.Replace("ANPUpdaterUtilityService.XmlSerializers.dll", "ANPUpdaterUtilityService.exe");
            Auuw_Auua_Path = Auuw_Auua_Path.Replace("ANPUpdaterUtilityService.XmlSerializers.dll", "ANPUpdaterUtilityService.exe");
            string AUUW = Auuw_Auua_Path;

            File.AppendAllText("log.log", "\nReplace new files for AUUW");
            File.AppendAllText("log.log", "\nAnpPath: " + AnpPath);
            File.AppendAllText("log.log", "\nAuuw_Auua_Path: " + Auuw_Auua_Path);

            File.SetAttributes(Auuw_Auua_Path, FileAttributes.Normal);
            File.SetAttributes(AnpPath, FileAttributes.Normal);
            File.Delete(Auuw_Auua_Path);
            File.Copy(AnpPath, Auuw_Auua_Path);
            File.Delete(AnpPath);

            // Update the AUUA's XML with current folder
            AnpPath = AnpPath.Replace("ANPUpdaterUtilityService.exe", "AUUAConfiguration.xml");
            Auuw_Auua_Path = Auuw_Auua_Path.Replace("ANPUpdaterUtilityService.exe", "Configuration.xml").Replace("AUUW", "AUUA");

            string CurrentFolder = GetStringValue(Microsoft.Win32.Registry.LocalMachine, @"SOFTWARE\Accountability Notepad\AUUA", "CurrentFolder");
            //CurrentFolder = (CurrentFolder == "1") ? "2" : "1";

            File.AppendAllText("log.log", "\nUpdate the AUUA's XML with current folder");
            File.AppendAllText("log.log", "\nAnpPath: " + AnpPath);
            File.AppendAllText("log.log", "\nCurrentFolder: " + CurrentFolder);

            XMLUtility XmlConf = new XMLUtility(AnpPath);
            XmlConf.EditKey("CurrentFolder", CurrentFolder);


            File.AppendAllText("log.log", "\nUpdate AUUA with XML file");
            File.AppendAllText("log.log", "\nAnpPath: " + AnpPath);
            File.AppendAllText("log.log", "\nAuuw_Auua_Path: " + Auuw_Auua_Path);

            // Update AUUA with XML file
            File.Copy(AnpPath, Auuw_Auua_Path);
            File.Delete(AnpPath);

            // Update AUUA with Alternating Loader
            AnpPath = AnpPath.Replace("AUUAConfiguration.xml", "AUUAAlternatingLoader.exe");
            Auuw_Auua_Path = Auuw_Auua_Path.Replace("Configuration.xml", "AlternatingLoader.exe");

            File.AppendAllText("log.log", "\nUpdate AUUA with Alternating Loader");
            File.AppendAllText("log.log", "\nAnpPath: " + AnpPath);
            File.AppendAllText("log.log", "\nAuuw_Auua_Path: " + Auuw_Auua_Path);

            File.SetAttributes(Auuw_Auua_Path, FileAttributes.Normal);
            File.SetAttributes(AnpPath, FileAttributes.Normal);
            File.Delete(Auuw_Auua_Path);
            File.Copy(AnpPath, Auuw_Auua_Path);
            File.Delete(AnpPath);

            // Update the ANP's XML with current folder
            AnpPath = AnpPath.Replace("AUUAAlternatingLoader.exe", "ANPConfiguration.xml");
            Auuw_Auua_Path = Auuw_Auua_Path.Replace("AUUA", "Accountability Notepad").Replace("AlternatingLoader.exe", "Configuration.xml");

            CurrentFolder = GetStringValue(Microsoft.Win32.Registry.LocalMachine, @"SOFTWARE\Accountability Notepad", "CurrentFolder");
            CurrentFolder = (CurrentFolder == "1") ? "2" : "1";

            File.AppendAllText("log.log", "\nUpdate the ANP's XML with current folder");
            File.AppendAllText("log.log", "\nAnpPath: " + AnpPath);
            File.AppendAllText("log.log", "\nAuuw_Auua_Path: " + Auuw_Auua_Path);
            File.AppendAllText("log.log", "\nCurrentFolder: " + CurrentFolder);

            XmlConf = new XMLUtility(AnpPath);
            XmlConf.EditKey("CurrentFolder", CurrentFolder);
            XmlConf.EditKey("Version", "10043");

            // Update ANP with XML file
            File.Copy(AnpPath, Auuw_Auua_Path);
            File.Delete(AnpPath);

            // Update ANP with Alternating Loader
            AnpPath = AnpPath.Replace("ANPConfiguration.xml", "ANPAlternatingLoader.exe");
            Auuw_Auua_Path = Auuw_Auua_Path.Replace("Configuration.xml", "AlternatingLoader.exe");

            File.AppendAllText("log.log", "\nUpdate ANP with Alternating Loader");
            File.AppendAllText("log.log", "\nAnpPath: " + AnpPath);
            File.AppendAllText("log.log", "\nAuuw_Auua_Path: " + Auuw_Auua_Path);

            File.SetAttributes(Auuw_Auua_Path, FileAttributes.Normal);
            File.SetAttributes(AnpPath, FileAttributes.Normal);
            File.Delete(Auuw_Auua_Path);
            File.Copy(AnpPath, Auuw_Auua_Path);
            File.Delete(AnpPath);

            // Start AUUW
            Process.Start(AUUW);

            File.AppendAllText("log.log", "\nStart AUUW");
            File.AppendAllText("log.log", "\nAUUW: " + AUUW);
        }

        private static void Build_4_Method(string[] args)
        {
            if (File.Exists("Install.exe"))
            {
                ProcessStartInfo procStrtInfo = new ProcessStartInfo(args[1] + "\\Install.exe");
                procStrtInfo.CreateNoWindow = false;
                procStrtInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process proc = Process.Start(procStrtInfo);
                proc.WaitForExit();

                if (proc.ExitCode != 1)
                    throw new Exception("Can't run installation file.");
            }
        }

        private static void Build_3_Method(string[] args)
        {
            AppFile = new XmlDocument();
            AppFile.Load(args[0]);

            if (!KeyExists("AccountabilityWebServiceURL"))
            {
                if (!AddApplicationSetting("AccountabilityWebServiceURL", "Accountability_WS"))
                    throw new Exception("Can't add setting element to configuration file.");
            }

            if (KeyExists("ServerUpdatesLocation"))
            {
                if (!DeleteSetting("ServerUpdatesLocation"))
                    throw new Exception("Can't delete setting element of configuration file.");
            }

            AppFile.Save(args[1]);
        }

        private static bool DeleteSetting(string attrName)
        {
            try
            {
                XmlNode appSettingsNode = AppFile.DocumentElement.SelectSingleNode("applicationSettings/AccountabilityNotePad.Properties.Settings");
                foreach (XmlNode ChildNode in appSettingsNode)
                {
                    if (ChildNode.Attributes["name"].Value == attrName)
                    {
                        appSettingsNode.RemoveChild(ChildNode);
                        return true;
                    }
                }
            }
            catch
            { }

            return false;
        }

        private static bool AddApplicationSetting(string name, string value)
        {
            bool result = false;

            try
            {
                XmlElement elem = AppFile.CreateElement("setting");
                elem.SetAttribute("name", name);
                elem.SetAttribute("serializeAs", "String");
                elem.InnerXml = "<value>" + value + "</value>";
                AppFile.ChildNodes[1].ChildNodes[1].ChildNodes[0].AppendChild(elem);
                result = true;
            }
            catch
            { }

            return result;
        }

        private static bool KeyExists(string strKey)
        {
            try
            {
                XmlNode appSettingsNode = AppFile.DocumentElement.SelectSingleNode("applicationSettings/AccountabilityNotePad.Properties.Settings");
                // Attempt to locate the requested setting.
                foreach (XmlNode childNode in appSettingsNode)
                {
                    if (childNode.Attributes["name"].Value == strKey)
                        return true;
                }
            }
            catch
            { }

            return false;
        }

        /// <summary>
        /// Retrieves the specified String value. Returns a System.String object
        /// </summary>
        private static string GetStringValue(RegistryKey hiveKey, string strSubKey, string strValue)
        {
            object objData = null;
            RegistryKey subKey = null;

            try
            {
                subKey = hiveKey.OpenSubKey(strSubKey);
                if (subKey == null)
                {
                    //MessageBox.Show("Cannot open the specified sub-key", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                objData = subKey.GetValue(strValue);
                if (objData == null)
                {
                    //MessageBox.Show("Cannot open the specified value", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                subKey.Close();
                hiveKey.Close();
            }
            catch (Exception exc)
            {
                //MessageBox.Show(exc.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return objData.ToString();
        }
    }
}
