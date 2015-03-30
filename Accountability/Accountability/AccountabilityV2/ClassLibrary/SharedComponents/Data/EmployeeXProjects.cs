using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using TSN.ERP.Engine;

namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for EmployeeXProjects.
	/// </summary>
	public class EmployeeXProjects : BussinesComponent
	{
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbCommand odcDelete;
		private TSN.ERP.SharedComponents.Data.dsEmployeesXProjects dsEmployeesXProjects1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EmployeeXProjects(System.ComponentModel.IContainer container)
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

		public EmployeeXProjects()
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
			this.oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.odcDelete = new System.Data.OleDb.OleDbCommand();
			this.dsEmployeesXProjects1 = new TSN.ERP.SharedComponents.Data.dsEmployeesXProjects();
			((System.ComponentModel.ISupportInitialize)(this.dsEmployeesXProjects1)).BeginInit();
			// 
			// oleDbDataAdapter1
			// 
			this.oleDbDataAdapter1.DeleteCommand = this.oleDbDeleteCommand1;
			this.oleDbDataAdapter1.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbDataAdapter1.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "GEN_EmployeesXProjects", new System.Data.Common.DataColumnMapping[] {
																																																								  new System.Data.Common.DataColumnMapping("projectID", "projectID"),
																																																								  new System.Data.Common.DataColumnMapping("ContactID", "ContactID")})});
			this.oleDbDataAdapter1.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM GEN_EmployeesXProjects WHERE (ContactID = ?) AND (projectID = ?)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_projectID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "projectID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=BASSAM;Tag with column collation when possible=False;Initial Catalog=ERPdb;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASSAM;Use Encryption for Data=False";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO GEN_EmployeesXProjects(projectID, ContactID) VALUES (?, ?); SELECT pr" +
				"ojectID, ContactID FROM GEN_EmployeesXProjects WHERE (ContactID = ?) AND (projec" +
				"tID = ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("projectID", System.Data.OleDb.OleDbType.Integer, 4, "projectID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_projectID", System.Data.OleDb.OleDbType.Integer, 4, "projectID"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT projectID, ContactID FROM GEN_EmployeesXProjects";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE GEN_EmployeesXProjects SET projectID = ?, ContactID = ? WHERE (ContactID =" +
				" ?) AND (projectID = ?); SELECT projectID, ContactID FROM GEN_EmployeesXProjects" +
				" WHERE (ContactID = ?) AND (projectID = ?)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("projectID", System.Data.OleDb.OleDbType.Integer, 4, "projectID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_projectID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "projectID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_projectID", System.Data.OleDb.OleDbType.Integer, 4, "projectID"));
			// 
			// odcDelete
			// 
			this.odcDelete.CommandText = "DELETE FROM GEN_EmployeesXProjects WHERE (projectID = ?) AND (ContactID = ?)";
			this.odcDelete.Connection = this.oleDbConnection1;
			this.odcDelete.Parameters.Add(new System.Data.OleDb.OleDbParameter("projectID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "projectID", System.Data.DataRowVersion.Original, null));
			this.odcDelete.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			// 
			// dsEmployeesXProjects1
			// 
			this.dsEmployeesXProjects1.DataSetName = "dsEmployeesXProjects";
			this.dsEmployeesXProjects1.EnforceConstraints = false;
			this.dsEmployeesXProjects1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// EmployeeXProjects
			// 
			this.ComponentDataAdabter = this.oleDbDataAdapter1;
			this.ComponentDataSet = this.dsEmployeesXProjects1;
			this.Connection = this.oleDbConnection1;
			((System.ComponentModel.ISupportInitialize)(this.dsEmployeesXProjects1)).EndInit();

		}
		#endregion

		public override System.Data.DataSet List(int ID)
		{
			return null;
		}
		public int Remove(int EmployeeID, int ProjectID)
		{
			odcDelete.Parameters["ContactID"].Value  = EmployeeID;
			odcDelete.Parameters["projectID"].Value  = ProjectID;
			return odcDelete.ExecuteNonQuery();
		}
	}
}
