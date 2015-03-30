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
using System.Collections.Generic;

namespace Office.BLL
{
    [System.ComponentModel.DataObject]
    public class ContactListsBLL : MasterClass
    {
        public ContactListsBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<ContactNotes> GetContactNotes(ContactNotes CurrentNote)
        {
            ContactNotes CNote = new ContactNotes();
            if (CurrentNote != null)
                CNote = CurrentNote;
            return CNote.GetRelatedNotes();
        }

        public DataTable SelectContactsDS(int PageSize, int PageNum)
        {
            ContactContactsInfo CCI = new ContactContactsInfo();
            return CCI.GetContactsDS(PageSize, PageNum);
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]

        public ContactContactsInfo GetSearchFilter(string SpecificFilter, string FilterField, string ContactID, int FilterContactsNotes, string Sort, string Direction)
        {
            ContactContactsInfo CCI = new ContactContactsInfo();
            if (SpecificFilter != "")
            {
                switch (FilterField)
                {
                    case "Company":
                        CCI.AccountName = SpecificFilter;
                        CCI.SearchList = ContactContactsInfo.SearchBy.AName;
                        break;

                    case "Email":
                        CCI.Email = SpecificFilter;
                        CCI.SearchList = ContactContactsInfo.SearchBy.Email;
                        break;

                    case "Fax":
                        CCI.Fax = SpecificFilter;
                        CCI.SearchList = ContactContactsInfo.SearchBy.Fax;
                        break;

                    case "Contact First Name":
                        CCI.FirstName = SpecificFilter;
                        CCI.SearchList = ContactContactsInfo.SearchBy.FirstName;
                        break;

                    case "Contact Last Name":
                        CCI.LastName = SpecificFilter;
                        CCI.SearchList = ContactContactsInfo.SearchBy.LastName;
                        break;

                    case "Telephone":
                        CCI.Phone = SpecificFilter;
                        CCI.SearchList = ContactContactsInfo.SearchBy.Phone;
                        break;
                }
            }
            if (ContactID != "")
            {
                CCI.ContactID = int.Parse(ContactID);
            }
            CCI.FilterContactsNotes = FilterContactsNotes;

            if (Sort == "Company")
                CCI.SortExpression = ContactContactsInfo.SortBy.Company;
            if (Sort == "LastName")
                CCI.SortExpression = ContactContactsInfo.SortBy.LastName;
            if (Sort == "Phone")
                CCI.SortExpression = ContactContactsInfo.SortBy.Phone;
            if (Sort == "FirstName")
                CCI.SortExpression = ContactContactsInfo.SortBy.FirstName;
            if (Sort == "Fax")
                CCI.SortExpression = ContactContactsInfo.SortBy.Fax;
            if (Sort == "Email")
                CCI.SortExpression = ContactContactsInfo.SortBy.Email;
            if (Sort == "TitleName")
                CCI.SortExpression = ContactContactsInfo.SortBy.TitleName;
            if (Sort == "Tag")
                CCI.SortExpression = ContactContactsInfo.SortBy.Tag;
            if (Sort == "LastContactNoteDate")
                CCI.SortExpression = ContactContactsInfo.SortBy.LastContactNoteDate;

            if (Direction == "DESC")
                CCI.SortDirect = SortDirection.Descending;
            else
                CCI.SortDirect = SortDirection.Ascending;

            return CCI;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public ContactAccount SelectAccount(ContactAccount CurrentAccount)
        {
            if (CurrentAccount != null)
                return CurrentAccount.GetSingleContact();
            else
                return new ContactAccount();
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<ContactAccount> GetAccountList(string BusSector)
        {
            return new ContactAccount().GetAccounList((string.IsNullOrEmpty(BusSector) || (BusSector == "All")) ? "-1" : BusSector);
        }

        public string[] GetAllBusSectorList()
        {
            //return new ContactAccount().GetAccounList();
            return new ContactAccount().GetAllAccountsNames("", ContactAccount.SearchBy.BusinessSectorName, "-1", "-1", "-1", "-1", "-1");
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<ContactContactsInfo> GetAllContacts(ContactContactsInfo CurrentContact)
        {
            ContactContactsInfo CCI = new ContactContactsInfo();
            if (CurrentContact != null)
                CCI = CurrentContact;
            return CCI.GetContacts();
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<MainSubCode> GetSubCodeList(string CurrentGCode)
        {
            MainSubCode GetList = new MainSubCode();
            GetList.GCode = CurrentGCode;
            return GetList.GetSCodeList();
        }

        public DataTable GetTitles()
        {
            MainSubCode GetList = new MainSubCode();
            GetList.GCode = "Title";
            List<MainSubCode> MSCodeLst = GetList.GetSCodeList();
            DataTable dt = new DataTable();
            dt.Columns.Add("TitleID", typeof(int));
            dt.Columns.Add("Title", typeof(string));
            foreach (MainSubCode MSCode in MSCodeLst)
            {
                dt.Rows.Add(MSCode.SubID, MSCode.SubCode);
            }
            dt.Rows.Add(null, "");

            return dt;
        }

        public DataTable GetDepartments()
        {
            MainSubCode GetList = new MainSubCode();
            GetList.GCode = "Department";
            List<MainSubCode> MSCodeLst = GetList.GetSCodeList();
            DataTable dt = new DataTable();
            dt.Columns.Add("DepartmentID", typeof(int));
            dt.Columns.Add("Department", typeof(string));
            foreach (MainSubCode MSCode in MSCodeLst)
            {
                dt.Rows.Add(MSCode.SubID, MSCode.SubCode);
            }
            dt.Rows.Add(null, "");

            return dt;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public ContactContactMiscellaneous GetContactMiscellaneous(ContactContactMiscellaneous CurrentContactMiscellaneous)
        {
            return CurrentContactMiscellaneous.GetContactMiscellanousData();
        }

        public ContactNotes GetContactNote(int NoteID)
        {
            ContactNotes CNote = new ContactNotes();
            return CNote.GetNoteByID(NoteID);
        }

        public ContactNotes GetNotesSortFilter(string Sortby, string sortDirection)
        {
            ContactNotes CNotes = new ContactNotes();
            switch (Sortby)
            {
                case "UserEnterDate":
                    CNotes.SortExpression = ContactNotes.SortBy.UserEnterDate;
                    break;
            }

            switch (sortDirection)
            {
                case "ASC":
                    CNotes.SortDirect = SortDirection.Ascending;
                    break;

                case "Desc":
                    CNotes.SortDirect = SortDirection.Descending;
                    break;
            }
            return CNotes;

        }

        public bool UpdateContactNote(int NID, string Note, DateTime? UserEnterDate)
        {
            ContactNotes CNote = new ContactNotes();
            CNote.NID = NID;
            CNote.Notes = Note;
            CNote.EditByID = ((ASIIdentity)User.Identity).UserID;
            CNote.EditDate = DateTime.Now;
            CNote.UserEnterDate = UserEnterDate;

            if (CNote.UpdateContactNotes() != -1)
                return true;
            else
                return false;
        }

        public bool UpdateAllContactNote(int ContactID, int? AID, int? BID)
        {
            ContactNotes CNote = new ContactNotes();
            CNote.ContactID = ContactID;
            CNote.AccountID = AID;
            CNote.BranchID = BID;

            if (CNote.UpdateAllContactNotes() != -1)
                return true;
            else
                return false;
        }

        public bool AddContactNote(string Note, int ContactID, int? AID, int? BID, DateTime? UserEnterDate)
        {
            ContactNotes CNote = new ContactNotes();
            CNote.NoteDate = DateTime.Now;
            CNote.Notes = Note;
            CNote.EnteredByID = ((ASIIdentity)User.Identity).UserID;
            CNote.EditByID = CNote.EnteredByID;
            CNote.EditDate = DateTime.Now;
            CNote.ContactID = ContactID;
            CNote.AccountID = AID;
            CNote.BranchID = BID;
            CNote.UserEnterDate = UserEnterDate;

            if (CNote.AddNewContactNotes() == 1)
                return true;
            else
                return false;
        }

        public ContactConnection GetContactConnectionData(int CurrentContactID)
        {
            ContactConnection CurrentConnection = new ContactConnection();
            CurrentConnection.ContactID = CurrentContactID;
            return CurrentConnection.GetContactConnection();
        }

        public string DeleteNoteByID(int NoteID)
        {
            ContactNotes CNote = new ContactNotes();
            CNote.NID = NoteID;

            string ResultMsg = CNote.DeleteContactNotes();

            if (ResultMsg.Equals("1"))
                ResultMsg = "Note deleted successfully!";
            else
            {
                if (ResultMsg.Equals("-1"))
                    ResultMsg = "Note not found.";
            }

            return ResultMsg;
        }

        public string DeleteContactByID(int ContactID)
        {
            ContactContactsInfo CCI = new ContactContactsInfo();
            CCI.ContactID = ContactID;

            string ResultMsg = CCI.DeleteContact();

            if (ResultMsg.Equals("1"))
                ResultMsg = "Contact deleted successfully!";
            else
            {
                if (ResultMsg.Equals("0"))
                    ResultMsg = "Contact not found.";
                else if(ResultMsg.Equals("-1"))
                    ResultMsg = "You must delete all notes belong to this contact.";
            }

            return ResultMsg;
        }

        public bool DeleteContactByID(int ContactID, out string ResultMsg)
        {
            bool Result = false;
            ContactContactsInfo CCI = new ContactContactsInfo();
            CCI.ContactID = ContactID;

            ResultMsg = CCI.DeleteContact();

            if (ResultMsg.Equals("1"))
            {
                ResultMsg = "Contact deleted successfully!";
                Result = true;
            }
            else
            {
                if (ResultMsg.Equals("0"))
                    ResultMsg = "Contact not found.";
                else if (ResultMsg.Equals("-1"))
                    ResultMsg = "You must delete all notes belong to this contact.";
            }

            return Result;
        }

        public int GetContactOrderNo(ContactContactsInfo CCI)
        {
            int OrderNo = CCI.GetContactOrder();
            
            return (OrderNo == -1) ? 0 : OrderNo;// +1;
        }

        public int GetAccountIDByBranchID(int BranchID)
        {
            return ContactAccount.GetAccountByBranch(BranchID);
        }
    }
}