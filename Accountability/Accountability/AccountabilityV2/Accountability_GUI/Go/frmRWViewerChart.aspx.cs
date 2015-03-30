using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Globalization;
using Stimulsoft.Report.Units;

namespace TSN.ERP.WebGUI.Go
{
	/// <summary>
	/// Summary description for ReportViewer.
	/// </summary>
	public partial class frmRWViewer : System.Web.UI.Page
	{
		protected TSN.ERP.WebGUI.Go.rep.dsTotalAccSheet dsTotalAccSheet;
		protected TSN.ERP.SharedComponents.Data.dsAccountabilitySheet dsAccountabilitySheet;
		//protected Stimulsoft.Report.Web.StiWebViewer StiWebViewer1;
		protected TSN.ERP.SharedComponents.Data.DsTaskSummReport dsTaskSummReport1;
		protected System.Data.DataSet dataSetEmpData;
		protected System.Data.DataTable dataTable2;
		protected System.Data.DataColumn dataColumn11;
		protected System.Data.DataColumn dataColumn12;
		protected System.Data.DataColumn dataColumn13;
		protected System.Data.DataColumn dataColumn14;
		protected System.Data.DataColumn dataColumn15;
		protected System.Data.DataSet dataSetNotes;
		protected System.Data.DataTable dataTable3;
		protected System.Data.DataColumn dataColumn16;
		protected TSN.ERP.SharedComponents.Data.dsTeams dsTeams1;
		protected TSN.ERP.SharedComponents.Data.dsEmployee dsEmployee1;
		protected System.Data.DataColumn dataColumn17;
		
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            lblError.Visible = false;
            try
            {
                // Added By Sayed 21-2-2010  to set the default size of chart according to request from Rod.
                int FileID = Convert.ToInt32(Session["ChartID"]);

                byte[] imgBinary = ((Navigation.BaseObject)Session["navigation"]).OrgnizationChartsWSObject.LoadChartBody(FileID);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(imgBinary);
                System.Drawing.Bitmap originalImage = new Bitmap(ms);
                int newWidth = originalImage.Width;
                int newHeight = originalImage.Height;
                //float fh = originalImage.VerticalResolution;
                //float fw = originalImage.HorizontalResolution;
                double dh = newHeight / 75.0;
                txtHeight.Text = dh.ToString();
                double dw = newWidth / 75.0;
                txtWidth.Text = dw.ToString();
                RunReport();
            }
           
            catch (System.ArgumentException ex)
            {
                StiWebViewer1.Visible = false;
                lblError.Visible = true;
                lblError.Text = "Chart is not valid, please recreat it again";
                return;
            }
            catch (Exception ex)
            {
                StiWebViewer1.Visible = false;
                string x = ex.Message;
                //btnRunReport_Click(null, null);
                return;
            }


