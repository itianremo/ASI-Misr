
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

namespace TSN.ERP.WebGUI.Go
{
	/// <summary>
	/// Summary description for frmEmpJobtitle.
	/// </summary>
	public partial class frmEmpJobtitle : System.Web.UI.Page
	{
		protected TSN.ERP.SharedComponents.Data.dsJobtitles dsJobtitles1;
		protected TSN.ERP.SharedComponents.Data.dsResponsblities dsResponsblities1;
		protected TSN.ERP.SharedComponents.Data.dsAccountabilitySheet dsAccountabilitySheet1;
		protected TSN.ERP.SharedComponents.Data.dsProjects dsProjects1;
		MasterMethods master = new MasterMethods();

//		string EmpCode="300000",EmpName="AA AA AA",EmpJobTitleID="1",EmpJobTitleName="Vice President";
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialze the page here
			Navigation.BaseObject.SafeMerge(dsProjects1,((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.ListAllProjects());

			if( !IsPostBack )
			{
//				Navigation.BaseObject.SafeMerge(dsJobtitles1,((Navigation.BaseObject) Session[ "navigation" ]).JobTiltesWsObject.ListJobtitles());
				Navigation.BaseObject.SafeMerge(dsJobtitles1,((Navigation.BaseObject) Session[ "navigation" ]).JobTiltesWsObject.ListActiveJobtitles());
				lstJobs.DataBind();

				lblCode.Text = Session["code"].ToString();
				lblName.Text = Session["name"].ToString();
				lblCurrentJobTitle.Text = Session["EmpJobTitleName"].ToString();
				try
				{
					lstJobs.SelectedValue = Session["EmpJobTitleID"].ToString();
				}
				catch
				{
				}
                //DataSource="<%# dsResponsblities1 %>" DataTextField="ResponsName" DataValueField="ResponsID"
				lstJobs_SelectedIndexChanged(null, null);
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
			this.dsJobtitles1 = new TSN.ERP.SharedComponents.Data.dsJobtitles();
			this.dsResponsblities1 = new TSN.ERP.SharedComponents.Data.dsResponsblities();
			this.dsAccountabilitySheet1 = new TSN.ERP.SharedComponents.Data.dsAccountabilitySheet();
			this.dsProjects1 = new TSN.ERP.SharedComponents.Data.dsProjects();
			((System.ComponentModel.ISupportInitialize)(this.dsJobtitles1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsResponsblities1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsAccountabilitySheet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsProjects1)).BeginInit();
			this.grdTasks.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grdTasks_ItemDataBound);
			// 
			// dsJobtitles1
			// 
			this.dsJobtitles1.DataSetName = "dsJobtitles";
			this.dsJobtitles1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// dsResponsblities1
			// 
			this.dsResponsblities1.DataSetName = "dsResponsblities";
			this.dsResponsblities1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// dsAccountabilitySheet1
			// 
			this.dsAccountabilitySheet1.DataSetName = "dsAccountabilitySheet";
			this.dsAccountabilitySheet1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// dsProjects1
			// 
			this.dsProjects1.DataSetName = "dsProjects";
			this.dsProjects1.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.dsJobtitles1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsResponsblities1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsAccountabilitySheet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsProjects1)).EndInit();

		}
		#endregion

		protected void lstJobs_SelectedIndexChanged(object sender, System.EventArgs e)
		{
//			Navigation.BaseObject.SafeMerge(dsResponsblities1,((Navigation.BaseObject) Session[ "navigation" ]).JobTiltesWsObject.ListJobResponsbilities( int.Parse( lstJobs.SelectedValue ) ));
			Navigation.BaseObject.SafeMerge(dsResponsblities1,((Navigation.BaseObject) Session[ "navigation" ]).JobTiltesWsObject.ListActiveJobResponsbilities( int.Parse( lstJobs.SelectedValue ) ));
			Navigation.BaseObject.SafeMerge(dsAccountabilitySheet1,((Navigation.BaseObject) Session[ "navigation" ]).AccountabilityWSObject.GetAccSheet(Convert.ToInt32(Session["contactID"].ToString()),DateTime.Now,10,false));

            for (int ResCount = 0; ResCount < dsResponsblities1.Tables[0].Rows.Count; ResCount++)
            {
                dsResponsblities1.Tables[0].Rows[ResCount]["ResponsName"] = dsResponsblities1.Tables[0].Rows[ResCount]["ResponsName"].ToString().Trim();
            }
            dsResponsblities1.AcceptChanges();

			//Filtering Acc Sheet to contain tasks only
			DataRow dr = dsAccountabilitySheet1.Tables[0].NewRow();
			for(int i=dsAccountabilitySheet1.Tables[0].Rows.Count-1;i>=0;i--)
			{
				dr = dsAccountabilitySheet1.Tables[0].Rows[i];
				if (dr["RecoredType"].ToString() != "10" || dr["AssStatus"].ToString().Trim() == "3") // if (project or responsibility) or (completed task)
				{
					dsAccountabilitySheet1.Tables[0].Rows.RemoveAt(i) ;   // remove it from dataset
				}
			}


			grdTasks.DataBind();
		}

