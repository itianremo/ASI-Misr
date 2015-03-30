using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;


namespace ReportWriter
{
    /// <summary>
    /// Summary description for ApplicationInfo
    /// </summary>
    public class ApplicationInfo 
    {
        Hashtable appInfo = new Hashtable();
      
        public ApplicationInfo()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string ApplicationID
        {
            get
            {
                return appInfo["Id"].ToString();
            }
            set
            {
                appInfo.Add( "Id" , value);

            }
        }
        public string ApplicationName
        {
            get
            {
                return appInfo["AppName"].ToString();
            }
            set
            {
                appInfo.Add("AppName", value);

            }
        }
        public string UsersQuery
        {
            get
            {
                return appInfo["UsrQuery"].ToString();
            }
            set
            {
                appInfo.Add("UsrQuery", value);

            }
        }
        public string UserDisplayedField
        {
            get
            {
                return appInfo["DispFld"].ToString();
            }
            set
            {
                appInfo.Add("DispFld", value);

            }
        }
        public string UserIDField
        {
            get
            {
                return appInfo["IDFld"].ToString();
            }
            set
            {
                appInfo.Add("IDFld", value);

            }
        }
        public string ApplicationConnection
        {
            get
            {
                return appInfo["Conn"].ToString();
            }
            set
            {
                appInfo.Add("Conn", value);

            }
        }
        public string WSDSReportURL
        {
            get
            {
                return appInfo["WSDSReportURL"].ToString();
            }
            set
            {
                appInfo.Add("WSDSReportURL", value);

            }
        }

        //public string ApplicationID
        //{
        //    get
        //    {
        //        return appInfo["ApplicationID"].ToString();
        //    }
        //    set
        //    {
        //        appInfo.Add("ApplicationID", value);

        //    }
        //}
        public string DModelPass
        {
            get
            {
                return appInfo["DModelPass"].ToString();
            }
            set
            {
                appInfo.Add("DModelPass", value);

            }
        }
        public string MRTFileName
        {
            get
            {
                return appInfo["MRTFileName"].ToString();
            }
            set
            {
                appInfo.Add("MRTFileName", value);

            }
        }

    }
}
