using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using TSN.ERP.Engine;
using TSN.ERP.SharedComponents;
using System.Data;
namespace TSN.ERP.Reporting.Data
{
	/// <summary>
	/// Summary description for EntitiesData.
	/// </summary>
	public class EntitiesData :BussinesComponent
	{
		private System.Data.OleDb.OleDbDataAdapter odaEntites;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbConnection con1;
		private TSN.ERP.Reporting.Data.dsEntities dsEntities1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EntitiesData(System.ComponentModel.IContainer container)
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

		public EntitiesData()
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

		public DataSet GetListForEntityParameter(string TargetTableName)
		{
			dsEntities dsTemp = new dsEntities();
			dsTemp.Merge(List("cTableName = '" + TargetTableName+"'"));
			dsEntities.SEC_EntitiesRow  Dr =  dsTemp.SEC_Entities[0];
			return DataGloabalFormat(Dr.cKeyName,Dr.cDescription,TargetTableName);

		}
		private DataSet DataGloabalFormat(string PkColoum,string DescriptionColoum,string TableName)
		{
			string selectComand = "Select " + PkColoum + " as cPkCol ,"+ DescriptionColoum + " as cDescription from " + TableName;
			System.Data.OleDb.OleDbDataAdapter DA = new System.Data.OleDb.OleDbDataAdapter(selectComand,con1);
			//DA.TableMappings[TableName].DataSetTable = "tDataList";
			DataSet DS = new DataSet();
			DA.Fill(DS);
			return DS;
		}

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
			this.odaEntites = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.con1 = new System.Data.OleDb.OleDbConnection();
			this.dsEntities1 = new TSN.ERP.Reporting.Data.dsEntities();
			((System.ComponentModel.ISupportInitialize)(this.dsEntities1)).BeginInit();
			// 
			// odaEntites
			// 
			this.odaEntites.SelectCommand = this.oleDbSelectCommand1;
			this.odaEntites.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								 new System.Data.Common.DataTableMapping("Table", "SEC_Entities", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("EntityID", "EntityID"),
																																																				 new System.Data.Common.DataColumnMapping("EntityName", "EntityName"),
																																																				 new System.Data.Common.DataColumnMapping("cTableName", "cTableName"),
																																																				 new System.Data.Common.DataColumnMapping("cKeyName", "cKeyName"),
																																																				 new System.Data.Common.DataColumnMapping("cDescription", "cDescription"),
																																																				 new System.Data.Common.DataColumnMapping("cManagerColoum", "cManagerColoum"),
																																																				 new System.Data.Common.DataColumnMapping("cAutoAssginUsers", "cAutoAssginUsers")})});
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT EntityID, EntityName, cTableName, cKeyName, cDescription, cManagerColoum, " +
				"cAutoAssginUsers FROM SEC_Entities";
			this.oleDbSelectCommand1.Connection = this.con1;
			// 
			// con1
			// 
			this.con1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=BASSAM;Tag with column collation when possible=False;Initial Catalog=ERPdb;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASSAM;Use Encryption for Data=False";
			// 
			// dsEntities1
			// 
			this.dsEntities1.DataSetName = "dsEntities";
			this.dsEntities1.EnforceConstraints = false;
			this.dsEntities1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// EntitiesData
			// 
			this.ComponentDataAdabter = this.odaEntites;
			this.ComponentDataSet = this.dsEntities1;
			this.Connection = this.con1;
			((System.ComponentModel.ISupportInitialize)(this.dsEntities1)).EndInit();

		}
		#endregion
	}
}
