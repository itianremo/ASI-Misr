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
/// Summary RelatedToContact for History
/// </summary>
namespace Office.DAL
{
    [Serializable]
    public class MyCustomerSupports
    {
        public MyCustomerSupports()
        {
           
        }

        string StrCon = ConfigurationManager.ConnectionStrings["ASI-CRMConnectionString"].ToString();
        #region -------------------- Properties -------------------

        public enum SortBy
        {
            FirstName,
            LastName,
            Account,
            Country
        }

        public enum SearchBy
        {
            RelatedToContact,
            Subject
        }

        public int? TechnicalSupportID
        {
            get { return _TechnicalSupportID; }
            set { _TechnicalSupportID = value; }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public string Account
        {
            get { return _Account; }
            set { _Account = value; }
        }

        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        public DateTime? TechnicalSupportDate
        {
            get { return _TechnicalSupportDate; }
            set { _TechnicalSupportDate = value; }
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

        #region -----------------Private Variables-----------------

        private int? _TechnicalSupportID;
        private string _FirstName;
        private string _LastName;
        private string _Account;
        private string _Country;
        private DateTime? _TechnicalSupportDate;
      
        private SortBy _SortExpression;
        private SortDirection _SortDirect;
       

        #endregion

        #region -----------------General Functions----------------
        #endregion

    }
}