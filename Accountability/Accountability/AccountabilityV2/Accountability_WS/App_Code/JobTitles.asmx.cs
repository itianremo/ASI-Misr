using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using TSN.ERP.SharedComponents;
namespace SharedPresentation
{
	/// <summary>
	/// Summary description for JobTitles.
	/// </summary>
	public class JobTitles : TSN.ERP.Presentation.ERPMasterService 
	{
		private JobTitlesManager JTManager ;

		public JobTitles()
		{
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
			if (JTManager!=null)
				//JTManager.Dispose();
				JTManager=null;
			if(disposing && components != null)
			{
				//components.Dispose();
				components=null;
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		#region Jobtitles
		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public  DataSet ListJobtitles()
		{
			LoadJobtitlesManager();
			return JTManager.ListJobtitles();
		}

		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public  DataSet ListActiveJobtitles()
		{
			LoadJobtitlesManager();
			return JTManager.ListActiveJobtitles();
		}

		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public  DataSet ListClosedJobtitles()
		{
			LoadJobtitlesManager();
			return JTManager.ListClosedJobtitles();
		}

		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public  DataSet ListSingleJobTitle( int JobTitleID )
		{
			LoadJobtitlesManager();
			return JTManager.ListSingleJobtitle(JobTitleID);
		}

		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public  bool IsJobTitleActive( int JobTitleID )
		{
			LoadJobtitlesManager();
			return JTManager.IsJobTitleActive(JobTitleID);
		}

		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public int AddJobtitles(DataSet NewJobTitles)
		{
			LoadJobtitlesManager();
			return JTManager.AddJobtitles(NewJobTitles);
		}

		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public int EditJobtitle(DataSet ModifedJobTitles)
		{
			LoadJobtitlesManager();
			return JTManager.EditJobtitle(ModifedJobTitles);
		}

		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListJobtitlesbyCompnayElment(int CompanyElementID)
		{
			LoadJobtitlesManager();
			return JTManager.ListJobsByCoElement(CompanyElementID);
		}
		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public int DeleteJobtitle(DataSet DeletedJobtitle)
		{
			LoadJobtitlesManager();
			return JTManager.DeleteJobtitle(DeletedJobtitle);
		}
		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public int AddJobsToCompanyElement(DataSet JobTitles)
		{
			LoadJobtitlesManager();
			return JTManager.AddJobsToCompanyElement(JobTitles);
		}
		
		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public int RemoveJobsFromCompanyElement(DataSet JobTitles)
		{
			LoadJobtitlesManager();
			return JTManager.RemoveJobsFromCompanyElement(JobTitles);
		}

		[WebMethod (EnableSession = true , MessageName = "JobRemoveJobsFromCompanyElement"  ) , SoapHeader("Authenticator") ]
		
		public int RemoveJobsFromCompanyElement( int jobTitleID , int compElm )
		{
			LoadJobtitlesManager();
			return JTManager.RemoveJobsFromCompanyElement( jobTitleID , compElm  );
		}

		#endregion

		#region Reponsbilities
		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public int AddResponsbilities(DataSet NewResponsbilities)
		{
			LoadJobtitlesManager();
			return JTManager.AddResponsbilities(NewResponsbilities);
		}

		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public int EditResponsbilities(DataSet EditRespons)
		{
			LoadJobtitlesManager();
			return JTManager.EditResponsbilities(EditRespons);
		}

		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public int DeleteResponsbilities(DataSet DeletedRespons)
		{
			LoadJobtitlesManager();
			return JTManager.DeleteResponsbilities(DeletedRespons);
		}
		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListJobResponsbilities(int JobID)
		{
			LoadJobtitlesManager();
			return JTManager.ListJobResponsbilities(JobID);
		}
		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListActiveJobResponsbilities(int JobID)
		{
			LoadJobtitlesManager();
			return JTManager.ListActiveJobResponsbilities(JobID);
		}
		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListClosedJobResponsbilities(int JobID)
		{
			LoadJobtitlesManager();
			return JTManager.ListClosedJobResponsbilities(JobID);
		}
		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListResponsbilities()
		{
			LoadJobtitlesManager();
			return JTManager.ListResponsbilities();
		}

		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListSingleResponsbility( int ResponsibilityID )
		{
			LoadJobtitlesManager();
			return JTManager.ListSingleResponsibility(ResponsibilityID);
		}

		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public bool IsResponsibilityActive( int ResponsibilityID )
		{
			LoadJobtitlesManager();
			return JTManager.IsResponsibilityActive(ResponsibilityID);
		}


		#endregion
		
		//Responsbilities
		

		
		private void LoadJobtitlesManager()
		{
			//JTManager = (JobTitlesManager) GetInstance("TSN.ERP.SharedComponents.JobTitlesManager","TSN.ERP.SharedComponents");
			JTManager = new JobTitlesManager();
			JTManager.JoinSession(Token);
		}
	}
}
