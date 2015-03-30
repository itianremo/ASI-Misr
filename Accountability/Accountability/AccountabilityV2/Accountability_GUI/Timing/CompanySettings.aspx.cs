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
using TSN.ERP.SharedComponents.Data;

namespace TSN.ERP.WebGUI.Go
{
	/// <summary>
	/// Summary description for TimingCompSettings.
	/// </summary>
	public partial class CompanySettings : System.Web.UI.Page
	{
		protected TSN.ERP.SharedComponents.Data.dsTiming_CompanySettings dsTiming_CompanySettings1;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				Navigation.BaseObject.SafeMerge(dsTiming_CompanySettings1,((Navigation.BaseObject) Session[ "navigation" ]).TimingWSObject.ListCompanyTimingSettings());				
				if(dsTiming_CompanySettings1.Tables[0].Rows.Count != 0)
				{
					dsTiming_CompanySettings.Timing_CompanySettingsRow Row = (dsTiming_CompanySettings.Timing_CompanySettingsRow)dsTiming_CompanySettings1.Timing_CompanySettings.Rows[0];

					txtMailServer.Text = Row.MailServer;
					txtMonthStart.Text = Row.MonthStart.ToString();
					txtMonthEnd.Text = Row.MonthEnd.ToString();
					txtMaxHoursPerDay.Text = Row.MaxHoursPerDay.ToString();
					txtMaxHoursPerWeek.Text = Row.MaxHoursPerWeek.ToString();

					btnUpdate.Text = "Update";
				}
				else
				{
					btnUpdate.Text = "Add";
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
			this.dsTiming_CompanySettings1 = new TSN.ERP.SharedComponents.Data.dsTiming_CompanySettings();
			((System.ComponentModel.ISupportInitialize)(this.dsTiming_CompanySettings1)).BeginInit();
			// 
			// dsTiming_CompanySettings1
			// 
			this.dsTiming_CompanySettings1.DataSetName = "dsTiming_CompanySettings";
			this.dsTiming_CompanySettings1.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.dsTiming_CompanySettings1)).EndInit();

		}
		#endregion

		protected void btnUpdate_Click(object sender, System.EventArgs e)
		{
			dsTiming_CompanySettings1.Clear();
			Navigation.BaseObject.SafeMerge(dsTiming_CompanySettings1,((Navigation.BaseObject) Session[ "navigation" ]).TimingWSObject.ListCompanyTimingSettings());				
			if(dsTiming_CompanySettings1.Timing_CompanySettings.Rows.Count == 0)
			{
				dsTiming_CompanySettings.Timing_CompanySettingsRow Row = dsTiming_CompanySettings1.Timing_CompanySettings.NewTiming_CompanySettingsRow();
				
				try
				{
					Row.Serial          = 0;
					Row.MailServer      = txtMailServer.Text;
					Row.MonthStart      = Convert.ToInt32(txtMonthStart.Text);
					Row.MonthEnd        = Convert.ToInt32(txtMonthEnd.Text);
					Row.MaxHoursPerDay  = Convert.ToDecimal(txtMaxHoursPerDay.Text);
					Row.MaxHoursPerWeek = Convert.ToDecimal(txtMaxHoursPerWeek.Text);

					dsTiming_CompanySettings1.Timing_CompanySettings.AddTiming_CompanySettingsRow(Row);
					int i = ((Navigation.BaseObject) Session[ "navigation" ]).TimingWSObject.EditTimingCompanySettings(dsTiming_CompanySettings1);
					if(i >= 0)
					{
						btnUpdate.Text = "Update";
						lblNote.Visible = true;
						lblNote.Text = "Company timing settings has been added successfully ";
					}
				}				
				catch(Exception ex)
				{
					Response.Write(ex.Message);
				}
			}
			else// is equal to 1
			{
				try
				{
					dsTiming_CompanySettings.Timing_CompanySettingsRow Row = (dsTiming_CompanySettings.Timing_CompanySettingsRow)dsTiming_CompanySettings1.Timing_CompanySettings.Rows[0];

					Row.MailServer      = txtMailServer.Text;
					Row.MonthStart      = Convert.ToInt32(txtMonthStart.Text);
					Row.MonthEnd        = Convert.ToInt32(txtMonthEnd.Text);
					Row.MaxHoursPerDay  = Convert.ToDecimal(txtMaxHoursPerDay.Text);
					Row.MaxHoursPerWeek = Convert.ToDecimal(txtMaxHoursPerWeek.Text);

					int i = ((Navigation.BaseObject) Session[ "navigation" ]).TimingWSObject.EditTimingCompanySettings(dsTiming_CompanySettings1);

					if(i >= 0)
					{
						lblNote.Visible = true;
						lblNote.Text = "Company timing settings has been updated successfully ";
					}
				}				
				catch(Exception ex)
				{
					Response.Write(ex.Message);
				}


			}
		}
	}
}
