using System;
using System.Data;
using TSN.ERP.Engine;
namespace TSN.ERP.SharedComponents
{
	/// <summary>
	/// Summary description for ProjectsManager.
	/// </summary>
	public class ProjectsManager:Engine.BussinesObject 
	{
		protected Data.ProjectsData      ProjectsData	= new TSN.ERP.SharedComponents.Data.ProjectsData();
		protected Data.ProjectLevels     PrjLevelData	= new TSN.ERP.SharedComponents.Data.ProjectLevels();
		protected TasksManager		     TaskMag		= new TasksManager();
		protected Data.EmployeeData      EmpData		= new TSN.ERP.SharedComponents.Data.EmployeeData();
		protected Data.EmployeeXProjects EmpXProjData   = new TSN.ERP.SharedComponents.Data.EmployeeXProjects();
		
		public ProjectsManager()
		{
			this.DataComponents.Add(ProjectsData);
			this.DataComponents.Add(EmpData);
			this.DataComponents.Add(EmpXProjData);
			this.DataComponents.Add(PrjLevelData);
		}

		protected override void ObjectIntiated()
		{
			base.ObjectIntiated ();
			TaskMag.JoinSession(ActiveSession.Token);
		}

		#region ListProjects
		/// <summary>
		/// It returns data of all projects 
		/// </summary>
		/// <returns>DataSet:Containing all data of all projects</returns>
		[AtrERPMethodType(ERPMethodType.List)]
		public DataSet ListAllProjects()
		{
			
			if ( ! ( ProjectsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListAllProjects  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListAllProjects  );
				return  null;
			}

			return this.ProjectsData.List();
		}
		/// <summary>
		/// It list all projects of user.		
		/// </summary>
		/// <returns></returns>
		[AtrERPMethodType(ERPMethodType.List)]
		public DataSet ListUserProjects()
		{
			Data.dsProjects dsUsrPrj = new TSN.ERP.SharedComponents.Data.dsProjects();
			Data.dsEmployeesXProjects dsEmpXPRoject = new TSN.ERP.SharedComponents.Data.dsEmployeesXProjects();
			if (ActiveSession.IsAdmin ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListAllProjects )))
				return ProjectsData.List();

			int userContactid = ActiveSession.ContactId; 
			if (userContactid < 0)
				return null; 
			
