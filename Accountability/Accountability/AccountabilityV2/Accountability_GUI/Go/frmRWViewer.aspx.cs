using System;
using System.Configuration;
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

namespace TSN.ERP.WebGUI.Go
{
	/// <summary>
	/// Summary description for ReportViewer.
	/// </summary>
	public partial class frmRWViewer : System.Web.UI.Page
	{
		protected TSN.ERP.WebGUI.Go.rep.dsTotalAccSheet dsTotalAccSheet;
		protected TSN.ERP.SharedComponents.Data.dsAccountabilitySheet dsAccountabilitySheet;
		//protected Stimulsoft.Report.Web.StiWebViewer StiWebViewer1;
		protected TSN.ERP.SharedComponents.Data.DsTaskSummReport dsTaskSummReport1;
		protected System.Data.DataSet dataSetEmpData;
		protected System.Data.DataTable dataTable2;
		protected System.Data.DataColumn dataColumn11;
		protected System.Data.DataColumn dataColumn12;
		protected System.Data.DataColumn dataColumn13;
		protected System.Data.DataColumn dataColumn14;
		protected System.Data.DataColumn dataColumn15;
		protected System.Data.DataSet dataSetNotes;
		protected System.Data.DataTable dataTable3;
		protected System.Data.DataColumn dataColumn16;
		protected TSN.ERP.SharedComponents.Data.dsTeams dsTeams1;
		protected TSN.ERP.SharedComponents.Data.dsEmployee dsEmployee1;
		protected System.Data.DataColumn dataColumn17;
		
	
		protected void Page_Load(object sender, System.EventArgs e)
		{

            TextBoxFrom.Attributes.Add("readonly", "true");
            TextBoxTo.Attributes.Add("readonly", "true");
			
			int reportType = int.Parse(Request["rpID"]);
		
			#region  Accountability sheet for only one given employee

			if (reportType == 1 )
			{
				if(!IsPostBack )
				{
					Panel2.Visible = true;
					Panel1.Visible = false;
					BindEmployees(1);
				}
			}
			#endregion

			#region  Total accountability sheet, for all employees
	    	else if (reportType == 2)
			{

				if(!IsPostBack )
				{
					Panel2.Visible = true;
					Panel1.Visible = false;
					Label1.Visible = false;
					Label3.Visible = false;
					Label4.Visible = false;
					DrpDwnMnagedEmp.Visible = false;
					lstViewMode.Visible = false;
					CheckBox1.Visible = false;
				}	
			}	
			

			#endregion

			#region  Task Summary sheet for given employee
			if (reportType == 3)
			{
				if( !IsPostBack )
				{
					Panel1.Visible = true;
					Panel2.Visible = false;
					BindEmployees(3);
					Navigation.BaseObject.SafeMerge(dsTeams1,((Navigation.BaseObject) Session[ "navigation" ]).TeamsWSObject.ListTeams());
					DropDownListTeams.DataBind();
					//Adding null team in the first run to teams drop down list:
					ListItem LI = new ListItem("","-1");
					DropDownListTeams.Items.Insert(0,LI);
					if( DropDownListTeams.Items.Count != 0 )
					{
						Navigation.BaseObject.SafeMerge(dsEmployee1,((Navigation.BaseObject) Session[ "navigation" ]).TeamsWSObject.ListTeamEmployees( int.Parse( DropDownListTeams.Items[ 0 ].Value ) ));
                        //Sort Employees DataSet//////////////////////////////////
                        MasterMethods master = new MasterMethods();
                        DataView dvEmp = dsEmployee1.Tables[0].DefaultView;
                        dvEmp.Sort = "FirstName, MiddleName, LastName";
                        dsEmployee1.Tables.Clear();
                        dsEmployee1.Tables.Add(master.CreateTableFromView(dvEmp));
                        //////////////////////////////////////////////////////////
						DropDownListEmp.DataBind();
					}

					// check if the user is admin
					if ( ! ((Navigation.BaseObject)Page.Session[ "navigation" ]).SecInfo.IsAdministrator )
					{
						RadioButtonListEmp.Visible = false;
						DropDownListTeams.Visible = false;
						DropDownListEmp.Visible = false;
					}
				}

				
			}
			#endregion

		}
		//--------------------------------------------------------------------
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
			this.dsTotalAccSheet = new TSN.ERP.WebGUI.Go.rep.dsTotalAccSheet();
			this.dsAccountabilitySheet = new TSN.ERP.SharedComponents.Data.dsAccountabilitySheet();
			this.dsTaskSummReport1 = new TSN.ERP.SharedComponents.Data.DsTaskSummReport();
			this.dataSetEmpData = new System.Data.DataSet();
			this.dataTable2 = new System.Data.DataTable();
			this.dataColumn11 = new System.Data.DataColumn();
			this.dataColumn12 = new System.Data.DataColumn();
			this.dataColumn13 = new System.Data.DataColumn();
			this.dataColumn14 = new System.Data.DataColumn();
			this.dataColumn15 = new System.Data.DataColumn();
			this.dataSetNotes = new System.Data.DataSet();
			this.dataTable3 = new System.Data.DataTable();
			this.dataColumn16 = new System.Data.DataColumn();
			this.dataColumn17 = new System.Data.DataColumn();
			this.dsTeams1 = new TSN.ERP.SharedComponents.Data.dsTeams();
			this.dsEmployee1 = new TSN.ERP.SharedComponents.Data.dsEmployee();
			((System.ComponentModel.ISupportInitialize)(this.dsTotalAccSheet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsAccountabilitySheet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTaskSummReport1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetEmpData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetNotes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTeams1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsEmployee1)).BeginInit();
			// 
			// dsTotalAccSheet
			// 
			this.dsTotalAccSheet.DataSetName = "dsTotalAccSheet";
			this.dsTotalAccSheet.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dsAccountabilitySheet
			// 
			this.dsAccountabilitySheet.DataSetName = "dsAccountabilitySheet";
			this.dsAccountabilitySheet.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// dsTaskSummReport1
			// 
			this.dsTaskSummReport1.DataSetName = "DsTaskSummReport";
			this.dsTaskSummReport1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dataSetEmpData
			// 
			this.dataSetEmpData.DataSetName = "dsEmpData";
			this.dataSetEmpData.Locale = new System.Globalization.CultureInfo("en-US");
			this.dataSetEmpData.Tables.AddRange(new System.Data.DataTable[] {
																				this.dataTable2});
			// 
			// dataTable2
			// 
			this.dataTable2.Columns.AddRange(new System.Data.DataColumn[] {
																			  this.dataColumn11,
																			  this.dataColumn12,
																			  this.dataColumn13,
																			  this.dataColumn14,
																			  this.dataColumn15});
			this.dataTable2.TableName = "EmpData";
			// 
			// dataColumn11
			// 
			this.dataColumn11.ColumnName = "EmpName";
			// 
			// dataColumn12
			// 
			this.dataColumn12.ColumnName = "Title";
			// 
			// dataColumn13
			// 
			this.dataColumn13.ColumnName = "Division";
			// 
			// dataColumn14
			// 
			this.dataColumn14.ColumnName = "FromDate";
			// 
			// dataColumn15
			// 
			this.dataColumn15.ColumnName = "ToDate";
			// 
			// dataSetNotes
			// 
			this.dataSetNotes.DataSetName = "dsNotes";
			this.dataSetNotes.Locale = new System.Globalization.CultureInfo("en-US");
			this.dataSetNotes.Tables.AddRange(new System.Data.DataTable[] {
																			  this.dataTable3});
			// 
			// dataTable3
			// 
			this.dataTable3.Columns.AddRange(new System.Data.DataColumn[] {
																			  this.dataColumn16,
																			  this.dataColumn17});
			this.dataTable3.TableName = "Table";
			// 
			// dataColumn16
			// 
			this.dataColumn16.ColumnName = "AccountabilityDate";
			this.dataColumn16.DataType = typeof(System.DateTime);
			// 
			// dataColumn17
			// 
			this.dataColumn17.ColumnName = "NoteBody";
			// 
			// dsTeams1
			// 
			this.dsTeams1.DataSetName = "dsTeams";
			this.dsTeams1.EnforceConstraints = false;
			this.dsTeams1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dsEmployee1
			// 
			this.dsEmployee1.DataSetName = "dsEmployee";
			this.dsEmployee1.Locale = new System.Globalization.CultureInfo("ar-EG");
			((System.ComponentModel.ISupportInitialize)(this.dsTotalAccSheet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsAccountabilitySheet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTaskSummReport1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetEmpData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetNotes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTeams1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsEmployee1)).EndInit();

		}
		#endregion

