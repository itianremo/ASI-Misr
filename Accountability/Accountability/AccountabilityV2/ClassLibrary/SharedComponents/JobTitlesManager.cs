using System;
using System.Data;
using TSN.ERP.Engine;
namespace TSN.ERP.SharedComponents
{
	/// <summary>
	/// This class manage all job titles and all responsibilities in the system such as add,list, 
	///  update and delete jobs or responsibilities 
	/// </summary>
	public class JobTitlesManager:Engine.BussinesObject 
	{
		Data.JobtitlesData JobsData = new TSN.ERP.SharedComponents.Data.JobtitlesData();
		Data.ResponsblitiesData ResponsData = new TSN.ERP.SharedComponents.Data.ResponsblitiesData();
		Data.CoElmentsXJobtitlesData CoJobsData = new TSN.ERP.SharedComponents.Data.CoElmentsXJobtitlesData();

		//access code 5 
		enum AccessRights
		{
			ViewJobtitles = 5001, AddJobtitles = 5002, EditJobtitles = 5003
		}
		public JobTitlesManager()
		{
			// Adding to the data components
			DataComponents.Add(JobsData);
			DataComponents.Add(ResponsData);
			DataComponents.Add(CoJobsData);
			
		}
		
		
			// Jobtitles
			/// <summary>
			/// Get all job titles in the system
			/// </summary>
			/// <returns>DataSet.(GEN_JobTitles):containing a set of job titles</returns>
			[AtrERPMethodType(ERPMethodType.List)]
		public  DataSet ListJobtitles()
		{
			//
			if ( ! ( JobsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListJobtitles  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListJobtitles );
				return  null;
			}
			return this.JobsData.List();
		}

		public  DataSet ListActiveJobtitles()
		{
			//
			if ( ! ( JobsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListJobtitles  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListJobtitles );
				return  null;
			}
			return this.JobsData.ListActiveJobTitles();
		}

		public  DataSet ListClosedJobtitles()
		{
			//
			if ( ! ( JobsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListJobtitles  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListJobtitles );
				return  null;
			}
			return this.JobsData.ListClosedJobTitles();
		}

		public  DataSet ListSingleJobtitle(int JobTitleID)
		{
			//
			if ( ! ( JobsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListJobtitles  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListJobtitles );
				return  null;
			}
			return this.JobsData.ListSingleJobTitle(JobTitleID);
		}

		public  bool IsJobTitleActive(int JobTitleID)
		{
			//
			if ( ! ( JobsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListJobtitles  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListJobtitles );
				return  false;
			}
			return this.JobsData.IsJobTitleActive(JobTitleID);
		}

		/// <summary>
		/// Add new job titles
		/// </summary>
		/// <param name="NewJobTitles">DataSet.(GEN_JobTitles):containing a set of new job titles</param>
		/// <returns>integer value:1 if succeeded to add and 0 if failed</returns>
		public int AddJobtitles(DataSet NewJobTitles)
		{
			//
			if ( ! ( JobsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.AddJobtitles  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.AddJobtitles );
				return  0;
			}
			return this.JobsData.Add(NewJobTitles);
		}

		/// <summary>
		/// Edit on job title data
		/// </summary>
		/// <param name="editJobtitle">DataSet.(GEN_JobTitles):containing job title detailed data</param>
		/// <returns>integer value:1 if succeeded to edit and 0 if failed</returns>
		public int EditJobtitle(DataSet editJobtitle)
		{
			//
			if ( ! ( JobsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.EditJobtitle  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.EditJobtitle );
				return  0;
			}
			return this.JobsData.Edit(editJobtitle);
		}


		/// <summary>
		/// Delete job titles
		/// </summary>
		/// <param name="DeleteJobtitle">DataSet.(GEN_JobTitles):containing job title data</param>
		/// <returns>integer value:1 if succeeded to delete and 0 if failed</returns>
		public int DeleteJobtitle(DataSet DeleteJobtitle)
		{
			//
			if ( ! ( JobsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.DeleteJobtitle  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.DeleteJobtitle );
				return  0;
			}
			return this.JobsData.Delete(DeleteJobtitle);
		}


		/// <summary>
		/// Get all responsibilities for a job title 
		/// </summary>
		/// <param name="JobID">integer value:job ID</param>
		/// <returns>DataSet.(GEN_Responsibilities):containing a set of responsibilities</returns>
		[AtrERPMethodType(ERPMethodType.List , "GEN_JobTitles" )]
			
		public DataSet ListJobResponsbilities(int JobID)
		{
			//
			if ( ! ( ResponsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListJobResponsbilities  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListJobResponsbilities );
				return  null;
			}
			return this.ResponsData.ListResponsebyJob(JobID);
		}

		public DataSet ListActiveJobResponsbilities(int JobTitleID)
		{
			//
			if ( ! ( ResponsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListJobResponsbilities  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListJobResponsbilities );
				return  null;
			}
			return this.ResponsData.ListActiveResponsibilities(JobTitleID);
		}

		public DataSet ListClosedJobResponsbilities(int JobTitleID)
		{
			//
			if ( ! ( ResponsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListJobResponsbilities  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListJobResponsbilities );
				return  null;
			}
			return this.ResponsData.ListClosedResponsibilities(JobTitleID);
		}

