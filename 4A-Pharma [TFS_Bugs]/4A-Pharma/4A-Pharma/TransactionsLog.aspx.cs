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

public partial class TransactionsLog : TransactionLogBLL
{
    protected void Page_Load(object sender, EventArgs e)
    {
        InitiateTransactionsControl();
        if (!IsPostBack)
        {
            Session["OrderBy"] = "-1";
            Session["OrderByDirection"] = "DESC";
            BindgvTransactions();
        }
    }
   
    private void InitiateTransactionsControl()
    {
        TransButtons ucTransButtons = (TransButtons)Master.FindControl("ucTransButtons");
        ucTransButtons.CurrentPage = "Reports";
    }
    
    private void BindgvTransactions()
    {
        gvTransLog.DataSource = odsTransactions;
        gvTransLog.DataBind();

    }

    protected void gvTransLog_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (((RadioButtonList)(e.Row.Cells[4].FindControl("rbList"))).Visible != false)
            {
                if (CurrentUserInfo.UserRole == UsersRoles.User)
                {
                    ((RadioButtonList)(e.Row.Cells[4].FindControl("rbList"))).Items[1].Enabled = false;
                }
                // check if current record is BMD_Employees
                if (((HyperLink)e.Row.Cells[3].FindControl("lnkModule")).Text.StartsWith("BMD_Employees"))
                {
                    if (CurrentUserInfo.UserRole == UsersRoles.Admin)
                    {
                        ((RadioButtonList)(e.Row.Cells[4].FindControl("rbList"))).Items[1].Enabled = false;
                    }
                }
            }

