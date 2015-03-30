using System;
using System.Drawing;
using MindFusion.FlowChartX.LayoutSystem;
using MindFusion.FlowChartX;
using System.Data;
using System.Collections;
using System.Xml.Serialization; 
using System.IO;



namespace TSN.ERP.WebGUI.Go.flowcharts
{
	/// <summary>
	/// Chars base class, all charts attributes are defined here. this Class define a virtual function (Render)
	/// which must be overriden in each child class.
	/// Note : To add a new chart, just create a new class, let it be inherited from chart class and 
	/// override the Render function
	/// </summary>
	[Serializable]
	public class Chart
	{
		#region private memebers
		/// <summary>
		/// Chart ID
		/// </summary>
		private int _ID;
		/// <summary>
		/// Chart Name
		/// </summary>
		private string _Name;
		/// <summary>
		/// Root company element id, used in only in departments and job- charts, this is the root node
		/// </summary>
		private int _CompElementID;
		/// <summary>
		/// Type of the chart
		/// <li>1 ... Department chart</li>
		/// <li>2 ... Title chart</li>
		/// <li>3 ... Team chart</li>
		/// <li>4 ... Project chart</li>
		/// </summary>
		private int _Type;
		/// <summary>
		/// Root company element name, used only in departments and  charts 
		/// </summary>
		private string _CompElementName;
		/// <summary>
		/// Array of all selected projects IDs in project chart.
		/// </summary>
		private ArrayList _ProjectsIDs;
		/// <summary>
		/// Array of all selected teams IDs in teams chart.
		/// </summary>
		private ArrayList _TeamsIDs;
		/// <summary>
		/// Denotes whether to show employees nodes or not
		/// </summary>
		private bool _ShowEmpName;
		/// <summary>
		/// Denotes whether to show employee's department or not
		/// </summary>
		private bool _ShowEmpDept;
		/// <summary>
		/// Denotes whether to show employees's title or not
		/// </summary>
		private bool _ShowEmpTitle;
		/// <summary>
		/// Denotes whether to show employee's code or not
		/// </summary>
		private bool _ShowEmpCode;
		/// <summary>
		/// Denotes whether to show employee's personal photo or not
		/// </summary>
		private bool _ShowEmpPhoto;
		/// <summary>
		/// Denotes whether to show teams that each employee is member in or not
		/// </summary>
		private bool _ShowEmpTeams;
		/// <summary>
		/// Denotes whether to show project that each employee is working on or not
		/// </summary>
		private bool _ShowEmpProjects;
		/// <summary>
		/// Denotes whether to show department manager or not
		/// </summary>
		private bool _ShowDeptManager;
		/// <summary>
		/// Denotes whether to show number of employees in each department or not
		/// </summary>
		private bool _ShowDeptEmpNo;
		/// <summary>
		/// Denotes whether to show number of employees occupying each job or not
		/// </summary>
		private bool _ShowTitleEmpNo;
		/// <summary>
		/// Denotes whether to show project manager or not
		/// </summary>
		private bool _ShowProjectManager;
		/// <summary>
		/// Denotes whether to show number of employees working on each project or not
		/// </summary>
		private bool _ShowProjectEmpNo;
		/// <summary>
		/// Denotes whether to show team leader or not
		/// </summary>
		private bool _ShowTeamLeader;
		/// <summary>
		/// Denotes whether to show number of employees in each team or not
		/// </summary>
		private bool _ShowTeamEmpNo;
		/// <summary>
		/// Denotes whether to group employee by their job  or not
		/// </summary>
		private bool _GroupByEmpTitles;
		/// <summary>
		/// Arrow color
		/// </summary>
	 	private Color _ArrowColor;
		/// <summary>
		/// Department node back color
		/// </summary>
		private Color _DeptBackColor;
		/// <summary>
		/// Department border color
		/// </summary>
		private Color _DeptBorderColor;
		/// <summary>
		/// Department node font color
		/// </summary>
		private Color _DeptFontColor;
		/// <summary>
		/// Department node font
		/// </summary>
	 	private Font _DeptFont;
		/// <summary>
		/// Number of employees in each department font color
		/// </summary>
	 	private Color _DeptEmpNoFontColor;
		/// <summary>
		/// Department manager font color
		/// </summary>
	 	private Color _DeptManagerFontColor;
		/// <summary>
		/// Employee node back color
		/// </summary>
	 	private Color _EmpBackColor ;
		/// <summary>
		/// Employee node border color
		/// </summary>
	 	private Color _EmpBorderColor;
		/// <summary>
		/// Employee name font color
		/// </summary>
	 	private Color _EmpNameFontColor;
		/// <summary>
		/// Employee node font
		/// </summary>
		private Font _EmpFont;
		/// <summary>
		/// Employee's department font color
		/// </summary>
	 	private Color _EmpDeptFontColor;
		/// <summary>
		/// Employee's title font color
		/// </summary>
	 	private Color _EmpTitleFontColor;
		/// <summary>
		/// Employee's code font color 
		/// </summary>
	 	private Color _EmpCodeFontColor;
		/// <summary>
		/// Employee's teams font color
		/// </summary>
	 	private Color _EmpTeamsFontColor;
		/// <summary>
		/// Employee's project font color
		/// </summary>
	 	private Color _EmpProjectsFontColor;
		/// <summary>
		/// Title node back color
		/// </summary>
		private Color _TitleBackColor;
		/// <summary>
		/// Title node border color
		/// </summary>
		private Color _TitleBorderColor;
		/// <summary>
		/// Job title font color
		/// </summary>
		private Color _TitleFontColor;
		/// <summary>
		/// Title node font
		/// </summary>
		private Font _TitleFont;
		/// <summary>
		/// Number of employees in each title font color
		/// </summary>
		private Color _TitleEmpNoFontColor;
		/// <summary>
		/// Team node back color
		/// </summary>
		private Color _TeamBackColor;
		/// <summary>
		/// Team node border color
		/// </summary>
		private Color _TeamBorderColor;
		/// <summary>
		/// Team font color
		/// </summary>
		private Color _TeamFontColor;
		/// <summary>
		/// Team node font
		/// </summary>
		private Font _TeamFont;
		/// <summary>
		/// Number of employees in each team font color
		/// </summary>
		private Color _TeamEmpNoFontColor;
		/// <summary>
		/// Team leader font color
		/// </summary>
		private Color _TeamLeaderFontColor;
		/// <summary>
		/// Project node back color
		/// </summary>
		private Color _ProjectBackColor;
		/// <summary>
		/// Project node border color
		/// </summary>
		private Color _ProjectBorderColor;
		/// <summary>
		/// Project font color
		/// </summary>
		private Color _ProjectFontColor;
		/// <summary>
		/// Project node font
		/// </summary> 
		private Font _ProjectFont;
		/// <summary>
		/// Number of employees in each project font color
		/// </summary>
		private Color _ProjectEmpNoFontColor;
		/// <summary>
		/// Project manager font color
		/// </summary>
		private Color _ProjectManagerFontColor;
		
