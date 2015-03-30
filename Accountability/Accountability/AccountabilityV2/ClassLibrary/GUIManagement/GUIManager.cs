using System;
using System.Data;

namespace TSN.ERP.GUIManagement
{
	/// <summary>
	/// This class deals with modules, links and functionalities
	/// A module:is like the whole Accountability
	/// A link: is like Projects,Employees,Job Titles,....
	/// A functionality: which lies under a certain link; like employees and teams under the link "Employees" 
	/// </summary>
	public class GUIManager:TSN.ERP.Engine.BussinesObject
	{
		Data.ModulesData moduleData = new TSN.ERP.GUIManagement.Data.ModulesData();
		Data.LinksData linkData = new TSN.ERP.GUIManagement.Data.LinksData();
		Data.FunctionalitiesData functionData = new TSN.ERP.GUIManagement.Data.FunctionalitiesData();
		
		public GUIManager()
		{
			
			this.DataComponents.Add(moduleData);
			this.DataComponents.Add(linkData);
			this.DataComponents.Add(functionData);
		}


		#region Modules

		#region AddModule 
		/// <summary>
		/// Add new modules 
		/// </summary>
		/// <param name="ds">DataSet:containing a set of modules</param>
		/// <returns>integer value:1 if succeeded to add and -1 if failed</returns>
		public int AddModule ( System.Data.DataSet ds )
		{
			////System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			if ( ActiveSession.UserSecurityInfo.Administrator )
			{
			   if (	moduleData.Add( ds ) == 1 )
				   return 1 ;
				else
				   return -1 ;
			}
			else 
				return -1 ;

		}


		#endregion 

		#region UpdateModule 
		/// <summary>
		/// Update module
		/// </summary>
		/// <param name="ds">DataSet:containing a set of modules</param>
		/// <returns>integer value:1 if succeeded to update and -1 if failed</returns>
		public int UpdateModule ( System.Data.DataSet ds )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			if ( ActiveSession.UserSecurityInfo.Administrator )
			{
				if (	moduleData.Edit( ds ) == 1 )
					return 1 ;
				else
					return -1 ;
			}
			else 
				return -1 ;

		}


		#endregion 

