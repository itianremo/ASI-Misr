namespace TSN.ERP.WebGUI.Navigation
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Web.UI;

	/// <summary>
	///		not used to be deleted in next revision
	/// </summary>
	public partial class US_Top : System.Web.UI.UserControl
	{
		protected LinkButton HomeLink;
		protected void Page_Load(object sender, System.EventArgs e)
		{

			try
			{
				
			}

			catch ( Exception ee )
			{
				Navigation.BaseObject.showMessage ( ee.Message , this.Page );
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}
		#endregion
		

	}
}
