using System;

namespace TSN.ERP.Reporting.CrysatlReports
{
	/// <summary>
	/// Summary description for ReportsConnector.
	/// </summary>
	public class ReportsConnector
	{
		public string _dbName;
		public string _serverName;
		public string _userID;
		public string _passWord;


		public ReportsConnector()
		{
			//
			// TODO: Add constructor logic here
			//	oCRTable	error: identifier 'oCRTable' out of scope	

		}
		public static bool ApplyConnectionInfo(CrystalDecisions.CrystalReports.Engine.ReportDocument _oRpt, string dbaseName, string serverName)
		{						
			foreach(CrystalDecisions.CrystalReports.Engine.Table oCRTable in _oRpt.Database.Tables)
			{
				oCRTable.LogOnInfo.ConnectionInfo.DatabaseName = dbaseName;
				oCRTable.LogOnInfo.ConnectionInfo.ServerName = serverName;
				//oCRTable.LogOnInfo.ConnectionInfo.IntegratedSecurity  = true;
				oCRTable.ApplyLogOnInfo(oCRTable.LogOnInfo);	
			}
			return true;
		}

		
	}
}
