using System;
//using System.EnterpriseServices;
using System.Data;
using TSN.ERP.Engine;
using TSN.ERP.SharedComponents;
using TSN.ERP.SharedComponents.Data;
using System.Reflection;
using System.Xml.Serialization;
using System.IO;
namespace TSN.ERP.Reporting
{
	/// <summary>
	/// Summary description for ReportsManager.
	/// </summary>
	/// 
	public class ReportsManager:BussinesObject 
	{ 
		protected Data.ReportsInfoData RepInfo =new TSN.ERP.Reporting.Data.ReportsInfoData();
		protected Data.ReportCallsData RepCallls = new TSN.ERP.Reporting.Data.ReportCallsData();
		protected Data.ReportParamtersData RepParms = new TSN.ERP.Reporting.Data.ReportParamtersData();
		protected Data.EntitiesData EntitesData =new TSN.ERP.Reporting.Data.EntitiesData();
		protected Data.RegisteredAssembliesData RegAssembData = new TSN.ERP.Reporting.Data.RegisteredAssembliesData();
		protected Data.dsRegisteredAssemblies dsAssemblies = new TSN.ERP.Reporting.Data.dsRegisteredAssemblies();
		protected Data.dsReportsInfo dsRepinfo = new TSN.ERP.Reporting.Data.dsReportsInfo();
		protected Data.dsReportCalls dsRepCalls = new TSN.ERP.Reporting.Data.dsReportCalls();
		protected Data.dsRepParms dsRepParms = new TSN.ERP.Reporting.Data.dsRepParms();
		protected Data.TableInfoData TableInf = new TSN.ERP.Reporting.Data.TableInfoData();

		public ReportsManager()
		{
			DataComponents.Add(RepInfo);
			DataComponents.Add(RepCallls);
			DataComponents.Add(RepParms);
			DataComponents.Add(RegAssembData);
			DataComponents.Add(EntitesData);
			DataComponents.Add(TableInf);

			dsRepCalls.EnforceConstraints = false;
			dsRepinfo.EnforceConstraints = false;
			dsRepParms.EnforceConstraints = false;
		}
		#region ReportsInfo
		public DataSet ListReportsInfo()
		{
			if (!CheckUserAccess((int)TSN.ERP.Security.Rules.GeneralRules.ListReports))return null;
			return RepInfo.List();
		}
		public DataSet ListReportsInfo(string Filter)
		{
			if (!CheckUserAccess((int)TSN.ERP.Security.Rules.GeneralRules.ListReports))return null;
			return RepInfo.List(Filter);
		}
		public int AddReportInfo(DataSet NewReports)
		{
			if (!CheckUserAccess((int)TSN.ERP.Security.Rules.GeneralRules.AddReport))return -1;
			return RepInfo.Add(NewReports);
		}
		public int DeleteReportInfo(DataSet DeletedReports)
		{
			////System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			return RepInfo.Delete(DeletedReports);
		}
		public DataSet LatestReportsDataSet()
		{
			if (!CheckUserAccess((int)TSN.ERP.Security.Rules.GeneralRules.AddReport))return null;
			return RepInfo.ComponentDataSet;
		}
		
		#endregion
		#region Calls Execution
		public DataSet ListRegisterdAssemblies()
		{
			if (!CheckUserAccess((int)TSN.ERP.Security.Rules.GeneralRules.ListReports))return null;
			return RegAssembData.List();
		}

