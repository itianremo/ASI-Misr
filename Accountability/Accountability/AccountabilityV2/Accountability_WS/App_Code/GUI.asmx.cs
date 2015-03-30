using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;


namespace GUIPresentation
{
	/// <summary>
	/// Summary description for Service1.
	/// </summary>
	public class GUI : TSN.ERP.Presentation.ERPMasterService 
	{
		TSN.ERP.GUIManagement.GUIManager gm ;
		TSN.ERP.GUIManagement.SecurityGUIManager  secGUIMang ;
		public TSN.ERP.Presentation.AuthHeader authHeader = new TSN.ERP.Presentation.AuthHeader();

		public GUI()
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
			if (gm != null)
				//gm.Dispose();
				gm=null;
			if (secGUIMang != null)
				//secGUIMang.Dispose();
				secGUIMang=null;

			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		#region GUI Manager 
	

		[WebMethod ( EnableSession = true ), SoapHeader( "authHeader" ) ]
		public DataSet ViewUserModules()
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds.Merge( gm.ViewUserModules( ERPSession.UserId ));
				
			}
			return ds;
		}


		[WebMethod ( EnableSession = true ), SoapHeader( "authHeader" ) ]
		public DataSet ViewUserLinks( int moduleID )
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = gm.ViewUserLinks( ERPSession.UserId , moduleID );
			}
			return ds;
		}


		[WebMethod ( EnableSession = true ), SoapHeader( "authHeader" ) ]
		public DataSet ViewUserFunctionalities( int linkID )
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = gm.ViewUserFunctionalities( ERPSession.UserId  , linkID );
			}
			return ds;
		}


		
		[WebMethod ( EnableSession = true ), SoapHeader( "authHeader" ) ]
		public DataSet ViewModules()
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds.Merge( gm.ViewModules( ));
				
			}
			return ds;
		}


		[WebMethod ( EnableSession = true ), SoapHeader( "authHeader" ) ]
		public DataSet ViewModuleLinks( int modID )
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds.Merge( gm.ViewModuleLinks( modID ));
				
			}
			return ds;
		}


		[WebMethod ( EnableSession = true ), SoapHeader( "authHeader" ) ]
		public DataSet ViewLinkFunctionalities( int linkID )
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds.Merge( gm.ViewLinkFunctionalities( linkID ));
				
			}
			return ds;
		}


		public void JoinSession( )
		{
			gm = new TSN.ERP.GUIManagement.GUIManager();
			gm.JoinSession(Token);
			secGUIMang = new TSN.ERP.GUIManagement.SecurityGUIManager();
			secGUIMang.JoinSession(Token);
		}

		
		#endregion

		#region security GUI

		[WebMethod ( EnableSession = true ), SoapHeader( "authHeader" ) ]
		public DataSet ViewSubModulesForModule( int modID )
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = secGUIMang.ViewSubModulesForModule( modID );
			}
			return ds;
		}

		[WebMethod ( EnableSession = true ), SoapHeader( "authHeader" ) ]
		public DataSet ViewRulesForSubModule( int ModsubModID )
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = secGUIMang.ViewRulesOfSubModule( ModsubModID );
			}
			return ds;
		}

		[WebMethod ( EnableSession = true ), SoapHeader( "authHeader" ) ]
		public DataSet ViewRulesEntitiesOfSubModule( int ModsubModID )
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = secGUIMang.ViewRulesEntitiesOfSubModule( ModsubModID );
			}
			return ds;
		}
	

		
		[WebMethod ( EnableSession = true ), SoapHeader( "authHeader" ) ]
		public DataSet ViewModuleUserGroups( int modID )
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = gm.ViewModuleUserGroups( modID );
			}
			return ds;
		}

		[WebMethod ( EnableSession = true ), SoapHeader( "authHeader" ) ]
		public DataSet ViewModuleRuleGroups( int modID )
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = gm.ViewModuleRuleGroups( modID );
			}
			return ds;
		}


		[WebMethod ( EnableSession = true ), SoapHeader( "authHeader" ) ]
		public DataSet ViewRulesGroupsOfUserGroupInModule( int modID , int userGroupID )
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = gm.ViewRulesGroupsOfUserGroupInModule( modID , userGroupID );
			}
			return ds;
		}


		[WebMethod ( EnableSession = true ), SoapHeader( "authHeader" ) ]
		public DataSet ViewUsersGroupsOfRuleGroupInModule( int modID , int ruleGroupID )
		{
			DataSet ds = new DataSet();
			if( authHeader != null )
			{
				JoinSession( );
				ds = gm.ViewUsersGroupsOfRuleGroupInModule( modID , ruleGroupID );
			}
			return ds;
		}
	
		

		

		#endregion 
	}
}
