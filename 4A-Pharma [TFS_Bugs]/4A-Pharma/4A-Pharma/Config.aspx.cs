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

public partial class Config : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void imgbtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        if (txtUsername.Text == "pharmaConf" && txtPassword.Text == "pharmaConfPass147")
            OpenConfPanel();
        else
            HttpContext.Current.Response.Redirect("Login.aspx");
    }

    private void OpenConfPanel()
    {
        pnlLogin.Visible = false;
        pnlConf.Visible = true;
    }
}
