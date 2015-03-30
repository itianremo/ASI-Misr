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
    public class ContactAccountHierarchy
    {
        #region ------------------Constructors------------------

        public ContactAccountHierarchy()
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

        public int ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }

        public int AID
        {
            get { return _AID; }
            set { _AID = value; }
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

        private int _ParentID;
        private int _AID;
        private int? _Type;
        private string _TypeName;
        private SortBy _SortExpression;
        private SortDirection _SortDirect;

        string StrCon = ConfigurationManager.ConnectionStrings["ASI-CRMConnectionString"].ToString();

        #endregion

        #region -----------------General Functions---------------

        /// <summary>
        /// Insert new record into table Contact_AccountHierarchy
        /// Fill in all properties of the Contact_AccountHierarchy Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int AddNewAccountHierarchy()
        {
            int Affected = -1;
            try
            {
                BaseClass.InsertCommand("Contact_AccountHierarchy_Insert", this._ParentID, this._AID, this._Type);
                Affected = 1;
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return Affected;
        }

        /// <summary>
        /// Update existing record in table Contact_AccountHierarchy
        /// Fill in all properties of the Contact_AccountHierarchy Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int UpdateAccountHierarchy()
        {
            int Affected = -1;
            try
            {
                BaseClass.UpdateCommand("Contact_AccountHierarchy_Update", this._ParentID, this._AID, this._Type);
                Affected = 1;
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return Affected;
        }

        /// <summary>
        /// Delete existing record in table Contact_AccountHierarchy
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public string DeleteAccountHierarchy()
        {
            object Affected = "-1";
            try
            {
                Affected = BaseClass.ReturnValueCommand("Contact_AccountHierarchy_Delete", this._AID);  
            }
            catch (Exception Exp)
            {
                return Exp.Message;
            }
            return Affected.ToString();
        }

        /// <summary>
        /// Get all Contact_AccountHierarchies 
        /// </summary>
        /// <returns>List of Contact_AccountHierarchies objects</returns>
        public List<ContactAccountHierarchy> GetAccountHierarchies()
        {
            List<ContactAccountHierarchy> AccountHierarchiesList = new List<ContactAccountHierarchy>();
            SqlConnection conAccountHierarchies = new SqlConnection(StrCon);
            try
            {
                ContactAccountHierarchy CAH;
                SqlDataReader rdrNotes = SqlHelper.ExecuteReader(conAccountHierarchies, "Contact_AccountHierarchy_Get");
                while (rdrNotes.Read())
                {
                    CAH = new ContactAccountHierarchy();

                    CAH.ParentID = int.Parse(rdrNotes["ParentID"].ToString());
                    CAH.AID = int.Parse(rdrNotes["AID"].ToString());
                    if (rdrNotes["Type"] != null && rdrNotes["Type"].ToString() != "")
                        CAH.Type = int.Parse(rdrNotes["Type"].ToString());
                    else
                        CAH.Type = int.MinValue;
                    CAH.TypeName = rdrNotes["TypeName"].ToString();

                    AccountHierarchiesList.Add(CAH);
                }
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                conAccountHierarchies.Close();
            }
            return AccountHierarchiesList;
        }

        /// <summary>
        /// Get Account Parent by AccountID
        /// </summary>
        /// <returns>List of Contact_AccountHierarchies objects</returns>
        public object GetAccountParent()
        {
            object result = -1;

            try
            {
                object Val = BaseClass.ReturnValueCommand("Contact_AccountHierarchy_Get_By_AID", this._AID, 0);
                if (!Val.Equals(0))
                    result = Val;
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return result;
        }
        #endregion

        #region -----------------Private Functions---------------

        #endregion
    }
}