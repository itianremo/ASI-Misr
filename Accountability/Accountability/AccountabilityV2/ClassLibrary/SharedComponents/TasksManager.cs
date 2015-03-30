using System;
using System.Data;
using TSN.ERP.Engine;
namespace TSN.ERP.SharedComponents
{
	/// <summary>
	///This class manage the tasks with it's responsibilities and assignments
	/// </summary>
	public class TasksManager:Engine.BussinesObject 
	{
		
		
		protected Data.AssignmentsDataClass AssData  = new TSN.ERP.SharedComponents.Data.AssignmentsDataClass();
		protected Data.TasksDataClass TaskData		 = new TSN.ERP.SharedComponents.Data.TasksDataClass();
		protected Data.EmployeeData	  EmpData		 = new TSN.ERP.SharedComponents.Data.EmployeeData();
		protected AssginmentTransactions AssTrxMang	 = new AssginmentTransactions(); 
		protected CheckSecurity checkSec = new CheckSecurity();

        protected Data.ProjectsData projData = new TSN.ERP.SharedComponents.Data.ProjectsData();

		public TasksManager()
		{
			this.DataComponents.Add(AssData);
			this.DataComponents.Add(TaskData);
			this.DataComponents.Add(EmpData);
            this.DataComponents.Add(projData);
		}

		protected override void ObjectIntiated( )
		{
			base.ObjectIntiated();
			AssTrxMang.JoinSession( ActiveSession.Token );
			checkSec.JoinSession(ActiveSession.Token);
		}


		
		#region Tasks

		#region AddTasks
        public bool AddTaskToProjectFromPDMS(string projectName, string taskName, string taskDescription, int taskUnit)
        {
            //ProjectsManager projManager = new ProjectsManager();
            //DataSet dsProject = projData.List("ProjectName=" + projectName + "");            
            DataSet dsProject = projData.List();            
            if (dsProject == null || dsProject.Tables.Count == 0)
            {
                return false;
            }
            else
            {
                DataRow[] projectRows = dsProject.Tables[0].Select("ProjectName='" + projectName + "'");
                if (projectRows.Length == 0)
                    return false;
                else 
                {
                    DataSet ds =ViewProjectTasks(Convert.ToInt32(projectRows[0]["projectID"]));
                    DataRow[] TaskRows = ds.Tables[0].Select("TaskName='" + taskName + "'");
                    if (TaskRows.Length > 0)
                    {
                        return false;
                    }
                    else
                    {

                        Data.dsTasks dsTask = new TSN.ERP.SharedComponents.Data.dsTasks();
                        Data.dsTasks.GEN_TasksRow taskRow = dsTask.GEN_Tasks.NewGEN_TasksRow();
                        taskRow.TaskID = 10000;
                        taskRow.projectID = Convert.ToInt32(projectRows[0]["projectID"]);
                        taskRow.TaskName = taskName;
                        taskRow.TaskDesc = taskDescription;
                        taskRow.TaskUnit = taskUnit;
                        dsTask.GEN_Tasks.AddGEN_TasksRow(taskRow);
                        AddTasks(dsTask);
                        return true;
                    }
                }
            }
        }
		/// <summary>
		/// Add new tasks to the system
		/// </summary>
		/// <param name="NewTasks">DataSet:containing a set of tasks</param>
		/// <returns>DataSet.(GEN_Tasks):containing a set of tasks</returns>
		public DataSet AddTasks(DataSet NewTasks)
		{
			try
			{
				Data.dsTasks dsTemp = new TSN.ERP.SharedComponents.Data.dsTasks();
				dsTemp.EnforceConstraints = false;
				dsTemp.Merge(NewTasks);
				int rowCount = dsTemp.GEN_Tasks.Count;
			
				if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasTaskProjectAccessRule( NewTasks , (int)TSN.ERP.Security.Rules.ProjectRules.AddTaskToProject ) || checkSec.HasTaskGeneralAccessRule(  NewTasks , (int)TSN.ERP.Security.Rules.GeneralRules.AddTasks )  )  )
				{
					SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.AddTasks );
					return  null;
				}

