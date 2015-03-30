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
using Office.BLL;
using System.Text;



public partial class AccountLists : Office.BLL.AccountListsBLL
{
    // Sessions:
    // SingleAccountID, CurrentNote, UserData, CurrentContact, Account, SingleContactID, NewAccount

    protected void Page_Load(object sender, EventArgs e)
    {
        CheckUserSession();
		 
        Session["UserID"] = ((ASIIdentity)User.Identity).UserID;
        //check the post back and prevent hiding the branch banel, if it was internal post back from the country list box 
        string controlName = Request.Params.Get("__EVENTTARGET");
        if (controlName == "TabContainer1$TabPanel3$BranchForm1$frmViewBranchDetails$ddlCountry")
        {
            mdlPopup.Show();

        }
        // end
        ShowTabHeaders(true);
        if (!IsPostBack)
        {
            //lblVersionInfo.Text = GetVersionInfo();
            if (Session["SingleAccountID"] != null && Session["SingleAccountID"].ToString() != "")
            {
                // Added By Fawzi //
                Session["SingleAccountIDForContactListsPage"] = Session["SingleAccountID"];
                //
                ViewState["AccountID"] = Session["SingleAccountID"];
                ViewState["AccountIDforPaging"] = Session["SingleAccountID"];
                Session["SingleAccountID"] = null;
                if (Convert.ToInt32(Session["CurrentSelectedRowIndex"]) == -2)
                {
                    Session["CurrentSelectedRowIndex"] = GetAccountItemOrderNo(Convert.ToInt32(ViewState["AccountID"]));
                }
            }
            else
            {
                if (ViewState["AccountID"] == null)
                    ViewState["AccountID"] = "";
                ViewState["AccountIDforPaging"] = "";
                Session["CurrentSelectedRowIndex"] = null;
            }

            //
            imgContactsTab.Attributes.Add("onmouseover", "this.src= 'Images/contacts_over.png';");
            imgContactsTab.Attributes.Add("onmouseout", "this.src= 'Images/contacts_normal.png';");
            imgNotesTab.Attributes.Add("onmouseover", "this.src= 'Images/notes_over.png';");
            imgNotesTab.Attributes.Add("onmouseout", "this.src= 'Images/notes_normal.png';");
            imgbtnSubCompanies.Attributes.Add("onmouseover", "this.src= 'Images/SubCompanies-o.png';");
            imgbtnSubCompanies.Attributes.Add("onmouseout", "this.src= 'Images/SubCompanies-n.png';");
            btnNewSubCompany.Attributes.Add("onmouseover", "this.src= 'Images/AddSubCompany_o.png';");
            btnNewSubCompany.Attributes.Add("onmouseout", "this.src= 'Images/AddSubCompany_n.png';");
            imgbtnKeySoftware.Attributes.Add("onmouseover", "this.src= 'Images/Keys-o.png';");
            imgbtnKeySoftware.Attributes.Add("onmouseout", "this.src= 'Images/Keys-n.png';");
            imgbtnHistory.Attributes.Add("onmouseover", "this.src= 'Images/History-o.png';");
            imgbtnHistory.Attributes.Add("onmouseout", "this.src= 'Images/History-n.png';");
            imgbtnAttachments.Attributes.Add("onmouseover", "this.src= 'Images/Attachments-o.png';");
            imgbtnAttachments.Attributes.Add("onmouseout", "this.src= 'Images/Attachments-n.png';");
            imgbtnDuediligence.Attributes.Add("onmouseout", "this.src= 'Images/DueDiligence-n.png';");
            imgbtnDuediligence.Attributes.Add("onmouseover", "this.src= 'Images/DueDiligence-o.png';");
            //
            imgbtnNext.Attributes.Add("onmouseover", "this.src= 'Images/RightArrow_o.gif';");
            imgbtnNext.Attributes.Add("onmouseout", "this.src= 'Images/RightArrow_n.gif';");
            imgbtnNext.Attributes.Add("onmousedown", "this.src='Images/RightArrow_s.gif'");
            //
            imgbtnPrevious.Attributes.Add("onmouseover", "this.src= 'Images/LeftArrow_o.gif';");
            imgbtnPrevious.Attributes.Add("onmouseout", "this.src= 'Images/LeftArrow_n.gif';");
            imgbtnPrevious.Attributes.Add("onmousedown", "this.src='Images/LeftArrow_s.gif'");
            //
            Session["CurrentNote"] = null;
            Session["CurrentAID"] = null;
            //
            if (Session["Country"] != null && Session["Country"].ToString() !="All")
            {
                ViewState["Country"] = Session["Country"].ToString();
            }
            else 
            {
                ViewState["Country"] = "-1";
            }
            //
            if (Session["SortExpression"] != null)
                ViewState["orderbyField"] = Session["SortExpression"];
            else
                ViewState["orderbyField"] = "AccountName";

            if (Session["SortType"] != null)
                ViewState["SortType"] = Session["SortType"];
            else
                ViewState["SortType"] = "ASC";

            ViewState["NoteSortType"] = "ASC";
            ViewState["SpecificAccount"] = "";
            //
            LoadSearchPrameters();
            BindFormView();
            Session["SelectedAccountID"] = frmViewAccountDetails.SelectedValue;
            // added by Sayed 12/3/2012 
            Session["EmailDuediligence"] = ((TextBox)frmViewAccountDetails.FindControl("txtEmailEdit")).Text;
            //
            Session["CurrentPage"] = "AccountLists";
            AddjustDropDownListsSelection();
            InsertFakeRecord();
            if (Session["NewAccount"] == null || !((bool)Session["NewAccount"]))
            {
                OrderBy("UserEnterDate");
                LoadNoteSearchPrameters();
                gvNotesBindData();
            }
            AdjustReadOnlyFormStatus(true);

            //BranchForm1.AccountID = 0;

            if (Session["AccountID_branch"] != null)
            {
                //if (Session["AccountID_branch"].ToString() != "")
                    //BranchForm1.AccountID = Int32.Parse(Session["AccountID_branch"].ToString());
            }

            ViewState["AccountDeleted"] = false;

            //if (frmViewAccountDetails.PageIndex > 0)
            //{
            //    imgbtnPrevious.Visible = true;
            //}
            AdjustNextPreviousButtons();
        }
        else
        {
            lblMsg.Text = "";
        }
       
        string CurrentPage = "AccountLists";
        ucTransToolBar.CurrentPage = CurrentPage;
        ucTransToolBar.btnBackEvent += new EventHandler(ucTransToolBar_btnBackEvent);
        ucTransToolBar.btnSaveEvent += new EventHandler(ucTransToolBar_btnSaveEvent);
        ucTransToolBar.btnAddEvent += new EventHandler(ucTransToolBar_btnAddEvent);
        ucTransToolBar.btnEditEvent += new EventHandler(ucTransToolBar_btnEditEvent);
        ucTransToolBar.btnDeleteEvent += new EventHandler(ucTransToolBar_btnDeleteEvent);
        ucTransToolBar.btnCancelEvent += new EventHandler(ucTransToolBar_btnCancelEvent);
        AssignReportParameters();
        //////
        //ucUserTabs.CurrentPage = CurrentPage;
        //ucUserTabs.btnAccountsEvent += new EventHandler(ucUserTabs_btnAccountsEvent);
        //ucUserTabs.btnContantsEvent += new EventHandler(ucUserTabs_btnContantsEvent);
        //ucUserTabs.btnContactListsEvent += new EventHandler(ucUserTabs_btnContactListsEvent);
        //ucUserTabs.btnBranchesEvent += new EventHandler(ucUserTabs_btnBranchesEvent);
        //ucUserTabs.btnBranchesDetailsEvent += new EventHandler(ucUserTabs_btnBranchesDetailsEvent);
        //ucUserTabs.btnCallsEvent += new EventHandler(ucUserTabs_btnCallsEvent);
        //ucUserTabs.btnManageApplicationEvent += new EventHandler(ucUserTabs_btnManageApplicationEvent);
        //////
        ucAutoCompleteSearch.CurrentPage = CurrentPage;
        ucAutoCompleteSearch.btnSearchEvent += new EventHandler(ucAutoCompleteSearch_btnSearchEvent);
        //////
        //////
        //imgbtnSignOut.Attributes.Add("onmouseover", "this.src='Images/CloseBut_pressed.jpg'");
        //imgbtnSignOut.Attributes.Add("onmouseout", "this.src='Images/CloseBut_normal.jpg'");
        btnAddEditNotes.Attributes.Add("onMouseOver", "this.style.background = 'Blue'; this.style.color = 'White';");
        btnAddEditNotes.Attributes.Add("onMouseOut", "this.style.background = 'White'; this.style.color = 'Black';");
        // 
        //BranchesGrid1.BranchDeletingEvent +=new EventHandler(BranchesGrid1_BranchDeletingEvent);
        SubAccounts1.SubCompanyEditingEvent += new EventHandler(SubAccounts1_SubCompanyEditingEvent);
        SubAccounts1.SubCompanyDeletingEvent += new EventHandler(SubAccounts1_SubCompanyDeletingEvent);
        Contacts1.ContactsSortingEvent +=new GridViewSortEventHandler(Contacts1_ContactsSortingEvent);
        AdjustAccountManagerControls();
        lblEmptyResults.Visible = false;
    }

    private void AdjustNextPreviousButtons()
    {
        imgbtnNext_Click(null, null);
        if (frmViewAccountDetails.PageIndex + 1 <= frmViewAccountDetails.PageCount)
        {
            imgbtnPrevious_Click(null, null);
        }
        if (frmViewAccountDetails.PageIndex > 0)
        {
            imgbtnPrevious.Visible = true;
        }
        if (frmViewAccountDetails.PageIndex + 1 == frmViewAccountDetails.PageCount)
        {
            imgbtnNext.Visible = false;
        }
    }

