using System;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Diagnostics;
using TSN.ERP.Engine;
namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for ContactsData.
	/// </summary>
	public class ContactsData : BussinesComponent 
	{
		private System.Data.OleDb.OleDbDataAdapter odaContacts;
		private System.Data.OleDb.OleDbConnection con1;
		private TSN.ERP.SharedComponents.Data.dsContacts dsContacts1;
		private System.Data.OleDb.OleDbDataAdapter odaListContactData;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterUpdateContactUsrID;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ContactsData(System.ComponentModel.IContainer container)
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

		public ContactsData()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactsData));
            this.odaContacts = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.con1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.dsContacts1 = new TSN.ERP.SharedComponents.Data.dsContacts();
            this.odaListContactData = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDataAdapterUpdateContactUsrID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsContacts1)).BeginInit();
            // 
            // odaContacts
            // 
            this.odaContacts.DeleteCommand = this.oleDbDeleteCommand1;
            this.odaContacts.InsertCommand = this.oleDbInsertCommand1;
            this.odaContacts.SelectCommand = this.oleDbSelectCommand1;
            this.odaContacts.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GEN_Contacts", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
                        new System.Data.Common.DataColumnMapping("ContTypeID", "ContTypeID"),
                        new System.Data.Common.DataColumnMapping("UserID", "UserID"),
                        new System.Data.Common.DataColumnMapping("FirstName", "FirstName"),
                        new System.Data.Common.DataColumnMapping("MiddleName", "MiddleName"),
                        new System.Data.Common.DataColumnMapping("LastName", "LastName"),
                        new System.Data.Common.DataColumnMapping("Fullname", "Fullname")})});
            this.odaContacts.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = resources.GetString("oleDbDeleteCommand1.CommandText");
            this.oleDbDeleteCommand1.Connection = this.con1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContTypeID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContTypeID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContTypeID", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContTypeID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_UserID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "UserID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "UserID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FirstName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FirstName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FirstName", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FirstName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MiddleName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MiddleName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MiddleName", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MiddleName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_LastName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "LastName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_LastName", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LastName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Fullname", System.Data.OleDb.OleDbType.Char, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Fullname", System.Data.DataRowVersion.Original, null)});
            // 
            // con1
            // 
            this.con1.ConnectionString = "Provider=SQLNCLI.1;Data Source=MISSERVER;User ID=RW;Initial Catalog=TestAccountab" +
                "ility_Data";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [GEN_Contacts] ([ContactID], [ContTypeID], [UserID], [FirstName], [Mi" +
                "ddleName], [LastName], [Fullname]) VALUES (?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.con1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 0, "ContactID"),
            new System.Data.OleDb.OleDbParameter("ContTypeID", System.Data.OleDb.OleDbType.SmallInt, 0, "ContTypeID"),
            new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 0, "UserID"),
            new System.Data.OleDb.OleDbParameter("FirstName", System.Data.OleDb.OleDbType.VarChar, 0, "FirstName"),
            new System.Data.OleDb.OleDbParameter("MiddleName", System.Data.OleDb.OleDbType.VarChar, 0, "MiddleName"),
            new System.Data.OleDb.OleDbParameter("LastName", System.Data.OleDb.OleDbType.VarChar, 0, "LastName"),
            new System.Data.OleDb.OleDbParameter("Fullname", System.Data.OleDb.OleDbType.Char, 0, "Fullname")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT ContactID, ContTypeID, UserID, FirstName, MiddleName, LastName, Fullname F" +
                "ROM GEN_Contacts ORDER BY Fullname";
            this.oleDbSelectCommand1.Connection = this.con1;
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.con1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 0, "ContactID"),
            new System.Data.OleDb.OleDbParameter("ContTypeID", System.Data.OleDb.OleDbType.SmallInt, 0, "ContTypeID"),
            new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 0, "UserID"),
            new System.Data.OleDb.OleDbParameter("FirstName", System.Data.OleDb.OleDbType.VarChar, 0, "FirstName"),
            new System.Data.OleDb.OleDbParameter("MiddleName", System.Data.OleDb.OleDbType.VarChar, 0, "MiddleName"),
            new System.Data.OleDb.OleDbParameter("LastName", System.Data.OleDb.OleDbType.VarChar, 0, "LastName"),
            new System.Data.OleDb.OleDbParameter("Fullname", System.Data.OleDb.OleDbType.Char, 0, "Fullname"),
            new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContTypeID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContTypeID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContTypeID", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContTypeID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_UserID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "UserID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "UserID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FirstName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FirstName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FirstName", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FirstName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MiddleName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MiddleName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MiddleName", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MiddleName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_LastName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "LastName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_LastName", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LastName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Fullname", System.Data.OleDb.OleDbType.Char, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Fullname", System.Data.DataRowVersion.Original, null)});
            // 
            // dsContacts1
            // 
            this.dsContacts1.DataSetName = "dsContacts";
            this.dsContacts1.EnforceConstraints = false;
            this.dsContacts1.Locale = new System.Globalization.CultureInfo("ar-EG");
            this.dsContacts1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // odaListContactData
            // 
            this.odaListContactData.DeleteCommand = this.oleDbDeleteCommand2;
            this.odaListContactData.InsertCommand = this.oleDbInsertCommand2;
            this.odaListContactData.SelectCommand = this.oleDbSelectCommand2;
            this.odaListContactData.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GEN_Contacts", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
                        new System.Data.Common.DataColumnMapping("ContTypeID", "ContTypeID"),
                        new System.Data.Common.DataColumnMapping("UserID", "UserID"),
                        new System.Data.Common.DataColumnMapping("FirstName", "FirstName"),
                        new System.Data.Common.DataColumnMapping("LastName", "LastName"),
                        new System.Data.Common.DataColumnMapping("Fullname", "Fullname"),
                        new System.Data.Common.DataColumnMapping("MiddleName", "MiddleName")})});
            this.odaListContactData.UpdateCommand = this.oleDbUpdateCommand2;
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = resources.GetString("oleDbDeleteCommand2.CommandText");
            this.oleDbDeleteCommand2.Connection = this.con1;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ContTypeID", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContTypeID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ContTypeID1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContTypeID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_FirstName", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FirstName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_FirstName1", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FirstName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Fullname", System.Data.OleDb.OleDbType.VarChar, 160, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Fullname", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_LastName", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LastName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_LastName1", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LastName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_MiddleName", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MiddleName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_MiddleName1", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MiddleName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "UserID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_UserID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "UserID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = resources.GetString("oleDbInsertCommand2.CommandText");
            this.oleDbInsertCommand2.Connection = this.con1;
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"),
            new System.Data.OleDb.OleDbParameter("ContTypeID", System.Data.OleDb.OleDbType.SmallInt, 2, "ContTypeID"),
            new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"),
            new System.Data.OleDb.OleDbParameter("FirstName", System.Data.OleDb.OleDbType.VarChar, 120, "FirstName"),
            new System.Data.OleDb.OleDbParameter("LastName", System.Data.OleDb.OleDbType.VarChar, 120, "LastName"),
            new System.Data.OleDb.OleDbParameter("Fullname", System.Data.OleDb.OleDbType.VarChar, 160, "Fullname"),
            new System.Data.OleDb.OleDbParameter("MiddleName", System.Data.OleDb.OleDbType.VarChar, 120, "MiddleName"),
            new System.Data.OleDb.OleDbParameter("Select_ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID")});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = "SELECT ContactID, ContTypeID, UserID, FirstName, LastName, Fullname, MiddleName F" +
                "ROM GEN_Contacts WHERE (ContactID = ?)";
            this.oleDbSelectCommand2.Connection = this.con1;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID")});
            // 
            // oleDbUpdateCommand2
            // 
            this.oleDbUpdateCommand2.CommandText = resources.GetString("oleDbUpdateCommand2.CommandText");
            this.oleDbUpdateCommand2.Connection = this.con1;
            this.oleDbUpdateCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"),
            new System.Data.OleDb.OleDbParameter("ContTypeID", System.Data.OleDb.OleDbType.SmallInt, 2, "ContTypeID"),
            new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"),
            new System.Data.OleDb.OleDbParameter("FirstName", System.Data.OleDb.OleDbType.VarChar, 120, "FirstName"),
            new System.Data.OleDb.OleDbParameter("LastName", System.Data.OleDb.OleDbType.VarChar, 120, "LastName"),
            new System.Data.OleDb.OleDbParameter("Fullname", System.Data.OleDb.OleDbType.VarChar, 160, "Fullname"),
            new System.Data.OleDb.OleDbParameter("MiddleName", System.Data.OleDb.OleDbType.VarChar, 120, "MiddleName"),
            new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ContTypeID", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContTypeID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ContTypeID1", System.Data.OleDb.OleDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContTypeID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_FirstName", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FirstName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_FirstName1", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FirstName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Fullname", System.Data.OleDb.OleDbType.VarChar, 160, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Fullname", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_LastName", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LastName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_LastName1", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LastName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_MiddleName", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MiddleName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_MiddleName1", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MiddleName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "UserID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_UserID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "UserID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Select_ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID")});
            // 
            // oleDbDataAdapterUpdateContactUsrID
            // 
            this.oleDbDataAdapterUpdateContactUsrID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GEN_Contacts", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
                        new System.Data.Common.DataColumnMapping("ContTypeID", "ContTypeID"),
                        new System.Data.Common.DataColumnMapping("UserID", "UserID"),
                        new System.Data.Common.DataColumnMapping("FirstName", "FirstName"),
                        new System.Data.Common.DataColumnMapping("MiddleName", "MiddleName"),
                        new System.Data.Common.DataColumnMapping("LastName", "LastName"),
                        new System.Data.Common.DataColumnMapping("Fullname", "Fullname")})});
            this.oleDbDataAdapterUpdateContactUsrID.UpdateCommand = this.oleDbUpdateCommand3;
            // 
            // oleDbUpdateCommand3
            // 
            this.oleDbUpdateCommand3.CommandText = "UPDATE GEN_Contacts SET UserID = ? WHERE (ContactID = ?)";
            this.oleDbUpdateCommand3.Connection = this.con1;
            this.oleDbUpdateCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"),
            new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null)});
            // 
            // ContactsData
            // 
            this.ComponentDataAdabter = this.odaContacts;
            this.ComponentDataSet = this.dsContacts1;
            this.Connection = this.con1;
            ((System.ComponentModel.ISupportInitialize)(this.dsContacts1)).EndInit();

		}
		#endregion
		public DataSet ListContactData(int ContactID)
		{
			this.dsContacts1.Clear();
			this.odaListContactData.SelectCommand.Parameters[0].Value = ContactID;
			this.odaListContactData.Fill(this.dsContacts1);
			return this.dsContacts1;
		}
        public DataSet ListContactData()
        {
            this.dsContacts1.Clear();
            this.odaContacts.Fill(this.dsContacts1);
            return this.dsContacts1;
        }

		public int UpdateContactUserID( int userID , int ContactID )
		{
			this.oleDbDataAdapterUpdateContactUsrID.UpdateCommand.Parameters[0].Value = userID;
			this.oleDbDataAdapterUpdateContactUsrID.UpdateCommand.Parameters[1].Value = ContactID;
			return this.oleDbDataAdapterUpdateContactUsrID.UpdateCommand.ExecuteNonQuery();
		}
	}
}
