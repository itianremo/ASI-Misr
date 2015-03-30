using System;
using System.Data.OleDb;
using TSN.ERP;
using TSN.ERP.Security;
using System.Reflection;
//rusing System.EnterpriseServices;
using System.Diagnostics;
using System.Data;
namespace TSN.ERP.Engine
{
	/// <summary>
	/// Summary description for Session.
	/// </summary>
	/// 
	//r[ObjectPooling(Enabled=true, MinPoolSize=0, MaxPoolSize=10000, CreationTimeout=10000)]
	public class Session //r:ServicedComponent 
	{
		#region Class Members

		private string _Token;
		private string _UserString;
		private bool _Authenticated = false;
		protected string _ConnectionString; 
		//private Engine.Collections.BussinesObjectCollection  _BussinesObjects;
		private ERPUserSecurityInfo _UserSecurityInfo;
		private ERPError _LastError = new ERPError(0,"0",0,new Exception("No Error"));
		private bool _HasNewErrors;
		private Data.dsServer.tSessionRow _DataRow;
		private int _ContactID =-1;
		private int _SessionID;
		private TSN.ERP.Security.SecurityManagement  MySecurityManager; 
		private DataSet _LastDataSet;

		#endregion 

		#region Constructor

		public Session():base()
		{
			if (Server.ERPServer == null)
				new Server();
			//this._BussinesObjects = new TSN.ERP.Engine.Collections.BussinesObjectCollection(this);
			this._UserSecurityInfo = new ERPUserSecurityInfo();
			MySecurityManager = new SecurityManagement();

		}
		#endregion 

		#region SetLgoinData
		/// <summary>
		/// Sets the login Data for the session , this fucntions loads the user data into the session 
		/// being intiated
		/// </summary>
		/// <param name="UserName"></param>
		/// <param name="Password"></param>
		internal void SetLgoinData(string UserName,string Password)
		{
			this._UserString = UserName;
			this._Authenticated = true;
			if (_UserSecurityInfo.SetConnectionString(ConnectionString))
				this.UserSecurityInfo.GetUserDetails(UserName);
			MySecurityManager.ConnectionString = ConnectionString;
			_ContactID = MySecurityManager.GetUserContactID(UserSecurityInfo.UserID);

		}


		#endregion

		#region SetToken
		/// <summary>
		/// Sets the token for Session
		/// </summary>
		/// <param name="SessionToken"></param>
		internal void SetToken(string SessionToken)
		{
			this._Token = SessionToken;
		}
		#endregion 

		#region Dispose
		//r
//		protected override void Dispose(bool disposing)
//		{
//			_UserSecurityInfo.Dispose();
//			_DataRow.Delete();
//			base.Dispose(true);
//		}


		#endregion 
				
		#region LogOff
		/// <summary>
		/// Logs of this session , by emptying the user data and telling the server to log the session off , by removing 
		/// it from the server session collection
		/// </summary>
		public void LogOff()
		{
			this._UserString = null;
			this._Authenticated = false;
			this._UserSecurityInfo.Dispose();
			this.MySecurityManager.Dispose();
			this._UserSecurityInfo = new ERPUserSecurityInfo();
			this.MySecurityManager = new SecurityManagement();
			_ContactID = -1;
			Server.ERPServer.LogOff(this);
		}
		

		#endregion 
	
		#region AddBussinessObject

		/// <summary>
		/// Unused funtion Should be deleted
		/// </summary>
		/// <param name="ChildObject"></param>
		/// <returns></returns>
		//r[AutoComplete(true)]
		internal int AddBussinessObject(Engine.BussinesObject ChildObject)
		{
			return 1;
		}

		#endregion 

		#region GetUserRuleEntities

		/// <summary>
		/// Loads the set of Rule Entites for the given user
		/// </summary>
		/// <param name="ruleID"></param>
		/// <returns></returns>
		public DataSet GetUserRuleEntities(int ruleID)
		{
			// Accessing the security manger to Load the user Rule entites
			return MySecurityManager.GetUserRuleEntities(UserId,ruleID);

		}

		#endregion 

