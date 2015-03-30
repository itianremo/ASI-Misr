using System;
using System.Data;

namespace TSN.ERP.SharedComponents
{
	/// <summary>
	/// Summary description for CheckSecurity.
	/// </summary>
	public class CheckSecurity :Engine.BussinesObject 
	{
		
		Data.TasksDataClass tskData				= new TSN.ERP.SharedComponents.Data.TasksDataClass();
		Data.EmployeeXTeamDataClass empTeamData = new TSN.ERP.SharedComponents.Data.EmployeeXTeamDataClass();
		Data.EmployeeData empData				= new TSN.ERP.SharedComponents.Data.EmployeeData();
		Data.ProjectsData prjData				= new TSN.ERP.SharedComponents.Data.ProjectsData();

		
		public CheckSecurity()
		{
			DataComponents.Add(tskData);
			DataComponents.Add(empTeamData);
			DataComponents.Add(empData);
			DataComponents.Add(prjData);
		}


		//********* Tasks ***********
		
		#region HasTaskProjectAccessRule 
		public bool HasTaskProjectAccessRule ( DataSet dsTask , int ruleID )
		{
			//
			Data.dsTasks dsTemp = new TSN.ERP.SharedComponents.Data.dsTasks();
			dsTemp.Merge(dsTask);
			int rowCount = dsTemp.GEN_Tasks.Count;

			bool haveTaskProject = false;

			if ( rowCount != 0 )
			{
				if ( !( dsTemp.GEN_Tasks[ 0 ].IsprojectIDNull()) && CheckUserAccess( ruleID  , dsTemp.GEN_Tasks[ 0 ].projectID.ToString() ) )
					haveTaskProject = true;
			}

			return haveTaskProject;
		}


		#endregion 

		#region HasTaskGeneralAccessRule
		public bool HasTaskGeneralAccessRule( DataSet dsTask , int ruleID )
		{
			//
			Data.dsTasks dsTemp = new TSN.ERP.SharedComponents.Data.dsTasks();
			dsTemp.EnforceConstraints = false;
			dsTemp.Merge(dsTask);
			int rowCount = dsTemp.GEN_Tasks.Count;

			bool haveGeneralRule = false;
			
			if ( rowCount != 0 )
			{
				if ( dsTemp.GEN_Tasks[ 0 ].IsprojectIDNull() && CheckUserAccess( ruleID ) )
					haveGeneralRule = true;
			}

			return haveGeneralRule;
		}


		#endregion 
		
		#region IsTaskCreator
		public bool IsTaskCreator( DataSet dsTask )
		{
			//
			Data.dsTasks dsTemp = new TSN.ERP.SharedComponents.Data.dsTasks();
			dsTemp.Merge(dsTask);
			int rowCount = dsTemp.GEN_Tasks.Count;

			bool IsCreator	= false;

			if ( rowCount != 0 )
			{
				if ( dsTemp.GEN_Tasks[ 0 ].TaskCreatBy ==  ActiveSession.UserId )
					IsCreator = true;
			}
			return IsCreator;
		}


		#endregion

		#region IsTaskAssignedEmployee
		public bool IsTaskAssignedEmployee( DataSet dsTask )
		{
			//
			Data.dsTasks dsTemp = new TSN.ERP.SharedComponents.Data.dsTasks();
			dsTemp.Merge(dsTask);
			int rowCount = dsTemp.GEN_Tasks.Count;

			bool IsAssignedEmp	 = false;
			
			
			if ( rowCount != 0 )
			{
				DataSet empDs = empData.ListTaskEmployees( dsTemp.GEN_Tasks[ 0 ].TaskID );
				for ( int i = 0 ; i < empDs.Tables[ "GEN_Employees" ].Rows.Count ; i++ )
				{
					if ( Convert.ToInt32( empDs.Tables[ "GEN_Employees" ].Rows[ i ][ "ContactID" ] ) == ActiveSession.ContactId )
					{
						IsAssignedEmp = true;
						break;
					}
				}
			}
			return IsAssignedEmp;
		}
			

		#endregion 

		//********* General ***********

		#region HasAccessRule

		public bool HasAccessRule( int ruleID )
		{
			//
			bool haveGeneralRule = false;
			
			if ( CheckUserAccess( ruleID ) )
				haveGeneralRule = true;
		
			return haveGeneralRule;
		}


		#endregion 

		#region HasAccessRule

		public bool HasAccessRule( int ruleID , string entityID )
		{
			//
			bool haveGeneralRule = false;
			
			if ( CheckUserAccess( ruleID , entityID ) )
				haveGeneralRule = true;
		
			return haveGeneralRule;
		}


		#endregion 

		//********** Assignments ************

		#region HasProjectAssignmentAccess
		public bool HasProjectAssignmentAccess( DataSet dsAss , int ruleID )
		{
			Data.dsAssignments dsTemp = new TSN.ERP.SharedComponents.Data.dsAssignments();
			dsTemp.Merge( dsAss );
			
			DataSet dsTask = tskData.List( dsTemp.GEN_Assignments[ 0 ].TaskID );

			if ( CheckUserAccess( ruleID , dsTask.Tables[ "GEN_Tasks" ].Rows[ 0 ][ "projectID" ].ToString()  ) )
				return  true;
		
			return false;
		}


