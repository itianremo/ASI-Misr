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

public partial class Distributors : Pharma.BMD.BLL.DistributorsBLL
{
    private bool TransExist = false;
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
              
        if (this.Master.ToString() != "ASP.blankmasterpage_master")
        {
            InitiateEventsHandlers();
        }
        else
        {
            frmViewDistributors.PagerSettings.Visible = false;
        }
        
        if (!IsPostBack)
        {
            //Get the page that contains the ProductID passed in the query string
            if (!String.IsNullOrEmpty(CurrentQueryStringsValues.ID))
            {
                int ID;
                int.TryParse(CurrentQueryStringsValues.ID, out ID);
                frmViewDistributors.PageIndex = GetCertainPageByID(ID, !String.IsNullOrEmpty(CurrentQueryStringsValues.TransType));
                BindDistributorsView(!String.IsNullOrEmpty(CurrentQueryStringsValues.TransType));

            }
            else
            {
                BindDistributorsView(false);
            }
            
            if (frmViewDistributors.DataItemCount > 0)
            {
                bool ShowAll = false;
                if (!String.IsNullOrEmpty(CurrentQueryStringsValues.TransType))
                {
                    if (CurrentQueryStringsValues.TransType == "Update" || CurrentQueryStringsValues.TransType == "Add")
                    {
                        ShowAll = true;
                    }
                }
                BindgvBranches(ShowAll);
            }
            else
            {
                lblNoDataMsg.Text = "No Distributors found in your bricks.";
                HandleIfBlankFormView();
            }
        }
    }
  
    #endregion

    #region Form View Handler

    private void HandleIfBlankFormView()
    {
        ViewState["SaveMode"] = "Add";
        ((TextBox)frmViewDistributors.FindControl("txtDistributorName")).ReadOnly = false;
        //
        TransButtons ucTransButtons = (TransButtons)Master.FindControl("ucTransButtons");
        ((ImageButton)ucTransButtons.FindControl("btnSave")).Visible = true;
        ((ImageButton)ucTransButtons.FindControl("btnCancel")).Visible = false;
        ((ImageButton)ucTransButtons.FindControl("btnAdd")).Visible = false;
        ((ImageButton)ucTransButtons.FindControl("btnEdit")).Visible = false;
        ((ImageButton)ucTransButtons.FindControl("btnDelete")).Visible = false;
    }

    private void BindDistributorsView(bool ShowAll)
    {
        Session["ShowAll"] = ShowAll;
        frmViewDistributors.DataSource = odsDistributors;
        frmViewDistributors.DataBind();
    }

    protected void frmViewDistributors_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {
        frmViewDistributors.PageIndex = e.NewPageIndex;
        BindDistributorsView(false);
        ViewState["gvBranchesSelectedIndex"] = null;
        BindgvBranches(false);
        AdjustTransButtons(false);
        lblmsg.Visible = false;
    }
  
    protected void frmViewDistributors_DataBound(object sender, EventArgs e)
    {
        if (this.Master.ToString() == "ASP.blankmasterpage_master")
        {
            ((UpdatePanel)frmViewDistributors.FindControl("upnlAddBranch")).Visible = false;
            ((TextBox)frmViewDistributors.FindControl("txtSearchName")).Enabled = false;
            ((Label)frmViewDistributors.FindControl("lblSearch")).Enabled = false;
            ((TextBox)frmViewDistributors.FindControl("txtDistributorName")).ReadOnly = true;
        }
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

    private void AdjustTransButtons(bool Flag)
    {
        if (this.MasterPageFile != "/4A-Pharma/BlankMasterPage.master")
        {
            TransButtons ucTransButtons = (TransButtons)Master.FindControl("ucTransButtons");
            ((ImageButton)ucTransButtons.FindControl("btnCancel")).Visible = Flag;
            ((ImageButton)ucTransButtons.FindControl("btnSave")).Visible = Flag;
            ((ImageButton)ucTransButtons.FindControl("btnAdd")).Visible = !Flag;
            ((ImageButton)ucTransButtons.FindControl("btnEdit")).Visible = !Flag;
        }
    }

    private void ResetFormtxtboxes()
    {
        ((TextBox)frmViewDistributors.FindControl("txtDistributorName")).Text = "";
        ((UpdatePanel)frmViewDistributors.FindControl("upnlAddBranch")).Visible = false;
        ((UpdatePanel)frmViewDistributors.FindControl("upnlBranches")).Visible = false;
        ((UpdatePanel)frmViewDistributors.FindControl("upnlBricks")).Visible = false;
        frmViewDistributors.Height = 0;
    }

    protected void AdjustReadOnlyFormStatus(bool Flag)
    {
        ((TextBox)frmViewDistributors.FindControl("txtDistributorName")).ReadOnly = Flag;
        // Handler for Add new Branch Controls //
        txtNewBranchName.ReadOnly = !Flag;
        txtNewBranchAddress.ReadOnly = !Flag;
        btnNewBranch.Enabled = Flag;
    }

    #endregion

    #region Search Handler

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        string[] Names = new string[0];
        string ErrMsg = "";
        Distributors currentPage = new Distributors();
        Names = currentPage.GetAllEntitiesNamesByUser("Distributors", prefixText, out ErrMsg);
        return Names;
    }
    protected void txtSearchName_TextChanged(object sender, EventArgs e)
    {
        string txtSearchDistributor = ((TextBox)frmViewDistributors.FindControl("txtSearchName")).Text ;
        frmViewDistributors.PageIndex = GetCertainPageByName(txtSearchDistributor,false);
        BindDistributorsView(false);
        ViewState["gvBranchesSelectedIndex"] = null;
        BindgvBranches(false);
        AdjustTransButtons(false);
        ((TextBox)frmViewDistributors.FindControl("txtSearchName")).Text = "";
        lblmsg.Visible = false;
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
        ((Label)frmViewDistributors.FindControl("lblDistDupName")).Visible = false;
        lblmsg.Text = "";
        ViewState["SaveMode"] = "Edit";
        EnableGridview(gvBricks, true, false, false);
        EditgvBranchesItem(true);
        AdjustReadOnlyFormStatus(false);
        AdjustTransButtons(true);
    }

    protected void ucTransButtons_btnAddEvent(object sender, EventArgs e)
    {
        lblDupName.Visible = false;
        ((Label)frmViewDistributors.FindControl("lblDistDupName")).Visible = false;
        lblmsg.Text = "";
        ViewState["SaveMode"] = "Add";
        EnableGridview(gvBricks, true, false, true);
        EditgvBranchesItem(false);
        AdjustReadOnlyFormStatus(false);
        AdjustTransButtons(true);
        ResetFormtxtboxes();
    }

    protected void ucTransButtons_btnSaveEvent(object sender, EventArgs e)
    {
        if (lblDupName != null)
            lblDupName.Visible = false;
        if (lblmsg != null)
            lblmsg.Text = "";
        string DistributorName = ((TextBox)frmViewDistributors.FindControl("txtDistributorName")).Text;

        if (ViewState["SaveMode"].ToString() == "Add")
        {
            if (!IsDistributorNameExist(DistributorName))
            {
                int NewDistributorID = 0;
                int Result = AddNewDistributor(DistributorName, out NewDistributorID);
                if (Result == 1)
                {
                    // Added //
                    //// Reload Data //
                    frmViewDistributors.PageIndex = GetCertainPageByID(NewDistributorID, false);
                    BindDistributorsView(false);
                }
                else
                {
                    if (Result == 2)
                    {
                        // Added Requested // Pending Request
                        frmViewDistributors.PageIndex = 0;
                        BindDistributorsView(false);
                        lblmsg.ForeColor = System.Drawing.Color.Green;
                        lblmsg.Text = "Your request for adding new Distributor is in pending phase until acceptance from your manager";
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
                if (frmViewDistributors.DataItemCount > 0)
                {
                    ((Label)frmViewDistributors.FindControl("lblDistDupName")).Visible = false;
                }
                else
                {
                    lblNoDataMsg.Text = "No Distributors found in your bricks.";
                    HandleIfBlankFormView();
                }
            }
            else
            {
                if (frmViewDistributors.DataItemCount > 0)
                {
                    ((Label)frmViewDistributors.FindControl("lblDistDupName")).Visible = true;
                }
                else
                {
                    lblNoDataMsg.Text = "Duplicated name. No Distributors found in your bricks.";
                    HandleIfBlankFormView();
                }
            }
        }
        else if (ViewState["SaveMode"].ToString() == "Edit")
        {
            int DistributorID = (int.Parse(frmViewDistributors.DataKey["DistributorID"].ToString()));
            if (!IsUpdatedDistributorNameExist(DistributorID, DistributorName))
            {
                string Msg = "";
                int result = UpdateDistributor(DistributorID, DistributorName, out Msg);
                if (result == 0)
                {
                    lblmsg.Text = (Msg.Length > 0) ? Msg : "Failed to Edit";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    lblmsg.Visible = true;
                }
                else if (result == 1)
                {
                    // Updated //
                    int BranchID = int.Parse(gvBranches.DataKeys[gvBranches.SelectedIndex]["BranchID"].ToString());
                    string BranchName = ((TextBox)gvBranches.Rows[gvBranches.SelectedIndex].FindControl("txtBranchName")).Text;
                    string BranchAddress = ((TextBox)gvBranches.Rows[gvBranches.SelectedIndex].FindControl("txtBranchAddress")).Text;

                    UpdateBranch(DistributorID, BranchID, BranchName, BranchAddress);
                    //
                    // Update the Rest of Transactions //
                    SaveChangedValues(BranchID, GetChangedValues(((DataTable)ViewState["BranchBricks"]), "Selected", gvBricks, "cbxSelectBrick", 1));
                }
                else
                {
                    int BranchID = int.Parse(gvBranches.DataKeys[gvBranches.SelectedIndex]["BranchID"].ToString());
                    string BranchName = ((TextBox)gvBranches.Rows[gvBranches.SelectedIndex].FindControl("txtBranchName")).Text;
                    string BranchAddress = ((TextBox)gvBranches.Rows[gvBranches.SelectedIndex].FindControl("txtBranchAddress")).Text;

                    UpdateBranch(DistributorID, BranchID, BranchName, BranchAddress);
                    //
                    // Update the Rest of Transactions //
                    SaveChangedValues(BranchID, GetChangedValues(((DataTable)ViewState["BranchBricks"]), "Selected", gvBricks, "cbxSelectBrick", 1));
                    // Updated Requested // Pending Request
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                    lblmsg.Text = "Your request for updating Distributor is in pending phase until acceptance from your manager";
                    lblmsg.Visible = true;
                    
                }
                if (frmViewDistributors.DataItemCount > 0)
                {
                    ((Label)frmViewDistributors.FindControl("lblDistDupName")).Visible = false;
                }
                else
                {
                    lblNoDataMsg.Text = "No Distributors found in your bricks.";
                    HandleIfBlankFormView();
                }
            }
            else
            {
                if (frmViewDistributors.DataItemCount > 0)
                {
                    ((Label)frmViewDistributors.FindControl("lblDistDupName")).Visible = true;
                }
                else
                {
                    lblNoDataMsg.Text = "No Distributors found in your bricks.";
                    HandleIfBlankFormView();
                }
            }
        }
  
        if (frmViewDistributors.DataItemCount > 0)
        {
            BindgvBranches(false);
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
        ((Label)frmViewDistributors.FindControl("lblDistDupName")).Visible = false;
        lblmsg.Text = "";
        BindDistributorsView(false);
        BindgvBranches(false);
        AdjustReadOnlyFormStatus(true);
        AdjustTransButtons(false);
    }

    protected void ucTransButtons_btnDeleteEvent(object sender, EventArgs e)
    {
        lblDupName.Visible = false;
        ((Label)frmViewDistributors.FindControl("lblDistDupName")).Visible = false;
        lblmsg.Text = "";
        int DistributorID = (int.Parse(frmViewDistributors.DataKey["DistributorID"].ToString()));
        int result = DeleteDistributor(DistributorID);
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
            if (frmViewDistributors.PageIndex > 1)
                frmViewDistributors.PageIndex--;
            BindDistributorsView(false);
            BindgvBranches(false);
            AdjustReadOnlyFormStatus(true);
            AdjustTransButtons(false);
        }
        else
        {
            // Delete Requested // Pending Request
            lblmsg.ForeColor = System.Drawing.Color.Green;
            lblmsg.Text = "Your request for Delete Distributor is in Pending phase until Acceptance from your Manager";
            lblmsg.Visible = true;
        }
    }

    #endregion

    #region Branches GridView Handler

    private void BindgvBranches(bool ShowAll)
    {
        if (CurrentQueryStringsValues.TransType == "Update")
        {
            gvBranches.DataSource = GetDistributorBranches(int.Parse(CurrentQueryStringsValues.oldRefID), ShowAll);
        }
        else
        {
            gvBranches.DataSource = GetDistributorBranches(int.Parse(frmViewDistributors.DataKey["DistributorID"].ToString()), ShowAll);
        }
        gvBranches.DataBind();
        if (gvBranches.Rows.Count > 0)
        {
            int gvBranchesSelectedIndex = 0;
            if (ViewState["gvBranchesSelectedIndex"] != null)
            {
                gvBranchesSelectedIndex = int.Parse(ViewState["gvBranchesSelectedIndex"].ToString());
            }
            ViewState["gvBranchesSelectedIndex"] = gvBranchesSelectedIndex;
            gvBranches.SelectedIndex = gvBranchesSelectedIndex;
            if (CurrentQueryStringsValues.TransType == "Update")
            {
                BindgvBricks(int.Parse(gvBranches.DataKeys[gvBranchesSelectedIndex]["BranchID"].ToString()), ShowAll);
            }
            else
            {
                BindgvBricks(int.Parse(gvBranches.DataKeys[gvBranchesSelectedIndex]["BranchID"].ToString()), ShowAll);
            }
            
            UpdatePanel upnlBranches = (UpdatePanel)frmViewDistributors.FindControl("upnlBranches");
            upnlBranches.Visible = true;
            UpdatePanel upnlBricks = (UpdatePanel)frmViewDistributors.FindControl("upnlBricks");
            upnlBricks.Visible = true;
        }
        else
        {
            frmViewDistributors.Height = 0;
        }
    }

    private void EditgvBranchesItem(bool EditMode)
    {
        if (gvBranches.Rows.Count > 0)
        {
            if (CurrentUserInfo.UserRole != UsersRoles.SuperAdmin)
            {
                gvBranches.Columns[2].Visible = EditMode;
            }

            if (gvBranches.Rows[gvBranches.SelectedIndex].RowType == DataControlRowType.DataRow)
            {
                gvBranches.Rows[gvBranches.SelectedIndex].FindControl("txtBranchName").Visible = EditMode;
                gvBranches.Rows[gvBranches.SelectedIndex].FindControl("txtBranchAddress").Visible = EditMode;
                gvBranches.Rows[gvBranches.SelectedIndex].FindControl("lblBranchName").Visible = !EditMode;
                gvBranches.Rows[gvBranches.SelectedIndex].FindControl("lblBranchAddress").Visible = !EditMode;
                //
                if (EditMode)
                {
                    // Commented by Yasser to allow user to delete any row except (EditMode) row
                    //for (int i = 0; i < gvBranches.Rows.Count; i++)
                    //{
                    //    gvBranches.Rows[i].Attributes.Clear();
                    //    ((LinkButton)gvBranches.Rows[i].FindControl("lbtnDelete")).Attributes.Clear();
                    //    ((LinkButton)gvBranches.Rows[i].FindControl("lbtnDelete")).Enabled = !EditMode;
                    //}
                    gvBranches.Rows[gvBranches.SelectedIndex].Attributes.Clear();
                    ((LinkButton)gvBranches.Rows[gvBranches.SelectedIndex].FindControl("lbtnDelete")).Attributes.Clear();
                    ((LinkButton)gvBranches.Rows[gvBranches.SelectedIndex].FindControl("lbtnDelete")).Enabled = (!EditMode);
                }
            }
        }
    }

    protected void gvBranches_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (String.IsNullOrEmpty(CurrentQueryStringsValues.TransType))
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='none';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvBranches, "Select$" + e.Row.RowIndex);
                //
                LinkButton btn = (LinkButton) e.Row.Cells[2].FindControl("lbtnDelete");
                btn.Attributes.Add("onclick", "return confirm('Are you sure you want to Delete this Branch?')");
            }
        }
    }

    protected void gvBranches_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        if (ViewState["gvBranchesSelectedIndex"] != null)
        {
            int PreviousSelectedIndex = int.Parse(ViewState["gvBranchesSelectedIndex"].ToString());
            gvBranches.Rows[PreviousSelectedIndex].FindControl("txtBranchName").Visible = false;
            gvBranches.Rows[PreviousSelectedIndex].FindControl("txtBranchAddress").Visible = false;
            gvBranches.Rows[PreviousSelectedIndex].FindControl("lblBranchName").Visible = true;
            gvBranches.Rows[PreviousSelectedIndex].FindControl("lblBranchAddress").Visible = true;
        }

        ViewState["gvBranchesSelectedIndex"] = e.NewSelectedIndex;
        bool ShowAll = false;
        if (CurrentQueryStringsValues.TransType == "Update" || CurrentQueryStringsValues.TransType == "Add")
            ShowAll = true;
        BindgvBricks(int.Parse(gvBranches.DataKeys[e.NewSelectedIndex]["BranchID"].ToString()), ShowAll);
        AdjustReadOnlyFormStatus(true);
        AdjustTransButtons(false);
    }

    protected void gvBranches_DataBound(object sender, EventArgs e)
    {
        gvBranches.Columns[2].Visible = (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin);
    }

    protected void gvBranches_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int BranchID = (Convert.ToInt32(gvBranches.DataKeys[e.RowIndex].Value));
        int DistributorID = (int.Parse(frmViewDistributors.DataKey["DistributorID"].ToString()));
        string Msg = "";
        int result = DeleteBranch(DistributorID, BranchID, out Msg);
        if (result == 0)
        {
            // Failed
            lblmsg.Text = (Msg.Length > 0) ? Msg : "Failed to delete";
            lblmsg.ForeColor = System.Drawing.Color.Red;
            lblmsg.Visible = true;

        }
        else if (result == 1)
        {
            // Direct Delete //
            //// Reload Data after record is deleted//
            BindDistributorsView(false);
            BindgvBranches(false);
            AdjustReadOnlyFormStatus(true);
            AdjustTransButtons(false);
        }
        else
        {
            // Delete Requested // Pending Request
            //if (!TransExist)
            //{
            //    TransExist = true;
                
                string DistributorName = ((TextBox)frmViewDistributors.FindControl("txtDistributorName")).Text;
                
                UpdateDistributor(DistributorID, DistributorName, out Msg);
            //}
            lblmsg.ForeColor = System.Drawing.Color.Green;
            lblmsg.Text = (Msg.Length > 0) ? Msg : "Your request for Delete Branch is in Pending phase until Acceptance from your Manager";
            lblmsg.Visible = true;
        }
    }
    #endregion

    #region Add New Branch Event
    protected void btnNewBranch_Click(object sender, EventArgs e)
    {
        if (txtNewBranchName.Text == "" && txtNewBranchAddress.Text == "")
        {
            lblVBranchName.Visible = true;
            lblVBranchAddress.Visible = true;
            return;
        }
        else
        {
            lblVBranchName.Visible = false;
            lblVBranchAddress.Visible = false;
        }

        if (txtNewBranchName.Text == "")
        {
            lblVBranchName.Visible = true;
            return;
        }
        else
        {
            lblVBranchAddress.Visible = false;

        }

        if (txtNewBranchAddress.Text == "")
        {
            lblVBranchAddress.Visible = true;
            return;
        }
        else
        {
            lblVBranchAddress.Visible = false;

        }

        if (txtNewBranchName.Text != "" && txtNewBranchAddress.Text != "")
        {
            int DistributorID = (int.Parse(frmViewDistributors.DataKey["DistributorID"].ToString()));
            string DistributorName = ((TextBox)frmViewDistributors.FindControl("txtDistributorName")).Text;
            if (!IsBranchNameExist(txtNewBranchName.Text))
            {
                int Result = AddNewBranch(DistributorID, DistributorName, txtNewBranchName.Text, txtNewBranchAddress.Text);
                if (Result == 1)
                {
                    // Added //
                    //// Reload Data //
                    BindgvBranches(false);
                }
                else
                {
                    if (Result == 2)
                    {
                        // Added Requested // Pending Request
                        lblmsg.ForeColor = System.Drawing.Color.Green;
                        lblmsg.Text = "Your request for adding new Branch is in pending phase until acceptance from your manager";
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
                txtNewBranchName.Text = "";
                txtNewBranchAddress.Text = "";
                ((Label)frmViewDistributors.FindControl("lblDupName")).Visible = false;
            }
            else
                ((Label)frmViewDistributors.FindControl("lblDupName")).Visible = true;
        }

    }
    #endregion

    #region Bricks GridView Handler

    private void BindgvBricks(int BranchID, bool ShowAll)
    {
        ViewState["BranchBricks"] = GetBranchBricks(BranchID, ShowAll);
        gvBricks.DataSource = ViewState["BranchBricks"];
        gvBricks.DataBind();
    }

    protected void gvBricks_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (((CheckBox)e.Row.FindControl("cbxSelectBrick")).Checked)
            {
                e.Row.CssClass = "GridhighlightedRowsStyle";
            }
        }
    }

    private DataTable GetChangedValues(DataTable dtOriginalData, string OrgColumnName, GridView GridViewName, string CheckBoxName, int CheckBoxNameCellLocation)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("CurrentID"));
        dt.Columns.Add(new DataColumn("CurrentcbxStatus"));

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
        return dt;
    }

    private void SaveChangedValues(int BranchID, DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            int ID = int.Parse(dt.Rows[i]["CurrentID"].ToString());
            bool Status = bool.Parse(dt.Rows[i]["CurrentcbxStatus"].ToString());
            if (Status)
            {
                AssignBranchToBrick(BranchID, ID);
            }
            else
            {
                UnAssignBranchToBrick(BranchID, ID);
            }

        }
    }


    #endregion
}
