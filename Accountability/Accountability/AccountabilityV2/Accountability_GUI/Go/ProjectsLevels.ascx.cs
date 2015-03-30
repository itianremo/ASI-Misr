namespace TSN.ERP.WebGUI.Go
{
	using System;
	using System.Collections;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Navigation;

	/// <summary>
	///		Summary description for ItemDetails.
	/// </summary>
	public partial class ProjectsLevels : System.Web.UI.UserControl
	{
		#region Controls Definitions 

		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Web.UI.HtmlControls.HtmlGenericControl parent;
		protected System.Web.UI.HtmlControls.HtmlGenericControl ParentMenue;
		protected System.Data.DataView dvProjects;
		protected TSN.ERP.SharedComponents.Data.dsProjects dsProjects1;
		protected TSN.ERP.SharedComponents.Data.dsProjectsLevels dsProjectsLevels1;

		#endregion 
		
		#region Page_Load
		protected void Page_Load(object sender, System.EventArgs e)
		{
			tblErr.Visible = false;
			try
			{
				if( !IsPostBack )
				{                    
					#region Fill combos

					// fill company levels
					ShowErrorTable = false;
			
					if ( Navigation.BaseObject.SafeMerge( dsProjectsLevels1 , ((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.ListAllProjectsLevels() ) )
					{
						DropDownListAllPrjLevels.DataBind();
						ListItem TempItem = new ListItem();
						TempItem.Text = "---- Select Parent -----";
						TempItem.Value = "-1";
						DropDownListAllPrjLevels.Items.Insert(0,TempItem);
						ViewState[ "Levels" ] = dsProjectsLevels1;
					
					}

					// fill projects
					
					if ( Navigation.BaseObject.SafeMerge( dsProjects1 , ((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.ListAllProjects() ) )
					{
						DropDownListProjects.DataTextField  = "ProjectName"; 
						DropDownListProjects.DataValueField = "projectID";
						DropDownListProjects.DataSource = dsProjects1;
						DropDownListProjects.DataBind();
						ListItem TempItem = new ListItem();
						TempItem.Text = "---- Select Projects -----";
						TempItem.Value = "-1";
						DropDownListProjects.Items.Insert(0,TempItem);
						ViewState[ "AllPrj" ] = dsProjects1;
					
					}
					FillTree();
					if(TreeView1.Nodes.Count>0)
					{
						dsProjects1.Clear();
						TreeView1.SelectedNodeIndex="0";
						TreeView1.AutoSelect=true;
						btnSelectNode_Click(null,null);

                        Microsoft.Web.UI.WebControls.CssCollection css = new Microsoft.Web.UI.WebControls.CssCollection();
                        css.CssText = "color:#FFFFFF";
                        TreeView1.DefaultStyle = css;
                        //TreeView1.Nodes[0].DefaultStyle = css;
					}

					#endregion 
				}
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
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
			this.dvProjects = new System.Data.DataView();
			this.dsProjects1 = new TSN.ERP.SharedComponents.Data.dsProjects();
			this.dsProjectsLevels1 = new TSN.ERP.SharedComponents.Data.dsProjectsLevels();
			((System.ComponentModel.ISupportInitialize)(this.dvProjects)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsProjects1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsProjectsLevels1)).BeginInit();
			// 
			// dsProjects1
			// 
			this.dsProjects1.DataSetName = "dsProjects";
			this.dsProjects1.EnforceConstraints = false;
			this.dsProjects1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// dsProjectsLevels1
			// 
			this.dsProjectsLevels1.DataSetName = "dsProjectsLevels";
			this.dsProjectsLevels1.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.dvProjects)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsProjects1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsProjectsLevels1)).EndInit();

		}
		#endregion
		
		#region Fill Tree

		void FillTree( )
		{
			dsProjectsLevels1    = (TSN.ERP.SharedComponents.Data.dsProjectsLevels ) ViewState[ "Levels" ];
			
			if (dsProjectsLevels1 !=null && dsProjectsLevels1.Tables.Count>0)
			{
				TreeView1.Nodes.Clear();
				
				foreach (DataRow dr in dsProjectsLevels1.Tables[0].Rows)
				{
					if ((int)dr["ProjectElementParent"]==0)
					{
						Microsoft.Web.UI.WebControls.TreeNode treeNode = new Microsoft.Web.UI.WebControls.TreeNode();
						treeNode.Text   = dr["ProjectElementName"].ToString();
						treeNode.ID     = "E" + dr["ProjectElementID"].ToString();
						TreeView1.Nodes.Add ( treeNode );
						FillChildren(  int.Parse(treeNode.ID.Remove( 0 , 1 )) , treeNode, (DataSet) dsProjectsLevels1);
						GetProjectsInParent( treeNode );
					}
				}
			}
		}

		void FillChildren( int parentID,  Microsoft.Web.UI.WebControls.TreeNode tn,  DataSet templist)
		{
			if (templist!=null && templist.Tables.Count>0)
			{
				foreach (DataRow dr in templist.Tables[0].Rows)
				{
					if ((int)dr["ProjectElementParent"]==parentID)
					{
						Microsoft.Web.UI.WebControls.TreeNode treeNode = new Microsoft.Web.UI.WebControls.TreeNode();
						treeNode.Text   = dr["ProjectElementName"].ToString();
						treeNode.ID     =  "E" + dr["ProjectElementID"].ToString();
						tn.Nodes.Add ( treeNode );
						FillChildren( int.Parse(treeNode.ID.Remove( 0 , 1 )),  treeNode, templist);
						GetProjectsInParent( treeNode );
					}	
				}
			}
		}


		#region AddProjectToParent

		void AddProjectToParent(  Microsoft.Web.UI.WebControls.TreeView tv,  Microsoft.Web.UI.WebControls.TreeNode tn,  DataSet templist)
		{
			if (templist!=null && templist.Tables.Count>0)
			{
				foreach (DataRow dr in templist.Tables[0].Rows)
				{
					
					Microsoft.Web.UI.WebControls.TreeNode treeNode = new Microsoft.Web.UI.WebControls.TreeNode();
					treeNode.Text   = dr["ProjectName"].ToString();
					treeNode.ID     = 'P' + dr["projectID"].ToString();
					Microsoft.Web.UI.WebControls.CssCollection css = new Microsoft.Web.UI.WebControls.CssCollection();
                    //css.CssText = "color: #993300" ;
                    css.CssText = "color: #FF0000";
					treeNode.DefaultStyle = css;
					tn.Nodes.Add ( treeNode );
				}
			}
		}


		#endregion 

		#region GetProjectsInParent

		void GetProjectsInParent( Microsoft.Web.UI.WebControls.TreeNode node )
		{
			DataSet ds = ((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.GetProjectsByParent( Convert.ToInt32( node.ID.Remove( 0 , 1 ) ) );
			AddProjectToParent(  TreeView1 ,  node ,  ds );
		}


		#endregion 

		#endregion 
	
		#region get Selected Node In Tree
	
		protected void btnSelectNode_Click(object sender, System.EventArgs e)
		{
			// get selected node
			Microsoft.Web.UI.WebControls.TreeNode node = TreeView1.GetNodeFromIndex( TreeView1.SelectedNodeIndex );

			ButtonAddLevel.Visible	   = false;
			ButtonUpdateLevel.Visible  = true;
			TABLE7.Visible = true;

            btnDelete.Visible = true;

			if(TreeView1 ==null || TreeView1.Nodes.Count == 0)
			{
				BaseObject.showMessage("There is not item in the tree to select it",this.Page);
				return;
			}
			else if( node.ID[ 0 ] == 'E' )
			{
				hdnFlage.Value ="yes";
				hdnUpdateFlage.Value = "yes";
				// selected node ID
				string selectedParent = node.ID.Remove( 0 , 1 );

				// get the selected row from projectLevel DataSet
				dsProjectsLevels1 = (TSN.ERP.SharedComponents.Data.dsProjectsLevels) ViewState[ "Levels" ];
				TSN.ERP.SharedComponents.Data.dsProjectsLevels.GEN_ProjectsHierarchyRow row = (TSN.ERP.SharedComponents.Data.dsProjectsLevels.GEN_ProjectsHierarchyRow) dsProjectsLevels1.GEN_ProjectsHierarchy.FindByProjectElementID( int.Parse( selectedParent ) );
				txtElementName.Text        = row[ "ProjectElementName" ].ToString();
				txtElementDescription.Text = row[ "ProjectElementDesc" ].ToString();
				Label1.Text = row[ "ProjectElementName" ].ToString();
				Label2.Text = row[ "ProjectElementName" ].ToString();
				AddProjectToElm.Enabled = true;
				ButtonRmvPrjFrmElm.Enabled = true;

				if ( row[ "ProjectElementParent" ].ToString() != "0" )
					DropDownListAllPrjLevels.SelectedValue =  row[ "ProjectElementParent" ].ToString();
				else
					DropDownListAllPrjLevels.SelectedIndex  = 0; 

				if ( Navigation.BaseObject.SafeMerge( dsProjects1 , ((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.GetProjectsByParent( int.Parse( selectedParent ) ) ) )
				{
					dgProjects.DataBind();	
					ViewState[ "elmPrjs" ] = dsProjects1 ;
				}
				//save selected node
				ViewState[ "selectedLevel" ] = int.Parse( selectedParent );

			}
			else
			{
				txtElementName.Text        = "";
				txtElementDescription.Text = "";
				DropDownListAllPrjLevels.SelectedIndex  = 0; 
				AddProjectToElm.Enabled = false;
				ButtonRmvPrjFrmElm.Enabled = false;
				dsProjects1.Clear();
				dgProjects.DataBind();
				ViewState[ "elmPrjs" ] = dsProjects1;

				btnDelete.Visible = false;
				ButtonUpdateLevel.Visible = false;
			}			

		}

		#endregion 

		#region ButtonNewLevel_Click
		// prepare to adding new level
		protected void ButtonNewLevel_Click(object sender, System.EventArgs e)
		{
			// clear controls
			txtElementName.Text        = "";
			txtElementDescription.Text = "";
			DropDownListAllPrjLevels.SelectedIndex  = 0; 
			dsProjects1.Clear();
			dgProjects.DataBind();
			ButtonAddLevel.Visible	   = true;
			ButtonUpdateLevel.Visible  = false;
			TABLE7.Visible = false;
			Label1.Text="";
		}

		#endregion 
		public bool IsElementExist(TSN.ERP.SharedComponents.Data.dsProjectsLevels ds,string ElementName)
		{
			bool Flage = false;
			foreach(DataRow dr in ds.Tables[0].Rows)
			{
				if( dr[1].ToString().ToLower()==ElementName.ToLower())
				{
					Flage = true;
					break;
				}
				else
				{
					Flage = false;
				}
			}
			return Flage;
		}
		public bool IsElementExistForUpdate(TSN.ERP.SharedComponents.Data.dsProjectsLevels ds,string ElementName,int ElementID)
		{
			bool Flage = false;
			foreach(DataRow dr in ds.Tables[0].Rows)
			{
				if(dr[1].ToString().ToLower()==ElementName.ToLower() && int.Parse(dr[0].ToString())!=ElementID)
				{
					Flage = true;
					break;
				}
				else
				{
					Flage = false;
				}
			}
			return Flage;
		}


		#region Add Level
		protected void ButtonAddLevel_Click(object sender, System.EventArgs e)
		{
			//add new level
			if(Page.IsValid)
			{
				dsProjectsLevels1 = (TSN.ERP.SharedComponents.Data.dsProjectsLevels) ViewState[ "Levels" ];
				TSN.ERP.SharedComponents.Data.dsProjectsLevels.GEN_ProjectsHierarchyRow  row = dsProjectsLevels1.GEN_ProjectsHierarchy.NewGEN_ProjectsHierarchyRow();
				row.ProjectElementID 	  = 0;
				row.ProjectElementName	  = txtElementName.Text;
				row.ProjectElementDesc    = txtElementDescription.Text;

				if(txtElementName.Text.ToLower().Trim()== DropDownListAllPrjLevels.Items[DropDownListAllPrjLevels.SelectedIndex].ToString().ToLower().Trim())
				{
					BaseObject.showMessage("Please select different element name" ,this.Page);
					return;
				}
				if (DropDownListAllPrjLevels.SelectedIndex > 0)
					row.ProjectElementParent = int.Parse(DropDownListAllPrjLevels.SelectedValue);
				else
					row.ProjectElementParent = 0;
				bool Flage = IsElementExist(dsProjectsLevels1,txtElementName.Text.Trim());
				if(Flage==true)
				{
					BaseObject.showMessage("This element already exists, please try another name" ,this.Page);
					ButtonNewLevel_Click(null,new System.EventArgs());
					return;
				}
				else
				{
					
					dsProjectsLevels1.GEN_ProjectsHierarchy.AddGEN_ProjectsHierarchyRow( row );
					if ( ((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.AddProjectLevel( dsProjectsLevels1 ) != 0 )
					{
						dsProjectsLevels1.AcceptChanges();
						dsProjectsLevels1.Clear();
						if ( Navigation.BaseObject.SafeMerge( dsProjectsLevels1 , ((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.ListAllProjectsLevels() ) )
							ViewState[ "Levels" ] = dsProjectsLevels1;
						ButtonNewLevel_Click(null,new System.EventArgs());
					}
					
					//Refresh data
					txtElementName.Text        = "";
					txtElementDescription.Text = "";
					DropDownListAllPrjLevels.SelectedIndex  = 0; 
					DropDownListAllPrjLevels.Items.Clear();
					DropDownListAllPrjLevels.DataBind();
					ListItem TempItem = new ListItem();
					TempItem.Text = "---- Select Parent -----";
					TempItem.Value = "-1";
					DropDownListAllPrjLevels.Items.Insert(0,TempItem);
				
					ButtonAddLevel.Visible	   = false;
					ButtonUpdateLevel.Visible  = true;
					TABLE7.Visible = true;
					FillTree();
					TreeView1.SelectedNodeIndex="0";
					TreeView1.AutoSelect=true;
					btnSelectNode_Click(null,null);
				}
			}
		}

		#endregion 

		#region Update Project Level
		protected void ButtonUpdateLevel_Click(object sender, System.EventArgs e)
		{
			if(Page.IsValid)
			{
				if ( txtElementName.Text.Trim() != ""  )
				{
					// set new updates
					dsProjectsLevels1 = (TSN.ERP.SharedComponents.Data.dsProjectsLevels) ViewState[ "Levels" ];
					if(hdnUpdateFlage.Value == "yes")
					{
						TSN.ERP.SharedComponents.Data.dsProjectsLevels.GEN_ProjectsHierarchyRow row = (TSN.ERP.SharedComponents.Data.dsProjectsLevels.GEN_ProjectsHierarchyRow) dsProjectsLevels1.GEN_ProjectsHierarchy.FindByProjectElementID( Convert.ToInt32( ViewState[ "selectedLevel" ].ToString()) );
						//if (txtElementName.Text.Trim() == DropDownListAllPrjLevels.Items[DropDownListAllPrjLevels.SelectedIndex].ToString().Trim())
						//{
						//    BaseObject.showMessage("Please select different project name", this.Page);
						//    return;
						//}
						if (row.ProjectElementID == Convert.ToInt32(DropDownListAllPrjLevels.SelectedValue))
						{
							BaseObject.showMessage("Please select different project name", this.Page);
							return;
						}
						bool Flage = IsElementExistForUpdate(dsProjectsLevels1,txtElementName.Text.Trim(),row.ProjectElementID);					
						// update the level
						if(Flage==true )
						{
							BaseObject.showMessage("This element already exist, please try another name" ,this.Page);
							ButtonNewLevel_Click(null,new System.EventArgs());
							return;
						}
						else
						{
							row.ProjectElementName	  = txtElementName.Text;
							row.ProjectElementDesc    = txtElementDescription.Text;
					

							if (DropDownListAllPrjLevels.SelectedIndex > 0)
							{
								TSN.ERP.SharedComponents.Data.dsProjectsLevels.GEN_ProjectsHierarchyRow childRow = (TSN.ERP.SharedComponents.Data.dsProjectsLevels.GEN_ProjectsHierarchyRow) dsProjectsLevels1.GEN_ProjectsHierarchy.FindByProjectElementID(Convert.ToInt32(DropDownListAllPrjLevels.SelectedValue));
								if(childRow.ProjectElementParent == Convert.ToInt32( ViewState[ "selectedLevel" ].ToString()))
								{
									childRow.ProjectElementParent = row.ProjectElementParent;
									row.ProjectElementParent = childRow.ProjectElementID;
								}
								else
								{
									row.ProjectElementParent = int.Parse(DropDownListAllPrjLevels.SelectedValue);
								}
							}
							else
							{
								row.ProjectElementParent = 0;
							}
						
							((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.EditProjectsLevels( dsProjectsLevels1 );
							dsProjectsLevels1.AcceptChanges();
							ViewState[ "Levels" ] = dsProjectsLevels1;
							ButtonNewLevel_Click(null,new System.EventArgs());

					
							//Refresh data
							Label1.Text = row.ProjectElementName;
							Label2.Text = row.ProjectElementName;
							txtElementName.Text        = "";
							txtElementDescription.Text = "";
							DropDownListAllPrjLevels.Items.Clear();
							DropDownListAllPrjLevels.DataBind();
							ListItem TempItem = new ListItem();
							TempItem.Text = "---- Select Parent -----";
							TempItem.Value = "-1";
							DropDownListAllPrjLevels.Items.Insert(0,TempItem);
							dsProjects1.Clear();
							dgProjects.DataBind();	
							FillTree();
							TreeView1.SelectedNodeIndex="0";
							TreeView1.AutoSelect=true;
							btnSelectNode_Click(null,null);
						}
					}
				}
				//else
				//	BaseObject.showMessage( "Please insert the element name"  , this.Page );
			}
		}

		#endregion 

		#region  Delete Project Level
		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			if(TreeView1.Nodes.Count > 0)
			{
				if (TreeView1.GetNodeFromIndex( TreeView1.SelectedNodeIndex).Nodes.Count == 0 )
				{
					Microsoft.Web.UI.WebControls.TreeNode node = TreeView1.GetNodeFromIndex( TreeView1.SelectedNodeIndex );
					
					if( node.ID[ 0 ] == 'E'  && hdnFlage.Value =="yes")
					{
						dsProjectsLevels1 = (TSN.ERP.SharedComponents.Data.dsProjectsLevels) ViewState[ "Levels" ];
						TSN.ERP.SharedComponents.Data.dsProjectsLevels.GEN_ProjectsHierarchyRow row = (TSN.ERP.SharedComponents.Data.dsProjectsLevels.GEN_ProjectsHierarchyRow) dsProjectsLevels1.GEN_ProjectsHierarchy.FindByProjectElementID( Convert.ToInt32(ViewState[ "selectedLevel" ].ToString()) );
						
						row.Delete();
						int deleteresult = ((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.DeleteProjectsLevels(dsProjectsLevels1);
						if (deleteresult<=0)
						{
							ShowErrorTable = true;
							tblErr.Visible = true;
							dsProjectsLevels1.RejectChanges();
						}
						else
						{
							dsProjectsLevels1.AcceptChanges();
							dsProjectsLevels1.Merge(((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.ListAllProjectsLevels());
							ViewState[ "Levels" ] = dsProjectsLevels1;

							// refresh data
							txtElementName.Text        = "";
							txtElementDescription.Text = "";
							DropDownListAllPrjLevels.SelectedIndex  = 0; 
							FillTree();
                            if (dsProjectsLevels1.Tables[0].Rows.Count != 0)
                            {
                                DropDownListAllPrjLevels.DataBind();
                            }
							ListItem TempItem = new ListItem();
							TempItem.Text = "---- Select Parent -----";
							TempItem.Value = "-1";
							DropDownListAllPrjLevels.Items.Insert(0,TempItem);
							Label1.Text = "";
							Label2.Text = "";
							ButtonNewLevel_Click(null,new System.EventArgs());

                            if (TreeView1.Nodes.Count != 0)
                            {
                                TreeView1.SelectedNodeIndex = "0";
                                TreeView1.AutoSelect = true;
                                btnSelectNode_Click(null, null);
                            }
						}
					}
				}
				else
				{
					BaseObject.showMessage( "You have to delete the children elements or move them to another element before deleting this element ", this.Page );
				}
			}
			else
			{
			BaseObject.showMessage( "There is no items to delete", this.Page );
			}
		}

		#endregion

		#region Add Project To Project Level

		protected void AddProjectToElm_Click(object sender, System.EventArgs e)
		{
			if ( DropDownListProjects.SelectedValue != "-1" )
			{
				// All projects
//				SharedComponents.Data.dsProjects allProjects = (TSN.ERP.SharedComponents.Data.dsProjects ) ViewState[ "AllPrj" ];
				SharedComponents.Data.dsProjects allProjects = new TSN.ERP.SharedComponents.Data.dsProjects();
				allProjects.Merge(((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.ListAllProjects());
				// selected Element Projects
				dsProjects1    = (TSN.ERP.SharedComponents.Data.dsProjects ) ViewState[ "elmPrjs" ];
				
				if( dsProjects1 != null )
				{
                    if (dsProjects1.GEN_Projects.FindByprojectID(Convert.ToInt32(DropDownListProjects.SelectedValue)) == null)
                    {
                        // get selected Row in All projects dataset
                        TSN.ERP.SharedComponents.Data.dsProjects.GEN_ProjectsRow row = allProjects.GEN_Projects.FindByprojectID(Convert.ToInt32(DropDownListProjects.SelectedValue));

                        //set the parent id field in the founded row

                        row.ProjectParentID = Convert.ToInt32(ViewState["selectedLevel"].ToString());

                        // modify the projects ds
                        int x = ((Navigation.BaseObject)Session["navigation"]).ProjectWSObject.EditProjects(allProjects);
                        allProjects.AcceptChanges();
                        ViewState["AllPrj"] = allProjects;

                        // get the element projects again and re bind the grid
                        //if( Convert.ToInt32( DropDownListProjects.SelectedValue )

                        dsProjects1.Clear();
                        if (Navigation.BaseObject.SafeMerge(dsProjects1, ((Navigation.BaseObject)Session["navigation"]).ProjectWSObject.GetProjectsByParent(Convert.ToInt32(ViewState["selectedLevel"].ToString()))))
                        {
                            dgProjects.DataBind();
                            ViewState["elmPrjs"] = dsProjects1;

                        }
                        DropDownListProjects.SelectedIndex = 0;
                        FillTree();

                    }
                    else
                    {
                        BaseObject.showMessage("this item already added", this.Page);
                    }
                    
				}
			}
            else
            {
                BaseObject.showMessage("There is no selected item", this.Page);
                return;

            }
		}


		#endregion 

		#region Remove Project From Project Level

		protected void ButtonRmvPrjFrmElm_Click(object sender, System.EventArgs e)
		{
			       // selected Element Projects
			
		   dsProjects1    = (TSN.ERP.SharedComponents.Data.dsProjects ) ViewState[ "elmPrjs" ];

			if ( dsProjects1 != null )
			{
                bool IsRemoved = false;
				for ( int i = 0 ; i < dgProjects.Items.Count ; i++ )
				{
					if ( ((CheckBox) dgProjects.Items[ i ].Cells[ 2 ].Controls[ 1 ] ).Checked )
					{
						// get selected Row in All projects dataset
						TSN.ERP.SharedComponents.Data.dsProjects.GEN_ProjectsRow row = dsProjects1.GEN_Projects.FindByprojectID( Convert.ToInt32( dgProjects.Items[ i ].Cells[ 0 ].Text ));
						row.SetProjectParentIDNull();
						((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.EditProjects( dsProjects1 );
						dsProjects1.AcceptChanges();
						ViewState[ "elmPrjs" ] = dsProjects1;
                        IsRemoved = true;
					}
				}
                

				// clear projects dataset
				dsProjects1.Clear();
                if (!IsRemoved)
                {
                    BaseObject.showMessage("There is no selected item", this.Page);
                    return;

                }
				
				// re-bind projects datagrid and re bind tree view
				if ( Navigation.BaseObject.SafeMerge( dsProjects1 , ((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.GetProjectsByParent( Convert.ToInt32( ViewState[ "selectedLevel" ].ToString() ) ) ) )
				{
					dgProjects.DataBind();	
					ViewState[ "elmPrjs" ] = dsProjects1 ;
					FillTree();
				}
			}
		}
		

		#endregion 

		#region ShowErrorTable
		public bool ShowErrorTable
		{
			get
			{
				bool tempval=(bool)Session["ShowErrorTable"];
				
				ShowErrorTable = false;
				return tempval;
			}
			set
			{
				Session["ShowErrorTable"] = value;
			}
		}
		#endregion 
	}
}
