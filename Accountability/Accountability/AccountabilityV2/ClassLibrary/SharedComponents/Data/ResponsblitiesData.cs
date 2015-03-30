using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using TSN.ERP.Engine;
namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for ResponsblitiesData.
	/// </summary>
	public class ResponsblitiesData:BussinesComponent 
	{
		/// <summary>
		/// Old Delete Command:::::
		/// </summary>
		//			this.oleDbDeleteCommand1.CommandText = "DELETE FROM GEN_Responsibilities WHERE (ResponsID = ?) AND (JobTitleID = ? OR ? I" +
		//				"S NULL AND JobTitleID IS NULL) AND (ResponsName = ?) AND (ResponsOrder = ? OR ? " +
		//				"IS NULL AND ResponsOrder IS NULL)";
		//			this.oleDbDeleteCommand1.Connection = this.con1;
		//			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ResponsID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResponsID", System.Data.DataRowVersion.Original, null));
		//			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "JobTitleID", System.Data.DataRowVersion.Original, null));
		//			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_JobTitleID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "JobTitleID", System.Data.DataRowVersion.Original, null));
		//			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ResponsName", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResponsName", System.Data.DataRowVersion.Original, null));
		//			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ResponsOrder", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResponsOrder", System.Data.DataRowVersion.Original, null));
		//			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ResponsOrder1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResponsOrder", System.Data.DataRowVersion.Original, null));

		/// <summary>
		/// Old Update Command:::::
		/// </summary>
		//			this.oleDbUpdateCommand1.CommandText = @"UPDATE GEN_Responsibilities SET ResponsID = ?, JobTitleID = ?, ResponsName = ?, ResponsDesc = ?, ResponsOrder = ?, IsActive = ? WHERE (ResponsID = ?) AND (JobTitleID = ? OR ? IS NULL AND JobTitleID IS NULL) AND (ResponsName = ?) AND (ResponsOrder = ? OR ? IS NULL AND ResponsOrder IS NULL); SELECT ResponsID, JobTitleID, ResponsName, ResponsDesc, ResponsOrder, IsActive FROM GEN_Responsibilities WHERE (ResponsID = ?)";			
		//			this.oleDbUpdateCommand1.Connection = this.con1;
		//			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsID", System.Data.OleDb.OleDbType.Integer, 4, "ResponsID"));
		//			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleID"));
		//			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsName", System.Data.OleDb.OleDbType.VarChar, 180, "ResponsName"));
		//			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsDesc", System.Data.OleDb.OleDbType.VarChar, 2147483647, "ResponsDesc"));
		//			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsOrder", System.Data.OleDb.OleDbType.Integer, 4, "ResponsOrder"));
		//			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IsActive", System.Data.OleDb.OleDbType.Boolean, 1, "IsActive"));
		//			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ResponsID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResponsID", System.Data.DataRowVersion.Original, null));
		//			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "JobTitleID", System.Data.DataRowVersion.Original, null));
		//			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PARAM57", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Original, null));
		//			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ResponsName", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResponsName", System.Data.DataRowVersion.Original, null));
		//			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ResponsOrder", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResponsOrder", System.Data.DataRowVersion.Original, null));
		//			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PARAM60", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Original, null));
		//			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select1_ResponsID", System.Data.OleDb.OleDbType.Integer, 4, "ResponsID"));


		private System.Data.OleDb.OleDbDataAdapter odaResponsbilities;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbConnection con1;
		private TSN.ERP.SharedComponents.Data.dsResponsblities dsResponsblities1;
		private System.Data.OleDb.OleDbDataAdapter odaResponsByJob;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterEmpResponsibilities;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		private System.Data.OleDb.OleDbDataAdapter odaActiveResponsByJob;
		private System.Data.OleDb.OleDbCommand oleDbCommand1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterSingleResp;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand5;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterIsResponseActive;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand6;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ResponsblitiesData(System.ComponentModel.IContainer container)
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

		public ResponsblitiesData()
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
			this.odaResponsbilities = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.con1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dsResponsblities1 = new TSN.ERP.SharedComponents.Data.dsResponsblities();
			this.odaResponsByJob = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterEmpResponsibilities = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.odaActiveResponsByJob = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterSingleResp = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterIsResponseActive = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand6 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsResponsblities1)).BeginInit();
			// 
			// odaResponsbilities
			// 
			this.odaResponsbilities.DeleteCommand = this.oleDbDeleteCommand1;
			this.odaResponsbilities.InsertCommand = this.oleDbInsertCommand1;
			this.odaResponsbilities.SelectCommand = this.oleDbSelectCommand1;
			this.odaResponsbilities.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										 new System.Data.Common.DataTableMapping("Table", "GEN_Responsibilities", new System.Data.Common.DataColumnMapping[] {
																																																								 new System.Data.Common.DataColumnMapping("ResponsID", "ResponsID"),
																																																								 new System.Data.Common.DataColumnMapping("JobTitleID", "JobTitleID"),
																																																								 new System.Data.Common.DataColumnMapping("ResponsName", "ResponsName"),
																																																								 new System.Data.Common.DataColumnMapping("ResponsDesc", "ResponsDesc"),
																																																								 new System.Data.Common.DataColumnMapping("ResponsOrder", "ResponsOrder"),
																																																								 new System.Data.Common.DataColumnMapping("IsActive", "IsActive")})});
			this.odaResponsbilities.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM GEN_Responsibilities WHERE (ResponsID = ?)";
			this.oleDbDeleteCommand1.Connection = this.con1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ResponsID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResponsID", System.Data.DataRowVersion.Original, null));
			// 
			// con1
			// 
			this.con1.ConnectionString = @"Auto Translate=True;Integrated Security=SSPI;User ID=RW;Data Source=""ERP\ERPSQL2005"";Tag with column collation when possible=False;Initial Catalog=TestAccountability_Data;Use Procedure for Prepare=1;Provider=""SQLOLEDB.1"";Persist Security Info=False;Workstation ID=HAMDYAHMED;Use Encryption for Data=False;Packet Size=4096";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = @"INSERT INTO GEN_Responsibilities (ResponsID, JobTitleID, ResponsName, ResponsDesc, ResponsOrder, IsActive) VALUES (?, ?, ?, ?, ?, ?); SELECT ResponsID, JobTitleID, ResponsName, ResponsDesc, ResponsOrder, IsActive FROM GEN_Responsibilities WHERE (ResponsID = ?)";
			this.oleDbInsertCommand1.Connection = this.con1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsID", System.Data.OleDb.OleDbType.Integer, 4, "ResponsID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsName", System.Data.OleDb.OleDbType.VarChar, 180, "ResponsName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsDesc", System.Data.OleDb.OleDbType.VarChar, 2147483647, "ResponsDesc"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsOrder", System.Data.OleDb.OleDbType.Integer, 4, "ResponsOrder"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IsActive", System.Data.OleDb.OleDbType.Boolean, 1, "IsActive"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select1_ResponsID", System.Data.OleDb.OleDbType.Integer, 4, "ResponsID"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT ResponsID, JobTitleID, ResponsName, ResponsDesc, ResponsOrder, IsActive FR" +
				"OM GEN_Responsibilities";
			this.oleDbSelectCommand1.Connection = this.con1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE GEN_Responsibilities SET ResponsID = ?, JobTitleID = ?, ResponsName = ?, ResponsDesc = ?, ResponsOrder = ?, IsActive = ? WHERE (ResponsID = ?); SELECT ResponsID, JobTitleID, ResponsName, ResponsDesc, ResponsOrder, IsActive FROM GEN_Responsibilities WHERE (ResponsID = ?)";
			this.oleDbUpdateCommand1.Connection = this.con1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsID", System.Data.OleDb.OleDbType.Integer, 4, "ResponsID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsName", System.Data.OleDb.OleDbType.VarChar, 180, "ResponsName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsDesc", System.Data.OleDb.OleDbType.VarChar, 2147483647, "ResponsDesc"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsOrder", System.Data.OleDb.OleDbType.Integer, 4, "ResponsOrder"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IsActive", System.Data.OleDb.OleDbType.Boolean, 1, "IsActive"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ResponsID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ResponsID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select1_ResponsID", System.Data.OleDb.OleDbType.Integer, 4, "ResponsID"));
			// 
			// dsResponsblities1
			// 
			this.dsResponsblities1.DataSetName = "dsResponsblities";
			this.dsResponsblities1.EnforceConstraints = false;
			this.dsResponsblities1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// odaResponsByJob
			// 
			this.odaResponsByJob.SelectCommand = this.oleDbSelectCommand2;
			this.odaResponsByJob.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "GEN_Responsibilities", new System.Data.Common.DataColumnMapping[] {
																																																							  new System.Data.Common.DataColumnMapping("ResponsID", "ResponsID"),
																																																							  new System.Data.Common.DataColumnMapping("JobTitleID", "JobTitleID"),
																																																							  new System.Data.Common.DataColumnMapping("ResponsName", "ResponsName"),
																																																							  new System.Data.Common.DataColumnMapping("ResponsDesc", "ResponsDesc"),
																																																							  new System.Data.Common.DataColumnMapping("ResponsOrder", "ResponsOrder")})});
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT ResponsID, JobTitleID, ResponsName, ResponsDesc, ResponsOrder, IsActive FR" +
				"OM GEN_Responsibilities WHERE (JobTitleID = ?) ORDER BY ResponsOrder, ResponsNam" +
				"e";
			this.oleDbSelectCommand2.Connection = this.con1;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleID"));
			// 
			// oleDbDataAdapterEmpResponsibilities
			// 
			this.oleDbDataAdapterEmpResponsibilities.SelectCommand = this.oleDbSelectCommand3;
			this.oleDbDataAdapterEmpResponsibilities.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																														  new System.Data.Common.DataTableMapping("Table", "GEN_Responsibilities", new System.Data.Common.DataColumnMapping[] {
																																																												  new System.Data.Common.DataColumnMapping("ResponsID", "ResponsID"),
																																																												  new System.Data.Common.DataColumnMapping("JobTitleID", "JobTitleID"),
																																																												  new System.Data.Common.DataColumnMapping("ResponsName", "ResponsName"),
																																																												  new System.Data.Common.DataColumnMapping("ResponsDesc", "ResponsDesc"),
																																																												  new System.Data.Common.DataColumnMapping("ResponsOrder", "ResponsOrder"),
																																																												  new System.Data.Common.DataColumnMapping("Expr1", "Expr1"),
																																																												  new System.Data.Common.DataColumnMapping("JobName", "JobName"),
																																																												  new System.Data.Common.DataColumnMapping("JobTitleOrder", "JobTitleOrder"),
																																																												  new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																												  new System.Data.Common.DataColumnMapping("Expr2", "Expr2"),
																																																												  new System.Data.Common.DataColumnMapping("FileID", "FileID"),
																																																												  new System.Data.Common.DataColumnMapping("CompElmentID", "CompElmentID"),
																																																												  new System.Data.Common.DataColumnMapping("EmployeeStatus", "EmployeeStatus"),
																																																												  new System.Data.Common.DataColumnMapping("EmpHireDate", "EmpHireDate")})});
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = @"SELECT GEN_Responsibilities.ResponsID, GEN_Responsibilities.JobTitleID, GEN_Responsibilities.ResponsName, GEN_Responsibilities.ResponsDesc, GEN_Responsibilities.ResponsOrder, GEN_JobTitles.JobTitleID AS Expr1, GEN_JobTitles.JobName, GEN_JobTitles.JobTitleOrder, GEN_Employees.ContactID, GEN_Employees.JobTitleID AS Expr2, GEN_Employees.FileID, GEN_Employees.CompElmentID, GEN_Employees.EmployeeStatus, GEN_Employees.EmpHireDate, GEN_JobTitles.IsActive AS JobTitleIsActive, GEN_Responsibilities.IsActive AS RespIsActive FROM GEN_Responsibilities INNER JOIN GEN_JobTitles ON GEN_Responsibilities.JobTitleID = GEN_JobTitles.JobTitleID INNER JOIN GEN_Employees ON GEN_JobTitles.JobTitleID = GEN_Employees.JobTitleID WHERE (GEN_Employees.ContactID = ?)";
			this.oleDbSelectCommand3.Connection = this.con1;
			this.oleDbSelectCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			// 
			// oleDbDataAdapter1
			// 
			this.oleDbDataAdapter1.SelectCommand = this.oleDbSelectCommand4;
			this.oleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "GEN_Responsibilities", new System.Data.Common.DataColumnMapping[] {
																																																								new System.Data.Common.DataColumnMapping("ResponsID", "ResponsID"),
																																																								new System.Data.Common.DataColumnMapping("JobTitleID", "JobTitleID"),
																																																								new System.Data.Common.DataColumnMapping("ResponsName", "ResponsName"),
																																																								new System.Data.Common.DataColumnMapping("ResponsDesc", "ResponsDesc"),
																																																								new System.Data.Common.DataColumnMapping("ResponsOrder", "ResponsOrder"),
																																																								new System.Data.Common.DataColumnMapping("IsActive", "IsActive")})});
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = "SELECT ResponsID, JobTitleID, ResponsName, ResponsDesc, ResponsOrder, IsActive FR" +
				"OM GEN_Responsibilities WHERE (IsActive = ?) AND (JobTitleID = ?)";
			this.oleDbSelectCommand4.Connection = this.con1;
			this.oleDbSelectCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("IsActive", System.Data.OleDb.OleDbType.Boolean, 1, "IsActive"));
			this.oleDbSelectCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleID"));
			// 
			// odaActiveResponsByJob
			// 
			this.odaActiveResponsByJob.SelectCommand = this.oleDbCommand1;
			this.odaActiveResponsByJob.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											new System.Data.Common.DataTableMapping("Table", "GEN_Responsibilities", new System.Data.Common.DataColumnMapping[] {
																																																									new System.Data.Common.DataColumnMapping("ResponsID", "ResponsID"),
																																																									new System.Data.Common.DataColumnMapping("JobTitleID", "JobTitleID"),
																																																									new System.Data.Common.DataColumnMapping("ResponsName", "ResponsName"),
																																																									new System.Data.Common.DataColumnMapping("ResponsDesc", "ResponsDesc"),
																																																									new System.Data.Common.DataColumnMapping("ResponsOrder", "ResponsOrder")})});
			// 
			// oleDbCommand1
			// 
			this.oleDbCommand1.CommandText = "SELECT ResponsID, JobTitleID, ResponsName, ResponsDesc, ResponsOrder, IsActive FR" +
				"OM GEN_Responsibilities WHERE (JobTitleID = ?) ORDER BY ResponsOrder, ResponsNam" +
				"e";
			this.oleDbCommand1.Connection = this.con1;
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleID"));
			// 
			// oleDbDataAdapterSingleResp
			// 
			this.oleDbDataAdapterSingleResp.SelectCommand = this.oleDbSelectCommand5;
			this.oleDbDataAdapterSingleResp.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												 new System.Data.Common.DataTableMapping("Table", "GEN_Responsibilities", new System.Data.Common.DataColumnMapping[] {
																																																										 new System.Data.Common.DataColumnMapping("ResponsID", "ResponsID"),
																																																										 new System.Data.Common.DataColumnMapping("JobTitleID", "JobTitleID"),
																																																										 new System.Data.Common.DataColumnMapping("ResponsName", "ResponsName"),
																																																										 new System.Data.Common.DataColumnMapping("ResponsDesc", "ResponsDesc"),
																																																										 new System.Data.Common.DataColumnMapping("ResponsOrder", "ResponsOrder"),
																																																										 new System.Data.Common.DataColumnMapping("IsActive", "IsActive")})});
			// 
			// oleDbSelectCommand5
			// 
			this.oleDbSelectCommand5.CommandText = "SELECT ResponsID, JobTitleID, ResponsName, ResponsDesc, ResponsOrder, IsActive FR" +
				"OM GEN_Responsibilities WHERE (ResponsID = ?)";
			this.oleDbSelectCommand5.Connection = this.con1;
			this.oleDbSelectCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsID", System.Data.OleDb.OleDbType.Integer, 4, "ResponsID"));
			// 
			// oleDbDataAdapterIsResponseActive
			// 
			this.oleDbDataAdapterIsResponseActive.SelectCommand = this.oleDbSelectCommand6;
			this.oleDbDataAdapterIsResponseActive.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													   new System.Data.Common.DataTableMapping("Table", "GEN_Responsibilities", new System.Data.Common.DataColumnMapping[] {
																																																											   new System.Data.Common.DataColumnMapping("IsActive", "IsActive")})});
			// 
			// oleDbSelectCommand6
			// 
			this.oleDbSelectCommand6.CommandText = "SELECT IsActive FROM GEN_Responsibilities WHERE (ResponsID = ?)";
			this.oleDbSelectCommand6.Connection = this.con1;
			this.oleDbSelectCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("ResponsID", System.Data.OleDb.OleDbType.Integer, 4, "ResponsID"));
			// 
			// ResponsblitiesData
			// 
			this.ComponentDataAdabter = this.odaResponsbilities;
			this.ComponentDataSet = this.dsResponsblities1;
			this.Connection = this.con1;
			((System.ComponentModel.ISupportInitialize)(this.dsResponsblities1)).EndInit();

		}
		#endregion

		public DataSet ListResponsebyJob(int JobID)
		{
			this.dsResponsblities1.Clear();
			this.odaResponsByJob.SelectCommand.Parameters["JobTitleID"].Value = JobID;
			this.odaResponsByJob.Fill(this.dsResponsblities1);
			return this.dsResponsblities1;
		}

		

		public DataSet ListEmployeeResponsibilities( int empID )
		{
			dsResponsblities1.Clear();
			oleDbDataAdapterEmpResponsibilities.SelectCommand.Parameters[ "ContactID"  ].Value =  empID ;
			oleDbDataAdapterEmpResponsibilities.Fill( dsResponsblities1 );
			return dsResponsblities1;
		}


		public DataSet ListActiveResponsibilities(int JobTitleID)
		{
			DataSet dsActiveResponsibilities = new DataSet();
			this.oleDbDataAdapter1.SelectCommand.Parameters[0].Value = true;
			this.oleDbDataAdapter1.SelectCommand.Parameters[1].Value = JobTitleID;
			this.oleDbDataAdapter1.Fill(dsActiveResponsibilities);
			return dsActiveResponsibilities;
		}

		public DataSet ListClosedResponsibilities(int JobTitleID)
		{
			DataSet dsClosedResponsibilities = new DataSet();
			this.oleDbDataAdapter1.SelectCommand.Parameters[0].Value = false;
			this.oleDbDataAdapter1.SelectCommand.Parameters[1].Value = JobTitleID;
			this.oleDbDataAdapter1.Fill(dsClosedResponsibilities);
			return dsClosedResponsibilities;
		}

		public DataSet ListSingleResponsibility(int RespID)
		{
			DataSet dsSingleResponsibility = new DataSet();
			this.oleDbDataAdapter1.SelectCommand.Parameters[0].Value = RespID;
			this.oleDbDataAdapter1.Fill(dsSingleResponsibility);
			return dsSingleResponsibility;
		}

		public DataSet ListResponsibility(int RespID)
		{
			DataSet dsSingleResponsibility = new DataSet();
			this.oleDbDataAdapterSingleResp.SelectCommand.Parameters[0].Value = RespID;
			this.oleDbDataAdapterSingleResp.Fill(dsSingleResponsibility);
			return dsSingleResponsibility;
		}

		public bool IsResponsibilityActive( int ResponsibilityID)
		{
			this.oleDbDataAdapterIsResponseActive.SelectCommand.Parameters[0].Value = ResponsibilityID;
			bool VBIsResponsibilityActive = Convert.ToBoolean(this.oleDbDataAdapterIsResponseActive.SelectCommand.ExecuteScalar());
			return VBIsResponsibilityActive;
		}
		
	

	}
}
