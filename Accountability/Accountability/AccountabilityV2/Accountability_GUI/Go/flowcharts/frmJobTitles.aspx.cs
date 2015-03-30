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

namespace TSN.ERP.WebGUI.Go.flowcharts
{
	/// <summary>
	/// This form is used to set all attributes concerning job-titles chart
	/// </summary>
	public partial class frmJobTitles : System.Web.UI.Page
	{
		//------------------------------------------------------------------------------------
		#region Class memebrs
		protected System.Web.UI.WebControls.CheckBox chkEmpProjects;
		TSN.ERP.WebGUI.Go.dbTreeView tvElementsList;
		#endregion
		//------------------------------------------------------------------------------------
		#region Page load
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			tvElementsList = new TSN.ERP.WebGUI.Go.dbTreeView();
            Microsoft.Web.UI.WebControls.CssCollection css = new Microsoft.Web.UI.WebControls.CssCollection();
            css.CssText = "color:#FFFFFF";
            tvElementsList.DefaultStyle = css;
			DataSet dsCompanyElements = ((Navigation.BaseObject) Session[ "navigation" ]).CompanyWsObject.ListCompnayElements();
			tvElementsList.bind(dsCompanyElements);
			PlaceHolder1.Controls.Add(tvElementsList);
			
		}
		#endregion
		//------------------------------------------------------------------------------------
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
		//------------------------------------------------------------------------------------
		#region chkEmpName event handler
		protected void chkEmpName_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkEmpName.Checked)
			{
				chkEmpCode.Enabled = true;
				chkEmpPhoto.Enabled = true;
				chkEmpDept.Enabled = true;
			}
			else
			{
				chkEmpCode.Enabled = false;
				chkEmpCode.Checked = false;
				chkEmpPhoto.Enabled = false;
				chkEmpPhoto.Checked = false;
				chkEmpDept.Enabled = false;
				chkEmpDept.Checked = false;
			}
		}
		#endregion
		//------------------------------------------------------------------------------------
		#region Next button event handler
		protected void btnNext_Click(object sender, System.EventArgs e)
		{
			if(chkEmpName.Checked == false && chkEmpNo.Checked == false && chkDeptManager.Checked == false && chkJobEmpNo.Checked == false)
			{
				lblMSG.Text ="Please check at least one chart parameter";
				return ;
			}

			else if(tvElementsList.Nodes.Count ==0)
			{
				lblMSG.Text ="There is no job title to create flowchart for it.";
				return ;
			
			}
			TitlesChart titleChart = (TitlesChart)Session["chartObject"];
			titleChart.CompElementID = tvElementsList.getSelectedNode().CompElmentId;
			titleChart.CompElementName = tvElementsList.getSelectedNode().CEName;
			titleChart.ShowEmpName = chkEmpName.Checked;
			titleChart.ShowDeptManager = chkDeptManager.Checked;
			titleChart.ShowDeptEmpNo = chkEmpNo.Checked;
			titleChart.ShowEmpCode = chkEmpCode.Checked;
			titleChart.ShowTitleEmpNo = chkJobEmpNo.Checked;
			titleChart.ShowEmpPhoto = chkEmpPhoto.Checked;
			titleChart.ShowEmpDept = chkEmpDept.Checked;
			Session["chartObject"] = titleChart;
			Session["chartType"] = (int)Chart.ChartTypes.TitleChart; // Job titles hierarchy
			Response.Redirect("frmColors.aspx?chartname="+Request.QueryString["chartname"]+"&action="+Request.QueryString["action"]+"&chartid="+Request.QueryString["chartid"]);
		}
		#endregion
		//------------------------------------------------------------------------------------
		#region Back button event handler
		protected void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("frmCreateNewChart.aspx?chartname="+Request.QueryString["chartname"]+"&action="+Request.QueryString["action"]+"&chartid="+Request.QueryString["chartid"]);
		}
		#endregion
		//------------------------------------------------------------------------------------
	}
}
