using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ConfigData_Default7 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["ConfigDB"] == null)
            {
                Response.Redirect("~/ConfigData/ConfigData.aspx", true);
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["ConfigDB"] = null;
        Response.Redirect("~/ConfigData/ConfigData.aspx", true);
    }
}