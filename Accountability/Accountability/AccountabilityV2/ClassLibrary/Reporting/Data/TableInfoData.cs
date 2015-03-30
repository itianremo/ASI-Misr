using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
namespace TSN.ERP.Reporting.Data
{
	/// <summary>
	/// Summary description for TableInfoData.
	/// </summary>
	public class TableInfoData : TSN.ERP.Engine.BussinesComponent 
	{
		private System.Data.OleDb.OleDbDataAdapter odaTableInfo;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbConnection con1;
		private TSN.ERP.Reporting.Data.dsTableInfo dsTableInfo1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TableInfoData(System.ComponentModel.IContainer container)
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

		public TableInfoData()
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
			this.odaTableInfo = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.con1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dsTableInfo1 = new TSN.ERP.Reporting.Data.dsTableInfo();
			((System.ComponentModel.ISupportInitialize)(this.dsTableInfo1)).BeginInit();
			// 
			// odaTableInfo
			// 
			this.odaTableInfo.DeleteCommand = this.oleDbDeleteCommand1;
			this.odaTableInfo.InsertCommand = this.oleDbInsertCommand1;
			this.odaTableInfo.SelectCommand = this.oleDbSelectCommand1;
			this.odaTableInfo.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								   new System.Data.Common.DataTableMapping("Table", "GEN_TableInfo", new System.Data.Common.DataColumnMapping[] {
																																																					new System.Data.Common.DataColumnMapping("cTableName", "cTableName"),
																																																					new System.Data.Common.DataColumnMapping("cTableDescCol", "cTableDescCol"),
																																																					new System.Data.Common.DataColumnMapping("cTablePkCol", "cTablePkCol"),
																																																					new System.Data.Common.DataColumnMapping("cTableDescription", "cTableDescription")})});
			this.odaTableInfo.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM GEN_TableInfo WHERE (cTableName = ?) AND (cTableDescCol = ? OR ? IS N" +
				"ULL AND cTableDescCol IS NULL) AND (cTableDescription = ?) AND (cTablePkCol = ?)" +
				"";
			this.oleDbDeleteCommand1.Connection = this.con1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cTableName", System.Data.OleDb.OleDbType.VarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cTableName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cTableDescCol", System.Data.OleDb.OleDbType.VarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cTableDescCol", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cTableDescCol1", System.Data.OleDb.OleDbType.VarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cTableDescCol", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cTableDescription", System.Data.OleDb.OleDbType.VarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cTableDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cTablePkCol", System.Data.OleDb.OleDbType.VarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cTablePkCol", System.Data.DataRowVersion.Original, null));
			// 
			// con1
			// 
			this.con1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=erp;Tag with column collation when possible=False;Initial Catalog=erpdb4;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASSAM;Use Encryption for Data=False";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO GEN_TableInfo(cTableName, cTableDescCol, cTablePkCol, cTableDescripti" +
				"on) VALUES (?, ?, ?, ?); SELECT cTableName, cTableDescCol, cTablePkCol, cTableDe" +
				"scription FROM GEN_TableInfo WHERE (cTableName = ?)";
			this.oleDbInsertCommand1.Connection = this.con1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("cTableName", System.Data.OleDb.OleDbType.VarChar, 255, "cTableName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("cTableDescCol", System.Data.OleDb.OleDbType.VarChar, 255, "cTableDescCol"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("cTablePkCol", System.Data.OleDb.OleDbType.VarChar, 255, "cTablePkCol"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("cTableDescription", System.Data.OleDb.OleDbType.VarChar, 255, "cTableDescription"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_cTableName", System.Data.OleDb.OleDbType.VarChar, 255, "cTableName"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT cTableName, cTableDescCol, cTablePkCol, cTableDescription FROM GEN_TableIn" +
				"fo";
			this.oleDbSelectCommand1.Connection = this.con1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE GEN_TableInfo SET cTableName = ?, cTableDescCol = ?, cTablePkCol = ?, cTableDescription = ? WHERE (cTableName = ?) AND (cTableDescCol = ? OR ? IS NULL AND cTableDescCol IS NULL) AND (cTableDescription = ?) AND (cTablePkCol = ?); SELECT cTableName, cTableDescCol, cTablePkCol, cTableDescription FROM GEN_TableInfo WHERE (cTableName = ?)";
			this.oleDbUpdateCommand1.Connection = this.con1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("cTableName", System.Data.OleDb.OleDbType.VarChar, 255, "cTableName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("cTableDescCol", System.Data.OleDb.OleDbType.VarChar, 255, "cTableDescCol"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("cTablePkCol", System.Data.OleDb.OleDbType.VarChar, 255, "cTablePkCol"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("cTableDescription", System.Data.OleDb.OleDbType.VarChar, 255, "cTableDescription"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cTableName", System.Data.OleDb.OleDbType.VarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cTableName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cTableDescCol", System.Data.OleDb.OleDbType.VarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cTableDescCol", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cTableDescCol1", System.Data.OleDb.OleDbType.VarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cTableDescCol", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cTableDescription", System.Data.OleDb.OleDbType.VarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cTableDescription", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cTablePkCol", System.Data.OleDb.OleDbType.VarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cTablePkCol", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_cTableName", System.Data.OleDb.OleDbType.VarChar, 255, "cTableName"));
			// 
			// dsTableInfo1
			// 
			this.dsTableInfo1.DataSetName = "dsTableInfo";
			this.dsTableInfo1.EnforceConstraints = false;
			this.dsTableInfo1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// TableInfoData
			// 
			this.ComponentDataAdabter = this.odaTableInfo;
			this.ComponentDataSet = this.dsTableInfo1;
			this.Connection = this.con1;
			((System.ComponentModel.ISupportInitialize)(this.dsTableInfo1)).EndInit();

		}
		#endregion



		public DataSet GetListForGeneralParameter(string TargetTableName)
		{
			dsTableInfo dsTemp = new dsTableInfo();
			dsTemp.Merge(List("cTableName = '" + TargetTableName+"'"));
			dsTableInfo.GEN_TableInfoRow Dr =  dsTemp.GEN_TableInfo[0];
			return DataGloabalFormat(Dr.cTablePkCol,Dr.cTableDescCol,TargetTableName);

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
	}
}
