using System;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Security;
using System.Security.Principal;
using System.Runtime.InteropServices;

/// <summary>
/// Summary description for FoxProSrv
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class FoxProSrv : System.Web.Services.WebService
{
    #region Definitions for impersonation
    public const int LOGON32_LOGON_INTERACTIVE = 2;
    public const int LOGON32_PROVIDER_DEFAULT = 0;

    private static bool _IsImpersonated = false;
    WindowsImpersonationContext impersonationContext;

    [DllImport("advapi32.dll")]
    public static extern int LogonUserA(String lpszUserName,
        String lpszDomain,
        String lpszPassword,
        int dwLogonType,
        int dwLogonProvider,
        ref IntPtr phToken);
    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int DuplicateToken(IntPtr hToken,
        int impersonationLevel,
        ref IntPtr hNewToken);

    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool RevertToSelf();

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static extern bool CloseHandle(IntPtr handle);
    #endregion

    public FoxProSrv()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    protected override void Dispose(bool disposing)
    {
        if (_IsImpersonated)
            undoImpersonation();
        base.Dispose(disposing);
    }

    #region GetFoxProConnection
    string GetFoxProConnection()
    {
        string conn = "";
        conn = System.Configuration.ConfigurationManager.AppSettings["FoxProConnection"].ToString();
        return conn;
    }
    #endregion

    #region GetAllOperations
    [WebMethod]
    public DataSet GetAllOperations()
    {
        impersonate();

        DataSet MyDS = new DataSet();

        using (OleDbConnection MyCon = new OleDbConnection(GetFoxProConnection()))
        {
            //Create New ODBC command to execute command
            OleDbCommand MyCmd = new OleDbCommand();
            MyCmd.CommandText = "SELECT DISTINCT operation FROM a_92 WHERE (operation NOT like ' ')";
            MyCmd.Connection = MyCon;
            MyCon.Open();

            //Creates new adapter to execute the ODBC command with parameters
            OleDbDataAdapter MyAdapt = new OleDbDataAdapter(MyCmd);

            //Fill DataSet with results from Adapter
            MyAdapt.Fill(MyDS);
        }
        return MyDS;
    }
    #endregion

    #region GetTravelerData
    [WebMethod]
    public DataSet GetTravelerData(string TravelerID)
    {
        impersonate();

        DataSet MyDS = new DataSet();

        using (OleDbConnection MyCon = new OleDbConnection(GetFoxProConnection()))
        {
            //Create New ODBC command to execute command
            OleDbCommand MyCmd = new OleDbCommand();
            MyCmd.CommandText = "SELECT tsn_no, stock_no, retailer AS Company, type AS PartClass, part_no AS PartNumber FROM a_88 WHERE (wo_no = " + TravelerID + ")";
            MyCmd.Connection = MyCon;
            MyCon.Open();

            //Creates new adapter to execute the ODBC command with parameters
            OleDbDataAdapter MyAdapt = new OleDbDataAdapter(MyCmd);

            //Fill DataSet with results from Adapter
            MyAdapt.Fill(MyDS);
        }
        return MyDS;
    }

    #endregion 

    #region GetTrvPartTypeInTable77
    [WebMethod]
    public DataSet GetTrvPartTypeInTable77(string TsnNo )
    {
        impersonate();

        DataSet MyDS = new DataSet();

        using (OleDbConnection MyCon = new OleDbConnection(GetFoxProConnection()))
        {
            //Create New ODBC command to execute command
            OleDbCommand MyCmd = new OleDbCommand();
            MyCmd.CommandText = "SELECT rolled_l AS ClipMember FROM a_77 WHERE (tsn_no = " + TsnNo + ")";
            MyCmd.Connection = MyCon;
            MyCon.Open();

            //Creates new adapter to execute the ODBC command with parameters
            OleDbDataAdapter MyAdapt = new OleDbDataAdapter(MyCmd);

            //Fill DataSet with results from Adapter
            MyAdapt.Fill(MyDS);
        }
        return MyDS;
    }

    #endregion 

    #region GetTrvPartTypeInTable90
    [WebMethod]
    public DataSet GetTrvPartTypeInTable90(string StockNo )
    {
        impersonate();

        DataSet MyDS = new DataSet();

        using (OleDbConnection MyCon = new OleDbConnection(GetFoxProConnection()))
        {
            //Create New ODBC command to execute command
            OleDbCommand MyCmd = new OleDbCommand();
            MyCmd.CommandText = "SELECT rolled_l AS ClipMember FROM a_90 WHERE (stock_no = " + StockNo   + ")";
            MyCmd.Connection = MyCon;
            MyCon.Open();

            //Creates new adapter to execute the ODBC command with parameters
            OleDbDataAdapter MyAdapt = new OleDbDataAdapter(MyCmd);

            //Fill DataSet with results from Adapter
            MyAdapt.Fill(MyDS);
        }
        return MyDS;
    }

    #endregion 

    #region GetTravelerOperation
    [WebMethod]
    public DataSet GetTravelerOperation(string TravelerID)
    {
        impersonate();

        DataSet MyDS = new DataSet();

        using (OleDbConnection MyCon = new OleDbConnection(GetFoxProConnection()))
        {
            //Create New ODBC command to execute command
            OleDbCommand MyCmd = new OleDbCommand();
            MyCmd.CommandText = "SELECT DISTINCT operation FROM a_92 WHERE (wo_no = " + TravelerID + ")";
            MyCmd.Connection = MyCon;
            MyCon.Open();

            //Creates new adapter to execute the ODBC command with parameters
            OleDbDataAdapter MyAdapt = new OleDbDataAdapter(MyCmd);

            //Fill DataSet with results from Adapter
            MyAdapt.Fill(MyDS);
        }
        return MyDS;
    }

    #endregion 

    #region CheckConnection
    [WebMethod]
    public int CheckConnection()
    {
        impersonate();

        int n = 0;
        try
        {
            OleDbConnection MyCon = new OleDbConnection(GetFoxProConnection());
            MyCon.Open();
            new OleDbDataAdapter(new OleDbCommand("SELECT wo_no FROM a_92 WHERE (wo_no = 1)", MyCon)).Fill(new DataSet());
            MyCon.Close();
            n = 1;
        }
        catch( Exception ee ) 
        {
            n = 0;
        }
        return n;
    }

    #endregion

    #region Test current impersonation state
    [WebMethod]
    public bool IsImpersonated()
    {
        impersonate();

        return _IsImpersonated;
    }
    #endregion

    #region Test impersonation web method
    [WebMethod]
    public string testImpersonation()
    {
        string result = "Currrent user in: '" + WindowsIdentity.GetCurrent().Name + "'.\n";

        string UserName = System.Configuration.ConfigurationManager.AppSettings["FoxProUserName"].ToString();
        string Password = DecryptText(System.Configuration.ConfigurationManager.AppSettings["FoxProUserPass"].ToString());
        string Domain = System.Environment.UserDomainName;

        result += "U: '" + UserName + "'\n";
        result += "P: '" + Password + "'\n";
        result += "D: '" + Domain + "'\n";

        if (impersonateValidUser(UserName, Domain, Password))
        {
            result += "Currrent user in: '" + WindowsIdentity.GetCurrent().Name + "'.\n";
            undoImpersonation();
            result += "Currrent user in: '" + WindowsIdentity.GetCurrent().Name + "'.\n";
        }
        else
        {
            result += "Can't impersonate";
        }

        return result;
    }
    #endregion

    [WebMethod]
    public string getUser()
    {
        return WindowsIdentity.GetCurrent().Name;
    }
    #region Impersonation functions
    private void impersonate()
    {
        string UserName = System.Configuration.ConfigurationManager.AppSettings["FoxProUserName"].ToString();
        string Password = DecryptText(System.Configuration.ConfigurationManager.AppSettings["FoxProUserPass"].ToString());
        _IsImpersonated = impersonateValidUser(UserName, System.Environment.UserDomainName, Password);
    }
    private bool impersonateValidUser(String userName, String domain, String password)
    {
        WindowsIdentity tempWindowsIdentity;
        IntPtr token = IntPtr.Zero;
        IntPtr tokenDuplicate = IntPtr.Zero;

        if (RevertToSelf())
        {
            if (LogonUserA(userName, domain, password, LOGON32_LOGON_INTERACTIVE,
                LOGON32_PROVIDER_DEFAULT, ref token) != 0)
            {
                if (DuplicateToken(token, 2, ref tokenDuplicate) != 0)
                {
                    tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                    impersonationContext = tempWindowsIdentity.Impersonate();
                    if (impersonationContext != null)
                    {
                        CloseHandle(token);
                        CloseHandle(tokenDuplicate);
                        return true;
                    }
                }
            }
        }
        if (token != IntPtr.Zero)
            CloseHandle(token);
        if (tokenDuplicate != IntPtr.Zero)
            CloseHandle(tokenDuplicate);
        return false;
    }
    private void undoImpersonation()
    {
        impersonationContext.Undo();
    }
    private string EncryptText(string TextToEncrypt)
    {
        string SKey = "0123456789";
        string EncryptedText = Util.EncryptData(TextToEncrypt, SKey);
        return EncryptedText;
    }
    private string DecryptText(string TextToDecrypt)
    {
        string SKey = "0123456789";
        string DecData = Util.DecryptData(TextToDecrypt, SKey);
        return DecData;
    }
    #endregion

    private void InitializeComponent()
    {

    }


}

