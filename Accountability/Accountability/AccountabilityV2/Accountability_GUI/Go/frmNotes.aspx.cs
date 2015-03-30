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
using System.Web.Mail;

namespace TSN.ERP.WebGUI.Go
{
	/// <summary>
	/// Summary description for frmEmpPhone.
	/// </summary>
	public partial class frmNotes : System.Web.UI.Page
	{
		protected TSN.ERP.SharedComponents.Data.dsEmail dsEmail1;
		
//		private static int contactID;

		#region page load
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
//				//
//				string NoteText = Session["NotesSession"].ToString().Replace("123!!!321","=").Replace("123!321","#");
////				string NoteText = Request.QueryString.Get("NoteText").Replace("123!!!321","=").Replace("123!321","#");
//				FreeTextBox1.Text = NoteText;
////				FCKeditor1.Value=Request.QueryString.Get("NoteText").Replace("123!!!321","=");
////				FCKeditor1.Value= FCKeditor1.Value.Replace("123!321","#");

            lblNote.Visible=false;
			string empName=Request.QueryString.Get("empName");
			if(empName.StartsWith("'"))
			{
				empName = empName.Remove(0,1);
			}
			if(empName.EndsWith("'"))
			{
				empName = empName.Remove(empName.Length-1,1);
			}
			string noteDate = Request.QueryString.Get("noteDate");
			if(noteDate.StartsWith("'"))
			{
				noteDate = noteDate.Remove(0,1);
			}
			if(noteDate.EndsWith("'"))
			{
				noteDate = noteDate.Remove(noteDate.Length-1,1);
			}
			int ContactID= /*122;//*/Convert.ToInt32(Session["LoginContactID"]);
//			DataSet ds = ((Navigation.BaseObject)Session["navigation"]).ContactWsObject.ListAllCotactEmails(ContactID);
//			Navigation.BaseObject.SafeMerge(dsEmail1, ((Navigation.BaseObject)Session["navigation"]).ContactWsObject.ListAllCotactEmails(ContactID));
			dsEmail1.Clear();
			Navigation.BaseObject.SafeMerge(dsEmail1,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListAllCotactEmails(ContactID));
			if(dsEmail1.GEN_Emails.Rows.Count > 0)
			{
				string mailingType = System.Configuration.ConfigurationSettings.AppSettings["MailingType"];
				DataRow[] Mails = dsEmail1.GEN_Emails.Select("EmailType="+mailingType+"");
				if(mailingType == "0")//Internal
				{
					if(Mails.Length > 0)
					{
						txtFrom.Text = Mails[0]["ContactEmail"].ToString().Trim();
						btnSendMail.Enabled=true;
					}
					else
					{
						txtFrom.Text = String.Empty;
						lblNote.Visible=true;
						lblNote.Text = "User hasn't internal email";
	//					Response.Write("No internal emails");
						btnSendMail.Enabled=false;
					}
				}
				else if(mailingType == "1")//External
				{
					if(Mails.Length > 0)
					{
						txtFrom.Text = Mails[0]["ContactEmail"].ToString().Trim();
						btnSendMail.Enabled=true;
					}
					else
					{
						txtFrom.Text = String.Empty;
						lblNote.Visible=true;
						lblNote.Text = "User hasn't external email";
						//					Response.Write("No internal emails");
						btnSendMail.Enabled=false;
					}
				}
			}
			else
			{
				txtFrom.Text=String.Empty;
				lblNote.Visible=true;
				lblNote.Text = "User hasn't email";
//				Response.Write("No Emails");
				btnSendMail.Enabled=false;
			}
			

////////////////////			//Old code
////////////////////			Navigation.BaseObject.SafeMerge(dsEmail1,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListAllCotactEmails(ContactID));
////////////////////			if(dsEmail1.GEN_Emails.Rows.Count > 0)
////////////////////			{
////////////////////				DataRow[] internalMail = dsEmail1.GEN_Emails.Select("EmailType=0");
////////////////////				if(internalMail.Length > 0)
////////////////////				{
////////////////////					txtFrom.Text = internalMail[0]["ContactEmail"].ToString().Trim();
////////////////////				}
////////////////////				else
////////////////////				{
////////////////////					txtFrom.Text = String.Empty;
////////////////////					lblNote.Visible=true;
////////////////////					lblNote.Text = "User hasn't internal email";
//////////////////////					Response.Write("No internal emails");
////////////////////				}
////////////////////			}
////////////////////			else
////////////////////			{
////////////////////				txtFrom.Text=String.Empty;
////////////////////				lblNote.Visible=true;
////////////////////				lblNote.Text = "User hasn't email";
//////////////////////				Response.Write("No Emails");
////////////////////			}

				string defaultTo = System.Configuration.ConfigurationSettings.AppSettings["DefaultTo"];
				string defaultCC = System.Configuration.ConfigurationSettings.AppSettings["DefaultCC"];
				txtTo.Text=defaultTo;
				txtCC.Text = defaultCC;
				txtSubject.Text = "Note From <" + empName +"><"+noteDate+">";
			}
//			DoIt();
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
			this.dsEmail1 = new TSN.ERP.SharedComponents.Data.dsEmail();
			((System.ComponentModel.ISupportInitialize)(this.dsEmail1)).BeginInit();
			// 
			// dsEmail1
			// 
			this.dsEmail1.DataSetName = "dsEmail";
			this.dsEmail1.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.dsEmail1)).EndInit();

		}
		#endregion

		private void btnSaveNotes_Click(object sender, System.EventArgs e)
		{
			string notes = FreeTextBox1.Text;
			this.RegisterClientScriptBlock("dfd","<script>SaveNoteInAcc('"+notes+"')</script>");
		}

	
		//------------------------------------------------------------

		protected void btnSendMail_Click(object sender, System.EventArgs e)
		{
			MailMessage msg = new MailMessage();
			msg.From=txtFrom.Text;
			msg.To=txtTo.Text;
			msg.Cc=txtCC.Text;
			msg.Bcc=txtBCC.Text;
			msg.Subject=txtSubject.Text;
			msg.BodyFormat=MailFormat.Html;
			msg.Body="<html><body><Table><tr><td>"+FreeTextBox1.Text+"</td></tr></table></body></html>";//"<H1>HHHHHHHHHH</H1>";//notes;			

			string mailingType = System.Configuration.ConfigurationSettings.AppSettings["MailingType"];
			if(mailingType == "0")//Internal
			{
				SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"];		
				//SmtpMail.SmtpServer.Insert(0,System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"]);
			}
			else if(mailingType == "1")//External
			{
				SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"];					
				//SmtpMail.SmtpServer.Insert(0,System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"]);

//				msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
//				msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "hamdyahmed");
//				msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "H@mdy7#");

			}
			try
			{
				SmtpMail.Send(msg);
			}
			catch(Exception ex)
			{
				//Response.Write(ex.InnerException);
				lblNote.Visible=true;
				lblNote.Text = "Error during sending mail, make sure you typed correct email addresses";
				return;
			}
//			string scriptSave = "window.opener.setFreeTextBoxData(FTB_API['FreeTextBox1'].GetHtml());";
//			scriptSave += "window.opener.saveNote();";
//			scriptSave += "window.close();";
			this.RegisterStartupScript("CloseMe","<script>closeNotes();</script>");
		}
	}
}
