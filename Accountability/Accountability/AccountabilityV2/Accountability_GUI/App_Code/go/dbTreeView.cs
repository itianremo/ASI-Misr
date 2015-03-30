using System;
using Microsoft.Web.UI.WebControls;
using System.Data;

namespace TSN.ERP.WebGUI.Go
{
	/// <summary>
	/// Bindable Tree View
	/// </summary>
	public class dbTreeView : TreeView
	{
		public dbTreeView()
		{
			
		}
		// selected treenode
		dbTreeNode selectedTreeNode = new dbTreeNode();
		//---------------------------------
		public void bind(DataSet ds)
		{
			int cntr = 0;
			if (ds!=null && ds.Tables.Count>0)
			{
				this.Nodes.Clear();
				cntr = 0;
				foreach (DataRow dr in ds.Tables[0].Rows)
				{	
					if (dr["CEParent"] == System.DBNull.Value)
					{
						TreeNode treeNode = new TreeNode();                     
						treeNode.Text   =   dr["CEName"].ToString() ;
						treeNode.ID     = dr["CompElmentID"].ToString();
						treeNode.NodeData = dr["CEL_ID"].ToString();
						treeNode.Type = cntr.ToString();
						this.Nodes.Add( treeNode );
						FillChildren(ref treeNode,ref ds);
					}	
					cntr++;
				}
			}
		}
		//--------------------------------------------------
		private void FillChildren(ref TreeNode tn, ref DataSet ds)
		{
			int cntr = 0;
			if (ds!=null && ds.Tables.Count>0)
			{
				cntr =0;
				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					if (dr["CEParent"].ToString() == tn.ID)
					{
						TreeNode treeNode = new TreeNode();
						treeNode.Text   = dr["CEName"].ToString();
						treeNode.ID     = dr["CompElmentID"].ToString();
						treeNode.NodeData = dr["CEL_ID"].ToString();
						treeNode.Type = cntr.ToString();
						tn.Nodes.Add ( treeNode );
						FillChildren(ref treeNode,ref ds);
					}	
					cntr++;
				}
			}
		}
		//--------------------------------------------------
		// get selected node's parameters 
		public dbTreeNode  getSelectedNode()
		{
			this.selectedTreeNode.CompElmentId = int.Parse(this.GetNodeFromIndex(this.SelectedNodeIndex).ID);
			if ( this.GetNodeFromIndex(this.SelectedNodeIndex).NodeData != "" )
				this.selectedTreeNode.CEL_ID = int.Parse(this.GetNodeFromIndex(this.SelectedNodeIndex).NodeData);
			this.selectedTreeNode.CEName = this.GetNodeFromIndex(this.SelectedNodeIndex).Text; 
			this.selectedTreeNode.DSIndex =int.Parse(this.GetNodeFromIndex(this.SelectedNodeIndex).Type); //Node index           
			return this.selectedTreeNode;
		}
	}
	public class dbTreeNode
	{
		//-------------------------------------------------
		private int m_CompElmentId ;  // Company element ID
		private int m_CEL_ID;   // Element type [Division, department, Project ...]
		private string m_CEName;   // Element Name	
		public int DSIndex;        // Index of selected node [begins from zero]
		//-------------------------------------------------
		public int CompElmentId
		{
			get
			{
				return m_CompElmentId;
			}
			set
			{
				m_CompElmentId = value;
			}
		}
		//--------------------------------------------------
		public int CEL_ID
		{
			get
			{
				return m_CEL_ID;
			}
			set
			{
				m_CEL_ID = value;
			}
		}
		//--------------------------------------------------
		public string CEName
		{
			get
			{
				return m_CEName;
			}
			set
			{
				m_CEName = value;
			}
		}
		//--------------------------------------------------
	}
}
