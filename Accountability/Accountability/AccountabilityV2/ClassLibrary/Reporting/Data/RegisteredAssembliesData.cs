using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using TSN.ERP.Engine;
using TSN.ERP.SharedComponents;

namespace TSN.ERP.Reporting.Data
{
	/// <summary>
	/// Summary description for RegisteredAssembliesData.
	/// </summary>
	public class RegisteredAssembliesData : BussinesComponent
	{
		private System.Data.OleDb.OleDbDataAdapter odaRegisteredAssemblies;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbConnection con1;
		private TSN.ERP.Reporting.Data.dsRegisteredAssemblies dsRegisteredAssemblies1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RegisteredAssembliesData(System.ComponentModel.IContainer container)
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

		public RegisteredAssembliesData()
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
			this.odaRegisteredAssemblies = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.con1 = new System.Data.OleDb.OleDbConnection();
			this.dsRegisteredAssemblies1 = new TSN.ERP.Reporting.Data.dsRegisteredAssemblies();
			((System.ComponentModel.ISupportInitialize)(this.dsRegisteredAssemblies1)).BeginInit();
			// 
			// odaRegisteredAssemblies
			// 
			this.odaRegisteredAssemblies.SelectCommand = this.oleDbSelectCommand1;
			this.odaRegisteredAssemblies.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											  new System.Data.Common.DataTableMapping("Table", "GEN_RegisteredAssemblies", new System.Data.Common.DataColumnMapping[] {
																																																										  new System.Data.Common.DataColumnMapping("cAssemblyName", "cAssemblyName"),
																																																										  new System.Data.Common.DataColumnMapping("cAssemblyDesc", "cAssemblyDesc")})});
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT cAssemblyName, cAssemblyDesc FROM GEN_RegisteredAssemblies";
			this.oleDbSelectCommand1.Connection = this.con1;
			// 
			// con1
			// 
			this.con1.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=BASSAM;Tag with column collation when possible=False;Initial Catalog=ERPdb;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=BASSAM;Use Encryption for Data=False";
			// 
			// dsRegisteredAssemblies1
			// 
			this.dsRegisteredAssemblies1.DataSetName = "dsRegisteredAssemblies";
			this.dsRegisteredAssemblies1.EnforceConstraints = false;
			this.dsRegisteredAssemblies1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// RegisteredAssembliesData
			// 
			this.ComponentDataAdabter = this.odaRegisteredAssemblies;
			this.ComponentDataSet = this.dsRegisteredAssemblies1;
			this.Connection = this.con1;
			((System.ComponentModel.ISupportInitialize)(this.dsRegisteredAssemblies1)).EndInit();

		}
		#endregion
	}
}
