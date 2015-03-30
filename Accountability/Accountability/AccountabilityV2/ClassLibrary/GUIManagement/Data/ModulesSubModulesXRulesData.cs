using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace TSN.ERP.GUIManagement.Data
{
	/// <summary>
	/// Summary description for ModulesSubModulesXRulesData.
	/// </summary>
	public class ModulesSubModulesXRulesData : TSN.ERP.Engine.BussinesComponent
	{
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		public System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterRulesOfSubModules;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		public System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterRulesEntitiesOfSubModules;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ModulesSubModulesXRulesData(System.ComponentModel.IContainer container)
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

		public ModulesSubModulesXRulesData()
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
        //protected override void Dispose( bool disposing )
        //{
        //    if( disposing )
        //    {
        //        if(components != null)
        //        {
        //            components.Dispose();
        //        }
        //    }
        //    base.Dispose( disposing );
        //}


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
			this.oleDbDataAdapterRulesOfSubModules = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterRulesEntitiesOfSubModules = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			// 
			// oleDbDataAdapter1
			// 
			this.oleDbDataAdapter1.DeleteCommand = this.oleDbDeleteCommand1;
			this.oleDbDataAdapter1.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbDataAdapter1.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "SEC_ModulesSubModulesXRules", new System.Data.Common.DataColumnMapping[] {
																																																									   new System.Data.Common.DataColumnMapping("MSMID", "MSMID"),
																																																									   new System.Data.Common.DataColumnMapping("RuleID", "RuleID")})});
			this.oleDbDataAdapter1.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM SEC_ModulesSubModulesXRules WHERE (MSMID = ?) AND (RuleID = ?)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MSMID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MSMID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=BASSAM;Tag with column collation when possible=False;Initial Catalog=ERPdb;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASANT;Use Encryption for Data=False";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO SEC_ModulesSubModulesXRules(MSMID, RuleID) VALUES (?, ?); SELECT MSMI" +
				"D, RuleID FROM SEC_ModulesSubModulesXRules WHERE (MSMID = ?) AND (RuleID = ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("MSMID", System.Data.OleDb.OleDbType.Integer, 4, "MSMID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleID", System.Data.OleDb.OleDbType.Integer, 4, "RuleID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_MSMID", System.Data.OleDb.OleDbType.Integer, 4, "MSMID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_RuleID", System.Data.OleDb.OleDbType.Integer, 4, "RuleID"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT MSMID, RuleID FROM SEC_ModulesSubModulesXRules";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE SEC_ModulesSubModulesXRules SET MSMID = ?, RuleID = ? WHERE (MSMID = ?) AN" +
				"D (RuleID = ?); SELECT MSMID, RuleID FROM SEC_ModulesSubModulesXRules WHERE (MSM" +
				"ID = ?) AND (RuleID = ?)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("MSMID", System.Data.OleDb.OleDbType.Integer, 4, "MSMID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleID", System.Data.OleDb.OleDbType.Integer, 4, "RuleID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MSMID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MSMID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_MSMID", System.Data.OleDb.OleDbType.Integer, 4, "MSMID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_RuleID", System.Data.OleDb.OleDbType.Integer, 4, "RuleID"));
			// 
			// oleDbDataAdapterRulesOfSubModules
			// 
			this.oleDbDataAdapterRulesOfSubModules.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbDataAdapterRulesOfSubModules.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																														new System.Data.Common.DataTableMapping("Table", "SEC_Rules", new System.Data.Common.DataColumnMapping[] {
																																																									 new System.Data.Common.DataColumnMapping("RuleName", "RuleName"),
																																																									 new System.Data.Common.DataColumnMapping("MSMID", "MSMID"),
																																																									 new System.Data.Common.DataColumnMapping("RuleID", "RuleID")})});
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT SEC_Rules.RuleName, SEC_ModulesSubModulesXRules.MSMID, SEC_ModulesSubModul" +
				"esXRules.RuleID FROM SEC_Rules INNER JOIN SEC_ModulesSubModulesXRules ON SEC_Rul" +
				"es.RuleID = SEC_ModulesSubModulesXRules.RuleID WHERE (SEC_ModulesSubModulesXRule" +
				"s.MSMID = ?)";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("MSMID", System.Data.OleDb.OleDbType.Integer, 4, "MSMID"));
			// 
			// oleDbDataAdapterRulesEntitiesOfSubModules
			// 
			this.oleDbDataAdapterRulesEntitiesOfSubModules.DeleteCommand = this.oleDbDeleteCommand2;
			this.oleDbDataAdapterRulesEntitiesOfSubModules.InsertCommand = this.oleDbInsertCommand2;
			this.oleDbDataAdapterRulesEntitiesOfSubModules.SelectCommand = this.oleDbSelectCommand3;
			this.oleDbDataAdapterRulesEntitiesOfSubModules.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																																new System.Data.Common.DataTableMapping("Table", "SEC_RuleEntity", new System.Data.Common.DataColumnMapping[] {
																																																												  new System.Data.Common.DataColumnMapping("RuleEntityID", "RuleEntityID"),
																																																												  new System.Data.Common.DataColumnMapping("RuleID", "RuleID"),
																																																												  new System.Data.Common.DataColumnMapping("RuleEntityValue", "RuleEntityValue"),
																																																												  new System.Data.Common.DataColumnMapping("RuleEntityDescription", "RuleEntityDescription")})});
			this.oleDbDataAdapterRulesEntitiesOfSubModules.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = "DELETE FROM SEC_RuleEntity WHERE (RuleEntityID = ?) AND (RuleEntityDescription = " +
				"? OR ? IS NULL AND RuleEntityDescription IS NULL) AND (RuleEntityValue = ? OR ? " +
				"IS NULL AND RuleEntityValue IS NULL) AND (RuleID = ? OR ? IS NULL AND RuleID IS " +
				"NULL)";
			this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Delete3_Original_RuleEntityID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Delete3_Original_RuleEntityDescription", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Delete3_Original_RuleEntityDescription1", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Delete3_Original_RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityValue", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Delete3_Original_RuleEntityValue1", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityValue", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Delete3_Original_RuleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Delete3_Original_RuleID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO SEC_RuleEntity(RuleID, RuleEntityValue, RuleEntityDescription) VALUES" +
				" (?, ?, ?)";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Insert3_RuleID", System.Data.OleDb.OleDbType.Integer, 4, "RuleID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Insert3_RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, "RuleEntityValue"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Insert3_RuleEntityDescription", System.Data.OleDb.OleDbType.VarChar, 200, "RuleEntityDescription"));
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = @"SELECT SEC_RuleEntity.RuleEntityID, SEC_RuleEntity.RuleID, SEC_RuleEntity.RuleEntityValue, SEC_RuleEntity.RuleEntityDescription FROM SEC_Rules INNER JOIN SEC_ModulesSubModulesXRules ON SEC_Rules.RuleID = SEC_ModulesSubModulesXRules.RuleID INNER JOIN SEC_RuleEntity ON SEC_Rules.RuleID = SEC_RuleEntity.RuleID WHERE (SEC_ModulesSubModulesXRules.MSMID = ?)";
			this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("MSMID", System.Data.OleDb.OleDbType.Integer, 4, "MSMID"));
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = @"UPDATE SEC_RuleEntity SET RuleID = ?, RuleEntityValue = ?, RuleEntityDescription = ? WHERE (RuleEntityID = ?) AND (RuleEntityDescription = ? OR ? IS NULL AND RuleEntityDescription IS NULL) AND (RuleEntityValue = ? OR ? IS NULL AND RuleEntityValue IS NULL) AND (RuleID = ? OR ? IS NULL AND RuleID IS NULL)";
			this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Update3_RuleID", System.Data.OleDb.OleDbType.Integer, 4, "RuleID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Update3_RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, "RuleEntityValue"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Update3_RuleEntityDescription", System.Data.OleDb.OleDbType.VarChar, 200, "RuleEntityDescription"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Update3_Original_RuleEntityID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Update3_Original_RuleEntityDescription", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Update3_Original_RuleEntityDescription1", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Update3_Original_RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityValue", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Update3_Original_RuleEntityValue1", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityValue", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Update3_Original_RuleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Update3_Original_RuleID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleID", System.Data.DataRowVersion.Original, null));
			// 
			// ModulesSubModulesXRulesData
			// 
			this.ComponentDataAdabter = this.oleDbDataAdapter1;
			this.Connection = this.oleDbConnection1;

		}
		#endregion
	}
}
