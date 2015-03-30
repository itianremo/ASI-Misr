using System;
using System.Data;
using TSN.ERP.Engine;
namespace TSN.ERP.SharedComponents
{
	/// <summary>
	/// Summary description for TaskTransactions.
	/// </summary>
	public class AssginmentTransactions : TSN.ERP.Engine.BussinesObject
	{

		protected Data.AssignmentTrxsDataClass AssTrxData		 = new TSN.ERP.SharedComponents.Data.AssignmentTrxsDataClass();
		protected Data.TransactionsData TransData				 = new TSN.ERP.SharedComponents.Data.TransactionsData();
		protected CheckSecurity checkSec = new CheckSecurity();

		protected Data.AssignmentsDataClass AssData = new TSN.ERP.SharedComponents.Data.AssignmentsDataClass();

		public AssginmentTransactions()
		{
			//
			// TODO: Add constructor logic here
			//

			this.DataComponents.Add(AssData);
			this.DataComponents.Add(AssTrxData);
			this.DataComponents.Add(TransData);
		}

				
		#region ListAllAssignmentTransactions
		[AtrERPMethodType(ERPMethodType.List)]
		public DataSet ListAllAssignmentTransactions( int  assignmentID  )
		{
			//
			if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasAccessRule( (int)TSN.ERP.Security.Rules.GeneralRules.ListAllAssignmentTransactions )))
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ViewAllAssignments );
				return  null; 
			}
 
			return this.AssTrxData.List( assignmentID );
		}


		#endregion 

		#region AddAssignmentTransaction

		public int AddAssignmentTransaction( DataSet assTrx )
		{
			//
			int trxID = this.TransData.CreateTransaction(this.ActiveSession.UserSecurityInfo.UserID);
			((Data.dsAssignmentTransaction) assTrx ).GEN_AssgimentTransactions[ 0 ].TransID = trxID ;
			
			return this.AssTrxData.Add(assTrx , false );

		}


		#endregion 

		#region ApproveAssignment

		public int ApproveAssignment( int assignmentID  )
		{
			//
			int result = 0 ;
			// get assignment
			Data.dsAssignments  ds = new TSN.ERP.SharedComponents.Data.dsAssignments();
			ds.Merge ( (Data.dsAssignments) AssData.List( assignmentID ) );
			
			if( ds.Tables[ 0 ].Rows.Count != 0 )
			{
				if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasCompanyElementAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.CompanyElementRules.ApproveAssignment ) || checkSec.HasProjectAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.ProjectRules.ApproveAssignment ) || checkSec.HasTeamAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.TeamRules.ApproveAssignment )|| checkSec.HasAssignedToAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.ApproveAssignment ) || checkSec.HasCreatorAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.ApproveAssignment ) || checkSec.HasEmployeeAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.ApproveAssignment ) || checkSec.HasAccessRule( (int)TSN.ERP.Security.Rules.GeneralRules.ApproveAssignment )))
				{
					SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ApproveAssignment );
					return  0; 
				}

				// check assignment status
				if ( ds.GEN_Assignments[ 0 ].AssignmentStatus == (Int32) Data.AssignmentsDataClass.AssignmentStatus.RequestToClose )
				{	
					// add assignment transaction
					Data.dsAssignmentTransaction assTrx = new TSN.ERP.SharedComponents.Data.dsAssignmentTransaction();
					assTrx.EnforceConstraints = false;

					Data.dsAssignmentTransaction.GEN_AssgimentTransactionsRow row = assTrx.GEN_AssgimentTransactions.NewGEN_AssgimentTransactionsRow();
					
					row.AssignmentD		= assignmentID;
					row.AssTransType    = 0 ;
					row.OLdEvalution    = ds.GEN_Assignments[ 0 ].AssignmentEvalutation ;
					row.OldStatus       = ds.GEN_Assignments[ 0 ].AssignmentStatus ;
					row.NewStatus		= (Int32)Data.AssignmentsDataClass.AssignmentStatus.Closed ;
					row.NewEvalutation  = (Int32)Data.AssignmentsDataClass.AssignmentEvaluation.Approved ;
					
					assTrx.GEN_AssgimentTransactions.AddGEN_AssgimentTransactionsRow( row );
					result = AddAssignmentTransaction( assTrx );

					// update assignment 
					ds.GEN_Assignments[ 0 ].AssignmentEvalutation = (Int32)Data.AssignmentsDataClass.AssignmentEvaluation.Approved ;
					ds.GEN_Assignments[ 0 ].AssignmentStatus	  = (Int32)Data.AssignmentsDataClass.AssignmentStatus.Closed ;
					result =  AssData.Update( ds );

				}
				else
					ActiveSession.SetError( new TSN.ERP.Engine.ERPError( 0 , "Invalid Assignmemt Status" , 0 , null ));
			}
			
			return	result;
		}

		#endregion 

		#region RejectAssignment

		public int RejectAssignment( int assignmentID  )
		{
			//
			int result = 0 ;
			// get assignment
			Data.dsAssignments  ds = new TSN.ERP.SharedComponents.Data.dsAssignments();
			ds.Merge ( (Data.dsAssignments) AssData.List( assignmentID ) );
			
			if( ds.Tables[ 0 ].Rows.Count != 0 )
			{
				if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasCompanyElementAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.CompanyElementRules.RejectAssignment ) || checkSec.HasProjectAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.ProjectRules.RejectAssignment ) || checkSec.HasTeamAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.TeamRules.RejectAssignment )|| checkSec.HasAssignedToAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.RejectAssignment ) || checkSec.HasCreatorAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.RejectAssignment )|| checkSec.HasEmployeeAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.ApproveAssignment ) || checkSec.HasAccessRule( (int)TSN.ERP.Security.Rules.GeneralRules.RejectAssignment )))
				{
					SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.RejectAssignment );
					return  0; 
				}

				// check assignment status
				if ( ds.GEN_Assignments[ 0 ].AssignmentStatus == (Int32) Data.AssignmentsDataClass.AssignmentStatus.RequestToClose )
				{	
					// add assignment transaction
					Data.dsAssignmentTransaction assTrx = new TSN.ERP.SharedComponents.Data.dsAssignmentTransaction();
					assTrx.EnforceConstraints = false;

					Data.dsAssignmentTransaction.GEN_AssgimentTransactionsRow row = assTrx.GEN_AssgimentTransactions.NewGEN_AssgimentTransactionsRow();
					
					row.AssignmentD		= assignmentID;
					row.AssTransType    = 0 ;
					row.OLdEvalution    = ds.GEN_Assignments[ 0 ].AssignmentEvalutation ;
					row.OldStatus       = ds.GEN_Assignments[ 0 ].AssignmentStatus ;
					row.NewStatus		= (Int32)Data.AssignmentsDataClass.AssignmentStatus.Closed ;
					row.NewEvalutation  = (Int32)Data.AssignmentsDataClass.AssignmentEvaluation.Rejected ;
					
					assTrx.GEN_AssgimentTransactions.AddGEN_AssgimentTransactionsRow( row );
					result = AddAssignmentTransaction( assTrx );

					// update assignment 
					ds.GEN_Assignments[ 0 ].AssignmentEvalutation = (Int32)Data.AssignmentsDataClass.AssignmentEvaluation.Rejected ;
					ds.GEN_Assignments[ 0 ].AssignmentStatus	  = (Int32)Data.AssignmentsDataClass.AssignmentStatus.Closed ;
					result = AssData.Update( ds );

				}
				else
					ActiveSession.SetError( new TSN.ERP.Engine.ERPError( 0 , "Invalid Assignmemt Status" , 0 , null ));
			}
			
			return	result;
		}

		#endregion 
	
		#region ReassignedAssignment

		public int ReassignedAssignment( int assignmentID  )
		{
			//
			int result = 0;
			// get assignment
			Data.dsAssignments  ds = new TSN.ERP.SharedComponents.Data.dsAssignments();
			ds.Merge ( (Data.dsAssignments) AssData.List( assignmentID ) );
			
			if( ds.Tables[ 0 ].Rows.Count != 0 )
			{
				if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasCompanyElementAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.CompanyElementRules.ReassignedAssignment ) || checkSec.HasProjectAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.ProjectRules.ReassignedAssignment ) || checkSec.HasTeamAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.TeamRules.ReassignedAssignment )|| checkSec.HasAssignedToAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.ReassignedAssignment ) || checkSec.HasCreatorAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.ReassignedAssignment ) || checkSec.HasEmployeeAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.ReassignedAssignment ) || checkSec.HasAccessRule( (int)TSN.ERP.Security.Rules.GeneralRules.ReassignedAssignment )))
				{
					SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.ReassignedAssignment );
					return  0; 
				}

				// check assignment status
				if ( ds.GEN_Assignments[ 0 ].AssignmentStatus == (Int32) Data.AssignmentsDataClass.AssignmentStatus.RequestToClose )
				{	
					// add assignment transaction
					Data.dsAssignmentTransaction assTrx = new TSN.ERP.SharedComponents.Data.dsAssignmentTransaction();
					assTrx.EnforceConstraints = false;

					Data.dsAssignmentTransaction.GEN_AssgimentTransactionsRow row = assTrx.GEN_AssgimentTransactions.NewGEN_AssgimentTransactionsRow();
					
					row.AssignmentD		= assignmentID;
					row.AssTransType    = 0 ;
					row.OLdEvalution    = ds.GEN_Assignments[ 0 ].AssignmentEvalutation ;
					row.OldStatus       = ds.GEN_Assignments[ 0 ].AssignmentStatus ;
					row.NewStatus		= (Int32)Data.AssignmentsDataClass.AssignmentStatus.Closed ;
					row.NewEvalutation  = (Int32)Data.AssignmentsDataClass.AssignmentEvaluation.Reassigned ;
					
					assTrx.GEN_AssgimentTransactions.AddGEN_AssgimentTransactionsRow( row );
					result = AddAssignmentTransaction( assTrx );

					// update assignment 
					ds.GEN_Assignments[ 0 ].AssignmentEvalutation = (Int32)Data.AssignmentsDataClass.AssignmentEvaluation.Reassigned ;
					ds.GEN_Assignments[ 0 ].AssignmentStatus	  = (Int32)Data.AssignmentsDataClass.AssignmentStatus.Closed ;
					result = AssData.Update( ds );

				}
				else
					ActiveSession.SetError( new TSN.ERP.Engine.ERPError( 0 , "Invalid Assignmemt Status" , 0 , null ));
			}
			
			return	result;
		}

		#endregion 

		#region CancelAssignment

		public int CancelAssignment( int assignmentID  )
		{
			int result = 0;
			// get assignment
			Data.dsAssignments  ds = new TSN.ERP.SharedComponents.Data.dsAssignments();
			ds.Merge ( (Data.dsAssignments) AssData.List( assignmentID ) );
			
			if( ds.Tables[ 0 ].Rows.Count != 0 )
			{
				if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasCompanyElementAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.CompanyElementRules.CancelAssignment ) || checkSec.HasProjectAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.ProjectRules.CancelAssignment ) || checkSec.HasTeamAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.TeamRules.CancelAssignment )|| checkSec.HasAssignedToAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.CancelAssignment ) || checkSec.HasCreatorAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.CancelAssignment ) || checkSec.HasEmployeeAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.CancelAssignment ) || checkSec.HasAccessRule( (int)TSN.ERP.Security.Rules.GeneralRules.CancelAssignment )))
				{
					SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.CancelAssignment );
					return  0; 
				}

				// check assignment status
				if ( ds.GEN_Assignments[ 0 ].AssignmentStatus != (Int32) Data.AssignmentsDataClass.AssignmentStatus.Closed )
				{	
					// add assignment transaction
					Data.dsAssignmentTransaction assTrx = new TSN.ERP.SharedComponents.Data.dsAssignmentTransaction();
					assTrx.EnforceConstraints = false;

					Data.dsAssignmentTransaction.GEN_AssgimentTransactionsRow row = assTrx.GEN_AssgimentTransactions.NewGEN_AssgimentTransactionsRow();
					
					row.AssignmentD		= assignmentID;
					row.AssTransType    = 0 ;
					row.OLdEvalution    = ds.GEN_Assignments[ 0 ].AssignmentEvalutation ;
					row.OldStatus       = ds.GEN_Assignments[ 0 ].AssignmentStatus ;
					row.NewStatus		= (Int32)Data.AssignmentsDataClass.AssignmentStatus.Canceled ;
					row.NewEvalutation  = (Int32)Data.AssignmentsDataClass.AssignmentEvaluation.NotEvaluated ;
					
					assTrx.GEN_AssgimentTransactions.AddGEN_AssgimentTransactionsRow( row );
					result = AddAssignmentTransaction( assTrx );

					// update assignment 
					ds.GEN_Assignments[ 0 ].AssignmentEvalutation = (Int32)Data.AssignmentsDataClass.AssignmentEvaluation.NotEvaluated ;
					ds.GEN_Assignments[ 0 ].AssignmentStatus	  = (Int32)Data.AssignmentsDataClass.AssignmentStatus.Canceled ;
					result = AssData.Update( ds );

				}
				else
					ActiveSession.SetError( new TSN.ERP.Engine.ERPError( 0 , "Can not cancel a closed assignmemt " , 0 , null ));
			}
			
			return	result;
		}

		#endregion 

		#region RequestToCloseAssignment

		public int RequestToCloseAssignment( int assignmentID  )
		{
			//
			int result = 0;
			// get assignment
			Data.dsAssignments  ds = new TSN.ERP.SharedComponents.Data.dsAssignments();
			ds.Merge ( (Data.dsAssignments) AssData.List( assignmentID ) );
			
			if( ds.Tables[ 0 ].Rows.Count != 0 )
			{
				if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasCompanyElementAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.CompanyElementRules.RequestToCloseAssignment ) || checkSec.HasProjectAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.ProjectRules.RequestToCloseAssignment ) || checkSec.HasTeamAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.TeamRules.RequestToCloseAssignment )|| checkSec.HasAssignedToAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.RequestToCloseAssignment ) || checkSec.HasCreatorAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.RequestToCloseAssignment ) || checkSec.HasEmployeeAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.RequestToCloseAssignment ) || checkSec.HasAccessRule( (int)TSN.ERP.Security.Rules.GeneralRules.RequestToCloseAssignment )))
				{
					SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.RequestToCloseAssignment );
					return  0; 
				}

				// check assignment status
				if ( ds.GEN_Assignments[ 0 ].AssignmentStatus == (Int32) Data.AssignmentsDataClass.AssignmentStatus.Ongoing )
				{	
					// add assignment transaction
					Data.dsAssignmentTransaction assTrx = new TSN.ERP.SharedComponents.Data.dsAssignmentTransaction();
					assTrx.EnforceConstraints = false;

					Data.dsAssignmentTransaction.GEN_AssgimentTransactionsRow row = assTrx.GEN_AssgimentTransactions.NewGEN_AssgimentTransactionsRow();
					
					row.AssignmentD		= assignmentID;
					row.AssTransType    = 0 ;
					row.OLdEvalution    = ds.GEN_Assignments[ 0 ].AssignmentEvalutation ;
					row.OldStatus       = ds.GEN_Assignments[ 0 ].AssignmentStatus ;
					row.NewStatus		= (Int32)Data.AssignmentsDataClass.AssignmentStatus.RequestToClose ;
					row.NewEvalutation  = (Int32)Data.AssignmentsDataClass.AssignmentEvaluation.NotEvaluated ;
					
					assTrx.GEN_AssgimentTransactions.AddGEN_AssgimentTransactionsRow( row );
					result = AddAssignmentTransaction( assTrx );

					// update assignment 
					ds.GEN_Assignments[ 0 ].AssignmentStatus	  = (Int32)Data.AssignmentsDataClass.AssignmentStatus.RequestToClose ;
					ds.GEN_Assignments[ 0 ].AssignmentEvalutation = (Int32)Data.AssignmentsDataClass.AssignmentEvaluation.NotEvaluated ;
					
					result = AssData.Update( ds );

				}
				else
					ActiveSession.SetError( new TSN.ERP.Engine.ERPError( 0 , "Assignmemt should be ongoing " , 0 , null ));
			}
			
			return	result;
		}

		#endregion 

		#region SetOngoingAssignment

		public int SetOngoingAssignment( int assignmentID  )
		{
			//
			int result = 0;
			// get assignment
			Data.dsAssignments  ds = new TSN.ERP.SharedComponents.Data.dsAssignments();
			ds.Merge ( (Data.dsAssignments) AssData.List( assignmentID ) );
			
			if( ds.Tables[ 0 ].Rows.Count != 0 )
			{
				if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasCompanyElementAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.CompanyElementRules.SetOngoingAssignment ) || checkSec.HasProjectAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.ProjectRules.SetOngoingAssignment ) || checkSec.HasTeamAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.TeamRules.SetOngoingAssignment )|| checkSec.HasAssignedToAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.SetOngoingAssignment ) || checkSec.HasCreatorAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.SetOngoingAssignment ) || checkSec.HasEmployeeAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.SetOngoingAssignment ) || checkSec.HasAccessRule( (int)TSN.ERP.Security.Rules.GeneralRules.SetOngoingAssignment )))
				{
					SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.SetOngoingAssignment );
					return  0; 
				}

				// check assignment status
				if ( ds.GEN_Assignments[ 0 ].AssignmentStatus == (Int32) Data.AssignmentsDataClass.AssignmentStatus.Planed )
				{	
					// add assignment transaction
					Data.dsAssignmentTransaction assTrx = new TSN.ERP.SharedComponents.Data.dsAssignmentTransaction();
					assTrx.EnforceConstraints = false;

					Data.dsAssignmentTransaction.GEN_AssgimentTransactionsRow row = assTrx.GEN_AssgimentTransactions.NewGEN_AssgimentTransactionsRow();
					
					row.AssignmentD		= assignmentID;
					row.AssTransType    = 0 ;
					row.OLdEvalution    = ds.GEN_Assignments[ 0 ].AssignmentEvalutation ;
					row.OldStatus       = ds.GEN_Assignments[ 0 ].AssignmentStatus ;
					row.NewStatus		= (Int32)Data.AssignmentsDataClass.AssignmentStatus.Ongoing ;
					row.NewEvalutation  = (Int32)Data.AssignmentsDataClass.AssignmentEvaluation.NotEvaluated ;
					
					assTrx.GEN_AssgimentTransactions.AddGEN_AssgimentTransactionsRow( row );
					result = AddAssignmentTransaction( assTrx );

					// update assignment 
					ds.GEN_Assignments[ 0 ].AssignmentStatus	  = (Int32)Data.AssignmentsDataClass.AssignmentStatus.Ongoing ;
					ds.GEN_Assignments[ 0 ].AssignmentEvalutation = (Int32)Data.AssignmentsDataClass.AssignmentEvaluation.NotEvaluated ;
					
					result = AssData.Update( ds );

				}
				else
					ActiveSession.SetError( new TSN.ERP.Engine.ERPError( 0 , "Assignmemt should be planed " , 0 , null ));
			}
			
			return	result;
		}

		#endregion  

		#region CloseAssignment

		public int CloseAssignment( int assignmentID  )
		{
			//
			int result = 0;
			// get assignment
			Data.dsAssignments  ds = new TSN.ERP.SharedComponents.Data.dsAssignments();
			ds.Merge ( AssData.List( assignmentID ) );


			if( ds.Tables[ 0 ].Rows.Count != 0 )
			{
				if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasCompanyElementAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.CompanyElementRules.CloseAssignment ) || checkSec.HasProjectAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.ProjectRules.CloseAssignment ) || checkSec.HasTeamAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.TeamRules.CloseAssignment )|| checkSec.HasAssignedToAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.CloseAssignment ) || checkSec.HasCreatorAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.CloseAssignment ) || checkSec.HasEmployeeAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.CloseAssignment ) || checkSec.HasAccessRule( (int)TSN.ERP.Security.Rules.GeneralRules.CloseAssignment )))
				{
					SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.CloseAssignment );
					return  0; 
				}

				// check assignment status
				if ( ds.GEN_Assignments[ 0 ].AssignmentStatus != (Int32) Data.AssignmentsDataClass.AssignmentStatus.Closed && ds.GEN_Assignments[ 0 ].AssignmentStatus != (Int32) Data.AssignmentsDataClass.AssignmentStatus.Canceled )
				{	
					// add assignment transaction
					Data.dsAssignmentTransaction assTrx = new TSN.ERP.SharedComponents.Data.dsAssignmentTransaction();
					assTrx.EnforceConstraints = false;

					Data.dsAssignmentTransaction.GEN_AssgimentTransactionsRow row = assTrx.GEN_AssgimentTransactions.NewGEN_AssgimentTransactionsRow();
					
					row.AssignmentD		= assignmentID;
					row.AssTransType    = 0 ;
					row.OLdEvalution    = ds.GEN_Assignments[ 0 ].AssignmentEvalutation ;
					row.OldStatus       = ds.GEN_Assignments[ 0 ].AssignmentStatus ;
					row.NewStatus		= (Int32)Data.AssignmentsDataClass.AssignmentStatus.Closed ;
					row.NewEvalutation  = (Int32)Data.AssignmentsDataClass.AssignmentEvaluation.NotEvaluated ;
					
					assTrx.GEN_AssgimentTransactions.AddGEN_AssgimentTransactionsRow( row );
					result = AddAssignmentTransaction( assTrx );

					// update assignment 
					ds.GEN_Assignments[ 0 ].AssignmentEvalutation = (Int32)Data.AssignmentsDataClass.AssignmentEvaluation.NotEvaluated ;
					ds.GEN_Assignments[ 0 ].AssignmentStatus	  = (Int32)Data.AssignmentsDataClass.AssignmentStatus.Closed ;
					result = AssData.Update( ds );

				}
				else
					ActiveSession.SetError( new TSN.ERP.Engine.ERPError( 0 , "Invalid Assignmemt Status" , 0 , null ));
			}
			
			return	result;
		}

		#endregion 

		#region OpenAssignment

		public int OpenAssignment( int assignmentID  )
		{
			//
			int result = 0;
			// get assignment
			Data.dsAssignments  ds = new TSN.ERP.SharedComponents.Data.dsAssignments();
			ds.Merge ( AssData.List( assignmentID ) );


			if( ds.Tables[ 0 ].Rows.Count != 0 )
			{
				if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasCompanyElementAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.CompanyElementRules.CloseAssignment ) || checkSec.HasProjectAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.ProjectRules.CloseAssignment ) || checkSec.HasTeamAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.TeamRules.CloseAssignment )|| checkSec.HasAssignedToAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.CloseAssignment ) || checkSec.HasCreatorAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.CloseAssignment ) || checkSec.HasEmployeeAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.CloseAssignment ) || checkSec.HasAccessRule( (int)TSN.ERP.Security.Rules.GeneralRules.CloseAssignment )))
				{
					SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.CloseAssignment );
					return  0; 
				}

