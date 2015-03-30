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

public partial class FMTPlanning : PlansBLL
{
    #region PageLoad

    protected void Page_Load(object sender, EventArgs e)
    {
        InitiateEventsHandlers();
        if (!IsPostBack)
        {
            if (Session["PlanDate"] == null)
            {
                DateTime StartDateOfNextWeek = StartDayOfWeek(Convert.ToDateTime(DateTime.Now.AddDays(7).ToShortDateString()), ApplicationDayOfWeek.Saturday);
                txtPlanDate.Text = StartDateOfNextWeek.ToShortDateString();
                Session["PlanDate"] = txtPlanDate.Text;
            }
            else 
            {
                txtPlanDate.Text = Session["PlanDate"].ToString();
            }
            
            txtPlanDate.Attributes.Add("ReadOnly", "ReadOnly");
            if (!PopulateMRList(false))
            {
                Session["ReturnMsg"] = "You can't use FMT before creating at least one medical-representative user.";

                Response.Redirect(Request.Url.AbsoluteUri.Replace("FMT/FMTPlanning", "index"));
                return;
            }
            PopulateFMTModules();
            PopulateWeekPlan();
            PopulateAllMRBricks();
            HandleWeekPlanStatus();
            ManageApprovalPanal();
            btnctlTabChangedEvent_Click(this, null);
        }
        else
        {
            ((DropDownList)tblVisitsContent.FindControl("ddlDaySTHourPM")).SelectedValue = ddlDaySTHourPM.SelectedValue;
            ((DropDownList)tblVisitsContent.FindControl("ddlDaySTMinPM")).SelectedValue = ddlDaySTMinPM.SelectedValue;
            ((DropDownList)tblVisitsContent.FindControl("ddlDaySTHour")).SelectedValue = ddlDaySTHour.SelectedValue;
            ((DropDownList)tblVisitsContent.FindControl("ddlDaySTMin")).SelectedValue = ddlDaySTMin.SelectedValue;
            tabcontWeekVisits.ActiveTab.Controls.Add(tblVisitsContent);
            gvDayPlanVisitsAM.DataSource = Session["gvDayPlanVisitsAM"];
            gvDayPlanVisitsPM.DataSource = Session["gvDayPlanVisitsPM"];
            tabcontWeekVisits.DataBind();
        }
    }
 
    #endregion

    #region Get Business process for Plans and Visits

    private int GetPlanID(DateTime PlanDate, bool ShowAll)
    {
        this.Culture = "ar-EG";
        int result = 0;
        ResetFormControls();
        //
        int EmpID = int.Parse(ddlMRList.SelectedValue);
        DataTable dt = SelectPlanVisits(PlanDate, EmpID, ShowAll); // Get PlanID and details in this function
        if (dt.Rows.Count > 0)
        {
            result = int.Parse(dt.Rows[0]["PlanID"].ToString()); // The Returned PlanID
            //
            //DisplayPlanStatus(int.Parse(dt.Rows[0]["Commit"].ToString())); //The Returned Plan Status for a day
            ViewState["PlanExists"] = "1";
            // Disable to Add New starting point and starting time becuse Plan already Exists
            txtSP.ReadOnly = true;
            ddlHour.Enabled = false;
            ddlMinute.Enabled = false;
            ddlDuration.Enabled = false;
            //////////////////////////////////////////////////////////////
            //
            txtdaySP.Text = dt.Rows[0]["StartPoint"].ToString();
            txtdaySPPM.Text = dt.Rows[0]["StartPointPM"].ToString();
            if (dt.Rows[0]["StartTime"] != DBNull.Value)
            {
                string[] StartTime = String.Format("{0:h mm tt}", Convert.ToDateTime(dt.Rows[0]["StartTime"])).Split(new string[] { " " }, StringSplitOptions.None);
                ddlDaySTHour.SelectedValue = StartTime[0];
                ddlDaySTMin.SelectedValue = StartTime[1];
                ddlDaySTDuration.SelectedValue = StartTime[2];
                //txtdayST.Text = String.Format("{0:t}", Convert.ToDateTime(dt.Rows[0]["StartTime"].ToString()));
            }
            else
            {
                ddlDaySTHour.SelectedValue = "12";
                ddlDaySTMin.SelectedValue = "00";
                ddlDaySTMin.Items.FindByText("--").Enabled = false;
            }
            if (dt.Rows[0]["StartTimePM"] != DBNull.Value)
            {
                string[] StartTimePM = String.Format("{0:h mm tt}", Convert.ToDateTime(dt.Rows[0]["StartTimePM"])).Split(new string[] { " " }, StringSplitOptions.None);
                ddlDaySTHourPM.SelectedValue = StartTimePM[0];
                ddlDaySTMinPM.SelectedValue = StartTimePM[1];
                ddlDaySTDurationPM.SelectedValue = StartTimePM[2];
                //txtdaySTPM.Text = String.Format("{0:t}", Convert.ToDateTime(dt.Rows[0]["StartTimePM"].ToString()));
            }
            else
            {
                ddlDaySTHourPM.SelectedValue = "12";
                ddlDaySTMinPM.SelectedValue = "00";
                ddlDaySTMinPM.Items.FindByText("--").Enabled = false;
            }
        }
        else  // No Plan Enterd yet for selected day
        {
            ViewState["PlanExists"] = null;
            // Enable to Add New starting point and starting time becuse Plan already Exists if save button is visable
            if (((ImageButton)ucTransButtons.FindControl("btnSave")).Visible)
            {
                txtSP.ReadOnly = false;
                ddlHour.Enabled = true;
                ddlMinute.Enabled = true;
                ddlDuration.Enabled = true;
            }
            //lblPlanStatus.Text = " No plan enterd..."; // No plan enterd For Given Day date...";
            //lblPlanStatus.ForeColor = System.Drawing.Color.Maroon;
        }
        return result;
    }

