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

public partial class RunReport : Office.BLL.MasterClass
{
    string reportsQuerystring = "";
    string strReportPageName = "";
    int IntContactID;
    protected void Page_Load(object sender, EventArgs e)
    {
        ApplyHeaderGroup();
        if (Session["UserData"] == null)
        {
            Response.Write("<script>alert('Session Expired, Please relogin in the application','Session Expired')</script>");
            Response.Write("<script>window.open('','_parent',''); window.close();</script>"); 
            Response.End();
        }
        
        if (!IsPostBack)
        {

            IntContactID = Convert.ToInt32(Session["CurrentEmployee"]);
            ViewState["IsAdmin"] = 1; // 1 is for Admin 0 For non Admin 
            string EncryptedQS = mEncryptQueryString("10&IsAdmin=" + ViewState["IsAdmin"].ToString() + "&ContactID=" + ((Office.DAL.SecurityUserLogin)(Session["UserData"])).UserID.ToString());
            string EncryptedReportWriterURL = System.Configuration.ConfigurationManager.AppSettings["ReportWriterURL"].ToString() + "?data=" + EncryptedQS.ToString();
            BindGridReports();
            //lnkReportWriter.NavigateUrl = EncryptedReportWriterURL;
            Page.ClientScript.RegisterClientScriptInclude("FromScript", "~/Script/Scripts.js");
            imgbtnReportWriter.Attributes.Add("onclick", "javascript:window.open('" + EncryptedReportWriterURL + "','_new')");
            reportsQuerystring = "orderbyField=" + Request.QueryString["orderbyField"].ToString() + "&SortType=" + Request.QueryString["SortType"].ToString() +
                "&Tag=" + Request.QueryString["Tag"].ToString() +
                "&SpecificAccount=" + Request.QueryString["SpecificAccount"].ToString() +
                "&FilterField=" + Request.QueryString["FilterField"].ToString() +
                "&LocationFilter=" + Request.QueryString["LocationFilter"].ToString() +
                "&SpecificLocation=" + Request.QueryString["SpecificLocation"].ToString();

            ViewState["reportsQuerystring"] = reportsQuerystring;
        }

        imgbtnReportWriter.Attributes.Add("onmouseover", "this.src='Images/ReportWriter-o.jpg'");
        imgbtnReportWriter.Attributes.Add("onmouseout", "this.src='Images/ReportWriter-n.jpg'");
        imgbtnReportWriter.Attributes.Add("onmousedown", "this.src='Images/ReportWriter-s.jpg'");
        //

        string CurrentPage = "Reports";
		  //ucUserTabs.CurrentPage = CurrentPage;
		  //ucUserTabs.btnAccountsEvent += new EventHandler(ucUserTabs_btnAccountsEvent);
		  //ucUserTabs.btnAccountListsEvent += new EventHandler(ucUserTabs_btnAccountListsEvent);
		  //ucUserTabs.btnContantsEvent += new EventHandler(ucUserTabs_btnContantsEvent);
		  //ucUserTabs.btnContactListsEvent += new EventHandler(ucUserTabs_btnContactListsEvent);
		  //ucUserTabs.btnManageApplicationEvent += new EventHandler(ucUserTabs_btnManageApplicationEvent);

    }

    private void ApplyHeaderGroup()
    {
        GridViewHelper gvHelper = new GridViewHelper(this.gvReports);
        gvHelper.RegisterGroup("ReportModule", true, true);
        gvHelper.GroupHeader += new GroupEvent(gvHelper_GroupHeader);
    }

    void gvHelper_GroupHeader(string groupName, object[] values, GridViewRow row)
    {
        row.CssClass = "HeaderGroupStyle";
    }

