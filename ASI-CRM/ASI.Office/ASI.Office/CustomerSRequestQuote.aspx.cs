using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Configuration;
using Office.DAL;
using Office.BLL;

public partial class CustomerSRequestQuote : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // must be deleted to work in USA //mglil
        //System.Net.IWebProxy proxy = new System.Net.WebProxy("http://ISA1:8080", true);
        //proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
        //sdata.Proxy = proxy;
        string CurrentPage = "CustomerSupport";
		  //ucUserTabs.CurrentPage = CurrentPage;
        divEdit.Visible = false;
        divDetails.Visible = false;
        lbToTSNOffice.Visible = false;
        if (!Page.IsPostBack)
        {
            Office.BLL.MasterClass mc = new Office.BLL.MasterClass();
				//lblVersionInfo.Text = mc. GetVersionInfo();
            ViewState["RequestQuoteURL"] = ConfigurationManager.AppSettings["RequestQuote.dataservice"].ToString();
            ViewState["RequestQuoteWSUserName"] = ConfigurationManager.AppSettings["UserNameRequestQuote"].ToString();
            ViewState["RequestQuoteWSPassword"] = ConfigurationManager.AppSettings["PasswordRequestQuote"].ToString();
            bindGrid();
            try
            {
                string ID = (Request.QueryString.Get("CustomerSupportID") == null) ? "" : Request.QueryString.Get("CustomerSupportID");
                if (ID.Trim() != null && ID != "")
                {
                    divDetails.Visible = true;
                    FillDetails(ID);

                }
            }
            catch (Exception ex) { string msg=ex.Message;}
                      
         }
        // 
    }
    private void bindGrid()
    {
        DataView dv =  GetAllCustomerSupportRequestQuote();
        gvCustomerSupport.DataSource = dv;
        gvCustomerSupport.DataBind();
        // added By Sayed Moawad 18/8/2011
        // get ditinct countries from datviev
        DataTable CountriesTable = dv.ToTable("CountriesTable", true, "country");
        ddCountries.Items.Clear();
        ddCountries.DataSource = CountriesTable;
        ddCountries.DataTextField = "country";
        ddCountries.DataValueField = "country";
        ddCountries.DataBind();
        BindLoginUsers();
        //



    }
    private void BindLoginUsers()
    {
        CustomerSupportBLL CSobj = new CustomerSupportBLL();
        DataSet dsLoginUsers = CSobj.GetLoginUsers();
        ddlLoginUsers.Items.Clear();
        ddlLoginUsers.DataSource = dsLoginUsers.Tables[0];
        ddlLoginUsers.DataTextField = "UserName";
        ddlLoginUsers.DataValueField = "UID";
        ddlLoginUsers.DataBind();

    }
    
    protected DataView  GetAllCustomerSupportRequestQuote()
    {
       RequestQuote.DataService sdata = new RequestQuote.DataService();
       RequestQuote.AuthHeader ss = new RequestQuote.AuthHeader();
        sdata.Url = ViewState["RequestQuoteURL"].ToString();
        ss.Password = ViewState["RequestQuoteWSPassword"].ToString();
        ss.Username = ViewState["RequestQuoteWSUserName"].ToString();
        sdata.AuthHeaderValue = ss;
        DataTable dt = sdata.getRequestForm();
        DataView dv = dt.DefaultView;

        return dv;

    }
   
    

    protected void lbtnDetails_Click(object sender, EventArgs e)
    {
       // ViewState["Mode"] = "Edit";
        divEdit.Visible = false;
        divDetails.Visible = true;
        lbToTSNOffice.Visible = false;
        //lbToRegistration.Visible = true;
        GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent;
        string ID = row.Cells[0].Text.Trim();
        // call new function from to get data from SSSAdmin web services by email 
        FillDetails(ID);
    }

    private void FillDetails(string ID)
    {
        if (ID != "")
        {
            DataRow drData = mGetRequestQuoteDataByEmail(ID);
            if (drData != null)
            {
                lblResult.Text = "";
                txtid.Text = drData["id"].ToString();
                txtfname.Text = drData["fname"].ToString();
                txtlname.Text = drData["lname"].ToString();
                txtphone.Text = drData["phone"].ToString();
                txtemail.Text = drData["email"].ToString();
                txtcompany.Text = drData["company"].ToString();
                txtIndustry.Text = drData["industry"].ToString();
                txtcomments.Text = drData["comments"].ToString();
                lblStatusValue.Text = drData["status"].ToString();
                if (drData["status"].ToString().Trim() == "active")
                {
                    rbtnActive.Checked = true;
                    rbtnNotActive.Checked = false;
                }
                else
                {
                    rbtnActive.Checked = false;
                    rbtnNotActive.Checked = true;
                }
                txtwebsite.Text = drData["website"].ToString();
                cbELSsoftware.Checked = Convert.ToBoolean(drData["Elssoftware"]);
                cbPlugings.Checked = Convert.ToBoolean(drData["plugins"]);
                cbSupportService.Checked = Convert.ToBoolean(drData["Supportservices"]);
                cbTraining.Checked = Convert.ToBoolean(drData["Training"]);



                string sCountry = drData["country"].ToString().Trim();
                ListItem cItem = ddCountries.Items.FindByValue(sCountry);
                if (cItem != null)
                {
                    ddCountries.SelectedIndex = -1;
                    cItem.Selected = true;
                }

            }
            else
            {
                mResetControls();
            }

        }
        else
        {
            mResetControls();
        }
    }
    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        // ViewState["Mode"] = "Edit";
        divEdit.Visible = true;
        divDetails.Visible = false;
        lbToTSNOffice.Visible = false;
        //lbToRegistration.Visible = true;
        GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent;
        string ID = row.Cells[0].Text.Trim();
        // call new function from to get data from SSSAdmin web services by email 
        if (ID != "")
        {
            DataRow drData = mGetRequestQuoteDataByEmail(ID);
            if (drData != null)
            {
                lblResult.Text = "";
                txtid.Text = drData["id"].ToString();
                txtfname.Text = drData["fname"].ToString();
                txtlname.Text = drData["lname"].ToString();
                txtphone.Text = drData["phone"].ToString();
                txtemail.Text = drData["email"].ToString();
                txtcompany.Text = drData["company"].ToString();
                txtIndustry.Text = drData["industry"].ToString();
                txtcomments.Text = drData["comments"].ToString();
                lblStatusValue.Text = drData["status"].ToString();
                if (drData["status"].ToString().Trim() == "active")
                {
                    rbtnActive.Checked = true;
                    rbtnNotActive.Checked = false;
                }
                else
                {
                    rbtnActive.Checked = false;
                    rbtnNotActive.Checked = true;
                }
                txtwebsite.Text = drData["website"].ToString();
                cbELSsoftware.Checked = Convert.ToBoolean(drData["Elssoftware"]);
                cbPlugings.Checked = Convert.ToBoolean(drData["plugins"]);
                cbSupportService.Checked = Convert.ToBoolean(drData["Supportservices"]);
                cbTraining.Checked = Convert.ToBoolean(drData["Training"]);



                string sCountry = drData["country"].ToString().Trim();
                ListItem cItem = ddCountries.Items.FindByValue(sCountry);
                if (cItem != null)
                {
                    ddCountries.SelectedIndex = -1;
                    cItem.Selected = true;
                }

            }
            else
            {
                mResetControls();
            }

        }
        else
        {
            mResetControls();
        }
    }
    private void mResetControls()
    {
        txtid.Text = "";
        txtfname.Text = "";
        txtlname.Text = "";
        txtphone.Text = "";
        txtemail.Text = "";
        txtcompany.Text = "";
        txtIndustry.Text = "";
        ddCountries.SelectedIndex = -1;
       // txtStatus.Text = "";
        txtwebsite.Text = "";
        txtcomments.Text = "";
        lblResult.Text = "";
        cbELSsoftware.Checked = false;
        cbPlugings.Checked = false;
        cbSupportService.Checked = false;
        cbTraining.Checked = false;
        rbtnActive.Checked = false;
        rbtnNotActive.Checked = true;
       // ViewState["Mode"] = "Add";
    }
   
    protected void gvWebinar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    LinkButton l = (LinkButton)e.Row.FindControl("lbtnDelete");
        //    l.Attributes["onclick"] = "javascript:return confirm('You are about to delete the selected Member. continue...?')";
        //}

    }

    DataRow mGetRequestQuoteDataByEmail(string ID)
    {
       RequestQuote.DataService sdata = new RequestQuote.DataService();
       RequestQuote.AuthHeader ss = new RequestQuote.AuthHeader();
        sdata.Url = ViewState["RequestQuoteURL"].ToString();
        ss.Password = ViewState["RequestQuoteWSPassword"].ToString();
        ss.Username = ViewState["RequestQuoteWSUserName"].ToString();
        // must be deleted to work in USA // mglil
        //System.Net.IWebProxy proxy = new System.Net.WebProxy("http://ISA1:8080", true);
        //proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
        //sdata.Proxy = proxy;
        // 
        sdata.AuthHeaderValue = ss;
        DataTable dt = sdata.getRequestFormDetails(Convert.ToInt32(ID));
        //DataTable dFiltered = dt.Clone();
        //DataRow[] dRowUpdates = dt.Select("email Like'%" + vsEmail + "%'");
        //foreach (DataRow dr in dRowUpdates)
        //    dFiltered.ImportRow(dr);
        if (dt.Rows.Count > 0)
            return dt.Rows[0];
        else return null;
    }

    protected void lbToTSNOffice_Click(object sender, EventArgs e)
    {
        Response.Redirect("contacts.aspx?Email=" + txtemail.Text.Trim());
    }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if ( txtid.Text.Trim()!= "")
        {
            //string status = "false";
            // call update webinar function
           // if (rbtnActive.Checked)
            //    status = "true";


            if (mUpdateStatus(txtid.Text, ddlStatus.SelectedValue))
            {
                lblResult.Text = "<font color='red'>Data has been saved.</font>";
                bindGrid();
            }
            else lblResult.Text = "<font color='red'>Data hasn't been saved.</font>";

        }
        else lblResult.Text = "<font color='red'>Please add valid status.</font>";
       
        
    }
    protected void imgbtnSignOut_Click(object sender, ImageClickEventArgs e)
    {
        HttpContext.Current.Session.Clear();
        HttpContext.Current.Response.Redirect("login.aspx");
    }
    private bool mUpdateStatus(string id, string Status)
    {
       RequestQuote.DataService sdata = new RequestQuote.DataService();
       RequestQuote.AuthHeader ss = new RequestQuote.AuthHeader();
        sdata.Url = ViewState["RequestQuoteURL"].ToString();
        ss.Password = ViewState["RequestQuoteWSPassword"].ToString();
        ss.Username = ViewState["RequestQuoteWSUserName"].ToString();
        // must be deleted to work in USA // mglil
        //System.Net.IWebProxy proxy = new System.Net.WebProxy("http://ISA1:8080", true);
        //proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
        //sdata.Proxy = proxy;
        // 
        sdata.AuthHeaderValue = ss;
        bool result = sdata.UpdateStatus(Convert.ToInt32(id), Status);
        return result;

    }
  
   
    protected void DDListWebinars_SelectedIndexChanged(object sender, EventArgs e)
    {
       // ViewState["SelectedDate"] = DDListWebinars.SelectedValue.ToString();
        bindGrid();
    }
    protected void gvWebinar_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCustomerSupport.PageIndex = e.NewPageIndex;
        bindGrid();
    }
    
    protected void btnCancel_Click(object sender, EventArgs e)
    {
       
        //txtid.Text = "New ID";
        txtid.Enabled = false;
        mResetControls();
        lbToTSNOffice.Visible = false;
        //lbToRegistration.Visible = false;
    }

    protected void gvWebinar_Sorting(object sender, GridViewSortEventArgs e)
    {
        bindGrid();

    }
  
    
   
   
    
    protected void ddlWebsitesWS_SelectedIndexChanged(object sender, EventArgs e)
    {
        // we will change this code to set values from database according to selected site
        ViewState["RequestQuoteURL"] = ConfigurationManager.AppSettings["RequestQuote.dataservice"].ToString();
        ViewState["RequestQuoteWSUserName"] = ConfigurationManager.AppSettings["UserNameRequestQuote"].ToString();
        ViewState["RequestQuoteWSPassword"] = ConfigurationManager.AppSettings["PasswordRequestQuote"].ToString();
    }
    protected void lbtnELSASI_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerSupport.aspx");
    }
    protected void btnForword_Click(object sender, EventArgs e)
    {
        CustomerSupportBLL CSobj = new CustomerSupportBLL();
        bool result = CSobj.AddNewForwordTechnicalSupport("Answer Technical Question", txtfname.Text + " " + txtlname.Text, "Technical Support Forword", Convert.ToInt32(((ASIIdentity)User.Identity).UserID.ToString()), DateTime.Now, Convert.ToInt32(ddlLoginUsers.SelectedValue), "Active", Convert.ToInt32(txtid.Text.Trim()), DateTime.Now,"SSS" /*ViewState["ASIURL"].ToString()*/);
        if (result)
        {
            lblResult.Text = "<font color='red'>Data has been forword.</font>";

        }
        else lblResult.Text = "<font color='red'>Data hasn't been forword.</font>";
    }
    protected void gvCustomerSupport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // ImageButton l = (ImageButton)e.Row.FindControl("ImgDelete");
            //l.Attributes["onclick"] = "javascript:return confirm('You are about to delete the selected template. continue...?')";
            e.Row.Cells[0].Visible = false;

            
        }
        else if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Visible = false;

        }
    }
}