    private void BindgvDayPlanVisits(int PlanID) 
    {
        if (PlanID > 0)
        {
            Session["gvDayPlanVisitsAM"] = SelectVisits(PlanID, false);
            Session["gvDayPlanVisitsPM"] = SelectVisits(PlanID, true);
            gvDayPlanVisitsAM.DataSource = Session["gvDayPlanVisitsAM"];
            gvDayPlanVisitsPM.DataSource = Session["gvDayPlanVisitsPM"];
            //
            ViewState["PlanID"] = PlanID;
            btnUpdateSP.Visible = true;
            btnUpdateSPPM.Visible = true;
        }
        else
        {
            Session.Remove("gvDayPlanVisitsAM");
            Session.Remove("gvDayPlanVisitsPM");
            gvDayPlanVisitsAM.DataSource = null;
            gvDayPlanVisitsPM.DataSource = null;
            //
            ViewState["PlanID"] = null;
            btnUpdateSP.Visible = false;
            btnUpdateSPPM.Visible = false;
        }
        tabcontWeekVisits.DataBind();
    }

    private void HandleWeekPlanStatus()
    {
        this.Culture = "ar-EG";
        //Handle If week plan is already Approved //
        ucTransButtons_btnCancelEvent(this, null);
        CommitCommand CM = GetWeekPlanCommittionStatus(Convert.ToDateTime(tbSat.HeaderText), int.Parse(ddlMRList.SelectedValue));

        if (CM == CommitCommand.Invalid)
        {
            lblPlanStatus.Text = " // No week plan Enterd";
            lblPlanStatus.ForeColor = System.Drawing.Color.Maroon;
            ViewState["WeekPlanStatus"] = "-1";
        }
        else if (CM == CommitCommand.Pending)
        {
            lblPlanStatus.Text = " // Current week plan is Pending";
            lblPlanStatus.ForeColor = System.Drawing.Color.Orange;
            ViewState["WeekPlanStatus"] = "0";
        }
        else if (CM == CommitCommand.Approve)
        {

            ((ImageButton)ucTransButtons.FindControl("btnAdd")).Visible = false;
            lblPlanStatus.Text = " // Current week plan is Approved";
            lblPlanStatus.ForeColor = System.Drawing.Color.Green;
            ViewState["WeekPlanStatus"] = "1";

        }
        else if (CM == CommitCommand.Reject)
        {
            ((ImageButton)ucTransButtons.FindControl("btnAdd")).Visible = false;
            lblPlanStatus.Text = " // Current week plan is Rejected";
            lblPlanStatus.ForeColor = System.Drawing.Color.Red;
            ViewState["WeekPlanStatus"] = "2";
            btnDelete.Visible = false;
            btnUpdateSP.Visible = false;
            btnUpdateSPPM.Visible = false;
        }
        //----------------------------------
        // check here to set btnAdd = Visible if the given date was in week range
        DateTime StartDateOfCurrentWeek = StartDayOfWeek(Convert.ToDateTime(DateTime.Today.ToShortDateString()), ApplicationDayOfWeek.Saturday);
        DateTime StartDateOfSelectedWeek = StartDayOfWeek(Convert.ToDateTime(txtPlanDate.Text), ApplicationDayOfWeek.Saturday);
        //
        if (StartDateOfCurrentWeek > StartDateOfSelectedWeek)
        {
          ((ImageButton)ucTransButtons.FindControl("btnAdd")).Visible = false;
        }
         //
    }

    private DateTime StartDayOfWeek(DateTime date, ApplicationDayOfWeek startDay)
    {

        if (date.DayOfWeek >= ApplicationToSystemDay(startDay))

            return date.AddDays((int)ApplicationDayOfWeek.Saturday - (int)SystemToApplicationDay(date.DayOfWeek));

        else

            return date.AddDays(7 - (int)ApplicationDayOfWeek.Saturday - (int)SystemToApplicationDay(date.DayOfWeek));

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
        ddlAllUserBricks.DataSource = SelectBricksForUser(Convert.ToInt32(ddlMRList.SelectedItem.Value));
        ddlAllUserBricks.DataTextField = "BrickName";
        ddlAllUserBricks.DataValueField = "BrickID";
        ddlAllUserBricks.DataBind();
    }

