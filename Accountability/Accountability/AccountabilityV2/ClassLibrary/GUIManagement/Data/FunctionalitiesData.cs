using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace TSN.ERP.GUIManagement.Data
{
	/// <summary>
	/// Summary description for FunctionalitiesData.
	/// </summary>
	public class FunctionalitiesData : TSN.ERP.Engine.BussinesComponent
	{
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private TSN.ERP.GUIManagement.Data.DsFunctionalities dsFunctionalities1;
		public System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterUserFunctionalities;
		public System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterLinkFunctionalities;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FunctionalitiesData(System.ComponentModel.IContainer container)
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

		public FunctionalitiesData()
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
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbDataAdapterUserFunctionalities = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDataAdapterLinkFunctionalities = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			// 
			// oleDbDataAdapter1
			// 
			this.oleDbDataAdapter1.DeleteCommand = this.oleDbDeleteCommand1;
			this.oleDbDataAdapter1.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbDataAdapter1.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "GUI_Functionalities", new System.Data.Common.DataColumnMapping[] {
																																																							   new System.Data.Common.DataColumnMapping("GFunID", "GFunID"),
																																																							   new System.Data.Common.DataColumnMapping("LinkID", "LinkID"),
																																																							   new System.Data.Common.DataColumnMapping("GFunName", "GFunName"),
																																																							   new System.Data.Common.DataColumnMapping("GFunUserControl", "GFunUserControl"),
																																																							   new System.Data.Common.DataColumnMapping("GFunVisible", "GFunVisible")})});
			this.oleDbDataAdapter1.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=BASSAM;Tag with column collation when possible=False;Initial Catalog=ERPdb;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASANT;Use Encryption for Data=False";
			// 
			// oleDbDataAdapterUserFunctionalities
			// 
			this.oleDbDataAdapterUserFunctionalities.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbDataAdapterUserFunctionalities.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																														  new System.Data.Common.DataTableMapping("Table", "GUI_Functionalities", new System.Data.Common.DataColumnMapping[] {
																																																												 new System.Data.Common.DataColumnMapping("GFunID", "GFunID"),
																																																												 new System.Data.Common.DataColumnMapping("LinkID", "LinkID"),
																																																												 new System.Data.Common.DataColumnMapping("GFunName", "GFunName"),
																																																												 new System.Data.Common.DataColumnMapping("GFunUserControl", "GFunUserControl"),
																																																												 new System.Data.Common.DataColumnMapping("GFunVisible", "GFunVisible"),
																																																												 new System.Data.Common.DataColumnMapping("GForder", "GForder")})});
			// 
			// oleDbDataAdapterLinkFunctionalities
			// 
			this.oleDbDataAdapterLinkFunctionalities.SelectCommand = this.oleDbSelectCommand3;
			this.oleDbDataAdapterLinkFunctionalities.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																														  new System.Data.Common.DataTableMapping("Table", "GUI_Functionalities", new System.Data.Common.DataColumnMapping[] {
																																																												 new System.Data.Common.DataColumnMapping("GFunID", "GFunID"),
																																																												 new System.Data.Common.DataColumnMapping("LinkID", "LinkID"),
																																																												 new System.Data.Common.DataColumnMapping("GFunName", "GFunName"),
																																																												 new System.Data.Common.DataColumnMapping("GFunUserControl", "GFunUserControl"),
																																																												 new System.Data.Common.DataColumnMapping("GFunVisible", "GFunVisible")})});
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = "SELECT GFunID, LinkID, GFunName, GFunUserControl, GFunVisible FROM GUI_Functional" +
				"ities WHERE (LinkID = ?)";
			this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("LinkID", System.Data.OleDb.OleDbType.Integer, 4, "LinkID"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT GFunID, LinkID, GFunName, GFunUserControl, GFunVisible FROM GUI_Functional" +
				"ities ORDER BY GForder";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO GUI_Functionalities(LinkID, GFunName, GFunUserControl, GFunVisible) V" +
				"ALUES (?, ?, ?, ?); SELECT GFunID, LinkID, GFunName, GFunUserControl, GFunVisibl" +
				"e FROM GUI_Functionalities WHERE (GFunID = @@IDENTITY) ORDER BY GForder";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("LinkID", System.Data.OleDb.OleDbType.Integer, 4, "LinkID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GFunName", System.Data.OleDb.OleDbType.VarChar, 150, "GFunName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GFunUserControl", System.Data.OleDb.OleDbType.VarChar, 200, "GFunUserControl"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GFunVisible", System.Data.OleDb.OleDbType.Boolean, 1, "GFunVisible"));
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE GUI_Functionalities SET LinkID = ?, GFunName = ?, GFunUserControl = ?, GFunVisible = ? WHERE (GFunID = ?) AND (GFunName = ? OR ? IS NULL AND GFunName IS NULL) AND (GFunUserControl = ? OR ? IS NULL AND GFunUserControl IS NULL) AND (GFunVisible = ? OR ? IS NULL AND GFunVisible IS NULL) AND (LinkID = ? OR ? IS NULL AND LinkID IS NULL); SELECT GFunID, LinkID, GFunName, GFunUserControl, GFunVisible FROM GUI_Functionalities WHERE (GFunID = ?) ORDER BY GForder";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("LinkID", System.Data.OleDb.OleDbType.Integer, 4, "LinkID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GFunName", System.Data.OleDb.OleDbType.VarChar, 150, "GFunName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GFunUserControl", System.Data.OleDb.OleDbType.VarChar, 200, "GFunUserControl"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("GFunVisible", System.Data.OleDb.OleDbType.Boolean, 1, "GFunVisible"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GFunID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GFunID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GFunName", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GFunName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GFunName1", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GFunName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GFunUserControl", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GFunUserControl", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GFunUserControl1", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GFunUserControl", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GFunVisible", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GFunVisible", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GFunVisible1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GFunVisible", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_GFunID", System.Data.OleDb.OleDbType.Integer, 4, "GFunID"));
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = @"DELETE FROM GUI_Functionalities WHERE (GFunID = ?) AND (GFunName = ? OR ? IS NULL AND GFunName IS NULL) AND (GFunUserControl = ? OR ? IS NULL AND GFunUserControl IS NULL) AND (GFunVisible = ? OR ? IS NULL AND GFunVisible IS NULL) AND (LinkID = ? OR ? IS NULL AND LinkID IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GFunID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GFunID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GFunName", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GFunName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GFunName1", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GFunName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GFunUserControl", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GFunUserControl", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GFunUserControl1", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GFunUserControl", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GFunVisible", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GFunVisible", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_GFunVisible1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GFunVisible", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LinkID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinkID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = @"SELECT DISTINCT GUI_Functionalities.GFunID, GUI_Functionalities.LinkID, GUI_Functionalities.GFunName, GUI_Functionalities.GFunUserControl, GUI_Functionalities.GFunVisible, GUI_Functionalities.GForder FROM SEC_RuleEntityXRuleGroup INNER JOIN SEC_RuleEntity ON SEC_RuleEntityXRuleGroup.RuleEntityID = SEC_RuleEntity.RuleEntityID INNER JOIN SEC_RuleGroup ON SEC_RuleEntityXRuleGroup.RuleGroupID = SEC_RuleGroup.RuleGroupID INNER JOIN SEC_Rules ON SEC_RuleEntity.RuleID = SEC_Rules.RuleID INNER JOIN SEC_UsersGroupsXRulesGroups ON SEC_RuleGroup.RuleGroupID = SEC_UsersGroupsXRulesGroups.RuleGroupID INNER JOIN SEC_UsersGroups ON SEC_UsersGroupsXRulesGroups.UserGroupID = SEC_UsersGroups.UserGroupID INNER JOIN SEC_UserXUserGroup ON SEC_UsersGroups.UserGroupID = SEC_UserXUserGroup.UserGroupID INNER JOIN SEC_Users ON SEC_UserXUserGroup.UserID = SEC_Users.UserID INNER JOIN SEC_FunctionalitiesXRules ON SEC_Rules.RuleID = SEC_FunctionalitiesXRules.RuleID INNER JOIN GUI_Functionalities ON SEC_FunctionalitiesXRules.GFunID = GUI_Functionalities.GFunID WHERE (GUI_Functionalities.LinkID = ?) AND (SEC_Users.UserID = ?) ORDER BY GUI_Functionalities.GForder";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("LinkID", System.Data.OleDb.OleDbType.Integer, 4, "LinkID"));
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			// 
			// FunctionalitiesData
			// 
			this.ComponentDataAdabter = this.oleDbDataAdapter1;
			this.Connection = this.oleDbConnection1;

		}
		#endregion
	}
}
