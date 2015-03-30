using System;
using System.Data;
using System.Data.OleDb;
using TSN.ERP;
using TSN.ERP.XML;
namespace TSN.ERP.Engine
{
	/// <summary>
	/// This Class acts as a resource pool  for the server; 
	/// mainly to carry the connection or any other shared resource that could arise
	/// </summary>
	/// 
	[Serializable]
	internal class ResourcePool
	{
		private System.Data.OleDb.OleDbConnection MyConnection = new System.Data.OleDb.OleDbConnection();
		
		public ResourcePool()
		{
			this.OpenConnection();
		}
		#region Connection Handling
		public string GetConnectionString()
		{
			//return @"Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ERPdb;Data Source=BASSAM;Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=BASSAM;Use Encryption for Data=False;Tag with column collation when possible=False";
			ConnFileLoader ConnectonFile = new ConnFileLoader();
			return ConnectonFile.GetDefaultUserConn(ERP.Engine.Server.ServerSettings.GetConnectionFile());
		}
		public bool OpenConnection()
		{
			try
			{
				this.Connection.Close();
				this.Connection.ConnectionString = this.GetConnectionString();
				this.Connection.Open();
				return true;
			}
			catch
			{
				string VsCon=this.GetConnectionString();
				OleDbConnection con=new OleDbConnection(VsCon);
				con.Close();
				con.Open();
				string rr="";
			
           
			return true;

			}
		}
		public System.Data.OleDb.OleDbConnection Connection
		{
			get
			{
				this.MyConnection.Close();
				this.MyConnection.ConnectionString=this.GetConnectionString();
		
				return this.MyConnection;
			}
			set
			{
             Connection=value;
			}
		}
		#endregion
	}
}
