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
using Office.DAL.ApplicationBlocks;
using System.Data.SqlClient;

namespace Office.DAL
{
    [Serializable]
    public class Branches
    {
        #region -----------------Constructor---------------------

        public Branches()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region --------------------Properties -------------------

        public enum SortBy
        {
            BranchID,
            BranchName,
            BusinessSectorName,
            City,
            State,
            Tag,
            LastAccountNoteDate,
            IDStatus,
            CountryName
        }

        public enum SearchBy
        {
            BrnachName,
            BusinessSectorName
        }

        public int? BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }

        public string BranchName
        {
            get { return _BranchName; }
            set { _BranchName = value; }
        }

        public int? TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }

        public int? BussinessSectorID
        {
            get { return _BussinessSectorID; }
            set { _BussinessSectorID = value; }
        }

        public string TypeName
        {
            get { return _TypeName; }
            set { _TypeName = value; }
        }

        public string BussinessSectorName
        {
            get { return _BussinessSectorName; }
            set { _BussinessSectorName = value; }
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

        public string StatusName
        {
            get { return _StatusName; }
            set { _StatusName = value; }
        }

        public string Street1
        {
            get { return _Street1; }
            set { _Street1 = value; }
        }

        private string _ZipCode;

        public string ZipCode
        {
            get { return _ZipCode; }
            set { _ZipCode = value; }
        }

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        public int? CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }

        public string CountryName
        {
            get { return _CountryName; }
            set { _CountryName = value; }
        }

        public string ReferedBy
        {
            get { return _ReferedBy; }
            set { _ReferedBy = value; }
        }

        public string Street2
        {
            get { return _Street2; }
            set { _Street2 = value; }
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

        public string BranchManagerName
        {
            get { return _BranchManagerName; }
            set { _BranchManagerName = value; }
        }

        public string BranchManagerEditByName
        {
            get { return _BranchManagerEditByName; }
            set { _BranchManagerEditByName = value; }
        }

        public int? BranchManagerID
        {
            get { return _BranchManagerID; }
            set { _BranchManagerID = value; }
        }

        public DateTime? BranchManagerEditDate
        {
            get { return _BranchManagerEditDate; }
            set { _BranchManagerEditDate = value; }
        }

        public int? BranchManagerEditByID
        {
            get { return _BranchManagerEditByID; }
            set { _BranchManagerEditByID = value; }
        }

        public DateTime? BranchManagerAssignedDate
        {
            get { return _BranchManagerAssignedDate; }
            set { _BranchManagerAssignedDate = value; }
        }

        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        public int? AccountID
        {
            get { return _AccountID; }
            set { _AccountID = value; }
        }

        public string AccountName
        {
            get { return _AccountName; }
            set { _AccountName = value; }
        }

        public bool? MainOffice
        {
            get { return _MainOffice; }
            set { _MainOffice = value; }
        }

        public int? ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; }
        }

        public string ContactFullName
        {
            get { return _ContactFullName; }
            set { _ContactFullName = value; }
        }

        public DateTime? LastBranchNoteDate
        {
            get { return _LastBranchNoteDate; }
            set { _LastBranchNoteDate = value; }
        }

        public int? FilterBranchNotes
        {
            get { return _FilterBranchNotes; }
            set { _FilterBranchNotes = value; }
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
        //public string SCode
        //{
        //    get { return _SCode; }
        //    set { _SCode = value; }
        //}

        //public int? SID
        //{
        //    get { return _SID; }
        //    set { _SID = value; }
        //}

        #endregion

        #region -----------------Private Variables-----------------

        private int? _EnterByID;
        private DateTime? _EnterDate;
        private int? _EditByID;
        private DateTime? _EditDate;
        private string _EditByName;
        private string _EnteredByName;
        private int? _BranchManagerID;
        private DateTime? _BranchManagerEditDate;
        private int? _BranchManagerEditByID;
        private DateTime? _BranchManagerAssignedDate;
        private string _BranchManagerName;
        private string _BranchManagerEditByName;
        private string _State;
        private int? _AccountID;
        private string _AccountName;
        private bool? _MainOffice;
        private int? _ContactID;
        private string _ContactFullName;
        //private string _SCode;
        //private int? _SID;
        private string _BussinessSectorName;
        private int? _BussinessSectorID;
        private string _TypeName;
        private string _StatusName;
        private string _Street1;
        private string _Fax;
        private int? _IDStatus;
        private string _Phone;
        private string _WebSite;
        private int? _CountryID;
        private string _CountryName;
        private string _ReferedBy;
        private string _Street2;
        private int? _BranchID;
        private string _BranchName;
        private int? _TypeID;
        private string _City;
        private DateTime? _LastBranchNoteDate;
        private int? _FilterBranchNotes;
        private SortBy _SortExpression;
        private SortDirection _SortDirect;
        string StrCon = ConfigurationManager.ConnectionStrings["ASI-CRMConnectionString"].ToString();

        #endregion

        #region -----------------General Functions----------------

        /// <summary>
        /// Insert new record into table Contact_Branches
        /// Fill in all properties of the Branches Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int AddNewBranch()
        {
            int AffectedRows = -1;
            try
            {
                if (this._MainOffice == null)
                    this.MainOffice = false;
                object ReturnVal = SqlHelper.ExecuteScalar(StrCon, "SP_INSERT_INTO_Contact_Branchs", this._BranchName, this._TypeID, this._BussinessSectorID, this._Fax, this._Phone, this._WebSite
                                                    , this._IDStatus, this._Street1, this._City, this._ZipCode, this._CountryID, this._ReferedBy, this._EnterByID, this._EnterDate, this._EditByID
                                                    , this._EditDate, this._Street2, this._BranchManagerID, this._BranchManagerEditDate, this._BranchManagerEditByID
                                                    , this._BranchManagerAssignedDate, this._State, this._AccountID, this._MainOffice);
                if (ReturnVal != null)
                    AffectedRows = Convert.ToInt32(ReturnVal.ToString());
               // AffectedRows = 1;
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return AffectedRows;
        }

        /// <summary>
        /// Update existing record in table Contact_Branches
        /// Fill in all properties of the Branches Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int UpdateBranch()
        {
            int Affected = -1;

            try
            {
                object[] Params = BuildUpdateQueryParams();
                string st = "";
                foreach (object param in Params)
                    st += param.ToString() + ";";
                Affected = BaseClass.UpdateCommand("SP_UPDATE_Contact_Branches", Params);
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return Affected;
        }

        public List<Branches> GetBranchesData()
        {
            SqlConnection conBranch = new SqlConnection(StrCon);
            List<Branches> BranchList = new List<Branches>();

            try
            {
                BuildFilter();
                string SortCriteria = BuildSortCriteria();
                SqlDataReader rdrBranch = SqlHelper.ExecuteReader(conBranch, "SP_Get_Branches", this.BranchID, this.IDStatus, this.BranchName, this.City, this.Phone, this.State, this.BussinessSectorName, this.CountryName, SortCriteria, this.FilterBranchNotes);
                Branches Bran;

                while (rdrBranch.Read())
                {
                    try
                    {
                        Bran = new Branches();
                        Bran.BranchID = int.Parse(rdrBranch["BranchID"].ToString());

                        if (rdrBranch["AccountID"] != null && rdrBranch["AccountID"].ToString() != "")
                            Bran.AccountID = int.Parse(rdrBranch["AccountID"].ToString());
                        else
                            Bran.AccountID = int.MinValue;

                        Bran.AccountName = rdrBranch["AccountName"].ToString();

                        if (rdrBranch["BranchID"] != null && rdrBranch["BranchID"].ToString() != "")
                            Bran.BranchID = int.Parse(rdrBranch["BranchID"].ToString());
                        else
                            Bran.BranchID = int.MinValue;

                        if (rdrBranch["BranchManagerAssignedDate"] != null && rdrBranch["BranchManagerAssignedDate"].ToString() != "")
                            Bran.BranchManagerAssignedDate = Convert.ToDateTime(rdrBranch["BranchManagerAssignedDate"].ToString());
                        else
                            Bran.BranchManagerAssignedDate = DateTime.MinValue;

                        if (rdrBranch["BranchManagerEditByID"] != null && rdrBranch["BranchManagerEditByID"].ToString() != "")
                            Bran.BranchManagerEditByID = int.Parse(rdrBranch["BranchManagerEditByID"].ToString());
                        else
                            Bran.BranchManagerEditByID = int.MinValue;

                        Bran.BranchManagerEditByName = rdrBranch["BranchManagerEditByName"].ToString();

                        if (rdrBranch["BranchManagerEditDate"] != null && rdrBranch["BranchManagerEditDate"].ToString() != "")
                            Bran.BranchManagerEditDate = Convert.ToDateTime(rdrBranch["BranchManagerEditDate"].ToString());
                        else
                            Bran.BranchManagerEditDate = DateTime.MinValue;

                        if (rdrBranch["BranchManagerID"] != null && rdrBranch["BranchManagerID"].ToString() != "")
                            Bran.BranchManagerID = int.Parse(rdrBranch["BranchManagerID"].ToString());
                        else
                            Bran.BranchManagerID = int.MinValue;

                        Bran.BranchManagerName = rdrBranch["BranchManagerName"].ToString();

                        Bran.BranchName = rdrBranch["BranchName"].ToString();

                        if (rdrBranch["BussinessSectorID"] != null && rdrBranch["BussinessSectorID"].ToString() != "")
                            Bran.BussinessSectorID = int.Parse(rdrBranch["BussinessSectorID"].ToString());
                        else
                            Bran.BussinessSectorID = int.MinValue;

                        Bran.BussinessSectorName = rdrBranch["BussinessSectorName"].ToString();

                        Bran.City = rdrBranch["City"].ToString();

                        Bran.ContactFullName = rdrBranch["ContactFullName"].ToString();

                        if (rdrBranch["ContactID"] != null && rdrBranch["ContactID"].ToString() != "")
                            Bran.ContactID = int.Parse(rdrBranch["ContactID"].ToString());
                        else
                            Bran.ContactID = int.MinValue;

                        if (rdrBranch["CountryID"] != null && rdrBranch["CountryID"].ToString() != "")
                            Bran.CountryID = int.Parse(rdrBranch["CountryID"].ToString());
                        else
                            Bran.CountryID = int.MinValue;

                        Bran.CountryName = rdrBranch["CountryName"].ToString();

                        if (rdrBranch["EditByID"] != null && rdrBranch["EditByID"].ToString() != "")
                            Bran.EditByID = int.Parse(rdrBranch["EditByID"].ToString());
                        else
                            Bran.EditByID = int.MinValue;

                        Bran.EditByName = rdrBranch["EditByName"].ToString();

                        if (rdrBranch["EditDate"] != null && rdrBranch["EditDate"].ToString() != "")
                            Bran.EditDate = Convert.ToDateTime(rdrBranch["EditDate"].ToString());
                        else
                            Bran.EditDate = DateTime.MinValue;

                        if (rdrBranch["EnterByID"] != null && rdrBranch["EnterByID"].ToString() != "")
                            Bran.EnterByID = int.Parse(rdrBranch["EnterByID"].ToString());
                        else
                            Bran.EnterByID = int.MinValue;

                        if (rdrBranch["EnterDate"] != null && rdrBranch["EnterDate"].ToString() != "")
                            Bran.EnterDate = Convert.ToDateTime(rdrBranch["EnterDate"].ToString());
                        else
                            Bran.EnterDate = DateTime.MinValue;

                        Bran.EnteredByName = rdrBranch["EnteredByName"].ToString();

                        Bran.Fax = rdrBranch["Fax"].ToString();

                        if (rdrBranch["IDStatus"] != null && rdrBranch["IDStatus"].ToString() != "")
                            Bran.IDStatus = int.Parse(rdrBranch["IDStatus"].ToString());
                        else
                            Bran.IDStatus = int.MinValue;

                        if (rdrBranch["MainOffice"] != null && rdrBranch["MainOffice"].ToString() != "")
                            Bran.MainOffice = Convert.ToBoolean(rdrBranch["MainOffice"]);
                        else
                            Bran.MainOffice = false;

                        Bran.Phone = rdrBranch["Phone"].ToString();
                        Bran.ReferedBy = rdrBranch["ReferedBy"].ToString();
                        //Bran.SCode = rdrBranch["SCode"].ToString();

                        //if (rdrBranch["SID"] != null && rdrBranch["SID"].ToString() != "")
                        //    Bran.SID = int.Parse(rdrBranch["SID"].ToString());
                        //else
                        //    Bran.SID = int.MinValue;

                        Bran.State = rdrBranch["State"].ToString();
                        Bran.StatusName = rdrBranch["StatusName"].ToString();
                        Bran.Street1 = rdrBranch["Street1"].ToString();
                        Bran.Street2 = rdrBranch["Street2"].ToString();

                        if (rdrBranch["TypeID"] != null && rdrBranch["TypeID"].ToString() != "")
                            Bran.TypeID = int.Parse(rdrBranch["TypeID"].ToString());
                        else
                            Bran.TypeID = int.MinValue;

                        Bran.TypeName = rdrBranch["TypeName"].ToString();
                        Bran.WebSite = rdrBranch["WebSite"].ToString();
                        Bran.ZipCode = rdrBranch["ZipCode"].ToString();

                        if (rdrBranch["LastBranchNoteDate"] != null && rdrBranch["LastBranchNoteDate"].ToString() != "")
                            Bran.LastBranchNoteDate = Convert.ToDateTime(rdrBranch["LastBranchNoteDate"].ToString());
                        else
                            Bran.LastBranchNoteDate = DateTime.MinValue;

                        BranchList.Add(Bran);
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
                conBranch.Close();
            }

            return BranchList;
        }

        public Branches GetSingleBranch()
        {
            SqlConnection conBranch = new SqlConnection(StrCon);
            Branches Bran = new Branches();

            try
            {
                SqlDataReader rdrBranch = SqlHelper.ExecuteReader(conBranch, "SP_Get_Single_Contact_Branches", this.BranchID);

                while (rdrBranch.Read())
                {
                    try
                    {
                        Bran.BranchID = int.Parse(rdrBranch["BranchID"].ToString());

                        if (rdrBranch["AccountID"] != null && rdrBranch["AccountID"].ToString() != "")
                            Bran.AccountID = int.Parse(rdrBranch["AccountID"].ToString());
                        else
                            Bran.AccountID = int.MinValue;

                        Bran.AccountName = rdrBranch["AccountName"].ToString();

                        if (rdrBranch["BranchID"] != null && rdrBranch["BranchID"].ToString() != "")
                            Bran.BranchID = int.Parse(rdrBranch["BranchID"].ToString());
                        else
                            Bran.BranchID = int.MinValue;

                        if (rdrBranch["BranchManagerAssignedDate"] != null && rdrBranch["BranchManagerAssignedDate"].ToString() != "")
                            Bran.BranchManagerAssignedDate = Convert.ToDateTime(rdrBranch["BranchManagerAssignedDate"].ToString());
                        else
                            Bran.BranchManagerAssignedDate = DateTime.MinValue;

                        if (rdrBranch["BranchManagerEditByID"] != null && rdrBranch["BranchManagerEditByID"].ToString() != "")
                            Bran.BranchManagerEditByID = int.Parse(rdrBranch["BranchManagerEditByID"].ToString());
                        else
                            Bran.BranchManagerEditByID = int.MinValue;

                        Bran.BranchManagerEditByName = rdrBranch["BranchManagerEditByName"].ToString();

                        if (rdrBranch["BranchManagerEditDate"] != null && rdrBranch["BranchManagerEditDate"].ToString() != "")
                            Bran.BranchManagerEditDate = Convert.ToDateTime(rdrBranch["BranchManagerEditDate"].ToString());
                        else
                            Bran.BranchManagerEditDate = DateTime.MinValue;

                        if (rdrBranch["BranchManagerID"] != null && rdrBranch["BranchManagerID"].ToString() != "")
                            Bran.BranchManagerID = int.Parse(rdrBranch["BranchManagerID"].ToString());
                        else
                            Bran.BranchManagerID = int.MinValue;

                        Bran.BranchManagerName = rdrBranch["BranchManagerName"].ToString();

                        Bran.BranchName = rdrBranch["BranchName"].ToString();

                        if (rdrBranch["BussinessSectorID"] != null && rdrBranch["BussinessSectorID"].ToString() != "")
                            Bran.BussinessSectorID = int.Parse(rdrBranch["BussinessSectorID"].ToString());
                        else
                            Bran.BussinessSectorID = int.MinValue;

                        Bran.BussinessSectorName = rdrBranch["BussinessSectorName"].ToString();

                        Bran.City = rdrBranch["City"].ToString();

                        Bran.ContactFullName = rdrBranch["ContactFullName"].ToString();

                        if (rdrBranch["ContactID"] != null && rdrBranch["ContactID"].ToString() != "")
                            Bran.ContactID = int.Parse(rdrBranch["ContactID"].ToString());
                        else
                            Bran.ContactID = int.MinValue;

                        if (rdrBranch["CountryID"] != null && rdrBranch["CountryID"].ToString() != "")
                            Bran.CountryID = int.Parse(rdrBranch["CountryID"].ToString());
                        else
                            Bran.CountryID = int.MinValue;

                        Bran.CountryName = rdrBranch["CountryName"].ToString();

                        if (rdrBranch["EditByID"] != null && rdrBranch["EditByID"].ToString() != "")
                            Bran.EditByID = int.Parse(rdrBranch["EditByID"].ToString());
                        else
                            Bran.EditByID = int.MinValue;

                        Bran.EditByName = rdrBranch["EditByName"].ToString();

                        if (rdrBranch["EditDate"] != null && rdrBranch["EditDate"].ToString() != "")
                            Bran.EditDate = Convert.ToDateTime(rdrBranch["EditDate"].ToString());
                        else
                            Bran.EditDate = DateTime.MinValue;

                        if (rdrBranch["EnterByID"] != null && rdrBranch["EnterByID"].ToString() != "")
                            Bran.EnterByID = int.Parse(rdrBranch["EnterByID"].ToString());
                        else
                            Bran.EnterByID = int.MinValue;

                        if (rdrBranch["EnterDate"] != null && rdrBranch["EnterDate"].ToString() != "")
                            Bran.EnterDate = Convert.ToDateTime(rdrBranch["EnterDate"].ToString());
                        else
                            Bran.EnterDate = DateTime.MinValue;

                        Bran.EnteredByName = rdrBranch["EnteredByName"].ToString();

                        Bran.Fax = rdrBranch["Fax"].ToString();

                        if (rdrBranch["IDStatus"] != null && rdrBranch["IDStatus"].ToString() != "")
                            Bran.IDStatus = int.Parse(rdrBranch["IDStatus"].ToString());
                        else
                            Bran.IDStatus = int.MinValue;

                        if (rdrBranch["MainOffice"] != null && rdrBranch["MainOffice"].ToString() != "")
                            Bran.MainOffice = Convert.ToBoolean(rdrBranch["MainOffice"]);
                        else
                            Bran.MainOffice = false;

                        Bran.Phone = rdrBranch["Phone"].ToString();
                        Bran.ReferedBy = rdrBranch["ReferedBy"].ToString();
                        //Bran.SCode = rdrBranch["SCode"].ToString();

                        //if (rdrBranch["SID"] != null && rdrBranch["SID"].ToString() != "")
                        //    Bran.SID = int.Parse(rdrBranch["SID"].ToString());
                        //else
                        //    Bran.SID = int.MinValue;

                        Bran.State = rdrBranch["State"].ToString();
                        Bran.StatusName = rdrBranch["StatusName"].ToString();
                        Bran.Street1 = rdrBranch["Street1"].ToString();
                        Bran.Street2 = rdrBranch["Street2"].ToString();

                        if (rdrBranch["TypeID"] != null && rdrBranch["TypeID"].ToString() != "")
                            Bran.TypeID = int.Parse(rdrBranch["TypeID"].ToString());
                        else
                            Bran.TypeID = int.MinValue;

                        Bran.TypeName = rdrBranch["TypeName"].ToString();
                        Bran.WebSite = rdrBranch["WebSite"].ToString();
                        Bran.ZipCode = rdrBranch["ZipCode"].ToString();
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
                conBranch.Close();
            }
            return Bran;
        }

        public List<Branches> GetBranchByAccID()
        {
            SqlConnection conBranch = new SqlConnection(StrCon);
            List<Branches> BranchList = new List<Branches>();

            try
            {
                SqlDataReader rdrBranch = SqlHelper.ExecuteReader(conBranch, "SP_Get_Account_Branch", this.AccountID);
                Branches Bran;

                while (rdrBranch.Read())
                {
                    try
                    {
                        Bran = new Branches();
                        Bran.BranchID = int.Parse(rdrBranch["BranchID"].ToString());

                        if (rdrBranch["AccountID"] != null && rdrBranch["AccountID"].ToString() != "")
                            Bran.AccountID = int.Parse(rdrBranch["AccountID"].ToString());
                        else
                            Bran.AccountID = int.MinValue;

                        Bran.AccountName = rdrBranch["AccountName"].ToString();

                        if (rdrBranch["BranchID"] != null && rdrBranch["BranchID"].ToString() != "")
                            Bran.BranchID = int.Parse(rdrBranch["BranchID"].ToString());
                        else
                            Bran.BranchID = int.MinValue;

                        if (rdrBranch["BranchManagerAssignedDate"] != null && rdrBranch["BranchManagerAssignedDate"].ToString() != "")
                            Bran.BranchManagerAssignedDate = Convert.ToDateTime(rdrBranch["BranchManagerAssignedDate"].ToString());
                        else
                            Bran.BranchManagerAssignedDate = DateTime.MinValue;

                        if (rdrBranch["BranchManagerEditByID"] != null && rdrBranch["BranchManagerEditByID"].ToString() != "")
                            Bran.BranchManagerEditByID = int.Parse(rdrBranch["BranchManagerEditByID"].ToString());
                        else
                            Bran.BranchManagerEditByID = int.MinValue;

                        Bran.BranchManagerEditByName = rdrBranch["BranchManagerEditByName"].ToString();

                        if (rdrBranch["BranchManagerEditDate"] != null && rdrBranch["BranchManagerEditDate"].ToString() != "")
                            Bran.BranchManagerEditDate = Convert.ToDateTime(rdrBranch["BranchManagerEditDate"].ToString());
                        else
                            Bran.BranchManagerEditDate = DateTime.MinValue;

                        if (rdrBranch["BranchManagerID"] != null && rdrBranch["BranchManagerID"].ToString() != "")
                            Bran.BranchManagerID = int.Parse(rdrBranch["BranchManagerID"].ToString());
                        else
                            Bran.BranchManagerID = int.MinValue;

                        Bran.BranchManagerName = rdrBranch["BranchManagerName"].ToString();

                        Bran.BranchName = rdrBranch["BranchName"].ToString();

                        if (rdrBranch["BussinessSectorID"] != null && rdrBranch["BussinessSectorID"].ToString() != "")
                            Bran.BussinessSectorID = int.Parse(rdrBranch["BussinessSectorID"].ToString());
                        else
                            Bran.BussinessSectorID = int.MinValue;

                        Bran.BussinessSectorName = rdrBranch["BussinessSectorName"].ToString();

                        Bran.City = rdrBranch["City"].ToString();

                        Bran.ContactFullName = rdrBranch["ContactFullName"].ToString();

                        if (rdrBranch["ContactID"] != null && rdrBranch["ContactID"].ToString() != "")
                            Bran.ContactID = int.Parse(rdrBranch["ContactID"].ToString());
                        else
                            Bran.ContactID = int.MinValue;

                        if (rdrBranch["CountryID"] != null && rdrBranch["CountryID"].ToString() != "")
                            Bran.CountryID = int.Parse(rdrBranch["CountryID"].ToString());
                        else
                            Bran.CountryID = int.MinValue;

                        Bran.CountryName = rdrBranch["CountryName"].ToString();

                        if (rdrBranch["EditByID"] != null && rdrBranch["EditByID"].ToString() != "")
                            Bran.EditByID = int.Parse(rdrBranch["EditByID"].ToString());
                        else
                            Bran.EditByID = int.MinValue;

                        Bran.EditByName = rdrBranch["EditByName"].ToString();

                        if (rdrBranch["EditDate"] != null && rdrBranch["EditDate"].ToString() != "")
                            Bran.EditDate = Convert.ToDateTime(rdrBranch["EditDate"].ToString());
                        else
                            Bran.EditDate = DateTime.MinValue;

                        if (rdrBranch["EnterByID"] != null && rdrBranch["EnterByID"].ToString() != "")
                            Bran.EnterByID = int.Parse(rdrBranch["EnterByID"].ToString());
                        else
                            Bran.EnterByID = int.MinValue;

                        if (rdrBranch["EnterDate"] != null && rdrBranch["EnterDate"].ToString() != "")
                            Bran.EnterDate = Convert.ToDateTime(rdrBranch["EnterDate"].ToString());
                        else
                            Bran.EnterDate = DateTime.MinValue;

                        Bran.EnteredByName = rdrBranch["EnteredByName"].ToString();

                        Bran.Fax = rdrBranch["Fax"].ToString();

                        if (rdrBranch["IDStatus"] != null && rdrBranch["IDStatus"].ToString() != "")
                            Bran.IDStatus = int.Parse(rdrBranch["IDStatus"].ToString());
                        else
                            Bran.IDStatus = int.MinValue;

                        if (rdrBranch["MainOffice"] != null && rdrBranch["MainOffice"].ToString() != "")
                            Bran.MainOffice = Convert.ToBoolean(rdrBranch["MainOffice"]);
                        else
                            Bran.MainOffice = false;

                        Bran.Phone = rdrBranch["Phone"].ToString();
                        Bran.ReferedBy = rdrBranch["ReferedBy"].ToString();
                        //Bran.SCode = rdrBranch["SCode"].ToString();

                        //if (rdrBranch["SID"] != null && rdrBranch["SID"].ToString() != "")
                        //    Bran.SID = int.Parse(rdrBranch["SID"].ToString());
                        //else
                        //    Bran.SID = int.MinValue;

                        Bran.State = rdrBranch["State"].ToString();
                        Bran.StatusName = rdrBranch["StatusName"].ToString();
                        Bran.Street1 = rdrBranch["Street1"].ToString();
                        Bran.Street2 = rdrBranch["Street2"].ToString();

                        if (rdrBranch["TypeID"] != null && rdrBranch["TypeID"].ToString() != "")
                            Bran.TypeID = int.Parse(rdrBranch["TypeID"].ToString());
                        else
                            Bran.TypeID = int.MinValue;

                        Bran.TypeName = rdrBranch["TypeName"].ToString();
                        Bran.WebSite = rdrBranch["WebSite"].ToString();
                        Bran.ZipCode = rdrBranch["ZipCode"].ToString();

                        BranchList.Add(Bran);
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
                conBranch.Close();
            }
            return BranchList;
        }

        /// <summary>
        /// Get All Branches Names For Incremental Search Purpose
        /// </summary>
        /// <returns>Array of strings contains all names</returns>
        public string[] GetAllBranchesNames(string Prefix, SearchBy SearchColumn, string Country, string State, string BusSect, string Notes, string Tag)
        {
            string[] BrNames = new string[0];
            try
            {
                DataSet dsNames = new DataSet();
                dsNames = SqlHelper.ExecuteDataset(StrCon, "SP_Get_All_Branches_Names", SearchColumn.ToString(), Prefix, Country, State, BusSect, Notes, Tag);
                BrNames = new string[dsNames.Tables[0].Rows.Count];
                for (int i = 0; i < dsNames.Tables[0].Rows.Count; i++)
                {
                    BrNames[i] = dsNames.Tables[0].Rows[i][SearchColumn.ToString()].ToString();
                }
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return BrNames;
        }

        /// <summary>
        /// Delete existing record in table Contact_Branches
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public string DeleteBranch()
        {
            object Affected = "-1";
            try
            {
                object[] Params = { _BranchID, 0 };
                Affected = BaseClass.ReturnValueCommand("SP_DELETE_Contact_Branches", Params);
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
        /// <returns>integer value to indicates number of this contact order</returns>
        public int GetBranchOrder()
        {
            int result = -1;

            try
            {
                string pref = "";
                switch (this._SortExpression)
                {
                    case SortBy.BranchID:
                        pref = "-1";
                        break;
                    case SortBy.BranchName:
                        pref = this._BranchName;
                        break;
                    case SortBy.BusinessSectorName:
                        pref = this._BussinessSectorName;
                        break;
                    case SortBy.City:
                        pref = this._City;
                        break;
                    case SortBy.State:
                        pref = this._State;
                        break;
                    case SortBy.IDStatus:
                        pref = this._IDStatus.Value.ToString();
                        break;
                    case SortBy.CountryName:
                        pref = this._CountryName;
                        break;
                    default:
                        break;
                }

                result = Convert.ToInt32(BaseClass.ReturnValueCommand("SP_Get_Branch_Order", this._BranchID.Value, this._FilterBranchNotes.Value.ToString(), this._SortExpression.ToString(), pref, 0));
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }

            return result;
        }


        #endregion

        #region -----------------Private Functions----------------

        private object[] BuildUpdateQueryParams()
        {
            object[] UpdateParameters = new object[25];
            UpdateParameters[0] = this.BranchID.ToString();

            if (this.BranchName == null)
                UpdateParameters[1] = "-1";
            else
                UpdateParameters[1] = this.BranchName;

            if (this.TypeID == null)
                UpdateParameters[2] = "-1";
            else
                UpdateParameters[2] = this.TypeID.ToString();

            if (this.BussinessSectorID == null)
                UpdateParameters[3] = "-1";
            else
                UpdateParameters[3] = this.BussinessSectorID.ToString();

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
                UpdateParameters[17] = this.Street1.ToString();

            if (this.BranchManagerID == null)
                UpdateParameters[18] = "-1";
            else
                UpdateParameters[18] = this.BranchManagerID.ToString();

            if (this.BranchManagerEditDate == null)
                UpdateParameters[19] = "-1";
            else
                UpdateParameters[19] = this.BranchManagerEditDate.ToString();

            if (this.BranchManagerEditByID == null)
                UpdateParameters[20] = "-1";
            else
                UpdateParameters[20] = this.BranchManagerEditByID.ToString();

            if (this.BranchManagerAssignedDate == null)
                UpdateParameters[21] = "-1";
            else
                UpdateParameters[21] = this.BranchManagerAssignedDate.ToString();

            if (this.State == null)
                UpdateParameters[22] = "-1";
            else
                UpdateParameters[22] = this.State.ToString();

            if (this.AccountID == null)
                UpdateParameters[23] = "-1";
            else
                UpdateParameters[23] = this.AccountID.Value.ToString();

            if (this.MainOffice == null)
                UpdateParameters[24] = "-1";
            else
            {
                if (this.MainOffice.Value == true)
                    UpdateParameters[24] = "1";
                else
                    UpdateParameters[24] = "0";
            }
            return UpdateParameters;
        }

        private void BuildFilter()
        {
            if (this.BranchID == null)
                this.BranchID = -1;

            if (this.BranchName == null || this.BranchName.Trim() == "")
                this.BranchName = "-1";

            if (this.City == null || this.City.Trim() == "")
                this.City = "-1";

            if (this.Phone == null || this.Phone.Trim() == "")
                this.Phone = "-1";

            if (this.CountryName == null || this.CountryName.Trim() == "")
                this.CountryName = "-1";

            if (this.State == null || this.State.Trim() == "")
                this.State = "-1";

            if (this.BussinessSectorName == null || this.BussinessSectorName.Trim() == "")
                this.BussinessSectorName = "-1";

            if (this.IDStatus == null)
                this.IDStatus = -1;
        }

        private string BuildSortCriteria()
        {
            string SortCriteria = "-1";

            if (this.SortExpression == SortBy.BranchID)
                SortCriteria = "Contact_Branches.BranchID";
            if (this.SortExpression == SortBy.City)
                SortCriteria = "Contact_Branches.City";
            if (this.SortExpression == SortBy.BusinessSectorName)
                SortCriteria = "BussinessSectorName";
            if (this.SortExpression == SortBy.BranchName)
                SortCriteria = "BranchName";
            if (this.SortExpression == SortBy.State)
                SortCriteria = "Contact_Branches.State";
            if (this.SortExpression == SortBy.IDStatus)
                SortCriteria = "Contact_Branches.IDStatus";
            if (this.SortExpression == SortBy.CountryName)
                SortCriteria = "CountryName";
            //
            if (this.SortExpression == SortBy.LastAccountNoteDate)
                SortCriteria = "LastBranchNoteDate";
            //
            if (this.SortDirect == SortDirection.Ascending)
                SortCriteria += " ASC";
            if (this.SortDirect == SortDirection.Descending)
                SortCriteria += " Desc";

            return SortCriteria;
        }
        #endregion
    }
}