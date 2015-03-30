using System;
using System.Data;
using TSN.ERP.Engine;
namespace TSN.ERP.SharedComponents
{
	/// <summary>
	/// This class manage the notes entered by the employees; list, add, update, delete notes
	/// </summary>
	public class ManagersNotesManager:BussinesObject 
	{
		enum AccessRights
		{
			//access code = 3
			AddNote = 3010, ListAllNotes = 3020
		}
		private Data.ManagersNotesData ManagersNotesDataClass = new TSN.ERP.SharedComponents.Data.ManagersNotesData(); 
		public ManagersNotesManager()
		{
			this.DataComponents.Add(ManagersNotesDataClass);
		}

		#region AddNote

		/// <summary>
		/// Add a note for today
		/// </summary>
		/// <param name="noteBody">string:contain note body</param>
		/// <returns>integer value:1 if succeeded to add note 0 if failed</returns>
		public int AddManagerNote( string noteBody,DateTime vDate)
		{
//			if ( ! ( ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.AddNote  ) ) )  )
//			{
//				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.AddNote );
//				return  0;
//			}
			
			Data.dsManagersNotes dsManagersNotes = new TSN.ERP.SharedComponents.Data.dsManagersNotes();
			dsManagersNotes.EnforceConstraints = false;
			Data.dsManagersNotes.GEN_ManagerNotesRow ManagersNotesRow = dsManagersNotes.GEN_ManagerNotes.NewGEN_ManagerNotesRow();
			ManagersNotesRow.UserID = this.ActiveSession.UserSecurityInfo.UserID;
			ManagersNotesRow.NoteBody = noteBody;
			ManagersNotesRow.CreatedOn= DateTime.Today;
			int weekDateCount = -(int)vDate.DayOfWeek;
			DateTime weekStart = vDate.AddDays(weekDateCount);
			ManagersNotesRow.WeekStartDate = weekStart;
//			int weekDateCount = -(int)DateTime.Today.DayOfWeek;
//			DateTime weekStart = DateTime.Today.AddDays(weekDateCount);
//			ManagersNotesRow.WeekStartDate = weekStart;
			dsManagersNotes.GEN_ManagerNotes.AddGEN_ManagerNotesRow(ManagersNotesRow);
			if (ManagersNotesDataClass.Add(dsManagersNotes)>=1)
				return ManagersNotesRow.MNoteID;
			return -1;
		}

		/// <summary>
		/// Add a note for a specific day
		/// </summary>
		/// <param name="noteBody">string:contain note body</param>
		/// <param name="noteDate">DateTime:for addition</param>
		/// <returns>integer value:1 if succeeded to add note 0 if failed</returns>
//		public int AddManagerNote( string noteBody , DateTime noteDate )
//		{
////			if ( ! ( ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.AddNote  ) ) )  )
////			{
////				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.AddNote );
////				return  0;
////			}
//			Data.dsManagersNotes dsManagersNotes = new TSN.ERP.SharedComponents.Data.dsManagersNotes();
//			dsManagersNotes.EnforceConstraints = false;
//			Data.dsManagersNotes.GEN_ManagerNotesRow ManagersNotesRow = dsManagersNotes.GEN_ManagerNotes.NewGEN_ManagerNotesRow();
//			ManagersNotesRow.UserID = this.ActiveSession.UserSecurityInfo.UserID;
//			ManagersNotesRow.NoteBody = noteBody;
//			ManagersNotesRow.CreatedOn = noteDate;
//			int weekDateCount = -(int)noteDate.DayOfWeek;
//			DateTime weekStart = noteDate.AddDays(weekDateCount);
//			ManagersNotesRow.WeekStartDate = weekStart;
//			dsManagersNotes.GEN_ManagerNotes.AddGEN_ManagerNotesRow(ManagersNotesRow);
//			if (ManagersNotesDataClass.Add(dsManagersNotes)>=1)
//				return ManagersNotesRow.MNoteID;
//			return -1;
//		}



		/// <summary>
		/// Add a note to a contact
		/// </summary>
		/// <param name="ContactID">integer value:contact ID</param>
		/// <param name="NoteID">integer value:note ID</param>
		/// <returns>boolean:True for addition and False for failure</returns>
//		internal bool AddNotetoContact(int ContactID,int NoteID)
//		{
//			return NotesDataClass.AddNoteToContact(ContactID,NoteID);
//		}
		#endregion 

		#region ListAllNotes

		/// <summary>
		/// Get all notes data
		/// </summary>
		/// <returns>DataSet:containing a set of notes</returns>
		public DataSet ListAllManagersNotes( )
		{
//			//
//			if ( ! ( ManagersNotesDataClass.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListAllNotes  ) ) )  )
//			{
//				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListAllNotes );
//				return  null;
//			}
			return ManagersNotesDataClass.List();
		}

		#endregion 

		#region ListNote

		/// <summary>
		/// Get a note body
		/// </summary>
		/// <param name="noteID">integer value:note ID</param>
		/// <returns>DataSet.(GEN_Notes):containing note body</returns>
		public DataSet ListManagerNote( int noteID )
		{
//			//
//			if ( ! ( ManagersNotesDataClass.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListNote  ) ) )  )
//			{
//				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListNote );
//				return  null;
//			}
			return ManagersNotesDataClass.List( noteID );
		}

		/// <summary>
		/// Get a note body
		/// </summary>
		/// <param name="noteID">integer value:note ID</param>
		/// <returns>DataSet.(GEN_Notes):containing note body</returns>
		public DataSet ListManagerNote( string filterString )
		{
			try
			{
				//			//
				//			if ( ! ( ManagersNotesDataClass.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListNote  ) ) )  )
				//			{
				//				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListNote );
				//				return  null;
				//			}
				return ManagersNotesDataClass.List( filterString );
			}
			catch(Exception ex)
			{
              string mesg=ex.Message;
				return null;
			}
		}

		#endregion 

		#region UpdateNote

		/// <summary>
		/// Update notes
		/// </summary>
		/// <param name="noteDS">DataSet.(GEN_Notes):containing a set of notes</param>
		/// <returns>integer value: 1 if succeeded to update note 0 if failed</returns>
		public int UpdateManagersNote( DataSet noteDS )
		{
//			//
//			if ( ! ( ManagersNotesDataClass.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.UpdateNote  ) ) )  )
//			{
//				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.UpdateNote );
//				return  0;
//			}
			return ManagersNotesDataClass.Update( noteDS );
		}

		#endregion 

		#region DeleteNote

		/// <summary>
		/// Delete notes
		/// </summary>
		/// <param name="noteDS">DataSet.(GEN_Notes):containing a set of notes</param>
		/// <returns>integer value: 1 if succeeded to delete note 0 if failed</returns>
		public int DeleteManagersNote( DataSet noteDS )
		{
//			//
//			if ( ! ( ManagersNotesDataClass.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.DeleteNote  ) ) )  )
//			{
//				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.DeleteNote );
//				return  0;
//			}
			return ManagersNotesDataClass.Delete( noteDS );
		}

		#endregion 

	}
}
