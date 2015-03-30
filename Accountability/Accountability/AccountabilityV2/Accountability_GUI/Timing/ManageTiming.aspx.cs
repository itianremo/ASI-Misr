using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;  
using System.Configuration;
using System.Reflection;
using System.Net.Mail;

namespace TSN.ERP.WebGUI.Timing
{
	/// <summary>
	/// Summary description for frmEmpPhone.
	/// </summary>
	public partial class ManageTiming : System.Web.UI.Page
	{
		
		//		private static int contactID;

		#region page load
		protected void Page_Load(object sender, System.EventArgs e)
		{

			lblNote.Visible=false;
			if(!IsPostBack)
			{
                FreeTextBoxControls.NetSpell netSpell = new FreeTextBoxControls.NetSpell();
                try   // added to avoid error of IE8 with freetextbox control
                {
                    FreeTextBox1.Toolbars[3].Items.Add(netSpell);
                }
                catch { }

				txtDate.Text = DateTime.Now.ToShortDateString();
                txtDay.Text = Convert.ToDateTime(txtDate.Text).DayOfWeek.ToString();
				txtDate.Attributes.Add("readonly","true");
//				ImageButton1.Attributes.Add("readonly","true");
                DataSet dsAllEmployees = ((Navigation.BaseObject)Session["navigation"]).EmployeeWsObject.ListEmployees();
                if (dsAllEmployees.Tables.Count != 0)
                {
                    ViewState["dsAllEmployees"] = dsAllEmployees;
                }

				#region Fill Employees DropDownList
                try
                {
					DataSet dsEmployee =  ((Navigation.BaseObject)Session["navigation"]).AccountabilityWSObject.ViewAccountabilityEmployees();
					DataView dvEmp = dsEmployee.Tables[0].DefaultView;
					dvEmp.RowFilter = "EmployeeStatus = 1";	
					dvEmp.Sort = "FirstName, MiddleName, LastName";
					dsEmployee.Tables.Clear();
					dsEmployee.Tables.Add(CreateTable(dvEmp));	
								
					ddlEmployees.DataTextField="Fullname";
					ddlEmployees.DataValueField="ContactID";
					ddlEmployees.DataSource=dsEmployee;
					ddlEmployees.DataBind();
				

				int ContactID = -1;
				try
				{
					ContactID=Convert.ToInt32(Session["CurrentEmployee"]);
					ddlEmployees.SelectedValue = ContactID.ToString();
                    //GetEmpData(ContactID);
				}
				catch(Exception ex)
				{
                    Response.Write(ex.Message);
				}

                #endregion
                if (ddlEmployees.Items.Count > 0)
                {
                    GetEmpData(Convert.ToInt32(ddlEmployees.SelectedValue));
                }

//				Calendar1.Visible=false;
		
				if(dsEmployee.Tables[0].Rows.Count==0)
				{
					tnAddRecord.Enabled=false;
					ImageButton2.Visible=false;
					return;
				}
				else
				{
					tnAddRecord.Enabled=true;
					ImageButton2.Visible=true;
				}
				#region Bind Grid	
                if (ddlEmployees.Items.Count > 0)
                {
                    FillDataSet();
                }
				#endregion


                try
                {
                    BindMailsGrid();
                    ////////////////////DataSet dsContactsAndEmails = new DataSet();
                    ////////////////////string mailingType = System.Configuration.ConfigurationSettings.AppSettings["MailingType"];
                    ////////////////////if (mailingType == "0")//Internal
                    ////////////////////{
                    ////////////////////    Navigation.BaseObject.SafeMerge(dsContactsAndEmails, ((Navigation.BaseObject)Session["navigation"]).ContactWsObject.ListCotactsAndEmails(0));
                    ////////////////////}
                    ////////////////////else if (mailingType == "1")//External
                    ////////////////////{
                    ////////////////////    Navigation.BaseObject.SafeMerge(dsContactsAndEmails, ((Navigation.BaseObject)Session["navigation"]).ContactWsObject.ListCotactsAndEmails(1));
                    ////////////////////}
                    ////////////////////else if (mailingType == "2")//Private
                    ////////////////////{
                    ////////////////////    Navigation.BaseObject.SafeMerge(dsContactsAndEmails, ((Navigation.BaseObject)Session["navigation"]).ContactWsObject.ListCotactsAndEmails(2));
                    ////////////////////}
                    ////////////////////else if (mailingType == "-1")//Get All mails
                    ////////////////////{
                    ////////////////////    Navigation.BaseObject.SafeMerge(dsContactsAndEmails, ((Navigation.BaseObject)Session["navigation"]).ContactWsObject.ListCotactsAndEmails(-1));
                    ////////////////////}
                    ////////////////////Session["dsContactsAndEmails"] = dsContactsAndEmails;
                    ////////////////////dgEmails.DataSource = dsContactsAndEmails;
                    ////////////////////dgEmails.DataBind();
                    //////////////////////					RegisterClientScriptBlock("dfd","<script>drawGrid("+dgEmails+")</script>");
                    //////////////////////divPanel.Visible=false;
                    txtboxSubject.Text = "Edited Time Clock Entries. <" + DateTime.Now.ToString("d") + ">";
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error to connect Timing Web Services " + ex.Message);
            }
//				if(dgTiming.Items.Count == 0)
//				{
//					dgTiming.Visible = false;
//				}
//				else
//				{
//					dgTiming.Visible = true;
//				}               
			}
            int contactID = Convert.ToInt32(Session["CurrentEmployee"]);
            GetTotalCheckInHours(contactID, DateTime.Now);
			
		}
		#endregion

        private decimal GetTotalCheckInHours(int contactID, DateTime date)
        {
            contactID = int.Parse(ddlEmployees.SelectedValue.ToString());
            date = DateTime.Parse(txtDate.Text);
            decimal total = 0;
            EAMWS.TimingWS EAM = new TSN.ERP.WebGUI.EAMWS.TimingWS();
            try
            {
                total = EAM.GetTotalCheckInTime(contactID, date);
            }
            catch (Exception ex)
            {
               // Response.Write("Error calculating total check in time : " + ex.Message);
                total = 0;
            }
            finally
            {
                lblTotalCheckInTime.Text = total.ToString();
            }
            return total;
        }
        private void GetEmpData(int ContactID)
        {
            //Get Employee Number
            DataSet EmpSet = ((Navigation.BaseObject)Session["navigation"]).EmployeeWsObject.ListSingleEmployeeData(ContactID);      
            txtEmployeeNumber.Text = EmpSet.Tables[0].Rows[0]["EmpCode"].ToString().Trim();
            string compElmentID = EmpSet.Tables[0].Rows[0]["compElmentID"].ToString().Trim();

            //Get Exempt and Shift
            EAMWS.TimingWS EAM = new TSN.ERP.WebGUI.EAMWS.TimingWS();
            DataSet dsShifts = EAM.GetAllTimingShifts();
            ddlShift.DataSource = dsShifts;
            ddlShift.DataBind();

            DataSet dsShiftExempted = EAM.GetEmployeeShiftExempted(ContactID);
            if (dsShiftExempted.Tables[0].Rows.Count > 0)
            {
                if (dsShiftExempted.Tables[0].Rows[0]["ShiftID"].ToString() != "")
                {
                    ddlShift.SelectedValue = dsShiftExempted.Tables[0].Rows[0]["ShiftID"].ToString();
                }

                if (dsShiftExempted.Tables[0].Rows[0]["Exempted"].ToString() != "")
                {
                    ddlExempt.SelectedValue = dsShiftExempted.Tables[0].Rows[0]["Exempted"].ToString();
                }
            }

            //Get Department and Manager
            DataSet dsDept = ((Navigation.BaseObject)Session["navigation"]).CompanyWsObject.ListCompnayElements();
            try
            {
                string DeptName = dsDept.Tables[0].Select("CompElmentID=" + compElmentID + "")[0]["CEName"].ToString().Trim();
                txtDepartment.Text = DeptName;
            }
            catch
            {
                txtDepartment.Text = String.Empty;
            }
            //
            DataView view = new DataView(dsDept.Tables[0]);
            view.Sort = "CompElmentID";

            int rowIndex = view.Find(compElmentID);
            if (rowIndex != -1)
            {
                string vsManagerContactID = view[rowIndex]["ContactID"].ToString();
                // Handle if the Employee has no manager //
                if (vsManagerContactID == "")
                {
                    vsManagerContactID = "-1000";
                }

                //

                DataSet ManagerSet = ((Navigation.BaseObject)Session["navigation"]).EmployeeWsObject.ListSingleEmployeeData(Convert.ToInt32(vsManagerContactID));
                try
                {
                    string DeptManager = ManagerSet.Tables[0].Rows[0]["Fullname"].ToString().Trim();
                    txtManager.Text = DeptManager;
                }
                catch
                {
                    txtManager.Text = String.Empty;
                }
            }


        }
		//------------------------------------------------------------
		//------------------------------------------------------------
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
			this.ImageButton2.Click += new System.Web.UI.ImageClickEventHandler(this.ImageButton2_Click);
			this.dgTiming.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgTiming_ItemCreated);
			this.dgTiming.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTiming_ItemCommand);
			this.dgTiming.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTiming_CancelCommand);
			this.dgTiming.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTiming_EditCommand);
			this.dgTiming.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTiming_UpdateCommand);
			this.dgTiming.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgTiming_ItemDataBound);

		}
		#endregion	
		//------------------------------------------------------------
		# region create a table from dataview
		/// <summary>
		/// Convert given dataview to datatable
		/// </summary>
		/// <param name="obDataView"></param>
		/// <returns></returns>
		public static DataTable CreateTable(DataView obDataView)
		{
			if (null == obDataView)
			{
				throw new ArgumentNullException
					("DataView", "Invalid DataView object specified");
			}


		
			///********* End of Enhance Performance by SM ****************///
			//						DataTable obNewDt = obDataView.Table;

			///********* End of Enhance Performance by SM ****************///
			
			

			///********* Old Code ****************///
			DataTable obNewDt = obDataView.Table.Clone();
			int idx = 0;
			string [] strColNames = new string[obNewDt.Columns.Count];
			foreach (DataColumn col in obNewDt.Columns)
			{
				strColNames[idx++] = col.ColumnName;
			}

			IEnumerator viewEnumerator = obDataView.GetEnumerator();
			while (viewEnumerator.MoveNext())
			{
				DataRowView drv = (DataRowView)viewEnumerator.Current;
				DataRow dr = obNewDt.NewRow();
				try
				{
					foreach (string strName in strColNames)
					{
						dr[strName] = drv[strName];
					}
				}
				catch (Exception ex)
				{
					
				}
				obNewDt.Rows.Add(dr);
			}
			///*************** End of Old Code **************************//

			return obNewDt;
		}
		#endregion
		//------------------------------------------------------------
		#region Bind DataGrid
