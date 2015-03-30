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
    public class HistoryBLL : System.Web.UI.UserControl
    {
        public HistoryBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet GetHistoryByAccountID(int AccountID)
        {
            History objHistory=new History();
            return objHistory.GetHistoryByAccountID(AccountID);
        }

        public DataSet GetHistoryByContactID(int ContactID)
        {
            History objHistory = new History();
            return objHistory.GetHistoryByContactID(ContactID);
        }
        public DataSet GetHistoryByBranchID(int BranchID)
        {
            History objHistory = new History();
            return objHistory.GetHistoryByBranchID(BranchID);
        }

        


              
    }
}
