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
using System.Configuration;

namespace TSN.ERP.WebGUI.Navigation
{
	/// <summary>
	/// Summary description for Top.
	/// </summary>
    public partial class Bottom : System.Web.UI.Page
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
            // added by moawad to solve problem of ie8
            //HtmlMeta m = new HtmlMeta();
            //m.HttpEquiv = "X-UA-Compatible";
            //System.Windows.Forms.WebBrowser b = new System.Windows.Forms.WebBrowser();
            //int version = b.Version.Build;

            ////bool flag = true;
            //if (version == 8)
            //{
            //    m.Content = "IE=EmulateIE7";
            //    Page.Header.Controls.Add(m);
            //}
            //
            lblDate.Text = DateTime.Now.ToString("dddd MMMM dd,yyyy h:mm tt");
            lblBuild.Text = ConfigurationManager.AppSettings["BuildNo"];

            int ContactID = -1;
            ContactID = Convert.ToInt32(Session["LoginContactID"]);
            DataSet dsContact = ((Navigation.BaseObject)Session["navigation"]).AccountabilityWSObject.ViewAccountabilityEmployees();
            try
            {
                    lblLoggedUser.Text = dsContact.Tables[0].Rows.Find(ContactID)["Fullname"].ToString().Trim();
            }
            catch
            {
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
