using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Xml;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Korzh.WebControls.XControls;
using Korzh.EasyQuery;
using ReportWriter;

public partial class QueryTestForm : Pharma.BMD.BLL.MasterClass
{
    private System.Data.SqlClient.SqlConnection DbConnection = null;
    Query.ConditionList condList = new Query.ConditionList();
    CommonMethods CommMethods = new CommonMethods();
    Query.ConditionList list = new Query.ConditionList();

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        InitiateTransactionsControl();
        string Status = Page.Request.QueryString.Get("Status").ToString();
        if (IsPostBack == false)
        {

            #region Check Access Right
            if (Session["IsAdmin"].ToString() != "1")
            {
                if (Status == "NewReport")
                {
                    dsApplicationsUsersTableAdapters.REP_ApplicationsXUsersRulesTableAdapter objAppUsers = new dsApplicationsUsersTableAdapters.REP_ApplicationsXUsersRulesTableAdapter();
                    if (Convert.ToInt32(objAppUsers.mCheckAppUserRule(int.Parse(Session["ContactID"].ToString()), 4, int.Parse(Session["VsApplicationID"].ToString()))) == 0)

                        Response.Redirect("../Login.aspx");
                }
            }
            #endregion

            #region Check Status
            if (Convert.ToString(Session["FireFoxPostBack"]) == "false")
            {
                QueryPanel1.Query.Clear();
                SqlTextBox.Text = "";
                ResultGrid.Columns.Clear();
                Session["FireFoxPostBack"] = "true";
                if (Status == "NewReport")
                {
                    if (Request.QueryString.Get("BackToQuery") == "Yes")
                    {
                        mLoadXMLFile();
                    }
                }               
                else if (Status == "ModifyReport")
                {
                    mLoadXMLFile();
                }
                else
                {
                    btnNext.Visible = false;
                    QueryPanel1.Query.Clear();
                    SqlTextBox.Text = "";
                    ResultGrid.Columns.Clear();
                }
            }
            #endregion
        }

       
        QueryPanel1.Query.ColumnsChanged += new Korzh.EasyQuery.ColumnsChangedEventHandler(query_ColumnsChanged);
        QueryPanel1.Query.ConditionsChanged += new Korzh.EasyQuery.ConditionsChangedEventHandler(query_ConditionsChanged);
        ErrorLabel.Visible = false;

    }
    #endregion
   
    private void InitiateTransactionsControl()
    {
        TransButtons ucTransButtons = (TransButtons)Master.FindControl("ucTransButtons");
        ucTransButtons.CurrentPage = "Reports";
    }

    #region Load columns and conditions from DB by xml string
    private void mLoadXMLFile()
    {
        string VsFileXMLText = "";
        if (Request.QueryString.Get("BackToQuery") == "Yes")
        {
            VsFileXMLText = Session["XMLQueryText"].ToString();
        }
        else
        {
            VsFileXMLText = mGetXMLFile(int.Parse(Request.QueryString.Get("RepID")));
        } 
       
       
        if (VsFileXMLText != "")
        {
            try
            {
                // Reload Columns and Conditions
                QueryPanel1.Query.LoadFromString(VsFileXMLText);
                //Load SQL
                Korzh.EasyQuery.Query query = (Korzh.EasyQuery.Query)Session["Query"];
                query.BuildSQL();
                SqlTextBox.Text = query.Result.SQL;
                //Load Conditions Text
                QueryTextFormats formats = new QueryTextFormats();
                formats.UseHtml = true;
                formats.UseMathSymbolsForOperators = true;
                Literal1.Text = query.GetConditionsText(formats);

                // QueryColumnsPanel1.Enabled = false;
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = "Error during loading: <br>" + ex.Message;
                ErrorLabel.Visible = true;
            }
        }
    }

    private string mGetXMLFile(int ReportID)
    {
        #region Get XML file Text to reload it in Query Builder Report
        Rep_ReportsTableAdapters.REP_ReportsTableAdapter RepAdp = new Rep_ReportsTableAdapters.REP_ReportsTableAdapter();
        string VsFileXMLText = RepAdp.GetFileXMLText(ReportID).ToString();
        return VsFileXMLText;
        #endregion
    } 
    #endregion

    #region Page Unload
    protected void Page_Unload(object sender, EventArgs e)
    {
        try
        {
            QueryPanel1.Query.ColumnsChanged -= new Korzh.EasyQuery.ColumnsChangedEventHandler(query_ColumnsChanged);
            QueryPanel1.Query.ConditionsChanged -= new Korzh.EasyQuery.ConditionsChangedEventHandler(query_ConditionsChanged);
        }
        catch { }
    }
    #endregion

    private string baseDataPath = null;

    #region Page Init
    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {

            baseDataPath = this.MapPath("./data");
            QueryPanel1.Model = (Korzh.EasyQuery.DataModel)Session["DataModel"];
            QueryPanel1.Query = (Korzh.EasyQuery.Query)Session["Query"];

            QueryColumnsPanel1.Model = QueryPanel1.Model;
            QueryColumnsPanel1.Query = QueryPanel1.Query;
            QueryColumnsPanel1.Appearance.AdditionRowColor = Color.Green;
        }
        catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
    } 
    #endregion

    #region Check Connection
    protected void CheckConnection()
    {
        if (DbConnection == null)
        {
            DbConnection = new SqlConnection();
            DbConnection.ConnectionString = Session["VsConnectionString"].ToString();
            DbConnection.Open();
        }
    } 
    #endregion

    #region Query Panel_SQLExecute
    protected void QueryPanel1_SqlExecute(object sender, Korzh.EasyQuery.WebControls.SqlExecuteEventArgs e)
    {
        try
        {
            CheckConnection();
            SqlDataAdapter resultDA = new SqlDataAdapter(e.SQL, DbConnection);

            DataSet tempDS = new DataSet();
            resultDA.Fill(tempDS, "Result");

            StringWriter strWriter = new StringWriter();
            tempDS.WriteXml(strWriter);
            e.ListItems.LoadFromXml(strWriter.ToString());
        }
        catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
    } 
    #endregion

    #region QueryPanel1_ListRequest
    protected void QueryPanel1_ListRequest(object sender, Korzh.EasyQuery.WebControls.ListRequestEventArgs e)
    {
        if (e.ListName == "ShipRegionList")
        {
            e.ListItems.Add("British Columbia", "BC");
            e.ListItems.Add("Colorado", "CO");
            e.ListItems.Add("Oregon", "OR");
            e.ListItems.Add("Washington", "WA");
        }
    } 
    #endregion

    #region query_ColumnsChanged
    protected void query_ColumnsChanged(object sender, Korzh.EasyQuery.ColumnsChangeEventArgs e)
    {
        UpdateSql();
    } 
    #endregion

    #region query_ConditionsChanged
    protected void query_ConditionsChanged(object sender, Korzh.EasyQuery.ConditionsChangeEventArgs e)
    {
        UpdateSql();
    } 
    #endregion

    #region UpdateSql
    protected void UpdateSql()
    {
        try
        {
            Korzh.EasyQuery.Query query = (Korzh.EasyQuery.Query)Session["Query"];           
            SqlTextBox.Text = string.Empty;
            Literal1.Text = string.Empty;

            if (query.Root.Conditions.Count > 0 || query.Result.Columns.Count > 0)
            {
                query.BuildSQL();
                SqlTextBox.Text = query.Result.SQL;
                QueryTextFormats formats = new QueryTextFormats();
                formats.UseHtml = true;
                formats.UseMathSymbolsForOperators = true;
                Literal1.Text = query.GetConditionsText(formats);
                ResultGrid.Visible = false;
                ResultLabel.Visible = false;
                ResultLabel.Text = "";
            }
        }
        catch(Exception ex)
        {
            ResultGrid.Visible = false;
            ResultLabel.Width = new Unit("100%");
            ResultLabel.Text = ex.Message+"<br>There is no relation between some of the selected entities";
            ResultLabel.Visible = true;
            SqlTextBox.Text = string.Empty;
            Literal1.Text = string.Empty;

        }
    } 
    #endregion

    #region UpdateResultBtn_Click
    protected void UpdateResultBtn_Click(object sender, EventArgs e)
    {
        Korzh.EasyQuery.Query query = (Korzh.EasyQuery.Query)Session["Query"];
        if (query.Result.Columns.Count > 0)
        {

            if (SqlTextBox.Text.StartsWith("SELECT", StringComparison.InvariantCultureIgnoreCase))
            { //we do not allow to execute statements other that SELECT
                try
                {
                    SqlDataAdapter daResult = new SqlDataAdapter(SqlTextBox.Text, Session["VsConnectionString"].ToString());
                    DataSet dsResult = new DataSet();
                    daResult.Fill(dsResult);
                    if (dsResult.Tables[0].Rows.Count > 1000)
                    {
                        ResultGrid.Visible = false;
                        ResultLabel.Width = new Unit("100%");
                        ResultLabel.Text = "Result set is too big";
                        ResultLabel.Visible = true;
                        return;
                    }


                    SqlResultDS.ConnectionString = Session["VsConnectionString"].ToString();
                    SqlResultDS.SelectCommand = SqlTextBox.Text;
                    SqlResultDS.Select(DataSourceSelectArguments.Empty);
                    ResultLabel.Visible = false;
                    ResultGrid.Visible = true;

                    foreach (DataColumn col in ResultGrid.Columns)
                    {
                        if (col.DataType.ToString()=="DateTime")
                        {
                        }
                    }
     
                    
                }
                catch (Exception ex)
                {
                    ResultGrid.Visible = false;
                    ResultLabel.Width = new Unit("100%");
                    ResultLabel.Text = "Error in SQL statement: <br>" + ex.Message;
                    ResultLabel.Visible = true;

                }
            }
        }
        else
        {
            ResultGrid.Visible = false;
            ResultLabel.Width = new Unit("100%");
            ResultLabel.Text = "there are no selected columns";
            ResultLabel.Visible = true;

        }
    } 
    #endregion

    #region QueryPanel1_CreateValueElement
    protected void QueryPanel1_CreateValueElement(object sender, Korzh.EasyQuery.WebControls.CreateValueElementEventArgs e)
    {
        // this method demonstrates an ability to change value elelements at run-time
        // for example in this case we change element from ListRowElement to EditRowElement if list of available values is too long

        if (e.ConditionRow.Condition is Query.SimpleCondition)
        {
            Expression baseExpr = ((Query.SimpleCondition)e.ConditionRow.Condition).BaseExpr;
            DataModel.EntityAttr attr = ((EntityAttrExpr)baseExpr).Attribute;
            if (attr.DefaultEditor is DataModel.SqlListValueEditor)
            {
                string sql = ((DataModel.SqlListValueEditor)attr.DefaultEditor).SQL;
                if (ResultSetIsTooBig(sql))
                { //or put your condition here
                    e.Element = new EditRowElement();
                }
            }
        }
    } 
    #endregion

    #region ResultSetIsTooBig
    private bool ResultSetIsTooBig(string sql)
    {
        CheckConnection();
        SqlDataAdapter resultDA = new SqlDataAdapter(sql, DbConnection);

        DataSet tempDS = new DataSet();
        resultDA.Fill(tempDS, "Result");
        return tempDS.Tables[0].Rows.Count > 150;
    } 
    #endregion


    #region btnNext_Click
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Korzh.EasyQuery.Query query = (Korzh.EasyQuery.Query)Session["Query"];
        if (query.Result.Columns.Count == 0)
        {
            ResultGrid.Visible = false;
            ResultLabel.Width = new Unit("100%");
            ResultLabel.Text = "there are no selected columns";
            ResultLabel.Visible = true;
            ErrorLabel.Visible = true;
            ErrorLabel.Text = "You must choose some columns to be shown in the report";
            return;

        }

        #region Check for repeated conditions

        foreach (Query.Condition cond in query.Root.Conditions)
        {
            Conditions(cond);
        }
        for (int i = 0; i < list.Count; i++)
        {
            Query.SimpleCondition i_Cond = (Query.SimpleCondition)list[i];
            for (int j = 0; j < list.Count; j++)
            {
                Query.SimpleCondition j_Cond = (Query.SimpleCondition)list[j];
                if (j == i)
                    continue;
                if (i_Cond.BaseExpr.Value == j_Cond.BaseExpr.Value)
                {
                    ErrorLabel.Visible = true;
                    ErrorLabel.Text = "'" + i_Cond.BaseExpr.Text + "'" + " is repeated, you must select unique conditions";
                    return;
                }
            }
        }
        #endregion

        #region Check if the user selected some columns
        if (SqlTextBox.Text == string.Empty)
        {
            Session["XMLQueryText"] = null;
            Session["QueryText"] = null;
            ErrorLabel.Visible = true;
            ErrorLabel.Text = "You must choose some columns to be shown in the report";
            return;

        }
        #endregion

        #region New Report
        else if (Request.QueryString.Get("Status").ToString() == "NewReport")
        {
            string QueryText = QueryPanel1.Query.SaveToString();
            Session["XMLQueryText"] = QueryText;
            Session["QueryText"] = SqlTextBox.Text;            // 
            #region Get Dump Report
            Stimulsoft.Report.StiReport CurrentReportDocument = CommMethods.GetDumpReport(Session["VsApplicationReportPath"].ToString(), SqlTextBox.Text);
            #endregion
            #region Insert Report
            int InsertedReportID = CommMethods.InsertReportQuery(Request.QueryString.Get("ReportName").Trim(), "", Session["VsApplicationID"].ToString(), "", CurrentReportDocument.SaveToByteArray(), SqlTextBox.Text, "", "", DateTime.Today.Date, true, "", 3, int.Parse(Session["ContactID"].ToString()), Session["XMLQueryText"].ToString(), 3, this);
            if (InsertedReportID == -1)
            {
                return;
            }
            #endregion
            #region Go To Reports.aspx
            Response.Redirect("Reports.aspx");
            #endregion
        }
        #endregion

        #region Modify Report
        else if (Request.QueryString.Get("Status").ToString() == "ModifyReport")
        {
            #region Modify SQL Statement and XML File to Report
            Rep_ReportsTableAdapters.REP_ReportsTableAdapter RepAdp = new Rep_ReportsTableAdapters.REP_ReportsTableAdapter();
            RepAdp.UpdateSQLXMLToReport(SqlTextBox.Text, QueryPanel1.Query.SaveToString(), int.Parse(Request.QueryString.Get("RepID")));
            #endregion

            #region Modify the sql statement of the physical stimulsoft report
            Stimulsoft.Report.StiReport CurrentReportDocument = new Stimulsoft.Report.StiReport();
            byte[] reportBytes = ((byte[])RepAdp.GetReportBytes(int.Parse(Request.QueryString.Get("RepID"))));
            CurrentReportDocument.Load(reportBytes);
            ((Stimulsoft.Report.Dictionary.StiSqlSource)(CurrentReportDocument.DataSources.Items[0])).SqlCommand = SqlTextBox.Text;
            RepAdp.UpdateReportBytes(CurrentReportDocument.SaveToByteArray(), int.Parse(Request.QueryString.Get("RepID")));
            #endregion

            #region Go To Reports.aspx
            Response.Redirect("Reports.aspx");
            #endregion

        }
        #endregion
    } 
    #endregion

    #region btnClear_Click
    protected void btnClear_Click(object sender, EventArgs e)
    {
        QueryPanel1.Query.Clear();
        SqlTextBox.Text = "";
        ResultGrid.Visible = false;
        ResultLabel.Width = new Unit("100%");
        ResultLabel.Text = string.Empty;
        ResultLabel.Visible = false;
        Literal1.Text = string.Empty;
    } 
    #endregion

    #region Get recursive conditions
    private void Conditions(Query.Condition cond)
    {
        if (cond is Query.SimpleCondition)
        {
            list.Add(cond);
        }
        else
        {
            foreach (Query.Condition c in ((Query.Predicate)cond).Conditions)
            {
                Conditions(c);
            }
        }
    } 
    #endregion
}


