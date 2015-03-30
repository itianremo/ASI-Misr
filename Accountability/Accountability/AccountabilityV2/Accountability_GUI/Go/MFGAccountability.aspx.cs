
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

namespace TSN.ERP.WebGUI.Go
{
	/// <summary>
	/// Summary description for frmEmpJobtitle.
	/// </summary>
	public partial class MFGAccountability : System.Web.UI.Page
	{
		protected System.Data.DataSet dataSetEmp;

		Boolean isMFGAdmin;
		//int empContactID;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            TextBoxFrom.Attributes["readonly"] = "true";
			// Put user code to initialze the page here
			try
			{
				if( !IsPostBack )
				{
					// check if the user is admin or MFG admin
					if( ((Navigation.BaseObject) Session[ "navigation" ]).SecInfo.IsAdministrator || ((Navigation.BaseObject) Session[ "navigation" ]).MFGWSObject.UserIsMFGAdmin( ((Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.GetLoggedUserID() ) )
						isMFGAdmin =  true;
					// if MFG admin get all his employees
					if ( isMFGAdmin )
					{
						#region Fill Employees Combobox
					
						dataSetEmp.Merge(((Navigation.BaseObject) Session[ "navigation" ]).MFGWSObject.GetAllMFGEmployees());
						if( dataSetEmp.Tables[ 0 ].Rows.Count == 0)
						{
							Table1.Visible   = false;
							Button1.Visible  = false;
							Label1.Visible   = true;
							return;
						}
						lstEmp.DataSource = dataSetEmp;
						lstEmp.DataTextField = "Fullname";
						lstEmp.DataValueField = "ContactID";
						lstEmp.DataBind();
						//empContactID =  Convert.ToInt32( lstEmp.Items[ 0 ].Value );
						ViewState[ "empContactID" ] =  Convert.ToInt32( lstEmp.Items[ 0 ].Value );
						#endregion
					}
					else
					{
						LabelEmp.Visible = false;
						lstEmp.Visible   = false;
						// set employee contact to the logged user contact ID
						ViewState[ "empContactID" ] = Convert.ToInt32( Session["CurrentEmployee"]);
					}
					// Get sheet for today
					TextBoxFrom.Text = DateTime.Today.ToShortDateString();
					CreateGrids( Convert.ToDateTime( DateTime.Today.ToShortDateString()) , false );
			
				}
			}
			catch( Exception ee )
			{
				Response.Write(ee.Message);
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
			this.dataSetEmp = new System.Data.DataSet();
			((System.ComponentModel.ISupportInitialize)(this.dataSetEmp)).BeginInit();
			// 
			// dataSetEmp
			// 
			this.dataSetEmp.DataSetName = "NewDataSet";
			this.dataSetEmp.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.dataSetEmp)).EndInit();

		}
		#endregion

		#region Load Sheet
		void CreateGrids( DateTime weekStart , Boolean wholeweek )
		{
			try
			{
				int iterationNum = 1 ;
				
				if( wholeweek )
					iterationNum = 7;

				for( int i = 0 ; i < iterationNum ; i++ )
				{
					DataSet ds = new DataSet();
					
					if( wholeweek )
						weekStart = weekStart.AddDays( 1 );
					// get sheet for selected date
					Navigation.BaseObject.SafeMerge( ds , (((Navigation.BaseObject) Session[ "navigation" ]).MFGWSObject.ListEmployeeMFGTasks( Convert.ToInt32( ViewState[ "empContactID" ] ) ,   weekStart  ))  );
					DrawGrid( weekStart , ds );
				}
			}
			catch( Exception ee )
			{
				Response.Write(ee.Message+"Hamdy");
			}
		}

		#endregion

		#region Employees  Selected Index Changed
		protected void lstEmp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DateTime date = Convert.ToDateTime (TextBoxFrom.Text );
			ViewState[ "empContactID" ] =  int.Parse(lstEmp.SelectedValue ); 
			CreateGrids( date , false ); 
		}
		#endregion 
		
		#region Date Selected Index Changed
		protected void DropdownlistDate_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DateTime date = new DateTime();
			//int weekDatCount = -(int)DateTime.Today.DayOfWeek;
			int weekDatCount = -(int)Convert.ToDateTime (TextBoxFrom.Text ).DayOfWeek;
			DateTime weekStart = ( Convert.ToDateTime (TextBoxFrom.Text ) ).AddDays(weekDatCount);
			
