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

public partial class AttachFile : Office.BLL.MasterClass
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
            ViewState["ContactID"] = 0;
            ViewState["BranchID"] = 0;

            if (Request.QueryString["AccountID"] != null)
            {

                AccountID = Int32.Parse(Request.QueryString["AccountID"]);
                ViewState["AccountID"] = AccountID;

            }
            if (Request.QueryString["ContactID"] != null)
            {
                ContactID = Int32.Parse(Request.QueryString["ContactID"]);
                ViewState["ContactID"] = ContactID;

            }
            if (Request.QueryString["BranchID"] != null)
            {
                BranchID = Int32.Parse(Request.QueryString["BranchID"]);
                ViewState["BranchID"] = BranchID;

            }

        }
    }
    protected void AddAttachment_Click(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        string FileName = FileUpload1.FileName;
        Office.BLL.AttachmentsBLL attachFile = new Office.BLL.AttachmentsBLL();
        bool vbAdd = attachFile.AddAttachments(0, FileName, FileUpload1.PostedFile.ContentLength.ToString(), FileUpload1.FileBytes, txtDescription.Text, Int32.Parse(ViewState["AccountID"].ToString()), Int32.Parse(ViewState["ContactID"].ToString()), Int32.Parse(ViewState["BranchID"].ToString()), Int32.Parse(ViewState["EnterBy"].ToString()));
        this.txtDescription.Text = "";
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