    private void PopulateCurrentPlanBricks()
    {
        this.Culture = "ar-EG";
        ddlPlanUserBricks.DataSource = SelectBricksForUserPlan(Convert.ToDateTime(tbSat.HeaderText), int.Parse(ddlMRList.SelectedValue));
        ddlPlanUserBricks.DataTextField = "BrickName";
        ddlPlanUserBricks.DataValueField = "BrickName";
        ddlPlanUserBricks.DataBind();
    }

    //protected void lbProducts_DataBound(object sender, EventArgs e)
    //{
    //    if (lbProducts.Items.Count > 0)
    //    {
    //        lbProducts.Items[0].Selected = true;
    //    }
    //}
   
    protected void lbMM_DataBound(object sender, EventArgs e)
    {
        //if (lbMM.Items.Count > 0)
        //{
        //    lbMM.Items[0].Selected = true;
        //}
    }
   
    protected void ddlAddItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAddItem.SelectedItem.Text != "Select")
        {
            if (ddlAddItem.SelectedItem.Text != "Other")
            {
                //New Mode //
                if (ddlAddItem.SelectedItem.Text == "Pharmacies" || ddlAddItem.SelectedItem.Text == "PrivateClinics")
                {
                    lbSubModule.DataSource = SelectEntitiesList(ddlAddItem.SelectedItem.Text, ddlMRList.SelectedValue);
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
                    ddlAddRel.DataSource = SelectEntitiesList(ddlAddItem.SelectedItem.Text, ddlMRList.SelectedValue);
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
                lbSubModule.DataSource = GetBranchesNamesByDistributor(int.Parse(ddlAddRel.SelectedValue), Convert.ToInt32(ddlMRList.SelectedValue));
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
        // For The Visit FeedBack Page
        Session["EmpID"] = ddlMRList.SelectedValue;
        //
        GetEmpData();
        PopulateAllMRBricks();
        HandleWeekPlanStatus();
        ManageApprovalPanal();
        btnctlTabChangedEvent_Click(this, null);
    }

    protected void ddlAllUserBricks_DataBound(object sender, EventArgs e)
    {
        lblTotalBricksNo.Text = ddlAllUserBricks.Items.Count.ToString();
    }

    protected void ddlPlanUserBricks_DataBound(object sender, EventArgs e)
    {
        lblPlanBricksNo.Text = ddlPlanUserBricks.Items.Count.ToString();
    }

    protected void ddlAddRel_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAddRel_DataBound(this, null);
    }


    #endregion

    #region  Week Range Handler

    private bool PopulateMRList(bool ShowAll)
    {
        ddlMRList.DataSource = GetMRList(ShowAll);
        ddlMRList.DataValueField = "EmpID";
        ddlMRList.DataTextField = "EmpName";
        ddlMRList.DataBind();
        if (Session["EmpID"] == null)
        {
            Session["EmpID"] = ddlMRList.SelectedValue;
        }
        else
        {
            ddlMRList.SelectedValue = Session["EmpID"].ToString();
        }

        if (ddlMRList.Items.Count > 0)
        {
            GetEmpData();
            return true;
        }
        else
            return false;

    }

    private void GetEmpData() 
    {
        DataRow row = GetEmployeeInfo(Convert.ToInt32(ddlMRList.SelectedItem.Value));
        lblMRName.Text = row["EmpName"].ToString();
        lblMRTitle.Text = row["Title"].ToString();
    }
    
    private void PopulateWeekPlan()
    {
        this.Culture = "ar-EG";
        SetWeekRangeTabs(Convert.ToDateTime(txtPlanDate.Text));
        tabcontWeekVisits.ActiveTabIndex = FocusOnSelectedDay(Convert.ToDateTime(txtPlanDate.Text));
    }
    
    private void SetWeekRangeTabs(DateTime dayDateVar)
    {
        this.Culture = "ar-EG";
        string[] WeekDayNames = new string[7];
        string DayName;
        string DayDate;
        int subDay = 0;
        bool WeekEndFlag = false;
        DateTime WeekEndDate = DateTime.Today;
        DateTime WeekStartDate = DateTime.Today;

        for (int i = 0; i < WeekDayNames.Length; i++)
        {
            DayName = dayDateVar.AddDays(i).DayOfWeek.ToString();
            if (WeekEndFlag == false)
            {
                DayDate = dayDateVar.AddDays(i).Date.ToShortDateString();
            }
            else
            {
                WeekStartDate = WeekEndDate.AddDays(-7);
                subDay = subDay + 1;
                DayDate = WeekStartDate.AddDays(subDay).Date.ToShortDateString();
            }

            switch ((DayOfWeek)dayDateVar.AddDays(i).DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    ((Label)tbSat.FindControl("lblSat")).Text = ":: " + ApplicationDayOfWeek.Saturday.ToString().Remove(3, 5) + " " + DayDate + " ::";
                    tbSat.HeaderText = DayDate;
                    break;
                case DayOfWeek.Sunday:
                    ((Label)tbSun.FindControl("lblSun")).Text = ":: " + ApplicationDayOfWeek.Sunday.ToString().Remove(3, 3) + " " + DayDate + " ::";
                    tbSun.HeaderText = DayDate;
                    break;
                case DayOfWeek.Monday:
                    ((Label)tbMon.FindControl("lblMon")).Text = ":: " + ApplicationDayOfWeek.Monday.ToString().Remove(3, 3) + " " + DayDate + " ::";
                    tbMon.HeaderText = DayDate;
                    break;
                case DayOfWeek.Tuesday:
                    ((Label)tbTue.FindControl("lblTue")).Text = ":: " + ApplicationDayOfWeek.Tuesday.ToString().Remove(3, 4) + " " + DayDate + " ::";
                    tbTue.HeaderText = DayDate;
                    break;
                case DayOfWeek.Wednesday:
                    ((Label)tbWed.FindControl("lblWed")).Text = ":: " + ApplicationDayOfWeek.Wednesday.ToString().Remove(3, 6) + " " + DayDate + " ::";
                    tbWed.HeaderText = DayDate;
                    break;
                case DayOfWeek.Thursday:
                    ((Label)tbThur.FindControl("lblThur")).Text = ":: " + ApplicationDayOfWeek.Thursday.ToString().Remove(4, 4) + " " + DayDate + " ::";
                    tbThur.HeaderText = DayDate;
                    break;
                case DayOfWeek.Friday:
                    ((Label)tbFri.FindControl("lblFri")).Text = ":: " + ApplicationDayOfWeek.Friday.ToString().Remove(3, 3) + " " + DayDate + " ::";
                    tbFri.HeaderText = DayDate;
                    WeekEndFlag = true;
                    WeekEndDate = Convert.ToDateTime(DayDate);
                    break;
            }
        }
    }

    private int FocusOnSelectedDay(DateTime dayDateVar)
    {
        this.Culture = "ar-EG";
        string[] WeekDayNames = new string[7];
        for (int i = 0; i < WeekDayNames.Length; i++)
        {
            switch ((DayOfWeek)dayDateVar.AddDays(i).DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    return 0;
                case DayOfWeek.Sunday:
                    return 1;
                case DayOfWeek.Monday:
                    return 2;
                case DayOfWeek.Tuesday:
                    return 3;
                case DayOfWeek.Wednesday:
                    return 4;
                case DayOfWeek.Thursday:
                    return 5;
                case DayOfWeek.Friday:
                    return 6;
            }
        }
        return 0;
    }

    #endregion
   
    #region  tabcontWeekVisits Events handlers
   
    protected void txtPlanDate_TextChanged(object sender, EventArgs e)
    {
        // For The Visit FeedBack Page
        Session["PlanDate"] = txtPlanDate.Text;
        //
        PopulateWeekPlan();
        HandleWeekPlanStatus();
        ManageApprovalPanal();
        btnctlTabChangedEvent_Click(this, null);
    }

    protected void btnctlTabChangedEvent_Click(object sender, EventArgs e)
    {
        this.Culture = "ar-EG";
        DateTime PlanDate = DateTime.Today;
        switch (tabcontWeekVisits.ActiveTabIndex)
        {
            case 0:
                tbSat.Controls.Add(tblVisitsContent);
                PlanDate = Convert.ToDateTime(tbSat.HeaderText); //selected tab time
                break;
            case 1:
                tbSun.Controls.Add(tblVisitsContent);
                PlanDate = Convert.ToDateTime(tbSun.HeaderText); //selected tab time
                break;
            case 2:
                tbMon.Controls.Add(tblVisitsContent);
                PlanDate = Convert.ToDateTime(tbMon.HeaderText); //selected tab time
                break;
            case 3:
                tbTue.Controls.Add(tblVisitsContent);
                PlanDate = Convert.ToDateTime(tbTue.HeaderText); //selected tab time
                break;
            case 4:
                tbWed.Controls.Add(tblVisitsContent);
                PlanDate = Convert.ToDateTime(tbWed.HeaderText); //selected tab time
                break;
            case 5:
                tbThur.Controls.Add(tblVisitsContent);
                PlanDate = Convert.ToDateTime(tbThur.HeaderText); //selected tab time
                break;
            case 6:
                tbFri.Controls.Add(tblVisitsContent);
                PlanDate = Convert.ToDateTime(tbFri.HeaderText); //selected tab time
                break;
        }
        txtPlanDate.Text = PlanDate.ToShortDateString();
        BindgvDayPlanVisits(GetPlanID(PlanDate, true));
        PopulateCurrentPlanBricks();
        HandleDeleteAction();
       
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
                    if(Quantity > 0)
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
                string ModuleName = ddlAddItem.SelectedItem.Text ;
                //
                int NewPlanID = 0;
                int NewVisitID = 0;
                int VisitTypeID = int.Parse(ddlVType.SelectedValue.ToString());
                int EmpID = int.Parse(ddlMRList.SelectedValue.ToString());
                //
                //
                bool ISPMShift = true;
                if (rblVisitShift.SelectedIndex == 0)
                    ISPMShift = false;
                //
                //
                int StartHour = GetShiftHour(int.Parse(ddlHour.SelectedValue), ddlDuration.SelectedIndex == 1);
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

                    if (!IsPlanExists(Convert.ToDateTime(tabcontWeekVisits.ActiveTab.HeaderText), EmpID, out NewPlanID))
                    {
                        AddPlan(Convert.ToDateTime(tabcontWeekVisits.ActiveTab.HeaderText), EmpID, SPAM, STAM, SPPM, STPM, DateTime.Now, ModuleID, ModuleRefID, VisitTypeID, ISPMShift, txtOthers.Text, true, boolDoubleVisit, out NewPlanID, out NewVisitID);
                    }
                    else
                    {
                        // Add Visit //
                        AddVisit(NewPlanID, ModuleID, ModuleRefID, VisitTypeID, ISPMShift, txtOthers.Text, true, boolDoubleVisit, out NewVisitID);
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
                    //SaveListBoxItems("MarketingMaterials", lbMM, NewVisitID);
                    SaveMarketingMaterials(NewVisitID);

                }
                // Switching else // Pharmacies or PrivateClinics or any dynamic module to add later
                else // 
                {
                    if (!IsPlanExists(Convert.ToDateTime(tabcontWeekVisits.ActiveTab.HeaderText), EmpID, out NewPlanID))
                    {
                        AddPlan(Convert.ToDateTime(tabcontWeekVisits.ActiveTab.HeaderText), EmpID, SPAM, STAM, SPPM, STPM, DateTime.Now, true, out NewPlanID);
                    }
                        // Add one or more selected visits Visits //
                        for (int i = 0; i < lbSubModule.Items.Count; i++)
                        {
                            if (lbSubModule.Items[i].Selected)
                            {
                                //Begain save multi Pharmacies or PrivateClinics
                                AddVisit(NewPlanID, ModuleID, int.Parse(lbSubModule.Items[i].Value), VisitTypeID, ISPMShift, txtOthers.Text, true, boolDoubleVisit, out NewVisitID);
                                SaveProductsSamples(NewVisitID);
                                //SaveListBoxItems("Products", lbProducts, NewVisitID);
                                //Save MarketingMaterials
                                //SaveListBoxItems("MarketingMaterials", lbMM, NewVisitID);
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
                ddlDuration.SelectedIndex = 0;
                // Disable to Add New starting point and starting time becuse he already did
                txtSP.ReadOnly = true;
                ddlHour.Enabled = false;
                ddlMinute.Enabled = false;
                ddlDuration.Enabled = false;
                //////////////////////////////////////////////////////////////
                // Initate that its is a pending week plan for first entry //
                lblPlanStatus.Text = " // Current week plan is Pending";
                lblPlanStatus.ForeColor = System.Drawing.Color.Orange;
                ViewState["WeekPlanStatus"] = "0";
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
            btnctlTabChangedEvent_Click(this, null);
            //
        }
    }

    private int GetShiftHour(int StartHour , bool ISPMShift) 
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

            case "MarketingMaterials":
                for (int i = 0; i < LBItems.Items.Count; i++)
                {
                    if (LBItems.Items[i].Selected)
                    {
                        int MarketingMaterialsID = int.Parse(LBItems.Items[i].Value);
                        // save MarketingMaterials //
                         AddVisitItem(VisitID, "MarketingMaterials", MarketingMaterialsID, Quantity, out NewID);
                        result = result + 1;
                    }
                }
                break;
        }
        return result;
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
        txtdaySP.Text = "";
        ddlDaySTDuration.SelectedIndex = -1;
        ddlDaySTDurationPM.SelectedIndex = -1;
        ddlDaySTHour.SelectedIndex = -1;
        ddlDaySTHourPM.SelectedIndex = -1;
    }

    protected void AdjustReadOnlyFormStatus(bool Flag)
    {
        if (ViewState["PlanExists"] != null)
        {
            txtSP.ReadOnly = true;
            ddlHour.Enabled = false;
            ddlMinute.Enabled = false;
            ddlDuration.Enabled = false;
        }
        else
        {
            txtSP.ReadOnly = Flag;
            ddlHour.Enabled = !Flag;
            ddlMinute.Enabled = !Flag;
            ddlDuration.Enabled = !Flag;
        }

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

    #region GridViews Events Handlers

    private string SetModulesLink(GridViewRow row , GridView gvTargetDayPlanVisits)
    {
        string NormalizedModule = row.Cells[1].Text;
        string CurrentID = gvTargetDayPlanVisits.DataKeys[row.RowIndex].Values["ModuleRefID"].ToString().Trim();
        string URL = "";
        switch (NormalizedModule)
        {
            case "PrivateClinics":
                URL = "~/PrivateClinics.aspx?";
                break;
            case "MedicalAccounts":
                URL = "~/MedicalAccounts.aspx?";
                break;
            case "Distributors":
                URL = "~/Distributors.aspx?";
                break;
            case "Pharmacies":
                URL = "~/Pharmacies.aspx?";
                break;
            case "Physicians":
                URL = "~/Physicians.aspx?";
                break;
        }
        return URL + "data=" + mEncryptQueryString("&ID=" + CurrentID);
    }

    protected void gvDayPlanVisitsAM_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView rowView = (DataRowView)e.Row.DataItem;
            string strModuleName = rowView["ModuleName"].ToString();
            if (strModuleName == "" || strModuleName.ToLower() == "other")
            {
                ((HyperLink)e.Row.Cells[0].FindControl("lnkModuleNameRef")).Visible = false;
                ((Label)e.Row.Cells[0].FindControl("lblOtherModule")).Visible = true;
            }
            else
            {
                ((Label)e.Row.Cells[0].FindControl("lblOtherModule")).Visible = false;
                ((HyperLink)e.Row.Cells[0].FindControl("lnkModuleNameRef")).Visible = true;
                ((HyperLink)e.Row.Cells[0].FindControl("lnkModuleNameRef")).NavigateUrl = SetModulesLink(e.Row, gvDayPlanVisitsAM);
            }
            /////////////////////////////////////////////////////////////
            int VisitID = int.Parse(gvDayPlanVisitsAM.DataKeys[e.Row.RowIndex].Values["VisitID"].ToString().Trim());
            DropDownList ddlvProducts = ((DropDownList)e.Row.Cells[5].FindControl("ddlvProducts"));
            DataTable dt = SelectVisitsItems(VisitID, "Products");
            if (dt.Rows.Count > 0)
            {
                ddlvProducts.Visible = true;
                ddlvProducts.DataSource = dt;
                ddlvProducts.DataBind();
                dt.Clear();
            }
            //
            else
            {
                ddlvProducts.Visible = false;
                e.Row.Cells[4].Text = "N/A";
            }
            //
            DropDownList ddlvMM = ((DropDownList)e.Row.Cells[6].FindControl("ddlvMM"));
            dt = SelectVisitsItems(VisitID, "MarketingMaterials");
            if (dt.Rows.Count > 0)
            {
                ddlvMM.Visible = true;
                ddlvMM.DataSource = dt;
                ddlvMM.DataBind();
                dt.Clear();
            }
            //
            else
            {
                ddlvMM.Visible = false;
                e.Row.Cells[5].Text = "N/A";
            }
            //

            DropDownList ddlvEntity = ((DropDownList)e.Row.Cells[7].FindControl("ddlvEntity"));
            dt = SelectSubModules(VisitID);
            if (dt.Rows.Count > 0)
            {
                ddlvEntity.Visible = true;
                ddlvEntity.DataSource = dt;
                ddlvEntity.DataBind();
                dt.Clear();
            }
            //
            else
            {
                ddlvEntity.Visible = false;
                e.Row.Cells[6].Text = "N/A";
            }
        }
        //
    }

    protected void gvDayPlanVisitsPM_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView rowView = (DataRowView)e.Row.DataItem;
            string strModuleName = rowView["ModuleName"].ToString();
            if (strModuleName == "" || strModuleName.ToLower() == "other")
            {
                ((HyperLink)e.Row.Cells[0].FindControl("lnkModuleNameRef")).Visible = false;
                ((Label)e.Row.Cells[0].FindControl("lblOtherModule")).Visible = true;
            }
            else
            {
                ((Label)e.Row.Cells[0].FindControl("lblOtherModule")).Visible = false;
                ((HyperLink)e.Row.Cells[0].FindControl("lnkModuleNameRef")).Visible = true;
                ((HyperLink)e.Row.Cells[0].FindControl("lnkModuleNameRef")).NavigateUrl = SetModulesLink(e.Row, gvDayPlanVisitsPM);
            }
            /////////////////////////////////////////////////////////////
            int VisitID = int.Parse(gvDayPlanVisitsPM.DataKeys[e.Row.RowIndex].Values["VisitID"].ToString().Trim());
            DropDownList ddlvProducts = ((DropDownList)e.Row.Cells[5].FindControl("ddlvProducts"));
            DataTable dt = SelectVisitsItems(VisitID, "Products");
            if (dt.Rows.Count > 0)
            {
                ddlvProducts.Visible = true;
                ddlvProducts.DataSource = dt;
                ddlvProducts.DataBind();
                dt.Clear();
            }
            //
            else
            {
                ddlvProducts.Visible = false;
                e.Row.Cells[4].Text = "N/A";
            }
            //
            DropDownList ddlvMM = ((DropDownList)e.Row.Cells[6].FindControl("ddlvMM"));
            dt = SelectVisitsItems(VisitID, "MarketingMaterials");
            if (dt.Rows.Count > 0)
            {
                ddlvMM.Visible = true;
                ddlvMM.DataSource = dt;
                ddlvMM.DataBind();
                dt.Clear();
            }
            //
            else
            {
                ddlvMM.Visible = false;
                e.Row.Cells[5].Text = "N/A";
            }
            //

            DropDownList ddlvEntity = ((DropDownList)e.Row.Cells[7].FindControl("ddlvEntity"));
            dt = SelectSubModules(VisitID);
            if (dt.Rows.Count > 0)
            {
                ddlvEntity.Visible = true;
                ddlvEntity.DataSource = dt;
                ddlvEntity.DataBind();
                dt.Clear();
            }
            //
            else
            {
                ddlvEntity.Visible = false;
                e.Row.Cells[6].Text = "N/A";
            }
        }
    }

    #endregion

    #region Approval Handler
    
    private void ManageApprovalPanal()
    {
        // if logged user is Super Admin
        if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
        {
            tblApprovalManager.Visible = true;
            rbApproveWeekPlan.SelectedIndex = int.Parse(ViewState["WeekPlanStatus"].ToString());
            rbApproveWeekPlan.Enabled = true;
            btnCommit.Enabled = true;
        }
        // if logged user is NOT a medical representative //
        else if (CurrentUserInfo.UserRole != UsersRoles.User)
        {
            tblApprovalManager.Visible = true;
            rbApproveWeekPlan.SelectedIndex = int.Parse(ViewState["WeekPlanStatus"].ToString());
            if (rbApproveWeekPlan.SelectedIndex == 1)
            {
                rbApproveWeekPlan.Enabled = false;
                btnCommit.Enabled = false;
            }
            else
            {
                rbApproveWeekPlan.Enabled = true;
                btnCommit.Enabled = true;
            }
        }
        // User //
        else
        {
            tblApprovalManager.Visible = false;

        }
    }

    protected void btnCommit_Click(object sender, EventArgs e)
    {
        this.Culture = "ar-EG";
        if (rbApproveWeekPlan.SelectedIndex == 0)
        {
            CommittWeekPlan(Convert.ToDateTime(tbSat.HeaderText), int.Parse(ddlMRList.SelectedValue), CommitCommand.Pending);
        }
        else if (rbApproveWeekPlan.SelectedIndex == 1)
        {
            CommittWeekPlan(Convert.ToDateTime(tbSat.HeaderText), int.Parse(ddlMRList.SelectedValue), CommitCommand.Approve);

        }
        else
        {
            CommittWeekPlan(Convert.ToDateTime(tbSat.HeaderText), int.Parse(ddlMRList.SelectedValue), CommitCommand.Reject);

        }
        HandleWeekPlanStatus();
        ManageApprovalPanal();
        btnctlTabChangedEvent_Click(this, null);
    }


    #endregion

    #region Max / Min form event handler
    
    protected void lnkbtnMaxWin_Click(object sender, EventArgs e)
    {
        if (lnkbtnMaxWin.Text == "Max")
        {
            tblPlanManager.Visible = false;
            lnkbtnMaxWin.Text = "Min";
        }
        else
        {
            tblPlanManager.Visible = true;
            lnkbtnMaxWin.Text = "Max";
        }
        btnctlTabChangedEvent_Click(this, null);
    }

    #endregion

    #region Save Feedback Handler

    //protected void btnSaveFeedBack_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (ViewState["VisitID"] != null)
    //    {
    //        int VisitID = int.Parse(ViewState["VisitID"].ToString());
    //        if (SaveVisitFeedBack(VisitID, FCKFeedBack.Text))
    //        {
    //            //
    //            int SelectedGridIndex = int.Parse(ViewState["SelectedGridRowIndex"].ToString());
    //            //
    //            if (Convert.ToString(ViewState["GridViewName"].ToString()) == "gvDayPlanVisitsAM")
    //            {
    //                gvDayPlanVisitsAM.SelectedIndex = SelectedGridIndex;
    //            }
    //            else if (Convert.ToString(ViewState["GridViewName"].ToString()) == "gvDayPlanVisitsPM")
    //            {
    //                gvDayPlanVisitsPM.SelectedIndex = SelectedGridIndex;
    //            }
    //            //
    //            lblfeedbackmsg.Visible = true;
    //            ViewState["VisitID"] = null;
    //            ViewState["GridViewName"] = null;
    //            ViewState["SelectedGridRowIndex"] = null;
    //        }
    //    }
    //}

    #endregion

    #region Delete Visit and  Handler

    private void HandleDeleteAction()
    {
        if (Convert.ToString(ViewState["WeekPlanStatus"].ToString()) == "-1" || Convert.ToString(ViewState["WeekPlanStatus"].ToString()) == "0")
        {
            if (gvDayPlanVisitsAM.Rows.Count > 0 || gvDayPlanVisitsPM.Rows.Count > 0)
            {
                btnDelete.Visible = true;
                btnUpdateSP.Visible = true;
                btnUpdateSPPM.Visible = true;
                gvDayPlanVisitsAM.Columns[7].Visible = true;
                gvDayPlanVisitsPM.Columns[7].Visible = true;
            }
            else
            {
                btnDelete.Visible = false;
                btnUpdateSP.Visible = false;
                btnUpdateSPPM.Visible = false;
                gvDayPlanVisitsAM.Columns[7].Visible = false;
                gvDayPlanVisitsPM.Columns[7].Visible = false;
            }
        }
        else if (Convert.ToString(ViewState["WeekPlanStatus"].ToString()) == "1" || Convert.ToString(ViewState["WeekPlanStatus"].ToString()) == "2")
        {
            btnDelete.Visible = false;
            btnUpdateSP.Visible = false;
            btnUpdateSPPM.Visible = false;
            gvDayPlanVisitsAM.Columns[7].Visible = false;
            gvDayPlanVisitsPM.Columns[7].Visible = false;
        }
    }

    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        bool result = false;
        for (int i = 0; i < gvDayPlanVisitsAM.Rows.Count; i++)
        {
            if (((CheckBox)gvDayPlanVisitsAM.Rows[i].FindControl("cbxDelete")).Checked)
            {
                int VisitID = int.Parse(gvDayPlanVisitsAM.DataKeys[i].Values["VisitID"].ToString().Trim());
                if (DeleteVisit(VisitID))
                    result = true;
            }

        }
        for (int i = 0; i < gvDayPlanVisitsPM.Rows.Count; i++)
        {
            if (((CheckBox)gvDayPlanVisitsPM.Rows[i].FindControl("cbxDelete")).Checked)
            {
                int VisitID = int.Parse(gvDayPlanVisitsPM.DataKeys[i].Values["VisitID"].ToString().Trim());
                if (DeleteVisit(VisitID))
                    result = true;
            }

        }
        if (result)
        {
            HandleWeekPlanStatus();
            btnctlTabChangedEvent_Click(this, null);
        }
    }
    
    #endregion

    #region ddlMRList DataBound
    
    #endregion

    #region Update Start Point and start time

    protected void btnUpdateSP_Click(object sender, EventArgs e)
    {
        if (ViewState["PlanID"] != null)
        {
            this.Culture = "ar-EG";
            DateTime? STAM;
            if (ddlDaySTHour.SelectedValue != "--")
            {
                int Hour = Convert.ToInt32(ddlDaySTHour.SelectedValue);
                if (ddlDaySTDuration.SelectedValue == "ã")
                {
                    if (Hour < 12)
                        Hour += 12;
                }
                else
                {
                    if (Hour == 12)
                        Hour = 0;
                }
                STAM = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                        Hour, Convert.ToInt32(ddlDaySTMin.SelectedValue), 0);
            }
            else
                STAM = null;
            DateTime? STPM;
            if (ddlDaySTHourPM.SelectedValue != "--")
            {
                int Hour = Convert.ToInt32(ddlDaySTHourPM.SelectedValue);
                if (ddlDaySTDurationPM.SelectedValue == "ã")
                {
                    if (Hour < 12)
                        Hour += 12;
                }
                else
                {
                    if (Hour == 12)
                        Hour = 0;
                }
                STPM = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                    Hour, Convert.ToInt32(ddlDaySTMinPM.SelectedValue), 0);
            }
            else
                STPM = null;
            UpdatePlanSPST(int.Parse(ViewState["PlanID"].ToString()), txtdaySP.Text, STAM, txtdaySPPM.Text, STPM);
        }
    }

    protected void btnUpdateSPPM_Click(object sender, EventArgs e)
    {
        if (ViewState["PlanID"] != null)
        {
            this.Culture = "ar-EG";
            DateTime? STAM;
            if (ddlDaySTHour.SelectedValue != "--")
            {
                int Hour = Convert.ToInt32(ddlDaySTHour.SelectedValue);
                if (ddlDaySTDuration.SelectedValue == "ã")
                {
                    if (Hour < 12)
                        Hour += 12;
                }
                else
                {
                    if (Hour == 12)
                        Hour = 0;
                }
                STAM = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                        Hour, Convert.ToInt32(ddlDaySTMin.SelectedValue), 0);
            }
            else
                STAM = null;
            DateTime? STPM;
            if (ddlDaySTHourPM.SelectedValue != "--")
            {
                int Hour = Convert.ToInt32(ddlDaySTHourPM.SelectedValue);
                if (ddlDaySTDurationPM.SelectedValue == "ã")
                {
                    if (Hour < 12)
                        Hour += 12;
                }
                else
                {
                    if (Hour == 12)
                        Hour = 0;
                }
                STPM = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                    Hour, Convert.ToInt32(ddlDaySTMinPM.SelectedValue), 0);
            }
            else
                STPM = null;
            UpdatePlanSPST(int.Parse(ViewState["PlanID"].ToString()), txtdaySP.Text, STAM, txtdaySPPM.Text, STPM);
        }
    }

    #endregion

    protected void gvMM_DataBound(object sender, EventArgs e)
    {
        if (gvMM.Rows.Count > 0) 
        {
            ((CheckBox)gvMM.Rows[0].FindControl("cbxSelect")).Checked = true;
            ((TextBox)gvMM.Rows[0].FindControl("txtQuantity")).Text = "1";
            //gvMM.Rows[0].CssClass = "AltRowStyle";
            //gvMM.Rows[0].Style[HtmlTextWriterStyle.BackgroundColor] = "#BCC9B7";
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

    //protected void gvMM_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    for (int i = 0; i < gvMM.Rows.Count; i++)
    //    {
    //        if (((CheckBox)gvMM.Rows[i].FindControl("cbxSelect")).Checked)
    //        {
    //            int MarketingMaterialsID = int.Parse(gvMM.DataKeys[i].Values["SID"].ToString().Trim());
    //            int Quantity = int.Parse(((TextBox)gvMM.Rows[i].FindControl("txtQuantity")).Text);
    //            if (Quantity > 0) 
    //            {
    //                gvMM.Rows[i].CssClass = "AltRowStyle";
    //            }
    //        }
    //    }
    //}

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
    protected void ddlDaySTHour_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlDaySTMin.SelectedValue = "00";
    }
    protected void ddlDaySTHourPM_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlDaySTMinPM.SelectedValue = "00";
    }
}
   
