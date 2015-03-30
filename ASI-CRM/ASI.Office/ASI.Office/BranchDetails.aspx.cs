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

public partial class BranchDetails : Office.BLL.AccountListsBLL
{
    private int _AccountID;
    private int BranchID;
    public int AccountID
    {
        get { return _AccountID; }
        set { _AccountID = value; }
    }

    public int This_BranchID
    {
        get { return BranchID; }
        set { BranchID = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckUserSession();
        lblAddUserMsg.Visible = false;
      
        if (!IsPostBack)
        {
            Session["CurrentBrnachID"] = Session["SingleBranchID"];// "34";// for testing only


             ViewState["SortType"] = "";
           
                if (ViewState["AccountID"] == null)
                    ViewState["AccountID"] = "";
                ViewState["AccountIDforPaging"] = "";
                Session["CurrentSelectedRowIndex"] = null;
           
            //
				//lblVersionInfo.Text = GetVersionInfo();
            Session["CurrentNote"] = null;


            // added by Sayed 10-6-2011   from Branches page
            //
            if (Session["BranchSortExpression"] == null)
            {
                ViewState["orderbyField"] = "BranchName";
                ViewState["SortType"] = "ASC";
            }
            else
            {
                ViewState["orderbyField"] = Session["BranchSortExpression"].ToString();
                ViewState["SortType"] = Session["BranchSortType"].ToString();
            }
            //

            ViewState["StatusID"] = "All";
            //ViewState["SortType"] = "ASC";
            ViewState["Tag"] = "All";
            ViewState["SpecificAccount"] = "";
            ViewState["LocationFilter"] = "";
            ViewState["SpecificLocation"] = "";
            ViewState["AccountID"] = "";
            BranchesPageBLL.Filter fltr;
            try
            {
                if (Session["BranchFilterField"] == null)
                {
                    fltr = new BranchesPageBLL.Filter();
                    fltr.IncrementalSearch = "Company";
                    fltr.IncrementalSearchValue = "";
                    fltr.BusSector = "-1";
                    fltr.Tag = "-1";
                    fltr.Notes = "-1";
                    fltr.StatusID = -1;
                }
                else
                    fltr = (BranchesPageBLL.Filter)Session["BranchFilterField"];
            }
            catch
            {
                fltr = new BranchesPageBLL.Filter();
                fltr.IncrementalSearch = "Company";
                fltr.IncrementalSearchValue = "";
                fltr.BusSector = "-1";
                fltr.Tag = "-1";
                fltr.Notes = "-1";
                fltr.StatusID = -1;

            }
            Session["BranchFilterField"] = fltr;
            if (Session["FilterBranchNotes"] == null)
            {
                Session["FilterBranchNotes"] = 0;
            }
            //
            

            LoadData();
            Session["SelectedBranchID"] = ((HiddenField)frmViewBranchDetails.FindControl("HiddenBranchID")).Value;
            Session["CurrentPage"] = "BranchDetails";
            AdjustNextPreviousButtons();
            // added By Sayed 17/10/2011
            OrderBy("UserEnterDate");
            LoadNoteSearchPrameters();
            //
            gvNotesBindData();
            

            //ddlBusSector.DataSource = odsBusSectorNames; //GetAllBusSectorList();
            ddlBusSector.DataBind();
            ddlBusSector.Items.Insert(0, "All");
            ViewState["BranchDeleted"] = false;
            
            imgNotesTab.Attributes.Add("onmouseover", "this.src= 'Images/notes_over.png';");
            imgNotesTab.Attributes.Add("onmouseout", "this.src= 'Images/notes_normal.png';");
            imgContactsTab.Attributes.Add("onmouseover", "this.src= 'Images/contacts_over.png';");
            imgContactsTab.Attributes.Add("onmouseout", "this.src= 'Images/contacts_normal.png';");
            imgbtnKeySoftware.Attributes.Add("onmouseover", "this.src= 'Images/Keys-o.png';");
            imgbtnKeySoftware.Attributes.Add("onmouseout", "this.src= 'Images/Keys-n.png';");
            imgbtnHistory.Attributes.Add("onmouseover", "this.src= 'Images/History-o.png';");
            imgbtnHistory.Attributes.Add("onmouseout", "this.src= 'Images/History-n.png';");
            imgbtnAttachments.Attributes.Add("onmouseover", "this.src= 'Images/Attachments-o.png';");
            imgbtnAttachments.Attributes.Add("onmouseout", "this.src= 'Images/Attachments-n.png';");
        }


        string CurrentPage = "BranchDetails";
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
		  //ucUserTabs.btnContactListsEvent +=new EventHandler(ucUserTabs_btnContactListsEvent);
		  //ucUserTabs.btnBranchesEvent +=new EventHandler(ucUserTabs_btnBranchesEvent);
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
        Contacts1.ContactsSortingEvent += new GridViewSortEventHandler(Contacts1_ContactsSortingEvent);

        Contacts1.BindGridView();
        Key1.BindGridView();
        HistoryNC1.BindGridView();
        Attachment1.BindGridView();
    }

    private void LoadData()
    {
        // added by Sayed
        BranchesPageBLL branch = new BranchesPageBLL();
        Session["Branch"] = branch.GetSearchFilter(ViewState["orderbyField"].ToString(), ViewState["SortType"].ToString(), ViewState["SpecificAccount"].ToString(), (BranchesPageBLL.Filter)Session["BranchFilterField"], ViewState["LocationFilter"].ToString(), ViewState["SpecificLocation"].ToString(), int.Parse(Session["FilterBranchNotes"].ToString()));
        Office.DAL.Branches Branches = (Office.DAL.Branches)Session["Branch"];
        if (Session["CurrentBrnachID"] != null)
        {
            if (Session["CurrentBrnachID"].ToString() != "")
            {
                BranchID = Int32.Parse(Session["CurrentBrnachID"].ToString());
                Session["SingleBrnachIDForContactListsPage"] = Session["CurrentBrnachID"];
                Branches.BranchID = BranchID;
                Session["Branch"] = Branches;
                Session["CurrentBrnachID"]=null;
            }
        }
    
            bindForm();
            AdjustReadOnlyFormStatus(true);
        
        // end added

        _AccountID = Convert.ToInt32(((HiddenField)frmViewBranchDetails.FindControl("HiddenAccountID")).Value);
        ViewState["Country"] = ((DropDownList)frmViewBranchDetails.FindControl("ddlCountry")).SelectedItem.Text;
        dllCompanyName.SelectedValue = _AccountID.ToString();
        BindAccountFormView();
    }
    protected void dllBranchName_DataBound(object sender, EventArgs e)
    {
       
    }

    private void AdjustNextPreviousButtons()
    {
        imgbtnNext_Click(null, null);
        if (frmViewBranchDetails.PageIndex + 1 <= frmViewBranchDetails.PageCount)
        {
            imgbtnPrevious_Click(null, null);
        }

        if (frmViewBranchDetails.PageIndex > 0)
        {
            imgbtnPrevious.Visible = true;
        }
        if (frmViewBranchDetails.PageIndex + 1 == frmViewBranchDetails.PageCount)
        {
            imgbtnNext.Visible = false;
        }
    }

    protected override void OnLoadComplete(EventArgs e)
    {
        base.OnLoadComplete(e);

        if (!IsPostBack)
        {
            if ((bool)ViewState["BranchDeleted"])
                ViewState["BranchDeleted"] = false;
            else
                lblMsg.Text = "";
        }
    }

    void ucUserTabs_btnManageApplicationEvent(object sender, EventArgs e)
    {
        Response.Redirect("ManageApplication.aspx");
    }

    private void AssignReportParameters()
    {
        string SpecificAccount = ((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text;
       // ((ImageButton)ucTransToolBar.FindControl("btnPrint")).Attributes.Add("onclick", "openReports('','','','" + SpecificAccount + "','" + Session["ContactFilterField"].ToString() + "','','');");
    }
    private void HandleNextPrevButton() 
    {

        if (frmViewBranchDetails.PageIndex == 0)
        {
            imgbtnPrevious.Visible = false;
        }
        else
        {
            imgbtnPrevious.Visible = true;
        }
        //
        if (frmViewBranchDetails.PageIndex == frmViewBranchDetails.PageCount)
        {
            imgbtnNext.Visible = false;
        }
        else
        {
            imgbtnNext.Visible = true;
        }
        
    }

    private void LoadSearchPrameters()
    {
        if (ViewState["SpecificFilter"] == null)
            ViewState["SpecificFilter"] = "";
        Session["Branch"] = new BranchesPageBLL().GetBranchDetailsSearchFilter(ViewState["SpecificFilter"].ToString(), ((Office.BLL.BranchesPageBLL.Filter)(Session["BranchFilterField"])).IncrementalSearch, ViewState["BranchID"].ToString());
        ViewState["BranchID"] = "";
    }
    /// <summary>
    /// new account load search paramter- mglil
    /// </summary>
    /// 
    private void LoadSearchPrameters(string vsBranchID)
    {
        //ViewState["orderbyField"] = "";
        //ViewState["AccountID"] = AccountID;
        //ViewState["SpecificAccount"] = "";
       
        //Session["Branch"] = GetSearchFilter(ViewState["orderbyField"].ToString(), ViewState["SortType"].ToString(), ViewState["SpecificAccount"].ToString(), ViewState["AccountID"].ToString(), ViewState["Country"].ToString());
        if (ViewState["SpecificFilter"] == null)
            ViewState["SpecificFilter"] = "";
        ViewState["BranchID"] = vsBranchID;
        Session["Branch"] = new BranchesPageBLL().GetBranchDetailsSearchFilter(ViewState["SpecificFilter"].ToString(), ((Office.BLL.BranchesPageBLL.Filter)(Session["BranchFilterField"])).IncrementalSearch, ViewState["BranchID"].ToString());
        ViewState["BranchID"] = "";
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
   

    protected void ucTransToolBar_btnBackEvent(object sender, EventArgs e)
    {
        if (ViewState["BranchIDforPaging"] != null && ViewState["BranchIDforPaging"].ToString() != "")
        {
            
            ViewState["BranchIDforPaging"] = null;
            // Added By Fawzi //
            if (Session["FromPage"] == null)
            {
                Response.Redirect("Branches.aspx");
            }
            else 
            {
                Session["FromPage"] = null;
              
            }
           
        }
        else Response.Redirect("Branches.aspx");
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
            bindForm();
            AdjustReadOnlyFormStatus(true);
            //
            AdjustTransButtons(false);
            //
            LoadSearchPrameters();
            //
            BindAccountFormView();
            ////
          
          
        }
        catch (Exception exp)
        {
            lblMsg.Text = exp.Message;
        }
    }

    private void AdjustTransButtons(bool Flag)
    {
        // rules
        lblMsg.Text = "";
        //
        ((ImageButton)ucTransToolBar.FindControl("btnCancel")).Visible = Flag;
        ((ImageButton)ucTransToolBar.FindControl("btnSave")).Visible = Flag;
        //
               
        if (User.IsInRole("AddBranch"))
            ((ImageButton)ucTransToolBar.FindControl("btnAdd")).Visible = !Flag;
        if (User.IsInRole("EditBranch"))
            ((ImageButton)ucTransToolBar.FindControl("btnEdit")).Visible = !Flag;
        if (User.IsInRole("DeleteBranch"))
            ((ImageButton)ucTransToolBar.FindControl("btnDelete")).Visible = !Flag;
    }


    //Button Update 
    void ucTransToolBar_btnEditEvent(object sender, EventArgs e)
    {
        ((ImageButton)ucTransToolBar.FindControl("btnSave")).AlternateText = "Update";
        AdjustReadOnlyFormStatus(false);
                   
        ((DropDownList)(frmViewBranchDetails.FindControl("ddlState"))).Visible = false;
        ((TextBox)(frmViewBranchDetails.FindControl("txtState"))).Visible = true;
        
        ViewState["SaveMode"] = "Update";
        AdjustTransButtons(true);
       

    }
   
    //Button New 
    void ucTransToolBar_btnAddEvent(object sender, EventArgs e)
    {
        // added by Sayed 5/9/2011
        if (divTabs.Visible)
            divTabs.Visible = false;
       //
        ((DropDownList)frmViewBranchDetails.FindControl("ddlCountry")).SelectedIndex = 0;
        ((DropDownList)(frmViewBranchDetails.FindControl("ddlState"))).Visible = false;
        ((TextBox)(frmViewBranchDetails.FindControl("txtState"))).Visible = true;

        ((ImageButton)ucTransToolBar.FindControl("btnSave")).AlternateText = "Save";
        //
        AdjustReadOnlyFormStatus(false);
        //
        AdjustTransButtons(true);
        //
        ViewState["SaveMode"] = "Add";
        ClearFormControls();
       
    }
   
    void ucTransToolBar_btnSaveEvent(object sender, EventArgs e)
    {
        // Added by sayed 08/12/2011
        if (dllCompanyName.SelectedValue == "" || dllCompanyName.SelectedValue == "-----")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Please choose an account to add branch for it.";
            return;
        }
        else
        {
            lblMsg.Visible = false;
            lblMsg.Text = "";
        }
        //
        bool vbResult = false;
        if (ViewState["SaveMode"].ToString() == "Add")
        {
            vbResult = AddNewBranch();
        }
        else if (ViewState["SaveMode"].ToString() == "Update")
        {
            vbResult = UpdateBranch();

        }
        if (vbResult)
        {
            AdjustTransButtons(false);
            // 25/12/2012
            AdjustReadOnlyFormStatus(true);
            Contacts1.BindGridView();
            Key1.BindGridView();
            HistoryNC1.BindGridView();
            Attachment1.BindGridView();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "EnableContactTab();", true);
        }
    }
    //Clear contacts controls for new entery
    private void ResetBranchControls()
    {
        ((DropDownList)frmViewBranchDetails.FindControl("ddlCountry")).SelectedIndex = 0;
        ((DropDownList)(frmViewBranchDetails.FindControl("ddlState"))).Visible = false;
        ((TextBox)(frmViewBranchDetails.FindControl("txtState"))).Visible = true;

        dllCompanyName.Enabled = true;
        ddlBusSector.Enabled = true;
        // EnableStateControls();///////////////sayed
        ((TextBox)frmViewBranchDetails.FindControl("txtboxBranchName")).Text = "";
        ((TextBox)frmViewBranchDetails.FindControl("txtboxPhone")).Text = "";
        ((TextBox)frmViewBranchDetails.FindControl("txtboxZipCode")).Text = "";
        ((TextBox)frmViewBranchDetails.FindControl("txtboxWebsite")).Text = "";
        ((TextBox)frmViewBranchDetails.FindControl("txtboxFax")).Text = "";
        ((TextBox)frmViewBranchDetails.FindControl("txtboxPhone")).Text = "";
        ((TextBox)frmViewBranchDetails.FindControl("txtboxPhone")).Text = "";
        ((TextBox)frmViewBranchDetails.FindControl("txtboxStreet1")).Text = "";
        ((TextBox)frmViewBranchDetails.FindControl("txtboxStreet2")).Text = "";
        ((TextBox)frmViewBranchDetails.FindControl("txtboxCity")).Text = "";
        ((TextBox)frmViewBranchDetails.FindControl("txtboxRefBy")).Text = "";
        ((TextBox)frmViewBranchDetails.FindControl("txtStatus")).Text = "";
        ((CheckBox)frmViewBranchDetails.FindControl("chBoxHeadQ")).Text = "";
      
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
    private bool AddNewBranch()
    {
        Office.BLL.BranchesBLL Branch = new Office.BLL.BranchesBLL();
        try
        {

            string countryID = ((DropDownList)frmViewBranchDetails.FindControl("ddlCountry")).SelectedValue;
            string state = "";
            if (countryID == "2414")
            {
                state = ((DropDownList)frmViewBranchDetails.FindControl("ddlState")).SelectedValue;
            }
            else
            {
                state = ((TextBox)frmViewBranchDetails.FindControl("txtState")).Text;
            }

            string BranchID = ((HiddenField)frmViewBranchDetails.FindControl("HiddenBranchID")).Value;
            _AccountID = int.Parse(dllCompanyName.SelectedValue);
            string strBusSec = ((HiddenField)frmViewAccounts.FindControl("BusSecID")).Value;
            int? BusSec = string.IsNullOrEmpty(strBusSec) ? 0 : Convert.ToInt32(ddlBusSector.SelectedValue);
            int result = 0;
            if (ValidateData1())
            {
                if (BranchID == "")
                {
                    //Add Branch
                    result = Branch.AddBranch(((TextBox)frmViewBranchDetails.FindControl("txtboxBranchName")).Text, null, BusSec, ((TextBox)frmViewBranchDetails.FindControl("txtboxFax")).Text, ((TextBox)frmViewBranchDetails.FindControl("txtboxPhone")).Text,
                        ((TextBox)frmViewBranchDetails.FindControl("txtboxWebsite")).Text, null, ((TextBox)frmViewBranchDetails.FindControl("txtboxStreet1")).Text,
                        ((TextBox)frmViewBranchDetails.FindControl("txtboxCity")).Text, ((TextBox)frmViewBranchDetails.FindControl("txtboxZipCode")).Text, int.Parse(countryID), "", 1, System.DateTime.Now, ((TextBox)frmViewBranchDetails.FindControl("txtboxStreet2")).Text,
                        null, System.DateTime.Now, null, System.DateTime.Now, state, _AccountID, ((CheckBox)frmViewBranchDetails.FindControl("chBoxHeadQ")).Checked);
                }
                
            }
            else
                return false;

            if (result > 0)
            {
                lblResult.Text = "Data has been Saved.";
                Session["SelectedBranchID"] = result;
                ((HiddenField)frmViewBranchDetails.FindControl("HiddenBranchID")).Value = result.ToString();
                ((HiddenField)frmViewBranchDetails.FindControl("HiddenAccountID")).Value = _AccountID.ToString();
                LoadSearchPrameters(result.ToString());
                bindForm();
                if (frmViewBranchDetails.DataKey.Value != null)
                {
                    gvNotesBindData();
                    BindAccountFormView();
                    AddjustDropDownListsSelection();
                }

                // added by Sayed 5/9/2011
                if (!divTabs.Visible)
                    divTabs.Visible = true;
                //

            }

            return true;

        }
        catch
        {
            lblResult.Text = "Error occured!";
            return false;
        }
       // return true; 
    }
    
    private bool UpdateBranch()
    {

        Office.BLL.BranchesBLL Branch = new Office.BLL.BranchesBLL();
        try
        {

            string countryID = ((DropDownList)frmViewBranchDetails.FindControl("ddlCountry")).SelectedValue;
            string state = "";
            if (countryID == "2414")
            {
                state = ((DropDownList)frmViewBranchDetails.FindControl("ddlState")).SelectedValue;
            }
            else
            {
                state = ((TextBox)frmViewBranchDetails.FindControl("txtState")).Text;
            }

            string vsBranchID = ((HiddenField)frmViewBranchDetails.FindControl("HiddenBranchID")).Value;
            string AccountID = dllCompanyName.SelectedValue;// ((HiddenField)frmViewBranchDetails.FindControl("HiddenAccountID")).Value;
            BranchID = int.Parse(vsBranchID);
            _AccountID = int.Parse(AccountID);
            string strBusSec = ((HiddenField)frmViewAccounts.FindControl("BusSecID")).Value; 
            int? BusSec = string.IsNullOrEmpty(strBusSec) ? 0 : Convert.ToInt32(strBusSec);//error
            int result = 0;
            if (ValidateData1())
            {
                if (vsBranchID != "")
               
                {
                    //Update Branch
                    result = Branch.updateBranch(int.Parse(vsBranchID), ((TextBox)frmViewBranchDetails.FindControl("txtboxBranchName")).Text, null, BusSec, ((TextBox)frmViewBranchDetails.FindControl("txtboxFax")).Text, ((TextBox)frmViewBranchDetails.FindControl("txtboxPhone")).Text,
                        ((TextBox)frmViewBranchDetails.FindControl("txtboxWebsite")).Text, null, ((TextBox)frmViewBranchDetails.FindControl("txtboxStreet1")).Text,
                        ((TextBox)frmViewBranchDetails.FindControl("txtboxCity")).Text, ((TextBox)frmViewBranchDetails.FindControl("txtboxZipCode")).Text, int.Parse(countryID), ((TextBox)frmViewBranchDetails.FindControl("txtboxRefBy")).Text, 1, System.DateTime.Now, ((TextBox)frmViewBranchDetails.FindControl("txtboxStreet2")).Text,
                        null, System.DateTime.Now, null, System.DateTime.Now, state, _AccountID, ((CheckBox)frmViewBranchDetails.FindControl("chBoxHeadQ")).Checked);
                }
            }
            else
                return false;

            if (result == 1)
            {
                UpdateAllBranchNote(BranchID, _AccountID);
                lblResult.Text = "Data has been Saved.";
            }

            return true;

        }
        catch (Exception ex)
        {
            lblResult.Text = "Error occured!"+ex.Message;
            return false;
        }
        //return true;
    }
    //Enable Or Disable Controls in Case of editing 
    private void AdjustReadOnlyFormStatus(bool Flag)
    {
        
        ((DropDownList)frmViewBranchDetails.FindControl("ddlCountry")).Enabled = !Flag;
        ((DropDownList)frmViewBranchDetails.FindControl("ddlState")).Enabled = !Flag;
        dllCompanyName.Enabled = !Flag;
        ddlBusSector.Enabled = !Flag;
       // EnableStateControls();///////////////sayed
        ((TextBox)frmViewBranchDetails.FindControl("txtboxBranchName")).Enabled = !Flag;
        ((TextBox)frmViewBranchDetails.FindControl("txtboxPhone")).Enabled = !Flag;
        ((TextBox)frmViewBranchDetails.FindControl("txtboxZipCode")).Enabled = !Flag;
        ((TextBox)frmViewBranchDetails.FindControl("txtboxWebsite")).Enabled = !Flag;
        ((TextBox)frmViewBranchDetails.FindControl("txtboxFax")).Enabled = !Flag;
        ((TextBox)frmViewBranchDetails.FindControl("txtboxPhone")).Enabled = !Flag;
        ((TextBox)frmViewBranchDetails.FindControl("txtboxPhone")).Enabled = !Flag;
        ((TextBox)frmViewBranchDetails.FindControl("txtboxStreet1")).Enabled = !Flag;
        ((TextBox)frmViewBranchDetails.FindControl("txtboxStreet2")).Enabled = !Flag;
        ((TextBox)frmViewBranchDetails.FindControl("txtboxCity")).Enabled = !Flag;
        ((TextBox)frmViewBranchDetails.FindControl("txtboxRefBy")).Enabled = !Flag;
        ((TextBox)frmViewBranchDetails.FindControl("txtStatus")).Enabled = !Flag;
        ((CheckBox)frmViewBranchDetails.FindControl("chBoxHeadQ")).Enabled = !Flag;
       
    }
  
    void ucTransToolBar_btnDeleteEvent(object sender, EventArgs e)
    {
        int BranchID;
        Office.BLL.BranchesBLL Branch = new Office.BLL.BranchesBLL();
        if (int.TryParse(((HiddenField)frmViewBranchDetails.FindControl("HiddenBranchID")).Value, out BranchID))
            lblMsg.Text = Branch.DeleteBranchByID(BranchID);
           
        if (lblMsg.Text == "Branch deleted successfully!")
        {
            Session["SelectedBranchID"] = -1;
            Session["CurrentBrnachID"] = null;
            ViewState["BranchDeleted"] = true;
            Session["SingleBranch"] = null;
            Session["Branch"] = null;
            frmViewAccounts.DataSource = null;
            frmViewAccounts.DataBind();
            LoadData();
           

                         
        }
        
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
    private void ucUserTabs_btnContactListsEvent(object sender, EventArgs e)
    {
        Response.Redirect("ContactLists.aspx");
    }

    private void ucUserTabs_btnBranchesEvent(object sender, EventArgs e)
    {
        Response.Redirect("Branches.aspx");
    }

    private void ucUserTabs_btnCallsEvent(object sender, EventArgs e)
    {
        Response.Redirect("CallsManagement.aspx");
    }
    
    protected void ucAutoCompleteSearch_ddlFindTypeEvent(object sender, EventArgs e)
    {
        DropDownList ddlFindType = (DropDownList)ucAutoCompleteSearch.FindControl("ddlFindType");
        Session["BranchFilterField"] = ddlFindType.SelectedValue;
        //
        ((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text = "";
        AssignReportParameters();
    }
    private void ucAutoCompleteSearch_btnSearchEvent(object sender, EventArgs e)
    {
        if (((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text.Length > 0)
        {
            SetSpecificAccountFilter();
            LoadSearchPrameters();
            bindForm();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "EnableContactTab();", true);
           
            if (frmViewBranchDetails.DataKey.Value != null)
            {
                gvNotesBindData();
                NoteState();// 15/12/2011 review
                BindAccountFormView();
                AddjustDropDownListsSelection();
            }
            divTabs.Visible = frmViewBranchDetails.DataKey.Value != null;
            AdjustTransButtons(false);
            
        }
        else
        {
            Session["SingleBranch"] = null;
            Session["CurrentNote"] = null;
            ViewState["ContactID"] = "";
            ViewState["SpecificFilter"] = "";
            LoadSearchPrameters();
            bindForm();
            BindAccountFormView();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "EnableContactTab();", true);

            frmViewAccounts.DataSource = null;
            frmViewAccounts.DataBind();
            AddjustDropDownListsSelection();
            ////ddlIDStatus.DataBind();
            gvNotesBindData();
            AssignReportParameters();
        }
    }

    private void AddjustDropDownListsSelection()
    {
        ((DropDownList)frmViewBranchDetails.FindControl("ddlCountry")).SelectedValue = ((TextBox)frmViewBranchDetails.FindControl("txtCountryID")).Text;
        EnableStateControls();
        try
        {
            if (string.IsNullOrEmpty(((HiddenField)frmViewBranchDetails.FindControl("HiddenAccountID")).Value))
            {
                //if (!(dllCompanyName.Items.Count > 0))
                //dllCompanyName.SelectedIndex = -1;
                dllCompanyName.SelectedValue = "";
                dllCompanyName.DataBind();
                dllCompanyName.SelectedValue = "-----";
                ddlBusSector.SelectedValue = "All";
            }
            else
            {
                dllCompanyName.SelectedValue = ((HiddenField)frmViewBranchDetails.FindControl("HiddenAccountID")).Value;

               // ((DropDownList)frmViewAccountDetails.FindControl("ddlBusSector")).SelectedValue = ((TextBox)frmViewAccountDetails.FindControl("txtBusSector")).Text;

                BindAccountFormView();
                ddlBusSector.SelectedValue = ((HiddenField)frmViewAccounts.FindControl("BusSecID")).Value;
            }
        }
        catch { }

    }
    private void EnableStateControls()
    {
        if (((DropDownList)frmViewBranchDetails.FindControl("ddlCountry")).SelectedItem.Text.ToString().Trim().ToLower() == "united states")
        {
            ((DropDownList)frmViewBranchDetails.FindControl("ddlState")).Visible = true;
            ((TextBox)frmViewBranchDetails.FindControl("txtState")).Visible = false;
            if (((DropDownList)(frmViewBranchDetails.FindControl("ddlState"))).Items.FindByText(((TextBox)(frmViewBranchDetails.FindControl("txtState"))).Text) != null)
                ((DropDownList)(frmViewBranchDetails.FindControl("ddlState"))).SelectedValue = ((TextBox)(frmViewBranchDetails.FindControl("txtState"))).Text;
        }
        else
        {
            ((DropDownList)frmViewBranchDetails.FindControl("ddlState")).Visible = false;
            ((TextBox)frmViewBranchDetails.FindControl("txtState")).Visible = true;
        }
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        Office.DAL.Branches BR = new Office.DAL.Branches();
        BranchDetails objBranch = new BranchDetails();
        string[] BrNames = new string[0];

        BranchesPageBLL.Filter fltr = (BranchesPageBLL.Filter)objBranch.Session["BranchFilterField"];

        string SelectedTableName = fltr.IncrementalSearch;

        string Country = "-1";
        string State = "-1";



        if (fltr.LocationType == "Country")
            Country = fltr.LocationName;
        else if (fltr.LocationType == "State")
            State = fltr.LocationName;

        if (SelectedTableName == "Company")
            BrNames = BR.GetAllBranchesNames(prefixText, Office.DAL.Branches.SearchBy.BrnachName, Country, State, fltr.BusSector, fltr.Notes, fltr.Tag);

        if (SelectedTableName == "Business Sector")
            BrNames = BR.GetAllBranchesNames(prefixText, Office.DAL.Branches.SearchBy.BusinessSectorName, Country, State, fltr.BusSector, fltr.Notes, fltr.Tag);

        return BrNames;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        PopupControlExtender1.Cancel();
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
           // Session["SingleBranch"] = CntAcc;
            Session["CurrentAccount"] = CntAcc;

            frmViewAccounts.DataSource = odsAccounts;
            frmViewAccounts.DataBind();
            try
            {
                ddlBusSector.SelectedValue = ((HiddenField)frmViewAccounts.FindControl("BusSecID")).Value;
            }
            catch 
            {
                ((DropDownList)frmViewAccounts.FindControl("ddlBusSector")).SelectedValue = ((TextBox)frmViewAccounts.FindControl("txtBusSector")).Text;
            }
            
           
        }
        else
        {
            frmViewAccounts.DataSource = null;
            frmViewAccounts.DataBind();
        }
    }

    protected void dllCompanyName_DataBound(object sender, EventArgs e)
    {
      
        BindAccountFormView();
    }
    protected void dllCompanyName_DataBinding(object sender, EventArgs e)
    {
        dllCompanyName.Items.Clear();
            ListItem FirstItem = new ListItem("-----", "-----");
            dllCompanyName.Items.Insert(0, FirstItem);
        //BindAccountFormView();
    }

    protected void gvNotes_SelectedIndexChanged(object sender, EventArgs e)
    {
        int NoteID = (int)(gvNotes.DataKeys[gvNotes.SelectedIndex].Values["NID"]);
        Session["CurrentNote"] = new AccountListsBLL().GetContactNote(NoteID);
    }

    protected void gvNotesBindData()
    {
        TabContainer1.Enabled = true;
        int BID = 1;
        if (frmViewBranchDetails.SelectedValue != null)
        {
            if (!int.TryParse(frmViewBranchDetails.SelectedValue.ToString(), out BID))
                BID = -1;


            if (Session["CurrentNote"] == null)
            {
                ContactNotes CNote = new ContactNotes();
                CNote.BranchID = BID;
                Session["CurrentNote"] = CNote;
            }
            else
                ((ContactNotes)Session["CurrentNote"]).BranchID = BID;

            gvNotes.DataSource = odsNotes;
            gvNotes.DataBind();

            if (Session["CurrentContact"] == null)
            {
                ContactContactsInfo CCI = new ContactContactsInfo();
                CCI.BranchID = BID;
                Session["CurrentContact"] = CCI;
            }
            else
                ((ContactContactsInfo)Session["CurrentContact"]).BranchID = BID;

            Contacts1.BindGridView();
        }
        gvNotes.SelectedIndex = -1;
        Contacts1.SetSelectedIndex(-1);
        Session["CurrentNote"] = null;
        Session["CurrentContact"] = null;
        
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
        Session["CurrentNote"] = GetNotesSortFilter(ViewState["orderbyField"].ToString(), ViewState["SortType"].ToString());
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //ShowNoteDataControls(true);
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
                    txtCalender.Text = "";
                }
                else
                    lblMsg.Text = "Error while updating note.";
            }
            else if (txtContact.Text.Length == 0)
            {
                int? AID = null;
                if (dllCompanyName.SelectedValue != "-----")
                    AID = Convert.ToInt32(dllCompanyName.SelectedValue);
                int BID = 1;
                if (int.TryParse(frmViewBranchDetails.SelectedValue.ToString(), out BID))
                {
                    if (AddBranchNote(AdjustWordsLengths(hdnNote.Value), BID, AID, EDate))
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
        //ShowNoteDataControls(true);
        Session["CurrentNote"] = null;
        ViewState["SortType"] = "Desc";
        OrderBy("UserEnterDate");
        LoadNoteSearchPrameters();
        gvNotesBindData();
        PopupControlExtender1.Cancel();
        //System.Web.UI.ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "click", "alert('ok')", true);
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
   
    protected void imgbtnSignOut_Click(object sender, ImageClickEventArgs e)
    {
        SignOut();
    }
    
    protected void btnNewAccount_Click(object sender, EventArgs e)
    {
        //AddNewAccount();
    }
   
    protected void ibtnAddNewAcc_Click(object sender, ImageClickEventArgs e)
    {
        AddNewAccount();
    }
    private void AddNewAccount()
    {
        Session["NewAccount"] = true;
        Response.Redirect("AccountLists.aspx");
    }
   
   
    protected void ScriptManager1_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
    {
        e.ToString();
    }
    //protected void ddlBusSector_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    lblSelectedBS.Text = ddlBusSector.SelectedItem.Text;
    //    dllCompanyName.DataBind();
    //}

    protected void imgbtnNext_Click(object sender, ImageClickEventArgs e)
    {
        if (frmViewBranchDetails.PageIndex == 0 && Session["Branch"] != null)
        {
            Office.DAL.Branches Branches = (Office.DAL.Branches)Session["Branch"];
            int? ID = Branches.BranchID;
            if (ID.HasValue)
            {
                BranchesBLL brnch = new BranchesBLL();
                frmViewBranchDetails.PageIndex = brnch.GetBranchOrderNo(Branches);
            }
        }
        ViewState["BranchID"] = "";
        FormViewPageEventArgs FVPEA = new FormViewPageEventArgs(frmViewBranchDetails.PageIndex + 1);
        frmViewBranchDetails_PageIndexChanging(sender == null ? null : this, FVPEA);
        NoteState();
    }
    protected void imgbtnPrevious_Click(object sender, ImageClickEventArgs e)
    {
        if (frmViewBranchDetails.PageIndex == 0 && Session["Branch"] != null)
        {
            Office.DAL.Branches Branches = (Office.DAL.Branches)Session["Branch"];
            int? ID = Branches.BranchID;
            if (ID.HasValue)
            {
                BranchesBLL brnch = new BranchesBLL();
                frmViewBranchDetails.PageIndex = brnch.GetBranchOrderNo(Branches);
            }
        }
        ViewState["BranchID"] = "";
        FormViewPageEventArgs FVPEA = new FormViewPageEventArgs(frmViewBranchDetails.PageIndex - 1);
        frmViewBranchDetails_PageIndexChanging(sender == null ? null : this, FVPEA);
        NoteState();
    }
    /////////////////////////////////////////////////////////////////////////////Session["CurrentBrnachID"]
    public void LoadControlData()
    {
        lblResult.Text = "";

        if (Session["CurrentBrnachID"] != null)
        {
            frmViewBranchDetails.ChangeMode(FormViewMode.ReadOnly);
            bindForm();

        }
        else
        {
            frmViewBranchDetails.ChangeMode(FormViewMode.Insert);
            ClearFormControls();
            ((DropDownList)frmViewBranchDetails.FindControl("ddlCountry")).SelectedIndex = 0;
            ((DropDownList)(frmViewBranchDetails.FindControl("ddlState"))).Visible = false;
            ((TextBox)(frmViewBranchDetails.FindControl("txtState"))).Visible = true;
        }
    }
    private void ClearFormControls()
    {
        ((TextBox)(frmViewBranchDetails.FindControl("txtboxBranchName"))).Text = "";
        ((TextBox)(frmViewBranchDetails.FindControl("txtboxPhone"))).Text = "";
        ((TextBox)(frmViewBranchDetails.FindControl("txtboxFax"))).Text = "";
        ((TextBox)(frmViewBranchDetails.FindControl("txtboxWebsite"))).Text = "";
        ((TextBox)(frmViewBranchDetails.FindControl("txtboxRefBy"))).Text = "";
        ((TextBox)(frmViewBranchDetails.FindControl("txtStatus"))).Text = "";
        ((TextBox)(frmViewBranchDetails.FindControl("txtboxStreet1"))).Text = "";
        ((TextBox)(frmViewBranchDetails.FindControl("txtboxStreet2"))).Text = "";
        ((TextBox)(frmViewBranchDetails.FindControl("txtboxCity"))).Text = "";
        ((TextBox)(frmViewBranchDetails.FindControl("txtboxZipCode"))).Text = "";
        ((Label)(frmViewBranchDetails.FindControl("lblErrSymZipCode"))).Text = "";
        ((TextBox)(frmViewBranchDetails.FindControl("txtState"))).Text = "";
        ((HiddenField)frmViewBranchDetails.FindControl("HiddenBranchID")).Value = "";
        ((HiddenField)frmViewBranchDetails.FindControl("HiddenAccountID")).Value = "";

        ContactContactsInfo CCI = new ContactContactsInfo();
        CCI.AccountID = -1;
        Session["CurrentContact"] = CCI;
        Contacts1.BindGridView();
    }

    public void bindForm()
    {
        frmViewBranchDetails.DataSource = odsBranchDetails0;
        frmViewBranchDetails.DataBind();
        AddjustDropDownListsSelection1();
        lblEmptyResults.Visible = (frmViewBranchDetails.DataKey.Value == null);
        pnlAccount.Visible = (frmViewBranchDetails.DataKey.Value != null);
       
    }
    protected void odsBranchDetails_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        if (Session["CurrentBrnachID"] != null)
        {
            This_BranchID = int.Parse(Session["CurrentBrnachID"].ToString());

        }
        else
        {
            This_BranchID = 3;
        }
        e.InputParameters["BranchID"] = BranchID;
    }



    public void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        // ((TextBox)(frmViewBranchDetails.FindControl("txtCountryID"))).Text = ((DropDownList)(frmViewBranchDetails.FindControl("ddlCountry"))).SelectedValue;
        AdjustCountryStateSelection();
    }

    private void AdjustCountryStateSelection()
    {
        if (((DropDownList)(frmViewBranchDetails.FindControl("ddlCountry"))).SelectedItem.Text.Trim().ToLower() == "united states")
        {
            ((DropDownList)(frmViewBranchDetails.FindControl("ddlState"))).Visible = true;
            ((TextBox)(frmViewBranchDetails.FindControl("txtState"))).Visible = false;
            if (((DropDownList)(frmViewBranchDetails.FindControl("ddlState"))).Items.FindByText(((TextBox)(frmViewBranchDetails.FindControl("txtState"))).Text) != null)
                ((DropDownList)(frmViewBranchDetails.FindControl("ddlState"))).SelectedValue = ((TextBox)(frmViewBranchDetails.FindControl("txtState"))).Text;
        }
        else
        {
            ((DropDownList)(frmViewBranchDetails.FindControl("ddlState"))).Visible = false;
            ((TextBox)(frmViewBranchDetails.FindControl("txtState"))).Visible = true;
        }
    }

    private void AddjustDropDownListsSelection1()
    {
        if (frmViewBranchDetails.CurrentMode != FormViewMode.Insert)
        {
            if (frmViewBranchDetails.DataKey.Value != null)
            {
                ((DropDownList)frmViewBranchDetails.FindControl("ddlCountry")).SelectedValue = ((TextBox)frmViewBranchDetails.FindControl("txtCountryID")).Text;
                AdjustCountryStateSelection();
            }
        }
    }

    private bool ValidateData1()
    {
        bool Valid = true;
        //Validate Branch Name Required
        if (((TextBox)frmViewBranchDetails.FindControl("txtboxBranchName")).Text.Trim() == "")
        {
            ((Label)frmViewBranchDetails.FindControl("lblErrSymAccName")).Text = "Branch name is required";
            ((Label)frmViewBranchDetails.FindControl("lblErrSymAccName")).Visible = true;
            Valid = false;
        }
        else
        {
            ((Label)frmViewBranchDetails.FindControl("lblErrSymAccName")).Text = "";
            ((Label)frmViewBranchDetails.FindControl("lblErrSymAccName")).Visible = false;
        }
        //Validate Phone Required
        if (((TextBox)frmViewBranchDetails.FindControl("txtboxPhone")).Text.Trim() == "")
        {
            ((Label)frmViewBranchDetails.FindControl("lblErrSymPhone")).Text = "Telephone is required";
            ((Label)frmViewBranchDetails.FindControl("lblErrSymPhone")).Visible = true;
            Valid = false;
        }

        else
        {
             string PhoneExp = @"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}";
             if (!(System.Text.RegularExpressions.Regex.Match(((TextBox)frmViewBranchDetails.FindControl("txtboxPhone")).Text, PhoneExp).Success))
             {
                 ((Label)frmViewBranchDetails.FindControl("lblErrSymPhone")).Text = "Phone Format is not valid, hint: valid Format eg.(+xxx-xxx-xxx-xxxx)";
                 ((Label)frmViewBranchDetails.FindControl("lblErrSymPhone")).Visible = true;
                 Valid = false;
             }
             else
             {
                 ((Label)frmViewBranchDetails.FindControl("lblErrSymPhone")).Text = "";
                 ((Label)frmViewBranchDetails.FindControl("lblErrSymPhone")).Visible = false;
             }
        }
        //Validate Zip Code Required
        if (((TextBox)frmViewBranchDetails.FindControl("txtboxZipCode")).Text.Trim() == "")
        {
            ((Label)frmViewBranchDetails.FindControl("lblErrSymZipCode")).Text = "Zip Code is required";
            ((Label)frmViewBranchDetails.FindControl("lblErrSymZipCode")).Visible = true;
            Valid = false;
        }
        else
        {
            ((Label)frmViewBranchDetails.FindControl("lblErrSymZipCode")).Text = "";
            ((Label)frmViewBranchDetails.FindControl("lblErrSymZipCode")).Visible = false;
        }

        if (((TextBox)frmViewBranchDetails.FindControl("txtboxWebsite")).Text.Trim() != "")
        {
            string WebSite = ((TextBox)frmViewBranchDetails.FindControl("txtboxWebsite")).Text;
            if (!((WebSite.Length > 7 && WebSite.Substring(0, 7) == "http://") || (WebSite.Length > 8 && WebSite.Substring(0, 8) == "https://")))
                WebSite = "http://" + WebSite;
            string WebSiteExp = @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
            if (!(System.Text.RegularExpressions.Regex.Match(WebSite, WebSiteExp).Success))
            {
                ((Label)frmViewBranchDetails.FindControl("lblErrSymWebSite")).Text = "WebSite URL is not valid";
                ((Label)frmViewBranchDetails.FindControl("lblErrSymWebSite")).Visible = true;
                Valid = false;
            }
            else
            {
                ((Label)frmViewBranchDetails.FindControl("lblErrSymWebSite")).Text = "";
                ((Label)frmViewBranchDetails.FindControl("lblErrSymWebSite")).Visible = false;
            }
        }

        //if (((TextBox)frmViewBranchDetails.FindControl("txtboxPhone")).Text.Trim() != "")
        //{
        //    string PhoneExp = @"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}";
        //    if (!(System.Text.RegularExpressions.Regex.Match(((TextBox)frmViewBranchDetails.FindControl("txtboxPhone")).Text, PhoneExp).Success))
        //    {
        //        ((Label)frmViewBranchDetails.FindControl("lblErrSymPhone")).Text = "Phone Format is not valid, hint: valid Format eg.(+xxx-xxx-xxx-xxxx)";
        //        ((Label)frmViewBranchDetails.FindControl("lblErrSymPhone")).Visible = true;
        //        Valid = false;
        //    }
        //    else
        //    {
        //        ((Label)frmViewBranchDetails.FindControl("lblErrSymPhone")).Text = "";
        //        ((Label)frmViewBranchDetails.FindControl("lblErrSymPhone")).Visible = false;
        //    }
        //}
        if (((TextBox)frmViewBranchDetails.FindControl("txtboxZipCode")).Text != "")
        {
            string ZipExp = @"^(\d{5}-\d{4}|\d{5}|\d{9})$|^([a-zA-Z]\d[a-zA-Z] \d[a-zA-Z]\d)$";
            if (!(System.Text.RegularExpressions.Regex.Match(((TextBox)frmViewBranchDetails.FindControl("txtboxZipCode")).Text, ZipExp).Success))
            {
                ((Label)frmViewBranchDetails.FindControl("lblErrSymZipCode")).Text = "Zip Code Format is not valid";
                ((Label)frmViewBranchDetails.FindControl("lblErrSymZipCode")).Visible = true;
                Valid = false;
            }
            else
            {
                ((Label)frmViewBranchDetails.FindControl("lblErrSymZipCode")).Text = "";
                ((Label)frmViewBranchDetails.FindControl("lblErrSymZipCode")).Visible = false;
            }
        }
        //if (((TextBox)frmViewBranchDetails.FindControl("txtboxFax")).Text != "")
        //{
        //    string FaxExp = @"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}";
        //    if (!(System.Text.RegularExpressions.Regex.Match(((TextBox)frmViewBranchDetails.FindControl("txtboxFax")).Text, FaxExp).Success))
        //    {
        //        ((Label)frmViewBranchDetails.FindControl("lblErrValidFax")).Text = "Fax Format is not valid, hint: valid Format eg.(+xxx-xxx-xxx-xxxx)";
        //        ((Label)frmViewBranchDetails.FindControl("lblErrValidFax")).Visible = true;
        //        Valid = false;
        //    }
        //    else
        //    {
        //        ((Label)frmViewBranchDetails.FindControl("lblErrValidFax")).Text = "";
        //        ((Label)frmViewBranchDetails.FindControl("lblErrValidFax")).Visible = false;
        //    }
        //}
        return Valid;
    }
    protected void frmViewBranchDetails_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {
        frmViewBranchDetails.PageIndex = e.NewPageIndex;
        DropDownList ddlFindType = (DropDownList)ucAutoCompleteSearch.FindControl("ddlFindType");
        LoadData();

    }
    protected void imgNotesTab_Click(object sender, ImageClickEventArgs e)
    {
        NoteState();
    }

    private void NoteState()
    {
        imgContactsTab.Enabled = true;
        imgContactsTab.ImageUrl = "Images/contacts_normal.png";
        imgNotesTab.Enabled = false;
        imgNotesTab.ImageUrl = "Images/notes_selected.png";
        imgbtnKeySoftware.Enabled = true;
        imgbtnKeySoftware.ImageUrl = "Images/Keys-n.png";
        imgbtnHistory.ImageUrl = "Images/History-n.png";
        imgbtnHistory.Enabled = true;

        imgbtnAttachments.ImageUrl = "Images/Attachments-n.png";
        imgbtnAttachments.Enabled = true;
    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        Session["SelectedBranchID"] = ((HiddenField)frmViewBranchDetails.FindControl("HiddenBranchID")).Value;
        Session["CurrentPage"] = "BranchDetails";
    }
    protected void imgContactsTab_Click(object sender, ImageClickEventArgs e)
    {

        imgContactsTab.Enabled = false;
        imgContactsTab.ImageUrl = "Images/contacts_selected.png";
        imgNotesTab.Enabled = true;
        imgNotesTab.ImageUrl = "Images/notes_normal.png";

        imgbtnKeySoftware.Enabled = true;
        imgbtnKeySoftware.ImageUrl = "Images/Keys-n.png";
        imgbtnHistory.Enabled = true;
        imgbtnHistory.ImageUrl = "Images/History-n.png";
        imgbtnAttachments.Enabled = true;
        imgbtnAttachments.ImageUrl = "Images/Attachments-n.png";
        Contacts1.BindGridView();
    }
    protected void imgbtnKeySoftware_Click(object sender, ImageClickEventArgs e)
    {
        imgContactsTab.Enabled = true;
        imgContactsTab.ImageUrl = "Images/contacts_normal.png";
        imgNotesTab.Enabled = true;
        imgNotesTab.ImageUrl = "Images/notes_normal.png";
        imgbtnKeySoftware.Enabled = false;
        imgbtnKeySoftware.ImageUrl = "Images/Keys-s.png";
        imgbtnHistory.Enabled = true;
        imgbtnHistory.ImageUrl = "Images/History-n.png";
        imgbtnAttachments.ImageUrl = "Images/Attachments-n.png";
        imgbtnAttachments.Enabled = true;
        Key1.BindGridView();
    }
    protected void imgbtnHistory_Click(object sender, ImageClickEventArgs e)
    {
        imgContactsTab.Enabled = true;
        imgContactsTab.ImageUrl = "Images/contacts_normal.png";
        imgNotesTab.Enabled = true;
        imgNotesTab.ImageUrl = "Images/notes_normal.png";

        imgbtnKeySoftware.Enabled = true;
        imgbtnKeySoftware.ImageUrl = "Images/Keys-n.png";
        imgbtnAttachments.ImageUrl = "Images/Attachments-n.png";
        imgbtnAttachments.Enabled = true;
        imgbtnHistory.ImageUrl = "Images/History-s.png";
        imgbtnHistory.Enabled = false;
        HistoryNC1.BindGridView();
    }

    protected void imgbtnAttachments_Click(object sender, ImageClickEventArgs e)
    {
        imgContactsTab.Enabled = true;
        imgContactsTab.ImageUrl = "Images/contacts_normal.png";
        imgNotesTab.Enabled = true;
        imgNotesTab.ImageUrl = "Images/notes_normal.png";
        imgbtnKeySoftware.Enabled = true;
        imgbtnKeySoftware.ImageUrl = "Images/Keys-n.png";
        imgbtnHistory.ImageUrl = "Images/History-n.png";
        imgbtnHistory.Enabled = true;

        imgbtnAttachments.ImageUrl = "Images/Attachments-s.png";
        imgbtnAttachments.Enabled = false;
        Attachment1.BindGridView();
    }
    private void LoadContactSearchPrameters()
    {
        Session["CurrentContact"] = GetContactSortFilter(ViewState["orderbyField"].ToString(), ViewState["NoteSortType"].ToString());
    }
    protected void Contacts1_ContactsSortingEvent(object sender, GridViewSortEventArgs e)
    {
        OrderBy(e.SortExpression);
        LoadContactSearchPrameters();
        //
        lblMsg.Visible = false;
        //
        gvNotesBindData();
    }
}
