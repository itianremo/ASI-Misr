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
	/// Summary description for frmAccTask.
	/// </summary>
	public partial class frmPopup : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		public int AssignmentID;
		public DateTime dtAssDate;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Register this form as Ajax compliant
			Ajax.Utility.RegisterTypeForAjax(typeof(frmPopup));
		
			string[] vars = null;
			if (Request["type"] == "addTask")
			{
				vars =  Request["vars"].ToString().Split('$');
				vars[3] = vars[3].Replace("_*_","&");
				CTask task = new CTask(int.Parse(vars[0]),vars[1],int.Parse(vars[2]),vars[3]);
				Session["task"] = task;
				hldTask.Controls.Add(LoadControl("ctlTask.ascx"));	
			}
			else if (Request["type"] == "editTask")
			{
				vars =  Request["vars"].ToString().Split('$');
				vars[3] = vars[3].Replace("_*_","&");
				DataSet dsAss = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewAssignmentData(int.Parse(vars[4]));
				if ( dsAss != null && dsAss.Tables[0].Rows.Count != 0 )
				{
					CTask task = new CTask(int.Parse(vars[0]), vars[1],vars[3],"",int.Parse(dsAss.Tables[0].Rows[0]["TaskID"].ToString()) ,int.Parse(vars[4]),true);
					Session["task"] = task;
					hldTask.Controls.Add(LoadControl("ctlTask.ascx"));
				}
				else
				{
					hldTask.Controls.Add( LoadControl("AccessRightErrMsg.ascx")  );
				}
			}
			else if (Request["type"] == "findemp")
			{
				if(Request.QueryString.Get("page") == "projectlist")
				{
					Session["Page_Project_List"]="Page_Project_List";
					hldTask.Controls.Add(LoadControl("EmployeeMainSearch.ascx"));	
				}
				else
				{
					hldTask.Controls.Add(LoadControl("EmployeeMainSearch.ascx"));	
				}
			}
			else if (Request["type"] == "completetask")
			{
				vars =  Request["vars"].ToString().Split('$');
//				Label1.Text = Request["vars"].ToString();
				txtTask.Text = vars[1];
				AssignmentID = int.Parse(vars[0]);
				dtAssDate = DateTime.Parse(vars[2]);
				hldTask.Visible = false;
				pnlCloseTask.Visible = true;
			}

			else if (Request["type"] == "changeResp")
			{
				vars =  Request["vars"].ToString().Split('$');
				vars[3] = vars[3].Replace("_*_","&");
				DataSet dsAss = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewAssignmentData(int.Parse(vars[4]));
				if ( dsAss != null && dsAss.Tables[0].Rows.Count != 0 )
				{
					CTask task = new CTask(int.Parse(vars[0]), vars[1],vars[3],"",int.Parse(dsAss.Tables[0].Rows[0]["TaskID"].ToString()) ,int.Parse(vars[4]),true);
					Session["task"] = task;
					hldTask.Controls.Add(LoadControl("ChangAsskResponsibility.ascx"));
				}
				else
				{
					hldTask.Controls.Add( LoadControl("AccessRightErrMsg.ascx")  );
				}
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

		protected void btnOk_Click(object sender, System.EventArgs e)
		{
			if(Page.IsValid)
			{
				string x=MComplete(AssignmentID, dtAssDate.ToShortDateString(), false);
//				try
//				{
//					DataSet dsTask = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewAssignmentTask(AssignmentID);
//					int taskID = int.Parse(dsTask.Tables[0].Rows[0]["TaskID"].ToString());
//
//					//Check if the closing date is out of the current week
//					int weekDatCount = -(int)dtAssDate.DayOfWeek;
//					DateTime weekStart = dtAssDate.AddDays(weekDatCount);
////					DateTime weekEnd = weekStart.AddDays(6);
//					if(weekStart > DateTime.Now)
//					{
//						lblMsg.Text = "Can't open/complete tasks in a date greater than current week date";
//						return;
//					}
//
//
//					DataSet dsAss = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewAssignmentData(AssignmentID);
//					DataSet dsResps = ((Navigation.BaseObject)Session[ "navigation" ]).JobTiltesWsObject.ListResponsbilities();
//					int respID = Convert.ToInt32(dsResps.Tables[0].Select("ResponsID='"+dsAss.Tables[0].Rows[0]["ResponsID"].ToString()+"'")[0]["ResponsID"]);
//					bool IsActive = Convert.ToBoolean(dsResps.Tables[0].Select("ResponsID='"+respID+"'")[0]["IsActive"]);
//
////					int taskStatus=Convert.ToInt32(dsTask.Tables[0].Rows[0]["TaskStatus"]);
////					int assStatus=Convert.ToInt32(dsAss.Tables[0].Rows[0]["AssignmentStatus"]);
//					if(!IsActive /*&& (taskStatus == 0 || assStatus == 3)*/)
//					{
//						lblMsg.Text = "Can't open/complete tasks under complete responsibilities";
//						return;
//					}
//
//
//					if(dsTask.Tables[0].Rows[0]["projectID"] == DBNull.Value)
//					{
//						((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.CompleteTask(taskID,txtComment.Text);
//					}
//					else
//					{							
//						if(Convert.ToInt32(dsAss.Tables[0].Rows[0]["AssignmentStatus"]) == 1)
//						{
//							((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.CloseAssignment(AssignmentID);
//						}
//						else if(Convert.ToInt32(dsAss.Tables[0].Rows[0]["AssignmentStatus"]) == 3)
//						{
//							//Check if project is complete, if true, don't open the assignment
//							DataSet dsProject = ((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.ListProject(Convert.ToInt32(dsTask.Tables[0].Rows[0]["projectID"]));
//							if(Convert.ToInt32(dsProject.Tables[0].Rows[0]["ProjectStatus"]) == 0)
//							{
//								lblMsg.Text = "Can't open tasks under complete projects";
//								return;
//							}
//							////////////////////////////////////////////////////////////////////
//							((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.OpenAssignment(AssignmentID);
//						}
////						((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.SetTaskNote(taskID, txtComment.Text);	
//					}
//					
//					lblMsg.Text = "Saved";
//					txt1.Value = "1";
//				}
//				catch(Exception ex)
//				{
//					lblMsg.Text = "Can't complete this task";
//				}
			}
		}

		
		[Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
		public string MComplete( int vniAssignmentID,string vsdate , bool isProject)
		{
			DateTime vdtAssDate=Convert.ToDateTime(vsdate);
			try
			{
				DataSet dsTask = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewAssignmentTask(vniAssignmentID);
				int taskID = int.Parse(dsTask.Tables[0].Rows[0]["TaskID"].ToString());

				//Check if the closing date is out of the current week
				int weekDatCount = -(int)vdtAssDate.DayOfWeek;
				DateTime weekStart = vdtAssDate.AddDays(weekDatCount);
				//
				//4444
				DateTime weekEnd = weekStart.AddDays(6);
				if(weekStart > DateTime.Now)
				{
					if(isProject == false)
					{
						lblMsg.Text = "Can't open/complete tasks in a date greater than current week date";
						
					}
					return null;
				}


				DataSet dsAss = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewAssignmentData(vniAssignmentID);
				DataSet dsResps = ((Navigation.BaseObject)Session[ "navigation" ]).JobTiltesWsObject.ListResponsbilities();
				int respID = Convert.ToInt32(dsResps.Tables[0].Select("ResponsID='"+dsAss.Tables[0].Rows[0]["ResponsID"].ToString()+"'")[0]["ResponsID"]);
				bool IsActive = Convert.ToBoolean(dsResps.Tables[0].Select("ResponsID='"+respID+"'")[0]["IsActive"]);

				//					int taskStatus=Convert.ToInt32(dsTask.Tables[0].Rows[0]["TaskStatus"]);
				//	
				//4444
				int assStatus=Convert.ToInt32(dsAss.Tables[0].Rows[0]["AssignmentStatus"]);
				if(!IsActive /*&& (taskStatus == 0 || assStatus == 3)*/)
				{
					if(isProject == false)
					{
						lblMsg.Text = "Can't open/complete tasks under complete responsibilities";
					}
					return null;
				}


				if(dsTask.Tables[0].Rows[0]["projectID"] == DBNull.Value)
				{
					((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.CompleteTask(taskID,txtComment.Text);
				}
				else
				{							
					if(Convert.ToInt32(dsAss.Tables[0].Rows[0]["AssignmentStatus"]) == 1)
					{
						((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.CloseAssignment(vniAssignmentID);
					}
					else if(Convert.ToInt32(dsAss.Tables[0].Rows[0]["AssignmentStatus"]) == 3)
					{
						//Check if project is complete, if true, don't open the assignment
						DataSet dsProject = ((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.ListProject(Convert.ToInt32(dsTask.Tables[0].Rows[0]["projectID"]));

						if(Convert.ToInt32(dsProject.Tables[0].Rows[0]["ProjectStatus"]) == 0)
						{
							// 4444
							if(isProject == false)
							{
								lblMsg.Text = "Can't open tasks under complete projects";
							}
							return null;
						}
						if(int.Parse(dsTask.Tables[0].Rows[0]["TaskStatus"].ToString()) == 0)
						{
							if(isProject == false)
							{
								lblMsg.Text = "Can't open assignments under complete tasks";
							}
							return null;
						}
						////////////////////////////////////////////////////////////////////
						((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.OpenAssignment(vniAssignmentID);
					}
					//						((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.SetTaskNote(taskID, txtComment.Text);	
				}

				if(isProject == false)
				{	
					lblMsg.Text = "Saved";
					txt1.Value = "1";
				}
				return "";
				
			}
			catch(Exception ex)
			{
				if(isProject == false)
				{
					lblMsg.Text = "Can't complete this task";
				}
				return "";
			}
		
		}
	}
}
