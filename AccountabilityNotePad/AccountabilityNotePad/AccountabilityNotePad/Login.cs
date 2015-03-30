using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
//using System.IO;
using System.Security.Cryptography;
using AdvancedDataGridView;
using System.Configuration;
using System.Collections;
using System.Threading;
//using System.Runtime.Serialization.Formatters.Binary;
using AccountabilityNotePad.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using mshtml;
using System.Diagnostics;
using Microsoft.Win32;

namespace AccountabilityNotePad
{
    public partial class LoginForm : Form
    {
        Edit_Configuration ConfigWnd;
        private string configPath = Application.StartupPath + @"\AccountabilityNotePad.exe.config";
        private string foxConn = "";
        private string DataPath = Application.StartupPath + @"\Data.txt";
        string UsrNam = "";
        string Paswrd = "";
        //bool PreSavedUser;
        bool isMFGUser = true;
        DataSet dsMFGt; //Used to store MFG Tasks in datagrid
        DataSet dsLocalMFGt; //Used to store MFG Tasks localy to get 'Not saved changes'
        int ViewModeSelectedIndex = -1;
        int LoginID;
        private DateTime TodayDate;
        int SelectedTask;
        int currentEmpIndex;
        bool undoEmpChange = false;
        int SignInRepeater = 0;
        public DataSet AccSet;
        DataSet OriginalSet;
        int UserID;
        int LoggedUserID;
        string MyToken;
        private bool DataSaved = true;
        private bool LocalSaved = true;
        private bool MFGDataSaved = true;
        public LoginForm()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(342, 730);
        }
        //On Form Load (Application Starting)
        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Initialize KeyDown event for note text box
                txtNotes.TextPreviewKeyDownEvent += new EventHandler<PreviewKeyDownEventArgs>(txtNotes_TextPreviewKeyDownEvent);
                txtNotes.ToolStripItemClickedEvent += new EventHandler<ToolStripItemClickedEventArgs>(txtNotes_ToolStripItemClickedEvent);
                txtNotes.ValidatedEvent += new EventHandler<EventArgs>(txtNotes_ValidatedEvent);

