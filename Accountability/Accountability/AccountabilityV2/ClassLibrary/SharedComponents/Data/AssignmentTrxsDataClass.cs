using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for AssignmentTrxsDataClass.
	/// </summary>
	public class AssignmentTrxsDataClass : TSN.ERP.Engine.BussinesComponent 
	{
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private TSN.ERP.SharedComponents.Data.dsAssignmentTransaction dsAssignmentTransaction1;
		private System.Data.OleDb.OleDbDataAdapter odaGetMaxAssTransDate;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AssignmentTrxsDataClass(System.ComponentModel.IContainer container)
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

		public AssignmentTrxsDataClass()
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
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dsAssignmentTransaction1 = new TSN.ERP.SharedComponents.Data.dsAssignmentTransaction();
			this.odaGetMaxAssTransDate = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsAssignmentTransaction1)).BeginInit();
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=BASSAM;Tag with column collation when possible=False;Initial Catalog=ERPdb;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASANT;Use Encryption for Data=False";
			// 
			// oleDbDataAdapter1
			// 
			this.oleDbDataAdapter1.DeleteCommand = this.oleDbDeleteCommand1;
			this.oleDbDataAdapter1.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbDataAdapter1.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "GEN_AssgimentTransactions", new System.Data.Common.DataColumnMapping[] {
																																																									 new System.Data.Common.DataColumnMapping("TransID", "TransID"),
																																																									 new System.Data.Common.DataColumnMapping("AssignmentD", "AssignmentD"),
																																																									 new System.Data.Common.DataColumnMapping("AssTransType", "AssTransType"),
																																																									 new System.Data.Common.DataColumnMapping("OldStatus", "OldStatus"),
																																																									 new System.Data.Common.DataColumnMapping("OLdEvalution", "OLdEvalution"),
																																																									 new System.Data.Common.DataColumnMapping("NewStatus", "NewStatus"),
																																																									 new System.Data.Common.DataColumnMapping("NewEvalutation", "NewEvalutation")})});
			this.oleDbDataAdapter1.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = @"DELETE FROM GEN_AssgimentTransactions WHERE (TransID = ?) AND (AssTransType = ?) AND (AssignmentD = ? OR ? IS NULL AND AssignmentD IS NULL) AND (NewEvalutation = ?) AND (NewStatus = ?) AND (OLdEvalution = ? OR ? IS NULL AND OLdEvalution IS NULL) AND (OldStatus = ? OR ? IS NULL AND OldStatus IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TransID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TransID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssTransType", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssTransType", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentD", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentD1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentD", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_NewEvalutation", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "NewEvalutation", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_NewStatus", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "NewStatus", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OLdEvalution", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OLdEvalution", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OLdEvalution1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OLdEvalution", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OldStatus", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OldStatus", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OldStatus1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OldStatus", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = @"INSERT INTO GEN_AssgimentTransactions(TransID, AssignmentD, AssTransType, OldStatus, OLdEvalution, NewStatus, NewEvalutation) VALUES (?, ?, ?, ?, ?, ?, ?); SELECT TransID, AssignmentD, AssTransType, OldStatus, OLdEvalution, NewStatus, NewEvalutation FROM GEN_AssgimentTransactions WHERE (TransID = ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TransID", System.Data.OleDb.OleDbType.Integer, 4, "TransID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, "AssignmentD"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssTransType", System.Data.OleDb.OleDbType.SmallInt, 2, "AssTransType"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("OldStatus", System.Data.OleDb.OleDbType.SmallInt, 2, "OldStatus"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("OLdEvalution", System.Data.OleDb.OleDbType.SmallInt, 2, "OLdEvalution"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("NewStatus", System.Data.OleDb.OleDbType.SmallInt, 2, "NewStatus"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("NewEvalutation", System.Data.OleDb.OleDbType.SmallInt, 2, "NewEvalutation"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_TransID", System.Data.OleDb.OleDbType.Integer, 4, "TransID"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT TransID, AssignmentD, AssTransType, OldStatus, OLdEvalution, NewStatus, Ne" +
				"wEvalutation FROM GEN_AssgimentTransactions";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE GEN_AssgimentTransactions SET TransID = ?, AssignmentD = ?, AssTransType = ?, OldStatus = ?, OLdEvalution = ?, NewStatus = ?, NewEvalutation = ? WHERE (TransID = ?) AND (AssTransType = ?) AND (AssignmentD = ? OR ? IS NULL AND AssignmentD IS NULL) AND (NewEvalutation = ?) AND (NewStatus = ?) AND (OLdEvalution = ? OR ? IS NULL AND OLdEvalution IS NULL) AND (OldStatus = ? OR ? IS NULL AND OldStatus IS NULL); SELECT TransID, AssignmentD, AssTransType, OldStatus, OLdEvalution, NewStatus, NewEvalutation FROM GEN_AssgimentTransactions WHERE (TransID = ?)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TransID", System.Data.OleDb.OleDbType.Integer, 4, "TransID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, "AssignmentD"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssTransType", System.Data.OleDb.OleDbType.SmallInt, 2, "AssTransType"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("OldStatus", System.Data.OleDb.OleDbType.SmallInt, 2, "OldStatus"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("OLdEvalution", System.Data.OleDb.OleDbType.SmallInt, 2, "OLdEvalution"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("NewStatus", System.Data.OleDb.OleDbType.SmallInt, 2, "NewStatus"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("NewEvalutation", System.Data.OleDb.OleDbType.SmallInt, 2, "NewEvalutation"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TransID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TransID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssTransType", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssTransType", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentD", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AssignmentD1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AssignmentD", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_NewEvalutation", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "NewEvalutation", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_NewStatus", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "NewStatus", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OLdEvalution", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OLdEvalution", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OLdEvalution1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OLdEvalution", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OldStatus", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OldStatus", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OldStatus1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OldStatus", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_TransID", System.Data.OleDb.OleDbType.Integer, 4, "TransID"));
			// 
			// dsAssignmentTransaction1
			// 
			this.dsAssignmentTransaction1.DataSetName = "dsAssignmentTransaction";
			this.dsAssignmentTransaction1.EnforceConstraints = false;
			this.dsAssignmentTransaction1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// odaGetMaxAssTransDate
			// 
			this.odaGetMaxAssTransDate.SelectCommand = this.oleDbSelectCommand2;
			this.odaGetMaxAssTransDate.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											new System.Data.Common.DataTableMapping("Table", "Table", new System.Data.Common.DataColumnMapping[] {
																																																					 new System.Data.Common.DataColumnMapping("MaxTransDate", "MaxTransDate")})});
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT MAX(GEN_Transactions.TransTime) AS MaxTransDate FROM GEN_AssgimentTransact" +
				"ions INNER JOIN GEN_Transactions ON GEN_AssgimentTransactions.TransID = GEN_Tran" +
				"sactions.TransID WHERE (GEN_AssgimentTransactions.AssignmentD = ?)";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, "AssignmentD"));
			// 
			// AssignmentTrxsDataClass
			// 
			this.ComponentDataAdabter = this.oleDbDataAdapter1;
			this.ComponentDataSet = this.dsAssignmentTransaction1;
			this.Connection = this.oleDbConnection1;
			((System.ComponentModel.ISupportInitialize)(this.dsAssignmentTransaction1)).EndInit();

		}
		#endregion

		public DateTime GetMaxAssTransDate(int assignmentID)
		{
			odaGetMaxAssTransDate.SelectCommand.Parameters[0].Value = assignmentID;
			DateTime dt = Convert.ToDateTime(odaGetMaxAssTransDate.SelectCommand.ExecuteScalar());
			return dt;
		}


	}
}
