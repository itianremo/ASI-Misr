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

namespace Office.DAL
{
    [Serializable]
    public class KeySoftware
    {
        #region -----------------Constructor---------------------

        public KeySoftware()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region -------------------- Properties -------------------

        public enum SortBy
        {
            SID,
            Software,
            Version
            
        }

        public enum SearchBy
        {
            Software,
            Version
        }

        public int? SID
        {
            get { return _SID; }
            set { _SID = value; }
        }

        public string Software
        {
            get { return _Software; }
            set { _Software = value; }
        }

        public DateTime? IssueDate
        {
            get { return _IssueDate; }
            set { _IssueDate = value; }
        }

        public DateTime? ExpireDate
        {
            get { return _ExpireDate; }
            set { _ExpireDate = value; }
        }

        public string Version
        {
            get { return _Version; }
            set { _Version = value; }
        }
        public string Build
        {
            get { return _Build; }
            set { _Build = value; }
        }

        public bool HardwareKey
        {
            get { return _HardwareKey; }
            set { _HardwareKey = value; }
        }
        public bool VMWare
        {
            get { return _VMWare; }
            set { _VMWare = value; }
        }

        public bool LicenseServer
        {
            get { return _LicenseServer; }
            set { _LicenseServer = value; }
        }
        public int? KeySuppliedID
        {
            get { return _KeySuppliedID; }
            set { _KeySuppliedID = value; }
        }
        public int? ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; }
        }
        public int? CompanyID
        {
            get { return _CompanyID; }
            set { _CompanyID = value; }
        }
        public int? BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }

        public string ServiceBack
        {
            get { return _ServiceBack; }
            set { _ServiceBack = value; }
        }

        public string LicenseCode
        {
            get { return _LicenseCode; }
            set { _LicenseCode = value; }
        }
        public string LicenseKey
        {
            get { return _LicenseKey; }
            set { _LicenseKey = value; }
        }
        public string MachineCode
        {
            get { return _MachineCode; }
            set { _MachineCode = value; }
        }
        public string FileVersion
        {
            get { return _FileVersion; }
            set { _FileVersion = value; }
        }
        public string KeyNote
        {
            get { return _KeyNote; }
            set { _KeyNote = value; }

        }
        public string KeyOption
        {
            get { return _KeyOption; }
            set { _KeyOption = value; }
        }

        public string LicenseType
        {
            get { return _LicenseType; }
            set { _LicenseType = value; }
        }
        public string LicensePeriod
        {
            get { return _LicensePeriod; }
            set { _LicensePeriod = value; }
        }
        public string Approvedby
        {
            get { return _Approvedby; }
            set { _Approvedby = value; }
        }

        public string MethodofPayment
        {
            get { return _MethodofPayment; }
            set { _MethodofPayment = value; }
        }
        //public string Build
        //{
        //    get { return _Build; }
        //    set { _Build = value; }
        //}

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

        public string EditByName
        {
            get { return _EditByName; }
            set { _EditByName = value; }
        }

        public string EnteredByName
        {
            get { return _EnteredByName; }
            set { _EnteredByName = value; }
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

        private int? _EnterByID;
        private DateTime? _EnterDate;
        private int? _EditByID;
        private DateTime? _EditDate;
        private DateTime? _ExpireDate;
        private DateTime? _IssueDate;
        private string _EditByName;
        private string _EnteredByName;
        private bool _HardwareKey;
        private bool _VMWare;
        private bool _LicenseServer;
        private int? _SID;
        private int? _KeySuppliedID;
        private int? _ContactID;
        private int? _CompanyID;
        private int? _BranchID;
        private string _Software;
       // private DateTime? _IssueDate;
        private string _Version;
        private string _ServiceBack;
        private string _LicenseCode;
        private string _LicenseKey;
        private string _MachineCode;
        private string _FileVersion;
        private string _KeyNote;
        private string  _KeyOption;
        private string _LicenseType;
        private string  _LicensePeriod;
        private string  _Approvedby;
        private string _MethodofPayment;
        private string _Build;
        private SortBy _SortExpression;
        private SortDirection _SortDirect;
        string StrCon = ConfigurationManager.ConnectionStrings["ASI-CRMConnectionString"].ToString();

        #endregion

        #region -----------------General Functions----------------

        /// <summary>
        /// Insert new record into table EmailkeySW
        /// Fill in all properties of the EmailkeySW Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int AddNewKeySoftWare()
        {
            int AffectedRows = -1;
            try
            {
                if (this._HardwareKey == null)
                    this.HardwareKey = false;
                if (this._VMWare == null)
                    this.VMWare = false;
                if (this._LicenseServer == null)
                    this.LicenseServer = false;


                object objKeyID = SqlHelper.ExecuteNonQuery(StrCon, "Key_Software_Insert", this._Software, this._IssueDate, this._Version, this._Build, this._ServiceBack, this._LicenseCode, this._LicenseKey, this._MachineCode, this._HardwareKey, this._VMWare, this._KeySuppliedID, this._LicenseServer, this._FileVersion, this._ContactID, this._CompanyID, this._BranchID, this._ExpireDate, this._EnterByID, this._EnterDate, this._EditByID, this._EditDate, this._KeyNote, this._KeyOption, this._LicenseType, this._LicensePeriod, this._Approvedby, this._MethodofPayment);
                if (objKeyID != null)
                    AffectedRows = int.Parse(objKeyID.ToString());
               
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return AffectedRows;
        }

        /// <summary>
        /// Update existing record in table key
        /// Fill in all properties of the key Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int UpdateKeySoftWare()
        {
            int Affected = -1;

            try
            {
                object[] Params = BuildUpdateQueryParams();
                string st = "";
                foreach (object param in Params)
                    st += param.ToString() + ";";
                Affected = BaseClass.UpdateCommand("EmailkeySW_Update", Params);
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return Affected;
        }

        public List<KeySoftware> GetKeySoftWare()
        {
            SqlConnection conkeySW = new SqlConnection(StrCon);
            List<KeySoftware> keySWList = new List<KeySoftware>();

            try
            {
                BuildFilter();
                string SortCriteria = BuildSortCriteria();
                SqlDataReader rdrkeySW;
                if (this.ContactID == null && this.CompanyID > 0)
                    rdrkeySW = SqlHelper.ExecuteReader(conkeySW, "KeySoftWare_GetKeySoftwareByCompanyID", this.CompanyID);
                else if (ContactID > 0)
                    rdrkeySW = SqlHelper.ExecuteReader(conkeySW, "KeySoftWare_GetKeySoftwareByContactID", this.ContactID);
                  
                else if(BranchID>0)
                    rdrkeySW = SqlHelper.ExecuteReader(conkeySW, "KeySoftWare_GetKeySoftwareByBranchID", this.BranchID);

                else
                    rdrkeySW = SqlHelper.ExecuteReader(conkeySW, "KeySoftWare_GetKeySoftwareByCompanyID", 0);

                KeySoftware keySW;
                while (rdrkeySW.Read())
                {
                    try
                    {
                        keySW = new KeySoftware();
                        keySW.SID = int.Parse(rdrkeySW["SID"].ToString());

                          if (rdrkeySW["SID"] != null && rdrkeySW["SID"].ToString() != "")
                            keySW.SID = int.Parse(rdrkeySW["SID"].ToString());
                        else
                            keySW.SID = int.MinValue;

                          if (rdrkeySW["ContactID"] != null && rdrkeySW["ContactID"].ToString() != "")
                              keySW.ContactID = int.Parse(rdrkeySW["ContactID"].ToString());
                          else
                              keySW.ContactID = int.MinValue;

                          if (rdrkeySW["CompanyID"] != null && rdrkeySW["CompanyID"].ToString() != "")
                              keySW.CompanyID = int.Parse(rdrkeySW["CompanyID"].ToString());
                          else
                              keySW.CompanyID = int.MinValue;

                          if (rdrkeySW["KeySuppliedID"] != null && rdrkeySW["KeySuppliedID"].ToString() != "")
                            keySW.KeySuppliedID = int.Parse(rdrkeySW["KeySuppliedID"].ToString());
                          else
                            keySW.KeySuppliedID = int.MinValue;
                        

                          keySW.Software = rdrkeySW["Software"].ToString();
                          keySW.Build = rdrkeySW["Build"].ToString();
                          keySW.Version = rdrkeySW["Version"].ToString();
                          keySW.ServiceBack = rdrkeySW["ServiceBack"].ToString();
                          keySW.LicenseCode = rdrkeySW["LicenseCode"].ToString();
                          keySW.LicenseKey = rdrkeySW["LicenseKey"].ToString();
                          keySW.MachineCode = rdrkeySW["MachineCode"].ToString();
                          keySW.FileVersion = rdrkeySW["FileVersion"].ToString();
                          keySW.KeyNote = rdrkeySW["KeyNote"].ToString();
                          keySW.KeyOption = rdrkeySW["KeyOption"].ToString();
                          keySW.LicenseType = rdrkeySW["LicenseType"].ToString();
                          keySW.LicensePeriod = rdrkeySW["LicensePeriod"].ToString();
                          keySW.Approvedby = rdrkeySW["Approvedby"].ToString();
                          keySW.MethodofPayment = rdrkeySW["MethodofPayment"].ToString();
                         

                        if (rdrkeySW["HardwareKey"] != null && rdrkeySW["HardwareKey"].ToString() != "")
                            keySW.HardwareKey = Convert.ToBoolean(rdrkeySW["HardwareKey"]);
                        else
                            keySW.HardwareKey = false;

                        if (rdrkeySW["VMWare"] != null && rdrkeySW["VMWare"].ToString() != "")
                            keySW.VMWare = Convert.ToBoolean(rdrkeySW["VMWare"]);
                        else
                             keySW.VMWare = false;

                        

                        if (rdrkeySW["IssueDate"] != null && rdrkeySW["IssueDate"].ToString() != "")
                            keySW.IssueDate = Convert.ToDateTime(rdrkeySW["IssueDate"].ToString());
                        else
                            keySW.IssueDate = DateTime.MinValue;

                        if (rdrkeySW["ExpireDate"] != null && rdrkeySW["ExpireDate"].ToString() != "")
                            keySW.ExpireDate = Convert.ToDateTime(rdrkeySW["ExpireDate"].ToString());
                        else
                            keySW.ExpireDate = DateTime.MinValue;
                       

                        if (rdrkeySW["EditBy"] != null && rdrkeySW["EditBy"].ToString() != "")
                            keySW.EditByID = int.Parse(rdrkeySW["EditBy"].ToString());
                        else
                            keySW.EditByID = int.MinValue;

                       

                        if (rdrkeySW["EditDate"] != null && rdrkeySW["EditDate"].ToString() != "")
                            keySW.EditDate = Convert.ToDateTime(rdrkeySW["EditDate"].ToString());
                        else
                            keySW.EditDate = DateTime.MinValue;

                        if (rdrkeySW["EnterBy"] != null && rdrkeySW["EnterBy"].ToString() != "")
                            keySW.EnterByID = int.Parse(rdrkeySW["EnterBy"].ToString());
                        else
                            keySW.EnterByID = int.MinValue;

                        if (rdrkeySW["EnterDate"] != null && rdrkeySW["EnterDate"].ToString() != "")
                            keySW.EnterDate = Convert.ToDateTime(rdrkeySW["EnterDate"].ToString());
                        else
                            keySW.EnterDate = DateTime.MinValue;

                        //keySW.EnteredByName = rdrkeySW["EnteredByName"].ToString();
                        //keySW.EditByName = rdrkeySW["EditByName"].ToString();

                       

                                          

                        

                        keySWList.Add(keySW);
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
                conkeySW.Close();
            }

            return keySWList;
        }

        public KeySoftware GetSingleKeySoftWare()
        {
            SqlConnection conkeySW = new SqlConnection(StrCon);
            KeySoftware keySW = new KeySoftware();

            try
            {
                SqlDataReader rdrkeySW = SqlHelper.ExecuteReader(conkeySW, "EmailkeySW_GetBySID", this.SID);

                while (rdrkeySW.Read())
                {
                    try
                    {
                        keySW.SID = int.Parse(rdrkeySW["SID"].ToString());

                        if (rdrkeySW["SID"] != null && rdrkeySW["SID"].ToString() != "")
                            keySW.SID = int.Parse(rdrkeySW["SID"].ToString());
                        else
                            keySW.SID = int.MinValue;

                        if (rdrkeySW["ContactID"] != null && rdrkeySW["ContactID"].ToString() != "")
                            keySW.ContactID = int.Parse(rdrkeySW["ContactID"].ToString());
                        else
                            keySW.ContactID = int.MinValue;

                        if (rdrkeySW["CompanyID"] != null && rdrkeySW["CompanyID"].ToString() != "")
                            keySW.CompanyID = int.Parse(rdrkeySW["CompanyID"].ToString());
                        else
                            keySW.CompanyID = int.MinValue;

                        if (rdrkeySW["BranchID"] != null && rdrkeySW["BranchID"].ToString() != "")
                            keySW.BranchID = int.Parse(rdrkeySW["BranchID"].ToString());
                        else
                            keySW.BranchID = int.MinValue;

                        if (rdrkeySW["KeySuppliedID"] != null && rdrkeySW["KeySuppliedID"].ToString() != "")
                            keySW.KeySuppliedID = int.Parse(rdrkeySW["KeySuppliedID"].ToString());
                        else
                            keySW.KeySuppliedID = int.MinValue;


                        keySW.Software = rdrkeySW["Software"].ToString();
                        keySW.Build = rdrkeySW["Build"].ToString();
                        keySW.Version = rdrkeySW["Version"].ToString();
                        keySW.ServiceBack = rdrkeySW["ServiceBack"].ToString();
                        keySW.LicenseCode = rdrkeySW["LicenseCode"].ToString();
                        keySW.LicenseKey = rdrkeySW["LicenseKey"].ToString();
                        keySW.MachineCode = rdrkeySW["MachineCode"].ToString();
                        keySW.FileVersion = rdrkeySW["FileVersion"].ToString();
                        keySW.KeyNote = rdrkeySW["KeyNote"].ToString();
                        keySW.KeyOption = rdrkeySW["KeyOption"].ToString();
                        keySW.LicenseType = rdrkeySW["LicenseType"].ToString();
                        keySW.LicensePeriod = rdrkeySW["LicensePeriod"].ToString();
                        keySW.Approvedby = rdrkeySW["Approvedby"].ToString();
                        keySW.MethodofPayment = rdrkeySW["MethodofPayment"].ToString();


                        if (rdrkeySW["HardwareKey"] != null && rdrkeySW["HardwareKey"].ToString() != "")
                            keySW.HardwareKey = Convert.ToBoolean(rdrkeySW["HardwareKey"]);
                        else
                            keySW.HardwareKey = false;

                        if (rdrkeySW["VMWare"] != null && rdrkeySW["VMWare"].ToString() != "")
                            keySW.VMWare = Convert.ToBoolean(rdrkeySW["VMWare"]);
                        else
                            keySW.VMWare = false;



                        if (rdrkeySW["IssueDate"] != null && rdrkeySW["IssueDate"].ToString() != "")
                            keySW.IssueDate = Convert.ToDateTime(rdrkeySW["IssueDate"].ToString());
                        else
                            keySW.IssueDate = DateTime.MinValue;

                        if (rdrkeySW["ExpireDate"] != null && rdrkeySW["ExpireDate"].ToString() != "")
                            keySW.ExpireDate = Convert.ToDateTime(rdrkeySW["ExpireDate"].ToString());
                        else
                            keySW.ExpireDate = DateTime.MinValue;


                        if (rdrkeySW["EditBy"] != null && rdrkeySW["EditBy"].ToString() != "")
                            keySW.EditByID = int.Parse(rdrkeySW["EditBy"].ToString());
                        else
                            keySW.EditByID = int.MinValue;



                        if (rdrkeySW["EditDate"] != null && rdrkeySW["EditDate"].ToString() != "")
                            keySW.EditDate = Convert.ToDateTime(rdrkeySW["EditDate"].ToString());
                        else
                            keySW.EditDate = DateTime.MinValue;

                        if (rdrkeySW["EnterBy"] != null && rdrkeySW["EnterBy"].ToString() != "")
                            keySW.EnterByID = int.Parse(rdrkeySW["EnterBy"].ToString());
                        else
                            keySW.EnterByID = int.MinValue;

                        if (rdrkeySW["EnterDate"] != null && rdrkeySW["EnterDate"].ToString() != "")
                            keySW.EnterDate = Convert.ToDateTime(rdrkeySW["EnterDate"].ToString());
                        else
                            keySW.EnterDate = DateTime.MinValue;

                        //keySW.EnteredByName = rdrkeySW["EnteredByName"].ToString();
                        //keySW.EditByName = rdrkeySW["EditByName"].ToString();


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
                conkeySW.Close();
            }
            return keySW;
        }

    

       
        /// <summary>
        /// Delete existing record in table key_Software
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public string DeleteKeySoftWare()
        {
            object Affected = "-1";
            try
            {
                object[] Params = { _SID};
                Affected = BaseClass.ReturnValueCommand("keySW_Delete", Params);
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
        /// <returns>integer value to indicates number of this keySW order</returns>
        public int GetKeySoftWareOrder()
        {
            int result = -1;

            try
            {
                result = (int)BaseClass.ReturnValueCommand("SP_Get_keySW_Order", this._SID, 0);
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
            object[] UpdateParameters = new object[7];
            UpdateParameters[0] = this.SID.ToString();

            if (this.Software == null)
                UpdateParameters[1] = "-1";
            else
                UpdateParameters[1] = this.Software;
            if (this.Build == null)
                UpdateParameters[2] = "-1";
            else
                UpdateParameters[2] = this.Build;
            if (this.Version == null)
                UpdateParameters[3] = "-1";
            else
                UpdateParameters[3] = this.Version;

            if (this.HardwareKey == null)
                UpdateParameters[4] = "-1";
            else
            {
                if (this.HardwareKey == true)
                    UpdateParameters[4] =true;
                else
                    UpdateParameters[4] = false;
            }
                       
            //if (this.EnterByID == null)
            //    UpdateParameters[5] = "-1";
            //else
            //    UpdateParameters[5] = this.EnterByID.ToString();

            //if (this.EnterDate == null)
            //    UpdateParameters[6] = "-1";
            //else
            //    UpdateParameters[6] = this.EnterDate.ToString();

            if (this.EditByID == null)
                UpdateParameters[5] =DBNull.Value;// "-1";
            else
                UpdateParameters[5] = this.EditByID.ToString();

            if (this.EditDate == null)
                UpdateParameters[6] = DBNull.Value;//"-1";
            else
                UpdateParameters[6] = this.EditDate.ToString();
                        
           
            return UpdateParameters;
        }

        private void BuildFilter()
        {
            if (this.SID == null)
                this.SID = -1;

            if (this.Software == null || this.Software.Trim() == "")
                this.Software = "-1";

                     
        }

        private string BuildSortCriteria()
        {
            string SortCriteria = "-1";

            if (this.SortExpression == SortBy.SID)
                SortCriteria = "SID";
           
            if (this.SortExpression == SortBy.Software)
                SortCriteria = "Software";
           
            if (this.SortDirect == SortDirection.Ascending)
                SortCriteria += " ASC";
            if (this.SortDirect == SortDirection.Descending)
                SortCriteria += " Desc";

            return SortCriteria;
        }
        #endregion
    }
}