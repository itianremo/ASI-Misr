using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for CityDataClass.
	/// </summary>
	public class CityDataClass : TSN.ERP.Engine.BussinesComponent 
	{
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterStateCities;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private TSN.ERP.SharedComponents.Data.dsCity dsCity1;
		private System.Data.OleDb.OleDbDataAdapter odaCities;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CityDataClass(System.ComponentModel.IContainer container)
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

		public CityDataClass()
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
			this.oleDbDataAdapterStateCities = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.odaCities = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dsCity1 = new TSN.ERP.SharedComponents.Data.dsCity();
			((System.ComponentModel.ISupportInitialize)(this.dsCity1)).BeginInit();
			// 
			// oleDbDataAdapterStateCities
			// 
			this.oleDbDataAdapterStateCities.DeleteCommand = this.oleDbDeleteCommand2;
			this.oleDbDataAdapterStateCities.InsertCommand = this.oleDbInsertCommand2;
			this.oleDbDataAdapterStateCities.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbDataAdapterStateCities.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												  new System.Data.Common.DataTableMapping("Table", "GEN_City", new System.Data.Common.DataColumnMapping[] {
																																																							  new System.Data.Common.DataColumnMapping("CityID", "CityID"),
																																																							  new System.Data.Common.DataColumnMapping("StateCode", "StateCode"),
																																																							  new System.Data.Common.DataColumnMapping("CityName", "CityName")})});
			this.oleDbDataAdapterStateCities.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = "DELETE FROM GEN_City WHERE (CityID = ?) AND (CityName = ? OR ? IS NULL AND CityNa" +
				"me IS NULL) AND (StateCode = ? OR ? IS NULL AND StateCode IS NULL)";
			this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CityID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CityName", System.Data.OleDb.OleDbType.VarChar, 70, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CityName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CityName1", System.Data.OleDb.OleDbType.VarChar, 70, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CityName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StateCode", System.Data.OleDb.OleDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StateCode", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StateCode1", System.Data.OleDb.OleDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StateCode", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Auto Translate=True;Integrated Security=SSPI;User ID=RW;Data Source=""ERP\ERPSQL2005"";Tag with column collation when possible=False;Initial Catalog=TestAccountability_Data;Use Procedure for Prepare=1;Provider=""SQLOLEDB.1"";Persist Security Info=False;Workstation ID=HAMDYAHMED;Use Encryption for Data=False;Packet Size=4096";
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO GEN_City(CityID, StateCode, CityName) VALUES (?, ?, ?); SELECT CityID" +
				", StateCode, CityName FROM GEN_City WHERE (CityID = ?)";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CityID", System.Data.OleDb.OleDbType.Integer, 4, "CityID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("StateCode", System.Data.OleDb.OleDbType.VarChar, 6, "StateCode"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CityName", System.Data.OleDb.OleDbType.VarChar, 70, "CityName"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_CityID", System.Data.OleDb.OleDbType.Integer, 4, "CityID"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT CityID, StateCode, CityName FROM GEN_City WHERE (StateCode = ?)";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("StateCode", System.Data.OleDb.OleDbType.VarChar, 6, "StateCode"));
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = "UPDATE GEN_City SET CityID = ?, StateCode = ?, CityName = ? WHERE (CityID = ?) AN" +
				"D (CityName = ? OR ? IS NULL AND CityName IS NULL) AND (StateCode = ? OR ? IS NU" +
				"LL AND StateCode IS NULL); SELECT CityID, StateCode, CityName FROM GEN_City WHER" +
				"E (CityID = ?)";
			this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CityID", System.Data.OleDb.OleDbType.Integer, 4, "CityID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("StateCode", System.Data.OleDb.OleDbType.VarChar, 6, "StateCode"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CityName", System.Data.OleDb.OleDbType.VarChar, 70, "CityName"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CityID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CityName", System.Data.OleDb.OleDbType.VarChar, 70, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CityName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CityName1", System.Data.OleDb.OleDbType.VarChar, 70, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CityName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StateCode", System.Data.OleDb.OleDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StateCode", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StateCode1", System.Data.OleDb.OleDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StateCode", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_CityID", System.Data.OleDb.OleDbType.Integer, 4, "CityID"));
			// 
			// odaCities
			// 
			this.odaCities.DeleteCommand = this.oleDbDeleteCommand1;
			this.odaCities.InsertCommand = this.oleDbInsertCommand1;
			this.odaCities.SelectCommand = this.oleDbSelectCommand1;
			this.odaCities.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								new System.Data.Common.DataTableMapping("Table", "GEN_City", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("CityID", "CityID"),
																																																			new System.Data.Common.DataColumnMapping("StateCode", "StateCode"),
																																																			new System.Data.Common.DataColumnMapping("CityName", "CityName")})});
			this.odaCities.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM GEN_City WHERE (CityID = ?) AND (CityName = ? OR ? IS NULL AND CityNa" +
				"me IS NULL) AND (StateCode = ? OR ? IS NULL AND StateCode IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CityID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CityName", System.Data.OleDb.OleDbType.VarChar, 70, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CityName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CityName1", System.Data.OleDb.OleDbType.VarChar, 70, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CityName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StateCode", System.Data.OleDb.OleDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StateCode", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StateCode1", System.Data.OleDb.OleDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StateCode", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO GEN_City(CityID, StateCode, CityName) VALUES (?, ?, ?); SELECT CityID" +
				", StateCode, CityName FROM GEN_City WHERE (CityID = ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CityID", System.Data.OleDb.OleDbType.Integer, 4, "CityID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("StateCode", System.Data.OleDb.OleDbType.VarChar, 6, "StateCode"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CityName", System.Data.OleDb.OleDbType.VarChar, 70, "CityName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_CityID", System.Data.OleDb.OleDbType.Integer, 4, "CityID"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT CityID, StateCode, CityName FROM GEN_City";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE GEN_City SET CityID = ?, StateCode = ?, CityName = ? WHERE (CityID = ?) AN" +
				"D (CityName = ? OR ? IS NULL AND CityName IS NULL) AND (StateCode = ? OR ? IS NU" +
				"LL AND StateCode IS NULL); SELECT CityID, StateCode, CityName FROM GEN_City WHER" +
				"E (CityID = ?)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CityID", System.Data.OleDb.OleDbType.Integer, 4, "CityID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("StateCode", System.Data.OleDb.OleDbType.VarChar, 6, "StateCode"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CityName", System.Data.OleDb.OleDbType.VarChar, 70, "CityName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CityID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CityName", System.Data.OleDb.OleDbType.VarChar, 70, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CityName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CityName1", System.Data.OleDb.OleDbType.VarChar, 70, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CityName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StateCode", System.Data.OleDb.OleDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StateCode", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StateCode1", System.Data.OleDb.OleDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StateCode", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_CityID", System.Data.OleDb.OleDbType.Integer, 4, "CityID"));
			// 
			// dsCity1
			// 
			this.dsCity1.DataSetName = "dsCity";
			this.dsCity1.EnforceConstraints = false;
			this.dsCity1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// CityDataClass
			// 
			this.ComponentDataAdabter = this.odaCities;
			this.ComponentDataSet = this.dsCity1;
			this.Connection = this.oleDbConnection1;
			((System.ComponentModel.ISupportInitialize)(this.dsCity1)).EndInit();

		}
		#endregion

		public DataSet GetStateCities( int stateID )
		{
			return List("StateCode = " + stateID.ToString());
		}
	}
}
