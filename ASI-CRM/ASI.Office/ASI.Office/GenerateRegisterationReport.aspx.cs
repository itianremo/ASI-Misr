using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GenerateRegisterationReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string file = "Members.xls";
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", file));
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        HttpContext.Current.Response.TransmitFile(file);
        Response.Flush();
        Response.End();
    }
}