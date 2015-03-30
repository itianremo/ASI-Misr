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
using System.Drawing.Imaging;
using MindFusion.FlowChartX.LayoutSystem;
using MindFusion.FlowChartX;
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;



//using MindFusion.Diagramming.Export;
using MindFusion.FlowChartX;
using Microsoft.Office.Interop.Visio;


namespace TSN.ERP.WebGUI.Go.flowcharts
{
	/// <summary>
	/// Summary description for frmViewChart.
	/// </summary>
	public partial class frmViewChart : System.Web.UI.Page
	{
		#region Class members
		protected TSN.ERP.SharedComponents.Data.dsOrgnizationCharts dsOrgnizationCharts;
		#endregion
		//------------------------------------------------------------------
		#region page load
		protected void Page_Load(object sender, System.EventArgs e)
		{
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            if (! Page.IsPostBack)
            {
                
                
                if (Session["CurrentOgnizationChartIndex"] == null)
                {
                        FlowChart fcsession = (FlowChart)Session["fcx"];
                        string streamData="";                 
                        streamData= fcsession.SaveToString();
                        fcChart.LoadFromString(streamData);
                        fcChart.ArrowStyle = MindFusion.Diagramming.WebForms.ArrowStyle.Cascading;
                      
                }
                else
                {
                   
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        ms = (System.IO.MemoryStream)Session["EditChart"];
                        fcChart.LoadFromStream(ms);
                        fcChart.ArrowStyle = MindFusion.Diagramming.WebForms.ArrowStyle.Cascading;
                        btnSave.Visible = true;
 
                }

                
                
            }

            
           
            //***********/


           

		}
		#endregion
		//------------------------------------------------------------------
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
			this.dsOrgnizationCharts = new TSN.ERP.SharedComponents.Data.dsOrgnizationCharts();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgnizationCharts)).BeginInit();
			// 
			// dsOrgnizationCharts
			// 
			this.dsOrgnizationCharts.DataSetName = "dsOrgnizationCharts";
			this.dsOrgnizationCharts.Locale = new System.Globalization.CultureInfo("ar-EG");
			((System.ComponentModel.ISupportInitialize)(this.dsOrgnizationCharts)).EndInit();

		}
		#endregion
		//------------------------------------------------------------------
		#region back button
		protected void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("frmColors.aspx?chartname="+Request.QueryString["chartname"]+"&action="+Request.QueryString["action"]+"&chartid="+Request.QueryString["chartid"]);
		}
		#endregion
		//------------------------------------------------------------------
		#region save chart button
		protected void btnSave_Click(object sender, System.EventArgs e)
		{
            if (Session["chartType"] != null)
            {
                int chartType = int.Parse(Session["chartType"].ToString());
            }
            
			
			try
			{
				System.Text.UTF7Encoding utf = new System.Text.UTF7Encoding();
				// get the chart class file
                
				Chart ch = (Chart) Session["chartObject"];
				// save new chart
				if (Session["FileID"].ToString() == "")	 
				{
					//AddChart(ch);
                    AddChart();
                    //ch = (Chart)Session["chartObject"];
					lblMsg.Visible = true;
					btnSave.Enabled = false;
                    btnBack.Enabled = false;
                   fcChart.ClientSideMode = MindFusion.Diagramming.WebForms.ClientSideMode.ImageMap; 
                  
                   imgChart.Visible = true;
                   fcChart.Visible = false;
                   // 30-12-2010 By Sayed
                   //string chartn = ch.Name;
                   //string[] str = Regex.Split(chartn, "\r\n");
                   //string ChartName = str[0].ToString();
                   //((Navigation.BaseObject)Session["navigation"]).OrgnizationChartsWSObject.ModifyChartDescription(int.Parse(Session["FileID"].ToString()), ChartName);


                   
				}
				else
				{
					EditChart(ch,int.Parse(Session["FileID"].ToString()));
                    fcChart.ClientSideMode = MindFusion.Diagramming.WebForms.ClientSideMode.ImageMap; 
					lblMsg.Visible = true;
					btnSave.Enabled = false;
                    btnBack.Enabled = false;
                    Session["EditChart"] = null;

				}

			}
			catch(Exception ex)
			{
				//Response.Write(ex.Message);
			}	
		}
		#endregion
		//------------------------------------------------------------------
		#region export sheet
		protected void btnExport_Click(object sender, System.EventArgs e)
		{
            //FlowChart fc = (FlowChart)Session["fcx"];
           //VisioExporter ve = new VisioExporter();
           // ve.CreateVisioGroups = true;
           // ve.Export(fc, "chart.vdx");

            //MindFusion.Diagramming.Export.VisioExporter ve = new MindFusion.Diagramming.Export.VisioExporter();
            //MindFusion.FlowChartX.FlowChart winfc = new MindFusion.FlowChartX.FlowChart();
            //winfc.LoadFromString(ViewState["originFC"].ToString());
            //ve.Export(winfc, "C:"); 

            //MindFusion.FlowChartX.FlowChart winfc = new MindFusion.FlowChartX.FlowChart();
            //winfc.LoadFromString(webfc.SaveToString());
            //ve.Export(fc, "c:\\Temp\\dependency.vdx");  
		
		}
		#endregion
		//------------------------------------------------------------------
		#region Save new chart into database
		private void AddChart(Chart ch)
		{  
			XmlSerializer s;
			ERP.SharedComponents.Data.dsOrgnizationCharts.GEN_OrgnizationChartsRow row;
			try
			{
				System.Text.UTF7Encoding utf = new System.Text.UTF7Encoding();
				row= dsOrgnizationCharts.GEN_OrgnizationCharts.NewGEN_OrgnizationChartsRow();
					row.FileID = 100000;
				row.OChartDesc = ch.Name;
				// serialize chart object
				if (ch.Type ==1)
					s = new XmlSerializer(typeof(DeptHierarchyChart));
				else if (ch.Type ==2)
				   s = new XmlSerializer(typeof(TitlesChart));
				else if (ch.Type ==3)
					s = new XmlSerializer(typeof(TeamsChart));
				else 
					s = new XmlSerializer(typeof(ProjectsChart));
	
				row.OChartType = ch.Type; 
				MemoryStream ms = new MemoryStream();
                
				s.Serialize(ms,ch);
				row.OChartObject = utf.GetString(ms.ToArray());
				ms.Close();
				//--------------------------
				dsOrgnizationCharts.Tables[0].Rows.Add(row);
				((Navigation.BaseObject) Session[ "navigation" ]).OrgnizationChartsWSObject.AddChartsInfo(dsOrgnizationCharts);			
				DataSet ds =  ((Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.LastDataSet();
				DataRow dr = ds.Tables[0].Rows[0];
				// Convert chart object to array of bytes
				FlowChart fc = (FlowChart)Session["fcx"];
				
                Bitmap bmp = fc.CreateBmpFromChart();

                System.IO.MemoryStream stream2 = new System.IO.MemoryStream();
                
                // Save image to stream.
                bmp.Save(stream2, ImageFormat.Jpeg);

                // save it into database
               ((Navigation.BaseObject)Session["navigation"]).OrgnizationChartsWSObject.UpdateChartBody(int.Parse(dr["FileID"].ToString()), stream2.ToArray());
               
				Session["FileID"] = dr["FileID"];

			}
			catch(Exception ex)
			{
				Response.Write(ex.Message);
			}
		
		}
        private void AddChart()
        {
            XmlSerializer s;
            ERP.SharedComponents.Data.dsOrgnizationCharts.GEN_OrgnizationChartsRow row;
            try
            {
                Chart ch = (Chart)Session["chartObject"];
                System.Text.UTF7Encoding utf = new System.Text.UTF7Encoding();
                row = dsOrgnizationCharts.GEN_OrgnizationCharts.NewGEN_OrgnizationChartsRow();
                row.FileID = 100000;
                           

                row.OChartDesc = ch.Name;
                //29-12-2010
                //ch.Name = ch.Name + System.Environment.NewLine + "Printed "+DateTime.Now.ToShortDateString();
                
               // ch.Render();
               
                //
                // serialize chart object
                if (ch.Type == 1)
                    s = new XmlSerializer(typeof(DeptHierarchyChart));
                else if (ch.Type == 2)
                    s = new XmlSerializer(typeof(TitlesChart));
                else if (ch.Type == 3)
                    s = new XmlSerializer(typeof(TeamsChart));
                else
                    s = new XmlSerializer(typeof(ProjectsChart));

                row.OChartType = ch.Type;
                MemoryStream ms = new MemoryStream();
                //ch = (Chart)Session["chartObject"]; 
                s.Serialize(ms, ch);
                row.OChartObject = utf.GetString(ms.ToArray());
                ms.Close();


                //--------------------------
                dsOrgnizationCharts.Tables[0].Rows.Add(row);
                ((Navigation.BaseObject)Session["navigation"]).OrgnizationChartsWSObject.AddChartsInfo(dsOrgnizationCharts);
                DataSet ds = ((Navigation.BaseObject)Session["navigation"]).SessionWSObject.LastDataSet();
                DataRow dr = ds.Tables[0].Rows[0];

                System.IO.MemoryStream st = new System.IO.MemoryStream();
                fcChart.SaveToStream(st);

                ((Navigation.BaseObject)Session["navigation"]).OrgnizationChartsWSObject.UpdateChartBody(int.Parse(dr["FileID"].ToString()), st.ToArray());

                Session["FileID"] = dr["FileID"];
                // 30-12-2010 By Sayed
                //string chartn = ch.Name;
                //string[] str = Regex.Split(chartn, "\r\n");
                //string ChartName = str[0].ToString();
                //((Navigation.BaseObject)Session["navigation"]).OrgnizationChartsWSObject.ModifyChartDescription(int.Parse(dr["FileID"].ToString()), ChartName);

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }
		#endregion
		//------------------------------------------------------------------
		#region Edit chart
		private void EditChart(Chart ch,int fileID)
		{
			XmlSerializer s;
			ERP.SharedComponents.Data.dsOrgnizationCharts.GEN_OrgnizationChartsRow row;
			try
            {
                #region old code
                /*
                System.Text.UTF7Encoding utf = new System.Text.UTF7Encoding();
				dsOrgnizationCharts.Merge(((Navigation.BaseObject) Session[ "navigation" ]).OrgnizationChartsWSObject.ListChartsInfo());
				row= dsOrgnizationCharts.GEN_OrgnizationCharts.FindByFileID(fileID);
				row.OChartDesc = ch.Name;
				// serialize chart object
				if (ch.Type ==1)
					s = new XmlSerializer(typeof(DeptHierarchyChart));
				else if (ch.Type ==2)
					s = new XmlSerializer(typeof(TitlesChart));
				else if (ch.Type ==3)
					s = new XmlSerializer(typeof(TeamsChart));
				else 
					s = new XmlSerializer(typeof(ProjectsChart));
				row.OChartType = ch.Type; 
				MemoryStream ms = new MemoryStream();
				s.Serialize(ms,ch);
				row.OChartObject = utf.GetString(ms.ToArray());
				ms.Close();
				//--------------------------
				((Navigation.BaseObject) Session[ "navigation" ]).OrgnizationChartsWSObject.ModifyChartsInfo(dsOrgnizationCharts);			
				FlowChart fc = (FlowChart)Session["fcx"];
				System.IO.MemoryStream st = new System.IO.MemoryStream();
				fc.SaveToStream(st,true);
				// save it into database
               

                Bitmap bmp = fc.CreateBmpFromChart();

                System.IO.MemoryStream stream2 = new System.IO.MemoryStream();

                // Save image to stream.
                bmp.Save(stream2, ImageFormat.Jpeg);

                // stream2.ToArray()
                
                ((Navigation.BaseObject)Session["navigation"]).OrgnizationChartsWSObject.UpdateChartBody(fileID, stream2.ToArray());
                
                //Session["FileID"] = fileID;
                //Session["fcx"] = fc;


                // comented 11-2-2010
                //((Navigation.BaseObject) Session[ "navigation" ]).OrgnizationChartsWSObject.UpdateChartBody(fileID,st.ToArray());
                */
                #endregion
                System.IO.MemoryStream st = new System.IO.MemoryStream();
                fcChart.SaveToStream(st);

                ((Navigation.BaseObject)Session["navigation"]).OrgnizationChartsWSObject.UpdateChartBody(int.Parse(Session["FileID"].ToString()), st.ToArray());

               
            }
			catch(Exception ex)
			{
				Response.Write(ex.Message);
			}
		}
		#endregion
		//------------------------------------------------------------------

	}
}
