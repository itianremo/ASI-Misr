using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using TSN.ERP.Engine;
namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for CompaniesProfilesData.
	/// </summary>
	public class CompaniesProfilesData :BussinesComponent 
	{
		private System.Data.OleDb.OleDbDataAdapter odaCompaniesProfiles;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbConnection con1;
		private TSN.ERP.SharedComponents.Data.dsCompaniesProfiles dsCompaniesProfiles1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CompaniesProfilesData(System.ComponentModel.IContainer container)
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

		public CompaniesProfilesData()
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
			this.odaCompaniesProfiles = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.con1 = new System.Data.OleDb.OleDbConnection();
			this.dsCompaniesProfiles1 = new TSN.ERP.SharedComponents.Data.dsCompaniesProfiles();
			((System.ComponentModel.ISupportInitialize)(this.dsCompaniesProfiles1)).BeginInit();
			// 
			// odaCompaniesProfiles
			// 
			this.odaCompaniesProfiles.DeleteCommand = this.oleDbDeleteCommand1;
			this.odaCompaniesProfiles.InsertCommand = this.oleDbInsertCommand1;
			this.odaCompaniesProfiles.SelectCommand = this.oleDbSelectCommand1;
			this.odaCompaniesProfiles.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										   new System.Data.Common.DataTableMapping("Table", "GEN_CompanyProfile", new System.Data.Common.DataColumnMapping[] {
																																																								 new System.Data.Common.DataColumnMapping("CompID", "CompID"),
																																																								 new System.Data.Common.DataColumnMapping("CompanyName", "CompanyName")})});
			this.odaCompaniesProfiles.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT CompID, CompanyName FROM GEN_CompanyProfile";
			this.oleDbSelectCommand1.Connection = this.con1;
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO GEN_CompanyProfile(CompID, CompanyName) VALUES (?, ?); SELECT CompID," +
				" CompanyName FROM GEN_CompanyProfile WHERE (CompID = ?)";
			this.oleDbInsertCommand1.Connection = this.con1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 4, "CompID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompanyName", System.Data.OleDb.OleDbType.VarChar, 250, "CompanyName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_CompID", System.Data.OleDb.OleDbType.Integer, 4, "CompID"));
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE GEN_CompanyProfile SET CompID = ?, CompanyName = ? WHERE (CompID = ?) AND " +
				"(CompanyName = ?); SELECT CompID, CompanyName FROM GEN_CompanyProfile WHERE (Com" +
				"pID = ?)";
			this.oleDbUpdateCommand1.Connection = this.con1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 4, "CompID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompanyName", System.Data.OleDb.OleDbType.VarChar, 250, "CompanyName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompanyName", System.Data.OleDb.OleDbType.VarChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompanyName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_CompID", System.Data.OleDb.OleDbType.Integer, 4, "CompID"));
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM GEN_CompanyProfile WHERE (CompID = ?) AND (CompanyName = ?)";
			this.oleDbDeleteCommand1.Connection = this.con1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompanyName", System.Data.OleDb.OleDbType.VarChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompanyName", System.Data.DataRowVersion.Original, null));
			// 
			// con1
			// 
			this.con1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=BASSAM;Tag with column collation when possible=False;Initial Catalog=ERPdb;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASSAM;Use Encryption for Data=False";
			// 
			// dsCompaniesProfiles1
			// 
			this.dsCompaniesProfiles1.DataSetName = "dsCompaniesProfiles";
			this.dsCompaniesProfiles1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// CompaniesProfilesData
			// 
			this.ComponentDataAdabter = this.odaCompaniesProfiles;
			this.ComponentDataSet = this.dsCompaniesProfiles1;
			this.Connection = this.con1;
			((System.ComponentModel.ISupportInitialize)(this.dsCompaniesProfiles1)).EndInit();

		}
		#endregion

	}
}
