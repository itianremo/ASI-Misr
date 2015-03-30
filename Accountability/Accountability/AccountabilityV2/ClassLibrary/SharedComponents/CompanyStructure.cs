using System;
using System.Data;
using TSN.ERP.Engine;
namespace TSN.ERP.SharedComponents
{
	/// <summary>
	/// Summary description for CompanyStructure.
	/// </summary>
	/// 

	public class CompanyStructure:Engine.BussinesObject 
	{
		Data.CompanElementsLevelsData  LevelsData = new TSN.ERP.SharedComponents.Data.CompanElementsLevelsData();
		Data.CompanyElmentsData ElementsData =new TSN.ERP.SharedComponents.Data.CompanyElmentsData();
		Data.CompaniesProfilesData CompaniesData = new TSN.ERP.SharedComponents.Data.CompaniesProfilesData();
		
		public  CompanyStructure()
		{
			this.DataComponents.Add(LevelsData);
			this.DataComponents.Add(ElementsData);
			this.DataComponents.Add(CompaniesData);
		}


		# region Company Structure Levels
		/// <summary>
		/// List all company elements levels
		/// </summary>
		/// <returns>Dataset:Returns data containing company elements to list</returns>
		[AtrERPMethodType(ERPMethodType.List)]
		public DataSet ListCompanyElmentsLevels()
		{
			//
			if ( ! ( LevelsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListCompanyElmentsLevels  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListCompanyElmentsLevels );
				return  null;
			}

			return this.LevelsData.List();
		}

		/// <summary>
		/// Adding new company elments levels
		/// </summary>
		/// <param name="CompanyElmentsLevels">DataSet:New data of company elments levels</param>
		/// <returns>int:Returns 1 if success and 0 if failed</returns>
		public int AddCompanyElmentsLevels(DataSet CompanyElmentsLevels)
		{
			//
			if ( ! ( LevelsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.AddCompanyElmentsLevels  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.AddCompanyElmentsLevels );
				return  0;
			}

			return this.LevelsData.Add(CompanyElmentsLevels);			
			
		}
		/// <summary>
		/// Edit company elments levels.
		/// </summary>
		/// <param name="CompanyElmentsLevels">DataSet:Containg data of company elments levels which want to editing</param>
		/// <returns>int:Returns 1 if success and 0 if failed</returns>
		public int EditCompanyElmentsLevels(DataSet CompanyElmentsLevels)
		{
			//
			if ( ! ( LevelsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.EditCompanyElmentsLevels  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.EditCompanyElmentsLevels );
				return  0;
			}

			return this.LevelsData.Edit(CompanyElmentsLevels);			
		}

		/// <summary>
		/// Delete company elments levels.
		/// </summary>
		/// <param name="CompanyElmentsLevels">DataSet:Containing data of company elments levels which want to deleting</param>
		/// <returns>int:Returns 1 if success and 0 if failed</returns>
		public int DeleteCompanyElmentsLevels(DataSet CompanyElmentsLevels)
		{
			//
			if ( ! ( LevelsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.DeleteCompanyElmentsLevels  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.DeleteCompanyElmentsLevels );
				return  0;
			}

			return this.LevelsData.Delete(CompanyElmentsLevels);			
		}
		#endregion

		# region Company Elements
		/// <summary>
		/// listing all company elements
		/// </summary>
		/// <returns>DataSet:Returns teh data of all company elements which in dadt base</returns>
		[AtrERPMethodType(ERPMethodType.List)]
		public DataSet ListCompanyElments()
		{
			//
			if ( ! ( LevelsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListCompanyElments  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListCompanyElments );
				return  null;
			}
			return this.ElementsData.List();
		}

		/// <summary>
		/// Add child company elements by send a temp dataset containing data of this child to AddCompanyElements
		/// </summary>
		/// <param name="ParentID">int:Parent ID(Element ID)</param>
		/// <param name="CompanyElmentsLevels">DataSet:Containing the data of company elments levels which want to add</param>
		/// <returns>int:Returns 1 if success and 0 if failed</returns>
		public int AddChildCompanyElements(int ParentID, DataSet CompanyElmentsLevels)
		{
			//
			if ( ! ( LevelsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.AddChildCompanyElements  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.AddChildCompanyElements );
				return  0;
			}

			Data.dsCompanyElements TempDataSet = new TSN.ERP.SharedComponents.Data.dsCompanyElements();
			TempDataSet.EnforceConstraints = false;
			TempDataSet.Merge(CompanyElmentsLevels);
			int count = TempDataSet.GEN_CompanyElments.Count;
			bool elmentExsist = ElementsData.CheckElmentExists(ParentID);
			if ( elmentExsist== false)
			{
				//ActiveSession.LastError  = new TSN.ERP.Engine.ERPError(0,"Parent Doesnot Exsist",0,null);
				return -1;
			}
			int ParentLevel = ElementsData.GetElementLevel(ParentID);
			int ChildLevel = LevelsData.NextLevel(ParentLevel);
			for(int i = 0 ; i < count; i++)
			{
				Data.dsCompanyElements.GEN_CompanyElmentsRow TempRow = TempDataSet.GEN_CompanyElments[i];
				if (TempRow.RowState == System.Data.DataRowState.Added)
				{
					TempRow.CEParent = ParentID;
					TempRow.CEL_ID = ChildLevel;
				}
			}
			return this.AddCompanyElments(TempDataSet);		
		}

