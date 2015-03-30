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
using System.Configuration;

namespace TSN.ERP.WebGUI.Go
{
	/// <summary>
	/// Summary description for frmEmpPhone.
	/// </summary>
	public partial class frmManagersNotes_Test : System.Web.UI.Page
	{
		protected TSN.ERP.SharedComponents.Data.dsEmail dsEmail1;
		protected TSN.ERP.SharedComponents.Data.dsManagersNotes dsManagersNotes1;
        private bool methodFired = false;
		
//		private static int contactID;

		#region page load
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (!IsPostBack)
            {
                FreeTextBoxControls.NetSpell netSpell = new FreeTextBoxControls.NetSpell();
                try   // added to avoid error of IE8 with freetextbox control
                {
                    FreeTextBox1.Toolbars[3].Items.Add(netSpell);
                }
                catch { }
            }

			this.imgSaveManagerNote.Attributes.Add("onmouseover","src='images/Save_o.jpg'");
			this.imgSaveManagerNote.Attributes.Add("onmouseout","src='images/Save_n.jpg'");
			this.imgSaveManagerNote.Attributes.Add("onmousedown","src='images/Save_s.jpg'");

			this.imgSendMail.Attributes.Add("onmouseover","src='images/Send_o.jpg'");
			this.imgSendMail.Attributes.Add("onmouseout","src='images/Send_n.jpg'");
			this.imgSendMail.Attributes.Add("onmousedown","src='images/Send_s.jpg'");
			// Register this form as Ajax compliant
			Ajax.Utility.RegisterTypeForAjax(typeof(frmManagersNotes_Test));
            string empName = Request.QueryString.Get("empName");
			if(!IsPostBack)
			{

                if (ConfigurationManager.AppSettings["MailingType"] == "0")//Internal
                {
                    rblSendingMethod.SelectedIndex = 0;
                }
                else if (ConfigurationManager.AppSettings["MailingType"] == "1")//External
                {
                    rblSendingMethod.SelectedIndex = 1;
                }


                BindMailsGrid();



////////////////////                #region Load Emails DataGrid
////////////////////                try
////////////////////                {						
////////////////////                    DataSet dsContactsAndEmails = new DataSet();
////////////////////                    string mailingType = System.Configuration.ConfigurationSettings.AppSettings["MailingType"];
////////////////////                    if(mailingType == "0")//Internal
////////////////////                    {
////////////////////                        Navigation.BaseObject.SafeMerge(dsContactsAndEmails,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListCotactsAndEmails(0));
////////////////////                    }
////////////////////                    else if(mailingType == "1")//External
////////////////////                    {
////////////////////                        Navigation.BaseObject.SafeMerge(dsContactsAndEmails,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListCotactsAndEmails(1));
////////////////////                    }
////////////////////                    else if(mailingType == "2")//Private
////////////////////                    {
////////////////////                        Navigation.BaseObject.SafeMerge(dsContactsAndEmails,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListCotactsAndEmails(2));
////////////////////                    }										
////////////////////                    else if(mailingType == "-1")//Get All mails
////////////////////                    {
////////////////////                        Navigation.BaseObject.SafeMerge(dsContactsAndEmails,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListCotactsAndEmails(-1));
////////////////////                    }										
////////////////////                    Session["dsContactsAndEmails"] = dsContactsAndEmails;
////////////////////                    dgEmails.DataSource=dsContactsAndEmails;
////////////////////                    dgEmails.DataBind();
//////////////////////					RegisterClientScriptBlock("dfd","<script>drawGrid("+dgEmails+")</script>");
////////////////////                    //divPanel.Visible=false;
////////////////////                }
////////////////////                catch(Exception ex)
////////////////////                {
////////////////////                    Response.Write(ex.Message);
////////////////////                }
////////////////////                #endregion

				string noteDate = Request.QueryString.Get("noteDate");
				DateTime dtNoteDate = DateTime.Parse(noteDate);
				ViewState["dtNoteDate"]=dtNoteDate;
				//int userID = ((Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.GetLoggedUserID();	
				//added by sayed 30/09/2008

				// get contact ID for selected employee 
				int ContactID_Selected=Convert.ToInt32(Session["CurrentEmployee"]);
				// get User ID for selected employee 
				int userID=((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.GetUserIDByContactID(ContactID_Selected);

				//end
				int weekDateCount = -(int)dtNoteDate.DayOfWeek;
				DateTime weekStart = dtNoteDate.AddDays(weekDateCount);
				ViewState["userID"]=userID;
				ViewState["weekStart"]=weekStart;
				dsManagersNotes1.Merge(((Navigation.BaseObject) Session[ "navigation" ]).GeneralWSObject.ListManagerNoteByFilterString("UserID="+userID+" AND WeekStartDate='"+weekStart+"'"));
				ViewState["dsManagersNotes1"]=dsManagersNotes1;
				
				if(dsManagersNotes1.GEN_ManagerNotes.Rows.Count>0)
				{
					FreeTextBox1.Text =dsManagersNotes1.GEN_ManagerNotes.Rows[0]["NoteBody"].ToString();
					ViewState["ManagersNotesStauts"]="Update";
				}
				else
				{
					//Bullets without indention to save space.  Also, no spaces between bullets for same reason.  
					
					if(ContactID_Selected==-1)
					{
						lblNote.Visible=true;
						lblNote.Text = "You must select employee from accountability sheet page first";
						return;

					}
					else lblNote.Visible=false;
					// add template
					DataSet ManagerSet =((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListSingleEmployeeData(ContactID_Selected);
				
					//ManagerName=ManagerSet.Tables[0].Rows[0]["FullName"].ToString();
					//ManagerSet.Tables[0].Rows[0]["ContactID"].ToString();
					//ManagerSet.Tables[0].Rows[0]["CompElmentID"].ToString();

                    string CompanyNameAndEmployeeName = GetDeptName(int.Parse(ManagerSet.Tables[0].Rows[0]["CompElmentID"].ToString()))+" - "+empName;

					string strData=@"<U><B>";

                                    /* last code commented by sayed at 13/7/2009
                                    string CompanyNameAndManagerName=GetEmployeeCompanyNameAndManagerName(int.Parse(ManagerSet.Tables[0].Rows[0]["CompElmentID"].ToString()));
                                    strData+="<P align=center><FONT style='FONT-SIZE: 14pt; FONT-FAMILY: Arial'>"+CompanyNameAndManagerName+"</FONT> </P></B></U><B>";
                                    strData+="<P><FONT style='FONT-SIZE: 12pt; FONT-FAMILY: Arial'>Accomplishments for Week ("+weekStart.AddDays(-6).ToShortDateString()+"-"+weekStart.AddDays(-2).ToShortDateString()+")</FONT> </P></B>";
                                    strData+=" <P><FONT style='FONT-SIZE: 12pt; FONT-FAMILY: Arial'>";
                                    strData+="<LI>Bullets without indention to save space.  Also, no spaces between bullets for same reason.</LI><br><br><B>";
                                    strData+="<P><FONT style='FONT-SIZE: 12pt; FONT-FAMILY: Arial'>Priorities for Week ("+weekStart.AddDays(1).ToShortDateString()+"-"+weekStart.AddDays(5).ToShortDateString()+")</FONT> </P></B>";
                                    strData+="<P><FONT style='FONT-SIZE: 12pt; FONT-FAMILY: Arial'>";
                                    strData+=" <LI>Bullets without indention to save space.  Also, no spaces between bullets for same reason.</LI></FONT></FONT>";
                                   
                                     */
                         /* last code commented by sayed at 24/9/2009
                    strData += "<P align=center><FONT style='FONT-SIZE: 14pt; FONT-FAMILY: Arial'>" + CompanyNameAndEmployeeName + "</FONT> </P></B></U><B>";
                    strData += "<P><FONT style='FONT-SIZE: 12pt; FONT-FAMILY: Arial'>Accomplishments for Week (" + weekStart.AddDays(1).ToShortDateString() + "-" + weekStart.AddDays(5).ToShortDateString() + ")</FONT> </P></B>";
                    strData += " <P><FONT style='FONT-SIZE: 12pt; FONT-FAMILY: Arial'>";
                    strData += "<LI>Bullets without indention to save space.  Also, no spaces between bullets for same reason.</LI><br> <br><B>";
                    strData += "<P><FONT style='FONT-SIZE: 12pt; FONT-FAMILY: Arial'>Priorities for Week (" + weekStart.AddDays(8).ToShortDateString() + "-" + weekStart.AddDays(12).ToShortDateString() + ")</FONT> </P></B>";
                    strData += "<P><FONT style='FONT-SIZE: 12pt; FONT-FAMILY: Arial'>";
                    strData += " <LI>Bullets without indention to save space.  Also, no spaces between bullets for same reason.</LI></FONT></FONT>";
                        */
                    strData += "<P align=center><FONT style='FONT-SIZE: 14pt; FONT-FAMILY: Arial'>" + CompanyNameAndEmployeeName + "</FONT> </P></B></U><B>";
                    strData += "<P><FONT style='FONT-SIZE: 12pt; FONT-FAMILY: Arial'>Accomplishments for Week (" + weekStart.AddDays(1).ToShortDateString() + "-" + weekStart.AddDays(5).ToShortDateString() + ")</FONT> </P></B>";
                    strData += " <P><FONT style='FONT-SIZE: 12pt; FONT-FAMILY: Arial'>";
                    strData += "Tasks for this week.<br> <br><B>";
                    strData += "<P><FONT style='FONT-SIZE: 12pt; FONT-FAMILY: Arial'>Priorities for Week (" + weekStart.AddDays(8).ToShortDateString() + "-" + weekStart.AddDays(12).ToShortDateString() + ")</FONT> </P></B>";
                    strData += "<P><FONT style='FONT-SIZE: 12pt; FONT-FAMILY: Arial'>";
                    strData += "Tasks for next week.</FONT></FONT>";
					FreeTextBox1.Text =strData;
					ViewState["ManagersNotesStauts"]="Insert";
				}
				

            lblNote.Visible=false;
			
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
////////////////////            int ContactID= /*122;//*/Convert.ToInt32(Session["LoginContactID"]);
//////////////////////			DataSet ds = ((Navigation.BaseObject)Session["navigation"]).ContactWsObject.ListAllCotactEmails(ContactID);
//////////////////////			Navigation.BaseObject.SafeMerge(dsEmail1, ((Navigation.BaseObject)Session["navigation"]).ContactWsObject.ListAllCotactEmails(ContactID));
////////////////////            dsEmail1.Clear();
////////////////////            Navigation.BaseObject.SafeMerge(dsEmail1,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListAllCotactEmails(ContactID));
////////////////////            if(dsEmail1.GEN_Emails.Rows.Count > 0)
////////////////////            {
////////////////////                string mailingType = System.Configuration.ConfigurationSettings.AppSettings["MailingType"];
////////////////////                DataRow[] Mails = dsEmail1.GEN_Emails.Select("EmailType="+mailingType+"");
////////////////////                if(mailingType == "0")//Internal
////////////////////                {
////////////////////                    if(Mails.Length > 0)
////////////////////                    {
////////////////////                        txtFrom.Text = Mails[0]["ContactEmail"].ToString().Trim();
////////////////////                        imgSendMail.Enabled=true;
////////////////////                    }
////////////////////                    else
////////////////////                    {
////////////////////                        txtFrom.Text = String.Empty;
////////////////////                        lblNote.Visible=true;
////////////////////                        lblNote.Text = "User hasn't internal email";
////////////////////    //					Response.Write("No internal emails");
////////////////////                        imgSendMail.Enabled=false;
////////////////////                    }
////////////////////                }
////////////////////                else if(mailingType == "1")//External
////////////////////                {
////////////////////                    if(Mails.Length > 0)
////////////////////                    {
////////////////////                        txtFrom.Text = Mails[0]["ContactEmail"].ToString().Trim();
////////////////////                        imgSendMail.Enabled=true;
////////////////////                    }
////////////////////                    else
////////////////////                    {
////////////////////                        txtFrom.Text = String.Empty;
////////////////////                        lblNote.Visible=true;
////////////////////                        lblNote.Text = "User hasn't external email";
////////////////////                        //					Response.Write("No internal emails");
////////////////////                        imgSendMail.Enabled=false;
////////////////////                    }
////////////////////                }
////////////////////            }
////////////////////            else
////////////////////            {
////////////////////                txtFrom.Text=String.Empty;
////////////////////                lblNote.Visible=true;
////////////////////                lblNote.Text = "User hasn't email";
//////////////////////				Response.Write("No Emails");
////////////////////                imgSendMail.Enabled=false;
////////////////////            }
			

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
                // commented by Sayed 24/9/2009
				// txtTo.Text=defaultTo;
				txtCC.Text = defaultCC;
				// added By Sayed Moawad 18/08/2008
//				DataSet dsEmp = ((Navigation.BaseObject)Session["navigation"]).EmployeeWsObject.ListSingleEmployeeData(ContactID);
//				if(dsEmp.Tables[0].Rows.Count>0)
//				{
//					empName=Convert.ToString(dsEmp.Tables[0].Rows[0]["Fullname"]).Trim();
//				}
				// end
																				  

			
                //txtSubject.Text = "Managers Weekly Report <" + empName +"><"+noteDate+">";
                txtSubject.Text = "Weekly Report <" + empName + "><" + noteDate + ">";
			}
//			DoIt();
		}
        private void BindMailsGrid()
        {
            DataSet dsContactsAndEmails = new DataSet();
            string mailingType = ConfigurationManager.AppSettings["MailingType"];
            if (IsPostBack)//First load, get mailing type from web.config else getit from sending method radio button list 
                mailingType = rblSendingMethod.SelectedValue;
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
            dgEmails.DataSource = dsContactsAndEmails;
            dgEmails.DataBind();




            int ContactID = /*122;//*/Convert.ToInt32(Session["LoginContactID"]);
            dsEmail1.Clear();
            Navigation.BaseObject.SafeMerge(dsEmail1, ((Navigation.BaseObject)Session["navigation"]).ContactWsObject.ListAllCotactEmails(ContactID));
            if (dsEmail1.GEN_Emails.Rows.Count > 0)
            {
                DataRow[] Mails = dsEmail1.GEN_Emails.Select("EmailType=" + mailingType + "");
                if (mailingType == "0")//Internal
                {
                    if (Mails.Length > 0)
                    {
                        txtFrom.Text = Mails[0]["ContactEmail"].ToString().Trim();
                        imgSendMail.Enabled = true;
                    }
                    else
                    {
                        txtFrom.Text = String.Empty;
                        lblNote.Visible = true;
                        lblNote.Text = "User hasn't internal email";
                        //					Response.Write("No internal emails");
                        imgSendMail.Enabled = false;
                    }
                }
                else if (mailingType == "1")//External
                {
                    if (Mails.Length > 0)
                    {
                        txtFrom.Text = Mails[0]["ContactEmail"].ToString().Trim();
                        imgSendMail.Enabled = true;
                    }
                    else
                    {
                        txtFrom.Text = String.Empty;
                        lblNote.Visible = true;
                        lblNote.Text = "User hasn't external email";
                        //					Response.Write("No internal emails");
                        imgSendMail.Enabled = false;
                    }
                }
            }
            else
            {
                txtFrom.Text = String.Empty;
                lblNote.Visible = true;
                lblNote.Text = "User hasn't email";
                //				Response.Write("No Emails");
                imgSendMail.Enabled = false;
            }
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
			this.imgSendMail.Click += new System.Web.UI.ImageClickEventHandler(this.imgSendMail_Click);
			this.imgSaveManagerNote.Click += new System.Web.UI.ImageClickEventHandler(this.btnSaveManagerNote_Click);
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

        protected void imgSendMail_Click(object sender, ImageClickEventArgs e)
		{
            if (methodFired)
                return;
			// added by Sayed Moawad
			int ContactID_Selected=Convert.ToInt32(Session["CurrentEmployee"]);
			if(ContactID_Selected==-1)
			{
				lblNote.Visible=true;
				lblNote.Text = "You must select employee from accountability sheet page first";
				return;

			}
			else lblNote.Visible=false;

			MailMessage msg = new MailMessage();
			msg.From=txtFrom.Text;
			msg.To=txtTo.Text;
			msg.Cc=txtCC.Text;
			msg.Bcc=txtBCC.Text;
			msg.Subject=txtSubject.Text;
			msg.BodyFormat=MailFormat.Html;
			msg.Body="<html><body><Table><tr><td>"+FreeTextBox1.Text+"</td></tr></table></body></html>";//"<H1>HHHHHHHHHH</H1>";//notes;			

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

            if (rblSendingMethod.SelectedValue == "0")//Internal                
                SmtpMail.SmtpServer = ConfigurationManager.AppSettings["SMTPServerInternal"];
            else//External
                SmtpMail.SmtpServer = ConfigurationManager.AppSettings["SMTPServerExternal"];

			try
			{
				SmtpMail.Send(msg);
				btnSaveManagerNote_Click(null,null);
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
            methodFired = true;
		}
		private void btnSendMail_Click_Old(object sender, System.EventArgs e)
		{
			WSMailer.MailerService mailService=new TSN.ERP.WebGUI.WSMailer.MailerService();
			string From    = txtFrom.Text;
			string To      = txtTo.Text;
			string CC      = txtCC.Text;
			string BCC     = txtBCC.Text;
			string Subject = txtSubject.Text;
			string Body    = "<html><body><Table><tr><td>"+FreeTextBox1.Text+"</td></tr></table></body></html>";

			string mailingType = System.Configuration.ConfigurationSettings.AppSettings["MailingType"];
			try
			{
				bool Success=false;
				if(mailingType == "0")//Internal
				{
					Success = mailService.SendHTMLMail(To,CC,BCC,From,"",Subject,Body,"");	
					btnSaveManagerNote_Click(null,null);
				}
				else if(mailingType == "1")//External
				{
					Success = mailService.SendHTMLMail(To,CC,BCC,From,"",Subject,Body,"");
					btnSaveManagerNote_Click(null,null);
				}
				if(Success)
				{
					this.RegisterStartupScript("CloseMe","<script>closeNotes();</script>");
				}
				else
				{
					lblNote.Visible=true;
                    lblNote.Text = "Error during sending mail, make sure you typed correct email addresses";
					return;
				}

			}
			catch(Exception ex)
			{
				lblNote.Visible=true;
                lblNote.Text = ex.Message; //"Error during sending mail, make sure you typed correct email addresses";
				return;
			}
			//			string scriptSave = "window.opener.setFreeTextBoxData(FTB_API['FreeTextBox1'].GetHtml());";
			//			scriptSave += "window.opener.saveNote();";
			//			scriptSave += "window.close();";
			
		}

		private void btnSaveManagerNote_Click(object sender, ImageClickEventArgs e)
		{ 
			// added by Sayed Moawad
			int ContactID_Selected=Convert.ToInt32(Session["CurrentEmployee"]);
			if(ContactID_Selected==-1)
			{
				lblNote.Visible=true;
				lblNote.Text = "You must select employee from accountability sheet first";
				return;

			}
			else lblNote.Visible=false;
			////
			int returnValue=-1;
			string vsManagersNotesStauts=ViewState["ManagersNotesStauts"].ToString();
			dsManagersNotes1=(SharedComponents.Data.dsManagersNotes)ViewState["dsManagersNotes1"];
			if(vsManagersNotesStauts=="Update")
			{
				int testi=dsManagersNotes1.GEN_ManagerNotes.Rows.Count;
				string test=dsManagersNotes1.GEN_ManagerNotes.Rows[0]["NoteBody"].ToString();
				
				//SharedComponents.Data.dsManagersNotes.GEN_ManagerNotesRow row = ((SharedComponents.Data.dsManagersNotes.GEN_ManagerNotesRow)dsManagersNotes1.GEN_ManagerNotes.Rows[0]).NoteBody;
				((SharedComponents.Data.dsManagersNotes.GEN_ManagerNotesRow)dsManagersNotes1.GEN_ManagerNotes.Rows[0]).NoteBody=FreeTextBox1.Text.Trim();
				test=dsManagersNotes1.GEN_ManagerNotes.Rows[0]["NoteBody"].ToString();
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
        public string GetDeptName(int CompElmentID)
        {
            DataSet dsDept = ((Navigation.BaseObject)Session["navigation"]).CompanyWsObject.ListCompnayElements();
            DataView view = new DataView(dsDept.Tables[0]);

            view.Sort = "CompElmentID";
            int rowIndex = view.Find(CompElmentID);
            string vsCEName;
            if (rowIndex != -1)
            {

                string vsManagerContactID = view[rowIndex]["ContactID"].ToString();
                Session["ManagerContactID"] = vsManagerContactID;
                vsCEName = view[rowIndex]["CEName"].ToString();
                //DataSet ManagerSet = ((Navigation.BaseObject)Session["navigation"]).EmployeeWsObject.ListSingleEmployeeData(int.Parse(vsManagerContactID));
                //ManagerName = ManagerSet.Tables[0].Rows[0]["FullName"].ToString();
               
                return vsCEName;



            }
            return "";



        }
		public string GetEmployeeCompanyNameAndManagerName(int CompElmentID)
		{
			DataSet dsDept = ((Navigation.BaseObject) Session[ "navigation" ]).CompanyWsObject.ListCompnayElements();
			DataView view = new DataView(dsDept.Tables[0]);

			view.Sort = "CompElmentID";
			int rowIndex = view.Find(CompElmentID);
			string vsCEName;
			string ManagerName;

			if (rowIndex != -1)

			{

				string vsManagerContactID = view[rowIndex]["ContactID"].ToString();
				Session["ManagerContactID"]=vsManagerContactID;
				vsCEName = view[rowIndex]["CEName"].ToString();
				DataSet ManagerSet =((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListSingleEmployeeData(int.Parse(vsManagerContactID));
				
				ManagerName=ManagerSet.Tables[0].Rows[0]["FullName"].ToString();
				//ManagerSet.Tables[0].Rows[0]["ContactID"].ToString();
				 return vsCEName+" - "+ ManagerName;



			}
			return "";
			
       

		}
        protected void rblSendingMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindMailsGrid();
        }
}
}
