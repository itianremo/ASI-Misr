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

namespace TSN.ERP.WebGUI
{
	/// <summary>
	/// Summary description for frmTimingInOut.
	/// </summary>
	public partial class frmTimingInOut : System.Web.UI.Page
	{
		//EAMWS..AccTimingService timeWS=new TSN.ERP.WebGUI.NewTimingWS.AccTimingService();
		EAMWS.TimingWS timeWS=new TSN.ERP.WebGUI.EAMWS.TimingWS();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			//Session["CurrentEmployee"]= ContactID
			
//			
//			DataSet dsEmpSummarizedData = ((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListEmployeeSummarizedData(ContactID);
//
//			DataRow row = dataSetEmpData.Tables[ 0 ].NewRow();
//			row[ 0 ] = dsEmpSummarizedData.Tables[0].Rows[0]["Fullname"];
//			row[ 1 ] = dsEmpSummarizedData.Tables[0].Rows[0]["JobName"];
//			row[ 2 ] = dsEmpSummarizedData.Tables[0].Rows[0]["CEName"];
			 admin.Visible=false;

			if(!IsPostBack)
			{
				divConfirm.Visible=false;
				int ContactID=Convert.ToInt32(Session["CurrentEmployee"]);
				ViewState["ContactID"]=ContactID;
				string empName;

				FillDataSet();

				// added By Sayed Moawad 18/08/2008
				DataSet dsEmp = ((Navigation.BaseObject)Session["navigation"]).EmployeeWsObject.ListSingleEmployeeData(ContactID);
				if(dsEmp.Tables[0].Rows.Count>0)
				{
					empName=Convert.ToString(dsEmp.Tables[0].Rows[0]["Fullname"]).Trim();
					ViewState["empName"]=empName;
					lblWelcome.Text=ViewState["empName"].ToString();
					divConfirm.Visible=false;
					//DivConsimpate.Visible=false;
				}
				else
				{
					lblWelcome.Text="Administrator";
					divConfirm.Visible=false;
					//DivConsimpate.Visible=false;
					divInOut.Visible=false;
					admin.Visible=true;
					

				}
				// end
				
				GetStatus();

				//added By Moawad 28/9/2008
				try
				{
					int UserID=((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.GetUserIDByContactID(ContactID);
					
					bool hasRight=((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.CheckRuleXUserID(UserID,5125);
					if(hasRight)
					{
						btnCheckIn.Enabled=true;
						btnCheckOut.Enabled=true;
					}
					else
					{
						btnCheckIn.Enabled=false;
						btnCheckOut.Enabled=false;
						return;
					}
						
					
				}
				catch
				{
					btnCheckIn.Enabled=false;
					btnCheckOut.Enabled=false;
					return;
				}
				//
//				GetStatus();
				
			}

            // sayed 29-6-2007
            GetTotalCheckInHours(Convert.ToInt32(ViewState["ContactID"]), DateTime.Now);
		}
        private decimal GetTotalCheckInHours(int contactID, DateTime date)
        {
            decimal total = 0;
            try
            {
                total = timeWS.GetTotalCheckInTime(contactID, date);
            }
            catch (Exception ex)
            {
                // commented by sayed and replaced by after next line where total=0
                //Response.Write("Error calculating total check in time : " + ex.Message);
                lblTotalCheckInTime.Text = total.ToString();
            }
            finally
            {
                lblTotalCheckInTime.Text = total.ToString();
            }
            return total;
        }
		void GetStatus()
		{
			try
			{
				string  vsCurrentStatus=timeWS.GetEmployeeTimingStatus(Convert.ToInt32(ViewState["ContactID"]));
				if(vsCurrentStatus.Trim()=="Checked Out")
					ViewState["vsCurrentStatus"]="O";
				else if(vsCurrentStatus.Trim()=="Checked In")
					ViewState["vsCurrentStatus"]="I";
								
				ChangeStatus(ViewState["vsCurrentStatus"].ToString().Trim());
					
			}
			catch(Exception ex)
			{
				Response.Write("Error to connect Timing Web Services "+ex.Message);
				ViewState["vsCurrentStatus"]="error";
				ChangeStatus("error");
			}
		}
		void ChangeStatus(string vsCurrentStatus)
		{
			if(vsCurrentStatus=="" )
			{
				lblStatus.Text="Not checked in";

			}
			else if(vsCurrentStatus=="O" )
			{
				lblStatus.Text="Checked Out";

			}
			else if(vsCurrentStatus=="I")
			{
				lblStatus.Text="Checked In";

			}
			
			else if(vsCurrentStatus=="error")
			{
				lblStatus.Text="Error";

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
			this.dgTiming.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgTiming_ItemDataBound);

		}
		#endregion

		protected void btnCheckIn_Click(object sender, ImageClickEventArgs e)
		{
			GetStatus();
			if(ViewState["vsCurrentStatus"].ToString().Trim()=="I")
			{
				
				lblConfirmMessage.Text="You are already checked in. do you want to check in again?";
				ViewState["NewvsCurrentStatus"]="I";
				divConfirm.Visible=true;
				divInOut.Visible=false;
				ViewState["AddOrDelete"]="Add";

			}
			else
			{
				ViewState["vsCurrentStatus"]="I";

				string TimeToConvert = DateTime.Now.ToShortDateString() + " " +DateTime.Now.ToLongTimeString();
				DateTime AddTime = DateTime.Parse(TimeToConvert);

				
				try
				{
					timeWS.AddCheckTime(Convert.ToInt32(ViewState["ContactID"]),AddTime,ViewState["vsCurrentStatus"].ToString().Trim(),Convert.ToInt32(ddLocation.SelectedValue));
				}
				catch
				{
					lblConfirmMessage.Text="An error iccured during checkin...";
					return;
				}
				divConfirm.Visible=false;
				divInOut.Visible=true;
				ViewState["CurrentDateTime"]=DateTime.Now;
				GetStatus();
				
			}

			FillDataSet();
            GetTotalCheckInHours(Convert.ToInt32(ViewState["ContactID"]), DateTime.Now);				
		}
        protected void btnCheckOut_Click(object sender, ImageClickEventArgs e)
		{
			try
			{
				GetStatus();
				if(ViewState["vsCurrentStatus"].ToString().Trim()=="O")
				{
					
					lblConfirmMessage.Text="You are already checked out. do you want to check out again?";
					ViewState["NewvsCurrentStatus"]="O";
					ViewState["AddOrDelete"]="Delete";
					divConfirm.Visible=true;
					divInOut.Visible=false;

				}
				else
				{
					
					ViewState["vsCurrentStatus"]="O";

					string TimeToConvert = DateTime.Now.ToShortDateString() + " " +DateTime.Now.ToLongTimeString();
					DateTime AddTime = DateTime.Parse(TimeToConvert);
					

					try
					{
						timeWS.AddCheckTime(Convert.ToInt32(ViewState["ContactID"]),AddTime,ViewState["vsCurrentStatus"].ToString().Trim(),Convert.ToInt32(ddLocation.SelectedValue));
					}
					catch
					{
						lblConfirmMessage.Text="An error iccured during checkin...";
						return;
					}
					divConfirm.Visible=false;
					divInOut.Visible=true;
					GetStatus();
				}
				FillDataSet();
			}
			catch(Exception ex)
			{
				Response.Write("Error to connect Timing Web Services "+ex.Message);
			}
            GetTotalCheckInHours(Convert.ToInt32(ViewState["ContactID"]), DateTime.Now);
		}
        protected void btnYes_Click(object sender, ImageClickEventArgs e)
		{
			ViewState["vsCurrentStatus"]=ViewState["NewvsCurrentStatus"];
			if(ViewState["AddOrDelete"].ToString()=="Add")
			{
				string TimeToConvert = DateTime.Now.ToShortDateString() + " " +DateTime.Now.ToLongTimeString();
				DateTime AddTime = DateTime.Parse(TimeToConvert);
					
				
				try
				{
					timeWS.AddCheckTime(Convert.ToInt32(ViewState["ContactID"]),AddTime,ViewState["vsCurrentStatus"].ToString().Trim(),Convert.ToInt32(ddLocation.SelectedValue));
				}
				catch
				{
					lblConfirmMessage.Text="An error iccured during saving...";
					return;
				}
				divInOut.Visible=true;
				divConfirm.Visible=false;
				
			}
			else
			{
				string TimeToConvert = DateTime.Now.ToShortDateString() + " " +DateTime.Now.ToLongTimeString();
				DateTime AddTime = DateTime.Parse(TimeToConvert);
					

				try
				{
					timeWS.AddCheckTime(Convert.ToInt32(ViewState["ContactID"]),AddTime,ViewState["vsCurrentStatus"].ToString().Trim(),Convert.ToInt32(ddLocation.SelectedValue));
				}
				catch
				{
					lblConfirmMessage.Text="An error iccured during saving...";
					return;
				}
				divInOut.Visible=true;
				divConfirm.Visible=false;
				GetStatus();
			}
			FillDataSet();
            GetTotalCheckInHours(Convert.ToInt32(ViewState["ContactID"]), DateTime.Now);
		}
        protected void btnNo_Click(object sender, ImageClickEventArgs e)
		{
			divInOut.Visible=true;
			divConfirm.Visible=false;
            GetTotalCheckInHours(Convert.ToInt32(ViewState["ContactID"]), DateTime.Now);			
		}

		private DataSet FillDataSet()
		{
			EAMWS.TimingWS EAM = new TSN.ERP.WebGUI.EAMWS.TimingWS();
			try
			{
				DataSet ds = EAM.GetEmployeeAttendance(Convert.ToInt32(ViewState["ContactID"]),Convert.ToDateTime(DateTime.Now.ToShortDateString()));
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
			catch(Exception ex)
			{
				string str=ex.Message;
				return null;
			}
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
					Label lblLocation = ((Label)e.Item.FindControl("lblLocation"));
					ddlLocationI.SelectedValue=lblLocation.Text.Trim();//Location
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

			}
		}
	}
}
