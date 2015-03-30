using System;
using System.Data;

namespace TSN.ERP.GUIManagement
{
	/// <summary>
	/// Summary description for SecurityGUI.
	/// </summary>
	public class SecurityGUIManager : TSN.ERP.Engine.BussinesObject
	{
		TSN.ERP.GUIManagement.Data.GenModulesData generalMod				 = new TSN.ERP.GUIManagement.Data.GenModulesData();
		TSN.ERP.GUIManagement.Data.GenSubModulesData generalSubMod		     = new TSN.ERP.GUIManagement.Data.GenSubModulesData();
		TSN.ERP.GUIManagement.Data.ModulesXSubModulesData generalModSubMod   = new TSN.ERP.GUIManagement.Data.ModulesXSubModulesData();
		TSN.ERP.GUIManagement.Data.ModulesSubModulesXRulesData ModSubModRule = new TSN.ERP.GUIManagement.Data.ModulesSubModulesXRulesData();
	
		public SecurityGUIManager()
		{
			this.DataComponents.Add(generalMod);
			this.DataComponents.Add(generalSubMod);
			this.DataComponents.Add(generalModSubMod);
			this.DataComponents.Add(ModSubModRule);

		}



		#region GeneralModules

		#region AddGeneralModule 
		public int AddGeneralModule ( System.Data.DataSet ds )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			if ( ActiveSession.UserSecurityInfo.Administrator )
			{
				if (	generalMod.Add( ds ) == 1 )
					return 1 ;
				else
					return -1 ;
			}
			else 
				return -1 ;

		}


		#endregion 