			switch( DropdownlistDate.SelectedValue )
			{
				case "0" :
					date = Convert.ToDateTime( DateTime.Today.ToShortDateString() );
					TextBoxFrom.Text = date.ToShortDateString();
					break;
				case "1" :
					CreateGrids( weekStart.AddDays( -1 ) , true );
					return;
				case "Sunday" :
					date = weekStart ;
					break;
				case "Monday" :
					date = weekStart.AddDays(1);
					break;
				case "Tuesday" :
					date = weekStart.AddDays(2);
					break;
				case "Wednesday" :
					date = weekStart.AddDays(3);
					break;
				case "Thursday" :
					date = weekStart.AddDays(4);
					break;
				case "Friday" :
					date = weekStart.AddDays(5);
					break;
				case "Saturday" :
					date = weekStart.AddDays(6);
					break;
			}
			CreateGrids( date , false );
		}

		#endregion

		#region On Date Select
		protected void Button1_Click(object sender, System.EventArgs e)
		{
			DateTime date = Convert.ToDateTime (TextBoxFrom.Text );
			//int n = date.Day;
			DropdownlistDate.SelectedValue = date.DayOfWeek.ToString();
			CreateGrids( date , false );
		}
		
		#endregion

		#region Draw Grids
		void DrawGrid( DateTime date , DataSet ds )
		{
			string totalStr = "Total Hours:";
			int total = 0 ;

			total = 0;

			DataGrid myDataGrid = new DataGrid();
	
			// Create Bound Columns 
			BoundColumn nameColumn = new BoundColumn(); 
			nameColumn.HeaderText = "Traveler"; 
			nameColumn.DataField = "TrvNumber";
			myDataGrid.Columns.Add(nameColumn); 
						
			BoundColumn nameColumn2 = new BoundColumn(); 
			nameColumn2.HeaderText = "Company"; 
			nameColumn2.DataField = "Compnay";
			nameColumn2.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			myDataGrid.Columns.Add(nameColumn2); 
			
			BoundColumn nameColumn3 = new BoundColumn(); 
			nameColumn3.HeaderText = "Clip/Member"; 
			nameColumn3.DataField = "ClipMember";
			myDataGrid.Columns.Add(nameColumn3); 
			
			BoundColumn nameColumn4 = new BoundColumn(); 
			nameColumn4.HeaderText = "Part Class"; 
			nameColumn4.DataField = "PartClass";
			myDataGrid.Columns.Add(nameColumn4); 
			
			BoundColumn nameColumn5 = new BoundColumn(); 
			nameColumn5.HeaderText = "Part Number"; 
			nameColumn5.DataField =  "PartNumber";
			nameColumn5.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			myDataGrid.Columns.Add(nameColumn5); 
			
			BoundColumn nameColumn6 = new BoundColumn(); 
			nameColumn6.HeaderText = "Operation"; 
			nameColumn6.DataField = "Operation";
			nameColumn6.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
			myDataGrid.Columns.Add(nameColumn6); 
			
			BoundColumn nameColumn7 = new BoundColumn(); 
			nameColumn7.HeaderText = "Quantity"; 
			nameColumn7.DataField = "Quantity";
			myDataGrid.Columns.Add(nameColumn7); 
			
			BoundColumn nameColumn8 = new BoundColumn(); 
			nameColumn8.HeaderText = "Hours"; 
			nameColumn8.DataField = "Hours";
			myDataGrid.Columns.Add(nameColumn8); 

			myDataGrid.Width = System.Web.UI.WebControls.Unit.Percentage( 100 );
			myDataGrid.PageSize = 3;
			myDataGrid.AutoGenerateColumns = false;
			myDataGrid.HeaderStyle.CssClass = "headertd" ;
			myDataGrid.AlternatingItemStyle.CssClass="bsalternativetd";
			myDataGrid.ItemStyle.CssClass="bsnormaltd";

			myDataGrid.DataSource = ds;
			myDataGrid.DataBind();
			
			foreach( DataGridItem item in myDataGrid.Items )
			{
				item.Cells[ 1 ].Text = "&nbsp;&nbsp;&nbsp;" + item.Cells[ 1 ].Text;
				item.Cells[ 4 ].Text = "&nbsp;&nbsp;&nbsp;" + item.Cells[ 4 ].Text;
				item.Cells[ 5 ].Text = "&nbsp;&nbsp;&nbsp;" + item.Cells[ 5 ].Text;
			}
			
			totalStr = date.DayOfWeek.ToString() + " " + date.ToShortDateString(); 
			// set total value
			foreach( DataRow row in ds.Tables[ 0 ].Rows )
				total += Convert.ToInt32( row[ "Hours" ] );

			string headerText = " <TABLE class='whitetd' id='Table2' style='cellSpacing='1' cellPadding='1' width='100%' border='0'>"+
				"<TR>"+
				"<TD align='left'>"+
				"<div style=' DISPLAY: inline; FONT-WEIGHT: bold; FONT-SIZE: 13px; COLOR: #044476; FONT-FAMILY: Arial, Helvetica, sans-serif'>"+totalStr+"</div>"+
				"</TD>"+
				"<TD align='right'>"+
				"<div style=' DISPLAY: inline; FONT-WEIGHT: bold; FONT-SIZE: 13px; COLOR: #044476; FONT-FAMILY: Arial, Helvetica, sans-serif'>Total Hours: "+total.ToString()+"</div>"+
				"&nbsp;"+
				"</TD>"+
				"</TR>"+
				"</TABLE>";

			PlaceHolder1.Controls.Add( new LiteralControl( headerText ));
			PlaceHolder1.Controls.Add( myDataGrid );
			PlaceHolder1.Controls.Add( new LiteralControl( "<br><br><br><br><br><br>" ));
			
		}

		#endregion
	}
}
