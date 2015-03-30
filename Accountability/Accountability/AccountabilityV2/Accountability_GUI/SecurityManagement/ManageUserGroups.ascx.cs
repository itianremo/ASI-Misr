namespace TSN.ERP.WebGUI.SecurityManagement
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using TSN.ERP.WebGUI.Navigation;

	/// <summary>
	///		Summary description for ManageUserGroups.
	/// </summary>
	public partial class ManageUserGroups : System.Web.UI.UserControl
	{
		protected TSN.ERP.WebGUI.Data.DataSetGroups dataSetGroups1;
		protected TSN.ERP.WebGUI.Data.DataSetRuleGroup dataSetRuleGroup1;
		protected TSN.ERP.WebGUI.Data.DataSetUser dataSetUser1;
        public int userGroupID = 0;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			lblRequired.Text = "";
			if (!IsPostBack) 
			{
				btnRemoveUser.Attributes.Add("onclick","Checkusersfordelete()");
				btnDeleteUserGroups.Attributes.Add("onclick","Checkusergroupsfordelete()");
				BindGroups();
				
			}
            
			if ((string)Session["Action"] == "1")
			{

				BindUsersAccounts(Convert.ToInt32(Session["userGroupID"])) ;
				BindGroupRoles(Convert.ToInt32(Session["userGroupID"]));
				Session["Action"] = "0";
			} 
			
		}
		#region Multi datagrid Users CheckBoxes Selector

		protected void chkUsersHeader_CheckedChanged(object a, System.EventArgs b)
		{
			CheckBox chk1=(CheckBox)a;
			if(chk1.Checked)
			{
				foreach(DataGridItem item in dgUsers.Items)
				{
					if(item.ItemType==ListItemType.Item||item.ItemType==ListItemType.AlternatingItem)
					{
						CheckBox SelectUser=(CheckBox)item.FindControl("SelectUser");
						SelectUser.Checked=true;
					}
				}
			}
			else
			{
				foreach(DataGridItem item in dgUsers.Items)
				{
					if(item.ItemType==ListItemType.Item||item.ItemType==ListItemType.AlternatingItem)
					{
						CheckBox SelectUser=(CheckBox)item.FindControl("SelectUser");
						SelectUser.Checked=false;
					}
				}
			}
		}
		

		
		#endregion


		#region Multi datagrid Roles CheckBoxes Selector

		protected void chkRolesHeader_CheckedChanged(object a, System.EventArgs b)
		{
			CheckBox chk1=(CheckBox)a;
			if(chk1.Checked)
			{
				foreach(DataGridItem item in dgRoleGroups.Items)
				{
					if(item.ItemType==ListItemType.Item||item.ItemType==ListItemType.AlternatingItem)
					{
						CheckBox SelectRole=(CheckBox)item.FindControl("SelectRole");
						SelectRole.Checked=true;
					}
				}
			}
			else
			{
				foreach(DataGridItem item in dgRoleGroups.Items)
				{
					if(item.ItemType==ListItemType.Item||item.ItemType==ListItemType.AlternatingItem)
					{
						CheckBox SelectRole=(CheckBox)item.FindControl("SelectRole");
						SelectRole.Checked=false;
					}
				}
			}
		}
		
		#endregion


		#region Bind DataGroups 
		
		public DataSet BindGroups()
		{	
			dataSetGroups1.Clear();
			BaseObject.SafeMerge(dataSetGroups1,((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.GetAllUsersGroups());
			dgUserGroupName.DataBind();
//			userGroupID = Convert.ToInt32(dgUserGroupName.Items[0].Cells[0].Text);
			userGroupID = Convert.ToInt32(dgUserGroupName.SelectedItem.Cells[0].Text);
			Session["userGroupID"] = userGroupID ;
			//// Call Bind Default Users in Data Group
			BindDefaultUsers(userGroupID);
			//// Call Bind Default User Group Roles
            BindGroupRoles(userGroupID);
			return dataSetGroups1;
		}
		
		#endregion

		#region BindUsers from DataGroups

	    // Bind Default Users in Data Group
		private void BindDefaultUsers(int userGroupID)
		{
			dataSetUser1.Clear();
			BaseObject.SafeMerge(dataSetUser1,((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.GetAllUsersInUserGroup(userGroupID));
			dgUsers.DataBind();
		
		}
		
		// Bind Users in DataGroup By Sender Group ID
		protected void BindDataGroupsUsers (object sender , System.EventArgs e )
		{
			
			DataGridItem itm = (DataGridItem) ((LinkButton) sender).Parent.Parent;
			dgUserGroupName.SelectedIndex = itm.ItemIndex;
			userGroupID = Convert.ToInt32(itm.Cells[0].Text); 
			Session["userGroupID"] = userGroupID ;
			BindUsersAccounts( userGroupID );
            BindGroupRoles(userGroupID);

			

		}

		#endregion

		# region Bind Users 
	
		private void BindUsersAccounts(int userGroupID)
		{
			dataSetUser1.Clear();
			BaseObject.SafeMerge(dataSetUser1, ((BaseObject)Session[ "navigation" ]).SecurityWsObject.GetAllUsersInUserGroup(userGroupID));
			dgUsers.DataBind();
		}
		
		#endregion

		# region Bind User Group Roles
	
		private void BindGroupRoles(int userGroupID)
		{
			dataSetRuleGroup1.Clear();
			BaseObject.SafeMerge(dataSetRuleGroup1,((Navigation.BaseObject) Session[ "navigation" ]).GUIWsObject.ViewRulesGroupsOfUserGroupInModule(((Navigation.BaseObject) Session[ "navigation" ]).Module , userGroupID));  
			dgRoleGroups.DataBind();
		}
		
		#endregion

		#region Delete User Groups
		
		protected void btnDeleteUserGroups_Click(object sender, System.EventArgs e)
		{
			int rowCount =  dgUserGroupName.Items.Count ;
			bool deletedUserGroup = false;
//			int checkedUserGroups = 0;
			for ( int i = rowCount -1   ; i >= 0 ;  i-- )
			{
				CheckBox ch = (CheckBox) dgUserGroupName.Items[ i ].Cells[ 3 ].Controls[ 1 ];
				if ( ch.Checked  ) 
				{
//					checkedUserGroups++;
					int usrGrpID = Convert.ToInt32( dgUserGroupName.Items[ i ].Cells[0].Text );
					if(usrGrpID > 4)
					{
						((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.DeleteUserGroup( usrGrpID );
						deletedUserGroup = true;
					}
					else
					{
						Navigation.BaseObject.showMessage( "You select basic user group , and it is not allowed to delete" , this.Page );					
					}
				}
			}
//			if(checkedUserGroups == 0)
//			{
//				Navigation.BaseObject.showMessage( "You must select a user group to delete" , this.Page );	
//			}
			if(deletedUserGroup)
			{
				Navigation.BaseObject.showMessage( "user group(s) have been deleted successfully" , this.Page );
			}
			//Navigation.BaseObject.showMessage( "user groups have been deleted successfully" , this.Page );
			BindGroups();
		
		}
		#endregion

		#region Add New User Groups
		
		private void buttons(bool flag)
		{
			txtAddGroup.Visible = flag ;
			btnAddGroup.Visible = flag ;
			btnCancel.Visible = flag ;
		    lblRequired.Visible = false ;
		}
		protected void btnNewUserGroup_Click(object sender, System.EventArgs e)
		{
			buttons(true);
		}
		bool CheckUserGroupByName(TSN.ERP.WebGUI.Data.DataSetGroups ds,string GroupName)
		{
			bool flag = true ;
			foreach(DataRow dr in ds.Tables["SEC_UsersGroups"].Rows)
			{
				flag = true;
				if(dr["UserGroupName"].ToString().ToLower().Trim()== GroupName.ToLower())
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
		protected void btnAddGroup_Click(object sender, System.EventArgs e)
		{
			bool Flage = true;
			if (txtAddGroup.Visible == true && txtAddGroup.Text =="")
			{
				lblRequired.Visible = true ;
				return;
			}
			else
			{
				BaseObject.SafeMerge(dataSetGroups1,((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.GetAllUsersGroups());			
				Flage = CheckUserGroupByName(dataSetGroups1,txtAddGroup.Text.Trim());
				if(Flage)
				{
					((BaseObject) Session[ "navigation" ]).SecurityWsObject.AddUserGroup(txtAddGroup.Text);
					BindGroups();
					txtAddGroup.Text = "";
					buttons(false);
					dgUserGroupName.SelectedIndex = 0;
					lblRequired.Visible = true;
					lblRequired.Text ="User group name added successfully";
				}
				else
				{
					lblRequired.Visible = true;
					lblRequired.Text ="This user group name added so far , please try another name";
				}
			}
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			txtAddGroup.Text = "";
			buttons(false);
		}

		#endregion

		#region Remove User(s)
		
		protected void btnRemoveUser_Click(object sender, System.EventArgs e)
		{
			int rowCount =  dgUsers.Items.Count ;
			int userID = 0;
			int SessionUserGroupId = Convert.ToInt32(Session["userGroupID"].ToString());
			for ( int i = rowCount -1   ; i >= 0 ;  i-- )
			{
				CheckBox ch = (CheckBox) dgUsers.Items[ i ].Cells[ 3 ].Controls[ 1 ];
				if ( ch.Checked  ) 
				{
					userID = Convert.ToInt32(dgUsers.Items[ i ].Cells[ 0 ].Text) ;
					((BaseObject) Session[ "navigation" ]).SecurityWsObject.RemoveUserFromGroup(userID,SessionUserGroupId);

				}
			}
			BindDefaultUsers(SessionUserGroupId);
		}
		
		#endregion

		#region Remove Role(s)

		protected void btnRemoveRole_Click(object sender, System.EventArgs e)
		{
			int rowCount =  dgRoleGroups.Items.Count ;
			int RoleGroupId = 0;
			int SessionUserGroupId = Convert.ToInt32(Session["userGroupID"].ToString());
			int counter = 0; 
			for ( int i = rowCount -1   ; i >= 0 ;  i-- )
			{
				CheckBox ch = (CheckBox) dgRoleGroups.Items[ i ].Cells[ 2 ].Controls[ 1 ];
				if ( ch.Checked  ) 
				{
					RoleGroupId = Convert.ToInt32(dgRoleGroups.Items[ i ].Cells[ 0 ].Text) ;
					((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.RemoveRuleGroupFromUserGroup(SessionUserGroupId,RoleGroupId);
					counter++;
				}
			}
			if( counter > 0 )
				BindGroupRoles(SessionUserGroupId);
			else
				Navigation.BaseObject.showMessage( "Please select role to delete" , this.Page );	
				
		}

		#endregion

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
			this.dataSetRuleGroup1 = new TSN.ERP.WebGUI.Data.DataSetRuleGroup();
			this.dataSetUser1 = new TSN.ERP.WebGUI.Data.DataSetUser();
			((System.ComponentModel.ISupportInitialize)(this.dataSetGroups1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetRuleGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetUser1)).BeginInit();
			// 
			// dataSetGroups1
			// 
			this.dataSetGroups1.DataSetName = "DataSetGroups";
			this.dataSetGroups1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dataSetRuleGroup1
			// 
			this.dataSetRuleGroup1.DataSetName = "DataSetRuleGroup";
			this.dataSetRuleGroup1.EnforceConstraints = false;
			this.dataSetRuleGroup1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dataSetUser1
			// 
			this.dataSetUser1.DataSetName = "DataSetUser";
			this.dataSetUser1.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.dataSetGroups1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetRuleGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetUser1)).EndInit();

		}
		#endregion

	}
}
