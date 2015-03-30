using System;
using System.Collections;

namespace TSN.ERP.Reporting.CrysatlReports
{
	/// <summary>
	/// Summary description for Parameter.
	/// </summary>
	/// 

	[Serializable]
	public class Parameter
	{
		// Crystal Paramter TYpes for GUI checks
		public int ParmType = 0 ;
		// Source Tabble name to genrate selection list, if -1 then manual i.e : no selection
		public string Source = "0";
		// Is the parameter a General Item
		public bool General;
		public int parameterID;
		public string promptText = "";
		public string ParmName = "";
		// I ncase of manged parameters only!
		public  ArrayList EntityAccessRights  = new ArrayList();
		public object currentValue;
		public Parameter()
		{

		}

	}
}