    protected void gvReports_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='none';";
        e.Row.Cells[1].Attributes["onmouseout"] = "this.style.textDecoration='none';";
    }

    protected void ucUserTabs_btnAccountsEvent(object sender, EventArgs e)
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
    
    void ucUserTabs_btnManageApplicationEvent(object sender, EventArgs e)
    {
        Response.Redirect("ManageApplication.aspx");
    }

    protected void imgbtnSignOut_Click(object sender, ImageClickEventArgs e)
    {
        SignOut();
    }
   
    //private void BindGridReports()
    //{
    //    // Intialize the reports dataview
    //    DataTable dt = new DataTable();
    //    dt.Columns.Add(new DataColumn("ReportID"));
    //    dt.Columns.Add(new DataColumn("ReportName"));
    //    dt.Columns.Add(new DataColumn("ReportType"));
    //    DataSet dsReports = new DataSet();

    //    #region Add Fixed Reports

    //    //// add DBuilt-In Report 1
    //    //DataRow row = dt.NewRow();
    //    //DataRow row1 = dt.NewRow();

    //    //row[0] = 1;
    //    //row[1] = "Built-In Report 1";
    //    //row[2] = 1;
    //    //dt.Rows.Add(row);
    //    //// add Built-In Report 2
    //    //row1[0] = 2;
    //    //row1[1] = "Built-In Report 2";
    //    //row1[2] = 1;
    //    //dt.Rows.Add(row1);

    //    #endregion

    //    #region Add Dynamic Reports
    //    wsReports.Reports wsReports = new wsReports.Reports();
    //    DataSet dsRW = new DataSet();

    //    if (SafeMerge(dsRW, wsReports.mAccessRightsReports("10", ((Office.DAL.SecurityUserLogin)(Session["UserData"])).UserID.ToString(), ViewState["IsAdmin"].ToString())))
    //    {

    //        foreach (DataRow rowRW in dsRW.Tables[0].Rows)
    //        {
    //            DataRow row2 = dt.NewRow();
    //            row2[0] = rowRW["REP_RepID"];
    //            row2[1] = rowRW["REP_RepName"];
    //            row2[2] = 2;
    //            dt.Rows.Add(row2);
    //        }

    //    }
    //    #endregion

    //    dsReports.Tables.Add(dt);
    //    DataView dvReports = new DataView();
    //    dvReports = dsReports.Tables[0].DefaultView;
    //    dvReports.Sort = "ReportName";
    //    if (dvReports.Count > 0)
    //    {
    //        gvReports.DataSource = dvReports;
    //        gvReports.DataBind();
    //    }
    //}

    private void BindGridReports()
    {
        // Intialize the reports dataview
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("ReportID"));
        dt.Columns.Add(new DataColumn("ReportName"));
        dt.Columns.Add(new DataColumn("ReportType"));
        dt.Columns.Add(new DataColumn("ReportModule"));
        dt.Columns.Add(new DataColumn("ReportDescription"));
        dt.Columns.Add(new DataColumn("REP_Creator"));
        dt.Columns.Add(new DataColumn("REP_RepDate"));
        dt.Columns.Add(new DataColumn("REP_RepRemarks"));
        DataSet dsReports = new DataSet();

        #region Add Fixed Reports

        //if (ApplicationID == "13")
        //{
        //    // add Details Screen Report
        //    DataRow row = dt.NewRow();
        //    DataRow row1 = dt.NewRow();

        //    row[0] = 1;
        //    row[1] = "Timming Report 1";
        //    row[2] = 1;
        //    dt.Rows.Add(row);
        //    // add SalesForecast - Quote -Summary Report
        //    row1[0] = 2;
        //    row1[1] = "Timming Report 2";
        //    row1[2] = 1;
        //    dt.Rows.Add(row1);
        //}

        #endregion

        #region Add Dynamic Reports
        wsReports.Reports wsReports = new wsReports.Reports();
        DataSet dsRW = new DataSet();
        if (SafeMerge(dsRW, wsReports.mAccessRightsReports("10", ((Office.DAL.SecurityUserLogin)(Session["UserData"])).UserID.ToString(), ViewState["IsAdmin"].ToString())))
        {

            foreach (DataRow rowRW in dsRW.Tables[0].Rows)
            {
                DataRow row2 = dt.NewRow();
                row2[0] = rowRW["REP_RepID"];
                row2[1] = rowRW["REP_RepName"];
                row2[2] = 2;
                row2[3] = rowRW["REP_Module"];
                row2[4] = rowRW["REP_RepDescription"];
                row2[5] = rowRW["REP_Creator"];
                row2[6] = rowRW["REP_RepDate"];
                row2[7] = rowRW["REP_RepRemarks"];
                dt.Rows.Add(row2);
            }

        }
        #endregion

        //
        dsReports.Tables.Add(dt);
        DataView dvReports = new DataView();
        dvReports = dsReports.Tables[0].DefaultView;
        Session["dvReports"] = dvReports;
        dvReports.Sort = "ReportName";
        try
        {
            gvReports.DataSource = dvReports;
            gvReports.DataBind();
        }
        catch (Exception)
        {


        }

    }



    protected void gvReports_SelectedIndexChanged(object sender, EventArgs e)
    {

        DataKey Key = gvReports.SelectedDataKey;
        ViewState["repID"] = Key["ReportID"].ToString();
        string repType = Key["ReportType"].ToString();
        if (repType == "1") // Fixed Reports
        {
            string strReportName = gvReports.SelectedRow.Cells[1].Text;
            switch (strReportName)
            {

                case "Built-In Report 1":
                    strReportPageName = "Reporting/Report1.aspx?";
                    break;
                case "Built-In Report 2":
                    strReportPageName = "Reporting/Report2.aspx?";
                    break;
            }

            System.Threading.ThreadStart RptStart = new System.Threading.ThreadStart(RunBuiltInReports);
            System.Threading.Thread RptThrd = new System.Threading.Thread(RptStart);
            RptThrd.Start();
        }
        else // Dynamic Reports
        {
            System.Threading.ThreadStart RptStart = new System.Threading.ThreadStart(RunDynamicReports);
            System.Threading.Thread RptThrd = new System.Threading.Thread(RptStart);
            RptThrd.Start();

        }
    }
    protected void gvReports_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //
            DateTime ReportDate = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "REP_RepDate", "{0:d}"));
            ((Label)(e.Row.FindControl("lblReportDate"))).Text = ReportDate.ToShortDateString();
            //
            //Employee objEmployee = new Employee();
            //int RepCreatorID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "REP_Creator"));
            //((Label)(e.Row.FindControl("lblReportCreator"))).Text = objEmployee.getReportCreatorName(RepCreatorID);
            //
            string RequestedBy = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "REP_RepRemarks"));
            ((Label)(e.Row.FindControl("lblReportCreator"))).Text = RequestedBy;
            //
            DataKey Key = gvReports.DataKeys[e.Row.RowIndex];
            string repID = Key["ReportID"].ToString();
            string repType = Key["ReportType"].ToString();
            HyperLink objlnk = (HyperLink)(e.Row.FindControl("lnkRun"));
            //
            string ApplicationID = "10";
            string EncryptedQSRepID = mEncryptQueryString(ApplicationID + "&IsAdmin=" + ViewState["IsAdmin"].ToString() + "&ContactID=" + IntContactID + "&repID=" + repID);
            string EncryptedReportWriterURLRepID = System.Configuration.ConfigurationManager.AppSettings["ReportWriterURL"].ToString() + "?data=" + EncryptedQSRepID.ToString();
            objlnk.NavigateUrl = EncryptedReportWriterURLRepID;
        }
    }

    //public string getReportCreatorName(int UserID)
    //{
    //    dsEmployee.dtEmployeeDataTable dt = Adapter.GetReportCreatorName(UserID);
    //    return dt.Rows[0]["Fullname"].ToString();
    //}

    private void RunBuiltInReports()
    {
        ClientScript.RegisterStartupScript(typeof(RunReport), "Open Window", "<script lang='javascript'>window.open('" + strReportPageName + ViewState["reportsQuerystring"].ToString() + "');</script>");
    }
    private void RunDynamicReports()
    {
        string EncryptedQSRepID = mEncryptQueryString("5&IsAdmin=" + ViewState["IsAdmin"].ToString() + "&ContactID=" + ((Office.DAL.SecurityUserLogin)(Session["UserData"])).UserID.ToString() + "&repID=" + ViewState["repID"].ToString() + "&" + ViewState["reportsQuerystring"].ToString());
        string EncryptedReportWriterURLRepID = System.Configuration.ConfigurationManager.AppSettings["ReportWriterURL"].ToString() + "?data=" + EncryptedQSRepID.ToString();
        ClientScript.RegisterStartupScript(typeof(RunReport), "Open Window", "<script lang='javascript'>window.open('" + EncryptedReportWriterURLRepID + "');</script>");
    }

    protected void gvReports_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataView dvReports = Session["dvReports"] as DataView;
        dvReports.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
        gvReports.DataSource = dvReports;
        
        gvReports.DataBind();
    }

    private string GetSortDirection(string column)
    {

        // By default, set the sort direction to ascending.
        string sortDirection = "DESC";

        // Retrieve the last column that was sorted.
        string sortExpression = ViewState["SortExpression"] as string;

        if (sortExpression != null)
        {
            // Check if the same column is being sorted.
            // Otherwise, the default value can be returned.
            if (sortExpression == column)
            {
                string lastDirection = ViewState["SortDirection"] as string;
                if ((lastDirection != null) && (lastDirection == "DESC"))
                {
                    sortDirection = "ASC";
                }
            }
        }

        // Save new values in ViewState.
        ViewState["SortDirection"] = sortDirection;
        ViewState["SortExpression"] = column;
        return sortDirection;
    }
}
