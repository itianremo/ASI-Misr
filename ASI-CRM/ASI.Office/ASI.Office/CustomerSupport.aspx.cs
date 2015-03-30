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

public partial class CustomerSupport :  Office.BLL.MasterClass
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
            ViewState["ASIURL"] = ConfigurationManager.AppSettings["ELSData.DataService"].ToString();
            ViewState["ASIWSUserName"] = ConfigurationManager.AppSettings["UserNameELS"].ToString();
            ViewState["ASIWSPassword"] = ConfigurationManager.AppSettings["PasswordELS"].ToString();
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
            catch (Exception ex) { string msg = ex.Message; }
                      
         }
        // 
    }
    private void bindGrid()
    {
        DataView dv = GetAllCustomerSupport();
        gvCustomerSupport.DataSource = dv;
         gvCustomerSupport.DataBind();

        // added By Sayed Moawad 18/8/2011
        // get distinct countries from datviev
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
        DataSet dsLoginUsers= CSobj.GetLoginUsers();
        ddlLoginUsers.Items.Clear();
        ddlLoginUsers.DataSource = dsLoginUsers.Tables[0];
        ddlLoginUsers.DataTextField = "UserName";
        ddlLoginUsers.DataValueField = "UID";
        ddlLoginUsers.DataBind();
        
    }

    
    protected DataView GetAllCustomerSupport()
    {
        ELSData.DataService sdata = new ELSData.DataService();
        ELSData.AuthHeader ss = new ELSData.AuthHeader();
        sdata.Url = ViewState["ASIURL"].ToString();
        ss.Password = ViewState["ASIWSPassword"].ToString();
        ss.Username = ViewState["ASIWSUserName"].ToString();
        sdata.AuthHeaderValue = ss;
        DataTable dt = sdata.getAllContact();
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
            DataRow drData = mGetCustomerSupportDataByEmail(ID);
            if (drData != null)
            {
                lblResult.Text = "";
                txtid.Text = drData["id"].ToString();
                txtfname.Text = drData["FirstName"].ToString();
                txtlname.Text = drData["LastName"].ToString();
                txtphone.Text = drData["phone"].ToString();
                txtemail.Text = drData["email"].ToString();
                txtcompany.Text = drData["CompanyName"].ToString();
                txtwebsite.Text = drData["industry"].ToString();
                txtcomments.Text = drData["comments"].ToString();
                lblStatusValue.Text = drData["status"].ToString();

                if (drData["status"].ToString().Trim().ToLower() == "active")
                {
                    rbtnActive.Checked = true;
                    rbtnNotActive.Checked = false;
                }
                else
                {
                    rbtnActive.Checked = false;
                    rbtnNotActive.Checked = true;
                }


                string sCountry = drData["country"].ToString();
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
            DataRow drData = mGetCustomerSupportDataByEmail(ID);
            if (drData != null)
            {
                lblResult.Text = "";
                txtid.Text = drData["id"].ToString();
                txtfname.Text = drData["FirstName"].ToString();
                txtlname.Text = drData["LastName"].ToString();
                txtphone.Text = drData["phone"].ToString();
                txtemail.Text = drData["email"].ToString();
                txtcompany.Text = drData["CompanyName"].ToString();
                txtwebsite.Text = drData["industry"].ToString();
                txtcomments.Text = drData["comments"].ToString();
                lblStatusValue.Text = drData["status"].ToString();

                if (drData["status"].ToString().Trim().ToLower() == "active")
                {
                    rbtnActive.Checked = true;
                    rbtnNotActive.Checked = false;
                }
                else
                {
                    rbtnActive.Checked = false;
                    rbtnNotActive.Checked = true;
                }


                string sCountry = drData["country"].ToString();
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
        txtwebsite.Text = "";
        ddCountries.SelectedIndex = -1;
        //txtStatus.Text = "";
        txtcomments.Text = "";
        lblResult.Text = "";
        rbtnActive.Checked = false;
        rbtnNotActive.Checked = true;
    }
   
    protected void gvWebinar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    LinkButton l = (LinkButton)e.Row.FindControl("lbtnDelete");
        //    l.Attributes["onclick"] = "javascript:return confirm('You are about to delete the selected Member. continue...?')";
        //}

    }
  
    DataRow mGetCustomerSupportDataByEmail(string ID)
    {
        ELSData.DataService sdata = new ELSData.DataService();
        ELSData.AuthHeader ss = new ELSData.AuthHeader();
        sdata.Url = ViewState["ASIURL"].ToString();
        ss.Password = ViewState["ASIWSPassword"].ToString();
        ss.Username = ViewState["ASIWSUserName"].ToString();
        // must be deleted to work in USA // mglil
        //System.Net.IWebProxy proxy = new System.Net.WebProxy("http://ISA1:8080", true);
        //proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
        //sdata.Proxy = proxy;
        // 
        sdata.AuthHeaderValue = ss;
        DataTable dt = sdata.getContactDetails(Convert.ToInt32(ID));
       // DataTable dFiltered = dt.Clone();
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
           // string status = "false";
           //if (rbtnActive.Checked)
           //     status = "true";
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
        ELSData.DataService sdata = new ELSData.DataService();
        ELSData.AuthHeader ss = new ELSData.AuthHeader();
        sdata.Url = ViewState["ASIURL"].ToString();
        ss.Password = ViewState["ASIWSPassword"].ToString();
        ss.Username = ViewState["ASIWSUserName"].ToString();
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
    private string GetSortDirection(string column)
    {
        // By default, set the sort direction to ascending.
        string sortDirection = "ASC";

        // Retrieve the last column that was sorted.
        string sortExpression = ViewState["SortExpression"] as string;

        if (sortExpression != null)
        {
            // Check if the same column is being sorted.
            // Otherwise, the default value can be returned.
            if (sortExpression == column)
            {
                string lastDirection = ViewState["SortDirection"] as string;
                if ((lastDirection != null) && (lastDirection == "ASC"))
                {
                    sortDirection = "DESC";
                }
            }
        }

        // Save new values in ViewState.
        ViewState["SortDirection"] = sortDirection;
        ViewState["SortExpression"] = column;
        return sortDirection;
    }
    
   
   
    
    protected void ddlWebsitesWS_SelectedIndexChanged(object sender, EventArgs e)
    {
        // we will change this code to read from database according to selected site
        ViewState["ASIURL"] = ConfigurationManager.AppSettings["ELSData.DataService"].ToString();
        ViewState["ASIWSUserName"] = ConfigurationManager.AppSettings["UserNameELS"].ToString();
        ViewState["ASIWSPassword"] = ConfigurationManager.AppSettings["PasswordELS"].ToString();
    }
    protected void lbtnRequestQuote_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerSRequestQuote.aspx");
    }
    protected void btnForword_Click(object sender, EventArgs e)
    {
        CustomerSupportBLL CSobj = new CustomerSupportBLL();
      bool result=  CSobj.AddNewForwordTechnicalSupport("Answer Technical Question", txtfname.Text + " " + txtlname.Text, "Technical Support Forword",Convert.ToInt32( ((ASIIdentity)User.Identity).UserID.ToString()), DateTime.Now, Convert.ToInt32(ddlLoginUsers.SelectedValue), "Active", Convert.ToInt32(txtid.Text.Trim()), DateTime.Now, ViewState["ASIURL"].ToString());
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