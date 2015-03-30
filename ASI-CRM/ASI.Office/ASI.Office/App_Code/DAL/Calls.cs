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
    public class Calls
    {
        #region ------------------Constructors------------------

        public Calls()
        {
            //
            // TODO : Implement Constructor Function
            //
        }

        #endregion

        #region -------------------Properties--------------------

        public enum SortBy
        {
            EnterDate,
            Subject,
            ContactFirstName,
            ContactLastName,
            StatusName,
            StartDate,
            Notes
        }

        public int CallID
        {
            get { return _CallID; }
            set { _CallID = value; }
        }

        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }

        public DateTime? StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }

        public int? Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public string StatusName
        {
            get { return _StatusName; }
            set { _StatusName = value; }
        }

        public int? ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; }
        }

        public string ContactFirstName
        {
            get { return _ContactFirstName; }
            set { _ContactFirstName = value; }
        }

        public string ContactLastName
        {
            get { return _ContactLastName; }
            set { _ContactLastName = value; }
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

        public int? EnterByID
        {
            get { return _EnterByID; }
            set { _EnterByID = value; }
        }

        public string EnterByName
        {
            get { return _EnterByName; }
            set { _EnterByName = value; }
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

        public string EditByName
        {
            get { return _EditByName; }
            set { _EditByName = value; }
        }

        public DateTime? EditDate
        {
            get { return _EditDate; }
            set { _EditDate = value; }
        }

        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
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

        #endregion

        #region -----------------Private Variables----------------

        private int _CallID;
        private string _Subject;
        private DateTime? _StartDate;
        private int? _Status;
        private string _StatusName;
        private int? _ContactID;
        private string _ContactFirstName;
        private string _ContactLastName;
        private int? _AccountID;
        private string _AccountName;
        private int? _EnterByID;
        private string _EnterByName;
        private DateTime? _EnterDate;
        private int? _EditByID;
        private string _EditByName;
        private DateTime? _EditDate;
        private string _Notes;
        private SortBy _SortExpression;
        private SortDirection _SortDirect;

        string StrCon = ConfigurationManager.ConnectionStrings["ASI-CRMConnectionString"].ToString();

        #endregion

        #region -----------------General Functions---------------

        /// <summary>
        /// Insert new record into table Contact_Notes
        /// Fill in all properties of the Contact_Notes Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int AddNewCall()
        {
            int Affected = -1;
            try
            {
                _Notes = BaseClass.EncodeString(_Notes);
                BaseClass.InsertCommand("Calls_Insert", this._Subject, this._StartDate,
                    this._Status, this._ContactID, this._AccountID, this._EnterByID, this._EnterDate, this._EditByID, this._EditDate, this._Notes);
                Affected = 1;
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return Affected;
        }

        /// <summary>
        /// Update existing record in table Contact_Notes
        /// Fill in all properties of the Contact_Notes Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int UpdateCall()
        {
            int Affected = -1;
            try
            {
                object[] Params = BuildUpdateQueryParams();
                BaseClass.UpdateCommand("Calls_Update", Params);
                Affected = 1;
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return Affected;
        }

        /// <summary>
        /// Delete existing record in table Contact_Notes
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public string DeleteCall()
        {
            object Affected = "-1";
            try
            {
                object[] Params = { _CallID, 0 };
                Affected = BaseClass.ReturnValueCommand("Calls_Delete", Params);  
            }
            catch (Exception Exp)
            {
                return Exp.Message;
            }
            return Affected.ToString();
        }

        /// <summary>
        /// Get all notes that meets search crieteria that are supplied by object properties
        /// you can search by AccountID or ContactID
        /// </summary>
        /// <returns>List of ContactNotes objects that meet the search criteria</returns>
        public List<Calls> GetRelatedCalls()
        {
            List<Calls> CallsList = new List<Calls>();
            SqlConnection conCalls = new SqlConnection(StrCon);
            try
            {
                Calls Call;
                string Filter = BuildFilter();
                string SortCriteria = BuildSortCriteria();
                SqlDataReader rdrNotes = SqlHelper.ExecuteReader(conCalls, "Calls_Get", Filter, SortCriteria);
                while (rdrNotes.Read())
                {
                    Call = new Calls();

                    Call.CallID = int.Parse(rdrNotes["CallID"].ToString());
                    Call.Subject = rdrNotes["Subject"].ToString();
                    Call.StartDate = Convert.ToDateTime(rdrNotes["StartDate"].ToString());
                    Call.Status = int.Parse(rdrNotes["Status"].ToString());
                    Call.StatusName = rdrNotes["StatusName"].ToString();
                    if (rdrNotes["ContactID"] != DBNull.Value)
                        Call.ContactID = int.Parse(rdrNotes["ContactID"].ToString());
                    else
                        Call.ContactID = null;
                    Call.ContactFirstName = rdrNotes["ContactFirstName"].ToString();
                    Call.ContactLastName = rdrNotes["ContactLastName"].ToString();
                    if (rdrNotes["AccountID"] != DBNull.Value)
                        Call.AccountID = int.Parse(rdrNotes["AccountID"].ToString());
                    else
                        Call.AccountID = null;
                    Call.AccountName = rdrNotes["AccountName"].ToString();
                    Call.EnterByID = int.Parse(rdrNotes["EnterByID"].ToString());
                    Call.EnterByName = rdrNotes["EnterByName"].ToString();
                    Call.EnterDate = Convert.ToDateTime(rdrNotes["EnterDate"].ToString());
                    Call.EditByID = int.Parse(rdrNotes["EditByID"].ToString());
                    Call.EditByName = rdrNotes["EditByName"].ToString();
                    Call.EditDate = Convert.ToDateTime(rdrNotes["EditDate"].ToString());
                    Call.Notes = BaseClass.DecodeString(rdrNotes["Notes"].ToString());

                    CallsList.Add(Call);
                }
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                conCalls.Close();
            }
            return CallsList;
        }

        public Calls GetCallByID(int CallID)
        {
            Calls Call = new Calls();
            SqlConnection conCalls = new SqlConnection(StrCon);
            try
            {
                SqlDataReader rdrNotes = SqlHelper.ExecuteReader(conCalls, "Calls_Get", " AND Calls.CallID = " + CallID, "-1");
                if (rdrNotes.Read())
                {
                    Call.CallID = int.Parse(rdrNotes["CallID"].ToString());
                    Call.Subject = rdrNotes["Subject"].ToString();
                    Call.StartDate = Convert.ToDateTime(rdrNotes["StartDate"].ToString());
                    Call.Status = int.Parse(rdrNotes["Status"].ToString());
                    Call.StatusName = rdrNotes["StatusName"].ToString();
                    if (rdrNotes["ContactID"] != DBNull.Value)
                        Call.ContactID = int.Parse(rdrNotes["ContactID"].ToString());
                    else
                        Call.ContactID = null;
                    Call.ContactFirstName = rdrNotes["ContactFirstName"].ToString();
                    Call.ContactLastName = rdrNotes["ContactLastName"].ToString();
                    if (rdrNotes["AccountID"] != DBNull.Value)
                        Call.AccountID = int.Parse(rdrNotes["AccountID"].ToString());
                    else
                        Call.AccountID = null;
                    Call.AccountName = rdrNotes["AccountName"].ToString();
                    Call.EnterByID = int.Parse(rdrNotes["EnterByID"].ToString());
                    Call.EnterByName = rdrNotes["EnterByName"].ToString();
                    Call.EnterDate = Convert.ToDateTime(rdrNotes["EnterDate"].ToString());
                    Call.EditByID = int.Parse(rdrNotes["EditByID"].ToString());
                    Call.EditByName = rdrNotes["EditByName"].ToString();
                    Call.EditDate = Convert.ToDateTime(rdrNotes["EditDate"].ToString());
                    Call.Notes = BaseClass.DecodeString(rdrNotes["Notes"].ToString());
                }
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                conCalls.Close();
            }
            return Call;
        }

        #endregion

        #region -----------------Private Functions---------------

        private string BuildFilter()
        {
            string Filter = "";

            if (this.ContactID != null)
                Filter += " AND Calls.ContactID = " + this.ContactID.ToString();
            if (this.AccountID != null)
                Filter += " AND Calls.AccountID = " + this.AccountID.ToString();
            if (this.ContactFirstName != null)
                Filter += " AND Contact_ContactsInfo.FirstName LIKE '%" + this.ContactFirstName + "%'";
            if (this.StartDate != null)
                Filter += " AND DateDiff(day, Calls.StartDate, '" + this.StartDate.Value.ToShortDateString() + "') = 0";
            if (this.Notes != null)
                Filter += " AND Calls.Notes LIKE '%" + this.Notes + "%'";

            return Filter;
        }

        private object[] BuildUpdateQueryParams()
        {
            _Notes = BaseClass.EncodeString(_Notes);

            object[] UpdateParameters = new object[11];
            UpdateParameters[0] = this.CallID.ToString();

            if (this.Subject == null)
                UpdateParameters[1] = "-1";
            else
                UpdateParameters[1] = this.Subject.ToString();

            if (this.StartDate == null)
                UpdateParameters[2] = "-1";
            else
                UpdateParameters[2] = this.StartDate.ToString();

            if (this.Status == null)
                UpdateParameters[3] = "-1";
            else
                UpdateParameters[3] = this.Status.ToString();

            if (this.ContactID == null)
                UpdateParameters[4] = "-1";
            else
                UpdateParameters[4] = this.ContactID.ToString();

            if (this.AccountID == null)
                UpdateParameters[5] = "-1";
            else
                UpdateParameters[5] = this.AccountID.ToString();

            if (this.EnterByID == null)
                UpdateParameters[6] = "-1";
            else
                UpdateParameters[6] = this.EnterByID.ToString();

            if (this.EnterDate == null)
                UpdateParameters[7] = "-1";
            else
                UpdateParameters[7] = this.EnterDate.ToString();

            if (this.EditByID == null)
                UpdateParameters[8] = "-1";
            else
                UpdateParameters[8] = this.EditByID.ToString();

            if (this.EditDate == null)
                UpdateParameters[9] = "-1";
            else
                UpdateParameters[9] = this.EditDate.ToString();

            if (this.Notes == null)
                UpdateParameters[10] = "-1";
            else
                UpdateParameters[10] = this.Notes.ToString();

            return UpdateParameters;
        }

        private string BuildSortCriteria()
        {
            string SortCriteria = "-1";

            switch (this.SortExpression)
            {
                case Calls.SortBy.Subject:
                    SortCriteria = "Calls.Subject";
                    break;
                case Calls.SortBy.ContactFirstName:
                    SortCriteria = "ContactFirstName";
                    break;
                case Calls.SortBy.ContactLastName:
                    SortCriteria = "ContactLastName";
                    break;
                case Calls.SortBy.StatusName:
                    SortCriteria = "StatusName";
                    break;
                case Calls.SortBy.StartDate:
                    SortCriteria = "StartDate";
                    break;
                case Calls.SortBy.Notes:
                    SortCriteria = "Notes";
                    break;
                default:
                    SortCriteria = "Calls.EnterDate";
                    break;
            }

            if (this.SortDirect == SortDirection.Ascending)
                SortCriteria += " ASC";
            if (this.SortDirect == SortDirection.Descending)
                SortCriteria += " Desc";

            return SortCriteria;
        }

        #endregion
    }
}