using System;
using System.Data;
using System.Data.OleDb;

namespace TSN.ERP.SharedComponents
{
	/// <summary>
	/// Summary description for ReportWriterManager.
	/// </summary>
	public class ReportWriterManager :Engine.BussinesObject 
	{
		#region Variables

		protected Data.ProjectsData        ProjectsData	= new TSN.ERP.SharedComponents.Data.ProjectsData();
		protected Data.TeamsDataClass      TeamData		= new TSN.ERP.SharedComponents.Data.TeamsDataClass();
		protected Data.CompanyElmentsData  CompanyElementsData	= new TSN.ERP.SharedComponents.Data.CompanyElmentsData();
		protected EmployeeAccountabiltiy	EmpAccMag		= new EmployeeAccountabiltiy();
		protected TSN.ERP.Engine.SecurityManager	EntSecMag	= new TSN.ERP.Engine.SecurityManager();

		#endregion

		#region Constructor
		public ReportWriterManager()
		{
			this.DataComponents.Add(ProjectsData);
			this.DataComponents.Add(TeamData);
			this.DataComponents.Add(CompanyElementsData);
		}

		protected override void ObjectIntiated()
		{
			base.ObjectIntiated ();
			EmpAccMag.JoinSession(ActiveSession.Token);
			EntSecMag.JoinSession(ActiveSession.Token);
		}

		#endregion

		#region GetUserManagedEntities
		public DataSet GetUserManagedEntities( string FieldName )
		{
			DataSet dsResult = new DataSet();

			try
			{
				
				if( ActiveSession.Token != "" )
				{
					// set user ID value
					int userID    = ActiveSession.UserId;
					// set contact ID value
					int contactID = ActiveSession.ContactId;
					// get table And Column Name from fiield name parameter
					string[] tableAndColumnName = FieldName.Split( '.' );

					// check table name is one of the main security entities
					if( tableAndColumnName.Length == 2 )
					{
						if( ( tableAndColumnName[0] == "GEN_Projects" && tableAndColumnName[1] == "projectID" ) || ( tableAndColumnName[0] == "GEN_Employees" && tableAndColumnName[1] == "ContactID" ) || ( tableAndColumnName[0] == "GEN_Contacts" && tableAndColumnName[1] == "ContactID" ) || ( tableAndColumnName[0] == "GEN_Teams" && tableAndColumnName[1] == "TeamID" ) || ( tableAndColumnName[0] == "GEN_CompanyElments" && tableAndColumnName[1] == "CompElmentID" ) )
						{
							dsResult = CheckEntitiy( tableAndColumnName[0] , ActiveSession.IsAdmin );
						}
						else
						{
							// check the foriegn key's table name
							DataSet dsPrimTbl = GetForiegnKeyPrimaryTable( tableAndColumnName[1]   , tableAndColumnName[0] );
							if( dsPrimTbl != null && dsPrimTbl.Tables[ 0 ].Rows.Count != 0 )
							{
								if( dsPrimTbl.Tables[0].Rows[ 0 ][ "PrimaryTable" ].ToString()  == "GEN_Projects" || dsPrimTbl.Tables[0].Rows[ 0 ][ "PrimaryTable" ].ToString() == "GEN_Employees" || dsPrimTbl.Tables[0].Rows[ 0 ][ "PrimaryTable" ].ToString() == "GEN_Contacts" || dsPrimTbl.Tables[0].Rows[ 0 ][ "PrimaryTable" ].ToString() == "GEN_Teams" || dsPrimTbl.Tables[0].Rows[ 0 ][ "PrimaryTable" ].ToString() == "GEN_CompanyElments" )
									dsResult = CheckEntitiy( dsPrimTbl.Tables[0].Rows[ 0 ][ "PrimaryTable" ].ToString() , ActiveSession.IsAdmin );
								else
									return null;
							}

						}
					}

				}
			}
			catch( Exception ee )
			{

			}

			return dsResult;
		}

		#endregion

