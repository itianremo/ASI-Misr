using System;
using System.Data;
using TSN.ERP.Engine;
using System.Globalization;
namespace TSN.ERP.SharedComponents
{
	/// <summary>
	/// Summary description for EmployeeAccountabiltiy.
	/// </summary>
	public class EmployeeAccountabiltiy:BussinesObject 
	{
		public enum View{General=10,Responsbility=20,Project=30,TasksOnly=40,TasksWithTime=50,ActiveTasks=60}
		public enum Sort {Task=10,Responsbility=20}
		public enum AccRecoredType{Task = 10,Respons = 20,Project = 30,DayOff = 40};
		public enum TaskUnit{Hours = 10,Number = 20,NC = 30, DayOff = 40};

		//Data Classes
		private Data.AccountabilityDataClass accData = new TSN.ERP.SharedComponents.Data.AccountabilityDataClass();
		private Data.AssignmentsDataClass AssinmentsData = new TSN.ERP.SharedComponents.Data.AssignmentsDataClass();
		private Data.ProjectsData projectData = new TSN.ERP.SharedComponents.Data.ProjectsData();
		private Data.EmployeeData empData = new TSN.ERP.SharedComponents.Data.EmployeeData();
		private Data.JobtitlesData jobData = new TSN.ERP.SharedComponents.Data.JobtitlesData();
		private Data.ResponsblitiesData responsData = new TSN.ERP.SharedComponents.Data.ResponsblitiesData();
		private Data.CompanyElmentsData compData = new TSN.ERP.SharedComponents.Data.CompanyElmentsData();
		private Data.TransactionsData TransData = new TSN.ERP.SharedComponents.Data.TransactionsData();
		private Data.TasksDataClass TaskData = new TSN.ERP.SharedComponents.Data.TasksDataClass();

		protected CheckSecurity checkSec = new CheckSecurity();
		protected NotesManager AccNotesManager = new NotesManager();

		//Data Sets
		private Data.dsAccountabilitySheet dsAccSheet = new TSN.ERP.SharedComponents.Data.dsAccountabilitySheet();
		private Data.dsAccDailyEntries dsAccDailyEntries = new TSN.ERP.SharedComponents.Data.dsAccDailyEntries();
		private Data.dsProjects dsEmpProjects = new TSN.ERP.SharedComponents.Data.dsProjects();
		private Data.dsResponsblities dsEmpRespons = new TSN.ERP.SharedComponents.Data.dsResponsblities();
		private Data.dsEmployee dsEmp = new TSN.ERP.SharedComponents.Data.dsEmployee();
		private Data.dsAssignments dsEmpAssignments  = new TSN.ERP.SharedComponents.Data.dsAssignments();
		private Data.dsTotalAccSheet dsEmpTotalAccSheet = new TSN.ERP.SharedComponents.Data.dsTotalAccSheet(); 
		
		//BussinessObjects 
		private EmployeesManager EmpManager = new EmployeesManager();
		//

		//View properties
		private View _SheetView = View.General;
		private Sort _SheetSort = Sort.Responsbility;
		private DateTime _SheetDate = DateTime.Now;
		private int _Employee;
		private bool _ShowDaysOff = false;
		private bool _ShowCompletedTasks = false;

		private DateTime weekStart = DateTime.Now;
		
		#region EmployeeAccountabiltiy

		public EmployeeAccountabiltiy()
		{
			DataComponents.Add(accData);
			DataComponents.Add(projectData);
			DataComponents.Add(empData);
			DataComponents.Add(jobData);
			DataComponents.Add(responsData);
			DataComponents.Add(compData);
			DataComponents.Add(AssinmentsData);
			DataComponents.Add(TransData);
			DataComponents.Add(TaskData);
			

			dsAccDailyEntries.EnforceConstraints = false;
			dsAccSheet.EnforceConstraints = false;
			dsEmp.EnforceConstraints = false;
			dsEmpAssignments.EnforceConstraints = false;
			dsEmpProjects.EnforceConstraints = false;
			dsEmpRespons.EnforceConstraints = false;
		}


		#endregion 

		#region LoadEmployeeData

		protected void LoadEmployeeData(int employeeID, DateTime DtAccDate)
		{
			dsEmp.Clear();
			dsEmp.Merge(empData.EmployeeDetailedData(employeeID));
			
			#region -- new added by basant to fill employee data
			// get emp job
			SharedComponents.Data.dsJobtitles dsJob = new TSN.ERP.SharedComponents.Data.dsJobtitles();
			dsJob.Merge( jobData.List( Convert.ToInt32( dsEmp.GEN_Employees[ 0 ][ "JobTitleID" ])) );
			// get emp dep
			SharedComponents.Data.dsCompanyElements dsDept = new TSN.ERP.SharedComponents.Data.dsCompanyElements();
			dsDept.Merge( compData.List( Convert.ToInt32( dsEmp.GEN_Employees[ 0 ][ "CompElmentID" ])) );
			// fill employee name in dsAccSheet.EmployeeData table
			SharedComponents.Data.dsAccountabilitySheet.EmployeeDataRow empDataRow =  dsAccSheet.EmployeeData.NewEmployeeDataRow();
			if( dsEmp.GEN_Employees.Rows.Count != 0 )
			{
				empDataRow.EmployeeName  = dsEmp.GEN_Employees[ 0 ].Fullname;
				empDataRow.EmployeeIndex = dsEmp.GEN_Employees[ 0 ].ContactID;
			}

			if( dsJob.GEN_JobTitles.Rows.Count != 0 )
			{
				empDataRow.JobName       = dsJob.GEN_JobTitles[ 0 ].JobName;
				empDataRow.JobIndex      = dsJob.GEN_JobTitles[ 0 ].JobTitleID;
			}

			if( dsDept.GEN_CompanyElments.Rows.Count != 0 )
			{
				empDataRow.DeptName      = dsDept.GEN_CompanyElments[ 0 ].CEName ; 
				empDataRow.DeptIndex     = dsDept.GEN_CompanyElments[ 0 ].CompElmentID ; 
			}

			dsAccSheet.EmployeeData.AddEmployeeDataRow( empDataRow  );
			/////
			
			#endregion

			dsEmpProjects.Clear();
			dsEmpProjects.Merge(projectData.ProjectsByEmployee(employeeID));
			Data.dsEmployee.GEN_EmployeesRow empRow = dsEmp.GEN_Employees[0];
			dsEmpRespons.Clear();
			dsEmpRespons.Merge(responsData.ListResponsebyJob(empRow.JobTitleID));
			for(int i = 0; i < dsEmpRespons.Tables[0].Rows.Count; i++)
			{
				Data.dsResponsblities.GEN_ResponsibilitiesRow Row = (Data.dsResponsblities.GEN_ResponsibilitiesRow)dsEmpRespons.GEN_Responsibilities.Rows[i];
				if(!Row.IsActive)
				{
					try
					{
						DateTime dt = TaskData.GetRespTasksMaxCloseDate(Row.ResponsID);
						int weekDateCount = -(int)DtAccDate.DayOfWeek;
						DateTime localweekStart = DtAccDate.AddDays(weekDateCount);
						DateTime localweekEnd = localweekStart.AddDays(6);
//						if( !(dt >= localweekStart && dt <=localweekEnd))
						if((localweekStart > dt))
						{
							dsEmpRespons.GEN_Responsibilities.Rows[i].Delete();
						}
					}
					catch
					{
					}
				}
			}
			dsEmpRespons.AcceptChanges();
		}

