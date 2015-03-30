using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace TSN.ERP.GUIManagement.Data
{
	/// <summary>
	/// Summary description for ModulesData.
	/// </summary>
	public class ModulesData : TSN.ERP.Engine.BussinesComponent
	{
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private TSN.ERP.GUIManagement.Data.DsModules dsModules1;
		public System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterUserModules;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterModules;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		public System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterModuleUserGroups;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		public System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterRuleGroupsOfUserGroupInModule;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand5;
		public System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterUserGroupsOfRuleGroupInModule;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand6;
		public System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterModuleRulesGroups;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ModulesData(System.ComponentModel.IContainer container)
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

		public ModulesData()
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
			this.oleDbDataAdapterModules = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.dsModules1 = new TSN.ERP.GUIManagement.Data.DsModules();
			this.oleDbDataAdapterUserModules = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDataAdapterModuleRulesGroups = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterModuleUserGroups = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterRuleGroupsOfUserGroupInModule = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterUserGroupsOfRuleGroupInModule = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand6 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsModules1)).BeginInit();
			// 
			// oleDbDataAdapterModules
			// 
			this.oleDbDataAdapterModules.DeleteCommand = this.oleDbDeleteCommand1;
			this.oleDbDataAdapterModules.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbDataAdapterModules.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbDataAdapterModules.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											  new System.Data.Common.DataTableMapping("Table", "GUI_Modules", new System.Data.Common.DataColumnMapping[] {
																																																							 new System.Data.Common.DataColumnMapping("ModID", "ModID"),
																																																							 new System.Data.Common.DataColumnMapping("ModName", "ModName"),
																																																							 new System.Data.Common.DataColumnMapping("ModDescription", "ModDescription")})});
			this.oleDbDataAdapterModules.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=BASSAM;Tag with column collation when possible=False;Initial Catalog=ERPdb;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASANT;Use Encryption for Data=False";
			// 
			// dsModules1
			// 
			this.dsModules1.DataSetName = "DsModules";
			this.dsModules1.EnforceConstraints = false;
			this.dsModules1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbDataAdapterUserModules
			// 
			this.oleDbDataAdapterUserModules.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbDataAdapterUserModules.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												  new System.Data.Common.DataTableMapping("Table", "GUI_Modules", new System.Data.Common.DataColumnMapping[] {
																																																								 new System.Data.Common.DataColumnMapping("ModID", "ModID"),
																																																								 new System.Data.Common.DataColumnMapping("ModName", "ModName"),
																																																								 new System.Data.Common.DataColumnMapping("ModDescription", "ModDescription"),
																																																								 new System.Data.Common.DataColumnMapping("ModOrder", "ModOrder")})});
			// 
			// oleDbDataAdapterModuleRulesGroups
			// 
			this.oleDbDataAdapterModuleRulesGroups.SelectCommand = this.oleDbSelectCommand3;
			this.oleDbDataAdapterModuleRulesGroups.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																														new System.Data.Common.DataTableMapping("Table", "SEC_RuleGroup", new System.Data.Common.DataColumnMapping[] {
																																																										 new System.Data.Common.DataColumnMapping("RuleGroupID", "RuleGroupID"),
																																																										 new System.Data.Common.DataColumnMapping("RuleGroupName", "RuleGroupName")})});
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = @"SELECT DISTINCT SEC_RuleGroup.RuleGroupID, SEC_RuleGroup.RuleGroupName FROM GUI_Functionalities INNER JOIN GUI_Links ON GUI_Functionalities.LinkID = GUI_Links.LinkID INNER JOIN GUI_Modules ON GUI_Links.ModID = GUI_Modules.ModID INNER JOIN SEC_FunctionalitiesXRules ON GUI_Functionalities.GFunID = SEC_FunctionalitiesXRules.GFunID INNER JOIN SEC_RuleEntity ON SEC_FunctionalitiesXRules.RuleID = SEC_RuleEntity.RuleID INNER JOIN SEC_RuleEntityXRuleGroup ON SEC_RuleEntity.RuleEntityID = SEC_RuleEntityXRuleGroup.RuleEntityID INNER JOIN SEC_RuleGroup ON SEC_RuleEntityXRuleGroup.RuleGroupID = SEC_RuleGroup.RuleGroupID INNER JOIN SEC_Rules ON SEC_FunctionalitiesXRules.RuleID = SEC_Rules.RuleID AND SEC_RuleEntity.RuleID = SEC_Rules.RuleID WHERE (GUI_Modules.ModID = ?)";
			this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ModID", System.Data.OleDb.OleDbType.Integer, 4, "ModID"));
			// 
			// oleDbDataAdapterModuleUserGroups
			// 
			this.oleDbDataAdapterModuleUserGroups.SelectCommand = this.oleDbSelectCommand4;
			this.oleDbDataAdapterModuleUserGroups.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													   new System.Data.Common.DataTableMapping("Table", "SEC_UsersGroups", new System.Data.Common.DataColumnMapping[] {
																																																										  new System.Data.Common.DataColumnMapping("UserGroupID", "UserGroupID"),
																																																										  new System.Data.Common.DataColumnMapping("UserGroupName", "UserGroupName"),
																																																										  new System.Data.Common.DataColumnMapping("UserGroupType", "UserGroupType")})});
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = @"SELECT DISTINCT SEC_UsersGroups.UserGroupID, SEC_UsersGroups.UserGroupName, SEC_UsersGroups.UserGroupType FROM GUI_Functionalities INNER JOIN GUI_Links ON GUI_Functionalities.LinkID = GUI_Links.LinkID INNER JOIN GUI_Modules ON GUI_Links.ModID = GUI_Modules.ModID INNER JOIN SEC_FunctionalitiesXRules ON GUI_Functionalities.GFunID = SEC_FunctionalitiesXRules.GFunID INNER JOIN SEC_RuleEntity ON SEC_FunctionalitiesXRules.RuleID = SEC_RuleEntity.RuleID INNER JOIN SEC_RuleEntityXRuleGroup ON SEC_RuleEntity.RuleEntityID = SEC_RuleEntityXRuleGroup.RuleEntityID INNER JOIN SEC_RuleGroup ON SEC_RuleEntityXRuleGroup.RuleGroupID = SEC_RuleGroup.RuleGroupID INNER JOIN SEC_Rules ON SEC_FunctionalitiesXRules.RuleID = SEC_Rules.RuleID AND SEC_RuleEntity.RuleID = SEC_Rules.RuleID INNER JOIN SEC_UsersGroupsXRulesGroups ON SEC_RuleGroup.RuleGroupID = SEC_UsersGroupsXRulesGroups.RuleGroupID INNER JOIN SEC_UsersGroups ON SEC_UsersGroupsXRulesGroups.UserGroupID = SEC_UsersGroups.UserGroupID WHERE (GUI_Modules.ModID = ?)";
			this.oleDbSelectCommand4.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ModID", System.Data.OleDb.OleDbType.Integer, 4, "ModID"));
			// 
			// oleDbDataAdapterRuleGroupsOfUserGroupInModule
			// 
			this.oleDbDataAdapterRuleGroupsOfUserGroupInModule.SelectCommand = this.oleDbSelectCommand5;
			this.oleDbDataAdapterRuleGroupsOfUserGroupInModule.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																																	new System.Data.Common.DataTableMapping("Table", "SEC_RuleGroup", new System.Data.Common.DataColumnMapping[] {
																																																													 new System.Data.Common.DataColumnMapping("RuleGroupID", "RuleGroupID"),
																																																													 new System.Data.Common.DataColumnMapping("RuleGroupName", "RuleGroupName")})});
			// 
			// oleDbSelectCommand5
			// 
			this.oleDbSelectCommand5.CommandText = @"SELECT DISTINCT SEC_RuleGroup.RuleGroupID, SEC_RuleGroup.RuleGroupName FROM GUI_Functionalities INNER JOIN GUI_Links ON GUI_Functionalities.LinkID = GUI_Links.LinkID INNER JOIN GUI_Modules ON GUI_Links.ModID = GUI_Modules.ModID INNER JOIN SEC_FunctionalitiesXRules ON GUI_Functionalities.GFunID = SEC_FunctionalitiesXRules.GFunID INNER JOIN SEC_RuleEntity ON SEC_FunctionalitiesXRules.RuleID = SEC_RuleEntity.RuleID INNER JOIN SEC_RuleEntityXRuleGroup ON SEC_RuleEntity.RuleEntityID = SEC_RuleEntityXRuleGroup.RuleEntityID INNER JOIN SEC_RuleGroup ON SEC_RuleEntityXRuleGroup.RuleGroupID = SEC_RuleGroup.RuleGroupID INNER JOIN SEC_Rules ON SEC_FunctionalitiesXRules.RuleID = SEC_Rules.RuleID AND SEC_RuleEntity.RuleID = SEC_Rules.RuleID INNER JOIN SEC_UsersGroupsXRulesGroups ON SEC_RuleGroup.RuleGroupID = SEC_UsersGroupsXRulesGroups.RuleGroupID INNER JOIN SEC_UsersGroups ON SEC_UsersGroupsXRulesGroups.UserGroupID = SEC_UsersGroups.UserGroupID WHERE (GUI_Modules.ModID = ?) AND (SEC_UsersGroups.UserGroupID = ?) ORDER BY SEC_RuleGroup.RuleGroupName";
			this.oleDbSelectCommand5.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("ModID", System.Data.OleDb.OleDbType.Integer, 4, "ModID"));
			this.oleDbSelectCommand5.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserGroupID", System.Data.OleDb.OleDbType.Integer, 4, "UserGroupID"));
			// 
			// oleDbDataAdapterUserGroupsOfRuleGroupInModule
			// 
			this.oleDbDataAdapterUserGroupsOfRuleGroupInModule.SelectCommand = this.oleDbSelectCommand6;
			this.oleDbDataAdapterUserGroupsOfRuleGroupInModule.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																																	new System.Data.Common.DataTableMapping("Table", "SEC_UsersGroups", new System.Data.Common.DataColumnMapping[] {
																																																													   new System.Data.Common.DataColumnMapping("UserGroupID", "UserGroupID"),
																																																													   new System.Data.Common.DataColumnMapping("UserGroupName", "UserGroupName"),
																																																													   new System.Data.Common.DataColumnMapping("UserGroupType", "UserGroupType")})});
			// 
			// oleDbSelectCommand6
			// 
			this.oleDbSelectCommand6.CommandText = @"SELECT DISTINCT SEC_UsersGroups.UserGroupID, SEC_UsersGroups.UserGroupName, SEC_UsersGroups.UserGroupType FROM GUI_Functionalities INNER JOIN GUI_Links ON GUI_Functionalities.LinkID = GUI_Links.LinkID INNER JOIN GUI_Modules ON GUI_Links.ModID = GUI_Modules.ModID INNER JOIN SEC_FunctionalitiesXRules ON GUI_Functionalities.GFunID = SEC_FunctionalitiesXRules.GFunID INNER JOIN SEC_RuleEntity ON SEC_FunctionalitiesXRules.RuleID = SEC_RuleEntity.RuleID INNER JOIN SEC_RuleEntityXRuleGroup ON SEC_RuleEntity.RuleEntityID = SEC_RuleEntityXRuleGroup.RuleEntityID INNER JOIN SEC_RuleGroup ON SEC_RuleEntityXRuleGroup.RuleGroupID = SEC_RuleGroup.RuleGroupID INNER JOIN SEC_Rules ON SEC_FunctionalitiesXRules.RuleID = SEC_Rules.RuleID AND SEC_RuleEntity.RuleID = SEC_Rules.RuleID INNER JOIN SEC_UsersGroupsXRulesGroups ON SEC_RuleGroup.RuleGroupID = SEC_UsersGroupsXRulesGroups.RuleGroupID INNER JOIN SEC_UsersGroups ON SEC_UsersGroupsXRulesGroups.UserGroupID = SEC_UsersGroups.UserGroupID WHERE (GUI_Modules.ModID = ?) AND (SEC_RuleGroup.RuleGroupID = ?)";
			this.oleDbSelectCommand6.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("ModID", System.Data.OleDb.OleDbType.Integer, 4, "ModID"));
			this.oleDbSelectCommand6.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleGroupID", System.Data.OleDb.OleDbType.Integer, 4, "RuleGroupID"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT ModID, ModName, ModDescription FROM GUI_Modules ORDER BY ModOrder";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO GUI_Modules(ModID, ModName, ModDescription) VALUES (?, ?, ?); SELECT " +
				"ModID, ModName, ModDescription FROM GUI_Modules WHERE (ModID = ?) ORDER BY ModOr" +
				"der";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ModID", System.Data.OleDb.OleDbType.Integer, 4, "ModID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ModName", System.Data.OleDb.OleDbType.VarChar, 150, "ModName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ModDescription", System.Data.OleDb.OleDbType.VarChar, 200, "ModDescription"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_ModID", System.Data.OleDb.OleDbType.Integer, 4, "ModID"));
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE GUI_Modules SET ModID = ?, ModName = ?, ModDescription = ? WHERE (ModID = ?) AND (ModDescription = ? OR ? IS NULL AND ModDescription IS NULL) AND (ModName = ? OR ? IS NULL AND ModName IS NULL); SELECT ModID, ModName, ModDescription FROM GUI_Modules WHERE (ModID = ?) ORDER BY ModOrder";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ModID", System.Data.OleDb.OleDbType.Integer, 4, "ModID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ModName", System.Data.OleDb.OleDbType.VarChar, 150, "ModName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ModDescription", System.Data.OleDb.OleDbType.VarChar, 200, "ModDescription"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ModID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ModID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ModDescription", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ModDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ModDescription1", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ModDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ModName", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ModName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ModName1", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ModName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_ModID", System.Data.OleDb.OleDbType.Integer, 4, "ModID"));
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM GUI_Modules WHERE (ModID = ?) AND (ModDescription = ? OR ? IS NULL AN" +
				"D ModDescription IS NULL) AND (ModName = ? OR ? IS NULL AND ModName IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ModID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ModID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ModDescription", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ModDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ModDescription1", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ModDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ModName", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ModName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ModName1", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ModName", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = @"SELECT DISTINCT GUI_Modules.ModID, GUI_Modules.ModName, GUI_Modules.ModDescription, GUI_Modules.ModOrder FROM GUI_Links INNER JOIN GUI_Functionalities ON GUI_Links.LinkID = GUI_Functionalities.LinkID INNER JOIN GUI_Modules ON GUI_Links.ModID = GUI_Modules.ModID INNER JOIN SEC_FunctionalitiesXRules ON GUI_Functionalities.GFunID = SEC_FunctionalitiesXRules.GFunID INNER JOIN SEC_RuleEntity INNER JOIN SEC_RuleEntityXRuleGroup ON SEC_RuleEntity.RuleEntityID = SEC_RuleEntityXRuleGroup.RuleEntityID INNER JOIN SEC_RuleGroup ON SEC_RuleEntityXRuleGroup.RuleGroupID = SEC_RuleGroup.RuleGroupID INNER JOIN SEC_Rules ON SEC_RuleEntity.RuleID = SEC_Rules.RuleID INNER JOIN SEC_UsersGroupsXRulesGroups ON SEC_RuleGroup.RuleGroupID = SEC_UsersGroupsXRulesGroups.RuleGroupID INNER JOIN SEC_UsersGroups ON SEC_UsersGroupsXRulesGroups.UserGroupID = SEC_UsersGroups.UserGroupID INNER JOIN SEC_UserXUserGroup ON SEC_UsersGroups.UserGroupID = SEC_UserXUserGroup.UserGroupID INNER JOIN SEC_Users ON SEC_UserXUserGroup.UserID = SEC_Users.UserID ON SEC_FunctionalitiesXRules.RuleID = SEC_Rules.RuleID WHERE (SEC_Users.UserID = ?) ORDER BY GUI_Modules.ModOrder";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			// 
			// ModulesData
			// 
			this.ComponentDataAdabter = this.oleDbDataAdapterModules;
			this.ComponentDataSet = this.dsModules1;
			this.Connection = this.oleDbConnection1;
			((System.ComponentModel.ISupportInitialize)(this.dsModules1)).EndInit();

		}
		#endregion
	}
}
