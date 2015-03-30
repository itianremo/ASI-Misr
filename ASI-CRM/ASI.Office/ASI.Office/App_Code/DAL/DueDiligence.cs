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
    public class DueDiligence
    {
        #region -----------------Constructor---------------------

        public DueDiligence()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region --------------------Properties -------------------

        public enum SortBy
        {
            DueDil_ID,
            AID
        }

        public enum SearchBy
        {
            DueDil_ID,
            AID
        }

        public int? DueDil_ID
        {
            get { return _DueDil_ID; }
            set { _DueDil_ID = value; }
        }
        public int? AID
        {
            get { return _AID; }
            set { _AID = value; }
        }
                
        public byte[] CreditCheckFile
        {
            get { return _CreditCheckFile; }
            set { _CreditCheckFile = value; }
        }
        public byte[] MasterPurchaseFile
        {
            get { return _MasterPurchaseFile; }
            set { _MasterPurchaseFile = value; }
        }
      

        public int? NonproliferationSanctionsAnswers
        {
            get { return _NonproliferationSanctionsAnswers; }
            set { _NonproliferationSanctionsAnswers = value; }
        }

        public int? ManunfactureCFS
        {
            get { return _ManunfactureCFS; }
            set { _ManunfactureCFS = value; }
        }

        public string AntiboycotComplianceURL
        {
            get { return _AntiboycotComplianceURL; }
            set { _AntiboycotComplianceURL = value; }
        }

        public string NonproliferationSanctionsURL
        {
            get { return _NonproliferationSanctionsURL; }
            set { _NonproliferationSanctionsURL = value; }
        }

        public bool? ASIContact
        {
            get { return _ASIContact; }
            set { _ASIContact = value; }
        }
               
        public int? BlockedPersonListAnswer
        {
            get { return _BlockedPersonListAnswer; }
            set { _BlockedPersonListAnswer = value; }
        }
              
        public bool? TSNContact
        {
            get { return _TSNContact; }
            set { _TSNContact = value; }
        }

        public int? UnverifiedListAnswer
        {
            get { return _UnverifiedListAnswer; }
            set { _UnverifiedListAnswer = value; }
        }

        public string CreditCheckStatus
        {
            get { return _CreditCheckStatus; }
            set { _CreditCheckStatus = value; }
        }

        public string MasterPurchaseStatus
        {
            get { return _MasterPurchaseStatus; }
            set { _MasterPurchaseStatus = value; }
        }

        public string EntityListUrl
        {
            get { return _EntityListUrl; }
            set { _EntityListUrl = value; }
        }

        public string BlockedPersonListURL
        {
            get { return _BlockedPersonListURL; }
            set { _BlockedPersonListURL = value; }
        }

        public int? EntityListAnswer
        {
            get { return _EntityListAnswer; }
            set { _EntityListAnswer = value; }
        }
                
        public int? StracturalSoftware
        {
            get { return _StracturalSoftware; }
            set { _StracturalSoftware = value; }
        }
               
        public string DeniedPersonsURL
        {
            get { return _DeniedPersonsURL; }
            set { _DeniedPersonsURL = value; }
        }

        public int? DeniedPersonsAnswer
        {
            get { return _DeniedPersonsAnswer; }
            set { _DeniedPersonsAnswer = value; }
        }

        public string DebarredListURL
        {
            get { return _DebarredListURL; }
            set { _DebarredListURL = value; }
        }

        public bool? OutisdeUSA
        {
            get { return _OutisdeUSA; }
            set { _OutisdeUSA = value; }
        }

        public int? DebarredListAnswers
        {
            get { return _DebarredListAnswers; }
            set { _DebarredListAnswers = value; }
        }

        public string UnverifiedListURL
        {
            get { return _UnverifiedListURL; }
            set { _UnverifiedListURL = value; }
        }
      
        public int? AntiboycotComplianceAnswes
        {
            get { return _AntiboycotComplianceAnswes; }
            set { _AntiboycotComplianceAnswes = value; }
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
        public int? CreditParentLink_AID
        {
            get { return _CreditParentLink_AID; }
            set { _CreditParentLink_AID = value; }
        }
        public int? MasterParentLink_AID
        {
            get { return _MasterParentLink_AID; }
            set { _MasterParentLink_AID = value; }
        }

        public string CreditCheckFileName
        {
            get { return _CreditCheckFileName; }
            set { _CreditCheckFileName = value; }
        }

        public string CreditCheckFileSize
        {
            get { return _CreditCheckFileSize; }
            set { _CreditCheckFileSize = value; }
        }

        public string MasterPurchaseFileName
        {
            get { return _MasterPurchaseFileName; }
            set { _MasterPurchaseFileName = value; }
        }

        public string MasterPurchaseFileSize
        {
            get { return _MasterPurchaseFileSize; }
            set { _MasterPurchaseFileSize = value; }
        }

        #endregion

        #region -----------------Private Variables-----------------

        private int? _EnterByID;
        private DateTime? _EnterDate;
        private int? _EditByID;
        private DateTime? _EditDate;
        private int? _DueDil_ID;
        private int? _StracturalSoftware;
        private int? _ManunfactureCFS;
        private string _CreditCheckStatus;
        private byte[] _CreditCheckFile;
        private string _MasterPurchaseStatus;
        private byte[] _MasterPurchaseFile;
        private bool? _OutisdeUSA;
        private string _EntityListUrl;
        private int? _EntityListAnswer;
        private string _BlockedPersonListURL;
        private int? _BlockedPersonListAnswer;
        private string _UnverifiedListURL;
        private int? _UnverifiedListAnswer;
        private string _DeniedPersonsURL;
        private int? _DeniedPersonsAnswer;
        private string _DebarredListURL;
        private int? _DebarredListAnswers;
        private string _NonproliferationSanctionsURL;
        private int? _NonproliferationSanctionsAnswers;
        private string _AntiboycotComplianceURL;
        private int? _AntiboycotComplianceAnswes;
        private int? _AID;
        private bool? _TSNContact;
        private bool? _ASIContact;
        private int? _CreditParentLink_AID;
        private int? _MasterParentLink_AID;
        private string _CreditCheckFileName;
        private string _CreditCheckFileSize;
        private string _MasterPurchaseFileName;
        private string _MasterPurchaseFileSize;
       
        private SortBy _SortExpression;
        private SortDirection _SortDirect;
        string StrCon = ConfigurationManager.ConnectionStrings["ASI-CRMConnectionString"].ToString();

        #endregion

        #region -----------------General Functions----------------

        /// <summary>
        /// Insert new record into table Contact_DueDiligence
        /// Fill in all properties of the DueDiligence Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int AddNewDueDiligence()
        {
            int AffectedRows = -1;
            try
            {
                if (this._OutisdeUSA == null)
                    this.OutisdeUSA = false;
                if (this._ASIContact == null)
                    this.ASIContact = false;
                if (this._TSNContact == null)
                    this.TSNContact = false;



                object ReturnVal = SqlHelper.ExecuteScalar(StrCon, "DueDiligences_Insert",
                    this._StracturalSoftware,
                    this._ManunfactureCFS,
                    this._CreditCheckStatus,
                    this._CreditCheckFile,
                    this._MasterPurchaseStatus,
                    this._MasterPurchaseFile,
                    this._OutisdeUSA,
                    this._EntityListUrl, 
                    this._EntityListAnswer, 
                    this._BlockedPersonListURL, 
                    this._BlockedPersonListAnswer,
                    this._UnverifiedListURL, 
                    this._UnverifiedListAnswer,
                    this._DeniedPersonsURL,
                    this._DeniedPersonsAnswer,
                    this._DebarredListURL,
                    this._DebarredListAnswers,
                    this._NonproliferationSanctionsURL,
                    this._NonproliferationSanctionsAnswers,
                    this._AntiboycotComplianceURL,
                    this._AntiboycotComplianceAnswes,
                    this._AID,
                    this._TSNContact,
                    this._ASIContact,
                    this._EnterByID,
                    this._EnterDate,
                    this._EditByID,
                    this._EditDate,
                    this._CreditParentLink_AID,
                    this._MasterParentLink_AID
                    
                    );

                if (ReturnVal != null)
                    AffectedRows = Convert.ToInt32(ReturnVal.ToString());
              
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return AffectedRows;
        }

        /// <summary>
        /// Update existing record in table Contact_DueDiligence
        /// Fill in all properties of the DueDiligence Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int UpdateDueDiligence()
        {
            int Affected = -1;

            try
            {//  concatination error 23/2/2012
                object[] Params = BuildUpdateQueryParams();
                string st = "";
                foreach (object param in Params)
                    st += param.ToString() + ";";
                Affected = BaseClass.UpdateCommand("DueDiligence_Update", Params);
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return Affected;
        }

        /// <summary>
        /// Update existing record in table Contact_DueDiligence
        /// Fill in all properties of the DueDiligence Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int UpdateDueDiligenceFile()
        {
            int Affected = -1;

            try
            {
                bool IsCredit = this._CreditCheckStatus.Length > 0;
                Affected = BaseClass.UpdateCommand("DueDiligence_Update_File", this._DueDil_ID, IsCredit, 
                    IsCredit? this._CreditCheckStatus: this._MasterPurchaseStatus, 
                    IsCredit? this._CreditCheckFile: this._MasterPurchaseFile,
                    IsCredit ? this._CreditCheckFileName : this._MasterPurchaseFileName,
                    IsCredit ? this._CreditCheckFileSize : this._MasterPurchaseFileSize,
                    this._EditByID, this._EditDate);
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return Affected;
        }

        public List<DueDiligence> GetDueDiligenceByAccID()
        {
            SqlConnection conDueDiligence = new SqlConnection(StrCon);
            List<DueDiligence> DueDiligenceList = new List<DueDiligence>();

            try
            {
                BuildFilter();
                string SortCriteria = BuildSortCriteria();
                SqlDataReader rdrDueDiligence = SqlHelper.ExecuteReader(conDueDiligence, "DueDiligences_GetByAid", this.AID);
                DueDiligence objDueDiligence;

                while (rdrDueDiligence.Read())
                {
                    try
                    {
                        objDueDiligence = new DueDiligence();
                        objDueDiligence.DueDil_ID = int.Parse(rdrDueDiligence["DueDil_ID"].ToString());

                        if (rdrDueDiligence["DeniedPersonsAnswer"] != null && rdrDueDiligence["DeniedPersonsAnswer"].ToString() != "")
                            objDueDiligence.DeniedPersonsAnswer = int.Parse(rdrDueDiligence["DeniedPersonsAnswer"].ToString());
                        else
                            objDueDiligence.DeniedPersonsAnswer = int.MinValue;

                        objDueDiligence.DebarredListURL = rdrDueDiligence["DebarredListURL"].ToString();

                        if (rdrDueDiligence["AID"] != null && rdrDueDiligence["AID"].ToString() != "")
                            objDueDiligence.AID = int.Parse(rdrDueDiligence["AID"].ToString());
                        else
                            objDueDiligence.AID = int.MinValue;
                        if (rdrDueDiligence["CreditCheckFile"] != null && rdrDueDiligence["CreditCheckFile"].ToString() != "")

                        objDueDiligence.CreditCheckFile = (byte[])rdrDueDiligence["CreditCheckFile"];
                        if (rdrDueDiligence["MasterPurchaseFile"] != null && rdrDueDiligence["MasterPurchaseFile"].ToString() != "")
                        objDueDiligence.MasterPurchaseFile = (byte[])rdrDueDiligence["MasterPurchaseFile"];

                        if (rdrDueDiligence["StracturalSoftware"] != null && rdrDueDiligence["StracturalSoftware"].ToString() != "")
                            objDueDiligence.StracturalSoftware = int.Parse(rdrDueDiligence["StracturalSoftware"].ToString());
                        else
                            objDueDiligence.StracturalSoftware = int.MinValue;

                        objDueDiligence.BlockedPersonListURL = rdrDueDiligence["BlockedPersonListURL"].ToString();

                        

                        if (rdrDueDiligence["EntityListAnswer"] != null && rdrDueDiligence["EntityListAnswer"].ToString() != "")
                            objDueDiligence.EntityListAnswer = int.Parse(rdrDueDiligence["EntityListAnswer"].ToString());
                        else
                            objDueDiligence.EntityListAnswer = int.MinValue;

                        objDueDiligence.EntityListUrl = rdrDueDiligence["EntityListUrl"].ToString();

                       

                        if (rdrDueDiligence["ManunfactureCFS"] != null && rdrDueDiligence["ManunfactureCFS"].ToString() != "")
                            objDueDiligence.ManunfactureCFS = int.Parse(rdrDueDiligence["ManunfactureCFS"].ToString());
                        else
                            objDueDiligence.ManunfactureCFS = int.MinValue;

                        objDueDiligence.NonproliferationSanctionsURL = rdrDueDiligence["NonproliferationSanctionsURL"].ToString();

                       

                        objDueDiligence.UnverifiedListURL = rdrDueDiligence["UnverifiedListURL"].ToString();

                        if (rdrDueDiligence["DebarredListAnswers"] != null && rdrDueDiligence["DebarredListAnswers"].ToString() != "")
                            objDueDiligence.DebarredListAnswers = int.Parse(rdrDueDiligence["DebarredListAnswers"].ToString());
                        else
                            objDueDiligence.DebarredListAnswers = int.MinValue;

                        if (rdrDueDiligence["UnverifiedListAnswer"] != null && rdrDueDiligence["UnverifiedListAnswer"].ToString() != "")
                            objDueDiligence.UnverifiedListAnswer = int.Parse(rdrDueDiligence["UnverifiedListAnswer"].ToString());
                        else
                            objDueDiligence.UnverifiedListAnswer = int.MinValue;

                       

                        if (rdrDueDiligence["EditByID"] != null && rdrDueDiligence["EditByID"].ToString() != "")
                            objDueDiligence.EditByID = int.Parse(rdrDueDiligence["EditByID"].ToString());
                        else
                            objDueDiligence.EditByID = int.MinValue;

                        objDueDiligence.CreditCheckStatus = rdrDueDiligence["CreditCheckStatus"].ToString();

                        if (rdrDueDiligence["EditDate"] != null && rdrDueDiligence["EditDate"].ToString() != "")
                            objDueDiligence.EditDate = Convert.ToDateTime(rdrDueDiligence["EditDate"].ToString());
                        else
                            objDueDiligence.EditDate = DateTime.MinValue;

                        if (rdrDueDiligence["EnterByID"] != null && rdrDueDiligence["EnterByID"].ToString() != "")
                            objDueDiligence.EnterByID = int.Parse(rdrDueDiligence["EnterByID"].ToString());
                        else
                            objDueDiligence.EnterByID = int.MinValue;

                        if (rdrDueDiligence["EnterDate"] != null && rdrDueDiligence["EnterDate"].ToString() != "")
                            objDueDiligence.EnterDate = Convert.ToDateTime(rdrDueDiligence["EnterDate"].ToString());
                        else
                            objDueDiligence.EnterDate = DateTime.MinValue;

                        objDueDiligence.MasterPurchaseStatus = rdrDueDiligence["MasterPurchaseStatus"].ToString();



                        if (rdrDueDiligence["BlockedPersonListAnswer"] != null && rdrDueDiligence["BlockedPersonListAnswer"].ToString() != "")
                            objDueDiligence.BlockedPersonListAnswer = int.Parse(rdrDueDiligence["BlockedPersonListAnswer"].ToString());
                        else
                            objDueDiligence.BlockedPersonListAnswer = int.MinValue;

                        if (rdrDueDiligence["OutisdeUSA"] != null && rdrDueDiligence["OutisdeUSA"].ToString() != "")
                            objDueDiligence.OutisdeUSA = Convert.ToBoolean(rdrDueDiligence["OutisdeUSA"]);
                        else
                            objDueDiligence.OutisdeUSA = false;
                        if (rdrDueDiligence["TSNContact"] != null && rdrDueDiligence["TSNContact"].ToString() != "")
                            objDueDiligence.TSNContact = Convert.ToBoolean(rdrDueDiligence["TSNContact"]);
                        else
                            objDueDiligence.TSNContact = false;
                        if (rdrDueDiligence["ASIContact"] != null && rdrDueDiligence["ASIContact"].ToString() != "")
                            objDueDiligence.ASIContact = Convert.ToBoolean(rdrDueDiligence["ASIContact"]);
                        else
                            objDueDiligence.ASIContact = false;
                        
                        objDueDiligence.DeniedPersonsURL = rdrDueDiligence["DeniedPersonsURL"].ToString();
                                                                   
                         if (rdrDueDiligence["NonproliferationSanctionsAnswers"] != null && rdrDueDiligence["NonproliferationSanctionsAnswers"].ToString() != "")
                            objDueDiligence.NonproliferationSanctionsAnswers = int.Parse(rdrDueDiligence["NonproliferationSanctionsAnswers"].ToString());
                        else
                            objDueDiligence.NonproliferationSanctionsAnswers = int.MinValue;

                        objDueDiligence.AntiboycotComplianceURL = rdrDueDiligence["AntiboycotComplianceURL"].ToString();
                        if (rdrDueDiligence["AntiboycotComplianceAnswes"] != null && rdrDueDiligence["AntiboycotComplianceAnswes"].ToString() != "")
                            objDueDiligence.AntiboycotComplianceAnswes = int.Parse(rdrDueDiligence["AntiboycotComplianceAnswes"].ToString());
                        else
                            objDueDiligence.AntiboycotComplianceAnswes = int.MinValue;

                        /////
                        if (rdrDueDiligence["MasterParentLink_AID"] != null && rdrDueDiligence["MasterParentLink_AID"].ToString() != "")
                            objDueDiligence.MasterParentLink_AID = int.Parse(rdrDueDiligence["MasterParentLink_AID"].ToString());
                        else
                            objDueDiligence.MasterParentLink_AID = int.Parse(rdrDueDiligence["AID"].ToString()); 

                        if (rdrDueDiligence["CreditParentLink_AID"] != null && rdrDueDiligence["CreditParentLink_AID"].ToString() != "")
                            objDueDiligence.CreditParentLink_AID = int.Parse(rdrDueDiligence["CreditParentLink_AID"].ToString());
                        else
                            objDueDiligence.CreditParentLink_AID = int.Parse(rdrDueDiligence["AID"].ToString());
                       
                        



                        DueDiligenceList.Add(objDueDiligence);
                    }
                    catch (Exception Ep)
                    {
                        string ErrMsg = Ep.Message;
                        continue;
                    }
                }
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                conDueDiligence.Close();
            }

            return DueDiligenceList;
        }

        public DueDiligence GetSingleDueDiligence()
        {
            SqlConnection conDueDiligence = new SqlConnection(StrCon);
            DueDiligence objDueDiligence = new DueDiligence();

            try
            {
                SqlDataReader rdrDueDiligence = SqlHelper.ExecuteReader(conDueDiligence, "DueDiligences_GetByDueDil_ID", this.DueDil_ID);

                while (rdrDueDiligence.Read())
                {
                    try
                    {
                        objDueDiligence.DueDil_ID = int.Parse(rdrDueDiligence["DueDil_ID"].ToString());

                        if (rdrDueDiligence["DeniedPersonsAnswer"] != null && rdrDueDiligence["DeniedPersonsAnswer"].ToString() != "")
                            objDueDiligence.DeniedPersonsAnswer = int.Parse(rdrDueDiligence["DeniedPersonsAnswer"].ToString());
                        else
                            objDueDiligence.DeniedPersonsAnswer = int.MinValue;

                        objDueDiligence.DebarredListURL = rdrDueDiligence["DebarredListURL"].ToString();

                        if (rdrDueDiligence["AID"] != null && rdrDueDiligence["AID"].ToString() != "")
                            objDueDiligence.AID = int.Parse(rdrDueDiligence["AID"].ToString());
                        else
                            objDueDiligence.AID = int.MinValue;

                        if (rdrDueDiligence["CreditCheckFile"] != null && rdrDueDiligence["CreditCheckFile"].ToString() != "")

                            objDueDiligence.CreditCheckFile = (byte[])rdrDueDiligence["CreditCheckFile"];
                                             

                        if (rdrDueDiligence["MasterPurchaseFile"] != null && rdrDueDiligence["MasterPurchaseFile"].ToString() != "")
                            objDueDiligence.MasterPurchaseFile = (byte[])rdrDueDiligence["MasterPurchaseFile"];

                        // added By Sayed Moawad  15/5/2012
                        if (rdrDueDiligence["CreditCheckFileSize"] != null && rdrDueDiligence["CreditCheckFileSize"].ToString() != "")
                            objDueDiligence.CreditCheckFileSize = rdrDueDiligence["CreditCheckFileSize"].ToString();
                        if (rdrDueDiligence["CreditCheckFileName"] != null && rdrDueDiligence["CreditCheckFileName"].ToString() != "")
                            objDueDiligence.CreditCheckFileName = rdrDueDiligence["CreditCheckFileName"].ToString();
                        if (rdrDueDiligence["CreditCheckStatus"] != null && rdrDueDiligence["CreditCheckStatus"].ToString() != "")
                            objDueDiligence.CreditCheckStatus = rdrDueDiligence["CreditCheckStatus"].ToString();

                        // purchase
                        if (rdrDueDiligence["MasterPurchaseFileSize"] != null && rdrDueDiligence["MasterPurchaseFileSize"].ToString() != "")
                            objDueDiligence.MasterPurchaseFileSize = rdrDueDiligence["MasterPurchaseFileSize"].ToString();
                        if (rdrDueDiligence["MasterPurchaseFileName"] != null && rdrDueDiligence["MasterPurchaseFileName"].ToString() != "")
                            objDueDiligence.MasterPurchaseFileName = rdrDueDiligence["MasterPurchaseFileName"].ToString();
                        if (rdrDueDiligence["MasterPurchaseStatus"] != null && rdrDueDiligence["MasterPurchaseStatus"].ToString() != "")
                            objDueDiligence.MasterPurchaseStatus = rdrDueDiligence["MasterPurchaseStatus"].ToString();

                        // end 15/5/2012


                        if (rdrDueDiligence["StracturalSoftware"] != null && rdrDueDiligence["StracturalSoftware"].ToString() != "")
                            objDueDiligence.StracturalSoftware = int.Parse(rdrDueDiligence["StracturalSoftware"].ToString());
                        else
                            objDueDiligence.StracturalSoftware = int.MinValue;

                        objDueDiligence.BlockedPersonListURL = rdrDueDiligence["BlockedPersonListURL"].ToString();



                        if (rdrDueDiligence["EntityListAnswer"] != null && rdrDueDiligence["EntityListAnswer"].ToString() != "")
                            objDueDiligence.EntityListAnswer = int.Parse(rdrDueDiligence["EntityListAnswer"].ToString());
                        else
                            objDueDiligence.EntityListAnswer = int.MinValue;

                        objDueDiligence.EntityListUrl = rdrDueDiligence["EntityListUrl"].ToString();



                        if (rdrDueDiligence["ManunfactureCFS"] != null && rdrDueDiligence["ManunfactureCFS"].ToString() != "")
                            objDueDiligence.ManunfactureCFS = int.Parse(rdrDueDiligence["ManunfactureCFS"].ToString());
                        else
                            objDueDiligence.ManunfactureCFS = int.MinValue;

                        objDueDiligence.NonproliferationSanctionsURL = rdrDueDiligence["NonproliferationSanctionsURL"].ToString();



                        objDueDiligence.UnverifiedListURL = rdrDueDiligence["UnverifiedListURL"].ToString();

                        if (rdrDueDiligence["DebarredListAnswers"] != null && rdrDueDiligence["DebarredListAnswers"].ToString() != "")
                            objDueDiligence.DebarredListAnswers = int.Parse(rdrDueDiligence["DebarredListAnswers"].ToString());
                        else
                            objDueDiligence.DebarredListAnswers = int.MinValue;

                        if (rdrDueDiligence["UnverifiedListAnswer"] != null && rdrDueDiligence["UnverifiedListAnswer"].ToString() != "")
                            objDueDiligence.UnverifiedListAnswer = int.Parse(rdrDueDiligence["UnverifiedListAnswer"].ToString());
                        else
                            objDueDiligence.UnverifiedListAnswer = int.MinValue;



                        if (rdrDueDiligence["EditByID"] != null && rdrDueDiligence["EditByID"].ToString() != "")
                            objDueDiligence.EditByID = int.Parse(rdrDueDiligence["EditByID"].ToString());
                        else
                            objDueDiligence.EditByID = int.MinValue;

                        objDueDiligence.CreditCheckStatus = rdrDueDiligence["CreditCheckStatus"].ToString();

                        if (rdrDueDiligence["EditDate"] != null && rdrDueDiligence["EditDate"].ToString() != "")
                            objDueDiligence.EditDate = Convert.ToDateTime(rdrDueDiligence["EditDate"].ToString());
                        else
                            objDueDiligence.EditDate = DateTime.MinValue;

                        if (rdrDueDiligence["EnterByID"] != null && rdrDueDiligence["EnterByID"].ToString() != "")
                            objDueDiligence.EnterByID = int.Parse(rdrDueDiligence["EnterByID"].ToString());
                        else
                            objDueDiligence.EnterByID = int.MinValue;

                        if (rdrDueDiligence["EnterDate"] != null && rdrDueDiligence["EnterDate"].ToString() != "")
                            objDueDiligence.EnterDate = Convert.ToDateTime(rdrDueDiligence["EnterDate"].ToString());
                        else
                            objDueDiligence.EnterDate = DateTime.MinValue;

                        objDueDiligence.MasterPurchaseStatus = rdrDueDiligence["MasterPurchaseStatus"].ToString();



                        if (rdrDueDiligence["BlockedPersonListAnswer"] != null && rdrDueDiligence["BlockedPersonListAnswer"].ToString() != "")
                            objDueDiligence.BlockedPersonListAnswer = int.Parse(rdrDueDiligence["BlockedPersonListAnswer"].ToString());
                        else
                            objDueDiligence.BlockedPersonListAnswer = int.MinValue;

                        if (rdrDueDiligence["OutisdeUSA"] != null && rdrDueDiligence["OutisdeUSA"].ToString() != "")
                            objDueDiligence.OutisdeUSA = Convert.ToBoolean(rdrDueDiligence["OutisdeUSA"]);
                        else
                            objDueDiligence.OutisdeUSA = false;
                        if (rdrDueDiligence["TSNContact"] != null && rdrDueDiligence["TSNContact"].ToString() != "")
                            objDueDiligence.TSNContact = Convert.ToBoolean(rdrDueDiligence["TSNContact"]);
                        else
                            objDueDiligence.TSNContact = false;
                        if (rdrDueDiligence["ASIContact"] != null && rdrDueDiligence["ASIContact"].ToString() != "")
                            objDueDiligence.ASIContact = Convert.ToBoolean(rdrDueDiligence["ASIContact"]);
                        else
                            objDueDiligence.ASIContact = false;


                        objDueDiligence.DeniedPersonsURL = rdrDueDiligence["DeniedPersonsURL"].ToString();




                        if (rdrDueDiligence["NonproliferationSanctionsAnswers"] != null && rdrDueDiligence["NonproliferationSanctionsAnswers"].ToString() != "")
                            objDueDiligence.NonproliferationSanctionsAnswers = int.Parse(rdrDueDiligence["NonproliferationSanctionsAnswers"].ToString());
                        else
                            objDueDiligence.NonproliferationSanctionsAnswers = int.MinValue;

                        objDueDiligence.AntiboycotComplianceURL = rdrDueDiligence["AntiboycotComplianceURL"].ToString();
                        if (rdrDueDiligence["AntiboycotComplianceAnswes"] != null && rdrDueDiligence["AntiboycotComplianceAnswes"].ToString() != "")
                            objDueDiligence.AntiboycotComplianceAnswes = int.Parse(rdrDueDiligence["AntiboycotComplianceAnswes"].ToString());
                        else
                            objDueDiligence.AntiboycotComplianceAnswes = int.MinValue;

                        /////
                        if (rdrDueDiligence["MasterParentLink_AID"] != null && rdrDueDiligence["MasterParentLink_AID"].ToString() != "")
                            objDueDiligence.MasterParentLink_AID = int.Parse(rdrDueDiligence["MasterParentLink_AID"].ToString());
                        else
                            objDueDiligence.MasterParentLink_AID = int.MinValue;

                        if (rdrDueDiligence["CreditParentLink_AID"] != null && rdrDueDiligence["CreditParentLink_AID"].ToString() != "")
                            objDueDiligence.CreditParentLink_AID = int.Parse(rdrDueDiligence["CreditParentLink_AID"].ToString());
                        else
                            objDueDiligence.CreditParentLink_AID = int.MinValue;
                      
                        
                    }
                    catch (Exception Ep)
                    {
                        string ErrMsg = Ep.Message;
                        continue;
                    }
                }

            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                conDueDiligence.Close();
            }
            return objDueDiligence;
        }

        public List<DueDiligence> GetDueDiligenceData()
        {
            SqlConnection conDueDiligence = new SqlConnection(StrCon);
            List<DueDiligence> DueDiligenceList = new List<DueDiligence>();

            try
            {
                string TSNContactValue, ASIContactValue, OutisdeUSAValue;
                if (this.TSNContact == null)
                    TSNContactValue = "-1";
                else
                {
                    if (this.TSNContact == true)
                        TSNContactValue = "1";
                    else
                        TSNContactValue = "0";
                }
                if (this.ASIContact == null)
                    ASIContactValue = "-1";
                else
                {
                    if (this.ASIContact == true)
                        ASIContactValue = "1";
                    else
                        ASIContactValue = "0";
                }

                if (this.OutisdeUSA == null)
                    OutisdeUSAValue = "-1";
                else
                {
                    if (this.OutisdeUSA == true)
                        OutisdeUSAValue = "1";
                    else
                        OutisdeUSAValue = "0";
                }

                SqlDataReader rdrDueDiligence = SqlHelper.ExecuteReader(conDueDiligence, "DueDiligencesGetData", this.DueDil_ID, this.StracturalSoftware, this.ManunfactureCFS,this.CreditCheckStatus,this.MasterPurchaseStatus,OutisdeUSAValue,this.AID, TSNContactValue,ASIContactValue);
                DueDiligence objDueDiligence;

                while (rdrDueDiligence.Read())
                {
                    try
                    {
                        objDueDiligence = new DueDiligence();
                        objDueDiligence.DueDil_ID = int.Parse(rdrDueDiligence["DueDil_ID"].ToString());

                        if (rdrDueDiligence["DeniedPersonsAnswer"] != null && rdrDueDiligence["DeniedPersonsAnswer"].ToString() != "")
                            objDueDiligence.DeniedPersonsAnswer = int.Parse(rdrDueDiligence["DeniedPersonsAnswer"].ToString());
                        else
                            objDueDiligence.DeniedPersonsAnswer = int.MinValue;

                        objDueDiligence.DebarredListURL = rdrDueDiligence["DebarredListURL"].ToString();

                        if (rdrDueDiligence["AID"] != null && rdrDueDiligence["AID"].ToString() != "")
                            objDueDiligence.AID = int.Parse(rdrDueDiligence["AID"].ToString());
                        else
                            objDueDiligence.AID = int.MinValue;

                        if (rdrDueDiligence["CreditCheckFile"] != null && rdrDueDiligence["CreditCheckFile"].ToString() != "")

                            objDueDiligence.CreditCheckFile = (byte[])rdrDueDiligence["CreditCheckFile"];
                        if (rdrDueDiligence["MasterPurchaseFile"] != null && rdrDueDiligence["MasterPurchaseFile"].ToString() != "")
                            objDueDiligence.MasterPurchaseFile = (byte[])rdrDueDiligence["MasterPurchaseFile"];


                        if (rdrDueDiligence["StracturalSoftware"] != null && rdrDueDiligence["StracturalSoftware"].ToString() != "")
                            objDueDiligence.StracturalSoftware = int.Parse(rdrDueDiligence["StracturalSoftware"].ToString());
                        else
                            objDueDiligence.StracturalSoftware = int.MinValue;

                        objDueDiligence.BlockedPersonListURL = rdrDueDiligence["BlockedPersonListURL"].ToString();



                        if (rdrDueDiligence["EntityListAnswer"] != null && rdrDueDiligence["EntityListAnswer"].ToString() != "")
                            objDueDiligence.EntityListAnswer = int.Parse(rdrDueDiligence["EntityListAnswer"].ToString());
                        else
                            objDueDiligence.EntityListAnswer = int.MinValue;

                        objDueDiligence.EntityListUrl = rdrDueDiligence["EntityListUrl"].ToString();



                        if (rdrDueDiligence["ManunfactureCFS"] != null && rdrDueDiligence["ManunfactureCFS"].ToString() != "")
                            objDueDiligence.ManunfactureCFS = int.Parse(rdrDueDiligence["ManunfactureCFS"].ToString());
                        else
                            objDueDiligence.ManunfactureCFS = int.MinValue;

                        objDueDiligence.NonproliferationSanctionsURL = rdrDueDiligence["NonproliferationSanctionsURL"].ToString();



                        objDueDiligence.UnverifiedListURL = rdrDueDiligence["UnverifiedListURL"].ToString();

                        if (rdrDueDiligence["DebarredListAnswers"] != null && rdrDueDiligence["DebarredListAnswers"].ToString() != "")
                            objDueDiligence.DebarredListAnswers = int.Parse(rdrDueDiligence["DebarredListAnswers"].ToString());
                        else
                            objDueDiligence.DebarredListAnswers = int.MinValue;

                        if (rdrDueDiligence["UnverifiedListAnswer"] != null && rdrDueDiligence["UnverifiedListAnswer"].ToString() != "")
                            objDueDiligence.UnverifiedListAnswer = int.Parse(rdrDueDiligence["UnverifiedListAnswer"].ToString());
                        else
                            objDueDiligence.UnverifiedListAnswer = int.MinValue;



                        if (rdrDueDiligence["EditByID"] != null && rdrDueDiligence["EditByID"].ToString() != "")
                            objDueDiligence.EditByID = int.Parse(rdrDueDiligence["EditByID"].ToString());
                        else
                            objDueDiligence.EditByID = int.MinValue;

                        objDueDiligence.CreditCheckStatus = rdrDueDiligence["CreditCheckStatus"].ToString();

                        if (rdrDueDiligence["EditDate"] != null && rdrDueDiligence["EditDate"].ToString() != "")
                            objDueDiligence.EditDate = Convert.ToDateTime(rdrDueDiligence["EditDate"].ToString());
                        else
                            objDueDiligence.EditDate = DateTime.MinValue;

                        if (rdrDueDiligence["EnterByID"] != null && rdrDueDiligence["EnterByID"].ToString() != "")
                            objDueDiligence.EnterByID = int.Parse(rdrDueDiligence["EnterByID"].ToString());
                        else
                            objDueDiligence.EnterByID = int.MinValue;

                        if (rdrDueDiligence["EnterDate"] != null && rdrDueDiligence["EnterDate"].ToString() != "")
                            objDueDiligence.EnterDate = Convert.ToDateTime(rdrDueDiligence["EnterDate"].ToString());
                        else
                            objDueDiligence.EnterDate = DateTime.MinValue;

                        objDueDiligence.MasterPurchaseStatus = rdrDueDiligence["MasterPurchaseStatus"].ToString();



                        if (rdrDueDiligence["BlockedPersonListAnswer"] != null && rdrDueDiligence["BlockedPersonListAnswer"].ToString() != "")
                            objDueDiligence.BlockedPersonListAnswer = int.Parse(rdrDueDiligence["BlockedPersonListAnswer"].ToString());
                        else
                            objDueDiligence.BlockedPersonListAnswer = int.MinValue;

                        if (rdrDueDiligence["OutisdeUSA"] != null && rdrDueDiligence["OutisdeUSA"].ToString() != "")
                            objDueDiligence.OutisdeUSA = Convert.ToBoolean(rdrDueDiligence["OutisdeUSA"]);
                        else
                            objDueDiligence.OutisdeUSA = false;
                        if (rdrDueDiligence["TSNContact"] != null && rdrDueDiligence["TSNContact"].ToString() != "")
                            objDueDiligence.TSNContact = Convert.ToBoolean(rdrDueDiligence["TSNContact"]);
                        else
                            objDueDiligence.TSNContact = false;
                        if (rdrDueDiligence["ASIContact"] != null && rdrDueDiligence["ASIContact"].ToString() != "")
                            objDueDiligence.ASIContact = Convert.ToBoolean(rdrDueDiligence["ASIContact"]);
                        else
                            objDueDiligence.ASIContact = false;


                        objDueDiligence.DeniedPersonsURL = rdrDueDiligence["DeniedPersonsURL"].ToString();




                        if (rdrDueDiligence["NonproliferationSanctionsAnswers"] != null && rdrDueDiligence["NonproliferationSanctionsAnswers"].ToString() != "")
                            objDueDiligence.NonproliferationSanctionsAnswers = int.Parse(rdrDueDiligence["NonproliferationSanctionsAnswers"].ToString());
                        else
                            objDueDiligence.NonproliferationSanctionsAnswers = int.MinValue;

                        objDueDiligence.AntiboycotComplianceURL = rdrDueDiligence["AntiboycotComplianceURL"].ToString();
                        if (rdrDueDiligence["AntiboycotComplianceAnswes"] != null && rdrDueDiligence["AntiboycotComplianceAnswes"].ToString() != "")
                            objDueDiligence.AntiboycotComplianceAnswes = int.Parse(rdrDueDiligence["AntiboycotComplianceAnswes"].ToString());
                        else
                            objDueDiligence.AntiboycotComplianceAnswes = int.MinValue;

                        /////
                        if (rdrDueDiligence["MasterParentLink_AID"] != null && rdrDueDiligence["MasterParentLink_AID"].ToString() != "")
                            objDueDiligence.MasterParentLink_AID = int.Parse(rdrDueDiligence["MasterParentLink_AID"].ToString());
                        else
                            objDueDiligence.MasterParentLink_AID = int.MinValue;

                        if (rdrDueDiligence["CreditParentLink_AID"] != null && rdrDueDiligence["CreditParentLink_AID"].ToString() != "")
                            objDueDiligence.CreditParentLink_AID = int.Parse(rdrDueDiligence["CreditParentLink_AID"].ToString());
                        else
                            objDueDiligence.CreditParentLink_AID = int.MinValue;
                       
                                              
                        DueDiligenceList.Add(objDueDiligence);
                    }
                    catch (Exception Ep)
                    {
                        string ErrMsg = Ep.Message;
                        continue;
                    }
                }

            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                conDueDiligence.Close();
            }
            return DueDiligenceList;
        }

       
        /// <summary>
        /// Delete existing record in table Contact_DueDiligence
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public string DeleteDueDiligence()
        {
            object Affected = "-1";
            try
            {
                object[] Params = { _DueDil_ID, 0 };
                Affected = BaseClass.ReturnValueCommand("DueDiligence_Delete", Params);
            }
            catch (Exception Exp)
            {
                return Exp.Message;
            }
            return Affected.ToString();
        }

        /// <summary>
        /// Get contact page no. in grid
        /// </summary>
        /// <returns>integer value to indicates number of this contact order</returns>
        public int GetDueDiligenceOrder()// NOT IMPLEMENTED
        {
            int result = -1;

            try
            {
                string pref = "";
                switch (this._SortExpression)
                {
                    case SortBy.AID:
                        pref = "-1";
                        break;
                    case SortBy.DueDil_ID:
                        pref = "-1";
                        break;
                   
                    default:
                        break;
                }

                result = Convert.ToInt32(BaseClass.ReturnValueCommand("SP_Get_DueDiligence_Order", this._AID.Value, this._AntiboycotComplianceAnswes.Value.ToString(), this._SortExpression.ToString(), pref, 0));
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }

            return result;
        }


        #endregion

        #region -----------------Private Functions----------------
        private object[] BuildUpdateQueryParams()
        {
            object[] UpdateParameters = new object[27];
            UpdateParameters[0] = this.DueDil_ID.ToString();

            if (this.StracturalSoftware == null)
                UpdateParameters[1] = "-1";
            else
                UpdateParameters[1] = this.StracturalSoftware.ToString();

            if (this.ManunfactureCFS == null)
                UpdateParameters[2] = "-1";
            else
                UpdateParameters[2] = this.ManunfactureCFS.ToString();

            if (this.CreditCheckStatus == null)
                UpdateParameters[3] = "-1";
            else
                UpdateParameters[3] = this.CreditCheckStatus.ToString();

            //if (this.CreditCheckFile == null)
            //    UpdateParameters[4] = "-1";
            //else
            //    UpdateParameters[4] = this.CreditCheckFile.ToString();


            if (this.MasterPurchaseStatus == null)
                UpdateParameters[4] = "-1";
            else
                UpdateParameters[4] = this.MasterPurchaseStatus.ToString();

            //if (this.MasterPurchaseFile == null)
            //    UpdateParameters[6] = "-1";
            //else
            //    UpdateParameters[6] = this.MasterPurchaseFile.ToString();


            if (this.OutisdeUSA == null)
                UpdateParameters[5] = "-1";
            else
            {
                if (this.OutisdeUSA.Value == true)
                    UpdateParameters[5] = "1";
                else
                    UpdateParameters[5] = "0";
            }
            if (this.EntityListUrl == null)
                UpdateParameters[6] = "-1";
            else
                UpdateParameters[6] = this.EntityListUrl.ToString();
            if (this.EntityListAnswer == null)
                UpdateParameters[7] = "-1";
            else
                UpdateParameters[7] = this.EntityListAnswer.ToString();

            if (this.BlockedPersonListURL == null)
                UpdateParameters[8] = "-1";
            else
                UpdateParameters[8] = this.BlockedPersonListURL.ToString();

            if (this.BlockedPersonListAnswer == null)
                UpdateParameters[9] = "-1";
            else
                UpdateParameters[9] = this.BlockedPersonListAnswer.ToString();

            if (this.UnverifiedListURL == null)
                UpdateParameters[10] = "-1";
            else
                UpdateParameters[10] = this.UnverifiedListURL.ToString();
            //
            if (this.UnverifiedListAnswer == null)
                UpdateParameters[11] = "-1";
            else
                UpdateParameters[11] = this.UnverifiedListAnswer.ToString();

            if (this.DeniedPersonsURL == null)
                UpdateParameters[12] = "-1";
            else
                UpdateParameters[12] = this.DeniedPersonsURL.ToString();
            
            if (this.DeniedPersonsAnswer == null)
                UpdateParameters[13] = "-1";
            else
                UpdateParameters[13] = this.DeniedPersonsAnswer.ToString();

            if (this.DebarredListURL == null)
                UpdateParameters[14] = "-1";
            else
                UpdateParameters[14] = this.DebarredListURL.ToString();

            if (this.DebarredListAnswers == null)
                UpdateParameters[15] = "-1";
            else
                UpdateParameters[15] = DebarredListAnswers.ToString();
            
            if (this.NonproliferationSanctionsURL == null)
                UpdateParameters[16] = "-1";
            else
                UpdateParameters[16] = this.NonproliferationSanctionsURL.ToString();

            if (this.NonproliferationSanctionsAnswers == null)
                UpdateParameters[17] = "-1";
            else
                UpdateParameters[17] = this.NonproliferationSanctionsAnswers.ToString();

            if (this.AntiboycotComplianceURL == null)
                UpdateParameters[18] = "-1";
            else
                UpdateParameters[18] = AntiboycotComplianceURL.ToString();

            if (this.AntiboycotComplianceAnswes == null)
                UpdateParameters[19] = "-1";
            else
                UpdateParameters[19] = this.AntiboycotComplianceAnswes.ToString();

            if (this.AID == null)
                UpdateParameters[20] = "-1";
            else
                UpdateParameters[20] = AID.ToString();


            if (this.TSNContact == null)
                UpdateParameters[21] = "-1";
            else
            {
                if (this.TSNContact.Value == true)
                    UpdateParameters[21] = "1";
                else
                    UpdateParameters[21] = "0";
            }
            if (this.ASIContact == null)
                UpdateParameters[22] = "-1";
            else
            {
                if (this.ASIContact.Value == true)
                    UpdateParameters[22] = "1";
                else
                    UpdateParameters[22] = "0";
            }



            //if (this.EnterByID == null)
            //    UpdateParameters[25] = "-1";
            //else
            //    UpdateParameters[25] = this.EnterByID.ToString();

            //if (this.EnterDate == null)
            //    UpdateParameters[26] = "-1";
            //else
            //    UpdateParameters[26] = this.EnterDate.ToString();

            if (this.EditByID == null)
                UpdateParameters[23] = "-1";
            else
                UpdateParameters[23] = this.EditByID.ToString();

            if (this.EditDate == null)
                UpdateParameters[24] = "-1";
            else
                UpdateParameters[24] = this.EditDate.ToString();

            if (this.CreditParentLink_AID == null)
                UpdateParameters[25] = "-1";
            else
                UpdateParameters[25] = this.CreditParentLink_AID.ToString();
     
            if (this.MasterParentLink_AID == null)
                UpdateParameters[26] = "-1";
            else
                UpdateParameters[26] = this.MasterParentLink_AID.ToString();





            return UpdateParameters;
        }

        private object[] BuildUpdateQueryParamsOld()
        {
            object[] UpdateParameters = new object[25];
            UpdateParameters[0] = this.DueDil_ID.ToString();

            if (this.StracturalSoftware == null)
                UpdateParameters[1] = "0";
            else
                UpdateParameters[1] = this.StracturalSoftware;

            if (this.ManunfactureCFS == null)
                UpdateParameters[2] = "0";
            else
                UpdateParameters[2] = this.ManunfactureCFS.ToString();

            if (this.CreditCheckStatus == null)
                UpdateParameters[3] = "";
            else
                UpdateParameters[3] = this.CreditCheckStatus.ToString();

            //if (this.CreditCheckFile == null)
            //    UpdateParameters[4] = "-1";
            //else
            //    UpdateParameters[4] = this.CreditCheckFile.ToString();


            if (this.MasterPurchaseStatus == null)
                UpdateParameters[4] = "";
            else
                UpdateParameters[4] = this.MasterPurchaseStatus.ToString();

            //if (this.MasterPurchaseFile == null)
            //    UpdateParameters[6] = "-1";
            //else
            //    UpdateParameters[6] = this.MasterPurchaseFile.ToString();
           

            if (this.OutisdeUSA == null)
                UpdateParameters[5] = false;
            else
            {
                if (this.OutisdeUSA.Value == true)
                    UpdateParameters[5] =true;
                else
                    UpdateParameters[5] = false;
            }
            if (this.EntityListUrl == null)
                UpdateParameters[6] = "";
            else
                UpdateParameters[6] = this.EntityListUrl.ToString();
            if (this.EntityListAnswer == null)
                UpdateParameters[7] = "0";
            else
                UpdateParameters[7] = this.EntityListAnswer.ToString();

            if (this.BlockedPersonListURL == null)
                UpdateParameters[8] = "";
            else
                UpdateParameters[8] = this.BlockedPersonListURL.ToString();

            if (this.BlockedPersonListAnswer == null)
                UpdateParameters[9] = "0";
            else
                UpdateParameters[9] = this.BlockedPersonListAnswer.ToString();

            if (this.UnverifiedListURL == null)
                UpdateParameters[10] = "";
            else
                UpdateParameters[10] = this.UnverifiedListURL.ToString();
            //
            if (this.UnverifiedListAnswer == null)
                UpdateParameters[11] = "0";
            else
                UpdateParameters[11] = this.UnverifiedListAnswer.ToString();



            if (this.DeniedPersonsURL == null)
                UpdateParameters[12] = "";
            else
                UpdateParameters[12] = this.DeniedPersonsURL.ToString();



            if (this.DeniedPersonsAnswer == null)
                UpdateParameters[13] = "0";
            else
                UpdateParameters[13] = this.DeniedPersonsAnswer.ToString();

            if (this.DebarredListURL == null)
                UpdateParameters[14] = "";
            else
                UpdateParameters[14] = this.DebarredListURL.ToString();

            if (this.DebarredListAnswers == null)
                UpdateParameters[15] = "0";
            else
                UpdateParameters[15] = DebarredListAnswers.ToString();


            if (this.NonproliferationSanctionsURL == null)
                UpdateParameters[16] = "";
            else
                UpdateParameters[16] = this.NonproliferationSanctionsURL.ToString();

            if (this.NonproliferationSanctionsAnswers == null)
                UpdateParameters[17] = "0";
            else
                UpdateParameters[17] = this.NonproliferationSanctionsAnswers.ToString();

            if (this.AntiboycotComplianceURL == null)
                UpdateParameters[18] = "";
            else
                UpdateParameters[18] = AntiboycotComplianceURL.ToString();

            if (this.AntiboycotComplianceAnswes == null)
                UpdateParameters[19] = "0";
            else
                UpdateParameters[19] = this.AntiboycotComplianceAnswes.ToString();

            if (this.AID == null)
                UpdateParameters[20] = "-1";
            else
                UpdateParameters[20] = AID.ToString();


            if (this.TSNContact == null)
                UpdateParameters[21] = false;
            else
            {
                if (this.TSNContact.Value == true)
                    UpdateParameters[21] = true;
                else
                    UpdateParameters[21] = false;
            }
            if (this.ASIContact == null)
                UpdateParameters[22] = false;
            else
            {
                if (this.ASIContact.Value == true)
                    UpdateParameters[22] = true;
                else
                    UpdateParameters[22] = false;
            }



            //if (this.EnterByID == null)
            //    UpdateParameters[25] = "-1";
            //else
            //    UpdateParameters[25] = this.EnterByID.ToString();

            //if (this.EnterDate == null)
            //    UpdateParameters[26] = "-1";
            //else
            //    UpdateParameters[26] = this.EnterDate.ToString();

            if (this.EditByID == null)
                UpdateParameters[23] = "-1";
            else
                UpdateParameters[23] = this.EditByID.ToString();

            if (this.EditDate == null)
                UpdateParameters[24] = DateTime.Now.ToString();
            else
                UpdateParameters[24] = this.EditDate.ToString();





            return UpdateParameters;
        }

        private void BuildFilter()
        {
            if (this.DueDil_ID == null)
                this.DueDil_ID = -1;   
            if (this.AID == null)
                this.AID = -1;
            if (this.StracturalSoftware == null)
                this.StracturalSoftware = -1;
            if (this.ManunfactureCFS == null)
                this.ManunfactureCFS = -1;
             //this.StracturalSoftware, this.ManunfactureCFS,this.CreditCheckStatus,this.MasterPurchaseStatus,this.OutisdeUSA,this.AID, this.TSNContact,this.ASIContact
            if (this.CreditCheckStatus == null)
                this.CreditCheckStatus = "-1";
         

           


           
        }

        private string BuildSortCriteria()
        {
            string SortCriteria = "-1";

            if (this.SortExpression == SortBy.AID)
                SortCriteria = "Contact_DueDiligance.AID";
            if (this.SortExpression == SortBy.DueDil_ID)
                SortCriteria = "Contact_DueDiligance.DueDil_ID";
           
            if (this.SortDirect == SortDirection.Ascending)
                SortCriteria += " ASC";
            if (this.SortDirect == SortDirection.Descending)
                SortCriteria += " Desc";

            return SortCriteria;
        }
        #endregion
    }
}