//		private void BindGrid(int ContactID, DateTime BindDate)
//		{
//			EAMWS.TimingWS EAM = new TSN.ERP.WebGUI.EAMWS.TimingWS();
//			DataSet ds = EAM.GetEmployeeAttendance(ContactID, BindDate);
//			dgTiming.DataSource=ds;
//			dgTiming.DataBind();
//		}
		#endregion

		private void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
////////////////////			Response.Redirect("../Navigation/ContentPage.aspx?uc=go/ReportWriter.ascx");
//////////////////////////////////////////////			Response.Write("Hi Man, It Has Been Done");
		}

		protected void ddlEmployees_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillDataSet();
            GetEmpData(Convert.ToInt32(ddlEmployees.SelectedValue));
            int contactID = Convert.ToInt32(ddlEmployees.SelectedValue);
            GetTotalCheckInHours(contactID, DateTime.Now);
		}
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void bindTimingEmpData(string strDate)
        {
            // txtDate.Text = strDate;
            FillDataSet();
        }
		private DataSet FillDataSet()
		{
			EAMWS.TimingWS EAM = new TSN.ERP.WebGUI.EAMWS.TimingWS();
			DataSet ds = EAM.GetEmployeeAttendance(Convert.ToInt32(ddlEmployees.SelectedValue),Convert.ToDateTime(txtDate.Text));
			dgTiming.DataSource=ds;
			dgTiming.DataBind();

			if(dgTiming.Items.Count == 0)
			{
				dgTiming.Visible = false;
			}
			else
			{
				dgTiming.Visible = true;
			}
			return ds;
		}

        protected void dgTiming_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
			if(e.Item.ItemType==ListItemType.Item||e.Item.ItemType==ListItemType.AlternatingItem)
			{
				DropDownList ddlGridAction = ((DropDownList)e.Item.FindControl("ddlGridAction"));
				Label lblAction = ((Label)e.Item.FindControl("lblAction"));
				try
				{
					DropDownList ddlLocationI = ((DropDownList)e.Item.FindControl("ddlLocationI"));
					Label lblLocationI = ((Label)e.Item.FindControl("lblLocationI"));
					ddlLocationI.SelectedValue=lblLocationI.Text.Trim();//Location
				}
				catch(Exception ex)
				{
					string str=ex.Message;
				}
				if(lblAction.Text == "CheckIn")
				{
					ddlGridAction.SelectedValue="I";
				}
				else if(lblAction.Text=="CheckOut")
				{
					ddlGridAction.SelectedValue="O";
				}
				//				if(e.Item.ItemIndex == Convert.ToInt32(ViewState["EditIndex"]) && ViewState["arr"]!=null)
				//				{
				//					string[] arr=(string[])ViewState["arr"];
				////					DateTime previousTime = Convert.ToDateTime(arr[0]);
				//					string previousAction = arr[1];
				//					DropDownList ddlGridActionEdit = (DropDownList)e.Item.Cells[1].Controls[1];
				//					ddlGridActionEdit.SelectedValue=previousAction;
				//				}
                Label lblModifiedBy = ((Label)e.Item.FindControl("lblModifiedBy"));
                if (lblModifiedBy.Text == "0")
                {
                    lblModifiedBy.Text = String.Empty;
                }
                else
                {
                    DataSet dsAllEmployees = (DataSet)ViewState["dsAllEmployees"];
                    if (dsAllEmployees.Tables.Count != 0 && !String.IsNullOrEmpty(lblModifiedBy.Text))
                    {
                        string empName = dsAllEmployees.Tables[0].Select("ContactID=" + lblModifiedBy.Text + "")[0]["Fullname"].ToString().Trim();
                        lblModifiedBy.Text = empName;
                    }
                }

			}
			else if(e.Item.ItemType == ListItemType.EditItem)
			{
				DropDownList ddlGridAction = ((DropDownList)e.Item.FindControl("dllGridActionEdit"));
				string CheckType = dgTiming.DataKeys[e.Item.ItemIndex].ToString();
				try
				{
					DropDownList ddlLocationE = ((DropDownList)e.Item.FindControl("ddlLocationE"));
					Label lblLocationE = ((Label)e.Item.FindControl("lblLocationE"));
					ddlLocationE.SelectedValue=lblLocationE.Text.Trim();//Location
				}
				catch(Exception ex)
				{
					string str=ex.Message;
				}
				if(CheckType == "CheckIn")
				{
					ddlGridAction.SelectedValue="I";
				}
				else if(CheckType=="CheckOut")
				{
					ddlGridAction.SelectedValue="O";
				}

                Label lblModifiedBy = ((Label)e.Item.FindControl("lblModifiedBy"));
                if (lblModifiedBy.Text == "0")
                {
                    lblModifiedBy.Text = String.Empty;
                }
                else
                {
                    DataSet dsAllEmployees = (DataSet)ViewState["dsAllEmployees"];
                    if (dsAllEmployees.Tables.Count != 0 && !String.IsNullOrEmpty(lblModifiedBy.Text))
                    {
                        string empName = dsAllEmployees.Tables[0].Select("ContactID=" + lblModifiedBy.Text + "")[0]["Fullname"].ToString().Trim();
                        lblModifiedBy.Text = empName;
                    }
                }
			}
		}

        protected void dgTiming_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			dgTiming.EditItemIndex = e.Item.ItemIndex;

            //
            //Label txtTime = (Label)e.Item.Cells[2].Controls[1];
            Label lblTime = (Label)e.Item.Cells[2].FindControl("lblTimeOriginal");
			DropDownList ddlActionEdit = (DropDownList)e.Item.Cells[1].Controls[1];
			try
			{
				DropDownList ddlLocationE = (DropDownList)e.Item.Cells[0].Controls[1];//((DropDownList)e.Item.FindControl("ddlLocationE"));
				Label lblLocationE = (Label)e.Item.Cells[0].Controls[3];//((Label)e.Item.FindControl("lblLocationE"));
				ddlLocationE.SelectedValue=lblLocationE.Text.Trim();//Location
			}
			catch(Exception ex)
			{
				string str=ex.Message;
			}
			
			
			string[] arr = new string[2];
            arr[0] = lblTime.Text;
			arr[1]=ddlActionEdit.SelectedValue;
			string CheckType = dgTiming.DataKeys[e.Item.ItemIndex].ToString();
			
			ViewState["arr"]=arr;
