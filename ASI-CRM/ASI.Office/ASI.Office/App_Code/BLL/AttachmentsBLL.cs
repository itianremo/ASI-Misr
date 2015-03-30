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
    public class AttachmentsBLL : System.Web.UI.UserControl
    {
        public AttachmentsBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<Attachments> SelectAllAttachments(Attachments CurrentAttchment)
        {
            Attachments objAttach = new Attachments();
            if (CurrentAttchment != null)
                objAttach = CurrentAttchment;
            return objAttach.GetAttachments();
        }

        
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public Attachments SelectAttachment(Attachments CurrentAttchment)
        {
            if (CurrentAttchment != null)
                return CurrentAttchment.GetSingleAttachments();
            else
                return new Attachments();
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public Attachments GetSearchFilter(string Sortby, string sortDirection)
        {
            Attachments objAttach = new Attachments();
            switch (Sortby)
            {
                case "FileName":
                    objAttach.SortExpression = Attachments.SortBy.FileName;
                    break;

                case "AttachmentID":
                    objAttach.SortExpression = Attachments.SortBy.AttachmentID;
                    break;
                case "FileSize":
                    objAttach.SortExpression = Attachments.SortBy.FileSize;
                    break;


            }

            switch (sortDirection)
            {
                case "ASC":
                    objAttach.SortDirect = SortDirection.Ascending;
                    break;

                case "Desc":
                    objAttach.SortDirect = SortDirection.Descending;
                    break;
            }


            //
            return objAttach;

        }

/*
        public bool UpdateAttachments(int AttachmentsID, string FileName, string FileSizet, byte[] Attach, string Description)
        {
            Attachments objAttach = new Attachments();
            objAttach.AttachmentID = AttachmentsID;
            objAttach.FileName = FileName;
            objAttach.FileSize = FileSizet;
            objAttach.Attach = Attach;
            objAttach.Description = Description;
            objAttach.EditBy = ((ASIIdentity)User.Identity).UserID;
            objAttach.EditDate = DateTime.Now;
           

            if (objAttach.Update() != -1)
                return true;
            else
                return false;
        }
 * */

        public bool AddAttachments(int AttachmentsID, string FileName, string FileSize, byte[] Attach, string Description,int AccountID,int ContactID,int BranchID, int UserID)
        {
            Attachments objAttach = new Attachments();
            objAttach.AttachmentID = AttachmentsID;
            objAttach.FileName = FileName;
            objAttach.FileSize = FileSize;
            objAttach.Attach = Attach;
            objAttach.Description = Description;
            if(AccountID>0)
            objAttach.AccountID = AccountID;
            if (ContactID > 0)
            objAttach.ContactID = ContactID;
            if (BranchID > 0)
                objAttach.BranchID = BranchID;


            objAttach.EnterBy = UserID;// ((ASIIdentity)User.Identity).UserID;
            objAttach.EnterDate = DateTime.Now;
            objAttach.EditBy = UserID; //((ASIIdentity)User.Identity).UserID;
            objAttach.EditDate = DateTime.Now;
           
           

            if (objAttach.AddNewAttachments() == 1)
                return true;
            else
                return false;
        }


        public string DeleteAttachmentByID(int AttachmentID)
        {
            Attachments objAttach = new Attachments();
            objAttach.AttachmentID = AttachmentID;

            string ResultMsg = objAttach.DeleteAttachments();

            if (ResultMsg.Equals("1"))
                ResultMsg = "Attached deleted successfully!";
            else
            {
                if (ResultMsg.Equals("0"))
                    ResultMsg = "Attached not found.";
                else if (ResultMsg.Equals("-1"))
                    ResultMsg = "Can't delete this Attached.";
            }

            return ResultMsg;
        }

        public bool DeleteAttachmentByID(int AttachmentID, out string ResultMsg)
        {
            bool Result = false;
            Attachments objAttach = new Attachments();
            objAttach.AttachmentID = AttachmentID;

            ResultMsg = objAttach.DeleteAttachments();

            if (ResultMsg.Equals("1"))
            {
                ResultMsg = "Attached deleted successfully!";
                Result = true;
            }
            else
            {
                if (ResultMsg.Equals("0"))
                    ResultMsg = "Attached not found.";
                else if (ResultMsg.Equals("-1"))
                    ResultMsg = "Can't delate this Attached.";
            }

            return Result;
        }



        public bool AddCreditFile(int DueDil_ID, string FileName, string FileSize, byte[] CreditCheckFile, string CreditCheckStatus, int UserID)
        {
            DueDiligence objAttach = new DueDiligence();
            objAttach.DueDil_ID = DueDil_ID;
            objAttach.CreditCheckFile = CreditCheckFile;
            objAttach.CreditCheckStatus = CreditCheckStatus;
            objAttach.CreditCheckFileName = FileName;
            objAttach.CreditCheckFileSize = FileSize;
            objAttach.EditByID = UserID; //((ASIIdentity)User.Identity).UserID;
            objAttach.EditDate = DateTime.Now;



            if (objAttach.UpdateDueDiligenceFile() == 1)
                return true;
            else
                return false;
        }

        public bool AddMasterFile(int DueDil_ID, string FileName, string FileSize, byte[] MasterPurchaseFile, string MasterPurchaseStatus, int UserID)
        {
            DueDiligence objAttach = new DueDiligence();
            objAttach.DueDil_ID = DueDil_ID;
            objAttach.CreditCheckStatus = "";
            objAttach.MasterPurchaseFile = MasterPurchaseFile;
            objAttach.MasterPurchaseStatus = MasterPurchaseStatus;
            objAttach.MasterPurchaseFileName = FileName;
            objAttach.MasterPurchaseFileSize = FileSize;
            objAttach.EditByID = UserID; //((ASIIdentity)User.Identity).UserID;
            objAttach.EditDate = DateTime.Now;



            if (objAttach.UpdateDueDiligenceFile() == 1)
                return true;
            else
                return false;
        }
        
    }
}
