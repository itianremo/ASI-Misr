namespace TSN.ERP.WebGUI.Go
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using TSN.ERP.SharedComponents.Data;
	using TSN.ERP.WebGUI.Data;
	using Navigation;

	/// <summary>
	///		Summary description for addNewProject.
	/// </summary>
	public partial class addNewProject : System.Web.UI.UserControl
	{
		protected TSN.ERP.SharedComponents.Data.dsProjects dsProjects1;
		protected TSN.ERP.SharedComponents.Data.dsEmployee dsEmployee1;
		protected System.Data.DataView dataView1;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		
			LoadProjectsManager();
			drpManagerList.DataBind();
		    
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dsProjects1 = new TSN.ERP.SharedComponents.Data.dsProjects();
			this.dsEmployee1 = new TSN.ERP.SharedComponents.Data.dsEmployee();
			this.dataView1 = new System.Data.DataView();
			((System.ComponentModel.ISupportInitialize)(this.dsProjects1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsEmployee1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
			// 
			// dsProjects1
			// 
			this.dsProjects1.DataSetName = "dsProjects";
			this.dsProjects1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// dsEmployee1
			// 
			this.dsEmployee1.DataSetName = "dsEmployee";
			this.dsEmployee1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// dataView1
			// 
			this.dataView1.Sort = "EmpCode";
			this.dataView1.Table = this.dsEmployee1.GEN_Employees;
			((System.ComponentModel.ISupportInitialize)(this.dsProjects1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsEmployee1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();

		}
		#endregion

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			DIV1.Controls.Clear();
			DIV1.Controls.Add(LoadControl("ProjectsList.ascx"));
		}

		protected void btnSaveProject_Click(object sender, System.EventArgs e)
		{
			
			dsProjects1.EnforceConstraints = false;
			dsProjects.GEN_ProjectsRow row =  dsProjects1.GEN_Projects.NewGEN_ProjectsRow();
			// Build Row
			row.ProjectName = txtProjectName.Text;
			row.ProjectManager = Convert.ToInt32(drpManagerList.SelectedValue) ;
			row.ProjectTargetDate = Convert.ToDateTime(txtDeliverDate.Text);
			row.ProjectCriticalDate = Convert.ToDateTime(txtCriticalDate.Text);
			// Adds Row in dataset	
			dsProjects1.GEN_Projects.AddGEN_ProjectsRow(row);
			((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject.AddProject(dsProjects1);
		
		}
	
		private void LoadProjectsManager()
		{
			dsEmployee1.Merge(((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListEmployees());
		}


	}
}