//			string PreviousAction = dgTiming.DataKeys[e.Item.ItemIndex].
			if(CheckType == "CheckIn")
			{
				ddlActionEdit.SelectedValue="I";
			}
			else if(CheckType=="CheckOut")
			{
				ddlActionEdit.SelectedValue="O";
			}
		
//			if(CheckType == "I")
//				ddlActionEdit.Items[0].Selected=true;//.SelectedIndex=0;
//			else
//				
//				ddlActionEdit.Items[1].Selected=true;
			//ddlActionEdit.SelectedValue=CheckType;
			FillDataSet();
            Label lblEditNote = (Label)e.Item.FindControl("lblEditNote");
            FreeTextBox1.Text = lblEditNote.Text;
            pnlReason.Visible = true;
            lblEmailConfirm.Visible = false;
            GetLoggedUserEmail();

            CalendarExtender1.Enabled = false;
			
		}

		protected void dgTiming_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			dgTiming.EditItemIndex = -1;
			FillDataSet();

            FreeTextBox1.Text = String.Empty;
            pnlReason.Visible = false;

            CalendarExtender1.Enabled = true;
		}

        protected void dgTiming_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
            //Check if user entered notes
            //string str = FreeTextBox1.Text.Trim();
            //string str2 = FreeTextBox1.HtmlStrippedText.Trim();
            //string str3 = FreeTextBox1.Xhtml;
            if (String.IsNullOrEmpty(FreeTextBox1.Text.Trim()) || String.IsNullOrEmpty(FreeTextBox1.HtmlStrippedText.Trim()))//<p> </p>
            {
                lblNote.Text = "You must enter notes";
                lblNote.Visible = true;
                return;
            }
            //============================           
            //TextBox txtTime = (TextBox)e.Item.Cells[2].FindControl("txtTimeEdit");

            TextBox txtTime = (TextBox)e.Item.Cells[2].FindControl("txtTimeEdit");
			DropDownList ddlActionEdit = (DropDownList)e.Item.Cells[1].Controls[1];
			DropDownList ddlLocationE = (DropDownList)e.Item.Cells[0].Controls[1];
			

