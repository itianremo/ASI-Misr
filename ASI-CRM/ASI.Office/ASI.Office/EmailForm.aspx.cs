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
using System.Net.Mail;
using System.Configuration;
using Office.BLL;
using Office.DAL;
using System.IO;


public partial class frmNotes_test : SendEmailBLL
{

	private bool methodFired = false;
	//private static int contactID;
	#region page load
	protected void Page_Load(object sender, System.EventArgs e)
	{
		CheckUserSession();
		if (!IsPostBack)
		{
            txtFrom.Text = ((ASIIdentity)User.Identity).Email;
			imgSendMail.Attributes.Add("onmouseover", "this.src='Images/Send-o.jpg'");
			//imgCancelNote.Attributes.Add("onmouseover", "this.src='Images/Cancel2.jpg'");
			//////////////////////////////////////////////////////////////////////////
			imgSendMail.Attributes.Add("onmouseout", "this.src='Images/send-n.jpg'");
			//imgCancelNote.Attributes.Add("onmouseout", "this.src='Images/Cancel1.jpg'");
			//////////////////////////////////////////////////////////////////////////
			imgSendMail.Attributes.Add("onmousedown", "this.src='Images/Send-s.jpg'");
			// imgCancelNote.Attributes.Add("onmousedown", "this.src='Images/Cancel3.jpg'");

			FreeTextBoxControls.NetSpell netSpell = new FreeTextBoxControls.NetSpell();
			try   // added to avoid error of IE8 with freetextbox control
			{
				FreeTextBox1.Toolbars[3].Items.Add(netSpell);
			}
			catch { }

			/***************************************************************/
			try
			{

				//BindMailsGrid();

			}
			catch (Exception ex)
			{
				Response.Write(ex.Message);
			}

			lblNote.Visible = false;
			//string defaultTo = ConfigurationManager.AppSettings["DefaultTo"];
			//string defaultCC = ConfigurationManager.AppSettings["DefaultCC"];
			if (Request.QueryString["emailto"] != null)
				txtTo.Text = Request.QueryString["emailto"].ToString();
			//txtCC.Text = defaultCC;
			if (Request.QueryString["AccountID"] != null)
				ViewState["AccountID"] = Request.QueryString["AccountID"].ToString();

			if (Request.QueryString["DueDil_ID"] != null)
				ViewState["DueDil_ID"] = Request.QueryString["DueDil_ID"].ToString();

			if (Request.QueryString["MasterOrCredit"] != null)
			{
				if (Request.QueryString["MasterOrCredit"].ToString() == "master")
				{
					txtSubject.Text = "TSN Master Purchase Agreement";
					string DueDilID = ViewState["DueDil_ID"].ToString();
					GenerateASIAttachmentHTMLFile(DueDilID, "TSN/MasterPurchase.htm");
					ConvertToPDF(DueDilID);
					lnkASIAttachment.NavigateUrl = GetASIAttachmentURL(DueDilID);
					lnkASIAttachment.Text = "TSN Master Purchase Agreement";
				}
				else
				{
					txtSubject.Text = "TSN Credit Application";
					string DueDilID = ViewState["DueDil_ID"].ToString();
					GenerateASIAttachmentHTMLFile(DueDilID, "TSN/CreditApp.htm");
					ConvertToPDF(DueDilID);
					lnkASIAttachment.NavigateUrl = GetASIAttachmentURL(DueDilID);
					lnkASIAttachment.Text = "TSN Credit Application";
				}
			}
		}

	}

	private string GetASIAttachmentURL(string DueDilID)
	{
		return "./TSN/" + DueDilID + ".pdf";
	}

	private void GenerateASIAttachmentHTMLFile(string DueDilID, string CreditOrPurchase)
	{
		string line;

		ContactAccount CAcc = new ContactAccount();
		CAcc.AccountID = Convert.ToInt32(ViewState["AccountID"]);
		CAcc = CAcc.GetSingleContact();

		string[] TemplateVars = { "@AccountName", "@Phone", "@Fax", "@City", "@State", "@ZipCode", "@Email", "@WebSite" };
		string[] AttachmentVars = { CAcc.AccountName, CAcc.Phone, CAcc.Fax, CAcc.City, CAcc.State, CAcc.ZipCode, CAcc.Email, CAcc.WebSite };
		int i = 0;

		using (StreamReader reader = File.OpenText(Server.MapPath(CreditOrPurchase)))
		{
			//Commented By Sayed 15/5/2012
			// using (StreamWriter writer = File.AppendText(Server.MapPath(DueDilID)))
			// End 15/5/2012

			// Modified By Sayed 15/5/2012
			using (StreamWriter writer = File.AppendText(Server.MapPath("./TSN/" + DueDilID + ".htm")))
			//
			{

				while ((line = reader.ReadLine()) != null)
				{
					if (i < TemplateVars.Length)
					{
						if (line.Contains(TemplateVars[i]))
						{
							line = line.Replace(TemplateVars[i], AttachmentVars[i]);
							i++;
						}
					}

					writer.WriteLine(line);
				}
				writer.Flush();
				writer.Close();
			}
			reader.Close();
		}
	}

