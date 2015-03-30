using System;

namespace TSN.ERP.Engine
{
	/// <summary>
	/// Summary description for AtrERPMethodType.
	/// </summary>
	/// 

	public enum DBTables
	{
		GEN_AccDailyEntries,
		GEN_Address,
		GEN_Assignments,
		GEN_City,
		GEN_CompanyElmentLevels,
		GEN_CompanyElments,
		GEN_CompanyProfile,
		GEN_ContactNotes,
		GEN_Contacts,
		GEN_Country,
		GEN_Customers,
		GEN_Emails,
		GEN_Employees,
		GEN_Files,
		GEN_JobTitles,
		GEN_Modules,
		GEN_Notes,
		GEN_Phonebook,
		GEN_Projects,
		GEN_Responsibilities,
		GEN_State,
		GEN_Tasks,
		GEN_Teams,
		GEN_Vendors,
		GEN_Websites,
		SEC_Users,
		SEC_Entities,
		SEC_RuleEntity,
		SEC_RuleGroup,
		SEC_Rules,
		SEC_UsersGroups

	}


	public enum ERPMethodType
	{
		Add = 0,
		Edit = 1,
		List = 2,
		Delete = 3
	}
	
	public class AtrERPMethodType:Attribute 
	{
		private ERPMethodType _EMType = ERPMethodType.Add; 
		public string MethodArguments;
		public string MethodSchema;

		public AtrERPMethodType(ERPMethodType EMType, string Arguments, string ReturnSchema)
		{
			_EMType = EMType;
			MethodArguments = Arguments;
			MethodSchema = ReturnSchema;
		}
		public AtrERPMethodType(ERPMethodType EMType,string Arguments)
		{
			_EMType = EMType;
			MethodArguments = Arguments;
		}
		public AtrERPMethodType(ERPMethodType EMType)
		{
			_EMType = EMType;
		}
		public ERPMethodType CurrentERPMethodType
		{
			get
			{
				return _EMType;
			}
		}
	}
}
