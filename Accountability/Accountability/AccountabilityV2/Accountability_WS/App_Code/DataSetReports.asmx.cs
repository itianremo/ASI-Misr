using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using TSN.ERP.Presentation;
using System.Data.SqlClient;
using TSN.ERP.XML;
using System.Globalization;
using System.Threading;

namespace AccountabilityWS
{
	/// <summary>
	/// Summary description for CommonMethod.
	/// </summary>
	public class CommonMethod : ERPMasterService
	{
		public TSN.ERP.Presentation.AuthHeader authHeader = new TSN.ERP.Presentation.AuthHeader();
		string Token;
        //SqlConnection con = new SqlConnection(/*System.Configuration.ConfigurationManager.ConnectionStrings["AccountabilityConnectionString"].ToString()*/);
        SqlConnection con = new SqlConnection();
      
        
		public CommonMethod()
		{
            con.ConnectionString = ConnectionString();  
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();

             
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

     
        private string ConnectionString()
        {
           //return con.ConnectionString;
            //		ConnectionString()	"Provider=SQLOLEDB;Persist Security Info=True;Data Source=MISServer;Initial Catalog=TestAccountability_Data;Password= RW ;User ID=RW;"	string

           string x= TSN.ERP.Engine.Server.ServerSettings.GetConnectionFile();
           TSN.ERP.XML.ConnFileLoader xx = new ConnFileLoader();
          string tt= xx.GetDefaultUserConn(x);
          return tt.Replace("Provider=SQLOLEDB;", " ");
        }

		
		[WebMethod]
		public DataSet CallSpecificFunction(string FunctionData)
		{
			DataSet ds;
			

			try
			{
				string[] parameter = FunctionData.Split(',');
				string funName = parameter[0].Trim();
				//Token=parameter[1].Trim();
				switch (funName)
				{
						// ToDo: Add your funcyion declarations here
					case "Function1":
						ds = Function1(parameter[1].Trim(), parameter[2].Trim());
						break;
					case "GetTotalAccSheet":
						ds = GetTotalAccSheet(Convert.ToDateTime(parameter[1].Trim()), parameter[2].Trim());
						break;
					case "Test":
						ds = Test(parameter[1].Trim());
                        
						break;
                    case "AccountabilityDetailsReport":
                        ds = AccountabilityDetailsReport(parameter[1].Trim(), parameter[2].Trim(), parameter[3].Trim());
                        break;
                    case "AccountabilityTimingReportASIE":
                        ds = AccountabilityTimingReportASIE(parameter[1].Trim(), parameter[2].Trim());
                        break;
                    case "AccountabilityTimingReportASIE_ForEmployee":
                        ds = AccountabilityTimingReportASIE_ForEmployee(parameter[1].Trim(), parameter[2].Trim());
                        break;
                    case "AccountabilityTimingReportASIUS_ForEmployee":
                        ds = AccountabilityTimingReportASIUS_ForEmployee(parameter[1].Trim(), parameter[2].Trim());
                        break;
                        
                    case "connTest":
                        ds = conntest();
                        break;

					default:
						ds = null;
						break;
				}
			}
			catch
			{

				return null;
			}
			return ds;

		}

        [WebMethod]// please don't delete this method
		private DataSet Test(string param1)
		{
			DataSet dataSet1 = new DataSet();
            
            
			// create table
			DataTable table2 = new DataTable("Welcome");

			table2.Columns.Add();
			table2.Columns.Add();
			table2.Columns.Add();

			DataRow row10 = table2.NewRow();
			DataRow row20 = table2.NewRow();
			DataRow row30 = table2.NewRow();

			row10.ItemArray = new string[3] { "1", "Report Writer", "done" };
			row20.ItemArray = new string[3] { "2", "Accountability", "done" };
			row30.ItemArray = new string[3] { "3", "you entered", param1 };

			table2.Rows.Add(row10);
			table2.Rows.Add(row20);
			table2.Rows.Add(row30);
			dataSet1.Tables.Add(table2);
			return dataSet1;
		}

        [WebMethod]// please don't delete this method
        private DataSet conntest()
        {

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add();
            DataRow row = dt.NewRow();
            row[0] = "new ";
            dt.Rows.Add(row);

            ds.Tables.Add(dt);
            return ds;



        }

		[WebMethod]
		private DataSet Function1(string param1, string param2)
		{
			DataSet Ds = new DataSet(); // fill it with data
			return Ds;

		}
        [WebMethod]// please don't delete this method
        private DataSet AccountabilityTimingReportASIE(string contactID, string WeeklyStartDate)
        {
          
            string TK="";
            //AccountabilityWS.AccountabilityService AccServ = new AccountabilityService();
            //AccountabilityWS.AuthHeader authHeder = new AccountabilityWS.AuthHeader();
            //authHeder.Token = TK;
            //AccServ.AuthHeaderValue = authHeder;
            ////AccServ.Load();
            //DataSet AccDS = AccServ.GetAccSheet(int.Parse(contactID), DateTime.Parse(WeeklyStartDate), 10, true);
            //DataSet ds = AccServ.GetEmployeeNotesInInterval(int.Parse(contactID), Convert.ToDateTime(WeeklyStartDate), Convert.ToDateTime(WeeklyStartDate).AddDays(6));
            //return AccDS;

            // add the timing table 

            TSN.ERP.Engine.BussinesComponent bs = new TSN.ERP.Engine.BussinesComponent();
           // SqlConnection con = new SqlConnection("Data Source=misserver;Initial Catalog=testaccountability_data;User ID=RW; Password=RW");
            SqlCommand comm = new SqlCommand();

            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from [fn_Accountability_Timing_TotalHours]('"+WeeklyStartDate+"')";
            comm.Connection = con;

            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = comm;

            DataTable AccTimingDT = new DataTable("AccountabilityTiming");
            adpt.Fill(AccTimingDT);
            //decimal totalTime;
            int viColumnIndex;
          
             
            for (int i = 2; i < AccTimingDT.Rows.Count; i++)
            {
                //totalTime =0.0m;
                viColumnIndex = 3;


                if (AccTimingDT.Rows[i]["c11"].ToString().Trim() == "Time Clock")
                {
                    string hh = long.MaxValue + "";
                    string uu = Int64.MaxValue + "";
                    for (viColumnIndex = 3; viColumnIndex < 11; viColumnIndex++)
                    {
                        if (AccTimingDT.Rows[i]["c" + viColumnIndex].ToString().Trim() != "")
                        {
                            string[] VsValues = AccTimingDT.Rows[i]["c" + viColumnIndex].ToString().Split('.');
                           TimeSpan dtTime = new TimeSpan(long.Parse(VsValues[0]));
                           AccTimingDT.Rows[i]["c" + viColumnIndex] = Math.Round(dtTime.Duration().TotalHours, 2);
                           //totalTime = totalTime +(decimal) Math.Round(dtTime.Duration().TotalHours, 2);
                        }
                    }

                }
                              
               
               
                


            }
            AccTimingDT.AcceptChanges();
            DataSet AccDS = new DataSet();
            AccDS.Tables.Add(AccTimingDT);
            //comm.CommandText = "select NoteDate,NoteBody from [GEN_Notes] where ('" + WeeklyStartDate + "')";

            return AccDS;
        }

        
        [WebMethod]// please don't delete this method
        private DataSet AccountabilityTimingReportASIE_ForEmployee(string contactID, string WeeklyStartDate)

        {
            

            //con.ConnectionString = ConnectionString();
            WeeklyStartDate = GetStartSunday(Convert.ToDateTime(WeeklyStartDate));

            string TK = "";
            //AccountabilityWS.AccountabilityService AccServ = new AccountabilityService();
            //AccountabilityWS.AuthHeader authHeder = new AccountabilityWS.AuthHeader();
            //authHeder.Token = TK;
            //AccServ.AuthHeaderValue = authHeder;
            ////AccServ.Load();
            //DataSet AccDS = AccServ.GetAccSheet(int.Parse(contactID), DateTime.Parse(WeeklyStartDate), 10, true);
            //DataSet ds = AccServ.GetEmployeeNotesInInterval(int.Parse(contactID), Convert.ToDateTime(WeeklyStartDate), Convert.ToDateTime(WeeklyStartDate).AddDays(6));
            //return AccDS;

            // add the timing table 

            TSN.ERP.Engine.BussinesComponent bs = new TSN.ERP.Engine.BussinesComponent();
            //SqlConnection con = new SqlConnection("Data Source=misserver;Initial Catalog=testaccountability_data;User ID=RW; Password=RW");
            SqlCommand comm = new SqlCommand();

            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from [fn_Accountability_Timing_Emp_TotalHours]("+contactID+",'" + WeeklyStartDate + "')";
            comm.Connection = con;

            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = comm;

            DataTable AccTimingDT = new DataTable("AccountabilityTiming");
            adpt.Fill(AccTimingDT);
            //decimal totalTime;
            int viColumnIndex;


            for (int i = 2; i < AccTimingDT.Rows.Count; i++)
            {
                //totalTime =0.0m;
                viColumnIndex = 3;


                if (AccTimingDT.Rows[i]["c11"].ToString().Trim() == "Time Clock")
                {
                    string hh = long.MaxValue + "";
                    string uu = Int64.MaxValue + "";
                    for (viColumnIndex = 3; viColumnIndex < 11; viColumnIndex++)
                    {
                        if (AccTimingDT.Rows[i]["c" + viColumnIndex].ToString().Trim() != "")
                        {
                            string[] VsValues = AccTimingDT.Rows[i]["c" + viColumnIndex].ToString().Split('.');
                            TimeSpan dtTime = new TimeSpan(long.Parse(VsValues[0]));
                            AccTimingDT.Rows[i]["c" + viColumnIndex] = Math.Round(dtTime.Duration().TotalHours, 2);
                            //totalTime = totalTime +(decimal) Math.Round(dtTime.Duration().TotalHours, 2);
                        }
                    }

                }

            }
            AccTimingDT.AcceptChanges();

            //////////////// Get Employee Notes ////////////////////////////////////
            DateTime FromDate, ToDate;
            FromDate = Convert.ToDateTime(WeeklyStartDate.Trim());
           // FromDate.DayOfWeek
            ToDate = Convert.ToDateTime(WeeklyStartDate.Trim()).AddDays(6);
            comm.CommandText = "SELECT  GEN_AccDailyEntries.AccountabilityDate, GEN_Notes.NoteBody " +
                                                                               " FROM GEN_AccDailyEntries INNER JOIN " +
                                                                               " GEN_Notes ON GEN_AccDailyEntries.NoteID = GEN_Notes.NoteID INNER JOIN " +
                                                                               " GEN_ContactNotes ON GEN_Notes.NoteID = GEN_ContactNotes.NoteID " +
                                                                               " WHERE  (GEN_AccDailyEntries.TransID IN " +
                                                                               " (SELECT MAX(GEN_AccDailyEntries.TransID) AS EXPR1 " +
                                                                               " FROM GEN_AccDailyEntries INNER JOIN " +
                                                                               " GEN_Notes ON GEN_AccDailyEntries.NoteID = GEN_Notes.NoteID INNER JOIN " +
                                                                                " 	GEN_ContactNotes ON GEN_Notes.NoteID = GEN_ContactNotes.NoteID " +
                                                                                " WHERE (GEN_AccDailyEntries.AccountabilityDate BETWEEN '" + FromDate.AddDays(-1).ToShortDateString() + " 11:59:59 PM' AND '" + ToDate.ToShortDateString() + "' ) AND (GEN_ContactNotes.ContactID = " + contactID + " ) " +
                                                                                " GROUP BY GEN_AccDailyEntries.AccountabilityDate))" +
                                                                                " AND ( (GEN_Notes.NoteBody NOT LIKE 'null') AND (GEN_Notes.NoteBody NOT LIKE '')) ";
           
            DataTable NotesDT = new DataTable("Notes");
            adpt.Fill(NotesDT);




            //////////////////////////////////////
            comm.CommandText = "SELECT GEN_Projects.projectID, GEN_Tasks.TaskName, SUM(GEN_AccDailyEntries.AccountabilityValue) AS SumValue, "+
           " GEN_Tasks.TaskCloseDate, GEN_Projects.ProjectName, GEN_Contacts.Fullname, GEN_JobTitles.JobName, GEN_CompanyElments.CEName,        "+
           " GEN_Assignments.AssignmentDate, GEN_Tasks.TaskUnit FROM GEN_Tasks INNER JOIN GEN_Assignments INNER JOIN GEN_AccDailyEntries          "+
           " ON GEN_Assignments.AssignmentD = GEN_AccDailyEntries.AssignmentD ON GEN_Tasks.TaskID = GEN_Assignments.TaskID INNER JOIN GEN_Contacts  "+
           " ON GEN_Assignments.ContactID = GEN_Contacts.ContactID INNER JOIN GEN_Employees ON GEN_Contacts.ContactID = GEN_Employees.ContactID       "+
           " INNER JOIN GEN_JobTitles ON GEN_Employees.JobTitleID = GEN_JobTitles.JobTitleID INNER JOIN GEN_CompanyElments                              "+
           " ON GEN_Employees.CompElmentID = GEN_CompanyElments.CompElmentID LEFT OUTER JOIN GEN_Projects ON GEN_Tasks.projectID = GEN_Projects.projectID "+
           " WHERE (GEN_AccDailyEntries.AssignmentD IS NOT NULL) AND (GEN_Tasks.TaskUnit = 10  or GEN_Tasks.TaskUnit is null)" +
           " AND (GEN_Assignments.ContactID =" + contactID + ") AND (GEN_AccDailyEntries.AccountabilityDate BETWEEN '" + FromDate.AddDays(-1).ToShortDateString() + " 11:59:59 PM' AND '" + ToDate.ToShortDateString() + "' ) " +
           " GROUP BY GEN_Tasks.TaskName, GEN_Tasks.TaskName, GEN_Tasks.projectID, GEN_Assignments.AssignmentD, GEN_Projects.ProjectName, GEN_Tasks.TaskCloseDate, GEN_Assignments.AssignmentDate, GEN_Contacts.Fullname, GEN_JobTitles.JobName, GEN_CompanyElments.CEName, GEN_Projects.projectID, GEN_Tasks.TaskUnit  "+
           " ORDER BY GEN_Tasks.projectID DESC  ";
            DataTable TasksDT = new DataTable("Tasks");
            adpt.Fill(TasksDT);
            
           
            //////////////// Add tables into dataset ////////////////////////////////////
            NotesDT = DecryptNotes(NotesDT);
            DataSet AccDS = new DataSet("set");
            AccDS.Tables.Add(AccTimingDT);
            AccDS.Tables.Add(TasksDT);
            AccDS.Tables.Add(NotesDT);
           
            AccDS.DataSetName = "DatasetAT";

            AccTimingDT.Dispose();
            TasksDT.Dispose();
            NotesDT.Dispose();
            
            //AccDS.WriteXmlSchema("d:/DatasetAT.xsd");
            //AccDS.WriteXml("d:/DatasetAT.xml");
           
           
            return AccDS;
            //return null;
        }

        [WebMethod]// please don't delete this method
        private DataSet AccountabilityTimingReportASIUS_ForEmployee(string contactID, string WeeklyStartDate)
        {
            //con.ConnectionString = ConnectionString();
            WeeklyStartDate = GetStartSunday(Convert.ToDateTime(WeeklyStartDate));

            string TK = "";
            //AccountabilityWS.AccountabilityService AccServ = new AccountabilityService();
            //AccountabilityWS.AuthHeader authHeder = new AccountabilityWS.AuthHeader();
            //authHeder.Token = TK;
            //AccServ.AuthHeaderValue = authHeder;
            ////AccServ.Load();
            //DataSet AccDS = AccServ.GetAccSheet(int.Parse(contactID), DateTime.Parse(WeeklyStartDate), 10, true);
            //DataSet ds = AccServ.GetEmployeeNotesInInterval(int.Parse(contactID), Convert.ToDateTime(WeeklyStartDate), Convert.ToDateTime(WeeklyStartDate).AddDays(6));
            //return AccDS;

            // add the timing table 


            TSN.ERP.Engine.BussinesComponent bs = new TSN.ERP.Engine.BussinesComponent();

            SqlCommand comm = new SqlCommand();

            comm.CommandType = CommandType.Text;
            //comm.CommandText = "select * from [fn_Accountability_Timing_Emp_TotalHours]("+contactID+",'" + WeeklyStartDate + "')";
            comm.CommandText = "exec SP_GetAllAccHours2 " + contactID + ",'" + WeeklyStartDate + "'";
            comm.Connection = con;

            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = comm;

            DataTable AccTimingDT = new DataTable("AccountabilityTiming");
            adpt.Fill(AccTimingDT);
            //decimal totalTime;
            int viColumnIndex;





            //////////////// Get Employee Notes ////////////////////////////////////
            DateTime FromDate, ToDate;
            FromDate = Convert.ToDateTime(WeeklyStartDate.Trim());
            ToDate = Convert.ToDateTime(WeeklyStartDate.Trim()).AddDays(6);
            comm.CommandText = "SELECT  GEN_AccDailyEntries.AccountabilityDate, GEN_Notes.NoteBody " +
                                                                               " FROM GEN_AccDailyEntries INNER JOIN " +
                                                                               " GEN_Notes ON GEN_AccDailyEntries.NoteID = GEN_Notes.NoteID INNER JOIN " +
                                                                               " GEN_ContactNotes ON GEN_Notes.NoteID = GEN_ContactNotes.NoteID " +
                                                                               " WHERE  (GEN_AccDailyEntries.TransID IN " +
                                                                               " (SELECT MAX(GEN_AccDailyEntries.TransID) AS EXPR1 " +
                                                                               " FROM GEN_AccDailyEntries INNER JOIN " +
                                                                               " GEN_Notes ON GEN_AccDailyEntries.NoteID = GEN_Notes.NoteID INNER JOIN " +
                                                                                " 	GEN_ContactNotes ON GEN_Notes.NoteID = GEN_ContactNotes.NoteID " +
                                                                                " WHERE (GEN_AccDailyEntries.AccountabilityDate BETWEEN '" + FromDate.ToShortDateString() + "' AND '" + ToDate.ToShortDateString() + "' ) AND (GEN_ContactNotes.ContactID = " + contactID + " ) " +
                                                                                " GROUP BY GEN_AccDailyEntries.AccountabilityDate))" +
                                                                                " AND ( (GEN_Notes.NoteBody NOT LIKE 'null') AND (GEN_Notes.NoteBody NOT LIKE '')) ";

            DataTable NotesDT = new DataTable("Notes");
            adpt.Fill(NotesDT);




            //////////////////////////////////////
            comm.CommandText = "SELECT GEN_Projects.projectID, GEN_Tasks.TaskName, SUM(GEN_AccDailyEntries.AccountabilityValue) AS SumValue, " +
           " GEN_Tasks.TaskCloseDate, GEN_Projects.ProjectName, GEN_Contacts.Fullname, GEN_JobTitles.JobName, GEN_CompanyElments.CEName,        " +
           " GEN_Assignments.AssignmentDate, GEN_Tasks.TaskUnit FROM GEN_Tasks INNER JOIN GEN_Assignments INNER JOIN GEN_AccDailyEntries          " +
           " ON GEN_Assignments.AssignmentD = GEN_AccDailyEntries.AssignmentD ON GEN_Tasks.TaskID = GEN_Assignments.TaskID INNER JOIN GEN_Contacts  " +
           " ON GEN_Assignments.ContactID = GEN_Contacts.ContactID INNER JOIN GEN_Employees ON GEN_Contacts.ContactID = GEN_Employees.ContactID       " +
           " INNER JOIN GEN_JobTitles ON GEN_Employees.JobTitleID = GEN_JobTitles.JobTitleID INNER JOIN GEN_CompanyElments                              " +
           " ON GEN_Employees.CompElmentID = GEN_CompanyElments.CompElmentID LEFT OUTER JOIN GEN_Projects ON GEN_Tasks.projectID = GEN_Projects.projectID " +
           " WHERE (GEN_AccDailyEntries.AssignmentD IS NOT NULL) AND (GEN_Tasks.TaskUnit = 10  or GEN_Tasks.TaskUnit is null)" +
           " AND (GEN_Assignments.ContactID =" + contactID + ") AND (GEN_AccDailyEntries.AccountabilityDate BETWEEN '" + FromDate.ToShortDateString() + "' AND '" + ToDate.ToShortDateString() + "' ) " +
           " GROUP BY GEN_Tasks.TaskName, GEN_Tasks.TaskName, GEN_Tasks.projectID, GEN_Assignments.AssignmentD, GEN_Projects.ProjectName, GEN_Tasks.TaskCloseDate, GEN_Assignments.AssignmentDate, GEN_Contacts.Fullname, GEN_JobTitles.JobName, GEN_CompanyElments.CEName, GEN_Projects.projectID, GEN_Tasks.TaskUnit  " +
           " ORDER BY GEN_Tasks.projectID DESC  ";
            DataTable TasksDT = new DataTable("Tasks");
            adpt.Fill(TasksDT);


            //////////////// Add tables into dataset ////////////////////////////////////
            NotesDT = DecryptNotes(NotesDT);
            DataSet AccDS = new DataSet("set");
            AccDS.Tables.Add(AccTimingDT);
            AccDS.Tables.Add(TasksDT);
            AccDS.Tables.Add(NotesDT);

            AccDS.DataSetName = "DatasetAT";

            //AccDS.WriteXmlSchema("d:/DatasetAT.xsd");
            //AccDS.WriteXml("d:/DatasetAT.xml");


            return AccDS;
        }

        [WebMethod]// please don't delete this method
        private DataSet AccountabilityDetailsReport(string TK, string param1, string param2)
        {
            try
            {
                // add parameter in the report writer with name "TK"

                // get the accountability table           
                // SharedPresentation.AccountabilityService AccServ = new SharedPresentation.AccountabilityService();
                AccountabilityWS.AccountabilityService AccServ = new AccountabilityService();

                AccountabilityWS.AuthHeader authHeder = new AccountabilityWS.AuthHeader();
                //string  tok= Login("amoawad","1");

                authHeder.Token = TK;
                AccServ.AuthHeaderValue = authHeder;
                //AccServ.Load();
                DataSet AccDS = AccServ.GetAccSheet(int.Parse(param1), DateTime.Parse(param2), 10, true);
                return AccDS;

                // add the timing table 
                TSN.ERP.Engine.BussinesComponent bs = new TSN.ERP.Engine.BussinesComponent();

                SqlConnection con = new SqlConnection(bs.ConnectionString);
                SqlCommand comm = new SqlCommand();

                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "SP_timing_GetEmployeeWeeklySummary";

                SqlParameter sqlparam1 = new SqlParameter();
                sqlparam1.ParameterName = "@contactId";
                sqlparam1.Value = param1;


                SqlParameter sqlparam2 = new SqlParameter();
                sqlparam2.ParameterName = "@date";
                sqlparam2.Value = param2;


                comm.Parameters.Add(sqlparam1);
                comm.Parameters.Add(sqlparam2);


                SqlDataAdapter adpt = new SqlDataAdapter();
                adpt.SelectCommand = comm;

                DataTable timingDT = new DataTable();
                adpt.Fill(timingDT);

                AccDS.Tables.Add(timingDT);


                return AccDS;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }

        #region GetContactAccountabilityNotesInInterval

        private DataSet GetContactAccountabilityNotesInInterval(int ContactID, DateTime FromDate, DateTime ToDate)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter ContactNotesInInterval = new SqlDataAdapter();
            SqlConnection con = new SqlConnection();
            ContactNotesInInterval.SelectCommand.Connection = con;


           ContactNotesInInterval.SelectCommand.CommandText = "SELECT  GEN_AccDailyEntries.AccountabilityDate, GEN_Notes.NoteBody " +
                                                                               " FROM GEN_AccDailyEntries INNER JOIN " +
                                                                               " GEN_Notes ON GEN_AccDailyEntries.NoteID = GEN_Notes.NoteID INNER JOIN " +
                                                                               " GEN_ContactNotes ON GEN_Notes.NoteID = GEN_ContactNotes.NoteID " +
                                                                               " WHERE  (GEN_AccDailyEntries.TransID IN " +
                                                                               " (SELECT MAX(GEN_AccDailyEntries.TransID) AS EXPR1 " +
                                                                               " FROM GEN_AccDailyEntries INNER JOIN " +
                                                                               " GEN_Notes ON GEN_AccDailyEntries.NoteID = GEN_Notes.NoteID INNER JOIN " +
                                                                                " 	GEN_ContactNotes ON GEN_Notes.NoteID = GEN_ContactNotes.NoteID " +
                                                                                " WHERE (GEN_AccDailyEntries.AccountabilityDate BETWEEN '" + FromDate.ToShortDateString() + "' AND '" + ToDate.ToShortDateString() + "' ) AND (GEN_ContactNotes.ContactID = " + ContactID.ToString() + " ) " +
                                                                                " GROUP BY GEN_AccDailyEntries.AccountabilityDate))" +
                                                                                " AND ( (GEN_Notes.NoteBody NOT LIKE 'null') AND (GEN_Notes.NoteBody NOT LIKE '')) ";
            ContactNotesInInterval.Fill(ds);
            return ds;
        }

        #endregion

		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
        private DataSet GetTotalAccSheet(DateTime dtime, string filter)
		{
			//string tt=this.Token;
			//string ttttt=this.Login(UserName,Password);
			SharedPresentation.AccountabilityService xx=new SharedPresentation.AccountabilityService();
			
			//string tt=xx.Login(UserName,Password);
			xx.GetERPSession(Token);
			xx.Load();
			return xx.GetTotalAccSheet(dtime,filter);
			
		}
        private DataTable DecryptNotes(DataTable dt)
        {
            //in case task summery report

            foreach (DataRow dr in dt.Rows)
            {
                dr["NoteBody"] = RemoveSimboles(dr["NoteBody"].ToString());
            }
            return dt;
        }

        public string RemoveSimboles(string NoteBody)
        {
            NoteBody = NoteBody.Replace("%20", " ");
            NoteBody = NoteBody.Replace("%21", "!");
            NoteBody = NoteBody.Replace("%23", "#");
            NoteBody = NoteBody.Replace("%24", "$");
            NoteBody = NoteBody.Replace("%25", "%");
            NoteBody = NoteBody.Replace("%5E", "^");
            NoteBody = NoteBody.Replace("%26", "&");
            NoteBody = NoteBody.Replace("%29", ")");
            NoteBody = NoteBody.Replace("%28", "(");
            NoteBody = NoteBody.Replace("%7C", "|");
            NoteBody = NoteBody.Replace("%3B", ";");
            NoteBody = NoteBody.Replace("%3F", "?");
            NoteBody = NoteBody.Replace("%3B", ",");
            NoteBody = NoteBody.Replace("%2C", "/");
            NoteBody = NoteBody.Replace("%3A", ":");
            NoteBody = NoteBody.Replace("%3D", "=");
            NoteBody = NoteBody.Replace("%5D", "]");
            NoteBody = NoteBody.Replace("%5B", "[");
            NoteBody = NoteBody.Replace("%7D", "}");
            NoteBody = NoteBody.Replace("%7B", "{");
            NoteBody = NoteBody.Replace("%7E", "~");
            NoteBody = NoteBody.Replace("%22", "\"");

            NoteBody = NoteBody.Replace("%27", "'");
            NoteBody = NoteBody.Replace("%5C", "\\");
            NoteBody = NoteBody.Replace("%0D%0A", "\n");
            NoteBody = NoteBody.Replace("%0D%", "\n");
            NoteBody = NoteBody.Replace("%0A", "\n");
            NoteBody = NoteBody.Replace("%3C", "<");
            NoteBody = NoteBody.Replace("%3E", ">");
            NoteBody = NoteBody.Replace("@@0937107@@", "&");
            return NoteBody;
        }
        private string GetStartSunday(DateTime startDate)
        {
            CultureInfo info = Thread.CurrentThread.CurrentCulture;
            DayOfWeek firstday = info.DateTimeFormat.FirstDayOfWeek;
            DayOfWeek today = info.Calendar.GetDayOfWeek(startDate);

            int diff = today - firstday;
            DateTime firstDate = startDate.AddDays(-diff);
            return firstDate.ToShortDateString();
        }
	}
}
