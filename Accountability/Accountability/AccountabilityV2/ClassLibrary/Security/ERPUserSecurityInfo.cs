using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using TSN.ERP.Security.Data;

namespace TSN.ERP.Security
{
	/// <summary>
	/// Summary description for UserSecurity.
	/// </summary>
	/// 
	[Serializable]
	public class ERPUserSecurityInfo : System.ComponentModel.Component
	{
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterUser;
		private TSN.ERP.Security.Data.DataSetUser dataSetUser1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterAllUserGroups;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterRuleGroup;
		private TSN.ERP.Security.Data.DataSetAllUserGroups dataSetAllUserGroups1;
		private TSN.ERP.Security.Data.DataSetRG dataSetRG1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
		private TSN.ERP.Security.Data.DataSetAllUGForRG dataSetAllUGForRG1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterAllUGForRG1;
		private System.Data.OleDb.OleDbCommand oleDCGetUserID;
		private System.Data.OleDb.OleDbCommand oleDCIsUserAdmin;
		private System.Data.OleDb.OleDbCommand oleDCGetRuleName;
		private System.Data.OleDb.OleDbDataAdapter odaRuleGroupNullEntity;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand5;
		private System.Data.OleDb.OleDbConnection con1;


		/// <summary>
		/// Required designer variable.
		/// </summary>
		#region Variables 
		private string error,username,password , winUser;
		private int usrID;
		bool admin;
		DateTime chgpass;
		#endregion 
		private System.Data.OleDb.OleDbCommand odcChangePass;
		

		private System.ComponentModel.Container components = null;

