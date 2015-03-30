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
using System.Text.RegularExpressions;

namespace TSN.ERP.WebGUI.Timing
{
	/// <summary>
	/// Summary description for SpecialTiming.
	/// </summary>
	public partial class SpecialTiming : System.Web.UI.Page
	{
		protected TSN.ERP.SharedComponents.Data.dsTiming_SpecialTime dsTiming_SpecialTime1;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				FillDataSet();
				dgSpecialTime.DataBind();
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
			this.dsTiming_SpecialTime1 = new TSN.ERP.SharedComponents.Data.dsTiming_SpecialTime();
			((System.ComponentModel.ISupportInitialize)(this.dsTiming_SpecialTime1)).BeginInit();
			// 
			// dsTiming_SpecialTime1
			// 
			this.dsTiming_SpecialTime1.DataSetName = "dsTiming_SpecialTime";
			this.dsTiming_SpecialTime1.Locale = new System.Globalization.CultureInfo("en-US");
			this.dgSpecialTime.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgSpecialTime_Command);
			this.dgSpecialTime.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemsGrid_Cancel);
			this.dgSpecialTime.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemsGrid_Edit);
			this.dgSpecialTime.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemsGrid_Update);
			this.dgSpecialTime.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgSpecialTime_DeleteCommand);
			this.dgSpecialTime.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgSpecialTime_ItemDataBound);
			((System.ComponentModel.ISupportInitialize)(this.dsTiming_SpecialTime1)).EndInit();

		}
		#endregion


		private void FillDataSet()
		{
			Navigation.BaseObject.SafeMerge(dsTiming_SpecialTime1,((Navigation.BaseObject) Session[ "navigation" ]).TimingWSObject.ListSpecialTiming());
		}

		void ItemsGrid_Edit(Object sender, DataGridCommandEventArgs e) 
		{
			dgSpecialTime.EditItemIndex = e.Item.ItemIndex;
			FillDataSet();
			dgSpecialTime.DataBind();
		}

		void ItemsGrid_Cancel(Object sender, DataGridCommandEventArgs e) 
		{
			dgSpecialTime.EditItemIndex = -1;
			FillDataSet();
			dgSpecialTime.DataBind();

		}

		void ItemsGrid_Update(Object sender, DataGridCommandEventArgs e) 
		{
			TextBox txtSerial = (TextBox)e.Item.Cells[0].Controls[1];
			TextBox txtStartDate = (TextBox)e.Item.Cells[1].Controls[1];
			TextBox txtEndDate = (TextBox)e.Item.Cells[2].Controls[1];
			TextBox txtHour = (TextBox)e.Item.Cells[3].Controls[1];

			if(!ValidateData(txtStartDate.Text.Trim(), txtEndDate.Text.Trim(), txtHour.Text.Trim()))
			{
				return;
			}

			int Serial = int.Parse(txtSerial.Text);
			DateTime dtStartDate = DateTime.Parse(txtStartDate.Text);
			DateTime dtEndDate = DateTime.Parse(txtEndDate.Text);
			decimal vndHour = decimal.Parse(txtHour.Text);

			FillDataSet();
			dsTiming_SpecialTime.Timing_SpecialTimeRow Row = dsTiming_SpecialTime1.Timing_SpecialTime.FindBySerial(Serial);

			Row.StartDate = dtStartDate;
			Row.EndDate = dtEndDate;
			Row.HourEqual = vndHour;

			int i = ((Navigation.BaseObject) Session[ "navigation" ]).TimingWSObject.EditSpecialTiming(dsTiming_SpecialTime1);

			FillDataSet();
			dgSpecialTime.EditItemIndex = -1;
			dgSpecialTime.DataBind();

			lblNote.Text = "Row updated successfully";

		}


		void dgSpecialTime_Command(Object sender, DataGridCommandEventArgs e)
		{

			if(e.CommandName == "Add")
			{
				TextBox txtStartDate = (TextBox)e.Item.Cells[1].Controls[1];
				TextBox txtEndDate = (TextBox)e.Item.Cells[2].Controls[1];
				TextBox txtHour = (TextBox)e.Item.Cells[3].Controls[1];

				DateTime dtStartDate = DateTime.Parse(txtStartDate.Text);
				DateTime dtEndDate = DateTime.Parse(txtEndDate.Text);
				decimal vndHour = decimal.Parse(txtHour.Text);

				FillDataSet();
				dsTiming_SpecialTime.Timing_SpecialTimeRow Row = dsTiming_SpecialTime1.Timing_SpecialTime.NewTiming_SpecialTimeRow();
	
				Row.Serial = 0;
				Row.StartDate = dtStartDate;
				Row.EndDate = dtEndDate;
				Row.HourEqual = vndHour;
	
				dsTiming_SpecialTime1.Timing_SpecialTime.AddTiming_SpecialTimeRow(Row);

				int i = ((Navigation.BaseObject) Session[ "navigation" ]).TimingWSObject.EditSpecialTiming(dsTiming_SpecialTime1);

				FillDataSet();
				dgSpecialTime.DataBind();
				lblNote.Text = "Row added successfully";
			}
		}

		private void dgSpecialTime_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			Label lblSerial = (Label)e.Item.Cells[0].Controls[1];
			int Serial = int.Parse(lblSerial.Text);
			FillDataSet();
			dsTiming_SpecialTime.Timing_SpecialTimeRow Row = dsTiming_SpecialTime1.Timing_SpecialTime.FindBySerial(Serial);
			Row.Delete();
			int i = ((Navigation.BaseObject) Session[ "navigation" ]).TimingWSObject.EditSpecialTiming(dsTiming_SpecialTime1);

			FillDataSet();
			dgSpecialTime.DataBind();
			lblNote.Text = "Row deleted successfully";
		}

		private void dgSpecialTime_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			e.Item.Cells[0].Visible=false;
		}

		private bool ValidateData(string StartDate, string EndDate, string HoursValue)
		{
			Regex regDate = new Regex(@"([1-9]|0[1-9]|1[012])[/]([1-9]|0[1-9]|[12][0-9]|3[01])[/](20)\d\d");
			//Validate Start Date	
			Match matchDate = regDate.Match(StartDate);
			if (!matchDate.Success)
			{ 
				lblNote.Text = "Invalid start date";
				return false;
			}            
			//Validate End Date	
			matchDate = regDate.Match(EndDate);
			if (!matchDate.Success)
			{ 
				lblNote.Text = "Invalid end date";
				return false;
			}
           

			try
			{
				double.Parse(HoursValue);
			}
			catch
			{
				lblNote.Text = "Invalid hour value";
				return false;
			}

//			Regex regNumber = new Regex(@"([0-9]+)|([0-9]+[.][0-9]+)|([0-9]*[.][0-9]+)");
//			Match matchNumber = regNumber.Match(HoursValue);
//			if (!matchNumber.Success)
//			{ 
//				lblNote.Text = "Invalid hour value";
//				return false;
//			}
			



			return true;

		}


	}
}
