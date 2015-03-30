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
using Office.DAL;
using Office.DAL.ApplicationBlocks;

namespace Office.DAL
{
    [Serializable]
    public class MainGeneralCode
    {
        #region ------------------Constructors------------------

        public MainGeneralCode()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        
        #endregion
        
        #region -------------------Properties--------------------

        public int? GeneralID
        {
            get { return _GeneralID; }
            set { _GeneralID = value; }
        }

        public string GeneralCode
        {
            get { return _GeneralCode; }
            set { _GeneralCode = value; }
        }

        #endregion
        
        #region -----------------Private Variables----------------

        private int? _GeneralID;
        private string _GeneralCode;
        string StrCon = ConfigurationManager.ConnectionStrings["ASI-CRMConnectionString"].ToString();
        
        #endregion
        
        #region ----------------General Functions-----------------
        /// <summary>
        /// Insert new record into table Main_GeneralCode
        /// Fill in all properties of the Main_GeneralCode Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int AddNewMainGeneralCode()
        {
            int result = -1;
            try
            {
                BaseClass.InsertCommand("SP_INSERT_INTO_Main_GeneralCode", this._GeneralCode);
                result = 1;
            }
            catch (Exception Ex)
            {
                string ErrMsg = Ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Update existing record in table Main_GeneralCode
        /// Fill in all properties of the Main_GeneralCode Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int UpdateMainGeneralCode()
        {
            int result = -1;
            try
            {
                BaseClass.UpdateCommand("SP_UPDATE_Main_GeneralCode", this._GeneralID, this._GeneralCode);
                result = 1;
            }
            catch (Exception Ex)
            {
                string ErrMsg = Ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Get the GeneralCodeID which is corresponding to the GeneralCode property.
        /// You must fill in the GeneralCode property first
        /// </summary>
        /// <returns>int GeneralCodeID</returns>
        public int GetGeneralCodeID()
        {
            int GID = -1;
            try
            {
                object GCodID = SqlHelper.ExecuteScalar(StrCon, "SP_Get_General_Code_ID", this._GeneralCode);
                if (GCodID != null)
                    GID = int.Parse(GCodID.ToString());
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return GID;
        }

        #endregion
        
    }
}