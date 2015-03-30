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
	/// Summary description for frmCreateNewChart.
	/// </summary>
	public partial class frmCreateNewChart : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnBack;
		protected TSN.ERP.SharedComponents.Data.dsOrgnizationCharts dsOrgnizationCharts1;
		//--------------------------------------------------------------------
		#region Page load
		protected void Page_Load(object sender, System.EventArgs e)
		{
			lblMSG.Text ="";
			dsOrgnizationCharts1.Merge(((Navigation.BaseObject) Session[ "navigation" ]).OrgnizationChartsWSObject.ListChartsInfo());
			if (!IsPostBack)
			{
				// Reset selectedNode, selectedNode session variable hold the last selected company element
				// ID. 

				try
				{
					Session["selectedNode"] = "";
                    Session["CurrentOgnizationChartIndex"] = null;
					// if session variable FileID hold a value, this means that we are in edit mode
					// Consecutively, Load edited chart info.
					if (Session["FileID"].ToString() != "" )
					{
						Chart ch = (Chart)Session["chartObject"];
						if (ch.Type == (int)Chart.ChartTypes.DeptChart ) // Department chart
							optDept.Checked = true;
						else if (ch.Type == (int)Chart.ChartTypes.TitleChart) // Job titles chart
							optJob.Checked = true;
						else if (ch.Type == (int)Chart.ChartTypes.TeamChart) // team chart
							optTeam.Checked = true;
						else if (ch.Type == (int)Chart.ChartTypes.ProjectChart) // project chart
							optProject.Checked = true;
						txtChartName.Text = ch.Name; // load chart name
					
					}
					else
					{
						if(Request.QueryString["action"]=="")
						{
							txtChartName.Text = Request.QueryString["chartname"];
							optProject.Checked= (bool)Session["chkProject"];
							optTeam.Checked=(bool)Session["chkTeams"];
							optDept.Checked=(bool) Session["chkDept"];
							optJob.Checked=(bool) Session["chkJobTitle"];

						}
					}
				}
				catch(Exception ex)
				{
					//Response.Write(ex);
				}
			}
	
       }
		#endregion
		//--------------------------------------------------------------------
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
			this.dsOrgnizationCharts1 = new TSN.ERP.SharedComponents.Data.dsOrgnizationCharts();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgnizationCharts1)).BeginInit();
			// 
			// dsOrgnizationCharts1
			// 
			this.dsOrgnizationCharts1.DataSetName = "dsOrgnizationCharts";
			this.dsOrgnizationCharts1.Locale = new System.Globalization.CultureInfo("ar-EG");
			((System.ComponentModel.ISupportInitialize)(this.dsOrgnizationCharts1)).EndInit();

		}
		#endregion
		//--------------------------------------------------------------------
		#region Back button
		private void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("frmChartMain.aspx");
		}
		#endregion
		//--------------------------------------------------------------------
		#region Next button
		public bool CheckChartName(TSN.ERP.SharedComponents.Data.dsOrgnizationCharts ds,string ChartName)
		{
			bool flag = true ;
			string action = "";
			string ID="";
			if(Request.QueryString.Count > 0)
			{
				action = Request.QueryString["action"].ToString();
				ID = Request.QueryString["chartid"].ToString();
			}
				foreach(DataRow dr in ds.Tables["GEN_OrgnizationCharts"].Rows)
			{
				flag = true;
				if(action=="edit" && (ID!="" || ID!=null))
				{
					if(dr["OChartDesc"].ToString().ToLower().Trim()== ChartName.ToLower() && int.Parse(dr["FileID"].ToString())!=Convert.ToInt32(ID))
					{
						flag = false;
						break;
					}				
					else
					{
						flag = true;
					}
				}
				else
				{
					if(dr["OChartDesc"].ToString().ToLower().Trim()== ChartName.ToLower())
					{
						flag = false;
						break;
					}				
					else
					{
						flag = true;
					}
				
				}
			}
			return flag;
		} 

		protected void btnNext_Click(object sender, System.EventArgs e)
		{
			// new department hierarchy chart
			bool Flage;
			string action="";
			string	ID="";

			if(Request.QueryString.Count > 0)
			{
				action = Request.QueryString["action"].ToString();
				ID = Request.QueryString["chartid"].ToString();
			}

			if(Page.IsValid)
			{
				Flage = CheckChartName(dsOrgnizationCharts1,txtChartName.Text.Trim());
				if(Flage)
				{
					Session["chkProject"]= optProject.Checked;
					Session["chkTeams"]= optTeam.Checked;
					Session["chkDept"]= optDept.Checked;
					Session["chkJobTitle"]= optJob.Checked;

					if(optDept.Checked)
					{
						//create an object for the chart and save it in the session
						CreateNewChart((int)Chart.ChartTypes.DeptChart); // department chart
						Response.Redirect("frmdept.aspx?chartname="+txtChartName.Text.Trim()+"&action="+action+"&chartid="+ID);
				
					}
					else if(optJob.Checked)
					{
						CreateNewChart((int)Chart.ChartTypes.TitleChart); // Job titles chart
						Response.Redirect("frmJobTitles.aspx?chartname="+txtChartName.Text.Trim()+"&action="+action+"&chartid="+ID);
					}
					else if(optTeam.Checked)
					{
						CreateNewChart((int)Chart.ChartTypes.TeamChart);  // Team chart
						Response.Redirect("frmTeams.aspx?chartname="+txtChartName.Text.Trim()+"&action="+action+"&chartid="+ID);
					}
					else
					{
						CreateNewChart((int)Chart.ChartTypes.ProjectChart); //project chart
						Response.Redirect("frmProjects.aspx?chartname="+txtChartName.Text.Trim()+"&action="+action+"&chartid="+ID);
					}

			}
				else
				{
					lblMSG.Visible = true;
					lblMSG.Text = "This chart name already exists , please try another one";
				}
			}

		}
		#endregion
		//--------------------------------------------------------------------
		#region Create new chart
		/// <summary>
		/// Create a new chart object, then save it in session.
		/// </summary>
		/// <param name="type"> Type of chart (1..Dept - 2..Title - 3..Team - 4..Project)</param>
		private void CreateNewChart (int type)
		{
	        // 29-12-2010
			Chart chart = ChartFactory.CreateChart(type);
            DateTime value = DateTime.Today;
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            //Console.WriteLine(value.ToString("D", culture));
           // culture = System.Globalization.CultureInfo.GetCultureInfo("en-GB");
            chart.Name = txtChartName.Text + System.Environment.NewLine + " Printed " + value.ToString("M", culture) + ", " + value.Year;
            //chart.Name = txtChartName.Text + System.Environment.NewLine + " Printed " + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year; 
			chart.Type=type;
			Session["chartObject"] = chart;
		}
		#endregion
		//--------------------------------------------------------------------
	}
}
