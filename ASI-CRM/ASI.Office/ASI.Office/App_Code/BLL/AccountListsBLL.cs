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
    public class AccountListsBLL : MasterClass
    {
        public AccountListsBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<ContactAccount> SelectAccounts(ContactAccount CurrentAccount)
        {
            ContactAccount CAcc = new ContactAccount();
            if (CurrentAccount != null)
                CAcc = CurrentAccount;
            return CAcc.GetAccounts();
        }

        public bool UpdateAllBranchNote(int BranchID, int? AID)
        {
            ContactNotes CNote = new ContactNotes();
            CNote.BranchID = BranchID;
            CNote.AccountID = AID;

            if (CNote.UpdateAllBranchNotes() != -1)
                return true;
            else
                return false;
        }

        public DataTable SelectAccountsDS(int PageSize, int PageNum)
        {
            ContactAccount CAcc = new ContactAccount();
            return CAcc.GetAccountsDS(PageSize, PageNum);
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<MainSubCode> GetSubCodeList(string CurrentGCode)
        {
            MainSubCode GetList = new MainSubCode();
            GetList.GCode = CurrentGCode;
            return GetList.GetSCodeList();
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<ContactAccountHierarchy> GetParentsList()
        {
            ContactAccountHierarchy Ah = new ContactAccountHierarchy();
            return Ah.GetAccountHierarchies();
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public ContactAccount GetSearchFilter(string Sortby, string sortDirection, string SpecificAccount, string AccountID, string CountryName)
        {
            ContactAccount CntAcc = new ContactAccount();
            switch (Sortby)
            {
                case "AccountName":
                    CntAcc.SortExpression = ContactAccount.SortBy.CompanyName;
                    break;

                case "AName":
                    CntAcc.SortExpression = ContactAccount.SortBy.CompanyName;
                    break;

                case "BusinessSectorName":
                    CntAcc.SortExpression = ContactAccount.SortBy.BusinessSectorName;
                    break;

                case "City":
                    CntAcc.SortExpression = ContactAccount.SortBy.City;
                    break;
                    
                case "State":
                    CntAcc.SortExpression = ContactAccount.SortBy.State;
                    break;
            }

            switch (sortDirection)
            {
                case "ASC":
                    CntAcc.SortDirect = SortDirection.Ascending;
                    break;

                case "Desc":
                    CntAcc.SortDirect = SortDirection.Descending;
                    break;
            }

            if (SpecificAccount != "")
            {
                CntAcc.AccountName = SpecificAccount;
            }

            if (AccountID != "")
            {
                CntAcc.AccountID = int.Parse(AccountID);

            }
            // Added by fawzi // 
            CntAcc.CountryName = CountryName;
            return CntAcc;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<SecurityUserLogin> GetAccountManagers()
        {
            SecurityUserLogin SecUser = new SecurityUserLogin();
            return SecUser.GetAccountManagerUsers();
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public bool CheckAccountManager(SecurityUserLogin ManagerUser)
        {
            return ManagerUser.IsAccountManagerUser();
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<ContactNotes> GetContactNotes(ContactNotes CurrentNote)
        {
            ContactNotes CNote = new ContactNotes();
            if (CurrentNote != null)
                CNote = CurrentNote;
            return CNote.GetAccountRelatedNotes();
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
            CNotes.SortExpression = ContactNotes.SortBy.UserEnterDate;

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

        public bool AddContactNote(string Note, int AccountID, DateTime? UserEnterDate)
        {
            ContactNotes CNote = new ContactNotes();
            CNote.NoteDate = DateTime.Now;
            CNote.Notes = Note;
            CNote.EnteredByID = ((ASIIdentity)User.Identity).UserID;
            CNote.EditByID = CNote.EnteredByID;
            CNote.EditDate = DateTime.Now;
            CNote.ContactID = null;
            CNote.AccountID = AccountID;
            CNote.BranchID = null;
            CNote.UserEnterDate = UserEnterDate;

            if (CNote.AddNewContactNotes() == 1)
                return true;
            else
                return false;
        }

        public bool AddBranchNote(string Note, int BranchID, int? AID, DateTime? UserEnterDate)
        {
            ContactNotes CNote = new ContactNotes();
            CNote.NoteDate = DateTime.Now;
            CNote.Notes = Note;
            CNote.EnteredByID = ((ASIIdentity)User.Identity).UserID;
            CNote.EditByID = CNote.EnteredByID;
            CNote.EditDate = DateTime.Now;
            CNote.ContactID = null;
            CNote.AccountID = AID;
            CNote.BranchID = BranchID;
            CNote.UserEnterDate = UserEnterDate;

            if (CNote.AddNewContactNotes() == 1)
                return true;
            else
                return false;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<ContactContactsInfo> GetAccountContacts(ContactContactsInfo CurrentContact)
        {
            ContactContactsInfo CCI = new ContactContactsInfo();
            if (CurrentContact != null)
                CCI = CurrentContact;
            return CCI.GetContacts();
        }

        public ContactContactsInfo GetContactSortFilter(string Sortby, string sortDirection)
        {
            ContactContactsInfo CCI = new ContactContactsInfo();
            switch (Sortby)
            {
                case "FirstName":
                    CCI.SortExpression = ContactContactsInfo.SortBy.FirstName;
                    break;

                case "Phone":
                    CCI.SortExpression = ContactContactsInfo.SortBy.Phone;
                    break;

                case "TitleName":
                    CCI.SortExpression = ContactContactsInfo.SortBy.TitleName;
                    break;
            }

            switch (sortDirection)
            {
                case "ASC":
                    CCI.SortDirect = SortDirection.Ascending;
                    break;

                case "Desc":
                    CCI.SortDirect = SortDirection.Descending;
                    break;
            }
            return CCI;
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
                if(ResultMsg.Equals("-1"))
                    ResultMsg = "Note not found.";
            }

            return ResultMsg;
        }

        public string DeleteAccountByID(int AccountID)
        {
            ContactAccount CAcc = new ContactAccount();
            CAcc.AccountID = AccountID;

            string ResultMsg = CAcc.DeleteAccount();

            if (ResultMsg.Equals("1"))
                ResultMsg = "Account deleted successfully!";
            else
            {
                if (ResultMsg.Equals("0"))
                    ResultMsg = "Account not found.";
                else if (ResultMsg.Equals("-1"))
                    ResultMsg = "You must delete all notes, contacts and sub companies belong to this account.";
            }

            return ResultMsg;
        }

        public bool DeleteAccountByID(int AccountID, out string ResultMsg)
        {
            bool Result = false;
            ContactAccount CAcc = new ContactAccount();
            CAcc.AccountID = AccountID;

            ResultMsg = CAcc.DeleteAccount();

            if (ResultMsg.Equals("1"))
            {
                ResultMsg = "Account deleted successfully!";
                Result = true;
            }
            else
            {
                if (ResultMsg.Equals("0"))
                    ResultMsg = "Account not found.";
                else if (ResultMsg.Equals("-1"))
                    ResultMsg = "You must delete all notes, contacts and sub companies belong to this account.";
            }

            return Result;
        }

        public int GetAccountOrderNo(int AccountID)
        {
            ContactAccount CA = new ContactAccount();
            CA.AccountID = AccountID;
            int OrderNo = CA.GetAccountOrder();

            return (OrderNo == -1) ? 0 : OrderNo;
        }

        public int GetAccountItemOrderNo(int AccountID)
        {
            ContactAccount CA = new ContactAccount();
            CA = (ContactAccount)Session["Account"];
            CA.AccountID = AccountID;
            CA.AccountName = "";
            Office.BLL.AccountsBLL.Filter fltr = (Office.BLL.AccountsBLL.Filter)Session["FilterField"];
            ContactAccount.SearchBy SB = fltr.IncrementalSearch == "Company" ? ContactAccount.SearchBy.AName : ContactAccount.SearchBy.BusinessSectorName;
            ViewState["orderbyField"] = SB.ToString();
            int OrderNo = CA.GetAccountItemOrder(SB, fltr.Notes, fltr.Tag, fltr.IncrementalSearchValue);

            return (OrderNo == -1) ? 0 : OrderNo;
        }

        public object GetAccountParent(int AccountID)
        {
            ContactAccountHierarchy CAH = new ContactAccountHierarchy();
            CAH.AID = AccountID;
            return CAH.GetAccountParent();
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<SubCompany> GetSubCompaniesByParentID(object ParentID)
        {
            SubCompany SC = new SubCompany();
            if (ParentID != null)
                SC.ParentID = Convert.ToInt32(ParentID);
            else
                SC.ParentID = -1;
            return SC.GetAccountHierarchies();
        }

        public static bool DeleteSubCompanyByID(int AccountID, out string ResultMsg)
        {
            bool Result = false;
            ContactAccountHierarchy CAH = new ContactAccountHierarchy();
            CAH.AID = AccountID;

            ResultMsg = CAH.DeleteAccountHierarchy();

            if (!ResultMsg.Equals("-1"))
            {
                ResultMsg = "Sub company deleted successfully!";
                Result = true;
            }
            else
            {
                ResultMsg = "Error deleting sub company.";
            }

            return Result;
        }

        public bool AddAccountHierarchy(int AccountID, int ParentID, int TypeID)
        {
            ContactAccountHierarchy CAH = new ContactAccountHierarchy();
            CAH.AID = AccountID;
            CAH.ParentID = ParentID;
            CAH.Type = TypeID;

            if (CAH.AddNewAccountHierarchy() == 1)
                return true;
            else
                return false;
        }

        public bool UpdateAccountHierarchy(int AccountID, int ParentID, int TypeID)
        {
            ContactAccountHierarchy CAH = new ContactAccountHierarchy();
            CAH.AID = AccountID;
            CAH.ParentID = ParentID;
            CAH.Type = TypeID;

            if (CAH.UpdateAccountHierarchy() == 1)
                return true;
            else
                return false;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<SubCompany> GetSubAccountsNamesList(bool All)
        {
            return SubCompany.GetSubAccountsNames(All);
        }
    }
}
