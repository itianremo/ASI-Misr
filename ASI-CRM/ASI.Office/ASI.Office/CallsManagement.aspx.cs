using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Office.DAL;
using System.Collections;
using System.Text;

public partial class CallsManagement : Office.BLL.CallsBLL
{
    private static bool RunTextChangeHandler;
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckUserSession();
        if (!IsPostBack)
        {
            //
				//lblVersionInfo.Text = GetVersionInfo();
            //
            if (Session["CallSortExpression"] == null)
            {
                ViewState["orderbyField"] = "CallName";
                ViewState["SortType"] = "ASC";
            }
            else
            {
                ViewState["orderbyField"] = Session["CallSortExpression"].ToString();
                ViewState["SortType"] = Session["CallSortType"].ToString();
            }
            //

            ViewState["StatusID"] = "All";
            //ViewState["SortType"] = "ASC";
            //ViewState["Tag"] = "All";
            ViewState["SpecificCall"] = "";
            ViewState["SpecificCallDate"] = "";
            ViewState["CallID"] = "";
            RunTextChangeHandler = true;
            //Filter fltr;
            //try
            //{
            //    if (Session["CallFilterField"] == null)
            //    {
            //        fltr = new Filter();
            //        fltr.IncrementalSearch = "Company";
            //        fltr.IncrementalSearchValue = "";
            //        fltr.BusSector = "-1";
            //        fltr.Tag = "-1";
            //        fltr.Notes = "-1";
            //        fltr.StatusID = -1;
            //    }
            //    else
            //        fltr = (Filter)Session["CallFilterField"];
            //}
            //catch
            //{
            //    fltr = new Filter();
            //    fltr.IncrementalSearch = "Company";
            //    fltr.IncrementalSearchValue = "";
            //    fltr.BusSector = "-1";
            //    fltr.Tag = "-1";
            //    fltr.Notes = "-1";
            //    fltr.StatusID = -1;

            //}
            //Session["CallFilterField"] = fltr;

            // Commented By Fawzi June-8-2009 
            // Session["FilterCallNotes"] = null;
            //
            LoadSearchPrameters();
            if (Session["SingleCallID"] != null && Session["SingleCallID"].ToString() != "")
            {
                int PageNo = Session["CallsPageIndex"] == null ? 0 : Convert.ToInt32(Session["CallsPageIndex"]);
                //int PageNo = GetCallGridPageNo(int.Parse(Session["SingleCallID"].ToString()), gvCalls.PageSize);
                ChangePageIndex(PageNo, true);
                Session["SingleCallID"] = null;
            }
            else if (Request.QueryString["CallID"] != null && Request.QueryString["CallID"] != "")
            {
                Calls C = new Calls();
                C.CallID = Convert.ToInt32(Request.QueryString["CallID"]);
                Session["Call"] = C;
                BindGridView();
                for (int i = 0; i < gvCalls.Rows.Count; i++)
                {
                    if (gvCalls.DataKeys[i][0].ToString() == Request.QueryString["CallID"])
                    {
                        gvCalls.SelectedIndex = i;
                        break;
                    }
                }
                ucTransToolBar_btnEditEvent(this, null);
            }
            else
                BindGridView();

            txtDate.Attributes.Add("ReadOnly", "ReadOnly");
            txtCallDate.Attributes.Add("ReadOnly", "ReadOnly");
            //int CallsCount = GetCallsCount();
            //CheckedTags = new bool[(CallsCount != -1) ? CallsCount : 0];
            //ViewState["CheckedTags"] = new ArrayList();
            //ViewState["UnCheckedTags"] = new ArrayList();
            //
        }
        string CurrentPage = "Calls";
        ucTransToolBar.CurrentPage = CurrentPage;
        ucTransToolBar.btnSaveEvent += new EventHandler(ucTransToolBar_btnSaveEvent);
        ucTransToolBar.btnAddEvent += new EventHandler(ucTransToolBar_btnAddEvent);
        ucTransToolBar.btnEditEvent += new EventHandler(ucTransToolBar_btnEditEvent);
        ucTransToolBar.btnDeleteEvent += new EventHandler(ucTransToolBar_btnDeleteEvent);
        ucTransToolBar.btnCancelEvent += new EventHandler(ucTransToolBar_btnCancelEvent);
        AssignReportParameters();
        //////
		  //ucUserTabs.CurrentPage = CurrentPage;
		  //ucUserTabs.btnAccountsEvent += new EventHandler(ucUserTabs_btnAccountsEvent);
		  //ucUserTabs.btnAccountListsEvent += new EventHandler(ucUserTabs_btnAccountListsEvent);
		  //ucUserTabs.btnContantsEvent += new EventHandler(ucUserTabs_btnContantsEvent);
		  //ucUserTabs.btnContactListsEvent += new EventHandler(ucUserTabs_btnContactListsEvent);
		  //ucUserTabs.btnBranchesEvent += new EventHandler(ucUserTabs_btnBranchesEvent);
		  //ucUserTabs.btnBranchesDetailsEvent += new EventHandler(ucUserTabs_btnBranchesDetailsEvent);
		  //ucUserTabs.btnCallsEvent += new EventHandler(ucUserTabs_btnCallsEvent);
		  //ucUserTabs.btnManageApplicationEvent += new EventHandler(ucUserTabs_btnManageApplicationEvent);
        //////
        ucAutoCompleteSearch.CurrentPage = CurrentPage;
        ucAutoCompleteSearch.btnSearchEvent += new EventHandler(ucAutoCompleteSearch_btnSearchEvent);
        //ucAutoCompleteSearch.ddlFindTypeEvent += new EventHandler(ucAutoCompleteSearch_ddlFindTypeEvent);
        //////
        acsRelatedTo.CurrentPage = "CallRelatedTo";
        acsRelatedTo.btnSearchEvent += new EventHandler(acsRelatedTo_btnSearchEvent);
        //acsRelatedTo.ddlFindTypeEvent += new EventHandler(acsRelatedTo_ddlFindTypeEvent);
        //btnTagAll.Attributes.Add("onmouseover", "this.src='Images/CallDetails_select_28.jpg'");
        //btnTagAll.Attributes.Add("onmouseout", "this.src='Images/CallDetails_28.jpg'");
        //////
        //btnUnTagAll.Attributes.Add("onmouseover", "this.src='Images/CallDetails_select_31.jpg'");
        //btnUnTagAll.Attributes.Add("onmouseout", "this.src='Images/CallDetails_31.jpg'");
        //
		  //imgbtnSignOut.Attributes.Add("onmouseover", "this.src='Images/CloseBut_pressed.jpg'");
		  //imgbtnSignOut.Attributes.Add("onmouseout", "this.src='Images/CloseBut_normal.jpg'");
        //
    }

    protected override void OnLoadComplete(EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["ScheduleCallCons"] != null)
            {
                SwitchPanel(true, true);
                ((ImageButton)ucTransToolBar.FindControl("btnSave")).AlternateText = "Save";
                AdjustTransButtons(true);
                ListItemCollection CC = (ListItemCollection)Session["ScheduleCallCons"];
                if (CC.Count > 0)
                {
                    if (CC.Count > 1)
                        lblAddEdit.Text = "Add New Calls..";

                    ((ImageButton)acsRelatedTo.FindControl("btnSearch")).Enabled = false;
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < CC.Count; i++)
                    {
                         sb.Append(CC[i].Text);
                         sb.Append(",");
                    }
                    ((TextBox)acsRelatedTo.FindControl("txtBoxSearch")).Text = sb.ToString();
                }
            }
            if (gvCalls.Rows.Count == 0)
            {
                SwitchPanel(true, true);
                ((ImageButton)ucTransToolBar.FindControl("btnSave")).AlternateText = "Save";
                AdjustTransButtons(true);
            }

            base.OnLoadComplete(e);
        }
    }
    private void SwitchPanel(bool IsAddEditPanel, bool IsAdd)
    {
        if (IsAddEditPanel)
        {
            pnlSearch.Visible = false;
            upCallsgv.Visible = false;
            upAddEditCall.Visible = true;
            ddlStatus.DataSource = GetCallStatusList();
            ddlStatus.DataBind();
            if (IsAdd)
            {
                imgDate.Visible = true;
                btnReschedule.Enabled = false;
                ViewState["AddCall"] = "True";
                ResetAddEditPanel();
                lblAddEdit.Text = "Add New Call..";
            }
            else
            {
                imgDate.Visible = false;
                btnReschedule.Enabled = true;
                ViewState["AddCall"] = null;
                FillAddEditPanel();
            }
        }
        else
        {
            pnlSearch.Visible = true;
            upCallsgv.Visible = true;
            upAddEditCall.Visible = false;
            imgDate.Visible = false;
        }
    }

    private void FillAddEditPanel()
    {
        if (gvCalls.DataKeys[gvCalls.SelectedIndex].Values["ContactID"] != null)
            hdnContactID.Value = gvCalls.DataKeys[gvCalls.SelectedIndex].Values["ContactID"].ToString();
        else if (gvCalls.DataKeys[gvCalls.SelectedIndex].Values["AccountID"] != null)
            hdnContactID.Value = gvCalls.DataKeys[gvCalls.SelectedIndex].Values["AccountID"].ToString();
        txtSubject.Text = gvCalls.SelectedRow.Cells[0].Text;
        gvContacts.DataSource = null;
        gvContacts.DataBind();
        ((TextBox)acsRelatedTo.FindControl("txtBoxSearch")).Text = Server.HtmlDecode(gvCalls.SelectedRow.Cells[1].Text);
        txtDate.Text = gvCalls.SelectedRow.Cells[4].Text;
        ddlStatus.SelectedValue = ddlStatus.Items.FindByText(gvCalls.SelectedRow.Cells[3].Text).Value;
        txtNote.Text = (gvCalls.SelectedRow.Cells[5].Text == "&nbsp;") ? "" : gvCalls.SelectedRow.Cells[5].Text;
       
    }

    private void ResetAddEditPanel()
    {
        txtSubject.Text = "";
        gvContacts.DataSource = null;
        gvContacts.DataBind();
        ((TextBox)acsRelatedTo.FindControl("txtBoxSearch")).Text = "";
        txtDate.Text = "";
        ddlStatus.SelectedIndex = -1;
        txtNote.Text = "";
    }

    private void LoadSearchPrameters()
    {
        if (!Page.IsPostBack) // Added By Fawzi June-8-2009 //
        {
            // Added By Fawzi to Fix Bug 1611 #2 
            //if (Session["SpecificCall"] != null)
            //{
            //    ViewState["SpecificCall"] = Session["SpecificCall"].ToString();
            //    ddlBusSector.SelectedValue = ViewState["SpecificCall"].ToString();
            //    Filter fltr;
            //    if (Session["CallFilterField"] == null)
            //        fltr = new Filter();
            //    else
            //        fltr = (Filter)Session["CallFilterField"];
            //    //fltr.IncrementalSearch = "Business Sector";
            //    fltr.BusSector = ddlBusSector.SelectedValue;
            //    fltr.Tag = "-1";
            //    fltr.Notes = "-1";
            //    Session["CallFilterField"] = fltr;

            //    //
            //}
            ////
            //if (Session["FilterCallNotes"] == null)
            //{
            //    Session["FilterCallNotes"] = 0;
            //}
            //else
            //{
            //    ddlNotes.SelectedValue = Session["FilterCallNotes"].ToString();
            //}
        }

        Session["Call"] = GetSearchFilter(ViewState["SortType"].ToString(), ViewState["SpecificCall"].ToString(), ViewState["SpecificCallDate"].ToString(), ViewState["orderbyField"].ToString());
        // Commented by Yasser  June-15-2009
        //// Added By Fawzi June-8-2009 //
        ////ResetIncrementalSearch();
    }

    private void ChangePageIndex(int NewIndex, bool IsTurnBack)
    {
        RestSelectedRow();
        gvCalls.PageIndex = NewIndex;
        BindGridView();
    }

    private void BindGridView()
    {
        gvCalls.SelectedIndex = -1;
        gvCalls.DataSource = odsCalls;
        gvCalls.DataBind();
        FormatGridValues(gvCalls, "NULL", "");
    }

    private void RestSelectedRow()
    {
        ViewState["CallID"] = "";
        gvCalls.SelectedIndex = -1;
        gvCalls.PageIndex = 0;
        lblTransMsg.Visible = false;
    }

    private void AssignReportParameters()
    {
        string SpecificCall = ((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text;
        ((ImageButton)ucTransToolBar.FindControl("btnPrint")).Attributes.Add("onclick", "openReports('" + ViewState["orderbyField"].ToString() + "','" + ViewState["SortType"].ToString() + "','" + "All"/*ViewState["Tag"].ToString()*/ + "','" + SpecificCall + "','" + ""/*((Filter)Session["CallFilterField"]).IncrementalSearch*/ + "','" + ""/*ViewState["LocationFilter"].ToString()*/ + "','" + ""/*ViewState["SpecificLocation"].ToString()*/ + "');");
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

    private void ucAutoCompleteSearch_ddlFindTypeEvent(object sender, EventArgs e)
    {
        DropDownList ddlFindType = (DropDownList)ucAutoCompleteSearch.FindControl("ddlFindType");
        //Filter fltr = (Filter)Session["CallFilterField"];
        //fltr.IncrementalSearch = ddlFindType.SelectedValue;
        //Session["CallFilterField"] = fltr;
        //
        ((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text = "";
        AssignReportParameters();
    }
    private void ucAutoCompleteSearch_btnSearchEvent(object sender, EventArgs e)
    {
        if (RunTextChangeHandler)
        {
            lblAddEdit.Text = "";
            SetSpecificCallFilter();
            LoadSearchPrameters();
            RestSelectedRow();
            BindGridView();
            CancelOp();
        }
    }

    private void acsRelatedTo_btnSearchEvent(object sender, EventArgs e)
    {
        lblAddEdit.Text = "";
        SetSpecificContactFilter();
        RestContactSelectedRow();
        BindContactsGridView();
    }

    private void SetSpecificContactFilter()
    {
        TextBox objtxtSearch = (TextBox)acsRelatedTo.FindControl("txtBoxSearch");
        if (string.IsNullOrEmpty(objtxtSearch.Text) || objtxtSearch.Text.Trim().Length == 0)
        {
            gvContacts.DataSource = null;
            gvContacts.DataBind();
        }
        else
        {
            Office.BLL.ContactsBLL.Filter Filter = new Office.BLL.ContactsBLL.Filter();
            Filter.IncrementalSearch = "Contact First Name";
            Filter.IncrementalSearchValue = objtxtSearch.Text.Replace("'", "''");
            Session["CallContact"] = new Office.BLL.ContactsBLL().GetSearchFilter("FirstName", "ASC", "All", "", Filter, 0);
        }
    }

    private void RestContactSelectedRow()
    {
        ViewState["ContactID"] = "";
        gvContacts.SelectedIndex = -1;
        gvContacts.PageIndex = 0;
        lblAddEdit.Text = "";
    }

    private void BindContactsGridView()
    {
        gvContacts.DataSource = odsContacts;
        gvContacts.DataBind();
        FormatGridValues(gvContacts, "NULL", "");
    }

    private void SetSpecificCallFilter()
    {
        //DropDownList ddlFindType = (DropDownList)ucAutoCompleteSearch.FindControl("ddlFindType");
        //Filter fltr = (Filter)Session["CallFilterField"];
        //fltr.IncrementalSearch = ddlFindType.SelectedValue;
        //
        TextBox objtxtSearch = (TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch");
        ViewState["SortType"] = "ASC";
        ViewState["SpecificCall"] = objtxtSearch.Text.Replace("'", "''");
        ViewState["SpecificCallDate"] = (txtCallDate.Text.Length > 0) ? txtCallDate.Text : "";
        //Session["CallFilterField"] = GetSearchFilter("ASC", objtxtSearch.Text.Replace("'", "''"));
        // Added by fawzi to fix bug 1774 #1
        //ViewState["SpecificCall"] = fltr.IncrementalSearchValue = objtxtSearch.Text.Replace("'", "''");
        //Session["CallFilterField"] = fltr;
        //
    }

    void ucTransToolBar_btnCancelEvent(object sender, EventArgs e)
    {
        RunTextChangeHandler = true;
        try
        {
            CancelOp();
            LoadSearchPrameters();
            //
            gvCalls.SelectedIndex = -1;
            BindGridView();
        }
        catch (Exception exp)
        {
            lblAddEdit.Text = exp.Message;
        }
    }

    private void CancelOp()
    {
        lblAddEdit.Text = "";
        ((ImageButton)ucTransToolBar.FindControl("btnDelete")).Visible = false;
        SwitchPanel(false, false);
        //
        AdjustTransButtons(false);
        //
        ((ImageButton)ucTransToolBar.FindControl("btnDelete")).Visible = false;
        ((ImageButton)ucTransToolBar.FindControl("btnEdit")).Visible = false;
    }

    private void AdjustTransButtons(bool Flag)
    {
        // rules
        if (Flag)
            lblAddEdit.Text = "";
        //
        ((ImageButton)ucTransToolBar.FindControl("btnCancel")).Visible = Flag;
        ((ImageButton)ucTransToolBar.FindControl("btnSave")).Visible = Flag;
        //
       
        if (User.IsInRole("AddCall"))
            ((ImageButton)ucTransToolBar.FindControl("btnAdd")).Visible = !Flag;
        if (User.IsInRole("EditCall"))
            ((ImageButton)ucTransToolBar.FindControl("btnEdit")).Visible = !Flag;
        if (User.IsInRole("DeleteCall"))
            ((ImageButton)ucTransToolBar.FindControl("btnDelete")).Visible = !Flag;
    }

    void ucTransToolBar_btnEditEvent(object sender, EventArgs e)
    {
        RunTextChangeHandler = false;
        lblAddEdit.Text = "";
        if (gvCalls.SelectedIndex > -1)
        {
            ((ImageButton)ucTransToolBar.FindControl("btnSave")).AlternateText = "Update";

            SwitchPanel(true, false);

            AdjustTransButtons(true);
        }
        else
            lblAddEdit.Text = "No call selected.";
    }

    void ucTransToolBar_btnAddEvent(object sender, EventArgs e)
    {
        RunTextChangeHandler = false;
        lblAddEdit.Text = "";
        SwitchPanel(true, true);
        ((ImageButton)ucTransToolBar.FindControl("btnSave")).AlternateText = "Save";
        AdjustTransButtons(true);
    }
    //Button Save 
    void ucTransToolBar_btnSaveEvent(object sender, EventArgs e)
    {
        RunTextChangeHandler = true;
        bool Result;
        if (ViewState["AddCall"] != null)
            Result = AddNewCall();
        else
            Result = UpdateCall();

        if (Result)
        {
            if (Session["ScheduleCallCons"] != null)
            {
                Session["ScheduleCallCons"] = null;
                ((ImageButton)acsRelatedTo.FindControl("btnSearch")).Enabled = true;
            }
            SwitchPanel(false, false);
            AdjustTransButtons(false);
            LoadSearchPrameters();
            BindGridView();
            // added By Sayed Moawad 26/1/2012
            ((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text = "";
            // end
        }

        ((ImageButton)ucTransToolBar.FindControl("btnEdit")).Visible = false;
        ((ImageButton)ucTransToolBar.FindControl("btnDelete")).Visible = false;
    }

    private bool AddNewCall()
    {
        try
        {
            if (Session["ScheduleCallCons"] != null)
            {
                ListItemCollection CC = (ListItemCollection)Session["ScheduleCallCons"];

                int result = 0;
                if (ValidateCallsData())
                {
                    int StatusID;
                    if (ddlStatus.SelectedValue != null)
                        StatusID = Convert.ToInt32(ddlStatus.SelectedValue);
                    else
                        StatusID = Convert.ToInt32(ddlStatus.Items[0].Value);

                    int RelatedToID;
                    DateTime CallDate = Convert.ToDateTime(txtDate.Text);

                    foreach (ListItem item in CC)
                    {
                        RelatedToID = Convert.ToInt32(item.Value);
                        result = AddCall(txtSubject.Text, CallDate, StatusID, RelatedToID, txtNote.Text) ? 1 : 0;
                    }
                }
                else
                    return false;

                if (result == 1)
                {
                    lblAddEdit.Text = "Call has been saved.";
                    ((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text = "";
                }
            }
            else
            {
                int result = 0;
                if (ValidateData())
                {
                    int StatusID;
                    if (ddlStatus.SelectedValue != null)
                        StatusID = Convert.ToInt32(ddlStatus.SelectedValue);
                    else
                        StatusID = Convert.ToInt32(ddlStatus.Items[0].Value);

                    int RelatedToID = Convert.ToInt32(gvContacts.DataKeys[gvContacts.SelectedIndex].Values["ContactID"]);

                    result = AddCall(txtSubject.Text, Convert.ToDateTime(txtDate.Text), StatusID, RelatedToID, txtNote.Text) ? 1 : 0;
                }
                else
                    return false;

                if (result == 1)
                {
                    lblAddEdit.Text = "Call has been saved.";
                    ((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text = "";
                }
            }
            return true;

        }
        catch
        {
            lblAddEdit.Text = "Error occured!";
            return true;
        }
    }

    private bool UpdateCall()
    {
        try
        {
            int result = 0;
            bool IsRescheduled = false;
            if (ValidateData())
            {
                int StatusID;
                if (ddlStatus.SelectedValue != null)
                    StatusID = Convert.ToInt32(ddlStatus.SelectedValue);
                else
                    StatusID = Convert.ToInt32(ddlStatus.Items[0].Value);
                int CallID = Convert.ToInt32(gvCalls.DataKeys[gvCalls.SelectedIndex].Values["CallID"]);

                DateTime NewDate = Convert.ToDateTime(txtDate.Text);

                if (NewDate.ToShortDateString() == gvCalls.SelectedRow.Cells[4].Text)
                    result = UpdateCall(CallID, txtSubject.Text, NewDate, StatusID,Convert.ToInt32(hdnContactID.Value), txtNote.Text) ? 1 : 0;
                else
                {
                    IsRescheduled = true;
                    result = AddCall(txtSubject.Text, NewDate, StatusID, Convert.ToInt32(hdnContactID.Value), txtNote.Text) ? 1 : 0;
                }
            }
            else
                return false;

            if (result == 1)
            {
                if (IsRescheduled)
                    lblAddEdit.Text = "Call has been rescheduled.";
                else
                    lblAddEdit.Text = "Call has been Saved.";
            }

            return true;

        }
        catch (Exception ex)
        {
            lblAddEdit.Text = "Error occured!" + ex.Message;
            return true;
        }
    }

    private bool ValidateData()
    {
        bool Valid = true;
        lblAddEdit.Text = "";

        if (txtSubject.Text.Trim() == "")
        {
            lblAddEdit.Text = "Subject is required. ";
            Valid = false;
        }

        if (ViewState["AddCall"] != null)
        {
            if (gvContacts.Rows.Count > 0 && gvContacts.SelectedIndex > -1)
            {
            }
            else if (((TextBox)acsRelatedTo.FindControl("txtBoxSearch")).Text.Trim() == "")// ="user must search about existing contact"
            {
                lblAddEdit.Text += "Related entity is required. ";
                Valid = false;
            }

            else if (gvContacts.Rows.Count == 0 || gvContacts.SelectedIndex == -1)
            {
                lblAddEdit.Text += "Select Related to from Contacts list. ";
                Valid = false;
            }
            
        }

        if (txtDate.Text.Trim() == "")
        {
            lblAddEdit.Text += "Date is required. ";
            Valid = false;
        }

        if (ddlStatus.Items.Count > 0 && ddlStatus.SelectedIndex > -1)
        {
        }
        else
        {
            lblAddEdit.Text += "Status is required.";
            Valid = false;
        }

        return Valid;
    }

    private bool ValidateCallsData()
    {
        bool Valid = true;
        lblAddEdit.Text = "";

        if (txtSubject.Text.Trim() == "")
        {
            lblAddEdit.Text = "Subject is required. ";
            Valid = false;
        }

        if (txtDate.Text.Trim() == "")
        {
            lblAddEdit.Text += "Date is required. ";
            Valid = false;
        }

        if (ddlStatus.Items.Count > 0 && ddlStatus.SelectedIndex > -1)
        {
        }
        else
        {
            lblAddEdit.Text += "Status is required.";
            Valid = false;
        }

        return Valid;
    }

    void ucTransToolBar_btnDeleteEvent(object sender, EventArgs e)
    {
        if (gvCalls.SelectedIndex > -1)
        {
            int CallID = Convert.ToInt32(gvCalls.DataKeys[gvCalls.SelectedIndex].Values["CallID"]);

            lblAddEdit.Text = DeleteCallByID(CallID);

            if (lblAddEdit.Text == "Call deleted successfully!")
            {
                gvCalls.SelectedIndex = -1;
                BindGridView();
            }
        }
        else
            lblAddEdit.Text = "No call selected.";
        // added by Sayed 26/3/2012
        CancelOp();
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        ContactContactsInfo CCI = new ContactContactsInfo();
        string[] AccNames = new string[0];

        AccNames = CCI.GetSearchList(prefixText, ContactContactsInfo.SearchBy.FirstName);

        return AccNames;
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList2(string prefixText, int count, string contextKey)
    {
        ContactContactsInfo CCI = new ContactContactsInfo();
        string[] AccNames = new string[0];

        AccNames = CCI.GetSearchList(prefixText, ContactContactsInfo.SearchBy.FirstName);

        return AccNames;
    }

    protected void gvCalls_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        ChangePageIndex(e.NewPageIndex, false);
        Session["CallsPageIndex"] = e.NewPageIndex;
    }
    protected void gvCalls_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='none';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            //e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvCalls, "Select$" + e.Row.RowIndex);
            e.Row.Attributes["ondblclick"] = ClientScript.GetPostBackClientHyperlink(this.gvCalls, "Select$" + e.Row.RowIndex);
            foreach (TableCell tc in e.Row.Cells)
            {
                tc.CssClass = "GridCellStyle";
            }
        }
    }
    protected void gvCalls_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void gvCalls_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (gvCalls.SelectedIndex > -1)
        {
            ((ImageButton)ucTransToolBar.FindControl("btnEdit")).Visible = true;
            ((ImageButton)ucTransToolBar.FindControl("btnDelete")).Visible = true;
        }
        else
            ((ImageButton)ucTransToolBar.FindControl("btnDelete")).Visible = false;
        //ViewState["CallID"] = gvCalls.DataKeys[gvCalls.SelectedIndex].Values["CallID"].ToString();
        //lblTransMsg.Visible = false;

        //Session["SingleCallID"] = ViewState["CallID"];

        //if (Session["CallFilterField"] == null)
        //    Session["CurrentCallSelectedRowIndex"] = gvCalls.PageIndex * gvCalls.PageSize + gvCalls.SelectedIndex;
        //else
        //{
        //    //if (((Filter)Session["CallFilterField"]).IncrementalSearchValue == "")
        //    //    Session["CurrentCallSelectedRowIndex"] = gvCalls.PageIndex * gvCalls.PageSize + gvCalls.SelectedIndex;
        //    //else
        //    //    Session["CurrentCallSelectedRowIndex"] = -2;
        //}
        //
        //Response.Redirect("CallDetails.aspx");
        // end - mglil
    }
    protected void gvCalls_Sorting(object sender, GridViewSortEventArgs e)
    {
        Session["CallSortExpression"] = e.SortExpression;
        //
        OrderBy(e.SortExpression);
        LoadSearchPrameters();
        //
        ViewState["CallID"] = "";
        gvCalls.SelectedIndex = -1;
        lblTransMsg.Visible = false;
        //
        BindGridView();
    }
    private void OrderBy(string field)
    {
        if (ViewState["SortType"].ToString().Trim() == "ASC".Trim())
        {
            ViewState["SortType"] = "Desc";
            Session["CallSortType"] = "Desc";
        }
        else
        {
            ViewState["SortType"] = "ASC";
            Session["CallSortType"] = "ASC";
        }

        ViewState["orderbyField"] = field;
    }
    protected void imgbtnSignOut_Click(object sender, ImageClickEventArgs e)
    {
        SignOut();
    }
    protected void txtCallDate_TextChanged(object sender, EventArgs e)
    {
        if (RunTextChangeHandler)
        {
            //CancelOp();
            lblAddEdit.Text = "";
            ViewState["SpecificCall"] = "";
            ViewState["SpecificCallDate"] = (txtCallDate.Text.Length > 0) ? txtCallDate.Text : "";
            LoadSearchPrameters();
            RestSelectedRow();
            BindGridView();
            // Added 24-10-2011
            SwitchPanel(false, false);
            AdjustTransButtons(false);
            gvCalls.SelectedIndex = -1;
            ((ImageButton)ucTransToolBar.FindControl("btnDelete")).Visible = false;
            // added by Sayed 16/3/2012
            CancelOp();
        }
    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        if (RunTextChangeHandler)
        {
            lblAddEdit.Text = "";
            RunTextChangeHandler = false;
            ViewState["SpecificCall"] = txtCallDate.Text = "";
            ViewState["SpecificCallDate"] = ((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text = "";
            RunTextChangeHandler = true;
            LoadSearchPrameters();
            RestSelectedRow();
            BindGridView();
            SwitchPanel(false, false);
            AdjustTransButtons(false);
            gvCalls.SelectedIndex = -1;
            ((ImageButton)ucTransToolBar.FindControl("btnDelete")).Visible = false;
            CancelOp();
        }
    }
    protected void gvContacts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        RestContactSelectedRow();
        gvContacts.PageIndex = e.NewPageIndex;
        BindContactsGridView();
    }
    protected void gvContacts_SelectedIndexChanged(object sender, EventArgs e)
    {
        ((TextBox)acsRelatedTo.FindControl("txtBoxSearch")).Text = gvContacts.SelectedRow.Cells[1].Text;
        ((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text = gvContacts.SelectedRow.Cells[1].Text;
        hdnContactID.Value = Convert.ToInt32(gvContacts.DataKeys[gvContacts.SelectedIndex].Values["ContactID"]).ToString();
       
    }
    //protected void lbtnDetails_Click(object sender, EventArgs e)
    //{
       
    //    GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent;
    //    ((TextBox)acsRelatedTo.FindControl("txtBoxSearch")).Text = row.Cells[1].Text;
    //    //((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text = row.Cells[1].Text;
    //}
}