using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for ProjectLevels.
	/// </summary>
	public class ProjectLevels :TSN.ERP.Engine.BussinesComponent 
	{
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterPrjLevels;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private TSN.ERP.SharedComponents.Data.dsProjectsLevels dsProjectsLevels1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ProjectLevels(System.ComponentModel.IContainer container)
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

		public ProjectLevels()
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
			this.oleDbDataAdapterPrjLevels = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dsProjectsLevels1 = new TSN.ERP.SharedComponents.Data.dsProjectsLevels();
			((System.ComponentModel.ISupportInitialize)(this.dsProjectsLevels1)).BeginInit();
			// 
			// oleDbDataAdapterPrjLevels
			// 
			this.oleDbDataAdapterPrjLevels.DeleteCommand = this.oleDbDeleteCommand1;
			this.oleDbDataAdapterPrjLevels.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbDataAdapterPrjLevels.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbDataAdapterPrjLevels.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												new System.Data.Common.DataTableMapping("Table", "GEN_ProjectsHierarchy", new System.Data.Common.DataColumnMapping[] {
																																																										 new System.Data.Common.DataColumnMapping("ProjectElementID", "ProjectElementID"),
																																																										 new System.Data.Common.DataColumnMapping("ProjectElementName", "ProjectElementName"),
																																																										 new System.Data.Common.DataColumnMapping("ProjectElementDesc", "ProjectElementDesc"),
																																																										 new System.Data.Common.DataColumnMapping("ProjectElementParent", "ProjectElementParent")})});
			this.oleDbDataAdapterPrjLevels.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM GEN_ProjectsHierarchy WHERE (ProjectElementID = ?) AND (ProjectElemen" +
				"tName = ? OR ? IS NULL AND ProjectElementName IS NULL) AND (ProjectElementParent" +
				" = ? OR ? IS NULL AND ProjectElementParent IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectElementID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectElementID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectElementName", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectElementName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectElementName1", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectElementName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectElementParent", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectElementParent", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectElementParent1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectElementParent", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Auto Translate=True;Integrated Security=SSPI;User ID=RW;Data Source=""ERP\ERPSQL2005"";Tag with column collation when possible=False;Initial Catalog=TestAccountability_Data;Use Procedure for Prepare=1;Provider=""SQLOLEDB.1"";Persist Security Info=False;Workstation ID=HAMDYAHMED;Use Encryption for Data=False;Packet Size=4096";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = @"INSERT INTO GEN_ProjectsHierarchy(ProjectElementID, ProjectElementName, ProjectElementDesc, ProjectElementParent) VALUES (?, ?, ?, ?); SELECT ProjectElementID, ProjectElementName, ProjectElementDesc, ProjectElementParent FROM GEN_ProjectsHierarchy WHERE (ProjectElementID = ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectElementID", System.Data.OleDb.OleDbType.Integer, 4, "ProjectElementID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectElementName", System.Data.OleDb.OleDbType.VarChar, 150, "ProjectElementName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectElementDesc", System.Data.OleDb.OleDbType.VarChar, 2147483647, "ProjectElementDesc"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectElementParent", System.Data.OleDb.OleDbType.Integer, 4, "ProjectElementParent"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_ProjectElementID", System.Data.OleDb.OleDbType.Integer, 4, "ProjectElementID"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT ProjectElementID, ProjectElementName, ProjectElementDesc, ProjectElementPa" +
				"rent FROM GEN_ProjectsHierarchy ORDER BY ProjectElementName";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE GEN_ProjectsHierarchy SET ProjectElementID = ?, ProjectElementName = ?, ProjectElementDesc = ?, ProjectElementParent = ? WHERE (ProjectElementID = ?) AND (ProjectElementName = ? OR ? IS NULL AND ProjectElementName IS NULL) AND (ProjectElementParent = ? OR ? IS NULL AND ProjectElementParent IS NULL); SELECT ProjectElementID, ProjectElementName, ProjectElementDesc, ProjectElementParent FROM GEN_ProjectsHierarchy WHERE (ProjectElementID = ?)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectElementID", System.Data.OleDb.OleDbType.Integer, 4, "ProjectElementID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectElementName", System.Data.OleDb.OleDbType.VarChar, 150, "ProjectElementName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectElementDesc", System.Data.OleDb.OleDbType.VarChar, 2147483647, "ProjectElementDesc"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ProjectElementParent", System.Data.OleDb.OleDbType.Integer, 4, "ProjectElementParent"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectElementID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectElementID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectElementName", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectElementName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectElementName1", System.Data.OleDb.OleDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectElementName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectElementParent", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectElementParent", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ProjectElementParent1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProjectElementParent", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_ProjectElementID", System.Data.OleDb.OleDbType.Integer, 4, "ProjectElementID"));
			// 
			// dsProjectsLevels1
			// 
			this.dsProjectsLevels1.DataSetName = "dsProjectsLevels";
			this.dsProjectsLevels1.EnforceConstraints = false;
			this.dsProjectsLevels1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// ProjectLevels
			// 
			this.ComponentDataAdabter = this.oleDbDataAdapterPrjLevels;
			this.ComponentDataSet = this.dsProjectsLevels1;
			this.Connection = this.oleDbConnection1;
			((System.ComponentModel.ISupportInitialize)(this.dsProjectsLevels1)).EndInit();

		}
		#endregion
	}
}
