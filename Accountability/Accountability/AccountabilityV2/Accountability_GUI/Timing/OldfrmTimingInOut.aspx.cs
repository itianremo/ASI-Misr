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

namespace TSN.ERP.WebGUI.Timing
{
	/// <summary>
	/// Summary description for OldfrmTimingInOut.
	/// </summary>
	public partial class OldfrmTimingInOut : System.Web.UI.Page
	{
		NewTimingWS.AccTimingService timeWS=new TSN.ERP.WebGUI.NewTimingWS.AccTimingService();
	
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
				DivConsimpate.Visible=false;
				int ContactID=Convert.ToInt32(Session["CurrentEmployee"]);
				ViewState["ContactID"]=ContactID;
				string empName;

				// added By Sayed Moawad 18/08/2008
				DataSet dsEmp = ((Navigation.BaseObject)Session["navigation"]).EmployeeWsObject.ListSingleEmployeeData(ContactID);
				if(dsEmp.Tables[0].Rows.Count>0)
				{
					empName=Convert.ToString(dsEmp.Tables[0].Rows[0]["Fullname"]).Trim();
					ViewState["empName"]=empName;
					lblWelcome.Text="Welcome : "+ViewState["empName"].ToString();
					divConfirm.Visible=false;
					DivConsimpate.Visible=false;
				}
				else
				{
					lblWelcome.Text="Welcome : Administrator";
					divConfirm.Visible=false;
					DivConsimpate.Visible=false;
					divInOut.Visible=false;
					admin.Visible=true;
					

				}
				// end
				
				//string vsCurrentStatus;
				GetStatus();
				
			}
			
