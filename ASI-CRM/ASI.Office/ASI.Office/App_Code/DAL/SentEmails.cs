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
    public class SentEmails
    {
        #region ------------------Constructors------------------

        public SentEmails()
        {
            //
            // TODO : Implement Constructor Function
            //
        }

        #endregion

        #region -------------------Properties--------------------

        public enum SortBy
        {
            SentDate
        }

        public int SentEmailID
        {
            get { return _SentEmailID; }
            set { _SentEmailID = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public DateTime? SentDate
        {
            get { return _SentDate; }
            set { _SentDate = value; }
        }

        public int? SentBy
        {
            get { return _SentBy; }
            set { _SentBy = value; }
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

        private int _SentEmailID;
        private string _Email;
        private DateTime? _SentDate;
        private int? _SentBy;
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
        public int AddNewSentEmail()
        {
            int Affected = -1;
            try
            {
                BaseClass.InsertCommand("SentEmails_Insert", this._Email, this._SentDate, this._SentBy);
                Affected = 1;
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return Affected;
        }

        #endregion

        #region -----------------Private Functions---------------

        #endregion
    }
}