using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using TSN.ERP.Presentation;
using TSN.ERP.SharedComponents;
namespace SharedPresentation
{
	/// <summary>
	/// Summary description for TasksService.
	/// </summary>
	public class TasksService : ERPMasterService  
	{
		protected TasksManager TaskMgr = new TasksManager();
		protected AssginmentTransactions assTrxMang  = new AssginmentTransactions();

		public TasksService()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// 		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{ 
			if (TaskMgr != null)
				//TaskMgr.Dispose();
				TaskMgr=null;
			if (assTrxMang != null)
				//assTrxMang.Dispose();
				assTrxMang=null;
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

	
		#region Tasks

		#region AddTasks
		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet AddTasks(DataSet NewTasks)
		{
			loadObjects();
			return TaskMgr.AddTasks(NewTasks);
		}
        [WebMethod(Description = "", EnableSession = true), SoapHeader("Authenticator")]
        public int AddTaskToProjectFromPDMS(string projectName, string taskName, string taskDescrption)
        {
            try
            {

                loadObjects();
                int taskUnit = 10; // hours
                return Convert.ToInt32(TaskMgr.AddTaskToProjectFromPDMS(projectName, taskName, taskDescrption, taskUnit));
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


		#endregion 

		#region UpdateTask
		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public int UpdateTask ( DataSet ds )
		{
			loadObjects();
			return TaskMgr.UpdateTask( ds );
	
		}


		#endregion 

		#region UpdateDayOff
		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public int UpdateDayOff ( DataSet ds )
		{
			loadObjects();
			return TaskMgr.UpdateDayOff( ds );
	
		}


		#endregion 

		#region DeleteTask
		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]

		public int DeleteTask ( System.Data.DataSet ds )
		{
			loadObjects();
			return	TaskMgr.DeleteTask( ds ) ;
		}


		#endregion 

		#region ViewTasks
		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ViewAllTasks ()
		{
			loadObjects();
			return TaskMgr.ViewAllTasks(); 
		}
		
		#endregion 

		#region ViewTask
		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ViewTask ( int ID )
		{
			loadObjects();
			return TaskMgr.ViewTask( ID ); 
		}
		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet LastUpdatedTasks ( )
		{
			loadObjects();
			return TaskMgr.LatestUpdatedTasks(); 
		}
		#region ViewTask
		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ViewTaskByProject ( int ProjectID )
		{
			loadObjects();
			return TaskMgr.ViewProjectTasks( ProjectID ); 
		}
		#endregion 
		
		#endregion 

		#region CompleteTask
		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public int CompleteTask ( int ID )
		{
			loadObjects();
			return TaskMgr.CompleteTask( ID ); 
		}
		[WebMethod (Description = "" ,EnableSession = true, MessageName = "CompleteTaskWithNote") , SoapHeader("Authenticator")]
		public int CompleteTask ( int ID , string TaskBody)
		{
			loadObjects();
			int ret = TaskMgr.CompleteTask( ID, TaskBody ); 
			return ret;
		}
        [WebMethod(Description = "", EnableSession = true, MessageName = "CompleteTaskFromPDMS"), SoapHeader("Authenticator")]
        public int CompleteTaskInProjFromPDMS(string projectName, string taskName)
        {
            try
            {
                loadObjects();
                int ret = TaskMgr.CompleteTaskInProjFromPDMS(projectName, taskName);
                return ret;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
		
		
		#endregion 

		#region GetAllDaysOffTasks
		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet GetAllDaysOffTasks (  )
		{
			loadObjects();
			return TaskMgr.GetAllDaysOffTasks( ); 
		}
		
		#endregion 

		#region AddDayOffTasks
		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public int AddDayOffTasks( DataSet NewTasks )
		{
			loadObjects();
			return TaskMgr.AddDayOffTasks(  NewTasks ); 
		}


		#endregion 

		#region ViewAssignmentTask
		
		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ViewAssignmentTask( int assID )
		{
			loadObjects();
			return TaskMgr.ViewAssignmentTask( assID ); 
		}
		
		#endregion 

		#region UpdateAssignmentTask

		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public int UpdateAssignmentTask( int assID , DataSet dsTsk )
		{
			loadObjects();
			return TaskMgr.UpdateAssignmentTask(  assID , dsTsk  ); 
		}


		#endregion 

		#region Get Responsibility open tasks count
		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public int GetRespOpenTasksCount ( int ResponsibilityID )
		{
			loadObjects();
			return TaskMgr.GetRespOpenTasksCount(ResponsibilityID);
		}		
		#endregion 

		#region Set Task Note on Tasks table
		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public bool SetTaskNote ( int taskID, string noteBody )
		{
			loadObjects();
			return TaskMgr.SetTaskNote(taskID, noteBody);
		}		
		#endregion 

		#endregion

		#region Assignments

		#region AssginTask

		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public int AssginTask(int TaskId, int EmployeeID,int ResponsID, int Priority)
		{
			loadObjects();
			return TaskMgr.AssginTask(TaskId,EmployeeID,ResponsID,Priority);
		}

		[WebMethod (Description = "" ,EnableSession = true , MessageName= "AssginTaskWith2Parameters" ) , SoapHeader("Authenticator")]
		public int AssginTask(int TaskId, int EmployeeID)
		{
			loadObjects();
			return TaskMgr.AssginTask(TaskId,EmployeeID);
		}
		
		[WebMethod (Description = "" ,EnableSession = true , MessageName= "AssginTaskWithDataSet" ) , SoapHeader("Authenticator")]
		public void AssginTask( DataSet ds )
		{
			loadObjects();
			TaskMgr.AssginTask( ds );
		}

		#endregion 

		#region DeleteAssignment

		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public int DeleteAssignment ( System.Data.DataSet ds )
		{
			loadObjects();
			return	TaskMgr.DeleteAssignment( ds ) ;
		}


		#endregion 

		#region ViewAssignments

		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ViewAllAssignments (  )
		{
			loadObjects();
			return  TaskMgr.ViewAllAssignments(); 
			
		}
		
		#endregion 

		#region ViewAssignmentData

		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ViewAssignmentData ( int ID )
		{
			loadObjects();
			return TaskMgr.ViewAssignmentData( ID ); 
		}
		
		#endregion 

		#region ViewEmployeeAssignments

		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ViewEmployeeAssignments ( int empID )
		{
			loadObjects();
			return TaskMgr.ViewEmployeeAssignments( empID ); 
		}
		
		
		#endregion 
		
		#region Change assignment priority

		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public void UpdateAssignmentPriority ( int AssID , int AssPriority)
		{
			loadObjects();
			TaskMgr.SetAssignmentPiority( AssID ,AssPriority); 
		}
		
		
		#endregion

		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public bool ChangeResponsbility(int assID, int NewResponseID)
		{
			loadObjects();
			return assTrxMang.ChangeResponspility(assID,NewResponseID);
		}
		#endregion 

		#region Assignments Transactions

		#region ListAllAssignmentTransactions

		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListAllAssignmentTransactions( int  assignmentID  )
		{
			loadObjects();
			return assTrxMang.ListAllAssignmentTransactions( assignmentID );
		}


		#endregion 
		
		#region AddAssignmentTransaction

		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public int AddAssignmentTransaction( DataSet assTrx )
		{
			loadObjects();
			return assTrxMang.AddAssignmentTransaction( assTrx );
		}


		#endregion 

		#region ApproveAssignment

		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public int ApproveAssignment( int assignmentID  )
		{
			loadObjects();
			return assTrxMang.ApproveAssignment( assignmentID );
		}

		#endregion 

		#region RejectAssignment

		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public int RejectAssignment( int assignmentID  )
		{
			loadObjects();
			
			return	assTrxMang.RejectAssignment( assignmentID );
		}

		#endregion 
	
		#region ReassignedAssignment

		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public int ReassignedAssignment( int assignmentID  )
		{
			
			loadObjects();
			return	assTrxMang.ReassignedAssignment( assignmentID );
		}

		#endregion 

		#region CancelAssignment

		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public int CancelAssignment( int assignmentID  )
		{
			
			loadObjects();
			return	assTrxMang.CancelAssignment( assignmentID );
		}


		#endregion 

		#region RequestToCloseAssignment

		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public int RequestToCloseAssignment( int assignmentID  )
		{
			loadObjects();
			return	assTrxMang.RequestToCloseAssignment( assignmentID );
		}


		#endregion 

		#region SetOngoingAssignment

		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public int SetOngoingAssignment( int assignmentID  )
		{
			loadObjects();
			return	assTrxMang.SetOngoingAssignment( assignmentID );
		}


		#endregion  
		
		#region CloseAssignment

		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public int CloseAssignment( int assignmentID  )
		{
			
			loadObjects();
			return	assTrxMang.CloseAssignment( assignmentID );
		}
		#endregion 

		#region OpenAssignment

		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public int OpenAssignment( int assignmentID  )
		{
			
			loadObjects();
			return	assTrxMang.OpenAssignment( assignmentID );
		}
		#endregion 

		#region Get Max Assignment Transaction Date

		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public DateTime GetMaxAssTransDate( int assignmentID  )
		{
			
			loadObjects();
			return	assTrxMang.GetMaxAssTransDate(assignmentID);
		}
		#endregion 
		
		#endregion 

		public void loadObjects()
		{
			//assTrxMang =(AssginmentTransactions) GetInstance("TSN.ERP.SharedComponents.AssginmentTransactions","TSN.ERP.SharedComponents");
			//TaskMgr = (TasksManager) GetInstance("TSN.ERP.SharedComponents.TasksManager","TSN.ERP.SharedComponents");
			assTrxMang = new AssginmentTransactions();
			assTrxMang.JoinSession(Token);
			TaskMgr = new TasksManager();
			TaskMgr.JoinSession(Token);
		}
	
	}
}
