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

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Pharma.BMD.BLL.MasterClass MCPage = new Pharma.BMD.BLL.MasterClass();
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblLoggedUser.Text = "Logged User: " + MCPage.CurrentUserInfo.FullUserName;
           
            #region -------------------Graphics Handler--------------------
            /////////////////////////////////////////////////////////////////////////////////////
            imgbtnHome.Attributes.Add("onmouseover", "this.src='" + ResolveClientUrl("~/Images/Home-o.jpg") + "'");
            imgbtnProducts.Attributes.Add("onmouseover", "this.src='" + ResolveClientUrl("~/Images/Products-o.jpg") + "'");
            imgbtnPhysicians.Attributes.Add("onmouseover", "this.src='" + ResolveClientUrl("~/Images/Physicians-o.jpg") + "'");
            imgbtnMedicalAccounts.Attributes.Add("onmouseover", "this.src='" + ResolveClientUrl("~/Images/MedicalAccounts-o.jpg") + "'");
            imgbtnPrivateClinics.Attributes.Add("onmouseover", "this.src='" + ResolveClientUrl("~/Images/PrivateClinics-o.jpg") + "'");
            imgbtnPharmacies.Attributes.Add("onmouseover", "this.src='" + ResolveClientUrl("~/Images/Pharmacies-o.jpg") + "'");
            imgbtnDistributors.Attributes.Add("onmouseover", "this.src='" + ResolveClientUrl("~/Images/Distributors-o.jpg") + "'");
            imgbtnManageUsers.Attributes.Add("onmouseover", "this.src='" + ResolveClientUrl("~/Images/Users-o.jpg") + "'");
            imgbtnManageApplication.Attributes.Add("onmouseover", "this.src='" + ResolveClientUrl("~/Images/manage-applications-o.jpg") + "'");
            imgbtnReports.Attributes.Add("onmouseover", "this.src='" + ResolveClientUrl("~/Images/Queries-o.jpg") + "'");
            imgbtnTransactions.Attributes.Add("onmouseover", "this.src='" + ResolveClientUrl("~/Images/Transaction-o.jpg") + "'");
            /////////////////////////////////////////////////////////////////////////////////////
            imgbtnHome.Attributes.Add("onmouseout", "this.src='" + ResolveClientUrl("~/Images/Home-n.jpg") + "'");
            imgbtnProducts.Attributes.Add("onmouseout", "this.src='" + ResolveClientUrl("~/Images/Products-n.jpg") + "'");
            imgbtnPhysicians.Attributes.Add("onmouseout", "this.src='" + ResolveClientUrl("~/Images/Physicians-n.jpg") + "'");
            imgbtnMedicalAccounts.Attributes.Add("onmouseout", "this.src='" + ResolveClientUrl("~/Images/MedicalAccounts-n.jpg") + "'");
            imgbtnPrivateClinics.Attributes.Add("onmouseout", "this.src='" + ResolveClientUrl("~/Images/PrivateClinics-n.jpg") + "'");
            imgbtnPharmacies.Attributes.Add("onmouseout", "this.src='" + ResolveClientUrl("~/Images/Pharmacies-n.jpg") + "'");
            imgbtnDistributors.Attributes.Add("onmouseout", "this.src='" + ResolveClientUrl("~/Images/Distributors-n.jpg") + "'");
            imgbtnManageUsers.Attributes.Add("onmouseout", "this.src='" + ResolveClientUrl("~/Images/Users-n.jpg") + "'");
            imgbtnManageApplication.Attributes.Add("onmouseout", "this.src='" + ResolveClientUrl("~/Images/manage-applications-n.jpg") + "'");
            imgbtnReports.Attributes.Add("onmouseout", "this.src='" + ResolveClientUrl("~/Images/Queries-n.jpg") + "'");
            imgbtnTransactions.Attributes.Add("onmouseout", "this.src='" + ResolveClientUrl("~/Images/Transaction-n.jpg") + "'");
            /////////////////////////////////////////////////////////////////////////////////////
            #endregion

            #region -------------- Page links Handler -------------

            Page objCurrentPage = this.Page;
            string CurrentPageName = objCurrentPage.GetType().ToString();
            switch (CurrentPageName)
            {
                case "ASP.index_aspx":
                    imgbtnHome.Attributes.Clear();
                    imgbtnHome.Enabled = false;
                    imgbtnHome.ImageUrl = "~/Images/Home-s.jpg";
                    break;

                case "ASP.products_aspx":
                    imgbtnProducts.Attributes.Clear();
                    imgbtnProducts.Enabled = false;
                    imgbtnProducts.ImageUrl = "~/Images/Products-s.jpg";

                    break;
                case "ASP.physicians_aspx":
                    imgbtnPhysicians.Attributes.Clear();
                    imgbtnPhysicians.Enabled = false;
                    imgbtnPhysicians.ImageUrl = "~/Images/Physicians-s.jpg";

                    break;
                case "ASP.medicalaccounts_aspx":
                    imgbtnMedicalAccounts.Attributes.Clear();
                    imgbtnMedicalAccounts.Enabled = false;
                    imgbtnMedicalAccounts.ImageUrl = "~/Images/MedicalAccounts-s.jpg";

                    break;
                case "ASP.privateclinics_aspx":
                    imgbtnPrivateClinics.Attributes.Clear();
                    imgbtnPrivateClinics.Enabled = false;
                    imgbtnPrivateClinics.ImageUrl = "~/Images/PrivateClinics-s.jpg";

                    break;
                case "ASP.pharmacies_aspx":
                    imgbtnPharmacies.Attributes.Clear();
                    imgbtnPharmacies.Enabled = false;
                    imgbtnPharmacies.ImageUrl = "~/Images/Pharmacies-s.jpg";
                    break;

                case "ASP.distributors_aspx":
                    imgbtnDistributors.Attributes.Clear();
                    imgbtnDistributors.Enabled = false;
                    imgbtnDistributors.ImageUrl = "~/Images/Distributors-s.jpg";
                    break;

                case "ASP.bmdusers_aspx":

                    imgbtnManageUsers.Attributes.Clear();
                    imgbtnManageUsers.Enabled = false;
                    imgbtnManageUsers.ImageUrl = "~/Images/Users-s.jpg";
                    break;

                case "ASP.manageapplication_aspx":
                    imgbtnManageApplication.Attributes.Clear();
                    imgbtnManageApplication.Enabled = false;
                    imgbtnManageApplication.ImageUrl = "~/Images/manage-applications-s.jpg";
                    break;


                case "ASP.reports_aspx":
                    imgbtnReports.Attributes.Clear();
                    imgbtnReports.Enabled = false;
                    imgbtnReports.ImageUrl = "~/Images/Queries-s.jpg";
                    break;

                case "ASP.transactionslog_aspx":
                    imgbtnTransactions.Attributes.Clear();
                    imgbtnTransactions.Enabled = false;
                    imgbtnTransactions.ImageUrl = "~/Images/Transaction-s.jpg";
                    break;

            }

            if (!MCPage.CurrentUserInfo.IsAdminRank)
            {
                imgbtnManageUsers.Visible = false;
                spacerUsers.Visible = false;
                imgbtnManageApplication.Visible = false;
                spacerManageApp.Visible = false;
                imgbtnReports.Visible = false;
                spacerReports.Visible = false;
            }

            #endregion
        }
    }
}
