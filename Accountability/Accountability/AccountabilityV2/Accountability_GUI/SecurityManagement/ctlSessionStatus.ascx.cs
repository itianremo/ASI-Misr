namespace TSN.ERP.WebGUI.SecurityManagement
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for ctlSessionStatus.
	/// </summary>
	public partial class ctlSessionStatus : System.Web.UI.UserControl
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			Navigation.BaseObject BO = (Navigation.BaseObject)Session["navigation"];
			lblToken.Text = BO.Token;
			try
			{
				lblException.Text =  ((Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.LastInnerException();
			}
			catch
			{
				lblException.Text = "Couldn't retrieve Error Information";
			}
			try
			{
				lblAccessViolation.Text = ((Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.LastSecurityError();
			}
			catch
			{
				lblAccessViolation.Text = "Couldn't Access Information";
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
