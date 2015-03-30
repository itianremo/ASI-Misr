using System;
using TSN.ERP;
//using System.EnterpriseServices;
namespace TSN.ERP.Engine
{
	/// <summary>
	/// Summary description for ServerShell.
	/// </summary>
	/// 





	//[ObjectPooling(Enabled=false),JustInTimeActivation(true)]
	public class ServerShell//r:ServicedComponent //this class represents the base class of all classes  using com+ services
	{
		public ServerShell()
		{
			if (Server.ERPServer == null)
				new Server();
		}

		public Session GetSession(string Token)
		{  
			//r System.EnterpriseServices.ContextUtil.DeactivateOnReturn = false;
			return Server.ERPServer.GetSession(Token);	
		}

		//r[AutoComplete(true)]
		public Session LogIn(string UserName, string Password)
		{
			//r System.EnterpriseServices.ContextUtil.DeactivateOnReturn = false;
			return Server.ERPServer.LogIn(UserName,Password);
		}
//		public bool Start()
//		{
//			//r System.EnterpriseServices.ContextUtil.DeactivateOnReturn = false;
//			if (Server.ERPServer == null)
//			{
//				new Server();
//				return true;
//			}
//			else
//			{
//				return false;
//			}
//		}
		public int ForceTimeOutCheck()
		{
			//r System.EnterpriseServices.ContextUtil.DeactivateOnReturn = false;
			return Server.ERPServer.TimeOutCheck();
		}
		public System.Data.DataSet GetServerData()
		{
			//r System.EnterpriseServices.ContextUtil.DeactivateOnReturn = false;
			return Server.ERPServer.GetServerData();
		}
	}
}
