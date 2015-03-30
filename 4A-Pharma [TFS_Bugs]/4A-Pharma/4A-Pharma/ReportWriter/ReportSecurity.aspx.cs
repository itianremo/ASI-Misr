using System;
using ReportWriter;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ReportModification : System.Web.UI.Page
{
    ReportWriter.ReportHandler repHnd = new ReportWriter.ReportHandler();

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IsAdmin"] == null || Session["IsAdmin"].ToString() != "1")
        {
            Response.Redirect("NotAuthorized.aspx");
        }
        MaintainScrollPositionOnPostBack = true;
        if (!IsPostBack)
        {
            ddlReports.DataBind();
            ddlSecurityType.DataBind();
            if (ddlReports.Items.Count == 0)
            {
                ddlReports.Enabled = false;
                ddlSecurityType.Enabled = false;
                ButtonSaveReprt.Enabled = false;
            }
            else
            {
                ddlReports_SelectedIndexChanged(null, null);
            }
            BingAppSecurity();
        }
        
    } 
    #endregion

    #region Applications DropDownList Initialization
    protected void ddlApplications_Init(object sender, EventArgs e)
    {
        try
        {
            ArrayList arr = repHnd.GetAllApplicationsInfo(this.Page);
            ddlApplications.Items.Add(new ListItem("-- Select Application --", "-1"));
            for (int i = 0; i < arr.Count; i++)
            {
                ReportWriter.ApplicationInfo appInfo = (ReportWriter.ApplicationInfo)arr[i];
                ddlApplications.Items.Add(new ListItem(appInfo.ApplicationName, appInfo.ApplicationID));
            }
            ddlApplications.SelectedValue = Session["VsApplicationID"].ToString();
            ddlApplications.Enabled = false;
            lblApplicationName.Text = ddlApplications.SelectedItem.Text;
        }
        catch (Exception ee)
        {
            ReportHandler.ShowMessage("Report Modification: " + ee.Message, this.Page);
        }
    } 
    #endregion

    #region Security/Report Type DropDownList Selected Index Changed
    protected void ddlSecurityType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            #region If Report Type is Custom Report Get Report Users Rules
            if (ddlSecurityType.SelectedValue == "3")
            {
                if (ddlApplications.SelectedValue != "-1")
                {
                    #region Get Application Users
                    ReportWriter.ApplicationInfo appInfo = (ReportWriter.ApplicationInfo)repHnd.GetApplicationInfo(ddlApplications.SelectedValue, this.Page);
                    System.Data.SqlClient.SqlDataAdapter daUsers = new System.Data.SqlClient.SqlDataAdapter(appInfo.UsersQuery, new System.Data.SqlClient.SqlConnection(appInfo.ApplicationConnection));
                    DataTable dtUsers = new DataTable();
                    daUsers.Fill(dtUsers);
                    DataColumn dcView = new DataColumn("View", typeof(bool));
                    DataColumn dcModify = new DataColumn("Modify", typeof(bool));
                    dcView.DefaultValue = false;
                    dcModify.DefaultValue = false;
                    dtUsers.Columns.Add(dcView);
                    dtUsers.Columns.Add(dcModify);
                    #endregion

                    #region Get Report Users Rules
                    REP_ReportUsersTableAdapters.REP_ReportUsersTableAdapter reportUsers = new REP_ReportUsersTableAdapters.REP_ReportUsersTableAdapter();
                    DataTable dtReportUsersRules = reportUsers.GetReportUsersRules(Convert.ToInt32(ddlReports.SelectedValue), Convert.ToString(Session["VsApplicationID"]));

                    #endregion

                    #region Set Report Users View And Modify Rules
                    foreach (DataRow dr in dtUsers.Rows)
                    {
                        DataRow[] dr2 = dtReportUsersRules.Select("REP_RepID='" + ddlReports.SelectedValue + "' AND ContactID='" + dr["UserID"] + "'");
                        foreach (DataRow dr3 in dr2)
                        {
                            if (dr3["RoleID"].ToString() == "1")
                            {
                                dr["View"] = true;
                            }
                            else if (dr3["RoleID"].ToString() == "2")
                            {
                                dr["Modify"] = true;
                            }
                        }
                    }
                    #endregion

                    divSaveReport.Style.Add(HtmlTextWriterStyle.Height, "25px");
                    GridView1.DataSource = dtUsers;
                    GridView1.DataBind();
                }
                DivReportRights.Visible = true;
                divSaveReport.Visible = true;
                GridView1.Visible = true;
            }
            else
            {
                GridView1.Visible = false;
                DivReportRights.Visible = false;
            }
            #endregion
        }
        catch (Exception ee)
        {
            ReportHandler.ShowMessage("Report Modification: " + ee.Message, this.Page);
        }
    } 
    #endregion

    #region Report Users Rules Save Button
    protected void ButtonSaveReprt_Click(object sender, EventArgs e)
    {
        #region Update Report Type
        Rep_ReportsTableAdapters.REP_ReportsTableAdapter Reports = new Rep_ReportsTableAdapters.REP_ReportsTableAdapter();
        Reports.UpdateReportType(Convert.ToInt32(ddlSecurityType.SelectedValue), Convert.ToInt32(ddlReports.SelectedValue)); 
        #endregion

        #region Delete Report Users Rules
        REP_ReportUsersTableAdapters.REP_ReportUsersTableAdapter reportUsers = new REP_ReportUsersTableAdapters.REP_ReportUsersTableAdapter();
        reportUsers.DeleteByReportID(Convert.ToInt32(ddlReports.SelectedValue)); 
        #endregion

        #region If Report Type is Custom Report(3) Insert Report Users Rules
        if (ddlSecurityType.SelectedValue == "3")
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chkView = ((CheckBox)row.Cells[2].Controls[1]);
                CheckBox chkModify = ((CheckBox)row.Cells[3].Controls[1]);

                //Get User(Contact) ID
                int contactID = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values[0]);

                //User Can View Only:
                if (chkView.Checked && !chkModify.Checked)
                {
                    reportUsers.InsertReportUsersRules(Convert.ToInt32(ddlReports.SelectedValue), contactID, 1);
                }
                //User Can Modify Only:
                else if (!chkView.Checked && chkModify.Checked)
                {
                    reportUsers.InsertReportUsersRules(Convert.ToInt32(ddlReports.SelectedValue), contactID, 1);
                    reportUsers.InsertReportUsersRules(Convert.ToInt32(ddlReports.SelectedValue), contactID, 2);
                }
                //User Can View And Modify:
                else if (chkView.Checked && chkModify.Checked)
                {
                    reportUsers.InsertReportUsersRules(Convert.ToInt32(ddlReports.SelectedValue), contactID, 1);
                    reportUsers.InsertReportUsersRules(Convert.ToInt32(ddlReports.SelectedValue), contactID, 2);
                }
            }
            ddlSecurityType_SelectedIndexChanged(null, null);
        }        
        #endregion
    } 
    #endregion

    #region Expand And Load Application Access Rights
    protected void BingAppSecurity()
    {

        #region Get Application Users
        ReportWriter.ApplicationInfo appInfo = (ReportWriter.ApplicationInfo)repHnd.GetApplicationInfo(ddlApplications.SelectedValue, this.Page);
        System.Data.SqlClient.SqlDataAdapter daUsers = new System.Data.SqlClient.SqlDataAdapter(appInfo.UsersQuery, new System.Data.SqlClient.SqlConnection(appInfo.ApplicationConnection));
        DataTable dtUsers = new DataTable();
        daUsers.Fill(dtUsers);
        DataColumn dcCreateReport = new DataColumn("CreateNewReport", typeof(bool));

        dcCreateReport.DefaultValue = false;        

        dtUsers.Columns.Add(dcCreateReport); 
        
        #endregion

        #region Get Application Users Rules
        dsApplicationsUsersTableAdapters.REP_ApplicationsXUsersRulesTableAdapter appUsers = new dsApplicationsUsersTableAdapters.REP_ApplicationsXUsersRulesTableAdapter();
        DataTable dtApplicationUsersRules = appUsers.GetAllByAppID(Convert.ToInt32(Session["VsApplicationID"])); 
        #endregion

        #region Set Application Users Rules For Each User
        foreach (DataRow dr in dtUsers.Rows)
        {
            DataRow[] dr2 = dtApplicationUsersRules.Select("App_ID='" + ddlApplications.SelectedValue + "' AND ContactID='" + dr["UserID"] + "'");
            foreach (DataRow dr3 in dr2)
            {
                if (dr3["RoleID"].ToString() == "4")
                {
                    dr["CreateNewReport"] = true;
                }
            }
        } 
        #endregion

        GridView2.DataSource = dtUsers;
        GridView2.DataBind();
    } 
    #endregion

    #region Application Users Rules Save Button
    protected void btnSaveGeneralRules_Click(object sender, EventArgs e)
    {
        dsApplicationsUsersTableAdapters.REP_ApplicationsXUsersRulesTableAdapter appUsers = new dsApplicationsUsersTableAdapters.REP_ApplicationsXUsersRulesTableAdapter();
        //Delete All Application Users Rules:
        appUsers.DeleteAllByApplicationID(Convert.ToInt32(Session["VsApplicationID"]));
        foreach (GridViewRow row in GridView2.Rows)
        {
            CheckBox chkCreateReport = ((CheckBox)row.Cells[2].Controls[1]);

            int contactID = Convert.ToInt32(GridView2.DataKeys[row.RowIndex].Values[0]);

            if (chkCreateReport.Checked)
            {
                appUsers.Insert(contactID, 4, Convert.ToInt32(Session["VsApplicationID"]));
            }          
        }
    } 
    #endregion

    #region Reports DropDownList Selected Index Changed(Get Report Type)
    protected void ddlReports_SelectedIndexChanged(object sender, EventArgs e)
    {
        Rep_ReportsTableAdapters.REP_ReportsTableAdapter Reports = new Rep_ReportsTableAdapters.REP_ReportsTableAdapter();
        ddlSecurityType.SelectedValue = Convert.ToString(Reports.GetReportType(Convert.ToInt32(ddlReports.SelectedValue)));
        ddlSecurityType_SelectedIndexChanged(null, null);
    } 
    #endregion
    
}