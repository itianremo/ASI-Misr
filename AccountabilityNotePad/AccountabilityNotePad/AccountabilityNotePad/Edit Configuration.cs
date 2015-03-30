using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Configuration;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.ObjectModel;

namespace AccountabilityNotePad
{
    public partial class Edit_Configuration : Form
    {
        private string FPath = Application.StartupPath + @"\AccountabilityNotePad.exe.config";
        string Server = "";
        bool Hide = false;
        bool MFGMode = false;
        public Edit_Configuration()
        {
            InitializeComponent();
        }
        //Form Load
        private void Edit_Configuration_Load(object sender, EventArgs e)
        {
            try
            {
                GetIntializationData();
            }
            catch (Exception Ecp)
            {
                MessageBox.Show(Ecp.Message, "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Get data from file for displaying it in the displayed form
        /// </summary>
        /// <returns>bool Readed</returns>
        private bool GetIntializationData()
        {
            bool Readed = false;
            try
            {
                XmlDocument AppFile = new XmlDocument();
                AppFile.Load(FPath);
                XmlNode AccSetting = AppFile.ChildNodes[1].ChildNodes[1].ChildNodes[0];
                int Brk = 0;
                for (int i = 0; i < AccSetting.ChildNodes.Count; i++)
                {
                    if (AccSetting.ChildNodes[i].Attributes["name"].Value.Trim() == "AccountabilityNotePad_AccRoutingServer_RoutingService")
                    {
                        string ServerName = AccSetting.ChildNodes[i].ChildNodes[0].InnerXml;
                        ServerName = ServerName.Trim();
                        ServerName = ServerName.Remove(0, 7);
                        ServerName = ServerName.Substring(0, ServerName.IndexOf("/"));
                        txtCurrent.Text = ServerName;
                        break;
                        //Brk++;
                    }
                    //if (Brk == 2)
                    //    break;
                }
                if (Properties.Settings.Default.HideApp == true)
                    cbAlwaysHide.Checked = true;
                else
                    cbAlwaysHide.Checked = false;

                rdBtnMFGMode.Checked = Properties.Settings.Default.MFGMode;

                Readed = true;
                Server = txtCurrent.Text.Trim();
                Hide = cbAlwaysHide.Checked;
                MFGMode = rdBtnMFGMode.Checked;
            }
            catch (Exception Ecp)
            {
                Readed = false;
                string ErrMsg = Ecp.Message;
            }
            #region Old Approach
            //try
            //{
            //    string[] Lines = new string[File.ReadAllLines(FPath).Length];
            //    Lines = File.ReadAllLines(FPath);
            //    TextLine = Lines[28].Trim();
            //    TextLine = TextLine.Remove(0,TextLine.IndexOf("<value>"));
            //    TextLine = TextLine.Remove(TextLine.IndexOf("</value>") + 8, TextLine.Length - (TextLine.IndexOf("</value>") + 8));
            //    TextLine = TextLine.Replace("<value>","");
            //    TextLine = TextLine.Replace("</value>","");
            //    txtCurrent.Text = TextLine.Trim();
            //    TextLine = Lines[31].Trim();
            //    TextLine = TextLine.Remove(0, TextLine.IndexOf("<value>"));
            //    TextLine = TextLine.Remove(TextLine.IndexOf("</value>") + 8, TextLine.Length - (TextLine.IndexOf("</value>") + 8));
            //    TextLine = TextLine.Replace("<value>", "");
            //    TextLine = TextLine.Replace("</value>", "");
            //    txtCurrntURL.Text = TextLine.Trim();

            //}
            //catch (Exception Ecp)
            //{

            //}
            #endregion
            return Readed;
        }
        /// <summary>
        /// Allow the user to change the server name
        /// </summary>
        /// <returns>bool changedsuccessfully</returns>
        private bool ChangeServerName()
        {
            bool Successfully = true;
            try
            {
                if (txtCurrent.Text.Trim() != "")
                {
                    XmlDocument AppFile = new XmlDocument();
                    AppFile.Load(FPath);
                    XmlNode AccSetting = AppFile.ChildNodes[1].ChildNodes[1].ChildNodes[0];
                    int Brk = 0;
                    for (int i = 0; i < AccSetting.ChildNodes.Count; i++)
                    {
                        if (AccSetting.ChildNodes[i].Attributes["name"].Value.Trim() == "AccountabilityNotePad_AccRoutingServer_RoutingService")
                        {
                            AccSetting.ChildNodes[i].ChildNodes[0].InnerXml = "http://" + txtCurrent.Text + "/maingui/AccRouting.asmx";
                            AppFile.Save(FPath);
                            Brk++;
                        }
                        if (AccSetting.ChildNodes[i].Attributes["name"].Value.Trim() == "AccountabilityNotePad_FoxProService_FoxProSrv")
                        {
                            AccSetting.ChildNodes[i].ChildNodes[0].InnerXml = "http://" + txtCurrent.Text + "/maingui/FoxProSrv.asmx";
                            AppFile.Save(FPath);
                            Brk++;
                        }
                        if (Brk == 2)
                            break;
                        #region Commented Code
                        //if (AccSetting.ChildNodes[i].Attributes["name"].Value.Trim() == "AccountabilityNotePad_GUI_GUI")
                        //{
                        //    AccSetting.ChildNodes[i].ChildNodes[0].InnerXml = "http://"+txtCurrent.Text+"/Accountability_WS/GUI.asmx";
                        //    Brk++;
                        //}
                        //else if (AccSetting.ChildNodes[i].Attributes["name"].Value.Trim() == "AccountabilityNotePad_EmployeesService_EmployeesService")
                        //{
                        //    AccSetting.ChildNodes[i].ChildNodes[0].InnerXml = "http://" + txtCurrent.Text + "/Accountability_WS/EmployeesService.asmx";
                        //    Brk++;
                        //}
                        //else if (AccSetting.ChildNodes[i].Attributes["name"].Value.Trim() == "AccountabilityNotePad_AccountabilityService_AccountabilityService")
                        //{
                        //    AccSetting.ChildNodes[i].ChildNodes[0].InnerXml = "http://" + txtCurrent.Text + "/Accountability_WS/AccountabilityService.asmx";
                        //    Brk++;
                        //}
                        //else if (AccSetting.ChildNodes[i].Attributes["name"].Value.Trim() == "AccountabilityNotePad_ERPSessionServices_ERPSessionServices")
                        //{
                        //   AccSetting.ChildNodes[i].ChildNodes[0].InnerXml = "http://" + txtCurrent.Text + "/Accountability_WS/ERPSessionServices.asmx";
                        //    Brk++;
                        //}
                        ////else if (AccSetting.ChildNodes[i].Attributes["name"].Value.Trim() == "ServerName")
                        ////{
                        ////    AccSetting.ChildNodes[i].ChildNodes[0].InnerXml = txtCurrent.Text;
                        ////    Brk++;
                        ////}
                        //if (Brk == 4)
                        //{
                        //    AppFile.Save(FPath);
                        //    Successfully = true;
                        //    break;
                        //}
                        #endregion
                    }

                    #region Old Approach
                    //ArrayList MyNewValues = new ArrayList();
                    //ArrayList MyLinesNumbers = new ArrayList();
                    //MyLinesNumbers.Add("13");
                    //MyLinesNumbers.Add("17");
                    //MyLinesNumbers.Add("21");
                    //MyLinesNumbers.Add("25");
                    //MyLinesNumbers.Add("28");
                    //MyNewValues.Add("<value>http://" + txtCurrent.Text + "/Accountability_WS/GUI.asmx</value>");
                    //MyNewValues.Add("<value>http://" + txtCurrent.Text + "/Accountability_WS/AccountabilityService.asmx</value>");
                    //MyNewValues.Add("<value>http://" + txtCurrent.Text + "/Accountability_WS/ERPSessionServices.asmx</value>");
                    //MyNewValues.Add("<value>http://" + txtCurrent.Text + "/Accountability_WS/EmployeesService.asmx</value>");
                    //MyNewValues.Add("<value>" + txtCurrent.Text + "</value>");
                    //Successfully = EditFile(MyLinesNumbers, MyNewValues);
                    #endregion

                    if (Successfully)
                    {
                        //////Update Registery
                        UpdateManager UpdtMgr = new UpdateManager();
                        UpdtMgr.SetStringValue(Microsoft.Win32.Registry.LocalMachine, @"SOFTWARE\Accountability Notepad\Server", "RoutingService", txtCurrent.Text);
                        Successfully = true;
                    }
                }
                else
                {
                    Successfully = false;
                    MessageBox.Show("Server name cannot be null", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception Ecp)
            {
                Successfully = false;
                string ErrMsg = Ecp.Message;
            }
            return Successfully;
        }
        ///// <summary>
        ///// Allow the user to change the URL
        ///// </summary>
        ///// <returns>bool changedsuccessfully</returns>
        //private bool ChangeURL()
        //{
        //    bool Successfully = false;
        //    try
        //    {
        //        if (txtCurrntURL.Text.Trim() != "")
        //        {
        //            XmlDocument AppFile = new XmlDocument();
        //            AppFile.Load(FPath);
        //            XmlNode AccSetting = AppFile.ChildNodes[1].ChildNodes[1].ChildNodes[0];
        //            for (int i = 0; i < AccSetting.ChildNodes.Count; i++)
        //            {
        //                if (AccSetting.ChildNodes[i].Attributes["name"].Value.Trim() == "ServerUpdatesLocation")
        //                {
        //                    AccSetting.ChildNodes[i].ChildNodes[0].InnerXml = txtCurrntURL.Text;
        //                    AppFile.Save(FPath);
        //                    Successfully = true;
        //                    break;
        //                }
        //            }
        //            #region Old Approach
        //            ////////Update File
        //            //string NewURL = txtCurrntURL.Text;
        //            //if (!NewURL.EndsWith(@"\"))
        //            //    NewURL = NewURL + @"\";
        //            //ArrayList MyNewValues = new ArrayList();
        //            //ArrayList MyLinesNumbers = new ArrayList();
        //            //MyLinesNumbers.Add("31");
        //            //MyNewValues.Add("<value>" + NewURL + "</value>");
        //            //Successfully = EditFile(MyLinesNumbers, MyNewValues);
        //            #endregion
        //            if (Successfully)
        //            {
        //                //////Update Registery
        //                UpdateManager UpdtMgr = new UpdateManager();
        //                UpdtMgr.SetStringValue(Microsoft.Win32.Registry.LocalMachine, @"SOFTWARE\Accountability Notepad\Server", "UpdateLocation", txtCurrntURL.Text);
        //                Successfully = true;
        //            }
        //        }
        //        else
        //        {
        //            Successfully = false;
        //            MessageBox.Show("URL cannot be null", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception Ecp)
        //    {
        //        Successfully = false;
        //        string ErrMsg = Ecp.Message;
        //    }
        //    return Successfully;
        //}
        /// <summary>
        /// Change Always Hide Status
        /// </summary>
        /// <returns>bool changedsuccessfully</returns>
        private bool SetAlwaysHideFlag()
        {
            bool Successfully = true;
            try
            {
                Properties.Settings.Default.HideApp = cbAlwaysHide.Checked;
                Properties.Settings.Default.Save();
            }
            catch (Exception Ecp)
            {
                string ErrMsg = Ecp.Message;
                Successfully = false;
            }
            return Successfully;
        }
        /// <summary>
        /// Change Default Start Mode Status
        /// </summary>
        /// <returns>bool changedsuccessfully</returns>
        private bool SetStartModeFlag()
        {
            bool Successfully = true;
            try
            {
                Properties.Settings.Default.MFGMode = rdBtnMFGMode.Checked;
                Properties.Settings.Default.Save();
            }
            catch (Exception Ecp)
            {
                string ErrMsg = Ecp.Message;
                Successfully = false;
            }
            return Successfully;
        }
        //Button Cancel
        private void btnClosURL_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Button OK
        private void btnSaveAllChanges_Click(object sender, EventArgs e)
        {
            int SaveWithMessage = 0;
            if (txtCurrent.Text.Trim() != Server)
            {
                if (ChangeServerName())
                {
                    SaveWithMessage = 2;
                }
                else
                    MessageBox.Show("Error occurred. Couldn't change Server Name", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (Hide != cbAlwaysHide.Checked)
            {
                if (SetAlwaysHideFlag())
                {
                    if (SaveWithMessage != 2)
                        SaveWithMessage = 1;
                }
                else
                    MessageBox.Show("Error occurred. Couldn't change Always Hide Application option", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (MFGMode != rdBtnMFGMode.Checked)
            {
                if (SetStartModeFlag())
                {
                    if (SaveWithMessage != 2)
                        SaveWithMessage = 1;
                }
                else
                    MessageBox.Show("Error occurred. Couldn't change Always Hide Application option", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (SaveWithMessage != 0)
            {
                if (SaveWithMessage == 2)
                    MessageBox.Show("Changes Saved Successfully,Please close the application and open it again to apply changes", "Edit Configuration", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                else
                    MessageBox.Show("Changes Saved Successfully", "Edit Configuration", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            this.Close();
        }
        /// <summary>
        /// Update the data file when the user change URL or ServerName and save these changes to the data file
        /// </summary>
        /// <param name="LineNumber">ArrayList LineNumber</param>
        /// <param name="NewValues">ArrayList NewValues</param>
        /// <returns>bool Updated</returns>
        private bool EditFile(ArrayList LineNumber, ArrayList NewValues)
        {
            bool Successfully = false;
            try
            {
                if (File.Exists(FPath))
                {
                    string[] Lines = new string[File.ReadAllLines(FPath).Length];
                    Lines = File.ReadAllLines(FPath);
                    for (int f = 0; f < LineNumber.Count; f++)
                    {
                        for (int h = 0; h < Lines.Length; h++)
                        {
                            if (LineNumber[f].ToString() == h.ToString())
                                Lines[h] = NewValues[f].ToString();
                        }
                    }
                    File.WriteAllLines(FPath, Lines);
                    Successfully = true;
                }
            }
            catch (Exception Ecp)
            {
                string ErrMsg = Ecp.Message;
                Successfully = false;
            }
            return Successfully;
        }

        ////Button Browse
        //private void btnBrws_Click(object sender, EventArgs e)
        //{
        //    DialogResult Dlg = URLBrowser.ShowDialog();
        //    if (Dlg == DialogResult.OK)
        //    {
        //        txtCurrntURL.Text = URLBrowser.SelectedPath;
        //    }
        //}
    }
}