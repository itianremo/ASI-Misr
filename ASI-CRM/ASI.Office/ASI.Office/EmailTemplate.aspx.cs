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
using Office.DAL;

public partial class EmailTemplate :  Office.BLL.EmailTemplateBLL
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckUserSession();
        if (!IsPostBack)
        {
            
            BindGridView();
        }
        //////
		  //string CurrentPage = "EmailTemplate";
		  //ucUserTabs.CurrentPage = CurrentPage;
		  //ucUserTabs.btnAccountsEvent += new EventHandler(ucUserTabs_btnAccountsEvent);
		  //ucUserTabs.btnAccountListsEvent += new EventHandler(ucUserTabs_btnAccountListsEvent);
		  //ucUserTabs.btnContantsEvent += new EventHandler(ucUserTabs_btnContantsEvent);
		  //ucUserTabs.btnContactListsEvent += new EventHandler(ucUserTabs_btnContactListsEvent);
		  //ucUserTabs.btnBranchesEvent += new EventHandler(ucUserTabs_btnBranchesEvent);
		  //ucUserTabs.btnBranchesDetailsEvent += new EventHandler(ucUserTabs_btnBranchesDetailsEvent);
		  //ucUserTabs.btnCallsEvent += new EventHandler(ucUserTabs_btnCallsEvent);
		  //ucUserTabs.btnManageApplicationEvent += new EventHandler(ucUserTabs_btnManageApplicationEvent);
		  ////
		  //imgbtnSignOut.Attributes.Add("onmouseover", "this.src='Images/CloseBut_pressed.jpg'");
		  //imgbtnSignOut.Attributes.Add("onmouseout", "this.src='Images/CloseBut_normal.jpg'");
        //
        //
        imgSaveTemplate.Attributes.Add("onmouseover", "this.src='Images/save2.jpg'");
        imgSaveTemplate.Attributes.Add("onmouseout", "this.src='Images/save1.jpg'");
        //
        //
        imgCancel.Attributes.Add("onmouseover", "this.src='Images/Cancel2.jpg'");
        imgCancel.Attributes.Add("onmouseout", "this.src='Images/Cancel1.jpg'");
        //
        //
        imgNewTemplate.Attributes.Add("onmouseover", "this.src='Images/New-o.jpg'");
        imgNewTemplate.Attributes.Add("onmouseout", "this.src='Images/New-n.jpg'");
        //
    }
    private void BindGridView()
    {
        Session["CurrentTemplate"] = GetSearchFilter("TemplateName", "ASC");
        dgTemplates.DataSource = ObjectDataSource1;
        dgTemplates.DataBind();
       
    }
    private void ucUserTabs_btnAccountsEvent(object sender, EventArgs e)
    {
        Response.Redirect("Accounts.aspx");
    }

    private void ucUserTabs_btnAccountListsEvent(object sender, EventArgs e)
    {
        Response.Redirect("AccountLists.aspx");
    }

    private void ucUserTabs_btnContantsEvent(object sender, EventArgs e)
    {
        Response.Redirect("Contacts.aspx");
    }

    private void ucUserTabs_btnContactListsEvent(object sender, EventArgs e)
    {
        Response.Redirect("ContactLists.aspx");
    }

    private void ucUserTabs_btnBranchesEvent(object sender, EventArgs e)
    {
        Response.Redirect("Branches.aspx");
    }

    private void ucUserTabs_btnBranchesDetailsEvent(object sender, EventArgs e)
    {
        Response.Redirect("BranchDetails.aspx");
    }

    private void ucUserTabs_btnCallsEvent(object sender, EventArgs e)
    {
        Response.Redirect("CallsManagement.aspx");
    }

    private void ucUserTabs_btnManageApplicationEvent(object sender, EventArgs e)
    {
        Response.Redirect("ManageApplication.aspx");
    }

	 //public void CheckUserSession()
	 //{
	 //    if (HttpContext.Current.Session["UserData"] == null)
	 //    {
	 //        Response.Redirect("Login.aspx");
	 //    }

	 //}
    protected void imgSaveTemplate_Click(object sender, ImageClickEventArgs e)
    {
        if (ViewState["TemplateID"] != null)//update
        {

            int TemplateID = Convert.ToInt32(ViewState["TemplateID"].ToString());
            bool vbResult = UpdateEmailTemplate(TemplateID, txtTemplateName.Text, Server.HtmlEncode(FreeTextBox1.Text), txtSubject.Text, cbDefault.Checked);
            if (vbResult)
            {
                ResetControls();
                ViewState["TemplateID"] = null;
                BindGridView();

            }
        }
        else// add
        {
            bool vbResult = AddEmailTemplate(0, txtTemplateName.Text, Server.HtmlEncode(FreeTextBox1.Text), txtSubject.Text, cbDefault.Checked);
            if (vbResult)
            {
                ResetControls();
                ViewState["TemplateID"] = null;
                BindGridView();

            }

        }


    }

    private void ResetControls()
    {
        txtTemplateName.Text = "";
        txtSubject.Text = "";
        FreeTextBox1.Text = "";
        cbDefault.Checked = false;
    }
    protected void imgNewTemplate_Click(object sender, ImageClickEventArgs e)
    {
        ResetControls();
        ViewState["TemplateID"] = null;
    }
    protected void imgCancel_Click(object sender, ImageClickEventArgs e)
    {
        ResetControls();
        ViewState["TemplateID"] = null;
    }
    protected void imgbtnSignOut_Click(object sender, ImageClickEventArgs e)
    {
        SignOut();
    }
    protected void ImgEditTemplate_Click(object sender, ImageClickEventArgs e)
    {
        GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent;
        int TemplateID = int.Parse(row.Cells[0].Text);
        Office.DAL.EmailTemplate temp = new Office.DAL.EmailTemplate();
        temp.TemplateID = TemplateID;
        ViewState["TemplateID"] = TemplateID;
        Office.DAL.EmailTemplate tempemail = temp.GetSingleTemplate();
        txtTemplateName.Text = tempemail.TemplateName;
        txtSubject.Text = tempemail.TemplateEmailSubject;
        FreeTextBox1.Text = Server.HtmlDecode(tempemail.TemplateContent);
        cbDefault.Checked = tempemail.DefaultTemplate;

    }
    protected void ImgDelete_Click(object sender, ImageClickEventArgs e)
    {
        GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent;
        int TemplateID = int.Parse(row.Cells[0].Text);
        string vsMsg=DeleteTemplateByID(TemplateID);
        BindGridView();


    }
    protected void dgTemplates_PageIndexChanged(object sender, EventArgs e)
    {
        dgTemplates.SelectedIndex = -1;
    }
    protected void dgTemplates_SelectedIndexChanged(object sender, EventArgs e)
    {
        int TemplateID = Convert.ToInt32(dgTemplates.DataKeys[dgTemplates.SelectedIndex].Values["TemplateID"].ToString());
        Office.DAL.EmailTemplate temp = new Office.DAL.EmailTemplate();
        temp.TemplateID =TemplateID;
        Office.DAL.EmailTemplate tempemail = temp.GetSingleTemplate();
       
       

    }
    protected void dgTemplates_RowCreated(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='none';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            e.Row.Attributes["ondblclick"] = ClientScript.GetPostBackClientHyperlink(this.dgTemplates, "Select$" + e.Row.RowIndex);
            foreach (TableCell tc in e.Row.Cells)
            {
                tc.CssClass = "GridCellStyle";
            }
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton l = (ImageButton)e.Row.FindControl("ImgDelete");
            l.Attributes["onclick"] = "javascript:return confirm('You are about to delete the selected template. continue...?')";
             e.Row.Cells[0].Visible = false;
           

            
        }
        else if (e.Row.RowType == DataControlRowType.Header)
        {
             e.Row.Cells[0].Visible = false;
           
        }

    }
}