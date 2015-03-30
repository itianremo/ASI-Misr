using System;
using System.Data;
using TSN.ERP.Engine;

namespace TSN.ERP.Timing
{
	public class CompanySettingsManager:Engine.BussinesObject
	{
		  Timing.Data.Timing_CompanySettings TimingCompanySettings = new TSN.ERP.Timing.Data.Timing_CompanySettings();

		public CompanySettingsManager()
		{
			this.DataComponents.Add(TimingCompanySettings);
		}

		public DataSet ListTimingCompanySettings (  )
		{
//			return TimingCompanySettings.GetTimingCompanySettings();
			return TimingCompanySettings.List(); 
		}

		public int EditTimingCompanySettings(DataSet dsTiming)
		{
			int i = TimingCompanySettings.Update(dsTiming);
			return i;
		}

	}
}
