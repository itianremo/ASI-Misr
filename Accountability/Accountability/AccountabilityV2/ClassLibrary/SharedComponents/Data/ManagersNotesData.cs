using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for NotesData.
	/// </summary>
	public class ManagersNotesData : TSN.ERP.Engine.BussinesComponent 
	{
		private System.Data.OleDb.OleDbConnection con1;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter odaManagersNotes;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbCommand1;
		private System.Data.OleDb.OleDbCommand oleDbCommand2;
		private System.Data.OleDb.OleDbCommand oleDbCommand3;
		private TSN.ERP.SharedComponents.Data.dsManagersNotes dsManagersNotes1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ManagersNotesData(System.ComponentModel.IContainer container)
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

		public ManagersNotesData()
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
			this.con1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.odaManagersNotes = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
			this.dsManagersNotes1 = new TSN.ERP.SharedComponents.Data.dsManagersNotes();
			((System.ComponentModel.ISupportInitialize)(this.dsManagersNotes1)).BeginInit();
			// 
			// con1
			// 
			this.con1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=BASSAM;Tag with column collation when possible=False;Initial Catalog=ERPdb;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASSAM;Use Encryption for Data=False";
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=erp;Tag with column collation when possible=False;Initial Catalog=TestAccountability_data;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=HAMDYAHMED;Use Encryption for Data=False";
			// 
			// odaManagersNotes
			// 
			this.odaManagersNotes.DeleteCommand = this.oleDbCommand1;
			this.odaManagersNotes.InsertCommand = this.oleDbCommand2;
			this.odaManagersNotes.SelectCommand = this.oleDbSelectCommand1;
			this.odaManagersNotes.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "GEN_ManagerNotes", new System.Data.Common.DataColumnMapping[] {
																																																						   new System.Data.Common.DataColumnMapping("MNoteID", "MNoteID"),
																																																						   new System.Data.Common.DataColumnMapping("UserID", "UserID"),
																																																						   new System.Data.Common.DataColumnMapping("NoteBody", "NoteBody"),
																																																						   new System.Data.Common.DataColumnMapping("WeekStartDate", "WeekStartDate"),
																																																						   new System.Data.Common.DataColumnMapping("CreatedOn", "CreatedOn")})});
			this.odaManagersNotes.UpdateCommand = this.oleDbCommand3;
			// 
			// oleDbCommand1
			// 
			this.oleDbCommand1.CommandText = "DELETE FROM GEN_ManagerNotes WHERE (MNoteID = ?)";
			this.oleDbCommand1.Connection = this.con1;
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("MNoteID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MNoteID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbCommand2
			// 
			this.oleDbCommand2.CommandText = "INSERT INTO GEN_ManagerNotes (MNoteID, UserID, NoteBody, WeekStartDate, CreatedOn" +
				") VALUES (?, ?, ?, ?, ?)";
			this.oleDbCommand2.Connection = this.con1;
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("MNoteID", System.Data.OleDb.OleDbType.Integer, 4, "MNoteID"));
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("NoteBody", System.Data.OleDb.OleDbType.VarChar, 2147483647, "NoteBody"));
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("WeekStartDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "WeekStartDate"));
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CreatedOn", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "CreatedOn"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT MNoteID, UserID, NoteBody, WeekStartDate, CreatedOn FROM GEN_ManagerNotes";
			this.oleDbSelectCommand1.Connection = this.con1;
			// 
			// oleDbCommand3
			// 
			this.oleDbCommand3.CommandText = "UPDATE GEN_ManagerNotes SET  NoteBody = ? where UserID = ? and WeekStartDate = ? " +
				"and CreatedOn = ?";
			this.oleDbCommand3.Connection = this.con1;
			this.oleDbCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("NoteBody", System.Data.OleDb.OleDbType.VarChar, 2147483647, "NoteBody"));
			this.oleDbCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.oleDbCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WeekStartDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WeekStartDate", System.Data.DataRowVersion.Original, null));
			this.oleDbCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CreatedOn", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CreatedOn", System.Data.DataRowVersion.Original, null));
			// 
			// dsManagersNotes1
			// 
			this.dsManagersNotes1.DataSetName = "dsManagersNotes";
			this.dsManagersNotes1.EnforceConstraints = false;
			this.dsManagersNotes1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// ManagersNotesData
			// 
			this.ComponentDataAdabter = this.odaManagersNotes;
			this.ComponentDataSet = this.dsManagersNotes1;
			this.Connection = this.con1;
			((System.ComponentModel.ISupportInitialize)(this.dsManagersNotes1)).EndInit();

		}
		#endregion
//		protected override bool onDelete(System.Data.DataSet dsDeletedRecords)
//		{
//			return false;
//		}
//		public override int Edit(System.Data.DataSet dsModifiedRecords)
//		{
//			return  -1;
//		}
//		public bool AddNoteToContact(int ContID,int NoteID)
//		{
//			try
//			{
//				odcAddNotToContact.Parameters["ContactID"].Value= ContID;
//				odcAddNotToContact.Parameters["NoteID"].Value= NoteID;
//				odcAddNotToContact.ExecuteNonQuery();
//				return true;
//			}
//			catch (Exception ex)
//			{
//				ActiveSession.SetError(new ERP.Engine.ERPError(0,"Cannot Assgin Note to Contact" ,0,ex));
//				return false;
//			}
//		}
	}
}
