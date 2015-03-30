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
	public partial class FrmTimingInOutEG : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblConfirmMessage;


//		NewTimingWS.AccTimingService timeWS=new TSN.ERP.WebGUI.NewTimingWS.AccTimingService();
		TimingWS_EG.TimingCheckInOut timeWS = new TSN.ERP.WebGUI.TimingWS_EG.TimingCheckInOut();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{	
			admin.Visible=false;
			if(!IsPostBack)
			{
				int ContactID=Convert.ToInt32(Session["CurrentEmployee"]);				
				ViewState["ContactID"]=ContactID;
				string empName;		

				// added By Sayed Moawad 18/08/2008
				DataSet dsEmp = ((Navigation.BaseObject)Session["navigation"]).EmployeeWsObject.ListSingleEmployeeData(ContactID);
				if(dsEmp.Tables[0].Rows.Count>0)
				{
					empName=Convert.ToString(dsEmp.Tables[0].Rows[0]["Fullname"]).Trim();
					ViewState["empName"]=empName;
                    lblWelcome.Text = ViewState["empName"].ToString();

//					btnCheckIn.Enabled=true;
//					btnCheckOut.Enabled=true;

                    try
                    {
                        string Status = timeWS.GetEmployeeStatusInDay(ContactID, DateTime.Now);
                        lblStatus.Text = Status;
                        if (Status == "IN")
                        {
                            btnCheckIn.Enabled = false;
                            btnCheckOut.Enabled = true;
                            lblStatus.Text = "Checked In";
                        }
                        else if (Status == "OUT")
                        {
                            btnCheckIn.Enabled = true;
                            btnCheckOut.Enabled = false;
                            lblStatus.Text = "Checked Out";
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error to connect Timing Web Services " + ex.Message);
                        btnCheckIn.Enabled = false;
                        btnCheckOut.Enabled = false;
                        lblStatus.Text = "Error...";
                    }
					
//					Label3.Visible = true;
//					lblStatus.Visible = true;
				}
				else
				{
					lblWelcome.Text="Administrator";
					admin.Visible=true;
					divInOut.Visible = false;
//					btnCheckIn.Visible=false;
//					btnCheckOut.Visible=false;
//					lblWelcome.Visible = false;
//					Label3.Visible = false;
//					lblStatus.Visible = false;

				}

				
//				if(dsEmp.Tables[0].Rows.Count == 0)
//				{
//					btnCheckIn.Enabled=false;
//					btnCheckOut.Enabled=false;
//					lblStatus.Text = "Checked Out";
//				}
//				else
//				{
//				}
			}
            int contactID = Convert.ToInt32(Session["CurrentEmployee"]);
            GetTotalCheckInHours(contactID, DateTime.Now);
            FillDataSet();
		}

        private string GetTotalCheckInHours(int contactID, DateTime date)
        {
            string total = "0";
            try
            {
                string tempTotal = timeWS.GetDayTotalWorkingHours(contactID, date);
                total = String.IsNullOrEmpty(tempTotal) ? "0" : tempTotal;
            }
            catch (Exception ex)
            {
                Response.Write("Error calculating total check in time : " + ex.Message);
            }
            finally
            {
                lblTotalCheckInTime.Text = total;
            }
            return total;
        }

        private DataSet FillDataSet()
        {
            try
            {
                DataSet ds = timeWS.GetEmployeeRecordsInPeriod(Convert.ToInt32(Session["CurrentEmployee"]), DateTime.Now, DateTime.Now);
                dgTiming.DataSource = ds;
                dgTiming.DataBind();

                if (dgTiming.Items.Count == 0)
                {
                    dgTiming.Visible = false;
                }
                else
                {
                    dgTiming.Visible = true;
                }
                return ds;
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return null;
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

		}
		#endregion

		protected void btnCheckIn_Click(object sender, System.EventArgs e)
		{
			string returnValue = timeWS.CheckInService(ViewState["ContactID"].ToString(),DateTime.Now.ToString());

			int ContactID = Convert.ToInt32(ViewState["ContactID"]);
			string Status = timeWS.GetEmployeeStatusInDay(ContactID,DateTime.Now);
			if(Status == "IN")
			{
				btnCheckIn.Enabled=false;
				btnCheckOut.Enabled=true;
				lblStatus.Text = "Checked In";
			}
			else if(Status == "OUT")
			{
				btnCheckIn.Enabled=true;
				btnCheckOut.Enabled=false;
				lblStatus.Text = "Checked Out";
			}
            GetTotalCheckInHours(ContactID, DateTime.Now);
            FillDataSet();
		}

		protected void btnCheckOut_Click(object sender, System.EventArgs e)
		{
			string returnValue = timeWS.CheckOutService(ViewState["ContactID"].ToString(),DateTime.Now.ToString());

			int ContactID = Convert.ToInt32(ViewState["ContactID"]);
			string Status = timeWS.GetEmployeeStatusInDay(ContactID,DateTime.Now);
			if(Status == "IN")
			{
				btnCheckIn.Enabled=false;
				btnCheckOut.Enabled=true;
				lblStatus.Text = "Checked In";
			}
			else if(Status == "OUT")
			{
				btnCheckIn.Enabled=true;
				btnCheckOut.Enabled=false;
				lblStatus.Text = "Checked Out";
			}
            GetTotalCheckInHours(ContactID, DateTime.Now);
            FillDataSet();
		}
	}
}
