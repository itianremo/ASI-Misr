namespace TSN.ERP.Security.Rules

{

	#region ProjectRules

	public enum ProjectRules
	{  
		ViewTaskAssignment			= 1001,
		ViewProjectsDetatils		= 1002,
		AddTaskToProject			= 1003,
		EditProject					= 1004,
        ////AddProject                  = 1005,
        ////DeleteProject               = 1006,
		GetProjectEmployees			= 1007,
		ListProject					= 1008,
		CompleteProject				= 1009,
		AddEmployeeToProject		= 1010,
		RemoveEmployeeFromProject	= 1011,
		ViewProjectTasks			= 1012,
		ViewEmployeeAccountability	= 1013,
		ViewEmployeesDetailedData	= 1014,
		LoadAccountabilityEmployees	= 1015,
		UpdateAccountability		= 1016,
		ApproveAssignment			= 1017,
		RejectAssignment			= 1018,
		ReassignedAssignment		= 1019,
		CancelAssignment			= 1020,
		RequestToCloseAssignment	= 1021,
		SetOngoingAssignment		= 1022,
		CloseAssignment				= 1023,
		AssginTaskToProject			= 1024,
		DeleteAssignment			= 1025,
		ViewAssignmentData			= 1026,
		UpdateTask					= 1027,
		DeleteTask					= 1028,
		ViewTask					= 1029,
		CompleteTask				= 1030,
		SetAssignmentPiority		= 1031,
		SetAssignmentScore		    = 1032
		
		
   };

	#endregion

	#region CompanyElementRules

	public enum CompanyElementRules
	{  
		ViewCompanyElementAccountability  = 2001,
		ManageCompamyElement			  = 2002,
		ViewAssignmentData				  = 2003, 
		ViewTaskAssignments				  = 2004,
		ApproveAssignment				  = 2005,
		RejectAssignment				  = 2006,
		ReassignedAssignment			  = 2007,
		CancelAssignment				  = 2008,
		RequestToCloseAssignment		  = 2009,
		SetOngoingAssignment			  = 2010,
		CloseAssignment					  = 2011,
		LoadAccountabilityEmployees		  = 2012,
		UpdateAccountability			  = 2013,
		DeleteAssignment				  = 2014,
		AssginTask						  = 2015,
		SetAssignmentPiority			  = 2016,
		SetAssignmentScore				  = 2017,
		ViewTask						  = 2018,
		UpdateTask						  = 2019
	};
	
	#endregion 

	#region EmployeeRules

	public enum EmployeeRules
	{  
		ViewEmployeesDetailedData	=3001,
		ViewEmployeesContactData	=3002,
		AddTaskToEmployee			=3003,
		ListAssignment				=3004,
		ApproveAssignment			=3005,
		RejectAssignment			=3006,
		ReassignedAssignment		=3007,
		CancelAssignment			=3008,
		RequestToCloseAssignment	=3009,
		SetOngoingAssignment		=3010,
		CloseAssignment				=3011,
		AssginTask					=3012,
		UpdateAssignment			=3013,
		DeleteAssignment			=3014,
		ViewAssignmentData			=3015,
		ListEmployeesProjects		=3016,
		LoadAccountabilityEmployees	=3017,
		UpdateAccountability		=3018,
		SetAssignmentPiority		=3019,
		SetAssignmentScore		    =3020
	
	};

	#endregion

	#region TeamRules

	public enum TeamRules
	{  
		ViewEmployeesDetailedData	=4001,
		ViewEmployeesContactData	=4002,
		AddTaskToEmployee			=4003,
		ListAssignment				=4004,
		AddAssignmentTransaction	=4005,
		ApproveAssignment			=4006,
		RejectAssignment			=4007,
		ReassignedAssignment		=4008,
		CancelAssignment			=4009,
		RequestToCloseAssignment	=4010,
		SetOngoingAssignment		=4011,
		CloseAssignment				=4012,
		AssginTask					=4013,
		UpdateAssignment			=4014,
		DeleteAssignment			=4015,
		ViewAssignmentData			=4016,
		LoadAccountabilityEmployees	=4017,
		UpdateAccountability		=4018,
		SetAssignmentPiority		=4019,
		SetAssignmentScore		    =4020,
		ViewTask					=4021,
		UpdateTask					=4022
	
	};
	
	#endregion 

	#region GeneralRules

	public enum GeneralRules
	{  
		AddProject					=5001,
		AssginTask					=5002,
		AddNewEmployee				=5003,
		EditEmployee				=5004,
		DeleteEmployee				=5005,
		AddEmployeeResponsibility	=5006,
		ListAllProjects				=5007,
		ListActiveEmployees			=5008,
		ListTerminatedEmployees		=5009,
		TerminateEmployee			=5010,
		ListJobtitles				=5011,
		AddJobtitles				=5012,
		EditJobtitle				=5013,
		DeleteJobtitle				=5014,
		ListJobResponsbilities		=5015,
		ListJobsByCoElement			=5016,
		ListEmployeesDetailedData	=5017,
		AddResponsbilities			=5018,
		ListResponsbilities			=5019,
		DeleteResponsbilities		=5020,
		EditResponsbilities			=5021,
		ListAllEmployeeResponsibilities=5022,
		AddJobsToCompanyElement		=5023,
		RemoveJobsFromCompanyElement=5024,
		ListCompanyElmentsLevels	=5025,
		AddCompanyElmentsLevels		=5026,
		EditCompanyElmentsLevels	=5027,
		DeleteCompanyElmentsLevels	=5028,
		ListCompanyElments			=5029,
		AddChildCompanyElements		=5030,
		AddCompanyElments			=5031,
		EditCompanyElments			=5032,
		DeleteCompanyElments		=5033,
		ListChildrenElements		=5034,
		ListCompaniesProfiles		=5035,
		AddCompaniesProfilesData	=5036,
		EditCompaniesProfilesData	=5037,
		DeleteCompaniesProfilesData	=5038,
		ListAllContacts				=5039,
		ListConactData				=5040,
		AddContact					=5041,
		EditContact					=5042,
		LastContactsData			=5043,
		UpdateContactPhones			=5044,
		ListContactPhones			=5045,
		ListPrimayContactPhones		=5046,
		ListContactAddress			=5047,
		UpdateContactAddress		=5048,
		GetContactPrimaryAddress	=5049,
		ListAllCities				=5050,
		ListCity					=5051,
		UpdateCity					=5052,
		DeleteCity					=5053,
		ListAllStateCities			=5054,
		ListAllStates				=5055,
		ListState					=5056,
		UpdateState					=5057,
		DeleteState					=5058,
		ListAllCountryStates		=5059,
		ListAllCountries			=5060,
		ListCountry					=5061,
		UpdateCountry				=5062,
		DeleteCountry				=5063,
		ListAllEmails				=5064,
		UpdateEmail					=5065,
		DeleteEmail					=5066,
		ListAllCotactEmails			=5067,
		ListContactPrimaryEmail		=5068,
		ListAllWebSites				=5069,
		UpdateWebSite				=5070,
		DeleteWebSite				=5071,
		ListAllCotactWebSite		=5072,
		ListContactPrimaryWebSite	=5073,
		AddNote						=5074,
		ListAllNotes				=5075,
		ListNote					=5076,
		UpdateNote					=5077,
		DeleteNote					=5078,
		AddTasks					=5079,
		UpdateTask					=5080,
		DeleteTask					=5081,
		ViewAllTasks				=5082,
		ViewTask					=5083,
		ListAllAssignmentTransactions=5084,
		GetLastTasksStatus			=5085,
		CompleteTask				=5086,
		ViewAllAssignments			=5087,
		ViewTaskAssignments			=5088,
		ViewResponsibiltyAssignments=5089,
		ViewEmpAssignentsInProjectResponsibility=5090,
		AddTeams					=5091,
		EditTeams					=5092,
		DeleteTeams					=5093,
		ListTeams					=5094,
		ListTeam					=5095,
		ListTeamEmployees			=5096,
		AddEmployeeToTeam			=5097,
		RemoveEmployeeFromTeam		=5098,
		ViewProjectTasks			=5099,
		ViewAssignmentData			=5100,
		LoadAccountabilityEmployees	=5101,
		UpdateAccountability		=5102,
		ApproveAssignment			=5103,
		RejectAssignment			=5104,
		ReassignedAssignment		=5105,
		CancelAssignment			=5106,
		RequestToCloseAssignment	=5107,
		SetOngoingAssignment		=5108,
		CloseAssignment				=5109,
		DeleteAssignment			=5110,
		SetAssignmentPiority		=5111,
		SetAssignmentScore		    =5112,
		ViewFileInfo				=5113,
		ViewFileContent				=5114,
		ModifyFileInfo				=5115,
		ModifyFileContent			=5116,
		ViewOrgnizationChartInfo	=5117,
		ViewOrgnizationChartContent	=5118,
		ModifyOrgnizationChartInfo	=5119,
		ModifyOrgnizationChartContent=5120,
		AddDayOff					 =5121,
		AddReport = 5122,
		ListReports = 5123,
		DeleteReport = 5124,
		WorkFromHome=5125
	};
	
	#endregion 

}
