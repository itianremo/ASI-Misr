namespace TSN.ERP.WebGUI.Go
{
	using System;
	using System.Collections;
	using System.Data;
	using System.Drawing;
	using System.Web;
    using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using TSN.ERP.SharedComponents.Data;
	using TSN.ERP.WebGUI.Data;
	using Navigation;
	using System.Globalization;

	/// <summary>
	///		Summary description for TestUser.
	/// </summary>
	public partial class ProjectsList : System.Web.UI.UserControl
	{		
		public DataRow dr ;
        public dsProjects dsProjects1;
		#region Controls Definitions 

        protected TSN.ERP.SharedComponents.Data.dsEmployee dsEmployee1;
		protected System.Data.DataView dataView1;
		protected TSN.ERP.SharedComponents.Data.dsTasks dsTasks1;
		protected System.Web.UI.WebControls.LinkButton AdvancedSearch ;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected TSN.ERP.SharedComponents.Data.dsProjectsLevels dsProjectsLevels1;
		protected TSN.ERP.SharedComponents.Data.dsJobtitles dsJobtitles1;

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
            this.dsProjects1 = new TSN.ERP.SharedComponents.Data.dsProjects();
            this.dsEmployee1 = new TSN.ERP.SharedComponents.Data.dsEmployee();
            this.dataView1 = new System.Data.DataView();
            this.dsTasks1 = new TSN.ERP.SharedComponents.Data.dsTasks();
            this.dsProjectsLevels1 = new TSN.ERP.SharedComponents.Data.dsProjectsLevels();
            this.dsJobtitles1 = new TSN.ERP.SharedComponents.Data.dsJobtitles();
            ((System.ComponentModel.ISupportInitialize)(this.dsProjects1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmployee1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTasks1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProjectsLevels1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsJobtitles1)).BeginInit();
            // 
            // dsProjects1
            // 
            this.dsProjects1.DataSetName = "dsProjects";
            this.dsProjects1.EnforceConstraints = false;
            this.dsProjects1.Locale = new System.Globalization.CultureInfo("ar-EG");
            // 
            // dsEmployee1
            // 
            this.dsEmployee1.DataSetName = "dsEmployee";
            this.dsEmployee1.EnforceConstraints = false;
            this.dsEmployee1.Locale = new System.Globalization.CultureInfo("ar-EG");
            // 
            // dataView1
            // 
            this.dataView1.Sort = "Fullname";
            this.dataView1.Table = this.dsEmployee1.GEN_Employees;
            // 
            // dsTasks1
            // 
            this.dsTasks1.DataSetName = "dsTasks";
            this.dsTasks1.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // dsProjectsLevels1
            // 
            this.dsProjectsLevels1.DataSetName = "dsProjectsLevels";
            this.dsProjectsLevels1.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // dsJobtitles1
            // 
            this.dsJobtitles1.DataSetName = "dsJobtitles";
            this.dsJobtitles1.Locale = new System.Globalization.CultureInfo("ar-EG");
            ((System.ComponentModel.ISupportInitialize)(this.dsProjects1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmployee1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTasks1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProjectsLevels1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsJobtitles1)).EndInit();

		}
		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
            SecButtonsDeleteTsk.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this task?')");
            btnDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete project?')");
            txtDeliverDate.Attributes.Add("readonly", "true");
            txtCriticalDate.Attributes.Add("readonly", "true");
            lblmsgAssaign.Text = "";
//			bool x;
//			DataSet ds = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewTaskByProject(43);
//			x=BaseObject.SafeMerge(dsTasks1,((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewTaskByProject(43));

			if( !IsPostBack )
				btnCompleteProject.Attributes.Add("onclick", "if(confirm('Are you sure you want to complete this project?')){}else{return false}") ;

			if ((string) Session["ConfirmMessage"] == "1")
			{
				Response.Write("<script>alert('Tasks Have Been Added To The Employee(s)')</script>");
                Session["ConfirmMessage"] = "0";
			}

			if (Session["SaveMode"] == null)
					Session["SaveMode"] = 0;

			if (Session["BackToProjectTask"] == null)
                Session["BackToProjectTask"] = 0;

			if ( Session["ProjectID"] != null )
				((Navigation.BaseObject) Session[ "navigation" ]).EntityID = int.Parse( Session["ProjectID"].ToString() ) ;

			if ((int)Session["BackToProjectTask"]!=1)
			{
				Navigation.BaseObject.SafeMerge( dsProjectsLevels1 , ((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.ListAllProjectsLevels() );
				LoadProjects();

				if ( ! IsPostBack ) 
				{
					CheckButtonVisibilty();
					LoadProjectsManagerDropDownList();
				}

			}
			else
			{
				((BaseObject)Session[ "Navigation" ]).Operation = BaseObject.OperationType.UPADATE ;
				ReLoadProject();
				checkUpdateAndNewProjectButtons();
			}
			lblMSG.Text ="";

            int userID = ((Navigation.BaseObject)Session["navigation"]).SecurityWsObject.GetUserIDByContactID(Convert.ToInt32(Session["CurrentEmployee"]));
            bool hasAddProjectAccess = ((Navigation.BaseObject)Session["navigation"]).SecurityWsObject.CheckRuleXUserID(userID, 5001);
            // disibale managers dropdown list if the user is not admin
            if (!(((Navigation.BaseObject)Page.Session["navigation"]).SecInfo.IsAdministrator) && !hasAddProjectAccess)
            {
                drpManagerList.Enabled = false;
                IMG2.Visible = false;
            }
		}


		#region check Header
		
		protected void chkHeader_CheckedChanged(object a, System.EventArgs b)
		{
			CheckBox chk1=(CheckBox)a;
			if(chk1.Checked)
			{
				foreach(DataGridItem item in dgAssignedEmp.Items)
				{
					if(item.ItemType==ListItemType.Item||item.ItemType==ListItemType.AlternatingItem)
					{
						CheckBox SelectEmployee=(CheckBox)item.FindControl("SelectEmployee");
						SelectEmployee.Checked=true;
					}
				}
			}
			else
			{
				foreach(DataGridItem item in dgAssignedEmp.Items)
				{
					if(item.ItemType==ListItemType.Item||item.ItemType==ListItemType.AlternatingItem)
					{
						CheckBox SelectEmployee=(CheckBox)item.FindControl("SelectEmployee");
						SelectEmployee.Checked=false;
					}
				}
			}
		}
		
		private void ClearChkBoxHeader()
		{
			DataGridItem item = (DataGridItem)dgAssignedEmp.Controls[0].Controls[0];
			CheckBox chkHeader = (CheckBox)item.FindControl("chkHeader");
			chkHeader.Checked = false;	

			int rowCountForTask =  dgAssignedEmp.Items.Count ;
			for ( int i = rowCountForTask -1   ; i >= 0 ;  i-- )
			{
				CheckBox chk = (CheckBox) dgAssignedEmp.Items[ i ].Cells[ 3 ].Controls[ 1 ];
				if ( chk.Checked  ) 
				{
					chk.Checked = false ;

				}
			}
		}
		
		#endregion

		#region Load Projects
		private void LoadProjects()
		{
			BaseObject.SafeMerge(dsProjects1,((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.ListUserProjects());
            //Filter Projects List
            MasterMethods master = new MasterMethods();
            DataView dvProjects = dsProjects1.Tables[0].DefaultView;
            dvProjects.Sort = "ProjectName";
            if (rblActiveProjects.SelectedIndex == 0)
            {
                dvProjects.RowFilter = "ProjectStatus = 1";
            }
            else
            {
                dvProjects.RowFilter = "";
            }
            DataTable dtProjects = master.CreateTableFromView(dvProjects);
            //dsProjects1.Tables.Clear();
            dsProjects1.GEN_Projects.Rows.Clear();
            foreach (dsProjects.GEN_ProjectsRow row in dtProjects.Rows)
            {
                dsProjects1.GEN_Projects.ImportRow(row);
            }
            //dsProjects1.Tables.Add(master.CreateTableFromView(dvProjects));
            //////////////////////
			dgProjectList.DataBind();

			// set parent name of the projects 
			foreach( DataGridItem gridItem in dgProjectList.Items )
			{
				if ( Server.HtmlDecode( gridItem.Cells[ 6 ].Text ).Trim() != ""  )// get project id
				{
					SharedComponents.Data.dsProjectsLevels.GEN_ProjectsHierarchyRow row = (SharedComponents.Data.dsProjectsLevels.GEN_ProjectsHierarchyRow) dsProjectsLevels1.GEN_ProjectsHierarchy.FindByProjectElementID( int.Parse( gridItem.Cells[ 6 ].Text ) );
					if ( row != null )
						((Label) gridItem.Cells[ 4 ].Controls[ 1 ]).Text = row.ProjectElementName;
				}
				
				if (gridItem.Cells[ 3 ].Text != "&nbsp;")
				{
				gridItem.CssClass = "completetask";
				((CheckBox) gridItem.Cells[0].Controls[1]).Visible = false;
				} 
			
			}
		}

		#endregion
		
		#region Load One Project From List
		
		
		private void ReLoadProject()
		{
			pnlNewProject.Visible = true ;
			pnlProjectList.Visible = false ;
            btnNew.Visible = false;
            btnDelete.Visible = false;
            rblActiveProjects.Visible = false;
			txtProjectName.Text = Session["ProjectName"].ToString();
			ViewState["ProjectName"] = Session["ProjectName"];
			BaseObject.SafeMerge(dsEmployee1,(DataSet) Session[ "CacheEmp" ]);
			drpEmployeesList.DataBind();
			drpManagerList.DataBind();

			if ( Session["ProjectManager"].ToString() != "-1" )
				drpManagerList.SelectedValue =  Session["ProjectManager"].ToString();

			txtDeliverDate.Text = Session["sDeliverDate"].ToString() ;
			txtCriticalDate.Text= Session["sCriticalDate"].ToString() ;
			ViewState["ProjectID"] = Session["ProjectID"] ;
			//>>
			BinddgProjectTasks();
			//>>
//			dsEmployee1.Clear();
//			BaseObject.SafeMerge(dsEmployee1,(DataSet)Session[ "CacheAssignedEmp"]);

			dsEmployee1.Clear();
			BaseObject.SafeMerge(dsEmployee1,((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.ListProjectEmployees((int)Session["ProjectID"]));
			//>>
			dsEmployee AssigndcachEmp = new dsEmployee();
			BaseObject.SafeMerge(AssigndcachEmp,dsEmployee1);
			Session[ "CacheAssignedEmp"] = AssigndcachEmp;

			dgAssignedEmp.DataBind();
			ShowGrids();
		    Session["BackToProjectTask"] = null ;
		    Session["SaveMode"] = 1 ;

			
			
		}

		# region bind dgProjectTasks
        
		private void BinddgProjectTasks()
		{
			dsTasks1.Clear();
			BaseObject.SafeMerge(dsTasks1,((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewTaskByProject((int)Session["ProjectID"]));
			dgProjectTasks.DataBind();
		    setTaskStatus();
		} 
		
		#endregion
		public  string FormatDate(string date)
		{
			string strFormatedDate = date.Substring(0,10);
			if(strFormatedDate[8]==' ')
				return strFormatedDate.Substring(0,strFormatedDate.Length-2);
			else
				return strFormatedDate;
		}
		
		protected void LoadProjectByID(object sender , System.EventArgs e )
		{
			ClearText();
			// get project details 
			DataGridItem itm = (DataGridItem) ((LinkButton) sender).Parent.Parent;
			int pagno = dgProjectList.CurrentPageIndex; ;
			int pagsize = dgProjectList.PageSize;
			int itmID = itm.ItemIndex + (pagno*pagsize) ;
            Session["itmID"] = itmID ; 
			txtProjectName.Text = dsProjects1.GEN_Projects[itmID].ProjectName.ToString() ;
			Session["ProjectName"] = txtProjectName.Text;
			//drpManagerList.DataBind();
			if ( !dsProjects1.GEN_Projects[itmID].IsProjectManagerNull() )
				drpManagerList.SelectedValue = dsProjects1.GEN_Projects[itmID].ProjectManager.ToString() ;
			Session["ProjectManager"] = drpManagerList.SelectedValue ;
			if ( !dsProjects1.GEN_Projects[itmID].IsProjectTargetDateNull() )
				txtDeliverDate.Text= FormatDate(dsProjects1.GEN_Projects[itmID].ProjectTargetDate.ToString());
			Session["sDeliverDate"] = txtDeliverDate.Text;
			if ( !dsProjects1.GEN_Projects[itmID].IsProjectCriticalDateNull() )
				txtCriticalDate.Text= FormatDate(dsProjects1.GEN_Projects[itmID].ProjectCriticalDate.ToString()) ;
			Session["sCriticalDate"] = txtCriticalDate.Text;
			int ProjectID = dsProjects1.GEN_Projects[itmID].projectID ;
			((Navigation.BaseObject) Session[ "navigation" ]).EntityID = ProjectID;
			ViewState["ProjectID"] = ProjectID ;
			Session["ProjectID"] = ProjectID ;

			// get project tasks
			BaseObject.SafeMerge(dsTasks1,((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewTaskByProject(ProjectID));
			dgProjectTasks.DataBind();
			setTaskStatus();
		
//			// get project employees
			dsEmployee1.Clear();
			BaseObject.SafeMerge(dsEmployee1,((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.ListProjectEmployees(ProjectID));
			//****************
			Session[ "CacheAssignedEmp" ] = dsEmployee1;
			//****************
			dgAssignedEmp.DataBind();
			ShowGrids();
		    //****************
			Session["SaveMode"] = 1 ;
			//
		    ShowButtons();

            CheckButtonVisibilty();	 
            checkButtons(this.Page.Controls[1].Controls[1].Controls[0]);					
		
			((BaseObject)Session[ "Navigation" ]).Operation = BaseObject.OperationType.UPADATE; 

			if( ! dsProjects1.GEN_Projects[itmID].IsProjectStatusNull() && dsProjects1.GEN_Projects[itmID].ProjectStatus == 0 )
			{
				Session[ "isPrjComp" ] = true;
				LoadCompleteProjectsManagerDropDownList();
			}
			else
			{
				Session[ "isPrjComp" ] = false;
				LoadProjectsManagerDropDownList();
			}
			if ( !dsProjects1.GEN_Projects[itmID].IsProjectManagerNull() )
			{
				drpManagerList.SelectedValue = dsProjects1.GEN_Projects[itmID].ProjectManager.ToString() ;
			}
			checkUpdateAndNewProjectButtons( );

//			// disibale managers dropdown list if the user is not admin
//			if (  !((Navigation.BaseObject)Page.Session[ "navigation" ]).SecInfo.IsAdministrator )
//			{
//				drpManagerList.Enabled = false;
//				IMG2.Visible = false;
//			}

            // added by Sayed 21/07/2009
            CheckButtonVisibilty();
			
		}

		#endregion	
		
		#region Delete and Adds New Project
		
		protected void btnDelete_Click(object sender, ImageClickEventArgs e)
		{
            tblErr.Visible = false;
			int rowCount =  dgProjectList.Items.Count ;
			int pagsize = dgProjectList.PageSize;
			int rowCountds = dsProjects1.GEN_Projects.Count;
			int flag = 0;
            dsProjects1.AcceptChanges();
			for ( int i = rowCount -1   ; i >= 0 ;  i-- )
			{
				CheckBox ch = (CheckBox) dgProjectList.Items[ i ].Cells[ 0 ].Controls[ 1 ];
				if ( ch.Checked  ) 
				{
					int pagno  = dgProjectList.CurrentPageIndex;
                    this.dsProjects1.Tables[0].Rows[i + (pagno * pagsize)].Delete();
                    //dsProjects1.GEN_Projects.Rows[i].Delete();
				    rowCountds = rowCountds - 1; 
				    flag = 1;
				}
			     
			}
            if (flag == 1)
            {
                int DelReturn = ((Navigation.BaseObject)Session["navigation"]).ProjectWSObject.DeleteProjects(dsProjects1);
                if (DelReturn <= 0)
                    tblErr.Visible = true;
            }
            else
            {
                Response.Write("<script>alert(' You must select project first')</script>");
                return;
                // you must select record first
            }
			
			dsProjects1.Clear();
			LoadProjects();
		
		}

		
		protected void btnNew_Click(object sender, ImageClickEventArgs e)
		{
			//HideButtons();
			Session["SaveMode"] = 0 ;
			ClearText();
			pnlNewProject.Visible       = true ;
			pnlProjectList.Visible      = false ;
            btnNew.Visible = false;
            btnDelete.Visible = false;
            rblActiveProjects.Visible = false;
            btnNew.Visible = false;
            btnDelete.Visible = false;
            rblActiveProjects.Visible = false;
			ButtonAddProject.Visible    = true;
			ButtonUpdateProject.Visible = false;
			btnCompleteProject.Visible  = false;
			pnlTasks.Visible = false;
			pnlEmp.Visible = false;
		    LoadProjectsManagerDropDownList();
			
			IMG1.Visible   = false;
			((BaseObject)Session[ "Navigation" ]).Operation = BaseObject.OperationType.ADD ; 
			checkUpdateAndNewProjectButtons();
		}

		#endregion
		
		#region btnCancel_Click

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Session["BackToProjectTask"] = null;
			HideButtons();
			pnlProjectList.Visible = true ;
            btnNew.Visible = true;
            btnDelete.Visible = true;
            rblActiveProjects.Visible = true;
			pnlNewProject.Visible  = false ;
			pnlEmp.Visible = false;
			pnlTasks.Visible = false;
			tblErr.Visible = false;
			((Navigation.BaseObject) Session[ "navigation" ]).EntityID = -1;
		}

		#endregion 

		#region HideButtons

		private void HideButtons()
		{
			pnlEmp.Visible = false;
			pnlProjectList.Visible = false;
            btnNew.Visible = false;
            btnDelete.Visible = false;
            rblActiveProjects.Visible = false;
			pnlTasks.Visible = false;
			pnlNewProject.Visible = true;

		}
		
		#endregion 
		
		#region ShowButtons
		private void ShowButtons()
		{
			
			
			pnlEmp.Visible = true;
			pnlProjectList.Visible = false;
            btnNew.Visible = false;
            btnDelete.Visible = false;
            rblActiveProjects.Visible = false;
			pnlTasks.Visible = true;
			pnlNewProject.Visible = true;
			
		}
		
		#endregion 
		
		#region btnSaveProject_Click
		private void btnSaveProject_Click(object sender, System.EventArgs e)
		{
			IFormatProvider culture = new CultureInfo("en-US",true);
			dsProjects1.EnforceConstraints = false;
		
			if ((int)Session["SaveMode"] == 0 )
			{
				dsProjects.GEN_ProjectsRow row =  dsProjects1.GEN_Projects.NewGEN_ProjectsRow();
				// Build Row
				row.ProjectName = txtProjectName.Text;
				row.ProjectManager = Convert.ToInt32(drpManagerList.SelectedValue) ;
				row.ProjectTargetDate = DateTime.Parse(txtDeliverDate.Text,culture);
				row.ProjectCriticalDate = DateTime.Parse(txtCriticalDate.Text,culture);
				// Adds Row in dataset	
				dsProjects1.GEN_Projects.AddGEN_ProjectsRow(row);
				((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.AddProject(dsProjects1);
				pnlProjectList.Visible = true ;
                btnNew.Visible = true;
                btnDelete.Visible = true;
                rblActiveProjects.Visible = true;
				pnlNewProject.Visible = false ;
			}
			else if ((int)Session["SaveMode"] == 1)
			{
				int editIndex = (int)Session["itmID"];
				dsProjects.GEN_ProjectsRow row =  dsProjects1.GEN_Projects[editIndex];
				// Update Row
				row.ProjectName = txtProjectName.Text;
				row.ProjectManager = Convert.ToInt32(drpManagerList.SelectedValue) ;
				row.ProjectTargetDate = DateTime.Parse(txtDeliverDate.Text,culture);
				row.ProjectCriticalDate = DateTime.Parse(txtCriticalDate.Text,culture);
				// Edits Row in dataset	
				((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.EditProjects(dsProjects1);
			
			}
			//Reload dataset and Return To The Project list
			dsProjects1.Clear();
			LoadProjects();
		
		}
		
		#endregion 
		
		#region LoadProjectsManagerDropDownList
		private void LoadProjectsManagerDropDownList()
		
		{
		    BaseObject.SafeMerge(dsEmployee1,((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListActiveEmployees());
			

//			dataView1.Sort="Fullname";
//			foreach(DataRow dr in dataView1.Table.Rows)
//			{
//				Response.Write(dr["Fullname"].ToString()+"</br>");
//			}
//
//			drpManagerList.DataSource = dsEmployee1;
//			drpEmployeesList.DataSource=dsEmployee1;
			drpManagerList.Items.Clear();
			drpEmployeesList.Items.Clear();



			dsEmployee cachEmp = new dsEmployee();
			BaseObject.SafeMerge(cachEmp,dsEmployee1);
			Session[ "CacheEmp" ] = cachEmp;
			
			drpManagerList.DataBind();
			ListItem TempItem = new ListItem();
			TempItem.Text = "";
			TempItem.Value = "-1";
			drpManagerList.Items.Insert(0,TempItem);

			drpEmployeesList.DataBind();

		}

		//If project is closed
		private void LoadCompleteProjectsManagerDropDownList()
		
		{
			BaseObject.SafeMerge(dsEmployee1,((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListEmployees());
			

			DataView dv = dataView1;


			dsEmployee cachEmp = new dsEmployee();
			BaseObject.SafeMerge(cachEmp,dsEmployee1);
			Session[ "CacheEmp" ] = cachEmp;
			
			drpManagerList.DataBind();
			ListItem TempItem = new ListItem();
			TempItem.Text = "";
			TempItem.Value = "-1";
			drpManagerList.Items.Insert(0,TempItem);

			drpEmployeesList.DataBind();

		}

		#endregion 
	
		#region lnkbtnNewTask_Click
		private void lnkbtnNewTask_Click(object sender, System.EventArgs e)
		{
			CTask task = new CTask((int)Session["ProjectID"],Session["ProjectName"].ToString()); 
			Session["task"] = task;
			Response.Redirect("../Go/NewTask.aspx");
			
		}
		
		#endregion 
	
		#region ChangeBackColor
		protected void ChangeBackColor(object sender , System.EventArgs e )
		{
			
			DataGridItem itm = (DataGridItem) ((CheckBox) sender).Parent.Parent;
			CheckBox ch = (CheckBox) sender;

			if (ch.Checked)
			{
				itm.BackColor = Color.LightGreen ;
			}
			else
			{
				itm.BackColor = Color.White ;
			}
 		
		}
		
		#endregion 
		
		#region ShowGrids
		private void ShowGrids()
		{
			dgProjectTasks.Visible = true;
			dgAssignedEmp.Visible = true;
		}

		#endregion 
		 
		#region ClearText
		private void ClearText()
		{
			txtProjectName.Text="";
			txtDeliverDate.Text="";
			txtCriticalDate.Text="";
		}
         
		#endregion 
	
		#region dgProjectList_PageIndexChanged
		private void dgProjectList_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.dgProjectList.CurrentPageIndex=e.NewPageIndex;
			LoadProjects();
		}

		#endregion 
		
		#region btnAddEmp_Click
		protected void btnAddEmp_Click(object sender, System.EventArgs e)
		{
            lblmsgAssaign.Text = "";
			if( drpEmployeesList.SelectedValue != "" )
			{
				int empIndex = Convert.ToInt32(drpEmployeesList.SelectedValue );
                BaseObject.SafeMerge(dsEmployee1, ((Navigation.BaseObject)Session["navigation"]).ProjectWSObject.ListProjectEmployees((int)ViewState["ProjectID"]));
                DataRow[] dr = dsEmployee1.Tables[0].Select("ContactID=" + empIndex);
               //dv.RowFilter = "ContactID=" + empIndex;
              // dsEmployee1.Dispose();
               if (dr.Length == 0)
               {

                   ((Navigation.BaseObject)Session["navigation"]).ProjectWSObject.AddEmployeeToProject((int)ViewState["ProjectID"], empIndex);
                   dsEmployee1.Clear();
                   BaseObject.SafeMerge(dsEmployee1, ((Navigation.BaseObject)Session["navigation"]).ProjectWSObject.ListProjectEmployees((int)ViewState["ProjectID"]));
                   Session["CacheAssignedEmp"] = dsEmployee1;
                   dgAssignedEmp.DataBind();
                   lblmsgAssaign.Text = "";
               }
               else
               {
                   lblmsgAssaign.Text = "the selected employee already assigned to this project";

               }
			}
			
		}

		#endregion 
		
		#region btnDeleteTask_Click
		protected void btnDeleteTask_Click(object sender, System.EventArgs e)
		{           
			BaseObject.SafeMerge(dsTasks1,((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewTaskByProject((int)Session["ProjectID"]));
			int rowCount =  dgProjectTasks.Items.Count ;
			bool TaskSelected = false;

			for ( int i = rowCount -1   ; i >= 0 ;  i-- )
			{
				CheckBox ch = (CheckBox) dgProjectTasks.Items[ i ].Cells[ 5 ].Controls[ 1 ];
				if ( ch.Checked  ) 
				{
				 this.dsTasks1.Tables[0].Rows[i].Delete();
					TaskSelected = true;
				}
			}
			if(dgProjectTasks.Items.Count==0 || !TaskSelected)
			{
				Response.Write("<script>alert('Select a task to delete')</script>");
				return;
			}
			int TaskDeleted = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.DeleteTask(dsTasks1);
			if(TaskDeleted == -1)
			{
				Response.Write("<script>alert('Task can not be deleted!')</script>");	
				return;
			}
			//>>
			BinddgProjectTasks();

			//>>		
		}

		#endregion 

		#region btnRemoveEmp_Click
		protected void btnRemoveEmp_Click(object sender, System.EventArgs e)
		{
			BaseObject.SafeMerge(dsEmployee1,((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.ListProjectEmployees((int)Session["ProjectID"]));
			int rowCount =  dgAssignedEmp.Items.Count ;
			for ( int i = rowCount -1   ; i >= 0 ;  i-- )
			{
				CheckBox ch = (CheckBox) dgAssignedEmp.Items[ i ].Cells[ 3 ].Controls[ 1 ];
				if ( ch.Checked  ) 
				{
					((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.RemoveEmployeeFromProject( (int)Session["ProjectID"] , int.Parse( dgAssignedEmp.Items[ i ].Cells[ 4 ].Text ) );
				}
			}
			dsEmployee1.Clear();
			BaseObject.SafeMerge(dsEmployee1,((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.ListProjectEmployees((int)Session["ProjectID"]));
			//>>
			dsEmployee AssigndcachEmp = new dsEmployee();
			BaseObject.SafeMerge(AssigndcachEmp,dsEmployee1);
			Session[ "CacheAssignedEmp"] = AssigndcachEmp;
			//>>
			dgAssignedEmp.DataBind();
		
		}

		#endregion 
		
		#region btnEditTask_Click
		protected void btnEditTask_Click(object sender, System.EventArgs e)
		{
			int rowCount =  dgProjectTasks.Items.Count ;
			int flag = 0 ;
			bool TaskSelected = false;
			
			if(CheckedRows() > 1)
			{
				Navigation.BaseObject.showMessage("Please select just one task",this.Page);
				return;
			}
			else
			{
				for ( int i = rowCount -1  ; i >= 0;  i-- )
				{
					CheckBox ch = (CheckBox) dgProjectTasks.Items[i].Cells[5].Controls[1];
					if ( ch.Checked ) 
					{
						TaskSelected = true;
						CTask task = new CTask((int)Session["ProjectID"],Session["ProjectName"].ToString(),Convert.ToInt32(dgProjectTasks.Items[i].Cells[0].Text));
						Session["task"] = task ;
						Response.Redirect("../Go/NewTask.aspx");
					}
				}
				if (flag == 0 || !TaskSelected)
					Response.Write("<script>alert('Select a Task To Edit')</script>");
			}
		
		}

		#endregion 
		
		#region btnCompleteProject_Click
		protected void btnCompleteProject_Click(object sender, System.EventArgs e)
		{
            //int ret = ((Navigation.BaseObject)Session["navigation"]).ProjectWSObject.CompleteProjectFromPDMS("111.111.111 Project");
            //return;
            //////int ret = ((Navigation.BaseObject)Session["navigation"]).TaskWSObject.CompleteTaskInProjFromPDMS("111.111.111 Project","h");
            //////return;
            //////111.111.111 Project 
	     	dsProjects1.Clear();
			BaseObject.SafeMerge(dsProjects1,((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.ListProject((int)Session["ProjectID"]));
			if(	((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.CompleteProject(dsProjects1) == 1 )
				Navigation.BaseObject.showMessage( "Project has been completed successfully" , this.Page );

//			//Disable page controls to prevent editing project details,project tasks and project employees	
			Navigation.BaseObject.SafeMerge( dsProjectsLevels1 , ((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.ListAllProjectsLevels() );
			dsProjects1.Clear();
			LoadProjects();
			btnCancel_Click(null, null);
		}

		#endregion 
		
		#region btnNewTask_Click
		protected void btnNewTask_Click(object sender, System.EventArgs e)
		{
			CTask task = new CTask((int)Session["ProjectID"],Session["ProjectName"].ToString()); 
			Session["task"] = task;
			Response.Redirect("../Go/NewTask.aspx");

		}

		#endregion 
		
		#region btnCompleteTask_Click
		protected void btnCompleteTask_Click(object sender, System.EventArgs e)
		{
			
			int rowCount =  dgProjectTasks.Items.Count ;
			bool TaskSelected = false;

		
			for ( int i = rowCount -1  ; i >= 0;  i-- )
			{
				CheckBox ch = (CheckBox) dgProjectTasks.Items[i].Cells[5].Controls[1];
				if ( ch.Checked ) 
				{
					TaskSelected = true;
					((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.CompleteTask(Convert.ToInt32(dgProjectTasks.Items[i].Cells[0].Text));
				}
			}
			if(dgProjectTasks.Items.Count==0 || !TaskSelected)
			{
				Response.Write("<script>alert('Select a task to complete')</script>");	
			}

			//>>
			BinddgProjectTasks();
			//>>			
		}
		
		#endregion 
		
		#region btnAssignTaskToEmp_Click
		
		protected void btnAssignTaskToEmp_Click(object sender, System.EventArgs e)
		{
			int rowCount =  dgAssignedEmp.Items.Count ;
			int ConstJobtitleID = 0;
			int flag = 0;
			//>>> if selected employees have the same job titles or just selected one employee
			for ( int i = rowCount -1  ; i >= 0;  i-- )
			{
				CheckBox ch = (CheckBox) dgAssignedEmp.Items[i].Cells[3].Controls[1];
				if ( ch.Checked )
				{ 
					if (ConstJobtitleID == 0)
					ConstJobtitleID = Convert.ToInt32(dgAssignedEmp.Items[i].Cells[5].Text);
					
					int CurrentJobtitleID =  Convert.ToInt32(dgAssignedEmp.Items[i].Cells[5].Text);
					if (ConstJobtitleID - CurrentJobtitleID != 0)
					{
						Response.Write("<script>alert('Selected Employees Does not have the same Job title to Manage')</script>");
						ClearChkBoxHeader();
						return;
					}
					else
					{
					flag = 1; 
					}
				
				}
			}
			
			if (flag == 1)
			{
			
							DataSet Tempds = new DataSet();
							DataTable dt = new DataTable();
							DataColumn EmpName = new DataColumn("Name");
							DataColumn EmpID = new DataColumn("ID");
							dt.Columns.Add(EmpName);
							dt.Columns.Add(EmpID);
							for ( int i = rowCount -1  ; i >= 0;  i-- )
							{
								CheckBox ch = (CheckBox) dgAssignedEmp.Items[i].Cells[3].Controls[1];
								if ( ch.Checked )
								{ 
									dr = dt.NewRow();
									dr["Name"] = dgAssignedEmp.Items[i].Cells[1].Text;
									dr["ID"] = dgAssignedEmp.Items[i].Cells[4].Text;
									dt.Rows.Add(dr);
									//>> bug here
									//if ((string)Session["EmpID"] == null)
                                    Session["EmpID"] = dgAssignedEmp.Items[i].Cells[4].Text;
								}
							}
							Tempds.Tables.Add(dt);
							Session["TempDs"] = Tempds;
							((Navigation.BaseObject) Session[ "navigation" ]).EntityID = ((Navigation.BaseObject) Session[ "navigation" ]).EntityID ;
							Response.Redirect("../Go/CopyofAssignTaskToEmployee.aspx");
			}
		}

	
		
		#endregion 

		#region btnManageEmpTasks_Click
		private void btnManageEmpTasks_Click(object sender, System.EventArgs e)
		{
			int rowCount =  dgAssignedEmp.Items.Count ;
			for ( int i = rowCount -1  ; i >= 0;  i-- )
			{
				CheckBox ch = (CheckBox) dgAssignedEmp.Items[i].Cells[3].Controls[1];
				if ( ch.Checked ) 
				{
					Session["EmpName"] = dgAssignedEmp.Items[i].Cells[1].Text;
					Session["EmpID"] = dgAssignedEmp.Items[i].Cells[4].Text;
					Response.Redirect("../Go/ManageEmployeeTask.aspx");
				}	
			}
		}

		#endregion 

		#region ChangeTaskBackColor
		protected void ChangeTaskBackColor(object sender , System.EventArgs e )
		{
			DataGridItem itm = (DataGridItem) ((CheckBox) sender).Parent.Parent;
			if ( itm.Cells[ 3 ].Text == "0" )
			{
				((CheckBox) itm.Cells[5].Controls[1]).Checked = false;
				BaseObject.showMessage( "Can not select a completed task" , this.Page );
				return;
			}

			CheckBox ch = (CheckBox) sender;

			if (ch.Checked)
				itm.BackColor = Color.LightGreen ;
			else
				itm.BackColor = Color.White ;
			
		}

		#endregion 

		#region setTaskStatus 
		void setTaskStatus ()
		{
			for( int i = 0 ; i < dgProjectTasks.Items.Count ; i++ )
			{
				DataGridItem item = dgProjectTasks.Items[ i ];
				if ( item.Cells[ 3 ].Text == "0" )
				{
					item.Cells[ 4 ].Text = "Completed";
					item.CssClass = "completetask";
				   ((CheckBox) item.Cells[5].Controls[1]).Visible = false;
				}
				else
				{
					item.Cells[ 4 ].Text = "Opened";
				}
			}
		}
		
		#endregion 

		#region ButtonAddProject_Click
		
		public bool CheckProjectsByName(TSN.ERP.SharedComponents.Data.dsProjects ds,string ProjectName)
		{
			bool flag = true ;
			foreach(DataRow dr in ds.Tables["GEN_Projects"].Rows)
			{
				flag = true;
				if(dr["ProjectName"].ToString().ToLower()== ProjectName.ToLower() )
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
		public bool CheckProjectsByNameAndID(TSN.ERP.SharedComponents.Data.dsProjects ds,string ProjectName,int ProjectID)
		{
			bool flag = true ;
			foreach(DataRow dr in ds.Tables["GEN_Projects"].Rows)
			{
				flag = true;
				if(dr["ProjectName"].ToString().ToLower() == ProjectName.ToLower() && int.Parse(dr["projectID"].ToString())!=ProjectID)
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

		protected void ButtonAddProject_Click(object sender, System.EventArgs e)
        {           
            #region Validation
            if (txtProjectName.Text.Trim() == "")
            {
                Navigation.BaseObject.showMessage("Please enter Project Name", this.Page);
                return;
            }
            if (drpManagerList.SelectedValue == "-1")
            {
                Navigation.BaseObject.showMessage("Please select Project Manager", this.Page);
                return;
            }
            if (txtDeliverDate.Text == "")
            {
                Navigation.BaseObject.showMessage("Please select Delivery Date", this.Page);
                return;
            }
            if (txtCriticalDate.Text == "")
            {
                Navigation.BaseObject.showMessage("Please select Critical Date", this.Page);
                return;
            }
            #endregion
            IFormatProvider culture = new CultureInfo("en-US",true);

            dsProjects1.Clear();
            BaseObject.SafeMerge(dsProjects1, ((Navigation.BaseObject)Session["navigation"]).ProjectWSObject.ListUserProjects());
            dsProjects1.AcceptChanges();
                //dsProjects.GEN_ProjectsRow row =  dsProjects1.GEN_Projects.NewGEN_ProjectsRow();
            DataRow row = dsProjects1.Tables[0].NewRow();
				// Build Row				
				row["ProjectName"] = txtProjectName.Text.Trim();
                if (drpManagerList.SelectedValue != "-1")
                    row["ProjectManager"] = Convert.ToInt32(drpManagerList.SelectedValue);
                else
                    //row.SetProjectManagerNull();
                    row["ProjectManager"] = DBNull.Value;


				if ( txtDeliverDate.Text != "" )
					row["ProjectTargetDate"]   = DateTime.Parse(txtDeliverDate.Text,culture);
				if ( txtCriticalDate.Text != "" )
					row["ProjectCriticalDate"] = DateTime.Parse(txtCriticalDate.Text,culture);
				// Adds Row in dataset	
				bool Flage = CheckProjectsByName(dsProjects1,txtProjectName.Text.Trim());
					if(Flage)
					{
                        //row.projectID = 146;
                        //row.ProjectOwner = 325;
                        try
                        {
                            //row.AcceptChanges();
                            //row.SetAdded();
                            //dsProjects1.GEN_Projects.AddGEN_ProjectsRow(row);
                            dsProjects1.Tables[0].Rows.Add(row);
                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex.Message);
                        }
						((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.AddProject(dsProjects1);
						pnlProjectList.Visible = true ;
                        btnNew.Visible = true;
                        btnDelete.Visible = true;
                        rblActiveProjects.Visible = true;
						pnlNewProject.Visible = false ;

						dsProjects1.Clear();
						tblErr.Visible = false;
						LoadProjects();
					}
					else
					{
						lblMSG.Visible = true;
						lblMSG.Text = "This Project Name already exists ,please try another name";
					}
		}

		#endregion 

		#region ButtonUpdateProject_Click
		protected void ButtonUpdateProject_Click(object sender, System.EventArgs e)
		{
				IFormatProvider culture = new CultureInfo("en-US",true);
				dsProjects1.EnforceConstraints = false;
				if (txtProjectName.Text.Trim() == "" )
				{
					Navigation.BaseObject.showMessage( "Please enter Project Name" , this.Page );
					return;
				}
				if (drpManagerList.SelectedValue == "-1")
				{
					Navigation.BaseObject.showMessage( "Please select Project Manager" , this.Page );
					return;
				}
				if (txtDeliverDate.Text == "" )
				{
					Navigation.BaseObject.showMessage( "Please select Delivery Date" , this.Page );
					return;
				}
				if (txtCriticalDate.Text == "" )
				{
					Navigation.BaseObject.showMessage( "Please select Critical Date" , this.Page );
					return;
				}

				int editIndex = (int)Session["itmID"];
				int SelectedProjectID =int.Parse( dsProjects1.GEN_Projects[editIndex]["ProjectID"].ToString());
				bool Flage = CheckProjectsByNameAndID(dsProjects1,txtProjectName.Text.Trim(),SelectedProjectID);

                dsProjects1.AcceptChanges();
				dsProjects.GEN_ProjectsRow row =  dsProjects1.GEN_Projects[editIndex];
			if(Flage)
			{
				// Update Row
				row.ProjectName = txtProjectName.Text;
				if ( drpManagerList.SelectedValue != "-1" )
					row.ProjectManager = Convert.ToInt32(drpManagerList.SelectedValue) ;
				else
					row.SetProjectManagerNull();
				if ( txtDeliverDate.Text != "" )
					row.ProjectTargetDate   = DateTime.Parse(txtDeliverDate.Text,culture);
				if ( txtCriticalDate.Text != "" )
					row.ProjectCriticalDate = DateTime.Parse(txtCriticalDate.Text,culture);
				//row.ProjectTargetDate = DateTime.Parse(txtDeliverDate.Text,culture);
				//row.ProjectCriticalDate = DateTime.Parse(txtCriticalDate.Text,culture);
				// Edits Row in dataset	                
				int retValue = ((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.EditProjects(dsProjects1);

				dsProjects1.Clear();
				LoadProjects();
			}
			else
			{
				lblMSG.Text ="This Project Name already exist, please try another name";
			}
		}

		#endregion 

		#region CheckButtonVisibilty
		
		void CheckButtonVisibilty()
		{
			ArrayList arrRules = new ArrayList();
			bool visibililty = true;

			// check add project buttons
			//arrRules.Add( 1005 );
//			arrRules.Add( 5001 );
//			visibililty = Navigation.BaseObject.CheckUserAccessRule( arrRules );
//			btnNew.Visible			  = visibililty;
//			ButtonAddProject .Visible = visibililty;

			// check edit project buttons
			visibililty = true;
			arrRules.Clear();

			arrRules.Add( 1004 );
			visibililty = ((Navigation.BaseObject) Session[ "navigation" ]).CheckUserAccessRule( arrRules );
			ButtonUpdateProject.Visible	= visibililty;

			// check edit task buttons
			visibililty = true;
			arrRules.Clear();

			arrRules.Add( 1027 );
			arrRules.Add( 5080 );
			visibililty = ((Navigation.BaseObject) Session[ "navigation" ]).CheckUserAccessRule( arrRules );
			SecButtonsEditTsk.Visible	= visibililty;

			// check delete task buttons
			visibililty = true;
			arrRules.Clear();

			arrRules.Add( 1028 );
			arrRules.Add( 5081 );
			visibililty = ((Navigation.BaseObject) Session[ "navigation" ]).CheckUserAccessRule( arrRules );
			SecButtonsDeleteTsk.Visible	= visibililty;

			// check complete task button
			visibililty = true;
			arrRules.Clear();

			arrRules.Add( 1030 );
			arrRules.Add( 5086 );
			visibililty = ((Navigation.BaseObject) Session[ "navigation" ]).CheckUserAccessRule( arrRules );
			ButtonCmpTsk.Visible	= visibililty;

		}
		#endregion 

		#region checkButtons
		void checkButtons( System.Web.UI.Control ctr )
		{
			try
			{
				int index = 0 ;
				bool  visibility = false ;

				while( ctr.Controls.Count != 0 && index < ctr.Controls.Count )
				{                    
					if ( ctr.Controls[ index ].GetType().ToString() == "TSN.ERP.WebGUI.Navigation.SecButtons" )
					{
                        if (((TSN.ERP.WebGUI.Navigation.SecButtons)ctr.Controls[index]).ID.Trim() == "ButtonCmpTsk")
                        {
                            string Batata = "Abo 7alawa ya looz";
                        }



						if (  ((Navigation.BaseObject) Session[ "navigation" ]).SecInfo.IsAdministrator )
						{
							visibility = true;
							((TSN.ERP.WebGUI.Navigation.SecButtons)ctr.Controls[ index ]).Visible = visibility;
						}

						if ( ((TSN.ERP.WebGUI.Navigation.SecButtons)ctr.Controls[ index ]).RuleID != 0 )
						{
                            DataTable dt = new DataTable();
                            dt.Columns.Add("First");
                            dt.Columns.Add("Second");
                            for (int i = 0; i < ((Navigation.BaseObject)Session["navigation"]).SecInfo.RulesArray.Count; i++)
                            {
                                int[] elm = new int[2];
                                elm = (int[])((Navigation.BaseObject)Session["navigation"]).SecInfo.RulesArray[i];
                                DataRow dr = dt.NewRow();
                                dr[0] = elm[0];
                                dr[1] = elm[1];
                                dt.Rows.Add(dr);
                            }
							for( int i = 0 ; i < ((Navigation.BaseObject) Session[ "navigation" ]).SecInfo.RulesArray.Count ; i++ )
							{
								int[] elm = new int[2];
								elm = (int[]) ((Navigation.BaseObject) Session[ "navigation" ]).SecInfo.RulesArray[ i ];
								if( elm[ 0 ] == ((TSN.ERP.WebGUI.Navigation.SecButtons)ctr.Controls[ index ]).RuleID )
								{
									if ( elm[ 1 ] == -1 )
									{
										visibility = true;
									
									}
									else if( elm[ 1 ] ==  ((Navigation.BaseObject) Session[ "navigation" ]).EntityID )
									{
										visibility = true;
									
									}

								}
							}
							((TSN.ERP.WebGUI.Navigation.SecButtons)ctr.Controls[ index ]).Visible = visibility;
						}
						visibility = false ;
					}
					checkButtons( ctr.Controls[ index ] );
					index +=1;
				}
				
			}
			catch( Exception ee )
			{

			}
		}

		#endregion 

		#region checkUpdateAndNewProjectButtons

		void checkUpdateAndNewProjectButtons( )
		{
			if ( ((BaseObject)Session[ "Navigation" ]).Operation == BaseObject.OperationType.ADD && !ButtonAddProject.Visible )
			{
				ButtonAddProject.Visible	= true;
				ButtonUpdateProject.Visible = false;
				btnCompleteProject.Visible  = false;
			}
			else if ( ((BaseObject)Session[ "Navigation" ]).Operation == BaseObject.OperationType.UPADATE )
			{
				ButtonAddProject.Visible	= false;
		
				//if the project is completed
				if ( (bool)Session[ "isPrjComp" ] )
				{
					btnCompleteProject.Visible  = false;
					ButtonUpdateProject.Visible = false;
					ButtonCmpTsk.Visible		= false;
					SecButtonsNewTsk.Visible	= false;
					SecButtonsEditTsk.Visible   = false;
					SecButtonsDeleteTsk.Visible = false;
					SecButtAddEmpToPrj.Visible  = false;
					btnRemoveEmp.Visible		= false ;
					btnAssignTaskToEmp.Visible  = false;
				}
			}
		}
		#endregion
		public int CheckedRows()
		{
			int count = 0 ;
			int rowCount =  dgProjectTasks.Items.Count ;
			for ( int i = rowCount -1  ; i >= 0;  i-- )
			{
				CheckBox ch = (CheckBox) dgProjectTasks.Items[i].Cells[5].Controls[1];
				if ( ch.Checked ) 
				{
					count++;				
				}
			}
			return count;

		}

		protected void dgAssignedEmp_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                BaseObject.SafeMerge(dsJobtitles1, ((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobtitles());
                foreach (DataRow dr in dsJobtitles1.Tables[0].Rows)
                {
                    if (e.Item.Cells[5].Text == dr["JobTitleID"].ToString())
                    {
                        e.Item.Cells[2].Text = dr["JobName"].ToString();
                    }
                }
                if (e.Item.Cells[6].Text == "0")
                {
                    ((CheckBox)e.Item.Cells[3].Controls[1]).Visible = false;
                    e.Item.CssClass = "completetask";
                }
            }
		}
        protected void rblActiveProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProjects();
        }
        protected void dgProjectTasks_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
          
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)

            {
                e.Item.Cells[0].Visible = false;
            }
            else if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[0].Visible = false;
            }
        }
}
}