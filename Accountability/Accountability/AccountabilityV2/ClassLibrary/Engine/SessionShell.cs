using System;
//r using System.EnterpriseServices;
using TSN.ERP.Security;
namespace TSN.ERP.Engine
{
	/// <summary>
	/// Summary description for SessionShell.
	/// </summary>
	/// 
	//r [ObjectPooling(Enabled=true, MinPoolSize=0, MaxPoolSize=100, CreationTimeout=200000),JustInTimeActivation(true)]
	public class SessionShell//r :ServicedComponent 
	{
		private Session LocalSession;
		public SessionShell()
		{

		}
		public string Token
		{
			get
			{
				return LocalSession.Token;
			}
		}
		public string UserName
		{
			get
			{
				return LocalSession.UserName;
			}
		}
		public int UserId
		{
			get
			{
				return LocalSession.UserId;
			}
		}
		public ERPUserSecurityInfo  UserSecurityInfo
		{
			get
			{
				return LocalSession.UserSecurityInfo;
			}
		}
		
	}
}