		public DataSet ListSingleResponsibility(int ResponsibilityID)
		{
			//
			if ( ! ( ResponsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListJobResponsbilities  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListJobResponsbilities );
				return  null;
			}
			return this.ResponsData.ListSingleResponsibility(ResponsibilityID);
		}

		public bool IsResponsibilityActive(int ResponsibilityID)
		{
			//
			if ( ! ( ResponsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListJobResponsbilities  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListJobResponsbilities );
				return  false;
			}
			return this.ResponsData.IsResponsibilityActive(ResponsibilityID);
		}

		


		/// <summary>
		/// Get all job titles for a company element
		/// </summary>
		/// <param name="CoelementID">integer value:company element ID</param>
		/// <returns>DataSet.(GEN_JobTitles):containing a set of jobs</returns>
		[AtrERPMethodType(ERPMethodType.List , "GEN_CompanyElments" )]
		public DataSet ListJobsByCoElement(int CoelementID)
		{
			//
			if ( ! ( CoJobsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListJobsByCoElement  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListJobsByCoElement );
				return  null;
			}
			return this.CoJobsData.ListJobtitlesByCoElement(CoelementID);
		}



		//Responsbilities
		/// <summary>
		/// Add new responsibilities
		/// </summary>
		/// <param name="NewResponsbilities">DataSet.(GEN_Responsibilities):containing a set of responsibilities</param>
		/// <returns>integer value:1 if succeeded to add and 0 if failed</returns>
		public int AddResponsbilities(DataSet NewResponsbilities)
		{
			//
			if ( ! ( ResponsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.AddResponsbilities  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.AddResponsbilities );
				return  0;
			}
			return this.ResponsData.Add(NewResponsbilities);
		}



		/// <summary>
		/// Get all responsibilities in the system
		/// </summary>
		/// <returns>DataSet.(GEN_Responsibilities):containing a set of responsibilities</returns>
		[AtrERPMethodType(ERPMethodType.List)]
		public DataSet ListResponsbilities()
		{
			//
			if ( ! ( ResponsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListResponsbilities  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListResponsbilities );
				return  null;
			}
			return this.ResponsData.List();
		}



		/// <summary>
		/// Delete responsibilities
		/// </summary>
		/// <param name="DeletedRespons">DataSet.(GEN_Responsibilities):containing a set of responsibilities</param>
		/// <returns>integer value:1 if succeeded to delete and 0 if failed</returns>
		public int DeleteResponsbilities(DataSet DeletedRespons)
		{
			//
			if ( ! ( ResponsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.DeleteResponsbilities  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.DeleteResponsbilities );
				return  0;
			}
			return this.ResponsData.Delete(DeletedRespons);
		}



		/// <summary>
		/// Edit responsibilites data
		/// </summary>
		/// <param name="DeletedRespons">DataSet.(GEN_Responsibilities):containing a set of responsibilities</param>
		/// <returns>integer value:1 if succeeded to edit and 0 if failed</returns>
		public int EditResponsbilities(DataSet DeletedRespons)
		{
			//
			if ( ! ( ResponsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.EditResponsbilities  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.EditResponsbilities );
				return  0;
			}
			return this.ResponsData.Edit(DeletedRespons);
		}



		/// <summary>
		/// Get all responsibilities for an employee
		/// </summary>
		/// <param name="empID">integer value:employee ID</param>
		/// <returns>DataSet.(GEN_Responsibilities):containing a set of responsibilities</returns>
		[AtrERPMethodType(ERPMethodType.List , "GEN_Employees" )]
		public DataSet ListAllEmployeeResponsibilities( int empID )
		{
			//
			if ( ! ( ResponsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListAllEmployeeResponsibilities  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListAllEmployeeResponsibilities );
				return  null;
			}
			return ResponsData.ListEmployeeResponsibilities( empID );
		}



		// Job titles company elements
		/// <summary>
		/// Add new job titles to company elements
		/// </summary>
		/// <param name="JobTitles">DataSet.(GEN_JobTitles):containing a set of job titles</param>
		/// <returns>integer value:1 if succeeded to add and 0 if failed</returns>
		public int AddJobsToCompanyElement(DataSet JobTitles)
		{
			//
			if ( ! ( CoJobsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.AddJobsToCompanyElement  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.AddJobsToCompanyElement );
				return  0;
			}
			return CoJobsData.Add(JobTitles , false );
		}






		/// <summary>
		/// Remove job titles from company elements
		/// </summary>
		/// <param name="JobTitles">DataSet.(GEN_JobTitles):containing a set of job titles</param>
		/// <returns>integer value:1 if succeeded to remove and 0 if failed</returns>
		public int RemoveJobsFromCompanyElement(DataSet JobTitles)
		{
			//
			if ( ! ( CoJobsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.RemoveJobsFromCompanyElement  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.RemoveJobsFromCompanyElement );
				return  0;
			}
			return CoJobsData.Delete(JobTitles);
		}



		/// <summary>
		/// Remove a job title from a company element
		/// </summary>
		/// <param name="jobTitleID">integer value:job title ID</param>
		/// <param name="compElm">integer value:company element ID</param>
		/// <returns>integer value:1 if succeeded to remove and 0 if failed</returns>
		public int RemoveJobsFromCompanyElement( int jobTitleID , int compElm )
		{
			//
			if ( ! ( CoJobsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.RemoveJobsFromCompanyElement  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.RemoveJobsFromCompanyElement );
				return  0;
			}
			return CoJobsData.RemoveJobTitleFromCoElement( jobTitleID , compElm );
		}


	
	}
}
