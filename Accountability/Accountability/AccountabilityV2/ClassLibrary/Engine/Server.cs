using System;
using System.Reflection;
using System.Diagnostics;
using TSN.ERP;
using TSN.ERP.Engine.Collections;




//r using System.EnterpriseServices;
namespace TSN.ERP.Engine
{
	/// <summary>
	/// The Server Class acts as a backbone for our system
	/// </summary>
	/// 



	//r [ObjectPooling(Enabled=true, MinPoolSize=1, MaxPoolSize=1, CreationTimeout=20000)]
	public class Server//r *:System.EnterpriseServices.ServicedComponent ,Interfaces.IServer */
	{
		internal static Server ERPServer;
		public static SettingsManager ServerSettings = new SettingsManager();
		//Collection of sessions currently open by the server
		private SessionCollection Sessions = new SessionCollection() ;
		// Server Resource Pool
		private ResourcePool MyResourcePool;
		private TSN.ERP.Security.SecurityManagement  ServerSecurityManager; 
		internal Data.dsServer dsServerData = new TSN.ERP.Engine.Data.dsServer();
		// LastCheckTime For TimeOutSessions
		private DateTime LastTimeOutCheck = DateTime.Now ;

		public Server()
		{
			try
			{
				Server.ERPServer = this;
				//Intating Resources
				this.MyResourcePool = new ResourcePool();
				this.ServerResources.OpenConnection();
				//Set Server Security Manager
				this.ServerSecurityManager = new TSN.ERP.Security.SecurityManagement();
				this.ServerSecurityManager.ConnectionString = this.ServerResources.GetConnectionString();
			}
			catch(Exception ex)
			{
				EventLog.WriteEntry("ERP Server","Couldn't Start Server, Internal Error: " + ex.Message,System.Diagnostics.EventLogEntryType.Error); 
			}
			
		}
		public void load ()
		{
			Server.ERPServer = this;
			//Intating Resources
			this.MyResourcePool = new ResourcePool();
			this.ServerResources.OpenConnection();
			//Set Server Security Manager
			this.ServerSecurityManager = new TSN.ERP.Security.SecurityManagement();
			this.ServerSecurityManager.ConnectionString = this.ServerResources.GetConnectionString();
		}
		//r
//		protected override void Dispose(bool disposing)
//		{
//			base.Dispose (disposing);
//		}
		//r
//		protected override bool CanBePooled() 
//		{
//			return true;
//		}
		# region Session Activation and time out 
		internal void DeactivateSession(Session TargetSession)
		{
			int SessionID = this.Sessions.IndexOf(TargetSession);
			if (SessionID < 0 )
				return;

			Data.dsServer.tSessionRow SessionRow =(Data.dsServer.tSessionRow) dsServerData.tSession.Rows.Find(TargetSession.Token);
			SessionRow.IdelSince = DateTime.Now;
			SessionRow.Status = "I";
		}
		// this function is used to mark the recored of a given session in the server dataset as Active,
		internal void ActivateSession(Session TargetSession)
		{
			int SessionID = this.Sessions.IndexOf(TargetSession);
			if (SessionID < 0 )
				return;
			Data.dsServer.tSessionRow SessionRow = (Data.dsServer.tSessionRow) dsServerData.tSession.Rows.Find(TargetSession.Token);
			SessionRow.SetIdelSinceNull();
			SessionRow.Status = "A";
		}


		// check session time out & idle session time out .. any idle sessions will be loggout 
		internal int TimeOutCheck()
		{
			
			int logedOffCount = 0;
			try
			{

				// Gets the server session time out as stated in the server config file
				int timeOut = ServerSettings.SessionTimeOut();
				// Gets the server idle session time out as stated in the server config file
				int idleTimeOut = ServerSettings.IdleSessionTimeOut();
				// Gets Sessions Count from the session collection
				int SessionCount = Sessions.Count;
				for (int i = SessionCount - 1 ;i >= 0;i--)
				{
					// Access the Session Row from the Server Dataset
					Data.dsServer.tSessionRow SessionRow = dsServerData.tSession[i];
					if (SessionRow.Status == "O")
						continue;
					//calculates the duration this session ahs been open in minutes and logs it off if nessecary
					TimeSpan aliveDuration = (DateTime.Now - SessionRow.LoginTime);
					int minuteCount = (int)(aliveDuration.Days*24*60+ aliveDuration.Hours*60+aliveDuration.Minutes);
					if (minuteCount >= timeOut)
					{
						LogOff(Sessions.find(SessionRow.Token));
						logedOffCount++;
						continue;
					}
					//-------------------------------------------------------------------------------------------//
					
					if (SessionRow.Status != "I")// Session Status is idle the check will not contniue , Modified to get better performance
						continue;
					TimeSpan idleDuration = (DateTime.Now - SessionRow.IdelSince);
					minuteCount = (int)(idleDuration.Days*24*60+ idleDuration.Hours*60+idleDuration.Minutes);
					if (minuteCount >= idleTimeOut)
					{
						LogOff(Sessions.find(SessionRow.Token));
						logedOffCount++;
						continue;
					}
				}
				return logedOffCount;
			}
			catch(Exception ex)
			{
				EventLog.WriteEntry("TSN ERP Server","Error While Session Time Out Check: " + ex.Message ,EventLogEntryType.Error);
				return logedOffCount;
			}
			
		}
		#endregion
		# region Login and Sessions handling