		#endregion 

		#region HasTeamAssignmentAccess

		public bool HasTeamAssignmentAccess( DataSet  dsAss , int ruleID )
		{
			//
			Data.dsAssignments dsTemp = new TSN.ERP.SharedComponents.Data.dsAssignments();
			dsTemp.Merge( dsAss );

			DataSet dsTeam = empTeamData.ListEmployeeTeams( dsTemp.GEN_Assignments[ 0 ].ContactID );
			
			for ( int i = 0 ; i < dsTeam.Tables[ 0 ].Rows.Count ; i++ )
			{
				if ( CheckUserAccess( ruleID , dsTeam.Tables[ "GEN_EmploeesXTeams" ].Rows[ 0 ][ "TeamID" ].ToString()  ) )
					return  true;
			
			}
		
			return false;
		}

		public bool HasTeamAssignmentAccess( int empID , int ruleID )
		{
			//
			DataSet dsTeam = empTeamData.ListEmployeeTeams( empID );
			
			for ( int i = 0 ; i < dsTeam.Tables[ 0 ].Rows.Count ; i++ )
			{
				if ( CheckUserAccess( ruleID , dsTeam.Tables[ "GEN_EmploeesXTeams" ].Rows[ i ][ "TeamID" ].ToString() ))
					return  true;
			}
		
			return false;
		}


		#endregion 

		#region HasCompanyElementAssignmentAccess
		public bool HasCompanyElementAssignmentAccess( DataSet  dsAss , int ruleID )
		{
			Data.dsAssignments dsTemp = new TSN.ERP.SharedComponents.Data.dsAssignments();
			dsTemp.Merge( dsAss );

			DataSet dsEmp =  empData.List( dsTemp.GEN_Assignments[ 0 ].ContactID );
			
			if ( CheckUserAccess( ruleID , dsEmp.Tables[ "GEN_Employees" ].Rows[ 0 ][ "CompElmentID" ].ToString() ) )
				return  true;
			else
				return  false;
		}


		public bool HasCompanyElementAddAssignmentAccess( int empID , int ruleID )
		{
			
			DataSet dsEmp =  empData.List( empID );
			
			if ( CheckUserAccess( ruleID , dsEmp.Tables[ "GEN_Employees" ].Rows[ 0 ][ "CompElmentID" ].ToString() ) )
				return  true;
			else
				return  false;
		}


		#endregion 

		#region HasEmployeeAssignmentAccess

		public bool HasEmployeeAssignmentAccess( DataSet  dsAss , int ruleID )
		{
			//
			Data.dsAssignments dsTemp = new TSN.ERP.SharedComponents.Data.dsAssignments();
			dsTemp.Merge( dsAss );

			if ( CheckUserAccess( ruleID , dsTemp.GEN_Assignments[ 0 ].ContactID.ToString()  ) )
				return  true;
		
			return false;
		}

		public bool HasEmployeeAssignmentAccess( int empID , int ruleID )
		{
			
			if ( CheckUserAccess( ruleID , empID.ToString() ))
				return  true;
			
			return false;
		}


		#endregion 

		#region HasAssignedToAccess

		public bool HasAssignedToAccess( DataSet  dsAss , int ruleID )
		{
			Data.dsAssignments dsTemp = new TSN.ERP.SharedComponents.Data.dsAssignments();
			dsTemp.Merge( dsAss );

			if ( ( dsTemp.GEN_Assignments[ 0 ].ContactID == ActiveSession.ContactId ) && CheckUserAccess( ruleID , dsTemp.GEN_Assignments[ 0 ].ContactID.ToString() ) )
				return  true;
			else
				return  false;
		}

		public bool HasAssignedToAccess( int empID , int ruleID )
		{
			//
			if ( ( empID == ActiveSession.ContactId ) && CheckUserAccess( ruleID , empID.ToString() ) )
				return  true;
			else
				return  false;
		}


		#endregion 

		#region HasCreatorAssignmentAccess

		public bool HasCreatorAssignmentAccess( DataSet  dsAss , int ruleID )
		{
				//
			Data.dsAssignments dsTemp = new TSN.ERP.SharedComponents.Data.dsAssignments();
			dsTemp.Merge( dsAss );

			if ( ( dsTemp.GEN_Assignments[ 0 ].AssginedBy == ActiveSession.ContactId ) && CheckUserAccess( ruleID , dsTemp.GEN_Assignments[ 0 ].AssginedBy.ToString() ) )
				return  true;
			else
				return  false;
		}


		#endregion 

		//*********** Accountability  ************

		#region HasLoadAccountabiltiyAccess

