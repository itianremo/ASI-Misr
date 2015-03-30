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
    public class SecurityUserGroupRole
    {
        #region ------------------Constructors------------------

        public SecurityUserGroupRole()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region -------------------Properties--------------------

        public int? RoleID
        {
            get { return _RoleID; }
            set { _RoleID = value; }
        }

        public int? GroupID
        {
            get { return _GroupID; }
            set { _GroupID = value; }
        }

        public int? ReferenceID
        {
            get { return _ReferenceID; }
            set { _ReferenceID = value; }
        }

        public string ReferenceValue
        {
            get { return _ReferenceValue; }
            set { _ReferenceValue = value; }
        }

        #endregion

        #region -----------------Private Variables----------------

        private int? _RoleID;
        private int? _ReferenceID;
        private string _ReferenceValue;
        private int? _GroupID;

        #endregion

        #region ---------------General Functions-----------------
        /// <summary>
        /// Update existing record in table Sec_UserGroup_Role
        /// Fill in all properties of the Sec_UserGroup_Role Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int AddNewSecurityUserGroupRole()
        {
            int result = -1;
            try
            {
                BaseClass.InsertCommand("SP_INSERT_INTO_Sec_UserGroup_Role", this._RoleID, this._GroupID, this._ReferenceID, this._ReferenceValue);
                result = 1;
            }
            catch (Exception Ex)
            {
                string ErrMsg = Ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Update existing record in table Sec_UserGroup_Role
        /// Fill in all properties of the Sec_UserGroup_Role Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int UpdateSecurityUserGroupRole()
        {
            int result = -1;
            try
            {
                BaseClass.UpdateCommand("SP_UPDATE_Sec_UserGroup_Role", this._RoleID, this._GroupID, this._ReferenceID, this._ReferenceValue);
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