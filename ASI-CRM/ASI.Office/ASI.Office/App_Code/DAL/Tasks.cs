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
    public class Tasks
    {
        #region ------------------Constructors------------------

        public Tasks()
        {
            //
            // TODO : Implement Constructor Function
            //
        }

        #endregion

        #region -------------------Properties--------------------

        public enum SortBy
        {
            Subject
        }

        public int? ForwordID
        {
            get { return _ForwordID; }
            set { _ForwordID = value; }
        }

        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }

        public int? TechnicalSupportID
        {
            get { return _TechnicalSupportID; }
            set { _TechnicalSupportID = value; }
        }

        public string RelatedToContact
        {
            get { return _RelatedToContact; }
            set { _RelatedToContact = value; }
        }

        public DateTime TaskDate
        {
            get { return _TaskDate; }
            set { _TaskDate = value; }
        }

        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        public int? EnterByID
        {
            get { return _EnterByID; }
            set { _EnterByID = value; }
        }

        public string From
        {
            get { return _From; }
            set { _From = value; }
        }

        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public int? CallID
        {
            get { return _CallID; }
            set { _CallID = value; }
        }

        public string Site
        {
            get { return _Site; }
            set { _Site = value; }
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

        private int? _ForwordID;
        private string _Subject;
        private int? _TechnicalSupportID;
        private string _RelatedToContact;
        private DateTime _TaskDate;
        private string _Type;
        private int? _EnterByID;
        private string _From;
        private string _Status;
        private int? _CallID;
        private string _Site;
        private SortBy _SortExpression;
        private SortDirection _SortDirect;

        string StrCon = ConfigurationManager.ConnectionStrings["ASI-CRMConnectionString"].ToString();

        #endregion

        #region -----------------General Functions---------------

        /// <summary>
        /// Get all Tasks that meets search crieteria that are supplied by object properties
        /// </summary>
        /// <returns>List of Tasks objects that meet the search criteria</returns>
        public List<Tasks> GetOpenTasks(int UserID, DateTime OpenTaskDate)
        {
            ELSData.DataService sdata = new ELSData.DataService();
            ELSData.AuthHeader ss = new ELSData.AuthHeader();
            sdata.Url = ConfigurationManager.AppSettings["ELSData.DataService"].ToString();
            ss.Password = ConfigurationManager.AppSettings["UserNameELS"].ToString();
            ss.Username = ConfigurationManager.AppSettings["PasswordELS"].ToString();
            sdata.AuthHeaderValue = ss;

            if (System.Diagnostics.Debugger.IsAttached)
                UserID = 26;
            List<Tasks> TasksList = new List<Tasks>();
            SqlConnection conCalls = new SqlConnection(StrCon);
            try
            {
                Tasks Task;
                //string SortCriteria = BuildSortCriteria();
                SqlDataReader rdrTasks = SqlHelper.ExecuteReader(conCalls, "OpenTasks_Get", UserID, OpenTaskDate);
                while (rdrTasks.Read())
                {
                    Task = new Tasks();

                    if (rdrTasks["TechnicalSupportID"] != DBNull.Value)
                    {
                        int TechnicalSupportID = Convert.ToInt32(rdrTasks["TechnicalSupportID"]);
                        DataTable dt = sdata.getContactDetails(TechnicalSupportID);

                        if (rdrTasks["ForwordID"] != DBNull.Value)
                            Task.ForwordID = int.Parse(rdrTasks["ForwordID"].ToString());
                        else
                            Task.ForwordID = null;
                        Task.Subject = rdrTasks["Subject"].ToString();
                        Task.TechnicalSupportID = TechnicalSupportID;
                        Task.RelatedToContact = dt.Rows[0]["firstName"].ToString() + " " + dt.Rows[0]["lastName"].ToString();//rdrTasks["RelatedToContact"].ToString();
                        Task.TaskDate = Convert.ToDateTime(rdrTasks["TaskDate"].ToString());
                        Task.Type = rdrTasks["Type"].ToString();
                        if (rdrTasks["EnterByID"] != DBNull.Value)
                            Task.EnterByID = int.Parse(rdrTasks["EnterByID"].ToString());
                        else
                            Task.EnterByID = null;
                        Task.From = rdrTasks["From"].ToString();
                        Task.Status = rdrTasks["Status"].ToString();
                        if (rdrTasks["CallID"] != DBNull.Value)
                            Task.CallID = int.Parse(rdrTasks["CallID"].ToString());
                        else
                            Task.CallID = null;
                        Task.Site = rdrTasks["Site"].ToString();

                        TasksList.Add(Task);
                    }
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
            return TasksList;
        }

        #endregion

        #region -----------------Private Functions---------------


        private string BuildSortCriteria()
        {
            string SortCriteria = "-1";

            switch (this.SortExpression)
            {
                case Tasks.SortBy.Subject:
                    SortCriteria = "Subject";
                    break;
                default:
                    SortCriteria = "Subject";
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