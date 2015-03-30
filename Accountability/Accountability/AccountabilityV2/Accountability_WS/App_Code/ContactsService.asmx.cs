using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using TSN.ERP.Presentation;
using TSN.ERP.SharedComponents;
namespace SharedPresentation
{
	/// <summary>
	/// Summary description for ContactsService.
	/// </summary>
	public class ContactsService : ERPMasterService 
	{
		private ContactsManager ContManager;

		public ContactsService()
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
			if (ContManager != null)
				//ContManager.Dispose();
				ContManager=null;
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		#region Contacts

		#region List
		[WebMethod (Description = "Lists All Contacts Data, returns a Dataset of type (TSN.ERP.SharedComponents.Data.dsContacts)", EnableSession = true) , SoapHeader("Authenticator")]
		public  DataSet ListContactsData()
		{
			LoadContactsClass();
            return ContManager.ListContactsData();
		}

		[WebMethod (Description = "List the details for a given contact, returns a dataset of type (TSN.ERP.SharedComponents.Data.dsContacts)",
			 EnableSession = true, MessageName = "ListContactByID") , SoapHeader("Authenticator")]
		public DataSet ListContactsData(int ContactID)
		{
			LoadContactsClass();
			return ContManager.ListContactsData(ContactID);
		}
		
		[WebMethod (Description = "List the details for a given Query, returns a dataset of type (TSN.ERP.SharedComponents.Data.dsContacts)",
			 EnableSession = true , MessageName = "ListContactByQuery") , SoapHeader("Authenticator")]
		public DataSet ListContactsData(string filterString)
		{
			LoadContactsClass();
			return ContManager.ListContactsData(filterString);
		}

		#endregion
		
		[WebMethod (Description = "Adds new contacts to the system , takes dataset of type (TSN.ERP.SharedComponents.Data.dsContacts)",EnableSession = true) , SoapHeader("Authenticator")]
		public int AddContact(DataSet NewContacts)
		{
			LoadContactsClass();
			return ContManager.AddContact(NewContacts);
		}


		[WebMethod (Description = "Edit exsisting contact data, takes a dataset of type (TSN.ERP.SharedComponents.Data.dsContacts)",EnableSession = true) , SoapHeader("Authenticator")]
		public int EditContact(DataSet ModifiedContects)
		{
			LoadContactsClass();
			return ContManager.EditContact(ModifiedContects);
		}

		[WebMethod (Description = "Edit exsisting contact data, takes a dataset of type (TSN.ERP.SharedComponents.Data.dsContacts)",EnableSession = true) , SoapHeader("Authenticator")]
		public int UpdateContactUserID( int userID , int contactID )
		{
			LoadContactsClass();
			return ContManager.UpdateContactUserID( userID , contactID );
		}
				

		#endregion 

