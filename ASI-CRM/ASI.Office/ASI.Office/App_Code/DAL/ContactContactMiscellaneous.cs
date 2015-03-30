using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using Office.DAL.ApplicationBlocks;

namespace Office.DAL
{
    [Serializable]
    public class ContactContactMiscellaneous
    {
        #region ------------------Constructors------------------

        public ContactContactMiscellaneous()
        {
            //
            // TODO : Implement Constructor Function
            //
        }

        #endregion

        #region -------------------Properties--------------------

        public int? MID
        {
            get { return _MID; }
            set { _MID = value; }
        }

        public int? IDStatus
        {
            get { return _IDStatus; }
            set { _IDStatus = value; }
        }

        public DateTime? Birthday
        {
            get { return _Birthday; }
            set { _Birthday = value; }
        }

        public string Spouse
        {
            get { return _Spouse; }
            set { _Spouse = value; }
        }

        public string ReferredBy
        {
            get { return _ReferredBy; }
            set { _ReferredBy = value; }
        }

        public int? ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; }
        }

        public int? EnterByID
        {
            get { return _EnterByID; }
            set { _EnterByID = value; }
        }

        public DateTime? EnterDate
        {
            get { return _EnterDate; }
            set { _EnterDate = value; }
        }

        public int? EditByID
        {
            get { return _EditByID; }
            set { _EditByID = value; }
        }

        public DateTime? EditDate
        {
            get { return _EditDate; }
            set { _EditDate = value; }
        }

        public string ContactFirstName
        {
            get { return _ContactFirstName; }
            set { _ContactFirstName = value; }
        }

        public string ContactLastName
        {
            get { return _ContactLastName; }
            set { _ContactLastName = value; }
        }

        public string EnterByName
        {
            get { return _EnterByName; }
            set { _EnterByName = value; }
        }

        public string EditrByName
        {
            get { return _EditrByName; }
            set { _EditrByName = value; }
        }

        public string StatusName
        {
            get { return _StatusName; }
            set { _StatusName = value; }
        }

        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }

        #endregion

        #region -----------------Private Variables----------------

        private int? _IDStatus;
        private DateTime? _Birthday;
        private string _Spouse;
        private string _ReferredBy;
        private int? _ContactID;
        private int? _EnterByID;
        private DateTime? _EnterDate;
        private int? _EditByID;
        private DateTime? _EditDate;
        private int? _MID;
        private string _ContactFirstName;
        private string _ContactLastName;
        private string _EnterByName;
        private string _EditrByName;
        private string _StatusName;
        private string _Note;

        string StrCon = ConfigurationManager.ConnectionStrings["ASI-CRMConnectionString"].ToString();

        #endregion

        #region -----------------General Functions---------------

        /// <summary>
        /// Insert new record into table ContactContactMiscellaneous
        /// Fill in all properties of the ContactContactMiscellaneous Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int AddNewContactContactMiscellaneous()
        {
            int Affected = -1;
            try
            {
                BaseClass.InsertCommand("SP_INSERT_INTO_Contact_ContactMiscellaneous", this._IDStatus, this._Birthday, this._Spouse, this._ReferredBy,
                                                      this._ContactID, this._EnterByID, this._EnterDate, this._EditByID, this._EditDate,this._Note);
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
        public int UpdateContactContactMiscellaneous()
        {
            int Affected = -1;
            try
            {
                object[] Params = BuildUpdateQueryParams();
                BaseClass.UpdateCommand("SP_UPDATE_Contact_ContactMiscellaneous", Params);
                Affected = 1;
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return Affected;
        }

        /// <summary>
        /// Get list of ContactContactMiscellaneous that are related to certain Contact 
        /// You should fill in the ContactID property first before calling this function
        /// </summary>
        /// <returns>Object of ContactContactMiscellaneous</returns>
        public ContactContactMiscellaneous GetContactMiscellanousData()
        {
            ContactContactMiscellaneous CCM = new ContactContactMiscellaneous();
            SqlConnection conMisc = new SqlConnection(StrCon);
            try
            {
                SqlDataReader rdrMisc = SqlHelper.ExecuteReader(StrCon, "SP_Get_Contact_ContactMiscellaneous", this.ContactID);
                while (rdrMisc.Read())
                {
                    CCM.MID = int.Parse(rdrMisc["MID"].ToString());
                    if (rdrMisc["IDStatus"] != null && rdrMisc["IDStatus"].ToString() != "")
                        CCM.IDStatus = int.Parse(rdrMisc["IDStatus"].ToString());
                    if (rdrMisc["Birthday"] != null && rdrMisc["Birthday"].ToString() != "")
                        CCM.Birthday = Convert.ToDateTime(rdrMisc["Birthday"].ToString());
                    CCM.Spouse = rdrMisc["Spouse"].ToString();
                    CCM.ReferredBy = rdrMisc["ReferredBy"].ToString();
                    if (rdrMisc["ContactID"] != null && rdrMisc["ContactID"].ToString() != "")
                        CCM.ContactID = int.Parse(rdrMisc["ContactID"].ToString());
                    if (rdrMisc["EnterByID"] != null && rdrMisc["EnterByID"].ToString() != "")
                        CCM.EnterByID = int.Parse(rdrMisc["EnterByID"].ToString());
                    if (rdrMisc["EnterDate"] != null && rdrMisc["EnterDate"].ToString() != "")
                        CCM.EnterDate = Convert.ToDateTime(rdrMisc["EnterDate"].ToString());
                    if (rdrMisc["EditByID"] != null && rdrMisc["EditByID"].ToString() != "")
                        CCM.EditByID = int.Parse(rdrMisc["EditByID"].ToString());
                    if (rdrMisc["EditDate"] != null && rdrMisc["EditDate"].ToString() != "")
                        CCM.EditDate = Convert.ToDateTime(rdrMisc["EditDate"].ToString());
                    CCM.ContactFirstName = rdrMisc["ContactFirsName"].ToString();
                    CCM.ContactLastName = rdrMisc["ContactLastName"].ToString();
                    CCM.EnterByName = rdrMisc["EnterByName"].ToString();
                    CCM.EnterByName = rdrMisc["EditByName"].ToString();
                    CCM.StatusName = rdrMisc["StatusName"].ToString();
                    CCM.Note = rdrMisc["Note"].ToString();
                }
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                conMisc.Close();
            }
            return CCM;
        }

        /// <summary>
        /// Check if there is related Miscellaneous data for certain contact or not.
        /// Fill in the ContactID property before calling this function
        /// </summary>
        /// <returns>True if this record exists, false otherwise</returns>
        public bool CheckRecordExistance()
        {
            SqlConnection conExist = new SqlConnection(StrCon);
            bool Exist = false;
            try
            {
                SqlDataReader rdrExist = SqlHelper.ExecuteReader(conExist, "SP_Check_Miscellaneous_Existance", this.ContactID);
                if (rdrExist.HasRows)
                    Exist = true;
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                conExist.Close();
            }
            return Exist;
        }

        #endregion

        #region ------------------Private Functions---------------

        private object[] BuildUpdateQueryParams()
        {
            object [] UpdateParameters = new object[11];
            UpdateParameters[0] = this._MID.ToString();

            if (this._IDStatus == null)
                UpdateParameters[1] = "-1";
            else
                UpdateParameters[1] = this._IDStatus.ToString();

            if (this._Birthday == null)
                UpdateParameters[2] = "-1";
            else
                UpdateParameters[2] = this._Birthday.ToString();

            if (this._Spouse == null)
                UpdateParameters[3] = "-1";
            else
                UpdateParameters[3] = this._Spouse.ToString();

            if (this._ReferredBy == null)
                UpdateParameters[4] = "-1";
            else
                UpdateParameters[4] = this._ReferredBy.ToString();

            if (this._ContactID == null)
                UpdateParameters[5] = "-1";
            else
                UpdateParameters[5] = this._ContactID.ToString();

            if (this._EnterByID == null)
                UpdateParameters[6] = "-1";
            else
                UpdateParameters[6] = this._EnterByID.ToString();

            if (this._EnterDate == null)
                UpdateParameters[7] = "-1";
            else
                UpdateParameters[7] = this._EnterDate.ToString();

            if (this._EditByID == null)
                UpdateParameters[8] = "-1";
            else
                UpdateParameters[8] = this._EditByID.ToString();

            if (this._EditDate == null)
                UpdateParameters[9] = "-1";
            else
                UpdateParameters[9] = this._EditDate.ToString();

            if (this._Note == null)
                UpdateParameters[10] = "-1";
            else
                UpdateParameters[10] = this._Note.ToString();

            return UpdateParameters;
        }

        #endregion
    }
}