		protected void BtnSave_Click(object sender, System.EventArgs e)
		{
			//Check if all tasks are either closed or moved to any resp. of the new job title:
			foreach(DataGridItem DGI in grdTasks.Items)
			{
				DropDownList ddl = ((DropDownList)DGI.Cells[0].Controls[1]);
				CheckBox chk = ((CheckBox)DGI.Cells[4].Controls[1]);
				if((ddl.SelectedValue == "-1" && !chk.Checked) || (ddl.SelectedValue != "-1" && chk.Checked))
				{
					//Navigation.BaseObject.showMessage("For all tasks: You must either close the task or add it to another responsibility",this);
                    Navigation.BaseObject.showMessage("For all tasks:" + "\n" + "You must either close the task or add it to another responsibility", this);
					return;
				}
			}

			//Either close task or move to another resposibility
			foreach(DataGridItem DGI in grdTasks.Items)
			{
				DropDownList ddl = ((DropDownList)DGI.Cells[0].Controls[1]);
				CheckBox chk = ((CheckBox)DGI.Cells[4].Controls[1]);
				if(chk.Checked)
				{
                    if (DGI.Cells[1].Text.Trim() != String.Empty && DGI.Cells[1].Text.Trim() != "&nbsp;")
					{
                        ((Navigation.BaseObject)Session["navigation"]).TaskWSObject.CloseAssignment(int.Parse(DGI.Cells[5].Text.Trim()));
					}
					else
					{
                        int TaskID = int.Parse(((Navigation.BaseObject)Session["navigation"]).TaskWSObject.ViewAssignmentTask(int.Parse(DGI.Cells[5].Text.Trim())).Tables[0].Rows[0]["TaskID"].ToString());
						((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.CompleteTask(TaskID);
					}
				}
				else
				{
                    ((Navigation.BaseObject)Session["navigation"]).TaskWSObject.ChangeResponsbility(int.Parse(DGI.Cells[5].Text.Trim()), int.Parse(ddl.SelectedValue));
				}
			}

			//Update Employee Job Title:
			TSN.ERP.SharedComponents.Data.dsEmployee.GEN_EmployeesRow row;
			TSN.ERP.SharedComponents.Data.dsEmployee dsEmployee = new TSN.ERP.SharedComponents.Data.dsEmployee();
			Navigation.BaseObject.SafeMerge(dsEmployee,((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListSingleEmployeeData(int.Parse(Session["contactID"].ToString())));
			row	=(TSN.ERP.SharedComponents.Data.dsEmployee.GEN_EmployeesRow)dsEmployee.Tables[0].Rows[0];
			row.JobTitleID = int.Parse(lstJobs.SelectedValue);
			((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ModifyEmployee(dsEmployee);
			//Add Employee JobTitle Entry:
			((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.AddEmployeesJobTitle(row.ContactID,row.JobTitleID,DateTime.Now);
//			if(grdTasks.Items.Count == 0)
//			{
//				grdTasks.ShowHeader = false;
//			}
//			else
//			{
//				grdTasks.ShowHeader = true;
//			}
//			Navigation.BaseObject.showMessage("Job title and tasks have been updated successfully",this);
			this.RegisterStartupScript("dd","<script language='JavaScript'>alert('Job title and tasks have been updated successfully')</script>");
		}

		private void grdTasks_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				if(e.Item.Cells[1].Text.Trim() != string.Empty && e.Item.Cells[1].Text.Trim() != "&nbsp;")
				{
					e.Item.Cells[2].Text = dsProjects1.GEN_Projects.FindByprojectID(int.Parse(e.Item.Cells[1].Text.Trim())).ProjectName;
                    e.Item.Cells[2].BackColor = System.Drawing.Color.GreenYellow;
				}
				else
				{
					e.Item.Cells[2].Text = string.Empty;
                    e.Item.Cells[2].BackColor = System.Drawing.Color.White;
				}
                e.Item.Cells[3].BackColor = System.Drawing.Color.White;
				DropDownList newResp = ((DropDownList)e.Item.FindControl("DropDownListNewResp"));
				newResp.Items.Insert(0,new ListItem("--------------------","-1"));
                try
                {
                    newResp.SelectedValue = newResp.Items.FindByText(e.Item.Cells[7].Text.Trim()).Value;
                   // newResp.BackColor = System.Drawing.Color.Yellow;
                    //newResp.Items.FindByText(e.Item.Cells[7].Text).Attributes.Add("style", "font-weight:bold");
                   // newResp.Items.FindByText(e.Item.Cells[7].Text).Attributes.Add("Style", "Color:yellow");
                    newResp.Items.FindByText(e.Item.Cells[7].Text.Trim()).Attributes.Add("Style", "background-color:Yellow");
                  
                    //newResp.SelectedValue = newResp.Items.FindByText("Maintain Addition and subtraction taxes and submit their qua").Value;
                }
                catch(Exception ex)
                {
                    string mesg = ex.Message;
                }
			}
		}

		protected void lstJobs_DataBinding(object sender, System.EventArgs e)
		{
			//Sort Job Titles DataSet//////////////////////////////////
			DataView dvJT = dsJobtitles1.GEN_JobTitles.DefaultView;
			dvJT.Sort = "JobName";
			dsJobtitles1.Tables.Clear();
			dsJobtitles1.Tables.Add(master.CreateTableFromView(dvJT));
			//////////////////////////////////////////////////////////
		}
	}
}
