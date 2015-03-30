namespace TSN.ERP.WebGUI.Go
{
	using System;
	using System.Collections;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.IO;
	using System.Text.RegularExpressions;

	/// <summary>
	///	This Form used to query, add, modify and activete/terminate employees.
	/// </summary>
	public partial class EmployeeMainSearch : System.Web.UI.UserControl
	{
	
		#region Class members
		private static string filter ;
		protected TSN.ERP.SharedComponents.Data.dsCompanyElements dsCompElements;
		protected TSN.ERP.SharedComponents.Data.dsJobtitles dsJobTitles;
		protected System.Web.UI.WebControls.HyperLink lnkAddress1;
		protected TSN.ERP.SharedComponents.Data.dsContacts dsContacts;
		protected System.Data.DataView dataView1;
		protected TSN.ERP.SharedComponents.Data.dsEmployee dsEmployee;

		public  static DataTable dtCountry = new DataTable();
		public  static DataTable dtState = new DataTable();
		public  static DataTable dtCity = new DataTable();
		protected TSN.ERP.WebGUI.Navigation.SecButtons btnWeeklySheet;
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.WebControls.Label Label1;
		protected TSN.ERP.WebGUI.Data.UsrDS usrDS1;
		protected System.Data.DataSet dsUnassignedUsers;
		protected System.Web.UI.WebControls.Label Label5;
		protected TSN.ERP.SharedComponents.Data.dsFilesInfo dsFilesInfo;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected TSN.ERP.SharedComponents.Data.dsCity dsCity;
		protected TSN.ERP.SharedComponents.Data.dsCountry dsCountry;
		protected TSN.ERP.SharedComponents.Data.dsState dsState;
		protected TSN.ERP.WebGUI.Data.DataSetUser dsUser;
		protected TSN.ERP.SharedComponents.Data.dsAddress dsAddress;
		protected TSN.ERP.SharedComponents.Data.dsPhonebook dsPhonebook;
		protected System.Web.UI.WebControls.ImageButton ImageButton1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;

        MasterMethods master = new MasterMethods();
		
		
				protected string SortField;
		#endregion
		//------------------------------------------------------------------
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			
			InitializeComponent();
			base.OnInit(e);
		}
		
	
		private void InitializeComponent()
		{
			this.dsCompElements = new TSN.ERP.SharedComponents.Data.dsCompanyElements();
			this.dsJobTitles = new TSN.ERP.SharedComponents.Data.dsJobtitles();
			this.dsContacts = new TSN.ERP.SharedComponents.Data.dsContacts();
			this.dataView1 = new System.Data.DataView();
			this.dsEmployee = new TSN.ERP.SharedComponents.Data.dsEmployee();
			this.usrDS1 = new TSN.ERP.WebGUI.Data.UsrDS();
			this.dsUser = new TSN.ERP.WebGUI.Data.DataSetUser();
			this.dsUnassignedUsers = new System.Data.DataSet();
			this.dsFilesInfo = new TSN.ERP.SharedComponents.Data.dsFilesInfo();
			this.dsCity = new TSN.ERP.SharedComponents.Data.dsCity();
			this.dsCountry = new TSN.ERP.SharedComponents.Data.dsCountry();
			this.dsState = new TSN.ERP.SharedComponents.Data.dsState();
			this.dsAddress = new TSN.ERP.SharedComponents.Data.dsAddress();
			this.dsPhonebook = new TSN.ERP.SharedComponents.Data.dsPhonebook();
			((System.ComponentModel.ISupportInitialize)(this.dsCompElements)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsJobTitles)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsContacts)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsEmployee)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.usrDS1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUser)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUnassignedUsers)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsFilesInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCountry)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsState)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsAddress)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsPhonebook)).BeginInit();
			this.grdEmployees.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grdEmployees_ItemDataBound);
			// 
			// dsCompElements
			// 
			this.dsCompElements.DataSetName = "dsCompanyElements";
			this.dsCompElements.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// dsJobTitles
			// 
			this.dsJobTitles.DataSetName = "dsJobtitles";
			this.dsJobTitles.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// dsContacts
			// 
			this.dsContacts.DataSetName = "dsContacts";
			this.dsContacts.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dataView1
			// 
			this.dataView1.Table = this.dsContacts.GEN_Contacts;
			// 
			// dsEmployee
			// 
			this.dsEmployee.DataSetName = "dsEmployee";
			this.dsEmployee.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// usrDS1
			// 
			this.usrDS1.DataSetName = "UsrDS";
			this.usrDS1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dsUser
			// 
			this.dsUser.DataSetName = "DataSetUser";
			this.dsUser.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dsUnassignedUsers
			// 
			this.dsUnassignedUsers.DataSetName = "NewDataSet";
			this.dsUnassignedUsers.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dsFilesInfo
			// 
			this.dsFilesInfo.DataSetName = "dsFilesInfo";
			this.dsFilesInfo.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// dsCity
			// 
			this.dsCity.DataSetName = "dsCity";
			this.dsCity.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dsCountry
			// 
			this.dsCountry.DataSetName = "dsCountry";
			this.dsCountry.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dsState
			// 
			this.dsState.DataSetName = "dsState";
			this.dsState.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dsAddress
			// 
			this.dsAddress.DataSetName = "dsAddress";
			this.dsAddress.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dsPhonebook
			// 
			this.dsPhonebook.DataSetName = "dsPhonebook";
			this.dsPhonebook.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.dsCompElements)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsJobTitles)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsContacts)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsEmployee)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.usrDS1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUser)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsUnassignedUsers)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsFilesInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCountry)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsState)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsAddress)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsPhonebook)).EndInit();

		}
		#endregion
		//------------------------------------------------------------------
		#region page load 
		protected void Page_Load(object sender, System.EventArgs e)
		{
            txtDate.Attributes.Add("readonly", "true");
            txtDate.Value = DateTime.Now.ToString("MM/dd/yyyy");
            
				lblRsltCount.Text ="";
				if ( !Page.IsPostBack  )
				{
					// bind countries, states and cities.
					Navigation.BaseObject.SafeMerge(dsCountry,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListAllCountries());
					dtCountry =dsCountry.Tables[0];
					Navigation.BaseObject.SafeMerge(dsState,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListAllStates());
					dtState = dsState.Tables[0];
					Navigation.BaseObject.SafeMerge(dsCity,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListAllCities());
					dtCity = dsCity.Tables[0];
					// Bind companay elements.
					bindCompanyElements();
					// Bind job titles.
					bindJobTitles();
					//Bind users' names
					BindUserNames();
					// bind unassigned user names
					BindUnassignedUserNames();
					// if this form is called from accontability webform
					showAddressPhone(false);
					// If this form is called as a pop-up window to search for a particular employee
					// Hide all buttons except find button.
					if (Request["type"] == "findemp")
					{
						btnUpdate.Visible = false;
						btnNew.Visible = false;
						btnTerminate.Visible = false;
					}
					// Get the last selcted employee in accountability form and view his/her data
                    if (System.Web.HttpContext.Current.Session["CurrentEmployee"] != null)
                    {
                        int empID = int.Parse(System.Web.HttpContext.Current.Session["CurrentEmployee"].ToString());
                     // the follwoing codes commented by moawad to fix bug of input string is not in accorect format
                    /*if (ViewState != null)
                    {
                        int empID = int.Parse(ViewState.ToString()); */

						Navigation.BaseObject.SafeMerge(dsEmployee,((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListSingleEmployeeData(empID));
						if (dsEmployee.Tables[0].Rows.Count > 0)
						{
							int cnt = 0;
							if( !((Navigation.BaseObject)Page.Session[ "navigation" ]).SecInfo.IsAdministrator )
								cnt = BindEmployee("EmpCode='" + dsEmployee.Tables[0].Rows[0]["EmpCode"].ToString() + "'");
							else 
								cnt = BindEmployee( "" );

							lblRsltCount.Text = "Total results found " + cnt;
							showAddressPhone(false);
							//System.Web.HttpContext.Current.Session["CurrentEmployee"] = null;
						}
					}

					
				}
		}
		#endregion
		//------------------------------------------------------------------
		#region on employee selected
		/// <summary>
		/// Load employee data on get selected
		/// </summary>
		/// <param name="sernder"></param>
		/// <param name="e"></param>
		public void OnSelect(object sernder, System.EventArgs e)
		{
			imgEmp.Src = "";
			lnkShowPhoto.Enabled = true;
			Session["selectedEmployee"] = grdEmployees.SelectedItem.Cells[1].Text;
			int contactID =int.Parse(grdEmployees.SelectedItem.Cells[1].Text); 
			ViewState["CurrentEmployee"] = contactID;
			string job,Department,userID;
			clearForm();
			resetColors();
			// load employee's information----------------------------------
			txtCode.Text =  (grdEmployees.SelectedItem.Cells[3].Text 
				== "&nbsp;" ? "" : grdEmployees.SelectedItem.Cells[3].Text);
			txtFName.Text = grdEmployees.SelectedItem.Cells[5].Text;
			txtMName.Text = grdEmployees.SelectedItem.Cells[6].Text == "&nbsp;" ? "" : grdEmployees.SelectedItem.Cells[6].Text ;
			txtLName.Text = grdEmployees.SelectedItem.Cells[7].Text;
			Session["contactID"] =  grdEmployees.SelectedItem.Cells[1].Text;
			Session["code"] = txtCode.Text ;
			Session["name"] = txtFName.Text + " " + txtMName.Text + " " + txtLName.Text  ;

			((Navigation.BaseObject) Session[ "navigation" ]).EntityID = contactID;

			try
			{
				// job and department and user ID---------------------------------------
				Navigation.BaseObject.SafeMerge(dsEmployee,((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListSingleEmployeeData(contactID));
				// save photo file id in a session
				Session["FileID"] = dsEmployee.Tables[0].Rows[0]["FileID"].ToString();
				job = dsEmployee.Tables[0].Rows[0]["JobTitleID"].ToString();
				userID = dsEmployee.Tables[0].Rows[0]["UserID"].ToString();
				Department = dsEmployee.Tables[0].Rows[0]["CompElmentID"].ToString();
				lstCompElements.SelectedIndex = lstCompElements.Items.IndexOf(lstCompElements.Items.FindByValue(Department));
				lstJobTitles.SelectedIndex = lstJobTitles.Items.IndexOf(lstJobTitles.Items.FindByValue(job)); 
				if (userID != "")
					lstUserName.SelectedIndex = lstUserName.Items.IndexOf(lstUserName.Items.FindByValue(userID)); 
				// Address--------------------------------------------------	
				// Join Address, City, State and country tables to get employee's address
				Navigation.BaseObject.SafeMerge(dsAddress, ((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.GetContactPrimaryAddress(contactID));
				DataTable dtAddress =dsAddress.Tables[0];
				DataTable dtJoin = DSHelper.Join(dtAddress,dtCity,"CityID","CityID");
				dtJoin = DSHelper.Join(dtJoin,dtState,"StateCode","StateCode");
				dtJoin = DSHelper.Join(dtJoin,dtCountry,"CountryID","CountryID");
				if ( dtJoin.Rows.Count >0)
				{
					txtCountry.Text = dtJoin.Rows[0]["CountryName"].ToString();
					txtState.Text = dtJoin.Rows[0]["StateName"].ToString();
					txtCity.Text = dtJoin.Rows[0]["CityName"].ToString();
					txtZIP.Text = dtJoin.Rows[0]["ZipCode"].ToString();
					txtAddress.Text = dtJoin.Rows[0]["AddressLine"].ToString();
				}
				//Phone---------------------------------------------------------
				Navigation.BaseObject.SafeMerge(dsPhonebook,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListPrimayContactPhones(contactID));
				if (dsPhonebook.Tables[0].Rows.Count>0)
					txtPhone.Text = dsPhonebook.Tables[0].Rows[0]["PhoneNumber"].ToString();
				
				btnNew.Visible = false;
				btnUpdate.Visible = true;
				btnTerminate.Enabled = true;
                //if (grdEmployees.SelectedItem.Cells[12].Text == "1")
                //    btnTerminate.Text = "Terminate";
                //else
                //    btnTerminate.Text = "Activate";
				showAddressPhone(true);
				//load emp photo
				if (pnlPhoto.Visible == true)
					loadEmpPhoto();	

				CheckButtonVisibilty();
			}
			catch(Exception ex)
			{
				lnkAddress.Visible = false ;
				lnkPhone.Visible = false;
				btnNew.Visible = false;
				Response.Write(ex.Message);
			}
		}
		#endregion
		//------------------------------------------------------------------
		#region bind company elements drop-down list.
		/// <summary>
		/// Bind all company's elements [departments and divisions] to its listbox
		/// </summary>
		public void bindCompanyElements()
		{
			try
			{
				Navigation.BaseObject.SafeMerge(dsCompElements,((Navigation.BaseObject) Session[ "navigation" ]).CompanyWsObject.ListCompnayElements());
				lstCompElements.DataBind();
				lstCompElements.Items.Insert(0,"Select One------------");
			}
			catch(Exception ex)
			{
				Response.Write("Faild to load company");
			}
		}
		#endregion
		//------------------------------------------------------------------
		#region bind Job Titles drop-down list.
		/// <summary>
		/// Bind all job titles to its listbox
		/// </summary>
		public void bindJobTitles()
		{
			try
			{
				Navigation.BaseObject.SafeMerge(dsJobTitles,((Navigation.BaseObject) Session[ "navigation" ]).JobTiltesWsObject.ListJobtitles());	
				lstJobTitles.DataBind();
				lstJobTitles.Items.Insert(0,"Select One------------");
			}
			catch(Exception ex)
			{
				Response.Write("Faild to load jobs");
			}
		}
		#endregion
		//------------------------------------------------------------------
		#region clear-form 
		/// <summary>
		/// Clear and reset form
		/// </summary>
		public void clearForm()
		{
			txtCode.Text = "";
			txtFName.Text = "";
			txtMName.Text = "";
			txtLName.Text = "";
			lstCompElements.SelectedIndex = 0;
			lstJobTitles.SelectedIndex =0;
			lstUserName.SelectedIndex = 0;
			txtCountry.Text = "";
			txtState.Text = "";
			txtCity.Text = "";
			txtZIP.Text = "";
			txtAddress.Text = "";
			txtPhone.Text = "";
			btnNew.Visible = true;
			lblRsltCount.Text = " ";
			btnUpdate.Visible = false;
			tblErr.Visible = false;
			
		}
		#endregion
		//------------------------------------------------------------------
		#region find employee
		/// <summary>
		/// Find all employees who match the selected criteria
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnFind_Click(object sender, System.EventArgs e)
		{
			
			lnkShowPhoto.Enabled = false;
			pnlPhoto.Visible = false;
			
			pnlWeeklySheet.Visible = false;
			try
			{
				int cnt;  // number of found employees
				//-------------------------------------------------------
				filter = "";
				btnTerminate.Enabled = false;
				lnkAddress.Visible =false;
				lnkPhone.Visible = false;
				grdEmployees.CurrentPageIndex = 0;
				//-------------------------------------------------------
				resetColors();  // reset controls back colors to white
				grdEmployees.SelectedIndex = -1;
				btnUpdate.Visible = false;
				// filter Code
				if (txtCode.Text != "" )
				{
					filter = "EmpCode='" + txtCode.Text.Trim() + "' and ";
				}
				//filter first name
				if (txtFName.Text != "")
				{
					filter = filter + "FirstName like '%" + txtFName.Text.Trim() + "%' and ";
				}
				//filter middle name
				if (txtMName.Text != "")
				{
					filter = filter + "MiddleName like '%" + txtMName.Text.Trim() + "%' and ";
				}
				// filter last name
				if (txtLName.Text != "")
				{
					filter = filter + "LastName like '%" + txtLName.Text.Trim() + "%' and ";
				}
				// filter user name
				if (lstUserName.SelectedIndex  != 0)
				{
					filter = filter + "UserID =" + lstUserName.SelectedValue + " and ";
				}
				// filter job
				if (lstJobTitles.SelectedIndex != 0)
				{
					filter = filter + "JobTitleID =" + lstJobTitles.SelectedValue + " and ";
				}
				// filter department
				if (lstCompElements.SelectedIndex != 0)
				{
					filter = filter + "CompElmentID =" + lstCompElements.SelectedValue + " and ";
				}
				// filter status
				if (radStatus.SelectedValue == "1") // active
					filter = filter + "EmployeeStatus =1 and"; 
				else if (radStatus.SelectedValue == "2")
					filter = filter + "EmployeeStatus =0 and"; 
				//---------------------------------------------------
				if (filter != "")
					filter = filter.Substring(0,filter.Length-4);
				cnt = BindEmployee(filter);
				if (cnt > 0 )
					pnlWeeklySheet.Visible = false;
				lblRsltCount.Text = "Total results found " + cnt;
				txtDate.Value = DateTime.Now.ToString("MM/dd/yyyy");
				//hide addresses and phone-book panel
				showAddressPhone(false);
				//filter = "";
			}
			catch(Exception ex)
			{
			}
		}
		#endregion
		//------------------------------------------------------------------
		#region delete employee
		/// <summary>
		///  delete single employee
		/// </summary>
		/// <param name="sernder"></param>
		/// <param name="e"></param>
		public void OnDelete(object sernder, DataGridCommandEventArgs e)
		{
			try
			{
				resetColors();
				int empID = int.Parse(e.Item.Cells[1].Text); 
				Navigation.BaseObject.SafeMerge(dsEmployee,((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListSingleEmployeeData(empID));
				dsEmployee.Tables[0].Rows[0].Delete();
				int res = ((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.DeleteEmployee(dsEmployee);
				if (res >= 1)
					lblRsltCount.Text = "Employee Deleted";
				else
					lblRsltCount.Text = "Couldn't delete";
				grdEmployees.SelectedIndex = -1;
				//BindEmployee(filter);
				BindEmployee(" GEN_Employees.ContactID = GEN_Employees.ContactID ");
			}
			catch(Exception ex)
			{
			}
		}
		#endregion
		//------------------------------------------------------------------
		#region on grid-itembound
		private void grdEmployees_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
			System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
			try
			{
			
				if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
				{
					if (Request["type"] == "findemp")
					{
						e.Item.Cells[0].Attributes.Add("onClick","opener.employeeID=" + e.Item.Cells[1].Text + ";window.close();");
					}
					// Confirm delete
					e.Item.Cells[11].Attributes.Add("onclick", "if(confirm('Are you sure you want to delete this employee?')){}else{return false}") ;
					// generate employee full name 
					e.Item.Cells[4].Text = e.Item.Cells[5].Text + " " + e.Item.Cells[6].Text 
						+ " " + e.Item.Cells[7].Text;	
					// determine active and inactive employees
					img =(System.Web.UI.WebControls.Image)
							e.Item.FindControl("imgActive");
					if (e.Item.Cells[12].Text == "1" )
						img.ImageUrl = "images/active.gif";
					else
						img.ImageUrl = "images/inactive.gif";
					e.Item.Cells[8].Text = lstCompElements.Items.FindByValue
						(e.Item.Cells[8].Text).Text;
					e.Item.Cells[9].Text = lstJobTitles.Items.FindByValue
						(e.Item.Cells[9].Text).Text;
					// get user name
					e.Item.Cells[10].Text = lstUserName.Items.FindByValue(e.Item.Cells[10].Text).Text;
				}
			}
			catch(Exception ex)
			{
			}
		}
		#endregion
		//------------------------------------------------------------------
		#region bind employees to grid
		public int BindEmployee(string filter)
		{
			dsEmployee.Clear();
			if (filter != "" && filter != null )
				Navigation.BaseObject.SafeMerge(dsEmployee,((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListEmployeesDetailedData(filter));	
			else
				Navigation.BaseObject.SafeMerge(dsEmployee,((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListEmployeesDetailedData());

            //Sort Employees DataSet//////////////////////////////////
            DataView dvEmpAll = dsEmployee.GEN_Employees.DefaultView;
            dvEmpAll.Sort = "FirstName, MiddleName, LastName";
            dvEmpAll.RowFilter = "EmployeeStatus=1";
            dsEmployee.Tables.Clear();
            dsEmployee.Tables.Add(master.CreateTableFromView(dvEmpAll));
            //////////////////////////////////////////////////////////

			if(Session["Page_Project_List"]!=null && Session["Page_Project_List"].ToString()=="Page_Project_List")
			{
				Session["Page_Project_List"]=null;
				grdEmployees.DataSource = dsEmployee;
				if (dsEmployee.Tables[0].Rows.Count >0) 
				{
					grdEmployees.Visible = true;
					grdEmployees.DataBind();
				}
				else
					grdEmployees.Visible = false;
				filter = "";
				//			return dsEmployee.Tables[0].Rows.Count;
				return dsEmployee.Tables[0].Rows.Count;
			}

			DataSet dsContactEmployees =  ((Navigation.BaseObject)Session["navigation"]).AccountabilityWSObject.ViewAccountabilityEmployees();
			TSN.ERP.SharedComponents.Data.dsEmployee dsBoundEmployees = new TSN.ERP.SharedComponents.Data.dsEmployee();
			dsBoundEmployees.Tables[0].Clear();
			TSN.ERP.SharedComponents.Data.dsEmployee.GEN_EmployeesRow Row;

			foreach(DataRow dr in dsContactEmployees.Tables[0].Rows)
			{
				if(dr["EmployeeStatus"].ToString() == "0")
					continue;
				foreach(TSN.ERP.SharedComponents.Data.dsEmployee.GEN_EmployeesRow dr2 in dsEmployee.GEN_Employees.Rows)
				{
					if(dr2["ContactID"].ToString() == dr["ContactID"].ToString())
					{
						Row = dsBoundEmployees.GEN_Employees.NewGEN_EmployeesRow();
						
						Row.ContactID = dr2.ContactID;
						if(!dr2.IsJobTitleIDNull())
						{
							Row.JobTitleID = dr2.JobTitleID;
						}
						if(!dr2.IsFileIDNull())
						{
							Row.FileID = dr2.FileID;
						}
						if(!dr2.IsCompElmentIDNull())
						{
							Row.CompElmentID = dr2.CompElmentID;
						}
						Row.EmployeeStatus = dr2.EmployeeStatus;
						if(!dr2.IsEmpHireDateNull())
						{
							Row.EmpHireDate = dr2.EmpHireDate;
						}
						if(!dr2.IsEmpCodeNull())
						{
							Row.EmpCode = dr2.EmpCode;
						}
						if(!dr2.IsContTypeIDNull())
						{
							Row.ContTypeID = dr2.ContTypeID;
						}
						if(!dr2.IsUserIDNull())
						{
							Row.UserID = dr2.UserID;
						}
						if(!dr2.IsFirstNameNull())
						{
							Row.FirstName = dr2.FirstName;
						}
						if(!dr2.IsMiddleNameNull())
						{
							Row.MiddleName = dr2.MiddleName;
						}
						if(!dr2.IsLastNameNull())
						{
							Row.LastName = dr2.LastName;
						}
						Row.Fullname = dr2.Fullname;
						dsBoundEmployees.GEN_Employees.AddGEN_EmployeesRow(Row);
						break;
					}
				}
			}


            //Sort Employees DataSet//////////////////////////////////
            DataView dvEmp = dsBoundEmployees.GEN_Employees.DefaultView;
            dvEmp.Sort = "FirstName, MiddleName, LastName";
            dsBoundEmployees.Tables.Clear();
            dsBoundEmployees.Tables.Add(master.CreateTableFromView(dvEmp));
            //////////////////////////////////////////////////////////

//			grdEmployees.DataSource = dsEmployee;
			grdEmployees.DataSource = dsBoundEmployees;
//			if (dsEmployee.Tables[0].Rows.Count >0) 
			if (dsBoundEmployees.Tables[0].Rows.Count >0) 
			{
				grdEmployees.Visible = true;
				grdEmployees.DataBind();
			}
			else
				grdEmployees.Visible = false;
			filter = "";
//			return dsEmployee.Tables[0].Rows.Count;
			return dsBoundEmployees.Tables[0].Rows.Count;
		}
		#endregion
		//------------------------------------------------------------------
		#region clear button
		protected void btnClear_Click(object sender, System.EventArgs e)
		{
			lnkShowPhoto.Enabled = false;
			pnlPhoto.Visible = false;
			try
			{
				clearForm();
				resetColors();
				pnlWeeklySheet.Visible = false;
				grdEmployees.SelectedIndex = -1;
				showAddressPhone(false);
				btnTerminate.Enabled = false;

				CheckButtonVisibilty();
			}
			catch(Exception ex)
			{
				//TODO
			}
		}
		#endregion
		//------------------------------------------------------------------
		#region update employee
		public bool CheckEmployeeCodeForUpdate(TSN.ERP.SharedComponents.Data.dsEmployee ds,string EmployeeCode,int EmployeeID)
		{
			bool flag = true ;
			foreach(DataRow dr in ds.Tables["GEN_Employees"].Rows)
			{
				flag = true;
				if(dr["EmpCode"].ToString().Trim()== EmployeeCode && int.Parse(dr["ContactID"].ToString())!=EmployeeID)
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
		public bool CheckEmployeeCodeForAdd(TSN.ERP.SharedComponents.Data.dsEmployee ds,string EmployeeCode)
		{
			bool flag = true ;
			foreach(DataRow dr in ds.Tables["GEN_Employees"].Rows)
			{
				flag = true;
				if(dr["EmpCode"].ToString().Trim()== EmployeeCode)
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


		
		protected void btnUpdate_Click(object sender, System.EventArgs e)
		{	
			if(Page.IsValid)
			{
				int empID ;
				lnkShowPhoto.Enabled = false;
				TSN.ERP.SharedComponents.Data.dsEmployee.GEN_EmployeesRow row;
				try
				{
					if (ValidateForm())
					{
					
//						if (txtCode.Text.Trim() == "" )
//						{
//							Navigation.BaseObject.showMessage( "Invalid Employee number" , this.Page );
//							return;
//						}
//						if (txtFName.Text.Trim() == "")
//						{
//							Navigation.BaseObject.showMessage( "Invalid First Name" , this.Page );
//							return;
//						}
//						if (txtMName.Text.Trim() == "" )
//						{
//							Navigation.BaseObject.showMessage( "Invalid Middle Name" , this.Page );
//							return;
//						}
//						if (txtLName.Text.Trim() == "" )
//						{
//							Navigation.BaseObject.showMessage( "Invalid Last Name" , this.Page );
//							return;
//						}

						TSN.ERP.SharedComponents.Data.dsEmployee dsAllEmployees = new TSN.ERP.SharedComponents.Data.dsEmployee();
						empID= int.Parse(grdEmployees.Items[grdEmployees.SelectedIndex].Cells[1].Text);
						Navigation.BaseObject.SafeMerge(dsEmployee,((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListSingleEmployeeData(empID));
						row
							=(TSN.ERP.SharedComponents.Data.dsEmployee.GEN_EmployeesRow)dsEmployee.Tables[0].Rows[0];
						row.FirstName = txtFName.Text.Trim();
						row.MiddleName = txtMName.Text.Trim();
						row.LastName = txtLName.Text.Trim();
						row.Fullname = txtFName.Text.Trim()+" "+txtMName.Text.Trim()+" "+txtLName.Text.Trim();
						row.JobTitleID = int.Parse(lstJobTitles.SelectedValue);
						row.CompElmentID = int.Parse(lstCompElements.SelectedValue);
						row.EmpCode = txtCode.Text.Trim();
					
						Navigation.BaseObject.SafeMerge(dsAllEmployees,((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListEmployeesDetailedData());	
						bool Flag = CheckEmployeeCodeForUpdate(dsAllEmployees,txtCode.Text.Trim(),empID);
						if(Flag)
						{
							if (lstUserName.SelectedIndex != 0)
								row.UserID = int.Parse(lstUserName.SelectedValue);
							((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ModifyEmployee(dsEmployee);
							lblRsltCount.Text = "Employee Updated";
							// save employee image
							saveEmpPhoto(empID);
							//load emp data
							btnFind_Click(null,null);
							grdEmployees.SelectedIndex = 0;
							OnSelect(null,null);
							filter = "";
						}
						else
						{
							lblRsltCount.Text = "This Employee Number already Exists ,Please try another number";
						}
					}
				}
				catch(Exception ex)
				{
					Response.Write(ex.Message);
					// TODO : Handling exception
				}
			}
		}
		#endregion
		//------------------------------------------------------------------
		#region add new employee
		protected void btnNew_Click(object sender, System.EventArgs e)
		{
			if(Page.IsValid)
			{
				lnkShowPhoto.Enabled = false;
				pnlPhoto.Visible = false;
				try
				{
					// Firstly, validate user input
					if ( ValidateForm())
					{
//						if (txtCode.Text.Trim() == "" )
//						{
//							Navigation.BaseObject.showMessage( "Invalid Employee number" , this.Page );
//							return;
//						}
//						if (txtFName.Text.Trim() == "")
//						{
//							Navigation.BaseObject.showMessage( "Invalid First Name" , this.Page );
//							return;
//						}
//						if (txtMName.Text.Trim() == "" )
//						{
//							Navigation.BaseObject.showMessage( "Invalid Middle Name" , this.Page );
//							return;
//						}
//						if (txtLName.Text.Trim() == "" )
//						{
//							Navigation.BaseObject.showMessage( "Invalid Last Name" , this.Page );
//							return;
//						}

					
						TSN.ERP.SharedComponents.Data.dsEmployee dsAllEmployeesAdd = new TSN.ERP.SharedComponents.Data.dsEmployee();
						// prepare employee dataset
						dsEmployee.Clear();
						dsEmployee.EnforceConstraints = false;
						ERP.SharedComponents.Data.dsEmployee.GEN_EmployeesRow row
							= dsEmployee.GEN_Employees.NewGEN_EmployeesRow();
						row.ContTypeID =1;
						row.FirstName = txtFName.Text.Trim();
						row.MiddleName = txtMName.Text.Trim();
						row.LastName = txtLName.Text.Trim();
						row.Fullname = row.FirstName + " " 
							+ " " +  row.MiddleName + " " + row.LastName;
						row.JobTitleID = int.Parse(lstJobTitles.SelectedValue);
						row.CompElmentID =int.Parse(lstCompElements.SelectedValue);
						row.EmployeeStatus = 1;
						row.EmpCode = txtCode.Text.Trim();
						if (lstUserName.SelectedIndex != 0)
							row.UserID = int.Parse(lstUserName.SelectedValue);
						dsEmployee.GEN_Employees.AddGEN_EmployeesRow(row);
						// insert new employee
					
						Navigation.BaseObject.SafeMerge(dsAllEmployeesAdd,((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListEmployeesDetailedData());	
						bool Flag = CheckEmployeeCodeForAdd(dsAllEmployeesAdd,txtCode.Text.Trim());
						if(Flag)
						{
							((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.AddEmployees(dsEmployee);
							btnFind_Click(null,new System.EventArgs());
							clearForm();
							lblRsltCount.Text = "New employee inserted.";	

							CheckButtonVisibilty();
						}
						else
						{
							lblRsltCount.Text = "This Employee Number already Exist Please try another number";	
						}
					}
				}
				catch(Exception ex)
				{
					Response.Write(((Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.LastInnerException());
					Response.Write(ex.Message);
				}
			}
		}
		#endregion
		//------------------------------------------------------------------
		#region grid paging 
		private void grdEmployees_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.grdEmployees.SelectedIndex = -1;
			this.grdEmployees.CurrentPageIndex = e.NewPageIndex;
			BindEmployee(filter);
		}
		#endregion
		//------------------------------------------------------------------
		#region reset control back colors to white
		private void resetColors()
		{
			txtCode.BackColor = Color.White; 
			txtFName.BackColor = Color.White; 
			txtMName.BackColor = Color.White; 
			txtLName.BackColor = Color.White; 
			lstCompElements.BackColor = Color.White; 
			lstJobTitles.BackColor = Color.White; 
			lstUserName.BackColor = Color.White;
			tblErr.Visible = false;
		}
		#endregion
		//------------------------------------------------------------------	
		#region validate user inputs
		/// <summary>
		/// Validate form inputs before going to save or update
		/// </summary>
		/// <returns></returns>
		private bool ValidateForm()
		{
			// flag to indicate if the selected user name is reserved or not
			bool unassignedUser = false; 
			string msg="";
			resetColors();
			Regex reg = new Regex(@"[^a-zA-Z\s]");
			Match match = reg.Match(txtFName.Text.Trim());

//			Regex codeReg = new Regex(@"\d{1,7}");
//			Match codeMatch = codeReg.Match(txtCode.Text.Trim());
			if(txtCode.Text.Trim()=="")
			{
					msg = msg + "<li> Employee code Shouldn't be empty or character</li>" ;
					txtCode.BackColor = Color.LightYellow;
			
			}
			if (txtFName.Text.Trim() == "" || match.Success)
			{
				msg = msg + "<li> First name Shouldn't be empty or contains numbers</li>" ;
				txtFName.BackColor = Color.LightYellow;
			}
			if (txtMName.Text.Trim() != "")
			{
				match = reg.Match(txtMName.Text.Trim());
				if (txtMName.Text.Trim() == "" || match.Success)
				{
					msg = msg + "<li> Middle name Shouldn't contains numbers</li>" ;
					txtMName.BackColor = Color.LightYellow;
				}
			}
			match = reg.Match(txtLName.Text.Trim());
			if (txtLName.Text.Trim() == "" || match.Success)
			{
				msg = msg + "<li> Last name Shouldn't be empty or contains numbers</li>" ;
				txtLName.BackColor = Color.LightYellow;
			}
			if (lstCompElements.SelectedIndex == 0)
			{
				msg = msg + "<li> Please specify in which company section the employee is working</li>" ;
				lstCompElements.BackColor = Color.LightYellow;
			}
			if (lstJobTitles.SelectedIndex == 0)
			{
				msg = msg + "<li> Please specify a job</li>" ;
				lstJobTitles.BackColor = Color.LightYellow;
			}
			// validate user name, check if its already reserved
			// TODO : validate that user name is given for only one employee
//			if (lstUserName.SelectedIndex != 0)
//			{
//				for (int i = 0; i<lstUnassignedUsers.Items.Count ; i++)
//				{
//					if (lstUserName.SelectedValue == lstUnassignedUsers.Items[i].Value)
//					{
//						unassignedUser = true;
//						break;
//					}
//				}
//			
//				if (!unassignedUser )
//				{
//					msg = msg + "<li> Selected user name is already assigned to onother employee</li>" ;
//					lstUserName.BackColor = Color.LightYellow;
//				}
//			}
			if (msg != "")
			{
				msg = "<ul>" + msg + "</ul>";
				tblErr.Rows[0].Cells[1].Text = "<p><b>Please correct the entries highlighted with yellow </b></p>" 
													+ msg;
				tblErr.Visible = true;
				return false;
			}
			else
			{
				return true;
			}	
		}
		#endregion
		//------------------------------------------------------------------	
		#region activate or deactivate employees
		protected void btnTerminate_Click(object sender, System.EventArgs e)
		{
            //int empID ;
            //lnkShowPhoto.Enabled = false;
            //pnlPhoto.Visible = false;
            //TSN.ERP.SharedComponents.Data.dsEmployee.GEN_EmployeesRow row;
            //try
            //{
            //    empID= int.Parse(grdEmployees.Items[grdEmployees.SelectedIndex].Cells[1].Text);
            //    dsEmployee.Clear();
            //    Navigation.BaseObject.SafeMerge(dsEmployee,((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListSingleEmployeeData(empID));
            //    row= (TSN.ERP.SharedComponents.Data.dsEmployee.GEN_EmployeesRow)
            //        dsEmployee.Tables[0].Rows[0];
            //    if (btnTerminate.Text== "Activate")
            //        row.EmployeeStatus = 1;
            //    else
            //        row.EmployeeStatus = 0;
				
            //    ((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ModifyEmployee(dsEmployee);
            //    lblRsltCount.Text = "Employee Updated";
            //    grdEmployees.Visible = false;
            //}
            //catch(Exception ex)
            //{
            //    Response.Write(ex.Message);
            //    // TODO : Handling exception
            //}
            //finally
            //{
            //    btnTerminate.Enabled = false;
            //}
		}	
		#endregion
		//------------------------------------------------------------------
		#region hide address and phone panels
		private void showAddressPhone(bool val)
		{
			lblCountry.Visible = val;
			lblCity.Visible = val;
			lblPhone.Visible = val;
			lblState.Visible = val;
			lblZIP.Visible = val;
			lblAddress.Visible = val;
			lblAddressLine.Visible = val;
			txtCountry.Visible = val;
			txtState.Visible = val;
			txtCity.Visible = val;
			txtZIP.Visible = val;
			txtAddress.Visible = val;
			txtPhone.Visible = val;
			lnkAddress.Visible = val;
			lnkPhone.Visible = val;
		}
		#endregion
		//------------------------------------------------------------------
		#region view total accountability sheet
		protected void btnTotalSheet_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../go/frmReportViewer.aspx?type=2&vars=" + txtDate.Value  + "," + filter);
		}
		#endregion
		//------------------------------------------------------------------
		#region bind user names
		/// <summary>
		/// Bind all user name to its listbox
		/// </summary>
		private void BindUserNames()
		{
			try
			{
				
				Navigation.BaseObject.SafeMerge(dsUser,((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.GetAllNonAssignedUsers());
				lstUserName.DataBind();
				lstUserName.Items.Insert(0,"Select one ......");
			}
			catch(Exception ex)
			{
				Response.Write("Faild to load users name");
			}
		}
		#endregion
		//-------------------------------------------------------------------
		#region bind unassigned usernames
		/// <summary>
		/// Bind unassigned user names to its listbox, unassigned usernames are all username 
		/// which have not been assigned to any employee yet. 
		/// </summary>
		private void BindUnassignedUserNames()
		{
			try
			{
				dsUnassignedUsers = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.GetAllNonAssignedUsers();
				lstUnassignedUsers.DataSource = dsUnassignedUsers;
				lstUnassignedUsers.DataBind();
			}
			catch(Exception ex)
			{
				Response.Write("Faild to load unassigned users name");
			}
		}
		#endregion
		//-------------------------------------------------------------------
		#region save employee's photo
		/// <summary>
		/// Save employee's photo
		/// </summary>
		/// <param name="ContactID"></param>
		private void saveEmpPhoto(int ContactID)
		{
			string imgContentType; 
			int imgLen ;
	

			if (fileEmp.PostedFile != null)
			{
				if (fileEmp.PostedFile.FileName.Trim().Length > 0 && fileEmp.
					PostedFile.ContentLength > 0 )
				{
					Stream imgStream = fileEmp.PostedFile.InputStream;				
					imgLen = fileEmp.PostedFile.ContentLength;
					imgContentType = fileEmp.PostedFile.ContentType;
					byte[] imgBinaryData = new byte[imgLen];
					imgStream.Read(imgBinaryData,0,imgLen);
					// add file info
					dsFilesInfo.EnforceConstraints = false;
					DataRow drFileInfo = dsFilesInfo.GEN_Files.NewGEN_FilesRow();
					drFileInfo["FileID"] = 100000;
					drFileInfo["FileName"] = "";
					drFileInfo["FileSize"] = "";
					drFileInfo["FileType"] = "";
					dsFilesInfo.Tables[0].Rows.Add(drFileInfo);
					((Navigation.BaseObject) Session[ "navigation" ]).GeneralWSObject.AddFileInfo(dsFilesInfo);
					// get inserted file id
					DataSet tmp =  ((Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.LastDataSet();
					int fileID = int.Parse(tmp.Tables[0].Rows[0]["FileID"].ToString());
					//save image
					((Navigation.BaseObject) Session[ "navigation" ]).GeneralWSObject.UpdateFileContent(fileID,imgBinaryData);
					// bind this file to employee
					dsEmployee.Clear();
					Navigation.BaseObject.SafeMerge(dsEmployee,((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListSingleEmployeeData(ContactID));
					dsEmployee.Tables[0].Rows[0]["FileID"] = fileID;
					((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ModifyEmployee(dsEmployee);
				}
			}
		}
		#endregion
		//-------------------------------------------------------------------
		#region view photo link
		/// <summary>
		/// Show employee's personal photo
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lnkShowPhoto_Click(object sender, System.EventArgs e)
		{
			if(pnlPhoto.Visible == false)
			{
				pnlPhoto.Visible = true;
				// show employee photo
				loadEmpPhoto();
			}	
			else
			{
				pnlPhoto.Visible = false;
			}
		}
		#endregion
		//-------------------------------------------------------------------
		#region load employee's photo
		/// <summary>
		/// Load employee's peronal photo
		/// </summary>
		private void loadEmpPhoto()
		{
			if (Session["FileID"].ToString() != "")
				imgEmp.Src = "../go/frmEmpImg.aspx";
			else
				imgEmp.Src = "../go/images/dummy.bmp";
		}
		#endregion	

		//-------------------------------------------------------------------

		#region CheckButtonVisibilty
		
		void CheckButtonVisibilty()
		{
			ArrayList arrRules = new ArrayList();
			bool visibililty = true;

			// check edit task buttons
			visibililty = true;
			arrRules.Clear();

			arrRules.Add( 5004 );
			visibililty = ((Navigation.BaseObject) Session[ "navigation" ]).CheckUserAccessRule( arrRules );
			btnUpdate.Visible	= visibililty;

			// check add employee buttons
			visibililty = true;
			arrRules.Clear();

			arrRules.Add( 5003 );
			visibililty = ((Navigation.BaseObject) Session[ "navigation" ]).CheckUserAccessRule( arrRules );
			btnNew.Visible	= visibililty;

		}
		#endregion 

		private void grdEmployees_Sort(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			
			if(filter ==null || filter =="")
			{	
				SortField = " GEN_Employees.ContactID = GEN_Employees.ContactID ORDER BY " +(string)e.SortExpression;
			}
			else
			{
				
				
				SortField = filter+" AND GEN_Employees.ContactID = GEN_Employees.ContactID ORDER BY " +(string)e.SortExpression;
			}
				BindEmployee(SortField);
			grdEmployees.SelectedIndex = -1;
			SortField = "";

		}
	}
}
