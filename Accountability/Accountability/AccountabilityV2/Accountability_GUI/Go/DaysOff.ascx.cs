namespace TSN.ERP.WebGUI.Go
{
	using System;
	using System.Collections;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using TSN.ERP.WebGUI.Navigation;

	/// <summary>
	///		Summary description for DaysOff.
	/// </summary>
	public partial class DaysOff : System.Web.UI.UserControl
	{
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		protected System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
		protected TSN.ERP.SharedComponents.Data.dsTasks dsTasks1;
		protected System.Data.DataView dataView1;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if ( !IsPostBack )
			{
				DataSet ds = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.GetAllDaysOffTasks();
				if ( Navigation.BaseObject.SafeMerge(  dsTasks1 , ds ))
				{
					dsTasks1.Merge ( ds );
					DataGrid1.DataBind();
					ViewState[ "dsTasks1" ] = dsTasks1;
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
			this.dsTasks1 = new TSN.ERP.SharedComponents.Data.dsTasks();
			this.dataView1 = new System.Data.DataView();
			((System.ComponentModel.ISupportInitialize)(this.dsTasks1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
			// 
			// oleDbDataAdapter1
			// 
			this.oleDbDataAdapter1.DeleteCommand = this.oleDbDeleteCommand1;
			this.oleDbDataAdapter1.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbDataAdapter1.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbDataAdapter1.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// dsTasks1
			// 
			this.dsTasks1.DataSetName = "dsTasks";
			this.dsTasks1.EnforceConstraints = false;
			this.dsTasks1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dataView1
			// 
			this.dataView1.Table = this.dsTasks1.GEN_Tasks;
			((System.ComponentModel.ISupportInitialize)(this.dsTasks1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();

		}
		#endregion

		#region ControlsEvents
		
		#region ButtonClick

		protected void ButtonClick( object sender ,  System.EventArgs ee )
		{
			dsTasks1 = ( TSN.ERP.SharedComponents.Data.dsTasks ) ViewState[ "dsTasks1" ] ;
			DataGridItem item = (DataGridItem) ((LinkButton) sender).Parent.Parent;
			DataGrid1.SelectedIndex = item.ItemIndex;
			int n =  Convert.ToInt32( item.Cells[ 2 ].Text );
			TSN.ERP.SharedComponents.Data.dsTasks.GEN_TasksRow row = (TSN.ERP.SharedComponents.Data.dsTasks.GEN_TasksRow) dsTasks1.GEN_Tasks.Rows.Find( n );
			TextBoxType.Text = row.TaskName ;
			TextBoxDesc.Text = row.TaskDesc ;
			Panel1.Visible = true;	
			ButtonAddDayyOff.Visible    = false;
			ButtonUpdateDayyOff.Visible = true;
			ViewState[ "TaskID" ] = n;
			((Navigation.BaseObject) Session[ "navigation" ]).Operation = BaseObject.OperationType.UPADATE;

			// check update button visibility
			ArrayList rule = new ArrayList();
			rule.Add( 5080 );
			ButtonUpdateDayyOff.Visible = ((Navigation.BaseObject) Session[ "navigation" ]).CheckUserAccessRule( rule );
		}

		#endregion
		
		#region ButtonNew_Click

		protected void ButtonNew_Click(object sender, System.EventArgs e)
		{
			try
			{
				Panel1.Visible = true;
				TextBoxType.Text = "" ;
				TextBoxDesc.Text = "" ;
				ButtonAddDayyOff.Visible    = true;
				ButtonUpdateDayyOff.Visible = false;

				((Navigation.BaseObject) Session[ "navigation" ]).Operation = BaseObject.OperationType.ADD;

				
				
			}
			catch ( Exception ee )
			{
				BaseObject.showMessage( ee.Message , this.Page );
			}
		}	

		#endregion

		#region ButtonEdit_Click

		private void ButtonEdit_Click(object sender, System.EventArgs e)
		{
			Panel1.Visible = true;
		}

		#endregion 

		#region ButtonDelete_Click

		protected void ButtonDelete_Click(object sender, System.EventArgs e)
		{
			dsTasks1 = ( TSN.ERP.SharedComponents.Data.dsTasks ) ViewState[ "dsTasks1" ] ;
            bool isSelected = false;

			for ( int i = 0 ; i < DataGrid1.Items.Count ; i++ )
			{
                if (((CheckBox)DataGrid1.Items[i].Cells[3].Controls[1]).Checked)
                {

                    dsTasks1.GEN_Tasks[i].Delete();
                    isSelected = true;
                }
			}
            if(!isSelected)
                Navigation.BaseObject.showMessage("Please Select Item to delete it. ", this.Page);
			int Deleted = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.DeleteTask( dsTasks1 );
			if(Deleted == -1)
			{
				BaseObject.showMessage( "Selected DayOff can not be deleted because it has previous entries!" , this.Page ); 
			}

			// get DaysOff again 
			dsTasks1.Clear();
			DataSet ds = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.GetAllDaysOffTasks();
			dsTasks1.Merge ( ds );
			DataGrid1.DataBind();
            ButtonCancel_Click(null, null);
			
		}

		#endregion 

		#region ButtonSave_Click

		private void ButtonSave_Click(object sender, System.EventArgs e)
		{
			if ( ((Navigation.BaseObject) Session[ "navigation" ]).Operation == BaseObject.OperationType.ADD ) 
			{	
				// add DayOff
				dsTasks1 = ( TSN.ERP.SharedComponents.Data.dsTasks ) ViewState[ "dsTasks1" ] ;
				dsTasks1.EnforceConstraints = false;
				TSN.ERP.SharedComponents.Data.dsTasks.GEN_TasksRow row = dsTasks1.GEN_Tasks.NewGEN_TasksRow();
				row.TaskName	= TextBoxType.Text;
				row.TaskDesc	= TextBoxDesc.Text;
				dsTasks1.GEN_Tasks.AddGEN_TasksRow( row );
				int n = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.AddDayOffTasks( dsTasks1 );

				// get DaysOff again 
				dsTasks1.Clear();
				DataSet ds = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.GetAllDaysOffTasks();
				dsTasks1.Merge ( ds );
				DataGrid1.DataBind();
				ViewState[ "dsTasks1" ] = dsTasks1;
				TextBoxType.Text = "" ;
				TextBoxDesc.Text = "" ;
				Panel1.Visible = false;

				if( n == 1 )
					BaseObject.showMessage( "Item has been added successfully " , this.Page ); 
			}
			else if (((Navigation.BaseObject) Session[ "navigation" ]).Operation == BaseObject.OperationType.UPADATE ) 
			{
				// Update DaysOff
				dsTasks1 = ( TSN.ERP.SharedComponents.Data.dsTasks ) ViewState[ "dsTasks1" ] ;
				TSN.ERP.SharedComponents.Data.dsTasks.GEN_TasksRow row = (TSN.ERP.SharedComponents.Data.dsTasks.GEN_TasksRow) dsTasks1.GEN_Tasks.Rows.Find( ((Navigation.BaseObject) Session[ "navigation" ]).EntityID );
				row.TaskName	= TextBoxType.Text;
				row.TaskDesc	= TextBoxDesc.Text;
				int n = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.UpdateTask( dsTasks1 );
				
				// get DaysOff again 
				TextBoxType.Text = "" ;
				TextBoxDesc.Text = "" ;
				Panel1.Visible = false;
				dsTasks1.Clear();
				DataSet ds = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.GetAllDaysOffTasks();
				dsTasks1.Merge ( ds );
				DataGrid1.DataBind();
				if( n == 1 )
					BaseObject.showMessage( "Item has been updated successfully " , this.Page ); 
				
			}
		}

		#endregion 

		#region ButtonCancel_Click

		protected void ButtonCancel_Click(object sender, System.EventArgs e)
		{
			TextBoxType.Text = "" ;
			TextBoxDesc.Text = "" ;
			Panel1.Visible = false;
		}

		#endregion

		#region ButtonAddDayyOff_Click

		#region CheckDayNameForAdd
		public bool CheckDayNameForAdd(TSN.ERP.SharedComponents.Data.dsTasks ds,string DayName)
		{
			bool flag = true ;
			foreach(DataRow dr in ds.Tables["GEN_Tasks"].Rows)
			{
				flag = true;
				if(dr["TaskName"].ToString().ToLower().Trim()== DayName.ToLower())
				{
					flag = false;
					break;
				}				
				else
				{
					flag = true;
				}
			}
			return flag;
		}
		#endregion

		#region CheckDayNameForEdit
		public bool CheckDayNameForEdit(TSN.ERP.SharedComponents.Data.dsTasks ds,string DayName,int DayID)
		{
			bool flag = true ;
			foreach(DataRow dr in ds.Tables["GEN_Tasks"].Rows)
			{
				flag = true;
				if(dr["TaskName"].ToString().ToLower().Trim()== DayName.ToLower() && int.Parse(dr["TaskID"].ToString())!=DayID)
				{
					flag = false;
					break;
				}				
				else
				{
					flag = true;
				}
			}
			return flag;
		}

		#endregion


		protected void ButtonAddDayyOff_Click(object sender, System.EventArgs e)
		{
			if (TextBoxType.Text.Trim() != "")
			{
				if ( ((Navigation.BaseObject) Session[ "navigation" ]).Operation == BaseObject.OperationType.ADD ) 
				{	
					// add DayOff
					if( ViewState[ "dsTasks1" ] != null )
						dsTasks1 = ( TSN.ERP.SharedComponents.Data.dsTasks ) ViewState[ "dsTasks1" ] ;
					
					dsTasks1.EnforceConstraints = false;
					TSN.ERP.SharedComponents.Data.dsTasks.GEN_TasksRow row = dsTasks1.GEN_Tasks.NewGEN_TasksRow();
					row.TaskName	= TextBoxType.Text;
					row.TaskDesc	= TextBoxDesc.Text;
					bool Flage = CheckDayNameForAdd(dsTasks1,TextBoxType.Text.Trim());
					if(Flage)
					{
						dsTasks1.GEN_Tasks.AddGEN_TasksRow( row );
						int n = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.AddDayOffTasks( dsTasks1 );

						// get DaysOff again 
						dsTasks1.Clear();
						DataSet ds = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.GetAllDaysOffTasks();
						dsTasks1.Merge ( ds );
						DataGrid1.DataBind();
						ViewState[ "dsTasks1" ] = dsTasks1;
						TextBoxType.Text = "" ;
						TextBoxDesc.Text = "" ;
						Panel1.Visible = false;

						if( n == 1 )
							BaseObject.showMessage( "Item has been added successfully " , this.Page ); 
					}
					else
					{
						BaseObject.showMessage( "This item added so far ,please try another one" , this.Page ); 
					}
				}
			}
			else 
			
			{
				Response.Write("<script>alert('Please Enter Item To Add')</script>");
			}  
		
		}


		#endregion

		#region ButtonUpdateDayyOff_Click

		protected void ButtonUpdateDayyOff_Click(object sender, System.EventArgs e)
		{
			
			if (((Navigation.BaseObject) Session[ "navigation" ]).Operation == BaseObject.OperationType.UPADATE ) 
			{
				if (TextBoxType.Text.Trim() != "")
				{
					// Update DaysOff
					dsTasks1 = ( TSN.ERP.SharedComponents.Data.dsTasks ) ViewState[ "dsTasks1" ] ;
					TSN.ERP.SharedComponents.Data.dsTasks.GEN_TasksRow row = (TSN.ERP.SharedComponents.Data.dsTasks.GEN_TasksRow) dsTasks1.GEN_Tasks.Rows.Find( Convert.ToInt32( ViewState[ "TaskID" ] ) );
					row.TaskName	= TextBoxType.Text;
					row.TaskDesc	= TextBoxDesc.Text;
					bool Flage = CheckDayNameForEdit(dsTasks1,TextBoxType.Text.Trim(), Convert.ToInt32( ViewState[ "TaskID" ] ));
					if(Flage)
					{
						int n = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.UpdateDayOff( dsTasks1 );
				
						// get DaysOff again 
						TextBoxType.Text = "" ;
						TextBoxDesc.Text = "" ;
						Panel1.Visible = false;
						dsTasks1.Clear();
						DataSet ds = ((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject.GetAllDaysOffTasks();
						dsTasks1.Merge ( ds );
						DataGrid1.DataBind();
						if( n == 1 )
							BaseObject.showMessage( "Item has been updated successfully " , this.Page ); 
					}
					else
					{
						BaseObject.showMessage( "This item already exists ,please try another one" , this.Page ); 
					}
				}
				else 
				{
					Page.RegisterStartupScript( "" , "<script language='javascript'>alert('Please enter type name ')</script>" );
				}  
				
			}
			
		}


		#endregion 

		#endregion

		
	}
}
