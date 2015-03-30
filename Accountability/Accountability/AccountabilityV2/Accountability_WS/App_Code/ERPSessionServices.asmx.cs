using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using TSN.ERP.Presentation;
namespace SharedPresentation
{
	/// <summary>
	/// Summary description for ERPSessionServices.
	/// </summary>
	public class ERPSessionServices : ERPMasterService
	{
		TSN.ERP.Engine.BussinesObject BO;
		public ERPSessionServices()
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
		{
			if (BO != null)
				//BO.Dispose();
				BO=null;
			
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion


		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public bool CheckUserAccess(int ruleID)
		{
			JoinSession();
			return BO.CheckUserAccess(ruleID);
		}

		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public bool IsUserAdmin()
		{
			//JoinSession();
			bool test = ERPSession.IsAdmin;
		   return test;

		}

		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public void LogOff()
		{
			ERPSession.LogOff();
		}

		#region Error Detection
		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public bool HasErrors()
		{
			return ERPSession.HasNewErrors();
		}
		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public string LastError()
		{	
			string tempstr = this.ERPSession.LastException;
			return tempstr;
		}
		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public string LastInnerException()
		{
			return this.ERPSession.LastException;
		}
		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public string LastSecurityError()
		{
			string tempstr = this.ERPSession.LastSecurityError;
			return tempstr;
		}
		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet LastDataSet()
		{
			//JoinSession();
			return ERPSession.LastDataSet; 
		}
		#endregion
		
		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public int GetUserContactID()
		{
			return ERPSession.ContactId; 
		}

		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public int GetLoggedUserID()
		{
			return ERPSession.UserId; 
		}
		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public string GetLoggedUserName()
		{
			return ERPSession.UserName; 
		}
		

		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public DateTime GetServerDateTime()
		{
			return DateTime.Now; 
		}

		[WebMethod (EnableSession = true) , SoapHeader("Authenticator")]
		public bool ChangePassword(string OldPassword,string NewPassword)
		{
			return ERPSession.ChangePaassword(OldPassword,NewPassword);
		}
		
		public void JoinSession()
		{
			BO = new TSN.ERP.Engine.BussinesObject();
			BO.JoinSession(Token);
		}
	}
}
