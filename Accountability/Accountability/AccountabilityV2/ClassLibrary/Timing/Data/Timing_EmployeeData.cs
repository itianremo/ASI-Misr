using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace TSN.ERP.Timing.Data
{
	/// <summary>
	/// Summary description for Timing_EmployeeData.
	/// </summary>
	public class Timing_EmployeeData  :TSN.ERP.Engine.BussinesComponent
	{
		private System.Data.OleDb.OleDbConnection Con;
		private System.Data.OleDb.OleDbDataAdapter daTimingEmployee;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private TSN.ERP.Timing.Data.dsTiming_Employee dsTiming_Employee1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Timing_EmployeeData(System.ComponentModel.IContainer container)
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

		public Timing_EmployeeData()
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
			this.Con = new System.Data.OleDb.OleDbConnection();
			this.daTimingEmployee = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dsTiming_Employee1 = new TSN.ERP.Timing.Data.dsTiming_Employee();
			((System.ComponentModel.ISupportInitialize)(this.dsTiming_Employee1)).BeginInit();
			// 
			// Con
			// 
			this.Con.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=""erp\erpsql2005"";Tag with column collation when possible=False;Initial Catalog=TestAccountability_Data;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=MOAWAD;Use Encryption for Data=False";
			// 
			// daTimingEmployee
			// 
			this.daTimingEmployee.InsertCommand = this.oleDbInsertCommand1;
			this.daTimingEmployee.SelectCommand = this.oleDbSelectCommand1;
			this.daTimingEmployee.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "Timing_Employee", new System.Data.Common.DataColumnMapping[] {
																																																						  new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																						  new System.Data.Common.DataColumnMapping("EmploymentType", "EmploymentType"),
																																																						  new System.Data.Common.DataColumnMapping("TargetTime", "TargetTime"),
																																																						  new System.Data.Common.DataColumnMapping("QT_Balance", "QT_Balance"),
																																																						  new System.Data.Common.DataColumnMapping("WorkPeriod", "WorkPeriod"),
																																																						  new System.Data.Common.DataColumnMapping("StartTime", "StartTime"),
																																																						  new System.Data.Common.DataColumnMapping("EndTime", "EndTime"),
																																																						  new System.Data.Common.DataColumnMapping("TimeRule", "TimeRule"),
																																																						  new System.Data.Common.DataColumnMapping("PC_Name", "PC_Name")})});
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = @"INSERT INTO Timing_Employee(ContactID, EmploymentType, TargetTime, QT_Balance, WorkPeriod, StartTime, EndTime, TimeRule, PC_Name) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?); SELECT ContactID, EmploymentType, TargetTime, QT_Balance, WorkPeriod, StartTime, EndTime, TimeRule, PC_Name FROM Timing_Employee";
			this.oleDbInsertCommand1.Connection = this.Con;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("EmploymentType", System.Data.OleDb.OleDbType.Boolean, 1, "EmploymentType"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TargetTime", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((System.Byte)(18)), ((System.Byte)(2)), "TargetTime", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("QT_Balance", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((System.Byte)(18)), ((System.Byte)(2)), "QT_Balance", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("WorkPeriod", System.Data.OleDb.OleDbType.Integer, 4, "WorkPeriod"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartTime", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "StartTime"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndTime", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "EndTime"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TimeRule", System.Data.OleDb.OleDbType.Integer, 4, "TimeRule"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PC_Name", System.Data.OleDb.OleDbType.VarChar, 50, "PC_Name"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT ContactID, EmploymentType, TargetTime, QT_Balance, WorkPeriod, StartTime, " +
				"EndTime, TimeRule, PC_Name FROM Timing_Employee";
			this.oleDbSelectCommand1.Connection = this.Con;
			// 
			// dsTiming_Employee1
			// 
			this.dsTiming_Employee1.DataSetName = "dsTiming_Employee";
			this.dsTiming_Employee1.EnforceConstraints = false;
			this.dsTiming_Employee1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// Timing_EmployeeData
			// 
			this.ComponentDataAdabter = this.daTimingEmployee;
			this.ComponentDataSet = this.dsTiming_Employee1;
			this.Connection = this.Con;
			((System.ComponentModel.ISupportInitialize)(this.dsTiming_Employee1)).EndInit();

		}
		#endregion
	}
}
