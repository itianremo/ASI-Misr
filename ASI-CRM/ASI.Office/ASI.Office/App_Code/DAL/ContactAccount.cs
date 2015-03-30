using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Office.DAL;
using System.Collections;
using System.Collections.Generic;
using Office.DAL.ApplicationBlocks;
using System.Data.SqlClient;

namespace Office.DAL
{
    [Serializable]
    public class ContactAccount
    {

        #region ---------------Properties AND Enums--------------

        public enum SortBy
        {
            AccountID,
            CompanyName,
            BusinessSectorName,
            City,
            State,
            Tag,
            LastAccountNoteDate,
            StatusName,
            CountryName
        }

        public enum SearchBy
        {
            AName,
            BusinessSectorName, Telephone, Fax, Email, Website, AID
        }

        public int? AccountID
        {
            get { return _AccountID; }
            set { _AccountID = value; }
        }

        public string AccountName
        {
            get { return _AccountName; }
            set {         
                _AccountName = value; }
        }

        public int? TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }

        public int? BusSector
        {
            get { return _BusSector; }
            set { _BusSector = value; }
        }

        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string WebSite
        {
            get { return _WebSite; }
            set { _WebSite = value; }
        }

        public int? IDStatus
        {
            get { return _IDStatus; }
            set { _IDStatus = value; }
        }

        public string Street1
        {
            get { return _Street1; }
            set { _Street1 = value; }
        }

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        public string ZipCode
        {
            get { return _ZipCode; }
            set { _ZipCode = value; }
        }