		public ERPUserSecurityInfo(System.ComponentModel.IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			container.Add(this);
			InitializeComponent();
			error = "";
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public ERPUserSecurityInfo()
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
////////////////////        [DebuggerStepThrough()]
////////////////////        protected override void Dispose( bool disposing )
////////////////////        {
////////////////////            if (con1 !=null)
////////////////////            {
////////////////////                //con1.Close();
////////////////////                con1.Dispose();
////////////////////            }
//////////////////////			if( disposing )
//////////////////////			{
//////////////////////				if(components != null)
//////////////////////				{
//////////////////////					components.Dispose();
//////////////////////				}
//////////////////////			}
////////////////////            base.Dispose( disposing );
////////////////////        }


		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.oleDbDataAdapterUser = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.con1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dataSetUser1 = new TSN.ERP.Security.Data.DataSetUser();
			this.oleDbDataAdapterAllUserGroups = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterRuleGroup = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.dataSetAllUserGroups1 = new TSN.ERP.Security.Data.DataSetAllUserGroups();
			this.dataSetRG1 = new TSN.ERP.Security.Data.DataSetRG();
			this.oleDbDataAdapterAllUGForRG1 = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
			this.dataSetAllUGForRG1 = new TSN.ERP.Security.Data.DataSetAllUGForRG();
			this.oleDCGetUserID = new System.Data.OleDb.OleDbCommand();
			this.oleDCIsUserAdmin = new System.Data.OleDb.OleDbCommand();
			this.oleDCGetRuleName = new System.Data.OleDb.OleDbCommand();
			this.odaRuleGroupNullEntity = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
			this.odcChangePass = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dataSetUser1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetAllUserGroups1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetRG1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetAllUGForRG1)).BeginInit();
			// 
			// oleDbDataAdapterUser
			// 
			this.oleDbDataAdapterUser.DeleteCommand = this.oleDbDeleteCommand1;
			this.oleDbDataAdapterUser.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbDataAdapterUser.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbDataAdapterUser.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										   new System.Data.Common.DataTableMapping("Table", "SEC_Users", new System.Data.Common.DataColumnMapping[] {
																																																						new System.Data.Common.DataColumnMapping("UserID", "UserID"),
																																																						new System.Data.Common.DataColumnMapping("UserName", "UserName"),
																																																						new System.Data.Common.DataColumnMapping("SecPass", "SecPass"),
																																																						new System.Data.Common.DataColumnMapping("ChgPassDate", "ChgPassDate"),
																																																						new System.Data.Common.DataColumnMapping("SecAdministrator", "SecAdministrator"),
																																																						new System.Data.Common.DataColumnMapping("WinUser", "WinUser")})});
			this.oleDbDataAdapterUser.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = @"DELETE FROM SEC_Users WHERE (UserID = ?) AND (ChgPassDate = ? OR ? IS NULL AND ChgPassDate IS NULL) AND (SecAdministrator = ? OR ? IS NULL AND SecAdministrator IS NULL) AND (SecPass = ?) AND (UserName = ?) AND (WinUser = ? OR ? IS NULL AND WinUser IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.con1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ChgPassDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ChgPassDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ChgPassDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ChgPassDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecAdministrator", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecAdministrator", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecAdministrator1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecAdministrator", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecPass", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecPass", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserName", System.Data.OleDb.OleDbType.VarChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WinUser", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WinUser", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WinUser1", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WinUser", System.Data.DataRowVersion.Original, null));
			// 
			// con1
			// 
			this.con1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=BASSAM;Tag with column collation when possible=False;Initial Catalog=ERPdbFinal;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASSAM;Use Encryption for Data=False";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO SEC_Users(UserName, SecPass, ChgPassDate, SecAdministrator, WinUser) " +
				"VALUES (?, ?, ?, ?, ?); SELECT UserID, UserName, SecPass, ChgPassDate, SecAdmini" +
				"strator, WinUser FROM SEC_Users WHERE (UserID = @@IDENTITY)";
			this.oleDbInsertCommand1.Connection = this.con1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserName", System.Data.OleDb.OleDbType.VarChar, 60, "UserName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("SecPass", System.Data.OleDb.OleDbType.VarChar, 180, "SecPass"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ChgPassDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ChgPassDate"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("SecAdministrator", System.Data.OleDb.OleDbType.Boolean, 1, "SecAdministrator"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WinUser", System.Data.OleDb.OleDbType.VarChar, 120, "WinUser"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT UserID, UserName, SecPass, ChgPassDate, SecAdministrator, WinUser FROM SEC" +
				"_Users WHERE (UserID = ?)";
			this.oleDbSelectCommand1.Connection = this.con1;
			this.oleDbSelectCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE SEC_Users SET UserName = ?, SecPass = ?, ChgPassDate = ?, SecAdministrator = ?, WinUser = ? WHERE (UserID = ?) AND (ChgPassDate = ? OR ? IS NULL AND ChgPassDate IS NULL) AND (SecAdministrator = ? OR ? IS NULL AND SecAdministrator IS NULL) AND (SecPass = ?) AND (UserName = ?) AND (WinUser = ? OR ? IS NULL AND WinUser IS NULL); SELECT UserID, UserName, SecPass, ChgPassDate, SecAdministrator, WinUser FROM SEC_Users WHERE (UserID = ?)";
			this.oleDbUpdateCommand1.Connection = this.con1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserName", System.Data.OleDb.OleDbType.VarChar, 60, "UserName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("SecPass", System.Data.OleDb.OleDbType.VarChar, 180, "SecPass"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ChgPassDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ChgPassDate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("SecAdministrator", System.Data.OleDb.OleDbType.Boolean, 1, "SecAdministrator"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WinUser", System.Data.OleDb.OleDbType.VarChar, 120, "WinUser"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ChgPassDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ChgPassDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Param64", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecAdministrator", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecAdministrator", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Param66", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecPass", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecPass", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserName", System.Data.OleDb.OleDbType.VarChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WinUser", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WinUser", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Param70", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select1_UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			// 
			// dataSetUser1
			// 
			this.dataSetUser1.DataSetName = "DataSetUser";
			this.dataSetUser1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbDataAdapterAllUserGroups
			// 
			this.oleDbDataAdapterAllUserGroups.DeleteCommand = this.oleDbDeleteCommand2;
			this.oleDbDataAdapterAllUserGroups.InsertCommand = this.oleDbInsertCommand2;
			this.oleDbDataAdapterAllUserGroups.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbDataAdapterAllUserGroups.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													new System.Data.Common.DataTableMapping("Table", "SEC_UserXUserGroup", new System.Data.Common.DataColumnMapping[] {
																																																										  new System.Data.Common.DataColumnMapping("UserID", "UserID"),
																																																										  new System.Data.Common.DataColumnMapping("UserGroupID", "UserGroupID")})});
			this.oleDbDataAdapterAllUserGroups.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = "DELETE FROM SEC_UserXUserGroup WHERE (UserGroupID = ?) AND (UserID = ?)";
			this.oleDbDeleteCommand2.Connection = this.con1;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserGroupID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO SEC_UserXUserGroup(UserID, UserGroupID) VALUES (?, ?); SELECT UserID," +
				" UserGroupID FROM SEC_UserXUserGroup WHERE (UserGroupID = ?) AND (UserID = ?)";
			this.oleDbInsertCommand2.Connection = this.con1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, "UserGroupID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, "UserGroupID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT UserID, UserGroupID FROM SEC_UserXUserGroup WHERE (UserID = ?)";
			this.oleDbSelectCommand2.Connection = this.con1;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = "UPDATE SEC_UserXUserGroup SET UserID = ?, UserGroupID = ? WHERE (UserGroupID = ?)" +
				" AND (UserID = ?); SELECT UserID, UserGroupID FROM SEC_UserXUserGroup WHERE (Use" +
				"rGroupID = ?) AND (UserID = ?)";
			this.oleDbUpdateCommand2.Connection = this.con1;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, "UserGroupID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserGroupID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, "UserGroupID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			// 
			// oleDbDataAdapterRuleGroup
			// 
			this.oleDbDataAdapterRuleGroup.SelectCommand = this.oleDbSelectCommand3;
			this.oleDbDataAdapterRuleGroup.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												new System.Data.Common.DataTableMapping("Table", "SEC_RuleEntityXRuleGroup", new System.Data.Common.DataColumnMapping[] {
																																																											new System.Data.Common.DataColumnMapping("RuleGroupID", "RuleGroupID")})});
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = "SELECT SEC_RuleEntityXRuleGroup.RuleGroupID FROM SEC_RuleEntity INNER JOIN SEC_Ru" +
				"leEntityXRuleGroup ON SEC_RuleEntity.RuleEntityID = SEC_RuleEntityXRuleGroup.Rul" +
				"eEntityID WHERE (SEC_RuleEntity.RuleID = ?) AND (SEC_RuleEntity.RuleEntityValue " +
				"= ?)";
			this.oleDbSelectCommand3.Connection = this.con1;
			this.oleDbSelectCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleID", System.Data.OleDb.OleDbType.Integer, 4, "RuleID"));
			this.oleDbSelectCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, "RuleEntityValue"));
			// 
			// dataSetAllUserGroups1
			// 
			this.dataSetAllUserGroups1.DataSetName = "DataSetAllUserGroups";
			this.dataSetAllUserGroups1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dataSetRG1
			// 
			this.dataSetRG1.DataSetName = "DataSetRG";
			this.dataSetRG1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbDataAdapterAllUGForRG1
			// 
			this.oleDbDataAdapterAllUGForRG1.DeleteCommand = this.oleDbDeleteCommand3;
			this.oleDbDataAdapterAllUGForRG1.InsertCommand = this.oleDbInsertCommand3;
			this.oleDbDataAdapterAllUGForRG1.SelectCommand = this.oleDbSelectCommand4;
			this.oleDbDataAdapterAllUGForRG1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												  new System.Data.Common.DataTableMapping("Table", "SEC_UsersGroupsXRulesGroups", new System.Data.Common.DataColumnMapping[] {
																																																												 new System.Data.Common.DataColumnMapping("UserGroupID", "UserGroupID"),
																																																												 new System.Data.Common.DataColumnMapping("RuleGroupID", "RuleGroupID")})});
			this.oleDbDataAdapterAllUGForRG1.UpdateCommand = this.oleDbUpdateCommand3;
			// 
			// oleDbDeleteCommand3
			// 
			this.oleDbDeleteCommand3.CommandText = "DELETE FROM SEC_UsersGroupsXRulesGroups WHERE (RuleGroupID = ?) AND (UserGroupID " +
				"= ?)";
			this.oleDbDeleteCommand3.Connection = this.con1;
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleGroupID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleGroupID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserGroupID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand3
			// 
			this.oleDbInsertCommand3.CommandText = "INSERT INTO SEC_UsersGroupsXRulesGroups(UserGroupID, RuleGroupID) VALUES (?, ?); " +
				"SELECT UserGroupID, RuleGroupID FROM SEC_UsersGroupsXRulesGroups WHERE (RuleGrou" +
				"pID = ?) AND (UserGroupID = ?)";
			this.oleDbInsertCommand3.Connection = this.con1;
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, "UserGroupID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleGroupID", System.Data.OleDb.OleDbType.Integer, 4, "RuleGroupID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_RuleGroupID", System.Data.OleDb.OleDbType.Integer, 4, "RuleGroupID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, "UserGroupID"));
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = "SELECT UserGroupID, RuleGroupID FROM SEC_UsersGroupsXRulesGroups WHERE (RuleGroup" +
				"ID = ?)";
			this.oleDbSelectCommand4.Connection = this.con1;
			this.oleDbSelectCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleGroupID", System.Data.OleDb.OleDbType.Integer, 4, "RuleGroupID"));
			// 
			// oleDbUpdateCommand3
			// 
			this.oleDbUpdateCommand3.CommandText = "UPDATE SEC_UsersGroupsXRulesGroups SET UserGroupID = ?, RuleGroupID = ? WHERE (Ru" +
				"leGroupID = ?) AND (UserGroupID = ?); SELECT UserGroupID, RuleGroupID FROM SEC_U" +
				"sersGroupsXRulesGroups WHERE (RuleGroupID = ?) AND (UserGroupID = ?)";
			this.oleDbUpdateCommand3.Connection = this.con1;
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, "UserGroupID"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleGroupID", System.Data.OleDb.OleDbType.Integer, 4, "RuleGroupID"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleGroupID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleGroupID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserGroupID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_RuleGroupID", System.Data.OleDb.OleDbType.Integer, 4, "RuleGroupID"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, "UserGroupID"));
			// 
			// dataSetAllUGForRG1
			// 
			this.dataSetAllUGForRG1.DataSetName = "DataSetAllUGForRG";
			this.dataSetAllUGForRG1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDCGetUserID
			// 
			this.oleDCGetUserID.CommandText = "SELECT UserID FROM SEC_Users WHERE (UserName = ?)";
			this.oleDCGetUserID.Connection = this.con1;
			this.oleDCGetUserID.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserName", System.Data.OleDb.OleDbType.VarChar, 60, "UserName"));
			// 
			// oleDCIsUserAdmin
			// 
			this.oleDCIsUserAdmin.CommandText = "SELECT COUNT(*) AS UserCount FROM SEC_Users WHERE (UserID = ?) AND (SecAdministra" +
				"tor = 1)";
			this.oleDCIsUserAdmin.Connection = this.con1;
			this.oleDCIsUserAdmin.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			// 
			// oleDCGetRuleName
			// 
			this.oleDCGetRuleName.CommandText = "SELECT RuleName FROM SEC_Rules WHERE (RuleID = ?)";
			this.oleDCGetRuleName.Connection = this.con1;
			this.oleDCGetRuleName.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleID", System.Data.OleDb.OleDbType.Integer, 4, "RuleID"));
			// 
			// odaRuleGroupNullEntity
			// 
			this.odaRuleGroupNullEntity.SelectCommand = this.oleDbSelectCommand5;
			this.odaRuleGroupNullEntity.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											 new System.Data.Common.DataTableMapping("Table", "SEC_RuleEntityXRuleGroup", new System.Data.Common.DataColumnMapping[] {
																																																										 new System.Data.Common.DataColumnMapping("RuleGroupID", "RuleGroupID")})});
			// 
			// oleDbSelectCommand5
			// 
			this.oleDbSelectCommand5.CommandText = "SELECT SEC_RuleEntityXRuleGroup.RuleGroupID FROM SEC_RuleEntity INNER JOIN SEC_Ru" +
				"leEntityXRuleGroup ON SEC_RuleEntity.RuleEntityID = SEC_RuleEntityXRuleGroup.Rul" +
				"eEntityID WHERE (SEC_RuleEntity.RuleID = ?) AND (SEC_RuleEntity.RuleEntityValue " +
				"IS NULL)";
			this.oleDbSelectCommand5.Connection = this.con1;
			this.oleDbSelectCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleID", System.Data.OleDb.OleDbType.Integer, 4, "RuleID"));
			// 
			// odcChangePass
			// 
			this.odcChangePass.CommandText = "UPDATE SEC_Users SET SecPass = ? WHERE (UserID = ?) AND (SecPass = ?)";
			this.odcChangePass.Connection = this.con1;
			this.odcChangePass.Parameters.Add(new System.Data.OleDb.OleDbParameter("SecPass", System.Data.OleDb.OleDbType.VarChar, 180, "SecPass"));
			this.odcChangePass.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.odcChangePass.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecPass", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecPass", System.Data.DataRowVersion.Original, null));
			((System.ComponentModel.ISupportInitialize)(this.dataSetUser1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetAllUserGroups1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetRG1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetAllUGForRG1)).EndInit();

		}
		#endregion

		#region Functions 
		public string GetRuleName(int RuleID)
		{
			oleDCGetRuleName.Parameters[0].Value = RuleID;
			return oleDCGetRuleName.ExecuteScalar().ToString();
		}
		
		#region Get User Details
		/// <summary>
		/// Get user details giving name.
		/// </summary>
		/// <param name="UserName">string:Containing the required user name</param>
		/// <returns>DataSetUser:Containing details of the required user</returns>
		public DataSetUser GetUserDetails(string UserName)
		{
			this.oleDCGetUserID.Parameters["UserName"].Value = UserName;
			int tempUserID = (int)this.oleDCGetUserID.ExecuteScalar();
			return this.GetUserDetails(tempUserID);
		}
		/// <summary>
		/// Get user details giving ID.
		/// </summary>
		/// <param name="userID">int: User ID</param>
		/// <returns>DataSetUser: Containing details of the required user</returns>
		public DataSetUser GetUserDetails( int userID )
		{
			try
			{
				oleDbDataAdapterUser.SelectCommand.Parameters[ 0 ].Value = userID;
				oleDbDataAdapterUser.Fill( dataSetUser1 );
				if ( dataSetUser1.SEC_Users.Rows.Count != 0)
				{
					usrID	 = dataSetUser1.SEC_Users[0].UserID;
					username = dataSetUser1.SEC_Users[0].UserName;
					password = dataSetUser1.SEC_Users[0].SecPass;
					if ( dataSetUser1.Tables[ 0 ].Rows[ 0 ][ "ChgPassDate" ] != DBNull.Value )
						chgpass  = dataSetUser1.SEC_Users[0].ChgPassDate;
					admin	 = dataSetUser1.SEC_Users[0].SecAdministrator;
					if ( dataSetUser1.Tables[ 0 ].Rows[ 0 ][ "WinUser" ] != DBNull.Value )
						winUser  = dataSetUser1.SEC_Users[0].WinUser;
				}
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return dataSetUser1;
		}
		/// <summary>
		/// Checking if user admin or not.
		/// </summary>
		/// <param name="UserID">int:User ID</param>
		/// <returns>bool:If the opration success retruns true,but if not retruns false</returns>
		public bool IsUserAdmin(int UserID)
		{
			try
			{
				this.oleDCIsUserAdmin.Parameters[0].Value = UserID;
				object tempobj = oleDCIsUserAdmin.ExecuteScalar();
				if (tempobj == null)
					return false;
				if (Int32.Parse(tempobj.ToString()) > 0)
					return true;
				return false;
			}
			catch(Exception ex)
			{
				error = ex.Message;
				return false;
			}
		}
		#endregion

		#region Check User Access Right
		/// <summary>
		/// Checking user access right for giving rule.
		/// </summary>
		/// <param name="userID">int: The giving user ID</param>
		/// <param name="ruleID">int: The giving rule ID</param>
		/// <param name="entityValue">string: Entity value</param>
		/// <returns>bool: If the opration success retruns true,but if not retruns false</returns>
		public bool CheckUserAccessRight( int userID , int ruleID , string entityValue )
		{
			bool right =  false; 
			dataSetAllUserGroups1.Clear();
			dataSetRG1.Clear();
			dataSetAllUGForRG1.Clear();
			string ErrorMsg1 =" ,  Rule ID :" + ruleID.ToString() + " , Entity : " + entityValue;

			try
			{
				// Check Super User
				if (this.IsUserAdmin(userID))
					return true;
				// Get All user groups
				oleDbDataAdapterAllUserGroups.SelectCommand.Parameters[ "UserID" ].Value = userID;
				oleDbDataAdapterAllUserGroups.Fill( dataSetAllUserGroups1 );
				if ( dataSetAllUserGroups1.Tables[ 0 ].Rows.Count == 0 )
				{	
					error = "This user is not associated with any group" + ErrorMsg1;
					return false;
				}

				// Get the Rule Group which having this rule and entity
				
				if (entityValue == null)//Modifications for entity value = null , BS
				{
					odaRuleGroupNullEntity.SelectCommand.Parameters["RuleID" ].Value = ruleID;
					odaRuleGroupNullEntity.Fill( dataSetRG1);
				}
				else
				{
					oleDbDataAdapterRuleGroup.SelectCommand.Parameters[ "RuleID" ].Value = ruleID;
					oleDbDataAdapterRuleGroup.SelectCommand.Parameters[ "RuleEntityValue" ].Value = entityValue;
					oleDbDataAdapterRuleGroup.Fill( dataSetRG1 );
				}
				if ( dataSetRG1.Tables[ 0 ].Rows.Count == 0 )
				{	
					error = "This rule and entity are not assigned to any rule group " + ErrorMsg1;
					return false;
				}
				
				//Get All User Groups for Rule Group
				for ( int i = 0 ; i < dataSetRG1.SEC_RuleEntityXRuleGroup.Rows.Count ; i++ )
				{
					TSN.ERP.Security.Data.DataSetAllUGForRG tempDs  = new TSN.ERP.Security.Data.DataSetAllUGForRG(); 
					oleDbDataAdapterAllUGForRG1.SelectCommand.Parameters[ "RuleGroupID" ].Value = dataSetRG1.SEC_RuleEntityXRuleGroup[i].RuleGroupID;
					oleDbDataAdapterAllUGForRG1.Fill( tempDs );
					dataSetAllUGForRG1.Merge ( tempDs );
					tempDs.Clear();
				}
				if ( dataSetAllUGForRG1.Tables[ 0 ].Rows.Count == 0 )
				{	
					error = "This rule group is not associated with any user group" + ErrorMsg1 ;
					return false;
				}

				//Check user right 
				DataRowCollection rc ;
				rc = dataSetAllUserGroups1.SEC_UserXUserGroup.Rows;

				for ( int i = 0 ; i < dataSetAllUGForRG1.SEC_UsersGroupsXRulesGroups.Rows.Count ; i++ )
				{
					object[] arr = new object[2];	
					arr[0] =  userID;
					arr[1] = dataSetAllUGForRG1.SEC_UsersGroupsXRulesGroups[ i ].UserGroupID ;
					
					if ( rc.Find( arr ) != null )
					{	
						right = true ;
						break;
					}
				}
			}
			catch ( Exception ee )
			{
				error = ee.Message;
				return false;
			}

			if ( right )
				return true;
			else
			{
				error = "This user has not access right for this rule" + ErrorMsg1 ;
				return false;
			}
		}
		
		
		#endregion
			
		#endregion 

		#region Properties
		public string Error
		{
			get
			{
				return error;
			}
		}


		public int UserID
		{
			get
			{
				return usrID;
			}
		}

		public string UserPassword
		{
			get
			{
				return password.Trim();
			}
		}

		public string UserName
		{
			get
			{
				return username.Trim();
			}
		}

		public DateTime ChangPasswordDate
		{
			get
			{
				return chgpass;
			}
		}

		public string WindowsUser
		{
			get
			{
				return winUser.Trim();
			}
		}

		public bool Administrator
		{
			get
			{
				return admin;
			}
		}

		public bool SetConnectionString(string NewConnectionString)
		{
			try
			{
				con1.Close(); 
				con1.ConnectionString = NewConnectionString; 
				con1.Open();
				return true;
			}
			
			catch ( Exception ex )
			{
				EventLog.WriteEntry("TSN ERP Server ERPSecurityInfor",ex.Message,System.Diagnostics.EventLogEntryType.Error);
				return false;
			}
		}

		public string ConnectionString
		{
			set
			{
				try
				{
					con1.Close();
					con1.ConnectionString = value;
					con1.Open();
				}
				catch ( Exception ee )
				{
					EventLog.WriteEntry("TSN ERP Server : Security Manager",ee.Message,System.Diagnostics.EventLogEntryType.Error);
				}
			}
		}
		public bool ChangePassword(string OldPassword, string NewPassword)
		{
			odcChangePass.Parameters["Original_UserID"].Value = UserID;
			odcChangePass.Parameters["Original_SecPass"].Value = OldPassword;
			odcChangePass.Parameters["SecPass"].Value = NewPassword;
			if (odcChangePass.ExecuteNonQuery() == 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion 
	}
}
