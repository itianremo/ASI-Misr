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

namespace TSN.ERP.WebGUI
{
	/// <summary>
	/// Summary description for Assignments.
	/// </summary>
	public partial class Assignments : System.Web.UI.Page
	{
		protected TSN.ERP.SharedComponents.Data.dsAccDailyEntries dsAccDailyEntries;
		protected System.Data.DataView dvAssignments;
		protected TSN.ERP.SharedComponents.Data.dsAssignments dsAssignments;
		protected TSN.ERP.SharedComponents.Data.dsTasks dsTasks;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				//Navigation.BaseObject.GeneralWSObject.ListNote();
				if(!Page.IsPostBack)
				{
					GetAccountabilityEntries();
					BindData();
				}
			}
			catch(Exception ex)
			{
            // Response.Write(ex.ToString());
			}
		}

		private void GetAccountabilityEntries()
		{
			int assignmentID=int.Parse(Request.QueryString["assignID"]);
			ViewState["assignmentID"]=assignmentID;
			dsAccDailyEntries.Clear();
			this.dsAccDailyEntries.Merge(((Navigation.BaseObject) Session[ "navigation" ]).AccountabilityWSObject.GetAssigmentAccountability(assignmentID));
		}

		private void BindData()
		{			
			//Getting basic information that will be displayed into 'dgAssignments' datagrid
			this.dvAssignments.Table=this.dsAccDailyEntries.Tables[0];
			this.dvAssignments.Sort="AccountabilityDate";
			this.dgAssignments.DataSource=this.dvAssignments;
			this.dgAssignments.DataBind();

			//---------------------------------------------------------------------------
			//Displaying data related to assignment into textboxes fields
			//---------------------------------------------------------------------------

			//Getting 'From Date' & 'To Date' from 'dvAssignments'
			int rowsCount=this.dvAssignments.Table.Rows.Count;
			if(rowsCount > 0)
			{
				DateTime dtFrom=(DateTime) dvAssignments[0]["AccountabilityDate"];
				DateTime dtTo=(DateTime)dvAssignments[rowsCount-1]["AccountabilityDate"];
				this.txtFromDate.Text=dtFrom.ToString("d");
				this.txtToDate.Text=dtTo.ToString("d");
				//Getting 'Total' Sum of spent times on specified assignment
				DataColumn dcTotalUnits=new DataColumn("TotalUnits",typeof(float),"sum(AccountabilityValue)");
				this.dsAccDailyEntries.Tables[0].Columns.Add(dcTotalUnits);
				this.txtTotalsUnits.Text=dsAccDailyEntries.Tables[0].Rows[0]["TotalUnits"].ToString();

				//Getting TaskID of selected AssignmentID, which will be used to get needed Task information
				int assignmentID=(int)ViewState["assignmentID"];
				this.dsAssignments.Clear();
				this.dsAssignments.Merge(((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewAssignmentData(assignmentID));
			
				string assignmentName=Request.QueryString["assignName"];
				this.txtAssignmentName.Text=assignmentName;
			
				//Getting Task information
				int taskID=(int)this.dsAssignments.Tables[0].Rows[0]["TaskID"];
				this.dsTasks.Clear();
				this.dsTasks.Merge(((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewTask(taskID));
				TSN.ERP.SharedComponents.Data.dsTasks.GEN_TasksRow taskRow=(TSN.ERP.SharedComponents.Data.dsTasks.GEN_TasksRow)dsTasks.Tables[0].Rows[0];
				decimal taskEstimates=0;
				string taskDescription =(string)this.dsTasks.Tables[0].Rows[0]["TaskDesc"];
				this.txtAssignementDescription.Text=taskDescription;
			
				DateTime taskDueDate=DateTime.Now,taskCompletedDate=DateTime.Now;
				if(!taskRow.IsTaskDurationNull())
				{
					taskEstimates=(decimal)dsTasks.Tables[0].Rows[0]["TaskDuration"];
				}
				this.txtEstimates.Text=taskEstimates.ToString();
				if(!taskRow.IsTaskEndDateNull())
				{
					taskDueDate=(DateTime)dsTasks.Tables[0].Rows[0]["TaskEndDate"];
					//taskDueDate=(DateTime)dsAccDailyEntries.Tables[0].Rows[0]["TaskEndDate"];
					this.txtDueDate.Text=taskDueDate.ToString("d");
				
				}
				else
				{
					this.txtDueDate.Text="/ /";
				}
				if(!taskRow.IsTaskCloseDateNull())
				{
					// updated By: Sayed Moawad 19/06/2008 
					
					if(dsTasks.Tables[0].Rows[0]["TaskStatus"].ToString()=="1")//opened task
					{
						this.txtCompleted.Text="/ /";
					}
					else
					{
						// end of update
						taskCompletedDate=(DateTime)dsTasks.Tables[0].Rows[0]["TaskCloseDate"];
						//taskCompletedDate=(DateTime)dsAccDailyEntries.Tables[0].Rows[0]["TaskCloseDate"];
						this.txtCompleted.Text=taskCompletedDate.ToString("d");
					}
				}
				else
				{
					this.txtCompleted.Text="/ /";
				}

				if(dsTasks.Tables[0].Rows[0]["projectID"] != DBNull.Value && Convert.ToInt32(dsAssignments.Tables[0].Rows[0]["AssignmentStatus"]) == 3)
				{
					DateTime dt =  ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.GetMaxAssTransDate(assignmentID);
					this.txtCompleted.Text=dt.ToString("d");
				}
			}
			else
			{
				int assignmentID=(int)ViewState["assignmentID"];
				this.dsAssignments.Clear();
				this.dsAssignments.Merge(((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewAssignmentData(assignmentID));

				string assignmentName=Request.QueryString["assignName"];
				this.txtAssignmentName.Text=assignmentName;
			
				//Getting Task information
				int taskID=(int)this.dsAssignments.Tables[0].Rows[0]["TaskID"];
				this.dsTasks.Clear();
				this.dsTasks.Merge(((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewTask(taskID));
				TSN.ERP.SharedComponents.Data.dsTasks.GEN_TasksRow taskRow=(TSN.ERP.SharedComponents.Data.dsTasks.GEN_TasksRow)dsTasks.Tables[0].Rows[0];
				string taskDescription =(string)this.dsTasks.Tables[0].Rows[0]["TaskDesc"];
				this.txtAssignementDescription.Text=taskDescription;
				//if(dsTasks.Tables[0].Rows[0]["TaskStartDate"]!=System.DBNull.Value && dsTasks.Tables[0].Rows[0]["TaskEndDate"]!=System.DBNull.Value)
				//{
				string TaskStartDate = "", TaskEndDate = "", TaskCloseDate = "";
				if(dsTasks.Tables[0].Rows[0]["TaskStartDate"] != DBNull.Value)
				{
					TaskStartDate = ((DateTime)dsTasks.Tables[0].Rows[0]["TaskStartDate"]).ToString("d");
				}
				if(dsTasks.Tables[0].Rows[0]["TaskEndDate"] != DBNull.Value)
				{
					TaskEndDate = ((DateTime)dsTasks.Tables[0].Rows[0]["TaskEndDate"]).ToString("d");
				}
				if(dsTasks.Tables[0].Rows[0]["TaskCloseDate"] != DBNull.Value)
				{
					TaskCloseDate = ((DateTime)dsTasks.Tables[0].Rows[0]["TaskCloseDate"]).ToString("d");
				}
//					if(TaskStartDate.Substring(9,10)==" ")
//					{
//						this.txtFromDate.Text =  TaskStartDate.Substring(0,10);
				this.txtFromDate.Text =  TaskStartDate;
//					}
//					else
//					{
//						this.txtFromDate.Text =  TaskStartDate.Substring(0,9);
//					}
//					if(TaskEndDate.Substring(9,10)==" ")
//					{
//						this.txtToDate.Text =  TaskEndDate.Substring(0,10);
				this.txtToDate.Text =  TaskEndDate;
//					}
//					else
//					{
//						this.txtToDate.Text =  TaskEndDate.Substring(0,9);
//					}
			
					this.txtEstimates.Text = dsTasks.Tables[0].Rows[0]["TaskDuration"].ToString();
				// updated By: Sayed Moawad 19/06/2008 
					
				if(dsTasks.Tables[0].Rows[0]["TaskStatus"].ToString()=="1")//opened task
				{
					this.txtCompleted.Text="/ /";
				}
				else
				{
					// end of update
					this.txtCompleted.Text = TaskCloseDate;
				}

				if(dsTasks.Tables[0].Rows[0]["projectID"] != DBNull.Value  && Convert.ToInt32(dsAssignments.Tables[0].Rows[0]["AssignmentStatus"]) == 3)
				{
					DateTime dt =  ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.GetMaxAssTransDate(assignmentID);
					this.txtCompleted.Text=dt.ToString("d");
				}

				//}

			}
		}
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
			this.dsAccDailyEntries = new TSN.ERP.SharedComponents.Data.dsAccDailyEntries();
			this.dvAssignments = new System.Data.DataView();
			this.dsAssignments = new TSN.ERP.SharedComponents.Data.dsAssignments();
			this.dsTasks = new TSN.ERP.SharedComponents.Data.dsTasks();
			((System.ComponentModel.ISupportInitialize)(this.dsAccDailyEntries)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvAssignments)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsAssignments)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTasks)).BeginInit();
			// 
			// dsAccDailyEntries
			// 
			this.dsAccDailyEntries.DataSetName = "dsAccDailyEntries";
			this.dsAccDailyEntries.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// dvAssignments
			// 
			this.dvAssignments.Sort = "AccountabilityDate";
			this.dvAssignments.Table = this.dsAccDailyEntries.GEN_AccDailyEntries;
			// 
			// dsAssignments
			// 
			this.dsAssignments.DataSetName = "dsAssignments";
			this.dsAssignments.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dsTasks
			// 
			this.dsTasks.DataSetName = "dsTasks";
			this.dsTasks.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.dsAccDailyEntries)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvAssignments)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsAssignments)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTasks)).EndInit();

		}
		#endregion

		
	}
}