		#region GetTaskSummary
		void GetTaskSummary( )
		{
			dataSetEmpData.Clear();

			int impID;
			// get selected employee ID
			if (  ((Navigation.BaseObject)Page.Session[ "navigation" ]).SecInfo.IsAdministrator )
			{

				if( RadioButtonListEmp.SelectedValue == "1" )
					impID = int.Parse( DrpDwnTskEmplyees.SelectedValue );
				else
				{
					if( DropDownListEmp.SelectedValue != "" )
						impID = int.Parse( DropDownListEmp.SelectedValue );
					else
						return;
				}
			}
			else
				impID = int.Parse( DrpDwnTskEmplyees.SelectedValue );

			DateTime fromDate ;
			DateTime toDate   ;
			//fromDate = Convert.ToDateTime( TextBoxFrom.Text );
			//toDate = Convert.ToDateTime( TextBoxTo.Text );

			if(TextBoxFrom.Text.Trim()=="")
			{
				Navigation.BaseObject.showMessage( "Please select From date" , this.Page );
				return;
			}
			else if(TextBoxTo.Text.Trim()=="")
			{
				
				Navigation.BaseObject.showMessage( "Please select To date" , this.Page );
				return;
				
			}
			else
			{
				fromDate = Convert.ToDateTime( TextBoxFrom.Text );
				toDate	 = Convert.ToDateTime( TextBoxTo.Text );

				if(fromDate > toDate)
				{
					Navigation.BaseObject.showMessage( "Start date can not be greater than end date" , this.Page );
					return;

				}

			}
													
			Navigation.BaseObject.SafeMerge( dsTaskSummReport1 ,((Navigation.BaseObject) Session[ "navigation" ]).AccountabilityWSObject.GetEmployeeTaskSummary( impID , fromDate , toDate ));
//			if( dsTaskSummReport1 != null  && dsTaskSummReport1.GEN_Tasks.Rows.Count != 0 )
//			{
//				DataRow row = dataSetEmpData.Tables[ 0 ].NewRow();
//				row[ 0 ] = dsTaskSummReport1.GEN_Tasks[ 0 ].Fullname;
//				row[ 1 ] = dsTaskSummReport1.GEN_Tasks[ 0 ].JobName;
//				row[ 2 ] = dsTaskSummReport1.GEN_Tasks[ 0 ].CEName;
//				row[ 3 ] = fromDate.ToShortDateString();
//				row[ 4 ] = toDate.ToShortDateString();
//				dataSetEmpData.Tables[ 0 ].Rows.Add( row );
//			}

			DataSet dsEmpSummarizedData = ((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListEmployeeSummarizedData(impID);

			DataRow row = dataSetEmpData.Tables[ 0 ].NewRow();
			row[ 0 ] = dsEmpSummarizedData.Tables[0].Rows[0]["Fullname"];
			row[ 1 ] = dsEmpSummarizedData.Tables[0].Rows[0]["JobName"];
			row[ 2 ] = dsEmpSummarizedData.Tables[0].Rows[0]["CEName"];
			row[ 3 ] = fromDate.ToShortDateString();
			row[ 4 ] = toDate.ToShortDateString();
			dataSetEmpData.Tables[ 0 ].Rows.Add( row );
			
			if( RadioButtonListNotes.SelectedValue == "1" )
			  Navigation.BaseObject.SafeMerge(  dataSetNotes , ((Navigation.BaseObject) Session[ "navigation" ]).AccountabilityWSObject.GetEmployeeNotesInInterval( impID , fromDate , toDate ));
			

			string toolValue =  ConfigurationSettings.AppSettings[ "reportingTool" ];

			// for StimulSoft
			if ( toolValue == "2" )
			{
					
				#region StimulSoft
					
				if ( StiWebViewer1.IsImageRequest )  return;
				if (dsTaskSummReport1 != null )
				{
					
					Stimulsoft.Report.StiReport streprt1 = new Stimulsoft.Report.StiReport();
					string path =  Server.MapPath( "rep/stiRepTskSummary.mrt" );
					try
					{
						streprt1.Load(path );
					}
					catch( Exception ee)
					{
						string s = ee.Message;
					}
                    //streprt1.Pages[1].Width = 5;
                    //streprt1.Pages[1].Height = 5;
                    // streprt1.Pages[1].Orientation=Stimulsoft.Report.Components.StiPageOrientation.Landscape;
					streprt1.RegData ( dsTaskSummReport1 ); 
					streprt1.RegData(  dataSetEmpData ); 
					dataSetNotes=DecryptNotes(dataSetNotes);
					streprt1.RegData(  dataSetNotes );
					StiWebViewer1.Report = streprt1;
					StiWebViewer1.Visible = true;				
				}
				#endregion 
			}
		}

		#endregion

	
		protected void DropDownListTeams_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
			Navigation.BaseObject.SafeMerge(dsEmployee1,((Navigation.BaseObject) Session[ "navigation" ]).TeamsWSObject.ListTeamEmployees( int.Parse( DropDownListTeams.SelectedValue ) ));
            //Sort Employees DataSet//////////////////////////////////
            MasterMethods master = new MasterMethods();
            DataView dvEmp = dsEmployee1.Tables[0].DefaultView;
            dvEmp.Sort = "FirstName, MiddleName, LastName";
            dsEmployee1.Tables.Clear();
            dsEmployee1.Tables.Add(master.CreateTableFromView(dvEmp));
            //////////////////////////////////////////////////////////
			DropDownListEmp.DataBind();
		}

		protected void RadioButtonListEmp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if( RadioButtonListEmp.SelectedValue == "1" ) 
			{
				DropDownListTeams.Enabled = false;
				DropDownListEmp.Enabled   = false;	
				DrpDwnTskEmplyees.Enabled = true;
			}
			else 
			{
				DropDownListTeams.Enabled = true;
				DropDownListEmp.Enabled   = true;	
				DrpDwnTskEmplyees.Enabled = false;
			}
		}

