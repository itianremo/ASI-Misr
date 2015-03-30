using System;
using TSN.ERP.Security;
using TSN.ERP.Security.Data;
using System.Data;
//using System.EnterpriseServices;

namespace TSN.ERP.Engine
{
	/// <summary>
	/// Summary description for SecurityManager.
	/// </summary>
	/// 
	//[ObjectPooling(Enabled=true, MinPoolSize=0, MaxPoolSize=100, CreationTimeout=10000)]
	public class SecurityManager:BussinesObject 
	{
		#region Variables 
		private string _error = "";
		private SecurityManagement secMang = new SecurityManagement();
		private TSN.ERP.Security.EntitysecurityManager secEntMng = new EntitysecurityManager(); 

		string noAccessRigh = "This user has not access right"; 
		#endregion 

		protected override void ObjectIntiated()
		{
			base.ObjectIntiated ();
			secMang.ConnectionString = this.ActiveSession.ConnectionString;
			secEntMng.SetConnection( this.ActiveSession.ConnectionString );
			
		}

		public SecurityManager()
		{
			
		}


		#region Functions 

		#region User Management
		
		#region Add User
		/// <summary>
		/// Adding user record in the DB
		/// </summary>
		/// <param name="usrName">string for user name</param>
		/// <param name="password">string for passward</param>
		/// <param name="administrator">if the user is administrator or not</param>
		/// <param name="winUser">user windows authintication</param>
		/// <returns>integer: holding the added user ID</returns>

		public int AddUser( string usrName , string password , bool administrator , string winUser )
		{
			////System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			int n = -1;

			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					n = secMang.AddUser( usrName , password , administrator , winUser );
				else
				{
					error = noAccessRigh;
					return -1 ;
				}
				
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return n ;
		}
		#endregion


		#region Get User Name
		/// <summary>
		/// Get user Name by Employee Code
		/// </summary>
		/// <param name="EmpCode">string for employee code</param>
		/// <returns>string: User Name</returns>

		public string GetUserName(string EmployeeCode)
		{
			try
			{
				ResourcePool objRespool=new ResourcePool();
				
				return secMang.mGetUserNameByEmpCode(EmployeeCode,objRespool.GetConnectionString());
				
			}
			catch ( Exception ee )
			{
				return null;
			}
			
		}
		#endregion

		#region Get User Data by Employee Code
		/// <summary>
		/// Get user Name and Password by Employee Code
		/// </summary>
		/// <param name="EmpCode">string for employee code</param>
		/// <returns>DataSet: has User Name and Password</returns>

		public DataSet GetUserData(string EmployeeCode)
		{
			try
			{
				ResourcePool objRespool=new ResourcePool();
				
				return secMang.mGetUserDataByEmpCode(EmployeeCode,objRespool.GetConnectionString());
				
			}
			catch ( Exception ee )
			{
				return null;
			}
			
		}
		#endregion

		#region Get All Users
		/// <summary>
		/// get all users
		/// </summary>
		/// <returns>dataset containing a aset of users</returns>
		public UsrDS GetAllUsers()
		{
			////System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			UsrDS ds = new UsrDS();
			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					ds = secMang.GetAllUsers();
				else
				{
					error = noAccessRigh;
					return null ;
				}

			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return ds;
		}
		#endregion

		#region Get All Active Users
		/// <summary>
		/// get all active users
		/// </summary>
		/// <returns>dataset containing a set of active users</returns>
		/// 
		public UsrDS GetAllActiveUsers()
		{
			////System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			UsrDS ds = new UsrDS();
			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					ds = secMang.GetAllActiveUsers();
				else
				{
					error = noAccessRigh;
					return null ;
				}

			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			
			return ds;
		}
		#endregion

