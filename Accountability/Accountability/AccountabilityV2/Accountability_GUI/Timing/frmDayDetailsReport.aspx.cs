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

namespace TSN.ERP.WebGUI
{
	/// <summary>
	/// Summary description for frmDayDetailsReport.
	/// </summary>
	public partial class frmDayDetailsReport : System.Web.UI.Page
	{
		NewTimingWS.AccTimingService timeWS=new TSN.ERP.WebGUI.NewTimingWS.AccTimingService();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				DataSet ds=BindEmployees();
				DropDownListEmp.DataSource=ds.Tables[0];
				//ownListEmp.DataValueField="ContactID";
				DropDownListEmp.DataBind();
				DropDownListEmp.Enabled   = true;
				int ContactID=Convert.ToInt32(Session["CurrentEmployee"]);
				ViewState["ContactID"]=ContactID;
				TextBoxFrom.Text=DateTime.Now.ToShortDateString();
				if (DropDownListEmp.Items.FindByValue(ContactID.ToString())!=null)
				{
					DropDownListEmp.Items.FindByValue(ContactID.ToString()).Selected = true;
				}
				
			}

			

			// Put user code to initialize the page here
		}
		//[Ajax.AjaxMethod (Ajax.HttpSessionStateRequirement.Read)]
		public DataSet BindEmployees()
		{
			
			//DataSet dsEmployee =  ((Navigation.BaseObject)System.Web.HttpContext.Current.Session["navigation"]).AccountabilityWSObject.ViewAccountabilityEmployees();
			DataSet dsEmployee =  ((Navigation.BaseObject)Session["navigation"]).AccountabilityWSObject.ViewAccountabilityEmployees();
			DataView dvEmp = dsEmployee.Tables[0].DefaultView;
			dvEmp.RowFilter = "EmployeeStatus = 1";	
			dvEmp.Sort = "FirstName, MiddleName, LastName";
			dsEmployee.Tables.Clear();
			dsEmployee.Tables.Add(CreateTable(dvEmp));			
			return dsEmployee;
		}
		//#endregion
		//----------------------------------------------------------------------
		# region create a table from dataview
		/// <summary>
		/// Convert given dataview to datatable
		/// </summary>
		/// <param name="obDataView"></param>
		/// <returns></returns>
		public static DataTable CreateTable(DataView obDataView)
		{
			if (null == obDataView)
			{
				throw new ArgumentNullException
					("DataView", "Invalid DataView object specified");
			}


		
			///********* End of Enhance Performance by SM ****************///
			//						DataTable obNewDt = obDataView.Table;

			///********* End of Enhance Performance by SM ****************///
			
			

			///********* Old Code ****************///
			DataTable obNewDt = obDataView.Table.Clone();
			int idx = 0;
			string [] strColNames = new string[obNewDt.Columns.Count];
			foreach (DataColumn col in obNewDt.Columns)
			{
				strColNames[idx++] = col.ColumnName;
			}

			IEnumerator viewEnumerator = obDataView.GetEnumerator();
			while (viewEnumerator.MoveNext())
			{
				DataRowView drv = (DataRowView)viewEnumerator.Current;
				DataRow dr = obNewDt.NewRow();
				try
				{
					foreach (string strName in strColNames)
					{
						dr[strName] = drv[strName];
					}
				}
				catch (Exception ex)
				{
					
				}
				obNewDt.Rows.Add(dr);
			}
			///*************** End of Old Code **************************//

			return obNewDt;
		}
		#endregion
		//----------------------------------------------------------------------

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

		protected void DropDownListEmp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		
		protected void RadioButtonListEmp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if( RadioButtonListEmp.SelectedValue == "1" ) 
			{
				DropDownListEmp.Enabled   = true;	
			}
			else 
			{
				DropDownListEmp.Enabled   = false;	
			}
		}

		protected void btnGetReport_Click(object sender, System.EventArgs e)
		{
			try
			{
				string vsDayDetailsReport="";
				if(DropDownListEmp.Items.Count<=0)
					return;
			

				if( RadioButtonListEmp.SelectedValue == "1" ) 
				{
					ViewState["All"]   = false;	
				}
				else 
				{
					ViewState["All"]   = true;	
					//DropDownListEmp.Enabled   = false;	
				}
				int vnContactID=Convert.ToInt32(DropDownListEmp.SelectedItem.Value);

				DataSet dsData=timeWS.GetDayDetailsReport(vnContactID/*Convert.ToInt32(ViewState["ContactID"])*/,Convert.ToDateTime(TextBoxFrom.Text.Trim()),Convert.ToBoolean(ViewState["All"]));
			
				vsDayDetailsReport+=@"<table border =1 id='taskTable' bordercolor='#000066'  cellpadding=0 cellspacing=0 style=border-collapse:collapse width=900>
								 <TR>
								 <TD class='headertd'>Name</TD>
                                 <TD class='headertd'>Date</TD>
                                 <TD class='headertd'>Day</TD>
                                 <TD class='headertd'>Time</TD>
                                 <TD class='headertd'>Status</TD>
                                 <TD class='headertd'>Time</TD>
                                 <TD class='headertd'>Status</TD>
                                 <TD class='headertd'>Division</TD>
								</TR>";
				foreach(DataRow dr in dsData.Tables[0].Rows)
				{

					vsDayDetailsReport+=@"<TR><TD>&nbsp;<font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+dr["Name"].ToString()+"</font></TD>";
					vsDayDetailsReport+=@"<TD align=center width=80><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+dr["Date"].ToString()+"</font></TD>";
					vsDayDetailsReport+=@"<TD align=center width=80><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+dr["Day"].ToString()+"</font></TD>";
					vsDayDetailsReport+=@"<TD align=center width=80><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+dr["CheckInTime"].ToString()+"</font></TD>";
					vsDayDetailsReport+=@"<TD align=center width=80><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+dr["InStatus"].ToString()+"</font></TD>";
					vsDayDetailsReport+=@"<TD align=center width=80><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+dr["CheckOutTime"].ToString()+"</font></TD>";
					vsDayDetailsReport+=@"<TD align=center width=80><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+dr["OutStatus"].ToString()+"</font></TD>";
					vsDayDetailsReport+=@"<TD  width=150>&nbsp;<font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+dr["Division"].ToString()+"</font></TD></TR>";


				}

				vsDayDetailsReport+=@" </Table>";
				divReport.InnerHtml=vsDayDetailsReport;//"<table><tr><td>Hi Sayed</td></tr></table>";
			}
			catch(Exception ex)
			{
             divReport.InnerHtml="<table width=100% align=center><tr><td>there is no data: &nbsp;"+ex.InnerException+"</td></tr></table>";
			}
		}
	}
}
