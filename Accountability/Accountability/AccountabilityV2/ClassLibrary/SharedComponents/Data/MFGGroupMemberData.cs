using System;
using System.Data;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for MFGGroupMemberData.
	/// </summary>
	public class MFGGroupMemberData :TSN.ERP.Engine.BussinesComponent 
	{
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private TSN.ERP.SharedComponents.Data.dsMFGGroupMember dsMFGGroupMember1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterMFGEmployees;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterUserIsMFG;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterAllAdminEmp;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterAllMFGAdmins;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand5;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterUserIsMFGEmployee;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand6;
		private System.Data.OleDb.OleDbCommand oleDbCommand1;
		private System.Data.OleDb.OleDbCommand oleDbCommand2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MFGGroupMemberData(System.ComponentModel.IContainer container)
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

		public MFGGroupMemberData()
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

		public DataSet GetMFGEmployees( int UserID )
		{
			DataSet	ds = new DataSet();
			try
			{
				oleDbDataAdapterMFGEmployees.SelectCommand.Parameters[ 0 ].Value = UserID;
				oleDbDataAdapterMFGEmployees.Fill( ds );
			}
			catch( Exception ee )
			{

			}
			return ds;
		}

		public DataSet GetAllAdminEmployees( )
		{
			DataSet	ds = new DataSet();
			try
			{
				oleDbDataAdapterAllAdminEmp.Fill( ds );
			}
			catch( Exception ee )
			{

			}
			return ds;
		}

		public DataSet GetAllMFGAdmins( )
		{
			DataSet	ds = new DataSet();
			try
			{
				oleDbDataAdapterAllMFGAdmins.Fill( ds );
			}
			catch( Exception ee )
			{

			}
			return ds;
		}

		public Boolean UserIsMFG( int UserID )
		{
			Boolean check = false;
			try
			{
				oleDbDataAdapterUserIsMFG.SelectCommand.Parameters[ "MFGUserID" ].Value = UserID;
				Object n = oleDbDataAdapterUserIsMFG.SelectCommand.ExecuteScalar( );
				if ( Convert.ToInt32( n )  != 0 )
					check = true;
	
			}
			catch( Exception ee )
			{

			}
			return check;
			
		}

		public Boolean UserIsMFGEmployee( int UserID )
		{
			Boolean check = false;
			try
			{
				oleDbDataAdapterUserIsMFGEmployee.SelectCommand.Parameters[ 0 ].Value = UserID;
				Object n = oleDbDataAdapterUserIsMFGEmployee.SelectCommand.ExecuteScalar( );
				if ( Convert.ToInt32( n )  != 0 )
					check = true;
	
			}
			catch( Exception ee )
			{

			}
			return check;
			
		}

		public int DeleteMFGAdmin( int MFGAdminUsrID )
		{
			int n= 0;
			try
			{
				oleDbDataAdapter1.DeleteCommand.Parameters[ 0 ].Value = MFGAdminUsrID;
				n = oleDbDataAdapter1.DeleteCommand.ExecuteNonQuery();
			}
			catch( Exception ee )
			{

			}
			return n;
		}

		public void AddMFGAdmin( DataSet ds )
		{
			try
			{
				for( int i = 0 ; i < ds.Tables[ 0 ].Rows.Count ; i++ )
				{
					oleDbDataAdapter1.InsertCommand.Parameters[ "MFGUserID" ].Value = ds.Tables[ 0 ].Rows[ i ][ "MFGUserID" ];
					oleDbDataAdapter1.InsertCommand.Parameters[ "ContactID" ].Value = ds.Tables[ 0 ].Rows[ i ][ "ContactID" ];
					oleDbDataAdapter1.InsertCommand.ExecuteNonQuery();
				}
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
			this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dsMFGGroupMember1 = new TSN.ERP.SharedComponents.Data.dsMFGGroupMember();
			this.oleDbDataAdapterMFGEmployees = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterUserIsMFG = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterAllAdminEmp = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterAllMFGAdmins = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterUserIsMFGEmployee = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand6 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsMFGGroupMember1)).BeginInit();
			// 
			// oleDbDataAdapter1
			// 
			this.oleDbDataAdapter1.DeleteCommand = this.oleDbCommand2;
			this.oleDbDataAdapter1.InsertCommand = this.oleDbCommand1;
			this.oleDbDataAdapter1.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "SEC_MFGGroupMember", new System.Data.Common.DataColumnMapping[] {
																																																							  new System.Data.Common.DataColumnMapping("MFGUserID", "MFGUserID"),
																																																							  new System.Data.Common.DataColumnMapping("ContactID", "ContactID")})});
			// 
			// oleDbCommand2
			// 
			this.oleDbCommand2.CommandText = "DELETE FROM SEC_MFGGroupMember WHERE (MFGUserID = ?)";
			this.oleDbCommand2.Connection = this.oleDbConnection1;
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("MFGUserID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MFGUserID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=""ERP\ERPSQL2005"";Tag with column collation when possible=False;Initial Catalog=TestAccountability_Data;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASANT;Use Encryption for Data=False";
			// 
			// oleDbCommand1
			// 
			this.oleDbCommand1.CommandText = "INSERT INTO SEC_MFGGroupMember (MFGUserID, ContactID) VALUES (?, ?)";
			this.oleDbCommand1.Connection = this.oleDbConnection1;
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("MFGUserID", System.Data.OleDb.OleDbType.Integer, 4, "MFGUserID"));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT MFGUserID, ContactID FROM SEC_MFGGroupMember";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// dsMFGGroupMember1
			// 
			this.dsMFGGroupMember1.DataSetName = "dsMFGGroupMember";
			this.dsMFGGroupMember1.EnforceConstraints = false;
			this.dsMFGGroupMember1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbDataAdapterMFGEmployees
			// 
			this.oleDbDataAdapterMFGEmployees.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbDataAdapterMFGEmployees.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												   new System.Data.Common.DataTableMapping("Table", "SEC_MFGGroupMember", new System.Data.Common.DataColumnMapping[] {
																																																										 new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																										 new System.Data.Common.DataColumnMapping("Fullname", "Fullname")})});
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT SEC_MFGGroupMember.ContactID, GEN_Contacts.Fullname FROM SEC_MFGGroupMembe" +
				"r INNER JOIN GEN_Contacts ON SEC_MFGGroupMember.ContactID = GEN_Contacts.Contact" +
				"ID WHERE (SEC_MFGGroupMember.MFGUserID = ?)";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("MFGUserID", System.Data.OleDb.OleDbType.Integer, 4, "MFGUserID"));
			// 
			// oleDbDataAdapterUserIsMFG
			// 
			this.oleDbDataAdapterUserIsMFG.SelectCommand = this.oleDbSelectCommand3;
			this.oleDbDataAdapterUserIsMFG.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												new System.Data.Common.DataTableMapping("Table", "Table", new System.Data.Common.DataColumnMapping[] {
																																																						 new System.Data.Common.DataColumnMapping("Num", "Num")})});
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = "SELECT COUNT(*) AS Num FROM SEC_MFGGroupMember WHERE (MFGUserID = ?)";
			this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("MFGUserID", System.Data.OleDb.OleDbType.Integer, 4, "MFGUserID"));
			// 
			// oleDbDataAdapterAllAdminEmp
			// 
			this.oleDbDataAdapterAllAdminEmp.SelectCommand = this.oleDbSelectCommand4;
			this.oleDbDataAdapterAllAdminEmp.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												  new System.Data.Common.DataTableMapping("Table", "SEC_MFGGroupMember", new System.Data.Common.DataColumnMapping[] {
																																																										new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																										new System.Data.Common.DataColumnMapping("Fullname", "Fullname")})});
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = "SELECT DISTINCT SEC_MFGGroupMember.ContactID, GEN_Contacts.Fullname FROM SEC_MFGG" +
				"roupMember INNER JOIN GEN_Contacts ON SEC_MFGGroupMember.ContactID = GEN_Contact" +
				"s.ContactID";
			this.oleDbSelectCommand4.Connection = this.oleDbConnection1;
			// 
			// oleDbDataAdapterAllMFGAdmins
			// 
			this.oleDbDataAdapterAllMFGAdmins.SelectCommand = this.oleDbSelectCommand5;
			this.oleDbDataAdapterAllMFGAdmins.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												   new System.Data.Common.DataTableMapping("Table", "SEC_MFGGroupMember", new System.Data.Common.DataColumnMapping[] {
																																																										 new System.Data.Common.DataColumnMapping("MFGUserID", "MFGUserID"),
																																																										 new System.Data.Common.DataColumnMapping("Fullname", "Fullname")})});
			// 
			// oleDbSelectCommand5
			// 
			this.oleDbSelectCommand5.CommandText = "SELECT DISTINCT SEC_MFGGroupMember.MFGUserID, GEN_Contacts.Fullname FROM SEC_MFGG" +
				"roupMember INNER JOIN GEN_Contacts ON SEC_MFGGroupMember.MFGUserID = GEN_Contact" +
				"s.UserID";
			this.oleDbSelectCommand5.Connection = this.oleDbConnection1;
			// 
			// oleDbDataAdapterUserIsMFGEmployee
			// 
			this.oleDbDataAdapterUserIsMFGEmployee.SelectCommand = this.oleDbSelectCommand6;
			this.oleDbDataAdapterUserIsMFGEmployee.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																														new System.Data.Common.DataTableMapping("Table", "Table", new System.Data.Common.DataColumnMapping[] {
																																																								 new System.Data.Common.DataColumnMapping("Expr1", "Expr1")})});
			// 
			// oleDbSelectCommand6
			// 
			this.oleDbSelectCommand6.CommandText = "SELECT COUNT(*) AS Expr1 FROM GEN_Contacts INNER JOIN SEC_MFGGroupMember ON GEN_C" +
				"ontacts.ContactID = SEC_MFGGroupMember.ContactID WHERE (GEN_Contacts.UserID = ?)" +
				"";
			this.oleDbSelectCommand6.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			// 
			// MFGGroupMemberData
			// 
			this.ComponentDataAdabter = this.oleDbDataAdapter1;
			this.ComponentDataSet = this.dsMFGGroupMember1;
			this.Connection = this.oleDbConnection1;
			((System.ComponentModel.ISupportInitialize)(this.dsMFGGroupMember1)).EndInit();

		}
		#endregion
	}
}
