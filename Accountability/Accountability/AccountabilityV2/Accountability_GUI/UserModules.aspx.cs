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
	/// Summary description for WebForm1.
	/// </summary>
	public partial class UserModules : System.Web.UI.Page
	{
		string direction ="";	
		protected void Page_Load(object sender, System.EventArgs e)
		{

			Session["ComeFromIndexPage"] = "yes";

			Session["logoff"]=null;
			// Put user code to initialize the page here

			
			((Navigation.BaseObject) Session[ "navigation" ]).Module = 1;
			direction = Request.QueryString["home"];
			
			if ( ! IsPostBack )
			{
				if ( ((Navigation.BaseObject) Session[ "navigation" ]).SecInfo.RulesArray.Count == 0 && !((Navigation.BaseObject) Session[ "navigation" ]).SecInfo.IsAdministrator )
				{
					Label1.Visible = true;
					Table1.Visible= false;
					Table2.Visible= false;
				}

				else
				{
					GUIWS.GUI guiWS = ((Navigation.BaseObject) Session[ "navigation" ]).GUIWsObject;
					DataSet ds = new DataSet();

					if ( !((Navigation.BaseObject) Session[ "navigation" ]).SecInfo.IsAdministrator )
						ds = guiWS.ViewUserModules( );
					
					else
						ds = guiWS.ViewModules( );

					if ( ds.Tables[ 0 ].Rows.Count != 0 )
					{
						DataGrid1.DataSource = ds ;
						DataGrid1.DataBind();
					}
				}
				if(direction=="yes")
				{
					((Navigation.BaseObject) Session[ "navigation" ]).Module = 1;
					((Navigation.BaseObject) Session[ "navigation" ]).Link   = 1 ; 
					Response.Redirect ( "MasterForm.aspx" );

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

		
		protected void GridOnClick ( object sender , System.EventArgs e  )
		{
			try
			{
				DataGridItem itm = (DataGridItem) ((LinkButton) sender).Parent.Parent;
				int moduleID  = Convert.ToInt32( itm.Cells[ 1 ].Text );
				((Navigation.BaseObject) Session[ "navigation" ]).Module = moduleID;
				((Navigation.BaseObject) Session[ "navigation" ]).Link   = 1 ; 
				Response.Redirect ( "MasterForm.aspx" );
			}
			catch( Exception ee )
			{
				Navigation.BaseObject.showMessage (  ee.Message , this.Page );
			}
		}

		protected void cbChangePass_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("SecurityManagement/frmChangePass.aspx");
		}

	}
}
