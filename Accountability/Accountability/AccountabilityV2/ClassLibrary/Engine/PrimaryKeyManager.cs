using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.OleDb;
//using System.EnterpriseServices;
namespace TSN.ERP.Engine
{
	/// <summary>
	/// Summary description for PrimaryKeyManager.
	/// </summary>
	/// 

	//[Transaction(TransactionOption.Disabled, Isolation=TransactionIsolationLevel.ReadUncommitted, Timeout=1)]
	public class PrimaryKeyManager : System.ComponentModel.Component
	{
		private System.Data.OleDb.OleDbDataAdapter odaKeyManger;
		private System.Data.OleDb.OleDbConnection con1;
		private TSN.ERP.Engine.Data.dsKeyManager dsKeyManager1;
		private Data.dsKeyManager.GEN_KeysManagerRow PKRow;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		//private System.ComponentModel.Container components = null;

		public PrimaryKeyManager(System.ComponentModel.IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			container.Add(this);
			InitializeComponent();

		}

		public PrimaryKeyManager()
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
		/// 

        ////////////////////[DebuggerStepThrough()] 
        ////////////////////protected override void Dispose( bool disposing )
        ////////////////////{
        ////////////////////    if (con1 != null)
        ////////////////////    {
        ////////////////////        con1.Dispose();
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
			this.odaKeyManger = new System.Data.OleDb.OleDbDataAdapter();
			this.con1 = new System.Data.OleDb.OleDbConnection();
			this.dsKeyManager1 = new TSN.ERP.Engine.Data.dsKeyManager();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsKeyManager1)).BeginInit();
			// 
			// odaKeyManger
			// 
			this.odaKeyManger.DeleteCommand = this.oleDbDeleteCommand1;
			this.odaKeyManger.InsertCommand = this.oleDbInsertCommand1;
			this.odaKeyManger.SelectCommand = this.oleDbSelectCommand1;
			this.odaKeyManger.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								   new System.Data.Common.DataTableMapping("Table", "GEN_KeysManager", new System.Data.Common.DataColumnMapping[] {
																																																					  new System.Data.Common.DataColumnMapping("cTableName", "cTableName"),
																																																					  new System.Data.Common.DataColumnMapping("cLastKey", "cLastKey")})});
			this.odaKeyManger.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// con1
			// 
			this.con1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=BASSAM;Tag with column collation when possible=False;Initial Catalog=ERPdb;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASSAM;Use Encryption for Data=False";
			// 
			// dsKeyManager1
			// 
			this.dsKeyManager1.DataSetName = "dsKeyManager";
			this.dsKeyManager1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT cTableName, cLastKey FROM GEN_KeysManager";
			this.oleDbSelectCommand1.Connection = this.con1;
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO GEN_KeysManager(cTableName, cLastKey) VALUES (?, ?); SELECT cTableNam" +
				"e, cLastKey FROM GEN_KeysManager WHERE (cTableName = ?)";
			this.oleDbInsertCommand1.Connection = this.con1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("cTableName", System.Data.OleDb.OleDbType.VarChar, 200, "cTableName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("cLastKey", System.Data.OleDb.OleDbType.Integer, 4, "cLastKey"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_cTableName", System.Data.OleDb.OleDbType.VarChar, 200, "cTableName"));
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE GEN_KeysManager SET cTableName = ?, cLastKey = ? WHERE (cTableName = ?) AN" +
				"D (cLastKey = ?); SELECT cTableName, cLastKey FROM GEN_KeysManager WHERE (cTable" +
				"Name = ?)";
			this.oleDbUpdateCommand1.Connection = this.con1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("cTableName", System.Data.OleDb.OleDbType.VarChar, 200, "cTableName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("cLastKey", System.Data.OleDb.OleDbType.Integer, 4, "cLastKey"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cTableName", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cTableName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cLastKey", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cLastKey", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_cTableName", System.Data.OleDb.OleDbType.VarChar, 200, "cTableName"));
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM GEN_KeysManager WHERE (cTableName = ?) AND (cLastKey = ?)";
			this.oleDbDeleteCommand1.Connection = this.con1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cTableName", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cTableName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cLastKey", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cLastKey", System.Data.DataRowVersion.Original, null));
			((System.ComponentModel.ISupportInitialize)(this.dsKeyManager1)).EndInit();

		}
		#endregion

		/// <summary>
		/// Adds primary key values to the newly added records
		/// </summary>
		/// <param name="NewRecords"></param>
		/// <returns>returns true if it succeeds to assgin primary keys</returns>
		public bool PrepareToSave(DataSet NewRecords)
		{
			dsKeyManager1.Clear();
			odaKeyManger.Fill(dsKeyManager1);
			int TableCount = dsKeyManager1.Tables.Count;
			for(int i = 0; i < TableCount; i++)
			{
				 if (!PrepareToSave(NewRecords.Tables[i]))
					 return false;
			}
			return true;
		}

		/// <summary>
		/// Adds primary key values to the newly added records, deals with a single table
		/// </summary>
		/// <param name="NewRecords"></param>
		/// <returns></returns>
		public bool PrepareToSave(DataTable NewRecords)
		{
			int RowCount = NewRecords.Rows.Count;
			int KeysCount = 0;
			//Getting the primary key name from the schema
			string pkName;
			if (NewRecords.PrimaryKey.Length > 0)
			{
				 pkName = NewRecords.PrimaryKey[0].ColumnName;
			}
			else
			{
				return true;
			}
			//Count the number of newly added records
			for (int i = 0; i <RowCount;i++ )
			{
				if (NewRecords.Rows[i].RowState == DataRowState.Added)
					KeysCount++;
			}
			// Gets the last key stored in the table
			int LastKey  = NextPrimaryKey(NewRecords.TableName);
			
			//Reserves the requiered number of keys in the dbase table, GEN_KeysManager
			if (!CommitLastPK(KeysCount))
				return false;

			for (int i = 0; i <RowCount;i++ )
			{
				if (NewRecords.Rows[i].RowState == DataRowState.Added)
				{
					LastKey++;
					NewRecords.Rows[i][pkName] = LastKey;
				}
			}
			return true;
		}

		public int NextPrimaryKey(string TableName) 
		{
			int Rowindex  = FindRow(TableName);
			if (Rowindex >= 0)
			{
				PKRow = dsKeyManager1.GEN_KeysManager[Rowindex];
			}
			else
			{
				PKRow = dsKeyManager1.GEN_KeysManager.NewGEN_KeysManagerRow();
				PKRow.cTableName = TableName;
				PKRow.cLastKey = 1000;
				dsKeyManager1.GEN_KeysManager.AddGEN_KeysManagerRow(PKRow);
				odaKeyManger.Update(dsKeyManager1);
			}
			return PKRow.cLastKey;
		}

		public bool CommitLastPK(int RecoredCount)
		{
			PKRow.cLastKey = PKRow.cLastKey + RecoredCount;
			odaKeyManger.Update(dsKeyManager1);
			return true;
		}
		
		public int FindRow(string TableName)
		{
			int RowCount = dsKeyManager1.GEN_KeysManager.Rows.Count;
			for(int i = 0; i < RowCount; i++)
			{
				Data.dsKeyManager.GEN_KeysManagerRow TableRow= dsKeyManager1.GEN_KeysManager[i];
				string tempname = TableRow.cTableName.TrimEnd();
				if (tempname == TableName)
					return i;
			}
			return -1;
		}
		public void SetConnection(string ConnectionString)
		{
			con1.Close();
			con1.ConnectionString = ConnectionString;
			con1.Open();
			
		}
	}
}
