
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	namespace TSN.ERP.WebGUI.Go
	{
		/// <summary>
		///		Summary description for MFGAdmins.
		/// </summary>
		public partial class MFGAdmins : System.Web.UI.UserControl
		{

			protected TSN.ERP.SharedComponents.Data.dsEmployee dsEmployee1;
			protected System.Data.DataSet dataSetMFGAdmins;
			protected TSN.ERP.SharedComponents.dsMFGGroupMember dsMFGGroupMember1;
			protected System.Data.DataSet dataSetMFGEmployees;

		
			protected void Page_Load(object sender, System.EventArgs e)
			{
				try
				{
					if( !IsPostBack )
					{
						Navigation.BaseObject.SafeMerge( dsEmployee1 , ((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListActiveEmployees());
						Navigation.BaseObject.SafeMerge( dataSetMFGAdmins , ((Navigation.BaseObject) Session[ "navigation" ]).MFGWSObject.GetAllMFGAdmins() );
						foreach(DataRow dr in dsEmployee1.Tables[0].Rows)
						{
							if(dr["UserID"] == DBNull.Value)
								
							{
								dr.Delete();
							}
						}
						dsEmployee1.AcceptChanges();

						DropDownListMFGAdmins.DataBind();
						DropDownListTSNEmp.DataBind();
						ListBoxTSNEmp.DataBind();

						DropDownListMFGAdmins.Items.Insert( 0 , new ListItem( "-- Select Admin -- " , "-1" ));	
						ViewState[ "NewMode" ] = false; 
						
					}

				}
				catch( Exception ee )
				{
					string s = ee.Message;
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
			/// Required method for Designer support - do not modify
			/// the contents of this method with the code editor.
			/// </summary>
			private void InitializeComponent()
			{    
				this.dsEmployee1 = new TSN.ERP.SharedComponents.Data.dsEmployee();
				this.dataSetMFGAdmins = new System.Data.DataSet();
				this.dataSetMFGEmployees = new System.Data.DataSet();
				this.dsMFGGroupMember1 = new TSN.ERP.SharedComponents.dsMFGGroupMember();
				((System.ComponentModel.ISupportInitialize)(this.dsEmployee1)).BeginInit();
				((System.ComponentModel.ISupportInitialize)(this.dataSetMFGAdmins)).BeginInit();
				((System.ComponentModel.ISupportInitialize)(this.dataSetMFGEmployees)).BeginInit();
				((System.ComponentModel.ISupportInitialize)(this.dsMFGGroupMember1)).BeginInit();
				// 
				// dsEmployee1
				// 
				this.dsEmployee1.DataSetName = "dsEmployee";
				this.dsEmployee1.Locale = new System.Globalization.CultureInfo("ar-EG");
				// 
				// dataSetMFGAdmins
				// 
				this.dataSetMFGAdmins.DataSetName = "NewDataSet";
				this.dataSetMFGAdmins.Locale = new System.Globalization.CultureInfo("en-US");
				// 
				// dataSetMFGEmployees
				// 
				this.dataSetMFGEmployees.DataSetName = "NewDataSet";
				this.dataSetMFGEmployees.Locale = new System.Globalization.CultureInfo("en-US");
				// 
				// dsMFGGroupMember1
				// 
				this.dsMFGGroupMember1.DataSetName = "dsMFGGroupMember";
				this.dsMFGGroupMember1.Locale = new System.Globalization.CultureInfo("en-US");
				((System.ComponentModel.ISupportInitialize)(this.dsEmployee1)).EndInit();
				((System.ComponentModel.ISupportInitialize)(this.dataSetMFGAdmins)).EndInit();
				((System.ComponentModel.ISupportInitialize)(this.dataSetMFGEmployees)).EndInit();
				((System.ComponentModel.ISupportInitialize)(this.dsMFGGroupMember1)).EndInit();

			}
			#endregion

			#region Save
			protected void ButtonSave_Click(object sender, System.EventArgs e)
			{
				int MFGAdminID= -1;
				
				if ( ListBoxMFGEmp.Items.Count == 0 )
				{
					LabelMsg.Text = "At least one employee should be selected ";
                    Navigation.BaseObject.showMessage("At least one employee should be selected.", this.Page);
					LabelMsg.Visible = true;
					return;
				}
				if( !Convert.ToBoolean( ViewState[ "NewMode" ] ) && DropDownListTSNEmp.SelectedValue != "-1" )
					MFGAdminID = Convert.ToInt32( DropDownListMFGAdmins.SelectedValue ) ;
				else if ( Convert.ToBoolean( ViewState[ "NewMode" ] ) )
					MFGAdminID = Convert.ToInt32( DropDownListTSNEmp.SelectedValue ) ;
				else if( !Convert.ToBoolean( ViewState[ "NewMode" ] ) && DropDownListTSNEmp.SelectedValue == "-1" )
				{
					LabelMsg.Text = "Please select MFG admin ";
                    Navigation.BaseObject.showMessage("Please select MFG admin.", this.Page);
					return;
				}
				
				// create employees dataset

				for( int i = 0 ; i < ListBoxMFGEmp.Items.Count ; i++ )
				{
					TSN.ERP.SharedComponents.dsMFGGroupMember.SEC_MFGGroupMemberRow  row = dsMFGGroupMember1.SEC_MFGGroupMember.NewSEC_MFGGroupMemberRow(); 
					row[ "MFGUserID" ] = MFGAdminID;
					row[ "ContactID" ] = Convert.ToInt32( ListBoxMFGEmp.Items[ i ].Value );
					dsMFGGroupMember1.SEC_MFGGroupMember.AddSEC_MFGGroupMemberRow( MFGAdminID , Convert.ToInt32( ListBoxMFGEmp.Items[ i ].Value ));
				}

				// add mfg employees
				if( !Convert.ToBoolean( ViewState[ "NewMode" ] ) )
				{
					((Navigation.BaseObject) Session[ "navigation" ]).MFGWSObject.AddMFGAdminEmployees( Convert.ToInt32( DropDownListMFGAdmins.SelectedValue ) , dsMFGGroupMember1 );
					DropDownListMFGAdmins.SelectedValue = "-1";
				}

				else if( Convert.ToBoolean( ViewState[ "NewMode" ] ) )
				{
					((Navigation.BaseObject) Session[ "navigation" ]).MFGWSObject.AddMFGAdminEmployees( Convert.ToInt32( DropDownListTSNEmp.SelectedValue ) , dsMFGGroupMember1 );
					// settings controls in New mode
					dataSetMFGAdmins.Merge( ((Navigation.BaseObject) Session[ "navigation" ]).MFGWSObject.GetAllMFGAdmins() );
					DropDownListMFGAdmins.DataBind();
					LabelMFG.Visible = false;
					DropDownListTSNEmp.Visible = false;
					DropDownListMFGAdmins.Enabled = true;
					Delete.Enabled = true;
					ViewState[ "NewMode" ]  = false;
					DropDownListMFGAdmins.Items.Insert( 0 , new ListItem( "-- Select Admin -- " , "-1" ));	
				}
                if(MFGAdminID==-1)
                {
                    Navigation.BaseObject.showMessage("MFG admin must be selected first.", this.Page);
                    return;
                }

				LabelMsg.Text = "MFG admin data has been updated successfully";
                Navigation.BaseObject.showMessage("MFG admin data has been updated successfully.", this.Page);
				LabelMsg.Visible = true;
				ButtonNew.Enabled = true;
				TextBoxMFGName.Text = "";
				ListBoxMFGEmp.Items.Clear();
			}

			#endregion 

			#region Delete
			protected void Delete_Click(object sender, System.EventArgs e)
			{
                if (((Navigation.BaseObject)Session["navigation"]).MFGWSObject.DeleteMFGAdmin(Convert.ToInt32(DropDownListMFGAdmins.SelectedValue)) > 0)
                {
                    LabelMsg.Text = "MFG admin has been deleted successfully";
                    Navigation.BaseObject.showMessage("MFG admin data has been deleted successfully.", this.Page);
                    LabelMsg.Visible = true;
                    dataSetMFGAdmins.Merge(((Navigation.BaseObject)Session["navigation"]).MFGWSObject.GetAllMFGAdmins());
                    DropDownListMFGAdmins.DataBind();
                    TextBoxMFGName.Text = "";
                    ListBoxMFGEmp.Items.Clear();
                    DropDownListMFGAdmins.Items.Insert(0, new ListItem("-- Select Admin -- ", "-1"));
                }
                else
                {
                    Navigation.BaseObject.showMessage("MFG admin must be selected first.", this.Page);
                }

			}

			#endregion

			#region New
			protected void ButtonNew_Click(object sender, System.EventArgs e)
			{
				LabelMFG.Visible = true;
				DropDownListTSNEmp.Visible = true;
				DropDownListMFGAdmins.Enabled = false;
				Delete.Enabled = false;
				LabelMsg.Visible = false;
				ViewState[ "NewMode" ]  = true;
				ButtonNew.Enabled = false;
				TextBoxMFGName.Text = "";
				ListBoxMFGEmp.Items.Clear();
			}

			#endregion 

			#region Remobe Employee
			protected void ButtonOut_Click(object sender, System.EventArgs e)
			{
				for( int i = 0 ; i < ListBoxMFGEmp.Items.Count ; i++ )
				{
					if( ListBoxMFGEmp.Items[ i ].Selected )
						ListBoxMFGEmp.Items.RemoveAt( i );
				}
			
			}

			#endregion 

			#region Add Employee
			protected void ButtonIn_Click(object sender, System.EventArgs e)
			{
				for( int i = 0 ; i < ListBoxTSNEmp.Items.Count ; i++ )
				{
					if( ListBoxTSNEmp.Items[ i ].Selected && !ListBoxMFGEmp.Items.Contains( new ListItem( ListBoxTSNEmp.Items[ i ].Text , ListBoxTSNEmp.Items[ i ].Value ) ) )
						ListBoxMFGEmp.Items.Add( new ListItem( ListBoxTSNEmp.Items[ i ].Text , ListBoxTSNEmp.Items[ i ].Value ));			
				}
			}

			#endregion 

			#region DropDownListMFGAdmins_SelectedIndexChanged
			protected void DropDownListMFGAdmins_SelectedIndexChanged(object sender, System.EventArgs e)
			{
				dataSetMFGEmployees.Clear();
				ListBoxMFGEmp.Items.Clear();

				if( DropDownListMFGAdmins.SelectedValue != "-1" )
					TextBoxMFGName.Text = DropDownListMFGAdmins.SelectedItem.ToString();
				else
				{
					TextBoxMFGName.Text = "";
					return;
				}

				
				dataSetMFGEmployees.Merge( ((Navigation.BaseObject) Session[ "navigation" ]).MFGWSObject.GetMFGAdminEmployees( Convert.ToInt32( DropDownListMFGAdmins.SelectedValue ) ) );
				foreach( DataRow row in  dataSetMFGEmployees.Tables[ 0 ].Rows )
				{
					ListBoxMFGEmp.Items.Add( new ListItem( row[ "Fullname" ].ToString() , row[ "ContactID" ].ToString() ));
				}
				LabelMsg.Text ="";
			}

			#endregion 

			#region DropDownListTSNEmp_SelectedIndexChanged
			protected void DropDownListTSNEmp_SelectedIndexChanged(object sender, System.EventArgs e)
			{
				TextBoxMFGName.Text = DropDownListTSNEmp.SelectedItem.ToString();
				dataSetMFGEmployees.Clear();
				ListBoxMFGEmp.Items.Clear();
				LabelMsg.Text ="";
				
			}

			#endregion 


		
		}
	}

