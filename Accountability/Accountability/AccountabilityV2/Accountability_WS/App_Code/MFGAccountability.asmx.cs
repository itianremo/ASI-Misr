using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using TSN.ERP.SharedComponents;
using TSN.ERP.Presentation;

namespace SharedPresentation
{
	/// <summary>
	/// Summary description for MFGAccountability.
	/// </summary>
	public class MFGAccountability : ERPMasterService
	{
		protected MFGAccountabilityManager MfgMng;
		public MFGAccountability()
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
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		[WebMethod (Description = "", EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListEmployeeMFGTasks( int ContactID , DateTime Date )
		{
			LoadMfgAcc();
			return MfgMng.ListEmployeeMFGTasks( ContactID , Date);
		}

		#region SaveMFGTasksSheet

		[WebMethod (Description = "", EnableSession = true) , SoapHeader("Authenticator")]
		public void SaveMFGTasksSheet( DataSet dsMFGTasks )
		{
			
			LoadMfgAcc();
			MfgMng.SaveMFGTasksSheet( dsMFGTasks );
		}
		#endregion

		#region GetAllMFGEmployees
		[WebMethod (Description = "", EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet GetAllMFGEmployees( )
		{
			LoadMfgAcc();
			return MfgMng.GetAllMFGEmployees( this.ERPSession.UserId );
		}

		[WebMethod (Description = "", EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet GetMFGAdminEmployees( int UserID )
		{
			LoadMfgAcc();
			return MfgMng.GetMFGAdminEmployees( UserID );
		}

		#endregion

		#region User IS MFG Admin 
		[WebMethod (Description = "", EnableSession = true) , SoapHeader("Authenticator")]
		public Boolean UserIsMFGAdmin( int UserID )
		{
			LoadMfgAcc();
			return MfgMng.UserIsMFGAdmin( UserID );
		
		}
		#endregion

		#region User IS MFG Admin Or MFG Employee
		[WebMethod (Description = "", EnableSession = true) , SoapHeader("Authenticator")]
		public Boolean UserIsMFGAdminOrEmployee( )
		{
			LoadMfgAcc();
			return MfgMng.UserIsMFGAdminOrEmployee( ERPSession.UserId );
		
		}
		#endregion

		#region DeleteMFGAdmin
		[WebMethod (Description = "", EnableSession = true) , SoapHeader("Authenticator")]
		public int DeleteMFGAdmin( int MFGAdminUsrID )
		{
			LoadMfgAcc();
			return MfgMng.DeleteMFGAdmin( MFGAdminUsrID );
		}
		#endregion

		#region AddMFGAdminEmployees
		[WebMethod (Description = "", EnableSession = true) , SoapHeader("Authenticator")]
		public void AddMFGAdminEmployees( int mfgAdminUsrID , DataSet dsMFGEmp )
		{
			LoadMfgAcc();
			MfgMng.AddMFGAdminEmployees( mfgAdminUsrID , dsMFGEmp );
		}
		#endregion

		#region GetAllMFGAdmins
		[WebMethod (Description = "", EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet GetAllMFGAdmins()
		{
			LoadMfgAcc();
			return MfgMng.GetAllMFGAdmins( );
		}
		#endregion

		protected void LoadMfgAcc()
		{
			//CompStruct  = (CompanyStructure)this.GetInstance("TSN.ERP.SharedComponents.CompanyStructure","TSN.ERP.SharedComponents");
			MfgMng = new MFGAccountabilityManager();
			MfgMng.JoinSession(Token);
		}
	}
}
