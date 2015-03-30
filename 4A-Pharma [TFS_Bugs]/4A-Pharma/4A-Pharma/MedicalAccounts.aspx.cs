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
using Pharma.BMD.BLL;

public partial class MedicalAccounts : Pharma.BMD.BLL.MedicalAccountsBLL
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Master.ToString() != "ASP.blankmasterpage_master")
        {
            InitiateEventsHandlers();
        }
        else
        {
            frmViewMedicalAccounts.PagerSettings.Visible = false;
        }

        if (!IsPostBack)
        {
            //Get the page that contains the MedicalAccountID passed in the query string
            if (!String.IsNullOrEmpty(CurrentQueryStringsValues.ID))
            {
                int ID = 0;
                int.TryParse(CurrentQueryStringsValues.ID, out ID);
                frmViewMedicalAccounts.PageIndex = GetCertainPageByID(ID, !String.IsNullOrEmpty(CurrentQueryStringsValues.TransType));
                BindMedicalAccountsView(!String.IsNullOrEmpty(CurrentQueryStringsValues.TransType));
            }
            else
            {
                BindMedicalAccountsView(false);
            }

            if (frmViewMedicalAccounts.DataItemCount > 0)
            {
                bool ShowAll = false;
                if (!String.IsNullOrEmpty(CurrentQueryStringsValues.TransType))
                {
                    if (CurrentQueryStringsValues.TransType == "Update" || CurrentQueryStringsValues.TransType == "Add") 
                    {
                        ShowAll = true;
                    }
                }
                BindgvPharmacies(ShowAll);
                BindProductsFeedback(int.Parse(((DropDownList)(frmViewMedicalAccounts.FindControl("ddlProductsList"))).SelectedValue), ShowAll);
                AdjustReadOnlyFormStatus(true);
                AdjustDropDownListsSelection();
            }
            else
            {
                lblNoDataMsg.Text = "No Medical Accounts found in your bricks.";
                HandleIfBlankFormView();
            }
        }
    }

    #endregion

    #region FormView Handler

    private void HandleIfBlankFormView()
    {
        ViewState["SaveMode"] = "Add";
        AdjustReadOnlyFormStatus(false);
        ResetFormtxtboxes();
        ResetProductFeedbackControls();
        (((DropDownList)(frmViewMedicalAccounts.FindControl("ddlProductsList")))).Enabled = false;
        TransButtons ucTransButtons = (TransButtons)Master.FindControl("ucTransButtons");
        ((ImageButton)ucTransButtons.FindControl("btnSave")).Visible = true;
        ((ImageButton)ucTransButtons.FindControl("btnCancel")).Visible = false;
        ((ImageButton)ucTransButtons.FindControl("btnAdd")).Visible = false;
        ((ImageButton)ucTransButtons.FindControl("btnEdit")).Visible = false;
        ((ImageButton)ucTransButtons.FindControl("btnDelete")).Visible = false;
    }


    private void BindMedicalAccountsView(bool ShowAll)
    {
        Session["ShowAll"] = ShowAll;
        frmViewMedicalAccounts.DataSource = odsMedicalAccounts;
        frmViewMedicalAccounts.DataBind();
    }

    protected void frmViewMedicalAccounts_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {
        frmViewMedicalAccounts.PageIndex = e.NewPageIndex;
        BindMedicalAccountsView(false);
        BindgvPharmacies(false);
        BindProductsFeedback(int.Parse(ViewState["SelectedProductFeedBackID"].ToString()), false);
        AdjustDropDownListsSelection();
        AdjustTransButtons(false);
        lblmsg.Visible = false;
    }

    protected void frmViewMedicalAccounts_DataBound(object sender, EventArgs e)
    {
        if (this.Master.ToString() == "ASP.blankmasterpage_master")
        {
            ((TextBox)frmViewMedicalAccounts.FindControl("txtSearchName")).Enabled = false;
            ((Label)frmViewMedicalAccounts.FindControl("lblSearch")).Enabled = false;
            ((DropDownList)frmViewMedicalAccounts.FindControl("ddlProductsList")).Enabled = false;
        }
    }

    #endregion

    #region Grids Handler

    private void BindgvPharmacies(bool ShowAll)
    {
        if (CurrentQueryStringsValues.TransType == "Update")
        {
            ViewState["GetRxPharmacies"] = GetPharmaciesBelongToMedicalAccount(int.Parse(CurrentQueryStringsValues.oldRefID), ShowAll);
        }
        else
        {
            ViewState["GetRxPharmacies"] = GetPharmaciesBelongToMedicalAccount(int.Parse(frmViewMedicalAccounts.DataKey["MedicalAccountID"].ToString()), ShowAll);
        }
        ((GridView)(frmViewMedicalAccounts.FindControl("gvPharmacies"))).DataSource = ViewState["GetRxPharmacies"];
        ((GridView)(frmViewMedicalAccounts.FindControl("gvPharmacies"))).DataBind();
    }

    protected void gvMedicalAccounts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (((CheckBox)e.Row.FindControl("cbxSelectMedicalAcc")).Checked)
            {
                e.Row.BackColor = System.Drawing.Color.LightBlue;
            }
        }
    }

    protected void gvPhyscians_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (((CheckBox)e.Row.FindControl("cbxSelectPhyscians")).Checked)
            {
                e.Row.BackColor = System.Drawing.Color.LightBlue;
            }
        }
    }

    protected void gvDistributors_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (((CheckBox)e.Row.FindControl("cbxSelectDistributor")).Checked)
            {
                e.Row.BackColor = System.Drawing.Color.LightBlue;
            }
        }
    }

    protected void gvPharmacies_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (((CheckBox)e.Row.FindControl("cbxSelectPharmacy")).Checked)
            {
                e.Row.CssClass = "GridhighlightedRowsStyle";
            }
        }
    }

    private void SaveChangedValues(int MedicalAccountID, DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            Pharma.BMD.BLL.PharmaciesBLL objPharmaciesBLL = new PharmaciesBLL();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int ID = int.Parse(dt.Rows[i]["CurrentID"].ToString());
                bool Status = bool.Parse(dt.Rows[i]["CurrentcbxStatus"].ToString());

                if (Status)
                {
                    objPharmaciesBLL.AssignPharmacyToMedicalAccount(ID, MedicalAccountID);

                }
                else
                {
                    objPharmaciesBLL.UnAssignPharmacyToMedicalAccount(ID, MedicalAccountID);
                }

            }
        }
    }

    private DataTable GetChangedValues(string SaveMode, DataTable dtOriginalData, string OrgColumnName, GridView GridViewName, string CheckBoxName, int CheckBoxNameCellLocation)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("CurrentID"));
        dt.Columns.Add(new DataColumn("CurrentcbxStatus"));
        switch (SaveMode)
        {
            case "Add":
                for (int i = 0; i < GridViewName.Rows.Count; i++)
                {
                    if (GridViewName.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        int CurrentID = int.Parse(GridViewName.DataKeys[i].Values[0].ToString());
                        bool CurrentcbxStatus = ((CheckBox)(GridViewName.Rows[i].Cells[CheckBoxNameCellLocation].FindControl(CheckBoxName))).Checked;
                        if (CurrentcbxStatus)
                        {
                            DataRow row = dt.NewRow();
                            row["CurrentID"] = CurrentID.ToString();
                            row["CurrentcbxStatus"] = CurrentcbxStatus.ToString();
                            dt.Rows.Add(row);
                        }
                    }
                }
                break;


            case "Edit":
                for (int i = 0; i < GridViewName.Rows.Count; i++)
                {
                    if (GridViewName.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        int CurrentID = int.Parse(GridViewName.DataKeys[i].Values[0].ToString());
                        int OriginalID = int.Parse(dtOriginalData.Rows[i][1].ToString());
                        if (CurrentID == OriginalID)
                        {
                            bool CurrentcbxStatus = ((CheckBox)(GridViewName.Rows[i].Cells[CheckBoxNameCellLocation].FindControl(CheckBoxName))).Checked;
                            bool OriginalStatus = bool.Parse(dtOriginalData.Rows[i][OrgColumnName].ToString());
                            if (CurrentcbxStatus != OriginalStatus)
                            {
                                DataRow row = dt.NewRow();
                                row["CurrentID"] = CurrentID.ToString();
                                row["CurrentcbxStatus"] = CurrentcbxStatus.ToString();
                                dt.Rows.Add(row);
                            }
                        }
                    }
                }
                break;
        }
        return dt;
    }

    #endregion

    #region Buttons Transactions Events

    private void InitiateEventsHandlers()
    {
        TransButtons ucTransButtons = (TransButtons)Master.FindControl("ucTransButtons");
        ucTransButtons.btnAddEvent += new EventHandler(ucTransButtons_btnAddEvent);
        ucTransButtons.btnEditEvent += new EventHandler(ucTransButtons_btnEditEvent);
        ucTransButtons.btnCancelEvent += new EventHandler(ucTransButtons_btnCancelEvent);
        ucTransButtons.btnSaveEvent += new EventHandler(ucTransButtons_btnSaveEvent);
        ucTransButtons.btnDeleteEvent += new EventHandler(ucTransButtons_btnDeleteEvent);

    }

    protected void ucTransButtons_btnEditEvent(object sender, EventArgs e)
    {
        lblDupName.Visible = false;
        lblmsg.Text = "";
        ViewState["SaveMode"] = "Edit";
        AdjustReadOnlyFormStatus(false);
        AdjustTransButtons(true);
        EnableGridview(((GridView)(frmViewMedicalAccounts.FindControl("gvPharmacies"))), true, false, false);
    }

    protected void ucTransButtons_btnAddEvent(object sender, EventArgs e)
    {
        lblDupName.Visible = false;
        lblmsg.Text = "";
        ViewState["SaveMode"] = "Add";
        AdjustReadOnlyFormStatus(false);
        AdjustTransButtons(true);
        ResetFormtxtboxes();
        ResetProductFeedbackControls();
        ((DropDownList)(frmViewMedicalAccounts.FindControl("ddlProductsList"))).Enabled = false;
        EnableGridview(((GridView)(frmViewMedicalAccounts.FindControl("gvPharmacies"))), true, false, true);
    }

    protected void ucTransButtons_btnSaveEvent(object sender, EventArgs e)
    {
        lblDupName.Visible = false;
        lblmsg.Text = "";
        string txtName = ((TextBox)frmViewMedicalAccounts.FindControl("txtName")).Text;
        string txtArea = ((TextBox)frmViewMedicalAccounts.FindControl("txtArea")).Text;
        string txtAddress = ((TextBox)frmViewMedicalAccounts.FindControl("txtAddress")).Text;
        string txtPhone1 = ((TextBox)frmViewMedicalAccounts.FindControl("txtPhone1")).Text;
        string txtMobile = ((TextBox)frmViewMedicalAccounts.FindControl("txtMobile")).Text;
        string txtPostalCode = ((TextBox)frmViewMedicalAccounts.FindControl("txtPostalCode")).Text;
        //---------------------------------
        decimal RXFinancialLimits = decimal.Parse(((TextBox)frmViewMedicalAccounts.FindControl("txtRXFinancialLimits")).Text);
        decimal RXFinancialLimitsMonthly = decimal.Parse(((TextBox)frmViewMedicalAccounts.FindControl("txtRXFinancialLimitsMonthly")).Text);
        decimal RXFinancialLimitsAnnual = decimal.Parse(((TextBox)frmViewMedicalAccounts.FindControl("txtRXFinancialLimitsAnnual")).Text);
        //---------------------------------
        int TotalGenRXDay = int.Parse(((TextBox)frmViewMedicalAccounts.FindControl("txtTotalGenRXDay")).Text);
        int TotalGenRXWeek = int.Parse(((TextBox)frmViewMedicalAccounts.FindControl("txtTotalGenRXWeek")).Text);
        int TotalGenRXMonth = int.Parse(((TextBox)frmViewMedicalAccounts.FindControl("txtTotalGenRXMonth")).Text);
        //---------------------------------
        bool cbxInternalPharmacy = ((CheckBox)frmViewMedicalAccounts.FindControl("cbxInternalPharmacy")).Checked;
        bool cbxExternalPharmacy = ((CheckBox)frmViewMedicalAccounts.FindControl("cbxExternalPharmacy")).Checked;
        bool cbxDirectOrders = ((CheckBox)frmViewMedicalAccounts.FindControl("cbxDirectOrders")).Checked;
        bool cbxTender = ((CheckBox)frmViewMedicalAccounts.FindControl("cbxTender")).Checked;
        //---------------------------------
        int NoOfServedPts = int.Parse(((TextBox)frmViewMedicalAccounts.FindControl("txtNoOfServed")).Text);
        int ICUID = int.Parse(((TextBox)frmViewMedicalAccounts.FindControl("txtICU")).Text);
        int GovID = int.Parse(((DropDownList)frmViewMedicalAccounts.FindControl("ddlGov")).SelectedValue);
        int CityID = int.Parse(((DropDownList)frmViewMedicalAccounts.FindControl("ddlCity")).SelectedValue);
        int BrickID = int.Parse(((DropDownList)frmViewMedicalAccounts.FindControl("ddlBrick")).SelectedValue);
        int SubordinationID = int.Parse(((DropDownList)frmViewMedicalAccounts.FindControl("ddlSubordination")).SelectedValue);
        //---------------------------------

        if (ViewState["SaveMode"].ToString() == "Add")
        {
            if (!IsMedicalAccountNameExist(txtName))
            {
                int NewMedicalAccountID = 0;
                int Result = AddMedicalAccount(txtName, BrickID, SubordinationID, GovID, CityID, txtArea, txtAddress, txtPhone1, txtMobile, txtPostalCode, ICUID, NoOfServedPts, RXFinancialLimits, RXFinancialLimitsMonthly, RXFinancialLimitsAnnual, cbxInternalPharmacy, cbxExternalPharmacy, cbxDirectOrders, cbxTender, TotalGenRXDay, TotalGenRXWeek, TotalGenRXMonth, out NewMedicalAccountID);
                if (Result == 0)
                {
                    // Error // Failed to perform this operation
                    lblmsg.Text = "Failed to perform this operation.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    lblmsg.Visible = true;
                    goto EndSaveTrans;
                }
                else if (Result == 1)
                {
                    // Save the Rest of tansactions 
                    SaveChangedValues(NewMedicalAccountID, GetChangedValues("Add", ((DataTable)ViewState["GetRxPharmacies"]), "Selected", ((GridView)(frmViewMedicalAccounts.FindControl("gvPharmacies"))), "cbxSelectPharmacy", 1));
                    SaveProductFeedBack(NewMedicalAccountID);
                    //// Reload Data //
                    frmViewMedicalAccounts.PageIndex = GetCertainPageByID(NewMedicalAccountID, false);
                    BindMedicalAccountsView(false);
                    if (frmViewMedicalAccounts.DataItemCount > 0)
                    {
                        BindgvPharmacies(false);
                        BindProductsFeedback(int.Parse(ViewState["SelectedProductFeedBackID"].ToString()), false);
                    }
                }
                else if (Result == 2)
                {
                    // Request to Save the Rest of tansactions //
                    SaveChangedValues(NewMedicalAccountID, GetChangedValues("Add", ((DataTable)ViewState["GetRxPharmacies"]), "Selected", ((GridView)(frmViewMedicalAccounts.FindControl("gvPharmacies"))), "cbxSelectPharmacy", 1));
                    SaveProductFeedBack(NewMedicalAccountID);
                    //// Reload Data //
                    frmViewMedicalAccounts.PageIndex = GetCertainPageByID(NewMedicalAccountID, false);
                    BindMedicalAccountsView(false);
                    if (frmViewMedicalAccounts.DataItemCount > 0)
                    {
                        BindgvPharmacies(false);
                        BindProductsFeedback(int.Parse(ViewState["SelectedProductFeedBackID"].ToString()), false);
                    }
                    // Show Confirm pending request msg //
                    lblmsg.Text = "Your request for adding new Medical Account is in pending phase until acceptance from your manager";
                    lblmsg.Visible = true;
                }
                if (frmViewMedicalAccounts.DataItemCount > 0)
                {
                    lblDupName.Visible = false;
                }
            }
            else
            {
                lblDupName.Visible = true;
                return;
            }
        }
        //-----------------------------------
        else if (ViewState["SaveMode"].ToString() == "Edit")
        {
            int MedicalAccountID = (int.Parse(frmViewMedicalAccounts.DataKey["MedicalAccountID"].ToString()));
            if (!IsUpdatedMedicalAccountNameExist(MedicalAccountID, txtName))
            {
                string Msg = "";
                int result = UpdateMedicalAccount(MedicalAccountID, txtName, BrickID, SubordinationID, GovID, CityID, txtArea, txtAddress, txtPhone1, txtMobile, txtPostalCode, ICUID, NoOfServedPts, RXFinancialLimits, RXFinancialLimitsMonthly, RXFinancialLimitsAnnual, cbxInternalPharmacy, cbxExternalPharmacy, cbxDirectOrders, cbxTender, TotalGenRXDay, TotalGenRXWeek, TotalGenRXMonth, out Msg);
                if (result == 0)
                {
                    // Failed Request
                    lblmsg.Text = (Msg.Length > 0) ? Msg : "Failed to Edit";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    lblmsg.Visible = true;
                    goto EndSaveTrans;
                }
                else if (result == 1)
                {
                    SaveChangedValues(MedicalAccountID, GetChangedValues("Edit", ((DataTable)ViewState["GetRxPharmacies"]), "Selected", ((GridView)(frmViewMedicalAccounts.FindControl("gvPharmacies"))), "cbxSelectPharmacy", 1));
                    SaveProductFeedBack(MedicalAccountID);
                    // Reload Data //
                    frmViewMedicalAccounts.PageIndex = GetCertainPageByID(MedicalAccountID, false);
                    BindMedicalAccountsView(false);
                    BindgvPharmacies(false);
                    BindProductsFeedback(int.Parse(ViewState["SelectedProductFeedBackID"].ToString()), false);
                }
                else if (result == 2)
                {
                    // Pending Request
                    SaveChangedValues(MedicalAccountID, GetChangedValues("Edit", ((DataTable)ViewState["GetRxPharmacies"]), "Selected", ((GridView)(frmViewMedicalAccounts.FindControl("gvPharmacies"))), "cbxSelectPharmacy", 1));
                    SaveProductFeedBack(MedicalAccountID);
                    // Reload Data //
                    frmViewMedicalAccounts.PageIndex = GetCertainPageByID(MedicalAccountID, false);
                    BindMedicalAccountsView(false);
                    BindgvPharmacies(false);
                    BindProductsFeedback(int.Parse(ViewState["SelectedProductFeedBackID"].ToString()), false);
                    // Show pending msg
                    lblmsg.Text = "Your request for updating Medical Account is in pending phase until acceptance from your manager";
                    lblmsg.Visible = true;
                }
                lblDupName.Visible = false;
            }
            else
            {
                lblDupName.Visible = true;
                return;
            }
        }
    //
    EndSaveTrans:
        if (frmViewMedicalAccounts.DataItemCount > 0)
        {
            AdjustDropDownListsSelection();
            AdjustTransButtons(false);
            AdjustReadOnlyFormStatus(true);
        }
        else
        {
            HandleIfBlankFormView();
        }

    }

    protected void ucTransButtons_btnCancelEvent(object sender, EventArgs e)
    {
        lblDupName.Visible = false;
        lblmsg.Text = "";
        BindMedicalAccountsView(false);
        BindgvPharmacies(false);
        BindProductsFeedback(int.Parse(ViewState["SelectedProductFeedBackID"].ToString()), false);
        AdjustReadOnlyFormStatus(true);
        AdjustDropDownListsSelection();
        AdjustTransButtons(false);
    }

    protected void ucTransButtons_btnDeleteEvent(object sender, EventArgs e)
    {
        lblDupName.Visible = false;
        lblmsg.Text = "";
        int MedicalAccountID = (int.Parse(frmViewMedicalAccounts.DataKey["MedicalAccountID"].ToString()));
        int result = DeleteMedicalAccount(MedicalAccountID);
        if (result == 0)
        {
            // Failed
            lblmsg.Text = "Failed to delete";
            lblmsg.ForeColor = System.Drawing.Color.Red;
            lblmsg.Visible = true;

        }
        else if (result == 1)
        {
            // Direct Delete //
            //// Reload Data after record is deleted//
            if (frmViewMedicalAccounts.PageIndex > 1)
                frmViewMedicalAccounts.PageIndex--;
            BindMedicalAccountsView(false);
            BindgvPharmacies(false);
            BindProductsFeedback(int.Parse(ViewState["SelectedProductFeedBackID"].ToString()), false);
            AdjustReadOnlyFormStatus(true);
            AdjustDropDownListsSelection();
            AdjustTransButtons(false);
        }
        else
        {
            // Delete Requested // Pending Request
            lblmsg.Text = "Your request for Delete Medical Account is in Pending phase until Acceptance from your Manager";
            lblmsg.Visible = true;
        }
    }

    #endregion

    #region Page Controls Handler

    private void AdjustDropDownListsSelection()
    {
        ((DropDownList)frmViewMedicalAccounts.FindControl("ddlBrick")).SelectedValue = ((TextBox)frmViewMedicalAccounts.FindControl("txtBrickID")).Text;
        ((DropDownList)frmViewMedicalAccounts.FindControl("ddlGov")).SelectedValue = ((TextBox)frmViewMedicalAccounts.FindControl("txtGov")).Text;
        ((DropDownList)frmViewMedicalAccounts.FindControl("ddlCity")).SelectedValue = ((TextBox)frmViewMedicalAccounts.FindControl("txtCity")).Text;
        ((DropDownList)frmViewMedicalAccounts.FindControl("ddlSubordination")).SelectedValue = ((TextBox)frmViewMedicalAccounts.FindControl("txtSubordination")).Text;
    }

    protected void ddlGov_SelectedIndexChanged(object sender, EventArgs e)
    {
        LookupsBLL objLookupsBLL = new LookupsBLL();
        ((TextBox)(frmViewMedicalAccounts.FindControl("txtGov"))).Text = ((DropDownList)(frmViewMedicalAccounts.FindControl("ddlGov"))).SelectedValue;
        ((DropDownList)(frmViewMedicalAccounts.FindControl("ddlCity"))).DataSource = objLookupsBLL.GetCitiesByGov(int.Parse(((DropDownList)(frmViewMedicalAccounts.FindControl("ddlGov"))).SelectedValue));
        ((DropDownList)(frmViewMedicalAccounts.FindControl("ddlCity"))).DataBind();
    }

    protected void ddlGov_DataBound(object sender, EventArgs e)
    {
        LookupsBLL objLookupsBLL = new LookupsBLL();
        ((DropDownList)(frmViewMedicalAccounts.FindControl("ddlCity"))).DataSource = objLookupsBLL.GetCitiesByGov(int.Parse(((DropDownList)(frmViewMedicalAccounts.FindControl("ddlGov"))).SelectedValue));
        ((DropDownList)(frmViewMedicalAccounts.FindControl("ddlCity"))).DataBind();

    }

    private void AdjustTransButtons(bool Flag)
    {
        TransButtons ucTransButtons = (TransButtons)Master.FindControl("ucTransButtons");
        ((ImageButton)ucTransButtons.FindControl("btnCancel")).Visible = Flag;
        ((ImageButton)ucTransButtons.FindControl("btnSave")).Visible = Flag;
        ((ImageButton)ucTransButtons.FindControl("btnAdd")).Visible = !Flag;
        ((ImageButton)ucTransButtons.FindControl("btnEdit")).Visible = !Flag;
    }

    private void EnableGridview(GridView GridviewName, bool Flag, bool Reset, bool NewEntry)
    {
        foreach (GridViewRow row in GridviewName.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                ((CheckBox)row.Cells[1].Controls[1]).Enabled = Flag;
                if (Reset)
                {
                    ((CheckBox)row.Cells[1].Controls[1]).Checked = Reset;
                }
                if (NewEntry)
                {
                    row.BackColor = System.Drawing.Color.Transparent;
                    ((CheckBox)row.Cells[1].Controls[1]).Checked = Reset;
                }
            }
        }

    }

    private void ResetFormtxtboxes()
    {
        ((TextBox)frmViewMedicalAccounts.FindControl("txtName")).Text = "";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtGov")).Text = "";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtCity")).Text = "";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtArea")).Text = "";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtAddress")).Text = "";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtBrickID")).Text = "";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtPhone1")).Text = "";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtICU")).Text = "0";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtMobile")).Text = "";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtPostalCode")).Text = "";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtNoOfServed")).Text = "0";
        //---------------------------------
        ((TextBox)frmViewMedicalAccounts.FindControl("txtRXFinancialLimits")).Text = "0";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtRXFinancialLimitsMonthly")).Text = "0";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtRXFinancialLimitsAnnual")).Text = "0";
        //---------------------------------
        ((TextBox)frmViewMedicalAccounts.FindControl("txtTotalGenRXDay")).Text = "0";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtTotalGenRXWeek")).Text = "0";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtTotalGenRXMonth")).Text = "0";
        //--Product FeedBack --------------
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupTotalRXDay")).Text = "0";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupTotalRXWeek")).Text = "0";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupTotalRXMonth")).Text = "0";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupCompRXDay")).Text = "0";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupCompRXWeek")).Text = "0";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupCompRXMonth")).Text = "0";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductTotalRXAvgDay")).Text = "0";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductTotalRXAvgWeek")).Text = "0";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductTotalRXAvgMonth")).Text = "0";
        //---------------------------------
        ((CheckBox)frmViewMedicalAccounts.FindControl("cbxInternalPharmacy")).Enabled = true;
        ((CheckBox)frmViewMedicalAccounts.FindControl("cbxInternalPharmacy")).Checked = false;
        //
        ((CheckBox)frmViewMedicalAccounts.FindControl("cbxExternalPharmacy")).Enabled = true;
        ((CheckBox)frmViewMedicalAccounts.FindControl("cbxExternalPharmacy")).Checked = false;
        //
        ((CheckBox)frmViewMedicalAccounts.FindControl("cbxDirectOrders")).Enabled = true;
        ((CheckBox)frmViewMedicalAccounts.FindControl("cbxDirectOrders")).Checked = false;
        //
        ((CheckBox)frmViewMedicalAccounts.FindControl("cbxTender")).Enabled = true;
        ((CheckBox)frmViewMedicalAccounts.FindControl("cbxTender")).Checked = false;
        //

    }

    protected void AdjustReadOnlyFormStatus(bool Flag)
    {
        ((TextBox)frmViewMedicalAccounts.FindControl("txtName")).ReadOnly = Flag;
        ((TextBox)frmViewMedicalAccounts.FindControl("txtGov")).ReadOnly = Flag;
        ((TextBox)frmViewMedicalAccounts.FindControl("txtCity")).ReadOnly = Flag;
        ((TextBox)frmViewMedicalAccounts.FindControl("txtArea")).ReadOnly = Flag;
        ((TextBox)frmViewMedicalAccounts.FindControl("txtAddress")).ReadOnly = Flag;
        ((TextBox)frmViewMedicalAccounts.FindControl("txtBrickID")).ReadOnly = Flag;
        ((TextBox)frmViewMedicalAccounts.FindControl("txtPhone1")).ReadOnly = Flag;
        ((TextBox)frmViewMedicalAccounts.FindControl("txtICU")).ReadOnly = Flag;
        ((TextBox)frmViewMedicalAccounts.FindControl("txtMobile")).ReadOnly = Flag;
        ((TextBox)frmViewMedicalAccounts.FindControl("txtPostalCode")).ReadOnly = Flag;
        ((TextBox)frmViewMedicalAccounts.FindControl("txtNoOfServed")).ReadOnly = Flag;
        //
        //---------------------------------
        ((TextBox)frmViewMedicalAccounts.FindControl("txtRXFinancialLimits")).ReadOnly = Flag;
        ((TextBox)frmViewMedicalAccounts.FindControl("txtRXFinancialLimitsMonthly")).ReadOnly = Flag;
        ((TextBox)frmViewMedicalAccounts.FindControl("txtRXFinancialLimitsAnnual")).ReadOnly = Flag;
        //---------------------------------
        ((TextBox)frmViewMedicalAccounts.FindControl("txtTotalGenRXDay")).ReadOnly = Flag;
        ((TextBox)frmViewMedicalAccounts.FindControl("txtTotalGenRXWeek")).ReadOnly = Flag;
        ((TextBox)frmViewMedicalAccounts.FindControl("txtTotalGenRXMonth")).ReadOnly = Flag;
        // Product FeedBack
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupTotalRXDay")).ReadOnly = Flag;
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupTotalRXWeek")).ReadOnly = Flag;
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupTotalRXMonth")).ReadOnly = Flag;
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupCompRXDay")).ReadOnly = Flag;
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupCompRXWeek")).ReadOnly = Flag;
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupCompRXMonth")).ReadOnly = Flag;
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductTotalRXAvgDay")).ReadOnly = Flag;
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductTotalRXAvgWeek")).ReadOnly = Flag;
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductTotalRXAvgMonth")).ReadOnly = Flag;
        //
        //---------------------------------
        ((CheckBox)frmViewMedicalAccounts.FindControl("cbxInternalPharmacy")).Enabled = !Flag;
        ((CheckBox)frmViewMedicalAccounts.FindControl("cbxExternalPharmacy")).Enabled = !Flag;
        ((CheckBox)frmViewMedicalAccounts.FindControl("cbxDirectOrders")).Enabled = !Flag;
        ((CheckBox)frmViewMedicalAccounts.FindControl("cbxTender")).Enabled = !Flag;
        //
        ((DropDownList)frmViewMedicalAccounts.FindControl("ddlGov")).Enabled = !Flag;
        ((DropDownList)frmViewMedicalAccounts.FindControl("ddlCity")).Enabled = !Flag;
        ((DropDownList)frmViewMedicalAccounts.FindControl("ddlBrick")).Enabled = !Flag;
        ((DropDownList)frmViewMedicalAccounts.FindControl("ddlSubordination")).Enabled = !Flag;

    }

    #endregion

    #region Products FeedBack

    protected void ddlProductsList_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindProductsFeedback(int.Parse(((DropDownList)(frmViewMedicalAccounts.FindControl("ddlProductsList"))).SelectedValue), false);
    }

    private void BindProductsFeedback(int ProductID, bool ShowAll)
    {
        ViewState["SelectedProductFeedBackID"] = ProductID.ToString();
        int MedicalAccountID;
        if (CurrentQueryStringsValues.TransType == "Update")
        {
            MedicalAccountID = int.Parse(CurrentQueryStringsValues.oldRefID);
             ShowAll = true;
        }
        else
        {
             MedicalAccountID = (int.Parse(frmViewMedicalAccounts.DataKey["MedicalAccountID"].ToString()));
        }
        
        DataTable dt = new DataTable();
        dt.Merge(GetProductFeedback(ProductID, MedicalAccountID, ShowAll));
        if (dt.Rows.Count > 0)
        {
            ViewState["ProductFeedbackID"] = int.Parse(dt.Rows[0]["ProductFeedbackID"].ToString());
            ((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupTotalRXDay")).Text = dt.Rows[0]["Group_Total_Average_day"].ToString();
            ((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupTotalRXWeek")).Text = dt.Rows[0]["Group_Total_Average_Week"].ToString();
            ((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupTotalRXMonth")).Text = dt.Rows[0]["Group_Total_Average_Month"].ToString();
            ((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupCompRXDay")).Text = dt.Rows[0]["Product_Competitors_Average_Day"].ToString();
            ((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupCompRXWeek")).Text = dt.Rows[0]["Product_Competitors_Average_Week"].ToString();
            ((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupCompRXMonth")).Text = dt.Rows[0]["Product_Competitors_Average_Month"].ToString();
            ((TextBox)frmViewMedicalAccounts.FindControl("txtProductTotalRXAvgDay")).Text = dt.Rows[0]["Product_Total_Day"].ToString();
            ((TextBox)frmViewMedicalAccounts.FindControl("txtProductTotalRXAvgWeek")).Text = dt.Rows[0]["Product_Total_Week"].ToString();
            ((TextBox)frmViewMedicalAccounts.FindControl("txtProductTotalRXAvgMonth")).Text = dt.Rows[0]["Product_Total_Month"].ToString();

        }
        else
        {
            ResetProductFeedbackControls();

        }
        ((DropDownList)(frmViewMedicalAccounts.FindControl("ddlProductsList"))).SelectedValue = ProductID.ToString();

    }

    private void ResetProductFeedbackControls()
    {
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupTotalRXDay")).Text = "0";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupTotalRXWeek")).Text = "0";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupTotalRXMonth")).Text = "0";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupCompRXDay")).Text = "0";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupCompRXWeek")).Text = "0";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupCompRXMonth")).Text = "0";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductTotalRXAvgDay")).Text = "0";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductTotalRXAvgWeek")).Text = "0";
        ((TextBox)frmViewMedicalAccounts.FindControl("txtProductTotalRXAvgMonth")).Text = "0";
        ViewState["ProductFeedbackID"] = null;
    }

    private void SaveProductFeedBack(int MedicalAccountID)
    {
        int ProductID = int.Parse(((DropDownList)frmViewMedicalAccounts.FindControl("ddlProductsList")).SelectedValue);
        int ProductGroupTotalRXDay = int.Parse(((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupTotalRXDay")).Text);
        int ProductGroupTotalRXWeek = int.Parse(((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupTotalRXWeek")).Text);
        int ProductGroupTotalRXMonth = int.Parse(((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupTotalRXMonth")).Text);
        int ProductGroupCompRXDay = int.Parse(((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupCompRXDay")).Text);
        int ProductGroupCompRXWeek = int.Parse(((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupCompRXWeek")).Text);
        int ProductGroupCompRXMonth = int.Parse(((TextBox)frmViewMedicalAccounts.FindControl("txtProductGroupCompRXMonth")).Text);
        int ProductTotalRXAvgDay = int.Parse(((TextBox)frmViewMedicalAccounts.FindControl("txtProductTotalRXAvgDay")).Text);
        int ProductTotalRXAvgWeek = int.Parse(((TextBox)frmViewMedicalAccounts.FindControl("txtProductTotalRXAvgWeek")).Text);
        int ProductTotalRXAvgMonth = int.Parse(((TextBox)frmViewMedicalAccounts.FindControl("txtProductTotalRXAvgMonth")).Text);
        //
        if (ViewState["ProductFeedbackID"] != null)
        {
            int ProductFeedbackID = int.Parse(ViewState["ProductFeedbackID"].ToString());
            UpdateProductFeedback(ProductFeedbackID, ProductID, MedicalAccountID, ProductGroupTotalRXDay, ProductGroupTotalRXWeek, ProductGroupTotalRXMonth, ProductGroupCompRXDay, ProductGroupCompRXWeek, ProductGroupCompRXMonth, ProductTotalRXAvgDay, ProductTotalRXAvgWeek, ProductTotalRXAvgMonth);
        }
        else
        {
            InsertProductFeedback(ProductID, MedicalAccountID, ProductGroupTotalRXDay, ProductGroupTotalRXWeek, ProductGroupTotalRXMonth, ProductGroupCompRXDay, ProductGroupCompRXWeek, ProductGroupCompRXMonth, ProductTotalRXAvgDay, ProductTotalRXAvgWeek, ProductTotalRXAvgMonth);
        }
    }

    #endregion

    #region Search Handler

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        string[] Names = new string[0];
        string ErrMsg = "";
        MedicalAccounts currentPage = new MedicalAccounts();
        Names = currentPage.GetAllEntitiesNamesByUser("MedicalAccounts", prefixText, out ErrMsg);
        return Names;
    }

    protected void txtSearchName_TextChanged(object sender, EventArgs e)
    {
        string medicalAccountName = ((TextBox)frmViewMedicalAccounts.FindControl("txtSearchName")).Text;
        frmViewMedicalAccounts.PageIndex = GetCertainPageByName(medicalAccountName, false);
        BindMedicalAccountsView(false);
        BindgvPharmacies(false);
        BindProductsFeedback(int.Parse(((DropDownList)(frmViewMedicalAccounts.FindControl("ddlProductsList"))).SelectedValue), false);
        AdjustReadOnlyFormStatus(true);
        AdjustDropDownListsSelection();
        lblmsg.Visible = false;
    }

    #endregion

}