using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for CompXJobtitlesData.
	/// </summary>
	public class CoElmentsXJobtitlesData : TSN.ERP.Engine.BussinesComponent 
	{
		private System.Data.OleDb.OleDbDataAdapter odaJobtitlesXCoElemetns;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbConnection con1;
		private TSN.ERP.SharedComponents.Data.dsJobXCoElements dsJobXCoElements1;
		private System.Data.OleDb.OleDbDataAdapter odaJobsByCoElement;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CoElmentsXJobtitlesData(System.ComponentModel.IContainer container)
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

		public  CoElmentsXJobtitlesData()
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
			this.odaJobtitlesXCoElemetns = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.con1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dsJobXCoElements1 = new TSN.ERP.SharedComponents.Data.dsJobXCoElements();
			this.odaJobsByCoElement = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsJobXCoElements1)).BeginInit();
			// 
			// odaJobtitlesXCoElemetns
			// 
			this.odaJobtitlesXCoElemetns.DeleteCommand = this.oleDbDeleteCommand1;
			this.odaJobtitlesXCoElemetns.InsertCommand = this.oleDbInsertCommand1;
			this.odaJobtitlesXCoElemetns.SelectCommand = this.oleDbSelectCommand1;
			this.odaJobtitlesXCoElemetns.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											  new System.Data.Common.DataTableMapping("Table", "GEN_JobTitlesXCoElments", new System.Data.Common.DataColumnMapping[] {
																																																										 new System.Data.Common.DataColumnMapping("CompElmentID", "CompElmentID"),
																																																										 new System.Data.Common.DataColumnMapping("JobTitleID", "JobTitleID")})});
			this.odaJobtitlesXCoElemetns.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM GEN_JobTitlesXCoElments WHERE (CompElmentID = ?) AND (JobTitleID = ?)" +
				"";
			this.oleDbDeleteCommand1.Connection = this.con1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompElmentID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompElmentID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "JobTitleID", System.Data.DataRowVersion.Original, null));
			// 
			// con1
			// 
			this.con1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=BASSAM;Tag with column collation when possible=False;Initial Catalog=ERPdb;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASSAM;Use Encryption for Data=False";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO GEN_JobTitlesXCoElments(CompElmentID, JobTitleID) VALUES (?, ?); SELE" +
				"CT CompElmentID, JobTitleID FROM GEN_JobTitlesXCoElments WHERE (CompElmentID = ?" +
				") AND (JobTitleID = ?)";
			this.oleDbInsertCommand1.Connection = this.con1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompElmentID", System.Data.OleDb.OleDbType.Integer, 4, "CompElmentID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_CompElmentID", System.Data.OleDb.OleDbType.Integer, 4, "CompElmentID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleID"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT CompElmentID, JobTitleID FROM GEN_JobTitlesXCoElments";
			this.oleDbSelectCommand1.Connection = this.con1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE GEN_JobTitlesXCoElments SET CompElmentID = ?, JobTitleID = ? WHERE (CompEl" +
				"mentID = ?) AND (JobTitleID = ?); SELECT CompElmentID, JobTitleID FROM GEN_JobTi" +
				"tlesXCoElments WHERE (CompElmentID = ?) AND (JobTitleID = ?)";
			this.oleDbUpdateCommand1.Connection = this.con1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompElmentID", System.Data.OleDb.OleDbType.Integer, 4, "CompElmentID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompElmentID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompElmentID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "JobTitleID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_CompElmentID", System.Data.OleDb.OleDbType.Integer, 4, "CompElmentID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_JobTitleID", System.Data.OleDb.OleDbType.Integer, 4, "JobTitleID"));
			// 
			// dsJobXCoElements1
			// 
			this.dsJobXCoElements1.DataSetName = "dsJobXCoElements";
			this.dsJobXCoElements1.EnforceConstraints = false;
			this.dsJobXCoElements1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// odaJobsByCoElement
			// 
			this.odaJobsByCoElement.SelectCommand = this.oleDbSelectCommand2;
			this.odaJobsByCoElement.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										 new System.Data.Common.DataTableMapping("Table", "GEN_JobTitles", new System.Data.Common.DataColumnMapping[] {
																																																						  new System.Data.Common.DataColumnMapping("JobTitleID", "JobTitleID"),
																																																						  new System.Data.Common.DataColumnMapping("JobName", "JobName"),
																																																						  new System.Data.Common.DataColumnMapping("JobTitleOrder", "JobTitleOrder")})});
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT GEN_JobTitles.JobTitleID, GEN_JobTitles.JobName, GEN_JobTitles.JobTitleOrd" +
				"er FROM GEN_JobTitlesXCoElments INNER JOIN GEN_JobTitles ON GEN_JobTitlesXCoElme" +
				"nts.JobTitleID = GEN_JobTitles.JobTitleID WHERE (GEN_JobTitlesXCoElments.CompElm" +
				"entID = ?)";
			this.oleDbSelectCommand2.Connection = this.con1;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompElmentID", System.Data.OleDb.OleDbType.Integer, 4, "CompElmentID"));
			// 
			// CoElmentsXJobtitlesData
			// 
			this.ComponentDataAdabter = this.odaJobtitlesXCoElemetns;
			this.ComponentDataSet = this.dsJobXCoElements1;
			this.Connection = this.con1;
			((System.ComponentModel.ISupportInitialize)(this.dsJobXCoElements1)).EndInit();

		}
		#endregion

		public DataSet ListJobtitlesByCoElement(int CoElement)
		{
			dsJobtitles tempds = new dsJobtitles();
			odaJobsByCoElement.SelectCommand.Parameters[0].Value = CoElement;
			odaJobsByCoElement.Fill(tempds);
			return tempds;
		}

		public int RemoveJobTitleFromCoElement( int jobTitle , int compElm )
		{

			odaJobtitlesXCoElemetns.DeleteCommand.Parameters[ 0 ].Value = compElm;
			odaJobtitlesXCoElemetns.DeleteCommand.Parameters[ 1 ].Value   = jobTitle;
			return odaJobtitlesXCoElemetns.DeleteCommand.ExecuteNonQuery();
		}	
	}
}