				for(int i = 0; i < rowCount;i++)
				{
					Data.dsTasks.GEN_TasksRow tempRow = dsTemp.GEN_Tasks[i];
					if (tempRow.RowState == DataRowState.Added)
					{
						tempRow.TaskCreatBy = ActiveSession.UserId;
						tempRow.TaskStatus = 1;
						if (!tempRow.IsTaskDurationNull())
						{
							if (tempRow.TaskDuration < 0)
								tempRow.TaskDuration = 0;
						}
						if(!tempRow.IsTaskStartDateNull() && !tempRow.IsTaskEndDateNull())
						{
							if (tempRow.TaskEndDate < tempRow.TaskStartDate )
								tempRow.TaskEndDate = tempRow.TaskStartDate;
						}
					}
				}
				TaskData.Add(dsTemp);
				return TaskData.ComponentDataSet;
			}
			catch( Exception ee )
			{
				ActiveSession.SetError(new ERPError(0,"Error While Adding Task",0,ee));
			}
			return null;
		}


		#endregion 

		#region UpdateTask
		/// <summary>
		/// Update tasks data
		/// </summary>
		/// <param name="ds">DataSet.(GEN_Tasks):containing a set of tasks</param>
		/// <returns>integer value:1 for success to update,0 for failure</returns>
		public int UpdateTask ( DataSet ds )
		{
		
			//
			#region Check Security
			
//			Data.dsTasks dsTemp = new TSN.ERP.SharedComponents.Data.dsTasks();
//			dsTemp.Merge(ds);
//			int rowCount = dsTemp.GEN_Tasks.Count;	
//
//			if ( rowCount != 0 )
//			{
//				bool haveTaskProject = false;
//				bool haveGeneralRule = false;
//				bool IsCreator		 = false;
//
//				if ( dsTemp.GEN_Tasks[ 0 ].projectID != 0 && CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.ProjectRules.UpdateTask ) , dsTemp.GEN_Tasks[ 0 ].projectID.ToString() ) )
//					haveTaskProject = true;
//
//				if ( dsTemp.GEN_Tasks[ 0 ].projectID == 0 && CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.UpdateTask  ) ) )
//					haveGeneralRule = true;
//
//				if ( dsTemp.GEN_Tasks[ 0 ].TaskCreatBy ==  ActiveSession.UserId )
//					IsCreator = true;
//
//				if ( ! ( TaskData.ActiveSession.UserSecurityInfo.Administrator || haveTaskProject || haveGeneralRule || IsCreator )  )
//				{
//					SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.UpdateTask );
//					return  0;
//				}
//			}

			#endregion

			if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasTaskProjectAccessRule( ds , (int)TSN.ERP.Security.Rules.ProjectRules.UpdateTask ) || checkSec.HasTaskGeneralAccessRule(  ds , (int)TSN.ERP.Security.Rules.GeneralRules.UpdateTask ) || checkSec.IsTaskCreator( ds ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.AddTasks );
				return  0;
			}

			return TaskData.Edit( ds );
		}


		#endregion 

		#region UpdateDayOff
		/// <summary>
		/// Update days off data
		/// </summary>
		/// <param name="ds">DataSet.(GEN_Tasks):containing a set of daysoff  </param>
		/// <returns>integer value:1 for success to update,0 for failure</returns>
		public int UpdateDayOff ( DataSet ds )
		{
		
			//
		
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasTaskGeneralAccessRule(  ds , (int)TSN.ERP.Security.Rules.GeneralRules.UpdateTask ) || checkSec.IsTaskCreator( ds ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.AddTasks );
				return  0;
			}

			return TaskData.Edit( ds );
		}


		#endregion 

		#region DeleteTask
		/// <summary>
		/// Delete tasks 
		/// </summary>
		/// <param name="ds">DataSet.(GEN_Tasks):containing a set of tasks</param>
		/// <returns>integer value:1 for success to delete,0 for failure</returns>
		public int DeleteTask ( System.Data.DataSet ds )
		{
			try
			{
				Data.dsTasks dsTemp = new TSN.ERP.SharedComponents.Data.dsTasks();
				dsTemp.Merge(ds);
				//Commented by Hamdy Ahmed on 06_11_2007 to fix the problem of deleting project task that is the only one by the project manager
//				dsTemp.AcceptChanges();
				////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
				//Added by Hamdy Ahmed on 06_11_2007 to fix the problem of deleting project task that is the only one by the project manager
				dsTemp.RejectChanges();
				/////////////////////////////////////////////////////////////////////////////////////////////////////////////
			
				//Commented by Hamdy Ahmed on 06_11_2007 to fix the problem of deleting project task that is the only one by the project manager
//				if ( ! ( ActiveSession.UserSecurityInfo.Administrator ||  checkSec.HasTaskProjectAccessRule( dsTemp , (int)TSN.ERP.Security.Rules.ProjectRules.DeleteTask ) || checkSec.HasTaskGeneralAccessRule(  ds , (int)TSN.ERP.Security.Rules.GeneralRules.DeleteTask ) || checkSec.IsTaskCreator( ds ) )  )
//				{
//					SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.DeleteTask );
//					return  0;
//				}
				////////////////////////////////////////////////////////////////////////////////////////////////////
				/////Added by Hamdy Ahmed on 06_11_2007 to fix the problem of deleting project task that is the only one by the project manager				
				if ( ! ( ActiveSession.UserSecurityInfo.Administrator ||  checkSec.HasTaskProjectAccessRule( dsTemp , (int)TSN.ERP.Security.Rules.ProjectRules.DeleteTask ) || checkSec.HasTaskGeneralAccessRule(  dsTemp , (int)TSN.ERP.Security.Rules.GeneralRules.DeleteTask ) || checkSec.IsTaskCreator( dsTemp ) )  )
				{
					SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.DeleteTask );
					return  0;
				}
				///////////////////////////////////////////////////////////////////////////////////////////////////////
				return	TaskData.Delete( ds ) ;

			}
			catch( Exception ee )
			{
				ActiveSession.SetError(new ERPError(0,"Error While Deleting Task",0,ee));
			}
			return -1;

		}


		#endregion 

		#region ViewTasks

		/// <summary>
		/// View all tasks in the system
		/// </summary>
		/// <returns>DataSet.(GEN_Tasks):containing a set of tasks</returns>
		[AtrERPMethodType(ERPMethodType.List)]
		public DataSet ViewAllTasks (  )
		{
			
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator ||  checkSec.HasAccessRule(  Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ViewAllTasks ) )))
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ViewAllTasks );
				return  null;
			}
			return TaskData.List(); 
		}
		
		#endregion 

		#region ViewTask

		/// <summary>
		/// View task detailed data
		/// </summary>
		/// <param name="ID">integer value:task ID</param>
		/// <returns>DataSet.(GEN_Tasks):containing the task selected</returns>
		[AtrERPMethodType(ERPMethodType.List , "GEN_Tasks" )]
		public DataSet ViewTask ( int ID )
		{
			//
			DataSet ds = TaskData.List( ID ); 

			//| checkSec.HasTeamAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.TeamRules.ViewTask )
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasTaskProjectAccessRule( ds , (int)TSN.ERP.Security.Rules.ProjectRules.ViewTask )  || checkSec.HasTaskGeneralAccessRule(  ds , (int)TSN.ERP.Security.Rules.GeneralRules.ViewTask ) || checkSec.IsTaskCreator( ds ) || checkSec.IsTaskAssignedEmployee( ds ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ViewTask );
				return  null;
			}

			return ds; 
		}
		
		#endregion 

		#region ViewAssignmentTask
		/// <summary>
		/// View assignment tasks
		/// </summary>
		/// <param name="assID">integer value:assignment ID</param>
		/// <returns>DataSet.(GEN_Tasks):containing a set of tasks</returns>
		public DataSet ViewAssignmentTask ( int assID )
		{
			
			DataSet dsAss = AssData.List( assID ); 
			DataSet ds = new DataSet();

			if ( dsAss.Tables[ 0 ].Rows.Count != 0 )
				ds = TaskData.List( Convert.ToInt32( dsAss.Tables[ 0 ].Rows[ 0 ][ "TaskID" ] ) ); 

			if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasTaskProjectAccessRule( ds , (int)TSN.ERP.Security.Rules.ProjectRules.ViewTask )  || checkSec.HasTaskGeneralAccessRule(  ds , (int)TSN.ERP.Security.Rules.GeneralRules.ViewTask ) || checkSec.IsTaskCreator( ds ) || checkSec.IsTaskAssignedEmployee( ds ) || checkSec.HasTeamAssignmentAccess( dsAss , (int)TSN.ERP.Security.Rules.TeamRules.ViewTask ) || checkSec.HasCompanyElementAssignmentAccess( dsAss , (int)TSN.ERP.Security.Rules.CompanyElementRules.ViewTask ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ViewTask );
				return  null;
			}
			
			return ds; 
		}
		
		#endregion 

		#region UpdateAssignmentTask
		/// <summary>
		/// Update data for assignment tasks 
		/// </summary>
		/// <param name="assID">integer value:assignment ID</param>
		/// <param name="dsTsk">DataSet.(GEN_Tasks):containing a set of tasks</param>
		/// <returns>integer value:1 for success to delete and 0 for failure</returns>
		public int UpdateAssignmentTask ( int assID , DataSet dsTsk )
		{
			
			DataSet dsAss = AssData.List( assID ); 
			
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasTaskProjectAccessRule( dsTsk , (int)TSN.ERP.Security.Rules.ProjectRules.UpdateTask ) || checkSec.HasTaskGeneralAccessRule(  dsTsk , (int)TSN.ERP.Security.Rules.GeneralRules.UpdateTask ) || checkSec.IsTaskCreator( dsTsk ) || checkSec.HasTeamAssignmentAccess( dsAss , (int)TSN.ERP.Security.Rules.TeamRules.UpdateTask ) || checkSec.HasCompanyElementAssignmentAccess( dsAss , (int)TSN.ERP.Security.Rules.CompanyElementRules.UpdateTask ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.AddTasks );
				return  0;
			}

			return TaskData.Edit( dsTsk );
		}


		#endregion 

		#region ViewProjectTasks

		/// <summary>
		/// View all project tasks
		/// </summary>
		/// <param name="projID">integer value:project ID</param>
		/// <returns>DataSet.(GEN_Tasks):containing a set of tasks</returns>
		[AtrERPMethodType(ERPMethodType.List , "GEN_Projects" )]
		public DataSet ViewProjectTasks ( int projID )
		{
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasAccessRule( (int)TSN.ERP.Security.Rules.ProjectRules.ViewProjectTasks , projID.ToString() ) || checkSec.HasAccessRule( (int)TSN.ERP.Security.Rules.GeneralRules.ViewProjectTasks ) ))
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.ProjectRules.ViewProjectTasks );
				return  null;
			}
			return  TaskData.GetProjectTasks( projID ); 
		}
		
		#endregion 

		#region GetLastTasksStatus

		// to get the last set of updated tasks
		/// <summary>
		// Get the last set of updated tasks
		/// </summary>
		/// <returns>DataSet.(GEN_Tasks):containing a set of updated tasks</returns>
		public DataSet GetLastTasksStatus()
		{
		
			return ActiveSession.LastDataSet;
		}
		

		#endregion

		#region CompleteTask

		/// <summary>
		/// Set task as completed
		/// </summary>
		/// <param name="taskID">integer value:task ID</param>
		/// <returns>integer value:1 for success,0 for failure</returns>
		public int CompleteTask ( int taskID )
		{
			return CompleteTask(taskID,"");
		}

		/// <summary>
		/// Set task as completed and set a note to it
		/// </summary>
		/// <param name="taskID">integer value for task ID</param>
		/// <param name="noteBody">string:holding completed task note</param>
		/// <returns>integer value:1 for success,0 for failure</returns>
		public int CompleteTask ( int taskID ,string noteBody)
		{
			int result = 0;
			// Get Task Details	
			Data.dsTasks taskDS =new TSN.ERP.SharedComponents.Data.dsTasks();
			taskDS.Merge( ViewTask( taskID ) );
			taskDS.EnforceConstraints = false;
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasTaskProjectAccessRule( taskDS , (int)TSN.ERP.Security.Rules.ProjectRules.CompleteTask ) || checkSec.HasTaskGeneralAccessRule(  taskDS , (int)TSN.ERP.Security.Rules.GeneralRules.CompleteTask ) || checkSec.IsTaskCreator( taskDS ) ) )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.CompleteTask );
				return  0;
			}

			if ( taskDS.Tables[ 0 ].Rows.Count != 0 )
			{
				
				// Get all task assignments
				Data.dsAssignments dsAss = new TSN.ERP.SharedComponents.Data.dsAssignments();
				dsAss.Merge( AssData.ViewTaskAssignments( Convert.ToInt32( taskDS.Tables[ 0 ].Rows[ 0 ][ "TaskID" ] ) ) );
				
				AssTrxMang = new AssginmentTransactions();
				AssTrxMang.JoinSession( this.ActiveSession.Token );

				// close all task assginmnets
				for ( int i = 0 ; i < dsAss.GEN_Assignments.Rows.Count ; i++ )
				{
					if(Convert.ToInt32(taskDS.GEN_Tasks[ 0 ].TaskStatus) == 0)
					{
						AssTrxMang.OpenAssignment( dsAss.GEN_Assignments[ i ].AssignmentD);
					}
					else if(Convert.ToInt32(taskDS.GEN_Tasks[ 0 ].TaskStatus) == 1)
					{
						AssTrxMang.CloseAssignment( dsAss.GEN_Assignments[ i ].AssignmentD);
					}					
				}

				// close task
				if(Convert.ToInt32(taskDS.GEN_Tasks[ 0 ].TaskStatus) == 0)
				{
					taskDS.GEN_Tasks[ 0 ].TaskStatus = 1;
				}
				else if(Convert.ToInt32(taskDS.GEN_Tasks[ 0 ].TaskStatus) == 1)
				{
					taskDS.GEN_Tasks[ 0 ].TaskStatus = 0;
				}
//				//If task start date is greater than today's date, then make task close date = task start date, else maje task close date = today's date
//				if(taskDS.GEN_Tasks[ 0 ].TaskStartDate > DateTime.Now)
//				{
//					taskDS.GEN_Tasks[ 0 ].TaskCloseDate = taskDS.GEN_Tasks[ 0 ].TaskStartDate;
//				}
//				else
//				{
					taskDS.GEN_Tasks[ 0 ].TaskCloseDate = DateTime.Now;
//				}
		
				result = UpdateTask( taskDS );
				TaskData.SetTaskNote( taskID , noteBody);
			}
			return result;
	
		}

        public int CompleteTasksInProject(int taskID, string noteBody)
        {

            int result = 0;

            // Get Task Details	
            Data.dsTasks taskDS = new TSN.ERP.SharedComponents.Data.dsTasks();
            taskDS.Merge(ViewTask(taskID));
            taskDS.EnforceConstraints = false;

            if (!(ActiveSession.UserSecurityInfo.Administrator || checkSec.HasTaskProjectAccessRule(taskDS, (int)TSN.ERP.Security.Rules.ProjectRules.CompleteTask) || checkSec.HasTaskGeneralAccessRule(taskDS, (int)TSN.ERP.Security.Rules.GeneralRules.CompleteTask) || checkSec.IsTaskCreator(taskDS)))
            {
                SendAccessDeniedMessage((int)TSN.ERP.Security.Rules.GeneralRules.CompleteTask);
                return 0;
            }

            if (taskDS.Tables[0].Rows.Count != 0)
            {

                // Get all task assignments
                Data.dsAssignments dsAss = new TSN.ERP.SharedComponents.Data.dsAssignments();
                dsAss.Merge(AssData.ViewTaskAssignments(Convert.ToInt32(taskDS.Tables[0].Rows[0]["TaskID"])));

                AssTrxMang = new AssginmentTransactions();
                AssTrxMang.JoinSession(this.ActiveSession.Token);

                // close all task assginmnets
                for (int i = 0; i < dsAss.GEN_Assignments.Rows.Count; i++)
                {
                    //if (Convert.ToInt32(taskDS.GEN_Tasks[0].TaskStatus) == 0)
                    //{
                    //    AssTrxMang.OpenAssignment(dsAss.GEN_Assignments[i].AssignmentD);
                    //}
                    //else if (Convert.ToInt32(taskDS.GEN_Tasks[0].TaskStatus) == 1)
                    //{
                        AssTrxMang.CloseAssignment(dsAss.GEN_Assignments[i].AssignmentD);
                    //}
                }

                // close task
                //if (Convert.ToInt32(taskDS.GEN_Tasks[0].TaskStatus) == 0)
                //{
                //    taskDS.GEN_Tasks[0].TaskStatus = 1;
                //}
                //else if (Convert.ToInt32(taskDS.GEN_Tasks[0].TaskStatus) == 1)
                //{
                    taskDS.GEN_Tasks[0].TaskStatus = 0;
                //}
                //				//If task start date is greater than today's date, then make task close date = task start date, else maje task close date = today's date
                //				if(taskDS.GEN_Tasks[ 0 ].TaskStartDate > DateTime.Now)
                //				{
                //					taskDS.GEN_Tasks[ 0 ].TaskCloseDate = taskDS.GEN_Tasks[ 0 ].TaskStartDate;
                //				}
                //				else
                //				{
                taskDS.GEN_Tasks[0].TaskCloseDate = DateTime.Now;
                //				}

                result = UpdateTask(taskDS);
                TaskData.SetTaskNote(taskID, noteBody);
            }
            return result;

        }

        public int CompleteTaskInProjFromPDMS(string projectName, string taskName)
        {            
            DataSet dsProject = projData.List("ProjectName='" + projectName + "'");
            DataSet dsTask = TaskData.List("TaskName='" + taskName + "'");
            if (dsProject == null || dsProject.Tables.Count == 0 || dsTask == null || dsTask.Tables.Count == 0)
            {
                return -1;
            }
            else
            {  
                int taskID = Convert.ToInt32(dsTask.Tables[0].Rows[0]["TaskID"]);
                int i = CompleteTasksInProject(taskID, "");
                return i;
            }
            //DataSet dsProject = projData.List();
            //if (dsProject == null || dsProject.Tables.Count == 0)
            //{
            //    return -1;
            //}
            //else
            //{
            //    DataRow[] projectRows = dsProject.Tables[0].Select("ProjectName='" + projectName + "'");
            //    if (projectRows.Length == 0)
            //        return -1;
            //    else
            //    {
            //        Data.dsTasks dsTask = new TSN.ERP.SharedComponents.Data.dsTasks();
            //        Data.dsTasks.GEN_TasksRow taskRow = dsTask.GEN_Tasks.NewGEN_TasksRow();



            //        taskRow.TaskID = 10000;
            //        taskRow.projectID = Convert.ToInt32(projectRows[0]["projectID"]);
            //        taskRow.TaskName = taskName;
            //        taskRow.TaskDesc = taskDescription;
            //        dsTask.GEN_Tasks.AddGEN_TasksRow(taskRow);
            //        AddTasks(dsTask);
            //        return 1;
            //    }
            //}
            //return -1;
        }

		#endregion 

		#region Set Task Notes
		public bool SetTaskNote ( int taskID ,string noteBody)
		{
			// Get Task Details	
			Data.dsTasks taskDS =new TSN.ERP.SharedComponents.Data.dsTasks();
			taskDS.Merge( ViewTask( taskID ) );
			taskDS.EnforceConstraints = false;

			if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasTaskProjectAccessRule( taskDS , (int)TSN.ERP.Security.Rules.ProjectRules.CompleteTask ) || checkSec.HasTaskGeneralAccessRule(  taskDS , (int)TSN.ERP.Security.Rules.GeneralRules.CompleteTask ) || checkSec.IsTaskCreator( taskDS ) ) )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.CompleteTask );
				return  false;
			}
			return TaskData.SetTaskNote(taskID, noteBody);
		}

		#endregion 

		#region Latest Updated Tasks

		/// <summary>
		/// Get the latest updated tasks
		/// </summary>
		/// <returns>DataSet.(GEN_Tasks):containing a set of tasks</returns>
		public DataSet LatestUpdatedTasks()
		{
			
			return TaskData.ComponentDataSet;
		}
		#endregion

		#region AddDayOffTasks

		/// <summary>
		/// Add days off to all employees
		/// </summary>
		/// <param name="NewTasks">DataSet.(GEN_Tasks):containing a set of daysoff</param>
		/// <returns>integer value:1 for success,0 for failure</returns>
		public int AddDayOffTasks( DataSet NewTasks )
		{
			
			Data.dsTasks dsTemp = new TSN.ERP.SharedComponents.Data.dsTasks();
			dsTemp.EnforceConstraints = false;
			dsTemp.Merge(NewTasks);
			int rowCount = dsTemp.GEN_Tasks.Count;
			
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasTaskGeneralAccessRule(  NewTasks , (int)TSN.ERP.Security.Rules.GeneralRules.AddDayOff )  )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.AddTasks );
				return  0;
			}

			for(int i = 0; i < rowCount;i++)
			{
				Data.dsTasks.GEN_TasksRow tempRow = dsTemp.GEN_Tasks[i];
				if (tempRow.RowState == DataRowState.Added)
				{
					tempRow.TaskCreatBy = ActiveSession.UserId;
					tempRow.TaskStatus  = 1;
					tempRow.TaskUnit    = 40;
					
				}
			}
			
			// add task
			int n = this.TaskData.Add(dsTemp);
			dsTemp.Merge ( TaskData.ComponentDataSet );

			// assgin task to all employees
			DataSet ds = EmpData.List();
			Data.dsEmployee dsEmp = new TSN.ERP.SharedComponents.Data.dsEmployee();
			dsEmp.Merge( ds );

			if ( n != 0)
			{
				for(int i = 0; i < rowCount;i++)
				{
					if ( dsTemp.GEN_Tasks[ i ].RowState == DataRowState.Modified )
					{
						for( int j = 0 ; j < dsEmp.Tables [ 0 ].Rows.Count ; j++ )
						{
							AssginTask( dsTemp.GEN_Tasks[ i ].TaskID , dsEmp.GEN_Employees[ j ].ContactID  ) ;
						}
					}
				}
			}
			return n;
		}


		#endregion 

		#region GetAllDaysOffTasks

		/// <summary>
		/// Get all days off
		/// </summary>
		/// <returns>DataSet.(GEN_Tasks):containing a set of daysoff</returns>
		public DataSet GetAllDaysOffTasks (  )
		{
			
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator ||  checkSec.HasAccessRule(  Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ViewAllTasks ) )))
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ViewAllTasks );
				return  null;
			}
			return TaskData.GetAllDaysOff(); 
		}
		
		#endregion 

		#region Get a specific resposibility open tasks count

		/// <summary>
		/// 
		/// </summary>
		/// <param name="RespID"></param>
		/// <returns></returns>
		public int GetRespOpenTasksCount ( int RespID )
		{
			
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator))
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ViewAllTasks );
				return  -1;
			}
			return TaskData.GetRespOpenTasksCount(RespID);
		}
		
		#endregion 

		#endregion 

		#region Assignments

		#region AssginTask	

		/// <summary>
		/// Assign task to employee 
		/// </summary>
		/// <param name="TaskId">integer value:task ID</param>
		/// <param name="EmployeeID">integer value:employee ID </param>
		/// <param name="ResponsID">integer value:Reponsibility ID</param>
		/// <param name="Priority">integer value:priority ID</param>
		/// <returns>integer value:1 if succeeded to assign task and 0 if failed</returns>
		public int AssginTask( int TaskId, int EmployeeID,int ResponsID, int Priority )
		{
			
			DataSet dsTask = TaskData.List( TaskId );
  
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasTaskProjectAccessRule( dsTask , (int)TSN.ERP.Security.Rules.ProjectRules.AssginTaskToProject ) || checkSec.HasTeamAssignmentAccess( EmployeeID , (int)TSN.ERP.Security.Rules.TeamRules.AssginTask ) || checkSec.HasCompanyElementAddAssignmentAccess( EmployeeID , (int)TSN.ERP.Security.Rules.CompanyElementRules.AssginTask )  ||  checkSec.HasTaskGeneralAccessRule( dsTask , (int)TSN.ERP.Security.Rules.GeneralRules.AssginTask ) || checkSec.HasEmployeeAssignmentAccess( EmployeeID , (int)TSN.ERP.Security.Rules.EmployeeRules.AssginTask ) || checkSec.HasAssignedToAccess( EmployeeID , (int)TSN.ERP.Security.Rules.EmployeeRules.AssginTask )  )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ViewTask );
				return  0;
			}

			return AssData.AssginTask( TaskId, EmployeeID, ResponsID,  Priority );
			
		}


		/// <summary>
		/// Assign task to employee
		/// </summary>
		/// <param name="TaskId">integer value: for task ID</param>
		/// <param name="EmployeeID">integer value:employee ID</param>
		/// <returns>integer value:1 if succeeded to assign task and 0 if failed</returns>
		public int AssginTask( int TaskId, int EmployeeID )
		{
			DataSet dsTask = TaskData.List( TaskId );
  
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasTaskProjectAccessRule( dsTask , (int)TSN.ERP.Security.Rules.ProjectRules.AssginTaskToProject ) || checkSec.HasTeamAssignmentAccess( EmployeeID , (int)TSN.ERP.Security.Rules.TeamRules.AssginTask )  || checkSec.HasCompanyElementAddAssignmentAccess( EmployeeID , (int)TSN.ERP.Security.Rules.CompanyElementRules.AssginTask ) ||  checkSec.HasTaskGeneralAccessRule( dsTask , (int)TSN.ERP.Security.Rules.GeneralRules.AssginTask ) || checkSec.HasEmployeeAssignmentAccess( EmployeeID , (int)TSN.ERP.Security.Rules.EmployeeRules.AssginTask ) || checkSec.HasAssignedToAccess( EmployeeID , (int)TSN.ERP.Security.Rules.EmployeeRules.AssginTask )  )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ViewTask );
				return  0;
			}

			return  AssData.AssginTask( TaskId, EmployeeID );

		}


		/// <summary>
		/// Assign task to employee
		/// </summary>
		/// <param name="dsAssignments">DataSet.(GEN_Assignments):containing a set of assignments</param>
		public void AssginTask( DataSet dsAssignments )
		{
			
			Data.dsAssignments dsAss = new TSN.ERP.SharedComponents.Data.dsAssignments();
			dsAss.EnforceConstraints = false;
			dsAss.Merge( dsAssignments );
		

			if( dsAss != null )
				for( int i = 0 ; i < dsAss.GEN_Assignments.Rows.Count ; i++ )
				{
					if ( ! dsAss.GEN_Assignments[ i ].IsResponsIDNull()  )
						AssData.AssginTask( dsAss.GEN_Assignments[ i ].TaskID , dsAss.GEN_Assignments[ i ].ContactID , dsAss.GEN_Assignments[ i ].ResponsID , dsAss.GEN_Assignments[ i ].AssignmentPriority , dsAss.GEN_Assignments[ i ].AssignmentDate );
					
					else 
						AssData.AssginTask( dsAss.GEN_Assignments[ i ].TaskID , dsAss.GEN_Assignments[ i ].ContactID , dsAss.GEN_Assignments[ i ].AssignmentDate );
				}
		}
 

		#endregion 
	
		#region DeleteAssignment

		/// <summary>
		/// Delete assignments
		/// </summary>
		/// <param name="ds">DataSet:containing a set of assignments</param>
		/// <returns>integer value:1 for success deletion else failure </returns>
		public int DeleteAssignment ( System.Data.DataSet ds )
		{
			try
			{
				DataSet tempds = new DataSet();
				tempds.Merge(ds);
				tempds.RejectChanges();
				
				if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasCompanyElementAssignmentAccess( tempds , (int)TSN.ERP.Security.Rules.CompanyElementRules.DeleteAssignment ) || checkSec.HasProjectAssignmentAccess( tempds , (int)TSN.ERP.Security.Rules.ProjectRules.DeleteAssignment ) || checkSec.HasTeamAssignmentAccess( tempds , (int)TSN.ERP.Security.Rules.TeamRules.DeleteAssignment )|| checkSec.HasAssignedToAccess( tempds , (int)TSN.ERP.Security.Rules.EmployeeRules.DeleteAssignment ) || checkSec.HasCreatorAssignmentAccess( tempds , (int)TSN.ERP.Security.Rules.EmployeeRules.DeleteAssignment ) || checkSec.HasEmployeeAssignmentAccess( tempds , (int)TSN.ERP.Security.Rules.EmployeeRules.ApproveAssignment ) || checkSec.HasAccessRule( (int)TSN.ERP.Security.Rules.GeneralRules.DeleteAssignment )))
				{
					SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.DeleteAssignment );
					return  0; 
				}

				return	AssData.Delete( ds ) ;

			}
			catch(Exception ex)
			{
				ActiveSession.SetError(new ERPError(0,"Error Deleteing Assginment",0,ex));
				return -1;
			}
		}


		#endregion 

		#region ViewAssignments

		/// <summary>
		/// View all assignments
		/// </summary>
		/// <returns>DataSet.(GEN_Assignments):containing a set of assignments</returns>
		[AtrERPMethodType(ERPMethodType.List)]
		public DataSet ViewAllAssignments (  )
		{
			
			DataSet ds = new DataSet();
			
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasAccessRule( (int)TSN.ERP.Security.Rules.GeneralRules.ViewAllAssignments )))
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ViewAllAssignments );
				return  null;
			}

			ds = AssData.List(); 
			
			return ds;
		}
		
		#endregion 

		#region ViewAssignmentData

		/// <summary>
		/// View assignment detailed data
		/// </summary>
		/// <param name="ID">integer value:assignment ID</param>
		/// <returns>DataSet.(GEN_Assignments):containing assignment data</returns>
		[AtrERPMethodType(ERPMethodType.List , "GEN_Assignments" )]
		public DataSet ViewAssignmentData ( int ID )
		{
			DataSet ds = new DataSet();
			ds = AssData.List( ID ); 

			if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasCompanyElementAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.CompanyElementRules.ViewAssignmentData ) || checkSec.HasProjectAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.ProjectRules.ViewAssignmentData ) || checkSec.HasTeamAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.TeamRules.ViewAssignmentData )|| checkSec.HasAssignedToAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.ViewAssignmentData ) || checkSec.HasCreatorAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.ViewAssignmentData ) || checkSec.HasEmployeeAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.ViewAssignmentData ) || checkSec.HasAccessRule( (int)TSN.ERP.Security.Rules.GeneralRules.ViewAssignmentData )))
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ViewAllAssignments );
				return  null; 
			}

			return ds;
		}
		
		#endregion 

		#region ViewTaskAssignments

		/// <summary>
		/// View task assignments
		/// </summary>
		/// <param name="taskID">integer value:task ID</param>
		/// <returns>DataSet.(GEN_Assignments):containing a set of assignments</returns>
		[AtrERPMethodType(ERPMethodType.List , "GEN_Tasks" )]
		public DataSet ViewTaskAssignments ( int taskID )
		{
			
			DataSet dsTask = TaskData.List( taskID ); 
			
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasTaskProjectAccessRule( dsTask , (int)TSN.ERP.Security.Rules.ProjectRules.ViewTaskAssignment ) || checkSec.HasTaskGeneralAccessRule( dsTask , (int)TSN.ERP.Security.Rules.GeneralRules.ViewTaskAssignments )))
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ViewAllAssignments );
				return  null; 
			}
	
			return  AssData.ViewTaskAssignments( taskID );
		}
		
		#endregion 

		#region ViewResponsibiltyAssignments

		/// <summary>
		/// View all responsibility assignments
		/// </summary>
		/// <param name="responsID">integer value:responsibility ID</param>
		/// <returns>DataSet.(GEN_Assignments):containing a set of assignments</returns>
		[AtrERPMethodType(ERPMethodType.List , "GEN_Responsibilities" )]
		public DataSet ViewResponsibiltyAssignments ( int responsID )
		{
			
			return AssData.ViewResponsAssignments( responsID );
		}
		
		#endregion 

		#region ViewEmpAssignentsInProjectResponsibility

		/// <summary>
		/// View employee assignments for a given project responsibility 
		/// </summary>
		/// <param name="empID">integer value:employee ID</param>
		/// <param name="responseID">integer value:responsibility ID</param>
		/// <param name="projID">integer value:project ID</param>
		/// <returns>DataSet.(GEN_Assignments):containing a set of assignments</returns>
		[AtrERPMethodType(ERPMethodType.List , "GEN_Employees;GEN_Responsibilities;GEN_Projects" )]
		public DataSet ViewEmpAssignentsInProjectResponsibility ( int empID , int responseID , int projID )
		{
			
			return AssData.ViewEmpAssignentsInProjectResponsibility(  empID ,  responseID , projID );
		}
		
		#endregion 

		#region ViewEmployeeAssignments

		/// <summary>
		/// View all employee assignments
		/// </summary>
		/// <param name="empID">integer value:employee ID</param>
		/// <returns>DataSet.(GEN_Assignments):containing a set of assignments</returns>
		[AtrERPMethodType(ERPMethodType.List , "GEN_Employees" )]
		public DataSet ViewEmployeeAssignments ( int empID )
		{
			
			return AssData.GetEmpAssginemts( empID );
		}
		
		#endregion 

		#region SetAssignmentPiority

		/// <summary>
		/// Set assignment priority
		/// </summary>
		/// <param name="assignmentID">integer value:assignment ID</param>
		/// <param name="priority">integer value:indicating priority</param>
		/// <returns>integer value: 0 for failure assignment,1 for success,-1 if priority has negative value</returns>
		public int SetAssignmentPiority( int assignmentID , int priority )
		{
			if (priority < 0 ) return -1;
			int result = 0 ;
			// get assignment
			Data.dsAssignments  ds = new TSN.ERP.SharedComponents.Data.dsAssignments();
			ds.Merge ( (Data.dsAssignments) AssData.List( assignmentID ) );
			
			if( ds.Tables[ 0 ].Rows.Count != 0 )
			{
				if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasCompanyElementAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.CompanyElementRules.SetAssignmentPiority ) || checkSec.HasProjectAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.ProjectRules.SetAssignmentPiority ) || checkSec.HasTeamAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.TeamRules.SetAssignmentPiority )|| checkSec.HasAssignedToAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.SetAssignmentPiority ) || checkSec.HasCreatorAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.SetAssignmentPiority ) || checkSec.HasEmployeeAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.SetAssignmentPiority ) || checkSec.HasAccessRule( (int)TSN.ERP.Security.Rules.GeneralRules.SetAssignmentPiority )))
				{
					SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.SetAssignmentPiority );
					return  0; 
				}
				// update assignment 
				ds.GEN_Assignments[ 0 ].AssignmentPriority = priority;
				result =  AssData.Update( ds );
			}
			
			return	result;
		}
		#endregion 

		#endregion 
		
		
	}
}
