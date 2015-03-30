using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for EmployeeData.
	/// </summary>
	public class EmployeeData : TSN.ERP.Engine.BussinesComponent  
	{
		private System.Data.OleDb.OleDbDataAdapter odaEmployee;
		private System.Data.OleDb.OleDbConnection con1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterProjectEmployees;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Data.OleDb.OleDbDataAdapter odaEmployeesByTeam;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		private System.Data.OleDb.OleDbDataAdapter odaEmployeesByProject;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand5;
		private TSN.ERP.SharedComponents.Data.dsEmployeeOrginal dsEmployeeOrginal1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterTaskEmployees;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterEmpSummData;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand6;
        private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterDsEmployee;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EmployeeData(System.ComponentModel.IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			container.Add(this);
			InitializeComponent();
		}

		public EmployeeData()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();

			ParentComponent = new ContactsData();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeData));
            this.odaEmployee = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.con1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDataAdapterProjectEmployees = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            this.odaEmployeesByTeam = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
            this.odaEmployeesByProject = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
            this.dsEmployeeOrginal1 = new TSN.ERP.SharedComponents.Data.dsEmployeeOrginal();
            this.oleDbDataAdapterTaskEmployees = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDataAdapterEmpSummData = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand6 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDataAdapterDsEmployee = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmployeeOrginal1)).BeginInit();
            // 
            // odaEmployee
            // 
            this.odaEmployee.DeleteCommand = this.oleDbDeleteCommand1;
            this.odaEmployee.InsertCommand = this.oleDbInsertCommand1;
            this.odaEmployee.SelectCommand = this.oleDbSelectCommand1;
            this.odaEmployee.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GEN_Employees", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
                        new System.Data.Common.DataColumnMapping("JobTitleID", "JobTitleID"),
                        new System.Data.Common.DataColumnMapping("FileID", "FileID"),
                        new System.Data.Common.DataColumnMapping("CompElmentID", "CompElmentID"),
                        new System.Data.Common.DataColumnMapping("EmployeeStatus", "EmployeeStatus"),
                        new System.Data.Common.DataColumnMapping("EmpHireDate", "EmpHireDate"),
                        new System.Data.Common.DataColumnMapping("EmpCode", "EmpCode"),
                        new System.Data.Common.DataColumnMapping("EmpTerminationDate", "EmpTerminationDate"),
                        new System.Data.Common.DataColumnMapping("FileIDHR", "FileIDHR")})});
            this.odaEmployee.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = resources.GetString("oleDbDeleteCommand1.CommandText");
            this.oleDbDeleteCommand1.Connection = this.con1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_JobTitleID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "JobTitleID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_JobTitleID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "JobTitleID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FileID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FileID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FileID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FileID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompElmentID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompElmentID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompElmentID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompElmentID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_EmployeeStatus", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EmployeeStatus", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EmpHireDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EmpHireDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EmpHireDate", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EmpHireDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EmpCode", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EmpCode", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EmpCode", System.Data.OleDb.OleDbType.Char, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EmpCode", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EmpTerminationDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EmpTerminationDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EmpTerminationDate", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EmpTerminationDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FileIDHR", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FileIDHR", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FileIDHR", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FileIDHR", System.Data.DataRowVersion.Original, null)});
            // 
            // con1
            // 
            this.con1.ConnectionString = "Provider=SQLNCLI.1;Data Source=MISSERVER;Password=RW;User ID=RW;Initial Catalog=T" +
                "estAccountability_Data";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [GEN_Employees] ([ContactID], [JobTitleID], [FileID], [CompElmentID]," +
                " [EmployeeStatus], [EmpHireDate], [EmpCode], [EmpTerminationDate], [FileIDHR]) V" +
                "ALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.con1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 0, "ContactID"),
            new System.Data.OleDb.OleDbParameter("JobTitleID", System.Data.OleDb.OleDbType.Integer, 0, "JobTitleID"),
            new System.Data.OleDb.OleDbParameter("FileID", System.Data.OleDb.OleDbType.Integer, 0, "FileID"),
            new System.Data.OleDb.OleDbParameter("CompElmentID", System.Data.OleDb.OleDbType.Integer, 0, "CompElmentID"),
            new System.Data.OleDb.OleDbParameter("EmployeeStatus", System.Data.OleDb.OleDbType.SmallInt, 0, "EmployeeStatus"),
            new System.Data.OleDb.OleDbParameter("EmpHireDate", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "EmpHireDate"),
            new System.Data.OleDb.OleDbParameter("EmpCode", System.Data.OleDb.OleDbType.Char, 0, "EmpCode"),
            new System.Data.OleDb.OleDbParameter("EmpTerminationDate", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "EmpTerminationDate"),
            new System.Data.OleDb.OleDbParameter("FileIDHR", System.Data.OleDb.OleDbType.Integer, 0, "FileIDHR")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT     ContactID, JobTitleID, FileID, CompElmentID, EmployeeStatus, EmpHireDa" +
                "te, EmpCode, EmpTerminationDate, FileIDHR\r\nFROM         GEN_Employees";
            this.oleDbSelectCommand1.Connection = this.con1;
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.con1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 0, "ContactID"),
            new System.Data.OleDb.OleDbParameter("JobTitleID", System.Data.OleDb.OleDbType.Integer, 0, "JobTitleID"),
            new System.Data.OleDb.OleDbParameter("FileID", System.Data.OleDb.OleDbType.Integer, 0, "FileID"),
            new System.Data.OleDb.OleDbParameter("CompElmentID", System.Data.OleDb.OleDbType.Integer, 0, "CompElmentID"),
            new System.Data.OleDb.OleDbParameter("EmployeeStatus", System.Data.OleDb.OleDbType.SmallInt, 0, "EmployeeStatus"),
            new System.Data.OleDb.OleDbParameter("EmpHireDate", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "EmpHireDate"),
            new System.Data.OleDb.OleDbParameter("EmpCode", System.Data.OleDb.OleDbType.Char, 0, "EmpCode"),
            new System.Data.OleDb.OleDbParameter("EmpTerminationDate", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "EmpTerminationDate"),
            new System.Data.OleDb.OleDbParameter("FileIDHR", System.Data.OleDb.OleDbType.Integer, 0, "FileIDHR"),
            new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_JobTitleID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "JobTitleID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_JobTitleID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "JobTitleID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FileID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FileID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FileID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FileID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompElmentID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompElmentID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompElmentID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompElmentID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_EmployeeStatus", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EmployeeStatus", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EmpHireDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EmpHireDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EmpHireDate", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EmpHireDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EmpCode", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EmpCode", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EmpCode", System.Data.OleDb.OleDbType.Char, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EmpCode", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EmpTerminationDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EmpTerminationDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EmpTerminationDate", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EmpTerminationDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FileIDHR", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FileIDHR", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FileIDHR", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FileIDHR", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDataAdapterProjectEmployees
            // 
            this.oleDbDataAdapterProjectEmployees.DeleteCommand = this.oleDbDeleteCommand2;
            this.oleDbDataAdapterProjectEmployees.InsertCommand = this.oleDbInsertCommand2;
            this.oleDbDataAdapterProjectEmployees.SelectCommand = this.oleDbSelectCommand3;
            this.oleDbDataAdapterProjectEmployees.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GEN_Employees", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
                        new System.Data.Common.DataColumnMapping("JobTitleID", "JobTitleID"),
                        new System.Data.Common.DataColumnMapping("FileID", "FileID"),
                        new System.Data.Common.DataColumnMapping("CompElmentID", "CompElmentID"),
                        new System.Data.Common.DataColumnMapping("EmployeeStatus", "EmployeeStatus"),
                        new System.Data.Common.DataColumnMapping("EmpHireDate", "EmpHireDate"),
                        new System.Data.Common.DataColumnMapping("EmpCode", "EmpCode")})});
            this.oleDbDataAdapterProjectEmployees.UpdateCommand = this.oleDbUpdateCommand2;
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = resources.GetString("oleDbDeleteCommand2.CommandText");
            this.oleDbDeleteCommand2.Connection = this.con1;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_CompElmentID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompElmentID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_CompElmentID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompElmentID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_EmpCode", System.Data.OleDb.OleDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EmpCode", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_EmpCode1", System.Data.OleDb.OleDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EmpCode", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_EmpHireDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EmpHireDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_EmpHireDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EmpHireDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_EmployeeStatus", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EmployeeStatus", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_FileID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FileID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_FileID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FileID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "JobTitleID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_JobTitleID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "JobTitleID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = "INSERT INTO GEN_Employees(ContactID, JobTitleID, FileID, CompElmentID, EmployeeSt" +
                "atus, EmpHireDate, EmpCode) VALUES (?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand2.Connection = this.con1;
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"),
            new System.Data.OleDb.OleDbParameter("JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleID"),
            new System.Data.OleDb.OleDbParameter("FileID", System.Data.OleDb.OleDbType.Integer, 4, "FileID"),
            new System.Data.OleDb.OleDbParameter("CompElmentID", System.Data.OleDb.OleDbType.Integer, 4, "CompElmentID"),
            new System.Data.OleDb.OleDbParameter("EmployeeStatus", System.Data.OleDb.OleDbType.SmallInt, 2, "EmployeeStatus"),
            new System.Data.OleDb.OleDbParameter("EmpHireDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "EmpHireDate"),
            new System.Data.OleDb.OleDbParameter("EmpCode", System.Data.OleDb.OleDbType.VarChar, 6, "EmpCode")});
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = resources.GetString("oleDbSelectCommand3.CommandText");
            this.oleDbSelectCommand3.Connection = this.con1;
            this.oleDbSelectCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("projectID", System.Data.OleDb.OleDbType.Integer, 4, "projectID")});
            // 
            // oleDbUpdateCommand2
            // 
            this.oleDbUpdateCommand2.CommandText = resources.GetString("oleDbUpdateCommand2.CommandText");
            this.oleDbUpdateCommand2.Connection = this.con1;
            this.oleDbUpdateCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"),
            new System.Data.OleDb.OleDbParameter("JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleID"),
            new System.Data.OleDb.OleDbParameter("FileID", System.Data.OleDb.OleDbType.Integer, 4, "FileID"),
            new System.Data.OleDb.OleDbParameter("CompElmentID", System.Data.OleDb.OleDbType.Integer, 4, "CompElmentID"),
            new System.Data.OleDb.OleDbParameter("EmployeeStatus", System.Data.OleDb.OleDbType.SmallInt, 2, "EmployeeStatus"),
            new System.Data.OleDb.OleDbParameter("EmpHireDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "EmpHireDate"),
            new System.Data.OleDb.OleDbParameter("EmpCode", System.Data.OleDb.OleDbType.Char, 6, "EmpCode"),
            new System.Data.OleDb.OleDbParameter("EmpTerminationDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "EmpTerminationDate"),
            new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_CompElmentID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompElmentID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_PARAM11", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_EmpCode", System.Data.OleDb.OleDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EmpCode", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_PARAM13", System.Data.OleDb.OleDbType.VarChar, 1024, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_EmpHireDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EmpHireDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_PARAM15", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_EmployeeStatus", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EmployeeStatus", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_FileID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FileID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_PARAM18", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "JobTitleID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_PARAM20", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_EmpTerminationDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EmpTerminationDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_PARAM22", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Original, null)});
            // 
            // odaEmployeesByTeam
            // 
            this.odaEmployeesByTeam.SelectCommand = this.oleDbSelectCommand4;
            this.odaEmployeesByTeam.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GEN_Employees", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
                        new System.Data.Common.DataColumnMapping("JobTitleID", "JobTitleID"),
                        new System.Data.Common.DataColumnMapping("FileID", "FileID"),
                        new System.Data.Common.DataColumnMapping("CompElmentID", "CompElmentID"),
                        new System.Data.Common.DataColumnMapping("EmployeeStatus", "EmployeeStatus"),
                        new System.Data.Common.DataColumnMapping("EmpHireDate", "EmpHireDate"),
                        new System.Data.Common.DataColumnMapping("EmpCode", "EmpCode")})});
            // 
            // oleDbSelectCommand4
            // 
            this.oleDbSelectCommand4.CommandText = resources.GetString("oleDbSelectCommand4.CommandText");
            this.oleDbSelectCommand4.Connection = this.con1;
            this.oleDbSelectCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("TeamID", System.Data.OleDb.OleDbType.Integer, 4, "TeamID")});
            // 
            // odaEmployeesByProject
            // 
            this.odaEmployeesByProject.SelectCommand = this.oleDbSelectCommand5;
            this.odaEmployeesByProject.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GEN_Employees", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
                        new System.Data.Common.DataColumnMapping("JobTitleID", "JobTitleID"),
                        new System.Data.Common.DataColumnMapping("FileID", "FileID"),
                        new System.Data.Common.DataColumnMapping("CompElmentID", "CompElmentID"),
                        new System.Data.Common.DataColumnMapping("EmployeeStatus", "EmployeeStatus"),
                        new System.Data.Common.DataColumnMapping("EmpHireDate", "EmpHireDate"),
                        new System.Data.Common.DataColumnMapping("EmpCode", "EmpCode")})});
            // 
            // oleDbSelectCommand5
            // 
            this.oleDbSelectCommand5.CommandText = resources.GetString("oleDbSelectCommand5.CommandText");
            this.oleDbSelectCommand5.Connection = this.con1;
            this.oleDbSelectCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("projectID", System.Data.OleDb.OleDbType.Integer, 4, "projectID")});
            // 
            // dsEmployeeOrginal1
            // 
            this.dsEmployeeOrginal1.DataSetName = "dsEmployeeOrginal";
            this.dsEmployeeOrginal1.EnforceConstraints = false;
            this.dsEmployeeOrginal1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsEmployeeOrginal1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oleDbDataAdapterTaskEmployees
            // 
            this.oleDbDataAdapterTaskEmployees.SelectCommand = this.oleDbSelectCommand2;
            this.oleDbDataAdapterTaskEmployees.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GEN_Employees", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
                        new System.Data.Common.DataColumnMapping("JobTitleID", "JobTitleID"),
                        new System.Data.Common.DataColumnMapping("FileID", "FileID"),
                        new System.Data.Common.DataColumnMapping("CompElmentID", "CompElmentID"),
                        new System.Data.Common.DataColumnMapping("EmployeeStatus", "EmployeeStatus"),
                        new System.Data.Common.DataColumnMapping("EmpHireDate", "EmpHireDate"),
                        new System.Data.Common.DataColumnMapping("EmpCode", "EmpCode")})});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = resources.GetString("oleDbSelectCommand2.CommandText");
            this.oleDbSelectCommand2.Connection = this.con1;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("TaskID", System.Data.OleDb.OleDbType.Integer, 4, "TaskID")});
            // 
            // oleDbDataAdapterEmpSummData
            // 
            this.oleDbDataAdapterEmpSummData.SelectCommand = this.oleDbSelectCommand6;
            this.oleDbDataAdapterEmpSummData.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GEN_Contacts", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
                        new System.Data.Common.DataColumnMapping("UserID", "UserID"),
                        new System.Data.Common.DataColumnMapping("Fullname", "Fullname"),
                        new System.Data.Common.DataColumnMapping("JobTitleID", "JobTitleID"),
                        new System.Data.Common.DataColumnMapping("CompElmentID", "CompElmentID"),
                        new System.Data.Common.DataColumnMapping("EmployeeStatus", "EmployeeStatus"),
                        new System.Data.Common.DataColumnMapping("JobName", "JobName"),
                        new System.Data.Common.DataColumnMapping("CEName", "CEName")})});
            // 
            // oleDbSelectCommand6
            // 
            this.oleDbSelectCommand6.CommandText = resources.GetString("oleDbSelectCommand6.CommandText");
            this.oleDbSelectCommand6.Connection = this.con1;
            this.oleDbSelectCommand6.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID")});
            // 
            // oleDbDataAdapterDsEmployee
            // 
            this.oleDbDataAdapterDsEmployee.SelectCommand = this.oleDbCommand1;
            this.oleDbDataAdapterDsEmployee.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GEN_Employees", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
                        new System.Data.Common.DataColumnMapping("JobTitleID", "JobTitleID"),
                        new System.Data.Common.DataColumnMapping("FileID", "FileID"),
                        new System.Data.Common.DataColumnMapping("CompElmentID", "CompElmentID"),
                        new System.Data.Common.DataColumnMapping("EmployeeStatus", "EmployeeStatus"),
                        new System.Data.Common.DataColumnMapping("EmpHireDate", "EmpHireDate"),
                        new System.Data.Common.DataColumnMapping("EmpCode", "EmpCode")})});
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = resources.GetString("oleDbCommand1.CommandText");
            this.oleDbCommand1.Connection = this.con1;
            // 
            // EmployeeData
            // 
            this.ComponentDataAdabter = this.odaEmployee;
            this.ComponentDataSet = this.dsEmployeeOrginal1;
            this.Connection = this.con1;
            ((System.ComponentModel.ISupportInitialize)(this.dsEmployeeOrginal1)).EndInit();

		}
		#endregion

		#region EmployeeDetailedData

		public DataSet EmployeeDetailedData(int ContID)
		{
			return List(ContID);
		}


		#endregion 

		#region GetProjectEmplyees
		public DataSet GetProjectEmplyees(int projID)
		{
			dsEmployeeOrginal1.Clear();
			oleDbDataAdapterProjectEmployees.SelectCommand.Parameters[0].Value = projID;
			oleDbDataAdapterProjectEmployees.Fill(dsEmployeeOrginal1);
			return List(dsEmployeeOrginal1); 
		}

		#endregion 

		#region ListTeamEmployees
		public DataSet ListTeamEmployees(int TeamID)
		{
			dsEmployeeOrginal1.Clear();
			odaEmployeesByTeam.SelectCommand.Parameters[0].Value = TeamID;
			odaEmployeesByTeam.Fill(dsEmployeeOrginal1);
			return List(dsEmployeeOrginal1);;
		}


		#endregion 

		#region  ListActiveEmployees
		public DataSet ListActiveEmployees( )
		{
			return List("EmployeeStatus = 1");
		}
		#endregion 

		#region ListTerminatedEmployees
		public DataSet ListTerminatedEmployees( )
		{
			return List("EmployeeStatus = 0");
		}
		#endregion 
		
		#region ListCoElmEmployees
		public DataSet ListCoElmEmployees( int comElmID )
		{
			return List("CompElmentID = "+comElmID.ToString());
		}

		#endregion 

		#region ListTaskEmployees
		public DataSet ListTaskEmployees( int taskID )
		{
			dsEmployeeOrginal1.Clear();
			oleDbDataAdapterTaskEmployees.SelectCommand.Parameters[0].Value = taskID;
			oleDbDataAdapterTaskEmployees.Fill(dsEmployeeOrginal1);
			return dsEmployeeOrginal1;
		}

		#endregion 

		#region List Employee Summarized Data
		public DataSet ListEmpSummData( int ContactID )
		{
			DataSet dsEmpSummData = new DataSet();
			oleDbDataAdapterEmpSummData.SelectCommand.Parameters[0].Value = ContactID;//Contact ID
			oleDbDataAdapterEmpSummData.Fill(dsEmpSummData);
			return dsEmpSummData;
		}

		#endregion 

		

	}
}