		// Checks that the provided user name and password are correct
		//Adds a newly created session to the server sessions collection, 
		internal bool RegisterSession(Session NewSession,string UserName, string Password)
		{
			if(NewSession.Authenticated)
				throw new Exception("Session Already Registerd");
			//Check User Name and Password
			if (!this.ServerSecurityManager.CheckUser(UserName,Password))
				return false;
			int sessionCount = Sessions.Count;
			//int MaxSessionCount = Convert.ToInt32( System.Configuration.ConfigurationSettings.AppSettings["MaxSessions"]);
			//Adding Session To servers Session Collection
			int TempSessionID = this.Sessions.Add(NewSession);
			//Setting Session ID 
			NewSession.SessionID = TempSessionID;
			//Setting Sessions Connection String
			NewSession.ConnectionString = this.ServerResources.Connection.ConnectionString;
			//Setting Token
			string TempToken = CreateToken(UserName,NewSession);
			NewSession.SetToken(TempToken);//Should Get the value

			return true;
		}


		// The Login Function as called by the Server Shell
		internal Session LogIn(string UserName, string Password)
		{
			try
			{
				// Checks if there is an already open session that requiers to be loggedd off
				TimeOutCheck();
				// Creates a new session
				Session NewSession = new Session();
			
				if (this.RegisterSession(NewSession,UserName,Password))
				{
					//Filling the user the 
					NewSession.SetLgoinData(UserName,Password);
					NewSession.DataRow = AddSessionLoginData(NewSession);
					return NewSession;
				}
				return null;
			}
			catch(Exception ex)
			{
				EventLog.WriteEntry("ERP Server",ex.Message,System.Diagnostics.EventLogEntryType.FailureAudit);
				return null;
			}
		}


		protected Data.dsServer.tSessionRow AddSessionLoginData(Session NewSession)
		{
			//Update Server Dataset
			Data.dsServer.tSessionRow SessionRow = dsServerData.tSession.NewtSessionRow();
			SessionRow.LoginTime = DateTime.Now;
			SessionRow.UserID = NewSession.UserId;
			SessionRow.UserName  = NewSession.UserName;
			SessionRow.Token = NewSession.Token;
			SessionRow.Status = "A";
			SessionRow.ActiveObjects = 0;
			dsServerData.tSession.AddtSessionRow(SessionRow);
			return SessionRow;
		}


		// Logs off a certain session, removing it from the server collection and releasing its resources
		internal void LogOff(Session ChildSession)
		{
			// Remove the session form the session collection
			Sessions.Remove(ChildSession);
			//Sets the session status in the server dataset to logged off
			ChildSession.DataRow.Status = "O";
			//r
			//ChildSession.Dispose();
			GC.Collect();
		}


		// creates a session token
		public string CreateToken(string user, Session NewSession)
		{
			TSNLogin.TSN_encryptor Encryptor = new TSNLogin.TSN_encryptor();
			string ServerMachineID = System.Environment.MachineName;
			string UserId = user + this.Sessions.Count.ToString() + NewSession.GetHashCode().ToString();
			string LoginTime = System.DateTime.Now.ToUniversalTime().ToString();
			string SessionId = NewSession.SessionID.ToString().PadLeft(6,'0');
			return SessionId+Encryptor.encrypt(ServerMachineID,UserId,LoginTime);
		}
		

		//r[AutoComplete(true)]
			// returns a certain session , given its token
		public Session GetSession(string Token)
		{
			// try to hit the using Session ID 
			int SessionId = Convert.ToInt32(Token.Substring(0,6));
			if (Sessions.Count > SessionId)
				if (Sessions[SessionId].Token == Token)
					return Sessions[SessionId];
			//.......................................//
			Session TempSession = this.Sessions.find(Token);
			if (TempSession == null)
				throw new Exception("TSN ERP Server:Session Expired");
			return TempSession;
		}
		# endregion
		#region Server Data
		internal System.Data.DataSet GetServerData()
		{
			return dsServerData;
		}
		#endregion
		

		internal ResourcePool ServerResources
		{
			get
			{
				try
				{
					//if(MyResourcePool.Connection.State==System.Data.ConnectionState.Closed)
					MyResourcePool.Connection.Close();
					MyResourcePool.Connection.Open();

					return this.MyResourcePool;
				}
				catch
				{
					MyResourcePool.Connection.Close();
					ResourcePool myresbool=new ResourcePool();
					return myresbool;

				}
			}
		}
	}
}
