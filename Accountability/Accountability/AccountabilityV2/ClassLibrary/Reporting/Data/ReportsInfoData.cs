using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace TSN.ERP.Reporting.Data
{
	/// <summary>
	/// Summary description for ReportsInfoData.
	/// </summary>
	public class ReportsInfoData : Engine.BussinesComponent
	{
		private System.Data.OleDb.OleDbDataAdapter odaReportInfo;
		private System.Data.OleDb.OleDbConnection con1;
		private TSN.ERP.Reporting.Data.dsReportsInfo dsReportsInfo1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbCommand odcSetRepInfo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ReportsInfoData(System.ComponentModel.IContainer container)
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

		public ReportsInfoData()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();
			ParentComponent = new TSN.ERP.SharedComponents.Data.FilesDataClass();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// 
		public int SetRepInfo(int ReportId, string Repinfo)
		{
			odcSetRepInfo.Parameters["ReportRunData"].Value = Repinfo;
			odcSetRepInfo.Parameters["Original_FileID"].Value = ReportId;
			object temp = odcSetRepInfo.ExecuteScalar();
			if (temp == null)
			{
				return -1;
			}
			return (int)temp;
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
			this.odaReportInfo = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.con1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dsReportsInfo1 = new TSN.ERP.Reporting.Data.dsReportsInfo();
			this.odcSetRepInfo = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsReportsInfo1)).BeginInit();
			// 
			// odaReportInfo
			// 
			this.odaReportInfo.DeleteCommand = this.oleDbDeleteCommand1;
			this.odaReportInfo.InsertCommand = this.oleDbInsertCommand1;
			this.odaReportInfo.SelectCommand = this.oleDbSelectCommand1;
			this.odaReportInfo.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									new System.Data.Common.DataTableMapping("Table", "REP_ReportInfo", new System.Data.Common.DataColumnMapping[] {
																																																					  new System.Data.Common.DataColumnMapping("FileID", "FileID"),
																																																					  new System.Data.Common.DataColumnMapping("ReportTypeID", "ReportTypeID"),
																																																					  new System.Data.Common.DataColumnMapping("ReportDescrition", "ReportDescrition"),
																																																					  new System.Data.Common.DataColumnMapping("ReportRunData", "ReportRunData")})});
			this.odaReportInfo.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM REP_ReportInfo WHERE (FileID = ?) AND (ReportTypeID = ? OR ? IS NULL " +
				"AND ReportTypeID IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.con1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FileID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FileID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ReportTypeID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReportTypeID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ReportTypeID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReportTypeID", System.Data.DataRowVersion.Original, null));
			// 
			// con1
			// 
			this.con1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=erp;Tag with column collation when possible=False;Initial Catalog=erpdb4;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASSAM;Use Encryption for Data=False";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO REP_ReportInfo(FileID, ReportTypeID, ReportDescrition, ReportRunData)" +
				" VALUES (?, ?, ?, ?); SELECT FileID, ReportTypeID, ReportDescrition, ReportRunDa" +
				"ta FROM REP_ReportInfo WHERE (FileID = ?)";
			this.oleDbInsertCommand1.Connection = this.con1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FileID", System.Data.OleDb.OleDbType.Integer, 4, "FileID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ReportTypeID", System.Data.OleDb.OleDbType.Integer, 4, "ReportTypeID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ReportDescrition", System.Data.OleDb.OleDbType.VarChar, 2147483647, "ReportDescrition"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ReportRunData", System.Data.OleDb.OleDbType.VarChar, 2147483647, "ReportRunData"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_FileID", System.Data.OleDb.OleDbType.Integer, 4, "FileID"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT FileID, ReportTypeID, ReportDescrition, ReportRunData FROM REP_ReportInfo";
			this.oleDbSelectCommand1.Connection = this.con1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE REP_ReportInfo SET FileID = ?, ReportTypeID = ?, ReportDescrition = ?, ReportRunData = ? WHERE (FileID = ?) AND (ReportTypeID = ? OR ? IS NULL AND ReportTypeID IS NULL); SELECT FileID, ReportTypeID, ReportDescrition, ReportRunData FROM REP_ReportInfo WHERE (FileID = ?)";
			this.oleDbUpdateCommand1.Connection = this.con1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FileID", System.Data.OleDb.OleDbType.Integer, 4, "FileID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ReportTypeID", System.Data.OleDb.OleDbType.Integer, 4, "ReportTypeID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ReportDescrition", System.Data.OleDb.OleDbType.VarChar, 2147483647, "ReportDescrition"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ReportRunData", System.Data.OleDb.OleDbType.VarChar, 2147483647, "ReportRunData"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FileID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FileID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ReportTypeID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReportTypeID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ReportTypeID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReportTypeID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_FileID", System.Data.OleDb.OleDbType.Integer, 4, "FileID"));
			// 
			// dsReportsInfo1
			// 
			this.dsReportsInfo1.DataSetName = "dsReportsInfo";
			this.dsReportsInfo1.EnforceConstraints = false;
			this.dsReportsInfo1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// odcSetRepInfo
			// 
			this.odcSetRepInfo.CommandText = "UPDATE REP_ReportInfo SET ReportRunData = ? WHERE (FileID = ?)";
			this.odcSetRepInfo.Connection = this.con1;
			this.odcSetRepInfo.Parameters.Add(new System.Data.OleDb.OleDbParameter("ReportRunData", System.Data.OleDb.OleDbType.VarChar, 2147483647, "ReportRunData"));
			this.odcSetRepInfo.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FileID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FileID", System.Data.DataRowVersion.Original, null));
			// 
			// ReportsInfoData
			// 
			this.ComponentDataAdabter = this.odaReportInfo;
			this.ComponentDataSet = this.dsReportsInfo1;
			this.Connection = this.con1;
			((System.ComponentModel.ISupportInitialize)(this.dsReportsInfo1)).EndInit();

		}
		#endregion
	}
}
