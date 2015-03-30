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

public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblErrMsg.Visible = false;
        txtUserName.Focus();
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string ErrMsg = "";
        if (txtPassword.Text.Trim() == "" || txtUserName.Text.Trim() == "")
        {
            ErrMsg = "Please enter User Name and Password";
            lblErrMsg.Visible = true;
        }
        else if (txtPassword.Text.Trim().ToLower() != "tsnadmin" || txtUserName.Text.Trim().ToLower() != "admin")
        {
            ErrMsg = "User Name or Password is incorrect";
            lblErrMsg.Visible = true;
        }
        else
        {
            ErrMsg = "";
            lblErrMsg.Visible = false;
            Session["User"] = "True";
            Response.Redirect("AdminPage.aspx");
        }
        lblErrMsg.Text = ErrMsg;
    }
}
