using System;
using System.Data;
using TSN.ERP.Engine;

namespace TSN.ERP.Timing
{
	/// <summary>
	/// Summary description for ManageSpecialTime.
	/// </summary>
	public class SpecialTimingManager:Engine.BussinesObject
	{
		Data.Timing_SpecialTimeData  objSpecialTime = new TSN.ERP.Timing.Data.Timing_SpecialTimeData();
		public SpecialTimingManager()
		{
			this.DataComponents.Add(objSpecialTime);	
			
		}

		public DataSet ListSpecialTiming()
		{
			return objSpecialTime.List();
		}

		public int EditSpecialTime(DataSet dsSpecialTime)
		{
			int AffectedRows = objSpecialTime.Update(dsSpecialTime);
			return AffectedRows;
		}
		
	}
}
