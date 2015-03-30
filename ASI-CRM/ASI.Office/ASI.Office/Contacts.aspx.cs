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

public partial class Contacts : Office.BLL.ContactsBLL
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckUserSession();
        if (!IsPostBack)
        {
          

            // commented by Moawad 11-4-2012
            //ViewState["orderbyField"] = "AccountName";
            ViewState["orderbyField"] = "FirstName";
            ViewState["SortType"] = "ASC";
            ViewState["Tag"] = "All";
            ViewState["SpecificFilter"] = "";
            ViewState["ContactID"] = "";
            Filter fltr;
            try
            {
                if (Session["ContactsFilterField"] == null)
                {
                    fltr = new Filter();
                    // commented by Moawad 11-4-2012
                   // fltr.IncrementalSearch = "Company";
                    fltr.IncrementalSearch = "FirstName";

                    fltr.IncrementalSearchValue = "";
                    fltr.Tag = "-1";
                    fltr.Notes = "-1";
                    fltr.SortCriteria = "FirstName";
                }
                else
                    fltr = (Filter)Session["ContactsFilterField"];
            }
            catch
            {
                fltr = new Filter();
                // commented by Moawad 11-4-2012
                // fltr.IncrementalSearch = "Company";
                fltr.IncrementalSearch = "FirstName";

                fltr.IncrementalSearchValue = "";
                fltr.Tag = "-1";
                fltr.Notes = "-1";
                fltr.SortCriteria = "FirstName";
            }
            
            Session["ContactsFilterField"] = fltr;
            //
            Session["FilterContactNotes"] = null;
            Session["FilterContactSort"] = ViewState["orderbyField"];
            //
            LoadSearchPrameters();
            if (Session["SingleContactID"] != null && Session["SingleContactID"].ToString() != "")
            {
                // Sayed's comment 27/12/2011
                //there is error here , it didn't take the search criteria when got the page number.
               // int PageNo = GetContactGridPageNo(int.Parse(Session["SingleContactID"].ToString()), gvContacts.PageSize);
                int PageNo = Session["ContactsPageIndex"] == null ? 0 : Convert.ToInt32(Session["ContactsPageIndex"]);
                         
                ChangePageIndex(PageNo);
                Session["SingleContactID"] = null;
            }
            else
            {
                if (Request.QueryString["Email"] != null && Request.QueryString["Email"] != "")
                {
                    ((DropDownList)ucAutoCompleteSearch.FindControl("ddlFindType")).SelectedValue = "Email";
                    ((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text = Request.QueryString["Email"];
                    SetSpecificAccountFilter();
                    LoadSearchPrameters();
                    RestSelectedRow();
                }
                BindGridView();
            }

            //gvContacts_Sorting(this, new GridViewSortEventArgs("FirstName", SortDirection.Descending));
        }
       
        string CurrentPage = "Contacts";
        ucTransToolBar.CurrentPage = CurrentPage;
        ucTransToolBar.btnSendEvent += new EventHandler(ucTransToolBar_btnSendEvent);
        AssignReportParameters();
        //
		  //ucUserTabs.CurrentPage = CurrentPage;
		  //ucUserTabs.btnAccountsEvent += new EventHandler(ucUserTabs_btnAccountsEvent);
		  //ucUserTabs.btnAccountListsEvent += new EventHandler(ucUserTabs_btnAccountListsEvent);
		  //ucUserTabs.btnContactListsEvent += new EventHandler(ucUserTabs_btnContactListsEvent);
		  //ucUserTabs.btnBranchesEvent += new EventHandler(ucUserTabs_btnBranchesEvent);
		  //ucUserTabs.btnBranchesDetailsEvent += new EventHandler(ucUserTabs_btnBranchesDetailsEvent);
		  //ucUserTabs.btnCallsEvent += new EventHandler(ucUserTabs_btnCallsEvent);
		  //ucUserTabs.btnManageApplicationEvent += new EventHandler(ucUserTabs_btnManageApplicationEvent);
     
        ucAutoCompleteSearch.CurrentPage = CurrentPage;
        ucAutoCompleteSearch.btnSearchEvent += new EventHandler(ucAutoCompleteSearch_btnSearchEvent);
        ucAutoCompleteSearch.ddlFindTypeEvent += new EventHandler(ucAutoCompleteSearch_ddlFindTypeEvent);
        
        //////
        btnTagAll.Attributes.Add("onmouseover", "this.src='Images/Tag-o.jpg'");
        btnTagAll.Attributes.Add("onmouseout", "this.src='Images/Tag-n.jpg'");
        btnTagAll.Attributes.Add("onmousedown", "this.src='Images/Tag-s.jpg'");

        btnReset.Attributes.Add("onmouseover", "this.src='Images/Reset-o.jpg'");
        btnReset.Attributes.Add("onmouseout", "this.src='Images/Reset-n.jpg'");
        btnReset.Attributes.Add("onmousedown", "this.src='Images/Reset-s.jpg'");
        //////
        btnUnTagAll.Attributes.Add("onmouseover", "this.src='Images/accountDetails_select_31.jpg'");
        btnUnTagAll.Attributes.Add("onmouseout", "this.src='Images/accountDetails_31.jpg'");
        //
		  //imgbtnSignOut.Attributes.Add("onmouseover", "this.src='Images/CloseBut_pressed.jpg'");
		  //imgbtnSignOut.Attributes.Add("onmouseout", "this.src='Images/CloseBut_normal.jpg'");

        btnAdvancedSearch.Attributes.Add("onmouseover", "this.src='Images/AdvancedSearch-o.jpg'");
        btnAdvancedSearch.Attributes.Add("onmouseout", "this.src='Images/AdvancedSearch-n.jpg'");
        btnAdvancedSearch.Attributes.Add("onmousedown", "this.src='Images/AdvancedSearch-s.jpg'");
    }

    protected void btnReset_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Contacts.aspx");
    }

    void ucUserTabs_btnManageApplicationEvent(object sender, EventArgs e)
    {
        Response.Redirect("ManageApplication.aspx");
    }
    private void AssignReportParameters()
    {
        string SpecificAccount = ((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text;
        ((ImageButton)ucTransToolBar.FindControl("btnPrint")).Attributes.Add("onclick", "openReports('" + ViewState["orderbyField"].ToString() + "','" + ViewState["SortType"].ToString() + "','" + ViewState["Tag"].ToString() + "','" + SpecificAccount + "','" + ((Filter)Session["ContactsFilterField"]).IncrementalSearchValue + "','','');");
    }

    private void LoadSearchPrameters()
    {
        if (!Page.IsPostBack)
        {
            Filter fltr;
            if (Session["ContactsFilterField"] == null)
            {
                fltr = new Filter();
                fltr.Tag = "-1";
                fltr.Notes = "-1";
            }
            else
                fltr = (Filter)Session["ContactsFilterField"];


            fltr.SortCriteria = ViewState["orderbyField"].ToString();
            if (fltr.Tag != "-1")
            {
                ViewState["Tag"] = fltr.Tag;
                ddlTaged.SelectedValue = ViewState["Tag"].ToString();
            }
            // commented by Sayed 27/12/2011
            if (fltr.Notes == "-1") 
           // if (fltr.Notes == null)
            {
                Session["FilterContactNotes"] = 0;
            }
            else
            {
                ddlNotes.SelectedValue = fltr.Notes;
                Session["FilterContactNotes"] = fltr.Notes;
            }
        }
        Session["FilterContactSort"] = ViewState["orderbyField"];
        Session["FilterContactSortType"] = ViewState["SortType"];
        Session["Contact"] = GetSearchFilter(ViewState["orderbyField"].ToString(), ViewState["SortType"].ToString(), ViewState["Tag"].ToString(), ViewState["SpecificFilter"].ToString(), (Filter)Session["ContactsFilterField"], int.Parse(Session["FilterContactNotes"].ToString()));
    }
    
    private void BindGridView()
    {
        gvContacts.DataSource = odsContacts;
        gvContacts.DataBind();
        FormatGridValues(gvContacts, "NULL", "");
        cbxEmailAll.Visible = gvContacts.Rows.Count > 0;

    }

    protected void ucAutoCompleteSearch_ddlFindTypeEvent(object sender, EventArgs e)
    {
       
        DropDownList ddlFindType = (DropDownList)ucAutoCompleteSearch.FindControl("ddlFindType");
        Filter fltr = (Filter)Session["ContactsFilterField"];
        fltr.IncrementalSearch = ddlFindType.SelectedValue;
        Session["ContactsFilterField"] = fltr;
        //
        // Added by fawzi 5-Aug-2010 //
        Session["ddlFilterField"] = ddlFindType.SelectedValue;
        //
        ((TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch")).Text = "";
        AssignReportParameters();
    }
    
    protected void ucUserTabs_btnAccountsEvent(object sender, EventArgs e)
    {
        Response.Redirect("Accounts.aspx");
    }
    protected void ucUserTabs_btnAccountListsEvent(object sender, EventArgs e)
    {
        Response.Redirect("AccountLists.aspx");
    }
    protected void ucUserTabs_btnContactListsEvent(object sender, EventArgs e)
    {
        Session["SingleContactID"] = ViewState["ContactID"].ToString();
        Response.Redirect("ContactLists.aspx" );
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
        Session["ContactsPageIndex"] = null;
        SetSpecificAccountFilter();
        LoadSearchPrameters();
        RestSelectedRow();
        BindGridView();
        cbxEmailAll.Checked = false;


    }

    protected void btnTagAll_Click(object sender, ImageClickEventArgs e)
    {
        UpdateContactGridTags(gvContacts);
        lblTransMsg.Visible = true;
        cbxEmailAll.Checked = false;
    }
    protected void Reset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Contacts.aspx");
    }
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        ContactContactsInfo CCI = new ContactContactsInfo();
        Contacts objContacts = new Contacts();
        string[] AccNames = new string[0];

        Filter fltr = (Filter)objContacts.Session["ContactsFilterField"];

        string SelectedTableName = fltr.IncrementalSearch;

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

        if (SelectedTableName == "ID/Status")
            AccNames = CCI.GetSearchList(prefixText, ContactContactsInfo.SearchBy.IDStatus);
        
        return AccNames;
    }
    
    //protected void btnTagAll_Click(object sender, ImageClickEventArgs e)
    //{
    //    TagGridView(gvContacts, true);
    //}
 
    protected void btnUnTagAll_Click(object sender, ImageClickEventArgs e)
    {
        TagGridView(gvContacts, false); 
    }
    
    protected void gvContacts_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ///////////////////////////////////
            e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='none';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            // double click - mglil
            //e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvContacts, "Select$" + e.Row.RowIndex);
            e.Row.Attributes["ondblclick"] = ClientScript.GetPostBackClientHyperlink(this.gvContacts, "Select$" + e.Row.RowIndex);
            // end - mglil
            

          
                
            foreach (TableCell tc in e.Row.Cells)
            {
                tc.CssClass = "GridCellStyle";
            }
        }
    }
    
    protected void gvContacts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // added by sayed 20/11/2011
            e.Row.Cells[1].Visible = false;
            // end added
            HyperLink lnkbtnWebSite = (HyperLink)e.Row.FindControl("lnkEmail");
            if (lnkbtnWebSite.Text == "NULL")
            {
                lnkbtnWebSite.Visible = false;
            }
        }
        // added by Sayed 20/11/2011
        else if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[1].Visible = false;

        }
        // end added
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
    
    protected void gvContacts_Sorting(object sender, GridViewSortEventArgs e)
    {
        OrderBy(e.SortExpression);
        LoadSearchPrameters();
        //
        ViewState["ContactID"] = "";
        gvContacts.SelectedIndex = -1;
        lblTransMsg.Visible = false;
        //
        BindGridView();

    }
    
    private void SetSpecificAccountFilter()
    {
        DropDownList ddlFindType = (DropDownList)ucAutoCompleteSearch.FindControl("ddlFindType");
        Filter fltr = (Filter)Session["ContactsFilterField"];
        fltr.IncrementalSearch = ddlFindType.SelectedValue;
        //
        TextBox objtxtSearch = (TextBox)ucAutoCompleteSearch.FindControl("txtBoxSearch");
        //
        ViewState["SpecificFilter"] = fltr.IncrementalSearchValue = objtxtSearch.Text.Replace("~", "-").Replace("'", "''");
        Session["ContactsFilterField"] = fltr;
        //
        // Added by fawzi
        Session["SpecificFilter"] = ViewState["SpecificFilter"];
        //
    }

    private void OrderBy(string field)
    {
        if (ViewState["SortType"].ToString().Trim() == "ASC".Trim())
        {
            ViewState["SortType"] = "Desc";
        }
        else
        {
            ViewState["SortType"] = "ASC";
        }

        ViewState["orderbyField"] = field;
    }

    protected void ddlTaged_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["ContactsPageIndex"] = null;
        Filter fltr = (Filter)Session["ContactsFilterField"];
        if (ddlTaged.SelectedValue == "Tagged")
        {
            ViewState["Tag"] = "Tagged";
            fltr.Tag = "Tagged";
        }
        else if (ddlTaged.SelectedValue == "Un-Tagged")
        {
            ViewState["Tag"] = "Un-Tagged";
            fltr.Tag = "Un-Tagged";
        }
        else
        {
            ViewState["Tag"] = "All";
            fltr.Tag = "-1";
        }
        Session["ContactsFilterField"] = fltr;
        LoadSearchPrameters();
        RestSelectedRow();
        BindGridView();


    }

    private void RestSelectedRow()
    {
        ViewState["ContactID"] = "";
        gvContacts.SelectedIndex = -1;
        gvContacts.PageIndex = 0;
        lblTransMsg.Visible = false;

    }
   
    protected void gvContacts_SelectedIndexChanged(object sender, EventArgs e)
     {
        ViewState["ContactID"] = gvContacts.DataKeys[gvContacts.SelectedIndex].Values["ContactID"].ToString();
        lblTransMsg.Visible = false;
        //object[] sessionStr = new object[2];
        //sessionStr[0] = ViewState["ContactID"];
        //sessionStr[1] = gvContacts.PageIndex;
        //Session["SingleContactID"] = sessionStr;
        Session["SingleContactID"] = ViewState["ContactID"];
        Response.Redirect("ContactLists.aspx?ContactID=" + ViewState["ContactID"]);
    }
    protected void gvContacts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        ChangePageIndex(e.NewPageIndex);
        Session["ContactsPageIndex"] = e.NewPageIndex;
        EmailGridView(gvContacts, cbxEmailAll.Checked);
    }
    private void ChangePageIndex(int NewIndex)
    {
        RestSelectedRow();
        gvContacts.PageIndex = NewIndex;
        BindGridView();
    }
    protected void imgbtnSignOut_Click(object sender, ImageClickEventArgs e)
    {
        SignOut();
    }
    protected void ddlNotes_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["ContactsPageIndex"] = null;
        Session["FilterContactNotes"] = ddlNotes.SelectedValue;
        Filter fltr = (Filter)Session["ContactsFilterField"];
        fltr.Notes = (ddlNotes.SelectedValue != "All") ? ddlNotes.SelectedValue : "-1";
        Session["ContactsFilterField"] = fltr;
        LoadSearchPrameters();
        RestSelectedRow();
        BindGridView();
    }
    protected void cbxEmailAll_CheckedChanged(object sender, EventArgs e)
    {
        EmailGridView(gvContacts, cbxEmailAll.Checked);
    }

    protected void ucTransToolBar_btnSendEvent(object sender, EventArgs e)
    {
        Session["SendEmailAccs"] = null;
        Session["SendEmailCons"] = GatherContactsToSendEmail();
        Response.Redirect("SendEmail.aspx");
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
        myDataColumn.ColumnName = "fname";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "lname";
        myDataTable.Columns.Add(myDataColumn);



        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "email";
        myDataTable.Columns.Add(myDataColumn);

        return myDataTable;
    }

    private List<string> GatherContactsToSendEmail()
    {
        DataTable dtContactsEmail = CreateDataTable();
        List<string> CAs = new List<string>();
        //for (int i = 0; i < gvContacts.Rows.Count; i++)
        //{
        //    if (gvContacts.Rows[i].RowType == DataControlRowType.DataRow)
        //    {
        //        if (((CheckBox)gvContacts.Rows[i].Cells[0].Controls[1]).Enabled)
        //        {
        //            if (gvContacts.DataKeys[gvContacts.Rows[i].RowIndex].Values[0] != null)
        //            {
        //                if (gvContacts.DataKeys[gvContacts.Rows[i].RowIndex].Values[0].ToString().Length > 0)
        //                    CAs.Add(((HyperLink)gvContacts.Rows[i].Cells[10].Controls[1]).NavigateUrl);
        //            }
        //        }
        //    }
        //}

        foreach (GridViewRow gvrow in gvContacts.Rows)
        {
            if (gvrow.RowType == DataControlRowType.DataRow)
            {
                //string[] CA = new string[3];
                //CA[0] = gvContacts.DataKeys[gvrow.RowIndex].Value.ToString();
                //CA[1] = (string.IsNullOrEmpty(gvrow.Cells[4].Text) ? "" : gvrow.Cells[4].Text) 
                //    + " " 
                //    + (string.IsNullOrEmpty(gvrow.Cells[5].Text) ? "" : gvrow.Cells[5].Text);
                //CA[2] = ((HtmlLink)gvrow.Cells[10].Controls[0]).ToString();
                if (((CheckBox)gvrow.Cells[0].Controls[1]).Checked)
                {
                    if (gvContacts.DataKeys[gvrow.RowIndex].Values[0] != null)
                    {
                        if (gvContacts.DataKeys[gvrow.RowIndex].Values[0].ToString().Length > 0)
                        {
                            CAs.Add(((HyperLink)gvrow.Cells[9].Controls[1]).NavigateUrl.Replace("mailto:", ""));
                            DataRow dr = dtContactsEmail.NewRow();
                            dr["id"] = gvContacts.DataKeys[gvrow.RowIndex].Values[0];
                            dr["email"] = ((HyperLink)gvrow.Cells[9].Controls[1]).NavigateUrl.Replace("mailto:", "");
                            dr["fname"] = gvrow.Cells[4].Text;
                            dr["lname"] = gvrow.Cells[5].Text;
                            try
                            {
                                dtContactsEmail.Rows.Add(dr);
                            }
                            catch (Exception ex)
                            {
                                //if(ex.Message.StartsWith("Column 'id' is co"))
                            }
                            

                        }
                    }
                }
            }
        }
        Session["dtAccountsEmail"] = null;
        Session["dtContactsEmail"] = dtContactsEmail;
        return CAs;
    }
    

    private ListItemCollection GatherContactsToScheduleCall()
    {
        ListItemCollection CAs = new ListItemCollection();

        foreach (GridViewRow gvrow in gvContacts.Rows)
        {
            if (gvrow.RowType == DataControlRowType.DataRow)
            {
                if (((CheckBox)gvrow.Cells[0].Controls[1]).Checked)
                {
                    if (gvContacts.DataKeys[gvrow.RowIndex].Values[0] != null)
                    {
                        if (gvContacts.DataKeys[gvrow.RowIndex].Values[0].ToString().Length > 0)
                        {
                            CAs.Add(new ListItem(gvrow.Cells[4].Text, gvContacts.DataKeys[gvrow.RowIndex].Values[0].ToString()));
                        }
                    }
                }
            }
        }
        return CAs;
    }
    protected void ddlAction_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAction.SelectedValue.ToLower() == "1")//send email
        {
            Session["SendEmailAccs"] = null;
            Session["SendEmailCons"] = GatherContactsToSendEmail();
            Response.Redirect("SendEmail.aspx");
        }
        else if (ddlAction.SelectedValue.ToLower() == "2")//schedule call
        {
            Session["ScheduleCallCons"] = GatherContactsToScheduleCall();
            Response.Redirect("CallsManagement.aspx");
        }


    }
}
