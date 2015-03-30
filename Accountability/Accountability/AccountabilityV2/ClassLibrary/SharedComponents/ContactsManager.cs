using System;
using System.Data; 
using TSN.ERP.Engine;
//using System.EnterpriseServices;
namespace TSN.ERP.SharedComponents
{
	/// <summary>
	/// Summary description for ContactsManager.
	/// </summary>
	/// 
	
	public class ContactsManager:Engine.BussinesObject 
	{
		// accesscode 4
		private Data.ContactsData ContactsData		= new TSN.ERP.SharedComponents.Data.ContactsData();
		private Data.AddressDataClass AddressData	= new TSN.ERP.SharedComponents.Data.AddressDataClass();
		private Data.PhonebookDataClass PhoneData	= new TSN.ERP.SharedComponents.Data.PhonebookDataClass();
		private Data.CityDataClass CityData			= new TSN.ERP.SharedComponents.Data.CityDataClass();
		private Data.StateDataClass stateData		= new TSN.ERP.SharedComponents.Data.StateDataClass();
		private Data.CountryDataClass countryData	= new TSN.ERP.SharedComponents.Data.CountryDataClass();
		private Data.EmailDataClass mailData		= new TSN.ERP.SharedComponents.Data.EmailDataClass();
		private Data.WebSitesDataClass webSiteData	= new TSN.ERP.SharedComponents.Data.WebSitesDataClass();

