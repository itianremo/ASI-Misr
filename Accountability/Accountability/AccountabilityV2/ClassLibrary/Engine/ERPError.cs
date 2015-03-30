using System;

namespace TSN.ERP.Engine
{
	/// <summary>
	/// Summary description for Error.
	/// </summary>
	/// 
	[Serializable]
	public class ERPError
{
		Exception _SourceException;
		string _ErrorDescription;
		int _ErrorID;
		int _ErrorSecurotyRuleID;
		public enum ErrorTypes{Undefiend = 0,Security = 10, Database = 20 }
		public ERPError(int ID,string Description, int SecurotyRuleID, Exception Source)
		{
			_ErrorID =ID ;
			_ErrorDescription = Description;
			_ErrorSecurotyRuleID = SecurotyRuleID;
			_SourceException = Source ;
		}
		public Exception SourceException
		{
			get
			{
				return _SourceException;
			}
		}
		public string ErrorDescription
		{
			get
			{
				return _ErrorDescription;
			}
		}
		public int ErrorID
		{
			get
			{
				return _ErrorID;
			}
		}
		public int ErrorSecurotyRuleID
		{
			get
			{
				return _ErrorSecurotyRuleID;
			}

		}
	}
}
