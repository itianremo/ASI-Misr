using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace TSN.ERP.WebGUI.SecurityManagement
{
	/// <summary>
	/// Summary description for frmFindRuleGroup.
	/// </summary>
	public partial class frmFindRuleGroup : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button cbCancel;
		protected TSN.ERP.WebGUI.Data.DataSetRuleGroup dataSetRuleGroup1;
		protected System.Data.DataView dvRoles;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				
				Navigation.BaseObject.SafeMerge(dataSetRuleGroup1,((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.GetAllRuleGroups());
				Session["RuleGroups"] = dataSetRuleGroup1;
				dgRoles.DataBind();
			}
			dataSetRuleGroup1 = (TSN.ERP.WebGUI.Data.DataSetRuleGroup)Session["RuleGroups"];
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.dataSetRuleGroup1 = new TSN.ERP.WebGUI.Data.DataSetRuleGroup();
			this.dvRoles = new System.Data.DataView();
			((System.ComponentModel.ISupportInitialize)(this.dataSetRuleGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvRoles)).BeginInit();
			this.dgRoles.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgRoles_PageIndexChanged);
			// 
			// dataSetRuleGroup1
			// 
			this.dataSetRuleGroup1.DataSetName = "DataSetRuleGroup";
			this.dataSetRuleGroup1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvRoles
			// 
			this.dvRoles.Sort = "RuleGroupName";
			this.dvRoles.Table = this.dataSetRuleGroup1.SEC_RuleGroup;
			((System.ComponentModel.ISupportInitialize)(this.dataSetRuleGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvRoles)).EndInit();

		}
		#endregion

		
		#region Multi datagrid Roles CheckBoxes Selector

		protected void chkRolesHeader_CheckedChanged(object a, System.EventArgs b)
		{
			CheckBox chk1=(CheckBox)a;
			if(chk1.Checked)
			{
				foreach(DataGridItem item in dgRoles.Items)
				{
					if(item.ItemType==ListItemType.Item||item.ItemType==ListItemType.AlternatingItem)
					{
						CheckBox cbxSelect=(CheckBox)item.FindControl("cbxSelect");
						cbxSelect.Checked=true;
					}
				}
			}
			else
			{
				foreach(DataGridItem item in dgRoles.Items)
				{
					if(item.ItemType==ListItemType.Item||item.ItemType==ListItemType.AlternatingItem)
					{
						CheckBox cbxSelect=(CheckBox)item.FindControl("cbxSelect");
						cbxSelect.Checked=false;
					}
				}
			}
		}
		#endregion
		
		
		
		private void dgRoles_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			try
			{
				dgRoles.CurrentPageIndex = e.NewPageIndex;
				dataSetRuleGroup1 = (TSN.ERP.WebGUI.Data.DataSetRuleGroup)Session["RuleGroups"];
				dvRoles.Table = dataSetRuleGroup1.SEC_RuleGroup;
                string Filter = "RuleGroupName LIKE  '%" + tbFilter.Text + "%'";
                dvRoles.RowFilter = Filter;
				dgRoles.DataBind();
			}
			catch(Exception ex)
			{
				Response.Write(ex.Message);
			}
		}

		protected void cbFind_Click(object sender, System.EventArgs e)
		{
			try
			{
				dataSetRuleGroup1 = (TSN.ERP.WebGUI.Data.DataSetRuleGroup)Session["RuleGroups"];
				dvRoles.Table = dataSetRuleGroup1.SEC_RuleGroup;
				string Filter = "RuleGroupName LIKE  '%" + tbFilter.Text+ "%'" ;
				dvRoles.RowFilter = Filter;
				if(dvRoles.Count > 0)
				{
					Label1.Visible = false;
					dgRoles.Visible = true;
					Button1.Visible = true;
					cbAdd.Visible = true;
                    dgRoles.CurrentPageIndex = 0;
					dgRoles.DataBind();
					Session["RuleGroups"] = dataSetRuleGroup1;
				}
				else
				{
					Label1.Visible = true;
					dgRoles.Visible = false;
					Button1.Visible = false;
					cbAdd.Visible = false;

				}

			}
			catch (Exception ex)
			{
				Response.Write(ex.Message);
			}
		}

	
		protected void lbShowAll_Click(object sender, System.EventArgs e)
		{
			dataSetRuleGroup1 = (TSN.ERP.WebGUI.Data.DataSetRuleGroup)Session["RuleGroups"];
			dvRoles.Table = dataSetRuleGroup1.SEC_RuleGroup;
			dvRoles.RowFilter = "";
			dgRoles.DataBind();
			Label1.Visible = false;
			if(dgRoles.Items.Count > 0)
			{
				dgRoles.Visible = true;
			}
			else
			{
				dgRoles.Visible = false;
			}
			Session["RuleGroups"] = dataSetRuleGroup1;
		}



		protected int GroupID
		{
			get
			{
				return int.Parse(Request.QueryString["GroupID"]);
			}
		}
		protected void cbAdd_Click(object sender, System.EventArgs e)
		{
			int counter = 0 ;
			int usrGrpID = Convert.ToInt32( Session["userGroupID"] ) ;

			dataSetRuleGroup1 = (TSN.ERP.WebGUI.Data.DataSetRuleGroup)Session["RuleGroups"];
			foreach (DataGridItem dgiTemp in dgRoles.Items)
			{
				object temp  = dgiTemp.FindControl("cbxSelect");
				if (temp==null)continue;
				CheckBox cbxSelector = (CheckBox) temp;
				if (!cbxSelector.Checked)continue;
				int rlGrpID = Convert.ToInt32( dgiTemp.Cells[ 2 ].Text ); 
				((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.AddRuleGroupToUserGroup( usrGrpID , rlGrpID );
				cbxSelector.Checked = false;
				counter++;
			}
			DataGridItem item = (DataGridItem)dgRoles.Controls[0].Controls[1];
			CheckBox ChkRolesHdr = (CheckBox)item.FindControl("ChkRolesHdr");
			ChkRolesHdr.Checked = false;	
		    Session["Action"] = "1";

			if( counter == 0 )
//				Navigation.BaseObject.showMessage( "Please select role to add" , this.Page );	
				this.RegisterStartupScript("Notfound","<script language=javascript>alert('Please select role to add!')</script>");
		}
	}
}
