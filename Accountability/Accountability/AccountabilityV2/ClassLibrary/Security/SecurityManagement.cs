using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Net;
using TSN.ERP.Security.Data;
//using System.EnterpriseServices;
namespace TSN.ERP.Security
	
{
	/// <summary>
	/// Summary description for SecurityManagement.
	/// </summary>
	/// 
	//[Transaction(TransactionOption.Supported)] 
	public class SecurityManagement : System.ComponentModel.Component
	{
		#region 

		private TSN.ERP.Security.Data.DataSetGroups dataSetGroups1;
		private TSN.ERP.Security.Data.DataSetUsrGroup dataSetUsrGroup1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterRules;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand4;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand4;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand4;
		private TSN.ERP.Security.Data.DataSetRules dataSetRules1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand6;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand6;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand6;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand6;
		private TSN.ERP.Security.Data.DataSetRuleGroup dataSetRuleGroup1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterRlEntWithRlGrp;
		private TSN.ERP.Security.Data.DataSetRlEntRlGrp dataSetRlEntRlGrp1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterUsrGrpRulGrp;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand8;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand8;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand8;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand8;
		private TSN.ERP.Security.Data.DataSetUsrGrpRulGrp dataSetUsrGrpRulGrp1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterLogFile;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand9;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand9;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand9;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand9;
		private TSN.ERP.Security.Data.DataSetLogFile dataSetLogFile1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterLogin;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand10;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand10;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand10;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand10;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Data.OleDb.OleDbConnection oleDbConnection2;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterRuleEntity;
		private TSN.ERP.Security.Data.DataSetRuleEntity dataSetRuleEntity1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand5;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand5;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand5;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand5;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterAllUsersInUserGroup;
		private TSN.ERP.Security.Data.DataSetUsersInUsrGrp dataSetUsersInUsrGrp1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand7;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand7;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand7;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand7;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterAllEntInRlGr;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand12;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand11;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand11;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand11;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand11;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterUserRuleEntities;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand14;
		private System.Data.OleDb.OleDbDataAdapter odaRuleGroup;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterUsrGroup;
		private System.Data.OleDb.OleDbDataAdapter odaUserGroups;
		private System.Data.OleDb.OleDbCommand odcGetContactUserID;
		private System.Data.OleDb.OleDbCommand odcGetUserContactID;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterGetRuleGroup;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand15;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterGetUserGroup;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand16;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterAllNonUserGroupType;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand17;
	
		#endregion 
		/// <summary>
		/// Required designer variable.
		/// </summary>
		/// 

		#region Variables 
		private string error;
		#endregion 
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterAllUserRules;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand18;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterNotAssignedUsers;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand19;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterAllEntities;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand13;
		private TSN.ERP.Security.Data.DataSetEntities dataSetEntities1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand20;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterAllRuleEntOfEntityAndValue;
		private System.Data.OleDb.OleDbDataAdapter odaGeneralRules;
		private System.Data.OleDb.OleDbCommand odcSetHomeLink;
		private System.Data.OleDb.OleDbCommand odcGetHomeLink;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand21;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterAllUserRlEnt;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand22;
		private System.Data.OleDb.OleDbDataAdapter oleDbAdptRlGrpOfEntValueAndEntity;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand23;
		private System.Data.OleDb.OleDbDataAdapter odaRulesForEntity;
		private System.Data.OleDb.OleDbCommand odaRulesForEntitySelectCommand;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterActiveUsers;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand24;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand12;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand12;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand12;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter odaUsers;
//		private TSN.ERP.Security.Data.UsrDS usrDS1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private TSN.ERP.Security.Data.UsrDS usrDS1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterVisitLog;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand25;
		private System.Data.OleDb.OleDbCommand oleDbCommandVisitLogInsert;
		private System.Data.OleDb.OleDbCommand oleDbCommandVisitLogUpdate;
		private System.Data.OleDb.OleDbCommand cmdGetUserNameByEmpCode;
		private System.Data.OleDb.OleDbCommand cmdGetUserData;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterGetUserRlEnt;
		private System.Data.OleDb.OleDbCommand oleDbCommand1;
		private System.Data.OleDb.OleDbCommand cmdGetUserIdByContactID;
	
		
				
		private System.ComponentModel.Container components = null;
		public SecurityManagement(System.ComponentModel.IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			container.Add(this);
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			error = "";
		}

