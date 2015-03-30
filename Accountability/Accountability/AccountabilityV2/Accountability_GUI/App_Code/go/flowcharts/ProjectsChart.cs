using System;
using System.Drawing;
using MindFusion.FlowChartX.LayoutSystem;
using MindFusion.FlowChartX;
using System.Data;
using System.Collections;

namespace TSN.ERP.WebGUI.Go.flowcharts
{
	/// <summary>
	/// Projects chart
	/// </summary>
	public class ProjectsChart : Chart
	{
		//----------------------------------------------------------------------------
		#region Constructor
		/// <summary>
		/// Here we call the parent (Chart) constructor, which fill all dataview we may use during rendering process
		/// </summary>
		public ProjectsChart( ):base( )
			{	
			}
		#endregion
		//----------------------------------------------------------------------------
		#region Render project chart
		public override FlowChart Render()
		{
			// get all jobs
			dvJobs = ((Navigation.BaseObject) System.Web.HttpContext.Current.Session[ "navigation" ]).JobTiltesWsObject.ListJobtitles().Tables[0].DefaultView;
			// Chart general properties
			dvDept = ((Navigation.BaseObject) System.Web.HttpContext.Current.Session[ "navigation" ]).CompanyWsObject.ListCompnayElements().Tables[0].DefaultView;
			// Chart general properties
			fc = new FlowChart();
			InitFlowChart(fc);
			
			//Looping through selected list of current projects arraylist
			for (int i=0;i< this.ProjectsIDs.Count ;i++)
			{
				/////////////////////configure project node row height based on selcted font///////////////////////

				float rowHeight = this.ProjectFont.Size * 3;
                float mglilh = rowHeight * GetRowsNumber(5) + 1;
				Table node = fc.CreateTable(0, 0, fc.TableColWidth, rowHeight * GetRowsNumber(5) +1);

				//Getting details of currently selectde project
				//Using available PorjectID value, we use 'ListProject' web method to get its details from database

				TSN.ERP.SharedComponents.Data.dsProjects dsUserProjects = new TSN.ERP.SharedComponents.Data.dsProjects();
				Navigation.BaseObject.SafeMerge(dsUserProjects, ((Navigation.BaseObject) System.Web.HttpContext.Current.Session[ "navigation" ]).ProjectWSObject.ListUserProjects());
				TSN.ERP.SharedComponents.Data.dsProjects.GEN_ProjectsRow drProject = dsUserProjects.GEN_Projects.FindByprojectID(int.Parse(ProjectsIDs[i].ToString()));


//				DataSet dsProject = ((Navigation.BaseObject) System.Web.HttpContext.Current.Session[ "navigation" ]).ProjectWSObject.ListProject(int.Parse(ProjectsIDs[i].ToString()));
				node.FillColor = this.ProjectBackColor;
				node.FrameColor = this.ProjectBorderColor;
				node.RowHeight = rowHeight;
//				AddNodeItem(node,"",dsProject.Tables[0].Rows[0]["ProjectName"].ToString(),this.ProjectFontColor);
//				node.Tag = dsProject.Tables[0].Rows[0]["projectID"].ToString();
				AddNodeItem(node,"",drProject["ProjectName"].ToString(),this.ProjectFontColor);
				node.Tag = drProject["projectID"].ToString();
				node.Font = this.ProjectFont;
				//Testing user diagram configurations 
				if (this.ShowEmpName)  // Show employees nodes 
					DrawEmployeesNodes(node);
				if (this.ShowProjectEmpNo) //Show number of employees in each project by adding new row with needed value
					AddNodeItem(node,"Emp#: ",GetEmpNumber(int.Parse(ProjectsIDs[i].ToString())).ToString(),this.ProjectEmpNoFontColor);
				if(this.ShowProjectManager)
				{
//					string projectManager = GetProjectManager(dsProject.Tables[0].Rows[0]["ProjectManager"].ToString());
					string projectManager = GetProjectManager(drProject["ProjectManager"].ToString());
					AddNodeItem(node,"",projectManager,this.ProjectManagerFontColor);
				}
			}
			// set chart layout
			SetChartLayout(fc);
			return fc;
		}
		#endregion
		//----------------------------------------------------------------------------
		#region Draw employees nodes working on given project
		private void DrawEmployeesNodes(Table projectNode)
		{
			DataSet empDS = ((Navigation.BaseObject) System.Web.HttpContext.Current.Session[ "navigation" ]).ProjectWSObject.ListProjectEmployees(int.Parse(projectNode.Tag.ToString()));
            DataView dvEmp = empDS.Tables[0].DefaultView;
            dvEmp.RowFilter = "EmployeeStatus = 1";
            //dvEmp.Sort = "FirstName, MiddleName, LastName";
            empDS.Tables.Clear();
            empDS.Tables.Add(CreateTable(dvEmp));

			foreach(DataRow dr in empDS.Tables[0].Rows)			
			{
				float rowHeight = this.EmpFont.Size * 3;
                
				Table empNode = fc.CreateTable(1, 1,fc.TableColWidth, rowHeight * GetRowsNumber(1) + 1);
				empNode.FillColor= this.EmpBackColor;
				empNode.FrameColor = this.EmpBorderColor;
				empNode.RowHeight = rowHeight;
				AddNodeItem(empNode,"", dr["FirstName"].ToString() + " " + 
					dr["MiddleName"].ToString() + " " + 
					dr["LastName"].ToString(),this.EmpNameFontColor);

				empNode.Tag = dr["ContactID"].ToString() ;
				empNode.Font = this.EmpFont;
				if(this.ShowEmpCode)
				{
					AddNodeItem(empNode,"Code :",dr["EmpCode"].ToString(),this.EmpCodeFontColor);
				}
				if (this.ShowEmpDept)
				{
					dvDept.RowFilter = "CompElmentID =" + dr["CompElmentID"].ToString();
					AddNodeItem(empNode,"",dvDept[0]["CEName"].ToString(),this.EmpDeptFontColor);
				}
				if (this.ShowEmpTitle)
				{
					dvJobs.RowFilter = "JobTitleID = " + dr["JobTitleID"].ToString() ;
					AddNodeItem(empNode,"",dvJobs[0]["JobName"].ToString(),this.EmpTitleFontColor);
				}
				if (this.ShowEmpPhoto)
				{
					empNode.AddRow();
					empNode[0,empNode.RowCount-1].Picture = getEmpImage(int.Parse(dr["ContactID"].ToString()));
					empNode.Rows[empNode.RowCount-1].Height = rowHeight + 50 ;
					empNode.Resize(fc.TableColWidth , rowHeight * GetRowsNumber(1) + 51); 
					empNode.FitSizeToPicture();
				}
				fc.CreateArrow(projectNode,empNode);	
			}
		}
		#endregion
		//----------------------------------------------------------------------------
		#region Returns number of employee working on given project
		protected  int GetEmpNumber(int projectID) 
		{
			//return ((Navigation.BaseObject) System.Web.HttpContext.Current.Session[ "navigation" ]).ProjectWSObject.ListProjectEmployees(projectID).Tables[0].Rows.Count;
            DataView dvEmp = ((Navigation.BaseObject)System.Web.HttpContext.Current.Session["navigation"]).ProjectWSObject.ListProjectEmployees(projectID).Tables[0].DefaultView;
            dvEmp.RowFilter = "EmployeeStatus = 1";
            return dvDept.Table.Rows.Count;
           
		}
		#endregion
		//----------------------------------------------------------------------------
		#region Returns project manager name
		//-------------------------------------------------------------------------------
		/// <summary>
		/// Returns project manager name having the given ID
		/// </summary>
		/// <param name="teamLeaderID"></param>
		/// <returns>Project manager name</returns>
		private string GetProjectManager(string projectManagerID)
		{
			try
			{
				DataSet dsEmp = ((Navigation.BaseObject) System.Web.HttpContext.Current.Session[ "navigation" ]).EmployeeWsObject.ListSingleEmployeeData(int.Parse(projectManagerID));
				return dsEmp.Tables[0].Rows[0]["FirstName"].ToString() + " " + dsEmp.Tables[0].Rows[0]["MiddleName"].ToString()
					+ " " + dsEmp.Tables[0].Rows[0]["LastName"].ToString(); 
			}
			catch(Exception ex)
			{
				return "";
			}
		}
		#endregion
		//----------------------------------------------------------------------------



	}
}
