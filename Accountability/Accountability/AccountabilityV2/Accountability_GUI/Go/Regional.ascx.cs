using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using TSN.ERP.WebGUI.Navigation;
using System.Text.RegularExpressions;

namespace TSN.ERP.WebGUI.Go
    {

	/// <summary>
	///		Summary description for Regional.
	/// </summary>
	public partial class Regional : System.Web.UI.UserControl
	{
		protected TSN.ERP.SharedComponents.Data.dsCountry dsCountry1;
		protected TSN.ERP.SharedComponents.Data.dsCity dsCity1;
		//
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.TextBox TextBox3;
		protected System.Web.UI.HtmlControls.HtmlImage btnDelete;
		protected System.Web.UI.WebControls.ImageButton ImageButton5;
		protected System.Web.UI.WebControls.ImageButton ImageButton6;
		protected TSN.ERP.SharedComponents.Data.dsState dsState1;
		public MasterMethods master = new MasterMethods();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			resetErrHandler();

			if(lstCountries.SelectedIndex == 0)
			   btnDeleteCountry.Enabled = false ;

			if(lstStates.SelectedIndex == 0)
			   btnDeleteState.Enabled = false;
			    
			if(lstCities.SelectedIndex == 0)
               btnDeleteCity.Enabled = false;
			
			
			if (Session["Message"] != null)
			{
				lblConfirm.Text = Session["Message"].ToString();
				lblConfirm.Visible = true;

			}
			Session["Message"] = null;
			
			if (!IsPostBack) 
			{
				 BindCountries();
			     btnDeleteCountry.Enabled = false; 
				 btnDeleteState.Enabled = false ;
			     btnDeleteCity.Enabled = false ;
				 this.btnDeleteCountry.Attributes.Add("onclick","return confirm('Are you sure you want to delete the selected country including its states and cities?')");
			     this.btnDeleteState.Attributes.Add("onclick","return confirm('Are you sure you want to delete the selected state including its cities?')");
				 this.btnDeleteCity.Attributes.Add("onclick","return confirm('Are you sure you want to delete the selected city?')");
			}
			
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
			this.dsCountry1 = new TSN.ERP.SharedComponents.Data.dsCountry();
			this.dsState1 = new TSN.ERP.SharedComponents.Data.dsState();
			this.dsCity1 = new TSN.ERP.SharedComponents.Data.dsCity();
			((System.ComponentModel.ISupportInitialize)(this.dsCountry1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsState1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCity1)).BeginInit();
			this.btnDeleteCountry.Click += new System.Web.UI.ImageClickEventHandler(this.btnDeleteCountry_Click);
			this.btnAddCountry.Click += new System.Web.UI.ImageClickEventHandler(this.btnAddCountry_Click);
			this.btnDeleteState.Click += new System.Web.UI.ImageClickEventHandler(this.btnDeleteState_Click);
			this.btnAddState.Click += new System.Web.UI.ImageClickEventHandler(this.btnAddState_Click);
			this.btnDeleteCity.Click += new System.Web.UI.ImageClickEventHandler(this.btnDeleteCity_Click);
			this.btnAddCity.Click += new System.Web.UI.ImageClickEventHandler(this.btnAddCity_Click);
			// 
			// dsCountry1
			// 
			this.dsCountry1.DataSetName = "dsCountry";
			this.dsCountry1.EnforceConstraints = false;
			this.dsCountry1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dsState1
			// 
			this.dsState1.DataSetName = "dsState";
			this.dsState1.EnforceConstraints = false;
			this.dsState1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dsCity1
			// 
			this.dsCity1.DataSetName = "dsCity";
			this.dsCity1.EnforceConstraints = false;
			this.dsCity1.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.dsCountry1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsState1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCity1)).EndInit();

		}
		#endregion
		
		#region bind countries to dropdowlist
		
		public DataSet BindCountries()
		{	
			dsCountry1.Clear();
			lstCountries.Items.Clear();
			BaseObject.SafeMerge(dsCountry1,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListAllCountries());
			SetCountriesCache();
			lstCountries.DataBind();
			lstCountries.Items.Insert(0,"Select One --------");	
			return dsCountry1;
		}
		#endregion

		# region Set Cache Countries
		
		private void SetCountriesCache()
		{
			TSN.ERP.SharedComponents.Data.dsCountry CacheCountry = new TSN.ERP.SharedComponents.Data.dsCountry();
			BaseObject.SafeMerge(CacheCountry,dsCountry1);
			Session[ "CacheCountry" ] = CacheCountry;
		}
		
		# endregion
		
		#region bind cities
		
		public DataSet BindCities(int StateID)
		{
			dsCity1.Clear();
			lstCities.Items.Clear();
			BaseObject.SafeMerge(dsCity1,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListAllStateCities(StateID));
			//Sort Cities DataSet//////////////////////////////////
			DataView dvCity = dsCity1.GEN_City.DefaultView;
			dvCity.Sort = "CityName";
			dsCity1.Tables.Clear();
			dsCity1.Tables.Add(master.CreateTableFromView(dvCity));
			dsCity1.AcceptChanges();
			//////////////////////////////////////////////////////////
			SetCitiesCache();
			lstCities.DataBind();
			lstCities.Items.Insert(0,"Select One ---------");
			return dsCity1;
		}
		#endregion

		#region Set Cache Cities
		
		private void SetCitiesCache()
		{
			TSN.ERP.SharedComponents.Data.dsCity CacheCity = new TSN.ERP.SharedComponents.Data.dsCity();
			BaseObject.SafeMerge(CacheCity,dsCity1);
			Session[ "CacheCity" ] = CacheCity;
		}
		
		
		#endregion
		
		#region bind states
		public DataSet BindStates(int CountryID)
		{
			dsState1.Clear();
			lstStates.Items.Clear();
			lstCities.Items.Clear();
			BaseObject.SafeMerge(dsState1,((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.ListAllCountryStates(CountryID));
			SetStatesCache();
			lstStates.DataBind();
			lstStates.Items.Insert(0,"Select One ---------");
			return dsState1; 
		}
		#endregion
	
		#region Set State Cache
        
		private void SetStatesCache()
		{
			TSN.ERP.SharedComponents.Data.dsState CacheStates = new TSN.ERP.SharedComponents.Data.dsState();
			BaseObject.SafeMerge(CacheStates,dsState1);
			Session["CacheStates"] = CacheStates ;
		}
		
		#endregion
	
		#region on lstCountries selected index change 
		
		protected void lstCountries_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			resetColors();  // reset controls back colors to white
			if (lstCountries.SelectedIndex !=0)
			{
				BindStates(int.Parse(lstCountries.SelectedValue));
				Session["CountryID"] =  int.Parse(lstCountries.SelectedValue) ;
				
			    btnAddState.Visible = true;
			    txtState.Visible = true;

				btnAddCountry.Visible = false ;
			    txtCountry.Visible = false;
			
				btnAddCity.Visible = false;
				txtCity.Visible = false;
			    // 
				btnDeleteCountry.Enabled = true ;
				lstStates.Visible = true;
			}
			else
			{
				lstStates.Items.Clear();
				lstCities.Items.Clear();
				lstStates.Visible = false;
				lstCities.Visible = false;
				btnAddState.Visible = false;
				txtState.Visible = false;

				btnAddCountry.Visible = true ;
			    txtCountry.Visible = true;
				
				btnAddCity.Visible = false;
			    txtCity.Visible = false;
				//
			    btnDeleteCountry.Enabled = false ;

				txtCountry.Text=String.Empty;
				txtState.Text = String.Empty;
				txtCity.Text=String.Empty;
			}
			
			if(lstStates.SelectedIndex==0)
			{
				btnAddCity.Visible = false;
				txtCity.Visible = false;
				lstCities.Visible=false;
				btnDeleteCity.Visible=false;
			}
			   
			    btnDeleteState.Enabled = false;
			    btnDeleteCity.Enabled = false;
			    //
			    lblConfirm.Text = "";
	     		lblConfirm.Visible = false;
		}

		
		#endregion
		
		#region on lstStates selected index change
		
		protected void lstStates_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			resetColors();  // reset controls back colors to white
			if (lstStates.SelectedIndex !=0)
			{
				BindCities(int.Parse(lstStates.SelectedValue));
				Session["StateID"] = int.Parse(lstStates.SelectedValue);
		        
				btnAddCity.Visible = true;
			    txtCity.Visible = true;
				
				btnAddState.Visible = false;
			    txtState.Visible = false;
			    //
			    btnDeleteState.Enabled = true;
				lstCities.Visible = true;

			}
			else
			{
				lstCities.Items.Clear();
			    lstCities.Visible = false;
				btnAddCity.Visible = false;
			    txtCity.Visible = false;
				
				btnAddState.Visible = true;
			    txtState.Visible = true;
				//
			    btnDeleteState.Enabled = false;

				txtCountry.Text=String.Empty;
				txtState.Text = String.Empty;
				txtCity.Text=String.Empty;
			}
			   
			    btnDeleteCity.Enabled = false;
			   
			    lblConfirm.Text = "";
			    lblConfirm.Visible = false;
		
		
		}

		#endregion

		#region select Cities Changed
		
		protected void lstCities_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			resetColors();  // reset controls back colors to white
			if (lstCities.SelectedIndex !=0)
			{
				btnDeleteCity.Enabled = true;
				btnDeleteCity.Visible = true;
			}
			else
			{
				btnDeleteCity.Enabled = false;
				btnDeleteCity.Visible = false;

				txtCountry.Text=String.Empty;
				txtState.Text = String.Empty;
				txtCity.Text=String.Empty;
			}
		}
	 
		#endregion
		
		# region Add New Country
		
		bool CheckCountryByName(TSN.ERP.SharedComponents.Data.dsCountry ds,string CountryName)
		{	bool flag = true ;
				foreach(DataRow dr in ds.Tables["GEN_Country"].Rows)
				{
					flag = true;
					if(dr["CountryName"].ToString().ToLower().Trim()== CountryName.ToLower() )
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
		bool CheckStateByName(TSN.ERP.SharedComponents.Data.dsState ds,string StateName,int CountryID)
		{
		
			bool  flag = true;
			foreach(DataRow dr in ds.Tables["GEN_State"].Rows)
				{
					flag = true;
					if(dr["StateName"].ToString().ToLower().Trim()== StateName.ToLower() && int.Parse(dr["CountryID"].ToString().Trim())==CountryID)
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
		bool CheckCityByName(TSN.ERP.SharedComponents.Data.dsCity ds,string CityName,string StateCode)
		{
			bool flag = true;
			foreach(DataRow dr in ds.Tables["GEN_City"].Rows)
				{
					flag = true;
					if(dr["CityName"].ToString().ToLower().Trim()== CityName.ToLower() && dr["StateCode"].ToString().Trim()== StateCode.Trim())
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
		private void btnAddCountry_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if ( ValidateForm("Country"))
			{
				BaseObject.SafeMerge(dsCountry1,(DataSet) Session[ "CacheCountry" ]);
				TSN.ERP.SharedComponents.Data.dsCountry.GEN_CountryRow row = dsCountry1.GEN_Country.NewGEN_CountryRow();
				row.CountryName = txtCountry.Text ;

				bool Flage = CheckCountryByName(dsCountry1,txtCountry.Text.Trim());
				if(Flage)
				{
					dsCountry1.GEN_Country.AddGEN_CountryRow (row);
					((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.UpdateCountry(dsCountry1);
					BindCountries();

					lblConfirm.Visible = true;
					txtCountry.Text = "";
					btnDeleteCountry.Enabled = false ; 
					lblConfirm.Text = "Country added successfully";
				}
				else
				{
					lblConfirm.Visible = true;
					lblConfirm.Text = "This country name already exists, please try another one";
				}
			}
		}
		#endregion

		#region Add New State
		
		private void btnAddState_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if ( ValidateForm("State"))
			{
				BaseObject.SafeMerge(dsState1,(DataSet) Session[ "CacheStates" ]);
				TSN.ERP.SharedComponents.Data.dsState.GEN_StateRow row = dsState1.GEN_State.NewGEN_StateRow();
				row.CountryID = Convert.ToInt16(Session["CountryID"]) ; 
				row.StateName = txtState.Text ;
				
				bool Flage = CheckStateByName(dsState1,txtState.Text.Trim(),Convert.ToInt16(Session["CountryID"]));
				if(Flage)
				{
					dsState1.GEN_State.AddGEN_StateRow (row) ;
					((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.UpdateState(dsState1);
					BindStates(Convert.ToInt32(Session["CountryID"]));
					lblConfirm.Visible = true;
					txtState.Text = "";
					btnDeleteState.Enabled = false;
					lblConfirm.Text = "State added successfully";
				}
				else
				{
					lblConfirm.Visible = true;
					lblConfirm.Text = "This state name already exists, please try another one";
				}
			}
		}
		
		#endregion

		#region Add New City 
		
		private void btnAddCity_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if ( ValidateForm("City"))
			{
				BaseObject.SafeMerge(dsCity1,(DataSet) Session[ "CacheCity" ]);
				TSN.ERP.SharedComponents.Data.dsCity.GEN_CityRow row = dsCity1.GEN_City.NewGEN_CityRow();
				row.StateCode = Session["StateID"].ToString();
				row.CityName = txtCity.Text ;
				
				bool Flage = CheckCityByName(dsCity1,txtCity.Text.Trim(),Session["StateID"].ToString());
				if(Flage)
				{
					dsCity1.GEN_City.AddGEN_CityRow (row);
					int x = ((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.UpdateCity(dsCity1);
					BindCities(Convert.ToInt32(Session["StateID"]));
					lblConfirm.Visible = true;
					txtCity.Text = "";
					btnDeleteCity.Enabled = false;
					lblConfirm.Text = "City added successfully";
				}
				else
				{
					lblConfirm.Visible = true;
					lblConfirm.Text = "This city name already exists, please try another one";
				}
			}
		}
		#endregion
		
		#region Delete Country
		
		private void btnDeleteCountry_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (lstCountries.SelectedIndex !=0)
			{
				BaseObject.SafeMerge(dsCountry1,(DataSet) Session[ "CacheCountry" ]);
				dsCountry1.GEN_Country.Rows[lstCountries.SelectedIndex - 1].Delete();
				
				if (((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.DeleteCountry(dsCountry1) <= 0)
				{
					dsCountry1.RejectChanges();
					DeleteHandler("Country");
					return;
				}
				else 
				{
					Session["Message"] = lstCountries.SelectedItem.Text +" has been deleted from your countries list";
//					ClearServerCache();
					Response.Redirect("../Navigation/ContentPage.aspx?uc=Go/Regional.ascx");
				}
			}
		}
		
		# endregion

		#region DeleteHandler
		
		private void DeleteHandler(string msg)
		{
				tblErr.Rows[0].Cells[1].Text = "<br><b>This "+ msg +" Can't be deleted because it's assigned to another entity</b></br>";  
				tblErr.Visible = true;
		} 
		
		private void resetErrHandler()
		{
			   tblErr.Visible = false;
		}

		
		
		
		#endregion
		
		#region Delete State
		
		private void btnDeleteState_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (lstStates.SelectedIndex !=0)
			{
				BaseObject.SafeMerge(dsState1,(DataSet) Session[ "CacheStates" ]);
				dsState1.GEN_State.Rows[lstStates.SelectedIndex -1].Delete();
				
				if (((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.DeleteState(dsState1) <= 0)
				{
				dsState1.RejectChanges();
				DeleteHandler("State");
				return;
				}
				else 
				{
				Session["Message"] = lstStates.SelectedItem.Text +" has been deleted from your states list";
//				ClearServerCache();
				Response.Redirect("../Navigation/ContentPage.aspx?uc=Go/Regional.ascx");
				}
			}     
		}
		#endregion
		
		#region Delete City
		
		private void btnDeleteCity_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (lstCities.SelectedIndex !=0)
			{
				BaseObject.SafeMerge(dsCity1,(DataSet) Session[ "CacheCity" ]);
				dsCity1.GEN_City.Rows[lstCities.SelectedIndex -1].Delete();
				
				if(((Navigation.BaseObject) Session[ "navigation" ]).ContactWsObject.DeleteCity(dsCity1) <=0)
				{
					dsCity1.RejectChanges();
					DeleteHandler("City");
					return;
				}
				else
				{
					Session["Message"] = "Item has been deleted from your cities List";
//					ClearServerCache();
					Response.Redirect("../Navigation/ContentPage.aspx?uc=Go/Regional.ascx");
				}
			}
		}
		#endregion	  

		# region Clear Server Cache
		
		private void ClearServerCache()
		{
		    Cache.Remove("CacheCountry");
			Cache.Remove("CacheStates");
		    Cache.Remove("CacheCity");
		}
		# endregion

		#region reset control back colors to white
		private void resetColors()
		{
			txtCountry.BackColor = Color.White; 
			txtState.BackColor = Color.White; 
			txtCity.BackColor = Color.White; 
			tblErr.Visible = false;
		}
		#endregion

		#region validate user inputs
		/// <summary>
		/// Validate form inputs before going to save or update
		/// </summary>
		/// <returns></returns>
		private bool ValidateForm(string FieldType)
		{
			string msg="";
			resetColors();
			Regex reg = new Regex(@"[^a-zA-Z\s]");
			

			if (FieldType == "Country")
			{
				Match match = reg.Match(txtCountry.Text.Trim());
				if (txtCountry.Text.Trim() == "" || match.Success )
				{
					msg = "<li>Country name Shouldn't be empty or contains special characters</li>" ;
					txtCountry.BackColor = Color.LightYellow;
			
				}
			}
			if (FieldType == "State")
			{
				Match match = reg.Match(txtState.Text.Trim());
				if (txtState.Text.Trim() == "" || match.Success )
				{
					msg = "<li>State name Shouldn't be empty or contains special characters</li>" ;
					txtState.BackColor = Color.LightYellow;
				}
			
			}
			
			if (FieldType == "City")
			{
				Match match = reg.Match(txtCity.Text.Trim());
				if (txtCity.Text.Trim() == "" || match.Success)
				{
					msg = "<li>City name Shouldn't be empty or contains special characters</li>" ;
					txtCity.BackColor = Color.LightYellow;
				}
			
			}
			///////
			if (msg != "")
			{
				msg = "<ul>" + msg + "</ul>";
				tblErr.Rows[0].Cells[1].Text = "<p><b>Please correct the entries highlighted with yellow </b></p>" 
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

	
	}
	}

