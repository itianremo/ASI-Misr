namespace TSN.ERP.WebGUI.SecurityManagement
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for Users.
	/// </summary>
	public partial class Users : System.Web.UI.UserControl
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			lblMSG.Text = "";
			if ( !IsPostBack )
			{
				LoadUsersMenue();
				
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

		#region LoadUsersMenue
		void LoadUsersMenue()
		{
			SecurityWS.SecurityManagement secMang = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject;
//			DataSet dsUsers = secMang.GetAllUsers();
			DataSet dsUsers = secMang.GetAllActiveUsers();
			DropDownListUsers.DataSource = dsUsers;
			DropDownListUsers.DataTextField  = "UserName";
			DropDownListUsers.DataValueField = "UserID";
			DropDownListUsers.DataBind();
			DropDownListUsers.Items.Insert(0,new ListItem("-- Select User--","-1"));
			ViewState[ "user"] =  dsUsers;
		}

		#endregion 

		#region DropDownListUsers_SelectedIndexChanged
		protected void DropDownListUsers_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			SecurityWS.SecurityManagement secMang = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject;
			DataSet ds = (DataSet) ViewState[ "user"] ;
			Data.DataSetUser dsUsr = new TSN.ERP.WebGUI.Data.DataSetUser();
//			ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns["UserID"] };
			dsUsr.Merge( ds );
			Data.DataSetUser.SEC_UsersRow row ;
			
			if ( dsUsr.SEC_Users.Rows.Count != 0 )
			{
				if (DropDownListUsers.SelectedValue == "-1") 
				{
					TextBoxUserName.Text = String.Empty;
					TextBoxPassword.Text = String.Empty;
					TextBoxConfirm.Text  = String.Empty;
					TextBoxPassword.Attributes.Add("value", String.Empty);
					TextBoxConfirm.Attributes.Add("value", String.Empty);
					ButtonUpdateUser.Visible = false;
					return;
				}
				row = (Data.DataSetUser.SEC_UsersRow ) dsUsr.SEC_Users.Rows.Find( Convert.ToInt32( DropDownListUsers.SelectedValue ) );
				
				if ( ! row.IsNull( "UserID" ) )
				{
					TextBoxUserName.Text = row.UserName;
					TextBoxPassword.Text = row.SecPass;
					TextBoxConfirm.Text  = row.SecPass;
					TextBoxPassword.Attributes.Add("value",row.SecPass.ToString());
					TextBoxConfirm.Attributes.Add("value",row.SecPass.ToString());
					if (!row.IsSecAdministratorNull())
					{
						if ( row.SecAdministrator )
							CheckAdmin.Checked = true;
						else
							CheckAdmin.Checked = false;
					}
					
					ButtonAddUser.Visible	 = false;
					ButtonUpdateUser.Visible = true;

				}
			}

			TextBoxUserName.Enabled = false;

		}


		#endregion 

		#region ButtonAddUser_Click

		public bool CheckUserNameExistance(DataSet ds,string UserName)
		{
			bool flag = true ;
			foreach(DataRow dr in ds.Tables["SEC_Users"].Rows)
			{
				flag = true;
				if(dr["UserName"].ToString().ToLower().Trim()== UserName.ToLower())
				{
					flag = false;
					break;
				}				
				else
				{
					flag = true;
				}
			}
			return flag;
		}

		protected void ButtonAddUser_Click(object sender, System.EventArgs e)
		{
			if ( !validateForm() )
				return;
 
			if(Page.IsValid)
			{

				SecurityWS.SecurityManagement secMang = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject;
				//Check if there is a user group has tha same name as the user name
				DataSet dsUserGroups = secMang.GetAllUsersGroups();
				foreach (DataRow dr in dsUserGroups.Tables[0].Rows)
				{
					if (dr["UserGroupName"].ToString().Trim() == TextBoxUserName.Text.Trim())
					{
						lblMSG.Visible = true;
						lblMSG.Text = "There is a user group with the same name as the user name, this is forbidden.";
						return;
					}
				}
				DataSet dsUsers = secMang.GetAllUsers();
//				bool Flage = CheckUserNameExistance(dsUsers,TextBoxUserName.Text.Trim());
//				if(Flage)
//				{
					
				int affectedRows = secMang.AddUser( TextBoxUserName.Text.Trim() , TextBoxPassword.Text , CheckAdmin.Checked , "" );
				if(affectedRows == -1)
				{
					lblMSG.Visible =true;
					lblMSG.Text ="This user name already exists , please try another one";
					return;
				}
				//Navigation.BaseObject.showMessage( "User has been added successfully" , this.Page );
				TextBoxUserName.Text = "";
				TextBoxPassword.Text = "";
				TextBoxConfirm.Text  = "";
				CheckAdmin.Checked	 = false;
				ButtonAddUser.Visible	 = false;
//				ButtonUpdateUser.Visible = true;
				LoadUsersMenue();
				lblMSG.Visible =true;
				lblMSG.Text ="User name added successfully";
//				}
//				else
//				{
//					lblMSG.Visible =true;
//					lblMSG.Text ="This user name already exists , please try another one";
//				}
			}
		}


		#endregion 

		#region ButtonUpdateUser_Click

		protected void ButtonUpdateUser_Click(object sender, System.EventArgs e)
		{
			if ( !validateForm() )
				return;
			if(Page.IsValid)
			{
				SecurityWS.SecurityManagement secMang = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject;
		
		
				DataSet ds = (DataSet) ViewState[ "user"] ;
				Data.DataSetUser dsUsr = new TSN.ERP.WebGUI.Data.DataSetUser();
//				ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns["UserID"] };
				dsUsr.Merge( ds );
			
				dsUsr.SEC_Users[ DropDownListUsers.SelectedIndex -1 ].UserName			= TextBoxUserName.Text.Trim();
				dsUsr.SEC_Users[ DropDownListUsers.SelectedIndex -1 ].SecPass			= TextBoxPassword.Text;
				dsUsr.SEC_Users[ DropDownListUsers.SelectedIndex -1 ].SecAdministrator = CheckAdmin.Checked;

				// modify user
				if ( secMang.ModifyUser( dsUsr ))
					Navigation.BaseObject.showMessage( "User has been updated successfully" , this.Page );
			

				TextBoxUserName.Text = "";
				TextBoxPassword.Text = "";
				TextBoxConfirm.Text  = "";
				TextBoxPassword.Attributes.Add("value","");
				TextBoxConfirm.Attributes.Add("value","");
				CheckAdmin.Checked	 = false;
			
				LoadUsersMenue();

				TextBoxUserName.Enabled = true;
			}
		}


		#endregion 

		#region btnNewUser_Click

		protected void btnNewUser_Click(object sender, System.EventArgs e)
		{
			TextBoxUserName.Text = "";
			TextBoxPassword.Text = "";
			TextBoxConfirm.Text  = "";
			TextBoxPassword.Attributes.Add("value","");
			TextBoxConfirm.Attributes.Add("value","");
			CheckAdmin.Checked	 = false;
			ButtonAddUser.Visible	 = true;
			ButtonUpdateUser.Visible = false;
			TextBoxUserName.Enabled = true;
			DropDownListUsers.SelectedValue = "-1";
		}


		#endregion 
		
		#region Validate

		bool validateForm()
		{
			string msg = "" ;

			if (  TextBoxUserName.Text.Trim().Length == 0 )
				msg = "Please enter the user name";

			if (  msg.Length == 0 && TextBoxPassword.Text.Trim().Length == 0 )
				msg = "Please enter password and confirm password";
			if (  msg.Length == 0 && TextBoxConfirm.Text.Trim().Length == 0 )
				msg = "Please enter password and confirm password";
			
			//else 	if (  msg.Length != 0 && TextBoxPassword.Text.Trim().Length == 0 )
			//	msg += " and password";

			if ( msg.Length != 0 )
				Navigation.BaseObject.showMessage( msg , this.Page );
			
			if ( msg.Length != 0 )
				return false;
			else
				return true;
		}


		#endregion 
	}
}

