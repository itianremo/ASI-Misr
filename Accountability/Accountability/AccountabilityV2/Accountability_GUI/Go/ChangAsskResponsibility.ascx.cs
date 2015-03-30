namespace TSN.ERP.WebGUI.Go
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Globalization;
	using System.Text.RegularExpressions;

	/// <summary>
	///	Use this control to do the following
	///	<li>Create or edit project task</li>
	///	<li>Create, edit or score employee's assignment</li>
	/// </summary>
	public partial class ChangAsskResponsibility : System.Web.UI.UserControl
	{
		protected TSN.ERP.SharedComponents.Data.dsAssignments dsAssignments;
		protected TSN.ERP.SharedComponents.Data.dsTasks dsTasks;
		protected System.Web.UI.HtmlControls.HtmlInputText Text1;
		protected TSN.ERP.SharedComponents.Data.dsResponsblities dsResponsblities1;
		protected static CTask task;
		//--------------------------------------------------------------
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dsAssignments = new TSN.ERP.SharedComponents.Data.dsAssignments();
			this.dsTasks = new TSN.ERP.SharedComponents.Data.dsTasks();
			this.dsResponsblities1 = new TSN.ERP.SharedComponents.Data.dsResponsblities();
			((System.ComponentModel.ISupportInitialize)(this.dsAssignments)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTasks)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsResponsblities1)).BeginInit();
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
			// 
			// dsResponsblities1
			// 
			this.dsResponsblities1.DataSetName = "dsResponsblities";
			this.dsResponsblities1.Locale = new System.Globalization.CultureInfo("ar-EG");
			((System.ComponentModel.ISupportInitialize)(this.dsAssignments)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTasks)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsResponsblities1)).EndInit();

		}
		#endregion
		//--------------------------------------------------------------
		#region page load
		/// <summary>
		/// In the load of the task control, we check the mode we are in
		/// <br>In fact we have 5 modes </br>
		/// <li>Add project task</li>
		/// <li>Add employee's task</li>
		/// <li>Edit project task</li>
		/// <li>Edit employee's task</li>
		/// <li>Score employee's task </li>
		/// <br>And according to the mode, We begin to configure the control</br>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			TSN.ERP.SharedComponents.Data.dsTasks.GEN_TasksRow row = null;
			try
			{
				if( !IsPostBack )
					LoadResponsibilities();

				// USA data format
				IFormatProvider culture = new CultureInfo("en-US",true);
				// get the from mode
				task = (CTask)Session["task"];
				switch (task.mode)
				{
					case 4 : // in case of editing employee task 
						//lblProjectName.Text = task.projectName;
						lblEmpName.Text = task.empName;
						if (task.respID != -1)
						{
							// get employee assignment
							Navigation.BaseObject.SafeMerge(dsAssignments,((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewAssignmentData(task.assignmentID));
							//lblRespName.Text = task.respName;
							lblRespName.Text = DrpDwnResp.Items.FindByValue( dsAssignments.GEN_Assignments[ 0 ].ResponsID.ToString()).Text;
						}
						dsTasks.Clear();
						Navigation.BaseObject.SafeMerge(dsTasks,((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewAssignmentTask(task.assignmentID));
						if ( dsTasks.GEN_Tasks.Rows.Count != 0 )
						{
							row
								=(TSN.ERP.SharedComponents.Data.dsTasks.GEN_TasksRow) dsTasks.GEN_Tasks.Rows[0];
							txtName.Text = row.TaskName;
							
						}
						
						break;
						
				}
			}
			catch(Exception ex)
			{
				Response.Write(ex.Message);
			}
		}
			#endregion
		//--------------------------------------------------------------
		#region Change Responsibility
			/// <summary>
			/// change existing employee's assignment 's respnsibility
			/// </summary>
		protected void ChangeAssignmentResponsibility( object sender, System.EventArgs e )
		{
			((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ChangeResponsbility(  task.assignmentID , Convert.ToInt32( DrpDwnResp.SelectedValue ) );
			txtClose.Value ="1";
			lblMsg.Text = "Responisbility changed";	

		}
		#endregion
		//--------------------------------------------------------------
		#region clear form
		/// <summary>
		/// Reset form
		/// </summary>
		private void ClearForm()
		{
			txtName.Text = "";
		}
		#endregion
		//--------------------------------------------------------------
		
		private void LoadResponsibilities()
		{
			task = (CTask)Session["task"];
			
			TSN.ERP.SharedComponents.Data.dsEmployee dsEmp = new TSN.ERP.SharedComponents.Data.dsEmployee();
			Navigation.BaseObject.SafeMerge( dsEmp , ((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListSingleEmployeeData(task.empID));
			
			if ( dsEmp != null && dsEmp.GEN_Employees.Rows.Count != 0 )
			{
				Navigation.BaseObject.SafeMerge( dsResponsblities1 , ((Navigation.BaseObject) Session[ "navigation" ]).JobTiltesWsObject.ListActiveJobResponsbilities( dsEmp.GEN_Employees[ 0 ].JobTitleID));
				DrpDwnResp.DataBind();
				//DrpDwnResp.SelectedValue =  task.respID.ToString();
			}
		
		}

	}
}
