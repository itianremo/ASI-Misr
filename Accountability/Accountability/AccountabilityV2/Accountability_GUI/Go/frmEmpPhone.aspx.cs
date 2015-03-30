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
	/// Summary description for frmEmpPhone.
	/// </summary>
	public partial class frmEmpPhone : System.Web.UI.Page
	{
		protected TSN.ERP.SharedComponents.Data.dsPhonebook dsPhonebook;
		
		private static int contactID;

		#region page load
		protected void Page_Load(object sender, System.EventArgs e)
		{
			contactID = int.Parse(Session["contactID"].ToString());
			if(!IsPostBack)
			{				
				lblCode.Text = Session["code"].ToString();
				lblName.Text = Session["name"].ToString();
				BindPhones();	
			}
		}
#endregion
		//------------------------------------------------------------
		#region bind phones to the grid
		public void BindPhones()
		{
			dsPhonebook.Clear();
			Navigation.BaseObject.SafeMerge(dsPhonebook,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListContactPhones(contactID));
			grdPhones.DataBind();
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
			this.dsPhonebook = new TSN.ERP.SharedComponents.Data.dsPhonebook();
			((System.ComponentModel.ISupportInitialize)(this.dsPhonebook)).BeginInit();
			this.grdPhones.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grdPhones_ItemDataBound);
			// 
			// dsPhonebook
			// 
			this.dsPhonebook.DataSetName = "dsPhonebook";
			this.dsPhonebook.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.dsPhonebook)).EndInit();

		}
		#endregion
		//------------------------------------------------------------
		#region fired during grid databind
		private void grdPhones_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			try
			{
				if(e.Item.ItemType==ListItemType.Item||e.Item.ItemType==ListItemType.AlternatingItem)
				{
					#region determinign phone type
					switch(e.Item.Cells[6].Text)
					{
						case "0":
							e.Item.Cells[6].Text = "Business";
							break;
						case "1":
							e.Item.Cells[6].Text= "Business Fax";
							break;
						case "2":
							e.Item.Cells[6].Text = "Car";
							break;
						case "3":
							e.Item.Cells[6].Text = "Company";
							break;
						case "4":
							e.Item.Cells[6].Text = "Home";
							break;
						case "5":
							e.Item.Cells[6].Text = "Home Fax";
							break;
						case "6":
							e.Item.Cells[6].Text = "Mobile";
							break;
						default :
							e.Item.Cells[6].Text = "Other";
							break;
					}
					#endregion
					System.Web.UI.WebControls.Image img = 
						(System.Web.UI.WebControls.Image)e.Item.FindControl("imgPrimary");
					if (e.Item.Cells[9].Text =="True")
					{
						img.ImageUrl = "images/checked.jpg";
					}
					else
					{
						img.Visible = false;
					}
				}
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
			}
		}
		#endregion
		//------------------------------------------------------------
		#region add new phone
		public bool CheckAPhoneForAdd(TSN.ERP.SharedComponents.Data.dsPhonebook ds,string Phone,int ContactID)
		{
			bool flag = true ;
			foreach(DataRow dr in ds.Tables["GEN_Phonebook"].Rows)
			{
				flag = true;
				if(dr["PhoneNumber"].ToString().ToLower().Trim()== Phone.ToLower() && int.Parse(dr["ContactID"].ToString().Trim())==ContactID)
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

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			if(Page.IsValid)
			{
				#region Validate Area, Zone, Country and Number
				//Area Validation
				try
				{
					if(txtArea.Text.Length < 2 || txtArea.Text.Length > 3 || int.Parse(txtArea.Text) > 999)
					{
						lblMSG.Visible=true;
						lblMSG.Text = "Enter 2-3 digits only for area";
						return;
					}
				}
				catch
				{
					lblMSG.Visible=true;
					lblMSG.Text = "Enter 2-3 digits only for area";
					return;
				}
				//Country Validation
				try
				{
					if(txtCountry.Text.Length < 2 || txtCountry.Text.Length > 3 || int.Parse(txtCountry.Text) > 999)
					{
						lblMSG.Visible=true;
						lblMSG.Text = "Enter 2-3 digits only for country";
						return;
					}
				}
				catch
				{
					lblMSG.Visible=true;
					lblMSG.Text = "Enter 2-3 digits only for country";
					return;
				}
				//Zone Validation
				try
				{
					if(txtZone.Text.Length < 2 || txtZone.Text.Length > 3 || int.Parse(txtZone.Text) > 999)
					{
						lblMSG.Visible=true;
						lblMSG.Text = "Enter 2-3 digits only for zone";
						return;
					}
				}
				catch
				{
					lblMSG.Visible=true;
					lblMSG.Text = "Enter 2-3 digits only for zone";
					return;
				}
				//Number Validation
				try
				{
					if(txtNumber.Text.Length < 5 || txtNumber.Text.Length > 7 || int.Parse(txtNumber.Text) > 9999999)
					{
						lblMSG.Visible=true;
						lblMSG.Text = "Enter 5-7 digits only for number";
						return;
					}
				}
				catch
				{
					lblMSG.Visible=true;
					lblMSG.Text = "Enter 5-7 digits only for number";
					return;
				}
				#endregion
			
				try
				{
					dsPhonebook.Clear();
					Navigation.BaseObject.SafeMerge(dsPhonebook, ((Navigation.BaseObject)Session["navigation"]).ContactWsObject.ListContactPhones(contactID));
					dsPhonebook.EnforceConstraints = false;          					
					bool Flage = CheckAPhoneForAdd(dsPhonebook,txtNumber.Text.Trim(),contactID);
					if(Flage)
					{
						// add the new phone
						

						if (chkPrimary.Checked)
						{
							for (int i = 0; i < dsPhonebook.Tables[0].Rows.Count; i++)
							{
								//								row = (ERP.SharedComponents.Data.dsPhonebook.GEN_PhonebookRow)
								//									dsPhonebook.Tables[0].Rows[i];
								//								row.PrimaryPhoneBook = false;
								dsPhonebook.GEN_Phonebook.Rows[i]["PrimaryPhoneBook"] = false;
							}
							int x = ((Navigation.BaseObject)Session["navigation"]).ContactWsObject.UpdatePhoneBook(dsPhonebook);
							//dsPhonebook.AcceptChanges();
						}

						dsPhonebook.Clear();
						Navigation.BaseObject.SafeMerge(dsPhonebook, ((Navigation.BaseObject)Session["navigation"]).ContactWsObject.ListContactPhones(contactID));

						ERP.SharedComponents.Data.dsPhonebook.GEN_PhonebookRow row = dsPhonebook.GEN_Phonebook.NewGEN_PhonebookRow();
						row.ContactID = contactID;
						row.AreaCode = txtArea.Text;
						row.CountryCode = txtCountry.Text;
						row.PhoneZone = txtZone.Text;
						row.PhoneNumber = txtNumber.Text;
						row.PhoneType = lstType.SelectedValue;
						row.PrimaryPhoneBook= chkPrimary.Checked;
						
						//////////						((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.UpdatePhoneBook(dsPhonebook);

						

						
						//--------------
						// If the new phone is primary, reset all other phones
						//--------------
						//////////						Navigation.BaseObject.SafeMerge(dsPhonebook,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListContactPhones(contactID));
						
						dsPhonebook.GEN_Phonebook.AddGEN_PhonebookRow(row);
						int xx = ((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.UpdatePhoneBook(dsPhonebook);



						BindPhones();
						lblMSG.Text = "Phone added Successfully";
					}
					else
					{
						lblMSG.Text = "This number added so far , please try another one";
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
				int phoneID = int.Parse(e.Item.Cells[1].Text); 
				dsPhonebook.Clear();
				Navigation.BaseObject.SafeMerge(dsPhonebook,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListContactPhones(contactID));
				ERP.SharedComponents.Data.dsPhonebook.GEN_PhonebookRow row 
					=  dsPhonebook.GEN_Phonebook.FindByPhoneBookID(phoneID);
				row.Delete();
				((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.UpdatePhoneBook(dsPhonebook);
				BindPhones();
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
	}
}
