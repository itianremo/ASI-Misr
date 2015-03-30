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
    public class WebsitesServices
    {
        #region ------------------Constructors------------------

        public WebsitesServices()
        {
            //
            // TODO : Implement Constructor Function
            //
        }

        #endregion

        #region -------------------Properties--------------------

        public enum SortBy
        {
            WSName
        }

        public int WSID
        {
            get { return _WSID; }
            set { _WSID = value; }
        }

        public string WSName
        {
            get { return _WSName; }
            set { _WSName = value; }
        }

        public string WSURL
        {
            get { return _WSURL; }
            set { _WSURL = value; }
        }

        public string WSUsername
        {
            get { return _WSUsername; }
            set { _WSUsername = value; }
        }

        public string WSPassword
        {
            get { return _WSPassword; }
            set { _WSPassword = value; }
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

        private int _WSID;
        private string _WSName;
        private string _WSURL;
        private string _WSUsername;
        private string _WSPassword;
        private SortBy _SortExpression;
        private SortDirection _SortDirect;

        string StrCon = ConfigurationManager.ConnectionStrings["ASI-CRMConnectionString"].ToString();

        #endregion

        #region -----------------General Functions---------------

        /// <summary>
        /// Insert new record into table WebsitesService
        /// Fill in all properties of the WebsitesService Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int AddNewWebsitesService()
        {
            int Affected = -1;
            try
            {
                BaseClass.InsertCommand("WebsitesServices_Insert", this._WSName, this._WSURL,
                    this._WSUsername, this._WSPassword);
                Affected = 1;
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return Affected;
        }

        /// <summary>
        /// Update existing record in table WebsitesServices
        /// Fill in all properties of the WebsitesService Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int UpdateWebsitesService()
        {
            int Affected = -1;
            try
            {
                object[] Params = BuildUpdateQueryParams();
                BaseClass.UpdateCommand("WebsitesServices_Update", Params);
                Affected = 1;
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return Affected;
        }

        /// <summary>
        /// Delete existing record in table WebsitesServices
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public string DeleteWebsitesService()
        {
            object Affected = "-1";
            try
            {
                object[] Params = { _WSID, 0 };
                Affected = BaseClass.ReturnValueCommand("WebsitesServices_Delete", Params);  
            }
            catch (Exception Exp)
            {
                return Exp.Message;
            }
            return Affected.ToString();
        }

        /// <summary>
        /// Get all WebsitesServices that meets search crieteria that are supplied by object properties
        /// </summary>
        /// <returns>List of WebsitesServices objects that meet the search criteria</returns>
        public List<WebsitesServices> GetRelatedWebsitesServices()
        {
            List<WebsitesServices> WebsitesServicesList = new List<WebsitesServices>();
            SqlConnection conWebsitesServices = new SqlConnection(StrCon);
            try
            {
                WebsitesServices WebsitesService;
                string Filter = BuildFilter();
                string SortCriteria = BuildSortCriteria();
                SqlDataReader rdrNotes = SqlHelper.ExecuteReader(conWebsitesServices, "WebsitesServices_Get", Filter, SortCriteria);
                while (rdrNotes.Read())
                {
                    WebsitesService = new WebsitesServices();

                    WebsitesService.WSID = int.Parse(rdrNotes["WSID"].ToString());
                    WebsitesService.WSName = rdrNotes["WSName"].ToString();
                    WebsitesService.WSURL = rdrNotes["WSURL"].ToString();
                    WebsitesService.WSUsername = rdrNotes["WSUsername"].ToString();
                    WebsitesService.WSPassword = rdrNotes["WSPassword"].ToString();

                    WebsitesServicesList.Add(WebsitesService);
                }
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                conWebsitesServices.Close();
            }
            return WebsitesServicesList;
        }

        public WebsitesServices GetWebsitesServiceByID(int WSID)
        {
            WebsitesServices WebsitesService = new WebsitesServices();
            SqlConnection conWebsitesServices = new SqlConnection(StrCon);
            try
            {
                SqlDataReader rdrNotes = SqlHelper.ExecuteReader(conWebsitesServices, "WebsitesServices_Get", " AND WebsitesServices.WSID = " + WSID, "-1");
                if (rdrNotes.Read())
                {
                    WebsitesService.WSID = int.Parse(rdrNotes["WSID"].ToString());
                    WebsitesService.WSName = rdrNotes["WSName"].ToString();
                    WebsitesService.WSURL = rdrNotes["WSURL"].ToString();
                    WebsitesService.WSUsername = rdrNotes["WSUsername"].ToString();
                    WebsitesService.WSPassword = rdrNotes["WSPassword"].ToString();
                }
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                conWebsitesServices.Close();
            }
            return WebsitesService;
        }

        #endregion

        #region -----------------Private Functions---------------

        private string BuildFilter()
        {
            string Filter = "";

            if (this.WSName != null)
                Filter += " AND WebsitesServices.WSName LIKE '%" + this.WSName + "%'";
            if (this.WSURL != null)
                Filter += " AND WebsitesServices.WSURL LIKE '%" + this.WSURL + "%'";
            if (this.WSUsername != null)
                Filter += " AND WebsitesServices.WSName LIKE '%" + this.WSUsername + "%'";
            if (this.WSPassword != null)
                Filter += " AND WebsitesServices.WSURL LIKE '%" + this.WSPassword + "%'";

            return Filter;
        }

        private object[] BuildUpdateQueryParams()
        {
            object[] UpdateParameters = new object[5];
            UpdateParameters[0] = this.WSID.ToString();

            if (this.WSName == null)
                UpdateParameters[1] = "-1";
            else
                UpdateParameters[1] = this.WSName;

            if (this.WSURL == null)
                UpdateParameters[2] = "-1";
            else
                UpdateParameters[2] = this.WSURL;

            if (this.WSUsername == null)
                UpdateParameters[3] = "-1";
            else
                UpdateParameters[3] = this.WSUsername;

            if (this.WSPassword == null)
                UpdateParameters[4] = "-1";
            else
                UpdateParameters[4] = this.WSPassword;

            return UpdateParameters;
        }

        private string BuildSortCriteria()
        {
            string SortCriteria = "-1";

            if (this.SortExpression == SortBy.WSName)
                SortCriteria = "WebsitesServices.WSName";

            if (this.SortDirect == SortDirection.Ascending)
                SortCriteria += " ASC";
            if (this.SortDirect == SortDirection.Descending)
                SortCriteria += " Desc";

            return SortCriteria;
        }

        /// <summary>
        /// Check if the given WSName exists before or not.
        /// You should set the WSName before calling this function
        /// </summary>
        /// <returns>Nullable boolean, true in case of exist true if not and null in case of error</returns>
        public bool? CheckWSNameExistance()
        {
            bool? Exist = null;
            SqlConnection ECon = new SqlConnection(StrCon);
            try
            {
                int Count = (int)BaseClass.ReturnValueCommand("WebsitesServices_Check_WSName_Existance", this._WSName, 0);
                if (Count > 0)
                    Exist = true;
                else
                    Exist = false;
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                ECon.Close();
            }
            return Exist;
        }

        /// <summary>
        /// Check if the given WSName exists or not.
        /// You should set the WSName before calling this function
        /// </summary>
        /// <returns>Nullable boolean, true in case of exist true if not and null in case of error</returns>
        public bool? CheckUpdatedWSNameExistance()
        {
            bool? Exist = null;
            SqlConnection ECon = new SqlConnection(StrCon);
            try
            {
                int Count = (int)BaseClass.ReturnValueCommand("WebsitesServices_Check_Updated_WSName_Existance", this._WSID, this._WSName, 0);
                if (Count > 0)
                    Exist = true;
                else
                    Exist = false;
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                ECon.Close();
            }
            return Exist;
        }
        #endregion
    }
}