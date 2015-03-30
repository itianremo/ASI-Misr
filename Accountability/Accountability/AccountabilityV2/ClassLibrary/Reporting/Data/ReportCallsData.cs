using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using TSN.ERP.Engine;
namespace TSN.ERP.Reporting.Data
{
	/// <summary>
	/// Summary description for ReportCallsData.
	/// </summary>
	public class ReportCallsData : BussinesComponent
	{
		private System.Data.OleDb.OleDbDataAdapter odaReportCalls;
		private System.Data.OleDb.OleDbConnection con1;
		private TSN.ERP.Reporting.Data.dsReportCalls dsReportCalls1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ReportCallsData(System.ComponentModel.IContainer container)
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

		public ReportCallsData()
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
			this.odaReportCalls = new System.Data.OleDb.OleDbDataAdapter();
			this.con1 = new System.Data.OleDb.OleDbConnection();
			this.dsReportCalls1 = new TSN.ERP.Reporting.Data.dsReportCalls();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsReportCalls1)).BeginInit();
			// 
			// odaReportCalls
			// 
			this.odaReportCalls.DeleteCommand = this.oleDbDeleteCommand1;
			this.odaReportCalls.InsertCommand = this.oleDbInsertCommand1;
			this.odaReportCalls.SelectCommand = this.oleDbSelectCommand1;
			this.odaReportCalls.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									 new System.Data.Common.DataTableMapping("Table", "REP_Calls", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("RepCallIId", "RepCallIId"),
																																																				  new System.Data.Common.DataColumnMapping("cAssemblyName", "cAssemblyName"),
																																																				  new System.Data.Common.DataColumnMapping("FileID", "FileID"),
																																																				  new System.Data.Common.DataColumnMapping("RepCallDesc", "RepCallDesc"),
																																																				  new System.Data.Common.DataColumnMapping("RCTypeName", "RCTypeName"),
																																																				  new System.Data.Common.DataColumnMapping("RCMethodName", "RCMethodName"),
																																																				  new System.Data.Common.DataColumnMapping("RCRetType", "RCRetType"),
																																																				  new System.Data.Common.DataColumnMapping("RCArgs", "RCArgs")})});
			this.odaReportCalls.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// con1
			// 
			this.con1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=BASSAM;Tag with column collation when possible=False;Initial Catalog=ERPdb;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASSAM;Use Encryption for Data=False";
			// 
			// dsReportCalls1
			// 
			this.dsReportCalls1.DataSetName = "dsReportCalls";
			this.dsReportCalls1.EnforceConstraints = false;
			this.dsReportCalls1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT RepCallIId, cAssemblyName, FileID, RepCallDesc, RCTypeName, RCMethodName, " +
				"RCRetType, RCArgs FROM REP_Calls";
			this.oleDbSelectCommand1.Connection = this.con1;
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = @"INSERT INTO REP_Calls(RepCallIId, cAssemblyName, FileID, RepCallDesc, RCTypeName, RCMethodName, RCRetType, RCArgs) VALUES (?, ?, ?, ?, ?, ?, ?, ?); SELECT RepCallIId, cAssemblyName, FileID, RepCallDesc, RCTypeName, RCMethodName, RCRetType, RCArgs FROM REP_Calls WHERE (RepCallIId = ?)";
			this.oleDbInsertCommand1.Connection = this.con1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RepCallIId", System.Data.OleDb.OleDbType.Integer, 4, "RepCallIId"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("cAssemblyName", System.Data.OleDb.OleDbType.VarChar, 250, "cAssemblyName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FileID", System.Data.OleDb.OleDbType.Integer, 4, "FileID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RepCallDesc", System.Data.OleDb.OleDbType.VarChar, 2147483647, "RepCallDesc"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RCTypeName", System.Data.OleDb.OleDbType.VarChar, 250, "RCTypeName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RCMethodName", System.Data.OleDb.OleDbType.VarChar, 250, "RCMethodName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RCRetType", System.Data.OleDb.OleDbType.Integer, 4, "RCRetType"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RCArgs", System.Data.OleDb.OleDbType.VarChar, 2147483647, "RCArgs"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_RepCallIId", System.Data.OleDb.OleDbType.Integer, 4, "RepCallIId"));
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE REP_Calls SET RepCallIId = ?, cAssemblyName = ?, FileID = ?, RepCallDesc = ?, RCTypeName = ?, RCMethodName = ?, RCRetType = ?, RCArgs = ? WHERE (RepCallIId = ?) AND (FileID = ? OR ? IS NULL AND FileID IS NULL) AND (RCMethodName = ? OR ? IS NULL AND RCMethodName IS NULL) AND (RCRetType = ? OR ? IS NULL AND RCRetType IS NULL) AND (RCTypeName = ? OR ? IS NULL AND RCTypeName IS NULL) AND (cAssemblyName = ? OR ? IS NULL AND cAssemblyName IS NULL); SELECT RepCallIId, cAssemblyName, FileID, RepCallDesc, RCTypeName, RCMethodName, RCRetType, RCArgs FROM REP_Calls WHERE (RepCallIId = ?)";
			this.oleDbUpdateCommand1.Connection = this.con1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RepCallIId", System.Data.OleDb.OleDbType.Integer, 4, "RepCallIId"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("cAssemblyName", System.Data.OleDb.OleDbType.VarChar, 250, "cAssemblyName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FileID", System.Data.OleDb.OleDbType.Integer, 4, "FileID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RepCallDesc", System.Data.OleDb.OleDbType.VarChar, 2147483647, "RepCallDesc"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RCTypeName", System.Data.OleDb.OleDbType.VarChar, 250, "RCTypeName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RCMethodName", System.Data.OleDb.OleDbType.VarChar, 250, "RCMethodName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RCRetType", System.Data.OleDb.OleDbType.Integer, 4, "RCRetType"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RCArgs", System.Data.OleDb.OleDbType.VarChar, 2147483647, "RCArgs"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RepCallIId", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RepCallIId", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FileID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FileID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FileID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FileID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCMethodName", System.Data.OleDb.OleDbType.VarChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCMethodName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCMethodName1", System.Data.OleDb.OleDbType.VarChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCMethodName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCRetType", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCRetType", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCRetType1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCRetType", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCTypeName", System.Data.OleDb.OleDbType.VarChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCTypeName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCTypeName1", System.Data.OleDb.OleDbType.VarChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCTypeName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cAssemblyName", System.Data.OleDb.OleDbType.VarChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cAssemblyName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cAssemblyName1", System.Data.OleDb.OleDbType.VarChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cAssemblyName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_RepCallIId", System.Data.OleDb.OleDbType.Integer, 4, "RepCallIId"));
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = @"DELETE FROM REP_Calls WHERE (RepCallIId = ?) AND (FileID = ? OR ? IS NULL AND FileID IS NULL) AND (RCMethodName = ? OR ? IS NULL AND RCMethodName IS NULL) AND (RCRetType = ? OR ? IS NULL AND RCRetType IS NULL) AND (RCTypeName = ? OR ? IS NULL AND RCTypeName IS NULL) AND (cAssemblyName = ? OR ? IS NULL AND cAssemblyName IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.con1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RepCallIId", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RepCallIId", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FileID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FileID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FileID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FileID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCMethodName", System.Data.OleDb.OleDbType.VarChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCMethodName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCMethodName1", System.Data.OleDb.OleDbType.VarChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCMethodName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCRetType", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCRetType", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCRetType1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCRetType", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCTypeName", System.Data.OleDb.OleDbType.VarChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCTypeName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RCTypeName1", System.Data.OleDb.OleDbType.VarChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RCTypeName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cAssemblyName", System.Data.OleDb.OleDbType.VarChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cAssemblyName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_cAssemblyName1", System.Data.OleDb.OleDbType.VarChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cAssemblyName", System.Data.DataRowVersion.Original, null));
			// 
			// ReportCallsData
			// 
			this.ComponentDataAdabter = this.odaReportCalls;
			this.ComponentDataSet = this.dsReportCalls1;
			this.Connection = this.con1;
			((System.ComponentModel.ISupportInitialize)(this.dsReportCalls1)).EndInit();

		}
		#endregion
	}
}
