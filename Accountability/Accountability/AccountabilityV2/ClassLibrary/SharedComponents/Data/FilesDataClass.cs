using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;

namespace TSN.ERP.SharedComponents.Data
{
	/// <summary>
	/// Summary description for FilesDataClass.
	/// </summary>
	public class FilesDataClass : TSN.ERP.Engine.BussinesComponent 
	{
		private System.Data.OleDb.OleDbDataAdapter odaFilesInfo;
		private System.Data.OleDb.OleDbConnection con1;
		private TSN.ERP.SharedComponents.Data.dsFilesInfo dsFilesInfo1;
		private System.Data.OleDb.OleDbCommand odcUpdateFileContent;
		private System.Data.OleDb.OleDbCommand odcDeleteFile;
		private System.Data.OleDb.OleDbCommand odcLoadFile;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbCommand GetFileID;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FilesDataClass(System.ComponentModel.IContainer container)
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

		public FilesDataClass()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.odaFilesInfo = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.con1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dsFilesInfo1 = new TSN.ERP.SharedComponents.Data.dsFilesInfo();
			this.odcUpdateFileContent = new System.Data.OleDb.OleDbCommand();
			this.odcDeleteFile = new System.Data.OleDb.OleDbCommand();
			this.odcLoadFile = new System.Data.OleDb.OleDbCommand();
			this.GetFileID = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsFilesInfo1)).BeginInit();
			// 
			// odaFilesInfo
			// 
			this.odaFilesInfo.DeleteCommand = this.oleDbDeleteCommand1;
			this.odaFilesInfo.InsertCommand = this.oleDbInsertCommand1;
			this.odaFilesInfo.SelectCommand = this.oleDbSelectCommand1;
			this.odaFilesInfo.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								   new System.Data.Common.DataTableMapping("Table", "GEN_Files", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("FileID", "FileID"),
																																																				new System.Data.Common.DataColumnMapping("UserID", "UserID"),
																																																				new System.Data.Common.DataColumnMapping("FileName", "FileName"),
																																																				new System.Data.Common.DataColumnMapping("FileSize", "FileSize"),
																																																				new System.Data.Common.DataColumnMapping("FileType", "FileType"),
																																																				new System.Data.Common.DataColumnMapping("FileCreationTime", "FileCreationTime")})});
			this.odaFilesInfo.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM GEN_Files WHERE (FileID = ?)";
			this.oleDbDeleteCommand1.Connection = this.con1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FileID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FileID", System.Data.DataRowVersion.Original, null));
			// 
			// con1
			// 
			this.con1.ConnectionString = @"User ID=sa;Data Source=ERP;Tag with column collation when possible=False;Initial Catalog=InitialAccountability;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=MHAMDY;Use Encryption for Data=False;Packet Size=4096";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO GEN_Files(FileID, UserID, FileName, FileSize, FileType, FileCreationT" +
				"ime) VALUES (?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.con1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FileID", System.Data.OleDb.OleDbType.Integer, 4, "FileID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FileName", System.Data.OleDb.OleDbType.VarChar, 250, "FileName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FileSize", System.Data.OleDb.OleDbType.VarChar, 20, "FileSize"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FileType", System.Data.OleDb.OleDbType.VarChar, 25, "FileType"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FileCreationTime", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "FileCreationTime"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT FileID, UserID, FileName, FileSize, FileType, FileCreationTime FROM GEN_Fi" +
				"les";
			this.oleDbSelectCommand1.Connection = this.con1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE GEN_Files SET FileID = ?, UserID = ?, FileName = ?, FileSize = ?, FileType" +
				" = ?, FileCreationTime = ? WHERE (FileID = ?)";
			this.oleDbUpdateCommand1.Connection = this.con1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FileID", System.Data.OleDb.OleDbType.Integer, 4, "FileID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("UserID", System.Data.OleDb.OleDbType.Integer, 4, "UserID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FileName", System.Data.OleDb.OleDbType.VarChar, 250, "FileName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FileSize", System.Data.OleDb.OleDbType.VarChar, 20, "FileSize"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FileType", System.Data.OleDb.OleDbType.VarChar, 25, "FileType"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FileCreationTime", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "FileCreationTime"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FileID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FileID", System.Data.DataRowVersion.Original, null));
			// 
			// dsFilesInfo1
			// 
			this.dsFilesInfo1.DataSetName = "dsFilesInfo";
			this.dsFilesInfo1.EnforceConstraints = false;
			this.dsFilesInfo1.Locale = new System.Globalization.CultureInfo("ar-EG");
			// 
			// odcUpdateFileContent
			// 
			this.odcUpdateFileContent.CommandText = "UPDATE GEN_Files SET FileBody = ? WHERE (FileID = ?)";
			this.odcUpdateFileContent.Connection = this.con1;
			this.odcUpdateFileContent.Parameters.Add(new System.Data.OleDb.OleDbParameter("FileBody", System.Data.OleDb.OleDbType.VarBinary, 2147483647, "FileBody"));
			this.odcUpdateFileContent.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FileID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FileID", System.Data.DataRowVersion.Original, null));
			// 
			// odcDeleteFile
			// 
			this.odcDeleteFile.CommandText = "DELETE FROM GEN_Files WHERE (FileID = ?)";
			this.odcDeleteFile.Connection = this.con1;
			this.odcDeleteFile.Parameters.Add(new System.Data.OleDb.OleDbParameter("FileID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FileID", System.Data.DataRowVersion.Original, null));
			// 
			// odcLoadFile
			// 
			this.odcLoadFile.CommandText = "SELECT FileBody, FileID FROM GEN_Files WHERE (FileID = ?)";
			this.odcLoadFile.Connection = this.con1;
			this.odcLoadFile.Parameters.Add(new System.Data.OleDb.OleDbParameter("FileID", System.Data.OleDb.OleDbType.Integer, 4, "FileID"));
			// 
			// GetFileID
			// 
			this.GetFileID.CommandText = "SELECT max(FileID) as fileid   FROM GEN_Files";
			this.GetFileID.Connection = this.con1;
			// 
			// FilesDataClass
			// 
			this.ComponentDataAdabter = this.odaFilesInfo;
			this.ComponentDataSet = this.dsFilesInfo1;
			this.Connection = this.con1;
			((System.ComponentModel.ISupportInitialize)(this.dsFilesInfo1)).EndInit();

		}
		#endregion

		public bool UpdateFileContent(int FileID,  byte[] Buffer)
		{
			odcUpdateFileContent.Parameters["Original_FileID"].Value = FileID;
			odcUpdateFileContent.Parameters["FileBody"].Value  =Buffer ;
			if (odcUpdateFileContent.ExecuteNonQuery() >0 )
			{
				dsFilesInfo Tempds = new dsFilesInfo();
				Tempds = (dsFilesInfo)List(FileID);
				if (Tempds == null) return false;
				Tempds.GEN_Files[0].FileCreationTime = DateTime.Now;
				Tempds.GEN_Files[0].FileSize = Buffer.GetLength(0).ToString();
				Tempds.GEN_Files[0].UserID = ActiveSession.UserId;
				Edit(Tempds);
			}
				return true;
			return false;
		}

		public byte[] LoadFileBody(int FileID)
		{
			odcLoadFile.Parameters[0].Value = FileID;
			byte[] Buffer = (byte[])odcLoadFile.ExecuteScalar();
			return Buffer;
		}
		// Get Max File ID
		public int mGetMaxFileID()
		{
			
			int vNfileID = Convert.ToInt32(GetFileID.ExecuteScalar());
			return vNfileID;
		}
//		protected override bool onAdd(System.Data.DataSet dsNewRecords)
//		{
//			foreach(DataRow TempRow in dsNewRecords.Tables["GEN_Files"].Rows)
//			{
//				//TempRow["UserID"] = ActiveSession.UserId;
//				//TempRow["FileCreationTime"] = DateTime.Now;
//			}
//			return base.onAdd (dsNewRecords);
//		}

	}
}