		/// <summary>
		/// Add new company elments
		/// </summary>
		/// <param name="CompanyElmentsLevels">DataSet:Containing new data of company elments levels</param>
		/// <returns>int:Returns 1 if success and 0 if failed</returns>
		public int AddCompanyElments(DataSet CompanyElmentsLevels)
		{
			//
			if ( ! ( LevelsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.AddCompanyElments  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.AddCompanyElments );
				return  0;
			}

			Data.dsCompanyElements TempDataSet = new TSN.ERP.SharedComponents.Data.dsCompanyElements();
			TempDataSet.EnforceConstraints = false;
			TempDataSet.Merge(CompanyElmentsLevels);
			int count = TempDataSet.GEN_CompanyElments.Count;
			for(int i = 0 ; i < count; i++)
			{
				Data.dsCompanyElements.GEN_CompanyElmentsRow TempRow = TempDataSet.GEN_CompanyElments[i];
				if (!TempRow.IsCEParentNull())
				{
					bool CheckElmentExists = this.ElementsData.CheckElmentExists(TempRow.CEParent);
					if (!CheckElmentExists)
						throw new Exception("Parent Element doesnot exist");
				}
			}
			return this.ElementsData.Add(CompanyElmentsLevels);		
			
		}

		/// <summary>
		/// Can edit all company elments in data base.
		/// </summary>
		/// <param name="CompanyElmentsLevels">DataSet:Containing company elments levels which want to editing</param>
		/// <returns>int:Returns 1 if success and 0 if failed</returns>
		public int EditCompanyElments(DataSet CompanyElmentsLevels)
		{
			//
			if ( ! ( LevelsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.EditCompanyElments  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.EditCompanyElments );
				return  0;
			}
			
			Data.dsCompanyElements TempDataSet = new TSN.ERP.SharedComponents.Data.dsCompanyElements();
			TempDataSet.EnforceConstraints = false;
			TempDataSet.Merge(CompanyElmentsLevels);
			int count = TempDataSet.GEN_CompanyElments.Count;

			return this.ElementsData.Edit(CompanyElmentsLevels);			
			
		}

		/// <summary>
		/// Can delete any company elments in data base.
		/// </summary>
		/// <param name="CompanyElmentsLevels">DataSet:Containing company elments levels which want to delete</param>
		/// <returns>int:Returns 1 if success and 0 if failed</returns>
		public int DeleteCompanyElments(DataSet CompanyElmentsLevels)
		{
			//
			if ( ! ( LevelsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.DeleteCompanyElments  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.DeleteCompanyElments );
				return  0;
			}

			Data.dsCompanyElements TempDataSet = new TSN.ERP.SharedComponents.Data.dsCompanyElements();
			TempDataSet.EnforceConstraints = false;
			TempDataSet.Merge(CompanyElmentsLevels);
			int count = TempDataSet.GEN_CompanyElments.Count;
			TempDataSet.Reset();
			
			return this.ElementsData.Delete(CompanyElmentsLevels);		
			
		}

		/// <summary>
		/// list all children elements under spacific parent.
		/// </summary>
		/// <param name="ParentElementID">int:Parent element ID</param>
		/// <returns>DataSet:Returns data of the childern elements under spacific parent</returns>
		[AtrERPMethodType(ERPMethodType.List, "GEN_CompanyElments" )]
		public DataSet ListChildrenElements(int ParentElementID)
		{
			//
			if ( ! ( LevelsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListChildrenElements  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListChildrenElements );
				return  null;
			}

			return ElementsData.ListChildrenCompanyElements(ParentElementID);
		}
		#endregion
	
		# region Company Profiles
		/// <summary>
		/// List all companies profiles
		/// </summary>
		/// <returns>Dataset:Returns data of companies profiles</returns>
		[AtrERPMethodType(ERPMethodType.List)]
		public DataSet ListCompaniesProfiles()
		{
			//
			if ( ! ( LevelsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListCompaniesProfiles  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListCompaniesProfiles );
				return  null;
			}
			return this.CompaniesData.List();
		}		
		/// <summary>
		/// Adding new companies profiles to data company profiles.
		/// </summary>
		/// <param name="CompaniesProfilesData">DataSet:Containing new companies profiles data</param>
		/// <returns>int:Returns 1 if success and 0 if failed</returns>
		public int AddCompaniesProfilesData(DataSet CompaniesProfilesData)
		{
			//
			if ( ! ( LevelsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.AddCompaniesProfilesData  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.AddCompaniesProfilesData );
				return  0;
			}
			return this.CompaniesData.Add(CompaniesProfilesData);
			
		}	
		/// <summary>
		/// Can edit all companies profiles data which in data base.
		/// </summary>
		/// <param name="CompaniesProfilesData">DataSet:Containing companies profiles data which want to editing</param>
		/// <returns>int:Returns 1 if success and 0 if failed</returns>
		public int EditCompaniesProfilesData(DataSet CompaniesProfilesData)
		{
			//
			if ( ! ( LevelsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.EditCompaniesProfilesData  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.EditCompaniesProfilesData );
				return  0;
			}
			return this.CompaniesData.Edit(CompaniesProfilesData);
			
		}	
		/// <summary>
		/// Can delete all companies profiles data from data base.
		/// </summary>
		/// <param name="CompaniesProfilesData">DataSet:Containing companies profiles data which want to deleting</param>
		/// <returns>int:Returns 1 if success and 0 if failed</returns>
		public int DeleteCompaniesProfilesData(DataSet CompaniesProfilesData)
		{
			//
			if ( ! ( LevelsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.DeleteCompaniesProfilesData  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.DeleteCompaniesProfilesData );
				return  0;
			}
			return this.CompaniesData.Delete(CompaniesProfilesData);
		}
		#endregion
	}
}
