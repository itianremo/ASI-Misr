using System;
using TSN.ERP.WebGUI.Navigation;

namespace TSN.ERP.WebGUI.Navigation
{
	/// <summary>
	/// Summary description for SecButtons.
	/// </summary>
	public class SecButtons : System.Web.UI.WebControls.Button
	{
		int ruleID = 0 ;
		public SecButtons()
		{

		}

		public int RuleID
		{
			get
			{
				return ruleID;
				
			}
			set
			{
				ruleID = value;
			}
		}


		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			if (  ((Navigation.BaseObject)Page.Session[ "navigation" ]).SecInfo.IsAdministrator )
			{
				if ( Visible )
				 Visible = true;
				return;
				
			}

			if ( ruleID != 0 )
			{
				for( int i = 0 ; i < ((Navigation.BaseObject) Page.Session[ "navigation" ]).SecInfo.RulesArray.Count ; i++ )
				{
					int[] elm = new int[2];
					elm = (int[]) ((Navigation.BaseObject) Page.Session[ "navigation" ]).SecInfo.RulesArray[ i ];
					if( elm[ 0 ] == ruleID )
					{
						if ( elm[ 1 ] == -1 )
						{
							if ( Visible )
								Visible = true;
							return;
							
						}
						else if( elm[ 1 ] == ((Navigation.BaseObject)Page.Session[ "navigation" ]).EntityID )
						{
							if ( Visible )
								Visible = true;
							return;
							
						}

					}
				}
				Visible = false;
			}

		}

	}
}
