using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Collections;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using TSN.ERP.SharedComponents.Data;
using TSN.ERP.WebGUI.Data;
using TSN.ERP.WebGUI.Navigation;

namespace TSN.ERP.WebGUI.Go
{
	/// <summary>
	/// Summary description for ManageEmployeeTask.
	/// </summary>
	public partial class ManageEmployeeTask : System.Web.UI.Page
	{
		protected TSN.ERP.SharedComponents.Data.dsAccountabilitySheet dsAccountabilitySheet1;
		protected System.Data.DataView dvEmpAccSheet;
	
		
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
		//Response.Write(BaseObject.SessionWSObject.LastInnerException());
		//Response.Write(BaseObject.SessionWSObject.LastSecurityError());
			if ( ! IsPostBack ) 
			{
				lblEmpName.Text = Session["EmpName"].ToString();
				LoadAccSheet() ; 
				
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
				if (tempRow.RecoredType == 10)
				{
					CheckBox ch = (CheckBox) dgEmpResTasks.Items[i].Cells[2].Controls[1];
					ch.Visible = true ;
					dgEmpResTasks.Items[i].BackColor = Color.YellowGreen ;
				}
			
			}
		
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
			this.dsAccountabilitySheet1 = new TSN.ERP.SharedComponents.Data.dsAccountabilitySheet();
			this.dvEmpAccSheet = new System.Data.DataView();
			((System.ComponentModel.ISupportInitialize)(this.dsAccountabilitySheet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvEmpAccSheet)).BeginInit();
			// 
			// dsAccountabilitySheet1
			// 
			this.dsAccountabilitySheet1.DataSetName = "dsAccountabilitySheet";
			this.dsAccountabilitySheet1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// dvEmpAccSheet
			// 
			this.dvEmpAccSheet.Table = this.dsAccountabilitySheet1.EmpAccSheet;
			((System.ComponentModel.ISupportInitialize)(this.dsAccountabilitySheet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvEmpAccSheet)).EndInit();

		}
		#endregion

		protected void btnCompleteTask_Click(object sender, System.EventArgs e)
		{
			int rowCount =  dgEmpResTasks.Items.Count ;
			for ( int i = rowCount -1   ; i >= 0 ;  i-- )
			{
				CheckBox ch = (CheckBox) dgEmpResTasks.Items[ i ].Cells[ 2 ].Controls[ 1 ];
				if ( ch.Checked  ) 
				{
					int AssignID = Convert.ToInt32(dgEmpResTasks.Items[i].Cells[3].Text) ;
					((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.RequestToCloseAssignment(AssignID);
					((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ApproveAssignment(AssignID);
				}
				dsAccountabilitySheet1.Clear();
				LoadAccSheet() ; 
			
			}
		}

		protected void btnRemoveTask_Click(object sender, System.EventArgs e)
		{
			ArrayList deletedItems = new ArrayList();
			// get employee accountability sheet
			dsAccountabilitySheet1.Merge(((Navigation.BaseObject) Session[ "navigation" ]).AccountabilityWSObject.GetAccSheet(Convert.ToInt32(Session["EmpID"]),DateTime.Today,10,false));
			
			// get employee assignments
			TSN.ERP.SharedComponents.Data.dsAssignments dsAllAss = new dsAssignments();
			//dsAllAss.Merge( ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewEmployeeAssignments( Convert.ToInt32(Session["EmpID"]) ));
			
			int rowCount =  dgEmpResTasks.Items.Count ;
			for ( int i = rowCount -1   ; i >= 0 ;  i-- )
			{
				CheckBox ch = (CheckBox) dgEmpResTasks.Items[ i ].Cells[ 2 ].Controls[ 1 ];
				if ( ch.Checked  ) 
				{
					int AssignID = Convert.ToInt32(dgEmpResTasks.Items[i].Cells[3].Text) ;
					TSN.ERP.SharedComponents.Data.dsAssignments.GEN_AssignmentsRow temprow = (TSN.ERP.SharedComponents.Data.dsAssignments.GEN_AssignmentsRow) dsAllAss.GEN_Assignments.Rows.Find( AssignID );
						
					if ( temprow != null  )
						temprow.Delete();

					deletedItems.Add( AssignID );
				}
			}
			
			// delete checked assginmnet
			int n = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.DeleteAssignment( dsAllAss );

			// if not deleted then close them
			if ( n == -1 )
			{
				for ( int i = 0 ; i < deletedItems.Count ; i++ )
					((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.CloseAssignment( Convert.ToInt32( deletedItems[ i ] ) );
			}
			dsAccountabilitySheet1.Clear();
			LoadAccSheet() ; 
		
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Session["BackToProjectTask"] = 1;
			Response.Redirect("../Navigation/ContentPage.aspx");
		}
		
	}
}
