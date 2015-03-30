using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for NotesData.
	/// </summary>
	public class NotesData : TSN.ERP.Engine.BussinesComponent 
	{
		private System.Data.OleDb.OleDbDataAdapter odaNote;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbConnection con1;
		private TSN.ERP.SharedComponents.Data.dsNotes dsNotes1;
		private System.Data.OleDb.OleDbCommand odcAddNotToContact;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NotesData(System.ComponentModel.IContainer container)
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

		public NotesData()
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
			this.odaNote = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.con1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dsNotes1 = new TSN.ERP.SharedComponents.Data.dsNotes();
			this.odcAddNotToContact = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsNotes1)).BeginInit();
			// 
			// odaNote
			// 
			this.odaNote.DeleteCommand = this.oleDbDeleteCommand1;
			this.odaNote.InsertCommand = this.oleDbInsertCommand1;
			this.odaNote.SelectCommand = this.oleDbSelectCommand1;
			this.odaNote.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							  new System.Data.Common.DataTableMapping("Table", "GEN_Notes", new System.Data.Common.DataColumnMapping[] {
																																																		   new System.Data.Common.DataColumnMapping("NoteID", "NoteID"),
																																																		   new System.Data.Common.DataColumnMapping("UserID", "UserID"),
																																																		   new System.Data.Common.DataColumnMapping("NoteBody", "NoteBody"),
																																																		   new System.Data.Common.DataColumnMapping("NoteDate", "NoteDate")})});
			this.odaNote.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM GEN_Notes WHERE (NoteID = ?) AND (NoteDate = ?) AND (UserID = ? OR ? " +
				"IS NULL AND UserID IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.con1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_NoteID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "NoteID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_NoteDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "NoteDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			// 
			// con1
			// 
			this.con1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=BASSAM;Tag with column collation when possible=False;Initial Catalog=ERPdb;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASSAM;Use Encryption for Data=False";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO GEN_Notes(NoteID, UserID, NoteBody, NoteDate) VALUES (?, ?, ?, ?); SE" +
				"LECT NoteID, UserID, NoteBody, NoteDate FROM GEN_Notes WHERE (NoteID = ?)";
			this.oleDbInsertCommand1.Connection = this.con1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("NoteID", System.Data.OleDb.OleDbType.Integer, 4, "NoteID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("NoteBody", System.Data.OleDb.OleDbType.VarChar, 2147483647, "NoteBody"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("NoteDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "NoteDate"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_NoteID", System.Data.OleDb.OleDbType.Integer, 4, "NoteID"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT NoteID, UserID, NoteBody, NoteDate FROM GEN_Notes";
			this.oleDbSelectCommand1.Connection = this.con1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE GEN_Notes SET NoteID = ?, UserID = ?, NoteBody = ?, NoteDate = ? WHERE (No" +
				"teID = ?) AND (NoteDate = ?) AND (UserID = ? OR ? IS NULL AND UserID IS NULL); S" +
				"ELECT NoteID, UserID, NoteBody, NoteDate FROM GEN_Notes WHERE (NoteID = ?)";
			this.oleDbUpdateCommand1.Connection = this.con1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("NoteID", System.Data.OleDb.OleDbType.Integer, 4, "NoteID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("NoteBody", System.Data.OleDb.OleDbType.VarChar, 2147483647, "NoteBody"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("NoteDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "NoteDate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_NoteID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "NoteID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_NoteDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "NoteDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_NoteID", System.Data.OleDb.OleDbType.Integer, 4, "NoteID"));
			// 
			// dsNotes1
			// 
			this.dsNotes1.DataSetName = "dsNotes";
			this.dsNotes1.EnforceConstraints = false;
			this.dsNotes1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// odcAddNotToContact
			// 
			this.odcAddNotToContact.CommandText = "INSERT INTO GEN_ContactNotes (NoteID, ContactID) VALUES (?, ?)";
			this.odcAddNotToContact.Connection = this.con1;
			this.odcAddNotToContact.Parameters.Add(new System.Data.OleDb.OleDbParameter("NoteID", System.Data.OleDb.OleDbType.Integer, 4, "NoteID"));
			this.odcAddNotToContact.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			// 
			// NotesData
			// 
			this.ComponentDataAdabter = this.odaNote;
			this.ComponentDataSet = this.dsNotes1;
			this.Connection = this.con1;
			((System.ComponentModel.ISupportInitialize)(this.dsNotes1)).EndInit();

		}
		#endregion
		protected override bool onDelete(System.Data.DataSet dsDeletedRecords)
		{
			return false;
		}
		public override int Edit(System.Data.DataSet dsModifiedRecords)
		{
			return  -1;
		}
		public bool AddNoteToContact(int ContID,int NoteID)
		{
			try
			{
				odcAddNotToContact.Parameters["ContactID"].Value= ContID;
				odcAddNotToContact.Parameters["NoteID"].Value= NoteID;
				odcAddNotToContact.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{
				ActiveSession.SetError(new ERP.Engine.ERPError(0,"Cannot Assgin Note to Contact" ,0,ex));
				return false;
			}
		}
	}
}