		#region this part to decrypt the notes body to view it in the correct way 

		public DataSet DecryptNotes(DataSet ds)
		{
			//in case task summery report

			foreach(DataRow dr in ds.Tables[0].Rows)
			{
				dr["NoteBody"]= RemoveSimboles(dr["NoteBody"].ToString());
			}
			return ds;
		}
		public TSN.ERP.SharedComponents.Data.dsAccountabilitySheet DecryptWeeklyNotes(TSN.ERP.SharedComponents.Data.dsAccountabilitySheet ds)
		{
			//in case weekly report for single employee
			foreach(DataRow dr in ds.Tables[3].Rows)
			{
				dr["NoteBody"]= RemoveSimboles(dr["NoteBody"].ToString());
					
			}
			return ds;		
		}

		public string RemoveSimboles(string NoteBody)
		{
			NoteBody = NoteBody.Replace("%20"," ");
			NoteBody = NoteBody.Replace("%21","!");
			NoteBody = NoteBody.Replace("%23","#");
			NoteBody = NoteBody.Replace("%24","$");
			NoteBody = NoteBody.Replace("%25","%");
			NoteBody = NoteBody.Replace("%5E","^");
			NoteBody = NoteBody.Replace("%26","&");
			NoteBody = NoteBody.Replace("%29",")");
			NoteBody = NoteBody.Replace("%28","(");
			NoteBody = NoteBody.Replace("%7C","|");
			NoteBody = NoteBody.Replace("%3B",";");
			NoteBody = NoteBody.Replace("%3F","?");
			NoteBody = NoteBody.Replace("%3B",",");
			NoteBody = NoteBody.Replace("%2C","/");
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
	

		#endregion

		protected void ButtonTskSumm_Click(object sender, ImageClickEventArgs e)
		{
			GetTaskSummary( );	
		}


		#region Get all employees whom current user has access upon.
		/// <summary>
		/// Returns all employees whom current user has permessions to view their data.
		/// </summary>
		/// <returns></returns>
		
		public void BindEmployees(int reportType )
		{
			
			DataSet dsEmployee =  ((Navigation.BaseObject)Session["navigation"]).AccountabilityWSObject.ViewAccountabilityEmployees();
            //Sort Employees DataSet//////////////////////////////////
            MasterMethods master = new MasterMethods();
            DataView dvEmp = dsEmployee.Tables[0].DefaultView;
            dvEmp.Sort = "FirstName, MiddleName, LastName";
            dsEmployee.Tables.Clear();
            dsEmployee.Tables.Add(master.CreateTableFromView(dvEmp));
            //////////////////////////////////////////////////////////
			
			if ( reportType == 1 )
			{
				DrpDwnMnagedEmp.DataSource = dsEmployee;
				DrpDwnMnagedEmp.DataTextField = "FullName";
				DrpDwnMnagedEmp.DataValueField = "ContactID";
				DrpDwnMnagedEmp.DataBind();
			}
			else if ( reportType == 3 )
			{
				DrpDwnTskEmplyees.DataSource = dsEmployee;
				DrpDwnTskEmplyees.DataTextField = "FullName";
				DrpDwnTskEmplyees.DataValueField = "ContactID";
				DrpDwnTskEmplyees.DataBind();
			}
			
		}
		#endregion

		#region GetReport 
		protected void ButtonGetRep_Click(object sender, ImageClickEventArgs e)
		{
			int reportType = int.Parse(Request["rpID"]);

			if( TextBoxCalender.Text.Trim() == "" )
			{
				Navigation.BaseObject.showMessage( "Please select a date" , this.Page );
				return;
			}

			if (reportType == 1)
				
				GetAccountabilityEmployeeSheet();
			else if (reportType == 2)
				
				GetTotalAccountabilitySheet();
			
		}
		
		#endregion

		#region GetAccountabilityEmployeeSheet
		void GetAccountabilityEmployeeSheet( )
		{
			bool showOffDays;
			int viewMode;
			showOffDays= CheckBox1.Checked;
			viewMode = int.Parse( lstViewMode.Items[ lstViewMode.SelectedIndex ].Value );
			int RowsCount = 0;
			DataRow TaskRow = null;
			if(viewMode==40)
			{
	
	
				Navigation.BaseObject.SafeMerge(dsAccountabilitySheet,((Navigation.BaseObject) Session[ "navigation" ]).AccountabilityWSObject.GetAccSheet(int.Parse(DrpDwnMnagedEmp.SelectedValue),DateTime.Parse(TextBoxCalender.Text.Trim()),10,showOffDays));
				RowsCount = dsAccountabilitySheet.Tables[0].Rows.Count-1;
				for(int i= RowsCount; i>=0; i--)
				{
					TaskRow = dsAccountabilitySheet.Tables[0].Rows[i];
					if (TaskRow["RecoredType"].ToString() != "10") 
						dsAccountabilitySheet.Tables[0].Rows.RemoveAt(i);
				}
			}
			else
			{
				Navigation.BaseObject.SafeMerge(dsAccountabilitySheet,((Navigation.BaseObject) Session[ "navigation" ]).AccountabilityWSObject.GetAccSheet(int.Parse(DrpDwnMnagedEmp.SelectedValue),DateTime.Parse(TextBoxCalender.Text.Trim()),viewMode,showOffDays));
			}
			
								
			#region StimulSoft
					
				if ( StiWebViewer1.IsImageRequest )  return;
				if (  dsAccountabilitySheet != null )
				{
						
						
					//stiReport1["Dept"]    =	vars[3];
					//stiReport1["job"]     =	vars[4];
					//StiWebViewer1.Report = stiReport1 ;
					Stimulsoft.Report.StiReport streprt1 = new Stimulsoft.Report.StiReport();
					string path =  Server.MapPath( "rep/stiReport1.mrt" );
					streprt1.Load(path );
					//streprt1.Compile();
					//stiReport1["empName"] =	vars[2];
					dsAccountabilitySheet = DecryptWeeklyNotes(dsAccountabilitySheet);
					streprt1.RegData ( dsAccountabilitySheet ); 
					StiWebViewer1.Report = streprt1;
					StiWebViewer1.Visible = true;		
						
				}
				#endregion 
			
		}

		#endregion

		#region GetTotalAccountabilitySheet
		void GetTotalAccountabilitySheet( )
		{
			bool showOffDays;
			int viewMode;
			showOffDays= CheckBox1.Checked;
			viewMode = int.Parse( lstViewMode.Items[ lstViewMode.SelectedIndex ].Value );
						
							
			#region StimulSoft
								
			    if ( StiWebViewer1.IsImageRequest )  return;
			    if (  dsAccountabilitySheet != null )
			    {
				    Stimulsoft.Report.StiReport streprt1 = new Stimulsoft.Report.StiReport();
				    string path =  Server.MapPath( "rep/stiRepTotalAccSheet.mrt" );
				    try
				    {
					    streprt1.Load(path );
				    }
				    catch( Exception ee )
				    {
					    string s = ee.Message;
				    }
                   
                     // modified by Sayed Moawad 4/1/2010  to select active employees only as a request from Rod
				    ((Navigation.BaseObject) Session[ "navigation" ]).AccountabilityWSObject.Timeout = 10000000 ;
                    streprt1.RegData(((Navigation.BaseObject)Session["navigation"]).AccountabilityWSObject.GetTotalAccSheet(DateTime.Parse(TextBoxCalender.Text), "EmployeeStatus = 1")); 
				    StiWebViewer1.Report = streprt1;
				    StiWebViewer1.Visible = true;				
    				
			    }
            #endregion 
								
			
			
		}

		#endregion

		
	}
}