		#region DeleteModule 
		/// <summary>
		/// Delete module
		/// </summary>
		/// <param name="ds">DataSet:containing a set of modules</param>
		/// <returns>integer value:1 if succeeded to delete and -1 if failed</returns>
		public int DeleteModule ( System.Data.DataSet ds )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			if ( ActiveSession.UserSecurityInfo.Administrator )
			{
				if (	moduleData.Delete( ds ) == 1 )
					return 1 ;
				else
					return -1 ;
			}
			else 
				return -1 ;

		}


		#endregion 

		#region ViewModules 
		/// <summary>
		/// Get all modules
		/// </summary>
		/// <returns>DataSet:containing a set of modules</returns>
		public DataSet ViewModules (  )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			return moduleData.List(); 
		}
		
		#endregion 

		#region ViewUserModules
		/// <summary>
		/// Get all user modules 
		/// </summary>
		/// <param name="usrID">integer value:user ID</param>
		/// <returns>DataSet:containing a set of modules</returns>
		public DataSet ViewUserModules( int usrID )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSet ds = new DataSet();
			
			if ( ActiveSession.UserSecurityInfo.Administrator )
				ds = ViewModules();
			else
			{
				moduleData.oleDbDataAdapterUserModules.SelectCommand.Parameters[ "UserID" ].Value = usrID ;
				moduleData.oleDbDataAdapterUserModules.Fill( ds );
			}
			
			return ds;
		}
			

	
		#endregion 

		#region ViewModuleUserGroups
		/// <summary>
		/// Get module user groups
		/// </summary>
		/// <param name="modID">integer value:module ID</param>
		/// <returns>DataSet:containing a set of user groups</returns>
		public DataSet ViewModuleUserGroups( int modID )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSet ds = new DataSet();
			
			moduleData.oleDbDataAdapterModuleUserGroups.SelectCommand.Parameters[ "ModID" ].Value = modID ;
			moduleData.oleDbDataAdapterModuleUserGroups.Fill( ds );
			
			return ds;
		}
		
	
		#endregion 

		#region ViewModuleRuleGroups
		/// <summary>
		/// Get module rule groups
		/// </summary>
		/// <param name="modID">integer value:module ID</param>
		/// <returns>DataSet:containing a set of rule groups</returns>

		public DataSet ViewModuleRuleGroups( int modID )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSet ds = new DataSet();
			
			moduleData.oleDbDataAdapterModuleRulesGroups.SelectCommand.Parameters[ "ModID" ].Value = modID ;
			moduleData.oleDbDataAdapterModuleRulesGroups.Fill( ds );
			
			return ds;
		}
			
		
		#endregion 

		#region ViewRulesGroupsOfUserGroupInModule
		/// <summary>
		/// Get rule groups for a specific user group and module
		/// </summary>
		/// <param name="modID">integer value:module ID</param>
		/// <param name="userGroupID">integer value:user group ID</param>
		/// <returns>DataSet:containing a set of rule groups</returns>
		public DataSet ViewRulesGroupsOfUserGroupInModule( int modID , int userGroupID )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSet ds = new DataSet();
			
			moduleData.oleDbDataAdapterRuleGroupsOfUserGroupInModule.SelectCommand.Parameters[ "ModID" ].Value = modID ;
			moduleData.oleDbDataAdapterRuleGroupsOfUserGroupInModule.SelectCommand.Parameters[ "UserGroupID" ].Value = userGroupID ;
			moduleData.oleDbDataAdapterRuleGroupsOfUserGroupInModule.Fill( ds );
			
			return ds;
		}
			

	
		#endregion 

		#region ViewUsersGroupsOfRuleGroupInModule
		/// <summary>
		/// Get user groups for a specific rule group and module
		/// </summary>
		/// <param name="modID">integer value:module ID</param>
		/// <param name="ruleGroupID">integer value:rule group ID</param>
		/// <returns>DataSet:containing a set of user groups</returns>
		public DataSet ViewUsersGroupsOfRuleGroupInModule( int modID , int ruleGroupID )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSet ds = new DataSet();
			
			moduleData.oleDbDataAdapterUserGroupsOfRuleGroupInModule.SelectCommand.Parameters[ "ModID" ].Value = modID ;
			moduleData.oleDbDataAdapterUserGroupsOfRuleGroupInModule.SelectCommand.Parameters[ "RuleGroupID" ].Value = ruleGroupID ;
			moduleData.oleDbDataAdapterUserGroupsOfRuleGroupInModule.Fill( ds );
			
			return ds;
		}
			

	
		#endregion 

		#endregion 

		#region Links
		
		#region AddLinks
		/// <summary>
		/// Add new links
		/// </summary>
		/// <param name="ds">DataSet:containing a set of links</param>
		/// <returns>integer value:1 if succeeded to add and -1 if failed</returns>
		public int AddLinks ( System.Data.DataSet ds )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			if ( ActiveSession.UserSecurityInfo.Administrator )
			{
				if ( linkData.Add( ds ) == 1 )
					return 1 ;
				else
					return -1 ;
			}
			else 
				return -1 ;

		}


		#endregion 

		#region UpdateLinks
		/// <summary>
		/// Update links data
		/// </summary>
		/// <param name="ds">DataSet:containing a set of links</param>
		/// <returns>integer value:1 if succeeded to update and -1 if failed</returns>
		public int UpdateLinks ( System.Data.DataSet ds )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			if ( ActiveSession.UserSecurityInfo.Administrator )
			{
				if (	linkData.Edit( ds ) == 1 )
					return 1 ;
				else
					return -1 ;
			}
			else 
				return -1 ;

		}


		#endregion 

		#region DeleteLinks
		/// <summary>
		/// Delete links 
		/// </summary>
		/// <param name="ds">DataSet:containing a set of links</param>
		/// <returns>integer value:1 if succeeded to delete and -1 if failed</returns>
		public int DeleteLinks ( System.Data.DataSet ds )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			if ( ActiveSession.UserSecurityInfo.Administrator )
			{
				if (	linkData.Delete( ds ) == 1 )
					return 1 ;
				else
					return -1 ;
			}
			else 
				return -1 ;

		}


		#endregion 

		#region ViewLinks
		/// <summary>
		/// Get all links in the system
		/// </summary>
		/// <returns>DataSet:containing a set of links</returns>
		public DataSet ViewLinks (  )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSet ds = new DataSet();

			if ( ActiveSession.UserSecurityInfo.Administrator )
				ds = linkData.List(); 
			
			return ds;

		}
		
		#endregion 

		#region ViewUserLinks
		/// <summary>
		/// Get all links which user has access to  
		/// </summary>
		/// <param name="usrID">integer value:user ID</param>
		/// <param name="moduleID">integer value:module ID</param>
		/// <returns>DataSet:containing a set of links</returns>
		public DataSet ViewUserLinks( int usrID , int moduleID )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSet ds = new DataSet();
			
			if ( ActiveSession.UserSecurityInfo.Administrator )
				ds = ViewModuleLinks( moduleID );

			else
			{
				linkData.oleDbDataAdapterUserLinks.SelectCommand.Parameters[ "UserID" ].Value = usrID ;
				linkData.oleDbDataAdapterUserLinks.SelectCommand.Parameters[ "ModID" ].Value = moduleID ;
				linkData.oleDbDataAdapterUserLinks.Fill( ds );
			}
			
			return ds;
		}
			

		#endregion 

		#region ViewModuleLinks
		/// <summary>
		/// Get all links for a specific module
		/// </summary>
		/// <param name="modID">integer value:module ID</param>
		/// <returns>DataSet:containing a set of links</returns>
		public DataSet ViewModuleLinks( int modID  )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSet ds = new DataSet();
			
			linkData.oleDbDataAdapterModuleLinks.SelectCommand.Parameters[ "ModID" ].Value = modID ;
			linkData.oleDbDataAdapterModuleLinks.Fill( ds );
			
			return ds;
		}
			

		#endregion 
		
		#endregion 

		#region Functionalities
		
		#region AddFunctionalities
		/// <summary>
		/// Add new functionalities
		/// </summary>
		/// <param name="ds">DataSet:containing a set of functionalities</param>
		/// <returns>integer value:1 if succeeded to add and -1 if failed</returns>
		public int AddFunctionalities ( System.Data.DataSet ds )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			if ( ActiveSession.UserSecurityInfo.Administrator )
			{
				if ( functionData.Add( ds ) == 1 )
					return 1 ;
				else
					return -1 ;
			}
			else 
				return -1 ;

		}


		#endregion 

		#region UpdateFunctionalities
		/// <summary>
		/// Update functionalities data
		/// </summary>
		/// <param name="ds">DataSet:containing a set of functionalities</param>
		/// <returns>integer value:1 if succeeded to update and -1 if failed</returns>
		public int UpdateFunctionalities ( System.Data.DataSet ds )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			if ( ActiveSession.UserSecurityInfo.Administrator )
			{
				if (	functionData.Edit( ds ) == 1 )
					return 1 ;
				else
					return -1 ;
			}
			else 
				return -1 ;

		}


		#endregion 

		#region DeleteFunctionalities
		/// <summary>
		/// Delete functionalities
		/// </summary>
		/// <param name="ds">DataSet:containing a set of functionalities</param>
		/// <returns>integer value:1 if succeeded to delete and -1 if failed</returns>
		public int DeleteFunctionalities ( System.Data.DataSet ds )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			if ( ActiveSession.UserSecurityInfo.Administrator )
			{
				if (	functionData.Delete( ds ) == 1 )
					return 1 ;
				else
					return -1 ;
			}
			else 
				return -1 ;

		}


		#endregion 

		#region ViewFunctionalities
		/// <summary>
		/// Get all functionalities in the system
		/// </summary>
		/// <returns>DataSet:containing a set of functionalities</returns>
		public DataSet ViewFunctionalities (  )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSet ds = new DataSet();

			if ( ActiveSession.UserSecurityInfo.Administrator )
				ds = functionData.List(); 
			
			return ds;

		}
		
		#endregion 

		#region ViewUserFunctionalities
		/// <summary>
		/// Get functionalities that user has access to
		/// example:"Employees" link contains "Employees" & "Teams" functionalities
		/// </summary>
		/// <param name="usrID">integer value:user ID</param>
		/// <param name="linkID">integer value:link ID</param>
		/// <returns>DataSet:containing a set of functionalities</returns>
		public DataSet ViewUserFunctionalities( int usrID , int linkID )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSet ds = new DataSet();
			
			if ( ActiveSession.UserSecurityInfo.Administrator )
				ds = ViewLinkFunctionalities( linkID );
			else
			{
				functionData.oleDbDataAdapterUserFunctionalities.SelectCommand.Parameters[ "UserID" ].Value = usrID ;
				functionData.oleDbDataAdapterUserFunctionalities.SelectCommand.Parameters[ "linkID" ].Value = linkID ;
				functionData.oleDbDataAdapterUserFunctionalities.Fill( ds );
			}
			
			return ds;
		}
			

		#endregion 

		#region ViewLinkFunctionalities
		/// <summary>
		/// Get all functionalities for a certain link that user has access to  
		/// </summary>
		/// <param name="linkID">integer value:user ID</param>
		/// <returns>DataSet:containing a set of functionalities</returns>
		public DataSet ViewLinkFunctionalities( int linkID )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSet ds = new DataSet();
			
			
			functionData.oleDbDataAdapterLinkFunctionalities.SelectCommand.Parameters[ "LinkID" ].Value = linkID ;
			functionData.oleDbDataAdapterLinkFunctionalities.Fill( ds );
			
			
			return ds;
		}
			

		#endregion 

		#endregion 
	}
}
