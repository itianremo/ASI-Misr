using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using TSN.ERP.Presentation;
using  TSN.ERP;


namespace TimingWS
{
	/// <summary>
	/// Summary description for Service1.
	/// </summary>
	public class TimingWS : ERPMasterService 
	{
		TSN.ERP.Timing.CompanySettingsManager compSettingsManager;
		TSN.ERP.Timing.SpecialTimingManager specialTimingManager;
		TSN.ERP.Timing.CheckInOutManager checkInOutManager;


		public TSN.ERP.Presentation.AuthHeader authHeader = new TSN.ERP.Presentation.AuthHeader();		

		public TimingWS()
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
			if (compSettingsManager != null)
				compSettingsManager=null;

			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion
	

		#region Company Settings Management

		[WebMethod ( EnableSession = true ), SoapHeader( "authHeader" ) ]
		public int EditTimingCompanySettings(DataSet ds)
		{
			LoadCompanySettingsManager();
			int ReturnValue = compSettingsManager.EditTimingCompanySettings( ds );
			return ReturnValue;
		}


		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListCompanyTimingSettings( )
		{
			LoadCompanySettingsManager();
			return compSettingsManager.ListTimingCompanySettings();
		}

		#endregion

		#region Special Timing Management

		[WebMethod ( EnableSession = true ), SoapHeader( "authHeader" ) ]
		public int EditSpecialTiming(DataSet ds)
		{
			LoadSpecialTimingManager();
			int ReturnValue = specialTimingManager.EditSpecialTime( ds );
			return ReturnValue;
		}


		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListSpecialTiming( )
		{
			LoadSpecialTimingManager();
			return specialTimingManager.ListSpecialTiming();
		}

		#endregion


		#region CheckInOut Manager

		[WebMethod ( EnableSession = true ), SoapHeader( "authHeader" ) ]
		public DataSet UpdateCheckInOut(DataSet ds)
		{
			LoadCheckInOutManager();
			return checkInOutManager.mUpdateCheckInOut( ds );
		}
		[WebMethod ( EnableSession = true ), SoapHeader( "authHeader" ) ]
		public DataSet DeleteCheckInOut(DataSet ds)
		{
			LoadCheckInOutManager();
			return checkInOutManager.mDeleteCheckInOut( ds );
		}
		[WebMethod ( EnableSession = true ), SoapHeader( "authHeader" ) ]
		public DataSet AddCheckInOut(DataSet ds)
		{
			LoadCheckInOutManager();
			return checkInOutManager.mAddCheckInOut( ds );
		}


		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet GetCheckInOut(DataSet ds )
		{
			LoadSpecialTimingManager();
			return checkInOutManager.mAddCheckInOut(ds);
		}

		#endregion


		#region Load Managers

		public void LoadCompanySettingsManager()
		{
			compSettingsManager = new TSN.ERP.Timing.CompanySettingsManager();
			compSettingsManager.JoinSession(Token);
		}

		public void LoadSpecialTimingManager()
		{
			specialTimingManager = new TSN.ERP.Timing.SpecialTimingManager();
			specialTimingManager.JoinSession(Token);
		}
		public void LoadCheckInOutManager()
		{
			checkInOutManager = new TSN.ERP.Timing.CheckInOutManager();
			checkInOutManager.JoinSession(Token);
		}
		#endregion
	}
}
