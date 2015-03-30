using System;
using System.Drawing;
using ReportWriter;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Reports : Pharma.BMD.BLL.MasterClass
{
    ReportHandler repHnd = new ReportHandler();
    CommonMethods CommMethods = new CommonMethods();
    string sql;

    protected void Page_Load(object sender, EventArgs e)
    {
        InitiateTransactionsControl();
        if (!IsPostBack)
        {
            InitializeEasyQuery();
            txtREP_Project.Text = Session["VsApplicationID"].ToString();//*/"2";//projectID
            txtIsAdmin.Text = Session["IsAdmin"].ToString();//*/"1";//IsAdmin
            txtContactID.Text = Session["ContactID"].ToString();//*/"157";//ContactID
        }

        if (GridView_1.Rows.Count == 0)
        {
            tblErr.Rows[0].Cells[1].Text = "<ul><li>You don't have access rights to view any reports or there is no reports with current application.</li></ul>";
            tblErr.Visible = true;
            GridView_1.Visible = false;
        }
        else
        {
            tblErr.Visible = false;
            GridView_1.Visible = true;

            //Added By Fawzi
            if (!IsPostBack)
            {
                GridView_1.SelectedIndex = 0;
                GridView_1_SelectedIndexChanged(this.GridView_1, null);
            }
        }
    }

    private void InitializeEasyQuery()
    {
        string VsApplicationID;
        string VsConnectionString;
        string VsApplicationReportPath;

        //Session["IsAdmin"] = "1";
        //Session["ContactID"] = "450";
        //VsApplicationID = "2";
        Session["IsAdmin"] = "1";
        Session["ContactID"] = "98";
        VsApplicationID = "1";
        Session["VsApplicationID"] = VsApplicationID;

        HttpCookie applicattionCookie = new HttpCookie("VsApplicationIDCookie", VsApplicationID);
        applicattionCookie.Expires = DateTime.Now.AddHours(24);
        Response.Cookies.Add(applicattionCookie);

        // get current Directory of application
        string path = AppDomain.CurrentDomain.BaseDirectory;
        try
        {
            // get applications data
            ArrayList arr = repHnd.GetAllApplicationsInfo(this.Page);
            for (int i = 0; i < arr.Count; i++)
            {
                ReportWriter.ApplicationInfo appInfo = (ReportWriter.ApplicationInfo)arr[i];
                if (appInfo.ApplicationID == Session["VsApplicationID"].ToString())
                {
                    // set values of Report path and connection string into session
                    VsApplicationReportPath = Page.MapPath(appInfo.MRTFileName);
                    Session["VsApplicationReportPath"] = VsApplicationReportPath;
                    VsConnectionString = appInfo.ApplicationConnection;
                    Session["VsConnectionString"] = VsConnectionString;
                    Session["WSDSReportURL"] = appInfo.WSDSReportURL;
                    path += appInfo.DModelPass;
                    break;
                }
            }
        }
        catch (Exception ee)
        {
            ReportWriter.ReportHandler.ShowMessage("There are errors in this page: <br>" + ee.Message, this.Page);
            return;
        }
        // load data model of application        
        Korzh.EasyQuery.DataModel model = new Korzh.EasyQuery.DataModel();
        model.LoadFromFile(path);
        Session["DataModel"] = model;
        // set values to query properties
        Korzh.EasyQuery.Query query = new Korzh.EasyQuery.Query();
        query.Model = model;
        query.Formats.DateFormat = "MM/dd/yyyy";
        query.Formats.DateTimeFormat = "MM/dd/yyyy";//"yyyy-MM-dd hh:mm:ss";
        query.Formats.QuoteBool = false;
        query.Formats.FalseValue = "0";
        query.Formats.TrueValue = "1";
        query.Formats.QuoteTime = true;
        query.Formats.SqlQuote1 = '[';
        query.Formats.SqlQuote2 = ']';
        query.Formats.SqlSyntax = Korzh.EasyQuery.SqlSyntax.SQL2;
        query.Formats.OrderByStyle = Korzh.EasyQuery.OrderByStyles.Names;
        Session["Query"] = query;
    }

    private void InitiateTransactionsControl()
    {
        TransButtons ucTransButtons = (TransButtons)Master.FindControl("ucTransButtons");
        ucTransButtons.CurrentPage = "Reports";
    }

    protected void GridView_1_SelectedIndexChanged(object sender, EventArgs e)
    {

        ClearControls();
        resetColors();
        
        int VniReportID = Convert.ToInt32(((System.Web.UI.WebControls.GridView)sender).SelectedDataKey.Value.ToString());
        SetReportsData(VniReportID);
        
        ViewState["ReportID"] = VniReportID;
        ViewState["ReportName"] = TextBoxName.Text;
        Rep_ReportsTableAdapters.REP_ReportsTableAdapter repAdp = new Rep_ReportsTableAdapters.REP_ReportsTableAdapter();       
        Session["ReportInserted"] = null;

        string sql = repAdp.GetSQL(VniReportID).ToString();
        Session["VsSql"] = sql;

    }

    #region CheckUserSecurity
    /// <summary>
    /// this function check the user access right to the report
    /// </summary>
    bool CheckUserSecurity(int repID, string reportType)
    {
        bool accessRight = false;

        try
        {
            // determine user access right
            switch (reportType)
            {
                case "Admin":
                    if (Session["IsAdmin"] != null && int.Parse(Session["IsAdmin"].ToString()) == 1)
                        accessRight = true;
                    else
                        accessRight = false;
                    break;

                case "ALL":
                    accessRight = true;
                    break;

                case "Custom Users":
                    if (int.Parse(Session["IsAdmin"].ToString()) == 1)
                        accessRight = true;
                    else if (Session["ContactID"] != null)
                        accessRight = CheckReportUserExist(repID, int.Parse(Session["ContactID"].ToString()), 1);
                    break;
                default:
                    break;
            }
            return accessRight;
        }
        catch (Exception ee)
        {
            ReportHandler.ShowMessage("View Report: " + ee.Message, this.Page);
            return false;
        }
    }
    #endregion

    #region Check if user exist in ReportUsers

    bool CheckReportUserExist(int repID, int userId, int RoleID)
    {
        try
        {
            REP_ReportUsersTableAdapters.REP_ReportUsersTableAdapter repUsr = new REP_ReportUsersTableAdapters.REP_ReportUsersTableAdapter();
            // check if user is one of report users
            int count = (int)repUsr.FillByID(repID, userId, RoleID);
            if (count > 0)
                return true;
        }
        catch (Exception ee)
        {
            ReportHandler.ShowMessage("View Report: " + ee.Message, this.Page);
        }
        return false;
    }

    #endregion

    #region Download Report
    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        // download Access Rights
        GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent;

        Rep_ReportsTableAdapters.REP_ReportsTableAdapter repAdp = new Rep_ReportsTableAdapters.REP_ReportsTableAdapter();
        int ViRepID = Convert.ToInt32(GridView_1.DataKeys[row.RowIndex].Values[0]);
        Rep_Reports.REP_ReportsDataTable dbTable = repAdp.GetRepByID(ViRepID);
        bool IsValidDownLoad;

        if (dbTable[0]["REP_Creator"].ToString() == Session["ContactID"].ToString() || Session["IsAdmin"].ToString() == "1")
            IsValidDownLoad = true;
        else if (CheckReportUserExist(ViRepID, int.Parse(Session["ContactID"].ToString()), 2))
        {
            IsValidDownLoad = true;
        }
        else
            IsValidDownLoad = false;

        if (IsValidDownLoad)
            CommMethods.DownloadReport(ViRepID, this);
    }


    #endregion

    #region SetReportsData
    void SetReportsData(int reportID)
    {
        Rep_ReportsTableAdapters.REP_ReportsTableAdapter repAdp = new Rep_ReportsTableAdapters.REP_ReportsTableAdapter();
        Rep_Reports.REP_ReportsDataTable dbTable = repAdp.GetRepByID(reportID);
        TextBoxName.Text = dbTable[0].REP_RepName.ToString();
        TextBoxDesc.Text = dbTable[0].REP_RepDescription.ToString();
        ViewState["REP_Creator"] = dbTable[0]["REP_Creator"].ToString();        

        if (CheckReportUserExist(reportID, int.Parse(Session["ContactID"].ToString()), 2) == true || Session["IsAdmin"].ToString() == "1")
        {
            ButtonSaveReprt.Enabled = true;
        }
        else
        {
            ButtonSaveReprt.Enabled = false;
        }

        if (!dbTable[0].IsNull(dbTable[0].REP_RepType))
        {
            ViewState["REP_RepType"] = dbTable[0].REP_RepType.ToString();
        }

        ViewState["file"] = dbTable[0].REP_RepBlob;
    }
    #endregion

    #region Save Report
    protected void ButtonSaveReprt_Click(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["ReportID"] != null)
            {
                if (ValidateForm())
                {
                    Rep_ReportsTableAdapters.REP_ReportsTableAdapter RepAdp = new Rep_ReportsTableAdapters.REP_ReportsTableAdapter();
                    if (TextBoxName.Text != ViewState["ReportName"].ToString())
                    {
                        if (Convert.ToInt32(RepAdp.CheckRepeatedAppReport(Convert.ToString(Session["VsApplicationID"]), TextBoxName.Text)) != 0)
                        {
                            tblErr.Rows[0].Cells[1].Text = "This report name is already exist!";
                            tblErr.Visible = true;
                            return;
                        }
                    }

                    Stimulsoft.Report.StiReport CurrentReportDocument = new Stimulsoft.Report.StiReport();
                    ////////////////////Note Here-----------------------------
                    string str = FileUpload2.PostedFile.FileName;
                    if (FileUpload2.FileName != "")
                    {
                        CurrentReportDocument.Load(FileUpload2.FileBytes);
                    }
                    else
                    {
                        CurrentReportDocument.Load((byte[])ViewState["file"]);
                    }
                    sql = ((Stimulsoft.Report.Dictionary.StiSqlSource)(CurrentReportDocument.DataSources.Items[0])).SqlCommand;

                    int newID = Convert.ToInt32(RepAdp.Update(TextBoxName.Text, TextBoxDesc.Text, Session["VsApplicationID"].ToString(), "", CurrentReportDocument.SaveToByteArray(), sql, "", "", DateTime.Now, true, "", int.Parse(ViewState["REP_RepType"].ToString()), Convert.ToInt32(ViewState["REP_Creator"].ToString()), 3, Convert.ToInt32(ViewState["ReportID"].ToString())));
                    ViewState["ReportName"] = TextBoxName.Text;

                    if (newID > 0)
                    {
                        GridView_1.DataBind();
                    }

                }
            }
            else
            {
                tblErr.Rows[0].Cells[1].Text = "<ul><li>You should select a report to modify.</li></ul>";
                tblErr.Visible = true;
            }
        }
        catch (Exception ee)
        {
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "string", "<script language=javascript > alert ( '" + ee.Message + "' ) </script>");
        }
    }
    #endregion

    #region validate user inputs
    /// <summary>
    /// Validate form inputs before going to save or update
    /// </summary>
    /// <returns></returns>
    private bool ValidateForm()
    {
        string msg = "";
        resetColors();

        if (TextBoxName.Text.Trim() == "")
        {
            msg = msg + "<li> Report name Shouldn't be empty </li>";
            TextBoxName.BackColor = Color.LightYellow;
        }
        System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"[a-zA-Z0-9\p{IsArabic}_\s]");
        foreach (char c in TextBoxName.Text)
        {
            System.Text.RegularExpressions.Match match = reg.Match(c.ToString());
            if (!match.Success)
            {
                msg = msg + "<li> Report name must not have special characters </li>";
                TextBoxName.BackColor = Color.LightYellow;
            }
        }

        if (FileUpload2.FileName != "" && FileUpload2.FileName.Substring(FileUpload2.FileName.IndexOf('.')) != ".mrt")
        {
            Stimulsoft.Report.StiReport CurrentReportDocument = new Stimulsoft.Report.StiReport();
            try
            {
                CurrentReportDocument.Load(FileUpload2.FileBytes);
            }
            catch (Exception ee)
            {
                msg = ee.Message + "<br>" + msg + "<li> Please enter a valid stimulsoft report </li>";
                FileUpload2.BackColor = Color.LightYellow;
            }
        }


        if (msg != "")
        {
            msg = "<ul>" + msg + "</ul>";
            tblErr.Rows[0].Cells[1].Text = "<p><b>Please correct the entries highlighted with yellow </b></p>"
                                                + msg;
            tblErr.Visible = true;
            return false;
        }
        else
        {
            return true;
        }
    }
    #endregion

    #region reset control back colors to white
    private void resetColors()
    {
        TextBoxName.BackColor = Color.White;
        FileUpload2.BackColor = Color.White;
        tblErr.Visible = false;
    }
    #endregion

    #region Clear Controls
    private void ClearControls()
    {

        TextBoxName.Text = "";
        TextBoxDesc.Text = "";
        tblErr.Rows[0].Cells[1].Text = "";
        tblErr.Visible = false;
    }
    #endregion

    #region Run Report
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        // Run Access rights
        GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent;
        int VniReportID = Convert.ToInt32(GridView_1.DataKeys[row.RowIndex].Values[0]);
        bool accessRight = CheckUserSecurity(VniReportID, row.Cells[2].Text);
        Session["ReportInserted"] = null;
        if (accessRight)
        {
            Rep_ReportsTableAdapters.REP_ReportsTableAdapter repAdp = new Rep_ReportsTableAdapters.REP_ReportsTableAdapter();
            //ViewState["IsReportWriter"] = repAdp.IsReportWriter(VniReportID);
            sql = repAdp.GetSQL(VniReportID).ToString();
            Session["VsSql"] = sql;
            Session["FireFoxPostBack"] = "false";
            Response.Redirect("Query.aspx?Status=RunReport&RepID=" + VniReportID);
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "dsfssadsa", "<script>alert( 'You have not access right to view this report' )</script>");
        }




    }
    #endregion

    #region SqlDataSource1_Deleting
    protected void SqlDataSource1_Deleting(object sender, SqlDataSourceCommandEventArgs e)
    {
        if (Session["IsAdmin"].ToString() == "0")
        {
            e.Cancel = true;
            string msg = "<li> You have not access right to delete reports. </li>";
            msg = "<ul>" + msg + "</ul>";
            tblErr.Rows[0].Cells[1].Text = msg;
            tblErr.Visible = true;
        }
        else
        {
            e.Cancel = false;
            ClearControls();
        }
    }
    #endregion

    #region Gridview Row Created
    protected void GridView_1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["style"] = "cursor:hand";
            e.Row.Attributes["onclick"] = this.ClientScript.GetPostBackEventReference(GridView_1, "Select$" + e.Row.RowIndex.ToString());
        }
    }
    #endregion

    #region Gridview Page Index Changed
    protected void GridView_1_PageIndexChanged(object sender, EventArgs e)
    {
        resetColors();
        ClearControls();
    }
    #endregion

    protected void SqlDataSource1_Deleted(object sender, SqlDataSourceStatusEventArgs e)
    {
        GridView_1.DataBind();
        if (GridView_1.Rows.Count == 0)
        {
            tblErr.Rows[0].Cells[1].Text = "<ul><li>You don't have access rights to view any reports or there is no reports with current application.</li></ul>";
            tblErr.Visible = true;
            GridView_1.Visible = false;
        }
        else
        {
            tblErr.Visible = false;
            GridView_1.Visible = true;

            GridView_1.SelectedIndex = -1;
        }
    }

    protected void GridView_1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtnDelete = (LinkButton)e.Row.FindControl("lnkbtnDelete");
            lnkbtnDelete.Attributes["onclick"] = "javascript:return confirm('You are about to delete a report! continue...?')";
        }
    }
    protected void btnCreateReport_Click(object sender, EventArgs e)
    {
        if (txtCreateReportName.Text.Trim() != "")
        {
            Session["FireFoxPostBack"] = "false";
            Response.Redirect("Query.aspx?Status=NewReport&ReportName=" + txtCreateReportName.Text.Trim() + "");
        }
        else
        {
            lblVReportName.Visible = true;
        }
    }

    protected void lnkbtnModify_Click(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent;
        int VniReportID = Convert.ToInt32(GridView_1.DataKeys[row.RowIndex].Values[0]);
        Rep_ReportsTableAdapters.REP_ReportsTableAdapter repAdpt = new Rep_ReportsTableAdapters.REP_ReportsTableAdapter();
        Rep_Reports.REP_ReportsRow ReportRow = (Rep_Reports.REP_ReportsRow)repAdpt.GetRepByID(VniReportID).Rows[0];
        if (ReportRow["REP_Creator"].ToString() == Session["ContactID"].ToString() || CheckReportUserExist(VniReportID, int.Parse(Session["ContactID"].ToString()), 2) || Session["IsAdmin"].ToString() == "1")
        {
            Session["FireFoxPostBack"] = "false";
            Response.Redirect("Query.aspx?Status=ModifyReport&RepID=" + VniReportID);
        }
    }
    protected void lnkbtnDelete_Click(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent;
        int VniReportID = Convert.ToInt32(GridView_1.DataKeys[row.RowIndex].Values[0]);
        Rep_ReportsTableAdapters.REP_ReportsTableAdapter repAdpt = new Rep_ReportsTableAdapters.REP_ReportsTableAdapter();
        Rep_Reports.REP_ReportsRow ReportRow = (Rep_Reports.REP_ReportsRow)repAdpt.GetRepByID(VniReportID).Rows[0];
        if (ReportRow.REP_Creator.ToString() == Session["ContactID"].ToString() || Session["IsAdmin"].ToString() == "1")
        {
            repAdpt.DeleteReport(VniReportID);
            GridView_1.DataBind();
        }
        else
        {
            tblErr.Rows[0].Cells[1].Text = "<ul><li>You don't have access rights to delete selected report.</li></ul>";
            tblErr.Visible = true;
        }

    }
}