using System;
using System.Collections.Generic;
using System.Web;
using Office.DAL;

namespace Office.BLL
{

    [System.ComponentModel.DataObject]
    public class SendEmailBLL : MasterClass
    {
        public SendEmailBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<EmailTemplateName> SelectEmailTemplatesNames()
        {
            EmailTemplate ETemp = new EmailTemplate();
            return ETemp.GetTemplatesNames();
        }

        public Office.DAL.EmailTemplate SelectEmailTemplate(int TemplateID)
        {
            EmailTemplate ETemp = new EmailTemplate();
            ETemp.TemplateID = TemplateID;
            return ETemp.GetSingleTemplate();
        }

        public List<string> GetEmailCCList()
        {
            MainSubCode GetList = new MainSubCode();
            GetList.GCode = "EmailCC";
            List<MainSubCode> MSCodeLst = GetList.GetSCodeList();
            List<string> EmailCCList = new List<string>();
            foreach (MainSubCode item in MSCodeLst)
            {
                EmailCCList.Add(item.SubCode);
            }
            return EmailCCList;
        }

        public bool AddSentEmailRecord(string Email)
        {
            SentEmails Se = new SentEmails();

            Se.Email = Email;
            Se.SentDate = DateTime.Now;
            Se.SentBy = ((ASIIdentity)User.Identity).UserID;

            return Se.AddNewSentEmail() == 1;
        }
    }
}