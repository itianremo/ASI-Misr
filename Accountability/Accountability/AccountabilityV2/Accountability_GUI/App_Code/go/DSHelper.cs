using System;
using System.Data;

namespace TSN.ERP.WebGUI.Go
{
	/// <summary>
	/// Used to join two table based on the given two columns array. 
	/// </summary>
	public class DSHelper
	{
		public DSHelper()
		{
		
		}
		//FJC = First Join Column
		//SJC = Second Join Column
		/// <summary>
		/// Returns the inner join of the two given tables
		/// </summary>
		/// <param name="First">First table</param>
		/// <param name="Second">Second table</param>
		/// <param name="FJC">Columns of first table</param>
		/// <param name="SJC">Columns of second table</param>
		/// <returns></returns>
		public static DataTable Join (DataTable First, DataTable Second, DataColumn[] FJC, DataColumn[] SJC)
		{
			//Create Empty Table
			DataTable table = new DataTable("Join");
			// Use a DataSet to leverage DataRelation
			using(DataSet ds = new DataSet())
			{
				//Add Copy of Tables
				ds.Tables.AddRange(new DataTable[]{First.Copy(),Second.Copy()});
				//Identify Joining Columns from First
				DataColumn[] parentcolumns = new DataColumn[FJC.Length];
				for(int i = 0; i < parentcolumns.Length; i++)
				{
					parentcolumns[i] = ds.Tables[0].Columns[FJC[i].ColumnName];
				}
				//Identify Joining Columns from Second
				DataColumn[] childcolumns = new DataColumn[SJC.Length];
				for(int i = 0; i < childcolumns.Length; i++)
				{
					childcolumns[i] = ds.Tables[1].Columns[SJC[i].ColumnName];
				}
				//Create DataRelation
				DataRelation r = new DataRelation(string.Empty,parentcolumns,childcolumns,false);
				ds.Relations.Add(r);
				//Create Columns for JOIN table
				for(int i = 0; i < First.Columns.Count; i++)
				{
					table.Columns.Add(First.Columns[i].ColumnName, First.Columns[i].DataType);
				}
				for(int i = 0; i < Second.Columns.Count; i++)
				{
					//Beware Duplicates
					if(!table.Columns.Contains(Second.Columns[i].ColumnName))
						table.Columns.Add(Second.Columns[i].ColumnName, Second.Columns[i].DataType);
					else
						table.Columns.Add(Second.Columns[i].ColumnName + "_Second", Second.Columns[i].DataType);
				}
				//Loop through First table
				table.BeginLoadData();
				foreach(DataRow firstrow in ds.Tables[0].Rows)
				{
					//Get "joined" rows
					DataRow[] childrows = firstrow.GetChildRows(r);
					if(childrows != null && childrows.Length > 0)
					{
						object[] parentarray = firstrow.ItemArray; 
						foreach(DataRow secondrow in childrows)
						{
							object[] secondarray = secondrow.ItemArray;
							object[] joinarray = new object[parentarray.Length+secondarray.Length];
							Array.Copy(parentarray,0,joinarray,0,parentarray.Length);
							Array.Copy(secondarray,0,joinarray,parentarray.Length,secondarray.Length);
							table.LoadDataRow(joinarray,true);
						}
					}
				}
				table.EndLoadData();
			}
			return table;
		}

		public static DataTable Join (DataTable First, DataTable Second, DataColumn FJC, DataColumn SJC)
		{
			return DSHelper.Join(First, Second, new DataColumn[]{FJC}, new DataColumn[]{SJC});
		}
		public static DataTable Join (DataTable First, DataTable Second, string FJC, string SJC)
		{
			return DSHelper.Join(First, Second, new DataColumn[]{First.Columns[FJC]}, new DataColumn[]{First.Columns[SJC]});
		}
	}
}
