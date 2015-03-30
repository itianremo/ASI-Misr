using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using Office.DAL;

/// <summary>
/// Summary description for ContactListsWS
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class ContactListsWS : BaseClassWS {

    private Office.BLL.ContactListsBLL CctLst;
    private Office.BLL.ContactsBLL Ccts;

    public ContactListsWS () {

        CctLst = new Office.BLL.ContactListsBLL();
        Ccts = new Office.BLL.ContactsBLL();
    }

    [WebMethod]
    public bool IsLogged()
    {
        return IsAuthenticated;
    }

    [WebMethod(EnableSession = true)]
    public string GetAllContacts(int PageSize, int PageNum)
    {
        if (IsAuthenticated == false)
        {
            throw new UnauthorizedAccessException("Invalid user name or password provided");
        }

        string Result = Serializer.Serialize(CctLst.SelectContactsDS(PageSize, PageNum));
        return Cryption.Encrypt(Result);
    }

    [WebMethod(EnableSession = true)]
    public string GetAccountsList()
    {
        if (IsAuthenticated == false)
        {
            throw new UnauthorizedAccessException("Invalid user name or password provided");
        }

        ContactAccount CA = new ContactAccount();
        string Result = Serializer.Serialize(CA.GetAccounList());
        return Cryption.Encrypt(Result);
    }

    [WebMethod(EnableSession = true)]
    public string GetTitlesList()
    {
        if (IsAuthenticated == false)
        {
            throw new UnauthorizedAccessException("Invalid user name or password provided");
        }

        string Result = Serializer.Serialize(CctLst.GetTitles());
        return Cryption.Encrypt(Result);
    }

    [WebMethod(EnableSession = true)]
    public string GetDepartmentsList()
    {
        if (IsAuthenticated == false)
        {
            throw new UnauthorizedAccessException("Invalid user name or password provided");
        }

        string Result = Serializer.Serialize(CctLst.GetDepartments());
        return Cryption.Encrypt(Result);
    }

    [WebMethod(EnableSession = true)]
    public string GetContactsPagesNumbers(int PageSize)
    {
        if (IsAuthenticated == false)
        {
            throw new UnauthorizedAccessException("Invalid user name or password provided");
        }

        string Result = Serializer.Serialize(Ccts.GetContactsPagesNums(PageSize));
        return Cryption.Encrypt(Result);
    }

    [WebMethod(EnableSession = true)]
    public bool UpdateContact(int ContactID, int? AccountID, string FirstName, string LastName, string Phone, int? TitleID, string Email, int? DepartmentID)
    {
        if (IsAuthenticated == false)
        {
            throw new UnauthorizedAccessException("Invalid user name or password provided");
        }

        ContactContactsInfo CCI = new ContactContactsInfo();
        CCI.ContactID = ContactID;
        CCI.AccountID = AccountID;
        CCI.FirstName = FirstName;
        CCI.LastName = LastName;
        CCI.Phone = Phone;
        CCI.TitleID = TitleID;
        CCI.Email = Email;
        CCI.DepartmentID = DepartmentID;
        return CCI.UpdateContactContactsInfo() > -1;
    }

    [WebMethod(EnableSession = true)]
    public bool AddContact(int? AccountID, string FirstName, string LastName, string Phone, int? TitleID, string Email, int? DepartmentID, int PageSize, out int PageNo, out int ContactID)
    {
        if (IsAuthenticated == false)
        {
            throw new UnauthorizedAccessException("Invalid user name or password provided");
        }

        bool Result = false;
        PageNo = 0;
        ContactID = -1;

        ContactContactsInfo CCI = new ContactContactsInfo();
        CCI.Intial = "";
        CCI.FirstName = FirstName;
        CCI.MiddleIntial = "";
        CCI.LastName = LastName;
        CCI.TitleID = TitleID;
        CCI.DepartmentID = DepartmentID;
        CCI.Phone = Phone;
        CCI.Ext = "";
        CCI.CellPhone = "";
        CCI.Fax = "";
        CCI.Email = Email;

        MainSubCode MSC = new MainSubCode();
        int CountryID = -1;
        string State = "";
        if (!MSC.GetDefaultCountryAndState(out CountryID, out State))
            return false;

        CCI.CountryID = CountryID;
        CCI.State = State;
        CCI.EnteredbyID = Convert.ToInt32(Session["UserID"]);
        CCI.EnterDate = DateTime.Now;
        CCI.EditByID = Convert.ToInt32(Session["UserID"]);
        CCI.EditDate = DateTime.Now;
        if (AccountID.HasValue)
        {
            CCI.AccountID = AccountID;
            CCI.MainContact = true;
        }

        ContactID = Convert.ToInt32(CCI.AddNewContactContactsInfo());
        Result = ContactID > -1;

        CCI.ContactID = ContactID;
        PageNo = CCI.GetContactPageNum(PageSize);
        PageNo = (PageNo == -1) ? 0 : PageNo;

        return Result;
    }

    [WebMethod(EnableSession = true)]
    public bool DeleteContact(int ContactID, out string ResultMsg)
    {
        if (IsAuthenticated == false)
        {
            throw new UnauthorizedAccessException("Invalid user name or password provided");
        }

        return CctLst.DeleteContactByID(ContactID, out ResultMsg);
    }
}
