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
    public class ContactNotes
    {
        #region ------------------Constructors------------------

        public ContactNotes()
        {
            //
            // TODO : Implement Constructor Function
            //
        }

        #endregion

        #region -------------------Properties--------------------

        public enum SortBy
        {
            UserEnterDate
        }

        public int? NID
        {
            get { return _NID; }
            set { _NID = value; }
        }

        public DateTime? NoteDate
        {
            get { return _NoteDate; }
            set { _NoteDate = value; }
        }

        public DateTime? UserEnterDate
        {
            get { return _UserEnterDate; }
            set { _UserEnterDate = value; }
        }

        public string NoteDateStr
        {
            get { return _NoteDateStr; }
            set { _NoteDateStr = value; }
        }

        public string NoteTimeStr
        {
            get { return _NoteTimeStr; }
            set { _NoteTimeStr = value; }
        }

        public byte[] NoteTime
        {
            get { return _NoteTime; }
            set { _NoteTime = value; }
        }

        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }

        public int? EnteredByID
        {
            get { return _EnteredByID; }
            set { _EnteredByID = value; }
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

        public string EditDateStr
        {
            get { return _EditDateStr; }
            set { _EditDateStr = value; }
        }

        public string EditTimeStr
        {
            get { return _EditTimeStr; }
            set { _EditTimeStr = value; }
        }

        public int? ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; }
        }

        public int? BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }

        public int? AccountID
        {
            get { return _AccountID; }
            set { _AccountID = value; }
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
        
        public string AccountName
        {
            get { return _AccountName; }
            set { _AccountName = value; }
        }

        public string BranchName
        {
            get { return _BranchName; }
            set { _BranchName = value; }
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

        private int? _NID;
        private DateTime? _NoteDate;
        private DateTime? _UserEnterDate;
        private string _NoteDateStr;
        private string _NoteTimeStr;
        private byte[] _NoteTime;
        private string _Notes;
        private int? _EnteredByID;
        private int? _EditByID;
        private DateTime? _EditDate;
        private string _EditDateStr;
        private string _EditTimeStr;
        private int? _ContactID;
        private int? _AccountID;
        private int? _BranchID;
        private string _EnteredByName;
        private string _EditByName;
        private string _AccountName;
        private string _BranchName;
        private string _ContactFirstName;
        private string _ContactLastName;
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
        public int AddNewContactNotes()
        {
            int Affected = -1;
            try
            {
                _Notes = BaseClass.EncodeString(_Notes);
                BaseClass.InsertCommand("SP_INSERT_INTO_Contact_Notes", this._NoteDate, this._UserEnterDate, 
                    this._Notes, this._EnteredByID, this._EditByID, this._EditDate, this._ContactID, this._AccountID, this._BranchID);
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
        public int UpdateContactNotes()
        {
            int Affected = -1;
            try
            {
                object[] Params = BuildUpdateQueryParams();
                BaseClass.UpdateCommand("SP_UPDATE_Contact_Notes", Params);
                Affected = 1;
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return Affected;
        }

        public int UpdateAllContactNotes()
        {
            int Affected = -1;
            try
            {
                object[] Params = BuildUpdateAllContactNoteParams();
                BaseClass.UpdateCommand("SP_UPDATE_All_Contact_Notes", Params);
                Affected = 1;
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return Affected;
        }

        public int UpdateAllBranchNotes()
        {
            int Affected = -1;
            try
            {
                object[] Params = BuildUpdateAllBranchNoteParams();
                BaseClass.UpdateCommand("SP_UPDATE_All_Branch_Notes", Params);
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
        public string DeleteContactNotes()
        {
            object Affected = "-1";
            try
            {
                object[] Params = { _NID, 0 };
                Affected = BaseClass.ReturnValueCommand("SP_DELETE_Contact_Note", Params);  
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
        public List<ContactNotes> GetRelatedNotes()
        {
            List<ContactNotes> NotesList = new List<ContactNotes>();
            SqlConnection conNotes = new SqlConnection(StrCon);
            try
            {
                ContactNotes CNote;
                string Filter = BuildFilter(this);
                string SortCriteria = BuildSortCriteria();
                SqlDataReader rdrNotes = SqlHelper.ExecuteReader(conNotes, "SP_Get_Notes", Filter, SortCriteria);
                while (rdrNotes.Read())
                {
                    CNote = new ContactNotes();

                    CNote.NID = int.Parse(rdrNotes["NID"].ToString());
                    CNote.NoteDate = Convert.ToDateTime(rdrNotes["NoteDate"].ToString());
                    DateTime ResultDate;
                    if (rdrNotes["UserEnterDate"] == null || !DateTime.TryParse(rdrNotes["UserEnterDate"].ToString(), out ResultDate))
                    {
                        CNote.UserEnterDate = null;
                        CNote.NoteDateStr = "";
                        CNote.NoteTimeStr = "";

                    }
                    else
                    {
                        CNote.UserEnterDate = ResultDate;
                        CNote.NoteDateStr = ResultDate.ToShortDateString();
                        CNote.NoteTimeStr = ResultDate.ToShortTimeString();
                    }
                    CNote.NoteTime = (byte[])rdrNotes["NoteTime"];
                    CNote.Notes = BaseClass.DecodeString(rdrNotes["Notes"].ToString());
                    CNote.EnteredByID = int.Parse(rdrNotes["EnterdByID"].ToString());
                    CNote.EditByID = int.Parse(rdrNotes["EditByID"].ToString());
                    CNote.EditDate = Convert.ToDateTime(rdrNotes["EditDate"].ToString());
                    CNote.EditDateStr = Convert.ToDateTime(rdrNotes["EditDate"].ToString()).ToShortDateString();
                    CNote.EditTimeStr = Convert.ToDateTime(rdrNotes["EditDate"].ToString()).ToShortTimeString();
                    if (rdrNotes["ContactID"] != DBNull.Value)
                        CNote.ContactID = int.Parse(rdrNotes["ContactID"].ToString());
                    else
                        CNote.ContactID = null;
                    if (rdrNotes["AccountID"] != DBNull.Value)
                        CNote.AccountID = int.Parse(rdrNotes["AccountID"].ToString());
                    else
                        CNote.AccountID = null;
                    if (rdrNotes["BranchID"] != DBNull.Value)
                        CNote.BranchID = int.Parse(rdrNotes["BranchID"].ToString());
                    else
                        CNote.BranchID = null;
                    CNote.EnteredByName = rdrNotes["EnteredByName"].ToString();
                    CNote.EditByName = rdrNotes["EditByName"].ToString();
                    CNote.AccountName = rdrNotes["AccountName"].ToString();
                    CNote.BranchName = rdrNotes["BranchName"].ToString();
                    CNote.ContactFirstName = rdrNotes["ContactFirstName"].ToString();
                    CNote.ContactLastName = rdrNotes["ContactLastName"].ToString();

                    NotesList.Add(CNote);
                }
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                conNotes.Close();
            }
            return NotesList;
        }

        /// <summary>
        /// Get all notes that meets search crieteria that are supplied by object properties
        /// you can search by AccountID
        /// </summary>
        /// <returns>List of ContactNotes objects that meet the search criteria</returns>
        public List<ContactNotes> GetAccountRelatedNotes()
        {
            List<ContactNotes> NotesList = new List<ContactNotes>();
            SqlConnection conNotes = new SqlConnection(StrCon);
            try
            {
                ContactNotes CNote;
                string Filter = BuildAccountFilter(this);
                string SortCriteria = BuildSortCriteria();
                int AID = (AccountID != null) ? AccountID.Value : -1;
                SqlDataReader rdrNotes = SqlHelper.ExecuteReader(conNotes, "SP_Get_Account_Contacts_Notes", AccountID, Filter, SortCriteria);
                while (rdrNotes.Read())
                {
                    CNote = new ContactNotes();

                    CNote.NID = int.Parse(rdrNotes["NID"].ToString());
                    CNote.NoteDate = Convert.ToDateTime(rdrNotes["NoteDate"].ToString());
                    DateTime ResultDate;
                    if (rdrNotes["UserEnterDate"] == null || !DateTime.TryParse(rdrNotes["UserEnterDate"].ToString(), out ResultDate))
                    {
                        CNote.UserEnterDate = null;
                        CNote.NoteDateStr = "";
                        CNote.NoteTimeStr = "";

                    }
                    else
                    {
                        CNote.UserEnterDate = ResultDate;
                        CNote.NoteDateStr = ResultDate.ToShortDateString();
                        CNote.NoteTimeStr = ResultDate.ToShortTimeString();
                    }
                    CNote.NoteTime = (byte[])rdrNotes["NoteTime"];
                    CNote.Notes = BaseClass.DecodeString(rdrNotes["Notes"].ToString());
                    CNote.EnteredByID = int.Parse(rdrNotes["EnterdByID"].ToString());
                    CNote.EditByID = int.Parse(rdrNotes["EditByID"].ToString());
                    CNote.EditDate = Convert.ToDateTime(rdrNotes["EditDate"].ToString());
                    CNote.EditDateStr = Convert.ToDateTime(rdrNotes["EditDate"].ToString()).ToShortDateString();
                    CNote.EditTimeStr = Convert.ToDateTime(rdrNotes["EditDate"].ToString()).ToShortTimeString();
                    if (rdrNotes["ContactID"] != DBNull.Value)
                        CNote.ContactID = int.Parse(rdrNotes["ContactID"].ToString());
                    else
                        CNote.ContactID = null;
                    if (rdrNotes["AccountID"] != DBNull.Value)
                        CNote.AccountID = int.Parse(rdrNotes["AccountID"].ToString());
                    else
                        CNote.AccountID = null;
                    CNote.EnteredByName = rdrNotes["EnteredByName"].ToString();
                    CNote.EditByName = rdrNotes["EditByName"].ToString();
                    CNote.AccountName = rdrNotes["AccountName"].ToString();
                    CNote.ContactFirstName = rdrNotes["ContactFirstName"].ToString();
                    CNote.ContactLastName = rdrNotes["ContactLastName"].ToString();
                    if (rdrNotes["BranchID"] != DBNull.Value)
                        CNote.BranchID = int.Parse(rdrNotes["BranchID"].ToString());
                    else
                        CNote.BranchID = null;
                    CNote.BranchName = rdrNotes["BranchName"].ToString();

                    NotesList.Add(CNote);
                }
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                conNotes.Close();
            }
            return NotesList;
        }

        /// <summary>
        /// Get all account notes contacts first name that meets search crieteria that are supplied by object properties
        /// you can search by AccountID
        /// </summary>
        /// <returns>List of contacts first name that meet the search criteria</returns>
        public string[] GetAccountRelatedNotesContactsFirstName(string Prefix, int AccounID)
        {
            string[] CntNames = new string[0];
            try
            {
                DataSet dsNames = new DataSet();
                dsNames = SqlHelper.ExecuteDataset(StrCon, "SP_Get_All_Account_Notes_Contacts_Names", AccounID, Prefix);
                CntNames = new string[dsNames.Tables[0].Rows.Count];
                for (int i = 0; i < dsNames.Tables[0].Rows.Count; i++)
                {
                    CntNames[i] = dsNames.Tables[0].Rows[i][0].ToString();
                }
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return CntNames;
        }

        public ContactNotes GetNoteByID(int NoteID)
        {
            ContactNotes CNote = new ContactNotes();
            SqlConnection conNotes = new SqlConnection(StrCon);
            try
            {
                SqlDataReader rdrNotes = SqlHelper.ExecuteReader(conNotes, "SP_Get_Notes", " AND Contact_Notes.NID = " + NoteID, "-1");
                if (rdrNotes.Read())
                {
                    CNote.NID = int.Parse(rdrNotes["NID"].ToString());
                    CNote.NoteDate = Convert.ToDateTime(rdrNotes["NoteDate"].ToString());
                    DateTime ResultDate;
                    if (rdrNotes["UserEnterDate"] == null || !DateTime.TryParse(rdrNotes["UserEnterDate"].ToString(), out ResultDate))
                    {
                        CNote.UserEnterDate = null;
                        CNote.NoteDateStr = "";
                        CNote.NoteTimeStr = "";

                    }
                    else
                    {
                        CNote.UserEnterDate = ResultDate;
                        CNote.NoteDateStr = ResultDate.ToShortDateString();
                        CNote.NoteTimeStr = ResultDate.ToShortTimeString();
                    }
                    CNote.NoteTime = (byte[])rdrNotes["NoteTime"];
                    CNote.Notes = BaseClass.DecodeString(rdrNotes["Notes"].ToString());
                    CNote.EnteredByID = int.Parse(rdrNotes["EnterdByID"].ToString());
                    CNote.EditByID = int.Parse(rdrNotes["EditByID"].ToString());
                    CNote.EditDate = Convert.ToDateTime(rdrNotes["EditDate"].ToString());
                    CNote.EditDateStr = Convert.ToDateTime(rdrNotes["EditDate"].ToString()).ToShortDateString();
                    CNote.EditTimeStr = Convert.ToDateTime(rdrNotes["EditDate"].ToString()).ToShortTimeString();
                    if (rdrNotes["ContactID"] != DBNull.Value)
                        CNote.ContactID = int.Parse(rdrNotes["ContactID"].ToString());
                    else
                        CNote.ContactID = null;
                    if (rdrNotes["AccountID"] != DBNull.Value)
                        CNote.AccountID = int.Parse(rdrNotes["AccountID"].ToString());
                    else
                        CNote.AccountID = null;
                    CNote.EnteredByName = rdrNotes["EnteredByName"].ToString();
                    CNote.EditByName = rdrNotes["EditByName"].ToString();
                    CNote.AccountName = rdrNotes["AccountName"].ToString();
                    CNote.ContactFirstName = rdrNotes["ContactFirstName"].ToString();
                    CNote.ContactLastName = rdrNotes["ContactLastName"].ToString();
                }
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                conNotes.Close();
            }
            return CNote;
        }

        #endregion

        #region -----------------Private Functions---------------

        private string BuildFilter(ContactNotes CurrentNote)
        {
            string Filter = "";

            if (CurrentNote.AccountID != null)
                Filter += " AND Contact_Notes.AccountID = " + CurrentNote.AccountID.ToString();
            if (CurrentNote.BranchID != null)
                Filter += " AND Contact_Notes.BranchID = " + CurrentNote.BranchID.ToString();
            if (CurrentNote.ContactID != null)
                Filter += " AND Contact_Notes.ContactID = " + CurrentNote.ContactID.ToString();
            if (CurrentNote.EditDate != null)
                Filter += " AND DateDiff(day, Contact_Notes.EditDate, '" + CurrentNote.EditDate.Value.ToShortDateString() + "') = 0";
            if (CurrentNote.UserEnterDate != null)
                Filter += " AND DateDiff(day, Contact_Notes.UserEnterDate, '" + CurrentNote.UserEnterDate.Value.ToShortDateString() + "') = 0";
            if (CurrentNote.Notes != null)
                Filter += " AND Contact_Notes.Notes LIKE '%" + CurrentNote.Notes + "%'";

            return Filter;
        }

        private string BuildAccountFilter(ContactNotes CurrentNote)
        {
            string Filter = "";

            if (CurrentNote.ContactID != null)
                Filter += " AND Contact_Notes.ContactID = " + CurrentNote.ContactID.ToString();
            if (CurrentNote.ContactFirstName != null)
                Filter += " AND Contact_ContactsInfo.FirstName = '" + CurrentNote.ContactFirstName + "'";
            if (CurrentNote.EditDate != null)
                Filter += " AND DateDiff(day, Contact_Notes.EditDate, '" + CurrentNote.EditDate.Value.ToShortDateString() + "') = 0";
            if (CurrentNote.UserEnterDate != null)
                Filter += " AND DateDiff(day, Contact_Notes.UserEnterDate, '" + CurrentNote.UserEnterDate.Value.ToShortDateString() + "') = 0";
            if (CurrentNote.Notes != null)
                Filter += " AND Contact_Notes.Notes LIKE '%" + CurrentNote.Notes + "%'";

            return Filter;
        }

        private object[] BuildUpdateQueryParams()
        {
            _Notes = BaseClass.EncodeString(_Notes);

            object[] UpdateParameters = new object[9];
            UpdateParameters[0] = this.NID.ToString();
            
            if (this.NoteDate == null)
                UpdateParameters[1] = "-1";
            else
                UpdateParameters[1] = this.NoteDate.ToString();

            if (this.UserEnterDate == null)
                UpdateParameters[2] = "-1";
            else
                UpdateParameters[2] = this.UserEnterDate.ToString();

            if (this.Notes == null)
                UpdateParameters[3] = "-1";
            else
                UpdateParameters[3] = this.Notes.ToString();

            if (this.EnteredByID == null)
                UpdateParameters[4] = "-1";
            else
                UpdateParameters[4] = this.EnteredByID.ToString();

            if (this.EditByID== null)
                UpdateParameters[5] = "-1";
            else
                UpdateParameters[5] = this.EditByID.ToString();

            if (this.EditDate == null)
                UpdateParameters[6] = "-1";
            else
                UpdateParameters[6] = this.EditDate.ToString();

            if (this.ContactID == null)
                UpdateParameters[7] = "-1";
            else
                UpdateParameters[7] = this.ContactID.ToString();

            if (this.AccountID == null)
                UpdateParameters[8] = "-1";
            else
                UpdateParameters[8] = this.AccountID.ToString();

            return UpdateParameters;
        }

        private object[] BuildUpdateAllContactNoteParams()
        {
            object[] UpdateParameters = new object[3];
            UpdateParameters[0] = this.ContactID.ToString();

            if (this.BranchID == null)
                UpdateParameters[1] = "-1";
            else
                UpdateParameters[1] = this.BranchID.ToString();

            if (this.AccountID == null)
                UpdateParameters[2] = "-1";
            else
                UpdateParameters[2] = this.AccountID.ToString();

            return UpdateParameters;
        }

        private object[] BuildUpdateAllBranchNoteParams()
        {
            object[] UpdateParameters = new object[2];
            UpdateParameters[0] = this.BranchID.ToString();

            if (this.AccountID == null)
                UpdateParameters[1] = "-1";
            else
                UpdateParameters[1] = this.AccountID.ToString();

            return UpdateParameters;
        }

        private string BuildSortCriteria()
        {
            string SortCriteria = "-1";

            if (this.SortExpression == SortBy.UserEnterDate)
                SortCriteria = "UserEnterDate";

            if (this.SortDirect == SortDirection.Ascending)
                SortCriteria += " ASC";
            if (this.SortDirect == SortDirection.Descending)
                SortCriteria += " Desc";

            return SortCriteria;
        }

        #endregion
    }
}