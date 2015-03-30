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

namespace TSN.ERP.WebGUI.Go
{
	/// <summary>
	/// Summary description for frmFindRuleGroup.
	/// </summary>
	public partial class frmFindEmail : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button cbCancel;
		protected System.Web.UI.HtmlControls.HtmlInputButton Button1;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				try
				{
					DataSet dsContactsAndEmails = new DataSet();
					string mailingType = System.Configuration.ConfigurationSettings.AppSettings["MailingType"];
					if(mailingType == "0")//Internal
					{
						Navigation.BaseObject.SafeMerge(dsContactsAndEmails,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListCotactsAndEmails(0));
					}
					else if(mailingType == "1")//External
					{
						Navigation.BaseObject.SafeMerge(dsContactsAndEmails,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListCotactsAndEmails(1));
					}
					else if(mailingType == "2")//Private
					{
						Navigation.BaseObject.SafeMerge(dsContactsAndEmails,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListCotactsAndEmails(2));
					}										
					else if(mailingType == "-1")//Get All mails
					{
						Navigation.BaseObject.SafeMerge(dsContactsAndEmails,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListCotactsAndEmails(-1));
					}										
					Session["dsContactsAndEmails"] = dsContactsAndEmails;
					dgEmails.DataSource=dsContactsAndEmails;
					dgEmails.DataBind();				
				}
				catch(Exception ex)
				{
					Response.Write(ex.Message);
				}
			}
			string mailButton = Request.QueryString.Get("mailButton");
			//				string txtTo = Request.QueryString.Get("txtTo");
			//				string txtCC = Request.QueryString.Get("txtCC");
			//				string txtBCC = Request.QueryString.Get("txtBCC");
			string Script = "mailButton='"+mailButton+"';";
			//				Script += "txtTo='"+txtTo+"';";
			//				Script += "txtCC='"+txtCC+"';";
			//				Script += "txtBCC='"+txtBCC+"';";
			this.RegisterStartupScript("fff", "<script>"+Script+"</script>");
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
			this.dgEmails.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgEmails_PageIndexChanged);

		}
		#endregion
		
		
		private void dgEmails_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			try
			{
				dgEmails.CurrentPageIndex = e.NewPageIndex;
				DataSet dsContactsAndEmails = new DataSet();
				dsContactsAndEmails = (DataSet)Session["dsContactsAndEmails"];
				dgEmails.DataSource=dsContactsAndEmails;
				dgEmails.DataBind();
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
				DataSet dsContactsAndEmails  = (DataSet)Session["dsContactsAndEmails"];
				DataSet dsContactsAndEmailsCopy = new DataSet();
				DataRow[] drColl = dsContactsAndEmails.Tables[0].Select("ContactEmail LIKE  '%" + tbFilter.Text+ "%'");
				DataTable dt= dsContactsAndEmails.Tables[0].Clone();
				dsContactsAndEmailsCopy.Tables.Add(dt);
				foreach(DataRow dr in drColl)
				{					
					dsContactsAndEmailsCopy.Tables[0].ImportRow(dr);
				}				

				if(dsContactsAndEmailsCopy.Tables[0].Rows.Count > 0)
				{
					Label1.Visible = false;
					dgEmails.Visible = true;
					//Button1.Visible = true;
//					cbAdd.Visible = true;
					dgEmails.DataSource=dsContactsAndEmailsCopy;
					dgEmails.DataBind();
				}
				else
				{
					Label1.Visible = true;
					dgEmails.Visible = false;
					//Button1.Visible = false;
//					cbAdd.Visible = false;

				}

			}
			catch (Exception ex)
			{
				Response.Write(ex.Message);
			}
		}

	
		protected void lbShowAll_Click(object sender, System.EventArgs e)
		{
			DataSet dsContactsAndEmails = (DataSet)Session["dsContactsAndEmails"];
			dgEmails.DataSource=dsContactsAndEmails;
			dgEmails.DataBind();
			Label1.Visible = false;
			if(dgEmails.Items.Count > 0)
			{
				dgEmails.Visible = true;
			}
			else
			{
				dgEmails.Visible = false;
			}
		}



		protected void cbAdd_Click(object sender, System.EventArgs e)
		{
			string strEmail=String.Empty;
			int idx=0;
			foreach (DataGridItem dgiTemp in dgEmails.Items)
			{
				object temp  = dgiTemp.FindControl("cbxSelect");
				if (temp==null)continue;
				CheckBox cbxSelector = (CheckBox) temp;
				if (!cbxSelector.Checked)continue;
				idx++;
				strEmail += dgiTemp.Cells[ 1 ].Text.Trim(); 
				if(idx > 0)
					strEmail+=";";
			}
			if(idx == 0)
			{
				this.RegisterStartupScript("fdss","<script>alert('You must select at least one email address to add it');</script>");
			}
			if(strEmail.EndsWith(";"))
				strEmail = strEmail.Remove(strEmail.Length-1,1);
			string mailButton = Request.QueryString.Get("mailButton");
			this.RegisterStartupScript("fds","<script>saveEmails2('"+strEmail+"','"+mailButton+"');</script>");

		}

	}
}
