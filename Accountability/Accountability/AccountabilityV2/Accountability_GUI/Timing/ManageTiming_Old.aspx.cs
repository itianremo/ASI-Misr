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

namespace TSN.ERP.WebGUI.Timing
{
	/// <summary>
	/// Summary description for frmEmpPhone.
	/// </summary>
	public partial class ManageTiming_Old : System.Web.UI.Page
	{
		
		//		private static int contactID;

		#region page load
		protected void Page_Load(object sender, System.EventArgs e)
		{
			lblNote.Visible=false;
			if(!IsPostBack)
			{
				txtDate.Text = DateTime.Now.ToShortDateString();
				txtDate.Attributes.Add("readonly","true");
//				ImageButton1.Attributes.Add("readonly","true");

				#region Fill Employees DropDownList
//				try
//				{
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
//				}
//				catch(Exception ex)
//				{
//					Response.Write(ex.Message);
//				}

				int ContactID = -1;
				try
				{
					ContactID=Convert.ToInt32(Session["CurrentEmployee"]);
					ddlEmployees.SelectedValue = ContactID.ToString();
				}
				catch
				{
					
				}

//				Calendar1.Visible=false;
				#endregion

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
				FillDataSet();
				#endregion
//				if(dgTiming.Items.Count == 0)
//				{
//					dgTiming.Visible = false;
//				}
//				else
//				{
//					dgTiming.Visible = true;
//				}
			}			
		}
		#endregion
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

		private void dgTiming_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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
			}
		}

		private void dgTiming_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			dgTiming.EditItemIndex = e.Item.ItemIndex;

			Label txtTime = (Label)e.Item.Cells[0].Controls[1];
			DropDownList ddlActionEdit = (DropDownList)e.Item.Cells[1].Controls[1];
			try
			{
				DropDownList ddlLocationE = (DropDownList)e.Item.Cells[2].Controls[1];//((DropDownList)e.Item.FindControl("ddlLocationE"));
				Label lblLocationE = (Label)e.Item.Cells[2].Controls[3];//((Label)e.Item.FindControl("lblLocationE"));
				ddlLocationE.SelectedValue=lblLocationE.Text.Trim();//Location
			}
			catch(Exception ex)
			{
				string str=ex.Message;
			}
			
			
			string[] arr = new string[2];
			arr[0]=txtTime.Text;
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
			
		}

		private void dgTiming_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			dgTiming.EditItemIndex = -1;
			FillDataSet();
		}

		private void dgTiming_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			TextBox txtTime = (TextBox)e.Item.Cells[0].Controls[1];
			DropDownList ddlActionEdit = (DropDownList)e.Item.Cells[1].Controls[1];
			DropDownList ddlLocationE = (DropDownList)e.Item.Cells[2].Controls[1];
			

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
			DateTime dtTime = DateTime.Parse(txtTime.Text);
			string Action = ddlActionEdit.SelectedValue;

			string[] arr=(string[])ViewState["arr"];
			DateTime previousTime = Convert.ToDateTime(arr[0]);
			string previousAction = arr[1];

			int ContactID = Convert.ToInt32(ddlEmployees.SelectedValue);
			EAMWS.TimingWS EAM = new TSN.ERP.WebGUI.EAMWS.TimingWS();
			FillDataSet();
			EAM.UpdateEmployeeTiming(ContactID,previousTime,dtTime,previousAction,Action,Convert.ToInt32(ddlLocationE.SelectedValue),Convert.ToInt32(Session["LoginContactID"]),DateTime.Now," ");
//
			
			
			dgTiming.EditItemIndex=-1;
			FillDataSet();
		}

		protected void tnAddRecord_Click(object sender, System.EventArgs e)
		{
			Panel1.Visible=true;
		}

		private void ImageButton2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(txtAddTime.Visible==false)
				return;
			DateTime AddTime;
			string Action=ddlAddAction.SelectedValue;
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
			{
				EAM.AddCheckTime(ContactID, AddTime, Action,Convert.ToInt32(ddLocation.SelectedValue));
			}
			catch
			{
				lblNote.Visible=true;
				lblNote.Text="Error occured during saving...";
				return;
			}
			FillDataSet();
			lblNote.Visible=true;
			lblNote.Text="Saved...";

			txtAddTime.Text = String.Empty;
			ddlAMPM.SelectedValue = "AM";
			ddlAddAction.SelectedValue = "I";
			Panel1.Visible=false;
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
			//Response.Write("HI");
		}

		private void ibtnCallender_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
//			Calendar1.Visible=true;
		}

		private void dgTiming_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				LinkButton btn = (LinkButton)e.Item.FindControl("LinkButton1");
				btn.Attributes.Add("onclick", "return confirm('Are you sure you want to Delete this Entry?')");
			}

		}

		

		private void dgTiming_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Trim()=="Delete")
			{
				// get Serial from dataGrid
				// Call WebServices
				Label txtTime = (Label)e.Item.Cells[0].Controls[1];
				DropDownList ddlActionEdit = (DropDownList)e.Item.Cells[1].Controls[1];
				int ContactID = Convert.ToInt32(ddlEmployees.SelectedValue);
				EAMWS.TimingWS EAM = new TSN.ERP.WebGUI.EAMWS.TimingWS();
				EAM.DeleteEmployeeAttendance(ContactID,Convert.ToDateTime(txtTime.Text.Trim()),ddlActionEdit.SelectedValue);
				FillDataSet();
			}
		}

//		private void Calendar1_SelectionChanged(object sender, System.EventArgs e)
//		{
//			txtDate.Text=Calendar1.SelectedDate.ToShortDateString();
//			Calendar1.Visible=false;
//			FillDataSet();
//		}
	}
}
