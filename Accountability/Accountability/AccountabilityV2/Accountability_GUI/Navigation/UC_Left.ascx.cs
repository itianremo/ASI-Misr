namespace TSN.ERP.WebGUI.Navigation
{
	using System;
	using System.Web.UI;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for UC_Left.
	/// </summary>
	public partial class UC_Left : System.Web.UI.UserControl
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			try
			{
				

				if ( ((Navigation.BaseObject) Session[ "navigation" ]).Link != 0 ) 
				{
					buttonsTable.Controls.Clear();

					GUIWS.GUI guiWS = ((Navigation.BaseObject) Session[ "navigation" ]).GUIWsObject;
				
					int linkID = ((Navigation.BaseObject) Session[ "navigation" ]).Link ;
					DataSet ds = guiWS.ViewUserFunctionalities( linkID );

					if ( ds.Tables[ 0 ].Rows.Count != 0 )
					{
						for ( int i = 0 ; i < ds.Tables[ 0 ].Rows.Count ; i++ )
						{
							if ( ds.Tables[ 0 ].Rows[ i ][ "GFunVisible" ].ToString() == "True" )
							{
								LinkButton lb = new LinkButton();
								lb.Text = ds.Tables[ 0 ].Rows[ i ][ "GFunName" ].ToString();
								lb.ID   = ds.Tables[ 0 ].Rows[ i ][ "GFunID" ].ToString();
								lb.Click += new EventHandler( buttonClick );
								lb.Attributes.Add( "controlName" , ds.Tables[ 0 ].Rows[ i ][ 3 ].ToString() );
					
//								buttonsTable.Controls.Add( new LiteralControl (" <tr><td height='' valign='top'>"));
//								buttonsTable.Controls.Add( lb );
//								buttonsTable.Controls.Add( new LiteralControl ("</td></tr> " ));

								TD2.Controls.Add( lb );
								TD2.Controls.Add( new LiteralControl ( "&nbsp;&nbsp;&nbsp;&nbsp;" ) ) ;
								
							}
						}
					}
				}
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

		#region buttonClick 

		protected void buttonClick ( object sender , EventArgs e )
		{
			try
			{
				((Navigation.BaseObject) Session[ "navigation" ]).Link		  = Convert.ToInt32( ((LinkButton)sender).ID );
				((Navigation.BaseObject) Session[ "navigation" ]).UserControl = ((LinkButton)sender).Attributes[ "controlName" ] ;
				string frameScript = "<script language='javascript'> window.parent.frames(2).location='ContentPage.aspx';</script>";
				Page.RegisterStartupScript("FrameScript", frameScript);
			}
			catch ( Exception ee )
			{
				Navigation.BaseObject.showMessage (  ee.Message , this.Page );
			}
		}

		#endregion 
	}
}