		#region CheckEntitiy
		DataSet CheckEntitiy( string  tableName , bool isAdmin )
		{
			DataSet dsResult = new DataSet();

			try
			{
				// intialize the result dataset columns
				dsResult.Tables.Add();
				dsResult.Tables[ 0 ].Columns.Add( "ID" );
				dsResult.Tables[ 0 ].Columns.Add( "Name" );
				

				// check table name
				switch( tableName )
				{
					case "GEN_Projects" :
					{
						Data.dsProjects dsUsrPrj = new TSN.ERP.SharedComponents.Data.dsProjects();
						if( isAdmin )
							dsUsrPrj.Merge(ProjectsData.List());
						else
						{
							// Get All projects that the user is a project manager to it 
							dsUsrPrj.Merge(ProjectsData.List("ProjectManager = " + ActiveSession.ContactId.ToString() + " or ProjectOwner = " + ActiveSession.UserId.ToString()  ));
							// Get All projects that the user has the role group of it 
							DataSet dsMngRlGrp = GetUserManagedRoleGroups( 1 );
							for( int i = 0 ; i < dsMngRlGrp.Tables[ 0 ].Rows.Count ; i++ )
							{
								// get the rolegroup for an entity and entity value ID
								int rlGrpID = EntSecMag.GetRuleGroupForEntity( dsMngRlGrp.Tables[ 0 ].Rows[ i ][ "RuleEntityValue" ].ToString() , 1 );
								if( rlGrpID != -1 && rlGrpID == int.Parse( dsMngRlGrp.Tables[ 0 ].Rows[ i ][ "RuleGroupID" ].ToString() ) )
								{
									if( dsUsrPrj.GEN_Projects.FindByprojectID( int.Parse( dsMngRlGrp.Tables[ 0 ].Rows[ i ][ "RuleEntityValue" ].ToString())) == null )
										dsUsrPrj.Merge(ProjectsData.List("projectID = " +  dsMngRlGrp.Tables[ 0 ].Rows[ i ][ "RuleEntityValue" ].ToString() ));
								}
							}
						}
						// set the ID and Name of the result entities
						if( dsUsrPrj.GEN_Projects.Count != 0 )
						{
							// Added by Sayed Moawad 24/09/2008
							if( isAdmin )
							{
								dsResult.Tables[ 0 ].Rows.Add( dsResult.Tables[ 0 ].NewRow() );
								dsResult.Tables[ 0 ].Rows[ 0 ][ 0 ] ="0";
								dsResult.Tables[ 0 ].Rows[ 0 ][ 1 ] = "All";
								for( int i = 1 ; i < dsUsrPrj.GEN_Projects.Rows.Count+1 ; i++ )
								{
									dsResult.Tables[ 0 ].Rows.Add( dsResult.Tables[ 0 ].NewRow() );
									dsResult.Tables[ 0 ].Rows[ i ][ 0 ] = dsUsrPrj.GEN_Projects[ i-1 ][ "projectID" ].ToString();
									dsResult.Tables[ 0 ].Rows[ i ][ 1 ] = dsUsrPrj.GEN_Projects[ i-1 ][ "ProjectName" ];
								}
                                
							}
								// end 
							else
							{
								for( int i = 0 ; i < dsUsrPrj.GEN_Projects.Rows.Count ; i++ )
								{
									dsResult.Tables[ 0 ].Rows.Add( dsResult.Tables[ 0 ].NewRow() );
									dsResult.Tables[ 0 ].Rows[ i ][ 0 ] = dsUsrPrj.GEN_Projects[ i ][ "projectID" ].ToString();
									dsResult.Tables[ 0 ].Rows[ i ][ 1 ] = dsUsrPrj.GEN_Projects[ i ][ "ProjectName" ];
								}
							}
						}
					}
						break;

					case "GEN_Employees" :
					case "GEN_Contacts" :
						Data.dsEmployee dsEmp = new TSN.ERP.SharedComponents.Data.dsEmployee();
						dsEmp.Merge(EmpAccMag.ViewAccountabilityEmployees());
						// set the ID and Name of the result entities
						if( dsEmp.GEN_Employees.Count != 0 )
						{
                            // added by sayed Moawad 29/10/2009
                            DataView dvEmp = dsEmp.Tables[0].DefaultView;

                            dvEmp.RowFilter = "EmployeeStatus = 1";
                            dvEmp.Sort = "FirstName, MiddleName, LastName";
                            dsEmp.Tables.Clear();
                            DataTable dt = new DataTable("GEN_Employees");
                            dt = CreateTable(dvEmp);
                            //dsEmp.Tables.Add(CreateTable(dvEmp));	
                           // end

							// Added by Sayed Moawad 24/09/2008
							if( isAdmin )
							{
								dsResult.Tables[ 0 ].Rows.Add( dsResult.Tables[ 0 ].NewRow() );
								dsResult.Tables[ 0 ].Rows[ 0 ][ 0 ] ="0";
								dsResult.Tables[ 0 ].Rows[ 0 ][ 1 ] = "All";
                                for (int i = 1; i < dt.Rows.Count + 1; i++)
								{
									dsResult.Tables[ 0 ].Rows.Add( dsResult.Tables[ 0 ].NewRow() );
                                    dsResult.Tables[0].Rows[i][0] = dt.Rows[i - 1]["ContactID"].ToString();
                                    dsResult.Tables[0].Rows[i][1] = dt.Rows[i - 1]["Fullname"];
								}
							}
							else
							{
                                for (int i = 0; i < dt.Rows.Count; i++)
								{
									dsResult.Tables[ 0 ].Rows.Add( dsResult.Tables[ 0 ].NewRow() );
                                    dsResult.Tables[0].Rows[i][0] = dt.Rows[i]["ContactID"].ToString();
                                    dsResult.Tables[0].Rows[i][1] = dt.Rows[i]["Fullname"];
								}
							}
						}
						break;

					case "GEN_Teams" :
					{
						Data.dsTeams dsUsrTeams = new TSN.ERP.SharedComponents.Data.dsTeams();
						if( isAdmin )
							dsUsrTeams.Merge(TeamData.List());
						else
						{
							// Get All teams that the user is a manager to it 
							dsUsrTeams.Merge(TeamData.List("TeamLeader = " + ActiveSession.ContactId.ToString() ));
							// Get All teams that the user has the role group of it 
							DataSet dsMngRlGrp = GetUserManagedRoleGroups( 4 );
							for( int i = 0 ; i < dsMngRlGrp.Tables[ 0 ].Rows.Count ; i++ )
							{
								// get the rolegroup for an entity and entity value ID
								int rlGrpID = EntSecMag.GetRuleGroupForEntity( dsMngRlGrp.Tables[ 0 ].Rows[ i ][ "RuleEntityValue" ].ToString() , 4 );
								if( rlGrpID != -1 && rlGrpID == int.Parse( dsMngRlGrp.Tables[ 0 ].Rows[ i ][ "RuleGroupID" ].ToString() ) )
								{
									if( dsUsrTeams.GEN_Teams.FindByTeamID( int.Parse( dsMngRlGrp.Tables[ 0 ].Rows[ i ][ "RuleEntityValue" ].ToString())) == null )
										dsUsrTeams.Merge(TeamData.List("TeamID = " +  dsMngRlGrp.Tables[ 0 ].Rows[ i ][ "RuleEntityValue" ].ToString() ));
								}
							}
						}
						// set the ID and Name of the result entities
						if( dsUsrTeams.GEN_Teams.Count != 0 )
						{
							// Added by Sayed Moawad 24/09/2008
							if( isAdmin )
							{
								dsResult.Tables[ 0 ].Rows.Add( dsResult.Tables[ 0 ].NewRow() );
								dsResult.Tables[ 0 ].Rows[ 0 ][ 0 ] ="0";
								dsResult.Tables[ 0 ].Rows[ 0 ][ 1 ] = "All";
								for( int i = 1 ; i < dsUsrTeams.GEN_Teams.Rows.Count+1 ; i++ )
								{
									dsResult.Tables[ 0 ].Rows.Add( dsResult.Tables[ 0 ].NewRow() );
									dsResult.Tables[ 0 ].Rows[ i ][ 0 ] = dsUsrTeams.GEN_Teams[ i-1 ][ "TeamID" ].ToString();
									dsResult.Tables[ 0 ].Rows[ i ][ 1 ] = dsUsrTeams.GEN_Teams[ i-1 ][ "TeamName" ];
								}
							}
							else
							{
								for( int i = 0 ; i < dsUsrTeams.GEN_Teams.Rows.Count ; i++ )
								{
									dsResult.Tables[ 0 ].Rows.Add( dsResult.Tables[ 0 ].NewRow() );
									dsResult.Tables[ 0 ].Rows[ i ][ 0 ] = dsUsrTeams.GEN_Teams[ i ][ "TeamID" ].ToString();
									dsResult.Tables[ 0 ].Rows[ i ][ 1 ] = dsUsrTeams.GEN_Teams[ i ][ "TeamName" ];
								}
							}
						}
					}
						break;

					case "GEN_CompanyElments" :
					{
						Data.dsCompanyElements dsUsrCompElm = new TSN.ERP.SharedComponents.Data.dsCompanyElements();
						if( isAdmin )
							dsUsrCompElm.Merge(CompanyElementsData.List());
						else
						{
							// Get All company elements that the user is a manager to it 
							dsUsrCompElm.Merge(CompanyElementsData.List("ContactID = " + ActiveSession.ContactId.ToString() ));
							// Get All teams that the user has the role group of it 
							DataSet dsMngRlGrp = GetUserManagedRoleGroups( 2 );
							for( int i = 0 ; i < dsMngRlGrp.Tables[ 0 ].Rows.Count ; i++ )
							{
								// get the rolegroup for an entity and entity value ID
								int rlGrpID = EntSecMag.GetRuleGroupForEntity( dsMngRlGrp.Tables[ 0 ].Rows[ i ][ "RuleEntityValue" ].ToString() , 2 );
								if( rlGrpID != -1 && rlGrpID == int.Parse( dsMngRlGrp.Tables[ 0 ].Rows[ i ][ "RuleGroupID" ].ToString() ) )
								{
									if( dsUsrCompElm.GEN_CompanyElments.FindByCompElmentID( int.Parse( dsMngRlGrp.Tables[ 0 ].Rows[ i ][ "RuleEntityValue" ].ToString())) == null )
										dsUsrCompElm.Merge(CompanyElementsData.List("CompElmentID = " +  dsMngRlGrp.Tables[ 0 ].Rows[ i ][ "RuleEntityValue" ].ToString() ));
								}
							}
						}
						// set the ID and Name of the result entities
						if( dsUsrCompElm.GEN_CompanyElments.Count != 0 )
						{
							// Added by Sayed Moawad 24/09/2008
							if( isAdmin )
							{
								dsResult.Tables[ 0 ].Rows.Add( dsResult.Tables[ 0 ].NewRow() );
								dsResult.Tables[ 0 ].Rows[ 0 ][ 0 ] ="0";
								dsResult.Tables[ 0 ].Rows[ 0 ][ 1 ] = "All";
								for( int i = 1 ; i < dsUsrCompElm.GEN_CompanyElments.Rows.Count+1 ; i++ )
								{
									dsResult.Tables[ 0 ].Rows.Add( dsResult.Tables[ 0 ].NewRow() );
									dsResult.Tables[ 0 ].Rows[ i ][ 0 ] = dsUsrCompElm.GEN_CompanyElments[ i -1][ "CompElmentID" ].ToString();
									dsResult.Tables[ 0 ].Rows[ i ][ 1 ] = dsUsrCompElm.GEN_CompanyElments[ i -1][ "CEName" ];
								}
							}

							//end
							else // Basant
							{
								for( int i = 0 ; i < dsUsrCompElm.GEN_CompanyElments.Rows.Count ; i++ )
								{
									dsResult.Tables[ 0 ].Rows.Add( dsResult.Tables[ 0 ].NewRow() );
									dsResult.Tables[ 0 ].Rows[ i ][ 0 ] = dsUsrCompElm.GEN_CompanyElments[ i ][ "CompElmentID" ].ToString();
									dsResult.Tables[ 0 ].Rows[ i ][ 1 ] = dsUsrCompElm.GEN_CompanyElments[ i ][ "CEName" ];
								}
							}
						}
					}
						break;

				}
			}
			
			catch( Exception ee )
			{

			}
			return dsResult;
		}

