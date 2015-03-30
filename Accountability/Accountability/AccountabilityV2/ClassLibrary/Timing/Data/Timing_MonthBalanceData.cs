using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace TSN.ERP.Timing.Data
{
	/// <summary>
	/// Summary description for Timing_MonthBalanceData.
	/// </summary>
	public class Timing_MonthBalanceData :TSN.ERP.Engine.BussinesComponent
	{
		private System.Data.OleDb.OleDbConnection Con;
		private System.Data.OleDb.OleDbDataAdapter daTiming_MonthBalance;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private TSN.ERP.Timing.Data.dsTiming_MonthBalance dsTiming_MonthBalance1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Timing_MonthBalanceData(System.ComponentModel.IContainer container)
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

		public Timing_MonthBalanceData()
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
			this.Con = new System.Data.OleDb.OleDbConnection();
			this.daTiming_MonthBalance = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dsTiming_MonthBalance1 = new TSN.ERP.Timing.Data.dsTiming_MonthBalance();
			((System.ComponentModel.ISupportInitialize)(this.dsTiming_MonthBalance1)).BeginInit();
			// 
			// Con
			// 
			this.Con.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=""erp\erpsql2005"";Tag with column collation when possible=False;Initial Catalog=TestAccountability_Data;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=MOAWAD;Use Encryption for Data=False";
			// 
			// daTiming_MonthBalance
			// 
			this.daTiming_MonthBalance.InsertCommand = this.oleDbInsertCommand1;
			this.daTiming_MonthBalance.SelectCommand = this.oleDbSelectCommand1;
			this.daTiming_MonthBalance.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											new System.Data.Common.DataTableMapping("Table", "Timing_MonthBalance", new System.Data.Common.DataColumnMapping[] {
																																																								   new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																								   new System.Data.Common.DataColumnMapping("Year", "Year"),
																																																								   new System.Data.Common.DataColumnMapping("Month", "Month"),
																																																								   new System.Data.Common.DataColumnMapping("StartDate", "StartDate"),
																																																								   new System.Data.Common.DataColumnMapping("EndDate", "EndDate"),
																																																								   new System.Data.Common.DataColumnMapping("WorkTime", "WorkTime"),
																																																								   new System.Data.Common.DataColumnMapping("OverTime", "OverTime"),
																																																								   new System.Data.Common.DataColumnMapping("BulkTime", "BulkTime"),
																																																								   new System.Data.Common.DataColumnMapping("QTused", "QTused"),
																																																								   new System.Data.Common.DataColumnMapping("Paid", "Paid"),
																																																								   new System.Data.Common.DataColumnMapping("Plus", "Plus"),
																																																								   new System.Data.Common.DataColumnMapping("Bonus", "Bonus")})});
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = @"INSERT INTO Timing_MonthBalance (Serial, ContactID, Year, Month, StartDate, EndDate, WorkTime, OverTime, BulkTime, QTused, Paid, Plus, Bonus) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?); SELECT Serial, ContactID, Year, Month, StartDate, EndDate, WorkTime, OverTime, BulkTime, QTused, Paid, Plus, Bonus FROM Timing_MonthBalance";
			this.oleDbInsertCommand1.Connection = this.Con;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Serial", System.Data.OleDb.OleDbType.Integer, 4, "Serial"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Year", System.Data.OleDb.OleDbType.Integer, 4, "Year"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Month", System.Data.OleDb.OleDbType.Integer, 4, "Month"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "StartDate"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "EndDate"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WorkTime", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((System.Byte)(18)), ((System.Byte)(2)), "WorkTime", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("OverTime", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((System.Byte)(18)), ((System.Byte)(2)), "OverTime", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("BulkTime", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((System.Byte)(18)), ((System.Byte)(2)), "BulkTime", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("QTused", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((System.Byte)(18)), ((System.Byte)(2)), "QTused", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Paid", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((System.Byte)(18)), ((System.Byte)(2)), "Paid", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Plus", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((System.Byte)(18)), ((System.Byte)(2)), "Plus", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Bonus", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((System.Byte)(18)), ((System.Byte)(2)), "Bonus", System.Data.DataRowVersion.Current, null));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT ContactID, Year, Month, StartDate, EndDate, WorkTime, OverTime, BulkTime, " +
				"QTused, Paid, Plus, Bonus, Serial FROM Timing_MonthBalance";
			this.oleDbSelectCommand1.Connection = this.Con;
			// 
			// dsTiming_MonthBalance1
			// 
			this.dsTiming_MonthBalance1.DataSetName = "dsTiming_MonthBalance";
			this.dsTiming_MonthBalance1.EnforceConstraints = false;
			this.dsTiming_MonthBalance1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// Timing_MonthBalanceData
			// 
			this.ComponentDataAdabter = this.daTiming_MonthBalance;
			this.ComponentDataSet = this.dsTiming_MonthBalance1;
			this.Connection = this.Con;
			((System.ComponentModel.ISupportInitialize)(this.dsTiming_MonthBalance1)).EndInit();

		}
		#endregion
	}
}
