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
	public partial class Top : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected ImageButton HomeLink;

		protected void Page_Load(object sender, System.EventArgs e)
		{
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

			Ajax.Utility.RegisterTypeForAjax(typeof(Top));
			// Put user code to initialize the page here
			try
			{
				
				fillLinks();
				if (HomeLink!=null && !IsPostBack)
					buttonClick(HomeLink,new System.EventArgs());
			}

			catch ( Exception ee )
			{
				//Navigation.BaseObject.showMessage ( ee.Message , this.Page );
				Page.Parent.ResolveUrl("../index.aspx");
			}


            //DataSet dsFunctionalities = guiWS.ViewUserFunctionalities(HomeLinkID);
            //if (dsFunctionalities.Tables[0].Rows.Count > 1)
            //{
            //    TD2.Visible = true;
            //}
            //else
            //{
            //    TD2.Visible = false;
            //}
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

		#region fillLinks

		void fillLinks()
		{
			GUIWS.GUI guiWS = ((Navigation.BaseObject) Session[ "navigation" ]).GUIWsObject;
			int moduleID = ((Navigation.BaseObject) Session[ "navigation" ]).Module ;
			int HomeLinkID = ((Navigation.BaseObject) Session[ "navigation" ]).Link ;
			DataSet ds = guiWS.ViewUserLinks( moduleID );
			TD1.Controls.Clear();
			
			if ( ds.Tables[ 0 ].Rows.Count != 0 )
			{
				for ( int i = 0 ; i < ds.Tables[ 0 ].Rows.Count ; i++ )
				{
					if ( ds.Tables[ 0 ].Rows[ i ][ "LinkVisible" ].ToString() == "True" )
					{
						// check if the user is admin or MFG admin or MFG employee to view Manufacturing Link
						if( ds.Tables[ 0 ].Rows[ i ][ "LinkCaption" ].ToString() == "Manufacturing" && ( !((Navigation.BaseObject) Session[ "navigation" ]).SecInfo.IsAdministrator && !((Navigation.BaseObject) Session[ "navigation" ]).MFGWSObject.UserIsMFGAdminOrEmployee() ))
							//break;
						continue;

                        ImageButton lb = new ImageButton();







                        lb.Attributes.Add("onclick", "DisplaySaveMessage('1');"); 









                        //lb.CssClass = "tabtext";
                        //lb.Text = ds.Tables[ 0 ].Rows[ i ][ "LinkCaption" ].ToString();
						lb.ID = "L" + ds.Tables[ 0 ].Rows[ i ][ "LinkID" ].ToString();
						lb.Click += new ImageClickEventHandler( buttonClick );
                        //lb.ImageUrl = "../Go/images/EmployeeSheet_n.jpg";
                        string linkCaption = ds.Tables[0].Rows[i]["LinkCaption"].ToString();
                        lb.ImageUrl = "../Go/images/TopLinks/" + linkCaption + "_n.jpg";
                        lb.Attributes.Add("onmouseover", "this.src='../Go/images/TopLinks/" + linkCaption + "_o.jpg'");
                        lb.Attributes.Add("onmouseout", "this.src='../Go/images/TopLinks/" + linkCaption + "_n.jpg'");
                        lb.Attributes.Add("onmousedown", "this.src='../Go/images/TopLinks/" + linkCaption + "_s.jpg'");
                        lb.ToolTip = linkCaption;
						if (HomeLinkID == (int)ds.Tables[ 0 ].Rows[ i ][ "LinkID" ])
							HomeLink = lb;
						HtmlTableCell cell = new HtmlTableCell();
						cell.VAlign = "bottom";                        
                        
						//cell.Attributes[ "class" ] = "unselectedTap";
						cell.Controls.Add (lb);
						TD1.Controls.Add ( cell );
                        //Literal ltr = new Literal();
                        //ltr.Text = "|";
                        //cell.Controls.Add(ltr);
						
					}		
				}
			
			}
		}


		#endregion 

		#region fillFunctionalities

		void fillFunctionalities()
		{
			
			if ( ((Navigation.BaseObject) Session[ "navigation" ]).Link != 0 ) 
			{
				TD2.Controls.Clear();
                TD2.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"));

				GUIWS.GUI guiWS = ((Navigation.BaseObject) Session[ "navigation" ]).GUIWsObject;
				
				int linkID = ((Navigation.BaseObject) Session[ "navigation" ]).Link ;
				DataSet ds = guiWS.ViewUserFunctionalities( linkID );

				if ( ds.Tables[ 0 ].Rows.Count != 0 )
				{
					for ( int i = 0 ; i < ds.Tables[ 0 ].Rows.Count ; i++ )
					{
						if ( ds.Tables[ 0 ].Rows[ i ][ "GFunVisible" ].ToString() == "True" )
						{
							HyperLink l = new HyperLink();

							if( i == 0 )
								l.CssClass = "selectedsublinks";
							else
								l.CssClass = "unselectedsublinks";
                            l.Text = ds.Tables[0].Rows[i]["GFunName"].ToString();
							l.ID =  "Func" + ds.Tables[ 0 ].Rows[ i ][ "GFunID" ].ToString();							
                            //if (i == 0)
                            //{
                            //    l.ImageUrl = "../Go/images/SubLinks/" + l.Text + "_s.gif";
                            //}
                            //else
                            //{
                                l.ImageUrl = "../Go/images/SubLinks/" + l.Text + "_n.jpg";
                            //}
                            l.Attributes["onclick"] = "changeLink(id)";
                            string imgMouseOver = "../Go/images/SubLinks/" + l.Text + "_o.jpg";
                            string imgMouseDown = "../Go/images/SubLinks/" + l.Text + "_s.jpg";
                            string imgMouseOut = "../Go/images/SubLinks/" + l.Text + "_n.jpg";
                            //document.getElementById( s ).children[0].setAttribute('src',newSrc)
                            l.Attributes["onmouseover"] = "document.getElementById( '" + l.ClientID + "' ).children[0].setAttribute('src','" + imgMouseOver + "')";
                            l.Attributes["onmousedown"] = "document.getElementById( '" + l.ClientID + "' ).children[0].setAttribute('src','" + imgMouseDown + "')";
                            l.Attributes["onmouseout"] = "document.getElementById( '" + l.ClientID + "' ).children[0].setAttribute('src','" + imgMouseOut + "')";
                            //l.Attributes["onmouseover"] = "this.src='" + imgMouseOver + "',alert('Mouse Over')";
                            //l.Attributes["onmousedown"] = "this.src='" + imgMouseDown + "',alert('Mouse Down')";
                            //l.Attributes["onmouseout"] = "this.src='" + imgMouseOut + "',alert('Mouse Out')";
							l.ToolTip = l.Text;
							((Navigation.BaseObject) Session[ "navigation" ]).UserControl = ds.Tables[ 0 ].Rows[ i ][ 3 ].ToString();
							l.NavigateUrl  = "ContentPage.aspx?uc=" + ds.Tables[ 0 ].Rows[ i ][ 3 ].ToString() + "&hid=" + l.ID.Remove( 0 , 4 ) ;
							l.Target = "Content";
							TD2.Controls.Add( l );                                                                                   
                            //TD2.Controls.Add( new LiteralControl ( "&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;" ) ) ;
                            TD2.Controls.Add(new LiteralControl("&nbsp;"));                            

						}
					}                      
					
				}
                //If number of sub links is 0 or 1 hide the sub links bar else show it
                if (ds.Tables[0].Rows.Count > 1)
                {
                    //TD2.Visible = true;
                    TD2.Style.Add(HtmlTextWriterStyle.Display, "inline");
                    tblSubLinks.Visible = true;
                }
                else
                {
                    //TD2.Visible = false;
                    TD2.Style.Add(HtmlTextWriterStyle.Display, "none");
                    tblSubLinks.Visible = false;                   
                }
			}
		}


		#endregion 

		#region On Link Click 
		
		void buttonClick ( object sender  , System.EventArgs e )
		{
			try
			{
                // check if accountability form has been changed without saving
                if (((Navigation.BaseObject)Session["navigation"]).UserControl == "Go/frmAccountability.aspx" && Session["SheetStatus"] != null && Session["SheetStatus"].ToString() == "Modified")
                {
                    fillFunctionalities();
                    ViewState["LastSelectedLink"] = Convert.ToInt32(((ImageButton)sender).ID.ToString().Substring(1));
                    //((Navigation.BaseObject) Session[ "navigation" ]).Link 
                    return;
                }

				// for content page 
//				((Navigation.BaseObject) Session[ "navigation" ]).UserControl = "" ;
//				string frameScript2 = "<script language='javascript'> parent.document.getElementById('Content').src = 'Navigation/ContentPage.aspx' </script>";
//				Page.Registe0StartupScript("FrameScript2", frameScript2);

                // modify the CSS of the previouse Tap and selected Tap
                for (int i = 0; i < TD1.Controls.Count; i++)
                {
                    if (TD1.Controls[i].GetType().ToString() == "System.Web.UI.HtmlControls.HtmlTableCell")
                    {
                        ////////////////////((HtmlTableCell)TD1.Controls[i]).Attributes["class"] = "unselectedTap";
                        ////////////////////////((ImageButton)(TD1.Controls[i].Controls[0])).CssClass = "tabtext";
                        ((ImageButton)(TD1.Controls[i].Controls[0])).ImageUrl = ((ImageButton)(TD1.Controls[i].Controls[0])).ImageUrl.Replace("_s.jpg", "_n.jpg");
                        ((ImageButton)(TD1.Controls[i].Controls[0])).Attributes.Add("onmouseout", "this.src='" + ((ImageButton)(TD1.Controls[i].Controls[0])).ImageUrl.Replace("_s.jpg", "_n.jpg") + "'");
                        ((ImageButton)(TD1.Controls[i].Controls[0])).Attributes.Add("onmouseover", "this.src='" + ((ImageButton)(TD1.Controls[i].Controls[0])).ImageUrl.Replace("_n.jpg", "_o.jpg") + "'");
                    }
                }
                ////////////////////((HtmlTableCell)((ImageButton)sender).Parent).Attributes["class"] = "selectedTap";
                ////////////////////((ImageButton)sender).CssClass = "tabselectedtext";
                //////////////////////((ImageButton)sender).ImageUrl = ((ImageButton)sender).ImageUrl.Replace("_n.jpg", "_s.jpg");
                ((ImageButton)sender).Attributes.Add("onmouseout", "this.src='" + ((ImageButton)sender).ImageUrl.Replace("_o.jpg", "_n.jpg") + "'");
                ((ImageButton)sender).Attributes.Add("onmouseover", "this.src='" + ((ImageButton)sender).ImageUrl.Replace("_n.jpg", "_o.jpg") + "'");
                lblScreenName.Text = ((ImageButton)sender).ToolTip;
				
				// get selected link ID
				((Navigation.BaseObject) Session[ "navigation" ]).Link = Convert.ToInt32( ((ImageButton)sender).ID.ToString().Substring( 1 ) );

				// fill selected link functionalities
				fillFunctionalities();
				
				// load first user control
				if ( TD2.Controls.Count > 1 )
				{
				
					HyperLink link = (HyperLink) TD2.Controls[ 1 ];
					string usrCtr = link.NavigateUrl.Substring( link.NavigateUrl.IndexOf( '=' )+ 1 );
					((Navigation.BaseObject) Session[ "navigation" ]).UserControl = usrCtr;
					((Navigation.BaseObject) Session[ "navigation" ]).Function =  int.Parse(link.ID.Remove( 0 , 4 ));
					string frameScript = "<script language='javascript'> parent.document.getElementById('Content').src = 'Navigation/ContentPage.aspx?uc=" + usrCtr +"'</script>";
					//string frameScript = "<script language='javascript'>parent.Content.window.location.href = 'Navigation/ContentPage.aspx?uc=" + usrCtr +"'</script>";
					//string frameScript = "<script language='javascript'>parent.frames[1].window.location.href = 'Navigation/ContentPage.aspx?uc=" + usrCtr +"'</script>";
					Page.RegisterStartupScript("FrameScript", frameScript);
				}
			}
			catch( Exception ee )
			{
				Navigation.BaseObject.showMessage (  ee.Message , this.Page );
			}
		}


		#endregion 

		#region buttonClick2 

		protected void buttonClick2 ( object sender , EventArgs e )
		{
			try
			{
				((Navigation.BaseObject) Session[ "navigation" ]).UserControl = ((LinkButton)sender).Attributes[ "controlName" ] ;
				string frameScript = "<script language='javascript'> window.parent.frames('Content').location='ContentPage.aspx';</script>";
				Page.RegisterStartupScript("FrameScript", frameScript);
			}
			catch ( Exception ee )
			{
				Navigation.BaseObject.showMessage (  ee.Message , this.Page );
			}
		}

		#endregion 

		#region Logg Off
		private void lnkLogOff_Click(object sender, System.EventArgs e)
		{
			((Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.LogOff();

			//Record that the user has logged off
			((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.UpdateUserLogin(DateTime.Now, int.Parse(Session["CurrentLoggedID"].ToString()));

			Page.Parent.ResolveUrl("../index.aspx");
		}

		#endregion

		protected void ButtonAccSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				// modify the CSS of the previouse Tap and selected Tap
				for( int i = 0 ; i < TD1.Controls.Count ; i++ )
				{
                    if ( TD1.Controls[ i ].GetType().ToString() == "System.Web.UI.HtmlControls.HtmlTableCell" )
					{
                        ////////////////////((HtmlTableCell)TD1.Controls[ i ]).Attributes[ "class" ] = "unselectedTap";
                        ////////////////////((ImageButton)(TD1.Controls[ i ].Controls[0])).CssClass = "tabtext";
                        ((ImageButton)(TD1.Controls[i].Controls[0])).ImageUrl = ((ImageButton)(TD1.Controls[i].Controls[0])).ImageUrl.Replace("_s.jpg", "_n.jpg");
                        ((ImageButton)(TD1.Controls[i].Controls[0])).Attributes.Add("onmouseout", "this.src='" + ((ImageButton)(TD1.Controls[i].Controls[0])).ImageUrl.Replace("_s.jpg", "_n.jpg") + "'");
                        ((ImageButton)(TD1.Controls[i].Controls[0])).Attributes.Add("onmouseover", "this.src='" + ((ImageButton)(TD1.Controls[i].Controls[0])).ImageUrl.Replace("_n.jpg", "_o.jpg") + "'");

                        if (((ImageButton)(TD1.Controls[i].Controls[0])).ID.Substring(1) == ViewState["LastSelectedLink"].ToString())
						{
                            ////////////////////((HtmlTableCell)TD1.Controls[ i ]).Attributes[ "class" ] = "selectedTap";
                            ////////////////////((ImageButton)(TD1.Controls[i].Controls[0])).CssClass = "tabselectedtext";
                            ((ImageButton)(TD1.Controls[i].Controls[0])).ImageUrl = ((ImageButton)(TD1.Controls[i].Controls[0])).ImageUrl.Replace("_n.jpg", "_s.jpg");
                            ((ImageButton)(TD1.Controls[i].Controls[0])).Attributes.Add("onmouseout", "");
                            ((ImageButton)(TD1.Controls[i].Controls[0])).Attributes.Add("onmouseover", "");
						}
					}
				}

				// fill selected link functionalities
				((Navigation.BaseObject) Session[ "navigation" ]).Link =  int.Parse( ViewState[ "LastSelectedLink" ].ToString() );
				fillFunctionalities();
				
				// load first user control
				if ( TD2.Controls.Count > 1 )
				{
				
					HyperLink link = (HyperLink) TD2.Controls[ 1 ];
					string usrCtr = link.NavigateUrl.Substring( link.NavigateUrl.IndexOf( '=' )+ 1 );
					((Navigation.BaseObject) Session[ "navigation" ]).UserControl = usrCtr;
					((Navigation.BaseObject) Session[ "navigation" ]).Function =  int.Parse(link.ID.Remove( 0 , 4 ));
					string frameScript = "<script language='javascript'> parent.document.getElementById('Content').src = 'Navigation/ContentPage.aspx?uc=" + usrCtr +"'</script>";
					Page.RegisterStartupScript("FrameScript", frameScript);
				}

				Session[ "SheetStatus" ] = null;
			}
			catch( Exception ee )
			{
				Navigation.BaseObject.showMessage (  ee.Message , this.Page );
			}
		}

		[Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
		public void LogOut(bool CheckClosed)
		{
			//			if(CheckClosed)
			//			{
			//Record that the user has logged off
			((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.UpdateUserLogin(DateTime.Now, int.Parse(Session["CurrentLoggedID"].ToString()));
			//			}
		}
	}
}
