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
using System.Data.SqlClient;
using Office.DAL.ApplicationBlocks;

namespace Office.DAL
{
    [Serializable]
    public class ContactConnection
    {
        #region ------------------Constructors------------------

        public ContactConnection()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region -------------------Properties--------------------

        public int? ConnectionID
        {
            get { return _ConnectionID; }
            set { _ConnectionID = value; }
        }

        public int? ConnectionTypeID
        {
            get { return _ConnectionTypeID; }
            set { _ConnectionTypeID = value; }
        }

        public DateTime? ConnectionDate
        {
            get { return _ConnectionDate; }
            set { _ConnectionDate = value; }
        }

        public int? UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        public int? ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; }
        }

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public string ConnectionType
        {
            get { return _ConnectionType; }
            set { _ConnectionType = value; }
        }

        #endregion

        #region -----------------Private Variables----------------

        private int? _ConnectionID;
        private int? _ConnectionTypeID;
        private DateTime? _ConnectionDate;
        private int? _UserID;
        private int? _ContactID;
        private string _UserName;
        private string _ConnectionType;

        string StrCon = ConfigurationManager.ConnectionStrings["ASI-CRMConnectionString"].ToString();

        #endregion

        #region -----------------General Functions---------------
        /// <summary>
        /// Insert new record into table Contact_Connection
        /// Fill in all properties of the Contact_Connection Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int AddNewContactConnection()
        {
            int Affected = -1;
            try
            {
                BaseClass.InsertCommand("SP_INSERT_INTO_Contact_Connection", this._ConnectionTypeID, this._ConnectionDate, this._UserID, this._ContactID);
                Affected = 1;
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return Affected;
        }
        
        /// <summary>
        /// Update existing record in table Contact_Connection
        /// Fill in all properties of the Contact_Connection Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int UpdateContactConnection()
        {
            int Affected = -1;
            try
            {
                object[] Params = BuildUpdateQueryParams();
                Affected = BaseClass.UpdateCommand("SP_UPDATE_Contact_Connection", Params);    
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return Affected;
        }

        /// <summary>
        /// Get ContactConnection data 
        /// </summary>
        /// <returns>ContactConnection object</returns>
        public ContactConnection GetContactConnection()
        {
            SqlConnection conContCon = new SqlConnection(StrCon);
            ContactConnection ContCon = new ContactConnection();
            try
            {
                SqlDataReader rdrContCon = SqlHelper.ExecuteReader(conContCon, "SP_Get_Contact_Connection", this._ContactID);
                while (rdrContCon.Read())
                {
                    ContCon.ConnectionID = int.Parse(rdrContCon["CID"].ToString());
                    ContCon.ContactID = int.Parse(rdrContCon["ContactID"].ToString());

                    if(rdrContCon["ConnectionTypeID"] != null && rdrContCon["ConnectionTypeID"].ToString() != "")
                        ContCon.ConnectionTypeID = int.Parse(rdrContCon["ConnectionTypeID"].ToString());
                    if (rdrContCon["ConnectionDate"] != null && rdrContCon["ConnectionDate"].ToString() != "")
                        ContCon.ConnectionDate = Convert.ToDateTime(rdrContCon["ConnectionDate"].ToString());
                    if (rdrContCon["UserID"] != null && rdrContCon["UserID"].ToString() != "")
                        ContCon.UserID = int.Parse(rdrContCon["UserID"].ToString());
                    if (rdrContCon["UserName"] != null && rdrContCon["UserName"].ToString() != "") 
                        ContCon.UserName = rdrContCon["UserName"].ToString();
                    if (rdrContCon["SCode"] != null && rdrContCon["SCode"].ToString() != "") 
                        ContCon.ConnectionType = rdrContCon["SCode"].ToString();
                }
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                conContCon.Close();
            }
            return ContCon;
        }

        /// <summary>
        /// Get last acction for certain contact. (e.g. last attempt, last meeting or last reach
        /// </summary>
        /// <returns>DateTime</returns>
        public DateTime GetLastAction()
        {
            DateTime dtLastAction = DateTime.MinValue;
            try
            {
                object DateValue = SqlHelper.ExecuteScalar(StrCon, "SP_Get_Contact_Connection_Last_Action", this._ContactID, this._ConnectionTypeID);
                if (DateValue != null)
                    dtLastAction = Convert.ToDateTime(DateValue);
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return dtLastAction;
        }
        #endregion

        #region -----------------Private Functions---------------
        private object[] BuildUpdateQueryParams()
        {
            object[] UpdateParameters = new object[5];
            UpdateParameters[0] = this.ConnectionID.ToString();

            if (this.ConnectionTypeID == null)
                UpdateParameters[1] = "-1";
            else
                UpdateParameters[1] = this.ConnectionTypeID.ToString();

            if (this.ConnectionDate == null)
                UpdateParameters[2] = "-1";
            else
                UpdateParameters[2] = this.ConnectionDate.ToString();

            if (this.UserID == null)
                UpdateParameters[3] = "-1";
            else
                UpdateParameters[3] = this.UserID.ToString();

            if (this.ContactID == null)
                UpdateParameters[4] = "-1";
            else
                UpdateParameters[4] = this.ContactID.ToString();

            return UpdateParameters;
        }
        #endregion
    }
}