		/// <summary>
		/// Chart layout type
		/// </summary>
		[XmlIgnore]
		private TreeLayoutType _TreeLayout;
		/// <summary>
		/// Chart layout direction
		/// </summary>
		[XmlIgnore]
		private TreeLayoutDirection _TreeDirection;
		/// <summary>
		/// Chart arrow type
		/// </summary>
		[XmlIgnore]
		private TreeLayoutArrowType _ArrowType;
		/// <summary>
		/// Flow chart
		/// </summary>
		[XmlIgnore]
		public FlowChart fc;
		/// <summary>
		/// Job  dataview, filled once at the begining of the rendering process, and used anywhere
		/// </summary>
		[XmlIgnore]public  DataView dvJobs;
		/// <summary>
		/// Department dataview, filled once at the begining of the rendering process, and used anywhere
		/// </summary>
		[XmlIgnore]public DataView dvDept;  
		/// <summary>
		/// Employee dataview, filled once at the begining of the rendering process, and used anywhere
		/// </summary>
		[XmlIgnore]public DataView dvEmployee;
		// Chart types enumerator
		public enum ChartTypes{DeptChart=1,TitleChart,TeamChart,ProjectChart}
		// Node types enumerator
		public enum NodeTypes{EmployeeNode=1,DeptNode,TitleNode,TeamNode,ProjectNode}

		

		#endregion
		//-------------------------------------------------------------------------------
		#region Constructor
		public Chart( )
		{
			
			//_Page = page;
			// get all jobs
		    dvJobs = ((Navigation.BaseObject) System.Web.HttpContext.Current.Session[ "navigation" ]).JobTiltesWsObject.ListJobtitles().Tables[0].DefaultView;
            dvJobs.RowFilter = "IsActive = True";
			// get all employees
			dvEmployee = ((Navigation.BaseObject) System.Web.HttpContext.Current.Session[ "navigation" ]).EmployeeWsObject.ListEmployees().Tables[0].DefaultView;
            dvEmployee.RowFilter = "EmployeeStatus = 1";
			// get all company elements
			dvDept = ((Navigation.BaseObject) System.Web.HttpContext.Current.Session[ "navigation" ]).CompanyWsObject.ListCompnayElements().Tables[0].DefaultView;
           
		}
		#endregion
		//-------------------------------------------------------------------------------
		#region setters and gettres
		public int ID
		{
			get {return _ID; }
			set {_ID = value;}
		}
		public string Name
		{
			get {return _Name; }
			set {_Name = value;}
		}	 
		