		public ContactsManager()
		{
			
			this.DataComponents.Add(ContactsData);
			this.DataComponents.Add(AddressData);
			this.DataComponents.Add(PhoneData);
			this.DataComponents.Add(CityData);
			this.DataComponents.Add(stateData);
			this.DataComponents.Add(countryData);
			this.DataComponents.Add(mailData);
			this.DataComponents.Add(webSiteData);
		}
		#region Contatcs
		/// <summary>
		/// List a spacific contact data using filter string.
		/// </summary>
		/// <param name="FilterString">string:Filter String to spacify the coantact</param>
		/// <returns>DataSet:Containing data of this contact</returns>
		public DataSet ListContactsData(string FilterString)
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListConactData  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListConactData );
				return  null;
			}
			return this.ContactsData.List(FilterString);
		}
		
		/// <summary>
		/// List all contacts data.
		/// </summary>
		/// <returns>DataSet:Containing data of all contacts</returns>
		[AtrERPMethodType (ERPMethodType.List ) ]
		public  DataSet ListContactsData()
		{
			//
            if ( ! ( ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListEmployeesDetailedData  ) ) )  )
			{
			SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListConactData );
				return  null;
			}
			return this.ContactsData.ListContactData();
		}

		/// <summary>
		/// List a spacific contact data using its ID.
		/// </summary>
		/// <param name="ContactID">int:Contact ID</param>
		/// <returns>DataSet:Containing data of this contact</returns>
		public DataSet ListContactsData(int ContactID)
		{
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListConactData  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListConactData );
				return  null;
			}
			return this.ContactsData.ListContactData(ContactID);
		}

		/// <summary>
		/// Add new contact.
		/// </summary>
		/// <param name="NewContacts">DataSet:Containing data of new contacts</param>
		/// <returns>Int:returns 1 if success and 0 if not</returns>
		public int AddContact(DataSet NewContacts)
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.AddContact  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.AddContact );
				return  0;
			}
			return this.ContactsData.Add(NewContacts);
		}

		/// <summary>
		/// Edit a contact
		/// </summary>
		/// <param name="EditedContects"></param>
		/// <returns>Int:returns 1 if success and 0 if not</returns>
		public int EditContact(DataSet EditedContects)
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.EditContact  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.EditContact );
				return  0;
			}
			return this.ContactsData.Edit(EditedContects);
		}

		/// <summary>
		/// Update contact for spacific user.
		/// </summary>
		/// <param name="userID">int:User ID</param>
		/// <param name="ContactID">int:Contact ID</param>
		/// <returns>Int:returns 1 if success and 0 if not</returns>
		public int UpdateContactUserID( int userID , int ContactID )
		{
			
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.EditContact  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.EditContact );
				return  0;
			}
			return this.ContactsData.UpdateContactUserID( userID , ContactID );
		}

		/// <summary>
		/// List contacts data.
		/// </summary>
		/// <returns>DataSet:Containing data of all contacts</returns>
		public DataSet LastContactsData()
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.LastContactsData  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.LastContactsData );
				return  null;
			}
			return  ContactsData.ComponentDataSet;
		}
		#endregion

		#region Phonebook
		/// <summary>
		/// Update contact phones.
		/// </summary>
		/// <param name="dsPhoneBook">DataSet:Containing data of phone</param>
		/// <returns>Int:returns 1 if success and 0 if not</returns>
		public int UpdateContactPhones(DataSet dsPhoneBook)
		{
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.UpdateContactPhones  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.UpdateContactPhones );
				return  0;
			}
			return PhoneData.Update(dsPhoneBook);
		}
		
		/// <summary>
		/// List phones for spacicfic contact.
		/// </summary>
		/// <param name="ContactID">int:Contact ID</param>
		/// <returns>DataSet:Containing data of contact phones</returns>
		[AtrERPMethodType(ERPMethodType.List , "GEN_Contacts" ) ]
		public DataSet ListContactPhones(int ContactID)
		{
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListContactPhones  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListContactPhones );
				return  null;
			}
			return PhoneData.ContactPhones(ContactID);
		}

		/// <summary>
		/// List primay contact phone.
		/// </summary>
		/// <param name="ContactID">int:Contact ID</param>
		/// <returns>DataSet:Containing data of contact phones</returns>
		public DataSet ListPrimayContactPhones(int ContactID)
		{
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListPrimayContactPhones  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListPrimayContactPhones );
				return  null;
			}
			return PhoneData.PrimaryContactPhones(ContactID);
		}

		#endregion

		#region Address

		/// <summary>
		/// List address for spacific contact.
		/// </summary>
		/// <param name="ContactID">int:Contact ID</param>
		/// <returns>DataSet:Containing data of contact address</returns>
		[AtrERPMethodType(ERPMethodType.List , "GEN_Contacts" ) ]
		public DataSet ListContactAddress(int ContactID)
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListContactAddress  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListContactAddress );
				return  null;
			}
			return AddressData.ContactAddresses(ContactID);
		}
		/// <summary>
		/// Update address for contact.
		/// </summary>
		/// <param name="dsAddresses">DataSet:Containing data of Addresses which wanted to modified</param>
		/// <returns>Int:returns 1 if success and 0 if not</returns>
		public int  UpdateContactAddress(DataSet dsAddresses)
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.UpdateContactAddress  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.UpdateContactAddress );
				return  0;
			}
			return AddressData.Update(dsAddresses);
		}

		/// <summary>
		/// It retruns data of primary address for spacific contact
		/// </summary>
		/// <param name="ContactID">int:Contact ID</param>
		/// <returns>DataSet:Containing data of primary address</returns>
		public DataSet  GetContactPrimaryAddress(int ContactID)
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.GetContactPrimaryAddress  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.GetContactPrimaryAddress );
				return  null;
			}
			return AddressData.ContactPrimaryAddresses( ContactID);
		} 

		#endregion

		#region City
		/// <summary>
		/// It retruns data of all cities.
		/// </summary>
		/// <returns>DataSet:Containing data of all cities</returns>
		public DataSet ListAllCities(  )
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListAllCities  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListAllCities );
				return  null;
			}
			return CityData.List( );
		}

		/// <summary>
		/// It retrun data of spacific city.
		/// </summary>
		/// <param name="cityID">int:City ID</param>
		/// <returns>DataSet:Containing data of required city</returns>
		public DataSet ListCity( int cityID  )
		{	
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListCity  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListCity );
				return  null;
			}
			return CityData.List( cityID );
		}

		/// <summary>
		/// Update city.
		/// </summary>
		/// <param name="ds">DataSet:Containing data of city</param>
		/// <returns>Int:returns 1 if success and 0 if not</returns>
		public int  UpdateCity( DataSet ds )
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.UpdateCity  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.UpdateCity );
				return  0;
			}
			return CityData.Update( ds );
		}

		/// <summary>
		/// Delete city from the data base.
		/// </summary>
		/// <param name="ds">DataSet:Containing data which wanted to delete</param>
		/// <returns>Int:returns 1 if success and 0 if not</returns>
		public int  DeleteCity( DataSet ds )
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.DeleteCity  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.DeleteCity );
				return  0;
			}
			return CityData.Delete( ds );
		}
		/// <summary>
		/// It returns data of all cities under spacific state  ID.
		/// </summary>
		/// <param name="stateID">int:State ID</param>
		/// <returns>DataSet:Containing data of required cities</returns>
		public DataSet  ListAllStateCities(  int stateID )
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListAllStateCities  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListAllStateCities );
				return  null;
			}
			return CityData.GetStateCities( stateID );
		}

		#endregion

		#region States

		/// <summary>
		/// It retrun data of all states.
		/// </summary>
		/// <returns>DataSet:Containing data of all states</returns>
		public DataSet ListAllStates(  )
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListAllStates  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListAllStates );
				return  null;
			}
			return stateData.List( );
		}

		/// <summary>
		/// It retruns data of spacific state.
		/// </summary>
		/// <param name="stateID">int:State ID</param>
		/// <returns>DataSet:Containing data of required state</returns>
		public DataSet ListState( int stateID  )
		{	
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListState  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListState );
				return  null;
			}
			return stateData.List( stateID );
		}

		/// <summary>
		/// update data of state.
		/// </summary>
		/// <param name="ds">DataSet|:Data to modefied</param>
		/// <returns>Int:returns 1 if success and 0 if not</returns>
		public int  UpdateState( DataSet ds )
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.UpdateState  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.UpdateState );
				return  0;
			}
			return stateData.Update( ds );
		}

		/// <summary>
		/// Delete data of state.
		/// </summary>
		/// <param name="ds">DataSet:Deleted data</param>
		/// <returns>Int:returns 1 if success and 0 if not</returns>
		public int  DeleteState( DataSet ds )
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.DeleteState  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.DeleteState );
				return  0;
			}
			return stateData.Delete( ds );
		}

		/// <summary>
		/// It retruns all states under spacific countary.
		/// </summary>
		/// <param name="countryID">int:Country ID</param>
		/// <returns>DataSet:Containing data of all states</returns>
		public DataSet  ListAllCountryStates( int countryID )
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListAllCountryStates  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListAllCountryStates );
				return  null;
			}
			return stateData.GetCountryStates( countryID );
		}

		#endregion

		#region Countries

		/// <summary>
		/// List all countries.
		/// </summary>
		/// <returns>DAtaSet:Containing data of countries</returns>
		public DataSet ListAllCountries(  )
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListAllCountries  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListAllCountries );
				return  null;
			}
			return countryData.List( );
		}

		/// <summary>
		/// List a spacific countary.
		/// </summary>
		/// <param name="stateID">int:State ID</param>
		/// <returns>DAtaSet:Containing data of reqiured countary</returns>
		public DataSet ListCountry( int stateID  )
		{	
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListCountry  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListCountry );
				return  null;
			}
			return countryData.List( stateID );
		}

		/// <summary>
		/// Update data of country.
		/// </summary>
		/// <param name="ds">DataSet:Updateing data</param>
		/// <returns>int:returns 1 if success and 0 if not</returns>
		public int  UpdateCountry( DataSet ds )
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.UpdateCountry  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.UpdateCountry );
				return  0;
			}
			return countryData.Update( ds );
		}

		/// <summary>
		/// Delete data of of country.
		/// </summary>
		/// <param name="ds">DataSet:Deleting data</param>
		/// <returns>int:returns 1 if success and 0 if not</returns>
		public int  DeleteCountry( DataSet ds )
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.DeleteCountry  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.DeleteCountry );
				return  0;
			}
			return countryData.Delete( ds );
		}

		
		#endregion

		#region Emails

		/// <summary>
		/// It returns data of all e-mails.
		/// </summary>
		/// <returns>DataSet:Containing data of all e-mails</returns>
		public DataSet ListAllEmails(  )
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListAllEmails  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListAllEmails );
				return  null;
			}
			return mailData.List( );
		}

		/// <summary>
		/// Add new e-mail.
		/// </summary>
		/// <param name="ds">DataSet:Containing data of new e-mail</param>
		/// <returns>int:returns 1 if success and 0 if not</returns>
		public int  AddEmail( DataSet ds )
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.UpdateEmail  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.UpdateEmail );
				return  0;
			}
			return mailData.Add( ds , false );
		}

		/// <summary>
		/// Updating data of e-mails.
		/// </summary>
		/// <param name="ds">DataSet:Updating data</param>
		/// <returns>int:returns 1 if success and 0 if not</returns>
		public int  UpdateEmail( DataSet ds )
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.UpdateEmail  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.UpdateEmail );
				return  0;
			}
			return mailData.Update( ds );
		}

		/// <summary>
		/// Delete data of e-mail.
		/// </summary>
		/// <param name="ds">DataSet:Deleting data</param>
		/// <returns>int:returns 1 if success and 0 if not</returns>
		public int  DeleteEmail( DataSet ds )
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.DeleteEmail  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.DeleteEmail );
				return  0;
			}
			return mailData.Delete( ds );
		}
		
		/// <summary>
		/// It returns data of all contact e-mails.
		/// </summary>
		/// <param name="contactID">int:Contact ID</param>
		/// <returns>DataSet:Containing all data of contacts e-mails</returns>
		[AtrERPMethodType(ERPMethodType.List , "GEN_Contacts" ) ]
		public DataSet  ListAllCotactEmails( int contactID )
		{
//			//
//			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListAllCotactEmails  ) ) )  )
//			{
//				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListAllCotactEmails );
//				return  null;
//			}
			return mailData.GetContactEmails( contactID );
		}

		/// <summary>
		/// It returns data of all contact e-mails.
		/// </summary>
		/// <param name="contactID">int:Contact ID</param>
		/// <returns>DataSet:Containing all data of contacts e-mails</returns>
		[AtrERPMethodType(ERPMethodType.List , "GEN_Contacts" ) ]
		public DataSet  ListAllCotactsAndEmails( int emailType )
		{
			
//			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListConactData  ) )  ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListAllCotactEmails  ) ) )  )
//			{
//				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListConactData );
//				return  null;
//			}
			DataSet dsContactsAndEmails = mailData.GetContactsAndEmails(emailType);
			return dsContactsAndEmails;
		}


