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
using System.Text.RegularExpressions;

namespace TSN.ERP.WebGUI.Go
{
	/// <summary>
	/// Summary description for frmEmpPhone.
	/// </summary>
	public partial class frmEmpEmail : System.Web.UI.Page
	{
		protected TSN.ERP.SharedComponents.Data.dsEmail dsEmail1;
		
		private static int contactID;

		#region page load
		protected void Page_Load(object sender, System.EventArgs e)
		{
			contactID = int.Parse(Session["contactID"].ToString());
			if(!IsPostBack)
			{
				lblCode.Text = Session["code"].ToString();
				lblName.Text = Session["name"].ToString();
				BindEmails();
			}
		}
#endregion
		//------------------------------------------------------------
		#region bind phones to the grid
		public void BindEmails()
		{
			dsEmail1.Clear();
			Navigation.BaseObject.SafeMerge(dsEmail1,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListAllCotactEmails(contactID));
			grdEmails.DataBind();
		}
		#endregion
		//------------------------------------------------------------
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
			this.dsEmail1 = new TSN.ERP.SharedComponents.Data.dsEmail();
			((System.ComponentModel.ISupportInitialize)(this.dsEmail1)).BeginInit();
			this.grdEmails.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grdEmails_ItemDataBound);
			// 
			// dsEmail1
			// 
			this.dsEmail1.DataSetName = "dsEmail";
			this.dsEmail1.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.dsEmail1)).EndInit();

		}
		#endregion
		//------------------------------------------------------------
		//------------------------------------------------------------
		#region add new wmail
		public bool CheckEmailForAdd(TSN.ERP.SharedComponents.Data.dsEmail ds,string Email,int ContactID)
		{
			bool flag = true ;
			foreach(DataRow dr in ds.Tables["GEN_Emails"].Rows)
			{
				//Check if the Email address is repeated
				flag = true;
				if(dr["ContactEmail"].ToString().ToLower().Trim()== Email.ToLower() && int.Parse(dr["ContactID"].ToString().Trim())==ContactID)
				{
					flag = false;
					break;
				}				
				else
				{
					flag = true;
				}
			}
			return flag;
		}

		private bool CheckMail(TSN.ERP.SharedComponents.Data.dsEmail ds)
		{
			foreach(DataRow dr in ds.GEN_Emails.Rows)
			{
				if(ddlEmailType.SelectedValue == "0")
				{
					if(dr["EmailType"].ToString() == ddlEmailType.SelectedValue)
					{
						lblMSG.Text = "You can add only one internal mail";
						return false;
					}
				}
				else if(ddlEmailType.SelectedValue == "1")
				{
					if(dr["EmailType"].ToString() == ddlEmailType.SelectedValue)
					{
						lblMSG.Text = "You can add only one external mail";
						return false;
					}
				}			
			}
			return true;
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			if(Page.IsValid)
			{			
				try
				{
					string strEmail = txtEmail.Text;
					//\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)* 
					if(!IsValidEmail(strEmail))
					{
						lblMSG.Text = "Invalid email address";
						return;
					}
					dsEmail1.Clear();
					Navigation.BaseObject.SafeMerge(dsEmail1, ((Navigation.BaseObject)Session["navigation"]).ContactWsObject.ListAllCotactEmails(contactID));
					dsEmail1.EnforceConstraints = false;
					if(!CheckMail(dsEmail1))
					{
						return;
					}
					bool Flage = CheckEmailForAdd(dsEmail1,txtEmail.Text.Trim(),contactID);
					if(Flage)
					{
						//						// add the new email
						//						dsEmail1.Clear();
						//						Navigation.BaseObject.SafeMerge(dsEmail1, ((Navigation.BaseObject)Session["navigation"]).ContactWsObject.ListAllCotactEmails(contactID));

						ERP.SharedComponents.Data.dsEmail.GEN_EmailsRow row = dsEmail1.GEN_Emails.NewGEN_EmailsRow();
						row.ContactID = contactID;
						row.ContactEmail = txtEmail.Text;
						row.EmailType = Convert.ToInt32(ddlEmailType.SelectedValue);						
						dsEmail1.GEN_Emails.AddGEN_EmailsRow(row);
						int xx = ((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.UpdateEmail(dsEmail1);	
						BindEmails();
						lblMSG.Text = "Email added Successfully";
					}
					else
					{
						lblMSG.Text = "This email added so far , please try another one";
					}
				}
				catch(Exception ex)
				{
					Response.Write(ex.Message);
					//TODO : Handling Exception
				}
			}
		}
		#endregion
		//------------------------------------------------------------
		#region delete phone
		public void OnDelete(object sender,DataGridCommandEventArgs e)
		{
			try
			{
				int EmailID = int.Parse(e.Item.Cells[0].Text); 
				dsEmail1.Clear();
				Navigation.BaseObject.SafeMerge(dsEmail1,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListAllCotactEmails(contactID));
				ERP.SharedComponents.Data.dsEmail.GEN_EmailsRow row 
					=  dsEmail1.GEN_Emails.FindByEmailID(EmailID);
				row.Delete();
				((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.UpdateEmail(dsEmail1);
				BindEmails();
				lblMSG.Text = "";
			}
			catch(Exception ex)
			{
				Response.Write(ex.Message);
				//TODO
			}
		}
#endregion

		//------------------------------------------------------------		
		private void grdEmails_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Item||e.Item.ItemType==ListItemType.AlternatingItem)
			{
			
				if (e.Item.Cells[3].Text =="0")
				{
					e.Item.Cells[2].Text = "Internal";
				}
				else if (e.Item.Cells[3].Text =="1")
				{
					e.Item.Cells[2].Text = "External";
				}
				else					
				{
					e.Item.Cells[2].Text = "Private";
				}
			}
		}

	
		//------------------------------------------------------------		

		public bool IsValidEmail(string email)
		{
			//regular expression pattern for valid email
			//addresses, allows for the following domains:
			//com,edu,info,gov,int,mil,net,org,biz,name,museum,coop,aero,pro,tv
//			string pattern = @"^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$";
			string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)* ";
			//Regular expression object
			Regex check = new Regex(pattern,RegexOptions.IgnorePatternWhitespace);
			//boolean variable to return to calling method
			bool valid = false;
 
			//make sure an email address was provided
			if (email == "" || email == null)
			{
				valid = false;
			}
			else
			{
				//use IsMatch to validate the address
				valid = check.IsMatch(email);
			}
			//return the value to the calling method
			return valid;
		} 

	}
}
