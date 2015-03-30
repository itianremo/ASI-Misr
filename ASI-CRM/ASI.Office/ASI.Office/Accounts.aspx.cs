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
using System.Collections.Generic;

public partial class Accounts : Office.BLL.AccountsBLL
{
    
    //private static bool[] CheckedTags;

    protected void Page_Load(object sender, EventArgs e)
    {
        CheckUserSession();
        if (!IsPostBack)
        {
            //
				//lblVersionInfo.Text = GetVersionInfo();
            //
            ddlCountry.DataSource = GetCountryList();
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, "All");
            //
            ddlBusSector.DataSource = GetBusSectorList();
            ddlBusSector.DataBind();
            ddlBusSector.Items.Insert(0, "All");
            //
            ddlStatus.DataSource = GetFilterdStatusList();
            ddlStatus.DataTextField = "SubCode";
            ddlStatus.DataValueField = "SubID";
            ddlStatus.DataBind();
            ddlStatus.Items.Insert(0, "All");
            //
            if (Session["SortExpression"] == null)
            {
                ViewState["orderbyField"] = "AccountName";
                ViewState["SortType"] = "ASC";
            }
            else 
            {
                ViewState["orderbyField"] = Session["SortExpression"].ToString();
                ViewState["SortType"] = Session["SortType"].ToString();
            }
            //
            
            ViewState["StatusID"] = "All";
            //ViewState["SortType"] = "ASC";
            ViewState["Tag"] = "All";
            ViewState["SpecificAccount"] = "";
            ViewState["LocationFilter"] = "";
            ViewState["SpecificLocation"] = "";
            ViewState["AccountID"] = "";
            Filter fltr;
            try
            {
                if (Session["FilterField"] == null)
                {
                    fltr = new Filter();
                    fltr.IncrementalSearch = "Company";
                    fltr.IncrementalSearchValue = "";
                    fltr.BusSector = "-1";
                    fltr.Tag = "-1";
                    fltr.Notes = "-1";
                    fltr.StatusID = -1;
                }
                else
                    fltr = (Filter)Session["FilterField"];
            }
            catch
            {
                fltr = new Filter();
                fltr.IncrementalSearch = "Company";
                fltr.IncrementalSearchValue = "";
                fltr.BusSector = "-1";
                fltr.Tag = "-1";
                fltr.Notes = "-1";
                fltr.StatusID = -1;

            }
            Session["FilterField"] = fltr;
            
            // Commented By Fawzi June-8-2009 
            // Session["FilterAccountNotes"] = null;
            //
            LoadSearchPrameters();
            if (Session["SingleAccountID"] != null && Session["SingleAccountID"].ToString() != "")
            {
                int PageNo = Session["AccountsPageIndex"] == null ? 0 : Convert.ToInt32(Session["AccountsPageIndex"]);
                //int PageNo = GetAccountGridPageNo(int.Parse(Session["SingleAccountID"].ToString()), gvAccounts.PageSize);
                ChangePageIndex(PageNo, true);
                Session["SingleAccountID"] = null;
            }
            else
                BindGridView();

            //int AccountsCount = GetAccountsCount();
            //CheckedTags = new bool[(AccountsCount != -1) ? AccountsCount : 0];
            ViewState["CheckedTags"] = new ArrayList();
            ViewState["UnCheckedTags"] = new ArrayList();
            //
        }
        string CurrentPage = "Accounts";
        ucTransToolBar.CurrentPage = CurrentPage;
        ucTransToolBar.btnAddEvent += new EventHandler(ucTransToolBar_btnAddEventEvent);
        ucTransToolBar.btnSendEvent += new EventHandler(ucTransToolBar_btnSendEvent);
        AssignReportParameters();
        //////
		  //ucUserTabs.CurrentPage = CurrentPage;
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
        ucAutoCompleteSearch.ddlFindTypeEvent += new EventHandler(ucAutoCompleteSearch_ddlFindTypeEvent);
        //////
        //btnTagAll.Attributes.Add("onmouseover", "this.src='Images/accountDetails_select_28.jpg'");
        //btnTagAll.Attributes.Add("onmouseout", "this.src='Images/accountDetails_28.jpg'");
        //////
        //btnUnTagAll.Attributes.Add("onmouseover", "this.src='Images/accountDetails_select_31.jpg'");
        //btnUnTagAll.Attributes.Add("onmouseout", "this.src='Images/accountDetails_31.jpg'");
        //
		  //imgbtnSignOut.Attributes.Add("onmouseover", "this.src='Images/CloseBut_pressed.jpg'");
		  //imgbtnSignOut.Attributes.Add("onmouseout", "this.src='Images/CloseBut_normal.jpg'");
        //
        btnTag.Attributes.Add("onmouseover", "this.src='Images/Tag-o.jpg'");
        btnTag.Attributes.Add("onmouseout", "this.src='Images/Tag-n.jpg'");
        btnTag.Attributes.Add("onmousedown", "this.src='Images/Tag-s.jpg'");

