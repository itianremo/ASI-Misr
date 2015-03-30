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

namespace TSN.ERP.WebGUI
{
	/// <summary>
	/// Summary description for logout.
	/// </summary>
	public partial class logout : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				if(Request.QueryString.Get("Home") != null)
				{
					Session["logoff"]=false;
					Response.Redirect("UserModules.aspx?home=yes");
//					this.RegisterStartupScript("closeit","<script>window.navigate('UserModules.aspx?home=yes');</script>");
//					return;
					//				Response.Redirect("UserModules.aspx?home=yes");
				}
				else if(Request.QueryString.Get("ChangePassword") != null)
				{
					//				this.RegisterStartupScript("closeit","<script>window.navigate('SecurityManagement/frmChangePass.aspx');</script>");
					//				return;
					Session["logoff"]=false;
					Response.Redirect("SecurityManagement/frmChangePass.aspx");
				}
				else if(Request.QueryString.Get("logoff") != null)
				{
					//Record that the user has logged off
					((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.UpdateUserLogin(DateTime.Now, int.Parse(Session["CurrentLoggedID"].ToString()));

					((TSN.ERP.WebGUI.Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.LogOff();
					Session.Clear();
					Session.Abandon(); Session.Clear(); 
					Response.Redirect("index.aspx?logoff=false");
				}			
				 else if(Request.QueryString.Get("Sessiontimeout") != null)
				{
					//Record that the user has logged off
					((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.UpdateUserLogin(DateTime.Now, int.Parse(Session["CurrentLoggedID"].ToString()));

					((TSN.ERP.WebGUI.Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.LogOff();
					Session.Clear();
					Session.Abandon(); Session.Clear(); 
					Response.Redirect("ErrorPage.aspx");


					  }
				else
				{
					if(Session["logoff"]!=null)
					{
						//Record that the user has logged off
						((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.UpdateUserLogin(DateTime.Now, int.Parse(Session["CurrentLoggedID"].ToString()));

						((TSN.ERP.WebGUI.Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.LogOff();
						Session.Clear();
						Session.Abandon(); Session.Clear(); 


						if(Request.QueryString.Get("Exit") == null)
						{
							//Response.Redirect("Index.aspx");
							//				this.RegisterStartupScript("closeit","<script>window.close();window.open('index.aspx?CloseOpener=yes');</script>");
							//this.RegisterStartupScript("closeit","<script>window.navigate('index.aspx');</script>");
							Response.Redirect("index.aspx");
						}
						else
						{
							this.RegisterStartupScript("closeit","<script>window.close();</script>");
						}
					}
					else
					{
//						//Record that the user has logged off
//						((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.UpdateUserLogin(DateTime.Now, int.Parse(Session["CurrentLoggedID"].ToString()));
//
//						((TSN.ERP.WebGUI.Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.LogOff();
//						Session.Clear();
//						Session.Abandon(); Session.Clear(); 
						this.RegisterStartupScript("closeit","<script>window.close();</script>");
					}
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
	}
}
