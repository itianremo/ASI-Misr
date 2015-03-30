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
	using System.IO;
	using System.Text.RegularExpressions;
	using TSN.ERP.SharedComponents.Data;
    using System.Text;
    using System.Drawing.Imaging;

	/// <summary>
	///	This Form used to query, add, modify and activete/terminate employees.
	/// </summary>
	public partial class ctlEmployeeMain : System.Web.UI.UserControl
	{
	
		#region Class members
		private static string filter ;
		bool EventFiredOneTime= false;
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
		protected string SortField;
		public bool ResetImageFlage = false;

		public MasterMethods master = new MasterMethods();
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

			ArrayList arrRules = new ArrayList();
			arrRules.Add( 5005 );
			ViewState[ "CanDelete" ] = ((Navigation.BaseObject) Session[ "navigation" ]).CheckUserAccessRule( arrRules ); 
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
			this.grdEmployees.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grdEmployees_PageIndexChanged);
			this.grdEmployees.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grdEmployees_Sort);
			this.grdEmployees.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.OnDelete);
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
            txtHDate.Attributes.Add("readonly", "true");
            txtTDate.Attributes.Add("readonly", "true");
			EventFiredOneTime = false;
			lblRsltCount.Text ="";
			lstJobTitles.Enabled = true;
			if ( !Page.IsPostBack  )
			{
				//List All Jobtitles:
				DataSet DSTempJobTitles = ((Navigation.BaseObject)Session["Navigation"]).JobTiltesWsObject.ListJobtitles();
				ViewState["DSTempJobTitles"] = DSTempJobTitles;

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
					Navigation.BaseObject.SafeMerge(dsEmployee,((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListSingleEmployeeData(empID));
					if (dsEmployee.Tables[0].Rows.Count > 0)
					{
						int cnt = 0;
						if( !((Navigation.BaseObject)Page.Session[ "navigation" ]).SecInfo.IsAdministrator )
						{
                            cnt = BindEmployee("EmpCode='" + dsEmployee.Tables[0].Rows[0]["EmpCode"].ToString() + "' AND EmployeeStatus=1");
                            radStatus.Visible = false;
						}
						else 
						{
							cnt = BindEmployee( "EmployeeStatus=1" );
                            radStatus.Visible = true;
						}

						lblRsltCount.Text = "Total results found " + cnt;
						showAddressPhone(false);
						//System.Web.HttpContext.Current.Session["CurrentEmployee"] = null;
					}
				}			
			}
            // added by Sayed 31/3/2010
            if (btnNew.Visible)
            {
                ViewState["ShowNewUserPassword"] = "Show";
            }
            //
            if (ViewState["ShowNewUserPassword"] != null && ViewState["ShowNewUserPassword"].ToString() == "Show")
            {
                ViewState["ShowNewUserPassword"] = null;
                lblNewUserName.Visible = true;
                lblNewPassword.Visible = true;
                txtNewUserName.Visible = true;
                txtNewPassword.Visible = true;
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
			//To prevent the event from firing twice
			if(EventFiredOneTime)
				return;
			fileEmp.Style["background"] = "";
			imgEmp.Src = "";
            imgEmpHR.Src = "";
			lnkShowPhoto.Enabled = true;
			Session["selectedEmployee"] = grdEmployees.SelectedItem.Cells[1].Text;
			int contactID =int.Parse(grdEmployees.SelectedItem.Cells[1].Text); 
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

                //Fill Hiring Date and Termination Date                
                if (dsEmployee.Tables[0].Rows[0]["EmpHireDate"] != DBNull.Value && dsEmployee.Tables[0].Rows[0]["EmpHireDate"] != null)
                {
                    DateTime dtHiringDate = Convert.ToDateTime(dsEmployee.Tables[0].Rows[0]["EmpHireDate"]);
                    txtHDate.Text = dtHiringDate.ToShortDateString();
                }
                else
                {
                    txtHDate.Text = String.Empty;
                }
                if (dsEmployee.Tables[0].Rows[0]["EmpTerminationDate"] != DBNull.Value && dsEmployee.Tables[0].Rows[0]["EmpTerminationDate"] != null)
                {
                    DateTime dtTerminationDate = Convert.ToDateTime(dsEmployee.Tables[0].Rows[0]["EmpTerminationDate"]);
                    txtTDate.Text = dtTerminationDate.ToShortDateString();
                }
                else
                {
                    txtTDate.Text = String.Empty;
                }
                ///////////////////////////////////////
				// save photo file id in a session
				Session["FileID"] = dsEmployee.Tables[0].Rows[0]["FileID"].ToString();
                // added 20/7/2010 by Sayed
                Session["FileIDHR"] = dsEmployee.Tables[0].Rows[0]["FileIDHR"].ToString();
                if(Session["FileIDHR"].ToString().Trim()!="")
                    btnDownload.Visible = true;
                else
                    btnDownload.Visible = false;
                //
				job = dsEmployee.Tables[0].Rows[0]["JobTitleID"].ToString();
//				ViewState["jobTitleID"] = job;
				DataSet DSTempJobTitles = (DataSet)ViewState["DSTempJobTitles"];
				DataRow DRJobTitle = DSTempJobTitles.Tables[0].Rows.Find(job);
				string JobTitleName = DRJobTitle["JobName"].ToString().Trim();

//				ViewState["JobTitleName"] = JobTitleName;
				userID = dsEmployee.Tables[0].Rows[0]["UserID"].ToString();
				if(dsEmployee.Tables[0].Rows[0]["UserID"] == System.DBNull.Value)
				{
					lstUnassignedUsers.Enabled = true;
					lstUserName.Enabled = true;
				}
				else
				{
					lstUnassignedUsers.Enabled = false;
					lstUserName.Enabled = false;
				}
				Department = dsEmployee.Tables[0].Rows[0]["CompElmentID"].ToString();
				lstCompElements.SelectedIndex = lstCompElements.Items.IndexOf(lstCompElements.Items.FindByValue(Department));
				if(Convert.ToBoolean(DRJobTitle["IsActive"]))
				{
					lstJobTitles.SelectedIndex = lstJobTitles.Items.IndexOf(lstJobTitles.Items.FindByValue(job)); 
					txtJobTitleName.Visible=false;
					lstJobTitles.Visible=true;
				}
				else
				{
					lstJobTitles.Visible=false;
					txtJobTitleName.Visible=true;
					txtJobTitleName.Enabled=false;
					txtJobTitleName.Text=JobTitleName;
				}
				
//				Session["EmpJobTitleID"] = lstJobTitles.SelectedValue;
//				Session["EmpJobTitleName"] = lstJobTitles.SelectedItem.Text;
				Session["EmpJobTitleID"] = job;
				Session["EmpJobTitleName"] = JobTitleName;
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
                // Email ----------------------
                GetUserEmail(contactID);
				
				btnNew.Visible = false;
				btnUpdate.Visible = true;
				btnTerminate.Enabled = true;
                if (grdEmployees.SelectedItem.Cells[12].Text == "1")
                {
                    //btnTerminate.Text = "Terminate";
                    rblEmpStatus.SelectedValue = "1";
                }
                else
                {
                    //btnTerminate.Text = "Activate";
                    rblEmpStatus.SelectedValue = "0";
                }
				showAddressPhone(true);
				//load emp photo
				if (pnlPhoto.Visible == true)
					loadEmpPhoto();	
				lstJobTitles.Enabled = false;

				CheckButtonVisibilty();
				btnNew.Visible = false;
				if(!Convert.ToBoolean(DRJobTitle["IsActive"]))
				{
					btnUpdate.Visible=false;
					btnNew.Visible=false;
				}
			}
			catch(Exception ex)
			{
				lnkAddress.Visible = false ;
				lnkPhone.Visible = false;
				lnkEmail.Visible = false;
				lnkJobTitle.Visible = false;
				btnNew.Visible = false;
				Response.Write(ex.Message);
			}

			//Display or hide view weeekly accountability sheet panel
			DataSet dsContactEmployees =  ((Navigation.BaseObject)Session["navigation"]).AccountabilityWSObject.ViewAccountabilityEmployees();
			DataRow[] drEmps = dsContactEmployees.Tables[0].Select("ContactID = '"+grdEmployees.SelectedItem.Cells[1].Text+"'");
			if(drEmps.Length > 0)
			{
				pnlWeeklySheet.Visible = true;
				btnTotalSheet.Visible = true;
				txtDate.Value = DateTime.Now.ToString("MM/dd/yyyy");
			}
			else
			{
				pnlWeeklySheet.Visible = false;
				btnTotalSheet.Visible = false;
			}
			/////////////////////////////////////////////////////////
			EventFiredOneTime = true;
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


//				//Sort Company Elements DataSet//////////////////////////////////
//				DataView dvCE = dsCompElements.GEN_CompanyElments.DefaultView;
//				dvCE.Sort = "CEName";
//				dsCompElements.Tables.Clear();
//				dsCompElements.Tables.Add(master.CreateTableFromView(dvCE));
//				//////////////////////////////////////////////////////////
				///

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
//				Navigation.BaseObject.SafeMerge(dsJobTitles,((Navigation.BaseObject) Session[ "navigation" ]).JobTiltesWsObject.ListJobtitles());
				Navigation.BaseObject.SafeMerge(dsJobTitles,((Navigation.BaseObject) Session[ "navigation" ]).JobTiltesWsObject.ListActiveJobtitles());

//				//Sort Job Titles DataSet//////////////////////////////////
//				DataView dvJT = dsJobTitles.GEN_JobTitles.DefaultView;
//				dvJT.Sort = "JobName";
//				dsJobTitles.Tables.Clear();
//				dsJobTitles.Tables.Add(master.CreateTableFromView(dvJT));
//				//////////////////////////////////////////////////////////
				///

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
            rblEmpStatus.SelectedIndex = -1;
            txtHDate.Text = "";
            txtTDate.Text = "";
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
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
		{
			
			lnkShowPhoto.Enabled = false;
			pnlPhoto.Visible = false;
			
//			pnlWeeklySheet.Visible = false;
			try
			{
				int cnt;  // number of found employees
				//-------------------------------------------------------
				filter = "";
				btnTerminate.Enabled = false;
				lnkAddress.Visible =false;
				lnkPhone.Visible = false;
				lnkEmail.Visible = false;
				lnkJobTitle.Visible = false;
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
//					pnlWeeklySheet.Visible = true;
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
			//To prevent the event from firing twice
			if(EventFiredOneTime)
				return;
			try
			{
				resetColors();
				int empID = int.Parse(e.Item.Cells[1].Text); 
				Navigation.BaseObject.SafeMerge(dsEmployee,((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListSingleEmployeeData(empID));
				dsEmployee.Tables[0].Rows[0].Delete();
				int res = ((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.DeleteEmployee(dsEmployee);
				
				grdEmployees.SelectedIndex = -1;
				//BindEmployee(filter);
				BindEmployee(" GEN_Employees.ContactID = GEN_Employees.ContactID ");
				btnClear_Click( sernder,  null);
				if (res >= 1)
					lblRsltCount.Text = "Employee Deleted";
				else
					lblRsltCount.Text = "Couldn't Delete";
				EventFiredOneTime = true;

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
			
//			System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
			//imgActive
			try
			{
			
				if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
				{
					if (Request["type"] == "findemp")
					{
						e.Item.Cells[0].Attributes.Add("onClick","opener.employeeID=" + e.Item.Cells[1].Text + ";window.close();");
					}


					// Confirm delete
					if( (bool) ViewState[ "CanDelete" ] )
						e.Item.Cells[11].Attributes.Add("onclick", "return confirm('Are you sure you want to delete this employee?')") ;
					
					
					((LinkButton) e.Item.Cells[11].Controls[0]).Enabled = (bool) ViewState[ "CanDelete" ];

					// generate employee full name 
					e.Item.Cells[4].Text = e.Item.Cells[5].Text + " " + e.Item.Cells[6].Text + " " + e.Item.Cells[7].Text;	
					// determine active and inactive employees
//					img =(System.Web.UI.WebControls.Image)
//							e.Item.FindControl("imgActive");
					if (e.Item.Cells[12].Text == "1" )
					{
						//						img.ImageUrl = "images/active.gif";
						((System.Web.UI.WebControls.Image)e.Item.FindControl("imgActive")).ImageUrl="images/active.gif";
					}
					else
					{
						//						img.ImageUrl = "images/inactive.gif";
						((System.Web.UI.WebControls.Image)e.Item.FindControl("imgActive")).ImageUrl="images/inactive.gif";
					}
					e.Item.Cells[8].Text = lstCompElements.Items.FindByValue(e.Item.Cells[8].Text).Text;
					if(lstJobTitles.Items.FindByValue(e.Item.Cells[9].Text) != null)
					{
						e.Item.Cells[9].Text = lstJobTitles.Items.FindByValue(e.Item.Cells[9].Text).Text;
					}
					else
					{
						DataSet DSTempJobTitles = (DataSet)ViewState["DSTempJobTitles"];
						DataRow DRJobTitle = DSTempJobTitles.Tables[0].Rows.Find(e.Item.Cells[9].Text);
						e.Item.Cells[9].Text = DRJobTitle["JobName"].ToString();
						e.Item.Cells[9].ForeColor = Color.Red;
					}
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
			DataView dvEmp = dsEmployee.GEN_Employees.DefaultView;
			dvEmp.Sort = "FirstName, MiddleName, LastName";
			dsEmployee.Tables.Clear();
			dsEmployee.Tables.Add(master.CreateTableFromView(dvEmp));
			//////////////////////////////////////////////////////////

			grdEmployees.DataSource = dsEmployee;

			if (dsEmployee.Tables[0].Rows.Count >0) 
			{
				grdEmployees.Visible = true;
				grdEmployees.DataBind();
			}
			else
				grdEmployees.Visible = false;
			filter = "";
			return dsEmployee.Tables[0].Rows.Count;
		}
		#endregion
		//------------------------------------------------------------------
		#region clear button
        protected void btnClear_Click(object sender, ImageClickEventArgs e)
		{
			btnNew.Visible = true;
			txtJobTitleName.Visible=false;
			lstJobTitles.Visible=true;
			lnkShowPhoto.Enabled = false;
			pnlPhoto.Visible = false;
			lstUserName.Enabled = true;
			try
			{
				clearForm();
				resetColors();
//				pnlWeeklySheet.Visible = false;
				grdEmployees.SelectedIndex = -1;
				showAddressPhone(false);
				btnTerminate.Enabled = false;

				CheckButtonVisibilty();
				btnUpdate.Visible = false;
				lnkJobTitle.Visible = false;
				pnlWeeklySheet.Visible=false;

                lblNewUserName.Visible = true;
                lblNewPassword.Visible = true;
                txtNewUserName.Visible = true;
                txtNewPassword.Visible = true;
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
					if(EmployeeCode != string.Empty)
					{
						flag = false;
						break;
					}
				}				
				else
				{
					flag = true;
				}
			}
			return flag;
		}


		
		protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
		{	
			if(Page.IsValid)
			{
				int empID ;
				lnkShowPhoto.Enabled = false;
				TSN.ERP.SharedComponents.Data.dsEmployee.GEN_EmployeesRow row;
				try
				{
					if(grdEmployees.SelectedIndex > -1)
					{
                        if (ValidateForm("edit"))
                        
						{                        
							empID= int.Parse(grdEmployees.Items[grdEmployees.SelectedIndex].Cells[1].Text);
							Navigation.BaseObject.SafeMerge(dsEmployee,((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListSingleEmployeeData(empID));
							row=(TSN.ERP.SharedComponents.Data.dsEmployee.GEN_EmployeesRow)dsEmployee.Tables[0].Rows[0];


                            if (rblEmpStatus.SelectedValue == "1")
                            {
                                //if (!String.IsNullOrEmpty(txtTDate.Text))
                                //{
                                //    tblErr.Rows[0].Cells[1].Text = "<p><ul><li>Employee can't be active and have termination date in the same time.</li></ul></p>";
                                //    tblErr.Visible = true;
                                //    return;
                                //}
                                DataSet DSTempJobTitles = (DataSet)ViewState["DSTempJobTitles"];
                                DataRow DRJobTitle = DSTempJobTitles.Tables[0].Rows.Find(row.JobTitleID);
                                if (!Convert.ToBoolean(DRJobTitle["IsActive"]))
                                {
                                    tblErr.Rows[0].Cells[1].Text = "<p><ul><li>Employee can not be activated as long as his job title is terminated, change his job title or activate the current job title.</li></ul></p>";
                                    tblErr.Visible = true;
                                    return;
                                }
                                row.EmployeeStatus = 1;
                                row["EmpTerminationDate"] = DBNull.Value;
                                //row.EmpTerminationDate = DBNull.Value;
                            }
                            else if (rblEmpStatus.SelectedValue == "0")
                            {
                                if (String.IsNullOrEmpty(txtTDate.Text))
                                {
                                    tblErr.Rows[0].Cells[1].Text = "<p><ul><li>Termination date can't be empty when the user is terminated.</li></ul></p>";
                                    tblErr.Visible = true;
                                    return;
                                }
                                DateTime dtTerminationDate = DateTime.Now;
                                try
                                {
                                    dtTerminationDate = Convert.ToDateTime(txtTDate.Text);
                                }
                                catch
                                {
                                    tblErr.Rows[0].Cells[1].Text = "<p><ul><li>Enter valid date in termination date.</li></ul></p>";
                                    tblErr.Visible = true;
                                    return;
                                }

                                TSN.ERP.SharedComponents.Data.dsTeams Teams = new TSN.ERP.SharedComponents.Data.dsTeams();
                                TSN.ERP.SharedComponents.Data.dsProjects Projects = new TSN.ERP.SharedComponents.Data.dsProjects();
                                TSN.ERP.SharedComponents.Data.dsCompanyElements CElements = new TSN.ERP.SharedComponents.Data.dsCompanyElements();
                                Navigation.BaseObject.SafeMerge(Teams, ((Navigation.BaseObject)Session["navigation"]).TeamsWSObject.ListTeams());
                                Navigation.BaseObject.SafeMerge(Projects, ((Navigation.BaseObject)Session["navigation"]).ProjectWSObject.ListAllProjects());
                                Navigation.BaseObject.SafeMerge(CElements, ((Navigation.BaseObject)Session["navigation"]).CompanyWsObject.ListCompnayElements());

                                DataRow[] arrTeams = Teams.Tables[0].Select("TeamLeader='" + empID + "'");
                                DataRow[] arrProjects = Projects.Tables[0].Select("ProjectManager='" + empID + "' AND ProjectStatus=1");
                                DataRow[] arrCompElements = CElements.Tables[0].Select("ContactID='" + empID + "'");

                                if (arrTeams.Length == 0 && arrProjects.Length == 0 && arrCompElements.Length == 0)
                                {
                                    row.EmployeeStatus = 0;
                                    row.EmpTerminationDate = DateTime.Now;
                                }
                                else
                                {
                                    tblErr.Rows[0].Cells[1].Text = "Employee can not be terminated as he/she is project manager, team leader or company element manager.";
                                    if (arrProjects.Length > 0)
                                    {
                                        StringBuilder strProjects = new StringBuilder();
                                        strProjects.Append(arrProjects[0]["ProjectName"].ToString());
                                        for (int i = 1; i < arrProjects.Length; i++)
                                        {
                                            strProjects.Append(", " + arrProjects[i]["ProjectName"].ToString());
                                        }
                                        tblErr.Rows[0].Cells[1].Text += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<ul><li>Projects: " + strProjects.ToString() + "</li>";
                                    }
                                    if (arrTeams.Length > 0)
                                    {
                                        StringBuilder strTeams = new StringBuilder();
                                        strTeams.Append(arrTeams[0]["TeamName"].ToString());
                                        for (int i = 1; i < arrTeams.Length; i++)
                                        {
                                            strTeams.Append(", " + arrTeams[i]["TeamName"].ToString());
                                        }
                                        tblErr.Rows[0].Cells[1].Text += "<li>Teams: " + strTeams + "</li>";
                                    }
                                    if (arrCompElements.Length > 0)
                                    {
                                        StringBuilder strCompElements = new StringBuilder();
                                        strCompElements.Append(arrCompElements[0]["CEName"].ToString());
                                        for (int i = 1; i < arrCompElements.Length; i++)
                                        {
                                            strCompElements.Append(", " + arrCompElements[i]["CEName"].ToString());
                                        }
                                        tblErr.Rows[0].Cells[1].Text += "<li>Company Elements: " + strCompElements + "</li></ul>";
                                    }
                                    tblErr.Rows[0].Cells[1].Text += "</ul>";
                                    tblErr.Visible = true;
                                    return;
                                }
                            }



							row.FirstName = txtFName.Text.Trim();
							row.MiddleName = txtMName.Text.Trim();
							row.LastName = txtLName.Text.Trim();
							row.Fullname = txtFName.Text.Trim()+" "+txtMName.Text.Trim()+" "+txtLName.Text.Trim();
							row.JobTitleID = int.Parse(lstJobTitles.SelectedValue);
							row.CompElmentID = int.Parse(lstCompElements.SelectedValue);
                            row.EmpCode = txtCode.Text.Trim();
                            if (!String.IsNullOrEmpty(txtHDate.Text))
                            {
                                row.EmpHireDate = DateTime.Parse(txtHDate.Text);
                            }
                            if (!String.IsNullOrEmpty(txtTDate.Text) && row.EmployeeStatus == 0)
                            {
                                row.EmpTerminationDate = DateTime.Parse(txtTDate.Text);
                            }                         					
							if (lstUserName.SelectedIndex != 0)
							{
								row.UserID = int.Parse(lstUserName.SelectedValue);
								bool Added = false;
								Added = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.AddUserToGroup(1,row.UserID);
								Added=false;
							}
								((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ModifyEmployee(dsEmployee);
								// save employee image
								saveEmpPhoto(empID);
								//load emp data
								btnFind_Click(null,null);
								grdEmployees.SelectedIndex = 0;
								OnSelect(null,null);
								filter = "";
								//hdnResetImage.Value = "";
							hdnResetImage.Value ="";
							lblRsltCount.Text = "Employee Updated";
                            if (!grdEmployees.Visible)
                            {
                                clearForm();
                            }
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

        protected void btnUpdate_New_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                int empID;
                lnkShowPhoto.Enabled = false;
                TSN.ERP.SharedComponents.Data.dsEmployee.GEN_EmployeesRow row;
                try
                {
                    if (grdEmployees.SelectedIndex > -1)
                    {
                        if (ValidateForm("edit"))
                        {
                            empID = int.Parse(grdEmployees.Items[grdEmployees.SelectedIndex].Cells[1].Text);
                            Navigation.BaseObject.SafeMerge(dsEmployee, ((Navigation.BaseObject)Session["navigation"]).EmployeeWsObject.ListSingleEmployeeData(empID));
                            row = (TSN.ERP.SharedComponents.Data.dsEmployee.GEN_EmployeesRow)dsEmployee.Tables[0].Rows[0];


                            if (rblEmpStatus.SelectedValue == "1")
                            {
                                //if (!String.IsNullOrEmpty(txtTDate.Text))
                                //{
                                //    tblErr.Rows[0].Cells[1].Text = "<p><ul><li>Employee can't be active and have termination date in the same time.</li></ul></p>";
                                //    tblErr.Visible = true;
                                //    return;
                                //}
                                DataSet DSTempJobTitles = (DataSet)ViewState["DSTempJobTitles"];
                                DataRow DRJobTitle = DSTempJobTitles.Tables[0].Rows.Find(row.JobTitleID);
                                if (!Convert.ToBoolean(DRJobTitle["IsActive"]))
                                {
                                    tblErr.Rows[0].Cells[1].Text = "<p><ul><li>Employee can not be activated as long as his job title is terminated, change his job title or activate the current job title.</li></ul></p>";
                                    tblErr.Visible = true;
                                    return;
                                }
                                row.EmployeeStatus = 1;
                                row["EmpTerminationDate"] = DBNull.Value;
                                //row.EmpTerminationDate = DBNull.Value;
                            }
                            else if (rblEmpStatus.SelectedValue == "0")
                            {
                                if (String.IsNullOrEmpty(txtTDate.Text))
                                {
                                    tblErr.Rows[0].Cells[1].Text = "<p><ul><li>Termination date can't be empty when the user is terminated.</li></ul></p>";
                                    tblErr.Visible = true;
                                    return;
                                }
                                DateTime dtTerminationDate = DateTime.Now;
                                try
                                {
                                    dtTerminationDate = Convert.ToDateTime(txtTDate.Text);
                                }
                                catch
                                {
                                    tblErr.Rows[0].Cells[1].Text = "<p><ul><li>Enter valid date in termination date.</li></ul></p>";
                                    tblErr.Visible = true;
                                    return;
                                }

                                TSN.ERP.SharedComponents.Data.dsTeams Teams = new TSN.ERP.SharedComponents.Data.dsTeams();
                                TSN.ERP.SharedComponents.Data.dsProjects Projects = new TSN.ERP.SharedComponents.Data.dsProjects();
                                TSN.ERP.SharedComponents.Data.dsCompanyElements CElements = new TSN.ERP.SharedComponents.Data.dsCompanyElements();
                                Navigation.BaseObject.SafeMerge(Teams, ((Navigation.BaseObject)Session["navigation"]).TeamsWSObject.ListTeams());
                                Navigation.BaseObject.SafeMerge(Projects, ((Navigation.BaseObject)Session["navigation"]).ProjectWSObject.ListAllProjects());
                                Navigation.BaseObject.SafeMerge(CElements, ((Navigation.BaseObject)Session["navigation"]).CompanyWsObject.ListCompnayElements());

                                DataRow[] arrTeams = Teams.Tables[0].Select("TeamLeader='" + empID + "'");
                                DataRow[] arrProjects = Projects.Tables[0].Select("ProjectManager='" + empID + "' AND ProjectStatus=1");
                                DataRow[] arrCompElements = CElements.Tables[0].Select("ContactID='" + empID + "'");

                                if (arrTeams.Length == 0 && arrProjects.Length == 0 && arrCompElements.Length == 0)
                                {
                                    row.EmployeeStatus = 0;
                                    row.EmpTerminationDate = DateTime.Now;
                                }
                                else
                                {
                                    TSN.ERP.SharedComponents.Data.dsEmployee.GEN_EmployeesRow NoneEmployeeRow;
                                    dsEmployee dsNoneEmployee = new dsEmployee();
                                    Navigation.BaseObject.SafeMerge(dsNoneEmployee, ((Navigation.BaseObject)Session["navigation"]).EmployeeWsObject.ListEmployeesDetailedData("FirstName = 'None'"));
                                    int NoneContactID;
                                    int NoneJobTitleID; 
                                    int NoneCompElementID;
                                    int NoneUserID;
                                    if (dsNoneEmployee.Tables[0].Rows.Count > 0)
                                    {
                                        NoneEmployeeRow = (TSN.ERP.SharedComponents.Data.dsEmployee.GEN_EmployeesRow)dsNoneEmployee.Tables[0].Rows[0];
                                        NoneContactID = NoneEmployeeRow.ContactID;
                                    }
                                    else
                                    {

                                        //Get Jobtitle ID
                                        dsJobtitles.GEN_JobTitlesRow NoneJobTitleRow = dsJobTitles.GEN_JobTitles.NewGEN_JobTitlesRow();
                                        //Navigation.BaseObject.SafeMerge(dsJobTitles, ((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobtitles());
                                        NoneJobTitleRow.JobName = "None";
                                        NoneJobTitleRow.JobDescription = "None";
                                        NoneJobTitleRow.JobTitleOrder = 1;
                                        NoneJobTitleRow.IsActive = true;

                                        bool Flage ;
                                        if(dsJobTitles.Tables[0].Select("JobName='None'").Length>0)
                                            Flage=false;
                                        else
                                            Flage = CheckJobTitleByName(dsJobTitles, "None");
                                        if (Flage)//"None" job title does not exist
                                        {
                                            dsJobTitles.EnforceConstraints = false;
                                            dsJobTitles.GEN_JobTitles.AddGEN_JobTitlesRow(NoneJobTitleRow);
                                            ((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.AddJobtitles(dsJobTitles);
                                            dsJobTitles.AcceptChanges();
                                        }
                                        dsJobTitles.Clear();
                                        Navigation.BaseObject.SafeMerge(dsJobTitles, ((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobtitles());
                                        NoneJobTitleRow = (dsJobtitles.GEN_JobTitlesRow)dsJobTitles.Tables[0].Select("JobName='None'")[0];
                                        NoneJobTitleID = NoneJobTitleRow.JobTitleID;

                                        // check if the compay element exist or not

                                        dsCompElements.Clear();
                                        Navigation.BaseObject.SafeMerge(dsCompElements, ((Navigation.BaseObject)Session["navigation"]).CompanyWsObject.ListCompnayElements());
                                       // NoneCompanyElementRow = (dsCompanyElements.GEN_CompanyElmentsRow)dsCompElements.Tables[0].Select("CEName='None'")[0];
                                       // NoneCompElementID = NoneCompanyElementRow.CompElmentID;


                                        //Get None Company Element ID
                                        bool departmentflage = false;
                                        //Navigation.BaseObject.SafeMerge(dsCompElements, ((Navigation.BaseObject)Session["navigation"]).CompanyWsObject.ListCompnayElements());
                                        TSN.ERP.SharedComponents.Data.dsCompanyElements.GEN_CompanyElmentsRow NoneCompanyElementRow = dsCompElements.GEN_CompanyElments.NewGEN_CompanyElmentsRow();
                                        NoneCompanyElementRow.CEName = "None";
                                        NoneCompanyElementRow.CEDescription = "None";
                                        departmentflage = IsElementExist(dsCompElements, "None");
                                        NoneCompanyElementRow.CEL_ID = 2;
                                        if (!departmentflage)//"None" company element does not exist
                                        {
                                            dsCompElements.EnforceConstraints = false;
                                            dsCompElements.GEN_CompanyElments.AddGEN_CompanyElmentsRow(NoneCompanyElementRow);
                                            ((Navigation.BaseObject)Session["navigation"]).CompanyWsObject.AddCompanyElements(dsCompElements);
                                            dsCompElements.AcceptChanges();
                                        }
                                        dsCompElements.Clear();
                                        Navigation.BaseObject.SafeMerge(dsCompElements, ((Navigation.BaseObject)Session["navigation"]).CompanyWsObject.ListCompnayElements());
                                        NoneCompanyElementRow = (dsCompanyElements.GEN_CompanyElmentsRow)dsCompElements.Tables[0].Select("CEName='None'")[0];
                                        NoneCompElementID = NoneCompanyElementRow.CompElmentID;


                                        //Get None UserID
                                        SecurityWS.SecurityManagement secMang = ((Navigation.BaseObject)Session["navigation"]).SecurityWsObject;
                                        if (!IsUserExists("None"))
                                        {                                            
                                            secMang.AddUser("None", "None", true, "");
                                        }
                                        DataSet dsUsers = secMang.GetAllUsers();
                                        DataRow drUser = dsUsers.Tables[0].Select("UserName='None'")[0];
                                        NoneUserID = Convert.ToInt32(drUser["UserID"]);

                                        dsNoneEmployee.Clear();
                                        dsNoneEmployee.EnforceConstraints = false;
                                        NoneEmployeeRow = dsNoneEmployee.GEN_Employees.NewGEN_EmployeesRow();
                                        NoneEmployeeRow.ContTypeID = 1;
                                        NoneEmployeeRow.FirstName = "None";
                                        NoneEmployeeRow.MiddleName = "";
                                        NoneEmployeeRow.LastName = "";
                                        NoneEmployeeRow.Fullname = "None";
                                        NoneEmployeeRow.JobTitleID = NoneJobTitleID;
                                        NoneEmployeeRow.CompElmentID = NoneCompElementID;
                                        NoneEmployeeRow.EmployeeStatus = 1;
                                        NoneEmployeeRow.EmpCode = "9999999";
                                        NoneEmployeeRow.UserID = NoneUserID;
                                        NoneEmployeeRow.EmpHireDate = DateTime.Now;
                                        dsNoneEmployee.GEN_Employees.AddGEN_EmployeesRow(NoneEmployeeRow);
                                        ((Navigation.BaseObject)Session["navigation"]).EmployeeWsObject.AddEmployees(dsNoneEmployee);

                                        dsNoneEmployee.AcceptChanges();
                                        dsNoneEmployee.Clear();
                                        Navigation.BaseObject.SafeMerge(dsNoneEmployee, ((Navigation.BaseObject)Session["navigation"]).EmployeeWsObject.ListEmployeesDetailedData("FirstName = 'None'"));
                                        NoneEmployeeRow = (ERP.SharedComponents.Data.dsEmployee.GEN_EmployeesRow)dsNoneEmployee.Tables[0].Rows[0];
                                        NoneContactID = NoneEmployeeRow.ContactID;                                        
                                    }

                                    if (arrProjects.Length > 0)
                                    {
                                        //StringBuilder sbProjects = new StringBuilder();
                                        //sbProjects.Append("Project(s) ");
                                        //Projects.Clear();
                                        Projects.EnforceConstraints = false;
                                        for (int i = 0; i < arrProjects.Length; i++)
                                        {
                                            dsProjects.GEN_ProjectsRow ProjectRow = (dsProjects.GEN_ProjectsRow)Projects.Tables[0].Select("projectID='" + ((dsProjects.GEN_ProjectsRow)arrProjects[i]).projectID + "'")[0];
                                            ProjectRow.ProjectManager = NoneContactID;
                                            //Projects.GEN_Projects.AddGEN_ProjectsRow(ProjectRow);    
                                            //sbProjects.Append(i == 0 ? ProjectRow.ProjectName : ", " + ProjectRow.ProjectName);
                                        }
                                        ((Navigation.BaseObject)Session["navigation"]).ProjectWSObject.EditProjects(Projects);
                                        //sbProjects.Append(" now has no assigned manager.</br>");
                                        //tblErr.Rows[0].Cells[1].Text = sbProjects.ToString();
                                        //tblErr.Visible = true;                    
                                    }                          
                                   
                                    if (arrTeams.Length > 0)
                                    {
                                        //Teams.Clear();
                                        Teams.EnforceConstraints = false;
                                        for (int i = 0; i < arrTeams.Length; i++)
                                        {
                                            dsTeams.GEN_TeamsRow TeamRow = (dsTeams.GEN_TeamsRow)Teams.Tables[0].Select("TeamID='" + ((dsTeams.GEN_TeamsRow)arrTeams[i]).TeamID + "'")[0];
                                            TeamRow.TeamLeader = NoneContactID;
                                            //Teams.GEN_Teams.AddGEN_TeamsRow(TeamRow);     
                                        }
                                        ((Navigation.BaseObject)Session["navigation"]).TeamsWSObject.EditTeams(Teams);   
                                    }
                                    if (arrCompElements.Length > 0)
                                    {
                                        //CElements.Clear();
                                        CElements.EnforceConstraints = false;
                                        for (int i = 0; i < arrCompElements.Length; i++)
                                        {
                                            dsCompanyElements.GEN_CompanyElmentsRow CElementRow = (dsCompanyElements.GEN_CompanyElmentsRow)CElements.Tables[0].Select("CompElmentID='" + ((dsCompanyElements.GEN_CompanyElmentsRow)arrCompElements[i]).CompElmentID + "'")[0];
                                            CElementRow.ContactID = NoneContactID;
                                            //CElements.GEN_CompanyElments.AddGEN_CompanyElmentsRow(CElementRow);
                                        }
                                        ((Navigation.BaseObject)Session["navigation"]).CompanyWsObject.ModifyCompanyElemenets(CElements);                      
                                    }
                                    row.EmployeeStatus = 0;
                                    row.EmpTerminationDate = DateTime.Now;
                                }
                            }
                            row.FirstName = txtFName.Text.Trim();
                            row.MiddleName = txtMName.Text.Trim();
                            row.LastName = txtLName.Text.Trim();
                            row.Fullname = txtFName.Text.Trim() + " " + txtMName.Text.Trim() + " " + txtLName.Text.Trim();
                            row.JobTitleID = int.Parse(lstJobTitles.SelectedValue);
                            row.CompElmentID = int.Parse(lstCompElements.SelectedValue);
                            row.EmpCode = txtCode.Text.Trim();
                            if (!String.IsNullOrEmpty(txtHDate.Text))
                            {
                                row.EmpHireDate = DateTime.Parse(txtHDate.Text);
                            }
                            if (!String.IsNullOrEmpty(txtTDate.Text) && row.EmployeeStatus == 0)
                            {
                                row.EmpTerminationDate = DateTime.Parse(txtTDate.Text);
                            }
                            if (lstUserName.SelectedIndex != 0)
                            {
                                row.UserID = int.Parse(lstUserName.SelectedValue);
                                bool Added = false;
                                Added = ((Navigation.BaseObject)Session["navigation"]).SecurityWsObject.AddUserToGroup(1, row.UserID);
                                Added = false;
                            }
                            ((Navigation.BaseObject)Session["navigation"]).EmployeeWsObject.ModifyEmployee(dsEmployee);
                            // save employee image
                            saveEmpPhoto(empID);
                            //load emp data
                            btnFind_Click(null, null);
                            grdEmployees.SelectedIndex = 0;
                            OnSelect(null, null);
                            filter = "";
                            //hdnResetImage.Value = "";
                            hdnResetImage.Value = "";
                            lblRsltCount.Text = "Employee Updated";
                            if (!grdEmployees.Visible)
                            {
                                clearForm();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                    // TODO : Handling exception
                }
            }
        }

        public bool CheckJobTitleByName(TSN.ERP.SharedComponents.Data.dsJobtitles ds, string NewJobTitleName)
        {
            bool flag = true;
            foreach (DataRow dr in ds.Tables["GEN_JobTitles"].Rows)
            {
                flag = true;
                if (dr["JobName"].ToString().Trim().ToLower() == NewJobTitleName.Trim().ToLower())
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

        public bool IsElementExist(TSN.ERP.SharedComponents.Data.dsCompanyElements ds, string ElementName)
        {
            bool Flage = false;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr[4].ToString().ToLower() == ElementName.ToLower())
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
        public bool IsUserExists(string UserName)
        {
            bool Flag = false;
            SecurityWS.SecurityManagement secMang = ((Navigation.BaseObject)Session["navigation"]).SecurityWsObject;
            DataSet dsUsers = secMang.GetAllUsers();
            foreach (DataRow dr in dsUsers.Tables[0].Rows)
            {
                if (dr["UserName"].ToString().Trim() == UserName)
                {
                    Flag = true;
                    break;
                }
            }
            return Flag;

        }
		#endregion
		//------------------------------------------------------------------
		#region add new employee
		protected void btnNew_Click(object sender, ImageClickEventArgs e)
		{
			if(Page.IsValid)
			{
				lnkShowPhoto.Enabled = false;
				pnlPhoto.Visible = false;
				try
				{
					// Firstly, validate user input
					if ( ValidateForm("add"))
					{
				
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
                        {
                            row.UserID = int.Parse(lstUserName.SelectedValue);
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(txtNewUserName.Text) && !String.IsNullOrEmpty(txtNewPassword.Text))
                            {
                                SecurityWS.SecurityManagement secMang = ((Navigation.BaseObject)Session["navigation"]).SecurityWsObject;
                                int newUserID = secMang.AddUser(txtNewUserName.Text.Trim(), txtNewPassword.Text, false, "");
                                if (newUserID == -1)
                                {
                                    tblErr.Visible = true;
                                    tblErr.Rows[0].Cells[1].Text = "This user name already exists , please try another one";
                                    ViewState["ShowNewUserPassword"] = "Show";
                                    return;
                                }
                                else
                                {
                                    //DataSet dsUsers = secMang.GetAllUsers();
                                    //DataRow drUser = dsUsers.Tables[0].Select("UserName='" + txtNewUserName.Text + "'")[0];
                                    //int NewUserID = Convert.ToInt32(drUser["UserID"]);
                                    row.UserID = newUserID;
                                }
                            }
                            else if ((String.IsNullOrEmpty(txtNewUserName.Text) && !String.IsNullOrEmpty(txtNewPassword.Text)) || (!String.IsNullOrEmpty(txtNewUserName.Text) && String.IsNullOrEmpty(txtNewPassword.Text)))
                            {
                                tblErr.Visible = true;
                                tblErr.Rows[0].Cells[1].Text = "You must type user name and password altogether";
                                ViewState["ShowNewUserPassword"] = "Show";
                                return;
                            }
                            //else
                            //{
                            //    row.UserID = DBNull.Value;
                            //}
                        }
                        if (!String.IsNullOrEmpty(txtHDate.Text))
                        {
                            row.EmpHireDate = Convert.ToDateTime(txtHDate.Text);
                        }
						dsEmployee.GEN_Employees.AddGEN_EmployeesRow(row);
						// insert new employee
					
						((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.AddEmployees(dsEmployee);
						btnFind_Click(null,null);
						clearForm();
						lblRsltCount.Text = "New employee inserted.";	

						CheckButtonVisibilty();
					    btnUpdate.Visible=  false;
						lnkJobTitle.Visible = false;

                        lblNewUserName.Visible = false;
                        lblNewPassword.Visible = false;
                        txtNewUserName.Visible = false;
                        txtNewPassword.Visible = false;

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
		private bool ValidateForm(string action)
		{
			// flag to indicate if the selected user name is reserved or not
			bool unassignedUser = false; 
			bool AddFlag = true;
			bool EditFlag = true;
			string msg="";
			int empID;
			TSN.ERP.SharedComponents.Data.dsEmployee dsAllEmployeesAdd = new TSN.ERP.SharedComponents.Data.dsEmployee();
			TSN.ERP.SharedComponents.Data.dsEmployee dsAllEmployees = new TSN.ERP.SharedComponents.Data.dsEmployee();

			resetColors();

			Regex reg = new Regex(@"[^a-zA-Z\s]");
			Match match = reg.Match(txtFName.Text.Trim());
			int picfilelength = 0;
			string picextention="";
			
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
			if(fileEmp.PostedFile!=null && fileEmp.PostedFile.FileName.Trim().Length!=0)
			{
				picfilelength = fileEmp.PostedFile.FileName.Length;
				picextention = fileEmp.PostedFile.FileName.Substring(picfilelength-3,3);
				if(picextention.ToLower() == "gif" ||picextention.ToLower() == "jpg")
				{
					//fileEmp.b = Color.LightYellow;
				}
				else
				{
					msg = msg + "<li>Please select employee image with extension gif or jpg </li>" ;
					fileEmp.Style["background"] = "lightyellow";

				}
				if(fileEmp.PostedFile.ContentLength > 102400)
				{					
					msg += "<li>Image size must not exceed 100k.</li>";
					fileEmp.Style["background"] = "lightyellow";
				}
			}
			if(action=="add")
			{
				Navigation.BaseObject.SafeMerge(dsAllEmployeesAdd,((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListEmployeesDetailedData());	
				 AddFlag = CheckEmployeeCodeForAdd(dsAllEmployeesAdd,txtCode.Text.Trim());
				if(AddFlag == false )
				{
					msg = msg +"<li>This Employee Number already Exist Please try another number</li>";
					txtCode.BackColor = Color.LightYellow;
				}
			}
			if(action=="edit")
			{
				Navigation.BaseObject.SafeMerge(dsAllEmployees,((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListEmployeesDetailedData());	
				empID= int.Parse(grdEmployees.Items[grdEmployees.SelectedIndex].Cells[1].Text);
				EditFlag = CheckEmployeeCodeForUpdate(dsAllEmployees,txtCode.Text.Trim(),empID);
				if(EditFlag==false)
				{
					msg = msg +"<li>This Employee Number already Exist Please try another number</li>";
						txtCode.BackColor = Color.LightYellow;
				}

			}

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
//            int empID ;
//            lnkShowPhoto.Enabled = false;
//            pnlPhoto.Visible = false;
//            TSN.ERP.SharedComponents.Data.dsEmployee.GEN_EmployeesRow row;
//            try
//            {
//                empID= int.Parse(grdEmployees.Items[grdEmployees.SelectedIndex].Cells[1].Text);
//                dsEmployee.Clear();
//                Navigation.BaseObject.SafeMerge(dsEmployee,((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListSingleEmployeeData(empID));
//                row= (TSN.ERP.SharedComponents.Data.dsEmployee.GEN_EmployeesRow)dsEmployee.Tables[0].Rows[0];
//                if (btnTerminate.Text== "Activate")
//                {
//                    DataSet DSTempJobTitles = (DataSet)ViewState["DSTempJobTitles"];
//                    DataRow DRJobTitle = DSTempJobTitles.Tables[0].Rows.Find(row.JobTitleID);
//                    if(!Convert.ToBoolean(DRJobTitle["IsActive"]))
//                    {
//                        tblErr.Rows[0].Cells[1].Text = "<p><ul><li>Employee can not be activated as long as his job title is terminated, change his job title or activate the current job title.</li></ul></p>" ;
//                        tblErr.Visible = true;
//                        return ;
//                    }
//                    row.EmployeeStatus = 1;
//                    row["EmpTerminationDate"] = DBNull.Value;
//                    //row.EmpTerminationDate = DBNull.Value;
//                }
//                else
//                {
//                    TSN.ERP.SharedComponents.Data.dsTeams Teams = new TSN.ERP.SharedComponents.Data.dsTeams();
//                    TSN.ERP.SharedComponents.Data.dsProjects Projects = new TSN.ERP.SharedComponents.Data.dsProjects();
//                    TSN.ERP.SharedComponents.Data.dsCompanyElements CElements =new TSN.ERP.SharedComponents.Data.dsCompanyElements();
//                    Navigation.BaseObject.SafeMerge(Teams,((Navigation.BaseObject) Session[ "navigation" ]).TeamsWSObject.ListTeams());
//                    Navigation.BaseObject.SafeMerge(Projects,((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.ListAllProjects());
//                    Navigation.BaseObject.SafeMerge(CElements,((Navigation.BaseObject) Session[ "navigation" ]).CompanyWsObject.ListCompnayElements());

//                    DataRow[] arrTeams=Teams.Tables[0].Select("TeamLeader='"+empID+"'");
//                    DataRow[] arrProjects=Projects.Tables[0].Select("ProjectManager='"+empID+"' AND ProjectStatus=1");
//                    DataRow[] arrCelements=CElements.Tables[0].Select("ContactID='"+empID+"'");

//                    if(arrTeams.Length == 0 && arrProjects.Length == 0 && arrCelements.Length == 0)
//                    {
//                        row.EmployeeStatus = 0;
//                        row.EmpTerminationDate = DateTime.Now;
//                    }
//                    else
//                    {
//                        tblErr.Rows[0].Cells[1].Text = "<p><ul><li>Employee can not be terminated.</li></ul></p>" ;
//                        tblErr.Visible = true;
//                        return ;
//                    }
//                }
				
//                ((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ModifyEmployee(dsEmployee);
//                lblRsltCount.Text = "Employee Updated";
//                BindEmployee( "" );
////				string x=this.ToString();
////				string y=x.Remove(0,4);
////				string z=y.Remove(y.Length-5,5)+".ascx";
////				string goUrl="Go/"+z;
////				http://localhost/ERP/AccGui/Navigation/ContentPage.aspx?uc=Go/ctlEmployeeMain.ascx&hid=3
//                Response.Redirect("ContentPage.aspx?uc=Go/ctlEmployeeMain.ascx&hid=3");
//                //grdEmployees.Visible = false;
//            }
//            catch(Exception ex)
//            {
//                Response.Write(ex.Message);
//                // TODO : Handling exception
//            }
//            finally
//            {
//                btnTerminate.Enabled = false;
//            }
		}	
		#endregion
		//------------------------------------------------------------------
		#region hide address and phone panels
		private void showAddressPhone(bool val)
		{
			lblCountry.Visible = val;
			lblCity.Visible = val;
			lblPhone.Visible = val;
			lblEmail.Visible = val;
            lblEmailInternal.Visible = val;
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
			txtEmail.Visible = val;
            txtEmailInternal.Visible = val;
			lnkAddress.Visible = val;
			lnkPhone.Visible = val;
			lnkEmail.Visible = val;
			lnkJobTitle.Visible = val;
            //divHiringDate.Visible = val;
            //divHiringDate2.Visible = val;
		}
		#endregion
		//------------------------------------------------------------------
		#region view total accountability sheet
		protected void btnTotalSheet_Click(object sender, ImageClickEventArgs e)
		{
			filter = "GEN_Employees.ContactID = '"+Session["contactID"]+"'";
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

				//Sort Users DataSet//////////////////////////////////
				DataView dvUser = dsUser.Tables[0].DefaultView;
				dvUser.Sort = "UserName";
				dsUser.Tables.Clear();
				dsUser.Tables.Add(master.CreateTableFromView(dvUser));
				//////////////////////////////////////////////////////////
				///

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
				//Sort Users DataSet//////////////////////////////////
				DataView dvUser = dsUnassignedUsers.Tables[0].DefaultView;
				dvUser.Sort = "UserName";
				dsUnassignedUsers.Tables.Clear();
				dsUnassignedUsers.Tables.Add(master.CreateTableFromView(dvUser));
				//////////////////////////////////////////////////////////
				///
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
            // the following line commented by Sayed to fix error, where the follwoing line was display html during running  
            //Response.ContentType="image/JPEG";
         
			string imgContentType; 
			int imgLen ;
	

			if (fileEmp.PostedFile != null)
			{
				if (fileEmp.PostedFile.FileName.Trim().Length > 0 && fileEmp.PostedFile.ContentLength > 0 )
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
					int fileID ;
//					DataSet tmp =  ((Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.LastDataSet();
//
//					if(tmp==null)
//					{
						if(Session["FileID"].ToString()!="")
						{
                         fileID=Convert.ToInt32(Session["FileID"]);
						}
						else
						{
							fileID=((Navigation.BaseObject) Session[ "navigation" ]).GeneralWSObject.mGetMaxFileID();

						}
						Session["FileID"] =fileID;
//						Navigation.BaseObject.SafeMerge(dsEmployee,((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListSingleEmployeeData(ContactID));
//						// save photo file id in a session
//						Session["FileID"] = dsEmployee.Tables[0].Rows[0]["FileID"].ToString();
//						fileID=Convert.ToInt32(Session["FileID"]);
//					}
//					
//					else 
//						fileID = int.Parse(tmp.Tables[0].Rows[0]["FileID"].ToString());
					
					//save image
                    // added By sayed 21-2-2010
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(imgBinaryData);
                         System.Drawing.Bitmap bmp = ResizeImage(ms, 100, 134);
                        //Bitmap bmp = fc.CreateBmpFromChart();

                        System.IO.MemoryStream stream2 = new System.IO.MemoryStream();

                        //// Save image to stream.
                        bmp.Save(stream2, System.Drawing.Imaging.ImageFormat.Jpeg);

                        imgBinaryData = stream2.ToArray();
                    // END 21-2-2010
					((Navigation.BaseObject) Session[ "navigation" ]).GeneralWSObject.UpdateFileContent(fileID,imgBinaryData);
					// bind this file to employee
					dsEmployee.Clear();
					Navigation.BaseObject.SafeMerge(dsEmployee,((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListSingleEmployeeData(ContactID));
					dsEmployee.Tables[0].Rows[0]["FileID"] = fileID;
					((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ModifyEmployee(dsEmployee);
				}
				else
				{
					if(hdnResetImage.Value=="yes")
					{
						if(Session["FileID"].ToString()!="")
						{
				
							//int ContactID = int.Parse(Session["contactID"].ToString());
							// bind this file to employee
							dsEmployee.Clear();
							Navigation.BaseObject.SafeMerge(dsEmployee,((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListSingleEmployeeData(ContactID));
							dsEmployee.Tables[0].Rows[0]["FileID"] =System.DBNull.Value;
							((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ModifyEmployee(dsEmployee);
							//delete the file from the Gen_files table
							dsFilesInfo.EnforceConstraints = false;
							DataRow drFileInfo = dsFilesInfo.GEN_Files.NewGEN_FilesRow();
							drFileInfo["FileID"] = int.Parse(Session["FileID"].ToString());
							dsFilesInfo.Tables[0].Rows.Add(drFileInfo);
							dsFilesInfo.AcceptChanges();
							drFileInfo = dsFilesInfo.GEN_Files.FindByFileID( int.Parse(Session["FileID"].ToString()) );
							drFileInfo.Delete();
							((Navigation.BaseObject) Session[ "navigation" ]).GeneralWSObject.DeleteFileInfo(dsFilesInfo);


						}
					}
				}
				
			}
            // added by Sayed 20/7/2010
            if (fileEmpHR.PostedFile != null)
            {
                if (fileEmpHR.PostedFile.FileName.Trim().Length > 0 && fileEmpHR.PostedFile.ContentLength > 0)
                {
                    Stream imgStream = fileEmpHR.PostedFile.InputStream;
                    imgLen = fileEmpHR.PostedFile.ContentLength;
                    imgContentType = fileEmpHR.PostedFile.ContentType;
                    byte[] imgBinaryData = new byte[imgLen];
                    imgStream.Read(imgBinaryData, 0, imgLen);

                    // add file info
                    dsFilesInfo.EnforceConstraints = false;
                    DataRow drFileInfo = dsFilesInfo.GEN_Files.NewGEN_FilesRow();
                    drFileInfo["FileID"] = 100000;
                    drFileInfo["FileName"] = "";
                    drFileInfo["FileSize"] = "";
                    drFileInfo["FileType"] = "";
                    dsFilesInfo.Tables[0].Rows.Add(drFileInfo);
                    ((Navigation.BaseObject)Session["navigation"]).GeneralWSObject.AddFileInfo(dsFilesInfo);
                    // get inserted file id
                    int fileID;
                   
                    if (Session["FileIDHR"].ToString() != "")
                    {
                        fileID = Convert.ToInt32(Session["FileIDHR"]);
                    }
                    else
                    {
                        fileID = ((Navigation.BaseObject)Session["navigation"]).GeneralWSObject.mGetMaxFileID();

                    }
                    Session["FileIDHR"] = fileID;
                    

                    //save image
                    // added By sayed 21-2-2010
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imgBinaryData);
                    
                    imgBinaryData = ms.ToArray();
                    
                    ((Navigation.BaseObject)Session["navigation"]).GeneralWSObject.UpdateFileContent(fileID, imgBinaryData);
                    // bind this file to employee
                    dsEmployee.Clear();
                    Navigation.BaseObject.SafeMerge(dsEmployee, ((Navigation.BaseObject)Session["navigation"]).EmployeeWsObject.ListSingleEmployeeData(ContactID));
                    dsEmployee.Tables[0].Rows[0]["FileIDHR"] = fileID;
                    ((Navigation.BaseObject)Session["navigation"]).EmployeeWsObject.ModifyEmployee(dsEmployee);
                    btnDownload.Visible = true;
                }
                else
                {
                    if (hdnResetImageHR.Value == "yes")
                    {
                        if (Session["FileIDHR"].ToString() != "")
                        {

                            //int ContactID = int.Parse(Session["contactID"].ToString());
                            // bind this file to employee
                            dsEmployee.Clear();
                            Navigation.BaseObject.SafeMerge(dsEmployee, ((Navigation.BaseObject)Session["navigation"]).EmployeeWsObject.ListSingleEmployeeData(ContactID));
                            dsEmployee.Tables[0].Rows[0]["FileIDHR"] = System.DBNull.Value;
                            ((Navigation.BaseObject)Session["navigation"]).EmployeeWsObject.ModifyEmployee(dsEmployee);
                            //delete the file from the Gen_files table
                            dsFilesInfo.EnforceConstraints = false;
                            DataRow drFileInfo = dsFilesInfo.GEN_Files.NewGEN_FilesRow();
                            drFileInfo["FileID"] = int.Parse(Session["FileIDHR"].ToString());
                            dsFilesInfo.Tables[0].Rows.Add(drFileInfo);
                            dsFilesInfo.AcceptChanges();
                            drFileInfo = dsFilesInfo.GEN_Files.FindByFileID(int.Parse(Session["FileIDHR"].ToString()));
                            drFileInfo.Delete();
                            ((Navigation.BaseObject)Session["navigation"]).GeneralWSObject.DeleteFileInfo(dsFilesInfo);
                            btnDownload.Visible = false;


                        }
                    }
                }

            }
            // end 20/7/2010
		}
		#endregion
		//-------------------------------------------------------------------
		#region view photo link
		/// <summary>
		/// Show employee's personal photo
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void lnkShowPhoto_Click(object sender, ImageClickEventArgs e)
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
            if (Session["FileIDHR"].ToString() != "")
            {
                btnDownload.Visible = true;
               // imgEmpHR.Src = "../go/frmEmpImg2.aspx";
            }
            else
            {
                btnDownload.Visible = false;
               // imgEmpHR.Src = "../go/images/dummy.bmp";
            }
		}
		#endregion	

		//-------------------------------------------------------------------

		#region CheckButtonVisibilty
		
		void CheckButtonVisibilty()
		{
			ArrayList arrRules = new ArrayList();
			bool visibililty = true;

			// check edit employee buttons
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

			// check change jobtitle button
			arrRules.Clear();

			arrRules.Add( 5004 );
			visibililty = ((Navigation.BaseObject) Session[ "navigation" ]).CheckUserAccessRule( arrRules );
			lnkJobTitle.Visible	= visibililty;

		}
		#endregion 
        public System.Drawing.Bitmap ResizeImage(System.IO.Stream streamImage, int maxWidth, int maxHeight)
        {
            System.Drawing.Bitmap originalImage = new Bitmap(streamImage);
            int newWidth = originalImage.Width;
            int newHeight = originalImage.Height;
            double aspectRatio = Convert.ToDouble(originalImage.Width) / Convert.ToDouble(originalImage.Height);


            if (aspectRatio <= 1 && originalImage.Width > maxWidth)
            {
                newHeight = maxHeight;
                newWidth = Convert.ToInt32(Math.Round(newHeight * aspectRatio));
            }
            else
                if (aspectRatio > 1 && originalImage.Height > maxHeight)
                {
                    newWidth = maxWidth;
                    newHeight = Convert.ToInt32(Math.Round(newWidth / aspectRatio));

                }

            System.Drawing.Bitmap newImage = new Bitmap(originalImage, newWidth, newHeight);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(newImage);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            g.DrawImage(originalImage, 0, 0, newImage.Width, newImage.Height);
            originalImage.Dispose();

            return newImage;
        } 

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

		protected void btnDeletePic_Click(object sender, System.EventArgs e)
		{
			hdnResetImage.Value = "yes";
			//set the no pic 
			imgEmp.Src = "images/dummy.bmp";

			
		}

		protected void lstCompElements_DataBinding(object sender, System.EventArgs e)
		{
			//Sort Company Elements DataSet//////////////////////////////////
			DataView dvCE = dsCompElements.GEN_CompanyElments.DefaultView;
			dvCE.Sort = "CEName";
			dsCompElements.Tables.Clear();
			dsCompElements.Tables.Add(master.CreateTableFromView(dvCE));
			//////////////////////////////////////////////////////////
		}

		protected void lstUserName_DataBinding(object sender, System.EventArgs e)
		{
			Navigation.BaseObject.SafeMerge(dsUser,((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.GetAllNonAssignedUsers());

			//Sort Users DataSet//////////////////////////////////
			DataView dvUser = dsUser.Tables[0].DefaultView;
			dvUser.Sort = "UserName";
			dsUser.Tables.Clear();
			dsUser.Tables.Add(master.CreateTableFromView(dvUser));
			//////////////////////////////////////////////////////////
		}

		protected void lstJobTitles_DataBinding(object sender, System.EventArgs e)
		{
			//Sort Job Titles DataSet//////////////////////////////////
			DataView dvJT = dsJobTitles.GEN_JobTitles.DefaultView;
			dvJT.Sort = "JobName";
			dsJobTitles.Tables.Clear();
			dsJobTitles.Tables.Add(master.CreateTableFromView(dvJT));
			//////////////////////////////////////////////////////////
		}
        // added by Sayed 27/8/2009
        private void GetUserEmail(int contactID)
        {
            DataSet dsEmail1 = new DataSet();
            Navigation.BaseObject.SafeMerge(dsEmail1, ((Navigation.BaseObject)Session["navigation"]).ContactWsObject.ListAllCotactEmails(contactID));
            if (dsEmail1.Tables[0].Rows.Count > 0)
            {
                /*  before internal and external 
                 
                 string mailingType = System.Configuration.ConfigurationSettings.AppSettings["MailingType"];
                 DataRow[] Mails = dsEmail1.Tables[0].Select("EmailType=" + mailingType + "");
                 
               */

                DataRow[] MailsExternal = dsEmail1.Tables[0].Select("EmailType=1");
                DataRow[] MailsInternal = dsEmail1.Tables[0].Select("EmailType=0");
                //before internal and external 
                //if (mailingType == "0")//Internal
                //{
                    if (MailsInternal.Length > 0)
                    {

                        txtEmailInternal.Text = MailsInternal[0]["ContactEmail"].ToString().Trim();
                    }
                    else
                    {
                        txtEmailInternal.Text = String.Empty;
                    }
                //}
                //before internal and external 
                //else if (mailingType == "1")//External
                //{
                    if (MailsExternal.Length > 0)
                    {
                        txtEmail.Text = MailsExternal[0]["ContactEmail"].ToString().Trim();
                    }
                    else
                    {
                        txtEmail.Text = String.Empty;
                    }
                //}
            }
            else
            {
                txtEmail.Text = String.Empty;
                txtEmailInternal.Text = String.Empty;
            }
        }

        protected void btnDeletePicHR_Click(object sender, EventArgs e)
        {
            hdnResetImageHR.Value = "yes";
            //set the no pic 
            imgEmpHR.Src = "images/dummy.bmp";
        }
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                System.Text.UTF7Encoding utf = new System.Text.UTF7Encoding();
                string FileID = Session["FileIDHR"].ToString();

                if (FileID != "")
                {
                    byte[] tempbuffer = ((Navigation.BaseObject)Session["navigation"]).GeneralWSObject.LoadFileBody(int.Parse(FileID));
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(tempbuffer);

                    //***********/
                    byte[] imgBinary = ms.ToArray();
                    byte[] rep = imgBinary;
                    Page.Response.AddHeader("Content-Disposition", "attachment;filename=" +txtFName.Text+txtMName.Text+txtLName.Text + ".Jpeg");
                    Page.Response.AddHeader("Content-Length", rep.Length.ToString());
                    Page.Response.ContentType = "application/octet-stream";
                    Page.Response.Buffer = true;

                    //Displaying a dialog taht will ask user to open file or even to download it locally on hard disk
                    Page.Response.BinaryWrite(rep);
                    //Flushing all data after downloading it
                    Page.Response.Flush();
                    Page.Response.Close();
                    Page.Response.End();
                    return;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }
}
}
