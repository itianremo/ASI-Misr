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
	/// Summary description for frm_SummaryHoursReport_aspx.
	/// </summary>
	public partial class frmSummaryHoursReport : System.Web.UI.Page
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
		
			return obNewDt;
		}
		#endregion
		//---

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
				DateTime dtFromDate=Convert.ToDateTime(TextBoxFrom.Text.Trim());
				int weekDateCount = -(int)dtFromDate.DayOfWeek;
				DateTime weekStart = dtFromDate.AddDays(weekDateCount);
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
					
				}

				if( rbtnWeeks.SelectedValue == "1" ) 
				{
					ViewState["WeeksCount"]   = 1;	
				}
				else 
				{
					ViewState["WeeksCount"]    = 2;	
				
				}
				int vnContactID=Convert.ToInt32(DropDownListEmp.SelectedItem.Value);

				DataSet dsData=timeWS.GetSummaryReport(vnContactID/*Convert.ToInt32(ViewState["ContactID"])*/,weekStart,Convert.ToBoolean(ViewState["All"]),Convert.ToInt32(ViewState["WeeksCount"]));
			
				//vsDayDetailsReport+=@"<TABLE  cellSpacing='2' cellPadding='2' width='750' border='1'>
				vsDayDetailsReport+=@"<table border =1 id='taskTable' bordercolor='#000066'  cellpadding=0 cellspacing=0 style=border-collapse:collapse width=900>
								 <TR>
								 <TD class='headertd' width=200>Name</TD>
                                 <TD class='headertd'>Sun</TD>
                                 <TD class='headertd'>Mon</TD>
                                 <TD class='headertd'>Tue</TD>
                                 <TD class='headertd'>Wed</TD>
                                 <TD class='headertd'>Thru</TD>
                                 <TD class='headertd'>Fri</TD>
                                 <TD class='headertd'>Sat</TD>
                                 <TD class='headertd'>Week</TD>";
				if(Convert.ToInt32(ViewState["WeeksCount"])==2)
				{
					vsDayDetailsReport+=@"<TD class='headertd'>Sun</TD>
                                 <TD class='headertd'>Mon</TD>
                                 <TD class='headertd'>Tue</TD>
                                 <TD class='headertd'>Wed</TD>
                                 <TD class='headertd'>Thru</TD>
                                 <TD class='headertd'>Fri</TD>
                                 <TD class='headertd'>Sat</TD>
                                 <TD class='headertd'>Week</TD>
                                 <TD class='headertd'>Total</TD>";
				}
				vsDayDetailsReport+=@"</TR>";
				//ViewState["RowsCount"]=0;
				int RowsCount=0;
				foreach(DataRow dr in dsData.Tables[0].Rows)
				{
					RowsCount++;

					//if(Convert.ToBoolean(ViewState["firstRow"]))
					if(RowsCount==1)
					{
					
						vsDayDetailsReport+=@"<TR><TD align=right><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>date&nbsp;</font></TD>";
						vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+ReFormatDate(dr["Sun1Date"].ToString())+"</font></TD>";
						vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+ReFormatDate(dr["Mon1Date"].ToString())+"</font></TD>";
						vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+ReFormatDate(dr["Tue1Date"].ToString())+"</font></TD>";
						vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+ReFormatDate(dr["Wed1Date"].ToString())+"</font></TD>";
						vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+ReFormatDate(dr["Thur1Date"].ToString())+"</font></TD>";
						vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+ReFormatDate(dr["Fri1Date"].ToString())+"</font></TD>";
						vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+ReFormatDate(dr["Sat1Date"].ToString())+"</font></TD>";
						vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>&nbsp;</font></TD>";
						if(Convert.ToInt32(ViewState["WeeksCount"])==2)
						{
							//vsDayDetailsReport+=@"<TR><TD align=right>date</TD>";
							vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+ReFormatDate(dr["Sun2Date"].ToString())+"</font></TD>";
							vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+ReFormatDate(dr["Mon2Date"].ToString())+"</font></TD>";
							vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+ReFormatDate(dr["Tue2Date"].ToString())+"</font></TD>";
							vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+ReFormatDate(dr["Wed2Date"].ToString())+"</font></TD>";
							vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+ReFormatDate(dr["Thur2Date"].ToString())+"</font></TD>";
							vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+ReFormatDate(dr["Fri2Date"].ToString())+"</font></TD>";
							vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+ReFormatDate(dr["Sat2Date"].ToString())+"</font></TD>";
							vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>&nbsp;</font></TD>";
							vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>&nbsp;</font></TD>";
						}
						vsDayDetailsReport+=@"</TR>";
						//ViewState["firstRow"]=false;
					}
					//else
				{
				
					if(RowsCount==1)
						vsDayDetailsReport+=@"<TR><TD>&nbsp;<font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+DropDownListEmp.SelectedItem.Text.Trim()+"</font></TD>";
					else
						vsDayDetailsReport+=@"<TR><TD><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>&nbsp;"+dr["Name"].ToString()+"</font></TD>";

					vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+dr["Sun1WT"].ToString()+"</font></TD>";
					vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+dr["Mon1WT"].ToString()+"</font></TD>";
					vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+dr["Tue1WT"].ToString()+"</font></TD>";
					vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+dr["Wed1WT"].ToString()+"</font></TD>";
					vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+dr["Thur1WT"].ToString()+"</font></TD>";
					vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+dr["Fri1WT"].ToString()+"</font></TD>";
					vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+dr["Sat1WT"].ToString()+"</font></TD>";
					vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+dr["Week1WT"].ToString()+"</font></TD>";

					if(Convert.ToInt32(ViewState["WeeksCount"])==2)
					{
						vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+dr["Sun2WT"].ToString()+"</font></TD>";
						vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+dr["Mon2WT"].ToString()+"</font></TD>";
						vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+dr["Tue2WT"].ToString()+"</font></TD>";
						vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+dr["Wed2WT"].ToString()+"</font></TD>";
						vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+dr["Thur2WT"].ToString()+"</font></TD>";
						vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+dr["Fri2WT"].ToString()+"</font></TD>";
						vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+dr["Sat2WT"].ToString()+"</font></TD>";
						vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+dr["Week2WT"].ToString()+"</font></TD>";
						vsDayDetailsReport+=@"<TD align=center width=50><font face='Arial, Helvetica, sans-serif' color=#003366 size=2>"+dr["Total"].ToString()+"</font></TD>";
					}
					vsDayDetailsReport+=@"</TR>";
				}

				}

				vsDayDetailsReport+=@" </Table>";
				divReport.InnerHtml=vsDayDetailsReport;//"<table><tr><td>Hi Sayed</td></tr></table>";
			}
			catch(Exception ex)
			{
				divReport.InnerHtml="<table width=100% align=center><tr><td><font face='Arial, Helvetica, sans-serif' color=#003366 size=3>there is no data: &nbsp;"+ex.InnerException+"</font></td></tr></table>";
			}
		}
		string ReFormatDate(string vsDate)
		{
			try
			{
				DateTime dt=Convert.ToDateTime(vsDate.Trim());
				string VsMonthDay=dt.Month+"/"+dt.Day;
				return VsMonthDay;
			}
			catch
			{
				return "&nbsp;";
			}
		}
	}
}
