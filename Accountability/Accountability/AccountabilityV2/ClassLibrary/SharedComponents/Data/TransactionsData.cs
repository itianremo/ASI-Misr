using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for TransactionsData.
	/// </summary>
	public class TransactionsData : Engine.BussinesComponent 
	{
		private System.Data.OleDb.OleDbDataAdapter odaTrans;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbConnection con1;
		private TSN.ERP.SharedComponents.Data.dsTransactions dsTransactions1;
		private System.Data.OleDb.OleDbCommand odcCreateTransaction;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TransactionsData(System.ComponentModel.IContainer container)
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

		public TransactionsData()
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
			this.odaTrans = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.con1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dsTransactions1 = new TSN.ERP.SharedComponents.Data.dsTransactions();
			this.odcCreateTransaction = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsTransactions1)).BeginInit();
			// 
			// odaTrans
			// 
			this.odaTrans.DeleteCommand = this.oleDbDeleteCommand1;
			this.odaTrans.InsertCommand = this.oleDbInsertCommand1;
			this.odaTrans.SelectCommand = this.oleDbSelectCommand1;
			this.odaTrans.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							   new System.Data.Common.DataTableMapping("Table", "GEN_Transactions", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("TransID", "TransID"),
																																																				   new System.Data.Common.DataColumnMapping("UserID", "UserID"),
																																																				   new System.Data.Common.DataColumnMapping("TransTime", "TransTime")})});
			this.odaTrans.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM GEN_Transactions WHERE (TransID = ?) AND (TransTime = ?) AND (UserID " +
				"= ? OR ? IS NULL AND UserID IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.con1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TransID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TransID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TransTime", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TransTime", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			// 
			// con1
			// 
			this.con1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=BASSAM;Tag with column collation when possible=False;Initial Catalog=ERPdb;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASSAM;Use Encryption for Data=False";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO GEN_Transactions(TransID, UserID, TransTime) VALUES (?, ?, ?); SELECT" +
				" TransID, UserID, TransTime FROM GEN_Transactions WHERE (TransID = ?)";
			this.oleDbInsertCommand1.Connection = this.con1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TransID", System.Data.OleDb.OleDbType.Integer, 4, "TransID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TransTime", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "TransTime"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_TransID", System.Data.OleDb.OleDbType.Integer, 4, "TransID"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT TransID, UserID, TransTime FROM GEN_Transactions";
			this.oleDbSelectCommand1.Connection = this.con1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE GEN_Transactions SET TransID = ?, UserID = ?, TransTime = ? WHERE (TransID" +
				" = ?) AND (TransTime = ?) AND (UserID = ? OR ? IS NULL AND UserID IS NULL); SELE" +
				"CT TransID, UserID, TransTime FROM GEN_Transactions WHERE (TransID = ?)";
			this.oleDbUpdateCommand1.Connection = this.con1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TransID", System.Data.OleDb.OleDbType.Integer, 4, "TransID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TransTime", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "TransTime"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TransID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TransID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TransTime", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TransTime", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_TransID", System.Data.OleDb.OleDbType.Integer, 4, "TransID"));
			// 
			// dsTransactions1
			// 
			this.dsTransactions1.DataSetName = "dsTransactions";
			this.dsTransactions1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// odcCreateTransaction
			// 
			this.odcCreateTransaction.CommandText = "INSERT INTO GEN_Transactions (UserID, TransTime) VALUES (?, ?)";
			this.odcCreateTransaction.Connection = this.con1;
			this.odcCreateTransaction.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			this.odcCreateTransaction.Parameters.Add(new System.Data.OleDb.OleDbParameter("TransTime", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "TransTime"));
			// 
			// TransactionsData
			// 
			this.ComponentDataAdabter = this.odaTrans;
			this.ComponentDataSet = this.dsTransactions1;
			this.Connection = this.con1;
			((System.ComponentModel.ISupportInitialize)(this.dsTransactions1)).EndInit();

		}
		#endregion
		protected override bool onDelete(System.Data.DataSet dsDeletedRecords)
		{
			return false;
		}
		protected override bool onEdit(System.Data.DataSet dsModifiedRecords)
		{
			return false;
		}
		public int CreateTransaction(int UserID)
		{
			dsTransactions dsTempTrans = new dsTransactions();
			dsTempTrans.Clear();
			dsTempTrans.EnforceConstraints = false;
			dsTransactions.GEN_TransactionsRow TransRow  = dsTempTrans.GEN_Transactions.NewGEN_TransactionsRow();
			TransRow.UserID = UserID;
			TransRow.TransTime = DateTime.Now;
			dsTempTrans.GEN_Transactions.AddGEN_TransactionsRow(TransRow);
			Add(dsTempTrans);
			return TransRow.TransID;
		}
	}
}
