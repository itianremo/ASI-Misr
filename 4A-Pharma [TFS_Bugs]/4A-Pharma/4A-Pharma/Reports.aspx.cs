using System;
using System.Drawing;
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
    string reportsQuerystring = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        InitiateTransactionsControl();

        if (!IsPostBack)
        {
            if (CurrentUserInfo.IsAdminRank)
            {
                Session["IsAdmin"] = 1; // 1 for Admin 
            }
            else
            {
                Session["IsAdmin"] = 0; // 0 for Non Admin 
            }
            string EncryptedQS = mEncryptQueryString(System.Configuration.ConfigurationManager.AppSettings["ReportWriterAppID"].ToString().Trim() + "&IsAdmin=" + Session["IsAdmin"].ToString() + "&ContactID=" + CurrentUserInfo.EmpID.ToString());
            string EncryptedReportWriterURL = System.Configuration.ConfigurationManager.AppSettings["ReportWriterURL"].ToString() + "?data=" + EncryptedQS.ToString();
            BindGridReports();
            lnkReportWriter.NavigateUrl = EncryptedReportWriterURL;
            Session["reportsQuerystring"] = reportsQuerystring;
        }
    }

    private void BindGridReports()
    {
        wsReports.Reports wsReports = new wsReports.Reports();
        gvReports.DataSource = wsReports.mAccessRightsReports(System.Configuration.ConfigurationManager.AppSettings["ReportWriterAppID"].ToString().Trim(), "96", Session["IsAdmin"].ToString());
        gvReports.DataBind();
    }

    protected void gvReports_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            HyperLink hplReports = (HyperLink)e.Row.FindControl("hplReports");
            hplReports.NavigateUrl = RunDynamicReports(gvReports.DataKeys[e.Row.RowIndex].Values["REP_RepID"].ToString());
         
        }
    }

    private string RunDynamicReports(string RepID)
    {
        string EncryptedQSRepID = mEncryptQueryString(System.Configuration.ConfigurationManager.AppSettings["ReportWriterAppID"].ToString().Trim() + "&IsAdmin=1&ContactID=" + 96 + "&repID=" + RepID);
        string EncryptedReportWriterURLRepID = System.Configuration.ConfigurationManager.AppSettings["ReportWriterURL"].ToString() + "?data=" + EncryptedQSRepID.ToString();
        return EncryptedReportWriterURLRepID;
    }

    private void InitiateTransactionsControl()
    {
        TransButtons ucTransButtons = (TransButtons)Master.FindControl("ucTransButtons");
        ucTransButtons.CurrentPage = "Reports";
    }
  
}