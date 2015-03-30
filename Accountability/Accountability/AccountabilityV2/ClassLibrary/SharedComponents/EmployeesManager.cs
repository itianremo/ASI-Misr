using System;
using System.Data;
//using System.EnterpriseServices;
using TSN.ERP.Engine;
namespace TSN.ERP.SharedComponents
{
	/// <summary>
	///Manages Employees Data for the ERP System.
	/// </summary>
	/// 

	public class EmployeesManager:TSN.ERP.Engine.BussinesObject 
	{
		enum AccessRights
		{
			//AccesRightsCode 1
			ManageEmployeesData = 1010,ViewEmployeesListDetailed = 1020,ViewEmployeesList = 1030
		}

		#region Variables 

		private ContactsManager ContManger			= new ContactsManager();
		private Data.EmployeeData EmployeeData		= new TSN.ERP.SharedComponents.Data.EmployeeData();
		TSN.ERP.Engine.SecurityManager secMng  = new TSN.ERP.Engine.SecurityManager(); 
		private Data.CompanyElmentsData comElmData	= new TSN.ERP.SharedComponents.Data.CompanyElmentsData();
		private Data.TeamsDataClass teamData		= new TSN.ERP.SharedComponents.Data.TeamsDataClass();
		private Data.TasksDataClass taskData		= new TSN.ERP.SharedComponents.Data.TasksDataClass();
		private Data.AssignmentsDataClass assgData	= new TSN.ERP.SharedComponents.Data.AssignmentsDataClass();
		private Data.ProjectsData projData = new TSN.ERP.SharedComponents.Data.ProjectsData();
		private Data.EmployeeJobTitles empJobsData		= new TSN.ERP.SharedComponents.Data.EmployeeJobTitles();


		#endregion 

		public EmployeesManager()
		{
			DataComponents.Add(EmployeeData);
			DataComponents.Add(taskData);
			DataComponents.Add(assgData);
			DataComponents.Add(projData);
			DataComponents.Add(teamData);
			DataComponents.Add(comElmData);
			DataComponents.Add(empJobsData);

		}
		protected override void ObjectIntiated()
		{
			base.ObjectIntiated ();
			ContManger.JoinSession(ActiveSession.Token);
			secMng.JoinSession(ActiveSession.Token);
		}


		#region AddEmployee
		/// <summary>
		/// Add new employee,assing days off and add job title to this employee
		/// </summary>
		/// <param name="EmployeesData">DataSet:Containing new data of this employees</param>
		/// <returns>int:returns 1 if success and 0 if not</returns>
		public int AddEmployee(DataSet EmployeesData )
		{
			
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.AddNewEmployee  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.AddNewEmployee  );
				return  0;
			}

			// Add Employee
			int n = EmployeeData.Add(EmployeesData);
			Data.dsEmployee dsEmp = new TSN.ERP.SharedComponents.Data.dsEmployee();
			dsEmp.Merge( EmployeesData );

			// Assign days off to employees
			Data.dsTasks dsTsk = taskData.GetAllDaysOff();
			
			for ( int i = 0 ; i < dsEmp.GEN_Employees.Rows.Count ; i++ )
			{
				// Assign days off to employees
				for ( int j = 0 ; j < dsTsk.GEN_Tasks.Rows.Count ; j++ )
				{
					assgData.AssginTask( dsTsk.GEN_Tasks[ j ].TaskID , dsEmp.GEN_Employees[ i ].ContactID );
				}

				// add employee to employees user group if it has user account
				if(dsEmp.Tables[0].Rows[i]["UserID"] != null && dsEmp.Tables[0].Rows[i]["UserID"] != DBNull.Value)
				{
					int UserID = int.Parse(dsEmp.Tables[0].Rows[i]["UserID"].ToString());
					secMng.AddUserToGroup(1, UserID);
				}

				// add employee JobTitle
				AddEmployeeJobTitle(dsEmp.GEN_Employees[ i ].ContactID , dsEmp.GEN_Employees[ i ].JobTitleID , DateTime.Now );
			}
			
			


