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
    public class MyCalls
    {
        #region ------------------Constructors------------------

        public MyCalls()
        {
            //
            // TODO : Implement Constructor Function
            //
        }

        #endregion

        #region -------------------Properties--------------------

        public enum SortBy
        {
            Date
        }

        public int CallID
        {
            get { return _CallID; }
            set { _CallID = value; }
        }

        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }

        public DateTime? Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public int? ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; }
        }

        public string RelatedTo
        {
            get { return _RelatedTo; }
            set { _RelatedTo = value; }
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

        private int _CallID;
        private string _Subject;
        private DateTime? _Date;
        private string _Status;
        private int? _ContactID;
        private string _RelatedTo;
        private SortBy _SortExpression;
        private SortDirection _SortDirect;

        string StrCon = ConfigurationManager.ConnectionStrings["ASI-CRMConnectionString"].ToString();

        #endregion

        #region -----------------General Functions---------------

        /// <summary>
        /// Get all MyCall that meets search crieteria that are supplied by object properties
        /// </summary>
        /// <returns>List of MyCall objects that meet the search criteria</returns>
        public List<MyCalls> GetMyCalls()
        {
            List<MyCalls> MyCallsList = new List<MyCalls>();
            SqlConnection conCalls = new SqlConnection(StrCon);
            try
            {
                MyCalls MyCall;
                SqlDataReader rdrMyCalls = SqlHelper.ExecuteReader(conCalls, "MyCalls_Get");
                while (rdrMyCalls.Read())
                {
                    MyCall = new MyCalls();

                    MyCall.CallID = int.Parse(rdrMyCalls["CallID"].ToString());
                    MyCall.Subject = rdrMyCalls["Subject"].ToString();
                    MyCall.Date = Convert.ToDateTime(rdrMyCalls["Date"].ToString());
                    MyCall.Status = rdrMyCalls["Status"].ToString();
                    MyCall.ContactID = int.Parse(rdrMyCalls["ContactID"].ToString());
                    MyCall.RelatedTo = rdrMyCalls["RelatedTo"].ToString();

                    MyCallsList.Add(MyCall);
                }
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                conCalls.Close();
            }
            return MyCallsList;
        }

        #endregion

        #region -----------------Private Functions---------------

        #endregion
    }
}