		public int CompElementID
		{
			get {return _CompElementID; }
			set {_CompElementID = value;}
		}
		public int Type
		{
			get {return _Type; }
			set {_Type = value;}
		}
		public string CompElementName
		{
			get {return _CompElementName; }
			set {_CompElementName = value;}
		}
		[XmlIgnore]
		public ArrayList ProjectsIDs
		{
			get {return _ProjectsIDs; }
			set {_ProjectsIDs = value;}
		}
		[XmlIgnore]
		public ArrayList TeamsIDs
		{
			get {return _TeamsIDs; }
			set {_TeamsIDs = value;}
		}

		public bool ShowEmpName
		{
			get {return _ShowEmpName; }
			set {_ShowEmpName = value;}
		}
		public bool ShowEmpCode
		{
			get {return _ShowEmpCode; }
			set {_ShowEmpCode = value;}
		}
		public bool ShowEmpDept
		{
			get {return _ShowEmpDept; }
			set {_ShowEmpDept = value;}
		}
		public bool ShowEmpTitle
		{
			get {return _ShowEmpTitle; }
			set {_ShowEmpTitle = value;}
		}

		public bool ShowEmpPhoto
		{
			get {return _ShowEmpPhoto; }
			set {_ShowEmpPhoto = value;}
		}
		public bool ShowEmpTeams
		{
			get {return _ShowEmpTeams; }
			set {_ShowEmpTeams = value;}
		}
		public bool ShowEmpProjects
		{
			get {return _ShowEmpProjects; }
			set {_ShowEmpProjects = value;}
		}
		public bool ShowDeptManager
		{
			get {return _ShowDeptManager; }
			set {_ShowDeptManager = value;}
		}
		public bool ShowDeptEmpNo
		{
			get {return _ShowDeptEmpNo; }
			set {_ShowDeptEmpNo = value;}
		}
		public bool ShowTitleEmpNo
		{
			get {return _ShowTitleEmpNo; }
			set {_ShowTitleEmpNo = value;}
		}
		public bool ShowProjectManager
		{
			get {return _ShowProjectManager; }
			set {_ShowProjectManager = value;}
		}
		public bool ShowProjectEmpNo
		{
			get {return _ShowProjectEmpNo; }
			set {_ShowProjectEmpNo = value;}
		}
		public bool ShowTeamLeader
		{
			get {return _ShowTeamLeader; }
			set {_ShowTeamLeader = value;}
		}
		public bool ShowTeamEmpNo
		{
			get {return _ShowTeamEmpNo; }
			set {_ShowTeamEmpNo = value;}
		}
		public bool GroupByEmpTitles
		{
			get {return _GroupByEmpTitles; }
			set {_GroupByEmpTitles = value;}
		}

		[XmlIgnore]
		public Color ArrowColor
		{
			get {return _ArrowColor; }
			set {_ArrowColor = value;}
		}

		[XmlIgnore]
			//departments
		public Color DeptBackColor
		{
			get {return _DeptBackColor; }
			set {_DeptBackColor = value;}
		}
		[XmlIgnore]public Color DeptBorderColor
		{
			get {return _DeptBorderColor; }
			set {_DeptBorderColor = value;}
		}
		[XmlIgnore]public Color DeptFontColor
		{
			get {return _DeptFontColor; }
			set {_DeptFontColor = value;}
		}
		[XmlIgnore]public Font DeptFont
		{
			get {return _DeptFont; }
			set {_DeptFont = value;}
		}
		[XmlIgnore]public Color DeptEmpNoFontColor
		{
			get {return _DeptEmpNoFontColor; }
			set {_DeptEmpNoFontColor = value;}
		}
		[XmlIgnore]public Color DeptManagerFontColor
		{
			get {return _DeptManagerFontColor; }
			set {_DeptManagerFontColor = value;}
		}
		
		//Employees
		[XmlIgnore]public Color EmpBackColor
		{
			get {return _EmpBackColor; }
			set {_EmpBackColor = value;}
		}
		[XmlIgnore]public Color EmpBorderColor
		{
			get {return _EmpBorderColor; }
			set {_EmpBorderColor = value;}
		}
		public Color EmpNameFontColor
		{
			get {return _EmpNameFontColor; }
			set {_EmpNameFontColor = value;}
		}
		[XmlIgnore]public Font EmpFont
		{
			get {return _EmpFont; }
			set {_EmpFont = value;}
		}
		[XmlIgnore]public Color EmpDeptFontColor
		{
			get {return _EmpDeptFontColor; }
			set {_EmpDeptFontColor = value;}
		}
		
		[XmlIgnore]public Color EmpTitleFontColor
		{
			get {return _EmpTitleFontColor; }
			set {_EmpTitleFontColor = value;}
		}
		
