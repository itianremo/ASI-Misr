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

public partial class ChangePassword : Pharma.BMD.BLL.ChangePasswordBLL
{
    protected void Page_Load(object sender, EventArgs e)
    {
        InitiateTransactionsControl();
        if (!IsPostBack)
        {
            ClearTextBoxes();
            lblMsg.Text = "";
        }
    }
    private void InitiateTransactionsControl()
    {
        TransButtons ucTransButtons = (TransButtons)Master.FindControl("ucTransButtons");
        ucTransButtons.CurrentPage = "ManageApplication";
    }
   
    private void ClearTextBoxes()
    {
        txtOldPassword.Text = "";
        txtNewPassword1.Text = "";
        txtNewPassword2.Text = "";
    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (Membership.ValidateUser(CurrentUserInfo.UserName, txtOldPassword.Text))
        {
            MembershipUser msu = Membership.GetUser(CurrentUserInfo.UserName);

            if (msu.ChangePassword(txtOldPassword.Text, txtNewPassword1.Text))
                lblMsg.Text = "Password updated successfully!";
            else
                lblMsg.Text = "Can't update password.";
        }
        else
            lblMsg.Text = "Invalid old password.";

        ClearTextBoxes();
    }
}
