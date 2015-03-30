using System;
//////using System.EnterpriseServices;
using System.Data.OleDb;
using TSN.ERP;
using TSN.ERP.Engine;
namespace TSN.ERP.Engine
{
	/// <summary>
	/// Summary description for BussinesObject.
	/// </summary>
	/// 

//r	[JustInTimeActivation(true), ObjectPooling(false)]
	public class BussinesObject //r :ServicedComponent 
	{
		protected Collections.BussinesComponentsCollection _DataComponentsCollection ;
		protected string _ConnectionString;
		protected Session MySession ;
		protected OleDbConnection conn;
		public BussinesObject()//:base()
		{
			_DataComponentsCollection = new TSN.ERP.Engine.Collections.BussinesComponentsCollection(this);
		}
		/// <summary>
		/// This fucntion is called by the ERP Server after this class joins the session
		/// mianly this functions intiates the data components added in the busssines object 
		/// data components collection, override this fucntion to excexute any code during the 
		/// object intiation, typicaly intiating another bussines object.
		/// </summary>
		protected  virtual void ObjectIntiated()
		{
			int ObjectCount = this.DataComponents.Count;
			for (int i =0; i < ObjectCount;i++ )
			{
				// Intaite the connection string for Data Component
				DataComponents[i].SetConnection(ConnectionString);
				//Set the Sessio for Data component
				DataComponents[i].SetSession(ActiveSession);
			}
		}
		//r
//		protected override void Dispose(bool disposing)
//		{
//			try
//			{
//				int ObjectCount = this.DataComponents.Count;
//				for (int i =0; i < ObjectCount;i++ )
//				{
//					DataComponents[i].Dispose();
//				}
//				DataComponents.Dispose();
//			}
//			catch (Exception ex )
//			{
//				
//			}
//			
//			base.Dispose (disposing);
//		}

		internal bool Initiate(Session CurrentSession)
		{
			this.MySession = CurrentSession;
			this.ConnectionString = this.MySession.ConnectionString;
	
			this.ObjectIntiated();
			return true;
		}

		/// <summary>
		/// this function must be called by the bussines object users beforew
		/// executing any call, this lets the Bussines Object Joins a certain session
		/// </summary>
		/// <param name="Token">The Session Token</param>
		/// <returns></returns>
		public bool JoinSession(string Token)
		{
			this.MySession = Server.ERPServer.GetSession(Token);
			if (this.MySession == null)
				////throw new Exception("Session not Found");
				return false;
			return this.Initiate(this.MySession);
		}
		/// <summary>
		/// Protected property that allows an inherted bussines object to access the 
		/// current session, to retrieve user information.
		/// </summary>
		protected Session ActiveSession{get{return this.MySession;}}
		# region Connection Mangment
		
		/// <summary>
		/// Protected property that carries the Database Connection
		/// string currently used by the server
		/// </summary>
		protected string ConnectionString
		{
			get
			{
				return _ConnectionString;
			}
			set
			{
				_ConnectionString = value;
			}
		}
		#endregion
		protected Collections.BussinesComponentsCollection  DataComponents
		{
			get
			{
				return this._DataComponentsCollection;
			}
		}

		/// <summary>
		/// Use this fucntion to check the current user access right for a certain rule and a certain Entity ID
		/// </summary>
		/// <param name="RuleId">The Rule ID</param>
		/// <param name="EntityID">Entity ID, which is the primary Key for the entity  recored</param>
		/// <returns></returns>
		public bool CheckUserAccess(int RuleId,string EntityID)
		{
			ActiveSession.UserSecurityInfo.SetConnectionString(ConnectionString);
			return ActiveSession.UserSecurityInfo.CheckUserAccessRight(this.ActiveSession.UserSecurityInfo.UserID,RuleId,EntityID);
		}
		/// <summary>
		/// Use this fucntion to check the current user access right for a general rule
		/// </summary>
		/// <param name="RuleId">The Rule ID</param>
		/// <returns></returns>
		public bool CheckUserAccess(int RuleId)
		{
			return this.CheckUserAccess(RuleId,null);
		}
		/// <summary>
		/// use this fucntion to raise a access denied error , the error is stored in the session, as an error
		/// and it could be retrieved by the user later
		/// </summary>
		/// <param name="RuleID"></param>
		protected void SendAccessDeniedMessage(int RuleID)
		{
			string RuleName = RuleID.ToString();
			ActiveSession.SetError(new ERPError(1,"Access Denied, User has no access to " + RuleName,RuleID,null));
		}
	}
}
