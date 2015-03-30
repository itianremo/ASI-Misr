using System;

namespace TSN.ERP.WebGUI.Go
{
	/// <summary>
	/// Before Creating, modifying or scoring any task, you should firstly make an appropriate instance of this class 
	/// and save it in the session variable Session["task"].
	/// </summary>
	public class CTask
	{
		private int m_Mode;
		private int m_ProjectID;
		private string m_ProjectName;
		private int m_EmpID;
		private string m_EmpName;
		private int m_RespID;
		private string m_RespName;
		private int m_TaskID;
		private int m_AssignmentID;
		//-----------------------------------------------------------
		#region used in case of creating a project task
		/// <summary>
		/// used in case of creating a project task
		/// </summary>
		/// <param name="projectID">Project ID</param>
		/// <param name="projectName">Project name</param>
		public CTask(int projectID, string projectName)
		{
			this.m_Mode = 1;
			this.m_ProjectID = projectID;
			this.m_ProjectName = projectName;
		}
		#endregion
		//-----------------------------------------------------------
		#region used in case of creating an employee's task
		/// <summary>
		/// used in case of creating an employee's task
		/// </summary>
		/// <param name="empID">Employee ID</param>
		/// <param name="empName">Employee name</param>
		/// <param name="respID">responsibility ID</param>
		/// <param name="respName">responsibility name</param>
		public CTask(int empID, string empName
			,int respID,string respName)
		{
			this.m_Mode = 2;
			this.m_EmpID = empID;
			this.m_EmpName = empName;
			
			this.m_RespID = respID; 
			this.m_RespName = respName;
		}
		#endregion
		//-----------------------------------------------------------
		#region used in case of editing project task
		/// <summary>
		/// used in case of editing project task
		/// </summary>
		/// <param name="projectID">Project ID</param>
		/// <param name="projectName">Project name</param>
		/// <param name="taskID">Task ID</param>
		public CTask(int projectID, string projectName,int taskID)
		{
			this.m_Mode = 3;
			this.m_ProjectID = projectID;
			this.m_ProjectName = projectName;
			this.m_TaskID = taskID;
		}
		#endregion
		//-----------------------------------------------------------
		#region used in case of editing or scoring employee's task
		/// <summary>
		/// used in case of editing employee's task
		/// </summary>
		/// <param name="empID">Employee ID</param>
		/// <param name="empName">Employee name</param>
		/// <param name="respID">Responsibility ID</param>
		/// <param name="respName">Responsibility name</param>
		/// <param name="taskID">Task ID</param>
		/// <param name="assignmentID">Assignment ID</param>
		/// <param name="flag">Denotes whether the form is used in editing (true) or scoring</param>
		public CTask(int empID, string empName
			,string respName,string projectName,int taskID,int assignmentID,bool flag)
		{
			if (flag == true)
				this.m_Mode = 4;
			else
				this.m_Mode = 5;
			this.m_EmpID = empID;
			this.m_EmpName = empName;
			this.m_RespID = respID;
			this.m_RespName = respName;
			this.m_TaskID =taskID;
			this.m_AssignmentID = assignmentID;
			this.m_ProjectName = projectName;
		}
		#endregion
		//-----------------------------------------------------------	
		///<summary>
		///Denotes the purpose of creating this object
		///<li>1 --- Create a new project task</li>
		///<li>2 --- Creating a new employee assignment</li>
		///<li>3 --- Editing existing project task</li>
		///<li>4 --- Editing existing employee's assignment</li>
		///<li>5 --- Scoring an employee's assignment</li>
		///</summary>
		public int mode 
		{
			get { return m_Mode;}
		}
		//----------------------------------------------------------
		/// <summary>
		/// Project ID
		/// </summary>
		public int projectID 
		{
			get { return m_ProjectID;}
		}
		//----------------------------------------------------------
		/// <summary>
		/// Project Name
		/// </summary>
		public string projectName 
		{
			get { return m_ProjectName;}
		}
		//----------------------------------------------------------
		/// <summary>
		/// Employee ID
		/// </summary>
		public int empID
		{
			get { return m_EmpID;}
		}
		//----------------------------------------------------------
		/// <summary>
		/// Employee Name
		/// </summary>
		public string empName 
		{
			get { return m_EmpName;}
		}
		//----------------------------------------------------------
		/// <summary>
		/// Responsibility ID
		/// </summary>
		public int respID 
		{
			get { return m_RespID;}
		}
		//----------------------------------------------------------
		/// <summary>
		/// Responsibility name
		/// </summary>
		public string respName 
		{
			get { return m_RespName;}
		}
		//----------------------------------------------------------
		/// <summary>
		/// Task ID
		/// </summary>
		public int taskID 
		{
			get { return m_TaskID;}
		}
		//----------------------------------------------------------
		/// <summary>
		/// Assignment ID
		/// </summary>
		public int assignmentID 
		{
			get { return m_AssignmentID;}
		}
		//----------------------------------------------------------
	}
}
