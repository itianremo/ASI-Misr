using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using TSN.ERP.SharedComponents;
using TSN.ERP.Presentation;
using System.Web.Services.Protocols;



namespace SharedPresentation
{
	/// <summary>
	/// Summary description for GeneralService.
	/// </summary>
	public class GeneralService : ERPMasterService
	{	
		private NotesManager noteMng ;
		private ManagersNotesManager managersNotesMngr;
		private FilesManager FileClass;
		public GeneralService()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}


		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if (noteMng != null)
				//noteMng.Dispose();
				noteMng=null;
			if (managersNotesMngr != null)
				//managersNotesMngr.Dispose();
				managersNotesMngr=null;
			if (FileClass != null)
				//FileClass.Dispose();
				FileClass=null;
			if(disposing && components != null)
			{
				//components.Dispose();
				components=null;
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		#region Notes

		#region AddNote
		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int AddNote( string noteBody)
		{
			LoadNotesComponent();
			return noteMng.AddNote( noteBody );
		}

		#endregion 

		#region ListAllNotes
		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListAllNotes( )
		{
			LoadNotesComponent();
			return noteMng.ListAllNotes();
		}

		#endregion 

		#region ListNote
		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListNote( int noteID )
		{
			LoadNotesComponent();
			return noteMng.ListNote( noteID );
		}

		#endregion 

		#region UpdateNote
		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int UpdateNote( DataSet noteDS )
		{
			LoadNotesComponent();
			return noteMng.UpdateNote( noteDS );
		}

		#endregion 

		#region DeleteNote
		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int DeleteNote( DataSet noteDS )
		{
			LoadNotesComponent();
			return noteMng.DeleteNote( noteDS );
		}

		#endregion 
		
		#endregion

		#region Managers Notes

		#region AddManagerNote
		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int AddManagerNote( string noteBody,DateTime noteDate)
		{
			LoadManagersNotesComponent();
			return managersNotesMngr.AddManagerNote( noteBody,noteDate );
		}

		#endregion 

		#region ListAllManagersNotes
		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListAllManagersNotes( )
		{
			LoadManagersNotesComponent();
			return managersNotesMngr.ListAllManagersNotes();
		}

		#endregion 

		#region ListManagerNote
		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListManagerNoteByNoteID( int noteID )
		{
			LoadManagersNotesComponent();
			return managersNotesMngr.ListManagerNote( noteID );
		}

		[WebMethod (Description = "Get Manager Note Bu UserID and Week Start Date" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListManagerNoteByFilterString( string filterString )
		{
			LoadManagersNotesComponent();
			return managersNotesMngr.ListManagerNote( filterString );
		}

		#endregion 

		#region UpdateManagersNotes
		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int UpdateManagerNote( DataSet noteDS )
		{
			LoadManagersNotesComponent();
			return managersNotesMngr.UpdateManagersNote( noteDS );
		}

		#endregion 

		#region DeleteManagerNote
		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int DeleteManagerNote( DataSet noteDS )
		{
			LoadManagersNotesComponent();
			return managersNotesMngr.DeleteManagersNote( noteDS );
		}

		#endregion 
		
		#endregion

		#region Files
		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int AddFileInfo(DataSet ds)
		{
			LoadFilesManager();
			return FileClass.AddFileInfo(ds);
		}

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListFileInfo() 
		{
			LoadFilesManager();
			return FileClass.ListFileInfo();
		}

		[WebMethod (Description = "" ,MessageName = "ListSingleFileInfo", EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListFileInfo(int FileID) 
		{
			LoadFilesManager();
			return FileClass.ListFileInfo(FileID);
		}

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int EditFileInfo(DataSet ds)
		{
			LoadFilesManager();
			return FileClass.EditFileInfo(ds);
		}

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int DeleteFileInfo(DataSet ds)
		{
			LoadFilesManager();
			return FileClass.DeleteFileInfo(ds);
		}

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public bool UpdateFileContent(int FileID, byte[] MStream)
		{
			LoadFilesManager();
			return FileClass.UpdateFileContent(FileID,MStream);
		}

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public byte[] LoadFileBody(int FileID)
		{
			LoadFilesManager();
			return FileClass.LoadFileBody(FileID);


		}
		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int mGetMaxFileID()
		{
			LoadFilesManager();
			return FileClass.mGetMaxFileID();


		}
		#endregion
		protected void LoadFilesManager()
		{
			//FileClass = (FilesManager)GetInstance("TSN.ERP.SharedComponents.FilesManager","TSN.ERP.SharedComponents");
			FileClass = new FilesManager();
			FileClass.JoinSession(Token);
		}
		protected void LoadNotesComponent()
		{
			//noteMng  = (NotesManager)this.GetInstance("TSN.ERP.SharedComponents.NotesManager","TSN.ERP.SharedComponents");
			noteMng = new NotesManager();
			noteMng.JoinSession(Token);
		}
		protected void LoadManagersNotesComponent()
		{
			//noteMng  = (NotesManager)this.GetInstance("TSN.ERP.SharedComponents.NotesManager","TSN.ERP.SharedComponents");
			managersNotesMngr = new ManagersNotesManager();
			managersNotesMngr.JoinSession(Token);
		}

	}
}
