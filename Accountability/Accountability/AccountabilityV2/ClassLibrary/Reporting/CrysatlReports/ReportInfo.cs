using System;
using System.Collections;
namespace TSN.ERP.Reporting.CrysatlReports
{
	/// <summary>
	/// use this class to store all data needed to run a crystal report in pull model
	/// </summary>
	/// 
	[Serializable]
	[System.Xml.Serialization.XmlInclude(typeof(Parameter))]
	public class ReportInfo
	{
		public bool AdminstratorOnly = false;
		//To hold the Ids of geenral access rights
		public ArrayList GeneralAccessRules = new ArrayList();
		public ArrayList ReportParameters = new ArrayList();
		public ReportInfo()
		{
			//
			// TODO: Add constructor logic here
			//
		}

	}
}
