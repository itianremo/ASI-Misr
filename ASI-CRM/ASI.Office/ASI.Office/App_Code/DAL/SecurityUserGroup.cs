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
    public class SecurityUserGroup
    {
        #region ------------------Constructors------------------

        public SecurityUserGroup()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region -------------------Properties--------------------

        public int? GroupID
        {
            get { return _GroupID; }
            set { _GroupID = value; }
        }

        public string GroupName
        {
            get { return _GroupName; }
            set { _GroupName = value; }
        }

        #endregion

        #region -----------------Private Variables----------------

        private int? _GroupID;
        private string _GroupName;

        #endregion

        #region ---------------General Functions-----------------
        /// <summary>
        /// Insert new record into table Sec_UserGroup
        /// Fill in all properties of the Sec_UserGroup Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int AddNewSecurityUserGroup()
        {
            int result = -1;
            try
            {
                BaseClass.InsertCommand("SP_INSERT_INTO_Sec_UserGroup", this._GroupName);
                result = 1;
            }
            catch (Exception Ex)
            {
                string ErrMsg = Ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Update existing record in table Sec_UserGroup
        /// Fill in all properties of the Sec_UserGroup Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int UpdateSecurityUserGroup()
        {
            int result = -1;
            try
            {
                BaseClass.UpdateCommand("SP_UPDATE_Sec_UserGroup", this._GroupID, this._GroupName);
                result = 1;
            }
            catch (Exception Ex)
            {
                string ErrMsg = Ex.Message;
            }
            return result;
        }

        #endregion
    }
}