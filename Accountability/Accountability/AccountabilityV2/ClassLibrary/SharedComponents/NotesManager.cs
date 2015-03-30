using System;
using System.Data;
using TSN.ERP.Engine;
namespace TSN.ERP.SharedComponents
{
	/// <summary>
	/// This class manage the notes entered by the employees; list, add, update, delete notes
	/// </summary>
	public class NotesManager:BussinesObject 
	{
		enum AccessRights
		{
			//access code = 3
			AddNote = 3010, ListAllNotes = 3020
		}
		private Data.NotesData NotesDataClass = new TSN.ERP.SharedComponents.Data.NotesData(); 
		public NotesManager()
		{
			this.DataComponents.Add(NotesDataClass);
		}

		#region AddNote

		/// <summary>
		/// Add a note for today
		/// </summary>
		/// <param name="noteBody">string:contain note body</param>
		/// <returns>integer value:1 if succeeded to add note 0 if failed</returns>
		public int AddNote( string noteBody)
		{
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.AddNote  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.AddNote );
				return  0;
			}
			Data.dsNotes dsNotesDatsSet = new TSN.ERP.SharedComponents.Data.dsNotes();
			dsNotesDatsSet.EnforceConstraints = false;
			Data.dsNotes.GEN_NotesRow NotesRow = dsNotesDatsSet.GEN_Notes.NewGEN_NotesRow();
			NotesRow.UserID = this.ActiveSession.UserSecurityInfo.UserID;
			NotesRow.NoteBody = noteBody;
			NotesRow.NoteDate= DateTime.Today;
			dsNotesDatsSet.GEN_Notes.AddGEN_NotesRow(NotesRow);
			if (NotesDataClass.Add(dsNotesDatsSet)>=1)
				return NotesRow.NoteID;
			return -1;
		}

		/// <summary>
		/// Add a note for a specific day
		/// </summary>
		/// <param name="noteBody">string:contain note body</param>
		/// <param name="noteDate">DateTime:for addition</param>
		/// <returns>integer value:1 if succeeded to add note 0 if failed</returns>
		public int AddNote( string noteBody , DateTime noteDate )
		{
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.AddNote  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.AddNote );
				return  0;
			}
			Data.dsNotes dsNotesDatsSet = new TSN.ERP.SharedComponents.Data.dsNotes();
			dsNotesDatsSet.EnforceConstraints = false;
			Data.dsNotes.GEN_NotesRow NotesRow = dsNotesDatsSet.GEN_Notes.NewGEN_NotesRow();
			NotesRow.UserID = this.ActiveSession.UserSecurityInfo.UserID;
			NotesRow.NoteBody = noteBody;
			NotesRow.NoteDate = noteDate;
			dsNotesDatsSet.GEN_Notes.AddGEN_NotesRow(NotesRow);
			if (NotesDataClass.Add(dsNotesDatsSet)>=1)
				return NotesRow.NoteID;
			return -1;
		}



		/// <summary>
		/// Add a note to a contact
		/// </summary>
		/// <param name="ContactID">integer value:contact ID</param>
		/// <param name="NoteID">integer value:note ID</param>
		/// <returns>boolean:True for addition and False for failure</returns>
		internal bool AddNotetoContact(int ContactID,int NoteID)
		{
			return NotesDataClass.AddNoteToContact(ContactID,NoteID);
		}
		#endregion 

		#region ListAllNotes

		/// <summary>
		/// Get all notes data
		/// </summary>
		/// <returns>DataSet:containing a set of notes</returns>
		public DataSet ListAllNotes( )
		{
			//
			if ( ! ( NotesDataClass.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListAllNotes  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListAllNotes );
				return  null;
			}
			return NotesDataClass.List();
		}

		#endregion 

		#region ListNote

		/// <summary>
		/// Get a note body
		/// </summary>
		/// <param name="noteID">integer value:note ID</param>
		/// <returns>DataSet.(GEN_Notes):containing note body</returns>
		public DataSet ListNote( int noteID )
		{
			//
			if ( ! ( NotesDataClass.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.ListNote  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ListNote );
				return  null;
			}
			return NotesDataClass.List( noteID );
		}

		#endregion 

		#region UpdateNote

		/// <summary>
		/// Update notes
		/// </summary>
		/// <param name="noteDS">DataSet.(GEN_Notes):containing a set of notes</param>
		/// <returns>integer value: 1 if succeeded to update note 0 if failed</returns>
		public int UpdateNote( DataSet noteDS )
		{
			//
			if ( ! ( NotesDataClass.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.UpdateNote  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.UpdateNote );
				return  0;
			}
			return NotesDataClass.Update( noteDS );
		}

		#endregion 

		#region DeleteNote

		/// <summary>
		/// Delete notes
		/// </summary>
		/// <param name="noteDS">DataSet.(GEN_Notes):containing a set of notes</param>
		/// <returns>integer value: 1 if succeeded to delete note 0 if failed</returns>
		public int DeleteNote( DataSet noteDS )
		{
			//
			if ( ! ( NotesDataClass.ActiveSession.UserSecurityInfo.Administrator ||  CheckUserAccess( Convert.ToInt32( TSN.ERP.Security.Rules.GeneralRules.DeleteNote  ) ) )  )
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.DeleteNote );
				return  0;
			}
			return NotesDataClass.Delete( noteDS );
		}

		#endregion 

	}
}