		#region Addresses
		[WebMethod (Description = "Lists the addresses for a given contact,return a dataset of type (TSN.ERP.SharedComponents.Data.dsAddress)",EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListContactAddress(int ContactID)
		{
			LoadContactsClass();
			return ContManager.ListContactAddress(ContactID);
		}
		[WebMethod (Description = "",EnableSession = true) , SoapHeader("Authenticator")]
		public int UpdateAddress(DataSet dsAddress)
		{
			LoadContactsClass();
			return ContManager.UpdateContactAddress(dsAddress);
		}

		[WebMethod (Description = "",EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet  GetContactPrimaryAddress(int ContactID)
		{
			LoadContactsClass();

			return ContManager.GetContactPrimaryAddress( ContactID);
		} 

		#endregion

		#region PhoneBook
		[WebMethod (Description = "List the Phones for a specific contact",EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListContactPhones(int ContactID)
		{
			LoadContactsClass();
			return ContManager.ListContactPhones(ContactID);
		}
		[WebMethod (Description = "s",EnableSession = true) , SoapHeader("Authenticator")]
		public int UpdatePhoneBook(DataSet dsPhones)
		{
			LoadContactsClass();
			return ContManager.UpdateContactPhones(dsPhones);
		}

		[WebMethod (Description = "",EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListPrimayContactPhones(int ContactID)
		{
			LoadContactsClass();
			return ContManager.ListPrimayContactPhones( ContactID );
		}

		#endregion

		#region City
		
		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListAllCities(  )
		{
			LoadContactsClass();
			return ContManager.ListAllCities( );
		}

		
		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListCity( int cityID  )
		{	
			LoadContactsClass();
			return ContManager.ListCity( cityID );
		}


		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int  UpdateCity( DataSet ds )
		{
			LoadContactsClass();
			return ContManager.UpdateCity( ds );
		}


		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int  DeleteCity( DataSet ds )
		{
			LoadContactsClass();
			return ContManager.DeleteCity( ds );
		}


		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet  ListAllStateCities(  int stateID )
		{
			LoadContactsClass();
			return ContManager.ListAllStateCities( stateID );
		}


		#endregion

		#region States

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListAllStates(  )
		{
			LoadContactsClass();
			return ContManager.ListAllStates( );
		}

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListState( int stateID  )
		{	
			LoadContactsClass();
			return ContManager.ListState( stateID );
		}

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int  UpdateState( DataSet ds )
		{
			LoadContactsClass();
			return ContManager.UpdateState( ds );
		}

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]	
		public int  DeleteState( DataSet ds )
		{
			LoadContactsClass();
			return ContManager.DeleteState( ds );
		}

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet  ListAllCountryStates( int countryID )
		{
			LoadContactsClass();
			return ContManager.ListAllCountryStates( countryID );
		}

		#endregion

		#region Countries

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListAllCountries(  )
		{
			LoadContactsClass();
			return ContManager.ListAllCountries( );
		}

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListCountry( int stateID  )
		{
			LoadContactsClass();
			return ContManager.ListCountry( stateID );
		}

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int  UpdateCountry( DataSet ds )
		{
			LoadContactsClass();
			return ContManager.UpdateCountry( ds );
		}

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int  DeleteCountry( DataSet ds )
		{
			LoadContactsClass();
			return ContManager.DeleteCountry( ds );
		}

		
		#endregion

		#region Emails
		
		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListAllEmails(  )
		{
			LoadContactsClass();
			return ContManager.ListAllEmails( );
		}

		
		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int  UpdateEmail( DataSet ds )
		{
			LoadContactsClass();
			return ContManager.UpdateEmail( ds );
		}


		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int  DeleteEmail( DataSet ds )
		{
			LoadContactsClass();
			return ContManager.DeleteEmail( ds );
		}


		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet  ListAllCotactEmails( int contactID )
		{
			LoadContactsClass();
			return ContManager.ListAllCotactEmails( contactID );
		}

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet  ListCotactsAndEmails( int emailType )
		{
			LoadContactsClass();
			return ContManager.ListAllCotactsAndEmails(emailType);
		}


//		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
//		public DataSet  ListContactPrimaryEmail( int contactID )
//		{
//			LoadContactsClass();
//			return ContManager.ListContactPrimaryEmail( contactID );
//		}

		#endregion
		
		#region WebSites

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListAllWebSites(  )
		{
			LoadContactsClass();
			return ContManager.ListAllWebSites( );
		}

		
		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int  UpdateWebSite( DataSet ds )
		{
			LoadContactsClass();
			return ContManager.UpdateWebSite( ds );
		}


		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int  DeleteWebSite( DataSet ds )
		{
			LoadContactsClass();
			return ContManager.DeleteWebSite( ds );
		}


		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet  ListAllCotactWebSite( int contactID )
		{
			LoadContactsClass();
			return ContManager.ListAllCotactWebSite( contactID );
		}


		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet  ListContactPrimaryWebSite( int contactID )
		{
			LoadContactsClass();
			return ContManager.ListContactPrimaryWebSite( contactID );
		}

		#endregion


		public void LoadContactsClass()
		{
			//ContManager = (ContactsManager)GetInstance("TSN.ERP.SharedComponents.ContactsManager","TSN.ERP.SharedComponents");
			ContManager = new ContactsManager();
			ContManager.JoinSession(Token);
		}
	}
}
