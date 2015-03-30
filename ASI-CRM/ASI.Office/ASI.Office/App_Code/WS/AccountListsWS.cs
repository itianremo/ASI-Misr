using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using Office.DAL;
using System.Data;

/// <summary>
/// Summary description for AccountListsWS
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class AccountListsWS : BaseClassWS {

    private Office.BLL.AccountListsBLL AccLst;
    private Office.BLL.AccountsBLL Accs;

    public AccountListsWS () {

        AccLst = new Office.BLL.AccountListsBLL();
        Accs = new Office.BLL.AccountsBLL();
    }

    [WebMethod]
    public string Test(string s)
    {
        return Cryption.Decrypt(Cryption.Encrypt(s));
    }

    [WebMethod]
    public bool IsLogged()
    {
        return IsAuthenticated;
    }

    [WebMethod(EnableSession = true)]
    public string GetAllAccounts(int PageSize, int PageNum)
    {
        if (IsAuthenticated == false)
        {
            throw new UnauthorizedAccessException("Invalid user name or password provided");
        }

        string Result = Serializer.Serialize(AccLst.SelectAccountsDS(PageSize, PageNum));
        return Cryption.Encrypt(Result);
    }

    [WebMethod(EnableSession = true)]
    public string GetBusSectorList()
    {
        if (IsAuthenticated == false)
        {
            throw new UnauthorizedAccessException("Invalid user name or password provided");
        }

        string Result = Serializer.Serialize(Accs.GetBusSectors());
        return Cryption.Encrypt(Result);
    }

    [WebMethod(EnableSession = true)]
    public string GetStatusList()
    {
        if (IsAuthenticated == false)
        {
            throw new UnauthorizedAccessException("Invalid user name or password provided");
        }

        string Result = Serializer.Serialize(Accs.GetStatus());
        return Cryption.Encrypt(Result);
    }

    [WebMethod(EnableSession = true)]
    public string GetCountriesList()
    {
        if (IsAuthenticated == false)
        {
            throw new UnauthorizedAccessException("Invalid user name or password provided");
        }

        string Result = Serializer.Serialize(Accs.GetCountries());
        return Cryption.Encrypt(Result);
    }

    [WebMethod(EnableSession = true)]
    public string GetStatesList()
    {
        if (IsAuthenticated == false)
        {
            throw new UnauthorizedAccessException("Invalid user name or password provided");
        }

        string Result = Serializer.Serialize(Accs.GetStates());
        return Cryption.Encrypt(Result);
    }

    [WebMethod(EnableSession = true)]
    public string GetAccountsPagesNumbers(int PageSize)
    {
        if (IsAuthenticated == false)
        {
            throw new UnauthorizedAccessException("Invalid user name or password provided");
        }

        string Result = Serializer.Serialize(Accs.GetAccountsPagesNums(PageSize));
        return Cryption.Encrypt(Result);
    }

    [WebMethod(EnableSession = true)]
    public bool UpdateAccount(int AccountID, string AccountName, int? Status, int? BusSector, string City, string Phone, string ZipCode)
    {
        if (IsAuthenticated == false)
        {
            throw new UnauthorizedAccessException("Invalid user name or password provided");
        }

        ContactAccount CA = new ContactAccount();
        CA.AccountID = AccountID;
        CA.AccountName = AccountName;
        CA.IDStatus = Status;
        CA.BusSector = BusSector;
        CA.City = City;
        CA.Phone = Phone;
        CA.ZipCode = ZipCode;
        return CA.UpdateContactAccount() > -1;
    }

    [WebMethod(EnableSession = true)]
    public bool AddAccount(string AccountName, int? Status, int? BusSector, string City, string Phone, string ZipCode, int CountryID, string StateName, int PageSize, out int PageNo, out int AccountID)
    {
        if (IsAuthenticated == false)
        {
            throw new UnauthorizedAccessException("Invalid user name or password provided");
        }

        bool Result = false;
        PageNo = 0;
        AccountID = -1;

        ContactAccount CA = new ContactAccount();
        CA.AccountName = AccountName;
        CA.BusSector = BusSector;
        CA.City = City;
        CA.Profile = "";

        //MainSubCode MSC = new MainSubCode();
        //int CountryID = -1;
        //string State = "";
        //if (!MSC.GetDefaultCountryAndState(out CountryID, out State))
        //    return false;

        CA.CountryID = CountryID;
        CA.State = StateName;
        CA.Fax = "";
        CA.Phone = Phone;
        CA.ReferedBy = "";
        CA.IDStatus = Status;
        CA.Street1 = "";
        CA.Street2 = "";
        CA.WebSite = "";
        CA.ZipCode = ZipCode;
        CA.EnterByID = Convert.ToInt32(Session["UserID"]);
        CA.EnterDate = DateTime.Now;
        CA.EditByID = Convert.ToInt32(Session["UserID"]);
        CA.EditDate = DateTime.Now;

        AccountID = CA.AddNewContactAccount();
        Result = AccountID > -1;

        CA.AccountID = AccountID;
        PageNo = CA.GetAccountPage(PageSize);
        PageNo = (PageNo == -1) ? 0 : PageNo;

        return Result;
    }

    [WebMethod(EnableSession = true)]
    public bool DeleteAccount(int AccountID, out string ResultMsg)
    {
        if (IsAuthenticated == false)
        {
            throw new UnauthorizedAccessException("Invalid user name or password provided");
        }

        return AccLst.DeleteAccountByID(AccountID, out ResultMsg);
    }
}
