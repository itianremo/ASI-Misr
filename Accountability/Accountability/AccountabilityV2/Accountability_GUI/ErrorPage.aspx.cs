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

namespace TSN.ERP.WebGUI.Navigation
{
	/// <summary>
	/// Summary description for ErrorPage.
	/// </summary>
	public partial class ErrorPage : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.HyperLink hlLogin;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
		
			if (Request.QueryString["Redirect"] == "1")
			{
				Response.Write("<script>window.open('ErrorPage.aspx','_parent')</script>") ;
			}
			if(Session[ "navigation" ]==null)
			{
				tblSessionExpr.Visible = true;
				pError.Visible = false;
			}
			else
			{
				try
				{
					tblSessionExpr.Visible = false;
					pError.Visible = true;
					lblAccess.Text =  ((Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.LastInnerException();
					lblServer.Text = ((Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.LastSecurityError();
				}
				catch
				{
					tblSessionExpr.Visible = true;
					pError.Visible = false;
				}
			}

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

		protected void cbLogin_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("index.aspx");
		}
	}
}
