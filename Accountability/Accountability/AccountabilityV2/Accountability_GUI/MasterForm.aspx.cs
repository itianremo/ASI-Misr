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
	/// Summary description for MasterForm.
	/// </summary>
	public partial class MasterForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
            // added by moawad 01/07/2009 to solve problem of ie8
            //HtmlMeta m = new HtmlMeta();
            //m.HttpEquiv = "X-UA-Compatible";
            //System.Windows.Forms.WebBrowser b = new System.Windows.Forms.WebBrowser();
            //int version=b.Version.Build;

            //if (version==8)
            //{
            //m.Content = "IE=EmulateIE7";
            //Page.Header.Controls.Add(m);
            //}
            //
            
               
			//Session["logoff"]=false;
			// Register this form as Ajax compliant
			Ajax.Utility.RegisterTypeForAjax(typeof(MasterForm));
			
			if(Session[ "navigation" ]==null)
			{
				Response.Redirect("index.aspx");
			}

//			//Check if the current page is open from index.aspx not from the browser directly (I mean from a new tab in IE)
//			if(Session["ComeFromIndexPage"] == null)
//			{
//				Response.Redirect("index.aspx");
//			}
			Session["ComeFromIndexPage"] = null;

		}

//		[Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
//		public string SetDataLogout()
//		{
//			string vslogout="Hamdy";
//
//			return vslogout;
//		}


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
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
        public string SetIEVersionSession(string version)
        {
            Session["IEVersion"] = version;
            return version;

        }
	}
}
