using System;
using System.Data;
using TSN.ERP.Engine;
using TSN.ERP.SharedComponents;
using TSN.ERP.SharedComponents.Data;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Xml.Serialization;
namespace TSN.ERP.Reporting.CrysatlReports
{
	/// <summary>
	/// Summary description for CrysatlReportsManager.
	/// </summary>
	public class CrysatlReportsManager:BussinesObject 
	{
		private Reporting.Data.ReportCallsData RCalls = new TSN.ERP.Reporting.Data.ReportCallsData();
		private Reporting.Data.ReportParamtersData RParms = new TSN.ERP.Reporting.Data.ReportParamtersData();
		private Reporting.Data.ReportsInfoData RInfo = new TSN.ERP.Reporting.Data.ReportsInfoData();
		private FilesDataClass FilesData = new FilesDataClass();
		private TSN.ERP.Reporting.ReportsManager Rmanger = new ReportsManager();

		private Data.dsReportCalls dsReportCalls1 = new TSN.ERP.Reporting.Data.dsReportCalls();
		private Data.dsReportsInfo dsReportsInfo1 = new TSN.ERP.Reporting.Data.dsReportsInfo();
		private Data.dsRepParms dsRepParms1 = new TSN.ERP.Reporting.Data.dsRepParms();
		private ReflectionSupport RefSupport = new ReflectionSupport();
		//private string ReportsStreamerFolder  = @"D:\ERP Workspace\";
		
		public CrysatlReportsManager()
		{
			DataComponents.Add(RCalls);
			DataComponents.Add(RParms);
			DataComponents.Add(RInfo);
			DataComponents.Add(FilesData);

		}
		protected override void ObjectIntiated()
		{
			
			RefSupport.JoinSession(ActiveSession.Token);
			Rmanger.JoinSession(ActiveSession.Token);
			base.ObjectIntiated ();
		}

		#region LoadReport

		public byte[] LoadReport(int ReportFileID, object[] Parameters)
		{
			if (!CheckUserAccess((int)TSN.ERP.Security.Rules.GeneralRules.ListReports))return null;
			
			
			ReportDocument  CurrentReportDocument = LoadReportDocumnet(ReportFileID);
			dsReportsInfo1.Merge( RInfo.List(ReportFileID));
			// Methods ( push model )
			if (dsReportsInfo1.REP_ReportInfo[0].ReportTypeID == 1)
			{
				dsReportCalls1.Clear();
				dsReportCalls1.Merge(RCalls.List("FileID = " +ReportFileID.ToString()));
				DataSet dsTemp = new DataSet(); 
				dsTemp.EnforceConstraints = false;
				foreach(Data.dsReportCalls.REP_CallsRow CallRow in dsReportCalls1.REP_Calls)
				{
					dsTemp.Merge(ExcuteReportCall(CallRow));
				}
				CurrentReportDocument.SetDataSource(dsTemp);
			}
				// Database ( pull model )
			else if (dsReportsInfo1.REP_ReportInfo[0].ReportTypeID == 2)
			{
				string dbasename = RInfo.Connection.Database;
				string dbserver = RInfo.Connection.DataSource;

				//Check user Access Right fro this report
				if (!Rmanger.CheckReportAccess( ReportFileID,  Parameters)) return null;
				
				//Change Report Connection
				ReportsConnector.ApplyConnectionInfo(CurrentReportDocument,dbasename,dbserver);
				
				//Fill Report
				ReportInfo RI = Rmanger.LoadReportRunInfo(ReportFileID);
				int Length = Parameters.Length; 
				for(int i = 0; i< Length ; i++) 
				{
					Parameter P = (Parameter)RI.ReportParameters[i];
					CurrentReportDocument.SetParameterValue(P.ParmName,Parameters[i]);
				}
			}
			System.IO.MemoryStream ms = (System.IO.MemoryStream) CurrentReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
			return ms.ToArray();
		}
		
		
		
		public byte[] LoadReport(int ReportFileID, DataSet dsParameters )
		{
			
			if (!CheckUserAccess((int)TSN.ERP.Security.Rules.GeneralRules.ListReports))return null;
			ReportDocument  CurrentReportDocument = LoadReportDocumnet(ReportFileID);
			dsReportCalls1.Clear();
			dsReportCalls1.Merge(RCalls.List("FileID = " +ReportFileID.ToString()));
			DataSet dsTemp = new DataSet(); 
			dsTemp.EnforceConstraints = false;

			for ( int i = 0 ; i < dsReportCalls1.REP_Calls.Rows.Count ; i++ )
			{
				if( dsParameters.Tables.Contains( "T" + dsReportCalls1.REP_Calls[ i ].RepCallIId.ToString() ) )
				{
					dsTemp.Merge(ExcuteReportCall( (Data.dsReportCalls.REP_CallsRow ) dsReportCalls1.REP_Calls.Rows[ i ] , dsParameters.Tables[ "T" + dsReportCalls1.REP_Calls[ i ].RepCallIId.ToString() ] ));
				}
				else
					dsTemp.Merge(ExcuteReportCall( (Data.dsReportCalls.REP_CallsRow ) dsReportCalls1.REP_Calls.Rows[ i ] ));
			}

			CurrentReportDocument.SetDataSource(dsTemp);
			CurrentReportDocument.Refresh();
			System.IO.MemoryStream ms = (System.IO.MemoryStream) CurrentReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
			return ms.ToArray();
		}
	