		public DataSet ListAssemblyCalls(string  AssemblyName)
		{
			if (!CheckUserAccess((int)TSN.ERP.Security.Rules.GeneralRules.ListReports))return null;
			dsRepCalls.Clear();
			Type[] aTypes;
			System.Reflection.Assembly TempAsm = System.Reflection.Assembly.LoadWithPartialName(AssemblyName);
			aTypes = TempAsm.GetTypes();
			// Loading Assembly Types
			foreach(Type TempType in aTypes )
			{
				// Loading Type Methods
				if (!ReflectionSupport.CheckInheritance(TempType,typeof(Engine.BussinesObject)))
					continue;
				MethodInfo[] MInfo;
				MInfo =  TempType.GetMethods();
				
				foreach(MethodInfo TempMInf in MInfo)
				{
					if (TempMInf.IsPublic && ReflectionSupport.CheckMethodERPType(TempMInf,ERPMethodType.List))
					{
//						if (TempMInf.GetParameters().GetUpperBound(0) > 0)
//							continue;
						Data.dsReportCalls.REP_CallsRow  RepCallsRow = dsRepCalls.REP_Calls.NewREP_CallsRow();
						RepCallsRow.RCMethodName = TempMInf.Name;
						RepCallsRow.RCTypeName = TempType.FullName;
						RepCallsRow.cAssemblyName = AssemblyName;
						RepCallsRow.RCArgs = ReflectionSupport.GetArgummentsString(TempMInf);
						dsRepCalls.REP_Calls.AddREP_CallsRow(RepCallsRow);
					}
				}
			}
			return dsRepCalls;
		}
		public DataSet ListCallParamaters(string AssemblyName, string TypeName ,string CallName,string CallArgs)
		{
			if (!CheckUserAccess((int)TSN.ERP.Security.Rules.GeneralRules.ListReports))return null;
			dsRepParms.Clear();
			System.Reflection.Assembly TempAsm = System.Reflection.Assembly.LoadWithPartialName(AssemblyName);
			Type TempType = TempAsm.GetType(TypeName);
			MethodInfo TempMInf = TempType.GetMethod(CallName);
			ParameterInfo[] PInfo = TempMInf.GetParameters();
			foreach(ParameterInfo TempPInf in PInfo)
			{
				Data.dsRepParms.REP_CallParmsRow TempRow = dsRepParms.REP_CallParms.NewREP_CallParmsRow();
				TempRow.RCParmName = TempPInf.Name;

			}
			return dsRepParms;
		}

		#region ListReportParameters

		public DataSet ListReportParameters( int ReportFileID )
		{
			if (!CheckUserAccess((int)TSN.ERP.Security.Rules.GeneralRules.ListReports))return null;
			DataSet dsAllCallsArguments = new DataSet();
			//dsRepCalls.Clear();
			Data.dsReportCalls dsRepCalls = new TSN.ERP.Reporting.Data.dsReportCalls();
			dsRepCalls.Merge(RepCallls.List("FileID = " + ReportFileID.ToString()));
			
			//loop in calls
			foreach( Data.dsReportCalls.REP_CallsRow CallRow in dsRepCalls.REP_Calls )
			{
				Data.dsRepArguments dsRepArg = new TSN.ERP.Reporting.Data.dsRepArguments();
				System.Reflection.Assembly TempAsm = System.Reflection.Assembly.LoadWithPartialName( CallRow.cAssemblyName );
				Type TempType = TempAsm.GetType( CallRow.RCTypeName );
				MethodInfo TempMInf = TempType.GetMethod( CallRow.RCMethodName );
				string argString = ReflectionSupport.GetArgummentsString( TempMInf );

				if( argString != "" )
				{
					string[] allArg = argString.Split( ';' );

					//loop in arguments
					for ( int i = 0 ; i < allArg.Length ; i++ )
					{
						Data.dsRepArguments.RepArgumentsRow row = dsRepArg.RepArguments.NewRepArgumentsRow();
						row.TableName = allArg[ i ] ;
						dsRepArg.RepArguments.AddRepArgumentsRow( row );
						//row.IsEntity;
					}
				
					DataTable dsTable = dsRepArg.Tables[ 0 ];
					dsTable.TableName = "T" +  CallRow.RepCallIId.ToString();
					dsRepArg.Tables.Remove ( dsTable );
					dsAllCallsArguments.Tables.Add( dsTable );
				}
			
			}
			return dsAllCallsArguments;
		}

		#endregion

		#endregion
		#region Misc
		
		public DataSet ListEntities()
		{
			if (!CheckUserAccess((int)TSN.ERP.Security.Rules.GeneralRules.ListReports))return null;
			return EntitesData.List();
		}
		public DataSet ListTableInfo()
		{
			if (!CheckUserAccess((int)TSN.ERP.Security.Rules.GeneralRules.ListReports))return null;
			return TableInf.List();
		}