		[XmlIgnore]public Color EmpTeamsFontColor
		{
			get {return _EmpTeamsFontColor; }
			set {_EmpTeamsFontColor = value;}
		}
		[XmlIgnore]public Color EmpProjectsFontColor
		{
			get {return _EmpProjectsFontColor; }
			set {_EmpProjectsFontColor = value;}
		}
		[XmlIgnore]public Color EmpCodeFontColor
		{
			get {return _EmpCodeFontColor; }
			set {_EmpCodeFontColor = value;}
		}

		// Projects
		[XmlIgnore]public Color ProjectBackColor
		{
			get {return _ProjectBackColor; }
			set {_ProjectBackColor = value;}
		}
		[XmlIgnore]public Color ProjectBorderColor
		{
			get {return _ProjectBorderColor; }
			set {_ProjectBorderColor = value;}
		}
		[XmlIgnore]public Color ProjectFontColor
		{
			get {return _ProjectFontColor; }
			set {_ProjectFontColor = value;}
		}
		[XmlIgnore]public Font ProjectFont
		{
			get {return _ProjectFont; }
			set {_ProjectFont = value;}
		}
		[XmlIgnore]public Color ProjectEmpNoFontColor
		{
			get {return _ProjectEmpNoFontColor; }
			set {_ProjectEmpNoFontColor = value;}
		}
		[XmlIgnore]public Color ProjectManagerFontColor
		{
			get {return _ProjectManagerFontColor; }
			set {_ProjectManagerFontColor = value;}
		}
		
		//Titles
		[XmlIgnore]public Color TitleBackColor
		{
			get {return _TitleBackColor; }
			set {_TitleBackColor = value;}
		}
		[XmlIgnore]public Color TitleBorderColor
		{
			get {return _TitleBorderColor; }
			set {_TitleBorderColor = value;}
		}
		[XmlIgnore]public Color TitleFontColor
		{
			get {return _TitleFontColor; }
			set {_TitleFontColor = value;}
		}
		[XmlIgnore]public Font TitleFont
		{
			get {return _TitleFont; }
			set {_TitleFont = value;}
		}
		[XmlIgnore]public Color TitleEmpNoFontColor
		{
			get {return _TitleEmpNoFontColor; }
			set {_TitleEmpNoFontColor = value;}
		}
		//Teams
		[XmlIgnore]public Color TeamBackColor
		{
			get {return _TeamBackColor; }
			set {_TeamBackColor = value;}
		}
		[XmlIgnore]public Color TeamBorderColor
		{
			get {return _TeamBorderColor; }
			set {_TeamBorderColor = value;}
		}
		[XmlIgnore]public Color TeamFontColor
		{
			get {return _TeamFontColor; }
			set {_TeamFontColor = value;}
		}
		[XmlIgnore]public Font TeamFont
		{
			get {return _TeamFont; }
			set {_TeamFont = value;}
		}
		[XmlIgnore]public Color TeamEmpNoFontColor
		{
			get {return _TeamEmpNoFontColor; }
			set {_TeamEmpNoFontColor = value;}
		}
		[XmlIgnore]public Color TeamLeaderFontColor
		{
			get {return _TeamLeaderFontColor; }
			set {_TeamLeaderFontColor = value;}
		}
		

		[XmlIgnore]public TreeLayoutType TreeLayout
		{
			get {return _TreeLayout; }
			set {_TreeLayout = value;}
		}

