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
using MindFusion.FlowChartX.LayoutSystem;
using MindFusion.FlowChartX;
using System.Drawing.Imaging;

namespace TSN.ERP.WebGUI.Go.flowcharts
{
    /// <summary>
    /// Summary description for ImageGen.
    /// </summary>
    public partial class ImageGen : System.Web.UI.Page
    {
        //--------------------------------------------------------------------------
        #region page load
        protected void Page_Load(object sender, System.EventArgs e)
        {
            try
            {
                FlowChart fc = new FlowChart();
                Response.ContentType = "image/jpeg";
                //			HttpContext.Current.Response.ContentType = "image/gif"; 

                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                // generate jpeg image ...
                // View mode, chart is already saved in database
                if (Session["CurrentOgnizationChartIndex"] != null)
                {
                    int ChartID = (int)Session["CurrentOgnizationChartIndex"];
                    byte[] tempbuffer = ((Navigation.BaseObject)Session["navigation"]).OrgnizationChartsWSObject.LoadChartBody(ChartID);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(tempbuffer);

                    MindFusion.Diagramming.WebForms.FlowChart chartCtrl = new MindFusion.Diagramming.WebForms.FlowChart();
                    chartCtrl.LoadFromStream(ms);

                    Bitmap bmp = chartCtrl.CreateImage();
                    System.IO.MemoryStream stream2 = new System.IO.MemoryStream();
                    bmp.Save(stream2, ImageFormat.Jpeg);

                    //***********/
                    byte[] imgBinary = stream2.ToArray();


                    //imgBinary = ((Navigation.BaseObject)Session["navigation"]).OrgnizationChartsWSObject.LoadChartBody(ChartID);
                    Response.OutputStream.Write(imgBinary, 0, imgBinary.Length);
                    Response.OutputStream.Close();
                    Session["CurrentOgnizationChartIndex"] = null;

                    return;
                    //******************//

                    /// the two lines commented at 11-2-2010
                    //fc.LoadFromStream(ms);
                    //Session["CurrentOgnizationChartIndex"] = null;
                }
                else // new chart mode, load chart from session
                    fc = (FlowChart)this.Session["fcx"];
                if (fc != null)
                {


                    int ChartID = (int)Session["FileID"];
                    byte[] tempbuffer = ((Navigation.BaseObject)Session["navigation"]).OrgnizationChartsWSObject.LoadChartBody(ChartID);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(tempbuffer);
                    // 11-2-2010

                    //***********/
                    MindFusion.Diagramming.WebForms.FlowChart chartCtrl = new MindFusion.Diagramming.WebForms.FlowChart();
                    chartCtrl.LoadFromStream(ms);

                    Bitmap bmp = chartCtrl.CreateImage();
                    System.IO.MemoryStream stream2 = new System.IO.MemoryStream();
                    bmp.Save(stream2, ImageFormat.Jpeg);

                    //***********/
                    byte[] imgBinary = stream2.ToArray();


                    //imgBinary = ((Navigation.BaseObject)Session["navigation"]).OrgnizationChartsWSObject.LoadChartBody(ChartID);
                    Response.OutputStream.Write(imgBinary, 0, imgBinary.Length);
                    Response.OutputStream.Close();
                    
                    /*
                    Bitmap bmp = fc.CreateBmpFromChart();                    
                    EncoderParameters eps = new EncoderParameters(1);
                    eps.Param[0] = new EncoderParameter(Encoder.Quality, (long)90);
                    ImageCodecInfo codec = GetEncoderInfo(Response.ContentType);
                    bmp.Save(Response.OutputStream, codec, eps);
                    bmp.Dispose();
                     */
                }

                Response.OutputStream.Close();
            }
            catch (Exception ex)
            {
                Response.Write("The format of this chart is not supported, please remove this chart then recreate it.<br>" + ex.Message);
            }
        }
        #endregion
        //--------------------------------------------------------------------------
        #region GetEncoderInfo
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
        #endregion
        //--------------------------------------------------------------------------
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
    }
}
