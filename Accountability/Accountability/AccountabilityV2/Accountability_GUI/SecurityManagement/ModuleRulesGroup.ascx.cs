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
	public partial class ModuleRulesGroup : System.Web.UI.UserControl
	{
		#region Controls Definitions 

		protected System.Web.UI.WebControls.Button ButtonOut;
		protected System.Web.UI.WebControls.Button ButtonAdd;
		protected System.Web.UI.WebControls.ListBox ListBox3;
		protected TSN.ERP.WebGUI.Data.DataSetRuleGroup dataSetRuleGroup1;
		protected TSN.ERP.WebGUI.Data.DataSetRuleEntity dataSetRuleEntity1;
		protected TSN.ERP.Security.Data.DataSetEntities dataSetEntities1;

		#endregion 

		#region Page_Load

		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			if (!IsPostBack)
			{
				Session["ControlMode"] = "Edit";
				GUIWS.GUI guiWS =  ((Navigation.BaseObject) Session[ "navigation" ]).GUIWsObject ;
				DataSet ds = guiWS.ViewSubModulesForModule( ((Navigation.BaseObject) Session[ "navigation" ]).Module );
				//BS
				SecurityWS.SecurityManagement secMang = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject ;
				dataSetRuleGroup1.Merge( secMang.GetAllRuleGroups());
				dlpRuleGroups.DataBind();
				ListItem tempItem = new ListItem();
				tempItem.Value = "";
				tempItem.Text = "--Select Value--";
				dlpRuleGroups.Items.Insert(0,tempItem);

				SecurityWS.SecurityManagement sec = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject;
				dataSetEntities1.Merge( sec.GetAllEntities() );
				DropDownListEntities.DataBind();
		
				DropDownListEntities.Items.Insert( 0 , "----- Select Entity ----- " );

				ListItem GeneralItem = new ListItem();
				GeneralItem.Text = "General";
				GeneralItem.Value = "-1";

				DropDownListEntities.Items.Insert(1,GeneralItem);

				

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
			this.dataSetEntities1 = new TSN.ERP.Security.Data.DataSetEntities();
			((System.ComponentModel.ISupportInitialize)(this.dataSetRuleGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetRuleEntity1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetEntities1)).BeginInit();
			this.DataGridRlEnt.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
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
			// 
			// dataSetEntities1
			// 
			this.dataSetEntities1.DataSetName = "DataSetEntities";
			this.dataSetEntities1.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.dataSetRuleGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetRuleEntity1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetEntities1)).EndInit();

		}
		#endregion

		
		#region Controls Events 
		
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

					////////////////////////////////////////
					dlpRuleGroups.Visible = true;
					btnNew.Visible = true;
					TextBoxGroupName.Visible = false;
					dlpRuleGroups.SelectedIndex = 0 ;
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
					Response.Write ( "<script language=javascript > alert ( 'The group hase been updated sucessefuly' ) </script>" ) ;

					
				}
				
			}
			catch ( Exception ee )
			{
				Navigation.BaseObject.showMessage (  ee.Message , this.Page );
			}
		}

		#endregion

		#region btnNew_Click
		protected void btnNew_Click(object sender, System.EventArgs e)
		{
			Session["ControlMode"] = "Add";
			dlpRuleGroups.Visible = false;
			btnNew.Visible = false;
			TextBoxGroupName.Visible = true;
			ListBoxEntities.Items.Clear();
		}

		#endregion

		#region DataGrid1_PageIndexChanged

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DropDownListEntitiesItems_SelectedIndexChanged( source , e );
			this.DataGridRlEnt.CurrentPageIndex=e.NewPageIndex;
		}


		#endregion 

		#region DropDownListEntities_SelectedIndexChanged

		protected void DropDownListEntities_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DropDownListEntitiesItems.Items.Clear();
			dataSetEntities1.Clear();
			DataGridRlEnt.CurrentPageIndex = 0 ;
			DataGridRlEnt.DataBind();
			
			if( DropDownListEntities.SelectedIndex != 0  )
			{
				DataSet ds = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.GetAllEntitiesItemsOfEntity( int.Parse( DropDownListEntities.SelectedValue ) );

				DropDownListEntitiesItems.DataSource = ds;
				DropDownListEntitiesItems.Visible = true;

				switch( DropDownListEntities.SelectedValue )
				{
					case "-1":
					{
						DropDownListEntitiesItems.Visible = false;
						dataSetRuleEntity1.Merge( ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.GetGeneralRuleEntities());
						DataGridRlEnt.DataBind();
						break;
					}
					case "1" :
					{
						DropDownListEntitiesItems.DataTextField  = "ProjectName";
						DropDownListEntitiesItems.DataValueField = "projectID";
						break;
					}
					case "2" :
					{
						DropDownListEntitiesItems.DataTextField  = "CEName";
						DropDownListEntitiesItems.DataValueField = "CompElmentID";
						break;
					}
					case "3" :
					{
						DropDownListEntitiesItems.DataTextField  = "FullName";
						DropDownListEntitiesItems.DataValueField = "ContactID";
						break;
					}
					case "4" :
					{
						DropDownListEntitiesItems.DataTextField  = "TeamName";
						DropDownListEntitiesItems.DataValueField = "TeamID";
						break;
					}
				}
					//TSN.ERP.Security.Data.DataSetEntities.SEC_EntitiesRow row = dataSetEntities1.SEC_Entities[ DropDownListEntities.SelectedIndex -1 ].cKeyName
				if ( ds != null && ds.Tables.Count != 0 )
				{
					DropDownListEntitiesItems.DataBind();
					DropDownListEntitiesItems.Items.Insert( 0 , "----- Select Entity Item ----- " );
				}

			}

			////////////////////////////
