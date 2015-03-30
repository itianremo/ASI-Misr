using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using TSN.ERP.Engine;
namespace TSN.ERP.Presentation
{
	/// <summary>
	/// The Master Service for ERP Web services
	/// </summary>
	/// 
	public class ERPMasterService : System.Web.Services.WebService
	{
		public TSN.ERP.Presentation.AuthHeader Authenticator = new AuthHeader(); 
		protected Engine.ServerShell Shell = new TSN.ERP.Engine.ServerShell();
		private Engine.Session _ERPSession;
		private bool _Authenticated = false;
		public static ERPMasterService SessionMasterService;

		public ERPMasterService()
		{
			InitializeComponent();
			if (SessionMasterService == null)
				SessionMasterService = this;
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
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		#region Login and Session 


		[WebMethod (EnableSession = true)]
		public bool GetERPSession(string UserToken)
		{	
			string TokenString = UserToken;
			_ERPSession = this.Shell.GetSession(TokenString);
			if( _ERPSession == null)
			{
				this._Authenticated = false;
			}
			else
			{
				Session.Add("ERPSession",_ERPSession);
				this._Authenticated = true;
			}
			return this._Authenticated;
		}


		//Logs in if the Session is not authenticated
		[WebMethod (EnableSession = true)]
		public string Login(string userName, string passWord)
		{

			this._ERPSession = this.Shell.LogIn(userName,passWord);
			if (this._ERPSession!=null)
			{
				Session.Add("UserID",this._ERPSession.UserId);
				Session.Add("Token",this._ERPSession.Token);
				Session.Add("ERPSession", this._ERPSession);
				return this._ERPSession.Token;
			}
			return null;
		}
		#endregion

		# region Getting Bussines Objects
		public BussinesObject GetInstance(string TypeName, string AssemblyName)
		{
			return this.ERPSession.GetInstance(TypeName,AssemblyName);
		}
		# endregion

		# region Identification Properties

		public bool Authenticated
		{
			get
			{
				return this._Authenticated;
			}
		}
		public Engine.Session ERPSession
		{
			get
			{
				object TempObject = Session["ERPSession"];
				if (TempObject==null)
					throw new Exception ("TSN ERP Server: Cannot Load ERP Session");
				this._ERPSession  = (Engine.Session)TempObject;
				return this._ERPSession;
			}
		}
		public string Token
		{
			get
			{
				return ERPSession.Token;
			}
		}

		#endregion		

		
	}
}
