using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Office.DAL;
using Office.BLL;
using System.Text;

public partial class AttachFile3 : Office.BLL.MasterClass
{
    int AccountID;
    int ContactID;
    int BranchID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblStatus.Text = "";
            ViewState["EnterBy"] = ((ASIIdentity)User.Identity).UserID.ToString();
            ViewState["AccountID"] = 0;
            ViewState["MasterOrCredit"] = 0;
            ViewState["DueDilID"] = 0;

            //if (Request.QueryString["AccountID"] != null)
            //{

            //    ViewState["AccountID"] = Request.QueryString["AccountID"];

            //}
            if (Request.QueryString["MasterOrCredit"] != null)
            {
                ViewState["MasterOrCredit"] = Request.QueryString["MasterOrCredit"];

            }
            if (Request.QueryString["DueDil_ID"] != null)
            {
                ViewState["DueDilID"] = Request.QueryString["DueDil_ID"];

            }

        }
    }
    protected void AddAttachment_Click(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        string FileName = FileUpload1.FileName;
        Office.BLL.AttachmentsBLL attachFile = new Office.BLL.AttachmentsBLL();
        bool vbAdd;
        if(ViewState["MasterOrCredit"].ToString() == "credit")
            vbAdd = attachFile.AddCreditFile(Convert.ToInt32(ViewState["DueDilID"]),FileName, FileUpload1.PostedFile.ContentLength.ToString(), FileUpload1.FileBytes, "processing", Int32.Parse(ViewState["EnterBy"].ToString()));
        else
            vbAdd = attachFile.AddMasterFile(Convert.ToInt32(ViewState["DueDilID"]),FileName, FileUpload1.PostedFile.ContentLength.ToString(), FileUpload1.FileBytes, "recieved", Int32.Parse(ViewState["EnterBy"].ToString()));
        //this.txtDescription.Text = "";
        lblStatus.Text = FileName + " uploaded successfully";
        //FileUpload1 = null;
        //  AsyncFileUpload1.PostedFile.InputStream.Flush();//.FileName = "";


        string frameScript = "<script language='javascript'>clearContents();</script>";
        //string frameScript = "<script language='javascript'>clearContents();document.forms[0].AsyncFileUpload1.value = 'none';var who = document.getElementsByName(AsyncFileUpload1)[0]; who.value = ''; var who2 = who.cloneNode(false); who2.onchange = who.onchange; who.parentNode.replaceChild(who2, who);</script>";
        Type cstype = this.GetType();
        ClientScript.RegisterStartupScript(cstype, "FrameScript", frameScript);
        //Response.Redirect("AttachFile.aspx");
    }

}