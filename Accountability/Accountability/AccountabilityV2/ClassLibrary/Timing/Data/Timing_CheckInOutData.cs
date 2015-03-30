using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace TSN.ERP.Timing.Data
{
	/// <summary>
	/// Summary description for Timing_CheckInOutData.
	/// </summary>
	public class Timing_CheckInOutData  :TSN.ERP.Engine.BussinesComponent
	{
		private System.Data.OleDb.OleDbConnection Con;
		private System.Data.OleDb.OleDbDataAdapter daTiming_CheckInOut;
		private TSN.ERP.Timing.Data.dsTiming_CheckInOut dsTiming_CheckInOut1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbCommand1;
		private System.Data.OleDb.OleDbCommand cmdAddCheckInOut;
		private System.Data.OleDb.OleDbCommand cmdUpdateCheckInOut;
		private System.Data.OleDb.OleDbCommand oleDbCommand2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Timing_CheckInOutData(System.ComponentModel.IContainer container)
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

		public Timing_CheckInOutData()
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
			this.daTiming_CheckInOut = new System.Data.OleDb.OleDbDataAdapter();
			this.dsTiming_CheckInOut1 = new TSN.ERP.Timing.Data.dsTiming_CheckInOut();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
			this.cmdAddCheckInOut = new System.Data.OleDb.OleDbCommand();
			this.cmdUpdateCheckInOut = new System.Data.OleDb.OleDbCommand();
			this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsTiming_CheckInOut1)).BeginInit();
			// 
			// Con
			// 
			this.Con.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=""erp\erpsql2005"";Tag with column collation when possible=False;Initial Catalog=TestAccountability_Data;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=MOAWAD;Use Encryption for Data=False";
			// 
			// daTiming_CheckInOut
			// 
			this.daTiming_CheckInOut.InsertCommand = this.oleDbCommand1;
			this.daTiming_CheckInOut.SelectCommand = this.oleDbSelectCommand1;
			this.daTiming_CheckInOut.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										  new System.Data.Common.DataTableMapping("Table", "Timing_CheckInOut", new System.Data.Common.DataColumnMapping[] {
																																																							   new System.Data.Common.DataColumnMapping("Serial", "Serial"),
																																																							   new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																							   new System.Data.Common.DataColumnMapping("Date", "Date"),
																																																							   new System.Data.Common.DataColumnMapping("CheckIn", "CheckIn"),
																																																							   new System.Data.Common.DataColumnMapping("CheckOut", "CheckOut"),
																																																							   new System.Data.Common.DataColumnMapping("BreakTime", "BreakTime"),
																																																							   new System.Data.Common.DataColumnMapping("WorkTime", "WorkTime"),
																																																							   new System.Data.Common.DataColumnMapping("Active", "Active"),
																																																							   new System.Data.Common.DataColumnMapping("TimeRule", "TimeRule")})});
			// 
			// dsTiming_CheckInOut1
			// 
			this.dsTiming_CheckInOut1.DataSetName = "dsTiming_CheckInOut";
			this.dsTiming_CheckInOut1.EnforceConstraints = false;
			this.dsTiming_CheckInOut1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT Serial, ContactID, Date, CheckIn, CheckOut, BreakTime, WorkTime, Active, T" +
				"imeRule FROM Timing_CheckInOut";
			this.oleDbSelectCommand1.Connection = this.Con;
			// 
			// oleDbCommand1
			// 
			this.oleDbCommand1.CommandText = "INSERT INTO Timing_CheckInOut (Serial, ContactID, Date, CheckIn, CheckOut, BreakT" +
				"ime, WorkTime, Active, TimeRule) VALUES (@Serial, @ContactID, @Date, @CheckIn, @" +
				"CheckOut, @BreakTime, @WorkTime, @Active, @TimeRule)";
			this.oleDbCommand1.Connection = this.Con;
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Serial", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((System.Byte)(18)), ((System.Byte)(0)), "Serial", System.Data.DataRowVersion.Current, null));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Date", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "Date"));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CheckIn", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "CheckIn"));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CheckOut", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "CheckOut"));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("BreakTime", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "BreakTime"));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WorkTime", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((System.Byte)(18)), ((System.Byte)(2)), "WorkTime", System.Data.DataRowVersion.Current, null));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Active", System.Data.OleDb.OleDbType.Integer, 4, "Active"));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TimeRule", System.Data.OleDb.OleDbType.Integer, 4, "TimeRule"));
			// 
			// cmdAddCheckInOut
			// 
			this.cmdAddCheckInOut.CommandText = "INSERT INTO Timing_CheckInOut (Serial, ContactID, Date, CheckIn, CheckOut, BreakT" +
				"ime, WorkTime, Active, TimeRule) VALUES (@Serial, @ContactID, @Date, @CheckIn, @" +
				"CheckOut, @BreakTime, @WorkTime, @Active, @TimeRule)";
			this.cmdAddCheckInOut.Connection = this.Con;
			this.cmdAddCheckInOut.Parameters.Add(new System.Data.OleDb.OleDbParameter("Serial", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((System.Byte)(18)), ((System.Byte)(0)), "Serial", System.Data.DataRowVersion.Current, null));
			this.cmdAddCheckInOut.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.cmdAddCheckInOut.Parameters.Add(new System.Data.OleDb.OleDbParameter("Date", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "Date"));
			this.cmdAddCheckInOut.Parameters.Add(new System.Data.OleDb.OleDbParameter("CheckIn", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "CheckIn"));
			this.cmdAddCheckInOut.Parameters.Add(new System.Data.OleDb.OleDbParameter("CheckOut", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "CheckOut"));
			this.cmdAddCheckInOut.Parameters.Add(new System.Data.OleDb.OleDbParameter("BreakTime", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "BreakTime"));
			this.cmdAddCheckInOut.Parameters.Add(new System.Data.OleDb.OleDbParameter("WorkTime", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((System.Byte)(18)), ((System.Byte)(2)), "WorkTime", System.Data.DataRowVersion.Current, null));
			this.cmdAddCheckInOut.Parameters.Add(new System.Data.OleDb.OleDbParameter("Active", System.Data.OleDb.OleDbType.Integer, 4, "Active"));
			this.cmdAddCheckInOut.Parameters.Add(new System.Data.OleDb.OleDbParameter("TimeRule", System.Data.OleDb.OleDbType.Integer, 4, "TimeRule"));
			// 
			// cmdUpdateCheckInOut
			// 
			this.cmdUpdateCheckInOut.CommandText = "UPDATE Timing_CheckInOut SET CheckIn = @CheckIn, CheckOut = @CheckOut, BreakTime " +
				"= @BreakTime, WorkTime = @WorkTime, Active = @Active, TimeRule = @TimeRule WHERE" +
				" Serial = @Serial";
			this.cmdUpdateCheckInOut.Connection = this.Con;
			this.cmdUpdateCheckInOut.Parameters.Add(new System.Data.OleDb.OleDbParameter("CheckIn", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "CheckIn"));
			this.cmdUpdateCheckInOut.Parameters.Add(new System.Data.OleDb.OleDbParameter("CheckOut", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "CheckOut"));
			this.cmdUpdateCheckInOut.Parameters.Add(new System.Data.OleDb.OleDbParameter("BreakTime", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "BreakTime"));
			this.cmdUpdateCheckInOut.Parameters.Add(new System.Data.OleDb.OleDbParameter("WorkTime", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((System.Byte)(18)), ((System.Byte)(2)), "WorkTime", System.Data.DataRowVersion.Current, null));
			this.cmdUpdateCheckInOut.Parameters.Add(new System.Data.OleDb.OleDbParameter("Active", System.Data.OleDb.OleDbType.Integer, 4, "Active"));
			this.cmdUpdateCheckInOut.Parameters.Add(new System.Data.OleDb.OleDbParameter("TimeRule", System.Data.OleDb.OleDbType.Integer, 4, "TimeRule"));
			this.cmdUpdateCheckInOut.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Serial", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((System.Byte)(18)), ((System.Byte)(0)), "Serial", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbCommand2
			// 
			this.oleDbCommand2.CommandText = "DELETE FROM Timing_CheckInOut WHERE Serial = @Serial";
			this.oleDbCommand2.Connection = this.Con;
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Serial", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((System.Byte)(18)), ((System.Byte)(0)), "Serial", System.Data.DataRowVersion.Original, null));
			// 
			// Timing_CheckInOutData
			// 
			this.ComponentDataAdabter = this.daTiming_CheckInOut;
			this.ComponentDataSet = this.dsTiming_CheckInOut1;
			this.Connection = this.Con;
			((System.ComponentModel.ISupportInitialize)(this.dsTiming_CheckInOut1)).EndInit();

		}
		#endregion
	}
}