		public SecurityManagement()
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
//////////////////////			if(oleDbConnection2 != null)
//////////////////////			{
//////////////////////				//oleDbConnection2.Close();
//////////////////////				oleDbConnection2.Dispose();
//////////////////////			}
//////////////////////////			if( disposing )
//////////////////////////			{
//////////////////////////				if(components != null)
//////////////////////////				{
//////////////////////////					components.Dispose();
//////////////////////////				}
////////////////////////			}
//////////////////////			base.Dispose( disposing );
////////////////////        }

		 

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.oleDbConnection2 = new System.Data.OleDb.OleDbConnection();
			this.odaUserGroups = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterRules = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand4 = new System.Data.OleDb.OleDbCommand();
			this.odaRuleGroup = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand6 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand6 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand6 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand6 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterRlEntWithRlGrp = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand7 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand7 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand7 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand7 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterUsrGrpRulGrp = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand8 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand8 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand8 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand8 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterLogFile = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand9 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand9 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand9 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand9 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterLogin = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand10 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand10 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand10 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand10 = new System.Data.OleDb.OleDbCommand();
			this.dataSetUsrGrpRulGrp1 = new TSN.ERP.Security.Data.DataSetUsrGrpRulGrp();
			this.dataSetUsrGroup1 = new TSN.ERP.Security.Data.DataSetUsrGroup();
			this.dataSetRules1 = new TSN.ERP.Security.Data.DataSetRules();
			this.dataSetRuleGroup1 = new TSN.ERP.Security.Data.DataSetRuleGroup();
			this.dataSetRlEntRlGrp1 = new TSN.ERP.Security.Data.DataSetRlEntRlGrp();
			this.dataSetLogFile1 = new TSN.ERP.Security.Data.DataSetLogFile();
			this.dataSetGroups1 = new TSN.ERP.Security.Data.DataSetGroups();
			this.oleDbDataAdapterRuleEntity = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand5 = new System.Data.OleDb.OleDbCommand();
			this.dataSetRuleEntity1 = new TSN.ERP.Security.Data.DataSetRuleEntity();
			this.oleDbDataAdapterAllUsersInUserGroup = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand11 = new System.Data.OleDb.OleDbCommand();
			this.dataSetUsersInUsrGrp1 = new TSN.ERP.Security.Data.DataSetUsersInUsrGrp();
			this.oleDbDataAdapterAllEntInRlGr = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand11 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand11 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand12 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand11 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterUserRuleEntities = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand14 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterUsrGroup = new System.Data.OleDb.OleDbDataAdapter();
			this.odcGetContactUserID = new System.Data.OleDb.OleDbCommand();
			this.odcGetUserContactID = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterGetRuleGroup = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand15 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterGetUserGroup = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand16 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterAllNonUserGroupType = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand17 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterAllUserRules = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand18 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterNotAssignedUsers = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand19 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterAllEntities = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand13 = new System.Data.OleDb.OleDbCommand();
			this.dataSetEntities1 = new TSN.ERP.Security.Data.DataSetEntities();
			this.oleDbDataAdapterAllRuleEntOfEntityAndValue = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand20 = new System.Data.OleDb.OleDbCommand();
			this.odaGeneralRules = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand21 = new System.Data.OleDb.OleDbCommand();
			this.odcSetHomeLink = new System.Data.OleDb.OleDbCommand();
			this.odcGetHomeLink = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterAllUserRlEnt = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand22 = new System.Data.OleDb.OleDbCommand();
			this.oleDbAdptRlGrpOfEntValueAndEntity = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand23 = new System.Data.OleDb.OleDbCommand();
			this.odaRulesForEntity = new System.Data.OleDb.OleDbDataAdapter();
			this.odaRulesForEntitySelectCommand = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterActiveUsers = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand12 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand12 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand24 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand12 = new System.Data.OleDb.OleDbCommand();
			this.odaUsers = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.usrDS1 = new TSN.ERP.Security.Data.UsrDS();
			this.oleDbDataAdapterVisitLog = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbCommandVisitLogInsert = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand25 = new System.Data.OleDb.OleDbCommand();
			this.oleDbCommandVisitLogUpdate = new System.Data.OleDb.OleDbCommand();
			this.cmdGetUserNameByEmpCode = new System.Data.OleDb.OleDbCommand();
			this.cmdGetUserData = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterGetUserRlEnt = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
			this.cmdGetUserIdByContactID = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dataSetUsrGrpRulGrp1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetUsrGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetRules1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetRuleGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetRlEntRlGrp1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetLogFile1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetGroups1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetRuleEntity1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetUsersInUsrGrp1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetEntities1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.usrDS1)).BeginInit();
			// 
			// oleDbConnection2
			// 
			this.oleDbConnection2.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=MIS;Tag with column collation when possible=False;Initial Catalog=TestAccountability_Data;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASANT;Use Encryption for Data=False";
			// 
			// odaUserGroups
			// 
			this.odaUserGroups.DeleteCommand = this.oleDbDeleteCommand2;
			this.odaUserGroups.InsertCommand = this.oleDbInsertCommand2;
			this.odaUserGroups.SelectCommand = this.oleDbSelectCommand2;
			this.odaUserGroups.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									new System.Data.Common.DataTableMapping("Table", "SEC_UsersGroups", new System.Data.Common.DataColumnMapping[] {
																																																					   new System.Data.Common.DataColumnMapping("UserGroupID", "UserGroupID"),
																																																					   new System.Data.Common.DataColumnMapping("UserGroupName", "UserGroupName"),
																																																					   new System.Data.Common.DataColumnMapping("UserGroupType", "UserGroupType")})});
			this.odaUserGroups.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = "DELETE FROM SEC_UsersGroups WHERE (UserGroupID = ?)";
			this.oleDbDeleteCommand2.Connection = this.oleDbConnection2;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserGroupID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO SEC_UsersGroups(UserGroupName, UserGroupType) VALUES (?, ?); SELECT U" +
				"serGroupID, UserGroupName, UserGroupType FROM SEC_UsersGroups WHERE (UserGroupID" +
				" = @@IDENTITY)";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection2;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserGroupName", System.Data.OleDb.OleDbType.VarChar, 180, "UserGroupName"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserGroupType", System.Data.OleDb.OleDbType.Boolean, 1, "UserGroupType"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT UserGroupID, UserGroupName, UserGroupType FROM SEC_UsersGroups ORDER BY Us" +
				"erGroupName";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection2;
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = "UPDATE SEC_UsersGroups SET UserGroupName = ?, UserGroupType = ? WHERE (UserGroupI" +
				"D = ?) AND (UserGroupName = ?) AND (UserGroupType = ?); SELECT UserGroupID, User" +
				"GroupName, UserGroupType FROM SEC_UsersGroups WHERE (UserGroupID = ?)";
			this.oleDbUpdateCommand2.Connection = this.oleDbConnection2;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserGroupName", System.Data.OleDb.OleDbType.VarChar, 180, "UserGroupName"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserGroupType", System.Data.OleDb.OleDbType.Boolean, 1, "UserGroupType"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserGroupID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserGroupName", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserGroupName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserGroupType", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserGroupType", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, "UserGroupID"));
			// 
			// oleDbDataAdapterRules
			// 
			this.oleDbDataAdapterRules.DeleteCommand = this.oleDbDeleteCommand4;
			this.oleDbDataAdapterRules.InsertCommand = this.oleDbInsertCommand4;
			this.oleDbDataAdapterRules.SelectCommand = this.oleDbSelectCommand4;
			this.oleDbDataAdapterRules.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											new System.Data.Common.DataTableMapping("Table", "SEC_Rules", new System.Data.Common.DataColumnMapping[] {
																																																						 new System.Data.Common.DataColumnMapping("RuleID", "RuleID"),
																																																						 new System.Data.Common.DataColumnMapping("RuleName", "RuleName")})});
			this.oleDbDataAdapterRules.UpdateCommand = this.oleDbUpdateCommand4;
			// 
			// oleDbDeleteCommand4
			// 
			this.oleDbDeleteCommand4.CommandText = "DELETE FROM SEC_Rules WHERE (RuleID = ?) AND (RuleName = ?)";
			this.oleDbDeleteCommand4.Connection = this.oleDbConnection2;
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleName", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleName", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand4
			// 
			this.oleDbInsertCommand4.CommandText = "INSERT INTO SEC_Rules (RuleName) VALUES (?); SELECT RuleID, RuleName FROM SEC_Rul" +
				"es WHERE (RuleID = @@identity)";
			this.oleDbInsertCommand4.Connection = this.oleDbConnection2;
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleName", System.Data.OleDb.OleDbType.VarChar, 180, "RuleName"));
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = "SELECT RuleID, RuleName FROM SEC_Rules ORDER BY RuleName";
			this.oleDbSelectCommand4.Connection = this.oleDbConnection2;
			// 
			// oleDbUpdateCommand4
			// 
			this.oleDbUpdateCommand4.CommandText = "UPDATE SEC_Rules SET RuleID = ?, RuleName = ? WHERE (RuleID = ?) AND (RuleName = " +
				"?); SELECT RuleID, RuleName FROM SEC_Rules WHERE (RuleID = ?)";
			this.oleDbUpdateCommand4.Connection = this.oleDbConnection2;
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleID", System.Data.OleDb.OleDbType.Integer, 4, "RuleID"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleName", System.Data.OleDb.OleDbType.VarChar, 180, "RuleName"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleName", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_RuleID", System.Data.OleDb.OleDbType.Integer, 4, "RuleID"));
			// 
			// odaRuleGroup
			// 
			this.odaRuleGroup.DeleteCommand = this.oleDbDeleteCommand6;
			this.odaRuleGroup.InsertCommand = this.oleDbInsertCommand6;
			this.odaRuleGroup.SelectCommand = this.oleDbSelectCommand6;
			this.odaRuleGroup.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								   new System.Data.Common.DataTableMapping("Table", "SEC_RuleGroup", new System.Data.Common.DataColumnMapping[] {
																																																					new System.Data.Common.DataColumnMapping("RuleGroupID", "RuleGroupID"),
																																																					new System.Data.Common.DataColumnMapping("RuleGroupName", "RuleGroupName")})});
			this.odaRuleGroup.UpdateCommand = this.oleDbUpdateCommand6;
			// 
			// oleDbDeleteCommand6
			// 
			this.oleDbDeleteCommand6.CommandText = "DELETE FROM SEC_RuleGroup WHERE (RuleGroupID = ?)";
			this.oleDbDeleteCommand6.Connection = this.oleDbConnection2;
			this.oleDbDeleteCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleGroupID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleGroupID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand6
			// 
			this.oleDbInsertCommand6.CommandText = "INSERT INTO SEC_RuleGroup (RuleGroupName) VALUES (?); SELECT RuleGroupID, RuleGro" +
				"upName FROM SEC_RuleGroup WHERE (RuleGroupID = @@IDENTITY)";
			this.oleDbInsertCommand6.Connection = this.oleDbConnection2;
			this.oleDbInsertCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleGroupName", System.Data.OleDb.OleDbType.VarChar, 120, "RuleGroupName"));
			// 
			// oleDbSelectCommand6
			// 
			this.oleDbSelectCommand6.CommandText = "SELECT RuleGroupID, RuleGroupName FROM SEC_RuleGroup ORDER BY RuleGroupName";
			this.oleDbSelectCommand6.Connection = this.oleDbConnection2;
			// 
			// oleDbUpdateCommand6
			// 
			this.oleDbUpdateCommand6.CommandText = "UPDATE SEC_RuleGroup SET RuleGroupName = ? WHERE (RuleGroupID = ?)";
			this.oleDbUpdateCommand6.Connection = this.oleDbConnection2;
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleGroupName", System.Data.OleDb.OleDbType.VarChar, 120, "RuleGroupName"));
			this.oleDbUpdateCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleGroupID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleGroupID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbDataAdapterRlEntWithRlGrp
			// 
			this.oleDbDataAdapterRlEntWithRlGrp.DeleteCommand = this.oleDbDeleteCommand7;
			this.oleDbDataAdapterRlEntWithRlGrp.InsertCommand = this.oleDbInsertCommand7;
			this.oleDbDataAdapterRlEntWithRlGrp.SelectCommand = this.oleDbSelectCommand7;
			this.oleDbDataAdapterRlEntWithRlGrp.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													 new System.Data.Common.DataTableMapping("Table", "SEC_RuleEntityXRuleGroup", new System.Data.Common.DataColumnMapping[] {
																																																												 new System.Data.Common.DataColumnMapping("RuleEntityID", "RuleEntityID"),
																																																												 new System.Data.Common.DataColumnMapping("RuleGroupID", "RuleGroupID")})});
			this.oleDbDataAdapterRlEntWithRlGrp.UpdateCommand = this.oleDbUpdateCommand7;
			// 
			// oleDbDeleteCommand7
			// 
			this.oleDbDeleteCommand7.CommandText = "DELETE FROM SEC_RuleEntityXRuleGroup WHERE (RuleEntityID = ?) AND (RuleGroupID = " +
				"?)";
			this.oleDbDeleteCommand7.Connection = this.oleDbConnection2;
			this.oleDbDeleteCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleGroupID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleGroupID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand7
			// 
			this.oleDbInsertCommand7.CommandText = "INSERT INTO SEC_RuleEntityXRuleGroup (RuleEntityID, RuleGroupID) VALUES (?, ?)";
			this.oleDbInsertCommand7.Connection = this.oleDbConnection2;
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityID", System.Data.OleDb.OleDbType.Integer, 4, "RuleEntityID"));
			this.oleDbInsertCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleGroupID", System.Data.OleDb.OleDbType.Integer, 4, "RuleGroupID"));
			// 
			// oleDbSelectCommand7
			// 
			this.oleDbSelectCommand7.CommandText = "SELECT RuleEntityID, RuleGroupID FROM SEC_RuleEntityXRuleGroup WHERE (RuleGroupID" +
				" = ?)";
			this.oleDbSelectCommand7.Connection = this.oleDbConnection2;
			this.oleDbSelectCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleGroupID", System.Data.OleDb.OleDbType.Integer, 4, "RuleGroupID"));
			// 
			// oleDbUpdateCommand7
			// 
			this.oleDbUpdateCommand7.CommandText = "UPDATE SEC_RuleEntityXRuleGroup SET RuleEntityID = ?, RuleGroupID = ? WHERE (Rule" +
				"EntityID = ?) AND (RuleGroupID = ?); SELECT RuleEntityID, RuleGroupID FROM SEC_R" +
				"uleEntityXRuleGroup WHERE (RuleEntityID = ?) AND (RuleGroupID = ?)";
			this.oleDbUpdateCommand7.Connection = this.oleDbConnection2;
			this.oleDbUpdateCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityID", System.Data.OleDb.OleDbType.Integer, 4, "RuleEntityID"));
			this.oleDbUpdateCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleGroupID", System.Data.OleDb.OleDbType.Integer, 4, "RuleGroupID"));
			this.oleDbUpdateCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleGroupID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleGroupID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_RuleEntityID", System.Data.OleDb.OleDbType.Integer, 4, "RuleEntityID"));
			this.oleDbUpdateCommand7.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_RuleGroupID", System.Data.OleDb.OleDbType.Integer, 4, "RuleGroupID"));
			// 
			// oleDbDataAdapterUsrGrpRulGrp
			// 
			this.oleDbDataAdapterUsrGrpRulGrp.DeleteCommand = this.oleDbDeleteCommand8;
			this.oleDbDataAdapterUsrGrpRulGrp.InsertCommand = this.oleDbInsertCommand8;
			this.oleDbDataAdapterUsrGrpRulGrp.SelectCommand = this.oleDbSelectCommand8;
			this.oleDbDataAdapterUsrGrpRulGrp.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												   new System.Data.Common.DataTableMapping("Table", "SEC_UsersGroupsXRulesGroups", new System.Data.Common.DataColumnMapping[] {
																																																												  new System.Data.Common.DataColumnMapping("UserGroupID", "UserGroupID"),
																																																												  new System.Data.Common.DataColumnMapping("RuleGroupID", "RuleGroupID")})});
			this.oleDbDataAdapterUsrGrpRulGrp.UpdateCommand = this.oleDbUpdateCommand8;
			// 
			// oleDbDeleteCommand8
			// 
			this.oleDbDeleteCommand8.CommandText = "DELETE FROM SEC_UsersGroupsXRulesGroups WHERE (RuleGroupID = ?) AND (UserGroupID " +
				"= ?)";
			this.oleDbDeleteCommand8.Connection = this.oleDbConnection2;
			this.oleDbDeleteCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleGroupID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleGroupID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserGroupID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand8
			// 
			this.oleDbInsertCommand8.CommandText = "INSERT INTO SEC_UsersGroupsXRulesGroups (UserGroupID, RuleGroupID) VALUES (?, ?)";
			this.oleDbInsertCommand8.Connection = this.oleDbConnection2;
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, "UserGroupID"));
			this.oleDbInsertCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleGroupID", System.Data.OleDb.OleDbType.Integer, 4, "RuleGroupID"));
			// 
			// oleDbSelectCommand8
			// 
			this.oleDbSelectCommand8.CommandText = "SELECT UserGroupID, RuleGroupID FROM SEC_UsersGroupsXRulesGroups";
			this.oleDbSelectCommand8.Connection = this.oleDbConnection2;
			// 
			// oleDbUpdateCommand8
			// 
			this.oleDbUpdateCommand8.CommandText = "UPDATE SEC_UsersGroupsXRulesGroups SET UserGroupID = ?, RuleGroupID = ? WHERE (Ru" +
				"leGroupID = ?) AND (UserGroupID = ?); SELECT UserGroupID, RuleGroupID FROM SEC_U" +
				"sersGroupsXRulesGroups WHERE (RuleGroupID = ?) AND (UserGroupID = ?)";
			this.oleDbUpdateCommand8.Connection = this.oleDbConnection2;
			this.oleDbUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, "UserGroupID"));
			this.oleDbUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleGroupID", System.Data.OleDb.OleDbType.Integer, 4, "RuleGroupID"));
			this.oleDbUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleGroupID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleGroupID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserGroupID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_RuleGroupID", System.Data.OleDb.OleDbType.Integer, 4, "RuleGroupID"));
			this.oleDbUpdateCommand8.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, "UserGroupID"));
			// 
			// oleDbDataAdapterLogFile
			// 
			this.oleDbDataAdapterLogFile.DeleteCommand = this.oleDbDeleteCommand9;
			this.oleDbDataAdapterLogFile.InsertCommand = this.oleDbInsertCommand9;
			this.oleDbDataAdapterLogFile.SelectCommand = this.oleDbSelectCommand9;
			this.oleDbDataAdapterLogFile.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											  new System.Data.Common.DataTableMapping("Table", "SEC_LogFile", new System.Data.Common.DataColumnMapping[] {
																																																							 new System.Data.Common.DataColumnMapping("LogRecID", "LogRecID"),
																																																							 new System.Data.Common.DataColumnMapping("UserID", "UserID"),
																																																							 new System.Data.Common.DataColumnMapping("LogInDate", "LogInDate"),
																																																							 new System.Data.Common.DataColumnMapping("LogOutDate", "LogOutDate"),
																																																							 new System.Data.Common.DataColumnMapping("LogMachineName", "LogMachineName"),
																																																							 new System.Data.Common.DataColumnMapping("LogMAchineIP", "LogMAchineIP")})});
			this.oleDbDataAdapterLogFile.UpdateCommand = this.oleDbUpdateCommand9;
			// 
			// oleDbDeleteCommand9
			// 
			this.oleDbDeleteCommand9.CommandText = @"DELETE FROM SEC_LogFile WHERE (LogRecID = ?) AND (LogInDate = ?) AND (LogMAchineIP = ? OR ? IS NULL AND LogMAchineIP IS NULL) AND (LogMachineName = ? OR ? IS NULL AND LogMachineName IS NULL) AND (LogOutDate = ? OR ? IS NULL AND LogOutDate IS NULL) AND (UserID = ? OR ? IS NULL AND UserID IS NULL)";
			this.oleDbDeleteCommand9.Connection = this.oleDbConnection2;
			this.oleDbDeleteCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LogRecID", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(9)), ((System.Byte)(0)), "LogRecID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LogInDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LogInDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LogMAchineIP", System.Data.OleDb.OleDbType.VarChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LogMAchineIP", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LogMAchineIP1", System.Data.OleDb.OleDbType.VarChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LogMAchineIP", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LogMachineName", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LogMachineName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LogMachineName1", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LogMachineName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LogOutDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LogOutDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LogOutDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LogOutDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand9
			// 
			this.oleDbInsertCommand9.CommandText = "INSERT INTO SEC_LogFile (UserID, LogMachineName, LogMAchineIP) VALUES (?, ?, ?); " +
				"SELECT LogRecID, UserID, LogInDate, LogOutDate, LogMachineName, LogMAchineIP FRO" +
				"M SEC_LogFile WHERE (LogRecID = @@IDENTITY)";
			this.oleDbInsertCommand9.Connection = this.oleDbConnection2;
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("LogMachineName", System.Data.OleDb.OleDbType.VarChar, 180, "LogMachineName"));
			this.oleDbInsertCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("LogMAchineIP", System.Data.OleDb.OleDbType.VarChar, 15, "LogMAchineIP"));
			// 
			// oleDbSelectCommand9
			// 
			this.oleDbSelectCommand9.CommandText = "SELECT LogRecID, UserID, LogInDate, LogOutDate, LogMachineName, LogMAchineIP FROM" +
				" SEC_LogFile";
			this.oleDbSelectCommand9.Connection = this.oleDbConnection2;
			// 
			// oleDbUpdateCommand9
			// 
			this.oleDbUpdateCommand9.CommandText = @"UPDATE SEC_LogFile SET UserID = ?, LogInDate = ?, LogOutDate = ?, LogMachineName = ?, LogMAchineIP = ? WHERE (LogRecID = ?) AND (LogInDate = ?) AND (LogMAchineIP = ? OR ? IS NULL AND LogMAchineIP IS NULL) AND (LogMachineName = ? OR ? IS NULL AND LogMachineName IS NULL) AND (LogOutDate = ? OR ? IS NULL AND LogOutDate IS NULL) AND (UserID = ? OR ? IS NULL AND UserID IS NULL); SELECT LogRecID, UserID, LogInDate, LogOutDate, LogMachineName, LogMAchineIP FROM SEC_LogFile WHERE (LogRecID = ?)";
			this.oleDbUpdateCommand9.Connection = this.oleDbConnection2;
			this.oleDbUpdateCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			this.oleDbUpdateCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("LogInDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "LogInDate"));
			this.oleDbUpdateCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("LogOutDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "LogOutDate"));
			this.oleDbUpdateCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("LogMachineName", System.Data.OleDb.OleDbType.VarChar, 180, "LogMachineName"));
			this.oleDbUpdateCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("LogMAchineIP", System.Data.OleDb.OleDbType.VarChar, 15, "LogMAchineIP"));
			this.oleDbUpdateCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LogRecID", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(9)), ((System.Byte)(0)), "LogRecID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LogInDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LogInDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LogMAchineIP", System.Data.OleDb.OleDbType.VarChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LogMAchineIP", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LogMAchineIP1", System.Data.OleDb.OleDbType.VarChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LogMAchineIP", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LogMachineName", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LogMachineName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LogMachineName1", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LogMachineName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LogOutDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LogOutDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LogOutDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LogOutDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand9.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_LogRecID", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(9)), ((System.Byte)(0)), "LogRecID", System.Data.DataRowVersion.Current, null));
			// 
			// oleDbDataAdapterLogin
			// 
			this.oleDbDataAdapterLogin.DeleteCommand = this.oleDbDeleteCommand10;
			this.oleDbDataAdapterLogin.InsertCommand = this.oleDbInsertCommand10;
			this.oleDbDataAdapterLogin.SelectCommand = this.oleDbSelectCommand10;
			this.oleDbDataAdapterLogin.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											new System.Data.Common.DataTableMapping("Table", "SEC_Users", new System.Data.Common.DataColumnMapping[] {
																																																						 new System.Data.Common.DataColumnMapping("UserID", "UserID"),
																																																						 new System.Data.Common.DataColumnMapping("UserName", "UserName"),
																																																						 new System.Data.Common.DataColumnMapping("SecPass", "SecPass"),
																																																						 new System.Data.Common.DataColumnMapping("ChgPassDate", "ChgPassDate"),
																																																						 new System.Data.Common.DataColumnMapping("SecAdministrator", "SecAdministrator"),
																																																						 new System.Data.Common.DataColumnMapping("WinUser", "WinUser")})});
			this.oleDbDataAdapterLogin.UpdateCommand = this.oleDbUpdateCommand10;
			// 
			// oleDbDeleteCommand10
			// 
			this.oleDbDeleteCommand10.CommandText = @"DELETE FROM SEC_Users WHERE (UserID = ?) AND (ChgPassDate = ? OR ? IS NULL AND ChgPassDate IS NULL) AND (SecAdministrator = ? OR ? IS NULL AND SecAdministrator IS NULL) AND (SecPass = ?) AND (UserName = ?) AND (WinUser = ? OR ? IS NULL AND WinUser IS NULL)";
			this.oleDbDeleteCommand10.Connection = this.oleDbConnection2;
			this.oleDbDeleteCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ChgPassDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ChgPassDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ChgPassDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ChgPassDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecAdministrator", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecAdministrator", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecAdministrator1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecAdministrator", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecPass", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecPass", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserName", System.Data.OleDb.OleDbType.VarChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WinUser", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WinUser", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WinUser1", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WinUser", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand10
			// 
			this.oleDbInsertCommand10.CommandText = "INSERT INTO SEC_Users(UserName, SecPass, ChgPassDate, SecAdministrator, WinUser) " +
				"VALUES (?, ?, ?, ?, ?); SELECT UserID, UserName, SecPass, ChgPassDate, SecAdmini" +
				"strator, WinUser FROM SEC_Users WHERE (UserID = @@IDENTITY)";
			this.oleDbInsertCommand10.Connection = this.oleDbConnection2;
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserName", System.Data.OleDb.OleDbType.VarChar, 60, "UserName"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("SecPass", System.Data.OleDb.OleDbType.VarChar, 180, "SecPass"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("ChgPassDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ChgPassDate"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("SecAdministrator", System.Data.OleDb.OleDbType.Boolean, 1, "SecAdministrator"));
			this.oleDbInsertCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("WinUser", System.Data.OleDb.OleDbType.VarChar, 120, "WinUser"));
			// 
			// oleDbSelectCommand10
			// 
			this.oleDbSelectCommand10.CommandText = "SELECT UserID, UserName, SecPass, ChgPassDate, SecAdministrator, WinUser FROM SEC" +
				"_Users WHERE (UserName = ?) AND (SecPass = ?)";
			this.oleDbSelectCommand10.Connection = this.oleDbConnection2;
			this.oleDbSelectCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserName", System.Data.OleDb.OleDbType.VarChar, 60, "UserName"));
			this.oleDbSelectCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("SecPass", System.Data.OleDb.OleDbType.VarChar, 180, "SecPass"));
			// 
			// oleDbUpdateCommand10
			// 
			this.oleDbUpdateCommand10.CommandText = @"UPDATE SEC_Users SET UserName = ?, SecPass = ?, ChgPassDate = ?, SecAdministrator = ?, WinUser = ? WHERE (UserID = ?) AND (ChgPassDate = ? OR ? IS NULL AND ChgPassDate IS NULL) AND (SecAdministrator = ? OR ? IS NULL AND SecAdministrator IS NULL) AND (SecPass = ?) AND (UserName = ?) AND (WinUser = ? OR ? IS NULL AND WinUser IS NULL); SELECT UserID, UserName, SecPass, ChgPassDate, SecAdministrator, WinUser FROM SEC_Users WHERE (UserID = ?)";
			this.oleDbUpdateCommand10.Connection = this.oleDbConnection2;
			this.oleDbUpdateCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserName", System.Data.OleDb.OleDbType.VarChar, 60, "UserName"));
			this.oleDbUpdateCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("SecPass", System.Data.OleDb.OleDbType.VarChar, 180, "SecPass"));
			this.oleDbUpdateCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("ChgPassDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ChgPassDate"));
			this.oleDbUpdateCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("SecAdministrator", System.Data.OleDb.OleDbType.Boolean, 1, "SecAdministrator"));
			this.oleDbUpdateCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("WinUser", System.Data.OleDb.OleDbType.VarChar, 120, "WinUser"));
			this.oleDbUpdateCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ChgPassDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ChgPassDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ChgPassDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ChgPassDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecAdministrator", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecAdministrator", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecAdministrator1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecAdministrator", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecPass", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecPass", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserName", System.Data.OleDb.OleDbType.VarChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WinUser", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WinUser", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WinUser1", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WinUser", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand10.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			// 
			// dataSetUsrGrpRulGrp1
			// 
			this.dataSetUsrGrpRulGrp1.DataSetName = "DataSetUsrGrpRulGrp";
			this.dataSetUsrGrpRulGrp1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dataSetUsrGroup1
			// 
			this.dataSetUsrGroup1.DataSetName = "DataSetUsrGroup";
			this.dataSetUsrGroup1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dataSetRules1
			// 
			this.dataSetRules1.DataSetName = "DataSetRules";
			this.dataSetRules1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dataSetRuleGroup1
			// 
			this.dataSetRuleGroup1.DataSetName = "DataSetRuleGroup";
			this.dataSetRuleGroup1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dataSetRlEntRlGrp1
			// 
			this.dataSetRlEntRlGrp1.DataSetName = "DataSetRlEntRlGrp";
			this.dataSetRlEntRlGrp1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dataSetLogFile1
			// 
			this.dataSetLogFile1.DataSetName = "DataSetLogFile";
			this.dataSetLogFile1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dataSetGroups1
			// 
			this.dataSetGroups1.DataSetName = "DataSetGroups";
			this.dataSetGroups1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbDataAdapterRuleEntity
			// 
			this.oleDbDataAdapterRuleEntity.DeleteCommand = this.oleDbDeleteCommand5;
			this.oleDbDataAdapterRuleEntity.InsertCommand = this.oleDbInsertCommand5;
			this.oleDbDataAdapterRuleEntity.SelectCommand = this.oleDbSelectCommand5;
			this.oleDbDataAdapterRuleEntity.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												 new System.Data.Common.DataTableMapping("Table", "SEC_RuleEntity", new System.Data.Common.DataColumnMapping[] {
																																																								   new System.Data.Common.DataColumnMapping("RuleEntityID", "RuleEntityID"),
																																																								   new System.Data.Common.DataColumnMapping("RuleID", "RuleID"),
																																																								   new System.Data.Common.DataColumnMapping("RuleEntityValue", "RuleEntityValue"),
																																																								   new System.Data.Common.DataColumnMapping("RuleEntityDescription", "RuleEntityDescription")})});
			this.oleDbDataAdapterRuleEntity.UpdateCommand = this.oleDbUpdateCommand5;
			// 
			// oleDbDeleteCommand5
			// 
			this.oleDbDeleteCommand5.CommandText = "DELETE FROM SEC_RuleEntity WHERE (RuleEntityID = ?) AND (RuleEntityDescription = " +
				"? OR ? IS NULL AND RuleEntityDescription IS NULL) AND (RuleEntityValue = ? OR ? " +
				"IS NULL AND RuleEntityValue IS NULL) AND (RuleID = ? OR ? IS NULL AND RuleID IS " +
				"NULL)";
			this.oleDbDeleteCommand5.Connection = this.oleDbConnection2;
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityDescription", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityDescription1", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityValue", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityValue1", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityValue", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand5
			// 
			this.oleDbInsertCommand5.CommandText = "INSERT INTO SEC_RuleEntity(RuleID, RuleEntityValue, RuleEntityDescription) VALUES" +
				" (?, ?, ?); SELECT RuleEntityID, RuleID, RuleEntityValue, RuleEntityDescription " +
				"FROM SEC_RuleEntity WHERE (RuleEntityID = @@IDENTITY)";
			this.oleDbInsertCommand5.Connection = this.oleDbConnection2;
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleID", System.Data.OleDb.OleDbType.Integer, 4, "RuleID"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, "RuleEntityValue"));
			this.oleDbInsertCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityDescription", System.Data.OleDb.OleDbType.VarChar, 200, "RuleEntityDescription"));
			// 
			// oleDbSelectCommand5
			// 
			this.oleDbSelectCommand5.CommandText = "SELECT RuleEntityID, RuleID, RuleEntityValue, RuleEntityDescription FROM SEC_Rule" +
				"Entity";
			this.oleDbSelectCommand5.Connection = this.oleDbConnection2;
			// 
			// oleDbUpdateCommand5
			// 
			this.oleDbUpdateCommand5.CommandText = @"UPDATE SEC_RuleEntity SET RuleID = ?, RuleEntityValue = ?, RuleEntityDescription = ? WHERE (RuleEntityID = ?) AND (RuleEntityDescription = ? OR ? IS NULL AND RuleEntityDescription IS NULL) AND (RuleEntityValue = ? OR ? IS NULL AND RuleEntityValue IS NULL) AND (RuleID = ? OR ? IS NULL AND RuleID IS NULL); SELECT RuleEntityID, RuleID, RuleEntityValue, RuleEntityDescription FROM SEC_RuleEntity WHERE (RuleEntityID = ?)";
			this.oleDbUpdateCommand5.Connection = this.oleDbConnection2;
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleID", System.Data.OleDb.OleDbType.Integer, 4, "RuleID"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, "RuleEntityValue"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityDescription", System.Data.OleDb.OleDbType.VarChar, 200, "RuleEntityDescription"));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityDescription", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityDescription1", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityValue", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityValue1", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityValue", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_RuleEntityID", System.Data.OleDb.OleDbType.Integer, 4, "RuleEntityID"));
			// 
			// dataSetRuleEntity1
			// 
			this.dataSetRuleEntity1.DataSetName = "DataSetRuleEntity";
			this.dataSetRuleEntity1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbDataAdapterAllUsersInUserGroup
			// 
			this.oleDbDataAdapterAllUsersInUserGroup.SelectCommand = this.oleDbSelectCommand11;
			this.oleDbDataAdapterAllUsersInUserGroup.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																														  new System.Data.Common.DataTableMapping("Table", "SEC_Users", new System.Data.Common.DataColumnMapping[] {
																																																									   new System.Data.Common.DataColumnMapping("UserName", "UserName"),
																																																									   new System.Data.Common.DataColumnMapping("SecPass", "SecPass"),
																																																									   new System.Data.Common.DataColumnMapping("ChgPassDate", "ChgPassDate"),
																																																									   new System.Data.Common.DataColumnMapping("SecAdministrator", "SecAdministrator"),
																																																									   new System.Data.Common.DataColumnMapping("WinUser", "WinUser"),
																																																									   new System.Data.Common.DataColumnMapping("UserID", "UserID")})});
			// 
			// oleDbSelectCommand11
			// 
			this.oleDbSelectCommand11.CommandText = @"SELECT DISTINCT SEC_Users.UserName, SEC_Users.SecPass, SEC_Users.ChgPassDate, SEC_Users.SecAdministrator, SEC_Users.WinUser, SEC_Users.UserID FROM SEC_Users INNER JOIN SEC_UserXUserGroup ON SEC_Users.UserID = SEC_UserXUserGroup.UserID WHERE (SEC_UserXUserGroup.UserGroupID = ?) ORDER BY SEC_Users.UserName";
			this.oleDbSelectCommand11.Connection = this.oleDbConnection2;
			this.oleDbSelectCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, "UserGroupID"));
			// 
			// dataSetUsersInUsrGrp1
			// 
			this.dataSetUsersInUsrGrp1.DataSetName = "DataSetUsersInUsrGrp";
			this.dataSetUsersInUsrGrp1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbDataAdapterAllEntInRlGr
			// 
			this.oleDbDataAdapterAllEntInRlGr.DeleteCommand = this.oleDbDeleteCommand11;
			this.oleDbDataAdapterAllEntInRlGr.InsertCommand = this.oleDbInsertCommand11;
			this.oleDbDataAdapterAllEntInRlGr.SelectCommand = this.oleDbSelectCommand12;
			this.oleDbDataAdapterAllEntInRlGr.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												   new System.Data.Common.DataTableMapping("Table", "SEC_RuleEntity", new System.Data.Common.DataColumnMapping[] {
																																																									 new System.Data.Common.DataColumnMapping("RuleEntityID", "RuleEntityID"),
																																																									 new System.Data.Common.DataColumnMapping("RuleID", "RuleID"),
																																																									 new System.Data.Common.DataColumnMapping("RuleEntityValue", "RuleEntityValue"),
																																																									 new System.Data.Common.DataColumnMapping("RuleEntityDescription", "RuleEntityDescription")})});
			this.oleDbDataAdapterAllEntInRlGr.UpdateCommand = this.oleDbUpdateCommand11;
			// 
			// oleDbDeleteCommand11
			// 
			this.oleDbDeleteCommand11.CommandText = "DELETE FROM SEC_RuleEntity WHERE (RuleEntityID = ?) AND (RuleEntityDescription = " +
				"? OR ? IS NULL AND RuleEntityDescription IS NULL) AND (RuleEntityValue = ? OR ? " +
				"IS NULL AND RuleEntityValue IS NULL) AND (RuleID = ? OR ? IS NULL AND RuleID IS " +
				"NULL)";
			this.oleDbDeleteCommand11.Connection = this.oleDbConnection2;
			this.oleDbDeleteCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityDescription", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityDescription1", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityValue", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityValue1", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityValue", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand11
			// 
			this.oleDbInsertCommand11.CommandText = "INSERT INTO SEC_RuleEntity(RuleID, RuleEntityValue, RuleEntityDescription) VALUES" +
				" (?, ?, ?)";
			this.oleDbInsertCommand11.Connection = this.oleDbConnection2;
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleID", System.Data.OleDb.OleDbType.Integer, 4, "RuleID"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, "RuleEntityValue"));
			this.oleDbInsertCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityDescription", System.Data.OleDb.OleDbType.VarChar, 200, "RuleEntityDescription"));
			// 
			// oleDbSelectCommand12
			// 
			this.oleDbSelectCommand12.CommandText = @"SELECT SEC_RuleEntity.RuleEntityID, SEC_RuleEntity.RuleID, SEC_RuleEntity.RuleEntityValue, SEC_RuleEntity.RuleEntityDescription FROM SEC_RuleEntity INNER JOIN SEC_RuleEntityXRuleGroup ON SEC_RuleEntity.RuleEntityID = SEC_RuleEntityXRuleGroup.RuleEntityID WHERE (SEC_RuleEntityXRuleGroup.RuleGroupID = ?)";
			this.oleDbSelectCommand12.Connection = this.oleDbConnection2;
			this.oleDbSelectCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleGroupID", System.Data.OleDb.OleDbType.Integer, 4, "RuleGroupID"));
			// 
			// oleDbUpdateCommand11
			// 
			this.oleDbUpdateCommand11.CommandText = @"UPDATE SEC_RuleEntity SET RuleID = ?, RuleEntityValue = ?, RuleEntityDescription = ? WHERE (RuleEntityID = ?) AND (RuleEntityDescription = ? OR ? IS NULL AND RuleEntityDescription IS NULL) AND (RuleEntityValue = ? OR ? IS NULL AND RuleEntityValue IS NULL) AND (RuleID = ? OR ? IS NULL AND RuleID IS NULL)";
			this.oleDbUpdateCommand11.Connection = this.oleDbConnection2;
			this.oleDbUpdateCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleID", System.Data.OleDb.OleDbType.Integer, 4, "RuleID"));
			this.oleDbUpdateCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, "RuleEntityValue"));
			this.oleDbUpdateCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityDescription", System.Data.OleDb.OleDbType.VarChar, 200, "RuleEntityDescription"));
			this.oleDbUpdateCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityDescription", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityDescription1", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityValue", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityValue1", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityValue", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand11.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbDataAdapterUserRuleEntities
			// 
			this.oleDbDataAdapterUserRuleEntities.SelectCommand = this.oleDbSelectCommand14;
			this.oleDbDataAdapterUserRuleEntities.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													   new System.Data.Common.DataTableMapping("Table", "SEC_RuleEntity", new System.Data.Common.DataColumnMapping[] {
																																																										 new System.Data.Common.DataColumnMapping("RuleEntityID", "RuleEntityID"),
																																																										 new System.Data.Common.DataColumnMapping("RuleID", "RuleID"),
																																																										 new System.Data.Common.DataColumnMapping("RuleEntityValue", "RuleEntityValue"),
																																																										 new System.Data.Common.DataColumnMapping("RuleEntityDescription", "RuleEntityDescription"),
																																																										 new System.Data.Common.DataColumnMapping("UserID", "UserID")})});
			// 
			// oleDbSelectCommand14
			// 
			this.oleDbSelectCommand14.CommandText = @"SELECT DISTINCT SEC_RuleEntity.RuleEntityID AS RuleEntityID, SEC_RuleEntity.RuleID AS RuleID, SEC_RuleEntity.RuleEntityValue AS RuleEntityValue, SEC_RuleEntity.RuleEntityDescription AS RuleEntityDescription, SEC_UserXUserGroup.UserID FROM SEC_RuleEntity INNER JOIN SEC_RuleEntityXRuleGroup ON SEC_RuleEntity.RuleEntityID = SEC_RuleEntityXRuleGroup.RuleEntityID INNER JOIN SEC_RuleGroup ON SEC_RuleEntityXRuleGroup.RuleGroupID = SEC_RuleGroup.RuleGroupID INNER JOIN SEC_UsersGroupsXRulesGroups ON SEC_RuleGroup.RuleGroupID = SEC_UsersGroupsXRulesGroups.RuleGroupID INNER JOIN SEC_UsersGroups ON SEC_UsersGroupsXRulesGroups.UserGroupID = SEC_UsersGroups.UserGroupID INNER JOIN SEC_UserXUserGroup ON SEC_UsersGroups.UserGroupID = SEC_UserXUserGroup.UserGroupID WHERE (SEC_RuleEntity.RuleID = ?) AND (SEC_UserXUserGroup.UserID = ?)";
			this.oleDbSelectCommand14.Connection = this.oleDbConnection2;
			this.oleDbSelectCommand14.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleID", System.Data.OleDb.OleDbType.Integer, 4, "RuleID"));
			this.oleDbSelectCommand14.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = "SELECT UserID, UserGroupID FROM SEC_UserXUserGroup";
			this.oleDbSelectCommand3.Connection = this.oleDbConnection2;
			// 
			// oleDbInsertCommand3
			// 
			this.oleDbInsertCommand3.CommandText = "INSERT INTO SEC_UserXUserGroup (UserID, UserGroupID) VALUES (?, ?)";
			this.oleDbInsertCommand3.Connection = this.oleDbConnection2;
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, "UserGroupID"));
			// 
			// oleDbUpdateCommand3
			// 
			this.oleDbUpdateCommand3.CommandText = "UPDATE SEC_UserXUserGroup SET UserID = ?, UserGroupID = ? WHERE (UserGroupID = ?)" +
				" AND (UserID = ?); SELECT UserID, UserGroupID FROM SEC_UserXUserGroup WHERE (Use" +
				"rGroupID = ?) AND (UserID = ?)";
			this.oleDbUpdateCommand3.Connection = this.oleDbConnection2;
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, "UserGroupID"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserGroupID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, "UserGroupID"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			// 
			// oleDbDeleteCommand3
			// 
			this.oleDbDeleteCommand3.CommandText = "DELETE FROM SEC_UserXUserGroup WHERE (UserGroupID = ?) AND (UserID = ?)";
			this.oleDbDeleteCommand3.Connection = this.oleDbConnection2;
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserGroupID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbDataAdapterUsrGroup
			// 
			this.oleDbDataAdapterUsrGroup.DeleteCommand = this.oleDbDeleteCommand3;
			this.oleDbDataAdapterUsrGroup.InsertCommand = this.oleDbInsertCommand3;
			this.oleDbDataAdapterUsrGroup.SelectCommand = this.oleDbSelectCommand3;
			this.oleDbDataAdapterUsrGroup.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											   new System.Data.Common.DataTableMapping("Table", "SEC_UserXUserGroup", new System.Data.Common.DataColumnMapping[] {
																																																									 new System.Data.Common.DataColumnMapping("UserID", "UserID"),
																																																									 new System.Data.Common.DataColumnMapping("UserGroupID", "UserGroupID")})});
			this.oleDbDataAdapterUsrGroup.UpdateCommand = this.oleDbUpdateCommand3;
			// 
			// odcGetContactUserID
			// 
			this.odcGetContactUserID.CommandText = "SELECT UserID FROM GEN_Contacts WHERE (ContactID = ?)";
			this.odcGetContactUserID.Connection = this.oleDbConnection2;
			this.odcGetContactUserID.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			// 
			// odcGetUserContactID
			// 
			this.odcGetUserContactID.CommandText = "SELECT ContactID FROM GEN_Contacts WHERE (UserID = ?)";
			this.odcGetUserContactID.Connection = this.oleDbConnection2;
			this.odcGetUserContactID.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			// 
			// oleDbDataAdapterGetRuleGroup
			// 
			this.oleDbDataAdapterGetRuleGroup.SelectCommand = this.oleDbSelectCommand15;
			this.oleDbDataAdapterGetRuleGroup.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												   new System.Data.Common.DataTableMapping("Table", "SEC_RuleGroup", new System.Data.Common.DataColumnMapping[] {
																																																									new System.Data.Common.DataColumnMapping("RuleGroupID", "RuleGroupID"),
																																																									new System.Data.Common.DataColumnMapping("RuleGroupName", "RuleGroupName")})});
			// 
			// oleDbSelectCommand15
			// 
			this.oleDbSelectCommand15.CommandText = "SELECT RuleGroupID, RuleGroupName FROM SEC_RuleGroup WHERE (RuleGroupID = ?) ORDE" +
				"R BY RuleGroupName";
			this.oleDbSelectCommand15.Connection = this.oleDbConnection2;
			this.oleDbSelectCommand15.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleGroupID", System.Data.OleDb.OleDbType.Integer, 4, "RuleGroupID"));
			// 
			// oleDbDataAdapterGetUserGroup
			// 
			this.oleDbDataAdapterGetUserGroup.SelectCommand = this.oleDbSelectCommand16;
			this.oleDbDataAdapterGetUserGroup.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												   new System.Data.Common.DataTableMapping("Table", "SEC_UsersGroups", new System.Data.Common.DataColumnMapping[] {
																																																									  new System.Data.Common.DataColumnMapping("UserGroupID", "UserGroupID"),
																																																									  new System.Data.Common.DataColumnMapping("UserGroupName", "UserGroupName"),
																																																									  new System.Data.Common.DataColumnMapping("UserGroupType", "UserGroupType")})});
			// 
			// oleDbSelectCommand16
			// 
			this.oleDbSelectCommand16.CommandText = "SELECT UserGroupID, UserGroupName, UserGroupType FROM SEC_UsersGroups WHERE (User" +
				"GroupID = ?) ORDER BY UserGroupName";
			this.oleDbSelectCommand16.Connection = this.oleDbConnection2;
			this.oleDbSelectCommand16.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, "UserGroupID"));
			// 
			// oleDbDataAdapterAllNonUserGroupType
			// 
			this.oleDbDataAdapterAllNonUserGroupType.SelectCommand = this.oleDbSelectCommand17;
			this.oleDbDataAdapterAllNonUserGroupType.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																														  new System.Data.Common.DataTableMapping("Table", "SEC_UsersGroups", new System.Data.Common.DataColumnMapping[] {
																																																											 new System.Data.Common.DataColumnMapping("UserGroupID", "UserGroupID"),
																																																											 new System.Data.Common.DataColumnMapping("UserGroupName", "UserGroupName"),
																																																											 new System.Data.Common.DataColumnMapping("UserGroupType", "UserGroupType")})});
			// 
			// oleDbSelectCommand17
			// 
			this.oleDbSelectCommand17.CommandText = "SELECT UserGroupID, UserGroupName, UserGroupType FROM SEC_UsersGroups WHERE (User" +
				"GroupType = 0) ORDER BY UserGroupName";
			this.oleDbSelectCommand17.Connection = this.oleDbConnection2;
			// 
			// oleDbDataAdapterAllUserRules
			// 
			this.oleDbDataAdapterAllUserRules.SelectCommand = this.oleDbSelectCommand18;
			this.oleDbDataAdapterAllUserRules.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												   new System.Data.Common.DataTableMapping("Table", "SEC_Rules", new System.Data.Common.DataColumnMapping[] {
																																																								new System.Data.Common.DataColumnMapping("RuleID", "RuleID"),
																																																								new System.Data.Common.DataColumnMapping("RuleName", "RuleName"),
																																																								new System.Data.Common.DataColumnMapping("EntityID", "EntityID")})});
			// 
			// oleDbSelectCommand18
			// 
			this.oleDbSelectCommand18.CommandText = @"SELECT DISTINCT SEC_Rules.RuleID, SEC_Rules.RuleName, SEC_Rules.EntityID FROM SEC_RuleEntity INNER JOIN SEC_RuleEntityXRuleGroup ON SEC_RuleEntity.RuleEntityID = SEC_RuleEntityXRuleGroup.RuleEntityID INNER JOIN SEC_RuleGroup ON SEC_RuleEntityXRuleGroup.RuleGroupID = SEC_RuleGroup.RuleGroupID INNER JOIN SEC_UsersGroupsXRulesGroups ON SEC_RuleGroup.RuleGroupID = SEC_UsersGroupsXRulesGroups.RuleGroupID INNER JOIN SEC_UsersGroups ON SEC_UsersGroupsXRulesGroups.UserGroupID = SEC_UsersGroups.UserGroupID INNER JOIN SEC_UserXUserGroup ON SEC_UsersGroups.UserGroupID = SEC_UserXUserGroup.UserGroupID INNER JOIN SEC_Rules ON SEC_RuleEntity.RuleID = SEC_Rules.RuleID WHERE (SEC_UserXUserGroup.UserID = ?)";
			this.oleDbSelectCommand18.Connection = this.oleDbConnection2;
			this.oleDbSelectCommand18.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			// 
			// oleDbDataAdapterNotAssignedUsers
			// 
			this.oleDbDataAdapterNotAssignedUsers.SelectCommand = this.oleDbSelectCommand19;
			this.oleDbDataAdapterNotAssignedUsers.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													   new System.Data.Common.DataTableMapping("Table", "SEC_Users", new System.Data.Common.DataColumnMapping[] {
																																																									new System.Data.Common.DataColumnMapping("UserID", "UserID"),
																																																									new System.Data.Common.DataColumnMapping("UserName", "UserName"),
																																																									new System.Data.Common.DataColumnMapping("SecPass", "SecPass"),
																																																									new System.Data.Common.DataColumnMapping("ChgPassDate", "ChgPassDate"),
																																																									new System.Data.Common.DataColumnMapping("SecAdministrator", "SecAdministrator"),
																																																									new System.Data.Common.DataColumnMapping("WinUser", "WinUser")})});
			// 
			// oleDbSelectCommand19
			// 
			this.oleDbSelectCommand19.CommandText = "SELECT DISTINCT UserID, UserName, SecPass, ChgPassDate, SecAdministrator, WinUser" +
				" FROM SEC_Users WHERE (UserID NOT IN (SELECT DISTINCT SEC_Users.UserID FROM SEC_" +
				"Users iner JOIN GEN_Contacts ON SEC_Users.UserID = GEN_Contacts.UserID))";
			this.oleDbSelectCommand19.Connection = this.oleDbConnection2;
			// 
			// oleDbDataAdapterAllEntities
			// 
			this.oleDbDataAdapterAllEntities.SelectCommand = this.oleDbSelectCommand13;
			this.oleDbDataAdapterAllEntities.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												  new System.Data.Common.DataTableMapping("Table", "SEC_Entities", new System.Data.Common.DataColumnMapping[] {
																																																								  new System.Data.Common.DataColumnMapping("EntityID", "EntityID"),
																																																								  new System.Data.Common.DataColumnMapping("EntityName", "EntityName"),
																																																								  new System.Data.Common.DataColumnMapping("cTableName", "cTableName"),
																																																								  new System.Data.Common.DataColumnMapping("cKeyName", "cKeyName"),
																																																								  new System.Data.Common.DataColumnMapping("cDescription", "cDescription"),
																																																								  new System.Data.Common.DataColumnMapping("cManagerColoum", "cManagerColoum"),
																																																								  new System.Data.Common.DataColumnMapping("cAutoAssginUsers", "cAutoAssginUsers")})});
			// 
			// oleDbSelectCommand13
			// 
			this.oleDbSelectCommand13.CommandText = "SELECT EntityID, EntityName, cTableName, cKeyName, cDescription, cManagerColoum, " +
				"cAutoAssginUsers FROM SEC_Entities";
			this.oleDbSelectCommand13.Connection = this.oleDbConnection2;
			// 
			// dataSetEntities1
			// 
			this.dataSetEntities1.DataSetName = "DataSetEntities";
			this.dataSetEntities1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbDataAdapterAllRuleEntOfEntityAndValue
			// 
			this.oleDbDataAdapterAllRuleEntOfEntityAndValue.SelectCommand = this.oleDbSelectCommand20;
			this.oleDbDataAdapterAllRuleEntOfEntityAndValue.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																																 new System.Data.Common.DataTableMapping("Table", "SEC_RuleEntity", new System.Data.Common.DataColumnMapping[] {
																																																												   new System.Data.Common.DataColumnMapping("RuleEntityID", "RuleEntityID"),
																																																												   new System.Data.Common.DataColumnMapping("RuleID", "RuleID"),
																																																												   new System.Data.Common.DataColumnMapping("RuleEntityValue", "RuleEntityValue"),
																																																												   new System.Data.Common.DataColumnMapping("RuleEntityDescription", "RuleEntityDescription")})});
			// 
			// oleDbSelectCommand20
			// 
			this.oleDbSelectCommand20.CommandText = @"SELECT SEC_RuleEntity.RuleEntityID, SEC_RuleEntity.RuleID, SEC_RuleEntity.RuleEntityValue, SEC_RuleEntity.RuleEntityDescription FROM SEC_Entities INNER JOIN SEC_Rules ON SEC_Entities.EntityID = SEC_Rules.EntityID INNER JOIN SEC_RuleEntity ON SEC_Rules.RuleID = SEC_RuleEntity.RuleID WHERE (SEC_RuleEntity.RuleEntityValue = ?) AND (SEC_Entities.EntityID = ?)";
			this.oleDbSelectCommand20.Connection = this.oleDbConnection2;
			this.oleDbSelectCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, "RuleEntityValue"));
			this.oleDbSelectCommand20.Parameters.Add(new System.Data.OleDb.OleDbParameter("EntityID", System.Data.OleDb.OleDbType.Integer, 4, "EntityID"));
			// 
			// odaGeneralRules
			// 
			this.odaGeneralRules.SelectCommand = this.oleDbSelectCommand21;
			this.odaGeneralRules.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "SEC_RuleEntity", new System.Data.Common.DataColumnMapping[] {
																																																						new System.Data.Common.DataColumnMapping("RuleEntityID", "RuleEntityID"),
																																																						new System.Data.Common.DataColumnMapping("RuleID", "RuleID"),
																																																						new System.Data.Common.DataColumnMapping("RuleEntityValue", "RuleEntityValue"),
																																																						new System.Data.Common.DataColumnMapping("RuleEntityDescription", "RuleEntityDescription")})});
			// 
			// oleDbSelectCommand21
			// 
			this.oleDbSelectCommand21.CommandText = "SELECT RuleEntityID, RuleID, RuleEntityValue, RuleEntityDescription FROM SEC_Rule" +
				"Entity WHERE (RuleEntityValue IS NULL)";
			this.oleDbSelectCommand21.Connection = this.oleDbConnection2;
			// 
			// odcSetHomeLink
			// 
			this.odcSetHomeLink.CommandText = "UPDATE SEC_Users SET UserHomeLink = ? WHERE (UserID = ?)";
			this.odcSetHomeLink.Connection = this.oleDbConnection2;
			this.odcSetHomeLink.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserHomeLink", System.Data.OleDb.OleDbType.Integer, 4, "UserHomeLink"));
			this.odcSetHomeLink.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			// 
			// odcGetHomeLink
			// 
			this.odcGetHomeLink.CommandText = "SELECT UserHomeLink FROM SEC_Users WHERE (UserID = ?)";
			this.odcGetHomeLink.Connection = this.oleDbConnection2;
			this.odcGetHomeLink.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			// 
			// oleDbDataAdapterAllUserRlEnt
			// 
			this.oleDbDataAdapterAllUserRlEnt.SelectCommand = this.oleDbSelectCommand22;
			this.oleDbDataAdapterAllUserRlEnt.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												   new System.Data.Common.DataTableMapping("Table", "SEC_RuleEntity", new System.Data.Common.DataColumnMapping[] {
																																																									 new System.Data.Common.DataColumnMapping("RuleEntityID", "RuleEntityID"),
																																																									 new System.Data.Common.DataColumnMapping("RuleID", "RuleID"),
																																																									 new System.Data.Common.DataColumnMapping("RuleEntityValue", "RuleEntityValue"),
																																																									 new System.Data.Common.DataColumnMapping("RuleEntityDescription", "RuleEntityDescription")})});
			// 
			// oleDbSelectCommand22
			// 
			this.oleDbSelectCommand22.CommandText = @"SELECT SEC_RuleEntity.RuleEntityID, SEC_RuleEntity.RuleID, SEC_RuleEntity.RuleEntityValue, SEC_RuleEntity.RuleEntityDescription FROM SEC_UsersGroups INNER JOIN SEC_UserXUserGroup ON SEC_UsersGroups.UserGroupID = SEC_UserXUserGroup.UserGroupID INNER JOIN SEC_Users ON SEC_UserXUserGroup.UserID = SEC_Users.UserID INNER JOIN SEC_UsersGroupsXRulesGroups ON SEC_UsersGroups.UserGroupID = SEC_UsersGroupsXRulesGroups.UserGroupID INNER JOIN SEC_RuleGroup ON SEC_UsersGroupsXRulesGroups.RuleGroupID = SEC_RuleGroup.RuleGroupID INNER JOIN SEC_RuleEntityXRuleGroup ON SEC_RuleGroup.RuleGroupID = SEC_RuleEntityXRuleGroup.RuleGroupID INNER JOIN SEC_RuleEntity ON SEC_RuleEntityXRuleGroup.RuleEntityID = SEC_RuleEntity.RuleEntityID WHERE (SEC_Users.UserID = ?)";
			this.oleDbSelectCommand22.Connection = this.oleDbConnection2;
			this.oleDbSelectCommand22.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			// 
			// oleDbAdptRlGrpOfEntValueAndEntity
			// 
			this.oleDbAdptRlGrpOfEntValueAndEntity.SelectCommand = this.oleDbSelectCommand23;
			this.oleDbAdptRlGrpOfEntValueAndEntity.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																														new System.Data.Common.DataTableMapping("Table", "SEC_RuleGroup", new System.Data.Common.DataColumnMapping[] {
																																																										 new System.Data.Common.DataColumnMapping("RuleGroupID", "RuleGroupID"),
																																																										 new System.Data.Common.DataColumnMapping("RuleGroupName", "RuleGroupName")})});
			// 
			// oleDbSelectCommand23
			// 
			this.oleDbSelectCommand23.CommandText = @"SELECT DISTINCT SEC_RuleGroup.RuleGroupID, SEC_RuleGroup.RuleGroupName FROM SEC_RuleEntity INNER JOIN SEC_Rules ON SEC_RuleEntity.RuleID = SEC_Rules.RuleID INNER JOIN SEC_RuleEntityXRuleGroup ON SEC_RuleEntity.RuleEntityID = SEC_RuleEntityXRuleGroup.RuleEntityID INNER JOIN SEC_RuleGroup ON SEC_RuleEntityXRuleGroup.RuleGroupID = SEC_RuleGroup.RuleGroupID WHERE (SEC_RuleEntity.RuleEntityValue = ?) AND (SEC_Rules.EntityID = ?)";
			this.oleDbSelectCommand23.Connection = this.oleDbConnection2;
			this.oleDbSelectCommand23.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, "RuleEntityValue"));
			this.oleDbSelectCommand23.Parameters.Add(new System.Data.OleDb.OleDbParameter("EntityID", System.Data.OleDb.OleDbType.Integer, 4, "EntityID"));
			// 
			// odaRulesForEntity
			// 
			this.odaRulesForEntity.SelectCommand = this.odaRulesForEntitySelectCommand;
			this.odaRulesForEntity.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "SEC_Rules", new System.Data.Common.DataColumnMapping[] {
																																																					 new System.Data.Common.DataColumnMapping("RuleID", "RuleID"),
																																																					 new System.Data.Common.DataColumnMapping("RuleName", "RuleName"),
																																																					 new System.Data.Common.DataColumnMapping("EntityID", "EntityID")})});
			// 
			// odaRulesForEntitySelectCommand
			// 
			this.odaRulesForEntitySelectCommand.CommandText = "SELECT RuleID, RuleName, EntityID FROM SEC_Rules WHERE (EntityID = ?) ORDER BY Ru" +
				"leName";
			this.odaRulesForEntitySelectCommand.Connection = this.oleDbConnection2;
			this.odaRulesForEntitySelectCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("EntityID", System.Data.OleDb.OleDbType.Integer, 4, "EntityID"));
			// 
			// oleDbDataAdapterActiveUsers
			// 
			this.oleDbDataAdapterActiveUsers.DeleteCommand = this.oleDbDeleteCommand12;
			this.oleDbDataAdapterActiveUsers.InsertCommand = this.oleDbInsertCommand12;
			this.oleDbDataAdapterActiveUsers.SelectCommand = this.oleDbSelectCommand24;
			this.oleDbDataAdapterActiveUsers.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												  new System.Data.Common.DataTableMapping("Table", "SEC_Users", new System.Data.Common.DataColumnMapping[] {
																																																							   new System.Data.Common.DataColumnMapping("UserID", "UserID"),
																																																							   new System.Data.Common.DataColumnMapping("UserName", "UserName"),
																																																							   new System.Data.Common.DataColumnMapping("SecPass", "SecPass"),
																																																							   new System.Data.Common.DataColumnMapping("ChgPassDate", "ChgPassDate"),
																																																							   new System.Data.Common.DataColumnMapping("SecAdministrator", "SecAdministrator"),
																																																							   new System.Data.Common.DataColumnMapping("WinUser", "WinUser")})});
			this.oleDbDataAdapterActiveUsers.UpdateCommand = this.oleDbUpdateCommand12;
			// 
			// oleDbDeleteCommand12
			// 
			this.oleDbDeleteCommand12.CommandText = @"DELETE FROM SEC_Users WHERE (UserID = ?) AND (ChgPassDate = ? OR ? IS NULL AND ChgPassDate IS NULL) AND (SecAdministrator = ? OR ? IS NULL AND SecAdministrator IS NULL) AND (SecPass = ? OR ? IS NULL AND SecPass IS NULL) AND (UserName = ?) AND (WinUser = ? OR ? IS NULL AND WinUser IS NULL)";
			this.oleDbDeleteCommand12.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ChgPassDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ChgPassDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ChgPassDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ChgPassDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecAdministrator", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecAdministrator", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecAdministrator1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecAdministrator", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecPass", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecPass", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecPass1", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecPass", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserName", System.Data.OleDb.OleDbType.VarChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WinUser", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WinUser", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WinUser1", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WinUser", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"User ID=sa;Data Source=ERP;Tag with column collation when possible=False;Initial Catalog=InitialAccountability;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=HAMDYAHMED;Use Encryption for Data=False;Packet Size=4096";
			// 
			// oleDbInsertCommand12
			// 
			this.oleDbInsertCommand12.CommandText = "INSERT INTO SEC_Users(UserName, SecPass, ChgPassDate, SecAdministrator, WinUser) " +
				"VALUES (?, ?, ?, ?, ?); SELECT UserID, UserName, SecPass, ChgPassDate, SecAdmini" +
				"strator, WinUser FROM SEC_Users WHERE (UserID = @@IDENTITY)";
			this.oleDbInsertCommand12.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserName", System.Data.OleDb.OleDbType.VarChar, 60, "UserName"));
			this.oleDbInsertCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("SecPass", System.Data.OleDb.OleDbType.VarChar, 180, "SecPass"));
			this.oleDbInsertCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("ChgPassDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ChgPassDate"));
			this.oleDbInsertCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("SecAdministrator", System.Data.OleDb.OleDbType.Boolean, 1, "SecAdministrator"));
			this.oleDbInsertCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("WinUser", System.Data.OleDb.OleDbType.VarChar, 120, "WinUser"));
			// 
			// oleDbSelectCommand24
			// 
			this.oleDbSelectCommand24.CommandText = @"SELECT UserID, UserName, SecPass, ChgPassDate, SecAdministrator, WinUser FROM SEC_Users WHERE (UserID IN (SELECT UserID FROM SEC_Users AS SEC_Users_2 WHERE (UserID NOT IN (SELECT UserID FROM GEN_Contacts AS GEN_Contacts WHERE (NOT (UserID IS NULL)))) UNION SELECT GEN_Contacts_1.UserID FROM GEN_Contacts AS GEN_Contacts_1 INNER JOIN GEN_Employees ON GEN_Contacts_1.ContactID = GEN_Employees.ContactID INNER JOIN SEC_Users AS SEC_Users_1 ON GEN_Contacts_1.UserID = SEC_Users_1.UserID WHERE (GEN_Employees.EmployeeStatus = 1)))";
			this.oleDbSelectCommand24.Connection = this.oleDbConnection2;
			// 
			// oleDbUpdateCommand12
			// 
			this.oleDbUpdateCommand12.CommandText = @"UPDATE SEC_Users SET UserName = ?, SecPass = ?, ChgPassDate = ?, SecAdministrator = ?, WinUser = ? WHERE (UserID = ?) AND (ChgPassDate = ? OR ? IS NULL AND ChgPassDate IS NULL) AND (SecAdministrator = ? OR ? IS NULL AND SecAdministrator IS NULL) AND (SecPass = ? OR ? IS NULL AND SecPass IS NULL) AND (UserName = ?) AND (WinUser = ? OR ? IS NULL AND WinUser IS NULL); SELECT UserID, UserName, SecPass, ChgPassDate, SecAdministrator, WinUser FROM SEC_Users WHERE (UserID = ?)";
			this.oleDbUpdateCommand12.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserName", System.Data.OleDb.OleDbType.VarChar, 60, "UserName"));
			this.oleDbUpdateCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("SecPass", System.Data.OleDb.OleDbType.VarChar, 180, "SecPass"));
			this.oleDbUpdateCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("ChgPassDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ChgPassDate"));
			this.oleDbUpdateCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("SecAdministrator", System.Data.OleDb.OleDbType.Boolean, 1, "SecAdministrator"));
			this.oleDbUpdateCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("WinUser", System.Data.OleDb.OleDbType.VarChar, 120, "WinUser"));
			this.oleDbUpdateCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ChgPassDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ChgPassDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ChgPassDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ChgPassDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecAdministrator", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecAdministrator", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecAdministrator1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecAdministrator", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecPass", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecPass", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecPass1", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecPass", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserName", System.Data.OleDb.OleDbType.VarChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WinUser", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WinUser", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WinUser1", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WinUser", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand12.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			// 
			// odaUsers
			// 
			this.odaUsers.DeleteCommand = this.oleDbDeleteCommand1;
			this.odaUsers.InsertCommand = this.oleDbInsertCommand1;
			this.odaUsers.SelectCommand = this.oleDbSelectCommand1;
			this.odaUsers.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							   new System.Data.Common.DataTableMapping("Table", "SEC_Users", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("UserID", "UserID"),
																																																			new System.Data.Common.DataColumnMapping("UserName", "UserName"),
																																																			new System.Data.Common.DataColumnMapping("SecPass", "SecPass"),
																																																			new System.Data.Common.DataColumnMapping("ChgPassDate", "ChgPassDate"),
																																																			new System.Data.Common.DataColumnMapping("SecAdministrator", "SecAdministrator"),
																																																			new System.Data.Common.DataColumnMapping("WinUser", "WinUser")})});
			this.odaUsers.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = @"DELETE FROM SEC_Users WHERE (UserID = ?) AND (ChgPassDate = ? OR ? IS NULL AND ChgPassDate IS NULL) AND (SecAdministrator = ? OR ? IS NULL AND SecAdministrator IS NULL) AND (SecPass = ? OR ? IS NULL AND SecPass IS NULL) AND (UserName = ?) AND (WinUser = ? OR ? IS NULL AND WinUser IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection2;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ChgPassDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ChgPassDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ChgPassDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ChgPassDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecAdministrator", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecAdministrator", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecAdministrator1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecAdministrator", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecPass", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecPass", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecPass1", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecPass", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserName", System.Data.OleDb.OleDbType.VarChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WinUser", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WinUser", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WinUser1", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WinUser", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO SEC_Users(UserName, SecPass, ChgPassDate, SecAdministrator, WinUser) " +
				"VALUES (?, ?, ?, ?, ?); SELECT UserID, UserName, SecPass, ChgPassDate, SecAdmini" +
				"strator, WinUser FROM SEC_Users WHERE (UserID = @@IDENTITY)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection2;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserName", System.Data.OleDb.OleDbType.VarChar, 60, "UserName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("SecPass", System.Data.OleDb.OleDbType.VarChar, 180, "SecPass"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ChgPassDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ChgPassDate"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("SecAdministrator", System.Data.OleDb.OleDbType.Boolean, 1, "SecAdministrator"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WinUser", System.Data.OleDb.OleDbType.VarChar, 120, "WinUser"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT UserID, UserName, SecPass, ChgPassDate, SecAdministrator, WinUser FROM SEC" +
				"_Users ORDER BY UserName";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection2;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE SEC_Users SET UserName = ?, SecPass = ?, ChgPassDate = ?, SecAdministrator = ?, WinUser = ? WHERE (UserID = ?) AND (ChgPassDate = ? OR ? IS NULL AND ChgPassDate IS NULL) AND (SecAdministrator = ? OR ? IS NULL AND SecAdministrator IS NULL) AND (SecPass = ? OR ? IS NULL AND SecPass IS NULL) AND (UserName = ?) AND (WinUser = ? OR ? IS NULL AND WinUser IS NULL); SELECT UserID, UserName, SecPass, ChgPassDate, SecAdministrator, WinUser FROM SEC_Users WHERE (UserID = ?)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection2;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserName", System.Data.OleDb.OleDbType.VarChar, 60, "UserName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("SecPass", System.Data.OleDb.OleDbType.VarChar, 180, "SecPass"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ChgPassDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ChgPassDate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("SecAdministrator", System.Data.OleDb.OleDbType.Boolean, 1, "SecAdministrator"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WinUser", System.Data.OleDb.OleDbType.VarChar, 120, "WinUser"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ChgPassDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ChgPassDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ChgPassDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ChgPassDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecAdministrator", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecAdministrator", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecAdministrator1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecAdministrator", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecPass", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecPass", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SecPass1", System.Data.OleDb.OleDbType.VarChar, 180, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SecPass", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UserName", System.Data.OleDb.OleDbType.VarChar, 60, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WinUser", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WinUser", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_WinUser1", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "WinUser", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			// 
			// usrDS1
			// 
			this.usrDS1.DataSetName = "UsrDS";
			this.usrDS1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbDataAdapterVisitLog
			// 
			this.oleDbDataAdapterVisitLog.InsertCommand = this.oleDbCommandVisitLogInsert;
			this.oleDbDataAdapterVisitLog.SelectCommand = this.oleDbSelectCommand25;
			this.oleDbDataAdapterVisitLog.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											   new System.Data.Common.DataTableMapping("Table", "SEC_VisitLog", new System.Data.Common.DataColumnMapping[] {
																																																							   new System.Data.Common.DataColumnMapping("id", "id"),
																																																							   new System.Data.Common.DataColumnMapping("username", "username"),
																																																							   new System.Data.Common.DataColumnMapping("signintime", "signintime"),
																																																							   new System.Data.Common.DataColumnMapping("signouttime", "signouttime"),
																																																							   new System.Data.Common.DataColumnMapping("SessionID", "SessionID"),
																																																							   new System.Data.Common.DataColumnMapping("offline", "offline")})});
			this.oleDbDataAdapterVisitLog.UpdateCommand = this.oleDbCommandVisitLogUpdate;
			// 
			// oleDbCommandVisitLogInsert
			// 
			this.oleDbCommandVisitLogInsert.CommandText = "INSERT INTO SEC_VisitLog (username, signintime, SessionID, offline) VALUES (?, ?," +
				" ?, ?)";
			this.oleDbCommandVisitLogInsert.Connection = this.oleDbConnection2;
			this.oleDbCommandVisitLogInsert.Parameters.Add(new System.Data.OleDb.OleDbParameter("username", System.Data.OleDb.OleDbType.VarChar, 100, "username"));
			this.oleDbCommandVisitLogInsert.Parameters.Add(new System.Data.OleDb.OleDbParameter("signintime", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "signintime"));
			this.oleDbCommandVisitLogInsert.Parameters.Add(new System.Data.OleDb.OleDbParameter("SessionID", System.Data.OleDb.OleDbType.VarWChar, 50, "SessionID"));
			this.oleDbCommandVisitLogInsert.Parameters.Add(new System.Data.OleDb.OleDbParameter("offline", System.Data.OleDb.OleDbType.Boolean, 1, "offline"));
			// 
			// oleDbSelectCommand25
			// 
			this.oleDbSelectCommand25.CommandText = "SELECT MAX(id) AS MaxID FROM SEC_VisitLog";
			this.oleDbSelectCommand25.Connection = this.oleDbConnection2;
			// 
			// oleDbCommandVisitLogUpdate
			// 
			this.oleDbCommandVisitLogUpdate.CommandText = "UPDATE SEC_VisitLog SET signouttime = ?, offline = ? WHERE (id = ?)";
			this.oleDbCommandVisitLogUpdate.Connection = this.oleDbConnection2;
			this.oleDbCommandVisitLogUpdate.Parameters.Add(new System.Data.OleDb.OleDbParameter("signouttime", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "signouttime"));
			this.oleDbCommandVisitLogUpdate.Parameters.Add(new System.Data.OleDb.OleDbParameter("offline", System.Data.OleDb.OleDbType.Boolean, 1, "offline"));
			this.oleDbCommandVisitLogUpdate.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "id", System.Data.DataRowVersion.Original, null));
			// 
			// cmdGetUserNameByEmpCode
			// 
			this.cmdGetUserNameByEmpCode.CommandText = "SELECT SEC_Users.UserName FROM GEN_Contacts INNER JOIN GEN_Employees ON GEN_Conta" +
				"cts.ContactID = GEN_Employees.ContactID INNER JOIN SEC_Users ON GEN_Contacts.Use" +
				"rID = SEC_Users.UserID WHERE (GEN_Employees.EmpCode = ?)";
			this.cmdGetUserNameByEmpCode.Connection = this.oleDbConnection2;
			this.cmdGetUserNameByEmpCode.Parameters.Add(new System.Data.OleDb.OleDbParameter("EmpCode", System.Data.OleDb.OleDbType.VarChar, 6, "EmpCode"));
			// 
			// cmdGetUserData
			// 
			this.cmdGetUserData.CommandText = "SELECT SEC_Users.UserName, SEC_Users.SecPass FROM GEN_Contacts INNER JOIN GEN_Emp" +
				"loyees ON GEN_Contacts.ContactID = GEN_Employees.ContactID INNER JOIN SEC_Users " +
				"ON GEN_Contacts.UserID = SEC_Users.UserID WHERE (GEN_Employees.EmpCode = ?)";
			this.cmdGetUserData.Connection = this.oleDbConnection2;
			this.cmdGetUserData.Parameters.Add(new System.Data.OleDb.OleDbParameter("EmpCode", System.Data.OleDb.OleDbType.VarChar, 6, "EmpCode"));
			// 
			// oleDbDataAdapterGetUserRlEnt
			// 
			this.oleDbDataAdapterGetUserRlEnt.SelectCommand = this.oleDbCommand1;
			this.oleDbDataAdapterGetUserRlEnt.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												   new System.Data.Common.DataTableMapping("Table", "SEC_RuleEntity", new System.Data.Common.DataColumnMapping[] {
																																																									 new System.Data.Common.DataColumnMapping("RuleEntityID", "RuleEntityID"),
																																																									 new System.Data.Common.DataColumnMapping("RuleID", "RuleID"),
																																																									 new System.Data.Common.DataColumnMapping("RuleEntityValue", "RuleEntityValue"),
																																																									 new System.Data.Common.DataColumnMapping("RuleEntityDescription", "RuleEntityDescription")})});
			// 
			// oleDbCommand1
			// 
			this.oleDbCommand1.CommandText = @"SELECT SEC_RuleEntity.RuleEntityID, SEC_RuleEntity.RuleID, SEC_RuleEntity.RuleEntityValue, SEC_RuleEntity.RuleEntityDescription FROM SEC_UsersGroups INNER JOIN SEC_UserXUserGroup ON SEC_UsersGroups.UserGroupID = SEC_UserXUserGroup.UserGroupID INNER JOIN SEC_Users ON SEC_UserXUserGroup.UserID = SEC_Users.UserID INNER JOIN SEC_UsersGroupsXRulesGroups ON SEC_UsersGroups.UserGroupID = SEC_UsersGroupsXRulesGroups.UserGroupID INNER JOIN SEC_RuleGroup ON SEC_UsersGroupsXRulesGroups.RuleGroupID = SEC_RuleGroup.RuleGroupID INNER JOIN SEC_RuleEntityXRuleGroup ON SEC_RuleGroup.RuleGroupID = SEC_RuleEntityXRuleGroup.RuleGroupID INNER JOIN SEC_RuleEntity ON SEC_RuleEntityXRuleGroup.RuleEntityID = SEC_RuleEntity.RuleEntityID WHERE (SEC_Users.UserID = ?) AND (SEC_RuleEntity.RuleID = ?)";
			this.oleDbCommand1.Connection = this.oleDbConnection2;
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleID", System.Data.OleDb.OleDbType.Integer, 4, "RuleID"));
			// 
			// cmdGetUserIdByContactID
			// 
			this.cmdGetUserIdByContactID.CommandText = "SELECT SEC_Users.UserID FROM GEN_Contacts INNER JOIN GEN_Employees ON GEN_Contact" +
				"s.ContactID = GEN_Employees.ContactID INNER JOIN SEC_Users ON GEN_Contacts.UserI" +
				"D = SEC_Users.UserID WHERE (GEN_Employees.ContactID = ?)";
			this.cmdGetUserIdByContactID.Connection = this.oleDbConnection2;
			this.cmdGetUserIdByContactID.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			((System.ComponentModel.ISupportInitialize)(this.dataSetUsrGrpRulGrp1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetUsrGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetRules1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetRuleGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetRlEntRlGrp1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetLogFile1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetGroups1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetRuleEntity1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetUsersInUsrGrp1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetEntities1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.usrDS1)).EndInit();

		}
		#endregion

		#region Functions 

		#region User Management
		
		#region Add User
		/// <summary>
		/// Adding user record in the DB
		/// </summary>
		/// <param name="usrName"></param>
		/// <param name="password"></param>
		/// <param name="administrator">if the user is administrator or not</param>
		/// <param name="winUser">user windows authintication</param>
		/// <returns>integer</returns>

		public int AddUser( string usrName , string password , bool administrator , string winUser )
		{
			int n = -1;

			try
			{
				odaUsers.InsertCommand.Parameters[ 0 ].Value = usrName;
				odaUsers.InsertCommand.Parameters[ 1 ].Value = password;
				odaUsers.InsertCommand.Parameters[ 2 ].Value = DBNull.Value;
				odaUsers.InsertCommand.Parameters[ 3 ].Value = administrator;
				odaUsers.InsertCommand.Parameters[ 4 ].Value = winUser;
		
				n = (int) odaUsers.InsertCommand.ExecuteScalar(); 
				int userGroup = AddUserGroup(usrName,true);
				AddUserToGroup(userGroup,n);
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return n ;
		}
		#endregion

		#region Get All Users
		/// <summary>
		/// get all users
		/// </summary>
		/// <returns>dataset</returns>
		public UsrDS GetAllUsers()
		{
			try
			{
				usrDS1.Clear();
				odaUsers.Fill( usrDS1 );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return usrDS1;
		}
		#endregion

		#region Get All Active Users
		/// <summary>
		/// get all active users
		/// </summary>
		/// <returns>dataset</returns>
		public UsrDS GetAllActiveUsers()
		{
			try
			{
				usrDS1.Clear();
				oleDbDataAdapterActiveUsers.Fill( usrDS1 );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return usrDS1;
		}
		#endregion

		#region Get All Users In User Group
		/// <summary>
		/// get all users
		/// </summary>
		/// <returns>dataset</returns>
		public UsrDS GetAllUsersInGroup( int userGroupID )
		{
			try
			{
				usrDS1.Clear();
				oleDbDataAdapterAllUsersInUserGroup.SelectCommand.Parameters[ "UserGroupID" ].Value = userGroupID;
				oleDbDataAdapterAllUsersInUserGroup.Fill( usrDS1 );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return usrDS1;
		}
		#endregion

		#region Modify User
		/// <summary>
		/// modify user details
		/// </summary>
		/// <param name="ds">dataset contains user information</param>
		/// <returns></returns>
		public bool ModifyUser( DataSet ds )
		{
			int n = 0;

			try
			{
				usrDS1.Clear();
				usrDS1.Merge( ds );
				if ( usrDS1.SEC_Users.Rows.Count != 0 )
				{
					for ( int i = 0 ; i < usrDS1.SEC_Users.Rows.Count ; i++ )
					{
						if ( usrDS1.SEC_Users.Rows[ i ].RowState != DataRowState.Modified )
							usrDS1.SEC_Users.Rows[ i ].RejectChanges();
					}
					n = odaUsers.Update( usrDS1 );
				}
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return Convert.ToBoolean( n );
			
		}
		#endregion

		#region Login 
		/// <summary>
		/// check user information for login
		/// </summary>
		/// <param name="userName">string</param>
		/// <param name="password">string</param>
		/// <returns>boolean: True for successful login , False for unsuccessful login</returns>
		public bool CheckUser( string userName , string password )
		{
			bool login = false;

			try
			{
				usrDS1.Clear();
				oleDbDataAdapterLogin.SelectCommand.Parameters[ 0 ].Value = userName;
				oleDbDataAdapterLogin.SelectCommand.Parameters[ 1 ].Value = password;
				oleDbDataAdapterLogin.Fill( usrDS1 );
				
				if ( usrDS1.SEC_Users.Rows.Count != 0 )
				{
					login = true;
					if (this.oleDbConnection2.State != ConnectionState.Open)
						this.oleDbConnection2.Open();

					oleDbDataAdapterLogFile.InsertCommand.Parameters[ 0 ].Value = usrDS1.SEC_Users[ 0 ].UserID;
					oleDbDataAdapterLogFile.InsertCommand.Parameters[ 1 ].Value = System.Environment.MachineName;
					oleDbDataAdapterLogFile.InsertCommand.Parameters[ 2 ].Value = GetIPAddress();
					oleDbDataAdapterLogFile.InsertCommand.ExecuteNonQuery(); 
				}
				else
					login = false;
			}
			catch ( Exception ee )
			{
				error = ee.Message;
				return false;
			}
			return login;
		}


		private string GetIPAddress()
		{
			string strHostName;
			
			// Getting Ip address of local machine...
			// First get the host name of local machine.
			strHostName = Dns.GetHostName();
			
			// Then using host name, get the IP address list..
			IPHostEntry ipEntry = Dns.GetHostByName(strHostName);
			IPAddress[] addr = ipEntry.AddressList;
          	
			return  addr[0].ToString();
		}    


		#endregion

		#region Get User Rule Entities
		/// <summary>
		/// Get User Rule Entities
		/// </summary>
		/// <returns>dataset</returns>
		public DataSetRuleEntity GetUserRuleEntities( int usrID , int ruleID )
		{
			try
			{
				dataSetRuleEntity1.Clear();
				oleDbDataAdapterUserRuleEntities.SelectCommand.Parameters[ "RuleID" ].Value = ruleID;
				oleDbDataAdapterUserRuleEntities.SelectCommand.Parameters[ "UserID" ].Value = usrID;
				oleDbDataAdapterUserRuleEntities.Fill( dataSetRuleEntity1 );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return dataSetRuleEntity1;
		}
		#endregion

		#region Get All Non Assigned Users 
		/// <summary>
		/// Get All Non Assigned Users 
		/// </summary>
		/// <returns>dataset</returns>
		public UsrDS GetAllNonAssignedUsers ( )
		{
			try
			{
				usrDS1.Clear();
				oleDbDataAdapterNotAssignedUsers.Fill( usrDS1 );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return usrDS1;
		}
		#endregion

		#region Record User Login
		/// <summary>
		/// Record User Sign in time and sign out time
		/// </summary>
		/// <param name="UserName"></param>
		/// <param name="SignInTime"></param>
		/// <param name="SessionID"></param>
		/// <param name="Offline"></param>
		/// <returns></returns>
		public int RecordUserLogin(string UserName, DateTime SignInTime, string SessionID, bool Offline)
		{
			int n = -1;
			try
			{
				oleDbDataAdapterVisitLog.InsertCommand.Parameters[0].Value = UserName;
				oleDbDataAdapterVisitLog.InsertCommand.Parameters[1].Value = SignInTime;
				oleDbDataAdapterVisitLog.InsertCommand.Parameters[2].Value = SessionID;
				oleDbDataAdapterVisitLog.InsertCommand.Parameters[3].Value = Offline;
				oleDbDataAdapterVisitLog.InsertCommand.ExecuteNonQuery();
				n = Convert.ToInt32(oleDbDataAdapterVisitLog.SelectCommand.ExecuteScalar());
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return n;
		}
		#endregion

		#region Update User Login
		/// <summary>
		/// Update User Signout Time
		/// </summary>
		/// <param name="SignOutTime"></param>
		/// <param name="ID"></param>
		/// <returns></returns>
		public int UpdateUserLogin(DateTime SignOutTime, int ID)
		{
			int n = -1;
			try
			{
				oleDbDataAdapterVisitLog.UpdateCommand.Parameters[0].Value = SignOutTime;
				oleDbDataAdapterVisitLog.UpdateCommand.Parameters[1].Value = true;
				oleDbDataAdapterVisitLog.UpdateCommand.Parameters[2].Value = ID;
				n = (int)oleDbDataAdapterVisitLog.UpdateCommand.ExecuteNonQuery();
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return n;
		}
		#endregion
			
		#endregion

		#region Groups Management
		
		#region Add User Group
		/// <summary>
		/// adding user group
		/// </summary>
		/// <param name="groupName"></param>
		/// <returns>integer: holding the added group ID</returns>

		public int AddUserGroup( string groupName)
		{
			return AddUserGroup(groupName,false);
		}
		public int AddUserGroup( string groupName, bool SingleUser )
		{
			int result = -1;

			try
			{
				odaUserGroups.InsertCommand.Parameters[ 0 ].Value = groupName;
				odaUserGroups.InsertCommand.Parameters[ 1 ].Value = SingleUser;
				result = (int) odaUserGroups.InsertCommand.ExecuteScalar();
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return result ;
		}
		#endregion

		#region Get All Users Groups
		/// <summary>
		/// Get all employee assigned in users groups.
		/// </summary>
		/// <returns>DataSetGroups: Containing details of user groups</returns>
		public DataSetGroups GetAllUsersGroups()
		{
			try
			{
				dataSetGroups1.Clear();
				odaUserGroups.Fill( dataSetGroups1 );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return dataSetGroups1;
		}
		#endregion

		#region Get All Non User Groups Type 
		/// <summary>
		///Get all employee don't assigned in users groups.
		/// </summary>
		/// <returns>DataSetGroups: Containing details of non user groups</returns>
		public DataSetGroups AllNonUserGroupsType()
		{
			try
			{
				dataSetGroups1.Clear();
				oleDbDataAdapterAllNonUserGroupType.Fill( dataSetGroups1 );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return dataSetGroups1;
		}
		#endregion

		#region Get UserGroup
		/// <summary>
		/// Get the user group.
		/// </summary>
		/// <param name="userGroupID">int: User group ID</param>
		/// <returns>DataSetGroups: Containg the details of the user group</returns>
		public DataSetGroups GetUserGroup( int userGroupID )
		{
			try
			{
				dataSetGroups1.Clear();
				oleDbDataAdapterGetUserGroup.SelectCommand.Parameters[ "UserGroupID" ].Value = userGroupID;
				oleDbDataAdapterGetUserGroup.Fill( dataSetGroups1 );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return dataSetGroups1;
		}
		#endregion

		#region Modify User Group
		/// <summary>
		/// Modify the user group.
		/// </summary>
		/// <param name="ds">DataSet: Containing user group data to be modified</param>
		/// <returns>bool: If the opration success retruns true,but if not retruns false</returns>
		public bool ModifyUserGroup( DataSet ds )
		{
			int n = 0;

			try
			{
				dataSetGroups1.Clear();
				dataSetGroups1.Merge( ds );
				if ( dataSetGroups1.SEC_UsersGroups.Rows.Count != 0 )
				{
					for ( int i = 0 ; i < dataSetGroups1.SEC_UsersGroups.Rows.Count ; i++ )
					{
						if ( dataSetGroups1.SEC_UsersGroups.Rows[ i ].RowState != DataRowState.Modified && dataSetGroups1.SEC_UsersGroups.Rows[ i ].RowState != DataRowState.Added )
							dataSetGroups1.SEC_UsersGroups.Rows[ i ].RejectChanges();
					}
					n = odaUserGroups.Update( dataSetGroups1 );
				}

			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return Convert.ToBoolean( n );
		}
		#endregion

		#region Delete User Group
		/// <summary>
		/// Delete the user group.
		/// </summary>
		/// <param name="usrGrpID">int: User group ID to be deleted</param>
		/// <returns>bool: If the opration success retruns true,but if not retruns false</returns>
		public bool DeleteUserGroup( int usrGrpID )
		{
			int n = 0;

			try
			{
				odaUserGroups.DeleteCommand.Parameters[ 0 ].Value = usrGrpID;
				n = odaUserGroups.DeleteCommand.ExecuteNonQuery(); 
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return Convert.ToBoolean( n );
		}
		#endregion

		#region Add User To Group
		/// <summary>
		/// Add new user to group.
		/// </summary>
		/// <param name="groupID">int: The giving group ID</param>
		/// <param name="userID">int: The new user ID</param>
		/// <returns>bool: If the opration success retruns true,but if not retruns false</returns>
		public bool AddUserToGroup( int groupID , int userID )
		{
			int n = 0;

			try
			{
				oleDbDataAdapterUsrGroup.InsertCommand.Parameters[ 0 ].Value = userID;
				oleDbDataAdapterUsrGroup.InsertCommand.Parameters[ 1 ].Value = groupID;
				n = oleDbDataAdapterUsrGroup.InsertCommand.ExecuteNonQuery(); 
			}
			catch ( Exception  ee )
			{
				error = ee.Message;
			}
			return Convert.ToBoolean( n );
		}
		#endregion

		#region Remove User from Group
		/// <summary>
		/// Remove User From Group
		/// </summary>
		/// <param name="userID">user id</param>
		/// <param name="userGroupID">user group ID</param>
		/// <returns></returns>
		public bool RemoveUserFromGroup( int userID , int userGroupID )
		{
			int n = 0;

			try
			{
				oleDbDataAdapterUsrGroup.DeleteCommand.Parameters[ 1 ].Value = userID;
				oleDbDataAdapterUsrGroup.DeleteCommand.Parameters[ 0 ].Value = userGroupID;
				n = oleDbDataAdapterUsrGroup.DeleteCommand.ExecuteNonQuery(); 
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return Convert.ToBoolean( n );
		}
		#endregion
		
		#region Modify Users In UserGroup
		/// <summary>
		/// Modify users in user group
		/// </summary>
		/// <param name="ds">DataSet: Containing the data of users to be modified</param>
		/// <returns>bool: If the opration success retruns true,but if not retruns false</returns>
		public bool ModifyUsersInUserGroup( DataSet ds )
		{
			int n = 0;

			try
			{
				dataSetUsrGroup1.Clear();
				dataSetUsrGroup1.Merge( ds );
				if ( dataSetUsrGroup1.SEC_UserXUserGroup.Rows.Count != 0 )
				{
										//					for ( int i = 0 ; i < dataSetUsrGroup1.SEC_UserXUserGroup.Rows.Count ; i++ )
										//					{
										//						if ( dataSetUsrGroup1.SEC_UserXUserGroup.Rows[ i ].RowState != DataRowState.Modified )
										//							dataSetUsrGroup1.SEC_UserXUserGroup.Rows[ i ].RejectChanges();
										//					}
					n = oleDbDataAdapterUsrGroup.Update( dataSetUsrGroup1 );
				}

			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return Convert.ToBoolean( n );
		}
		#endregion

		#endregion

		#region Rules Management
		
		#region Add Rule
		/// <summary>
		/// Adding Rule record in the DB
		/// </summary>
		/// <param name="ruleName">rule name</param>
		/// <returns>Integer: added rule id</returns>

		public int AddRule( string ruleName )
		{
			int n = -1;
			try
			{
				oleDbDataAdapterRules.InsertCommand.Parameters[ 0 ].Value = ruleName;
				n = (int)oleDbDataAdapterRules.InsertCommand.ExecuteScalar(); 
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return n ;
		}
		#endregion

		#region Get All Rules
		/// <summary>
		/// Get All Rules
		/// </summary>
		/// <returns>dataset</returns>
		public DataSetRules GetAllRules()
		{
			try
			{
				dataSetRules1.Clear();
				oleDbDataAdapterRules.Fill( dataSetRules1 );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return dataSetRules1;
		}
		#endregion

		#region Modify Rule
		/// <summary>
		/// Modify Rule
		/// </summary>
		/// <param name="ds">dataset contains rule data</param>
		/// <returns></returns>
		public bool ModifyRule( DataSet ds )
		{
			int n = 0;

			try
			{
				dataSetRules1.Clear();
				dataSetRules1.Merge( ds );
				if ( dataSetRules1.SEC_Rules.Rows.Count != 0 )
				{
					for ( int i = 0 ; i < dataSetRules1.SEC_Rules.Rows.Count ; i++ )
					{
						if ( dataSetRules1.SEC_Rules.Rows[ i ].RowState != DataRowState.Modified )
							dataSetRules1.SEC_Rules.Rows[ i ].RejectChanges();
					}
					n = oleDbDataAdapterRules.Update( dataSetRules1 );
				}
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return Convert.ToBoolean( n );
		}
		#endregion

		#region Add Rule Entity
		/// <summary>
		/// Add Rule Entity
		/// </summary>
		/// <param name="ruleID"></param>
		/// <param name="entityValue"></param>
		/// <returns>Integer: new rule entity id</returns>
		public int AddRuleEntity( int ruleID , string entityValue, string entityDesc )
		{
			int n = -1;

			try
			{
				oleDbDataAdapterRuleEntity.InsertCommand.Parameters[0].Value = ruleID;
				oleDbDataAdapterRuleEntity.InsertCommand.Parameters[1].Value = entityValue;
				oleDbDataAdapterRuleEntity.InsertCommand.Parameters[2].Value = entityDesc;
				n = (int)oleDbDataAdapterRuleEntity.InsertCommand.ExecuteNonQuery();
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return  n ;
		}


		/// <summary>
		/// Add Rule Entity
		/// </summary>
		/// <param name="ruleID"></param>
		/// <returns>Integer: new rule entity id</returns>
		public int AddRuleEntity( int ruleID )
		{
			int n = -1;

			try
			{
				oleDbDataAdapterRuleEntity.InsertCommand.Parameters[ 0 ].Value = ruleID;
				oleDbDataAdapterRuleEntity.InsertCommand.Parameters[ 1 ].Value = null;
				oleDbDataAdapterRuleEntity.InsertCommand.Parameters[2].Value = null;
				n = (int)oleDbDataAdapterRuleEntity.InsertCommand.ExecuteNonQuery(); 
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return  n ;
		}


		#endregion

		#region Remove Rule Entity
		/// <summary>
		/// Remove Rule Entity
		/// </summary>
		/// <param name="ruleEntityID"></param>
		/// <returns></returns>
		public bool RemoveRuleEntity( int ruleEntityID )
		{
			int n = 0;

			try
			{
				oleDbDataAdapterRuleEntity.DeleteCommand.Parameters[ 0 ].Value = ruleEntityID;
				n = oleDbDataAdapterRuleEntity.DeleteCommand.ExecuteNonQuery(); 
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return Convert.ToBoolean( n );
		}
		#endregion

		#region Get All RulesEntities
		/// <summary>
		/// Get All Rule Entities
		/// </summary>
		/// <returns>dataset</returns>
		public DataSetRuleEntity GetAllRulesEntities()
		{
			try
			{
				dataSetRuleEntity1.Clear();
				oleDbDataAdapterRuleEntity.Fill( dataSetRuleEntity1 );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return dataSetRuleEntity1;
		}
		#endregion

		#region Get All User Rules
		/// <summary>
		/// Get All User Rules
		/// </summary>
		/// <returns>dataset</returns>
		public DataSetRules GetAllUserRules( int userID )
		{
			try
			{
				dataSetRules1.Clear();
				oleDbDataAdapterAllUserRules.SelectCommand.Parameters[ "UserID" ].Value = userID;
				oleDbDataAdapterAllUserRules.Fill( dataSetRules1 );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return dataSetRules1;
		}
		#endregion

		#region Get All User RuleEntities
		/// <summary>
		/// Get All User RuleEntities
		/// </summary>
		/// <returns>dataset</returns>
		public DataSetRuleEntity GetAllUserRuleEntities( int userID )
		{
			try
			{
				dataSetRuleEntity1.Clear();
				dataSetRuleEntity1.EnforceConstraints = false;
				oleDbDataAdapterAllUserRlEnt.SelectCommand.Parameters[ "UserID" ].Value = userID;
				oleDbDataAdapterAllUserRlEnt.Fill( dataSetRuleEntity1 );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return dataSetRuleEntity1;
		}
		#endregion
		//oleDbDataAdapterGetUserRlEnt
		#region Check User RuleEntities
		/// <summary>
		/// Get All User RuleEntities
		/// </summary>
		/// <returns>bool</returns>
		public bool CheckUserRuleEntities( int UserID,int RuleID )
		{
			try
			{
				dataSetRuleEntity1.Clear();
				dataSetRuleEntity1.EnforceConstraints = false;
				oleDbDataAdapterGetUserRlEnt.SelectCommand.Parameters[ "UserID" ].Value = UserID;
				oleDbDataAdapterGetUserRlEnt.SelectCommand.Parameters[ "RuleID" ].Value = RuleID;
				oleDbDataAdapterGetUserRlEnt.Fill( dataSetRuleEntity1 );
				if(dataSetRuleEntity1.Tables[0].Rows.Count>0)
					return true;
				else
					return false;

			}
			catch ( Exception ee )
			{
				error = ee.Message;
				return false;
			}
			
		}
		#endregion

		#region GetAllEntities
		/// <summary>
		/// Get all entities.
		/// </summary>
		/// <returns>DataSetEntities:Containing all entities</returns>
		public DataSetEntities GetAllEntities(  )
		{
			oleDbDataAdapterAllEntities.Fill( dataSetEntities1 );
			return dataSetEntities1;
		}

		#endregion

		#region GetAllEntitiesItemsOfEntity
		/// <summary>
		/// Get all entities items of entity.
		/// </summary>
		/// <param name="entityID">int:Entity ID</param>
		/// <returns>DataSet:Containing all entities items of entity</returns>
		public DataSet GetAllEntitiesItemsOfEntity( int entityID )
		{
			oleDbDataAdapterAllEntities.Fill( dataSetEntities1 );
			for ( int i = 0 ; i < dataSetEntities1.SEC_Entities.Rows.Count ; i++ )
			{
				if ( dataSetEntities1.SEC_Entities[ i ].EntityID == entityID )
				{
					DataSet dsEnt = new DataSet();
					System.Data.OleDb.OleDbDataAdapter adp = new System.Data.OleDb.OleDbDataAdapter();
					System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
					cmd.Connection = oleDbConnection2;
					adp.SelectCommand = cmd;

					if ( dataSetEntities1.SEC_Entities[ i ].cTableName.Trim() !=  "GEN_Employees" )
						adp.SelectCommand.CommandText = "select * from " + dataSetEntities1.SEC_Entities[ i ].cTableName ;
					else
						adp.SelectCommand.CommandText = "SELECT  dbo.GEN_Employees.*, dbo.GEN_Contacts.Fullname AS FullName "+
														" FROM dbo.GEN_Employees INNER JOIN "+
														" dbo.GEN_Contacts ON dbo.GEN_Employees.ContactID = dbo.GEN_Contacts.ContactID ORDER BY GEN_Contacts.Fullname";
					
					adp.SelectCommand.Connection = oleDbConnection2;
					adp.Fill( dsEnt );
					return dsEnt;
				}
			}
			return null;
		}
		
		
		#endregion

		#region Get All RulesEntities Of Entity And EntityValue
		/// <summary>
		/// Get all rules entities of entity and entity value.
		/// </summary>
		/// <param name="entityID">int:Entity ID</param>
		/// <param name="entityValue">int:Entity value</param>
		/// <returns>DataSetRuleEntity:Containing all rules entities of entity and entity value</returns>
		public DataSetRuleEntity GetAllRulesEntitiesOfEntityAndEntityValue( int entityID , int entityValue )
		{
			try
			{
				dataSetRuleEntity1.Clear();
				oleDbDataAdapterAllRuleEntOfEntityAndValue.SelectCommand.Parameters[0].Value = entityValue;
				oleDbDataAdapterAllRuleEntOfEntityAndValue.SelectCommand.Parameters[1].Value = entityID;
				oleDbDataAdapterAllRuleEntOfEntityAndValue.Fill( dataSetRuleEntity1 );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return dataSetRuleEntity1;
		}
		#endregion

		#region Get Rule Grpup Of Entity And EntityValue
		/// <summary>
		/// Get Rule Group Of Entity And Entity Value.
		/// </summary>
		/// <param name="entityID">int:Entity ID</param>
		/// <param name="entityValue">int:Entity value</param>
		/// <returns>DataSetRuleGroup:Containing Rule Group Of Entity And Entity Value</returns>
		public DataSetRuleGroup  GetRuleGroupOfEntityAndEntityValue( int entityID , int entityValue )
		{
			try
			{
				dataSetRuleEntity1.Clear();
				oleDbAdptRlGrpOfEntValueAndEntity.SelectCommand.Parameters[0].Value = entityValue;
				oleDbAdptRlGrpOfEntValueAndEntity.SelectCommand.Parameters[1].Value = entityID;
				oleDbAdptRlGrpOfEntValueAndEntity.Fill( dataSetRuleGroup1 );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return dataSetRuleGroup1 ;
		}
		#endregion

		#endregion

		#region Rules Groups Management
		
		#region Add Rule Group
		/// <summary>
		/// Adding new rule group.
		/// </summary>
		/// <param name="groupName">string:The new name for the rule group</param>
		/// <returns>int:Returns the new rule ID in
		public int AddRuleGroup( string groupName )
		{
			int n = -1;

			try
			{
				odaRuleGroup.InsertCommand.Parameters[ 0 ].Value = groupName;
				n = (int) odaRuleGroup.InsertCommand.ExecuteScalar(); 

			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return  n ;
		}
		#endregion

		#region Get All RuleGroups
		/// <summary>
		/// Get all rule groups.
		/// </summary>
		/// <returns>DataSetRuleGroup:Containing all data rule groups</returns>
		public DataSetRuleGroup GetAllRuleGroups()
		{
			try
			{
				dataSetRuleGroup1.Clear();
				odaRuleGroup.Fill( dataSetRuleGroup1 );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return dataSetRuleGroup1;
		}
		#endregion
		
		#region Get RuleGroup
		/// <summary>
		/// Get spcific rule group.
		/// </summary>
		/// <param name="ruleGroupID">int:Rule group ID</param>
		/// <returns>DataSetRuleGroup:Containing rule group</returns>
		public DataSetRuleGroup GetRuleGroup( int ruleGroupID )
		{
			try
			{
				dataSetRuleGroup1.Clear();
				oleDbDataAdapterGetRuleGroup.SelectCommand.Parameters[ "RuleGroupID" ].Value = ruleGroupID;
				oleDbDataAdapterGetRuleGroup.Fill( dataSetRuleGroup1 );
			}
			catch ( Exception ee )
			{ 
				error = ee.Message;
			}
			return dataSetRuleGroup1;
		}
		#endregion
																
		#region Modify Rule Group
		/// <summary>
		/// Modify spacific rule group.
		/// </summar1y> 
		/// <param name="ds">DataSet:Containing data of rule group to be modified</param>
		/// <returns>bool: If the opration success retruns true,but if not retruns false</returns>	
		public bool ModifyRuleGroup( DataSet ds )
		{
			int n = 0;

			try
			{
//				oleDbDataAdapterRuleGroup.UpdateCommand.Parameters[ 0 ].Value = ruleGroupName;
//				oleDbDataAdapterRuleGroup.UpdateCommand.Parameters[ 1 ].Value = ruleGroupID;
//				n = oleDbDataAdapterRuleGroup.UpdateCommand.ExecuteNonQuery(); 

//				dataSetRuleGroup1.Clear();
//				dataSetRuleGroup1.Merge( ds );
//				if ( dataSetRuleGroup1.SEC_RuleGroup.Rows.Count != 0 )
//				{
//					DataSetRuleGroup.SEC_RuleGroupRow row = dataSetRuleGroup1.SEC_RuleGroup.NewSEC_RuleGroupRow();
//					row.RuleGroupID   = dataSetRuleGroup1.SEC_RuleGroup[ 0 ].RuleGroupID;
//					row.RuleGroupName = dataSetRuleGroup1.SEC_RuleGroup[ 0 ].RuleGroupName;
//					dataSetRuleGroup1.SEC_RuleGroup.AddSEC_RuleGroupRow( row );
//					n = oleDbDataAdapterRuleGroup.Update( dataSetRuleGroup1 );
//				}

				dataSetRuleGroup1.Clear();
				dataSetRuleGroup1.Merge( ds );
				if ( dataSetRuleGroup1.SEC_RuleGroup.Rows.Count != 0 )
				{
					for ( int i = 0 ; i < dataSetRuleGroup1.SEC_RuleGroup.Rows.Count ; i++ )
					{
						if ( dataSetRuleGroup1.SEC_RuleGroup.Rows[ i ].RowState != DataRowState.Modified && dataSetRuleGroup1.SEC_RuleGroup.Rows[ i ].RowState != DataRowState.Added )
							dataSetRuleGroup1.SEC_RuleGroup.Rows[ i ].RejectChanges();
					}
					n = odaRuleGroup.Update( dataSetRuleGroup1 );
				}
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return Convert.ToBoolean( n );
			
		}
		#endregion

		#region Delete Rule Group
		/// <summary>
		/// Delete spacific rule group.
		/// </summary>
		/// <param name="usrGrpID">int:Rule group ID to be deleted</param>
		/// <returns>bool: If the opration success retruns true,but if not retruns false</returns>
		public bool DeleteRuleGroup( int rlGrpID )
		{
			int n = 0;

			try
			{
				odaRuleGroup.DeleteCommand.Parameters[ 0 ].Value = rlGrpID;
				n = odaRuleGroup.DeleteCommand.ExecuteNonQuery(); 
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return Convert.ToBoolean( n );
		}
		#endregion
		
		#region Add RuleEntity To RuleGroup
		/// <summary>
		/// Add the rule entity to rule group.
		/// </summary>
		/// <param name="ruleEntityID">int: The new rule entity ID</param>
		/// <param name="ruleGroupID">int: The giving rule group ID</param>
		/// <returns>bool: If the opration success retruns true,but if not retruns false</returns>
		public bool AddRuleEntityToRuleGroup( int ruleEntityID , int ruleGroupID )
		{
			int n = 0;

			try
			{
				oleDbDataAdapterRlEntWithRlGrp.InsertCommand.Parameters[ "RuleEntityID" ].Value = ruleEntityID;
				oleDbDataAdapterRlEntWithRlGrp.InsertCommand.Parameters[ "RuleGroupID" ].Value = ruleGroupID;
				n = oleDbDataAdapterRlEntWithRlGrp.InsertCommand.ExecuteNonQuery(); 

			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return Convert.ToBoolean( n );
		}
		#endregion
		
		#region Remove RuleEntity from RuleGroup
		/// <summary>
		/// Remove Rule Entity From Rule Group
		/// </summary>
		/// <param name="ruleEntityID">int: Rule entity ID</param>
		/// <param name="ruleGroupID">int: Rule group ID</param>
		/// <returns>bool: If the opration success retruns true,but if not retruns false</returns>
		public bool RemoveRuleEntityFromRuleGroup( int ruleEntityID , int ruleGroupID )
		{
			int n = 0;

			try
			{
				oleDbDataAdapterRlEntWithRlGrp.DeleteCommand.Parameters[ 0 ].Value = ruleEntityID;
				oleDbDataAdapterRlEntWithRlGrp.DeleteCommand.Parameters[ 1 ].Value = ruleGroupID;
				n = oleDbDataAdapterRlEntWithRlGrp.DeleteCommand.ExecuteNonQuery(); 
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return Convert.ToBoolean( n );
		}
		#endregion

		#region Modify RulesEntities In RuleGroup
		/// <summary>
		/// Modify rules entities in rule group.
		/// </summary>
		/// <param name="ds">dataset:contains the data of rule entities to be modified</param>
		/// <returns>bool: If the opration success retruns true,but if not retruns false</returns>
		public bool ModifyRulesEntitiesInRuleGroup( DataSet ds )
		{
			int n = 0;

			try
			{
				dataSetRlEntRlGrp1.Clear();
				dataSetRlEntRlGrp1.Merge( ds );
				if ( dataSetRlEntRlGrp1.SEC_RuleEntityXRuleGroup.Rows.Count != 0 )
				{
					//					for ( int i = 0 ; i < dataSetUsrGroup1.SEC_UserXUserGroup.Rows.Count ; i++ )
					//					{
					//						if ( dataSetUsrGroup1.SEC_UserXUserGroup.Rows[ i ].RowState != DataRowState.Modified )
								//							dataSetUsrGroup1.SEC_UserXUserGroup.Rows[ i ].RejectChanges();
					//					}
					n = oleDbDataAdapterRlEntWithRlGrp.Update( dataSetRlEntRlGrp1 );
																}
												
															}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return Convert.ToBoolean( n );
		}
		#endregion
			
		#region Get All RuleEntities in Rule Group
		/// <summary>
		/// Get all rule entities in rule group.
		/// </summary>
		/// <param name="ruleGroupID">int:r The giving rule group ID</param>
		/// <returns>DataSet:Containing data of all rule entities in rule group</returns>
		public DataSet GetAllRuleEntitiesInRuleGroup( int ruleGroupID )
		{
			
			try
			{
				
			dataSetRlEntRlGrp1.Clear();
				oleDbDataAdapterRlEntWithRlGrp.SelectCommand.Parameters[ 0 ].Value = ruleGroupID;
				oleDbDataAdapterRlEntWithRlGrp.Fill( dataSetRlEntRlGrp1 );
//				
//				oleDbDataAdapterTestRlEnt.SelectCommand.Parameters[ 0 ].Value = ruleGroupID;
//				oleDbDataAdapterTestRlEnt.Fill( ds );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return dataSetRlEntRlGrp1;
		}
		#endregion

		#region Add RuleGroup To UserGroup
		/// <summary>
		/// Add new rule group to user group.
		/// </summary>
		/// <param name="userGroupID">int: The giving user group ID</param>
		/// <param name="ruleGroupID">int: The giving rule group ID</param>
		/// <returns>bool: If the opration success retruns true,but if not retruns false</returns>
		public bool AddRuleGroupToUserGroup( int userGroupID , int ruleGroupID )
		{
			int n = 0;

			try
			{
				oleDbDataAdapterUsrGrpRulGrp.InsertCommand.Parameters[ 0 ].Value = userGroupID;
				oleDbDataAdapterUsrGrpRulGrp.InsertCommand.Parameters[ 1 ].Value = ruleGroupID;
				n = oleDbDataAdapterUsrGrpRulGrp.InsertCommand.ExecuteNonQuery(); 

			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return Convert.ToBoolean( n );
		}
		#endregion

		#region Remove RuleGroup from UserGroup
		/// <summary>
		/// Remove rule group from user group.
		/// </summary>
		/// <param name="userGroupID">int:The giving user group ID</param>
		/// <param name="ruleGroupID">int:Rule group ID to be remove</param>
		/// <returns>bool: If the opration success retruns true,but if not retruns falses</returns>
		public bool RemoveRuleGroupFromUserGroup( int userGroupID , int ruleGroupID )
		{
			int n = 0;

			try
			{
				oleDbDataAdapterUsrGrpRulGrp.DeleteCommand.Parameters[ 0 ].Value = ruleGroupID;
				oleDbDataAdapterUsrGrpRulGrp.DeleteCommand.Parameters[ 1 ].Value = userGroupID;
				n = oleDbDataAdapterUsrGrpRulGrp.DeleteCommand.ExecuteNonQuery(); 
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return Convert.ToBoolean( n );
		}
								#endregion

		#region Get All RuleEntities in Rule Group
		/// <summary>
		/// Get all rule entities data in rule group.
		/// </summary>
		/// <param name="ruleGroupID">int:Rule group ID</param>
		/// <returns>DataSetRuleEntity:Containing data of the rule entity</returns>
		public DataSetRuleEntity GetAllRuleEntitiesDataInRuleGroup( int ruleGroupID )
		{
			try
			{
				dataSetRuleEntity1.Clear();
				oleDbDataAdapterAllEntInRlGr.SelectCommand.Parameters[ 0 ].Value = ruleGroupID;
				oleDbDataAdapterAllEntInRlGr.Fill( dataSetRuleEntity1 );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return dataSetRuleEntity1;
		}
		#endregion

		#endregion
		/// <summary>
		/// Set home link for a user.
		/// </summary>
		/// <param name="UserID">int:User ID</param>
		/// <param name="LinkID">int:Link ID</param>
		/// <returns>int:Returns a link ID</returns>
		public int SetHomeLink(int UserID, int LinkID)
		{
			odcSetHomeLink.Parameters[0].Value = LinkID;
			odcSetHomeLink.Parameters[1].Value = UserID;
			return int.Parse(odcSetHomeLink.ExecuteScalar().ToString());
		}
		/// <summary>
		/// Get home link for a user.
		/// </summary>
		/// <param name="UserID">int:User ID</param>
		/// <returns>int:Returns a link ID</returns>
		public int GetHomeLink(int UserID)
		{
			try
			{
				odcGetHomeLink.Parameters[0].Value = UserID;
				object tempObj = odcGetHomeLink.ExecuteScalar();
				if (tempObj == null)
					return -1;
				int retint = (int)tempObj;
				return retint;
			}
			catch (Exception ex)
			{
				error = ex.Message;
				return -1;
			}
		}
		/// <summary>
		/// Get the general rules.
		/// </summary>
		/// <returns>DataSet:Containg a data of the general rules</returns>
		public DataSet GetGeneralRules()
		{
			dataSetRuleEntity1.Clear();
			odaGeneralRules.Fill(dataSetRuleEntity1);
			return dataSetRuleEntity1;
		}
		/// <summary>
		/// Get  user ID for spacific contact.
		/// </summary>
		/// <param name="ContactID">int:Contact ID</param>
		/// <returns>int:Returns the user ID</returns>
		public int GetContactUserID(int ContactID)
		{
			try
			{
				odcGetContactUserID.Parameters[0].Value = ContactID;
				return Convert.ToInt32(odcGetContactUserID.ExecuteScalar());
			}
			catch (Exception ex)
			{
				return -1;
			}
		}
		/// <summary>
		/// Get contact ID for spacific user.
		/// </summary>
		/// <param name="UserID">int:User ID</param>
		/// <returns>int:Returns the contact ID</returns>
		public int GetUserContactID(int UserID)
		{
			try
			{
				odcGetUserContactID.Parameters[0].Value = UserID;
				return Convert.ToInt32(odcGetUserContactID.ExecuteScalar());
			}
			catch (Exception ex)
			{
				return -1;
			}
		}
		#endregion 


		/// <summary>
		/// Get  UserName for spacific Employee Code.
		/// Created By: Sayed Moawad to Manage TSN Timing Application
		/// </summary>
		/// <param name="ContactID">string:EmpCode</param>
		/// <returns>string:Returns the User Name</returns>
		public string mGetUserNameByEmpCode(string VsEmployeeCode,string vsConnectionString)
		{
			try
			{
				oleDbConnection2.ConnectionString=vsConnectionString;
				if (this.oleDbConnection2.State != ConnectionState.Open)
					this.oleDbConnection2.Open();
				cmdGetUserNameByEmpCode.Parameters[0].Value = VsEmployeeCode;
				return Convert.ToString(cmdGetUserNameByEmpCode.ExecuteScalar());
				this.oleDbConnection2.Close();
			}
			catch (Exception ex)
			{
				this.oleDbConnection2.Close();
				return null;
			}
		}

		/// <summary>
		/// Get  UserName for spacific Employee Code.
		/// Created By: Sayed Moawad to Manage TSN Timing Application
		/// </summary>
		/// <param name="ContactID">string:EmpCode</param>
		/// <returns>string:Returns the User Name</returns>
		public int GetUserIDByContactID(int VnContactID)
		{
			try
			{
				//oleDbConnection2.ConnectionString=vsConnectionString;
//				if (this.oleDbConnection2.State != ConnectionState.Open)
//					this.oleDbConnection2.Open();
				cmdGetUserIdByContactID.Parameters[0].Value = VnContactID;
				return Convert.ToInt32(cmdGetUserIdByContactID.ExecuteScalar());
//				this.oleDbConnection2.Close();
			}
			catch (Exception ex)
			{
				//this.oleDbConnection2.Close();
				return -1;
			}
		}

		/// <summary>
		/// Get  UserName for spacific Employee Code.
		/// Created By: Sayed Moawad to Manage TSN Timing Application
		/// </summary>
		/// <param name="ContactID">string:EmpCode</param>
		/// <returns>string:Returns DataSet include User Name and Passord for Contact ID</returns>
		public DataSet mGetUserDataByEmpCode(string VsEmployeeCode,string vsConnectionString)
		{
			try
			{
			    DataSet ds=new DataSet(); 
			    System.Data.OleDb.OleDbDataAdapter dadp=new System.Data.OleDb.OleDbDataAdapter();
				oleDbConnection2.ConnectionString=vsConnectionString;
				cmdGetUserData .Parameters[0].Value = VsEmployeeCode;
				dadp.SelectCommand=cmdGetUserData;
				dadp.Fill(ds);
				return ds;

			}
			catch (Exception ex)
			{
				
				return null;
			}
		}

	
		/// <summary>
		/// Get rules for an entity type.
		/// </summary> 
		/// <param name="Entity">int:Entity ID</param>
		/// <returns>DataSet:Containing rules for an entity type</returns>
		public DataSet GetRulesForEntityType(int Entity) 
		{
			DataSetRules DS = new DataSetRules();
			odaRulesForEntity.SelectCommand.Parameters[0].Value = Entity;
			odaRulesForEntity.Fill(DS);
			return DS;

		}

		#region Properties
		public string Error
		{
			get
			{
				return error;
			}
		}


		public string ConnectionString
		{
			set
			{
				try
				{
					oleDbConnection2.Close();
					oleDbConnection2.ConnectionString = value;
					oleDbConnection2.Open();
				}
				catch ( Exception ee )
				{
					EventLog.WriteEntry("TSN ERP Server : Security Manager",ee.Message,System.Diagnostics.EventLogEntryType.Error);
				}
			}
		}
		#endregion 

		
	}
}
