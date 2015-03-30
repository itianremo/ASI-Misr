using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for EmployeeJobTitles.
	/// </summary>
	public class EmployeeJobTitles : TSN.ERP.Engine.BussinesComponent 
	{
		private System.Data.OleDb.OleDbDataAdapter oleEmpJobTitles;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private TSN.ERP.SharedComponents.Data.dsEmployeesJobTitles dsEmployeesJobTitles1;
		private System.Data.OleDb.OleDbDataAdapter oleJobsByEmployee;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EmployeeJobTitles(System.ComponentModel.IContainer container)
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

		public EmployeeJobTitles()
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
			this.oleEmpJobTitles = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dsEmployeesJobTitles1 = new TSN.ERP.SharedComponents.Data.dsEmployeesJobTitles();
			this.oleJobsByEmployee = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsEmployeesJobTitles1)).BeginInit();
			// 
			// oleEmpJobTitles
			// 
			this.oleEmpJobTitles.DeleteCommand = this.oleDbDeleteCommand1;
			this.oleEmpJobTitles.InsertCommand = this.oleDbInsertCommand1;
			this.oleEmpJobTitles.SelectCommand = this.oleDbSelectCommand1;
			this.oleEmpJobTitles.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "GEN_EmployeesJobTitles", new System.Data.Common.DataColumnMapping[] {
																																																								new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																								new System.Data.Common.DataColumnMapping("JobTitleID", "JobTitleID"),
																																																								new System.Data.Common.DataColumnMapping("JobDate", "JobDate")})});
			this.oleEmpJobTitles.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Provider=SQLOLEDB.1;Persist Security Info=False;User ID=sa;Initial Catalog=InitialAccountability;Data Source=ERP;Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=HAMDYAHMED;Use Encryption for Data=False;Tag with column collation when possible=False";
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT ContactID, JobTitleID, JobDate FROM GEN_EmployeesJobTitles";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO GEN_EmployeesJobTitles(ContactID, JobTitleID, JobDate) VALUES (?, ?, " +
				"?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "JobDate"));
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE GEN_EmployeesJobTitles SET ContactID = ?, JobTitleID = ?, JobDate = ? WHER" +
				"E (ContactID = ?) AND (JobDate = ?) AND (JobTitleID = ?)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "JobDate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_JobDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "JobDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "JobTitleID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM GEN_EmployeesJobTitles WHERE (ContactID = ?) AND (JobDate = ?) AND (J" +
				"obTitleID = ?)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_JobDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "JobDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "JobTitleID", System.Data.DataRowVersion.Original, null));
			// 
			// dsEmployeesJobTitles1
			// 
			this.dsEmployeesJobTitles1.DataSetName = "dsEmployeesJobTitles";
			this.dsEmployeesJobTitles1.EnforceConstraints = false;
			this.dsEmployeesJobTitles1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleJobsByEmployee
			// 
			this.oleJobsByEmployee.DeleteCommand = this.oleDbDeleteCommand2;
			this.oleJobsByEmployee.InsertCommand = this.oleDbInsertCommand2;
			this.oleJobsByEmployee.SelectCommand = this.oleDbSelectCommand2;
			this.oleJobsByEmployee.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "GEN_EmployeesJobTitles", new System.Data.Common.DataColumnMapping[] {
																																																								  new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																								  new System.Data.Common.DataColumnMapping("JobTitleID", "JobTitleID"),
																																																								  new System.Data.Common.DataColumnMapping("JobDate", "JobDate")})});
			this.oleJobsByEmployee.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT ContactID, JobTitleID, JobDate FROM GEN_EmployeesJobTitles WHERE (ContactI" +
				"D = ?)";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO GEN_EmployeesJobTitles(ContactID, JobTitleID, JobDate) VALUES (?, ?, " +
				"?); SELECT ContactID, JobTitleID, JobDate FROM GEN_EmployeesJobTitles WHERE (Con" +
				"tactID = ?) AND (JobDate = ?) AND (JobTitleID = ?)";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "JobDate"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_JobDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "JobDate"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleID"));
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = @"UPDATE GEN_EmployeesJobTitles SET ContactID = ?, JobTitleID = ?, JobDate = ? WHERE (ContactID = ?) AND (JobDate = ?) AND (JobTitleID = ?); SELECT ContactID, JobTitleID, JobDate FROM GEN_EmployeesJobTitles WHERE (ContactID = ?) AND (JobDate = ?) AND (JobTitleID = ?)";
			this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "JobDate"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_JobDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "JobDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "JobTitleID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_JobDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "JobDate"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleID"));
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = "DELETE FROM GEN_EmployeesJobTitles WHERE (ContactID = ?) AND (JobDate = ?) AND (J" +
				"obTitleID = ?)";
			this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_JobDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "JobDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "JobTitleID", System.Data.DataRowVersion.Original, null));
			// 
			// EmployeeJobTitles
			// 
			this.ComponentDataAdabter = this.oleEmpJobTitles;
			this.ComponentDataSet = this.dsEmployeesJobTitles1;
			this.Connection = this.oleDbConnection1;
			((System.ComponentModel.ISupportInitialize)(this.dsEmployeesJobTitles1)).EndInit();

		}
		#endregion


		public int AddEmployeeJobTitle(int EmployeeID, int JobTitleID , DateTime JobDate )
		{
			oleEmpJobTitles.InsertCommand.Parameters["ContactID"].Value   = EmployeeID;
			oleEmpJobTitles.InsertCommand.Parameters["JobTitleID"].Value  = JobTitleID;
			oleEmpJobTitles.InsertCommand.Parameters["JobDate"].Value	  = JobDate;
			return oleEmpJobTitles.InsertCommand.ExecuteNonQuery();

		}
	}
}
