using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
////////////////////using ReportWriter;

namespace ReportWriter
{
    /// <summary>
    /// Summary description for CommonMethods
    /// </summary>
    public class CommonMethods : System.Web.UI.Page
    {
        DataSet dataSet;
        public CommonMethods()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Get Dump Report
        public Stimulsoft.Report.StiReport GetDumpReport(string ReportPath, string QueryText)
        {

            Stimulsoft.Report.StiReport CurrentReportDocument = new Stimulsoft.Report.StiReport();
            CurrentReportDocument.Load(ReportPath);
            ((Stimulsoft.Report.Dictionary.StiSqlSource)(CurrentReportDocument.DataSources.Items[0])).SqlCommand = QueryText;
            return CurrentReportDocument;
        }
        #endregion

        #region Insert Report Query
        public int InsertReportQuery(string ReportName, string Desc, string AppID, string Module, byte[] ReportBytes, string SQL, string Where, string Sort, DateTime Date, bool IsActive, string Remarks, int RepType, int RepCreator, string XMLText, int IsReportWriter, Page SenderPage)
        {
            Rep_ReportsTableAdapters.REP_ReportsTableAdapter RepAdp = new Rep_ReportsTableAdapters.REP_ReportsTableAdapter();
            REP_ReportUsersTableAdapters.REP_ReportUsersTableAdapter reportUsers = new REP_ReportUsersTableAdapters.REP_ReportUsersTableAdapter();

            #region Check if report name is repeated
            if (Convert.ToInt32(RepAdp.CheckRepeatedAppReport(AppID, ReportName)) != 0)
            {
                SenderPage.ClientScript.RegisterStartupScript(SenderPage.GetType(), "fdtttttttsf", "<script>alert('This report name is already assigned to current application.')</script>");
                return -1;
            }
            #endregion

            #region Insert Report
            RepAdp.InsertReportQuery(ReportName, Desc, AppID, Module, ReportBytes, SQL, Where, Sort, Date, IsActive, Remarks, RepType, RepCreator, XMLText, IsReportWriter);
            #endregion

            #region Insert Report User Rights
            int ReportID = Convert.ToInt32(RepAdp.GetReportID(AppID, ReportName));
            reportUsers.InsertReportUsersRules(ReportID, RepCreator, 1);
            reportUsers.InsertReportUsersRules(ReportID, RepCreator, 2);
            #endregion

            return ReportID;
        }
        #endregion

        #region Update Report Describtion
        public void UpdateNotes(string Notes, int ReportID)
        {
            Rep_ReportsTableAdapters.REP_ReportsTableAdapter RepAdp = new Rep_ReportsTableAdapters.REP_ReportsTableAdapter();
            RepAdp.UpdateReportDescription(Notes, ReportID);
        }
        #endregion

        #region Update Report SQL and XML
        public void UpdateSQLXMLToReport(string SQL, string XML, int ReportID)
        {
            Rep_ReportsTableAdapters.REP_ReportsTableAdapter RepAdp = new Rep_ReportsTableAdapters.REP_ReportsTableAdapter();
            RepAdp.UpdateSQLXMLToReport(SQL, XML, ReportID);
        }
        #endregion    

        #region Get report details by report ID
        public Rep_Reports.REP_ReportsDataTable GetReportDataByID(int ReportID)
        {
            Rep_ReportsTableAdapters.REP_ReportsTableAdapter RepAdp = new Rep_ReportsTableAdapters.REP_ReportsTableAdapter();
            return RepAdp.GetRepByID(ReportID);
        }
        #endregion

        #region Download Report
        public void DownloadReport(int reportID, System.Web.UI.Page SenderPage)
        {
            Rep_ReportsTableAdapters.REP_ReportsTableAdapter repAdp = new Rep_ReportsTableAdapters.REP_ReportsTableAdapter();
            Rep_Reports.REP_ReportsDataTable dbTable = repAdp.GetRepByID(reportID);
            bool IsValidDownLoad;

            if (dbTable[0]["REP_Creator"].ToString() == SenderPage.Session["ContactID"].ToString() || SenderPage.Session["IsAdmin"].ToString() == "1")
            {
                IsValidDownLoad = true;
            }
            else if (CheckReportUserExist(reportID, int.Parse(SenderPage.Session["ContactID"].ToString()), 2, SenderPage))
            {
                IsValidDownLoad = true;
            }
            else
            {
                IsValidDownLoad = false;
            }

            if (IsValidDownLoad)
            {
                ReportWriter.ReportHandler repHnd = new ReportWriter.ReportHandler();

                try
                {
                    if (reportID != 0)
                    {
                        // intialize REP_ReportsTableAdapters object
                        Rep_ReportsTableAdapters.REP_ReportsTableAdapter repAdpt = new Rep_ReportsTableAdapters.REP_ReportsTableAdapter();

                        // intialize REP_ReportsDataTable object
                        Rep_Reports.REP_ReportsDataTable db = new Rep_Reports.REP_ReportsDataTable();

                        // Call GetRepByID function
                        db = repAdpt.GetRepByID(reportID);

                        // load report
                        byte[] rep = (byte[])db.Rows[0]["REP_RepBlob"];
                        Stimulsoft.Report.StiReport CurrentReportDocument = new Stimulsoft.Report.StiReport();
                        CurrentReportDocument.Load(rep);
                        SenderPage.Response.AddHeader("Content-Disposition", "attachment;filename=" + db.Rows[0]["REP_RepName"].ToString() + ".mrt");
                        SenderPage.Response.AddHeader("Content-Length", rep.Length.ToString());
                        SenderPage.Response.ContentType = "application/octet-stream";
                        SenderPage.Response.Buffer = true;

                        //Displaying a dialog that will ask user to open file or even to download it locally on hard disk
                        SenderPage.Response.BinaryWrite(rep);

                        //Flushing all data after downloading it
                        SenderPage.Response.Flush();
                        SenderPage.Response.Close();
                        SenderPage.Response.End();

                    }
                }
                catch (Exception ee)
                {
                    ReportHandler.ShowMessage("Download Report: " + ee.Message, SenderPage);
                }
            }
        }
        #endregion

        #region Check if user exist in ReportUsers
        bool CheckReportUserExist(int repID, int userId, int RoleID, System.Web.UI.Page SenderPage)
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
                ReportHandler.ShowMessage("View Report: " + ee.Message, SenderPage);
            }
            return false;
        }
        #endregion

        #region Check for special characters
        public bool CheckSpecial(string str)
        {
            if (str.Contains("!") || str.Contains("@") || str.Contains("#") || str.Contains("$") || 
                str.Contains("%") || str.Contains("^") || str.Contains("&") || str.Contains("*") || 
                str.Contains("(") || str.Contains(")") || str.Contains("\\") || str.Contains("/") || 
                str.Contains("?") || str.Contains("<") || str.Contains(">") || str.Contains("~") || 
                str.Contains(":") || str.Contains("'") || str.Contains("\"") || str.Contains(";") || 
                str.Contains(",") || str.Contains("+") || str.Contains("-") || str.Contains("|") || 
                str.Contains("{") || str.Contains("}") || str.Contains("[") || str.Contains("]"))
                return false;
            else
                return true;
        }
        #endregion
    }
}
