using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.OleDb;
//using System.EnterpriseServices;
namespace TSN.ERP.Security
{
	/// <summary>
	/// Summary description for EntitysecurityManager.
	/// </summary>
	/// 

	//[Transaction(TransactionOption.Required)] 
	public class EntitysecurityManager : System.ComponentModel.Component
	{
		private System.Data.OleDb.OleDbDataAdapter odaRulesByEntity;
		private System.Data.OleDb.OleDbConnection con1;
		private TSN.ERP.Security.Data.DataSetRules dataSetRules1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbDataAdapter odaRuleEntity;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private TSN.ERP.Security.Data.DataSetRuleEntity dataSetRuleEntity1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Data.OleDb.OleDbCommand odcTypeColName;
		private System.Data.OleDb.OleDbCommand odcEntityExists;
		private System.Data.OleDb.OleDbCommand odcEntityName;
		private System.Data.OleDb.OleDbDataAdapter odaEntities;
		private TSN.ERP.Security.dsEntities dsEntities1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Data.OleDb.OleDbCommand odcGetUserDefaultGroup;
		private System.Data.OleDb.OleDbDataAdapter odaRulesEntityByEntityIDandType;
		private System.Data.OleDb.OleDbCommand odaRulesEntityByEntityIDandTypeSelectCommand;
		private System.Data.OleDb.OleDbCommand odcDeleteDummyRGroups;
		private System.Data.OleDb.OleDbCommand odcFindRgroupForEntity;
		private System.Data.OleDb.OleDbDataAdapter odaEntityRulesByEntValue;
		private System.Data.OleDb.OleDbCommand odcRuleDescription;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
		private System.Data.OleDb.OleDbCommand odcRGRulesCount;
		private System.Data.OleDb.OleDbCommand odcEntityRuleCount;
		private SecurityManagement ComponentSecManager = new SecurityManagement();

		

		public EntitysecurityManager(System.ComponentModel.IContainer container)
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

