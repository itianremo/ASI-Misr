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
using System.Text.RegularExpressions;
using System.Net.Mail;


public partial class ASILogin : Office.BLL.MasterClass
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			CRMLogin.InstructionText = GetVersionInfo();

		}
		//////
		//btnLogin.Attributes.Add("onmouseover", "this.src='Images/sign_mouseover.png'");
		//btnLogin.Attributes.Add("onmouseout", "this.src='Images/sign_normal.png'");
		//btnLogin.Attributes.Add("onmousedown", "this.src='Images/sign_down.gif'");
		////////
		//imgbtnSendPassword.Attributes.Add("onmouseover", "this.src='Images/send_mouseover.gif'");
		//imgbtnSendPassword.Attributes.Add("onmouseout", "this.src='Images/send_normal.gif'");
		//imgbtnSendPassword.Attributes.Add("onmousedown", "this.src='Images/send_down.gif'");
		////////
		//lblLoginError.Visible = false;
	}

	//protected void btnLogin_Click(object sender, ImageClickEventArgs e)
	//{
	//   SecurityUserLogin SUL = new SecurityUserLogin();
	//   SUL.UserName = txtUserName.Text;
	//   SUL.Password = txtPassword.Text;
	//   if (SUL.GetUserData())
	//   {
	//      if (SUL.Active == true)
	//      {
	//         Session["UserData"] = SUL;
	//         //Response.Redirect("Home.aspx");
	//         //if (((SecurityUserLogin)Session["UserData"]).GetUserRoles().Contains("ViewAccount"))
	//         //    Response.Redirect("Accounts.aspx");
	//         //else if (((SecurityUserLogin)Session["UserData"]).GetUserRoles().Contains("ViewContact"))
	//         //    Response.Redirect("Contacts.aspx");
	//         //else
	//         //{
	//         //    lblLoginError.Visible = true;
	//         //    lblLoginError.Text = "Access Denied, You are not authorized to view any of website pages";
	//         //}
	//         //------------- Auth Cookie ----------------
	//         //FormsAuthentication.Initialize();
	//         // Get Roles
	//         ArrayList roles = SUL.GetUserRoles();
	//         if (SUL.Administrator.Value)
	//            roles.Insert(0, "Administrator");
	//         // Serialize the User Login Data
	//         string UserLogin = Serializer.Serialize(SUL);



	//         string UserData = string.Format("{0}##Roles##{1}", UserLogin, string.Join("|", roles.ToArray(typeof(string)) as string[]));

	//         FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, SUL.UserName, DateTime.Now, DateTime.Now.AddDays(2), false, UserData);
	//         string cookieContents = FormsAuthentication.Encrypt(authTicket);
	//         //HttpCookie authCookie = FormsAuthentication.GetAuthCookie(SUL.UserName, false);
	//         //authCookie.Value = cookieContents;
	//         var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieContents)
	//         {
	//            Expires = authTicket.Expiration,
	//            Path = FormsAuthentication.FormsCookiePath
	//         };

	//         Response.Cookies.Add(cookie);
	//         //Response.Cookies.Add(new HttpCookie("newCookie", "This Is Value"));
	//         //string defaulrUrl = FormsAuthentication.DefaultUrl;
	//         //FormsAuthentication.RedirectFromLoginPage(SUL.UserName, true);
	//         //string isloged = User.Identity.Name;
	//         Response.Redirect("Home.aspx");

	//      }
	//      else
	//      {
	//         lblLoginError.Text = "Access Denied, you will not be able to login because your account is disabled";
	//         lblLoginError.Visible = true;
	//      }
	//   }
	//   else
	//   {
	//      lblLoginError.Text = "Access Denied, Invalid Username or Password";
	//      lblLoginError.Visible = true;

	//   }
	//}

	//protected void lnkForgotPassword_Click(object sender, EventArgs e)
	//{
	//   HandleControls(false);
	//   lblUserName.Text = "Email Address:";
	//   lnkForgotPassword.Text = "login";

	//}

	//private void HandleControls(bool Flag)
	//{
	//   txtUserName.Visible = Flag;
	//   txtPassword.Visible = Flag;
	//   lblPassword.Visible = Flag;
	//   btnLogin.Visible = Flag;
	//   lnkForgotPassword.Visible = Flag;
	//   imgbtnSendPassword.Visible = !Flag;
	//   txtUserEmail.Visible = !Flag;
	//   lnkbtnLogin.Visible = !Flag;
	//}
	//protected void btnSendPassword_Click(object sender, EventArgs e)
	//{
	//   if (txtUserEmail.Text != "" && IsValidEmail(txtUserEmail.Text))
	//   {
	//      SecurityUserLogin SUL = new SecurityUserLogin();
	//      SUL.EMail = txtUserEmail.Text;
	//      if (SUL.GetUserPassword())
	//      {
	//         if (sendEmail("service@ASI-CRM.com", "ASI-CRM Service ", txtUserEmail.Text, SUL.Password))
	//         {
	//            lblLoginError.Visible = true;
	//            lblLoginError.Text = "Your password has been sent.<p></p>";
	//         }
	//         else
	//         {
	//            lblLoginError.Visible = true;
	//            lblLoginError.Text = "There was a problem in sending the email<p></p>";
	//         }
	//      }
	//      else
	//      {
	//         lblLoginError.Text = "Your email address does not match any Account on file.<p></p>";
	//         lblLoginError.Visible = true;
	//         //
	//         lblUserName.Text = "Please enter the correct email Address:";

	//      }
	//   }
	//   else
	//   {
	//      lblLoginError.Text = "Enter vaild user email address<p></p>";
	//      lblLoginError.Visible = true;

	//   }
	//}
	private bool IsValidEmail(string email)
	{
		bool isValid = false;
		if (email != "")
		{
			string strRegex = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
			Regex re = new Regex(strRegex);
			if (re.IsMatch(email))
			{ isValid = true; }
			else
			{ isValid = false; }
		}
		return isValid;
	}

	private bool sendEmail(string From, string Alias, string To, string Password)
	{
		bool result = false;
		string msgBody = "Hi " + To + ",<p> Your password for ASI-CRM Application is: " + Password + "</p><b>The ASI-CRM Team";
		string msgSubject = "Your ASI-CRM Password";
		try
		{

			MailMessage mMsg = new MailMessage();
			mMsg.From = new MailAddress(From, Alias);
			mMsg.To.Add(To);
			mMsg.Subject = msgSubject;
			mMsg.Body = msgBody;
			mMsg.IsBodyHtml = true;
			SmtpClient smtp = new SmtpClient();
			smtp.Host = ConfigurationManager.AppSettings["MailerSMTPServer"].ToString();
			try
			{

				smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
				smtp.Send(mMsg);
				result = true;
			}

			catch (SmtpException ex)
			{
				WSMailer.MailerService Mailer = new WSMailer.MailerService();
				result = Mailer.SendHTMLMail(To, "", "", From, Alias, msgSubject, msgBody, "");
				smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
				smtp.Send(mMsg);
			}

		}

		catch (Exception exp)
		{
			//lblLoginError.Text = String.Format("There was a problem in sending the email: {0}", exp.Message.Replace("'", "\'") + "\n" + exp.ToString().Replace("'", "\'"));
			CRMLogin.FailureText = String.Format("There was a problem in sending the email: {0}", exp.Message.Replace("'", "\'") + "\n" + exp.ToString().Replace("'", "\'"));
			
			//lblLoginError.Visible = true;
		}
		return result;
	}



	protected void lnkbtnLogin_Click(object sender, EventArgs e)
	{
		Response.Redirect("login.aspx");
	}
	//protected void imgbtnSendPassword_Click(object sender, ImageClickEventArgs e)
	//{
	//   if (txtUserEmail.Text != "" && IsValidEmail(txtUserEmail.Text))
	//   {
	//      SecurityUserLogin SUL = new SecurityUserLogin();
	//      SUL.EMail = txtUserEmail.Text;
	//      if (SUL.GetUserPassword())
	//      {
	//         if (sendEmail("service@ASI-CRM.com", "ASI-CRM Service ", txtUserEmail.Text, SUL.Password))
	//         {
	//            lblLoginError.Visible = true;
	//            lblLoginError.Text = "Your password has been sent.<p></p>";
	//         }
	//         else
	//         {
	//            lblLoginError.Visible = true;
	//            lblLoginError.Text = "There was a problem in sending the email<p></p>";
	//         }
	//      }
	//      else
	//      {
	//         lblLoginError.Text = "Your email address does not match any Account on file.<p></p>";
	//         lblLoginError.Visible = true;
	//         //
	//         lblUserName.Text = "Please enter the correct email Address:";

	//      }
	//   }
	//   else
	//   {
	//      lblLoginError.Text = "Enter vaild user email address<p></p>";
	//      lblLoginError.Visible = true;

	//   }
	//}
	protected void CRMLogin_Authenticate(object sender, AuthenticateEventArgs e)
	{
		SecurityUserLogin SUL = new SecurityUserLogin();
		SUL.UserName = CRMLogin.UserName;
		SUL.Password = CRMLogin.Password;
		if (SUL.GetUserData())
		{
			if (SUL.Active == true)
			{
				Session["UserData"] = SUL;
				//------------- Auth Cookie ----------------
				
				#region [Get Roles]
				ArrayList roles;
				try
				{
					roles = SUL.GetUserRoles();
				}
				catch (Exception)
				{
					roles = new ArrayList();
				}

				#endregion

				#region [IS Administrator - IS AccountManager]
				if (SUL.Administrator.Value)
					roles.Insert(0, "Administrator");
				if (SUL.IsAccountManagerUser())
					roles.Add("AccountManager");
				#endregion

				#region [AuthenticationTicket]
				System.Text.StringBuilder UserData = new System.Text.StringBuilder();
				UserData.Append(SUL.UserID.Value);
				UserData.Append("#");
				UserData.Append(SUL.AccountabilityID.Value);
				UserData.Append("#");
				UserData.Append(SUL.EMail);
				UserData.Append("#");
				UserData.Append(string.Join("|", roles.ToArray(typeof(string)) as string[]));

				var authTicket = new FormsAuthenticationTicket(1, SUL.UserName, DateTime.Now, DateTime.Now.AddDays(2), false, UserData.ToString());
				string cookieContents = FormsAuthentication.Encrypt(authTicket);

				var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieContents)
				{
					Expires = authTicket.Expiration,
					Path = FormsAuthentication.FormsCookiePath
				};

				Response.Cookies.Add(cookie);
				#endregion

				Response.Redirect("Home.aspx");
			}
			else
			{
				CRMLogin.InstructionText = "Access Denied, you will not be able to login because your account is disabled";
				//lblLoginError.Visible = true;
			}
		}
		else
		{
			CRMLogin.FailureText = "Access Denied, Invalid Username or Password";
			//lblLoginError.Visible = true;
		}
	}
	protected void CRMLogin_LoggingIn(object sender, LoginCancelEventArgs e)
	{

	}
}
