using System;
using System.Drawing;
using MindFusion.FlowChartX.LayoutSystem;
using MindFusion.FlowChartX;
using System.Collections;
using System.Data; 

namespace TSN.ERP.WebGUI.Go.flowcharts
{
	/// <summary>
	/// Teams chart
	/// </summary>

	public class TeamsChart :Chart
	{	
		//--------------------------------------------------------------------------------
		#region Constructor 
		/// <summary>
		/// Here we call the parent (Chart) constructor, which fill all dataview we may use during rendering process
		/// </summary>
		public TeamsChart( ):base( )
		{}
		#endregion
		//--------------------------------------------------------------------------------
		#region Render team chart
		public override FlowChart Render()
		{
			fc = new FlowChart();
			InitFlowChart(fc);
			for (int i=0;i< this.TeamsIDs.Count ;i++)
			{
				float rowHeight = this.TeamFont.Size * 3;
				Table node = fc.CreateTable(0, 0, fc.TableColWidth, rowHeight * GetRowsNumber(4) + 1);
				DataSet dsTeam = ((Navigation.BaseObject) System.Web.HttpContext.Current.Session[ "navigation" ]).TeamsWSObject.ListTeam(int.Parse(TeamsIDs[i].ToString()));
				node.RowHeight = rowHeight;
				node.FillColor = this.TeamBackColor;
				node.FrameColor = this.TeamBorderColor;
				AddNodeItem(node,"",dsTeam.Tables[0].Rows[0]["TeamName"].ToString(),this.TeamFontColor);
				node.Tag = dsTeam.Tables[0].Rows[0]["TeamID"].ToString();
				node.Font = this.TeamFont;
				if (this.ShowEmpName)
					DrwaEmployeesNodes(node);
				if (this.ShowTeamEmpNo)
					AddNodeItem(node,"Emp#: ",GetEmpNumber(int.Parse(TeamsIDs[i].ToString())).ToString(),this.TeamEmpNoFontColor);
				if (this.ShowTeamLeader)
				{
					string teamLeader = GetTeamLeader( dsTeam.Tables[0].Rows[0]["TeamLeader"].ToString());
					AddNodeItem(node,"Ldr: ",teamLeader,this.TeamLeaderFontColor);
				}
			}
			// set up chart layout and arrows type
			SetChartLayout(fc);
			return fc;
		}
		#endregion
		//--------------------------------------------------------------------------------
		#region Draw employees nodes
		private void DrwaEmployeesNodes(Table teamNode)
		{
			DataSet dsEmp = ((Navigation.BaseObject) System.Web.HttpContext.Current.Session[ "navigation" ]).TeamsWSObject.ListTeamEmployees(int.Parse(teamNode.Tag.ToString()));
            DataView dvEmp = dsEmp.Tables[0].DefaultView;
            dvEmp.RowFilter = "EmployeeStatus = 1";
            //dvEmp.Sort = "FirstName, MiddleName, LastName";
            dsEmp.Tables.Clear();
            dsEmp.Tables.Add(CreateTable(dvEmp));

			foreach(DataRow dr in dsEmp.Tables[0].Rows)			
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
				fc.CreateArrow(teamNode,empNode);		
			}
		}
		#endregion
		//--------------------------------------------------------------------------------
		#region Returns team leader name
		private string GetTeamLeader(string teamLeaderID)
		{
			try
			{
				DataSet dsEmp = ((Navigation.BaseObject) System.Web.HttpContext.Current.Session[ "navigation" ]).EmployeeWsObject.ListSingleEmployeeData(int.Parse(teamLeaderID));
                DataView dvEmp = dsEmp.Tables[0].DefaultView;
                dvEmp.RowFilter = "EmployeeStatus = 1";
                dsEmp.Tables.Clear();
                dsEmp.Tables.Add(CreateTable(dvEmp));
                if (dsEmp.Tables[0].Rows.Count == 0) return "";
				else return dsEmp.Tables[0].Rows[0]["FirstName"].ToString() + " " + dsEmp.Tables[0].Rows[0]["MiddleName"].ToString()
					+ " " + dsEmp.Tables[0].Rows[0]["LastName"].ToString(); 
			}
			catch(Exception ex)
			{
				return "";
			}
		}
		#endregion
		//--------------------------------------------------------------------------------
		#region Returns the number of employees in given team
		private int GetEmpNumber(int teamID) 
		{
			//return ((Navigation.BaseObject) System.Web.HttpContext.Current.Session[ "navigation" ]).TeamsWSObject.ListTeamEmployees(teamID).Tables[0].Rows.Count;
            DataView dvEmp = ((Navigation.BaseObject)System.Web.HttpContext.Current.Session["navigation"]).TeamsWSObject.ListTeamEmployees(teamID).Tables[0].DefaultView;
            dvEmp.RowFilter = "EmployeeStatus = 1";
            return dvEmp.Table.Rows.Count;
		}
		#endregion
		//--------------------------------------------------------------------------------
	}
}
