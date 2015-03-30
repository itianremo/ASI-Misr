using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using TSN.ERP.Presentation;

namespace SharedPresentation
{
	/// <summary>
	/// Summary description for ReportWriter.
	/// </summary>
	public class ReportWriter : ERPMasterService
	{
		protected TSN.ERP.SharedComponents.ReportWriterManager RWMang;
		public ReportWriter()
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
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		#region GetUserManagedEntities

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet GetUserManagedEntities( string FieldName  )
		{
			LoadSession();
			return this.RWMang.GetUserManagedEntities( FieldName  );
		}

		#endregion 

		protected void LoadSession()
		{
			
			RWMang = new TSN.ERP.SharedComponents.ReportWriterManager();
			RWMang.JoinSession(Token);
		}

	}
}
