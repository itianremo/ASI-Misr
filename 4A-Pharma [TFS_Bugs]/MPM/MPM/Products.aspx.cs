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

public partial class Products : Pharma.BMD.BLL.ProductsBLL
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
            frmViewProducts.PagerSettings.Visible = false;
            txtSearchName.Enabled = false;
            lblSearch.Enabled = false;
        }

        if (!IsPostBack)
        {
            //Get the page that contains the ProductID passed in the query string
            int ID = -1;
            if (!String.IsNullOrEmpty(CurrentQueryStringsValues.ID))
            {
                int.TryParse(CurrentQueryStringsValues.ID, out ID);
                frmViewProducts.PageIndex = GetCertainPageByID(ID, !String.IsNullOrEmpty(CurrentQueryStringsValues.TransType));
                BindProductsView(!String.IsNullOrEmpty(CurrentQueryStringsValues.TransType));

            }
            else
            {
                BindProductsView(false);
            }

            if (frmViewProducts.DataItemCount > 0)
            {
                AdjustDropDownListsSelection();
                
                if (ID > -1 && !String.IsNullOrEmpty(CurrentQueryStringsValues.oldRefID))
                {
                    AdjustChangesMarks(Convert.ToInt32(CurrentQueryStringsValues.oldRefID), ID);
                }
            }
            else
            {
                lblNoDataMsg.Text = "You have no products assigned.";
                HandleIfBlankFormView();
            }
        }
    }

    private void AdjustChangesMarks(int OldID, int NewID)
    {
        dsProducts.dtProductsChangesDataTable dt = SelectProductsChanges(OldID, NewID);

        if (dt.Rows.Count > 0)
        {
            foreach (DataColumn dc in dt.Columns)
            {
                if (dt.Rows[0][dc.ColumnName].Equals("True"))
                {
                    if (dc.ColumnName.StartsWith("txt"))
                    {
                        ((TextBox)frmViewProducts.FindControl(dc.ColumnName)).BackColor = System.Drawing.Color.LightYellow;
                    }
                    else if (dc.ColumnName.StartsWith("ddl"))
                    {
                        ((DropDownList)frmViewProducts.FindControl(dc.ColumnName)).BackColor = System.Drawing.Color.LightYellow;
                    }
                    else if (dc.ColumnName.StartsWith("cbx") || dc.ColumnName.StartsWith("chk"))
                    {
                        ((CheckBox)frmViewProducts.FindControl(dc.ColumnName)).BackColor = System.Drawing.Color.LightYellow;
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

    private void BindProductsView(bool ShowAll)
    {
        Session["ShowAll"] = ShowAll;
        frmViewProducts.DataSource = odsProducts;
        frmViewProducts.DataBind();
    }

    protected void frmViewProducts_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {
        frmViewProducts.PageIndex = e.NewPageIndex;
        BindProductsView(false);
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
        ViewState["SaveMode"] = "Edit";
        AdjustReadOnlyFormStatus(false);
        AdjustTransButtons(true);
    }

    protected void ucTransButtons_btnAddEvent(object sender, EventArgs e)
    {
        ViewState["SaveMode"] = "Add";
        AdjustReadOnlyFormStatus(false);
        AdjustTransButtons(true);
        ResetFormtxtboxes();
    }

    protected void ucTransButtons_btnSaveEvent(object sender, EventArgs e)
    {
        int ProductsForms = int.Parse(((DropDownList)frmViewProducts.FindControl("ddlProductsForms")).SelectedValue);
        string txtProductName = ((TextBox)frmViewProducts.FindControl("txtProductName")).Text;
        string txtComposition = ((TextBox)frmViewProducts.FindControl("txtComposition")).Text;
        string txtIndications = ((TextBox)frmViewProducts.FindControl("txtIndications")).Text;
        int txtDosage = int.Parse(((DropDownList)frmViewProducts.FindControl("ddlDosage")).SelectedValue);
        int txtPackSize = int.Parse(((DropDownList)frmViewProducts.FindControl("ddlPackSize")).SelectedValue);
        decimal txtPrice = Convert.ToDecimal(((TextBox)frmViewProducts.FindControl("txtPrice")).Text);
        //
        int DosageUnit = 1;
        int PackSizeUnit = 1;
        int CID = 1;
        //
        if (ViewState["SaveMode"].ToString() == "Add")
        {
            int NewProductID = 0;
            if (!IsProductNameDuplicated(txtProductName, ProductsForms))
            {
                int Result = AddProduct(txtProductName, ProductsForms, txtComposition, txtIndications, txtDosage, txtPackSize, txtPrice, DosageUnit, PackSizeUnit, CID, out NewProductID);
                if (Result == 1)
                {
                    // Added //
                    //// Reload Data //
                    lblmsg.Visible = false;
                    frmViewProducts.PageIndex = GetCertainPageByID(NewProductID, false);
                    BindProductsView(false);
                    //
                }
                else
                {
                    if (Result == 2)
                    {
                        //// Reload Data //
                        frmViewProducts.PageIndex = GetCertainPageByID(NewProductID, false);
                        BindProductsView(false);
                        // Added Requested // Pending Request
                        lblmsg.Text = "Your request for adding new product is in Pending phase until Acceptance from your Manager";
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
                lblmsg.Text = "Can't duplicate product name in the same form";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Visible = true;
                return;
            }
        }
        else if (ViewState["SaveMode"].ToString() == "Edit")
        {
            int ProductID = (int.Parse(frmViewProducts.DataKey["ProductID"].ToString()));
            if (!IsUpdatedProductNameDuplicated(ProductID, txtProductName, ProductsForms))
            {
                string Msg = "";
                int result = UpdateProduct(ProductID, txtProductName, ProductsForms, txtComposition, txtIndications, txtDosage, txtPackSize, txtPrice, DosageUnit, PackSizeUnit, CID, out Msg);
                if (result == 0)
                {
                    // Failed
                    lblmsg.Text = (Msg.Length > 0) ? Msg : "Failed to Edit";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    lblmsg.Visible = true;
                }
                else if (result == 1)
                {
                    // Direct Updated //
                    lblmsg.Visible = false;
                }
                else
                {
                    // Updated Requested // Pending Request
                    lblmsg.Text = "Your request for Updating product is in Pending phase until Acceptance from your Manager";
                    lblmsg.Visible = true;
                }
            }
            else
            {
                // Error
                lblmsg.Text = "Can't duplicate product name in the same form";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Visible = true;
                return;
            }
            //// Reload Data ////
            frmViewProducts.PageIndex = GetCertainPageByID(ProductID, false);
            BindProductsView(false);

        }
        if (frmViewProducts.DataItemCount > 0)
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
        lblmsg.Text = "";
        BindProductsView(false);
        AdjustReadOnlyFormStatus(true);
        AdjustDropDownListsSelection();
        AdjustTransButtons(false);
    }

    protected void ucTransButtons_btnDeleteEvent(object sender, EventArgs e)
    {
        int ProductID = (int.Parse(frmViewProducts.DataKey["ProductID"].ToString()));
        int result = DeleteProduct(ProductID);
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
            if (frmViewProducts.PageIndex > 1)
                frmViewProducts.PageIndex--;
            BindProductsView(false);
        }
        else
        {
            // Delete Requested // Pending Request
            lblmsg.Text = "Your request for Delete product is in Pending phase until Acceptance from your Manager";
            lblmsg.Visible = true;
        }

    }

    #endregion

    #region Page Controls Handler


    private void AdjustTransButtons(bool Flag)
    {
        TransButtons ucTransButtons = (TransButtons)Master.FindControl("ucTransButtons");
        ((ImageButton)ucTransButtons.FindControl("btnCancel")).Visible = Flag;
        ((ImageButton)ucTransButtons.FindControl("btnSave")).Visible = Flag;
        ((ImageButton)ucTransButtons.FindControl("btnAdd")).Visible = !Flag;
        ((ImageButton)ucTransButtons.FindControl("btnEdit")).Visible = !Flag;
        ((ImageButton)ucTransButtons.FindControl("btnDelete")).Visible = !Flag;
    }

    private void ResetFormtxtboxes()
    {
        ((TextBox)frmViewProducts.FindControl("txtProductName")).Text = "";
        ((TextBox)frmViewProducts.FindControl("txtComposition")).Text = "";
        ((TextBox)frmViewProducts.FindControl("txtIndications")).Text = "";
        ((TextBox)frmViewProducts.FindControl("txtPrice")).Text = "";
    }

    protected void AdjustReadOnlyFormStatus(bool Flag)
    {
        ((TextBox)frmViewProducts.FindControl("txtProductName")).ReadOnly = Flag;
        ((TextBox)frmViewProducts.FindControl("txtComposition")).ReadOnly = Flag;
        ((TextBox)frmViewProducts.FindControl("txtIndications")).ReadOnly = Flag;
        ((DropDownList)frmViewProducts.FindControl("ddlDosage")).Enabled = !Flag;
        ((DropDownList)frmViewProducts.FindControl("ddlPackSize")).Enabled = !Flag;
        ((TextBox)frmViewProducts.FindControl("txtPrice")).ReadOnly = Flag;
        ((DropDownList)frmViewProducts.FindControl("ddlProductsForms")).Enabled = !Flag;
    }

    private void AdjustDropDownListsSelection()
    {
        ((DropDownList)frmViewProducts.FindControl("ddlProductsForms")).SelectedValue = frmViewProducts.DataKey["FormID"].ToString();
        ((DropDownList)frmViewProducts.FindControl("ddlDosage")).SelectedValue = frmViewProducts.DataKey["Dosage"].ToString();
        ((DropDownList)frmViewProducts.FindControl("ddlPackSize")).SelectedValue = frmViewProducts.DataKey["PackSizes"].ToString();
    }

    #endregion

    #region Search Handler

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        string[] Names = new string[0];
        string ErrMsg = "";
        Products currentPage = new Products();
        Names = currentPage.GetAllEntitiesNamesByUser("Products", prefixText, out ErrMsg);
        return Names;
    }
    protected void txtSearchName_TextChanged(object sender, EventArgs e)
    {
        frmViewProducts.PageIndex = GetCertainPageByName(txtSearchName.Text, false);
        BindProductsView(false);
        AdjustDropDownListsSelection();
        AdjustTransButtons(false);
        txtSearchName.Text = "";
        lblmsg.Visible = false;
    }

    #endregion
    
}
