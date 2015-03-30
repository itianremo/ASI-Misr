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
using Office.BLL;
using Office.DAL;
using System.Text;

public partial class ContactLists : Office.BLL.ContactListsBLL
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckUserSession();
        lblAddUserMsg.Visible = false;
        lblAddResultMsg.Visible = false;
        lblAddMisc.Visible = false;
        //((Label)frmViewContacts.FindControl("lblValidationMsg")).Visible = true;
        if (!IsPostBack)
        {
            
            if (Session["SpecificFilter"] != null)
            {
                ViewState["SpecificFilter"] = Session["SpecificFilter"];
                ((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text = ViewState["SpecificFilter"].ToString();
                Session["SpecificFilter"] = null;
            }
            //
				//lblVersionInfo.Text = GetVersionInfo();
            Session["CurrentNote"] = null;

            if (Session["SingleContactID"] != null && Session["SingleContactID"].ToString() != "")
            {
                ViewState["ContactID"] = Session["SingleContactID"];
                ViewState["ContactIDforPaging"] = Session["SingleContactID"];
                Session["SingleContactID"] = null;
            }
            else
            {
                if (ViewState["ContactID"] == null)
                    ViewState["ContactID"] = "";
                ViewState["ContactIDforPaging"] = "";
                // added By Sayed 10/5/2012
                Session["FilterContactSort"] = "FirstName";
                Session["FilterContactSortType"] = "FirstName";
                Session["FilterContactSort"] = 0;
                // end 10/5/2012
            }

            if (Request.QueryString["ContactID"] != null && Request.QueryString["ContactID"] != "")
            {

                ViewState["ContactID"] = Request.QueryString["ContactID"];

            }

            //Session["ContactFilterField"] = "Company";
            // Added by fawzi 5-Aug-2010 //
            if (Session["ddlFilterField"] == null)
            {
               Session["ContactFilterField"] = "Company";
                //Session["ContactFilterField"] = "Contact First Name";
            }
            else
            {
                Session["ContactFilterField"] = Session["ddlFilterField"];
                ((DropDownList)ucAutoCompleteSearch.FindControl("ddlFindType")).SelectedValue = ((DropDownList)ucAutoCompleteSearch.FindControl("ddlFindType")).Items.FindByText(Session["ContactFilterField"].ToString()).Text;
                Session["ddlFilterField"] = null;
            }
            //
            
            //
            btnAddEditNotes.Attributes.Add("onMouseOver", "this.style.background = 'Blue'; this.style.color = 'White';");
            btnAddEditNotes.Attributes.Add("onMouseOut", "this.style.background = 'White'; this.style.color = 'Black';");
            //
            LoadSearchPrameters();
            BindFormView();
            //
            AddjustDropDownListsSelection();
            ddlIDStatus.DataBind();
            ddlBusSector.DataSource = GetAllBusSectorList();
            ddlBusSector.DataBind();
            ddlBusSector.Items.Insert(0, "All");
            ddlLastResults.DataBind();
            NavigateMiscellaneous();
            OrderBy("UserEnterDate");
            LoadNoteSearchPrameters();
            gvNotesBindData();
            LoadContactConnectionData();
            ViewState["ContactDeleted"] = false;
            AdjustNextPreviousButtons();
            Session["SelectedContactID"] = ((HiddenField)frmViewContacts.FindControl("txtContID")).Value;
            // modified by Sayed 26/7/2011
           // if (dllCompanyName.SelectedValue != "-----")
            try
            {
                if (dllCompanyName.SelectedValue != "" && dllCompanyName.SelectedValue != "-----")
                    Session["SelectedAccountID"] = int.Parse(dllCompanyName.SelectedValue.ToString());
                else
                    Session["SelectedAccountID"] = null;
            }
            catch(Exception ex)
            {
                Session["SelectedAccountID"] = null;
                string msg = ex.Message;
            }
            Session["SelectedBranchID"] = null;
            Session["CurrentPage"] = "ContactLists";
            imgNotesTab.Attributes.Add("onmouseover", "this.src= 'Images/notes_over.png';");
            imgNotesTab.Attributes.Add("onmouseout", "this.src= 'Images/notes_normal.png';");
            imgbtnKeySoftware.Attributes.Add("onmouseover", "this.src= 'Images/Keys-o.png';");
            imgbtnKeySoftware.Attributes.Add("onmouseout", "this.src= 'Images/Keys-n.png';");
            imgbtnHistory.Attributes.Add("onmouseover", "this.src= 'Images/History-o.png';");
            imgbtnHistory.Attributes.Add("onmouseout", "this.src= 'Images/History-n.png';");
            imgbtnAttachments.Attributes.Add("onmouseover", "this.src= 'Images/Attachments-o.png';");
            imgbtnAttachments.Attributes.Add("onmouseout", "this.src= 'Images/Attachments-n.png';");
            imgbtnCalls.Attributes.Add("onmouseover", "this.src= 'Images/CallManagement-o.png';");
            imgbtnCalls.Attributes.Add("onmouseout", "this.src= 'Images/CallManagement-n.png';");

            if (Request.QueryString["Email"] != null && Request.QueryString["Email"] != "")
            {
                ((DropDownList)ucAutoCompleteSearch.FindControl("ddlFindType")).SelectedValue = "Email";
                ((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text = Request.QueryString["Email"];

                SetSpecificAccountFilter();
                LoadSearchPrameters();
                BindFormView();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "EnableContactTab();", true);
                gvNotesBindData();
                divTabs.Visible = frmViewContacts.DataKey.Value != null;
                if (frmViewContacts.DataKey.Value != null)
                {
                    AddjustDropDownListsSelection();
                    NavigateMiscellaneous();
                    LoadContactConnectionData();
                }
                else lblEmptyResults.Visible = true;
                AdjustTransButtons(false);
            }

            if (Request.QueryString["ContactID"] != null && Request.QueryString["ContactID"] != "")
            {
                if (Request.QueryString["Calls"] != null && Request.QueryString["Calls"] != "")
                {
                    if (Request.QueryString["Calls"] == "t")
                    {
                        TabContainer1.ActiveTab = TabPanel2;
                        imgbtnCalls_Click(null, null);
                    }
                }

            }
        }


        string CurrentPage = "ContactLists";
        ucTransToolBar.CurrentPage = CurrentPage;
        ucTransToolBar.btnBackEvent += new EventHandler(ucTransToolBar_btnBackEvent);
        ucTransToolBar.btnSaveEvent += new EventHandler(ucTransToolBar_btnSaveEvent);
        ucTransToolBar.btnAddEvent += new EventHandler(ucTransToolBar_btnAddEvent);
        ucTransToolBar.btnEditEvent += new EventHandler(ucTransToolBar_btnEditEvent);
        ucTransToolBar.btnDeleteEvent +=new EventHandler(ucTransToolBar_btnDeleteEvent);
        ucTransToolBar.btnCancelEvent += new EventHandler(ucTransToolBar_btnCancelEvent);
        AssignReportParameters();
        //
		  //ucUserTabs.CurrentPage = CurrentPage;
		  //ucUserTabs.btnAccountsEvent += new EventHandler(ucUserTabs_btnAccountsEvent);
		  //ucUserTabs.btnAccountListsEvent += new EventHandler(ucUserTabs_btnAccountListsEvent);
		  //ucUserTabs.btnContantsEvent += new EventHandler(ucUserTabs_btnContactsEvent);
		  //ucUserTabs.btnBranchesEvent += new EventHandler(ucUserTabs_btnBranchesEvent);
		  //ucUserTabs.btnBranchesDetailsEvent += new EventHandler(ucUserTabs_btnBranchesDetailsEvent);
		  //ucUserTabs.btnCallsEvent += new EventHandler(ucUserTabs_btnCallsEvent);
		  //ucUserTabs.btnManageApplicationEvent += new EventHandler(ucUserTabs_btnManageApplicationEvent);
        //
        ucAutoCompleteSearch.CurrentPage = CurrentPage;
        ucAutoCompleteSearch.btnSearchEvent += new EventHandler(ucAutoCompleteSearch_btnSearchEvent);
        ucAutoCompleteSearch.ddlFindTypeEvent += new EventHandler(ucAutoCompleteSearch_ddlFindTypeEvent);
        //
		  //imgbtnSignOut.Attributes.Add("onmouseover", "this.src='Images/CloseBut_pressed.jpg'");
		  //imgbtnSignOut.Attributes.Add("onmouseout", "this.src='Images/CloseBut_normal.jpg'");
        //
        imgbtnNext.Attributes.Add("onmouseover", "this.src= 'Images/RightArrow_o.gif';");
        imgbtnNext.Attributes.Add("onmouseout", "this.src= 'Images/RightArrow_n.gif';");
        imgbtnNext.Attributes.Add("onmousedown", "this.src='Images/RightArrow_s.gif'");
        //
        imgbtnPrevious.Attributes.Add("onmouseover", "this.src= 'Images/LeftArrow_o.gif';");
        imgbtnPrevious.Attributes.Add("onmouseout", "this.src= 'Images/LeftArrow_n.gif';");
        imgbtnPrevious.Attributes.Add("onmousedown", "this.src='Images/LeftArrow_s.gif'");
        //
    }

    protected void imgNotesTab_Click(object sender, ImageClickEventArgs e)
    {
        NoteState();

    }

    private void NoteState()
    {
        imgNotesTab.Enabled = false;
        imgNotesTab.ImageUrl = "Images/notes_selected.png";
        imgbtnCalls.ImageUrl = "Images/CallManagement-n.png";
        imgbtnCalls.Enabled = true;
        imgbtnKeySoftware.Enabled = true;
        imgbtnKeySoftware.ImageUrl = "Images/Keys-n.png";
        imgbtnHistory.Enabled = true;
        imgbtnHistory.ImageUrl = "Images/History-n.png";
        imgbtnAttachments.Enabled = true;
        imgbtnAttachments.ImageUrl = "Images/Attachments-n.png";
        TabContainer1.ActiveTabIndex = 0;
    }

    private void AdjustNextPreviousButtons()
    {// it causes error when select contact hasn't account
        imgbtnNext_Click(null, null);
        if (frmViewContacts.PageIndex + 1 <= frmViewContacts.PageCount)
        {
            imgbtnPrevious_Click(null, null);
        }

        if (frmViewContacts.PageIndex > 0)
        {
            imgbtnPrevious.Visible = true;
        }
        if (frmViewContacts.PageIndex + 1 == frmViewContacts.PageCount)
        {
            imgbtnNext.Visible = false;
        }
    }

    protected override void OnLoadComplete(EventArgs e)
    {
        base.OnLoadComplete(e);

        if (!IsPostBack)
        {
            if ((bool)ViewState["ContactDeleted"])
                ViewState["ContactDeleted"] = false;
            else
                lblMsg.Text = "";
        }
    }

    //protected override void OnLoadComplete(EventArgs e)
    //{
    //    base.OnLoadComplete(e);
    //    if (!IsPostBack)
    //    {
    //        if (Session["NewContact"] != null && ((bool)Session["NewContact"]))
    //        {
    //            if(!string.IsNullOrEmpty(Request.QueryString["Acc"]))
    //            {
    //                int NewAccID = 0;
    //                if (int.TryParse(Request.QueryString["Acc"], out NewAccID))
    //                {
                        
    //                    //AddContact();
    //                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "AddNewContactForAccount();", true);

    //                    //dllCompanyName.SelectedValue = NewAccID.ToString();

    //                    //ContactAccount CntAcc = new ContactAccount();
    //                    //CntAcc.AccountID = NewAccID;
    //                    //Session["SingleAccount"] = CntAcc;
    //                    //frmViewAccounts.DataSource = odsAccounts;
    //                    //frmViewAccounts.DataBind();

    //                    //BranchesBLL Branchobj = new BranchesBLL();
    //                    //// select contact Branch
    //                    //if (Branchobj.GetContactBranchID(((TextBox)frmViewContacts.FindControl("txtContID")).Text, dllCompanyName.SelectedValue.ToString()) != "")
    //                    //{
    //                    //    ((DropDownList)frmViewAccounts.FindControl("dllBranchName")).SelectedValue = Branchobj.GetContactBranchID(((TextBox)frmViewContacts.FindControl("txtContID")).Text, dllCompanyName.SelectedValue.ToString());
    //                    //}

    //                    //// check the MainContact for Current Branch
    //                    //string BranchID = ((DropDownList)frmViewAccounts.FindControl("dllBranchName")).SelectedValue;
    //                    //string ContactID = ((TextBox)frmViewContacts.FindControl("txtContID")).Text;
    //                    //((CheckBox)frmViewAccounts.FindControl("chboxMainContact")).Checked = Branchobj.CheckMainContact(ContactID, BranchID);

    //                }
    //            }
    //        }
    //    }
    //}

    void ucUserTabs_btnManageApplicationEvent(object sender, EventArgs e)
    {
        Response.Redirect("ManageApplication.aspx");
    }

    private void AssignReportParameters()
    {
        string SpecificAccount = ((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text;
        ((ImageButton)ucTransToolBar.FindControl("btnPrint")).Attributes.Add("onclick", "openReports('','','','" + SpecificAccount + "','" + Session["ContactFilterField"].ToString() + "','','');");
    }
    private void HandleNextPrevButton() 
    {
        //
        if (frmViewContacts.PageIndex == 0)
        {
            imgbtnPrevious.Visible = false;
        }
        else
        {
            imgbtnPrevious.Visible = true;
        }
        //
        if (frmViewContacts.PageIndex == frmViewContacts.PageCount -1)
        {
            imgbtnNext.Visible = false;
        }
        else
        {
            imgbtnNext.Visible = true;
        }
        //
    }

    private void LoadSearchPrameters()
    {
        if (ViewState["SpecificFilter"] == null)
            ViewState["SpecificFilter"] = "";
        Session["Contact"] = GetSearchFilter(ViewState["SpecificFilter"].ToString(), Session["ContactFilterField"].ToString(), ViewState["ContactID"].ToString(), Convert.ToInt32(Session["FilterContactNotes"]), Session["FilterContactSort"].ToString(), Session["FilterContactSortType"].ToString());
        ViewState["ContactID"] = "";
    }
    /// <summary>
    /// New Contact Search Paramter  - mglil
    /// </summary>
    /// <param name="ContactID"></param>
    private void LoadSearchPrameters(string ContactID)
    {

        ViewState["SpecificFilter"] = "";
        Session["ContactFilterField"] = "";
        ViewState["ContactID"] = ContactID;
        Session["Contact"] = GetSearchFilter(ViewState["SpecificFilter"].ToString(), Session["ContactFilterField"].ToString(), ViewState["ContactID"].ToString(), Convert.ToInt32(Session["FilterContactNotes"]), Session["FilterContactSort"].ToString(), Session["FilterContactSortType"].ToString());
        ViewState["ContactID"] = "";

    }
    /// <summary>
    /// end
    /// </summary>


    private void SetSpecificAccountFilter()
    {
        DropDownList ddlFindType = (DropDownList)ucAutoCompleteSearch.FindControl("ddlFindType");
        Session["ContactFilterField"] = ddlFindType.SelectedValue;
        TextBox objtxtSearch = (TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch");
        // Added by Fawzi to fix reset search bug 
        if (objtxtSearch.Text != "")
            ViewState["SpecificFilter"] = objtxtSearch.Text.Replace("~", "-");// End Add
        else
            ViewState["SpecificFilter"] = "";
    }
    private void BindFormView()
    {
        lblEmptyResults.Visible = false;
        frmViewContacts.DataSource = odsContacts;
        frmViewContacts.DataBind();
        if (frmViewContacts.DataKey.Value == null)
        {
            lblEmptyResults.Visible = true;
            pnlCntMisc.Visible = false;
            pnlAccount.Visible = false;
            pnlResults.Visible = false;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "DisableContactTab();", true);
        }
        else
        {
            if(((Office.DAL.ContactContactsInfo)(frmViewContacts.DataItem)).TitleID.HasValue)
                ((DropDownList)frmViewContacts.FindControl("ddlTitle")).SelectedValue = ((Office.DAL.ContactContactsInfo)(frmViewContacts.DataItem)).TitleID.Value.ToString();
            if (((Office.DAL.ContactContactsInfo)(frmViewContacts.DataItem)).DepartmentID.HasValue)
            {
                ((DropDownList)frmViewContacts.FindControl("ddlDepartments")).SelectedValue = ((Office.DAL.ContactContactsInfo)(frmViewContacts.DataItem)).DepartmentID.Value.ToString();
            //    ((HiddenField)frmViewContacts.FindControl("txtDepartment")).Value = ((Office.DAL.ContactContactsInfo)(frmViewContacts.DataItem)).DepartmentID.Value.ToString();
            }
            //if (lblEmptyResults.Visible)
            //{
                lblEmptyResults.Visible = false;
                pnlCntMisc.Visible = true;
                pnlAccount.Visible = true;
                pnlResults.Visible = true;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "EnableContactTab();", true);
            //}
        }
        //if(((DropDownList)frmViewContacts.FindControl("ddlState")).SelectedValue.Trim().ToLower() == "united states")
        //    ((DropDownList)frmViewContacts.FindControl("ddlState")).SelectedValue = ((TextBox)frmViewContacts.FindControl("txtState")).Text;
        HandleNextPrevButton();
    }

    protected void ucTransToolBar_btnBackEvent(object sender, EventArgs e)
    {
        if (ViewState["ContactIDforPaging"] != null && ViewState["ContactIDforPaging"].ToString() != "")
        {
            Session["SingleContactID"] = ViewState["ContactIDforPaging"];
            ViewState["ContactIDforPaging"] = null;
            // Added By Fawzi //
            if (Session["FromPage"] == null)
            {
                Response.Redirect("Contacts.aspx");
            }
            else 
            {
                string FromPage = Session["FromPage"].ToString();
                Session["FromPage"] = null;
                if (FromPage == "AccountLists.aspx")
                {
                    Session["SingleAccountID"] = Session["SingleAccountIDForContactListsPage"];
                    Response.Redirect("AccountLists.aspx");
                }
                else if (FromPage == "BranchDetails.aspx")
                {
                    Session["SingleBranchID"] = Session["SingleBrnachIDForContactListsPage"];
                    Response.Redirect("BranchDetails.aspx");
                }
                else Response.Redirect("Contacts.aspx");
            }
           
        }
        else Response.Redirect("Contacts.aspx");
    }

    void ucTransToolBar_btnCancelEvent(object sender, EventArgs e)
    {
        try
        {
            // added by Sayed 5/9/2011
            if (!divTabs.Visible)
                divTabs.Visible = true;    
            //
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "EnableContactTab();", true);

            Session["SingleAccount"] = null;

            frmViewAccounts.DataSource = null;
            frmViewAccounts.DataBind();

            AdjustReadOnlyFormStatus(true);
            //
            AdjustTransButtons(false);
            //
            LoadSearchPrameters();
            //
            BindFormView();
            ////
            AddjustDropDownListsSelection();
            NavigateMiscellaneous();
            gvNotesBindData();
            // added By Sayed 24 Ramadan 1432 
            NoteState();

           
        }
        catch (Exception exp)
        {
            lblMsg.Text = exp.Message;
        }
    }

    private void AdjustTransButtons(bool Flag)
    {
        lblMsg.Text = "";
        //
        ((ImageButton)ucTransToolBar.FindControl("btnCancel")).Visible = Flag;
        ((ImageButton)ucTransToolBar.FindControl("btnSave")).Visible = Flag;
        //
        
        if (User.IsInRole("AddContact"))
            ((ImageButton)ucTransToolBar.FindControl("btnAdd")).Visible = !Flag;
        if (User.IsInRole("EditContact"))
            ((ImageButton)ucTransToolBar.FindControl("btnEdit")).Visible = !Flag;
        if (User.IsInRole("DeleteContact"))
            ((ImageButton)ucTransToolBar.FindControl("btnDelete")).Visible = !Flag;
    }


    //Button Update 
    void ucTransToolBar_btnEditEvent(object sender, EventArgs e)
    {
        ((ImageButton)ucTransToolBar.FindControl("btnSave")).AlternateText = "Update";
        // 
        AdjustReadOnlyFormStatus(false);
        ((TextBox)frmViewContacts.FindControl("txtEmailEdit")).Text = ((HyperLink)frmViewContacts.FindControl("txtEmail")).Text;
        //
        ViewState["SaveMode"] = "Update";
        //
        AdjustTransButtons(true);

        imgbtnNext.Visible = false;
        imgbtnPrevious.Visible = false;

    }
    //Button New 
    void ucTransToolBar_btnAddEvent(object sender, EventArgs e)
    {
         // added by sayed 5/9/2011
        divTabs.Visible = false;
         //

        imgbtnNext.Visible = false;
        imgbtnPrevious.Visible = false;

        AddContact();
    }
    void AddContact()
    {
        if (frmViewContacts.DataKey.Value == null)
        {
            ((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text = "";
            ViewState["SpecificFilter"] = "";
            Session["Contact"] = "";
            BindFormView();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "EnableContactTab();", true);
            lblEmptyResults.Visible = false;
        }
        ((ImageButton)ucTransToolBar.FindControl("btnSave")).AlternateText = "Save";
        //
        AdjustReadOnlyFormStatus(false);
        //
        AdjustTransButtons(true);
        //
        ViewState["SaveMode"] = "Add";
       
        ResetContactControls();

        if (Session["NewContact"] != null && ((bool)Session["NewContact"]))
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Acc"]))
            {
                int NewAccID = 0;
                if (int.TryParse(Request.QueryString["Acc"], out NewAccID))
                {

                    //AddContact();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "AddNewContactForAccount();", true);

                    dllCompanyName.SelectedValue = NewAccID.ToString();

                    ContactAccount CntAcc = new ContactAccount();
                    CntAcc.AccountID = NewAccID;
                    Session["SingleAccount"] = CntAcc;
                    frmViewAccounts.DataSource = odsAccounts;
                    frmViewAccounts.DataBind();

                    BranchesBLL Branchobj = new BranchesBLL();
                    // select contact Branch
                    if (Branchobj.GetContactBranchID(((HiddenField)frmViewContacts.FindControl("txtContID")).Value, dllCompanyName.SelectedValue.ToString()) != "")
                    {
                        ((DropDownList)frmViewAccounts.FindControl("dllBranchName")).SelectedValue = Branchobj.GetContactBranchID(((HiddenField)frmViewContacts.FindControl("txtContID")).Value, dllCompanyName.SelectedValue.ToString());
                    }

                    // check the MainContact for Current Branch
                    string BranchID = ((DropDownList)frmViewAccounts.FindControl("dllBranchName")).SelectedValue;
                    string ContactID = ((HiddenField)frmViewContacts.FindControl("txtContID")).Value;
                    ((CheckBox)frmViewAccounts.FindControl("chboxMainContact")).Checked = Branchobj.CheckMainContact(ContactID, BranchID);

                }
                else
                    Session["NewContact"] = null;
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["Br"]))
            {
                int NewAccID = 0;
                int NewBrID = 0;
                if (int.TryParse(Request.QueryString["Br"], out NewBrID))
                {

                    //AddContact();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "AddNewContactForAccount();", true);

                    NewAccID = GetAccountIDByBranchID(NewBrID);
                    dllCompanyName.SelectedValue = NewAccID.ToString();

                    ContactAccount CntAcc = new ContactAccount();
                    CntAcc.AccountID = NewAccID;
                    Session["SingleAccount"] = CntAcc;
                    frmViewAccounts.DataSource = odsAccounts;
                    frmViewAccounts.DataBind();

                    BranchesBLL Branchobj = new BranchesBLL();
                    // select contact Branch
                    ((DropDownList)frmViewAccounts.FindControl("dllBranchName")).SelectedValue = NewBrID.ToString();

                    // check the MainContact for Current Branch
                    //string BranchID = ((DropDownList)frmViewAccounts.FindControl("dllBranchName")).SelectedValue;
                    string ContactID = ((HiddenField)frmViewContacts.FindControl("txtContID")).Value;
                    ((CheckBox)frmViewAccounts.FindControl("chboxMainContact")).Checked = Branchobj.CheckMainContact(ContactID, NewBrID.ToString());

                }
                else
                    Session["NewContact"] = null;
            }
            else
                Session["NewContact"] = null;
        }
    }
    //Button Save 
    void ucTransToolBar_btnSaveEvent(object sender, EventArgs e)
    {
        if (ViewState["SaveMode"].ToString() == "Add")
            AddNewContact();
        else if (ViewState["SaveMode"].ToString() == "Update")
            UpdateContact();
    }
    //Clear contacts controls for new entery
    private void ResetContactControls()
    {
        //Contact Info
        ((HiddenField)frmViewContacts.FindControl("txtContID")).Value = "*";
        ((TextBox)frmViewContacts.FindControl("txtSalutaion")).Text = "";
        ((TextBox)frmViewContacts.FindControl("txtFirstName")).Text = "";
        ((TextBox)frmViewContacts.FindControl("txtMI")).Text = "";
        ((TextBox)frmViewContacts.FindControl("txtLastName")).Text = "";
        ((DropDownList)frmViewContacts.FindControl("ddlTitle")).SelectedIndex = 0;
        ((DropDownList)frmViewContacts.FindControl("ddlDepartments")).SelectedIndex = 0;
        ((DropDownList)frmViewContacts.FindControl("ddlState")).Visible = true;
        ((DropDownList)frmViewContacts.FindControl("ddlCountry")).SelectedIndex = GetSelectedCounrtyValue(((DropDownList)frmViewContacts.FindControl("ddlCountry")), "United States");

        ((TextBox)frmViewContacts.FindControl("txtTitle")).Text = ((DropDownList)frmViewContacts.FindControl("ddlTitle")).SelectedValue.ToString();
        ((HiddenField)frmViewContacts.FindControl("txtDepartment")).Value = ((DropDownList)frmViewContacts.FindControl("ddlDepartments")).SelectedValue.ToString();
        ((TextBox)frmViewContacts.FindControl("txtCountryID")).Text = ((DropDownList)frmViewContacts.FindControl("ddlCountry")).SelectedValue.ToString();
        //((TextBox)frmViewContacts.FindControl("txtState")).Text = "";
        ((TextBox)frmViewContacts.FindControl("txtPhone")).Text = "";
        ((TextBox)frmViewContacts.FindControl("txtExt")).Text = "";
        ((TextBox)frmViewContacts.FindControl("txtCellPhone")).Text = "";
        ((TextBox)frmViewContacts.FindControl("txtFax")).Text = "";
        ((TextBox)frmViewContacts.FindControl("txtEmailEdit")).Text = "";
        ((HyperLink)frmViewContacts.FindControl("txtEmail")).Text = "";
        ((TextBox)frmViewContacts.FindControl("txtState")).Text = "";
        ((TextBox)frmViewContacts.FindControl("txtState")).Visible = false;
        ((TextBox)frmViewContacts.FindControl("txtProbabilty")).Text = "";
        //EnableStateControls();

        //Contact Miscellaneous
        ddlIDStatus.SelectedIndex = 0;
        txtSpouse.Text = "";
        txtRefferedBy.Text = "";
        txtBirthday.Text = "";
        txtStatus.Text = "";
        txtMiscNotes.Text = "";

        //ContactConnection
        ddlLastResults.SelectedIndex = 0;
        txtDate.Text = "";
        txtLastAttempt.Text = "";
        txtLastEditBy.Text = "";
        txtLastMeet.Text = "";
        txtLastReach.Text = "";
        ViewState["SelectedResult"] = null;

        ((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text = "";

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "DisableContactTab();", true);
    }
    private int GetSelectedCounrtyValue(DropDownList SelectedDDL , string SelectedText)
    {
        int Index = -1;
        if (SelectedDDL != null)
        {
            for (int i = 0; i < SelectedDDL.Items.Count; i++)
            {
                if (SelectedDDL.Items[i].Text.Trim().ToLower() == SelectedText.Trim().ToLower())
                {
                    Index = i;
                    break;
                }
            }
        }
        return Index;
    }
    //Insert new contact in Database
    private void AddNewContact()
    {
        if (ValidateData())
        {
            if (((HiddenField)frmViewContacts.FindControl("txtContID")).Value == "*")
            {
                bool ValidDate = true;
                if (txtBirthday.Text != "")
                {
                    try
                    {
                        Convert.ToDateTime(txtBirthday.Text);
                    }
                    catch (Exception Ecp)
                    {
                        string Err = Ecp.Message;
                        lblAddUserMsg.Text = "Invalid Birthday Date";
                        lblAddUserMsg.Visible = true;
                        ValidDate = false;
                    }
                }
                if (ValidDate)
                {
                    ContactContactsInfo NewContact = new ContactContactsInfo();
                    try
                    {
                        
                        NewContact.Intial = ((TextBox)frmViewContacts.FindControl("txtSalutaion")).Text;
                        NewContact.FirstName = ((TextBox)frmViewContacts.FindControl("txtFirstName")).Text;
                        NewContact.MiddleIntial = ((TextBox)frmViewContacts.FindControl("txtMI")).Text;
                        NewContact.LastName = ((TextBox)frmViewContacts.FindControl("txtLastName")).Text;

                        // Modified By Sayed 7/9/2011

                        int TitleID = 0;
                        if (int.TryParse((((TextBox)frmViewContacts.FindControl("txtTitle")).Text), out TitleID))
                            NewContact.TitleID = TitleID;
                        int DeptID = 0;
                        if (int.TryParse((((HiddenField)frmViewContacts.FindControl("txtDepartment")).Value), out DeptID))
                            NewContact.DepartmentID = DeptID;

                        NewContact.CountryID = int.Parse(((DropDownList)frmViewContacts.FindControl("ddlCountry")).SelectedValue);
                        if (((DropDownList)frmViewContacts.FindControl("ddlCountry")).SelectedItem.Text.Trim().ToLower() == "united states")
                            NewContact.State = ((DropDownList)frmViewContacts.FindControl("ddlState")).Text;
                        else
                            NewContact.State = ((TextBox)frmViewContacts.FindControl("txtState")).Text;
                        //--------------------

                        NewContact.Phone = ((TextBox)frmViewContacts.FindControl("txtPhone")).Text;
                        NewContact.Ext = ((TextBox)frmViewContacts.FindControl("txtExt")).Text;
                        NewContact.CellPhone = ((TextBox)frmViewContacts.FindControl("txtCellPhone")).Text;
                        NewContact.Fax = ((TextBox)frmViewContacts.FindControl("txtFax")).Text;
                        NewContact.Email = ((TextBox)frmViewContacts.FindControl("txtEmailEdit")).Text;
                        NewContact.EnteredbyID = ((ASIIdentity)User.Identity).UserID;
                        NewContact.EditByID = ((ASIIdentity)User.Identity).UserID;
                        
                        if (dllCompanyName.SelectedValue != "-----")
                        {
                            NewContact.AccountID = int.Parse(dllCompanyName.SelectedValue.ToString());
                            NewContact.MainContact = ((CheckBox)frmViewAccounts.FindControl("chboxMainContact")).Checked;
                            if (((DropDownList)frmViewAccounts.FindControl("dllBranchName")) != null && ((DropDownList)frmViewAccounts.FindControl("dllBranchName")).SelectedValue != "")
                            {
                                // added by Sayed 6/9/2011
                                if (((DropDownList)frmViewAccounts.FindControl("dllBranchName")).SelectedValue != "-----")
                                NewContact.BranchID = int.Parse(((DropDownList)frmViewAccounts.FindControl("dllBranchName")).SelectedValue);
                            }
                        }
                        NewContact.EnterDate = DateTime.Now;
                        NewContact.EditDate = DateTime.Now;
                        if (!string.IsNullOrEmpty(((TextBox)frmViewContacts.FindControl("txtProbabilty")).Text))
                            NewContact.Probability = decimal.Parse(((TextBox)frmViewContacts.FindControl("txtProbabilty")).Text);
                        string Val = NewContact.AddNewContactContactsInfo();
                        if (Val != "-1")
                        {
                            ((HiddenField)frmViewContacts.FindControl("txtContID")).Value = Val;
                            lblAddUserMsg.Text = "Contact Added Successfully";
                            lblAddUserMsg.Visible = true;
                            AddContactMiscellaenous();
                            AddNewContactConnection();
                            AdjustTransButtons(false);
                            AdjustReadOnlyFormStatus(true);
                            // added by sayed 5/9/2011
                            divTabs.Visible = true;
                            //
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "EnableContactTab();", true);
                            LoadSearchPrameters(Val);
                            Session["CurrentNote"] = null;
                            BindFormView();
                            AddjustDropDownListsSelection();
                            gvNotesBindData();
                            // added By Sayed in 24 Ramadan 1432 H.
                            NoteState();
                             //

                            /////Commented By Ehab (2008-04-16)
                            /////Form bind after adding new contact- mglil
                            /////
                            //LoadSearchPrameters(Val);
                            //BindFormView();
                            //NavigateMiscellaneous();
                            //gvNotesBindData();
                            //LoadContactConnectionData();
                            /////
                            /////end -mglil
                            /////


                        }
                    }
                    catch (Exception Exp)
                    {
                        string ErrMsg = Exp.Message;
                        lblAddUserMsg.Text = ErrMsg;
                        lblAddUserMsg.Visible = true;

                    }
                }
            }
        }
    }
    //Insert new contact miscellaneous in Database
    private void AddContactMiscellaenous()
    {
        if (ddlIDStatus.SelectedIndex != 0 || txtSpouse.Text != "" || txtBirthday.Text != "" || txtRefferedBy.Text != "" || txtMiscNotes.Text != "")
        {
            ContactContactMiscellaneous NewContMisc = new ContactContactMiscellaneous();
            try
            {
                NewContMisc.ContactID = int.Parse(((HiddenField)frmViewContacts.FindControl("txtContID")).Value);
                if (txtStatus.Text != "")
                    NewContMisc.IDStatus = int.Parse(txtStatus.Text);
                if (txtBirthday.Text != "")
                    NewContMisc.Birthday = Convert.ToDateTime(txtBirthday.Text);
                NewContMisc.Spouse = txtSpouse.Text;
                NewContMisc.ReferredBy = txtRefferedBy.Text;
                NewContMisc.Note = txtMiscNotes.Text;
                NewContMisc.EnterByID = ((ASIIdentity)User.Identity).UserID;
                NewContMisc.EditByID = ((ASIIdentity)User.Identity).UserID;
                NewContMisc.EnterDate = DateTime.Now;
                NewContMisc.EditDate = DateTime.Now;

                NewContMisc.AddNewContactContactMiscellaneous();

                lblAddMisc.Visible = true;
                lblAddMisc.Text = "Contact Miscellaneous Added Successfully";
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
                lblAddMisc.Visible = true;
                lblAddMisc.Text = ErrMsg;
            }
        }
    }
    //Update the current contact account
    private void UpdateContact()
    {
        if (ValidateData())
        {
            ContactContactsInfo CurrentContact = new ContactContactsInfo();
            try
            {
                CurrentContact.ContactID = int.Parse(((HiddenField)frmViewContacts.FindControl("txtContID")).Value);
                CurrentContact.Intial = ((TextBox)frmViewContacts.FindControl("txtSalutaion")).Text;
                CurrentContact.FirstName = ((TextBox)frmViewContacts.FindControl("txtFirstName")).Text;
                CurrentContact.MiddleIntial = ((TextBox)frmViewContacts.FindControl("txtMI")).Text;
                CurrentContact.LastName = ((TextBox)frmViewContacts.FindControl("txtLastName")).Text;
                int TitleID = 0;
                if (int.TryParse((((TextBox)frmViewContacts.FindControl("txtTitle")).Text), out TitleID))
                    CurrentContact.TitleID = TitleID;
                int DeptID = 0;
                if (int.TryParse((((HiddenField)frmViewContacts.FindControl("txtDepartment")).Value), out DeptID))
                    CurrentContact.DepartmentID = DeptID;

                CurrentContact.CountryID = int.Parse(((DropDownList)frmViewContacts.FindControl("ddlCountry")).SelectedValue);
                if (((DropDownList)frmViewContacts.FindControl("ddlCountry")).SelectedItem.Text.Trim().ToLower() == "united states")
                    CurrentContact.State = ((DropDownList)frmViewContacts.FindControl("ddlState")).Text;
                else
                    CurrentContact.State = ((TextBox)frmViewContacts.FindControl("txtState")).Text;

                CurrentContact.Phone = ((TextBox)frmViewContacts.FindControl("txtPhone")).Text;
                CurrentContact.Ext = ((TextBox)frmViewContacts.FindControl("txtExt")).Text;
                CurrentContact.CellPhone = ((TextBox)frmViewContacts.FindControl("txtCellPhone")).Text;
                CurrentContact.Fax = ((TextBox)frmViewContacts.FindControl("txtFax")).Text;
                CurrentContact.Email = ((TextBox)frmViewContacts.FindControl("txtEmailEdit")).Text;
                CurrentContact.EditByID = ((ASIIdentity)User.Identity).UserID;
                CurrentContact.AccountID = null;
                if (dllCompanyName.SelectedValue != "-----")
                    CurrentContact.AccountID = int.Parse(dllCompanyName.SelectedValue.ToString());
                CurrentContact.EditDate = DateTime.Now;
                CurrentContact.BranchID = null;
                if ((frmViewAccounts.FindControl("dllBranchName") != null) && (((DropDownList)frmViewAccounts.FindControl("dllBranchName")).SelectedValue != ""))
                {
                    if (((DropDownList)frmViewAccounts.FindControl("dllBranchName")).SelectedValue != "-----")
                    CurrentContact.BranchID = int.Parse(((DropDownList)frmViewAccounts.FindControl("dllBranchName")).SelectedValue);
                }

                if (frmViewAccounts.FindControl("chboxMainContact") != null)
                    CurrentContact.MainContact = ((CheckBox)frmViewAccounts.FindControl("chboxMainContact")).Checked;

                decimal Probability = 0;
                if (decimal.TryParse((((TextBox)frmViewContacts.FindControl("txtProbabilty")).Text), out Probability))
                    CurrentContact.Probability = Probability;
                UpdateAllContactNote(CurrentContact.ContactID.Value, CurrentContact.AccountID, CurrentContact.BranchID);
                CurrentContact.UpdateContactContactsInfo();

                ((HyperLink)frmViewContacts.FindControl("txtEmail")).Text = CurrentContact.Email;
                lblAddUserMsg.Text = "Contact Updated Successfully";
                lblAddUserMsg.Visible = true;
                UpdateContactMiscellaenous();
                AddNewContactConnection();
                AdjustTransButtons(false);
                AdjustReadOnlyFormStatus(true);

                AddjustDropDownListsSelection();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "EnableContactTab();", true);
                gvNotesBindData();
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
                lblAddUserMsg.Text = ErrMsg;
                lblAddUserMsg.Visible = true;
            }
        }
    }
    //Enable Or Disable Controls in Case of editing 
    private void AdjustReadOnlyFormStatus(bool Flag)
    {
        //Contact Info
        ((TextBox)frmViewContacts.FindControl("txtSalutaion")).ReadOnly = Flag;
        ((TextBox)frmViewContacts.FindControl("txtFirstName")).ReadOnly = Flag;
        ((TextBox)frmViewContacts.FindControl("txtMI")).ReadOnly = Flag;
        ((TextBox)frmViewContacts.FindControl("txtLastName")).ReadOnly = Flag;
        ((TextBox)frmViewContacts.FindControl("txtPhone")).ReadOnly = Flag;
        ((TextBox)frmViewContacts.FindControl("txtExt")).ReadOnly = Flag;
        ((TextBox)frmViewContacts.FindControl("txtCellPhone")).ReadOnly = Flag;
        ((TextBox)frmViewContacts.FindControl("txtFax")).ReadOnly = Flag;
        ((TextBox)frmViewContacts.FindControl("txtEmailEdit")).ReadOnly = Flag;
        ((TextBox)frmViewContacts.FindControl("txtEmailEdit")).Visible = !Flag;
        ((HyperLink)frmViewContacts.FindControl("txtEmail")).Visible = Flag;
        ((TextBox)frmViewContacts.FindControl("txtCountryID")).ReadOnly = Flag;
        ((TextBox)frmViewContacts.FindControl("txtState")).ReadOnly = Flag;
        ((TextBox)frmViewContacts.FindControl("txtProbabilty")).ReadOnly = Flag;
        ((DropDownList)frmViewContacts.FindControl("ddlTitle")).Enabled = !Flag;
        ((DropDownList)frmViewContacts.FindControl("ddlDepartments")).Enabled = !Flag;
        ((DropDownList)frmViewContacts.FindControl("ddlState")).Enabled = !Flag;
        dllCompanyName.Enabled = !Flag;
        ddlBusSector.Enabled = !Flag;


        ((DropDownList)frmViewContacts.FindControl("ddlCountry")).Enabled = !Flag;
        //if (frmViewAccounts.FindControl("chboxMainContact") != null)
        //{
            //((CheckBox)frmViewAccounts.FindControl("chboxMainContact")).Enabled = !Flag;
        if (frmViewAccounts.FindControl("dllBranchName") != null)
            ((DropDownList)frmViewAccounts.FindControl("dllBranchName")).Enabled = !Flag;
        //}

        EnableStateControls();

        //Contact Miscellaneous
        ddlIDStatus.Enabled = !Flag;
        txtSpouse.ReadOnly = Flag;
        txtRefferedBy.ReadOnly = Flag;
        txtBirthday.ReadOnly = Flag;
        txtStatus.ReadOnly = Flag;
        txtMiscNotes.ReadOnly = Flag;
        imCalendar.Enabled = !Flag;

        //ContactConnection
        ddlLastResults.Enabled = !Flag;
    }
    private void UpdateContactMiscellaenous()
    {
        ContactContactMiscellaneous CurrentContMisc = new ContactContactMiscellaneous();
        CurrentContMisc.ContactID = int.Parse(((HiddenField)frmViewContacts.FindControl("txtContID")).Value);
        if (!CurrentContMisc.CheckRecordExistance())
        {
            AddContactMiscellaenous();
        }
        else
        {
            if (ddlIDStatus.SelectedIndex != 0 || txtSpouse.Text != "" || txtBirthday.Text != "" || txtRefferedBy.Text != "" || txtMiscNotes.Text != "")
            {

                try
                {
                    CurrentContMisc.MID = int.Parse(txtMID.Text);
                    if (txtStatus.Text != "")
                        CurrentContMisc.IDStatus = int.Parse(txtStatus.Text);
                    if (txtBirthday.Text != "")
                    {
                        try
                        {
                            CurrentContMisc.Birthday = Convert.ToDateTime(txtBirthday.Text);
                        }
                        catch { }
                    }
                    CurrentContMisc.Spouse = txtSpouse.Text;
                    CurrentContMisc.ReferredBy = txtRefferedBy.Text;
                    CurrentContMisc.Note = txtMiscNotes.Text;
                    CurrentContMisc.EditByID = ((ASIIdentity)User.Identity).UserID;
                    CurrentContMisc.EditDate = DateTime.Now;

                    CurrentContMisc.UpdateContactContactMiscellaneous();

                    lblAddMisc.Visible = true;
                    lblAddMisc.Text = "Contact Miscellaneous Updated Successfully";
                }
                catch (Exception Exp)
                {
                    string ErrMsg = Exp.Message;
                    lblAddMisc.Visible = true;
                    lblAddMisc.Text = ErrMsg;
                }
            }
        }
    }
    void ucTransToolBar_btnDeleteEvent(object sender, EventArgs e)
    {
        if (frmViewContacts.FindControl("txtContID") != null)
        {
            int ContactID;
            if (int.TryParse(((HiddenField)frmViewContacts.FindControl("txtContID")).Value, out ContactID))
                lblMsg.Text = DeleteContactByID(ContactID);

            if (lblMsg.Text == "Contact deleted successfully!")
            {
                ViewState["ContactDeleted"] = true;
                Session["SingleAccount"] = null;
                ViewState["SpecificFilter"] = "";
                frmViewAccounts.DataSource = null;
                frmViewAccounts.DataBind();
                Session["Contact"] = null;
                BindFormView();
                AdjustReadOnlyFormStatus(true);
                AdjustTransButtons(false);
                LoadSearchPrameters();
                BindFormView();
                AddjustDropDownListsSelection();
                NavigateMiscellaneous();
                gvNotesBindData();
            }
        }
        else
            lblMsg.Text = "There is no contact to delete.";
    }

    private void ucUserTabs_btnAccountsEvent(object sender, EventArgs e)
    {
        Response.Redirect("Accounts.aspx");
    }
    private void ucUserTabs_btnAccountListsEvent(object sender, EventArgs e)
    {
        Response.Redirect("AccountLists.aspx");
    }
    private void ucUserTabs_btnContactsEvent(object sender, EventArgs e)
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
    
    protected void ucAutoCompleteSearch_ddlFindTypeEvent(object sender, EventArgs e)
    {
        DropDownList ddlFindType = (DropDownList)ucAutoCompleteSearch.FindControl("ddlFindType");
        Session["ContactFilterField"] = ddlFindType.SelectedValue;
        //
        ((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text = "";
        AssignReportParameters();

    }
    private void ucAutoCompleteSearch_btnSearchEvent(object sender, EventArgs e)
    {
        lblEmptyResults.Visible = false;
        if (((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text.Length > 0)
        {
            SetSpecificAccountFilter();
            LoadSearchPrameters();
            BindFormView();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "EnableContactTab();", true);
            gvNotesBindData();
            divTabs.Visible = frmViewContacts.DataKey.Value != null;
            AdjustTransButtons(false);
            if (frmViewContacts.DataKey.Value != null)
            {
                AddjustDropDownListsSelection();
                NavigateMiscellaneous();
                LoadContactConnectionData();
            }
            else
            {
                ((ImageButton)ucTransToolBar.FindControl("btnEdit")).Visible = false;
                ((ImageButton)ucTransToolBar.FindControl("btnDelete")).Visible = false;
                ((ImageButton)ucTransToolBar.FindControl("btnAdd")).Visible = false;
                lblEmptyResults.Visible = true;
            }
        }
        else
        {
            Session["SingleAccount"] = null;
            Session["CurrentNote"] = null;
            ViewState["ContactID"] = "";
            ViewState["SpecificFilter"] = "";
            LoadSearchPrameters();
            BindFormView();
            divTabs.Visible = frmViewContacts.DataKey.Value != null;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "EnableContactTab();", true);
            frmViewAccounts.DataSource = null;
            frmViewAccounts.DataBind();
            AddjustDropDownListsSelection();
            ddlIDStatus.DataBind();
            NavigateMiscellaneous();
            gvNotesBindData();
            LoadContactConnectionData();
            AssignReportParameters();
        }
        imgbtnNext.Visible = false;
        imgbtnPrevious.Visible = false;
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        ContactContactsInfo CCI = new ContactContactsInfo();
        ContactLists objContacts = new ContactLists();
        string[] AccNames = new string[0];

        string SelectedTableName = objContacts.Session["ContactFilterField"].ToString();

        if (SelectedTableName == "Company")
            AccNames = CCI.GetSearchList(prefixText, ContactContactsInfo.SearchBy.AName);

        if (SelectedTableName == "Email")
            AccNames = CCI.GetSearchList(prefixText, ContactContactsInfo.SearchBy.Email);

        if (SelectedTableName == "Fax")
            AccNames = CCI.GetSearchList(prefixText, ContactContactsInfo.SearchBy.Fax);

        if (SelectedTableName == "Contact First Name")
            AccNames = CCI.GetSearchList(prefixText, ContactContactsInfo.SearchBy.FirstName);

        if (SelectedTableName == "Contact Last Name")
            AccNames = CCI.GetSearchList(prefixText, ContactContactsInfo.SearchBy.LastName);

        if (SelectedTableName == "Telephone")
            AccNames = CCI.GetSearchList(prefixText, ContactContactsInfo.SearchBy.Phone);

        return AccNames;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        PopupControlExtender1.Cancel();
    }

    protected void gvNotes_SelectedIndexChanged(object sender, EventArgs e)
    {
        int NoteID = (int)(gvNotes.DataKeys[gvNotes.SelectedIndex].Values["NID"]);
        Session["CurrentNote"] = new AccountListsBLL().GetContactNote(NoteID);
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

    protected void gvNotesBindData()
    {
        //TabContainer1.Enabled = true;
        int CID = 1;
        if (frmViewContacts.SelectedValue != null)
        {
            string x = ((TextBox)frmViewContacts.FindControl("txtLastName")).Text;
            if (!int.TryParse(frmViewContacts.SelectedValue.ToString(), out CID))
                CID = -1;


            if (Session["CurrentNote"] == null)
            {
                ContactNotes CNote = new ContactNotes();
                CNote.ContactID = CID;
                Session["CurrentNote"] = CNote;
            }
            else
                ((ContactNotes)Session["CurrentNote"]).ContactID = CID;

            gvNotes.DataSource = odsNotes;
            gvNotes.DataBind();

            gvNotes.SelectedIndex = -1;
            Session["CurrentNote"] = null;
        }
    }

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

    private void LoadNoteSearchPrameters()
    {
        // commented by Sayed 26-4-2012
        //ViewState["SortType"] = "Desc"; 
        Session["CurrentNote"] = GetNotesSortFilter(ViewState["orderbyField"].ToString(), ViewState["SortType"].ToString());
        // commented by Sayed 26-4-2012
       // ViewState["SortType"] = "ASC"; 
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

    protected void gvNotes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvNotes.SelectedIndex = -1;
        gvNotes.PageIndex = e.NewPageIndex;
        gvNotesBindData();
    }


    private void OrderBy(string field)
    {
        if (ViewState["SortType"] != null)
        {
            if (ViewState["SortType"].ToString().Trim() == "ASC".Trim())
            {
                ViewState["SortType"] = "Desc";
            }
            else
            {
                ViewState["SortType"] = "ASC";
            }
        }
        else
            ViewState["SortType"] = "Desc";
        ViewState["orderbyField"] = field;
    }

    protected void btnClosePanel_Click(object sender, ImageClickEventArgs e)
    {
        PopupControlExtender1.Cancel();
    }

    protected void dllCompanyName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindAccountFormView();
    }
    private void BindAccountFormView()
    {
        if (dllCompanyName.SelectedValue != "" && dllCompanyName.SelectedValue != "-----")
        {
            ContactAccount CntAcc = new ContactAccount();
            CntAcc.AccountID = int.Parse(dllCompanyName.SelectedValue);
            Session["SingleAccount"] = CntAcc;

            frmViewAccounts.DataSource = odsAccounts;
            frmViewAccounts.DataBind();
            if (((HiddenField)frmViewContacts.FindControl("txtBrID")).Value.Length > 0)
                ((DropDownList)frmViewAccounts.FindControl("dllBranchName")).SelectedValue = ((HiddenField)frmViewContacts.FindControl("txtBrID")).Value;
            //((DropDownList)frmViewAccounts.FindControl("dllBranchName")).Enabled = true;
            //((CheckBox)frmViewAccounts.FindControl("chboxMainContact")).Enabled = true;
        }
        else
        {
            frmViewAccounts.DataSource = null;
            frmViewAccounts.DataBind();
        }
    }

    protected void dllCompanyName_DataBound(object sender, EventArgs e)
    {
        //if (dllCompanyName.Items[0].Value != "-----")
        //{
        //    ListItem FirstItem = new ListItem("-----", "-----");
        //    dllCompanyName.Items.Insert(0, FirstItem);
        //}
        BindAccountFormView();
    }
    protected void dllCompanyName_DataBinding(object sender, EventArgs e)
    {
        dllCompanyName.Items.Clear();
            ListItem FirstItem = new ListItem("-----", "-----");
            dllCompanyName.Items.Insert(0, FirstItem);
        //BindAccountFormView();
    }
    protected void dllBranchName_DataBinding(object sender, EventArgs e)
    {
        DropDownList dllBranchName = ((DropDownList)frmViewAccounts.FindControl("dllBranchName"));
        dllBranchName.Items.Clear();
        ListItem FirstItem = new ListItem("-----", "-----");
        dllBranchName.Items.Insert(0, FirstItem);
    }
    protected void frmViewContacts_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {
        frmViewContacts.PageIndex = e.NewPageIndex;
        // reload the search paramter - mglil
        DropDownList ddlFindType = (DropDownList)ucAutoCompleteSearch.FindControl("ddlFindType");
        Session["ContactFilterField"] = ddlFindType.SelectedValue;
        LoadSearchPrameters();
        // end - mglil
        //ContactContactsInfo CCI = new ContactContactsInfo();
        //CCI = (ContactContactsInfo)Session["Contact"];
        //CCI.FirstName = "";
        //Session["Contact"] = CCI;
        frmViewContacts.DataSource = odsContacts;
        frmViewContacts.DataBind();
        //
        HandleNextPrevButton();
        //
        AddjustDropDownListsSelection();
        //EnableStateControls();
        NavigateMiscellaneous();
        if (((HiddenField)frmViewContacts.FindControl("txtAccID")).Value != "")
        {
            dllCompanyName.SelectedValue = ((HiddenField)frmViewContacts.FindControl("txtAccID")).Value;
            BindAccountFormView();
        }
        else
            dllCompanyName.SelectedValue = "-----";
        dllCompanyName_SelectedIndexChanged(null, null);
        LoadContactConnectionData();
        ViewState["SelectedResult"] = null;
        AdjustTransButtons(false);
        OrderBy("UserEnterDate");
        LoadNoteSearchPrameters();
        gvNotesBindData();
        Session["SelectedContactID"] = ((HiddenField)frmViewContacts.FindControl("txtContID")).Value;
        Key1.BindGridView();
        HistoryNC1.BindGridView();
        Attachment1.BindGridView();
        if (sender != null)
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "EnableContactTab();", true);
    }
    private void AddjustDropDownListsSelection()
    {
        if (frmViewContacts.FindControl("txtDepartment") != null)
        {
            if (((HiddenField)frmViewContacts.FindControl("txtDepartment")).Value.Length == 0)
                ((DropDownList)frmViewContacts.FindControl("ddlDepartments")).SelectedIndex = 0;
            else
                ((DropDownList)frmViewContacts.FindControl("ddlDepartments")).SelectedValue = ((HiddenField)frmViewContacts.FindControl("txtDepartment")).Value;
            ((DropDownList)frmViewContacts.FindControl("ddlTitle")).SelectedValue = ((TextBox)frmViewContacts.FindControl("txtTitle")).Text;
            DropDownList ddlCountry = ((DropDownList)frmViewContacts.FindControl("ddlCountry"));
            string txtCountryID = ((TextBox)frmViewContacts.FindControl("txtCountryID")).Text;
            if(ddlCountry.Items.FindByValue(txtCountryID) != null)
                ((DropDownList)frmViewContacts.FindControl("ddlCountry")).SelectedValue = txtCountryID;
            EnableStateControls();
            try
            {
                if (((HiddenField)frmViewContacts.FindControl("txtAccID")).Value.Trim() == "")
                {
                    //if (!(dllCompanyName.Items.Count > 0))
                    //dllCompanyName.SelectedIndex = -1;

                    //Commented by Yasser 31-7-2011
                    //dllCompanyName.SelectedValue = "";
                    //dllCompanyName.DataBind();
                    //dllCompanyName.SelectedValue = "-----";
                    dllCompanyName.SelectedValue = "-----";

                    string txtBrID = ((HiddenField)frmViewContacts.FindControl("txtBrID")).Value;
                    if (txtBrID.Length > 0)
                    {
                        string strAccID = GetAccountIDByBranchID(Convert.ToInt32(txtBrID)).ToString();
                        dllCompanyName.SelectedValue = strAccID;
                        BindAccountFormView();
                    }

                }
                else
                {
                    dllCompanyName.SelectedValue = ((HiddenField)frmViewContacts.FindControl("txtAccID")).Value;
                    BindAccountFormView();
                }
            }
            catch { }
        }
    }
    private void NavigateMiscellaneous()
    {
        ContactListsBLL CLB = new ContactListsBLL();
        ContactContactMiscellaneous CCM = new ContactContactMiscellaneous();
        CCM.ContactID = int.Parse(frmViewContacts.SelectedValue.ToString());
        CCM = CLB.GetContactMiscellaneous(CCM);
        if (CCM.MID != null)
        {
            txtMID.Text = CCM.MID.ToString();
            if (CCM.Birthday != null)
                txtBirthday.Text = CCM.Birthday.Value.ToShortDateString();
            txtSpouse.Text = CCM.Spouse;
            txtRefferedBy.Text = CCM.ReferredBy;
            txtMiscNotes.Text = CCM.Note;
            if (CCM.IDStatus != null && ddlIDStatus.Items.FindByValue(CCM.IDStatus.Value.ToString()) != null)
            {
                ddlIDStatus.SelectedValue = CCM.IDStatus.ToString();
                txtStatus.Text = ddlIDStatus.SelectedValue;
            }
        }
        else
            ResetMiscellaneous();
    }
    //Add New ContactConnection Record
    private void AddNewContactConnection()
    {
        if (ViewState["SelectedResult"] != null && ViewState["SelectedResult"].ToString() != "" && ViewState["SelectedResult"].ToString() != "-----")
        {
            try
            {
                ContactConnection NewContCon = new ContactConnection();
                NewContCon.ContactID = int.Parse(((HiddenField)frmViewContacts.FindControl("txtContID")).Value);
                NewContCon.ConnectionDate = DateTime.Now;
                NewContCon.UserID = ((ASIIdentity)User.Identity).UserID;
                NewContCon.ConnectionTypeID = int.Parse(ViewState["SelectedResult"].ToString());
                NewContCon.AddNewContactConnection();
                lblAddResultMsg.Visible = true;
                lblAddResultMsg.Text = "Results Saved Successfully";
                ViewState["SelectedResult"] = null;
            }
            catch (Exception Exp)
            {
                lblAddResultMsg.Visible = true;
                lblAddResultMsg.Text = "Couldn't Save Results; " + Exp.Message;
            }
        }
    }
    //Add contact connection data (Last Result, Last Meet,...ect)
    private void LoadContactConnectionData()
    {
        if (frmViewContacts.SelectedValue != null)
        {
            int ContID = int.Parse(frmViewContacts.SelectedValue.ToString());
            ContactConnection CurrentConnect = new ContactConnection();
            MainSubCode MSC;

            CurrentConnect.ContactID = ContID;
            //Get All ContactConnection data
            CurrentConnect = CurrentConnect.GetContactConnection();
            if (CurrentConnect.ConnectionID != null)
            {
                txtLastEditBy.Text = CurrentConnect.UserName;
                txtDate.Text = CurrentConnect.ConnectionDate.Value.ToShortDateString();
                ddlLastResults.SelectedValue = CurrentConnect.ConnectionTypeID.ToString();


                //Get Last Attempt
                MSC = new MainSubCode();
                MSC.SubCode = "Attemp";
                MSC = MSC.GetSpecificSubCode();
                if (MSC.SubID != null)
                {
                    CurrentConnect = new ContactConnection();
                    CurrentConnect.ContactID = ContID;
                    CurrentConnect.ConnectionTypeID = MSC.SubID;
                    DateTime dtlastAttempt = CurrentConnect.GetLastAction();
                    if (dtlastAttempt != DateTime.MinValue)
                        txtLastAttempt.Text = dtlastAttempt.ToShortDateString();
                    else
                        txtLastAttempt.Text = "";
                }
                else
                    txtLastAttempt.Text = "";

                //Get Last Meeting
                MSC = new MainSubCode();
                MSC.SubCode = "Meeting";
                MSC = MSC.GetSpecificSubCode();
                if (MSC.SubID != null)
                {
                    CurrentConnect = new ContactConnection();
                    CurrentConnect.ContactID = ContID;
                    CurrentConnect.ConnectionTypeID = MSC.SubID;
                    DateTime dtlastMeet = CurrentConnect.GetLastAction();
                    if (dtlastMeet != DateTime.MinValue)
                        txtLastMeet.Text = dtlastMeet.ToShortDateString();
                    else
                        txtLastMeet.Text = "";
                }
                else
                    txtLastMeet.Text = "";

                //Get Last Reach
                MSC = new MainSubCode();
                MSC.SubCode = "Reach";
                MSC = MSC.GetSpecificSubCode();
                if (MSC.SubID != null)
                {
                    CurrentConnect = new ContactConnection();
                    CurrentConnect.ContactID = ContID;
                    CurrentConnect.ConnectionTypeID = MSC.SubID;
                    DateTime dtlastReach = CurrentConnect.GetLastAction();
                    if (dtlastReach != DateTime.MinValue)
                        txtLastReach.Text = dtlastReach.ToShortDateString();
                    else
                        txtLastReach.Text = "";
                }
                else
                    txtLastReach.Text = "";
            }
            else
            {
                ddlLastResults.SelectedIndex = 0;
                txtDate.Text = "";
                txtLastAttempt.Text = "";
                txtLastEditBy.Text = "";
                txtLastMeet.Text = "";
                txtLastReach.Text = "";
                ViewState["SelectedResult"] = null;
            }
        }
        else
        {
            ddlLastResults.SelectedIndex = 0;
            txtDate.Text = "";
            txtLastAttempt.Text = "";
            txtLastEditBy.Text = "";
            txtLastMeet.Text = "";
            txtLastReach.Text = "";
            ViewState["SelectedResult"] = null;
        }
    }
    private void ResetMiscellaneous()
    {
        ddlIDStatus.SelectedIndex = 0;
        txtRefferedBy.Text = "";
        txtMiscNotes.Text = "";
        txtSpouse.Text = "";
        txtStatus.Text = "";
        txtBirthday.Text = "";
    }
    protected void ddlIDStatus_DataBound(object sender, EventArgs e)
    {
        if (ddlIDStatus.Items[0].Text != "-----")
        {
            ListItem FirstItem = new ListItem("-----", "-----");
            ddlIDStatus.Items.Insert(0, FirstItem);
            ddlIDStatus.SelectedIndex = ddlIDStatus.SelectedIndex - 1;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //ShowNoteDataControls(true);
        //ShowNoteDataControls(false);
        PopupControlExtender1.Cancel();
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
                    //ShowNoteDataControls(false);
                    txtCalender.Text = "";
                }
                else
                    lblMsg.Text = "Error while updating note.";
            }
            else if (txtContact.Text.Length == 0)
            {
                int CID = 1;
                if (int.TryParse(frmViewContacts.SelectedValue.ToString(), out CID))
                {
                    int? AID = null;
                    if (dllCompanyName.SelectedValue != "-----")
                        AID = Convert.ToInt32(dllCompanyName.SelectedValue);
                    int? BID = null;
                    if ((frmViewAccounts.FindControl("dllBranchName") != null) && (((DropDownList)frmViewAccounts.FindControl("dllBranchName")).SelectedValue != ""))
                    {
                        if (((DropDownList)frmViewAccounts.FindControl("dllBranchName")).SelectedValue != "-----")
                            BID = int.Parse(((DropDownList)frmViewAccounts.FindControl("dllBranchName")).SelectedValue);
                    }
                    if (AddContactNote(AdjustWordsLengths(hdnNote.Value), CID, AID, BID, EDate))
                    {
                        lblMsg.Text = "Note has been added successfully!";
                        //ShowNoteDataControls(false);
                        txtCalender.Text = "";
                    }
                    else
                        lblMsg.Text = "Error while adding note.";
                }
                else
                    lblMsg.Text = "Please choose an account to add notes for it.";
            }
        }
        //ShowNoteDataControls(true);
        Session["CurrentNote"] = null;
        ViewState["SortType"] = "Desc";
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
                for (int i = 0; i < str.Length; i += 30)
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
    protected void ddlIDStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtStatus.Text = ddlIDStatus.SelectedValue;
    }
    protected void ddlTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        ((TextBox)frmViewContacts.FindControl("txtTitle")).Text = ((DropDownList)frmViewContacts.FindControl("ddlTitle")).SelectedValue.ToString();
    }
    protected void ddlDepartments_SelectedIndexChanged(object sender, EventArgs e)
    {
        ((HiddenField)frmViewContacts.FindControl("txtDepartment")).Value = ((DropDownList)frmViewContacts.FindControl("ddlDepartments")).SelectedValue.ToString();
    }
    protected void imgbtnSignOut_Click(object sender, ImageClickEventArgs e)
    {
        SignOut();
    }
    protected void ddlLastResults_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["SelectedResult"] = ddlLastResults.SelectedValue;
    }
    protected void ddlLastResults_DataBound(object sender, EventArgs e)
    {
        if (ddlLastResults.Items[0].Value != "-----")
        {
            ListItem FirstItem = new ListItem("-----", "-----");
            ddlLastResults.Items.Insert(0, FirstItem);
        }
    }
    protected void btnNewAccount_Click(object sender, EventArgs e)
    {
        AddNewAccount();
    }
    private void AddNewAccount()
    {
        Session["NewAccount"] = true;
        Response.Redirect("AccountLists.aspx");
    }
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        ((TextBox)frmViewContacts.FindControl("txtCountryID")).Text = ((DropDownList)frmViewContacts.FindControl("ddlCountry")).SelectedValue.ToString();
        EnableStateControlsWithCountryChanged();
    }
    private void EnableStateControlsWithCountryChanged()
    {
        if (((DropDownList)frmViewContacts.FindControl("ddlCountry")).SelectedItem.Text.ToString().Trim().ToLower() == "united states")
        {
            ((DropDownList)frmViewContacts.FindControl("ddlState")).Visible = true;
            ((TextBox)frmViewContacts.FindControl("txtState")).Visible = false;
            if (((DropDownList)(frmViewContacts.FindControl("ddlState"))).Items.FindByText(((TextBox)(frmViewContacts.FindControl("txtState"))).Text) != null)
                ((DropDownList)(frmViewContacts.FindControl("ddlState"))).SelectedValue = ((TextBox)(frmViewContacts.FindControl("txtState"))).Text;
        }
        else
        {
            ((DropDownList)frmViewContacts.FindControl("ddlState")).Visible = false;
            ((TextBox)frmViewContacts.FindControl("txtState")).Visible = true;
            ((TextBox)frmViewContacts.FindControl("txtState")).Text = "";
        }
    }
    private void EnableStateControls()
    {
        if (((DropDownList)frmViewContacts.FindControl("ddlCountry")).SelectedItem.Text.ToString().Trim().ToLower() == "united states")
        {
            ((DropDownList)frmViewContacts.FindControl("ddlState")).Visible = true;
            ((TextBox)frmViewContacts.FindControl("txtState")).Visible = false;
            if (((DropDownList)(frmViewContacts.FindControl("ddlState"))).Items.FindByText(((TextBox)(frmViewContacts.FindControl("txtState"))).Text) != null)
                ((DropDownList)(frmViewContacts.FindControl("ddlState"))).SelectedValue = ((TextBox)(frmViewContacts.FindControl("txtState"))).Text;
        }
        else
        {
            ((DropDownList)frmViewContacts.FindControl("ddlState")).Visible = false;
            ((TextBox)frmViewContacts.FindControl("txtState")).Visible = true;
        }
    }
    protected void ibtnAddNewAcc_Click(object sender, ImageClickEventArgs e)
    {
        AddNewAccount();
    }
    private bool ValidateData()
    {
        bool Valid = true;
        if (((TextBox)frmViewContacts.FindControl("txtFirstName")).Text.Trim() == "")
        {
            ((Label)frmViewContacts.FindControl("lblFNError")).Text = "First name is required";
            ((Label)frmViewContacts.FindControl("lblFNError")).Visible = true;
            ((Label)frmViewContacts.FindControl("lblFNSym")).Visible = true;
            Valid = false;
        }
        else
        {
            ((Label)frmViewContacts.FindControl("lblFNError")).Text = "";
            ((Label)frmViewContacts.FindControl("lblFNError")).Visible = false;
            ((Label)frmViewContacts.FindControl("lblFNSym")).Visible = false;
        }
        if (((TextBox)frmViewContacts.FindControl("txtLastName")).Text.Trim() == "")
        {
            ((Label)frmViewContacts.FindControl("lblLNError")).Text = "Last name is required";
            ((Label)frmViewContacts.FindControl("lblLNError")).Visible = true;
            ((Label)frmViewContacts.FindControl("lblLNSym")).Visible = true;
            Valid = false;
        }
        else
        {
            ((Label)frmViewContacts.FindControl("lblLNError")).Text = "";
            ((Label)frmViewContacts.FindControl("lblLNError")).Visible = false;
            ((Label)frmViewContacts.FindControl("lblLNSym")).Visible = false;
        }
        if (((TextBox)frmViewContacts.FindControl("txtEmailEdit")).Text != "")
        {
            string EmailExp = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            if (!(System.Text.RegularExpressions.Regex.Match(((TextBox)frmViewContacts.FindControl("txtEmailEdit")).Text, EmailExp).Success))
            {
                ((Label)frmViewContacts.FindControl("lblEmailError")).Text = "E-Mail address is not valid";
                ((Label)frmViewContacts.FindControl("lblEmailError")).Visible = true;
                ((Label)frmViewContacts.FindControl("lblEmailSym")).Visible = true;
                Valid = false;
            }
            else
            {
                ((Label)frmViewContacts.FindControl("lblEmailError")).Text = "";
                ((Label)frmViewContacts.FindControl("lblEmailError")).Visible = false;
                ((Label)frmViewContacts.FindControl("lblEmailSym")).Visible = false;
            }
        }
        else
        {
            ((Label)frmViewContacts.FindControl("lblEmailError")).Text = "";
            ((Label)frmViewContacts.FindControl("lblEmailError")).Visible = false;
            ((Label)frmViewContacts.FindControl("lblEmailSym")).Visible = false;
        }

        //if (((TextBox)frmViewContacts.FindControl("txtPhone")).Text != "")
        //{
        //    string PhoneExp = @"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}";
        //    if (!(System.Text.RegularExpressions.Regex.Match(((TextBox)frmViewContacts.FindControl("txtPhone")).Text, PhoneExp).Success))
        //    {
        //        ((Label)frmViewContacts.FindControl("lblPhoneError")).Text = "Phone Format is not valid";
        //        ((Label)frmViewContacts.FindControl("lblPhoneError")).Visible = true;
        //        ((Label)frmViewContacts.FindControl("lblPhoneSym")).Visible = true;
        //        Valid = false;
        //    }
        //    else
        //    {
        //        ((Label)frmViewContacts.FindControl("lblPhoneError")).Text = "";
        //        ((Label)frmViewContacts.FindControl("lblPhoneError")).Visible = false;
        //        ((Label)frmViewContacts.FindControl("lblPhoneSym")).Visible = false;
        //    }
        //}
        //else
        //{
        //    ((Label)frmViewContacts.FindControl("lblPhoneError")).Text = "";
        //    ((Label)frmViewContacts.FindControl("lblPhoneError")).Visible = false;
        //    ((Label)frmViewContacts.FindControl("lblPhoneSym")).Visible = false;
        //}

        //if (((TextBox)frmViewContacts.FindControl("txtCellPhone")).Text != "")
        //{
        //    string CellPhoneExp = @"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"; //@"^[+]? ?([0-9]*) ?[\(]?([0-9]*)[\)]?  ?([-]?[0-9]*)*$";
        //    if (!(System.Text.RegularExpressions.Regex.Match(((TextBox)frmViewContacts.FindControl("txtCellPhone")).Text, CellPhoneExp).Success))
        //    {
        //        ((Label)frmViewContacts.FindControl("lblCellPhoneError")).Text = "Cell Phone Format is not valid";
        //        ((Label)frmViewContacts.FindControl("lblCellPhoneError")).Visible = true;
        //        ((Label)frmViewContacts.FindControl("lblCellPhoneSym")).Visible = true;
        //        Valid = false;
        //    }
        //    else
        //    {
        //        ((Label)frmViewContacts.FindControl("lblCellPhoneError")).Text = "";
        //        ((Label)frmViewContacts.FindControl("lblCellPhoneError")).Visible = false;
        //        ((Label)frmViewContacts.FindControl("lblCellPhoneSym")).Visible = false;
        //    }
        //}
        //else
        //{
        //    ((Label)frmViewContacts.FindControl("lblCellPhoneError")).Text = "";
        //    ((Label)frmViewContacts.FindControl("lblCellPhoneError")).Visible = false;
        //    ((Label)frmViewContacts.FindControl("lblCellPhoneSym")).Visible = false;
        //}

        //if (((TextBox)frmViewContacts.FindControl("txtFax")).Text != "")
        //{
        //    string FaxExp = @"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}";
        //    if (!(System.Text.RegularExpressions.Regex.Match(((TextBox)frmViewContacts.FindControl("txtFax")).Text, FaxExp).Success))
        //    {
        //        ((Label)frmViewContacts.FindControl("lblFaxError")).Text = "Phone Format is not valid";
        //        ((Label)frmViewContacts.FindControl("lblFaxError")).Visible = true;
        //        ((Label)frmViewContacts.FindControl("lblFaxSym")).Visible = true;
        //        Valid = false;
        //    }
        //    else
        //    {
        //        ((Label)frmViewContacts.FindControl("lblFaxError")).Text = "";
        //        ((Label)frmViewContacts.FindControl("lblFaxError")).Visible = false;
        //        ((Label)frmViewContacts.FindControl("lblFaxSym")).Visible = false;
        //    }
        //}
        //else
        //{
        //    ((Label)frmViewContacts.FindControl("lblFaxError")).Text = "";
        //    ((Label)frmViewContacts.FindControl("lblFaxError")).Visible = false;
        //    ((Label)frmViewContacts.FindControl("lblFaxSym")).Visible = false;
        //}

        if (((TextBox)frmViewContacts.FindControl("txtProbabilty")).Text != "")
        {
            string ProbabiltyExp = @"^-?[0-9]{0,2}(\.[0-9]{1,2})?$|^-?(100)(\.[0]{1,2})?$";
            string TxtProb = ((TextBox)frmViewContacts.FindControl("txtProbabilty")).Text;
            if (!(System.Text.RegularExpressions.Regex.Match(TxtProb, ProbabiltyExp).Success))
            {
                
                ((Label)frmViewContacts.FindControl("lblProbabiltyError")).Text = "Probability is not in this format: (xx.yy)";
                ((Label)frmViewContacts.FindControl("lblProbabiltyError")).Visible = true;
                ((Label)frmViewContacts.FindControl("lblProbabiltySym")).Visible = true;
                Valid = false;
            }
            else
            {
                ((Label)frmViewContacts.FindControl("lblProbabiltyError")).Text = "";
                ((Label)frmViewContacts.FindControl("lblProbabiltyError")).Visible = false;
                ((Label)frmViewContacts.FindControl("lblProbabiltySym")).Visible = false;
            }
        }
        else
        {
            ((Label)frmViewContacts.FindControl("lblProbabiltyError")).Text = "";
            ((Label)frmViewContacts.FindControl("lblProbabiltyError")).Visible = false;
            ((Label)frmViewContacts.FindControl("lblProbabiltySym")).Visible = false;
        }

        return Valid;
    }
    protected void dllBranchName_DataBound(object sender, EventArgs e)
    {
        BranchesBLL Branchobj = new BranchesBLL();
        // select contact Branch
        if (Branchobj.GetContactBranchID(((HiddenField)frmViewContacts.FindControl("txtContID")).Value, dllCompanyName.SelectedValue.ToString()) != "")
        {
            ((DropDownList)frmViewAccounts.FindControl("dllBranchName")).SelectedValue = Branchobj.GetContactBranchID(((HiddenField)frmViewContacts.FindControl("txtContID")).Value, dllCompanyName.SelectedValue.ToString());
        }

        // check the MainContact for Current Branch
        string BranchID = ((DropDownList)frmViewAccounts.FindControl("dllBranchName")).SelectedValue;
        string ContactID = ((HiddenField)frmViewContacts.FindControl("txtContID")).Value;
        ((CheckBox)frmViewAccounts.FindControl("chboxMainContact")).Checked = Branchobj.CheckMainContact(ContactID, BranchID);

        if (((ImageButton)ucTransToolBar.FindControl("btnSave")).Visible)
            ((DropDownList)frmViewAccounts.FindControl("dllBranchName")).Enabled = ((DropDownList)frmViewAccounts.FindControl("dllBranchName")).Items.Count > 1;
    }
    protected void ScriptManager1_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
    {
        e.ToString();
    }
    protected void ddlBusSector_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblSelectedBS.Text = ddlBusSector.SelectedItem.Text;
        dllCompanyName.DataBind();
    }
    protected void gvNotes_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int NoteID = (int)(gvNotes.DataKeys[e.RowIndex].Values["NID"]);
        lblMsg.Text = DeleteNoteByID(NoteID);
        ViewState["SortType"] = "Desc";
        OrderBy("UserEnterDate");
        LoadNoteSearchPrameters();
        gvNotesBindData();
    }
    protected void imgbtnNext_Click(object sender, ImageClickEventArgs e)
    {
        if (frmViewContacts.PageIndex == 0 && Session["Contact"] != null)
        {
            int? ID = ((ContactContactsInfo)Session["Contact"]).ContactID;
            if (ID.HasValue)
                frmViewContacts.PageIndex = GetContactOrderNo((ContactContactsInfo)Session["Contact"]);
        }
        ViewState["ContactID"] = "";
        FormViewPageEventArgs FVPEA = new FormViewPageEventArgs(frmViewContacts.PageIndex + 1);
        frmViewContacts_PageIndexChanging(sender == null ? null : this, FVPEA);
        NoteState();
    }
    protected void imgbtnPrevious_Click(object sender, ImageClickEventArgs e)
    {
        if (frmViewContacts.PageIndex == 0 && Session["Contact"] != null)
        {
            int? ID = ((ContactContactsInfo)Session["Contact"]).ContactID;
            if (ID.HasValue)
                frmViewContacts.PageIndex = GetContactOrderNo((ContactContactsInfo)Session["Contact"]);
        }
        ViewState["ContactID"] = "";
        FormViewPageEventArgs FVPEA = new FormViewPageEventArgs((frmViewContacts.PageIndex == frmViewContacts.DataItemCount - 1) ? frmViewContacts.PageIndex : frmViewContacts.PageIndex - 1);
        frmViewContacts_PageIndexChanging(sender == null ? null : this, FVPEA);
        NoteState();
    }
    protected void imgbtnKeySoftware_Click(object sender, ImageClickEventArgs e)
    {

        imgNotesTab.Enabled = true;
        imgNotesTab.ImageUrl = "Images/notes_normal.png";
        imgbtnKeySoftware.Enabled = false;
        imgbtnKeySoftware.ImageUrl = "Images/Keys-o.png";
        imgbtnHistory.Enabled = true;
        imgbtnHistory.ImageUrl = "Images/History-n.png";
        imgbtnAttachments.ImageUrl = "Images/Attachments-n.png";
        imgbtnAttachments.Enabled = true;
        imgbtnCalls.ImageUrl = "Images/CallManagement-n.png";
        imgbtnCalls.Enabled = true;
        Key1.BindGridView();
    }
    protected void imgbtnHistory_Click(object sender, ImageClickEventArgs e)
    {

        imgNotesTab.Enabled = true;
        imgNotesTab.ImageUrl = "Images/notes_normal.png";
        imgbtnKeySoftware.Enabled = true;
        imgbtnKeySoftware.ImageUrl = "Images/Keys-n.png";
        imgbtnAttachments.ImageUrl = "Images/Attachments-n.png";
        imgbtnAttachments.Enabled = true;
        imgbtnCalls.ImageUrl = "Images/CallManagement-n.png";
        imgbtnCalls.Enabled = true;

        imgbtnHistory.ImageUrl = "Images/History-o.png";
        imgbtnHistory.Enabled = false;
        HistoryNC1.BindGridView();
    }
    protected void imgbtnAttachments_Click(object sender, ImageClickEventArgs e)
    {

        imgNotesTab.Enabled = true;
        imgNotesTab.ImageUrl = "Images/notes_normal.png";
        imgbtnKeySoftware.Enabled = true;
        imgbtnKeySoftware.ImageUrl = "Images/Keys-n.png";
        imgbtnHistory.ImageUrl = "Images/History-n.png";
        imgbtnHistory.Enabled = true;
        imgbtnCalls.ImageUrl = "Images/CallManagement-n.png";
        imgbtnCalls.Enabled = true;

        imgbtnAttachments.ImageUrl = "Images/Attachments-o.png";
        imgbtnAttachments.Enabled = false;
        Attachment1.BindGridView();
    }
    protected void imgbtnCalls_Click(object sender, ImageClickEventArgs e)
    {

        imgNotesTab.Enabled = true;
        imgNotesTab.ImageUrl = "Images/notes_normal.png";
        imgbtnKeySoftware.Enabled = true;
        imgbtnKeySoftware.ImageUrl = "Images/Keys-n.png";
        imgbtnAttachments.ImageUrl = "Images/Attachments-n.png";
        imgbtnAttachments.Enabled = true;
        imgbtnHistory.ImageUrl = "Images/History-n.png";
        imgbtnHistory.Enabled = true;
        imgbtnCalls.ImageUrl = "Images/CallManagement-o.png";
        imgbtnCalls.Enabled = false;
        CallsCnt.BindGridView();
    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        Session["SelectedContactID"] = ((HiddenField)frmViewContacts.FindControl("txtContID")).Value;
        if (dllCompanyName.SelectedValue != "-----")
            Session["SelectedAccountID"] = int.Parse(dllCompanyName.SelectedValue.ToString());
        else
            Session["SelectedAccountID"] = null;
        Session["SelectedBranchID"] = null;
        Session["CurrentPage"] = "ContactLists";
    }
}
