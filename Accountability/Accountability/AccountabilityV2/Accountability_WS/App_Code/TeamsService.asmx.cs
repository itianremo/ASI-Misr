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
using TSN.ERP.Engine;
namespace SharedPresentation
{
	/// <summary>
	/// Summary description for TeamsService.
	/// </summary>
	public class TeamsService : ERPMasterService
	{
		private TeamsManager TeamMgr;
		public TeamsService()
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
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if (TeamMgr != null)
				//TeamMgr.Dispose();
				TeamMgr=null;
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		#region AddTeams

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int AddTeams(DataSet newTeams)
		{
			LoadTeamManager();
			return TeamMgr.AddTeams(newTeams);
		}

		#endregion

		#region EditTeams

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int EditTeams(DataSet editedTeams)
		{
			LoadTeamManager();
			return TeamMgr.EditTeams(editedTeams);
		}

		#endregion 

		#region DeleteTeams

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int DeleteTeams(DataSet deleteTeams)
		{
			LoadTeamManager();
			return TeamMgr.DeleteTeams(deleteTeams);
		}

		#endregion 

		#region ListTeams

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListTeams()
		{
			LoadTeamManager();
			return TeamMgr.ListTeams();
		}

		#endregion 

		#region ListTeam

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListTeam(int TeamId)
		{
			LoadTeamManager();
			return TeamMgr.ListTeam(TeamId);
		}

		#endregion 

		#region ListTeamEmployees

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListTeamEmployees(int TeamID)
		{
			LoadTeamManager();
			return TeamMgr.ListTeamEmployees(TeamID);
		}

		#endregion 

		#region AddEmployeeToTeam

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int AddEmployeeToTeam(int EmployeeID, int TeamID)
		{
			LoadTeamManager();
			return TeamMgr.AddEmployeeToTeam(EmployeeID,TeamID);
		}

		#endregion

		#region RemoveEmployeeFromTeam

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int RemoveEmployeeFromTeam(int EmployeeID, int TeamID)
		{
			LoadTeamManager();
			return TeamMgr.RemoveEmployeeFromTeam(EmployeeID,TeamID);
		}

		#endregion 


		private void LoadTeamManager()
		{
			//TeamMgr = (TeamsManager)GetInstance("TSN.ERP.SharedComponents.TeamsManager","TSN.ERP.SharedComponents");  
			TeamMgr = new TeamsManager();
			TeamMgr.JoinSession(Token);
		}
	}
}
