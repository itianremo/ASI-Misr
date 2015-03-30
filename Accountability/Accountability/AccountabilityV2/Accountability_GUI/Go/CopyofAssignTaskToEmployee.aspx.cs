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
	public partial class CopyofAssignTaskToEmployee : System.Web.UI.Page
	{
		protected TSN.ERP.SharedComponents.Data.dsTasks dsTasks1;
		protected TSN.ERP.SharedComponents.Data.dsAccountabilitySheet dsAccountabilitySheet1;
		protected System.Data.DataView dvEmpAccSheet;
		protected TSN.ERP.WebGUI.Data.UsrDS usrDS1;
		protected System.Web.UI.WebControls.CheckBox CheckBox2;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{

			if ( ! IsPostBack ) 
			{
				LoadSelectedEmp();
				LoadAccSheet() ; 
				LoadProjectTasks() ;
				dgProjectTasks.DataBind();
				//>>
				CheckIsTaskCompleted();
				//>>
				CheckButtonVisibilty();
			    CheckMultiEmpAccess();
			}
			int tasksCount=dsTasks1.Tables[0].Rows.Count;
			foreach(DataRow dr in dsTasks1.Tables[0].Rows)
			{
				if(dr["TaskStatus"].ToString() == "1")
				{
					btnAssign.Enabled=true;
					break;
				}
				else
				{
					btnAssign.Enabled=false;
				}
			}
//			if(dgProjectTasks.Items.Count==1 || !dgProjectTasks.Visible)
//			{
//				btnAssign.Enabled=false;
//			}
//			else if(dgProjectTasks.Items.Count>1 && dgProjectTasks.Visible)
//			{
//				btnAssign.Enabled=true;
//			}
		    
		
		}

		private void CheckIsTaskCompleted()
		{
			for( int i = 0 ; i < dgProjectTasks.Items.Count ; i++ )
			{
				DataGridItem item = dgProjectTasks.Items[ i ];
				if ( item.Cells[ 4 ].Text == "0" )
				{
				    item.Visible = false ;
				}
				
			}
		}

		private void LoadSelectedEmp()
		{
			
			dgEmployees.DataSource = (DataSet)Session["TempDs"];
			dgEmployees.DataBind();
			
		}
		
		private bool CheckMultiEmpAccess()
		{
			if (dgEmployees.Items.Count > 1)
			{
				btnRemoveTask.Visible = false;
				btnCompleteTask.Visible = false;
			    return true;
			}
		        return false;
		}

		protected void chkHeader_CheckedChanged(object a, System.EventArgs b)
		{
			CheckBox chk1=(CheckBox)a;
			if(chk1.Checked)
			{
				foreach(DataGridItem item in dgProjectTasks.Items)
				{
					if(item.ItemType==ListItemType.Item||item.ItemType==ListItemType.AlternatingItem)
					{
						CheckBox SelectTask=(CheckBox)item.FindControl("SelectTask");
						SelectTask.Checked=true;
					}
				}
			}
			else
			{
				foreach(DataGridItem item in dgProjectTasks.Items)
				{
					if(item.ItemType==ListItemType.Item||item.ItemType==ListItemType.AlternatingItem)
					{
						CheckBox SelectTask=(CheckBox)item.FindControl("SelectTask");
						SelectTask.Checked=false;
					}
				}
			}
            Navigation.BaseObject.SafeMerge(dsAccountabilitySheet1, ((Navigation.BaseObject)Session["navigation"]).AccountabilityWSObject.GetAccSheet(Convert.ToInt32(Session["EmpID"]), DateTime.Today, 10, false));
            ApplyDataFilter();
            int rowCount = dgEmpResTasks.Items.Count;
            for (int i = rowCount - 1; i >= 0; i--)
            {
                dsAccountabilitySheet.EmpAccSheetRow tempRow = (dsAccountabilitySheet.EmpAccSheetRow)dvEmpAccSheet[i].Row;
                if (tempRow.RecoredType == 20)
                {
                    CheckBox ch = (CheckBox)dgEmpResTasks.Items[i].Cells[2].Controls[1];
                    ch.Visible = true;
                    dgEmpResTasks.Items[i].BackColor = Color.FromName("#99CCFF");

                }
                //>>  Bug Fixation Begains Here 2 checks About task status
                else
                {
                    if (dgEmpResTasks.Items[i].Cells[5].Text == "&nbsp;" || dgEmpResTasks.Items[i].Cells[5].Text == "3")
                    {
                        CheckBox ch = (CheckBox)dgEmpResTasks.Items[i].Cells[2].Controls[1];
                        ch.Visible = false;
                        dgEmpResTasks.Items[i].CssClass = "completetask";
                    }

                }

            }
		}

	
		protected void ApplyDataFilter()
		{
			string filterString ="";
			if ( CheckMultiEmpAccess() == false)
			{
				filterString  = "RecoredType = 20 OR (RecoredType = 10 and ParentProjectID = "+ Convert.ToInt32(Session["ProjectID"]) + ")";
			}
			else
			{
				filterString  = "RecoredType = 20 "; 
			}
			
			dvEmpAccSheet.RowFilter = filterString;
		}
    
	
		private void LoadAccSheet()
		{
			Navigation.BaseObject.SafeMerge( dsAccountabilitySheet1 , ((Navigation.BaseObject) Session[ "navigation" ]).AccountabilityWSObject.GetAccSheet(Convert.ToInt32(Session["EmpID"]),DateTime.Today,10,false) );
			
			//string rowColor = "#02CECF";
			if (dsAccountabilitySheet1.Tables[0].Rows.Count > 0)
			{
			
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
                        dgEmpResTasks.Items[i].BackColor = Color.FromName("#99CCFF");
						
					}
					//>>  Bug Fixation Begains Here 2 checks About task status
					else
					{
						if(dgEmpResTasks.Items[i].Cells[5].Text == "&nbsp;" || dgEmpResTasks.Items[i].Cells[5].Text == "3")
						{
							CheckBox ch = (CheckBox) dgEmpResTasks.Items[i].Cells[2].Controls[1];
							ch.Visible = false ;
							dgEmpResTasks.Items[i].CssClass =  "completetask";
						}
					
					}
				
				}

				ViewState[ "Count" ] = dgEmpResTasks.Items.Count;
			}
		
		}

	
		private void LoadProjectTasks()
		{
			
			Navigation.BaseObject.SafeMerge( dsTasks1 , ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewTaskByProject(Convert.ToInt32(Session["ProjectID"])) );
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
			this.dsTasks1 = new TSN.ERP.SharedComponents.Data.dsTasks();
			this.usrDS1 = new TSN.ERP.WebGUI.Data.UsrDS();
			((System.ComponentModel.ISupportInitialize)(this.dsAccountabilitySheet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvEmpAccSheet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTasks1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.usrDS1)).BeginInit();
			// 
			// dsAccountabilitySheet1
			// 
			this.dsAccountabilitySheet1.DataSetName = "dsAccountabilitySheet";
			this.dsAccountabilitySheet1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// dvEmpAccSheet
			// 
			this.dvEmpAccSheet.Table = this.dsAccountabilitySheet1.EmpAccSheet;
			// 
			// dsTasks1
			// 
			this.dsTasks1.DataSetName = "dsTasks";
			this.dsTasks1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// usrDS1
			// 
			this.usrDS1.DataSetName = "UsrDS";
			this.usrDS1.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.dsAccountabilitySheet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvEmpAccSheet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTasks1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.usrDS1)).EndInit();

		}
		#endregion

		protected void btnAssign_Click(object sender, System.EventArgs e)
		{
			
			dsAccountabilitySheet dstemp = (dsAccountabilitySheet)ViewState["dsRes"];
			dsTasks dstemp2 = (dsTasks) ViewState["dsTempTask"];
			int rowCountForResp =  dgEmpResTasks.Items.Count ;
			ArrayList arrRes = new ArrayList();
            int flag = 1 ;
			int trueCheckBox = 0;
			bool NoTask = false;
			for ( int ii = dgProjectTasks.Items.Count -1   ; ii >= 0 ;  ii-- )
			{
				if(((CheckBox) dgProjectTasks.Items[ ii ].Cells[ 3 ].Controls[ 1 ]).Checked)
				{
					NoTask = true;
					continue;
				}
			}
			if(!NoTask)
			{
				Navigation.BaseObject.showMessage( "Select tasks(s) to assign" , this.Page );
				return;
			}
			for ( int i = rowCountForResp -1   ; i >= 0 ;  i-- )
			{	
				
				CheckBox ch1 = (CheckBox) dgEmpResTasks.Items[ i ].Cells[ 2 ].Controls[ 1 ];
				if ( ch1.Checked  ) 
				{
					//Check if the user tries to assign a task to a task
					if(dgEmpResTasks.Items[ i ].Cells[ 4 ].Text == "10")
					{
						Navigation.BaseObject.showMessage( "You can assign tasks(s) only to responsibilities!" , this.Page );
						return;
					}

					trueCheckBox++;
					ViewState["ResID"] = dgEmpResTasks.Items[ i ].Cells[ 3 ].Text ;  
		           
				   int rowCountForTask =  dgProjectTasks.Items.Count ;
				   for ( int ii = rowCountForTask -1   ; ii >= 0 ;  ii-- )
				   {
					CheckBox ch2 = (CheckBox) dgProjectTasks.Items[ ii ].Cells[ 3 ].Controls[ 1 ];
					   if ( ch2.Checked  ) 
					   {
						int TaskID = Convert.ToInt32(dgProjectTasks.Items[ii].Cells[0].Text) ;
						
						   int rowCountForEmp =  dgEmployees.Items.Count ;
						   
						   for ( int iii = rowCountForEmp -1   ; iii >= 0 ;  iii-- )
						   {
							   int EmpID = Convert.ToInt32(dgEmployees.Items[iii].Cells[1].Text) ;
							   int newID = 0;
							   if(dgProjectTasks.Items[ ii ].Cells[ 4 ].Text == "1")
							   {
								   newID = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.AssginTask(TaskID,EmpID,Convert.ToInt32(ViewState["ResID"]),0);
							   }
							   if ( newID != -1 )
							   {
								   ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.SetOngoingAssignment( newID );
								   if (rowCountForEmp > 1)
								   Session["ConfirmMessage"] = "1";
							   }	
							   else
									flag = 0;
						   }
					   }
				    }
			     }
		    }
			if (flag == 1 && trueCheckBox > 0)
				Navigation.BaseObject.showMessage( "Tasks have been assigned to employee" , this.Page );
			else if (flag == 1 && trueCheckBox == 0)
				Navigation.BaseObject.showMessage( "Please Select Responsibility  first" , this.Page );
				else
				Navigation.BaseObject.showMessage( "not all tasks have been assigned to employee, either this task assigned before,or some other error occurred" , this.Page );

			flag = 0;
			
			if ( CheckMultiEmpAccess() == false)
			{
				dsAccountabilitySheet1.Clear();
				LoadAccSheet() ; 
				ClearChkBoxHeader() ;
			}
			else if ( CheckMultiEmpAccess() == true && (string)Session["ConfirmMessage"] == "1")
			{
				Session["BackToProjectTask"] = 1;
				Response.Redirect("../Navigation/ContentPage.aspx?uc=go/ProjectsList.ascx");
			
			}


		}

		private void ClearChkBoxHeader()
		{
        DataGridItem item = (DataGridItem)dgProjectTasks.Controls[0].Controls[0];
		CheckBox chkHdr = (CheckBox)item.FindControl("chkHeader");
		chkHdr.Checked = false;	

		int rowCountForTask =  dgProjectTasks.Items.Count ;
				   for ( int i = rowCountForTask -1   ; i >= 0 ;  i-- )
				   {
					CheckBox chk = (CheckBox) dgProjectTasks.Items[ i ].Cells[ 3 ].Controls[ 1 ];
					   if ( chk.Checked  ) 
					   {
						   chk.Checked = false ;

					   }
				   }
		}
		
		
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Session["BackToProjectTask"] = 1;
			Response.Redirect("../Navigation/ContentPage.aspx?uc=go/ProjectsList.ascx");
		}
		
		protected void btnCompleteTask_Click(object sender, System.EventArgs e)
		{
			int rowCount =  dgEmpResTasks.Items.Count ;
			int flag = 0;
			string RecordType="";
			bool Flage = false;
			for ( int i = rowCount -1   ; i >= 0 ;  i-- )
			{
				CheckBox ch = (CheckBox) dgEmpResTasks.Items[ i ].Cells[ 2 ].Controls[ 1 ];
				RecordType = dgEmpResTasks.DataKeys[i].ToString();
				if ( ch.Checked  && RecordType =="10" ) 
				{
					//BaseObject.showMessage(dgEmpResTasks.DataKeys[i].ToString(),this.Page);
					int AssignID = Convert.ToInt32(dgEmpResTasks.Items[i].Cells[3].Text) ;
					((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.RequestToCloseAssignment(AssignID);
					((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ApproveAssignment(AssignID);
					//Response.Write("<script>alert('Task completed')</script>");
					//flag = 1;
					Flage = true;
					
				}
				else if(ch.Checked && RecordType =="20")
				{
					//flag = 1;
					Response.Write("<script>alert('You have to select task under the selected responsability')</script>");
				}

			}
			if ( Flage) 
			{
			Response.Write("<script>alert('Task(s) completed')</script>");
			}
			//if (flag == 1)
            //Response.Write("<script>alert('You have to select task first')</script>");
			
			dsAccountabilitySheet1.Clear();
			LoadAccSheet() ; 
		}

		protected void btnRemoveTask_Click(object sender, System.EventArgs e)
		{
			ArrayList deletedItems = new ArrayList();
			// get employee accountability sheet
			Navigation.BaseObject.SafeMerge( dsAccountabilitySheet1 , ((Navigation.BaseObject) Session[ "navigation" ]).AccountabilityWSObject.GetAccSheet(Convert.ToInt32(Session["EmpID"]),DateTime.Today,10,false) );
			// get employee assignments
			TSN.ERP.SharedComponents.Data.dsAssignments dsAllAss = new dsAssignments();
			dsAllAss.Merge( ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.ViewEmployeeAssignments( Convert.ToInt32(Session["EmpID"]) ));
			dsAssignments dsDeletedAssignments = new dsAssignments();
			
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

			foreach(dsAssignments.GEN_AssignmentsRow row in dsAllAss.GEN_Assignments.Rows)
			{
				if(row.RowState == DataRowState.Deleted)
				{
					try
					{
						dsDeletedAssignments.GEN_Assignments.ImportRow(row);
					}
					catch(Exception ex)
					{
						Response.Write(ex.Message);
					}
				}
			}
			
			// delete checked assginmnet
//			int n = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.DeleteAssignment( dsAllAss );
			int n = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.DeleteAssignment( dsDeletedAssignments );

			// if not deleted then close them
			if ( n == -1 || n == 0 )
			{
				for ( int i = 0 ; i < deletedItems.Count ; i++ )
					((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.CloseAssignment( Convert.ToInt32( deletedItems[ i ] ) );
			}
			dsAccountabilitySheet1.Clear();
			LoadAccSheet() ; 
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Session["BackToProjectTask"] = 1;
			Response.Redirect("../Navigation/ContentPage.aspx?uc=go/ProjectsList.ascx");
		}

		private void Button2_ServerClick(object sender, System.EventArgs e)
		{
		
		}
	
		
		#region CheckButtonVisibilty
		
		void CheckButtonVisibilty()
		{
			ArrayList arrRules = new ArrayList();
			bool visibililty = true;

			// check complete task button
			arrRules.Add( 1017 );
			arrRules.Add( 2005 );
			arrRules.Add( 3005 );
			arrRules.Add( 4006 );
			arrRules.Add( 5103 );
			visibililty = ((Navigation.BaseObject) Session[ "navigation" ]).CheckUserAccessRule( arrRules );
			btnCompleteTask.Visible = visibililty;

			// check close task button
			visibililty = true;
			arrRules.Clear();

			arrRules.Add( 1025 );
			arrRules.Add( 2014 );
			arrRules.Add( 3014 );
			arrRules.Add( 4015 );
			arrRules.Add( 5110 );
			arrRules.Add( 1023 );
			arrRules.Add( 2011 );
			arrRules.Add( 3011 );
			arrRules.Add( 4012 );
			arrRules.Add( 5109 );

			visibililty = ((Navigation.BaseObject) Session[ "navigation" ]).CheckUserAccessRule( arrRules );
			btnRemoveTask.Visible	= visibililty;

			// check assign task to employee button
			visibililty = true;
			arrRules.Clear();

			arrRules.Add( 1024 );
			arrRules.Add( 2015 );
			arrRules.Add( 3012 );
			arrRules.Add( 4013 );
			arrRules.Add( 5002 );
			visibililty = ((Navigation.BaseObject) Session[ "navigation" ]).CheckUserAccessRule( arrRules );
			btnAssign.Visible	= visibililty;

		}
		#endregion 


        protected void dgProjectTasks_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Cells[0].Visible = false;
            }
            else if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[0].Visible = false;
            }
        }
}
		
	}	


