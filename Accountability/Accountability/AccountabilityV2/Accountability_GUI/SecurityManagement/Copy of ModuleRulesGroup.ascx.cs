namespace TSN.ERP.WebGUI.SecurityManagement
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for ModuleRulesEntitiesTree.
	/// </summary>
	public partial class ModuleRulesGroup1 : System.Web.UI.UserControl
	{
		#region Controls Definitions 

		protected System.Web.UI.WebControls.Button ButtonOut;
		protected System.Web.UI.WebControls.Button ButtonAdd;
		protected System.Web.UI.WebControls.ListBox ListBox3;
		protected TSN.ERP.WebGUI.Data.DataSetRuleGroup dataSetRuleGroup1;
		protected TSN.ERP.WebGUI.Data.DataSetRuleEntity dataSetRuleEntity1;

		#endregion 

		#region Page_Load

		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			if (!IsPostBack)
			{
				Session["ControlMode"] = "Edit";
				GUIWS.GUI guiWS =  ((Navigation.BaseObject) Session[ "navigation" ]).GUIWsObject ;
				DataSet ds = guiWS.ViewSubModulesForModule( ((Navigation.BaseObject) Session[ "navigation" ]).Module );
				FillTreeRecursive( ds , ref this.TreeView11 );
				//BS
				SecurityWS.SecurityManagement secMang = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject ;
				dataSetRuleGroup1.Merge( secMang.GetAllRuleGroups());
				dlpRuleGroups.DataBind();
				ListItem tempItem = new ListItem();
				tempItem.Value = "";
				tempItem.Text = "--Select Value--";
				dlpRuleGroups.Items.Insert(0,tempItem);

			}
			if (Session["ControlMode"].ToString() == "Add")
			{
				dlpRuleGroups.Visible = false;
				btnNew.Visible = false;
				TextBoxGroupName.Visible = true;
			}
			else
			{
				dlpRuleGroups.Visible = true;
				btnNew.Visible = true;
				TextBoxGroupName.Visible = false;
			}
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
			this.dataSetRuleGroup1 = new TSN.ERP.WebGUI.Data.DataSetRuleGroup();
			this.dataSetRuleEntity1 = new TSN.ERP.WebGUI.Data.DataSetRuleEntity();
			((System.ComponentModel.ISupportInitialize)(this.dataSetRuleGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetRuleEntity1)).BeginInit();
			// 
			// dataSetRuleGroup1
			// 
			this.dataSetRuleGroup1.DataSetName = "DataSetRuleGroup";
			this.dataSetRuleGroup1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dataSetRuleEntity1
			// 
			this.dataSetRuleEntity1.DataSetName = "DataSetRuleEntity";
			this.dataSetRuleEntity1.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.dataSetRuleGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetRuleEntity1)).EndInit();

		}
		#endregion

		#region Functions 

		#region FillTreeRecursive

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


		#endregion 

		#region FillChildren

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


		#endregion 

		#region AddRulesNodesToSubModuleNode

		void AddRulesNodesToSubModuleNode( ref Microsoft.Web.UI.WebControls.TreeView tv, ref Microsoft.Web.UI.WebControls.TreeNode tn, ref DataSet templist)
		{
			if (templist!=null && templist.Tables.Count>0)
			{
				foreach (DataRow dr in templist.Tables[0].Rows)
				{
					
					Microsoft.Web.UI.WebControls.TreeNode treeNode = new Microsoft.Web.UI.WebControls.TreeNode();
					treeNode.Text   = dr["RuleEntityDescription"].ToString();
					treeNode.ID     = "R" + dr["RuleEntityID"].ToString();
					treeNode.CheckBox = true;
					tn.Nodes.Add ( treeNode );
				}
			}
		}


		#endregion 

		#region GetRulesOfSubModule

		void GetRulesOfSubModule( Microsoft.Web.UI.WebControls.TreeNode node )
		{
			GUIWS.GUI gws = ((Navigation.BaseObject) Session[ "navigation" ]).GUIWsObject;
			DataSet ds = gws.ViewRulesEntitiesOfSubModule( Convert.ToInt32( node.ID ) );
			AddRulesNodesToSubModuleNode( ref this.TreeView11 , ref node , ref ds );
		}


		#endregion 

		#region TreeView1_SelectedIndexChange

		private void TreeView1_SelectedIndexChange(object sender, Microsoft.Web.UI.WebControls.TreeViewSelectEventArgs e)
		{
			Microsoft.Web.UI.WebControls.TreeNode node = 	 TreeView11.GetNodeFromIndex( TreeView11.SelectedNodeIndex );
			if ( node.ID.StartsWith( "R" ) )
				Response.Write ( "Rule ID is :" + node.ID.Substring( 1 ) );
		}


		#endregion 

		#region getTreeChildren
		void getTreeChildren(  Microsoft.Web.UI.WebControls.TreeNode parent  )
		{
			
			foreach ( Microsoft.Web.UI.WebControls.TreeNode node in parent.Nodes )
			{
				if (  node.CheckBox  )
				{
					if ( node.Checked )
					{
						if ( node.ID.StartsWith( "R" ) )
						{	
							ListItem item = new ListItem();
							item.Value = node.ID.Substring( 1 );
							item.Text  = node.Text; 
							if ( ! ListBoxEntities.Items.Contains ( item ) )	
								ListBoxEntities.Items.Add( item );	
							//Response.Write ( "Rule ID is :" + node.ID.Substring( 1 ) + "<br>" );
						}
					}
				}

				getTreeChildren( node );
			}
		}


		#endregion 

		#endregion 

		#region Controls Events 
		
		#region Button1_Click
		protected void Button1_Click(object sender, System.EventArgs e)
		{
			foreach ( Microsoft.Web.UI.WebControls.TreeNode node in TreeView11.Nodes )
			{
				getTreeChildren( node );
			}
		}
		

		#endregion 

		#region ButtonOut_Click
		protected void ButtonOut_Click(object sender, System.EventArgs e)
		{
			try
			{
				for ( int i = ListBoxEntities.Items.Count-1 ; i >= 0 ; i-- )
				{
					if ( ListBoxEntities.Items[ i ].Selected )
					{
						ListBoxEntities.Items.Remove( ListBoxEntities.Items[ i ] );
					}
				}
			}

			catch ( Exception ee )
			{
				Navigation.BaseObject.showMessage (  ee.Message , this.Page );
			}
		}

		#endregion

		#region AddButton_Click
		protected void AddButton_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (Session["ControlMode"].ToString() == "Add")
				{
					SecurityWS.SecurityManagement secMang = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject ;
				
					int n = secMang.AddRuleGroup( TextBoxGroupName.Text ) ;
					if ( n != -1 )
					{
						for ( int i = 0 ; i < ListBoxEntities.Items.Count ; i++ )
						{
							secMang.AddRuleEntityToRuleGroup( Convert.ToInt32( ListBoxEntities.Items[ i ].Value ) , n ) ;	
						}
						Response.Write ( "<script language=javascript > alert ( 'The group hase been added sucessefuly' ) </script>" ) ;
					}
					else
						Navigation.BaseObject.showCallErrorMessage( "There has been error in creating Rule group:" , this.Page , ((Navigation.BaseObject) Session[ "navigation" ]).Token );  
				}
				else
				{
					int RGId = Int32.Parse(dlpRuleGroups.SelectedValue);
					SecurityWS.SecurityManagement secMang = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject ;
					dataSetRuleEntity1.Clear();
					dataSetRuleEntity1.Merge(secMang.GetAllRuleEntitiesDataInRuleGroup(RGId));
					foreach (  TSN.ERP.WebGUI.Data.DataSetRuleEntity.SEC_RuleEntityRow tempRow in dataSetRuleEntity1.SEC_RuleEntity )
						secMang.RemoveRuleEntityFromRuleGroup( tempRow.RuleEntityID ,RGId );
					for ( int i = 0 ; i < ListBoxEntities.Items.Count ; i++ )
						secMang.AddRuleEntityToRuleGroup( Convert.ToInt32( ListBoxEntities.Items[ i ].Value ) , Int32.Parse(dlpRuleGroups.SelectedValue) ) ;
					Response.Write ( "<script language=javascript > alert ( 'The group hase been added sucessefuly' ) </script>" ) ;
				}
				
			}
			catch ( Exception ee )
			{
				Navigation.BaseObject.showMessage (  ee.Message , this.Page );
			}
		}

		#endregion

		protected void btnNew_Click(object sender, System.EventArgs e)
		{
			Session["ControlMode"] = "Add";
		}

		#endregion 

		protected void dlpRuleGroups_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SecurityWS.SecurityManagement secMang = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject ;
			ListBoxEntities.Items.Clear();
			if (dlpRuleGroups.SelectedIndex ==0)
				return;
			dataSetRuleEntity1.Merge(secMang.GetAllRuleEntitiesDataInRuleGroup(Int32.Parse( dlpRuleGroups.SelectedValue)));

			foreach ( TSN.ERP.WebGUI.Data.DataSetRuleEntity.SEC_RuleEntityRow tempRow in dataSetRuleEntity1.SEC_RuleEntity  )
			{
				ListItem item = new ListItem();
				item.Value = tempRow.RuleEntityID.ToString();
				item.Text  = tempRow.RuleEntityDescription ; 
				if ( ! ListBoxEntities.Items.Contains ( item ) )
					ListBoxEntities.Items.Add( item );	
			}
		}

		
	}
}
