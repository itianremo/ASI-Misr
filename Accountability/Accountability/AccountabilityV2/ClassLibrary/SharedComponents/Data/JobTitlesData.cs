using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;

namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for JobtitlesData.
	/// </summary>
	public class JobtitlesData :TSN.ERP.Engine.BussinesComponent 
	{
		private System.Data.OleDb.OleDbDataAdapter odaJobTitles;
		private System.Data.OleDb.OleDbConnection con1;
		private TSN.ERP.SharedComponents.Data.dsJobtitles dsJobtitles1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterSingleJobTitle;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterIsJobTitleActive;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public JobtitlesData(System.ComponentModel.IContainer container)
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

		public JobtitlesData()
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
			this.odaJobTitles = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.con1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dsJobtitles1 = new TSN.ERP.SharedComponents.Data.dsJobtitles();
			this.oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterSingleJobTitle = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterIsJobTitleActive = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsJobtitles1)).BeginInit();
			// 
			// odaJobTitles
			// 
			this.odaJobTitles.DeleteCommand = this.oleDbDeleteCommand1;
			this.odaJobTitles.InsertCommand = this.oleDbInsertCommand1;
			this.odaJobTitles.SelectCommand = this.oleDbSelectCommand1;
			this.odaJobTitles.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								   new System.Data.Common.DataTableMapping("Table", "GEN_JobTitles", new System.Data.Common.DataColumnMapping[] {
																																																					new System.Data.Common.DataColumnMapping("JobTitleID", "JobTitleID"),
																																																					new System.Data.Common.DataColumnMapping("JobName", "JobName"),
																																																					new System.Data.Common.DataColumnMapping("JobTitleOrder", "JobTitleOrder"),
																																																					new System.Data.Common.DataColumnMapping("JobDescription", "JobDescription"),
																																																					new System.Data.Common.DataColumnMapping("IsActive", "IsActive")})});
			this.odaJobTitles.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM GEN_JobTitles WHERE (JobTitleID = ?)";
			this.oleDbDeleteCommand1.Connection = this.con1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "JobTitleID", System.Data.DataRowVersion.Original, null));
			// 
			// con1
			// 
			this.con1.ConnectionString = @"Auto Translate=True;User ID=RW;Tag with column collation when possible=False;Data Source=""erp\erpsql2005"";Password=RW;Initial Catalog=TestAccountability_Data;Use Procedure for Prepare=1;Provider=""SQLOLEDB.1"";Persist Security Info=True;Workstation ID=HAMDYAHMED;Use Encryption for Data=False;Packet Size=4096";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO GEN_JobTitles (JobTitleID, JobName, JobTitleOrder, JobDescription, Is" +
				"Active) VALUES (?, ?, ?, ?, ?); SELECT JobTitleID, JobName, JobTitleOrder, JobDe" +
				"scription, IsActive FROM GEN_JobTitles WHERE (JobTitleID = ?)";
			this.oleDbInsertCommand1.Connection = this.con1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobName", System.Data.OleDb.OleDbType.VarChar, 120, "JobName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobTitleOrder", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleOrder"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobDescription", System.Data.OleDb.OleDbType.VarChar, 150, "JobDescription"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IsActive", System.Data.OleDb.OleDbType.Boolean, 1, "IsActive"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select1_JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleID"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT JobTitleID, JobName, JobTitleOrder, JobDescription, IsActive FROM GEN_JobT" +
				"itles";
			this.oleDbSelectCommand1.Connection = this.con1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE GEN_JobTitles SET JobTitleID = ?, JobName = ?, JobTitleOrder = ?, JobDescr" +
				"iption = ?, IsActive = ? WHERE (JobTitleID = ?); SELECT JobTitleID, JobName, Job" +
				"TitleOrder, JobDescription, IsActive FROM GEN_JobTitles WHERE (JobTitleID = ?)";
			this.oleDbUpdateCommand1.Connection = this.con1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobName", System.Data.OleDb.OleDbType.VarChar, 120, "JobName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobTitleOrder", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleOrder"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobDescription", System.Data.OleDb.OleDbType.VarChar, 150, "JobDescription"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IsActive", System.Data.OleDb.OleDbType.Boolean, 1, "IsActive"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "JobTitleID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select1_JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleID"));
			// 
			// dsJobtitles1
			// 
			this.dsJobtitles1.DataSetName = "dsJobtitles";
			this.dsJobtitles1.EnforceConstraints = false;
			this.dsJobtitles1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// oleDbDataAdapter1
			// 
			this.oleDbDataAdapter1.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "GEN_JobTitles", new System.Data.Common.DataColumnMapping[] {
																																																						 new System.Data.Common.DataColumnMapping("JobTitleID", "JobTitleID"),
																																																						 new System.Data.Common.DataColumnMapping("JobName", "JobName"),
																																																						 new System.Data.Common.DataColumnMapping("JobTitleOrder", "JobTitleOrder"),
																																																						 new System.Data.Common.DataColumnMapping("JobDescription", "JobDescription"),
																																																						 new System.Data.Common.DataColumnMapping("IsActive", "IsActive")})});
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT JobTitleID, JobName, JobTitleOrder, JobDescription, IsActive FROM GEN_JobT" +
				"itles WHERE (IsActive = ?)";
			this.oleDbSelectCommand2.Connection = this.con1;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("IsActive", System.Data.OleDb.OleDbType.Boolean, 1, "IsActive"));
			// 
			// oleDbDataAdapterSingleJobTitle
			// 
			this.oleDbDataAdapterSingleJobTitle.SelectCommand = this.oleDbSelectCommand3;
			this.oleDbDataAdapterSingleJobTitle.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													 new System.Data.Common.DataTableMapping("Table", "GEN_JobTitles", new System.Data.Common.DataColumnMapping[] {
																																																									  new System.Data.Common.DataColumnMapping("JobTitleID", "JobTitleID"),
																																																									  new System.Data.Common.DataColumnMapping("JobName", "JobName"),
																																																									  new System.Data.Common.DataColumnMapping("JobTitleOrder", "JobTitleOrder"),
																																																									  new System.Data.Common.DataColumnMapping("JobDescription", "JobDescription"),
																																																									  new System.Data.Common.DataColumnMapping("IsActive", "IsActive")})});
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = "SELECT JobTitleID, JobName, JobTitleOrder, JobDescription, IsActive FROM GEN_JobT" +
				"itles WHERE (JobTitleID = ?)";
			this.oleDbSelectCommand3.Connection = this.con1;
			this.oleDbSelectCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleID"));
			// 
			// oleDbDataAdapterIsJobTitleActive
			// 
			this.oleDbDataAdapterIsJobTitleActive.SelectCommand = this.oleDbSelectCommand4;
			this.oleDbDataAdapterIsJobTitleActive.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													   new System.Data.Common.DataTableMapping("Table", "GEN_JobTitles", new System.Data.Common.DataColumnMapping[] {
																																																										new System.Data.Common.DataColumnMapping("IsActive", "IsActive")})});
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = "SELECT IsActive FROM GEN_JobTitles WHERE (JobTitleID = ?)";
			this.oleDbSelectCommand4.Connection = this.con1;
			this.oleDbSelectCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleID"));
			// 
			// JobtitlesData
			// 
			this.ComponentDataAdabter = this.odaJobTitles;
			this.ComponentDataSet = this.dsJobtitles1;
			this.Connection = this.con1;
			((System.ComponentModel.ISupportInitialize)(this.dsJobtitles1)).EndInit();

		}
		#endregion


		public System.Data.DataSet ListActiveJobTitles()
		{
			DataSet dsActiveJobtitles = new DataSet();
			this.oleDbDataAdapter1.SelectCommand.Parameters[0].Value = true;
			this.oleDbDataAdapter1.Fill(dsActiveJobtitles);
			return dsActiveJobtitles;
		}

		public System.Data.DataSet ListClosedJobTitles()
		{
			DataSet dsClosedJobtitles = new DataSet();
			this.oleDbDataAdapter1.SelectCommand.Parameters[0].Value = false;
			this.oleDbDataAdapter1.Fill(dsClosedJobtitles);
			return dsClosedJobtitles;
		}

		public System.Data.DataSet ListSingleJobTitle( int JobTitleID)
		{
			DataSet dsSingleJobTitle = new DataSet();
			this.oleDbDataAdapterSingleJobTitle.SelectCommand.Parameters[0].Value = JobTitleID;
			this.oleDbDataAdapterSingleJobTitle.Fill(dsSingleJobTitle);			
			return dsSingleJobTitle;
		}

		public bool IsJobTitleActive( int JobTitleID)
		{
			this.oleDbDataAdapterIsJobTitleActive.SelectCommand.Parameters[0].Value = JobTitleID;
			bool VBIsJobtitleActive = Convert.ToBoolean(this.oleDbDataAdapterIsJobTitleActive.SelectCommand.ExecuteScalar());
			return VBIsJobtitleActive;
		}
	}
}
