using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for TeamsDataClass.
	/// </summary>
	public class TeamsDataClass : TSN.ERP.Engine.BussinesComponent 
	{
		private TSN.ERP.SharedComponents.Data.dsTeams dsTeams1;
		private System.Data.OleDb.OleDbDataAdapter odaTeams;
		private System.Data.OleDb.OleDbConnection con1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TeamsDataClass(System.ComponentModel.IContainer container)
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

		public TeamsDataClass()
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
			this.odaTeams = new System.Data.OleDb.OleDbDataAdapter();
			this.con1 = new System.Data.OleDb.OleDbConnection();
			this.dsTeams1 = new TSN.ERP.SharedComponents.Data.dsTeams();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsTeams1)).BeginInit();
			// 
			// odaTeams
			// 
			this.odaTeams.DeleteCommand = this.oleDbDeleteCommand1;
			this.odaTeams.InsertCommand = this.oleDbInsertCommand1;
			this.odaTeams.SelectCommand = this.oleDbSelectCommand1;
			this.odaTeams.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							   new System.Data.Common.DataTableMapping("Table", "GEN_Teams", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("TeamID", "TeamID"),
																																																			new System.Data.Common.DataColumnMapping("projectID", "projectID"),
																																																			new System.Data.Common.DataColumnMapping("TeamName", "TeamName"),
																																																			new System.Data.Common.DataColumnMapping("TeamLeader", "TeamLeader"),
																																																			new System.Data.Common.DataColumnMapping("TeamDesc", "TeamDesc")})});
			this.odaTeams.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// con1
			// 
			this.con1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=bassam;Tag with column collation when possible=False;Initial Catalog=ERPdbFinal;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASSAM;Use Encryption for Data=False";
			// 
			// dsTeams1
			// 
			this.dsTeams1.DataSetName = "dsTeams";
			this.dsTeams1.EnforceConstraints = false;
			this.dsTeams1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT TeamID, projectID, TeamName, TeamLeader, TeamDesc FROM GEN_Teams";
			this.oleDbSelectCommand1.Connection = this.con1;
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO GEN_Teams(TeamID, projectID, TeamName, TeamLeader, TeamDesc) VALUES (" +
				"?, ?, ?, ?, ?); SELECT TeamID, projectID, TeamName, TeamLeader, TeamDesc FROM GE" +
				"N_Teams WHERE (TeamID = ?)";
			this.oleDbInsertCommand1.Connection = this.con1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TeamID", System.Data.OleDb.OleDbType.Integer, 4, "TeamID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("projectID", System.Data.OleDb.OleDbType.Integer, 4, "projectID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TeamName", System.Data.OleDb.OleDbType.VarChar, 120, "TeamName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TeamLeader", System.Data.OleDb.OleDbType.Integer, 4, "TeamLeader"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TeamDesc", System.Data.OleDb.OleDbType.VarChar, 2147483647, "TeamDesc"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_TeamID", System.Data.OleDb.OleDbType.Integer, 4, "TeamID"));
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE GEN_Teams SET TeamID = ?, projectID = ?, TeamName = ?, TeamLeader = ?, TeamDesc = ? WHERE (TeamID = ?) AND (TeamLeader = ? OR ? IS NULL AND TeamLeader IS NULL) AND (TeamName = ?) AND (projectID = ? OR ? IS NULL AND projectID IS NULL); SELECT TeamID, projectID, TeamName, TeamLeader, TeamDesc FROM GEN_Teams WHERE (TeamID = ?)";
			this.oleDbUpdateCommand1.Connection = this.con1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TeamID", System.Data.OleDb.OleDbType.Integer, 4, "TeamID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("projectID", System.Data.OleDb.OleDbType.Integer, 4, "projectID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TeamName", System.Data.OleDb.OleDbType.VarChar, 120, "TeamName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TeamLeader", System.Data.OleDb.OleDbType.Integer, 4, "TeamLeader"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TeamDesc", System.Data.OleDb.OleDbType.VarChar, 2147483647, "TeamDesc"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TeamID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TeamID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TeamLeader", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TeamLeader", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TeamLeader1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TeamLeader", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TeamName", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TeamName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_projectID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "projectID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_projectID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "projectID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_TeamID", System.Data.OleDb.OleDbType.Integer, 4, "TeamID"));
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM GEN_Teams WHERE (TeamID = ?) AND (TeamLeader = ? OR ? IS NULL AND Tea" +
				"mLeader IS NULL) AND (TeamName = ?) AND (projectID = ? OR ? IS NULL AND projectI" +
				"D IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.con1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TeamID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TeamID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TeamLeader", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TeamLeader", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TeamLeader1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TeamLeader", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TeamName", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TeamName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_projectID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "projectID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_projectID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "projectID", System.Data.DataRowVersion.Original, null));
			// 
			// TeamsDataClass
			// 
			this.ComponentDataAdabter = this.odaTeams;
			this.ComponentDataSet = this.dsTeams1;
			this.Connection = this.con1;
			((System.ComponentModel.ISupportInitialize)(this.dsTeams1)).EndInit();

		}
		#endregion
	}
}
