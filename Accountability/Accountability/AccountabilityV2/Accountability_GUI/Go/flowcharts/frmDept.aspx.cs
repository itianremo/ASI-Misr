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
using TSN.ERP.WebGUI;

namespace TSN.ERP.WebGUI.Go.flowcharts
{
	/// <summary>
	/// Summary description for frmDeptHierarchy.
	/// </summary>
	public partial class frmDeptHierarchy : System.Web.UI.Page
	{
		#region Class member
		protected System.Web.UI.WebControls.CheckBox chkEmpTeams;
		protected System.Web.UI.WebControls.CheckBox chkEmpProjects;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		TSN.ERP.WebGUI.Go.dbTreeView tvElementsList;
		#endregion
		//-----------------------------------------------------------------------
		#region Page load
		protected void Page_Load(object sender, System.EventArgs e)
		{
			tvElementsList = new dbTreeView(); // Company element tree view
            tvElementsList.ForeColor = Color.Black;
			// get all company elements
			DataSet dsCompanyElements = ((Navigation.BaseObject) Session[ "navigation" ]).CompanyWsObject.ListCompnayElements();
			tvElementsList.bind(dsCompanyElements);  //load company elements into tree view
//			tvElementsList.ExpandLevel = 1; 
			PlaceHolder1.Controls.Add(tvElementsList);
			if (!IsPostBack)
			{
				try
				{
					// load current chart parameters
					Chart chart = ChartFactory.LoadChart(1);  // 1 is the type of department hierarchy
					if (chart.CompElementID.ToString() != "")
					{
						if(Session["TreeExpandLevel"] == null)
						{
							tvElementsList.ExpandLevel=0;
						}
						else
						{
							tvElementsList.ExpandLevel = (int)Session["TreeExpandLevel"];
						}
						tvElementsList.SelectedNodeIndex = Session["selectedNode"].ToString();
						chkEmpName.Checked = chart.ShowEmpName;
						if (chkEmpName.Checked)
						{
							chkEmpCode.Enabled = true;
							chkEmpJob.Enabled = true;
						}
						chkEmpNo.Checked = chart.ShowDeptEmpNo;
						chkGrpByEmpTitles.Checked = chart.GroupByEmpTitles;
						chkEmpCode.Checked = chart.ShowEmpCode;
						chkEmpJob.Checked = chart.ShowEmpTitle;
						chkEmpPhoto.Checked = chart.ShowEmpPhoto;
						chkJobEmpNo.Checked = chart.ShowTitleEmpNo;
						chkJobEmpNo.Enabled = chart.GroupByEmpTitles?true:false;
						// enable show photo checkbox if user has selected show employee option
						chkEmpPhoto.Enabled = chart.ShowEmpName?true:false;
						chkDeptManager.Checked = chart.ShowDeptManager;
                        IntializeSelection();
					}
				}
				catch(Exception ex)
				{
					Response.Write(ex.Message);
				}
			}
			
		}

        protected void IntializeSelection()
        {
            chkEmpName.Checked = true;
            chkEmpCode.Enabled = true;
            chkEmpPhoto.Enabled = true;
            if (!chkGrpByEmpTitles.Checked)
                chkEmpJob.Enabled = true;

            chkEmpJob.Checked = true;
            chkEmpPhoto.Checked = true;
            chkDeptManager.Checked = true;
        
        }
		#endregion
		//-----------------------------------------------------------------------
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
		//-----------------------------------------------------------------------
		#region chkShowEmployee event handler
		protected void chkEmpName_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkEmpName.Checked)
			{
				chkEmpCode.Enabled = true;
				chkEmpPhoto.Enabled = true;
				if (!chkGrpByEmpTitles.Checked)
					chkEmpJob.Enabled = true;
			}
			else
			{
				chkEmpCode.Enabled = false;
				chkEmpJob.Enabled = false;
				chkEmpCode.Checked = false;
				chkEmpJob.Checked = false;
				chkEmpPhoto.Enabled = false;
				chkEmpPhoto.Checked = false;
			}
		}
		#endregion
		//-----------------------------------------------------------------------
		#region GrpByEmpTitlesroup event handler
		protected void chkGrpByEmpTitles_CheckedChanged(object sender, System.EventArgs e)
		{
			chkJobEmpNo.Enabled = chkGrpByEmpTitles.Checked;
			chkJobEmpNo.Checked = false; 
			chkEmpJob.Enabled = (chkEmpName.Checked) ? true :chkEmpJob.Checked;
		}
		#endregion
		//-----------------------------------------------------------------------
		#region Next button
		protected void btnNext_Click(object sender, System.EventArgs e)
		{
			// store the selected node in a session variable
			if(chkEmpName.Checked == false && chkEmpNo.Checked == false && chkDeptManager.Checked == false && chkGrpByEmpTitles.Checked == false)
			{
				lblMSG.Text ="Please check at least one chart parameter";
				return ;
			}
			else if(tvElementsList.Nodes.Count ==0)
			{
				lblMSG.Text ="Add department(s) first to create flowchart for it.";
				return ;
			
			}			
			Session["selectedNode"] = tvElementsList.SelectedNodeIndex;
			int TreeExpandLevel = tvElementsList.SelectedNodeIndex.Split(new char[]{'.'}).Length;
			Session["TreeExpandLevel"] = TreeExpandLevel-1;
			Chart chart = ChartFactory.LoadChart(1);
		    chart.CompElementID = tvElementsList.getSelectedNode().CompElmentId;
			chart.CompElementName = tvElementsList.getSelectedNode().CEName;
			chart.ShowEmpName = chkEmpName.Checked;
			chart.ShowDeptManager = chkDeptManager.Checked;
			chart.ShowDeptEmpNo = chkEmpNo.Checked;
			chart.GroupByEmpTitles = chkGrpByEmpTitles.Checked;
			chart.ShowEmpCode = chkEmpCode.Checked;
			chart.ShowTitleEmpNo = chkJobEmpNo.Checked;
			chart.ShowEmpTitle = chkEmpJob.Checked;
			chart.ShowEmpPhoto = chkEmpPhoto.Checked;
			Session["chartObject"] = chart;
			Session["chartType"] = (int)Chart.ChartTypes.DeptChart; // department hierarchy

			Response.Redirect("frmColors.aspx?chartname="+Request.QueryString["chartname"]+"&action="+Request.QueryString["action"]+"&chartid="+Request.QueryString["chartid"]);
		}
		#endregion
		//-----------------------------------------------------------------------
		#region  Back button
		protected void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("frmCreateNewChart.aspx?chartname="+Request.QueryString["chartname"]+"&action="+Request.QueryString["action"]+"&chartid="+Request.QueryString["chartid"]);
		}
		#endregion
		//-----------------------------------------------------------------------
		#region chkEmpJob event handler
		protected void chkEmpJob_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkEmpJob.Checked)
			{
				chkGrpByEmpTitles.Checked = false;
				chkGrpByEmpTitles.Enabled = false;
				chkJobEmpNo.Enabled = false;
				chkJobEmpNo.Checked = false;
			}
			else
			{
				chkGrpByEmpTitles.Enabled = true;
			}
		}
		#endregion
		//-----------------------------------------------------------------------
	}
}
