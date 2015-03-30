using System;
using System.Web.UI;
using System.Collections;

namespace TSN.ERP.WebGUI.Navigation
{
	/// <summary>
	/// Summary description for BaseObject.
	/// </summary>
	public class BaseObject
	{
		
		public int Module;
		public int Link;
		public int Function;
		public string UserControl;
		public string Token;
		public OperationType Operation;
		public int EntityID;
		public string EntityDescription;

		public SecurityWS.SecurityManagement SecurityWsObject ;
		public MasterWS.ERPMasterService ERPmasterObject;
		public GUIWS.GUI GUIWsObject ;
		public CompanyStruct.CompanyStucture CompanyWsObject ;
		public ContactsWS.ContactsService    ContactWsObject ;
		public EmployeesWS.EmployeesService  EmployeeWsObject ;
		public JobTitlesWS.JobTitles  JobTiltesWsObject ;
		public SharedCompWS.ERPSessionServices SessionWSObject;
		public ProjectsWS.ProjectsService ProjectWSObject;
		public TaskWS.TasksService TaskWSObject;
		public AccountabilityWS.AccountabilityService AccountabilityWSObject;
        public TeamsWS.TeamsService TeamsWSObject;
		public GeneralWS.GeneralService GeneralWSObject;
		public OrgnizationChartsWS.OrgnizationChartsMangmentService OrgnizationChartsWSObject;
		public SecurityInfo SecInfo;
		public CrysatlReportsWS.CrysatlReportsService  CrystalReportsWSObject;
		public MFGAccWS.MFGAccountability MFGWSObject;
		public TimingWS.TimingWS TimingWSObject;
//		public TimingCompanySettings.TimingCompanySettings TimingCompanySettings;
		
			
		public BaseObject()
		{
//           ERPmasterObject   = new TSN.ERP.WebGUI.MasterWS.ERPMasterService();
//			SecurityWsObject = new TSN.ERP.WebGUI.SecurityWS.SecurityManagement();
//			GUIWsObject		 = new TSN.ERP.WebGUI.GUIWS.GUI();
//			CompanyWsObject  = new TSN.ERP.WebGUI.CompanyStruct.CompanyStucture();
//			ContactWsObject  = new TSN.ERP.WebGUI.ContactsWS.ContactsService();
//			EmployeeWsObject = new TSN.ERP.WebGUI.EmployeesWS.EmployeesService();
//			JobTiltesWsObject= new TSN.ERP.WebGUI.JobTitlesWS.JobTitles();
//			SessionWSObject  = new TSN.ERP.WebGUI.SharedCompWS.ERPSessionServices(); 
//			ProjectWSObject  = new TSN.ERP.WebGUI.ProjectsWS.ProjectsService();
//			OrgnizationChartsWSObject = new TSN.ERP.WebGUI.OrgnizationChartsWS.OrgnizationChartsMangmentService();
//			AccountabilityWSObject = new TSN.ERP.WebGUI.AccountabilityWS.AccountabilityService();

			SecInfo			 = new SecurityInfo();

//			CrystalReportsWSObject = new  TSN.ERP.WebGUI.CrysatlReportsWS.CrysatlReportsService();
//			MFGWSObject = new TSN.ERP.WebGUI.MFGAccWS.MFGAccountability();
			
		}

		public enum OperationType { ADD , UPADATE , DELETE } ;

		public static void showCallErrorMessage( string msg , System.Web.UI.Page page , string token )
		{
			SharedCompWS.ERPSessionServices erpSession = new TSN.ERP.WebGUI.SharedCompWS.ERPSessionServices();
			SharedCompWS.AuthHeader authHeder = new TSN.ERP.WebGUI.SharedCompWS.AuthHeader();
			
			authHeder.Token = token;
			erpSession.AuthHeaderValue = authHeder;
	
			string lastError = erpSession.LastSecurityError();
			page.Response.Write ( "<script language=javascript > alert ( " + msg + lastError + " ) </script>" ) ;
		}
		public static bool SafeMerge(System.Data.DataSet MainDataSet, System.Data.DataSet SeconderyDataSet)
		{
			if (SeconderyDataSet !=null)
			{
				MainDataSet.Merge(SeconderyDataSet);
				return true;
			}
			else
			{
				return false;
			}
		}

		public static void showMessage( string msg , System.Web.UI.Page page )
		{
			msg =  msg.Replace( "\n" , " " ); 
//			page.Response.Write ( "<script language=javascript > alert ( '" + msg + "' ) </script>" ) ;
			//Hamdy : I replaced page.Response with page.RegisterStartupScript to avoid FF problems with 'Response'

            // added by Sayed to avoid error of IE8  3-8-2009
            if (msg.Contains("html"))
            {
                msg = "There is error related to browser";
            }
            // end added

			page.RegisterStartupScript("ShowAlert","<script language=javascript > alert ( '" + msg + "' ) </script>");
		}

		public bool CheckUserAccessRule( ArrayList rules )
		{
			bool visibility = true;
			
			if (  SecInfo.IsAdministrator )
				return true;

			for( int i = 0 ; i < SecInfo.RulesArray.Count ; i++ )
			{
				int[] elm = new int[2];
				elm = (int[]) SecInfo.RulesArray[ i ];
				for ( int j = 0 ; j < rules.Count ; j++ )
				{
					if( elm[ 0 ] == Convert.ToInt32( rules[ j ] ) )
					{
						if ( elm[ 1 ] == -1 )
							return visibility ;
						else if( elm[ 1 ] ==  EntityID )
							return visibility ;
						
					}
				}
			}
			visibility = false ;
			return  visibility ;
		}


		

	}
}