            //
           // 

		}
		//--------------------------------------------------------------------
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
			this.dsTotalAccSheet = new TSN.ERP.WebGUI.Go.rep.dsTotalAccSheet();
			this.dsAccountabilitySheet = new TSN.ERP.SharedComponents.Data.dsAccountabilitySheet();
			this.dsTaskSummReport1 = new TSN.ERP.SharedComponents.Data.DsTaskSummReport();
			this.dataSetEmpData = new System.Data.DataSet();
			this.dataTable2 = new System.Data.DataTable();
			this.dataColumn11 = new System.Data.DataColumn();
			this.dataColumn12 = new System.Data.DataColumn();
			this.dataColumn13 = new System.Data.DataColumn();
			this.dataColumn14 = new System.Data.DataColumn();
			this.dataColumn15 = new System.Data.DataColumn();
			this.dataSetNotes = new System.Data.DataSet();
			this.dataTable3 = new System.Data.DataTable();
			this.dataColumn16 = new System.Data.DataColumn();
			this.dataColumn17 = new System.Data.DataColumn();
			this.dsTeams1 = new TSN.ERP.SharedComponents.Data.dsTeams();
			this.dsEmployee1 = new TSN.ERP.SharedComponents.Data.dsEmployee();
			((System.ComponentModel.ISupportInitialize)(this.dsTotalAccSheet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsAccountabilitySheet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTaskSummReport1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetEmpData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetNotes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTeams1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsEmployee1)).BeginInit();
			// 
			// dsTotalAccSheet
			// 
			this.dsTotalAccSheet.DataSetName = "dsTotalAccSheet";
			this.dsTotalAccSheet.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dsAccountabilitySheet
			// 
			this.dsAccountabilitySheet.DataSetName = "dsAccountabilitySheet";
			this.dsAccountabilitySheet.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// dsTaskSummReport1
			// 
			this.dsTaskSummReport1.DataSetName = "DsTaskSummReport";
			this.dsTaskSummReport1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dataSetEmpData
			// 
			this.dataSetEmpData.DataSetName = "dsEmpData";
			this.dataSetEmpData.Locale = new System.Globalization.CultureInfo("en-US");
			this.dataSetEmpData.Tables.AddRange(new System.Data.DataTable[] {
																				this.dataTable2});
			// 
			// dataTable2
			// 
			this.dataTable2.Columns.AddRange(new System.Data.DataColumn[] {
																			  this.dataColumn11,
																			  this.dataColumn12,
																			  this.dataColumn13,
																			  this.dataColumn14,
																			  this.dataColumn15});
			this.dataTable2.TableName = "EmpData";
			// 
			// dataColumn11
			// 
			this.dataColumn11.ColumnName = "EmpName";
			// 
			// dataColumn12
			// 
			this.dataColumn12.ColumnName = "Title";
			// 
			// dataColumn13
			// 
			this.dataColumn13.ColumnName = "Division";
			// 
			// dataColumn14
			// 
			this.dataColumn14.ColumnName = "FromDate";
			// 
			// dataColumn15
			// 
			this.dataColumn15.ColumnName = "ToDate";
			// 
			// dataSetNotes
			// 
			this.dataSetNotes.DataSetName = "dsNotes";
			this.dataSetNotes.Locale = new System.Globalization.CultureInfo("en-US");
			this.dataSetNotes.Tables.AddRange(new System.Data.DataTable[] {
																			  this.dataTable3});
			// 
			// dataTable3
			// 
			this.dataTable3.Columns.AddRange(new System.Data.DataColumn[] {
																			  this.dataColumn16,
																			  this.dataColumn17});
			this.dataTable3.TableName = "Table";
			// 
			// dataColumn16
			// 
			this.dataColumn16.ColumnName = "AccountabilityDate";
			this.dataColumn16.DataType = typeof(System.DateTime);
			// 
			// dataColumn17
			// 
			this.dataColumn17.ColumnName = "NoteBody";
			// 
			// dsTeams1
			// 
			this.dsTeams1.DataSetName = "dsTeams";
			this.dsTeams1.EnforceConstraints = false;
			this.dsTeams1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dsEmployee1
			// 
			this.dsEmployee1.DataSetName = "dsEmployee";
			this.dsEmployee1.Locale = new System.Globalization.CultureInfo("ar-EG");
			((System.ComponentModel.ISupportInitialize)(this.dsTotalAccSheet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsAccountabilitySheet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTaskSummReport1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetEmpData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSetNotes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsTeams1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsEmployee1)).EndInit();

		}
		#endregion



        protected void btnRunReport_Click(object sender, EventArgs e)
        {
            RunReport();
            
        }

        private void RunReport()
        {
            try
            {
                StiWebViewer1.Visible = true;
                lblError.Text = "";
                lblError.Visible = false;
                try
                {

                    Convert.ToDouble(txtWidth.Text.Trim());
                    Convert.ToDouble(txtHeight.Text.Trim());
                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = "Invalid Values";
                    return;
                }
                // int ChartID = int.Parse(Request["ChartID"]);

                // byte[] rep = (byte[])ViewState["Report"];
                int FileID = Convert.ToInt32(Session["ChartID"]);
                //byte[] imgBinary;
                //imgBinary = ((Navigation.BaseObject)Session["navigation"]).OrgnizationChartsWSObject.LoadChartBody(FileID);


                TSN.ERP.SharedComponents.Data.dsChart dsChart = new TSN.ERP.SharedComponents.Data.dsChart();
                DataRow dr = dsChart.Tables[0].NewRow();
                dr["FileName"] = Convert.ToString(Session["ChartName"]);
                //  System.Data.OleDb.OleDbType.VarBinary  vbinary = ((Navigation.BaseObject)Session["navigation"]).OrgnizationChartsWSObject.LoadChartBody(FileID); 
                dr["FileBody"] = ((Navigation.BaseObject)Session["navigation"]).OrgnizationChartsWSObject.LoadChartBody(FileID);

                dsChart.Tables[0].Rows.Add(dr);
                dsChart.AcceptChanges();

                if (StiWebViewer1.IsImageRequest) return;
                if (dsChart != null)
                {
                    Stimulsoft.Report.StiReport CurrentReportDocument = new Stimulsoft.Report.StiReport();
                    //CurrentReportDocument.Load("rep /Report.mrt");
                    string path = Server.MapPath("rep/RepChartN.mrt");
                    try
                    {
                        CurrentReportDocument.Load(path);
                    }
                    catch (Exception ee)
                    {
                        string s = ee.Message;
                    }
                    // Stimulsoft.Report.Components.StiPage page = CurrentReportDocument.Pages[0];
                    CurrentReportDocument.Pages[0].Width = Convert.ToDouble(txtWidth.Text.Trim());
                    CurrentReportDocument.Pages[0].Height = Convert.ToDouble(txtHeight.Text.Trim());

                    if (rbPortrait.Checked)
                        CurrentReportDocument.Pages[0].Orientation = Stimulsoft.Report.Components.StiPageOrientation.Portrait;
                    else
                        CurrentReportDocument.Pages[0].Orientation = Stimulsoft.Report.Components.StiPageOrientation.Landscape;

                    StiUnit unitTo = new StiInchesUnit();
                    CurrentReportDocument.Convert(CurrentReportDocument.Unit, unitTo);

                    CurrentReportDocument.RegData(dsChart);
                    //CurrentReportDocument.Render();
                    //CurrentReportDocument.Show();
                    StiWebViewer1.Report = CurrentReportDocument;
                    StiWebViewer1.Visible = true;

                    #region commented

                    /* Stimulsoft.Report.Components.StiImage image = new Stimulsoft.Report.Components.StiImage();
                 image.Left = 0;
                 image.Top = 0;
                 image.Width = 10;
                 image.Height = 10;

                 //An image name should be unique in your report
                 image.Name = "MyUniqueName"; 

                ////Assign the image
                //image.Image = myImage;

                ////Add the component with the image with the report
                //CurrentReportDocument.Pages[0].Components.Add(image);
                //
                // Response.Cache.SetCacheability(HttpCacheability.NoCache);
                // TSN.ERP.SharedComponents.Data.dsOrgnizationCharts dsOrgnizationCharts1 = (TSN.ERP.SharedComponents.Data.dsOrgnizationCharts)ViewState["dsOrgnizationCharts1"];
                //int FileID = Convert.ToInt32(Session["ChartID"]);
                //byte[] imgBinary;
                //imgBinary = ((Navigation.BaseObject)Session["navigation"]).OrgnizationChartsWSObject.LoadChartBody(FileID);


                //TSN.ERP.SharedComponents.Data.dsChart dsChart = new TSN.ERP.SharedComponents.Data.dsChart();
                //DataRow dr = dsChart.Tables[0].NewRow();
                //dr["FileName"] = "FileName";
                ////  System.Data.OleDb.OleDbType.VarBinary  vbinary = ((Navigation.BaseObject)Session["navigation"]).OrgnizationChartsWSObject.LoadChartBody(FileID); 
                //dr["FileBody"] = ((Navigation.BaseObject)Session["navigation"]).OrgnizationChartsWSObject.LoadChartBody(FileID);

                //dsChart.Tables[0].Rows.Add(dr);
                //dsChart.AcceptChanges();
                //string strtable = dsChart.Tables[0].TableName;
                //Response.OutputStream.Write((byte[])dsChart.Tables[0].Rows[0]["FileBody"], 0, ((byte[])dsChart.Tables[0].Rows[0]["FileBody"]).Length);
                //Response.OutputStream.Close();
                //Response.Write(dsChart.Tables[0].Rows[0]["FileName"]+"<br>");
                //Response.Write(dsChart.Tables[0].Rows[0]["FileBody"] + "<br>");
                //CurrentReportDocument.RegData(dsChart.Tables[0]);
                //StiWebViewer1.Report = CurrentReportDocument;
                //StiWebViewer1.Visible = true;
                //Response.ContentType = imgBinary.ToString();

                //Response.BinaryWrite(imgBinary);
                // Response.OutputStream.Write(imgBinary, 0, imgBinary.Length);

                 System.IO.MemoryStream str = new System.IO.MemoryStream();
                 str.Write(imgBinary, 0, imgBinary.Length);
                 Bitmap bit = new Bitmap(str);
                 System.Drawing.Image img = (System.Drawing.Image)bit;
                 //Assign the image
                 image.Image = img;

                 //Add the component with the image with the report
                 CurrentReportDocument.Pages[0].Components.Add(image);
                 CurrentReportDocument.Render();  */
                    #endregion commented
                }
            }
            catch (System.ArgumentException ex)
            {
                StiWebViewer1.Visible = false;
                lblError.Visible = true;
                lblError.Text = "Chart is not valid, please recreat it again";
                return;
            }
            catch (Exception ex)
            {
                StiWebViewer1.Visible = false;
                lblError.Visible = true;
                lblError.Text = "Chart is not valid, please recreat it again";
                return;

            }
        }
}
}