                ConfigWnd = new Edit_Configuration();
                LoacteServerAndUpdateConfig();
                //DynamicUpdate.CloseUpdater();
                //CreateTempFolder();
                //DynamicUpdate.RemoveUpdateFile(Application.StartupPath, GetFileServer());
                //DynamicUpdate.RunUdpateService();
                TodayDate = GetServerTime();
                if (TodayDate != DateTime.MinValue)
                {
                    SetStartUpUserData();
                    //CheckUpdateMode();
                    //UpdateServiceTimer.Start();
                    //if (File.Exists(Environment.SystemDirectory.Substring(0, 1) + @":\Documents and Settings\" + Environment.UserName + @"\UserData.TXT"))
                    //{
                    //    try
                    //    {
                    //        LoadUserData();
                    //    }
                    //    catch (Exception Exp)
                    //    { string ErrMsg = Exp.Message; }
                    //}
                }
                else
                    return;
            }
            catch (Exception Ecp)
            {
                MessageBox.Show(Ecp.Message, "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CheckUpdateMode()
        {
            FileAccess.FileAccessService FAS = new AccountabilityNotePad.FileAccess.FileAccessService();
            FAS.Url = "http://" + GetFileServer() + "/FileAccessWS/FileAccessService.asmx";
            FAS.CheckUpdateMode();
            //string UsersFolderPath = Application.StartupPath + @"\Updates"; //Environment.SystemDirectory.Substring(0, 1) + @":\Documents and Settings\" + Environment.UserName + @"\CurrentUsers.txt";
            //if ((Directory.Exists(UsersFolderPath)) && (Directory.GetFiles(UsersFolderPath).Length > 0))
            //{
            //    DynamicUpdate.UpdateMultipleFiles("O",Application.StartupPath  , true);
            //}
        }
        private void CreateTempFolder()
        {
            FileAccess.FileAccessService FAS = new AccountabilityNotePad.FileAccess.FileAccessService();
            FAS.Url = "http://" + GetFileServer() + "/FileAccessWS/FileAccessService.asmx";
            FAS.CreateTempFolder(Environment.UserName);
            #region Commented Code
            //if (Directory.Exists(Application.StartupPath + @"\Temp"))
            //{
            //    if (!(File.Exists(Application.StartupPath + @"\Temp\" + Environment.UserName + ".txt")))
            //    {
            //        File.Create(Application.StartupPath + @"\Temp\" + Environment.UserName + ".txt");
            //    }
            //}
            //else
            //{
            //    Directory.CreateDirectory(Application.StartupPath + @"\Temp");
            //    File.Create(Application.StartupPath + @"\Temp\" + Environment.UserName + ".txt");
            //}
            #endregion
        }
        /// <summary>
        /// Get the user name and password from the registery and place them in the text boxes when loading the application form 
        /// </summary>
        private void SetStartUpUserData()
        {
            try
            {
                string EncData = Properties.Settings.Default.UNAP;
                #region Old Methods
                ////Get Data From Registry
                //UpdateManager UpdtMgr = new UpdateManager();
                //string EncData = UpdtMgr.GetStringValue(Microsoft.Win32.Registry.CurrentUser, @"SOFTWARE\TSN\Accountability Notepad\1", "UNPW");
                ////Get Data From file
                //string Key = Encoding.ASCII.GetString(File.ReadAllBytes(DataPath));
                //string EncryptedString = Cryptograph.DecryptFile(RememberMePath, Key);
                #endregion
                //string SKey = "0123456789";
                //TeaCrypto.XTea t = new TeaCrypto.XTea();
                string DecData = DecryptText(EncData);
                if (CheckDataCorrectness(DecData) == 1)
                    cbRemembrMe.Checked = true;
                else
                    cbRemembrMe.Checked = false;
            }
            catch (Exception Ecp)
            {
                string ErrMsg = Ecp.Message;
            }
        }
        bool Remove = false;
        string ServerName = "";
        string wsUrl = "";
        string wsUrlPart1 = "";
        string wsUrlPart2 = "";
        string wsUrlPart3 = "";
        /// <summary>
        /// Gets the server name where accountability is running and modify the .Config file with this sever
        /// </summary>
        private void LoacteServerAndUpdateConfig()
        {
            AccRoutingServer.AccRouting RoutService = new AccountabilityNotePad.AccRoutingServer.AccRouting();
            //AccRoutingServer.RoutingService RoutService = new AccountabilityNotePad.AccRoutingServer.RoutingService();
            ServerName = RoutService.GetAccServer();
            //wsUrl = "http://" + ServerName + "/Accountability_WS/";//Accountability_WS/ERPWebServices
            //wsUrlPart1 = "";//SharedPresentation/
            //wsUrlPart2 = "";//GUIPresentation/
            //wsUrlPart3 = "";//Security/

            wsUrl = "http://" + ServerName + Properties.Settings.Default.AccountabilityWebServiceURL;
            wsUrlPart1 = "";
            wsUrlPart2 = "";
            wsUrlPart3 = "";

            #region Commented Code - By Ehab (20071105)
            //string SavedServerName = "";
            //string FilePath = Application.StartupPath + @"\AccountabilityNotePad.exe.config";
            //XmlDocument AppFile = new XmlDocument();
            //AppFile.Load(FilePath);
            //XmlNode AccSetting = AppFile.ChildNodes[1].ChildNodes[1].ChildNodes[0];
            //for (int i = 0; i < AccSetting.ChildNodes.Count; i++)
            //{
            //    if (AccSetting.ChildNodes[i].Attributes["name"].Value.Trim() == "AccountabilityNotePad_ERPSessionServices_ERPSessionServices")
            //    {
            //        SavedServerName = AccSetting.ChildNodes[i].ChildNodes[0].InnerXml;
            //        break;
            //    }
            //}
            //if (ServerName.Trim().ToLower() != SavedServerName.Trim().ToLower())
            //{
            //    int Brk = 0;
            //    for (int i = 0; i < AccSetting.ChildNodes.Count; i++)
            //    {
            //        if (AccSetting.ChildNodes[i].Attributes["name"].Value.Trim() == "AccountabilityNotePad_GUI_GUI")
            //        {
            //            AccSetting.ChildNodes[i].ChildNodes[0].InnerXml = wsUrl + wsUrlPart1 + "GUI.asmx";
            //            Brk++;
            //        }
            //        else if (AccSetting.ChildNodes[i].Attributes["name"].Value.Trim() == "AccountabilityNotePad_EmployeesService_EmployeesService")
            //        {
            //            AccSetting.ChildNodes[i].ChildNodes[0].InnerXml = wsUrl + wsUrlPart1 + "EmployeesService.asmx";
            //            Brk++;
            //        }
            //        else if (AccSetting.ChildNodes[i].Attributes["name"].Value.Trim() == "AccountabilityNotePad_AccountabilityService_AccountabilityService")
            //        {
            //            AccSetting.ChildNodes[i].ChildNodes[0].InnerXml = wsUrl + wsUrlPart1 + "AccountabilityService.asmx";
            //            Brk++;
            //        }
            //        else if (AccSetting.ChildNodes[i].Attributes["name"].Value.Trim() == "AccountabilityNotePad_ERPSessionServices_ERPSessionServices")
            //        {
            //            AccSetting.ChildNodes[i].ChildNodes[0].InnerXml = wsUrl + wsUrlPart1 + "ERPSessionServices.asmx";
            //            Brk++;
            //        }
            //        //else if (AccSetting.ChildNodes[i].Attributes["name"].Value.Trim() == "ServerName")
            //        //{
            //        //    AccSetting.ChildNodes[i].ChildNodes[0].InnerXml = ServerName;
            //        //    Brk++;
            //        //}
            //        if (Brk == 4)
            //        {
            //            AppFile.Save(FilePath);
            //            break;
            //        }
            //    }
            //}
            #endregion
        }

        /// <summary>
        /// Get the date and time of the server machine
        /// </summary>
        /// <returns>DateTime ServerTime</returns>
        private DateTime GetServerTime()
        {
            try
            {
                ERPSessionServices.ERPSessionServices er = new AccountabilityNotePad.ERPSessionServices.ERPSessionServices();
                er.Url = wsUrl + wsUrlPart1 + "ERPSessionServices.asmx";
                //er.Url = "http://" + ServerName + "/ERPWebServices/SharedPresentation/ERPSessionServices.asmx";
                //"http://" + ServerName + "/Accountability_WS/ERPSessionServices.asmx";

                DateTime MyDate = er.GetServerDateTime();
                return MyDate;
            }
            catch (Exception Ecp)
            {
                MessageBox.Show(Ecp.Message, "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return DateTime.MinValue;
            }
        }
        private string EncryptText(string TextToEncrypt)
        {
            TeaCrypto.XTea t = new TeaCrypto.XTea();
            string SKey = "0123456789";
            string EncryptedText = t.EncryptString(TextToEncrypt, SKey);
            return EncryptedText;
        }
        private string DecryptText(string TextToDecrypt)
        {
            TeaCrypto.XTea t = new TeaCrypto.XTea();
            string SKey = "0123456789";
            string DecData = t.Decrypt(TextToDecrypt, SKey);
            return DecData;
        }
        ///////////////////////////////Login Form Functions//////////////////////////////////////////
        //Button Sign In Click
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            pnlConct.Visible = true;
            //if (!PreSavedUser)
            //{
            UsrNam = txtUsrName.Text;
            Paswrd = txtPasswrd.Text;
            if (UsrNam.Trim() == "" || Paswrd.Trim() == "")
            {
                MessageBox.Show("Please enter user name and password", "Signing In Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pnlConct.Visible = false;
                return;
            }

            if (cbRemembrMe.Checked == true)// && cbRemeberUsr.Checked == false)// cbRemembrMe.Text == "Remember User Name And Password")
            {
                try
                {
                    //TeaCrypto.XTea t = new TeaCrypto.XTea();
                    string Data = UsrNam + "||***|| " + Paswrd;
                    //string SKey = "0123456789";
                    string EncryptedText = EncryptText(Data);
                    Properties.Settings.Default.UNAP = EncryptedText;
                    Properties.Settings.Default.Save();
                    //UpdateManager UpdtMgr = new UpdateManager();
                    //UpdtMgr.SetStringValue(Microsoft.Win32.Registry.CurrentUser, @"SOFTWARE\TSN\Accountability Notepad\1", "UNPW", EncryptedText);
                }
                catch (Exception Ecp)
                {
                    string ErrMsg = Ecp.Message;
                }

            }
            else if (cbRemembrMe.Checked == false)
            {
                try
                {
                    Properties.Settings.Default.UNAP = "";
                    Properties.Settings.Default.Save();
                    UpdateManager UpdtMgr = new UpdateManager();
                    UpdtMgr.SetStringValue(Microsoft.Win32.Registry.CurrentUser, @"SOFTWARE\TSN\Accountability Notepad\1", "UNPW", "");
                }
                catch (Exception Ecp)
                {
                    string ErrMsg = Ecp.Message;
                }
                Remove = true;
            }
            //}
            MyToken = ValidateUser(UsrNam, Paswrd, false);
            if (MyToken != null && MyToken != "")
            {
                pnlConct.Visible = false;
                pnlLogin.Visible = false;
                pnlLogin.Enabled = false;
                pnlMainFrm.Visible = true;
                pnlMainFrm.Enabled = true;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.MaximizeBox = true;
                lblDate.Text = TodayDate.ToLongDateString();
                try
                {
                    ThreadStart UpdtThrdStrt = new ThreadStart(CheckForUpdate);
                    Thread UpdateThread = new Thread(UpdtThrdStrt);
                    UpdateThread.Start();
                }
                catch (Exception Ecp)
                {
                    string ErrMsg = Ecp.Message;
                }
                SignInRepeater = 0;
                cmbViewMode.SelectedIndex = 0;
                //Insert New Record In database to register user logging
                SecurityManagement.AuthHeader SecHeader = new AccountabilityNotePad.SecurityManagement.AuthHeader();
                SecHeader.Token = MyToken;
                SecurityManagement.SecurityManagement SecMngmnt = new AccountabilityNotePad.SecurityManagement.SecurityManagement();
                SecMngmnt.Url = wsUrl + wsUrlPart3 + "SecurityManagement.asmx";
                SecMngmnt.AuthHeaderValue = SecHeader;
                LoginID = SecMngmnt.RecordUserLogInTime(UsrNam, GetServerTime(), "AccountabilityNotePad", false);

                // Start another application and wait for exit.
                LuanchApplication();

                MFGAccWS.AuthHeader MFGHead = new AccountabilityNotePad.MFGAccWS.AuthHeader();
                MFGHead.Token = MyToken;
                MFGAccWS.MFGAccountability MFGAcc = new AccountabilityNotePad.MFGAccWS.MFGAccountability();
                MFGAcc.AuthHeaderValue = MFGHead;
                MFGAcc.Url = wsUrl + wsUrlPart1 + "MFGAccountability.asmx";

                DataSet dsMFGEmps = MFGAcc.GetAllMFGEmployees();

                if (dsMFGEmps.Tables[0].Rows.Count == 0)
                    isMFGUser = false;
                else
                {
                    isMFGUser = true;
                    
                    try
                    {
                        AccRoutingServer.AccRouting RoutService = new AccountabilityNotePad.AccRoutingServer.AccRouting();
                        //foxConn = RoutService.GetFoxProConnection();
                        //foxConn = "Driver={Microsoft Visual FoxPro Driver};sourcedb=D:\\MFG\\A001_DB\\A001.dbc;sourcetype=DBC;exclusive=No;backgroundfetch=No;collate=Machine;null=No;deleted=No;uid=;pwd=";
                        //OleDbConnection MyCon = new OleDbConnection(foxConn);
                        //MyCon.Open();
                        //new OleDbDataAdapter(new OleDbCommand("SELECT wo_no FROM a_92 WHERE (wo_no = 1)", MyCon)).Fill(new DataSet());
                        //MyCon.Close();
                        FoxProService.FoxProSrv foxSrv = new AccountabilityNotePad.FoxProService.FoxProSrv();
                        int isRightConnection=foxSrv.CheckConnection();
                        if (isRightConnection == 0)
                        {
                            MessageBox.Show("You can't connect to FoxPro Database.\nPlease contact your administrator to correct the connection string.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            isMFGUser = false;
                        }

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("You can't connect to FoxPro Database.\nPlease contact your administrator to correct the connection string.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isMFGUser = false;
                    }
                }

                if (isMFGUser)
                {
                    initMFGMode(); //Will be called in case of MFG-user has signed-in
                    if (Properties.Settings.Default.MFGMode)
                        showMFGPanel(); //Will be called if the default in setting is MFG mode
                    else
                        hideMFGPanel();
                }

                //Get Employee Sheet and add it in the grid
                GetEmployeeSheet(MyToken, false, true);
                //PreSavedUser = false;
            }
            else if (MyToken == null)
            {
                SignInRepeater++;
                DialogResult Dlg = DialogResult.None;
                if (SignInRepeater > 2)
                    Dlg = MessageBox.Show("User name or password is incorrect or server is busy", "Login Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                if (Dlg == DialogResult.Retry || SignInRepeater <= 2)
                    btnSignIn_Click(null, null);
                else
                    pnlConct.Visible = false;
            }
        }
        /// <summary>
        /// Start another application that has a path in registry and wait for exit.
        /// If registry key is null, it does nothing.
        /// </summary>
        private void LuanchApplication()
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\UMEEngine\Path", true);
                string path = key.GetValue("").ToString() + @"\Gizmos\EAT.Gizmo";
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(path);
                p.Start();
                key.Close();
            }
            catch (Exception ex) { }

            //try
            //{

            //    // Get registry key path
            //    string KeyName = Properties.Settings.Default.StartUpApplication_RegKeyName;
            //    string ValueName = Properties.Settings.Default.StartUpApplication_RegValueName;
            //    // Check key existance
            //    string RegKeyStr = new UpdateManager().GetStringValue(Microsoft.Win32.Registry.LocalMachine, KeyName.Remove(0, 19), ValueName);

            //    if (!string.IsNullOrEmpty(RegKeyStr))
            //    {
            //        // Check file existance
            //        if (System.IO.File.Exists(RegKeyStr))
            //        {
            //            // Hide ANP
            //            this.Hide();
            //            // Run the file.
            //            Process proc = Process.Start(RegKeyStr);
            //            //// Wait for execution end
            //            //proc.WaitForExit();
            //            // Show ANP
            //            this.Show();
            //        }
            //    }
            //}
            //catch
            //{
            //}
        }

        /// <summary>
        /// Generate a valid key to encrypt data
        /// </summary>
        /// <returns>string Key</returns>
        //private string GenerateValidKey()
        //{
        //    string SK = "";
        //    SK = "????????";
        //    File.WriteAllBytes(DataPath, Encoding.ASCII.GetBytes(SK));
        //    return SK;
        //}
        /// <summary>
        /// Check if the user has an account to allow user to login or not
        /// </summary>
        /// <param name="UserName">string Username</param>
        /// <param name="Password">string Password</param>
        /// <param name="ShowMessage">bool ShowMessage</param>
        /// <returns>string Valid</returns>
        private string ValidateUser(string UserName, string Password, bool ShowMessage)
        {
            string Token = "";
            try
            {
                GUI.GUI LgnWbSrvs = new AccountabilityNotePad.GUI.GUI();
                LgnWbSrvs.Url = wsUrl + wsUrlPart2 + "GUI.asmx";
                Token = LgnWbSrvs.Login(UserName, Password);
            }
            catch
            {
                MessageBox.Show("Error connecting to web service server", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Token;
        }
        /// <summary>
        /// Get the user name and password from the decrypted(decoded)data and place them in the TextBoxes in the login form
        /// </summary>
        /// <param name="EncryptedData">string EncryptedData</param>
        /// <returns>int Type</returns>
        private int CheckDataCorrectness(string EncryptedData)
        {
            int Type = 0;  //Type = 1 Remember User name and password 
            //Type = 2 Remember User Only
            //Type = 0 Error
            int i = 0;
            try
            {
                while (i < EncryptedData.Length - 7)
                {
                    if (EncryptedData.Substring(i, 8) == "||***|| ")
                    {
                        txtUsrName.Text = EncryptedData.Substring(0, i);
                        if (EncryptedData.Length == i + 8)
                        {
                            Type = 2;
                            txtPasswrd.Text = "";
                            break;
                        }
                        else
                        {
                            txtPasswrd.Text = EncryptedData.Substring(i + 8, EncryptedData.Length - (i + 8));
                            Type = 1;
                            break;
                        }
                    }
                    else
                        i++;
                }
            }
            catch (Exception Ecp)
            {
                string ErrMsg = Ecp.Message;
                MessageBox.Show("Error Reading User Files", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Type = 0;
            }
            return Type;
        }
        /// <summary>
        /// Get the Employee Name using the Employee ID
        /// </summary>
        /// <param name="EmployeeID">int EmployeeID</param>
        /// <returns>string EmployeeName</returns>
        private string GetEmployeeName(int EmployeeID)
        {
            string EmployeeName = "";
            try
            {
                EmployeesService.AuthHeader Hdr = new AccountabilityNotePad.EmployeesService.AuthHeader();
                Hdr.Token = MyToken;
                EmployeesService.EmployeesService EmpSrv = new AccountabilityNotePad.EmployeesService.EmployeesService();
                EmpSrv.Url = wsUrl + wsUrlPart1 + "EmployeesService.asmx";
                EmpSrv.AuthHeaderValue = Hdr;
                DataSet EmpSet = EmpSrv.ListSingleEmployeeData(EmployeeID);
                EmployeeName = EmpSet.Tables[0].Rows[0].ItemArray[12].ToString().Trim();
            }
            catch
            {
                MessageBox.Show("Couldn't connect to server at this moment");
            }
            return EmployeeName;
        }
        /// <summary>
        /// Prevent the user from singing in if the user has no corresponding employee account
        /// </summary>
        private void PreventSignIn()
        {
            hideMFGPanel();
            exitMFGMode();
            pnlMainFrm.Visible = false;
            pnlMainFrm.Enabled = false;
            pnlLogin.Visible = true;
            pnlLogin.Enabled = true;
            MessageBox.Show("Login user does not have an employee account in the system", "Log In Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        ////Check boxes Remember User and Password 
        //private void cbRemeberUsr_CheckedChanged_1(object sender, EventArgs e)
        //{
        //    if (cbRemeberUsr.Checked)
        //        cbRemembrMe.Checked = false;
        //}
        //private void cbRemembrMe_CheckedChanged_1(object sender, EventArgs e)
        //{
        //    if (cbRemembrMe.Checked)
        //        cbRemeberUsr.Checked = false;
        //}
        //To Disable Error during formatting grid when casting textbox to checkbox
        private void tgvTasks_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        //When Panel visibilty changes
        private void pnlMainFrm_VisibleChanged(object sender, EventArgs e)
        {
            ViewModeSelectedIndex = -1;
            Button ABtn = this.btnSignIn;
            //Button BBtn = this.btnUpdate;
            if (pnlMainFrm.Visible)
                this.AcceptButton = null;
            else
                this.AcceptButton = ABtn;
        }
        ////////////////////////////////////Menu Items Functions//////////////////////////////////////////////
        //SignOut Menu Item
        private void msiSignout_Click(object sender, EventArgs e)
        {
            SignMeOut();
        }
        /// <summary>
        /// Allow the user to sign out from the user's account 
        /// </summary>
        private void SignMeOut()
        {
            string MsgTxt = "";

            if (isMFGUser && cmbEmpName.SelectedIndex != -1)
            {
                checkMFGDataSaved();
            }

            if (DataSaved && MFGDataSaved)
                MsgTxt = "Are you sure you want to sign out?";
            else
                MsgTxt = "Are you sure you want to sign out? Unsaved data will be lost.";
            DialogResult Dlg = MessageBox.Show(MsgTxt, "Signing Out", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (Dlg == DialogResult.Yes)
            {
                if (isMFGUser)
                {
                    hideMFGPanel();
                    exitMFGMode();
                }

                if (pnlMainFrm.Visible)
                {
                    this.WindowState = FormWindowState.Normal;
                    pnlLogin.Visible = true;
                    pnlLogin.Enabled = true;
                    pnlMainFrm.Visible = false;
                    pnlMainFrm.Enabled = false;
                    this.Width = 340;
                    this.Height = 730;
                    this.FormBorderStyle = FormBorderStyle.FixedDialog;
                    this.MaximizeBox = false;
                }
                //Add LogOut Time
                DateTime LogOutTime = GetServerTime();
                AddLogoutrecord(LogOutTime);
                //Log Off Session
                ThreadStart CTS = new ThreadStart(CloseSession);
                Thread CloseThread = new Thread(CTS);
                CloseThread.Start();

                SetStartUpUserData();
                FreeResources(false);
                ExpandedNodes.Clear();
                tgvTasks.Dispose();
            }
        }
        //Exit Menu Item
        private void miExit_Click(object sender, EventArgs e)
        {
            CloseWithAlert("UserClosing");
        }
        /// <summary>
        /// Allow the user to close the application
        /// </summary>
        public void CloseWithAlert(string CloseingReason)
        {
            FormClosingEventArgs Cls = new FormClosingEventArgs(CloseReason.UserClosing, false);
            this.LoginForm_FormClosing(null, Cls);
            //DialogResult ExitDlg = MessageBox.Show("Are you sure you want to exit the application", "Exit Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            //if (ExitDlg == DialogResult.Yes)
            //    this.LoginForm_FormClosing(null, Cls);
        }
        //Menu Item Open Accountability
        private void miOpenAcc_Click(object sender, EventArgs e)
        {
            try
            {
                //AccRoutingServer.RoutingService RoutService = new AccountabilityNotePad.AccRoutingServer.RoutingService();
                //ServerName = RoutService.GetAccServer();
                //string FPath = Application.StartupPath + @"\AccountabilityNotePad.exe.config";
                //string[] Lines = File.ReadAllLines(FPath);
                //string StrVal = Lines[28].Trim();
                //StrVal = StrVal.Remove(0, StrVal.IndexOf("<value>"));
                //StrVal = StrVal.Remove(StrVal.IndexOf("</value>") + 8, StrVal.Length - (StrVal.IndexOf("</value>") + 8));
                //StrVal = StrVal.Replace("<value>", "");
                //StrVal = StrVal.Replace("</value>", "");
                //ServerName = StrVal.Trim();
            }
            catch (Exception Ecp)
            {
                string ErrMsg = Ecp.Message;
                //ServerName = Properties.Settings.Default.ServerName;
            }
            bool Failure = true;
            int i = 0;
            while (Failure)
            {
                MyToken = ValidateUser(UsrNam, Paswrd, false);
                if (MyToken == null || MyToken == "")
                {
                    Failure = true;
                    i++;
                }
                else
                {
                    Failure = false;
                }
                if (i == 2)
                    break;
            }
            string URL = "http://" + ServerName + "/Accountability_GUI/Index.aspx?Token=" + MyToken;
            System.Diagnostics.Process.Start(URL);
        }
        //Enable and Disable Menu Items
        private void fileToolStripMenuItem1_DropDownOpened(object sender, EventArgs e)
        {
            if (pnlLogin.Visible)
            {
                msiSignout.Enabled = false;
                miOpenAcc.Enabled = false;
                miUpdateAcc.Enabled = false;
            }
            else
            {
                msiSignout.Enabled = true;
                miOpenAcc.Enabled = true;
                miUpdateAcc.Enabled = true;
            }
        }
        //Menu Settings - Item Change Server Name
        private void miChangSrvrName_Click(object sender, EventArgs e)
        {
            Edit_Configuration EC = new Edit_Configuration();
            EC.ShowDialog();
        }
        //Help Button
        private void btnHelp_Click(object sender, EventArgs e)
        {
            Help Hlp = new Help();
            Hlp.ShowDialog();
        }
        //Menu Item Settings
        private void miSettings_Click(object sender, EventArgs e)
        {
            ConfigWnd.ShowDialog();
        }
        //Menu Item About
        private void miAbout_Click_1(object sender, EventArgs e)
        {
            About mAbt = new About();
            mAbt.ShowDialog();
        }
        //Menu Item Refresh
        private void miRefresh_Click(object sender, EventArgs e)
        {
            RefershGrid();
        }
        ////Check For Updates
        //private void miChkForUpdt_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        UpdateManager UMngr = new UpdateManager();
        //        int ReturnValue = UMngr.DownLoadLatestVerion();
        //        if (ReturnValue == 1)
        //            MessageBox.Show("You have the latest version", "Check For Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        else if (ReturnValue == 0)
        //            MessageBox.Show("No Update Server Exists, Or Connection Error occured!!", "Check For Update Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        else if (ReturnValue == -1)
        //            MessageBox.Show("You are not authorized to run upgrade process.", "Check For Update Error!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //    catch (Exception Ecp)
        //    {
        //        string ErrMsg = Ecp.Message;
        //    }
        //}
        //Add Notification
        NotifyIcon Notify = new NotifyIcon();
        /// <summary>
        /// Allow the user to minimize the application to the notification area 
        /// </summary>
        private void AddNotification()
        {
            Notify.ContextMenuStrip = cmNotify;
            Notify.Icon = MyNotifyIconResourceFile.NotifyIcons;
            Notify.Visible = true;
            Notify.Text = "Minimized Accountability Notepad";
            this.Hide();
            Notify.ShowBalloonTip(1000, "Accountability Notepad", "Double Click To Restore", ToolTipIcon.Info);
            Notify.DoubleClick += new EventHandler(Notify_DoubleClick);

        }
        private void RestoreForm()
        {
            Notify.Visible = false;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            if (pnlLogin.Visible)
            {
                Point HelpPnt = new Point(pnlLogin.Width - 25, 0);
                btnHelp.Location = HelpPnt;
            }
            else
            {
                if (pnlMFG.Visible)
                {
                    Point HelpPnt = new Point(pnlMFG.Width - 25, 0);
                    btnHelp.Location = HelpPnt;
                }
            }
            ViewModeSelectedIndex = cmbViewMode.SelectedIndex;
        }
        //When Double Click On Notification
        void Notify_DoubleClick(object sender, EventArgs e)
        {
            RestoreForm();
            //Notify.Visible = false;
            //this.Show();
            //this.WindowState = FormWindowState.Normal;
            //if (pnlLogin.Visible)
            //{
            //    Point HelpPnt = new Point(pnlLogin.Width - 25, 0);
            //    btnHelp.Location = HelpPnt;
            //}
        }
        //Minimize To Notification Area Menu Item
        private void miMinimizeToNotificationArea_Click(object sender, EventArgs e)
        {
            AddNotification();
        }
        private void miShow_Click(object sender, EventArgs e)
        {
            RestoreForm();
            //Notify.Visible = false;
            //this.Show();
            //this.WindowState = FormWindowState.Normal;
            //if (pnlLogin.Visible)
            //{
            //    Point HelpPnt = new Point(pnlLogin.Width - 25, 0);
            //    btnHelp.Location = HelpPnt;
            //}
        }
        private void LoginForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                //string FPath = Application.StartupPath + @"\AccountabilityNotePad.exe.config";
                //string [] Lines = File.ReadAllLines(FPath);
                //string StrVal = Lines[38].Trim();
                //StrVal = StrVal.Remove(0, StrVal.IndexOf("<value>"));
                //StrVal = StrVal.Remove(StrVal.IndexOf("</value>") + 8, StrVal.Length - (StrVal.IndexOf("</value>") + 8));
                //StrVal = StrVal.Replace("<value>", "");
                //StrVal = StrVal.Replace("</value>", "");               
                //if(StrVal.Trim().ToLower() == "true")
                if (Properties.Settings.Default.HideApp == true)
                    AddNotification();
            }
            else
            {
                if (!pnlMFG.Visible)
                {
                    if (this.Width <= 342 || this.Height <= 730)
                    {
                        if (this.Width <= 342)
                        {
                            this.Width = 342;
                        }
                        if (this.Height <= 730)
                        {
                            this.Height = 730;
                        }
                        return;
                    }
                }
                else
                {
                    if (this.Width <= 782 || this.Height <= 520)
                    {
                        if (this.Width <= 782)
                        {
                            this.Width = 782;
                        }
                        if (this.Height <= 520)
                        {
                            this.Height = 520;
                        }
                        return;
                    }
                }
            }
        }
        //Menu View Click
        private void viewToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            if (pnlLogin.Visible == true)
            {
                miRefresh.Enabled = false;
            }
            else if (pnlMainFrm.Visible == true)
            {
                miRefresh.Enabled = true;
            }
        }
        //Settings Menu Click
        private void msSettings_DropDownOpened(object sender, EventArgs e)
        {
            if (pnlLogin.Visible == true)
            {
                miChkForUpdt.Enabled = false;
            }
            else if (pnlMainFrm.Visible == true)
            {
                miChkForUpdt.Enabled = true;
            }
        }
        private void viewToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            if (pnlLogin.Visible == true)
                miRefresh.Enabled = false;
            else if (pnlMainFrm.Visible == true)
                miRefresh.Enabled = true;
        }
        //Menu Item Update Accountbility
        private void miUpdateAcc_Click(object sender, EventArgs e)
        {
            tgvTasks.EditMode = DataGridViewEditMode.EditProgrammatically;
            tgvTasks.EndEdit();
            tgvTasks.EditMode = DataGridViewEditMode.EditOnEnter;
            btnUpdate_Click(null, null);
        }
        ////////////////////////////////////Main Form Panel Functions/////////////////////////////////////////
        /////////////Adding Responsibilities, Projects and Tasks to Grid
        int SheetRepeater = 0;
        /// <summary>
        /// Load the main form panel with all menus,projects,tasks and responsibilties assigned to the login user
        /// </summary>
        /// <param name="Token">string Valid</param>
        /// <param name="ReloadInternal">bool ReloadInternal</param>
        /// <param name="FirstTime">bool FirstTime</param>
        private void GetEmployeeSheet(string Token, bool ReloadInternal, bool FirstTime)
        {
            if (Remove)
            {
                txtPasswrd.Text = "";
                txtUsrName.Text = "";
            }
            try
            {
                int ViewMode = 10;
                if (cmbViewMode.SelectedIndex == 0)
                    ViewMode = 10;
                else if (cmbViewMode.SelectedIndex == 1)
                    ViewMode = 30;
                else if (cmbViewMode.SelectedIndex == 2)
                    ViewMode = 10;
                if (!ReloadInternal)
                {
                    if (!FirstTime)
                        Token = ValidateUser(UsrNam, Paswrd, true);

                    ERPSessionServices.AuthHeader EHead = new AccountabilityNotePad.ERPSessionServices.AuthHeader();
                    EHead.Token = Token;
                    ERPSessionServices.ERPSessionServices UserIDServc = new AccountabilityNotePad.ERPSessionServices.ERPSessionServices();
                    UserIDServc.Url = wsUrl + wsUrlPart1 + "ERPSessionServices.asmx";
                    UserIDServc.AuthHeaderValue = EHead;

                    UserID = UserIDServc.GetUserContactID();
                    LoggedUserID = UserIDServc.GetLoggedUserID();
                    if (UserID == 0)
                    {
                        PreventSignIn();
                        return;
                    }
                    lblWlcm.Text = "Welcome " + GetEmployeeName(UserID);
                    Point WlcmPnt = new Point((int)((this.Width - lblWlcm.Width) / 2) - 5, lblWlcm.Location.Y);
                    lblWlcm.Location = WlcmPnt;

                    AccountabilityService.AccountabilityService AccSheet = new AccountabilityNotePad.AccountabilityService.AccountabilityService();
                    AccSheet.Url = wsUrl + wsUrlPart1 + "AccountabilityService.asmx";
                    AccountabilityService.AuthHeader SHeader = new AccountabilityNotePad.AccountabilityService.AuthHeader();
                    SHeader.Token = Token;
                    AccSheet.AuthHeaderValue = SHeader;
                    SelectedTask = 0;
                    AccSet = new DataSet();
                    IFormatProvider Culture = new System.Globalization.CultureInfo("en-US", false);
                    AccSet = AccSheet.GetAccSheet(UserID, DateTime.Parse(TodayDate.ToShortDateString(), Culture), ViewMode, false);
                    if (cmbViewMode.SelectedIndex == 2)
                    {
                        FilterDataSet(ref AccSet);
                    }
                    if (OriginalSet != null)
                        OriginalSet.Clear();
                    OriginalSet = AccSet.Copy();
                }
                tgvTasks.Nodes.Clear();
                int Inedx = 0;
                //Show today's data and hide other days
                if (TodayDate.DayOfWeek.ToString().ToLower() == "sunday")
                    Inedx = 3;
                else if (TodayDate.DayOfWeek.ToString().ToLower() == "monday")
                    Inedx = 4;
                else if (TodayDate.DayOfWeek.ToString().ToLower() == "tuesday")
                    Inedx = 5;
                else if (TodayDate.DayOfWeek.ToString().ToLower() == "wednesday")
                    Inedx = 6;
                else if (TodayDate.DayOfWeek.ToString().ToLower() == "thursday")
                    Inedx = 7;
                else if (TodayDate.DayOfWeek.ToString().ToLower() == "friday")
                    Inedx = 8;
                else if (TodayDate.DayOfWeek.ToString().ToLower() == "saturday")
                    Inedx = 9;
                tgvTasks.Columns[Inedx].Visible = true;
                //if (File.Exists(GetClientPath()))
                //{
                //    LoadSavedDataSet();
                //    File.Delete(GetClientPath());
                //}
                LoadGrid(ViewMode);
                AdjustGridColumns(Inedx);
                LoginForm_SizeChanged(null, null);
                UpdateColumnHeaderText(Inedx);
                SetNote(AccSet);
                SheetRepeater = 0;
            }
            catch (Exception Ecp)
            {
                SheetRepeater++;
                DialogResult DLG = DialogResult.None;
                if (SheetRepeater > 2)
                    DLG = MessageBox.Show("Couldn't Connect To Server To Load Data , It May Be Busy Now" + "\r\n" + Ecp.Message, "Connection Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                if (DLG == DialogResult.Retry || SheetRepeater <= 2)
                    GetEmployeeSheet(Token, ReloadInternal, FirstTime);
                else
                    MessageBox.Show(Ecp.Message);
            }
        }

        /// <summary>
        /// Filter the sheetset to include the tasks only instead of including projects,responsibilties and tasks 
        /// </summary>
        /// <param name="SheetSet">ref DataSet SheetSet</param>
        private void FilterDataSet(ref DataSet SheetSet)
        {
            DataRow RemoveRow;
            for (int i = 0; i < SheetSet.Tables[0].Rows.Count; i++)
            {
                if (SheetSet.Tables[0].Rows[i].ItemArray[12].ToString().Trim() != "10")
                {
                    RemoveRow = SheetSet.Tables[0].Rows[i];
                    SheetSet.Tables[0].Rows.Remove(RemoveRow);
                    SheetSet.AcceptChanges();
                    i--;
                }
            }
            //SortTable(ref SheetSet);
        }
        /// <summary>
        /// Check if there are new updates on the server,and download these updates
        /// </summary>
        private void CheckForUpdate()
        {
            try
            {
                UpdateManager UMngr = new UpdateManager();
                UMngr.DownLoadLatestVerion();
            }
            catch (Exception Ecp)
            {
                string ErrMsg = Ecp.Message;
            }
        }
        /// <summary>
        /// Load the data grid with projects,tasks,responsibilties according to the selected view mode
        /// </summary>
        /// <param name="ViewMode">int ViewMode</param>
        private void LoadGrid(int ViewMode)
        {
            TreeGridNode RNode = new TreeGridNode();
            TreeGridNode PNode = new TreeGridNode();
            int ColumnIndex = GetSelectedDayIndex();
            for (int a = 0; a < AccSet.Tables[0].Rows.Count; a++)
            {
                if (AccSet.Tables[0].Rows[a].ItemArray[12].ToString() == "20" && cmbViewMode.SelectedIndex == 0)
                {
                    RNode = AddResponsibilty(ColumnIndex, a);
                }
                else if (AccSet.Tables[0].Rows[a].ItemArray[12].ToString() == "30" && cmbViewMode.SelectedIndex != 2)
                {
                    if (cmbViewMode.SelectedIndex == 1)
                        PNode = AddProject(null, ColumnIndex, a);
                    else
                        PNode = AddProject(RNode, ColumnIndex, a);
                }
                else if ((AccSet.Tables[0].Rows[a].ItemArray[12].ToString() == "10" && RNode.Cells != null) || cmbViewMode.SelectedIndex == 1 || cmbViewMode.SelectedIndex == 2)
                {
                    if (cmbViewMode.SelectedIndex == 2)
                    {
                        AddTask(null, a, ColumnIndex);
                    }
                    else
                    {
                        if (AccSet.Tables[0].Rows[a].ItemArray[14].ToString() != "" || cmbViewMode.SelectedIndex == 1)
                            AddTask(PNode, a, ColumnIndex);
                        else
                            AddTask(RNode, a, ColumnIndex);
                    }
                }
            }
        }
        /// <summary>
        /// Allow the user to add new responsiblities to the user's account
        /// </summary>
        /// <param name="Index">int ResponsbilityIndex</param>
        /// <param name="i">int RowNumber</param>
        /// <returns>TreeGridNode NewResponsibilty</returns>
        private TreeGridNode AddResponsibilty(int Index, int i)
        {
            //Add Resp. to grid
            TreeGridNode RNode = tgvTasks.Nodes.Add(AccSet.Tables[0].Rows[i].ItemArray[1].ToString(), AccSet.Tables[0].Rows[i].ItemArray[11].ToString(), AccSet.Tables[0].Rows[i].ItemArray[2].ToString(),
                                                AccSet.Tables[0].Rows[i].ItemArray[3].ToString(), AccSet.Tables[0].Rows[i].ItemArray[4].ToString(),
                                                AccSet.Tables[0].Rows[i].ItemArray[5].ToString(), AccSet.Tables[0].Rows[i].ItemArray[6].ToString(),
                                                AccSet.Tables[0].Rows[i].ItemArray[7].ToString(), AccSet.Tables[0].Rows[i].ItemArray[8].ToString());
            if (RNode.Cells[Index].Value.ToString().Trim() == "0")
                RNode.Cells[Index].Value = "";
            RNode.Cells[10].ReadOnly = true;
            RNode.Cells[10] = new DataGridViewTextBoxCell();
            //Change Resp. color
            RNode.DefaultCellStyle.BackColor = Color.FromArgb(51, 204, 204);
            RNode.Cells[Index].ReadOnly = true;
            return RNode;
        }
        /// <summary>
        /// Allow the user to add new project to the user's account
        /// </summary>
        /// <param name="RNode">TreeGridNode Node</param>
        /// <param name="ColumnIndex">int ColumnIndex</param>
        /// <param name="i">int RowIndex</param>
        /// <returns>TreeGridNode NewProject</returns>
        private TreeGridNode AddProject(TreeGridNode RNode, int ColumnIndex, int i)
        {
            TreeGridNode PNode = new TreeGridNode();
            if (RNode != null)
            {
                PNode = RNode.Nodes.Add(AccSet.Tables[0].Rows[i].ItemArray[1].ToString(), AccSet.Tables[0].Rows[i].ItemArray[11].ToString(), AccSet.Tables[0].Rows[i].ItemArray[2].ToString(),
                                                AccSet.Tables[0].Rows[i].ItemArray[3].ToString(), AccSet.Tables[0].Rows[i].ItemArray[4].ToString(),
                                                AccSet.Tables[0].Rows[i].ItemArray[5].ToString(), AccSet.Tables[0].Rows[i].ItemArray[6].ToString(),
                                                AccSet.Tables[0].Rows[i].ItemArray[7].ToString(), AccSet.Tables[0].Rows[i].ItemArray[8].ToString());
            }
            else
            {
                PNode = tgvTasks.Nodes.Add(AccSet.Tables[0].Rows[i].ItemArray[1].ToString(), AccSet.Tables[0].Rows[i].ItemArray[11].ToString(), AccSet.Tables[0].Rows[i].ItemArray[2].ToString(),
                                            AccSet.Tables[0].Rows[i].ItemArray[3].ToString(), AccSet.Tables[0].Rows[i].ItemArray[4].ToString(),
                                            AccSet.Tables[0].Rows[i].ItemArray[5].ToString(), AccSet.Tables[0].Rows[i].ItemArray[6].ToString(),
                                            AccSet.Tables[0].Rows[i].ItemArray[7].ToString(), AccSet.Tables[0].Rows[i].ItemArray[8].ToString());
            }
            if (PNode.Cells[ColumnIndex].Value.ToString().Trim() == "0")
                PNode.Cells[ColumnIndex].Value = "";
            PNode.DefaultCellStyle.BackColor = Color.FromArgb(0, 255, 0);
            PNode.Cells[ColumnIndex].ReadOnly = true;
            PNode.Cells[10] = new DataGridViewTextBoxCell();
            // SetProjectsTasks(PNode, AccSet, AccSet.Tables[0].Rows[i].ItemArray[11].ToString(), ColumnIndex);
            PNode.Cells[10].ReadOnly = true;
            return PNode;
        }
        /// <summary>
        /// Allow the user to add new task to the user's account
        /// </summary>
        /// <param name="PNode">TreeGridNode ProjectNode</param>
        /// <param name="index">int RowIndex</param>
        /// <param name="ColumnIndex">int ColumnIndex</param>
        private void AddTask(TreeGridNode PNode, int index, int ColumnIndex)
        {
            int i = index;
            TreeGridNode ANode;
            if (cmbViewMode.SelectedIndex == 2)
            {
                ANode = tgvTasks.Nodes.Add(AccSet.Tables[0].Rows[i].ItemArray[1].ToString(), AccSet.Tables[0].Rows[i].ItemArray[11].ToString(), AccSet.Tables[0].Rows[i].ItemArray[2].ToString(),
                                                AccSet.Tables[0].Rows[i].ItemArray[3].ToString(), AccSet.Tables[0].Rows[i].ItemArray[4].ToString(),
                                                AccSet.Tables[0].Rows[i].ItemArray[5].ToString(), AccSet.Tables[0].Rows[i].ItemArray[6].ToString(),
                                                AccSet.Tables[0].Rows[i].ItemArray[7].ToString(), AccSet.Tables[0].Rows[i].ItemArray[8].ToString());
            }
            else
            {
                ANode = PNode.Nodes.Add(AccSet.Tables[0].Rows[i].ItemArray[1].ToString(), AccSet.Tables[0].Rows[i].ItemArray[11].ToString(), AccSet.Tables[0].Rows[i].ItemArray[2].ToString(),
                                                AccSet.Tables[0].Rows[i].ItemArray[3].ToString(), AccSet.Tables[0].Rows[i].ItemArray[4].ToString(),
                                                AccSet.Tables[0].Rows[i].ItemArray[5].ToString(), AccSet.Tables[0].Rows[i].ItemArray[6].ToString(),
                                                AccSet.Tables[0].Rows[i].ItemArray[7].ToString(), AccSet.Tables[0].Rows[i].ItemArray[8].ToString());
            }
            if (ANode.Cells[ColumnIndex].Value.ToString().Trim() == "0")
                ANode.Cells[ColumnIndex].Value = "";
            //Yellow
            if (AccSet.Tables[0].Rows[i].ItemArray[2].ToString() == "20")
            {
                ANode.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 0);
                ANode.Cells[2].Value = "#";
                ANode.Cells[10].ReadOnly = true;
                ANode.Cells[ColumnIndex].ReadOnly = false;
                ANode.Cells[10] = new DataGridViewTextBoxCell();
            }
            else if (AccSet.Tables[0].Rows[i].ItemArray[2].ToString() == "30")
            {
                ANode.DefaultCellStyle.ForeColor = Color.Red;
                ANode.Cells[2].Value = "";
                ANode.Cells[10].ReadOnly = true;
                ANode.Cells[ColumnIndex].ReadOnly = false;
                ANode.Cells[10] = new DataGridViewTextBoxCell();
            }
            else if (AccSet.Tables[0].Rows[i].ItemArray[2].ToString() == "40")
            {
                ANode.DefaultCellStyle.ForeColor = Color.FromArgb(243, 122, 30);
                ANode.Cells[2].Value = "Hrs.";
                ANode.Cells[10].ReadOnly = true;
                ANode.Cells[ColumnIndex].ReadOnly = false;
            }
            else
            {
                ANode.Cells[2].Value = "Hrs.";
                ANode.Cells[ColumnIndex].ReadOnly = false;
            }
            //violet
            if (AccSet.Tables[0].Rows[i].ItemArray[16].ToString() == "3")
            {

                ANode.DefaultCellStyle.BackColor = Color.FromArgb(175, 122, 165);
                ANode.Cells[10].ReadOnly = true;
                ANode.Cells[ColumnIndex].ReadOnly = true;
                ANode.Cells[10] = new DataGridViewTextBoxCell();
            }
        }
        #region Timer Settings

        //Timer Varaibles
        int Seconds = 0;
        int Minutes = 0;
        int Hours = 0;
        //Timer Counting
        private void tCounter_Tick(object sender, EventArgs e)
        {
            Seconds++;
            ModifyTime();
        }
        //Reset Timer
        private void btnRst_Click(object sender, EventArgs e)
        {
            DialogResult Dlg = MessageBox.Show("Are you sure you want to reset timer", "Reseting Timer Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Dlg == DialogResult.Yes)
            {
                Seconds = 0;
                Minutes = 0;
                Hours = 0;
                txtTimer.Text = "00:00:00";
                btnRst.Enabled = false;
                txtFormalTime.Text = "0";
                Seconds = 0;
                Minutes = 0;
                Hours = 0;
                tCounter.Stop();
                btnPause.Visible = false;
                btnStart.Text = "Start";
            }
        }
        //Click Start or Stop Timer
        private void btnStart_Click(object sender, EventArgs e)
        {
            DataGridViewComboBoxCell CM = new DataGridViewComboBoxCell();

            //if (SelectedTask != 0)
            //{
            DataSaved = false;
            LocalSaved = false;
            if (btnStart.Text == "Start")
            {
                Seconds = 0;
                Minutes = 0;
                Hours = 0;
                DialogResult Dlg = DialogResult.Yes;
                if (txtTimer.Text != "00:00:00")
                    Dlg = MessageBox.Show("Timer will clear previous time, Are you sure you want to start new timer?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (Dlg == DialogResult.Yes)
                {
                    txtTimer.Text = "00:00:00";
                    txtFormalTime.Text = "0";
                    btnStart.Text = "Stop";
                    tCounter.Start();
                    btnPause.Text = "Pause";
                    btnPause.Visible = true;
                    btnRst.Enabled = true;
                }
            }
            else
            {
                btnPause.Visible = false;
                btnStart.Text = "Start";
                tCounter.Stop();
                Seconds = 0;
                Minutes = 0;
                Hours = 0;
            }
            //}
            //else
            //    MessageBox.Show("Please select a task first");
        }
        //Pause button
        private void btnPause_Click(object sender, EventArgs e)
        {
            if (btnPause.Text == "Pause")
            {
                tCounter.Stop();
                btnPause.Text = "Continue";
            }
            else
            {
                tCounter.Start();
                btnPause.Text = "Pause";
            }
        }
        //Adjust and increase Seconds, mins and hours
        private void ModifyTime()
        {
            if (Hours < 24)
            {
                string Time = "";
                if (Seconds < 10)
                    Time = ":0" + Seconds.ToString();
                else if (Seconds <= 59)
                    Time = ":" + Seconds.ToString();
                else if (Seconds > 59)
                {
                    Minutes++;
                    Seconds = 0;
                    Time = ":0" + Seconds.ToString();
                }
                if (Minutes < 10)
                    Time = ":0" + Minutes.ToString() + Time;
                else if (Minutes <= 59)
                    Time = ":" + Minutes.ToString() + Time;
                else if (Minutes > 59)
                {
                    Hours++;
                    Minutes = 0;
                    Time = ":0" + Minutes.ToString() + Time;
                }
                if (Hours < 10)
                    Time = "0" + Hours.ToString() + Time;
                else
                    Time = Hours.ToString() + Time;
                txtTimer.Text = Time;
                double FormalTime = int.Parse(txtTimer.Text.Substring(0, 2)) + ((int.Parse(txtTimer.Text.Substring(3, 2)) * (.1 / 6))) + (int.Parse(txtTimer.Text.Substring(6, 2)) * (.1 / 360));
                double IntegerValue = Math.Floor(FormalTime);
                double FractionVal = Math.Round(FormalTime - IntegerValue, 2);
                if (FractionVal < 0.125)
                    FractionVal = 0;
                else if ((FractionVal >= 0.125 && FractionVal < 0.25) || (FractionVal >= 0.25 && FractionVal < 0.375))
                    FractionVal = 0.25;
                else if ((FractionVal >= 0.375 && FractionVal < 0.5) || (FractionVal >= 0.5 && FractionVal < 0.625))
                    FractionVal = 0.5;
                else if ((FractionVal >= 0.625 && FractionVal < 0.75) || (FractionVal >= 0.75 && FractionVal < 0.875))
                    FractionVal = 0.75;
                else if (FractionVal >= 0.875)
                {
                    FractionVal = 0;
                    IntegerValue++;
                }
                FormalTime = IntegerValue + FractionVal;
                txtFormalTime.Text = FormalTime.ToString();
            }
            else
            {
                tCounter.Stop();
                //if (this.WindowState == FormWindowState.Minimized)
                //    tWindow.Start();
                MessageBox.Show("Timer Exceeded Limited Time", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnStart.Text = "Stop";
                btnPause.Visible = false;
            }
        }
        private void tWindow_Tick(object sender, EventArgs e)
        {

            if (this.ForeColor == Color.Orange)
                this.ForeColor = Color.Blue;
            else
                this.ForeColor = Color.Orange;

        }

        #endregion
        ////////////Note Settings///////////////
        /// <summary>
        /// Get Today Notes and place them in the daily notes textbox 
        /// </summary>
        /// <param name="dsSheet">DataSet DaySheet</param>
        private void SetNote(DataSet dsSheet)
        {
            int Index = GetSelectedDayIndex();
            if (dsSheet.Tables[3].Rows[Index - 3].ItemArray[1].ToString() != "null")
                txtNotes.BodyHtml = DecodeText(dsSheet.Tables[3].Rows[Index - 3].ItemArray[1].ToString());
            //DateTime DT;
            //for (int n = 0; n < dsSheet.Tables[3].Rows.Count; n++)
            //{
            //    DT = (DateTime)dsSheet.Tables[3].Rows[n].ItemArray[0];
            //    if (DT.ToShortDateString() == TodayDate.ToShortDateString())
            //    {
            //        if(dsSheet.Tables[3].Rows[n].ItemArray[1].ToString() != "null")
            //            txtNotes.Text = DecodeText(dsSheet.Tables[3].Rows[n].ItemArray[1].ToString());
            //        break;
            //    }
            //}
        }
        //Save Notes in dataset from textbox
        private void txtNotes_TextPreviewKeyDownEvent(object sender, PreviewKeyDownEventArgs e)
        {
            if (pnlMainFrm.Visible && e.KeyValue.ToString() == "116")
            {
                RefershGrid();
                return;
            }

            txtNotes.Validate();
        }

        void txtNotes_ValidatedEvent(object sender, EventArgs e)
        {
            int Day = GetSelectedDayIndex();
            DataRow NewRow = AccSet.Tables[3].Rows[Day - 3];
            NewRow = AccSet.Tables[3].Rows[Day - 3];
            NewRow.BeginEdit();
            //NewRow[0] = TodayDate.Date;
            if (txtNotes.BodyHtml == null)
                NewRow[1] = "";
            else
                NewRow[1] = EncodeText(txtNotes.BodyHtml);
            NewRow.EndEdit();
            DataSaved = false;
        }

        private void txtNotes_ToolStripItemClickedEvent(object sender, ToolStripItemClickedEventArgs e)
        {
            int Day = GetSelectedDayIndex();
            DataRow NewRow = AccSet.Tables[3].Rows[Day - 3];
            NewRow = AccSet.Tables[3].Rows[Day - 3];
            NewRow.BeginEdit();
            //NewRow[0] = TodayDate.Date;
            if (txtNotes.BodyHtml == null)
                NewRow[1] = "";
            else
                NewRow[1] = EncodeText(txtNotes.BodyHtml);
            NewRow.EndEdit();
            DataSaved = false;
        }
        /// <summary>
        /// Decode daily notes retrieved from database
        /// </summary>
        /// <param name="Encoded">string EncodedNotes</param>
        /// <returns>string DecodedNotes</returns>
        private string DecodeText(string Encoded)
        {
            string NoteBody = Encoded;

            //NoteBody = NoteBody.Replace("%25", "%");
            //NoteBody = NoteBody.Replace("%20", " ");
            //NoteBody = NoteBody.Replace("%21", "!");
            //NoteBody = NoteBody.Replace("%23", "#");
            //NoteBody = NoteBody.Replace("%24", "$");

            //NoteBody = NoteBody.Replace("%5E", "^");
            //NoteBody = NoteBody.Replace("%26", "&");
            //NoteBody = NoteBody.Replace("%29", ")");
            //NoteBody = NoteBody.Replace("%28", "(");
            //NoteBody = NoteBody.Replace("%7C", "|");
            //NoteBody = NoteBody.Replace("%3B", ",");
            //NoteBody = NoteBody.Replace("%3F", "?");
            //NoteBody = NoteBody.Replace("%3B", ",");
            //NoteBody = NoteBody.Replace("%2C", "/");
            //NoteBody = NoteBody.Replace("%3A", ":");
            //NoteBody = NoteBody.Replace("%3D", "=");
            //NoteBody = NoteBody.Replace("%5D", "]");
            //NoteBody = NoteBody.Replace("%5B", "[");
            //NoteBody = NoteBody.Replace("%7D", "}");
            //NoteBody = NoteBody.Replace("%7B", "{");
            //NoteBody = NoteBody.Replace("%7E", "~");
            //NoteBody = NoteBody.Replace("%22", "\"");

            //NoteBody = NoteBody.Replace("%27", "'");
            //NoteBody = NoteBody.Replace("%5C", "\\");
            //NoteBody = NoteBody.Replace("%0D%0A", "\r\n");
            //NoteBody = NoteBody.Replace("%0D%", "\n");
            //NoteBody = NoteBody.Replace("%0A", "\n");
            //NoteBody = NoteBody.Replace("%3C", "<");
            //NoteBody = NoteBody.Replace("%3E", ">");
            //NoteBody = NoteBody.Replace("@@0937107@@", "&");

            //NoteBody = NoteBody.Replace("%25", "%");
            //NoteBody = NoteBody.Replace("%20", " ");
            //NoteBody = NoteBody.Replace("%21", "!");
            //NoteBody = NoteBody.Replace("%23", "#");
            //NoteBody = NoteBody.Replace("%24", "$");
            //NoteBody = NoteBody.Replace("%5E", "^");
            //NoteBody = NoteBody.Replace("%26", "&");
            //NoteBody = NoteBody.Replace("%29", ")");
            //NoteBody = NoteBody.Replace("%28", "(");
            //NoteBody = NoteBody.Replace("%7C", "|");
            //NoteBody = NoteBody.Replace("%3B", ";");
            //NoteBody = NoteBody.Replace("%3F", "?");
            //NoteBody = NoteBody.Replace("%3B", ",");
            //NoteBody = NoteBody.Replace("%2C", "/");
            //NoteBody = NoteBody.Replace("%3A", ":");
            //NoteBody = NoteBody.Replace("%3D", "=");
            //NoteBody = NoteBody.Replace("%5D", "]");
            //NoteBody = NoteBody.Replace("%5B", "[");
            //NoteBody = NoteBody.Replace("%7D", "}");
            //NoteBody = NoteBody.Replace("%7B", "{");
            //NoteBody = NoteBody.Replace("%7E", "~");
            //NoteBody = NoteBody.Replace("%22", "\"");
            //NoteBody = NoteBody.Replace("%27", "'");
            //NoteBody = NoteBody.Replace("%5C", "\\");
            //NoteBody = NoteBody.Replace("%0D%0A", "\n");
            //NoteBody = NoteBody.Replace("%0D%", "\n");
            //NoteBody = NoteBody.Replace("%0A", "\n");
            //NoteBody = NoteBody.Replace("%3C", "<");
            //NoteBody = NoteBody.Replace("%3E", ">");
            //NoteBody = NoteBody.Replace("@@0937107@@", "&");

            NoteBody = NoteBody.Replace("%25", "%");
            NoteBody = NoteBody.Replace("%20", " ");
            NoteBody = NoteBody.Replace("%21", "!");
            NoteBody = NoteBody.Replace("%23", "#");
            NoteBody = NoteBody.Replace("%24", "$");
            NoteBody = NoteBody.Replace("%5E", "^");
            NoteBody = NoteBody.Replace("%26", "&");
            NoteBody = NoteBody.Replace("%29", ")");
            NoteBody = NoteBody.Replace("%28", "(");
            NoteBody = NoteBody.Replace("%7C", "|");
            NoteBody = NoteBody.Replace("%3B", ";");
            NoteBody = NoteBody.Replace("%3F", "?");
            NoteBody = NoteBody.Replace("%3B", ";");
            NoteBody = NoteBody.Replace("%2C", ",");
            NoteBody = NoteBody.Replace("%3A", ":");
            NoteBody = NoteBody.Replace("%3D", "=");
            NoteBody = NoteBody.Replace("%5D", "]");
            NoteBody = NoteBody.Replace("%5B", "[");
            NoteBody = NoteBody.Replace("%7D", "}");
            NoteBody = NoteBody.Replace("%7B", "{");
            NoteBody = NoteBody.Replace("%7E", "~");
            NoteBody = NoteBody.Replace("%22", "\"");
            NoteBody = NoteBody.Replace("%27", "'");
            NoteBody = NoteBody.Replace("%5C", "\\");
            NoteBody = NoteBody.Replace("%0D%0A", "\n");
            NoteBody = NoteBody.Replace("%0D%", "\n");
            NoteBody = NoteBody.Replace("%0A", "\n");
            NoteBody = NoteBody.Replace("%3C", "<");
            NoteBody = NoteBody.Replace("%3E", ">");
            NoteBody = NoteBody.Replace("@@0937107@@", "&");


            return NoteBody;
        }
        /// <summary>
        /// Encode DailyNotes text before saving it to the database
        /// </summary>
        /// <param name="Decoded">string DecodedNotes</param>
        /// <returns>string EncodedNotes</returns>
        private string EncodeText(string Decoded)
        {
            string NoteBody = Decoded;

            //NoteBody = NoteBody.Replace("%","%25");
            //NoteBody = NoteBody.Replace(" ","%20");
            //NoteBody = NoteBody.Replace("!","%21") ;
            //NoteBody = NoteBody.Replace("#","%23");
            //NoteBody = NoteBody.Replace("$","%24") ;

            //NoteBody = NoteBody.Replace("^","%5E");
            //NoteBody = NoteBody.Replace("&","%26");
            //NoteBody = NoteBody.Replace(")","%29") ;
            //NoteBody = NoteBody.Replace("(","%28");
            //NoteBody = NoteBody.Replace( "|","%7C");
            //NoteBody = NoteBody.Replace(";","%3B");
            //NoteBody = NoteBody.Replace("?","%3F") ;
            //NoteBody = NoteBody.Replace(",","%3B");
            //NoteBody = NoteBody.Replace( "/","%2C");
            //NoteBody = NoteBody.Replace( ":","%3A");
            //NoteBody = NoteBody.Replace( "=","%3D");
            //NoteBody = NoteBody.Replace( "]","%5D");
            //NoteBody = NoteBody.Replace("[","%5B") ;
            //NoteBody = NoteBody.Replace( "}","%7D");
            //NoteBody = NoteBody.Replace("{","%7B") ;
            //NoteBody = NoteBody.Replace("~","%7E");
            //NoteBody = NoteBody.Replace("\"","%22");

            //NoteBody = NoteBody.Replace("'","%27");
            //NoteBody = NoteBody.Replace("\\","%5C");
            //NoteBody = NoteBody.Replace("\r\n","%0D%0A");
            //NoteBody = NoteBody.Replace("\n","%0D%");
            //NoteBody = NoteBody.Replace("\n","%0A");
            //NoteBody = NoteBody.Replace("<","%3C");
            //NoteBody = NoteBody.Replace(">","%3E");
            //NoteBody = NoteBody.Replace("&","@@0937107@@");

            NoteBody = NoteBody.Replace("%", "%25");
            NoteBody = NoteBody.Replace(" ", "%20");
            NoteBody = NoteBody.Replace("!", "%21");
            NoteBody = NoteBody.Replace("#", "%23");
            NoteBody = NoteBody.Replace("$", "%24");
            NoteBody = NoteBody.Replace("^", "%5E");
            NoteBody = NoteBody.Replace("&", "%26");
            NoteBody = NoteBody.Replace(")", "%29");
            NoteBody = NoteBody.Replace("(", "%28");
            NoteBody = NoteBody.Replace("|", "%7C");
            NoteBody = NoteBody.Replace(";", "%3B");
            NoteBody = NoteBody.Replace("?", "%3F");
            NoteBody = NoteBody.Replace(";", "%3B");
            NoteBody = NoteBody.Replace(",", "%2C");
            NoteBody = NoteBody.Replace(":", "%3A");
            NoteBody = NoteBody.Replace("=", "%3D");
            NoteBody = NoteBody.Replace("]", "%5D");
            NoteBody = NoteBody.Replace("[", "%5B");
            NoteBody = NoteBody.Replace("}", "%7D");
            NoteBody = NoteBody.Replace("{", "%7B");
            NoteBody = NoteBody.Replace("~", "%7E");
            NoteBody = NoteBody.Replace("\"", "%22");
            NoteBody = NoteBody.Replace("'", "%27");
            NoteBody = NoteBody.Replace("\\", "%5C");
            NoteBody = NoteBody.Replace("\n", "%0D%0A");
            NoteBody = NoteBody.Replace("\n", "%0D%");
            NoteBody = NoteBody.Replace("\n", "%0A");
            NoteBody = NoteBody.Replace("<", "%3C");
            NoteBody = NoteBody.Replace(">", "%3E");
            NoteBody = NoteBody.Replace("&", "@@0937107@@");

            return NoteBody;
        }
        //Expand and collapse in cell double click
        private void tgvTasks_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 0)
                {
                    bool ExpandIt = true;
                    for (int j = 0; j < ExpandedNodes.Count; j++)
                    {
                        if (tgvTasks[1, e.RowIndex].Value.ToString() == ExpandedNodes[j].ToString())
                        {
                            ExpandIt = false;
                            break;
                        }
                    }
                    TreeGridNode MyNode = tgvTasks.GetNodeForRow(e.RowIndex);
                    if (ExpandIt)
                    {
                        MyNode.Expand();
                        if (!(ExpandedNodes.Contains(MyNode.Cells[1].Value.ToString())))
                            ExpandedNodes.Add(MyNode.Cells[1].Value.ToString());
                    }

                    else
                    {
                        MyNode.Collapse();
                        ExpandedNodes.Remove(MyNode.Cells[1].Value.ToString());
                    }
                }
            }
        }
        //Enable Resizing Form When not In Login
        private void LoginForm_SizeChanged(object sender, EventArgs e)
        {
            if (pnlLogin.Visible)
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
            else
            {
                if (pnlMainFrm.Visible)
                {
                    pnlMainFrm.Width = this.Width - 10;
                    pnlMainFrm.Height = this.Height - 60;
                    tgvTasks.Width = pnlMainFrm.Width - 20;
                    txtNotes.Width = pnlMainFrm.Width - 20;
                    Point GrbPnt = new Point((int)((this.Width - grbButtons.Width) / 2) - 5, grbButtons.Location.Y);
                    Point BtnPnt = new Point((int)((this.Width - btnUpdate.Width) / 2) - 5, btnUpdate.Location.Y);
                    Point WlcmPnt = new Point((int)((this.Width - lblWlcm.Width) / 2) - 5, lblWlcm.Location.Y);
                    Point DatePnt = new Point((int)((this.Width - lblDate.Width) / 2) - 5, lblDate.Location.Y);
                    Point HelpPnt = new Point(pnlMainFrm.Width - 25, 0);
                    Point SizPnt = new Point(pnlMainFrm.Width - pbImgSize.Width, pnlMainFrm.Height - pbImgSize.Height);
                    Point VMode = new Point((int)((this.Width - pnlVMode.Width) / 2) - 5, pnlVMode.Location.Y);

                    btnUpdate.Location = BtnPnt;
                    grbButtons.Location = GrbPnt;
                    lblDate.Location = DatePnt;
                    lblWlcm.Location = WlcmPnt;
                    btnHelp.Location = HelpPnt;
                    pbImgSize.Location = SizPnt;
                    pnlVMode.Location = VMode;
                    AdjustGridColumns(GetSelectedDayIndex());
                }
                if (pnlMFG.Visible)
                {
                    pnlMFG.Width = this.Width - 12;
                    pnlMFG.Height = this.Height - 60;
                    pnlWorkerInfo.Width = pnlMFG.Width;
                    dgWorkerSheet.Width = pnlMFG.Width;
                    cmbEmpName.Left = (int)(282  * (double)pnlMFG.Width / 770);
                    clndrTaskDate.Left = (int)(314 * (double)pnlMFG.Width / 770);
                    imgCalender.Left = (int)(459 * (double)pnlMFG.Width / 770);
                    
                    Point BtnPnt = new Point((int)((this.Width - btnUpdateAccMFG.Width) / 2) - 5, btnUpdateAccMFG.Location.Y);
                    Point HelpPnt = new Point(pnlMFG.Width - 25, 0);
                    btnUpdateAccMFG.Location = BtnPnt;
                    btnHelp.Location = HelpPnt;
                    AdjustGridColumns();
                }
            }
            
        }
        #region commented code (collapse and uncheck)
        //private void ExpandForUncheck(TreeGridNode ExNode)
        //{
        //    if (ExNode == null)
        //    {
        //        for (int i = 0; i < tgvTasks.Nodes.Count; i++)
        //        {
        //            tgvTasks.Nodes[i].Expand();
        //            if (tgvTasks.Nodes[i].Nodes.Count > 0)
        //            {
        //                ExpandForUncheck(tgvTasks.Nodes[i]);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < ExNode.Nodes.Count; i++)
        //        {
        //            ExNode.Expand();
        //            if (ExNode.Nodes[i].Nodes.Count > 0)
        //            {
        //                ExpandForUncheck(ExNode.Nodes[i]);
        //            }
        //        }
        //    }
        //}
        //private void CollapseAfterCheck(ArrayList NodesToExpand)
        //{
        //    for (int i = 0; i < tgvTasks.Nodes.Count; i++)
        //    {
        //        CollapseAfterCheck(tgvTasks.Nodes[i], NodesToExpand);
        //    }
        //}
        //private void CollapseAfterCheck(TreeGridNode ParentNode, ArrayList NodesToExpand)
        //{
        //    if ((!NodesToExpand.Contains(ParentNode.Cells[1].Value.ToString())))
        //        ParentNode.Collapse();
        //    //else
        //    //    ParentNode.Collapse();
        //    if (ParentNode.Nodes.Count > 0)
        //    {
        //        for (int i = 0; i < ParentNode.Nodes.Count; i++)
        //        {
        //            CollapseAfterCheck(ParentNode.Nodes[i], NodesToExpand);
        //        }
        //    }
        //}
        #endregion
        //Check And Uncheck Selected Tasks
        private void tgvTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 10)
                {
                    if (tgvTasks.Rows[e.RowIndex].DefaultCellStyle.BackColor != Color.FromArgb(0, 255, 0) && tgvTasks.Rows[e.RowIndex].DefaultCellStyle.BackColor != Color.FromArgb(51, 204, 204)
                        && tgvTasks.Rows[e.RowIndex].DefaultCellStyle.BackColor != Color.FromArgb(175, 122, 165) && tgvTasks.Rows[e.RowIndex].DefaultCellStyle.BackColor != Color.FromArgb(243, 122, 30)
                        && tgvTasks.Rows[e.RowIndex].DefaultCellStyle.BackColor != Color.FromArgb(255, 255, 0) && tgvTasks.Rows[e.RowIndex].DefaultCellStyle.ForeColor != Color.Red)
                    {

                        this.tgvTasks.CommitEdit(DataGridViewDataErrorContexts.Commit);
                        if (tgvTasks[e.ColumnIndex, e.RowIndex].Value.ToString() == "False")
                        {
                            tgvTasks.Rows[e.RowIndex].Selected = false;
                            btnSave.Enabled = false;
                            SelectedTask = 0;
                        }
                        else
                        {
                            //for (int i = 0; i < tgvTasks.Nodes.Count; i++)
                            //{
                            //    UnCheckAll(tgvTasks.Nodes[i]);
                            //}
                            //tgvTasks.Rows[e.RowIndex].Selected = true;
                            //SelectedTask = int.Parse(tgvTasks.Rows[e.RowIndex].Cells[1].Value.ToString());
                            //btnSave.Enabled = true;

                            //ArrayList ENL = (ArrayList)ExpandedNodes.Clone();
                            //ExpandForUncheck(null);
                            //try
                            //{
                            //    CollapseAfterCheck(ENL);
                            //}
                            //catch { }
                            for (int i = 0; i < tgvTasks.Rows.Count; i++)
                            {
                                if (e.RowIndex != i && tgvTasks[10, i].ValueType.ToString() == "System.Boolean")
                                    ((DataGridViewCheckBoxCell)tgvTasks[10, i]).Value = false;
                            }
                            tgvTasks.Rows[e.RowIndex].Selected = true;
                            SelectedTask = int.Parse(tgvTasks.Rows[e.RowIndex].Cells[1].Value.ToString());
                            btnSave.Enabled = true;
                        }
                        #region Commented Code
                        //DataGridViewCheckBoxCell CbCell = (DataGridViewCheckBoxCell)tgvTasks[e.ColumnIndex, e.RowIndex];
                        //if (CbCell.Value != null && (bool)CbCell.Value == true)
                        //{
                        //    tgvTasks.Rows[e.RowIndex].Selected = false;
                        //}
                        //else
                        //{
                        //    for (int i = 0; i < tgvTasks.Rows.Count; i++)
                        //    {
                        //        if (e.RowIndex != i)
                        //            ((DataGridViewCheckBoxCell)tgvTasks[10, i]).Value = false;
                        //    }
                        //    tgvTasks.Rows[e.RowIndex].Selected = true;
                        //    SelectedTask = int.Parse(tgvTasks.Rows[e.RowIndex].Cells[1].Value.ToString());
                        //}
                        #endregion
                    }
                    else
                        MessageBox.Show("You can select timing tasks only");
                }
            }
        }
        //To sort the task table according to task priority
        //To Be Continued Later
        private void SortTable(ref DataSet dsTasks)
        {
            DataTable dtTasksNew = new DataTable();
            DataTable dtTasks = dsTasks.Tables[0];
            DataView dvTasks = new DataView(dtTasks);
            dvTasks.Sort = "Taskpriority";
            DataTable NewTable = dvTasks.Table;
            dsTasks.Merge(dvTasks.Table);

        }
        //View Mode ComboBox Events
        private void cmbViewMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ViewModeSelectedIndex == -1)
                ViewModeSelectedIndex = 0;
            else if (ViewModeSelectedIndex == cmbViewMode.SelectedIndex)
            {
                return;
            }
            else
            {
                DialogResult Dlg = DialogResult.None;
                if (DataSaved == false || LocalSaved == false)
                    Dlg = MessageBox.Show("Are you sure you want to change view mode? Unsaved data -Times and Daily Notes- will be lost", "View Mode Changing", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Dlg == DialogResult.Yes || Dlg == DialogResult.None)
                {
                    DataSaved = true;
                    LocalSaved = true;
                    ExpandedNodes.Clear();
                    if (cmbViewMode.SelectedIndex == 0)
                    {
                        GetEmployeeSheet(MyToken, false, false);
                        ViewModeSelectedIndex = 0;
                    }
                    else if (cmbViewMode.SelectedIndex == 1)
                    {
                        GetEmployeeSheet(MyToken, false, false);
                        ViewModeSelectedIndex = 1;
                    }
                    else if (cmbViewMode.SelectedIndex == 2)
                    {
                        GetEmployeeSheet(MyToken, false, false);
                        ViewModeSelectedIndex = 2;
                    }
                }
                else
                {
                    cmbViewMode.SelectedIndex = ViewModeSelectedIndex;
                }
            }
        }
        /////////////////Saving/////////////
        //Button Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SelectedTask != 0)
            {
                if (txtTimer.Text != "00:00:00")
                {
                    if (btnPause.Visible != true)
                    {
                        bool tSave = SaveTime();
                        if (tSave)
                        {
                            MessageBox.Show("Saved Successfully", "Saving Timer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtTimer.Text = "00:00:00";
                            btnRst.Enabled = false;
                            txtFormalTime.Text = "0";
                            Seconds = 0;
                            Minutes = 0;
                            Hours = 0;
                            LocalSaved = true;
                        }
                        else
                            MessageBox.Show("An error occurred, and data couldn't be saved", "Saving Timer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Stop the timer first", "Saving Timer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("There is no counted time to be saved", "Saving Timer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("There is no selected task", "Saving Timer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Save Time of timer,Update DataGrid with Timer,then save these updates to the DataSet
        /// </summary>
        /// <returns>bool TimeSaved</returns>
        private bool SaveTime()
        {
            bool Saved = true;
            double Time = 0;
            int SelectedDay = 0;
            double OldValue = 0;
            try
            {
                SelectedDay = GetSelectedDayIndex();
                Time = double.Parse(txtFormalTime.Text);
                //Time = int.Parse(txtTimer.Text.Substring(0, 2)) + ((int.Parse(txtTimer.Text.Substring(3, 2)) * (.1 / 6))) + (int.Parse(txtTimer.Text.Substring(6, 2)) * (.1 / 360));
                //Time = Math.Round(Time, 2);
                DataRow MyRow;
                for (int t = 0; t < AccSet.Tables[0].Rows.Count; t++)
                {
                    if (AccSet.Tables[0].Rows[t].ItemArray[11].ToString() == SelectedTask.ToString())
                    {
                        OldValue = double.Parse(AccSet.Tables[0].Rows[t].ItemArray[SelectedDay].ToString());
                        if (UpdateGridWithTimer(SelectedTask, SelectedDay, Time, OldValue))
                        {
                            Saved = false;
                            break;
                        }
                        Time += double.Parse(AccSet.Tables[0].Rows[t].ItemArray[SelectedDay].ToString());
                        MyRow = AccSet.Tables[0].Rows[t];
                        MyRow.BeginEdit();
                        MyRow[SelectedDay] = Time;
                        MyRow.EndEdit();
                        Saved = true;
                        break;
                    }
                }
            }
            catch
            {
                Saved = false;
            }
            if (Saved)
            {
                txtTimer.Text = "00:00:00";
                txtFormalTime.Text = "0";
                btnRst.Enabled = false;
                Seconds = 0;
                Minutes = 0;
                Hours = 0;
            }
            return Saved;
        }
        ///////////////////Updating//////////////////
        /// <summary>
        /// Update DataGrid with timer values,Add Timer values to the time of the selected task
        /// </summary>
        /// <param name="SelectedTask">int SelectedTask</param>
        /// <param name="SelectedDay">int SelectedDay</param>
        /// <param name="TimerValue">double TimerValue</param>
        /// <param name="OldValue">double OldValue</param>
        /// <returns>bool Updated</returns>
        private bool UpdateGridWithTimer(int SelectedTask, int SelectedDay, double TimerValue, double OldValue)
        {
            bool Invalid = false;
            double FullTime = Math.Round(TimerValue + OldValue, 2);
            for (int i = 0; i < tgvTasks.Rows.Count; i++)
            {
                if (tgvTasks[1, i].Value.ToString() == SelectedTask.ToString())
                {
                    string PreviousValue = tgvTasks[SelectedDay, i].Value.ToString();
                    tgvTasks[SelectedDay, i].Value = FullTime.ToString();
                    if (FullTime == 0)
                        tgvTasks[SelectedDay, i].Value = "";
                    Invalid = UpdateCalculatedHeaders(SelectedTask, FullTime, OldValue, SelectedDay);
                    if (Invalid)
                        tgvTasks[SelectedDay, i].Value = PreviousValue;
                    break;
                }
            }
            return Invalid;
        }
        //Compare between current DataSet and New DataSet From Server
        int CompareRepearter = 0;
        /// <summary>
        /// Compare between New DataSet and Current DataSet on The Server
        /// </summary>
        /// <returns>bool Equal</returns>
        private bool CompareDataSets()
        {
            bool Equal = true;
            try
            {
                int vMode = 10;
                MyToken = ValidateUser(UsrNam, Paswrd, false);
                AccountabilityService.AccountabilityService FreshSheet = new AccountabilityNotePad.AccountabilityService.AccountabilityService();
                FreshSheet.Url = wsUrl + wsUrlPart1 + "AccountabilityService.asmx";
                AccountabilityService.AuthHeader FHeader = new AccountabilityNotePad.AccountabilityService.AuthHeader();
                FHeader.Token = MyToken;
                FreshSheet.AuthHeaderValue = FHeader;
                DataSet FreshSet = new DataSet();
                //DateTime CurrentDate = new DateTime(TodayDate.Year, TodayDate.Month, TodayDate.Day);
                if (cmbViewMode.SelectedIndex == 0)
                    vMode = 10;
                else if (cmbViewMode.SelectedIndex == 1)
                    vMode = 30;
                else if (cmbViewMode.SelectedIndex == 2)
                    vMode = 10;
                IFormatProvider Culture = new System.Globalization.CultureInfo("en-US", true);
                FreshSet = FreshSheet.GetAccSheet(UserID, DateTime.Parse(TodayDate.ToShortDateString(), Culture), vMode, false);
                if (cmbViewMode.SelectedIndex == 2)
                    FilterDataSet(ref FreshSet);
                for (int t = 0; t < 4; t++)
                {
                    if (!(t == 1 || t == 2))
                    {
                        if (!ValidateTaskTables(FreshSet.Tables[t], OriginalSet.Tables[t], t))
                        {
                            Equal = false;
                            break;
                        }
                    }
                }
                CompareRepearter = 0;
            }
            catch (Exception Ecp)
            {
                CompareRepearter++;
                DialogResult Dlg = DialogResult.None;
                if (CompareRepearter > 2)
                    Dlg = MessageBox.Show("Error While Comparing Data, Server May Be Busy", "Connection Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                if (Dlg == DialogResult.Retry || CompareRepearter <= 2)
                    Equal = CompareDataSets();
                else
                    MessageBox.Show(Ecp.Message, "Connection Error");
            }
            return Equal;
        }
        /// <summary>
        /// Check if The Current TaskTable and The Original TaskTable are the same or not
        /// </summary>
        /// <param name="Table1">DataTable CurrentTable</param>
        /// <param name="Table2">DataTable OriginalTable</param>
        /// <param name="TableIndex">int TableIndex</param>
        /// <returns>bool Thesame</returns>
        private bool ValidateTaskTables(DataTable Table1, DataTable Table2, int TableIndex)
        {
            bool Valid = true;
            if (TableIndex != 3)
            {
                if (Table1.Rows.Count != Table2.Rows.Count)
                {
                    Valid = false;
                    return Valid;
                }
                else
                {
                    for (int t = 0; t < Table1.Rows.Count; t++)
                    {
                        for (int i = 0; i < Table1.Rows[t].ItemArray.Length; i++)
                        {
                            if (i > 2 && i < 11)
                            {
                                if (i != GetSelectedDayIndex())
                                {
                                    continue;
                                }
                            }
                            if (Table1.Rows[t].ItemArray[i].ToString() != Table2.Rows[t].ItemArray[i].ToString())
                            {
                                Valid = false;
                                return Valid;
                            }

                        }
                    }
                }
            }
            else
            {
                for (int j = 0; j < Table1.Rows.Count; j++)
                {
                    for (int l = 0; l < Table2.Rows.Count; l++)
                    {
                        if ((Table1.Rows[j].ItemArray[0].ToString() == Table2.Rows[l].ItemArray[0].ToString()) && (((DateTime)Table1.Rows[j].ItemArray[0]).ToShortDateString() == (Convert.ToDateTime(lblDate.Text).ToShortDateString())))
                        {
                            if (Table1.Rows[j].ItemArray[1].ToString() != Table2.Rows[l].ItemArray[1].ToString())
                            {
                                Valid = false;
                                return Valid;
                            }
                        }
                    }
                }
            }
            return Valid;
        }
        //Button Update to update database with current dataset
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateButtonFunction(true);
            //FocusOnLastView();
        }
        /// <summary>
        /// Return grid to the previous view (Exapnded and Collapsed Nodes) after updating Accountability
        /// </summary>
        private void FocusOnLastView()
        {
            for (int u = 0; u < ExpandedNodes.Count; u++)
            {
                for (int p = 0; p < tgvTasks.Nodes.Count; p++)
                {
                    try
                    {
                        ExpandNode(ExpandedNodes[u].ToString(), tgvTasks.Nodes[p]);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }
        /// <summary>
        /// Expand node to show the node's leaves 
        /// </summary>
        /// <param name="NodeID">string NodeID</param>
        /// <param name="SenderNode">TreeGridNode ParentNode</param>
        /// <returns>bool Expanded</returns>
        private bool ExpandNode(string NodeID, TreeGridNode SenderNode)
        {
            bool Expanded = false;
            if (SenderNode.Cells[1].Value.ToString() == NodeID)
            {
                SenderNode.Expand();
                Expanded = true;
                return Expanded;
            }
            else if (SenderNode.Nodes.Count > 0)
            {
                for (int y = 0; y < SenderNode.Nodes.Count; y++)
                {
                    Expanded = ExpandNode(NodeID, SenderNode.Nodes[y]);
                    if (Expanded)
                        break;
                }
            }
            return Expanded;
        }
        /// <summary>
        /// Update Accountability Notepad when the user press update button or update menu item 
        /// </summary>
        /// <param name="ShowMessage">bool ShowMessage</param>
        /// <returns>int FinishUpdate</returns>
        private int UpdateButtonFunction(bool ShowMessage)
        {
            try
            {
                string MessageText = "";
                DialogResult Dlg = DialogResult.None;
                if (ShowMessage)
                {
                    if (!LocalSaved)
                        MessageText = "Are you sure you want to Update accountability? unsaved timer values will be lost";
                    else
                        MessageText = "Are you sure you want to Update accountability?";
                    Dlg = MessageBox.Show(MessageText, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                }
                else
                    Dlg = DialogResult.Yes;
                if (Dlg == DialogResult.Yes)
                {
                    bool Done = false;
                    FreeResources(true);
                    if (CompareDataSets())
                    {
                        Done = UpdateDataBase(AccSet);
                        UpdateRepeater = 0;
                    }
                    else
                    {
                        DialogResult DG = MessageBox.Show("Data on the accountability web site has been changed, Do you want to ovewrite it?\r\nYes to overwrite data on the server \r\nNo to get latest version from server and overwrite existing \r\nCancel to take no action", "Caution", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                        if (DG == DialogResult.Yes)
                            Done = UpdateDataBase(AccSet);
                        else if (DG == DialogResult.No)
                        {
                            txtTimer.Text = "00:00:00";
                            txtFormalTime.Text = "0";
                            btnRst.Enabled = false;
                            btnSave.Enabled = false;
                            Seconds = 0;
                            Minutes = 0;
                            Hours = 0;
                            GetEmployeeSheet(MyToken, false, true);
                            MessageBox.Show("Data refreshed successfully", "Refreshed Sucessfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return 1;
                        }
                        else
                        {
                            MessageBox.Show("Action canceled", "Action Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return 0;
                        }
                    }
                    if (Done)
                    {
                        GetEmployeeSheet(MyToken, false, true);
                        //DialogResult MyDlg = MessageBox.Show("Database updated sucessfully, Do you want to exit application?", "Update Database",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                        CustomMessageBox CMB = new CustomMessageBox();
                        CMB.ShowDialog();
                        string RV = CMB.ReturnValue;
                        DataSaved = true;
                        txtTimer.Text = "00:00:00";
                        txtFormalTime.Text = "0";
                        btnRst.Enabled = false;
                        btnSave.Enabled = false;
                        Seconds = 0;
                        Minutes = 0;
                        Hours = 0;
                        if (RV == "Exit")
                        {
                            FormClosingEventArgs Cls = new FormClosingEventArgs(CloseReason.UserClosing, false);
                            object Sndr = "Close without alert";
                            LoginForm_FormClosing(Sndr, Cls);
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    else
                        MessageBox.Show("Couldn't update database ");
                }
            }
            catch (Exception Ecp)
            {
                //MessageBox.Show(Ecp.Message);
            }
            return 1;
        }

        #region Commented Update Function
        //private DataSet ReplaceDataSetColumns(DataSet ExistingDataSet)
        //{
        //    int vMode = 10;
        //    SheetWebService.AccountabilityService FreshSheet = new AccountabilityNotePad.SheetWebService.AccountabilityService();
        //    SheetWebService.AuthHeader FHeader = new AccountabilityNotePad.SheetWebService.AuthHeader();
        //    FHeader.Token = MyToken;
        //    FreshSheet.AuthHeaderValue = FHeader;
        //    DataSet NewDataSet = new DataSet();
        //    if (cmbViewMode.SelectedIndex == 0)
        //        vMode = 10;
        //    else if (cmbViewMode.SelectedIndex == 1)
        //        vMode = 30;
        //    else if (cmbViewMode.SelectedIndex == 2)
        //        vMode = 10;
        //    IFormatProvider Culture = new System.Globalization.CultureInfo("en-US", true);
        //    NewDataSet = FreshSheet.GetAccSheet(UserID, DateTime.Parse(TodayDate.ToShortDateString(), Culture), vMode, false);
        //    if (cmbViewMode.SelectedIndex == 2)
        //        FilterDataSet(ref NewDataSet);
        //    DataRow RowToUpdate;
        //    for (int i = 0; i < NewDataSet.Tables[0].Rows.Count; i++)
        //    {
        //        for (int k = 0; k < NewDataSet.Tables[0].Rows[i].ItemArray.Length; k++)
        //        {
        //            if (k == GetSelectedDayIndex())
        //            {
        //                RowToUpdate = NewDataSet.Tables[0].Rows[i];
        //                RowToUpdate.BeginEdit();
        //                RowToUpdate.ItemArray[k] = ExistingDataSet.Tables[0].Rows[i].ItemArray[k].ToString();
        //                RowToUpdate.EndEdit();
        //            }
        //        }
        //    }
        //    DataRow NotesRow;
        //    for (int y = 0; y < NewDataSet.Tables[3].Rows.Count; y++)
        //    {
        //        //if
        //        NotesRow = NewDataSet.Tables[3].Rows[y];
        //        NotesRow.BeginEdit();
        //        NotesRow.ItemArray[1] = ExistingDataSet.Tables[3].Rows[y].ItemArray[1].ToString();
        //        NotesRow.EndEdit();
        //    }
        //    return NewDataSet;
        //}
        #endregion
        //Update Database with the current dataset
        int UpdateRepeater = 0;
        /// <summary>
        /// Update the Database with the current DataSet
        /// </summary>
        /// <param name="SheetSet">DataSet usersheet</param>
        /// <returns>bool Updated</returns>
        private bool UpdateDataBase(DataSet SheetSet)
        {
            bool Updated = false;
            try
            {
                //MyToken = ValidateUser(txtUsrName.Text, txtPasswrd.Text);
                AccountabilityService.AccountabilityService FreshSheet = new AccountabilityNotePad.AccountabilityService.AccountabilityService();
                FreshSheet.Url = wsUrl + wsUrlPart1 + "AccountabilityService.asmx";
                AccountabilityService.AuthHeader FHeader = new AccountabilityNotePad.AccountabilityService.AuthHeader();
                FHeader.Token = MyToken;
                FreshSheet.AuthHeaderValue = FHeader;
                int vMode = 10;
                AccountabilityService.AccountabilityService MyUpdatServic = new AccountabilityNotePad.AccountabilityService.AccountabilityService();
                MyUpdatServic.Url = wsUrl + wsUrlPart1 + "AccountabilityService.asmx";
                AccountabilityService.AuthHeader UpHeader = new AccountabilityNotePad.AccountabilityService.AuthHeader();
                UpHeader.Token = MyToken;
                MyUpdatServic.AuthHeaderValue = UpHeader;
                //ChangeDataSetDates();
                IFormatProvider Culture = new System.Globalization.CultureInfo("en-US", true);
                if (cmbViewMode.SelectedIndex == 0)
                    vMode = 10;
                else if (cmbViewMode.SelectedIndex == 1)
                    vMode = 30;
                else if (cmbViewMode.SelectedIndex == 2)
                    vMode = 40;

                TodayDate = GetServerTime();
                if (TodayDate == DateTime.MinValue)
                    TodayDate = DateTime.Today;

                MyUpdatServic.UpdateSheetForDay(AccSet, UserID, DateTime.Parse(TodayDate.ToShortDateString(), Culture), vMode, true);
                //MyUpdatServic.UpdateSheet(AccSet, UserID, DateTime.Parse(TodayDate.ToShortDateString(), Culture), vMode);
                Updated = true;
                UpdateRepeater = 0;
            }
            catch (Exception Ecp)
            {
                UpdateRepeater++;
                DialogResult Dlg = DialogResult.None;
                if (UpdateRepeater > 2)
                {
                    Dlg = MessageBox.Show("Error While Updating Database,Server may be busy", "Server Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    Updated = false;
                }
                if (Dlg == DialogResult.Retry || UpdateRepeater <= 2)
                {
                    Updated = UpdateDataBase(SheetSet);

                }
                else
                {
                    MessageBox.Show(Ecp.Message);
                    Updated = false;
                }
            }
            return Updated;
        }
        /// <summary>
        /// Allow the user to get the date only without Time
        /// </summary>
        private void ChangeDataSetDates()
        {
            DataRow MyRow;
            for (int d = 0; d < AccSet.Tables[3].Rows.Count; d++)
            {
                MyRow = AccSet.Tables[3].Rows[d];
                MyRow.BeginEdit();
                MyRow[0] = Convert.ToDateTime(AccSet.Tables[3].Rows[d].ItemArray[0].ToString()).ToShortDateString();
                MyRow.EndEdit();
                //AccSet.Tables[3].Rows[d].ItemArray[0] = Convert.ToDateTime(AccSet.Tables[3].Rows[d].ItemArray[0].ToString()).ToShortDateString();
                //AccSet.Tables[3].Rows[d].AcceptChanges();
            }
            //AccSet.AcceptChanges();
        }
        /// <summary>
        /// Update the DataGrid with data on the Accountability WebSite 
        /// </summary>
        private void RefershGrid()
        {
            DialogResult Dlg = MessageBox.Show("Are you sure you want to refresh your data?", "Refresh Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            if (Dlg == DialogResult.Yes)
            {
                txtTimer.Text = "00:00:00";
                txtFormalTime.Text = "0";
                btnRst.Enabled = false;
                Seconds = 0;
                Minutes = 0;
                Hours = 0;
                FreeResources(true);
                GetEmployeeSheet(MyToken, false, false);
                MessageBox.Show("Data refreshed successfully");
            }
        }
        //Refreshing Data when press F5
        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (pnlMainFrm.Visible && e.KeyValue.ToString() == "116")
                RefershGrid();
        }

        private void tgvTasks_KeyDown(object sender, KeyEventArgs e)
        {
            if (pnlMainFrm.Visible && e.KeyValue.ToString() == "116")
                RefershGrid();
        }
        ////////Close Application Event////////
        bool SelfCaller = false; //to determine if it is exit button or exit from menu item
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ExitDlg = DialogResult.None;
            if ((pnlLogin.Visible && SelfCaller != true) || (sender != null && sender.ToString() == "Close without alert"))
            {
                ExitDlg = DialogResult.Yes;
            }
            else
            {
                if (!SelfCaller)
                {
                    checkMFGDataSaved();
                    if (DataSaved && MFGDataSaved)
                    {
                        ExitDlg = MessageBox.Show("Are you sure you want to exit the application?", "Exit Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    }
                    else
                    {
                        DialogResult MyDlg = MessageBox.Show("Unsaved data will be lost, Do you want to update your accountability?", "Exit Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                        if (MyDlg == DialogResult.No)
                            ExitDlg = DialogResult.Yes;
                        else if (MyDlg == DialogResult.Cancel)
                            ExitDlg = DialogResult.No;
                        else
                        {
                            if (isMFGUser && !MFGDataSaved)
                            {
                                if (!updateMFGAccDB())
                                    ExitDlg = DialogResult.No;
                            }
                            else
                            {
                                if (UpdateButtonFunction(false).ToString() == "0")
                                    ExitDlg = DialogResult.No;
                            }
                        }
                    }
                }
            }
            if (ExitDlg == DialogResult.No)
            {
                e.Cancel = true;
                SelfCaller = false;
            }
            else if (ExitDlg == DialogResult.Yes)
            {
                SelfCaller = true;
                DateTime LogoutTime = GetServerTime();
                AddLogoutrecord(LogoutTime);
                ThreadStart CTS = new ThreadStart(CloseSession);
                Thread CloseThread = new Thread(CTS);
                //UpdateServiceTimer.Stop();
                CloseThread.Start();
                this.Hide();
                this.Close();
            }
        }
        private void AddLogoutrecord(DateTime CurrentTime)
        {
            if (LoginID != 0)
            {
                //Update record of user logging and set it to logout 
                SecurityManagement.AuthHeader SecHeader = new AccountabilityNotePad.SecurityManagement.AuthHeader();
                SecHeader.Token = MyToken;
                SecurityManagement.SecurityManagement SecMngmnt = new AccountabilityNotePad.SecurityManagement.SecurityManagement();
                SecMngmnt.Url = wsUrl + wsUrlPart3 + "SecurityManagement.asmx";
                SecMngmnt.AuthHeaderValue = SecHeader;
                LoginID = SecMngmnt.UpdateUserLogin(CurrentTime, LoginID);
                LoginID = 0;
            }
        }
        /// <summary>
        /// Close the session between the user and the Accountability WebSite when the user closes the application
        /// </summary>
        private void CloseSession()
        {
            try
            {
                //FileAccess.FileAccessService FAS = new AccountabilityNotePad.FileAccess.FileAccessService();
                //FAS.Url = "http://" + GetFileServer() + "/FileAccessWS/FileAccessService.asmx";
                //FAS.DeleteFile(Environment.UserName);
                //if (Directory.Exists(Application.StartupPath + @"\Temp") && File.Exists(Application.StartupPath + @"\Temp\" + Environment.UserName + ".txt"))
                //    File.Delete(Application.StartupPath + @"\Temp\" + Environment.UserName + ".txt");
                ERPSessionServices.AuthHeader Hdr = new AccountabilityNotePad.ERPSessionServices.AuthHeader();
                Hdr.Token = MyToken;
                ERPSessionServices.ERPSessionServices Ext = new AccountabilityNotePad.ERPSessionServices.ERPSessionServices();
                Ext.Url = wsUrl + wsUrlPart1 + "ERPSessionServices.asmx";
                Ext.AuthHeaderValue = Hdr;
                Ext.LogOff();
            }
            catch (Exception Ecp)
            {
                string Err = Ecp.Message;
            }
        }

        /////////Cell Editing Events/////////
        string EditText = "";
        //Begin Edit
        private void tgvTasks_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != 10)
            {
                if (tgvTasks[e.ColumnIndex, e.RowIndex].Value == null)
                    EditText = "";
                else
                    EditText = tgvTasks[e.ColumnIndex, e.RowIndex].Value.ToString().Trim();
                if (EditText == "")
                    EditText = "0";
            }
        }
        //End Edit       
        private void tgvTasks_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 10)
            {
                //if (tgvTasks[e.ColumnIndex, e.RowIndex].Value != null)
                //{
                bool Continue = true;
                if (tgvTasks.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.FromArgb(255, 255, 0) || tgvTasks.Rows[e.RowIndex].DefaultCellStyle.ForeColor == Color.Red)
                {
                    if (tgvTasks[e.ColumnIndex, e.RowIndex].Value != null && tgvTasks[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != "")
                    {
                        if (!CheckIfNumber(tgvTasks[e.ColumnIndex, e.RowIndex].Value.ToString()))
                        {
                            MessageBox.Show("Entered value is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (EditText == "0")
                                EditText = "";
                            tgvTasks[e.ColumnIndex, e.RowIndex].Value = EditText;
                            //EditText = "";
                            Continue = false;
                        }
                        else
                        {
                            if (double.Parse(tgvTasks[e.ColumnIndex, e.RowIndex].Value.ToString().Trim()) == 0)
                                tgvTasks[e.ColumnIndex, e.RowIndex].Value = "";
                            else
                                tgvTasks[e.ColumnIndex, e.RowIndex].Value = double.Parse(tgvTasks[e.ColumnIndex, e.RowIndex].Value.ToString().Trim()).ToString();
                        }
                    }
                }
                else
                {
                    string CellValue = "";
                    if (tgvTasks[e.ColumnIndex, e.RowIndex].Value != null)
                        CellValue = tgvTasks[e.ColumnIndex, e.RowIndex].Value.ToString().Trim();
                    if (CellValue == "")
                        CellValue = "0";
                    if (!CheckIfNumber(CellValue) || double.Parse(CellValue) > 24)
                    {
                        MessageBox.Show("Entered value is invalid, value should be between 0 and 24", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (EditText == "0")
                            EditText = "";
                        tgvTasks[e.ColumnIndex, e.RowIndex].Value = EditText;
                        //EditText = "";
                        Continue = false;
                    }
                }

                if (Continue)
                {
                    DataSaved = false;
                    if (!(tgvTasks.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.FromArgb(255, 255, 0)) && !(tgvTasks.Rows[e.RowIndex].DefaultCellStyle.ForeColor == Color.Red))
                    {
                        double CellValue = 0;
                        if (tgvTasks[e.ColumnIndex, e.RowIndex].Value != null && tgvTasks[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() != "")
                            CellValue = double.Parse(tgvTasks[e.ColumnIndex, e.RowIndex].Value.ToString().Trim());
                        bool Invalid = UpdateCalculatedHeaders(int.Parse(tgvTasks[1, e.RowIndex].Value.ToString()), CellValue, double.Parse(EditText), GetSelectedDayIndex());
                        if (Invalid)
                        {
                            if (EditText == "0")
                                EditText = "";
                            tgvTasks[e.ColumnIndex, e.RowIndex].Value = EditText;
                            //MessageBox.Show("Time Exceeds 24 hours for today","Timing Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (CellValue != 0)
                                tgvTasks[e.ColumnIndex, e.RowIndex].Value = Math.Round(CellValue, 2);
                            else
                                tgvTasks[e.ColumnIndex, e.RowIndex].Value = "";
                            SimultaneousUpdateGrid(e.RowIndex, e.ColumnIndex, tgvTasks[e.ColumnIndex, e.RowIndex].Value.ToString());
                        }
                    }
                    else
                    {
                        if (tgvTasks[e.ColumnIndex, e.RowIndex].Value == null || tgvTasks[e.ColumnIndex, e.RowIndex].Value.ToString().Trim() == "")
                            SimultaneousUpdateGrid(e.RowIndex, e.ColumnIndex, "0");
                        else
                            SimultaneousUpdateGrid(e.RowIndex, e.ColumnIndex, tgvTasks[e.ColumnIndex, e.RowIndex].Value.ToString());
                    }
                }
                //}
                //else
                //{
                //    MessageBox.Show("Cannot accept empty value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    tgvTasks[e.ColumnIndex, e.RowIndex].Value = EditText;
                //}
                EditText = "";
                //DataRow MyRow = AccSet.Tables[0].Rows[e.RowIndex];
                //MyRow.BeginEdit();
                //MyRow[e.ColumnIndex] = ;
                //MyRow.EndEdit();
            }

        }
        /// <summary>
        /// Update The DataSet with changes made in the datagrid
        /// </summary>
        /// <param name="RowIndex">int RowIndex</param>
        /// <param name="ColumnIndex">int ColumnIndex</param>
        /// <param name="NewValue">string NewValue</param>
        private void SimultaneousUpdateGrid(int RowIndex, int ColumnIndex, string NewValue)
        {
            string TaskID = tgvTasks[1, RowIndex].Value.ToString();
            DataRow GridRow;
            if (NewValue == "")
                NewValue = "0";
            for (int g = 0; g < AccSet.Tables[0].Rows.Count; g++)
            {
                if (AccSet.Tables[0].Rows[g].ItemArray[11].ToString() == TaskID)
                {
                    GridRow = AccSet.Tables[0].Rows[g];
                    GridRow.BeginEdit();
                    GridRow[ColumnIndex] = NewValue;
                    GridRow.EndEdit();
                    break;
                }
            }
        }

        /////////////////General Needed Functions//////////
        /// <summary>
        /// Check If the comming text is integer or not
        /// </summary>
        /// <param name="TextToCheck">string TextToCheck</param>
        /// <returns>bool IsInteger</returns>
        private bool CheckIfNumber(string TextToCheck)
        {
            bool IsNumber = true;
            double Result;
            IsNumber = double.TryParse(TextToCheck, out Result);
            if (IsNumber && Result < 0)
                IsNumber = false;
            return IsNumber;
        }
        private bool CheckIfInteger(string TextToCheck)
        {
            bool IsNumber = true;
            int Result;
            IsNumber = int.TryParse(TextToCheck, out Result);
            if (IsNumber && Result < 0)
                IsNumber = false;
            return IsNumber;
        }
        /// <summary>
        /// Get the Current Day Index
        /// </summary>
        /// <returns>int DayIndex</returns>
        private int GetSelectedDayIndex()
        {
            int SelectedDay = 0;
            for (int i = 3; i < 10; i++)
            {
                if (tgvTasks.Columns[i].Visible)
                {
                    SelectedDay = i;
                    break;
                }
            }
            return SelectedDay;
        }
        /// <summary>
        /// Format datagrid columns in suitable size 
        /// </summary>
        /// <param name="ColumnIndex">int ColumnIndex</param>
        private void AdjustGridColumns(int ColumnIndex)//, bool FirstTime)
        {
            tgvTasks.Columns[0].Width = tgvTasks.Width - (38 + 30 + 40);
            tgvTasks.Columns[2].Width = 30;
            tgvTasks.Columns[ColumnIndex].Width = 38;
            tgvTasks.Columns[10].Width = 40;
            tgvTasks.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            tgvTasks.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
        private void AdjustGridColumns()//, bool FirstTime)
        {
            dgWorkerSheet.Columns["colTrvNumber"].Width = (int)(66 * (double)dgWorkerSheet.Width / 770);
            dgWorkerSheet.Columns["colCompnay"].Width = (int)(130 * (double)dgWorkerSheet.Width / 770);
            dgWorkerSheet.Columns["colClipMember"].Width = (int)(80 * (double)dgWorkerSheet.Width / 770);
            dgWorkerSheet.Columns["colPartClass"].Width = (int)(80 * (double)dgWorkerSheet.Width / 770);
            dgWorkerSheet.Columns["colPartNumber"].Width = (int)(90 * (double)dgWorkerSheet.Width / 770);
            dgWorkerSheet.Columns["colOperation"].Width = (int)(150 * (double)dgWorkerSheet.Width / 770);
            dgWorkerSheet.Columns["colQuantity"].Width = (int)(66 * (double)dgWorkerSheet.Width / 770);
            dgWorkerSheet.Columns["colHours"].Width = (int)(65 * (double)dgWorkerSheet.Width / 770);
        }
        /// <summary>
        /// Clear All Variables And Controls
        /// </summary>
        private void FreeResources(bool CounterOnly)
        {
            if (!CounterOnly)
            {
                Remove = false;
                SelectedTask = 0;
                MyToken = "";
                txtNotes.BodyHtml = "";
                LocalSaved = true;
            }
            Seconds = 0;
            Hours = 0;
            Minutes = 0;
            tCounter.Stop();
            btnPause.Visible = false;
            btnStart.Text = "Start";
            txtTimer.Text = "00:00:00";
            btnRst.Enabled = false;
            txtFormalTime.Text = "0";
        }
        /// <summary>
        /// Calculate total amount of time of each responsibilty at the head of responsibilty and Calculate total amount of time of each project at the head of projects
        /// </summary>
        /// <param name="SelectedTaskID">int SelectedTaskID</param>
        /// <param name="NewValue">double NewValue</param>
        /// <param name="OldValue">double OldValue</param>
        /// <param name="SelectedDay">int SelectedDay</param>
        /// <returns>bool ExceedLimit</returns>
        private bool UpdateCalculatedHeaders(int SelectedTaskID, double NewValue, double OldValue, int SelectedDay)
        {
            bool ExeedLimit = false;

            for (int m = 0; m < AccSet.Tables[0].Rows.Count; m++)
            {
                if (AccSet.Tables[0].Rows[m].ItemArray[11].ToString() == SelectedTaskID.ToString())
                {
                    if (AccSet.Tables[0].Rows[m].ItemArray[14].ToString() != "")
                    {
                        ExeedLimit = CalculateProjectHeader(AccSet.Tables[0].Rows[m].ItemArray[14].ToString(), NewValue, OldValue, SelectedDay);
                        if (ExeedLimit)
                            break;
                    }
                    if (AccSet.Tables[0].Rows[m].ItemArray[15].ToString() != "")
                    {
                        ExeedLimit = CalculateResponsibiltyHeader(AccSet.Tables[0].Rows[m].ItemArray[15].ToString(), NewValue, OldValue, SelectedDay);
                        if (ExeedLimit)
                            break;
                    }
                    break;
                }
            }
            if (!ExeedLimit)
                ExeedLimit = UpdateColumnHeaderText(SelectedDay);
            if (ExeedLimit)
                MessageBox.Show("Time Exceeds 24 Hours For Today", "Data Entered Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return ExeedLimit;
        }
        /// <summary>
        /// Put the total amount of time at the column header
        /// </summary>
        /// <param name="SelectedDay">int SelectedDay</param>
        /// <returns>bool Exceeded</returns>
        private bool UpdateColumnHeaderText(int SelectedDay)
        {
            tgvTasks.Columns[SelectedDay].HeaderText = "0";
            bool Exeeded = false;
            double DayTime = 0;
            Color Clr = new Color();
            if (cmbViewMode.SelectedIndex == 0)
                Clr = Color.FromArgb(51, 204, 204);
            else if (cmbViewMode.SelectedIndex == 1)
                Clr = Color.FromArgb(0, 255, 0);
            for (int i = 0; i < tgvTasks.Nodes.Count; i++)
            {
                if (tgvTasks.Nodes[i].DefaultCellStyle.BackColor == Clr || cmbViewMode.SelectedIndex == 2)
                {
                    if (!(cmbViewMode.SelectedIndex == 2 && (tgvTasks.Nodes[i].DefaultCellStyle.BackColor == Color.FromArgb(255, 255, 0) || tgvTasks.Nodes[i].DefaultCellStyle.ForeColor == Color.Red)))
                    {
                        string CellValue = "";
                        if (tgvTasks.Nodes[i].Cells[SelectedDay].Value != null)
                            CellValue = tgvTasks.Nodes[i].Cells[SelectedDay].Value.ToString().Trim();
                        if (CellValue == "")
                            CellValue = "0";
                        DayTime = DayTime + Math.Round(double.Parse(CellValue), 2);
                        if (DayTime < 0)
                            DayTime = 0;
                    }
                }
            }
            if (!(DayTime <= 24))
                Exeeded = true;
            else
            {
                Exeeded = false;
                //string DayName = tgvTasks.Columns[SelectedDay].HeaderText;
                //DayName = DayName.Substring(0, DayName.IndexOf("y") + 1);
                ////tgvTasks.Columns[SelectedDay].HeaderText = DayName + "\r\n" + TodayDate.ToShortDateString() + "\r\n" + "Total = " + DayTime;
                //tgvTasks.Columns[SelectedDay].HeaderText = DayName + "\r\n" + "Total = " + DayTime;
                tgvTasks.Columns[SelectedDay].HeaderText = DayTime.ToString();
            }
            return Exeeded;
        }
        /// <summary>
        /// Calculate total of working hours of the selected project and place it at the head of the project
        /// </summary>
        /// <param name="ProjectID">string ProjectID</param>
        /// <param name="NewValue">double NewValue</param>
        /// <param name="OldValue">double OldValue</param>
        /// <param name="SelectedDay">int SelectedDay</param>
        /// <returns>bool Exceeds</returns>
        private bool CalculateProjectHeader(string ProjectID, double NewValue, double OldValue, int SelectedDay)
        {
            bool Exceeds = false;
            string HeaderValue = tgvTasks.Columns[SelectedDay].HeaderText;
            //double HeadVal = double.Parse(HeaderValue.Substring(HeaderValue.LastIndexOf("\r\n") + 10, HeaderValue.Length - HeaderValue.LastIndexOf("\r\n") - 10));
            double HeadVal = double.Parse(HeaderValue);

            for (int g = 0; g < tgvTasks.Rows.Count; g++)
            {
                if (tgvTasks[1, g].Value.ToString() == ProjectID)
                {
                    if (!(NewValue - OldValue + HeadVal <= 24))
                    {
                        Exceeds = true;
                        break;
                    }
                    else
                    {
                        if (tgvTasks[SelectedDay, g].Value.ToString() == "")
                            tgvTasks[SelectedDay, g].Value = "0";
                        tgvTasks[SelectedDay, g].Value = Math.Round(double.Parse(tgvTasks[SelectedDay, g].Value.ToString()) + NewValue - OldValue, 2);
                        if (tgvTasks[SelectedDay, g].Value.ToString().Trim() == "0")
                            tgvTasks[SelectedDay, g].Value = "";
                        else if (double.Parse(tgvTasks[SelectedDay, g].Value.ToString().Trim()) < 0)
                            tgvTasks[SelectedDay, g].Value = "";
                        Exceeds = false;
                        break;
                    }
                }
            }
            return Exceeds;
        }
        /// <summary>
        /// Calculate time of the selected resposiblity and place it at the head of the responsibilty
        /// </summary>
        /// <param name="ResponsibiltyID">string ResponsibiltyID</param>
        /// <param name="NewValue">double OldValue</param>
        /// <param name="OldValue">double NewValue</param>
        /// <param name="SelectedDay">int SelectedDay</param>
        /// <returns>bool Exceeds</returns>
        private bool CalculateResponsibiltyHeader(string ResponsibiltyID, double NewValue, double OldValue, int SelectedDay)
        {
            string HeaderValue = tgvTasks.Columns[SelectedDay].HeaderText;
            //double HeadVal = double.Parse(HeaderValue.Substring(HeaderValue.LastIndexOf("\r\n")+10, HeaderValue.Length  - HeaderValue.LastIndexOf("\r\n")-10));
            double HeadVal = double.Parse(HeaderValue);
            bool Exceeds = false;
            for (int g = 0; g < tgvTasks.Rows.Count; g++)
            {
                if (tgvTasks[1, g].Value.ToString() == ResponsibiltyID)
                {
                    if (!(NewValue - OldValue + HeadVal <= 24))
                    {
                        Exceeds = true;
                        break;
                    }
                    else
                    {
                        Exceeds = false;
                        if (tgvTasks[SelectedDay, g].Value.ToString() == "")
                            tgvTasks[SelectedDay, g].Value = "0";
                        tgvTasks[SelectedDay, g].Value = Math.Round(double.Parse(tgvTasks[SelectedDay, g].Value.ToString()) + NewValue - OldValue, 2);
                        if (tgvTasks[SelectedDay, g].Value.ToString().Trim() == "0")
                            tgvTasks[SelectedDay, g].Value = "";
                        else if (double.Parse(tgvTasks[SelectedDay, g].Value.ToString().Trim()) < 0)
                            tgvTasks[SelectedDay, g].Value = "";
                        break;
                    }
                }
            }
            return Exceeds;
        }

        ArrayList ExpandedNodes = new ArrayList();
        private void tgvTasks_NodeExpanding(object sender, ExpandingEventArgs e)
        {
            if (!(ExpandedNodes.Contains(e.Node.Cells[1].Value.ToString())))
                ExpandedNodes.Add(e.Node.Cells[1].Value.ToString());
        }
        private void tgvTasks_NodeCollapsing(object sender, CollapsingEventArgs e)
        {
            ExpandedNodes.Remove(e.Node.Cells[1].Value.ToString());
            UncheckCollapsedNode(e.Node);

        }
        private void UncheckCollapsedNode(TreeGridNode ParentNode)
        {
            if (ParentNode.Nodes.Count > 0)
            {
                for (int i = 0; i < ParentNode.Nodes.Count; i++)
                {
                    if (ParentNode.Nodes[i].Cells[10].ValueType.ToString() == "System.Boolean")
                    {
                        ((DataGridViewCheckBoxCell)ParentNode.Nodes[i].Cells[10]).Value = false;
                        SelectedTask = 0;
                        btnSave.Enabled = false;
                    }
                    if (ParentNode.Nodes[i].Nodes.Count > 0)
                    {
                        for (int j = 0; j < ParentNode.Nodes[i].Nodes.Count; j++)
                        {
                            if (ParentNode.Nodes[i].Nodes[j].Cells[10].ValueType.ToString() == "System.Boolean")
                            {
                                ((DataGridViewCheckBoxCell)ParentNode.Nodes[i].Nodes[j].Cells[10]).Value = false;
                                SelectedTask = 0;
                                btnSave.Enabled = false;
                            }
                        }
                    }
                }
            }
        }
        //Buttons Events to change Colors when moving over it
        //Button Update Acc.
        private void btnUpdate_MouseMove(object sender, MouseEventArgs e)
        {
            btnUpdate.BackColor = Color.FromArgb(255, 204, 153);
        }
        private void btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.White;
        }
        private void btnUpdate_MouseClick(object sender, MouseEventArgs e)
        {
            btnUpdate.BackColor = Color.FromArgb(255, 153, 0);
        }
        //Button Sign In
        private void btnSignIn_MouseMove(object sender, MouseEventArgs e)
        {
            btnSignIn.BackColor = Color.FromArgb(255, 204, 153);
        }
        private void btnSignIn_MouseLeave(object sender, EventArgs e)
        {
            btnSignIn.BackColor = Color.White;
        }
        private void btnSignIn_MouseClick(object sender, MouseEventArgs e)
        {
            btnSignIn.BackColor = Color.FromArgb(255, 153, 0);
        }
        //Help Button
        private void btnHelp_MouseLeave(object sender, EventArgs e)
        {
            btnHelp.BackColor = Color.White;
        }

        private void btnHelp_MouseMove(object sender, MouseEventArgs e)
        {
            btnHelp.BackColor = Color.FromArgb(255, 204, 153);
        }

        private void btnSignIn_MouseUp(object sender, MouseEventArgs e)
        {
            btnHelp.BackColor = Color.FromArgb(255, 153, 0);
        }

        ///////////////////////////////////////////////////
        #region Old Upgrade Approach
        private bool LoadSavedDataSet()
        {
            AccSet.Clear();
            AccSet.ReadXml(GetClientPath());
            tgvTasks.Nodes.Clear();
            return true;
        }
        private void UpdateServiceTimer_Tick(object sender, EventArgs e)
        {
            if (DynamicUpdate.GetUpdateMode(GetFileServer()) == "C")
            {
                UpdateServiceTimer.Stop();
                //SaveClientDataSet(AccSet);
                //MessageBox.Show("Application will be closed now during to upgrade status", "Upgrad AccountabilityNotepad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DynamicUpdate.RunUpdater(Application.StartupPath);
                FormClosingEventArgs Cls = new FormClosingEventArgs(CloseReason.UserClosing, false);
                object Sndr = "Close without alert";
                LoginForm_FormClosing(Sndr, Cls);
            }
        }
        //public bool SaveClientDataSet(DataSet CurrentUserDataSet)
        //{
        //    bool Succeed = true;
        //    try
        //    {
        //        if (CurrentUserDataSet != null)
        //        {
        //            SaveUserData();
        //            CurrentUserDataSet.WriteXml(GetClientPath());

        //        }
        //    }
        //    catch (Exception Ecp)
        //    {
        //        string ErrMsg = Ecp.Message;
        //        Succeed = false;
        //    }
        //    return Succeed;
        //}
        private string GetClientPath()
        {
            string CPath = Environment.SystemDirectory.Substring(0, 1) + @":\Documents and Settings\" + Environment.UserName + @"\ClientData.XML";
            return CPath;
        }
        //private void SaveUserData()
        //{
        //    string Timer = "_";
        //    if (txtTimer.Text != "00:00:00")
        //    {
        //        Timer = txtTimer.Text;
        //    }
        //    string[] Lines = new string[2];
        //    string EncText = UsrNam + "||***|| " + Paswrd;
        //    EncText = EncryptText(EncText);
        //    string CPath = Environment.SystemDirectory.Substring(0, 1) + @":\Documents and Settings\" + Environment.UserName + @"\UserData.TXT";
        //    Lines[0] = EncText;
        //    Lines[1] = Timer;
        //    File.WriteAllLines(CPath, Lines);
        //    //File.WriteAllText(CPath, EncText);
        //}
        //private void LoadUserData()
        //{
        //    string CPath = Environment.SystemDirectory.Substring(0, 1) + @":\Documents and Settings\" + Environment.UserName + @"\UserData.TXT";
        //    //string DecText = File.ReadAllText(CPath);
        //    string[] Lines = File.ReadAllLines(CPath);
        //    string DecText = Lines[0];
        //    string Timer = Lines[1];
        //    string EncText = DecryptText(DecText);
        //    File.Delete(CPath);
        //    UsrNam = EncText.Substring(0, EncText.IndexOf("||***|| "));
        //    Paswrd = EncText.Substring(EncText.IndexOf("||***|| ") + 8, EncText.Length - (EncText.IndexOf("||***|| ") + 8));
        //    //PreSavedUser = true;
        //    btnSignIn_Click(null, null);
        //    if (Timer != "_")
        //        SetSavedTimer(Timer);
        //}
        //public void SaveUsersList(ArrayList UserList)
        //{
        //    string UserFilePath = Environment.SystemDirectory.Substring(0, 1) + @":\Documents and Settings\" + Environment.UserName + @"\UsersList.TXT";
        //    BinaryFormatter ArrayFormat = new BinaryFormatter();
        //    MemoryStream ArrayStream = new MemoryStream();
        //    ArrayFormat.Serialize(ArrayStream, UserList);
        //    File.WriteAllBytes(UserFilePath, ArrayStream.ToArray());
        //}
        private string GetFileServer()
        {
            string FileServerName = "";
            string FilePath = Application.StartupPath + @"\AccountabilityNotePad.exe.config";
            XmlDocument AppFile = new XmlDocument();
            AppFile.Load(FilePath);
            XmlNode AccSetting = AppFile.ChildNodes[1].ChildNodes[1].ChildNodes[0];
            for (int i = 0; i < AccSetting.ChildNodes.Count; i++)
            {
                if (AccSetting.ChildNodes[i].Attributes["name"].Value.Trim() == "FileAccessServer")
                {
                    FileServerName = AccSetting.ChildNodes[i].ChildNodes[0].InnerXml;
                    break;
                }
            }
            return FileServerName;
        }
        private void SetSavedTimer(string SavedTime)
        {
            txtTimer.Text = SavedTime;
            btnPause.Text = "Continue";
            btnStart.Text = "Stop";
            btnPause.Visible = true;
            Hours = int.Parse(SavedTime.Substring(0, 2));
            Minutes = int.Parse(SavedTime.Substring(3, 2));
            Seconds = int.Parse(SavedTime.Substring(6, 2));
            ModifyTime();
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            //SaveClientDataSet(AccSet);
        }
        #endregion

        #region MFG Code
        private void clndrTaskDate_DateSelected(object sender, DateRangeEventArgs e)
        {
            checkMFGDataSaved();
            if (MFGDataSaved)
            {
                clndrTaskDate.Visible = false;
                TodayDate = e.Start.Date;
                updateEmpLblInfo();
                updateMFGDSheet();
                updateTotalHours();
            }
            else
            {
                DialogResult MyDlg = MessageBox.Show("Unsaved data will be lost, Do you want to update your accountability?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (MyDlg == DialogResult.Yes)
                {
                    updateMFGAccDB();
                    clndrTaskDate.Visible = false;
                    TodayDate = e.Start.Date;
                    updateEmpLblInfo();
                    updateMFGDSheet();
                    updateTotalHours();
                }
                else if (MyDlg == DialogResult.No)
                {
                    clndrTaskDate.Visible = false;
                    TodayDate = e.Start.Date;
                    updateEmpLblInfo();
                    updateMFGDSheet();
                    updateTotalHours();
                }
                else if (MyDlg == DialogResult.Cancel)
                {
                    clndrTaskDate.SetDate(TodayDate);
                    cmbEmpName.SelectedIndex = currentEmpIndex;
                }
            }
        }

        private void clndrTaskDate_MouseLeave(object sender, EventArgs e)
        {
            clndrTaskDate.Visible = false;
        }

        private void imgCalender_Click(object sender, EventArgs e)
        {
            clndrTaskDate.Visible = true;
        }

        private void cmbEmpName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!undoEmpChange)
            {
                checkMFGDataSaved();
                if (MFGDataSaved)
                {
                    currentEmpIndex = cmbEmpName.SelectedIndex;
                    TodayDate.ToString();
                    updateEmpLblInfo();
                    updateMFGDSheet();
                    updateTotalHours();
                }
                else
                {
                    DialogResult MyDlg = MessageBox.Show("Unsaved data will be lost, Do you want to update your accountability?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (MyDlg == DialogResult.Yes)
                    {
                        updateMFGAccDB();
                        currentEmpIndex = cmbEmpName.SelectedIndex;
                        TodayDate.ToString();
                        updateEmpLblInfo();
                        updateMFGDSheet();
                        updateTotalHours();
                    }
                    else if (MyDlg == DialogResult.No)
                    {
                        currentEmpIndex = cmbEmpName.SelectedIndex;
                        TodayDate.ToString();
                        updateEmpLblInfo();
                        updateMFGDSheet();
                        updateTotalHours();
                    }
                    else if (MyDlg == DialogResult.Cancel)
                    {
                        undoEmpChange = true;
                        cmbEmpName.SelectedIndex = currentEmpIndex;
                    }
                }
            }
            else
                undoEmpChange = false;
        }

        /// <summary>
        /// Initialize MFG panel, used every time the user switch to MFG mode
        /// </summary>
        private void showMFGPanel()
        {
            pnlMainFrm.Enabled = false;
            pnlMainFrm.Visible = false;
            pnlMFG.Enabled = true;
            pnlMFG.Visible = true;

            ((ToolStripMenuItem)msFile.Items["viewToolStripMenuItem"]).DropDownItems["mfgSheetToolStripMenuItem"].Enabled = false;
            ((ToolStripMenuItem)msFile.Items["viewToolStripMenuItem"]).DropDownItems["accountabilitySheetToolStripMenuItem"].Enabled = true;

            clndrTaskDate.SelectionStart = TodayDate;
            currentEmpIndex = 0;
            cmbEmpName.SelectedIndex = 0;
            updateEmpLblInfo();
            this.Width = 782;
            this.Height = 520;
            Point HelpPnt = new Point(pnlMFG.Width - 25, 0);
            btnHelp.Location = HelpPnt;
        }

        /// <summary>
        /// Initialize MFG Mode, this function will be called one time during form_load event if a MFG-user 
        /// has logged in.
        /// </summary>
        private void initMFGMode()
        {
            ((ToolStripMenuItem)msFile.Items["viewToolStripMenuItem"]).DropDownItems["toolStripSeparator1"].Visible = true;
            ((ToolStripMenuItem)msFile.Items["viewToolStripMenuItem"]).DropDownItems["mfgSheetToolStripMenuItem"].Visible = true;
            ((ToolStripMenuItem)msFile.Items["viewToolStripMenuItem"]).DropDownItems["accountabilitySheetToolStripMenuItem"].Visible = true;
            ((ToolStripMenuItem)msFile.Items["viewToolStripMenuItem"]).DropDownItems["toolStripSeparator2"].Visible = true;
            msFile.Items["operationsToolStripMenuItem"].Visible = true;

            ConfigWnd.grStartMode.Visible = true;
            Point pntLocation = ConfigWnd.btnSaveAllChanges.Location;
            pntLocation.Y = 259;
            ConfigWnd.btnSaveAllChanges.Location = pntLocation;
            pntLocation = ConfigWnd.btnClosURL.Location;
            pntLocation.Y = 259;
            ConfigWnd.btnClosURL.Location = pntLocation;
            ConfigWnd.Height = 322;
            TodayDate = DateTime.Today;

            updateEmpNamesInfo();
            setupMFGSheetLayout();
        }

        /// <summary>
        /// Hide MFG panel
        /// </summary>
        private void hideMFGPanel()
        {
            pnlMainFrm.Enabled = true;
            pnlMainFrm.Visible = true;
            pnlMFG.Enabled = false;
            pnlMFG.Visible = false;
            ((ToolStripMenuItem)msFile.Items["viewToolStripMenuItem"]).DropDownItems["mfgSheetToolStripMenuItem"].Enabled = true;
            ((ToolStripMenuItem)msFile.Items["viewToolStripMenuItem"]).DropDownItems["accountabilitySheetToolStripMenuItem"].Enabled = false;
            this.Width = 342;
            this.Height = 730;
            Point HelpPnt = new Point(pnlLogin.Width - 25, 0);
            btnHelp.Location = HelpPnt;
        }

        /// <summary>
        /// Exit MFG mode, this function will be called one time during sign-out, so that if a non-MFG user 
        /// signed-in again before closing the application then he will not be able to access MFG mode.
        /// </summary>
        private void exitMFGMode()
        {
            ((ToolStripMenuItem)msFile.Items["viewToolStripMenuItem"]).DropDownItems["toolStripSeparator1"].Visible = false;
            ((ToolStripMenuItem)msFile.Items["viewToolStripMenuItem"]).DropDownItems["mfgSheetToolStripMenuItem"].Visible = false;
            ((ToolStripMenuItem)msFile.Items["viewToolStripMenuItem"]).DropDownItems["accountabilitySheetToolStripMenuItem"].Visible = false;
            ((ToolStripMenuItem)msFile.Items["viewToolStripMenuItem"]).DropDownItems["toolStripSeparator2"].Visible = false;
            msFile.Items["operationsToolStripMenuItem"].Visible = false;

            ConfigWnd.grStartMode.Visible = false;
            Point pntLocation = ConfigWnd.btnSaveAllChanges.Location;
            pntLocation.Y = 176;
            ConfigWnd.btnSaveAllChanges.Location = pntLocation;
            pntLocation = ConfigWnd.btnClosURL.Location;
            pntLocation.Y = 176;
            ConfigWnd.btnClosURL.Location = pntLocation;
            ConfigWnd.Height = 244;
            cmbEmpName.Items.Clear();
            dgWorkerSheet.Columns.Clear();
            dsMFGt = null;
        }

        /// <summary>
        /// Update employees names in combo-box
        /// </summary>
        private void updateEmpNamesInfo()
        {
            MFGAccWS.AuthHeader MFGHead = new AccountabilityNotePad.MFGAccWS.AuthHeader();
            MFGHead.Token = MyToken;
            MFGAccWS.MFGAccountability MFGAcc = new AccountabilityNotePad.MFGAccWS.MFGAccountability();
            MFGAcc.AuthHeaderValue = MFGHead;
            MFGAcc.Url = wsUrl + wsUrlPart1 + "MFGAccountability.asmx";

            DataSet dsMFGEmps = MFGAcc.GetAllMFGEmployees();

            foreach (DataRow empName in dsMFGEmps.Tables[0].Rows)
                cmbEmpName.Items.Add(empName.ItemArray[1].ToString());
        }

        /// <summary>
        /// Update employee label info
        /// </summary>
        private void updateEmpLblInfo()
        {
            string strCurrentEmp = cmbEmpName.SelectedItem.ToString();
            string strTemp = "";
            bool isFirstSpace = false;
            for (int i = 0; i < strCurrentEmp.Length; i++)
            {
                if (!isFirstSpace)
                {
                    if (strCurrentEmp[i] == ' ')
                    {
                        strTemp += " ";
                        isFirstSpace = true;
                    }
                    else
                        strTemp += strCurrentEmp[i];
                }
                else
                {
                    if (strCurrentEmp[i] != ' ')
                    {
                        isFirstSpace = false;
                        strTemp += strCurrentEmp[i];
                    }
                }
                
            }
            lblWorkerInfo.Text = strTemp;
            lblEmpTaskDate.Left = lblWorkerInfo.Left + lblWorkerInfo.Width;
            lblEmpTaskDate.Text = " 's Tasks at " + TodayDate.ToShortDateString();
        }

        /// <summary>
        /// Setup layout of MFG sheet datagridview for the first time
        /// </summary>
        private void setupMFGSheetLayout()
        {
            dgWorkerSheet.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn colTrvNumber = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colCompnay = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colClipMember = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colPartClass = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colPartNumber = new DataGridViewTextBoxColumn();
            DataGridViewComboBoxColumn colOperation = new DataGridViewComboBoxColumn();
            DataGridViewTextBoxColumn colQuantity = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colHours = new DataGridViewTextBoxColumn();
            dgWorkerSheet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            colTrvNumber,
            colCompnay,
            colClipMember,
            colPartClass,
            colPartNumber,
            colOperation,
            colQuantity,
            colHours});

            colTrvNumber.DataPropertyName = "TrvNumber";
            colTrvNumber.HeaderText = "Traveler";
            colTrvNumber.Name = "colTrvNumber";
            colTrvNumber.ReadOnly = true;
            colTrvNumber.Width = 66;
            colTrvNumber.SortMode = DataGridViewColumnSortMode.Automatic;

            colCompnay.DataPropertyName = "Compnay";
            colCompnay.HeaderText = "Company";
            colCompnay.Name = "colCompnay";
            colCompnay.ReadOnly = true;
            colCompnay.Width = 130;
            colCompnay.SortMode = DataGridViewColumnSortMode.Automatic;

            colClipMember.DataPropertyName = "ClipMember";
            colClipMember.HeaderText = "Clip/Member";
            colClipMember.Name = "colClipMember";
            colClipMember.ReadOnly = true;
            colClipMember.Width = 80;
            colClipMember.SortMode = DataGridViewColumnSortMode.Automatic;

            colPartClass.DataPropertyName = "PartClass";
            colPartClass.HeaderText = "Part Class";
            colPartClass.Name = "colPartClass";
            colPartClass.ReadOnly = true;
            colPartClass.Width = 80;
            colPartClass.SortMode = DataGridViewColumnSortMode.Automatic;

            colPartNumber.DataPropertyName = "PartNumber";
            colPartNumber.HeaderText = "Part Number";
            colPartNumber.Name = "colPartNumber";
            colPartNumber.ReadOnly = true;
            colPartNumber.Width = 90;
            colPartNumber.SortMode = DataGridViewColumnSortMode.Automatic;

            colOperation.DataPropertyName = "operation";
            colOperation.DisplayMember = "operation";
            colOperation.ValueMember = "operation";
            colOperation.HeaderText = "Operations";
            colOperation.Name = "colOperation";
            colOperation.Width = 150;
            colOperation.SortMode = DataGridViewColumnSortMode.NotSortable;

            colQuantity.DataPropertyName = "Quantity";
            colQuantity.HeaderText = "Quantity";
            colQuantity.Name = "colQuantity";
            colQuantity.Width = 66;
            colQuantity.SortMode = DataGridViewColumnSortMode.NotSortable;

            colHours.DataPropertyName = "Hours";
            colHours.HeaderText = "Hours";
            colHours.Name = "colHours";
            colHours.Width = 65;
            colHours.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        /// <summary>
        /// Convert a multi-type columns dataset to a string-only columns dataset
        /// </summary>
        /// <param name="inDataSet">Input dataset that will be converted</param>
        /// <returns>A string-only columns dataset</returns>
        private DataSet convertToStringDS4DGV(DataSet inDataSet)
        {
            DataTable dtTmp = new DataTable(inDataSet.Tables[0].TableName);
            dtTmp.Columns.Add("TrvID", typeof(string));
            dtTmp.Columns.Add("TrvNumber", typeof(string));
            dtTmp.Columns.Add("Compnay", typeof(string));
            dtTmp.Columns.Add("ClipMember", typeof(string));
            dtTmp.Columns.Add("PartClass", typeof(string));
            dtTmp.Columns.Add("PartNumber", typeof(string));
            dtTmp.Columns.Add("Operation", typeof(string));
            dtTmp.Columns.Add("Quantity", typeof(string));
            dtTmp.Columns.Add("Hours", typeof(string));
            dtTmp.Columns.Add("ContactID", typeof(string));
            dtTmp.Columns.Add("TaskDate", typeof(string));
            dtTmp.Columns.Add("EnteredBy", typeof(string));

            if (inDataSet.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < inDataSet.Tables[0].Rows.Count; i++)
                {
                    dtTmp.Rows.InsertAt(dtTmp.NewRow(), i);
                    for (int j = 0; j < 12; j++)
                        dtTmp.Rows[i][j] = inDataSet.Tables[0].Rows[i][j].ToString();
                }
            }

            //foreach (DataColumn dtc in dtTmp.Columns)
            //    dtc.ReadOnly = dtc.ColumnName == "TrvNumber" || dtc.ColumnName == "Compnay" || dtc.ColumnName == "ClipMember" || dtc.ColumnName == "PartClass" || dtc.ColumnName == "PartNumber";

            DataSet dsOut = new DataSet();
            dsOut.Tables.Add(dtTmp);
            dsOut.AcceptChanges();
            return dsOut;
        }

        /// <summary>
        /// Convert a one column dataset to a string-only column dataset
        /// </summary>
        /// <param name="inDataSet">Input dataset that will be converted</param>
        /// <returns>A string-only column dataset</returns>
        private DataSet convertToStringDS4Opt(DataSet inDataSet)
        {
            DataTable dtTmp = new DataTable(inDataSet.Tables[0].TableName);
            dtTmp.Columns.Add("Operation", typeof(string));

            if (inDataSet.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < inDataSet.Tables[0].Rows.Count; i++)
                {
                    dtTmp.Rows.InsertAt(dtTmp.NewRow(), i);
                    dtTmp.Rows[i][0] = inDataSet.Tables[0].Rows[i][0].ToString();
                }
            }

            DataSet dsOut = new DataSet();
            dsOut.Tables.Add(dtTmp);
            dsOut.AcceptChanges();
            return dsOut;
        }

        /// <summary>
        /// Update MFG data grid with valid information sheet
        /// </summary>
        private void updateMFGDSheet()
        {
            try
            {
                MFGAccWS.AuthHeader MFGHead = new AccountabilityNotePad.MFGAccWS.AuthHeader();
                MFGHead.Token = MyToken;
                MFGAccWS.MFGAccountability MFGAcc = new AccountabilityNotePad.MFGAccWS.MFGAccountability();
                MFGAcc.AuthHeaderValue = MFGHead;
                MFGAcc.Url = wsUrl + wsUrlPart1 + "MFGAccountability.asmx";

                // Get data that will be displayed in all datagrid columns except "Operatios"
                DataSet dsMFGEmps = MFGAcc.GetAllMFGEmployees();
                //dsMFGt = MFGAcc.ListEmployeeMFGTasks((int)dsMFGEmps.Tables[0].Rows[cmbEmpName.SelectedIndex].ItemArray[0], TodayDate);
                dsMFGt = convertToStringDS4DGV(MFGAcc.ListEmployeeMFGTasks((int)dsMFGEmps.Tables[0].Rows[cmbEmpName.SelectedIndex].ItemArray[0], TodayDate));

                // Bind datagrid to dataset
                dgWorkerSheet.DataSource = dsMFGt.Tables[0];

                // Get data that will be displayed in "Operatios" column
                //DataSet dsOperation = ExecuteDataset(foxConn, "SELECT DISTINCT operation FROM a_92 WHERE (operation NOT like ' ')");
                FoxProService.FoxProSrv foxSrv = new AccountabilityNotePad.FoxProService.FoxProSrv();
                DataSet dsOperation = foxSrv.GetAllOperations();
                DataRow dtr0 = dsOperation.Tables[0].NewRow();
                DataRow dtr1 = dsOperation.Tables[0].NewRow();
                dtr0[0] = "Select an Operation..";
                dtr1[0] = "Add new Operation..";
                dsOperation.Tables[0].Rows.InsertAt(dtr0, 0);
                dsOperation.Tables[0].Rows.InsertAt(dtr1, 0);

                // Bind ComboBox-Column to dataset
                ((DataGridViewComboBoxColumn)dgWorkerSheet.Columns["colOperation"]).DataSource = dsOperation.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Update total hours label with calculated total hours
        /// </summary>
        private void updateTotalHours()
        {
            lblTotHours.Text = "Total Hours: " + getTotalHours().ToString();
        }

        /// <summary>
        /// Calculate Total hours from all rows
        /// </summary>
        /// <returns></returns>
        private decimal getTotalHours()
        {
            decimal totalMFGHours = 0;
            foreach (DataGridViewRow dtr in dgWorkerSheet.Rows)
            {
                if (dtr.Cells[7].Value.ToString() == "")
                    continue;
                totalMFGHours += decimal.Parse(dtr.Cells[7].Value.ToString());
            }
            return totalMFGHours;
        }

        /// <summary>
        /// Update MFG tables in accountability database
        /// </summary>
        /// <returns>Indecate wther update operation has done successfully or not</returns>
        private bool updateMFGAccDB()
        {
            bool ok = false;
            try
            {
                MFGAccWS.AuthHeader MFGHead = new AccountabilityNotePad.MFGAccWS.AuthHeader();
                MFGHead.Token = MyToken;
                MFGAccWS.MFGAccountability MFGAcc = new AccountabilityNotePad.MFGAccWS.MFGAccountability();
                MFGAcc.AuthHeaderValue = MFGHead;
                MFGAcc.Url = wsUrl + wsUrlPart1 + "MFGAccountability.asmx";
                
                // Search for Tasks with zero hours to delete
                bool hasZero = false;
                bool hasNoOp = false;
                bool[] zeros = new bool[dsMFGt.Tables[0].Rows.Count];

                for (int i = 0; i < dsMFGt.Tables[0].Rows.Count; i++)
                {
                    if (dsMFGt.Tables[0].Rows[i]["TrvNumber"].ToString() == "")
                    {
                        dsMFGt.Tables[0].Rows.Remove(dsMFGt.Tables[0].Rows[i]);
                        i--;
                        continue;
                    }
                }
                for (int i = 0; i < dsMFGt.Tables[0].Rows.Count; i++)
                {
                    zeros[i] = false;
                    if (dsMFGt.Tables[0].Rows[i]["Hours"].ToString() == "0")
                    {
                        hasZero = true;
                        zeros[i] = true;
                    }
                }
                if (hasZero)
                {
                    if (MessageBox.Show("Are you sure you want to delete tasks with 0 hours values?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                        return false;
                }
                for (int i = 0; i < dsMFGt.Tables[0].Rows.Count; i++)
                {
                    if (!zeros[i])
                    {
                        if (dsMFGt.Tables[0].Rows[i]["operation"].ToString() == "Add new Operation.." || dsMFGt.Tables[0].Rows[i]["operation"].ToString() == "Select an Operation..")
                        {
                            hasNoOp = true;
                            break;
                        }
                    }
                }
                if (hasNoOp)
                    MessageBox.Show("You should select an operation.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    for (int i = 0; i < dsMFGt.Tables[0].Rows.Count; i++)
                    {
                        if (zeros[i])
                            dsMFGt.Tables[0].Rows[i].Delete();
                    }
                    dgWorkerSheet.Columns[0].ReadOnly = true;
                    MFGAcc.SaveMFGTasksSheet(dsMFGt);
                    updateMFGDSheet();
                    MessageBox.Show("Data has been saved successfully", "Saved Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ok = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                ok = false;
            }
            return ok;
        }

        /// <summary>
        /// Refresh boolean value stored in 'MFGDataSaved'
        /// </summary>
        private void checkMFGDataSaved()
        {
            MFGDataSaved = true;

            if (cmbEmpName.SelectedIndex < 0 || dsMFGt == null || dsMFGt.Tables[0].Rows.Count == 0)
                return;

            dgWorkerSheet.EndEdit();
            MFGAccWS.AuthHeader MFGHead = new AccountabilityNotePad.MFGAccWS.AuthHeader();
            MFGHead.Token = MyToken;
            MFGAccWS.MFGAccountability MFGAcc = new AccountabilityNotePad.MFGAccWS.MFGAccountability();
            MFGAcc.AuthHeaderValue = MFGHead;
            MFGAcc.Url = wsUrl + wsUrlPart1 + "MFGAccountability.asmx";

            // Get data that will be displayed in datagrid
            DataSet dsMFGEmps = MFGAcc.GetAllMFGEmployees();
            
            dsLocalMFGt = MFGAcc.ListEmployeeMFGTasks((int)dsMFGEmps.Tables[0].Rows[currentEmpIndex].ItemArray[0], TodayDate);

            if (dsLocalMFGt.Tables[0].Columns.Count != dsMFGt.Tables[0].Columns.Count)
                MFGDataSaved = false;
            if (dsLocalMFGt.Tables[0].Rows.Count != dsMFGt.Tables[0].Rows.Count)
                MFGDataSaved = false;
            for (int i = 0; i < dsLocalMFGt.Tables[0].Columns.Count; i++)
            {
                for (int j = 0; j < dsLocalMFGt.Tables[0].Rows.Count; j++)
                {
                    if (dsLocalMFGt.Tables[0].Rows[j][i].ToString() != dsMFGt.Tables[0].Rows[j][i].ToString())
                    {
                        MFGDataSaved = false;
                        break;
                    }
                }
            }
        }

        private void showWarnMessege(string msgText, int msgInterval)
        {
            //MessageBox.Show(msgText, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void operationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Operation frmOperation = new Operation();
            frmOperation.ShowDialog();
        }

        private void mfgSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showMFGPanel();
        }

        private void accountabilitySheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideMFGPanel();
        }

        private void btnUpdateAccMFG_Click(object sender, EventArgs e)
        {
            updateMFGAccDB();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            bool newTaskExist = false;
            if (dgWorkerSheet.Rows.Count > 0 && dgWorkerSheet[0, dgWorkerSheet.Rows.Count - 1].Value.ToString() == "")
                newTaskExist = true;

            if (!newTaskExist)
            {
                dsMFGt.Tables[0].Rows.InsertAt(dsMFGt.Tables[0].NewRow(), dsMFGt.Tables[0].Rows.Count);
                dgWorkerSheet.Select();
                dgWorkerSheet.Rows[dgWorkerSheet.Rows.Count - 1].ReadOnly = true;
                dgWorkerSheet["colTrvNumber", dgWorkerSheet.Rows.Count - 1].ReadOnly = false;
                dgWorkerSheet.Rows[dgWorkerSheet.Rows.Count - 1].Cells["colTrvNumber"].Selected = true;
                dgWorkerSheet.Rows[dgWorkerSheet.Rows.Count - 1].Cells["colTrvNumber"].ToolTipText = "Enter the number of new traveler..";
            }
            else
                MessageBox.Show("There is a new row already exist!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public DataSet ExecuteDataset(string connectionString, string CommandText, params object[] parameterValues)
        {
            //Create dataset to be loaded with return results from adapter
            DataSet MyDS = new DataSet();

            //if we receive parameter values, we need to figure out where they go
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                using (OleDbConnection MyCon = new OleDbConnection(connectionString))
                {
                    //Create New ODBC command to execute command
                    OleDbCommand MyCmd = new OleDbCommand();
                    MyCmd.CommandText = CommandText;
                    MyCmd.Connection = MyCon;
                    MyCon.Open();

                    //Add Parameters to ODBC command
                    for (int p = 0; p < parameterValues.Length; p++)
                    {
                        MyCmd.Parameters.Add((OleDbParameter)parameterValues[p]);
                    }

                    //Creates new adapter to execute the ODBC command with parameters
                    OleDbDataAdapter MyAdapt = new OleDbDataAdapter(MyCmd);

                    //Fill DataSet with results from Adapter
                    MyAdapt.Fill(MyDS);

                    // detach the SqlParameters from the command object, so they can be used again.
                    MyCmd.Parameters.Clear();
                }
            }
            else
            {
                using (OleDbConnection MyCon = new OleDbConnection(connectionString))
                {
                    //Create New ODBC command to execute command
                    OleDbCommand MyCmd = new OleDbCommand();
                    MyCmd.CommandText = CommandText;
                    MyCmd.Connection = MyCon;
                    MyCon.Open();

                    //Creates new adapter to execute the ODBC command with parameters
                    OleDbDataAdapter MyAdapt = new OleDbDataAdapter(MyCmd);

                    //Fill DataSet with results from Adapter
                    MyAdapt.Fill(MyDS);
                }
            }

            //Return DataSet
            return MyDS;
        }

        private void dgWorkerSheet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                long trvNumber;

                if (long.TryParse(dgWorkerSheet[e.ColumnIndex, e.RowIndex].Value.ToString(), out trvNumber))
                {
                    string cautionMsg = "";
                    string clipMember = "";
                   // string strSQL = "SELECT tsn_no, stock_no, retailer AS Company, type AS PartClass, part_no AS PartNumber FROM a_88 WHERE (wo_no = " + trvNumber.ToString() + ")";
                    //DataSet ds88 = ExecuteDataset(foxConn, strSQL);
                    string strSQL;
                    FoxProService.FoxProSrv foxSrv = new AccountabilityNotePad.FoxProService.FoxProSrv();   
                    DataSet ds88 = foxSrv.GetTravelerData(trvNumber.ToString());

                    if (ds88.Tables[0].Rows.Count > 0)
                    {
                        for(int i = 2; i < dsMFGt.Tables[0].Columns.Count; i++)
                            dsMFGt.Tables[0].Rows[e.RowIndex][i] = DBNull.Value;

                        if ((decimal)ds88.Tables[0].Rows[0]["tsn_no"] != 0)
                        {
                            //strSQL = "SELECT rolled_l AS ClipMember FROM a_77 WHERE (tsn_no = " + ds88.Tables[0].Rows[0]["tsn_no"] + ")";
                            //DataSet ds77 = ExecuteDataset(foxConn, strSQL);
                            DataSet ds77 = foxSrv.GetTrvPartTypeInTable90( ds88.Tables[0].Rows[0]["tsn_no"].ToString() );

                            if (ds77.Tables[0].Rows.Count != 0)
                            {
                                if ((bool)ds77.Tables[0].Rows[0]["clipmember"])
                                    clipMember = "Member";
                                else
                                    clipMember = "Clip";
                            }
                            else
                                clipMember = "";
                        }
                        else
                        {
                            if ((decimal)ds88.Tables[0].Rows[0]["stock_no"] != 0)
                            {
                                //strSQL = "SELECT rolled_l AS ClipMember FROM a_90 WHERE (stock_no = " + ds88.Tables[0].Rows[0]["stock_no"] + ")";
                                //DataSet ds90 = ExecuteDataset(foxConn, strSQL);
                                DataSet ds90 = foxSrv.GetTrvPartTypeInTable90( ds88.Tables[0].Rows[0]["stock_no"].ToString() );

                                if (ds90.Tables[0].Rows.Count != 0)
                                {
                                    if ((bool)ds90.Tables[0].Rows[0]["clipmember"])
                                        clipMember = "Member";
                                    else
                                        clipMember = "Clip";
                                }
                                else
                                    clipMember = "";
                            }
                        }

                        //strSQL = "SELECT DISTINCT operation FROM a_92 WHERE (wo_no = " + trvNumber.ToString() + ")";
                        //DataSet ds92 = ExecuteDataset(foxConn, strSQL);
                        DataSet ds92 = foxSrv.GetTravelerOperation( trvNumber.ToString() );

                        string operation = "";
                        if (ds92.Tables[0].Rows.Count > 0)
                            operation = ds92.Tables[0].Rows[0]["operation"].ToString();
                        else
                        {
                            operation = "Select an Operation..";
                            cautionMsg = "Note: You have to select an operation in order to be able save the task.\n";
                        }

                        dgWorkerSheet.Rows[e.RowIndex].Cells["colCompnay"].Value = ds88.Tables[0].Rows[0]["company"];
                        dgWorkerSheet.Rows[e.RowIndex].Cells["colClipMember"].Value = clipMember;
                        dgWorkerSheet.Rows[e.RowIndex].Cells["colPartClass"].Value = ds88.Tables[0].Rows[0]["partclass"];
                        dgWorkerSheet.Rows[e.RowIndex].Cells["colPartNumber"].Value = ds88.Tables[0].Rows[0]["partnumber"];
                        dgWorkerSheet.Rows[e.RowIndex].Cells["colOperation"].Value = operation;

                        dgWorkerSheet.Rows[e.RowIndex].Cells["colOperation"].ReadOnly = false;
                        dgWorkerSheet.Rows[e.RowIndex].Cells["colQuantity"].ReadOnly = false;
                        dgWorkerSheet.Rows[e.RowIndex].Cells["colQuantity"].Value = 0;
                        dgWorkerSheet.Rows[e.RowIndex].Cells["colHours"].ReadOnly = false;
                        dgWorkerSheet.Rows[e.RowIndex].Cells["colHours"].Value = 0;
                        dgWorkerSheet.Rows[e.RowIndex].Cells["colHours"].Value = 0;
                        dsMFGt.Tables[0].Rows[e.RowIndex]["TaskDate"] = TodayDate;

                        MFGAccWS.AuthHeader MFGHead = new AccountabilityNotePad.MFGAccWS.AuthHeader();
                        MFGHead.Token = MyToken;
                        MFGAccWS.MFGAccountability MFGAcc = new AccountabilityNotePad.MFGAccWS.MFGAccountability();
                        MFGAcc.AuthHeaderValue = MFGHead;
                        MFGAcc.Url = wsUrl + wsUrlPart1 + "MFGAccountability.asmx";

                        DataSet dsMFGEmps = MFGAcc.GetAllMFGEmployees();
                        dsMFGt.Tables[0].Rows[e.RowIndex]["ContactID"] = (int)dsMFGEmps.Tables[0].Rows[cmbEmpName.SelectedIndex].ItemArray[0];
                        dsMFGt.Tables[0].Rows[e.RowIndex]["EnteredBy"] = LoggedUserID;
                        dsMFGt.Tables[0].Rows[e.RowIndex]["TrvID"] = DBNull.Value;

                        cautionMsg += "Note: You have to set a value greater than zero in HOURS cell in order to be able save the task.";
                        showWarnMessege(cautionMsg, 10);
                    }
                    else
                    {
                        for (int i = 0; i < dsMFGt.Tables[0].Columns.Count; i++)
                            dsMFGt.Tables[0].Rows[e.RowIndex][i] = DBNull.Value;
                        //showWarnMessege("Please enter a valid traveler number..", 3);
                        MessageBox.Show("Please enter a valid traveler number..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgWorkerSheet.Rows[e.RowIndex].Cells["colOperation"].ReadOnly = true;
                        dgWorkerSheet.Rows[e.RowIndex].Cells["colQuantity"].ReadOnly = true;
                        dgWorkerSheet.Rows[e.RowIndex].Cells["colHours"].ReadOnly = true;
                    }
                }
                else
                {
                    for (int i = 0; i < dsMFGt.Tables[0].Columns.Count; i++)
                        dsMFGt.Tables[0].Rows[e.RowIndex][i] = DBNull.Value;
                    //showWarnMessege("Please enter a valid traveler number..", 3);
                    MessageBox.Show("Please enter a valid traveler number..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //dgWorkerSheet[e.ColumnIndex, e.RowIndex].Value = null;
                    dgWorkerSheet.Rows[e.RowIndex].Cells["colOperation"].ReadOnly = true;
                    dgWorkerSheet.Rows[e.RowIndex].Cells["colQuantity"].ReadOnly = true;
                    dgWorkerSheet.Rows[e.RowIndex].Cells["colHours"].ReadOnly = true;
                }
            }

            if (e.ColumnIndex == 6)
            {
                string CellValue = "0";

                if (dgWorkerSheet[e.ColumnIndex, e.RowIndex].Value != null)
                    CellValue = dgWorkerSheet[e.ColumnIndex, e.RowIndex].Value.ToString().Trim();

                if (!CheckIfInteger(CellValue))
                {
                    MessageBox.Show("Entered quantity is not a valid integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CellValue = "0";
                }

                dgWorkerSheet[e.ColumnIndex, e.RowIndex].Value = CellValue;
            }

            if (e.ColumnIndex == 7)
            {
                string CellValue = "0";

                if (dgWorkerSheet[e.ColumnIndex, e.RowIndex].Value != null)
                    CellValue = dgWorkerSheet[e.ColumnIndex, e.RowIndex].Value.ToString().Trim();

                if (!CheckIfNumber(CellValue) || double.Parse(CellValue) > 24)
                {
                    MessageBox.Show("Entered hour value is invalid, value should be between 0 and 24", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CellValue = "0";
                }

                dgWorkerSheet[e.ColumnIndex, e.RowIndex].Value = CellValue;
            }

            #region Using Desined Table Adapter
            //if (e.ColumnIndex == 0)
            //{
            //    decimal trvNumber;
                
            //    if (!decimal.TryParse(dgWorkerSheet[e.ColumnIndex, e.RowIndex].Value.ToString(), out trvNumber))
            //        return;

            //    string clipMember = "";
                
            //    Data.dsFoxProTableAdapters.a_88TableAdapter ta_a_88 = new AccountabilityNotePad.Data.dsFoxProTableAdapters.a_88TableAdapter();
            //    dsFoxPro.a_88DataTable dt_a_88 = ta_a_88.GetData(trvNumber);

            //    if (dt_a_88.Rows.Count < 0)
            //    {
            //        if (dt_a_88[0].tsn_no != 0)
            //        {
            //            Data.dsFoxProTableAdapters.a_77TableAdapter ta_a_77 = new AccountabilityNotePad.Data.dsFoxProTableAdapters.a_77TableAdapter();
            //            dsFoxPro.a_77DataTable dt_a_77 = ta_a_77.GetData(dt_a_88[0].tsn_no);
            //            if (dt_a_77[0].clipmember)
            //                clipMember = "Member";
            //            else
            //                clipMember = "Clip";
            //        }
            //        else
            //        {
            //            if (dt_a_88[0].stock_no != 0)
            //            {
            //                Data.dsFoxProTableAdapters.a_90TableAdapter ta_a_90 = new AccountabilityNotePad.Data.dsFoxProTableAdapters.a_90TableAdapter();
            //                dsFoxPro.a_90DataTable dt_a_90 = ta_a_90.GetData(dt_a_88[0].stock_no);
            //                if (dt_a_90[0].clipmember)
            //                    clipMember = "Member";
            //                else
            //                    clipMember = "Clip";
            //            }
            //        }

            //        Data.dsFoxProTableAdapters.a_92TableAdapter ta1_a_92 = new AccountabilityNotePad.Data.dsFoxProTableAdapters.a_92TableAdapter();
            //        string operation = ta1_a_92.GetDataByTrvNo(trvNumber);

            //        dgWorkerSheet.Rows[e.RowIndex].Cells["colCompnay"].Value = dt_a_88[0].company;
            //        dgWorkerSheet.Rows[e.RowIndex].Cells["colClipMember"].Value = clipMember;
            //        dgWorkerSheet.Rows[e.RowIndex].Cells["colPartClass"].Value = dt_a_88[0].partclass;
            //        dgWorkerSheet.Rows[e.RowIndex].Cells["colPartNumber"].Value = dt_a_88[0].partnumber;
            //        dgWorkerSheet.Rows[e.RowIndex].Cells["colOperation"].Value = operation;

            //        dgWorkerSheet.Rows[dgWorkerSheet.Rows.Count - 1].Cells["colOperation"].ReadOnly = true;
            //        dgWorkerSheet.Rows[dgWorkerSheet.Rows.Count - 1].Cells["colQuantity"].ReadOnly = true;
            //        dgWorkerSheet.Rows[dgWorkerSheet.Rows.Count - 1].Cells["colHours"].ReadOnly = true;
            //    }
            //    else
            //    {
            //        ttGridMsg.SetToolTip(dgWorkerSheet, "Please enter a valid Traveler Number");
            //        dgWorkerSheet[e.ColumnIndex, e.RowIndex].Value = "";
            //    }
            //}
            #endregion
        }
        
        private void dgWorkerSheet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (e.RowIndex > -1 && dgWorkerSheet[e.ColumnIndex, e.RowIndex].IsInEditMode)
                {
                    string CellValue = "0";

                    if (dgWorkerSheet[e.ColumnIndex, e.RowIndex].Value != null)
                        CellValue = dgWorkerSheet[e.ColumnIndex, e.RowIndex].Value.ToString().Trim();

                    if (!CheckIfNumber(CellValue) || decimal.Parse(CellValue) > 24)
                    {
                        MessageBox.Show("Entered hour value is invalid, value should be between 0 and 24", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CellValue = "0";
                    }
                    else if (getTotalHours() > 24)
                    {
                        MessageBox.Show("Entered hour value is invalid, total hours should be between 0 and 24", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CellValue = "0";
                    }
                    dsMFGt.Tables[0].Rows[e.RowIndex][e.ColumnIndex + 1] = CellValue;
                    //dgWorkerSheet[e.ColumnIndex, e.RowIndex].Value = CellValue;
                }
                updateTotalHours();
            }
            if (e.ColumnIndex == 5 && e.RowIndex > -1)
            {
                if (dgWorkerSheet[5, e.RowIndex].Value.ToString() == "Add new Operation..")
                {
                    Operation frmOperation = new Operation();
                    frmOperation.ShowDialog();
                }
            }
        }
        #endregion
    }
}