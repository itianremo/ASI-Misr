namespace TSN.ERP.WebGUI.Go
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using TSN.ERP.SharedComponents.Data;
	using TSN.ERP.WebGUI.Data;
	using Navigation;

	/// <summary>
	///		Summary description for Teams1.
	/// </summary>
	public partial class Teams1 : System.Web.UI.UserControl
	{
		protected TSN.ERP.SharedComponents.Data.dsEmployee dsEmployee1;
		protected TSN.ERP.SharedComponents.Data.dsTeams dsTeams1;
		protected TSN.ERP.SharedComponents.Data.dsEmployee dsEmployee2;
		MasterMethods master = new MasterMethods();

		protected void Page_Load(object sender, System.EventArgs e)
		{
            lblTeams.Visible = false;
			// Put user code to initialize the page here
			LoadTeams();
			lblAdded.Text = "" ;
			if ( ! IsPostBack ) 
			{
				Label1.Visible = false;
				Label2.Visible = false;
				dgTeams.DataBind();
				LoadDefaultTeam();			    
			}
			if(dgTeams.Items.Count == 0)
			{
				btnSaveDiscription.Visible=false;
				btnAddEmployee.Visible=false;
				btnRemoveEmployee.Visible = false;
			}
			else
			{
				btnSaveDiscription.Visible=true;
				btnAddEmployee.Visible=true;
				btnRemoveEmployee.Visible = true;
			}
		}

		private void LoadTeams()
		{
			BaseObject.SafeMerge(dsTeams1,((Navigation.BaseObject) Session[ "navigation" ]).TeamsWSObject.ListTeams());
		}	
		

		private void LoadDefaultTeam()
		{
			if ( dgTeams.Items.Count != 0 )
			{
				DataGridItem itm = (DataGridItem) dgTeams.Items[0] ; 
				LinkButton LinkB = (LinkButton) itm.Cells[0].Controls[1];
				ViewState["RowIndex"] = 0 ;
				ViewState["TeamID"] = itm.Cells[ 1 ].Text ;
				ViewState["TeamName"] = LinkB.Text;             
				ViewState["LeaderName"] = itm.Cells[ 3 ].Text; 
				ViewState["Description"] = itm.Cells[ 4 ].Text;
				LoadTeamsDetails(Convert.ToInt32(ViewState["TeamID"]));
				dgTeams.SelectedIndex = 0;
			}

		}
		protected void LoadTeamById (object sender , System.EventArgs e )
		{
			DataGridItem itm = (DataGridItem) ((LinkButton) sender).Parent.Parent;
			ViewState["RowIndex"] = itm.ItemIndex;
			ViewState["TeamID"] = itm.Cells[ 1 ].Text ;
			ViewState["TeamName"] = ((LinkButton) sender).Text; 
			ViewState["LeaderName"] = itm.Cells[ 3 ].Text; 
			if ( itm.Cells[ 4 ].Text != "&nbsp;" )
				ViewState["Description"] = itm.Cells[ 4 ].Text;
			else
				ViewState["Description"] = "";

			LoadTeamsDetails(Convert.ToInt32(ViewState["TeamID"]));
		    dgTeams.SelectedIndex = itm.ItemIndex;
			if(itm.ItemIndex == 0)
			{
				dgTeams.Items[0].CssClass = "offday";
			}
			else
			{
				dgTeams.Items[0].CssClass = "bsnormaltd";
			}
			Label2.Visible = false;

			
		}
		private void LoadTeamsDetails(int TeamID)
		{
			((Navigation.BaseObject) Session[ "navigation" ]).EntityID = TeamID;

			dsEmployee2.Clear();
			BaseObject.SafeMerge(dsEmployee2,((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListActiveEmployees());
			dsEmployee1.Clear();
			BaseObject.SafeMerge(dsEmployee1,((Navigation.BaseObject) Session[ "navigation" ]).TeamsWSObject.ListTeamEmployees(TeamID));
			dsEmployee cachAllEmp = new dsEmployee();
            BaseObject.SafeMerge(cachAllEmp,dsEmployee2);
			Session["CacheAllEmp"] = cachAllEmp ;
			dgTeamMembers.DataBind(); 
			txtTeamName.Text = ViewState["TeamName"].ToString();
			string NullTeamLeader = "&nbsp;" ;
		

			drpLeaderName.DataBind();
			ListItem TempItem = new ListItem();
			TempItem.Text = "---- Select Item -----";
			TempItem.Value = "-1";
			drpLeaderName.Items.Insert(0,TempItem);

			if (ViewState["LeaderName"].ToString() != NullTeamLeader)
			drpLeaderName.SelectedValue = ViewState["LeaderName"].ToString();  
		    txtDescription.Text = ViewState["Description"].ToString().Replace("&nbsp;","");
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
			this.dsEmployee1 = new TSN.ERP.SharedComponents.Data.dsEmployee();
			this.dsTeams1 = new TSN.ERP.SharedComponents.Data.dsTeams();
			this.dsEmployee2 = new TSN.ERP.SharedComponents.Data.dsEmployee();
			((System.ComponentModel.ISupportInitialize)(this.dsEmployee1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTeams1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsEmployee2)).BeginInit();
			this.dgTeamMembers.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgTeamMembers_ItemDataBound);
			this.dgEmployeeList.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgEmployeeList_PageIndexChanged);
			// 
			// dsEmployee1
			// 
			this.dsEmployee1.DataSetName = "dsEmployee";
			this.dsEmployee1.EnforceConstraints = false;
			this.dsEmployee1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// dsTeams1
			// 
			this.dsTeams1.DataSetName = "dsTeams";
			this.dsTeams1.EnforceConstraints = false;
			this.dsTeams1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dsEmployee2
			// 
			this.dsEmployee2.DataSetName = "dsEmployee";
			this.dsEmployee2.Locale = new System.Globalization.CultureInfo("ar-EG");
			((System.ComponentModel.ISupportInitialize)(this.dsEmployee1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTeams1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsEmployee2)).EndInit();

		}
		#endregion

		protected void btnRemoveEmployee_Click(object sender, System.EventArgs e)
		{
			dsEmployee1.Clear();
			BaseObject.SafeMerge(dsEmployee1,((Navigation.BaseObject) Session[ "navigation" ]).TeamsWSObject.ListTeamEmployees(Convert.ToInt32(ViewState["TeamID"])));

				int rowCount =  dgTeamMembers.Items.Count ;
				for ( int i = rowCount - 1   ; i >= 0 ;  i-- )
				{
					CheckBox ch = (CheckBox) dgTeamMembers.Items[ i ].Cells[ 1 ].Controls[ 1 ];
					if ( ch.Checked  ) 
					{
						int EmpId = dsEmployee1.GEN_Employees[i].ContactID ;
						((Navigation.BaseObject) Session[ "navigation" ]).TeamsWSObject.RemoveEmployeeFromTeam(EmpId,Convert.ToInt32(ViewState["TeamID"]));
					}
				}
				dsEmployee1.Clear();
				
			BaseObject.SafeMerge(dsEmployee1,((Navigation.BaseObject) Session[ "navigation" ]).TeamsWSObject.ListTeamEmployees(Convert.ToInt32(ViewState["TeamID"])));
			dgTeamMembers.DataBind();
            if (rowCount == dgTeamMembers.Items.Count)
            {
                Navigation.BaseObject.showMessage("Please Select Employee to remove.", this.Page);
                return;
            }
		}

		
		protected void btnSaveDiscription_Click(object sender, System.EventArgs e)
		{
			if(Page.IsValid)
			{
				dsTeams.GEN_TeamsRow row = dsTeams1.GEN_Teams[Convert.ToInt32(ViewState["RowIndex"])];
				row.TeamName =  txtTeamName.Text;
				if ( drpLeaderName.SelectedIndex > -1 )
					row.TeamLeader = Convert.ToInt32(drpLeaderName.SelectedValue);
				row.TeamDesc =  txtDescription.Text;
				ViewState["LeaderName"] = drpLeaderName.SelectedItem.Text;
				// Edits Row in dataset	
			
				bool flag = CheckTeamForEdit(dsTeams1,txtTeamName.Text.Trim(),int.Parse(row.TeamID.ToString()));
				if(flag)
				{
					((Navigation.BaseObject) Session[ "navigation" ]).TeamsWSObject.EditTeams(dsTeams1);
					dsTeams1.Clear();
					BaseObject.SafeMerge(dsTeams1,((Navigation.BaseObject) Session[ "navigation" ]).TeamsWSObject.ListTeams());
					dgTeams.DataBind();
					Label2.Visible = false;
				}
				else
				{
					Label2.Visible = true;
					Label2.Text = "This team already exist, please try another name";
				}
			}
		}

		protected void btnAddEmployee_Click(object sender, System.EventArgs e)
		{
			
			BaseObject.SafeMerge(dsEmployee2,((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListActiveEmployees());
            //Sort Employees DataSet//////////////////////////////////
            DataView dvEmp = dsEmployee2.GEN_Employees.DefaultView;
            dvEmp.Sort = "FirstName";
            dsEmployee2.Tables.Clear();
            dsEmployee2.Tables.Add(master.CreateTableFromView(dvEmp));
            //////////////////////////////////////////////////////////
			dgEmployeeList.Visible = true;
			dgEmployeeList.DataBind();
            RadioButtonList1.SelectedIndex = 0;
			Panel3.Visible = true;
			Panel1.Visible = false;
			
		}
		public bool CheckTeamForEdit(TSN.ERP.SharedComponents.Data.dsTeams ds,string TeamName,int TeamID)
		{
			bool flag = true ;
			foreach(DataRow dr in ds.Tables["GEN_Teams"].Rows)
			{
				flag = true;
				if(dr["TeamName"].ToString().Trim().ToLower() == TeamName.Trim().ToLower() && int.Parse(dr["TeamID"].ToString().Trim())!=TeamID)
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
		public bool CheckTeamByName(TSN.ERP.SharedComponents.Data.dsTeams ds,string TeamName)
		{
			bool flag = true ;
			foreach(DataRow dr in ds.Tables["GEN_Teams"].Rows)
			{
				flag = true;
				if(dr["TeamName"].ToString().Trim().ToLower()== TeamName.Trim().ToLower())
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

		protected void NewTeam_Click(object sender, System.EventArgs e)
		{
			if(Page.IsValid)
			{
				dsTeams.GEN_TeamsRow row = dsTeams1.GEN_Teams.NewGEN_TeamsRow();
				// Build Row
				row.TeamName =  txtNewTeamName.Text;
				string TeamName= row.TeamName;
				row.TeamLeader = Convert.ToInt32(drpNewTeamLeader.SelectedValue);
				row.TeamDesc =  txtNewTeamDesc.Text;
				bool flag = CheckTeamByName(dsTeams1,txtNewTeamName.Text.Trim());
				if(flag)
				{
					// Adds Row in dataset	
					dsTeams1.GEN_Teams.AddGEN_TeamsRow(row);
					((Navigation.BaseObject) Session[ "navigation" ]).TeamsWSObject.AddTeams(dsTeams1);
					btnSaveDiscription.Visible=true;
					btnAddEmployee.Visible=true;
					btnRemoveEmployee.Visible = true;
			
					dsTeams1.Clear();
					BaseObject.SafeMerge(dsTeams1,((Navigation.BaseObject) Session[ "navigation" ]).TeamsWSObject.ListTeams());
					dgTeams.DataBind();
					txtNewTeamName.Text = "";
					txtNewTeamDesc.Text = "";
			
					LoadDefaultTeam();
					// reset the dgTeams.SelectedIndex
					for( int i = 0 ; i < dsTeams1.GEN_Teams.Rows.Count ; i++ )
						if( ViewState["TeamID"].ToString() == dsTeams1.GEN_Teams.Rows[ i ][ "TeamID" ].ToString() )
						{
							dgTeams.SelectedIndex = i;
							break;
						}


					/////////////////////////////////////////////////
//					DataGridItem itm = dgTeams.Items[0];
//					foreach(DataGridItem currentItem in dgTeams.Items)
//					{
//						if(((LinkButton)currentItem.Cells[ 0 ].Controls[1]).Text == TeamName)
//						{
//							itm = currentItem;
//							dgTeams.SelectedIndex = itm.ItemIndex;
//							break;
//						}
//					}
//					LoadTeamsDetails(int.Parse(itm.Cells[1].Text));

					

//					///DataGridItem itm = (DataGridItem) ((LinkButton) sender).Parent.Parent;
//					ViewState["RowIndex"] = dgTeams.SelectedIndex;
//					ViewState["TeamID"] = dgTeams.Items[dgTeams.SelectedIndex].Cells[ 1 ].Text ;
//					ViewState["TeamName"] = ((LinkButton)dgTeams.Items[dgTeams.SelectedIndex].Cells[ 1 ].Controls[0]).Text; 
//					ViewState["LeaderName"] = dgTeams.Items[dgTeams.SelectedIndex].Cells[3].Text; 
//					if ( dgTeams.Items[dgTeams.SelectedIndex].Cells[ 4 ].Text != "&nbsp;" )
//						ViewState["Description"] = dgTeams.Items[dgTeams.SelectedIndex].Cells[ 4 ].Text;
//					else
//						ViewState["Description"] = "";
//
//					LoadTeamsDetails(Convert.ToInt32(ViewState["TeamID"]));
					/////////////////////////////////////////////////
					
					
					Panel1.Visible = true ;
					Panel2.Visible = false;
				}
				else
				{
					Label1.Visible =true;
					Label1.Text = "This team already exist, please try another name";
				}
			}
		}

		private void lnkNewTeam_Click(object sender, System.EventArgs e)
		{
			LoadAllEmployees();
			Panel2.Visible = true ;
			Panel1.Visible = false;
		
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Panel1.Visible = true ;
			Panel2.Visible = false;
		    txtNewTeamName.Text = "";
		    txtNewTeamDesc.Text = "";
			Label1.Text = String.Empty;
		}
	
		private void LoadAllEmployees ()
		{
		    BaseObject.SafeMerge(dsEmployee2,((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListActiveEmployees());
			drpNewTeamLeader.DataBind();
		}

		protected void btnRemoveTeam_Click(object sender, System.EventArgs e)
		{
			int rowCount =  dgTeams.Items.Count ;
            int checkCount = 0;
			for ( int i = rowCount -1   ; i >= 0 ;  i-- )
			{
				CheckBox ch = (CheckBox) dgTeams.Items[ i ].Cells[ 5 ].Controls[ 1 ];
				if ( ch.Checked  ) 
				{
     				dsTeams1.GEN_Teams.Rows[i].Delete();
					txtTeamName.Text = "" ;
					txtDescription.Text = "" ;
					drpLeaderName.SelectedIndex = 0;
					dsEmployee1.Clear();
					dgTeamMembers.DataBind();
                    checkCount++;
				}
			}
            if (checkCount == 0)
            {
                lblTeams.Visible = true;
            }
            else
            {
                lblTeams.Visible = false;
            }
			((Navigation.BaseObject) Session[ "navigation" ]).TeamsWSObject.DeleteTeams(dsTeams1);
			
			dsTeams1.Clear();
			BaseObject.SafeMerge(dsTeams1,((Navigation.BaseObject) Session[ "navigation" ]).TeamsWSObject.ListTeams());
	     	dgTeams.DataBind(); 
			if(dgTeams.Items.Count > 0)
			{
				btnAddEmployee.Visible=true;
				btnRemoveEmployee.Visible = true;

				int teamdID ;
				string TeamName, LeaderName, TeamDesc;

				int selectedIndex;
				if(dgTeams.SelectedIndex == dgTeams.Items.Count)
				{
					selectedIndex = 0;
					teamdID = int.Parse(dgTeams.Items[selectedIndex].Cells[1].Text);
					TeamName = ((LinkButton)dgTeams.Items[selectedIndex].Cells[0].Controls[1]).Text;
					LeaderName = dgTeams.Items[selectedIndex].Cells[3].Text;
					TeamDesc = dgTeams.Items[selectedIndex].Cells[4].Text;
					dgTeams.Items[0].CssClass = "offday";
				}
				else
				{
					selectedIndex = dgTeams.SelectedIndex;
					teamdID = int.Parse(dgTeams.Items[selectedIndex].Cells[1].Text);
					TeamName = ((LinkButton)dgTeams.Items[selectedIndex].Cells[0].Controls[1]).Text;
					LeaderName = dgTeams.Items[selectedIndex].Cells[3].Text;
					TeamDesc = dgTeams.Items[selectedIndex].Cells[4].Text;
				}
				ViewState["TeamName"] = TeamName;
				ViewState["LeaderName"] = LeaderName;
				ViewState["Description"] = TeamDesc;
				LoadTeamsDetails(int.Parse(dgTeams.Items[selectedIndex].Cells[1].Text));				
			}
			else
			{
				btnSaveDiscription.Visible=false;
				btnAddEmployee.Visible=false;
				btnRemoveEmployee.Visible = false;
			}
			
		}

		protected void btnCancelAddEmp_Click(object sender, System.EventArgs e)
		{
			Panel1.Visible = true;
			Panel3.Visible = false;
		}

		protected void btnAddEmp_Click(object sender, System.EventArgs e)
		{
            //dsEmployee dstemp = (dsEmployee) Session["CacheAllEmp"];
			int rowCount =  dgEmployeeList.Items.Count ;
            //int pagsize = dgEmployeeList.PageSize;
			int EmpCount = 0 ;
			bool VBAdded = true;
			for ( int i = rowCount -1   ; i >= 0 ;  i-- )
			{
				CheckBox ch = (CheckBox) dgEmployeeList.Items[ i ].Cells[ 2 ].Controls[ 1 ];
				if ( ch.Checked  ) 
				{
                    //int pagno  = dgEmployeeList.CurrentPageIndex;
                    //int EmpId = dstemp.GEN_Employees[i/*+(pagno*pagsize)*/].ContactID;
                    int EmpId = Convert.ToInt32(dgEmployeeList.Items[i].Cells[0].Text);
					int EmpsAdded =((Navigation.BaseObject) Session[ "navigation" ]).TeamsWSObject.AddEmployeeToTeam(EmpId,Convert.ToInt32(ViewState["TeamID"]));
					if(EmpsAdded==-1)
					{
						VBAdded = false;										
					}
					ch.Checked = false ;
				    EmpCount = EmpCount + 1 ;
				}
			}
			dsEmployee1.Clear();
			BaseObject.SafeMerge(dsEmployee1,((Navigation.BaseObject) Session[ "navigation" ]).TeamsWSObject.ListTeamEmployees(Convert.ToInt32(ViewState["TeamID"])));
			dgTeamMembers.DataBind(); 
			if (VBAdded)
			{
                if (EmpCount == 0)
                {
                    Navigation.BaseObject.showMessage("Please select Employee.", this.Page);
                    return;
                }
                else
                {
                    lblAdded.Text = EmpCount.ToString() + " Employee(s) Added";
                }
			}
			else
			{
				lblAdded.Text = "Some employee(s) are already added to current team.";
			}
		}

		private void dgEmployeeList_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.dgEmployeeList.CurrentPageIndex=e.NewPageIndex;
			dsEmployee dstemp = (dsEmployee) Session["CacheAllEmp"];
			BaseObject.SafeMerge(dsEmployee2,dstemp);
			dgEmployeeList.DataBind();
		}

		protected void btnNewTeam_Click(object sender, System.EventArgs e)
		{
			LoadAllEmployees();
			Panel2.Visible = true ;
			Panel1.Visible = false;
			Label1.Text=String.Empty;
			Label1.Visible = false;
		}

		protected void txtDescription_Load(object sender, System.EventArgs e)
		{
			if(txtDescription.Text=="&nbsp;")
			{
				txtDescription.Text=String.Empty;
			}
		}

		protected void drpLeaderName_DataBinding(object sender, System.EventArgs e)
		{
			//Sort Employees DataSet//////////////////////////////////
			DataView dvEmp = dsEmployee2.GEN_Employees.DefaultView;
			dvEmp.Sort = "Fullname";
			dsEmployee2.Tables.Clear();
			dsEmployee2.Tables.Add(master.CreateTableFromView(dvEmp));
			//////////////////////////////////////////////////////////
		}

		protected void drpNewTeamLeader_DataBinding(object sender, System.EventArgs e)
		{
			//Sort Employees DataSet//////////////////////////////////
			DataView dvEmp = dsEmployee2.GEN_Employees.DefaultView;
			dvEmp.Sort = "Fullname";
			dsEmployee2.Tables.Clear();
			dsEmployee2.Tables.Add(master.CreateTableFromView(dvEmp));
			//////////////////////////////////////////////////////////
		}

		private void dgTeamMembers_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				if(e.Item.Cells[2].Text == "0")
				{
//					((CheckBox)e.Item.Cells[1].Controls[1]).Visible = false;
					e.Item.CssClass = "completetask";
					e.Item.HorizontalAlign = HorizontalAlign.Center;
					e.Item.Cells[0].Style.Add("font-family", "Arial, Helvetica, sans-serif");
					e.Item.Cells[0].Style.Add("font-size", "13px");
				}
			}
		}





        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BaseObject.SafeMerge(dsEmployee2, ((Navigation.BaseObject)Session["navigation"]).EmployeeWsObject.ListActiveEmployees());
            //Sort Employees DataSet//////////////////////////////////
            DataView dvEmp = dsEmployee2.GEN_Employees.DefaultView;
            if(RadioButtonList1.SelectedIndex==0)
            {
                if (chkSortOrder.Checked)
                    dvEmp.Sort = "FirstName Desc";
                else
                    dvEmp.Sort = "FirstName";

            }
            else if (RadioButtonList1.SelectedIndex == 1)
            {
                if (chkSortOrder.Checked)
                    dvEmp.Sort = "LastName Desc";
                else
                    dvEmp.Sort = "LastName";
            }                       
            dsEmployee2.Tables.Clear();
            dsEmployee2.Tables.Add(master.CreateTableFromView(dvEmp));
            Session["CacheAllEmp"] = dsEmployee2;
            dgEmployeeList.DataBind();
            //////////////////////////////////////////////////////////
        }
        //protected void chkSortOrder_CheckedChanged(object sender, EventArgs e)
        //{
        //    BaseObject.SafeMerge(dsEmployee2, ((Navigation.BaseObject)Session["navigation"]).EmployeeWsObject.ListActiveEmployees());
        //    //Sort Employees DataSet//////////////////////////////////
        //    DataView dvEmp = dsEmployee2.GEN_Employees.DefaultView;
        //    if (RadioButtonList1.SelectedIndex == 0)
        //    {
        //        if (chkSortOrder.Checked)
        //            dvEmp.Sort = "FirstName Desc";
        //        else
        //            dvEmp.Sort = "FirstName";

        //    }
        //    else if (RadioButtonList1.SelectedIndex == 1)
        //    {
        //        if (chkSortOrder.Checked)
        //            dvEmp.Sort = "LastName Desc";
        //        else
        //            dvEmp.Sort = "LastName";
        //    }
        //    dsEmployee2.Tables.Clear();
        //    dsEmployee2.Tables.Add(master.CreateTableFromView(dvEmp));
        //    Session["CacheAllEmp"] = dsEmployee2;
        //    dgEmployeeList.DataBind();
        //    //////////////////////////////////////////////////////////
        //}
}
}
