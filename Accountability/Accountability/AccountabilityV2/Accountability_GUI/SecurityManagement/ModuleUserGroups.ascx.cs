namespace TSN.ERP.WebGUI.SecurityManagement
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for ModuleUserGroups.
	/// </summary>
	public partial class ModuleUserGroups : System.Web.UI.UserControl
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			try
			{
				if (!IsPostBack)
				{
					// fill first UserGroup tree
					FillFirstUserGroupTree(  ref this.TreeViewUserGroup1 );

					// fill first RuleGroup tree
					FillFirstRuleGroupTree( ref this.TreeViewRuleGroup1 );

					// fill second UserGroup tree
					FillSecondUserGroupTree(  ref this.TreeViewUserGroup2 );

					// fill second RuleGroup tree
					FillSecondRuleGroupTree(  ref this.TreeViewRuleGroup2 );
					
				}
			}

			catch ( Exception ee )
			{
				Navigation.BaseObject.showMessage( ee.Message , this.Page );
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
		
		#region First Panel 

		#region FillFirstUserGroupTree

		void FillFirstUserGroupTree( ref Microsoft.Web.UI.WebControls.TreeView tv)
		{
			GUIWS.GUI guiWS = ((Navigation.BaseObject) Session[ "navigation" ]).GUIWsObject ;
			DataSet ds = guiWS.ViewModuleUserGroups( ((Navigation.BaseObject) Session[ "navigation" ]).Module );

			if (ds!=null && ds.Tables.Count>0)
			{
				tv.Nodes.Clear();
				
				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					Microsoft.Web.UI.WebControls.TreeNode treeNode = new Microsoft.Web.UI.WebControls.TreeNode();
					treeNode.Text   = dr["UserGroupName"].ToString();
					treeNode.ID     = "U" + dr["UserGroupID"].ToString();
					tv.Nodes.Add ( treeNode );

					GetRuleGroupsOfUserGroupInModule( treeNode );

				}
			}
		}


		#endregion 
		
		#region AddRuleGroupsToUserGroupNode

		void AddRuleGroupsToUserGroupNode( ref Microsoft.Web.UI.WebControls.TreeView tv, ref Microsoft.Web.UI.WebControls.TreeNode tn, ref DataSet templist)
		{
			if (templist!=null && templist.Tables.Count>0)
			{
				foreach (DataRow dr in templist.Tables[0].Rows)
				{
					
					Microsoft.Web.UI.WebControls.TreeNode treeNode = new Microsoft.Web.UI.WebControls.TreeNode();
					treeNode.Text   = dr["RuleGroupName"].ToString();
					treeNode.ID     = "R" + dr["RuleGroupID"].ToString();
					tn.Nodes.Add ( treeNode );
				}
			}
		}


		#endregion 

		#region GetRuleGroupsOfUserGroupInModule

		void GetRuleGroupsOfUserGroupInModule( Microsoft.Web.UI.WebControls.TreeNode node )
		{
			GUIWS.GUI guiWS = ((Navigation.BaseObject) Session[ "navigation" ]).GUIWsObject ;
			DataSet ds = guiWS.ViewRulesGroupsOfUserGroupInModule( ((Navigation.BaseObject) Session[ "navigation" ]).Module , Convert.ToInt32( node.ID.Remove( 0 , 1 ) ) );
			AddRuleGroupsToUserGroupNode( ref this.TreeViewUserGroup1 , ref node , ref ds );
		}


		#endregion 

		#region FillFirstRuleGroupTree

		void FillFirstRuleGroupTree( ref Microsoft.Web.UI.WebControls.TreeView tv)
		{
			GUIWS.GUI guiWS = ((Navigation.BaseObject) Session[ "navigation" ]).GUIWsObject ;
			DataSet ds = guiWS.ViewModuleRuleGroups( ((Navigation.BaseObject) Session[ "navigation" ]).Module );

			if (ds!=null && ds.Tables.Count>0)
			{
				tv.Nodes.Clear();
				
				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					Microsoft.Web.UI.WebControls.TreeNode treeNode = new Microsoft.Web.UI.WebControls.TreeNode();
					treeNode.Text   = dr["RuleGroupName"].ToString();
					treeNode.ID     = "R" + dr["RuleGroupID"].ToString();
					tv.Nodes.Add ( treeNode );
				}
			}
		}


		#endregion 

		#region ButtonAddRuleGrToUsrGr_Click

		protected void ButtonAddRuleGrToUsrGr_Click(object sender, System.EventArgs e)
		{
			try
			{
				string selectedRuleGrID = getSelectedNodeInTree( TreeViewRuleGroup1 );
				string selectedUserGrID = getSelectedNodeInTree( TreeViewUserGroup1 );
				
				if ( ! selectedUserGrID.StartsWith( "U" ) ) 
				{	
					Navigation.BaseObject.showMessage( "Please select User Group " , this.Page  ) ;
					return;
				}

				SecurityWS.SecurityManagement secMang = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject ;
				if (! secMang.AddRuleGroupToUserGroup( Convert.ToInt32( selectedUserGrID.Remove( 0 , 1 ) ) , Convert.ToInt32( selectedRuleGrID.Remove( 0 , 1 ) ) ))
				{
					Navigation.BaseObject.showCallErrorMessage( "Error in adding rule group to user groups: " , this.Page , ((Navigation.BaseObject) Session[ "navigation" ]).Token ) ;
					return;
				}

				FillFirstUserGroupTree( ref TreeViewUserGroup1 );
			}
			catch ( Exception ee )
			{
				Navigation.BaseObject.showMessage( ee.Message , this.Page ) ;
			}
		}


		#endregion 

		#region ButtonRemoveRuleGrFromUsrGr_Click

		protected void ButtonRemoveRuleGrFromUsrGr_Click(object sender, System.EventArgs e)
		{
			try
			{
				
				Microsoft.Web.UI.WebControls.TreeNode node = TreeViewUserGroup1.GetNodeFromIndex( TreeViewUserGroup1.SelectedNodeIndex );
				string selectedRuleGrID = node.ID;
				
				if ( ! selectedRuleGrID.StartsWith( "R" ) ) 
				{	
					Navigation.BaseObject.showMessage( "Please select Rule Group " , this.Page  ) ;
					return;
				}

				Microsoft.Web.UI.WebControls.TreeNode node2 = (Microsoft.Web.UI.WebControls.TreeNode )node.Parent;
				string selectedUserGrID = node2.ID;
				

				SecurityWS.SecurityManagement secMang = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject ;
				if (! secMang.RemoveRuleGroupFromUserGroup( Convert.ToInt32( selectedUserGrID.Remove( 0 , 1 ) ) , Convert.ToInt32( selectedRuleGrID.Remove( 0 , 1 ) ) ))
				{
					Navigation.BaseObject.showCallErrorMessage( "Error in adding rule group to user groups: " , this.Page , ((Navigation.BaseObject) Session[ "navigation" ]).Token ) ;
					return;
				}

				FillFirstUserGroupTree( ref TreeViewUserGroup1 );
			}
			catch ( Exception ee )
			{
				Navigation.BaseObject.showMessage( ee.Message , this.Page ) ;
			}
		}


		#endregion 

		#region getSelectedNodeInTree

		private string getSelectedNodeInTree( Microsoft.Web.UI.WebControls.TreeView treeView )
		{
			Microsoft.Web.UI.WebControls.TreeNode node = treeView.GetNodeFromIndex( treeView.SelectedNodeIndex );
			return  node.ID;
		}

		#endregion 

		#endregion 
	
		#region Second Panel 

		#region FillSecondUserGroupTree

		void FillSecondUserGroupTree( ref Microsoft.Web.UI.WebControls.TreeView tv)
		{
			SecurityWS.SecurityManagement secMang = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject;
			DataSet ds = secMang.GetAllUsersGroups(  );

			if (ds!=null && ds.Tables.Count>0)
			{
				tv.Nodes.Clear();
				
				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					Microsoft.Web.UI.WebControls.TreeNode treeNode = new Microsoft.Web.UI.WebControls.TreeNode();
					treeNode.Text   = dr["UserGroupName"].ToString();
					treeNode.ID     = "U" + dr["UserGroupID"].ToString();
					tv.Nodes.Add ( treeNode );
				}
			}
		}


		#endregion 
		
		#region FillSecondRuleGroupTree

		void FillSecondRuleGroupTree( ref Microsoft.Web.UI.WebControls.TreeView tv)
		{
			GUIWS.GUI guiWS = ((Navigation.BaseObject) Session[ "navigation" ]).GUIWsObject ;
			DataSet ds = guiWS.ViewModuleRuleGroups( ((Navigation.BaseObject) Session[ "navigation" ]).Module );

			if (ds!=null && ds.Tables.Count>0)
			{
				tv.Nodes.Clear();
				
				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					Microsoft.Web.UI.WebControls.TreeNode treeNode = new Microsoft.Web.UI.WebControls.TreeNode();
					treeNode.Text   = dr["RuleGroupName"].ToString();
					treeNode.ID     = "R" + dr["RuleGroupID"].ToString();
					tv.Nodes.Add ( treeNode );
					GetUserGroupsOfRuleGroupInModule( treeNode , tv );

				}
			}
		}


		#endregion 
		
		#region AddUserGroupsToRuleGroupNode

		void AddUserGroupsToRuleGroupNode( Microsoft.Web.UI.WebControls.TreeView tv, ref Microsoft.Web.UI.WebControls.TreeNode tn, ref DataSet templist)
		{
			if (templist!=null && templist.Tables.Count>0)
			{
				foreach (DataRow dr in templist.Tables[0].Rows)
				{
					
					Microsoft.Web.UI.WebControls.TreeNode treeNode = new Microsoft.Web.UI.WebControls.TreeNode();
					treeNode.Text   = dr["UserGroupName"].ToString();
					treeNode.ID     = "U" + dr["UserGroupID"].ToString();
					tn.Nodes.Add ( treeNode );
				}
			}
		}


		#endregion 

		#region GetUserGroupsOfRuleGroupInModule

		void GetUserGroupsOfRuleGroupInModule( Microsoft.Web.UI.WebControls.TreeNode node , Microsoft.Web.UI.WebControls.TreeView tree )
		{
			GUIWS.GUI guiWS = ((Navigation.BaseObject) Session[ "navigation" ]).GUIWsObject ;
			DataSet ds = guiWS.ViewUsersGroupsOfRuleGroupInModule( ((Navigation.BaseObject) Session[ "navigation" ]).Module , Convert.ToInt32( node.ID.Remove( 0 , 1 ) ) );
			AddUserGroupsToRuleGroupNode( tree , ref node , ref ds );
		}


		#endregion 

		#region ButtonRemoveUserGrFromRuleGr_Click

		protected void ButtonRemoveUserGrFromRuleGr_Click(object sender, System.EventArgs e)
		{	
			try
			{
				Microsoft.Web.UI.WebControls.TreeNode node = TreeViewRuleGroup2.GetNodeFromIndex( TreeViewRuleGroup2.SelectedNodeIndex );
				string selectedUserGrID = node.ID;
				
				if ( ! selectedUserGrID.StartsWith( "U" ) ) 
				{	
					Navigation.BaseObject.showMessage( "Please select User Group " , this.Page  ) ;
					return;
				}

				Microsoft.Web.UI.WebControls.TreeNode node2 = (Microsoft.Web.UI.WebControls.TreeNode )node.Parent;
				string selectedRuleGrID = node2.ID;
				

				SecurityWS.SecurityManagement secMang = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject;
				if (! secMang.RemoveRuleGroupFromUserGroup( Convert.ToInt32( selectedUserGrID.Remove( 0 , 1 ) ) , Convert.ToInt32( selectedRuleGrID.Remove( 0 , 1 ) ) ))
				{
					Navigation.BaseObject.showCallErrorMessage( "Error in adding rule group to user groups: " , this.Page , ((Navigation.BaseObject) Session[ "navigation" ]).Token ) ;
					return;
				}

				FillSecondRuleGroupTree( ref TreeViewRuleGroup2 );
			}
			catch ( Exception ee )
			{
				Navigation.BaseObject.showMessage( ee.Message , this.Page );
			}
		}


		#endregion

		#region ButtonAddUserGrToRuleGr_Click

		protected void ButtonAddUserGrToRuleGr_Click(object sender, System.EventArgs e)
		{
			try
			{
				string selectedUserGrID = getSelectedNodeInTree( TreeViewUserGroup2 );
				string selectedRuleGrID = getSelectedNodeInTree( TreeViewRuleGroup2 );
				
				if ( ! selectedRuleGrID.StartsWith( "R" ) ) 
				{	
					Navigation.BaseObject.showMessage( "Please select Rule Group " , this.Page  ) ;
					return;
				}

				SecurityWS.SecurityManagement secMang = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject;
				if (! secMang.AddRuleGroupToUserGroup( Convert.ToInt32( selectedUserGrID.Remove( 0 , 1 ) ) , Convert.ToInt32( selectedRuleGrID.Remove( 0 , 1 ) ) ))
				{
					Navigation.BaseObject.showCallErrorMessage( "Error in adding rule group to user groups: " , this.Page , ((Navigation.BaseObject) Session[ "navigation" ]).Token ) ;
					return;
				}

				FillSecondRuleGroupTree( ref TreeViewRuleGroup2 );
			}
			catch ( Exception ee )
			{
				Navigation.BaseObject.showMessage( ee.Message , this.Page );
			}
		}


		#endregion 

		
		#endregion 

		protected void RadioButtonList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( RadioButtonList1.SelectedValue == "0" )
			{
				Panel1.Visible = true ;
				Panel2.Visible = false ;
			}
			else
			{
				Panel1.Visible = false ;
				Panel2.Visible = true ;
			}
		}
	}
}
