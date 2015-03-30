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
using Pharma.FMT.BLL;


public partial class FMT_FMTReport : PlansBLL
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        
        InitiateEventsHandlers();
        
        if (!IsPostBack) 
        {
            DateTime PlanDate = DateTime.Now;
            txtPlanDate.Attributes.Add("ReadOnly", "ReadOnly");
            if (Session["PlanDate"] != null)
            {
                PlanDate = Convert.ToDateTime(Session["PlanDate"]);
            }
            txtPlanDate.Text = PlanDate.ToShortDateString();
            //--
            GetEmpData();
            GetWeekVisits(PlanDate);
            HandleFeedBackControls();
        }
    }

    #endregion

    #region Report Link

    private string FMTReportLink(string StartDateOfWeek, string EndDateOfWeek)
    {
        string RepID = System.Configuration.ConfigurationManager.AppSettings["ReportWriterFMTReportID"].ToString().Trim();
        string EncryptedQSRepID = mEncryptQueryString(System.Configuration.ConfigurationManager.AppSettings["ReportWriterAppID"].ToString().Trim() + "&IsAdmin=1&ContactID=" + 96 + "&repID=" + RepID + "&StartDateOfWeek=" + StartDateOfWeek + "&EndDateOfWeek=" + EndDateOfWeek + "&EmpID=" + Session["EmpID"].ToString());
        string EncryptedReportWriterURLRepID = System.Configuration.ConfigurationManager.AppSettings["ReportWriterURL"].ToString() + "?data=" + EncryptedQSRepID.ToString();
        return EncryptedReportWriterURLRepID;
    }

    #endregion
 
    #region Get Employee Data

    private void GetEmpData()
    {
        int EmpID = int.Parse(Session["EmpID"].ToString());
        DataRow row = GetEmployeeInfo(EmpID);
        lblMRName.Text = row["EmpName"].ToString();
        lblMRTitle.Text = row["Title"].ToString();
    }

    #endregion

    #region GridViews Binding handler
 
    private void BindgvDayPlanVisits(GridView gvName,HtmlTable TableName, int PlanID)
    {
        if (PlanID > 0)
        {
            gvName.DataSource = GetVisitFeedBack(PlanID);
            gvName.DataBind();
        }
        else 
        {
            gvName.DataSource = null;
            gvName.DataBind();
        }

        if (gvName.Rows.Count > 0)
        {
            TableName.Visible = true;
        }
        else 
        {
            TableName.Visible = false;
        }

    }

    #endregion

    #region HandleFeedBackControls

    private void HandleFeedBackControls()
    {
        lblfeedbackmsg.Visible = false;
        if (gvSunVisits.Rows.Count > 0 || gvMonVisits.Rows.Count > 0 || gvTueVisits.Rows.Count > 0 || gvWedVisits.Rows.Count > 0 || gvThurVisits.Rows.Count > 0 || gvFriVisits.Rows.Count > 0 || gvSatVisits.Rows.Count > 0)
        {
            lblNoPlans.Visible = false;
            btnSaveFeedBack.Visible = true;
            // check here to set tblPlanFields = Visible if the given date was in week range
            DateTime StartDateOfWeek = StartDayOfWeek(Convert.ToDateTime(txtPlanDate.Text), ApplicationDayOfWeek.Saturday);
            DateTime EndDateOfWeek = StartDateOfWeek.AddDays(6);
            DateTime StartDateOfCurrentWeek = StartDayOfWeek(Convert.ToDateTime(DateTime.Today.ToShortDateString()), ApplicationDayOfWeek.Saturday);
            //
            //----------------------------------
            if (StartDateOfCurrentWeek < StartDateOfWeek)
            {
                DisplayPlanFieldsPanel(false);
            }
            else
            {
                DisplayPlanFieldsPanel(true);
                PopulateFMTModules();
                IFormatProvider IFP = new System.Globalization.CultureInfo("en-US");
                lnkPrint.NavigateUrl = FMTReportLink(StartDateOfCurrentWeek.ToString(IFP), EndDateOfWeek.ToString(IFP));
                lnkPrint.Visible = true;
            }
        }
        else
        {

            DisplayPlanFieldsPanel(false);
            lblNoPlans.Visible = true;
        }

    }

    #endregion

    private void DisplayPlanFieldsPanel(bool Flag)
    {
        tblPlanFields.Visible = Flag;
        lnkPrint.Visible = Flag;
        btnSaveFeedBack.Visible = Flag;
    }

    #region Set and process Week Range

    private DateTime StartDayOfWeek(DateTime date, ApplicationDayOfWeek startDay)
    {

        if (date.DayOfWeek >= ApplicationToSystemDay(startDay))

            return date.AddDays((int)ApplicationDayOfWeek.Saturday - (int)SystemToApplicationDay(date.DayOfWeek));

        else

            return date.AddDays(7 - (int)ApplicationDayOfWeek.Saturday - (int)SystemToApplicationDay(date.DayOfWeek));

    }

    private int GetPlanID(DateTime PlanDate, bool ShowAll)
    {
        this.Culture = "ar-EG";
        int result = 0;
        int EmpID = int.Parse(Session["EmpID"].ToString());
        //
        DataTable dt = SelectPlanVisits(PlanDate, EmpID, ShowAll); // Get PlanID and details in this function
        if (dt.Rows.Count > 0)
        {
            result = int.Parse(dt.Rows[0]["PlanID"].ToString()); // The Returned PlanID
        }
        return result;
    }

    private void GetWeekVisits(DateTime dayDateVar)
    {
        this.Culture = "ar-EG";
        string[] WeekDayNames = new string[7];
        string DayName;
        DateTime DayDate;
        int subDay = 0;
        bool WeekEndFlag = false;
        DateTime WeekEndDate = DateTime.Today;
        DateTime WeekStartDate = DateTime.Today;
        ddlPlanDate.Items.Clear();
        ListItem[] lis = new ListItem[7];

        for (int i = 0; i < WeekDayNames.Length; i++)
        {
            ListItem li = new ListItem();
            //
            DayName = dayDateVar.AddDays(i).DayOfWeek.ToString();
            if (WeekEndFlag == false)
            {
                DayDate = dayDateVar.AddDays(i).Date;
            }
            else
            {
                WeekStartDate = WeekEndDate.AddDays(-7);
                subDay = subDay + 1;
                DayDate = WeekStartDate.AddDays(subDay).Date;
            }

            switch (dayDateVar.AddDays(i).DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    ((LinkButton)tblSunVisits.FindControl("lnkbtnSatVisits")).Text = ":: " + ApplicationDayOfWeek.Saturday.ToString().Remove(3, 5) + " " + DayDate.ToShortDateString() + " Visits ::";
                    ((LinkButton)tblSunVisits.FindControl("lnkbtnSatVisits")).ToolTip = DayDate.ToShortDateString();
                    //
                    li.Text = ApplicationDayOfWeek.Saturday.ToString().Remove(3, 5) + " " + DayDate.ToShortDateString();
                    li.Value = DayDate.ToShortDateString();
                    if (DayDate > DateTime.Today)
                        li.Enabled = false;
                    lis[0] = li;
                    //
                    BindgvDayPlanVisits(gvSatVisits, tblSatVisits, GetPlanID(DayDate, true));
                    if (DateTime.Today.CompareTo(DayDate.AddDays(2)) >= 0)
                    {
                        foreach (GridViewRow gvRow in gvSatVisits.Rows)
                        {
                            gvRow.Cells[2].Enabled = false;
                            gvRow.Cells[3].Enabled = false;
                        }
                    }
                    break;
                case DayOfWeek.Sunday:
                    ((LinkButton)tblSunVisits.FindControl("lnkbtnSunVisits")).Text = ":: " + ApplicationDayOfWeek.Sunday.ToString().Remove(3, 3) + " " + DayDate.ToShortDateString() + " Visits ::";
                    ((LinkButton)tblSunVisits.FindControl("lnkbtnSunVisits")).ToolTip = DayDate.ToShortDateString();
                    //
                    li.Text = ApplicationDayOfWeek.Sunday.ToString().Remove(3, 3) + " " + DayDate.ToShortDateString();
                    li.Value = DayDate.ToShortDateString();
                    if (DayDate > DateTime.Today)
                    {
                        li.Enabled = false;
                    }
                    lis[1] = li;
                    //
                    BindgvDayPlanVisits(gvSunVisits, tblSunVisits, GetPlanID(DayDate, true));
                    if (DateTime.Today.CompareTo(DayDate.AddDays(2)) >= 0)
                    {
                        foreach (GridViewRow gvRow in gvSunVisits.Rows)
                        {
                            gvRow.Cells[2].Enabled = false;
                            gvRow.Cells[3].Enabled = false;
                        }
                    }
                    break;
                case DayOfWeek.Monday:
                    ((LinkButton)tblSunVisits.FindControl("lnkbtnMonVisits")).Text = ":: " + ApplicationDayOfWeek.Monday.ToString().Remove(3, 3) + " " + DayDate.ToShortDateString() + " Visits ::";
                    ((LinkButton)tblSunVisits.FindControl("lnkbtnMonVisits")).ToolTip = DayDate.ToShortDateString();
                    //
                    li.Text = ApplicationDayOfWeek.Monday.ToString().Remove(3, 3) + " " + DayDate.ToShortDateString();
                    li.Value = DayDate.ToShortDateString();
                    if (DayDate > DateTime.Today)
                        li.Enabled = false;
                    lis[2] = li; 
                    //
                    BindgvDayPlanVisits(gvMonVisits, tblMonVisits, GetPlanID(DayDate, true));
                    if (DateTime.Today.CompareTo(DayDate.AddDays(2)) >= 0)
                    {
                        foreach (GridViewRow gvRow in gvMonVisits.Rows)
                        {
                            gvRow.Cells[2].Enabled = false;
                            gvRow.Cells[3].Enabled = false;
                        }
                    }
                    break;
                case DayOfWeek.Tuesday:
                    ((LinkButton)tblSunVisits.FindControl("lnkbtnTueVisits")).Text = ":: " + ApplicationDayOfWeek.Tuesday.ToString().Remove(3, 4) + " " + DayDate.ToShortDateString() + " Visits ::";
                    ((LinkButton)tblSunVisits.FindControl("lnkbtnTueVisits")).ToolTip = DayDate.ToShortDateString();
                    //
                    li.Text = ApplicationDayOfWeek.Tuesday.ToString().Remove(3, 4) + " " + DayDate.ToShortDateString();
                    li.Value = DayDate.ToShortDateString();
                    if (DayDate > DateTime.Today)
                        li.Enabled = false;
                    lis[3] = li; 
                    //
                    BindgvDayPlanVisits(gvTueVisits, tblTueVisits, GetPlanID(DayDate, true));
                    if (DateTime.Today.CompareTo(DayDate.AddDays(2)) >= 0)
                    {
                        foreach (GridViewRow gvRow in gvTueVisits.Rows)
                        {
                            gvRow.Cells[2].Enabled = false;
                            gvRow.Cells[3].Enabled = false;
                        }
                    }
                    break;
                case DayOfWeek.Wednesday:
                    ((LinkButton)tblSunVisits.FindControl("lnkbtnWedVisits")).Text = ":: " + ApplicationDayOfWeek.Wednesday.ToString().Remove(3, 6) + " " + DayDate.ToShortDateString() + " Visits ::";
                    ((LinkButton)tblSunVisits.FindControl("lnkbtnWedVisits")).ToolTip = DayDate.ToShortDateString();
                    //
                    li.Text = ApplicationDayOfWeek.Wednesday.ToString().Remove(3, 6) + " " + DayDate.ToShortDateString();
                    li.Value = DayDate.ToShortDateString();
                    if (DayDate > DateTime.Today)
                        li.Enabled = false;
                    lis[4] = li; 
                    //
                    BindgvDayPlanVisits(gvWedVisits, tblWedVisits, GetPlanID(DayDate, true));
                    if (DateTime.Today.CompareTo(DayDate.AddDays(2)) >= 0)
                    {
                        foreach (GridViewRow gvRow in gvWedVisits.Rows)
                        {
                            gvRow.Cells[2].Enabled = false;
                            gvRow.Cells[3].Enabled = false;
                        }
                    }
                    break;
                case DayOfWeek.Thursday:
                    ((LinkButton)tblSunVisits.FindControl("lnkbtnThurVisits")).Text = ":: " + ApplicationDayOfWeek.Thursday.ToString().Remove(4, 4) + " " + DayDate.ToShortDateString() + " Visits ::";
                    ((LinkButton)tblSunVisits.FindControl("lnkbtnThurVisits")).ToolTip = DayDate.ToShortDateString();
                    //
                    li.Text = ApplicationDayOfWeek.Thursday.ToString().Remove(4, 4) + " " + DayDate.ToShortDateString();
                    li.Value = DayDate.ToShortDateString();
                    if (DayDate > DateTime.Today)
                        li.Enabled = false;
                    lis[5] = li; 
                    //
                    BindgvDayPlanVisits(gvThurVisits, tblThurVisits, GetPlanID(DayDate, true));
                    if (DateTime.Today.CompareTo(DayDate.AddDays(2)) >= 0)
                    {
                        foreach (GridViewRow gvRow in gvThurVisits.Rows)
                        {
                            gvRow.Cells[2].Enabled = false;
                            gvRow.Cells[3].Enabled = false;
                        }
                    }
                    break;
                case DayOfWeek.Friday:
                    ((LinkButton)tblSunVisits.FindControl("lnkbtnFriVisits")).Text = ":: " + ApplicationDayOfWeek.Friday.ToString().Remove(3, 3) + " " + DayDate.ToShortDateString() + " Visits ::";
                    ((LinkButton)tblSunVisits.FindControl("lnkbtnFriVisits")).ToolTip = DayDate.ToShortDateString();
                    //
                    li.Text = ApplicationDayOfWeek.Friday.ToString().Remove(3, 3) + " " + DayDate.ToShortDateString();
                    li.Value = DayDate.ToShortDateString();
                    if (DayDate > DateTime.Today)
                        li.Enabled = false;
                    lis[6] = li; 
                    //
                    BindgvDayPlanVisits(gvFriVisits, tblFriVisits, GetPlanID(DayDate, true));
                    if (DateTime.Today.CompareTo(DayDate.AddDays(2)) >= 0)
                    {
                        foreach (GridViewRow gvRow in gvFriVisits.Rows)
                        {
                            gvRow.Cells[2].Enabled = false;
                            gvRow.Cells[3].Enabled = false;
                        }
                    }
                    WeekEndFlag = true;
                    WeekEndDate = DayDate;
                    break;
            }
        }
        ddlPlanDate.Items.AddRange(lis);
    }

    protected void txtPlanDate_TextChanged(object sender, EventArgs e)
    {
        // For The Visit FeedBack Page
        Session["PlanDate"] = txtPlanDate.Text;
        //
        GetWeekVisits(Convert.ToDateTime(txtPlanDate.Text));
        HandleFeedBackControls();
    }

    #endregion

    #region Save FeedBack

    protected void btnSaveFeedBack_Click(object sender, ImageClickEventArgs e)
    {
        if (gvSunVisits.Visible)
            SaveFeedBack(gvSunVisits);

        if (gvMonVisits.Visible)
            SaveFeedBack(gvMonVisits);
        
        if (gvTueVisits.Visible)
            SaveFeedBack(gvTueVisits);
        
        if (gvWedVisits.Visible)
            SaveFeedBack(gvWedVisits);
        
        if (gvThurVisits.Visible)
            SaveFeedBack(gvThurVisits);
        
        if (gvFriVisits.Visible)
            SaveFeedBack(gvFriVisits);
        
        if (gvSatVisits.Visible)
            SaveFeedBack(gvSatVisits);

    }

    private void SaveFeedBack(GridView gvName) 
    {
        bool SaveDone = false;
        for (int i = 0; i < gvName.Rows.Count; i++)
        {
            int VisitID = int.Parse(gvName.DataKeys[i].Values["VisitID"].ToString().Trim());
            bool IsVisited = Convert.ToBoolean(((RadioButtonList)(gvName.Rows[i].Cells[2].FindControl("rblIsVisited"))).SelectedValue);
            string VisitFeedback = ((TextBox)(gvName.Rows[i].Cells[3].FindControl("txtFeedBack"))).Text;
            SaveDone = SaveVisitFeedBack(VisitID, VisitFeedback, IsVisited);
        }
        if (SaveDone)
            lblfeedbackmsg.Visible = true;

    }

    #endregion

    #region  ListBoxes and dropdowns controls Handlers

    private void PopulateFMTModules()
    {
        ddlAddItem.DataSource = SelectModulesForVisits();
        ddlAddItem.DataTextField = "ModuleType";
        ddlAddItem.DataValueField = "ModuleID";
        ddlAddItem.DataBind();
        ddlAddItem.Items.Insert(0, "Select");
        ddlAddItem.SelectedIndex = 0;
    }

    private void PopulateAllMRBricks()
    {
        //ddlAllUserBricks.DataSource = SelectBricksForUser(Convert.ToInt32(ddlMRList.SelectedItem.Value));
        //ddlAllUserBricks.DataTextField = "BrickName";
        //ddlAllUserBricks.DataValueField = "BrickID";
        //ddlAllUserBricks.DataBind();
    }

    private void PopulateCurrentPlanBricks()
    {
        //this.Culture = "ar-EG";
        //ddlPlanUserBricks.DataSource = SelectBricksForUserPlan(Convert.ToDateTime(TabPanel1.HeaderText), int.Parse(ddlMRList.SelectedValue));
        //ddlPlanUserBricks.DataTextField = "BrickName";
        //ddlPlanUserBricks.DataValueField = "BrickName";
        //ddlPlanUserBricks.DataBind();
    }

    //protected void lbProducts_DataBound(object sender, EventArgs e)
    //{
    //    if (lbProducts.Items.Count > 0)
    //    {
    //        lbProducts.Items[0].Selected = true;
    //    }
    //}


    protected void ddlAddItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAddItem.SelectedItem.Text != "Select")
        {
            if (ddlAddItem.SelectedItem.Text != "Other")
            {
                //New Mode //
                if (ddlAddItem.SelectedItem.Text == "Pharmacies" || ddlAddItem.SelectedItem.Text == "PrivateClinics")
                {

                    lbSubModule.DataSource = SelectEntitiesList(ddlAddItem.SelectedItem.Text, Session["EmpID"].ToString());
                    lbSubModule.DataTextField = "EntityName";
                    lbSubModule.DataValueField = "EntityID";
                    lbSubModule.DataBind();
                    lbSubModule.SelectionMode = ListSelectionMode.Multiple;
                    //
                    rfvlbSubModule.Enabled = true;
                    rfvlbSubModule.ErrorMessage = ddlAddItem.SelectedItem.Text + " is required";
                    lblSubEntityName.Visible = true;
                    lblSubEntityName.Text = ddlAddItem.SelectedItem.Text + " List:";
                    lbSubModule.Visible = true;
                    //
                    txtOthers.Visible = false;
                    rfvtxtOthers.Enabled = false;
                    lblMentionOther.Visible = false;
                    ddlAddRel.Visible = false;
                    rfvddlAddRel.Enabled = false;
                    lblEntityName.Visible = false;
                    ddlAddRel.Visible = false;
                }
                else
                {
                    //New Mode //
                    lbSubModule.Visible = false;
                    lblSubEntityName.Visible = false;
                    //
                    ddlAddRel.DataSource = SelectEntitiesList(ddlAddItem.SelectedItem.Text, Session["EmpID"].ToString());
                    ddlAddRel.DataBind();
                    ddlAddRel.Visible = true;
                    rfvddlAddRel.Enabled = true;
                    lblEntityName.Visible = true;
                    lblEntityName.Text = ddlAddItem.SelectedItem.Text + " List:";
                    txtOthers.Visible = false;
                    rfvtxtOthers.Enabled = false;
                    lblMentionOther.Visible = false;
                }
            }
            else
            {
                txtOthers.Visible = true;
                rfvtxtOthers.Enabled = true;
                lblMentionOther.Visible = true;
                HideDDLControls();
            }
        }
        else
        {
            txtOthers.Visible = false;
            rfvtxtOthers.Enabled = false;
            lblMentionOther.Visible = false;
            HideDDLControls();
        }
    }

    protected void ddlAddRel_DataBound(object sender, EventArgs e)
    {

        if (ddlAddRel.Items.Count > 0)
        {
            if (ddlAddItem.SelectedItem.Text == "MedicalAccounts")
            {
                ddlAddRel.AutoPostBack = true;
                lblSubEntityName.Text = "Physicians Names:";
                lblSubEntityName.Visible = true;
                lbSubModule.Visible = true;
                rfvlbSubModule.ErrorMessage = lblSubEntityName.Text + " is required";
                rfvlbSubModule.Enabled = true;
                //
                lbSubModule.Items.Clear();
                lbSubModule.DataSource = GetPhysiciansNamesByMedicalAccount(int.Parse(ddlAddRel.SelectedValue));
                lbSubModule.DataTextField = "PhysicianName";
                lbSubModule.DataValueField = "PhysicianID";
                lbSubModule.DataBind();
                lbSubModule.SelectionMode = ListSelectionMode.Multiple;
                //
            }
            else if (ddlAddItem.SelectedItem.Text == "Distributors")
            {
                ddlAddRel.AutoPostBack = true;
                lblSubEntityName.Text = "Branches Names:";
                lblSubEntityName.Visible = true;
                rfvlbSubModule.ErrorMessage = lblSubEntityName.Text + " is required";
                lbSubModule.Visible = true;
                rfvlbSubModule.Enabled = true;
                //
                lbSubModule.Items.Clear();
                //
                lbSubModule.DataSource = GetBranchesNamesByDistributor(int.Parse(ddlAddRel.SelectedValue), Convert.ToInt32(Session["EmpID"]));
                lbSubModule.DataTextField = "BranchName";
                lbSubModule.DataValueField = "BranchID";
                lbSubModule.DataBind();
                lbSubModule.SelectionMode = ListSelectionMode.Single;
                //
            }
            else
            {
                ddlAddRel.AutoPostBack = false;
                lbSubModule.Visible = false;
                rfvlbSubModule.Enabled = false;
                lblSubEntityName.Visible = false;
            }

        }
    }

    private void HideDDLControls()
    {
        ddlAddRel.Visible = false;
        rfvddlAddRel.Enabled = false;
        lblEntityName.Visible = false;
        lbSubModule.Visible = false;
        rfvlbSubModule.Enabled = false;
        lblSubEntityName.Visible = false;
    }

    protected void ddlMRList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //// For The Visit FeedBack Page
        //Session["EmpID"] = ddlMRList.SelectedValue;
        ////
        //GetEmpData();
        //PopulateAllMRBricks();
        //HandleWeekPlanStatus();
        //ManageApprovalPanal();
        //btnctlTabChangedEvent_Click(this, null);
    }

    protected void ddlAllUserBricks_DataBound(object sender, EventArgs e)
    {
        //lblTotalBricksNo.Text = ddlAllUserBricks.Items.Count.ToString();
    }

    protected void ddlPlanUserBricks_DataBound(object sender, EventArgs e)
    {
        //lblPlanBricksNo.Text = ddlPlanUserBricks.Items.Count.ToString();
    }

    protected void ddlAddRel_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAddRel_DataBound(this, null);
    }


    #endregion

    #region Buttons Transactions Events

    private void InitiateEventsHandlers()
    {

        ucTransButtons.btnAddEvent += new EventHandler(ucTransButtons_btnAddEvent);
        ucTransButtons.btnCancelEvent += new EventHandler(ucTransButtons_btnCancelEvent);
        ucTransButtons.btnSaveEvent += new EventHandler(ucTransButtons_btnSaveEvent);
        // No need for edit and delete buttons in this page
        ((ImageButton)ucTransButtons.FindControl("btnEdit")).Visible = false;
        ((ImageButton)ucTransButtons.FindControl("btnDelete")).Visible = false;
        //// No need for CausesValidation for Add button in this page
        ((ImageButton)ucTransButtons.FindControl("btnAdd")).CausesValidation = false;
    }

    private void AdjustTransButtons(bool Flag)
    {
        ((ImageButton)ucTransButtons.FindControl("btnCancel")).Visible = Flag;
        ((ImageButton)ucTransButtons.FindControl("btnSave")).Visible = Flag;
        ((ImageButton)ucTransButtons.FindControl("btnAdd")).Visible = !Flag;
    }

    protected void ucTransButtons_btnAddEvent(object sender, EventArgs e)
    {
        AdjustReadOnlyFormStatus(false);
        AdjustTransButtons(true);
        ResetFormControls();
    }

    protected void ucTransButtons_btnSaveEvent(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            this.Culture = "ar-EG";
            
            bool MarketingMaterialsResult = false;
            for (int i = 0; i < gvMM.Rows.Count; i++)
            {
                if (((CheckBox)gvMM.Rows[i].FindControl("cbxSelect")).Checked)
                {
                    int Quantity = int.Parse(((TextBox)gvMM.Rows[i].FindControl("txtQuantity")).Text);
                    if (Quantity > 0)
                    {
                        MarketingMaterialsResult = true;
                        break;
                    }
                }
            }

            if (ddlAddItem.SelectedIndex != 0 && MarketingMaterialsResult == true)
            {
                // Form Data
                int ModuleID = int.Parse(ddlAddItem.SelectedValue.ToString());
                string ModuleName = ddlAddItem.SelectedItem.Text;
                //
                int NewPlanID = 0;
                int NewVisitID = 0;
                int VisitTypeID = int.Parse(ddlVType.SelectedValue.ToString());
                int EmpID = int.Parse(Session["EmpID"].ToString());
                //
                //
                bool ISPMShift = true;
                if (rblVisitShift.SelectedIndex == 0)
                    ISPMShift = false;
                //
                //
                int StartHour = GetShiftHour(int.Parse(ddlHour.SelectedValue), ISPMShift);
                int StartMinute = int.Parse(ddlMinute.SelectedValue);
                DateTime ST = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, StartHour, StartMinute, 0);
                //
                string SPAM = null, SPPM = null;
                DateTime? STAM = null, STPM = null;
                if (ISPMShift)
                {
                    SPPM = txtSP.Text;
                    STPM = ST;
                }
                else
                {
                    SPAM = txtSP.Text;
                    STAM = ST;
                }
                //
                int intDoubleVisit = int.Parse(rblDoubleVisit.SelectedValue);
                bool boolDoubleVisit = (intDoubleVisit != 0);

                // begain Switching here
                if (ModuleName == "MedicalAccounts" || ModuleName == "Distributors" || ModuleName == "Other")
                {
                    int ModuleRefID = 0;
                    if (ModuleName == "Other") // User Mention other Type
                    {
                        ModuleRefID = int.Parse(ddlAddItem.SelectedValue.ToString());
                    }
                    else // Medical Account or distributor
                    {
                        ModuleRefID = int.Parse(ddlAddRel.SelectedValue.ToString());
                    }

                    if (!IsPlanExists(Convert.ToDateTime(ddlPlanDate.SelectedValue), EmpID, out NewPlanID))
                    {
                        AddPlan(Convert.ToDateTime(ddlPlanDate.SelectedValue), EmpID, SPAM, STAM, SPPM, STPM, DateTime.Now, ModuleID, ModuleRefID, VisitTypeID, ISPMShift, txtOthers.Text, false, boolDoubleVisit, out NewPlanID, out NewVisitID);
                    }
                    else
                    {
                        // Add Visit //
                        AddVisit(NewPlanID, ModuleID, ModuleRefID, VisitTypeID, ISPMShift, txtOthers.Text, false, boolDoubleVisit, out NewVisitID);
                    }

                    // Add subModules for visit 
                    if (ddlAddItem.SelectedItem.Text == "MedicalAccounts" || ddlAddItem.SelectedItem.Text == "Distributors")
                    {
                        SaveListBoxItems(ddlAddItem.SelectedItem.Text, lbSubModule, NewVisitID);
                    }

                    //---------------Save Plan Scope -------------------------------------------------
                    //Save Products //
                    SaveProductsSamples(NewVisitID);
                    //SaveListBoxItems("Products", lbProducts, NewVisitID);
                    //Save MarketingMaterials
                    SaveMarketingMaterials(NewVisitID);

                }
                // Switching else // Pharmacies or PrivateClinics or any dynamic module to add later
                else // 
                {
                    if (!IsPlanExists(Convert.ToDateTime(ddlPlanDate.SelectedValue), EmpID, out NewPlanID))
                    {
                        AddPlan(Convert.ToDateTime(ddlPlanDate.SelectedValue), EmpID, SPAM, STAM, SPPM, STPM, DateTime.Now, false, out NewPlanID);
                    }
                    // Add one or more selected visits Visits //
                    for (int i = 0; i < lbSubModule.Items.Count; i++)
                    {
                        if (lbSubModule.Items[i].Selected)
                        {
                            //Begain save multi Pharmacies or PrivateClinics
                            AddVisit(NewPlanID, ModuleID, int.Parse(lbSubModule.Items[i].Value), VisitTypeID, ISPMShift, txtOthers.Text, false, boolDoubleVisit, out NewVisitID);
                            SaveProductsSamples(NewVisitID);
                            //SaveListBoxItems("Products", lbProducts, NewVisitID);
                            SaveMarketingMaterials(NewVisitID);
                        }
                    }
                }

                //------------------------------------------------------
                lblmsg.Text = "Visit Item Added Successfully, you can continue adding other visits or click on cancel to quit adding";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                lblmsg.Visible = true;
                // Rest starting point and starting time and txtOthers //
                txtSP.Text = "";
                txtOthers.Text = "";
                ddlHour.SelectedIndex = 11;
                ddlMinute.SelectedIndex = 0;
                // Disable to Add New starting point and starting time becuse he already did
                txtSP.ReadOnly = true;
                ddlHour.Enabled = false;
                ddlMinute.Enabled = false;
                //////////////////////////////////////////////////////////////
                //// Initate that its is a pending week plan for first entry //
                //lblPlanStatus.Text = " // Current week plan is Pending";
                //lblPlanStatus.ForeColor = System.Drawing.Color.Orange;
                //ViewState["WeekPlanStatus"] = "0";
                /////////////////////////////////////////////////////////////
                //------------------------------------------------------

            }
            else
            {
                lblmsg.Text = "";
                if (ddlAddItem.SelectedIndex == 0)
                {
                    lblmsg.Text = "Main module to add is required";
                }
                if (MarketingMaterialsResult == false)
                {
                    lblmsg.Text = lblmsg.Text + "<br> Marketing Materials to add is required";
                }
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Visible = true;
            }
            //--ReBind GVs -------------------------------
            GetWeekVisits(Convert.ToDateTime(txtPlanDate.Text));
            //
        }
    }

    private int GetShiftHour(int StartHour, bool ISPMShift)
    {
        if (ISPMShift)
        {
            if (StartHour != 12)
                StartHour = (StartHour + 12);
            else
                StartHour = 12;
        }
        else
        {
            if (StartHour == 12)
            {
                StartHour = 0;
            }
        }
        return StartHour;
    }

    private int SaveProductsSamples(int VisitID)
    {
        int result = 0;
        int NewID = 0;
        int ProductsID;
        int Quantity;

        for (int i = 0; i < gvProducts.Rows.Count; i++)
        {
            if (((CheckBox)gvProducts.Rows[i].FindControl("cbxSelect")).Checked)
            {
                ProductsID = Convert.ToInt32(gvProducts.DataKeys[i].Value);
                Quantity = Convert.ToInt32(((TextBox)gvProducts.Rows[i].FindControl("txtQuantity")).Text); ;
                // save Products //
                AddVisitItem(VisitID, "Products", ProductsID, Quantity, out NewID);
                result = result + 1;
            }
        }

        return result;
    }

    private int SaveListBoxItems(string ModuleName, ListBox LBItems, int VisitID)
    {
        int result = 0;
        int NewID = 0;
        int Quantity = 1;

        switch (ModuleName)
        {
            case "MedicalAccounts":
                for (int i = 0; i < LBItems.Items.Count; i++)
                {
                    if (LBItems.Items[i].Selected)
                    {
                        int PhysicianID = int.Parse(LBItems.Items[i].Value);
                        // save Physicians //
                        AddSubModule(VisitID, 3, PhysicianID, out NewID);
                        result = result + 1;
                    }
                }
                break;

            case "Distributors":
                for (int i = 0; i < LBItems.Items.Count; i++)
                {
                    if (LBItems.Items[i].Selected)
                    {
                        // save Distributors //
                        int DistributorID = int.Parse(LBItems.Items[i].Value);
                        AddSubModule(VisitID, 7, DistributorID, out NewID);
                        result = result + 1;
                    }
                }
                break;

            case "Products":
                for (int i = 0; i < LBItems.Items.Count; i++)
                {
                    if (LBItems.Items[i].Selected)
                    {
                        int ProductsID = int.Parse(LBItems.Items[i].Value);
                        // save Products //
                        AddVisitItem(VisitID, "Products", ProductsID, Quantity, out NewID);
                        result = result + 1;
                    }
                }
                break;
        }
        return result;
    }

    private void SaveMarketingMaterials(int VisitID)
    {
        int NewID = 0;
        for (int i = 0; i < gvMM.Rows.Count; i++)
        {
            if (((CheckBox)gvMM.Rows[i].FindControl("cbxSelect")).Checked)
            {
                int MarketingMaterialsID = int.Parse(gvMM.DataKeys[i].Values["SID"].ToString().Trim());
                int Quantity = int.Parse(((TextBox)gvMM.Rows[i].FindControl("txtQuantity")).Text);
                AddVisitItem(VisitID, "MarketingMaterials", MarketingMaterialsID, Quantity, out NewID);
            }
        }

    }

    protected void ucTransButtons_btnCancelEvent(object sender, EventArgs e)
    {
        AdjustTransButtons(false);
        AdjustReadOnlyFormStatus(true);
        HideDDLControls();
        txtOthers.Visible = false;
        rfvtxtOthers.Enabled = false;
        lblMentionOther.Visible = false;
        lblmsg.Visible = false;
    }

    private void ResetFormControls()
    {
        //txtdaySP.Text = "";
        //txtdayST.Text = "";
    }

    protected void AdjustReadOnlyFormStatus(bool Flag)
    {
        if (ViewState["PlanExists"] != null)
        {
            txtSP.ReadOnly = true;
            ddlHour.Enabled = false;
            ddlMinute.Enabled = false;

        }
        else
        {
            txtSP.ReadOnly = Flag;
            ddlHour.Enabled = !Flag;
            ddlMinute.Enabled = !Flag;
        }

        ddlPlanDate.Enabled = !Flag;
        ddlAddItem.Enabled = !Flag;
        rblVisitShift.Enabled = !Flag;
        ddlVType.Enabled = !Flag;
        gvProducts.Enabled = !Flag;
        //lbProducts.Enabled = !Flag;
        //rfvlbProducts.Enabled = !Flag;
        ddlAddItem.SelectedIndex = 0;
        rblVisitShift.SelectedIndex = 1;
        ddlVType.SelectedIndex = 0;
        ((CheckBox)gvProducts.Rows[0].FindControl("cbxSelect")).Checked = true;
        //lbProducts.SelectedIndex = 0;
        gvMM.Enabled = !Flag;
        rblDoubleVisit.Enabled = !Flag;
        rblDoubleVisit.SelectedIndex = 1;
    }

    #endregion

    #region Days Link Button handler

    protected void lnkbtnSunVisits_Click(object sender, EventArgs e)
    {
        Session["PlanDate"] = ((LinkButton)tblSunVisits.FindControl("lnkbtnSunVisits")).ToolTip;
        Response.Redirect("~/FMT/FMTPlanning.aspx");
    }
    protected void lnkbtnMonVisits_Click(object sender, EventArgs e)
    {
        Session["PlanDate"] = ((LinkButton)tblMonVisits.FindControl("lnkbtnMonVisits")).ToolTip;
        Response.Redirect("~/FMT/FMTPlanning.aspx");

    }
    protected void lnkbtnTueVisits_Click(object sender, EventArgs e)
    {
        Session["PlanDate"] = ((LinkButton)tblTueVisits.FindControl("lnkbtnTueVisits")).ToolTip;
        Response.Redirect("~/FMT/FMTPlanning.aspx");

    }
    protected void lnkbtnWedVisits_Click(object sender, EventArgs e)
    {
        Session["PlanDate"] = ((LinkButton)tblWedVisits.FindControl("lnkbtnWedVisits")).ToolTip;
        Response.Redirect("~/FMT/FMTPlanning.aspx");

    }
    protected void lnkbtnThurVisits_Click(object sender, EventArgs e)
    {
        Session["PlanDate"] = ((LinkButton)tblThurVisits.FindControl("lnkbtnThurVisits")).ToolTip;
        Response.Redirect("~/FMT/FMTPlanning.aspx");

    }
    protected void lnkbtnFriVisits_Click(object sender, EventArgs e)
    {
        Session["PlanDate"] = ((LinkButton)tblFriVisits.FindControl("lnkbtnFriVisits")).ToolTip;
        Response.Redirect("~/FMT/FMTPlanning.aspx");

    }
    protected void lnkbtnSatVisits_Click(object sender, EventArgs e)
    {
        Session["PlanDate"] = ((LinkButton)tblSatVisits.FindControl("lnkbtnSatVisits")).ToolTip;
        Response.Redirect("~/FMT/FMTPlanning.aspx");

    }
    #endregion

    #region GridViews RowDataBound

    protected void gvSunVisits_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        FormatgvDayPlanVisits(gvSunVisits, e.Row);
    }
   
    protected void gvMonVisits_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        FormatgvDayPlanVisits(gvMonVisits, e.Row);
    }
   
    protected void gvTueVisits_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        FormatgvDayPlanVisits(gvTueVisits, e.Row);

    }
    
    protected void gvWedVisits_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        FormatgvDayPlanVisits(gvWedVisits, e.Row);
    }
    
    protected void gvThurVisits_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        FormatgvDayPlanVisits(gvThurVisits, e.Row);
    }
    
    protected void gvFriVisits_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        FormatgvDayPlanVisits(gvFriVisits, e.Row);
    }
    
    protected void gvSatVisits_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        FormatgvDayPlanVisits(gvSatVisits, e.Row);
    }

    private void FormatgvDayPlanVisits(GridView gvName, GridViewRow gvRow)
    {

        if (gvRow.RowType == DataControlRowType.DataRow)
        {
            bool IsPlanned = Convert.ToBoolean(gvName.DataKeys[gvRow.RowIndex].Values["IsPlanned"].ToString());

            if (!IsPlanned)
            {
                gvRow.CssClass = "FMTUnPlannedStyle";
                ((RadioButtonList)(gvRow.Cells[2].FindControl("rblIsVisited"))).Enabled = false;
            }
            //////////////////////////////////////////////////
            DataRowView rowView = (DataRowView)gvRow.DataItem;
            string strModuleName = rowView["ModuleName"].ToString();
            if (strModuleName == "" || strModuleName.ToLower() == "other")
            {
                ((HyperLink)gvRow.Cells[0].FindControl("lnkModuleNameRef")).Visible = false;
                ((Label)gvRow.Cells[0].FindControl("lblOtherModule")).Visible = true;
            }
            else
            {
                ((Label)gvRow.Cells[0].FindControl("lblOtherModule")).Visible = false;
                ((HyperLink)gvRow.Cells[0].FindControl("lnkModuleNameRef")).Visible = true;
            }

        }
    }

    protected void gvMM_DataBound(object sender, EventArgs e)
    {
        if (gvMM.Rows.Count > 0)
        {
            ((CheckBox)gvMM.Rows[0].FindControl("cbxSelect")).Checked = true;
            ((TextBox)gvMM.Rows[0].FindControl("txtQuantity")).Text = "1";
            //gvMM.Rows[0].CssClass = "AltRowStyle";
            gvMM.Rows[0].Style.Add(HtmlTextWriterStyle.BackgroundColor, "#BCC9B7");
        }
    }

    protected void gvMM_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onMouseOver", "this.style.background='#ff9900'");
            e.Row.Attributes.Add("onMouseOut", "if(this.getElementsByTagName('input')[0].checked){this.style.background='#BCC9B7'}else{this.style.background='#ffffff'}");
        }
    }

    protected void gvProducts_DataBound(object sender, EventArgs e)
    {
        if (gvProducts.Rows.Count > 0)
        {
            ((CheckBox)gvProducts.Rows[0].FindControl("cbxSelect")).Checked = true;
            ((TextBox)gvProducts.Rows[0].FindControl("txtQuantity")).Text = "1";
        }
    }

    protected void gvProducts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onMouseOver", "this.style.background='#ff9900'");
            e.Row.Attributes.Add("onMouseOut", "if(this.getElementsByTagName('input')[0].checked){this.style.background='#BCC9B7'}else{this.style.background='#ffffff'}");
        }
    }
    
    #endregion
    
}
