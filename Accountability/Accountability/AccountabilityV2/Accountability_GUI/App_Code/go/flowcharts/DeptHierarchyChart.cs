using System;
using System.Drawing;
using MindFusion.FlowChartX.LayoutSystem;
using MindFusion.FlowChartX;
using System.Web;
using TSN.ERP.WebGUI;
using System.Data;
using System.Collections;
using System.Xml.Serialization;


namespace TSN.ERP.WebGUI.Go.flowcharts
{
	/// <summary>
	/// Used to create department hierarchy chart
	/// </summary>
	/// 
	public class DeptHierarchyChart : Chart
	{
		//-----------------------------------------------------------------------------
		public DeptHierarchyChart( ):base( )
		{}
		//-----------------------------------------------------------------------------
		#region Draw department hierarhcy chart
		/// <summary>
		/// Overriden render method, used to draw department hierarchy based on chart parameters.
		/// </summary>
		/// <returns>Flowchart object</returns>
		public override FlowChart Render()
		{
			// Chart general properties
			fc = new FlowChart();
			InitFlowChart(fc);
			// Draw the root node
			float rowHeight = this.DeptFont.Size * 3;
			fc.TableFillColor = this.DeptBackColor;
            float mglilh = rowHeight * GetRowsNumber(2) + 1;
            //fc.AccessibleDescription = "29-12-2010";
            // just for test by mglil
            
			Table node = fc.CreateTable(0, 0, fc.TableColWidth, rowHeight * GetRowsNumber(2)+1);
           
			node.RowHeight = rowHeight ;
			AddNodeItem(node,"",this.CompElementName,this.DeptFontColor);
			node.FrameColor = this.DeptBorderColor;
			node.Tag = this.CompElementID;
			node.Font = this.DeptFont;
            // 22-2-2010 added by MG to show manager photo in muti level chart and remove displaying  manager from employees
            HttpContext.Current.Session["ManagerName"] = "";
            // end 22-2-2010
			if (this.ShowDeptManager)
			{
				DataRow[] drDept = this.dvDept.Table.Select("CompElmentID = '"+this.CompElementID.ToString()+"'");
				string deptManager = GetDeptManager(drDept[0]["ContactID"].ToString());
                // 22-2-2010 added by MG to show manager photo in muti level chart and remove displaying  manager from employees
                HttpContext.Current.Session["ManagerName"] = deptManager;
                // end 22-2-2010
                // add job title 08232010 by MG
                try
                {
                    string deptManagerTitle = GetManagerTitle(drDept[0]["ContactID"].ToString());
                    AddNodeItem(node, "", deptManagerTitle, this.EmpTitleFontColor);

                }
                catch
                {
                    string x = "";
                }

                AddNodeItem(node,"",deptManager,this.DeptManagerFontColor);

                

				//GetDeptManager(node,drDept[0]["ContactID"].ToString());
                // 22-2-2010 added by MG to show manager photo in muti level chart and remove displaying  manager from employees
                #region add Manager photo
                if (this.ShowEmpPhoto)
                {
                    node.AddRow();

                    node[0, node.RowCount - 1].Picture = getEmpImage(int.Parse(drDept[0]["ContactID"].ToString()));
                    node.Rows[node.RowCount - 1].Height = rowHeight + 50;
                    node.Resize(fc.TableColWidth, rowHeight * (GetRowsNumber(1)+1) + 51);
                    node.FitSizeToPicture();
                }
                #endregion
               // end 22-2-2010
			}
			
				GetChildren(node);

                /*// commented on 03/05/2010 by mglil no need to readd Manager info again
                if (this.ShowDeptManager)
                {
                    DataRow[] drDept = this.dvDept.Table.Select("CompElmentID = '"+this.CompElementID.ToString()+"'");
                    //GetDeptManager(node,drDept[0]["ContactID"].ToString()); 
                
                }
                 */

			// if group by titles option is selected
			if (this.GroupByEmpTitles)
				DrawJobsNodes(node);   // draw jobs node
			else
				if (this.ShowEmpName)  // if show employee option is selected
					GetEmployee(null,node);   // get department employees

			// Configure the tree layout
			SetChartLayout(fc);
			return fc;
		}
		#endregion
		//-----------------------------------------------------------------------------
		// render the children of the given company element
		private int GetChildren(Table rootNode)
		{
			int empNO =0;
			if (this.ShowDeptEmpNo)
				empNO = GetEmpNumber(null,rootNode.Tag.ToString());
			DataSet compDS = ((Navigation.BaseObject) System.Web.HttpContext.Current.Session[ "navigation" ]).CompanyWsObject.ListChildrenElments(int.Parse(rootNode.Tag.ToString()));
			foreach(DataRow dr in compDS.Tables[0].Rows)
			{
                int rowcount = compDS.Tables[0].Rows.Count;

				
				float rowHeight = this.DeptFont.Size * 3;
                float mglilh = rowHeight * GetRowsNumber(2) + 1;
                
				Table node = fc.CreateTable(0, 0,fc.TableColWidth, rowHeight * GetRowsNumber(2)+1); // 08232010 
				node.RowHeight = rowHeight;
				AddNodeItem(node,"",dr["CEName"].ToString().Trim(),this.DeptFontColor);
				node.Font = this.DeptFont; 
				node.Tag = dr["CompElmentID"].ToString();
				node.FrameColor = this.DeptBackColor;

               
               

				if (this.ShowDeptManager) 
				{
					string deptManager = GetDeptManager(dr["ContactID"].ToString());
                    // 22-2-2010 added by MG to show manager photo in muti level chart and remove displaying  manager from employees
                    System.Web.HttpContext.Current.Session["ManagerName"] = deptManager;
                    // end 22-2-2010

                    // add job title 08232010 by MG
                    try
                    {
                        string deptManagerTitle = GetManagerTitle(dr["ContactID"].ToString());
                        AddNodeItem(node, "", deptManagerTitle, this.EmpTitleFontColor);

                    }
                    catch
                    {
                        continue;
                    }

					// 08232010 add for test by Mglil
                    AddNodeItem(node,"",deptManager,this.DeptManagerFontColor);
                    // end 08232010

                    
                   
                    #region add Manager photo
                    if (this.ShowEmpPhoto)
                    {
                        node.AddRow();

                        node[0, node.RowCount - 1].Picture = getEmpImage(int.Parse(dr["ContactID"].ToString()));
                        node.Rows[node.RowCount - 1].Height = rowHeight + 50;
                        node.Resize(fc.TableColWidth, rowHeight * (GetRowsNumber(1)+1) + 51);// was + 51 08202010
                        node.FitSizeToPicture();
                    }    
                    #endregion
                    // end 22-2-2010
                }
				// link this node with its parent
				fc.CreateArrow(rootNode,node);							
				// get jobs node if user select to view it
				if (this.GroupByEmpTitles)
					DrawJobsNodes(node);
				else
					if (this.ShowEmpName)  // if show employee option is selected
						GetEmployee(null,node);   // get department employees
				// Calculate number of employees
				empNO = empNO + GetChildren(node);
			}
			if (this.ShowDeptEmpNo)
			{
				AddNodeItem(rootNode,"Emp # :",empNO.ToString(),this.DeptEmpNoFontColor);
			}
            // 22-2-2010 added by MG to show manager photo in muti level chart and remove displaying  manager from employees
            System.Web.HttpContext.Current.Session["ManagerName"] = "";
            // end 22-2-2010
			
			return empNO; 
		}
	}
}
