using System;
using TSN.ERP.Engine;
using System.Data;
namespace TSN.ERP.SharedComponents
{
	/// <summary>
	/// This class manage the organization charts for the system
	/// this charts contains all the teams in the system with their pictures 
	/// </summary>
	public class OrgnizationChartsManager:BussinesObject 
	{
		private Data.OrgnizationChartsData ChartsData = new TSN.ERP.SharedComponents.Data.OrgnizationChartsData();
		
		public OrgnizationChartsManager()
		{
			DataComponents.Add(ChartsData);
		}

		/// <summary>
		/// List all charts 
		/// </summary>
		/// <returns>DataSet.(GEN_OrgnizationCharts):containing a set of charts</returns>
		
		[AtrERPMethodType(ERPMethodType.List)]
		public DataSet ListChartsInfo()
		{	
			return ChartsData.List();
		}

		/// <summary>
		/// Get a chart detailed data
		/// </summary>
		/// <param name="ChartID">integer value:chart ID</param>
		/// <returns>DataSet.(GEN_OrgnizationCharts):containing a set of charts</returns>
		
		[AtrERPMethodType(ERPMethodType.List)]
		public DataSet ListChartsInfo(int ChartID)
		{	
			return ChartsData.List(ChartID);
		}

		/// <summary>
		/// List chart giving special query string filter
		/// </summary>
		/// <param name="QueryString">string of query filter</param>
		/// <returns>DataSet.(GEN_OrgnizationCharts):containing a set of charts information</returns>
		
		[AtrERPMethodType(ERPMethodType.List)]
		public DataSet ListChartsInfo(string QueryString)
		{	
			return ChartsData.List(QueryString);
		}

		/// <summary>
		/// Add new charts 
		/// </summary>
		/// <param name="NewCharts">DataSet.(GEN_OrgnizationCharts):containing charts data</param>
		/// <returns>integer value:holds the ID of the added chart</returns>
		public int AddChartsInfo(DataSet NewCharts)
		{	
			return ChartsData.Add(NewCharts);
		}

        
            /// <summary>
		/// Modify charts Description
		/// </summary>
        /// <param name="int FileID,string ChartDescription">int FileID,string ChartDescription</param>
		/// <returns>bool value:1 if succeeded to modify and 0 if failed</returns>


        public bool SetChartDescription(int FileID,string ChartDescription)
		{
			if ( ! ( ChartsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ModifyOrgnizationChartInfo   ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ModifyOrgnizationChartInfo );
				return  false;
			}
				return ChartsData.SetChartDescription( FileID, ChartDescription);
		}

		/// <summary>
		/// Modify charts data
		/// </summary>
		/// <param name="ModifedChartsData">DataSet.(GEN_OrgnizationCharts):containing a set of charts</param>
		/// <returns>integer value:1 if succeeded to modify and 0 if failed</returns>
		

		public int ModifyChartsInfo(DataSet ModifedChartsData)
		{
			if ( ! ( ChartsData.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ModifyOrgnizationChartInfo   ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ModifyOrgnizationChartInfo );
				return  0;
			}
				return ChartsData.Update(ModifedChartsData);
		}
	}
}