		#region UpdateGeneralModule 
		public int UpdateGeneralModule ( System.Data.DataSet ds )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			if ( ActiveSession.UserSecurityInfo.Administrator )
			{
				if (	generalMod.Edit( ds ) == 1 )
					return 1 ;
				else
					return -1 ;
			}
			else 
				return -1 ;

		}


		#endregion 

		#region DeleteGeneralModule 
		public int DeleteGeneralModule ( System.Data.DataSet ds )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			if ( ActiveSession.UserSecurityInfo.Administrator )
			{
				if (	generalMod.Delete( ds ) == 1 )
					return 1 ;
				else
					return -1 ;
			}
			else 
				return -1 ;

		}


		#endregion 

		#region ViewGeneralModules 
		public DataSet ViewGeneralModules (  )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSet ds = new DataSet();
			ds = generalMod.List(); 
			
			return ds;

		}
		
		#endregion 
		
		
		#endregion 

		#region GeneralSubModules

		#region AddGeneralSubModule 
		public int AddGeneralSubModule ( System.Data.DataSet ds )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			if ( ActiveSession.UserSecurityInfo.Administrator )
			{
				if (	generalSubMod.Add( ds ) == 1 )
					return 1 ;
				else
					return -1 ;
			}
			else 
				return -1 ;

		}


		#endregion 

		#region UpdateGeneralSubModule 
		public int UpdateGeneralSubModule ( System.Data.DataSet ds )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			if ( ActiveSession.UserSecurityInfo.Administrator )
			{
				if (	generalSubMod.Edit( ds ) == 1 )
					return 1 ;
				else
					return -1 ;
			}
			else 
				return -1 ;

		}


		#endregion 

		#region DeleteGeneralSubModule 
		public int DeleteGeneralSubModule ( System.Data.DataSet ds )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			if ( ActiveSession.UserSecurityInfo.Administrator )
			{
				if (	generalSubMod.Delete( ds ) == 1 )
					return 1 ;
				else
					return -1 ;
			}
			else 
				return -1 ;

		}


		#endregion 

		#region ViewGeneralSubModules 
		public DataSet ViewGeneralSubModules (  )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSet ds = new DataSet();

			ds = generalSubMod.List(); 
			
			return ds;

		}
		
		#endregion 


		#endregion 

		#region GeneralModulesXSubModules

		#region AddModuleXSubModule 
		public int AddModuleXSubModule ( System.Data.DataSet ds )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			if ( ActiveSession.UserSecurityInfo.Administrator )
			{
				if (	generalModSubMod.Add( ds ) == 1 )
					return 1 ;
				else
					return -1 ;
			}
			else 
				return -1 ;

		}


		#endregion 

		#region UpdateModuleXSubModule 
		public int UpdateModuleXSubModule ( System.Data.DataSet ds )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			if ( ActiveSession.UserSecurityInfo.Administrator )
			{
				if (	generalModSubMod.Edit( ds ) == 1 )
					return 1 ;
				else
					return -1 ;
			}
			else 
				return -1 ;

		}


		#endregion 

		#region DeleteModuleXSubModule 
		public int DeleteModuleXSubModule ( System.Data.DataSet ds )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			if ( ActiveSession.UserSecurityInfo.Administrator )
			{
				if ( generalModSubMod.Delete( ds ) == 1 )
					return 1 ;
				else
					return -1 ;
			}
			else 
				return -1 ;

		}


		#endregion 

		#region ViewModuleXSubModule
		public DataSet ViewModuleXSubModule (  )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSet ds = new DataSet();

			if ( ActiveSession.UserSecurityInfo.Administrator )
				ds = generalModSubMod.List(); 
			
			return ds;

		}
		
		#endregion 

		#region ViewSubModulesForModule
		public DataSet ViewSubModulesForModule ( int modID  )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSet ds = new DataSet();
			
			if ( ActiveSession.UserSecurityInfo.Administrator )
			{
				generalModSubMod.oleDbDataAdapterModuleSubModules.SelectCommand.Parameters[ "ModID" ].Value = modID ;
				generalModSubMod.oleDbDataAdapterModuleSubModules.Fill( ds );
			}
			
			return ds;

		}
		
		#endregion 


		#endregion 

		#region ModulesSubModulesXRules

		#region AddModulesSubModulesXRules
		public int AddModulesSubModulesXRules( System.Data.DataSet ds )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			if ( ActiveSession.UserSecurityInfo.Administrator )
			{
				if (	ModSubModRule.Add( ds ) == 1 )
					return 1 ;
				else
					return -1 ;
			}
			else 
				return -1 ;

		}


		#endregion 

		#region UpdateModulesSubModulesXRules 
		public int UpdatModulesSubModulesXRules ( System.Data.DataSet ds )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			if ( ActiveSession.UserSecurityInfo.Administrator )
			{
				if (	generalModSubMod.Edit( ds ) == 1 )
					return 1 ;
				else
					return -1 ;
			}
			else 
				return -1 ;

		}


		#endregion 

		#region DeleteModulesSubModulesXRules  
		public int DeleteModulesSubModulesXRules ( System.Data.DataSet ds )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			if ( ActiveSession.UserSecurityInfo.Administrator )
			{
				if ( generalModSubMod.Delete( ds ) == 1 )
					return 1 ;
				else
					return -1 ;
			}
			else 
				return -1 ;

		}


		#endregion 

		#region ViewModulesSubModulesXRules 
		public DataSet ViewModulesSubModulesXRules (  )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSet ds = new DataSet();

			if ( ActiveSession.UserSecurityInfo.Administrator )
				ds = generalModSubMod.List(); 
			
			return ds;

		}
		
		#endregion 

		#region ViewRulesOfSubModule
		public DataSet ViewRulesOfSubModule ( int ModsubModID  )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSet ds = new DataSet();
			
			if ( ActiveSession.UserSecurityInfo.Administrator )
			{
				ModSubModRule.oleDbDataAdapterRulesOfSubModules.SelectCommand.Parameters[ "MSMID" ].Value = ModsubModID ;
				ModSubModRule.oleDbDataAdapterRulesOfSubModules.Fill( ds );
			}
			
			return ds;

		}
		
		#endregion 

		#region ViewRulesEntitiesOfSubModule
		public DataSet ViewRulesEntitiesOfSubModule ( int ModsubModID  )
		{
			//System.EnterpriseServices.ContextUtil.DeactivateOnReturn = true;
			DataSet ds = new DataSet();
			
			if ( ActiveSession.UserSecurityInfo.Administrator )
			{
				ModSubModRule.oleDbDataAdapterRulesEntitiesOfSubModules.SelectCommand.Parameters[ "MSMID" ].Value = ModsubModID ;
				ModSubModRule.oleDbDataAdapterRulesEntitiesOfSubModules.Fill( ds );
			}
			
			return ds;
		}
		
		#endregion 

		#endregion 

	}
}
