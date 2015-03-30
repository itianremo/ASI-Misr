using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using TSN.ERP.Engine;
using System.Data;
namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for AccountabilityDataClass.
	/// </summary>
	public class AccountabilityDataClass : BussinesComponent 
	{
		private System.Data.OleDb.OleDbDataAdapter odaAccountability;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbConnection con1;
		private TSN.ERP.SharedComponents.Data.dsAccDailyEntries dsAccDailyEntries1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbDataAdapter odaAccSheet;
		private System.Data.OleDb.OleDbCommand odcAccDaily;
		private System.Data.OleDb.OleDbCommand odcProjectEntriesByRespons;
		private System.Data.OleDb.OleDbCommand odcProjectEntires;
		private System.Data.OleDb.OleDbCommand odcResponseEntries;
		private System.Data.OleDb.OleDbCommand odcDayNotes;
		private System.Data.OleDb.OleDbDataAdapter odaAccEntries;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterContactNotesInInterval;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand5;
		private TSN.ERP.SharedComponents.Data.DsTaskSummReport dsTaskSummReport1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterTaskSummary;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AccountabilityDataClass(System.ComponentModel.IContainer container)
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

		public AccountabilityDataClass()
		{
			//this.con1 = BussinesComponent.MainConnection;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountabilityDataClass));
            this.odaAccountability = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.con1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.dsAccDailyEntries1 = new TSN.ERP.SharedComponents.Data.dsAccDailyEntries();
            this.odaAccSheet = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.odcAccDaily = new System.Data.OleDb.OleDbCommand();
            this.odcProjectEntriesByRespons = new System.Data.OleDb.OleDbCommand();
            this.odcProjectEntires = new System.Data.OleDb.OleDbCommand();
            this.odcResponseEntries = new System.Data.OleDb.OleDbCommand();
            this.odcDayNotes = new System.Data.OleDb.OleDbCommand();
            this.odaAccEntries = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbDataAdapterContactNotesInInterval = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
            this.dsTaskSummReport1 = new TSN.ERP.SharedComponents.Data.DsTaskSummReport();
            this.oleDbDataAdapterTaskSummary = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsAccDailyEntries1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTaskSummReport1)).BeginInit();
            // 
            // odaAccountability
            // 
            this.odaAccountability.DeleteCommand = this.oleDbDeleteCommand1;
            this.odaAccountability.InsertCommand = this.oleDbInsertCommand1;
            this.odaAccountability.SelectCommand = this.oleDbSelectCommand1;
            this.odaAccountability.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GEN_AccDailyEntries", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("TransID", "TransID"),
                        new System.Data.Common.DataColumnMapping("NoteID", "NoteID"),
                        new System.Data.Common.DataColumnMapping("AssignmentD", "AssignmentD"),
                        new System.Data.Common.DataColumnMapping("AccountabilityValue", "AccountabilityValue"),
                        new System.Data.Common.DataColumnMapping("AccountabilityDate", "AccountabilityDate")})});
            this.odaAccountability.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM GEN_AccDailyEntries WHERE (TransID = ?) AND (AccountabilityDate = ?) " +
                "AND (AccountabilityValue = ?) AND (AssignmentD = ?) AND (NoteID = ? OR ? IS NULL" +
                " AND NoteID IS NULL)";
            this.oleDbDeleteCommand1.Connection = this.con1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_TransID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TransID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_AccountabilityDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AccountabilityDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_AccountabilityValue", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, false, ((byte)(4)), ((byte)(2)), "AccountabilityValue", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AssignmentD", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_NoteID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NoteID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_NoteID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NoteID", System.Data.DataRowVersion.Original, null)});
            // 
            // con1
            // 
            this.con1.ConnectionString = "Provider=SQLNCLI.1;Data Source=MISSERVER;User ID=RW;Initial Catalog=TestAccountab" +
                "ility_Data";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.con1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("TransID", System.Data.OleDb.OleDbType.Integer, 4, "TransID"),
            new System.Data.OleDb.OleDbParameter("NoteID", System.Data.OleDb.OleDbType.Integer, 4, "NoteID"),
            new System.Data.OleDb.OleDbParameter("AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, "AssignmentD"),
            new System.Data.OleDb.OleDbParameter("AccountabilityValue", System.Data.OleDb.OleDbType.Decimal, 10, System.Data.ParameterDirection.Input, false, ((byte)(8)), ((byte)(2)), "AccountabilityValue", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("AccountabilityDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "AccountabilityDate"),
            new System.Data.OleDb.OleDbParameter("Select_TransID", System.Data.OleDb.OleDbType.Integer, 4, "TransID")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT TransID, NoteID, AssignmentD, AccountabilityValue, AccountabilityDate FROM" +
                " GEN_AccDailyEntries";
            this.oleDbSelectCommand1.Connection = this.con1;
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.con1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("TransID", System.Data.OleDb.OleDbType.Integer, 4, "TransID"),
            new System.Data.OleDb.OleDbParameter("NoteID", System.Data.OleDb.OleDbType.Integer, 4, "NoteID"),
            new System.Data.OleDb.OleDbParameter("AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, "AssignmentD"),
            new System.Data.OleDb.OleDbParameter("AccountabilityValue", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, false, ((byte)(4)), ((byte)(2)), "AccountabilityValue", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("AccountabilityDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "AccountabilityDate"),
            new System.Data.OleDb.OleDbParameter("Original_TransID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TransID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_AccountabilityDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AccountabilityDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_AccountabilityValue", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, false, ((byte)(4)), ((byte)(2)), "AccountabilityValue", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AssignmentD", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_NoteID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NoteID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_NoteID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NoteID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Select_TransID", System.Data.OleDb.OleDbType.Integer, 4, "TransID")});
            // 
            // dsAccDailyEntries1
            // 
            this.dsAccDailyEntries1.DataSetName = "dsAccDailyEntries";
            this.dsAccDailyEntries1.EnforceConstraints = false;
            this.dsAccDailyEntries1.Locale = new System.Globalization.CultureInfo("ar-EG");
            this.dsAccDailyEntries1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // odaAccSheet
            // 
            this.odaAccSheet.SelectCommand = this.oleDbSelectCommand2;
            this.odaAccSheet.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GEN_AccDailyEntries", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("AssignmentD", "AssignmentD"),
                        new System.Data.Common.DataColumnMapping("AccountabilityValue", "AccountabilityValue"),
                        new System.Data.Common.DataColumnMapping("AccountabilityDate", "AccountabilityDate"),
                        new System.Data.Common.DataColumnMapping("ContactID", "ContactID")})});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = resources.GetString("oleDbSelectCommand2.CommandText");
            this.oleDbSelectCommand2.Connection = this.con1;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("AccountabilityDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "AccountabilityDate"),
            new System.Data.OleDb.OleDbParameter("AccountabilityDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "AccountabilityDate"),
            new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID")});
            // 
            // odcAccDaily
            // 
            this.odcAccDaily.CommandText = "SELECT SUM(AccountabilityValue) AS accsum FROM GEN_AccDailyEntries GROUP BY Assig" +
                "nmentD, AccountabilityDate HAVING (AssignmentD = ?) AND (AccountabilityDate = ?)" +
                "";
            this.odcAccDaily.Connection = this.con1;
            this.odcAccDaily.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, "AssignmentD"),
            new System.Data.OleDb.OleDbParameter("AccountabilityDate", System.Data.OleDb.OleDbType.DBDate, 8, "AccountabilityDate")});
            // 
            // odcProjectEntriesByRespons
            // 
            this.odcProjectEntriesByRespons.CommandText = resources.GetString("odcProjectEntriesByRespons.CommandText");
            this.odcProjectEntriesByRespons.Connection = this.con1;
            this.odcProjectEntriesByRespons.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("projectID", System.Data.OleDb.OleDbType.Integer, 4, "projectID"),
            new System.Data.OleDb.OleDbParameter("ResponsID", System.Data.OleDb.OleDbType.Integer, 4, "ResponsID"),
            new System.Data.OleDb.OleDbParameter("AccountabilityDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "AccountabilityDate"),
            new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID")});
            // 
            // odcProjectEntires
            // 
            this.odcProjectEntires.CommandText = resources.GetString("odcProjectEntires.CommandText");
            this.odcProjectEntires.Connection = this.con1;
            this.odcProjectEntires.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("projectID", System.Data.OleDb.OleDbType.Integer, 4, "projectID"),
            new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"),
            new System.Data.OleDb.OleDbParameter("AccountabilityDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "AccountabilityDate")});
            // 
            // odcResponseEntries
            // 
            this.odcResponseEntries.CommandText = resources.GetString("odcResponseEntries.CommandText");
            this.odcResponseEntries.Connection = this.con1;
            this.odcResponseEntries.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"),
            new System.Data.OleDb.OleDbParameter("ResponsID", System.Data.OleDb.OleDbType.Integer, 4, "ResponsID"),
            new System.Data.OleDb.OleDbParameter("AccountabilityDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "AccountabilityDate")});
            // 
            // odcDayNotes
            // 
            this.odcDayNotes.CommandText = resources.GetString("odcDayNotes.CommandText");
            this.odcDayNotes.Connection = this.con1;
            this.odcDayNotes.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("AccountabilityDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "AccountabilityDate"),
            new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID")});
            // 
            // odaAccEntries
            // 
            this.odaAccEntries.SelectCommand = this.oleDbSelectCommand3;
            this.odaAccEntries.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GEN_AccDailyEntries", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("TransID", "TransID"),
                        new System.Data.Common.DataColumnMapping("NoteID", "NoteID"),
                        new System.Data.Common.DataColumnMapping("AssignmentD", "AssignmentD"),
                        new System.Data.Common.DataColumnMapping("AccountabilityValue", "AccountabilityValue"),
                        new System.Data.Common.DataColumnMapping("AccountabilityDate", "AccountabilityDate")})});
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = "SELECT TransID, NoteID, AssignmentD, AccountabilityValue, AccountabilityDate FROM" +
                " GEN_AccDailyEntries WHERE (AssignmentD = ?)";
            this.oleDbSelectCommand3.Connection = this.con1;
            this.oleDbSelectCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("AssignmentD", System.Data.OleDb.OleDbType.Integer, 4, "AssignmentD")});
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = resources.GetString("oleDbConnection1.ConnectionString");
            // 
            // oleDbDataAdapterContactNotesInInterval
            // 
            this.oleDbDataAdapterContactNotesInInterval.SelectCommand = this.oleDbSelectCommand5;
            // 
            // oleDbSelectCommand5
            // 
            this.oleDbSelectCommand5.Connection = this.con1;
            // 
            // dsTaskSummReport1
            // 
            this.dsTaskSummReport1.DataSetName = "DsTaskSummReport";
            this.dsTaskSummReport1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsTaskSummReport1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oleDbDataAdapterTaskSummary
            // 
            this.oleDbDataAdapterTaskSummary.SelectCommand = this.oleDbSelectCommand4;
            this.oleDbDataAdapterTaskSummary.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GEN_Tasks", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("projectID", "projectID"),
                        new System.Data.Common.DataColumnMapping("TaskName", "TaskName"),
                        new System.Data.Common.DataColumnMapping("SumValue", "SumValue"),
                        new System.Data.Common.DataColumnMapping("TaskCloseDate", "TaskCloseDate"),
                        new System.Data.Common.DataColumnMapping("ProjectName", "ProjectName"),
                        new System.Data.Common.DataColumnMapping("Fullname", "Fullname"),
                        new System.Data.Common.DataColumnMapping("JobName", "JobName"),
                        new System.Data.Common.DataColumnMapping("CEName", "CEName"),
                        new System.Data.Common.DataColumnMapping("AssignmentDate", "AssignmentDate")})});
            // 
            // oleDbSelectCommand4
            // 
            this.oleDbSelectCommand4.CommandText = resources.GetString("oleDbSelectCommand4.CommandText");
            this.oleDbSelectCommand4.Connection = this.con1;
            this.oleDbSelectCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 4, "ContactID"),
            new System.Data.OleDb.OleDbParameter("AccountabilityDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "AccountabilityDate"),
            new System.Data.OleDb.OleDbParameter("AccountabilityDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "AccountabilityDate")});
            // 
            // AccountabilityDataClass
            // 
            this.ComponentDataAdabter = this.odaAccountability;
            this.ComponentDataSet = this.dsAccDailyEntries1;
            this.Connection = this.con1;
            ((System.ComponentModel.ISupportInitialize)(this.dsAccDailyEntries1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTaskSummReport1)).EndInit();

		}
		#endregion

		public DataSet LoadAccountabilityData(int employeeId,DateTime dateFrom, DateTime dateTo)
		{
			odaAccSheet.SelectCommand.Parameters[0].Value = dateTo;
			odaAccSheet.SelectCommand.Parameters[1].Value = dateFrom;
			odaAccSheet.SelectCommand.Parameters[2].Value = employeeId;
			dsAccDailyEntries1.Clear();
			odaAccSheet.Fill(dsAccDailyEntries1);
			return dsAccDailyEntries1;
		}
		public double AssginementEntries(int AssginementID, DateTime EntryDate)
		{
			odcAccDaily.Parameters["AssignmentD"].Value = AssginementID;
			odcAccDaily.Parameters["AccountabilityDate"].Value = EntryDate;
			object TempVal = odcAccDaily.ExecuteScalar();
			if (TempVal == null)
				return 0;
			return Convert.ToDouble(TempVal);
		}
		public double ProjectEntries(int ProjectID,DateTime EntryDate,int EmployeeId,int ResponseID)
		{
			odcProjectEntriesByRespons.Parameters["projectID"].Value = ProjectID;
			odcProjectEntriesByRespons.Parameters["AccountabilityDate"].Value = EntryDate;
			odcProjectEntriesByRespons.Parameters["ContactID"].Value = EmployeeId;
			odcProjectEntriesByRespons.Parameters["ResponsID"].Value = ResponseID;
		
			object TempVal = odcProjectEntriesByRespons.ExecuteScalar();
			if (TempVal == null)
				return 0;
			return Convert.ToDouble(TempVal);
		}
		public double ProjectEntries(int ProjectID,DateTime EntryDate,int EmployeeId)
		{
			odcProjectEntires.Parameters["projectID"].Value = ProjectID;
			odcProjectEntires.Parameters["AccountabilityDate"].Value = EntryDate;
			odcProjectEntires.Parameters["ContactID"].Value = EmployeeId;
			object TempVal = odcProjectEntires.ExecuteScalar();
			if (TempVal == null)
				return 0;
			return Convert.ToDouble(TempVal);
		}
		public string GetDaysNote(int ContactID, DateTime NoteDate)
		{
			odcDayNotes.Parameters["AccountabilityDate"].Value = NoteDate;
			odcDayNotes.Parameters["ContactID"].Value = ContactID;
			object tempobject = odcDayNotes.ExecuteScalar();
			if (tempobject != null)
				return tempobject.ToString();
			return null;

		}
		public double ResponseEntries(int ResponsID,DateTime EntryDate,int EmployeeId)
		{
			odcResponseEntries.Parameters["ResponsID"].Value = ResponsID;
			odcResponseEntries.Parameters["AccountabilityDate"].Value = EntryDate;
			odcResponseEntries.Parameters["ContactID"].Value = EmployeeId;
			object TempVal = odcResponseEntries.ExecuteScalar();
			if (TempVal == null)
				return 0;
			return Convert.ToDouble(TempVal);
		}
		public DataSet AccountabilityTotalEntries(int AssID)
		{
			dsAccDailyEntries1.Clear();
			odaAccEntries.SelectCommand.Parameters[0].Value = AssID;
			odaAccEntries.Fill(dsAccDailyEntries1);
			return dsAccDailyEntries1;
		}

		#region GetTaskSummary

		public DataSet GetTaskSummary(int ContactID ,DateTime FromDate , DateTime ToDate )
		{
			
			oleDbDataAdapterTaskSummary.SelectCommand.Parameters[ 0 ].Value = ContactID;
			oleDbDataAdapterTaskSummary.SelectCommand.Parameters[ 1 ].Value = FromDate;
			oleDbDataAdapterTaskSummary.SelectCommand.Parameters[ 2 ].Value = ToDate;
			oleDbDataAdapterTaskSummary.Fill( dsTaskSummReport1 );
			return dsTaskSummReport1;
		}

		#endregion

		#region GetContactAccountabilityNotesInInterval

		public DataSet GetContactAccountabilityNotesInInterval(int ContactID ,DateTime FromDate , DateTime ToDate )
		{
			DataSet ds = new DataSet();

			oleDbDataAdapterContactNotesInInterval.SelectCommand.CommandText = "SELECT  GEN_AccDailyEntries.AccountabilityDate, GEN_Notes.NoteBody "+
																			   " FROM GEN_AccDailyEntries INNER JOIN "+
																			   " GEN_Notes ON GEN_AccDailyEntries.NoteID = GEN_Notes.NoteID INNER JOIN " +
																			   " GEN_ContactNotes ON GEN_Notes.NoteID = GEN_ContactNotes.NoteID "+
																			   " WHERE  (GEN_AccDailyEntries.TransID IN "+
																			   " (SELECT MAX(GEN_AccDailyEntries.TransID) AS EXPR1 "+
																			   " FROM GEN_AccDailyEntries INNER JOIN "+
																			   " GEN_Notes ON GEN_AccDailyEntries.NoteID = GEN_Notes.NoteID INNER JOIN "+
																				" 	GEN_ContactNotes ON GEN_Notes.NoteID = GEN_ContactNotes.NoteID "+
																				" WHERE (GEN_AccDailyEntries.AccountabilityDate BETWEEN '"+ FromDate.ToShortDateString() +"' AND '"+ ToDate.ToShortDateString() +"' ) AND (GEN_ContactNotes.ContactID = "+ ContactID.ToString() + " ) " +
																				" GROUP BY GEN_AccDailyEntries.AccountabilityDate))"+ 
																				" AND ( (GEN_Notes.NoteBody NOT LIKE 'null') AND (GEN_Notes.NoteBody NOT LIKE '')) ";		
			oleDbDataAdapterContactNotesInInterval.Fill( ds );
			return ds;
		}

		#endregion
	}
}
