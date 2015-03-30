using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OboutInc.Splitter2;
using Office.BLL;
using System.Web.Security;

public partial class MasterLayout : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
		 
    }
	 protected void imgbtnSignOut_Click(object sender, ImageClickEventArgs e)
	 {
		// SignOut();
		 FormsAuthentication.SignOut();
		 HttpContext.Current.Session.Clear();
		 FormsAuthentication.RedirectToLoginPage();
	 }
}
