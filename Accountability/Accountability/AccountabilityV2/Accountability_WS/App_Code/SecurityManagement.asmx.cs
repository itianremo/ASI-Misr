using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace Security
{
	/// <summary>
	/// Summary description for Service1.
	/// </summary>
	public class SecurityManagement : TSN.ERP.Presentation.ERPMasterService 
	{
		public TSN.ERP.Presentation.AuthHeader authHeader = new TSN.ERP.Presentation.AuthHeader();
		TSN.ERP.Engine.SecurityManager secManger  ;

		public string error;

		public SecurityManagement()
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
		//protected  void Dispose( bool disposing )
		{
			if (secManger != null)
				//secManger.Dispose();
				secManger=null;
			if(disposing && components != null)
			{
				//components.Dispose();
				components=null;
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		#region Users Management 

		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public int AddUser( string usrName , string password , bool administrator , string winUser )
		{
			int result = 0;

			if( authHeader != null )
			{
				JoinSession( );
				result = secManger.AddUser( usrName , password , administrator , winUser );
			}
			return result;
		}

		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public DataSet GetAllUsers(  )
		{
			DataSet ds = new DataSet();

			if( authHeader != null )
			{
				JoinSession( );
				ds = secManger.GetAllUsers( );
			}
			return ds;
		}

		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public DataSet GetAllActiveUsers(  )
		{
			DataSet ds = new DataSet();

			if( authHeader != null )
			{
				JoinSession( );
				ds = secManger.GetAllActiveUsers();
			}
			return ds;
		}

		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public bool ModifyUser( DataSet ds )
		{
			bool result = false;

			if( authHeader != null )
			{
				JoinSession( );
				result = secManger.ModifyUser( ds );
			}
			return result;
		}


		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public DataSet GetAllNonAssignedUsers( )
		{
			DataSet ds = new DataSet();

			if( authHeader != null )
			{
				JoinSession( );
				ds = secManger.GetAllNonAssignedUsers( );
			}
			return ds;
		}


		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public int GetDefaultUserGroup(int userID)
		{
			int n = -1;

			if( authHeader != null )
			{
				JoinSession( );
				n = secManger.GetDefaultUserGroup( userID );
			}
			return n;
		}

		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public int RecordUserLogInTime(string UserName, DateTime SignInTime, string SessionID, bool Offline)
		{
			int n = -1;

			if( authHeader != null )
			{
				JoinSession( );
				n = secManger.RecordUserLogInTime(UserName, SignInTime, SessionID, Offline);
			}
			return n;
		}

		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public int UpdateUserLogin(DateTime SignOutTime, int ID)
		{
			int n = -1;

			if( authHeader != null )
			{
				JoinSession( );
				n = secManger.UpdateUserLogin(SignOutTime, ID);
			}
			return n;
		}
		
		#endregion 

		#region Users Groups Management
		
		#region Add User Group

		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public int AddUserGroup( string groupName )
		{
			int result = -1;
			
			if( authHeader != null )
			{
				JoinSession( );
				result = secManger.AddUserGroup( groupName );
			}
			return result ;
		}
		#endregion

		#region Get All Users Groups
		
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public DataSet GetAllUsersGroups()
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = secManger.GetAllUsersGroups( );
			}

			return ds;
		}
		#endregion

		#region Get All Non User Groups Type 
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public DataSet GetAllNonUserGroupsType()
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = secManger.GetAllNonUserGroupsType( );
			}

			return ds;
		}
		#endregion
		
		#region Get UserGroup
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public DataSet GetUserGroup( int userGroupID )
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = secManger.GetUserGroup(userGroupID  );
			}

			return ds;
		}
		#endregion

		#region Get All Users In user Group
		
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public DataSet GetAllUsersInUserGroup( int userGroupID )
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = secManger.GetAllUsersInGroup( userGroupID );
			}

			return ds;
		}
		#endregion

		#region Modify User Group
		
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public bool ModifyUserGroup( DataSet ds )
		{
			bool result = false;
			
			if( authHeader != null )
			{
				JoinSession( );
				result = secManger.ModifyUserGroup( ds );
			}
			return result;
		}

		#endregion

		#region Add User To Group
		
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public bool AddUserToGroup( int groupID , int userID )
		{
			bool result = false;

			if( authHeader != null )
			{
				JoinSession( );
				result = secManger.AddUserToGroup( groupID , userID );
			}

			return result;
		}
		#endregion

		#region Remove User from Group
		
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public bool RemoveUserFromGroup( int userID , int userGroupID )
		{
			bool result = false;

			if( authHeader != null )
			{
				JoinSession( );
				result = secManger.RemoveUserFromGroup( userID , userGroupID );
			}

			return result;
		}
		#endregion

		#region Modify Users In UserGroup

		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public bool ModifyUsersInUserGroup( DataSet ds )
		{
			bool result = false;
			
			if( authHeader != null )
			{
				JoinSession( );
				result = secManger.ModifyUsersInUserGroup( ds );
			}
			return result;
		}
		#endregion

		#region Delete User Group
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
	
		public bool DeleteUserGroup( int usrGrpID )
		{
			bool result = false;
			
			if( authHeader != null )
			{
				JoinSession( );
				result = secManger.DeleteUserGroup( usrGrpID );
			}
			return result;
		}
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		
		public bool DeleteUserGroupX( int usrGrpID )
		{
			bool result = false;
			
			if( authHeader != null )
			{
				JoinSession( );
				result = secManger.DeleteUserGroup( usrGrpID );
			}
			return result;
		}

		#endregion
		#endregion

		#region Rules Management
		
		#region Add Rule
	
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public int AddRule( string ruleName )
		{
			int result = -1;
			if( authHeader != null )
			{
				JoinSession( );
				result = secManger.AddRule( ruleName );
			}
			return result ;
		}
		#endregion

		#region Get All Rules
		
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public DataSet GetAllRules()
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = secManger.GetAllRules( );
			}
			return ds;
		}
		#endregion

		#region Modify Rule
		
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public bool ModifyRule( DataSet ds )
		{
			bool result = false;

			if( authHeader != null )
			{
				JoinSession( );
				result = secManger.ModifyRule( ds );
			}
			return result;
		}
		#endregion

		#region Add Rule Entity
		
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public int AddRuleEntity( int ruleID , string entityValue , string entityDescription  )
		{
			int result = -1;
			if( authHeader != null )
			{
				JoinSession( );
				result = secManger.AddRuleEntity( ruleID , entityValue , entityDescription );
			}
		
			return  result ;
		}