            int TransStatus = int.Parse(gvTransLog.DataKeys[e.Row.RowIndex].Values["TransStatus"].ToString().Trim());
            if (TransStatus == 1) 
            {
                // Accepted Transaction Record // 
                HandleTransactionStatus(e.Row, 1);
            }
            else if (TransStatus == 2)
            {
                // For Rejected Transaction Record //
                HandleTransactionStatus(e.Row, 2);
            }
            else if (TransStatus == 3)
            {
                // Failed Transaction Record // 
                HandleTransactionStatus(e.Row, 3);
            }
            //
            HandleModulesLinks(e.Row);
        }
    }
    
    private void HandleModulesLinks(GridViewRow CurrentRow) 
    {
        int CurrentID;
        string TransModule ="";
        HyperLink lnkModule = (HyperLink)CurrentRow.FindControl("lnkModule");
        string URL="";
        string NormalizedModule = lnkModule.Text;
        if (NormalizedModule.StartsWith("BMD_Employees"))
            NormalizedModule = "BMD_Employees";

        switch (NormalizedModule)
        { 
            case "BMD_Products":
                lnkModule.Text = "Products";
                URL = "Products.aspx?";
                break;
            case "BMD_PrivateClinics":
                lnkModule.Text = "PrivateClinics";
                URL = "PrivateClinics.aspx?";
                break;
            case "BMD_MedicalAccounts":
                lnkModule.Text = "MedicalAccounts";
                URL = "MedicalAccounts.aspx?";
                break;
            case "BMD_ProductFeedback":
                lnkModule.Text = "MedicalAccounts";
                URL = "MedicalAccounts.aspx?";
                break;
            case "BMD_Distributors":
                lnkModule.Text = "Distributors";
                URL = "Distributors.aspx?";
                break;
            case "BMD_Distributor_Branches":
                lnkModule.Text = "DistributorsBranche";
                URL = "Distributors.aspx?";
                break;
            case "BMD_Pharmacies":
                lnkModule.Text = "Pharmacies";
                URL = "Pharmacies.aspx?";
                break;
            case "BMD_Physicians":
                lnkModule.Text = "Physicians";
                URL = "Physicians.aspx?";
                break;
            case "BMD_PhysicianScore":
                lnkModule.Text = "PhysicianScore";
                URL = "Physicians.aspx?";
                break;
            case "BMD_Bricks":
                lnkModule.Text = "System Brick";
                URL = "ManageApplication.aspx?sec=BMD_Bricks&";
                break;
            case "GNR_SubCode_BY_GeneralCode":
                lnkModule.Text = "System Entry";
                URL = "ManageApplication.aspx?sec=GNR_SubCode_BY_GeneralCode&";
                break;
            case "BMD_Employees":
                TransModule = lnkModule.Text;
                lnkModule.Text = "Employees";
                URL = "BMDUsers.aspx?";
                break;
        }
        string TransType = CurrentRow.Cells[2].Text;
        string OldRefID = gvTransLog.DataKeys[CurrentRow.RowIndex].Values["TransModuleRefID"].ToString().Trim();

        if (CurrentRow.Cells[2].Text != "Delete")
        {
            CurrentID = int.Parse(gvTransLog.DataKeys[CurrentRow.RowIndex].Values["TransModuleNewID"].ToString().Trim());
        }
        else
        {
            CurrentID = int.Parse(gvTransLog.DataKeys[CurrentRow.RowIndex].Values["TransModuleRefID"].ToString().Trim());
        }
       
        if (lnkModule.Text == "PhysicianScore")
        {
            CurrentID = PhysiciansBLL.GetPhysicianIDByScoreID(CurrentID);
        }

        string EncryptedQSID = mEncryptQueryString("&ID=" + CurrentID + "&TransType=" + TransType + "&oldRefID=" + OldRefID + "&TransModule=" + TransModule);
        lnkModule.NavigateUrl = URL + "data=" + EncryptedQSID;

    }
    
    private void HandleTransactionStatus(GridViewRow CurrentRow, int TransStatus)
    {
        ((RadioButtonList)CurrentRow.FindControl("rbList")).Visible = false;
        Label lblAccepted = (Label)CurrentRow.FindControl("lblAccepted");
        lblAccepted.Visible = true;
        
        if (TransStatus == 1)
        {
            lblAccepted.Text = "Accepted";
            lblAccepted.ForeColor = System.Drawing.Color.Green;
            CurrentRow.Enabled = false;
        }
        else if (TransStatus == 2)
        {
            lblAccepted.Text = "Rejected";
            lblAccepted.ForeColor = System.Drawing.Color.Red;
        }
        else if (TransStatus == 3)
        {
            lblAccepted.Text = "Failed";
            lblAccepted.ForeColor = System.Drawing.Color.Red;
        }
    }
  
    protected void btnCommitTrans_Click(object sender, EventArgs e)
    {
        bool NeedToReloadData = false;
        for (int i = 0; i < gvTransLog.Rows.Count; i++)
        {
            if (((RadioButtonList)(gvTransLog.Rows[i].Cells[4].FindControl("rbList"))).Visible != false)
            {
                int TransID = int.Parse(gvTransLog.DataKeys[i].Values["TransID"].ToString().Trim());
                int TransCommand;
                int.TryParse(((RadioButtonList)gvTransLog.Rows[i].Cells[4].FindControl("rbList")).SelectedValue, out TransCommand);
                if (TransCommand != 0)
                {
                    HyperLink lnkModule = (HyperLink)gvTransLog.Rows[i].FindControl("lnkModule");
                    string TransType = gvTransLog.Rows[i].Cells[2].Text;
                    //
                    // Handle Transactions for products //
                    switch (lnkModule.Text)
                    {
                         case "Products":
                            if (TransType == "Add")
                            {
                                ProductsBLL.ResponseAddProduct(TransID, TransCommand, CurrentUserInfo.EmpID);
                            }
                            else if (TransType == "Update")
                            {
                                ProductsBLL.ResponseUpdateProduct(TransID, TransCommand, CurrentUserInfo.EmpID);
                            }
                            else if (TransType == "Delete")
                            {
                                ProductsBLL.ResponseDelete(TransID, TransCommand, CurrentUserInfo.EmpID);
                            }
                            break;
                            
                        // Handle Transactions for Private Clinics //
                        case "PrivateClinics":
                            if (TransType == "Add")
                            {
                                PrivateClinicsBLL.ResponseAddPrivateClinic(TransID, TransCommand, CurrentUserInfo.EmpID);
                            }
                            else if (TransType == "Update")
                            {
                                PrivateClinicsBLL.ResponseUpdatePrivateClinic(TransID, TransCommand, CurrentUserInfo.EmpID);
                            }
                            else if (TransType == "Delete")
                            {
                                PrivateClinicsBLL.ResponseDelete(TransID, TransCommand, CurrentUserInfo.EmpID);
                            }
                            break;

                        // Handle Transactions for Physicians //
                        case "Physicians":
                            
                                if (TransType == "Add")
                                {
                                    PhysiciansBLL.ResponseAddPhysician(TransID, TransCommand, CurrentUserInfo.EmpID);
                                }
                                else if (TransType == "Update")
                                {
                                    PhysiciansBLL.ResponseUpdatePhysician(TransID, TransCommand, CurrentUserInfo.EmpID);
                                }
                                else if (TransType == "Delete")
                                {
                                    PhysiciansBLL.ResponseDelete(TransID, TransCommand, CurrentUserInfo.EmpID);
                                }
                                break;
                        
                        // Handle Transactions for Physician Score //
                        case "PhysicianScore": 
                           
                                if (TransType == "Add")
                                {
                                    int Result = PhysiciansBLL.ResponseAddPhysicianScores(TransID, TransCommand, CurrentUserInfo.EmpID);
                                    if (Result == 2 && TransCommand == 1)
                                    {
                                        lbltransLog.Text = "You can add only one scores record for each day.";
                                    }
                                }
                                else if (TransType == "Update")
                                {
                                    PhysiciansBLL.ResponseUpdatePhysicianScores(TransID, TransCommand, CurrentUserInfo.EmpID);
                                }
                                else if (TransType == "Delete")
                                {
                                    PhysiciansBLL.ResponseDelete(TransID, TransCommand, CurrentUserInfo.EmpID);
                                }
                                break;

                        // Handle Transactions for MedicalAccounts //
                        case "MedicalAccounts":
                            if (TransType == "Add")
                            {
                                MedicalAccountsBLL.ResponseAddMedicalAccount(TransID, TransCommand, CurrentUserInfo.EmpID);
                            }
                            else if (TransType == "Update")
                            {
                                MedicalAccountsBLL.ResponseUpdateMedicalAccount(TransID, TransCommand, CurrentUserInfo.EmpID);
                            }
                            else if (TransType == "Delete")
                            {
                                MedicalAccountsBLL.ResponseDelete(TransID, TransCommand, CurrentUserInfo.EmpID);
                            }
                            break;

                        // Handle Transactions for Pharmacies //
                        case "Pharmacies":
                            if (TransType == "Add")
                            {
                                PharmaciesBLL.ResponseAddPharmacy(TransID, TransCommand, CurrentUserInfo.EmpID);
                            }
                            else if (TransType == "Update")
                            {
                                PharmaciesBLL.ResponseUpdatePharmacy(TransID, TransCommand, CurrentUserInfo.EmpID);
                            }
                            else if (TransType == "Delete")
                            {
                                PharmaciesBLL.ResponseDelete(TransID, TransCommand, CurrentUserInfo.EmpID);
                            }
                            break;
                        
                        // Handle Transactions for Distributors //
                        case "Distributors":
                            if (TransType == "Add")
                            {
                                DistributorsBLL.ResponseAddDistributor(TransID, TransCommand, CurrentUserInfo.EmpID);
                            }
                            else if (TransType == "Update")
                            {
                                DistributorsBLL.ResponseUpdateDistributor(TransID, TransCommand, CurrentUserInfo.EmpID);
                            }
                            else if (TransType == "Delete")
                            {
                                DistributorsBLL.ResponseDelete(TransID, TransCommand, CurrentUserInfo.EmpID);
                            }
                            break;

                        // Handle Transactions for Distributors //
                        case "Employees":
                            if (TransType == "Add")
                            {
                                ManageUsersBLL.ResponseAddUser(TransID, TransCommand, CurrentUserInfo.EmpID);
                            }
                            else if (TransType == "Update")
                            {
                                ManageUsersBLL.ResponseUpdateUser(TransID, TransCommand, CurrentUserInfo.EmpID);
                            }
                            else if (TransType == "Delete")
                            {
                                ManageUsersBLL.ResponseDelete(TransID, TransCommand, CurrentUserInfo.EmpID);
                            }
                            break;

                    }
                    NeedToReloadData = true;
                }
            }
        }
        // Reload GridView data
        if(NeedToReloadData)
           BindgvTransactions();
    }
    
    protected void gvTransLog_Sorting(object sender, GridViewSortEventArgs e)
    {
        Session["OrderBy"] = e.SortExpression;
        Session["OrderByDirection"] = GetLocalSortDirection(e.SortExpression);
        BindgvTransactions();
    }
   
    private string GetLocalSortDirection(string column)
    {

        // By default, set the sort direction to ascending.
        string sortDirection = "ASC";

        // Retrieve the last column that was sorted.
        string sortExpression = ViewState["SortExpression"] as string;

        if (sortExpression != null)
        {
            // Check if the same column is being sorted.
            // Otherwise, the default value can be returned.
            if (sortExpression == column)
            {
                string lastDirection = ViewState["SortDirection"] as string;
                if ((lastDirection != null) && (lastDirection == "ASC"))
                {
                    sortDirection = "DESC";
                }
            }
        }

        // Save new values in ViewState.
        ViewState["SortDirection"] = sortDirection;
        ViewState["SortExpression"] = column;

        return sortDirection;
    }

    protected void gvTransLog_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTransLog.PageIndex = e.NewPageIndex;
        BindgvTransactions();
    }
}
