using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data.OleDb;
using System.Data;
//////using System.EnterpriseServices;
using TSN.ERP.Security;

namespace TSN.ERP.Engine
{
	/// <summary>
	/// The master for all data classes in the system , any data class should inherit this class, 
	/// it implements standard functions for Add, Edit, Delete and List
	/// </summary>
	/// 
	
////	[Transaction(TransactionOption.Required, Isolation=TransactionIsolationLevel.Any, Timeout=120)]
	public class BussinesComponent : System.ComponentModel.Component
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		/// 
		private string _ConnectionString;
		private System.ComponentModel.Container components = null;
		private DataSet MyDataSet = new DataSet();
		private OleDbDataAdapter MyDataAdabter = new OleDbDataAdapter() ;
		private OleDbConnection MyConnection = new OleDbConnection();
		private Session _UserSession;
		private string OrginalSelectComand ;
		private DataSet OrginalSchema = new DataSet();
		private BussinesComponent _ParentComponent;
		public BussinesComponent(System.ComponentModel.IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			container.Add(this);
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public BussinesComponent()
		{
	
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// 
         
        ////////////////////[DebuggerStepThrough()]
        ////////////////////protected override void Dispose( bool disposing )
        ////////////////////{
        ////////////////////    if( disposing )
        ////////////////////    {

			
        ////////////////////        if (Connection != null)
        ////////////////////        {
        ////////////////////            //Connection.Close();
        ////////////////////            Connection.Dispose();
        ////////////////////            //Connection=null;
        ////////////////////        }
        ////////////////////        if (ComponentDataSet !=null)
        ////////////////////            ComponentDataSet.Dispose();
        ////////////////////        //ComponentDataSet=null;
        ////////////////////        if (ComponentDataAdabter !=null)
        ////////////////////            ComponentDataAdabter.Dispose();
        ////////////////////        //ComponentDataAdabter=null;
        ////////////////////    }
        ////////////////////    base.Dispose( disposing );	
        ////////////////////}

		/// <summary> 
		///  Genral Function Should be moved to the bussines components view
		/// <summary> 
		/// 
		///<remarks>
		/// Testing Documentation 
		///</remarks>
		protected int ApplyRowStateFilter(DataSet currentDataSet,DataRowState FilterState )
		{
			int tableCount = currentDataSet.Tables.Count;
			int Filtercount = 0;
			for (int i =0; i <tableCount;i++)
			{
				int rowCount = currentDataSet.Tables[i].Rows.Count;
				for (int j=rowCount -1; j >=0 ;j--)
				{
					if (currentDataSet.Tables[i].Rows[j].RowState != FilterState)
					{
						currentDataSet.Tables[i].Rows[j].RejectChanges();
					}
					else
					{
						Filtercount++;
					}
				}
			}
			return Filtercount;
		}
		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion
		
		
		#region ConnectionMangmnet
		
		/// <summary>
		/// A public property to access  connection string, dont use to modify the connection string , use SetConnection 
		/// method instead
		/// </summary>
		public string ConnectionString
		{
			set
			{
				this._ConnectionString = value;
			}
			get
			{
				return this._ConnectionString;
			}
		}
		/// <summary>
		/// Gets or sets a refrence to the component main connection 
		/// </summary>
		public OleDbConnection Connection
		{
			set
			{
				this.MyConnection = value;
			}
			get
			{
				return this.MyConnection;
			}
		}
		
		/// <summary>
		/// Changes the component connection string 
		/// </summary>
		/// <param name="ServerConnectionString">Connection String</param>
		public void SetConnection(string  ServerConnectionString)
		{
			// stores the connection string
			_ConnectionString = ServerConnectionString;
			// recoreds the orgianl select comand as stated by the component data adabter
			OrginalSelectComand = MyDataAdabter.SelectCommand.CommandText;
			//Checks if this object has a parent component then it would pass the connection string to it as well
			if (_ParentComponent != null)
				_ParentComponent.SetConnection(ServerConnectionString);
			// Change the Connection string of the main connection
			this.MyConnection.Close();
			this.MyConnection.ConnectionString = ServerConnectionString;
			this.MyConnection.Open();
			
		}
		#endregion


		#region Standard Functions
		#region Add
		/// <summary>
		/// this function should handle all the processes of adding new records into the database
		/// no insertions should be carried out the add function , each Datacomponent will only add rcords
		/// having the schema , registered to it.
		/// </summary>
		/// <param name="dsNewRecords">a dataset holding, the newly added records</param>
		/// <param name="AutoCreate">if true will create and assgin primary keys t=o the new created records 
		/// otherwise will rely on that the primary keys are submited with the records or the dbms autoincrment</param>
		/// <returns>the number of records added</returns>
		public virtual int Add(DataSet dsNewRecords, bool AutoCreate)
		{
			try
			{
				// Creates and intiates an instance of the primary key manager class, to be used if creating primary keys are requiered
				PrimaryKeyManager PkManage ;
				PkManage = new PrimaryKeyManager();
				PkManage.SetConnection(this.MyConnection.ConnectionString);

				// Creates and intiates an instance of the Entity Security manager class, to be used for rule entity creation
				EntitysecurityManager EntSec ;
				EntSec = new EntitysecurityManager();
				EntSec.SetConnection(this.MyConnection.ConnectionString);

				ComponentDataSet.Clear();
				ComponentDataSet.EnforceConstraints = false;
				// Applying filter to check that only added rows are accepted 
				if (ApplyRowStateFilter(dsNewRecords,DataRowState.Added)< 1)
					return 0;
				// Allow inherited classes to control adding process
				if (!this.onAdd(dsNewRecords))
					return -1;
				//Check if this component has a parent component  
				if (ParentComponent != null)
				{
					// Changes the table name of the newly created records to match the tablename of the parent compoent
					dsNewRecords.Tables[0].TableName = ParentComponent.GetOrginalSchema().Tables[0].TableName;
					//Submits the dataset for the parent component to do the updateing
					int parentRetint = ParentComponent.Add(dsNewRecords,AutoCreate);

					// if the parent component fails to update abort the whole update proccess
					if (parentRetint < 1)
						return parentRetint;

					// restore the schema table name to the current component table name
					dsNewRecords.Tables[0].TableName = OrginalSchema.Tables[0].TableName;
				}
				else
				{
					// if the auto create is set to true assgin primary keys
					if (AutoCreate)
						PkManage.PrepareToSave(dsNewRecords);
				}
				ComponentDataSet.Merge(dsNewRecords);
				//Finaly do the update
				int Retint = this.ComponentDataAdabter.Update(this.ComponentDataSet);
				// I fupdate is done add rule entittes
				if (Retint > 0)
				{
					EntSec.AddRulesForEntity(dsNewRecords,ActiveSession.UserId);
					ActiveSession.LastDataSet = dsNewRecords;
				}
				return Retint;
			}
			catch(Exception ex)
			{
				ActiveSession.SetError(new ERPError((int) ERPError.ErrorTypes.Database,"Error During Insertion",0,ex));
				return -1;
			}
		}
		public virtual int Add(DataSet dsNewRecords)
		{
			return Add(dsNewRecords, true);
		}
		protected virtual bool onAdd(DataSet dsNewRecords)
		{
			return true;
		}
		#endregion
		#region Delete
		/// <summary>
		/// this fucntion is used to do all the delete from the database
		/// </summary>
		/// <param name="dsDeletedRecords">a data set conating the deleted records, this dataset should contain all the records information
		/// inorder to pass the consistancy checks</param>
		/// <returns>the number of deleted records</returns>
		public virtual int Delete(DataSet dsDeletedRecords)
		{
			try
			{
				//Creats an instance from the entity security manager in order to delete the rule entities related to the current entities
				EntitysecurityManager EntSec ;
				EntSec = new EntitysecurityManager();
				EntSec.SetConnection(this.MyConnection.ConnectionString);

		
				this.ComponentDataSet.Clear();
				this.ComponentDataSet.Merge(dsDeletedRecords);
				
				//Applies the row state filte will reject all records that are not of Status Deleted
				if (ApplyRowStateFilter(dsDeletedRecords,DataRowState.Deleted)< 1)
					return 0;
				//Allows and inhrited class to control the delete process
				if (!this.onDelete(dsDeletedRecords))
					return -1;
				
				//do the actual update
				int retint = this.ComponentDataAdabter.Update(this.ComponentDataSet);

				if(retint >= 1)
				{
					// Delete Rule Entities
					EntSec.DeleteRuleEntities(dsDeletedRecords);
				}
				if (retint < 1 ) return retint;

				// if there is a parent object , let the parent data component delete its records from the parent
				//table
				if (ParentComponent != null)
				{
					dsDeletedRecords.Tables[0].TableName = ParentComponent.GetOrginalSchema().Tables[0].TableName;
					int parentRetint = ParentComponent.Delete(dsDeletedRecords);
					if (parentRetint < 1)
						return parentRetint;
					dsDeletedRecords.Tables[0].TableName = OrginalSchema.Tables[0].TableName;
				}
				return retint;
			}
			catch(Exception ex)
			{
				ActiveSession.SetError(new ERPError((int) ERPError.ErrorTypes.Database,"Error During Delete",0,ex));
				return -1;
			}
		}
		protected virtual bool onDelete(DataSet dsDeletedRecords)
		{
			return true;
		}
		#endregion
		#region Edit 
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dsModifiedRecords"></param>
		/// <returns></returns>
		public virtual int Edit(DataSet dsModifiedRecords)
		{
			try
			{
				EntitysecurityManager EntSec ;
				EntSec = new EntitysecurityManager();
				EntSec.SetConnection(this.MyConnection.ConnectionString);

				this.ComponentDataSet.Clear();
				this.ComponentDataSet.Merge(dsModifiedRecords);
				if (ApplyRowStateFilter(dsModifiedRecords,DataRowState.Modified)< 1)
					return 0;
				if (!this.onEdit(dsModifiedRecords))
					return -1;
				EntSec.EditRuleEntities(dsModifiedRecords);
				if (ParentComponent != null)
				{
					dsModifiedRecords.Tables[0].TableName = ParentComponent.GetOrginalSchema().Tables[0].TableName;
					int parentRetint = ParentComponent.Edit(dsModifiedRecords);
					if (parentRetint < 1)
						return parentRetint;
					dsModifiedRecords.Tables[0].TableName = OrginalSchema.Tables[0].TableName;
				}
				return this.ComponentDataAdabter.Update(this.ComponentDataSet);
			}
			catch(Exception ex)
			{
				ActiveSession.SetError(new ERPError((int) ERPError.ErrorTypes.Database,"Error During Update",0,ex));
				return -1;
			}
		}
		protected virtual bool onEdit(DataSet dsModifiedRecords)
		{
			return true;
		}
		#endregion
		#region List
		/// <summary>
		/// Lists all the records in the datacomponent related table
		/// </summary>
		/// <returns>a dataset with all the records</returns>
		public virtual DataSet List()
		{
			try
			{
				ComponentDataSet.Clear();
				// if has a parent Component access the component to create a gloabl select command that mixs both parent and child
				//table in one schema
				if (ParentComponent !=null)
				{
					OrginalSelectComand = ComponentDataAdabter.SelectCommand.CommandText;
					ComponentDataAdabter.SelectCommand.CommandText = DataUtils.DataUtility.GenerateGlobalSelectCommand(OrginalSchema.Tables[0],ParentComponent.GetOrginalSchema().Tables[0]);
					ComponentDataAdabter.Fill(ComponentDataSet);
					RestoreOriginalSelectComand();
				}
				else
				{
					ComponentDataSet.EnforceConstraints = false;
					ComponentDataAdabter.Fill(this.ComponentDataSet);
				}
				// Allows an inherited class to control the the list process
				if(!this.onList(this.ComponentDataSet))
					return null;
				return this.ComponentDataSet;
			}
			catch(Exception ex)
			{
				ActiveSession.SetError(new ERPError(0,"Error While listing",-1,ex));
				return null;
			}
		}

		/// <summary>
		/// Lists a single record given its priamry key
		/// </summary>
		/// <param name="ID">the value of the recored primary key</param>
		/// <returns>a dataset contining the recored</returns>
		public virtual DataSet List( int ID )
		{
			try
			{

				this.ComponentDataSet.Clear();
				// storing the orgianl select command
				OrginalSelectComand = ComponentDataAdabter.SelectCommand.CommandText;
				// creating a new filter
				string FilterString , Key, TableName ;
				Key =   ComponentDataSet.Tables[ 0 ].PrimaryKey[ 0 ].ColumnName ;
				TableName= ComponentDataSet.Tables[ 0 ].TableName;
				FilterString = TableName+"."+Key + " = " + ID ;
				// using the list with filter function to rturn the required command
				return List(FilterString);
			}
			catch(Exception ex)
			{
				ActiveSession.SetError(new ERPError(0,"Error While listing",-1,ex));
				RestoreOriginalSelectComand();
				return null;
			}
		}
		/// <summary>
		/// this function lists a group of recored form the databse based that fites a certain filter
		/// </summary>
		/// <param name="FilterString">a filter string in like the following "ContactID = 12 and Fullname like 'Test'"</param>
		/// <returns>a datset of selected recoreds</returns>
		public virtual DataSet List(string FilterString)
		{
			try
			{
				OrginalSelectComand = ComponentDataAdabter.SelectCommand.CommandText;
				if (ParentComponent !=null)
				{
					ComponentDataAdabter.SelectCommand.CommandText = DataUtils.DataUtility.GenerateGlobalSelectCommand(OrginalSchema.Tables[0],
						ParentComponent.GetOrginalSchema().Tables[0],FilterString);
				}
				else
				{
					ComponentDataAdabter.SelectCommand.CommandText = ComponentDataAdabter.SelectCommand.CommandText + " where " + FilterString;
				}
				ComponentDataSet.Clear();
				ComponentDataSet.EnforceConstraints = false;
				ComponentDataAdabter.Fill(ComponentDataSet);
				RestoreOriginalSelectComand();
				if(!this.onList(this.ComponentDataSet))
					return null;
				return ComponentDataSet;
			}
			catch(Exception ex)
			{
				ActiveSession.SetError(new ERPError(0,"Error While listing: " + FilterString ,-1,ex));
				RestoreOriginalSelectComand();
				return null;
			}
		}
		/// <summary>
		/// lists the whole Records, based on a dataset with the values of the primary keys needed
		/// </summary>
		/// <param name="PKList"></param>
		/// <returns></returns>
		public virtual DataSet List(DataSet PKList)
		{
			try
			{
				string Key, TableName,FilterString, ShortKey;
				ShortKey = OrginalSchema.Tables[ 0 ].PrimaryKey[ 0 ].ColumnName;
				Key =  OrginalSchema.Tables[ 0 ].TableName+"."+ ComponentDataSet.Tables[ 0 ].PrimaryKey[ 0 ].ColumnName ;
				TableName= OrginalSchema.Tables[ 0 ].TableName;
				int rowCount = PKList.Tables[TableName].Rows.Count;
				if (rowCount<1)
				{
					ComponentDataSet.Clear();
					return ComponentDataSet;
				}
				string tempvale1 = Key + " = " + PKList.Tables[TableName].Rows[0][ShortKey].ToString();
				FilterString = tempvale1;
				for (int i = 0;i<rowCount;i++)
				{
					string tempvale = Key + " = " + PKList.Tables[TableName].Rows[i][ShortKey].ToString();
					FilterString = FilterString + " OR " + tempvale  ;
				}
				return List(FilterString);
			}
			catch(Exception ex)
			{
				ActiveSession.SetError(new ERPError(0,"Error While Listing: " + ex.Source.ToString() + ex.Message,0,ex));
				return null;
			}
			
		}
		protected virtual bool onList(DataSet dsListedRecords)
		{
			return true;
		}
		#endregion
		#region Update
		/// <summary>
		/// this is a function that calls the Edit , Add and Delete fro a given dataset in one calls
		/// </summary>
		/// <param name="dsModifiedRecords"></param>
		/// <returns></returns>
		public virtual int Update(DataSet dsModifiedRecords)
		{
			DataSet tempDataSet = new DataSet();
			tempDataSet.EnforceConstraints = false;
			tempDataSet.Merge(dsModifiedRecords);
			if (this.Edit(tempDataSet)> -1)
			{
				tempDataSet.Reset();
				tempDataSet.Merge(dsModifiedRecords);
				if (this.Delete(tempDataSet)> -1)
				{
					tempDataSet.Reset();
					tempDataSet.Merge(dsModifiedRecords);
				}
				return this.Add(dsModifiedRecords);
			}
			return -1;
		}
		#endregion
		#endregion
		#region Properties
		/// <summary>
		/// this is to emulate the ERD inheritance between tables, it supports listing and updateing the two tables as if one
		/// in order to make it easier for GUI devlopers, currently it supports only a single level of inheritance
		/// </summary>
		public BussinesComponent ParentComponent
		{
			get
			{
				return _ParentComponent;
			}
			set
			{
				_ParentComponent = value;
			}
		}
		/// <summary>
		/// the dataset schema that this datacomponent should behave based on
		/// </summary>
	
		public DataSet ComponentDataSet
		{
			set
			{
				MyDataSet = value;
				MyDataSet.EnforceConstraints = false;
				OrginalSchema.Clear();
				OrginalSchema.Merge(MyDataSet);
			}
			get
			{
				return this.MyDataSet;
			}
		}
		/// <summary>
		/// the data adabter used by this component to update or retirieve data from the database
		/// </summary>
		public OleDbDataAdapter ComponentDataAdabter
		{
			set
			{
				this.MyDataAdabter = value;
			}
			get
			{
				return this.MyDataAdabter ;
			}
		}
		/// <summary>
		/// the session that this component is currently a member of
		/// </summary>
		public Session ActiveSession
		{
			get
			{
				return _UserSession;
			}
		}
		internal DataSet GetOrginalSchema()
		{
			return OrginalSchema;
		}
		internal void SetSession(Session UserSession)
		{
			_UserSession = UserSession;
			if (_ParentComponent != null)
				_ParentComponent.SetSession(_UserSession);
		}
		#endregion
		protected void RestoreOriginalSelectComand()
		{
			ComponentDataAdabter.SelectCommand.CommandText = OrginalSelectComand;
			ComponentDataAdabter.SelectCommand.Parameters.Clear();
		}
		private bool PreAdd(DataSet AddedRows)
		{
			PrimaryKeyManager PkManage ;
			PkManage = new PrimaryKeyManager();
			PkManage.SetConnection(this.MyConnection.ConnectionString);
			return PkManage.PrepareToSave(AddedRows);
		}
	}
}