		#endregion 

		#region Call Execution
		private DataSet ExcuteReportCall( Data.dsReportCalls.REP_CallsRow CallRow )
		{
			MethodCall CurrentCall = new MethodCall();
			CurrentCall.AssemblyName = CallRow.cAssemblyName;
			CurrentCall.MethodName = CallRow.RCMethodName;
			CurrentCall.TypeName = CallRow.RCTypeName;
			Object[] arr = new object[ 0 ];
			CurrentCall.Parameters = arr;
			object tempObj = RefSupport.ExecuteMethod(CurrentCall);
			return (DataSet)tempObj;
		}

		private DataSet ExcuteReportCall( Data.dsReportCalls.REP_CallsRow CallRow , DataTable dtCallParams )
		{
			MethodCall CurrentCall   = new MethodCall();
			CurrentCall.AssemblyName = CallRow.cAssemblyName;
			CurrentCall.MethodName   = CallRow.RCMethodName;
			CurrentCall.TypeName     = CallRow.RCTypeName;
			object[] tempClPrm = new object[ dtCallParams.Rows.Count ];
			for ( int i = 0 ; i < dtCallParams.Rows.Count ; i++ )
			{
				tempClPrm[ i ] = dtCallParams.Rows[ i ][ "ArgValue" ] ;
			}
			CurrentCall.Parameters = tempClPrm ;
			object tempObj		   = RefSupport.ExecuteMethod(CurrentCall);
			return (DataSet)tempObj;
		}


		private object[] GetCallParms(int CallID)
		{
			Data.dsRepParms dstempParms =new TSN.ERP.Reporting.Data.dsRepParms();
			dstempParms.Merge(RParms.List("RepCallIId  = " + CallID));
			object[] tempObjects = new object[dstempParms.REP_CallParms.Rows.Count];
			int i = 0;
			foreach(Data.dsRepParms.REP_CallParmsRow TempRow in dstempParms.REP_CallParms)
			{
				if (TempRow.RCPFixed.ToString() == "1")
				{
					tempObjects[i] = dstempParms.REP_CallParms[i].RCPVal;
				}
				else
				{
					throw new Exception("Not Devloped yet");
				}
				i++;
			}
			return tempObjects;
		}
		#endregion

		public int SetReportInfo(int ReportID, ReportInfo RepInfo)
		{
			if (!CheckUserAccess((int)TSN.ERP.Security.Rules.GeneralRules.AddReport))return -1;
			XmlSerializer Xser = new XmlSerializer(typeof(TSN.ERP.Reporting.CrysatlReports.ReportInfo));
			TextWriter writer = new StreamWriter("TEReportInfo.xml");
			Xser.Serialize(writer,RepInfo);
			writer.Close();
			TextReader Reader = new  StreamReader("TEReportInfo.xml");
			string temp = Reader.ReadToEnd();
			return RInfo.SetRepInfo(ReportID,temp);
		}

		public ReportInfo GetReportDefaultInfo(int ReportID)
		{
			if (!(CheckUserAccess((int)TSN.ERP.Security.Rules.GeneralRules.ListReports)||CheckUserAccess((int)TSN.ERP.Security.Rules.GeneralRules.AddReport)))return null;
			ReportInfo CurrenReportInfo = new ReportInfo();
			ReportDocument  CurrentReportDocument = LoadReportDocumnet(ReportID);
			CurrenReportInfo.AdminstratorOnly = true;
			//foreach(ParameterField PF in CurrentReportDocument.ParameterFields)
			//foreach(ParameterField PF in CurrentReportDocument.ParameterFields)
			{
				Parameter tempparm = new Parameter();
//				tempparm.ParmType = (int)PF.ParameterValueType;
//				tempparm.promptText = PF.PromptText;
//				tempparm.ParmName = PF.Name;
				CurrenReportInfo.ReportParameters.Add(tempparm);
			}
			return CurrenReportInfo;
		}
		protected ReportDocument LoadReportDocumnet(int ReportFileID)
		{
			if (!CheckUserAccess((int)TSN.ERP.Security.Rules.GeneralRules.ListReports))return null;
			ReportDocument TempRepDoc = new ReportDocument();
			string ReportLocation = "TempReport.rpt";
			ReportDocument CurrentReportDocument = new ReportDocument();
			byte[] TempArray = FilesData.LoadFileBody(ReportFileID);
			FileStream FS = File.Create(ReportLocation);
			FS.Write(TempArray,0,TempArray.Length );
			FS.Close();
			TempRepDoc.Load(ReportLocation);
			return TempRepDoc;
		}
		public string[] GetReportDataSource(int ReportID)
		{
			if (!CheckUserAccess((int)TSN.ERP.Security.Rules.GeneralRules.ListReports))return null;
			ReportDocument RP = LoadReportDocumnet(ReportID);
			string[] retString = new string[RP.Database.Tables.Count];
			int i =0;
			foreach(Table RPDataTable in RP.Database.Tables)
			{
				retString[i] = RPDataTable.Name;
				i++;
			}
			return retString;
		}
	}
}
