using System;
using System.Data;
using System.Collections;

namespace TSN.ERP.WebGUI
{
	/// <summary>
	/// Summary description for MasterMethods.
	/// </summary>
	public class MasterMethods
	{
		public MasterMethods()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public System.Data.DataTable CreateTableFromView(System.Data.DataView obDataView)
		{
			if (null == obDataView)
			{
				throw new ArgumentNullException
					("DataView", "Invalid DataView object specified");
			}

			DataTable obNewDt = obDataView.Table.Clone();
			int idx = 0;
			string [] strColNames = new string[obNewDt.Columns.Count];
			foreach (DataColumn col in obNewDt.Columns)
			{
				strColNames[idx++] = col.ColumnName;
			}

			IEnumerator viewEnumerator = obDataView.GetEnumerator();
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
	}
}
