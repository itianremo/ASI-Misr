using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using TSN.ERP.Engine;
namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for CompanyElmentsData.
	/// </summary>
	public class CompanyElmentsData:BussinesComponent 
	{
		private System.Data.OleDb.OleDbDataAdapter odaCompanyElemnts;
		private System.Data.OleDb.OleDbConnection con1;
		private TSN.ERP.SharedComponents.Data.dsCompanyElements dsCompanyElements1;
		private System.Data.OleDb.OleDbCommand CheckElmExists;
		private System.Data.OleDb.OleDbCommand HasChildCount;
		private System.Data.OleDb.OleDbDataAdapter odaChildrenCompanyElements;
		private System.Data.OleDb.OleDbCommand odcGetElementLevel;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CompanyElmentsData(System.ComponentModel.IContainer container)
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

		public CompanyElmentsData()
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
			this.odaCompanyElemnts = new System.Data.OleDb.OleDbDataAdapter();
			this.con1 = new System.Data.OleDb.OleDbConnection();
			this.dsCompanyElements1 = new TSN.ERP.SharedComponents.Data.dsCompanyElements();
			this.CheckElmExists = new System.Data.OleDb.OleDbCommand();
			this.HasChildCount = new System.Data.OleDb.OleDbCommand();
			this.odaChildrenCompanyElements = new System.Data.OleDb.OleDbDataAdapter();
			this.odcGetElementLevel = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsCompanyElements1)).BeginInit();
			// 
			// odaCompanyElemnts
			// 
			this.odaCompanyElemnts.DeleteCommand = this.oleDbDeleteCommand1;
			this.odaCompanyElemnts.InsertCommand = this.oleDbInsertCommand1;
			this.odaCompanyElemnts.SelectCommand = this.oleDbSelectCommand1;
			this.odaCompanyElemnts.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "GEN_CompanyElments", new System.Data.Common.DataColumnMapping[] {
																																																							  new System.Data.Common.DataColumnMapping("CompElmentID", "CompElmentID"),
																																																							  new System.Data.Common.DataColumnMapping("CEL_ID", "CEL_ID"),
																																																							  new System.Data.Common.DataColumnMapping("CompID", "CompID"),
																																																							  new System.Data.Common.DataColumnMapping("CEParent", "CEParent"),
																																																							  new System.Data.Common.DataColumnMapping("CEName", "CEName"),
																																																							  new System.Data.Common.DataColumnMapping("CEDescription", "CEDescription"),
																																																							  new System.Data.Common.DataColumnMapping("ContactID", "ContactID")})});
			this.odaCompanyElemnts.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// con1
			// 
			this.con1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=BASSAM;Tag with column collation when possible=False;Initial Catalog=ERPdb;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASSAM;Use Encryption for Data=False";
			// 
			// dsCompanyElements1
			// 
			this.dsCompanyElements1.DataSetName = "dsCompanyElements";
			this.dsCompanyElements1.EnforceConstraints = false;
			this.dsCompanyElements1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// CheckElmExists
			// 
			this.CheckElmExists.CommandText = "SELECT COUNT(*) AS Expr1 FROM GEN_CompanyElments WHERE (CompElmentID = ?)";
			this.CheckElmExists.Connection = this.con1;
			this.CheckElmExists.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompElmentID", System.Data.OleDb.OleDbType.Integer, 4, "CompElmentID"));
			// 
			// HasChildCount
			// 
			this.HasChildCount.CommandText = "SELECT COUNT(*) AS Expr1 FROM GEN_CompanyElments GROUP BY CEParent HAVING (CEPare" +
				"nt = ?)";
			this.HasChildCount.Connection = this.con1;
			this.HasChildCount.Parameters.Add(new System.Data.OleDb.OleDbParameter("CEParent", System.Data.OleDb.OleDbType.Integer, 4, "CEParent"));
			// 
			// odaChildrenCompanyElements
			// 
			this.odaChildrenCompanyElements.SelectCommand = this.oleDbSelectCommand2;
			this.odaChildrenCompanyElements.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												 new System.Data.Common.DataTableMapping("Table", "GEN_CompanyElments", new System.Data.Common.DataColumnMapping[] {
																																																									   new System.Data.Common.DataColumnMapping("CompElmentID", "CompElmentID"),
																																																									   new System.Data.Common.DataColumnMapping("CEL_ID", "CEL_ID"),
																																																									   new System.Data.Common.DataColumnMapping("CompID", "CompID"),
																																																									   new System.Data.Common.DataColumnMapping("CEParent", "CEParent"),
																																																									   new System.Data.Common.DataColumnMapping("CEName", "CEName"),
																																																									   new System.Data.Common.DataColumnMapping("CEDescription", "CEDescription"),
																																																									   new System.Data.Common.DataColumnMapping("ContactID", "ContactID")})});
			// 
			// odcGetElementLevel
			// 
			this.odcGetElementLevel.CommandText = "SELECT CEL_ID FROM GEN_CompanyElments WHERE (CompElmentID = ?)";
			this.odcGetElementLevel.Connection = this.con1;
			this.odcGetElementLevel.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompElmentID", System.Data.OleDb.OleDbType.Integer, 4, "CompElmentID"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT CompElmentID, CEL_ID, CompID, CEParent, CEName, CEDescription, ContactID F" +
				"ROM GEN_CompanyElments";
			this.oleDbSelectCommand1.Connection = this.con1;
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = @"INSERT INTO GEN_CompanyElments(CompElmentID, CEL_ID, CompID, CEParent, CEName, CEDescription, ContactID) VALUES (?, ?, ?, ?, ?, ?, ?); SELECT CompElmentID, CEL_ID, CompID, CEParent, CEName, CEDescription, ContactID FROM GEN_CompanyElments WHERE (CompElmentID = ?)";
			this.oleDbInsertCommand1.Connection = this.con1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompElmentID", System.Data.OleDb.OleDbType.Integer, 4, "CompElmentID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CEL_ID", System.Data.OleDb.OleDbType.Integer, 4, "CEL_ID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 4, "CompID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CEParent", System.Data.OleDb.OleDbType.Integer, 4, "CEParent"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CEName", System.Data.OleDb.OleDbType.VarChar, 120, "CEName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CEDescription", System.Data.OleDb.OleDbType.VarChar, 2147483647, "CEDescription"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_CompElmentID", System.Data.OleDb.OleDbType.Integer, 4, "CompElmentID"));
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE GEN_CompanyElments SET CompElmentID = ?, CEL_ID = ?, CompID = ?, CEParent = ?, CEName = ?, CEDescription = ?, ContactID = ? WHERE (CompElmentID = ?) AND (CEL_ID = ? OR ? IS NULL AND CEL_ID IS NULL) AND (CEName = ?) AND (CEParent = ? OR ? IS NULL AND CEParent IS NULL) AND (CompID = ? OR ? IS NULL AND CompID IS NULL) AND (ContactID = ? OR ? IS NULL AND ContactID IS NULL); SELECT CompElmentID, CEL_ID, CompID, CEParent, CEName, CEDescription, ContactID FROM GEN_CompanyElments WHERE (CompElmentID = ?)";
			this.oleDbUpdateCommand1.Connection = this.con1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompElmentID", System.Data.OleDb.OleDbType.Integer, 4, "CompElmentID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CEL_ID", System.Data.OleDb.OleDbType.Integer, 4, "CEL_ID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 4, "CompID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CEParent", System.Data.OleDb.OleDbType.Integer, 4, "CEParent"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CEName", System.Data.OleDb.OleDbType.VarChar, 120, "CEName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CEDescription", System.Data.OleDb.OleDbType.VarChar, 2147483647, "CEDescription"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompElmentID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompElmentID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CEL_ID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CEL_ID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CEL_ID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CEL_ID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CEName", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CEName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CEParent", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CEParent", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CEParent1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CEParent", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_CompElmentID", System.Data.OleDb.OleDbType.Integer, 4, "CompElmentID"));
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = @"DELETE FROM GEN_CompanyElments WHERE (CompElmentID = ?) AND (CEL_ID = ? OR ? IS NULL AND CEL_ID IS NULL) AND (CEName = ?) AND (CEParent = ? OR ? IS NULL AND CEParent IS NULL) AND (CompID = ? OR ? IS NULL AND CompID IS NULL) AND (ContactID = ? OR ? IS NULL AND ContactID IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.con1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompElmentID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompElmentID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CEL_ID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CEL_ID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CEL_ID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CEL_ID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CEName", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CEName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CEParent", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CEParent", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CEParent1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CEParent", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT CompElmentID, CEL_ID, CompID, CEParent, CEName, CEDescription, ContactID F" +
				"ROM GEN_CompanyElments WHERE (CEParent = ?)";
			this.oleDbSelectCommand2.Connection = this.con1;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CEParent", System.Data.OleDb.OleDbType.Integer, 4, "CEParent"));
			// 
			// CompanyElmentsData
			// 
			this.ComponentDataAdabter = this.odaCompanyElemnts;
			this.ComponentDataSet = this.dsCompanyElements1;
			this.Connection = this.con1;
			((System.ComponentModel.ISupportInitialize)(this.dsCompanyElements1)).EndInit();

		}
		#endregion
	
		public bool CheckElmentExists(int id)
		{
			return true;
		}
	
		public int CountChildElments(int id)
		{
	     HasChildCount.Parameters[0].Value =id;
         int recno =(int) HasChildCount.ExecuteScalar() ;
         return recno;
		}
		public DataSet ListChildrenCompanyElements(int ParentCoElementID)
		{
			
			return List("CEParent = " +ParentCoElementID.ToString());
		}
		public int GetElementLevel(int ElementID)
		{
			odcGetElementLevel.Parameters[0].Value = ElementID;
			return (int)odcGetElementLevel.ExecuteScalar(); 
		}
	}
}
