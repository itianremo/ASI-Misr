using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Office.DAL.ApplicationBlocks;
using Office.DAL;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
/// <summary>
/// Summary description for History
/// </summary>
namespace Office.DAL
{
    [Serializable]
    public class History
    {
        public History()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        string StrCon = ConfigurationManager.ConnectionStrings["ASI-CRMConnectionString"].ToString();
        public DataSet GetHistoryByAccountID(int AccountID)
        {

            string[] paramters = new string[1];
            paramters[0] = AccountID.ToString();

            DataSet dsSoftwareSales = SqlHelper.ExecuteDataset(StrCon, "History_GetByAccountId", paramters);
            return dsSoftwareSales;

        }
        public DataSet GetHistoryByContactID(int ContactID)// need to update sp
        {

            string[] paramters = new string[1];
            paramters[0] = ContactID.ToString();

            DataSet dsSoftwareSales = SqlHelper.ExecuteDataset(StrCon, "History_GetByContactID", paramters);
            return dsSoftwareSales;

        }
        public DataSet GetHistoryByBranchID(int BranchID)// need to update sp
        {

            string[] paramters = new string[1];
            paramters[0] = BranchID.ToString();

            DataSet dsSoftwareSales = SqlHelper.ExecuteDataset(StrCon, "History_GetByBranchID", paramters);
            return dsSoftwareSales;

        }
    }
}