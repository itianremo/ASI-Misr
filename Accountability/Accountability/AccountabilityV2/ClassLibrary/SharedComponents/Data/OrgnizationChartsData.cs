using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using TSN.ERP.Engine; 
namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for FlowChartsData.
	/// </summary>
	public class OrgnizationChartsData : BussinesComponent 
	{
		private System.Data.OleDb.OleDbDataAdapter odaCharts;
		private System.Data.OleDb.OleDbConnection con1;
		private TSN.ERP.SharedComponents.Data.dsOrgnizationCharts dsOrgnizationCharts1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
        private System.Data.OleDb.OleDbCommand odcSetChartDesc;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OrgnizationChartsData(System.ComponentModel.IContainer container)
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
        public bool SetChartDescription(int FileID, string ChartDescription)
        {
            try
            {
                odcSetChartDesc.Parameters["Original_FileID"].Value = FileID;
                odcSetChartDesc.Parameters["OChartDesc"].Value = ChartDescription;
                object temp = odcSetChartDesc.ExecuteScalar();
                if (temp == null) return false;
                if ((int)temp > 0) return true;
                return false;
            }
            catch (Exception ex)
            {
                ActiveSession.SetError(new ERP.Engine.ERPError(0, "Error when  Update Chart Description", 0, ex));
                return false;
            }
        }

		public OrgnizationChartsData()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();

			ParentComponent = new FilesDataClass();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrgnizationChartsData));
            this.odaCharts = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.con1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.dsOrgnizationCharts1 = new TSN.ERP.SharedComponents.Data.dsOrgnizationCharts();
            this.odcSetChartDesc = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsOrgnizationCharts1)).BeginInit();
            // 
            // odaCharts
            // 
            this.odaCharts.DeleteCommand = this.oleDbDeleteCommand2;
            this.odaCharts.InsertCommand = this.oleDbInsertCommand1;
            this.odaCharts.SelectCommand = this.oleDbSelectCommand1;
            this.odaCharts.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GEN_OrgnizationCharts", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("FileID", "FileID"),
                        new System.Data.Common.DataColumnMapping("OChartDesc", "OChartDesc"),
                        new System.Data.Common.DataColumnMapping("OChartObject", "OChartObject"),
                        new System.Data.Common.DataColumnMapping("OChartType", "OChartType")})});
            this.odaCharts.UpdateCommand = this.oleDbUpdateCommand1;
            this.odaCharts.RowUpdated += new System.Data.OleDb.OleDbRowUpdatedEventHandler(this.odaCharts_RowUpdated);
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = "DELETE FROM GEN_OrgnizationCharts WHERE (FileID = ?) AND (OChartType = ? OR ? IS " +
                "NULL AND OChartType IS NULL)";
            this.oleDbDeleteCommand2.Connection = this.con1;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_FileID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FileID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_OChartType", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "OChartType", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_OChartType1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "OChartType", System.Data.DataRowVersion.Original, null)});
            // 
            // con1
            // 
            this.con1.ConnectionString = "Provider=SQLNCLI.1;Data Source=MISSERVER;User ID=RW;Initial Catalog=TestAccountab" +
                "ility_Data";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO GEN_OrgnizationCharts(FileID, OChartDesc, OChartObject, OChartType) V" +
                "ALUES (?, ?, ?, ?); SELECT FileID, OChartDesc, OChartObject, OChartType FROM GEN" +
                "_OrgnizationCharts WHERE (FileID = ?)";
            this.oleDbInsertCommand1.Connection = this.con1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("FileID", System.Data.OleDb.OleDbType.Integer, 4, "FileID"),
            new System.Data.OleDb.OleDbParameter("OChartDesc", System.Data.OleDb.OleDbType.VarChar, 2147483647, "OChartDesc"),
            new System.Data.OleDb.OleDbParameter("OChartObject", System.Data.OleDb.OleDbType.VarChar, 2147483647, "OChartObject"),
            new System.Data.OleDb.OleDbParameter("OChartType", System.Data.OleDb.OleDbType.Integer, 4, "OChartType"),
            new System.Data.OleDb.OleDbParameter("Select_FileID", System.Data.OleDb.OleDbType.Integer, 4, "FileID")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT FileID, OChartDesc, OChartObject, OChartType FROM GEN_OrgnizationCharts";
            this.oleDbSelectCommand1.Connection = this.con1;
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.con1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("FileID", System.Data.OleDb.OleDbType.Integer, 4, "FileID"),
            new System.Data.OleDb.OleDbParameter("OChartDesc", System.Data.OleDb.OleDbType.VarChar, 2147483647, "OChartDesc"),
            new System.Data.OleDb.OleDbParameter("OChartObject", System.Data.OleDb.OleDbType.VarChar, 2147483647, "OChartObject"),
            new System.Data.OleDb.OleDbParameter("OChartType", System.Data.OleDb.OleDbType.Integer, 4, "OChartType"),
            new System.Data.OleDb.OleDbParameter("Original_FileID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FileID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_OChartType", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "OChartType", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_OChartType1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "OChartType", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Select_FileID", System.Data.OleDb.OleDbType.Integer, 4, "FileID")});
            // 
            // dsOrgnizationCharts1
            // 
            this.dsOrgnizationCharts1.DataSetName = "dsOrgnizationCharts";
            this.dsOrgnizationCharts1.EnforceConstraints = false;
            this.dsOrgnizationCharts1.Locale = new System.Globalization.CultureInfo("ar-EG");
            this.dsOrgnizationCharts1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // odcSetChartDesc
            // 
            this.odcSetChartDesc.CommandText = "UPDATE GEN_OrgnizationCharts SET  OChartDesc = ?  WHERE (FileID = ?)";
            this.odcSetChartDesc.Connection = this.con1;
            this.odcSetChartDesc.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("OChartDesc", System.Data.OleDb.OleDbType.Char, 2147483647, "OChartDesc"),
            new System.Data.OleDb.OleDbParameter("Original_FileID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FileID", System.Data.DataRowVersion.Original, null)});
            // 
            // OrgnizationChartsData
            // 
            this.ComponentDataAdabter = this.odaCharts;
            this.ComponentDataSet = this.dsOrgnizationCharts1;
            this.Connection = this.con1;
            ((System.ComponentModel.ISupportInitialize)(this.dsOrgnizationCharts1)).EndInit();

		}
		#endregion

		private void odaCharts_RowUpdated(object sender, System.Data.OleDb.OleDbRowUpdatedEventArgs e)
		{
		
		}
	}
}
