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
	public partial class ElementsDetails : System.Web.UI.UserControl
	{
		#region Controls Definitions 

		dbTreeView tvElementsList=new dbTreeView();
		protected TSN.ERP.SharedComponents.Data.dsCompanyElements dsCompanyElements;
		protected TSN.ERP.SharedComponents.Data.dsCompanyElementLevels dsCompanyElementLevels;
		protected System.Data.DataView dvLevelName;
		string elementLevelName;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Data.DataView dvChildElement;
		protected TSN.ERP.SharedComponents.Data.dsJobtitles dsJobtitles;
		protected System.Web.UI.HtmlControls.HtmlGenericControl parent;
		protected System.Web.UI.HtmlControls.HtmlGenericControl ParentMenue;
		//protected System.Web.UI.WebControls.Button Button4;
		protected TSN.ERP.SharedComponents.Data.dsEmployee dsEmployee1;
		protected System.Data.DataView dvJobTitles;
		MasterMethods master = new MasterMethods();

		#endregion 
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
                //tvElementsList.BackColor = Color.White;
                //tvElementsList.ForeColor = Color.Magenta;
				PlaceHolder1.Controls.Add(tvElementsList);
                Microsoft.Web.UI.WebControls.CssCollection css = new Microsoft.Web.UI.WebControls.CssCollection();
                css.CssText = "color:#000000";
                tvElementsList.DefaultStyle = css;
				if(!Page.IsPostBack)
				{
					// get employees for managers
					ShowErrorTable = false;
					dsEmployee1.Clear();
					
					if ( Navigation.BaseObject.SafeMerge( dsEmployee1 , ((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListActiveEmployees() ) )
					{
						//Sort Employees DataSet//////////////////////////////////
						DataView dvEmp = dsEmployee1.GEN_Employees.DefaultView;
						dvEmp.Sort = "FirstName, MiddleName, LastName";
						dsEmployee1.Tables.Clear();
						dsEmployee1.Tables.Add(master.CreateTableFromView(dvEmp));
						//////////////////////////////////////////////////////////

						dlpManager.DataBind();
						ListItem TempItem = new ListItem();
						TempItem.Text = "---- Select Item -----";
						TempItem.Value = "-1";
						dlpManager.Items.Insert(0,TempItem);
					}

					// fill company levels
					ShowErrorTable = false;
			
					if ( Navigation.BaseObject.SafeMerge( dsCompanyElementLevels , ((Navigation.BaseObject) Session[ "navigation" ]).CompanyWsObject.ListCompanyElementLevels() ) )
					{
						DropDownListLevel.DataSource = dsCompanyElementLevels ;
						DropDownListLevel.DataBind();
						ListItem TempItem = new ListItem();
						TempItem.Text = "---- Select Level -----";
						TempItem.Value = "-1";
						DropDownListLevel.Items.Insert(0,TempItem);
					
					}

					// fill company elements tree & menue
					GetElementsData();
					dvChildElement.Sort = "CEName";
					this.tvElementsList.bind(this.dsCompanyElements);
					
					FilterChildElements();
					Session["dsCompanyElements"]=this.dsCompanyElements;
					

//					//Sort Company Elements DataSet//////////////////////////////////
//					DataView dvCE = dsCompanyElements.GEN_CompanyElments.DefaultView;
//					dvCE.Sort = "CEName";
//					dsCompanyElements.Tables.Clear();
//					dsCompanyElements.Tables.Add(master.CreateTableFromView(dvCE));
//					//////////////////////////////////////////////////////////
//					///

					DropDownListAllCompElm.DataBind();
					ListItem Itm = new ListItem();
					Itm.Text = "---- Select Parent -----";
					Itm.Value = "-1";
					DropDownListAllCompElm.Items.Insert(0,Itm);

					// fill jobtiles menue
					TSN.ERP.SharedComponents.Data.dsJobtitles jbTitle = new TSN.ERP.SharedComponents.Data.dsJobtitles();

					//jbTitle.Merge( BaseObject.JobTiltesWsObject.ListJobtitles() );
					if ( Navigation.BaseObject.SafeMerge( jbTitle , ((Navigation.BaseObject) Session[ "navigation" ]).JobTiltesWsObject.ListActiveJobtitles() ))
					{
						//Sort Job Titles DataSet//////////////////////////////////
						DataView dvJT = jbTitle.GEN_JobTitles.DefaultView;
						dvJT.Sort = "JobName";
						jbTitle.Tables.Clear();
						jbTitle.Tables.Add(master.CreateTableFromView(dvJT));
						//////////////////////////////////////////////////////////
						///
						DropDownListJobTitles.DataSource = jbTitle;
						DropDownListJobTitles.DataBind();
						Session["AllJB"] = jbTitle;
						dsJobtitles.Clear();
						GetJobTitles();
					}
				} 
				if (ShowErrorTable)
					tblErr.Visible = true;
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
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
			this.dsCompanyElements = new TSN.ERP.SharedComponents.Data.dsCompanyElements();
			this.dsCompanyElementLevels = new TSN.ERP.SharedComponents.Data.dsCompanyElementLevels();
			this.dvLevelName = new System.Data.DataView();
			this.dvChildElement = new System.Data.DataView();
			this.dsJobtitles = new TSN.ERP.SharedComponents.Data.dsJobtitles();
			this.dvJobTitles = new System.Data.DataView();
			this.dsEmployee1 = new TSN.ERP.SharedComponents.Data.dsEmployee();
			((System.ComponentModel.ISupportInitialize)(this.dsCompanyElements)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCompanyElementLevels)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvLevelName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvChildElement)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsJobtitles)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvJobTitles)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsEmployee1)).BeginInit();
			// 
			// dsCompanyElements
			// 
			this.dsCompanyElements.DataSetName = "dsCompanyElements";
			this.dsCompanyElements.EnforceConstraints = false;
			this.dsCompanyElements.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// dsCompanyElementLevels
			// 
			this.dsCompanyElementLevels.DataSetName = "dsCompanyElementLevels";
			this.dsCompanyElementLevels.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// dvLevelName
			// 
			this.dvLevelName.Table = this.dsCompanyElementLevels.GEN_CompanyElmentLevels;
			// 
			// dvChildElement
			// 
			this.dvChildElement.Table = this.dsCompanyElements.GEN_CompanyElments;
			// 
			// dsJobtitles
			// 
			this.dsJobtitles.DataSetName = "dsJobtitles";
			this.dsJobtitles.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// dvJobTitles
			// 
			this.dvJobTitles.Sort = "JobName";
			this.dvJobTitles.Table = this.dsJobtitles.GEN_JobTitles;
			// 
			// dsEmployee1
			// 
			this.dsEmployee1.DataSetName = "dsEmployee";
			this.dsEmployee1.Locale = new System.Globalization.CultureInfo("ar-EG");
			((System.ComponentModel.ISupportInitialize)(this.dsCompanyElements)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCompanyElementLevels)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvLevelName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvChildElement)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsJobtitles)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvJobTitles)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsEmployee1)).EndInit();

		}
		#endregion

		#region Functions

		#region GetElementDetails
		public bool IsContactIDExist(TSN.ERP.SharedComponents.Data.dsEmployee ds,int ContactID)
		{
			bool flag = false ;
			foreach(DataRow dr in ds.Tables["GEN_Employees"].Rows)
			{
				flag = false;
				if(dr["ContactID"]!= System.DBNull.Value)
				{

					if(int.Parse(dr["ContactID"].ToString().Trim())== ContactID)
					{
						flag = true;
						break;
					}				
					else
					{
						flag = false;
					}
				}
			}
			return flag;
		}
		/// <summary>
		/// To get selected element details and bind them to textboxes
		/// </summary>

		void GetElementDetails(int elementID)
		{
			TSN.ERP.SharedComponents.Data.dsCompanyElements.GEN_CompanyElmentsRow rowParentElement=(TSN.ERP.SharedComponents.Data.dsCompanyElements.GEN_CompanyElmentsRow)dsCompanyElements.GEN_CompanyElments.Rows[elementID];
			this.txtElementName.Text = rowParentElement.CEName;
			Label1.Text = rowParentElement.CEName;
			Label2.Text = rowParentElement.CEName;
			ButtonUpdateComElm.Visible = true;
			ButtonAddComElm.Visible    = false;
			TSN.ERP.SharedComponents.Data.dsEmployee ds = new TSN.ERP.SharedComponents.Data.dsEmployee();
			bool Flage = false;
			if(Navigation.BaseObject.SafeMerge( ds, ((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListActiveEmployees() ))
			if (rowParentElement.IsContactIDNull())
				DropDownListLevel.SelectedValue ="-1";
			else	
			Flage = IsContactIDExist(ds,rowParentElement.ContactID);
				
			if(Flage)
			{
				if (!rowParentElement.IsContactIDNull())
				{
					dlpManager.SelectedValue = rowParentElement.ContactID.ToString();
				}
			}
			else
			{
				dlpManager.SelectedValue ="-1";
			}
			if (!rowParentElement.IsCEL_IDNull())
				DropDownListLevel.SelectedValue = rowParentElement.CEL_ID.ToString();
			else
				DropDownListLevel.SelectedValue ="-1";

			if (!rowParentElement.IsCEParentNull())
				DropDownListAllCompElm.SelectedValue = rowParentElement.CEParent.ToString();
			else
				DropDownListAllCompElm.SelectedIndex = -1;

			if (!rowParentElement.IsCEDescriptionNull())
			{	
				this.txtElementDescription.Text=rowParentElement.CEDescription;
			}
			else
			{
				this.txtElementDescription.Text="";
			}

			GetJobTitles(); 
		}


		#endregion 

		#region UpdateElementsDetails

		/// <summary>
		/// To update selected element details
		/// </summary>
		/// <param name="elementID"></param>
		void UpdateElementsDetails(int elementID)
		{
			try
			{
				
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
			}
		}
		

		#endregion 

		#region GetLevelName

		/// <summary>
		/// To get the element name of selected element from elements 'TreeView'
		/// </summary>
		/// <param name="elementLevelID"></param>
		/// <returns></returns>
		private string GetLevelName(int elementLevelID)
		{
			string elementLevelName ="";
			int rowcount = dvLevelName.Table.Rows.Count;
			for (int i =0; i < rowcount ; i++)
			{
				if ((int)dvLevelName.Table.Rows[i]["CEL_ID"]==elementLevelID)
				{
					elementLevelName=(string)this.dvLevelName.Table.Rows[i]["CELName"];
					break;
				}
			}
			return  elementLevelName;
		}
		

		#endregion 

		#region GetElementsData

		private void GetElementsData()
		{
			dsCompanyElements.Clear();
			//dsCompanyElements.Merge( BaseObject.CompanyWsObject.ListCompnayElements());
			Navigation.BaseObject.SafeMerge( dsCompanyElements , ((BaseObject) Session[ "navigation" ]).CompanyWsObject.ListCompnayElements() );
			if (dsCompanyElements.GEN_CompanyElments.Rows.Count > 0)
			{
				dvChildElement.Table  = dsCompanyElements.GEN_CompanyElments;

//				//Sort Company Elements DataSet//////////////////////////////////
//				DataView dvCE = dsCompanyElements.GEN_CompanyElments.DefaultView;
//				dvCE.Sort = "CEName";
//				dsCompanyElements.Tables.Clear();
//				dsCompanyElements.Tables.Add(master.CreateTableFromView(dvCE));
//				//////////////////////////////////////////////////////////
			}
			
			
		}


		#endregion 

		#region GetJobTitles
		/// <summary>
		/// Get list of assigned job titles for selected element from elements 'TreeView'
		/// </summary>
		/// <param name="CompanyElementID"></param>
		private void GetJobTitles()
		{
			if(tvElementsList.Nodes.Count <= 0)
				return;
			int elementID = tvElementsList.getSelectedNode().CompElmentId;
			dsJobtitles.Clear();
			dsJobtitles.Merge( ((Navigation.BaseObject) Session[ "navigation" ]).JobTiltesWsObject.ListJobtitlesbyCompnayElment( elementID ));
			dvJobTitles.Table = dsJobtitles.GEN_JobTitles;
			dgJobTitles.DataBind();
			Session[ "JT" ] =  dsJobtitles;
		}


		#endregion 

		#region GetLevelsData

		private void GetLevelsData()
		{
			this.dsCompanyElementLevels.Clear();
			this.dsCompanyElementLevels.Merge( ((BaseObject) Session[ "navigation" ]).CompanyWsObject.ListCompanyElementLevels());
		}


		#endregion 

		#region FilterChildElements

		/// <summary>
		/// Retrive child elements for selected parent element from 'TreeView'
		/// </summary>
		private void FilterChildElements()
		{
			if(tvElementsList.Nodes.Count <= 0)
				return;

			((Navigation.BaseObject) Session[ "navigation" ]).EntityID = this.tvElementsList.getSelectedNode().CompElmentId;
			int parentElementID    = this.tvElementsList.getSelectedNode().CompElmentId;
			int parentElementIndex = this.tvElementsList.getSelectedNode().DSIndex;
			this.dvChildElement.RowFilter="CEParent='"+parentElementID+"'";
			GetElementDetails(parentElementIndex);
		}


		#endregion 
		
		#region DeleteElement
		
		/// <summary>
		/// Delete selected element (if possible)
		/// </summary>
		/// <param name="elementID"></param>
		void DeleteElement(int elementIndex )
		{
			try
			{
				dsCompanyElements=(TSN.ERP.SharedComponents.Data.dsCompanyElements)Session["dsCompanyElements"];
				FilterChildElements();
				this.dvChildElement.Table=dsCompanyElements.GEN_CompanyElments;
				TSN.ERP.SharedComponents.Data.dsCompanyElements.GEN_CompanyElmentsRow rowElement=(TSN.ERP.SharedComponents.Data.dsCompanyElements.GEN_CompanyElmentsRow)dsCompanyElements.GEN_CompanyElments.Rows[elementIndex];
				rowElement.Delete();
				int deleteresult = ((Navigation.BaseObject) Session[ "navigation" ]).CompanyWsObject.DeleteCompanyElements(dsCompanyElements);
				if (deleteresult<=0)
				{
					ShowErrorTable = true;
					tblErr.Visible = true;
					dsCompanyElements.RejectChanges();
				}
				else
				{
					DataSet tempds = ((Navigation.BaseObject) Session[ "navigation" ]).CompanyWsObject.ListCompnayElements();
					dsCompanyElements.Clear();
					if(tempds != null)dsCompanyElements.Merge(tempds);
					tvElementsList.bind(this.dsCompanyElements);
					Session["dsCompanyElements"]=dsCompanyElements;

					// refresh data
					txtElementName.Text			= "" ;
					txtElementDescription.Text	= "" ;
					dlpManager.SelectedIndex    = 0 ;
					DropDownListLevel.SelectedIndex    = 0 ;
					DropDownListAllCompElm.DataBind();
					ListItem Itm = new ListItem();
					Itm.Text = "---- Select Parent -----";
					Itm.Value = "-1";
					DropDownListAllCompElm.Items.Insert(0,Itm);
					DropDownListAllCompElm.SelectedIndex = 0 ;
					Label1.Text = "";
				}
			}
			catch(Exception ex)
			{
				Response.Write(ex.Message);
			}
		}


		#endregion 

	
		#endregion 

		#region Controls Events
		
	
		#region btnSelectNode_Click

		protected void btnSelectNode_Click( object sender, System.EventArgs e )
		{
			if(tvElementsList.Nodes.Count <= 0)
			{
				return;
				
			}
			else
			{
				try
				{
					dsCompanyElements = ( TSN.ERP.SharedComponents.Data.dsCompanyElements)Session["dsCompanyElements"];
					this.dvChildElement.Table = dsCompanyElements.GEN_CompanyElments;
					FilterChildElements();
					TSN.ERP.SharedComponents.Data.dsCompanyElements.GEN_CompanyElmentsRow r = dsCompanyElements.GEN_CompanyElments[this.tvElementsList.getSelectedNode().DSIndex];

					if ( ! r.IsCEL_IDNull() )
						elementLevelName   = this.GetLevelName(r.CEL_ID);

					GetJobTitles();
					((Navigation.BaseObject) Session[ "navigation" ]).Operation = BaseObject.OperationType.UPADATE;

					ArrayList rule = new ArrayList();
					rule.Add( 5032 );
					ButtonUpdateComElm.Visible = ((Navigation.BaseObject) Session[ "navigation" ]).CheckUserAccessRule( rule );
					TABLE7.Visible = true;
					ShowErrorTable = false;
					tblErr.Visible = false;
				 
				}
				catch(Exception ex)
				{
					Response.Write(ex.ToString());
				}
			}
		}

		#endregion 
		
		#region btnDelete_Click

		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			if(tvElementsList.Nodes.Count > 0)
			{
				if (tvElementsList.GetNodeFromIndex(tvElementsList.SelectedNodeIndex).Nodes.Count == 0 )
				{
					int elementID = this.tvElementsList.getSelectedNode().DSIndex;
					DeleteElement( elementID );
					Button4_Click(null,new System.EventArgs());

				}
				else
				{
					BaseObject.showMessage( "You have to delete the children elements or move them to another element before deleting this element ", this.Page );
				}
			}
		}


		#endregion 

		#region Button4_Click

		protected void Button4_Click(object sender, System.EventArgs e)
		{
			((Navigation.BaseObject) Session[ "navigation" ]).Operation = BaseObject.OperationType.ADD;
			dlpManager.SelectedIndex    = 0 ;
			DropDownListLevel.SelectedIndex    = 0 ;
			DropDownListAllCompElm.SelectedIndex = 0;
			txtElementName.Text			= "" ;
			txtElementDescription.Text	= "" ;
			ButtonAddComElm.Visible		= true;
			ButtonUpdateComElm.Visible  = false;
			Label1.Text ="";
			// HIDE JOB TITLES DATA GRID	
			dsJobtitles.Clear();
			dvJobTitles.Table.Clear();
			dgJobTitles.DataBind();
			TABLE7.Visible = false;
			
		}


		#endregion 

		#region ButtonRemoveJobTitle_Click

		protected void ButtonRemoveJobTitle_Click(object sender, System.EventArgs e)
		{
			dsJobtitles    = (TSN.ERP.SharedComponents.Data.dsJobtitles ) Session[ "JT" ];
			int elementID  = tvElementsList.getSelectedNode().CompElmentId;
            bool isChecked = false;

			for ( int i = 0 ; i < dgJobTitles.Items.Count ; i++ )
			{
                if (((CheckBox)dgJobTitles.Items[i].Cells[2].Controls[1]).Checked)
                {
                    isChecked = true;
                    ((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.RemoveJobsFromCompanyElement(dsJobtitles.GEN_JobTitles[i].JobTitleID, elementID);
                }
				
			}
            
			
			GetJobTitles( );
            if(isChecked==false)
                Navigation.BaseObject.showMessage("Please Select Item to Remove it.", this.Page);

		}


		#endregion 

		#region AddJobTileToComElm_Click

		protected void AddJobTileToComElm_Click(object sender, System.EventArgs e)
		{
		
			dsJobtitles    = (TSN.ERP.SharedComponents.Data.dsJobtitles ) Session[ "JT" ];	
			TSN.ERP.SharedComponents.Data.dsJobtitles.GEN_JobTitlesRow row = ((TSN.ERP.SharedComponents.Data.dsJobtitles)Session["AllJB"]).GEN_JobTitles.FindByJobTitleID( Convert.ToInt32( DropDownListJobTitles.SelectedValue ));

            if (dsJobtitles.GEN_JobTitles.FindByJobTitleID(row.JobTitleID) == null)
            {
                TSN.ERP.SharedComponents.Data.dsJobXCoElements ds = new TSN.ERP.SharedComponents.Data.dsJobXCoElements();
                TSN.ERP.SharedComponents.Data.dsJobXCoElements.GEN_JobTitlesXCoElmentsRow rowJC = ds.GEN_JobTitlesXCoElments.NewGEN_JobTitlesXCoElmentsRow();
                rowJC.JobTitleID = row.JobTitleID;
                rowJC.CompElmentID = tvElementsList.getSelectedNode().CompElmentId;
                ds.GEN_JobTitlesXCoElments.AddGEN_JobTitlesXCoElmentsRow(rowJC);
                ((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.AddJobsToCompanyElement(ds);
                GetJobTitles();
            }
            else
            {
                Navigation.BaseObject.showMessage("This item already added.", this.Page);
                return;
            }
		}


		#endregion 

		#region ButtonAddComElm_Click
		public bool IsElementExist(TSN.ERP.SharedComponents.Data.dsCompanyElements ds,string ElementName)
		{
			bool Flage = false;
			foreach(DataRow dr in ds.Tables[0].Rows)
			{
						if(dr[4].ToString().ToLower()==ElementName.ToLower())
						{
							Flage = true;
							break;
						}
						else
						{
							Flage = false;
						}
		//				}
		//			}
		//			else if(type=='D')
		//			{
		//				if(dr[3]== System.DBNull.Value && dr[4].ToString().ToLower()== ElementName.ToLower())
		//				{
		//					Flage = true;
		//					break;
		//				}
		//				else
		//				{
		//					Flage = false;
		//				}
		//			}
			}
			return Flage;
		}
		protected void ButtonAddComElm_Click(object sender, System.EventArgs e)
		{
			if(Page.IsValid)
			{
				if ( ((Navigation.BaseObject) Session[ "navigation" ]).Operation == BaseObject.OperationType.ADD )
				{
					int parentID ;	
					//bool elementflage = false;
					bool departmentflage = false;
//					dsCompanyElements    = (TSN.ERP.SharedComponents.Data.dsCompanyElements)Session["dsCompanyElements"];
//					GetElementsData();

					dsCompanyElements.Clear();
					Navigation.BaseObject.SafeMerge( dsCompanyElements , ((BaseObject) Session[ "navigation" ]).CompanyWsObject.ListCompnayElements() );
					TSN.ERP.SharedComponents.Data.dsCompanyElements.GEN_CompanyElmentsRow row = dsCompanyElements.GEN_CompanyElments.NewGEN_CompanyElmentsRow();
					//Row Columns
					//row.CompElmentID;
					//row.CEL_ID;
					//row.CompID;
					//row.CEParent;
					//row.CEName;
					//row.CEDescription;
					//row.ContactID;
					row.CEName			= txtElementName.Text;
					row.CEDescription   = txtElementDescription.Text;
					/////////////////////////////////////////////////
					parentID = int.Parse(DropDownListAllCompElm.SelectedValue);
					//elementflage = IsElementExist(dsCompanyElements,txtElementName.Text.Trim(),parentID,'E');
					departmentflage = IsElementExist(dsCompanyElements,txtElementName.Text.Trim());
					////////////////////////////////////////////////
					if (dlpManager.SelectedIndex > 0)
						row.ContactID = int.Parse(dlpManager.SelectedValue);
					if (DropDownListLevel.SelectedIndex > 0)
						row.CEL_ID = int.Parse(DropDownListLevel.SelectedValue);
					if(txtElementName.Text.ToLower().Trim()== DropDownListAllCompElm.Items[DropDownListAllCompElm.SelectedIndex].ToString().ToLower().Trim())
					{
						BaseObject.showMessage("Please select different department name" ,this.Page);
						return;
					}
					
					
					/*if(elementflage == true && DropDownListAllCompElm.SelectedIndex > 0)
					{
						BaseObject.showMessage("This element already exists, please try another name" ,this.Page);
						Button4_Click(null,new System.EventArgs());
						return;
					}*/
					if(departmentflage == true)
					{
						BaseObject.showMessage("This department already exists, please try another name" ,this.Page);
						Button4_Click(null,new System.EventArgs());
						return;
					
					}



					try
					{												
						dsCompanyElements.GEN_CompanyElments.AddGEN_CompanyElmentsRow( row );
					}
					catch(Exception ex)
					{
						Response.Write(ex.Message);
					}



					if (DropDownListAllCompElm.SelectedIndex > 0)
					{
						if(DropDownListLevel.SelectedIndex != 0)
						{
							((Navigation.BaseObject) Session[ "navigation" ]).CompanyWsObject.AddChildCompanyElements(Convert.ToInt32( DropDownListAllCompElm.SelectedValue) , dsCompanyElements );
							Button4_Click(null,new System.EventArgs());
						}
						else
						{
							BaseObject.showMessage( "Please select the company element level "  , this.Page );
							dsCompanyElements.GEN_CompanyElments.RejectChanges();
							return;
					
						}
					}					
					else
					{
						if ( DropDownListLevel.SelectedIndex != 0 )
						{
							((Navigation.BaseObject) Session[ "navigation" ]).CompanyWsObject.AddCompanyElements(dsCompanyElements);
							Button4_Click(null,new System.EventArgs());
							tvElementsList.SelectedNodeIndex = "" ;
						}
						else
						{
							BaseObject.showMessage( "Please select the company element level "  , this.Page );
							dsCompanyElements.GEN_CompanyElments.RejectChanges();							
							return;
						}

					}
					dsCompanyElements.AcceptChanges();
					Session["dsCompanyElements"] = dsCompanyElements;
					txtElementName.Text			= "" ;
					txtElementDescription.Text	= "" ;
					dlpManager.SelectedIndex    = 0 ;
					DropDownListLevel.SelectedIndex    = 0 ;
				
				}
				//Refresh data
				GetElementsData();

//				//Sort Company Elements DataSet//////////////////////////////////
//				DataView dvCE = dsCompanyElements.GEN_CompanyElments.DefaultView;
//				dvCE.Sort = "CEName";
//				dsCompanyElements.Tables.Clear();
//				dsCompanyElements.Tables.Add(master.CreateTableFromView(dvCE));
//				//////////////////////////////////////////////////////////
//				///
				this.tvElementsList.bind(this.dsCompanyElements);
				dsCompanyElements.AcceptChanges();
				
				DropDownListAllCompElm.DataBind();
				ListItem Itm = new ListItem();
				Itm.Text = "---- Select Parent -----";
				Itm.Value = "-1";
				DropDownListAllCompElm.Items.Insert(0,Itm);
				DropDownListAllCompElm.SelectedIndex = 0 ;
			}
		}


		#endregion 

		#region ButtonUpdateComElm_Click
		public bool IsElementExistForUpdate(TSN.ERP.SharedComponents.Data.dsCompanyElements ds,string ElementName,int ElementID)
		{
			bool Flage = false;
			foreach(DataRow dr in ds.Tables[0].Rows)
			{
					if(dr[4].ToString().ToLower()==ElementName.ToLower() && int.Parse(dr[0].ToString())!=ElementID)
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

		protected void ButtonUpdateComElm_Click(object sender, System.EventArgs e)
		{
			if(Page.IsValid)
			{
				if ( txtElementName.Text.Trim() != ""  )
				{
					if ( ((Navigation.BaseObject) Session[ "navigation" ]).Operation == BaseObject.OperationType.UPADATE )
					{
						//bool elementflage = false;
						bool departmentflage = false;
						int elementIndex        = tvElementsList.getSelectedNode().DSIndex;
						dsCompanyElements       = (TSN.ERP.SharedComponents.Data.dsCompanyElements)Session["dsCompanyElements"];
						dvChildElement.Table    = dsCompanyElements.GEN_CompanyElments;
						TSN.ERP.SharedComponents.Data.dsCompanyElements.GEN_CompanyElmentsRow rowParentElement = (TSN.ERP.SharedComponents.Data.dsCompanyElements.GEN_CompanyElmentsRow)dsCompanyElements.GEN_CompanyElments.Rows[elementIndex];
						//////////////////////////////////////////////////////////////////
						int ElementID = int.Parse(rowParentElement["CompElmentID"].ToString());
						int ParentID = int.Parse(DropDownListAllCompElm.SelectedValue);
						//elementflage = IsElementExistForUpdate(dsCompanyElements,txtElementName.Text.Trim(),ParentID,ElementID,'E');
						departmentflage = IsElementExistForUpdate(dsCompanyElements,txtElementName.Text.Trim(),ElementID);
						/*if(elementflage == true && DropDownListAllCompElm.SelectedIndex > 0)
						{
							BaseObject.showMessage("This element already exist, please try another name" ,this.Page);
							Button4_Click(null,new System.EventArgs());
							return;
						}*/
						if(departmentflage == true )
						{
							BaseObject.showMessage("This department already exist, please try another name" ,this.Page);
							Button4_Click(null,new System.EventArgs());
							return;
					
						}

						/////////////////////////////////////////////////////////////////
						rowParentElement.CEName = txtElementName.Text;
						rowParentElement.CEDescription = txtElementDescription.Text;
						if (dlpManager.SelectedIndex > 0)
							rowParentElement.ContactID = int.Parse(dlpManager.SelectedValue);
						if (DropDownListLevel.SelectedIndex > 0)
							rowParentElement.CEL_ID = int.Parse(DropDownListLevel.SelectedValue);
						if ( int.Parse( DropDownListAllCompElm.SelectedValue ) !=  rowParentElement.CompElmentID )
						{
							if( int.Parse(DropDownListAllCompElm.SelectedValue) != -1 )
							{
								TSN.ERP.SharedComponents.Data.dsCompanyElements.GEN_CompanyElmentsRow ParentElement = (TSN.ERP.SharedComponents.Data.dsCompanyElements.GEN_CompanyElmentsRow)dsCompanyElements.GEN_CompanyElments.FindByCompElmentID(int.Parse(DropDownListAllCompElm.SelectedValue));
								int parentEID = 0;
								try
								{
									parentEID = Convert.ToInt32(ParentElement.CEParent.ToString());
								}
								catch
								{
								}
								if(parentEID != 0)
								{
									if(ParentElement.CEParent == rowParentElement.CompElmentID)
									{
										ParentElement.SetCEParentNull();
										rowParentElement.CEParent = ParentElement.CompElmentID;
									}
									else
									{
										rowParentElement.CEParent = int.Parse(DropDownListAllCompElm.SelectedValue);
									}
								}
								else
								{
									rowParentElement.CEParent = int.Parse(DropDownListAllCompElm.SelectedValue);
								}
							}
							else
							{
								rowParentElement.SetCEParentNull();// =  System.Convert.DBNull;
								//CEParent
							}
						}
						if(txtElementName.Text.Trim()== DropDownListAllCompElm.Items[DropDownListAllCompElm.SelectedIndex].ToString().Trim())
						{
							BaseObject.showMessage("Please select different department name" ,this.Page);
							return;
						}

						((Navigation.BaseObject) Session[ "navigation" ]).CompanyWsObject.ModifyCompanyElemenets( dsCompanyElements );
						dsCompanyElements.AcceptChanges();
						Session["dsCompanyElements"] = dsCompanyElements;
						Button4_Click(null,new System.EventArgs());
						tvElementsList.SelectedNodeIndex = null;


					}
					//Refresh data
					GetElementsData();
					this.tvElementsList.bind(this.dsCompanyElements);
					dsCompanyElements.AcceptChanges();
					//DropDownListAllCompElm.DataBind();
				}
				//			else
				//				BaseObject.showMessage( "Please insert the element name"  , this.Page );
			}
		}
	

		#endregion 

		protected void txtElementName_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		#endregion 

		protected void dgJobTitles_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		

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
	}
}
