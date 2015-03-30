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
    public class TopAccounts
    {
        #region ------------------Constructors------------------

        public TopAccounts()
        {
            //
            // TODO : Implement Constructor Function
            //
        }

        #endregion

        #region -------------------Properties--------------------

        public enum SortBy
        {
            AName,
            Phone,
            City,
            State,
            CountryName,
            Status,
            BusinessSector
        }

        public int AID
        {
            get { return _AID; }
            set { _AID = value; }
        }

        public string AccountName
        {
            get { return _AccountName; }
            set { _AccountName = value; }
        }

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        public string CountryName
        {
            get { return _CountryName; }
            set { _CountryName = value; }
        }

        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public DateTime? NoteDate
        {
            get { return _NoteDate; }
            set { _NoteDate = value; }
        }

        public string BusinessSector
        {
            get { return _BusinessSector; }
            set { _BusinessSector = value; }
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

        private int _AID;
        private string _AccountName;
        private string _Phone;
        private string _City;
        private string _State;
        private string _CountryName;
        private string _Status;
        private string _BusinessSector;
        private DateTime? _NoteDate;
        private SortBy _SortExpression;
        private SortDirection _SortDirect;

        string StrCon = ConfigurationManager.ConnectionStrings["ASI-CRMConnectionString"].ToString();

        #endregion

        #region -----------------General Functions---------------

        /// <summary>
        /// Get all TopAccounts that meets search crieteria that are supplied by object properties
        /// </summary>
        /// <returns>List of TopAccounts objects that meet the search criteria</returns>
        public List<TopAccounts> GetTopAccounts()
        {
            List<TopAccounts> TopAccountsList = new List<TopAccounts>();
            SqlConnection conTopAccounts = new SqlConnection(StrCon);
            try
            {
                TopAccounts TopAccount;
                string SortCriteria = BuildSortCriteria();
                SqlDataReader rdrMyCalls = SqlHelper.ExecuteReader(conTopAccounts, "TopAccounts_Get", SortCriteria);
                while (rdrMyCalls.Read())
                {
                    TopAccount = new TopAccounts();

                    TopAccount.AID = int.Parse(rdrMyCalls["AID"].ToString());
                    TopAccount.AccountName = rdrMyCalls["AccountName"].ToString();
                    TopAccount.Phone = rdrMyCalls["Phone"].ToString();
                    TopAccount.City = rdrMyCalls["City"].ToString();
                    TopAccount.State = rdrMyCalls["State"].ToString();
                    TopAccount.CountryName = rdrMyCalls["CountryName"].ToString();
                    TopAccount.Status = rdrMyCalls["Status"].ToString();
                    TopAccount.BusinessSector = rdrMyCalls["BusinessSector"].ToString();
                    if (rdrMyCalls["NoteDate"] != null && rdrMyCalls["NoteDate"].ToString() != "")
                        TopAccount.NoteDate = Convert.ToDateTime(rdrMyCalls["NoteDate"].ToString());
                    else
                        TopAccount.NoteDate = DateTime.MinValue;

                    TopAccountsList.Add(TopAccount);
                }
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                conTopAccounts.Close();
            }
            return TopAccountsList;
        }

        #endregion

        #region -----------------Private Functions---------------
        private string BuildSortCriteria()
        {
            string SortCriteria = "-1";

            switch (this.SortExpression)
            {
                case TopAccounts.SortBy.AName:
                    SortCriteria = "AName";
                    break;
                case TopAccounts.SortBy.BusinessSector:
                    SortCriteria = "BusinessSector";
                    break;
                case TopAccounts.SortBy.City:
                    SortCriteria = "City";
                    break;
                case TopAccounts.SortBy.CountryName:
                    SortCriteria = "CountryName";
                    break;
                case TopAccounts.SortBy.Phone:
                    SortCriteria = "Phone";
                    break;
                case TopAccounts.SortBy.State:
                    SortCriteria = "State";
                    break;
                case TopAccounts.SortBy.Status:
                    SortCriteria = "Status";
                    break;
                default:
                    SortCriteria = "AName";
                    break;
            }
            if (this.SortDirect == SortDirection.Ascending)
                SortCriteria += " ASC";
            if (this.SortDirect == SortDirection.Descending)
                SortCriteria += " Desc";

            return SortCriteria;
        }
        #endregion
    }
}