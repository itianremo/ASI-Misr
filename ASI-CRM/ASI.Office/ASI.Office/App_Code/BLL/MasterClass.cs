using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Office.DAL;
using TSHAK.Components;
using System.Collections;


namespace Office.BLL
{
    public class MasterClass : System.Web.UI.Page 
    {
        public MasterClass()
        {
            this.Page.LoadComplete += new EventHandler(Master_Page_LoadComplete);

        }

        protected void Master_Page_LoadComplete(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            }
        }

        public void TagAccountsGridView(GridView GridViewName, bool TagFlag)
        {
            foreach (GridViewRow gvrow in GridViewName.Rows)
            {
                if (gvrow.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkboxTag = (CheckBox)gvrow.FindControl("chkboxTag");
                    chkboxTag.Checked = TagFlag;
                    if (TagFlag)
                        ((ArrayList)ViewState["CheckedTags"]).Add(chkboxTag.Text);
                    else
                        ((ArrayList)ViewState["UnCheckedTags"]).Add(chkboxTag.Text);
                }
            }
        }

        public void TagGridView(GridView GridViewName, bool TagFlag)
        {
            foreach (GridViewRow gvrow in GridViewName.Rows)
            {
                if (gvrow.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkboxTag = (CheckBox)gvrow.FindControl("CbEmail");
                    chkboxTag.Checked = TagFlag;
                }
            }
        }

        public void EmailGridView(GridView GridViewName, bool TagFlag)
        {
            foreach (GridViewRow gvrow in GridViewName.Rows)
            {
                if (gvrow.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkboxTag = (CheckBox)gvrow.FindControl("CbEmail");
                    chkboxTag.Checked = TagFlag;
                }
            }
        }
        
        public string GetVersionInfo() 
        {
            return ConfigurationManager.AppSettings["CRMVersionInfo"].ToString();
        }

        public void FormatGridValues(GridView gvConvertedGrid, string ConvertFrom, string ConvertTo)
        {
            try
            {
                for (int i = 0; i < gvConvertedGrid.Rows.Count; i++)
                {
                    for (int j = 0; j < gvConvertedGrid.Columns.Count; j++)
                    {
                        if (gvConvertedGrid.Rows[i].Cells[j].Text == ConvertFrom)
                            gvConvertedGrid.Rows[i].Cells[j].Text = ConvertTo;
                    }
                }
            }
            catch (Exception e)
            {
            }
            
        }

        public void SignOut() 
        {
            //Page.RegisterStartupScript("d", "window.open('javascript:window.close()', 'runreport', '');");
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScript", "window.open('javascript:window.close()', 'runreport', '');", true);
			  FormsAuthentication.SignOut();
			  HttpContext.Current.Session.Clear();
			  FormsAuthentication.RedirectToLoginPage();
            //HttpContext.Current.Response.Redirect("login.aspx");
        }

        public void CheckUserSession() 
        { 
			  //if (!User.Identity.IsAuthenticated)
			  //{
			  //   FormsAuthentication.RedirectToLoginPage();
			  //}

			  //CustomPrincipal princeple = (CustomPrincipal)HttpContext.Current.User;
			 
			  
			  //if (HttpContext.Current.Session["UserData"] == null)
			  //{
			  //   Response.Redirect("Login.aspx");
			  //}
			 
			  //princeple.IsAdministrator
			  
			 
			  //if (HttpContext.Current.Session["UserData"] == null)
			  //{
			  //   HttpContext.Current.Session["UserData"] = princeple.UserLogin;
			  //}

        
        }

        public string mEncryptQueryString(string strData)
        {
            SecureQueryString qs = new SecureQueryString();
            qs["YourName"] = strData;
            //qs.ExpireTime = DateTime.Now.AddMinutes(10);
            return qs.ToString();

        }

        public bool SafeMerge(System.Data.DataSet MainDataSet, System.Data.DataSet SeconderyDataSet)
        {
            if (SeconderyDataSet != null)
            {
                MainDataSet.Clear();
                MainDataSet.Merge(SeconderyDataSet);
                MainDataSet.AcceptChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}