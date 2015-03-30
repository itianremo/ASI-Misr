using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using TSN.ERP.Presentation;
using TSN.ERP.Engine;
using TSN.ERP.SharedComponents;
using System.Web.Services.Protocols;

namespace SharedPresentation
{
	/// <summary>
	/// Summary description for OrgnizationChartsMangmentService.
	/// </summary>
	public class OrgnizationChartsMangmentService :ERPMasterService
	{
		private FilesManager FileClass ;
		private OrgnizationChartsManager ChartsClass;

		public OrgnizationChartsMangmentService()
		{
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
			if (FileClass !=null)
				//FileClass.Dispose();
				FileClass=null;
			if (ChartsClass != null)
				//ChartsClass.Dispose();
				ChartsClass=null;
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		[WebMethod (Description = "" ,MessageName = "ListChartsInfo", EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListChartsInfo()
		{
			LoadChartsManager();
			return ChartsClass.ListChartsInfo();
		}
		[WebMethod (Description = "" ,MessageName = "ListChartsInfoByID", EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListChartsInfo(int ChartID)
		{
			LoadChartsManager();
			return ChartsClass.ListChartsInfo(ChartID);
		}
		
		[WebMethod (Description = "" ,MessageName = "ListChartsInfobyQuery", EnableSession = true) , SoapHeader("Authenticator")]
		public DataSet ListChartsInfo(string QueryString)
		{
			LoadChartsManager();
			return ChartsClass.ListChartsInfo(QueryString);
		}

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int AddChartsInfo(DataSet NewCharts)
		{
			LoadChartsManager();
			return ChartsClass.AddChartsInfo(NewCharts);
		}

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public int ModifyChartsInfo(DataSet ModifedChartsData)
		{
			LoadChartsManager();
			return ChartsClass.ModifyChartsInfo(ModifedChartsData);
		}
        [WebMethod(Description = "", EnableSession = true), SoapHeader("Authenticator")]
        public bool ModifyChartDescription (int FileID,string ChartDescription)
        {
            LoadChartsManager();
            return ChartsClass.SetChartDescription(FileID,ChartDescription);
        }

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public bool UpdateChartBody(int FileID, byte[] MStream)
		{
			LoadFilesManager();
			return FileClass.UpdateFileContent(FileID,MStream);
		}

		[WebMethod (Description = "" , EnableSession = true) , SoapHeader("Authenticator")]
		public byte[] LoadChartBody(int FileID)
		{
			LoadFilesManager();
			return FileClass.LoadFileBody(FileID);
		}
		protected void LoadFilesManager()
		{
			//FileClass = (FilesManager)GetInstance("TSN.ERP.SharedComponents.FilesManager","TSN.ERP.SharedComponents");
			FileClass = new FilesManager();
			FileClass.JoinSession(Token);
		}
		protected void LoadChartsManager()
		{
			ChartsClass = new OrgnizationChartsManager();
			ChartsClass.JoinSession(Token);
			//ChartsClass = (OrgnizationChartsManager)GetInstance("TSN.ERP.SharedComponents.OrgnizationChartsManager","TSN.ERP.SharedComponents");
		}

	}
}