//		/// <summary>
//		/// It returns data of primary e-mail for spacific contact.
//		/// </summary>
//		/// <param name="contactID">int:Contact ID</param>
//		/// <returns>DataSet:Containing all data of primary e-mail</returns>
//		public DataSet  ListContactPrimaryEmail( int contactID )
//		{
//			//
//			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListContactPrimaryEmail  ) ) )  )
//			{
//				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListContactPrimaryEmail );
//				return null;
//			}
//			return mailData.GetContactPrimaryEmail( contactID );
//		}
		#endregion
		
		#region WebSites

		/// <summary>
		/// It returns data of all web sites.
		/// </summary>
		/// <returns>DataSet:Containing data of all web sites</returns>
		public DataSet ListAllWebSites(  )
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListAllWebSites  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListAllWebSites );
				return  null;
			}
			return webSiteData.List( );
		}

		/// <summary>
		/// Update data of web site.
		/// </summary>
		/// <param name="ds">DataSet:Updating data</param>
		/// <returns>int:returns 1 if success and 0 if not</returns>
		public int  UpdateWebSite( DataSet ds )
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.UpdateWebSite  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.UpdateWebSite );
				return  0;
			}
			return webSiteData.Edit( ds );
		}

		/// <summary>
		/// Delete data of web site.
		/// </summary>
		/// <param name="ds">DataSet:Deleteing data</param>
		/// <returns>int:returns 1 if success and 0 if not</returns>
		public int  DeleteWebSite( DataSet ds )
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.DeleteWebSite  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.DeleteWebSite );
				return  0;
			}
			return webSiteData.Delete( ds );
		}

		/// <summary>
		/// It returns data of all web sites for spacific contact.
		/// </summary>
		/// <param name="contactID">int:Contact ID</param>
		/// <returns>DataSet:Containing data of all web sites</returns>
		[AtrERPMethodType(ERPMethodType.List , "GEN_Contacts" ) ]
		public DataSet  ListAllCotactWebSite( int contactID )
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListAllCotactWebSite  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListAllCotactWebSite );
				return  null;
			}
			return webSiteData.GetContactWebSites( contactID );
		}

		/// <summary>
		/// It retruns data of primary web site for spacific contact.
		/// </summary>
		/// <param name="contactID">int:Contact ID</param>
		/// <returns>DataSet:Containing data of primary web site</returns>
		public DataSet  ListContactPrimaryWebSite( int contactID )
		{
			//
			if ( ! ( ContactsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListContactPrimaryWebSite  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListContactPrimaryWebSite );
				return  null;
			}
			return webSiteData.GetContactPrimaryWebSite( contactID );
		}
		#endregion
	}
}
