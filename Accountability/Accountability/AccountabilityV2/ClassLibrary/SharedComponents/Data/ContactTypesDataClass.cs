using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for ContactTypesDataClass.
	/// </summary>
	public class ContactTypesDataClass : TSN.ERP.Engine.BussinesComponent 
	{
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private TSN.ERP.SharedComponents.Data.dsContactTypes dsContactTypes1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ContactTypesDataClass(System.ComponentModel.IContainer container)
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

		public ContactTypesDataClass()
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
			this.dsContactTypes1 = new TSN.ERP.SharedComponents.Data.dsContactTypes();
			((System.ComponentModel.ISupportInitialize)(this.dsContactTypes1)).BeginInit();
			// 
			// oleDbDataAdapter1
			// 
			this.oleDbDataAdapter1.DeleteCommand = this.oleDbDeleteCommand1;
			this.oleDbDataAdapter1.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbDataAdapter1.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "GEN_ContactTypes", new System.Data.Common.DataColumnMapping[] {
																																																							new System.Data.Common.DataColumnMapping("ContTypeID", "ContTypeID"),
																																																							new System.Data.Common.DataColumnMapping("ContTypeDesct", "ContTypeDesct")})});
			this.oleDbDataAdapter1.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM GEN_ContactTypes WHERE (ContTypeID = ?) AND (ContTypeDesct = ?)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContTypeID", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContTypeID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContTypeDesct", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContTypeDesct", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=ERP;Tag with column collation when possible=False;Initial Catalog=ERPdb;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=FAWZI;Use Encryption for Data=False";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO GEN_ContactTypes(ContTypeID, ContTypeDesct) VALUES (?, ?); SELECT Con" +
				"tTypeID, ContTypeDesct FROM GEN_ContactTypes WHERE (ContTypeID = ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContTypeID", System.Data.OleDb.OleDbType.SmallInt, 2, "ContTypeID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContTypeDesct", System.Data.OleDb.OleDbType.VarChar, 120, "ContTypeDesct"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_ContTypeID", System.Data.OleDb.OleDbType.SmallInt, 2, "ContTypeID"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT ContTypeID, ContTypeDesct FROM GEN_ContactTypes";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE GEN_ContactTypes SET ContTypeID = ?, ContTypeDesct = ? WHERE (ContTypeID =" +
				" ?) AND (ContTypeDesct = ?); SELECT ContTypeID, ContTypeDesct FROM GEN_ContactTy" +
				"pes WHERE (ContTypeID = ?)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContTypeID", System.Data.OleDb.OleDbType.SmallInt, 2, "ContTypeID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContTypeDesct", System.Data.OleDb.OleDbType.VarChar, 120, "ContTypeDesct"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContTypeID", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContTypeID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContTypeDesct", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContTypeDesct", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_ContTypeID", System.Data.OleDb.OleDbType.SmallInt, 2, "ContTypeID"));
			// 
			// dsContactTypes1
			// 
			this.dsContactTypes1.DataSetName = "dsContactTypes";
			this.dsContactTypes1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// ContactTypesDataClass
			// 
			this.ComponentDataAdabter = this.oleDbDataAdapter1;
			this.ComponentDataSet = this.dsContactTypes1;
			((System.ComponentModel.ISupportInitialize)(this.dsContactTypes1)).EndInit();

		}
		#endregion
	}
}