		public EntitysecurityManager()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// 

////////////////////        [DebuggerStepThrough()]
////////////////////        protected override void Dispose( bool disposing )
////////////////////        {
//////////////////////			if (con1 !=null)
//////////////////////			{
//////////////////////				//con1.Close();
//////////////////////				con1.Dispose();
//////////////////////			}
////////////////////////			if( disposing )
////////////////////////			{
////////////////////////				if(components != null)
////////////////////////				{
////////////////////////					components.Dispose();
////////////////////////				}
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
			this.odaRulesByEntity = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.con1 = new System.Data.OleDb.OleDbConnection();
			this.dataSetRules1 = new TSN.ERP.Security.Data.DataSetRules();
			this.odaRuleEntity = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dataSetRuleEntity1 = new TSN.ERP.Security.Data.DataSetRuleEntity();
			this.odcTypeColName = new System.Data.OleDb.OleDbCommand();
			this.odcEntityExists = new System.Data.OleDb.OleDbCommand();
			this.odcEntityName = new System.Data.OleDb.OleDbCommand();
			this.odaEntities = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.dsEntities1 = new TSN.ERP.Security.dsEntities();
			this.odcGetUserDefaultGroup = new System.Data.OleDb.OleDbCommand();
			this.odaRulesEntityByEntityIDandType = new System.Data.OleDb.OleDbDataAdapter();
			this.odaRulesEntityByEntityIDandTypeSelectCommand = new System.Data.OleDb.OleDbCommand();
			this.odcDeleteDummyRGroups = new System.Data.OleDb.OleDbCommand();
			this.odcFindRgroupForEntity = new System.Data.OleDb.OleDbCommand();
			this.odaEntityRulesByEntValue = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
			this.odcRuleDescription = new System.Data.OleDb.OleDbCommand();
			this.odcRGRulesCount = new System.Data.OleDb.OleDbCommand();
			this.odcEntityRuleCount = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dataSetRules1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetRuleEntity1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsEntities1)).BeginInit();
			// 
			// odaRulesByEntity
			// 
			this.odaRulesByEntity.SelectCommand = this.oleDbSelectCommand1;
			this.odaRulesByEntity.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "SEC_Rules", new System.Data.Common.DataColumnMapping[] {
																																																					new System.Data.Common.DataColumnMapping("RuleID", "RuleID"),
																																																					new System.Data.Common.DataColumnMapping("RuleName", "RuleName")})});
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT SEC_Rules.RuleID, SEC_Rules.RuleName FROM SEC_Rules INNER JOIN SEC_Entitie" +
				"s ON SEC_Rules.EntityID = SEC_Entities.EntityID WHERE (SEC_Entities.cTableName =" +
				" ?)";
			this.oleDbSelectCommand1.Connection = this.con1;
			this.oleDbSelectCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("cTableName", System.Data.OleDb.OleDbType.VarChar, 150, "cTableName"));
			// 
			// con1
			// 
			this.con1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=erp;Tag with column collation when possible=False;Initial Catalog=erpdb4;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASSAM;Use Encryption for Data=False";
			// 
			// dataSetRules1
			// 
			this.dataSetRules1.DataSetName = "DataSetRules";
			this.dataSetRules1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// odaRuleEntity
			// 
			this.odaRuleEntity.DeleteCommand = this.oleDbDeleteCommand1;
			this.odaRuleEntity.InsertCommand = this.oleDbInsertCommand1;
			this.odaRuleEntity.SelectCommand = this.oleDbSelectCommand2;
			this.odaRuleEntity.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									new System.Data.Common.DataTableMapping("Table", "SEC_RuleEntity", new System.Data.Common.DataColumnMapping[] {
																																																					  new System.Data.Common.DataColumnMapping("RuleEntityID", "RuleEntityID"),
																																																					  new System.Data.Common.DataColumnMapping("RuleID", "RuleID"),
																																																					  new System.Data.Common.DataColumnMapping("RuleEntityValue", "RuleEntityValue"),
																																																					  new System.Data.Common.DataColumnMapping("RuleEntityDescription", "RuleEntityDescription")})});
			this.odaRuleEntity.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM SEC_RuleEntity WHERE (RuleEntityID = ?) AND (RuleEntityDescription = " +
				"? OR ? IS NULL AND RuleEntityDescription IS NULL) AND (RuleEntityValue = ? OR ? " +
				"IS NULL AND RuleEntityValue IS NULL) AND (RuleID = ? OR ? IS NULL AND RuleID IS " +
				"NULL)";
			this.oleDbDeleteCommand1.Connection = this.con1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityDescription", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityDescription1", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityValue", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityValue1", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityValue", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO SEC_RuleEntity(RuleEntityID, RuleID, RuleEntityValue, RuleEntityDescr" +
				"iption) VALUES (?, ?, ?, ?); SELECT RuleEntityID, RuleID, RuleEntityValue, RuleE" +
				"ntityDescription FROM SEC_RuleEntity WHERE (RuleEntityID = ?)";
			this.oleDbInsertCommand1.Connection = this.con1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityID", System.Data.OleDb.OleDbType.Integer, 4, "RuleEntityID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleID", System.Data.OleDb.OleDbType.Integer, 4, "RuleID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, "RuleEntityValue"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityDescription", System.Data.OleDb.OleDbType.VarChar, 200, "RuleEntityDescription"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_RuleEntityID", System.Data.OleDb.OleDbType.Integer, 4, "RuleEntityID"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT RuleEntityID, RuleID, RuleEntityValue, RuleEntityDescription FROM SEC_Rule" +
				"Entity";
			this.oleDbSelectCommand2.Connection = this.con1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE SEC_RuleEntity SET RuleEntityID = ?, RuleID = ?, RuleEntityValue = ?, RuleEntityDescription = ? WHERE (RuleEntityID = ?) AND (RuleEntityDescription = ? OR ? IS NULL AND RuleEntityDescription IS NULL) AND (RuleEntityValue = ? OR ? IS NULL AND RuleEntityValue IS NULL) AND (RuleID = ? OR ? IS NULL AND RuleID IS NULL); SELECT RuleEntityID, RuleID, RuleEntityValue, RuleEntityDescription FROM SEC_RuleEntity WHERE (RuleEntityID = ?)";
			this.oleDbUpdateCommand1.Connection = this.con1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityID", System.Data.OleDb.OleDbType.Integer, 4, "RuleEntityID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleID", System.Data.OleDb.OleDbType.Integer, 4, "RuleID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, "RuleEntityValue"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityDescription", System.Data.OleDb.OleDbType.VarChar, 200, "RuleEntityDescription"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityDescription", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityDescription1", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityValue", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityValue1", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityValue", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_RuleEntityID", System.Data.OleDb.OleDbType.Integer, 4, "RuleEntityID"));
			// 
			// dataSetRuleEntity1
			// 
			this.dataSetRuleEntity1.DataSetName = "DataSetRuleEntity";
			this.dataSetRuleEntity1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// odcTypeColName
			// 
			this.odcTypeColName.CommandText = "SELECT cDescription FROM SEC_Entities WHERE (cTableName LIKE ?)";
			this.odcTypeColName.Connection = this.con1;
			this.odcTypeColName.Parameters.Add(new System.Data.OleDb.OleDbParameter("cTableName", System.Data.OleDb.OleDbType.VarChar, 150, "cTableName"));
			// 
			// odcEntityExists
			// 
			this.odcEntityExists.CommandText = "SELECT COUNT(*) AS Expr1 FROM SEC_Entities WHERE (cTableName LIKE ?)";
			this.odcEntityExists.Connection = this.con1;
			this.odcEntityExists.Parameters.Add(new System.Data.OleDb.OleDbParameter("cTableName", System.Data.OleDb.OleDbType.VarChar, 150, "cTableName"));
			// 
			// odcEntityName
			// 
			this.odcEntityName.CommandText = "SELECT EntityName FROM SEC_Entities WHERE (cTableName = ?)";
			this.odcEntityName.Connection = this.con1;
			this.odcEntityName.Parameters.Add(new System.Data.OleDb.OleDbParameter("cTableName", System.Data.OleDb.OleDbType.VarChar, 150, "cTableName"));
			// 
			// odaEntities
			// 
			this.odaEntities.DeleteCommand = this.oleDbDeleteCommand2;
			this.odaEntities.InsertCommand = this.oleDbInsertCommand2;
			this.odaEntities.SelectCommand = this.oleDbSelectCommand3;
			this.odaEntities.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								  new System.Data.Common.DataTableMapping("Table", "SEC_Entities", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("EntityID", "EntityID"),
																																																				  new System.Data.Common.DataColumnMapping("EntityName", "EntityName"),
																																																				  new System.Data.Common.DataColumnMapping("cKeyName", "cKeyName"),
																																																				  new System.Data.Common.DataColumnMapping("cDescription", "cDescription"),
																																																				  new System.Data.Common.DataColumnMapping("cManagerColoum", "cManagerColoum"),
																																																				  new System.Data.Common.DataColumnMapping("cAutoAssginUsers", "cAutoAssginUsers")})});
			this.odaEntities.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = @"DELETE FROM SEC_Entities WHERE (EntityID = ?) AND (EntityName = ?) AND (cAutoAssginUsers = ? OR ? IS NULL AND cAutoAssginUsers IS NULL) AND (cDescription = ? OR ? IS NULL AND cDescription IS NULL) AND (cKeyName = ? OR ? IS NULL AND cKeyName IS NULL) AND (cManagerColoum = ? OR ? IS NULL AND cManagerColoum IS NULL)";
			this.oleDbDeleteCommand2.Connection = this.con1;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EntityID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EntityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EntityName", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EntityName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cAutoAssginUsers", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cAutoAssginUsers", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cAutoAssginUsers1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cAutoAssginUsers", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cDescription", System.Data.OleDb.OleDbType.VarChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cDescription1", System.Data.OleDb.OleDbType.VarChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cKeyName", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cKeyName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cKeyName1", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cKeyName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cManagerColoum", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cManagerColoum", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cManagerColoum1", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cManagerColoum", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = @"INSERT INTO SEC_Entities(EntityID, EntityName, cKeyName, cDescription, cManagerColoum, cAutoAssginUsers) VALUES (?, ?, ?, ?, ?, ?); SELECT EntityID, EntityName, cKeyName, cDescription, cManagerColoum, cAutoAssginUsers FROM SEC_Entities WHERE (EntityID = ?)";
			this.oleDbInsertCommand2.Connection = this.con1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("EntityID", System.Data.OleDb.OleDbType.Integer, 4, "EntityID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("EntityName", System.Data.OleDb.OleDbType.VarChar, 150, "EntityName"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("cKeyName", System.Data.OleDb.OleDbType.VarChar, 150, "cKeyName"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("cDescription", System.Data.OleDb.OleDbType.VarChar, 250, "cDescription"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("cManagerColoum", System.Data.OleDb.OleDbType.VarChar, 150, "cManagerColoum"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("cAutoAssginUsers", System.Data.OleDb.OleDbType.Boolean, 1, "cAutoAssginUsers"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_EntityID", System.Data.OleDb.OleDbType.Integer, 4, "EntityID"));
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = "SELECT EntityID, EntityName, cKeyName, cDescription, cManagerColoum, cAutoAssginU" +
				"sers FROM SEC_Entities WHERE (cTableName = ?)";
			this.oleDbSelectCommand3.Connection = this.con1;
			this.oleDbSelectCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("cTableName", System.Data.OleDb.OleDbType.VarChar, 150, "cTableName"));
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = @"UPDATE SEC_Entities SET EntityID = ?, EntityName = ?, cKeyName = ?, cDescription = ?, cManagerColoum = ?, cAutoAssginUsers = ? WHERE (EntityID = ?) AND (EntityName = ?) AND (cAutoAssginUsers = ? OR ? IS NULL AND cAutoAssginUsers IS NULL) AND (cDescription = ? OR ? IS NULL AND cDescription IS NULL) AND (cKeyName = ? OR ? IS NULL AND cKeyName IS NULL) AND (cManagerColoum = ? OR ? IS NULL AND cManagerColoum IS NULL); SELECT EntityID, EntityName, cKeyName, cDescription, cManagerColoum, cAutoAssginUsers FROM SEC_Entities WHERE (EntityID = ?)";
			this.oleDbUpdateCommand2.Connection = this.con1;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("EntityID", System.Data.OleDb.OleDbType.Integer, 4, "EntityID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("EntityName", System.Data.OleDb.OleDbType.VarChar, 150, "EntityName"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("cKeyName", System.Data.OleDb.OleDbType.VarChar, 150, "cKeyName"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("cDescription", System.Data.OleDb.OleDbType.VarChar, 250, "cDescription"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("cManagerColoum", System.Data.OleDb.OleDbType.VarChar, 150, "cManagerColoum"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("cAutoAssginUsers", System.Data.OleDb.OleDbType.Boolean, 1, "cAutoAssginUsers"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EntityID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EntityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EntityName", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EntityName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cAutoAssginUsers", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cAutoAssginUsers", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cAutoAssginUsers1", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cAutoAssginUsers", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cDescription", System.Data.OleDb.OleDbType.VarChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cDescription1", System.Data.OleDb.OleDbType.VarChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cKeyName", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cKeyName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cKeyName1", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cKeyName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cManagerColoum", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cManagerColoum", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cManagerColoum1", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cManagerColoum", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_EntityID", System.Data.OleDb.OleDbType.Integer, 4, "EntityID"));
			// 
			// dsEntities1
			// 
			this.dsEntities1.DataSetName = "dsEntities";
			this.dsEntities1.EnforceConstraints = false;
			this.dsEntities1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// odcGetUserDefaultGroup
			// 
			this.odcGetUserDefaultGroup.CommandText = "SELECT SEC_UsersGroups.UserGroupID FROM SEC_Users INNER JOIN SEC_UsersGroups ON S" +
				"EC_Users.UserName = SEC_UsersGroups.UserGroupName WHERE (SEC_Users.UserID = ?) A" +
				"ND (SEC_UsersGroups.UserGroupType = 1)";
			this.odcGetUserDefaultGroup.Connection = this.con1;
			this.odcGetUserDefaultGroup.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			// 
			// odaRulesEntityByEntityIDandType
			// 
			this.odaRulesEntityByEntityIDandType.SelectCommand = this.odaRulesEntityByEntityIDandTypeSelectCommand;
			this.odaRulesEntityByEntityIDandType.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													  new System.Data.Common.DataTableMapping("Table", "SEC_RuleEntity", new System.Data.Common.DataColumnMapping[] {
																																																										new System.Data.Common.DataColumnMapping("RuleEntityID", "RuleEntityID"),
																																																										new System.Data.Common.DataColumnMapping("RuleID", "RuleID"),
																																																										new System.Data.Common.DataColumnMapping("RuleEntityValue", "RuleEntityValue"),
																																																										new System.Data.Common.DataColumnMapping("RuleEntityDescription", "RuleEntityDescription")})});
			// 
			// odaRulesEntityByEntityIDandTypeSelectCommand
			// 
			this.odaRulesEntityByEntityIDandTypeSelectCommand.CommandText = @"SELECT SEC_RuleEntity.RuleEntityID, SEC_RuleEntity.RuleID, SEC_RuleEntity.RuleEntityValue, SEC_RuleEntity.RuleEntityDescription FROM SEC_RuleEntity INNER JOIN SEC_Rules ON SEC_RuleEntity.RuleID = SEC_Rules.RuleID INNER JOIN SEC_Entities ON SEC_Rules.EntityID = SEC_Entities.EntityID WHERE (SEC_RuleEntity.RuleEntityValue = ?) AND (SEC_Entities.EntityID = ?)";
			this.odaRulesEntityByEntityIDandTypeSelectCommand.Connection = this.con1;
			this.odaRulesEntityByEntityIDandTypeSelectCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, "RuleEntityValue"));
			this.odaRulesEntityByEntityIDandTypeSelectCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("EntityID", System.Data.OleDb.OleDbType.Integer, 4, "EntityID"));
			// 
			// odcDeleteDummyRGroups
			// 
			this.odcDeleteDummyRGroups.CommandText = "DELETE FROM SEC_RuleGroup WHERE (RuleGroupID NOT IN (SELECT SEC_RuleGroup.RuleGro" +
				"upID FROM SEC_RuleGroup INNER JOIN SEC_RuleEntityXRuleGroup ON SEC_RuleGroup.Rul" +
				"eGroupID = SEC_RuleEntityXRuleGroup.RuleGroupID))";
			this.odcDeleteDummyRGroups.Connection = this.con1;
			// 
			// odcFindRgroupForEntity
			// 
			this.odcFindRgroupForEntity.CommandText = @"SELECT SEC_RuleGroup.RuleGroupID FROM SEC_Entities INNER JOIN SEC_Rules ON SEC_Entities.EntityID = SEC_Rules.EntityID INNER JOIN SEC_RuleEntity ON SEC_Rules.RuleID = SEC_RuleEntity.RuleID INNER JOIN SEC_RuleEntityXRuleGroup ON SEC_RuleEntity.RuleEntityID = SEC_RuleEntityXRuleGroup.RuleEntityID INNER JOIN SEC_RuleGroup ON SEC_RuleEntityXRuleGroup.RuleGroupID = SEC_RuleGroup.RuleGroupID WHERE (SEC_Entities.EntityID = ?) AND (SEC_RuleEntity.RuleEntityValue = ?) GROUP BY SEC_RuleGroup.RuleGroupID ORDER BY COUNT(*) DESC";
			this.odcFindRgroupForEntity.Connection = this.con1;
			this.odcFindRgroupForEntity.Parameters.Add(new System.Data.OleDb.OleDbParameter("EntityID", System.Data.OleDb.OleDbType.Integer, 4, "EntityID"));
			this.odcFindRgroupForEntity.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, "RuleEntityValue"));
			// 
			// odaEntityRulesByEntValue
			// 
			this.odaEntityRulesByEntValue.DeleteCommand = this.oleDbDeleteCommand3;
			this.odaEntityRulesByEntValue.InsertCommand = this.oleDbInsertCommand3;
			this.odaEntityRulesByEntValue.SelectCommand = this.oleDbSelectCommand4;
			this.odaEntityRulesByEntValue.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											   new System.Data.Common.DataTableMapping("Table", "SEC_RuleEntity", new System.Data.Common.DataColumnMapping[] {
																																																								 new System.Data.Common.DataColumnMapping("RuleEntityID", "RuleEntityID"),
																																																								 new System.Data.Common.DataColumnMapping("RuleID", "RuleID"),
																																																								 new System.Data.Common.DataColumnMapping("RuleEntityValue", "RuleEntityValue"),
																																																								 new System.Data.Common.DataColumnMapping("RuleEntityDescription", "RuleEntityDescription")})});
			this.odaEntityRulesByEntValue.UpdateCommand = this.oleDbUpdateCommand3;
			// 
			// oleDbDeleteCommand3
			// 
			this.oleDbDeleteCommand3.CommandText = "DELETE FROM SEC_RuleEntity WHERE (RuleEntityID = ?) AND (RuleEntityDescription = " +
				"? OR ? IS NULL AND RuleEntityDescription IS NULL) AND (RuleEntityValue = ? OR ? " +
				"IS NULL AND RuleEntityValue IS NULL) AND (RuleID = ? OR ? IS NULL AND RuleID IS " +
				"NULL)";
			this.oleDbDeleteCommand3.Connection = this.con1;
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityDescription", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityDescription1", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityValue", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityValue1", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityValue", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand3
			// 
			this.oleDbInsertCommand3.CommandText = "INSERT INTO SEC_RuleEntity(RuleID, RuleEntityValue, RuleEntityDescription) VALUES" +
				" (?, ?, ?)";
			this.oleDbInsertCommand3.Connection = this.con1;
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleID", System.Data.OleDb.OleDbType.Integer, 4, "RuleID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, "RuleEntityValue"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityDescription", System.Data.OleDb.OleDbType.VarChar, 200, "RuleEntityDescription"));
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = @"SELECT SEC_RuleEntity.RuleEntityID, SEC_RuleEntity.RuleID, SEC_RuleEntity.RuleEntityValue, SEC_RuleEntity.RuleEntityDescription FROM SEC_RuleEntity INNER JOIN SEC_Rules ON SEC_RuleEntity.RuleID = SEC_Rules.RuleID WHERE (SEC_RuleEntity.RuleEntityValue = ?) AND (SEC_Rules.EntityID = ?)";
			this.oleDbSelectCommand4.Connection = this.con1;
			this.oleDbSelectCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, "RuleEntityValue"));
			this.oleDbSelectCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("EntityID", System.Data.OleDb.OleDbType.Integer, 4, "EntityID"));
			// 
			// oleDbUpdateCommand3
			// 
			this.oleDbUpdateCommand3.CommandText = @"UPDATE SEC_RuleEntity SET RuleID = ?, RuleEntityValue = ?, RuleEntityDescription = ? WHERE (RuleEntityID = ?) AND (RuleEntityDescription = ? OR ? IS NULL AND RuleEntityDescription IS NULL) AND (RuleEntityValue = ? OR ? IS NULL AND RuleEntityValue IS NULL) AND (RuleID = ? OR ? IS NULL AND RuleID IS NULL)";
			this.oleDbUpdateCommand3.Connection = this.con1;
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleID", System.Data.OleDb.OleDbType.Integer, 4, "RuleID"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, "RuleEntityValue"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleEntityDescription", System.Data.OleDb.OleDbType.VarChar, 200, "RuleEntityDescription"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityDescription", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityDescription1", System.Data.OleDb.OleDbType.VarChar, 200, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityValue", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityValue", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleEntityValue1", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleEntityValue", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RuleID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RuleID", System.Data.DataRowVersion.Original, null));
			// 
			// odcRuleDescription
			// 
			this.odcRuleDescription.CommandText = "SELECT RuleName FROM SEC_Rules WHERE (RuleID = ?)";
			this.odcRuleDescription.Connection = this.con1;
			this.odcRuleDescription.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleID", System.Data.OleDb.OleDbType.Integer, 4, "RuleID"));
			// 
			// odcRGRulesCount
			// 
			this.odcRGRulesCount.CommandText = "SELECT COUNT(*) AS EXPR1 FROM SEC_RuleGroup INNER JOIN SEC_RuleEntityXRuleGroup O" +
				"N SEC_RuleGroup.RuleGroupID = SEC_RuleEntityXRuleGroup.RuleGroupID GROUP BY SEC_" +
				"RuleGroup.RuleGroupID HAVING (SEC_RuleGroup.RuleGroupID = ?)";
			this.odcRGRulesCount.Connection = this.con1;
			this.odcRGRulesCount.Parameters.Add(new System.Data.OleDb.OleDbParameter("RuleGroupID", System.Data.OleDb.OleDbType.Integer, 4, "RuleGroupID"));
			// 
			// odcEntityRuleCount
			// 
			this.odcEntityRuleCount.CommandText = "SELECT COUNT(*) AS EXPR1 FROM SEC_Rules INNER JOIN SEC_Entities ON SEC_Rules.Enti" +
				"tyID = SEC_Entities.EntityID GROUP BY SEC_Rules.EntityID HAVING (SEC_Rules.Entit" +
				"yID = ?)";
			this.odcEntityRuleCount.Connection = this.con1;
			this.odcEntityRuleCount.Parameters.Add(new System.Data.OleDb.OleDbParameter("EntityID", System.Data.OleDb.OleDbType.Integer, 4, "EntityID"));
			((System.ComponentModel.ISupportInitialize)(this.dataSetRules1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetRuleEntity1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsEntities1)).EndInit();

		}
		#endregion


		# region Createing New Rules
		/// <summary>
		/// Adding new rule entitiy.
		/// </summary>
		/// <param name="EntityTable">string: Entity table</param>
		/// <param name="EntityID">string: Entity ID</param>
		/// <param name="EntityDesc">string: Entity description</param>
		/// <param name="UserID">int: User ID</param>
		/// <param name="AutoAssgin">bool: Auto Assginment</param>
		/// <param name="ManagerContactID">int: Manager of the user ID</param>
		/// <returns>bool: If the opration success retruns true,but if not retruns false</returns>
		public bool AddRuleEntitiy(string EntityTable, string EntityID, string EntityDesc,int UserID,bool AutoAssgin,int ManagerContactID)
		{
			// Get Current Entity Name
			dataSetRuleEntity1.Clear();
			// Get Entity Type Related Rules
			dataSetRules1.Merge(GetEntityRules(EntityTable));
			int RowCount = dataSetRules1.SEC_Rules.Count;
			
			string EntityTypeName = GetTypeEntityName(EntityTable);
			int RuleGroupID = 0;
			if (RowCount > 0 )
			{ 
				OleDbTransaction trans = con1.BeginTransaction();
				RuleGroupID = ComponentSecManager.AddRuleGroup("Manage" + " " + EntityTypeName +" "+ EntityDesc);
				trans.Commit();
				if (AutoAssgin)
				{
					int tempgroup = GetDefaultUserGroup(UserID);
					if (tempgroup > 0)
						ComponentSecManager.AddRuleGroupToUserGroup(tempgroup,RuleGroupID);
					
					if (ManagerContactID > 0)
					{
						int ManagerUserID = ComponentSecManager.GetContactUserID(ManagerContactID);
						tempgroup = GetDefaultUserGroup(ManagerUserID);
						if (tempgroup >  0)
							ComponentSecManager.AddRuleGroupToUserGroup(tempgroup,RuleGroupID);
					}
				}
			}
			else
			{
				return true;
			}
			for (int i =0; i< RowCount;i++)
			{
				Data.DataSetRules.SEC_RulesRow RuleRow = dataSetRules1.SEC_Rules[i];
				ComponentSecManager.AddRuleEntity(RuleRow.RuleID , EntityID,RuleRow.RuleName +" "+ EntityDesc );
				int RuleEntityID = GetLastRuleEntityIdentity();
				ComponentSecManager.AddRuleEntityToRuleGroup(RuleEntityID,RuleGroupID);
			}
			
			return true;
		}
		

		/// <summary>
		/// Adding new rules for an entity for spacific user.
		/// </summary>
		/// <param name="NewRecordes">DataSet:Containing the new rule data</param>
		/// <param name="UserId">int:User ID</param>
		/// <returns>int:Returns (0)if opration failed,but if it success returns (value>=1)</returns>
		public int AddRulesForEntity(DataSet NewRecordes,int UserId)
		{
			int tableCount = NewRecordes.Tables.Count;
			int DoneCount = 0;
			string pkName ,TableName,DescColName;
			string ManagerColName = "";
			bool AutoAssginUsers = false;
			bool HasManager = false;
			for (int i =0; i <tableCount;i++)
			{
				DataTable CurrenTable = NewRecordes.Tables[i];
				pkName = CurrenTable.PrimaryKey[0].ColumnName;
				TableName = CurrenTable.TableName;
				if (! CheckEntityExsist(TableName))
					return 0;
				LoadEntityData(TableName);
				dsEntities.SEC_EntitiesRow EntityRow = dsEntities1.SEC_Entities[0];
				//GetDataForEntity
				DescColName = EntityRow.cDescription;
				if (!EntityRow.IscManagerColoumNull())
				{
					ManagerColName = EntityRow.cManagerColoum;
					HasManager = true;
				}
				if (!EntityRow.IscAutoAssginUsersNull())
				{
					AutoAssginUsers = EntityRow.cAutoAssginUsers;
				}
				else
				{
					AutoAssginUsers = false;
				}
				int rowCount = NewRecordes.Tables[i].Rows.Count;
				for (int j=0; j <rowCount;j++)
				{
					DataRow CurrentRow = CurrenTable.Rows[j];
					if ( CurrentRow.RowState == DataRowState.Added)
					{
						try
						{
							string EntityValue = CurrentRow[pkName].ToString();
							string EntityName = null;

							string[] DescFieldsArray = DescColName.Split(';');
							for(int x=0; x<DescFieldsArray.Length; x++)
							{
								if(x != DescFieldsArray.Length-1)
								{
									EntityName += CurrentRow[DescFieldsArray[x]] + "-";
								}
								else
								{
									EntityName += CurrentRow[DescFieldsArray[x]];
								}
							}

							if(HasManager)
							{
								if (!CurrentRow.IsNull(ManagerColName))
								{
									int EntityManagerID = Convert.ToInt32(CurrentRow[ManagerColName]);
									AddRuleEntitiy(TableName,EntityValue,EntityName,UserId,AutoAssginUsers,EntityManagerID);
								}
								else
								{
									AddRuleEntitiy(TableName,EntityValue,EntityName,UserId,AutoAssginUsers,-1);
								}
							}
							else
							{
								AddRuleEntitiy(TableName,EntityValue,EntityName,UserId,AutoAssginUsers,-1);
							}
							DoneCount++;
						}
						catch(Exception ex)
						{
							EventLog.WriteEntry("TSN ERP Server",ex.Message,System.Diagnostics.EventLogEntryType.Error);
							DoneCount = -1;
						}
					}
				}
			}
			return DoneCount;
		}

		#endregion
		
		#region Entity Information
		/// <summary>
		/// Get name of type entity.
		/// </summary>
		/// <param name="TableName">string: Table name</param>
		/// <returns>string: Returns the name of the type entity</returns>
		public string GetTypeEntityName(string TableName)
		{
			odcEntityName.Parameters[0].Value  = TableName;
			return odcEntityName.ExecuteScalar().ToString();
		}
		/// <summary>
		/// Get data of entity rules.
		/// </summary>
		/// <param name="EntityTable">string: Entity table name</param>
		/// <returns>DataSet: Containing the data of entity rule</returns>
		public DataSet GetEntityRules(string EntityTable)
		{
			DataSet Tempds = new DataSet();
			odaRulesByEntity.SelectCommand.Parameters[0].Value = EntityTable;
			odaRulesByEntity.Fill(Tempds);
			return Tempds;
		}
		/// <summary>
		/// Get entity desc Column name.
		/// </summary>
		/// <param name="EntityTable">string:Entity table name</param>
		/// <returns>string:Returns entity Column name</returns>
		public string GetEntityDescColName(string EntityTable)
		{
			odcTypeColName.Parameters[0].Value = EntityTable;
			object DescResult = odcTypeColName.ExecuteScalar();
			string DescColName = DescResult.ToString();
			return DescColName;
		}
		/// <summary>
		/// Checking if the entity exsist or not.
		/// </summary>
		/// <param name="EntityTable">string:Entity table name</param>
		/// <returns>bool:If the opration success retruns true,but if not retruns false</returns>
		public bool CheckEntityExsist(string EntityTable)
		{
			odcEntityExists.Parameters[0].Value = EntityTable;
			Int32 result = (Int32)odcEntityExists.ExecuteScalar(); 
			if (result == 1)
				return true;
			return false;
		}
		/// <summary>
		/// Loading for entity data.
		/// </summary>
		/// <param name="TableName">string:Table name</param>
		public void LoadEntityData(string TableName)
		{
			odaEntities.SelectCommand.Parameters[0].Value = TableName;
			odaEntities.Fill(dsEntities1);
		}
		#endregion

		/// <summary>
		/// Get default user group for spacific user.
		/// </summary>
		/// <param name="userID">int:User ID</param>
		/// <returns>int:Retruns group ID</returns>
		public int GetDefaultUserGroup(int userID)
		{
			try
			{
				odcGetUserDefaultGroup.Parameters[0].Value = userID;
				return Convert.ToInt32(odcGetUserDefaultGroup.ExecuteScalar());
			}
			catch ( Exception ee )
			{
				return -1;
			}
		}
		/// <summary>
		/// Get the last rule group ID entity.
		/// </summary>
		/// <returns>int:Returns the last rule group ID entity</returns>
		public int GetLastRuleGroupIdentity()
		{
			OleDbCommand odaGetIdentity = new OleDbCommand("select IDENT_CURRENT('SEC_RuleGroup')",con1);
			object tempobj = odaGetIdentity.ExecuteScalar().ToString();
			string tempstr = tempobj.ToString();
			return System.Convert.ToInt32(tempstr);
		}	
		/// <summary>
		/// Get the last rule entity ID entity.
		/// </summary>
		/// <returns>int:Returns the last rule entity ID entity</returns>
		public int GetLastRuleEntityIdentity()
		{
			OleDbCommand odaGetIdentity = new OleDbCommand("select IDENT_CURRENT('SEC_RuleEntity')",con1);
			object tempobj = odaGetIdentity.ExecuteScalar().ToString();
			string tempstr = tempobj.ToString();
			return System.Convert.ToInt32(tempstr);
		}


		

		#region Delete Entity
		/// <summary>
		/// Deleting rule entities.
		/// </summary>
		/// <param name="DeletedRecored">DataSet:Containing the data of rule entities</param>
		/// <returns>int:Returns (0)if opration failed,but if it success returns (1)?????????</returns>
		public int DeleteRuleEntities(DataSet DeletedRecored)
		{
			int tableCount = DeletedRecored.Tables.Count;
			int DoneCount = 0;
			string pkName ,TableName;
			for (int i =0; i <tableCount;i++)
			{
				DataTable CurrenTable = DeletedRecored.Tables[i];
				pkName = CurrenTable.PrimaryKey[0].ColumnName;
				TableName = CurrenTable.TableName;
				if (! CheckEntityExsist(TableName))
					return 0;
				LoadEntityData(TableName);
				dsEntities.SEC_EntitiesRow EntityRow = dsEntities1.SEC_Entities[0];
				DataView dvDelete = new DataView();
				dvDelete.Table = DeletedRecored.Tables[i];
				dvDelete.RowStateFilter = DataViewRowState.Deleted;

				int rlGrpID;
				foreach(DataRowView DvRow in dvDelete)
				{
					int pkno = Int32.Parse(DvRow[pkName].ToString());
					int entno = EntityRow.EntityID;

					//Get the rule group id assigned the the deleted entity(emp, project, ce,..) to be deleted also
					rlGrpID = FindRgroupForEntity(pkno.ToString(), entno);


					odaRulesEntityByEntityIDandType.SelectCommand.Parameters["RuleEntityValue"].Value =pkno ;
					odaRulesEntityByEntityIDandType.SelectCommand.Parameters["EntityID"].Value =entno ;
					dataSetRuleEntity1.Clear();
					odaRulesEntityByEntityIDandType.Fill(dataSetRuleEntity1);
					foreach(DataRow dr in dataSetRuleEntity1.SEC_RuleEntity)
					{
						dr.Delete();
					}
					odaRuleEntity.Update(dataSetRuleEntity1);
//					odcDeleteDummyRGroups.ExecuteNonQuery();
					//Delete the rule group of the deleted entity
					ComponentSecManager.DeleteRuleGroup(rlGrpID);
				}
			}
			return DoneCount;
		}

		#endregion

		/// <summary>
		/// Edit the rule entities.
		/// </summary>
		/// <param name="ModifiedRecored">DataSet:Containing the data of the rule entities</param>
		/// <returns>int:Returns (0)if opration failed,but if it success returns (value>=1)</returns>
		public int EditRuleEntities(DataSet ModifiedRecored)
		{

			int tableCount = ModifiedRecored.Tables.Count;
			int DoneCount = 0;
			string pkName ,TableName,DescColName;
			string ManagerColName = "";
			bool AutoAssginUsers = false;
			bool HasManager = false;

			for (int i =0; i <tableCount;i++)
			{
				DataTable CurrenTable = ModifiedRecored.Tables[i];
				pkName = CurrenTable.PrimaryKey[0].ColumnName;
				TableName = CurrenTable.TableName;
				if (! CheckEntityExsist(TableName))
					return 0;
				LoadEntityData(TableName);
				dsEntities.SEC_EntitiesRow EntityRow = dsEntities1.SEC_Entities[0];
				//GetDataForEntity
				DescColName = EntityRow.cDescription;
				if (!EntityRow.IscManagerColoumNull())
				{
					ManagerColName = EntityRow.cManagerColoum;
					HasManager = true;
				}
				if (!EntityRow.IscAutoAssginUsersNull())
				{
					AutoAssginUsers = EntityRow.cAutoAssginUsers;
				}
				else
				{
					AutoAssginUsers = false;
				}

				int rowCount = ModifiedRecored.Tables[i].Rows.Count;
				int ManagerUserID,tempgroup;
				for (int j=0; j <rowCount;j++)
				{
					DataRow CurrentRow = CurrenTable.Rows[j];
					if ( CurrentRow.RowState == DataRowState.Modified)
					{
						try
						{
							string EntityValue = CurrentRow[pkName].ToString();
							////////  Updated By Hamdy Ahmed and Sayed Moawad  23/08/2007   ////////////
							
							//Current Version
							string CurrentEntityName = null;
							string[] CurrentDescFieldsArray = DescColName.Split(';');
							for(int x=0; x<CurrentDescFieldsArray.Length; x++)
							{
								if(x != CurrentDescFieldsArray.Length-1)
								{
									CurrentEntityName += CurrentRow[CurrentDescFieldsArray[x],DataRowVersion.Current].ToString().Trim() + "-";
								}
								else
								{
									CurrentEntityName += CurrentRow[CurrentDescFieldsArray[x],DataRowVersion.Current].ToString().Trim();
								}
							}

							//Original Version
							string OriginalEntityName = null;
							string[] OriginalDescFieldsArray = DescColName.Split(';');
							for(int x=0; x<OriginalDescFieldsArray.Length; x++)
							{
								if(x != OriginalDescFieldsArray.Length-1)
								{
									OriginalEntityName += CurrentRow[OriginalDescFieldsArray[x],DataRowVersion.Original].ToString().Trim() + "-";
								}
								else
								{
									OriginalEntityName += CurrentRow[OriginalDescFieldsArray[x],DataRowVersion.Original].ToString().Trim();
								}
							}
							///////////////////////////////////////////////////////////////////////////
//							string EntityName = CurrentRow[DescColName].ToString();
							int RGID = FindRgroupForEntity(EntityValue,EntityRow.EntityID);


//							if (CurrentRow[DescColName,DataRowVersion.Current] != CurrentRow[DescColName,DataRowVersion.Original])
							////////  Updated By Hamdy Ahmed and Sayed Moawad  23/08/2007   ////////////
							if (CurrentEntityName != OriginalEntityName)
							{
								// Descritpion Coloum has Changed 
//								string temp = (string)CurrentRow[DescColName,DataRowVersion.Current];
								////////  Updated By Hamdy Ahmed and Sayed Moawad  23/08/2007   ////////////
								string temp = CurrentEntityName;
								ModifyEntityDescription(EntityValue,EntityRow.EntityID,TableName,temp);
							}
							if(!CurrentRow.IsNull(CurrenTable.Columns[ManagerColName],System.Data.DataRowVersion.Original)
								&& !CurrentRow.IsNull(CurrenTable.Columns[ManagerColName],System.Data.DataRowVersion.Current))
							{
								if (CurrentRow[ManagerColName,DataRowVersion.Current]!=CurrentRow[ManagerColName,DataRowVersion.Original])
								{
									//Manager Has Changed
									ManagerUserID = ComponentSecManager.GetContactUserID((int)CurrentRow[ManagerColName,DataRowVersion.Original]);


									////////  Updated By Hamdy Ahmed and Sayed Moawad  23/08/2007   //////////// 
									if(TableName == "GEN_Employees")
									{
										if(ManagerUserID==-1 && (CurrentRow["UserID"]==DBNull.Value || CurrentRow["UserID"]==null))
											return -1;
										else
											ManagerUserID = Convert.ToInt32(CurrentRow["UserID"].ToString());
									}

									///////////////////////////////////////////////////////////////////////////
									
									tempgroup = GetDefaultUserGroup(ManagerUserID);
									ComponentSecManager.RemoveRuleGroupFromUserGroup(tempgroup,RGID);

									if (AutoAssginUsers)
									{
										ManagerUserID = ComponentSecManager.GetContactUserID((int)CurrentRow[ManagerColName,DataRowVersion.Current]);
										
										
										////////  Updated By Hamdy Ahmed and Sayed Moawad  23/08/2007   //////////// 
										if(TableName == "GEN_Employees")
										{
											if(ManagerUserID==-1 && (CurrentRow["UserID"]==DBNull.Value || CurrentRow["UserID"]==null))
												return -1;
											else
												ManagerUserID = Convert.ToInt32(CurrentRow["UserID"].ToString());
										}

										///////////////////////////////////////////////////////////////////////////
									
										tempgroup = GetDefaultUserGroup(ManagerUserID);
										ComponentSecManager.AddRuleGroupToUserGroup(tempgroup,RGID);
									}
								}
							}

							if(!CurrentRow.IsNull(CurrenTable.Columns[ManagerColName],System.Data.DataRowVersion.Original)
								&& CurrentRow.IsNull(CurrenTable.Columns[ManagerColName],System.Data.DataRowVersion.Current))
							{
								//Manager Has Changed
						
								ManagerUserID = ComponentSecManager.GetContactUserID((int)CurrentRow[ManagerColName,DataRowVersion.Original]);
								tempgroup = GetDefaultUserGroup(ManagerUserID);
								ComponentSecManager.RemoveRuleGroupFromUserGroup(tempgroup,RGID);

							}

							if(CurrentRow.IsNull(CurrenTable.Columns[ManagerColName],System.Data.DataRowVersion.Original)
								&& !CurrentRow.IsNull(CurrenTable.Columns[ManagerColName],System.Data.DataRowVersion.Current))
							{
								if (AutoAssginUsers)
								{
									//Manager Has Changed
									ManagerUserID = ComponentSecManager.GetContactUserID((int)CurrentRow[ManagerColName,DataRowVersion.Current]);
									tempgroup = GetDefaultUserGroup(ManagerUserID);
									ComponentSecManager.AddRuleGroupToUserGroup(tempgroup,RGID);
								}
							}
							DoneCount++;
						}
						catch(Exception ex)
						{
							EventLog.WriteEntry("TSN ERP Server",ex.Message,System.Diagnostics.EventLogEntryType.Error);
							DoneCount = -1;
						}
					}
				}
			}
			return DoneCount;
		}

		private void ModifyEntityDescription(string EntityValue, int EntityID ,string TableName ,string NewDescription)
		{
			Data.DataSetRuleEntity dsRuleEntity =  new Data.DataSetRuleEntity();
			odaEntityRulesByEntValue.SelectCommand.Parameters["RuleEntityValue"].Value = EntityValue;
			odaEntityRulesByEntValue.SelectCommand.Parameters["EntityID"].Value = EntityID;
			odaEntityRulesByEntValue.Fill(dsRuleEntity);

			foreach(Data.DataSetRuleEntity.SEC_RuleEntityRow RuleRow in dsRuleEntity.SEC_RuleEntity)
			{
				odcRuleDescription.Parameters[0].Value = RuleRow.RuleID ;
				Object temp = odcRuleDescription.ExecuteScalar();
				if (temp == null) continue;
				string rulename = temp.ToString();
				RuleRow.RuleEntityDescription = rulename + " " + NewDescription;
			}

			odaEntityRulesByEntValue.Update(dsRuleEntity);

			int RGID = FindRgroupForEntity(EntityValue.ToString(),EntityID);
			Data.DataSetRuleGroup dsRG = new TSN.ERP.Security.Data.DataSetRuleGroup();
			dsRG.Merge(ComponentSecManager.GetRuleGroup(RGID));
			string EntityTypeName = GetTypeEntityName(TableName);
			dsRG.SEC_RuleGroup[0].RuleGroupName = "Manage" + " " + EntityTypeName +" "+ NewDescription;
			ComponentSecManager.ModifyRuleGroup(dsRG);
		}

		/// <summary>
		/// ????????????????????????????//???/?
		/// </summary>
		/// <param name="PKVal">string:?????</param>
		/// <param name="Entittype">int:Entity type</param>
		/// <returns>int: Group ID??????</returns>
		public int FindRgroupForEntity(string PKVal, int Entittype)
		{
			odcFindRgroupForEntity.Parameters["EntityID"].Value = Entittype;
			odcFindRgroupForEntity.Parameters["RuleEntityValue"].Value = PKVal;
			object temp = odcFindRgroupForEntity.ExecuteScalar();
			if (temp == null) return -1;
			int RGID = (int)temp;
			odcEntityRuleCount.Parameters[0].Value = Entittype;
			temp = odcEntityRuleCount.ExecuteScalar();
			if (temp == null) return -1;
			int EntityRuleCount = (int)temp;
			odcRGRulesCount.Parameters[0].Value = RGID;
			temp = odcRGRulesCount.ExecuteScalar();
			if (temp == null) return -1;
			int RGRulesCount = (int)temp;
			if (RGRulesCount != EntityRuleCount)return -1;
			return RGID;

		}
		/// <summary>
		/// Opens a database connection.
		/// </summary>
		/// <param name="ConnectionString">string:Connection string</param>
		public void SetConnection(string ConnectionString)
		{
			con1.Close();
			con1.ConnectionString = ConnectionString;
			con1.Open();
			ComponentSecManager.ConnectionString = ConnectionString;
		}


	}
}