		#endregion 

		#region LoadTotalData

		protected void LoadTotalData()
		{
			DataView dvAcc = new DataView();
			dvAcc.Table = dsAccSheet.EmpAccSheet;
			dvAcc.RowFilter = "(unit = 10 or unit = 40) and (RecoredType = 10 or RecoredType = 40)";
			int rowCount = dvAcc.Count;
			Data.dsAccountabilitySheet.WeekDataRow WeekRow = dsAccSheet.WeekData.NewWeekDataRow();

			WeekRow.SunDate = weekStart;
			WeekRow.MonDate = weekStart.AddDays(1);
			WeekRow.TueDate = weekStart.AddDays(2);
			WeekRow.WedDate  = weekStart.AddDays(3);
			WeekRow.ThurDate = weekStart.AddDays(4);
			WeekRow.FriDate = weekStart.AddDays(5);
			WeekRow.SatDate = weekStart.AddDays(6);
			
			WeekRow.SunTotal = 0;
			WeekRow.MonTotal = 0;
			WeekRow.TuesTotal = 0;
			WeekRow.WedTotal= 0;
			WeekRow.ThurTotal= 0;
			WeekRow.FriTotal = 0;
			WeekRow.SatTotal = 0;

			
			for (int i=0;i<7;i++)
			{
				DateTime TempDate = weekStart.AddDays(i);
				string notebody = accData.GetDaysNote(Employee,TempDate);
				Data.dsAccountabilitySheet.WeekNotesRow NoteRow = dsAccSheet.WeekNotes.NewWeekNotesRow();
				NoteRow.HasDaysOff = false;
				NoteRow.NoteDate = TempDate;
				if (notebody != null)
					NoteRow.NoteBody = notebody;
				dsAccSheet.WeekNotes.AddWeekNotesRow(NoteRow);
				
			}
			for (int i =0;i<rowCount;i++)
			{
				Data.dsAccountabilitySheet.EmpAccSheetRow  accRow = (Data.dsAccountabilitySheet.EmpAccSheetRow) dvAcc[i].Row;

				
				
				WeekRow.SunTotal = WeekRow.SunTotal + accRow.sun;
				if (accRow.unit == 40 && accRow.sun > 0)dsAccSheet.WeekNotes[0].HasDaysOff = true;
				WeekRow.MonTotal = WeekRow.MonTotal + accRow.mon;
				if (accRow.unit == 40 && accRow.mon > 0)dsAccSheet.WeekNotes[1].HasDaysOff = true;
				WeekRow.TuesTotal = WeekRow.TuesTotal + accRow.tue;
				if (accRow.unit == 40 && accRow.tue > 0)dsAccSheet.WeekNotes[2].HasDaysOff = true;
				WeekRow.WedTotal = WeekRow.WedTotal + accRow.wen;
				if (accRow.unit == 40 && accRow.wen > 0)dsAccSheet.WeekNotes[3].HasDaysOff = true;
				WeekRow.ThurTotal = WeekRow.ThurTotal + accRow.thr;
				if (accRow.unit == 40 && accRow.thr > 0)dsAccSheet.WeekNotes[4].HasDaysOff = true;
				WeekRow.FriTotal = WeekRow.FriTotal + accRow.fri;
				if (accRow.unit == 40 && accRow.fri > 0)dsAccSheet.WeekNotes[5].HasDaysOff = true;
				WeekRow.SatTotal = WeekRow.SatTotal + accRow.sat;
				if (accRow.unit == 40 && accRow.sat > 0)dsAccSheet.WeekNotes[6].HasDaysOff = true;
			}
			
			WeekRow.WeekTotal = WeekRow.SunTotal+WeekRow.MonTotal+WeekRow.TuesTotal+WeekRow.WedTotal+WeekRow.ThurTotal+WeekRow.FriTotal+WeekRow.SatTotal;
			WeekRow.Year = weekStart.Year;
			WeekRow.Month = weekStart.Month;
			dsAccSheet.WeekData.AddWeekDataRow(WeekRow);
			// Loading notes 

		}


		#endregion 

