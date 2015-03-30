using System;

namespace TSN.ERP.Reporting
{
	/// <summary>
	/// Summary description for MethodCall.
	/// </summary>
	/// 
	
	[Serializable]
	public class MethodCall
	{
		string _AssemblyName;
		string _TypeName;
		string _MethodName;
		object[] _Parameters;

		public MethodCall()
		{

		}
		public string AssemblyName
		{
			get
			{
				return _AssemblyName;
			}
			set
			{
				_AssemblyName = value;
			}
		}
		public string TypeName
		{
			get
			{
				return _TypeName;
			}
			set
			{
				_TypeName = value;
			}
		}
		public string MethodName
		{
			get
			{
				return _MethodName;
			}
			set
			{
				_MethodName = value;
			}
		}
		public object[] Parameters
		{
			get
			{
				return _Parameters;
			}
			set
			{
				_Parameters = value;
			}
		}
	}
}
