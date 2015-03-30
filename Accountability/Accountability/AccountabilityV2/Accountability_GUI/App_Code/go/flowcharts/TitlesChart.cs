using System;
using System.Drawing;
using MindFusion.FlowChartX.LayoutSystem;
using MindFusion.FlowChartX;
using System.Data;
using System.Collections;

namespace TSN.ERP.WebGUI.Go.flowcharts
{
	/// <summary>
	/// Title Chart
	/// </summary>
	[Serializable]
	public class TitlesChart :Chart
	{
		//----------------------------------------------------------------------------
		#region Constructor
		/// <summary>
		/// Here we call the parent (Chart) constructor, which fill all dataview we may use during rendering process
		/// </summary>
		public TitlesChart( ):base(  )
		{	
		}
		#endregion
		//----------------------------------------------------------------------------
		#region Render title chart
		/// <summary>
		/// Draw title chart based on pre-set parameters
		/// </summary>
		/// <returns>Flowchart object</returns>
		public override FlowChart Render()
		{		
			fc = new FlowChart();
			// initialize flow chart
			InitFlowChart(fc);
			// Draw the root node
			float rowHeight = this.DeptFont.Size * 3;
			Table node = fc.CreateTable(0, 0, fc.TableColWidth, rowHeight * GetRowsNumber(2) +1);
			node.RowHeight = rowHeight;
			AddNodeItem(node,"", this.CompElementName,this.DeptFontColor);
			node.Tag = this.CompElementID;
			node.Font = this.DeptFont;
			node.FillColor = this.DeptBackColor;
			node.FrameColor = this.DeptBorderColor;
			//node.Columns[0].ColumnStyle = EColumnStyle.csAutoWidth;
			if (this.ShowDeptEmpNo)
			{
				AddNodeItem(node,"Emp # :", GetEmpNumber(null,node.Tag.ToString()).ToString(),this.DeptEmpNoFontColor);
			}
			if (this.ShowDeptManager)
			{
				string deptManager = GetDeptManager(this.CompElementID.ToString());
				AddNodeItem(node,"Mgr :", deptManager,this.DeptManagerFontColor);
			}
			// Draw all jobs available in given department node
			DrawJobsNodes(node);
			// Configure the tree layout
			SetChartLayout(fc);
			return fc;
		}	
		#endregion
	}
}
