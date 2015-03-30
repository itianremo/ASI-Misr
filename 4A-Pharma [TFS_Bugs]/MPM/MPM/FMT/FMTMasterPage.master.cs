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

public partial class FMT_FMTMasterPage : System.Web.UI.MasterPage
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
            imgbtnHome.Attributes.Add("onmouseover", "this.src='" + ResolveClientUrl("~/Images/Planning-o.jpg") + "'");
            imgbtnReports.Attributes.Add("onmouseover", "this.src='" + ResolveClientUrl("~/Images/Reporting-o.jpg") + "'");
            /////////////////////////////////////////////////////////////////////////////////////
            imgbtnHome.Attributes.Add("onmouseout", "this.src='" + ResolveClientUrl("~/Images/Planning-n.jpg") + "'");
            imgbtnReports.Attributes.Add("onmouseout", "this.src='" + ResolveClientUrl("~/Images/Reporting-n.jpg") + "'");
            /////////////////////////////////////////////////////////////////////////////////////
            #endregion

            #region -------------- Page links Handler -------------

            Page objCurrentPage = this.Page;
            string CurrentPageName = objCurrentPage.GetType().ToString();
            switch (CurrentPageName)
            {
                case "ASP.fmt_fmtplanning_aspx":
                    imgbtnHome.Attributes.Clear();
                    imgbtnHome.Enabled = false;
                    imgbtnHome.ImageUrl = "~/Images/Planning-s.jpg";
                    break;

                case "ASP.fmt_fmtreport_aspx":
                    imgbtnReports.Attributes.Clear();
                    imgbtnReports.Enabled = false;
                    imgbtnReports.ImageUrl = "~/Images/Reporting-s.jpg";
                    break;

              

            }

            #endregion
        
        }
    }
}
