using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for CompanyStuctureDataClass.
	/// </summary>
	public class CompanElementsLevelsData : TSN.ERP.Engine.BussinesComponent 
	{
		private System.Data.OleDb.OleDbDataAdapter odaCompanyStructLevels;
		private System.Data.OleDb.OleDbCommand odaCompanyStructLevelsSelectCommand1;
		private System.Data.OleDb.OleDbCommand odaCompanyStructLevelsInsertCommand1;
		private System.Data.OleDb.OleDbCommand odaCompanyStructLevelsCommand1;
		private System.Data.OleDb.OleDbCommand odaCompanyStructLevelsDeleteCommand1;
		private System.Data.OleDb.OleDbConnection con1;
		private TSN.ERP.SharedComponents.Data.dsCompanyElementLevels dsCompanyElementLevels1;
		private System.Data.OleDb.OleDbCommand odcCheckLevelExsist;
		private System.Data.OleDb.OleDbCommand odcNextLevel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CompanElementsLevelsData(System.ComponentModel.IContainer container)
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

		public CompanElementsLevelsData()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();
			this.Connection = this.con1;
			this.ComponentDataAdabter = this.odaCompanyStructLevels;
			this.ComponentDataSet = this.dsCompanyElementLevels1;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
        ////////////////////protected override void Dispose( bool disposing )
        ////////////////////{
        ////////////////////    if( disposing )
        ////////////////////    {
        ////////////////////        if(components != null)
        ////////////////////        {
        ////////////////////            components.Dispose();
        ////////////////////        }
        ////////////////////    }
        ////////////////////    base.Dispose( disposing );
        ////////////////////}


		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.odaCompanyStructLevels = new System.Data.OleDb.OleDbDataAdapter();
			this.odaCompanyStructLevelsDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.con1 = new System.Data.OleDb.OleDbConnection();
			this.odaCompanyStructLevelsInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.odaCompanyStructLevelsSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.odaCompanyStructLevelsCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dsCompanyElementLevels1 = new TSN.ERP.SharedComponents.Data.dsCompanyElementLevels();
			this.odcCheckLevelExsist = new System.Data.OleDb.OleDbCommand();
			this.odcNextLevel = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsCompanyElementLevels1)).BeginInit();
			// 
			// odaCompanyStructLevels
			// 
			this.odaCompanyStructLevels.DeleteCommand = this.odaCompanyStructLevelsDeleteCommand1;
			this.odaCompanyStructLevels.InsertCommand = this.odaCompanyStructLevelsInsertCommand1;
			this.odaCompanyStructLevels.SelectCommand = this.odaCompanyStructLevelsSelectCommand1;
			this.odaCompanyStructLevels.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											 new System.Data.Common.DataTableMapping("Table", "GEN_CompanyElmentLevels", new System.Data.Common.DataColumnMapping[] {
																																																										new System.Data.Common.DataColumnMapping("CEL_ID", "CEL_ID"),
																																																										new System.Data.Common.DataColumnMapping("CELName", "CELName"),
																																																										new System.Data.Common.DataColumnMapping("CELevelDesc", "CELevelDesc"),
																																																										new System.Data.Common.DataColumnMapping("CELOrder", "CELOrder")})});
			this.odaCompanyStructLevels.UpdateCommand = this.odaCompanyStructLevelsCommand1;
			// 
			// odaCompanyStructLevelsDeleteCommand1
			// 
			this.odaCompanyStructLevelsDeleteCommand1.CommandText = "DELETE FROM GEN_CompanyElmentLevels WHERE (CEL_ID = ?) AND (CELName = ?) AND (CEL" +
				"Order = ?)";
			this.odaCompanyStructLevelsDeleteCommand1.Connection = this.con1;
			this.odaCompanyStructLevelsDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CEL_ID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CEL_ID", System.Data.DataRowVersion.Original, null));
			this.odaCompanyStructLevelsDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CELName", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CELName", System.Data.DataRowVersion.Original, null));
			this.odaCompanyStructLevelsDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CELOrder", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CELOrder", System.Data.DataRowVersion.Original, null));
			// 
			// con1
			// 
			this.con1.ConnectionString = @"Auto Translate=True;Integrated Security=SSPI;User ID=RW;Data Source=""ERP\ERPSQL2005"";Tag with column collation when possible=False;Initial Catalog=TestAccountability_Data;Use Procedure for Prepare=1;Provider=""SQLOLEDB.1"";Persist Security Info=False;Workstation ID=HAMDYAHMED;Use Encryption for Data=False;Packet Size=4096";
			// 
			// odaCompanyStructLevelsInsertCommand1
			// 
			this.odaCompanyStructLevelsInsertCommand1.CommandText = "INSERT INTO GEN_CompanyElmentLevels(CEL_ID, CELName, CELevelDesc, CELOrder) VALUE" +
				"S (?, ?, ?, ?); SELECT CEL_ID, CELName, CELevelDesc, CELOrder FROM GEN_CompanyEl" +
				"mentLevels WHERE (CEL_ID = ?)";
			this.odaCompanyStructLevelsInsertCommand1.Connection = this.con1;
			this.odaCompanyStructLevelsInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CEL_ID", System.Data.OleDb.OleDbType.Integer, 4, "CEL_ID"));
			this.odaCompanyStructLevelsInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CELName", System.Data.OleDb.OleDbType.VarChar, 120, "CELName"));
			this.odaCompanyStructLevelsInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CELevelDesc", System.Data.OleDb.OleDbType.VarChar, 2147483647, "CELevelDesc"));
			this.odaCompanyStructLevelsInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CELOrder", System.Data.OleDb.OleDbType.Integer, 4, "CELOrder"));
			this.odaCompanyStructLevelsInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_CEL_ID", System.Data.OleDb.OleDbType.Integer, 4, "CEL_ID"));
			// 
			// odaCompanyStructLevelsSelectCommand1
			// 
			this.odaCompanyStructLevelsSelectCommand1.CommandText = "SELECT CEL_ID, CELName, CELevelDesc, CELOrder FROM GEN_CompanyElmentLevels ORDER " +
				"BY CELName";
			this.odaCompanyStructLevelsSelectCommand1.Connection = this.con1;
			// 
			// odaCompanyStructLevelsCommand1
			// 
			this.odaCompanyStructLevelsCommand1.CommandText = "UPDATE GEN_CompanyElmentLevels SET CEL_ID = ?, CELName = ?, CELevelDesc = ?, CELO" +
				"rder = ? WHERE (CEL_ID = ?) AND (CELName = ?) AND (CELOrder = ?); SELECT CEL_ID," +
				" CELName, CELevelDesc, CELOrder FROM GEN_CompanyElmentLevels WHERE (CEL_ID = ?)";
			this.odaCompanyStructLevelsCommand1.Connection = this.con1;
			this.odaCompanyStructLevelsCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CEL_ID", System.Data.OleDb.OleDbType.Integer, 4, "CEL_ID"));
			this.odaCompanyStructLevelsCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CELName", System.Data.OleDb.OleDbType.VarChar, 120, "CELName"));
			this.odaCompanyStructLevelsCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CELevelDesc", System.Data.OleDb.OleDbType.VarChar, 2147483647, "CELevelDesc"));
			this.odaCompanyStructLevelsCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CELOrder", System.Data.OleDb.OleDbType.Integer, 4, "CELOrder"));
			this.odaCompanyStructLevelsCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CEL_ID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CEL_ID", System.Data.DataRowVersion.Original, null));
			this.odaCompanyStructLevelsCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CELName", System.Data.OleDb.OleDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CELName", System.Data.DataRowVersion.Original, null));
			this.odaCompanyStructLevelsCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CELOrder", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CELOrder", System.Data.DataRowVersion.Original, null));
			this.odaCompanyStructLevelsCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_CEL_ID", System.Data.OleDb.OleDbType.Integer, 4, "CEL_ID"));
			// 
			// dsCompanyElementLevels1
			// 
			this.dsCompanyElementLevels1.DataSetName = "dsCompanyElementLevels";
			this.dsCompanyElementLevels1.EnforceConstraints = false;
			this.dsCompanyElementLevels1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// odcCheckLevelExsist
			// 
			this.odcCheckLevelExsist.CommandText = "SELECT COUNT(*) AS levelcount, CEL_ID FROM GEN_CompanyElmentLevels GROUP BY CEL_I" +
				"D HAVING (CEL_ID = ?)";
			this.odcCheckLevelExsist.Connection = this.con1;
			this.odcCheckLevelExsist.Parameters.Add(new System.Data.OleDb.OleDbParameter("CEL_ID", System.Data.OleDb.OleDbType.Integer, 4, "CEL_ID"));
			// 
			// odcNextLevel
			// 
			this.odcNextLevel.CommandText = "SELECT CEL_ID FROM GEN_CompanyElmentLevels WHERE (CEL_ID > ?)";
			this.odcNextLevel.Connection = this.con1;
			this.odcNextLevel.Parameters.Add(new System.Data.OleDb.OleDbParameter("CEL_ID", System.Data.OleDb.OleDbType.Integer, 4, "CEL_ID"));
			// 
			// CompanElementsLevelsData
			// 
			this.ComponentDataAdabter = this.odaCompanyStructLevels;
			this.ComponentDataSet = this.dsCompanyElementLevels1;
			this.Connection = this.con1;
			((System.ComponentModel.ISupportInitialize)(this.dsCompanyElementLevels1)).EndInit();

		}
		#endregion

		public int NextLevel(int LevelID)
		{
			odcCheckLevelExsist.Parameters[0].Value = LevelID;
			object temp = odcCheckLevelExsist.ExecuteScalar();
			if(temp ==null)
			{
				return -1;
			}
			return (int)temp;
		}
	}
}
