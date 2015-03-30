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
using MindFusion.FlowChartX.LayoutSystem;
using MindFusion.FlowChartX;


namespace TSN.ERP.WebGUI.Go.flowcharts
{
	/// <summary>
	/// Summary description for frmColors.
	/// </summary>
	public partial class frmColors : System.Web.UI.Page
	{
		#region Class members
		protected System.Web.UI.HtmlControls.HtmlInputButton Button1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.HtmlControls.HtmlInputButton Button24;

		
		protected System.Web.UI.WebControls.TextBox txtEmpFontSize1;
		#endregion
		//--------------------------------------------------------------------------------------------
		#region Page load
		protected void Page_Load(object sender, System.EventArgs e)
		{
            lblNote.Visible = false;
			string[] fontarray =  new string[]{
												  "Arial", "Arial Black", "Arial Rounded MT Bold", 
												  "Book Antiqua", "Bookman Old Style", "Braggadocio", 
												  "Britannic Bold","Brooklyn","Brush Script MT", 
												  "Carleton", "Century Gothic","Century Schoolbook","Charcoal","Chicago","CG Times","Colonna MT","Comic Sans MS","Coronet","Courier","Courier New","Cursive Elegant","DawnCastle","Desdemona","Donata","Erie","Expo","Footlight MT Light","Fritzquad","Garamond","Geneva","Georgia","GilbertUltraBold","Gill Sans Condensed Bold","GV Terminal","Haettenschweiler","Helvetica","Humanst521 Cn BT","Impact","Kino MT","Klang MT","Lansbury","Letter Gothic","Lincoln","Matura MT Script Capitals","Merlin","Micro","Minion Web","Modern","Monaco","Motor","Sonoma","Sonoma Italic","Swiss721 BlkEx BT","Times","Times New Roman","Verdana","Wide Latin"
											  };	
			if (!IsPostBack)
			{
				// fill font lists
				lstDeptFont.DataSource = fontarray;
				lstDeptFont.DataBind();
				lstEmpFont.DataSource = fontarray;
				lstEmpFont.DataBind();
				lstProjectFont.DataSource = fontarray;
				lstProjectFont.DataBind();
				lstTeamFont.DataSource = fontarray;
				lstTeamFont.DataBind();
				lstTitleFont.DataSource = fontarray;
				lstTitleFont.DataBind();
				//-------------------------------------------
				Chart chart = ChartFactory.LoadChart(int.Parse(Session["chartType"].ToString()));
				// load last selected color and layout settings
				LoadChartsColors(chart);
				//-----------------------------------------------------------
				// enable and disable colors buttons according to selected chart and options
				// set Department and titles color panels
				if ((int)Session["chartType"] == (int)Chart.ChartTypes.DeptChart ||    
					(int)Session["chartType"] == (int)Chart.ChartTypes.TitleChart)
				{
					btnDeptBack.Disabled = false;
					btnDeptBrdr.Disabled = false;
					btnDeptName.Disabled = false;
					lstDeptFont.Enabled = true;
					lstDeptFontSize.Enabled= true;
					if (chart.ShowDeptManager)
						btnDeptManager.Disabled = false;
					if (chart.ShowDeptEmpNo)
						btnDeptEmpNo.Disabled = false;
					if (Session["chartType"].ToString() =="2" || chart.GroupByEmpTitles)
					{
						btnJobBack.Disabled = false;
						btnJobBrdr.Disabled = false;
						btnJobName.Disabled = false;
						lstTitleFont.Enabled = true;
						lstTitleFontSize.Enabled = true;
						if (chart.ShowTitleEmpNo)
							btnJobEmpNo.Disabled = false;
					}
					else
						pnlTitle.Visible = false;
					pnlTeam.Visible = false;
					pnlProject.Visible = false;
					
				}
				// set teams color panel
				if ((int)Session["chartType"] == (int)Chart.ChartTypes.TeamChart)
				{
					pnlDept.Visible = false;
					pnlProject.Visible = false;
					pnlTitle.Visible = false;
					btnTeamBack.Disabled = false;
					btnTeamBrdr.Disabled = false;
					btnTeamName.Disabled = false;
					lstTeamFont.Enabled = true;
					lstTeamFontSize.Enabled = true;
					if(chart.ShowTeamEmpNo)
						btnTeamEmpNo.Disabled = false;
					if(chart.ShowTeamLeader)
						btnTeamLeader.Disabled = false;
				}
				// set projects color panel
				if ((int)Session["chartType"] == (int)Chart.ChartTypes.ProjectChart)
				{
					pnlDept.Visible = false;
					pnlTeam.Visible = false;
					pnlTitle.Visible = false;
					btnProjectBack.Disabled = false;
					btnProjectBrdr.Disabled = false;
					btnProjectName.Disabled = false;
					lstProjectFont.Enabled = true;
					lstProjectFontSize.Enabled = true;
					if(chart.ShowProjectEmpNo)
						btnProjectEmpNo.Disabled = false;
					if(chart.ShowProjectManager)
						btnProjectManager.Disabled = false;
				}
				//set employee color panel
				if(chart.ShowEmpName)
				{
					btnEmpBack.Disabled = false;
					btnEmpBrdr.Disabled = false;
					btnEmpName.Disabled = false;
					btnEmpProjects.Disabled = false;
					btnEmpTeams.Disabled = false;

					lstEmpFont.Enabled = true;
					lstEmpFontSize.Enabled = true;
					if (chart.ShowEmpCode)
						btnEmpCode.Disabled = false;
					if(chart.ShowEmpTitle)
						btnEmpJob.Disabled = false;
					if(chart.ShowEmpDept)
						btnEmpDept.Disabled = false;
				}
				else
					pnlEmp.Visible = false;
			}
		}
		#endregion
		//--------------------------------------------------------------------------------------------
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
		//--------------------------------------------------------------------------------------------
		#region Back button
		protected void btnBack_Click(object sender, System.EventArgs e)
		{
			if ((int)Session["chartType"] == (int)Chart.ChartTypes.DeptChart)
				Response.Redirect("frmDept.aspx?chartname="+Request.QueryString["chartname"]+"&action="+Request.QueryString["action"]+"&chartid="+Request.QueryString["chartid"]);
			else if ((int)Session["chartType"] == (int)Chart.ChartTypes.TitleChart)
				Response.Redirect("frmJobTitles.aspx?chartname="+Request.QueryString["chartname"]+"&action="+Request.QueryString["action"]+"&chartid="+Request.QueryString["chartid"]);
			else if ((int)Session["chartType"] == (int)Chart.ChartTypes.TeamChart)
				Response.Redirect("frmTeams.aspx?chartname="+Request.QueryString["chartname"]+"&action="+Request.QueryString["action"]+"&chartid="+Request.QueryString["chartid"]);
			else if ((int)Session["chartType"] == (int)Chart.ChartTypes.ProjectChart)
				Response.Redirect("frmProjects.aspx?chartname="+Request.QueryString["chartname"]+"&action="+Request.QueryString["action"]+"&chartid="+Request.QueryString["chartid"]);

		}
		#endregion
		//--------------------------------------------------------------------------------------------
		#region view button
		protected void btnView_Click(object sender, System.EventArgs e)
		{
            try
            {

                TreeLayoutType treeLayoutType = new TreeLayoutType();
                TreeLayoutDirection treeLayoutDirection = new TreeLayoutDirection();
                TreeLayoutArrowType treeLayoutArrowType = new TreeLayoutArrowType();
                // configure layout type
                if (lstLayoutType.SelectedValue == "1")
                    treeLayoutType = TreeLayoutType.Cascading;
                else if (lstLayoutType.SelectedValue == "2")
                    treeLayoutType = TreeLayoutType.Centered;
                else
                    treeLayoutType = TreeLayoutType.Radial;
                // configure tree direction
                if (lstTreeDir.SelectedValue == "1")
                    treeLayoutDirection = TreeLayoutDirection.BottomToTop;
                else if (lstTreeDir.SelectedValue == "2")
                    treeLayoutDirection = TreeLayoutDirection.TopToBottom;
                else if (lstTreeDir.SelectedValue == "3")
                    treeLayoutDirection = TreeLayoutDirection.LeftToRight;
                else
                    treeLayoutDirection = TreeLayoutDirection.RightToLeft;
                // configure arrow type
                if (lstArrowType.SelectedValue == "1")
                    treeLayoutArrowType = TreeLayoutArrowType.Cascading2;
                else if (lstArrowType.SelectedValue == "2")
                    treeLayoutArrowType = TreeLayoutArrowType.Cascading3;
                else if (lstArrowType.SelectedValue == "3")
                    treeLayoutArrowType = TreeLayoutArrowType.Rounded;
                else if (lstArrowType.SelectedValue == "4")
                    treeLayoutArrowType = TreeLayoutArrowType.Straight;
                //--------------------------------------------------------------------

                Chart chart = ChartFactory.LoadChart(int.Parse(Session["chartType"].ToString()));
                chart.ArrowColor = ColorConv.HexStringToColor(txtArrow.Value);
                // department
                chart.DeptBackColor = ColorConv.HexStringToColor(txtDeptBack.Value);
                chart.DeptBorderColor = ColorConv.HexStringToColor(txtDeptBrdr.Value);
                chart.DeptFontColor = ColorConv.HexStringToColor(txtDeptName.Value);
                chart.DeptEmpNoFontColor = ColorConv.HexStringToColor(txtDeptEmpNo.Value);
                chart.DeptManagerFontColor = ColorConv.HexStringToColor(txtDeptManager.Value);
                chart.DeptFont = new Font(lstDeptFont.Items[lstDeptFont.SelectedIndex].Text, float.Parse(lstDeptFontSize.SelectedValue));
                //title
                chart.TitleBackColor = ColorConv.HexStringToColor(txtJobBack.Value);
                chart.TitleBorderColor = ColorConv.HexStringToColor(txtJobBrdr.Value);
                chart.TitleFontColor = ColorConv.HexStringToColor(txtJobName.Value);
                chart.TitleEmpNoFontColor = ColorConv.HexStringToColor(txtJobEmpNo.Value);
                chart.TitleFont = new Font(lstTitleFont.Items[lstTitleFont.SelectedIndex].Text, float.Parse(lstTeamFontSize.SelectedValue));
                //Team
                chart.TeamBackColor = ColorConv.HexStringToColor(txtTeamBack.Value);
                chart.TeamBorderColor = ColorConv.HexStringToColor(txtTeamBrdr.Value);
                chart.TeamFontColor = ColorConv.HexStringToColor(txtTeamName.Value);
                chart.TeamEmpNoFontColor = ColorConv.HexStringToColor(txtTeamEmpNo.Value);
                chart.TeamLeaderFontColor = ColorConv.HexStringToColor(txtTeamLeader.Value);
                chart.TeamFont = new Font(lstTeamFont.Items[lstTeamFont.SelectedIndex].Text, float.Parse(lstTeamFontSize.SelectedValue));
                //Project
                chart.ProjectBackColor = ColorConv.HexStringToColor(txtProjectBack.Value);
                chart.ProjectBorderColor = ColorConv.HexStringToColor(txtProjectBrdr.Value);
                chart.ProjectFontColor = ColorConv.HexStringToColor(txtProjectName.Value);
                chart.ProjectEmpNoFontColor = ColorConv.HexStringToColor(txtProjectEmpNo.Value);
                chart.ProjectManagerFontColor = ColorConv.HexStringToColor(txtProjectManager.Value);
                chart.ProjectFont = new Font(lstProjectFont.Items[lstProjectFont.SelectedIndex].Text, float.Parse(lstProjectFontSize.SelectedValue));
                //Employee
                chart.EmpBackColor = ColorConv.HexStringToColor(txtEmpBack.Value);
                chart.EmpFont = new Font(lstEmpFont.Items[lstEmpFont.SelectedIndex].Text, float.Parse(lstEmpFontSize.SelectedValue));
                chart.EmpBorderColor = ColorConv.HexStringToColor(txtEmpBrdr.Value);
                chart.EmpNameFontColor = ColorConv.HexStringToColor(txtEmpName.Value);
                chart.EmpTeamsFontColor = ColorConv.HexStringToColor(txtEmpTeams.Value);
                chart.EmpProjectsFontColor = ColorConv.HexStringToColor(txtEmpProject.Value);
                chart.EmpCodeFontColor = ColorConv.HexStringToColor(txtEmpCode.Value);
                chart.EmpTitleFontColor = ColorConv.HexStringToColor(txtEmpTitle.Value);
                //Layout
                chart.TreeLayout = treeLayoutType;
                chart.TreeDirection = treeLayoutDirection;
                chart.ArrowType = treeLayoutArrowType;
                FlowChart fc = chart.Render();
                Session["fcx"] = fc;
                Response.Redirect("frmViewChart.aspx?chartname=" + Request.QueryString["chartname"] + "&action=" + Request.QueryString["action"] + "&chartid=" + Request.QueryString["chartid"]);
            }
            catch(Exception ex)
            {
                string error = ex.Message.ToString();
                //Response.Write("Data not compatible with your selection ");
               // msg = "<ul>" + msg + "</ul>";
               // tblErr.Rows[0].Cells[1].Text = "<p><b>Please correct the entries  because the data not compatible with your entries </b></p>";
                lblNote.Text = error;

                lblNote.Visible = true;
               
                return;
            }
		}
		#endregion
		//--------------------------------------------------------------------------------------------
		#region load chart color and layout settings
		private void LoadChartsColors(Chart chart)
		{
			if (chart.ArrowColor.ToString() != "Color [Empty]")
			{
				switch (chart.TreeLayout)
				{
					case TreeLayoutType.Cascading:
						lstLayoutType.SelectedIndex = 0;
						break;
					case TreeLayoutType.Centered:
						lstLayoutType.SelectedIndex = 1;
						break;
					case TreeLayoutType.Radial:
						lstLayoutType.SelectedIndex = 2;
						break;
				}
				switch (chart.TreeDirection)
				{
					case TreeLayoutDirection.BottomToTop:
						lstTreeDir.SelectedIndex = 0;
						break;
					case TreeLayoutDirection.TopToBottom:
						lstTreeDir.SelectedIndex = 1;
						break;
					case TreeLayoutDirection.LeftToRight:
						lstTreeDir.SelectedIndex= 2;
						break;
					case TreeLayoutDirection.RightToLeft:
						lstTreeDir.SelectedIndex = 3;
						break;
				}
				switch (chart.ArrowType)
				{
					case TreeLayoutArrowType.Cascading2:
						lstArrowType.SelectedIndex = 0;
						break;
					case TreeLayoutArrowType.Cascading3:
						lstArrowType.SelectedIndex = 1;
						break;
					case TreeLayoutArrowType.Rounded:
						lstArrowType.SelectedIndex = 2;
						break;
					case TreeLayoutArrowType.Straight :
						lstArrowType.SelectedIndex = 3;
						break;
				}
				// arrow
				loadTextColor(txtArrow,chart.ArrowColor);
				// department
				loadTextColor(txtDeptBack,chart.DeptBackColor);
				loadTextColor(txtDeptBrdr,chart.DeptBorderColor);
				loadTextColor(txtDeptName,chart.DeptFontColor);
				loadTextColor(txtDeptEmpNo,chart.DeptEmpNoFontColor);
				loadTextColor(txtDeptManager,chart.DeptManagerFontColor);
				//title
				loadTextColor(txtJobBack,chart.TitleBackColor);
				loadTextColor(txtJobBrdr,chart.TitleBorderColor);
				loadTextColor(txtJobName,chart.TitleFontColor);
				loadTextColor(txtJobEmpNo,chart.TitleEmpNoFontColor);
				//Team
				loadTextColor(txtTeamBack,chart.TeamBackColor);
				loadTextColor(txtTeamBrdr,chart.TeamBorderColor);
				loadTextColor(txtTeamName,chart.TeamFontColor);
				loadTextColor(txtTeamEmpNo,chart.TeamEmpNoFontColor);
				loadTextColor(txtTeamLeader,chart.TeamLeaderFontColor);
				//Project
				loadTextColor(txtProjectBack,chart.ProjectBackColor);
				loadTextColor(txtProjectBrdr,chart.ProjectBorderColor);
				loadTextColor(txtProjectName,chart.ProjectFontColor);
				loadTextColor(txtProjectEmpNo,chart.ProjectEmpNoFontColor);
				loadTextColor(txtProjectManager,chart.ProjectManagerFontColor);

				//Employee
				loadTextColor(txtEmpBack,chart.EmpBackColor);
				loadTextColor(txtProjectBrdr,chart.ProjectBorderColor);
				loadTextColor(txtEmpBrdr,chart.EmpBorderColor);
				loadTextColor(txtEmpName,chart.EmpNameFontColor);
				loadTextColor(txtEmpTeams,chart.EmpTeamsFontColor);
				loadTextColor(txtEmpProject,chart.EmpProjectsFontColor);
				loadTextColor(txtEmpCode,chart.EmpCodeFontColor);
				loadTextColor(txtEmpTitle,chart.EmpTitleFontColor);
			}	
		}
		#endregion
		//--------------------------------------------------------------------------------------------
		#region load given text with given color
		private void loadTextColor(System.Web.UI.HtmlControls.HtmlInputText textBox,Color color)
		{
			string c = ColorConv.ColorToHexString(color);
			textBox.Style["color"] = "#" + c;
			textBox.Style["background-Color"] = "#" + c;
			textBox.Value = c;	
		}
		#endregion
		//--------------------------------------------------------------------------------------------
	}
}
