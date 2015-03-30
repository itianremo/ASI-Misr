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
	public partial class RulesGroups : System.Web.UI.UserControl
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if ( !IsPostBack )
			{
				SecurityWS.SecurityManagement secMang = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject;
				DataSet ds = secMang.GetAllRulesEntities();
				ListBoxRulesEntities.DataSource =  ds;
				ListBoxRulesEntities.DataTextField  = "RuleEntityDescription";
				ListBoxRulesEntities.DataValueField = "RuleEntityID";
				ListBoxRulesEntities.DataBind();

				// ************* Test
//				((Navigation.BaseObject) Session[ "navigation" ]).Operation = Navigation.BaseObject.OperationType.UPADATE;
//				((Navigation.BaseObject) Session[ "navigation" ]).EntityID = 60;
//				((Navigation.BaseObject) Session[ "navigation" ]).EntityDescription = "memoo";
				//*************
				DataSet ds2 = new DataSet();
				//Data.DataSetRuleEntity dsRlEnt = new DataSetRuleEntity();
				ViewState[ "Ent" ] =  ds2;

				if ( ((Navigation.BaseObject) Session[ "navigation" ]).Operation == Navigation.BaseObject.OperationType.UPADATE )
				{
					// get rule group
					DataSet dsRG = secMang.GetRuleGroup( ((Navigation.BaseObject) Session[ "navigation" ]).EntityID );
					ViewState[ "RuleGroup" ]   = dsRG;

					// get rule group entities
					ds2 =  secMang.GetAllRuleEntitiesInRuleGroup( ((Navigation.BaseObject) Session[ "navigation" ]).EntityID );
					//dsRlEnt.Merge( ds2 );


					TextBoxGroupName.Text = ((Navigation.BaseObject) Session[ "navigation" ]).EntityDescription;
					ListBoxRuleGroups.DataSource = ds2 ;
					ListBoxRuleGroups.DataTextField  = "RuleEntityDescription";
					ListBoxRuleGroups.DataValueField = "RuleEntityID";
					ListBoxRuleGroups.DataBind();

					ButtonUpdate.Visible = true ;
					ButtonAdd.Visible	 = false ;
					ViewState[ "Ent" ]   = ds2; 
				}

			}


	//Navigation.BaseObject.showMessage( ((Navigation.BaseObject) Session[ "navigation" ]).EntityID.ToString() , this.Page );
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

		#region Controls Events 
		
		#region AddButton_Click
		protected void AddButton_Click(object sender, System.EventArgs e)
		{
			try
			{
				SecurityWS.SecurityManagement secMang = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject;

				int n = secMang.AddRuleGroup( TextBoxGroupName.Text ) ;
				if ( n != -1 )
				{
					Response.Write ( "<script language=javascript > alert ( 'The group hase been added sucessefuly' ) </script>" ) ;
					
					for ( int i = 0 ; i < ListBoxRuleGroups.Items.Count ; i++ )
					{
						secMang.AddRuleEntityToRuleGroup( Convert.ToInt32( ListBoxRuleGroups.Items[ i ].Value ) , n ) ;	
					}
				}
				else
					Navigation.BaseObject.showCallErrorMessage( "There has been error in creating Rule group:" , this.Page , ((Navigation.BaseObject) Session[ "navigation" ]).Token );  
				
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
				DataSet ds = (DataSet) ViewState[ "Ent" ] ;
				for ( int i = 0 ; i <  ListBoxRuleGroups.Items.Count ; i++ )
				{
					if ( ListBoxRuleGroups.Items[ i ].Selected )
					{
						for ( int j = 0 ; j <  ListBoxRuleGroups.Items.Count ; j++ )
						{
							if( ( ds.Tables[ 0 ].Rows[ j ].RowState != DataRowState.Deleted ) &&  ( ds.Tables[ 0 ].Rows[ j ][ "RuleEntityID" ].ToString() ==  ListBoxRuleGroups.Items[ i ].Value ) )
								ds.Tables[ 0 ].Rows[ j ].Delete(); 
						}
					}
				}
				ListBoxRuleGroups.Items.Clear();
				ListBoxRuleGroups.DataSource = ds ;
				ListBoxRuleGroups.DataBind();
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

				for ( int i = 0 ; i < ListBoxRulesEntities.Items.Count ; i++ )
				{
					if ( ListBoxRulesEntities.Items[ i ].Selected )
					{
							
						DataSetRuleEntity ds2 = new DataSetRuleEntity();
						DataSetRuleEntity.SEC_RuleEntityRow row =  ds2.SEC_RuleEntity.NewSEC_RuleEntityRow();
						row.RuleEntityID		  = Convert.ToInt32( ListBoxRulesEntities.Items[ i ].Value );
						row.RuleEntityDescription = ListBoxRulesEntities.Items[ i ].Text;
						ds2.SEC_RuleEntity.AddSEC_RuleEntityRow( row );
						ds2.Tables[ 0 ].TableName = "Table";
						ds.Merge( ds2 );
						ds.Tables[ 0 ].Rows[ ds.Tables[ 0 ].Rows.Count-1 ][ "RuleGroupID" ] = ((Navigation.BaseObject) Session[ "navigation" ]).EntityID ;
										
					}
				}
				ListBoxRuleGroups.DataSource = ds;
				ListBoxRuleGroups.DataTextField  = "RuleEntityDescription";
				ListBoxRuleGroups.DataValueField = "RuleEntityID";
				ListBoxRuleGroups.DataBind();
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

				SecurityWS.SecurityManagement secMang     = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject;

				// modify rule group
				DataSet ds = (DataSet) ViewState[ "RuleGroup" ];
				if ( ds.Tables[ 0 ].Rows.Count != 0 )
					ds.Tables[ 0 ].Rows[ 0 ][ "RuleGroupName" ] = TextBoxGroupName.Text;
				if ( ! secMang.ModifyRuleGroup( ds ))
					Navigation.BaseObject.showCallErrorMessage( "" , this.Page ,  ((Navigation.BaseObject) Session[ "navigation" ]).Token );

				
				// modify rule group entitires
				string ruleEnt , ruleGrp   ;
				DataSet lastDS = (DataSet) ViewState[ "Ent" ];
				DataView view1 = new DataView();
				view1.Table = lastDS.Tables[ 0 ];
				view1.RowStateFilter = DataViewRowState.Deleted;

				for ( int i = 0 ; i < view1.Count ; i++ )
				{
					ruleEnt = view1[ i ][ "RuleEntityID" ].ToString();
					ruleGrp = view1[ i ][ "RuleGroupID" ].ToString();
					secMang.RemoveRuleEntityFromRuleGroup( Convert.ToInt32( ruleEnt ) , Convert.ToInt32( ruleGrp )  );
				}

				view1.RowStateFilter = DataViewRowState.Added;
				for ( int i = 0 ; i < view1.Count ; i++ )
				{
					ruleEnt = view1[ i ][ "RuleEntityID" ].ToString();
					ruleGrp = view1[ i ][ "RuleGroupID" ].ToString();
					secMang.AddRuleEntityToRuleGroup( Convert.ToInt32( ruleEnt ) , Convert.ToInt32( ruleGrp ) );
				}

				lastDS.Clear();
				lastDS = secMang.GetAllRuleEntitiesInRuleGroup( ((Navigation.BaseObject) Session[ "navigation" ]).EntityID );
				ViewState[ "Ent" ] = lastDS;
			}
			catch ( Exception ee )
			{
				Navigation.BaseObject.showMessage (  ee.Message , this.Page );
			}
		}


		#endregion 

		


		#endregion 
	}
}
