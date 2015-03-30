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

public partial class Branches : Office.BLL.BranchesPageBLL
{
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
            Filter fltr;
            try
            {
                if (Session["BranchFilterField"] == null)
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
                    fltr = (Filter)Session["BranchFilterField"];
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
            Session["BranchFilterField"] = fltr;

            // Commented By Fawzi June-8-2009 
            // Session["FilterBranchNotes"] = null;
            //
            LoadSearchPrameters();
            if (Session["SingleBranchID"] != null && Session["SingleBranchID"].ToString() != "")
            {
                int PageNo = Session["BranchesPageIndex"] == null ? 0 : Convert.ToInt32(Session["BranchesPageIndex"]);
                //int PageNo = GetAccountGridPageNo(int.Parse(Session["SingleBranchID"].ToString()), gvAccounts.PageSize);
                ChangePageIndex(PageNo, true);
                Session["SingleBranchID"] = null;
            }
            else
                BindGridView();

            //int AccountsCount = GetAccountsCount();
            //CheckedTags = new bool[(AccountsCount != -1) ? AccountsCount : 0];
            ViewState["CheckedTags"] = new ArrayList();
            ViewState["UnCheckedTags"] = new ArrayList();
            //
        }
        string CurrentPage = "Branches";
        ucTransToolBar.CurrentPage = CurrentPage;
        ucTransToolBar.btnSaveEvent += new EventHandler(ucTransToolBar_btnSaveEventEvent);
        //
        ucTransToolBar.btnAddEvent += new EventHandler(ucTransToolBar_btnAddEventEvent);
        AssignReportParameters();
        //////
		  //ucUserTabs.CurrentPage = CurrentPage;
		  //ucUserTabs.btnAccountsEvent += new EventHandler(ucUserTabs_btnAccountsEvent);
		  //ucUserTabs.btnAccountListsEvent += new EventHandler(ucUserTabs_btnAccountListsEvent);
		  //ucUserTabs.btnContantsEvent += new EventHandler(ucUserTabs_btnContantsEvent);
		  //ucUserTabs.btnContactListsEvent += new EventHandler(ucUserTabs_btnContactListsEvent);
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
    }

    private void LoadSearchPrameters()
    {
        if (!Page.IsPostBack) // Added By Fawzi June-8-2009 //
        {
            // Added By Fawzi June-8-2009 //
            if (Session["BranchCountry"] != null)
            {

                if (Session["BranchCountry"].ToString() == "All")
                {
                    ddlCountry.SelectedValue = ddlCountry.Items.FindByText("All").Value;
                    ViewState["LocationFilter"] = "Country";
                    ViewState["SpecificLocation"] = "";
                    Filter fltr = (Filter)Session["BranchFilterField"];
                    fltr.LocationType = "Country";
                    fltr.LocationName = "-1";
                    Session["BranchFilterField"] = fltr;
                }
                else
                {
                    ddlCountry.SelectedValue = Session["BranchCountry"].ToString();
                    ViewState["LocationFilter"] = "Country";
                    ViewState["SpecificLocation"] = ddlCountry.SelectedValue;
                    Filter fltr = (Filter)Session["BranchFilterField"];
                    fltr.LocationType = "Country";
                    fltr.LocationName = ddlCountry.SelectedValue;
                    Session["BranchFilterField"] = fltr;
                }

                if (Session["BranchState"] != null)
                {
                    ddlState.Enabled = true;
                    ddlState.DataSource = GetStateList();
                    ddlState.DataBind();
                    ddlState.Items.Insert(0, "All");
                    //
                    ddlState.SelectedValue = Session["BranchState"].ToString();
                    ViewState["LocationFilter"] = "State";
                    ViewState["SpecificLocation"] = ddlState.SelectedValue;
                    Filter fltr = (Filter)Session["BranchFilterField"];
                    fltr.LocationType = "State";
                    fltr.LocationName = ddlState.SelectedValue;
                    Session["BranchFilterField"] = fltr;
                }

            }
            // Added By Fawzi June-13-2010 // For Mod. 2626 #3
            else
            {
                ddlCountry.SelectedValue = ddlCountry.Items.FindByText("Egypt").Value;
                Session["BranchCountry"] = "Egypt";
                ViewState["LocationFilter"] = "Country";
                ViewState["SpecificLocation"] = ddlCountry.SelectedValue;
                Filter fltr = (Filter)Session["BranchFilterField"];
                fltr.LocationType = "Country";
                fltr.LocationName = ddlCountry.SelectedValue;
                Session["BranchFilterField"] = fltr;
            }

            // Added By Fawzi June-7-2009 //
            if (Session["Tag"] != null)
            {
                ViewState["Tag"] = Session["Tag"];
                //ddlTaged.SelectedValue = ViewState["Tag"].ToString();
            }
            //

            // Added By Fawzi to Fix Bug 1611 #2 
            if (Session["SpecificBranch"] != null)
            {
                ViewState["SpecificAccount"] = Session["SpecificBranch"].ToString();
                ddlBusSector.SelectedValue = ViewState["SpecificAccount"].ToString();
                Filter fltr;
                if (Session["BranchFilterField"] == null)
                    fltr = new Filter();
                else
                    fltr = (Filter)Session["BranchFilterField"];
                //fltr.IncrementalSearch = "Business Sector";
                fltr.BusSector = ddlBusSector.SelectedValue;
                fltr.Tag = "-1";
                fltr.Notes = "-1";
                Session["BranchFilterField"] = fltr;

                //
            }
            //
            if (Session["FilterBranchNotes"] == null)
            {
                Session["FilterBranchNotes"] = 0;
            }
            else
            {
                ddlNotes.SelectedValue = Session["FilterBranchNotes"].ToString();
            }
        }

        Session["Branch"] = GetSearchFilter(ViewState["orderbyField"].ToString(), ViewState["SortType"].ToString(), ViewState["SpecificAccount"].ToString(), (Filter)Session["BranchFilterField"], ViewState["LocationFilter"].ToString(), ViewState["SpecificLocation"].ToString(), int.Parse(Session["FilterBranchNotes"].ToString()));
        // Commented by Yasser  June-15-2009
        //// Added By Fawzi June-8-2009 //
        ////ResetIncrementalSearch();
    }

    private void ChangePageIndex(int NewIndex, bool IsTurnBack)
    {
        RestSelectedRow();
        gvBranches.PageIndex = NewIndex;
        BindGridView();
    }

    private void BindGridView()
    {
        gvBranches.DataSource = odsBranches;
        gvBranches.DataBind();
        FormatGridValues(gvBranches, "NULL", "");
    }

    private void RestSelectedRow()
    {
        ViewState["AccountID"] = "";
        gvBranches.SelectedIndex = -1;
        gvBranches.PageIndex = 0;
        lblTransMsg.Visible = false;

    }

    private void AssignReportParameters()
    {
        string SpecificBranch = ((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text;
        ((ImageButton)ucTransToolBar.FindControl("btnPrint")).Attributes.Add("onclick", "openReports('" + ViewState["orderbyField"].ToString() + "','" + ViewState["SortType"].ToString() + "','" + ViewState["Tag"].ToString() + "','" + SpecificBranch + "','" + ((Filter)Session["BranchFilterField"]).IncrementalSearch + "','" + ViewState["LocationFilter"].ToString() + "','" + ViewState["SpecificLocation"].ToString() + "');");
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

    private void ucUserTabs_btnBranchesDetailsEvent(object sender, EventArgs e)
    {
        Session["SingleBranchID"] = ViewState["AccountID"].ToString();
        Response.Redirect("BranchDetails.aspx");
    }

    private void ucUserTabs_btnCallsEvent(object sender, EventArgs e)
    {
        Response.Redirect("CallsManagement.aspx");
    }

    void ucUserTabs_btnManageApplicationEvent(object sender, EventArgs e)
    {
        Response.Redirect("ManageApplication.aspx");
    }

    private void ucAutoCompleteSearch_ddlFindTypeEvent(object sender, EventArgs e)
    {
        DropDownList ddlFindType = (DropDownList)ucAutoCompleteSearch.FindControl("ddlFindType");
        Filter fltr = (Filter)Session["BranchFilterField"];
        fltr.IncrementalSearch = ddlFindType.SelectedValue;
        Session["BranchFilterField"] = fltr;
        //
        ((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text = "";
        AssignReportParameters();
    }
    private void ucAutoCompleteSearch_btnSearchEvent(object sender, EventArgs e)
    {
        SetSpecificBranchFilter();
        LoadSearchPrameters();
        RestSelectedRow();
        BindGridView();
    }

    private void SetSpecificBranchFilter()
    {
        DropDownList ddlFindType = (DropDownList)ucAutoCompleteSearch.FindControl("ddlFindType");
        Filter fltr = (Filter)Session["BranchFilterField"];
        fltr.IncrementalSearch = ddlFindType.SelectedValue;
        //
        TextBox objtxtSearch = (TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch");
        // Added by fawzi to fix bug 1774 #1
        ViewState["SpecificAccount"] = fltr.IncrementalSearchValue = objtxtSearch.Text.Replace("'", "''");
        Session["BranchFilterField"] = fltr;
        //
    }

    private void ucTransToolBar_btnSaveEventEvent(object sender, EventArgs e)
    {
        lblTransMsg.Visible = true;

        LoadSearchPrameters();
        RestSelectedRow();
        BindGridView();
    }
    private void ucTransToolBar_btnAddEventEvent(object sender, EventArgs e)
    {
        AddNewAccount();
    }

    private void AddNewAccount()
    {
        Session["NewBranch"] = true;
        Response.Redirect("BranchDetails.aspx");
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        Office.DAL.Branches BR = new Office.DAL.Branches();
        Branches objBranch = new Branches();
        string[] BrNames = new string[0];

        Filter fltr = (Filter)objBranch.Session["BranchFilterField"];

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


    protected void gvBranches_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        ChangePageIndex(e.NewPageIndex, false);
        Session["BranchesPageIndex"] = e.NewPageIndex;
    }
    protected void gvBranches_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='none';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            //e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvAccounts, "Select$" + e.Row.RowIndex);
            e.Row.Attributes["ondblclick"] = ClientScript.GetPostBackClientHyperlink(this.gvBranches, "Select$" + e.Row.RowIndex);
            foreach (TableCell tc in e.Row.Cells)
            {
                tc.CssClass = "GridCellStyle";
            }
        }
    }
    protected void gvBranches_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void gvBranches_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["AccountID"] = gvBranches.DataKeys[gvBranches.SelectedIndex].Values["BranchID"].ToString();
        lblTransMsg.Visible = false;

        Session["SingleBranchID"] = ViewState["AccountID"];

        if (Session["BranchFilterField"] == null)
            Session["CurrentBranchSelectedRowIndex"] = gvBranches.PageIndex * gvBranches.PageSize + gvBranches.SelectedIndex;
        else
        {
            if (((Filter)Session["BranchFilterField"]).IncrementalSearchValue == "")
                Session["CurrentBranchSelectedRowIndex"] = gvBranches.PageIndex * gvBranches.PageSize + gvBranches.SelectedIndex;
            else
                Session["CurrentBranchSelectedRowIndex"] = -2;
        }
        //
        Response.Redirect("BranchDetails.aspx");
        // end - mglil
    }
    protected void gvBranches_Sorting(object sender, GridViewSortEventArgs e)
    {
        Session["BranchSortExpression"] = e.SortExpression;
        //
        OrderBy(e.SortExpression);
        LoadSearchPrameters();
        //
        ViewState["AccountID"] = "";
        gvBranches.SelectedIndex = -1;
        lblTransMsg.Visible = false;
        //
        BindGridView();
    }
    private void OrderBy(string field)
    {
        if (ViewState["SortType"].ToString().Trim() == "ASC".Trim())
        {
            ViewState["SortType"] = "Desc";
            Session["BranchSortType"] = "Desc";
        }
        else
        {
            ViewState["SortType"] = "ASC";
            Session["BranchSortType"] = "ASC";
        }

        ViewState["orderbyField"] = field;
    }
    protected void imgbtnSignOut_Click(object sender, ImageClickEventArgs e)
    {
        SignOut();
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        Filter fltr = (Filter)Session["BranchFilterField"];
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

        Session["BranchFilterField"] = fltr;
        Session["BranchStatusID"] = ViewState["StatusID"];
        LoadSearchPrameters();
        RestSelectedRow();
        BindGridView();
    }
    protected void ddlBusSector_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["SpecificBranch"] = ddlBusSector.SelectedValue;
        ViewState["SpecificAccount"] = (ddlBusSector.SelectedValue != "All") ? ddlBusSector.SelectedValue : "";
        Filter fltr = (Filter)Session["BranchFilterField"];
        fltr.BusSector = (ddlBusSector.SelectedValue != "All") ? ddlBusSector.SelectedValue : "-1";
        Session["BranchFilterField"] = fltr;
        LoadSearchPrameters();
        RestSelectedRow();
        BindGridView();
    }
    protected void ddlCountry_DataBound(object sender, EventArgs e)
    {
        ddlCountry.SelectedValue = ddlCountry.Items.FindByText("Egypt").Value;
    }
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["BranchCountry"] = ddlCountry.SelectedItem.Text;
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
                Filter fltr = (Filter)Session["BranchFilterField"];
                fltr.LocationType = "Country";
                fltr.LocationName = ddlCountry.SelectedValue;
                Session["BranchFilterField"] = fltr;

                Session["BranchCountry"] = ddlCountry.SelectedValue;

                LoadSearchPrameters();
                RestSelectedRow();
                BindGridView();
            }
            else
            {
                ViewState["LocationFilter"] = "Country";
                ViewState["SpecificLocation"] = "";
                Filter fltr = (Filter)Session["BranchFilterField"];
                fltr.LocationType = "Country";
                fltr.LocationName = "-1";
                Session["BranchFilterField"] = fltr;

                LoadSearchPrameters();
                RestSelectedRow();
                BindGridView();
            }
        }
        else
        {
            ViewState["LocationFilter"] = "Country";
            ViewState["SpecificLocation"] = ddlCountry.SelectedValue;
            Filter fltr = (Filter)Session["BranchFilterField"];
            fltr.LocationType = "Country";
            fltr.LocationName = ddlCountry.SelectedValue;
            Session["BranchFilterField"] = fltr;

            Session["BranchCountry"] = ddlCountry.SelectedValue;

            LoadSearchPrameters();
            RestSelectedRow();
            BindGridView();

            ddlState.Enabled = true;
            ddlState.DataSource = GetStateList();
            ddlState.DataBind();
            ddlState.Items.Insert(0, "All");
        }
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedValue != "All")
        {
            ViewState["LocationFilter"] = "State";
            ViewState["SpecificLocation"] = ddlState.SelectedValue;
            Filter fltr = (Filter)Session["BranchFilterField"];
            fltr.LocationType = "State";
            fltr.LocationName = ddlState.SelectedValue;
            Session["BranchFilterField"] = fltr;

            // Added By Fawzi June-8-2009 //
            Session["BranchState"] = ddlState.SelectedValue;
            //

            LoadSearchPrameters();
            RestSelectedRow();
            BindGridView();
        }
        else
        {
            ViewState["LocationFilter"] = "Country";
            ViewState["SpecificLocation"] = "United States";
            Filter fltr = (Filter)Session["BranchFilterField"];
            fltr.LocationType = "Country";
            fltr.LocationName = "United States";
            Session["BranchFilterField"] = fltr;

            // Added By Fawzi June-8-2009 //
            Session["BranchState"] = null;
            //

            LoadSearchPrameters();
            RestSelectedRow();
            BindGridView();
        }
    }
    protected void ddlNotes_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["FilterBranchNotes"] = ddlNotes.SelectedValue;
        Filter fltr = (Filter)Session["BranchFilterField"];
        fltr.Notes = (ddlNotes.SelectedValue != "All") ? ddlNotes.SelectedValue : "-1";
        Session["BranchFilterField"] = fltr;
        LoadSearchPrameters();
        RestSelectedRow();
        BindGridView();
    }
}