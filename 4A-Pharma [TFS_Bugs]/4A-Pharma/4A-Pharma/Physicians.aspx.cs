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

public partial class Physicians : Pharma.BMD.BLL.PhysiciansBLL
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
            frmViewPhysicians.PagerSettings.Visible = false;
        }

        if (!IsPostBack)
        {
            int ID = 0;
            //Get the page that contains the PhysicianID passed in the query string
            if (!String.IsNullOrEmpty(CurrentQueryStringsValues.ID))
            {

                int.TryParse(CurrentQueryStringsValues.ID, out ID);
                frmViewPhysicians.PageIndex = GetCertainPageByID(ID, !String.IsNullOrEmpty(CurrentQueryStringsValues.TransType));
                BindPhysiciasView(!String.IsNullOrEmpty(CurrentQueryStringsValues.TransType));
            }
            else
            {
                BindPhysiciasView(false);
            }
            
            if (frmViewPhysicians.DataItemCount > 0)
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
                LoadScores(ShowAll);
                AdjustReadOnlyFormStatus(true);
            }
            else
            {
                lblNoDataMsg.Text = "No Physicians Assigned.";
                HandleIfBlankFormView();
            }
        }
    }

    #endregion
   
    #region Form View Handler
    
    private void HandleIfBlankFormView()
    {
        ViewState["SaveMode"] = "Add";
        AdjustReadOnlyFormStatus(false);
        ResetFormtxtboxes();
        //
        BindgvMedicalAccounts(false);
        EnableGridview(((GridView)(frmViewPhysicians.FindControl("gvMedicalAccounts"))), true, false, true);
        //
        ((DropDownList)(frmViewPhysicians.FindControl("ddlChartType"))).Enabled = false;
        ((GridView)(frmViewPhysicians.FindControl("gvScores"))).Enabled = false;
        //
        TransButtons ucTransButtons = (TransButtons)Master.FindControl("ucTransButtons");
        ((ImageButton)ucTransButtons.FindControl("btnSave")).Visible = true;
        ((ImageButton)ucTransButtons.FindControl("btnCancel")).Visible = false;
        ((ImageButton)ucTransButtons.FindControl("btnAdd")).Visible = false;
        ((ImageButton)ucTransButtons.FindControl("btnEdit")).Visible = false;
        ((ImageButton)ucTransButtons.FindControl("btnDelete")).Visible = false;
    }

    private void BindgvMedicalAccounts(bool ShowAll)
    {
        if (CurrentQueryStringsValues.TransType == "Update")
        {
            ViewState["gvMedicalAccounts"] = GetMedicalAccountsAssociatedWithPhysicians(int.Parse(CurrentQueryStringsValues.oldRefID), ShowAll);
        }
        else
        {
            int PhysicianID;
            if (frmViewPhysicians.DataKey["PhysicianID"] != null)
                PhysicianID = int.Parse(frmViewPhysicians.DataKey["PhysicianID"].ToString());
            else
                PhysicianID = 0;
            ViewState["gvMedicalAccounts"] = GetMedicalAccountsAssociatedWithPhysicians(PhysicianID, ShowAll);
        }
        ((GridView)(frmViewPhysicians.FindControl("gvMedicalAccounts"))).DataSource = ViewState["gvMedicalAccounts"];
        ((GridView)(frmViewPhysicians.FindControl("gvMedicalAccounts"))).DataBind();
    }

    private void BindgvMedicalAccountsReset()
    {
        ViewState["gvMedicalAccounts"] = GetMedicalAccountsAssociatedWithPhysicians(0, false);
        ((GridView)(frmViewPhysicians.FindControl("gvMedicalAccounts"))).DataSource = ViewState["gvMedicalAccounts"];
        ((GridView)(frmViewPhysicians.FindControl("gvMedicalAccounts"))).DataBind();
    }

    private void BindPhysiciasView(bool ShowAll)
    {
        Session["ShowAll"] = ShowAll;
        frmViewPhysicians.DataSource = odsPhysicians;
        frmViewPhysicians.DataBind();
    }

    protected void ddlBrick_DataBound(object sender, EventArgs e)
    {
        DropDownList ddlBrick = (DropDownList)frmViewPhysicians.FindControl("ddlBrick");
        if (frmViewPhysicians.DataItem == null)
        {
            ddlBrick.Items.Add("NA");
            ddlBrick.SelectedValue = "NA";
        }
        else
        {
            string BrickID = ((DataRowView)frmViewPhysicians.DataItem)["BrickID"].ToString();
            if (ddlBrick.Items.FindByValue(BrickID) != null)
                ddlBrick.SelectedValue = BrickID;
            else
            {
                ddlBrick.Items.Add("NA");
                ddlBrick.SelectedValue = "NA";
            }
        }
    }

    protected void frmViewPhysicians_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {
        ((Label)frmViewPhysicians.FindControl("lblErrors")).Text = "";
        frmViewPhysicians.PageIndex = e.NewPageIndex;
        BindPhysiciasView(false);
        LoadScores(false);
        BindgvMedicalAccounts(false);
        AdjustDropDownListsSelection();
        AdjustTransButtons(false);
        lblmsg.Visible = false;
    }

    protected void frmViewPhysicians_DataBound(object sender, EventArgs e)
    {
        if (this.Master.ToString() == "ASP.blankmasterpage_master")
        {
            ((TextBox)frmViewPhysicians.FindControl("txtSearchName")).Enabled = false;
            ((Label)frmViewPhysicians.FindControl("lblSearch")).Enabled = false;
            ((DropDownList)frmViewPhysicians.FindControl("ddlChartType")).Enabled = false;
        }
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
        lblmsg.Text = "";
        ((Label)frmViewPhysicians.FindControl("lblErrors")).Text = "";
        ViewState["SaveMode"] = "Edit";
        EnableGridview(((GridView)(frmViewPhysicians.FindControl("gvMedicalAccounts"))), true, false, false);
        AdjustReadOnlyFormStatus(false);
        AdjustTransButtons(true);

    }

    protected void ucTransButtons_btnAddEvent(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        ((Label)frmViewPhysicians.FindControl("lblErrors")).Text = "";
        ViewState["SaveMode"] = "Add";
        AdjustReadOnlyFormStatus(false);
        AdjustTransButtons(true);
        ResetFormtxtboxes();
        ((System.Web.UI.HtmlControls.HtmlTable)(frmViewPhysicians.FindControl("tblScore"))).Visible = false;
        BindgvMedicalAccountsReset();
        EnableGridview(((GridView)(frmViewPhysicians.FindControl("gvMedicalAccounts"))), true, false, false);
         
    }

    protected void ucTransButtons_btnSaveEvent(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        ((Label)frmViewPhysicians.FindControl("lblErrors")).Text = "";
        string txtPhysicianName = ((TextBox)frmViewPhysicians.FindControl("txtPhysicianName")).Text;
        string txtAKA = ((TextBox)frmViewPhysicians.FindControl("txtAKA")).Text;
        string txtMobile = ((TextBox)frmViewPhysicians.FindControl("txtMobile")).Text;
        string txtEmail = ((TextBox)frmViewPhysicians.FindControl("txtEmail")).Text;
        string txtPostalCode = ((TextBox)frmViewPhysicians.FindControl("txtPostalCode")).Text;
        string txtComment = ((TextBox)frmViewPhysicians.FindControl("txtComment")).Text;

        int TitleID = int.Parse(((DropDownList)frmViewPhysicians.FindControl("ddlTitle")).SelectedValue);
        int SpecialityID = int.Parse(((DropDownList)frmViewPhysicians.FindControl("ddlSpeciality")).SelectedValue);
        string strBrickID = ((DropDownList)frmViewPhysicians.FindControl("ddlBrick")).SelectedValue;
        int BrickID;
        if (strBrickID == "NA")
            BrickID = Convert.ToInt32(((TextBox)frmViewPhysicians.FindControl("txtBrick")).Text);
        else
            BrickID = Convert.ToInt32(strBrickID);

        bool OwnsPrivateclinic = ((CheckBox)frmViewPhysicians.FindControl("chkOwnPrivateClinic")).Checked;
        //
        if (ViewState["SaveMode"].ToString() == "Add")
        {
            int NewPhysicianID = 0;
            if (!IsPhysicianNameAndAKADuplicated(txtPhysicianName, txtAKA))
            {
                int Result = AddNewPhysician(txtPhysicianName, txtAKA, BrickID, TitleID, SpecialityID, OwnsPrivateclinic, txtMobile, txtEmail, txtPostalCode, txtComment, out NewPhysicianID);
                if (Result == 1)
                {
                    // Added //
                    ((System.Web.UI.HtmlControls.HtmlTable)(frmViewPhysicians.FindControl("tblScore"))).Visible = true;
                    SaveMedicalAccountsRels(NewPhysicianID);
                    //// Reload Data //
                    frmViewPhysicians.PageIndex = GetCertainPageByID(NewPhysicianID, false);
                    BindPhysiciasView(false);
                    if (frmViewPhysicians.DataItemCount > 0)
                    {
                        BindgvMedicalAccounts(false);
                        LoadScores(false);
                    }
                }
                else
                {
                    if (Result == 2)
                    {
                        // Added Requested // Pending Request
                        ((System.Web.UI.HtmlControls.HtmlTable)(frmViewPhysicians.FindControl("tblScore"))).Visible = true;
                        SaveMedicalAccountsRels(NewPhysicianID);
                        //// Reload Data //
                        frmViewPhysicians.PageIndex = GetCertainPageByID(NewPhysicianID, false);
                        BindPhysiciasView(false);
                        if (frmViewPhysicians.DataItemCount > 0)
                        {
                            BindgvMedicalAccounts(false);
                            LoadScores(false);
                        }
                        lblmsg.Text = "Your request for adding new physician is in pending phase until acceptance from your manager";
                        lblmsg.Visible = true;
                    }
                    else
                    {
                        // Error
                        lblmsg.Text = "Failed to perform this operation.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        lblmsg.Visible = true;
                    }
                }
            }
            else
            {
                // Error
                lblmsg.Text = "Can't duplicate physician name with the same AKA";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Visible = true;
                return;
            }
        }
        else if (ViewState["SaveMode"].ToString() == "Edit")
        {
            int PhysicianID = (int.Parse(frmViewPhysicians.DataKey["PhysicianID"].ToString()));

            if (!IsUpdatedPhysicianNameAndAKADuplicated(PhysicianID, txtPhysicianName, txtAKA))
            {
                string Msg = "";
                int result = UpdatePhysician(PhysicianID, txtPhysicianName, txtAKA, BrickID, TitleID, SpecialityID, OwnsPrivateclinic, txtMobile, txtEmail, txtPostalCode, txtComment, out Msg);
                if (result == 0)
                {
                    lblmsg.Text = (Msg.Length > 0) ? Msg : "Failed to Edit";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    lblmsg.Visible = true;
                }
                else if (result == 1)
                {
                    // Updated //
                    SaveMedicalAccountsRels(PhysicianID);
                    //// Reload Data //
                    BindgvMedicalAccounts(false);
                    LoadScores(false);
                }
                else
                {
                    SaveMedicalAccountsRels(PhysicianID);
                    //// Reload Data //
                    BindgvMedicalAccounts(false);
                    LoadScores(false);

                    // Updated Requested // Pending Request
                    lblmsg.Text = "Your request for updating physician is in pending phase until acceptance from your manager";
                    lblmsg.Visible = true;
                }
            }
            else
            {
                // Error
                lblmsg.Text = "Can't duplicate physician name with the same AKA";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Visible = true;
                return;
            }
        }
        if (frmViewPhysicians.DataItemCount > 0)
        {
            AdjustTransButtons(false);
            AdjustReadOnlyFormStatus(true);
            EnableGridview(((GridView)(frmViewPhysicians.FindControl("gvMedicalAccounts"))), false, false, false);
        }
        else 
        {
            HandleIfBlankFormView();
        }
    }

    protected void ucTransButtons_btnDeleteEvent(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        int PhysicianID = (int.Parse(frmViewPhysicians.DataKey["PhysicianID"].ToString()));
        int result = DeletePhysician(PhysicianID);
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
            if (frmViewPhysicians.PageIndex > 1)
                frmViewPhysicians.PageIndex--;
            BindPhysiciasView(false);
            BindgvMedicalAccounts(false);
            LoadScores(false);
            ((Label)frmViewPhysicians.FindControl("lblErrors")).Text = "";
            ((System.Web.UI.HtmlControls.HtmlTable)(frmViewPhysicians.FindControl("tblScore"))).Visible = true;
            AdjustReadOnlyFormStatus(true);
            AdjustDropDownListsSelection();
            AdjustTransButtons(false);
        }
        else
        {
            // Delete Requested // Pending Request
            lblmsg.Text = "Your request for Delete Physician is in Pending phase until Acceptance from your Manager";
            lblmsg.Visible = true;
        }
    }

    protected void SaveMedicalAccountsRels(int PhysicianID)
    {
        DataTable dtOriginalGV = (DataTable)ViewState["gvMedicalAccounts"];
        bool ChangeHapened = false;

        for (int i = 0; i < ((GridView)(frmViewPhysicians.FindControl("gvMedicalAccounts"))).Rows.Count; i++)
        {
            if (((GridView)(frmViewPhysicians.FindControl("gvMedicalAccounts"))).Rows[i].RowType == DataControlRowType.DataRow)
            {
                int CurrentID = int.Parse(((GridView)(frmViewPhysicians.FindControl("gvMedicalAccounts"))).DataKeys[i].Values[0].ToString());
                int OriginalID = int.Parse(dtOriginalGV.Rows[i][1].ToString());
                if (CurrentID == OriginalID)
                {
                    bool CurrentP = ((CheckBox)((GridView)(frmViewPhysicians.FindControl("gvMedicalAccounts"))).Rows[i].Cells[1].Controls[1]).Checked;
                    bool CurrentI = ((CheckBox)((GridView)(frmViewPhysicians.FindControl("gvMedicalAccounts"))).Rows[i].Cells[2].Controls[1]).Checked;
                    bool CurrentC = ((CheckBox)((GridView)(frmViewPhysicians.FindControl("gvMedicalAccounts"))).Rows[i].Cells[3].Controls[1]).Checked;
                    bool OriginalP = bool.Parse(dtOriginalGV.Rows[i]["PrescribingCapable"].ToString());
                    bool OriginalI = bool.Parse(dtOriginalGV.Rows[i]["Internal"].ToString());
                    bool OriginalC = bool.Parse(dtOriginalGV.Rows[i]["Consultant"].ToString());
                    bool PChanged = (CurrentP != OriginalP);
                    bool IChanged = (CurrentI != OriginalI);
                    bool CChanged = (CurrentC != OriginalC);
                    
                    if (PChanged || IChanged || CChanged)
                    {
                        ChangeHapened = true;

                        if ((CurrentP || CurrentI || CurrentC) && (!OriginalP && !OriginalI && !OriginalC))
                            AddMedicalAccountRels(PhysicianID, CurrentID, CurrentP, CurrentI, CurrentC);
                        else
                        {
                            if (!CurrentP && !CurrentI && !CurrentC)
                                DeleteMedicalAccountRels(PhysicianID, CurrentID);
                            else
                                UpdateMedicalAccountRels(PhysicianID, CurrentID, CurrentP, CurrentI, CurrentC);
                        }
                    }
                }
            }
        }

        if (ChangeHapened)
        {
            ((Label)frmViewPhysicians.FindControl("lblErrors")).ForeColor = System.Drawing.Color.Green;
            if (CurrentUserInfo.UserRole != UsersRoles.User)
            {
                ((Label)frmViewPhysicians.FindControl("lblErrors")).Text = "Relations to Medical Accounts updated successfully!";
            }
            else
            {
                ((Label)frmViewPhysicians.FindControl("lblErrors")).Text = "Your request for updating relation(s) to medical accounts is/are in pending phase until acceptance from your manager";
            }
        }
    }

    protected void gvMedicalAccounts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((((CheckBox)e.Row.Cells[1].Controls[1]).Checked) || (((CheckBox)e.Row.Cells[2].Controls[1]).Checked) || (((CheckBox)e.Row.Cells[3].Controls[1]).Checked))
            {
                e.Row.CssClass = "GridhighlightedRowsStyle";
            }
        }
    }

    protected void ucTransButtons_btnCancelEvent(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        BindPhysiciasView(false);
        BindgvMedicalAccounts(false);
        LoadScores(false);
        ((Label)frmViewPhysicians.FindControl("lblErrors")).Text = "";
        ((System.Web.UI.HtmlControls.HtmlTable)(frmViewPhysicians.FindControl("tblScore"))).Visible = true;
        AdjustReadOnlyFormStatus(true);
        AdjustDropDownListsSelection();
        AdjustTransButtons(false);
        lblmsg.Visible = false;
    }


    #endregion

    #region Page Controls Handler

    private void AdjustDropDownListsSelection()
    {
        //((DropDownList)frmViewPhysicians.FindControl("ddlBrick")).SelectedValue = ((TextBox)frmViewPhysicians.FindControl("txtBrick")).Text;
        ((DropDownList)frmViewPhysicians.FindControl("ddlTitle")).SelectedValue = ((TextBox)frmViewPhysicians.FindControl("txtTitle")).Text;
        ((DropDownList)frmViewPhysicians.FindControl("ddlSpeciality")).SelectedValue = ((TextBox)frmViewPhysicians.FindControl("txtSpeciality")).Text;
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
                ((CheckBox)row.Cells[2].Controls[1]).Enabled = Flag;
                ((CheckBox)row.Cells[3].Controls[1]).Enabled = Flag;
                if (Reset)
                {
                    ((CheckBox)row.Cells[1].Controls[1]).Checked = Reset;
                    ((CheckBox)row.Cells[2].Controls[1]).Checked = Reset;
                    ((CheckBox)row.Cells[3].Controls[1]).Checked = Reset;
                }
                if (NewEntry)
                {
                    row.BackColor = System.Drawing.Color.Transparent;
                    ((CheckBox)row.Cells[1].Controls[1]).Checked = Reset;
                    ((CheckBox)row.Cells[2].Controls[1]).Checked = Reset;
                    ((CheckBox)row.Cells[3].Controls[1]).Checked = Reset;
                }
            }
        }

    }

    private void ResetFormtxtboxes()
    {
        ((TextBox)frmViewPhysicians.FindControl("txtPhysicianName")).Text = "";
        ((TextBox)frmViewPhysicians.FindControl("txtAKA")).Text = "";
        ((TextBox)frmViewPhysicians.FindControl("txtMobile")).Text = "";
        ((TextBox)frmViewPhysicians.FindControl("txtEmail")).Text = "";
        ((TextBox)frmViewPhysicians.FindControl("txtPostalCode")).Text = "";
        ((TextBox)frmViewPhysicians.FindControl("txtComment")).Text = "";
        ((CheckBox)frmViewPhysicians.FindControl("chkOwnPrivateClinic")).Enabled = true;
        ((CheckBox)frmViewPhysicians.FindControl("chkOwnPrivateClinic")).Checked = false;

    }

    protected void AdjustReadOnlyFormStatus(bool Flag)
    {
        ((TextBox)frmViewPhysicians.FindControl("txtPhysicianName")).ReadOnly = Flag;
        ((TextBox)frmViewPhysicians.FindControl("txtAKA")).ReadOnly = Flag;
        
        ((DropDownList)frmViewPhysicians.FindControl("ddlTitle")).Enabled = !Flag;
        ((DropDownList)frmViewPhysicians.FindControl("ddlBrick")).Enabled = !Flag;
        ((DropDownList)frmViewPhysicians.FindControl("ddlSpeciality")).Enabled = !Flag;
        ((CheckBox)frmViewPhysicians.FindControl("chkOwnPrivateClinic")).Enabled = !Flag;
        ((TextBox)frmViewPhysicians.FindControl("txtMobile")).ReadOnly = Flag;
        ((TextBox)frmViewPhysicians.FindControl("txtEmail")).ReadOnly = Flag;
        ((TextBox)frmViewPhysicians.FindControl("txtPostalCode")).ReadOnly = Flag;
        ((TextBox)frmViewPhysicians.FindControl("txtComment")).ReadOnly = Flag;
    }

    #endregion

    #region gvScores Events

    protected void LoadScores(bool ShowAll)
    {
        LoadScoresGridView(ShowAll);
        CreatLineChart(FusionLineChart.Line2D);
        
        if (!String.IsNullOrEmpty(CurrentQueryStringsValues.TransType))
        {
            if (CurrentQueryStringsValues.TransType == "Update" || CurrentQueryStringsValues.TransType == "Add")
            {
                ((GridView)(frmViewPhysicians.FindControl("gvScores"))).Enabled = false;
               
            }
        }
    }
    private void CreatLineChart(string CharType)
    {
        if (((GridView)(frmViewPhysicians.FindControl("gvScores"))).Rows.Count > 0)
        {
            FusionLineChart lineChart = new FusionLineChart();
            lineChart.showNames = true;
            lineChart.subCaption = "";
            lineChart.caption = "";
            lineChart.yAxisName = "Total Scores";
            lineChart.xAxisName = "Score Date";
            lineChart.yAxisMaxValue = 100;
            //
            string chartHtml = lineChart.CreateSetElement(BuildChartData(false), CharType, ((HtmlGenericControl)(frmViewPhysicians.FindControl("divScoresChart"))).ClientID, false, "", "StrScoreDate", "Total", "StrScoreDate", "", "", false, 400, 300);
            ((HtmlGenericControl)(frmViewPhysicians.FindControl("divScoresChart"))).InnerHtml = chartHtml;
        }
    }
    protected void ddlChartType_SelectedIndexChanged(object sender, EventArgs e)
    {
        CreatLineChart();
    }
    private void CreatLineChart()
    {

        switch (((DropDownList)(frmViewPhysicians.FindControl("ddlChartType"))).SelectedValue)
        {
            case "Area2D":
                CreatLineChart(FusionLineChart.Area2D);
                break;
            case "Bar2D":
                CreatLineChart(FusionLineChart.Bar2D);
                break;
            case "Line2D":
                CreatLineChart(FusionLineChart.Line2D);
                break;
            default:
                break;
        }
    }
    private DataTable BuildChartData(bool ShowAll)
    {
            return SelectPhysicianScoresChart(int.Parse(frmViewPhysicians.DataKey["PhysicianID"].ToString()), ShowAll);
    }
    protected void LoadScoresGridView(bool ShowAll)
    {
        if (CurrentQueryStringsValues.TransType == "Update")
        {
            ((GridView)(frmViewPhysicians.FindControl("gvScores"))).DataSource = SelectPhysicianScores(int.Parse(CurrentQueryStringsValues.ID), ShowAll);
        }
        else
        {
            ((GridView)(frmViewPhysicians.FindControl("gvScores"))).DataSource = SelectPhysicianScores(int.Parse(frmViewPhysicians.DataKey["PhysicianID"].ToString()), ShowAll);
        }
        ((GridView)(frmViewPhysicians.FindControl("gvScores"))).DataBind();

        if (((GridView)(frmViewPhysicians.FindControl("gvScores"))).Rows.Count > 0)
        {
            ((TextBox)((GridView)(frmViewPhysicians.FindControl("gvScores"))).FooterRow.FindControl("txtScoreDate")).Text = DateTime.Today.ToShortDateString();
        }
        else 
        {
            ((DropDownList)(frmViewPhysicians.FindControl("ddlChartType"))).Enabled = false;
            ((GridView)(frmViewPhysicians.FindControl("gvScores"))).Enabled = false;
        }
    }
    protected void btnAddScores_Click(object sender, EventArgs e)
    {
        if (!IsTodayScoresExist())
        {
            decimal P, G, I, Additional;
            if (((GridView)(frmViewPhysicians.FindControl("gvScores"))).Rows.Count > 0)
            {
                P = decimal.Parse(((TextBox)((GridView)(frmViewPhysicians.FindControl("gvScores"))).FooterRow.FindControl("txtNewPotential")).Text);
                G = decimal.Parse(((TextBox)((GridView)(frmViewPhysicians.FindControl("gvScores"))).FooterRow.FindControl("txtNewGrade")).Text);
                I = decimal.Parse(((TextBox)((GridView)(frmViewPhysicians.FindControl("gvScores"))).FooterRow.FindControl("txtNewInference")).Text);
                Additional = decimal.Parse(((TextBox)((GridView)(frmViewPhysicians.FindControl("gvScores"))).FooterRow.FindControl("txtNewAdditional")).Text);
            }
            else
            {
                DetailsView emptyScores = (DetailsView)Session["emptyScores"];
                P = decimal.Parse(((TextBox)emptyScores.Rows[0].FindControl("txtboxInsertP")).Text);
                G = decimal.Parse(((TextBox)emptyScores.Rows[0].FindControl("txtboxInsertG")).Text);
                I = decimal.Parse(((TextBox)emptyScores.Rows[0].FindControl("txtboxInsertI")).Text);
                Additional = decimal.Parse(((TextBox)emptyScores.Rows[0].FindControl("txtboxInsertAdd")).Text);

            }


            if (P + G + I + Additional <= 100)
            {
                int NewPhysicianScoreID = 0;
                int Result = AddPhysicianScores(int.Parse(frmViewPhysicians.DataKey["PhysicianID"].ToString()),
                    P, G, I, Additional, DateTime.Today, out NewPhysicianScoreID);
                if (Result == 1)
                {
                    LoadScoresGridView(false);
                    CreatLineChart();
                    ((Label)frmViewPhysicians.FindControl("lblErrors")).ForeColor = System.Drawing.Color.Green;
                    ((Label)frmViewPhysicians.FindControl("lblErrors")).Text = "New scores added successfully!";
                }
                else
                {
                    if (Result == 2)
                    {
                        LoadScoresGridView(false);
                        CreatLineChart();

                        // Added Requested // Pending Request
                        ((Label)frmViewPhysicians.FindControl("lblErrors")).ForeColor = System.Drawing.Color.Green;
                        ((Label)frmViewPhysicians.FindControl("lblErrors")).Text = "Your request for adding new scores is in pending phase until acceptance from your manager";
                    }
                    else
                    {
                        // Error
                        ((Label)frmViewPhysicians.FindControl("lblErrors")).ForeColor = System.Drawing.Color.Red;
                        ((Label)frmViewPhysicians.FindControl("lblErrors")).Text = "Failed to perform this operation.";
                    }
                }
            }
            else
            {
                ((Label)frmViewPhysicians.FindControl("lblErrors")).ForeColor = System.Drawing.Color.Red;
                ((Label)frmViewPhysicians.FindControl("lblErrors")).Text = "Total score can't be greater than 100.";
            }
        }
        else
        {
            ((Label)frmViewPhysicians.FindControl("lblErrors")).ForeColor = System.Drawing.Color.Red;
            ((Label)frmViewPhysicians.FindControl("lblErrors")).Text = "You can add only one scores record for each day.";
        }
    }
    private bool IsTodayScoresExist()
    {
        foreach (GridViewRow gvr in ((GridView)(frmViewPhysicians.FindControl("gvScores"))).Rows)
        {
            if (gvr.RowType == DataControlRowType.DataRow)
            {
                if (DateTime.Parse(((Label)gvr.FindControl("lblScoreDate")).Text) == DateTime.Today)
                    return true;
            }
        }

        return false;
    }
    protected void gvScores_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int result = DeletePhysicianScores(int.Parse(((GridView)(frmViewPhysicians.FindControl("gvScores"))).DataKeys[e.RowIndex].Values["ScoreID"].ToString()));
        if (result == 0)
        {
            ((Label)frmViewPhysicians.FindControl("lblErrors")).ForeColor = System.Drawing.Color.Red;
            ((Label)frmViewPhysicians.FindControl("lblErrors")).Text = "Can't delete these scores.";
        }
        else if (result == 1)
        {
            // Updated //
            LoadScoresGridView(false);
            CreatLineChart();
            ((Label)frmViewPhysicians.FindControl("lblErrors")).ForeColor = System.Drawing.Color.Green;
            ((Label)frmViewPhysicians.FindControl("lblErrors")).Text = "Scores deleted successfully!";
        }
        else
        {
            LoadScoresGridView(false);
            CreatLineChart();
            // Updated Requested // Pending Request
            ((Label)frmViewPhysicians.FindControl("lblErrors")).ForeColor = System.Drawing.Color.Green;
            ((Label)frmViewPhysicians.FindControl("lblErrors")).Text = "Your request for deleting scores is in pending phase until acceptance from your manager";
        }
            
    }
    protected void gvScores_RowEditing(object sender, GridViewEditEventArgs e)
    {
        ((GridView)(frmViewPhysicians.FindControl("gvScores"))).EditIndex = e.NewEditIndex;
        LoadScoresGridView(false);
        ((Label)frmViewPhysicians.FindControl("lblErrors")).Text = "";
    }
    protected void gvScores_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        ((GridView)(frmViewPhysicians.FindControl("gvScores"))).EditIndex = -1;
        LoadScoresGridView(false);
        ((Label)frmViewPhysicians.FindControl("lblErrors")).Text = "";
    }
    
    protected void gvScores_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.EmptyDataRow)
        {
            DetailsView emptyScores = (DetailsView)e.Row.FindControl("DetailsView1");
            Session["emptyScores"] = emptyScores;

        }
    }
    
    protected void gvScores_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        decimal P = decimal.Parse(((TextBox)((GridView)(frmViewPhysicians.FindControl("gvScores"))).Rows[e.RowIndex].FindControl("txtPotential")).Text);
        decimal G = decimal.Parse(((TextBox)((GridView)(frmViewPhysicians.FindControl("gvScores"))).Rows[e.RowIndex].FindControl("txtGrade")).Text);
        decimal I = decimal.Parse(((TextBox)((GridView)(frmViewPhysicians.FindControl("gvScores"))).Rows[e.RowIndex].FindControl("txtInference")).Text);
        decimal Additional = decimal.Parse(((TextBox)((GridView)(frmViewPhysicians.FindControl("gvScores"))).Rows[e.RowIndex].FindControl("txtAdditional")).Text);
        int ScoreID = int.Parse(((GridView)(frmViewPhysicians.FindControl("gvScores"))).DataKeys[e.RowIndex].Values["ScoreID"].ToString());
        if (P + G + I + Additional <= 100)
        {
            int PhysicianID = int.Parse(frmViewPhysicians.DataKey["PhysicianID"].ToString());
            int result = UpdatePhysicianScores(ScoreID, P, G, I, Additional, PhysicianID);
            if (result == 0)
            {
                ((Label)frmViewPhysicians.FindControl("lblErrors")).ForeColor = System.Drawing.Color.Red;
                ((Label)frmViewPhysicians.FindControl("lblErrors")).Text = "Can't update these scores.";
            }
            else if (result == 1)
            {
                // Updated //
                ((GridView)(frmViewPhysicians.FindControl("gvScores"))).EditIndex = -1;
                LoadScoresGridView(false);
                CreatLineChart();
                ((Label)frmViewPhysicians.FindControl("lblErrors")).ForeColor = System.Drawing.Color.Green;
                ((Label)frmViewPhysicians.FindControl("lblErrors")).Text = "Scores updated successfully!";
            }
            else
            {
                // Updated Requested // Pending Request
                ((GridView)(frmViewPhysicians.FindControl("gvScores"))).EditIndex = -1;
                LoadScoresGridView(false);
                CreatLineChart();
                ((Label)frmViewPhysicians.FindControl("lblErrors")).ForeColor = System.Drawing.Color.Green;
                ((Label)frmViewPhysicians.FindControl("lblErrors")).Text = "Your request for updating scores is in pending phase until acceptance from your manager";
            }
        }
        else
        {
            ((Label)frmViewPhysicians.FindControl("lblErrors")).ForeColor = System.Drawing.Color.Red;
            ((Label)frmViewPhysicians.FindControl("lblErrors")).Text = "Total score can't be greater than 100.";
        }
    }

    protected void gvScores_DataBound(object sender, EventArgs e)
    {
        if (CurrentUserInfo.UserRole != UsersRoles.SuperAdmin)
        {
            ((GridView)(frmViewPhysicians.FindControl("gvScores"))).Columns[7].Visible = false;
        }
    }
    #endregion

    #region Search Handler

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        string[] Names = new string[0];
        string ErrMsg = "";
        Physicians currentPage = new Physicians();
        Names = currentPage.GetAllEntitiesNamesByUser("Physicians", prefixText, out ErrMsg);
        return Names;
    }

    protected void txtSearchName_TextChanged(object sender, EventArgs e)
    {
        string PhysiciansName = ((TextBox)frmViewPhysicians.FindControl("txtSearchName")).Text;
        frmViewPhysicians.PageIndex = GetCertainPageByName(PhysiciansName, false);
        BindPhysiciasView(false);
        LoadScores(false);
        BindgvMedicalAccounts(false);
        AdjustDropDownListsSelection();
        AdjustTransButtons(false);
        ((TextBox)frmViewPhysicians.FindControl("txtSearchName")).Text = "";
        lblmsg.Visible = false;
    }
    
    #endregion

    
}
