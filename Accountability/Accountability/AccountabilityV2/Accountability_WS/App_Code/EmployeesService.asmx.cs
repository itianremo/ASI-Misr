using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using TSN.ERP.Presentation;
using TSN.ERP.Engine;
using TSN.ERP.SharedComponents;
namespace SharedPresentation
{
	/// <summary>
	/// Summary description for EmployeesService.
	/// </summary>
	public class EmployeesService : TSN.ERP.Presentation.ERPMasterService 
	{
		private TSN.ERP.SharedComponents.EmployeesManager EmpManager;
		public EmployeesService()
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
			if (EmpManager != null)
				//EmpManager.Dispose();
				EmpManager=null;
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		#region AddEmployees

		[WebMethod (Description = "Add New Employees to the system,takes the employees contact data in a dataset of type (TSN.ERP.SharedComponents.Data.dsContacts ) and the employees data as dataset of type (TSN.ERP.SharedComponents.Data.dsEmployee)"
			 ,EnableSession = true) , SoapHeader("Authenticator")]
		public int AddEmployees(DataSet EmployeesData)
		{
			LoadEmpManager();
			return EmpManager.AddEmployee(EmployeesData);
		}

		#endregion 

		#region DeleteEmployee

		[WebMethod (Description = "Deletes an Existing Employee, takes a dataset of type (TSN.ERP.SharedComponents.Data.dsEmployee)"
			 ,EnableSession = true) , SoapHeader("Authenticator")]
		public int DeleteEmployee(DataSet DeletedEmployees)
		{
			LoadEmpManager();
			return EmpManager.DeleteEmployee(DeletedEmployees);
		}

		#endregion 

		#region ModifyEmployee

		[WebMethod (Description = "Modifies an Existing Employee, takes a dataset of type (TSN.ERP.SharedComponents.Data.dsEmployee)"
			 ,EnableSession = true) , SoapHeader("Authenticator")]
		public int ModifyEmployee(DataSet ModifiedEmployees)
		{
			LoadEmpManager();
			return EmpManager.EditEmployee(ModifiedEmployees);
		}

		#endregion 

		#region ListEmployees

		[WebMethod (Description = "List All Employees Data, returns a dataset of type (TSN.ERP.SharedComponents.Data.dsEmployee) "
			 ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListEmployees()
		{
			LoadEmpManager();
			return EmpManager.ListEmployeesDetailedData();
		}

		#endregion 

		#region ListEmployeesDetailedData

		[WebMethod (Description = "List All Employees Detailed Data, returns a dataset of type (TSN.ERP.SharedComponents.Data.dsEmployee) "
			 ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListEmployeesDetailedData()
		{
			LoadEmpManager();
			return EmpManager.ListEmployeesDetailedData();
		}

		[WebMethod (Description = "List All Employees Detailed Data, returns a dataset of type (TSN.ERP.SharedComponents.Data.dsEmployee) "
			 ,EnableSession = true, MessageName = "ListEmployeesDetailedDataByQuery") , SoapHeader("Authenticator")]
		public DataSet ListEmployeesDetailedData(string FilterString)
		{
			LoadEmpManager();
			return EmpManager.ListEmployeesDetailedData(FilterString);
		}
		#endregion 

		#region ListSingleEmployeeData

		[WebMethod (Description = "List Employees Detailed Data for a Single Employee, returns a dataset of type (TSN.ERP.SharedComponents.Data.dsEmployee) "
			 ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListSingleEmployeeData(int EmployeeID)
		{
			LoadEmpManager();
			return EmpManager.ListEmployeesDetailedData(EmployeeID);
		}

		#endregion 

		#region ListEmployeeSummarizedData

		[WebMethod (Description = "List Employees Detailed(Job Title Name And Dept Name) Data for a Single Employee, returns a dataset of type (TSN.ERP.SharedComponents.Data.dsEmployee) "
			 ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListEmployeeSummarizedData(int EmployeeID)
		{
			LoadEmpManager();
			return EmpManager.ListEmpSummData(EmployeeID);
		}

		#endregion 

		#region ListActiveEmployees
		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListActiveEmployees( )
		{
			LoadEmpManager();
			return  EmpManager.ListActiveEmployees( );
		}


		#endregion

		#region ListTerminatedEmployees
		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListTerminatedEmployees( )
		{
			LoadEmpManager();
			return  EmpManager.ListTerminatedEmployees( );
		}

		#endregion 

		#region TerminateEmployee
		[WebMethod (Description = "" ,EnableSession = true) , SoapHeader("Authenticator")]
		public int TerminateEmployee( DataSet dsEmployees )
		{
			return EmpManager.TerminateEmployee(dsEmployees);
		}

		#endregion 

		#region Add Employees Jobtitle

		[WebMethod (Description = "Add new employee job title to the GEN_EmployeesJobTitles" ,EnableSession = true) , SoapHeader("Authenticator")]
		public int AddEmployeesJobTitle(int EmployeeID, int JobTitleID, DateTime JobDate)
		{
			LoadEmpManager();
			return EmpManager.AddEmployeeJobTitle(EmployeeID, JobTitleID, JobDate);
		}

		#endregion 


		public void LoadEmpManager()
		{
			//EmpManager = (TSN.ERP.SharedComponents.EmployeesManager)GetInstance("TSN.ERP.SharedComponents.EmployeesManager","TSN.ERP.SharedComponents" );
			EmpManager = new EmployeesManager();
			EmpManager.JoinSession(Token);
		}


	}
}