//		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
//		public int AddRuleEntity( int ruleID )
//		{
//			int result = -1;
//
//			if( authHeader != null )
//			{
//				JoinSession( );
//				result = secManger.AddRuleEntity( ruleID );
//			}
//			
//			return  result;
//		}


		#endregion

		#region Remove Rule Entity
		
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public bool RemoveRuleEntity( int ruleEntityID )
		{
			bool result = false;

			if( authHeader != null )
			{
				JoinSession( );
				result = secManger.RemoveRuleEntity( ruleEntityID );
			}

			return result;
		}
		#endregion

		#region Get All RulesEntities
		
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public DataSet GetAllRulesEntities()
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = secManger.GetAllRulesEntities( );
			}
			
			return ds;
		}
		#endregion

		#region Get All User Rules
		
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public DataSet GetAllUserRules( )
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = secManger.GetAllUserRules(  ERPSession.UserId );
			}
			return ds;
		}
		#endregion

		#region Get All User RulesEntities 
		
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public DataSet GetAllUserRulesEntities( )
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = secManger.GetAllUserRuleEntities(  ERPSession.UserId );
			}
			return ds;
		}
		#endregion

		#region GetAllEntities

		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public DataSet GetGeneralRuleEntities( )
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = secManger.GetGenralRuleEntities();
			}
			return ds;
		}

		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public DataSet GetAllEntities( )
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = secManger.GetAllEntities( );
			}
			return ds;
		}

		#endregion

		#region GetAllEntitiesItemsOfEntity

		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public DataSet GetAllEntitiesItemsOfEntity( int entityID )
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = secManger.GetAllEntitiesItemsOfEntity( entityID );
			}
			return ds;
		}
		
		
		#endregion

		#region Get All RulesEntities Of Entity And EntityValue

		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public DataSet GetAllRulesEntitiesOfEntityAndEntityValue( int entityID , int entityValue )
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = secManger.GetAllRulesEntitiesOfEntityAndEntityValue( entityID , entityValue );
			}
			return ds;
		}
		
		
		#endregion

		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public DataSet  GetRuleGroupOfEntityAndEntityValue( int entityID , int entityValue )
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = secManger.GetRuleGroupOfEntityAndEntityValue( entityID , entityValue );
			}
			return ds;
		}
		
		#endregion

		#region Rules Groups Management
		
		#region Add Rule Group

		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public int AddRuleGroup( string groupName )
		{
			int result = -1;

			if( authHeader != null )
			{
				JoinSession( );
				result = secManger.AddRuleGroup( groupName );
			}
			return  result ;
		}
		#endregion

		#region Get All RuleGroups
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public DataSet GetAllRuleGroups()
		{
			DataSet  ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = secManger.GetAllRuleGroups( );
			}
			return ds;
		}
		#endregion

		#region Get RuleGroup
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public DataSet GetRuleGroup( int ruleGroupID )
		{
			DataSet  ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = secManger.GetRuleGroup( ruleGroupID );
			}
			return ds;
		}
		#endregion

		#region Modify Rule Group
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public bool ModifyRuleGroup( DataSet ds )
		{
			bool result = false;

			if( authHeader != null )
			{
				JoinSession( );
				result = secManger.ModifyRuleGroup( ds );
			}

			return result;
			
		}
		#endregion
		
		#region Add RuleEntity To RuleGroup
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public bool AddRuleEntityToRuleGroup( int ruleEntityID , int ruleGroupID )
		{
			bool result = false;

			if( authHeader != null )
			{
				JoinSession( );
				result = secManger.AddRuleEntityToRuleGroup( ruleEntityID , ruleGroupID );
			}

			return result;
		}
		#endregion
		
		#region Remove RuleEntity from RuleGroup
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public bool RemoveRuleEntityFromRuleGroup( int ruleEntityID , int ruleGroupID )
		{
			bool result = false;

			if( authHeader != null )
			{
				JoinSession( );
				result = secManger.RemoveRuleEntityFromRuleGroup( ruleEntityID , ruleGroupID );
			}

			return result;
		}
		#endregion
			
		#region Get All RuleEntities in Rule Group
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public DataSet GetAllRuleEntitiesInRuleGroup( int ruleGroupID )
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = secManger.GetAllRuleEntitiesInRuleGroup( ruleGroupID );
			}
			return ds;
		}
		#endregion

		#region Add RuleGroup To UserGroup
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public bool AddRuleGroupToUserGroup( int userGroupID , int ruleGroupID )
		{
			bool result = false;

			if( authHeader != null )
			{
				JoinSession( );
				result = secManger.AddRuleGroupToUserGroup( userGroupID , ruleGroupID );
			}
			return result;
		}
		#endregion

		#region Remove RuleGroup from UserGroup
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public bool RemoveRuleGroupFromUserGroup( int userGroupID , int ruleGroupID )
		{
			bool result = false;

			if( authHeader != null )
			{
				JoinSession( );
				result = secManger.RemoveRuleGroupFromUserGroup( userGroupID , ruleGroupID );
			}
			return result;
		}
		#endregion

		#region Modify RulesEntities In RuleGroup

		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public bool ModifyRulesEntitiesInRuleGroup( DataSet ds )
		{
			bool result = false;
			
			if( authHeader != null )
			{
				JoinSession( );
				result = secManger.ModifyRulesEntitiesInRuleGroup( ds );
			}
			return result;
		}
		#endregion

		#region Get All RuleEntities in Rule Group
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public DataSet GetAllRuleEntitiesDataInRuleGroup( int ruleGroupID )
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = secManger.GetAllRuleEntitiesDataInRuleGroup( ruleGroupID );
			}
			return ds;
		}
		#endregion

		#region Delete Rule Group
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
	
		public bool DeleteRuleGroup( int rlGrpID )
		{
			bool result = false;
			if( authHeader != null )
			{
				JoinSession( );
				result = secManger.DeleteRuleGroup( rlGrpID );
			}
			return result;
		}
		#endregion
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public bool DeleteRuleGroupX( int rlGrpID )
		{
			bool result = false;
			if( authHeader != null )
			{
				JoinSession( );
				result = secManger.DeleteRuleGroup( rlGrpID );
			}
			return result;
		}


		#endregion

		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public int SetHomePage(int UserID, int LinkID)
		{
			JoinSession();
			return secManger.SetUserHomeLink(UserID,LinkID);
		}
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public int GetHomePage(int UserID)
		{
			JoinSession();
			return secManger.GetHomeLink(UserID);
		}
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public string GetUserName(string EmployeeCode)
		{
			//JoinSession();
			TSN.ERP.Engine.SecurityManager secManger2 = new TSN.ERP.Engine.SecurityManager();
			return secManger2.GetUserName(EmployeeCode);
		}
		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public string GetToken(string EmployeeCode)
		{
			//JoinSession();
			DataSet ds;
			TSN.ERP.Engine.SecurityManager secManger2 = new TSN.ERP.Engine.SecurityManager();
			ds=secManger2.GetUserData(EmployeeCode);
			if(ds==null || ds.Tables[0].Rows.Count==0)
				return null;
			else
			{
				return this.Login(Convert.ToString(ds.Tables[0].Rows[0]["UserName"]),Convert.ToString(ds.Tables[0].Rows[0]["SecPass"]));
			}
		}
		[WebMethod ( EnableSession = true,MessageName = "GetHomePageForCurrentUser" )  ,SoapHeader( "authHeader" ) ]
		public int GetHomePage()
		{
			JoinSession();
			return secManger.GetHomeLink(ERPSession.UserId);
		}

		[WebMethod ( EnableSession = true,MessageName = "" )  ,SoapHeader( "authHeader" ) ]
		public DataSet GetRulesForEntityType(int EntityID)
		{
			JoinSession();
			return secManger.GetRulesForEntityType(EntityID);
		}
		#region Get User ID

		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public int GetUserIDByContactID( int ContactID )
		{
			int result = -1;

			if( authHeader != null )
			{
				JoinSession( );
				result = secManger.GetUserIDbyContactID( ContactID );
			}
			return  result ;
		}
		#endregion

		#region Check Rule with User

		[WebMethod ( EnableSession = true ) , SoapHeader( "authHeader" ) ]
		public bool CheckRuleXUserID( int UserID,int RuleID )
		{
			bool result = false;

			if( authHeader != null )
			{
				JoinSession( );
				result = secManger.CheckRuleXUserID(UserID,RuleID);
			}
			return  result ;
		}
		#endregion

		public void JoinSession( )
		{
			secManger = new TSN.ERP.Engine.SecurityManager();
			secManger.JoinSession( ERPSession.Token );
			

		}

	}
}