        btnReset.Attributes.Add("onmouseover", "this.src='Images/Reset-o.jpg'");
        btnReset.Attributes.Add("onmouseout", "this.src='Images/Reset-n.jpg'");
        btnReset.Attributes.Add("onmousedown", "this.src='Images/Reset-s.jpg'");

        btnAdvancedSearch.Attributes.Add("onmouseover", "this.src='Images/AdvancedSearch-o.jpg'");
        btnAdvancedSearch.Attributes.Add("onmouseout", "this.src='Images/AdvancedSearch-n.jpg'");
        btnAdvancedSearch.Attributes.Add("onmousedown", "this.src='Images/AdvancedSearch-s.jpg'");
    }

    void ucUserTabs_btnManageApplicationEvent(object sender, EventArgs e)
    {
        Response.Redirect("ManageApplication.aspx");
    }
    
    private void AssignReportParameters()
    {
        string SpecificAccount = ((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text;
        ((ImageButton)ucTransToolBar.FindControl("btnPrint")).Attributes.Add("onclick", "openReports('" + ViewState["orderbyField"].ToString() + "','" + ViewState["SortType"].ToString() + "','" + ViewState["Tag"].ToString() + "','" + SpecificAccount + "','" + ((Filter)Session["FilterField"]).IncrementalSearch + "','" + ViewState["LocationFilter"].ToString() + "','" + ViewState["SpecificLocation"].ToString() + "');");
    }
    
    private void LoadSearchPrameters()
    {
        if (!Page.IsPostBack) // Added By Fawzi June-8-2009 //
        {
            // Added By Fawzi June-8-2009 //
            if (Session["Country"] != null)
            {

                if (Session["Country"].ToString() == "All")
                {
                    ddlCountry.SelectedValue = ddlCountry.Items.FindByText("All").Value;
                    ViewState["LocationFilter"] = "Country";
                    ViewState["SpecificLocation"] = "";
                    Filter fltr = (Filter)Session["FilterField"];
                    fltr.LocationType = "Country";
                    fltr.LocationName = "-1";
                    Session["FilterField"] = fltr;
                }
                else
                {
                    ddlCountry.SelectedValue = Session["Country"].ToString();
                    ViewState["LocationFilter"] = "Country";
                    ViewState["SpecificLocation"] = ddlCountry.SelectedValue;
                    Filter fltr = (Filter)Session["FilterField"];
                    fltr.LocationType = "Country";
                    fltr.LocationName = ddlCountry.SelectedValue;
                    Session["FilterField"] = fltr;
                }
                
                if (Session["State"] != null)
                {
                    ddlState.Enabled = true;
                    ddlState.DataSource = GetStateList();
                    ddlState.DataBind();
                    ddlState.Items.Insert(0, "All");
                    //
                    ddlState.SelectedValue = Session["State"].ToString();
                    ViewState["LocationFilter"] = "State";
                    ViewState["SpecificLocation"] = ddlState.SelectedValue;
                    Filter fltr = (Filter)Session["FilterField"];
                    fltr.LocationType = "State";
                    fltr.LocationName = ddlState.SelectedValue;
                    Session["FilterField"] = fltr;
                }

            }
            // Added By Fawzi June-13-2010 // For Mod. 2626 #3
            else
            {
                ddlCountry.SelectedValue = ddlCountry.Items.FindByText("Egypt").Value;
                Session["Country"] = "Egypt";
                ViewState["LocationFilter"] = "Country";
                ViewState["SpecificLocation"] = ddlCountry.SelectedValue;
                Filter fltr = (Filter)Session["FilterField"];
                fltr.LocationType = "Country";
                fltr.LocationName = ddlCountry.SelectedValue;
                Session["FilterField"] = fltr;
            }
            
            // Added By Fawzi June-7-2009 //
            if (Session["Tag"] != null)
            {
                ViewState["Tag"] = Session["Tag"];
                //ddlTaged.SelectedValue = ViewState["Tag"].ToString();
            }
            //

            // Added By Fawzi to Fix Bug 1611 #2 
            if (Session["SpecificAccount"] != null)
            {
                ViewState["SpecificAccount"] = Session["SpecificAccount"].ToString();
                ddlBusSector.SelectedValue = ViewState["SpecificAccount"].ToString();
                Filter fltr;
                if (Session["FilterField"] == null)
                    fltr = new Filter();
                else
                    fltr = (Filter)Session["FilterField"];
                //fltr.IncrementalSearch = "Business Sector";//sayed
                fltr.BusSector = ddlBusSector.SelectedValue;
                // adde by Sayed 26/12/2011 to fix empty page when click on back button
                if (fltr.BusSector == "All")
                    fltr.BusSector = "-1";
                if (fltr.StatusID != -1)
                    ddlStatus.SelectedValue = fltr.StatusID.ToString();
                //
                fltr.Tag = "-1";
                fltr.Notes = "-1";
                Session["FilterField"] = fltr;

                //
            }
            //
            if (Session["FilterAccountNotes"] == null)
            {
                Session["FilterAccountNotes"] = 0;
            }
            else 
            {
                ddlNotes.SelectedValue = Session["FilterAccountNotes"].ToString();
            }
            // added by sayed 27/12/2011
            if (Session["StatusID"] == null)
            {
                Session["StatusID"] = 0;
            }
            else
            {
                ddlStatus.SelectedValue = Session["StatusID"].ToString();
            }
            //
        }
       
        Session["Account"] = GetSearchFilter(ViewState["orderbyField"].ToString(), ViewState["SortType"].ToString(), ViewState["Tag"].ToString(), ViewState["SpecificAccount"].ToString(), (Filter)Session["FilterField"], ViewState["LocationFilter"].ToString(), ViewState["SpecificLocation"].ToString(), int.Parse(Session["FilterAccountNotes"].ToString()));
        // Commented by Yasser  June-15-2009
        //// Added By Fawzi June-8-2009 //
        ////ResetIncrementalSearch();
    }
    
    // Added By Fawzi June-8-2009 //
    private void ResetIncrementalSearch() 
    {
        Filter fltr;
        if (Session["FilterField"] == null)
            fltr = new Filter();
        else
            fltr = (Filter)Session["FilterField"];
        fltr.IncrementalSearch = "Company";
        Session["FilterField"] = fltr;
    
    }

    private void BindGridView()
    {
        gvAccounts.DataSource = odsAccounts;
        gvAccounts.DataBind();
        FormatGridValues(gvAccounts, "NULL", "");
        cbxEmailAll.Visible = gvAccounts.Rows.Count > 0;
    }

    private void ucUserTabs_btnAccountListsEvent(object sender, EventArgs e)
    {
        Session["SingleAccountID"] = ViewState["AccountID"].ToString();
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

    private void ucAutoCompleteSearch_ddlFindTypeEvent(object sender, EventArgs e)
    {
        DropDownList ddlFindType = (DropDownList)ucAutoCompleteSearch.FindControl("ddlFindType");
        Filter fltr = (Filter)Session["FilterField"];
        fltr.IncrementalSearch = ddlFindType.SelectedValue;
        Session["FilterField"] = fltr;
        //
        ((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text = "";
        AssignReportParameters();
    }
    private void ucAutoCompleteSearch_btnSearchEvent(object sender, EventArgs e)
    {
        SetSpecificAccountFilter();
        LoadSearchPrameters();
        RestSelectedRow();
        BindGridView();
    }

    protected void btnTag_Click(object sender, EventArgs e)
    {
        UpdateAccountGridTags((ArrayList)ViewState["CheckedTags"], (ArrayList)ViewState["UnCheckedTags"]);
        ((ArrayList)ViewState["CheckedTags"]).Clear();
        ((ArrayList)ViewState["UnCheckedTags"]).Clear();
        lblTransMsg.Visible = true;

        //ddlTaged.SelectedValue = "All";
        //ViewState["Tag"] = "All";
        LoadSearchPrameters();
        RestSelectedRow();
        BindGridView();
    }
    private void ucTransToolBar_btnAddEventEvent(object sender, EventArgs e)
    {
        AddNewAccount();
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        ContactAccount CA = new ContactAccount();
        Accounts objAccounts = new Accounts();
        string[] AccNames = new string[0];

        Filter fltr = (Filter)objAccounts.Session["FilterField"];

        string SelectedTableName = fltr.IncrementalSearch;

        string Country = "-1";
        string State = "-1";

        

        if (fltr.LocationType == "Country")
            Country = fltr.LocationName;
        else if (fltr.LocationType == "State")
            State = fltr.LocationName;

        if (SelectedTableName == "Company")
            AccNames = CA.GetAllAccountsNames(prefixText, ContactAccount.SearchBy.AName, Country, State, fltr.BusSector, fltr.Notes, fltr.Tag);

        if (SelectedTableName == "Business Sector")
            AccNames = CA.GetAllAccountsNames(prefixText, ContactAccount.SearchBy.BusinessSectorName, Country, State, fltr.BusSector, fltr.Notes, fltr.Tag);
        //Added by Sayed 18-12-2011
        if (SelectedTableName == "Telephone")
            AccNames = CA.GetAllAccountsNames(prefixText, ContactAccount.SearchBy.Telephone, Country, State, fltr.BusSector, fltr.Notes, fltr.Tag);
        if (SelectedTableName == "Fax")
            AccNames = CA.GetAllAccountsNames(prefixText, ContactAccount.SearchBy.Fax, Country, State, fltr.BusSector, fltr.Notes, fltr.Tag);
        if (SelectedTableName == "Company No")
            AccNames = CA.GetAllAccountsNames(prefixText, ContactAccount.SearchBy.AID,Country, State, fltr.BusSector, fltr.Notes, fltr.Tag);
        if (SelectedTableName == "Email")
            AccNames = CA.GetAllAccountsNames(prefixText, ContactAccount.SearchBy.Email, Country, State, fltr.BusSector, fltr.Notes, fltr.Tag);
        if (SelectedTableName == "Website")
            AccNames = CA.GetAllAccountsNames(prefixText, ContactAccount.SearchBy.Website, Country, State, fltr.BusSector, fltr.Notes, fltr.Tag);
        //
        return AccNames;
    }

    protected void btnTagAll_Click(object sender, ImageClickEventArgs e)
    {
        TagAccountsGridView(gvAccounts, true);
    }

    protected void btnUnTagAll_Click(object sender, ImageClickEventArgs e)
    {
        TagAccountsGridView(gvAccounts, false);
    }

    private void RestSelectedRow()
    {
        ViewState["AccountID"] = "";
        gvAccounts.SelectedIndex = -1;
        gvAccounts.PageIndex = 0;
        lblTransMsg.Visible = false;

    }
    private void RestGridPageIndex()
    {
        gvAccounts.PageIndex = 0;
    }
    
    protected void gvAccounts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        ChangePageIndex(e.NewPageIndex, false);
        Session["AccountsPageIndex"] = e.NewPageIndex;
        EmailGridView(gvAccounts, cbxEmailAll.Checked);
    }

    private void ChangePageIndex(int NewIndex, bool IsTurnBack)
    {
        RestSelectedRow();
        gvAccounts.PageIndex = NewIndex;
        BindGridView();
        

        //if(!IsTurnBack)
        //{
        //    foreach (GridViewRow row in gvAccounts.Rows)
        //    {
        //        if (((ArrayList)ViewState["CheckedTags"]).Contains(((CheckBox)row.Cells[0].Controls[1]).Text))
        //        {
        //            ((CheckBox)row.Cells[0].Controls[1]).Checked = true;
        //        }
        //        if (((ArrayList)ViewState["UnCheckedTags"]).Contains(((CheckBox)row.Cells[0].Controls[1]).Text))
        //        {
        //            ((CheckBox)row.Cells[0].Controls[1]).Checked = false;
        //        }
        //    }
        //}
    }

    protected void gvAccounts_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["AccountID"] = gvAccounts.DataKeys[gvAccounts.SelectedIndex].Values["AccountID"].ToString();
        lblTransMsg.Visible = false;
        // redirect user on double click occure - mglil
        //object[] sessionStr = new object[2];
        //sessionStr[0] = ViewState["AccountID"];
        //sessionStr[1] = gvAccounts.PageIndex;
        //Session["SingleAccountID"] = sessionStr;

        Session["SingleAccountID"] = ViewState["AccountID"];
        //
        //Session["PageIndex"] = gvAccounts.SelectedIndex;
        //if (ViewState["SpecificAccount"].ToString() == "")
        if (Session["FilterField"] == null)
            Session["CurrentSelectedRowIndex"] = gvAccounts.PageIndex * gvAccounts.PageSize + gvAccounts.SelectedIndex;
        else
        {
            if (((Filter)Session["FilterField"]).IncrementalSearchValue == "")
                Session["CurrentSelectedRowIndex"] = gvAccounts.PageIndex * gvAccounts.PageSize + gvAccounts.SelectedIndex;
            else
                Session["CurrentSelectedRowIndex"] = -2;
        }
        //
        Response.Redirect("AccountLists.aspx");
        // end - mglil
    }

    protected void gvAccounts_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='none';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            //e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvAccounts, "Select$" + e.Row.RowIndex);
            e.Row.Attributes["ondblclick"] = ClientScript.GetPostBackClientHyperlink(this.gvAccounts, "Select$" + e.Row.RowIndex);
            foreach (TableCell tc in e.Row.Cells)
            {
                tc.CssClass = "GridCellStyle";
            }
        }
    }

    protected void gvAccounts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            HyperLink lnkbtnWebSite = (HyperLink)e.Row.FindControl("lnkWebSite");
            if (lnkbtnWebSite.Text == "NULL")
            {
                lnkbtnWebSite.Visible = false;
            }
        }
        
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

    protected void gvAccounts_Sorting(object sender, GridViewSortEventArgs e)
    {
        Session["SortExpression"] = e.SortExpression;
        //
        OrderBy(e.SortExpression);
        LoadSearchPrameters();
        //
        ViewState["AccountID"] = "";
        gvAccounts.SelectedIndex = -1;
        lblTransMsg.Visible = false;
        //
        BindGridView();
    }

    private void SetSpecificAccountFilter() 
    {
        DropDownList ddlFindType = (DropDownList)ucAutoCompleteSearch.FindControl("ddlFindType");
        Filter fltr = (Filter)Session["FilterField"];
        fltr.IncrementalSearch = ddlFindType.SelectedValue;
        //
        TextBox objtxtSearch = (TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch");
        // Added by fawzi to fix bug 1774 #1
        ViewState["SpecificAccount"] = fltr.IncrementalSearchValue = objtxtSearch.Text.Replace("'", "''");
        Session["FilterField"] = fltr;
        //
    }

    private void OrderBy(string field)
    {
        if (ViewState["SortType"].ToString().Trim() == "ASC".Trim())
        {
            ViewState["SortType"] = "Desc";
            Session["SortType"] = "Desc";
        }
        else
        {
            ViewState["SortType"] = "ASC";
            Session["SortType"] = "ASC";
        }

            ViewState["orderbyField"] = field;
    }

    protected void imgbtnSignOut_Click(object sender, ImageClickEventArgs e)
    {
        SignOut();
    }
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Added By Fawzi June-13-2010 // For Mod. 2626 #1
        Session["Country"] = ddlCountry.SelectedItem.Text;
        //

        if (ddlCountry.SelectedValue != "United States")
        {
            ddlState.Items.Clear();
            ddlState.Items.Add("State");
            ddlState.Enabled = false;

            if (ddlCountry.SelectedValue != "All")
            {
                ViewState["LocationFilter"] = "Country";
                ViewState["SpecificLocation"] = ddlCountry.SelectedValue;
                Filter fltr = (Filter)Session["FilterField"];
                fltr.LocationType = "Country";
                fltr.LocationName = ddlCountry.SelectedValue;
                Session["FilterField"] = fltr;

                // Added By Fawzi June-8-2009 //
                SetSessionStates("Country", ddlCountry.SelectedValue);
                //
                
                LoadSearchPrameters();
                RestSelectedRow();
                BindGridView();
            }
            else
            {
                ViewState["LocationFilter"] = "Country";
                ViewState["SpecificLocation"] = "";
                Filter fltr = (Filter)Session["FilterField"];
                fltr.LocationType = "Country";
                fltr.LocationName = "-1";
                Session["FilterField"] = fltr;
                
                // Added By Fawzi June-8-2009 //
                //SetSessionStates("Country", null);
                //SetSessionStates("State", null);
                //
                
                LoadSearchPrameters();
                RestSelectedRow();
                BindGridView();
            }
        }
        else
        {
            ViewState["LocationFilter"] = "Country";
            ViewState["SpecificLocation"] = ddlCountry.SelectedValue;
            Filter fltr = (Filter)Session["FilterField"];
            fltr.LocationType = "Country";
            fltr.LocationName = ddlCountry.SelectedValue;
            Session["FilterField"] = fltr;
            
            // Added By Fawzi June-8-2009 //
            SetSessionStates("Country", ddlCountry.SelectedValue);
            //
            
            LoadSearchPrameters();
            RestSelectedRow();
            BindGridView();

            ddlState.Enabled = true;
            ddlState.DataSource = GetStateList();
            ddlState.DataBind();
            ddlState.Items.Insert(0, "All");
        }
       

    }
    
    private void SetSessionStates(string SessionName, string SessionValue)
    {
        // Added By Fawzi June-8-2009
        Session[SessionName] = SessionValue;
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedValue != "All")
        {
            ViewState["LocationFilter"] = "State";
            ViewState["SpecificLocation"] = ddlState.SelectedValue;
            Filter fltr = (Filter)Session["FilterField"];
            fltr.LocationType = "State";
            fltr.LocationName = ddlState.SelectedValue;
            Session["FilterField"] = fltr;
            
            // Added By Fawzi June-8-2009 //
            SetSessionStates("State", ddlState.SelectedValue);
            //
            
            LoadSearchPrameters();
            RestSelectedRow();
            BindGridView();
        }
        else
        {
            ViewState["LocationFilter"] = "Country";
            ViewState["SpecificLocation"] = "United States";
            Filter fltr = (Filter)Session["FilterField"];
            fltr.LocationType = "Country";
            fltr.LocationName = "United States";
            Session["FilterField"] = fltr;
            
            // Added By Fawzi June-8-2009 //
            SetSessionStates("State", null);
            //
            
            LoadSearchPrameters();
            RestSelectedRow();
            BindGridView();
        }
    }
    protected void ddlBusSector_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Filter fltr = new Filter();
        Session["SpecificAccount"] = ddlBusSector.SelectedValue;
        ViewState["SpecificAccount"] = (ddlBusSector.SelectedValue != "All") ? ddlBusSector.SelectedValue : "";
        Filter fltr = (Filter)Session["FilterField"];
        fltr.BusSector = (ddlBusSector.SelectedValue != "All") ? ddlBusSector.SelectedValue : "-1";
        Session["FilterField"] = fltr;
        LoadSearchPrameters();
        RestSelectedRow();
        BindGridView();
    }

    private void AddNewAccount()
    {
        Session["NewAccount"] = true;
        Response.Redirect("AccountLists.aspx");
    }
    protected void btnReset_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Accounts.aspx");
    }
    protected void chkboxTag_CheckedChanged(object sender, EventArgs e)
    {
        if (((CheckBox)sender).Checked)
            ((ArrayList)ViewState["CheckedTags"]).Add(((CheckBox)sender).ToolTip);
        else
            ((ArrayList)ViewState["UnCheckedTags"]).Add(((CheckBox)sender).ToolTip);
    }
    protected void ddlNotes_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["FilterAccountNotes"] = ddlNotes.SelectedValue;
        Filter fltr = (Filter)Session["FilterField"];
        fltr.Notes = (ddlNotes.SelectedValue != "All") ? ddlNotes.SelectedValue : "-1";
        Session["FilterField"] = fltr;
        LoadSearchPrameters();
        RestSelectedRow();
        BindGridView();
    }
    protected void ddlCountry_DataBound(object sender, EventArgs e)
    {
        ddlCountry.SelectedValue = ddlCountry.Items.FindByText("Egypt").Value;
    }
    
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Added By Fawzi June-21-2010 //
        Filter fltr = (Filter)Session["FilterField"];
        if (ddlStatus.SelectedValue.ToLower() == "all")
        {
            ViewState["StatusID"] = "All";
            fltr.StatusID = -1;
        }
        else
        {
            ViewState["StatusID"] = ddlStatus.SelectedItem.Value;
            fltr.StatusID = int.Parse(ddlStatus.SelectedItem.Value);
        }
       
        Session["FilterField"] = fltr;
        Session["StatusID"] = ViewState["StatusID"];
        LoadSearchPrameters();
        RestSelectedRow();
        BindGridView();
    }
    protected void cbxEmailAll_CheckedChanged(object sender, EventArgs e)
    {
        EmailGridView(gvAccounts, cbxEmailAll.Checked);
    }

    protected void ucTransToolBar_btnSendEvent(object sender, EventArgs e)
    {
        Session["SendEmailAccs"] = GatherAcountsToSendEmail();
        Session["SendEmailCons"] = null;
        Response.Redirect("SendEmail.aspx");
    }

    private List<string> GatherAcountsToSendEmail()
    {
        DataTable dtAccountsEmail = CreateDataTable();
        List<string> Accs = new List<string>();
        foreach (GridViewRow gvrow in gvAccounts.Rows)
        {
            if (gvrow.RowType == DataControlRowType.DataRow)
            {
                //string[] Acc = new string[3];
                //Acc[0] = gvAccounts.DataKeys[gvrow.RowIndex].Value.ToString();
                //Acc[1] = gvrow.Cells[1].Text;
                //Acc[2] = gvAccounts.DataKeys[gvrow.RowIndex].Values[1].ToString();
                if (((CheckBox)gvrow.Cells[0].Controls[1]).Checked)
                {
                    if (gvAccounts.DataKeys[gvrow.RowIndex].Values[1] != null)
                    {
                        if (gvAccounts.DataKeys[gvrow.RowIndex].Values[1].ToString().Length > 0)
                        {
                            Accs.Add(gvAccounts.DataKeys[gvrow.RowIndex].Values[1].ToString());
                            // added by Sayed 19-12-2011
                            DataRow dr = dtAccountsEmail.NewRow();
                            dr["id"] = gvAccounts.DataKeys[gvrow.RowIndex].Values[0];
                            dr["email"] = gvAccounts.DataKeys[gvrow.RowIndex].Values[1];
                            dr["cname"] = gvrow.Cells[1].Text;

                            dtAccountsEmail.Rows.Add(dr);
                        }
                    }
                }
            }
        }
        Session["dtContactsEmail"] = null;
        Session["dtAccountsEmail"] = dtAccountsEmail;
        return Accs;
    }
    private DataTable CreateDataTable()
    {
        DataTable myDataTable = new DataTable();
        DataColumn myDataColumn;
        DataColumn[] keys = new DataColumn[1];
        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "id";
        myDataTable.Columns.Add(myDataColumn);
        keys[0] = myDataColumn;
        myDataTable.PrimaryKey = keys;


        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "cname";
        myDataTable.Columns.Add(myDataColumn);

       
        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "email";
        myDataTable.Columns.Add(myDataColumn);

        return myDataTable;
    }
    protected void ddlAction_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAction.SelectedValue.ToLower() == "1")//send email
        {
            Session["SendEmailAccs"] = GatherAcountsToSendEmail();
            Session["SendEmailCons"] = null;
            Response.Redirect("SendEmail.aspx");
        }
        else if (ddlAction.SelectedValue.ToLower() == "2")//schedule call
        {
            // please yasser complete developing in this section to send data to call page
            Response.Redirect("CallsManagement.aspx");
           
        }
        

    }
}