		#region Modify User
		/// <summary>
		/// modify user data
		/// </summary>
		/// <param name="ds">dataset contains user information</param>
		/// <returns>bool,true if succeeded to modify and false if failed</returns>
		public bool ModifyUser( DataSet ds )
		{
			////System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			bool result = false;
			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					result = secMang.ModifyUser( ds );
				else
				{
					error = noAccessRigh;
					return false ;
				}
				
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return result;
			
		}
		#endregion
		
		#region Get All Users In User Group
		/// <summary>
		/// get all users
		/// </summary>
		/// <returns>dataset contains a set of users</returns>
		public UsrDS GetAllUsersInGroup( int userGroupID )
		{
			////System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			UsrDS ds = new UsrDS();
			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					ds = secMang.GetAllUsersInGroup( userGroupID );
				else
				{
					error = noAccessRigh;
					return null ;
				}

			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return ds;
		}
		#endregion

		#region Login 
		/// <summary>
		/// check user information for login
		/// </summary>
		/// <param name="userName">string for user name</param>
		/// <param name="password">string for passward</param>
		/// <returns>boolean: True for successful login , False for unsuccessful login</returns>
		public bool CheckUser( string userName , string password )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			bool login = false;

			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					login = secMang.CheckUser( userName , password );
				else
				{
					error = noAccessRigh;
					return false ;
				}
				
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return login;
		}
	

		#endregion

		#region Get All Non Assigned Users 
		/// <summary>
		/// Get all non assigned users
		/// </summary>
		/// <returns>dataset contains non assigned users</returns>
		public UsrDS GetAllNonAssignedUsers ( )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			UsrDS ds = new UsrDS();
			try
			{
				ds = secMang.GetAllNonAssignedUsers( );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return ds;
		}
		#endregion

		#region GetDefaultUserGroup
		/// <summary>
		/// Get default user group (group id)
		/// </summary>
		/// <param name="userID">int value for user ID</param>
		/// <returns>integer: holding the group ID</returns>
		public int GetDefaultUserGroup(int userID)
		{
			int n = -1;
			try
			{
				n = secEntMng.GetDefaultUserGroup( userID );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return n;
		}
		#endregion

		#region Record User Login
		/// <summary>
		/// Record User Login
		/// </summary>
		/// <param name="UserName"></param>
		/// <param name="SignInTime"></param>
		/// <param name="SessionID"></param>
		/// <param name="Offline"></param>
		/// <returns></returns>
		public int RecordUserLogInTime(string UserName, DateTime SignInTime, string SessionID, bool Offline)
		{
			int n = -1;
			try
			{
				n = secMang.RecordUserLogin(UserName, SignInTime, SessionID, Offline);
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return n;
		}
		#endregion

		#region Update User Login
		/// <summary>
		/// Update User Login
		/// </summary>
		/// <param name="SignOutTime"></param>
		/// <param name="ID"></param>
		/// <returns></returns>
		public int UpdateUserLogin(DateTime SignOutTime, int ID)
		{
			int n = -1;
			try
			{
				n = secMang.UpdateUserLogin(SignOutTime, ID);
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return n;
		}
		#endregion
			
		#endregion

		#region Groups Management
		
		#region Add User Group
		/// <summary>
		/// adding user group
		/// </summary>
		/// <param name="groupName">string for group name</param>
		/// <returns>integer: holding the added group ID</returns>
		public int AddUserGroup( string groupName )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			int result = -1;

			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					result = secMang.AddUserGroup( groupName );
				else
				{
					error = noAccessRigh;
					return -1 ;
				}
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return result ;
		}
		#endregion

		#region Get All Users Groups
		/// <summary>
		/// Get All Users Groups
		/// </summary>
		/// <returns>dataset contains users groups</returns>
		public DataSetGroups GetAllUsersGroups()
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSetGroups ds = new DataSetGroups();
			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					ds = secMang.GetAllUsersGroups( );
				else
				{
					error = noAccessRigh;
					return null;
				}
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return ds;
		}
		#endregion

		#region Get All Non User Groups Type 
		/// <summary>
		/// Get All Users Groups which not assigned to any employee
		/// </summary>
		/// <returns>dataset contains users groups</returns>
		public DataSetGroups GetAllNonUserGroupsType()
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSetGroups ds = new DataSetGroups();
			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					ds = secMang.AllNonUserGroupsType( );
				else
				{
					error = noAccessRigh;
					return null;
				}
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return ds;
		}
		#endregion