	private void ConvertToPDF(string DueDilID)
	{
		System.Diagnostics.Process process1 = new System.Diagnostics.Process();
		process1.StartInfo.WorkingDirectory = Request.MapPath("");
		process1.StartInfo.FileName = Request.MapPath("TSN/wkhtmltopdf.exe");
		process1.StartInfo.Arguments = " " + Server.MapPath("TSN/" + DueDilID + ".htm") + " " + Server.MapPath("TSN/" + DueDilID + ".pdf");
		process1.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
		process1.Start();
		process1.WaitForExit();
		process1.Close();
		File.Delete(Server.MapPath("TSN/" + DueDilID + ".htm"));
	}

	private void BindMailsGrid()
	{
		DataSet dsContactsAndEmails = new DataSet();
		Session["dsContactsAndEmails"] = dsContactsAndEmails;
		dgEmails.DataSource = dsContactsAndEmails;
		dgEmails.DataBind();
		// int ContactID =Convert.ToInt32(Session["LoginContactID"]);            

	}
	#endregion
	//------------------------------------------------------------
	//------------------------------------------------------------
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

		this.imgSendMail.Click += new System.Web.UI.ImageClickEventHandler(this.btnSendMail_Click);


	}
	#endregion



	//------------------------------------------------------------

	public void btnSendMail_Click(object sender, ImageClickEventArgs e)
	{
		if (methodFired)
			return;
		//if (ConfigurationManager.AppSettings["UseMailerModule"] == "No")
		{
			MailMessage msg = new MailMessage();
			msg.From = new MailAddress(txtFrom.Text);
			msg.To.Add(txtTo.Text);
			if (!String.IsNullOrEmpty(txtCC.Text))
			{
				if (cbSendMeAcopy.Checked) msg.CC.Add(txtCC.Text + ";" + txtFrom.Text);
				else msg.CC.Add(txtCC.Text);
			}

			else if (cbSendMeAcopy.Checked) msg.CC.Add(txtFrom.Text);
			if (!String.IsNullOrEmpty(txtBCC.Text))
				msg.Bcc.Add(txtBCC.Text);
			msg.Subject = txtSubject.Text;
			msg.IsBodyHtml = true;
			msg.Priority = MailPriority.High;
			msg.Body = "<html><body><table><tr><td>" + FreeTextBox1.Text + "</td></tr></table></body></html>";//"<H1>HHHHHHHHHH</H1>";//notes;	

			//Create Attachment 
			Attachment attachment;
			if (Request.QueryString["MasterOrCredit"] != null)
			{
				if (Request.QueryString["MasterOrCredit"].ToString() == "master")
				{
					attachment = new Attachment(Server.MapPath("files/master.doc"));
				}
				else
				{
					attachment = new Attachment(Server.MapPath("files/credit.doc"));
					//byte[] data = new byte[1024];
					//MemoryStream stream = new MemoryStream(data);
					// attachment = new Attachment(stream, "./files/credit.doc");
				}
				//Attach Attachment to Email 
				msg.Attachments.Add(attachment);
			}

			SmtpClient client = new SmtpClient();
			client.Host = ConfigurationManager.AppSettings["MailerSMTPServer"];
			client.SendCompleted += new SendCompletedEventHandler(client_SendCompleted);
			object userState = msg;
			try
			{
				client.SendAsync(msg, userState);
				Office.DAL.DueDiligence objDuDligance = new Office.DAL.DueDiligence();

				int AccountID = int.Parse(Session["SelectedAccountID"].ToString());
				objDuDligance.DueDil_ID = int.Parse(ViewState["DueDil_ID"].ToString());
				if (Request.QueryString["MasterOrCredit"].ToString() == "master")
				{
					objDuDligance.MasterPurchaseStatus = "sent";
				}
				else
				{
					objDuDligance.CreditCheckStatus = "sent";
				}
				objDuDligance.UpdateDueDiligence();

			}
			catch (Exception ex)
			{
				Response.Write("Error sending mail:" + ex.Message);
			}
		}

		this.ClientScript.RegisterClientScriptBlock(this.GetType(), "CloseMe", "<script>closeNotes();</script>");
		methodFired = true;


	}
	void client_SendCompleted(object sender, AsyncCompletedEventArgs e)
	{
		if (e.Error != null)
		{
			lblNote.Visible = true;
			lblNote.Text = "Error during sending mail:" + e.Error.Message;
			return;
		}
	}
	private void btnSendMail_Click_Old(object sender, System.EventArgs e)
	{
		WSMailer.MailerService mailService = new WSMailer.MailerService();
		string From = txtFrom.Text;
		string To = txtTo.Text;
		string CC = txtCC.Text;
		string BCC = txtBCC.Text;
		string Subject = txtSubject.Text;
		string Body = "<html><body><Table><tr><td>" + FreeTextBox1.Text + "</td></tr></table></body></html>";

		string mailingType = ConfigurationManager.AppSettings["MailingType"];
		try
		{
			bool Success = false;

			Success = mailService.SendHTMLMail(To, CC, BCC, From, "", Subject, Body, "");

			if (Success)
			{
				ClientScript.RegisterStartupScript(Page.GetType(), "CloseMe", "<script>var val = FTB_API['FreeTextBox1'].GetHtml();window.opener.setFreeTextBoxData(val);window.opener.saveNote();NotesClosed();</script>");
			}
			else
			{
				lblNote.Visible = true;
				lblNote.Text = "Error during sending mail, make sure you typed correct email addresses";
				return;
			}

		}
		catch (Exception ex)
		{
			lblNote.Visible = true;
			lblNote.Text = "Error during sending mail, make sure you typed correct email addresses";
			return;
		}


	}
	/************************************************************************/
	private void dgEmails_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
	{
		/* try
		 {
			  dgEmails.CurrentPageIndex = e.NewPageIndex;
			  DataSet dsContactsAndEmails = new DataSet();
			  dsContactsAndEmails = (DataSet)Session["dsContactsAndEmails"];
			  dgEmails.DataSource = dsContactsAndEmails;
			  dgEmails.DataBind();
		 }
		 catch (Exception ex)
		 {
			  Response.Write(ex.Message);
		 }
		 */
	}
	private void cbFind_Click(object sender, System.EventArgs e)
	{
		/* try
		 {
			  DataSet dsContactsAndEmails = (DataSet)Session["dsContactsAndEmails"];
			  DataSet dsContactsAndEmailsCopy = new DataSet();
			  DataRow[] drColl = dsContactsAndEmails.Tables[0].Select("ContactEmail LIKE  '%" + tbFilter.Text + "%'");
			  DataTable dt = dsContactsAndEmails.Tables[0].Clone();
			  dsContactsAndEmailsCopy.Tables.Add(dt);
			  foreach (DataRow dr in drColl)
			  {
					dsContactsAndEmailsCopy.Tables[0].ImportRow(dr);
			  }

			  if (dsContactsAndEmailsCopy.Tables[0].Rows.Count > 0)
			  {
					Label1.Visible = false;
					dgEmails.Visible = true;
					dgEmails.DataSource = dsContactsAndEmailsCopy;
					dgEmails.DataBind();
			  }
			  else
			  {
					Label1.Visible = true;
					dgEmails.Visible = false;


			  }

		 }
		 catch (Exception ex)
		 {
			  Response.Write(ex.Message);
		 }
		 * */


	}

	private void lbShowAll_Click(object sender, System.EventArgs e)
	{
		/*
		DataSet dsContactsAndEmails = (DataSet)Session["dsContactsAndEmails"];
		dgEmails.DataSource = dsContactsAndEmails;
		dgEmails.DataBind();
		Label1.Visible = false;
		if (dgEmails.Items.Count > 0)
		{
			 dgEmails.Visible = true;
		}
		else
		{
			 dgEmails.Visible = false;
		}
		 */
	}
	private void cbAdd_Click(object sender, System.EventArgs e)
	{
		/*string strEmail = String.Empty;
		int idx = 0;
		foreach (DataGridItem dgiTemp in dgEmails.Items)
		{
			 object temp = dgiTemp.FindControl("cbxSelect");
			 if (temp == null) continue;
			 CheckBox cbxSelector = (CheckBox)temp;
			 if (!cbxSelector.Checked) continue;
			 idx++;
			 strEmail += dgiTemp.Cells[1].Text.Trim();
			 if (idx > 0)
				  strEmail += ";";
		}
		if (idx == 0)
		{
			 this.RegisterStartupScript("fdss", "<script>alert('You must select at least one email address to add it');</script>");
		}
		if (strEmail.EndsWith(";"))
			 strEmail = strEmail.Remove(strEmail.Length - 1, 1);
		//string mailButton = Request.QueryString.Get("mailButton");
		string mailButton = Session["mailButton"].ToString();
		this.RegisterStartupScript("fds", "<script>saveEmails2('" + strEmail + "','" + mailButton + "');</script>");
		 * */

	}

	#region Show All EmailAdresses

	public void getAllEMailAdrees()
	{
		/*DataSet dsContactsAndEmails = (DataSet)Session["dsContactsAndEmails"];
		dgEmails.DataSource = dsContactsAndEmails;
		dgEmails.DataBind();
		Label1.Visible = false;
		if (dgEmails.Items.Count > 0)
		{
			 dgEmails.Visible = true;
		}
		else
		{
			 dgEmails.Visible = false;
		}
		 */
	}
	#endregion
	#region findEmailAdresses

	public void findEMailAdrees(string strcharacters)
	{
		/*
		try
		{
			 DataSet dsContactsAndEmails = (DataSet)Session["dsContactsAndEmails"];
			 DataSet dsContactsAndEmailsCopy = new DataSet();
			 DataRow[] drColl = dsContactsAndEmails.Tables[0].Select("ContactEmail LIKE  '%" + strcharacters  + "%'");
			 DataTable dt = dsContactsAndEmails.Tables[0].Clone();
			 dsContactsAndEmailsCopy.Tables.Add(dt);
			 foreach (DataRow dr in drColl)
			 {
				  dsContactsAndEmailsCopy.Tables[0].ImportRow(dr);
			 }

			 if (dsContactsAndEmailsCopy.Tables[0].Rows.Count > 0)
			 {
				  Label1.Visible = false;
				  dgEmails.Visible = true;
				  dgEmails.DataSource = dsContactsAndEmailsCopy;
				  dgEmails.DataBind();
			 }
			 else
			 {
				  Label1.Visible = true;
				  dgEmails.Visible = false;


			 }

		}
		catch (Exception ex)
		{
			 Response.Write(ex.Message);
		}
		  */
	}
	#endregion
	#region GetEmailAdresses

	public void getEMailAdrees(string mailButton)
	{
		/*
						try
						{
							 //divPanel.Visible=true;
							 DataSet dsContactsAndEmails = new DataSet();
							 string mailingType = System.Configuration.ConfigurationSettings.AppSettings["MailingType"];
							 if (mailingType == "0")//Internal
							 {
								  Navigation.BaseObject.SafeMerge(dsContactsAndEmails, ((Navigation.BaseObject)Session["navigation"]).ContactWsObject.ListCotactsAndEmails(0));
							 }
							 else if (mailingType == "1")//External
							 {
								  Navigation.BaseObject.SafeMerge(dsContactsAndEmails, ((Navigation.BaseObject)Session["navigation"]).ContactWsObject.ListCotactsAndEmails(1));
							 }
							 else if (mailingType == "2")//Private
							 {
								  Navigation.BaseObject.SafeMerge(dsContactsAndEmails, ((Navigation.BaseObject)Session["navigation"]).ContactWsObject.ListCotactsAndEmails(2));
							 }
							 else if (mailingType == "-1")//Get All mails
							 {
								  Navigation.BaseObject.SafeMerge(dsContactsAndEmails, ((Navigation.BaseObject)Session["navigation"]).ContactWsObject.ListCotactsAndEmails(-1));
							 }
							 Session["dsContactsAndEmails"] = dsContactsAndEmails;
							 if (dsContactsAndEmails.Tables[0].Rows.Count > 0)
								  //divPanel.Visible=true;
								  dgEmails.DataSource = dsContactsAndEmails;
							 dgEmails.DataBind();
						}
						catch (Exception ex)
						{
							 Response.Write(ex.Message);
						}

						Session["mailButton"] = mailButton;
						//string mailButton = Request.QueryString.Get("mailButton");
						string Script = "mailButton='" + mailButton + "';";
						this.RegisterStartupScript("fff", "<script>" + Script + "</script>");

		*/

	}
	#endregion
	#region CloseEmailWidow
	/// <summary>
	/// 
	/// </summary>
	/// <returns></returns>
	// [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
	public void closeEmailsWindow(string strValue)
	{
		try
		{
			//divPanel.Visible=false;
			string test = "";
		}
		catch (Exception ex)
		{
			Response.Write(ex.Message);
		}

	}
	#endregion
	/**************************************************************************/
	protected void rblSendingMethod_SelectedIndexChanged(object sender, EventArgs e)
	{
		BindMailsGrid();
	}
}
//}
