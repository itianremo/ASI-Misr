using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for WebSitesDataClass.
	/// </summary>
	public class WebSitesDataClass :  TSN.ERP.Engine.BussinesComponent 
	{
		private TSN.ERP.SharedComponents.Data.dsWebSites dsWebSites1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterContactPrimaryWebsite;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterContactWebSites;
		private System.Data.OleDb.OleDbDataAdapter odaWebsites;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public WebSitesDataClass(System.ComponentModel.IContainer container)
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

		public WebSitesDataClass()
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
        ///// </summary>
        //protected override void Dispose( bool disposing )
        //{
        //    if( disposing )
        //    {
        //        if(components != null)
        //        {
        //            components.Dispose();
        //        }
        //    }
        //    base.Dispose( disposing );
        //}


		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dsWebSites1 = new TSN.ERP.SharedComponents.Data.dsWebSites();
			this.oleDbDataAdapterContactPrimaryWebsite = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDataAdapterContactWebSites = new System.Data.OleDb.OleDbDataAdapter();
			this.odaWebsites = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsWebSites1)).BeginInit();
			// 
			// dsWebSites1
			// 
			this.dsWebSites1.DataSetName = "dsWebSites";
			this.dsWebSites1.EnforceConstraints = false;
			this.dsWebSites1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbDataAdapterContactPrimaryWebsite
			// 
			this.oleDbDataAdapterContactPrimaryWebsite.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbDataAdapterContactPrimaryWebsite.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																															new System.Data.Common.DataTableMapping("Table", "GEN_Websites", new System.Data.Common.DataColumnMapping[] {
																																																											new System.Data.Common.DataColumnMapping("ConactWebSite", "ConactWebSite"),
																																																											new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																											new System.Data.Common.DataColumnMapping("PrimaryWebSite", "PrimaryWebSite")})});
			// 
			// oleDbDataAdapterContactWebSites
			// 
			this.oleDbDataAdapterContactWebSites.SelectCommand = this.oleDbSelectCommand3;
			this.oleDbDataAdapterContactWebSites.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													  new System.Data.Common.DataTableMapping("Table", "GEN_Websites", new System.Data.Common.DataColumnMapping[] {
																																																									  new System.Data.Common.DataColumnMapping("ConactWebSite", "ConactWebSite"),
																																																									  new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																									  new System.Data.Common.DataColumnMapping("PrimaryWebSite", "PrimaryWebSite")})});
			// 
			// odaWebsites
			// 
			this.odaWebsites.DeleteCommand = this.oleDbDeleteCommand1;
			this.odaWebsites.InsertCommand = this.oleDbInsertCommand1;
			this.odaWebsites.SelectCommand = this.oleDbSelectCommand1;
			this.odaWebsites.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								  new System.Data.Common.DataTableMapping("Table", "GEN_Websites", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("ConactWebSite", "ConactWebSite"),
																																																				  new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																				  new System.Data.Common.DataColumnMapping("PrimaryWebSite", "PrimaryWebSite")})});
			this.odaWebsites.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT ConactWebSite, ContactID, PrimaryWebSite FROM GEN_Websites";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO GEN_Websites(ConactWebSite, ContactID, PrimaryWebSite) VALUES (?, ?, " +
				"?); SELECT ConactWebSite, ContactID, PrimaryWebSite FROM GEN_Websites WHERE (Con" +
				"actWebSite = ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ConactWebSite", System.Data.OleDb.OleDbType.VarChar, 180, "ConactWebSite"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PrimaryWebSite", System.Data.OleDb.OleDbType.Boolean, 1, "PrimaryWebSite"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_ConactWebSite", System.Data.OleDb.OleDbType.VarChar, 180, "ConactWebSite"));
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE GEN_Websites SET ConactWebSite = ?, ContactID = ?, PrimaryWebSite = ? WHERE (ConactWebSite = ?) AND (ContactID = ? OR ? IS NULL AND ContactID IS NULL) AND (PrimaryWebSite = ? OR ? IS NULL AND PrimaryWebSite IS NULL); SELECT ConactWebSite, ContactID, PrimaryWebSite FROM GEN_Websites WHERE (ConactWebSite = ?)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ConactWebSite", System.Data.OleDb.OleDbType.VarChar, 180, "ConactWebSite"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PrimaryWebSite", System.Data.OleDb.OleDbType.Boolean, 1, "PrimaryWebSite"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ConactWebSite", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ConactWebSite", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PrimaryWebSite", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PrimaryWebSite", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PrimaryWebSite1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PrimaryWebSite", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_ConactWebSite", System.Data.OleDb.OleDbType.VarChar, 180, "ConactWebSite"));
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM GEN_Websites WHERE (ConactWebSite = ?) AND (ContactID = ? OR ? IS NUL" +
				"L AND ContactID IS NULL) AND (PrimaryWebSite = ? OR ? IS NULL AND PrimaryWebSite" +
				" IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ConactWebSite", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ConactWebSite", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PrimaryWebSite", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PrimaryWebSite", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PrimaryWebSite1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PrimaryWebSite", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=BASSAM;Tag with column collation when possible=False;Initial Catalog=ERPdb;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASSAM;Use Encryption for Data=False";
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT ConactWebSite, ContactID, PrimaryWebSite FROM GEN_Websites WHERE (ContactI" +
				"D = ?) AND (PrimaryWebSite = 1)";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = "SELECT ConactWebSite, ContactID, PrimaryWebSite FROM GEN_Websites WHERE (ContactI" +
				"D = ?)";
			this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			// 
			// WebSitesDataClass
			// 
			this.ComponentDataAdabter = this.odaWebsites;
			this.ComponentDataSet = this.dsWebSites1;
			this.Connection = this.oleDbConnection1;
			((System.ComponentModel.ISupportInitialize)(this.dsWebSites1)).EndInit();

		}
		#endregion

		public dsWebSites GetContactWebSites( int contactID )
		{
			dsWebSites1.Clear();
			oleDbDataAdapterContactWebSites.SelectCommand.Parameters[0].Value = contactID;
			oleDbDataAdapterContactWebSites.Fill(dsWebSites1);
			return dsWebSites1;
		}

		public dsWebSites GetContactPrimaryWebSite( int contactID )
		{
			dsWebSites1.Clear();
			oleDbDataAdapterContactPrimaryWebsite.SelectCommand.Parameters[0].Value = contactID;
			oleDbDataAdapterContactPrimaryWebsite.Fill(dsWebSites1);
			return dsWebSites1;
		}
	}
}
