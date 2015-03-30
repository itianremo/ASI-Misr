using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using TSN.ERP.Presentation;
using TSN.ERP.Engine;
using TSN.ERP.SharedComponents;
namespace SharedPresentation
{
	/// <summary>
	/// Summary description for Service1.
	/// </summary>
	public class ProjectsService : ERPMasterService
	{
		protected TSN.ERP.SharedComponents.ProjectsManager projMang = new ProjectsManager();
		public ProjectsService()
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
			if (projMang != null)
				//projMang.Dispose();
				projMang=null;
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		#region ListProjects

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListAllProjects()
		{
			LoadProjectComponent();
			return this.projMang.ListAllProjects();
		}

		#endregion 


		#region ListProject

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListProject( int projID )
		{
			LoadProjectComponent();
			return this.projMang.ListProject( projID );
		}

		#endregion 
		
		#region AddProject

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int AddProject(DataSet NewProjects)
		{
			LoadProjectComponent();
			return this.projMang.AddProject(NewProjects);
		}

        [WebMethod(Description = "", EnableSession = true), SoapHeader("Authenticator")]
        public int AddProjectFromPDMS(string projectName)
        {
            try
            {

                // adde by Sayed 22/3/2010 to avoid doublicated recoreds
                DataView dv = ListAllProjects().Tables[0].DefaultView;
                DataRow[] dr = dv.Table.Select("ProjectName='" + projectName + "'"); 
                if(dr.Length>0)
                    return 0;
                             
                else
                {
                    LoadProjectComponent();
                    return this.projMang.AddProjectFromPDMS(projectName);
                }

                // end added
            }
            catch (Exception ex)
            {
                return -1;
            }
            
        }

		#endregion 

		#region EditProjects

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int EditProjects(DataSet ModifiedProjects)
		{
			LoadProjectComponent();
			return this.projMang.EditProjects(ModifiedProjects);
		}
		
		#endregion 

		#region DeleteProjects

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int DeleteProjects(DataSet DeletedProjects)
		{
			LoadProjectComponent();
			return this.projMang.DeleteProjects(DeletedProjects);
		}

		#endregion 

		#region ProjectSimpleList

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListProjectSimple()
		{
			LoadProjectComponent();
			return this.projMang.ProjectSimpleList();
		}

		#endregion 

		#region ListEmployeeProjects

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListEmployeeProjects(  )
		{
			LoadProjectComponent();
			//return this.projMang.ListEmployeeProjects( empID );ERPSession.UserId 2069
			return this.projMang.ListEmployeeProjects( ERPSession.ContactId   );
	
		}

		#endregion 

		#region ListProjectsByEmployeeResponsibilty

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListProjectsByEmployeeResponsibilty( int empID , int responseID )
		{
			LoadProjectComponent();
			return this.projMang.ListProjectsByEmployeeResponsibilty( empID , responseID);
		}

		#endregion 

		#region CompleteProject 
		
		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int CompleteProject ( DataSet projectDS )
		{
			LoadProjectComponent();
			return projMang.CompleteProject( projectDS );
	
		}

        [WebMethod(Description = "", EnableSession = true), SoapHeader("Authenticator")]
        public int CompleteProjectFromPDMS(string projectName)
        {
            try
            {
                LoadProjectComponent();
                return projMang.CompleteProjectFromPDMS(projectName);
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

		#endregion 

		#region ListProjectEmployees

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListProjectEmployees(int ProjectID)
		{
			LoadProjectComponent();
			return projMang.ProjectEmployees(ProjectID);
			
		}

		#endregion 

		#region AddEmployeeToProject

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int AddEmployeeToProject(int ProjectID, int EmployeeID)
		{
			LoadProjectComponent();
			return projMang.AddEmployeeToProject(ProjectID,EmployeeID);
		}

		#endregion 

		#region RemoveEmployeeFromProject

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int RemoveEmployeeFromProject(int ProjecID,int EmployeeID)
		{
			LoadProjectComponent();
			return projMang.RemoveEmployeeFromProject(ProjecID,EmployeeID);
		}

		#endregion 

		#region ListUserProjects
	
		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListUserProjects()
		{
			LoadProjectComponent();
			return projMang.ListUserProjects();
		}

		#endregion 

		#region ProjectsByParent
		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet GetProjectsByParent(int parentID)
		{
			LoadProjectComponent();
			return projMang.ProjectsByParent(parentID);
		}
		#endregion 


		#region --- Projects levels ---

		#region ListProjectsLevels
		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListAllProjectsLevels()
		{
			LoadProjectComponent();
			return projMang.ListAllProjectsLevels();
		}
	
		
		#endregion 
		
		#region ListProject Levels
		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListProjectLevel( int projLvlID )
		{
			LoadProjectComponent();
			return projMang.ListProjectLevel(projLvlID);
		}

		#endregion 

		#region AddProjectLevels
		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int AddProjectLevel(DataSet NewProjectsLevels)
		{
			LoadProjectComponent();
			return projMang.AddProjectLevel(NewProjectsLevels);
		}

		#endregion 

		#region EditProjectsLevels
		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int EditProjectsLevels(DataSet ModifiedProjectsLevels)
		{
			LoadProjectComponent();
			return projMang.EditProjectsLevels(ModifiedProjectsLevels);
		}

		#endregion 

		#region DeleteProjectsLevels
		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int DeleteProjectsLevels(DataSet DeletedProjectsLevels)
		{
			LoadProjectComponent();
			return projMang.DeleteProjectsLevels(DeletedProjectsLevels);
		}

		#endregion 

		#endregion 

		protected void LoadProjectComponent()
		{
			//projMang  = (ProjectsManager)this.GetInstance("TSN.ERP.SharedComponents.ProjectsManager","TSN.ERP.SharedComponents");
			projMang = new ProjectsManager();
			projMang.JoinSession(Token);
		}

		
	}
}
