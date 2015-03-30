using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

namespace MainGUI 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{
			
			
		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{
			
		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
            Response.AppendHeader("X-UA-Compatible", "IE=EmulateIE7");
		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}
		protected void Application_Error(Object sender, EventArgs e)
		{
//			((TSN.ERP.WebGUI.Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.UpdateUserLogin(DateTime.Now, int.Parse(Session["CurrentLoggedID"].ToString()));
            //Response.Redirect("ErrorPage.aspx?Redirect=1",true);
		}

		protected void Session_End(Object sender, EventArgs e)
		{
//		    ((TSN.ERP.WebGUI.Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.LogOff();
//			Session.Clear();
//			Session.Abandon(); Session.Clear(); 
//			Session["logoff"]=false;
//			Response.Redirect("logout.aspx?Sessiontimeout=Sessiontimeout");
			//Record that the user has logged off
			((TSN.ERP.WebGUI.Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.UpdateUserLogin(DateTime.Now, int.Parse(Session["CurrentLoggedID"].ToString()));
		}

		protected void Application_End(Object sender, EventArgs e)
		{
		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