		#region Get UserGroup
		/// <summary>
		/// Get user group detailed data
		/// </summary>
		/// <param name="userGroupID">integer:user group ID</param>
		/// <returns>dataset contains user group information</returns>
		public DataSetGroups GetUserGroup( int userGroupID )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSetGroups ds = new DataSetGroups();
			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					ds = secMang.GetUserGroup( userGroupID );
				else
				{
					error = noAccessRigh;
					return null ;
				}

			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return ds;
		}
		#endregion

		#region Modify User Group
		/// <summary>
		/// Modify user group
		/// </summary>
		/// <param name="ds">dataset contains data of user group</param>
		/// <returns>boolean: True for successful modification , False for unsuccessful one</returns>
		public bool ModifyUserGroup( DataSet ds )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			bool result = false;

			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					result = secMang.ModifyUserGroup( ds );
				else
				{
					error = noAccessRigh;
					return false ;
				}

			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return result;
		}
		#endregion

		#region Delete User Group
		/// <summary>
		/// Delete user group
		/// </summary>
		/// <param name="usrGrpID">integer:user group ID</param>
		/// <returns>boolean: True for successful deletion , False for unsuccessful one</returns>
	
	
		public bool DeleteUserGroup( int usrGrpID )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			bool result = false;

			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					result = secMang.DeleteUserGroup( usrGrpID );
				else
				{
					error = noAccessRigh;
					return false ;
				}

			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return result;
		}
		#endregion

		#region Add User To Group
		/// <summary>
		/// Add User To Group
		/// </summary>
		/// <param name="groupID">integer:group ID</param>
		/// <param name="userID">integer:user ID</param>
		/// <returns>boolean: True for successful addition , False for unsuccessful one</returns>
		public bool AddUserToGroup( int groupID , int userID )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			bool result = false;

			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					result = secMang.AddUserToGroup( groupID , userID );
				else
				{
					error = noAccessRigh;
					return false ;
				}
			}
			catch ( Exception  ee )
			{
				error = ee.Message;
			}
			return result;
		}
		#endregion

		#region Remove User from Group
		/// <summary>
		/// Remove User From Group
		/// </summary>
		/// <param name="userID">integer:user id</param>
		/// <param name="userGroupID">integer:user group ID</param>
		/// <returns>boolean: True for successful remove , False for unsuccessful one</returns>
		public bool RemoveUserFromGroup( int userID , int userGroupID )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			bool result = false;

			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					result = secMang.RemoveUserFromGroup( userID , userGroupID );
				else
				{
					error = noAccessRigh;
					return false;
				}
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return result;
		}
		#endregion

		#region Modify Users In UserGroup
		/// <summary>
		/// Modify users in user group
		/// </summary>
		/// <param name="ds">dataset contains user group informations</param>
		/// <returns>boolean: True for successful modification , False for unsuccessful one</returns>
	
		public bool ModifyUsersInUserGroup( DataSet ds )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			bool result = false;

			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					result = secMang.ModifyUsersInUserGroup( ds );
				else
				{
					error = noAccessRigh;
					return false ;
				}

			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return result;
		}
		#endregion
		
		#endregion

		#region Rules Management
		
		#region Add Rule
		/// <summary>
		/// Adding Rule record in the DB
		/// </summary>
		/// <param name="ruleName">string:rule name</param>
		/// <returns>Integer: added rule id</returns>

		public int AddRule( string ruleName )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			int n = -1;
			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					n = secMang.AddRule( ruleName );
				else
				{
					error = noAccessRigh;
					return -1 ;
				}
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return n ;
		}
		#endregion

		#region Get All Rules
		/// <summary>
		/// Get All Rules
		/// </summary>
		/// <returns>dataset:contains a set of rules</returns>
		public DataSetRules GetAllRules()
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSetRules ds = new DataSetRules();
			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					ds = secMang.GetAllRules();
				else
				{
					error = noAccessRigh;
					return null ;
				}
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return ds;
		}
		#endregion

		#region Modify Rule
		/// <summary>
		/// Modify Rule
		/// </summary>
		/// <param name="ds">dataset:contains rule data</param>
		/// <returns>boolean: True for successful modification , False for unsuccessful one</returns>
		public bool ModifyRule( DataSet ds )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			bool result = false;

			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					result = secMang.ModifyRule( ds );
				else
				{
					error = noAccessRigh;
					return false;
				}	
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return result;
		}
		#endregion

		#region Add Rule Entity
		/// <summary>
		/// Add rule entity 
		/// </summary>
		/// <param name="ruleID">integer:rule ID</param>
		/// <param name="entityValue">string:entity value</param>
		/// <param name="entityDescription">string: description for the added entity</param>
		/// <returns>integer: new rule entity id</returns>
		public int AddRuleEntity( int ruleID , string entityValue, string entityDescription )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			int n = -1;

			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					n = secMang.AddRuleEntity( ruleID , entityValue, entityDescription );
				else
				{
					error = noAccessRigh;
					return -1 ;
				}
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return  n ;
		}


		/// <summary>
		/// Add Rule Entity
		/// </summary>
		/// <param name="ruleID"></param>
		/// <returns>Integer: new rule entity id</returns>
		public int AddRuleEntity( int ruleID )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			int n = -1;

			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					n = secMang.AddRuleEntity( ruleID );
				else
				{
					error = noAccessRigh;
					return -1 ;
				}
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return  n;
		}


		#endregion

		#region Remove Rule Entity
		/// <summary>
		/// Remove Rule Entity
		/// </summary>
		/// <param name="ruleEntityID">integer:rule entity ID</param>
		/// <returns>boolean:true for successful addition and false for unsuccessful one</returns>
		public bool RemoveRuleEntity( int ruleEntityID )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			bool result = false;

			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					result = secMang.RemoveRuleEntity( ruleEntityID );
				else
				{
					error = noAccessRigh;
					return false ;
				}

			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return result;
		}
		#endregion

		#region Get All RulesEntities
		/// <summary>
		/// Get All Rule Entities
		/// </summary>
		/// <returns>dataset:contains a set of rule entities</returns>
		public DataSetRuleEntity GetAllRulesEntities()
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSetRuleEntity ds = new DataSetRuleEntity();
			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					ds = secMang.GetAllRulesEntities( );
				else
				{
					error = noAccessRigh;
					return null;
				}
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return ds;
	
		}
		#endregion

		#region Get All User Rules
		/// <summary>
		/// Get all user rules
		/// </summary>
		/// <param name="userID">integer:user ID</param>
		/// <returns>dataset:contains a set of rules</returns>
		public DataSet GetAllUserRules( int userID )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSetRules ds = new DataSetRules();
			try
			{
				ds = secMang.GetAllUserRules( userID );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return ds;
		}
		#endregion

		#region Get All User RuleEntities
		/// <summary>
		/// Get all user rule entities
		/// </summary>
		/// <param name="userID">integer:user ID</param>
		/// <returns>dataset:contains a set of all user rule entities</returns>
		public DataSet GetAllUserRuleEntities( int userID )
		{
			
			DataSetRuleEntity ds = new DataSetRuleEntity();
			try
			{
				ds = secMang.GetAllUserRuleEntities( userID );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return ds;
		}
		#endregion

		#region GetAllEntities
		/// <summary>
		/// Get all entities
		/// </summary>
		/// <returns>dataset:contains all entities</returns>
		public DataSet GetAllEntities(  )
		{
			DataSetEntities ds = new DataSetEntities();
			try
			{
				ds = secMang.GetAllEntities( );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return ds;

		}

		#endregion

		#region GetAllEntitiesItemsOfEntity
		/// <summary>
		/// Get all entities items of entity
		/// </summary>
		/// <param name="entityID">integer:entity ID</param>
		/// <returns>dataset:contains entities items</returns>
		public DataSet GetAllEntitiesItemsOfEntity( int entityID )
		{
			DataSet ds = new DataSet();
			try
			{
				ds = secMang.GetAllEntitiesItemsOfEntity( entityID );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return ds;
		}
		
		
		#endregion

		#region Get All RulesEntities Of Entity And EntityValue
		/// <summary>
		/// Get all rules entities of entity And entity value
		/// </summary>
		/// <param name="entityID">integer:entity ID</param>
		/// <param name="entityValue">integer:entity value</param>
		/// <returns>dataset:contains a set of rules entities</returns>
		public DataSetRuleEntity GetAllRulesEntitiesOfEntityAndEntityValue( int entityID , int entityValue )
		{
			DataSetRuleEntity ds = new DataSetRuleEntity();
			try
			{
				ds = secMang.GetAllRulesEntitiesOfEntityAndEntityValue( entityID , entityValue );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return ds;
		}
		public DataSet GetGenralRuleEntities()
		{
			DataSetRuleEntity ds = new DataSetRuleEntity();
			try
			{
				ds .Merge( secMang.GetGeneralRules());
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return ds;
		}

		#endregion

		#region Get Rule Grpup Of Entity And EntityValue
		/// <summary>
		///  Get rule group of entity and entity value
		/// </summary>
		/// <param name="entityID">integer: entity ID</param>
		/// <param name="entityValue">integer:entity value</param>
		/// <returns>dataset:contains a set of rule group</returns>
		public DataSetRuleGroup  GetRuleGroupOfEntityAndEntityValue( int entityID , int entityValue )
		{
			DataSetRuleGroup ds = new DataSetRuleGroup();
			try
			{
				ds = secMang.GetRuleGroupOfEntityAndEntityValue( entityID , entityValue );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return ds;
		}
		#endregion

		#endregion

		#region Rules Groups Management
		
		#region Add Rule Group
		/// <summary>
		/// Add rule group
		/// </summary>
		/// <param name="groupName">string:group name</param>
		/// <returns>Integer:added rule group id</returns>
		public int AddRuleGroup( string groupName )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			int n = -1;

			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					n = secMang.AddRuleGroup( groupName );
				else
				{
					error = noAccessRigh;
					return -1 ;
				}
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return  n ;
		}
		#endregion

		#region Get All RuleGroups
		/// <summary>
		/// get all rule groups data
		/// </summary>
		/// <returns>dataset:contains all rule groups</returns>
		public DataSetRuleGroup GetAllRuleGroups()
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSetRuleGroup  ds = new DataSetRuleGroup();
			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					ds = secMang.GetAllRuleGroups();
				else
				{
					error = noAccessRigh;
					return null ;
				}
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return ds;
		}
		#endregion

		#region Get RuleGroup
		/// <summary>
		/// Get a specific rule group
		/// </summary>
		/// <param name="ruleGroupID">integer:rule group ID</param>
		/// <returns>dataset:contains rule group information</returns>
		public DataSetRuleGroup GetRuleGroup( int ruleGroupID )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSetRuleGroup  ds = new DataSetRuleGroup();
			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					ds = secMang.GetRuleGroup( ruleGroupID );
				else
				{
					error = noAccessRigh;
					return null ;
				}
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return ds;
		}
		#endregion

		#region Modify Rule Group
		/// <summary>
		/// Modify rule group
		/// </summary>
		/// <param name="ds">dataset:contains a rule group information</param>
		/// <returns>boolean: True for successful modification , False for unsuccessful one</returns>
		
		public bool ModifyRuleGroup( DataSet ds )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			bool result = false;

			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					result = secMang.ModifyRuleGroup( ds );
				else
				{
					error = noAccessRigh;
					return false;
				}
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return result;
			
		}
		#endregion

		#region Delete Rule Group
		/// <summary>
		/// Delete a rule group
		/// </summary>
		/// <param name="usrGrpID">integer:rule group ID</param>
		/// <returns>boolean: True for successful deletion , False for unsuccessful one</returns>
	
		public bool DeleteRuleGroup( int rlGrpID )
		{
			bool result = false;

			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					result = secMang.DeleteRuleGroup( rlGrpID );
				else
				{
					error = noAccessRigh;
					return false ;
				}

			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return result;
		}
		#endregion
		
		#region Add RuleEntity To RuleGroup
		/// <summary>
		/// Add rule entity to rule group
		/// </summary>
		/// <param name="ruleEntityID">integer:rule entity ID</param>
		/// <param name="ruleGroupID">integer:rule group ID</param>
		/// <returns>boolean: True for successful addition , False for unsuccessful one</returns>
		public bool AddRuleEntityToRuleGroup( int ruleEntityID , int ruleGroupID )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			bool result = false;

			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					result = secMang.AddRuleEntityToRuleGroup( ruleEntityID , ruleGroupID );
				else
				{
					error = noAccessRigh;
					return false;
				}
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return result;
		}
		#endregion
		
		#region Remove RuleEntity from RuleGroup
		
		/// <summary>
		/// Remove a rule entity from a rule group
		/// </summary>
		/// <param name="ruleEntityID">integer:rule entity ID</param>
		/// <param name="ruleGroupID">integer:rule group ID</param>
		/// <returns>boolean: True if removed , False if not</returns>
		public bool RemoveRuleEntityFromRuleGroup( int ruleEntityID , int ruleGroupID )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			bool result = false;

			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					result = secMang.RemoveRuleEntityFromRuleGroup( ruleEntityID , ruleGroupID );
				else
				{
					error = noAccessRigh;
					return false ;
				}
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return result;
		}
		#endregion
			
		#region Get All RuleEntities in Rule Group
		/// <summary>
		/// Get all rule entities in a rule group
		/// </summary>
		/// <param name="ruleGroupID">integer:rule group ID</param>
		/// <returns>dataset:contains a set of rules</returns>
		public DataSet GetAllRuleEntitiesInRuleGroup( int ruleGroupID )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			//DataSetRlEntRlGrp ds = new DataSetRlEntRlGrp();
			DataSet ds = new DataSet();
			try
			{
				ds = secMang.GetAllRuleEntitiesInRuleGroup( ruleGroupID );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return ds;
		}
		#endregion

		#region Add RuleGroup To UserGroup
		/// <summary>
		/// Add rule group to user group
		/// </summary>
		/// <param name="userGroupID">integer:user group ID</param>
		/// <param name="ruleGroupID">integer:rule group ID</param>
		/// <returns>boolean: True for successful addition , False for unsuccessful one</returns>
		public bool AddRuleGroupToUserGroup( int userGroupID , int ruleGroupID )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			bool result = false;

			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					result = secMang.AddRuleGroupToUserGroup( userGroupID , ruleGroupID );
				else
				{
					error = noAccessRigh;
					return result;
				}
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return result;
		}
		#endregion

		#region Remove RuleGroup from UserGroup
		/// <summary>
		/// Remove a rule group from a user group
		/// </summary>
		/// <param name="userGroupID">integer:user group ID</param>
		/// <param name="ruleGroupID">integer:rule group ID</param>
		/// <returns>boolean: True if removed , False if not</returns>
		public bool RemoveRuleGroupFromUserGroup( int userGroupID , int ruleGroupID )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			bool result = false;

			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					result = secMang.RemoveRuleGroupFromUserGroup( userGroupID , ruleGroupID );
				else
				{
					error = noAccessRigh;
					return false ;
				}
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return result;
		}
		#endregion

		#region Modify RulesEntities In RuleGroup
		/// <summary>
		/// Modify rules entities in rule group 
		/// </summary>
		/// <param name="ds">dataset:contains rule group information</param>
		/// <returns>boolean: True for successful modification , False for unsuccessful one</returns>
		public bool ModifyRulesEntitiesInRuleGroup( DataSet ds )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			bool result = false;

			try
			{
				if ( ActiveSession.UserSecurityInfo.Administrator )
					result = secMang.ModifyRulesEntitiesInRuleGroup( ds );
				else
				{
					error = noAccessRigh;
					return false ;
				}

			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return result;
		
		}
		#endregion

		#region Get All RuleEntities in Rule Group
		/// <summary>
		/// Get all rule entities data in a rule group
		/// </summary>
		/// <param name="ruleGroupID">integer rule group ID</param>
		/// <returns>dataset:contains rule entities detailed data</returns>
		public DataSetRuleEntity GetAllRuleEntitiesDataInRuleGroup( int ruleGroupID )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSetRuleEntity ds = new DataSetRuleEntity();
			try
			{
				ds = secMang.GetAllRuleEntitiesDataInRuleGroup( ruleGroupID );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return ds;
		}
		#endregion

		#region GetRuleGroupForEntity
		/// <summary>
		/// Get rule group for entity
		/// </summary>
		/// <param name="primaryKeyValue">string:primary key value</param>
		/// <param name="entityType">integer:entity type</param>
		/// <returns>Integer:rule group ID</returns>
		public int GetRuleGroupForEntity( string primaryKeyValue , int entityType )
		{
			int n = -1;
			try
			{
				n = secEntMng.FindRgroupForEntity(  primaryKeyValue , entityType );
			}
			catch ( Exception ee )
			{
				error = ee.Message;
			}
			return n;
		}

		#endregion

		#endregion

		#endregion 
		

		#region Properties

		public string error
		{
			//		get
			//		{
			//			return this.ActiveSession.;
			//		}

			set
			{
				this.ActiveSession.SetError(new TSN.ERP.Engine.ERPError( 0 , _error , 0 ,null )) ;
			}
		}
		#endregion 
		/// <summary>
		/// Set user home link
		/// </summary>
		/// <param name="UserID">integer:user ID</param>
		/// <param name="HomeLink">integer:home link</param>
		/// <returns>integer: greater than 0 if succeeded and 0 if failed</returns>
		public int SetUserHomeLink(int UserID, int HomeLink)
		{
			if (ActiveSession.IsAdmin||ActiveSession.UserId == UserID)
				return secMang.SetHomeLink(UserID,HomeLink);
			return -1;
		}
		
		/// <summary>
		/// Get rules for an entity type
		/// </summary>
		/// <param name="EntityID">integer:entity ID</param>
		/// <returns>dataset:contains a set of rules</returns>
		public DataSet GetRulesForEntityType(int EntityID)
		{
			return secMang.GetRulesForEntityType(EntityID);
		}
		/// <summary>
		/// Get home link
		/// </summary>
		/// <param name="UserID">integer:user ID</param>
		/// <returns>integer:get user home link ID</returns>
		public int GetHomeLink(int UserID)
		{
			return secMang.GetHomeLink(UserID);
		}
		/// <summary>
		/// get User ID
		/// </summary>
		/// <param name="ContactID">integer:ContactID</param>
		/// <returns>integer: User Id</returns>
		public int GetUserIDbyContactID(int ContactID)
		{
			
				return secMang.GetUserIDByContactID(ContactID);
			
		}
		/// <summary>
		/// check Rule ID
		/// </summary>
		/// <param name="ContactID">integer:ContactID</param>
		/// <returns>integer: User Id</returns>
		public bool CheckRuleXUserID(int UserID,int RuleID)
		{
			
			return secMang.CheckUserRuleEntities(UserID,RuleID);
			
		}
	}
}
