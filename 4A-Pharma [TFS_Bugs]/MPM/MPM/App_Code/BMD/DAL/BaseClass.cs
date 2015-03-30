using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Pharma.DAL
{
    /// <summary>
    /// Summary description for BaseClass
    /// </summary>
    public sealed class BaseClass : System.Web.UI.Page 
    {
        public static string strConnection = ConfigurationManager.ConnectionStrings["PharmaConnectionString"].ConnectionString;
        public BaseClass()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}