		[XmlIgnore]public TreeLayoutDirection TreeDirection
		{
			get {return _TreeDirection; }
			set {_TreeDirection = value;}
		}
		[XmlIgnore]public TreeLayoutArrowType ArrowType
		{
			get {return _ArrowType; }
			set {_ArrowType = value;}
		}
		#endregion
		//-------------------------------------------------------------------------------
		#region Render chart 
		/// <summary>
		/// Virtual render function, this function is overrided in each derived class
		/// </summary>
		/// <returns></returns>
		virtual public FlowChart Render()
		{
			return null;
		}
		#endregion
		//-------------------------------------------------------------------------------
		#region get rows number for given node
		/// <summary>
		/// Get number of row in given node
		/// </summary>
		/// <param name="type">Typo of node </param>
		/// <returns>number of rows</returns>
		protected int GetRowsNumber(int nodeType)
		{
			int rowNumber = 1;
			// employee node
			if (nodeType == (int)NodeTypes.EmployeeNode)
			{
				if (this.ShowEmpCode)
					rowNumber ++;
				if (this.ShowEmpPhoto)
					rowNumber++;
				if (this.ShowEmpDept)
					rowNumber ++;
				if (this.ShowEmpProjects)
					rowNumber++;
				if (this.ShowEmpTitle)
					rowNumber ++;
				if (this.ShowEmpTeams)
					rowNumber++;
			}
			// department node
			if (nodeType == (int)NodeTypes.DeptNode)
			{
				if (this.ShowDeptEmpNo)
                    rowNumber = rowNumber +2;
				if (this.ShowDeptManager)
                    rowNumber = rowNumber +2;
			}
			//Ttile node
			if (nodeType ==(int)NodeTypes.TitleNode)
			{
				if (this.ShowTitleEmpNo)
					rowNumber ++;
			}
			// team node
			if (nodeType ==(int)NodeTypes.TeamNode)
			{
				if (this.ShowTeamEmpNo)
					rowNumber ++;
				if (this.ShowTeamLeader)
					rowNumber ++;
			}
			// project node
			if (nodeType ==(int)NodeTypes.ProjectNode)
			{
				if (this.ShowProjectEmpNo)
					rowNumber ++;
				if (this.ShowProjectManager)
					rowNumber ++;
			}
			return rowNumber;
		}
		#endregion
		//-------------------------------------------------------------------------------
		#region initialize flow chart 
		public void InitFlowChart(FlowChart fc)
		{
			fc.MeasureUnit = GraphicsUnit.Pixel;
			fc.SelectAfterCreate = false;
			fc.ArrowHead = ArrowHead.Triangle;
			fc.ArrowColor = this.ArrowColor;
			fc.DocExtents = new RectangleF(0, 0, 500, 10000);
            //System.Windows.Forms.Control ctr = new System.Windows.Forms.Control("welcome");

            //fc.Controls.Add(ctr);
            // 24/02/2010 modified by MG to shrink the chart
			//fc.TableColWidth = 200;
			fc.TableColWidth = 120;
			fc.TableRowHeight = 20;
			fc.TableRowCount = 0;
			fc.TableColumnCount= 1;
			fc.TableCaptionHeight =0;
			fc.TableCaption = "";
			fc.ShadowsStyle = ShadowsStyle.OneLevel;
			fc.ShadowColor = Color.Black;
			fc.TableStyle = TableStyle.RoundedRectangle;
           
            //fc.BackColor = Color.LightBlue;
            fc.BackColor = Color.White;
			fc.TableStyle = TableStyle.Rectangle;
           
		}
		#endregion
		//-------------------------------------------------------------------------------
		#region get all jobs node for given company element
		protected  void DrawJobsNodes(Table deptNode)
		{
			ArrayList arrJobs = new ArrayList();
			arrJobs = GetDeptJobTitles(int.Parse(deptNode.Tag.ToString()));
			for(int j=0;j<arrJobs.Count;j++)
				{
					float rowHeight = this.TitleFont.Size * 3;
                    dvJobs.RowFilter = "IsActive = True and jobTitleId = " + arrJobs[j].ToString();
					Table jobNode = fc.CreateTable(1,1,fc.TableColWidth, rowHeight * GetRowsNumber(3)+1);
					jobNode.FillColor= this.TitleBackColor;
					jobNode.FrameColor = this.TitleBorderColor;
					jobNode.RowHeight = rowHeight  ;
					AddNodeItem(jobNode,"",dvJobs[0]["JobName"].ToString(),this.TitleFontColor);
					jobNode.Tag = arrJobs[j].ToString();
					jobNode.Font = this.TitleFont;
					fc.CreateArrow(deptNode ,jobNode);	
					if(this.ShowEmpName)
						GetEmployee(jobNode,deptNode);
					if(this.ShowTitleEmpNo)
					{
						AddNodeItem(jobNode,"Emp # :",GetEmpNumber(jobNode.Tag.ToString(),deptNode.Tag.ToString()).ToString(),this.TitleEmpNoFontColor);
					}
				}		
		}
		#endregion
		//-------------------------------------------------------------------------------
		#region get employees number in given departmt or/and employee 
		protected  int GetEmpNumber(string jobCode,string deptCode)
		{
			string filter;
			if (jobCode != null)
                filter = "EmployeeStatus = 1 and CompElmentID =" + deptCode + " and JobTitleID=" + jobCode;
			else
                filter = "EmployeeStatus = 1 and CompElmentID =" + deptCode;
			DataSet empDS = ((Navigation.BaseObject) System.Web.HttpContext.Current.Session[ "navigation" ]).EmployeeWsObject.ListEmployeesDetailedData(filter);
			return empDS.Tables[0].Rows.Count;
		}
		#endregion
		//-------------------------------------------------------------------------------
		#region Returns all job titles available in specific department
		/// <summary>
		/// Returns array of all job titles IDs which are available in given department.
		/// </summary>
		/// <param name="deptID">Department id</param>
		/// <returns>Array of job titles Ids</returns>
		protected ArrayList GetDeptJobTitles(int deptID)
		{
			ArrayList arrJobs = new ArrayList();
            string filter = "EmployeeStatus = 1 and CompElmentID =" + deptID.ToString();
			string currID = "-1";
			dvEmployee.RowFilter = filter;
			dvEmployee.Sort = "JobTitleID";
			for(int i =0;i< dvEmployee.Count;i++)			
			{
				if (dvEmployee[i]["JobTitleID"].ToString() != currID)
				{
					arrJobs.Add(dvEmployee[i]["JobTitleID"]);
					currID = dvEmployee[i]["JobTitleID"].ToString();
				}
			}
			return arrJobs;
		}
		#endregion
		//-------------------------------------------------------------------------------
		#region Get all employee in given department and/or job and bind it to the appropriate node
		protected void GetEmployee(Table jobNode,Table deptNode)
		 {
			string filter;
			if (jobNode != null)
                filter = "EmployeeStatus = 1 and CompElmentID =" + deptNode.Tag.ToString() + " and jobTitleId=" + jobNode.Tag.ToString();
			else
                filter = "EmployeeStatus = 1 and CompElmentID =" + deptNode.Tag.ToString();
			dvEmployee.RowFilter = filter; 
			for( int j=0 ; j<dvEmployee.Count;j++) 
			{
                int empcount = dvEmployee.Count;
				DataRow[] drDept = this.dvDept.Table.Select("CompElmentID = '"+this.CompElementID.ToString()+"'");
				string contactID = drDept[0]["ContactID"].ToString();
				if(dvEmployee[j]["ContactID"].ToString() == contactID)
					continue;

				float rowHeight = this.EmpFont.Size * 4;
                // 22-2-2010 added by MG to show manager photo in muti level chart and remove displaying  manager from employees
                string sessionData = System.Web.HttpContext.Current.Session["ManagerName"].ToString();

                if (System.Web.HttpContext.Current.Session["ManagerName"].ToString().Contains(dvEmployee[j]["FirstName"].ToString()) && System.Web.HttpContext.Current.Session["ManagerName"].ToString().Contains(dvEmployee[j]["LastName"].ToString()))
                {
                    string x = "";
                }
                else
                // end  22-2-2010 
                {
                    float xpos = j * 120;
                    float mglilh = rowHeight * GetRowsNumber(1) + 1;
                    Table empNode = fc.CreateTable(0, 0, fc.TableColWidth, rowHeight * GetRowsNumber(1) + 1);
                    empNode.FillColor = this.EmpBackColor;
                    empNode.RowHeight = rowHeight;

                    // 24-2-2010 Moved by MG  to show employee title before the name
 		           if (this.ShowEmpTitle)
                    {
                        dvJobs.RowFilter = "jobTitleId = " + dvEmployee[j]["JobTitleID"].ToString();
                        AddNodeItem(empNode, "", dvJobs[0]["JobName"].ToString(), this.EmpTitleFontColor);
                    }

                    AddNodeItem(empNode, "", dvEmployee[j]["FirstName"].ToString() + " " +
                        dvEmployee[j]["MiddleName"].ToString() + " " +
                        dvEmployee[j]["LastName"].ToString(), this.EmpNameFontColor);
                    empNode.Tag = dvEmployee[j]["ContactID"].ToString();
                    empNode.Font = this.EmpFont;
                   
                    if (this.ShowEmpCode)
                    {
                        AddNodeItem(empNode, "Code :", dvEmployee[j]["EmpCode"].ToString(), this.EmpCodeFontColor);
                    }
                    if (this.ShowEmpDept)
                    {
                        dvDept.RowFilter = "CompElmentID =" + dvEmployee[j]["CompElmentID"].ToString();
                        AddNodeItem(empNode, "", dvDept[0]["CEName"].ToString(), this.EmpDeptFontColor);
                    }
                    if (this.ShowEmpPhoto)
                    {
                        empNode.AddRow();
                        // added by Sayed 21-2-2010      read only
                        //empNode[0, empNode.RowCount - 1].Picture.Height = 143;
                        //empNode[0, empNode.RowCount - 1].Picture.Width = 100;
                        //
                        empNode[0, empNode.RowCount - 1].Picture = getEmpImage(int.Parse(dvEmployee[j]["ContactID"].ToString()));
                        empNode.Rows[empNode.RowCount - 1].Height = rowHeight + 50;
                        empNode.Resize(fc.TableColWidth, rowHeight * GetRowsNumber(1) + 51);
                        empNode.FitSizeToPicture();
                        
                        
                    }
                    
                    
                    if (jobNode != null)
                        fc.CreateArrow(jobNode, empNode);
                    else
                        
                        fc.CreateArrow(deptNode, empNode);

                }
			}
		}
		#endregion
		//-------------------------------------------------------------------------------
		#region Get the department manager and bind it to the the department node directly
		protected void GetDeptManager(Table deptNode, string managerID)
		{
            string filter = "EmployeeStatus = 1 and CompElmentID =" + deptNode.Tag.ToString() + "and ContactID=" + managerID;
			dvEmployee.RowFilter = filter; 
			for( int j=0 ; j<dvEmployee.Count;j++) 
			{
				float rowHeight = this.EmpFont.Size * 3;
				Table empNode = deptNode;//fc.CreateTable(1, 1,fc.TableColWidth, rowHeight * GetRowsNumber(1) + 1);
				empNode.FillColor= this.EmpBackColor;
				empNode.RowHeight = rowHeight;
////////////////////				AddNodeItem(empNode,"",dvEmployee[j]["FirstName"].ToString() + " " + 
////////////////////					dvEmployee[j]["MiddleName"].ToString() + " " + 
////////////////////					dvEmployee[j]["LastName"].ToString(),this.EmpNameFontColor);
//				empNode.Tag = dvEmployee[j]["ContactID"].ToString() ;
//				empNode.Font = this.EmpFont;
				if (this.ShowEmpTitle)
				{
					dvJobs.RowFilter = "jobTitleId = " + dvEmployee[j]["JobTitleID"].ToString() ;
					AddNodeItem(empNode,"",dvJobs[0]["JobName"].ToString(),this.EmpTitleFontColor);
				}
				if(this.ShowEmpCode)
				{
					AddNodeItem(empNode,"Code :",dvEmployee[j]["EmpCode"].ToString(),this.EmpCodeFontColor);
				}
				if (this.ShowEmpDept)
				{
					dvDept.RowFilter = "CompElmentID =" + dvEmployee[j]["CompElmentID"].ToString();
					AddNodeItem(empNode,"",dvDept[0]["CEName"].ToString(),this.EmpDeptFontColor);
				}
				if (this.ShowEmpPhoto)
				{
					empNode.AddRow();
					empNode[0,empNode.RowCount-1].Picture = getEmpImage(int.Parse(dvEmployee[j]["ContactID"].ToString()));
					empNode.Rows[empNode.RowCount-1].Height = rowHeight + 50 ;
                    float mglilh = rowHeight * GetRowsNumber(2) + 150;
					empNode.Resize(fc.TableColWidth , rowHeight * GetRowsNumber(2) + 150); 
					empNode.FitSizeToPicture();
				}
//				if (jobNode != null)
//					fc.CreateArrow(jobNode,empNode);	
//				else
//					fc.CreateArrow(deptNode,empNode);	
			}
		}
		#endregion
		//-------------------------------------------------------------------------------
		#region Get given employee personal photo
		protected Bitmap getEmpImage(int contactID)
		{
			try
			{
                //DataSet dsEmp =  ((Navigation.BaseObject) System.Web.HttpContext.Current.Session[ "navigation" ]).EmployeeWsObject.ListSingleEmployeeData(contactID);
                //string fileID = dsEmp.Tables[0].Rows[0]["FileID"].ToString();
                //byte[] imgBinary  = ((Navigation.BaseObject) System.Web.HttpContext.Current.Session[ "navigation" ]).GeneralWSObject.LoadFileBody(int.Parse(fileID));
                //Stream st = new MemoryStream();
                //st.Write(imgBinary,0,imgBinary.Length);
                //Bitmap img = new Bitmap(st);
                //// commented 17-2-2010
                ////return img;

                //// 17-2-2010
                //System.IO.MemoryStream ms = new System.IO.MemoryStream(imgBinary);
                
                //System.Drawing.Bitmap bmp = ResizeImage(ms, 100, 134);
                //return bmp;
               
                ///////////
                DataSet dsEmp = ((Navigation.BaseObject)System.Web.HttpContext.Current.Session["navigation"]).EmployeeWsObject.ListSingleEmployeeData(contactID);
                string fileID = dsEmp.Tables[0].Rows[0]["FileID"].ToString();
                byte[] imgBinary = ((Navigation.BaseObject)System.Web.HttpContext.Current.Session["navigation"]).GeneralWSObject.LoadFileBody(int.Parse(fileID));
                System.IO.MemoryStream ms = new MemoryStream(imgBinary);
                System.Drawing.Bitmap bmp = ResizeImage(ms, 100, 134);
                //System.IO.MemoryStream stream2 = new System.IO.MemoryStream();

                ////// Save image to stream.
                //bmp.Save(stream2, System.Drawing.Imaging.ImageFormat.Jpeg);

                //imgBinary = stream2.ToArray();
                // bmp = ResizeImage(stream2, 100, 134);
                //Response.OutputStream.Write(imgBinary, 0, imgBinary.Length);
                //Response.OutputStream.Close();
                
                return bmp;
                
				
			}
			catch(Exception ex)
			{
				return null;
			}
		}
		#endregion

