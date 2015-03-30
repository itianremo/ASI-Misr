using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for TasksDataClass.
	/// </summary>
	public class TasksDataClass :TSN.ERP.Engine.BussinesComponent 
	{
		private TSN.ERP.SharedComponents.Data.dsTasks dsTasks1;
		private System.Data.OleDb.OleDbDataAdapter odaTasks;
		private System.Data.OleDb.OleDbConnection con1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterProjectTasks;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand odcTaskUnit;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterGetDaysOff;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		private System.Data.OleDb.OleDbCommand odcSetTaskNote;
		private System.Data.OleDb.OleDbCommand odcGetTaskNote;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterRespOpenTasks;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand5;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterRespTasksMaxDate;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand6;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TasksDataClass(System.ComponentModel.IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			container.Add(this);
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public TasksDataClass()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
        ////////////////////protected override void Dispose( bool disposing )
        ////////////////////{
        ////////////////////    if( disposing )
        ////////////////////    {
        ////////////////////        if(components != null)
        ////////////////////        {
        ////////////////////            components.Dispose();
        ////////////////////        }
        ////////////////////    }
        ////////////////////    base.Dispose( disposing );
        ////////////////////}


		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.odaTasks = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.con1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dsTasks1 = new TSN.ERP.SharedComponents.Data.dsTasks();
			this.oleDbDataAdapterProjectTasks = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.odcTaskUnit = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterGetDaysOff = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.odcSetTaskNote = new System.Data.OleDb.OleDbCommand();
			this.odcGetTaskNote = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterRespOpenTasks = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbDataAdapterRespTasksMaxDate = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand6 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsTasks1)).BeginInit();
			// 
			// odaTasks
			// 
			this.odaTasks.DeleteCommand = this.oleDbDeleteCommand1;
			this.odaTasks.InsertCommand = this.oleDbInsertCommand1;
			this.odaTasks.SelectCommand = this.oleDbSelectCommand1;
			this.odaTasks.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							   new System.Data.Common.DataTableMapping("Table", "GEN_Tasks", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("TaskID", "TaskID"),
																																																			new System.Data.Common.DataColumnMapping("projectID", "projectID"),
																																																			new System.Data.Common.DataColumnMapping("TaskForumID", "TaskForumID"),
																																																			new System.Data.Common.DataColumnMapping("TaskName", "TaskName"),
																																																			new System.Data.Common.DataColumnMapping("TaskDesc", "TaskDesc"),
																																																			new System.Data.Common.DataColumnMapping("TaskCreatBy", "TaskCreatBy"),
																																																			new System.Data.Common.DataColumnMapping("TaskProgress", "TaskProgress"),
																																																			new System.Data.Common.DataColumnMapping("TaskStartDate", "TaskStartDate"),
																																																			new System.Data.Common.DataColumnMapping("TaskEndDate", "TaskEndDate"),
																																																			new System.Data.Common.DataColumnMapping("TaskCloseDate", "TaskCloseDate"),
																																																			new System.Data.Common.DataColumnMapping("TaskStatus", "TaskStatus"),
																																																			new System.Data.Common.DataColumnMapping("TaskDuration", "TaskDuration"),
																																																			new System.Data.Common.DataColumnMapping("TaskUnit", "TaskUnit")})});
			this.odaTasks.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = @"DELETE FROM GEN_Tasks WHERE (TaskID = ?) AND (TaskCloseDate = ? OR ? IS NULL AND TaskCloseDate IS NULL) AND (TaskCreatBy = ? OR ? IS NULL AND TaskCreatBy IS NULL) AND (TaskDuration = ? OR ? IS NULL AND TaskDuration IS NULL) AND (TaskEndDate = ? OR ? IS NULL AND TaskEndDate IS NULL) AND (TaskForumID = ? OR ? IS NULL AND TaskForumID IS NULL) AND (TaskName = ?) AND (TaskProgress = ? OR ? IS NULL AND TaskProgress IS NULL) AND (TaskStartDate = ? OR ? IS NULL AND TaskStartDate IS NULL) AND (TaskStatus = ? OR ? IS NULL AND TaskStatus IS NULL) AND (TaskUnit = ? OR ? IS NULL AND TaskUnit IS NULL) AND (projectID = ? OR ? IS NULL AND projectID IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.con1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskCloseDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskCloseDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskCloseDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskCloseDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskCreatBy", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskCreatBy", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskCreatBy1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskCreatBy", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskDuration", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(5)), ((System.Byte)(2)), "TaskDuration", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskDuration1", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(5)), ((System.Byte)(2)), "TaskDuration", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskEndDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskEndDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskForumID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskForumID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskForumID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskForumID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskName", System.Data.OleDb.OleDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskProgress", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskProgress", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskProgress1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskProgress", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskStartDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskStartDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskStatus", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskStatus", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskStatus1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskStatus", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskUnit", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskUnit", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskUnit1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskUnit", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_projectID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "projectID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_projectID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "projectID", System.Data.DataRowVersion.Original, null));
			// 
			// con1
			// 
			this.con1.ConnectionString = @"Auto Translate=True;Integrated Security=SSPI;User ID=RW;Data Source=""ERP\ERPSQL2005"";Tag with column collation when possible=False;Initial Catalog=TestAccountability_Data;Use Procedure for Prepare=1;Provider=""SQLOLEDB.1"";Persist Security Info=False;Workstation ID=HAMDYAHMED;Use Encryption for Data=False;Packet Size=4096";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = @"INSERT INTO GEN_Tasks(TaskID, projectID, TaskForumID, TaskName, TaskDesc, TaskCreatBy, TaskProgress, TaskStartDate, TaskEndDate, TaskCloseDate, TaskStatus, TaskDuration, TaskUnit) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?); SELECT TaskID, projectID, TaskForumID, TaskName, TaskDesc, TaskCreatBy, TaskProgress, TaskStartDate, TaskEndDate, TaskCloseDate, TaskStatus, TaskDuration, TaskUnit FROM GEN_Tasks WHERE (TaskID = ?)";
			this.oleDbInsertCommand1.Connection = this.con1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskID", System.Data.OleDb.OleDbType.Integer, 4, "TaskID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("projectID", System.Data.OleDb.OleDbType.Integer, 4, "projectID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskForumID", System.Data.OleDb.OleDbType.Integer, 4, "TaskForumID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskName", System.Data.OleDb.OleDbType.VarChar, 50, "TaskName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskDesc", System.Data.OleDb.OleDbType.VarChar, 2147483647, "TaskDesc"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskCreatBy", System.Data.OleDb.OleDbType.Integer, 4, "TaskCreatBy"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskProgress", System.Data.OleDb.OleDbType.SmallInt, 2, "TaskProgress"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskStartDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "TaskStartDate"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskEndDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "TaskEndDate"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskCloseDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "TaskCloseDate"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskStatus", System.Data.OleDb.OleDbType.SmallInt, 2, "TaskStatus"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskDuration", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(5)), ((System.Byte)(2)), "TaskDuration", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskUnit", System.Data.OleDb.OleDbType.Integer, 4, "TaskUnit"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_TaskID", System.Data.OleDb.OleDbType.Integer, 4, "TaskID"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT TaskID, projectID, TaskForumID, TaskName, TaskDesc, TaskCreatBy, TaskProgr" +
				"ess, TaskStartDate, TaskEndDate, TaskCloseDate, TaskStatus, TaskDuration, TaskUn" +
				"it FROM GEN_Tasks";
			this.oleDbSelectCommand1.Connection = this.con1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE GEN_Tasks SET TaskID = ?, projectID = ?, TaskForumID = ?, TaskName = ?, TaskDesc = ?, TaskCreatBy = ?, TaskProgress = ?, TaskStartDate = ?, TaskEndDate = ?, TaskCloseDate = ?, TaskStatus = ?, TaskDuration = ?, TaskUnit = ? WHERE (TaskID = ?) AND (TaskCloseDate = ? OR ? IS NULL AND TaskCloseDate IS NULL) AND (TaskCreatBy = ? OR ? IS NULL AND TaskCreatBy IS NULL) AND (TaskDuration = ? OR ? IS NULL AND TaskDuration IS NULL) AND (TaskEndDate = ? OR ? IS NULL AND TaskEndDate IS NULL) AND (TaskForumID = ? OR ? IS NULL AND TaskForumID IS NULL) AND (TaskName = ?) AND (TaskProgress = ? OR ? IS NULL AND TaskProgress IS NULL) AND (TaskStartDate = ? OR ? IS NULL AND TaskStartDate IS NULL) AND (TaskStatus = ? OR ? IS NULL AND TaskStatus IS NULL) AND (TaskUnit = ? OR ? IS NULL AND TaskUnit IS NULL) AND (projectID = ? OR ? IS NULL AND projectID IS NULL); SELECT TaskID, projectID, TaskForumID, TaskName, TaskDesc, TaskCreatBy, TaskProgress, TaskStartDate, TaskEndDate, TaskCloseDate, TaskStatus, TaskDuration, TaskUnit FROM GEN_Tasks WHERE (TaskID = ?)";
			this.oleDbUpdateCommand1.Connection = this.con1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskID", System.Data.OleDb.OleDbType.Integer, 4, "TaskID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("projectID", System.Data.OleDb.OleDbType.Integer, 4, "projectID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskForumID", System.Data.OleDb.OleDbType.Integer, 4, "TaskForumID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskName", System.Data.OleDb.OleDbType.VarChar, 50, "TaskName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskDesc", System.Data.OleDb.OleDbType.VarChar, 2147483647, "TaskDesc"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskCreatBy", System.Data.OleDb.OleDbType.Integer, 4, "TaskCreatBy"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskProgress", System.Data.OleDb.OleDbType.SmallInt, 2, "TaskProgress"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskStartDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "TaskStartDate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskEndDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "TaskEndDate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskCloseDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "TaskCloseDate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskStatus", System.Data.OleDb.OleDbType.SmallInt, 2, "TaskStatus"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskDuration", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(5)), ((System.Byte)(2)), "TaskDuration", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskUnit", System.Data.OleDb.OleDbType.Integer, 4, "TaskUnit"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskCloseDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskCloseDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskCloseDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskCloseDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskCreatBy", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskCreatBy", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskCreatBy1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskCreatBy", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskDuration", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(5)), ((System.Byte)(2)), "TaskDuration", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskDuration1", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(5)), ((System.Byte)(2)), "TaskDuration", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskEndDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskEndDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskEndDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskForumID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskForumID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskForumID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskForumID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskName", System.Data.OleDb.OleDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskProgress", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskProgress", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskProgress1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskProgress", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskStartDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskStartDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskStatus", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskStatus", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskStatus1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskStatus", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskUnit", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskUnit", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskUnit1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskUnit", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_projectID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "projectID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_projectID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "projectID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_TaskID", System.Data.OleDb.OleDbType.Integer, 4, "TaskID"));
			// 
			// dsTasks1
			// 
			this.dsTasks1.DataSetName = "dsTasks";
			this.dsTasks1.EnforceConstraints = false;
			this.dsTasks1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbDataAdapterProjectTasks
			// 
			this.oleDbDataAdapterProjectTasks.SelectCommand = this.oleDbSelectCommand3;
			this.oleDbDataAdapterProjectTasks.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												   new System.Data.Common.DataTableMapping("Table", "GEN_Tasks", new System.Data.Common.DataColumnMapping[] {
																																																								new System.Data.Common.DataColumnMapping("TaskID", "TaskID"),
																																																								new System.Data.Common.DataColumnMapping("projectID", "projectID"),
																																																								new System.Data.Common.DataColumnMapping("TaskForumID", "TaskForumID"),
																																																								new System.Data.Common.DataColumnMapping("TaskName", "TaskName"),
																																																								new System.Data.Common.DataColumnMapping("TaskDesc", "TaskDesc"),
																																																								new System.Data.Common.DataColumnMapping("TaskCreatBy", "TaskCreatBy"),
																																																								new System.Data.Common.DataColumnMapping("TaskProgress", "TaskProgress"),
																																																								new System.Data.Common.DataColumnMapping("TaskStartDate", "TaskStartDate"),
																																																								new System.Data.Common.DataColumnMapping("TaskEndDate", "TaskEndDate"),
																																																								new System.Data.Common.DataColumnMapping("TaskCloseDate", "TaskCloseDate"),
																																																								new System.Data.Common.DataColumnMapping("TaskStatus", "TaskStatus"),
																																																								new System.Data.Common.DataColumnMapping("TaskDuration", "TaskDuration"),
																																																								new System.Data.Common.DataColumnMapping("TaskUnit", "TaskUnit")})});
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = "SELECT TaskID, projectID, TaskForumID, TaskName, TaskDesc, TaskCreatBy, TaskProgr" +
				"ess, TaskStartDate, TaskEndDate, TaskCloseDate, TaskStatus, TaskDuration, TaskUn" +
				"it FROM GEN_Tasks WHERE (projectID = ?)";
			this.oleDbSelectCommand3.Connection = this.con1;
			this.oleDbSelectCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("projectID", System.Data.OleDb.OleDbType.Integer, 4, "projectID"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT TaskID, projectID, TaskForumID, TaskName, TaskDesc, TaskCreatBy, TaskProgr" +
				"ess, TaskStartDate, TaskEndDate, TaskCloseDate, TaskStatus, TaskDuration, TaskUn" +
				"it FROM GEN_Tasks WHERE (projectID = ?)";
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("projectID", System.Data.OleDb.OleDbType.Integer, 4, "projectID"));
			// 
			// odcTaskUnit
			// 
			this.odcTaskUnit.CommandText = "SELECT TaskUnit FROM GEN_Tasks WHERE (TaskID = ?)";
			this.odcTaskUnit.Connection = this.con1;
			this.odcTaskUnit.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskID", System.Data.OleDb.OleDbType.Integer, 4, "TaskID"));
			// 
			// oleDbDataAdapterGetDaysOff
			// 
			this.oleDbDataAdapterGetDaysOff.SelectCommand = this.oleDbSelectCommand4;
			this.oleDbDataAdapterGetDaysOff.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												 new System.Data.Common.DataTableMapping("Table", "GEN_Tasks", new System.Data.Common.DataColumnMapping[] {
																																																							  new System.Data.Common.DataColumnMapping("TaskID", "TaskID"),
																																																							  new System.Data.Common.DataColumnMapping("projectID", "projectID"),
																																																							  new System.Data.Common.DataColumnMapping("TaskForumID", "TaskForumID"),
																																																							  new System.Data.Common.DataColumnMapping("TaskName", "TaskName"),
																																																							  new System.Data.Common.DataColumnMapping("TaskDesc", "TaskDesc"),
																																																							  new System.Data.Common.DataColumnMapping("TaskCreatBy", "TaskCreatBy"),
																																																							  new System.Data.Common.DataColumnMapping("TaskProgress", "TaskProgress"),
																																																							  new System.Data.Common.DataColumnMapping("TaskStartDate", "TaskStartDate"),
																																																							  new System.Data.Common.DataColumnMapping("TaskEndDate", "TaskEndDate"),
																																																							  new System.Data.Common.DataColumnMapping("TaskCloseDate", "TaskCloseDate"),
																																																							  new System.Data.Common.DataColumnMapping("TaskStatus", "TaskStatus"),
																																																							  new System.Data.Common.DataColumnMapping("TaskDuration", "TaskDuration"),
																																																							  new System.Data.Common.DataColumnMapping("TaskUnit", "TaskUnit")})});
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = "SELECT TaskID, projectID, TaskForumID, TaskName, TaskDesc, TaskCreatBy, TaskProgr" +
				"ess, TaskStartDate, TaskEndDate, TaskCloseDate, TaskStatus, TaskDuration, TaskUn" +
				"it FROM GEN_Tasks WHERE (TaskUnit = 40)";
			this.oleDbSelectCommand4.Connection = this.con1;
			// 
			// odcSetTaskNote
			// 
			this.odcSetTaskNote.CommandText = "UPDATE GEN_Tasks SET TaskNotes = ? WHERE (TaskID = ?)";
			this.odcSetTaskNote.Connection = this.con1;
			this.odcSetTaskNote.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskNotes", System.Data.OleDb.OleDbType.VarChar, 2147483647, "TaskNotes"));
			this.odcSetTaskNote.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskID", System.Data.DataRowVersion.Original, null));
			// 
			// odcGetTaskNote
			// 
			this.odcGetTaskNote.CommandText = "SELECT TaskNotes FROM GEN_Tasks WHERE (TaskID = ?)";
			this.odcGetTaskNote.Connection = this.con1;
			this.odcGetTaskNote.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskID", System.Data.OleDb.OleDbType.Integer, 4, "TaskID"));
			// 
			// oleDbDataAdapterRespOpenTasks
			// 
			this.oleDbDataAdapterRespOpenTasks.SelectCommand = this.oleDbSelectCommand5;
			this.oleDbDataAdapterRespOpenTasks.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													new System.Data.Common.DataTableMapping("Table", "Table", new System.Data.Common.DataColumnMapping[] {
																																																							 new System.Data.Common.DataColumnMapping("ResponsOpenTasksCount", "ResponsOpenTasksCount")})});
			// 
			// oleDbSelectCommand5
			// 
			this.oleDbSelectCommand5.CommandText = "SELECT COUNT(*) AS ResponsOpenTasksCount FROM GEN_Assignments INNER JOIN GEN_Task" +
				"s ON GEN_Assignments.TaskID = GEN_Tasks.TaskID WHERE (GEN_Assignments.ResponsID " +
				"= ?) AND (GEN_Tasks.TaskStatus = 1) AND (GEN_Assignments.AssignmentStatus = 1)";
			this.oleDbSelectCommand5.Connection = this.con1;
			this.oleDbSelectCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsID", System.Data.OleDb.OleDbType.Integer, 4, "ResponsID"));
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Integrated Security=SSPI;User ID=RW;Data Source=""ERP\ERPSQL2005"";Tag with column collation when possible=False;Initial Catalog=TestAccountability_Data;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=HAMDYAHMED;Use Encryption for Data=False;Packet Size=4096";
			// 
			// oleDbDataAdapterRespTasksMaxDate
			// 
			this.oleDbDataAdapterRespTasksMaxDate.SelectCommand = this.oleDbSelectCommand6;
			this.oleDbDataAdapterRespTasksMaxDate.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													   new System.Data.Common.DataTableMapping("Table", "Table", new System.Data.Common.DataColumnMapping[] {
																																																								new System.Data.Common.DataColumnMapping("MaxTaskCloseDate", "MaxTaskCloseDate")})});
			// 
			// oleDbSelectCommand6
			// 
			this.oleDbSelectCommand6.CommandText = "SELECT MAX(GEN_Tasks.TaskCloseDate) AS MaxTaskCloseDate FROM GEN_Tasks INNER JOIN" +
				" GEN_Assignments ON GEN_Tasks.TaskID = GEN_Assignments.TaskID WHERE (GEN_Assignm" +
				"ents.ResponsID = ?)";
			this.oleDbSelectCommand6.Connection = this.con1;
			this.oleDbSelectCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsID", System.Data.OleDb.OleDbType.Integer, 4, "ResponsID"));
			// 
			// TasksDataClass
			// 
			this.ComponentDataAdabter = this.odaTasks;
			this.ComponentDataSet = this.dsTasks1;
			this.Connection = this.con1;
			((System.ComponentModel.ISupportInitialize)(this.dsTasks1)).EndInit();

		}
		#endregion

		public dsTasks GetProjectTasks(int projID)
		{
			dsTasks1.Clear();
			oleDbDataAdapterProjectTasks.SelectCommand.Parameters[0].Value = projID;
			oleDbDataAdapterProjectTasks.Fill(dsTasks1);
			return dsTasks1;
		}
		public int TaskUnit(int TaskID)
		{
			odcTaskUnit.Parameters[0].Value = TaskID;
			object tempObject = odcTaskUnit.ExecuteScalar();
			if (tempObject == System.DBNull.Value)
				return 10;
			return Convert.ToInt32(tempObject);
		}

		public dsTasks GetAllDaysOff()
		{
			dsTasks1.Clear();
			oleDbDataAdapterGetDaysOff.Fill(dsTasks1);
			return dsTasks1;
		}
		public bool SetTaskNote(int TaskID,string NoteBody)
		{
			try
			{
				odcSetTaskNote.Parameters["Original_TaskID"].Value = TaskID;
				odcSetTaskNote.Parameters["TaskNotes"].Value = NoteBody;
				object temp =odcSetTaskNote.ExecuteScalar();
				if (temp == null)return false;
				if((int)temp > 0 )return true;
				return false;
			}
			catch (Exception ex)
			{
				ActiveSession.SetError(new ERP.Engine.ERPError(0,"Error Adding Note",0,ex));
				return false;
			}
		}
		public string GetTaskNote(int TaskID)
		{
			try
			{
				odcGetTaskNote.Parameters["TaskID"].Value = TaskID;
				object temp = odcGetTaskNote.ExecuteScalar();
				if (temp == null)return "";
				return temp.ToString();
			}
			catch (Exception ex)
			{
				ActiveSession.SetError(new ERP.Engine.ERPError(0,"Error Adding Note",0,ex));
				return "";
			}
		}

		public int GetRespOpenTasksCount(int RespID)
		{
			try
			{
				oleDbDataAdapterRespOpenTasks.SelectCommand.Parameters[0].Value = RespID;
				int RespOpenTaskCount = Convert.ToInt32(oleDbDataAdapterRespOpenTasks.SelectCommand.ExecuteScalar());
				return RespOpenTaskCount;
			}
			catch (Exception ex)
			{
				ActiveSession.SetError(new ERP.Engine.ERPError(0,"Error getting responsibility open tasks",0,ex));
				return -1;
			}
		}

		public DateTime GetRespTasksMaxCloseDate(int RespID)
		{
//			try
//			{
				oleDbDataAdapterRespTasksMaxDate.SelectCommand.Parameters[0].Value = RespID;
				DateTime RespTasksMaxCloseDate = Convert.ToDateTime(oleDbDataAdapterRespTasksMaxDate.SelectCommand.ExecuteScalar());
				return RespTasksMaxCloseDate;
//			}
//			catch (Exception ex)
//			{
//				ActiveSession.SetError(new ERP.Engine.ERPError(0,"Error getting responsibility open tasks",0,ex));
//				return ;
//			}
		}
	}
}
