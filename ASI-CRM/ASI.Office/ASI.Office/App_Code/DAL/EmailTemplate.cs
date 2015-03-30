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
    public class EmailTemplate
    {
        #region -----------------Constructor---------------------

        public EmailTemplate()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region --------------------Properties -------------------

        public enum SortBy
        {
            TemplateID,
            TemplateName,
            Subject
            
        }

        public enum SearchBy
        {
            TemplateName,
            Subject
        }

        public int? TemplateID
        {
            get { return _TemplateID; }
            set { _TemplateID = value; }
        }

        public string TemplateName
        {
            get { return _TemplateName; }
            set { _TemplateName = value; }
        }
        public string TemplateEmailSubject
        {
            get { return _TemplateEmailSubject; }
            set { _TemplateEmailSubject = value; }
        }
        public string TemplateContent
        {
            get { return _TemplateContent; }
            set { _TemplateContent = value; }
        }

        public bool DefaultTemplate
        {
            get { return _DefaultTemplate; }
            set { _DefaultTemplate = value; }
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
        private string _EditByName;
        private string _EnteredByName;
        private bool _DefaultTemplate;
        private int? _TemplateID;
        private string _TemplateName;
        private string _TemplateEmailSubject;
        private string _TemplateContent;
        private SortBy _SortExpression;
        private SortDirection _SortDirect;
        string StrCon = ConfigurationManager.ConnectionStrings["ASI-CRMConnectionString"].ToString();

        #endregion

        #region -----------------General Functions----------------

        /// <summary>
        /// Insert new record into table EmailTemplate
        /// Fill in all properties of the EmailTemplate Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int AddNewTemplate()
        {
            int AffectedRows = -1;
            try
            {
                if (this._DefaultTemplate == null)
                    this.DefaultTemplate = false;
                object voEmailTemplateID= SqlHelper.ExecuteNonQuery(StrCon, "EmailTemplate_Insert", this._TemplateName, this._TemplateContent, this._TemplateEmailSubject, this._DefaultTemplate, this._EnterByID, this._EnterDate, this._EditByID, this._EditDate);
                if (voEmailTemplateID != null)
                    AffectedRows = int.Parse(voEmailTemplateID.ToString());
                //AffectedRows = 1;
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return AffectedRows;
        }

        /// <summary>
        /// Update existing record in table Contact_EmailTemplate
        /// Fill in all properties of the EmailTemplate Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int UpdateTemplate()
        {
            int Affected = -1;

            try
            {
                object[] Params = BuildUpdateQueryParams();
                string st = "";
                foreach (object param in Params)
                    st += param.ToString() + ";";
                Affected = BaseClass.UpdateCommand("EmailTemplate_Update", Params);
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            return Affected;
        }

        public List<EmailTemplate> GetTemplates()
        {
            SqlConnection conTemplate = new SqlConnection(StrCon);
            List<EmailTemplate> TemplateList = new List<EmailTemplate>();

            try
            {
                BuildFilter();
                string SortCriteria = BuildSortCriteria();
                SqlDataReader rdrTemplate = SqlHelper.ExecuteReader(conTemplate, "EmailTemplate_SelectAll");
                EmailTemplate template;

                while (rdrTemplate.Read())
                {
                    try
                    {
                        template = new EmailTemplate();
                        template.TemplateID = int.Parse(rdrTemplate["TemplateID"].ToString());

                          if (rdrTemplate["TemplateID"] != null && rdrTemplate["TemplateID"].ToString() != "")
                            template.TemplateID = int.Parse(rdrTemplate["TemplateID"].ToString());
                        else
                            template.TemplateID = int.MinValue;
                          template.TemplateName = rdrTemplate["TemplateName"].ToString();


                          template.TemplateContent = rdrTemplate["TemplateContent"].ToString();
                          template.TemplateEmailSubject = rdrTemplate["TemplateEmailSubject"].ToString();

                        if (rdrTemplate["DefaultTemplate"] != null && rdrTemplate["DefaultTemplate"].ToString() != "")
                            template.DefaultTemplate = Convert.ToBoolean(rdrTemplate["DefaultTemplate"]);
                        else
                            template.DefaultTemplate = false;
                       

                        if (rdrTemplate["EditByID"] != null && rdrTemplate["EditByID"].ToString() != "")
                            template.EditByID = int.Parse(rdrTemplate["EditByID"].ToString());
                        else
                            template.EditByID = int.MinValue;

                       

                        if (rdrTemplate["EditDate"] != null && rdrTemplate["EditDate"].ToString() != "")
                            template.EditDate = Convert.ToDateTime(rdrTemplate["EditDate"].ToString());
                        else
                            template.EditDate = DateTime.MinValue;

                        if (rdrTemplate["EnterByID"] != null && rdrTemplate["EnterByID"].ToString() != "")
                            template.EnterByID = int.Parse(rdrTemplate["EnterByID"].ToString());
                        else
                            template.EnterByID = int.MinValue;

                        if (rdrTemplate["EnterDate"] != null && rdrTemplate["EnterDate"].ToString() != "")
                            template.EnterDate = Convert.ToDateTime(rdrTemplate["EnterDate"].ToString());
                        else
                            template.EnterDate = DateTime.MinValue;

                        //template.EnteredByName = rdrTemplate["EnteredByName"].ToString();
                        //template.EditByName = rdrTemplate["EditByName"].ToString();

                       

                                          

                        

                        TemplateList.Add(template);
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
                conTemplate.Close();
            }

            return TemplateList;
        }

        public EmailTemplate GetSingleTemplate()
        {
            SqlConnection conTemplate = new SqlConnection(StrCon);
            EmailTemplate template = new EmailTemplate();

            try
            {
                SqlDataReader rdrTemplate = SqlHelper.ExecuteReader(conTemplate, "EmailTemplate_GetByTemplateID", this.TemplateID);

                while (rdrTemplate.Read())
                {
                    try
                    {
                        template.TemplateID = int.Parse(rdrTemplate["TemplateID"].ToString());

                        if (rdrTemplate["TemplateID"] != null && rdrTemplate["TemplateID"].ToString() != "")
                            template.TemplateID = int.Parse(rdrTemplate["TemplateID"].ToString());
                        else
                            template.TemplateID = int.MinValue;

                        template.TemplateName = rdrTemplate["TemplateName"].ToString();
                        template.TemplateContent = rdrTemplate["TemplateContent"].ToString();
                        template.TemplateEmailSubject = rdrTemplate["TemplateEmailSubject"].ToString();

                        if (rdrTemplate["DefaultTemplate"] != null && rdrTemplate["DefaultTemplate"].ToString() != "")
                            template.DefaultTemplate = Convert.ToBoolean(rdrTemplate["DefaultTemplate"]);
                        else
                            template.DefaultTemplate = false;


                        if (rdrTemplate["EditByID"] != null && rdrTemplate["EditByID"].ToString() != "")
                            template.EditByID = int.Parse(rdrTemplate["EditByID"].ToString());
                        else
                            template.EditByID = int.MinValue;

                       

                        if (rdrTemplate["EditDate"] != null && rdrTemplate["EditDate"].ToString() != "")
                            template.EditDate = Convert.ToDateTime(rdrTemplate["EditDate"].ToString());
                        else
                            template.EditDate = DateTime.MinValue;

                        if (rdrTemplate["EnterByID"] != null && rdrTemplate["EnterByID"].ToString() != "")
                            template.EnterByID = int.Parse(rdrTemplate["EnterByID"].ToString());
                        else
                            template.EnterByID = int.MinValue;

                        if (rdrTemplate["EnterDate"] != null && rdrTemplate["EnterDate"].ToString() != "")
                            template.EnterDate = Convert.ToDateTime(rdrTemplate["EnterDate"].ToString());
                        else
                            template.EnterDate = DateTime.MinValue;

                        //template.EnteredByName = rdrTemplate["EnteredByName"].ToString();
                        //template.EditByName = rdrTemplate["EditByName"].ToString();

                      
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
                conTemplate.Close();
            }
            return template;
        }
        public EmailTemplate GetDefaultTemplate()
        {
            SqlConnection conTemplate = new SqlConnection(StrCon);
            EmailTemplate template = new EmailTemplate();

            try
            {
                SqlDataReader rdrTemplate = SqlHelper.ExecuteReader(conTemplate, "EmailTemplate_GetByDefaultTemplate");

                while (rdrTemplate.Read())
                {
                    try
                    {
                        template.TemplateID = int.Parse(rdrTemplate["TemplateID"].ToString());

                        if (rdrTemplate["TemplateID"] != null && rdrTemplate["TemplateID"].ToString() != "")
                            template.TemplateID = int.Parse(rdrTemplate["TemplateID"].ToString());
                        else
                            template.TemplateID = int.MinValue;

                        template.TemplateName = rdrTemplate["TemplateName"].ToString();
                        template.TemplateContent = rdrTemplate["TemplateContent"].ToString();
                        template.TemplateEmailSubject = rdrTemplate["TemplateEmailSubject"].ToString();

                        if (rdrTemplate["DefaultTemplate"] != null && rdrTemplate["DefaultTemplate"].ToString() != "")
                            template.DefaultTemplate = Convert.ToBoolean(rdrTemplate["DefaultTemplate"]);
                        else
                            template.DefaultTemplate = false;


                        if (rdrTemplate["EditByID"] != null && rdrTemplate["EditByID"].ToString() != "")
                            template.EditByID = int.Parse(rdrTemplate["EditByID"].ToString());
                        else
                            template.EditByID = int.MinValue;



                        if (rdrTemplate["EditDate"] != null && rdrTemplate["EditDate"].ToString() != "")
                            template.EditDate = Convert.ToDateTime(rdrTemplate["EditDate"].ToString());
                        else
                            template.EditDate = DateTime.MinValue;

                        if (rdrTemplate["EnterByID"] != null && rdrTemplate["EnterByID"].ToString() != "")
                            template.EnterByID = int.Parse(rdrTemplate["EnterByID"].ToString());
                        else
                            template.EnterByID = int.MinValue;

                        if (rdrTemplate["EnterDate"] != null && rdrTemplate["EnterDate"].ToString() != "")
                            template.EnterDate = Convert.ToDateTime(rdrTemplate["EnterDate"].ToString());
                        else
                            template.EnterDate = DateTime.MinValue;

                        //template.EnteredByName = rdrTemplate["EnteredByName"].ToString();
                        //template.EditByName = rdrTemplate["EditByName"].ToString();


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
                conTemplate.Close();
            }
            return template;
        }

        public List<EmailTemplateName> GetTemplatesNames()
        {
            SqlConnection conTemplate = new SqlConnection(StrCon);
            List<EmailTemplateName> TemplateList = new List<EmailTemplateName>();

            try
            {
                BuildFilter();
                string SortCriteria = BuildSortCriteria();
                SqlDataReader rdrTemplate = SqlHelper.ExecuteReader(conTemplate, "EmailTemplate_SelectNames");
                EmailTemplateName TemplateName;

                while (rdrTemplate.Read())
                {
                    try
                    {
                        TemplateName = new EmailTemplateName();
                        TemplateName.TemplateID = int.Parse(rdrTemplate["TemplateID"].ToString());
                        TemplateName.TemplateName = rdrTemplate["TemplateName"].ToString();

                        TemplateList.Add(TemplateName);
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
                conTemplate.Close();
            }

            return TemplateList;
        }
       
        /// <summary>
        /// Delete existing record in table Contact_EmailTemplate
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public string DeleteTemplate()
        {
            object Affected = "-1";
            try
            {
                object[] Params = { _TemplateID};
                Affected = BaseClass.ReturnValueCommand("EmailTemplate_Delete", Params);
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
        /// <returns>integer value to indicates number of this template order</returns>
        public int GetTemplateOrder()
        {
            int result = -1;

            try
            {
                result = (int)BaseClass.ReturnValueCommand("SP_Get_Template_Order", this._TemplateID, 0);
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
            UpdateParameters[0] = this.TemplateID.ToString();

            if (this.TemplateName == null)
                UpdateParameters[1] = "-1";
            else
                UpdateParameters[1] = this.TemplateName;
            if (this.TemplateContent == null)
                UpdateParameters[2] = "-1";
            else
                UpdateParameters[2] = this.TemplateContent;
            if (this.TemplateEmailSubject == null)
                UpdateParameters[3] = "-1";
            else
                UpdateParameters[3] = this.TemplateEmailSubject;

            if (this.DefaultTemplate == null)
                UpdateParameters[4] = "-1";
            else
            {
                if (this.DefaultTemplate == true)
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
            if (this.TemplateID == null)
                this.TemplateID = -1;

            if (this.TemplateName == null || this.TemplateName.Trim() == "")
                this.TemplateName = "-1";

                     
        }

        private string BuildSortCriteria()
        {
            string SortCriteria = "-1";

            if (this.SortExpression == SortBy.TemplateID)
                SortCriteria = "TemplateID";
           
            if (this.SortExpression == SortBy.TemplateName)
                SortCriteria = "TemplateName";
           
            if (this.SortDirect == SortDirection.Ascending)
                SortCriteria += " ASC";
            if (this.SortDirect == SortDirection.Descending)
                SortCriteria += " Desc";

            return SortCriteria;
        }
        #endregion
    }

    [Serializable]
    public class EmailTemplateName
    {
        #region -----------------Constructor---------------------

        public EmailTemplateName()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region --------------------Properties -------------------

        public int? TemplateID{
            get { return _TemplateID; }
            set { _TemplateID = value; }
        }

        public string TemplateName
        {
            get { return _TemplateName; }
            set { _TemplateName = value; }
        }

        private int? _TemplateID;
        private string _TemplateName;
        #endregion
    }
}