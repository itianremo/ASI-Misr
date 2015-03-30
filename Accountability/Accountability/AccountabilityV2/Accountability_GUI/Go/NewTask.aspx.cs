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

namespace TSN.ERP.WebGUI.Go
{
	/// <summary>
	/// Summary description for NewTask.
	/// </summary>
	public partial class NewTask : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{

			// Put user code to initialize the page here
			//CTask task = new CTask((int)Session["ProjectID"],Session["ProjectName"].ToString()); 
			//Session["task"] = task;
			PlaceHolder1.Controls.Add(LoadControl("ctlTask.ascx"));
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
			this.ImageButton1.Click += new System.Web.UI.ImageClickEventHandler(this.ImageButton1_Click);

		}
		#endregion

		protected void LinkButton1_Click(object sender, System.EventArgs e)
		{
			//Session["BackToProjectTask"] = 1;
			//Response.Redirect("../Navigation/ContentPage.aspx?uc=go/ProjectsList.ascx");
		}

		private void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Session["BackToProjectTask"] = 1;
			Response.Redirect("../Navigation/ContentPage.aspx?uc=go/ProjectsList.ascx");
		}

	}
}
