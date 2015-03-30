using System;
using System.Data;
namespace TSN.ERP.Engine
{
	/// <summary>
	/// Summary description for DataUtils.
	/// </summary>
	public class DataUtils
	{
		public static DataUtils DataUtility = new DataUtils();
		public DataUtils()
		{
		}
		#region DataSet Join 1To1
		public DataSet JoinDataSets1To1(DataSet ds1, DataSet ds2,int table1ID,int table2ID, string col1ID,string col2ID)
		{
			// join schema
			ds1.EnforceConstraints = false;
			ds2.EnforceConstraints = false;
			DataSet dsTemp = new DataSet();
			dsTemp.Merge(ds2);
			int col1Count = ds1.Tables[table1ID].Columns.Count;
			int col2Count = ds2.Tables[table2ID].Columns.Count;
			DataColumn[] tempColArray = new DataColumn[col2Count] ;
			dsTemp.Tables[table2ID].Columns.CopyTo(tempColArray,0);
			for (int o = col2Count-1;o>=0;o--)
			{
				if (tempColArray[o].ColumnName == col2ID)
				{
					tempColArray[o] =null;
				}
				else
				{
					dsTemp.Tables[table2ID].Columns.RemoveAt(o);
				}
			}
			ds1.Tables[table1ID].Columns.AddRange(tempColArray);

			
			//Intiating DataView
			DataView dv1 = new DataView(ds1.Tables[table1ID]);
			dv1.Sort = ds1.Tables[table1ID].Columns[col1ID].ColumnName; 
			DataView dv2 = new DataView(ds2.Tables[table2ID]);
			dv2.Sort = ds2.Tables[table2ID].Columns[col2ID].ColumnName;
			
			//Intiating Loop
			int rowCount1 = dv1.Count;
			int rowCount2 = dv2.Count;
		
			int LastIndex = 0;
			int colLocation = ds2.Tables[table2ID].Columns.IndexOf(col2ID);
			for (int i=0;i<rowCount1;i++ )
			{
				DataRow row1  = dv1[i].Row;
				object searchVal = row1[col1ID];
				for (int j = LastIndex; j < rowCount2;j++)
				{
					DataRow row2 = dv2[j].Row;
					if (searchVal.ToString() == row2[col2ID].ToString())
					{
						for (int k = 0 ; k < col2Count;k++)
						{
							if (k < colLocation)
								row1[col1Count + k ] = row2[k];
							if (k > colLocation)
								row1[col1Count + k -1] = row2[k];
						}
						LastIndex = j;
						continue;
					}
				}
			}
			return ds1;
		}

		#endregion
		#region SQL Script Support
		public string GenerateGlobalSelectCommand(DataTable Table1, DataTable Table2)
		{
			int Colcount1 = Table1.Columns.Count;
			int Colcount2 = Table2.Columns.Count;
			string pkname1 = Table1.TableName +"."+Table1.PrimaryKey[0].ColumnName;
			string pkname2 = Table2.TableName +"."+Table1.PrimaryKey[0].ColumnName;
			string SqlText = "Select ";
			bool FirstTime = true;
			for (int i=0;i<Colcount1;i++)
			{
				
				if (FirstTime)
				{
					SqlText = SqlText + " " +   Table1.TableName +"."+Table1.Columns[i].ColumnName;
					FirstTime = false;
				}
				else
				{
					SqlText = SqlText + ", " +   Table1.TableName +"."+Table1.Columns[i].ColumnName;
				}
			}
			for(int j=0;j< Colcount2;j++)
			{
				string colName = Table2.TableName +"."+Table2.Columns[j].ColumnName;
				if (colName == pkname2)
					continue;
				if (FirstTime)
				{
					SqlText = SqlText + " " +  colName ;
					FirstTime = false;
				}
				else
				{
					SqlText = SqlText + ", " +   colName;
				}
			}
			SqlText = SqlText + " From " + Table1.TableName + " INNER JOIN " + Table2.TableName + " ON " + pkname1 + " = " + pkname2;
			return SqlText;
		}
		public string GenerateGlobalSelectCommand(DataTable Table1, DataTable Table2,string Filter)
		{
			string sqltext = GenerateGlobalSelectCommand(Table1,Table2);
			sqltext = sqltext + " Where " + Filter ;
			return sqltext;
		}
		#endregion
	
	}
}
