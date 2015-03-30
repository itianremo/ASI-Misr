namespace TSN.ERP.WebGUI.Security_Management
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using TSN.ERP.WebGUI.Data;


	/// <summary>
	///		Summary description for UserGroups.
	/// </summary>
	public partial class UserGroups : System.Web.UI.UserControl
	{
		protected TSN.ERP.WebGUI.Data.DataSetGroups dataSetGroups1;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			
			
			if ( !IsPostBack )
			{
				// fill usr group menue
				LoadUsrGrpMenue();

				// get all users
				SecurityWS.SecurityManagement secMang = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject;
				DataSet ds = secMang.GetAllUsers();
				ListBoxUsers.DataSource = ds;
				ListBoxUsers.DataTextField  = "UserName";
				ListBoxUsers.DataValueField = "UserID";
				ListBoxUsers.DataBind();

				DataSet ds2 = new DataSet();
				ViewState[ "Ent" ] =  ds2;

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
			this.dataSetGroups1 = new TSN.ERP.WebGUI.Data.DataSetGroups();
			((System.ComponentModel.ISupportInitialize)(this.dataSetGroups1)).BeginInit();
			// 
			// dataSetGroups1
			// 
			this.dataSetGroups1.DataSetName = "DataSetGroups";
			this.dataSetGroups1.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.dataSetGroups1)).EndInit();

		}
		#endregion

		#region Controls Events 
		
		#region AddButton_Click
		protected void AddButton_Click(object sender, System.EventArgs e)
		{
			try
			{
				
				SecurityWS.SecurityManagement secMang = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject;

				int n = secMang.AddUserGroup( TextBoxGroupName.Text ) ;
				if ( n != -1 )
					Response.Write ( "<script language=javascript > alert ( 'The group hase been added sucessefuly' ) </script>" ) ;
				else
					Navigation.BaseObject.showCallErrorMessage( "There has been error in creating user group:" , this.Page , ((Navigation.BaseObject) Session[ "navigation" ]).Token );  
	
				for ( int i = 0 ; i < ListBoxUserGroups.Items.Count ; i++ )
				{
					secMang.AddUserToGroup( n , Convert.ToInt32( ListBoxUserGroups.Items[ i ].Value ) ) ;	
				}
				LoadUsrGrpMenue( );
			}

			catch ( Exception ee )
			{
				Navigation.BaseObject.showMessage (  ee.Message , this.Page );
			}
		}

		#endregion

		#region ButtonOut_Click
		protected void ButtonOut_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataSet ds = (DataSet) ViewState[ "Ent" ];

				for ( int i = 0 ;  i < ListBoxUserGroups.Items.Count ; i++ )
				{
					if ( ListBoxUserGroups.Items[ i ].Selected )
						ds.Tables[ 0 ].Rows.Find( Convert.ToInt32(  ListBoxUserGroups.Items[ i ].Value ) ).Delete();
				}
				ListBoxUserGroups.Items.Clear();
				ListBoxUserGroups.DataSource = ds;
				ListBoxUserGroups.DataBind();
				ViewState[ "Ent" ] = ds;
			}

			catch ( Exception ee )
			{
				Navigation.BaseObject.showMessage (  ee.Message , this.Page );
			}
		}

		#endregion

		#region ButtonIn_Click
		protected void ButtonIn_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataSet ds = (DataSet) ViewState[ "Ent" ];
				ds.EnforceConstraints = false;

				for ( int i = 0 ; i < ListBoxUsers.Items.Count ; i++ )
				{
					if ( ListBoxUsers.Items[ i ].Selected )
					{
						if ( !ListBoxUserGroups.Items.Contains( ListBoxUsers.Items[ i ] ))
						{
							UsrDS ds2 = new UsrDS();
							ds2.EnforceConstraints = false;
							UsrDS.SEC_UsersRow row =  ds2.SEC_Users.NewSEC_UsersRow();
							row.UserID   = Convert.ToInt32( ListBoxUsers.Items[ i ].Value );
							row.UserName = ListBoxUsers.Items[ i ].Text;
							ds2.SEC_Users.AddSEC_UsersRow( row );
							ds.Merge( ds2 );
						}
					}
				}
				ListBoxUserGroups.DataSource = ds;
				ListBoxUserGroups.DataTextField  = "UserName";
				ListBoxUserGroups.DataValueField = "UserID";
				ListBoxUserGroups.DataBind();
				ViewState[ "Ent" ] = ds;
			}
			catch ( Exception ee )
			{
				Navigation.BaseObject.showMessage (  ee.Message , this.Page );
			}
		}

		#endregion 

		#region ButtonUpdate_Click

		protected void ButtonUpdate_Click(object sender, System.EventArgs e)
		{
			try
			{
				if ( DropDownListUsrGroups.SelectedValue != "-1" )
				{
					SecurityWS.SecurityManagement secMang = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject;


					// modify user group
					DataSet ds = (DataSet) ViewState[ "UserGroup" ];
					if ( ds.Tables[ 0 ].Rows.Count != 0 )
						ds.Tables[ 0 ].Rows[ 0 ][ "UserGroupName" ] = TextBoxGroupName.Text;
					if ( ! secMang.ModifyUserGroup( ds ))
						Navigation.BaseObject.showCallErrorMessage( "" , this.Page ,  ((Navigation.BaseObject) Session[ "navigation" ]).Token );


					// modify user group entities
					string userID ;
					DataSet lastDS = (DataSet) ViewState[ "Ent" ];
					DataView view1 = new DataView();
					view1.Table = lastDS.Tables[ 0 ];
					view1.RowStateFilter = DataViewRowState.Deleted;

					for ( int i = 0 ; i < view1.Count ; i++ )
					{
						userID  = view1[ i ][ "UserID" ].ToString();
						secMang.RemoveUserFromGroup( Convert.ToInt32( userID ) , Convert.ToInt32( DropDownListUsrGroups.SelectedValue ) );
					}

					view1.RowStateFilter = DataViewRowState.Added;
					for ( int i = 0 ; i < view1.Count ; i++ )
					{
						userID  = view1[ i ][ "UserID" ].ToString();
						secMang.AddUserToGroup( Convert.ToInt32( DropDownListUsrGroups.SelectedValue ) , Convert.ToInt32( userID ) );
					}

					lastDS.Clear();
					lastDS = secMang.GetAllUsersInUserGroup( Convert.ToInt32( DropDownListUsrGroups.SelectedValue ) );
					ViewState[ "Ent" ] = lastDS;

					LoadUsrGrpMenue( );
				}
			}

			catch ( Exception ee )
			{
				Navigation.BaseObject.showMessage (  ee.Message , this.Page );
			}
		}


		#endregion 

		#region DropDownList1_SelectedIndexChanged

		protected void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( DropDownListUsrGroups.SelectedValue != "-1" )
			{
				((Navigation.BaseObject) Session[ "navigation" ]).Operation = Navigation.BaseObject.OperationType.UPADATE;

				SecurityWS.SecurityManagement secMang = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject;
				dataSetGroups1 = (DataSetGroups) ViewState[ "AllUsrGrp" ] ;
			
				Data.DataSetGroups.SEC_UsersGroupsRow row ;
			
				if ( dataSetGroups1.SEC_UsersGroups.Rows.Count != 0 )
				{
					row = (Data.DataSetGroups.SEC_UsersGroupsRow) dataSetGroups1.SEC_UsersGroups.Rows.Find( Convert.ToInt32( DropDownListUsrGroups.SelectedValue ) );
				
					if ( ! row.IsNull( "UserGroupID" ) )
					{
						
						// get user group
						TextBoxGroupName.Text = row.UserGroupName;
						DataSet dsUG = secMang.GetUserGroup( row.UserGroupID );
						ViewState[ "UserGroup" ]   = dsUG;
					
						// get user group entities
						DataSet ds2 = new DataSet();
						ds2 = secMang.GetAllUsersInUserGroup( Convert.ToInt32( DropDownListUsrGroups.SelectedValue ) );
					
						ListBoxUserGroups.DataSource = ds2;
						ListBoxUserGroups.DataTextField  = "UserName";
						ListBoxUserGroups.DataValueField = "UserID";
						ListBoxUserGroups.DataBind();
						ButtonUpdate.Visible = true ;
						AddButton.Visible	 = false ;
						ViewState[ "Ent" ] =  ds2; 
					
					}
				}
			}
		}


		#endregion

		#region LoadUsrGrpMenue
		void LoadUsrGrpMenue( )
		{
			DropDownListUsrGroups.Items.Clear();
			DataSetGroups.SEC_UsersGroupsRow row = dataSetGroups1.SEC_UsersGroups.NewSEC_UsersGroupsRow();
			row.UserGroupID = -1 ;
			row.UserGroupName = "select user group"; 
			row.UserGroupType = false ;
			dataSetGroups1.SEC_UsersGroups.AddSEC_UsersGroupsRow( row );
			DataSet dsUsrGrp = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.GetAllNonUserGroupsType();
			dataSetGroups1.Merge( dsUsrGrp ); 
			DropDownListUsrGroups.DataBind();
			ViewState[ "AllUsrGrp" ]   = dataSetGroups1;
		}


		#endregion

		#region LinkButton1_Click

		protected void LinkButton1_Click(object sender, System.EventArgs e)
		{
			((Navigation.BaseObject) Session[ "navigation" ]).Operation = Navigation.BaseObject.OperationType.ADD;
			TextBoxGroupName.Text = "" ;
			ListBoxUserGroups.Items.Clear();
			ButtonUpdate.Visible  = false;
			AddButton.Visible	  = true;
			DropDownListUsrGroups.SelectedIndex = 0 ;

		}

		#endregion 

		#endregion 
	
		
	}
}
