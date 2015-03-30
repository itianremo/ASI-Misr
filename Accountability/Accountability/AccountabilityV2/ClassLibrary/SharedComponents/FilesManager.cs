using System;
using TSN.ERP.Engine;
using System.Data;
namespace TSN.ERP.SharedComponents
{
	/// <summary>
	/// Summary description for FilesManager.
	/// </summary>
	public class FilesManager:BussinesObject 
	{
		private Data.FilesDataClass FileClass = new TSN.ERP.SharedComponents.Data.FilesDataClass();
		
		public FilesManager()
		{
			DataComponents.Add(FileClass);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="ds">DataSet:Containing data  of new info file</param>
		/// <returns>Int:returns 1 if success and 0 if not</returns>
		public int AddFileInfo(DataSet ds)
		{
			
			return FileClass.Add(ds);
		}
		/// <summary>
		/// List all fill info.
		/// </summary>
		/// <returns>DataSet:Containing data  of info files</returns>
		[AtrERPMethodType(ERPMethodType.List)]
		public DataSet ListFileInfo() 
		{
			
			return FileClass.List();
		}
		/// <summary>
		/// List spacific info file.
		/// </summary>
		/// <param name="FileID">int:File ID which wanted to view</param>
		/// <returns>DataSet:Containing data  of spacific info file</returns>
		[AtrERPMethodType(ERPMethodType.List)]
		public DataSet ListFileInfo(int FileID) 
		{
		
			return FileClass.List(FileID);
		}
		/// <summary>
		/// Edit info files.
		/// </summary>
		/// <param name="ds">DataSet:Containing data of info file</param>
		/// <returns>Int:returns 1 if success and 0 if not</returns>
		public int EditFileInfo(DataSet ds)
		{
			
			return FileClass.Edit(ds);
		}
		/// <summary>
		/// Delete info  files.
		/// </summary>
		/// <param name="ds">DataSet:Containing data of info file</param>
		/// <returns>Int:returns 1 if success and 0 if not</returns>
		public int DeleteFileInfo(DataSet ds)
		{
			
			return FileClass.Delete(ds);
		}
		/// <summary>
		/// Update which into spacific file. 
		/// </summary>
		/// <param name="FileID"></param>
		/// <param name="FileBody"></param>
		/// <returns>bool:Returns true if success and false if not</returns>
		public bool UpdateFileContent(int FileID, byte[] FileBody)
		{
			if ( ! ( FileClass.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ModifyFileContent   ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ModifyFileContent );
				return  false;
			}
			return FileClass.UpdateFileContent(FileID,FileBody);
		}
		/// <summary>
		/// Open a contaent of spacific file.
		/// </summary>
		/// <param name="FileID"></param>
		/// <returns></returns>
		public byte[] LoadFileBody(int FileID)
		{
			
			return FileClass.LoadFileBody(FileID);
		}

		/// <summary>
		/// Get MAx File ID.
		/// </summary>
		/// <param name=""></param>
		/// <returns>int:Returns Max FileID</returns>
		public int mGetMaxFileID()
		{
			
			return FileClass.mGetMaxFileID();
		}
	}
}
