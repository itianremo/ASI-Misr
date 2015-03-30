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
    public class SecurityUserUserGroup
    {
        #region ------------------Constructors------------------

        public SecurityUserUserGroup()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region -------------------Properties--------------------

        public int? UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        public int? GroupID
        {
            get { return _GroupID; }
            set { _GroupID = value; }
        }

        #endregion

        #region -----------------Private Variables----------------

        private int? _UserID;
        private int? _GroupID;

        #endregion

        #region ---------------General Functions-----------------
        /// <summary>
        /// Update existing record in table Sec_User_UserGroup
        /// Fill in all properties of the Sec_User_UserGroup Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int AddNewSecurityUserUserGroup()
        {
            int result = -1;
            try
            {
                BaseClass.InsertCommand("SP_INSERT_INTO_Sec_User_UserGroup", this._UserID, this._GroupID);
                result = 1;
            }
            catch (Exception Ex)
            {
                string ErrMsg = Ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Update existing record in table Sec_User_UserGroup
        /// Fill in all properties of the Sec_User_UserGroup Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int UpdateSecurityUserUserGroup()
        {
            int result = -1;
            try
            {
                BaseClass.UpdateCommand("SP_UPDATE_Sec_User_UserGroup", this._UserID, this._GroupID);
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