		#region Refresh
		/// <summary>
		/// Geting accountability sheet for spacific employee at spcific time in any mood(i.e.task mode) with showing day off as you want.
		/// </summary>
		/// <param name="EmpID">int:Employee ID which wanted to show his accountabiltiy sheet</param>
		/// <param name="AccSheetDate">Date Time:The date which wanted to show accountabiltiy sheet</param>
		/// <param name="viewType">enum View:To select the mode of showing</param>
		/// <param name="DaysOff">bool:To select if wanted to show day off of this employee or not</param>
		/// <returns>DataSet:Containing the data of this sheet</returns>
		[AtrERPMethodType(ERPMethodType.List)]
		public DataSet GetAccSheet(int EmpID, DateTime AccSheetDate,View viewType,bool DaysOff)
		{
			//
			if (!checkSec.HasLoadAccountabiltiyAccess(EmpID))
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.LoadAccountabilityEmployees );
				return null;
			}
			Employee = EmpID;
			SheetDate = AccSheetDate;
			SheetView = viewType;
			ShowDaysOff = DaysOff;
			dsAccSheet.Clear();
			LoadAccountabiltiy(Employee,SheetDate);
			ApplySheetFilter(dsAccSheet);
			dsAccSheet.AcceptChanges();
			return dsAccSheet;
		}


		#endregion 

		#region LoadAccountabiltiy

		protected void LoadAccountabiltiy(int employeeID,DateTime accountabilityDate)
		{
			
			LoadEmployeeData(employeeID, accountabilityDate);
			//Loading the Accountability Data for the requested week
			int weekDatCount = -(int)accountabilityDate.DayOfWeek;
			weekStart = accountabilityDate.AddDays(weekDatCount);
			DateTime weekEnd = weekStart.AddDays(6);
			switch((int)SheetView)
			{
				case (int)View.General:
					LoadGeneral(employeeID,weekStart,weekEnd);
					break;
				case (int)View.Project:
					LoadProjects(employeeID,weekStart,weekEnd);
					break;
			}
			_Employee = employeeID;
			LoadTotalData();
		}


		#endregion 

		#region GetAssigmentsWithNoResponse

		/// <summary>
		/// Get assigments with no responsibility.
		/// </summary>
		/// <param name="EmployeeID">int:Employee ID which wanted to get his or her assigments</param>
		/// <param name="dsReponseData">DataSet:Containing data of responsibility</param>
		/// <returns>DataSet:Containing data of this assigments</returns>
		public DataSet GetAssigmentsWithNoResponse(int EmployeeID,DataSet dsReponseData)
		{
			Data.dsResponsblities dstemp = new TSN.ERP.SharedComponents.Data.dsResponsblities();
			dstemp.Merge(dsReponseData);
			int rowCount = dstemp.GEN_Responsibilities.Count;
			DataSet ds = new DataSet();
			//if (ShowDaysOff)
			ds.Merge(AssinmentsData.List( "(ResponsID IS NULL) and (ContactID = " + EmployeeID.ToString() + " )"));
			if(rowCount > 0)
			{
				string FilterString = "( ";
				for(int i=0;i<rowCount;i++)
				{
					if (i==0)
					{
						FilterString =  FilterString + "ResponsID <> " + dstemp.GEN_Responsibilities[i].ResponsID;
					}
					else
					{
						FilterString = FilterString + " AND ResponsID <> "+dstemp.GEN_Responsibilities[i].ResponsID;
					}
				}
				FilterString = FilterString + ") AND ContactID = " + EmployeeID.ToString();
				ds.Merge( AssinmentsData.List(FilterString));
				return ds;
			}
			
			return AssinmentsData.List("ContactID = " + EmployeeID.ToString());
		}


		#endregion 

		#region View Projects
		protected void LoadProjects(int employeeID, DateTime weekStart,DateTime weekEnd )
		{
			dsEmpProjects.Clear();
			dsEmpProjects.Merge(projectData.ProjectsByEmployee(employeeID));
			int ProjCount = dsEmpProjects.GEN_Projects.Count;
			dsEmpAssignments.Clear();
			//dsEmpAssignments.Merge(AssinmentsData.ViewEmpAssignentsWithNoProject(employeeID));
			//InsertAssginments(dsAccSheet,dsEmpAssignments,weekStart,weekEnd,0,"");
			for(int i=0;i<ProjCount;i++)
			{
				Data.dsAccountabilitySheet.EmpAccSheetRow projectRow = InsertProject(dsAccSheet,dsEmpProjects.GEN_Projects[i],-1,weekStart,employeeID);
				dsEmpAssignments.Clear();
				dsEmpAssignments.Merge(AssinmentsData.ViewEmpAssignentsByProject(employeeID,dsEmpProjects.GEN_Projects[i].projectID));
				InsertAssginmentsProjectViewMode(dsAccSheet,dsEmpAssignments,weekStart,weekEnd,dsEmpProjects.GEN_Projects[i].projectID,dsEmpProjects.GEN_Projects[i].ProjectName);
			}
		}
		#region Insert Assginments for Project view mode
		protected int InsertAssginmentsProjectViewMode(Data.dsAccountabilitySheet AccDataSet, Data.dsAssignments AssDataSet, DateTime dateStart,DateTime dateEnd, int ProjectID,string ProjectName)
		{
			ApplyAssginmetnsFilter(AssDataSet,dateStart);
			DataView dvAssignments = new DataView();
			dvAssignments.Table = AssDataSet.GEN_Assignments;
			int accCount = dvAssignments.Count;
			for (int i =0; i < accCount;i++)
			{
				Data.dsAssignments.GEN_AssignmentsRow AssRow = (Data.dsAssignments.GEN_AssignmentsRow) dvAssignments[i].Row;
				Data.dsAccountabilitySheet.EmpAccSheetRow EmpAccSheetRow = dsAccSheet.EmpAccSheet.NewEmpAccSheetRow();
				EmpAccSheetRow.StrongID = AssRow.AssignmentD;
				EmpAccSheetRow.taskname = AssinmentsData.GetAssginemtTaskName(AssRow.AssignmentD);
				EmpAccSheetRow.RecoredType = (int) AccRecoredType.Task;
				EmpAccSheetRow.unit = TaskData.TaskUnit(AssRow.TaskID);
				EmpAccSheetRow.AssStatus = AssRow.AssignmentStatus;
				if (!AssRow.IsAssignmentPriorityNull())
					EmpAccSheetRow.Taskpriority = AssRow.AssignmentPriority;
				if (!AssRow.IsResponsIDNull())
					EmpAccSheetRow.ParentResponsID = AssRow.ResponsID;
				//EmpAccSheetRow.descReponse = ReponseName;
				EmpAccSheetRow.descReponse = responsData.ListResponsibility(AssRow.ResponsID).Tables[0].Rows[0]["ResponsName"].ToString();
				EmpAccSheetRow.descProject = ProjectName;
				if (ProjectID > 0)
				{
					EmpAccSheetRow.taskname = "*" + EmpAccSheetRow.taskname;
					EmpAccSheetRow.ParentProjectID = ProjectID;
				}

				// Week Data 
				EmpAccSheetRow.sun = accData.AssginementEntries(AssRow.AssignmentD,dateStart);
				EmpAccSheetRow.mon =accData.AssginementEntries(AssRow.AssignmentD,dateStart.AddDays(1));
				EmpAccSheetRow.tue =accData.AssginementEntries(AssRow.AssignmentD,dateStart.AddDays(2));
				EmpAccSheetRow.wen =accData.AssginementEntries(AssRow.AssignmentD,dateStart.AddDays(3));
				EmpAccSheetRow.thr = accData.AssginementEntries(AssRow.AssignmentD,dateStart.AddDays(4));
				EmpAccSheetRow.fri =accData.AssginementEntries(AssRow.AssignmentD,dateStart.AddDays(5));
				EmpAccSheetRow.sat =accData.AssginementEntries(AssRow.AssignmentD,dateStart.AddDays(6));
				EmpAccSheetRow.week =EmpAccSheetRow.sun+EmpAccSheetRow.mon+EmpAccSheetRow.tue+EmpAccSheetRow.wen+EmpAccSheetRow.thr+EmpAccSheetRow.fri+EmpAccSheetRow.sat;

				EmpAccSheetRow.descNote = TaskData.GetTaskNote(AssRow.TaskID);
				AccDataSet.EmpAccSheet.AddEmpAccSheetRow(EmpAccSheetRow);
			}
			return accCount;
		}
		
		#endregion
		#endregion

		#region View General
		protected void LoadGeneral(int employeeID, DateTime weekStart,DateTime weekEnd )
		{
			int responsCount = dsEmpRespons.GEN_Responsibilities.Count;
			dsEmpAssignments.Clear();
			dsEmpAssignments.Merge(GetAssigmentsWithNoResponse(employeeID,dsEmpRespons));
			InsertAssginments(dsAccSheet,dsEmpAssignments,weekStart,weekEnd,-1,"",0,"");

			for (int i =0; i< responsCount;i++)
			{
				//Inserting the responsbility Record
				Data.dsResponsblities.GEN_ResponsibilitiesRow ResponsRow = dsEmpRespons.GEN_Responsibilities[i];
				Data.dsAccountabilitySheet.EmpAccSheetRow EmpAccSheeRow = dsAccSheet.EmpAccSheet.NewEmpAccSheetRow();
				EmpAccSheeRow.StrongID = ResponsRow.ResponsID;
				EmpAccSheeRow.taskname = ResponsRow.ResponsName;
				EmpAccSheeRow.ResponsPrioity = ResponsRow.ResponsOrder;
				EmpAccSheeRow.RecoredType = (int)AccRecoredType.Respons;

				EmpAccSheeRow.sun = accData.ResponseEntries(ResponsRow.ResponsID,weekStart,employeeID);
				EmpAccSheeRow.mon = accData.ResponseEntries(ResponsRow.ResponsID,weekStart.AddDays(1),employeeID);
				EmpAccSheeRow.tue = accData.ResponseEntries(ResponsRow.ResponsID,weekStart.AddDays(2),employeeID);
				EmpAccSheeRow.wen = accData.ResponseEntries(ResponsRow.ResponsID,weekStart.AddDays(3),employeeID);
				EmpAccSheeRow.thr = accData.ResponseEntries(ResponsRow.ResponsID,weekStart.AddDays(4),employeeID);
				EmpAccSheeRow.fri = accData.ResponseEntries(ResponsRow.ResponsID,weekStart.AddDays(5),employeeID);
				EmpAccSheeRow.sat = accData.ResponseEntries(ResponsRow.ResponsID,weekStart.AddDays(6),employeeID);

				
				dsAccSheet.EmpAccSheet.AddEmpAccSheetRow(EmpAccSheeRow);
				dsEmpAssignments.Clear();
				dsEmpAssignments.Merge(AssinmentsData.ViewEmpAssignentsInResponsibilityWithNoProject(employeeID, ResponsRow.ResponsID));
				InsertAssginments(dsAccSheet,dsEmpAssignments,weekStart,weekEnd,ResponsRow.ResponsID,ResponsRow.ResponsName);
				dsEmpProjects.Clear();
				dsEmpProjects.Merge(projectData.ProjectByEmpRespons(employeeID,ResponsRow.ResponsID));
				int ProjCount = dsEmpProjects.GEN_Projects.Count;
				for (int j =0; j <ProjCount;j++ )
				{
					Data.dsAccountabilitySheet.EmpAccSheetRow projectRow = InsertProject(dsAccSheet,dsEmpProjects.GEN_Projects[j],ResponsRow.ResponsID,weekStart,employeeID);
					dsEmpAssignments.Clear();
					dsEmpAssignments.Merge(AssinmentsData.ViewEmpAssignentsInProjectResponsibility(employeeID,ResponsRow.ResponsID,dsEmpProjects.GEN_Projects[j].projectID));
					int taskCount = InsertAssginments(dsAccSheet,dsEmpAssignments,weekStart,weekEnd,ResponsRow.ResponsID,ResponsRow.ResponsName,dsEmpProjects.GEN_Projects[j].projectID,dsEmpProjects.GEN_Projects[j].ProjectName);
					if (taskCount <= 0)
						projectRow.Delete();
				}
			}
		}
		protected Data.dsAccountabilitySheet.EmpAccSheetRow InsertProject(Data.dsAccountabilitySheet AccDataSet,Data.dsProjects.GEN_ProjectsRow projectRow ,int ResponseID,DateTime startDate,int empID)
		{
			Data.dsAccountabilitySheet.EmpAccSheetRow AccRow = AccDataSet.EmpAccSheet.NewEmpAccSheetRow();
			AccRow.StrongID = projectRow.projectID;
			AccRow.taskname = projectRow.ProjectName;
			if (ResponseID > 0)
			{
				AccRow.sun = accData.ProjectEntries(projectRow.projectID,startDate,empID,ResponseID);
				AccRow.mon = accData.ProjectEntries(projectRow.projectID,startDate.AddDays(1),empID,ResponseID);
				AccRow.tue = accData.ProjectEntries(projectRow.projectID,startDate.AddDays(2),empID,ResponseID);
				AccRow.wen = accData.ProjectEntries(projectRow.projectID,startDate.AddDays(3),empID,ResponseID);
				AccRow.thr = accData.ProjectEntries(projectRow.projectID,startDate.AddDays(4),empID,ResponseID);
				AccRow.fri = accData.ProjectEntries(projectRow.projectID,startDate.AddDays(5),empID,ResponseID);
				AccRow.sat = accData.ProjectEntries(projectRow.projectID,startDate.AddDays(6),empID,ResponseID);
			}
			else
			{
				AccRow.sun = accData.ProjectEntries(projectRow.projectID,startDate,empID);
				AccRow.mon = accData.ProjectEntries(projectRow.projectID,startDate.AddDays(1),empID);
				AccRow.tue = accData.ProjectEntries(projectRow.projectID,startDate.AddDays(2),empID);
				AccRow.wen = accData.ProjectEntries(projectRow.projectID,startDate.AddDays(3),empID);
				AccRow.thr = accData.ProjectEntries(projectRow.projectID,startDate.AddDays(4),empID);
				AccRow.fri = accData.ProjectEntries(projectRow.projectID,startDate.AddDays(5),empID);
				AccRow.sat = accData.ProjectEntries(projectRow.projectID,startDate.AddDays(6),empID);
			}
			AccRow.RecoredType = (int) AccRecoredType.Project;
			AccDataSet.EmpAccSheet.AddEmpAccSheetRow(AccRow);
			return AccRow;
		}
		#endregion

		#region Insert Assginments
		protected int InsertAssginments(Data.dsAccountabilitySheet AccDataSet, Data.dsAssignments AssDataSet, DateTime dateStart,DateTime dateEnd, int ResponsID,string ReponseName,int ProjectID,string ProjectName)
		{
			ApplyAssginmetnsFilter(AssDataSet,dateStart);
			DataView dvAssignments = new DataView();
			dvAssignments.Table = dsEmpAssignments.GEN_Assignments;
			int accCount = dvAssignments.Count;
			for (int i =0; i < accCount;i++)
			{
				Data.dsAssignments.GEN_AssignmentsRow AssRow = (Data.dsAssignments.GEN_AssignmentsRow) dvAssignments[i].Row;
				Data.dsAccountabilitySheet.EmpAccSheetRow EmpAccSheetRow = dsAccSheet.EmpAccSheet.NewEmpAccSheetRow();
				EmpAccSheetRow.StrongID = AssRow.AssignmentD;
				EmpAccSheetRow.taskname = AssinmentsData.GetAssginemtTaskName(AssRow.AssignmentD);
				EmpAccSheetRow.RecoredType = (int) AccRecoredType.Task;
				EmpAccSheetRow.unit = TaskData.TaskUnit(AssRow.TaskID);
				EmpAccSheetRow.AssStatus = AssRow.AssignmentStatus;
				if (!AssRow.IsAssignmentPriorityNull())
					EmpAccSheetRow.Taskpriority = AssRow.AssignmentPriority;
				if (!AssRow.IsResponsIDNull())
					EmpAccSheetRow.ParentResponsID = AssRow.ResponsID;
				EmpAccSheetRow.descReponse = ReponseName;
				EmpAccSheetRow.descProject = ProjectName;
				if (ProjectID > 0)
				{
					EmpAccSheetRow.taskname = "*" + EmpAccSheetRow.taskname;
					EmpAccSheetRow.ParentProjectID = ProjectID;
				}

				// Week Data 
				EmpAccSheetRow.sun = accData.AssginementEntries(AssRow.AssignmentD,dateStart);
				EmpAccSheetRow.mon =accData.AssginementEntries(AssRow.AssignmentD,dateStart.AddDays(1));
				EmpAccSheetRow.tue =accData.AssginementEntries(AssRow.AssignmentD,dateStart.AddDays(2));
				EmpAccSheetRow.wen =accData.AssginementEntries(AssRow.AssignmentD,dateStart.AddDays(3));
				EmpAccSheetRow.thr = accData.AssginementEntries(AssRow.AssignmentD,dateStart.AddDays(4));
				EmpAccSheetRow.fri =accData.AssginementEntries(AssRow.AssignmentD,dateStart.AddDays(5));
				EmpAccSheetRow.sat =accData.AssginementEntries(AssRow.AssignmentD,dateStart.AddDays(6));
				EmpAccSheetRow.week =EmpAccSheetRow.sun+EmpAccSheetRow.mon+EmpAccSheetRow.tue+EmpAccSheetRow.wen+EmpAccSheetRow.thr+EmpAccSheetRow.fri+EmpAccSheetRow.sat;

				EmpAccSheetRow.descNote = TaskData.GetTaskNote(AssRow.TaskID);
				AccDataSet.EmpAccSheet.AddEmpAccSheetRow(EmpAccSheetRow);
			}
			return accCount;
		}
		protected int InsertAssginments(Data.dsAccountabilitySheet AccDataSet, Data.dsAssignments AssDataSet, DateTime dateStart,DateTime dateEnd,int ResponsID,string ResponseName)
		{
			return InsertAssginments(AccDataSet,AssDataSet,dateStart,dateEnd,ResponsID,ResponseName,-1,"");
		}
		
		#endregion

		private void ApplySheetFilter(Data.dsAccountabilitySheet tempAccSheet)
		{
			if (!ShowDaysOff)
			{
				int rowCount = tempAccSheet.EmpAccSheet.Rows.Count;
				for(int i = rowCount - 1;i >= 0; i--)
				{
					Data.dsAccountabilitySheet.EmpAccSheetRow TempRow = tempAccSheet.EmpAccSheet[i];
					if (TempRow.IsunitNull())
						continue;
					if (tempAccSheet.EmpAccSheet[i].unit == (int)TaskUnit.DayOff )
					{
						tempAccSheet.EmpAccSheet.Rows.RemoveAt(i);
					}
				}
			}
			if(SheetView == View.TasksOnly )
			{
				int rowCount = tempAccSheet.EmpAccSheet.Rows.Count;
				for(int i = rowCount - 1;i >= 0; i--)
				{
					Data.dsAccountabilitySheet.EmpAccSheetRow TempRow = tempAccSheet.EmpAccSheet[i];
					if (TempRow.IsRecoredTypeNull())
						continue;
					if ((AccRecoredType)tempAccSheet.EmpAccSheet[i].RecoredType == AccRecoredType.Project || (AccRecoredType)tempAccSheet.EmpAccSheet[i].RecoredType == AccRecoredType.Respons)
					{
						tempAccSheet.EmpAccSheet.Rows.RemoveAt(i);
					}
				}
			}
		}
		private bool CompareDates(DateTime FirstDate, DateTime SeconedDate )
		{
			if(FirstDate.Year > SeconedDate.Year)
				return true;
			if(SeconedDate.Year > FirstDate.Year)
				return false;
			if(FirstDate.Month > SeconedDate.Month)
				return true;
			if(SeconedDate.Month > FirstDate.Month)
				return false;
			if(FirstDate.Day > SeconedDate.Day)
				return true;
			if(SeconedDate.Day > FirstDate.Day)
				return false;
			return false;

		}

		// Applies the assgiments status filter , removes the assginmetns that either wsnot started by the current date, 
		//or assginemtns that was completed  before this week 
		private void ApplyAssginmetnsFilter(Data.dsAssignments tempAssDataSet,DateTime Accdate)
		{
			int weekDateCount = -(int)Accdate.DayOfWeek;
			DateTime localweekStart = Accdate.AddDays(weekDateCount);
			DateTime localweekEnd = localweekStart.AddDays(6);
			if (!ShowCompletedTasks) 
			{
				int rowCount = tempAssDataSet.GEN_Assignments.Rows.Count;

				for(int i = rowCount - 1;i >= 0; i--)
				{
					DateTime dttemp = tempAssDataSet.GEN_Assignments[i].AssignmentDate;
					//Added by Hamdy Ahmed on 19/03/2008 to display tasks from TaskStartDate not from Creation Date(Assignment Date)
					DataRow drTask = TaskData.List(tempAssDataSet.GEN_Assignments[i].TaskID).Tables[0].Rows[0];
					if(drTask["TaskStartDate"] != DBNull.Value)
					{
						dttemp = Convert.ToDateTime(drTask["TaskStartDate"]);
					}
					///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
					if (!CompareDates(localweekEnd,dttemp))
					{
						tempAssDataSet.GEN_Assignments.Rows.RemoveAt(i);
						continue;
					}
					if ((tempAssDataSet.GEN_Assignments[i].AssignmentStatus  >= 3))
					{
						DateTime CompleteDate =  AssinmentsData.GetAssginmentCompleteDate(tempAssDataSet.GEN_Assignments[i].AssignmentD);
						if ( CompareDates(localweekStart,CompleteDate))
						{
							tempAssDataSet.GEN_Assignments.Rows.RemoveAt(i);
							continue;
						}
					}
				}
			}
		}
		#region Update Accountability
		/// <summary>
		/// Update the accountability sheet for spacific employee at the spacific time.
		/// </summary>
		/// <param name="dsNewAccountability">DataSet:Containing a new data of accountability sheet</param>
		/// <param name="EmployeeID">int:Employee ID which wanted to update his acc sheet</param>
		/// <param name="SheetDate">DateTime:Sheet date</param>
		/// <returns>bool:Returns true if success and false if not</returns>
		public bool Update(DataSet dsNewAccountability,int EmployeeID,DateTime SheetDate)
		{
			if (  ! checkSec.HasUpdateAccountabiltiyAccess( EmployeeID ) )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.UpdateAccountability );
				return  false;
			}
			// Check if the save date is after the upperr boundary of the current week, if true return and don't save sheet
			int nowWeekDateCount = -(int)DateTime.Now.DayOfWeek;
			DateTime nowWeekStart = DateTime.Now.AddDays(nowWeekDateCount);
			DateTime nowWeekEnd=nowWeekStart.AddDays(6);
			if(SheetDate > nowWeekEnd)
			{
				return false;
			}
			/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

			int weekDatCount = -(int)SheetDate.DayOfWeek;
			weekStart = SheetDate.AddDays(weekDatCount);
			DateTime weekEnd = weekStart.AddDays(6);
			Data.dsAccountabilitySheet TempAccSheet = new TSN.ERP.SharedComponents.Data.dsAccountabilitySheet();
			TempAccSheet.EnforceConstraints = false;
			TempAccSheet.Merge(dsNewAccountability);
			DataView dvAcc = new DataView();
			dvAcc.Table = TempAccSheet.EmpAccSheet;

			// filter just tasks rows
			dvAcc.RowFilter = "RecoredType = 10";
			int recCount = dvAcc.Count;
			for (int i = 0 ;i<recCount;i++)
			{
				Data.dsAccountabilitySheet.EmpAccSheetRow AccRow = (Data.dsAccountabilitySheet.EmpAccSheetRow ) dvAcc[i].Row;
				if(!SetAccountabilityValue((int)AccRow.StrongID,AccRow.sun,weekStart.Date))return false;
				if(!SetAccountabilityValue((int)AccRow.StrongID,AccRow.mon,weekStart.AddDays(1).Date))return false;
				if(!SetAccountabilityValue((int)AccRow.StrongID,AccRow.tue,weekStart.AddDays(2).Date))return false;
				if(!SetAccountabilityValue((int)AccRow.StrongID,AccRow.wen,weekStart.AddDays(3).Date))return false;
				if(!SetAccountabilityValue((int)AccRow.StrongID,AccRow.thr,weekStart.AddDays(4).Date))return false;
				if(!SetAccountabilityValue((int)AccRow.StrongID,AccRow.fri,weekStart.AddDays(5).Date))return false;
				if(!SetAccountabilityValue((int)AccRow.StrongID,AccRow.sat,weekStart.AddDays(6).Date))return false;
			}

			int noteCount = TempAccSheet.WeekNotes.Rows.Count;
			for (int i=0;i < noteCount;i++)
			{
				Data.dsAccountabilitySheet.WeekNotesRow NoteRow = TempAccSheet.WeekNotes[i];
				if (NoteRow.RowState == DataRowState.Modified) 
					if (!SaveNote(NoteRow.NoteDate,NoteRow.NoteBody,EmployeeID))return false;
			}
			return true;
		}
		/// <summary>
		/// Set accountability value under spacific assginment and with work hours
		/// </summary>
		/// <param name="AssginmentID">int:Assginment ID</param>
		/// <param name="AccValue">double:Accountability value</param>
		/// <param name="AccDate">DateTime:Work date</param>
		/// <returns>bool:Returns true if success and false if not</returns>
		public bool SetAccountabilityValue(int AssginmentID,double AccValue, DateTime AccDate)
		{
			dsAccDailyEntries.Clear();
			Data.dsAccDailyEntries.GEN_AccDailyEntriesRow AccRow = dsAccDailyEntries.GEN_AccDailyEntries.NewGEN_AccDailyEntriesRow();
			double oldval = accData.AssginementEntries(AssginmentID,AccDate);
			if (oldval ==AccValue)
				return true;
			int TransID = TransData.CreateTransaction(ActiveSession.UserId);
			AccRow.TransID = TransID;
			AccRow.AssignmentD = AssginmentID;
			AccRow.AccountabilityDate = AccDate.Date;
			AccRow.AccountabilityValue = Convert.ToDecimal( AccValue ) - Convert.ToDecimal( oldval );

////////////////////			////////////////////////////////////////////////////////////////////////
////////////////////			#region Added by Hamdy Ahmed on 17/03/2008 to solve the problem that Dr. Amr has opened
////////////////////			if(AccRow.AccountabilityValue >=100 || AccRow.AccountabilityValue <= -100)
////////////////////			{
////////////////////				decimal OriginalValue = AccRow.AccountabilityValue;
////////////////////				int times = 0;
////////////////////				if((AccRow.AccountabilityValue % 99) != 0)
////////////////////				{
////////////////////					if(AccRow.AccountabilityValue > 0)
////////////////////					{
////////////////////						times = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(AccRow.AccountabilityValue) / 99));
////////////////////					}
////////////////////					else
////////////////////					{
////////////////////						times = Convert.ToInt32(Math.Floor(Convert.ToDouble(AccRow.AccountabilityValue) / 99));
////////////////////					}
////////////////////				}
////////////////////				else
////////////////////				{
////////////////////					times = Convert.ToInt32(AccRow.AccountabilityValue / 99);
////////////////////				}
////////////////////				times = Math.Abs(times);
////////////////////				for(int i=0; i<times; i++)
////////////////////				{
////////////////////					Data.dsAccDailyEntries.GEN_AccDailyEntriesRow AccRow2 = dsAccDailyEntries.GEN_AccDailyEntries.NewGEN_AccDailyEntriesRow();				
////////////////////					int TransID2 = TransData.CreateTransaction(ActiveSession.UserId);
////////////////////					AccRow2.TransID = TransID2;
////////////////////					AccRow2.AssignmentD = AssginmentID;
////////////////////					AccRow2.AccountabilityDate = AccDate.Date;
////////////////////					
////////////////////					if(OriginalValue > 99)
////////////////////					{
////////////////////						OriginalValue -= 99;
////////////////////						AccRow2.AccountabilityValue = 99;
////////////////////					}
////////////////////					else if(OriginalValue < -99)
////////////////////					{
////////////////////						OriginalValue += 99;
////////////////////						AccRow2.AccountabilityValue = -99;
////////////////////					}
////////////////////					else
////////////////////					{
////////////////////						AccRow2.AccountabilityValue = OriginalValue;
////////////////////					}
////////////////////
////////////////////					dsAccDailyEntries.GEN_AccDailyEntries.AddGEN_AccDailyEntriesRow(AccRow2);				
////////////////////				}
////////////////////				if (accData.Add(dsAccDailyEntries,false) >= 1)
////////////////////					return true;
////////////////////				return false;
////////////////////			}
////////////////////			#endregion
////////////////////			/////////////////////////////////////////////////////

			dsAccDailyEntries.GEN_AccDailyEntries.AddGEN_AccDailyEntriesRow(AccRow);
			if (accData.Add(dsAccDailyEntries,false) >= 1)
				return true;
			return false;
		}
		/// <summary>
		/// Save note which the employee write it in the text box.
		/// </summary>
		/// <param name="NoteDate">DateTime:Note date</param>
		/// <param name="NoteBody">string:Note words</param>
		/// <param name="localEmployeeID">int:Localemployee ID</param>
		/// <returns>bool:Returns true if success and false if not</returns>
		public bool SaveNote(DateTime NoteDate, string NoteBody,int localEmployeeID)
		{
			int noteid =  AccNotesManager.AddNote( NoteBody );
			AccNotesManager.AddNotetoContact(localEmployeeID,noteid);
			dsAccDailyEntries.Clear();
			Data.dsAccDailyEntries.GEN_AccDailyEntriesRow AccRow = dsAccDailyEntries.GEN_AccDailyEntries.NewGEN_AccDailyEntriesRow();
			int TransID = TransData.CreateTransaction(ActiveSession.UserId);
			AccRow.TransID = TransID;
			AccRow.AccountabilityDate = NoteDate;
			AccRow.AccountabilityValue = 0;
			AccRow.NoteID = noteid;
			dsAccDailyEntries.GEN_AccDailyEntries.AddGEN_AccDailyEntriesRow(AccRow);
			if (accData.Add(dsAccDailyEntries,false) >= 1)
				return true;
			return false;
		}

		/// <summary>
		/// Like the previous
		/// </summary>
		/// <param name="NoteDate"></param>
		/// <param name="NoteBody"></param>
		/// <param name="localEmployeeID"></param>
		/// <returns></returns>
		public bool SaveNoteInSpecificDate(DateTime NoteDate, string NoteBody,int localEmployeeID)
		{
			int noteid =  AccNotesManager.AddNote( NoteBody , NoteDate );
			AccNotesManager.AddNotetoContact(localEmployeeID,noteid);
			dsAccDailyEntries.Clear();
			Data.dsAccDailyEntries.GEN_AccDailyEntriesRow AccRow = dsAccDailyEntries.GEN_AccDailyEntries.NewGEN_AccDailyEntriesRow();
			int TransID = TransData.CreateTransaction(ActiveSession.UserId);
			AccRow.TransID = TransID;
			AccRow.AccountabilityDate = NoteDate;
			AccRow.AccountabilityValue = 0;
			AccRow.NoteID = noteid;
			dsAccDailyEntries.GEN_AccDailyEntries.AddGEN_AccDailyEntriesRow(AccRow);
			if (accData.Add(dsAccDailyEntries,false) >= 1)
				return true;
			return false;
		}

		#endregion

		
		#region Update Accountability for NotePad Gizmo
		public bool Update(DataSet dsNewAccountability,int EmployeeID,DateTime SheetDate,bool ISUpdateOneDateOnly)
		{
			if (!ISUpdateOneDateOnly)return false;

			if (  ! checkSec.HasUpdateAccountabiltiyAccess( EmployeeID ) )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.UpdateAccountability );
				return  false;
			}

			int weekDatCount = -(int)SheetDate.DayOfWeek;
			weekStart = SheetDate.AddDays(weekDatCount);
			DateTime weekEnd = weekStart.AddDays(6);
			Data.dsAccountabilitySheet TempAccSheet = new TSN.ERP.SharedComponents.Data.dsAccountabilitySheet();
			TempAccSheet.EnforceConstraints = false;
			TempAccSheet.Merge(dsNewAccountability);
			DataView dvAcc = new DataView();
			dvAcc.Table = TempAccSheet.EmpAccSheet;

			// filter just tasks rows
			dvAcc.RowFilter = "RecoredType = 10";
			int recCount = dvAcc.Count;
			int VnidayNumber= (int)SheetDate.DayOfWeek;
			for (int i = 0 ;i<recCount;i++)
			{
				
				Data.dsAccountabilitySheet.EmpAccSheetRow AccRow = (Data.dsAccountabilitySheet.EmpAccSheetRow ) dvAcc[i].Row;
				if(VnidayNumber==0)
				{
					if(!SetAccountabilityValue((int)AccRow.StrongID,AccRow.sun,weekStart.Date))return false;
				}
				else if(VnidayNumber==1)
				{
					if(!SetAccountabilityValue((int)AccRow.StrongID,AccRow.mon,weekStart.AddDays(1).Date))return false;
				}
				else if(VnidayNumber==2)
				{
					if(!SetAccountabilityValue((int)AccRow.StrongID,AccRow.tue,weekStart.AddDays(2).Date))return false;
				}
				else if(VnidayNumber==3)
				{
					if(!SetAccountabilityValue((int)AccRow.StrongID,AccRow.wen,weekStart.AddDays(3).Date))return false;
				}
				else if(VnidayNumber==4)
				{
					if(!SetAccountabilityValue((int)AccRow.StrongID,AccRow.thr,weekStart.AddDays(4).Date))return false;
				}
				else if(VnidayNumber==5)
				{
					if(!SetAccountabilityValue((int)AccRow.StrongID,AccRow.fri,weekStart.AddDays(5).Date))return false;
				}
				else if(VnidayNumber==6)
				{
					if(!SetAccountabilityValue((int)AccRow.StrongID,AccRow.sat,weekStart.AddDays(6).Date))return false;
				}
				else return false;
			
				
				
			}

			int noteCount = TempAccSheet.WeekNotes.Rows.Count;
			//for (int i=0;i < noteCount;i++)
		{
			Data.dsAccountabilitySheet.WeekNotesRow NoteRow = TempAccSheet.WeekNotes[VnidayNumber];
			if (NoteRow.RowState == DataRowState.Modified) 
				if (!SaveNote(NoteRow.NoteDate,NoteRow.NoteBody,EmployeeID))return false;
		}
			return true;
		}
	
		#endregion
	
		# region View Properties
		public bool ShowDaysOff
		{
			get
			{
				return _ShowDaysOff;
			}
			set
			{
				_ShowDaysOff = value;
			}
		}
		public bool ShowCompletedTasks
		{
			get
			{
				return _ShowCompletedTasks;
			}
			set
			{
				_ShowCompletedTasks = value;
			}
		}
		public int Employee 
		{
			get
			{
				return _Employee;
			}
			set
			{
				_Employee = value;
			}
		}
		public DateTime SheetDate
		{
			get
			{
				return _SheetDate;
			}
			set
			{
				_SheetDate = value;
			}
		}
	
		public View SheetView
		{
			get
			{
				return _SheetView;
			}
			set
			{
				_SheetView = value;
			}
		}
		public Sort SheetSort 
		{
			get
			{
				return _SheetSort;
			}
			set
			{
				_SheetSort = value;
			}
		}
		public DataSet AccountabilitySheet
		{
			get
			{
				return dsAccSheet;
			}
		}
		#endregion

		protected override void ObjectIntiated()
		{
			checkSec.JoinSession(ActiveSession.Token);
			AccNotesManager.JoinSession(ActiveSession.Token);
			EmpManager.JoinSession(ActiveSession.Token);
			base.ObjectIntiated ();
		}

		//------------------------------------------------------------------
		#region get total accountability sheet for all employees
		/// <summary>
		/// Get total accountability sheet for spacific
		/// </summary>
		/// <param name="sheetDate">DateTime:The time of sheet wanted to get</param>
		/// <param name="filter">string:Filter to select employee</param>
		/// <param name="sheetView">int:sheet view to select mode of showing</param>
		/// <returns>DataSet:Containing data of accoutability sheet</returns>
		[AtrERPMethodType(ERPMethodType.List)]
		public DataSet GetTotalAccSheet(DateTime sheetDate,string filter,int sheetView)
		{
			//
			dsEmpTotalAccSheet.Clear();
			DataSet dsEmp = new DataSet();
			if (filter != "")
				dsEmp.Merge(empData.List(filter)); 
			else
				dsEmp.Merge(empData.List());
 
			IFormatProvider culture = new CultureInfo("en-US",true);
			Data.dsTotalAccSheet.TotalAccSheetRow dataRow;
			DataSet dsDept = compData.List();
			DataView dvDept = dsDept.Tables[0].DefaultView;
			
			SheetDate = sheetDate;
			foreach (DataRow dr in dsEmp.Tables[0].Rows)
			{
				Employee = int.Parse(dr["ContactID"].ToString());
				SheetView = (View)sheetView;
				DataSet dsReturn = new DataSet();
				dsReturn = this.GetAccSheet(Employee,sheetDate,SheetView,true) ;
				if ( dsReturn != null )
				{
					//dataRow = new TSN.ERP.SharedComponents.Data.dsTotalAccSheet.TotalAccSheetRow(null);
					dataRow = dsEmpTotalAccSheet.TotalAccSheet.NewTotalAccSheetRow();
					dataRow["EmpName"] =  dr["FirstName"] + " " + dr["MiddleName"] + " " + dr["LastName"];
					// get department name
					dvDept.RowFilter = "CompElmentID = " + dr["CompElmentID"];
					dataRow["Dept"] = dvDept[0]["CEName"];
					// fill Dates
					dataRow["SunDate"] = dsAccSheet.Tables["WeekData"].Rows[0]["SunDate"];
					dataRow["MonDate"] = dsAccSheet.Tables["WeekData"].Rows[0]["MonDate"];
					dataRow["TueDate"] = dsAccSheet.Tables["WeekData"].Rows[0]["TueDate"];
					dataRow["WedDate"] = dsAccSheet.Tables["WeekData"].Rows[0]["WedDate"];
					dataRow["ThurDate"] = dsAccSheet.Tables["WeekData"].Rows[0]["ThurDate"];
					dataRow["FriDate"] = dsAccSheet.Tables["WeekData"].Rows[0]["FriDate"];
					dataRow["SatDate"] = dsAccSheet.Tables["WeekData"].Rows[0]["SatDate"];
					// fill total number
					dataRow["SunTotal"] = dsAccSheet.Tables["WeekData"].Rows[0]["SunTotal"];
					dataRow["MonTotal"] = dsAccSheet.Tables["WeekData"].Rows[0]["MonTotal"];
					dataRow["TuesTotal"] = dsAccSheet.Tables["WeekData"].Rows[0]["TuesTotal"];
					dataRow["WedTotal"] = dsAccSheet.Tables["WeekData"].Rows[0]["WedTotal"];
					dataRow["ThurTotal"] = dsAccSheet.Tables["WeekData"].Rows[0]["ThurTotal"];
					dataRow["FriTotal"] = dsAccSheet.Tables["WeekData"].Rows[0]["FriTotal"];
					dataRow["SatTotal"] = dsAccSheet.Tables["WeekData"].Rows[0]["SatTotal"];
					dataRow["WeekTotal"] = dsAccSheet.Tables["WeekData"].Rows[0]["WeekTotal"];
					dsEmpTotalAccSheet.Tables[0].Rows.Add(dataRow);
				}
			}
			return dsEmpTotalAccSheet;
		}
		#endregion
		//------------------------------------------------------------------

		public DataSet AccountabilityTotalEntries(int AssID)
		{
			return accData.AccountabilityTotalEntries(AssID);
		}
		/// <summary>
		/// To view all accountability employees
		/// </summary>
		/// <returns>DataSet:Containing data of employee</returns>
		public DataSet ViewAccountabilityEmployees()
		{
			if (ActiveSession.IsAdmin || CheckUserAccess((int)TSN.ERP.Security.Rules.GeneralRules.LoadAccountabilityEmployees))
				return empData.List();
			Data.dsEmployee dsEmp = new TSN.ERP.SharedComponents.Data.dsEmployee();
			dsEmp.Merge(EmpManager.GetEmployeesFromCoElement(ActiveSession.UserId,(int)Security.Rules.CompanyElementRules.ViewCompanyElementAccountability));
			dsEmp.Merge(EmpManager.GetEmployeesFromProject(ActiveSession.UserId,(int)Security.Rules.ProjectRules.ViewEmployeeAccountability));
			dsEmp.Merge(EmpManager.GetEmployeesFromTeam(ActiveSession.UserId,(int)Security.Rules.TeamRules.LoadAccountabilityEmployees));
			dsEmp.Merge(EmpManager.GetAccessedEmployees(ActiveSession.UserId,(int)Security.Rules.EmployeeRules.LoadAccountabilityEmployees));
			//GetAccessedEmployees
			if (ActiveSession.ContactId > 0)
				dsEmp.Merge(empData.List(ActiveSession.ContactId));
			return dsEmp;
		}


		//-------------------- Added by Basant 18/0ct/2006 -----------------
		/// <summary>
		/// This methd return the task summary sheet for employee withen a specific period of time
		/// </summary>
		/// <param name="ContactID">Integer</param>
		/// <param name="FromDate">DateTime</param>
		/// <param name="ToDate">DateTime</param>
		/// <returns>DataSet</returns>
		public DataSet GetEmployeeTaskSummary( int ContactID ,DateTime FromDate , DateTime ToDate )
		{
			return  accData.GetTaskSummary( ContactID , FromDate , ToDate );
		}

		/// <summary>
		/// This methd return the Notes for employee withen a specific period of time
		/// </summary>
		/// <param name="ContactID">Integer</param>
		/// <param name="FromDate">DateTime</param>
		/// <param name="ToDate">DateTime</param>
		/// <returns>DataSet</returns>
		public DataSet GetEmployeeNotesInInterval( int ContactID ,DateTime FromDate , DateTime ToDate )
		{
			return  accData.GetContactAccountabilityNotesInInterval( ContactID , FromDate , ToDate );
		}
	}
	
}
