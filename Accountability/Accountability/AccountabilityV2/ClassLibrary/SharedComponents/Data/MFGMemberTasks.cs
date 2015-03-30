using System;
using System.Data;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for MFGMemberTasks.
	/// </summary>
	public class MFGMemberTasks :TSN.ERP.Engine.BussinesComponent 
	{
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
		private System.Data.OleDb.OleDbConnection oleDbConnection2;
		private TSN.ERP.SharedComponents.Data.dsMFGMemberTasks dsMFGMemberTasks1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterEmpMFGTasks;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbCommand1;
		private System.Data.OleDb.OleDbCommand oleDbCommand2;
		private System.Data.OleDb.OleDbCommand oleDbCommand3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MFGMemberTasks(System.ComponentModel.IContainer container)
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

		public MFGMemberTasks()
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

		public dsMFGMemberTasks GetAllEmployeeMFGTasks( int ContactID , DateTime Date )
		{
			try
			{
				dsMFGMemberTasks1.Clear();
				oleDbDataAdapterEmpMFGTasks.SelectCommand.Parameters[ 0 ].Value = Date;
				oleDbDataAdapterEmpMFGTasks.SelectCommand.Parameters[ 1 ].Value = ContactID;
				oleDbDataAdapterEmpMFGTasks.Fill( dsMFGMemberTasks1 );
			}
			catch( Exception ee )
			{

			}
			return dsMFGMemberTasks1;
		}

		public void SaveTasksSheet( DataSet dsSheet )
		{
			try
			{
				oleDbDataAdapter1.Update( dsSheet );
			}
			catch( Exception ee )
			{

			}
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbConnection2 = new System.Data.OleDb.OleDbConnection();
			this.dsMFGMemberTasks1 = new TSN.ERP.SharedComponents.Data.dsMFGMemberTasks();
			this.oleDbDataAdapterEmpMFGTasks = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsMFGMemberTasks1)).BeginInit();
			// 
			// oleDbDataAdapter1
			// 
			this.oleDbDataAdapter1.DeleteCommand = this.oleDbCommand3;
			this.oleDbDataAdapter1.InsertCommand = this.oleDbCommand2;
			this.oleDbDataAdapter1.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "GEN_MFGMemberTasks", new System.Data.Common.DataColumnMapping[] {
																																																							  new System.Data.Common.DataColumnMapping("TrvID", "TrvID"),
																																																							  new System.Data.Common.DataColumnMapping("TrvNumber", "TrvNumber"),
																																																							  new System.Data.Common.DataColumnMapping("Compnay", "Compnay"),
																																																							  new System.Data.Common.DataColumnMapping("ClipMember", "ClipMember"),
																																																							  new System.Data.Common.DataColumnMapping("PartClass", "PartClass"),
																																																							  new System.Data.Common.DataColumnMapping("PartNumber", "PartNumber"),
																																																							  new System.Data.Common.DataColumnMapping("Operation", "Operation"),
																																																							  new System.Data.Common.DataColumnMapping("Quantity", "Quantity"),
																																																							  new System.Data.Common.DataColumnMapping("Hours", "Hours"),
																																																							  new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																							  new System.Data.Common.DataColumnMapping("TaskDate", "TaskDate"),
																																																							  new System.Data.Common.DataColumnMapping("EnteredBy", "EnteredBy")})});
			this.oleDbDataAdapter1.UpdateCommand = this.oleDbCommand1;
			// 
			// oleDbConnection2
			// 
			this.oleDbConnection2.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=""ERP\ERPSQL2005"";Tag with column collation when possible=False;Initial Catalog=TestAccountability_Data;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASANT;Use Encryption for Data=False";
			// 
			// dsMFGMemberTasks1
			// 
			this.dsMFGMemberTasks1.DataSetName = "dsMFGMemberTasks";
			this.dsMFGMemberTasks1.EnforceConstraints = false;
			this.dsMFGMemberTasks1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbDataAdapterEmpMFGTasks
			// 
			this.oleDbDataAdapterEmpMFGTasks.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbDataAdapterEmpMFGTasks.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												  new System.Data.Common.DataTableMapping("Table", "GEN_MFGMemberTasks", new System.Data.Common.DataColumnMapping[] {
																																																										new System.Data.Common.DataColumnMapping("TrvID", "TrvID"),
																																																										new System.Data.Common.DataColumnMapping("TrvNumber", "TrvNumber"),
																																																										new System.Data.Common.DataColumnMapping("Compnay", "Compnay"),
																																																										new System.Data.Common.DataColumnMapping("ClipMember", "ClipMember"),
																																																										new System.Data.Common.DataColumnMapping("PartClass", "PartClass"),
																																																										new System.Data.Common.DataColumnMapping("PartNumber", "PartNumber"),
																																																										new System.Data.Common.DataColumnMapping("Operation", "Operation"),
																																																										new System.Data.Common.DataColumnMapping("Quantity", "Quantity"),
																																																										new System.Data.Common.DataColumnMapping("Hours", "Hours"),
																																																										new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																										new System.Data.Common.DataColumnMapping("TaskDate", "TaskDate"),
																																																										new System.Data.Common.DataColumnMapping("EnteredBy", "EnteredBy")})});
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT TrvID, TrvNumber, Compnay, ClipMember, PartClass, PartNumber, Operation, Q" +
				"uantity, Hours, ContactID, TaskDate, EnteredBy FROM GEN_MFGMemberTasks WHERE (Ta" +
				"skDate = ?) AND (ContactID = ?)";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection2;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "TaskDate"));
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT TrvID, TrvNumber, Compnay, ClipMember, PartClass, PartNumber, Operation, Q" +
				"uantity, Hours, ContactID, TaskDate, EnteredBy FROM GEN_MFGMemberTasks";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection2;
			// 
			// oleDbCommand1
			// 
			this.oleDbCommand1.CommandText = "UPDATE GEN_MFGMemberTasks SET TrvNumber = ?, Compnay = ?, ClipMember = ?, PartCla" +
				"ss = ?, PartNumber = ?, Operation = ?, Quantity = ?, Hours = ?, ContactID = ?, T" +
				"askDate = ?, EnteredBy = ? WHERE (TrvID = ?)";
			this.oleDbCommand1.Connection = this.oleDbConnection2;
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TrvNumber", System.Data.OleDb.OleDbType.BigInt, 8, "TrvNumber"));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Compnay", System.Data.OleDb.OleDbType.VarWChar, 100, "Compnay"));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ClipMember", System.Data.OleDb.OleDbType.VarWChar, 10, "ClipMember"));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PartClass", System.Data.OleDb.OleDbType.VarWChar, 50, "PartClass"));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PartNumber", System.Data.OleDb.OleDbType.VarWChar, 100, "PartNumber"));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Operation", System.Data.OleDb.OleDbType.VarWChar, 100, "Operation"));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Quantity", System.Data.OleDb.OleDbType.Integer, 4, "Quantity"));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Hours", System.Data.OleDb.OleDbType.Double, 8, "Hours"));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "TaskDate"));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("EnteredBy", System.Data.OleDb.OleDbType.Integer, 4, "EnteredBy"));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TrvID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TrvID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbCommand2
			// 
			this.oleDbCommand2.CommandText = "INSERT INTO GEN_MFGMemberTasks (TrvNumber, Compnay, ClipMember, PartClass, PartNu" +
				"mber, Operation, Quantity, Hours, ContactID, TaskDate, EnteredBy) VALUES (?, ?, " +
				"?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbCommand2.Connection = this.oleDbConnection2;
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("TrvNumber", System.Data.OleDb.OleDbType.BigInt, 8, "TrvNumber"));
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Compnay", System.Data.OleDb.OleDbType.VarWChar, 100, "Compnay"));
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ClipMember", System.Data.OleDb.OleDbType.VarWChar, 10, "ClipMember"));
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("PartClass", System.Data.OleDb.OleDbType.VarWChar, 50, "PartClass"));
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("PartNumber", System.Data.OleDb.OleDbType.VarWChar, 100, "PartNumber"));
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Operation", System.Data.OleDb.OleDbType.VarWChar, 100, "Operation"));
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Quantity", System.Data.OleDb.OleDbType.Integer, 4, "Quantity"));
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Hours", System.Data.OleDb.OleDbType.Double, 8, "Hours"));
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("TaskDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "TaskDate"));
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("EnteredBy", System.Data.OleDb.OleDbType.Integer, 4, "EnteredBy"));
			// 
			// oleDbCommand3
			// 
			this.oleDbCommand3.CommandText = "DELETE FROM GEN_MFGMemberTasks WHERE (TrvID = ?)";
			this.oleDbCommand3.Connection = this.oleDbConnection2;
			this.oleDbCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("TrvID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TrvID", System.Data.DataRowVersion.Original, null));
			// 
			// MFGMemberTasks
			// 
			this.ComponentDataAdabter = this.oleDbDataAdapter1;
			this.ComponentDataSet = this.dsMFGMemberTasks1;
			this.Connection = this.oleDbConnection2;
			((System.ComponentModel.ISupportInitialize)(this.dsMFGMemberTasks1)).EndInit();

		}
		#endregion
	}
}
