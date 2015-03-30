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
    public class CustomerSupportBLL : System.Web.UI.UserControl
    {
        public CustomerSupportBLL()
        {
           
        }
        public DataSet GetLoginUsers()
        {
            CustomerSupport objCustomerSupport = new CustomerSupport();
            return objCustomerSupport.GetLoginUsers();
        }

        public bool AddNewForwordTechnicalSupport( string Subject,  string RelatedToContact,string Type,  int EnterBy,  DateTime EnterDate,int ForwordToUserID,string Status, int TechnicalSupportID, DateTime TechnicalSupportDate,string Site)
        {

            CustomerSupport objCustomerSupport = new CustomerSupport();
            objCustomerSupport.Subject = Subject;
            objCustomerSupport.RelatedToContact = RelatedToContact;
            objCustomerSupport.Type = Type;
            objCustomerSupport.EnterBy = EnterBy;
           
            // ((ASIIdentity)User.Identity).UserID;
            objCustomerSupport.EnterDate = DateTime.Now;
            objCustomerSupport.ForwordToUserID = ForwordToUserID;
            objCustomerSupport.Status = Status;
            objCustomerSupport.TechnicalSupportID = TechnicalSupportID;
            

            if (TechnicalSupportDate !=null)
                objCustomerSupport.TechnicalSupportDate = TechnicalSupportDate;
            if (Site != null)
            objCustomerSupport.Site = Site;


            if (objCustomerSupport.AddNewForwordTechnicalSupport() == 1)
                return true;
            else
                return false;
        }


       
              
    }
}