		#endregion
        # region create a table from dataview
        /// <summary>
        /// Convert given dataview to datatable
        /// </summary>
        /// <param name="obDataView"></param>
        /// <returns></returns>
        public static DataTable CreateTable(DataView obDataView)
        {  
            if (null == obDataView)
            {
                throw new ArgumentNullException
                    ("DataView", "Invalid DataView object specified");
            }



            DataTable obNewDt = obDataView.Table.Clone();
            int idx = 0;
            string[] strColNames = new string[obNewDt.Columns.Count];
            foreach (DataColumn col in obNewDt.Columns)
            {
                strColNames[idx++] = col.ColumnName;
            }

            System.Collections.IEnumerator viewEnumerator = obDataView.GetEnumerator();
            while (viewEnumerator.MoveNext())
            {
                DataRowView drv = (DataRowView)viewEnumerator.Current;
                DataRow dr = obNewDt.NewRow();
                try
                {
                    foreach (string strName in strColNames)
                    {
                        dr[strName] = drv[strName];
                    }
                }
                catch (Exception ex)
                {

                }
                obNewDt.Rows.Add(dr);
            }
           
            return obNewDt;
        }
        #endregion	
		#region GetForiegnKeyPrimaryTable
		private DataSet GetForiegnKeyPrimaryTable(string columnName , string tableName )
		{
			DataSet ds = new DataSet();
			OleDbDataAdapter sqlAdp = new OleDbDataAdapter();
			sqlAdp.SelectCommand = new OleDbCommand();
			sqlAdp.SelectCommand.Connection = new OleDbConnection();

			try
			{
				
				//sqlAdp.SelectCommand.Connection.ConnectionString = ProjectsData.Connection.ConnectionString;
				//sqlAdp.SelectCommand.Connection.Open();
				sqlAdp.SelectCommand.Connection =  ProjectsData.Connection;
				sqlAdp.SelectCommand.CommandText = "SELECT sysobjects.name AS PrimaryTable, sysforeignkeys.* FROM sysforeignkeys INNER JOIN "+
					"sysobjects ON sysforeignkeys.rkeyid = sysobjects.id "+
					"WHERE (sysforeignkeys.fkeyid IN (SELECT     syscolumns.id "+
					"FROM  syscolumns INNER JOIN sysobjects ON syscolumns.id = sysobjects.id "+
					"WHERE   (syscolumns.name = '"+ columnName +"') AND (sysobjects.name = '"+ tableName +"'))) AND (sysforeignkeys.fkey IN "+
					"(SELECT syscolumns.colid FROM syscolumns INNER JOIN sysobjects ON syscolumns.id = sysobjects.id "+
					" WHERE  (syscolumns.name = '"+ columnName +"') AND (sysobjects.name = '"+ tableName +"')))";

				sqlAdp.Fill(ds);
				sqlAdp.SelectCommand.Connection.Close();
				
			}
			catch (Exception ex)
			{
				
			}
			return ds;
		}
		#endregion