        public int? CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }

        public string ReferedBy
        {
            get { return _ReferedBy; }
            set { _ReferedBy = value; }
        }

        public int? EnterByID
        {
            get { return _EnterByID; }
            set { _EnterByID = value; }
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

        public string Street2
        {
            get { return _Street2; }
            set { _Street2 = value; }
        }

        public int? AccountManagerID
        {
            get { return _AccountManagerID; }
            set { _AccountManagerID = value; }
        }

        public DateTime? AccountManagerEditDate
        {
            get { return _AccountManagerEditDate; }
            set { _AccountManagerEditDate = value; }
        }

        public int? AccountManagerEditByID
        {
            get { return _AccountManagerEditByID; }
            set { _AccountManagerEditByID = value; }
        }

        public DateTime? AccountManagerAssignedDate
        {
            get { return _AccountManagerAssignedDate; }
            set { _AccountManagerAssignedDate = value; }
        }

        public string BusinessSectorName
        {
            get { return _BusinessSectorName; }
            set { _BusinessSectorName = value; }
        }

        public string CountryName
        {
            get { return _CountryName; }
            set { _CountryName = value; }
        }

        public string StatusName
        {
            get { return _StatusName; }
            set { _StatusName = value; }
        }

        public string EditByName
        {
            get { return _EditByName; }
            set { _EditByName = value; }
        }

        public string EnteredByName
        {
            get { return _EnteredByName; }
            set { _EnteredByName = value; }
        }

        public string AccountManagerName
        {
            get { return _AccountManagerName; }
            set { _AccountManagerName = value; }
        }

        public string AccountManagerEditByName
        {
            get { return _AccountManagerEditByName; }
            set { _AccountManagerEditByName = value; }
        }

        public string State
        {
            get { return _State; }
            set { _State = value; }
        }
        
        public bool? Tag
        {
            get { return _Tag; }
            set { _Tag = value; }
        }

        public bool? TopAccount
        {
            get { return _TopAccount; }
            set { _TopAccount = value; }
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

        public string Profile
        {
            get { return _Profile; }
            set { _Profile = value; }
        }
        // Added By Fawzi For Task 1703 
        public DateTime? LastAccountNoteDate
        {
            get { return _LastAccountNoteDate; }
            set { _LastAccountNoteDate = value; }
        }
        //
        public int? FilterAccountNotes
        {
            get { return _FilterAccountNotes; }
            set { _FilterAccountNotes = value; }
        } 

        #endregion

        #region -----------------Constructor---------------------

        public ContactAccount()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region -----------------Private Variables-----------------

        private int? _AccountID;
        private string _AccountName;
        private int? _TypeID;
        private int? _BusSector;
        private string _Fax;
        private string _Phone;
        private string _Email;
        private string _WebSite;
        private int? _IDStatus;
        private string _Street1;
        private string _City;
        private string _ZipCode;
        private int? _CountryID;
        private string _ReferedBy;
        private int? _EnterByID;
        private DateTime? _EnterDate;
        private int? _EditByID;
        private DateTime? _EditDate;
        private string _Street2;
        private int? _AccountManagerID;
        private DateTime? _AccountManagerEditDate;
        private int? _AccountManagerEditByID;
        private DateTime? _AccountManagerAssignedDate;
        private string _BusinessSectorName;
        private string _CountryName;
        private string _StatusName;
        private string _EditByName;
        private string _EnteredByName;
        private string _AccountManagerName;
        private string _AccountManagerEditByName;
        private string _State;
        private bool? _Tag;
        private bool? _TopAccount;
        private SortBy _SortExpression;
        private SortDirection _SortDirect;
        private string _Profile;
        
        // Added By Fawzi For Task 1703 
        private DateTime? _LastAccountNoteDate;
        private int? _FilterAccountNotes;
        //
        
        static string StrCon = ConfigurationManager.ConnectionStrings["ASI-CRMConnectionString"].ToString();

        #endregion

        #region -----------------General Functions----------------

        /// <summary>
        /// Insert new record into table Contact_Account
        /// Fill in all properties of the ContactAccount Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int AddNewContactAccount()
        {
            int ReturnID = -1;
            try
            {
                if (this._Tag == null)
                    this.Tag = false;
                object AccID = SqlHelper.ExecuteScalar(StrCon, "SP_INSERT_INTO_Contact_Account", this._AccountName.Replace("'","''"), this._TypeID, this._BusSector, this._Fax, this._Phone, this._WebSite
                                                    , this._IDStatus, this._Street1, this._City, this._ZipCode, this._CountryID, this._ReferedBy, this._EditByID, this._EditDate, this._EnterByID
                                                    , this._EnterDate, this._Street2, this._AccountManagerID, this._AccountManagerEditDate, this._AccountManagerEditByID
                                                    , this._AccountManagerAssignedDate, this._State, this._Tag,this._Profile,this._Email,this._TopAccount);
                if (AccID != null)
                    ReturnID = int.Parse(AccID.ToString());
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return ReturnID;
        }

        /// <summary>
        /// Update existing record in table Contact_Account
        /// Fill in all properties of the ContactAccount Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int UpdateContactAccount()
        {
            int Affected = -1;
            try
            {
                object[] Params = BuildUpdateQueryParams();
                Affected = Convert.ToInt32(SqlHelper.ExecuteScalar(StrCon,"SP_UPDATE_Contact_Account", Params));
                                                    /* this._AccountID, this._AccountName, this._TypeID, this._BusSector, this._Fax, this._Phone
                                                    , this._WebSite, this._IDStatus, this._Street1, this._City, this._ZipCode, this._CountryID, this._ReferedBy, this._EditByID
                                                    , this._EditDate, this._EnterByID, this._EnterDate, this._Street2, this._AccountManagerID, this._AccountManagerEditDate
                                                    , this._AccountManagerEditByID, this._AccountManagerAssignedDate, this._State, this._Tag);*/
                
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return Affected;
        }

        /// <summary>
        /// Get account by branch
        /// </summary>
        /// <returns>Account ID</returns>
        public static int GetAccountByBranch(int BranchID)
        {
            SqlConnection conAccount = new SqlConnection(StrCon);
            int result = -1;

            try
            {
                result = (int)BaseClass.ReturnValueCommand("SP_Get_AccountID_By_BranchID", BranchID, 0);
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }

            return result;
        }

        /// <summary>
        /// Get all accounts count
        /// </summary>
        /// <returns>integer value to indicates number of all accounts</returns>
        public static int GetAccountsCount()
        {
            SqlConnection conAccount = new SqlConnection(StrCon);
            int result = -1;

            try
            {
                result = (int)SqlHelper.ExecuteScalar(conAccount, CommandType.StoredProcedure, "SP_Get_Accounts_Count");
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }

            return result;
        }

        /// <summary>
        /// Get account page no. in grid
        /// </summary>
        /// <returns>integer value to indicates number of this account page</returns>
        public int GetAccountPage(int PageSize)
        {
            int result = -1;

            try
            {
                result = (int)BaseClass.ReturnValueCommand("SP_Get_Account_Or_Contact_Page", this._AccountID, true, PageSize, 0);
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }

            return result;
        }

        /// <summary>
        /// Get account page no. in grid
        /// </summary>
        /// <returns>integer value to indicates number of this account page</returns>
        public int GetAccountOrder()
        {
            int result = -1;

            try
            {
                result = (int)BaseClass.ReturnValueCommand("SP_Get_Account_Or_Contact_Order", this._AccountID, true, 0);
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }

            return result;
        }

        /// <summary>
        /// Get account page no. in grid
        /// </summary>
        /// <returns>integer value to indicates number of this account page</returns>
        public int GetAccountItemOrder(SearchBy SearchColumn, string Notes, string Tag, string Pref)
        {
            int result = -1;
            try
            {
                if (string.IsNullOrEmpty(Pref))
                {
                    switch (SearchColumn)
                    {
                        case SearchBy.AName:
                            Pref = this._AccountName;
                            break;
                        case SearchBy.BusinessSectorName:
                            Pref = this._BusinessSectorName;
                            break;
                        case SearchBy.Telephone:
                            Pref = this._Phone;
                            break;
                        case SearchBy.Fax:
                            Pref = this._Fax;
                            break;
                        case SearchBy.Email:
                            Pref = this._Email;
                            break;
                        case SearchBy.Website:
                            Pref = this._WebSite;
                            break;
                        case SearchBy.AID:
                            Pref = "0";
                            break;
                        default:
                            break;
                    }
                }
                result = (int)BaseClass.ReturnValueCommand("SP_Get_Account_Or_Contact_Item_Page", this._AccountID, 
                    this._CountryName, this._State,
                    this._BusinessSectorName, Tag, Notes, SearchColumn.ToString(), Pref, true, 0);
                
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return result;
        }

        /// <summary>
        /// Get all contacts from ContactContactsInfo table according to pre-determined search criteria
        /// You can search by AccountName, City, Phon and/or State. You need assign values to the properies according to the search criteria 
        /// </summary>
        /// <returns>List of  ContactAccount objects that meets the search filter</returns>
        public List<ContactAccount> GetAccounts()
        {
            SqlConnection conAccount = new SqlConnection(StrCon);
            List<ContactAccount> AccList = new List<ContactAccount>();

            try
            {
                string TagValue = BuildFilter();
                string SortCriteria = BuildSortCriteria();
                SqlDataReader rdrAccount = SqlHelper.ExecuteReader(conAccount, "SP_Get_Accounts", this.AccountID, this.IDStatus, this.AccountName, this.Email, this.WebSite, this.City, this.Phone, this.State, this.BusinessSectorName, this.CountryName, TagValue, SortCriteria, this.FilterAccountNotes);
                ContactAccount Acc;
                while (rdrAccount.Read())
                {
                    try
                    {
                        Acc = new ContactAccount();

                        Acc.AccountID = int.Parse(rdrAccount["AID"].ToString());
                        if (rdrAccount["AccountManagerEditByID"] != null && rdrAccount["AccountManagerEditByID"].ToString() != "")
                            Acc.AccountManagerEditByID = int.Parse(rdrAccount["AccountManagerEditByID"].ToString());
                        else
                            Acc.AccountManagerEditByID = int.MinValue;

                        if (rdrAccount["AccountManagerEditDate"] != null && rdrAccount["AccountManagerEditDate"].ToString() != "")
                            Acc.AccountManagerEditDate = Convert.ToDateTime(rdrAccount["AccountManagerEditDate"].ToString());
                        else
                            Acc.AccountManagerEditDate = DateTime.MinValue;

                        if (rdrAccount["AccountManagerID"] != null && rdrAccount["AccountManagerID"].ToString() != "")
                            Acc.AccountManagerID = int.Parse(rdrAccount["AccountManagerID"].ToString());
                        else
                            Acc.AccountManagerID = int.MinValue;

                        Acc.AccountName = rdrAccount["AName"].ToString();
                        if (rdrAccount["AccoutnManagerAssignedDate"] != null && rdrAccount["AccoutnManagerAssignedDate"].ToString() != "")
                            Acc.AccountManagerAssignedDate = Convert.ToDateTime(rdrAccount["AccoutnManagerAssignedDate"].ToString());
                        else
                            Acc.AccountManagerAssignedDate = DateTime.MinValue;

                        if (rdrAccount["BusSector"] != null && rdrAccount["BusSector"].ToString() != "")
                            Acc.BusSector = int.Parse(rdrAccount["BusSector"].ToString());
                        else
                            Acc.BusSector = int.MinValue;

                        Acc.City = rdrAccount["City"].ToString();
                        if (rdrAccount["CountryID"] != null && rdrAccount["CountryID"].ToString() != "")
                            Acc.CountryID = int.Parse(rdrAccount["CountryID"].ToString());
                        else
                            Acc.CountryID = int.MinValue;

                        if (rdrAccount["EditByID"] != null && rdrAccount["EditByID"].ToString() != "")
                            Acc.EditByID = int.Parse(rdrAccount["EditByID"].ToString());
                        else
                            Acc.EditByID = int.MinValue;

                        if (rdrAccount["EditDate"] != null && rdrAccount["EditDate"].ToString() != "")
                            Acc.EditDate = Convert.ToDateTime(rdrAccount["EditDate"].ToString());
                        else
                            Acc.EditDate = DateTime.MinValue;

                        if (rdrAccount["AccountManagerEditByID"] != null && rdrAccount["EnterByID"].ToString() != "")
                            Acc.EnterByID = int.Parse(rdrAccount["EnterByID"].ToString());
                        else
                            Acc.EnterByID = int.MinValue;

                        if (rdrAccount["AccountManagerEditByID"] != null && rdrAccount["EnterDate"].ToString() != "")
                            Acc.EnterDate = Convert.ToDateTime(rdrAccount["EnterDate"].ToString());
                        else
                            Acc.EnterDate = DateTime.MinValue;
                        
                        Acc.Fax = rdrAccount["Fax"].ToString();
                        if (rdrAccount["IDStatus"] != null && rdrAccount["IDStatus"].ToString() != "")
                            Acc.IDStatus = int.Parse(rdrAccount["IDStatus"].ToString());
                        else
                            Acc.IDStatus = int.MinValue;
                        Acc.Phone = rdrAccount["Phone"].ToString();
                        Acc.ReferedBy = rdrAccount["ReferedBy"].ToString();
                        Acc.Street1 = rdrAccount["Street1"].ToString();
                        Acc.Street2 = rdrAccount["Street2"].ToString();
                        if (rdrAccount["TypeID"] != null && rdrAccount["TypeID"].ToString() != "")
                            Acc.TypeID = int.Parse(rdrAccount["TypeID"].ToString());
                        else
                            Acc.TypeID = int.MinValue;
                        Acc.WebSite = rdrAccount["WebSite"].ToString();
                        Acc.ZipCode = rdrAccount["ZipCode"].ToString();
                        Acc.BusinessSectorName = rdrAccount["BusinessSectorName"].ToString();
                        Acc.CountryName = rdrAccount["CountryName"].ToString();
                        Acc.StatusName = rdrAccount["StatusName"].ToString();
                        Acc.EditByName = rdrAccount["EditByName"].ToString();
                        Acc.EnteredByName = rdrAccount["EnterByName"].ToString();
                        Acc.AccountManagerName = rdrAccount["AccountManagerName"].ToString();
                        Acc.AccountManagerEditByName = rdrAccount["AccountManagerEditByName"].ToString();
                        Acc.State = rdrAccount["State"].ToString();
                        if (rdrAccount["Tag"] != null && rdrAccount["Tag"].ToString() != "")
                            Acc.Tag = Convert.ToBoolean(rdrAccount["Tag"]);
                        else
                            Acc.Tag = false;
                        if (rdrAccount["TopAccount"] != null && rdrAccount["TopAccount"].ToString() != "")
                            Acc.TopAccount = Convert.ToBoolean(rdrAccount["TopAccount"]);
                        else
                            Acc.TopAccount = false;
                        Acc.Profile = rdrAccount["Profile"].ToString();
                        // Added By Fawzi For Task 1703
                        if (rdrAccount["LastAccountNoteDate"] != null && rdrAccount["LastAccountNoteDate"].ToString() != "")
                            Acc.LastAccountNoteDate = Convert.ToDateTime(rdrAccount["LastAccountNoteDate"].ToString());
                        Acc.Email = rdrAccount["Email"].ToString();
                        //
                        AccList.Add(Acc);
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
                conAccount.Close();
            }
            return AccList;
        }

        public static int GetAccountsPages(int PageSize)
        {
            SqlConnection conAccount = new SqlConnection(StrCon);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(conAccount, "SP_Get_Accounts_Pages", PageSize));
        }

        public DataTable GetAccountsDS(int PageSize, int PageNum)
        {
            SqlConnection conAccount = new SqlConnection(StrCon);
            DataTable dt = new DataTable();
            dt.Columns.Add("AccountID", typeof(int));
            dt.Columns.Add("AccountName", typeof(string));
            dt.Columns.Add("TypeID", typeof(int));
            dt.Columns.Add("BusSector", typeof(int));
            dt.Columns.Add("Fax", typeof(string));
            dt.Columns.Add("Phone", typeof(string));
            dt.Columns.Add("WebSite", typeof(string));
            dt.Columns.Add("Status", typeof(int));
            dt.Columns.Add("Street1", typeof(string));
            dt.Columns.Add("City", typeof(string));
            dt.Columns.Add("ZipCode", typeof(string));
            dt.Columns.Add("CountryID", typeof(int));
            dt.Columns.Add("ReferedBy", typeof(string));
            dt.Columns.Add("EnterByID", typeof(int));
            dt.Columns.Add("EnterDate", typeof(DateTime));
            dt.Columns.Add("EditByID", typeof(int));
            dt.Columns.Add("EditDate", typeof(DateTime));
            dt.Columns.Add("Street2", typeof(string));
            dt.Columns.Add("AccountManagerID", typeof(int));
            dt.Columns.Add("AccountManagerEditDate", typeof(DateTime));
            dt.Columns.Add("AccountManagerEditByID", typeof(int));
            dt.Columns.Add("AccountManagerAssignedDate", typeof(DateTime));
            dt.Columns.Add("BusSectorName", typeof(string));
            dt.Columns.Add("CountryName", typeof(string));
            dt.Columns.Add("StatusName", typeof(string));
            dt.Columns.Add("EditByName", typeof(string));
            dt.Columns.Add("EnteredByName", typeof(string));
            dt.Columns.Add("AccountManagerName", typeof(string));
            dt.Columns.Add("AccountManagerEditByName", typeof(string));
            dt.Columns.Add("State", typeof(string));
            dt.Columns.Add("Tag", typeof(bool));
            dt.Columns.Add("Profile", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("TopAccount", typeof(bool));

            try
            {
                SqlDataReader rdrAccount = SqlHelper.ExecuteReader(conAccount, "SP_Get_Accounts_By_Page", PageSize, PageNum);
                int RowIndex = -1;
                while (rdrAccount.Read())
                {
                    try
                    {
                        RowIndex++;
                        dt.Rows.InsertAt(dt.NewRow(), RowIndex);

                        dt.Rows[RowIndex]["AccountID"] = int.Parse(rdrAccount["AID"].ToString());
                        if (rdrAccount["AccountManagerEditByID"] != null && rdrAccount["AccountManagerEditByID"].ToString() != "")
                            dt.Rows[RowIndex]["AccountManagerEditByID"] = int.Parse(rdrAccount["AccountManagerEditByID"].ToString());
                        else
                            dt.Rows[RowIndex]["AccountManagerEditByID"] = int.MinValue;

                        if (rdrAccount["AccountManagerEditDate"] != null && rdrAccount["AccountManagerEditDate"].ToString() != "")
                            dt.Rows[RowIndex]["AccountManagerEditDate"] = Convert.ToDateTime(rdrAccount["AccountManagerEditDate"].ToString());
                        else
                            dt.Rows[RowIndex]["AccountManagerEditDate"] = DateTime.MinValue;

                        if (rdrAccount["AccountManagerID"] != null && rdrAccount["AccountManagerID"].ToString() != "")
                            dt.Rows[RowIndex]["AccountManagerID"] = int.Parse(rdrAccount["AccountManagerID"].ToString());
                        else
                            dt.Rows[RowIndex]["AccountManagerID"] = int.MinValue;

                        dt.Rows[RowIndex]["AccountName"] = rdrAccount["AName"].ToString();
                        if (rdrAccount["AccoutnManagerAssignedDate"] != null && rdrAccount["AccoutnManagerAssignedDate"].ToString() != "")
                            dt.Rows[RowIndex]["AccountManagerAssignedDate"] = Convert.ToDateTime(rdrAccount["AccoutnManagerAssignedDate"].ToString());
                        else
                            dt.Rows[RowIndex]["AccountManagerAssignedDate"] = DateTime.MinValue;

                        if (rdrAccount["BusSector"] != null && rdrAccount["BusSector"].ToString() != "")
                            dt.Rows[RowIndex]["BusSector"] = int.Parse(rdrAccount["BusSector"].ToString());
                        else
                            dt.Rows[RowIndex]["BusSector"] = DBNull.Value;

                        dt.Rows[RowIndex]["City"] = rdrAccount["City"].ToString();
                        if (rdrAccount["CountryID"] != null && rdrAccount["CountryID"].ToString() != "")
                            dt.Rows[RowIndex]["CountryID"] = int.Parse(rdrAccount["CountryID"].ToString());
                        else
                            dt.Rows[RowIndex]["CountryID"] = int.MinValue;

                        if (rdrAccount["EditByID"] != null && rdrAccount["EditByID"].ToString() != "")
                            dt.Rows[RowIndex]["EditByID"] = int.Parse(rdrAccount["EditByID"].ToString());
                        else
                            dt.Rows[RowIndex]["EditByID"] = int.MinValue;

                        if (rdrAccount["EditDate"] != null && rdrAccount["EditDate"].ToString() != "")
                            dt.Rows[RowIndex]["EditDate"] = Convert.ToDateTime(rdrAccount["EditDate"].ToString());
                        else
                            dt.Rows[RowIndex]["EditDate"] = DateTime.MinValue;

                        if (rdrAccount["AccountManagerEditByID"] != null && rdrAccount["EnterByID"].ToString() != "")
                            dt.Rows[RowIndex]["EnterByID"] = int.Parse(rdrAccount["EnterByID"].ToString());
                        else
                            dt.Rows[RowIndex]["EnterByID"] = int.MinValue;

                        if (rdrAccount["AccountManagerEditByID"] != null && rdrAccount["EnterDate"].ToString() != "")
                            dt.Rows[RowIndex]["EnterDate"] = Convert.ToDateTime(rdrAccount["EnterDate"].ToString());
                        else
                            dt.Rows[RowIndex]["EnterDate"] = DateTime.MinValue;

                        dt.Rows[RowIndex]["Fax"] = rdrAccount["Fax"].ToString();
                        if (rdrAccount["IDStatus"] != null && rdrAccount["IDStatus"].ToString() != "")
                            dt.Rows[RowIndex]["Status"] = int.Parse(rdrAccount["IDStatus"].ToString());
                        else
                            dt.Rows[RowIndex]["Status"] = DBNull.Value;
                        dt.Rows[RowIndex]["Phone"] = rdrAccount["Phone"].ToString();
                        dt.Rows[RowIndex]["ReferedBy"] = rdrAccount["ReferedBy"].ToString();
                        dt.Rows[RowIndex]["Street1"] = rdrAccount["Street1"].ToString();
                        dt.Rows[RowIndex]["Street2"] = rdrAccount["Street2"].ToString();
                        if (rdrAccount["TypeID"] != null && rdrAccount["TypeID"].ToString() != "")
                            dt.Rows[RowIndex]["TypeID"] = int.Parse(rdrAccount["TypeID"].ToString());
                        else
                            dt.Rows[RowIndex]["TypeID"] = int.MinValue;
                        dt.Rows[RowIndex]["WebSite"] = rdrAccount["WebSite"].ToString();
                        dt.Rows[RowIndex]["ZipCode"] = rdrAccount["ZipCode"].ToString();
                        dt.Rows[RowIndex]["BusSectorName"] = rdrAccount["BusinessSectorName"].ToString();
                        dt.Rows[RowIndex]["CountryName"] = rdrAccount["CountryName"].ToString();
                        dt.Rows[RowIndex]["StatusName"] = rdrAccount["StatusName"].ToString();
                        dt.Rows[RowIndex]["EditByName"] = rdrAccount["EditByName"].ToString();
                        dt.Rows[RowIndex]["EnteredByName"] = rdrAccount["EnterByName"].ToString();
                        dt.Rows[RowIndex]["AccountManagerName"] = rdrAccount["AccountManagerName"].ToString();
                        dt.Rows[RowIndex]["AccountManagerEditByName"] = rdrAccount["AccountManagerEditByName"].ToString();
                        dt.Rows[RowIndex]["State"] = rdrAccount["State"].ToString();
                        if (rdrAccount["Tag"] != null && rdrAccount["Tag"].ToString() != "")
                            dt.Rows[RowIndex]["Tag"] = Convert.ToBoolean(rdrAccount["Tag"]);
                        else
                            dt.Rows[RowIndex]["Tag"] = false;
                        if (rdrAccount["TopAccount"] != null && rdrAccount["TopAccount"].ToString() != "")
                            dt.Rows[RowIndex]["TopAccount"] = Convert.ToBoolean(rdrAccount["TopAccount"]);
                        else
                            dt.Rows[RowIndex]["TopAccount"] = false;
                        dt.Rows[RowIndex]["Profile"] = rdrAccount["Profile"].ToString();
                        // Added By Fawzi For Task 1703
                        if (rdrAccount["LastAccountNoteDate"] != null && rdrAccount["LastAccountNoteDate"].ToString() != "")
                            dt.Rows[RowIndex]["LastAccountNoteDate"] = Convert.ToDateTime(rdrAccount["LastAccountNoteDate"].ToString());
                        dt.Rows[RowIndex]["Email"] = rdrAccount["Email"].ToString();
                        //
                        //dt.Rows.Add(Acc.AccountID, Acc.AccountManagerEditByID, Acc.AccountManagerEditDate,
                        //    Acc.AccountManagerID, Acc.AccountName, Acc.AccountManagerAssignedDate, Acc.BusSector,
                        //    Acc.City, Acc.CountryID, Acc.EditByID, Acc.EditDate, Acc.EnterByID, Acc.EnterDate,
                        //    Acc.Fax, Acc.IDStatus, Acc.Phone, Acc.ReferedBy, Acc.Street1, Acc.Street2, Acc.TypeID,
                        //    Acc.WebSite, Acc.ZipCode, Acc.BusinessSectorName, Acc.CountryName, Acc.StatusName,
                        //    Acc.EditByName, Acc.EnteredByName, Acc.AccountManagerName, Acc.AccountManagerEditByName,
                        //    Acc.State, Acc.Tag, Acc.Profile);
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
                conAccount.Close();
            }
            return dt;
        }

        /// <summary>
        /// Get All Accounts Names For Incremental Search Purpose
        /// </summary>
        /// <returns>Array of strings contains all names</returns>
        public string[] GetAllAccountsNames(string Prefix, SearchBy SearchColumn)
        {
            string[] AccNames = new string[0];
            try
            {
                DataSet dsNames = new DataSet();
                dsNames = SqlHelper.ExecuteDataset(StrCon, "SP_Get_All_Accounts_Names", SearchColumn.ToString(), Prefix, "-1", "-1", "-1", "-1", "-1");
                AccNames = new string[dsNames.Tables[0].Rows.Count];
                for (int i = 0; i < dsNames.Tables[0].Rows.Count; i++)
                {
                    AccNames[i] = dsNames.Tables[0].Rows[i][SearchColumn.ToString()].ToString();
                }
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return AccNames;
        }

        /// <summary>
        /// Get All Accounts Names For Incremental Search Purpose
        /// </summary>
        /// <returns>Array of strings contains all names</returns>
        public string[] GetAllAccountsNames(string Prefix, SearchBy SearchColumn, string Country, string State, string BusSect, string Notes, string Tag)
        {
            string[] AccNames = new string[0];
            try
            {
                DataSet dsNames = new DataSet();
                dsNames = SqlHelper.ExecuteDataset(StrCon, "SP_Get_All_Accounts_Names", SearchColumn.ToString(), Prefix, Country, State, BusSect, Notes, Tag);
                AccNames = new string[dsNames.Tables[0].Rows.Count];
                for (int i = 0; i < dsNames.Tables[0].Rows.Count; i++)
                {
                    AccNames[i] = dsNames.Tables[0].Rows[i][SearchColumn.ToString()].ToString();
                }
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return AccNames;
        }

        /// <summary>
        /// Get single contact from ContacAccount 
        /// You need to fill the AccountID property First
        /// </summary>
        /// <returns>Single ContactAccount object</returns>
        public ContactAccount GetSingleContact()
        {
            SqlConnection conAccount = new SqlConnection(StrCon);
            ContactAccount Acc = new ContactAccount();

            try
            {
                SqlDataReader rdrAccount = SqlHelper.ExecuteReader(conAccount, "SP_Get_Single_Contact_Account", this.AccountID);
                
                while (rdrAccount.Read())
                {
                    try
                    {

                        Acc.AccountID = int.Parse(rdrAccount["AID"].ToString());
                        if (rdrAccount["AccountManagerEditByID"] != null && rdrAccount["AccountManagerEditByID"].ToString() != "")
                            Acc.AccountManagerEditByID = int.Parse(rdrAccount["AccountManagerEditByID"].ToString());
                        else
                            Acc.AccountManagerEditByID = int.MinValue;

                        if (rdrAccount["AccountManagerEditDate"] != null && rdrAccount["AccountManagerEditDate"].ToString() != "")
                            Acc.AccountManagerEditDate = Convert.ToDateTime(rdrAccount["AccountManagerEditDate"].ToString());
                        else
                            Acc.AccountManagerEditDate = DateTime.MinValue;

                        if (rdrAccount["AccountManagerID"] != null && rdrAccount["AccountManagerID"].ToString() != "")
                            Acc.AccountManagerID = int.Parse(rdrAccount["AccountManagerID"].ToString());
                        else
                            Acc.AccountManagerID = int.MinValue;

                        Acc.AccountName = rdrAccount["AName"].ToString();
                        if (rdrAccount["AccoutnManagerAssignedDate"] != null && rdrAccount["AccoutnManagerAssignedDate"].ToString() != "")
                            Acc.AccountManagerAssignedDate = Convert.ToDateTime(rdrAccount["AccoutnManagerAssignedDate"].ToString());
                        else
                            Acc.AccountManagerAssignedDate = DateTime.MinValue;

                        if (rdrAccount["BusSector"] != null && rdrAccount["BusSector"].ToString() != "")
                            Acc.BusSector = int.Parse(rdrAccount["BusSector"].ToString());
                        else
                            Acc.BusSector = int.MinValue;

                        Acc.City = rdrAccount["City"].ToString();
                        if (rdrAccount["CountryID"] != null && rdrAccount["CountryID"].ToString() != "")
                            Acc.CountryID = int.Parse(rdrAccount["CountryID"].ToString());
                        else
                            Acc.CountryID = int.MinValue;

                        if (rdrAccount["EditByID"] != null && rdrAccount["EditByID"].ToString() != "")
                            Acc.EditByID = int.Parse(rdrAccount["EditByID"].ToString());
                        else
                            Acc.EditByID = int.MinValue;

                        if (rdrAccount["EditDate"] != null && rdrAccount["EditDate"].ToString() != "")
                            Acc.EditDate = Convert.ToDateTime(rdrAccount["EditDate"].ToString());
                        else
                            Acc.EditDate = DateTime.MinValue;

                        if (rdrAccount["AccountManagerEditByID"] != null && rdrAccount["EnterByID"].ToString() != "")
                            Acc.EnterByID = int.Parse(rdrAccount["EnterByID"].ToString());
                        else
                            Acc.EnterByID = int.MinValue;

                        if (rdrAccount["AccountManagerEditByID"] != null && rdrAccount["EnterDate"].ToString() != "")
                            Acc.EnterDate = Convert.ToDateTime(rdrAccount["EnterDate"].ToString());
                        else
                            Acc.EnterDate = DateTime.MinValue;

                        Acc.Fax = rdrAccount["Fax"].ToString();
                        if (rdrAccount["IDStatus"] != null && rdrAccount["IDStatus"].ToString() != "")
                            Acc.IDStatus = int.Parse(rdrAccount["IDStatus"].ToString());
                        else
                            Acc.IDStatus = int.MinValue;
                        Acc.Phone = rdrAccount["Phone"].ToString();
                        Acc.ReferedBy = rdrAccount["ReferedBy"].ToString();
                        Acc.Street1 = rdrAccount["Street1"].ToString();
                        Acc.Street2 = rdrAccount["Street2"].ToString();
                        if (rdrAccount["TypeID"] != null && rdrAccount["TypeID"].ToString() != "")
                            Acc.TypeID = int.Parse(rdrAccount["TypeID"].ToString());
                        else
                            Acc.TypeID = int.MinValue;
                        Acc.WebSite = rdrAccount["WebSite"].ToString();
                        Acc.ZipCode = rdrAccount["ZipCode"].ToString();
                        Acc.BusinessSectorName = rdrAccount["BusinessSectorName"].ToString();
                        Acc.CountryName = rdrAccount["CountryName"].ToString();
                        Acc.StatusName = rdrAccount["StatusName"].ToString();
                        Acc.EditByName = rdrAccount["EditByName"].ToString();
                        Acc.EnteredByName = rdrAccount["EnterByName"].ToString();
                        Acc.AccountManagerName = rdrAccount["AccountManagerName"].ToString();
                        Acc.AccountManagerEditByName = rdrAccount["AccountManagerEditByName"].ToString();
                        Acc.State = rdrAccount["State"].ToString();
                        if (rdrAccount["Tag"] != null && rdrAccount["Tag"].ToString() != "")
                            Acc.Tag = Convert.ToBoolean(rdrAccount["Tag"]);
                        else
                            Acc.Tag = false;
                        if (rdrAccount["TopAccount"] != null && rdrAccount["TopAccount"].ToString() != "")
                            Acc.TopAccount = Convert.ToBoolean(rdrAccount["TopAccount"]);
                        else
                            Acc.TopAccount = false;
                        Acc.Profile = rdrAccount["Profile"].ToString();
                        // Added By Fawzi For Task 1703
                        if (rdrAccount["LastAccountNoteDate"] != null && rdrAccount["LastAccountNoteDate"].ToString() != "")
                            Acc.LastAccountNoteDate = Convert.ToDateTime(rdrAccount["LastAccountNoteDate"].ToString());
                        Acc.Email = rdrAccount["Email"].ToString();
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
                conAccount.Close();
            }
            return Acc;
        }

        /// <summary>
        /// Get all accounts names and ids
        /// </summary>
        /// <returns>List of  ContactAccount objects that meets the search filter</returns>
        public List<ContactAccount> GetAccounList(string BusSector)
        {
            List<ContactAccount> AccList = new List<ContactAccount>();
            SqlConnection conList = new SqlConnection(StrCon);
            try
            {
                SqlDataReader rdrAccList = SqlHelper.ExecuteReader(StrCon, "SP_Get_Account_List", BusSector);
                ContactAccount CntAcc;
                while (rdrAccList.Read())
                {
                    CntAcc = new ContactAccount();

                    CntAcc.AccountID = int.Parse(rdrAccList["AID"].ToString());
                    CntAcc.AccountName = rdrAccList["AName"].ToString();

                    AccList.Add(CntAcc);
                }
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                conList.Close();
            }
            return AccList;
        }

        public DataTable GetAccounList()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("AccountID", typeof(int));
            dt.Columns.Add("Account", typeof(string));
            SqlConnection conList = new SqlConnection(StrCon);
            try
            {
                SqlDataReader rdrAccList = SqlHelper.ExecuteReader(StrCon, "SP_Get_Account_List", "-1");
                while (rdrAccList.Read())
                {
                    dt.Rows.Add(Convert.ToInt32(rdrAccList["AID"]), rdrAccList["AName"].ToString());
                }
                dt.Rows.Add(null, "");
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                conList.Close();
            }

            return dt;
        }

        /// <summary>
        /// Delete existing record in table Contact_Account
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public string DeleteAccount()
        {
            object Affected = "-1";
            try
            {
                object[] Params = { _AccountID, 0 };
                Affected = BaseClass.ReturnValueCommand("SP_DELETE_Contact_Account", Params);
            }
            catch (Exception Exp)
            {
                return Exp.Message;
            }
            return Affected.ToString();
        }
        

        #endregion

        #region -----------------Private Functions----------------
        
        private string BuildFilter()
        {
            
            string TagValue = "";
            if (this.AccountID == null)
                this.AccountID = -1;

            if (this.AccountName == null || this.AccountName.Trim() == "")
                this.AccountName = "-1";

            if (this.City == null || this.City.Trim() == "")
                this.City = "-1";

            if (this.Phone == null || this.Phone.Trim() == "")
                this.Phone = "-1";

            if (this.CountryName == null || this.CountryName.Trim() == "")
                this.CountryName = "-1";

            if (this.State == null || this.State.Trim() == "")
                this.State = "-1";

            if (this.BusinessSectorName == null || this.BusinessSectorName.Trim() == "")
                this.BusinessSectorName = "-1";
            
            if (this.IDStatus == null)
                this.IDStatus = -1;

            if (this.Tag == null)
                TagValue = "-1";
            else
            {
                if (this.Tag == true)
                    TagValue = "1";
                else
                    TagValue = "0";
            }

            return TagValue;
        }

        private object [] BuildUpdateQueryParams()
        {
            object[] UpdateParameters = new object[27];
            UpdateParameters[0] = this.AccountID.ToString();

            if (this.AccountName == null)
                UpdateParameters[1] = "-1";
            else
                UpdateParameters[1] = this.AccountName.Replace("'","''");
            
            if (this.TypeID == null)
                UpdateParameters[2] = "-1";
            else
                UpdateParameters[2] = this.TypeID.ToString();
            
            if (this.BusSector == null)
                UpdateParameters[3] = "-1";
            else
                UpdateParameters[3] = this.BusSector.ToString();

            if (this.Fax == null)
                UpdateParameters[4] = "-1";
            else
                UpdateParameters[4] = this.Fax.ToString();
            
            if (this.Phone == null)
                UpdateParameters[5] = "-1";
            else
                UpdateParameters[5] = this.Phone.ToString();
            
            if (this.WebSite == null)
                UpdateParameters[6] = "-1";
            else
                UpdateParameters[6] = this.WebSite.ToString();

            if (this.IDStatus == null)
                UpdateParameters[7] = "-1";
            else
                UpdateParameters[7] = this.IDStatus.ToString();

            if (this.Street1 == null)
                UpdateParameters[8] = "-1";
            else
                UpdateParameters[8] = this.Street1.ToString();

            if (this.City == null)
                UpdateParameters[9] = "-1";
            else
                UpdateParameters[9] = this.City.ToString();

            if (this.ZipCode == null)
                UpdateParameters[10] = "-1";
            else
                UpdateParameters[10] = this.ZipCode.ToString();

            if (this.CountryID == null)
                UpdateParameters[11] = "-1";
            else
                UpdateParameters[11] = this.CountryID.ToString();

            if (this.ReferedBy == null)
                UpdateParameters[12] = "-1";
            else
                UpdateParameters[12] = this.ReferedBy.ToString();

            if (this.EnterByID == null)
                UpdateParameters[13] = "-1";
            else
                UpdateParameters[13] = this.EnterByID.ToString();

            if (this.EnterDate == null)
                UpdateParameters[14] = "-1";
            else
                UpdateParameters[14] = this.EnterDate.ToString();

            if (this.EditByID == null)
                UpdateParameters[15] = "-1";
            else
                UpdateParameters[15] = this.EditByID.ToString();

            if (this.EditDate == null)
                UpdateParameters[16] = "-1";
            else
                UpdateParameters[16] = this.EditDate.ToString();

            if (this.Street2 == null)
                UpdateParameters[17] = "-1";
            else
                UpdateParameters[17] = this.Street2.ToString();

            if (this.AccountManagerID == null)
                UpdateParameters[18] = "-1";
            else
                UpdateParameters[18] = this.AccountManagerID.ToString();

            if (this.AccountManagerEditDate == null)
                UpdateParameters[19] = "-1";
            else
                UpdateParameters[19] = this.AccountManagerEditDate.ToString();

            if (this.AccountManagerEditByID == null)
                UpdateParameters[20] = "-1";
            else
                UpdateParameters[20] = this.AccountManagerEditByID.ToString();

            if (this.AccountManagerAssignedDate == null)
                UpdateParameters[21] = "-1";
            else
                UpdateParameters[21] = this.AccountManagerAssignedDate.ToString();

            if (this.State == null)
                UpdateParameters[22] = "-1";
            else
                UpdateParameters[22] = this.State.ToString();

            if (this.Tag == null)
                UpdateParameters[23] = "-1";
            else
            {
                if (this.Tag == true)
                    UpdateParameters[23] = "1";
                else
                    UpdateParameters[23] = "0";
            }
            if (this.Profile == null)
                UpdateParameters[24] = "-1";
            else
                UpdateParameters[24] = this.Profile.ToString();
            if (this.Email == null)
                UpdateParameters[25] = "-1";
            else
                UpdateParameters[25] = this.Email.ToString();
            if (this.TopAccount == null)
                UpdateParameters[26] = "-1";
            else
                UpdateParameters[26] = this.TopAccount.ToString();
            return UpdateParameters;
        }

        private string BuildSortCriteria()
        {
            string SortCriteria = "-1";

            if (this.SortExpression == SortBy.AccountID)
                SortCriteria = "AID";
            if (this.SortExpression == SortBy.City)
                SortCriteria = "City";
            if (this.SortExpression == SortBy.BusinessSectorName)
                SortCriteria = "BusinessSectorName";
            if (this.SortExpression == SortBy.StatusName)
                SortCriteria = "StatusName";
            if (this.SortExpression == SortBy.CompanyName)
                SortCriteria = "AName";
            if (this.SortExpression == SortBy.State)
                SortCriteria = "State";
            if (this.SortExpression == SortBy.Tag)
                SortCriteria = "Tag";
            if (this.SortExpression == SortBy.CountryName)
                SortCriteria = "CountryName";
            //
            if (this.SortExpression == SortBy.LastAccountNoteDate)
                SortCriteria = "LastAccountNoteDate";
            //
            if (this.SortDirect == SortDirection.Ascending)
                SortCriteria += " ASC";
            if (this.SortDirect == SortDirection.Descending)
                SortCriteria += " Desc";

            return SortCriteria;
        }

        #endregion


        public SortBy CompanyName { get; set; }
    }
}