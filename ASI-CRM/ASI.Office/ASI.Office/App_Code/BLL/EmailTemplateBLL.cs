using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Office.DAL;
using System.Collections.Generic;

namespace Office.BLL
{
    [System.ComponentModel.DataObject]
    public class EmailTemplateBLL : MasterClass
    {
        public EmailTemplateBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<EmailTemplate> SelectAllEmailTemplate(EmailTemplate CurrentTemplate)
        {
            EmailTemplate CTemp = new EmailTemplate();
            if (CurrentTemplate != null)
                CTemp = CurrentTemplate;
            return CTemp.GetTemplates();
        }
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public EmailTemplate SelectEmailTemplate(EmailTemplate CurrentTemplate)
        {
            if (CurrentTemplate != null)
                return CurrentTemplate.GetSingleTemplate();
            else
                return new EmailTemplate();
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public EmailTemplate GetSearchFilter(string Sortby, string sortDirection)
        {
            EmailTemplate temp = new EmailTemplate();
            switch (Sortby)
            {
                case "TemplateName":
                    temp.SortExpression = EmailTemplate.SortBy.TemplateName;
                    break;

                case "TemplateID":
                    temp.SortExpression = EmailTemplate.SortBy.TemplateID;
                    break;
                case "Subject":
                    temp.SortExpression = EmailTemplate.SortBy.Subject;
                    break;


            }

            switch (sortDirection)
            {
                case "ASC":
                    temp.SortDirect = SortDirection.Ascending;
                    break;

                case "Desc":
                    temp.SortDirect = SortDirection.Descending;
                    break;
            }


            //
            return temp;

        }


        public bool UpdateEmailTemplate(int EmailTemplateID, string TemplateName, string TemplateContent, string TemplateEmailSubject, bool DefaultTemplate)
        {
            EmailTemplate temp = new EmailTemplate();
            temp.TemplateID = EmailTemplateID;
            temp.TemplateName = TemplateName;
            temp.TemplateContent = TemplateContent;
            temp.TemplateEmailSubject = TemplateEmailSubject;
            temp.DefaultTemplate = DefaultTemplate;
            temp.EditByID = ((ASIIdentity)User.Identity).UserID;
            temp.EditDate = DateTime.Now;
           

            if (temp.UpdateTemplate() != -1)
                return true;
            else
                return false;
        }

        public bool AddEmailTemplate(int EmailTemplateID, string TemplateName, string TemplateContent, string TemplateEmailSubject, bool DefaultTemplate)
        {
            EmailTemplate temp = new EmailTemplate();
            temp.TemplateID = EmailTemplateID;
            temp.TemplateName = TemplateName;
            temp.TemplateContent = TemplateContent;
            temp.TemplateEmailSubject = TemplateEmailSubject;
            temp.EnterByID = ((ASIIdentity)User.Identity).UserID;
            temp.EnterDate = DateTime.Now;
            temp.EditByID = ((ASIIdentity)User.Identity).UserID;
            temp.EditDate = DateTime.Now;
           
           

            if (temp.AddNewTemplate() == 1)
                return true;
            else
                return false;
        }


        public string DeleteTemplateByID(int TemplateID)
        {
            EmailTemplate temp = new EmailTemplate();
            temp.TemplateID = TemplateID;

            string ResultMsg = temp.DeleteTemplate();

            if (ResultMsg.Equals("1"))
                ResultMsg = "Template deleted successfully!";
            else
            {
                if (ResultMsg.Equals("0"))
                    ResultMsg = "Template not found.";
                else if (ResultMsg.Equals("-1"))
                    ResultMsg = "Can't delete this template.";
            }

            return ResultMsg;
        }

        public bool DeleteTemplateByID(int TemplateID, out string ResultMsg)
        {
            bool Result = false;
            EmailTemplate temp = new EmailTemplate();
            temp.TemplateID = TemplateID;

            ResultMsg = temp.DeleteTemplate();

            if (ResultMsg.Equals("1"))
            {
                ResultMsg = "Template deleted successfully!";
                Result = true;
            }
            else
            {
                if (ResultMsg.Equals("0"))
                    ResultMsg = "Template not found.";
                else if (ResultMsg.Equals("-1"))
                    ResultMsg = "Can't delate this template.";
            }

            return Result;
        }





        
    }
}
