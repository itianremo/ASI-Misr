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

public partial class Pharmacies : PharmaciesBLL
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
            frmViewPharmacies.PagerSettings.Visible = false;
        }


        if (!IsPostBack)
        {
            //Get the page that contains the PharmacyID passed in the query string
            int ID = -1;
            if (!String.IsNullOrEmpty(CurrentQueryStringsValues.ID))
            {
                int.TryParse(CurrentQueryStringsValues.ID, out ID);
                frmViewPharmacies.PageIndex = GetCertainPageByID(ID, !String.IsNullOrEmpty(CurrentQueryStringsValues.TransType));
                BindPharmaciesView(!String.IsNullOrEmpty(CurrentQueryStringsValues.TransType));
            }
            else
            {
                BindPharmaciesView(false);
            }
            
            if (frmViewPharmacies.DataItemCount > 0)
            {
                bool ShowAll = false;
                if (!String.IsNullOrEmpty(CurrentQueryStringsValues.TransType))
                {
                    if (CurrentQueryStringsValues.TransType == "Update" || CurrentQueryStringsValues.TransType == "Add")
                    {
                        ShowAll = true;
                    }
                }
                //----------------------
                BindgvMedicalAccounts(ShowAll);
                BindgvPhyscians(ShowAll);
                BindgvDistributors(ShowAll);
                //----------------------
                AdjustReadOnlyFormStatus(true);
                AdjustDropDownListsSelection();
                if (ID > -1 && !String.IsNullOrEmpty(CurrentQueryStringsValues.oldRefID))
                {
                    AdjustChangesMarks(Convert.ToInt32(CurrentQueryStringsValues.oldRefID), ID);
                }
            }
            else
            {
                lblNoDataMsg.Text = "No Pharmacies found in your bricks.";
                HandleIfBlankFormView();
            }
        }

    }

    private void AdjustChangesMarks(int OldID, int NewID)
    {
        dsPharmacies.dtPharmaciesChangesDataTable dt = SelectPharmaciesChanges(OldID, NewID);

        if (dt.Rows.Count > 0)
        {
            foreach (DataColumn dc in dt.Columns)
            {
                if (dt.Rows[0][dc.ColumnName].Equals("True"))
                {
                    if (dc.ColumnName.StartsWith("txt"))
                    {
                        ((TextBox)frmViewPharmacies.FindControl(dc.ColumnName)).BackColor = System.Drawing.Color.LightYellow;
                    }
                    else if (dc.ColumnName.StartsWith("ddl"))
                    {
                        ((DropDownList)frmViewPharmacies.FindControl(dc.ColumnName)).BackColor = System.Drawing.Color.LightYellow;
                    }
                    else if (dc.ColumnName.StartsWith("cbx") || dc.ColumnName.StartsWith("chk"))
                    {
                        ((CheckBox)frmViewPharmacies.FindControl(dc.ColumnName)).BackColor = System.Drawing.Color.LightYellow;
                    }
                }
            }
        }
    }

    #endregion

    #region GridViews Handler

    private void HandleIfBlankFormView()
    {
        ViewState["SaveMode"] = "Add";
        AdjustReadOnlyFormStatus(false);
        TransButtons ucTransButtons = (TransButtons)Master.FindControl("ucTransButtons");
        ((ImageButton)ucTransButtons.FindControl("btnSave")).Visible = true;
        ((ImageButton)ucTransButtons.FindControl("btnCancel")).Visible = false;
        ((ImageButton)ucTransButtons.FindControl("btnAdd")).Visible = false;
        ((ImageButton)ucTransButtons.FindControl("btnEdit")).Visible = false;
        ((ImageButton)ucTransButtons.FindControl("btnDelete")).Visible = false;
    }

    private void BindgvPhyscians(bool ShowAll)
    {
        if (CurrentQueryStringsValues.TransType == "Update")
        {
            ViewState["GetRxPhysicians"] = new PhysiciansBLL().GetRxPhysicians(int.Parse(CurrentQueryStringsValues.oldRefID), ShowAll);
        }
        else
        {
            ViewState["GetRxPhysicians"] = new PhysiciansBLL().GetRxPhysicians(int.Parse(frmViewPharmacies.DataKey["PharmacyID"].ToString()), ShowAll);
        }
        ((GridView)(frmViewPharmacies.FindControl("gvPhyscians"))).DataSource = ViewState["GetRxPhysicians"];
        ((GridView)(frmViewPharmacies.FindControl("gvPhyscians"))).DataBind();
    }

    private void BindPharmaciesView(bool ShowAll)
    {
        Session["ShowAll"] = ShowAll;
        frmViewPharmacies.DataSource = odsPharmacies;
        frmViewPharmacies.DataBind();
    }

    private void BindgvMedicalAccounts(bool ShowAll)
    {
        if (CurrentQueryStringsValues.TransType == "Update")
        {
            ViewState["GetRxMedicalAccount"] = GetRxMedicalAccount(int.Parse(CurrentQueryStringsValues.oldRefID), ShowAll);
        }
        else
        {
            ViewState["GetRxMedicalAccount"] = GetRxMedicalAccount(int.Parse(frmViewPharmacies.DataKey["PharmacyID"].ToString()), ShowAll);
        }
        ((GridView)(frmViewPharmacies.FindControl("gvMedicalAccounts"))).DataSource = ViewState["GetRxMedicalAccount"];
        ((GridView)(frmViewPharmacies.FindControl("gvMedicalAccounts"))).DataBind();
    }

    private void BindgvDistributors(bool ShowAll)
    {
        if (CurrentQueryStringsValues.TransType == "Update")
        {
            ViewState["GetRxDistributors"] = new DistributorsBLL().GetRxDistributors(int.Parse(CurrentQueryStringsValues.oldRefID), ShowAll);
        }
        else
        {
            ViewState["GetRxDistributors"] = new DistributorsBLL().GetRxDistributors(int.Parse(frmViewPharmacies.DataKey["PharmacyID"].ToString()), ShowAll);
        }
        ((GridView)(frmViewPharmacies.FindControl("gvDistributors"))).DataSource = ViewState["GetRxDistributors"];
        ((GridView)(frmViewPharmacies.FindControl("gvDistributors"))).DataBind();
    }

    protected void gvMedicalAccounts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (((CheckBox)e.Row.FindControl("cbxSelectMedicalAcc")).Checked)
            {
                e.Row.CssClass = "GridhighlightedRowsStyle";
            }
        }
    }

    protected void gvPhyscians_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (((CheckBox)e.Row.FindControl("cbxSelectPhyscians")).Checked)
            {
                e.Row.CssClass = "GridhighlightedRowsStyle";
            }
        }
    }

    protected void gvDistributors_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (((CheckBox)e.Row.FindControl("cbxSelectDistributor")).Checked)
            {
                e.Row.CssClass = "GridhighlightedRowsStyle";
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
                        int OriginalID = int.Parse(dtOriginalData.Rows[i][0].ToString());
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

    #region FormView Handler
    protected void frmViewPharmacies_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {
        frmViewPharmacies.PageIndex = e.NewPageIndex;
        BindPharmaciesView(false);
        BindgvMedicalAccounts(false);
        BindgvPhyscians(false);
        BindgvDistributors(false);
        AdjustDropDownListsSelection();
        AdjustTransButtons(false);
        lblmsg.Visible = false;
    }
   
    protected void ddlGov_SelectedIndexChanged(object sender, EventArgs e)
    {
        LookupsBLL objLookupsBLL = new LookupsBLL();
        ((TextBox)(frmViewPharmacies.FindControl("txtGov"))).Text = ((DropDownList)(frmViewPharmacies.FindControl("ddlGov"))).SelectedValue;
        ((DropDownList)(frmViewPharmacies.FindControl("ddlCity"))).DataSource = objLookupsBLL.GetCitiesByGov(int.Parse(((DropDownList)(frmViewPharmacies.FindControl("ddlGov"))).SelectedValue));
        ((DropDownList)(frmViewPharmacies.FindControl("ddlCity"))).DataBind();
    }

    protected void frmViewPharmacies_DataBound(object sender, EventArgs e)
    {
        if (this.Master.ToString() == "ASP.blankmasterpage_master")
        {
            ((TextBox)frmViewPharmacies.FindControl("txtSearchName")).Enabled = false;
            ((Label)frmViewPharmacies.FindControl("lblSearch")).Enabled = false;
        }
    }

    #endregion
    
    #region Buttons Transactions Events

    private void AdjustTransButtons(bool Flag)
    {
        TransButtons ucTransButtons = (TransButtons)Master.FindControl("ucTransButtons");
        ((ImageButton)ucTransButtons.FindControl("btnCancel")).Visible = Flag;
        ((ImageButton)ucTransButtons.FindControl("btnSave")).Visible = Flag;
        ((ImageButton)ucTransButtons.FindControl("btnAdd")).Visible = !Flag;
        ((ImageButton)ucTransButtons.FindControl("btnEdit")).Visible = !Flag;
    }
    
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
        EnableGridview(((GridView)(frmViewPharmacies.FindControl("gvMedicalAccounts"))), true, false,false);
        EnableGridview(((GridView)(frmViewPharmacies.FindControl("gvPhyscians"))), true, false, false);
        EnableGridview(((GridView)(frmViewPharmacies.FindControl("gvDistributors"))), true, false, false);
        AdjustReadOnlyFormStatus(false);
        AdjustTransButtons(true);
    }

    protected void ucTransButtons_btnAddEvent(object sender, EventArgs e)
    {
        lblDupName.Visible = false;
        lblmsg.Text = "";
        ViewState["SaveMode"] = "Add";
        EnableGridview(((GridView)(frmViewPharmacies.FindControl("gvMedicalAccounts"))), true, false, true);
        EnableGridview(((GridView)(frmViewPharmacies.FindControl("gvPhyscians"))), true, false, true);
        EnableGridview(((GridView)(frmViewPharmacies.FindControl("gvDistributors"))), true, false, true);
        AdjustReadOnlyFormStatus(false);
        AdjustTransButtons(true);
        ResetFormtxtboxes();
    }

    protected void ucTransButtons_btnSaveEvent(object sender, EventArgs e)
    {
        lblDupName.Visible = false;
        lblmsg.Text = "";
        string txtPharmacyName = ((TextBox)frmViewPharmacies.FindControl("txtPharmacyName")).Text;
        string txtPharmacistName = ((TextBox)frmViewPharmacies.FindControl("txtPharmacistName")).Text;
        string txtArea = ((TextBox)frmViewPharmacies.FindControl("txtArea")).Text;
        string txtAddress = ((TextBox)frmViewPharmacies.FindControl("txtAddress")).Text;
        string txtPhone1 = ((TextBox)frmViewPharmacies.FindControl("txtPhone1")).Text;
        string txtPhone2 = ((TextBox)frmViewPharmacies.FindControl("txtPhone2")).Text;
        string txtMobile = ((TextBox)frmViewPharmacies.FindControl("txtMobile")).Text;
        string txtPostalCode = ((TextBox)frmViewPharmacies.FindControl("txtPostalCode")).Text;
        string txtComment = ((TextBox)frmViewPharmacies.FindControl("txtComment")).Text;
        int GovID = int.Parse(((DropDownList)frmViewPharmacies.FindControl("ddlGov")).SelectedValue);
        int CityID = int.Parse(((DropDownList)frmViewPharmacies.FindControl("ddlCity")).SelectedValue);
        int BrickID = int.Parse(((DropDownList)frmViewPharmacies.FindControl("ddlBrick")).SelectedValue);
        if (ViewState["SaveMode"].ToString() == "Add")
        {
            if (!IsPharmacyNameExist(txtPharmacyName))
            {
                int NewPharmacyID = 0;
                int Result = AddNewPharmacy(txtPharmacyName, BrickID, txtPharmacistName, GovID, CityID, txtArea, txtAddress, txtPhone1, txtPhone2, txtMobile, txtPostalCode, txtComment, out NewPharmacyID);
                if (Result == 0)
                {
                    // Error // Failed to perform this operation
                    lblmsg.Text = "Failed to perform this operation.";
                    lblmsg.Visible = true;
                    goto EndSaveTrans;
                }
                else if (Result == 1)
                {
                    // Added //
                    // Save the Rest Ttansactions for Medical Accounts , Phsysions and distributers //
                    SaveChangedValues(NewPharmacyID, "SaveRxMedicalAccount", GetChangedValues("Add", ((DataTable)ViewState["GetRxMedicalAccount"]), "Selected", ((GridView)(frmViewPharmacies.FindControl("gvMedicalAccounts"))), "cbxSelectMedicalAcc", 1));
                    SaveChangedValues(NewPharmacyID, "SaveRxPhysicians", GetChangedValues("Add", ((DataTable)ViewState["GetRxPhysicians"]), "Selected", ((GridView)(frmViewPharmacies.FindControl("gvPhyscians"))), "cbxSelectPhyscians", 1));
                    SaveChangedValues(NewPharmacyID, "SaveRxDistributors", GetChangedValues("Add", ((DataTable)ViewState["GetRxDistributors"]), "Selected", ((GridView)(frmViewPharmacies.FindControl("gvDistributors"))), "cbxSelectDistributor", 1));
                    //// Reload Related Data //
                    frmViewPharmacies.PageIndex = GetCertainPageByID(NewPharmacyID, false);
                    BindPharmaciesView(false);
                    if (frmViewPharmacies.DataItemCount > 0)
                    {
                        BindgvMedicalAccounts(false);
                        BindgvPhyscians(false);
                        BindgvDistributors(false);
                    }
                }
                else if (Result == 2)
                {
                    // Request to Save the Rest of Transactions for Medical Accounts , Phsysions and distributers //
                    SaveChangedValues(NewPharmacyID, "SaveRxMedicalAccount", GetChangedValues("Add", ((DataTable)ViewState["GetRxMedicalAccount"]), "Selected", ((GridView)(frmViewPharmacies.FindControl("gvMedicalAccounts"))), "cbxSelectMedicalAcc", 1));
                    SaveChangedValues(NewPharmacyID, "SaveRxPhysicians", GetChangedValues("Add", ((DataTable)ViewState["GetRxPhysicians"]), "Selected", ((GridView)(frmViewPharmacies.FindControl("gvPhyscians"))), "cbxSelectPhyscians", 1));
                    SaveChangedValues(NewPharmacyID, "SaveRxDistributors", GetChangedValues("Add", ((DataTable)ViewState["GetRxDistributors"]), "Selected", ((GridView)(frmViewPharmacies.FindControl("gvDistributors"))), "cbxSelectDistributor", 1));
                    //// Reload Related Data //
                    frmViewPharmacies.PageIndex = GetCertainPageByID(NewPharmacyID, false);
                    BindPharmaciesView(false);
                    if (frmViewPharmacies.DataItemCount > 0)
                    {
                        BindgvMedicalAccounts(false);
                        BindgvPhyscians(false);
                        BindgvDistributors(false);
                    }
                    // Added Requested // Pending Request
                    lblmsg.Text = "Your request for adding new Pharmacy is in pending phase until acceptance from your manager";
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
        //-----------------------------------
        else if (ViewState["SaveMode"].ToString() == "Edit")
        {
            int PharmacyID = (int.Parse(frmViewPharmacies.DataKey["PharmacyID"].ToString()));
            if (!IsUpdatedPharmacyNameExist(PharmacyID, txtPharmacyName))
            {
                string Msg = "";
                int result = UpdatePharmacy(PharmacyID, txtPharmacyName, BrickID, txtPharmacistName, GovID, CityID, txtArea, txtAddress, txtPhone1, txtPhone2, txtMobile, txtPostalCode, txtComment, out Msg);
                if (result == 0)
                {
                    lblmsg.Text = (Msg.Length > 0) ? Msg : "Failed to Edit";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    lblmsg.Visible = true;
                    goto EndSaveTrans;
                }
                else if (result == 1)
                {
                    // Updated //
                    // Update the Rest Ttansactions for Medical Accounts , Phsysions and distributers //
                    SaveChangedValues(PharmacyID, "SaveRxMedicalAccount", GetChangedValues("Edit", ((DataTable)ViewState["GetRxMedicalAccount"]), "Selected", ((GridView)(frmViewPharmacies.FindControl("gvMedicalAccounts"))), "cbxSelectMedicalAcc", 1));
                    SaveChangedValues(PharmacyID, "SaveRxPhysicians", GetChangedValues("Edit", ((DataTable)ViewState["GetRxPhysicians"]), "Selected", ((GridView)(frmViewPharmacies.FindControl("gvPhyscians"))), "cbxSelectPhyscians", 1));
                    SaveChangedValues(PharmacyID, "SaveRxDistributors", GetChangedValues("Edit", ((DataTable)ViewState["GetRxDistributors"]), "Selected", ((GridView)(frmViewPharmacies.FindControl("gvDistributors"))), "cbxSelectDistributor", 1));
                    // Reload Data //
                    // Added //
                    frmViewPharmacies.PageIndex = GetCertainPageByID(PharmacyID, false);
                    BindPharmaciesView(false);
                    if (frmViewPharmacies.DataItemCount > 0)
                    {
                        BindgvMedicalAccounts(false);
                        BindgvPhyscians(false);
                        BindgvDistributors(false);
                    }
                }
                else if (result == 2)
                {
                    // Updated Requested // Pending Request
                    SaveChangedValues(PharmacyID, "SaveRxMedicalAccount", GetChangedValues("Edit", ((DataTable)ViewState["GetRxMedicalAccount"]), "Selected", ((GridView)(frmViewPharmacies.FindControl("gvMedicalAccounts"))), "cbxSelectMedicalAcc", 1));
                    SaveChangedValues(PharmacyID, "SaveRxPhysicians", GetChangedValues("Edit", ((DataTable)ViewState["GetRxPhysicians"]), "Selected", ((GridView)(frmViewPharmacies.FindControl("gvPhyscians"))), "cbxSelectPhyscians", 1));
                    SaveChangedValues(PharmacyID, "SaveRxDistributors", GetChangedValues("Edit", ((DataTable)ViewState["GetRxDistributors"]), "Selected", ((GridView)(frmViewPharmacies.FindControl("gvDistributors"))), "cbxSelectDistributor", 1));
                    // Reload Data //
                    frmViewPharmacies.PageIndex = GetCertainPageByID(PharmacyID, false);
                    BindPharmaciesView(false);
                    if (frmViewPharmacies.DataItemCount > 0)
                    {
                        BindgvMedicalAccounts(false);
                        BindgvPhyscians(false);
                        BindgvDistributors(false);
                    }
                    //
                    lblmsg.Text = "Your request for updating Pharmacy is in pending phase until acceptance from your manager";
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
        if (frmViewPharmacies.DataItemCount > 0)
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

    protected void ucTransButtons_btnDeleteEvent(object sender, EventArgs e)
    {
        lblDupName.Visible = false;
        lblmsg.Text = "";
        int PharmacyID = (int.Parse(frmViewPharmacies.DataKey["PharmacyID"].ToString()));
        int result = DeletePharmacy(PharmacyID);
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
            if (frmViewPharmacies.PageIndex > 1)
                frmViewPharmacies.PageIndex--;
            BindPharmaciesView(false);
            BindgvMedicalAccounts(false);
            BindgvPhyscians(false);
            BindgvDistributors(false);
            AdjustReadOnlyFormStatus(true);
            AdjustDropDownListsSelection();
            AdjustTransButtons(false);
        }
        else
        {
            // Delete Requested // Pending Request
            lblmsg.Text = "Your request for Delete Pharmacy is in Pending phase until Acceptance from your Manager";
            lblmsg.Visible = true;
        }
    }



    private void SaveChangedValues(int PharmacyID, string SaveMethod, DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            switch (SaveMethod)
            {
                case "SaveRxMedicalAccount":
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int ID = int.Parse(dt.Rows[i]["CurrentID"].ToString());
                        bool Status = bool.Parse(dt.Rows[i]["CurrentcbxStatus"].ToString());

                        if (Status)
                        {
                            AssignPharmacyToMedicalAccount(PharmacyID, ID);

                        }
                        else
                        {
                            UnAssignPharmacyToMedicalAccount(PharmacyID, ID);
                        }

                    }
                    break;

                case "SaveRxPhysicians":
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int ID = int.Parse(dt.Rows[i]["CurrentID"].ToString());
                        bool Status = bool.Parse(dt.Rows[i]["CurrentcbxStatus"].ToString());

                        if (Status)
                        {
                            AssignPharmacyToPhysician(PharmacyID, ID);

                        }
                        else
                        {
                            UnAssignPharmacyToPhysician(PharmacyID, ID);
                        }

                    }
                    break;

                case "SaveRxDistributors":
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int ID = int.Parse(dt.Rows[i]["CurrentID"].ToString());
                        bool Status = bool.Parse(dt.Rows[i]["CurrentcbxStatus"].ToString());

                        if (Status)
                        {
                            AssignPharmacyToDistributors(PharmacyID, ID);

                        }
                        else
                        {
                            UnAssignPharmacyToDistributors(PharmacyID, ID);
                        }

                    }
                    break;

            }
        }
    }

    protected void ucTransButtons_btnCancelEvent(object sender, EventArgs e)
    {
        lblDupName.Visible = false;
        lblmsg.Text = "";
        BindPharmaciesView(false);
        BindgvMedicalAccounts(false);
        BindgvPhyscians(false);
        BindgvDistributors(false);
        AdjustReadOnlyFormStatus(true);
        AdjustDropDownListsSelection();
        AdjustTransButtons(false);
    }


    #endregion

    #region Page Controls Handler

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

    private void AdjustDropDownListsSelection()
    {
        ((DropDownList)frmViewPharmacies.FindControl("ddlBrick")).SelectedValue = ((TextBox)frmViewPharmacies.FindControl("txtBrickID")).Text;
        ((DropDownList)frmViewPharmacies.FindControl("ddlGov")).SelectedValue = ((TextBox)frmViewPharmacies.FindControl("txtGov")).Text;
        ((DropDownList)frmViewPharmacies.FindControl("ddlCity")).SelectedValue = ((TextBox)frmViewPharmacies.FindControl("txtCity")).Text;

    }
    
    private void ResetFormtxtboxes()
    {
        ((TextBox)frmViewPharmacies.FindControl("txtPharmacyName")).Text = "";
        ((TextBox)frmViewPharmacies.FindControl("txtPharmacistName")).Text = "";
        ((TextBox)frmViewPharmacies.FindControl("txtGov")).Text = "";
        ((TextBox)frmViewPharmacies.FindControl("txtCity")).Text = "";
        ((TextBox)frmViewPharmacies.FindControl("txtArea")).Text = "";
        ((TextBox)frmViewPharmacies.FindControl("txtAddress")).Text = "";
        ((TextBox)frmViewPharmacies.FindControl("txtBrickID")).Text = "";
        ((TextBox)frmViewPharmacies.FindControl("txtPhone1")).Text = "";
        ((TextBox)frmViewPharmacies.FindControl("txtPhone2")).Text = "";
        ((TextBox)frmViewPharmacies.FindControl("txtMobile")).Text = "";
        ((TextBox)frmViewPharmacies.FindControl("txtPostalCode")).Text = "";
        ((TextBox)frmViewPharmacies.FindControl("txtComment")).Text = "";

    }
    
    protected void AdjustReadOnlyFormStatus(bool Flag)
    {
        ((TextBox)frmViewPharmacies.FindControl("txtPharmacyName")).ReadOnly = Flag;
        ((TextBox)frmViewPharmacies.FindControl("txtPharmacistName")).ReadOnly = Flag;
        ((TextBox)frmViewPharmacies.FindControl("txtGov")).ReadOnly = Flag;
        ((TextBox)frmViewPharmacies.FindControl("txtCity")).ReadOnly = Flag;
        ((TextBox)frmViewPharmacies.FindControl("txtArea")).ReadOnly = Flag;
        ((TextBox)frmViewPharmacies.FindControl("txtAddress")).ReadOnly = Flag;
        ((TextBox)frmViewPharmacies.FindControl("txtBrickID")).ReadOnly = Flag;
        ((TextBox)frmViewPharmacies.FindControl("txtPhone1")).ReadOnly = Flag;
        ((TextBox)frmViewPharmacies.FindControl("txtPhone2")).ReadOnly = Flag;
        ((TextBox)frmViewPharmacies.FindControl("txtMobile")).ReadOnly = Flag;
        ((TextBox)frmViewPharmacies.FindControl("txtPostalCode")).ReadOnly = Flag;
        ((TextBox)frmViewPharmacies.FindControl("txtComment")).ReadOnly = Flag;
        ((DropDownList)frmViewPharmacies.FindControl("ddlGov")).Enabled = !Flag;
        ((DropDownList)frmViewPharmacies.FindControl("ddlCity")).Enabled = !Flag;
        ((DropDownList)frmViewPharmacies.FindControl("ddlBrick")).Enabled = !Flag;
    }

    protected void ddlGov_DataBound(object sender, EventArgs e)
    {
        LookupsBLL objLookupsBLL = new LookupsBLL();
        ((DropDownList)(frmViewPharmacies.FindControl("ddlCity"))).DataSource = objLookupsBLL.GetCitiesByGov(int.Parse(((DropDownList)(frmViewPharmacies.FindControl("ddlGov"))).SelectedValue));
        ((DropDownList)(frmViewPharmacies.FindControl("ddlCity"))).DataBind();

    }

    #endregion

    #region Search Handler

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        string[] Names = new string[0];
        string ErrMsg = "";
        Pharmacies currentPage = new Pharmacies();
        Names = currentPage.GetAllEntitiesNamesByUser("Pharmacies", prefixText, out ErrMsg);
        return Names;
    }

    protected void txtSearchName_TextChanged(object sender, EventArgs e)
    {
        string pharmacyName = ((TextBox)frmViewPharmacies.FindControl("txtSearchName")).Text;
        frmViewPharmacies.PageIndex = GetCertainPageByName(pharmacyName, false);
        BindPharmaciesView(false);
        BindgvMedicalAccounts(false);
        BindgvPhyscians(false);
        BindgvDistributors(false);
        AdjustDropDownListsSelection();
        AdjustTransButtons(false);
        ((TextBox)frmViewPharmacies.FindControl("txtSearchName")).Text = "";
        lblmsg.Visible = false;
    }
    #endregion
}