			// User is a project manger or owner
			dsUsrPrj.Merge(ProjectsData.List("ProjectManager = " + userContactid.ToString() + " or ProjectOwner = " + ActiveSession.UserId.ToString() ));
			dsEmpXPRoject.Merge(EmpXProjData.List("ContactID = " + userContactid.ToString() ));
			foreach (Data.dsEmployeesXProjects.GEN_EmployeesXProjectsRow tempRow in dsEmpXPRoject.GEN_EmployeesXProjects.Rows)
				dsUsrPrj.Merge(ProjectsData.List(tempRow.projectID));
			return dsUsrPrj;

		}

		#endregion 

		#region ListProject
		/// <summary>
		/// It returns data of spacific project.
		/// </summary>
		/// <param name="projID">int:The project ID</param>
		/// <returns>DataSet:Contraining data of the project</returns>
		[AtrERPMethodType(ERPMethodType.List , "GEN_Projects" )]
		public DataSet ListProject( int projID )
		{
			
			if ( ! ( ProjectsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.ProjectRules.ListProject  ) , projID.ToString() )))
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.ProjectRules.ListProject  );
				return  null;
			}

			return this.ProjectsData.List( projID );
		}
        public DataSet ListProjectByName(string projectName)
        {

            return this.ProjectsData.List("ProjectName=" + projectName + "");
        }

		#endregion 

		#region AddProject
		/// <summary>
		/// Add new projects to project list.
		/// </summary>
		/// <param name="NewProjects">DataSet:Cotaining data of new project</param>
		/// <returns>int:Returns 1 if success and 0 if failed</returns>
		public int AddProject(DataSet NewProjects)
		{
			
			if ( ! ( ProjectsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.AddProject  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.AddProject  );
				return  0;
			}

			Data.dsProjects dsPrj =  new Data.dsProjects();
			dsPrj.EnforceConstraints = false;
			dsPrj.Merge( NewProjects );
			int rowCount = dsPrj.GEN_Projects.Rows.Count;
			for (int i=0;i<rowCount;i++)
			{
				if (dsPrj.GEN_Projects[i].RowState != DataRowState.Added )
					continue;
				if ( ! dsPrj.GEN_Projects[i].IsProjectTargetDateNull() )
					dsPrj.GEN_Projects[i].ProjectOrginatorTarget = dsPrj.GEN_Projects[i].ProjectTargetDate;
				dsPrj.GEN_Projects[i].ProjectOwner = ActiveSession.UserId;
				dsPrj.GEN_Projects[i].ProjectStatus = 1;
			}
			return this.ProjectsData.Add(dsPrj);
		}
        public int AddProjectFromPDMS(string projectName)
        {

            if (!(ProjectsData.ActiveSession.UserSecurityInfo.Administrator || CheckUserAccess(Convert.ToInt32(TSN.ERP.Security.Rules.GeneralRules.AddProject))))
            {
                SendAccessDeniedMessage((int)TSN.ERP.Security.Rules.GeneralRules.AddProject);
                return 0;
            }

            Data.dsProjects dsPrj = new Data.dsProjects();
            dsPrj.EnforceConstraints = false;
            Data.dsProjects.GEN_ProjectsRow row = dsPrj.GEN_Projects.NewGEN_ProjectsRow();
            row.ProjectName = projectName;
            dsPrj.GEN_Projects.AddGEN_ProjectsRow(row);
            return AddProject(dsPrj);
        }

		#endregion 

		#region EditProjects
		/// <summary>
		/// Edit the data of projects.
		/// </summary>
		/// <param name="ModifiedProjects">DataSet:Containing data which wanted to modified</param>
		/// <returns>int:Returns 1 if success and 0 if failed</returns>
		public int EditProjects(DataSet ModifiedProjects)
		{
			
			Data.dsProjects prj = new TSN.ERP.SharedComponents.Data.dsProjects();
			if ( ModifiedProjects != null &&  ModifiedProjects.Tables[ 0 ].Rows.Count != 0  )
			{
				prj.Merge( ModifiedProjects );
			
				if ( ! ( ProjectsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.ProjectRules.EditProject  ) , prj.GEN_Projects[ 0 ].projectID.ToString() ) )  )
				{
					SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.ProjectRules.EditProject  );
					return  0;
				}
				return this.ProjectsData.Edit(ModifiedProjects);
			}
			else
				return 0;
		}

		#endregion 

		#region DeleteProjects
		/// <summary>
		/// Deleted a projects from system.
		/// </summary>
		/// <param name="DeletedProjects">DataSet:Containing data which wanted to deleted</param>
		/// <returns>int:Returns 1 if success and 0 if failed</returns>
		public int DeleteProjects(DataSet DeletedProjects)
		{
			
			Data.dsProjects prj = new TSN.ERP.SharedComponents.Data.dsProjects();
			if ( DeletedProjects != null &&  DeletedProjects.Tables[ 0 ].Rows.Count != 0  )
			{
				prj.Merge( DeletedProjects );

				if ( ! ( ProjectsData.ActiveSession.UserSecurityInfo.Administrator ))
				{
					SendAccessDeniedMessage( -1 );
					return  0;
				}
				return this.ProjectsData.Delete(DeletedProjects);
			}
			else
				return 0;
		}

		#endregion 
		
		#region ProjectSimpleList
		/// <summary>
		/// Show a simple list for projects.
		/// </summary>
		/// <returns>DataSet:Containing data of the simple list of projects</returns>
		[AtrERPMethodType(ERPMethodType.List)]
		public DataSet ProjectSimpleList()
		{
			
			if ( ! ( ProjectsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListAllProjects  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListAllProjects  );
				return  null;
			}
			return this.ProjectsData.ProjectSimpleList();
		}

		#endregion 

		#region ListEmployeeProjects
		/// <summary>
		/// List all projects for spacific employee.
		/// </summary>
		/// <param name="empID">int:Employee ID</param>
		/// <returns>DataSet:Containing the data of projects</returns>
		[AtrERPMethodType(ERPMethodType.List , "GEN_Employees" ) ]
		public DataSet ListEmployeeProjects( int empID )
		{
			
			if ( ! ( ProjectsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.EmployeeRules.ListEmployeesProjects ) , empID.ToString() ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.EmployeeRules.ListEmployeesProjects  );
				return  null;
			}

			return this.ProjectsData.ProjectsByEmployee( empID );
		}

		#endregion

		#region ListProjectsByEmployeeResponsibilty
		/// <summary>
		/// List projects for spcific employee under spcific responsibilty.
		/// </summary>
		/// <param name="empID">int:Employee ID</param>
		/// <param name="responseID">int:Responsibilty ID</param>
		/// <returns>DataSet:Containing the data of projects</returns>
		[AtrERPMethodType(ERPMethodType.List , "GEN_Employees;GEN_Responsibilities" )]
		public DataSet ListProjectsByEmployeeResponsibilty( int empID , int responseID )
		{
			
			if ( ! ( ProjectsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.EmployeeRules.ListEmployeesProjects  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.EmployeeRules.ListEmployeesProjects  );
				return  null;
			}

			return this.ProjectsData.ProjectByEmpRespons( empID , responseID);
		}

		#endregion 

		#region CompleteProject
		/// <summary>
		/// Complete project(Colse).
		/// </summary>
		/// <param name="projectDS">DataSet:Containing data of project</param>
		/// <returns>int:Returns 1 if success and 0 if failed</returns>
		public int CompleteProject ( DataSet projectDS )
		{
			
			int result = 0 ;
			Data.dsProjects dsPrj = new TSN.ERP.SharedComponents.Data.dsProjects();
			dsPrj.Merge( projectDS );


			if ( projectDS.Tables[ 0 ].Rows.Count != 0 )
			{
				if ( ! ( ProjectsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.ProjectRules.CompleteProject) , dsPrj.GEN_Projects[ 0 ].projectID.ToString() ) )  )
				{
					SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.ProjectRules.CompleteProject  );
					return  0;
				}

				// Get all project tasks
				Data.dsTasks dsTasks = new TSN.ERP.SharedComponents.Data.dsTasks();
				dsTasks.Merge( TaskMag.ViewProjectTasks( dsPrj.GEN_Projects[ 0 ].projectID ) );
						 
				// close all task assignmnets
				for ( int i = 0 ; i < dsTasks.GEN_Tasks.Rows.Count ; i++ )
					TaskMag.CompleteTasksInProject( dsTasks.GEN_Tasks[ i ].TaskID, "" );

				// close project
				dsPrj.GEN_Projects[ 0 ].ProjectStatus		= 0;
				dsPrj.GEN_Projects[ 0 ].ProjectCompleteDate = DateTime.Now;
				result = EditProjects( dsPrj );
			}
			return result;
	
		}
        public int CompleteProjectFromPDMS(string projectName)
        {
            DataSet dsProject = ProjectsData.List("ProjectName='" + projectName + "'");
            if (dsProject == null || dsProject.Tables.Count == 0)
            {
                return -1;
            }
            else
            {
                return CompleteProject(dsProject);
            }
            //DataSet dsProject = ProjectsData.List();
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
            //        Data.dsProjects dsProjects = new TSN.ERP.SharedComponents.Data.dsProjects();
            //        Data.dsProjects.GEN_ProjectsRow projectRow = dsProjects.GEN_Projects.NewGEN_ProjectsRow();
            //        int projectID = Convert.ToInt32(projectRows[0]["projectID"]);
            //        projectRow.projectID = projectID;
            //        projectRow.ProjectName = projectName;
            //        projectRow.ProjectOwner = ActiveSession.UserId;
            //        dsProjects.GEN_Projects.AddGEN_ProjectsRow(projectRow);
            //        dsProjects.AcceptChanges();
            //        CompleteProject(dsProjects);
            //        return 1;
            //    }
            //}

        }

		#endregion 

		#region ProjectEmployees
		/// <summary>
		/// List all employees for spacific project.
		/// </summary>
		/// <param name="ProjectID">int:Project ID</param>
		/// <returns>DataSet:Containing the data of employees</returns>
		public DataSet ProjectEmployees(int ProjectID)
		{
			
			if ( ! ( ProjectsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.ProjectRules.GetProjectEmployees  ) , ProjectID.ToString() ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.ProjectRules.GetProjectEmployees  );
				return  null;
			}
			return EmpData.GetProjectEmplyees(ProjectID);
		}

		#endregion 

		#region AddEmployeeToProject
		/// <summary>
		/// Add spacific employee to spacific project.
		/// </summary>
		/// <param name="ProjectID">int:Project ID</param>
		/// <param name="EmployeeID">int:Employee ID</param>
		/// <returns>int:Returns 1 if success and 0 if failed</returns>
		public int AddEmployeeToProject(int ProjectID, int EmployeeID)
		{
			
			if ( ! ( ProjectsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.ProjectRules.AddEmployeeToProject  ) , ProjectID.ToString() ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.ProjectRules.AddEmployeeToProject  );
				return  0;
			}
			Data.dsEmployeesXProjects dsTemp = new TSN.ERP.SharedComponents.Data.dsEmployeesXProjects();
			Data.dsEmployeesXProjects.GEN_EmployeesXProjectsRow TempRow = dsTemp.GEN_EmployeesXProjects.NewGEN_EmployeesXProjectsRow();
			TempRow.ContactID = EmployeeID;
			TempRow.projectID = ProjectID;
			dsTemp.GEN_EmployeesXProjects.AddGEN_EmployeesXProjectsRow(TempRow);
			return EmpXProjData.Add(dsTemp, false);
		}

		#endregion 

		#region RemoveEmployeeFromProject
		/// <summary>
		/// Remove spacific employee from spacific project.
		/// </summary>
		/// <param name="ProjecID">int:Projec ID</param>
		/// <param name="EmployeeID">int:Employee ID</param>
		/// <returns>int:Returns 1 if success and 0 if failed</returns>
		public int RemoveEmployeeFromProject(int ProjecID,int EmployeeID)
		{
			
			if ( ! ( ProjectsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.ProjectRules.RemoveEmployeeFromProject  ) , ProjecID.ToString() ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.ProjectRules.RemoveEmployeeFromProject  );
				return  0;
			}
			return EmpXProjData.Remove( EmployeeID , ProjecID );
		}

		#endregion 

		public DataSet ProjectsByParent(int parentID)
		{
			if ( ! ( ProjectsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListAllProjects ) )))
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.ProjectRules.ListProject  );
				return  null;
			}
			return this.ProjectsData.ProjectsByParent( parentID );
		}

		#region --- Projects levels ---

		#region ListProjectsLevels
		/// <summary>
		/// List all projects levels.
		/// </summary>
		/// <returns>DataSet:Containing the data of all projects levels</returns>
		public DataSet ListAllProjectsLevels()
		{
			if ( ! ( ProjectsData.ActiveSession.UserSecurityInfo.Administrator ))
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListAllProjects  );
				return  null;
			}

			return this.PrjLevelData.List();
		}
	
		
		#endregion 

		#region ListProject
		/// <summary>
		/// List a spacific project level.
		/// </summary>
		/// <param name="projLvlID">int:Project level ID</param>
		/// <returns>DataSet:Containing the data of this level</returns>
		public DataSet ListProjectLevel( int projLvlID )
		{
			if ( ! ( ProjectsData.ActiveSession.UserSecurityInfo.Administrator ))
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.ProjectRules.ListProject  );
				return  null;
			}

			return this.PrjLevelData.List( projLvlID );
		}

		#endregion 

		#region AddProjectLevels
		/// <summary>
		/// Add new project level.
		/// </summary>
		/// <param name="NewProjectsLevels">DataSet:Conatining data of new project level</param>
		/// <returns>int:Returns 1 if success and 0 if failed</returns>
		public int AddProjectLevel(DataSet NewProjectsLevels)
		{
			if ( ! ( ProjectsData.ActiveSession.UserSecurityInfo.Administrator ))
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.AddProject  );
				return  0;
			}

			return this.PrjLevelData.Add(NewProjectsLevels);
		}

		#endregion 

		#region EditProjectsLevels
		/// <summary>
		/// Edit projects levels.
		/// </summary>
		/// <param name="ModifiedProjectsLevels">DataSet:Conatining data which wanted to edit</param>
		/// <returns>int:Returns 1 if success and 0 if failed</returns>
		public int EditProjectsLevels(DataSet ModifiedProjectsLevels)
		{
			Data.dsProjectsLevels prj = new TSN.ERP.SharedComponents.Data.dsProjectsLevels();
			if ( ModifiedProjectsLevels != null &&  ModifiedProjectsLevels.Tables[ 0 ].Rows.Count != 0  )
			{
				if ( ! ( ProjectsData.ActiveSession.UserSecurityInfo.Administrator  ))
				{
					SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.ProjectRules.EditProject  );
					return  0;
				}
				return this.PrjLevelData.Edit(ModifiedProjectsLevels);
			}
			else
				return 0;
		}

		#endregion 

		#region DeleteProjectsLevels
		/// <summary>
		/// Delete projects levels.
		/// </summary>
		/// <param name="DeletedProjectsLevels">DataSet:Data of project level wanted to Deleted</param>
		/// <returns>int:Returns 1 if success and 0 if failed</returns>
		public int DeleteProjectsLevels(DataSet DeletedProjectsLevels)
		{
			Data.dsProjectsLevels prj = new TSN.ERP.SharedComponents.Data.dsProjectsLevels();
			if ( DeletedProjectsLevels != null &&  DeletedProjectsLevels.Tables[ 0 ].Rows.Count != 0  )
			{
				prj.Merge( DeletedProjectsLevels );

				if ( ! ( ProjectsData.ActiveSession.UserSecurityInfo.Administrator ))
				{
					SendAccessDeniedMessage( -1 );
					return  0;
				}
				return this.PrjLevelData.Delete(DeletedProjectsLevels);
			}
			else
				return 0;
		}

		#endregion 

		#endregion 
	}
}
