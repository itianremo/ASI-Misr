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
    public class SubCompany
    {
        #region ------------------Constructors------------------

        public SubCompany()
        {
            //
            // TODO : Implement Constructor Function
            //
        }

        #endregion

        #region -------------------Properties--------------------

        public enum SortBy
        {
            Type
        }

        public int? ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }

        public int? AccountID
        {
            get { return _AccountID; }
            set { _AccountID = value; }
        }

        public string AccountName
        {
            get { return _AccountName; }
            set
            {
                _AccountName = value;
            }
        }

        public int? Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        public string TypeName
        {
            get { return _TypeName; }
            set { _TypeName = value; }
        }

        public DateTime? Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
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

        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
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

        private int? _ParentID;
        private int? _AccountID;
        private string _AccountName;
        private int? _Type;
        private string _TypeName;
        private DateTime? _Notes;
        private string _City;
        private string _State;
        private string _Country;
        private string _Phone;
        private SortBy _SortExpression;
        private SortDirection _SortDirect;

        static string StrCon = ConfigurationManager.ConnectionStrings["ASI-CRMConnectionString"].ToString();

        #endregion

        #region -----------------General Functions---------------


        /// <summary>
        /// Get all SubCompanies for certain Parent
        /// </summary>
        /// <returns>List of SubCompanies objects</returns>
        public List<SubCompany> GetAccountHierarchies()
        {
            List<SubCompany> SCList = new List<SubCompany>();
            SqlConnection conSC = new SqlConnection(StrCon);
            try
            {
                SubCompany SC;
                SqlDataReader rdrSC = SqlHelper.ExecuteReader(conSC, "SubCompanies_Get", this._ParentID);
                while (rdrSC.Read())
                {
                    SC = new SubCompany();

                    SC.ParentID = int.Parse(rdrSC["ParentID"].ToString());
                    SC.AccountID = int.Parse(rdrSC["AccountID"].ToString());
                    SC.AccountName = rdrSC["AccountName"].ToString();
                    SC.Type = int.Parse(rdrSC["Type"].ToString());
                    SC.TypeName = rdrSC["TypeName"].ToString();
                    if (rdrSC["Notes"] != null && rdrSC["Notes"].ToString() != "")
                        SC.Notes = Convert.ToDateTime(rdrSC["Notes"].ToString());
                    else
                        SC.Notes = DateTime.MinValue;
                    SC.City = rdrSC["City"].ToString();
                    SC.State = rdrSC["State"].ToString();
                    SC.Country = rdrSC["Country"].ToString();
                    SC.Phone = rdrSC["Phone"].ToString();

                    SCList.Add(SC);
                }
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                conSC.Close();
            }
            return SCList;
        }

        /// <summary>
        /// Get all sub accounts names and ids
        /// </summary>
        /// <returns>List of  ContactAccount objects that meets the search filter</returns>
        public static List<SubCompany> GetSubAccountsNames(bool All)
        {
            List<SubCompany> AccList = new List<SubCompany>();
            SqlConnection conList = new SqlConnection(StrCon);
            try
            {
                SqlDataReader rdrAccList = SqlHelper.ExecuteReader(StrCon, "SubCompanies_Names_Get", All);
                SubCompany CntAcc;
                while (rdrAccList.Read())
                {
                    CntAcc = new SubCompany();

                    CntAcc.AccountID = int.Parse(rdrAccList["AccountID"].ToString());
                    CntAcc.AccountName = rdrAccList["AccountName"].ToString();

                    AccList.Add(CntAcc);
                }
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                conList.Close();
            }
            return AccList;
        }

        #endregion

        #region -----------------Private Functions---------------

        #endregion
    }
}