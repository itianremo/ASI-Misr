using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace TSN.ERP.GUIManagement.Data
{
	/// <summary>
	/// Summary description for LinksData.
	/// </summary>
	public class LinksData : TSN.ERP.Engine.BussinesComponent
	{
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
		private TSN.ERP.GUIManagement.Data.DsLinks dsLinks1;
		public System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterUserLinks;
		public System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterModuleLinks;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public LinksData(System.ComponentModel.IContainer container)
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

		public LinksData()
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
			this.oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dsLinks1 = new TSN.ERP.GUIManagement.Data.DsLinks();
			this.oleDbDataAdapterUserLinks = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterModuleLinks = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsLinks1)).BeginInit();
			// 
			// oleDbDataAdapter1
			// 
			this.oleDbDataAdapter1.DeleteCommand = this.oleDbDeleteCommand1;
			this.oleDbDataAdapter1.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbDataAdapter1.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "GUI_Links", new System.Data.Common.DataColumnMapping[] {
																																																					 new System.Data.Common.DataColumnMapping("LinkID", "LinkID"),
																																																					 new System.Data.Common.DataColumnMapping("ModID", "ModID"),
																																																					 new System.Data.Common.DataColumnMapping("LinkCaption", "LinkCaption"),
																																																					 new System.Data.Common.DataColumnMapping("LinkDescription", "LinkDescription"),
																																																					 new System.Data.Common.DataColumnMapping("LinkParent", "LinkParent"),
																																																					 new System.Data.Common.DataColumnMapping("LinkVisible", "LinkVisible")})});
			this.oleDbDataAdapter1.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = @"DELETE FROM GUI_Links WHERE (LinkID = ?) AND (LinkCaption = ? OR ? IS NULL AND LinkCaption IS NULL) AND (LinkDescription = ? OR ? IS NULL AND LinkDescription IS NULL) AND (LinkParent = ? OR ? IS NULL AND LinkParent IS NULL) AND (LinkVisible = ? OR ? IS NULL AND LinkVisible IS NULL) AND (ModID = ? OR ? IS NULL AND ModID IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkCaption", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkCaption", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkCaption1", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkCaption", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkDescription", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkDescription1", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkParent", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkParent", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkParent1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkParent", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkVisible", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkVisible", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkVisible1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkVisible", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ModID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ModID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ModID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ModID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=erp;Tag with column collation when possible=False;Initial Catalog=erpdb4;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASSAM;Use Encryption for Data=False";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO GUI_Links(ModID, LinkCaption, LinkDescription, LinkParent, LinkVisibl" +
				"e) VALUES (?, ?, ?, ?, ?); SELECT LinkID, ModID, LinkCaption, LinkDescription, L" +
				"inkParent, LinkVisible FROM GUI_Links WHERE (LinkID = @@IDENTITY) ORDER BY LinkO" +
				"rder";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ModID", System.Data.OleDb.OleDbType.Integer, 4, "ModID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("LinkCaption", System.Data.OleDb.OleDbType.VarChar, 150, "LinkCaption"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("LinkDescription", System.Data.OleDb.OleDbType.VarChar, 200, "LinkDescription"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("LinkParent", System.Data.OleDb.OleDbType.Integer, 4, "LinkParent"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("LinkVisible", System.Data.OleDb.OleDbType.Boolean, 1, "LinkVisible"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT LinkID, ModID, LinkCaption, LinkDescription, LinkParent, LinkVisible FROM " +
				"GUI_Links ORDER BY LinkOrder";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE GUI_Links SET ModID = ?, LinkCaption = ?, LinkDescription = ?, LinkParent = ?, LinkVisible = ? WHERE (LinkID = ?) AND (LinkCaption = ? OR ? IS NULL AND LinkCaption IS NULL) AND (LinkDescription = ? OR ? IS NULL AND LinkDescription IS NULL) AND (LinkParent = ? OR ? IS NULL AND LinkParent IS NULL) AND (LinkVisible = ? OR ? IS NULL AND LinkVisible IS NULL) AND (ModID = ? OR ? IS NULL AND ModID IS NULL); SELECT LinkID, ModID, LinkCaption, LinkDescription, LinkParent, LinkVisible FROM GUI_Links WHERE (LinkID = ?) ORDER BY LinkOrder";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ModID", System.Data.OleDb.OleDbType.Integer, 4, "ModID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("LinkCaption", System.Data.OleDb.OleDbType.VarChar, 150, "LinkCaption"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("LinkDescription", System.Data.OleDb.OleDbType.VarChar, 200, "LinkDescription"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("LinkParent", System.Data.OleDb.OleDbType.Integer, 4, "LinkParent"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("LinkVisible", System.Data.OleDb.OleDbType.Boolean, 1, "LinkVisible"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkCaption", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkCaption", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkCaption1", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkCaption", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkDescription", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkDescription1", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkParent", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkParent", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkParent1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkParent", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkVisible", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkVisible", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkVisible1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkVisible", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ModID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ModID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ModID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ModID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_LinkID", System.Data.OleDb.OleDbType.Integer, 4, "LinkID"));
			// 
			// dsLinks1
			// 
			this.dsLinks1.DataSetName = "DsLinks";
			this.dsLinks1.EnforceConstraints = false;
			this.dsLinks1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbDataAdapterUserLinks
			// 
			this.oleDbDataAdapterUserLinks.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbDataAdapterUserLinks.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												new System.Data.Common.DataTableMapping("Table", "GUI_Links", new System.Data.Common.DataColumnMapping[] {
																																																							 new System.Data.Common.DataColumnMapping("LinkID", "LinkID"),
																																																							 new System.Data.Common.DataColumnMapping("ModID", "ModID"),
																																																							 new System.Data.Common.DataColumnMapping("LinkCaption", "LinkCaption"),
																																																							 new System.Data.Common.DataColumnMapping("LinkDescription", "LinkDescription"),
																																																							 new System.Data.Common.DataColumnMapping("LinkParent", "LinkParent"),
																																																							 new System.Data.Common.DataColumnMapping("LinkVisible", "LinkVisible"),
																																																							 new System.Data.Common.DataColumnMapping("UserID", "UserID"),
																																																							 new System.Data.Common.DataColumnMapping("LinkOrder", "LinkOrder")})});
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = @"SELECT DISTINCT GUI_Links.LinkID, GUI_Links.ModID, GUI_Links.LinkCaption, GUI_Links.LinkDescription, GUI_Links.LinkParent, GUI_Links.LinkVisible, SEC_Users.UserID, GUI_Links.LinkOrder FROM GUI_Links INNER JOIN GUI_Functionalities ON GUI_Links.LinkID = GUI_Functionalities.LinkID INNER JOIN SEC_FunctionalitiesXRules ON GUI_Functionalities.GFunID = SEC_FunctionalitiesXRules.GFunID INNER JOIN SEC_UsersGroupsXRulesGroups INNER JOIN SEC_RuleEntityXRuleGroup INNER JOIN SEC_RuleEntity ON SEC_RuleEntityXRuleGroup.RuleEntityID = SEC_RuleEntity.RuleEntityID INNER JOIN SEC_RuleGroup ON SEC_RuleEntityXRuleGroup.RuleGroupID = SEC_RuleGroup.RuleGroupID INNER JOIN SEC_Rules ON SEC_RuleEntity.RuleID = SEC_Rules.RuleID ON SEC_UsersGroupsXRulesGroups.RuleGroupID = SEC_RuleGroup.RuleGroupID INNER JOIN SEC_UsersGroups ON SEC_UsersGroupsXRulesGroups.UserGroupID = SEC_UsersGroups.UserGroupID INNER JOIN SEC_UserXUserGroup ON SEC_UsersGroups.UserGroupID = SEC_UserXUserGroup.UserGroupID INNER JOIN SEC_Users ON SEC_UserXUserGroup.UserID = SEC_Users.UserID ON SEC_FunctionalitiesXRules.RuleID = SEC_Rules.RuleID WHERE (GUI_Links.ModID = ?) AND (SEC_Users.UserID = ?) ORDER BY GUI_Links.LinkOrder";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ModID", System.Data.OleDb.OleDbType.Integer, 4, "ModID"));
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			// 
			// oleDbDataAdapterModuleLinks
			// 
			this.oleDbDataAdapterModuleLinks.DeleteCommand = this.oleDbDeleteCommand2;
			this.oleDbDataAdapterModuleLinks.InsertCommand = this.oleDbInsertCommand2;
			this.oleDbDataAdapterModuleLinks.SelectCommand = this.oleDbSelectCommand3;
			this.oleDbDataAdapterModuleLinks.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												  new System.Data.Common.DataTableMapping("Table", "GUI_Links", new System.Data.Common.DataColumnMapping[] {
																																																							   new System.Data.Common.DataColumnMapping("LinkID", "LinkID"),
																																																							   new System.Data.Common.DataColumnMapping("ModID", "ModID"),
																																																							   new System.Data.Common.DataColumnMapping("LinkCaption", "LinkCaption"),
																																																							   new System.Data.Common.DataColumnMapping("LinkDescription", "LinkDescription"),
																																																							   new System.Data.Common.DataColumnMapping("LinkParent", "LinkParent"),
																																																							   new System.Data.Common.DataColumnMapping("LinkVisible", "LinkVisible")})});
			this.oleDbDataAdapterModuleLinks.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = @"DELETE FROM GUI_Links WHERE (LinkID = ?) AND (LinkCaption = ? OR ? IS NULL AND LinkCaption IS NULL) AND (LinkDescription = ? OR ? IS NULL AND LinkDescription IS NULL) AND (LinkParent = ? OR ? IS NULL AND LinkParent IS NULL) AND (LinkVisible = ? OR ? IS NULL AND LinkVisible IS NULL) AND (ModID = ? OR ? IS NULL AND ModID IS NULL)";
			this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkCaption", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkCaption", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkCaption1", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkCaption", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkDescription", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkDescription1", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkParent", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkParent", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkParent1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkParent", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkVisible", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkVisible", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkVisible1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkVisible", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ModID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ModID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ModID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ModID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO GUI_Links(ModID, LinkCaption, LinkDescription, LinkParent, LinkVisibl" +
				"e) VALUES (?, ?, ?, ?, ?); SELECT LinkID, ModID, LinkCaption, LinkDescription, L" +
				"inkParent, LinkVisible FROM GUI_Links WHERE (LinkID = @@IDENTITY) ORDER BY LinkO" +
				"rder";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ModID", System.Data.OleDb.OleDbType.Integer, 4, "ModID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("LinkCaption", System.Data.OleDb.OleDbType.VarChar, 150, "LinkCaption"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("LinkDescription", System.Data.OleDb.OleDbType.VarChar, 200, "LinkDescription"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("LinkParent", System.Data.OleDb.OleDbType.Integer, 4, "LinkParent"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("LinkVisible", System.Data.OleDb.OleDbType.Boolean, 1, "LinkVisible"));
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = "SELECT LinkID, ModID, LinkCaption, LinkDescription, LinkParent, LinkVisible FROM " +
				"GUI_Links WHERE (ModID = ?) ORDER BY LinkOrder";
			this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ModID", System.Data.OleDb.OleDbType.Integer, 4, "ModID"));
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = @"UPDATE GUI_Links SET ModID = ?, LinkCaption = ?, LinkDescription = ?, LinkParent = ?, LinkVisible = ? WHERE (LinkID = ?) AND (LinkCaption = ? OR ? IS NULL AND LinkCaption IS NULL) AND (LinkDescription = ? OR ? IS NULL AND LinkDescription IS NULL) AND (LinkParent = ? OR ? IS NULL AND LinkParent IS NULL) AND (LinkVisible = ? OR ? IS NULL AND LinkVisible IS NULL) AND (ModID = ? OR ? IS NULL AND ModID IS NULL); SELECT LinkID, ModID, LinkCaption, LinkDescription, LinkParent, LinkVisible FROM GUI_Links WHERE (LinkID = ?) ORDER BY LinkOrder";
			this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ModID", System.Data.OleDb.OleDbType.Integer, 4, "ModID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("LinkCaption", System.Data.OleDb.OleDbType.VarChar, 150, "LinkCaption"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("LinkDescription", System.Data.OleDb.OleDbType.VarChar, 200, "LinkDescription"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("LinkParent", System.Data.OleDb.OleDbType.Integer, 4, "LinkParent"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("LinkVisible", System.Data.OleDb.OleDbType.Boolean, 1, "LinkVisible"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkCaption", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkCaption", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkCaption1", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkCaption", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkDescription", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkDescription1", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkParent", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkParent", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkParent1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkParent", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkVisible", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkVisible", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkVisible1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkVisible", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ModID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ModID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ModID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ModID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_LinkID", System.Data.OleDb.OleDbType.Integer, 4, "LinkID"));
			// 
			// LinksData
			// 
			this.ComponentDataAdabter = this.oleDbDataAdapter1;
			this.ComponentDataSet = this.dsLinks1;
			this.Connection = this.oleDbConnection1;
			((System.ComponentModel.ISupportInitialize)(this.dsLinks1)).EndInit();

		}
		#endregion
	}
}
