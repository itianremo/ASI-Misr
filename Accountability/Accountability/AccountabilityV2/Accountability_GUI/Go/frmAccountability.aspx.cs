using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Web.Mail;

namespace TSN.ERP.WebGUI.Go
{
	/// <summary>
	/// Summary description for frmAccountability.
	/// </summary>
	public partial class frmAccountability : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblFrom;
		protected System.Web.UI.WebControls.TextBox txtFrom;
		protected System.Web.UI.WebControls.Label lblTo;
		protected System.Web.UI.WebControls.TextBox txtTo;
		protected System.Web.UI.WebControls.Label lblCC;
		protected System.Web.UI.WebControls.TextBox txtCC;
		protected System.Web.UI.WebControls.Label lblBCC;
		protected System.Web.UI.WebControls.TextBox txtBCC;
		protected System.Web.UI.WebControls.Label lblSubject;
		protected System.Web.UI.WebControls.TextBox txtSubject;
		protected TSN.ERP.SharedComponents.Data.dsAccountabilitySheet dsAccountabilitySheet;

//		[Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
//		public string SetDataLogout()
//		{
//			string vslogout="Hamdy";
//
//			return vslogout;
//		}
		//----------------------------------------------------------------------
		#region page load
		protected void Page_Load(object sender, System.EventArgs e)
		{
            Response.AppendHeader("X-UA-Compatible", "IE=EmulateIE7");
            FreeTextBoxControls.NetSpell netSpell = new FreeTextBoxControls.NetSpell();
            try   // added to avoid error of IE8 with freetextbox control
            {
                FreeTextBox1.Toolbars[3].Items.Add(netSpell);
            }
            catch { }
			// Register this form as Ajax compliant
			Ajax.Utility.RegisterTypeForAjax(typeof(frmAccountability));
			Ajax.Utility.RegisterTypeForAjax(typeof(frmPopup));

            this.ddlFilterEmployees.Attributes.Add("onchange", "bindEmployees();");

			try
			{

                

				if ( !IsPostBack )
				{
                    ddlFilterEmployees.SelectedValue = "1";
					
					LabelToken.Text =  ((Navigation.BaseObject) Session[ "navigation" ]).Token;
					/////////////////////////
                    /////////////////////////////////
                    //////////////////////////
                    // fill jop titles
                    TSN.ERP.SharedComponents.Data.dsJobtitles dsJobs = new TSN.ERP.SharedComponents.Data.dsJobtitles();
                    if (Navigation.BaseObject.SafeMerge(dsJobs, ((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobtitles()))
                    {
                        for (int i = 0; i < dsJobs.GEN_JobTitles.Rows.Count; i++)
                        {
                            ListItem jobItem = new ListItem(dsJobs.GEN_JobTitles[i].JobName, dsJobs.GEN_JobTitles[i].JobTitleID.ToString());
                            jobItem.Attributes.Add("id", "job" + dsJobs.GEN_JobTitles[i].JobTitleID);
                            lstJob.Items.Add(jobItem);
                        }
                    }

                    // fill company elements
                    TSN.ERP.SharedComponents.Data.dsCompanyElements dsComp = new TSN.ERP.SharedComponents.Data.dsCompanyElements();
                    if (Navigation.BaseObject.SafeMerge(dsComp, ((Navigation.BaseObject)Session["navigation"]).CompanyWsObject.ListCompnayElements()))
                    {
                        for (int i = 0; i < dsComp.GEN_CompanyElments.Rows.Count; i++)
                        {
                            ListItem comItem = new ListItem(dsComp.GEN_CompanyElments[i].CEName, dsComp.GEN_CompanyElments[i].CompElmentID.ToString());
                            comItem.Attributes.Add("id", "dept" + dsComp.GEN_CompanyElments[i].CompElmentID);
                            lstDept.Items.Add(comItem);
                        }
                    }
                    /////////////////////////////////////////////
                    /////////////////////////
                    //////////////////////////////////////////////////////////////////////

					DataSet dsResps = ((Navigation.BaseObject)Session[ "navigation" ]).JobTiltesWsObject.ListResponsbilities();
					Session["dsResps"] = dsResps;

				}
			}
			catch( Exception ee )
			{

			}
		}
		#endregion
		//----------------------------------------------------------------------
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.dsAccountabilitySheet = new TSN.ERP.SharedComponents.Data.dsAccountabilitySheet();
			((System.ComponentModel.ISupportInitialize)(this.dsAccountabilitySheet)).BeginInit();
			// 
			// dsAccountabilitySheet
			// 
			this.dsAccountabilitySheet.DataSetName = "dsAccountabilitySheet";
			this.dsAccountabilitySheet.Locale = new System.Globalization.CultureInfo("ar-EG");
			((System.ComponentModel.ISupportInitialize)(this.dsAccountabilitySheet)).EndInit();

		}
		#endregion
		//----------------------------------------------------------------------
		#region Get all employees whom current user has access upon.
		/// <summary>
		/// Returns all employees whom current user has permessions to view their data.
		/// </summary>
		/// <returns></returns>
		[Ajax.AjaxMethod (Ajax.HttpSessionStateRequirement.Read)]
		public DataSet BindEmployees(int EmpStatus)
		{
            Session["EmployeesFilter"] = EmpStatus;
			//DataSet dsEmployee =  ((Navigation.BaseObject)System.Web.HttpContext.Current.Session["navigation"]).AccountabilityWSObject.ViewAccountabilityEmployees();
			DataSet dsEmployee =  ((Navigation.BaseObject)Session["navigation"]).AccountabilityWSObject.ViewAccountabilityEmployees();
			DataView dvEmp = dsEmployee.Tables[0].DefaultView;
            
            dvEmp.RowFilter = "EmployeeStatus = 1";
            if (Session["EmployeesFilter"] != null)
            {
                if (Session["EmployeesFilter"].ToString() == "0")
                {
                    dvEmp.RowFilter = "EmployeeStatus = 0";
                }
                else if (Session["EmployeesFilter"].ToString() == "1")
                {
                    dvEmp.RowFilter = "EmployeeStatus = 1";
                }
                else
                {
                    dvEmp.RowFilter = "";
                }
            }
            //if (ddlFilterEmployees.SelectedValue == "0")
            //{
            //    dvEmp.RowFilter = "EmployeeStatus = 0";
            //}
            //else if (ddlFilterEmployees.SelectedValue == "1")
            //{
            //dvEmp.RowFilter = "EmployeeStatus = 1";
            //}
            //else if (ddlFilterEmployees.SelectedValue == "2")
            //{
            //    dvEmp.RowFilter = "";
            //}
			dvEmp.Sort = "FirstName, MiddleName, LastName";
			dsEmployee.Tables.Clear();
			dsEmployee.Tables.Add(CreateTable(dvEmp));	
			if(dsEmployee.Tables[0].Rows.Count > 1)
				Session["IsManager"] = true;
			else
				Session["IsManager"] = false;
			return dsEmployee;
		}
		#endregion
		//----------------------------------------------------------------------
		#region returns job-titles
		/// <summary>
		/// Returns all job titles
		/// </summary>
		/// <returns></returns>
		[Ajax.AjaxMethod (Ajax.HttpSessionStateRequirement.Read)]
		public DataSet BindJobs()
		{
			DataSet dsJobs =  ((Navigation.BaseObject) Session[ "navigation" ]).JobTiltesWsObject.ListJobtitles();	
			return dsJobs;
		}
		#endregion
		//----------------------------------------------------------------------
		#region Get all company elements
		/// <summary>
		/// Returns all company elements [Department]
		/// </summary>
		/// <returns></returns>
		[Ajax.AjaxMethod (Ajax.HttpSessionStateRequirement.Read)]
		public DataSet BindDept()
		{
			DataSet dsDept = ((Navigation.BaseObject) Session[ "navigation" ]).CompanyWsObject.ListCompnayElements();
			return dsDept;
		}
		#endregion
		//----------------------------------------------------------------------
		#region get given employee's job and department, separated by comma. ex ["Software Developer,MIS"]
		/// <summary>
		/// Returns given employee department and job. the returned value is a string separated by comma.
		///  Eample : this function may return "Software Developer,MIS"
		/// </summary>
		/// <param name="empID"></param>
		/// <returns></returns>
		[Ajax.AjaxMethod (Ajax.HttpSessionStateRequirement.Read) ]
		public string BindEmpJobDept(int empID)
		{
			DataSet dsEmp = ((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListSingleEmployeeData(empID);
			string strJobDept = dsEmp.Tables[0].Rows[0]["JobTitleID"].ToString() + ',' 
				+ dsEmp.Tables[0].Rows[0]["compElmentID"].ToString() ;
            return strJobDept;
		}
		#endregion
		//----------------------------------------------------------------------
		#region bind accountability sheet
		/// <summary>
		/// 
		/// </summary>
		/// <param name="empID"> Employee ID</param>
		/// <param name="sheetDate"> Date of accountability sheet</param>
		/// <param name="showOffDays"> Denotes whether to show off days or not</param>
		/// <param name="viewMode">Sheet view mode (10 ... General, 20 ... Project, 40 ... Tasks only)</param>
		/// <returns>A dataset contains given employee sheet in given date</returns>
		[Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
		public DataSet BindSheet(int empID, string sheetDate, bool showOffDays, int viewMode)
		{
			int vMode = viewMode < 40 ? viewMode:10 ;
			DataRow dr = null;
			int cnt=0;
			try
			{
				System.Web.HttpContext.Current.Session["CurrentEmployee"] = empID;
				IFormatProvider culture = new CultureInfo("en-US",true);
//				DataSet dsSheet  = Navigation.((Navigation.BaseObject) Session[ "navigation" ]).AccountabilityWSObject.GetAccSheet
//				  	(empID,DateTime.Parse(sheetDate,culture),vMode,showOffDays);
				////////////// test////////////
//				DataSet dsSheet  = ((Navigation.BaseObject) Session[ "navigation" ]).AccountabilityWSObject.GetAccSheet
//					(empID,DateTime.Parse(sheetDate),vMode,showOffDays);
				//////////////////////////

				DataSet dsSheet = new DataSet();
				if (!Navigation.BaseObject.SafeMerge
					(dsSheet,((Navigation.BaseObject) Session[ "navigation" ]).AccountabilityWSObject.GetAccSheet(empID,DateTime.Parse(sheetDate,culture),vMode,showOffDays)))
					return new TSN.ERP.SharedComponents.Data.dsAccountabilitySheet();
				cnt = dsSheet.Tables[0].Rows.Count-1;
				// if view mode equals to 40, which means that user want to show tasks only
				// then, get general view of accountability sheet and remove all records except tasks
				if (viewMode == 40) 
				{
					///********* Enhance Performance by SM ****************///
					DataView dvTsk = dsSheet.Tables[0].DefaultView;
					dvTsk.RowFilter = "RecoredType = 10";	
					dvTsk.Sort = "Taskpriority";
					DataSet dsSheet2 = new DataSet();
					dsSheet2.Tables.Add(CreateTable(dvTsk));			
					dsSheet2.Tables.Add(dsSheet.Tables[ 1 ].Copy());			
					dsSheet2.Tables.Add(dsSheet.Tables[ 2 ].Copy());
					dsSheet2.Tables.Add(dsSheet.Tables[ 3 ].Copy());	
					dsSheet.Tables.Clear();
					dsSheet.Merge( dsSheet2 );
				///********* End of Enhance Performance by SM ****************///
					
			//********* Old code********************////

//					for(int i=cnt;i>=0;i--)
//					{
//						dr = dsSheet.Tables[0].Rows[i];
//						if (dr["RecoredType"].ToString() != "10") // if project or responsibility
//							dsSheet.Tables[0].Rows.RemoveAt(i);   // remove it from dataset
//
//					}
//
//					DataSet dsSheet2 = new DataSet();
//					DataView dvTsk = dsSheet.Tables[0].DefaultView;
//					dvTsk.Sort = "Taskpriority";
//					dsSheet2.Tables.Add(CreateTable(dvTsk));			
//					dsSheet2.Tables.Add(dsSheet.Tables[ 1 ].Copy());			
//					dsSheet2.Tables.Add(dsSheet.Tables[ 2 ].Copy());
//					dsSheet2.Tables.Add(dsSheet.Tables[ 3 ].Copy());	
//					dsSheet.Tables.Clear();
//					dsSheet.Merge( dsSheet2 );
					////******************************************////////
				}
				Session["dsSheet"]=dsSheet;
					
					return dsSheet; 
			}
			catch(Exception ex)
			{
				return null;
			}
		}
		#endregion
		//----------------------------------------------------------------------
		#region bind responsibilities
		/// <summary>
		/// Returns all responsibilities
		/// </summary>
		/// <returns>Responsibilities dataset</returns>
		[Ajax.AjaxMethod (Ajax.HttpSessionStateRequirement.Read)]
		public DataSet BindRespons()
		{
			DataSet dsResp = ((Navigation.BaseObject) Session[ "navigation" ]).JobTiltesWsObject.ListResponsbilities();
			return dsResp;
		}
		#endregion
		//----------------------------------------------------------------------
		#region bind projects
		/// <summary>
		/// Returns all project
		/// </summary>
		/// <returns>Projects dataset</returns>
		[Ajax.AjaxMethod (Ajax.HttpSessionStateRequirement.Read)]
		public DataSet BindProjects()
		{
			DataSet dsProject = ((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.ListAllProjects();
			return dsProject;
		}
		#endregion
		//----------------------------------------------------------------------
		#region save sheet
		/// <summary>
		/// Save accountability sheet for given employee
		/// </summary>
		/// <param name="sheet">Sheet array, each item contains all accountability value for all week days separated by comma, like "2,3,5,4,6,2,5"</param>
		/// <param name="empID">Employee ID</param>
		/// <param name="sheetDate">Sheet date</param>
		/// <param name="notes">Notes array, an array of 7 contains all notes value for all week days</param>
		/// <param name="showOffDays">Denotes wether to show off days or not</param>
		/// <param name="viewMode">Sheet view mode (10 ... General, 20 ... Project, 40 ... Tasks only)</param>
		/// <returns></returns>
		[Ajax.AjaxMethod (Ajax.HttpSessionStateRequirement.ReadWrite)]
		public string SaveSheet(string[] sheet,int empID, string sheetDate, string[] notes,bool showOffDays,int viewMode)
		{
			int vMode = viewMode < 40 ? viewMode : 10 ;
			DataRow dr = null;
			int cnt=0;
			try
			{
				Session[ "SheetStatus" ] = "Saved";

				IFormatProvider culture = new CultureInfo("en-US",true);
				///*************** New View *******************//
				DataSet dsSheet=(DataSet)Session["dsSheet"];
				////******************End View ***************************//
				////////************** Old Code ************************//
				 if(dsSheet==null)
				{
//					DataSet dsSheet  = ((Navigation.BaseObject) Session[ "navigation" ]).AccountabilityWSObject.GetAccSheet
//						(empID,DateTime.Parse(sheetDate),vMode,showOffDays);
					 dsSheet  = ((Navigation.BaseObject) Session[ "navigation" ]).AccountabilityWSObject.GetAccSheet
						(empID,DateTime.Parse(sheetDate),vMode,showOffDays);
					cnt = dsSheet.Tables[0].Rows.Count-1;
					// if view mode equals to 40, which means that user want to show tasks only
					// then, get general view of accountability sheet and remove all records except tasks
					if (viewMode == 40) 
					{
						//.RowFilter ="make=Chevy&model=Corvette"
						//					DataSet ds=new DataSet();
						//					ds.Tables.Add(dsSheet.Tables[0].Copy());
						//					ds.Tables[0].Clear();
						//System.Data.DataRow []objDataRows= dsSheet.Tables[0].Select("RecoredType='10'","Taskpriority");
						//ds.Tables[0].LoadDataRow(dsSheet.Tables[0].Select("RecoredType='10'"),true);
						//string test=Convert.ToString(ds.Tables[0].Rows[0][0]);
						///********* Enhance Performance SM ****************///
						DataView dvTsk = dsSheet.Tables[0].DefaultView;
						dvTsk.RowFilter = "RecoredType = 10";	
						dvTsk.Sort = "Taskpriority";
						DataSet dsSheet2 = new DataSet();
						dsSheet2.Tables.Add(CreateTable(dvTsk));			
						dsSheet2.Tables.Add(dsSheet.Tables[ 1 ].Copy());			
						dsSheet2.Tables.Add(dsSheet.Tables[ 2 ].Copy());
						dsSheet2.Tables.Add(dsSheet.Tables[ 3 ].Copy());	
						dsSheet.Tables.Clear();
						dsSheet.Merge( dsSheet2 );
						///********* End of Enhance Performance by SM ****************///
					
					
						///********* Old Code ****************///
						//					for(int i=cnt;i>=0;i--)
						//					{
						//						dr = dsSheet.Tables[0].Rows[i];
						//						if (dr["RecoredType"].ToString() != "10") // if current record is project or responsibility
						//							dsSheet.Tables[0].Rows.RemoveAt(i);   // remove it
						//					}
						//
						//					DataSet dsSheet2 = new DataSet();
						//					
						//					DataView dvTsk = dsSheet.Tables[0].DefaultView;
						//					dvTsk.Sort = "Taskpriority";
						//					dsSheet2.Tables.Add(CreateTable(dvTsk));			
						//					dsSheet2.Tables.Add(dsSheet.Tables[ 1 ].Copy());			
						//					dsSheet2.Tables.Add(dsSheet.Tables[ 2 ].Copy());
						//					dsSheet2.Tables.Add(dsSheet.Tables[ 3 ].Copy());	
						//					dsSheet.Tables.Clear();
						//					dsSheet.Merge( dsSheet2 );

						///*********End Old Code ****************///
					}
				}
				// create accountability sheet datasat.
				for ( int i =0; i < sheet.Length;i++)
				{
					
					string[] vals = sheet[i].Split(',');
					dsSheet.Tables[0].Rows[i]["sun"] = (vals[0].Trim() !="" ?Double.Parse(vals[0]):0);
					dsSheet.Tables[0].Rows[i]["mon"] = (vals[1].Trim() !="" ?Double.Parse(vals[1]):0);
					dsSheet.Tables[0].Rows[i]["tue"] = (vals[2].Trim() !="" ?Double.Parse(vals[2]):0);
					dsSheet.Tables[0].Rows[i]["wen"] = (vals[3].Trim() !="" ?Double.Parse(vals[3]):0);
					dsSheet.Tables[0].Rows[i]["thr"] = (vals[4].Trim() !="" ?Double.Parse(vals[4]):0);
					dsSheet.Tables[0].Rows[i]["fri"] = (vals[5].Trim() !="" ?Double.Parse(vals[5]):0);
					dsSheet.Tables[0].Rows[i]["sat"] = (vals[6].Trim() !="" ?Double.Parse(vals[6]):0);
				}
				// create notes dataset
				for (int i = 0; i<= 6 ;i++)
					
					dsSheet.Tables[3].Rows[i]["NoteBody"] = notes[i];//.Replace("'","&rsquo;"); 
				// save accountability sheet.
				
				((Navigation.BaseObject) Session[ "navigation" ]).AccountabilityWSObject.UpdateSheet(dsSheet,empID,DateTime.Parse(sheetDate,culture),10);
				return ((Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.LastInnerException();
				
			}
			catch(Exception ex)
			{
				return ex.Message;
			}
		}
		#endregion
		//----------------------------------------------------------------------
		#region delete assignment
		/// <summary>
		/// Delete given assignment
		/// </summary>
		/// <param name="assID">Assignment ID</param>
		/// <returns>1 if succeeded, error message if failed</returns>
		[Ajax.AjaxMethod (Ajax.HttpSessionStateRequirement.Read)]
		public string DeleteAss(int assID)
		{
			try
			{
				DataSet dsAss = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewAssignmentData(assID);
				if (dsAss.Tables[0].Rows.Count == 1)
					dsAss.Tables[0].Rows[0].Delete();
				else
					return "Failed to Find this Assginment" ;
				
				string strReturnValue = (((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.DeleteAssignment(dsAss)).ToString();
                return strReturnValue;
			}
			catch(Exception ex)
			{
				return "Falied to delete assignment";
			}
		}
		#endregion
		//----------------------------------------------------------------------
		#region Complete assignmenet
		/// <summary>
		/// Complete given assignment
		/// </summary>
		/// <param name="assID">Assignment ID</param>
		/// <returns>1 if succeeded, error message if failed</returns>
		[Ajax.AjaxMethod (Ajax.HttpSessionStateRequirement.Read)]
		public string CompleteAss(int assID)
		{
			try
			{
				return(((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.CloseAssignment(assID)).ToString();
			}
			catch(Exception ex)
			{
				return "Failed to complete assignment";
			}
		}
		#endregion
		//----------------------------------------------------------------------
		#region get last selected employee, used to load his/her sheet
		/// <summary>
		/// Returns last selected employee, used later to automatically load his/her sheet
		/// </summary>
		/// <returns>Employee ID</returns>
		[Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
		public int GetSelectedEmp()
		{
			try
			{
				int empID = int.Parse(System.Web.HttpContext.Current.Session["CurrentEmployee"].ToString());
				System.Web.HttpContext.Current.Session["CurrentEmployee"] = -1;

                //DataSet dsEmp = ((Navigation.BaseObject)Session["navigation"]).EmployeeWsObject.ListSingleEmployeeData(empID);
                //if(Convert.ToInt32(dsEmp.Tables[0].Rows[0]["EmployeeStatus"]) == 0)
                //{
                //    return -1;
                //}

				return(empID);
			}
			catch(Exception ex)
			{
				return -1;
			}
		}
		#endregion
        //----------------------------------------------------------------------
        #region get access right for weekly manager report
        /// <summary>
        /// Returns true if the emp has access right for weekly manager , otherwise return false
        /// </summary>
        /// <returns>boolean</returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
        public bool GetAccessRightForWeeklyManagerReport()
        {
            try
            {
                int empID = int.Parse(System.Web.HttpContext.Current.Session["CurrentEmployee"].ToString());
               
                int UserID = ((Navigation.BaseObject)Session["navigation"]).SecurityWsObject.GetUserIDByContactID(empID);

                bool hasRight = ((Navigation.BaseObject)Session["navigation"]).SecurityWsObject.CheckRuleXUserID(UserID, 5127);

                return hasRight;
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
		//----------------------------------------------------------------------
		# region create a table from dataview
		/// <summary>
		/// Convert given dataview to datatable
		/// </summary>
		/// <param name="obDataView"></param>
		/// <returns></returns>
		public static DataTable CreateTable(DataView obDataView)
		{
			if (null == obDataView)
			{
				throw new ArgumentNullException
					("DataView", "Invalid DataView object specified");
			}


		
			///********* End of Enhance Performance by SM ****************///
//						DataTable obNewDt = obDataView.Table;

			///********* End of Enhance Performance by SM ****************///
			
			

			///********* Old Code ****************///
			DataTable obNewDt = obDataView.Table.Clone();
			int idx = 0;
			string [] strColNames = new string[obNewDt.Columns.Count];
			foreach (DataColumn col in obNewDt.Columns)
			{
				strColNames[idx++] = col.ColumnName;
			}

			IEnumerator viewEnumerator = obDataView.GetEnumerator();
			while (viewEnumerator.MoveNext())
			{
				DataRowView drv = (DataRowView)viewEnumerator.Current;
				DataRow dr = obNewDt.NewRow();
				try
				{
					foreach (string strName in strColNames)
					{
						dr[strName] = drv[strName];
					}
				}
				catch (Exception ex)
				{
					
				}
				obNewDt.Rows.Add(dr);
			}
			///*************** End of Old Code **************************//

			return obNewDt;
		}
		#endregion
		//----------------------------------------------------------------------
		#region save priorities
		/// <summary>
		/// Save assignment priorities
		/// </summary>
		/// <param name="assIDs">Array of assignments IDs </param>
		/// <param name="assPriority">Array of corresponding priorities</param>
		/// <returns>Empty if succseeded, error message if failed</returns>
		[Ajax.AjaxMethod (Ajax.HttpSessionStateRequirement.Read)]
		public string SavePriorities(int[] assIDs, string[] assPriority )
		{
			try
			{
				for (int i =0;i<assIDs.Length;i++)
				{
					if (assPriority[i].Trim() != "" )
						((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.UpdateAssignmentPriority(assIDs[i],int.Parse(assPriority[i]));
					else
						((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.UpdateAssignmentPriority(assIDs[i],0);
				}
				return "";	
			}
			catch(Exception ex)
			{
				return "Error";

			}
		}
		#endregion
        // added by sayed to get version of ie 02/07/2009
        #region set IE_Version Session
        /// <summary>
        ///  set IE version Session
        /// </summary>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void SetIEVersionSession(string version)
        {
            Session["IEVersion"] = version;
          
        }
        #endregion
        //
		//----------------------------------------------------------------------
		#region Change Save Session
		/// <summary>
		///  Change Sheet Status
		/// </summary>
		[Ajax.AjaxMethod (Ajax.HttpSessionStateRequirement.ReadWrite)]
		public void ChangeSaveSession()
		{
			Session[ "SheetStatus" ] = "Modified";
	
		}

		/// <summary>
		///  Change Sheet Status
		/// </summary>
		[Ajax.AjaxMethod (Ajax.HttpSessionStateRequirement.ReadWrite)]
		public void ChangeSaveSession2()
		{
			Session[ "SheetStatus" ] = "Saved";
	
		}
		#endregion
		//----------------------------------------------------------------------
		#region Check if total hours exceeds 24 hours in a day
		/// <summary>
		/// 
		/// </summary>
		/// <param name="empID"> Employee ID</param>
		/// <param name="sheetDate"> Date of accountability sheet</param>
		/// <param name="showOffDays"> Denotes whether to show off days or not</param>
		/// <param name="viewMode">Sheet view mode (10 ... General, 20 ... Project, 40 ... Tasks only)</param>
		/// <returns>A dataset contains given employee sheet in given date</returns>
		[Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
		public int[] CheckHoursCount(int empID, string sheetDate, bool showOffDays, int viewMode, int originalViewMode)
		{
			try
			{
				System.Web.HttpContext.Current.Session["CurrentEmployee"] = empID;
				IFormatProvider culture = new CultureInfo("en-US",true);
				DataSet dsSheet  = ((Navigation.BaseObject) Session[ "navigation" ]).AccountabilityWSObject.GetAccSheet(empID,DateTime.Parse(sheetDate,culture),viewMode,/*showOffDays*/true);
				
				int[] tasksHours = new int[7];
				double xx= Convert.ToDouble(dsSheet.Tables[0].Compute("SUM("+dsSheet.Tables[0].Columns[3].ColumnName+")", ""+dsSheet.Tables[0].Columns[3].ColumnName+" > '0'"));

				foreach(DataRow dr in dsSheet.Tables[0].Rows)
				{
					if(dr[2] != DBNull.Value)//Task Unit--- DBNull.Value --> resp or proj, 10 --> task, 40 --> dayoff
					{
						if(dr[2].ToString() == "40")//Dayoff tasks
						{
							//Daysoff values
							tasksHours[0] += int.Parse(dr[3].ToString());//Sunday Value 
							tasksHours[1] += int.Parse(dr[4].ToString());//Monday Value
							tasksHours[2] += int.Parse(dr[5].ToString());//Tuesday Value
							tasksHours[3] += int.Parse(dr[6].ToString());//Wednesday value
							tasksHours[4] += int.Parse(dr[7].ToString());//Thursday Value
							tasksHours[5] += int.Parse(dr[8].ToString());//Friday Value
							tasksHours[6] += int.Parse(dr[9].ToString());//Saturday Value
						}
						else if(dr[2].ToString() == "10" && dr[14] == DBNull.Value && originalViewMode == 30)//Tasks that doesn't belong to any project and view mode is projects
						{
							//Tasks values
							tasksHours[0] += int.Parse(dr[3].ToString());//Sunday Value 
							tasksHours[1] += int.Parse(dr[4].ToString());//Monday Value
							tasksHours[2] += int.Parse(dr[5].ToString());//Tuesday Value
							tasksHours[3] += int.Parse(dr[6].ToString());//Wednesday value
							tasksHours[4] += int.Parse(dr[7].ToString());//Thursday Value
							tasksHours[5] += int.Parse(dr[8].ToString());//Friday Value
							tasksHours[6] += int.Parse(dr[9].ToString());//Saturday Value
						}
					}
				}
				return tasksHours;
			}
			catch(Exception ex)
			{
				return new int[7];
			}
		}
		#endregion
		//----------------------------------------------------------------------		
		#region Check if the user is admin
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
		public bool IsAdmin()
		{
			if(((Navigation.BaseObject)Page.Session[ "navigation" ]).SecInfo.IsAdministrator)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion
		//----------------------------------------------------------------------
		#region Check if the responsibility is closed
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
		public bool IsRespClosed(int JobID, int respID)
		{
			//################ First Solution ###################################################################
//			// Remove this code 
//			DataSet dsResp =((Navigation.BaseObject)Page.Session[ "navigation" ]).JobTiltesWsObject.ListClosedJobResponsbilities(JobID);
//			for(int i=0; i<dsResp.Tables[0].Rows.Count; i++)
//			{
//				if(Convert.ToInt32(dsResp.Tables[0].Rows[i]["ResponsID"]) == respID && !Convert.ToBoolean(dsResp.Tables[0].Rows[i]["IsActive"]))
//				{
//					return true;
//				}
//			}
//			return false;
			//##################################################################################################

			//################ Second Solution ###################################################################
//			bool IsRespActive = ((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.IsResponsibilityActive(respID);
//			return !IsRespActive;
			//##################################################################################################


			//################ Third Solution ###################################################################
			DataSet dsResps = (DataSet)Session["dsResps"];
			bool IsActive = Convert.ToBoolean(dsResps.Tables[0].Select("ResponsID='"+respID+"'")[0]["IsActive"]);
			return !IsActive;		
			//##################################################################################################
		}
		#endregion
		//----------------------------------------------------------------------
		#region SendMail
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
		public void SendMail(string from, string to, string cc, string bcc, string subject, string[] notes)
		{
			//string str = getIt();
			MailMessage msg = new MailMessage();
//			msg.From=txtFrom.Text;
//			msg.To=txtTo.Text;
//			msg.Cc=txtCC.Text;
//			msg.Bcc=txtBCC.Text;
//			msg.Subject=txtSubject.Text;
			msg.From=from;
			msg.To=to;
			msg.Cc=cc;
			msg.Bcc=bcc;
			msg.Subject=subject;
			msg.BodyFormat=MailFormat.Html;
			notes[0]=RemoveSymbols(notes[0]);
			msg.Body="<html><body><Table><tr><td>"+notes[0]+"</td></tr></table></body></html>";//"<H1>HHHHHHHHHH</H1>";//notes;			

			SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"];		
			//SmtpMail.SmtpServer.Insert(0,System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"]);
			try
			{
				SmtpMail.Send(msg);
			}
			catch(Exception ex)
			{
				Response.Write(ex.InnerException);
			}
		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			//SendMail();
		}
		//----------------------------------------------------------------------

		public string RemoveSymbols(string NoteBody)
		{
			NoteBody = NoteBody.Replace("%25","%");
			NoteBody = NoteBody.Replace("%20"," ");
			NoteBody = NoteBody.Replace("%21","!");
			NoteBody = NoteBody.Replace("%23","#");
			NoteBody = NoteBody.Replace("%24","$");
			NoteBody = NoteBody.Replace("%5E","^");
			NoteBody = NoteBody.Replace("%26","&");
			NoteBody = NoteBody.Replace("%29",")");
			NoteBody = NoteBody.Replace("%28","(");
			NoteBody = NoteBody.Replace("%7C","|");
			NoteBody = NoteBody.Replace("%3B",";");
			NoteBody = NoteBody.Replace("%3F","?");
			NoteBody = NoteBody.Replace("%3B",";");
			NoteBody = NoteBody.Replace("%2C",",");
			NoteBody = NoteBody.Replace("%3A",":");
			NoteBody = NoteBody.Replace("%3D","=");
			NoteBody = NoteBody.Replace("%5D","]");
			NoteBody = NoteBody.Replace("%5B","[");
			NoteBody = NoteBody.Replace("%7D","}");
			NoteBody = NoteBody.Replace("%7B","{");
			NoteBody = NoteBody.Replace("%7E","~");
			NoteBody = NoteBody.Replace("%22","\"");
			
			NoteBody = NoteBody.Replace("%27","'");
			NoteBody = NoteBody.Replace("%5C","\\");
			NoteBody = NoteBody.Replace("%0D%0A","\n");
			NoteBody = NoteBody.Replace("%0D%","\n");
			NoteBody = NoteBody.Replace("%0A","\n");
			NoteBody = NoteBody.Replace("%3C","<");
			NoteBody = NoteBody.Replace("%3E",">");
			NoteBody = NoteBody.Replace("@@0937107@@","&");
			return NoteBody;
		}
																

//		[Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
//		public void setNotesSession(string val)
//		{
//			Session["NotesSession"]=val;
//		}
//		[Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
//		public void ChangeFTBStatus(bool flag)
//		{
//			FreeTextBox1.ReadOnly=flag;
//		}

        //[Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
        //protected void ddlFilterEmployees_SelectedIndexChanged()
        //{
        //    Session["EmployeesFilter"] = ddlFilterEmployees.SelectedValue;
        //    BindEmployees();
        //}
}
	
}
