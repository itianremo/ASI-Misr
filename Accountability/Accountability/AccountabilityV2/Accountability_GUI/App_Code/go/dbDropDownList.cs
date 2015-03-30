using System;
using System.Data;
using System.Web.UI.WebControls;


namespace TSN.ERP.WebGUI.Go
{
	/// <summary>
	/// Data bindable list box
	/// </summary>
	public class dbListBox : System.Web.UI.WebControls.DropDownList
	{
		public dbListBox()
		{
			
		}
		public void fill(DataSet ds)
		{
			// clear old items
			this.Items.Clear();
			// fill the new set
			// the first filed in the dataset is the item's value, 
			//the second is the item's text
			foreach ( DataRow dr in ds.Tables[0].Rows)
			{
				ListItem li = new ListItem(dr[1].ToString(),dr[0].ToString());
				this.Items.Add(li);
			}
		
		}

	}
}