//			if(!ValidateData(txtStartDate.Text.Trim(), txtEndDate.Text.Trim(), txtHour.Text.Trim()))
//			{
//				return;
//			}

			//Validate CheckTime Value
			try
			{
                string TimeToConvert = txtTime.Text;
                DateTime AddTime = DateTime.Parse(TimeToConvert);//Convert.ToDateTime(TimeToConvert);
			}
			catch
			{
				lblNote.Visible=true;
				lblNote.Text="Invalid Time";
				return;
			}
			//////////////////////////
//
            Label lblModifyDateEdit = (Label)e.Item.Cells[4].FindControl("lblModifyDateEdit");
            DateTime dtTime = DateTime.Parse(lblModifyDateEdit.Text + " " + txtTime.Text);
			string Action = ddlActionEdit.SelectedValue;
            string[] arr=(string[])ViewState["arr"];
			DateTime previousTime = Convert.ToDateTime(arr[0]);
			string previousAction = arr[1];
            int ContactID = Convert.ToInt32(ddlEmployees.SelectedValue);
			EAMWS.TimingWS EAM = new TSN.ERP.WebGUI.EAMWS.TimingWS();
			FillDataSet();
            EAM.UpdateEmployeeTiming(ContactID, previousTime, dtTime, previousAction, Action, Convert.ToInt32(ddlLocationE.SelectedValue), Convert.ToInt32(Session["LoginContactID"]), DateTime.Now, FreeTextBox1.Text);
