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
    public class SecurityRoles
    {
        #region ------------------Constructors------------------

        public SecurityRoles()
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

        public string RoleName
        {
            get { return _RoleName; }
            set { _RoleName = value; }
        }

        public bool? GeneralRole
        {
            get { return _GeneralRole; }
            set { _GeneralRole = value; }
        }

        #endregion

        #region -----------------Private Variables----------------

        private int? _RoleID;
        private bool? _GeneralRole;
        private string _RoleName;

        #endregion

        #region ----------------General Functions-----------------
        /// <summary>
        /// Insert new record into table Sec_Roles
        /// Fill in all properties of the Sec_Roles Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int AddNewRole()
        {
            int result = -1;
            try
            {
                BaseClass.InsertCommand("SP_INSERT_INTO_Sec_Roles", this._RoleName, this._GeneralRole);
                result = 1;
            }
            catch (Exception Ex)
            {
                string ErrMsg = Ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Update existing record in table Sec_Roles
        /// Fill in all properties of the Sec_Roles Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int UpdateRole()
        {
            int result = -1;
            try
            {
                BaseClass.UpdateCommand("SP_UPDATE_Sec_Roles", this._RoleID, this._RoleName, this._GeneralRole);
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
