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

public partial class Webinars : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // must be deleted to work in USA //mglil
        //System.Net.IWebProxy proxy = new System.Net.WebProxy("http://ISA1:8080", true);
        //proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
        //sdata.Proxy = proxy;
        string CurrentPage = "Webinars";
		  //ucUserTabs.CurrentPage = CurrentPage;
        if (!Page.IsPostBack)
        {
            //string CurrentPage = "Calls";
            //ucTransToolBar.CurrentPage = CurrentPage;
            Office.BLL.MasterClass mc = new Office.BLL.MasterClass();
				//lblVersionInfo.Text = mc. GetVersionInfo();
            ViewState["SelectedDate"] = "";
            txtStartFrom.Text = System.DateTime.Now.ToShortDateString();
            ViewState["WebinarsWSURL"] = ConfigurationManager.AppSettings["SSSData.SSSData"].ToString();
            ViewState["WebinarsWSUserName"] = ConfigurationManager.AppSettings["UserNameSSS"].ToString();
            ViewState["WebinarsWSPassword"] = ConfigurationManager.AppSettings["PasswordSSS"].ToString();
            bindGrid(false, "");
            BindWebinars();
            ViewState["Mode"] = "Add";
            //btnNew.Enabled = false;
            lbToTSNOffice.Visible = false;
            lbToRegistration.Visible = false;
            lblLocateUserTSNOffice.Visible = false;
            lblLocateUserRegistration.Visible = false;
            btnDelete.Visible = false;

         }
        // 
    }
    private void bindGrid(bool filter, string webinar)
    {
        DataView dv = GetAllWebinars(filter, webinar, "", "", "");
        gvWebinar.DataSource = dv;
        gvWebinar.DataBind();

    }

    private void bindGrid(bool filter, string webinar, string SearchEXpression)
    {
        DataView dv = GetAllWebinars(filter, webinar, "", "", SearchEXpression);
        gvWebinar.DataSource = dv;
        gvWebinar.DataBind();

    }

    private void bindGrid(bool filter, string webinar, string sortExpression, string sortDirection)
    {
        DataView dv = GetAllWebinars(filter, webinar, sortExpression, sortDirection, "");
        gvWebinar.DataSource = dv;
        gvWebinar.DataBind();

    }

    protected DataView GetAllWebinars(bool filter, string webinar, string sortExpression, string sortDirection, string searchExpression)
    {
        SSSData.SSSData sdata = new SSSData.SSSData();
        SSSData.AuthHeader ss = new SSSData.AuthHeader();
        sdata.Url = ViewState["WebinarsWSURL"].ToString();
        ss.Password = ViewState["WebinarsWSPassword"].ToString();
        ss.Username = ViewState["WebinarsWSUserName"].ToString();
        sdata.AuthHeaderValue = ss;
        DataTable dt = null;
        DataView dv = null;

        if (Session["webinars"] == null)
        {
            dt = sdata.GetAllWebinarRegistrations();
            dv = dt.DefaultView;
            Session["webinars"] = dv;
        }
        else
        {
            if (filter)
            {
                dv = (DataView)Session["webinars"];

            }
            else
            {
                dt = sdata.GetAllWebinarRegistrations();
                dv = dt.DefaultView;
                Session["webinars"] = dv;

            }

        }
        if (DDListWebinars.SelectedValue.ToString().Trim() != "All" && DDListWebinars.SelectedValue.ToString().Trim() != "")
        {
            dv.RowFilter = "Webinardata='" + DDListWebinars.SelectedValue.ToString() + "'";
        }
        else
        {
            dv.RowFilter = "1=1";

        }

        if (sortExpression.Trim() != "")
        {
            dv.Sort = sortExpression + " " + sortDirection;
        }

        if (searchExpression.Trim() != "")
        {
            dv.RowFilter = "email like '%" + txtSearch.Text.Trim() + "%' or lname like '%" + txtSearch.Text.Trim() + "%' or fname like '%" + txtSearch.Text.Trim() + "%'";
        }
        return dv;

    }
    private void BindWebinars()
    {
        DateTime startdate = Convert.ToDateTime("05/18/2010");
        try
        {
            startdate = Convert.ToDateTime(txtStartFrom.Text);
        }
        catch (Exception ex)
        {
            lblResult.Visible = true;
            lblResult.Text = "Invalid Date";
        }
        ArrayList list = GetWebinars(startdate);
        if (list.Count == 0)
        {
            HttpContext.Current.Session["DateList"] = null;
            bindGrid(false, "", txtSearch.Text);
            list = GetWebinars(startdate);

        }
        list.Insert(0, "All");
        DDListWebinars.DataSource = list;
        DDListWebinars.DataBind();
    }
    private void BindUpdateWebinars()
    {
        DateTime startdate = Convert.ToDateTime("05/18/2010");
        ArrayList list = GetWebinars(startdate); ;
        ddlistUpdateWebinar.DataSource = list;
        ddlistUpdateWebinar.DataBind();
    }

    protected void lbtnDetails_Click(object sender, EventArgs e)
    {
        ViewState["Mode"] = "Edit";
        lbToTSNOffice.Visible = true;
        lbToRegistration.Visible = true;
        BindUpdateWebinars();
        GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent;
        string email = row.Cells[2].Text.Trim();
        // call new function from to get data from SSSAdmin web services by email 
        if (email != "")
        {
            DataRow drData = mGetWebinarDataByEmail(email);
            if (drData != null)
            {
                lblResult.Text = "";
                txtid.Text = drData["id"].ToString();
                txtfname.Text = drData["fname"].ToString();
                txtlname.Text = drData["lname"].ToString();
                txtphone.Text = drData["phone"].ToString();
                txtemail.Text = drData["email"].ToString();
                txtcompany.Text = drData["company"].ToString();
                txtwebsite.Text = drData["website"].ToString();
                txtcomments.Text = drData["comments"].ToString();
                chBoxAttend.Checked = Convert.ToBoolean(drData["Attend"]);
                lblLocateUserTSNOffice.Visible = true;
                lblLocateUserRegistration.Visible = true;
                btnDelete.Visible = true;
                //txtWebinardata.Text = drData["Webinardata"].ToString();
                string Webinardata = drData["Webinardata"].ToString();
                ListItem item = ddlistUpdateWebinar.Items.FindByValue(Webinardata);
                if (item != null)
                {
                    ddlistUpdateWebinar.SelectedIndex = -1;
                    item.Selected = true;
                }

                string sCountry = drData["country"].ToString();
                ListItem cItem = ddCountries.Items.FindByValue(sCountry);
                if (cItem != null)
                {
                    ddCountries.SelectedIndex = -1;
                    item.Selected = true;
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
        //txtcountry.Text = "";
        //txtindustry.Text = "";
        //txtstructuralEngineers.Text = "";
        //txtlicenses.Text = "";
        //txtaboutELS.Text = "";
        //txtStructuralAnalysisSoftware.Text = "";
        txtcomments.Text = "";
        lblResult.Text = "";
        //txtWebinardata.Text = "";
        ViewState["Mode"] = "Add";
        btnDelete.Visible = false;
    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        // call mDeleteWebinarData(txtid.Text);
        ViewState["Mode"] = "Add";
    }
    protected void gvWebinar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    LinkButton l = (LinkButton)e.Row.FindControl("lbtnDelete");
        //    l.Attributes["onclick"] = "javascript:return confirm('You are about to delete the selected Member. continue...?')";
        //}

    }
    private bool mDeleteWebinarData(string id)
    {
        SSSData.SSSData sdata = new SSSData.SSSData();
        SSSData.AuthHeader ss = new SSSData.AuthHeader();
        sdata.Url = ViewState["WebinarsWSURL"].ToString();
        ss.Password = ViewState["WebinarsWSPassword"].ToString();
        ss.Username = ViewState["WebinarsWSUserName"].ToString();
        // must be deleted to work in USA // mglil
        //System.Net.IWebProxy proxy = new System.Net.WebProxy("http://ISA1:8080", true);
        //proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
        //sdata.Proxy = proxy;
        // 
        sdata.AuthHeaderValue = ss;
        bool result = sdata.DeleteWebinarReg(int.Parse(id));
        return result;
      }
     
    DataRow mGetWebinarDataByEmail(string vsEmail)
    {
        SSSData.SSSData sdata = new SSSData.SSSData();
        SSSData.AuthHeader ss = new SSSData.AuthHeader();
        sdata.Url = ViewState["WebinarsWSURL"].ToString();
        ss.Password = ViewState["WebinarsWSPassword"].ToString();
        ss.Username = ViewState["WebinarsWSUserName"].ToString();
        // must be deleted to work in USA // mglil
        //System.Net.IWebProxy proxy = new System.Net.WebProxy("http://ISA1:8080", true);
        //proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
        //sdata.Proxy = proxy;
        // 
        sdata.AuthHeaderValue = ss;
        DataTable dt = sdata.GetAllWebinarRegistrations();
        DataTable dFiltered = dt.Clone();
        DataRow[] dRowUpdates = dt.Select("email Like'%" + vsEmail + "%'");
        foreach (DataRow dr in dRowUpdates)
            dFiltered.ImportRow(dr);
        if (dFiltered.Rows.Count > 0)
            return dFiltered.Rows[0];
        else return null;
    }

    protected void lbToTSNOffice_Click(object sender, EventArgs e)
    {
        Response.Redirect("contacts.aspx?Email=" + txtemail.Text.Trim());
    }
    protected void lbToRegistration_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registration.aspx?Email=" + txtemail.Text.Trim());
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Validation())
        {
            if (ViewState["Mode"].ToString() == "Edit")
            {
                // call update webinar function
                mUpdateWebinarData(txtid.Text, txtfname.Text, txtlname.Text, txtphone.Text, txtemail.Text, txtcompany.Text, txtwebsite.Text, ddCountries.SelectedValue.ToString(),
                    " ", " ", " ", " ", " ", txtcomments.Text, ddlistUpdateWebinar.SelectedValue.ToString());
                mUpdateWebinarAttendance(txtemail.Text, chBoxAttend.Checked);
                lblResult.Text = "<font color='red'>Data has been saved.</font>";
                bindGrid(false, "");

            }
            else
            {
                //call update webinar function
                txtid.Enabled = false;
                mAddWebinarData(txtfname.Text, txtlname.Text, txtphone.Text, txtemail.Text, txtcompany.Text, txtwebsite.Text, ddCountries.SelectedValue.ToString(),
                    " ", " ", " ", " ", " ", txtcomments.Text, ddlistUpdateWebinar.SelectedValue.ToString());
                mUpdateWebinarAttendance(txtemail.Text, chBoxAttend.Checked);
                lblResult.Text = "<font color='red'>Data has been saved.</font>";
                bindGrid(false, "");
                mResetControls();
            }
            btnNew.Enabled = true;
        }
    }
    protected void imgbtnSignOut_Click(object sender, ImageClickEventArgs e)
    {
        HttpContext.Current.Session.Clear();
        HttpContext.Current.Response.Redirect("login.aspx");
    }
    private bool mUpdateWebinarData(string id, string firstname, string lastname, string phone, string email, string compnay, string website, string country, string industry, string structue, string license, string els, string analysis, string comment, string webinardata)
    {
        SSSData.SSSData sdata = new SSSData.SSSData();
        SSSData.AuthHeader ss = new SSSData.AuthHeader();
        sdata.Url = ViewState["WebinarsWSURL"].ToString();
        ss.Password = ViewState["WebinarsWSPassword"].ToString();
        ss.Username = ViewState["WebinarsWSUserName"].ToString();
        // must be deleted to work in USA // mglil
        //System.Net.IWebProxy proxy = new System.Net.WebProxy("http://ISA1:8080", true);
        //proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
        //sdata.Proxy = proxy;
        // 
        sdata.AuthHeaderValue = ss;
        bool result = sdata.UpdateWebinarReg(firstname, lastname, phone, email, compnay, website, country, webinardata, int.Parse(id), chBoxSend.Checked);
        return result;

    }
    private bool mUpdateWebinarAttendance(string email, bool attend)
    {
        SSSData.SSSData sdata = new SSSData.SSSData();
        SSSData.AuthHeader ss = new SSSData.AuthHeader();
        sdata.Url = ViewState["WebinarsWSURL"].ToString();
        ss.Password = ViewState["WebinarsWSPassword"].ToString();
        ss.Username = ViewState["WebinarsWSUserName"].ToString();
        // must be deleted to work in USA // mglil
        //System.Net.IWebProxy proxy = new System.Net.WebProxy("http://ISA1:8080", true);
        //proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
        //sdata.Proxy = proxy;
        // 
        sdata.AuthHeaderValue = ss;
        bool result = sdata.UpdateWebinarRegAttendance(email, attend);
        return result;
      }
    private bool mAddWebinarData(string firstname, string lastname, string phone, string email, string compnay, string website, string country, string industry, string structue, string license, string els, string analysis, string comment, string webinardata)
    {
        SSSData.SSSData sdata = new SSSData.SSSData();
        SSSData.AuthHeader ss = new SSSData.AuthHeader();
        sdata.Url = ViewState["WebinarsWSURL"].ToString();
        ss.Password = ViewState["WebinarsWSPassword"].ToString();
        ss.Username = ViewState["WebinarsWSUserName"].ToString();
        // must be deleted to work in USA // mglil
        //System.Net.IWebProxy proxy = new System.Net.WebProxy("http://ISA1:8080", true);
        //proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
        //sdata.Proxy = proxy;
        // 
        sdata.AuthHeaderValue = ss;
        bool result = sdata.AddWebinarReg(firstname, lastname, phone, email, compnay, website, country, webinardata, chBoxSend.Checked);
        return result;


    }
    protected void DDListWebinars_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["SelectedDate"] = DDListWebinars.SelectedValue.ToString();
        bindGrid(true, DDListWebinars.SelectedValue.ToString());
    }
    protected void gvWebinar_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvWebinar.PageIndex = e.NewPageIndex;
        bindGrid(true, DDListWebinars.SelectedValue.ToString());
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        ViewState["Mode"] = "Add";
        txtid.Text = "New ID";
        txtid.Enabled = false;
        BindUpdateWebinars();
        mResetControls();
        btnNew.Enabled = false;
        lbToTSNOffice.Visible = false;
        lbToRegistration.Visible = false;
        lblLocateUserTSNOffice.Visible = false;
        lblLocateUserRegistration.Visible = false;
        btnDelete.Visible = false;
        //DDListWebinars
        //ddlistUpdateWebinar
        ListItem item = ddlistUpdateWebinar.Items.FindByValue(DDListWebinars.SelectedValue.ToString());
        if (item != null)
        {
            ddlistUpdateWebinar.SelectedIndex = -1;
            item.Selected = true;
        }

    }
   
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ViewState["Mode"] = "Add";
        txtid.Text = "New ID";
        txtid.Enabled = false;
        BindUpdateWebinars();
        mResetControls();
        btnNew.Enabled = true;
        lbToTSNOffice.Visible = false;
        lbToRegistration.Visible = false;
    }

    protected void gvWebinar_Sorting(object sender, GridViewSortEventArgs e)
    {
        bindGrid(true, DDListWebinars.SelectedValue.ToString(), e.SortExpression, GetSortDirection(e.SortExpression));

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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        mResetControls();
        ListItem item = DDListWebinars.Items.FindByValue("All");
        if (item != null)
        {
            DDListWebinars.SelectedIndex = -1;
            item.Selected = true;
        }
        bindGrid(false, "", txtSearch.Text);
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        mDeleteWebinarData(txtid.Text);
        lblResult.Text = "<font color='red'>Data has been saved.</font>";
        mResetControls();
        Session["webinars"] = null;
        bindGrid(false, "");
    }
    protected void txtStartFrom_TextChanged(object sender, EventArgs e)
    {
        BindWebinars();
        ListItem item = DDListWebinars.Items.FindByValue("All");
        if (item != null)
        {
            DDListWebinars.SelectedIndex = -1;
            item.Selected = true;
        }
        bindGrid(false, "", txtSearch.Text);
    }
    public  ArrayList GetWebinars(DateTime StartDate)
    {
        if (HttpContext.Current.Session["DateList"] == null)
        {
            setWebinars(StartDate);
        }
        ArrayList DateListtemp = (ArrayList)HttpContext.Current.Session["DateList"];
        ArrayList DateList = new ArrayList();
        string dateStr = "";
        string dateStrOrg = "";
        DateTime datevl;

        for (int i = 0; i < DateListtemp.Count; i++)
        {
            dateStr = DateListtemp[i].ToString();
            dateStrOrg = dateStr;
            dateStr = dateStr.Replace("Tuesday,", "");
            dateStr = dateStr.Replace("Thursday,", "");
            dateStr = dateStr.Replace("@ 01:00 PM", "");
            dateStr = dateStr.Replace("@1:00 PM", "");
            dateStr = dateStr.Replace("@ 1:00 PM", "");
            if (dateStr.Trim().Length > 0)
            {
                datevl = Convert.ToDateTime(dateStr.Trim());
                if (datevl > StartDate)
                    DateList.Add(dateStrOrg);
            }
        }

        return DateList;

    }
    bool Validation()
    {
        bool Valid = true;
        if (txtemail.Text != "")
        {
            string EmailExp = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            if (!(System.Text.RegularExpressions.Regex.Match(txtemail.Text, EmailExp).Success))
            {
                lblEmailError.Text = "E-Mail address is not valid";
                lblEmailError.Visible = true;
                Valid = false;
            }
            else
            {
                lblEmailError.Text = "";
                lblEmailError.Visible = false;
               
            }
        }
        else
        {
            lblEmailError.Text = "";
            lblEmailError.Visible = false;
        }
        return Valid;
    }

    public  ArrayList getNewWebinars()
    {
        ArrayList DateList = new ArrayList();
        DateTime date1 = DateTime.Parse("04/12/2011");
        DateTime todayDate = System.DateTime.Now;
        //int no = DateTime.Compare(todayDate, date1);
        int no = todayDate.Subtract(date1).Days;
        int reminder = no / 14;
        date1 = date1.AddDays(14 + (reminder * 14));
        DateList.Add(string.Format("Tuesday, {0} @ 01:00 PM", date1.ToShortDateString()));
        DateList.Add(string.Format("Tuesday, {0} @ 01:00 PM", date1.AddDays(14).ToShortDateString()));
        DateList.Add(string.Format("Tuesday, {0} @ 01:00 PM", date1.AddDays(28).ToShortDateString()));
        return DateList;

    }

    public  void setWebinars(DateTime StartDate)
    {
        DateTime todayDate = StartDate;
        ArrayList DateList = new ArrayList();
        DataView dv = null;
        string dateStr;
        string dateStrorg;
        DateTime datevl;
        DataTable dtWS;
        DataTable dt = new DataTable();
        dt.Columns.Add("dateStr", typeof(string));
        dt.Columns.Add("dateDDT", typeof(DateTime));
        if (HttpContext.Current.Session["webinars"] != null)
        {
            dv = (DataView)HttpContext.Current.Session["webinars"];

        }
        else
        {
            SSSData.SSSData sdata = new SSSData.SSSData();
            SSSData.AuthHeader ss = new SSSData.AuthHeader();
            sdata.Url =   ViewState["WebinarsWSURL"].ToString();
            ss.Password = ViewState["WebinarsWSPassword"].ToString();
            ss.Username = ViewState["WebinarsWSUserName"].ToString();
            sdata.AuthHeaderValue = ss;
            dtWS = sdata.GetAllWebinarRegistrations();
            dv = dtWS.DefaultView;

        }

        dv.Sort = "Webinardata asc";

        for (int i = 0; i < dv.Table.Rows.Count; i++)
        {
            dateStr = dv.Table.Rows[i]["Webinardata"].ToString();
            dateStrorg = dateStr;
            dateStr = dateStr.Replace("Tuesday,", "");
            dateStr = dateStr.Replace("Thursday,", "");
            dateStr = dateStr.Replace("@ 01:00 PM", "");
            dateStr = dateStr.Replace("@1:00 PM", "");
            dateStr = dateStr.Replace("@ 1:00 PM", "");



            if (dateStr.Trim().Length > 0)
            {
                datevl = Convert.ToDateTime(dateStr.Trim());
                // if (datevl > StartDate)                     

                dt.Rows.Add(dateStrorg, datevl);





            }

        }




        dv = null;
        //dv= dt.DefaultView.ToTable(true, "dateStr").DefaultView;

        dv = dt.DefaultView;
        dv.Sort = "dateDDT";

        DataView dv2 = dv.ToTable(true, "dateStr").DefaultView;

        for (int y = 0; y < dv2.Table.Rows.Count; y++)
        {
            DateList.Add(dv2.Table.Rows[y][0].ToString());
        }

        HttpContext.Current.Session["DateList"] = DateList;
    }
    protected void ddlWebsitesWS_SelectedIndexChanged(object sender, EventArgs e)
    {
        // we will change this code to read from database according to selected site
        ViewState["WebinarsWSURL"] = ConfigurationManager.AppSettings["SSSData.SSSData"].ToString();
        ViewState["WebinarsWSUserName"] = ConfigurationManager.AppSettings["UserNameSSS"].ToString();
        ViewState["WebinarsWSPassword"] = ConfigurationManager.AppSettings["PasswordSSS"].ToString();
    }
}