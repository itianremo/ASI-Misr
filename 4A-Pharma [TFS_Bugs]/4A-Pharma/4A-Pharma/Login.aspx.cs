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

public partial class PharmaLogin : Pharma.BMD.BLL.MasterClass
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region -------------------Graphics Handler--------------------
        imgbtnLogin.Attributes.Add("onmouseover", "this.src='Images/Login-d.png'");
        imgbtnLogin.Attributes.Add("onmouseout", "this.src='Images/Login-n.png'");
        #endregion
        if (!IsPostBack)
        {
            Session.Clear();
        }
    }

    protected void imgbtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        if (IsValidEmployee(txtUsername.Text, txtPassword.Text))
        {
            Session["User"] = txtUsername.Text;
            InitiateUserSessions();
            if(CurrentUserInfo.IsUserRank)
                if (!IsValidBrickRelations(CurrentUserInfo.EmpID))
                {
                    lblMsg.Text = "You have no bricks assigned to you.<Br>Please, Refere to your manager to assign you at least one brick.";
                    return;
                }
            Response.Redirect("Redirect.aspx");
        }
        else
            lblMsg.Text = "Invalid login attempt. Please, try again.";
    }

}
