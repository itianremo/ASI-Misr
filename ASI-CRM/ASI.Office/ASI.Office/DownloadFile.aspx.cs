using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DownloadFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int AttachmentID = int.Parse(Request.QueryString["AttachID"].ToString());
           
           mDownloadFile(AttachmentID);
            //BindGridView();

        }

    }
    protected void imgbtnDownload_Click(object sender, ImageClickEventArgs e)
    {
        GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent;
        int AttachmentID = int.Parse(row.Cells[0].Text);
        mDownloadFile(AttachmentID);

    }
    public void BindGridView()
    {

        if (Session["CurrentPage"] != null)
        {
            if (Session["CurrentAttachments"] != null)
            {
                gvAttachments.DataSource = odsAttachments;
                gvAttachments.DataBind();
                gvAttachments.SelectedIndex = -1;
            }

        }

    }

    private void mDownloadFile(int AttachmentID)
    {
        Office.BLL.AttachmentsBLL attachFile2 = new Office.BLL.AttachmentsBLL();
        Office.DAL.Attachments attachFile = attachFile2.GetSearchFilter("FileName", "ASC");
        attachFile.AttachmentID = AttachmentID;
        Office.DAL.Attachments attachGetFile = attachFile2.SelectAttachment(attachFile);
        byte[] vbAttach = (byte[])attachGetFile.Attach;
        //Getting file name which enable us to know its extension type
        string fileName = attachGetFile.FileName;
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


        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";

        //Eanbling buffering data, this will make download operation start after buffering all data
        HttpContext.Current.Response.Buffer = true;

        //Displaying a dialog taht will ask user to open file or even to download it locally on hard disk
        HttpContext.Current.Response.BinaryWrite(vbAttach);

        //Flushing all data after downloading it
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.Close();
        HttpContext.Current.Response.End();
        RegisterStartupScript("load", "<script type=\"text/javascript\">\n" + "self.close();\n" + "<" + "/script>");
        // <strong class="highlight">close</strong> the <strong class="highlight">page</strong> if successful update
        RegisterStartupScript("<strong class='highlight'>load</strong>", "<script type=\"text/javascript\">\n" + "self.close();\n" + "<" + "/script>");
    }
    protected void gvAttachments_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
         
            // e.Row.Cells[0].Text

            e.Row.Cells[0].Visible = false;



        }
        else if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Visible = false;

        }
    }
}