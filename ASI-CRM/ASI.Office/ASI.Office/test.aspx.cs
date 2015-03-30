using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Office.BLL;
using Office.DAL;

public partial class test : Office.BLL.ContactListsBLL
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //CalendarExtender31.BehaviorID = DateTime.Now.ToShortTimeString();
        //CalendarExtender1.BehaviorID = DateTime.Now.ToLongTimeString();
    }

    protected void btnAddEditNotes_Click(object sender, EventArgs e)
    {
        //try
        //{
            
            //HttpContext.Current.ApplicationInstance.CompleteRequest();
        //}
        //catch (Exception ex)
        //{
        //    return;
        //}
        
    }
}
