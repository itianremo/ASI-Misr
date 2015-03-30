using System;
using System.Data;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for AssignmentsDataClass.
	/// </summary>
	public class AssignmentsDataClass :TSN.ERP.Engine.BussinesComponent 
	{
		private TSN.ERP.SharedComponents.Data.dsAssignments dsAssignments1;
		private System.Data.OleDb.OleDbDataAdapter odaAssgiments;
		private System.Data.OleDb.OleDbConnection con1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterAssInEmpResponseProj;
		private System.Data.OleDb.OleDbDataAdapter odaResponsAssignemntsnoProject;
		private System.Data.OleDb.OleDbCommand odcTaskNAme;
		private System.Data.OleDb.OleDbDataAdapter odaAssginmentsnoProject;
		private System.Data.OleDb.OleDbDataAdapter oaAssginemetnsByProject;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterAssignmentsInEmpRespons;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand5;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand6;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterEmpAssignments;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand7;
		private System.Data.OleDb.OleDbCommand odcGetCompletedDate;
		private System.Data.OleDb.OleDbCommand odcChangeAssginmentResponse;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public enum AssignmentStatus	 { Planed , Ongoing , RequestToClose , Closed , Canceled };
		public enum AssignmentEvaluation { NotEvaluated  , Approved , Rejected , Reassigned };

		//public static AssignmentStatus assStatus;
		//public static AssignmentEvaluation assEvaluation;

		public AssignmentsDataClass(System.ComponentModel.IContainer container)
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

		public AssignmentsDataClass()
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
			this.odaAssgiments = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.con1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dsAssignments1 = new TSN.ERP.SharedComponents.Data.dsAssignments();
			this.oleDbDataAdapterAssInEmpResponseProj = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.odaResponsAssignemntsnoProject = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.odcTaskNAme = new System.Data.OleDb.OleDbCommand();
			this.odaAssginmentsnoProject = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oaAssginemetnsByProject = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand6 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbDataAdapterAssignmentsInEmpRespons = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterEmpAssignments = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand7 = new System.Data.OleDb.OleDbCommand();
			this.odcGetCompletedDate = new System.Data.OleDb.OleDbCommand();
			this.odcChangeAssginmentResponse = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsAssignments1)).BeginInit();
			// 
			// odaAssgiments
			// 
			this.odaAssgiments.DeleteCommand = this.oleDbDeleteCommand1;
			this.odaAssgiments.InsertCommand = this.oleDbInsertCommand1;
			this.odaAssgiments.SelectCommand = this.oleDbSelectCommand1;
			this.odaAssgiments.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									new System.Data.Common.DataTableMapping("Table", "GEN_Assignments", new System.Data.Common.DataColumnMapping[] {
																																																					   new System.Data.Common.DataColumnMapping("AssignmentD", "AssignmentD"),
																																																					   new System.Data.Common.DataColumnMapping("TaskID", "TaskID"),
																																																					   new System.Data.Common.DataColumnMapping("ResponsID", "ResponsID"),
																																																					   new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																					   new System.Data.Common.DataColumnMapping("AssignmentDate", "AssignmentDate"),
																																																					   new System.Data.Common.DataColumnMapping("AssginedBy", "AssginedBy"),
																																																					   new System.Data.Common.DataColumnMapping("AssignmentPriority", "AssignmentPriority"),
																																																					   new System.Data.Common.DataColumnMapping("AssignmentStatus", "AssignmentStatus"),
																																																					   new System.Data.Common.DataColumnMapping("AssignmentEvalutation", "AssignmentEvalutation"),
																																																					   new System.Data.Common.DataColumnMapping("AssignmentScore", "AssignmentScore")})});
			this.odaAssgiments.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = @"DELETE FROM GEN_Assignments WHERE (AssignmentD = ?) AND (AssginedBy = ?) AND (AssignmentDate = ?) AND (AssignmentEvalutation = ? OR ? IS NULL AND AssignmentEvalutation IS NULL) AND (AssignmentPriority = ? OR ? IS NULL AND AssignmentPriority IS NULL) AND (AssignmentScore = ? OR ? IS NULL AND AssignmentScore IS NULL) AND (AssignmentStatus = ?) AND (ContactID = ? OR ? IS NULL AND ContactID IS NULL) AND (ResponsID = ? OR ? IS NULL AND ResponsID IS NULL) AND (TaskID = ? OR ? IS NULL AND TaskID IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.con1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentD", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssginedBy", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssginedBy", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentEvalutation", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentEvalutation", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentEvalutation1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentEvalutation", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentPriority", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentPriority", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentPriority1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentPriority", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentScore", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentScore", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentScore1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentScore", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentStatus", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentStatus", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ResponsID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResponsID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ResponsID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResponsID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskID", System.Data.DataRowVersion.Original, null));
			// 
			// con1
			// 
			this.con1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=ERP;Tag with column collation when possible=False;Initial Catalog=InitialAccountability;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Use Encryption for Data=False";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = @"INSERT INTO GEN_Assignments(AssignmentD, TaskID, ResponsID, ContactID, AssignmentDate, AssginedBy, AssignmentPriority, AssignmentStatus, AssignmentEvalutation, AssignmentScore) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?); SELECT AssignmentD, TaskID, ResponsID, ContactID, AssignmentDate, AssginedBy, AssignmentPriority, AssignmentStatus, AssignmentEvalutation, AssignmentScore FROM GEN_Assignments WHERE (AssignmentD = ?)";
			this.oleDbInsertCommand1.Connection = this.con1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, "AssignmentD"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskID", System.Data.OleDb.OleDbType.Integer, 4, "TaskID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsID", System.Data.OleDb.OleDbType.Integer, 4, "ResponsID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "AssignmentDate"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssginedBy", System.Data.OleDb.OleDbType.Integer, 4, "AssginedBy"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentPriority", System.Data.OleDb.OleDbType.Integer, 4, "AssignmentPriority"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentStatus", System.Data.OleDb.OleDbType.SmallInt, 2, "AssignmentStatus"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentEvalutation", System.Data.OleDb.OleDbType.SmallInt, 2, "AssignmentEvalutation"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentScore", System.Data.OleDb.OleDbType.SmallInt, 2, "AssignmentScore"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, "AssignmentD"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT AssignmentD, TaskID, ResponsID, ContactID, AssignmentDate, AssginedBy, Ass" +
				"ignmentPriority, AssignmentStatus, AssignmentEvalutation, AssignmentScore FROM G" +
				"EN_Assignments";
			this.oleDbSelectCommand1.Connection = this.con1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE GEN_Assignments SET AssignmentD = ?, TaskID = ?, ResponsID = ?, ContactID = ?, AssignmentDate = ?, AssginedBy = ?, AssignmentPriority = ?, AssignmentStatus = ?, AssignmentEvalutation = ?, AssignmentScore = ? WHERE (AssignmentD = ?) AND (AssginedBy = ?) AND (AssignmentDate = ?) AND (AssignmentEvalutation = ? OR ? IS NULL AND AssignmentEvalutation IS NULL) AND (AssignmentPriority = ? OR ? IS NULL AND AssignmentPriority IS NULL) AND (AssignmentScore = ? OR ? IS NULL AND AssignmentScore IS NULL) AND (AssignmentStatus = ?) AND (ContactID = ? OR ? IS NULL AND ContactID IS NULL) AND (ResponsID = ? OR ? IS NULL AND ResponsID IS NULL) AND (TaskID = ? OR ? IS NULL AND TaskID IS NULL); SELECT AssignmentD, TaskID, ResponsID, ContactID, AssignmentDate, AssginedBy, AssignmentPriority, AssignmentStatus, AssignmentEvalutation, AssignmentScore FROM GEN_Assignments WHERE (AssignmentD = ?)";
			this.oleDbUpdateCommand1.Connection = this.con1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, "AssignmentD"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskID", System.Data.OleDb.OleDbType.Integer, 4, "TaskID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsID", System.Data.OleDb.OleDbType.Integer, 4, "ResponsID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "AssignmentDate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssginedBy", System.Data.OleDb.OleDbType.Integer, 4, "AssginedBy"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentPriority", System.Data.OleDb.OleDbType.Integer, 4, "AssignmentPriority"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentStatus", System.Data.OleDb.OleDbType.SmallInt, 2, "AssignmentStatus"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentEvalutation", System.Data.OleDb.OleDbType.SmallInt, 2, "AssignmentEvalutation"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentScore", System.Data.OleDb.OleDbType.SmallInt, 2, "AssignmentScore"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentD", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssginedBy", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssginedBy", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentEvalutation", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentEvalutation", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentEvalutation1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentEvalutation", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentPriority", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentPriority", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentPriority1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentPriority", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentScore", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentScore", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentScore1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentScore", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentStatus", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentStatus", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ResponsID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResponsID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ResponsID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResponsID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, "AssignmentD"));
			// 
			// dsAssignments1
			// 
			this.dsAssignments1.DataSetName = "dsAssignments";
			this.dsAssignments1.EnforceConstraints = false;
			this.dsAssignments1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbDataAdapterAssInEmpResponseProj
			// 
			this.oleDbDataAdapterAssInEmpResponseProj.DeleteCommand = this.oleDbDeleteCommand2;
			this.oleDbDataAdapterAssInEmpResponseProj.InsertCommand = this.oleDbInsertCommand2;
			this.oleDbDataAdapterAssInEmpResponseProj.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbDataAdapterAssInEmpResponseProj.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																														   new System.Data.Common.DataTableMapping("Table", "GEN_Assignments", new System.Data.Common.DataColumnMapping[] {
																																																											  new System.Data.Common.DataColumnMapping("AssignmentD", "AssignmentD"),
																																																											  new System.Data.Common.DataColumnMapping("TaskID", "TaskID"),
																																																											  new System.Data.Common.DataColumnMapping("ResponsID", "ResponsID"),
																																																											  new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																											  new System.Data.Common.DataColumnMapping("AssignmentDate", "AssignmentDate"),
																																																											  new System.Data.Common.DataColumnMapping("AssginedBy", "AssginedBy"),
																																																											  new System.Data.Common.DataColumnMapping("AssignmentPriority", "AssignmentPriority"),
																																																											  new System.Data.Common.DataColumnMapping("AssignmentStatus", "AssignmentStatus"),
																																																											  new System.Data.Common.DataColumnMapping("AssignmentEvalutation", "AssignmentEvalutation"),
																																																											  new System.Data.Common.DataColumnMapping("AssignmentScore", "AssignmentScore")})});
			this.oleDbDataAdapterAssInEmpResponseProj.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = @"DELETE FROM GEN_Assignments WHERE (AssignmentD = ?) AND (AssginedBy = ?) AND (AssignmentDate = ?) AND (AssignmentEvalutation = ? OR ? IS NULL AND AssignmentEvalutation IS NULL) AND (AssignmentPriority = ? OR ? IS NULL AND AssignmentPriority IS NULL) AND (AssignmentScore = ? OR ? IS NULL AND AssignmentScore IS NULL) AND (AssignmentStatus = ?) AND (ContactID = ? OR ? IS NULL AND ContactID IS NULL) AND (ResponsID = ? OR ? IS NULL AND ResponsID IS NULL) AND (TaskID = ? OR ? IS NULL AND TaskID IS NULL)";
			this.oleDbDeleteCommand2.Connection = this.con1;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentD", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssginedBy", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssginedBy", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentEvalutation", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentEvalutation", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentEvalutation1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentEvalutation", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentPriority", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentPriority", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentPriority1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentPriority", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentScore", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentScore", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentScore1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentScore", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentStatus", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentStatus", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ResponsID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResponsID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ResponsID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResponsID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO GEN_Assignments(AssignmentD, TaskID, ResponsID, ContactID, Assignment" +
				"Date, AssginedBy, AssignmentPriority, AssignmentStatus, AssignmentEvalutation, A" +
				"ssignmentScore) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand2.Connection = this.con1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, "AssignmentD"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskID", System.Data.OleDb.OleDbType.Integer, 4, "TaskID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsID", System.Data.OleDb.OleDbType.Integer, 4, "ResponsID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "AssignmentDate"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssginedBy", System.Data.OleDb.OleDbType.Integer, 4, "AssginedBy"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentPriority", System.Data.OleDb.OleDbType.Integer, 4, "AssignmentPriority"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentStatus", System.Data.OleDb.OleDbType.SmallInt, 2, "AssignmentStatus"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentEvalutation", System.Data.OleDb.OleDbType.SmallInt, 2, "AssignmentEvalutation"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentScore", System.Data.OleDb.OleDbType.SmallInt, 2, "AssignmentScore"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = @"SELECT GEN_Assignments.AssignmentD, GEN_Assignments.TaskID, GEN_Assignments.ResponsID, GEN_Assignments.ContactID, GEN_Assignments.AssignmentDate, GEN_Assignments.AssginedBy, GEN_Assignments.AssignmentPriority, GEN_Assignments.AssignmentStatus, GEN_Assignments.AssignmentEvalutation, GEN_Assignments.AssignmentScore, GEN_Tasks.TaskName FROM GEN_Assignments INNER JOIN GEN_Tasks ON GEN_Assignments.TaskID = GEN_Tasks.TaskID INNER JOIN GEN_Projects ON GEN_Tasks.projectID = GEN_Projects.projectID WHERE (GEN_Assignments.ContactID = ?) AND (GEN_Projects.projectID = ?) AND (GEN_Assignments.ResponsID = ?) ORDER BY GEN_Assignments.AssignmentPriority, GEN_Tasks.TaskName";
			this.oleDbSelectCommand2.Connection = this.con1;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("projectID", System.Data.OleDb.OleDbType.Integer, 4, "projectID"));
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsID", System.Data.OleDb.OleDbType.Integer, 4, "ResponsID"));
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = @"UPDATE GEN_Assignments SET AssignmentD = ?, TaskID = ?, ResponsID = ?, ContactID = ?, AssignmentDate = ?, AssginedBy = ?, AssignmentPriority = ?, AssignmentStatus = ?, AssignmentEvalutation = ?, AssignmentScore = ? WHERE (AssignmentD = ?) AND (AssginedBy = ?) AND (AssignmentDate = ?) AND (AssignmentEvalutation = ? OR ? IS NULL AND AssignmentEvalutation IS NULL) AND (AssignmentPriority = ? OR ? IS NULL AND AssignmentPriority IS NULL) AND (AssignmentScore = ? OR ? IS NULL AND AssignmentScore IS NULL) AND (AssignmentStatus = ?) AND (ContactID = ? OR ? IS NULL AND ContactID IS NULL) AND (ResponsID = ? OR ? IS NULL AND ResponsID IS NULL) AND (TaskID = ? OR ? IS NULL AND TaskID IS NULL)";
			this.oleDbUpdateCommand2.Connection = this.con1;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, "AssignmentD"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskID", System.Data.OleDb.OleDbType.Integer, 4, "TaskID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsID", System.Data.OleDb.OleDbType.Integer, 4, "ResponsID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "AssignmentDate"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssginedBy", System.Data.OleDb.OleDbType.Integer, 4, "AssginedBy"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentPriority", System.Data.OleDb.OleDbType.Integer, 4, "AssignmentPriority"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentStatus", System.Data.OleDb.OleDbType.SmallInt, 2, "AssignmentStatus"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentEvalutation", System.Data.OleDb.OleDbType.SmallInt, 2, "AssignmentEvalutation"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentScore", System.Data.OleDb.OleDbType.SmallInt, 2, "AssignmentScore"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentD", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssginedBy", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssginedBy", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentEvalutation", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentEvalutation", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentEvalutation1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentEvalutation", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentPriority", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentPriority", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentPriority1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentPriority", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentScore", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentScore", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentScore1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentScore", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentStatus", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentStatus", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ResponsID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResponsID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ResponsID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResponsID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskID", System.Data.DataRowVersion.Original, null));
			// 
			// odaResponsAssignemntsnoProject
			// 
			this.odaResponsAssignemntsnoProject.SelectCommand = this.oleDbSelectCommand3;
			this.odaResponsAssignemntsnoProject.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													 new System.Data.Common.DataTableMapping("Table", "GEN_Assignments", new System.Data.Common.DataColumnMapping[] {
																																																										new System.Data.Common.DataColumnMapping("AssignmentD", "AssignmentD"),
																																																										new System.Data.Common.DataColumnMapping("TaskID", "TaskID"),
																																																										new System.Data.Common.DataColumnMapping("ResponsID", "ResponsID"),
																																																										new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																										new System.Data.Common.DataColumnMapping("AssignmentDate", "AssignmentDate"),
																																																										new System.Data.Common.DataColumnMapping("AssginedBy", "AssginedBy"),
																																																										new System.Data.Common.DataColumnMapping("AssignmentPriority", "AssignmentPriority"),
																																																										new System.Data.Common.DataColumnMapping("AssignmentStatus", "AssignmentStatus"),
																																																										new System.Data.Common.DataColumnMapping("AssignmentEvalutation", "AssignmentEvalutation"),
																																																										new System.Data.Common.DataColumnMapping("AssignmentScore", "AssignmentScore")})});
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = @"SELECT GEN_Assignments.AssignmentD, GEN_Assignments.TaskID, GEN_Assignments.ResponsID, GEN_Assignments.ContactID, GEN_Assignments.AssignmentDate, GEN_Assignments.AssginedBy, GEN_Assignments.AssignmentPriority, GEN_Assignments.AssignmentStatus, GEN_Assignments.AssignmentEvalutation, GEN_Assignments.AssignmentScore, GEN_Tasks.TaskName FROM GEN_Assignments INNER JOIN GEN_Tasks ON GEN_Assignments.TaskID = GEN_Tasks.TaskID WHERE (GEN_Assignments.ContactID = ?) AND (GEN_Assignments.ResponsID = ?) AND (GEN_Tasks.projectID IS NULL) ORDER BY GEN_Assignments.AssignmentPriority, GEN_Tasks.TaskName";
			this.oleDbSelectCommand3.Connection = this.con1;
			this.oleDbSelectCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbSelectCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsID", System.Data.OleDb.OleDbType.Integer, 4, "ResponsID"));
			// 
			// odcTaskNAme
			// 
			this.odcTaskNAme.CommandText = "SELECT GEN_Tasks.TaskName FROM GEN_Tasks INNER JOIN GEN_Assignments ON GEN_Tasks." +
				"TaskID = GEN_Assignments.TaskID WHERE (GEN_Assignments.AssignmentD = ?)";
			this.odcTaskNAme.Connection = this.con1;
			this.odcTaskNAme.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, "AssignmentD"));
			// 
			// odaAssginmentsnoProject
			// 
			this.odaAssginmentsnoProject.SelectCommand = this.oleDbSelectCommand5;
			this.odaAssginmentsnoProject.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											  new System.Data.Common.DataTableMapping("Table", "GEN_Assignments", new System.Data.Common.DataColumnMapping[] {
																																																								 new System.Data.Common.DataColumnMapping("AssignmentD", "AssignmentD"),
																																																								 new System.Data.Common.DataColumnMapping("TaskID", "TaskID"),
																																																								 new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																								 new System.Data.Common.DataColumnMapping("AssignmentDate", "AssignmentDate"),
																																																								 new System.Data.Common.DataColumnMapping("AssginedBy", "AssginedBy"),
																																																								 new System.Data.Common.DataColumnMapping("AssignmentPriority", "AssignmentPriority"),
																																																								 new System.Data.Common.DataColumnMapping("AssignmentStatus", "AssignmentStatus"),
																																																								 new System.Data.Common.DataColumnMapping("AssignmentEvalutation", "AssignmentEvalutation"),
																																																								 new System.Data.Common.DataColumnMapping("AssignmentScore", "AssignmentScore")})});
			// 
			// oleDbSelectCommand5
			// 
			this.oleDbSelectCommand5.CommandText = @"SELECT GEN_Assignments.AssignmentD, GEN_Assignments.TaskID, GEN_Assignments.ContactID, GEN_Assignments.AssignmentDate, GEN_Assignments.AssginedBy, GEN_Assignments.AssignmentPriority, GEN_Assignments.AssignmentStatus, GEN_Assignments.AssignmentEvalutation, GEN_Assignments.AssignmentScore FROM GEN_Assignments INNER JOIN GEN_Tasks ON GEN_Assignments.TaskID = GEN_Tasks.TaskID WHERE (GEN_Assignments.ContactID = ?) AND (GEN_Tasks.projectID IS NULL) ORDER BY GEN_Tasks.TaskUnit DESC";
			this.oleDbSelectCommand5.Connection = this.con1;
			this.oleDbSelectCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			// 
			// oaAssginemetnsByProject
			// 
			this.oaAssginemetnsByProject.SelectCommand = this.oleDbSelectCommand6;
			this.oaAssginemetnsByProject.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											  new System.Data.Common.DataTableMapping("Table", "GEN_Assignments", new System.Data.Common.DataColumnMapping[] {
																																																								 new System.Data.Common.DataColumnMapping("AssignmentD", "AssignmentD"),
																																																								 new System.Data.Common.DataColumnMapping("TaskID", "TaskID"),
																																																								 new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																								 new System.Data.Common.DataColumnMapping("AssignmentDate", "AssignmentDate"),
																																																								 new System.Data.Common.DataColumnMapping("AssginedBy", "AssginedBy"),
																																																								 new System.Data.Common.DataColumnMapping("AssignmentPriority", "AssignmentPriority"),
																																																								 new System.Data.Common.DataColumnMapping("AssignmentStatus", "AssignmentStatus"),
																																																								 new System.Data.Common.DataColumnMapping("AssignmentEvalutation", "AssignmentEvalutation"),
																																																								 new System.Data.Common.DataColumnMapping("AssignmentScore", "AssignmentScore")})});
			// 
			// oleDbSelectCommand6
			// 
			this.oleDbSelectCommand6.CommandText = @"SELECT GEN_Assignments.AssignmentD, GEN_Assignments.TaskID, GEN_Assignments.ContactID, GEN_Assignments.AssignmentDate, GEN_Assignments.AssginedBy, GEN_Assignments.AssignmentPriority, GEN_Assignments.AssignmentStatus, GEN_Assignments.AssignmentEvalutation, GEN_Assignments.AssignmentScore, GEN_Assignments.ResponsID FROM GEN_Assignments INNER JOIN GEN_Tasks ON GEN_Assignments.TaskID = GEN_Tasks.TaskID WHERE (GEN_Assignments.ContactID = ?) AND (GEN_Tasks.projectID = ?)";
			this.oleDbSelectCommand6.Connection = this.con1;
			this.oleDbSelectCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbSelectCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("projectID", System.Data.OleDb.OleDbType.Integer, 4, "projectID"));
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"User ID=RW;Data Source=""erp\erpsql2005"";Tag with column collation when possible=False;Initial Catalog=TestAccountability_Data;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=HAMDYAHMED;Use Encryption for Data=False;Packet Size=4096";
			// 
			// oleDbDataAdapterAssignmentsInEmpRespons
			// 
			this.oleDbDataAdapterAssignmentsInEmpRespons.DeleteCommand = this.oleDbDeleteCommand3;
			this.oleDbDataAdapterAssignmentsInEmpRespons.InsertCommand = this.oleDbInsertCommand3;
			this.oleDbDataAdapterAssignmentsInEmpRespons.SelectCommand = this.oleDbSelectCommand4;
			this.oleDbDataAdapterAssignmentsInEmpRespons.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																															  new System.Data.Common.DataTableMapping("Table", "GEN_Assignments", new System.Data.Common.DataColumnMapping[] {
																																																												 new System.Data.Common.DataColumnMapping("AssignmentD", "AssignmentD"),
																																																												 new System.Data.Common.DataColumnMapping("TaskID", "TaskID"),
																																																												 new System.Data.Common.DataColumnMapping("ResponsID", "ResponsID"),
																																																												 new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																												 new System.Data.Common.DataColumnMapping("AssignmentDate", "AssignmentDate"),
																																																												 new System.Data.Common.DataColumnMapping("AssginedBy", "AssginedBy"),
																																																												 new System.Data.Common.DataColumnMapping("AssignmentPriority", "AssignmentPriority"),
																																																												 new System.Data.Common.DataColumnMapping("AssignmentStatus", "AssignmentStatus"),
																																																												 new System.Data.Common.DataColumnMapping("AssignmentEvalutation", "AssignmentEvalutation"),
																																																												 new System.Data.Common.DataColumnMapping("AssignmentScore", "AssignmentScore")})});
			this.oleDbDataAdapterAssignmentsInEmpRespons.UpdateCommand = this.oleDbUpdateCommand3;
			// 
			// oleDbDeleteCommand3
			// 
			this.oleDbDeleteCommand3.CommandText = @"DELETE FROM GEN_Assignments WHERE (AssignmentD = ?) AND (AssginedBy = ?) AND (AssignmentDate = ?) AND (AssignmentEvalutation = ? OR ? IS NULL AND AssignmentEvalutation IS NULL) AND (AssignmentPriority = ? OR ? IS NULL AND AssignmentPriority IS NULL) AND (AssignmentScore = ? OR ? IS NULL AND AssignmentScore IS NULL) AND (AssignmentStatus = ?) AND (ContactID = ? OR ? IS NULL AND ContactID IS NULL) AND (ResponsID = ? OR ? IS NULL AND ResponsID IS NULL) AND (TaskID = ? OR ? IS NULL AND TaskID IS NULL)";
			this.oleDbDeleteCommand3.Connection = this.con1;
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentD", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssginedBy", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssginedBy", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentEvalutation", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentEvalutation", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentEvalutation1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentEvalutation", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentPriority", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentPriority", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentPriority1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentPriority", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentScore", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentScore", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentScore1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentScore", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentStatus", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentStatus", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ResponsID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResponsID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ResponsID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResponsID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand3
			// 
			this.oleDbInsertCommand3.CommandText = @"INSERT INTO GEN_Assignments(AssignmentD, TaskID, ResponsID, ContactID, AssignmentDate, AssginedBy, AssignmentPriority, AssignmentStatus, AssignmentEvalutation, AssignmentScore) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?); SELECT AssignmentD, TaskID, ResponsID, ContactID, AssignmentDate, AssginedBy, AssignmentPriority, AssignmentStatus, AssignmentEvalutation, AssignmentScore FROM GEN_Assignments WHERE (AssignmentD = ?)";
			this.oleDbInsertCommand3.Connection = this.con1;
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, "AssignmentD"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskID", System.Data.OleDb.OleDbType.Integer, 4, "TaskID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsID", System.Data.OleDb.OleDbType.Integer, 4, "ResponsID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "AssignmentDate"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssginedBy", System.Data.OleDb.OleDbType.Integer, 4, "AssginedBy"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentPriority", System.Data.OleDb.OleDbType.Integer, 4, "AssignmentPriority"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentStatus", System.Data.OleDb.OleDbType.SmallInt, 2, "AssignmentStatus"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentEvalutation", System.Data.OleDb.OleDbType.SmallInt, 2, "AssignmentEvalutation"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentScore", System.Data.OleDb.OleDbType.SmallInt, 2, "AssignmentScore"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, "AssignmentD"));
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = "SELECT AssignmentD, TaskID, ResponsID, ContactID, AssignmentDate, AssginedBy, Ass" +
				"ignmentPriority, AssignmentStatus, AssignmentEvalutation, AssignmentScore FROM G" +
				"EN_Assignments WHERE (ResponsID = ?) AND (ContactID = ?)";
			this.oleDbSelectCommand4.Connection = this.con1;
			this.oleDbSelectCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsID", System.Data.OleDb.OleDbType.Integer, 4, "ResponsID"));
			this.oleDbSelectCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			// 
			// oleDbUpdateCommand3
			// 
			this.oleDbUpdateCommand3.CommandText = @"UPDATE GEN_Assignments SET AssignmentD = ?, TaskID = ?, ResponsID = ?, ContactID = ?, AssignmentDate = ?, AssginedBy = ?, AssignmentPriority = ?, AssignmentStatus = ?, AssignmentEvalutation = ?, AssignmentScore = ? WHERE (AssignmentD = ?) AND (AssginedBy = ?) AND (AssignmentDate = ?) AND (AssignmentEvalutation = ? OR ? IS NULL AND AssignmentEvalutation IS NULL) AND (AssignmentPriority = ? OR ? IS NULL AND AssignmentPriority IS NULL) AND (AssignmentScore = ? OR ? IS NULL AND AssignmentScore IS NULL) AND (AssignmentStatus = ?) AND (ContactID = ? OR ? IS NULL AND ContactID IS NULL) AND (ResponsID = ? OR ? IS NULL AND ResponsID IS NULL) AND (TaskID = ? OR ? IS NULL AND TaskID IS NULL); SELECT AssignmentD, TaskID, ResponsID, ContactID, AssignmentDate, AssginedBy, AssignmentPriority, AssignmentStatus, AssignmentEvalutation, AssignmentScore FROM GEN_Assignments WHERE (AssignmentD = ?)";
			this.oleDbUpdateCommand3.Connection = this.con1;
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, "AssignmentD"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskID", System.Data.OleDb.OleDbType.Integer, 4, "TaskID"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsID", System.Data.OleDb.OleDbType.Integer, 4, "ResponsID"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "AssignmentDate"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssginedBy", System.Data.OleDb.OleDbType.Integer, 4, "AssginedBy"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentPriority", System.Data.OleDb.OleDbType.Integer, 4, "AssignmentPriority"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentStatus", System.Data.OleDb.OleDbType.SmallInt, 2, "AssignmentStatus"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentEvalutation", System.Data.OleDb.OleDbType.SmallInt, 2, "AssignmentEvalutation"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentScore", System.Data.OleDb.OleDbType.SmallInt, 2, "AssignmentScore"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentD", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssginedBy", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssginedBy", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentEvalutation", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentEvalutation", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentEvalutation1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentEvalutation", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentPriority", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentPriority", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentPriority1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentPriority", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentScore", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentScore", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentScore1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentScore", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentStatus", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentStatus", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ResponsID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResponsID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ResponsID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResponsID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TaskID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TaskID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, "AssignmentD"));
			// 
			// oleDbDataAdapterEmpAssignments
			// 
			this.oleDbDataAdapterEmpAssignments.SelectCommand = this.oleDbSelectCommand7;
			this.oleDbDataAdapterEmpAssignments.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													 new System.Data.Common.DataTableMapping("Table", "GEN_Assignments", new System.Data.Common.DataColumnMapping[] {
																																																										new System.Data.Common.DataColumnMapping("AssignmentD", "AssignmentD"),
																																																										new System.Data.Common.DataColumnMapping("TaskID", "TaskID"),
																																																										new System.Data.Common.DataColumnMapping("ResponsID", "ResponsID"),
																																																										new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																										new System.Data.Common.DataColumnMapping("AssignmentDate", "AssignmentDate"),
																																																										new System.Data.Common.DataColumnMapping("AssginedBy", "AssginedBy"),
																																																										new System.Data.Common.DataColumnMapping("AssignmentPriority", "AssignmentPriority"),
																																																										new System.Data.Common.DataColumnMapping("AssignmentStatus", "AssignmentStatus"),
																																																										new System.Data.Common.DataColumnMapping("AssignmentEvalutation", "AssignmentEvalutation"),
																																																										new System.Data.Common.DataColumnMapping("AssignmentScore", "AssignmentScore")})});
			// 
			// oleDbSelectCommand7
			// 
			this.oleDbSelectCommand7.CommandText = "SELECT AssignmentD, TaskID, ResponsID, ContactID, AssignmentDate, AssginedBy, Ass" +
				"ignmentPriority, AssignmentStatus, AssignmentEvalutation, AssignmentScore FROM G" +
				"EN_Assignments WHERE (ContactID = ?)";
			this.oleDbSelectCommand7.Connection = this.con1;
			this.oleDbSelectCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			// 
			// odcGetCompletedDate
			// 
			this.odcGetCompletedDate.CommandText = @"SELECT GEN_Transactions.TransTime FROM GEN_AssgimentTransactions INNER JOIN GEN_Transactions ON GEN_AssgimentTransactions.TransID = GEN_Transactions.TransID WHERE (GEN_AssgimentTransactions.NewStatus = 3) AND (GEN_AssgimentTransactions.AssignmentD = ?) ORDER BY GEN_AssgimentTransactions.TransID DESC";
			this.odcGetCompletedDate.Connection = this.con1;
			this.odcGetCompletedDate.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, "AssignmentD"));
			// 
			// odcChangeAssginmentResponse
			// 
			this.odcChangeAssginmentResponse.CommandText = "UPDATE GEN_Assignments SET ResponsID = ? WHERE (AssignmentD = ?)";
			this.odcChangeAssginmentResponse.Connection = this.con1;
			this.odcChangeAssginmentResponse.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsID", System.Data.OleDb.OleDbType.Integer, 4, "ResponsID"));
			this.odcChangeAssginmentResponse.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentD", System.Data.DataRowVersion.Original, null));
			// 
			// AssignmentsDataClass
			// 
			this.ComponentDataAdabter = this.odaAssgiments;
			this.ComponentDataSet = this.dsAssignments1;
			this.Connection = this.con1;
			((System.ComponentModel.ISupportInitialize)(this.dsAssignments1)).EndInit();

		}
		#endregion

		
		#region ViewTaskAssignments

		public DataSet ViewTaskAssignments ( int taskID )
		{
			return List("TaskID = " + taskID.ToString());
		}
		#endregion 

		#region ViewResponsAssignments

		public DataSet ViewResponsAssignments ( int responseID )
		{
			return List("ResponsID =" + responseID.ToString());
		}
		
		#endregion 

		#region ViewEmpAssignentsInResponsibility

		public DataSet ViewEmpAssignentsInResponsibility ( int empID , int responseID )
		{
			return List("ContactID = " + empID.ToString()+" and ResponsID = " + responseID.ToString());
		}
		
		#endregion 

		#region ViewEmpAssignentsInProjectResponsibility

		public DataSet ViewEmpAssignentsInProjectResponsibility ( int empID , int responseID , int projID )
		{
			dsAssignments1.Clear();
			oleDbDataAdapterAssInEmpResponseProj.SelectCommand.Parameters[ "ResponsID"  ].Value =  responseID ;
			oleDbDataAdapterAssInEmpResponseProj.SelectCommand.Parameters[ "ContactID"  ].Value =  empID ;
			oleDbDataAdapterAssInEmpResponseProj.SelectCommand.Parameters[ "projectID"  ].Value =  projID ;
			oleDbDataAdapterAssInEmpResponseProj.Fill( dsAssignments1 );
			return dsAssignments1;
		}
		public DataSet ViewEmpAssignentsInResponsibilityWithNoProject ( int empID , int responseID  )
		{
			dsAssignments1.Clear();
			odaResponsAssignemntsnoProject.SelectCommand.Parameters["ContactID"].Value = empID;
			odaResponsAssignemntsnoProject.SelectCommand.Parameters["ResponsID"].Value = responseID;
			odaResponsAssignemntsnoProject.Fill(dsAssignments1);
			return dsAssignments1;
		}
		public DataSet ViewEmpAssignentsWithNoProject ( int empID)
		{
			dsAssignments1.Clear();
			odaAssginmentsnoProject.SelectCommand.Parameters["ContactID"].Value = empID;
			odaAssginmentsnoProject.Fill(dsAssignments1);
			return dsAssignments1;
		}
		public DataSet ViewEmpAssignentsByProject ( int empID, int projectID)
		{
			dsAssignments1.Clear();
			oaAssginemetnsByProject.SelectCommand.Parameters["ContactID"].Value = empID;
			oaAssginemetnsByProject.SelectCommand.Parameters["projectID"].Value = projectID;
			oaAssginemetnsByProject.Fill(dsAssignments1);
			return dsAssignments1;
		}
		#endregion 

		#region GetAssginemtTaskName

		public string GetAssginemtTaskName(int AssigenmentID)
		{
			odcTaskNAme.Parameters[0].Value = AssigenmentID;
			return odcTaskNAme.ExecuteScalar().ToString();
		}
		

		#endregion 

		
		#region GetEmpAssginemts

		public dsAssignments GetEmpAssginemts(int empID)
		{
			dsAssignments1.Clear();
			oleDbDataAdapterEmpAssignments.SelectCommand.Parameters[0].Value = empID;
			oleDbDataAdapterEmpAssignments.Fill( dsAssignments1 );
			return dsAssignments1;

		}
		

		#endregion 

		#region Assign Task  

		public int AssginTask( int TaskId, int EmployeeID,int ResponsID, int Priority )
		{
			Data.dsAssignments dsAss	 = new TSN.ERP.SharedComponents.Data.dsAssignments();
			dsAss.EnforceConstraints	 = false;
			dsAss.Clear();
			dsAss.Merge(List("TaskID = " + TaskId + " and ContactID = " + EmployeeID + " and AssignmentStatus <> 3"));
			if (dsAss.GEN_Assignments.Rows.Count > 0)
				return 0;
			Data.dsAssignments.GEN_AssignmentsRow AssRow = dsAss.GEN_Assignments.NewGEN_AssignmentsRow();
			AssRow.AssginedBy			 = ActiveSession.UserId;
			AssRow.AssignmentDate		 = DateTime.Now;
			AssRow.AssignmentEvalutation = (Int32)Data.AssignmentsDataClass.AssignmentEvaluation.NotEvaluated ;
			AssRow.AssignmentStatus		 = (Int32)Data.AssignmentsDataClass.AssignmentStatus.Planed;
			AssRow.AssignmentPriority	 = Priority;
			AssRow.TaskID				 = TaskId;
			AssRow.ContactID			 = EmployeeID;
			AssRow.ResponsID			 = ResponsID;
			
			dsAss.GEN_Assignments.AddGEN_AssignmentsRow(AssRow);
			if  (this.Add(dsAss)== 1)
			{
				dsAss.Merge( this.ComponentDataSet );
				return  AssRow.AssignmentD;
			}
			return -1;
		}


		public int AssginTask( int TaskId, int EmployeeID )
		{
			Data.dsAssignments dsAss	 = new TSN.ERP.SharedComponents.Data.dsAssignments();
			dsAss.EnforceConstraints	 = false;
			Data.dsAssignments.GEN_AssignmentsRow AssRow = dsAss.GEN_Assignments.NewGEN_AssignmentsRow();
			AssRow.AssginedBy			 = ActiveSession.UserId;
			AssRow.AssignmentDate		 = DateTime.Now;
			AssRow.AssignmentEvalutation = (Int32)Data.AssignmentsDataClass.AssignmentEvaluation.NotEvaluated ;
			AssRow.AssignmentStatus		 = (Int32)Data.AssignmentsDataClass.AssignmentStatus.Planed;
			AssRow.TaskID				 = TaskId;
			AssRow.ContactID			 = EmployeeID;
			
			dsAss.GEN_Assignments.AddGEN_AssignmentsRow(AssRow);
			if  (this.Add(dsAss)== 1)
			{
				dsAss.Merge( this.ComponentDataSet );
				return  AssRow.AssignmentD;
			}
			return -1;
		}

		
		public int AssginTask( int TaskId, int EmployeeID,int ResponsID, int Priority , DateTime assDate )
		{
			Data.dsAssignments dsAss	 = new TSN.ERP.SharedComponents.Data.dsAssignments();
			dsAss.EnforceConstraints	 = false;
			Data.dsAssignments.GEN_AssignmentsRow AssRow = dsAss.GEN_Assignments.NewGEN_AssignmentsRow();
			AssRow.AssginedBy			 = ActiveSession.UserId;
			AssRow.AssignmentDate		 = assDate;
			AssRow.AssignmentEvalutation = (Int32)Data.AssignmentsDataClass.AssignmentEvaluation.NotEvaluated ;
			AssRow.AssignmentStatus		 = (Int32)Data.AssignmentsDataClass.AssignmentStatus.Planed;
			AssRow.AssignmentPriority	 = Priority;
			AssRow.TaskID				 = TaskId;
			AssRow.ContactID			 = EmployeeID;
			AssRow.ResponsID			 = ResponsID;
			
			dsAss.GEN_Assignments.AddGEN_AssignmentsRow(AssRow);
			if  (this.Add(dsAss)== 1)
			{
				dsAss.Merge( this.ComponentDataSet );
				return  AssRow.AssignmentD;
			}
			return -1;
		}


		public int AssginTask( int TaskId, int EmployeeID , DateTime assDate )
		{
			Data.dsAssignments dsAss	 = new TSN.ERP.SharedComponents.Data.dsAssignments();
			dsAss.EnforceConstraints	 = false;
			Data.dsAssignments.GEN_AssignmentsRow AssRow = dsAss.GEN_Assignments.NewGEN_AssignmentsRow();
			AssRow.AssginedBy			 = ActiveSession.UserId;
			AssRow.AssignmentDate		 = assDate;
			AssRow.AssignmentEvalutation = (Int32)Data.AssignmentsDataClass.AssignmentEvaluation.NotEvaluated ;
			AssRow.AssignmentStatus		 = (Int32)Data.AssignmentsDataClass.AssignmentStatus.Planed;
			AssRow.TaskID				 = TaskId;
			AssRow.ContactID			 = EmployeeID;
			
			dsAss.GEN_Assignments.AddGEN_AssignmentsRow(AssRow);
			if  (this.Add(dsAss)== 1)
			{
				dsAss.Merge( this.ComponentDataSet );
				return  AssRow.AssignmentD;
			}
			return -1;
		}


		#endregion


		public bool ChangeResponspility(int AssID,int ReponseID)
		{
			odcChangeAssginmentResponse.Parameters["ResponsID"].Value = ReponseID;
			odcChangeAssginmentResponse.Parameters["Original_AssignmentD"].Value = AssID;
			int retval = odcChangeAssginmentResponse.ExecuteNonQuery();
			if (retval != 1)
				return false;
			return true;
		}

		public DateTime GetAssginmentCompleteDate(int AssID)
		{
			odcGetCompletedDate.Parameters[0].Value = AssID;
			Object tempObject = odcGetCompletedDate.ExecuteScalar();
			if (tempObject == null)
				return new DateTime();
			return (DateTime)tempObject;
		}

	}
}
