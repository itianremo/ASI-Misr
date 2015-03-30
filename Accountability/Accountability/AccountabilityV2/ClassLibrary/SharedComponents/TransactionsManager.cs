using System;
//using System.EnterpriseServices;
using TSN.ERP.Engine;
namespace TSN.ERP.SharedComponents
{
	/// <summary>
	/// This class manage the transactions such as if user changes evaluation the system will save the old and new data
	/// </summary>
	/// 
	//[Transaction(TransactionOption.Required, Isolation=TransactionIsolationLevel.Serializable, Timeout=10)]
	public class TransactionsManager:Engine.BussinesObject 
	{
		protected Data.TransactionsData TransData = new TSN.ERP.SharedComponents.Data.TransactionsData();

		public TransactionsManager()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// Create a new transaction
		/// </summary>
		/// <returns>integer value:1 for creation and 0 for failure</returns>
		public int CreateTransaction()
		{
			return this.TransData.CreateTransaction(this.ActiveSession.UserSecurityInfo.UserID);
		}
	}
}
