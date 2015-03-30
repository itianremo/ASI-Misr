using System;
using System.Data;
using TSN.ERP.Engine;

namespace TSN.ERP.Timing
{
	/// <summary>
	/// Summary description for CheckInOutManager.
	/// </summary>
	public class CheckInOutManager:BussinesObject
	{
		  Timing.Data.Timing_CheckInOutData objTiming_CheckInOutData = new TSN.ERP.Timing.Data.Timing_CheckInOutData();
		public CheckInOutManager()
		{
			
			this.DataComponents.Add(objTiming_CheckInOutData);
		}
		public DataSet mUpdateCheckInOut(DataSet dsCheckInOut)
		{
			return objTiming_CheckInOutData.List();
		}
		public DataSet mAddCheckInOut(DataSet dsCheckInOut)
		{
			objTiming_CheckInOutData.Add(dsCheckInOut);
			return objTiming_CheckInOutData.List();
		}
		public DataSet mDeleteCheckInOut(DataSet dsCheckInOut)
		{
			return objTiming_CheckInOutData.List();
		}
	}
}
