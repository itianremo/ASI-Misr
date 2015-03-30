using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Office.DAL.ApplicationBlocks;
using Office.DAL;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
/// <summary>
/// Summary RelatedToContact for History
/// </summary>
namespace Office.DAL
{
    [Serializable]
    public class CustomerSupport
    {
        public CustomerSupport()
        {
           
        }

        string StrCon = ConfigurationManager.ConnectionStrings["ASI-CRMConnectionString"].ToString();
        #region -------------------- Properties -------------------

        public enum SortBy
        {
            ForwordID,
           RelatedToContact,
            Subject

        }

        public enum SearchBy
        {
            RelatedToContact,
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

        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        
        public string RelatedToContact
        {
            get { return _RelatedToContact; }
            set { _RelatedToContact = value; }

        }

       
        public int? ForwordToUserID
        {
            get { return _ForwordToUserID; }
            set { _ForwordToUserID = value; }
        }
       
        public int? EnterBy
        {
            get { return _EnterBy; }
            set { _EnterBy = value; }
        }

        public DateTime? EnterDate
        {
            get { return _EnterDate; }
            set { _EnterDate = value; }
        }

        public int? TechnicalSupportID
        {
            get { return _TechnicalSupportID; }
            set { _TechnicalSupportID = value; }
        }

        public DateTime? TechnicalSupportDate
        {
            get { return _TechnicalSupportDate; }
            set { _TechnicalSupportDate = value; }
        }

        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
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

        #region -----------------Private Variables-----------------

        private int? _EnterBy;
        private int? _ForwordToUserID;
        private DateTime? _EnterDate;
        private int? _TechnicalSupportID;
        private DateTime? _TechnicalSupportDate;
        private string _Status;
        private string _Site;

        private int? _ForwordID;

        private string _Subject;

        private string _Type;


        private string _RelatedToContact;

      
        private SortBy _SortExpression;
        private SortDirection _SortDirect;
       

        #endregion

        #region -----------------General Functions----------------

       
        public int AddNewForwordTechnicalSupport()
        {
            int AffectedRows = -1;
            try
            {
                 
                object objSupport = SqlHelper.ExecuteNonQuery(StrCon, "ForwordTechnicalSupport_Insert", this._Subject,  this._RelatedToContact,this._Type,  this._EnterBy, this._EnterDate,this._ForwordToUserID,this._Status, this._TechnicalSupportID, this._TechnicalSupportDate,this._Site);
                if (objSupport != null)
                    AffectedRows = int.Parse(objSupport.ToString());
                //AffectedRows = 1;
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return AffectedRows;
        }
        
        public DataSet GetLoginUsers()
        {
            DataSet dsLoginUsers = SqlHelper.ExecuteDataset(StrCon,CommandType.StoredProcedure, "Sec_UserLogin_Get_List");
            return dsLoginUsers;

        }
        #endregion

    }
}