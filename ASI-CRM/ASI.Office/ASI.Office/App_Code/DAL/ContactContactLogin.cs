using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Office.DAL
{
    [Serializable]
    public class ContactContactLogin
    {
        #region ------------------Constructors------------------

        public ContactContactLogin()
        {
            //
            // TODO : Implement Constructor Function
            //
        }

        #endregion

        #region -------------------Properties--------------------

        public int? LID
        {
            get { return _LID; }
            set { _LID = value; }
        }

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public int? Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public int? Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        public int? ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; }
        }

        public string EnterBy
        {
            get { return _EnterBy; }
            set { _EnterBy = value; }
        }

        public DateTime? EnterDate
        {
            get { return _EnterDate; }
            set { _EnterDate = value; }
        }

        public string Editby
        {
            get { return _Editby; }
            set { _Editby = value; }
        }

        public DateTime? EditDate
        {
            get { return _EditDate; }
            set { _EditDate = value; }
        }

        #endregion

        #region -----------------Private Variables----------------

        private int? _LID;
        private string _UserName;
        private int? _Password;
        private int? _Active;
        private int? _ContactID;
        private string _EnterBy;
        private DateTime? _EnterDate;
        private string _Editby;
        private DateTime? _EditDate;

        #endregion

        #region -----------------General Functions---------------

        /// <summary>
        /// Insert new record into table ContactContactLogin
        /// Fill in all properties of the ContactContactLogin Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int AddNewContactContactLogin()
        {
            int Affected = -1;
            try
            {
                BaseClass.InsertCommand("SP_INSERT_INTO_Contact_ContactLogin", this._LID, this._UserName, this._Password, this._Active, this._EnterBy,
                                                    this._EnterDate, this._Editby, this._EditDate);
                Affected = 1;
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return Affected;
        }

        /// <summary>
        /// Update existing record in table ContactContactLogin
        /// Fill in all properties of the ContactContactLogin Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int UpdateContactContactLogin()
        {
            int Affected = -1;
            try
            {
                BaseClass.UpdateCommand("SP_UPDATE_Contact_ContactLogin", this._LID, this._UserName, this._Password, this._Active, this._EnterBy,
                                                    this._EnterDate, this._Editby, this._EditDate);
                Affected = 1;
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return Affected;
        }

        #endregion
    }
}