		#region GetUserManagedRoleGroups
		private DataSet GetUserManagedRoleGroups( int EntityType )
		{
			DataSet ds = new DataSet();
			OleDbDataAdapter sqlAdp = new OleDbDataAdapter();
			sqlAdp.SelectCommand = new OleDbCommand();
			sqlAdp.SelectCommand.Connection = new OleDbConnection();

			try
			{
				
				//sqlAdp.SelectCommand.Connection.ConnectionString = ProjectsData.Connection.ConnectionString;
				//sqlAdp.SelectCommand.Connection.Open();
				sqlAdp.SelectCommand.Connection =  ProjectsData.Connection;
				sqlAdp.SelectCommand.CommandText = "SELECT DISTINCT SEC_RuleEntity.RuleEntityValue, SEC_RuleGroup.RuleGroupID, SEC_RuleGroup.RuleGroupName "+
												    "FROM  SEC_UsersGroups INNER JOIN "+
												   "SEC_UserXUserGroup ON SEC_UsersGroups.UserGroupID = SEC_UserXUserGroup.UserGroupID INNER JOIN "+
												   "SEC_Users ON SEC_UserXUserGroup.UserID = SEC_Users.UserID INNER JOIN "+
												   " SEC_UsersGroupsXRulesGroups ON SEC_UsersGroups.UserGroupID = SEC_UsersGroupsXRulesGroups.UserGroupID INNER JOIN "+
												   "SEC_RuleGroup ON SEC_UsersGroupsXRulesGroups.RuleGroupID = SEC_RuleGroup.RuleGroupID INNER JOIN "+
												   "SEC_RuleEntityXRuleGroup ON SEC_RuleGroup.RuleGroupID = SEC_RuleEntityXRuleGroup.RuleGroupID INNER JOIN "+
												   "SEC_RuleEntity ON SEC_RuleEntityXRuleGroup.RuleEntityID = SEC_RuleEntity.RuleEntityID INNER JOIN "+
												   "SEC_Rules ON SEC_RuleEntity.RuleID = SEC_Rules.RuleID INNER JOIN "+
												   "SEC_Entities ON SEC_Rules.EntityID = SEC_Entities.EntityID "+
												   "WHERE  (SEC_Users.UserID ="+ ActiveSession.UserId +") AND (SEC_Entities.EntityID = "+ EntityType +")";

				sqlAdp.Fill(ds);
				sqlAdp.SelectCommand.Connection.Close();
				
			}
			catch (Exception ex)
			{
				
			}
			return ds;
		}
		#endregion
	}
}
