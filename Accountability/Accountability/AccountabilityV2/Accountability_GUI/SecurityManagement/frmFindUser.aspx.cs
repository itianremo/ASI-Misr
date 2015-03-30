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
	public partial class frmFindUser : System.Web.UI.Page
	{
		protected TSN.ERP.WebGUI.Data.UsrDS usrDS1;
		protected System.Data.DataView dvUsers;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				Navigation.BaseObject.SafeMerge(usrDS1,((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.GetAllUsers());
				Session["RuleGroups"] = usrDS1;
				dgRoles.DataBind();
			}
			usrDS1 = (TSN.ERP.WebGUI.Data.UsrDS)Session["RuleGroups"];
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
			this.usrDS1 = new TSN.ERP.WebGUI.Data.UsrDS();
			this.dvUsers = new System.Data.DataView();
			((System.ComponentModel.ISupportInitialize)(this.usrDS1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvUsers)).BeginInit();
			// 
			// usrDS1
			// 
			this.usrDS1.DataSetName = "UsrDS";
			this.usrDS1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dvUsers
			// 
			this.dvUsers.Sort = "UserName";
			this.dvUsers.Table = this.usrDS1.SEC_Users;
			this.dgRoles.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgRoles_PageIndexChanged);
			((System.ComponentModel.ISupportInitialize)(this.usrDS1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvUsers)).EndInit();

		}
		#endregion

		#region Multi datagrid users CheckBoxes Selector

		protected void chkUsersHeader_CheckedChanged(object a, System.EventArgs b)
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
				if (dgRoles.SelectedIndex != -1)
				{
					dgRoles.SelectedIndex = -1;
				}
				usrDS1 = (TSN.ERP.WebGUI.Data.UsrDS)Session["RuleGroups"];
				dvUsers.Table = usrDS1.SEC_Users;
                string Filter = "UserName LIKE  '%" + tbFilter.Text + "%'";
                dvUsers.RowFilter = Filter;
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
				usrDS1 = (TSN.ERP.WebGUI.Data.UsrDS)Session["RuleGroups"];
				dvUsers.Table = usrDS1.SEC_Users;
				string Filter = "UserName LIKE  '%" + tbFilter.Text+ "%'" ;
				dvUsers.RowFilter = Filter;

				dgRoles.CurrentPageIndex = 0;
				dgRoles.DataBind();
				Session["RuleGroups"] = usrDS1;
				dgRoles.CurrentPageIndex = 0;

				if(dgRoles.Items.Count > 0)
				{
					Label1.Visible = false;
					cbAdd.Visible = true;
					dgRoles.Visible = true;
				}
				else
				{
					Label1.Visible = true;
					cbAdd.Visible = false;
					dgRoles.Visible = false;
				}
			}
			catch (Exception ex)
			{
				Response.Write(ex.Message);
			}
		}

	
		protected void lbShowAll_Click(object sender, System.EventArgs e)
		{
			usrDS1 = (TSN.ERP.WebGUI.Data.UsrDS)Session["RuleGroups"];
			dvUsers.Table = usrDS1.SEC_Users;
			dvUsers.RowFilter = "";
			dgRoles.DataBind();
			Session["RuleGroups"] = usrDS1;
			dgRoles.CurrentPageIndex = 0;

			Label1.Visible = false;
			cbAdd.Visible = true;
			dgRoles.Visible = true;
		}

		protected int GroupID
		{
			get
			{
				//return 1588;
				return int.Parse(Request.QueryString["GroupID"]);
			}
		}
		protected void cbAdd_Click(object sender, System.EventArgs e)
		{
			int usrGrpID = Convert.ToInt32( Session["userGroupID"] ) ;
			int counter =0;
			usrDS1 = (TSN.ERP.WebGUI.Data.UsrDS)Session["RuleGroups"];
			foreach (DataGridItem dgiTemp in dgRoles.Items)
			{
				object temp  = dgiTemp.FindControl("cbxSelect");
				if (temp==null)continue;
				CheckBox cbxSelector = (CheckBox) temp;
				if (!cbxSelector.Checked)continue;
				((Navigation.BaseObject) Session[ "navigation" ]).SecurityWsObject.AddUserToGroup( usrGrpID ,Convert.ToInt32(dgiTemp.Cells[2].Text));
				cbxSelector.Checked = false;
				counter++;
		  	}
			DataGridItem item = (DataGridItem)dgRoles.Controls[0].Controls[1];
			CheckBox ChkUserHdr = (CheckBox)item.FindControl("ChkUserHdr");
			ChkUserHdr.Checked = false;	
			Session["Action"] = "1";
			if( counter == 0 )
				//Navigation.BaseObject.showMessage( "Please select user name to add" , this.Page );	
				this.RegisterStartupScript("Notfound","<script language=javascript>alert('Please select user name to add!')</script>");

		}
	}
}
