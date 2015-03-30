using System;
using System.Web.Services.Protocols;

namespace TSN.ERP.Presentation
{
	/// <summary>
	/// The Basic Authenticaion header for all our web services
	/// </summary>
	public class AuthHeader:SoapHeader 
	{
		private string _Token;

		public string Token
		{
			get
			{
				return this._Token;
			}
			set
			{
				try
				{
					ERPMasterService TempSrvc = new ERPMasterService();
					TempSrvc.GetERPSession(value);
					this._Token=value;
				}
				catch(Exception ex)
				{
					throw new Exception( "TSN ERP Server: Trying to Get ERP Session, " + ex.Message);
				}
			}
		}
	}
}