    void ucUserTabs_btnManageApplicationEvent(object sender, EventArgs e)
    {
        Response.Redirect("ManageApplication.aspx");
    }
    private void AssignReportParameters()
    {
        string SpecificAccount = ((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text;
        ((ImageButton)ucTransToolBar.FindControl("btnPrint")).Attributes.Add("onclick", "openReports('" + ViewState["orderbyField"].ToString() + "','" + ViewState["SortType"].ToString() + "','','" + SpecificAccount + "','','','');");
    }

    protected override void OnLoadComplete(EventArgs e)
    {
        base.OnLoadComplete(e);

        if (!IsPostBack)
        {
            if ((bool)ViewState["AccountDeleted"])
                ViewState["AccountDeleted"] = false;
            else
                lblMsg.Text = "";

            if (Session["NewAccount"] != null && ((bool)Session["NewAccount"]))
            {
                //Session["NewAccount"] = false;
                //Page.RegisterStartupScript("myScript", "<script language=JavaScript>DisableTab();</script>");
                AddAccount(true);
            }
        }
    }

    #region User-Controls Functions
    protected void ucTransToolBar_btnEditEvent(object sender, EventArgs e)
    {
        ((ImageButton)ucTransToolBar.FindControl("btnSave")).AlternateText = "Update";
        // 
        AdjustReadOnlyFormStatus(false);
        //
        ViewState["SaveMode"] = "Update";
        //
        AdjustTransButtons(true);

        imgbtnNext.Visible = false;
        imgbtnPrevious.Visible = false;
    }
    private void AdjustTransButtons(bool Flag) 
    {
        lblMsg.Text = "";
        //
        ((ImageButton)ucTransToolBar.FindControl("btnCancel")).Visible = Flag;
        ((ImageButton)ucTransToolBar.FindControl("btnSave")).Visible = Flag;
        //
       
        if (User.IsInRole("AddAccount"))
            ((ImageButton)ucTransToolBar.FindControl("btnAdd")).Visible = !Flag;
        if (User.IsInRole("EditAccount"))
            ((ImageButton)ucTransToolBar.FindControl("btnEdit")).Visible = !Flag;
        if (User.IsInRole("DeleteAccount"))
            ((ImageButton)ucTransToolBar.FindControl("btnDelete")).Visible = !Flag;
    }
    private void AdjustReadOnlyFormStatus(bool Flag)
    {
        ((TextBox)frmViewAccountDetails.FindControl("txtboxAccountName")).ReadOnly = Flag;
        ((TextBox)frmViewAccountDetails.FindControl("txtBusSector")).ReadOnly = Flag;
        ((TextBox)frmViewAccountDetails.FindControl("txtboxCity")).ReadOnly = Flag;
        ((TextBox)frmViewAccountDetails.FindControl("txtProfile")).ReadOnly = Flag;
        //((TextBox)frmViewAccountDetails.FindControl("txtCountry")).ReadOnly = Flag;
        ((TextBox)frmViewAccountDetails.FindControl("txtboxFax")).ReadOnly = Flag;
        ((TextBox)frmViewAccountDetails.FindControl("txtboxPhone")).ReadOnly = Flag;
        ((TextBox)frmViewAccountDetails.FindControl("txtboxRefBy")).ReadOnly = Flag;
        ((TextBox)frmViewAccountDetails.FindControl("txtStatus")).ReadOnly = Flag;
        ((TextBox)frmViewAccountDetails.FindControl("txtboxStreet1")).ReadOnly = Flag;
        ((TextBox)frmViewAccountDetails.FindControl("txtboxStreet2")).ReadOnly = Flag;
        ((TextBox)frmViewAccountDetails.FindControl("txtboxWebsite")).ReadOnly = Flag;
        ((TextBox)frmViewAccountDetails.FindControl("txtEmailEdit")).ReadOnly = Flag;
        
        ((HyperLink)frmViewAccountDetails.FindControl("hlWebSite")).Visible = Flag;
        ((HyperLink)frmViewAccountDetails.FindControl("hlEmail")).Visible = Flag;
        ((TextBox)frmViewAccountDetails.FindControl("txtboxZipCode")).ReadOnly = Flag;
        ((TextBox)frmViewAccountDetails.FindControl("txtCountryID")).ReadOnly = Flag;
        ((TextBox)frmViewAccountDetails.FindControl("txtState")).ReadOnly = Flag;

        //
        ((CheckBox)frmViewAccountDetails.FindControl("cbxTop")).Enabled = !Flag;
        ((DropDownList)frmViewAccountDetails.FindControl("ddlStatus")).Enabled = !Flag;
        ((DropDownList)frmViewAccountDetails.FindControl("ddlCountry")).Enabled = !Flag;
        ((DropDownList)frmViewAccountDetails.FindControl("ddlState")).Enabled = !Flag;
        ((DropDownList)frmViewAccountDetails.FindControl("ddlBusSector")).Enabled = !Flag;
        //To check if this User has the authority to manage user or not
        Office.BLL.AccountListsBLL ALB = new Office.BLL.AccountListsBLL();
        if (frmViewAccountDetails.FindControl("ddlAccountMan") != null
            && User.IsInRole("AccountManager"))
        {
            ((DropDownList)frmViewAccountDetails.FindControl("ddlAccountMan")).Enabled = !Flag;
        }
    }
    protected void ucTransToolBar_btnCancelEvent(object sender, EventArgs e)
    {
       // added by sayed 5/9/2011
        Panel1.Visible = true;
        //
        Session["NewAccount"] = false;

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "EnableTab();", true);
        //
        AdjustReadOnlyFormStatus(true);
        //
        AdjustTransButtons(false);
        //
        LoadSearchPrameters(frmViewAccountDetails.SelectedValue.ToString());
        BindFormView();
        AdjustAccountManagerControls();
        AddjustDropDownListsSelection();
        InsertFakeRecord();
        gvNotesBindData();
        AdjustNextPreviousButtons();
        //if (frmViewAccountDetails.PageCount > 1)
        //{
        //    if (frmViewAccountDetails.PageIndex < frmViewAccountDetails.PageCount - 1)
        //    {
        //        frmViewAccountDetails.PageIndex += 1;
        //        frmViewAccountDetails.PageIndex -= 1;
        //    }
        //    else
        //    {
        //        frmViewAccountDetails.PageIndex -= 1;
        //        frmViewAccountDetails.PageIndex += 1;
        //    }
        //}
    }
    protected void ucTransToolBar_btnAddEvent(object sender, EventArgs e)
    {
        // added by sayed
        Panel1.Visible = false;
        //NoteState();
        
        imgbtnNext.Visible = false;
        imgbtnPrevious.Visible = false;

        imgbtnHistory_Click(null, null);
        AddAccount(false);
    }
    protected void AddAccount(bool New)
    {
        if (frmViewAccountDetails.FindControl("ddlAccountMan") == null)
        {
            ((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text = "";
            ViewState["SpecificAccount"] = "";
            Session["Account"] = "";
            BindFormView();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "DisableTab();", true);
            lblEmptyResults.Visible = false;
        }

        ((ImageButton)ucTransToolBar.FindControl("btnSave")).AlternateText = "Save";
        //
        AdjustReadOnlyFormStatus(false);
        //
        AdjustTransButtons(true);
        //
        ViewState["SaveMode"] = "Add";
        //
        ResetFormtxtboxes(New);
    }
    protected void ucTransToolBar_btnBackEvent(object sender, EventArgs e)
    {
        if (ViewState["AccountIDforPaging"] != null && ViewState["AccountIDforPaging"].ToString() != "")
        {
            Session["SingleAccountID"] = ViewState["AccountIDforPaging"];
            ViewState["AccountIDforPaging"] = null;
        }
        Response.Redirect("Accounts.aspx");
    }
    protected void ucTransToolBar_btnSaveEvent(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "EnableTab();", true);

        if (ValidateData())
        {
            if (ViewState["SaveMode"].ToString() == "Add")
            {
                if (((TextBox)frmViewAccountDetails.FindControl("txtboxAccountName")).Text.Length > 0)
                {
                    ContactAccount CntAcc = new ContactAccount();
                    ////////// Save New Account /////
                    CntAcc.AccountName = ((TextBox)frmViewAccountDetails.FindControl("txtboxAccountName")).Text;
                    CntAcc.BusSector = int.Parse(((DropDownList)frmViewAccountDetails.FindControl("ddlBusSector")).SelectedValue);
                    CntAcc.City = ((TextBox)frmViewAccountDetails.FindControl("txtboxCity")).Text;
                    CntAcc.Profile = ((TextBox)frmViewAccountDetails.FindControl("txtProfile")).Text;
                    CntAcc.TopAccount = ((CheckBox)frmViewAccountDetails.FindControl("cbxTop")).Checked;
                    CntAcc.CountryID = int.Parse(((DropDownList)frmViewAccountDetails.FindControl("ddlCountry")).SelectedValue);
                    CntAcc.Fax = ((TextBox)frmViewAccountDetails.FindControl("txtboxFax")).Text;
                    CntAcc.Phone = ((TextBox)frmViewAccountDetails.FindControl("txtboxPhone")).Text;
                    CntAcc.ReferedBy = ((TextBox)frmViewAccountDetails.FindControl("txtboxRefBy")).Text;
                    CntAcc.IDStatus = int.Parse(((DropDownList)frmViewAccountDetails.FindControl("ddlStatus")).SelectedValue);
                    CntAcc.Street1 = ((TextBox)frmViewAccountDetails.FindControl("txtboxStreet1")).Text;
                    CntAcc.Street2 = ((TextBox)frmViewAccountDetails.FindControl("txtboxStreet2")).Text;
                    string WebSite = ((TextBox)frmViewAccountDetails.FindControl("txtboxWebsite")).Text;
                    if (WebSite != "")
                        CntAcc.WebSite = WebSite.ToLower().StartsWith("http://") ? WebSite : "http://" + WebSite;
                    else
                        CntAcc.WebSite = "";
                    ((TextBox)frmViewAccountDetails.FindControl("txtboxWebsite")).Text = CntAcc.WebSite;
                    CntAcc.Email = ((TextBox)frmViewAccountDetails.FindControl("txtEmailEdit")).Text;
                    CntAcc.ZipCode = ((TextBox)frmViewAccountDetails.FindControl("txtboxZipCode")).Text;
                    CntAcc.CountryID = int.Parse(((DropDownList)frmViewAccountDetails.FindControl("ddlCountry")).SelectedItem.Value);
                    if (((DropDownList)frmViewAccountDetails.FindControl("ddlCountry")).SelectedItem.Text.Trim().ToLower() == "united states")
                        CntAcc.State = ((DropDownList)frmViewAccountDetails.FindControl("ddlState")).SelectedValue;
                    else
                        CntAcc.State = ((TextBox)frmViewAccountDetails.FindControl("txtState")).Text;
                    ////////////////////////////////
                    CntAcc.EnterByID = ((ASIIdentity)User.Identity).UserID;
						 
						 
                    CntAcc.EnterDate = DateTime.Now;
                    CntAcc.EditByID = ((ASIIdentity)User.Identity).UserID;
                    CntAcc.EditDate = DateTime.Now;
                    ////////////////////////////////
                    if (((DropDownList)frmViewAccountDetails.FindControl("ddlAccountMan")).Enabled)
                    {
                        if (((DropDownList)frmViewAccountDetails.FindControl("ddlAccountMan")).SelectedValue != "-----")
                        {
                            CntAcc.AccountManagerID = int.Parse(((DropDownList)frmViewAccountDetails.FindControl("ddlAccountMan")).SelectedValue);
                            CntAcc.AccountManagerAssignedDate = DateTime.Now;
                            CntAcc.AccountManagerEditByID = ((ASIIdentity)User.Identity).UserID;
                            CntAcc.AccountManagerEditDate = DateTime.Now;
                        }
                    }

                    int AffectedRow = CntAcc.AddNewContactAccount();

                    if (AffectedRow > 0)
                    {
                        // added by sayed 5/9/2011
                        Panel1.Visible = true;
                        //
                        Session["NewAccount"] = false;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "EnableTab();", true);
                        lblMsg.Text = "Account Added Successfully";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        lblMsg.Visible = true;
                        UpdateURLText();
                        AdjustTransButtons(false);
                        AdjustReadOnlyFormStatus(true);

                        //Commented By Ehab (2008-04-16)
                        //UnCommented By Yasser (2008-08-04)
                        ViewState["Country"] = ((DropDownList)frmViewAccountDetails.FindControl("ddlCountry")).SelectedItem.Text;
                        Office.BLL.AccountsBLL.Filter ftr = (Office.BLL.AccountsBLL.Filter)Session["FilterField"];
                        ftr.LocationName = "-1";
                        Session["FilterField"] = ftr;
                        ContactAccount CA = new ContactAccount();
                        CA = (ContactAccount)Session["Account"];
                        CA.CountryName = ViewState["Country"].ToString();
                        Session["Account"] = CA;
                        Session["CurrentSelectedRowIndex"] = GetAccountItemOrderNo(AffectedRow);
                        GetSearchFilter(ViewState["orderbyField"].ToString(), ViewState["SortType"].ToString(), ViewState["SpecificAccount"].ToString(), ViewState["AccountID"].ToString(), ViewState["Country"].ToString());
                       // ViewState["AccountID"] = AffectedRow;//30-4-2012
                        LoadSearchPrameters();
                        BindFormView();
                        AddjustDropDownListsSelection();
                        InsertFakeRecord();
                        gvNotesBindData();
                        AdjustReadOnlyFormStatus(true); 
                    }
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Company name can't be empty.";
                    lblMsg.Visible = true;
                }

            }

            else if (ViewState["SaveMode"].ToString() == "Update")
            {
                UpdateAccount();
                lblMsg.ForeColor = System.Drawing.Color.Green;
                Session["NewAccount"] = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "EnableTab();", true);
                lblMsg.Text = "Account Updated Successfully";
                lblMsg.Visible = true;
                ViewState["Country"] = ((DropDownList)frmViewAccountDetails.FindControl("ddlCountry")).SelectedItem.Text;
                Office.BLL.AccountsBLL.Filter ftr = (Office.BLL.AccountsBLL.Filter)Session["FilterField"];
                ftr.LocationName = "-1";
                Session["FilterField"] = ftr;
                ContactAccount CA = new ContactAccount();
                CA = (ContactAccount)Session["Account"];
                CA.CountryName = ViewState["Country"].ToString();
                Session["Account"] = CA;
                Session["CurrentSelectedRowIndex"] = GetAccountItemOrderNo(Convert.ToInt32(frmViewAccountDetails.SelectedValue));
                // Added By Fawzi
                LoadSearchPrameters();
                BindFormView();
                AddjustDropDownListsSelection();
                //
                AdjustTransButtons(false);
                AdjustReadOnlyFormStatus(true);
                //
            }

            AdjustNextPreviousButtons();
        }
    }
    protected void ucTransToolBar_btnDeleteEvent(object sender, EventArgs e)
    {
        int AccountID;
        if (int.TryParse(frmViewAccountDetails.SelectedValue.ToString(), out AccountID))
            lblMsg.Text = DeleteAccountByID(AccountID);

        if (lblMsg.Text == "Account deleted successfully!")
        {
            ViewState["AccountDeleted"] = true;
            ViewState["AccountID"] = "";
            Session["SingleAccountID"] = null;
            Session["CurrentNote"] = null;
            Session["CurrentAID"] = null;
            ViewState["orderbyField"] = "AccountName";
            ViewState["SortType"] = "Desc"; 
            ViewState["NoteSortType"] = "ASC";
            ViewState["SpecificAccount"] = "";
            LoadSearchPrameters();
            BindFormView();
            AddjustDropDownListsSelection();
            InsertFakeRecord();
            gvNotesBindData();
            //BranchForm1.AccountID = 0;

            if (Session["AccountID_branch"] != null)
            {
                //if (Session["AccountID_branch"].ToString() != "")
                    //BranchForm1.AccountID = Int32.Parse(Session["AccountID_branch"].ToString());
            }
        }
        else
            ViewState["AccountDeleted"] = true;
    }
    
	protected void ucUserTabs_btnAccountsEvent(object sender, EventArgs e)
    {
        Response.Redirect("Accounts.aspx");
    }
    protected void ucUserTabs_btnContactListsEvent(object sender, EventArgs e)
    {
        Response.Redirect("ContactLists.aspx");
    }
    protected void ucUserTabs_btnContantsEvent(object sender, EventArgs e)
    {
        Response.Redirect("Contacts.aspx");
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
   
	protected void ucAutoCompleteSearch_btnSearchEvent(object sender, EventArgs e)
    {
        lblEmptyResults.Visible = false;
       // NoteState();
        imgbtnHistory_Click(null, null);
        RestFormView();
        SetSpecificAccountFilter();
        LoadSearchPrameters();
        BindFormView();
        AdjustTransButtons(false);
        Panel1.Visible = frmViewAccountDetails.DataKey.Value != null;
        if (frmViewAccountDetails.DataKey.Value == null)
        {
            ((ImageButton)ucTransToolBar.FindControl("btnEdit")).Visible = false;
            ((ImageButton)ucTransToolBar.FindControl("btnDelete")).Visible = false;
            ((ImageButton)ucTransToolBar.FindControl("btnAdd")).Visible = false;
            lblEmptyResults.Visible = true;
        }
        else
            Session["SelectedAccountID"] = frmViewAccountDetails.SelectedValue;

        if (frmViewAccountDetails.FindControl("ddlAccountMan") == null)
        {
            ((ImageButton)ucTransToolBar.FindControl("btnEdit")).Visible = false;
            ((ImageButton)ucTransToolBar.FindControl("btnDelete")).Visible = false;
            ((ImageButton)ucTransToolBar.FindControl("btnAdd")).Visible = false;
            lblEmptyResults.Visible = true;
            ShowTabHeaders(false);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "DisableTab();", true);
          
        }
        else
        {
            ViewState["ManagerChanged"] = "False";
            Session["CurrentNote"] = null;
            Session["CurrentContact"] = null;
            Session["NewAccount"] = false;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "EnableTab();", true);
            gvNotesBindData();
            imgNotesTab.Enabled = false;
            imgNotesTab.ImageUrl = "Images/notes_normal.png";
            imgContactsTab.Enabled = true;
            imgContactsTab.ImageUrl = "Images/contacts_normal.png";
            imgbtnSubCompanies.ImageUrl = "Images/SubCompanies-n.png";
            imgbtnSubCompanies.Enabled = true;
            lblEmptyResults.Visible = false;
        }
        imgbtnNext.Visible = false;
        imgbtnPrevious.Visible = false;
        AddjustDropDownListsSelection();
        Session["CurrentNote"] = null;
        gvNotesBindData();
    }

    private void ShowTabHeaders(bool Show)
    {
        imgNotesTab.Visible = Show;
        imgContactsTab.Visible = Show;
        imgbtnSubCompanies.Visible = Show;
        imgbtnKeySoftware.Visible = Show;
        imgbtnHistory.Visible = Show;
        imgbtnAttachments.Visible = Show;
    }
    #endregion

    #region DDL Functions
    protected void ddlAccountMan_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["ManagerChanged"] = "True";
    }
    protected void ddlAccountMan_DataBound(object sender, EventArgs e)
    {
        InsertFakeRecord();
    }
    //To set the right selection 
    private void AddjustDropDownListsSelection()
    {
        if (frmViewAccountDetails.FindControl("ddlStatus") != null && frmViewAccountDetails.FindControl("ddlCountry") != null &&
           frmViewAccountDetails.FindControl("ddlBusSector") != null && frmViewAccountDetails.FindControl("ddlAccountMan") != null)
        {
            ((DropDownList)frmViewAccountDetails.FindControl("ddlStatus")).SelectedValue = ((TextBox)frmViewAccountDetails.FindControl("txtStatus")).Text;
            ((DropDownList)frmViewAccountDetails.FindControl("ddlCountry")).SelectedValue = ((TextBox)frmViewAccountDetails.FindControl("txtCountryID")).Text;
            AdjustCountryStateSelection();
            ((DropDownList)frmViewAccountDetails.FindControl("ddlBusSector")).SelectedValue = ((TextBox)frmViewAccountDetails.FindControl("txtBusSector")).Text;
            if (int.Parse(((TextBox)frmViewAccountDetails.FindControl("txtAccMngr")).Text) != int.MinValue)
                ((DropDownList)frmViewAccountDetails.FindControl("ddlAccountMan")).SelectedValue = ((TextBox)frmViewAccountDetails.FindControl("txtAccMngr")).Text;
            else
                ((DropDownList)frmViewAccountDetails.FindControl("ddlAccountMan")).SelectedValue = "-----";
        }
    }
    private void InsertFakeRecord()
    {
        if (((DropDownList)frmViewAccountDetails.FindControl("ddlAccountMan")) != null)
        {
            if (((DropDownList)frmViewAccountDetails.FindControl("ddlAccountMan")).Items.Count > 0 &&
                ((DropDownList)frmViewAccountDetails.FindControl("ddlAccountMan")).Items[0].Value.Trim() != "-----")
            {
                ListItem FirstItem = new ListItem("-----", "-----");
                ((DropDownList)frmViewAccountDetails.FindControl("ddlAccountMan")).Items.Insert(0, FirstItem);
            }
        }
    }
    #endregion

    #region SubCompanies Events
    public void btnNewSubCompany_Click(object sender, ImageClickEventArgs e)
    {
        if (frmViewAccountDetails.SelectedValue != null)
        {
            ddlCompanyName.Items.Clear();
            ddlCompanyName.DataSource = odsAccountNames;
            ddlCompanyName.DataBind();
            string AccountID = frmViewAccountDetails.SelectedValue.ToString();
            ddlParent.Enabled = false;
            ddlParent.SelectedValue = AccountID;
            ddlCompanyName.Enabled = true;
            ViewState["AddSubCompany"] = true;
            mdlPopup.Show();
        }
        
    }

    //public void imgBtnNew_Click(object sender, ImageClickEventArgs e)
    //{
    //    mdlPopup.Show();
    //    BranchForm1.CimgbtnNew_Click(sender, e);

    //}
    public void imgBtnSave_Click(object sender, ImageClickEventArgs e)
    {

        if (ViewState["AddSubCompany"] != null)
        {
            if (ddlCompanyName.SelectedIndex != -1)
            {
                if (ddlHirarchyType.SelectedIndex != -1)
                {
                    int CompanyID = Convert.ToInt32(ddlCompanyName.SelectedValue);
                    int ParentID = Convert.ToInt32(ddlParent.SelectedValue);
                    int TypeID = Convert.ToInt32(ddlHirarchyType.SelectedValue);

                    if (CompanyID != ParentID)
                    {
                        if (ddlParent.SelectedValue != GetAccountParent(CompanyID).ToString())
                        {
                            if (ViewState["AddSubCompany"].Equals(true))
                            {

                                if (AddAccountHierarchy(CompanyID, ParentID, TypeID))
                                {
                                    lblMsg.Text = "Sub account added successfully!";
                                    SubAccounts1.BindGrid();
                                }
                                else
                                    lblMsg.Text = "Error while adding new sub account.";
                            }
                            else if (ViewState["AddSubCompany"].Equals(false))
                            {
                                if (UpdateAccountHierarchy(CompanyID, ParentID, TypeID))
                                {
                                    lblMsg.Text = "Sub account updated successfully!";
                                    SubAccounts1.BindGrid();
                                }
                                else
                                    lblMsg.Text = "Error while updating new sub account.";
                            }
                        }
                        else
                            lblMsg.Text = "Duplicated sub account.";
                    }
                    else
                        lblMsg.Text = "Account can't be sub account of it self.";
                }
            }
        }
        
        mdlPopup.Hide();
        //if (BranchForm1.BtnSave())
        //{
        //    BranchesGrid1.BindGrid();
        //    mdlPopup.Hide();
        //}
    }
    //protected void btnNewEditBranch1_Click(object sender, EventArgs e)
    //{
    //    mdlPopup.Show();
    //    BranchForm1.LoadControlData();

    //}
    //protected void BranchesGrid1_BranchDeletingEvent(object sender, EventArgs e)
    //{
    //    lblMsg.Text = BranchesGrid1.ActionResult;
    //    gvNotesBindData();
    //    BranchesGrid1.BindGrid();
    //}
    #endregion

    #region Accounts Functions
    private void AdjustAccountManagerControls()
    {
        Office.BLL.AccountListsBLL ALB = new Office.BLL.AccountListsBLL();
        if (frmViewAccountDetails.FindControl("ddlAccountMan") != null && !User.IsInRole("AccountManager"))
            ((DropDownList)frmViewAccountDetails.FindControl("ddlAccountMan")).Enabled = false;
    }
    private void RestFormView()
    {
        ViewState["AccountID"] = "";
        frmViewAccountDetails.PageIndex = 0;
    }
    private void ResetFormtxtboxes(bool New)
    {
        ((TextBox)frmViewAccountDetails.FindControl("txtAccID")).Text = "";
        ((TextBox)frmViewAccountDetails.FindControl("txtAccountNo")).Text = "";
        ((TextBox)frmViewAccountDetails.FindControl("txtboxAccountName")).Text = "";
        ((TextBox)frmViewAccountDetails.FindControl("txtBusSector")).Text = "";
        ((TextBox)frmViewAccountDetails.FindControl("txtboxCity")).Text = "";
        ((TextBox)frmViewAccountDetails.FindControl("txtProfile")).Text = "";
        ((TextBox)frmViewAccountDetails.FindControl("txtboxFax")).Text = "";
        ((TextBox)frmViewAccountDetails.FindControl("txtboxPhone")).Text = "";
        ((TextBox)frmViewAccountDetails.FindControl("txtboxRefBy")).Text = "";
        ((TextBox)frmViewAccountDetails.FindControl("txtStatus")).Text = "";
        ((TextBox)frmViewAccountDetails.FindControl("txtboxStreet1")).Text = "";
        ((TextBox)frmViewAccountDetails.FindControl("txtboxStreet2")).Text = "";
        ((TextBox)frmViewAccountDetails.FindControl("txtboxWebsite")).Text = "";
        ((TextBox)frmViewAccountDetails.FindControl("txtEmailEdit")).Text = "";
        ((TextBox)frmViewAccountDetails.FindControl("txtboxZipCode")).Text = "";
        ((TextBox)frmViewAccountDetails.FindControl("txtState")).Text = "";
        //
        ((CheckBox)frmViewAccountDetails.FindControl("cbxTop")).Checked = false;
        ((DropDownList)frmViewAccountDetails.FindControl("ddlStatus")).SelectedIndex = 0;
        ((DropDownList)frmViewAccountDetails.FindControl("ddlCountry")).SelectedIndex = 230;
        ((DropDownList)frmViewAccountDetails.FindControl("ddlState")).SelectedIndex = 0;
        ((DropDownList)frmViewAccountDetails.FindControl("ddlBusSector")).SelectedIndex = 0;
        ((TextBox)frmViewAccountDetails.FindControl("txtCountryID")).Text = ((DropDownList)frmViewAccountDetails.FindControl("ddlCountry")).SelectedValue;
        AdjustCountryStateSelection();
        //
        if (frmViewAccountDetails.FindControl("ddlAccountMan") != null)
        {
            ((DropDownList)frmViewAccountDetails.FindControl("ddlAccountMan")).SelectedIndex = 0;
            ((TextBox)frmViewAccountDetails.FindControl("txtboxCurrentDate")).Text = "";
            ((TextBox)frmViewAccountDetails.FindControl("txtboxEditby")).Text = "";
            ((TextBox)frmViewAccountDetails.FindControl("txtboxCurrentDate2")).Text = "";
        }

        //
        ContactNotes CNote = new ContactNotes();
        CNote.AccountID = -1;
        Session["CurrentNote"] = CNote;
        gvNotes.DataSource = odsNotes;
        gvNotes.DataBind();

        ContactContactsInfo CCI = new ContactContactsInfo();
        CCI.AccountID = -1;
        Session["CurrentContact"] = CCI;
        Contacts1.BindGridView();

        if (!New)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "DisableTab();", true);
        }
    }
    private void UpdateAccount()
    {
        ContactAccount CntAcc = new ContactAccount();
        //////////Edit Existing Account by Account ID /////
        string AccountID = frmViewAccountDetails.SelectedValue.ToString();
        CntAcc.AccountID = int.Parse(AccountID);
        //
        TextBox txtboxAccountName = (TextBox)frmViewAccountDetails.FindControl("txtboxAccountName");
        CntAcc.AccountName = txtboxAccountName.Text;
        //
        CntAcc.BusSector = int.Parse(((DropDownList)frmViewAccountDetails.FindControl("ddlBusSector")).SelectedValue);
        //
        TextBox txtboxCity = (TextBox)frmViewAccountDetails.FindControl("txtboxCity");
        CntAcc.City = txtboxCity.Text;
        //Profile
        CntAcc.Profile = ((TextBox)frmViewAccountDetails.FindControl("txtProfile")).Text;
        //TopAccount
        CntAcc.TopAccount = ((CheckBox)frmViewAccountDetails.FindControl("cbxTop")).Checked;
        //Country
        CntAcc.CountryID = int.Parse(((DropDownList)frmViewAccountDetails.FindControl("ddlCountry")).SelectedValue);
        //State
        if (((DropDownList)frmViewAccountDetails.FindControl("ddlCountry")).SelectedItem.Text.Trim().ToLower() == "united states") 
            CntAcc.State = ((DropDownList)frmViewAccountDetails.FindControl("ddlState")).SelectedValue;
        else
            CntAcc.State = ((TextBox)frmViewAccountDetails.FindControl("txtState")).Text;
        //FAX
        TextBox txtboxFax = (TextBox)frmViewAccountDetails.FindControl("txtboxFax");
        CntAcc.Fax = txtboxFax.Text;
        //
        TextBox txtboxPhone = (TextBox)frmViewAccountDetails.FindControl("txtboxPhone");
        CntAcc.Phone = txtboxPhone.Text;
        //
        TextBox txtboxRefBy = (TextBox)frmViewAccountDetails.FindControl("txtboxRefBy");
        CntAcc.ReferedBy = txtboxRefBy.Text;
        //
        CntAcc.IDStatus = int.Parse(((DropDownList)frmViewAccountDetails.FindControl("ddlStatus")).SelectedValue);
        //
        TextBox txtboxStreet1 = (TextBox)frmViewAccountDetails.FindControl("txtboxStreet1");
        CntAcc.Street1 = txtboxStreet1.Text;
        //
        TextBox txtboxStreet2 = (TextBox)frmViewAccountDetails.FindControl("txtboxStreet2");
        CntAcc.Street2 = txtboxStreet2.Text;
        //
        string WebSite = ((TextBox)frmViewAccountDetails.FindControl("txtboxWebsite")).Text;
        if (WebSite != "")
            CntAcc.WebSite = WebSite.ToLower().StartsWith("http://") ? WebSite : "http://" + WebSite;
        else
            CntAcc.WebSite = WebSite;
        ((TextBox)frmViewAccountDetails.FindControl("txtboxWebsite")).Text = CntAcc.WebSite;
        //
        TextBox txtboxZipCode = (TextBox)frmViewAccountDetails.FindControl("txtboxZipCode");
        CntAcc.ZipCode = txtboxZipCode.Text;
       CntAcc.Email=((TextBox)frmViewAccountDetails.FindControl("txtEmailEdit")).Text;
        ////////////////////////////////
        CntAcc.EditByID = ((ASIIdentity)User.Identity).UserID;
        CntAcc.EditDate = DateTime.Now;
        // commented by fawzi //
        //if (((DropDownList)frmViewAccountDetails.FindControl("ddlAccountMan")).Enabled && ViewState["ManagerChanged"] != null && ViewState["ManagerChanged"].ToString() == "True")
        //{
            if (((DropDownList)frmViewAccountDetails.FindControl("ddlAccountMan")).SelectedValue != "-----")
            {
                CntAcc.AccountManagerID = int.Parse(((DropDownList)frmViewAccountDetails.FindControl("ddlAccountMan")).SelectedValue);
                CntAcc.AccountManagerEditByID = ((ASIIdentity)User.Identity).UserID;
                CntAcc.AccountManagerEditDate = DateTime.Now;
            }
            ViewState["ManagerChanged"] = "False";
        //}
        CntAcc.UpdateContactAccount();
        UpdateURLText();
    }
    protected void frmViewAccountDetails_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {
        frmViewAccountDetails.PageIndex = e.NewPageIndex;
        
        // reload the search paramter - mglil
        //ViewState["orderbyField"] = "AccountName";
        LoadSearchPrameters();
        if (Session["CurrentSelectedRowIndex"] != null)
        {
            ContactAccount CA = (ContactAccount)Session["Account"];
            if (Session["FilterField"] == null)
                Session["FilterField"] = new Office.BLL.AccountsBLL.Filter();

            Office.BLL.AccountsBLL.Filter fltr = ((Office.BLL.AccountsBLL.Filter)Session["FilterField"]);

            switch (fltr.IncrementalSearch)
            {
                case "Company":
                    CA.AccountName = (fltr.IncrementalSearchValue != "") ? fltr.IncrementalSearchValue : null;
                    break;

                case "Business Sector":
                    CA.BusinessSectorName = (fltr.IncrementalSearchValue != "") ? fltr.IncrementalSearchValue : null;
                    if (fltr.IncrementalSearchValue != "")
                        fltr.BusSector = fltr.IncrementalSearchValue;
                    break;
            }

            CA.IDStatus = (fltr.StatusID != -1) ? fltr.StatusID : null;
            CA.BusinessSectorName = (fltr.BusSector != "-1") ? fltr.BusSector : null;
            CA.FilterAccountNotes = Convert.ToInt32(Session["FilterAccountNotes"]);

            Session["Account"] = CA;
        }
        // end - mglil
        //vip : do this
        BindFormView();
        AddjustDropDownListsSelection();
        AdjustAccountManagerControls();
        ViewState["ManagerChanged"] = "False";
        Session["CurrentNote"] = null;
        ViewState["NoteSortType"] = "ASC";
        Session["CurrentContact"] = null;
        Session["NewAccount"] = false;
        if (sender != null)
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "EnableTab();", true);
        OrderBy("UserEnterDate");
        LoadNoteSearchPrameters();
        gvNotesBindData();
        imgNotesTab.Enabled = false;
        imgNotesTab.ImageUrl = "Images/notes_normal.png";
        imgContactsTab.Enabled = true;
        imgContactsTab.ImageUrl = "Images/contacts_normal.png";
        imgbtnSubCompanies.ImageUrl = "Images/SubCompanies-n.png";
        imgbtnSubCompanies.Enabled = true;
        // added by Sayed 19/9/2011
        TabContainer1_ActiveTabChanged(null, null);
        //
        SubAccounts1.BindGrid();
        //BranchesGrid1.BindGrid();
        Contacts1.BindGridView();
        //BranchesGrid1.ResetGridSelection();
        Key1.BindGridView();
        HistoryNC1.BindGridView();
        Attachment1.BindGridView();
        // end 
        AdjustTransButtons(false); 
    }
    private void BindFormView()
    {
        frmViewAccountDetails.DataSource = odsAccountsDetails;
        frmViewAccountDetails.DataBind();
        if (frmViewAccountDetails.SelectedValue != null)
        {
            int AID;
            if (int.TryParse(frmViewAccountDetails.SelectedValue.ToString(), out AID))
                Session["CurrentAID"] = AID;
            string ParentID = GetAccountParent(AID).ToString();
            DropDownList ddlParent = (DropDownList)frmViewAccountDetails.FindControl("ddlParent");
            //ddlParent.DataBind();
            if (ParentID != "-1")
                ddlParent.SelectedValue = ParentID;
            else
                ddlParent.SelectedIndex = 0;
        }
        else
            lblMsg.Text = "Account doesn't exist.";
        //
            if (frmViewAccountDetails.PageIndex == 0)
            {
                imgbtnPrevious.Visible = false;
            }
            else 
            {
                imgbtnPrevious.Visible = true;
            }
            //
            if (frmViewAccountDetails.PageIndex == frmViewAccountDetails.PageCount)
            {
                imgbtnNext.Visible = false;
            }
            else 
            {
                imgbtnNext.Visible = true;
            }
            //
           


    }
    protected void frmViewAccountDetails_DataBound(object sender, EventArgs e)
    {
        if (((TextBox)frmViewAccountDetails.FindControl("txtboxCurrentDate")) != null)
        {
            if (Convert.ToDateTime(((TextBox)frmViewAccountDetails.FindControl("txtboxCurrentDate")).Text) == DateTime.MinValue)
                ((TextBox)frmViewAccountDetails.FindControl("txtboxCurrentDate")).Text = "";
            else
                ((TextBox)frmViewAccountDetails.FindControl("txtboxCurrentDate")).Text = Convert.ToDateTime(((TextBox)frmViewAccountDetails.FindControl("txtboxCurrentDate")).Text).ToShortDateString();
        }
        if (((TextBox)frmViewAccountDetails.FindControl("txtboxCurrentDate2")) != null)
        {
            if (Convert.ToDateTime(((TextBox)frmViewAccountDetails.FindControl("txtboxCurrentDate2")).Text) == DateTime.MinValue)
                ((TextBox)frmViewAccountDetails.FindControl("txtboxCurrentDate2")).Text = "";
            else
                ((TextBox)frmViewAccountDetails.FindControl("txtboxCurrentDate2")).Text = Convert.ToDateTime(((TextBox)frmViewAccountDetails.FindControl("txtboxCurrentDate2")).Text).ToShortDateString();
        }

        //if (frmViewAccountDetails.SelectedValue != null)
        //    Session["AccountID_branch"] = frmViewAccountDetails.SelectedValue.ToString();
        //else
        //    Session["AccountID_branch"] = null;


    }
    private void UpdateURLText()
    {
        if (((TextBox)frmViewAccountDetails.FindControl("txtboxWebsite")) != null && ((TextBox)frmViewAccountDetails.FindControl("txtboxWebsite")).Text.Trim() != "")
        {
            ((HyperLink)frmViewAccountDetails.FindControl("hlWebSite")).Visible = true;
            ((HyperLink)frmViewAccountDetails.FindControl("hlWebSite")).Text = ((TextBox)frmViewAccountDetails.FindControl("txtboxWebsite")).Text;
            ((HyperLink)frmViewAccountDetails.FindControl("hlWebSite")).NavigateUrl = ((TextBox)frmViewAccountDetails.FindControl("txtboxWebsite")).Text;
        }
        else
        {
            ((HyperLink)frmViewAccountDetails.FindControl("hlWebSite")).Text = "";
            ((HyperLink)frmViewAccountDetails.FindControl("hlWebSite")).NavigateUrl = "";
            ((HyperLink)frmViewAccountDetails.FindControl("hlWebSite")).Visible = false;
        }

        if (((TextBox)frmViewAccountDetails.FindControl("txtEmailEdit")) != null && ((TextBox)frmViewAccountDetails.FindControl("txtEmailEdit")).Text.Trim() != "")
        {
            ((HyperLink)frmViewAccountDetails.FindControl("hlEmail")).Visible = true;
            ((HyperLink)frmViewAccountDetails.FindControl("hlEmail")).Text = ((TextBox)frmViewAccountDetails.FindControl("txtEmailEdit")).Text;
            ((HyperLink)frmViewAccountDetails.FindControl("hlEmail")).NavigateUrl = ((TextBox)frmViewAccountDetails.FindControl("txtEmailEdit")).Text;
        }
        else
        {
            ((HyperLink)frmViewAccountDetails.FindControl("hlEmail")).Text = "";
            ((HyperLink)frmViewAccountDetails.FindControl("hlEmail")).NavigateUrl = "";
            ((HyperLink)frmViewAccountDetails.FindControl("hlEmail")).Visible = false;
        }
    }
    #endregion

    #region Accounts Filter Functions
    private void LoadSearchPrameters()
    {
        Session["Account"] = GetSearchFilter(ViewState["orderbyField"].ToString(), ViewState["SortType"].ToString(), ViewState["SpecificAccount"].ToString(), ViewState["AccountID"].ToString(), ViewState["Country"].ToString());
    }
    /// <summary>
    /// new account load search paramter- mglil
    /// </summary>
    /// 
    private void LoadSearchPrameters(string AccountID)
    {
        ViewState["orderbyField"] = "";
        ViewState["AccountID"] = AccountID;
        ViewState["SpecificAccount"] = "";
        Session["Account"] = GetSearchFilter(ViewState["orderbyField"].ToString(), ViewState["SortType"].ToString(), ViewState["SpecificAccount"].ToString(), ViewState["AccountID"].ToString(), ViewState["Country"].ToString());
    }
    /// <summary>
    /// end - mglil
    /// </summary>
    private void SetSpecificAccountFilter()
    {
        TextBox objtxtSearch = (TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch");
        ViewState["SpecificAccount"] = objtxtSearch.Text;

    }
    #endregion

    #region Add & Edit Notes Functions
    protected void btnAddEditNotes_Click(object sender, EventArgs e)
    {
        if (Session["CurrentNote"] != null)
        {
            ShowNoteDataControls(true);

            txtEnteredDate.Text = ((ContactNotes)Session["CurrentNote"]).NoteDate.Value.ToShortDateString();
            txtEnteredTime.Text = ((ContactNotes)Session["CurrentNote"]).NoteDate.Value.ToShortTimeString();
            txtEnteredBy.Text = ((ContactNotes)Session["CurrentNote"]).EnteredByName;
            txtEditDate.Text = ((ContactNotes)Session["CurrentNote"]).EditDate.Value.ToShortDateString();
            txtEditTime.Text = ((ContactNotes)Session["CurrentNote"]).EditDate.Value.ToShortTimeString();
            txtEditBy.Text = ((ContactNotes)Session["CurrentNote"]).EditByName;
            txtContact.Text = ((ContactNotes)Session["CurrentNote"]).ContactFirstName + " " + ((ContactNotes)Session["CurrentNote"]).ContactLastName;
            txtNote.Value = ((ContactNotes)Session["CurrentNote"]).Notes;
            if (((ContactNotes)Session["CurrentNote"]).UserEnterDate.HasValue)
            {
                DateTime dt = ((ContactNotes)Session["CurrentNote"]).UserEnterDate.Value;
                int hours;
                if (dt.Hour > 11)
                {
                    hours = (dt.Hour > 12) ? dt.Hour - 12 : 12;
                    ddlTime.SelectedValue = "PM";
                }
                else
                {
                    hours = (dt.Hour > 0) ? dt.Hour : 12;
                    ddlTime.SelectedValue = "AM";
                }
                txtHours.Text = hours.ToString();
                txtMin.Text = ((ContactNotes)Session["CurrentNote"]).UserEnterDate.Value.Minute.ToString();
                txtUserNoteDate.Text = ((ContactNotes)Session["CurrentNote"]).UserEnterDate.Value.ToShortDateString();
            }
            else
                txtUserNoteDate.Text = "";
        }
        else
        {
            txtEnteredDate.Text = "";
            txtEnteredTime.Text = "";
            txtEnteredBy.Text = "";
            txtEditDate.Text = "";
            txtEditTime.Text = "";
            txtEditBy.Text = "";
            txtContact.Text = "";
            ShowNoteDataControls(false);

            txtNote.Value = "";
            int hours;
            if (DateTime.Now.Hour > 11)
            {
                hours = (DateTime.Now.Hour > 12) ? DateTime.Now.Hour - 12 : 12;
                ddlTime.SelectedValue = "PM";
            }
            else
            {
                hours = (DateTime.Now.Hour > 0) ? DateTime.Now.Hour : 12;
                ddlTime.SelectedValue = "AM";
            }
            txtHours.Text = hours.ToString();
            txtMin.Text = DateTime.Now.Minute.ToString();
            txtUserNoteDate.Text = "";
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Session["CurrentNote"] = null;
        txtEnteredDate.Text = "";
        txtEnteredTime.Text = "";
        txtEnteredBy.Text = "";
        txtEditDate.Text = "";
        txtEditTime.Text = "";
        txtEditBy.Text = "";
        txtContact.Text = "";
        ShowNoteDataControls(false);

        txtNote.Value = "";

        int hours;
        if (DateTime.Now.Hour > 11)
        {
            hours = (DateTime.Now.Hour > 12) ? DateTime.Now.Hour - 12 : 12;
            ddlTime.SelectedValue = "PM";
        }
        else
        {
            hours = (DateTime.Now.Hour > 0) ? DateTime.Now.Hour : 12;
            ddlTime.SelectedValue = "AM";
        }

        txtHours.Text = hours.ToString();
        txtMin.Text = DateTime.Now.Minute.ToString();
        txtUserNoteDate.Text = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (hdnNote.Value.Length > 0)
        {
            DateTime? EDate;
            DateTime Date;
            string strDate = txtUserNoteDate.Text;

            if (txtHours.Text.Length > 0 || txtMin.Text.Length > 0)
            {
                if (txtHours.Text.Length > 0)
                {
                    int hours;
                    if (ddlTime.SelectedValue == "PM")
                    {
                        if (txtHours.Text == "12")
                            hours = 12;
                        else
                            hours = Convert.ToInt32(txtHours.Text) + 12;
                    }
                    else
                    {
                        if (txtHours.Text == "12")
                            hours = 0;
                        else
                            hours = Convert.ToInt32(txtHours.Text);
                    }

                    strDate += " " + hours.ToString();
                }
                else
                    strDate += " 00";

                if (txtMin.Text.Length > 0)
                {
                    strDate += ":" + txtMin.Text;
                }
                else
                    strDate += ":00";

                strDate += ":00";
            }
            else
                strDate += " 00:00:00";

            if (DateTime.TryParse(strDate, out Date))
                EDate = Date;
            else
                EDate = null;

            if (txtContact.Text.Length > 0 && Session["CurrentNote"] != null)
            {
                if (UpdateContactNote(((ContactNotes)Session["CurrentNote"]).NID.Value, AdjustWordsLengths(hdnNote.Value), EDate))
                {
                    lblMsg.Text = "Note has been updated successfully!";
                    txtCalender.Text = "";
                }
                else
                    lblMsg.Text = "Error while updating note.";
            }
            else if (txtContact.Text.Length == 0)
            {
                int AID;
                if (int.TryParse(frmViewAccountDetails.SelectedValue.ToString(), out AID))
                {
                    if (AddContactNote(AdjustWordsLengths(hdnNote.Value), AID, EDate))
                    {
                        lblMsg.Text = "Note has been added successfully!";
                        txtCalender.Text = "";
                    }
                    else
                        lblMsg.Text = "Error while adding note.";
                }
                else
                    lblMsg.Text = "Please choose an account to add notes for it.";
            }
        }
        else 
        {
            lblMsg.Text = "Error while adding note, Empty data is Not Allowed !!!";
        
        }
        //ShowNoteDataControls(true);
        Session["CurrentNote"] = null;
        ViewState["NoteSortType"] = "ASC";
        OrderBy("UserEnterDate");
        LoadNoteSearchPrameters();
        gvNotesBindData();
        PopupControlExtender1.Cancel();
        //System.Web.UI.ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "click", "alert('ok')", true);
    }
    protected string AdjustWordsLengths(string Input)
    {
        StringBuilder Result = new StringBuilder();
        string[] Inputs = Input.Replace("&nbsp;", "").Split(' ');

        foreach (string str in Inputs)
        {
            if (str.Length > 30)
            {
                for (int i = 0; i < str.Length; i+=30)
                {
                    Result.Append(str.Substring(i, (str.Length >= i + 30) ? 30 : str.Length - i));
                    Result.Append(' ');
                }
            }
            else
            {
                Result.Append(str);
            }

            Result.Append(' ');
        }

        return Result.ToString();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //ShowNoteDataControls(true);
        PopupControlExtender1.Cancel();
    }
    protected void ShowNoteDataControls(bool Show)
    {
        txtEnteredDate.Visible = Show;
        txtEnteredTime.Visible = Show;
        txtEnteredBy.Visible = Show;
        txtEditDate.Visible = Show;
        txtEditTime.Visible = Show;
        txtEditBy.Visible = Show;
        txtContact.Visible = Show;
        lblEnteredDate.Visible = Show;
        lblEnteredTime.Visible = Show;
        lblEnteredBy.Visible = Show;
        lblEditDate.Visible = Show;
        lblEditTime.Visible = Show;
        lblEditBy.Visible = Show;
        lblContact.Visible = Show;
    }
    #endregion

    #region Notes Filter Functions
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetContactList(string prefixText, int count, string contextKey)
    {
        ContactNotes CntNt = new ContactNotes();
        AccountLists AccLst = new AccountLists();
        string[] CntNames = CntNt.GetAccountRelatedNotesContactsFirstName(prefixText + "%", Convert.ToInt32(AccLst.Session["CurrentAID"]));
        return CntNames;
    }
    protected void btnSearchNoteContact_Click(object sender, EventArgs e)
    {
        txtSearchNote.Text = "";

        if (txtSearchContact.Text.Length > 0)
        {
            ContactNotes CNote = new ContactNotes();
            CNote.ContactFirstName = txtSearchContact.Text;
            Session["CurrentNote"] = CNote;
        }
        else
            Session["CurrentNote"] = null;
        gvNotesBindData();
    }
    protected void txtCalender_TextChanged(object sender, EventArgs e)
    {
        DateTime EDate;
        if (DateTime.TryParse(txtCalender.Text, out EDate))
        {
            ContactNotes CNote = new ContactNotes();
            CNote.UserEnterDate = EDate;
            Session["CurrentNote"] = CNote;
        }
        else
            Session["CurrentNote"] = null;
        gvNotesBindData();
    }
    protected void txtFilterDate_TextChanged(object sender, EventArgs e)
    {
        /*DateTime EDate;
        if (DateTime.TryParse(txtCalender.Text, out EDate))
        {
            ContactContactsInfo CCI = new ContactContactsInfo();
            CCI..EditDate = EDate;
            Session["CurrentNote"] = CNote;
        }
        else
            Session["CurrentNote"] = null;
        gvNotes.DataBind();*/
    }
    private void LoadNoteSearchPrameters()
    {
        Session["CurrentNote"] = GetNotesSortFilter(ViewState["orderbyField"].ToString(), ViewState["NoteSortType"].ToString());
    }
    private void OrderBy(string field)
    {
        if (ViewState["NoteSortType"].ToString().Trim() == "ASC".Trim())
            ViewState["NoteSortType"] = "Desc";
        else
            ViewState["NoteSortType"] = "ASC";

        //ViewState["orderbyField"] = field;
    }
    protected void btnSearchNote_Click(object sender, EventArgs e)
    {
        if (txtSearchNote.Text.Length > 0 || txtSearchContact.Text.Length > 0)
        {
            ContactNotes CNote = new ContactNotes();

            if (txtSearchNote.Text.Length > 0)
                CNote.Notes = txtSearchNote.Text;
            if (txtSearchContact.Text.Length > 0)
                CNote.ContactFirstName = txtSearchContact.Text;

            Session["CurrentNote"] = CNote;
        }
        else
            Session["CurrentNote"] = null;

        gvNotesBindData();
    }
    #endregion

    #region Notes Grid Functions
    protected void gvNotes_SelectedIndexChanged(object sender, EventArgs e)
    {
        int NoteID = (int)(gvNotes.DataKeys[gvNotes.SelectedIndex].Values["NID"]);
        Session["CurrentNote"] = new AccountListsBLL().GetContactNote(NoteID);
    }
    protected void gvNotes_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='none';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvNotes, "Select$" + e.Row.RowIndex);
            foreach (TableCell tc in e.Row.Cells)
            {
                tc.CssClass = "GridCellStyle";
            }
        }
    }
    protected void gvNotes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // show next and previous
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            Table pagerTable = (Table)e.Row.Cells[0].Controls[0];
            TableRow pagerRow = pagerTable.Rows[0];
            PagerSettings pagerSettings = ((GridView)sender).PagerSettings;
            int cellsCount = pagerRow.Cells.Count;

            int prevButtonIndex = pagerSettings.Mode == PagerButtons.Numeric ? 0 : 1;
            int nextButtonIndex = pagerSettings.Mode == PagerButtons.Numeric ? cellsCount - 1 : cellsCount - 2;
            if (prevButtonIndex < cellsCount)
            {
                //check whether previous button exists 
                LinkButton btnPrev = pagerRow.Cells[prevButtonIndex].Controls[0] as LinkButton;
                if (btnPrev != null && btnPrev.Text.IndexOf("...") != -1)
                    btnPrev.Text = pagerSettings.PreviousPageText;
            }

            if (nextButtonIndex > 0 && nextButtonIndex < cellsCount)
            {
                //check whether next button exists 
                LinkButton btnNext = pagerRow.Cells[nextButtonIndex].Controls[0] as LinkButton;
                if (btnNext != null && btnNext.Text.IndexOf("...") != -1)
                    btnNext.Text = pagerSettings.NextPageText;
            }
        }
    }
    protected void gvNotes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvNotes.SelectedIndex = -1;
        gvNotes.PageIndex = e.NewPageIndex;
        gvNotesBindData();
    }
    protected void gvNotes_Sorting(object sender, GridViewSortEventArgs e)
    {
        OrderBy(e.SortExpression);
        LoadNoteSearchPrameters();
        //
        gvNotes.SelectedIndex = -1;
        lblMsg.Visible = false;
        //
        gvNotesBindData();
    }
    protected void gvNotes_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int NoteID = (int)(gvNotes.DataKeys[e.RowIndex].Values["NID"]);
        lblMsg.Text = DeleteNoteByID(NoteID);
        ViewState["NoteSortType"] = "ASC";
        OrderBy("UserEnterDate");
        LoadNoteSearchPrameters();
        gvNotesBindData();
    }
    protected void gvNotesBindData()
    {
        //TabContainer1.ActiveTab.Visible = true;
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "EnableTab();", true);
        //Panel1.Enabled = true;

        if (frmViewAccountDetails.SelectedValue != null)
            Session["AccountID_branch"] = frmViewAccountDetails.SelectedValue.ToString();
        else
            Session["AccountID_branch"] = null;

        int AID;
        if (frmViewAccountDetails.SelectedValue != null)
        {
            if (!int.TryParse(frmViewAccountDetails.SelectedValue.ToString(), out AID))
                AID = -1;

            if (Session["CurrentNote"] == null)
            {
                ContactNotes CNote = new ContactNotes();
                CNote.AccountID = AID;
                Session["CurrentNote"] = CNote;
            }
            else
                ((ContactNotes)Session["CurrentNote"]).AccountID = AID;

            if (Session["CurrentContact"] == null)
            {
                ContactContactsInfo CCI = new ContactContactsInfo();
                CCI.AccountID = AID;
                Session["CurrentContact"] = CCI;
            }
            else
                ((ContactContactsInfo)Session["CurrentContact"]).AccountID = AID;

            gvNotes.DataSource = odsNotes;
            gvNotes.DataBind();
            Contacts1.BindGridView();
        }
        gvNotes.SelectedIndex = -1;
        Contacts1.SetSelectedIndex(-1);
        Session["CurrentNote"] = null;
        Session["CurrentContact"] = null;
    }
    #endregion

    #region Contacts Filter Functions
    private void LoadContactSearchPrameters()
    {
        Session["CurrentContact"] = GetContactSortFilter(ViewState["orderbyField"].ToString(), ViewState["NoteSortType"].ToString());
    }
    #endregion

    #region Contacts Grid Functions
    //protected void gvContacts_RowCreated(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='none';";
    //        e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
    //        //e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvContacts, "Select$" + e.Row.RowIndex);
    //        e.Row.Attributes["ondblclick"] = ClientScript.GetPostBackClientHyperlink(this.gvContacts, "Select$" + e.Row.RowIndex);
    //        foreach (TableCell tc in e.Row.Cells)
    //        {
    //            tc.CssClass = "GridCellStyle";
    //        }
    //    }
    //}
    //protected void gvContacts_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Session["SingleContactID"] = gvContacts.DataKeys[gvContacts.SelectedIndex].Values["ContactID"];
    //    // Added By Fawzi //
    //    Session["FromPage"] = "AccountLists.aspx";
    //    //
    //    Response.Redirect("ContactLists.aspx");
    //}
    protected void Contacts1_ContactsSortingEvent(object sender, GridViewSortEventArgs e)
    {
        OrderBy(e.SortExpression);
        LoadContactSearchPrameters();
        //
        lblMsg.Visible = false;
        //
        gvNotesBindData();
    }
    #endregion
    
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        ContactAccount CntAcc = new ContactAccount();
        string[] AccNames = CntAcc.GetAllAccountsNames(prefixText, ContactAccount.SearchBy.AName);
        return AccNames;
    }
    protected void imgbtnSignOut_Click(object sender, ImageClickEventArgs e)
    {
        SignOut();
    }
    protected void imgNotesTab_Click(object sender, ImageClickEventArgs e)
    {
        NoteState();
        
    }

    private void NoteState()
    {
        imgNotesTab.Enabled = false;
        imgNotesTab.ImageUrl = "Images/notes_selected.png";
        imgContactsTab.Enabled = true;
        imgContactsTab.ImageUrl = "Images/contacts_normal.png";
        imgbtnSubCompanies.ImageUrl = "Images/SubCompanies-n.png";
        imgbtnSubCompanies.Enabled = true;

        imgbtnKeySoftware.Enabled = true;
        imgbtnKeySoftware.ImageUrl = "Images/Keys-n.png";
        imgbtnHistory.Enabled = true;
        imgbtnHistory.ImageUrl = "Images/History-n.png";
        imgbtnAttachments.Enabled = true;
        imgbtnAttachments.ImageUrl = "Images/Attachments-n.png";
        imgbtnDuediligence.ImageUrl = "Images/DueDiligence-n.png";
        imgbtnDuediligence.Enabled = true;
        TabContainer1.ActiveTabIndex =1;
    }
    protected void imgSubCompaniesTab_Click(object sender, ImageClickEventArgs e)
    {
        imgNotesTab.Enabled = true;
        imgNotesTab.ImageUrl = "Images/notes_normal.png";
        imgContactsTab.Enabled = true;
        imgContactsTab.ImageUrl = "Images/contacts_normal.png";
        imgbtnSubCompanies.ImageUrl = "Images/SubCompanies-o.png";
        imgbtnSubCompanies.Enabled = false;

        imgbtnKeySoftware.Enabled = true;
        imgbtnKeySoftware.ImageUrl = "Images/Keys-n.png";
        imgbtnHistory.Enabled = true;
        imgbtnHistory.ImageUrl = "Images/History-n.png";
        imgbtnAttachments.Enabled = true;
        imgbtnAttachments.ImageUrl = "Images/Attachments-n.png";
        imgbtnDuediligence.ImageUrl = "Images/DueDiligence-n.png";
        imgbtnDuediligence.Enabled = true;
        //BranchesGrid1.BindGrid();
        SubAccounts1.BindGrid();

    }
    protected void imgContactsTab_Click(object sender, ImageClickEventArgs e)
    {
       
        imgContactsTab.Enabled = false;
        imgContactsTab.ImageUrl = "Images/contacts_selected.png";
        imgNotesTab.Enabled = true;
        imgNotesTab.ImageUrl = "Images/notes_normal.png";
        imgbtnSubCompanies.ImageUrl = "Images/SubCompanies-n.png";
        imgbtnSubCompanies.Enabled = true;

        imgbtnKeySoftware.Enabled = true;
        imgbtnKeySoftware.ImageUrl = "Images/Keys-n.png";
        imgbtnHistory.Enabled = true;
        imgbtnHistory.ImageUrl = "Images/History-n.png";
         imgbtnAttachments.Enabled = true;
        imgbtnAttachments.ImageUrl = "Images/Attachments-n.png";
        imgbtnDuediligence.ImageUrl = "Images/DueDiligence-n.png";
        imgbtnDuediligence.Enabled = true;
        Contacts1.BindGridView();
    }
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        ((TextBox)(frmViewAccountDetails.FindControl("txtCountryID"))).Text = ((DropDownList)(frmViewAccountDetails.FindControl("ddlCountry"))).SelectedValue;
        AdjustCountryStateSelection();
        if (((DropDownList)(frmViewAccountDetails.FindControl("ddlCountry"))).SelectedItem.Text.Trim().ToLower() != "united states")
            ((TextBox)(frmViewAccountDetails.FindControl("txtState"))).Text = "";
    }
    private void AdjustCountryStateSelection()
    {
        if (((DropDownList)(frmViewAccountDetails.FindControl("ddlCountry"))).SelectedItem.Text.Trim().ToLower() == "united states")
        {
            ((DropDownList)(frmViewAccountDetails.FindControl("ddlState"))).Visible = true;
            ((TextBox)(frmViewAccountDetails.FindControl("txtState"))).Visible = false;
            if (((DropDownList)(frmViewAccountDetails.FindControl("ddlState"))).Items.FindByText(((TextBox)(frmViewAccountDetails.FindControl("txtState"))).Text) != null)
                ((DropDownList)(frmViewAccountDetails.FindControl("ddlState"))).SelectedValue = ((TextBox)(frmViewAccountDetails.FindControl("txtState"))).Text;
        }
        else
        {   
            ((DropDownList)(frmViewAccountDetails.FindControl("ddlState"))).Visible = false;
            ((TextBox)(frmViewAccountDetails.FindControl("txtState"))).Visible = true;
        }
    }
    private bool ValidateData()
    {
        bool Valid = true;
        //Validate Account Name Required
        if (((TextBox)frmViewAccountDetails.FindControl("txtboxAccountName")).Text.Trim() == "")
        {
            ((Label)frmViewAccountDetails.FindControl("lblErrValidAccName")).Text = "Account name is required";
            ((Label)frmViewAccountDetails.FindControl("lblErrValidAccName")).Visible = true;
            ((Label)frmViewAccountDetails.FindControl("lblErrSymAccName")).Visible = true;
            Valid = false;
        }
        else
        {
            ((Label)frmViewAccountDetails.FindControl("lblErrValidAccName")).Text = "";
            ((Label)frmViewAccountDetails.FindControl("lblErrValidAccName")).Visible = false;
            ((Label)frmViewAccountDetails.FindControl("lblErrSymAccName")).Visible = false;
        }
        //Validate Phone Required
        if (((TextBox)frmViewAccountDetails.FindControl("txtboxPhone")).Text.Trim() == "")
        {
            ((Label)frmViewAccountDetails.FindControl("lblErrValidPhone")).Text = "Telephone is required";
            ((Label)frmViewAccountDetails.FindControl("lblErrValidPhone")).Visible = true;
            ((Label)frmViewAccountDetails.FindControl("lblErrSymPhone")).Visible = true;
            Valid = false;
        }
        else
        {
            ((Label)frmViewAccountDetails.FindControl("lblErrValidPhone")).Text = "";
            ((Label)frmViewAccountDetails.FindControl("lblErrValidPhone")).Visible = false;
            ((Label)frmViewAccountDetails.FindControl("lblErrSymPhone")).Visible = false;
        }
        //Validate Zip Code Required
        if (((TextBox)frmViewAccountDetails.FindControl("txtboxZipCode")).Text.Trim() == "")
        {
            ((Label)frmViewAccountDetails.FindControl("lblErrValidZipCode")).Text = "Zip Code is required";
            ((Label)frmViewAccountDetails.FindControl("lblErrValidZipCode")).Visible = true;
            ((Label)frmViewAccountDetails.FindControl("lblErrSymZipCode")).Visible = true;
            Valid = false;
        }
        else
        {
            ((Label)frmViewAccountDetails.FindControl("lblErrValidZipCode")).Text = "";
            ((Label)frmViewAccountDetails.FindControl("lblErrValidZipCode")).Visible = false;
            ((Label)frmViewAccountDetails.FindControl("lblErrSymZipCode")).Visible = false;
        }

        if (((TextBox)frmViewAccountDetails.FindControl("txtboxWebsite")).Text.Trim() != "")
        {
            string WebSite = ((TextBox)frmViewAccountDetails.FindControl("txtboxWebsite")).Text;
            if (!((WebSite.Length > 7 && WebSite.Substring(0, 7) == "http://") || (WebSite.Length > 8 && WebSite.Substring(0, 8) == "https://")))
                WebSite = "http://" + WebSite;
            string WebSiteExp = @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
            if (!(System.Text.RegularExpressions.Regex.Match(WebSite, WebSiteExp).Success))
            {
                ((Label)frmViewAccountDetails.FindControl("lblErrValidWebSite")).Text = "WebSite URL is not valid";
                ((Label)frmViewAccountDetails.FindControl("lblErrValidWebSite")).Visible = true;
                ((Label)frmViewAccountDetails.FindControl("lblErrSymWebSite")).Visible = true;
                Valid = false;
            }
            else
            {
                ((Label)frmViewAccountDetails.FindControl("lblErrValidWebSite")).Text = "";
                ((Label)frmViewAccountDetails.FindControl("lblErrValidWebSite")).Visible = false;
                ((Label)frmViewAccountDetails.FindControl("lblErrSymWebSite")).Visible = false;
            }
        }

        if (((TextBox)frmViewAccountDetails.FindControl("txtEmailEdit")).Text != "")
        {
            string WebSite = ((TextBox)frmViewAccountDetails.FindControl("txtEmailEdit")).Text;
            string EmailExp = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            if (!(System.Text.RegularExpressions.Regex.Match(WebSite, EmailExp).Success))
            {
                ((Label)frmViewAccountDetails.FindControl("lblErrValidEmail")).Text = "Email is not valid";
                ((Label)frmViewAccountDetails.FindControl("lblErrValidEmail")).Visible = true;
                ((Label)frmViewAccountDetails.FindControl("lblEmailSym")).Visible = true;
                Valid = false;
            }
            else
            {
                ((Label)frmViewAccountDetails.FindControl("lblErrValidEmail")).Text = "";
                ((Label)frmViewAccountDetails.FindControl("lblErrValidEmail")).Visible = false;
                ((Label)frmViewAccountDetails.FindControl("lblEmailSym")).Visible = false;
            }
        }
        //if (((TextBox)frmViewAccountDetails.FindControl("txtboxPhone")).Text != "")
        //{
        //    string PhoneExp = @"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}";
        //    if (!(System.Text.RegularExpressions.Regex.Match(((TextBox)frmViewAccountDetails.FindControl("txtboxPhone")).Text, PhoneExp).Success))
        //    {
        //        ((Label)frmViewAccountDetails.FindControl("lblErrValidPhoneNo")).Text = "Phone Format is not valid";
        //        ((Label)frmViewAccountDetails.FindControl("lblErrValidPhoneNo")).Visible = true;
        //        ((Label)frmViewAccountDetails.FindControl("lblErrSymPhone")).Visible = true;
        //        Valid = false;
        //    }
        //    else
        //    {
        //        ((Label)frmViewAccountDetails.FindControl("lblErrValidPhoneNo")).Text = "";
        //        ((Label)frmViewAccountDetails.FindControl("lblErrValidPhoneNo")).Visible = false;
        //        ((Label)frmViewAccountDetails.FindControl("lblErrSymPhone")).Visible = false;
        //    }
        //}
        //if(((TextBox)frmViewAccountDetails.FindControl("txtboxZipCode")).Text != "")
        //{
        //    string ZipExp = @"^(\d{5}-\d{4}|\d{5}|\d{9})$|^([a-zA-Z]\d[a-zA-Z] \d[a-zA-Z]\d)$";
        //    if (!(System.Text.RegularExpressions.Regex.Match(((TextBox)frmViewAccountDetails.FindControl("txtboxZipCode")).Text, ZipExp).Success))
        //    {
        //        ((Label)frmViewAccountDetails.FindControl("lblErrValidZipNo")).Text = "Zip Code Format is not valid";
        //        ((Label)frmViewAccountDetails.FindControl("lblErrValidZipNo")).Visible = true;
        //        ((Label)frmViewAccountDetails.FindControl("lblErrSymZip")).Visible = true;
        //        Valid = false;
        //    }
        //    else
        //    {
        //        ((Label)frmViewAccountDetails.FindControl("lblErrValidZipNo")).Text = "";
        //        ((Label)frmViewAccountDetails.FindControl("lblErrValidZipNo")).Visible = false;
        //        ((Label)frmViewAccountDetails.FindControl("lblErrSymZip")).Visible = false;
        //    }
        //}
        //if (((TextBox)frmViewAccountDetails.FindControl("txtboxFax")).Text != "")
        //{
        //    string FaxExp = @"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}";
        //    if (!(System.Text.RegularExpressions.Regex.Match(((TextBox)frmViewAccountDetails.FindControl("txtboxFax")).Text, FaxExp).Success))
        //    {
        //        ((Label)frmViewAccountDetails.FindControl("lblErrValidFax")).Text = "Fax Format is not valid";
        //        ((Label)frmViewAccountDetails.FindControl("lblErrValidFax")).Visible = true;
        //        ((TextBox)frmViewAccountDetails.FindControl("txtboxFax")).Visible = true;
        //        Valid = false;
        //    }
        //    else
        //    {
        //        ((Label)frmViewAccountDetails.FindControl("lblErrValidFax")).Text = "";
        //        ((Label)frmViewAccountDetails.FindControl("lblErrValidFax")).Visible = false;
        //        ((TextBox)frmViewAccountDetails.FindControl("txtboxFax")).Visible = false;
        //    }
        //}
        return Valid;
    }
    //protected void btnAddContact_Click(object sender, EventArgs e)
    //{
    //    Session["NewContact"] = true;
    //    Response.Redirect("ContactLists.aspx?Acc=" + frmViewAccountDetails.SelectedValue.ToString());
    //}
   
    protected void imgbtnNext_Click(object sender, ImageClickEventArgs e)
    {
        //if (frmViewAccountDetails.PageIndex == 0 && ViewState["AccountID"] != null)
        //{
        //    int ID = 0;
        //    if (int.TryParse(ViewState["AccountID"].ToString(), out ID))
        //        frmViewAccountDetails.PageIndex = GetAccountOrderNo(ID);
        //}
        //ViewState["AccountID"] = "";
        //FormViewPageEventArgs FVPEA = new FormViewPageEventArgs(frmViewAccountDetails.PageIndex + 1);
        //frmViewAccountDetails_PageIndexChanging(this, FVPEA);

        ViewState["AccountID"] = "";
        int NextPageIndex = 0;

        if (Session["CurrentSelectedRowIndex"] != null)
        {
            NextPageIndex = int.Parse(Session["CurrentSelectedRowIndex"].ToString()) + 1;
        }
        else
        {
            NextPageIndex = NextPageIndex + 1;
        }
        FormViewPageEventArgs FVPEA = new FormViewPageEventArgs(NextPageIndex);
        Session["CurrentSelectedRowIndex"] = NextPageIndex;
        frmViewAccountDetails_PageIndexChanging(sender == null ? null : this, FVPEA);
        if (frmViewAccountDetails.PageIndex + 1 == frmViewAccountDetails.PageCount)
        {
            imgbtnNext.Visible = false;
        }
       // NoteState();
        imgbtnHistory_Click(null, null);
    }
    protected void imgbtnPrevious_Click(object sender, ImageClickEventArgs e)
    {
        //if (frmViewAccountDetails.PageIndex == 0 && ViewState["AccountID"] != null)
        //{
        //    int ID = 0;
        //    if (int.TryParse(ViewState["AccountID"].ToString(), out ID))
        //        frmViewAccountDetails.PageIndex = GetAccountOrderNo(ID);
        //}
        //ViewState["AccountID"] = "";
        //FormViewPageEventArgs FVPEA = new FormViewPageEventArgs(frmViewAccountDetails.PageIndex - 1);
        //frmViewAccountDetails_PageIndexChanging(this, FVPEA);

        ViewState["AccountID"] = "";
        int PreviousPageIndex = 0;

        if (Session["CurrentSelectedRowIndex"] != null)
        {
            PreviousPageIndex = int.Parse(Session["CurrentSelectedRowIndex"].ToString()) - 1;
        }
        else
        {
            PreviousPageIndex = PreviousPageIndex - 1;
        }
        FormViewPageEventArgs FVPEA = new FormViewPageEventArgs(PreviousPageIndex);
        Session["CurrentSelectedRowIndex"] = PreviousPageIndex;
        frmViewAccountDetails_PageIndexChanging(sender == null ? null : this, FVPEA);
        //NoteState();
        imgbtnHistory_Click(null, null);

    }

    protected void imgbtnKeySoftware_Click(object sender, ImageClickEventArgs e)
    {
        imgNotesTab.Enabled = true;
        imgNotesTab.ImageUrl = "Images/notes_normal.png";
        imgContactsTab.Enabled = true;
        imgContactsTab.ImageUrl = "Images/contacts_normal.png";
        imgbtnSubCompanies.ImageUrl = "Images/SubCompanies-n.png";
        imgbtnSubCompanies.Enabled = true;

        imgbtnKeySoftware.Enabled = false;
        imgbtnKeySoftware.ImageUrl = "Images/Keys-o.png";
        imgbtnHistory.Enabled = true;
        imgbtnHistory.ImageUrl = "Images/History-n.png";
        imgbtnAttachments.ImageUrl = "Images/Attachments-n.png";
        imgbtnAttachments.Enabled = true;
        imgbtnDuediligence.ImageUrl = "Images/DueDiligence-n.png";
        imgbtnDuediligence.Enabled = true;
        Key1.BindGridView();
    }
    protected void imgbtnHistory_Click(object sender, ImageClickEventArgs e)
    {
        imgNotesTab.Enabled = true;
        imgNotesTab.ImageUrl = "Images/notes_normal.png";
        imgContactsTab.Enabled = true;
        imgContactsTab.ImageUrl = "Images/contacts_normal.png";
        imgbtnSubCompanies.ImageUrl = "Images/SubCompanies-n.png";
        imgbtnSubCompanies.Enabled = true;

        imgbtnKeySoftware.Enabled = true;
        imgbtnKeySoftware.ImageUrl = "Images/Keys-n.png";
        imgbtnAttachments.ImageUrl = "Images/Attachments-n.png";
        imgbtnAttachments.Enabled = true;
        imgbtnHistory.ImageUrl = "Images/History-o.png";
        imgbtnHistory.Enabled = false;
        imgbtnDuediligence.ImageUrl = "Images/DueDiligence-n.png";
        imgbtnDuediligence.Enabled = true;
        HistoryNC1.BindGridView();
    }

    protected void imgbtnAttachments_Click(object sender, ImageClickEventArgs e)
    {
        imgNotesTab.Enabled = true;
        imgNotesTab.ImageUrl = "Images/notes_normal.png";
        imgContactsTab.Enabled = true;
        imgContactsTab.ImageUrl = "Images/contacts_normal.png";
        imgbtnSubCompanies.ImageUrl = "Images/SubCompanies-n.png";
        imgbtnSubCompanies.Enabled = true;

        imgbtnKeySoftware.Enabled = true;
        imgbtnKeySoftware.ImageUrl = "Images/Keys-n.png";
        imgbtnHistory.ImageUrl = "Images/History-n.png";
        imgbtnHistory.Enabled = true;

        imgbtnAttachments.ImageUrl = "Images/Attachments-o.png";
        imgbtnAttachments.Enabled = false;
        imgbtnDuediligence.ImageUrl = "Images/DueDiligence-n.png";
        imgbtnDuediligence.Enabled = true;
        Attachment1.BindGridView();
    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        Session["SelectedAccountID"] = frmViewAccountDetails.SelectedValue;
        // added by Sayed 12/3/2012
         Session["EmailDuediligence"] = ((TextBox)frmViewAccountDetails.FindControl("txtEmailEdit")).Text;
        //
        Session["CurrentPage"] = "AccountLists";
    }
    protected void ddlParent_DataBinding(object sender, EventArgs e)
    {
        DropDownList ddlParent = (DropDownList)sender;
        ddlParent.Items.Clear();
        ListItem FirstItem = new ListItem("-----", "-----");
        ddlParent.Items.Insert(0, FirstItem);
    }

    protected void ddlParent_DataBound(object sender, EventArgs e)
    {
        if (frmViewAccountDetails.SelectedValue != null)
        {
            int AID = Convert.ToInt32(frmViewAccountDetails.SelectedValue);
            string ParentID = GetAccountParent(AID).ToString();
            DropDownList ddlParent = (DropDownList)sender;

            if (ParentID != "-1")
                ddlParent.SelectedValue = ParentID;
            else
                ddlParent.SelectedIndex = 0;
        }
    }

    void SubAccounts1_SubCompanyEditingEvent(object sender, EventArgs e)
    {
        if (frmViewAccountDetails.SelectedValue != null)
        {
            ddlParent.DataBind();
            ddlCompanyName.DataSource = null;
            ddlCompanyName.Items.Clear();

            string ParentID = frmViewAccountDetails.SelectedValue.ToString();
            ddlParent.SelectedValue = ParentID;

            string[] senderInfo = sender.ToString().Split(';');
            ddlCompanyName.Items.Add(new ListItem(senderInfo[1], senderInfo[0]));
            ddlCompanyName.SelectedIndex = 0;
            ddlCompanyName.Enabled = false;
            ddlParent.Enabled = true;

            ViewState["AddSubCompany"] = false;
            mdlPopup.Show();
        }
    }

    void SubAccounts1_SubCompanyDeletingEvent(object sender, EventArgs e)
    {
        lblMsg.Text = sender.ToString();
    }
    protected void imgbtnDuediligence_Click(object sender, ImageClickEventArgs e)
    {
        imgNotesTab.Enabled = true;
        imgNotesTab.ImageUrl = "Images/notes_normal.png";
        imgContactsTab.Enabled = true;
        imgContactsTab.ImageUrl = "Images/contacts_normal.png";
        imgbtnSubCompanies.ImageUrl = "Images/SubCompanies-n.png";
        imgbtnSubCompanies.Enabled = true;

        imgbtnKeySoftware.Enabled = true;
        imgbtnKeySoftware.ImageUrl = "Images/Keys-n.png";
        imgbtnHistory.ImageUrl = "Images/History-n.png";
        imgbtnHistory.Enabled = true;

        imgbtnAttachments.ImageUrl = "Images/Attachments-n.png";
        imgbtnAttachments.Enabled = true;
        imgbtnDuediligence.ImageUrl = "Images/DueDiligence-o.png";
        imgbtnDuediligence.Enabled = false;

    }
}
