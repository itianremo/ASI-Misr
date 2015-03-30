using System;
using System.Collections;

namespace TSN.ERP.WebGUI.Navigation
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class SecurityInfo
	{
		bool admin = false;
		ArrayList rulesArray;

		public SecurityInfo()
		{
			rulesArray	= new ArrayList();
		}

		public bool IsAdministrator
		{
			get
			{
				return admin;
				
			}
			set
			{
				admin = value;
			}
		}


		public ArrayList RulesArray
		{
			get
			{
				return rulesArray;
				
			}
			set
			{
				rulesArray = value;
			}
		}

	}
}