			// Put user code to initialize the page here
		}
		void GetStatus()
		{
			try
			{
				DataSet ds=timeWS.GetEmployeeStatus(Convert.ToInt32(ViewState["ContactID"]),DateTime.Now);
				if(ds==null || ds.Tables[0].Rows.Count==0)
					ViewState["vsCurrentStatus"]="";
				else
				{
					if(ds.Tables[0].Columns.Contains("StatusOut"))
					{
						ViewState["vsCurrentStatus"]=ds.Tables[0].Rows[0]["StatusOut"].ToString().Trim();
					}
					//else if(ds.Tables[0].Columns.Contains("StatusIn"))
					if(ds.Tables[0].Columns.Contains("StatusIn"))
					{
						if(ViewState["vsCurrentStatus"].ToString().Trim()=="")
							ViewState["vsCurrentStatus"]=ds.Tables[0].Rows[0]["StatusIn"].ToString().Trim();
					}  
				}
				
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
				//				btnCheckIn.Enabled=true;
				//				btnCheckOutforLunch.Enabled=false;
				//				btnCheckOut.Enabled=false;
				//				btnCheckInfromLunch.Enabled=false;
			}
			else if(vsCurrentStatus=="OUT" )
			{
				lblStatus.Text="Out";
				//				btnCheckIn.Enabled=true;
				//				btnCheckOutforLunch.Enabled=false;
				//				btnCheckOut.Enabled=false;
				//				btnCheckInfromLunch.Enabled=false;
			}
			else if(vsCurrentStatus=="IN")
			{
				lblStatus.Text="In";
				//				btnCheckIn.Enabled=false;
				//				btnCheckOutforLunch.Enabled=true;
				//				btnCheckOut.Enabled=true;
				//				btnCheckInfromLunch.Enabled=false;
			}
			else if(vsCurrentStatus=="LI")
			{
				lblStatus.Text="Cheched in from lunch";
				//				btnCheckIn.Enabled=false;
				//				btnCheckOutforLunch.Enabled=true;
				//				btnCheckOut.Enabled=true;
				//				btnCheckInfromLunch.Enabled=false;
			}
			else if(vsCurrentStatus=="LO")
			{
				lblStatus.Text="Checked out for lunch";
				//				btnCheckIn.Enabled=false;
				//				btnCheckOutforLunch.Enabled=false;
				//				btnCheckOut.Enabled=false;
				//				btnCheckInfromLunch.Enabled=true;
			}
			else if(vsCurrentStatus=="error")
			{
				lblStatus.Text="Not paid";
				//				btnCheckIn.Enabled=false;
				//				btnCheckOutforLunch.Enabled=false;
				//				btnCheckOut.Enabled=false;
				//				btnCheckInfromLunch.Enabled=false;
			}
			//txtCurrentStatus.Text="Status: " +ViewState["vsCurrentStatus"].ToString();
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

		}
		#endregion

		protected void btnCheckIn_Click(object sender, System.EventArgs e)
		{
			GetStatus();
			if(ViewState["vsCurrentStatus"].ToString().Trim()=="IN" || ViewState["vsCurrentStatus"].ToString().Trim()=="LI")
			{
				if(ViewState["vsCurrentStatus"].ToString().Trim()=="IN")
				{
					lblConfirmMessage.Text="You are already checked in. do you want to check in again?";
					ViewState["NewvsCurrentStatus"]="IN";
				}
				else
				{
					lblConfirmMessage.Text="You are already checked in from lunch. do you want to check in?";
					ViewState["NewvsCurrentStatus"]="IN";
				}
				divConfirm.Visible=true;
				divInOut.Visible=false;
				ViewState["AddOrDelete"]="Add";

			}
			else
			{
				ViewState["vsCurrentStatus"]="IN";
				divConfirm.Visible=false;
				divInOut.Visible=false;
				DivConsimpate.Visible=true;
				ViewState["CurrentDateTime"]=DateTime.Now;
				lblCurrentTime.Text=DateTime.Now.ToShortTimeString();
			}
						
			return;
			//			try
			//			{
			//				ViewState["vsCurrentStatus"]="IN";
			//				timeWS.CheckInService(Convert.ToInt32(ViewState["ContactID"]),DateTime.Now,ViewState["vsCurrentStatus"].ToString());
			//				ChangeStatus(ViewState["vsCurrentStatus"].ToString());
			//			}
			//			catch(Exception ex)
			//			{
			//				 Response.Write("Error to connect Timing Web Services "+ex.Message);
			//			}
		
		}

		protected void btnCheckInfromLunch_Click(object sender, System.EventArgs e)
		{
			GetStatus();
			if(ViewState["vsCurrentStatus"].ToString().Trim()=="IN" || ViewState["vsCurrentStatus"].ToString().Trim()=="LI")
			{
				if(ViewState["vsCurrentStatus"].ToString().Trim()=="IN")
				{
					lblConfirmMessage.Text="You are already checked in. do you want to check in from lunch?";
					ViewState["NewvsCurrentStatus"]="LI";
				}
				else
				{
					lblConfirmMessage.Text="You are already checked in from lunch. do you want to check in from lunch again?";
					ViewState["NewvsCurrentStatus"]="LI";
				}
				divConfirm.Visible=true;
				divInOut.Visible=false;
				ViewState["AddOrDelete"]="Add";

			}
			else
			{
				ViewState["vsCurrentStatus"]="LI";
				divConfirm.Visible=false;
				divInOut.Visible=false;
				DivConsimpate.Visible=true;
				ViewState["CurrentDateTime"]=DateTime.Now;
				lblCurrentTime.Text=DateTime.Now.ToShortTimeString();
			}
						
			return;
			//			try
			//			{
			//			ViewState["vsCurrentStatus"]="LI";
			//			timeWS.CheckInService(Convert.ToInt32(ViewState["ContactID"]),DateTime.Now,ViewState["vsCurrentStatus"].ToString());
			//			ChangeStatus(ViewState["vsCurrentStatus"].ToString());
			//			}
			//			catch(Exception ex)
			//			{
			//				Response.Write("Error to connect Timing Web Services "+ex.Message);
			//			}
		}

		protected void btnCheckOutforLunch_Click(object sender, System.EventArgs e)
		{
			
			try
			{
				GetStatus();
				if(ViewState["vsCurrentStatus"].ToString().Trim()=="OUT" || ViewState["vsCurrentStatus"].ToString().Trim()=="LO")
				{
					if(ViewState["vsCurrentStatus"].ToString().Trim()=="OUT")
					{
						lblConfirmMessage.Text="You are already checked out. do you want to check out for lunch?";
						ViewState["NewvsCurrentStatus"]="LO";
					}
					else
					{
						lblConfirmMessage.Text="You are already checked out for lunch. do you want to check out for lunch again?";
						ViewState["NewvsCurrentStatus"]="LO";
					}
					ViewState["AddOrDelete"]="Delete";
					divConfirm.Visible=true;
					divInOut.Visible=false;

				}
				else
				{
					ViewState["vsCurrentStatus"]="LO";
					timeWS.CheckOutService(Convert.ToInt32(ViewState["ContactID"]),DateTime.Now,ViewState["vsCurrentStatus"].ToString());
					ChangeStatus(ViewState["vsCurrentStatus"].ToString());
					GetStatus();
				}
			}
			catch(Exception ex)
			{
				Response.Write("Error to connect Timing Web Services "+ex.Message);
			}
			
		}

		protected void btnCheckOut_Click(object sender, System.EventArgs e)
		{
			try
			{
				GetStatus();
				if(ViewState["vsCurrentStatus"].ToString().Trim()=="OUT" || ViewState["vsCurrentStatus"].ToString().Trim()=="LO")
				{
					if(ViewState["vsCurrentStatus"].ToString().Trim()=="OUT")
					{
						lblConfirmMessage.Text="You are already checked out. do you want to check out again?";
						ViewState["NewvsCurrentStatus"]="OUT";
					}
					else
					{
						lblConfirmMessage.Text="You are already checked out for lunch. do you want to check out?";
						ViewState["NewvsCurrentStatus"]="OUT";
					}
					ViewState["AddOrDelete"]="Delete";
					divConfirm.Visible=true;
					divInOut.Visible=false;

				}
				else
				{
					//if(ViewState["vsCurrentStatus"].ToString().Trim()=="OUT")
					ViewState["vsCurrentStatus"]="OUT";
					timeWS.CheckOutService(Convert.ToInt32(ViewState["ContactID"]),DateTime.Now,ViewState["vsCurrentStatus"].ToString());
					ChangeStatus(ViewState["vsCurrentStatus"].ToString());
				}
			}
			catch(Exception ex)
			{
				Response.Write("Error to connect Timing Web Services "+ex.Message);
			}
		}

		protected void btnYes_Click(object sender, System.EventArgs e)
		{
			ViewState["vsCurrentStatus"]=ViewState["NewvsCurrentStatus"];
			if(ViewState["AddOrDelete"].ToString()=="Add")
			{
				divConfirm.Visible=false;
				DivConsimpate.Visible=true;
				lblCurrentTime.Text=DateTime.Now.ToShortTimeString();
				ViewState["CurrentDateTime"]=DateTime.Now;
				
			}
			else
			{
				timeWS.CheckOutService(Convert.ToInt32(ViewState["ContactID"]),DateTime.Now,ViewState["vsCurrentStatus"].ToString());
				//ChangeStatus(ViewState["vsCurrentStatus"].ToString());
				divInOut.Visible=true;
				divConfirm.Visible=false;
				DivConsimpate.Visible=false;
				GetStatus();
			}

		}

		protected void btnOKCompensate_Click(object sender, System.EventArgs e)
		{
			try
			{
				DateTime dt=Convert.ToDateTime(ViewState["CurrentDateTime"]);
				DateTime dtCompensate=dt.AddMinutes(-Convert.ToInt32(ddlCompensate.SelectedItem.Value));
				timeWS.CheckInService(Convert.ToInt32(ViewState["ContactID"]),dtCompensate,ViewState["vsCurrentStatus"].ToString());
				//ChangeStatus(ViewState["vsCurrentStatus"].ToString());
				GetStatus();
				divInOut.Visible=true;
				divConfirm.Visible=false;
				DivConsimpate.Visible=false;
			}
			catch(Exception ex)
			{
				Response.Write("Error to connect Timing Web Services "+ex.Message);
			}
			
		}

		protected void btnNo_Click(object sender, System.EventArgs e)
		{
			divInOut.Visible=true;
			divConfirm.Visible=false;
			DivConsimpate.Visible=false;
		}
	}
}