		public bool HasLoadAccountabiltiyAccess( int empID )
		{
			//
			// LoadAccountabilityEmployees;
			// UpdateAccountability;

			bool checkEmployee   = false;
			bool checkTeam		 = false;
			bool checkProject	 = false;
			bool checkCompElemnt = false;
			bool checkGeneralAccess = false;
			
			// check Company Elemnet 
			DataSet dsTemp1 = empData.List( empID );
			Data.dsEmployee dsEmp = new TSN.ERP.SharedComponents.Data.dsEmployee();
			dsEmp.Merge( dsTemp1 );

			if (dsEmp.GEN_Employees.Count < 1)
				return false;

			// check Employee
			if ( ( empID == ActiveSession.ContactId ) || CheckUserAccess( (int) TSN.ERP.Security.Rules.EmployeeRules.LoadAccountabilityEmployees , empID.ToString() ) )
				checkEmployee =  true;

			// check Team
			DataSet dsTeam = empTeamData.ListEmployeeTeams( empID );
			int rowCount = dsTeam.Tables[ "GEN_EmploeesXTeams" ].Rows.Count;
			
			for (int i = 0; i< rowCount;i++)
			{
				if ( CheckUserAccess( (int) TSN.ERP.Security.Rules.TeamRules.LoadAccountabilityEmployees , dsTeam.Tables[ "GEN_EmploeesXTeams" ].Rows[ i ][ "TeamID" ].ToString() ) )
				{
					checkTeam =  true;
					break;
				}
			}

			// check Project
			DataSet dsTemp  = prjData.ProjectsByEmployee( empID );
			Data.dsProjects dsPrj =  new TSN.ERP.SharedComponents.Data.dsProjects();
			dsPrj.Merge( dsTemp );

			for ( int i = 0 ; i < dsPrj.Tables[ 0 ].Rows.Count ; i++ )
			{
				if ( CheckUserAccess( (int) TSN.ERP.Security.Rules.ProjectRules.LoadAccountabilityEmployees , dsPrj.GEN_Projects[i].projectID.ToString() ) )
				{
					checkProject = true;
					break;
				}
			}

			
			if ( CheckUserAccess( (int) TSN.ERP.Security.Rules.CompanyElementRules.LoadAccountabilityEmployees , dsEmp.GEN_Employees[ 0 ].CompElmentID.ToString() ) )
				checkCompElemnt = true;


			checkGeneralAccess =  HasAccessRule( (int) TSN.ERP.Security.Rules.GeneralRules.LoadAccountabilityEmployees );
			
			
			if (  ActiveSession.UserSecurityInfo.Administrator || checkEmployee || checkTeam || checkProject || checkCompElemnt || checkGeneralAccess)
				return true;

			return false;

		}
	

		#endregion 

		#region HasUpdateAccountabiltiyAccess

		public bool HasUpdateAccountabiltiyAccess( int empID )
		{
			//
			bool checkEmployee   = false;
			bool checkTeam		 = false;
			bool checkProject	 = false;
			bool checkCompElemnt = false;
			
			// Check Adminstrator
			if (ActiveSession.UserSecurityInfo.Administrator )
				return true;

			// check Employee
			if ( ( empID == ActiveSession.ContactId ) && CheckUserAccess( (int)TSN.ERP.Security.Rules.EmployeeRules.UpdateAccountability , empID.ToString() ) )
				checkEmployee =  true;

			// check Team
			DataSet dsTeam = empTeamData.ListEmployeeTeams( empID );
			int teamsCount = dsTeam.Tables[ "GEN_EmploeesXTeams" ].Rows.Count;
			for (int i = 0;i <teamsCount;i++)
			{
				if ( CheckUserAccess( (int)TSN.ERP.Security.Rules.TeamRules.UpdateAccountability , dsTeam.Tables[ "GEN_EmploeesXTeams" ].Rows[ 0 ][ "TeamID" ].ToString() ) )
				{
					checkTeam =  true;
					break;
				}
				
			}

			// check Project
			DataSet dsTemp  = prjData.ProjectsByEmployee( empID );
			Data.dsProjects dsPrj =  new TSN.ERP.SharedComponents.Data.dsProjects();
			dsPrj.Merge( dsTemp );

			for ( int i = 0 ; i < dsPrj.Tables[ 0 ].Rows.Count ; i++ )
			{
				if ( CheckUserAccess( (int) TSN.ERP.Security.Rules.ProjectRules.UpdateAccountability , dsPrj.GEN_Projects[ i ].projectID.ToString() ) )
				{
					checkProject = true;
					break;
				}
			}

			// check Company Elemnet 
			DataSet dsTemp1 = empData.List( empID );
			Data.dsEmployee dsEmp = new TSN.ERP.SharedComponents.Data.dsEmployee();
			dsEmp.Merge( dsTemp1 );

			if ( CheckUserAccess( (int)TSN.ERP.Security.Rules.CompanyElementRules.UpdateAccountability , dsEmp.GEN_Employees[ 0 ].CompElmentID.ToString() ) )
				checkCompElemnt = true;
			
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkEmployee || checkTeam || checkProject || checkCompElemnt || HasAccessRule( (int)TSN.ERP.Security.Rules.GeneralRules.UpdateAccountability )))
				return false;	

			return true;
		}


		#endregion 
		
	}
}
			


