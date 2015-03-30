using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;

namespace TSN.ERP.Timing.Data
{
	/// <summary>
	/// Summary description for Timing_SpecialTimeData.
	/// </summary>
	public class Timing_SpecialTimeData :Engine.BussinesComponent
	{
		private System.Data.OleDb.OleDbConnection Con;
		private System.Data.OleDb.OleDbDataAdapter daTiming_SpecialTime;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbCommand1;
		private System.Data.OleDb.OleDbCommand oleDbCommand2;
		private System.Data.OleDb.OleDbCommand oleDbCommand3;
		private TSN.ERP.Timing.Data.dsTiming_SpecialTime dsTiming_SpecialTime1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Timing_SpecialTimeData(System.ComponentModel.IContainer container)
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

		public Timing_SpecialTimeData()
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
        //////////////////protected override void Dispose( bool disposing )
        //////////////////{
        //////////////////    if( disposing )
        //////////////////    {
        //////////////////        if(components != null)
        //////////////////        {
        //////////////////            components.Dispose();
        //////////////////        }
        //////////////////    }
        //////////////////    base.Dispose( disposing );
        //////////////////}


		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Con = new System.Data.OleDb.OleDbConnection();
			this.daTiming_SpecialTime = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
			this.dsTiming_SpecialTime1 = new TSN.ERP.Timing.Data.dsTiming_SpecialTime();
			((System.ComponentModel.ISupportInitialize)(this.dsTiming_SpecialTime1)).BeginInit();
			// 
			// Con
			// 
			this.Con.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=""erp\erpsql2005"";Tag with column collation when possible=False;Initial Catalog=TestAccountability_Data;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=MOAWAD;Use Encryption for Data=False";
			// 
			// daTiming_SpecialTime
			// 
			this.daTiming_SpecialTime.DeleteCommand = this.oleDbCommand1;
			this.daTiming_SpecialTime.InsertCommand = this.oleDbCommand2;
			this.daTiming_SpecialTime.SelectCommand = this.oleDbSelectCommand1;
			this.daTiming_SpecialTime.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										   new System.Data.Common.DataTableMapping("Table", "Timing_SpecialTime", new System.Data.Common.DataColumnMapping[] {
																																																								 new System.Data.Common.DataColumnMapping("Serial", "Serial"),
																																																								 new System.Data.Common.DataColumnMapping("StartDate", "StartDate"),
																																																								 new System.Data.Common.DataColumnMapping("EndDate", "EndDate"),
																																																								 new System.Data.Common.DataColumnMapping("HourEqual", "HourEqual")})});
			this.daTiming_SpecialTime.UpdateCommand = this.oleDbCommand3;
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT Serial, StartDate, EndDate, HourEqual FROM Timing_SpecialTime";
			this.oleDbSelectCommand1.Connection = this.Con;
			// 
			// oleDbCommand1
			// 
			this.oleDbCommand1.CommandText = "DELETE FROM Timing_SpecialTime WHERE (Serial = ?)";
			this.oleDbCommand1.Connection = this.Con;
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Serial", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Serial", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbCommand2
			// 
			this.oleDbCommand2.CommandText = "INSERT INTO Timing_SpecialTime (Serial, StartDate, EndDate, HourEqual) VALUES (?," +
				" ?, ?, ?)";
			this.oleDbCommand2.Connection = this.Con;
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Serial", System.Data.OleDb.OleDbType.Integer, 4, "Serial"));
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "StartDate"));
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "EndDate"));
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("HourEqual", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(5)), ((System.Byte)(2)), "HourEqual", System.Data.DataRowVersion.Current, null));
			// 
			// oleDbCommand3
			// 
			this.oleDbCommand3.CommandText = "UPDATE Timing_SpecialTime SET StartDate = ?, EndDate = ?, HourEqual = ? WHERE (Se" +
				"rial = ?)";
			this.oleDbCommand3.Connection = this.Con;
			this.oleDbCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "StartDate"));
			this.oleDbCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "EndDate"));
			this.oleDbCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("HourEqual", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(5)), ((System.Byte)(2)), "HourEqual", System.Data.DataRowVersion.Current, null));
			this.oleDbCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Serial", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Serial", System.Data.DataRowVersion.Original, null));
			// 
			// dsTiming_SpecialTime1
			// 
			this.dsTiming_SpecialTime1.DataSetName = "dsTiming_SpecialTime";
			this.dsTiming_SpecialTime1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// Timing_SpecialTimeData
			// 
			this.ComponentDataAdabter = this.daTiming_SpecialTime;
			this.Connection = this.Con;
			((System.ComponentModel.ISupportInitialize)(this.dsTiming_SpecialTime1)).EndInit();

		}
		#endregion
	}
}