//				// check assignment status
//				if ( ds.GEN_Assignments[ 0 ].AssignmentStatus != (Int32) Data.AssignmentsDataClass.AssignmentStatus.Closed && ds.GEN_Assignments[ 0 ].AssignmentStatus != (Int32) Data.AssignmentsDataClass.AssignmentStatus.Canceled )
//				{	
					// add assignment transaction
					Data.dsAssignmentTransaction assTrx = new TSN.ERP.SharedComponents.Data.dsAssignmentTransaction();
					assTrx.EnforceConstraints = false;

					Data.dsAssignmentTransaction.GEN_AssgimentTransactionsRow row = assTrx.GEN_AssgimentTransactions.NewGEN_AssgimentTransactionsRow();
					
					row.AssignmentD		= assignmentID;
					row.AssTransType    = 0 ;
					row.OLdEvalution    = ds.GEN_Assignments[ 0 ].AssignmentEvalutation ;
					row.OldStatus       = ds.GEN_Assignments[ 0 ].AssignmentStatus ;
					row.NewStatus		= (Int32)Data.AssignmentsDataClass.AssignmentStatus.Ongoing ;
					row.NewEvalutation  = (Int32)Data.AssignmentsDataClass.AssignmentEvaluation.NotEvaluated ;
					
					assTrx.GEN_AssgimentTransactions.AddGEN_AssgimentTransactionsRow( row );
					result = AddAssignmentTransaction( assTrx );

					// update assignment 
					ds.GEN_Assignments[ 0 ].AssignmentEvalutation = (Int32)Data.AssignmentsDataClass.AssignmentEvaluation.NotEvaluated ;
					ds.GEN_Assignments[ 0 ].AssignmentStatus	  = (Int32)Data.AssignmentsDataClass.AssignmentStatus.Ongoing ;
					result = AssData.Update( ds );

