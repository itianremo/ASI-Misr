using System;
using System.Data;
using TSN.ERP.Engine;
namespace TSN.ERP.SharedComponents
{
	/// <summary>
	/// This class manage teams in the system such as get all teams, add,delete,update teams 
	/// also to add employees or remove them from a team
	/// </summary>
	public class TeamsManager:BussinesObject 
	{
		Data.TeamsDataClass TeamData = new TSN.ERP.SharedComponents.Data.TeamsDataClass();
		Data.EmployeeXTeamDataClass EmployeeXTeamData = new TSN.ERP.SharedComponents.Data.EmployeeXTeamDataClass();
		Data.EmployeeData EmpData = new TSN.ERP.SharedComponents.Data.EmployeeData();

	
		public TeamsManager()
		{
			DataComponents.Add(EmployeeXTeamData);
			DataComponents.Add(TeamData);
			DataComponents.Add(EmpData);
		}

	
		#region AddTeams
		/// <summary>
		/// Add new teams
		/// </summary>
		/// <param name="newTeams">DataSet.(GEN_Teams):containing a set of teams</param>
		/// <returns>integer value:1 if succeeded to add and 0 if failed</returns>
		public int AddTeams(DataSet newTeams)
		{
			////
			if ( ! ( TeamData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.AddTeams  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.AddTeams );
				return  0;
			}
			return TeamData.Add(newTeams);
		}

		#endregion

		#region EditTeams
		/// <summary>
		/// Edit teams data
		/// </summary>
		/// <param name="editedTeams">DataSet.(GEN_Teams):containing a set of teams</param>
		/// <returns>integer value:1 if succeeded to edit and 0 if failed</returns>
		public int EditTeams(DataSet editedTeams)
		{
			//
			//
			if ( ! ( TeamData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.EditTeams  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.EditTeams );
				return  0;
			}
			return TeamData.Edit(editedTeams);
		}

		#endregion 

		#region DeleteTeams
		/// <summary>
		/// Delete teams from the system
		/// </summary>
		/// <param name="deleteTeams">DataSet.(GEN_Teams):containing a set of teams</param>
		/// <returns>integer value:1 if succeeded to delete and 0 if failed</returns>
		public int DeleteTeams(DataSet deleteTeams)
		{
			//
			if ( ! ( TeamData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.DeleteTeams  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.DeleteTeams );
				return  0;
			}
			return TeamData.Delete(deleteTeams);
		}

		#endregion 

		#region ListTeams
		/// <summary>
		/// List all teams in the system
		/// </summary>
		/// <returns>DataSet.(GEN_Teams):containing a set of teams</returns>
		[AtrERPMethodType(ERPMethodType.List)]
		public DataSet ListTeams()
		{
			//
			if ( ! ( TeamData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListTeams  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListTeams );
				return  null;
			}
			return TeamData.List();
		}

		#endregion 

		#region ListTeam
		/// <summary>
		/// List team detailed data
		/// </summary>
		/// <param name="TeamId">integer:team ID</param>
		/// <returns>DataSet.(GEN_Teams):containing team data</returns>
		[AtrERPMethodType(ERPMethodType.List , "GEN_Teams" )]
		public DataSet ListTeam(int TeamId)
		{
			//
			if ( ! ( TeamData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListTeam  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListTeam );
				return  null;
			}
			return TeamData.List(TeamId);
		}

		#endregion 

		#region ListTeamEmployees
		/// <summary>
		/// Get all the employees in a team
		/// </summary>
		/// <param name="TeamID">integer value:team ID</param>
		/// <returns>DataSet.(GEN_Employees):containing a set of employees</returns>
		[AtrERPMethodType(ERPMethodType.List , "GEN_Teams" ) ]
		public DataSet ListTeamEmployees(int TeamID)
		{
			//
			if ( ! ( TeamData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListTeamEmployees  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListTeamEmployees );
				return  null;
			}
			return EmpData.ListTeamEmployees(TeamID);
		}

		#endregion 

		#region AddEmployeeToTeam
		/// <summary>
		/// Add an employee to a team
		/// </summary>
		/// <param name="EmployeeID">int value for employee ID</param>
		/// <param name="TeamID">int value for team ID</param>
		/// <returns>int value,1 if succeeded to add and 0 if failed</returns>
		public int AddEmployeeToTeam(int EmployeeID, int TeamID)
		{
			//
			if ( ! ( TeamData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.AddEmployeeToTeam  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.AddEmployeeToTeam );
				return  0;
			}
			Data.dsEmployeeXTeams dsTemp = new TSN.ERP.SharedComponents.Data.dsEmployeeXTeams();
			Data.dsEmployeeXTeams.GEN_EmploeesXTeamsRow TempRow = dsTemp.GEN_EmploeesXTeams.NewGEN_EmploeesXTeamsRow();
			TempRow.ContactID =  EmployeeID;
			TempRow.TeamID = TeamID;
			dsTemp.GEN_EmploeesXTeams.AddGEN_EmploeesXTeamsRow(TempRow);
			return EmployeeXTeamData.Add(dsTemp,false);
		}

		#endregion

		#region RemoveEmployeeFromTeam
		/// <summary>
		/// Remove an employee from a team
		/// </summary>
		/// <param name="EmployeeID">integer value:employee ID</param>
		/// <param name="TeamID">integer value:team ID</param>
		/// <returns>integer value:1 if succeeded to remove and 0 if failed</returns>
		public int RemoveEmployeeFromTeam(int EmployeeID, int TeamID)
		{
			//
			if ( ! ( TeamData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.RemoveEmployeeFromTeam  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.RemoveEmployeeFromTeam );
				return  0;
			}
			return EmployeeXTeamData.Remove(TeamID, EmployeeID);
		}

		#endregion 
	}
}
