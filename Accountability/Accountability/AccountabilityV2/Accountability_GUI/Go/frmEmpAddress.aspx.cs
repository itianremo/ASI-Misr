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
	/// Summary description for EmployeeAdresses.
	/// </summary>
	public partial class frmEmpAdress : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected TSN.ERP.SharedComponents.Data.dsCountry dsCountry;
		protected TSN.ERP.SharedComponents.Data.dsAddress dsAddress;
		protected TSN.ERP.SharedComponents.Data.dsState dsState;
		protected TSN.ERP.SharedComponents.Data.dsCity dsCity;
		
		private static int contactID;
		//--------------------------------------------------------
		#region page load
		protected void Page_Load(object sender, System.EventArgs e)
		{
			contactID =int.Parse(Session["contactID"].ToString());
			lblMSG.Text = "";
			if (!IsPostBack) 
			{						
				lblCode.Text = Session["code"].ToString();
				lblName.Text = Session["name"].ToString();
				// bind countries
				BindCountries();
				bindAddresses();
				ViewState[ "ActionMode" ] = "A";
			}
		}
		#endregion 
		//--------------------------------------------------------
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
			this.dsCountry = new TSN.ERP.SharedComponents.Data.dsCountry();
			this.dsAddress = new TSN.ERP.SharedComponents.Data.dsAddress();
			this.dsState = new TSN.ERP.SharedComponents.Data.dsState();
			this.dsCity = new TSN.ERP.SharedComponents.Data.dsCity();
			((System.ComponentModel.ISupportInitialize)(this.dsCountry)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsAddress)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsState)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCity)).BeginInit();
			this.grdAddresses.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grdAddresses_ItemDataBound);
			// 
			// dsCountry
			// 
			this.dsCountry.DataSetName = "dsCountry";
			this.dsCountry.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dsAddress
			// 
			this.dsAddress.DataSetName = "dsAddress";
			this.dsAddress.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dsState
			// 
			this.dsState.DataSetName = "dsState";
			this.dsState.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dsCity
			// 
			this.dsCity.DataSetName = "dsCity";
			this.dsCity.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.dsCountry)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsAddress)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsState)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCity)).EndInit();

		}
		#endregion
		//--------------------------------------------------------
		#region save address
		public bool CheckAddressForAdd(TSN.ERP.SharedComponents.Data.dsAddress ds,string Address,int ContactID)
		{
			bool flag = true ;
			
			foreach(DataRow dr in ds.Tables["GEN_Address"].Rows)
			{
				flag = true;
				if(dr["AddressLine"].ToString().ToLower().Trim()== Address.ToLower() && int.Parse(dr["ContactID"].ToString().Trim())==ContactID)
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
		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			if(Page.IsValid)
			{
				try
				{
					tblErr.Visible = false;
					if (validateForm())
					{
						if(  ViewState[ "ActionMode" ].ToString() == "A" )
						{
							// add the new address
							dsAddress.Clear();
							Navigation.BaseObject.SafeMerge(dsAddress,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListContactAddress(contactID));
							bool Flage = CheckAddressForAdd(dsAddress,txtAddress.Text.Trim(),contactID);
							if(Flage)
							{
								dsAddress.EnforceConstraints = false;
								ERP.SharedComponents.Data.dsAddress.GEN_AddressRow row2 = 
									dsAddress.GEN_Address.NewGEN_AddressRow();
								if(chkPrimary.Checked)
								{
									foreach(DataRow dr in dsAddress.Tables[0].Rows)
									{
										dr["PrimaryAddress"] = false;
								
									}
								((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.UpdateAddress(dsAddress);
								}
								dsAddress.AcceptChanges();
								row2.AddressLine = txtAddress.Text;
								row2.CityID = int.Parse(lstCities.SelectedValue);
								row2.ZipCode = txtZIP.Text;
								row2.ContactID = contactID;
								row2.PrimaryAddress = chkPrimary.Checked;
								dsAddress.GEN_Address.AddGEN_AddressRow(row2);
								((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.UpdateAddress(dsAddress);
								bindAddresses();
								lblMSG.Text = "Address added successfully";
							}
							else
							{
								lblMSG.Text = "This Address added so far , please another one";
							}
						}
						else if ( ViewState[ "ActionMode" ].ToString() == "U" )
						{
							// Update address
							dsAddress.Clear();
							Navigation.BaseObject.SafeMerge(dsAddress,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListContactAddress(contactID));
							//bool Flage = CheckAddressForAdd(dsAddress,txtAddress.Text.Trim(),contactID);

							int addressID = int.Parse(grdAddresses.SelectedItem.Cells[ 0 ].Text); 
							dsAddress.EnforceConstraints = false;
							ERP.SharedComponents.Data.dsAddress.GEN_AddressRow row2 = 
								dsAddress.GEN_Address.FindByAddressID(addressID);
							row2.AddressLine = txtAddress.Text;
							row2.CityID = int.Parse(lstCities.SelectedValue);
							row2.ZipCode = txtZIP.Text;
							row2.ContactID = contactID;
							row2.PrimaryAddress = chkPrimary.Checked;
							((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.UpdateAddress(dsAddress);
							bindAddresses();
							lblMSG.Text = "Address Updated successfully";

							// clear controls 
							txtAddress.Text = "" ;
							lstCountries.SelectedIndex = 0;
							lstStates.SelectedIndex = 0; 
							lstCities.SelectedIndex = 0;
							txtZIP.Text = "";
							chkPrimary.Checked = false;
							ViewState[ "ActionMode" ] = "A";
						}
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
		//--------------------------------------------------------
		#region bind addresses
		private void bindAddresses()
		{
			try
			{
				dsAddress.Clear();
				DataTable dtJoin;
				// join county, state , city and address dataset to get employee's
				// address
				Navigation.BaseObject.SafeMerge(dsCountry,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListAllCountries());
				Navigation.BaseObject.SafeMerge(dsState,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListAllStates());
				Navigation.BaseObject.SafeMerge(dsCity,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListAllCities());
				Navigation.BaseObject.SafeMerge(dsAddress,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListContactAddress(contactID));
			
				dtJoin = DSHelper.Join(dsAddress.Tables[0],dsCity.Tables[0],"CityID","CityID");
				dtJoin = DSHelper.Join(dtJoin,dsState.Tables[0],"StateCode","StateCode");
				dtJoin = DSHelper.Join(dtJoin,dsCountry.Tables[0],"CountryID","CountryID");
				grdAddresses.DataSource = dtJoin;
				grdAddresses.DataBind();
			}
			catch(Exception ex)
			{
				//TODO
				//Response.Write(ex.Message);
			}
		}
		#endregion
		//--------------------------------------------------------
		#region bind countries to dropdowlist
		public DataSet BindCountries()
		{	
			dsCountry.Clear();
			lstCountries.Items.Clear();
			Navigation.BaseObject.SafeMerge(dsCountry,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListAllCountries());
			lstCountries.DataBind();
			lstCountries.Items.Insert(0,"Select One --------");	
			return dsCountry;
		}
		#endregion
		//--------------------------------------------------------
		#region bind states
		public DataSet BindStates(int CountryID)
		{
			dsState.Clear();
			lstStates.Items.Clear();
			lstCities.Items.Clear();
			Navigation.BaseObject.SafeMerge(dsState,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListAllCountryStates(CountryID));
			lstStates.DataBind();
			lstStates.Items.Insert(0,"Select One ---------");
			return dsState; 
		}
		#endregion
		//--------------------------------------------------------
		#region bind cities
		public DataSet BindCities(int StateID)
		{
			dsCity.Clear();
			lstCities.Items.Clear();
			Navigation.BaseObject.SafeMerge(dsCity,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListAllStateCities(StateID));
			lstCities.DataBind();
			lstCities.Items.Insert(0,"Select One ---------");
			return dsCity;
		}
		#endregion
		//--------------------------------------------------------
		#region on lstCountries selected index change 
		protected void lstCountries_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstCountries.SelectedIndex !=0)
				BindStates(int.Parse(lstCountries.SelectedValue));
			else
			{
				lstStates.Items.Clear();
				lstCities.Items.Clear();
			}
				
		}
		#endregion
		//--------------------------------------------------------
		#region grid paging
		private void grdAddresses_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grdAddresses.CurrentPageIndex = e.NewPageIndex;
			bindAddresses();
		}
		#endregion
		//--------------------------------------------------------
		#region on lstStates selected index change
		protected void lstStates_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstStates.SelectedIndex !=0)
				BindCities(int.Parse(lstStates.SelectedValue));
			else
				lstCities.Items.Clear();
		}
		#endregion
		//--------------------------------------------------------
		#region delete address
		public void OnDelete(object sender,DataGridCommandEventArgs e)
		{
			try
			{
				int addressID = int.Parse(e.Item.Cells[0].Text); 
				dsAddress.Clear();
				Navigation.BaseObject.SafeMerge(dsAddress,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListContactAddress(contactID));
				dsAddress.EnforceConstraints = false;
				ERP.SharedComponents.Data.dsAddress.GEN_AddressRow row 
					=  dsAddress.GEN_Address.FindByAddressID(addressID);
				row.Delete();
				((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.UpdateAddress(dsAddress);
				bindAddresses();
			}
			catch(Exception ex)
			{
				Response.Write(ex.Message);
				//TODO
			}
		}
		#endregion
		//--------------------------------------------------------
		#region fired during grid databind
		private void grdAddresses_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			try
			{
				if(e.Item.ItemType==ListItemType.Item||e.Item.ItemType==ListItemType.AlternatingItem || e.Item.ItemType==ListItemType.SelectedItem)
				{
					System.Web.UI.WebControls.Image img = 
						(System.Web.UI.WebControls.Image)e.Item.FindControl("imgPrimary");
					if (e.Item.Cells[7].Text =="True")
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
		//--------------------------------------------------------
		#region validate form
		public bool validateForm()
		{
			tblErr.Rows[0].Cells[0].Text = "";
			string msg="";
			if (lstCountries.SelectedIndex == 0)
			{
				msg = msg + "<li> Please specify a country</li>" ;
			}
			if (lstStates.SelectedIndex <= 0)
			{
				msg = msg + "<li> Please specify a state</li>" ;
			}
			if (lstCities.SelectedIndex <= 0)
			{
				msg = msg + "<li> Please specify a city</li>" ;
			}
			if (txtZIP.Text == "")
			{
				msg = msg + "<li> Please specify a ZIP code</li>" ;
			}
			if (txtAddress.Text == "")
			{
				msg = msg + "<li> Please specify an address</li>" ;
			}
			
			if (msg != "")
			{
				msg = "<ul>" + msg + "</ul>";
				tblErr.Rows[0].Cells[0].Text = "<p><b>Please correct the following entries</b></p>" 
					+ msg;
				tblErr.Visible = true;
				return false;
			}
			else
			{
				return true;
			}		
		}
		#endregion
		//--------------------------------------------------------
		#region Select Address
		public void OnSelect(object sernder, System.EventArgs e)
		{
			try
			{
				
				int addressID = int.Parse(grdAddresses.SelectedItem.Cells[ 0 ].Text); 
				dsAddress.Clear();
				Navigation.BaseObject.SafeMerge(dsAddress,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListContactAddress(contactID));
				ERP.SharedComponents.Data.dsAddress.GEN_AddressRow row 
					=  dsAddress.GEN_Address.FindByAddressID(addressID);

				txtAddress.Text = row.AddressLine ;
				lstCountries.SelectedIndex = lstCountries.Items.IndexOf( lstCountries.Items.FindByText( grdAddresses.SelectedItem.Cells[ 1 ].Text ));
				BindStates(int.Parse(lstCountries.SelectedValue));
				lstStates.SelectedIndex = lstStates.Items.IndexOf( lstStates.Items.FindByText( grdAddresses.SelectedItem.Cells[ 2 ].Text )); 
				BindCities( int.Parse(lstStates.SelectedValue));
				lstCities.SelectedValue = row.CityID.ToString();
				txtZIP.Text = row.ZipCode;
				chkPrimary.Checked = row.PrimaryAddress;

				ViewState[ "ActionMode" ] = "U";
				
			}
			catch(Exception ex)
			{
				Response.Write(ex.Message);
			
			}
		}

		#endregion

}	
}
