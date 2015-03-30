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

public partial class PrivateClinics : Pharma.BMD.BLL.PrivateClinicsBLL
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
            frmViewPrivateClinics.PagerSettings.Visible = false;
            txtSearchName.Enabled = false;
            lblSearch.Enabled = false;
        }
        
        if (!IsPostBack)
        {
            //Get the page that contains the PrivateClinicID passed in the query string
            int ID = -1;
            if (!String.IsNullOrEmpty(CurrentQueryStringsValues.ID))
            {
                int.TryParse(CurrentQueryStringsValues.ID, out ID);
                frmViewPrivateClinics.PageIndex = GetCertainPageByID(ID, !String.IsNullOrEmpty(CurrentQueryStringsValues.TransType));
                BindPrivateClinicsView(!String.IsNullOrEmpty(CurrentQueryStringsValues.TransType));
            }
            else
                BindPrivateClinicsView(false);

            if (frmViewPrivateClinics.DataItemCount > 0)
            {
                AdjustDropDownListsSelection();
                if (ID > -1 && !String.IsNullOrEmpty(CurrentQueryStringsValues.oldRefID))
                {
                    AdjustChangesMarks(Convert.ToInt32(CurrentQueryStringsValues.oldRefID), ID);
                }
            }
            else
            {
                lblNoDataMsg.Text = "No private clinics found in your bricks.";
                HandleIfBlankFormView();
            }
        }
    }

    private void AdjustChangesMarks(int OldID, int NewID)
    {
        dsPrivateClinics.dtPrivateClinicsChangesDataTable dt = SelectPrivateClinicsChanges(OldID, NewID);

        if (dt.Rows.Count > 0)
        {
            foreach (DataColumn dc in dt.Columns)
            {
                if (dt.Rows[0][dc.ColumnName].Equals("True"))
                {
                    if (dc.ColumnName.StartsWith("txt"))
                    {
                        ((TextBox)frmViewPrivateClinics.FindControl(dc.ColumnName)).BackColor = System.Drawing.Color.LightYellow;
                    }
                    else if (dc.ColumnName.StartsWith("ddl"))
                    {
                        ((DropDownList)frmViewPrivateClinics.FindControl(dc.ColumnName)).BackColor = System.Drawing.Color.LightYellow;
                    }
                    else if (dc.ColumnName.StartsWith("cbx") || dc.ColumnName.StartsWith("chk"))
                    {
                        ((CheckBox)frmViewPrivateClinics.FindControl(dc.ColumnName)).BackColor = System.Drawing.Color.LightYellow;
                    }
                }
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
        TransButtons ucTransButtons = (TransButtons)Master.FindControl("ucTransButtons");
        ((ImageButton)ucTransButtons.FindControl("btnSave")).Visible = true;
        ((ImageButton)ucTransButtons.FindControl("btnCancel")).Visible = false;
        ((ImageButton)ucTransButtons.FindControl("btnAdd")).Visible = false;
        ((ImageButton)ucTransButtons.FindControl("btnEdit")).Visible = false;
        ((ImageButton)ucTransButtons.FindControl("btnDelete")).Visible = false;
    }


    private void BindPrivateClinicsView(bool ShowAll)
    {
        Session["ShowAll"] = ShowAll;
        frmViewPrivateClinics.DataSource = odsPrivateClinics;
        frmViewPrivateClinics.DataBind();
    }
    protected void frmViewPrivateClinics_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {
        frmViewPrivateClinics.PageIndex = e.NewPageIndex;
        BindPrivateClinicsView(false);
        AdjustDropDownListsSelection();
        AdjustTransButtons(false);
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
        lblmsg.Text = "";
        ViewState["SaveMode"] = "Edit";
        AdjustReadOnlyFormStatus(false);
        AdjustTransButtons(true);
    }

    protected void ucTransButtons_btnAddEvent(object sender, EventArgs e)
    {
        lblDupName.Visible = false;
        lblmsg.Text = "";
        ViewState["SaveMode"] = "Add";
        AdjustReadOnlyFormStatus(false);
        AdjustTransButtons(true);
        ResetFormtxtboxes();
    }

    protected void ucTransButtons_btnSaveEvent(object sender, EventArgs e)
    {
        lblDupName.Visible = false;
        lblmsg.Text = "";
        int GovID = int.Parse(((DropDownList)frmViewPrivateClinics.FindControl("ddlGov")).Text);
        int CityID = int.Parse(((DropDownList)frmViewPrivateClinics.FindControl("ddlCity")).Text);
        int BrickID = int.Parse(((DropDownList)frmViewPrivateClinics.FindControl("ddlBrick")).Text);
        int PhysicianID;
        if (((DropDownList)frmViewPrivateClinics.FindControl("ddlPhysician")).Items.Count > 0)
            PhysicianID = int.Parse(((DropDownList)frmViewPrivateClinics.FindControl("ddlPhysician")).Text);
        else
        {
            // Error
            lblmsg.Text = "You must have at least one physician to be able to add private clinic.";
            lblmsg.ForeColor = System.Drawing.Color.Red;
            lblmsg.Visible = true;
            return;
        }
        string txtClinicName = ((TextBox)frmViewPrivateClinics.FindControl("txtClinicName")).Text;
        string txtArea = ((TextBox)frmViewPrivateClinics.FindControl("txtArea")).Text;
        string txtAddress = ((TextBox)frmViewPrivateClinics.FindControl("txtAddress")).Text;
        string txtPhone1 = ((TextBox)frmViewPrivateClinics.FindControl("txtPhone1")).Text;
        string txtPhone2 = ((TextBox)frmViewPrivateClinics.FindControl("txtPhone2")).Text;
        string txtMobile = ((TextBox)frmViewPrivateClinics.FindControl("txtMobile")).Text;
        string txtPostalCode = ((TextBox)frmViewPrivateClinics.FindControl("txtPostalCode")).Text;
        string txtEmail = ((TextBox)frmViewPrivateClinics.FindControl("txtEmail")).Text;
        string txtComment = ((TextBox)frmViewPrivateClinics.FindControl("txtComment")).Text;

        if (ViewState["SaveMode"].ToString() == "Add")
        {
            if (!IsPrivateClinicNameExist(txtClinicName))
            {
                int NewPrivateClinicID = 0;
                int Result = AddPrivateClinic(txtClinicName, PhysicianID, BrickID, GovID, CityID, txtArea, txtAddress, txtPhone1, txtPhone2, txtMobile, txtPostalCode, txtEmail, txtComment, out NewPrivateClinicID);
                if (Result == 1)
                {
                    // Added //
                    //// Reload Data //
                    frmViewPrivateClinics.PageIndex = GetCertainPageByID(NewPrivateClinicID, false);
                    BindPrivateClinicsView(false);
                    //
                }
                else
                {
                    if (Result == 2)
                    {
                        //// Reload Data //
                        frmViewPrivateClinics.PageIndex = GetCertainPageByID(NewPrivateClinicID, false);
                        BindPrivateClinicsView(false);
                        //
                        // Added Requested // Pending Request
                        lblmsg.Text = "Your request for adding new private clinic is in pending phase until acceptance from your manager";
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
                lblDupName.Visible = false;
            }
            else
            {
                lblDupName.Visible = true;
                return;
            }
        }
        else if (ViewState["SaveMode"].ToString() == "Edit")
        {
            int PrivateClinicID = (int.Parse(frmViewPrivateClinics.DataKey["PrivateClinicID"].ToString()));
            if (!IsUpdatedPrivateClinicNameExist(PrivateClinicID, txtClinicName))
            {
                string Msg = "";
                int result = UpdatePrivateClinic(PrivateClinicID, txtClinicName, PhysicianID, BrickID, GovID, CityID, txtArea, txtAddress, txtPhone1, txtPhone2, txtMobile, txtPostalCode, txtEmail, txtComment, out Msg);
                if (result == 0)
                {
                    lblmsg.Text = (Msg.Length > 0) ? Msg : "Failed to Edit";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    lblmsg.Visible = true;
                }
                else if (result == 1)
                {
                    // Updated //
                    frmViewPrivateClinics.PageIndex = GetCertainPageByID(PrivateClinicID, false);
                    BindPrivateClinicsView(false);
                }
                else
                {
                    //// Reload Data //
                    frmViewPrivateClinics.PageIndex = GetCertainPageByID(PrivateClinicID, false);
                    BindPrivateClinicsView(false);
                    //
                    // Updated Requested // Pending Request
                    lblmsg.Text = "Your request for updating private clinic is in pending phase until acceptance from your manager";
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
        if (frmViewPrivateClinics.DataItemCount > 0)
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
        BindPrivateClinicsView(false);
        AdjustReadOnlyFormStatus(true);
        AdjustDropDownListsSelection();
        AdjustTransButtons(false);
    }

    protected void ucTransButtons_btnDeleteEvent(object sender, EventArgs e)
    {
        lblDupName.Visible = false;
        lblmsg.Text = "";
        int PrivateClinicID = (int.Parse(frmViewPrivateClinics.DataKey["PrivateClinicID"].ToString()));
        int result = DeletePrivateClinic(PrivateClinicID);
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
            if (frmViewPrivateClinics.PageIndex > 1)
                frmViewPrivateClinics.PageIndex--;
            BindPrivateClinicsView(false);
        }
        else
        {
            // Delete Requested // Pending Request
            lblmsg.Text = "Your request for Delete Private Clinic is in Pending phase until Acceptance from your Manager";
            lblmsg.Visible = true;
        }

    }


    #endregion

    #region Page Controls Handler
    
    private void AdjustDropDownListsSelection()
    {
        ((DropDownList)frmViewPrivateClinics.FindControl("ddlBrick")).SelectedValue = ((TextBox)frmViewPrivateClinics.FindControl("txtBrickID")).Text;
        ((DropDownList)frmViewPrivateClinics.FindControl("ddlGov")).SelectedValue = ((TextBox)frmViewPrivateClinics.FindControl("txtGov")).Text;
        ((DropDownList)frmViewPrivateClinics.FindControl("ddlCity")).SelectedValue = ((TextBox)frmViewPrivateClinics.FindControl("txtCity")).Text;
        ((DropDownList)frmViewPrivateClinics.FindControl("ddlPhysician")).SelectedValue = ((TextBox)frmViewPrivateClinics.FindControl("txtPhysician")).Text;

    }
    protected void ddlGov_SelectedIndexChanged(object sender, EventArgs e)
    {
        LookupsBLL objLookupsBLL = new LookupsBLL();
        ((TextBox)(frmViewPrivateClinics.FindControl("txtGov"))).Text = ((DropDownList)(frmViewPrivateClinics.FindControl("ddlGov"))).SelectedValue;
        ((DropDownList)(frmViewPrivateClinics.FindControl("ddlCity"))).DataSource = objLookupsBLL.GetCitiesByGov(int.Parse(((DropDownList)(frmViewPrivateClinics.FindControl("ddlGov"))).SelectedValue));
        ((DropDownList)(frmViewPrivateClinics.FindControl("ddlCity"))).DataBind();
    }
    protected void ddlGov_DataBound(object sender, EventArgs e)
    {
        LookupsBLL objLookupsBLL = new LookupsBLL();
        ((DropDownList)(frmViewPrivateClinics.FindControl("ddlCity"))).DataSource = objLookupsBLL.GetCitiesByGov(int.Parse(((DropDownList)(frmViewPrivateClinics.FindControl("ddlGov"))).SelectedValue));
        ((DropDownList)(frmViewPrivateClinics.FindControl("ddlCity"))).DataBind();

    }

    private void AdjustTransButtons(bool Flag)
    {
        TransButtons ucTransButtons = (TransButtons)Master.FindControl("ucTransButtons");
        ((ImageButton)ucTransButtons.FindControl("btnCancel")).Visible = Flag;
        ((ImageButton)ucTransButtons.FindControl("btnSave")).Visible = Flag;
        ((ImageButton)ucTransButtons.FindControl("btnAdd")).Visible = !Flag;
        ((ImageButton)ucTransButtons.FindControl("btnEdit")).Visible = !Flag;
    }

    private void ResetFormtxtboxes()
    {
        ((TextBox)frmViewPrivateClinics.FindControl("txtClinicName")).Text = "";
        ((TextBox)frmViewPrivateClinics.FindControl("txtGov")).Text = "";
        ((TextBox)frmViewPrivateClinics.FindControl("txtCity")).Text = "";
        ((TextBox)frmViewPrivateClinics.FindControl("txtArea")).Text = "";
        ((TextBox)frmViewPrivateClinics.FindControl("txtAddress")).Text = "";
        ((TextBox)frmViewPrivateClinics.FindControl("txtBrickID")).Text = "";
        ((TextBox)frmViewPrivateClinics.FindControl("txtPhone1")).Text = "";
        ((TextBox)frmViewPrivateClinics.FindControl("txtPhone2")).Text = "";
        ((TextBox)frmViewPrivateClinics.FindControl("txtMobile")).Text = "";
        ((TextBox)frmViewPrivateClinics.FindControl("txtPostalCode")).Text = "";
        ((TextBox)frmViewPrivateClinics.FindControl("txtEmail")).Text = "";
        ((TextBox)frmViewPrivateClinics.FindControl("txtComment")).Text = "";
    }

    protected void AdjustReadOnlyFormStatus(bool Flag)
    {
        ((TextBox)frmViewPrivateClinics.FindControl("txtClinicName")).ReadOnly = Flag;
        ((TextBox)frmViewPrivateClinics.FindControl("txtGov")).ReadOnly = Flag;
        ((TextBox)frmViewPrivateClinics.FindControl("txtCity")).ReadOnly = Flag;
        ((TextBox)frmViewPrivateClinics.FindControl("txtArea")).ReadOnly = Flag;
        ((TextBox)frmViewPrivateClinics.FindControl("txtAddress")).ReadOnly = Flag;
        ((TextBox)frmViewPrivateClinics.FindControl("txtBrickID")).ReadOnly = Flag;
        ((TextBox)frmViewPrivateClinics.FindControl("txtPhone1")).ReadOnly = Flag;
        ((TextBox)frmViewPrivateClinics.FindControl("txtPhone2")).ReadOnly = Flag;
        ((TextBox)frmViewPrivateClinics.FindControl("txtMobile")).ReadOnly = Flag;
        ((TextBox)frmViewPrivateClinics.FindControl("txtPostalCode")).ReadOnly = Flag;
        ((TextBox)frmViewPrivateClinics.FindControl("txtEmail")).ReadOnly = Flag;
        ((TextBox)frmViewPrivateClinics.FindControl("txtComment")).ReadOnly = Flag;
        ((DropDownList)frmViewPrivateClinics.FindControl("ddlGov")).Enabled = !Flag;
        ((DropDownList)frmViewPrivateClinics.FindControl("ddlCity")).Enabled = !Flag;
        ((DropDownList)frmViewPrivateClinics.FindControl("ddlBrick")).Enabled = !Flag;
        ((DropDownList)frmViewPrivateClinics.FindControl("ddlPhysician")).Enabled = !Flag;
    }
    #endregion
    
    #region Search Handler

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        string[] Names = new string[0];
        string ErrMsg = "";
        PrivateClinics currentPage = new PrivateClinics();
        Names = currentPage.GetAllEntitiesNamesByUser("PrivateClinics", prefixText, out ErrMsg);
        return Names;
    }

    protected void txtSearchName_TextChanged(object sender, EventArgs e)
    {
        frmViewPrivateClinics.PageIndex = GetCertainPageByName(txtSearchName.Text, false);
        BindPrivateClinicsView(false);
        AdjustDropDownListsSelection();
        AdjustTransButtons(false);
        txtSearchName.Text = "";
        lblmsg.Visible = false;
    }


    #endregion

}
