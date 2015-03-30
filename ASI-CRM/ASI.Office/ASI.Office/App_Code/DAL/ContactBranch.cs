using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for ContactBranch
/// </summary>
namespace Office.DAL
{
    [Serializable]
    public class ContactBranch
    {
        #region ------------------Constructors------------------

        public ContactBranch()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion
        #region -----------------General Functions---------------
        public bool checkMainContact(int ContactID, int BranchID)
        {
            string Query = "SELECT  MainContact FROM  Contact_ContactsInfo where  ContactID="+ ContactID+" and BranchID="+BranchID;
            object  Result= Office.DAL.ApplicationBlocks.SqlHelper.ExecuteScalar(Office.DAL.BaseClass.strConnection, CommandType.Text, Query);
            bool boolResult = false;
            if (Result != null)
            {
                boolResult = (bool)Result;
            }
            return boolResult;
        }
        public bool SetMainContact(int ContactID, int BranchID,int Check)
        {
           
            string Query = " update Contact_ContactsInfo set MainContact=" + Check + "  where  ContactID=" + ContactID + " and BranchID=" + BranchID;
            object Result = Office.DAL.ApplicationBlocks.SqlHelper.ExecuteScalar(Office.DAL.BaseClass.strConnection, CommandType.Text, Query);
            bool boolResult = false;
            if (Result != null)
            {
                boolResult = (bool)Result;
            }
            return boolResult;
        }

        public string GetContactBranchID(string ContactID, string AccountID)
        {

            string Query = " select BranchID from   Contact_ContactsInfo where AccountID=" + AccountID + "  and  ContactID=" + ContactID ;
            object Result = Office.DAL.ApplicationBlocks.SqlHelper.ExecuteScalar(Office.DAL.BaseClass.strConnection, CommandType.Text, Query);
            string StrResult = "";
            if (Result != null)
            {
                StrResult = Result.ToString();
            }
            return StrResult;
        }

        #endregion
    }
}
