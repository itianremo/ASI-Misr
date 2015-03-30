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
//using System.Web.Mail;
using System.Net.Mail;
using System.Configuration;

namespace TSN.ERP.WebGUI.Go
{
	/// <summary>
	/// Summary description for frmEmpPhone.
	/// </summary>
	public partial class frmManagersNotes : System.Web.UI.Page
	{
		protected TSN.ERP.SharedComponents.Data.dsEmail dsEmail1;
		protected TSN.ERP.SharedComponents.Data.dsManagersNotes dsManagersNotes1;
        private bool methodFired = false;
		
//		private static int contactID;

		#region page load
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				string noteDate = Request.QueryString.Get("noteDate");
				DateTime dtNoteDate = DateTime.Parse(noteDate);
				ViewState["dtNoteDate"]=dtNoteDate;
				int userID = ((Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.GetLoggedUserID();				
				int weekDateCount = -(int)dtNoteDate.DayOfWeek;
				DateTime weekStart = dtNoteDate.AddDays(weekDateCount);
				ViewState["userID"]=userID;
				ViewState["weekStart"]=weekStart;
				//Response.Write(userID.ToString()+"<br>"+weekStart.ToShortDateString());
				//TSN.ERP.SharedComponents.Data.dsManagersNotes dsMngNotes = new TSN.ERP.SharedComponents.Data.dsManagersNotes();
				dsManagersNotes1.Merge(((Navigation.BaseObject) Session[ "navigation" ]).GeneralWSObject.ListManagerNoteByFilterString("UserID="+userID+" AND WeekStartDate='"+weekStart+"'"));
				ViewState["dsManagersNotes1"]=dsManagersNotes1;
				//DataSet ds=((Navigation.BaseObject) Session[ "navigation" ]).GeneralWSObject.ListManagerNoteByFilterString("UserID="+userID+" AND WeekStartDate='"+weekStart+"'");
				if(dsManagersNotes1.GEN_ManagerNotes.Rows.Count>0)
				{
					FreeTextBox1.Text =dsManagersNotes1.GEN_ManagerNotes.Rows[0]["NoteBody"].ToString();
					ViewState["ManagersNotesStauts"]="Update";
				}
				else
				{
					FreeTextBox1.Text ="";
					ViewState["ManagersNotesStauts"]="Insert";
				}
				//dsMngNotes.Merge(((Navigation.BaseObject) Session[ "navigation" ]).GeneralWSObjectListManagerNoteByFilterString("UserID="+userID+" AND WeekStartDate='"+weekStart+"'"));
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
				// added By Sayed Moawad 18/08/2008
				DataSet dsEmp = ((Navigation.BaseObject)Session["navigation"]).EmployeeWsObject.ListSingleEmployeeData(ContactID);
				if(dsEmp.Tables[0].Rows.Count>0)
				{
					empName=Convert.ToString(dsEmp.Tables[0].Rows[0]["Fullname"]).Trim();
				}
				// end
																				  

			
				txtSubject.Text = "Managers Weekly Report <" + empName +"><"+noteDate+">";
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
			this.dsManagersNotes1 = new TSN.ERP.SharedComponents.Data.dsManagersNotes();
			((System.ComponentModel.ISupportInitialize)(this.dsEmail1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsManagersNotes1)).BeginInit();
			// 
			// dsEmail1
			// 
			this.dsEmail1.DataSetName = "dsEmail";
			this.dsEmail1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dsManagersNotes1
			// 
			this.dsManagersNotes1.DataSetName = "dsManagersNotes";
			this.dsManagersNotes1.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.dsEmail1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsManagersNotes1)).EndInit();

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
            if (methodFired)
                return;
            if (ConfigurationManager.AppSettings["UseMailerModule"] == "No")
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(txtFrom.Text);
                msg.To.Add(txtTo.Text);
                if (!String.IsNullOrEmpty(txtCC.Text))
                    msg.CC.Add(txtCC.Text);
                if (!String.IsNullOrEmpty(txtBCC.Text))
                    msg.Bcc.Add(txtBCC.Text);
                msg.Subject = txtSubject.Text;
                msg.IsBodyHtml = true;
                msg.Body = "<html><body><table><tr><td>" + FreeTextBox1.Text + "</td></tr></table></body></html>";//"<H1>HHHHHHHHHH</H1>";//notes;			
                SmtpClient client = new SmtpClient();
                client.Host = ConfigurationManager.AppSettings["SMTPServer"];
                client.SendCompleted += new SendCompletedEventHandler(client_SendCompleted);
                client.SendAsync(msg, null);                
            }
            else if (ConfigurationManager.AppSettings["UseMailerModule"] == "Yes")
            {
                WSMailer.MailerService mailService = new TSN.ERP.WebGUI.WSMailer.MailerService();
                string From = txtFrom.Text;
                string To = txtTo.Text;
                string CC = txtCC.Text;
                string BCC = txtBCC.Text;
                string Subject = txtSubject.Text;
                string Body = "<html><body><table><tr><td>" + FreeTextBox1.Text + "</td></tr></table></body></html>";
                try
                {
                    bool Success = false;
                    Success = mailService.SendHTMLMail(To, CC, BCC, From, "", Subject, Body, "");
                    if (!Success)
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
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "CloseMe", "<script>closeNotes();</script>");
            methodFired = true;
            #region Old Code that uses System.Web.Mail namespace (.NET 2003)
            ////////////////////            MailMessage msg = new MailMessage();
            ////////////////////            msg.From=txtFrom.Text;
            ////////////////////            msg.To=txtTo.Text;
            ////////////////////            msg.Cc=txtCC.Text;
            ////////////////////            msg.Bcc=txtBCC.Text;
            ////////////////////            msg.Subject=txtSubject.Text;
            ////////////////////            msg.BodyFormat=MailFormat.Html;
            ////////////////////            msg.Body="<html><body><Table><tr><td>"+FreeTextBox1.Text+"</td></tr></table></body></html>";//"<H1>HHHHHHHHHH</H1>";//notes;			

            ////////////////////            string mailingType = System.Configuration.ConfigurationSettings.AppSettings["MailingType"];
            ////////////////////            if(mailingType == "0")//Internal
            ////////////////////            {
            ////////////////////                SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"];		
            ////////////////////                //SmtpMail.SmtpServer.Insert(0,System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"]);
            ////////////////////            }
            ////////////////////            else if(mailingType == "1")//External
            ////////////////////            {
            ////////////////////                SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"];					
            ////////////////////                //SmtpMail.SmtpServer.Insert(0,System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"]);

            //////////////////////				msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
            //////////////////////				msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "hamdyahmed");
            //////////////////////				msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "9ikj#");

            ////////////////////            }
            ////////////////////            try
            ////////////////////            {
            ////////////////////                SmtpMail.Send(msg);
            ////////////////////                btnSaveManagerNote_Click(null,null);
            ////////////////////            }
            ////////////////////            catch(Exception ex)
            ////////////////////            {
            ////////////////////                //Response.Write(ex.InnerException);
            ////////////////////                lblNote.Visible=true;
            ////////////////////                lblNote.Text = "Error during sending mail, make sure you typed correct email addresses";
            ////////////////////                return;
            ////////////////////            }
            //////////////////////			string scriptSave = "window.opener.setFreeTextBoxData(FTB_API['FreeTextBox1'].GetHtml());";
            //////////////////////			scriptSave += "window.opener.saveNote();";
            //////////////////////			scriptSave += "window.close();";
            ////////////////////            this.RegisterStartupScript("CloseMe","<script>closeNotes();</script>"); 
            #endregion
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

		protected void btnSaveManagerNote_Click(object sender, System.EventArgs e)
		{ 
			int returnValue=-1;
			string vsManagersNotesStauts=ViewState["ManagersNotesStauts"].ToString();
			dsManagersNotes1=(SharedComponents.Data.dsManagersNotes)ViewState["dsManagersNotes1"];
			if(vsManagersNotesStauts=="Update")
			{
				
				//SharedComponents.Data.dsManagersNotes.GEN_ManagerNotesRow row = ((SharedComponents.Data.dsManagersNotes.GEN_ManagerNotesRow)dsManagersNotes1.GEN_ManagerNotes.Rows[0]).NoteBody;
				((SharedComponents.Data.dsManagersNotes.GEN_ManagerNotesRow)dsManagersNotes1.GEN_ManagerNotes.Rows[0]).NoteBody=FreeTextBox1.Text.Trim();
				returnValue = ((Navigation.BaseObject) Session[ "navigation" ]).GeneralWSObject.UpdateManagerNote(dsManagersNotes1);
			}
			else
			{
				//				SharedComponents.Data.dsManagersNotes.GEN_ManagerNotesRow row=new TSN.ERP.SharedComponents.Data.dsManagersNotes.GEN_ManagerNotesRow();//((SharedComponents.Data.dsManagersNotes.GEN_ManagerNotesRow)dsManagersNotes1.GEN_ManagerNotes.Rows[0]);
				//				row.UserID=Convert.ToInt32(ViewState["userID"]);
				//				row.MNoteID=1000;
				//				row.NoteBody=FreeTextBox1.Text;
				//				row.WeekStartDate=Convert.ToDateTime(ViewState["weekStart"]);
				//				dsManagersNotes1.GEN_ManagerNotes.Rows.Add(row);
				returnValue = ((Navigation.BaseObject) Session[ "navigation" ]).GeneralWSObject.AddManagerNote(FreeTextBox1.Text,Convert.ToDateTime(ViewState["dtNoteDate"]));		

			}
			this.RegisterStartupScript("f","<script>this.close();</script>");
		
		}
	}
}