//				}
//				else
//					ActiveSession.SetError( new TSN.ERP.Engine.ERPError( 0 , "Invalid Assignmemt Status" , 0 , null ));
			}
			
			return	result;
		}

		#endregion 

		#region Get maximum assignment transaction date
		public DateTime GetMaxAssTransDate( int assignmentID  )
		{
			DateTime dt = AssTrxData.GetMaxAssTransDate(assignmentID);
			return dt;
		}
		#endregion 

		#region SetAssignmentScore
		public int SetAssignmentScore( int assignmentID , short score )
		{
			//
			int result = 0 ;
			// get assignment
			Data.dsAssignments  ds = new TSN.ERP.SharedComponents.Data.dsAssignments();
			ds.Merge ( (Data.dsAssignments) AssData.List( assignmentID ) );
			
			if( ds.Tables[ 0 ].Rows.Count != 0 )
			{
				if ( ! ( ActiveSession.UserSecurityInfo.Administrator || checkSec.HasCompanyElementAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.CompanyElementRules.SetAssignmentScore ) || checkSec.HasProjectAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.ProjectRules.SetAssignmentScore ) || checkSec.HasTeamAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.TeamRules.SetAssignmentScore )|| checkSec.HasAssignedToAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.SetAssignmentScore ) || checkSec.HasCreatorAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.SetAssignmentScore ) || checkSec.HasEmployeeAssignmentAccess( ds , (int)TSN.ERP.Security.Rules.EmployeeRules.SetAssignmentScore ) || checkSec.HasAccessRule( (int)TSN.ERP.Security.Rules.GeneralRules.SetAssignmentScore )))
				{
					SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.SetAssignmentScore );
					return  0; 
				}

				// add assignment transaction
				Data.dsAssignmentTransaction assTrx = new TSN.ERP.SharedComponents.Data.dsAssignmentTransaction();
				assTrx.EnforceConstraints = false;

				Data.dsAssignmentTransaction.GEN_AssgimentTransactionsRow row = assTrx.GEN_AssgimentTransactions.NewGEN_AssgimentTransactionsRow();
					
				row.AssignmentD		= assignmentID;
				row.AssTransType    = 0 ;
				row.OLdEvalution    = ds.GEN_Assignments[ 0 ].AssignmentEvalutation ;
				row.OldStatus       = ds.GEN_Assignments[ 0 ].AssignmentStatus ;
				row.NewStatus		= ds.GEN_Assignments[ 0 ].AssignmentEvalutation ;
				row.NewEvalutation  = ds.GEN_Assignments[ 0 ].AssignmentStatus ;
					
				assTrx.GEN_AssgimentTransactions.AddGEN_AssgimentTransactionsRow( row );
				result = AddAssignmentTransaction( assTrx );

				// update assignment 
				ds.GEN_Assignments[ 0 ].AssignmentScore = score;
				result =  AssData.Update( ds );
				
			}
			
			return	result;
	
		}
		#endregion 
		
		public bool ChangeResponspility(int AssID,int ReponseID)
		{
			Data.dsAssignments dsAss = new TSN.ERP.SharedComponents.Data.dsAssignments();
			dsAss.Merge(AssData.List(AssID));
			if (dsAss.GEN_Assignments.Rows.Count < 1) return false;
			if (!checkSec.HasLoadAccountabiltiyAccess(dsAss.GEN_Assignments[0].ContactID))
			{
				SendAccessDeniedMessage( (int)TSN.ERP.Security.Rules.GeneralRules.LoadAccountabilityEmployees );
				return false;
			}
			return AssData.ChangeResponspility(AssID,ReponseID);
		}

		protected override void ObjectIntiated()
		{
			checkSec.JoinSession(ActiveSession.Token);
			base.ObjectIntiated ();
		}

	}
}
