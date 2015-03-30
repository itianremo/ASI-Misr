using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;

namespace TSN.ERP.Timing.Data
{
	/// <summary>
	/// Summary description for Timing_CompanySettings.
	/// </summary>
	public class Timing_CompanySettings : Engine.BussinesComponent
	{
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbCommand1;
		private System.Data.OleDb.OleDbCommand oleDbCommand2;
		private System.Data.OleDb.OleDbConnection Con;
		private TSN.ERP.Timing.Data.dsTiming_CompanySettings dsTiming_CompanySettings1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Timing_CompanySettings(System.ComponentModel.IContainer container)
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

		public Timing_CompanySettings()
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
        ////////////////////////////protected override void Dispose( bool disposing )
        ////////////////////////////{
        ////////////////////////////    if( disposing )
        ////////////////////////////    {
        ////////////////////////////        if(components != null)
        ////////////////////////////        {
        ////////////////////////////            components.Dispose();
        ////////////////////////////        }
        ////////////////////////////    }
        ////////////////////////////    base.Dispose( disposing );
        ////////////////////////////}


		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
			this.Con = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
			this.dsTiming_CompanySettings1 = new TSN.ERP.Timing.Data.dsTiming_CompanySettings();
			((System.ComponentModel.ISupportInitialize)(this.dsTiming_CompanySettings1)).BeginInit();
			// 
			// oleDbDataAdapter1
			// 
			this.oleDbDataAdapter1.DeleteCommand = this.oleDbCommand1;
			this.oleDbDataAdapter1.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbDataAdapter1.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "Timing_CompanySettings", new System.Data.Common.DataColumnMapping[] {
																																																								  new System.Data.Common.DataColumnMapping("Serial", "Serial"),
																																																								  new System.Data.Common.DataColumnMapping("MailServer", "MailServer"),
																																																								  new System.Data.Common.DataColumnMapping("MonthStart", "MonthStart"),
																																																								  new System.Data.Common.DataColumnMapping("MonthEnd", "MonthEnd"),
																																																								  new System.Data.Common.DataColumnMapping("MaxHoursPerDay", "MaxHoursPerDay"),
																																																								  new System.Data.Common.DataColumnMapping("MaxHoursPerWeek", "MaxHoursPerWeek")})});
			this.oleDbDataAdapter1.UpdateCommand = this.oleDbCommand2;
			// 
			// oleDbCommand1
			// 
			this.oleDbCommand1.CommandText = "DELETE FROM Timing_CompanySettings WHERE (Serial = ?)";
			this.oleDbCommand1.Connection = this.Con;
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Serial", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Serial", System.Data.DataRowVersion.Original, null));
			// 
			// Con
			// 
			this.Con.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=""erp\erpsql2005"";Tag with column collation when possible=False;Initial Catalog=TestAccountability_Data;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=HAMDYAHMED;Use Encryption for Data=False";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO Timing_CompanySettings(Serial, MailServer, MonthStart, MonthEnd, MaxH" +
				"oursPerDay, MaxHoursPerWeek) VALUES (?, ?, ?, ?, ?, ?); SELECT Serial, MailServe" +
				"r, MonthStart, MonthEnd, MaxHoursPerDay, MaxHoursPerWeek FROM Timing_CompanySett" +
				"ings";
			this.oleDbInsertCommand1.Connection = this.Con;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Serial", System.Data.OleDb.OleDbType.Integer, 4, "Serial"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("MailServer", System.Data.OleDb.OleDbType.VarChar, 50, "MailServer"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("MonthStart", System.Data.OleDb.OleDbType.Integer, 4, "MonthStart"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("MonthEnd", System.Data.OleDb.OleDbType.Integer, 4, "MonthEnd"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("MaxHoursPerDay", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((System.Byte)(18)), ((System.Byte)(2)), "MaxHoursPerDay", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("MaxHoursPerWeek", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((System.Byte)(18)), ((System.Byte)(2)), "MaxHoursPerWeek", System.Data.DataRowVersion.Current, null));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT Serial, MailServer, MonthStart, MonthEnd, MaxHoursPerDay, MaxHoursPerWeek " +
				"FROM Timing_CompanySettings";
			this.oleDbSelectCommand1.Connection = this.Con;
			// 
			// oleDbCommand2
			// 
			this.oleDbCommand2.CommandText = "UPDATE Timing_CompanySettings SET MailServer = ?, MonthStart = ?, MonthEnd = ?, M" +
				"axHoursPerDay = ?, MaxHoursPerWeek = ? WHERE (Serial = ?)";
			this.oleDbCommand2.Connection = this.Con;
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("MailServer", System.Data.OleDb.OleDbType.VarChar, 50, "MailServer"));
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("MonthStart", System.Data.OleDb.OleDbType.Integer, 4, "MonthStart"));
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("MonthEnd", System.Data.OleDb.OleDbType.Integer, 4, "MonthEnd"));
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("MaxHoursPerDay", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((System.Byte)(18)), ((System.Byte)(2)), "MaxHoursPerDay", System.Data.DataRowVersion.Current, null));
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("MaxHoursPerWeek", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((System.Byte)(18)), ((System.Byte)(2)), "MaxHoursPerWeek", System.Data.DataRowVersion.Current, null));
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Serial", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Serial", System.Data.DataRowVersion.Original, null));
			// 
			// dsTiming_CompanySettings1
			// 
			this.dsTiming_CompanySettings1.DataSetName = "dsTiming_CompanySettings";
			this.dsTiming_CompanySettings1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// Timing_CompanySettings
			// 
			this.ComponentDataAdabter = this.oleDbDataAdapter1;
			this.Connection = this.Con;
			((System.ComponentModel.ISupportInitialize)(this.dsTiming_CompanySettings1)).EndInit();

		}
		#endregion
	}
}