//
			
			dgTiming.EditItemIndex=-1;
			FillDataSet();
            FreeTextBox1.Text = String.Empty;
            pnlReason.Visible = false;

            GetTotalCheckInHours(ContactID, DateTime.Now);


            CalendarExtender1.Enabled = true;
		}

        protected void tnAddRecord_Click(object sender, ImageClickEventArgs e)
		{
            //divPanel.Visible = false;
            CalendarExtender1.Enabled = false;


			Panel1.Visible=true;
            ImageButton2.Visible = true;
            // 08/07/2009
            pnlReason.Visible = true;
            lblEmailConfirm.Visible = false;
            FreeTextBox1.Text = String.Empty;
            GetLoggedUserEmail();
            //
		}

		protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
		{
			if(txtAddTime.Visible==false)
				return;
			DateTime AddTime;
			string Action=ddlAddAction.SelectedValue;

            // added by sayed 07/07
            //Check if user entered notes
            if (String.IsNullOrEmpty(FreeTextBox1.Text.Trim()) || String.IsNullOrEmpty(FreeTextBox1.HtmlStrippedText.Trim()))//<p> </p>
            {
                lblNote.Text = "You must enter notes";
                lblNote.Visible = true;
                return;
            }
           
            //============================    

			try
			{
				// string TimeToConvert = txtAddTime.Text + " " + ddlAMPM.SelectedValue;
				// changed by Sayed 30/09/2008
				string TimeToConvert = txtDate.Text.Trim() + " " +txtAddTime.Text.Trim() + " " + ddlAMPM.SelectedValue;
				// end
				AddTime = DateTime.Parse(TimeToConvert);//Convert.ToDateTime(TimeToConvert);
			}
			catch
			{
				lblNote.Visible=true;
				lblNote.Text="Invalid Time";
				return;
			}
			string str = AddTime.ToUniversalTime().ToShortTimeString();
			int ContactID = Convert.ToInt32(ddlEmployees.SelectedValue);
			EAMWS.TimingWS EAM = new TSN.ERP.WebGUI.EAMWS.TimingWS();
			try
			{ // add reason of adding
				EAM.AddCheckTime(ContactID, AddTime, Action,Convert.ToInt32(ddLocation.SelectedValue));
			}
			catch(Exception ex)
			{
				lblNote.Visible=true;
				lblNote.Text="Error occured during saving...";
				return;
			}
            ///////  added at 08/07/2009 as a temp untill fawzi develop new function 
            EAM.UpdateEmployeeTiming(ContactID, AddTime, AddTime, Action, Action, Convert.ToInt32(ddLocation.SelectedValue), Convert.ToInt32(Session["LoginContactID"]), DateTime.Now, FreeTextBox1.Text);
            FreeTextBox1.Text = String.Empty;
            pnlReason.Visible = false;
            ImageButton2.Visible = false;
            ///////////
			FillDataSet();
			lblNote.Visible=true;
			lblNote.Text="Saved...";

			txtAddTime.Text = String.Empty;
			ddlAMPM.SelectedValue = "AM";
			ddlAddAction.SelectedValue = "I";
			Panel1.Visible=false;
            GetTotalCheckInHours(ContactID, DateTime.Now);


            CalendarExtender1.Enabled = true;
		}

		private void txtDate_TextChanged(object sender, System.EventArgs e)
		{
			FillDataSet();
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			if(ddlEmployees.Items.Count == 0)
				return;
			FillDataSet();
            txtDay.Text = Convert.ToDateTime(txtDate.Text).DayOfWeek.ToString();
			//Response.Write("HI");
		}

		private void ibtnCallender_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
