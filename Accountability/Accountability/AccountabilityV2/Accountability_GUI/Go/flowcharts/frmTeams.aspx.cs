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
	/// Teams charts attributes 
	/// </summary>
	public partial class frmTeams : System.Web.UI.Page
	{
		//-----------------------------------------------------------------
		#region Class members
		protected System.Web.UI.WebControls.CheckBox chkEmpProjects;
		protected TSN.ERP.SharedComponents.Data.dsTeams dsTeams;
		#endregion
		//-----------------------------------------------------------------
		#region Page load
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Label1.Text = "";
			if (! IsPostBack)
			{
				// Bind all available teams to listbox
				dsTeams.Merge(((Navigation.BaseObject) Session[ "navigation" ]).TeamsWSObject.ListTeams());
				lstTeams.DataSource = dsTeams;
				lstTeams.DataBind();
			}
		}
		#endregion
		//-----------------------------------------------------------------
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
			this.dsTeams = new TSN.ERP.SharedComponents.Data.dsTeams();
			((System.ComponentModel.ISupportInitialize)(this.dsTeams)).BeginInit();
			// 
			// dsTeams
			// 
			this.dsTeams.DataSetName = "dsTeams";
			this.dsTeams.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.dsTeams)).EndInit();

		}
		#endregion
		//-----------------------------------------------------------------
		#region Select all teams
		protected void chkSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			for(int i=0; i<lstTeams.Items.Count;i++)
				lstTeams.Items[i].Selected = chkSelectAll.Checked;;
		}
		#endregion
		//-----------------------------------------------------------------
		#region Show employee option selected
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
		//-----------------------------------------------------------------
		#region Back button
		protected void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("frmCreateNewChart.aspx?chartname="+Request.QueryString["chartname"]+"&action="+Request.QueryString["action"]+"&chartid="+Request.QueryString["chartid"]);
		}
		#endregion
		//-----------------------------------------------------------------
		#region Next button
		protected void btnNext_Click(object sender, System.EventArgs e)
		{
			if(chkEmpName.Checked == false && chkTeamEmpNo.Checked == false && chkTeamLeader.Checked == false )
			{
				Label1.Visible = true;
				Label1.Text ="Please check at least one chart parameter";
				return ;
			}

			
			if(lstTeams.SelectedIndex >-1)
			{
				ArrayList arrTeams = new ArrayList();
				// get selected teams and save them in [arrTeams]
				for (int i=0; i<lstTeams.Items.Count ;i++)
					if (lstTeams.Items[i].Selected)
						arrTeams.Add(lstTeams.Items[i].Value);
				// Create a new instance of teams chart and configure its attributes
				Chart teamChart = ChartFactory.LoadChart((int)Chart.ChartTypes.TeamChart); 
				teamChart.TeamsIDs = arrTeams;
				teamChart.ShowEmpName = chkEmpName.Checked;
				teamChart.ShowEmpCode = chkEmpCode.Checked;
				teamChart.ShowEmpPhoto = chkEmpPhoto.Checked;
				teamChart.ShowEmpDept = chkEmpDept.Checked;
				teamChart.ShowEmpTitle = chkEmpTitle.Checked;
				teamChart.ShowTeamEmpNo = chkTeamEmpNo.Checked;
				teamChart.ShowTeamLeader = chkTeamLeader.Checked;
				teamChart.ShowTitleEmpNo = chkTeamEmpNo.Checked;
				Session["chartObject"] = teamChart;
				Session["chartType"] = (int)Chart.ChartTypes.TeamChart; // team chart
				Response.Redirect("frmColors.aspx?chartname="+Request.QueryString["chartname"]+"&action="+Request.QueryString["action"]+"&chartid="+Request.QueryString["chartid"]);
			}
			else
			{
				Label1.Visible = true;
				Label1.Text ="Please select Team from the Teams List";
			}
		}
		#endregion
		//-----------------------------------------------------------------
	}
}
