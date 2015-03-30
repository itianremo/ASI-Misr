using System;
using System.Configuration;
using System.Xml;
//using System.Web.UI;
using System.Collections;
using System.Xml.Serialization;
namespace TSN.ERP.Engine
{
	/// <summary>
	/// Summary description for SettingsManager.
	/// </summary>
	/// 

	
	public class SettingsManager
	{
		//Defualts
		private int timeoutval = 60;
		private int idleTime = 15;
		private string ConnectionLocation = @"D:\Accountability\ERP Workspace\Settings\ConnectionStrings.xml"; 
		XmlDocument XmlDoc = new XmlDocument(); 
		string VsAttributeValue;

		public SettingsManager()
		{
		}

		public int SessionTimeOut()
		{
			string SessionTimeout = mGetAttributeValue("SessionTimeOut");
			timeoutval = Convert.ToInt32(SessionTimeout);
			return timeoutval;
		}
		public int IdleSessionTimeOut()
		{
			string SessionTimeout = mGetAttributeValue("IdleSessionTimeOut");
			idleTime = Convert.ToInt32(SessionTimeout);
			return idleTime;
		}
		public string GetConnectionFile()
		{
			ConnectionLocation = mGetAttributeValue("ConnectionLocation");
			return ConnectionLocation;
		}
		private string mGetAttributeValue(string VsAttributeName)
		{
			

			try
			{
				try
				{
					
					string VsGetDirectory =AppDomain.CurrentDomain.BaseDirectory;
					//string path = page.MapPath("..\\Configuration\\SQLXMLFiles\\application.config");
					string VsFileName="Configurations/application.config";
					string path=VsGetDirectory+VsFileName;
					XmlDoc.Load(path);
					
				}
				catch
				{
					
					string path=System.IO.Path.GetFullPath("..\\..\\Configurations\\application.config");
					XmlDoc.Load(path);
				}
				
				XmlNodeList List = XmlDoc.SelectNodes("configuration//CONFIGURDATA[@id='1']");
				if(VsAttributeName=="ConnectionLocation")
				VsAttributeValue    = List[0].ChildNodes[0].InnerText; 
				else if(VsAttributeName=="MaxSessions")
				VsAttributeValue    = List[0].ChildNodes[1].InnerText; 
				else if(VsAttributeName=="SessionTimeOut")
				VsAttributeValue    = List[0].ChildNodes[2].InnerText;
				else if(VsAttributeName=="IdleSessionTimeOut")
				VsAttributeValue    = List[0].ChildNodes[3].InnerText;
                    
				
			}
			catch (Exception ee)
			{
				string error = ee.Message;
				return null;
			}
			return VsAttributeValue;
		}
	}
}
