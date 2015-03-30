namespace TSN.ERP.WebGUI.Go
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Drawing;
    using System.Web;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;
    using System.Xml.Serialization;
    using System.IO;
    using System.Configuration;
    using TSHAK.Components;
    using System.Drawing.Imaging;

    /// <summary>
    ///		Summary description for ctlFlowChartsList.
    /// </summary>
    public partial class ctlFlowChartsList : System.Web.UI.UserControl
    {
        protected TSN.ERP.SharedComponents.Data.dsOrgnizationCharts dsOrgnizationCharts1;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                dsOrgnizationCharts1.Merge(((Navigation.BaseObject)Session["navigation"]).OrgnizationChartsWSObject.ListChartsInfo());
                //Filter Charts List
                MasterMethods master = new MasterMethods();
                DataView dvCharts = dsOrgnizationCharts1.Tables[0].DefaultView;
                dvCharts.Sort = "OChartDesc";
                dsOrgnizationCharts1.Tables.Clear();
                dsOrgnizationCharts1.Tables.Add(master.CreateTableFromView(dvCharts));
                dsOrgnizationCharts1.AcceptChanges();
                //////////////////////
                dgFlowCharts.DataBind();
                ViewState["dsOrgnizationCharts1"] = dsOrgnizationCharts1;
                Session["FileID"] = "";
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
            this.dsOrgnizationCharts1 = new TSN.ERP.SharedComponents.Data.dsOrgnizationCharts();
            ((System.ComponentModel.ISupportInitialize)(this.dsOrgnizationCharts1)).BeginInit();
            this.dgFlowCharts.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgFlowCharts_ItemCommand);
            this.dgFlowCharts.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgFlowCharts_ItemDataBound);
            // 
            // dsOrgnizationCharts1
            // 
            this.dsOrgnizationCharts1.DataSetName = "dsOrgnizationCharts";
            this.dsOrgnizationCharts1.Locale = new System.Globalization.CultureInfo("ar-EG");
            ((System.ComponentModel.ISupportInitialize)(this.dsOrgnizationCharts1)).EndInit();

        }
        #endregion

        private void dgFlowCharts_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            System.Text.UTF7Encoding utf = new System.Text.UTF7Encoding();
            string s = "";
            XmlSerializer x;
            try
            {
                WebControl TempControl = (WebControl)e.CommandSource;
                if (TempControl.ID == "imgDownload")
                {
                    dsOrgnizationCharts1 = (TSN.ERP.SharedComponents.Data.dsOrgnizationCharts)ViewState["dsOrgnizationCharts1"];
                    int FileID = dsOrgnizationCharts1.GEN_OrgnizationCharts[e.Item.ItemIndex].FileID;
                    string ChartName = dsOrgnizationCharts1.GEN_OrgnizationCharts[e.Item.ItemIndex].OChartDesc;
                    if (FileID != null)
                    {
                        // int ChartID = (int)Session["CurrentOgnizationChartIndex"];
                        byte[] tempbuffer = ((Navigation.BaseObject)Session["navigation"]).OrgnizationChartsWSObject.LoadChartBody(FileID);
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(tempbuffer);

                        MindFusion.Diagramming.WebForms.FlowChart chartCtrl = new MindFusion.Diagramming.WebForms.FlowChart();
                        chartCtrl.LoadFromStream(ms);

                        Bitmap bmp = chartCtrl.CreateImage();
                        System.IO.MemoryStream stream2 = new System.IO.MemoryStream();

                        //// Create another image 
                        Bitmap bmp1 = new Bitmap(bmp.Width, 100);
                        Graphics g = Graphics.FromImage(bmp1);
                        g.Clear(System.Drawing.Color.White);

                        // add text 
                        StringFormat strFormat = new StringFormat();
                        strFormat.Alignment = StringAlignment.Center;
                        strFormat.LineAlignment = StringAlignment.Center;
                        g.DrawString(ChartName, new Font("Tahoma", 18), Brushes.Black,
                            new RectangleF(0, 0, bmp.Width, 100), strFormat);
                         // added By Sayed 30-12-2010
                            //g.DrawString("Printed"+DateTime.Now.ToShortDateString(), new Font("Tahoma", 18), Brushes.Black,
                            //     new RectangleF(0, 20, bmp.Width, 100), strFormat);
                            //


                        ////end text


                        // combine the 2 images
                        int width = Math.Max(bmp1.Width, bmp.Width);
                        int height = bmp1.Height + bmp.Height;
                        Bitmap fullBmp = new Bitmap(width, height);
                        Graphics gr = Graphics.FromImage(fullBmp);
                        gr.DrawImage(bmp1, 0, 0, bmp1.Width, bmp1.Height);
                        gr.DrawImage(bmp, 0, bmp1.Height);
                        fullBmp.Save(stream2, ImageFormat.Jpeg);

                        //bmp.Save(stream2, ImageFormat.Jpeg);

                        //***********/
                        byte[] imgBinary = stream2.ToArray();
                        byte[] rep = imgBinary;
                        Page.Response.AddHeader("Content-Disposition", "attachment;filename=" + ChartName.Trim() + ".Jpeg");
                        Page.Response.AddHeader("Content-Length", rep.Length.ToString());
                        Page.Response.ContentType = "application/octet-stream";
                        Page.Response.Buffer = true;

                        //Displaying a dialog taht will ask user to open file or even to download it locally on hard disk
                        Page.Response.BinaryWrite(rep);
                        //Flushing all data after downloading it
                        //Page.Response.Flush();
                        //Page.Response.Close();
                        //Page.Response.End();
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                        return;
                    }
                }

                else if (TempControl.ID == "imgExport")
                {

                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    dsOrgnizationCharts1 = (TSN.ERP.SharedComponents.Data.dsOrgnizationCharts)ViewState["dsOrgnizationCharts1"];
                    int FileID = dsOrgnizationCharts1.GEN_OrgnizationCharts[e.Item.ItemIndex].FileID;
                    string ChartName = dsOrgnizationCharts1.GEN_OrgnizationCharts[e.Item.ItemIndex].OChartDesc;
                    byte[] imgBinary;
                    imgBinary = ((Navigation.BaseObject)Session["navigation"]).OrgnizationChartsWSObject.LoadChartBody(FileID);
                    Session["ChartID"] = FileID;
                    Session["ChartName"] = ChartName;
                    //Response.Redirect("../go/frmrwviewerChart.aspx");
                    string frameScript = "<script language='javascript'> window.open( '../go/frmrwviewerChart.aspx?ChartID=" + FileID + "&ChartName=" + ChartName + "','PreViewChart','width=1000,height=650,scrollbars=yes,resizable=yes') </script>";
                    Page.RegisterStartupScript("FrameScript", frameScript);
                    /* byte[] rep = imgBinary;
                     Page.Response.AddHeader("Content-Disposition", "attachment;filename=xx.Jpeg");
                     Page.Response.AddHeader("Content-Length", rep.Length.ToString());
                     Page.Response.ContentType = "application/octet-stream";
                     Page.Response.Buffer = true;

                     //Displaying a dialog taht will ask user to open file or even to download it locally on hard disk
                     Page.Response.BinaryWrite(rep);
                     //Flushing all data after downloading it
                     Page.Response.Flush();
                     Page.Response.Close();
                     Page.Response.End();*/


                    //  connection.Close();

                }
                #region
                /* else if (TempControl.ID == "imgPreview")
				{
                    
					dsOrgnizationCharts1 = (TSN.ERP.SharedComponents.Data.dsOrgnizationCharts)ViewState["dsOrgnizationCharts1"];
							
                    string FileID = dsOrgnizationCharts1.GEN_OrgnizationCharts[e.Item.ItemIndex].FileID.ToString();
                    string OrgChartName = dsOrgnizationCharts1.GEN_OrgnizationCharts[e.Item.ItemIndex].OChartDesc;
                   
                    string repID = System.Configuration.ConfigurationSettings.AppSettings["OrgChartRepID"];// "725";//((DataGrid)sender).Items[((DataGrid)sender).SelectedIndex].Cells[0].Text;
                   // string repType = ((DataGrid)sender).Items[((DataGrid)sender).SelectedIndex].Cells[2].Text;

                    //if (repType == "1")
                    //{
                    //    string frameScript = "<script language='javascript'> window.open( '../go/frmRWViewer.aspx?rpid=" + repID + "') </script>";
                    //    Page.RegisterStartupScript("FrameScript", frameScript);
                    //}
                    //else
                    {
                        string token = ((Navigation.BaseObject)Session["navigation"]).Token.Replace(@"\", "*");
                        //cod added by Sayed Moawad 08/08/2007
                        // apply Encryption to send query string as encrypted to  Report Writer
                        string VsQueryString = "2&IsAdmin=" + Convert.ToInt32(((Navigation.BaseObject)Page.Session["navigation"]).SecInfo.IsAdministrator) + "&ContactID=" + ((Navigation.BaseObject)Session["navigation"]).SessionWSObject.GetLoggedUserID().ToString() + "&repID=" + repID + "&TK=" + token;

                        //Response.Redirect("http://localhost:3191/ReportWriter/default.aspx?data=" + qs.ToString());
                        // for test only

                        string RWURL = System.Configuration.ConfigurationSettings.AppSettings["reportWriterURL"] + "?Data=" + mEncryptQueryString(VsQueryString + "&ChartID=" + FileID + "&ChartName="+OrgChartName);//IsAdmin=" + Convert.ToInt32( ((Navigation.BaseObject)Page.Session[ "navigation" ]).SecInfo.IsAdministrator ) +"&ContactID=" + ((Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.GetLoggedUserID().ToString() + "&VsApplicationID=2&repID=" + repID +"&TK=" + token ;
                        string frameScript = "<script language='javascript'> window.open( '" + RWURL + "') </script>";
                        Page.RegisterStartupScript("FrameScript", frameScript);
                    }
					//Response.Redirect("ContentPage.aspx?uc=Go/ctlFlowChartsDetails.ascx");
                }   */
                #endregion
                else if (TempControl.ID == "cbView")
                {

                    dsOrgnizationCharts1 = (TSN.ERP.SharedComponents.Data.dsOrgnizationCharts)ViewState["dsOrgnizationCharts1"];
                    Session["CurrentOgnizationChartIndex"] = dsOrgnizationCharts1.GEN_OrgnizationCharts[e.Item.ItemIndex].FileID;
                    ((Navigation.BaseObject)Session["navigation"]).UserControl = "Go/ctlFlowChartsDetails";


                    Response.Redirect("ContentPage.aspx?uc=Go/ctlFlowChartsDetails.ascx");// mglil call view page instead

                }
                else if (TempControl.ID == "imgDelete")
                {
                    // check access right
                    ArrayList arr = new ArrayList();
                    arr.Add(5119);
                    if (!((Navigation.BaseObject)Session["navigation"]).CheckUserAccessRule(arr))
                    {
                        Navigation.BaseObject.showMessage("You do not have access right to delete a chart ", this.Page);
                        return;
                    }

                    dsOrgnizationCharts1 = (TSN.ERP.SharedComponents.Data.dsOrgnizationCharts)ViewState["dsOrgnizationCharts1"];
                    //dsOrgnizationCharts1.Tables[0].Rows[e.Item.ItemIndex].Delete();
                    ERP.SharedComponents.Data.dsOrgnizationCharts.GEN_OrgnizationChartsRow row
                        = dsOrgnizationCharts1.GEN_OrgnizationCharts.FindByFileID(dsOrgnizationCharts1.GEN_OrgnizationCharts[e.Item.ItemIndex].FileID);
                    row.Delete();
                    ((Navigation.BaseObject)Session["navigation"]).OrgnizationChartsWSObject.ModifyChartsInfo(dsOrgnizationCharts1);



                    BindCharts();
                }
                else if (TempControl.ID == "imgEdit")
                {

                    #region new Code
                    dsOrgnizationCharts1 = (TSN.ERP.SharedComponents.Data.dsOrgnizationCharts)ViewState["dsOrgnizationCharts1"];
                    Session["CurrentOgnizationChartIndex"] = dsOrgnizationCharts1.GEN_OrgnizationCharts[e.Item.ItemIndex].FileID;
                    ((Navigation.BaseObject)Session["navigation"]).UserControl = "Go/ctlFlowChartsDetails";

                    int ChartID = (int)Session["CurrentOgnizationChartIndex"];
                    byte[] tempbuffer = ((Navigation.BaseObject)Session["navigation"]).OrgnizationChartsWSObject.LoadChartBody(ChartID);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(tempbuffer);

                    Session["EditChart"] = ms;
                    Session["FileID"] = Session["CurrentOgnizationChartIndex"];


                    //string frameScript = "<script language='javascript'> window.parent.frames(1).location='ContentPage.aspx?uc=Go/ctlFlowChartsDetails.ascx';</script>";
                    //Page.RegisterStartupScript("FrameScript", frameScript);
                    //Response.Redirect("ContentPage.aspx?uc=Go/ctlFlowChartsDetails.ascx");// mglil call view page instead
                    Response.Redirect("~/go/flowcharts/frmViewChart.aspx?chartname=&action=edit&chartid=");

                    #endregion
                    /*
                    // added by Sayed Moawad 15/2/2010
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    dsOrgnizationCharts1 = (TSN.ERP.SharedComponents.Data.dsOrgnizationCharts)ViewState["dsOrgnizationCharts1"];
                    int FileID = dsOrgnizationCharts1.GEN_OrgnizationCharts[e.Item.ItemIndex].FileID;
                    string ChartName = dsOrgnizationCharts1.GEN_OrgnizationCharts[e.Item.ItemIndex].OChartDesc;
                    byte[] imgBinary;
                    imgBinary = ((Navigation.BaseObject)Session["navigation"]).OrgnizationChartsWSObject.LoadChartBody(FileID);
                    Session["ChartID"] = FileID;
                    Session["ChartName"] = ChartName;
                    //Response.Redirect("../go/frmrwviewerChart.aspx");
                    byte[] rep = imgBinary;
                    Page.Response.AddHeader("Content-Disposition", "attachment;filename="+ChartName+".Jpg");
                    Page.Response.AddHeader("Content-Length", rep.Length.ToString());
                    Page.Response.ContentType = "application/octet-stream";
                    Page.Response.Buffer = true;

                    //Displaying a dialog taht will ask user to open file or even to download it locally on hard disk
                    Page.Response.BinaryWrite(rep);
                    //Flushing all data after downloading it
                    Page.Response.Flush();
                    Page.Response.Close();
                    Page.Response.End();
                    */
                    #region Old code for Edit 15/2/2010
                    /*
                    
                    // check access right
					ArrayList arr = new ArrayList();
					arr.Add( 5116 );
					if ( !((Navigation.BaseObject) Session[ "navigation" ]).CheckUserAccessRule( arr ) )
					{
						Navigation.BaseObject.showMessage( "You do not have access right to edit a chart " , this.Page ) ;
						return;
					}


					dsOrgnizationCharts1 = (TSN.ERP.SharedComponents.Data.dsOrgnizationCharts)ViewState["dsOrgnizationCharts1"];
					ERP.SharedComponents.Data.dsOrgnizationCharts.GEN_OrgnizationChartsRow row 
						=  dsOrgnizationCharts1.GEN_OrgnizationCharts.FindByFileID(dsOrgnizationCharts1.GEN_OrgnizationCharts[e.Item.ItemIndex].FileID);
					string serObject = row.OChartObject;
					// format serialized object, remode new line and return symbols
					for(int i = 0; i<serObject.Length;i++)
						if (serObject[i] != 13 && serObject[i] != 10)
							
						{
							// replace " with '
							if (serObject[i] == 34)
								s = s + "'";
							else	
								s = s + serObject[i];
						}
					TextReader tr = new StringReader(s);
					flowcharts.Chart ch = new flowcharts.Chart( );
					if (row.OChartType ==1)
						x= new XmlSerializer(typeof(flowcharts.DeptHierarchyChart));
					else if (row.OChartType ==2)
						x= new XmlSerializer(typeof(flowcharts.TitlesChart));
					else if (row.OChartType ==3)
						x= new XmlSerializer(typeof(flowcharts.TeamsChart));
					else
						x= new XmlSerializer(typeof(flowcharts.ProjectsChart));

					ch = (flowcharts.Chart)x.Deserialize(tr);
					Session["chartObject"] = ch;
					// save the file id in the session
					Session["FileID"] = row.FileID;
					Response.Redirect("../go/flowcharts/frmCreateNewChart.aspx?action=edit&chartid="+row.FileID);
                     */
                    #endregion
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message + " " + s);
            }
        }

        private void BindCharts()
        {
            dsOrgnizationCharts1.Clear();
            dsOrgnizationCharts1.Merge(((Navigation.BaseObject)Session["navigation"]).OrgnizationChartsWSObject.ListChartsInfo());
            //Filter Charts List
            MasterMethods master = new MasterMethods();
            DataView dvCharts = dsOrgnizationCharts1.Tables[0].DefaultView;
            dvCharts.Sort = "OChartDesc";
            dsOrgnizationCharts1.Tables.Clear();
            dsOrgnizationCharts1.Tables.Add(master.CreateTableFromView(dvCharts));
            dsOrgnizationCharts1.AcceptChanges();
            //////////////////////
            dgFlowCharts.DataBind();
            ViewState["dsOrgnizationCharts1"] = dsOrgnizationCharts1;
        }
        private string mEncryptQueryString(string VsOriginalData)
        {

            // Create the queryString object

            SecureQueryString qs = new SecureQueryString();

            // Add name/value pairs.

            qs["YourName"] = VsOriginalData;

            // If the user wishes an expiration, set the expire time

            qs.ExpireTime = DateTime.Now.AddHours(5);
            return qs.ToString();

            // Redirect to the Destination page.   We simply call the ToString() method of 

            // SecureQuerySting to pass the encrypted data.

            //Response.Redirect("http://localhost:3191/ReportWriter/default.aspx?data=" + qs.ToString());
        }

        private void dgFlowCharts_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[3].Visible = false;// to hide edit

                ArrayList arr = new ArrayList();
                arr.Add(5116);
                if (!((Navigation.BaseObject)Session["navigation"]).CheckUserAccessRule(arr))
                {
                    e.Item.Cells[3].Visible = false;
                }

                ArrayList arr2 = new ArrayList();
                arr2.Add(5119);
                if (!((Navigation.BaseObject)Session["navigation"]).CheckUserAccessRule(arr2))
                {
                    e.Item.Cells[4].Visible = false;
                }
            }
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Cells[3].Visible = false;// to hide edit
                ArrayList arr = new ArrayList();
                arr.Add(5116);
                if (!((Navigation.BaseObject)Session["navigation"]).CheckUserAccessRule(arr))
                {
                    ((ImageButton)e.Item.Cells[3].FindControl("imgEdit")).Visible = false;
                    e.Item.Cells[3].Visible = false;
                }

                ArrayList arr2 = new ArrayList();
                arr2.Add(5119);
                if (!((Navigation.BaseObject)Session["navigation"]).CheckUserAccessRule(arr2))
                {
                    ((ImageButton)e.Item.Cells[4].FindControl("imgDelete")).Visible = false;
                    e.Item.Cells[4].Visible = false;
                }
                ((ImageButton)e.Item.Cells[4].FindControl("imgDelete")).Attributes.Add("onclick", "return confirm('Are you sure you want to delete this chart?')");
            }
        }

    }
}