			return n;
		}

		#endregion

		#region DeleteEmployee
		/// <summary>
		/// Can delete any employee
		/// </summary>
		/// <param name="DeletedEmployees">DataSet:Containing data of employees which want to delete</param>
		/// <returns>int:returns 1 if success and 0 if not</returns>
		public int DeleteEmployee(DataSet DeletedEmployees)
		{
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.DeleteEmployee  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.DeleteEmployee  );
				return  0;
			}

			return EmployeeData.Delete(DeletedEmployees);
		}

		#endregion 

		#region EditEmployee
		/// <summary>
		/// Can edite any employee
		/// </summary>
		/// <param name="ModifedEmployees">DataSet:Containing data of employees which want to edit</param>
		/// <returns>int:returns 1 if success and 0 if not</returns>
		public int EditEmployee(DataSet ModifedEmployees)
		{
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.EditEmployee  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.EditEmployee  );
				return  0;
			}

			return EmployeeData.Edit(ModifedEmployees);
		}

		#endregion 

		#region ListEmployeesDetailedData
		/// <summary>
		/// Listing all employees details
		/// </summary>
		/// <returns>DataSet:Containing data of employees details</returns>
		[AtrERPMethodType(ERPMethodType.List)]
		public DataSet ListEmployeesDetailedData()
		{
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListEmployeesDetailedData  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListEmployeesDetailedData  );
				return  null;
			}
 
			return EmployeeData.List();
		}

		#endregion 

		#region ListEmployeesDetailedData
		/// <summary>
		/// List detailed data of spacific employee(using ID).
		/// </summary>
		/// <param name="EmployeeID">int:Employee ID which want to view his details data</param>
		/// <returns>Dataset:Containing data of wanted employee</returns>
		public DataSet ListEmployeesDetailedData(int EmployeeID)
		{
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListEmployeesDetailedData  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListEmployeesDetailedData  );
				return  null;
			}


			return  EmployeeData.EmployeeDetailedData(EmployeeID);
		}


		#endregion 

		#region ListEmployeesDetailedData
		/// <summary>
		/// List detailed data of spacific employee(using filter string).
		/// </summary>
		/// <param name="FilterString">string:Filter string to spacify a spacific employee</param>
		/// <returns>Dataset:Containing data of wanted employee</returns>
		[AtrERPMethodType(ERPMethodType.List)]
		public DataSet ListEmployeesDetailedData(string FilterString)
		{
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListEmployeesDetailedData  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListEmployeesDetailedData  );
				return  null;
			}


			return EmployeeData.List(FilterString);
		}

		#endregion 

		#region ListProjectEmployees
		/// <summary>
		/// List all employees for spacific project.
		/// </summary>
		/// <param name="projID">int:project ID which wanted to list all its employee</param>
		/// <returns>Dataset:Containing data of employees for the spacific project</returns>
		[AtrERPMethodType(ERPMethodType.List , "GEN_Projects" )]
		public DataSet ListProjectEmployees( int projID )
		{
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.ProjectRules.GetProjectEmployees  ) , projID.ToString() ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.ProjectRules.GetProjectEmployees   );
				return  null;
			}

			return  EmployeeData.GetProjectEmplyees( projID );
		}


		#endregion 

		#region ListActiveEmployees
		/// <summary>
		/// Listing all active emlpyees
		/// </summary>
		/// <returns>DataSet:Containing data of active emlpyees</returns>
		[AtrERPMethodType(ERPMethodType.List)]
		public DataSet ListActiveEmployees( )
		{
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListActiveEmployees  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListActiveEmployees );
				return  null;
			}

			return  EmployeeData.ListActiveEmployees( );
		}


		#endregion

		#region List Employee Summarized Data	
		[AtrERPMethodType(ERPMethodType.List)]
		public DataSet ListEmpSummData( int ContactID )
		{
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListEmployeesDetailedData  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListEmployeesDetailedData  );
				return  null;
			}


			return  EmployeeData.ListEmpSummData(ContactID);
		}


		#endregion

		#region ListTerminatedEmployees
		/// <summary>
		/// List all terminated employuees(like closed).
		/// </summary>
		/// <returns>DataSet:Containing data of terminated emlpyees</returns>
		[AtrERPMethodType(ERPMethodType.List)]
		public DataSet ListTerminatedEmployees( )
		{
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListTerminatedEmployees  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListTerminatedEmployees );
				return  null;
			}

			return  EmployeeData.ListActiveEmployees( );
		}

		#endregion 

		#region TerminateEmployee
		/// <summary>
		/// Terminate any employee.
		/// </summary>
		/// <param name="dsEmployees">DataSet:Containing data of employee which wanted to terminated</param>
		/// <returns>int:returns 1 if success and 0 if not</returns>
		public int TerminateEmployee( DataSet dsEmployees )
		{ 
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.TerminateEmployee  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.TerminateEmployee );
				return  0;
			}

			Data.dsEmployee dsEmp = new TSN.ERP.SharedComponents.Data.dsEmployee();
			dsEmp.Merge ( dsEmployees );
			dsEmp.GEN_Employees[ 0 ].EmployeeStatus = 0 ;

			return EmployeeData.Edit(dsEmp);
		}

		#endregion 

		#region GetEmployeesFromCoElement
		/// <summary>
		/// Spacific user under spacific rule view employees from the company element. 
		/// </summary>
		/// <param name="usrID">int:usr ID which he or she wants to view employees from company element</param>
		/// <param name="ruleID">int:rule ID for this user</param>
		/// <returns>Dataset:Cotaining data of employees</returns>
		public DataSet GetEmployeesFromCoElement( int usrID , int ruleID )
		{
			Data.dsEmployee empDS = new TSN.ERP.SharedComponents.Data.dsEmployee() ;

			// Get Get User Rule Entities
			TSN.ERP.Security.Data.DataSetRuleEntity ruleEnt =  new TSN.ERP.Security.Data.DataSetRuleEntity();
			ruleEnt.Merge(ActiveSession.GetUserRuleEntities(  ruleID ));
		
			for ( int i = 0 ; i < ruleEnt.SEC_RuleEntity.Rows.Count ; i++ )
			{
				if ( ruleEnt.SEC_RuleEntity[ i ].RuleEntityValue != null )
				{
					Data.dsEmployee empTempDS = new TSN.ERP.SharedComponents.Data.dsEmployee();
					// check if comElm exist
					DataSet comElmDS = comElmData.List( Convert.ToInt32 ( ruleEnt.SEC_RuleEntity[ i ].RuleEntityValue ) ); 

					// get comElm employees
					if ( comElmDS.Tables[ 0 ].Rows.Count != 0 ) 
						empTempDS.Merge ( EmployeeData.ListCoElmEmployees( Convert.ToInt32( ruleEnt.SEC_RuleEntity[ i ].RuleEntityValue ) ) );
					
					if (  empTempDS.GEN_Employees.Rows.Count != 0 )
						empDS.Merge ( empTempDS );
//					for ( int j = 0 ; j < empTempDS.GEN_Employees.Rows.Count ; j++ )
//					{
//						empDS.GEN_Employees .AddGEN_EmployeesRow( empTempDS.GEN_Employees[ j ] );
//					}
					
				}
			}
			return empDS ;
		}
		#endregion 

		#region GetEmployeesFromTeam
		/// <summary>
		/// Spacific user under spacific rule view employees from team.
		/// </summary>
		/// <param name="usrID">int:usr ID which he or she wants to view employees from company element</param>
		/// <param name="ruleID">int:rule ID for this user</param>
		/// <returns>Dataset:Cotaining data of employees</returns>
		public DataSet GetEmployeesFromTeam( int usrID , int ruleID )
		{
			Data.dsEmployee empDS = new TSN.ERP.SharedComponents.Data.dsEmployee() ;

			// Get Get User Rule Entities
			TSN.ERP.Security.Data.DataSetRuleEntity ruleEnt =  new TSN.ERP.Security.Data.DataSetRuleEntity();
			ruleEnt.Merge(ActiveSession.GetUserRuleEntities(  ruleID ));
		
		
			for ( int i = 0 ; i < ruleEnt.SEC_RuleEntity.Rows.Count ; i++ )
			{
				if ( ruleEnt.SEC_RuleEntity[ i ].RuleEntityValue != null )
				{
					Data.dsEmployee empTempDS = new TSN.ERP.SharedComponents.Data.dsEmployee();
					// check if team exist
					DataSet teamDS = teamData.List( Convert.ToInt32 ( ruleEnt.SEC_RuleEntity[ i ].RuleEntityValue ) ); 

					// get team employees
					if ( teamDS.Tables[ 0 ].Rows.Count != 0 ) 
						empTempDS.Merge ( EmployeeData.ListTeamEmployees( Convert.ToInt32( ruleEnt.SEC_RuleEntity[ i ].RuleEntityValue ) ) );
					
					if (  empTempDS.GEN_Employees.Rows.Count != 0 )
						empDS.Merge ( empTempDS );

//	 				for ( int j = 0 ; j < empTempDS.GEN_Employees.Rows.Count ; j++ )
//						empDS.GEN_Employees.AddGEN_EmployeesRow( empTempDS.GEN_Employees[ j ] );
					
				}
			}
			return empDS ;
		}
		public DataSet GetEmployeesFromProject( int usrID , int ruleID )
		{
			Data.dsEmployee empDS = new TSN.ERP.SharedComponents.Data.dsEmployee() ;

			// Get Get User Rule Entities
			TSN.ERP.Security.Data.DataSetRuleEntity ruleEnt =  new TSN.ERP.Security.Data.DataSetRuleEntity();
			ruleEnt.Merge(ActiveSession.GetUserRuleEntities(  ruleID ));
		
		
			for ( int i = 0 ; i < ruleEnt.SEC_RuleEntity.Rows.Count ; i++ )
			{
				if ( ruleEnt.SEC_RuleEntity[ i ].RuleEntityValue != null )
				{
					Data.dsEmployee empTempDS = new TSN.ERP.SharedComponents.Data.dsEmployee();
					// check if project exist
					DataSet projDs = projData.List( Convert.ToInt32 ( ruleEnt.SEC_RuleEntity[ i ].RuleEntityValue ) ); 

					// get Project employees
					if ( projDs.Tables[ 0 ].Rows.Count != 0 ) 
						empTempDS.Merge ( EmployeeData.GetProjectEmplyees( Convert.ToInt32( ruleEnt.SEC_RuleEntity[ i ].RuleEntityValue ) ) );
					
					
					if (  empTempDS.GEN_Employees.Rows.Count != 0 )
						empDS.Merge ( empTempDS );
					
				}
			}
			return empDS ;
		}
		public DataSet GetAccessedEmployees(int usrID , int ruleID )
		{
			Data.dsEmployee empDS = new TSN.ERP.SharedComponents.Data.dsEmployee() ;

			// Get Get User Rule Entities
			TSN.ERP.Security.Data.DataSetRuleEntity ruleEnt =  new TSN.ERP.Security.Data.DataSetRuleEntity();
			ruleEnt.Merge(ActiveSession.GetUserRuleEntities(  ruleID ));
		
		
			for ( int i = 0 ; i < ruleEnt.SEC_RuleEntity.Rows.Count ; i++ )
			{
				if ( ruleEnt.SEC_RuleEntity[ i ].RuleEntityValue != null )
				{
					Data.dsEmployee empTempDS = new TSN.ERP.SharedComponents.Data.dsEmployee();
					// check if project exist
					empTempDS.Merge(EmployeeData.List(Int32.Parse( ruleEnt.SEC_RuleEntity[ i ].RuleEntityValue)));
					if (  empTempDS.GEN_Employees.Rows.Count != 0 )
						empDS.Merge ( empTempDS );
					
				}
			}
			return empDS ;
		}
		#endregion 

		#region Employee Jobtitles
		/// <summary>
		/// Add spacific employee to spacific job title at spacific time
		/// </summary>
		/// <param name="EmployeeID">int:Employee ID which wanted to add to job title</param>
		/// <param name="JobTitleID">int:Job title ID which the employee add to it</param>
		/// <param name="JobDate">DateTime:Job Date</param>
		/// <returns>int:returns 1 if success and 0 if not</returns>		
		public int  AddEmployeeJobTitle( int EmployeeID, int JobTitleID , DateTime JobDate )
		{
			if ( ! ( empJobsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.EditEmployee  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.EditEmployee );
				return  0;
			}
			return empJobsData.AddEmployeeJobTitle( EmployeeID, JobTitleID , JobDate );
		}

		
		#endregion
	}
}
