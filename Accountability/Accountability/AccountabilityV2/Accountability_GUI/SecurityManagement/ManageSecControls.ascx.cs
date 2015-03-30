namespace TSN.ERP.WebGUI.SecurityManagement
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for ManageSecControls.
	/// </summary>
	public partial class ManageSecControls : System.Web.UI.UserControl
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}
		#endregion

		protected void TabStrip2_SelectedIndexChange(object sender, System.EventArgs e)
		{
			if ( TabStrip2.SelectedIndex == 0 )
			{
				Panel1.Visible = true;
				Panel3.Visible = false;
				Panel4.Visible = false;
				Panel5.Visible = false;
				Panel2.Visible = false;
			}
			if ( TabStrip2.SelectedIndex == 1 )
			{
				Panel2.Visible = true;
				Panel3.Visible = false;
				Panel4.Visible = false;
				Panel5.Visible = false;
				Panel1.Visible = false;
			}
			if ( TabStrip2.SelectedIndex == 2 )
			{
				//Panel3.Visible = true;
				Panel5.Visible = true;
				Panel2.Visible = false;
				Panel1.Visible = false;
			}

		}

		protected void RadioButtonList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( RadioButtonList1.SelectedValue == "1" )
			{
				Panel3.Visible = true;
				Panel4.Visible = false;
			}
			else
			{
				Panel4.Visible = true;
				Panel3.Visible = false;
			}
		}
	}
}
