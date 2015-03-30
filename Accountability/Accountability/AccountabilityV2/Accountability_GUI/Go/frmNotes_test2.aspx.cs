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
	public partial class frmNotes_test2 : System.Web.UI.Page
	{
		protected TSN.ERP.SharedComponents.Data.dsEmail dsEmail1;
		
		
//		private static int contactID;

		#region page load
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Register this form as Ajax compliant
			Ajax.Utility.RegisterTypeForAjax(typeof(frmNotes_test));
			if(!IsPostBack)
			{
//				divPanel.Visible=true;
				/***************************************************************/
				try
				{
					
					
					DataSet dsContactsAndEmails = new DataSet();
					string mailingType = System.Configuration.ConfigurationSettings.AppSettings["MailingType"];
					if(mailingType == "0")//Internal
					{
						Navigation.BaseObject.SafeMerge(dsContactsAndEmails,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListCotactsAndEmails(0));
					}
					else if(mailingType == "1")//External
					{
						Navigation.BaseObject.SafeMerge(dsContactsAndEmails,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListCotactsAndEmails(1));
					}
					else if(mailingType == "2")//Private
					{
						Navigation.BaseObject.SafeMerge(dsContactsAndEmails,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListCotactsAndEmails(2));
					}										
					else if(mailingType == "-1")//Get All mails
					{
						Navigation.BaseObject.SafeMerge(dsContactsAndEmails,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListCotactsAndEmails(-1));
					}										
					Session["dsContactsAndEmails"] = dsContactsAndEmails;
					dgEmails.DataSource=dsContactsAndEmails;
					dgEmails.DataBind();
					//divPanel.Visible=false;
				}
				catch(Exception ex)
				{
					Response.Write(ex.Message);
				}
				/******************************************************************/
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
			int ContactID= /*122;//*/Convert.ToInt32(Session["CurrentEmployee"]);
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
			this.dgEmails.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgEmails_PageIndexChanged);
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

		/************************************************************************/
		private void dgEmails_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			try
			{
				dgEmails.CurrentPageIndex = e.NewPageIndex;
				DataSet dsContactsAndEmails = new DataSet();
				dsContactsAndEmails = (DataSet)Session["dsContactsAndEmails"];
				dgEmails.DataSource=dsContactsAndEmails;
				dgEmails.DataBind();
			}
			catch(Exception ex)
			{
				Response.Write(ex.Message);
			}
		}

		protected void cbFind_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataSet dsContactsAndEmails  = (DataSet)Session["dsContactsAndEmails"];
				DataSet dsContactsAndEmailsCopy = new DataSet();
				DataRow[] drColl = dsContactsAndEmails.Tables[0].Select("ContactEmail LIKE  '%" + tbFilter.Text+ "%'");
				DataTable dt= dsContactsAndEmails.Tables[0].Clone();
				dsContactsAndEmailsCopy.Tables.Add(dt);
				foreach(DataRow dr in drColl)
				{					
					dsContactsAndEmailsCopy.Tables[0].ImportRow(dr);
				}				

				if(dsContactsAndEmailsCopy.Tables[0].Rows.Count > 0)
				{
					Label1.Visible = false;
					dgEmails.Visible = true;
					//Button1.Visible = true;
					//					cbAdd.Visible = true;
					dgEmails.DataSource=dsContactsAndEmailsCopy;
					dgEmails.DataBind();
				}
				else
				{
					Label1.Visible = true;
					dgEmails.Visible = false;
					//Button1.Visible = false;
					//					cbAdd.Visible = false;

				}

			}
			catch (Exception ex)
			{
				Response.Write(ex.Message);
			}
		}

	
		protected void lbShowAll_Click(object sender, System.EventArgs e)
		{
			DataSet dsContactsAndEmails = (DataSet)Session["dsContactsAndEmails"];
			dgEmails.DataSource=dsContactsAndEmails;
			dgEmails.DataBind();
			Label1.Visible = false;
			if(dgEmails.Items.Count > 0)
			{
				dgEmails.Visible = true;
			}
			else
			{
				dgEmails.Visible = false;
			}
		}



		protected void cbAdd_Click(object sender, System.EventArgs e)
		{
			string strEmail=String.Empty;
			int idx=0;
			foreach (DataGridItem dgiTemp in dgEmails.Items)
			{
				object temp  = dgiTemp.FindControl("cbxSelect");
				if (temp==null)continue;
				CheckBox cbxSelector = (CheckBox) temp;
				if (!cbxSelector.Checked)continue;
				idx++;
				strEmail += dgiTemp.Cells[ 1 ].Text.Trim(); 
				if(idx > 0)
					strEmail+=";";
			}
			if(idx == 0)
			{
				this.RegisterStartupScript("fdss","<script>alert('You must select at least one email address to add it');</script>");
			}
			if(strEmail.EndsWith(";"))
				strEmail = strEmail.Remove(strEmail.Length-1,1);
			//string mailButton = Request.QueryString.Get("mailButton");
			string mailButton = Session["mailButton"].ToString();
			this.RegisterStartupScript("fds","<script>saveEmails2('"+strEmail+"','"+mailButton+"');</script>");

		}

//		private void btnTo_ServerClick(object sender, System.EventArgs e)
//		{
//			divPanel.Visible=true;
//		}

		#region GetEmailAdresses
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
		public void getEMailAdrees(string mailButton)
		{
			
			try
			{
//				divPanel.Visible=true;
				DataSet dsContactsAndEmails = new DataSet();
				string mailingType = System.Configuration.ConfigurationSettings.AppSettings["MailingType"];
				if(mailingType == "0")//Internal
				{
					Navigation.BaseObject.SafeMerge(dsContactsAndEmails,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListCotactsAndEmails(0));
				}
				else if(mailingType == "1")//External
				{
					Navigation.BaseObject.SafeMerge(dsContactsAndEmails,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListCotactsAndEmails(1));
				}
				else if(mailingType == "2")//Private
				{
					Navigation.BaseObject.SafeMerge(dsContactsAndEmails,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListCotactsAndEmails(2));
				}										
				else if(mailingType == "-1")//Get All mails
				{
					Navigation.BaseObject.SafeMerge(dsContactsAndEmails,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListCotactsAndEmails(-1));
				}										
				Session["dsContactsAndEmails"] = dsContactsAndEmails;
				if(dsContactsAndEmails.Tables[0].Rows.Count>0)
//				divPanel.Visible=true;
				dgEmails.DataSource=dsContactsAndEmails;
				dgEmails.DataBind();				
			}
			catch(Exception ex)
			{
				Response.Write(ex.Message);
			}
			Session["mailButton"]=mailButton;
			//string mailButton = Request.QueryString.Get("mailButton");
		    string Script = "mailButton='"+mailButton+"';";
			this.RegisterStartupScript("fff", "<script>"+Script+"</script>");
			
			
		}
		#endregion
		
		#region CloseEmailWidow
			/// <summary>
			/// 
			/// </summary>
			/// <returns></returns>
		[Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
		public void closeEmailsWindow(string strValue)
		{
			try
			{
//				divPanel.Visible=false;
			}
			catch(Exception ex)
			{
				Response.Write(ex.Message);
			}
					
		}
		#endregion

		/**************************************************************************/
	}
}
