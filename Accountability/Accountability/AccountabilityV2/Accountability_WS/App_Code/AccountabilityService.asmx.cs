using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using TSN.ERP.Engine;
using TSN.ERP.SharedComponents;
using TSN.ERP.Presentation;
namespace SharedPresentation
{
	/// <summary>
	/// Summary description for AccountabilityService.
	/// </summary>
	/// 

	
	public class AccountabilityService :ERPMasterService 
	{
		EmployeeAccountabiltiy AccManager;
		public AccountabilityService()
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
			if (AccManager != null)
				//AccManager.Dispose();
				AccManager=null;
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion


		[WebMethod (Description = "Updates an Accountability Sheet"
			 ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet UpdateSheet(DataSet AccountabilitySheet,int empID, DateTime AccDate,int ViewType)
		{
			LoadAccountabilityManager();
//			AccManager.Employee = empID;
//			AccManager.SheetDate = AccDate;
			AccManager.SheetView  = (EmployeeAccountabiltiy.View)ViewType;
			if (AccManager.Update(AccountabilitySheet,empID,AccDate))
				return new TSN.ERP.SharedComponents.Data.dsAccountabilitySheet();
			return null;
		}

		[WebMethod (Description = "Updates an Accountability Sheet for One Day only"
			 ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet UpdateSheetForDay(DataSet AccountabilitySheet,int empID, DateTime AccDate,int ViewType, bool IsUpdateOneDateOnly)
		{
			LoadAccountabilityManager();
			//			AccManager.Employee = empID;
			//			AccManager.SheetDate = AccDate;
			AccManager.SheetView  = (EmployeeAccountabiltiy.View)ViewType;
			if (AccManager.Update(AccountabilitySheet,empID,AccDate,IsUpdateOneDateOnly))
				return new TSN.ERP.SharedComponents.Data.dsAccountabilitySheet();
			return null;
		}

		[WebMethod (Description = "Set the employee Id for the accountability sheet manager"
			 ,EnableSession = true) , SoapHeader("Authenticator")]
		public void CureentEmployee(int EmployeeID)
		{
			LoadAccountabilityManager();
			AccManager.Employee = EmployeeID;
		}
		[WebMethod (Description = "Set the current date for the accountability sheet manager"
			 ,EnableSession = true) , SoapHeader("Authenticator")]
		public void SheetDate(DateTime AccDate)
		{
			LoadAccountabilityManager();
			AccManager.SheetDate = AccDate;
		}
		[WebMethod (Description = "Choose the type of sheet view used by the accountability manager, General = 10, Projectts = 30"
			 ,EnableSession = true) , SoapHeader("Authenticator")]
		public void SheetView(int ViewType)
		{
			LoadAccountabilityManager();
			AccManager.SheetView = (EmployeeAccountabiltiy.View) ViewType;
		}
//		[WebMethod (Description = "Reloads and returns the accountability based on the sheet settings (employee, date, view),returns a data set of type (TSN.ERP.SharedComponents.Data.dsAccountabilitySheet)"
//			 ,EnableSession = true) , SoapHeader("Authenticator")]
//		public DataSet Refresh()
//		{
//			LoadAccountabilityManager();
//			return AccManager.Refresh();
//		}

		[WebMethod (Description = "gets a list of employees which the current user has access to their accountability sheet"
			 ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ViewAccountabilityEmployees()
		{
			LoadAccountabilityManager();
			return AccManager.ViewAccountabilityEmployees();
		}

		[WebMethod (Description = "Gets the accountability sheet loaded by the last refresh ,returns a data set of type (TSN.ERP.SharedComponents.Data.dsAccountabilitySheet) "
			 ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet Load()
		{
			LoadAccountabilityManager();
			return AccManager.AccountabilitySheet;
		}
		private void LoadAccountabilityManager()
		{
			//AccManager = (EmployeeAccountabiltiy) GetInstance("TSN.ERP.SharedComponents.EmployeeAccountabiltiy","TSN.ERP.SharedComponents");
			AccManager = new EmployeeAccountabiltiy();
			AccManager.JoinSession(Token);
		}

		[WebMethod (Description = "",EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet GetTotalAccSheet(DateTime sheetDate,string filter)
		{	
			LoadAccountabilityManager();
			return AccManager.GetTotalAccSheet(sheetDate,filter,10);
		}

		[WebMethod (Description = "Gets the accountability sheet loaded by the last refresh ,returns a data set of type (TSN.ERP.SharedComponents.Data.dsAccountabilitySheet) "
			 ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet GetAccSheet(int empID, DateTime AccDate,int ViewType,bool showOffDays)
		{
			LoadAccountabilityManager();
			return AccManager.GetAccSheet(empID,AccDate,(EmployeeAccountabiltiy.View)ViewType,showOffDays);
		}	
		//-------------------------------------------------------
		[WebMethod (Description = "Gets the accountability sheet for given assignment"
			 ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet GetAssigmentAccountability(int assignmentID)
		{
			LoadAccountabilityManager();
			return AccManager.AccountabilityTotalEntries(assignmentID);
		}

		/////
		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public bool SetAccountabilityValue(int AssginmentID,double AccValue, DateTime AccDate)
		{
			LoadAccountabilityManager();
			return AccManager.SetAccountabilityValue( AssginmentID, AccValue, AccDate);
		}

		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public bool SaveNote(DateTime NoteDate, string NoteBody , int ContactID )
		{
			LoadAccountabilityManager();
			return AccManager.SaveNote( NoteDate, NoteBody , ContactID );
		}
		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public bool SaveNoteInSpecificDate(DateTime NoteDate, string NoteBody , int ContactID )
		{
			LoadAccountabilityManager();
			return AccManager.SaveNoteInSpecificDate( NoteDate, NoteBody , ContactID );
		}


		// --- Added By Basant 18-Oct-2006
		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet GetEmployeeTaskSummary( int ContactID , DateTime FromDate , DateTime ToDate )
		{
			LoadAccountabilityManager();
			return AccManager.GetEmployeeTaskSummary( ContactID, FromDate , ToDate );
			
		}
		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet GetEmployeeNotesInInterval( int ContactID , DateTime FromDate , DateTime ToDate )
		{
			LoadAccountabilityManager();
			return AccManager.GetEmployeeNotesInInterval( ContactID, FromDate , ToDate );
			
		}

	
	}
}
