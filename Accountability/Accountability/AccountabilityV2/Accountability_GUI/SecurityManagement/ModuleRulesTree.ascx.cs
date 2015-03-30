namespace TSN.ERP.WebGUI.SecurityManagement
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for ModuleRulesTree.
	/// </summary>
	public partial class ModuleRulesTree : System.Web.UI.UserControl
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if (!IsPostBack)
			{
				GUIWS.GUI gws = ((Navigation.BaseObject) Session[ "navigation" ]).GUIWsObject;
				DataSet ds = gws.ViewSubModulesForModule( ((Navigation.BaseObject) Session[ "navigation" ]).Module );
				FillTreeRecursive( ds , ref this.TreeView1 );
				
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
			this.TreeView1.SelectedIndexChange += new Microsoft.Web.UI.WebControls.SelectEventHandler(this.TreeView1_SelectedIndexChange);

		}
		#endregion

		#region Functions

		void FillTreeRecursive(DataSet templist, ref Microsoft.Web.UI.WebControls.TreeView tv)
		{
			if (templist!=null && templist.Tables.Count>0)
			{
				tv.Nodes.Clear();
				
				foreach (DataRow dr in templist.Tables[0].Rows)
				{
					if ((int)dr["SubModParent"]==0)
					{
						Microsoft.Web.UI.WebControls.TreeNode treeNode = new Microsoft.Web.UI.WebControls.TreeNode();
						treeNode.Text   = dr["SubModName"].ToString();
						treeNode.ID     = dr["MSMID"].ToString();
						tv.Nodes.Add ( treeNode );
						FillChildren(ref tv, int.Parse(treeNode.ID) ,ref treeNode,ref templist);

						GetRulesOfSubModule( treeNode );
					}	
				}
			}
		}

		void FillChildren(ref Microsoft.Web.UI.WebControls.TreeView tv, int parentID,ref Microsoft.Web.UI.WebControls.TreeNode tn, ref DataSet templist)
		{
			if (templist!=null && templist.Tables.Count>0)
			{
				foreach (DataRow dr in templist.Tables[0].Rows)
				{
					if ((int)dr["SubModParent"]==parentID)
					{
						Microsoft.Web.UI.WebControls.TreeNode treeNode = new Microsoft.Web.UI.WebControls.TreeNode();
						treeNode.Text   = dr["SubModName"].ToString();
						treeNode.ID     = dr["MSMID"].ToString();
						tn.Nodes.Add ( treeNode );
						FillChildren(ref tv,int.Parse(treeNode.ID), ref treeNode,ref templist);
						GetRulesOfSubModule( treeNode );
					}	
				}

			}
		}

		void AddRulesNodesToSubModuleNode( ref Microsoft.Web.UI.WebControls.TreeView tv, ref Microsoft.Web.UI.WebControls.TreeNode tn, ref DataSet templist)
		{
			if (templist!=null && templist.Tables.Count>0)
			{
				foreach (DataRow dr in templist.Tables[0].Rows)
				{
					
					Microsoft.Web.UI.WebControls.TreeNode treeNode = new Microsoft.Web.UI.WebControls.TreeNode();
					treeNode.Text   = dr["RuleName"].ToString();
					treeNode.ID     = "R" + dr["RuleID"].ToString();
					tn.Nodes.Add ( treeNode );
				}
			}
		}


		void GetRulesOfSubModule( Microsoft.Web.UI.WebControls.TreeNode node )
		{
			try
			{
				GUIWS.GUI gws = ((Navigation.BaseObject) Session[ "navigation" ]).GUIWsObject;
				DataSet ds = gws.ViewRulesForSubModule( Convert.ToInt32( node.ID ) );
				AddRulesNodesToSubModuleNode( ref this.TreeView1 , ref node , ref ds );
			}

			catch ( Exception ee )
			{
				Navigation.BaseObject.showMessage (  ee.Message , this.Page );
			}
		}


		#endregion 

		private void TreeView1_SelectedIndexChange(object sender, Microsoft.Web.UI.WebControls.TreeViewSelectEventArgs e)
		{
			Microsoft.Web.UI.WebControls.TreeNode node = 	 TreeView1.GetNodeFromIndex( TreeView1.SelectedNodeIndex );
			if ( node.ID.StartsWith( "R" ) )
				Label1.Text = "Rule ID is :" + node.ID.Substring( 1 );
		
		}
	}
}
