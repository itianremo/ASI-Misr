using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;



namespace TSN.ERP.WebGUI
{
	/// <summary>
	/// Summary description for Index.
	/// </summary>
	public partial class Index : System.Web.UI.Page
	{
        
		protected void Page_Load(object sender, System.EventArgs e)
		{
            // Register this form as Ajax compliant
            Ajax.Utility.RegisterTypeForAjax(typeof(Index));
            // commented by Sayed 5/10/2009
            //lblCompanyName.Text = System.Configuration.ConfigurationSettings.AppSettings["CompanyName"];
            lblCompany.Text = ConfigurationManager.AppSettings["CompanyName"];
			// Put user code to initialize the page here
			
			
			try
			{
				if (!IsPostBack)
				{
                    lblDate.Text = DateTime.Now.ToString(" dd MMMM yyyy");
                    lblBuild.Text ="GOA2  "+ ConfigurationManager.AppSettings["BuildNo"];
                    try
                    {

                        //Change Accesability(Intenet access, Local Area Network)
                        string strNetworkAccess = System.Configuration.ConfigurationManager.AppSettings["NetworkAccess"];
                        if (strNetworkAccess == "0")
                        {
                            lblAccess.Text = "&nbsp;(Local Area Network)";
                        }
                        else if (strNetworkAccess == "1")
                        {
                            lblAccess.Text = "&nbsp;(Internet Access)";
                        }
                    }
                    catch
                    {
                        lblAccess.Text = "&nbsp;(Local Area Network)";

                    }
                    

					//((Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.LogOff();
					//            		Session.Clear();
					//					if(Request.QueryString.Get("logoff") == null)
					//					{
					//						Session["logoff"] = false;			
					//					}

					if(Request.QueryString.Get("logoff") != null)
					{
						//Record that the user has logged off
						((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.UpdateUserLogin(DateTime.Now, int.Parse(Session["CurrentLoggedID"].ToString()));		
					}
					Session["selectedEMployee"] ="";
					
					#region NotePad Gizmo

					string GizmoTk = Request.QueryString["Token"];	
					if ( GizmoTk != null && GizmoTk != "" )
					{
						Navigation.BaseObject BO = new TSN.ERP.WebGUI.Navigation.BaseObject();
						BO.Token = GizmoTk;
						Session["navigation"] = BO;
						Fillobjects();
						FillUserRules();
						// Get the logged user's contact ID, Automatically his/her accountability sheet 'll be loaded as he navigate to 
						//automaticaly form

						try
						{
							//DataSet dsTerminatedEmps = ((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListTerminatedEmployees();
							Session["CurrentEmployee"] = ((Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.GetUserContactID();
							Session["LoginContactID"]=Session["CurrentEmployee"];
							TSN.ERP.SharedComponents.Data.dsEmployee dsEMP = new TSN.ERP.SharedComponents.Data.dsEmployee();
							dsEMP.Merge ( ((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListSingleEmployeeData( int.Parse( Session["CurrentEmployee"].ToString()  ) ));
							if ( dsEMP.GEN_Employees[0].EmployeeStatus == 0)
							{
								Label3.Visible=true;
								return;
							}
						}
						catch
						{
							Session["CurrentEmployee"] = -1;
						}
						// get username to add it when user make login
						string VsUserName=((Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.GetLoggedUserName();
						//Record user login
						int CurrentLoggedID = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.RecordUserLogInTime(VsUserName, DateTime.Now, Session.SessionID, false);
						Session["CurrentLoggedID"] = CurrentLoggedID;

						///////////////////////////
					
						int LinkID = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.GetHomePage();
						if ( LinkID > 0 &&  (((Navigation.BaseObject) Session[ "navigation" ]).SecInfo.RulesArray.Count != 0  || ((Navigation.BaseObject) Session[ "navigation" ]).SecInfo.IsAdministrator ) )
						{
							((Navigation.BaseObject) Session[ "navigation" ]).Module = 1;
							((Navigation.BaseObject) Session[ "navigation" ]).Link   = 1;
							Session["ComeFromIndexPage"] = "yes";//That means that the user has come from the index.aspx page before going to masterform.aspx

							//							//Record user login
							//							int CurrentLoggedID = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.RecordUserLogInTime(TextBoxUserName.Text, DateTime.Now, Session.SessionID, false);
							//							Session["CurrentLoggedID"] = CurrentLoggedID;

							Response.Redirect("MasterForm.aspx");			 

						}
						else
						{
							Response.Redirect ( "UserModules.aspx" );
						}

					}
					#endregion


					if(Session["CurrentLoggedID"] != null)
					{
						//Record that the user has logged off
						((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.UpdateUserLogin(DateTime.Now, int.Parse(Session["CurrentLoggedID"].ToString()));
						Session["CurrentLoggedID"] = null;
					}
                    //Change backgriund image based on country(Egypt, USA)
                    string strLoginImage = System.Configuration.ConfigurationManager.AppSettings["LoginImage"];
                    if (strLoginImage == "0")
                    {
                        tblGeneral.Style.Add(HtmlTextWriterStyle.BackgroundImage, "Go/images/accountabilityV20_login_bg3.gif");
                       // tblGeneral.Style.Add(HtmlTextWriterStyle.BackgroundImage, "Go/images/accountabilityV20_login_bg.jpg");
                    }
                    else if (strLoginImage == "1")
                    {
                        tblGeneral.Style.Add(HtmlTextWriterStyle.BackgroundImage, "Go/images/accountabilityV20_login_bg3.gif");
                        //tblGeneral.Style.Add(HtmlTextWriterStyle.BackgroundImage, "Go/images/accountabilityV20_login_bg_USA.jpg");
                    }
                    //----------------------------------------------------
				}
			}
			catch(Exception  ex)
			{
				string s = ex.Message;
			}
			/***************************/
			
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		#region Login_Click

        protected void Login_Click(object sender, ImageClickEventArgs e)
		{            
			Session["logoff"] = false;
			try
			{
				//MasterWS.ERPMasterService guiWS=new TSN.ERP.WebGUI.MasterWS.ERPMasterService();
				
				GUIWS.GUI guiWS = new TSN.ERP.WebGUI.GUIWS.GUI();
				string token = null;
                //int TrialsCount = 5;
				try
				{
					int vnEmployeeCode=Convert.ToInt32(TextBoxUserName.Text.Trim());
					SecurityWS.SecurityManagement sec=new TSN.ERP.WebGUI.SecurityWS.SecurityManagement();
					TextBoxUserName.Text=sec.GetUserName(vnEmployeeCode+"");
				}
				catch
				{
				}
								
                //while(TrialsCount > 0)
                //{
					token = guiWS.Login(  TextBoxUserName.Text , TextBoxPassword.Text );
                //    if(token != null)
                //    {
                //        break;
                //    }
                //    TrialsCount--;
                //}		
//				string token = guiWS.Login(  TextBoxUserName.Text , TextBoxPassword.Text );
//				SecurityWS.SecurityManagement sec=new TSN.ERP.WebGUI.SecurityWS.SecurityManagement();
//				TextBoxUserName.Text=sec.GetUserName("301");
				if ( token != null )
				{			
					Navigation.BaseObject BO = new TSN.ERP.WebGUI.Navigation.BaseObject();
					BO.Token = token;
					Session["navigation"] = BO;
					Fillobjects();
					FillUserRules();
                    //bool x = ((Navigation.BaseObject)Session["navigation"]).TaskWSObject.AddTaskToProjectFromPDMS("Accountability 1.5", "Fawzi Task", "Fawzi desc");
					// Get the logged user's contact ID, Automatically his/her accountability sheet 'll be loaded as he navigate to 
					//automaticaly form

					try
					{
						//						DataSet dsTerminatedEmps = ((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListTerminatedEmployees();
						Session["CurrentEmployee"] = ((Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.GetUserContactID();
						Session["LoginContactID"]=Session["CurrentEmployee"];
						TSN.ERP.SharedComponents.Data.dsEmployee dsEMP = new TSN.ERP.SharedComponents.Data.dsEmployee();
						dsEMP.Merge ( ((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject.ListSingleEmployeeData( int.Parse( Session["CurrentEmployee"].ToString()  ) ));
						if ( dsEMP.GEN_Employees[0].EmployeeStatus == 0)
						{
							Label3.Visible=true;
							return;
						}
					}
					catch
					{
						Session["CurrentEmployee"] = -1;
					}

					//Record user login
					int CurrentLoggedID = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.RecordUserLogInTime(TextBoxUserName.Text, DateTime.Now, Session.SessionID, false);
					Session["CurrentLoggedID"] = CurrentLoggedID;
					
					int LinkID = ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.GetHomePage();
					if ( LinkID > 0 &&  (((Navigation.BaseObject) Session[ "navigation" ]).SecInfo.RulesArray.Count != 0  || ((Navigation.BaseObject) Session[ "navigation" ]).SecInfo.IsAdministrator ) )
					{
						((Navigation.BaseObject) Session[ "navigation" ]).Module = 1;
						((Navigation.BaseObject) Session[ "navigation" ]).Link   = 1;
						Session["ComeFromIndexPage"] = "yes";//That means that the user has come from the index.aspx page before going to masterform.aspx
						Response.Redirect("MasterForm.aspx");			 

					}
					else
					{
						Response.Redirect ( "UserModules.aspx" );
					}

				}
				else
				{
					Label3.Visible = true;
				}
			}
			catch ( Exception ee )
			{
				Navigation.BaseObject.showMessage (  ee.Message , this.Page );
			}
				
		}

		#endregion 
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
        public void SetIEVersionSession(string version)
        {
            Session["IEVersion"] = version;
          
        }
        

		#region Fill objects
		
		public   void Fillobjects () 
		{
			/************Updated By :Sayed Moawad  Date: 17/06/2008 *************/
			try
			{
				string token = ((Navigation.BaseObject) Session[ "navigation" ]).Token;
				//------------------------------------------------------
				// fill GUI web service object
				GUIWS.GUI guiWS = new TSN.ERP.WebGUI.GUIWS.GUI();
				//token=guiWS.Login(  TextBoxUserName.Text , TextBoxPassword.Text );
				GUIWS.AuthHeader ah = new TSN.ERP.WebGUI.GUIWS.AuthHeader();
				ah.Token = token;
				guiWS.AuthHeaderValue = ah;
				//bool testgui=guiWS.GetERPSession(token);
				((Navigation.BaseObject) Session[ "navigation" ]).GUIWsObject = guiWS ;
				//Navigation.BaseObject.GUIWsObject = guiWS ;
				//------------------------------------------------------
				// fill security web service object
				SecurityWS.SecurityManagement secMang = new TSN.ERP.WebGUI.SecurityWS.SecurityManagement();
				//token=secMang.Login(  TextBoxUserName.Text , TextBoxPassword.Text );
				SecurityWS.AuthHeader authHeder = new TSN.ERP.WebGUI.SecurityWS.AuthHeader();
				authHeder.Token = token;
				secMang.AuthHeaderValue = authHeder;
				((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject = secMang ;	
				//------------------------------------------------------
				// fill Contacts web service object
				ContactsWS.ContactsService contactWS = new TSN.ERP.WebGUI.ContactsWS.ContactsService();
				//token=contactWS.Login(  TextBoxUserName.Text , TextBoxPassword.Text );
				ContactsWS.AuthHeader contactAH = new TSN.ERP.WebGUI.ContactsWS.AuthHeader();
				contactAH.Token = token;
				contactWS.AuthHeaderValue = contactAH;
				((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject = contactWS ;	
				//------------------------------------------------------
				// fill Employees web service object
				EmployeesWS.EmployeesService employeeWS = new TSN.ERP.WebGUI.EmployeesWS.EmployeesService();
				EmployeesWS.AuthHeader employeeAH = new TSN.ERP.WebGUI.EmployeesWS.AuthHeader();
				employeeAH.Token = token;
				employeeWS.AuthHeaderValue = employeeAH;
				((Navigation.BaseObject) Session[ "navigation" ]).EmployeeWsObject = employeeWS ;	
				//------------------------------------------------------
				
				// ******* job Titles ****
				JobTitlesWS.JobTitles jobWS = new JobTitlesWS.JobTitles();
				JobTitlesWS.AuthHeader jobAH = new TSN.ERP.WebGUI.JobTitlesWS.AuthHeader();
				jobAH.Token = token;
				jobWS.AuthHeaderValue = jobAH;
				((Navigation.BaseObject) Session[ "navigation" ]).JobTiltesWsObject = jobWS ;

				// ******* Compnay  ****
				CompanyStruct.CompanyStucture compWS = new TSN.ERP.WebGUI.CompanyStruct.CompanyStucture();
				CompanyStruct.AuthHeader compAH = new TSN.ERP.WebGUI.CompanyStruct.AuthHeader();
				compAH.Token = token;
				compWS.AuthHeaderValue = compAH;
				((Navigation.BaseObject) Session[ "navigation" ]).CompanyWsObject = compWS ;
				// ******* Compnay  ****
				SharedCompWS.ERPSessionServices sessionWS = new TSN.ERP.WebGUI.SharedCompWS.ERPSessionServices();
				SharedCompWS.AuthHeader sessionAH = new TSN.ERP.WebGUI.SharedCompWS.AuthHeader();
				//string Vstoken=sessionWS.Login(  TextBoxUserName.Text , TextBoxPassword.Text );
				sessionAH.Token = token;
				sessionWS.AuthHeaderValue = sessionAH;
				//bool Vbtest=sessionWS.IsUserAdmin() ;
				((Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject = sessionWS ;

				// ******* Projects  ****
				ProjectsWS.ProjectsService prjWS = new TSN.ERP.WebGUI.ProjectsWS.ProjectsService();
				ProjectsWS.AuthHeader prjAH = new TSN.ERP.WebGUI.ProjectsWS.AuthHeader();
				prjAH.Token = token;
				prjWS.AuthHeaderValue = prjAH;
				((Navigation.BaseObject) Session[ "navigation" ]).ProjectWSObject = prjWS ;

				// ******* Tasks  ****
				TaskWS.TasksService taskWS = new TSN.ERP.WebGUI.TaskWS.TasksService();
				TaskWS.AuthHeader taskAH = new TSN.ERP.WebGUI.TaskWS.AuthHeader();
				taskAH.Token = token;
				taskWS.AuthHeaderValue = taskAH;
				((Navigation.BaseObject) Session[ "navigation" ]).TaskWSObject = taskWS ;

				// ******* Accountability ****
				AccountabilityWS.AccountabilityService accWS = new TSN.ERP.WebGUI.AccountabilityWS.AccountabilityService();
				AccountabilityWS.AuthHeader accAH = new TSN.ERP.WebGUI.AccountabilityWS.AuthHeader();
				accAH.Token = token;
				accWS.AuthHeaderValue = accAH;
				((Navigation.BaseObject) Session[ "navigation" ]).AccountabilityWSObject = accWS ;

				// ******* teams ****
				TeamsWS.TeamsService teamWS = new TSN.ERP.WebGUI.TeamsWS.TeamsService();
				TeamsWS.AuthHeader teamAH = new TSN.ERP.WebGUI.TeamsWS.AuthHeader();
				teamAH.Token = token;
				teamWS.AuthHeaderValue = teamAH;
				((Navigation.BaseObject) Session[ "navigation" ]).TeamsWSObject = teamWS ;

				//******Orginzation Charts************
				OrgnizationChartsWS.OrgnizationChartsMangmentService ChartWS = new TSN.ERP.WebGUI.OrgnizationChartsWS.OrgnizationChartsMangmentService();
				OrgnizationChartsWS.AuthHeader Chartsauth = new TSN.ERP.WebGUI.OrgnizationChartsWS.AuthHeader();
				Chartsauth.Token = token;
				ChartWS.AuthHeaderValue = Chartsauth;
				((Navigation.BaseObject) Session[ "navigation" ]).OrgnizationChartsWSObject = ChartWS;
				
				//******Crysatl Reports************

				CrysatlReportsWS.CrysatlReportsService  CRWS = new  TSN.ERP.WebGUI.CrysatlReportsWS.CrysatlReportsService();
                //token=CRWS.Login(  TextBoxUserName.Text , TextBoxPassword.Text );
				CrysatlReportsWS.AuthHeader CRauth = new  TSN.ERP.WebGUI.CrysatlReportsWS.AuthHeader();
				CRauth.Token = token;
				CRWS.AuthHeaderValue = CRauth;
				((Navigation.BaseObject) Session[ "navigation" ]).CrystalReportsWSObject = CRWS;
				// ******* General services ****
				GeneralWS.GeneralService generalWS = new TSN.ERP.WebGUI.GeneralWS.GeneralService();
				GeneralWS.AuthHeader generalAH = new TSN.ERP.WebGUI.GeneralWS.AuthHeader();
				generalAH.Token = token;
				generalWS.AuthHeaderValue = generalAH;
				((Navigation.BaseObject) Session[ "navigation" ]).GeneralWSObject = generalWS ;
				// ******* Compnay  ****
				MFGAccWS.MFGAccountability mfgWS = new TSN.ERP.WebGUI.MFGAccWS.MFGAccountability();
				MFGAccWS.AuthHeader mfgAH = new TSN.ERP.WebGUI.MFGAccWS.AuthHeader();
				mfgAH.Token = token;
				mfgWS.AuthHeaderValue = mfgAH;
				((Navigation.BaseObject) Session[ "navigation" ]).MFGWSObject = mfgWS ;
				// ******* Timing Company Settings  ****
				TimingWS.TimingWS TimeWS = new TSN.ERP.WebGUI.TimingWS.TimingWS();
				TimingWS.AuthHeader TimingAuth = new TSN.ERP.WebGUI.TimingWS.AuthHeader();
				TimingAuth.Token = token;
				TimeWS.AuthHeaderValue = TimingAuth;
				((Navigation.BaseObject) Session[ "navigation" ]).TimingWSObject = TimeWS;

			}

			catch( Exception ee )
			{
				Navigation.BaseObject.showMessage( ee.Message , this.Page ); 
			}

		}
		#endregion

		#region Fill User Rules
		
		public   void FillUserRules() 
		{
			try
			{
				((Navigation.BaseObject) Session[ "navigation" ]).SecInfo.IsAdministrator = ((Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.IsUserAdmin( ); 
				
				if ( ! ((Navigation.BaseObject) Session[ "navigation" ]).SecInfo.IsAdministrator )
				{
//					Data.DataSetRules dsRules = new TSN.ERP.WebGUI.Data.DataSetRules();
//					dsRules.Merge ( ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.GetAllUserRules( ) );
//					for ( int i = 0 ; i < dsRules.Tables[ 0 ].Rows.Count ; i++ )
//						((Navigation.BaseObject) Session[ "navigation" ]).SecInfo.RulesArray.Add( dsRules.SEC_Rules[ i ].RuleID );
					
					Data.DataSetRuleEntity  dsRulesEnt = new TSN.ERP.WebGUI.Data.DataSetRuleEntity();
					dsRulesEnt.EnforceConstraints = false;
					dsRulesEnt.Merge ( ((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.GetAllUserRulesEntities( ) );
					for ( int i = 0 ; i < dsRulesEnt.Tables[ 0 ].Rows.Count ; i++ )
					{
						int[] elm = new int[2];
						// set rule id in index 0
						elm[ 0 ]= dsRulesEnt.SEC_RuleEntity[ i ].RuleID ;
						// set rule entity value in index 1 
						if( ! dsRulesEnt.SEC_RuleEntity[ i ].IsRuleEntityValueNull() )
							elm[ 1 ]= int.Parse( dsRulesEnt.SEC_RuleEntity[ i ].RuleEntityValue.Trim() ) ;
						else 
							elm[ 1 ]= -1 ;
							
						((Navigation.BaseObject) Session[ "navigation" ]).SecInfo.RulesArray.Add( elm );

					}
				}
			}

			catch( Exception ee )
			{
				Navigation.BaseObject.showMessage( ee.Message , this.Page ); 
			}

		}
		#endregion


		
	}
}
