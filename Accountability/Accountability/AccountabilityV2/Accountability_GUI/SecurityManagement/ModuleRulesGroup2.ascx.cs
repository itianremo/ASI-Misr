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
	public partial class ModuleRulesGroup2 : System.Web.UI.UserControl
	{
		#region Controls Definitions 

		protected System.Web.UI.WebControls.Button ButtonOut;
		protected System.Web.UI.WebControls.Button ButtonAdd;
		protected System.Web.UI.WebControls.ListBox ListBox3;
		protected TSN.ERP.WebGUI.Data.DataSetRuleGroup dataSetRuleGroup1;
		protected TSN.ERP.WebGUI.Data.DataSetRuleEntity dataSetRuleEntity1;
		protected TSN.ERP.Security.Data.DataSetEntities dataSetEntities1;
		MasterMethods master = new MasterMethods();

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
				ListItem tempItem = new ListItem();
				tempItem.Value = "";
				tempItem.Text = "--Select Value--";

				SecurityWS.SecurityManagement sec = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject;
				dataSetEntities1.Merge( sec.GetAllEntities() );
				//Sort Entities DataSet//////////////////////////////////
				DataView dvCE = dataSetEntities1.Tables[0].DefaultView;
				dvCE.Sort = "EntityName";
				dataSetEntities1.Tables.Clear();
				dataSetEntities1.Tables.Add(master.CreateTableFromView(dvCE));
				/////////////////////////////////////////////////////////
				DropDownListEntities.DataBind();
		
				DropDownListEntities.Items.Insert( 0 , "----- Select Entity ----- " );

				ListItem GeneralItem = new ListItem();
				GeneralItem.Text = "General";
				GeneralItem.Value = "-1";

				DropDownListEntities.Items.Insert(1,GeneralItem);
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
						DataGridRlEnt.Visible = true;
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
						//Sort Company Elements DataSet//////////////////////////////////
						DataView dvCE = ds.Tables[0].DefaultView;
						dvCE.Sort = "CEName";
						ds.Tables.Clear();
						ds.Tables.Add(master.CreateTableFromView(dvCE));
						//////////////////////////////////////////////////////////
						///
						DropDownListEntitiesItems.DataTextField  = "CEName";
						DropDownListEntitiesItems.DataValueField = "CompElmentID";
						break;
					}
					case "3" ://employees Entity
					{
						//Sort Employees DataSet//////////////////////////////////
						DataView dvEmp = ds.Tables[0].DefaultView;
						dvEmp.Sort = "Fullname";
						ds.Tables.Clear();
						ds.Tables.Add(master.CreateTableFromView(dvEmp));
						//////////////////////////////////////////////////////////

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
					DropDownListEntitiesItems.Items.Insert(0, new ListItem("----- Select Entity Item ----- ", "-1"));
					DataGridRlEnt.Visible =	false;
				}

			}
			else
			{
				DataGridRlEnt.Visible = false;
			}
				
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
			if (DataGridRlEnt.Items.Count == 0)
			{
				DataGridRlEnt.Visible = false;
			}
			else
			{
				DataGridRlEnt.Visible = true;
			}

		}

		#endregion 

		#region ButtonSelect_Click
		protected void ButtonSelect_Click(object sender, System.EventArgs e)
		{
			try
			{
				bool check = false;

				int rowCount =  DataGridRlEnt.Items.Count ;
				int roleGroupID=(int)Session["roleID"];
				SecurityWS.SecurityManagement secMang = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject ;
				for ( int i = rowCount -1  ; i >= 0;  i-- )
				{
					CheckBox ch = (CheckBox) DataGridRlEnt.Items[ i ].Cells[ 2 ].Controls[ 1 ];
					if ( ch.Checked  ) 
					{
						ListItem item = new ListItem();
						item.Value = DataGridRlEnt.Items[i].Cells[ 0 ].Text ;
						item.Text  = DataGridRlEnt.Items[i].Cells[ 1 ].Text.Trim() ; 
						int ruleEntityID=int.Parse(item.Value);
						secMang.AddRuleEntityToRuleGroup(ruleEntityID,roleGroupID);
						check = true;
					}
					ch.Checked = false;
				}
			
				DropDownListEntities.SelectedIndex = -1;  
				DropDownListEntitiesItems.SelectedIndex = -1;
				dataSetRuleEntity1.Clear();
				DataGridRlEnt.DataBind();
				DataGridRlEnt.Visible =	false;

				if ( check )
				{
					DropDownListEntitiesItems.Visible = true;
					Navigation.BaseObject.showMessage( "Entities have been added  successfully" , this.Page );
				}
				else
				{
					DropDownListEntitiesItems.Visible = false;
					Navigation.BaseObject.showMessage( "Please select an entity" , this.Page );
				}
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
			}
		}

		#endregion 

		#endregion 
	}
}
