using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;

namespace TSN.ERP.WebGUI.Go
{
	/// <summary>
	/// Summary description for frmEmpImg.
	/// </summary>
	public partial class frmEmpImg : System.Web.UI.Page
	{
		byte[] imgBinary;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				Response.ContentType = "image/jpeg";
				Response.Cache.SetCacheability(HttpCacheability.NoCache);
				string fileID = Session["FileID"].ToString();
				if (fileID != "")
				{
					/* before 17-2-2010*/
                    //imgBinary =  ((Navigation.BaseObject) Session[ "navigation" ]).GeneralWSObject.LoadFileBody(int.Parse(fileID));	
                    //Response.OutputStream.Write(imgBinary,0,imgBinary.Length);	
                    //Response.OutputStream.Close();
                     ////
                    


                    /* added by Sayed 17-2-2010 */
                    imgBinary = ((Navigation.BaseObject)Session["navigation"]).GeneralWSObject.LoadFileBody(int.Parse(fileID));	
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imgBinary);
                    System.Drawing.Bitmap bmp = ResizeImage(ms, 100, 134);
                    //Bitmap bmp = fc.CreateBmpFromChart();

                    System.IO.MemoryStream stream2 = new System.IO.MemoryStream();

                    //// Save image to stream.
                    bmp.Save(stream2, ImageFormat.Jpeg);

                    imgBinary =stream2.ToArray();
                    Response.OutputStream.Write(imgBinary, 0, imgBinary.Length);
                    Response.OutputStream.Close();

				}
			}
			catch(Exception ex)
			{
				Response.Write(ex.Message);
			}
		}

        public System.Drawing.Bitmap ResizeImage(System.IO.Stream streamImage, int maxWidth, int maxHeight)
        {
            System.Drawing.Bitmap originalImage = new Bitmap(streamImage);
            int newWidth = originalImage.Width;
            int newHeight = originalImage.Height;
            double aspectRatio = Convert.ToDouble(originalImage.Width) / Convert.ToDouble(originalImage.Height);


            if (aspectRatio <= 1 && originalImage.Width > maxWidth)
            {
                newHeight = maxHeight;
                newWidth = Convert.ToInt32(Math.Round(newHeight * aspectRatio));
            }
            else
                if (aspectRatio > 1 && originalImage.Height > maxHeight)
                {
                    newWidth = maxWidth;
                    newHeight = Convert.ToInt32(Math.Round(newWidth / aspectRatio));

                }

            System.Drawing.Bitmap newImage = new Bitmap(originalImage, newWidth, newHeight);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(newImage);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            g.DrawImage(originalImage, 0, 0, newImage.Width, newImage.Height);
            originalImage.Dispose();

            return newImage;
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

		}
		#endregion
	}
}