        public System.Drawing.Bitmap ResizeImage(System.IO.Stream streamImage, int maxWidth, int maxHeight)
        {
            System.Drawing.Bitmap originalImage = new Bitmap(streamImage);
            int newWidth = originalImage.Width;
            int newHeight = originalImage.Height;
            double aspectRatio = Convert.ToDouble(originalImage.Width) / Convert.ToDouble(originalImage.Height);


            if (aspectRatio <= 1 && originalImage.Width > maxWidth)
            {
                newHeight = maxHeight;
                newWidth = Convert.ToInt32(Math.Round(newHeight * aspectRatio));
            }
            else
                if (aspectRatio > 1 && originalImage.Height > maxHeight)
                {
                    newWidth = maxWidth;
                    newHeight = Convert.ToInt32(Math.Round(newWidth / aspectRatio));

                }

            System.Drawing.Bitmap newImage = new Bitmap(originalImage, newWidth, newHeight);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(newImage);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            g.DrawImage(originalImage, 0, 0, newImage.Width, newImage.Height);
            originalImage.Dispose();

            return newImage;
        } 
		//-------------------------------------------------------------------------------
		#region Add new row to given node
		protected void AddNodeItem(Table node,string preText, string txt, Color clr )
		{
			node.AddRow();
           
			node[0,node.RowCount-1].Text = preText + txt;
			node[0,node.RowCount-1].TextFormat.Alignment = StringAlignment.Center;
			node[0,node.RowCount-1].TextColor = clr;
		}
		#endregion
		//-------------------------------------------------------------------------------
		#region Set the layout of the given chart
		/// <summary>
		/// Set up the layout type, direction and arrow type for the given flow chart
		/// </summary>
		/// <param name="fc"></param>
		protected void SetChartLayout(FlowChart fc)
		{
			TreeLayout tl = new TreeLayout();
			tl.Type = this.TreeLayout; 
			tl.Direction = this.TreeDirection;
			tl.ArrowStyle = this.ArrowType;
			tl.LevelDistance = GetRowsNumber(1) * this.EmpFont.Size * 3 + 30;
			tl.Arrange(fc);
			fc.FitDocToObjects(10);
			fc.DocExtents = RectangleF.FromLTRB(0, 0,
				fc.DocExtents.Right, fc.DocExtents.Bottom);
            
		}
		#endregion
		//------------------------------------------------------------------------------
		#region Get department manager name for the given department
		/// <summary>
		/// Returns the name of the employee having the given ID
		/// </summary>
		/// <param name="ContactID">Department manager ID</param>
		/// <returns>Department manager name, or it returns "" if no department manager is available</returns>
		protected string GetDeptManager(string ContactID)
		{
			try
			{
				DataSet dsEmp = ((Navigation.BaseObject) System.Web.HttpContext.Current.Session[ "navigation" ]).EmployeeWsObject.ListSingleEmployeeData(int.Parse(ContactID));
				return dsEmp.Tables[0].Rows[0]["FirstName"].ToString() + " " + dsEmp.Tables[0].Rows[0]["MiddleName"].ToString()
					+ " " + dsEmp.Tables[0].Rows[0]["LastName"].ToString();
			}
			catch (Exception ex)
			{
				return "";
			}
		
		}

