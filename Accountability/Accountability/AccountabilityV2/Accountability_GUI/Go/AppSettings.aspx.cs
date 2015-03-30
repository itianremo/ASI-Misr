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
using System.Xml;  
using System.Configuration;
using System.Reflection;

namespace TSN.ERP.WebGUI.Go
{
	/// <summary>
	/// Summary description for frmEmpPhone.
	/// </summary>
	public partial class AppSettings : System.Web.UI.Page
	{
		protected FreeTextBoxControls.FreeTextBox FreeTextBox1;
		
//		private static int contactID;

		#region page load
		protected void Page_Load(object sender, System.EventArgs e)
		{
			lblNote.Visible=false;;
			if(!IsPostBack)
			{
				txtServerName.Text = ConfigurationSettings.AppSettings["ServerName"];
				txtSMTPServer.Text = ConfigurationSettings.AppSettings["MailerSMTPServer"];
				txtSMTPPort.Text   = ConfigurationSettings.AppSettings["MailerSMPTPort"];
				txtUserName.Text   = ConfigurationSettings.AppSettings["MailerUserName"];
				txtPassword.Text   = ConfigurationSettings.AppSettings["MailerUserPwd"];
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

		}
		#endregion	
		//------------------------------------------------------------

		protected void btnSaveMailSettings_Click(object sender, System.EventArgs e)
		{
			if(!WriteSetting("ServerName",txtServerName.Text))
			{
				lblNote.Visible=true;
				lblNote.Text = "Error during updating Server Name";
				return;
			}
			if(!WriteSetting("MailerSMTPServer",txtSMTPServer.Text))			
			{
				lblNote.Visible=true;
				lblNote.Text = "Error during updating SMTP Server";
				return;
			}
			if(!WriteSetting("MailerSMPTPort",txtSMTPPort.Text))
			{
				lblNote.Visible=true;
				lblNote.Text = "Error during updating SMTP Port";
				return;
			}
            if(!WriteSetting("MailerUserName",txtUserName.Text))
			{
				lblNote.Visible=true;
				lblNote.Text = "Error during updating User Name";
				return;
			}
			if(!WriteSetting("MailerUserPwd",txtPassword.Text))
			{
				lblNote.Visible=true;
				lblNote.Text = "Error during updating Password";
				return;
			}
			lblNote.Visible=true;
			lblNote.Text = "Mail settings have been updated successfully";
		}

		public static string ReadSetting(string key)
		{
			return ConfigurationSettings.AppSettings[key];
		}

		public bool WriteSetting(string key, string value)
		{
			bool Success=false;
			// load config document for current assembly
			XmlDocument doc = loadConfigDocument();

			// retrieve appSettings node
			XmlNode node =  doc.SelectSingleNode("//appSettings");

//			if (node == null)
//				throw new InvalidOperationException("appSettings section not found in config file.");

			try
			{
				// select the 'add' element that contains the key
				XmlElement elem = (XmlElement)node.SelectSingleNode(string.Format("//add[@key='{0}']", key));

				if (elem != null)
				{
					// add value for key
					elem.SetAttribute("value", value);
				}
				else
				{
					// key was not found so create the 'add' element 
					// and set it's key/value attributes 
					elem = doc.CreateElement("add");
					elem.SetAttribute("key", key);
					elem.SetAttribute("value", value); 
					node.AppendChild(elem);
				}
				doc.Save(getConfigFilePath());
				return Success=true;
			}
			catch(Exception ex)
			{
				string str = ex.Message;
				return Success=false;
				
				//throw;
			}
		}

		public void RemoveSetting(string key)
		{
			// load config document for current assembly
			XmlDocument doc = loadConfigDocument();

			// retrieve appSettings node
			XmlNode node =  doc.SelectSingleNode("//appSettings");

			try
			{
				if (node == null)
					throw new InvalidOperationException("appSettings section not found in config file.");
				else
				{
					// remove 'add' element with coresponding key
					node.RemoveChild(node.SelectSingleNode(string.Format("//add[@key='{0}']", key)));
					doc.Save(getConfigFilePath());
				}
			}
			catch (NullReferenceException e)
			{
				throw new Exception(string.Format("The key {0} does not exist.", key), e);
			}
		}

		private XmlDocument loadConfigDocument()
		{
			XmlDocument doc = null;
			try
			{
				doc = new XmlDocument();
				doc.Load(getConfigFilePath());
				return doc;
			}
			catch (System.IO.FileNotFoundException e)
			{
				throw new Exception("No configuration file found.", e);
			}
		}

		private string getConfigFilePath()
		{
			//return Assembly.GetExecutingAssembly().Location + ".config";
			string ConfigFilePath="";
			ConfigFilePath = AppDomain.CurrentDomain.BaseDirectory+"web.config";
			//ConfigFilePath = @"d:/web.xml";
			ConfigFilePath = System.Web.HttpContext.Current.Server.MapPath("../web.config");
			return ConfigFilePath;
		}
	}

	#region ConfigSettings that is used to add, update and delete appsettings keys
	#endregion
}
