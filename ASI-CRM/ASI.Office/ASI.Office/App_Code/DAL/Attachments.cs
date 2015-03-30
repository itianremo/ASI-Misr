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
    public class Attachments
    {
        #region -----------------Constructor---------------------

        public Attachments()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region -------------------- Properties -------------------

        public enum SortBy
        {
            AttachmentID,
            FileName,
            FileSize
            
        }

        public enum SearchBy
        {
            FileName,
            FileSize
        }

        public int? AttachmentID
        {
            get { return _AttachmentID; }
            set { _AttachmentID = value; }
        }

        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }

        public string FileSize
        {
            get { return _FileSize; }
            set { _FileSize = value; }
        }
         
        public string FileFileSize
        {
            get { return _FileSize; }
            set { _FileSize = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }

        }

        public byte[] Attach
        {
            get { return _Attach; }
            set { _Attach = value; }
        }
        public int? ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; }
        }
        public int? AccountID
        {
            get { return _AccountID; }
            set { _AccountID = value; }
        }

        public int? BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
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

        public int? EditBy
        {
            get { return _EditBy; }
            set { _EditBy = value; }
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

        public string EnterByName
        {
            get { return _EnterByName; }
            set { _EnterByName = value; }
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
        private int? _ContactID;
        private int? _AccountID;
        private int? _BranchID;
        private DateTime? _EnterDate;
        private int? _EditBy;
        private DateTime? _EditDate;
        private string _EditByName;
        private string _EnterByName;
       
        private int? _AttachmentID;
       
        private string _FileName;
       
        private string _FileSize;
       
       
        private string _Description;

        private byte[] _Attach;
             
       
        private SortBy _SortExpression;
        private SortDirection _SortDirect;
        string StrCon = ConfigurationManager.ConnectionStrings["ASI-CRMConnectionString"].ToString();

        #endregion

        #region -----------------General Functions----------------

        /// <summary>
        /// Insert new record into table EmailAttach
        /// Fill in all properties of the EmailAttach Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int AddNewAttachments()
        {
            int AffectedRows = -1;
            try
            {
               
                object objAttch= SqlHelper.ExecuteNonQuery(StrCon, "Attachments_Insert", this._FileName, this._FileSize,this._Attach,this._Description,this._AccountID,this._ContactID,this._BranchID, this._EnterBy, this._EnterDate, this._EditBy, this._EditDate);
                if (objAttch != null)
                    AffectedRows = int.Parse(objAttch.ToString());
                //AffectedRows = 1;
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return AffectedRows;
        }

        

        public List<Attachments> GetAttachments()
        {
            SqlConnection conAttach = new SqlConnection(StrCon);
            List<Attachments> AttachList = new List<Attachments>();
            SqlDataReader rdrAttach; 

            try
            {
                BuildFilter();
                string SortCriteria = BuildSortCriteria();
               
                if(this.ContactID==null && this.AccountID>0)
                rdrAttach = SqlHelper.ExecuteReader(conAttach, "Attachments_GetByCompanyID", this.AccountID);
                else if(ContactID>0)
                rdrAttach = SqlHelper.ExecuteReader(conAttach, "Attachments_GetByContactID", this.ContactID);
                else //if(BranchID>0)
                    rdrAttach = SqlHelper.ExecuteReader(conAttach, "Attachments_GetByBranchID", this.BranchID);
                Attachments Attach;

                while (rdrAttach.Read())
                {
                    try
                    {
                        Attach = new Attachments();
                        Attach.AttachmentID = int.Parse(rdrAttach["AttachmentID"].ToString());

                          if (rdrAttach["AttachmentID"] != null && rdrAttach["AttachmentID"].ToString() != "")
                            Attach.AttachmentID = int.Parse(rdrAttach["AttachmentID"].ToString());
                        else
                            Attach.AttachmentID = int.MinValue;

                          Attach.FileName = rdrAttach["FileName"].ToString();
                       
                          Attach.FileSize = rdrAttach["FileSize"].ToString();

                          Attach.Attach =(byte []) rdrAttach["Attach"];
                          Attach.Description = rdrAttach["Description"].ToString();

                          if (rdrAttach["ContactID"] != null && rdrAttach["ContactID"].ToString() != "")
                              Attach.ContactID = int.Parse(rdrAttach["ContactID"].ToString());
                          else
                              Attach.ContactID = int.MinValue;

                          if (rdrAttach["AccountID"] != null && rdrAttach["AccountID"].ToString() != "")
                              Attach.AccountID = int.Parse(rdrAttach["AccountID"].ToString());
                          else
                              Attach.AccountID = int.MinValue;

                          if (rdrAttach["BranchID"] != null && rdrAttach["BranchID"].ToString() != "")
                              Attach.BranchID = int.Parse(rdrAttach["BranchID"].ToString());
                          else
                              Attach.BranchID = int.MinValue;

                        if (rdrAttach["EditBy"] != null && rdrAttach["EditBy"].ToString() != "")
                            Attach.EditBy = int.Parse(rdrAttach["EditBy"].ToString());
                        else
                            Attach.EditBy = int.MinValue;

                       
                        if (rdrAttach["EditDate"] != null && rdrAttach["EditDate"].ToString() != "")
                            Attach.EditDate = Convert.ToDateTime(rdrAttach["EditDate"].ToString());
                        else
                            Attach.EditDate = DateTime.MinValue;

                        if (rdrAttach["EnterBy"] != null && rdrAttach["EnterBy"].ToString() != "")
                            Attach.EnterBy = int.Parse(rdrAttach["EnterBy"].ToString());
                        else
                            Attach.EnterBy = int.MinValue;

                        if (rdrAttach["EnterDate"] != null && rdrAttach["EnterDate"].ToString() != "")
                            Attach.EnterDate = Convert.ToDateTime(rdrAttach["EnterDate"].ToString());
                        else
                            Attach.EnterDate = DateTime.MinValue;

                        Attach.EnterByName = rdrAttach["EnterByName"].ToString();

                        Attach.EditByName = rdrAttach["EditByName"].ToString();

                      
                        

                        AttachList.Add(Attach);
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
                conAttach.Close();
            }

            return AttachList;
        }

        public Attachments GetSingleAttachments()
        {
            SqlConnection conAttach = new SqlConnection(StrCon);
            Attachments Attach = new Attachments();

            try
            {
                SqlDataReader rdrAttach = SqlHelper.ExecuteReader(conAttach, "Attachments_GetByID", this.AttachmentID);

                while (rdrAttach.Read())
                {
                    try
                    {
                        Attach.AttachmentID = int.Parse(rdrAttach["AttachmentID"].ToString());

                        if (rdrAttach["AttachmentID"] != null && rdrAttach["AttachmentID"].ToString() != "")
                            Attach.AttachmentID = int.Parse(rdrAttach["AttachmentID"].ToString());
                        else
                            Attach.AttachmentID = int.MinValue;

                        Attach.FileName = rdrAttach["FileName"].ToString();

                        Attach.FileSize = rdrAttach["FileSize"].ToString();

                        Attach.Attach = (byte[])rdrAttach["Attach"];
                        Attach.Description = rdrAttach["Description"].ToString();

                        if (rdrAttach["ContactID"] != null && rdrAttach["ContactID"].ToString() != "")
                            Attach.ContactID = int.Parse(rdrAttach["ContactID"].ToString());
                        else
                            Attach.ContactID = int.MinValue;

                        if (rdrAttach["AccountID"] != null && rdrAttach["AccountID"].ToString() != "")
                            Attach.AccountID = int.Parse(rdrAttach["AccountID"].ToString());
                        else
                            Attach.AccountID = int.MinValue;

                        if (rdrAttach["BranchID"] != null && rdrAttach["BranchID"].ToString() != "")
                            Attach.BranchID = int.Parse(rdrAttach["BranchID"].ToString());
                        else
                            Attach.BranchID = int.MinValue;

                        if (rdrAttach["EditBy"] != null && rdrAttach["EditBy"].ToString() != "")
                            Attach.EditBy = int.Parse(rdrAttach["EditBy"].ToString());
                        else
                            Attach.EditBy = int.MinValue;


                        if (rdrAttach["EditDate"] != null && rdrAttach["EditDate"].ToString() != "")
                            Attach.EditDate = Convert.ToDateTime(rdrAttach["EditDate"].ToString());
                        else
                            Attach.EditDate = DateTime.MinValue;

                        if (rdrAttach["EnterBy"] != null && rdrAttach["EnterBy"].ToString() != "")
                            Attach.EnterBy = int.Parse(rdrAttach["EnterBy"].ToString());
                        else
                            Attach.EnterBy = int.MinValue;

                        if (rdrAttach["EnterDate"] != null && rdrAttach["EnterDate"].ToString() != "")
                            Attach.EnterDate = Convert.ToDateTime(rdrAttach["EnterDate"].ToString());
                        else
                            Attach.EnterDate = DateTime.MinValue;

                        Attach.EnterByName = rdrAttach["EnterByName"].ToString();

                        Attach.EditByName = rdrAttach["EditByName"].ToString();

                   

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
                conAttach.Close();
            }
            return Attach;
        }

    

       
        /// <summary>
        /// Delete existing record in table Contact_EmailAttach
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public string DeleteAttachments()
        {
            object Affected = "-1";
            try
            {
                object[] Params = { _AttachmentID};
                Affected = BaseClass.ReturnValueCommand("Attachments_Delete", Params);
            }
            catch (Exception Exp)
            {
                return Exp.Message;
            }
            return Affected.ToString();
        }

       
        #endregion

        #region -----------------Private Functions----------------

        private object[] BuildUpdateQueryParams()
        {
            object[] UpdateParameters = new object[7];
            UpdateParameters[0] = this.AttachmentID.ToString();

            if (this.FileName == null)
                UpdateParameters[1] = "-1";
            else
                UpdateParameters[1] = this.FileName;
          
            if (this.FileSize == null)
                UpdateParameters[2] = "-1";
            else
                UpdateParameters[2] = this.FileSize;



            if (this.Attach == null)
                UpdateParameters[3] = "-1";
            else
                UpdateParameters[3] = this.Attach;

            if (this.Description == null)
                UpdateParameters[4] = "-1";
            else
                UpdateParameters[4] = this.Description;
                       
            //if (this.EnterBy == null)
            //    UpdateParameters[5] = "-1";
            //else
            //    UpdateParameters[5] = this.EnterBy.ToString();

            //if (this.EnterDate == null)
            //    UpdateParameters[6] = "-1";
            //else
            //    UpdateParameters[6] = this.EnterDate.ToString();

            if (this.EditBy == null)
                UpdateParameters[5] =DBNull.Value;// "-1";
            else
                UpdateParameters[5] = this.EditBy.ToString();

            if (this.EditDate == null)
                UpdateParameters[6] = DBNull.Value;//"-1";
            else
                UpdateParameters[6] = this.EditDate.ToString();
                        
           
            return UpdateParameters;
        }

        private void BuildFilter()
        {
            if (this.AttachmentID == null)
                this.AttachmentID = -1;

            if (this.FileName == null || this.FileName.Trim() == "")
                this.FileName = "-1";

                     
        }

        private string BuildSortCriteria()
        {
            string SortCriteria = "-1";

            if (this.SortExpression == SortBy.AttachmentID)
                SortCriteria = "AttachmentID";
           
            if (this.SortExpression == SortBy.FileName)
                SortCriteria = "FileName";
           
            if (this.SortDirect == SortDirection.Ascending)
                SortCriteria += " ASC";
            if (this.SortDirect == SortDirection.Descending)
                SortCriteria += " Desc";

            return SortCriteria;
        }
        #endregion
    }
}