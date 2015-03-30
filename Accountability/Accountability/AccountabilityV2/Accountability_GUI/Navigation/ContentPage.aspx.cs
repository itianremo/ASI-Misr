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
	/// Summary description for ContentPage.
	/// </summary>
	public partial class ContentPage : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            // added by moawad 01/07/2009 to solve problem of ie8
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

			// Put user code to initialize the page here
//			if( Session[ "SheetSave" ]!= null &&  Session[ "SheetSave" ].ToString()  == "Cancel" )
//				return;

			if ( ((Navigation.BaseObject) Session[ "navigation" ]).UserControl == null || ((Navigation.BaseObject) Session[ "navigation" ]).UserControl == "" )
					PlaceHolder1.Controls.Clear();

			if( Request.QueryString[ "uc" ] != null )
			{
				string uc     = Request.QueryString[ "uc" ].ToString();
				
				if( Request.QueryString[ "hid" ] != null )
					((Navigation.BaseObject) Session[ "navigation" ]).Function = int.Parse(Request.QueryString[ "hid" ].ToString());

				if ( uc != "" )
				{
					((Navigation.BaseObject) Session[ "navigation" ]).EntityID = -1;
	
					((Navigation.BaseObject) Session[ "navigation" ]).UserControl = uc;
					
					string fileExtenstion = uc.Substring( uc.IndexOf( "." ) + 1 );
					if ( fileExtenstion == "aspx" )	
					try
					{
						
							Response.Redirect( "../" + uc );
					}
					catch( Exception ee )
					{
						Page.RegisterStartupScript( "" , ee.Message );
					}

					else if ( fileExtenstion == "ascx" )	
					{
						string usercontrol =  "../" + uc ;
						PlaceHolder1.Controls.Add ( LoadControl ( usercontrol ) );
					}

					//					if ( uc == "Go/Accountability" )
					//						Response.Redirect( "../go/frmAccountability.aspx" );
					//			
					//					string usercontrol =  "../" + uc  + ".ascx" ;
					//					PlaceHolder1.Controls.Add ( LoadControl  ( usercontrol ) );
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
