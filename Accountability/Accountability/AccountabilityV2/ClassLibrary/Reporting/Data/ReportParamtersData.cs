using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using TSN.ERP.Engine;
namespace TSN.ERP.Reporting.Data
{
	/// <summary>
	/// Summary description for ReporParamtersData.
	/// </summary>
	public class ReportParamtersData : BussinesComponent 
	{
		private System.Data.OleDb.OleDbDataAdapter odaRepParms;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbConnection con1;
		private TSN.ERP.Reporting.Data.dsRepParms dsRepParms1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ReportParamtersData(System.ComponentModel.IContainer container)
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

		public ReportParamtersData()
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
			this.odaRepParms = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.con1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dsRepParms1 = new TSN.ERP.Reporting.Data.dsRepParms();
			((System.ComponentModel.ISupportInitialize)(this.dsRepParms1)).BeginInit();
			// 
			// odaRepParms
			// 
			this.odaRepParms.DeleteCommand = this.oleDbDeleteCommand1;
			this.odaRepParms.InsertCommand = this.oleDbInsertCommand1;
			this.odaRepParms.SelectCommand = this.oleDbSelectCommand1;
			this.odaRepParms.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								  new System.Data.Common.DataTableMapping("Table", "REP_CallParms", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("RCParmID", "RCParmID"),
																																																				   new System.Data.Common.DataColumnMapping("RepCallIId", "RepCallIId"),
																																																				   new System.Data.Common.DataColumnMapping("RCParmName", "RCParmName"),
																																																				   new System.Data.Common.DataColumnMapping("RCPFixed", "RCPFixed"),
																																																				   new System.Data.Common.DataColumnMapping("RCPVal", "RCPVal"),
																																																				   new System.Data.Common.DataColumnMapping("RCPType", "RCPType"),
																																																				   new System.Data.Common.DataColumnMapping("RCPCall", "RCPCall")})});
			this.odaRepParms.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = @"DELETE FROM REP_CallParms WHERE (RCParmID = ?) AND (RCPCall = ? OR ? IS NULL AND RCPCall IS NULL) AND (RCPFixed = ? OR ? IS NULL AND RCPFixed IS NULL) AND (RCPType = ? OR ? IS NULL AND RCPType IS NULL) AND (RCParmName = ?) AND (RepCallIId = ? OR ? IS NULL AND RepCallIId IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.con1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCParmID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCParmID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCPCall", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCPCall", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCPCall1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCPCall", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCPFixed", System.Data.OleDb.OleDbType.UnsignedTinyInt, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCPFixed", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCPFixed1", System.Data.OleDb.OleDbType.UnsignedTinyInt, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCPFixed", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCPType", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCPType", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCPType1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCPType", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCParmName", System.Data.OleDb.OleDbType.VarChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCParmName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RepCallIId", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RepCallIId", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RepCallIId1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RepCallIId", System.Data.DataRowVersion.Original, null));
			// 
			// con1
			// 
			this.con1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=BASSAM;Tag with column collation when possible=False;Initial Catalog=ERPdb;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASSAM;Use Encryption for Data=False";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO REP_CallParms(RCParmID, RepCallIId, RCParmName, RCPFixed, RCPVal, RCP" +
				"Type, RCPCall) VALUES (?, ?, ?, ?, ?, ?, ?); SELECT RCParmID, RepCallIId, RCParm" +
				"Name, RCPFixed, RCPVal, RCPType, RCPCall FROM REP_CallParms WHERE (RCParmID = ?)" +
				"";
			this.oleDbInsertCommand1.Connection = this.con1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RCParmID", System.Data.OleDb.OleDbType.Integer, 4, "RCParmID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RepCallIId", System.Data.OleDb.OleDbType.Integer, 4, "RepCallIId"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RCParmName", System.Data.OleDb.OleDbType.VarChar, 250, "RCParmName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RCPFixed", System.Data.OleDb.OleDbType.UnsignedTinyInt, 1, "RCPFixed"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RCPVal", System.Data.OleDb.OleDbType.VarChar, 2147483647, "RCPVal"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RCPType", System.Data.OleDb.OleDbType.Integer, 4, "RCPType"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RCPCall", System.Data.OleDb.OleDbType.Integer, 4, "RCPCall"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_RCParmID", System.Data.OleDb.OleDbType.Integer, 4, "RCParmID"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT RCParmID, RepCallIId, RCParmName, RCPFixed, RCPVal, RCPType, RCPCall FROM " +
				"REP_CallParms";
			this.oleDbSelectCommand1.Connection = this.con1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE REP_CallParms SET RCParmID = ?, RepCallIId = ?, RCParmName = ?, RCPFixed = ?, RCPVal = ?, RCPType = ?, RCPCall = ? WHERE (RCParmID = ?) AND (RCPCall = ? OR ? IS NULL AND RCPCall IS NULL) AND (RCPFixed = ? OR ? IS NULL AND RCPFixed IS NULL) AND (RCPType = ? OR ? IS NULL AND RCPType IS NULL) AND (RCParmName = ?) AND (RepCallIId = ? OR ? IS NULL AND RepCallIId IS NULL); SELECT RCParmID, RepCallIId, RCParmName, RCPFixed, RCPVal, RCPType, RCPCall FROM REP_CallParms WHERE (RCParmID = ?)";
			this.oleDbUpdateCommand1.Connection = this.con1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RCParmID", System.Data.OleDb.OleDbType.Integer, 4, "RCParmID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RepCallIId", System.Data.OleDb.OleDbType.Integer, 4, "RepCallIId"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RCParmName", System.Data.OleDb.OleDbType.VarChar, 250, "RCParmName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RCPFixed", System.Data.OleDb.OleDbType.UnsignedTinyInt, 1, "RCPFixed"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RCPVal", System.Data.OleDb.OleDbType.VarChar, 2147483647, "RCPVal"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RCPType", System.Data.OleDb.OleDbType.Integer, 4, "RCPType"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RCPCall", System.Data.OleDb.OleDbType.Integer, 4, "RCPCall"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCParmID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCParmID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCPCall", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCPCall", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCPCall1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCPCall", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCPFixed", System.Data.OleDb.OleDbType.UnsignedTinyInt, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCPFixed", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCPFixed1", System.Data.OleDb.OleDbType.UnsignedTinyInt, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCPFixed", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCPType", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCPType", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCPType1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCPType", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCParmName", System.Data.OleDb.OleDbType.VarChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCParmName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RepCallIId", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RepCallIId", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RepCallIId1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RepCallIId", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_RCParmID", System.Data.OleDb.OleDbType.Integer, 4, "RCParmID"));
			// 
			// dsRepParms1
			// 
			this.dsRepParms1.DataSetName = "dsRepParms";
			this.dsRepParms1.EnforceConstraints = false;
			this.dsRepParms1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// ReporParamtersData
			// 
			this.ComponentDataAdabter = this.odaRepParms;
			this.ComponentDataSet = this.dsRepParms1;
			this.Connection = this.con1;
			((System.ComponentModel.ISupportInitialize)(this.dsRepParms1)).EndInit();

		}
		#endregion
	}
}
