using System;
using System.Data;

namespace TSN.ERP.SharedComponents
{
	/// <summary>
	/// Summary description for MFGAccountabilityManager.
	/// </summary>
	public class MFGAccountabilityManager :Engine.BussinesObject 
	{
		Data.MFGMemberTasks		 MFGTasksData = new TSN.ERP.SharedComponents.Data.MFGMemberTasks();
		Data.MFGGroupMemberData  MFGGroupData = new TSN.ERP.SharedComponents.Data.MFGGroupMemberData();


		public MFGAccountabilityManager()
		{
			this.DataComponents.Add(MFGTasksData);
			this.DataComponents.Add(MFGGroupData);
		}

		#region MFG Tasks

		#region ListEmployeeMFGTasks

		public DataSet ListEmployeeMFGTasks( int ContactID , DateTime Date )
		{
			
			return this.MFGTasksData.GetAllEmployeeMFGTasks( ContactID , Date );
		}

		#endregion

		#region SaveMFGTasksSheet

		public void SaveMFGTasksSheet( DataSet dsMFGTasks )
		{
			
			this.MFGTasksData.SaveTasksSheet( dsMFGTasks );
		}
		#endregion

		#endregion

		#region MFG Group Memebers

		#region GetAllMFGEmployees
		// if user is admin get all MFG employees else if MFG admin get his only employees
		public DataSet GetAllMFGEmployees( int UserID )
		{
			DataSet ds = new DataSet();
			try
			{
				if( MFGGroupData.ActiveSession.IsAdmin )
					ds.Merge( this.MFGGroupData.GetAllAdminEmployees( ) );
				else
					ds.Merge( this.MFGGroupData.GetMFGEmployees( UserID ) );
			}
			catch( Exception ee )
			{

			}
			return ds;
		}
		#endregion

		#region Get MFG Admin Employees

		public DataSet GetMFGAdminEmployees( int UserID )
		{
			DataSet ds = new DataSet();
			try
			{
				
				ds.Merge( this.MFGGroupData.GetMFGEmployees( UserID ) );
			}
			catch( Exception ee )
			{

			}
			return ds;
		}
		#endregion

		#region GetAllMFGAdmins

		public DataSet GetAllMFGAdmins()
		{
			DataSet ds = new DataSet();
			try
			{
				
				ds.Merge( this.MFGGroupData.GetAllMFGAdmins() );
				
			}
			catch( Exception ee )
			{

			}
			return ds;
		}
		#endregion

		#region AddMFGAdminEmployees

		public void AddMFGAdminEmployees( int mfgAdminUsrID , DataSet dsMFGEmp )
		{
			try
			{
				MFGGroupData.DeleteMFGAdmin( mfgAdminUsrID );
				//MFGGroupData.Add( dsMFGEmp );
				MFGGroupData.AddMFGAdmin( dsMFGEmp );
			}
			catch( Exception ee )
			{

			}
		}
		#endregion

		#region User IS MFG Admin 

		public Boolean UserIsMFGAdmin( int UserID )
		{
			return this.MFGGroupData.UserIsMFG( UserID );
		
		}
		#endregion

		#region User IS MFGAdmin Or MFG Employee 

		public Boolean UserIsMFGAdminOrEmployee( int UserID )
		{
		
			if (this.MFGGroupData.UserIsMFG( UserID ) || this.MFGGroupData.UserIsMFGEmployee( UserID ) )
				return true;
			else
				return false;

		}
		#endregion

		#region DeleteMFGAdmin
		public int DeleteMFGAdmin( int MFGAdminUsrID )
		{
			return MFGGroupData.DeleteMFGAdmin( MFGAdminUsrID );
		}
		#endregion

		#endregion

	}
}
