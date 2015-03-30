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
    public class CallsControlBLL : System.Web.UI.UserControl
    {
        public CallsControlBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public List<Calls> GetCallsByAccountID(int AccountID)
        {
            Calls Call = new Calls();
            Call.AccountID = AccountID;
            return Call.GetRelatedCalls();
        }

        public List<Calls> GetCallsByContactID(int ContactID)
        {
            Calls Call = new Calls();
            Call.ContactID = ContactID;
            return Call.GetRelatedCalls();
        }
        public List<Calls> GetCallsByBranchID(int BranchID)
        {
            Calls Call = new Calls();
            return Call.GetRelatedCalls();
        }

        


              
    }
}
