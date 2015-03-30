using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ReportWriter;

    public partial class GenerateFile : System.Web.UI.Page
    {
        CommonMethods CommMethods = new CommonMethods();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString.Get("ReportID")))
                {
                    int ID;
                    int.TryParse(Request.QueryString.Get("ReportID"), out ID);
                    CommMethods.DownloadReport(ID, this);
                }
            }
        }
    }
