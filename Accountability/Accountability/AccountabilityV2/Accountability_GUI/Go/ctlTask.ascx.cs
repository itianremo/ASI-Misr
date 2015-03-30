namespace TSN.ERP.WebGUI.Go
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Globalization;
	using Navigation;
	using System.Text.RegularExpressions;

	/// <summary>
	///	Use this control to do the following
	///	<li>Create or edit project task</li>
	///	<li>Create, edit or score employee's assignment</li>
	/// </summary>
	public partial class ctlTask : System.Web.UI.UserControl
	{
		protected TSN.ERP.SharedComponents.Data.dsAssignments dsAssignments;
		protected TSN.ERP.SharedComponents.Data.dsTasks dsTasks;
		protected System.Web.UI.HtmlControls.HtmlInputText Text1;
		protected static CTask task;
		TSN.ERP.SharedComponents.Data.dsTasks dsTasksTest = new TSN.ERP.SharedComponents.Data.dsTasks();
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
			((System.ComponentModel.ISupportInitialize)(this.dsAssignments)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTasks)).BeginInit();
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
			((System.ComponentModel.ISupportInitialize)(this.dsAssignments)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTasks)).EndInit();

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
            txtStartDate.Attributes.Add("readonly", "true");
            txtDueDate.Attributes.Add("readonly", "true");
			lblMsg.Text ="";
			TSN.ERP.SharedComponents.Data.dsTasks.GEN_TasksRow row = null;
			try
				{
					// USA data format
					IFormatProvider culture = new CultureInfo("en-US",true);
					// get the from mode
					task = (CTask)Session["task"];
					switch (task.mode)
					{
						case 1 :  // in case of creating project task
							lblEmp.Visible = false;
							lblEmpName.Visible = false;
							lblResp.Visible = false;
							lblRespName.Visible = false;
							lblProjectName.Text = task.projectName;
							txtScore.Enabled = false;
							break;
						case 2 : // in case of creating employee task
							lblProject.Visible = false;
							lblProjectName.Visible = false;
							lblEmpName.Text = task.empName;
							if (task.respID != -1)
							{
								lblRespName.Text = task.respName;
							}
							txtScore.Enabled = false;
							break;
						case 3 : // in case of editing project task 
							lblEmp.Visible = false;
							lblEmpName.Visible = false;
							lblResp.Visible = false;
							lblRespName.Visible = false;
							lblProjectName.Text = task.projectName;
							txtScore.Enabled = false;
							lstUnit.Enabled = false;
							dsTasks.Clear();
							Navigation.BaseObject.SafeMerge(dsTasks,((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewTask(task.taskID));
							if ( dsTasks.GEN_Tasks.Rows.Count != 0 )
							{
								row
									=(TSN.ERP.SharedComponents.Data.dsTasks.GEN_TasksRow) dsTasks.GEN_Tasks.Rows[0];
								txtName.Text = row.TaskName;
								txtDesc.Text = row.TaskDesc;
								if (row["TaskDuration"].ToString() != "")
									txtPlanned.Text = row.TaskDuration.ToString();
								lstUnit.SelectedIndex = lstUnit.Items.IndexOf(lstUnit.Items.FindByValue(row.TaskUnit.ToString()));
								if (row["TaskStartDate"].ToString() != "")
									txtStartDate.Text = row.TaskStartDate.ToString("MM/dd/yyyy");
								if (row["TaskEndDate"].ToString() != "")
									txtDueDate.Text = row.TaskEndDate.ToString("MM/dd/yyyy");
							}
							break;
						case 4 : // in case of editing employee task 
							//In case of editing employee task no need to display project name
							lblProject.Visible=false;
							lblProjectName.Visible=false;
							lblProjectName.Text = task.projectName;
							lblEmpName.Text = task.empName;
							lstUnit.Enabled = false;
							if (task.respID != -1)
							{
								lblRespName.Text = task.respName;
							}
							if (task.respName == "-1")
							{
								lblResp.Visible = false;
								lblRespName.Visible = false;
							}
							else
							{
								lblResp.Visible = true;
								lblRespName.Visible = true;
							}
							txtScore.Enabled = false;
							dsTasks.Clear();
							Navigation.BaseObject.SafeMerge(dsTasks,((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewAssignmentTask(task.assignmentID));
							if ( dsTasks.GEN_Tasks.Rows.Count != 0 )
							{
								row
									=(TSN.ERP.SharedComponents.Data.dsTasks.GEN_TasksRow) dsTasks.GEN_Tasks.Rows[0];
								txtName.Text = row.TaskName;
								txtDesc.Text = row.TaskDesc;
								if (row["TaskDuration"].ToString() != ""  )
									txtPlanned.Text = row.TaskDuration.ToString();
								lstUnit.SelectedIndex = lstUnit.Items.IndexOf(lstUnit.Items.FindByValue(row.TaskUnit.ToString()));
								if (row["TaskStartDate"].ToString() != ""  )
									txtStartDate.Text = row.TaskStartDate.ToString("MM/dd/yyyy");
								if (row["TaskEndDate"].ToString() != ""  )
									txtDueDate.Text = row.TaskEndDate.ToString("MM/dd/yyyy");
							}
							// get employee assignment
							Navigation.BaseObject.SafeMerge(dsAssignments,((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewAssignmentData(task.assignmentID));
							txtScore.Text = dsAssignments.Tables[0].Rows[0]["AssignmentScore"].ToString();
							break;
						case 5 : // in case of task scoring
							lblProjectName.Text = task.projectName;
							lblEmpName.Text = task.empName;
							lblRespName.Text = task.respName;
							txtName.Enabled = false;
							txtDesc.Enabled = false;
							txtPlanned.Enabled = false;
							lstUnit.Enabled = false;
							Navigation.BaseObject.SafeMerge(dsTasks,((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewTask(task.taskID));
							if ( dsTasks.GEN_Tasks.Rows.Count != 0 )
							{
								row
									=(TSN.ERP.SharedComponents.Data.dsTasks.GEN_TasksRow) dsTasks.GEN_Tasks.Rows[0];
								txtName.Text = row.TaskName;
								txtDesc.Text = row.TaskDesc;
								txtPlanned.Text = row.TaskDuration.ToString();
								lstUnit.SelectedIndex = lstUnit.Items.IndexOf(lstUnit.Items.FindByValue(row.TaskUnit.ToString()));
								txtStartDate.Text = row.TaskStartDate.ToString("MM/dd/yyyy");
								txtDueDate.Text = row.TaskEndDate.ToString("MM/dd/yyyy");
							}
							// get employee assignment
							Navigation.BaseObject.SafeMerge(dsAssignments,((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewAssignmentData(task.assignmentID));
							txtScore.Text = dsAssignments.Tables[0].Rows[0]["AssignmentScore"].ToString();
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
		#region save task
		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			lblMsg.Text = "";
			try
			{
				if (ValidateForm(task.mode) == "")
				{
					switch (task.mode)
					{
						case 1:
							AddProjectTask();
							break;
						case 2: 
							AddEmpTask();
							break;
						case 3 : 
							EditProjectTask();
							break;
						case 4 : 
							EditEmpTask();
							break;
						case 5:
							ScoreTask();
							break;
					}
					txtClose.Value ="1";
				}
				else
					lblMsg.Text =   ValidateForm(task.mode) ;
				
			}
			catch(Exception ex)
			{
				Response.Write(ex.Message);
				//Response.Write(((Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.LastInnerException());
			}
			
		}
		#endregion
		//--------------------------------------------------------------
		public bool IsProjectTaskExist(TSN.ERP.SharedComponents.Data.dsTasks ds,string Taskname,int ProjectID)
		{
			bool flag = false ;
											 
			foreach(DataRow dr in ds.Tables[0].Rows)
			{
				flag = true;
				if(int.Parse(dr["projectID"].ToString().Trim())== ProjectID && dr["TaskName"].ToString().ToLower()==Taskname.ToLower() )
				{
					flag = true;
					break;
				}				
				else
				{
					flag = false;
				}
			}
			return flag;
		}
		public bool IsProjectTaskExistForEdit(TSN.ERP.SharedComponents.Data.dsTasks ds,string Taskname,int ProjectID,int TaskID)
		{
			bool flag = false ;
											 
			foreach(DataRow dr in ds.Tables[0].Rows)
			{
				flag = true;
				if(int.Parse(dr["projectID"].ToString().Trim())== ProjectID && dr["TaskName"].ToString().ToLower()==Taskname.ToLower() && int.Parse(dr["TaskID"].ToString())!=TaskID)
				{
					flag = true;
					break;
				}				
				else
				{
					flag = false;
				}
			}
			return flag;
		}
		
		#region Add project task
		/// <summary>
		/// Add new project task
		/// </summary>
		private void AddProjectTask()
		{


			TSN.ERP.SharedComponents.Data.dsTasks.GEN_TasksRow row
					= dsTasks.GEN_Tasks.NewGEN_TasksRow();
				dsTasks.Clear();
				dsTasks.EnforceConstraints = false;
				// USA data format
				IFormatProvider culture = new CultureInfo("en-US",true);
				// add new project task
				row.TaskID = 10000;
				row.projectID = task.projectID;
				row.TaskName = txtName.Text;
				row.TaskDesc = txtDesc.Text;
				if (txtPlanned.Text != "")
					row.TaskDuration = Decimal.Parse(txtPlanned.Text) ;
				row.TaskUnit = int.Parse(lstUnit.SelectedValue);
				if (txtStartDate.Text != "")
					row.TaskStartDate = DateTime.Parse(txtStartDate.Text ,culture); 
				if(txtDueDate.Text != "")	
					row.TaskEndDate = DateTime.Parse(txtDueDate.Text,culture);
			////////////////////////////////////////////////////////////////////////////	
			//TSN.ERP.SharedComponents.Data.dsTasks dsTasksTest = new TSN.ERP.SharedComponents.Data.dsTasks();
			BaseObject.SafeMerge(dsTasksTest,((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewTaskByProject(task.projectID));
			bool Flage = IsProjectTaskExist(dsTasksTest,txtName.Text.Trim(),task.projectID);
			///////////////////////////////////////////////////////////////////////////
			if(Flage)
			{
				lblMsg.Text ="This task already exists, please try another one";

			}
			else
			{
				dsTasks.Tables[0].Rows.Add(row);
				((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.AddTasks(dsTasks);
				lblMsg.Text = "Task saved";
				ClearForm();

			}
		}
		#endregion
		//--------------------------------------------------------------
		#region Add employee task
		/// <summary>
		/// Add new employee assignment
		/// </summary>
		private void AddEmpTask()
		{
				TSN.ERP.SharedComponents.Data.dsTasks.GEN_TasksRow row
					= dsTasks.GEN_Tasks.NewGEN_TasksRow();
				dsTasks.Clear();
				dsTasks.EnforceConstraints = false;
				// USA data format
				IFormatProvider culture = new CultureInfo("en-US",true);
				// add new employee task
				row.TaskID = 10000;
				row.TaskName = txtName.Text;
				row.TaskDesc = txtDesc.Text;
				if (txtPlanned.Text != "")	
					row.TaskDuration = int.Parse(txtPlanned.Text) ;
				row.TaskUnit = int.Parse(lstUnit.SelectedValue);
				if (txtStartDate.Text != "")
					row.TaskStartDate = DateTime.Parse(txtStartDate.Text,culture); 
				if (txtDueDate.Text != "")
					row.TaskEndDate = DateTime.Parse(txtDueDate.Text,culture);
				dsTasks.Tables[0].Rows.Add(row);
				// save the task
				TSN.ERP.SharedComponents.Data.dsTasks dsTask2 = new TSN.ERP.SharedComponents.Data.dsTasks ();  
				Navigation.BaseObject.SafeMerge(dsTask2,((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.AddTasks(dsTasks));
				row = (TSN.ERP.SharedComponents.Data.dsTasks.GEN_TasksRow) 
					dsTask2.GEN_Tasks.Rows[0];  // Get last inserted task
				// then assign it to the employee
				int newID = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.AssginTask
					(row.TaskID,task.empID,task.respID,0); //Firstly, set priority equals Zero 
				if ( newID != -1 )
					((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.SetOngoingAssignment( newID );
				lblMsg.Text = "Task saved";	
		}
		#endregion
		//--------------------------------------------------------------
		#region edit project task
		/// <summary>
		/// Edit existing project task
		/// </summary>
		private void EditProjectTask()
		{
			
			TSN.ERP.SharedComponents.Data.dsTasks.GEN_TasksRow row;
			// USA data format
			IFormatProvider culture = new CultureInfo("en-US",true);
			dsTasks.Clear();
			Navigation.BaseObject.SafeMerge(dsTasks,((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewTask(task.taskID));
			////////////////////////////////////////////////////////////////////////////////////////////////////
			BaseObject.SafeMerge(dsTasksTest,((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewTaskByProject(task.projectID));
			bool Flage = IsProjectTaskExistForEdit(dsTasksTest,txtName.Text.Trim(),task.projectID,task.taskID);
			//////////////////////////////////////////////////////////////////////////////////////////////
			if(Flage)
			{
			lblMsg.Text ="This task already exist, please try another one";
			}
			else
			{
				row = (TSN.ERP.SharedComponents.Data.dsTasks.GEN_TasksRow) 
					dsTasks.GEN_Tasks.Rows[0];
				row.TaskName = txtName.Text;
				row.TaskDesc = txtDesc.Text;
				if (txtPlanned.Text != "")
					row.TaskDuration = Decimal.Parse(txtPlanned.Text) ;
				row.TaskUnit = int.Parse(lstUnit.SelectedValue);
				if (txtStartDate.Text != "")
					row.TaskStartDate = DateTime.Parse(txtStartDate.Text ,culture); 
				if(txtDueDate.Text != "")
					row.TaskEndDate = DateTime.Parse(txtDueDate.Text,culture);
				((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.UpdateTask(dsTasks);
				lblMsg.Text = "Task saved";	
			}
		}
		#endregion
		//--------------------------------------------------------------
		#region edit Employee task
		/// <summary>
		/// Edit existing employee's assignment
		/// </summary>
		private void EditEmpTask()
		{
			TSN.ERP.SharedComponents.Data.dsTasks.GEN_TasksRow row;
				
			// USA data format
			IFormatProvider culture = new CultureInfo("en-US",true);
			dsTasks.Clear();
			Navigation.BaseObject.SafeMerge(dsTasks,((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewAssignmentTask( task.assignmentID ));
			row = (TSN.ERP.SharedComponents.Data.dsTasks.GEN_TasksRow) 
				dsTasks.GEN_Tasks.Rows[0];
			row.TaskName = txtName.Text;
			row.TaskDesc = txtDesc.Text;
			if (txtPlanned.Text != "")
				row.TaskDuration = Decimal.Parse(txtPlanned.Text) ;
			row.TaskUnit = int.Parse(lstUnit.SelectedValue);
			if (txtStartDate.Text != "")
				row.TaskStartDate = DateTime.Parse(txtStartDate.Text ,culture); 
			if (txtDueDate.Text != "")
				row.TaskEndDate = DateTime.Parse(txtDueDate.Text,culture);
			((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.UpdateAssignmentTask( task.assignmentID , dsTasks);
			lblMsg.Text = "Task saved";	

		}
		#endregion
		//--------------------------------------------------------------
		#region score a task
		/// <summary>
		/// Score existing assignment
		/// </summary>
		private void ScoreTask()
		{		
			// USA data format
			IFormatProvider culture = new CultureInfo("en-US",true);
			dsAssignments.Clear();
			Navigation.BaseObject.SafeMerge(dsAssignments,((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewAssignmentData(task.assignmentID));
			dsAssignments.GEN_Assignments.Rows[0]["AssignmentScore"] = txtScore.Text;
			//TODO : update assignment
			//((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.UpdateAssignment(dsAssignments);
			lblMsg.Text = "Task saved";	
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
			txtDesc.Text="" ;
			txtPlanned.Text = "";
			txtStartDate.Text = "";
			txtDueDate.Text = "";
			txtScore.Text = "";
		}
		#endregion
		//--------------------------------------------------------------
		#region validate form
		/// <summary>
		/// returns a message indicating invalid inputs
		/// returns empty string if all inputs are valid
		/// </summary>
		/// <param name="mode"></param>
		/// <returns></returns>
		private string ValidateForm(int mode)
		{
			IFormatProvider culture = new CultureInfo("en-US",true);
			Regex NumberPattern = new Regex("\\d?[.]?\\d");
			Regex IntegerPattern = new Regex("\\d");
			string msg = "";
			
			if (txtName.Text.Trim() == "")
					msg = msg + "<li>Please Specify a task name</li>";
			if (txtDesc.Text.Trim() == "")
					msg = msg + "<li>Please Specify a task description</li>";
			if (txtStartDate.Text.Trim() != "" && txtDueDate.Text.Trim() != "")
			{
				if (DateTime.Parse(txtStartDate.Text,culture) > 
					DateTime.Parse(txtDueDate.Text,culture))
					msg = msg + "<li>Start date should be earlier than due date</li>";
			}
			if (mode == 5)  //Score assignment
			{
				if (txtScore.Text == "" || !IntegerPattern.IsMatch(txtScore.Text))
					msg = msg + "<li>Score must be an integer</li>";
			}
			if(txtPlanned.Text!="") // Planned is optional parameter. and is validate if and only it contains a variable
			{
				if(IntegerPattern.IsMatch(txtPlanned.Text))
				{
					if(Double.Parse(txtPlanned.Text)<=0)
					{
						msg = msg + "<li>Planned must be an positive integer</li>";                    
					}
				}
				else
				{
					msg = msg + "<li>Planned must be an positive integer</li>";
				}
			}	
			return msg;
		}
		#endregion
	}
}