		#endregion
		//------------------------------------------------------------------------------
        //------------------------------------------------------------------------------
        #region Get department manager job title for the given department
        /// <summary>
        /// Returns the name of the employee having the given ID
        /// </summary>
        /// <param name="ContactID">Department manager ID</param>
        /// <returns>Department manager name, or it returns "" if no department manager is available</returns>
        protected string GetManagerTitle(string ContactID)
        {
            try
            {
                DataSet dsEmp = ((Navigation.BaseObject)System.Web.HttpContext.Current.Session["navigation"]).EmployeeWsObject.ListSingleEmployeeData(int.Parse(ContactID));
                
                dvJobs.RowFilter = "jobTitleId = " + dsEmp.Tables[0].Rows[0]["JobTitleID"].ToString()  ;
                return dvJobs[0]["JobName"].ToString();
            }
            catch (Exception ex)
            {
                return "None";
            }

        }

        #endregion
        //------------------------------------------------------------------------------
        # region create a table from dataview
        /// <summary>
        /// Convert given dataview to datatable
        /// </summary>
        /// <param name="obDataView"></param>
        /// <returns></returns>
        public static DataTable CreateTable(DataView obDataView)
        {
            if (null == obDataView)
            {
                throw new ArgumentNullException
                    ("DataView", "Invalid DataView object specified");
            }



            ///********* End of Enhance Performance by SM ****************///
            //						DataTable obNewDt = obDataView.Table;

            ///********* End of Enhance Performance by SM ****************///



            ///********* Old Code ****************///
            DataTable obNewDt = obDataView.Table.Clone();
            int idx = 0;
            string[] strColNames = new string[obNewDt.Columns.Count];
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
            ///*************** End of Old Code **************************//

            return obNewDt;
        }
        #endregion
	}
}
