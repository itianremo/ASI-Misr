using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Preview : System.Web.UI.Page
{
	string fileName;
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			if (Request.QueryString["DueDil_ID"] != null)
			{
				if (Request.QueryString["MasterOrCredit"] != null)
				{
					mDownloadFile(int.Parse(Request.QueryString["DueDil_ID"].ToString()), Request.QueryString["MasterOrCredit"].ToString());

				}

			}

		}

	}



	private void mDownloadFile(int DueDil_ID, string Action)
	{

		Office.DAL.DueDiligence objDuDliganceGet = new Office.DAL.DueDiligence();


		objDuDliganceGet.DueDil_ID = DueDil_ID;
		Office.DAL.DueDiligence objDuDligance = objDuDliganceGet.GetSingleDueDiligence();
		byte[] vbAttach;
		fileName = "";

		if (Action == "master")
		{
			if (objDuDligance.MasterPurchaseFile != null)
			{
				vbAttach = (byte[])objDuDligance.MasterPurchaseFile;
				fileName = objDuDligance.MasterPurchaseFileName;
			}
			else vbAttach = null;
		}
		else
		{
			if (objDuDligance.CreditCheckFile != null)
			{
				vbAttach = (byte[])objDuDligance.CreditCheckFile;
				fileName = objDuDligance.CreditCheckFileName;
			}
			else vbAttach = null;
		}
		if (vbAttach != null)
		{

			//Getting file name which enable us to know its extension type

			fileName = fileName.Replace(' ', '_');

			//Determinig file extenstion type which will be evaluated during dowloading it
			string fileExtension = System.IO.Path.GetExtension(fileName);
			Response.Clear();

			HttpContext.Current.Response.AddHeader("Content-Length", vbAttach.Length.ToString());
			HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);

			switch (fileExtension)
			{
				case ".doc":
					{
						HttpContext.Current.Response.ContentType = "application/msword";
						break;
					}
				case ".docx":
					{
						HttpContext.Current.Response.ContentType = "application/msword";
						break;
					}
				case ".xls":
					{

						HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
						break;
					}
				case ".rtf":
					{

						HttpContext.Current.Response.ContentType = "text/richtext";
						break;
					}
				case ".zip":
					{

						HttpContext.Current.Response.ContentType = "application/x-zip-compressed";
						break;
					}
				case ".html":
					{

						HttpContext.Current.Response.ContentType = "Text/HTML";
						break;
					}
				case ".mp3":
					{

						HttpContext.Current.Response.ContentType = "audio/mpeg3";
						break;
					}
				case ".ppt":
					{

						HttpContext.Current.Response.ContentType = "application/vnd.ms-powerpoint";
						break;
					}
				case ".txt":
				case ".ini":
				case ".log":
					{

						HttpContext.Current.Response.ContentType = "text/plain";
						break;
					}
				case ".tiff":
					{

						HttpContext.Current.Response.ContentType = "image/tiff";
						break;
					}
				case ".gif":
					{

						HttpContext.Current.Response.ContentType = "image/gif";
						break;
					}
				case ".jpeg":
					{

						HttpContext.Current.Response.ContentType = "image/jpeg";
						break;
					}
				case ".bmp":
					{

						HttpContext.Current.Response.ContentType = "image/bmp";
						break;
					}
				case ".avi":
					{

						HttpContext.Current.Response.ContentType = "video/avi";
						break;
					}
				case ".mpg":
				case "mpeg":
					{

						HttpContext.Current.Response.ContentType = "video/mpeg";
						break;
					}
				case ".wav":
					{

						HttpContext.Current.Response.ContentType = "audio/wav";
						break;
					}
				case ".asf":
					{

						HttpContext.Current.Response.ContentType = "video/x-ms-asf";
						break;
					}
				case ".ico":
					{

						HttpContext.Current.Response.ContentType = "image/x-icon";
						break;
					}
				case ".exe":
				case ".bin":
				case ".bat":
					{
						HttpContext.Current.Response.AddHeader("Content-Length", vbAttach.Length.ToString());
						HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
						break;
					}
				default:
					{


						HttpContext.Current.Response.ContentType = "application/octet-stream";
						break;
					}
			}


			// HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";

			//Eanbling buffering data, this will make download operation start after buffering all data
			HttpContext.Current.Response.Buffer = true;

			//Displaying a dialog taht will ask user to open file or even to download it locally on hard disk
			HttpContext.Current.Response.BinaryWrite(vbAttach);

			//Flushing all data after downloading it
			HttpContext.Current.Response.Flush();
			HttpContext.Current.Response.Close();
			HttpContext.Current.Response.End();
		}
		ClientScript.RegisterStartupScript(Page.GetType(), "load", "<script type=\"text/javascript\">\n" + "self.close();\n" + "<" + "/script>");
		// <strong class="highlight">close</strong> the <strong class="highlight">page</strong> if successful update
		ClientScript.RegisterStartupScript(Page.GetType(), "<strong class='highlight'>load</strong>", "<script type=\"text/javascript\">\n" + "self.close();\n" + "<" + "/script>");
	}

}