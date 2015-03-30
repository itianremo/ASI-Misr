using System;
using System.Web;

namespace TSN.ERP.WebGUI.Go.flowcharts
{
	/// <summary>
	/// Summary description for ChartFactory.
	/// </summary>
	public class ChartFactory 
	{
		//-------------------------------------------------------------------------
		#region Create new chart object
		/// <summary>
		/// Create new chart object based on given type parameter
		/// </summary>
		/// <param name="type">Type of created chart object</param>
		/// <returns>Chart object</returns>
		public static Chart CreateChart(int type )
		{
			if (type == (int)Chart.ChartTypes.DeptChart) 
				return new DeptHierarchyChart( );
			else if (type ==  (int)Chart.ChartTypes.TitleChart)
				return new TitlesChart( );
			else if (type ==  (int)Chart.ChartTypes.TeamChart)
				return new TeamsChart( );
			else if (type ==  (int)Chart.ChartTypes.ProjectChart)
				return new ProjectsChart( );
			else 
				return null;
		}
		#endregion
		//-------------------------------------------------------------------------
		#region Load existing chart
		/// <summary>
		/// Load resident chart object from the session
		/// </summary>
		/// <param name="type">Type of the chart</param>
		/// <returns>Chart object</returns>
		public static Chart LoadChart(int type)
		{
			if (type == (int)Chart.ChartTypes.DeptChart)
				return (DeptHierarchyChart)HttpContext.Current.Session["chartObject"];
			else if (type == (int)Chart.ChartTypes.TitleChart)
				return (TitlesChart)HttpContext.Current.Session["chartObject"];
			else if (type == (int)Chart.ChartTypes.TeamChart)
				return (TeamsChart)HttpContext.Current.Session["chartObject"];
			else if (type == (int)Chart.ChartTypes.ProjectChart)
				return (ProjectsChart)HttpContext.Current.Session["chartObject"];
			else 
				return null;
		
		}
		#endregion
		//-------------------------------------------------------------------------
	}
}
