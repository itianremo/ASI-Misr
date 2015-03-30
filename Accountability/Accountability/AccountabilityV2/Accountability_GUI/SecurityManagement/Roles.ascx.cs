namespace TSN.ERP.WebGUI.SecurityManagement
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Collections;

	/// <summary>
	///		Summary description for Roles.
	/// </summary>
	public partial class Roles : System.Web.UI.UserControl
	{
		protected TSN.ERP.WebGUI.Data.DataSetRuleGroup dataSetRuleGroup;
		protected TSN.ERP.WebGUI.Data.DataSetRuleEntity dataSetRuleEntity;
		protected System.Data.DataView dvRuleEntity;
		protected System.Data.DataView dvRulesGroup;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					GetRolesData();	
					BindRulesGroupDataGrid();
					FormatControls();
					ViewState["action"]="save";
					//btnDelete.Attributes.Add( "onclick" , "if(confirm('Are you sure you want to delete this role?')){}else{return false}" );

					if(Session["slectedRoleIndex"]!=null && int.Parse(Session["slectedRoleIndex"].ToString()) > 0 )
					{
						
						int selectedIndex=(int)Session["slectedRoleIndex"];
						dgRulesGroup.SelectedIndex=selectedIndex;
						if(selectedIndex > dgRulesGroup.Items.Count-1 || selectedIndex < 0)
						{
							selectedIndex = 0 ;
						}
						DataGridItem dgSelectedItem=dgRulesGroup.Items[selectedIndex];
						int roleID=int.Parse(dgSelectedItem.Cells[0].Text);
						Session["roleID"]=roleID;
						GetRuleEntitesData(roleID);
						BindRoleEntitiesListBox();
						LinkButton lnkRoleName=(LinkButton)dgSelectedItem.FindControl("lnkRoleName");
						this.txtRoleName.Text=lnkRoleName.Text;
						txtRoleName.Enabled = true;
						FormatControls();
						this.btnAddEnt.Visible=true;
						selectedRole.Value = roleID.ToString() ;

						//Added by Hamdy Ahmed on 12_11_2007
						btnSave.Visible = true;
						btnDelete.Visible = true;
					}
				
				}
				else
				{
					System.Web.UI.Control ctl = GetPostBackControl( this.Page );
					if( ctl == null )
					{
						dataSetRuleEntity.Clear();
						GetRuleEntitesData( Convert.ToInt32( Session["roleID"] ) );
						BindRoleEntitiesListBox();
						//lbRuleEntities.DataBind();
						lbRuleEntities.Visible = true;
					}
					
				}
			}
			catch(Exception ex)
			{
                Response.Write(ex.ToString());
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
			this.dataSetRuleGroup = new TSN.ERP.WebGUI.Data.DataSetRuleGroup();
			this.dvRulesGroup = new System.Data.DataView();
			this.dataSetRuleEntity = new TSN.ERP.WebGUI.Data.DataSetRuleEntity();
			this.dvRuleEntity = new System.Data.DataView();
			((System.ComponentModel.ISupportInitialize)(this.dataSetRuleGroup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvRulesGroup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetRuleEntity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvRuleEntity)).BeginInit();
			this.dgRulesGroup.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgRulesGroup_ItemCommand);
			// 
			// dataSetRuleGroup
			// 
			this.dataSetRuleGroup.DataSetName = "DataSetRuleGroup";
			this.dataSetRuleGroup.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvRulesGroup
			// 
			this.dvRulesGroup.Sort = "RuleGroupName";
			this.dvRulesGroup.Table = this.dataSetRuleGroup.SEC_RuleGroup;
			// 
			// dataSetRuleEntity
			// 
			this.dataSetRuleEntity.DataSetName = "DataSetRuleEntity";
			this.dataSetRuleEntity.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvRuleEntity
			// 
			this.dvRuleEntity.Table = this.dataSetRuleEntity.SEC_RuleEntity;
			((System.ComponentModel.ISupportInitialize)(this.dataSetRuleGroup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvRulesGroup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetRuleEntity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvRuleEntity)).EndInit();

		}
		#endregion


		/// <summary>
		/// Binding 'Rules Group' data into 'dgRulesGroup' datagrid
		/// </summary>
		void BindRulesGroupDataGrid()
		{
			dataSetRuleGroup=(TSN.ERP.WebGUI.Data.DataSetRuleGroup)Session["dataSetRuleGroup"];
			dvRulesGroup.Table=dataSetRuleGroup.SEC_RuleGroup;
			dvRulesGroup.Sort = "RuleGroupName" ;
			dgRulesGroup.DataSource=this.dvRulesGroup;
			this.dgRulesGroup.DataBind();
		}

		/// <summary>
		/// Retrieving 'Rules Group' data returned from 'GetAllRuleGroups' web method
		/// </summary>
		void GetRolesData()
		{
			if(Navigation.BaseObject.SafeMerge(this.dataSetRuleGroup,((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.GetAllRuleGroups()))
			{
				Session["dataSetRuleGroup"]=dataSetRuleGroup;
			}
		}

		void BindRoleEntitiesListBox()
		{
			dataSetRuleEntity=(TSN.ERP.WebGUI.Data.DataSetRuleEntity)Session["RuleEntitiesDataInRuleGroup"];
			dvRuleEntity.Table=dataSetRuleEntity.SEC_RuleEntity;
			lbRuleEntities.DataSource=dvRuleEntity;
			lbRuleEntities.DataTextField="RuleEntityDescription";
			lbRuleEntities.DataValueField="RuleEntityID";
			lbRuleEntities.DataBind();

			if(lbRuleEntities.Items.Count > 0)
			{
				ButtonRemoveAccess.Visible = true;
			}
			else
			{
				ButtonRemoveAccess.Visible = false;
			}
		}

		/// <summary>
		/// Controlling the visibility of controls related to data existing into 'RuleEntities'
		/// </summary>
		private void FormatControls()
		{
			if(lbRuleEntities.Items.Count==0)
			{
				this.lbRuleEntities.Visible=false;
				ButtonRemoveAccess.Visible = false;
			}
			else
			{
				this.lbRuleEntities.Visible=true;
				ButtonRemoveAccess.Visible = true;
			}
		}

		/// <summary>
		/// Retrieving list of Rule Entities for selected 'RoleID' from 'dgRulesGroup' datagrid
		/// </summary>
		void GetRuleEntitesData(int roleID)
		{
			Navigation.BaseObject.SafeMerge(this.dataSetRuleEntity,((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.GetAllRuleEntitiesDataInRuleGroup(roleID));
			Session["RuleEntitiesDataInRuleGroup"]=dataSetRuleEntity;
		}

		private void dgRulesGroup_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			

			try
			{
				if(e.Item.ItemType==ListItemType.Item||e.Item.ItemType==ListItemType.AlternatingItem)
				{
					dataSetRuleEntity.Clear();
					int roleID=int.Parse(e.Item.Cells[0].Text);
					Session["roleID"]=roleID;
					GetRuleEntitesData(roleID);
					this.lbRuleEntities.DataBind();
					Session["slectedRoleIndex"]=e.Item.ItemIndex;
					LinkButton lnkRoleName=(LinkButton)e.Item.FindControl("lnkRoleName");
					this.txtRoleName.Text=lnkRoleName.Text;
					FormatControls();
					this.btnAddEnt.Visible=true;
					this.dgRulesGroup.SelectedIndex=e.Item.ItemIndex;
					BindRulesGroupDataGrid();
					ViewState["action"]="save";

					selectedRole.Value = roleID.ToString() ;
					btnSave.Visible   = true;
					btnDelete.Visible = true;
					txtRoleName.Enabled = true;
					btnAddEnt.Visible  = true ;
				}
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
			}
		}

		/// <summary>
		/// Preparing controls for adding new role
		/// </summary>
		private void NewRole()
		{
			try
			{
				ViewState["action"]="new";
                this.txtRoleName.Text="";
				dataSetRuleEntity.Clear();
				lbRuleEntities.DataBind();
				btnSave.Visible   = true;
				btnDelete.Visible = false;
				txtRoleName.Enabled = true;
				btnAddEnt.Visible = false;
				ButtonRemoveAccess.Visible = false;
				this.dgRulesGroup.SelectedIndex = -1;
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
			}
		}

		/// <summary>
		/// Add new RoleEntities to 'lbRuleEntities' listbox
		/// </summary>
		void AddAccess()
		{
			try
			{
                                                
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
			}	
		}

		/// <summary>
		/// Removing slected RoleEntities from 'lbRuleEntities' listbox
		/// </summary>
		void RemoveAccess()
		{
			try
			{
				ArrayList selectedItemsList=new ArrayList();
				int roleID=(int)Session["roleID"];

				for(int x=0;x<lbRuleEntities.Items.Count;x++)
				{
					if(lbRuleEntities.Items[x].Selected)
					{
                        selectedItemsList.Add(lbRuleEntities.Items[x].Value);
					}
				}
				for(int xx=0;xx<selectedItemsList.Count;xx++)
				{
					string item=(string)selectedItemsList[xx];
					int itemValue=int.Parse(item);
					((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.RemoveRuleEntityFromRuleGroup(itemValue,roleID);
				}
				dataSetRuleEntity.Clear();
				GetRuleEntitesData(roleID);
				BindRoleEntitiesListBox();
				FormatControls();
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
			}
		}

		/// <summary>
		/// Saving role changes
		/// </summary>
		/// <param name="RoleName"></param>
		public bool CheckRoleNameForAdd(TSN.ERP.WebGUI.Data.DataSetRuleGroup ds,string RoleName)
		{
			bool flag = true ;
			foreach(DataRow dr in ds.Tables["SEC_RuleGroup"].Rows)
			{
				flag = true;
				if(dr["RuleGroupName"].ToString().ToLower().Trim()== RoleName.ToLower())
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
		public bool CheckRoleNameForEdit(TSN.ERP.WebGUI.Data.DataSetRuleGroup ds,string RoleName,int RoleID)
		{
			bool flag = true ;
			foreach(DataRow dr in ds.Tables["SEC_RuleGroup"].Rows)
			{
				flag = true;
				if(dr["RuleGroupName"].ToString().ToLower().Trim()== RoleName.ToLower() && int.Parse(dr["RuleGroupID"].ToString())!=RoleID)
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

		private void SaveRole(string RoleName)
		{
			try
			{
				//Checking for modification type
				//Modification can be by 'Adding' new role, or by 'Modifying' role name
				string action=(string)ViewState["action"];
				TSN.ERP.WebGUI.Data.DataSetRuleGroup ds;
				//New Role
				if(action=="new")
				{
					ds = (TSN.ERP.WebGUI.Data.DataSetRuleGroup)Session["dataSetRuleGroup"];
					bool Flage = CheckRoleNameForAdd(ds,RoleName.Trim());
					if(Flage)
					{
						((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.AddRuleGroup(RoleName);
						GetRolesData();
						BindRulesGroupDataGrid();
						Navigation.BaseObject.showMessage( "Role has been added successfully" , this.Page);
						txtRoleName.Text = "";


						if(Navigation.BaseObject.SafeMerge(this.dataSetRuleGroup,((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.GetAllRuleGroups()))
						{
							Session["dataSetRuleGroup"]=dataSetRuleGroup;
						}
						DataRow drRule = dataSetRuleGroup.Tables[0].Select("RuleGroupName = '"+RoleName+"'")[0];
						Session["roleID"] = drRule["RuleGroupID"];


						foreach(DataGridItem itm in dgRulesGroup.Items)
						{
							if(((LinkButton)(itm.Cells[1].Controls[1])).Text.Trim() == RoleName.Trim())
							{
								this.dgRulesGroup.SelectedIndex = itm.ItemIndex;
								ViewState["action"] = "save";
								Session["slectedRoleIndex"] = itm.ItemIndex;
								Page.RegisterStartupScript("","<script>document.getElementById( '_ctl0_selectedRole'  ).value = '"+RoleName+"'</script>");
//								dgRulesGroup_ItemCommand(dgRulesGroup, ((LinkButton)(itm.Cells[1].Controls[1])).CommandArgument);
								break;
							}
						}
//						this.dgRulesGroup.SelectedIndex = -1;
						btnAddEnt.Visible = true;
						ButtonRemoveAccess.Visible = true;
						btnDelete.Visible = true;
						txtRoleName.Text = RoleName;
					}
					else
					{
					Navigation.BaseObject.showMessage( "This role name already exists ,please try another one" , this.Page);
					}
				}

				//Modifying Role Name
				else
				{
					int roleID=(int)Session["roleID"];
					ds = (TSN.ERP.WebGUI.Data.DataSetRuleGroup)Session["dataSetRuleGroup"];
					bool Flage = CheckRoleNameForEdit(ds,RoleName.Trim(),roleID);
					if(Flage)
					{
						int selectedIndex=(int)Session["slectedRoleIndex"];
					
						Navigation.BaseObject.SafeMerge(dataSetRuleGroup,((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.GetRuleGroup(roleID));
						DataRow drSelectedRole=(DataRow)dataSetRuleGroup.Tables["SEC_RuleGroup"].Rows[0];
						drSelectedRole["RuleGroupName"]=RoleName;
						((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.ModifyRuleGroup(dataSetRuleGroup);
						GetRolesData();
						BindRulesGroupDataGrid();
						Navigation.BaseObject.showMessage( "Role has been updated successfully" , this.Page);
					}
					else
					{
						Navigation.BaseObject.showMessage( "This role name already exists, please try another one" , this.Page);
					}
				}
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
			}
		}

	
	
		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			if ( txtRoleName.Text.Trim().Length != 0 )
			{
				SaveRole(txtRoleName.Text);	
				
			}
			else
				Navigation.BaseObject.showMessage( "Please enter a role name " , this.Page );
		}

		protected void btnNew_Click(object sender, System.EventArgs e)
		{
            NewRole();	
		}

	
	
		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			int RoleID =Convert.ToInt32( Session["roleID"]);
			try
			{

				if(RoleID > 4 )
				{
					if( ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.DeleteRuleGroup( Convert.ToInt32( Session["roleID"] ) ) )
					{
						Navigation.BaseObject.showMessage( "The role has been deleted successfully" , this.Page );
						GetRolesData();	
						BindRulesGroupDataGrid();
						txtRoleName.Text = "";
						dataSetRuleEntity.Clear();
						lbRuleEntities.DataBind();
						ViewState["action"]="new";
						this.dgRulesGroup.SelectedIndex = -1;
						lbRuleEntities.Visible = false;
						ButtonRemoveAccess.Visible = false;
						btnAddEnt.Visible  = false ;
					}
					else
					{
						Navigation.BaseObject.showMessage( "Please select role to delete" , this.Page );
					}
				}
				else
				{
					Navigation.BaseObject.showMessage( "You select basic role, and it is not allowed to delete it" , this.Page );
					
				}
					
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
			}
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			// check if any item is selected to remove
			bool itemSelected = false;
			foreach( ListItem item in lbRuleEntities.Items )
				if( item.Selected )
				{
					itemSelected = true;
					break;
				}
			
			// remove access
			if( itemSelected )	
				RemoveAccess();
			else
				Navigation.BaseObject.showMessage( "No access is selected to remove" , this.Page );	
		}

		
		public static System.Web.UI.Control GetPostBackControl( System.Web.UI.Page page)
		{
			System.Web.UI.Control control = null;

			string ctrlname = page.Request.Params.Get("__EVENTTARGET");
			if (ctrlname != null && ctrlname != string.Empty)
			{
				control = page.FindControl(ctrlname);
			}
			else
			{
				foreach (string ctl in page.Request.Form)
				{
					System.Web.UI.Control c = page.FindControl(ctl);
					if (c is System.Web.UI.WebControls.Button)
					{
						control = c;
						break;
					}
				}
			}
			return control;
		}

	
		
		
	}
}
