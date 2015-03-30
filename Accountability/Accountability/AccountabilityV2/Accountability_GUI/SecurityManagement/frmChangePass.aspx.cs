using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Threading;

namespace TSN.ERP.WebGUI.SecurityManagement
{
	/// <summary>
	/// Summary description for frmChangePass.
	/// </summary>
	public partial class frmChangePass : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{

			Session["logoff"]=null;
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		protected void cbOK_Click(object sender, System.EventArgs e)
		{
			if(Page.IsValid)
			{
				if(((Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.ChangePassword(tbOldPass.Text,tbNewPass.Text))
				{
					//Navigation.BaseObject.showMessage( "Password changed successfully" , this.Page );
					Page.RegisterStartupScript( "" , "<script>alert('Password changed successfully')</script>");
				}
				else
				{
				
					//Navigation.BaseObject.showMessage( "Failed to change Password" , this.Page );
					Page.RegisterStartupScript( "" , "<script>alert('Failed to change Password')</script>");
				}
			}
		}

		private void cbCancel_Click(object sender, System.EventArgs e)
		{
		//	Response.Redirect("../UserModules.aspx");
            //Response.Redirect("../UserModules.aspx?home=yes");//ContentPage.aspx?uc=
            Response.Redirect("ContentPage.aspx?uc=ctlEmployeeMain.ascx");
		}

		private void cbHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../UserModules.aspx?home=yes");
		}
	}
}
