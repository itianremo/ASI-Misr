using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


    public partial class index : Pharma.BMD.BLL.MasterClass
    {
        #region Page Load
       
        protected void Page_Load(object sender, EventArgs e)
        {

            InitiateTransactionsControl();
            if (!IsPostBack)
            {
                #region -------------------Graphics Handler--------------------
                imgbtnApply.Attributes.Add("onmouseover", "this.src='Images/Search_o.jpg'");
                imgbtnReset.Attributes.Add("onmouseover", "this.src='Images/Reset_o.jpg'");
                /////////////////////////////////////////////////////////////////////////////////////
                imgbtnApply.Attributes.Add("onmouseout", "this.src='Images/Search_n.jpg'");
                imgbtnReset.Attributes.Add("onmouseout", "this.src='Images/Reset_n.jpg'");
                /////////////////////////////////////////////////////////////////////////////////////
                #endregion
                //
                if (Session["SelectedFilter"] == null)
                {
                    Session["SelectedFilter"] = ddlSearchby.SelectedValue;
                }
                else
                {
                    ddlSearchby.SelectedValue = Session["SelectedFilter"].ToString();
                }
                ddlSearchby_SelectedIndexChanged(null, null);

                if (!CurrentUserInfo.IsAdminRank)
                    ddlSearchby.Items.Remove("Users");

                if (Session["ReturnMsg"] != null)
                {
                    lblReturnMsg.Text = Session["ReturnMsg"].ToString();
                    lblReturnMsg.Visible = true;
                    Session["ReturnMsg"] = null;
                }
            }
        }

        private void InitiateTransactionsControl()
        {
            
            TransButtons ucTransButtons = (TransButtons)Master.FindControl("ucTransButtons");
            ucTransButtons.CurrentPage = "SearchPage";
        }
        #endregion

        #region Bind Grid View For The First Time Only
        private void BindGrid()
        {
            btnApply_Click(null, null);
        }
        #endregion

        #region Comment
        //protected void gvPhysicians_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    //Retrieve the table from the ViewState object.
        //    DataTable dt = ViewState["dtMissingData"] as DataTable;
        //    if (dt != null)
        //    {
        //        //Sort the data.
        //        dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
        //        gvSearchResult.DataSource = ViewState["dtMissingData"];
        //        gvSearchResult.DataBind();
        //    }
        //}

        //protected void gvPhysicians_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    GridViewRow row = e.Row;
        //    if (row.RowType == DataControlRowType.DataRow)
        //    {
        //        bool PrivateClinic = Convert.ToBoolean(row.Cells[4].Text);

        //        if (PrivateClinic == true)
        //        {
        //            row.Cells[4].Text = "Yes";
        //        }
        //        else 
        //        {
        //            row.Cells[4].Text = "No";
        //        }
        //    }
        //}

        //protected void odcPhysicians_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        //{
        //    ViewState["dtMissingData"] = e.ReturnValue;
        //} 
        #endregion

        #region Main Search DropDownList Change Event
        protected void ddlSearchby_SelectedIndexChanged(object sender, EventArgs e)
        {
            HtmlTableRow row = (HtmlTableRow)tblFilters.FindControl(ddlSearchby.SelectedValue);
            ToggleRows(row);
            Session["SelectedFilter"] = ddlSearchby.SelectedValue;
            txtSearchName.Text = "";
            ViewState["SortDirection"] = null;
            ViewState["SortExpression"] = null;
            gvSearchResult.PageIndex = 0;
            btnApply_Click(null, null);
        }
        #endregion

        #region Toggles Search Controls For Different Search Criteria
        private void ToggleRows(HtmlTableRow shownRow)
        {
            Physicians.Visible = false;
            Products.Visible = false;
            MedicalAccounts.Visible = false;
            PrivateClinics.Visible = false;
            Pharmacies.Visible = false;
            Distributors.Visible = false;
            Users.Visible = false;
            shownRow.Visible = true;
        }
        #endregion

        #region Methods used by the auto complete control
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetCompletionList(string prefixText, int count, string contextKey)
        {
            string[] Names = new string[0];
            string ErrMsg = "";
            index currentPage = new index();
            string selectedFilter = currentPage.Session["SelectedFilter"].ToString();

            if (selectedFilter == "Physicians" || selectedFilter == "Pharmacies" || selectedFilter == "Products" || 
                selectedFilter == "MedicalAccounts" || selectedFilter == "PrivateClinics" ||
                selectedFilter == "Distributors" || selectedFilter == "Users")
            {
                Names = currentPage.GetAllEntitiesNamesByUser(selectedFilter, prefixText, out ErrMsg);
            }
            else
                Names = currentPage.GetAllEntitiesNames(selectedFilter, prefixText, out ErrMsg);
            return Names;
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetSecondaryCompletionList(string prefixText, int count, string contextKey)
        {
            string[] Names = new string[0];
            string ErrMsg = "";
            index currentPage = new index();
            string selectedFilter = "Physicians";
            Names = currentPage.GetAllEntitiesNamesByUser(selectedFilter, prefixText, out ErrMsg);
            return Names;
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetThirdCompletionList(string prefixText, int count, string contextKey)
        {
            string[] Names = new string[0];
            string ErrMsg = "";
            index currentPage = new index();
            string selectedFilter = "Pharmacists";
            Names = currentPage.GetAllEntitiesNamesByUser(selectedFilter, prefixText, out ErrMsg);
            return Names;
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetForthCompletionList(string prefixText, int count, string contextKey)
        {
            string[] Names = new string[0];
            string ErrMsg = "";
            index currentPage = new index();
            string selectedFilter = "EmployeesID";
            Names = currentPage.GetAllEntitiesNames(selectedFilter, prefixText, out ErrMsg);
            return Names;
        }
        #endregion

        #region Apply Search Click Event
        protected void btnApply_Click(object sender, ImageClickEventArgs e)
        {
            string SelectedFilter;
            if (Session["SelectedFilter"] != null)
            {
                SelectedFilter = Session["SelectedFilter"].ToString();
            }
            else 
            {
                SelectedFilter = ddlSearchby.SelectedValue;
            }
            switch (SelectedFilter)
            {
                case "Physicians":
                    gvSearchResult.DataSource = odsPhysicians;
                    gvSearchResult.DataBind();
                    break;
                case "Products":
                    gvSearchResult.DataSource = odsProducts;
                    gvSearchResult.DataBind();
                    break;
                case "MedicalAccounts":
                    gvSearchResult.DataSource = odsMedicalAccounts;
                    gvSearchResult.DataBind();
                    break;
                case "PrivateClinics":
                    gvSearchResult.DataSource = odsPrivateClinics;
                    gvSearchResult.DataBind();
                    break;
                case "Pharmacies":
                    gvSearchResult.DataSource = odsPharmacies;
                    gvSearchResult.DataBind();
                    break;
                case "Distributors":
                    gvSearchResult.DataSource = odsDistributers;
                    gvSearchResult.DataBind();
                    break;
                case "Users":
                    gvSearchResult.DataSource = odsUsers;
                    gvSearchResult.DataBind();
                    break;
            }
        }
        #endregion

        #region Search GridView Sorting Event
        protected void gvSearchResult_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt = ViewState["retrievedData"] as DataTable;
            if (dt != null)
            {
                DataView dv = new DataView(dt);
                dv.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                gvSearchResult.DataSource = dv;
                gvSearchResult.DataBind();
            }

        }

        #endregion

        #region Fetch Returned Data From Different Object Data Sources
        protected void odsPhysicians_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            ViewState["retrievedData"] = e.ReturnValue;
        }
        protected void odsUsers_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            ViewState["retrievedData"] = e.ReturnValue;
        }
        protected void odsDistributers_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            ViewState["retrievedData"] = e.ReturnValue;
        }
        protected void odsPrivateClinics_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            ViewState["retrievedData"] = e.ReturnValue;
        }
        protected void odsMedicalAccounts_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            ViewState["retrievedData"] = e.ReturnValue;
        }
        protected void odsProducts_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            ViewState["retrievedData"] = e.ReturnValue;
        }
        protected void odsPharmacies_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            ViewState["retrievedData"] = e.ReturnValue;
        }
        #endregion
        protected void ddlCity_DataBound(object sender, EventArgs e)
        {
            ListItem li = new ListItem("All", "-1");
            ddlCity.Items.Insert(0, li);
        }
        protected void ddlCityPC_DataBound(object sender, EventArgs e)
        {
            ListItem li = new ListItem("All", "-1");
            ddlCityPC.Items.Insert(0, li);
        }
        protected void ddlCityPharmacy_DataBound(object sender, EventArgs e)
        {
            ListItem li = new ListItem("All", "-1");
            ddlCityPharmacy.Items.Insert(0, li);
        }
        protected void gvSearchResult_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
                if (ddlSearchby.SelectedValue == "PrivateClinics")
                   e.Row.Cells[2].Visible = false;
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
                //Make the name of the first entity hyper link            
                HyperLink hpl1 = new HyperLink();
                hpl1.Text = e.Row.Cells[1].Text;
                e.Row.Cells[1].Controls.Add(hpl1);

                switch (ddlSearchby.SelectedValue)
                {
                    case "Physicians":
                        hpl1.NavigateUrl = "Physicians.aspx?" + "data=" + mEncryptQueryString("&ID=" + e.Row.Cells[0].Text);
                        break;
                    case "Products":
                        hpl1.NavigateUrl = "Products.aspx?" + "data=" + mEncryptQueryString("&ID=" + e.Row.Cells[0].Text);
                        break;
                    case "MedicalAccounts":
                        hpl1.NavigateUrl = "MedicalAccounts.aspx?" + "data=" + mEncryptQueryString("&ID=" + e.Row.Cells[0].Text);
                        break;
                    case "PrivateClinics":
                        hpl1.NavigateUrl = "PrivateClinics.aspx?" + "data=" + mEncryptQueryString("&ID=" + e.Row.Cells[0].Text);
                        //Make the name of the second entity hyper link
                        HyperLink hpl2 = new HyperLink();
                        hpl2.Text = e.Row.Cells[3].Text;
                        hpl2.NavigateUrl = "Physicians.aspx?" + "data=" + mEncryptQueryString("&ID=" + e.Row.Cells[2].Text);
                        e.Row.Cells[3].Controls.Add(hpl2);
                        e.Row.Cells[2].Visible = false;
                        break;
                    case "Pharmacies":
                        hpl1.NavigateUrl = "Pharmacies.aspx?" + "data=" + mEncryptQueryString("&ID=" + e.Row.Cells[0].Text);
                        break;
                    case "Distributors":
                        e.Row.Cells[1].Width = 700;
                        hpl1.NavigateUrl = "Distributors.aspx?" + "data=" + mEncryptQueryString("&ID=" + e.Row.Cells[0].Text);
                        break;
                    case "Users":
                        hpl1.NavigateUrl = "BMDUsers.aspx?" + "data=" + mEncryptQueryString("&ID=" + e.Row.Cells[0].Text);
                        break;
                }
            }
        }
        protected void imgbtnReset_Click(object sender, ImageClickEventArgs e)
        {
            resetSearchControl();
        }
        private void resetSearchControl()
        {
            ddlTitile.SelectedIndex = -1;
            ddlSpeciality.SelectedIndex = -1;
            ddlScoreRange.SelectedIndex = -1;
            ddlForm.SelectedIndex = -1;
            ddlSubOrdination.SelectedIndex = -1;
            ddlGov.SelectedIndex = -1;
            ddlCity.SelectedIndex = -1;
            ddlBrick.SelectedIndex = -1;
            ddlGovPC.SelectedIndex = -1;
            ddlCityPC.SelectedIndex = -1;
            ddlBrickPC.SelectedIndex = -1;
            ddlGovPharmacy.SelectedIndex = -1;
            ddlCityPharmacy.SelectedIndex = -1;
            ddlBrickPharmacy.SelectedIndex = -1;
            ddlEmpTitles.SelectedIndex = -1;
            ddlBrickUser.SelectedIndex = -1;
            //
            txtSearchName.Text = "";
            txtAKA.Text = "";
            txtPhysicianPC.Text = "";
            txtPharmacistPharmacy.Text = "";
            txtEmployeeID.Text = "";
            txtBranches.Text = "";
            txtNatID.Text = "";
            //
            rblOwnsClinic.SelectedIndex = 0;
            btnApply_Click(null, null);
        }
        protected void gvSearchResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSearchResult.PageIndex = e.NewPageIndex;
            btnApply_Click(null, null);
        }

        protected void ddlGovPC_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCityPC.SelectedIndex = -1;
            btnApply_Click(null, null);
        }
        protected void ddlCityPC_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnApply_Click(null, null);
        }
        protected void ddlGov_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCity.SelectedIndex = -1;
            btnApply_Click(null, null);
        }
        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnApply_Click(null, null);
        }
        protected void ddlGovPharmacy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCityPharmacy.SelectedIndex = -1;
            btnApply_Click(null, null);
        }
}
