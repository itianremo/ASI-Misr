using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using TSN.ERP.Engine;
namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for EmployeeXTeamDataClass.
	/// </summary>
	public class EmployeeXTeamDataClass : BussinesComponent 
	{
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private TSN.ERP.SharedComponents.Data.dsEmployeeXTeams dsEmployeeXTeams1;
		private System.Data.OleDb.OleDbDataAdapter odaTeaEmployees;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand odcRemove;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterEmpTeams;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EmployeeXTeamDataClass(System.ComponentModel.IContainer container)
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

		public EmployeeXTeamDataClass()
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
			this.oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dsEmployeeXTeams1 = new TSN.ERP.SharedComponents.Data.dsEmployeeXTeams();
			this.odaTeaEmployees = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.odcRemove = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterEmpTeams = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsEmployeeXTeams1)).BeginInit();
			// 
			// oleDbDataAdapter1
			// 
			this.oleDbDataAdapter1.DeleteCommand = this.oleDbDeleteCommand1;
			this.oleDbDataAdapter1.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbDataAdapter1.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "GEN_EmploeesXTeams", new System.Data.Common.DataColumnMapping[] {
																																																							  new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																							  new System.Data.Common.DataColumnMapping("TeamID", "TeamID")})});
			this.oleDbDataAdapter1.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM GEN_EmploeesXTeams WHERE (ContactID = ?) AND (TeamID = ?)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TeamID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TeamID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=BASSAM;Tag with column collation when possible=False;Initial Catalog=ERPdb;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASSAM;Use Encryption for Data=False";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO GEN_EmploeesXTeams(ContactID, TeamID) VALUES (?, ?); SELECT ContactID" +
				", TeamID FROM GEN_EmploeesXTeams WHERE (ContactID = ?) AND (TeamID = ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TeamID", System.Data.OleDb.OleDbType.Integer, 4, "TeamID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_TeamID", System.Data.OleDb.OleDbType.Integer, 4, "TeamID"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT ContactID, TeamID FROM GEN_EmploeesXTeams";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE GEN_EmploeesXTeams SET ContactID = ?, TeamID = ? WHERE (ContactID = ?) AND" +
				" (TeamID = ?); SELECT ContactID, TeamID FROM GEN_EmploeesXTeams WHERE (ContactID" +
				" = ?) AND (TeamID = ?)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TeamID", System.Data.OleDb.OleDbType.Integer, 4, "TeamID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TeamID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TeamID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_TeamID", System.Data.OleDb.OleDbType.Integer, 4, "TeamID"));
			// 
			// dsEmployeeXTeams1
			// 
			this.dsEmployeeXTeams1.DataSetName = "dsEmployeeXTeams";
			this.dsEmployeeXTeams1.EnforceConstraints = false;
			this.dsEmployeeXTeams1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// odaTeaEmployees
			// 
			this.odaTeaEmployees.SelectCommand = this.oleDbSelectCommand2;
			this.odaTeaEmployees.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "GEN_EmploeesXTeams", new System.Data.Common.DataColumnMapping[] {
																																																							new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																							new System.Data.Common.DataColumnMapping("TeamID", "TeamID")})});
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT ContactID, TeamID FROM GEN_EmploeesXTeams WHERE (TeamID = ?)";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("TeamID", System.Data.OleDb.OleDbType.Integer, 4, "TeamID"));
			// 
			// odcRemove
			// 
			this.odcRemove.CommandText = "DELETE FROM GEN_EmploeesXTeams WHERE (ContactID = ?) AND (TeamID = ?)";
			this.odcRemove.Connection = this.oleDbConnection1;
			this.odcRemove.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.odcRemove.Parameters.Add(new System.Data.OleDb.OleDbParameter("TeamID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TeamID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbDataAdapterEmpTeams
			// 
			this.oleDbDataAdapterEmpTeams.SelectCommand = this.oleDbSelectCommand3;
			this.oleDbDataAdapterEmpTeams.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											   new System.Data.Common.DataTableMapping("Table", "GEN_EmploeesXTeams", new System.Data.Common.DataColumnMapping[] {
																																																									 new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																									 new System.Data.Common.DataColumnMapping("TeamID", "TeamID")})});
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = "SELECT ContactID, TeamID FROM GEN_EmploeesXTeams WHERE (ContactID = ?)";
			this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			// 
			// EmployeeXTeamDataClass
			// 
			this.ComponentDataAdabter = this.oleDbDataAdapter1;
			this.ComponentDataSet = this.dsEmployeeXTeams1;
			this.Connection = this.oleDbConnection1;
			((System.ComponentModel.ISupportInitialize)(this.dsEmployeeXTeams1)).EndInit();

		}
		#endregion

		public override System.Data.DataSet List(int TeamID)
		{
			dsEmployeeXTeams1.Clear();
			odaTeaEmployees.SelectCommand.Parameters[0].Value = TeamID;
			odaTeaEmployees.Fill(dsEmployeeXTeams1);
			return dsEmployeeXTeams1;
		}
		public int Remove(int TeamID,int EmployeeID)
		{
			odcRemove.Parameters["TeamID"].Value = TeamID;
			odcRemove.Parameters["ContactID"].Value = EmployeeID;
			return odcRemove.ExecuteNonQuery();
		}

		public System.Data.DataSet ListEmployeeTeams( int empID )
		{
			dsEmployeeXTeams1.Clear();
			oleDbDataAdapterEmpTeams.SelectCommand.Parameters[0].Value = empID;
			oleDbDataAdapterEmpTeams.Fill(dsEmployeeXTeams1);
			return dsEmployeeXTeams1;
		}
	}
}
