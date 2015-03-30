using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for ProjectsData.
	/// </summary>
	public class ProjectsData : TSN.ERP.Engine.BussinesComponent 
	{
		private System.Data.OleDb.OleDbDataAdapter odaProjects;
		private System.Data.OleDb.OleDbConnection con1;
		private System.Data.OleDb.OleDbDataAdapter odaProjectsSimpleList;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbDataAdapter odaProjectsByEmp;
		private System.Data.OleDb.OleDbDataAdapter odaProjectsByContactRespons;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterProjectsByPrjParent;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private TSN.ERP.SharedComponents.Data.dsProjects dsProjects1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ProjectsData(System.ComponentModel.IContainer container)
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

		public ProjectsData()
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
        //////////////////////protected override void Dispose( bool disposing )
        //////////////////////{
        //////////////////////    if( disposing )
        //////////////////////    {
        //////////////////////        if(components != null)
        //////////////////////        {
        //////////////////////            components.Dispose();
        //////////////////////        }
        //////////////////////    }
        //////////////////////    base.Dispose( disposing );
        //////////////////////}


		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.odaProjects = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.con1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.odaProjectsSimpleList = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.odaProjectsByEmp = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.odaProjectsByContactRespons = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterProjectsByPrjParent = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
			this.dsProjects1 = new TSN.ERP.SharedComponents.Data.dsProjects();
			((System.ComponentModel.ISupportInitialize)(this.dsProjects1)).BeginInit();
			// 
			// odaProjects
			// 
			this.odaProjects.DeleteCommand = this.oleDbDeleteCommand1;
			this.odaProjects.InsertCommand = this.oleDbInsertCommand1;
			this.odaProjects.SelectCommand = this.oleDbSelectCommand1;
			this.odaProjects.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								  new System.Data.Common.DataTableMapping("Table", "GEN_Projects", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("projectID", "projectID"),
																																																				  new System.Data.Common.DataColumnMapping("ProjectName", "ProjectName"),
																																																				  new System.Data.Common.DataColumnMapping("ProjectOwner", "ProjectOwner"),
																																																				  new System.Data.Common.DataColumnMapping("ProjectStartDate", "ProjectStartDate"),
																																																				  new System.Data.Common.DataColumnMapping("ProjectStatus", "ProjectStatus"),
																																																				  new System.Data.Common.DataColumnMapping("ProjectOrginatorTarget", "ProjectOrginatorTarget"),
																																																				  new System.Data.Common.DataColumnMapping("ProjectTargetDate", "ProjectTargetDate"),
																																																				  new System.Data.Common.DataColumnMapping("ProjectCriticalDate", "ProjectCriticalDate"),
																																																				  new System.Data.Common.DataColumnMapping("ProjectCompleteDate", "ProjectCompleteDate"),
																																																				  new System.Data.Common.DataColumnMapping("ProjectComplete", "ProjectComplete"),
																																																				  new System.Data.Common.DataColumnMapping("ProjectManager", "ProjectManager"),
																																																				  new System.Data.Common.DataColumnMapping("ProjectDesc", "ProjectDesc"),
																																																				  new System.Data.Common.DataColumnMapping("ProjectParentID", "ProjectParentID")})});
			this.odaProjects.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = @"DELETE FROM GEN_Projects WHERE (projectID = ?) AND (ProjectComplete = ? OR ? IS NULL AND ProjectComplete IS NULL) AND (ProjectCompleteDate = ? OR ? IS NULL AND ProjectCompleteDate IS NULL) AND (ProjectCriticalDate = ? OR ? IS NULL AND ProjectCriticalDate IS NULL) AND (ProjectManager = ? OR ? IS NULL AND ProjectManager IS NULL) AND (ProjectName = ?) AND (ProjectOrginatorTarget = ? OR ? IS NULL AND ProjectOrginatorTarget IS NULL) AND (ProjectOwner = ?) AND (ProjectParentID = ? OR ? IS NULL AND ProjectParentID IS NULL) AND (ProjectStartDate = ? OR ? IS NULL AND ProjectStartDate IS NULL) AND (ProjectStatus = ? OR ? IS NULL AND ProjectStatus IS NULL) AND (ProjectTargetDate = ? OR ? IS NULL AND ProjectTargetDate IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.con1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_projectID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "projectID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectComplete", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectComplete", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectComplete1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectComplete", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectCompleteDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectCompleteDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectCompleteDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectCompleteDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectCriticalDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectCriticalDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectCriticalDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectCriticalDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectManager", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectManager", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectManager1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectManager", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectName", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectOrginatorTarget", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectOrginatorTarget", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectOrginatorTarget1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectOrginatorTarget", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectOwner", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectOwner", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectParentID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectParentID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectParentID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectParentID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectStartDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectStartDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectStatus", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectStatus", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectStatus1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectStatus", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectTargetDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectTargetDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectTargetDate", System.Data.DataRowVersion.Original, null));
			// 
			// con1
			// 
			this.con1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=ERP;Tag with column collation when possible=False;Initial Catalog=ERPdb4;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASANT;Use Encryption for Data=False";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = @"INSERT INTO GEN_Projects(projectID, ProjectName, ProjectOwner, ProjectStartDate, ProjectStatus, ProjectOrginatorTarget, ProjectTargetDate, ProjectCriticalDate, ProjectCompleteDate, ProjectComplete, ProjectManager, ProjectDesc, ProjectParentID) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?); SELECT projectID, ProjectName, ProjectOwner, ProjectStartDate, ProjectStatus, ProjectOrginatorTarget, ProjectTargetDate, ProjectCriticalDate, ProjectCompleteDate, ProjectComplete, ProjectManager, ProjectDesc, ProjectParentID FROM GEN_Projects WHERE (projectID = ?)";
			this.oleDbInsertCommand1.Connection = this.con1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("projectID", System.Data.OleDb.OleDbType.Integer, 4, "projectID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectName", System.Data.OleDb.OleDbType.VarChar, 180, "ProjectName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectOwner", System.Data.OleDb.OleDbType.Integer, 4, "ProjectOwner"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectStartDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ProjectStartDate"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectStatus", System.Data.OleDb.OleDbType.SmallInt, 2, "ProjectStatus"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectOrginatorTarget", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ProjectOrginatorTarget"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectTargetDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ProjectTargetDate"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectCriticalDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ProjectCriticalDate"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectCompleteDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ProjectCompleteDate"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectComplete", System.Data.OleDb.OleDbType.Boolean, 1, "ProjectComplete"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectManager", System.Data.OleDb.OleDbType.Integer, 4, "ProjectManager"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectDesc", System.Data.OleDb.OleDbType.VarChar, 2147483647, "ProjectDesc"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectParentID", System.Data.OleDb.OleDbType.Integer, 4, "ProjectParentID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_projectID", System.Data.OleDb.OleDbType.Integer, 4, "projectID"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT projectID, ProjectName, ProjectOwner, ProjectStartDate, ProjectStatus, Pro" +
				"jectOrginatorTarget, ProjectTargetDate, ProjectCriticalDate, ProjectCompleteDate" +
				", ProjectComplete, ProjectManager, ProjectDesc, ProjectParentID FROM GEN_Project" +
				"s";
			this.oleDbSelectCommand1.Connection = this.con1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE GEN_Projects SET projectID = ?, ProjectName = ?, ProjectOwner = ?, ProjectStartDate = ?, ProjectStatus = ?, ProjectOrginatorTarget = ?, ProjectTargetDate = ?, ProjectCriticalDate = ?, ProjectCompleteDate = ?, ProjectComplete = ?, ProjectManager = ?, ProjectDesc = ?, ProjectParentID = ? WHERE (projectID = ?) AND (ProjectComplete = ? OR ? IS NULL AND ProjectComplete IS NULL) AND (ProjectCompleteDate = ? OR ? IS NULL AND ProjectCompleteDate IS NULL) AND (ProjectCriticalDate = ? OR ? IS NULL AND ProjectCriticalDate IS NULL) AND (ProjectManager = ? OR ? IS NULL AND ProjectManager IS NULL) AND (ProjectName = ?) AND (ProjectOrginatorTarget = ? OR ? IS NULL AND ProjectOrginatorTarget IS NULL) AND (ProjectOwner = ?) AND (ProjectParentID = ? OR ? IS NULL AND ProjectParentID IS NULL) AND (ProjectStartDate = ? OR ? IS NULL AND ProjectStartDate IS NULL) AND (ProjectStatus = ? OR ? IS NULL AND ProjectStatus IS NULL) AND (ProjectTargetDate = ? OR ? IS NULL AND ProjectTargetDate IS NULL); SELECT projectID, ProjectName, ProjectOwner, ProjectStartDate, ProjectStatus, ProjectOrginatorTarget, ProjectTargetDate, ProjectCriticalDate, ProjectCompleteDate, ProjectComplete, ProjectManager, ProjectDesc, ProjectParentID FROM GEN_Projects WHERE (projectID = ?)";
			this.oleDbUpdateCommand1.Connection = this.con1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("projectID", System.Data.OleDb.OleDbType.Integer, 4, "projectID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectName", System.Data.OleDb.OleDbType.VarChar, 180, "ProjectName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectOwner", System.Data.OleDb.OleDbType.Integer, 4, "ProjectOwner"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectStartDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ProjectStartDate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectStatus", System.Data.OleDb.OleDbType.SmallInt, 2, "ProjectStatus"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectOrginatorTarget", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ProjectOrginatorTarget"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectTargetDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ProjectTargetDate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectCriticalDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ProjectCriticalDate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectCompleteDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ProjectCompleteDate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectComplete", System.Data.OleDb.OleDbType.Boolean, 1, "ProjectComplete"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectManager", System.Data.OleDb.OleDbType.Integer, 4, "ProjectManager"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectDesc", System.Data.OleDb.OleDbType.VarChar, 2147483647, "ProjectDesc"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectParentID", System.Data.OleDb.OleDbType.Integer, 4, "ProjectParentID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_projectID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "projectID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectComplete", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectComplete", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectComplete1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectComplete", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectCompleteDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectCompleteDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectCompleteDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectCompleteDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectCriticalDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectCriticalDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectCriticalDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectCriticalDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectManager", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectManager", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectManager1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectManager", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectName", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectOrginatorTarget", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectOrginatorTarget", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectOrginatorTarget1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectOrginatorTarget", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectOwner", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectOwner", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectParentID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectParentID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectParentID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectParentID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectStartDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectStartDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectStatus", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectStatus", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectStatus1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectStatus", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectTargetDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectTargetDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_projectID", System.Data.OleDb.OleDbType.Integer, 4, "projectID"));
			// 
			// odaProjectsSimpleList
			// 
			this.odaProjectsSimpleList.SelectCommand = this.oleDbSelectCommand2;
			this.odaProjectsSimpleList.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											new System.Data.Common.DataTableMapping("Table", "GEN_Projects", new System.Data.Common.DataColumnMapping[] {
																																																							new System.Data.Common.DataColumnMapping("projectID", "projectID"),
																																																							new System.Data.Common.DataColumnMapping("ProjectName", "ProjectName")})});
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT projectID, ProjectName FROM GEN_Projects";
			this.oleDbSelectCommand2.Connection = this.con1;
			// 
			// odaProjectsByEmp
			// 
			this.odaProjectsByEmp.DeleteCommand = this.oleDbDeleteCommand2;
			this.odaProjectsByEmp.InsertCommand = this.oleDbInsertCommand2;
			this.odaProjectsByEmp.SelectCommand = this.oleDbSelectCommand3;
			this.odaProjectsByEmp.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "GEN_Projects", new System.Data.Common.DataColumnMapping[] {
																																																					   new System.Data.Common.DataColumnMapping("projectID", "projectID"),
																																																					   new System.Data.Common.DataColumnMapping("ProjectName", "ProjectName"),
																																																					   new System.Data.Common.DataColumnMapping("ProjectOwner", "ProjectOwner"),
																																																					   new System.Data.Common.DataColumnMapping("ProjectStartDate", "ProjectStartDate"),
																																																					   new System.Data.Common.DataColumnMapping("ProjectStatus", "ProjectStatus"),
																																																					   new System.Data.Common.DataColumnMapping("ProjectOrginatorTarget", "ProjectOrginatorTarget"),
																																																					   new System.Data.Common.DataColumnMapping("ProjectTargetDate", "ProjectTargetDate"),
																																																					   new System.Data.Common.DataColumnMapping("ProjectCriticalDate", "ProjectCriticalDate"),
																																																					   new System.Data.Common.DataColumnMapping("ProjectCompleteDate", "ProjectCompleteDate"),
																																																					   new System.Data.Common.DataColumnMapping("ProjectComplete", "ProjectComplete"),
																																																					   new System.Data.Common.DataColumnMapping("ProjectManager", "ProjectManager")})});
			this.odaProjectsByEmp.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = @"DELETE FROM GEN_Projects WHERE (projectID = ?) AND (ProjectComplete = ? OR ? IS NULL AND ProjectComplete IS NULL) AND (ProjectCompleteDate = ? OR ? IS NULL AND ProjectCompleteDate IS NULL) AND (ProjectCriticalDate = ? OR ? IS NULL AND ProjectCriticalDate IS NULL) AND (ProjectManager = ? OR ? IS NULL AND ProjectManager IS NULL) AND (ProjectName = ?) AND (ProjectOrginatorTarget = ? OR ? IS NULL AND ProjectOrginatorTarget IS NULL) AND (ProjectOwner = ?) AND (ProjectStartDate = ? OR ? IS NULL AND ProjectStartDate IS NULL) AND (ProjectStatus = ? OR ? IS NULL AND ProjectStatus IS NULL) AND (ProjectTargetDate = ? OR ? IS NULL AND ProjectTargetDate IS NULL)";
			this.oleDbDeleteCommand2.Connection = this.con1;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_projectID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "projectID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectComplete", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectComplete", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectComplete1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectComplete", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectCompleteDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectCompleteDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectCompleteDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectCompleteDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectCriticalDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectCriticalDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectCriticalDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectCriticalDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectManager", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectManager", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectManager1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectManager", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectName", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectOrginatorTarget", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectOrginatorTarget", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectOrginatorTarget1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectOrginatorTarget", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectOwner", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectOwner", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectStartDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectStartDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectStatus", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectStatus", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectStatus1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectStatus", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectTargetDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectTargetDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectTargetDate", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO GEN_Projects(projectID, ProjectName, ProjectOwner, ProjectStartDate, " +
				"ProjectStatus, ProjectOrginatorTarget, ProjectTargetDate, ProjectCriticalDate, P" +
				"rojectCompleteDate, ProjectComplete, ProjectManager) VALUES (?, ?, ?, ?, ?, ?, ?" +
				", ?, ?, ?, ?)";
			this.oleDbInsertCommand2.Connection = this.con1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("projectID", System.Data.OleDb.OleDbType.Integer, 4, "projectID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectName", System.Data.OleDb.OleDbType.VarChar, 180, "ProjectName"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectOwner", System.Data.OleDb.OleDbType.Integer, 4, "ProjectOwner"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectStartDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ProjectStartDate"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectStatus", System.Data.OleDb.OleDbType.SmallInt, 2, "ProjectStatus"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectOrginatorTarget", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ProjectOrginatorTarget"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectTargetDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ProjectTargetDate"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectCriticalDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ProjectCriticalDate"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectCompleteDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ProjectCompleteDate"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectComplete", System.Data.OleDb.OleDbType.Boolean, 1, "ProjectComplete"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectManager", System.Data.OleDb.OleDbType.Integer, 4, "ProjectManager"));
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = @"SELECT GEN_Projects.projectID, GEN_Projects.ProjectName, GEN_Projects.ProjectOwner, GEN_Projects.ProjectStartDate, GEN_Projects.ProjectStatus, GEN_Projects.ProjectOrginatorTarget, GEN_Projects.ProjectTargetDate, GEN_Projects.ProjectCriticalDate, GEN_Projects.ProjectCompleteDate, GEN_Projects.ProjectComplete, GEN_Projects.ProjectManager FROM GEN_Projects INNER JOIN GEN_EmployeesXProjects ON GEN_Projects.projectID = GEN_EmployeesXProjects.projectID WHERE (GEN_EmployeesXProjects.ContactID = ?)";
			this.oleDbSelectCommand3.Connection = this.con1;
			this.oleDbSelectCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = @"UPDATE GEN_Projects SET projectID = ?, ProjectName = ?, ProjectOwner = ?, ProjectStartDate = ?, ProjectStatus = ?, ProjectOrginatorTarget = ?, ProjectTargetDate = ?, ProjectCriticalDate = ?, ProjectCompleteDate = ?, ProjectComplete = ?, ProjectManager = ? WHERE (projectID = ?) AND (ProjectComplete = ? OR ? IS NULL AND ProjectComplete IS NULL) AND (ProjectCompleteDate = ? OR ? IS NULL AND ProjectCompleteDate IS NULL) AND (ProjectCriticalDate = ? OR ? IS NULL AND ProjectCriticalDate IS NULL) AND (ProjectManager = ? OR ? IS NULL AND ProjectManager IS NULL) AND (ProjectName = ?) AND (ProjectOrginatorTarget = ? OR ? IS NULL AND ProjectOrginatorTarget IS NULL) AND (ProjectOwner = ?) AND (ProjectStartDate = ? OR ? IS NULL AND ProjectStartDate IS NULL) AND (ProjectStatus = ? OR ? IS NULL AND ProjectStatus IS NULL) AND (ProjectTargetDate = ? OR ? IS NULL AND ProjectTargetDate IS NULL)";
			this.oleDbUpdateCommand2.Connection = this.con1;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("projectID", System.Data.OleDb.OleDbType.Integer, 4, "projectID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectName", System.Data.OleDb.OleDbType.VarChar, 180, "ProjectName"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectOwner", System.Data.OleDb.OleDbType.Integer, 4, "ProjectOwner"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectStartDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ProjectStartDate"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectStatus", System.Data.OleDb.OleDbType.SmallInt, 2, "ProjectStatus"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectOrginatorTarget", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ProjectOrginatorTarget"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectTargetDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ProjectTargetDate"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectCriticalDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ProjectCriticalDate"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectCompleteDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ProjectCompleteDate"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectComplete", System.Data.OleDb.OleDbType.Boolean, 1, "ProjectComplete"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectManager", System.Data.OleDb.OleDbType.Integer, 4, "ProjectManager"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_projectID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "projectID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectComplete", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectComplete", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectComplete1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectComplete", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectCompleteDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectCompleteDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectCompleteDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectCompleteDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectCriticalDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectCriticalDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectCriticalDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectCriticalDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectManager", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectManager", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectManager1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectManager", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectName", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectOrginatorTarget", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectOrginatorTarget", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectOrginatorTarget1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectOrginatorTarget", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectOwner", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectOwner", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectStartDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectStartDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectStatus", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectStatus", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectStatus1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectStatus", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectTargetDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectTargetDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectTargetDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectTargetDate", System.Data.DataRowVersion.Original, null));
			// 
			// odaProjectsByContactRespons
			// 
			this.odaProjectsByContactRespons.SelectCommand = this.oleDbSelectCommand4;
			this.odaProjectsByContactRespons.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												  new System.Data.Common.DataTableMapping("Table", "GEN_Projects", new System.Data.Common.DataColumnMapping[] {
																																																								  new System.Data.Common.DataColumnMapping("projectID", "projectID"),
																																																								  new System.Data.Common.DataColumnMapping("ProjectName", "ProjectName"),
																																																								  new System.Data.Common.DataColumnMapping("ProjectOwner", "ProjectOwner"),
																																																								  new System.Data.Common.DataColumnMapping("ProjectStartDate", "ProjectStartDate"),
																																																								  new System.Data.Common.DataColumnMapping("ProjectStatus", "ProjectStatus"),
																																																								  new System.Data.Common.DataColumnMapping("ProjectOrginatorTarget", "ProjectOrginatorTarget"),
																																																								  new System.Data.Common.DataColumnMapping("ProjectTargetDate", "ProjectTargetDate"),
																																																								  new System.Data.Common.DataColumnMapping("ProjectCriticalDate", "ProjectCriticalDate"),
																																																								  new System.Data.Common.DataColumnMapping("ProjectCompleteDate", "ProjectCompleteDate"),
																																																								  new System.Data.Common.DataColumnMapping("ProjectComplete", "ProjectComplete"),
																																																								  new System.Data.Common.DataColumnMapping("ProjectManager", "ProjectManager")})});
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = @"SELECT DISTINCT GEN_Projects.projectID, GEN_Projects.ProjectName, GEN_Projects.ProjectOwner, GEN_Projects.ProjectStartDate, GEN_Projects.ProjectStatus, GEN_Projects.ProjectOrginatorTarget, GEN_Projects.ProjectTargetDate, GEN_Projects.ProjectCriticalDate, GEN_Projects.ProjectCompleteDate, GEN_Projects.ProjectComplete, GEN_Projects.ProjectManager FROM GEN_Projects INNER JOIN GEN_Tasks ON GEN_Projects.projectID = GEN_Tasks.projectID INNER JOIN GEN_Assignments ON GEN_Tasks.TaskID = GEN_Assignments.TaskID WHERE (GEN_Assignments.ContactID = ?) AND (GEN_Assignments.ResponsID = ?) ORDER BY GEN_Projects.ProjectName";
			this.oleDbSelectCommand4.Connection = this.con1;
			this.oleDbSelectCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbSelectCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsID", System.Data.OleDb.OleDbType.Integer, 4, "ResponsID"));
			// 
			// oleDbDataAdapterProjectsByPrjParent
			// 
			this.oleDbDataAdapterProjectsByPrjParent.SelectCommand = this.oleDbSelectCommand5;
			this.oleDbDataAdapterProjectsByPrjParent.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																														  new System.Data.Common.DataTableMapping("Table", "GEN_Projects", new System.Data.Common.DataColumnMapping[] {
																																																										  new System.Data.Common.DataColumnMapping("projectID", "projectID"),
																																																										  new System.Data.Common.DataColumnMapping("ProjectName", "ProjectName"),
																																																										  new System.Data.Common.DataColumnMapping("ProjectOwner", "ProjectOwner"),
																																																										  new System.Data.Common.DataColumnMapping("ProjectStartDate", "ProjectStartDate"),
																																																										  new System.Data.Common.DataColumnMapping("ProjectStatus", "ProjectStatus"),
																																																										  new System.Data.Common.DataColumnMapping("ProjectOrginatorTarget", "ProjectOrginatorTarget"),
																																																										  new System.Data.Common.DataColumnMapping("ProjectTargetDate", "ProjectTargetDate"),
																																																										  new System.Data.Common.DataColumnMapping("ProjectCriticalDate", "ProjectCriticalDate"),
																																																										  new System.Data.Common.DataColumnMapping("ProjectCompleteDate", "ProjectCompleteDate"),
																																																										  new System.Data.Common.DataColumnMapping("ProjectComplete", "ProjectComplete"),
																																																										  new System.Data.Common.DataColumnMapping("ProjectManager", "ProjectManager"),
																																																										  new System.Data.Common.DataColumnMapping("ProjectDesc", "ProjectDesc"),
																																																										  new System.Data.Common.DataColumnMapping("ProjectParentID", "ProjectParentID")})});
			// 
			// oleDbSelectCommand5
			// 
			this.oleDbSelectCommand5.CommandText = @"SELECT projectID, ProjectName, ProjectOwner, ProjectStartDate, ProjectStatus, ProjectOrginatorTarget, ProjectTargetDate, ProjectCriticalDate, ProjectCompleteDate, ProjectComplete, ProjectManager, ProjectDesc, ProjectParentID FROM GEN_Projects WHERE (ProjectParentID = ?)";
			this.oleDbSelectCommand5.Connection = this.con1;
			this.oleDbSelectCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectParentID", System.Data.OleDb.OleDbType.Integer, 4, "ProjectParentID"));
			// 
			// dsProjects1
			// 
			this.dsProjects1.DataSetName = "dsProjects";
			this.dsProjects1.EnforceConstraints = false;
			this.dsProjects1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// ProjectsData
			// 
			this.ComponentDataAdabter = this.odaProjects;
			this.ComponentDataSet = this.dsProjects1;
			this.Connection = this.con1;
			((System.ComponentModel.ISupportInitialize)(this.dsProjects1)).EndInit();

		}
		#endregion
		public DataSet ProjectSimpleList()
		{
			dsProjects1.Clear();
			dsProjects1.EnforceConstraints = false;
			odaProjectsSimpleList.Fill(this.dsProjects1);
			return this.dsProjects1;
		}
		
		public DataSet ProjectsByEmployee(int EmployeeID)
		{
			dsProjects1.Clear();
			odaProjectsByEmp.SelectCommand.Parameters[0].Value = EmployeeID;
			odaProjectsByEmp.Fill(dsProjects1);
			return dsProjects1;
		}
		public DataSet ProjectByEmpRespons(int EmpId, int ResponseID)
		{
			odaProjectsByContactRespons.SelectCommand.Parameters["ContactID"].Value  = EmpId;
			odaProjectsByContactRespons.SelectCommand.Parameters["ResponsID"].Value  = ResponseID;
			this.dsProjects1.Clear();
			odaProjectsByContactRespons.Fill(dsProjects1);
			return dsProjects1;
		}
		
		public DataSet ProjectsByParent(int parentID)
		{
			dsProjects1.Clear();
			oleDbDataAdapterProjectsByPrjParent.SelectCommand.Parameters[0].Value = parentID;
			oleDbDataAdapterProjectsByPrjParent.Fill(dsProjects1);
			return dsProjects1;
		}
	}
}
