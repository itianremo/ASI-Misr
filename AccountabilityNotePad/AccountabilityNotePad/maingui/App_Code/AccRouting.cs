using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;


/// <summary>
/// Summary description for AccRouting
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class AccRouting : System.Web.Services.WebService {

    public AccRouting () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]
    public string GetAccServer()
    {
        string ServerName = "";
        ServerName = System.Configuration.ConfigurationManager.AppSettings["ServerName"].ToString();
        return ServerName;
        
    }
    [WebMethod]
    public string GetHelpURL()
    {
        string URL = "";
        URL = System.Configuration.ConfigurationManager.AppSettings["HelpURL"].ToString();
        return URL;
    }
    [WebMethod]
    public string GetFoxProConnection()
    {
        string conn = "";
        conn = System.Configuration.ConfigurationManager.AppSettings["FoxProConnection"].ToString();
        return conn;
    }
    [WebMethod]
    public string GetAUUAUpdateLoc()
    {
        string loc = "";
        loc = System.Configuration.ConfigurationManager.AppSettings["AUUAUpdateLocation"].ToString();
        return loc;
    }
    [WebMethod]
    public string GetANPUpdateLoc()
    {
        string loc = "";
        loc = System.Configuration.ConfigurationManager.AppSettings["ANPUpdateLocation"].ToString();
        return loc;
    }
    [WebMethod]
    public string GetAUUAServerVersion()
    {
        string version = null;
        string UpdateLocation = System.Configuration.ConfigurationManager.AppSettings["AUUAUpdateLocation"].ToString();

        DirectoryInfo dirInfo = new DirectoryInfo(UpdateLocation);
        if (dirInfo.Exists)
        {
            FileInfo[] fileCollection = dirInfo.GetFiles("ANPUpdaterUtilityApp.exe");
            if (fileCollection.Length > 0)
            {
                version = System.Diagnostics.FileVersionInfo.GetVersionInfo(fileCollection[0].FullName).ProductVersion.Replace(".", "");
            }
        }

        return version;
    }
}

