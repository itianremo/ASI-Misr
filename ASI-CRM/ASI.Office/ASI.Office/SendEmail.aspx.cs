using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Configuration;
using Office.BLL;
using Office.DAL;
using System.Data;

public partial class SendEmail : SendEmailBLL
{
	protected void Page_Load(object sender, EventArgs e)
	{
		CheckUserSession();
		if (!IsPostBack)
		{
			btnSend1.Attributes.Add("onmouseover", "this.src='Images/Send-o.jpg'");
			btnCancel1.Attributes.Add("onmouseover", "this.src='Images/Cancel2.jpg'");
			/////////////////////////////////////////////////////////////////////////////////////
			btnSend1.Attributes.Add("onmouseout", "this.src='Images/send-n.jpg'");
			btnCancel1.Attributes.Add("onmouseout", "this.src='Images/Cancel1.jpg'");
			/////////////////////////////////////////////////////////////////////////////////////
			btnSend1.Attributes.Add("onmousedown", "this.src='Images/Send-s.jpg'");
			btnCancel1.Attributes.Add("onmousedown", "this.src='Images/Cancel3.jpg'");
			//lblVersionInfo.Text = GetVersionInfo();
			BindTemplates();

            txtFrom.Text = ((ASIIdentity)User.Identity).Email;

			if (Session["SendEmailAccs"] != null)
			{
				int TosCount = ((List<string>)Session["SendEmailAccs"]).Count;
				if (TosCount > 1)
					txtTo.Text = "Group of Accounts";
				else if (TosCount == 1)
					txtTo.Text = "Account";
				else
					txtTo.Text = "---";

				List<string> EmailCCList = GetEmailCCList();
				if (EmailCCList.Count == 1)
					txtCC.Text += EmailCCList[0];
				else
				{
					foreach (string item in EmailCCList)
					{
						txtCC.Text += item + ",";
					}
				}
			}
			else if (Session["SendEmailCons"] != null)
			{
				int TosCount = ((List<string>)Session["SendEmailCons"]).Count;
				if (TosCount > 1)
					txtTo.Text = "Group of Contacts";
				else if (TosCount == 1)
					txtTo.Text = "Contact";
				else
					txtTo.Text = "---";

				List<string> EmailCCList = GetEmailCCList();
				if (EmailCCList.Count == 1)
					txtCC.Text += EmailCCList[0];
				else
				{
					foreach (string item in EmailCCList)
					{
						txtCC.Text += item + ",";
					}
				}
			}

		}
		string CurrentPage = "SendEmail";
		ucTransToolBar.CurrentPage = CurrentPage;
		AssignReportParameters();
		//////
		//ucUserTabs.CurrentPage = CurrentPage;
		////////
		//imgbtnSignOut.Attributes.Add("onmouseover", "this.src='Images/CloseBut_pressed.jpg'");
		//imgbtnSignOut.Attributes.Add("onmouseout", "this.src='Images/CloseBut_normal.jpg'");
		//
	}
	private void BindTemplates()
	{
		ddlTemplate.DataSource = SelectEmailTemplatesNames();
		ddlTemplate.DataTextField = "TemplateName";
		ddlTemplate.DataValueField = "TemplateID";
		ddlTemplate.DataBind();
		if (ddlTemplate.Items.Count > 0)
		{
			//foreach(List

			Office.DAL.EmailTemplate objTemp = new Office.DAL.EmailTemplate();
			Office.DAL.EmailTemplate ETemplate = objTemp.GetDefaultTemplate();
			if (ETemplate.TemplateID != null)
			{
				ddlTemplate.SelectedValue = ETemplate.TemplateID.ToString();
				txtBody.Text = Server.HtmlDecode(ETemplate.TemplateContent);
				txtSubject.Text = ETemplate.TemplateEmailSubject;

			}
			else
			{
				ddlTemplate.SelectedIndex = 0;
				Office.DAL.EmailTemplate ETemplate2 = SelectEmailTemplate(Convert.ToInt32(ddlTemplate.SelectedValue));
				txtBody.Text = Server.HtmlDecode(ETemplate2.TemplateContent);
				txtSubject.Text = ETemplate2.TemplateEmailSubject;
			}

		}
	}
	protected void ddlTemplate_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (ddlTemplate.SelectedValue != null)
		{
			Office.DAL.EmailTemplate ETemplate = SelectEmailTemplate(Convert.ToInt32(ddlTemplate.SelectedValue));
			// commented by sayed moawad 21/8/2011
			// txtBody.Text = ETemplate.TemplateContent;
			// added by sayed 21/8/2011
			txtBody.Text = Server.HtmlDecode(ETemplate.TemplateContent);
			// end added
			txtSubject.Text = ETemplate.TemplateEmailSubject;
		}
	}
	private void AssignReportParameters()
	{
		((ImageButton)ucTransToolBar.FindControl("btnPrint")).Attributes.Add("onclick", "openReports('','','" + "All"/*ViewState["Tag"].ToString()*/ + "','','" + ""/*((Filter)Session["CallFilterField"]).IncrementalSearch*/ + "','" + ""/*ViewState["LocationFilter"].ToString()*/ + "','" + ""/*ViewState["SpecificLocation"].ToString()*/ + "');");
	}

	protected void btnSend1_Click(object sender, EventArgs e)
	{
		SendEmailForm2();
	}
	protected void btnCancel1_Click(object sender, EventArgs e)
	{
		CancelEmailForm();
	}
	protected void btnSend2_Click(object sender, EventArgs e)
	{
		SendEmailForm2();
	}
	protected void btnCancel2_Click(object sender, EventArgs e)
	{
		CancelEmailForm();
	}

	protected void SendEmailForm2()
	{
		bool IsContacts;
		if (ValidateData())
		{
			IsContacts = false;
			DataTable dtContactsEmail = new DataTable();
			if (Session["dtContactsEmail"] != null)
			{
				dtContactsEmail = (DataTable)Session["dtContactsEmail"];
				IsContacts = true;
			}
			else if (Session["dtAccountsEmail"] != null)
			{
				dtContactsEmail = (DataTable)Session["dtAccountsEmail"];
				IsContacts = false;
			}

			MailMessage message = new MailMessage();
			message.IsBodyHtml = true;
			message.From = new MailAddress(txtFrom.Text);
			if (txtCC.Text.Contains(","))
			{
				string[] Emails = txtCC.Text.Split(',');
				foreach (string Email in Emails)
				{
					message.CC.Add(Email);
				}
			}
			else
			{
				if (txtCC.Text.Length > 0)
					message.CC.Add(txtCC.Text);
			}


			foreach (DataRow dr in dtContactsEmail.Rows)
			{
				message.To.Add(dr["email"].ToString());
				string msgBody = "";
				msgBody = txtBody.Text;
				if (IsContacts)
				{
					msgBody = msgBody.Replace("<fname>", dr["fname"].ToString());
					msgBody = msgBody.Replace("<lname>", dr["lname"].ToString());
				}
				else
					msgBody = msgBody.Replace("<cname>", dr["cname"].ToString());

				message.Body = msgBody;

				//if (txtTo.Text.Length > 0)
				//    message.To.Add(txtTo.Text);
				//if (System.Diagnostics.Debugger.IsAttached)
				//{
				//    System.Diagnostics.Debugger.Break();
				//    message.To.Clear();

				//}


				SmtpClient emailClient = new SmtpClient(ConfigurationManager.AppSettings["MailerSMTPServer"]);
				try
				{
					emailClient.Send(message);

					AddSentEmailRecord(dr["email"].ToString());



				}
				catch (Exception e)
				{
					lblMsg.Text = e.Message.ToString(); ;
				}
			}
			if (dtContactsEmail.Rows.Count > 0)
				lblMsg.Text = "Email has been sent successfully to " + dtContactsEmail.Rows.Count.ToString() + " recipient(s).";
			else lblMsg.Text = "Email has not been sent";
		}
		// else lblMsg.Text = "Invalid email";
	}
	protected void SendEmailForm()
	{
		if (ValidateData())
		{
			MailMessage message = new MailMessage();//, txtTo.Text, txtSubject.Text, txtBody.Text);
			message.IsBodyHtml = true;
			message.From = new MailAddress(txtFrom.Text);
			List<string> EmailToList = new List<string>();

			if (Session["SendEmailAccs"] != null)
			{
				EmailToList = (List<string>)Session["SendEmailAccs"];
			}
			else if (Session["SendEmailCons"] != null)
			{
				EmailToList = (List<string>)Session["SendEmailCons"];
			}
			foreach (string item in EmailToList)
			{
				message.To.Add(item);
			}
			//msgBody = msgBody.Replace("<FirstName>", dr["first"].ToString());
			//msgBody = msgBody.Replace("<LastName>", dr["last"].ToString());
			//msgBody = msgBody.Replace("<Company>", dr["company"].ToString());
			if (txtTo.Text.Length > 0)
				message.To.Add(txtTo.Text);
			if (System.Diagnostics.Debugger.IsAttached)
			{
				System.Diagnostics.Debugger.Break();
				message.To.Clear();
			}

			if (txtCC.Text.Contains(","))
			{
				string[] Emails = txtCC.Text.Split(',');
				foreach (string Email in Emails)
				{
					message.CC.Add(Email);
				}
			}
			else
			{
				message.CC.Add(txtCC.Text);
			}
			SmtpClient emailClient = new SmtpClient(ConfigurationManager.AppSettings["MailerSMTPServer"]);
			try
			{
				emailClient.Send(message);
				foreach (string item in EmailToList)
				{
					AddSentEmailRecord(item);
				}

				lblMsg.Text = "Email has been sent successfully to " + EmailToList.Count.ToString() + " recipient(s).";
			}
			catch (Exception e)
			{
				lblMsg.Text = e.Message.ToString();
			}
		}
	}
	protected bool ValidateData()
	{
		bool Result = true;
		lblMsg.Text = "";
		string MatchEmailPattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
										 + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                            [0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
										 + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                            [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
										 + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";


		if (ddlTemplate.SelectedIndex == -1)
		{
			Result = false;
			lblMsg.Text = "You must select a template.";
		}

		if (txtFrom.Text.Length == 0)
		{
			Result = false;
			lblMsg.Text += " 'From' can't empty.";
		}
		else
		{
			if (!Regex.IsMatch(txtFrom.Text, MatchEmailPattern))
			{
				Result = false;
				lblMsg.Text += " 'From' has invalid email form.";
			}
		}

		if (txtTo.Text.Length == 0 || txtTo.Text == "---")
		{
			Result = false;
			lblMsg.Text += " 'To' has invalid email form.";
		}
		else
		{
			if (txtTo.Text != "Group of Accounts" && txtTo.Text != "Group of Contacts"
				 && txtTo.Text != "Account" && txtTo.Text != "Contact")
			{
				if (!Regex.IsMatch(txtTo.Text, MatchEmailPattern))
				{
					if (!txtTo.Text.Contains(","))
					{
						Result = false;
						lblMsg.Text += " 'To' has invalid email form.";
					}
					else
					{
						string[] Emails = txtTo.Text.Split(',');
						foreach (string Email in Emails)
						{
							if (!Regex.IsMatch(Email, MatchEmailPattern))
							{
								Result = false;
								lblMsg.Text += " 'To' has invalid email form.";
								break;
							}
						}
					}
				}
			}
		}

		if (txtCC.Text.Length > 0)
		{
			if (txtCC.Text != "Group of emails")
			{
				if (!Regex.IsMatch(txtCC.Text, MatchEmailPattern))
				{
					if (!txtCC.Text.Contains(","))
					{
						Result = false;
						lblMsg.Text += " 'CC' has invalid email form.";
					}
					else
					{
						string[] Emails = txtCC.Text.Split(',');
						foreach (string Email in Emails)
						{
							if (!Regex.IsMatch(Email, MatchEmailPattern))
							{
								Result = false;
								lblMsg.Text += " 'CC' has invalid email form.";
								break;
							}
						}
					}
				}
			}
		}

		if (txtSubject.Text.Length == 0)
		{
			Result = false;
			lblMsg.Text += " Subject can't empty.";
		}

		if (txtBody.Text.Length == 0)
		{
			Result = false;
			lblMsg.Text += " Email body can't empty.";
		}

		return Result;
	}
	protected void CancelEmailForm()
	{
		if (Session["SendEmailAccs"] != null)
		{
			Session["dtAccountsEmail"] = null;

			Session["SendEmailAccs"] = null;
			Response.Redirect("Accounts.aspx");
		}
		else if (Session["SendEmailCons"] != null)
		{
			Session["SendEmailCons"] = null;
			Session["dtContactsEmail"] = null;
			Response.Redirect("Contacts.aspx");
		}
	}
	protected void imgbtnSignOut_Click(object sender, ImageClickEventArgs e)
	{
		SignOut();
	}
	protected void btnSend1_Click(object sender, ImageClickEventArgs e)
	{
		SendEmailForm2();
	}
	protected void btnSend2_Click(object sender, ImageClickEventArgs e)
	{
		SendEmailForm2();
	}
}