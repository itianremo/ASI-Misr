using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using TSN.ERP.SharedComponents.Data;
using TSN.ERP.WebGUI.Data;
using TSN.ERP.WebGUI.Navigation;
using System.Globalization;


namespace TSN.ERP.WebGUI.Go
{
	/// <summary>
	/// Summary description for AssignTaskToEmployee.
	/// </summary>
	public partial class AssignTaskToEmployee : System.Web.UI.Page
	{
		protected TSN.ERP.SharedComponents.Data.dsTasks dsTasks1;
		protected TSN.ERP.SharedComponents.Data.dsAccountabilitySheet dsAccountabilitySheet1;
		protected System.Data.DataView dvEmpAccSheet;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		
			if ( ! IsPostBack ) 
			{
				lblEmpName.Text = Session["EmpName"].ToString();
				LoadAccSheet() ; 
				LoadProjectTasks() ;
				dgProjectTasks.DataBind();
			}
		
		}

	
		protected void ApplyDataFilter()
		{
			string filterString  = "RecoredType = 20 OR (RecoredType = 10 and ParentProjectID = "+ Convert.ToInt32(Session["ProjectID"]) + ")";
			dvEmpAccSheet.RowFilter = filterString;
		}
    
	
		private void LoadAccSheet()
		{
			dsAccountabilitySheet1.Merge(((Navigation.BaseObject) Session[ "navigation" ]).AccountabilityWSObject.GetAccSheet(Convert.ToInt32(Session["EmpID"]),DateTime.Today,10,false));
			ApplyDataFilter();
			dgEmpResTasks.DataBind();

			int rowCount =  dgEmpResTasks.Items.Count ;
			for ( int i = rowCount -1  ; i >= 0;  i-- )
			{
				dsAccountabilitySheet.EmpAccSheetRow tempRow = (dsAccountabilitySheet.EmpAccSheetRow)dvEmpAccSheet[i].Row;
				if (tempRow.RecoredType == 20)
				{
					CheckBox ch = (CheckBox) dgEmpResTasks.Items[i].Cells[2].Controls[1];
					ch.Visible = true ;
					dgEmpResTasks.Items[i].BackColor = Color.LightGreen ;
				}
			
			}
		
		}

	
		private void LoadProjectTasks()
		{
			dsTasks1.Merge(((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewTaskByProject(Convert.ToInt32(Session["ProjectID"])));
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
			this.dsTasks1 = new TSN.ERP.SharedComponents.Data.dsTasks();
			this.dsAccountabilitySheet1 = new TSN.ERP.SharedComponents.Data.dsAccountabilitySheet();
			this.dvEmpAccSheet = new System.Data.DataView();
			((System.ComponentModel.ISupportInitialize)(this.dsTasks1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsAccountabilitySheet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvEmpAccSheet)).BeginInit();
			// 
			// dsTasks1
			// 
			this.dsTasks1.DataSetName = "dsTasks";
			this.dsTasks1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dsAccountabilitySheet1
			// 
			this.dsAccountabilitySheet1.DataSetName = "dsAccountabilitySheet";
			this.dsAccountabilitySheet1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// dvEmpAccSheet
			// 
			this.dvEmpAccSheet.Table = this.dsAccountabilitySheet1.EmpAccSheet;
			((System.ComponentModel.ISupportInitialize)(this.dsTasks1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsAccountabilitySheet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvEmpAccSheet)).EndInit();

		}
		#endregion

		protected void btnAssign_Click(object sender, System.EventArgs e)
		{
			
			dsAccountabilitySheet dstemp = (dsAccountabilitySheet)ViewState["dsRes"];
			dsTasks dstemp2 = (dsTasks) ViewState["dsTempTask"];
			int rowCountForResp =  dgEmpResTasks.Items.Count ;
			ArrayList arrRes = new ArrayList();

			for ( int i = rowCountForResp -1   ; i >= 0 ;  i-- )
			{	
				
				CheckBox ch1 = (CheckBox) dgEmpResTasks.Items[ i ].Cells[ 2 ].Controls[ 1 ];
				if ( ch1.Checked  ) 
				{
					ViewState["ResID"] = dgEmpResTasks.Items[ i ].Cells[ 3 ].Text ;  
				}
			}
			
			int rowCountForTask =  dgProjectTasks.Items.Count ;
			for ( int ii = rowCountForTask -1   ; ii >= 0 ;  ii-- )
			{
				CheckBox ch2 = (CheckBox) dgProjectTasks.Items[ ii ].Cells[ 3 ].Controls[ 1 ];
				if ( ch2.Checked  ) 
				{
					int TaskID = Convert.ToInt32(dgProjectTasks.Items[ii].Cells[0].Text) ;
					int newID = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.AssginTask(TaskID,Convert.ToInt32(Session["EmpID"]),Convert.ToInt32(ViewState["ResID"]),0);
					if ( newID != -1 )
						((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.SetOngoingAssignment( newID );
				}
			}

			dsAccountabilitySheet1.Clear();
			LoadAccSheet() ; 

		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Session["BackToProjectTask"] = 1;
			Response.Redirect("../Navigation/ContentPage.aspx");
		}

		protected void dgProjectTasks_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	
	}
}
