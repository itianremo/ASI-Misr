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
	/// Summary description for Service1.
	/// </summary>
	public class CompanyStucture : ERPMasterService
	{
		protected CompanyStructure CompStruct;
		public CompanyStucture()
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
			if (CompStruct != null)
				//CompStruct.Dispose();
				CompStruct=null;
			if(disposing && components != null)
			{
				components.Dispose();
				
			}
			base.Dispose(disposing);		
		}
		
		#endregion


		[WebMethod (Description = "Lists All avliable comapny elements, returns a DataSet of type (TSN.ERP.SharedComponents.Data.dsCompanyElementLevels)"
			 ,EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListCompanyElementLevels()
		{	
			LoadCampanyComponent();
			return CompStruct.ListCompanyElmentsLevels();
		}

		[WebMethod (Description = "Adds Child Elements to a given paretn elements, takes a DataSet of type (TSN.ERP.SharedComponents.Data.dsCompanyElementLevels)"
			 ,EnableSession = true) , SoapHeader("Authenticator")]
		public int AddChildCompanyElements(int parentID, DataSet newEements)
		{
			LoadCampanyComponent();
			return CompStruct.AddChildCompanyElements(parentID,newEements);
		}
		[WebMethod (Description = "Can be used to Delete or update and exisiting Company Element, Takes a Data Set of type (TSN.ERP.SharedComponents.Data.dsCompanyElementLevels) "
			 ,EnableSession = true) , SoapHeader("Authenticator")]
		public int ModifyCompanyElmentLevels(DataSet ModifiedElements)
		{
			LoadCampanyComponent();
			if (CompStruct.DeleteCompanyElmentsLevels(ModifiedElements)>= 0)
				if (CompStruct.EditCompanyElments(ModifiedElements)>= 0 )
					if(CompStruct.AddCompanyElments(ModifiedElements) >= 0)
						return 1;
			return -1;
		}

		[WebMethod (Description ="List Company Elemnts, Such as Divisions, Departments or any other type that is avliable, return a Dataset of type(TSN.ERP.SharedComponents.Data.dsCompanyElements)",
		EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListCompnayElements()
		{
			LoadCampanyComponent();
			return CompStruct.ListCompanyElments();
		}

		[WebMethod (Description = "Add new Company Elements , takes DataSet of type (TSN.ERP.SharedComponents.Data.dsCompanyElements) ",
			 EnableSession = true) , SoapHeader("Authenticator")]
		public int AddCompanyElements(DataSet NewElements)
		{
			LoadCampanyComponent();
			return CompStruct.AddCompanyElments(NewElements);
		}


		[WebMethod (Description = "used to Edit an exisiting company element, takes a dataset of type (TSN.ERP.SharedComponents.Data.dsCompanyElements)",
		EnableSession = true) , SoapHeader("Authenticator")]
		public int ModifyCompanyElemenets(DataSet ModifiedElemnts)
		{
			LoadCampanyComponent();
			return CompStruct.EditCompanyElments(ModifiedElemnts);
		}

		[WebMethod (Description = "Deletes Exsisting Company Elements, takes a dataset of type (TSN.ERP.SharedComponents.Data.dsCompanyElements)",
			 EnableSession = true) , SoapHeader("Authenticator")]
		public int DeleteCompanyElements(DataSet DeletedElements)
		{
			LoadCampanyComponent();
			return CompStruct.DeleteCompanyElments(DeletedElements);
		}


		[WebMethod (Description = "Lists the cildren of a given company elements, returns a dataset of type (TSN.ERP.SharedComponents.Data.dsCompanyElements)",
			 EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListChildrenElments(int ParentElementID)
		{
			LoadCampanyComponent();
			return CompStruct.ListChildrenElements(ParentElementID);
		}


		protected void LoadCampanyComponent()
		{
			//CompStruct  = (CompanyStructure)this.GetInstance("TSN.ERP.SharedComponents.CompanyStructure","TSN.ERP.SharedComponents");
			CompStruct = new CompanyStructure();
			CompStruct.JoinSession(Token);
		}
	}
}