		#region Get Instance
		/// <summary>
		/// an alternative to the Invoke object type
		/// </summary>
		/// <param name="BussinessObjectType"></param>
		/// <returns></returns>
		public BussinesObject GetInstance(Type BussinessObjectType)
		{
			return InvokeObject(BussinessObjectType);
		}
		/// <summary>
		/// this fucntion allows the user to load an bussines opbject direclty into the session , using its Type
		/// </summary>
		/// <param name="BussinessObjectType"></param>
		/// <returns></returns>
		private BussinesObject InvokeObject(Type BussinessObjectType)
		{
			Object[] args = null;
			object TempObject = BussinessObjectType.InvokeMember(null, 
				BindingFlags.DeclaredOnly | 
				BindingFlags.Public | BindingFlags.NonPublic | 
				BindingFlags.Instance | BindingFlags.CreateInstance, null, null, args);
			BussinesObject TempBussinessObject = (BussinesObject) TempObject;
			TempBussinessObject.Initiate(this);
			return TempBussinessObject;
		}
		/// <summary>
		/// this fucntion allows the user to load an bussines opbject direclty into the session , using its name and Assembly name
		/// </summary>
		/// <param name="TypeName"></param>
		/// <param name="AssemblyName"></param>
		/// <returns></returns>
		public BussinesObject GetInstance(string TypeName, string AssemblyName)
		{
			System.Reflection.Assembly TempAsm = LoadAssembly(AssemblyName);
			Type TempType = TempAsm.GetType(TypeName);
			return this.GetInstance(TempType);
		}
		/// <summary>
		/// Loads a .net assembly given its name
		/// </summary>
		/// <param name="AssemblyName"></param>
		/// <returns></returns>
		internal System.Reflection.Assembly LoadAssembly(string AssemblyName)
		{
			System.Reflection.Assembly TempAsm = System.Reflection.Assembly.LoadWithPartialName(AssemblyName);
		
			return TempAsm;
		}
		/// <summary>
		/// this fucntion is called by COM+ to determine wether the object should be pooled, we override it and return true 
		/// to indicate that the seesion can be pooled all time
		/// </summary>
		/// <returns></returns>
		
		//r
//		protected override bool CanBePooled() 
//		{
//			return true;
//		}
		#endregion

		#region Error Handling
		/// <summary>
		/// Return a description for the last exception stored in the session
		/// </summary>
		public string LastException
		{
			get
			{
				string retstring = _LastError.ErrorDescription +":"+ _LastError.SourceException.Source + ":" +_LastError.SourceException.Message; 
				return retstring;
			}
		}
		/// <summary>
		/// Return a description for the last security error stored in the session
		/// </summary>
		public string LastSecurityError
		{
			get
			{
				return UserSecurityInfo.Error;
			}

		}
		/// <summary>
		/// Checks if a new error was stored in the session
		/// </summary>
		/// <returns></returns>
		public bool HasNewErrors()
		{
			bool temp = _HasNewErrors;
			_HasNewErrors = false;
			return temp;
		}
		/// <summary>
		/// sets an error to be retrieved later by user
		/// </summary>
		/// <param name="NewError">an instance the ERP error</param>
		public void SetError(ERPError NewError)
		{
			this._LastError = NewError;
			_HasNewErrors = true;
		}
		#endregion

		#region ChangePaassword
		public bool ChangePaassword(string OldPassword,string NewPassword)
		{
			return UserSecurityInfo.ChangePassword(OldPassword,NewPassword);
		}
		#endregion 
		
		#region Identification Peoperties

		# region Connection Handleing
		internal string ConnectionString
		{
			get
			{
				return this._ConnectionString;
			}
			set
			{
				this._ConnectionString = value;
			}
		}
		#endregion

		public string Token
		{
			get
			{
				return _Token;
			}
		}
		public string UserName
		{
			get
			{
				return this._UserString;
			}
		}
		public int UserId
		{
			get
			{
				return this.UserSecurityInfo.UserID;
			}
		}
		public ERPUserSecurityInfo  UserSecurityInfo
		{
			get
			{
				return this._UserSecurityInfo;
			}
		}
		
		public bool IsAdmin
		{
			get
			{
				return this.UserSecurityInfo.Administrator;
			}
		}

		internal Data.dsServer.tSessionRow DataRow
		{
			get
			{
				return _DataRow;
			}
			set
			{
				_DataRow = value;
			}
		}
		internal int SessionID
		{
			get
			{
				return _SessionID;
			}
			set
			{
				_SessionID = value;
			}
		}


		#region ContactId
		public int ContactId
		{
			get
			{
				return _ContactID;
			}
		}
		#endregion 


	    public bool Authenticated
		{
			get
			{
				return this._Authenticated;
			}
		}


		public DataSet LastDataSet
		{
			get
			{
				return _LastDataSet;
			}
			set
			{
				_LastDataSet = value;
			}
		}


		#endregion


	}
}
