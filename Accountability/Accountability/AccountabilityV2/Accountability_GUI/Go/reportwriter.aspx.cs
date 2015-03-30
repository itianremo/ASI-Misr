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
using TSHAK.Components;

    public partial class test : System.Web.UI.Page
    {
        protected TSN.ERP.SharedComponents.Data.dsContacts dsContacts;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindReports();
            }
        }

        private void BindReports()
        {
            ApplyHeaderGroup();

            if (((TSN.ERP.WebGUI.Navigation.BaseObject)Session["navigation"]).SecInfo.IsAdministrator)
            {
                LinkButton1.Visible = true;
                LinkButton1.NavigateUrl = "";
                LinkButton1_Click(null, null);
            }
            else
            {
                try
                {
                    TSN.ERP.WebGUI.ReportWriterWS.Reports rwWS = new TSN.ERP.WebGUI.ReportWriterWS.Reports();
                    if (rwWS.mAccessRightsAddModifyReport("2", ((TSN.ERP.WebGUI.Navigation.BaseObject)Session["navigation"]).SessionWSObject.GetLoggedUserID().ToString()))
                    {
                        LinkButton1.Visible = true;
                        LinkButton1.NavigateUrl = "";
                        LinkButton1_Click(null, null);
                    }
                    else
                        LinkButton1.Visible = false;
                }
                catch
                {
                    LinkButton1.Visible = false;
                }
            }


            // Intialize the reports dataview
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ReportID"));
            dt.Columns.Add(new DataColumn("ReportName"));
            dt.Columns.Add(new DataColumn("ReportType"));
            dt.Columns.Add(new DataColumn("REP_Module"));
            dt.Columns.Add(new DataColumn("REP_RepDescription"));
            //dt.Columns.Add(new DataColumn("REP_Creator"));
            dt.Columns.Add(new DataColumn("REP_RepRemarks"));

            dt.Columns.Add(new DataColumn("REP_RepDate"));

            DataSet dsReports = new DataSet();

            #region Fixed Reports

            // add Weekly Total Hours Report
            DataRow row = dt.NewRow();
            DataRow row1 = dt.NewRow();
            DataRow row2 = dt.NewRow();
            row[0] = 1;
            row[1] = "Weekly Accountability Report";
            row[2] = 1;
            row[3] = "Weekly";
            row[4] = "Weekly Accountability Report";
            row[5] = "System";
            row[6] = "11/1/2006";
            dt.Rows.Add(row);
            // add Weekly Total Hours Report
            row1[0] = 2;
            row1[1] = "Weekly Total Hours Report";
            row1[2] = 1;
            row1[3] = "Weekly";
            row1[4] = "Weekly Total Hours Report";
            row1[5] = "System";
            row1[6] = "11/1/2006";
            dt.Rows.Add(row1);
            // add Task Summary Report
            row2[0] = 3;
            row2[1] = "Task Summary Report";
            row2[2] = 1;
            row2[3] = "Weekly";
            row2[4] = "Task Summary Report";
            row2[5] = "System";
            row2[6] = "11/1/2006";
            dt.Rows.Add(row2);

            #endregion


            #region RW reports

            try
            {
                //dsContacts.Clear();
                dsContacts = new TSN.ERP.SharedComponents.Data.dsContacts();
                TSN.ERP.WebGUI.Navigation.BaseObject.SafeMerge(dsContacts, ((TSN.ERP.WebGUI.Navigation.BaseObject)Session["navigation"]).ContactWsObject.ListContactsData());
                TSN.ERP.WebGUI.ReportWriterWS.Reports rwWS = new TSN.ERP.WebGUI.ReportWriterWS.Reports();
                DataSet dsRW = rwWS.mAccessRightsReports("2", ((TSN.ERP.WebGUI.Navigation.BaseObject)Session["navigation"]).SessionWSObject.GetLoggedUserID().ToString(), Convert.ToInt32(((TSN.ERP.WebGUI.Navigation.BaseObject)Session["navigation"]).SecInfo.IsAdministrator).ToString());
                if (dsRW != null && dsRW.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow rowRW in dsRW.Tables[0].Rows)
                    {
                        DataRow row4 = dt.NewRow();
                        row4[0] = rowRW["REP_RepID"];
                        row4[1] = rowRW["REP_RepName"];
                        row4[2] = 2;
                        row4[3] = rowRW["REP_Module"];
                        row4[4] = rowRW["REP_RepDescription"];
                        // comment 15-2-2011 By Sayed
                        //DataRow[] drContact = dsContacts.Tables[0].Select("UserID ='" + rowRW["REP_Creator"].ToString().Trim()+"'");
                        //if (drContact.Length > 0)
                        //    row4[5] = drContact[0]["FirstName"].ToString() + " " + drContact[0]["LastName"].ToString();// get Employee name by REP_Creator:  Fullname
                        //else row4[5] = "";
                        // end comment
                        row4[5] = rowRW["REP_RepRemarks"];
                        row4[6] = Convert.ToDateTime(rowRW["REP_RepDate"].ToString()).ToShortDateString();
                        dt.Rows.Add(row4);
                    }
                }
            }
            catch (Exception ee)
            {
                LinkButton1.Visible = false;
            }
            // dbo.REP_Reports.REP_RepID, dbo.REP_Reports.REP_RepName, dbo.REP_Reports.REP_RepDescription, dbo.REP_Reports.REP_Project, 
            //dbo.REP_Reports.REP_Module,  dbo.REP_Reports.REP_RepSqlWhere, dbo.REP_Reports.REP_RepSqlSort, 
            //dbo.REP_Reports.REP_RepDate, dbo.REP_Reports.REP_RepIsActive, dbo.REP_Reports.REP_RepRemarks, dbo.REP_Reports.REP_RepType, 
            #endregion


            //Sort Reports
            TSN.ERP.WebGUI.MasterMethods master = new TSN.ERP.WebGUI.MasterMethods();
            DataView dvReports = dt.DefaultView;
            dvReports.Sort = "REP_Module,ReportName";
            DataTable dtReports = master.CreateTableFromView(dvReports);
            ///////////////
            // Bind the Dtagrid with all reports
            dsReports.Tables.Add(dtReports);
            dgReports.DataSource = dsReports;
            dgReports.DataBind();
        }
        #region on Report selected

        protected void dgReports_SelectedIndexChanged(object sender, System.EventArgs e)
        {/*
            Label lblRepID = (Label)dgReports.SelectedRow.FindControl("lblRepID");
            string repID = lblRepID.Text;//dgReports.SelectedRow.Cells[0].Text; //((DataGrid)sender).Items[((DataGrid)sender).SelectedIndex].Cells[0].Text;
            Label lblRepType = (Label)dgReports.SelectedRow.FindControl("lblRepType");
            string repType = lblRepType.Text;// dgReports.SelectedRow.Cells[2].Text; //((DataGrid)sender).Items[((DataGrid)sender).SelectedIndex].Cells[2].Text;

            

			if( repType =="1" )
			{
				string frameScript = "<script language='javascript'> window.open( '../go/frmRWViewer.aspx?rpid="+repID+"') </script>";
				Page.RegisterStartupScript("FrameScript", frameScript);
			}
			else
			{
				string token = ((TSN.ERP.WebGUI.Navigation.BaseObject) Session[ "navigation" ]).Token.Replace( @"\" , "*" );
				//cod added by Sayed Moawad 08/08/2007
				// apply Encryption to send query string as encrypted to  Report Writer
				string VsQueryString="2&IsAdmin=" + Convert.ToInt32( ((TSN.ERP.WebGUI.Navigation.BaseObject)Page.Session[ "navigation" ]).SecInfo.IsAdministrator ) +"&ContactID=" + ((TSN.ERP.WebGUI.Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.GetLoggedUserID().ToString() + "&repID=" + repID +"&TK=" + token ;
				
				//Response.Redirect("http://localhost:3191/ReportWriter/default.aspx?data=" + qs.ToString());
				// for test only
  
				string RWURL = ConfigurationSettings.AppSettings[ "reportWriterURL" ] + "?Data=" + mEncryptQueryString(VsQueryString+"&x=1&y=2&z=3");//IsAdmin=" + Convert.ToInt32( ((TSN.ERP.WebGUI.Navigation.BaseObject)Page.Session[ "navigation" ]).SecInfo.IsAdministrator ) +"&ContactID=" + ((TSN.ERP.WebGUI.Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.GetLoggedUserID().ToString() + "&VsApplicationID=2&repID=" + repID +"&TK=" + token ;
				string frameScript = "<script language='javascript'> window.open( '"+ RWURL + "') </script>";
				Page.RegisterStartupScript("FrameScript", frameScript);

			}
             BindReports();
            //dgReports.SelectedIndex=dgReports
           */
        }

        #endregion

        private string mEncryptQueryString(string VsOriginalData)
        {

            // Create the queryString object

            SecureQueryString qs = new SecureQueryString();

            // Add name/value pairs.

            qs["YourName"] = VsOriginalData;

            // If the user wishes an expiration, set the expire time

            qs.ExpireTime = DateTime.Now.AddHours(5);
            return qs.ToString();

            // Redirect to the Destination page.   We simply call the ToString() method of 

            // SecureQuerySting to pass the encrypted data.

            //Response.Redirect("http://localhost:3191/ReportWriter/default.aspx?data=" + qs.ToString());
        }

        protected void LinkButton1_Click(object sender, System.EventArgs e)
        {
            string token = ((TSN.ERP.WebGUI.Navigation.BaseObject)Session["navigation"]).Token.Replace(@"\", "*");
            //cod added by Sayed Moawad 18/11/2008
            // apply Encryption to send query string as encrypted to  Report Writer

            string VsQueryString = "2&IsAdmin=" + Convert.ToInt32(((TSN.ERP.WebGUI.Navigation.BaseObject)Page.Session["navigation"]).SecInfo.IsAdministrator) + "&ContactID=" + ((TSN.ERP.WebGUI.Navigation.BaseObject)Session["navigation"]).SessionWSObject.GetLoggedUserID().ToString() + "&TK=" + token;
            string RWURL = ConfigurationSettings.AppSettings["reportWriterURL"] + "?Data=" + mEncryptQueryString(VsQueryString);
            //string frameScript = "<script language='javascript'> window.open( '"+ RWURL + "') </script>";
            //Page.RegisterStartupScript("FrameScript", frameScript);
            LinkButton1.NavigateUrl = RWURL;
        }
        private void ApplyHeaderGroup()
        {
            GridViewHelper gvHelper = new GridViewHelper(this.dgReports);
            gvHelper.RegisterGroup("REP_Module", true, true);
            gvHelper.GroupHeader += new GroupEvent(gvHelper_GroupHeader);
        }

        void gvHelper_GroupHeader(string groupName, object[] values, GridViewRow row)
        {
            row.CssClass = "fgridheader";
        }

        protected void dgReports_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataKey Key = dgReports.DataKeys[e.Row.RowIndex];
                string repID = Key["ReportID"].ToString();
                string repType = Key["ReportType"].ToString();
                HyperLink objlnk = (HyperLink)(e.Row.FindControl("HlnkRun"));

                if (repType == "1")
                {
                    string strReportPageName = "../go/frmRWViewer.aspx?rpid=" + repID;
                    // string frameScript = "<script language='javascript'> window.open( '../go/frmRWViewer.aspx?rpid=" + repID + "') </script>";
                    // Page.RegisterStartupScript("FrameScript", frameScript);
                    objlnk.NavigateUrl = strReportPageName;
                }
                else
                {
                    string token = ((TSN.ERP.WebGUI.Navigation.BaseObject)Session["navigation"]).Token.Replace(@"\", "*");
                    //cod added by Sayed Moawad 08/08/2007
                    // apply Encryption to send query string as encrypted to  Report Writer

                    string VsQueryString = "2&IsAdmin=" + Convert.ToInt32(((TSN.ERP.WebGUI.Navigation.BaseObject)Page.Session["navigation"]).SecInfo.IsAdministrator) + "&ContactID=" + ((TSN.ERP.WebGUI.Navigation.BaseObject)Session["navigation"]).SessionWSObject.GetLoggedUserID().ToString() + "&repID=" + repID + "&TK=" + token;

                    string RWURL = ConfigurationSettings.AppSettings["reportWriterURL"] + "?Data=" + mEncryptQueryString(VsQueryString + "&x=1&y=2&z=3");//IsAdmin=" + Convert.ToInt32( ((TSN.ERP.WebGUI.Navigation.BaseObject)Page.Session[ "navigation" ]).SecInfo.IsAdministrator ) +"&ContactID=" + ((TSN.ERP.WebGUI.Navigation.BaseObject) Session[ "navigation" ]).SessionWSObject.GetLoggedUserID().ToString() + "&VsApplicationID=2&repID=" + repID +"&TK=" + token ;
                    // string frameScript = "<script language='javascript'> window.open( '" + RWURL + "') </script>";
                    // Page.RegisterStartupScript("FrameScript", frameScript);
                    objlnk.NavigateUrl = RWURL;


                }
            }
        }
    }
