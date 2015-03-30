using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for PhonebookDataClass.
	/// </summary>
	public class PhonebookDataClass : TSN.ERP.Engine.BussinesComponent 
	{
		private System.Data.OleDb.OleDbDataAdapter odaPhoneBook;
		private System.Data.OleDb.OleDbConnection con1;
		private System.Data.OleDb.OleDbDataAdapter odaContactPhones;
		private TSN.ERP.SharedComponents.Data.dsPhonebook dsPhoneBook1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterPrimaryPhone;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PhonebookDataClass(System.ComponentModel.IContainer container)
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

		public PhonebookDataClass()
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
			this.odaPhoneBook = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.con1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dsPhoneBook1 = new TSN.ERP.SharedComponents.Data.dsPhonebook();
			this.odaContactPhones = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterPrimaryPhone = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsPhoneBook1)).BeginInit();
			// 
			// odaPhoneBook
			// 
			this.odaPhoneBook.DeleteCommand = this.oleDbDeleteCommand3;
			this.odaPhoneBook.InsertCommand = this.oleDbInsertCommand3;
			this.odaPhoneBook.SelectCommand = this.oleDbSelectCommand4;
			this.odaPhoneBook.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								   new System.Data.Common.DataTableMapping("Table", "GEN_Phonebook", new System.Data.Common.DataColumnMapping[] {
																																																					new System.Data.Common.DataColumnMapping("PhoneBookID", "PhoneBookID"),
																																																					new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																					new System.Data.Common.DataColumnMapping("AreaCode", "AreaCode"),
																																																					new System.Data.Common.DataColumnMapping("CountryCode", "CountryCode"),
																																																					new System.Data.Common.DataColumnMapping("PhoneZone", "PhoneZone"),
																																																					new System.Data.Common.DataColumnMapping("PhoneNumber", "PhoneNumber"),
																																																					new System.Data.Common.DataColumnMapping("PhoneType", "PhoneType"),
																																																					new System.Data.Common.DataColumnMapping("PrimaryPhoneBook", "PrimaryPhoneBook")})});
			this.odaPhoneBook.UpdateCommand = this.oleDbUpdateCommand3;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = @"DELETE FROM GEN_Phonebook WHERE (PhoneBookID = ?) AND (AreaCode = ? OR ? IS NULL AND AreaCode IS NULL) AND (ContactID = ? OR ? IS NULL AND ContactID IS NULL) AND (CountryCode = ? OR ? IS NULL AND CountryCode IS NULL) AND (PhoneNumber = ?) AND (PhoneType = ?) AND (PhoneZone = ? OR ? IS NULL AND PhoneZone IS NULL) AND (PrimaryPhoneBook = ? OR ? IS NULL AND PrimaryPhoneBook IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.con1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneBookID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneBookID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AreaCode", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AreaCode", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AreaCode1", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AreaCode", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CountryCode", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CountryCode", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CountryCode1", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CountryCode", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneNumber", System.Data.OleDb.OleDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneType", System.Data.OleDb.OleDbType.VarChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneType", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneZone", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneZone", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneZone1", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneZone", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PrimaryPhoneBook", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PrimaryPhoneBook", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PrimaryPhoneBook1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PrimaryPhoneBook", System.Data.DataRowVersion.Original, null));
			// 
			// con1
			// 
			this.con1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=BASSAM;Tag with column collation when possible=False;Initial Catalog=ERPdb;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASSAM;Use Encryption for Data=False";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = @"INSERT INTO GEN_Phonebook(PhoneBookID, ContactID, AreaCode, CountryCode, PhoneZone, PhoneNumber, PhoneType, PrimaryPhoneBook) VALUES (?, ?, ?, ?, ?, ?, ?, ?); SELECT PhoneBookID, ContactID, AreaCode, CountryCode, PhoneZone, PhoneNumber, PhoneType, PrimaryPhoneBook FROM GEN_Phonebook WHERE (PhoneBookID = ?)";
			this.oleDbInsertCommand1.Connection = this.con1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PhoneBookID", System.Data.OleDb.OleDbType.Integer, 4, "PhoneBookID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AreaCode", System.Data.OleDb.OleDbType.VarChar, 4, "AreaCode"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CountryCode", System.Data.OleDb.OleDbType.VarChar, 4, "CountryCode"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PhoneZone", System.Data.OleDb.OleDbType.VarChar, 4, "PhoneZone"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PhoneNumber", System.Data.OleDb.OleDbType.VarChar, 12, "PhoneNumber"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PhoneType", System.Data.OleDb.OleDbType.VarChar, 1, "PhoneType"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PrimaryPhoneBook", System.Data.OleDb.OleDbType.Boolean, 1, "PrimaryPhoneBook"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_PhoneBookID", System.Data.OleDb.OleDbType.Integer, 4, "PhoneBookID"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT PhoneBookID, ContactID, AreaCode, CountryCode, PhoneZone, PhoneNumber, Pho" +
				"neType, PrimaryPhoneBook FROM GEN_Phonebook";
			this.oleDbSelectCommand1.Connection = this.con1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE GEN_Phonebook SET PhoneBookID = ?, ContactID = ?, AreaCode = ?, CountryCode = ?, PhoneZone = ?, PhoneNumber = ?, PhoneType = ?, PrimaryPhoneBook = ? WHERE (PhoneBookID = ?) AND (AreaCode = ? OR ? IS NULL AND AreaCode IS NULL) AND (ContactID = ? OR ? IS NULL AND ContactID IS NULL) AND (CountryCode = ? OR ? IS NULL AND CountryCode IS NULL) AND (PhoneNumber = ?) AND (PhoneType = ?) AND (PhoneZone = ? OR ? IS NULL AND PhoneZone IS NULL) AND (PrimaryPhoneBook = ? OR ? IS NULL AND PrimaryPhoneBook IS NULL); SELECT PhoneBookID, ContactID, AreaCode, CountryCode, PhoneZone, PhoneNumber, PhoneType, PrimaryPhoneBook FROM GEN_Phonebook WHERE (PhoneBookID = ?)";
			this.oleDbUpdateCommand1.Connection = this.con1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PhoneBookID", System.Data.OleDb.OleDbType.Integer, 4, "PhoneBookID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AreaCode", System.Data.OleDb.OleDbType.VarChar, 4, "AreaCode"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CountryCode", System.Data.OleDb.OleDbType.VarChar, 4, "CountryCode"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PhoneZone", System.Data.OleDb.OleDbType.VarChar, 4, "PhoneZone"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PhoneNumber", System.Data.OleDb.OleDbType.VarChar, 12, "PhoneNumber"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PhoneType", System.Data.OleDb.OleDbType.VarChar, 1, "PhoneType"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PrimaryPhoneBook", System.Data.OleDb.OleDbType.Boolean, 1, "PrimaryPhoneBook"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneBookID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneBookID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AreaCode", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AreaCode", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AreaCode1", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AreaCode", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CountryCode", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CountryCode", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CountryCode1", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CountryCode", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneNumber", System.Data.OleDb.OleDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneType", System.Data.OleDb.OleDbType.VarChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneType", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneZone", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneZone", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneZone1", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneZone", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PrimaryPhoneBook", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PrimaryPhoneBook", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PrimaryPhoneBook1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PrimaryPhoneBook", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_PhoneBookID", System.Data.OleDb.OleDbType.Integer, 4, "PhoneBookID"));
			// 
			// dsPhoneBook1
			// 
			this.dsPhoneBook1.DataSetName = "dsPhonebook";
			this.dsPhoneBook1.EnforceConstraints = false;
			this.dsPhoneBook1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// odaContactPhones
			// 
			this.odaContactPhones.SelectCommand = this.oleDbSelectCommand2;
			this.odaContactPhones.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "GEN_Phonebook", new System.Data.Common.DataColumnMapping[] {
																																																						new System.Data.Common.DataColumnMapping("PhoneBookID", "PhoneBookID"),
																																																						new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																						new System.Data.Common.DataColumnMapping("AreaCode", "AreaCode"),
																																																						new System.Data.Common.DataColumnMapping("CountryCode", "CountryCode"),
																																																						new System.Data.Common.DataColumnMapping("PhoneZone", "PhoneZone"),
																																																						new System.Data.Common.DataColumnMapping("PhoneNumber", "PhoneNumber"),
																																																						new System.Data.Common.DataColumnMapping("PhoneType", "PhoneType"),
																																																						new System.Data.Common.DataColumnMapping("PrimaryPhoneBook", "PrimaryPhoneBook")})});
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT PhoneBookID, ContactID, AreaCode, CountryCode, PhoneZone, PhoneNumber, Pho" +
				"neType, PrimaryPhoneBook FROM GEN_Phonebook WHERE (ContactID = ?)";
			this.oleDbSelectCommand2.Connection = this.con1;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			// 
			// oleDbDataAdapterPrimaryPhone
			// 
			this.oleDbDataAdapterPrimaryPhone.DeleteCommand = this.oleDbDeleteCommand2;
			this.oleDbDataAdapterPrimaryPhone.InsertCommand = this.oleDbInsertCommand2;
			this.oleDbDataAdapterPrimaryPhone.SelectCommand = this.oleDbSelectCommand3;
			this.oleDbDataAdapterPrimaryPhone.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												   new System.Data.Common.DataTableMapping("Table", "GEN_Phonebook", new System.Data.Common.DataColumnMapping[] {
																																																									new System.Data.Common.DataColumnMapping("PhoneBookID", "PhoneBookID"),
																																																									new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																									new System.Data.Common.DataColumnMapping("AreaCode", "AreaCode"),
																																																									new System.Data.Common.DataColumnMapping("CountryCode", "CountryCode"),
																																																									new System.Data.Common.DataColumnMapping("PhoneZone", "PhoneZone"),
																																																									new System.Data.Common.DataColumnMapping("PhoneNumber", "PhoneNumber"),
																																																									new System.Data.Common.DataColumnMapping("PhoneType", "PhoneType"),
																																																									new System.Data.Common.DataColumnMapping("PrimaryPhoneBook", "PrimaryPhoneBook")})});
			this.oleDbDataAdapterPrimaryPhone.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = @"DELETE FROM GEN_Phonebook WHERE (PhoneBookID = ?) AND (AreaCode = ? OR ? IS NULL AND AreaCode IS NULL) AND (ContactID = ? OR ? IS NULL AND ContactID IS NULL) AND (CountryCode = ? OR ? IS NULL AND CountryCode IS NULL) AND (PhoneNumber = ?) AND (PhoneType = ?) AND (PhoneZone = ? OR ? IS NULL AND PhoneZone IS NULL) AND (PrimaryPhoneBook = ? OR ? IS NULL AND PrimaryPhoneBook IS NULL)";
			this.oleDbDeleteCommand2.Connection = this.con1;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneBookID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneBookID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AreaCode", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AreaCode", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AreaCode1", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AreaCode", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CountryCode", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CountryCode", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CountryCode1", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CountryCode", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneNumber", System.Data.OleDb.OleDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneType", System.Data.OleDb.OleDbType.VarChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneType", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneZone", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneZone", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneZone1", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneZone", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PrimaryPhoneBook", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PrimaryPhoneBook", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PrimaryPhoneBook1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PrimaryPhoneBook", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = @"INSERT INTO GEN_Phonebook(PhoneBookID, ContactID, AreaCode, CountryCode, PhoneZone, PhoneNumber, PhoneType, PrimaryPhoneBook) VALUES (?, ?, ?, ?, ?, ?, ?, ?); SELECT PhoneBookID, ContactID, AreaCode, CountryCode, PhoneZone, PhoneNumber, PhoneType, PrimaryPhoneBook FROM GEN_Phonebook WHERE (PhoneBookID = ?)";
			this.oleDbInsertCommand2.Connection = this.con1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("PhoneBookID", System.Data.OleDb.OleDbType.Integer, 4, "PhoneBookID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AreaCode", System.Data.OleDb.OleDbType.VarChar, 4, "AreaCode"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CountryCode", System.Data.OleDb.OleDbType.VarChar, 4, "CountryCode"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("PhoneZone", System.Data.OleDb.OleDbType.VarChar, 4, "PhoneZone"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("PhoneNumber", System.Data.OleDb.OleDbType.VarChar, 12, "PhoneNumber"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("PhoneType", System.Data.OleDb.OleDbType.VarChar, 1, "PhoneType"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("PrimaryPhoneBook", System.Data.OleDb.OleDbType.Boolean, 1, "PrimaryPhoneBook"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_PhoneBookID", System.Data.OleDb.OleDbType.Integer, 4, "PhoneBookID"));
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = "SELECT PhoneBookID, ContactID, AreaCode, CountryCode, PhoneZone, PhoneNumber, Pho" +
				"neType, PrimaryPhoneBook FROM GEN_Phonebook WHERE (ContactID = ?) AND (PrimaryPh" +
				"oneBook = 1)";
			this.oleDbSelectCommand3.Connection = this.con1;
			this.oleDbSelectCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = @"UPDATE GEN_Phonebook SET PhoneBookID = ?, ContactID = ?, AreaCode = ?, CountryCode = ?, PhoneZone = ?, PhoneNumber = ?, PhoneType = ?, PrimaryPhoneBook = ? WHERE (PhoneBookID = ?) AND (AreaCode = ? OR ? IS NULL AND AreaCode IS NULL) AND (ContactID = ? OR ? IS NULL AND ContactID IS NULL) AND (CountryCode = ? OR ? IS NULL AND CountryCode IS NULL) AND (PhoneNumber = ?) AND (PhoneType = ?) AND (PhoneZone = ? OR ? IS NULL AND PhoneZone IS NULL) AND (PrimaryPhoneBook = ? OR ? IS NULL AND PrimaryPhoneBook IS NULL); SELECT PhoneBookID, ContactID, AreaCode, CountryCode, PhoneZone, PhoneNumber, PhoneType, PrimaryPhoneBook FROM GEN_Phonebook WHERE (PhoneBookID = ?)";
			this.oleDbUpdateCommand2.Connection = this.con1;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("PhoneBookID", System.Data.OleDb.OleDbType.Integer, 4, "PhoneBookID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AreaCode", System.Data.OleDb.OleDbType.VarChar, 4, "AreaCode"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CountryCode", System.Data.OleDb.OleDbType.VarChar, 4, "CountryCode"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("PhoneZone", System.Data.OleDb.OleDbType.VarChar, 4, "PhoneZone"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("PhoneNumber", System.Data.OleDb.OleDbType.VarChar, 12, "PhoneNumber"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("PhoneType", System.Data.OleDb.OleDbType.VarChar, 1, "PhoneType"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("PrimaryPhoneBook", System.Data.OleDb.OleDbType.Boolean, 1, "PrimaryPhoneBook"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneBookID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneBookID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AreaCode", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AreaCode", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AreaCode1", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AreaCode", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CountryCode", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CountryCode", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CountryCode1", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CountryCode", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneNumber", System.Data.OleDb.OleDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneType", System.Data.OleDb.OleDbType.VarChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneType", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneZone", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneZone", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneZone1", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneZone", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PrimaryPhoneBook", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PrimaryPhoneBook", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PrimaryPhoneBook1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PrimaryPhoneBook", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_PhoneBookID", System.Data.OleDb.OleDbType.Integer, 4, "PhoneBookID"));
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = "SELECT PhoneBookID, ContactID, AreaCode, CountryCode, PhoneZone, PhoneNumber, Pho" +
				"neType, PrimaryPhoneBook FROM GEN_Phonebook";
			this.oleDbSelectCommand4.Connection = this.con1;
			// 
			// oleDbInsertCommand3
			// 
			this.oleDbInsertCommand3.CommandText = @"INSERT INTO GEN_Phonebook(PhoneBookID, ContactID, AreaCode, CountryCode, PhoneZone, PhoneNumber, PhoneType, PrimaryPhoneBook) VALUES (?, ?, ?, ?, ?, ?, ?, ?); SELECT PhoneBookID, ContactID, AreaCode, CountryCode, PhoneZone, PhoneNumber, PhoneType, PrimaryPhoneBook FROM GEN_Phonebook WHERE (PhoneBookID = ?)";
			this.oleDbInsertCommand3.Connection = this.con1;
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("PhoneBookID", System.Data.OleDb.OleDbType.Integer, 4, "PhoneBookID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AreaCode", System.Data.OleDb.OleDbType.VarChar, 4, "AreaCode"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("CountryCode", System.Data.OleDb.OleDbType.VarChar, 4, "CountryCode"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("PhoneZone", System.Data.OleDb.OleDbType.VarChar, 4, "PhoneZone"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("PhoneNumber", System.Data.OleDb.OleDbType.VarChar, 12, "PhoneNumber"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("PhoneType", System.Data.OleDb.OleDbType.VarChar, 1, "PhoneType"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("PrimaryPhoneBook", System.Data.OleDb.OleDbType.Boolean, 1, "PrimaryPhoneBook"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_PhoneBookID", System.Data.OleDb.OleDbType.Integer, 4, "PhoneBookID"));
			// 
			// oleDbUpdateCommand3
			// 
			this.oleDbUpdateCommand3.CommandText = @"UPDATE GEN_Phonebook SET PhoneBookID = ?, ContactID = ?, AreaCode = ?, CountryCode = ?, PhoneZone = ?, PhoneNumber = ?, PhoneType = ?, PrimaryPhoneBook = ? WHERE (PhoneBookID = ?) AND (AreaCode = ? OR ? IS NULL AND AreaCode IS NULL) AND (ContactID = ? OR ? IS NULL AND ContactID IS NULL) AND (CountryCode = ? OR ? IS NULL AND CountryCode IS NULL) AND (PhoneNumber = ?) AND (PhoneType = ?) AND (PhoneZone = ? OR ? IS NULL AND PhoneZone IS NULL) AND (PrimaryPhoneBook = ? OR ? IS NULL AND PrimaryPhoneBook IS NULL); SELECT PhoneBookID, ContactID, AreaCode, CountryCode, PhoneZone, PhoneNumber, PhoneType, PrimaryPhoneBook FROM GEN_Phonebook WHERE (PhoneBookID = ?)";
			this.oleDbUpdateCommand3.Connection = this.con1;
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("PhoneBookID", System.Data.OleDb.OleDbType.Integer, 4, "PhoneBookID"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("AreaCode", System.Data.OleDb.OleDbType.VarChar, 4, "AreaCode"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("CountryCode", System.Data.OleDb.OleDbType.VarChar, 4, "CountryCode"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("PhoneZone", System.Data.OleDb.OleDbType.VarChar, 4, "PhoneZone"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("PhoneNumber", System.Data.OleDb.OleDbType.VarChar, 12, "PhoneNumber"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("PhoneType", System.Data.OleDb.OleDbType.VarChar, 1, "PhoneType"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("PrimaryPhoneBook", System.Data.OleDb.OleDbType.Boolean, 1, "PrimaryPhoneBook"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneBookID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneBookID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AreaCode", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AreaCode", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AreaCode1", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AreaCode", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CountryCode", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CountryCode", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CountryCode1", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CountryCode", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneNumber", System.Data.OleDb.OleDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneType", System.Data.OleDb.OleDbType.VarChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneType", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneZone", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneZone", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneZone1", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneZone", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PrimaryPhoneBook", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PrimaryPhoneBook", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PrimaryPhoneBook1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PrimaryPhoneBook", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_PhoneBookID", System.Data.OleDb.OleDbType.Integer, 4, "PhoneBookID"));
			// 
			// oleDbDeleteCommand3
			// 
			this.oleDbDeleteCommand3.CommandText = @"DELETE FROM GEN_Phonebook WHERE (PhoneBookID = ?) AND (AreaCode = ? OR ? IS NULL AND AreaCode IS NULL) AND (ContactID = ? OR ? IS NULL AND ContactID IS NULL) AND (CountryCode = ? OR ? IS NULL AND CountryCode IS NULL) AND (PhoneNumber = ?) AND (PhoneType = ?) AND (PhoneZone = ? OR ? IS NULL AND PhoneZone IS NULL) AND (PrimaryPhoneBook = ? OR ? IS NULL AND PrimaryPhoneBook IS NULL)";
			this.oleDbDeleteCommand3.Connection = this.con1;
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneBookID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneBookID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AreaCode", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AreaCode", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AreaCode1", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AreaCode", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CountryCode", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CountryCode", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CountryCode1", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CountryCode", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneNumber", System.Data.OleDb.OleDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneType", System.Data.OleDb.OleDbType.VarChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneType", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneZone", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneZone", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PhoneZone1", System.Data.OleDb.OleDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PhoneZone", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PrimaryPhoneBook", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PrimaryPhoneBook", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_PrimaryPhoneBook1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PrimaryPhoneBook", System.Data.DataRowVersion.Original, null));
			// 
			// PhonebookDataClass
			// 
			this.ComponentDataAdabter = this.odaPhoneBook;
			this.ComponentDataSet = this.dsPhoneBook1;
			this.Connection = this.con1;
			((System.ComponentModel.ISupportInitialize)(this.dsPhoneBook1)).EndInit();

		}
		#endregion
		public DataSet ContactPhones(int ContactID)
		{
			dsPhoneBook1.Clear();
			odaContactPhones.SelectCommand.Parameters[0].Value = ContactID;
			odaContactPhones.Fill(dsPhoneBook1);
			return dsPhoneBook1;
		}

		public DataSet PrimaryContactPhones(int ContactID)
		{
			dsPhoneBook1.Clear();
			oleDbDataAdapterPrimaryPhone.SelectCommand.Parameters[0].Value = ContactID;
			oleDbDataAdapterPrimaryPhone.Fill(dsPhoneBook1);
			return dsPhoneBook1;
		}
	}
}
