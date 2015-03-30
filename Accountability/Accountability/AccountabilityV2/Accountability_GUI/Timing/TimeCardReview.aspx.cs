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
    public partial class TimeCardReview : System.Web.UI.Page
    {

        //		private static int contactID;
        TimingWS_EG.TimingCheckInOut timeWS = new TSN.ERP.WebGUI.TimingWS_EG.TimingCheckInOut();
        #region page load
        protected void Page_Load(object sender, System.EventArgs e)
        {

            //lblNote.Visible = false;
            if (!IsPostBack)
            {

                txtDate.Text = DateTime.Now.ToShortDateString();
                txtDay.Text = Convert.ToDateTime(txtDate.Text).DayOfWeek.ToString();
                txtDate.Attributes.Add("readonly", "true");
                //				ImageButton1.Attributes.Add("readonly","true");
                DataSet dsAllEmployees = ((Navigation.BaseObject)Session["navigation"]).EmployeeWsObject.ListEmployees();
                if (dsAllEmployees.Tables.Count != 0)
                {
                    ViewState["dsAllEmployees"] = dsAllEmployees;
                }


                try
                {
                    DataSet dsEmployee = ((Navigation.BaseObject)Session["navigation"]).AccountabilityWSObject.ViewAccountabilityEmployees();
                    DataView dvEmp = dsEmployee.Tables[0].DefaultView;
                    dvEmp.RowFilter = "EmployeeStatus = 1";
                    dvEmp.Sort = "FirstName, MiddleName, LastName";
                    dsEmployee.Tables.Clear();
                    dsEmployee.Tables.Add(CreateTable(dvEmp));

                    ddlEmployees.DataTextField = "Fullname";
                    ddlEmployees.DataValueField = "ContactID";
                    ddlEmployees.DataSource = dsEmployee;
                    ddlEmployees.DataBind();


                    int ContactID = -1;
                    try
                    {
                        ContactID = Convert.ToInt32(Session["CurrentEmployee"]);
                        ddlEmployees.SelectedValue = ContactID.ToString();
                        //GetEmpData(ContactID);
                    }
                    catch (Exception ex)
                    {
                        //Response.Write(ex.Message);
                    }
                    if (ddlEmployees.Items.Count > 0)
                    {
                        GetEmpData(Convert.ToInt32(ddlEmployees.SelectedValue));
                        FillDataSet(Convert.ToDateTime(txtDate.Text));
                        GetTotalCheckInHours(Convert.ToInt32(ddlEmployees.SelectedValue), DateTime.Now);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Error to connect Timing Web Services " + ex.Message);
                }

            }
           

        }
        #endregion

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
        private void GetEmpData(int ContactID)
        {
            //Get Employee Number
            DataSet EmpSet = ((Navigation.BaseObject)Session["navigation"]).EmployeeWsObject.ListSingleEmployeeData(ContactID);
            txtEmployeeNumber.Text = EmpSet.Tables[0].Rows[0]["EmpCode"].ToString().Trim();
            string compElmentID = EmpSet.Tables[0].Rows[0]["compElmentID"].ToString().Trim();

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
            string[] strColNames = new string[obNewDt.Columns.Count];
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


        protected void ddlEmployees_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            FillDataSet(Convert.ToDateTime(txtDate.Text));            
            int contactID = Convert.ToInt32(ddlEmployees.SelectedValue);
            GetEmpData(contactID);
            GetTotalCheckInHours(contactID, DateTime.Now);
        }
        private DataSet FillDataSet(DateTime dt)
        {
            try
            {
                int contactID = Convert.ToInt32(ddlEmployees.SelectedValue);
                DataSet ds = timeWS.GetEmployeeRecordsInPeriod(contactID, dt, dt);
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

        private void txtDate_TextChanged(object sender, System.EventArgs e)
        {
            FillDataSet(Convert.ToDateTime(txtDate.Text));
        }

        protected void Button1_Click(object sender, System.EventArgs e)
        {
            if (ddlEmployees.Items.Count == 0)
                return;
            int contactID = Convert.ToInt32(ddlEmployees.SelectedValue);
            FillDataSet(Convert.ToDateTime(txtDate.Text));
            txtDay.Text = Convert.ToDateTime(txtDate.Text).DayOfWeek.ToString();
            //Response.Write("HI");
            GetTotalCheckInHours(contactID, Convert.ToDateTime(txtDate.Text));
        }

        private void ibtnCallender_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            //			Calendar1.Visible=true;
        }
    }
}