//			Calendar1.Visible=true;
		}

        protected void dgTiming_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				LinkButton btn = (LinkButton)e.Item.FindControl("LinkButton1");
				btn.Attributes.Add("onclick", "return confirm('Are you sure you want to Delete this Entry?')");
			}

		}



        protected void dgTiming_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Trim()=="Delete")
			{
                if (dgTiming.EditItemIndex != -1)
                {
                    return;
                }
				// get Serial from dataGrid
				// Call WebServices
				Label lblTime = (Label)e.Item.Cells[2].FindControl("lblTimeOriginal");//.Controls[3];
                DropDownList ddlActionEdit = (DropDownList)e.Item.Cells[1].FindControl("ddlGridAction");//.Controls[3];
				int ContactID = Convert.ToInt32(ddlEmployees.SelectedValue);
				EAMWS.TimingWS EAM = new TSN.ERP.WebGUI.EAMWS.TimingWS();
				EAM.DeleteEmployeeAttendance(ContactID,Convert.ToDateTime(lblTime.Text.Trim()),ddlActionEdit.SelectedValue);
				FillDataSet();
                GetTotalCheckInHours(ContactID, DateTime.Now);
			}
		}

//		private void Calendar1_SelectionChanged(object sender, System.EventArgs e)
//		{
//			txtDate.Text=Calendar1.SelectedDate.ToShortDateString();
//			Calendar1.Visible=false;
//			FillDataSet();
//		}
        protected void imgbtnSend_Click(object sender, ImageClickEventArgs e)
        {
            if (String.IsNullOrEmpty(FreeTextBox1.Text.Trim()) || String.IsNullOrEmpty(FreeTextBox1.HtmlStrippedText.Trim()))//<p> </p>
            {
                lblNote.Text = "You must enter notes";
                lblNote.Visible = true;
                return;
            }

            if (txtboxEmailFrom.Text == "")
            {
                lblEmailConfirm.Text = ("Email Can not be sent, Current user has no valid Email account in 'From' Sender");
                lblEmailConfirm.ForeColor = System.Drawing.Color.Red;
                lblEmailConfirm.Visible = true;
                return;
            }
            if (txtboxTo.Text == "")
            {
                lblEmailConfirm.Text = ("Please type an address in the To field");
                lblEmailConfirm.ForeColor = System.Drawing.Color.Red;
                lblEmailConfirm.Visible = true;
                return;
            }

            if (txtboxTo.Text == "" && txtboxCC.Text == "" && txtboxBCC.Text == "")
            {
                lblEmailConfirm.Text = ("Please type an address in the To or CC or BCC Text box.");
                lblEmailConfirm.ForeColor = System.Drawing.Color.Red;
                lblEmailConfirm.Visible = true;
                return;
            }

            if (ConfigurationManager.AppSettings["UseMailerModule"] == "No")
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(txtboxEmailFrom.Text);
                msg.To.Add(txtboxTo.Text);
                if (!String.IsNullOrEmpty(txtboxCC.Text))
                    msg.CC.Add(txtboxCC.Text);
                if (!String.IsNullOrEmpty(txtboxBCC.Text))
                    msg.Bcc.Add(txtboxBCC.Text);
                msg.Subject = txtboxSubject.Text;
                msg.IsBodyHtml = true;
                msg.Body = "<html><body><table><tr><td>" + FreeTextBox1.Text + "</td></tr></table></body></html>";//"<H1>HHHHHHHHHH</H1>";//notes;			
                SmtpClient client = new SmtpClient();
                if (rblSendingMethod.SelectedValue == "0")//Internal                
                    client.Host = ConfigurationManager.AppSettings["SMTPServerInternal"];
                else//External
                    client.Host = ConfigurationManager.AppSettings["SMTPServerExternal"];
                client.SendCompleted += new SendCompletedEventHandler(client_SendCompleted);
                client.SendAsync(msg, null);
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "CloseMe", "<script>closeNotes();</script>");
            }
            else if (ConfigurationManager.AppSettings["UseMailerModule"] == "Yes")
            {
                WSMailer.MailerService mailService = new TSN.ERP.WebGUI.WSMailer.MailerService();
                string From = txtboxEmailFrom.Text;
                string To = txtboxTo.Text;
                string CC = txtboxCC.Text;
                string BCC = txtboxBCC.Text;
                string Subject = txtboxSubject.Text;
                string Body = "<html><body><table><tr><td>" + FreeTextBox1.Text + "</td></tr></table></body></html>";
                try
                {
                    bool Success = false;
                    Success = mailService.SendHTMLMail(To, CC, BCC, From, "", Subject, Body, "");
                    if (!Success)
                    {
                        lblEmailConfirm.Text = ("Error Occurred in Sending Email, Check SMTP Server Configurations");
                        lblEmailConfirm.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblEmailConfirm.Visible = true;
                        lblEmailConfirm.Text = "Email Sent Successfully";
                    }
                }
                catch (Exception ex)
                {
                    lblEmailConfirm.Text = ("Error Occurred in Sending Email, Check SMTP Server Configurations");
                    lblEmailConfirm.ForeColor = System.Drawing.Color.Red;
                }
            }
            //pnlEmail.Visible = false;
            lblEmailConfirm.Text = String.Empty;
            lblEmailConfirm.Visible = false;


            //WSMailer.MailerService objMailer = new WSMailer.MailerService();
            //try
            //{
            //    string MailerSMTPServer = ConfigurationManager.AppSettings["MailerSMTPServer"].ToString().Trim();
            //    string MailerSMPTPort = ConfigurationManager.AppSettings["MailerSMPTPort"].ToString().Trim();
            //    string MailerUserName = ConfigurationManager.AppSettings["MailerUserName"].ToString().Trim();
            //    string MailerUserPwd = ConfigurationManager.AppSettings["MailerUserPwd"].ToString().Trim();

            //    if (!objMailer.SendHTMLMail(txtboxTo.Text, txtboxCC.Text, txtboxBCC.Text, txtboxEmailFrom.Text, txtboxEmailFrom.Text, txtboxSubject.Text, FreeTextBox1.Text, "", MailerSMPTPort, MailerSMTPServer, MailerUserName, MailerUserPwd))
            //    //if (!objMailer.SendHTMLMail("fawzi@tsndomain.local", txtboxCC.Text, txtboxBCC.Text, "fawzi@tsndomain.local", "", txtboxSubject.Text, GetEmailBodyContent(), "", MailerSMPTPort, MailerSMTPServer, MailerUserName, MailerUserPwd))
            //    {
            //        lblEmailConfirm.Text = ("Error Occurred in Sending Email, Check SMTP Server Configurations");
            //        lblEmailConfirm.ForeColor = System.Drawing.Color.Red;
            //    }
            //    lblEmailConfirm.Visible = true;
            //    lblEmailConfirm.Text = "Email Sent Successfully";
            //}
            //catch (NullReferenceException)
            //{

            //}

            //pnlEmail.Visible = false;
            //lblEmailConfirm.Text = String.Empty;
            //lblEmailConfirm.Visible = false;
        }

        void client_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                lblEmailConfirm.Text = ("Error Occurred in Sending Email, Check SMTP Server Configurations");
                lblEmailConfirm.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void GetLoggedUserEmail()
        {
            DataSet dsEmail1 = new DataSet();
            Navigation.BaseObject.SafeMerge(dsEmail1, ((Navigation.BaseObject)Session["navigation"]).ContactWsObject.ListAllCotactEmails(Convert.ToInt32(Session["LoginContactID"])));
            if (dsEmail1.Tables[0].Rows.Count > 0)
            {
                string mailingType = ConfigurationManager.AppSettings["MailingType"];
                if (IsPostBack)//First load, get mailing type from web.config else getit from sending method radio button list 
                    mailingType = rblSendingMethod.SelectedValue;
                DataRow[] Mails = dsEmail1.Tables[0].Select("EmailType=" + mailingType + "");
                if (mailingType == "0")//Internal
                {
                    if (Mails.Length > 0)
                    {
                        txtboxEmailFrom.Text = Mails[0]["ContactEmail"].ToString().Trim();
                    }
                    else
                    {
                        txtboxEmailFrom.Text = String.Empty;
                    }
                }
                else if (mailingType == "1")//External
                {
                    if (Mails.Length > 0)
                    {
                        txtboxEmailFrom.Text = Mails[0]["ContactEmail"].ToString().Trim();
                    }
                    else
                    {
                        txtboxEmailFrom.Text = String.Empty;
                    }
                }
            }
            else
            {
                txtboxEmailFrom.Text = String.Empty;
            }
        }
        protected void imgbtnCancelSend_Click(object sender, ImageClickEventArgs e)
        {
            pnlEmail.Visible = false;
            lblEmailConfirm.Text = String.Empty;
        }
        protected void ibtnEmail_Click(object sender, ImageClickEventArgs e)
        {
            pnlEmail.Visible = true;
            GetLoggedUserEmail();
        }
        protected void ibtnZoomIn_Click(object sender, ImageClickEventArgs e)
        {
            if (pnlReason.Width == Unit.Parse("50%"))
                pnlReason.Width = Unit.Parse("60%");
            else if (pnlReason.Width == Unit.Parse("60%"))
                pnlReason.Width = Unit.Parse("70%");
            else if (pnlReason.Width == Unit.Parse("70%"))
                pnlReason.Width = Unit.Parse("80%");
            else if (pnlReason.Width == Unit.Parse("80%"))
                pnlReason.Width = Unit.Parse("90%");
            else if (pnlReason.Width == Unit.Parse("90%"))
                pnlReason.Width = Unit.Parse("100%");

            //if (pnlReason.Height == Unit.Parse("20%"))            
            //    pnlReason.Height = Unit.Parse("30%");
            //else if (pnlReason.Height == Unit.Parse("30%"))
            //    pnlReason.Height = Unit.Parse("40%");
            //if (pnlReason.Height == Unit.Parse("40%"))
            //    pnlReason.Height = Unit.Parse("50%");
            //if (pnlReason.Height == Unit.Parse("50%"))
            //    pnlReason.Height = Unit.Parse("60%");
            //if (pnlReason.Height == Unit.Parse("60%"))
            //    pnlReason.Height = Unit.Parse("70%");  

            //ibtnZoomIn.Visible = false;
            //ibtnZoomOut.Visible = true;
        }
        protected void ibtnZoomOut_Click(object sender, ImageClickEventArgs e)
        {
            if (pnlReason.Width == Unit.Parse("100%"))
                pnlReason.Width = Unit.Parse("90%");
            else if (pnlReason.Width == Unit.Parse("90%"))
                pnlReason.Width = Unit.Parse("80%");
            else if (pnlReason.Width == Unit.Parse("80%"))
                pnlReason.Width = Unit.Parse("70%");
            else if (pnlReason.Width == Unit.Parse("70%"))
                pnlReason.Width = Unit.Parse("60%");
            else if (pnlReason.Width == Unit.Parse("60%"))
                pnlReason.Width = Unit.Parse("50%");

            //ibtnZoomIn.Visible = true;
            //ibtnZoomOut.Visible = false;
        }
        protected void rblSendingMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindMailsGrid();
            GetLoggedUserEmail();
        }

        private void BindMailsGrid()
        {
            DataSet dsContactsAndEmails = new DataSet();
            string mailingType = ConfigurationManager.AppSettings["MailingType"];
            if (IsPostBack)//First load, get mailing type from web.config else getit from sending method radio button list 
                mailingType = rblSendingMethod.SelectedValue;
            if (mailingType == "0")//Internal
            {
                Navigation.BaseObject.SafeMerge(dsContactsAndEmails, ((Navigation.BaseObject)Session["navigation"]).ContactWsObject.ListCotactsAndEmails(0));
            }
            else if (mailingType == "1")//External
            {
                Navigation.BaseObject.SafeMerge(dsContactsAndEmails, ((Navigation.BaseObject)Session["navigation"]).ContactWsObject.ListCotactsAndEmails(1));
            }
            else if (mailingType == "2")//Private
            {
                Navigation.BaseObject.SafeMerge(dsContactsAndEmails, ((Navigation.BaseObject)Session["navigation"]).ContactWsObject.ListCotactsAndEmails(2));
            }
            else if (mailingType == "-1")//Get All mails
            {
                Navigation.BaseObject.SafeMerge(dsContactsAndEmails, ((Navigation.BaseObject)Session["navigation"]).ContactWsObject.ListCotactsAndEmails(-1));
            }
            Session["dsContactsAndEmails"] = dsContactsAndEmails;
            dgEmails.DataSource = dsContactsAndEmails;
            dgEmails.DataBind();
            
        }
}
}
