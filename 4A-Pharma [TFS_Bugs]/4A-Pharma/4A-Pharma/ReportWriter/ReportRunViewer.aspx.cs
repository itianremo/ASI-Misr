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
using ReportWriter;


public partial class Reporting_ReportRunViewer : System.Web.UI.Page
{
    CommonMethods CommMethods = new CommonMethods();
    private int GetParameterIndex(int index,ArrayList arrListConditions)
    {
        for (int i = 0; i < arrListConditions.Count; i++)
        {
            if (((myParameter)arrListConditions[i]).ConditionIndex == index.ToString())
                return i;
        }

        return 0;
    }



    protected void Page_Load(object sender, EventArgs e)
    {
       // if (!IsPostBack)
        {
            try
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);

                ReportHandler repHnd = new ReportHandler();
                if (id != 0)
                {
                    // intialize GA_ReportsTableAdapters object
                    Rep_ReportsTableAdapters.REP_ReportsTableAdapter gaAdpt = new Rep_ReportsTableAdapters.REP_ReportsTableAdapter();

                    // intialize GA_ReportsDataTable object
                    Rep_Reports.REP_ReportsDataTable db = new Rep_Reports.REP_ReportsDataTable();

                    // Call GetRepByID function
                    db = gaAdpt.GetRepByID(id);

                    // load report
                    byte[] rep = (byte[])db.Rows[0]["REP_RepBlob"];
                    ViewState["Report"] = rep;

                    // get report
                    rep = (byte[])ViewState["Report"];
                    Stimulsoft.Report.StiReport CurrentReportDocument = new Stimulsoft.Report.StiReport();
                    CurrentReportDocument.Load(rep);
                    string RepName = CurrentReportDocument.ReportName.Replace(" ", "_");
                    CurrentReportDocument.ReportName = RepName;


                    // Get SQL command from report
                    //string sql =((Stimulsoft.Report.Dictionary.StiSqlSource)(CurrentReportDocument.DataSources.Items[0])).SqlCommand;



                    // set connection string to  Session["Connection"]
                    if (db.Rows[0]["REP_Project"].ToString() != "")
                    {
                        ApplicationInfo appInfo = repHnd.GetApplicationInfo(db.Rows[0]["REP_Project"].ToString(), this.Page); ;
                        if (appInfo.ApplicationConnection != "")
                            Session["Connection"] = appInfo.ApplicationConnection;
                    }


                    //// stimulsoft report
                    //if (Request.QueryString.Get("ReportType") == "StimulSoft")// "Stimul")
                    //{
                    //    ((Stimulsoft.Report.Dictionary.StiSqlDatabase)(CurrentReportDocument.DataSources.Items[0].Dictionary.Databases[0])).ConnectionString = Session["Connection"].ToString();

                    //    if (CurrentReportDocument.DataSources[0].Parameters.Count > 0)
                    //    {
                    //        ArrayList arrListConditions = (ArrayList)Session["arrListConditions"];

                    //        for (int i = 0; i < arrListConditions.Count; i++)
                    //        {
                    //            string VsParameterName = ((myParameter)arrListConditions[GetParameterIndex(i, arrListConditions)]).ColumnName;
                    //            string VsParameterValue = ((myParameter)arrListConditions[GetParameterIndex(i, arrListConditions)]).ConditionValue1;
                    //            CurrentReportDocument.DataSources[0].Parameters[VsParameterName.ToString().Trim().Replace("@", "")].Value = VsParameterValue;
                    //        }
                    //    }
                    //    //Stimulsoft.Report.Web.StiReportResponse.ResponseAsPdf(this, CurrentReportDocument);
                    //    StiWebViewer1.Report = CurrentReportDocument;
                    //   // Stimulsoft.Report.Web.StiReportResponse.ResponseAsPdf(this, CurrentReportDocument, true);
                    //    return;
                    //}
                    // // stimulsoft report
                    //else if (Request.QueryString.Get("ReportType") == "DataSetReport")// "ds")
                    //{
                    //    // 123456

                    //    DataSet dataSet = CommMethods.GetDataSetForReport(Session["VsApplicationID"].ToString(), Session["VsSql"].ToString().Trim().Replace("'",""));

                    //    if (dataSet == null || dataSet.Tables.Count == 0)
                    //    {
                    //        Response.Write("may be this Application didn't has WebServices to deal with DataSet Report or the data of function is not true");
                    //        return;
                    //    }
                       
                    //    CurrentReportDocument.RegData("set", dataSet);
                    //    StiWebViewer1.Report = CurrentReportDocument;
                    //    StiWebViewer1.Visible = true;
                    //}

                    //        // Custom Report
                    //else
                    {

                        //System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(Session["VsSql"].ToString(), Session["Connection"].ToString());
                        //DataSet ds = new DataSet();
                        //da.Fill(ds);
                        ((Stimulsoft.Report.Dictionary.StiSqlDatabase)(CurrentReportDocument.DataSources.Items[0].Dictionary.Databases[0])).ConnectionString = Session["Connection"].ToString();
                        ((Stimulsoft.Report.Dictionary.StiSqlSource)(CurrentReportDocument.DataSources.Items[0])).SqlCommand = Session["VsSql"].ToString();
                        //CurrentReportDocument.RegData(ds);
                        StiWebViewer1.Report = CurrentReportDocument;
                    }

                }
            }
            catch (Exception ee)
            {
               
                ReportHandler.ShowMessage("Report Run: " + ee.Message.Replace("'", " "), this.Page);
            }
        }
    }
}

#region My Parameter Class
//public class myParameter1
//{
//    public string ColumnName, ColumnAlias, ColumnType, ConditionOperator, ConditionOperatorSymbol, ConditionValue1, ConditionValue2, SQL, Level, Index, ID, Linking, ListItems, AppliedOperations, ConditionIndex;
//    public myParameter1(string columnName, string columnAlias, string columnType, string conditionOperator, string conditionoperatorsymbol, string conditionValue1, string conditionValue2, string sql, string level, string index, string id, string linking, string listitems, string appliedoperations, string conditionindex)
//    {
//        this.ColumnName = columnName;
//        this.ColumnAlias = columnAlias;
//        this.ColumnType = columnType;
//        this.ConditionOperator = conditionOperator;
//        this.ConditionValue1 = conditionValue1;
//        this.ConditionValue2 = conditionValue2;
//        this.SQL = sql;
//        this.Level = level;
//        this.Linking = linking;
//        this.Index = index;
//        this.ID = id;
//        this.ListItems = listitems;
//        this.AppliedOperations = appliedoperations; ;
//        this.ConditionOperatorSymbol = conditionoperatorsymbol;
//        this.ConditionIndex = conditionindex;
//    }
//    public myParameter1()
//    {
//    }
//}
#endregion