		public int DeleteReport(DataSet DeletedReport)
		{
			return RepInfo.Delete(DeletedReport);
		}
		public int UpdateReportInfo(DataSet ModifedReports)
		{
			if (!CheckUserAccess((int)TSN.ERP.Security.Rules.GeneralRules.AddReport))return -1;
			return RepInfo.Update(ModifedReports);
		}
		public int AddReportCalls(DataSet NewCalls)
		{
			if (!CheckUserAccess((int)TSN.ERP.Security.Rules.GeneralRules.AddReport))return -1;
			return RepCallls.Add(NewCalls);
		}
		public int AddReportParms(DataSet NewReportParms)
		{
			if (!CheckUserAccess((int)TSN.ERP.Security.Rules.GeneralRules.AddReport))return -1;
			return RepParms.Add(NewReportParms);
		}
		#endregion
		


		public DataSet ParmSelectionList(int ReportID , int ParmdID)
		{
			Reporting.CrysatlReports.ReportInfo RInf = LoadReportRunInfo(ReportID);
			Reporting.CrysatlReports.Parameter P = (Reporting.CrysatlReports.Parameter)RInf.ReportParameters[ParmdID];
			if (P.General)
			{
				if (P.Source  == "-1")
					return null;
				return TableInf.GetListForGeneralParameter(P.Source);
			}
			else
			{
				return EntitesData.GetListForEntityParameter(P.Source);
			}
			return new DataSet();
		}
		public Reporting.CrysatlReports.ReportInfo LoadReportRunInfo(int ReportID)
		{
			if (!CheckUserAccess((int)TSN.ERP.Security.Rules.GeneralRules.ListReports))return null;
			dsRepinfo.Clear();
			dsRepinfo.Merge(RepInfo.List("GEN_Files.FileID = " + ReportID));
			if (dsRepinfo.REP_ReportInfo.Count < 1) return null;
			Data.dsReportsInfo.REP_ReportInfoRow Row = dsRepinfo.REP_ReportInfo[0];
			XmlSerializer Xser = new XmlSerializer(typeof(TSN.ERP.Reporting.CrysatlReports.ReportInfo));
			TextWriter TW = new StreamWriter("LastReportInfo.xml");
			TW.Write(dsRepinfo.REP_ReportInfo[0].ReportRunData);
			TW.Close();
			TextReader TR = new StreamReader("LastReportInfo.xml");
			Reporting.CrysatlReports.ReportInfo RInf =  (Reporting.CrysatlReports.ReportInfo)Xser.Deserialize(TR);
			TR.Close();
			return RInf;
		}
		
		public bool CheckReportAccess(int ReportFileID, object[] Parameters)
		{
			if (ActiveSession.IsAdmin)
				return true;

			int Length = 0;string TMPStr;

			// laod Run info class 
			Reporting.CrysatlReports.ReportInfo RInf = LoadReportRunInfo(ReportFileID);
			//Check General Access Rights
			if (RInf.AdminstratorOnly)
				return false;

			Length = RInf.GeneralAccessRules.Count;
			for (int i = 0; i < Length; i++)
			{
				TMPStr = RInf.GeneralAccessRules[i].ToString();
				int TempIn = Int32.Parse(TMPStr);
				if (!CheckUserAccess(TempIn))
					return false;
			}

			// OR Statment for : General Rules or Entity // Fix it !
			if (Length > 0 )return true;
			

			int j = 0;
			foreach(TSN.ERP.Reporting.CrysatlReports.Parameter P in RInf.ReportParameters)
			{	
				CrystalDecisions.Shared.ParameterValueKind PK = (CrystalDecisions.Shared.ParameterValueKind)P.ParmType ;
				if ( PK == CrystalDecisions.Shared.ParameterValueKind .NumberParameter)
				{
					if( !P.General) 
					{
						Length = P.EntityAccessRights.Count;
						for (int i = 0; i < Length; i++)
						{
							TMPStr = P.EntityAccessRights[i].ToString();
							int TempRuleID = Int32.Parse(TMPStr);
							TMPStr = Parameters[j].ToString();
							int TempInt = Int32.Parse(TMPStr);
							if (!CheckUserAccess(TempRuleID,TempInt.ToString()))
								return false;
						}
					}
				}
				j++;
			}
			return true;
		}

	}
}
