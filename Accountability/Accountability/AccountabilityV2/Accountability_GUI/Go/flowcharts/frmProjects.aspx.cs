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
	/// Project chart attributes
	/// </summary>
	public partial class frmProjects : System.Web.UI.Page
	{
		//----------------------------------------------------------------------------
		#region class members 
		protected TSN.ERP.SharedComponents.Data.dsProjects dsProjects;
		#endregion
		//----------------------------------------------------------------------------
		#region Page load
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (! IsPostBack)
			{
                 // check
//				dsProjects.safeMerge( ((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.ListAllProjects());
				Navigation.BaseObject.SafeMerge(dsProjects, ((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.ListUserProjects());
				lstProjects.DataSource = dsProjects;
				lstProjects.DataBind();
			}
		}
		#endregion
		//----------------------------------------------------------------------------
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
			this.dsProjects = new TSN.ERP.SharedComponents.Data.dsProjects();
			((System.ComponentModel.ISupportInitialize)(this.dsProjects)).BeginInit();
			// 
			// dsProjects
			// 
			this.dsProjects.DataSetName = "dsProjects";
			this.dsProjects.Locale = new System.Globalization.CultureInfo("ar-EG");
			((System.ComponentModel.ISupportInitialize)(this.dsProjects)).EndInit();

		}
		#endregion
		//----------------------------------------------------------------------------
		#region Next button
		protected void btnNext_Click(object sender, System.EventArgs e)
		{
			if(chkEmpName.Checked == false && chkProjectEmpNo.Checked == false && chkProjectManager.Checked == false )
			{
				Label1.Visible = true;
				Label1.Text ="Please check at least one chart parameter";
				return ;
			}
			if(lstProjects.SelectedIndex > -1)
			{
				ArrayList arrPrjects = new ArrayList();

				//Looping through selected Projects from 'lstProjects' listbox
				// Get selected Project and save them in [arrPrjects]
				for (int i=0; i<lstProjects.Items.Count ;i++)
					if (lstProjects.Items[i].Selected)
						arrPrjects.Add(lstProjects.Items[i].Value);
				Chart projectChart = ChartFactory.LoadChart((int)Chart.ChartTypes.ProjectChart);
				projectChart.ProjectsIDs = arrPrjects;
				projectChart.ShowEmpName = chkEmpName.Checked;
				projectChart.ShowEmpCode = chkEmpCode.Checked;
				projectChart.ShowEmpPhoto = chkEmpPhoto.Checked;
				projectChart.ShowEmpDept = chkEmpDept.Checked;
				projectChart.ShowEmpTitle = chkEmpTitle.Checked;
				projectChart.ShowProjectEmpNo = chkProjectEmpNo.Checked;
				projectChart.ShowProjectManager=this.chkProjectManager.Checked;
				Session["chartObject"] = projectChart;
				Session["chartType"] = (int)Chart.ChartTypes.ProjectChart; // project chart
				Response.Redirect("frmColors.aspx?chartname="+Request.QueryString["chartname"]+"&action="+Request.QueryString["action"]+"&chartid="+Request.QueryString["chartid"]);
			}
			else
			{
				Label1.Visible = true;
				Label1.Text = "Please select project from the projects List";
			}
		}
		#endregion	
		//----------------------------------------------------------------------------
		#region Back button
		protected void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("frmCreateNewChart.aspx?chartname="+Request.QueryString["chartname"]+"&action="+Request.QueryString["action"]+"&chartid="+Request.QueryString["chartid"]);
		}
		#endregion
		//----------------------------------------------------------------------------
		#region Select all projects
		protected void chkSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			for(int i=0; i<lstProjects.Items.Count;i++)
				lstProjects.Items[i].Selected = chkSelectAll.Checked;
		}
		#endregion
		//----------------------------------------------------------------------------
		#region Show employees option is selected
		protected void chkEmpName_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkEmpName.Checked)
			{
				chkEmpCode.Enabled = true;
				chkEmpPhoto.Enabled = true;
				//chkEmpProjects.Enabled = true;  // Not implemented yet.
				chkEmpDept.Enabled = true;
				chkEmpTitle.Enabled = true;
				chkEmpPhoto.Enabled = true;
			}
			else
			{
				chkEmpCode.Enabled = false;
				chkEmpPhoto.Enabled = false;
				//chkEmpProjects.Enabled = false;
				chkEmpDept.Enabled = false;
				chkEmpTitle.Enabled = false;
				chkEmpPhoto.Enabled = false;
				chkEmpCode.Checked = false;
				chkEmpPhoto.Checked = false;
				//chkEmpProjects.Checked = false;
				chkEmpDept.Checked = false;
				chkEmpTitle.Checked = false;;
				chkEmpPhoto.Checked = false;
			}
		}
		#endregion
		//----------------------------------------------------------------------------
	}
}
