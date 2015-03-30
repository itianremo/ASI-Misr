using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for EmailDataClass.
	/// </summary>
	public class EmailDataClass : TSN.ERP.Engine.BussinesComponent 
	{
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
		private TSN.ERP.SharedComponents.Data.dsEmail dsEmail1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterContactEmails;
		private System.Data.OleDb.OleDbConnection con1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbCommand1;
		private System.Data.OleDb.OleDbCommand oleDbCommand2;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterContactsAndEmails;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterAllContactsAndEmails;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EmailDataClass(System.ComponentModel.IContainer container)
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

		public EmailDataClass()
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
        //////////////////////protected override void Dispose( bool disposing )
        //////////////////////{
        //////////////////////    if( disposing )
        //////////////////////    {
        //////////////////////        if(components != null)
        //////////////////////        {
        //////////////////////            components.Dispose();
        //////////////////////        }
        //////////////////////    }
        //////////////////////    base.Dispose( disposing );
        //////////////////////}


		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.con1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dsEmail1 = new TSN.ERP.SharedComponents.Data.dsEmail();
			this.oleDbDataAdapterContactEmails = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterContactsAndEmails = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbDataAdapterAllContactsAndEmails = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsEmail1)).BeginInit();
			// 
			// con1
			// 
			this.con1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=""erp\erpsql2005"";Tag with column collation when possible=False;Initial Catalog=TestAccountability_Data;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=HAMDYAHMED;Use Encryption for Data=False";
			this.con1.InfoMessage += new System.Data.OleDb.OleDbInfoMessageEventHandler(this.oleDbConnection1_InfoMessage);
			// 
			// oleDbDataAdapter1
			// 
			this.oleDbDataAdapter1.DeleteCommand = this.oleDbCommand1;
			this.oleDbDataAdapter1.InsertCommand = this.oleDbCommand2;
			this.oleDbDataAdapter1.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "GEN_Emails", new System.Data.Common.DataColumnMapping[] {
																																																					  new System.Data.Common.DataColumnMapping("EmailID", "EmailID"),
																																																					  new System.Data.Common.DataColumnMapping("ContactEmail", "ContactEmail"),
																																																					  new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																					  new System.Data.Common.DataColumnMapping("EmailType", "EmailType")})});
			// 
			// oleDbCommand1
			// 
			this.oleDbCommand1.CommandText = "DELETE FROM GEN_Emails WHERE (EmailID = ?)";
			this.oleDbCommand1.Connection = this.con1;
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("EmailID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EmailID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbCommand2
			// 
			this.oleDbCommand2.CommandText = "INSERT INTO GEN_Emails (EmailID, ContactEmail, ContactID, EmailType) VALUES (?, ?" +
				", ?, ?)";
			this.oleDbCommand2.Connection = this.con1;
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("EmailID", System.Data.OleDb.OleDbType.Integer, 4, "EmailID"));
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactEmail", System.Data.OleDb.OleDbType.VarChar, 180, "ContactEmail"));
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("EmailType", System.Data.OleDb.OleDbType.Integer, 4, "EmailType"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT EmailID, ContactEmail, ContactID, EmailType FROM GEN_Emails";
			this.oleDbSelectCommand1.Connection = this.con1;
			// 
			// dsEmail1
			// 
			this.dsEmail1.DataSetName = "dsEmail";
			this.dsEmail1.EnforceConstraints = false;
			this.dsEmail1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbDataAdapterContactEmails
			// 
			this.oleDbDataAdapterContactEmails.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbDataAdapterContactEmails.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													new System.Data.Common.DataTableMapping("Table", "GEN_Emails", new System.Data.Common.DataColumnMapping[] {
																																																								  new System.Data.Common.DataColumnMapping("EmailID", "EmailID"),
																																																								  new System.Data.Common.DataColumnMapping("ContactEmail", "ContactEmail"),
																																																								  new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																								  new System.Data.Common.DataColumnMapping("EmailType", "EmailType")})});
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT EmailID, ContactEmail, ContactID, EmailType FROM GEN_Emails WHERE (Contact" +
				"ID = ?)";
			this.oleDbSelectCommand2.Connection = this.con1;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			// 
			// oleDbDataAdapterContactsAndEmails
			// 
			this.oleDbDataAdapterContactsAndEmails.SelectCommand = this.oleDbSelectCommand3;
			this.oleDbDataAdapterContactsAndEmails.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																														new System.Data.Common.DataTableMapping("Table", "GEN_Contacts", new System.Data.Common.DataColumnMapping[] {
																																																										new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																										new System.Data.Common.DataColumnMapping("Fullname", "Fullname"),
																																																										new System.Data.Common.DataColumnMapping("EmailID", "EmailID"),
																																																										new System.Data.Common.DataColumnMapping("ContactEmail", "ContactEmail"),
																																																										new System.Data.Common.DataColumnMapping("EmailType", "EmailType")})});
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = @"SELECT GEN_Contacts.ContactID, GEN_Contacts.Fullname, GEN_Emails.EmailID, GEN_Emails.ContactEmail, GEN_Emails.EmailType FROM GEN_Contacts INNER JOIN GEN_Emails ON GEN_Contacts.ContactID = GEN_Emails.ContactID WHERE (GEN_Emails.EmailType = ?) ORDER BY GEN_Contacts.Fullname";
			this.oleDbSelectCommand3.Connection = this.con1;
			this.oleDbSelectCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("EmailType", System.Data.OleDb.OleDbType.Integer, 4, "EmailType"));
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=mis;Tag with column collation when possible=False;Initial Catalog=TestAccountability_Data;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=HAMDYAHMED;Use Encryption for Data=False";
			// 
			// oleDbDataAdapterAllContactsAndEmails
			// 
			this.oleDbDataAdapterAllContactsAndEmails.SelectCommand = this.oleDbSelectCommand4;
			this.oleDbDataAdapterAllContactsAndEmails.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																														   new System.Data.Common.DataTableMapping("Table", "GEN_Contacts", new System.Data.Common.DataColumnMapping[] {
																																																										   new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																										   new System.Data.Common.DataColumnMapping("Fullname", "Fullname"),
																																																										   new System.Data.Common.DataColumnMapping("EmailID", "EmailID"),
																																																										   new System.Data.Common.DataColumnMapping("ContactEmail", "ContactEmail"),
																																																										   new System.Data.Common.DataColumnMapping("EmailType", "EmailType")})});
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = "SELECT GEN_Contacts.ContactID, GEN_Contacts.Fullname, GEN_Emails.EmailID, GEN_Ema" +
				"ils.ContactEmail, GEN_Emails.EmailType FROM GEN_Contacts INNER JOIN GEN_Emails O" +
				"N GEN_Contacts.ContactID = GEN_Emails.ContactID ORDER BY GEN_Contacts.Fullname";
			this.oleDbSelectCommand4.Connection = this.con1;
			// 
			// EmailDataClass
			// 
			this.ComponentDataAdabter = this.oleDbDataAdapter1;
			this.ComponentDataSet = this.dsEmail1;
			this.Connection = this.con1;
			((System.ComponentModel.ISupportInitialize)(this.dsEmail1)).EndInit();

		}
		#endregion

		public dsEmail GetContactEmails( int contactID )
		{
			try
			{
				dsEmail1.Clear();
				oleDbDataAdapterContactEmails.SelectCommand.Parameters[0].Value = contactID;
				oleDbDataAdapterContactEmails.Fill(dsEmail1);
				return dsEmail1;
			}
			catch(Exception ex)
			{
				string x = ex.Message;
				return dsEmail1;
			}
		}

		public System.Data.DataSet GetContactsAndEmails( int emailType )
		{
			try
			{
				System.Data.DataSet dsContactsAndEmails = new System.Data.DataSet();
				if(emailType == -1)//Will return all emails
				{					
					oleDbDataAdapterAllContactsAndEmails.Fill(dsContactsAndEmails);
					return dsContactsAndEmails;

				}
				else//Will return internal, external or private emails
				{										
					oleDbDataAdapterContactsAndEmails.SelectCommand.Parameters[0].Value = emailType;
					oleDbDataAdapterContactsAndEmails.Fill(dsContactsAndEmails);
					return dsContactsAndEmails;
			
				}
			}
			catch(Exception ex)
			{
				string x = ex.Message;
				return null;
			}
		}

		private void oleDbConnection1_InfoMessage(object sender, System.Data.OleDb.OleDbInfoMessageEventArgs e)
		{
		
		}
//		public dsEmail GetContactPrimaryEmail( int contactID )
//		{
//			dsEmail1.Clear();
//			oleDbDataAdapterContactPrimaryEmail.SelectCommand.Parameters[0].Value = contactID;
//			oleDbDataAdapterContactPrimaryEmail.Fill(dsEmail1);
//			return dsEmail1;
//		}
	}
}