//			int pagsize = DataGridRlEnt.PageSize;
//			int rowCountds = dataSetEntities1.GEN_JobTitles.Count;
//			if (Math.IEEERemainder(rowCountds , pagsize) == 0)
//			{
//				if ( DataGridRlEnt.CurrentPageIndex == 0 || DataGridRlEnt.CurrentPageIndex == 1 )
//				{
//					DataGridRlEnt.CurrentPageIndex = 0 ;
//				}
//				else
//				{
//					DataGridRlEnt.CurrentPageIndex = DataGridRlEnt.CurrentPageIndex - 1;
//				}
//			}
	
				
		}


		#endregion 

		#region DropDownListEntitiesItems_SelectedIndexChanged
		protected void DropDownListEntitiesItems_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (DropDownListEntities.SelectedValue != "-1")
			{
				dataSetRuleEntity1.Merge( ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.GetAllRulesEntitiesOfEntityAndEntityValue( int.Parse( DropDownListEntities.SelectedValue ) , int.Parse( DropDownListEntitiesItems.SelectedValue )) );
			}
			else
			{
				dataSetRuleEntity1.Merge(((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.GetGeneralRuleEntities());
			}
			DataGridRlEnt.DataBind();
		}


		#endregion 

		#region ButtonSelect_Click
		protected void ButtonSelect_Click(object sender, System.EventArgs e)
		{
			int rowCount =  DataGridRlEnt.Items.Count ;
			
			for ( int i = rowCount -1  ; i >= 0;  i-- )
			{
				CheckBox ch = (CheckBox) DataGridRlEnt.Items[ i ].Cells[ 0 ].Controls[ 1 ];
				if ( ch.Checked  ) 
				{
					ListItem item = new ListItem();
					item.Value = DataGridRlEnt.Items[i].Cells[ 1 ].Text ;
					item.Text  = DataGridRlEnt.Items[i].Cells[ 2 ].Text.Trim() ; 
					if ( ! ListBoxEntities.Items.Contains ( item ) )	
						ListBoxEntities.Items.Add( item );	
				}
				ch.Checked = false;
			}
		
		}


		#endregion 

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

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			dlpRuleGroups.Visible = true;
			btnNew.Visible = true;
			TextBoxGroupName.Visible = false;
			dlpRuleGroups.SelectedIndex = 0 ;
			TextBoxGroupName.Text = "";
			ListBoxEntities.Items.Clear();
			Session["ControlMode"] = "Edit";

		}

		
	}
}
