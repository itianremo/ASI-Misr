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
using System.Text.RegularExpressions;

public partial class ManageApplication : LookupsBLL
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CurrentUserInfo.IsAdminRank)
        {
            Response.Redirect("~/Login.aspx");
        }

        InitiateTransactionsControl();
        lblMessage.Text = "";
        if (gvGovs.SelectedIndex != -1)
        {
            gvCities.Visible = true;
            lblCity.Visible = true;
        }
        else
        {
            gvCities.Visible = false;
            lblCity.Visible = false;
        }

        if (!IsPostBack)
        {
            #region Display respective index in the accordion control
            if (String.IsNullOrEmpty(Request.QueryString.Get("sec")))
            {
                MyAccordion.SelectedIndex = -1;
            }
            else if (Request.QueryString.Get("sec") == "")
            {
            }
            else if (Request.QueryString.Get("sec") == "")
            {
            }
            else if (Request.QueryString.Get("sec") == "")
            {
            }
            else if (Request.QueryString.Get("sec") == "")
            {
            }
            else if (Request.QueryString.Get("sec") == "")
            {
            }
            else if (Request.QueryString.Get("sec") == "")
            {
            }
            #endregion
        }
    }
    private void InitiateTransactionsControl()
    {

        TransButtons ucTransButtons = (TransButtons)Master.FindControl("ucTransButtons");
        ucTransButtons.CurrentPage = "ManageApplication";
    }
 
    #region Product Froms Events
    protected void btnAddForm_Click(object sender, EventArgs e)
    {
        LookupsBLL lookUp=new LookupsBLL();
        string Form=((TextBox)gvForms.FooterRow.FindControl("txtForm")).Text;
        if (String.IsNullOrEmpty(Form))
        {
            lblMessage.Text = "Type product form to add";
            return;
        }
        int NewSCodeID = 0;
        string Msg = "";
        int Result = lookUp.AddSCodeToGCode("ProductsForms", Form, out NewSCodeID, ref Msg);
        if (Result == 1)
        {
            lblMessage.Text = "Product form added successfully";
            gvForms.DataBind();
        }
        else
        {
            if (Result == 2)
            {
                // Added Requested // Pending Request
                lblMessage.Text = "Your request for adding new product form is in Pending phase until Acceptance from your Manager";
            }
            else
            {
                // Error
                lblMessage.Text = (Msg.Length > 0) ? Msg : "Failed to add product form.";
            }
        }
    }
    protected void odsProductForms_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters["GeneralCode"] = "ProductsForms";
    }
    protected void odsProductForms_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        int result = Convert.ToInt32(e.ReturnValue);
        string Msg = e.OutputParameters["Msg"].ToString();

        if (result == 0)
            lblMessage.Text = (Msg.Length > 0) ? Msg : "Failed to update product form";
        else if (result == 1)
        {
            lblMessage.Text = "Product form updated successfully";
        }
        else
        {
            lblMessage.Text = "Your request for Updating product form is in Pending phase until Acceptance from your Manager";
        }
    }
    protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        gvForms.DataBind();
    }
    protected void odsProductForms_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters[0] = "ProductsForms";
    }
    #endregion

    #region Product Dosages Events
    protected void btnAddDosage_Click(object sender, EventArgs e)
    {
        LookupsBLL lookUp = new LookupsBLL();
        string Dosage = ((TextBox)gvDosages.FooterRow.FindControl("txtDosage")).Text;
        if (String.IsNullOrEmpty(Dosage))
        {
            lblMessage.Text = "Type product dosage to add";
            return;
        }
        int NewSCodeID = 0;
        string Msg = "";
        int Result = lookUp.AddSCodeToGCode("ProductsDosages", Dosage, out NewSCodeID, ref Msg);
        if (Result == 1)
        {
            lblMessage.Text = "Product dosage added successfully";
            gvDosages.DataBind();
        }
        else
        {
            if (Result == 2)
            {
                // Added Requested // Pending Request
                lblMessage.Text = "Your request for adding new product dosage is in Pending phase until Acceptance from your Manager";
            }
            else
            {
                // Error
                lblMessage.Text = (Msg.Length > 0) ? Msg : "Failed to add product dosage.";
            }
        }
    }
    protected void odsProductsDosages_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters["GeneralCode"] = "ProductsDosages";
    }
    protected void odsProductsDosages_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        int result = Convert.ToInt32(e.ReturnValue);
        string Msg = e.OutputParameters["Msg"].ToString();

        if (result == 0)
            lblMessage.Text = (Msg.Length > 0) ? Msg : "Failed to update product dosage";
        else if (result == 1)
        {
            lblMessage.Text = "Product dosage updated successfully";
        }
        else
        {
            lblMessage.Text = "Your request for Updating product dosage is in Pending phase until Acceptance from your Manager";
        }
    }
    protected void DetailsViewProductsDosages_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        gvDosages.DataBind();
    }
    protected void odsProductsDosages_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters[0] = "ProductsDosages";
    }
    #endregion

    #region Product PackSizes Events
    protected void btnAddPackSize_Click(object sender, EventArgs e)
    {
        
        LookupsBLL lookUp = new LookupsBLL();
        string PackSize = ((TextBox)gvPackSizes.FooterRow.FindControl("txtPackSize")).Text;
        if (String.IsNullOrEmpty(PackSize))
        {
            lblMessage.Text = "Type product packsize to add";
            return;
        }
        
        int NewSCodeID = 0;
        string Msg = "";
        int Result = lookUp.AddSCodeToGCode("ProductsPackSizes", PackSize, out NewSCodeID, ref Msg);
        if (Result == 1)
        {
            lblMessage.Text = "Product packsize added successfully";
            gvPackSizes.DataBind();
        }
        else
        {
            if (Result == 2)
            {
                // Added Requested // Pending Request
                lblMessage.Text = "Your request for adding new product packsize is in Pending phase until Acceptance from your Manager";
            }
            else
            {
                // Error
                lblMessage.Text = (Msg.Length > 0) ? Msg : "Failed to add product packsize.";
            }
        }
    }
    protected void odsProductsPackSizes_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters["GeneralCode"] = "ProductsPackSizes";
    }
    protected void odsProductsPackSizes_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        int result = Convert.ToInt32(e.ReturnValue);
        string Msg = e.OutputParameters["Msg"].ToString();

        if (result == 0)
            lblMessage.Text = (Msg.Length > 0) ? Msg : "Failed to update product packsize";
        else if (result == 1)
        {
            lblMessage.Text = "Product packsize updated successfully";
        }
        else
        {
            lblMessage.Text = "Your request for Updating product packsize is in Pending phase until Acceptance from your Manager";
        }
    }
    protected void DetailsViewProductsPackSizes_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        gvPackSizes.DataBind();
    }
    protected void odsProductsPackSizes_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters[0] = "ProductsPackSizes";
    }
    #endregion

    #region Physician Titles Events
    protected void btnAddPhysicianTitle_Click(object sender, EventArgs e)
    {
        LookupsBLL lookUp = new LookupsBLL();
        string PhysicianTitle = ((TextBox)gvPhysiciansTitles.FooterRow.FindControl("txtPhysicianTitle")).Text;
        if (String.IsNullOrEmpty(PhysicianTitle))
        {
            lblMessage.Text = "Type physician title to add";
            return;
        }
        int NewSCodeID = 0;
        string Msg = "";
        int Result = lookUp.AddSCodeToGCode("PhysicianTitles", PhysicianTitle, out NewSCodeID, ref Msg);
        if (Result == 1)
        {
            lblMessage.Text = "Physician title added successfully";
            gvPhysiciansTitles.DataBind();
        }
        else
        {
            if (Result == 2)
            {
                // Added Requested // Pending Request
                lblMessage.Text = "Your request for adding new physician title is in Pending phase until Acceptance from your Manager";
            }
            else
            {
                // Error
                lblMessage.Text = (Msg.Length > 0) ? Msg : "Failed to add physician title.";
            }
        }
    }
    protected void odsPhysicianTitles_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters["GeneralCode"] = "PhysicianTitles";
    }
    protected void odsPhysicianTitles_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        int result = Convert.ToInt32(e.ReturnValue);
        string Msg = e.OutputParameters["Msg"].ToString();

        if (result == 0)
            lblMessage.Text = (Msg.Length > 0) ? Msg : "Failed to update physician title";
        else if (result == 1)
        {
            lblMessage.Text = "Physician title updated successfully";
        }
        else
        {
            lblMessage.Text = "Your request for Updating physician title is in Pending phase until Acceptance from your Manager";
        }
    }
    protected void odsPhysicianTitles_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        gvPhysiciansTitles.DataBind();
    }
    protected void DetailsViewPhysiciansTitles_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        gvPhysiciansTitles.DataBind();
    }
    #endregion

    #region Physician Speciality Events
    protected void btnAddPhysicianSpeciality_Click(object sender, EventArgs e)
    {
        LookupsBLL lookUp = new LookupsBLL();
        string txtPhysicianSpeciality = ((TextBox)gvPhysicianSpecialities.FooterRow.FindControl("txtPhysicianSpeciality")).Text;
        if (String.IsNullOrEmpty(txtPhysicianSpeciality))
        {
            lblMessage.Text = "Type physician speciality to add";
            return;
        }
        int NewSCodeID = 0;
        string Msg = "";
        int Result = lookUp.AddSCodeToGCode("PhysicianSpecialities", txtPhysicianSpeciality, out NewSCodeID, ref Msg);
        if (Result == 1)
        {
            lblMessage.Text = "Physician speciality added successfully";
            gvPhysicianSpecialities.DataBind();
        }
        else
        {
            if (Result == 2)
            {
                // Added Requested // Pending Request
                lblMessage.Text = "Your request for adding new physician speciality is in Pending phase until Acceptance from your Manager";
            }
            else
            {
                // Error
                lblMessage.Text = (Msg.Length > 0) ? Msg : "Failed to add physician speciality.";
            }
        }
    }
    protected void odsPhysicianSpecialities_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters[0] = "PhysicianSpecialities";
    }
    protected void odsPhysicianSpecialities_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters["GeneralCode"] = "PhysicianSpecialities";
    }
    protected void odsPhysicianSpecialities_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        int result = Convert.ToInt32(e.ReturnValue);
        string Msg = e.OutputParameters["Msg"].ToString();

        if (result == 0)
            lblMessage.Text = (Msg.Length > 0) ? Msg : "Failed to update physician speciality";
        else if (result == 1)
        {
            lblMessage.Text = "Physician speciality updated successfully";
        }
        else
        {
            lblMessage.Text = "Your request for Updating physician speciality is in Pending phase until Acceptance from your Manager";
        }
    }
    protected void DetailsViewPhysicianSpecialities_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        gvPhysicianSpecialities.DataBind();
    }
    #endregion

    #region Subordination Events
    protected void btnAddSubordination_Click(object sender, EventArgs e)
    {
        LookupsBLL lookUp = new LookupsBLL();
        string txtSubordination = ((TextBox)gvSubordination.FooterRow.FindControl("txtSubordination")).Text;
        if (String.IsNullOrEmpty(txtSubordination))
        {
            lblMessage.Text = "Type subordination to add";
            return;
        }
        int NewSCodeID = 0;
        string Msg = "";
        int Result = lookUp.AddSCodeToGCode("Subordination", txtSubordination, out NewSCodeID, ref Msg);
        if (Result == 1)
        {
            lblMessage.Text = "Subordination added successfully";
            gvSubordination.DataBind();
        }
        else
        {
            if (Result == 2)
            {
                // Added Requested // Pending Request
                lblMessage.Text = "Your request for adding new subordination is in Pending phase until Acceptance from your Manager";
            }
            else
            {
                // Error
                lblMessage.Text = (Msg.Length > 0) ? Msg : "Failed to add subordination.";
            }
        }
    }
    protected void odsSubordination_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters[0] = "Subordination";
    }
    protected void odsSubordination_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters["GeneralCode"] = "Subordination";
    }
    protected void odsSubordination_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        int result = Convert.ToInt32(e.ReturnValue);
        string Msg = e.OutputParameters["Msg"].ToString();

        if (result == 0)
            lblMessage.Text = (Msg.Length > 0) ? Msg : "Failed to update subordination";
        else if (result == 1)
        {
            lblMessage.Text = "Subordination updated successfully";
        }
        else
        {
            lblMessage.Text = "Your request for Updating subordination is in Pending phase until Acceptance from your Manager";
        }
    }
    protected void DetailsViewSubordination_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        gvSubordination.DataBind();
    }
    #endregion

    #region Employees Events
    protected void btnAddEmployeesTitles_Click(object sender, EventArgs e)
    {
        LookupsBLL lookUp = new LookupsBLL();
        string txtEmployeesTitles = ((TextBox)gvEmployeesTitles.FooterRow.FindControl("txtEmployeesTitles")).Text;
        if (String.IsNullOrEmpty(txtEmployeesTitles))
        {
            lblMessage.Text = "Type title to add";
            return;
        }
        int NewSCodeID = 0;
        string Msg = "";
        int Result = lookUp.AddSCodeToGCode("EmployeeTitles", txtEmployeesTitles, out NewSCodeID, ref Msg);
        if (Result == 1)
        {
            lblMessage.Text = "Title added successfully";
            gvEmployeesTitles.DataBind();
        }
        else
        {
            if (Result == 2)
            {
                // Added Requested // Pending Request
                lblMessage.Text = "Your request for adding new title is in Pending phase until Acceptance from your Manager";
            }
            else
            {
                // Error
                lblMessage.Text = (Msg.Length > 0) ? Msg : "Failed to add title.";
            }
        }
    }
    protected void odsEmployeesTitles_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters[0] = "EmployeeTitles";
    }
    protected void odsEmployeesTitles_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters["GeneralCode"] = "EmployeeTitles";
    }
    protected void odsEmployeesTitles_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        int result = Convert.ToInt32(e.ReturnValue);
        string Msg = e.OutputParameters["Msg"].ToString();

        if (result == 0)
            lblMessage.Text = (Msg.Length > 0) ? Msg : "Failed to update title";
        else if (result == 1)
        {
            lblMessage.Text = "Title updated successfully";
        }
        else
        {
            lblMessage.Text = "Your request for Updating title is in Pending phase until Acceptance from your Manager";
        }
    }
    protected void DetailsViewEmployeesTitles_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        gvEmployeesTitles.DataBind();
    }
    #endregion

    #region Govs. Events
    protected void btnAddGov_Click(object sender, EventArgs e)
    {
        LookupsBLL lookUp = new LookupsBLL();
        string txtGov = ((TextBox)gvGovs.FooterRow.FindControl("txtGov")).Text;
        if (String.IsNullOrEmpty(txtGov))
        {
            lblMessage.Text = "Type gov. to add";
            return;
        }
        int NewSCodeID = 0;
        string Msg = "";
        int Result = lookUp.AddSCodeToGCode("Gov", txtGov, out NewSCodeID, ref Msg);
        if (Result == 1)
        {
            int NewCityID = 0;
            lookUp.AddSCodeToGCode("City", txtGov + " City", out NewCityID, ref Msg);
            lookUp.AddGovRelCity(NewSCodeID, NewCityID);
            lblMessage.Text = "Gov. added successfully";
            gvGovs.DataBind();
        }
        else
        {
            if (Result == 2)
            {
                // Added Requested // Pending Request
                lblMessage.Text = "Your request for adding new gov is in Pending phase until Acceptance from your Manager";
            }
            else
            {
                // Error
                lblMessage.Text = (Msg.Length > 0) ? Msg : "Failed to add gov.";
            }
        }
    }
    protected void odsGovs_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters[0] = "Gov";
    }
    protected void odsGovs_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters["GeneralCode"] = "Gov";
    }
    protected void odsGovs_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        gvCities.Visible = false;
        int result = Convert.ToInt32(e.ReturnValue);
        string Msg = e.OutputParameters["Msg"].ToString();

        if (result == 0)
            lblMessage.Text = (Msg.Length > 0) ? Msg : "Failed to update gov.";
        else if (result == 1)
        {
            lblMessage.Text = "Gov. updated successfully";
        }
        else
        {
            lblMessage.Text = "Your request for Updating gov. is in Pending phase until Acceptance from your Manager";
        }
    }
    protected void odsGovs_Deleting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        //e.InputParameters.RemoveAt(0);
    }
    protected void odsGovs_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        int result = Convert.ToInt32(e.ReturnValue);
        if (result == 0)
            lblMessage.Text = "Failed to delete gov";
        else if (result == 1)
        {
            lblMessage.Text = "Gov deleted successfully";
        }
        else if (result == -3)
        {
            lblMessage.Text = "Can't delete gov that has city(s) with any relation with other entity(s).";
        }
    }
    protected void DetailsViewGovs_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        gvGovs.DataBind();
    }
    protected void gvGovs_SelectedIndexChanged(object sender, EventArgs e)
    {
        AdjustCitiesPanelVisibility(true);
    }
    protected void gvGovs_RowDeleted(object sender, EventArgs e)
    {
        AdjustCitiesPanelVisibility(false);
    }
    protected void gvGovs_RowEditing(object sender, EventArgs e)
    {
        AdjustCitiesPanelVisibility(false);
    }

    protected void AdjustCitiesPanelVisibility(bool IsVisible)
    {
        gvCities.Visible = IsVisible;
        lblCity.Visible = IsVisible;
        gvGovs.SelectedIndex = ((IsVisible) ? gvGovs.SelectedIndex : -1);
    }
    #endregion

    #region Cities Events
    protected void btnAddCity_Click(object sender, EventArgs e)
    {
        LookupsBLL lookUp = new LookupsBLL();
        string txtCity = ((TextBox)gvCities.FooterRow.FindControl("txtCity")).Text;
        if (String.IsNullOrEmpty(txtCity))
        {
            lblMessage.Text = "Type city to add";
            return;
        }
        int NewSCodeID = 0;
        string Msg = "";
        int Result = lookUp.AddSCodeToGCode("City", txtCity, out NewSCodeID, ref Msg);
        if (Result == 1)
        {
            int GovID = int.Parse(gvGovs.DataKeys[gvGovs.SelectedIndex].Values[0].ToString());
            //int addedCity = lookUp.GetSIDByGCodeAndSCode("City", txtCity);
            lookUp.AddGovRelCity(GovID, NewSCodeID);
            lblMessage.Text = "City added successfully";
            gvCities.DataBind();
        }
        else
        {
            if (Result == 2)
            {
                // Added Requested // Pending Request
                int GovID = int.Parse(gvGovs.DataKeys[gvGovs.SelectedIndex].Values[0].ToString());
                lookUp.AddRequestGovRelCity(GovID, NewSCodeID);
                lblMessage.Text = "Your request for adding new city is in Pending phase until Acceptance from your Manager";
            }
            else
            {
                // Error
                lblMessage.Text = (Msg.Length > 0) ? Msg : "Failed to add city.";
            }
        }
    }
    protected void DetailsViewCities_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        string newCityName = ((TextBox)((DetailsView)sender).FindControl("txtInsertCity")).Text;
        ViewState["CityNameToInsert"] = newCityName;
    }
    protected void odsCities_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        string newCityName = ViewState["CityNameToInsert"].ToString();

        e.InputParameters.Clear();
        e.InputParameters.Add("GeneralCode", "City");
        e.InputParameters.Add("SubCode", newCityName);
    }
    protected void odsCities_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        string newCityName = ViewState["CityNameToInsert"].ToString();
        int GovID = int.Parse(gvGovs.DataKeys[gvGovs.SelectedIndex].Values[0].ToString());
        LookupsBLL lookUp = new LookupsBLL();
        int addedCity = lookUp.GetSIDByGCodeAndSCode("City", newCityName);
        lookUp.AddGovRelCity(GovID, addedCity);
    }
    protected void odsCities_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        //int CityID = int.Parse(gvCities.DataKeys[gvCities.EditIndex].Values[0].ToString());
        //string newCityName = ((TextBox)gvCities.Rows[gvCities.EditIndex].Cells[0].Controls[1]).Text;
        //
        e.InputParameters["SID"] = e.InputParameters["CityID"];
        e.InputParameters["SubCode"] = e.InputParameters["City"];
        e.InputParameters.Remove("CityID");
        e.InputParameters.Remove("City");
        e.InputParameters["GeneralCode"] = "City";
    }
    protected void odsCities_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        int result = Convert.ToInt32(e.ReturnValue);
        string Msg = e.OutputParameters["Msg"].ToString();

        if (result == 0)
            lblMessage.Text = (Msg.Length > 0) ? Msg : "Failed to update city";
        else if (result == 1)
        {
            lblMessage.Text = "City updated successfully";
        }
        else
        {
            lblMessage.Text = "Your request for Updating city is in Pending phase until Acceptance from your Manager";
        }
    }

    protected void odsCities_Deleting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        object CityIDToBeDeleted = e.InputParameters["CityID"];
        e.InputParameters["SID"] = CityIDToBeDeleted;
        e.InputParameters.RemoveAt(1);
        ViewState["CityIDToBeDeleted"] = CityIDToBeDeleted;
    }
    protected void odsCities_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        int CityID = Convert.ToInt32(ViewState["CityIDToBeDeleted"]);
        int GovID = int.Parse(gvGovs.DataKeys[gvGovs.SelectedIndex].Values[0].ToString());

        int result = Convert.ToInt32(e.ReturnValue);
        if (result == 0)
            lblMessage.Text = "Failed to delete city";
        else if (result == 1)
        {
            DeleteCityFromGov(GovID, CityID);
            lblMessage.Text = "City deleted successfully";
        }
        else if (result == -2)
        {
            lblMessage.Text = "Can't delete unique city in this governate.";
        }
        else if (result == -3)
        {
            lblMessage.Text = "Can't delete city that has any relation with other entity(s).";
        }
        else
        {
            DeleteRequestGovRelCity(GovID, CityID);
            lblMessage.Text = "Your request for Updating city is in Pending phase until Acceptance from your Manager";
        }
    }

    #endregion

    #region Bricks Events
    protected void btnAddBrick_Click(object sender, EventArgs e)
    {
      

        LookupsBLL lookUp = new LookupsBLL();
        string txtBrick = ((TextBox)gvBricks.FooterRow.FindControl("txtBrick")).Text;
        if (String.IsNullOrEmpty(txtBrick))
        {
            lblMessage.Text = "Type brick to add";
            return;
        }
        int NewSCodeID = 0;
        int Result = lookUp.InsertBrick(txtBrick, out NewSCodeID);
        #region [Hamdy - add switch instead of if , and add case for -1]
        switch (Result)
        {
            case -1:
                // Error
                lblMessage.Text = "The Brick is already exist.";
                break;
            case 1:
                lblMessage.Text = "Brick added successfully";
                gvBricks.DataBind();
                break;
            case 2:
                // Added Requested // Pending Request
                lblMessage.Text = "Your request for adding new brick is in Pending phase until Acceptance from your Manager";
           
                break;
            default:
                // Error
                lblMessage.Text = "Failed to add brick.";
                break;
        }
        //if (Result == 1)
        //{
        //    lblMessage.Text = "Brick added successfully";
        //    gvBricks.DataBind();
        //}
        //else
        //{
        //    if (Result == 2)
        //    {
        //        // Added Requested // Pending Request
        //        lblMessage.Text = "Your request for adding new brick is in Pending phase until Acceptance from your Manager";
        //    }
        //    else
        //    {
        //        // Error
        //        lblMessage.Text = "Failed to add brick.";
        //    }
        //}
        #endregion
    }
    protected void odsBricks_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {

    }
    protected void odsBricks_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        int result = Convert.ToInt32(e.ReturnValue);
        string Msg = e.OutputParameters["Msg"].ToString();

        if (result == 0)
            lblMessage.Text = (Msg.Length > 0) ? Msg : "Failed to update brick";
        else if (result == 1)
        {
            lblMessage.Text = "Brick updated successfully";
        }
        else
        {
            lblMessage.Text = "Your request for Updating brick is in Pending phase until Acceptance from your Manager";
        }
    }
    protected void DetailsViewBricks_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        gvBricks.DataBind();
    }
    #endregion        
}
