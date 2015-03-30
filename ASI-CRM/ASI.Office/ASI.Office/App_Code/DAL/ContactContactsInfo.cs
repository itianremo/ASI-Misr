using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;
using Office.DAL.ApplicationBlocks;

namespace Office.DAL
{
    [Serializable]
    public class ContactContactsInfo
    {

        #region -------------------Properties--------------------

        public enum SortBy
        {
            Company,
            LastName,
            Phone,
            FirstName,
            Fax,
            Email,
            TitleName,
            Tag,
            LastContactNoteDate
        }

        public enum SearchBy
        {
            AName,
            FirstName,
            LastName,
            Phone,
            Fax,
            Email,
            IDStatus
        }

        public int? ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; }
        }

        public string Intial
        {
            get { return _Intial; }
            set { _Intial = value; }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string MiddleIntial
        {
            get { return _MiddleIntial; }
            set { _MiddleIntial = value; }
        }

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public int? TitleID
        {
            get { return _TitleID; }
            set { _TitleID = value; }
        }

        public int? DepartmentID
        {
            get { return _DepartmentID; }
            set { _DepartmentID = value; }
        }

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        public string Ext
        {
            get { return _Ext; }
            set { _Ext = value; }
        }

        public string CellPhone
        {
            get { return _CellPhone; }
            set { _CellPhone = value; }
        }

        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public int? AccountID
        {
            get { return _AccountID; }
            set { _AccountID = value; }
        }

        public int? EnteredbyID
        {
            get { return _EnteredbyID; }
            set { _EnteredbyID = value; }
        }

        public DateTime? EnterDate
        {
            get { return _EnterDate; }
            set { _EnterDate = value; }
        }

        public int? EditByID
        {
            get { return _EditByID; }
            set { _EditByID = value; }
        }

        public DateTime? EditDate
        {
            get { return _EditDate; }
            set { _EditDate = value; }
        }

        public string TitleName
        {
            get { return _TitleName; }
            set { _TitleName = value; }
        }

        public string DepartmentName
        {
            get { return _DepartmentName; }
            set { _DepartmentName = value; }
        }

        public string AccountName
        {
            get { return _AccountName; }
            set { _AccountName = value; }
        }

        public string EnteredByName
        {
            get { return _EnteredByName; }
            set { _EnteredByName = value; }
        }

        public string EditByName
        {
            get { return _EditByName; }
            set { _EditByName = value; }
        }

        public bool? Tag
        {
            get { return _Tag; }
            set { _Tag = value; }
        }

        public SortBy SortExpression
        {
            get { return _SortExpression; }
            set { _SortExpression = value; }
        }

        public SortDirection SortDirect
        {
            get { return _SortDirect; }
            set { _SortDirect = value; }
        }

        public SearchBy SearchList
        {
            get { return _SearchList; }
            set { _SearchList = value; }
        }

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        public int? CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }

        public string URL
        {
            get { return _URL; }
            set { _URL = value; }
        }
       
        public string CountryName
        {
            get { return _CountryName; }
            set { _CountryName = value; }
        }

        public string IDStatus
        {
            get { return _IDStatus; }
            set { _IDStatus = value; }
        }

        public int? BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }

        public bool? MainContact
        {
            get { return _MainContact; }
            set { _MainContact = value; }
        }

        public decimal? Probability
        {
            get { return _Probability; }
            set { _Probability = value; }
        }
        // Added By Fawzi For Task 1703 
        public DateTime? LastContactNoteDate
        {
            get { return _LastContactNoteDate; }
            set { _LastContactNoteDate = value; }
        }
        //
        public int? FilterContactsNotes
        {
            get { return _FilterContactsNotes; }
            set { _FilterContactsNotes = value; }
        }
        //
        //

        #endregion

        #region ------------------Constructors------------------

        public ContactContactsInfo()
        {
            //
            // TODO : Implement Constructor Function
            //
        }

        #endregion

        #region -----------------Private Variables----------------

        private int? _ContactID;
        private string _Intial;
        private string _FirstName;
        private string _MiddleIntial;
        private string _LastName;
        private int? _TitleID;
        private int? _DepartmentID;
        private string _Phone;
        private string _Ext;
        private string _CellPhone;
        private string _Fax;
        private string _Email;
        private int? _AccountID;
        private int? _EnteredbyID;
        private DateTime? _EnterDate;
        private int? _EditByID;
        private DateTime? _EditDate;
        private string _TitleName;
        private string _DepartmentName;
        private string _AccountName;
        private string _EnteredByName;
        private string _EditByName;
        private bool? _Tag;
        private SortBy _SortExpression;
        private SortDirection _SortDirect;
        private SearchBy _SearchList;
        private string _Address;
        private string _City;
        private string _State;
        private int? _CountryID;
        private string _URL;
        private string _CountryName;
        private string _IDStatus;
        private int? _BranchID;
        private bool? _MainContact;
        private decimal? _Probability;
        // Added By Fawzi For Task 1703 
        private DateTime? _LastContactNoteDate;
        private int? _FilterContactsNotes;
        //

        static string StrCon = ConfigurationManager.ConnectionStrings["ASI-CRMConnectionString"].ToString();

        #endregion

        #region -----------------General Functions---------------

        /// <summary>
        /// Insert new record into table Contact_ContactsInfo
        /// Fill in all properties of the Contact_ContactsInfo Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public string AddNewContactContactsInfo()
        {
            string Affected = "-1";
            try
            {
                object ReturnVal = SqlHelper.ExecuteScalar(StrCon, "SP_INSERT_INTO_Contact_ContactsInfo", this._Intial, this._FirstName, this._MiddleIntial, this._LastName, this._TitleID,
                                                    this._DepartmentID, this._Phone, this._Ext, this._CellPhone, this._Fax, this._Email, this._AccountID, this._EnteredbyID,
                                                    this._EnterDate, this._EditByID, this._EditDate, this._Tag,this._Address,this._City,this._State,this._CountryID,this._URL,this._BranchID,this._MainContact, this._Probability);
                if (ReturnVal != null)
                    Affected = ReturnVal.ToString();
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return Affected;
        }

        /// <summary>
        /// Update existing record in table Contact_ContactsInfo
        /// Fill in all properties of the Contact_ContactsInfo Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int UpdateContactContactsInfo()
        {
            int Affected = -1;
            try
            {
                // object[] Params = BuildUpdateQuery(); // remarked by fawzi and added next line just to allow me to debug with no errors
                object[] Params = BuildUpdateQueryParams();

                Affected = Convert.ToInt32(SqlHelper.ExecuteScalar(StrCon, "SP_UPDATE_Contact_ContactsInfo", Params));
                                                    /*this._ContactID, this._Intial, this._FirstName, this._MiddleIntial, this._LastName,
                                                    this._TitleID, this._DepartmentID, this._Phone, this._Ext, this._CellPhone, this._Fax, this._Email, this._AccountID,
                                                    this._EnteredbyID, this._EnterDate, this._EditByID, this._EditeDate, this._Tag);*/                                                                                                 
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return Affected;
        }
        
        /// <summary>
        /// Get all contacts from ContactContactsInfo table according to pre-determined search criteria
        /// You can search by LastName, FirstName, EMail, Fax and Phone just fill the properies according to the search criteria 
        /// </summary>
        /// <returns>List of all contacts that meets the search filter</returns>
        public List<ContactContactsInfo> GetContacts()
        {
            SqlConnection conContact = new SqlConnection(StrCon);
            List<ContactContactsInfo> ContactList = new List<ContactContactsInfo>();

            try
            {
                string TagValue = BuildFilter();
                string SortCriteria = BuildSortCriteria();
                string ContID = "";
                if (this.ContactID != null)
                    ContID = this.ContactID.ToString();
                else
                    ContID = "-1";
                SqlDataReader rdrContact = SqlHelper.ExecuteReader(conContact, "SP_Get_Contacts", ContID, this.FirstName, this.LastName, this.Phone, this.Fax, this.Email, this.AccountID, this.BranchID, this.AccountName, this.IDStatus, TagValue, SortCriteria, this.FilterContactsNotes);//BuildFilter());
                ContactContactsInfo CCI;
                while (rdrContact.Read())
                {
                    CCI = new ContactContactsInfo();

                    if(rdrContact["ContactID"] != null && rdrContact["ContactID"].ToString() != "")
                        CCI.ContactID = int.Parse(rdrContact["ContactID"].ToString());
                    CCI.Intial = rdrContact["Intial"].ToString();
                    CCI.FirstName = rdrContact["FirstName"].ToString();
                    CCI.MiddleIntial = rdrContact["MiddleIntial"].ToString();
                    CCI.LastName = rdrContact["LastName"].ToString();
                    if (rdrContact["TitleID"] != null && rdrContact["TitleID"].ToString() != "")
                        CCI.TitleID = int.Parse(rdrContact["TitleID"].ToString());
                    if (rdrContact["DepartmentID"] != null && rdrContact["DepartmentID"].ToString() != "")
                        CCI.DepartmentID = int.Parse(rdrContact["DepartmentID"].ToString());
                    CCI.Phone = rdrContact["Phone"].ToString();
                    CCI.Ext = rdrContact["Ext"].ToString();
                    CCI.CellPhone = rdrContact["CellPhone"].ToString();
                    CCI.Fax = rdrContact["Fax"].ToString();
                    CCI.Email = rdrContact["Email"].ToString();
                    if(rdrContact["AccountID"] != null && rdrContact["AccountID"].ToString() != "")
                        CCI.AccountID = int.Parse(rdrContact["AccountID"].ToString());
                    if (rdrContact["EnteredbyID"] != null && rdrContact["EnteredbyID"].ToString() != "") 
                        CCI.EnteredbyID = int.Parse(rdrContact["EnteredbyID"].ToString());
                    if(rdrContact["EnterDate"] != null && rdrContact["EnterDate"].ToString() != "")
                        CCI.EnterDate = Convert.ToDateTime(rdrContact["EnterDate"].ToString());
                    if (rdrContact["EditByID"] != null && rdrContact["EditByID"].ToString() != "")
                        CCI.EditByID = int.Parse(rdrContact["EditByID"].ToString());
                    if (rdrContact["EditeDate"] != null && rdrContact["EditeDate"].ToString() != "")
                        CCI.EditDate = Convert.ToDateTime(rdrContact["EditeDate"].ToString());
                    CCI.TitleName = rdrContact["TitleName"].ToString();
                    CCI.DepartmentName = rdrContact["DepartmentName"].ToString();
                    CCI.AccountName = rdrContact["AName"].ToString();
                    CCI.EnteredByName = rdrContact["EnteredByName"].ToString();
                    CCI.EditByName = rdrContact["EditByName"].ToString();
                    if (rdrContact["Tag"] != null && rdrContact["Tag"].ToString() != "")
                        CCI.Tag = Convert.ToBoolean(rdrContact["Tag"].ToString());
                    else
                        CCI.Tag = false;
                    CCI.Address = rdrContact["Address"].ToString();
                    CCI.City = rdrContact["City"].ToString();
                    CCI.State = rdrContact["State"].ToString();
                    if(rdrContact["CountryID"] != null && rdrContact["CountryID"].ToString() != "")
                        CCI.CountryID = int.Parse(rdrContact["CountryID"].ToString());
                    CCI.CountryName = rdrContact["CountryName"].ToString();
                    CCI.URL = rdrContact["Url"].ToString();
                    CCI.IDStatus = rdrContact["IDStatusName"].ToString();
                    if (rdrContact["Probability"] != null && rdrContact["Probability"].ToString() != "")
                        CCI.Probability = decimal.Parse(rdrContact["Probability"].ToString());

                    // Added By Fawzi For Task 1703
                    if (rdrContact["LastContactNoteDate"] != null && rdrContact["LastContactNoteDate"].ToString() != "")
                        CCI.LastContactNoteDate = Convert.ToDateTime(rdrContact["LastContactNoteDate"].ToString());
                    //
                    ContactList.Add(CCI);
                }
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                conContact.Close();
            }
            return ContactList;
        }

        public DataTable GetContactsDS(int PageSize, int PageNum)
        {
            SqlConnection conContact = new SqlConnection(StrCon);
            DataTable dt = new DataTable();
            dt.Columns.Add("ContactID", typeof(int));
            dt.Columns.Add("Intial", typeof(string));
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("MiddleIntial", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("TitleID", typeof(int));
            dt.Columns.Add("DepartmentID", typeof(int));
            dt.Columns.Add("Phone", typeof(string));
            dt.Columns.Add("Ext", typeof(string));
            dt.Columns.Add("CellPhone", typeof(string));
            dt.Columns.Add("Fax", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("AccountID", typeof(int));
            dt.Columns.Add("EnteredbyID", typeof(int));
            dt.Columns.Add("EnterDate", typeof(DateTime));
            dt.Columns.Add("EditByID", typeof(int));
            dt.Columns.Add("EditDate", typeof(DateTime));
            dt.Columns.Add("TitleName", typeof(string));
            dt.Columns.Add("DepartmentName", typeof(string));
            dt.Columns.Add("AccountName", typeof(string));
            dt.Columns.Add("EnteredByName", typeof(string));
            dt.Columns.Add("EditByName", typeof(string));
            dt.Columns.Add("Tag", typeof(bool));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("City", typeof(string));
            dt.Columns.Add("State", typeof(string));
            dt.Columns.Add("CountryID", typeof(int));
            dt.Columns.Add("URL", typeof(string));
            dt.Columns.Add("CountryName", typeof(string));
            dt.Columns.Add("IDStatus", typeof(string));
            dt.Columns.Add("BranchID", typeof(int));
            dt.Columns.Add("MainContact", typeof(bool));
            dt.Columns.Add("Probability", typeof(decimal));
            dt.Columns.Add("LastContactNoteDate", typeof(DateTime));
            dt.Columns.Add("FilterContactsNotes", typeof(int));

            try
            {
                SqlDataReader rdrContact = SqlHelper.ExecuteReader(conContact, "SP_Get_Contacts_By_Page", PageSize, PageNum);
                int RowIndex = -1;
                while (rdrContact.Read())
                {
                    try
                    {
                        RowIndex++;
                        dt.Rows.InsertAt(dt.NewRow(), RowIndex);

                        if (rdrContact["ContactID"] != null && rdrContact["ContactID"].ToString() != "")
                            dt.Rows[RowIndex]["ContactID"] = int.Parse(rdrContact["ContactID"].ToString());
                        dt.Rows[RowIndex]["Intial"] = rdrContact["Intial"].ToString();
                        dt.Rows[RowIndex]["FirstName"] = rdrContact["FirstName"].ToString();
                        dt.Rows[RowIndex]["MiddleIntial"] = rdrContact["MiddleIntial"].ToString();
                        dt.Rows[RowIndex]["LastName"] = rdrContact["LastName"].ToString();
                        if (rdrContact["TitleID"] != null && rdrContact["TitleID"].ToString() != "")
                            dt.Rows[RowIndex]["TitleID"] = int.Parse(rdrContact["TitleID"].ToString());
                        if (rdrContact["DepartmentID"] != null && rdrContact["DepartmentID"].ToString() != "")
                            dt.Rows[RowIndex]["DepartmentID"] = int.Parse(rdrContact["DepartmentID"].ToString());
                        dt.Rows[RowIndex]["Phone"] = rdrContact["Phone"].ToString();
                        dt.Rows[RowIndex]["Ext"] = rdrContact["Ext"].ToString();
                        dt.Rows[RowIndex]["CellPhone"] = rdrContact["CellPhone"].ToString();
                        dt.Rows[RowIndex]["Fax"] = rdrContact["Fax"].ToString();
                        dt.Rows[RowIndex]["Email"] = rdrContact["Email"].ToString();
                        if (rdrContact["AccountID"] != null && rdrContact["AccountID"].ToString() != "")
                            dt.Rows[RowIndex]["AccountID"] = int.Parse(rdrContact["AccountID"].ToString());
                        if (rdrContact["EnteredbyID"] != null && rdrContact["EnteredbyID"].ToString() != "")
                            dt.Rows[RowIndex]["EnteredbyID"] = int.Parse(rdrContact["EnteredbyID"].ToString());
                        if (rdrContact["EnterDate"] != null && rdrContact["EnterDate"].ToString() != "")
                            dt.Rows[RowIndex]["EnterDate"] = Convert.ToDateTime(rdrContact["EnterDate"].ToString());
                        if (rdrContact["EditByID"] != null && rdrContact["EditByID"].ToString() != "")
                            dt.Rows[RowIndex]["EditByID"] = int.Parse(rdrContact["EditByID"].ToString());
                        if (rdrContact["EditeDate"] != null && rdrContact["EditeDate"].ToString() != "")
                            dt.Rows[RowIndex]["EditDate"] = Convert.ToDateTime(rdrContact["EditeDate"].ToString());
                        dt.Rows[RowIndex]["TitleName"] = rdrContact["TitleName"].ToString();
                        dt.Rows[RowIndex]["DepartmentName"] = rdrContact["DepartmentName"].ToString();
                        dt.Rows[RowIndex]["AccountName"] = rdrContact["AName"].ToString();
                        dt.Rows[RowIndex]["EnteredByName"] = rdrContact["EnteredByName"].ToString();
                        dt.Rows[RowIndex]["EditByName"] = rdrContact["EditByName"].ToString();
                        if (rdrContact["Tag"] != null && rdrContact["Tag"].ToString() != "")
                            dt.Rows[RowIndex]["Tag"] = Convert.ToBoolean(rdrContact["Tag"].ToString());
                        else
                            dt.Rows[RowIndex]["Tag"] = false;
                        dt.Rows[RowIndex]["Address"] = rdrContact["Address"].ToString();
                        dt.Rows[RowIndex]["City"] = rdrContact["City"].ToString();
                        dt.Rows[RowIndex]["State"] = rdrContact["State"].ToString();
                        if (rdrContact["CountryID"] != null && rdrContact["CountryID"].ToString() != "")
                            dt.Rows[RowIndex]["CountryID"] = int.Parse(rdrContact["CountryID"].ToString());
                        dt.Rows[RowIndex]["CountryName"] = rdrContact["CountryName"].ToString();
                        dt.Rows[RowIndex]["URL"] = rdrContact["Url"].ToString();
                        dt.Rows[RowIndex]["IDStatus"] = rdrContact["IDStatusName"].ToString();
                        if (rdrContact["Probability"] != null && rdrContact["Probability"].ToString() != "")
                            dt.Rows[RowIndex]["Probability"] = decimal.Parse(rdrContact["Probability"].ToString());

                        // Added By Fawzi For Task 1703
                        if (rdrContact["LastContactNoteDate"] != null && rdrContact["LastContactNoteDate"].ToString() != "")
                            dt.Rows[RowIndex]["LastContactNoteDate"] = Convert.ToDateTime(rdrContact["LastContactNoteDate"].ToString());
                        //
                    }
                    catch (Exception Ep)
                    {
                        string ErrMsg = Ep.Message;
                        continue;
                    }
                }

            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                conContact.Close();
            }
            return dt;
        }

        public static int GetContactsPages(int PageSize)
        {
            SqlConnection conContact = new SqlConnection(StrCon);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(conContact, "SP_Get_Contacts_Pages", PageSize));
        }

        /// <summary>
        /// Return list of names that would be used in incremental search
        /// </summary>
        /// <param name="Prefix">Intial part of the name to search for</param>
        /// <param name="SearchColumn">The column or field to search in</param>
        /// <returns>String Array of all names which match the given prefix </returns>
        public string[] GetSearchList(string Prefix, SearchBy SearchColumn)
        {
            string[] NamesList = new string[0];
            try
            {
                DataSet dsList = new DataSet();
                dsList = SqlHelper.ExecuteDataset(StrCon, "SP_Get_Contacts_Search_List", SearchColumn.ToString(), Prefix);
                NamesList = new string[dsList.Tables[0].Rows.Count];
                for (int i = 0; i < dsList.Tables[0].Rows.Count; i++)
                {
                    if ((SearchColumn != SearchBy.Phone) && (SearchColumn != SearchBy.Fax))
                        NamesList[i] = dsList.Tables[0].Rows[i][SearchColumn.ToString()].ToString();
                    else
                        NamesList[i] = dsList.Tables[0].Rows[i][SearchColumn.ToString()].ToString().Replace("-", "~");
                }

            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }

            return NamesList;
        }

        /// <summary>
        /// Delete existing record in table Contact_ContactsInfo
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public string DeleteContact()
        {
            object Affected = "-1";
            try
            {
                object[] Params = { _ContactID, 0 };
                Affected = BaseClass.ReturnValueCommand("SP_DELETE_Contact_ContactsInfo", Params);
            }
            catch (Exception Exp)
            {
                return Exp.Message;
            }
            return Affected.ToString();
        }

        /// <summary>
        /// Get contact page no. in grid
        /// </summary>
        /// <returns>integer value to indicates number of this contact page</returns>
        public int GetContactPage(int PageSize)
        {
            int result = -1;

            try
            {
                result = (int)BaseClass.ReturnValueCommand("SP_Get_Account_Or_Contact_Page", this._ContactID, false, PageSize, 0);
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }

            return result;
        }

        /// <summary>
        /// Get contact page no. in grid
        /// </summary>
        /// <returns>integer value to indicates number of this contact page</returns>
        public int GetContactPageNum(int PageSize)
        {
            int result = -1;

            try
            {
                result = (int)BaseClass.ReturnValueCommand("SP_Get_Account_Or_Contact_Page_num", this._ContactID, false, PageSize, 0);
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }

            return result;
        }

        /// <summary>
        /// Get contact page no. in grid
        /// </summary>
        /// <returns>integer value to indicates number of this contact order</returns>
        public int GetContactOrder()
        {
            int result = -1;

            try
            {
                string pref = "";
                switch (this._SearchList)
                {
                    case SearchBy.AName:
                        pref = this._AccountName;
                        break;
                    case SearchBy.FirstName:
                        pref = this._FirstName;
                        break;
                    case SearchBy.LastName:
                        pref = this._LastName;
                        break;
                    case SearchBy.Phone:
                        pref = this._Phone;
                        break;
                    case SearchBy.Fax:
                        pref = this._Fax;
                        break;
                    case SearchBy.Email:
                        pref = this._Email;
                        break;
                    case SearchBy.IDStatus:
                        pref = this._IDStatus;
                        break;
                    default:
                        break;
                }
                if (pref.Length == 0) pref = "-1";
                result = (int)BaseClass.ReturnValueCommand("SP_Get_Account_Or_Contact_Order", this._ContactID, false, this._SearchList, pref, this._FilterContactsNotes, this.SortExpression.ToString(), 0);
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }

            return result;
        }

        #endregion

        #region -----------------Private Functions---------------

        private string BuildFilter()
        {
            string Filter = "";
            if (this.FirstName == null || this.FirstName.Trim() == "")
                this.FirstName = "-1";

            if (this.LastName == null || this.LastName.Trim() == "")
                this.LastName = "-1";

            if (this.Email == null || this.Email.Trim() == "")
                this.Email = "-1";

            if (this.Phone == null || this.Phone.Trim() == "")
                this.Phone = "-1";

            if (this.Fax == null || this.Fax.Trim() == "")
                this.Fax = "-1";

            if (this.AccountID == null)
                this.AccountID = -1;

            if (this.BranchID == null)
                this.BranchID = -1;

            if (this.AccountName == null || this.AccountName.Trim() == "")
                this.AccountName = "-1";

            if (this.IDStatus == null || this.IDStatus.Trim() == "")
                this.IDStatus = "-1";

            if (this.Tag == null)
                Filter = "-1";
            else
            {
                if (this.Tag == true)
                    Filter = "1";
                else
                    Filter = "0";
            }

            return Filter;
        }

        private object[] BuildUpdateQueryParams()
        {
            object[] UpdateParameters = new object[26];
            UpdateParameters[0] = this._ContactID.ToString();

            if (this._Intial == null)
                UpdateParameters[1] = "-1";
            else
                UpdateParameters[1] = this._Intial.ToString();

            if (this._FirstName == null)
                UpdateParameters[2] = "-1";
            else
                UpdateParameters[2] = this._FirstName.ToString();

            if (this._MiddleIntial == null)
                UpdateParameters[3] = "-1";
            else
                UpdateParameters[3] = this._MiddleIntial.ToString();

            if (this._LastName == null)
                UpdateParameters[4] = "-1";
            else
                UpdateParameters[4] = this._LastName.ToString();

            if (this._TitleID == null)
                UpdateParameters[5] = "-1";
            else
                UpdateParameters[5] = this._TitleID.ToString();

            if (this._DepartmentID == null)
                UpdateParameters[6] = "-1";
            else
                UpdateParameters[6] = this._DepartmentID.ToString();

            if (this._Phone == null)
                UpdateParameters[7] = "-1";
            else
                UpdateParameters[7] = this._Phone.ToString();
           
            if (this._Ext == null)
                UpdateParameters[8] = "-1";
            else
                UpdateParameters[8] = this._Ext.ToString();
            
            if (this._Fax == null)
                UpdateParameters[9] = "-1";
            else
                UpdateParameters[9] = this._Fax.ToString();

            if (this._Email == null)
                UpdateParameters[10] = "-1";
            else
                UpdateParameters[10] = this._Email.ToString();
            
            if (this._CellPhone == null)
                UpdateParameters[11] = "-1";
            else
                UpdateParameters[11] = this._CellPhone.ToString();
         
            if (this._AccountID == null)
                UpdateParameters[12] = "-1";
            else
                UpdateParameters[12] = this._AccountID.ToString();

            if (this._EnteredbyID == null)
                UpdateParameters[13] = "-1";
            else
                UpdateParameters[13] = this._EnteredbyID.ToString();

            if (this._EnterDate == null)
                UpdateParameters[14] = "-1";
            else
                UpdateParameters[14] = this._EnterDate.ToString();

            if (this._EditByID == null)
                UpdateParameters[15] = "-1";
            else
                UpdateParameters[15] = this._EditByID.ToString();

            if (this._EditDate == null)
                UpdateParameters[16] = "-1";
            else
                UpdateParameters[16] = this._EditDate.ToString();

            if (this._Tag == null)
                UpdateParameters[17] = "-1";
            else
            {
                if (this._Tag == true)
                    UpdateParameters[17] = "1";
                else
                    UpdateParameters[17] = "0";
                }

            if (this._Address == null)
                UpdateParameters[18] = "-1";
            else
                UpdateParameters[18] = this._Address.ToString();

            if (this._City == null)
                UpdateParameters[19] = "-1";
            else
                UpdateParameters[19] = this._City.ToString();

            if (this._State == null)
                UpdateParameters[20] = "-1";
            else
                UpdateParameters[20] = this._State.ToString();

            if (this._CountryID == null)
                UpdateParameters[21] = "-1";
            else
                UpdateParameters[21] = this._CountryID.ToString();

            if (this._URL == null)
                UpdateParameters[22] = "-1";
            else
                UpdateParameters[22] = this._URL.ToString();
            if (this._BranchID == null)
                UpdateParameters[23] = "-1";
            else
                UpdateParameters[23] = this._BranchID.ToString();

            if (this._MainContact == null)
                UpdateParameters[24] = "-1";
            else
            {
                if (this._MainContact == true)
                    UpdateParameters[24] = "1";
                else
                    UpdateParameters[24] = "0";
            }

            if (this._Probability == null)
                UpdateParameters[25] = "-1";
            else
                UpdateParameters[25] = this._Probability.ToString();

            return UpdateParameters;
        }

        private string BuildSortCriteria()
        {
            string SortCriteria = "-1";

            if (this.SortExpression == SortBy.FirstName)
                SortCriteria = "FirstName";
            if (this.SortExpression == SortBy.LastName)
                SortCriteria = "LastName";
            if (this.SortExpression == SortBy.Email)
                SortCriteria = "Contact_ContactsInfo.Email";
            if (this.SortExpression == SortBy.Fax)
                SortCriteria = "Contact_ContactsInfo.Fax";
            if (this.SortExpression == SortBy.Phone)
                SortCriteria = "Contact_ContactsInfo.Phone";
            if (this.SortExpression == SortBy.Company)
                SortCriteria = "AName";
            if (this.SortExpression == SortBy.TitleName)
                SortCriteria = "TitleName";
            if (this.SortExpression == SortBy.Tag)
                SortCriteria = " Contact_ContactsInfo.Tag";
            if (this.SortExpression == SortBy.LastContactNoteDate)
                SortCriteria = " LastContactNoteDate";
            if (this.SortDirect == SortDirection.Ascending)
                SortCriteria += " ASC";
            if (this.SortDirect == SortDirection.Descending)
                SortCriteria += " Desc";

            return SortCriteria;
        }

        #endregion
    }
}