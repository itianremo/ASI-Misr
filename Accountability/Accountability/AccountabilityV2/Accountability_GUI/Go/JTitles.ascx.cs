namespace TSN.ERP.WebGUI.Go
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Web;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;
    using TSN.ERP.SharedComponents.Data;
    using TSN.ERP.WebGUI.Data;
    using Navigation;

    /// <summary>
    ///		Summary description for JTitles.
    /// </summary>
    public partial class JTitles : System.Web.UI.UserControl
    {
        protected TSN.ERP.SharedComponents.Data.dsJobtitles dsJobtitles1;
        protected TSN.ERP.SharedComponents.Data.dsResponsblities dsResponsblities1, dsResponsblities2;
        protected System.Data.DataView dataView1;

        //string DefRespText;
        protected System.Web.UI.WebControls.Table Table4;
        protected TSN.ERP.SharedComponents.Data.dsEmployee dsEmployee1;

        protected void Page_Load(object sender, System.EventArgs e)
        {

            resetErrHandler();
            Label1.Text = "";
            if (!IsPostBack)
            {
                divPanel.Visible = false;
                LoadJobs();
                if (((Navigation.BaseObject)Page.Session["navigation"]).SecInfo.IsAdministrator)
                {
                    OpenCloseResp.Visible = true;
                    OpenCloseJobtitle.Visible = true;
                    btnCopyResponsibility.Visible = true;
                }
                else
                {
                    OpenCloseResp.Visible = false;
                    OpenCloseJobtitle.Visible = false;
                    btnCopyResponsibility.Visible = false;
                }
               
            }
        }

        #region Load Job Titles

        private void LoadJobs()
        {
            dsJobtitles1.Clear();
            Navigation.BaseObject.SafeMerge(dsJobtitles1, ((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobtitles());
            //			dsJobtitles1.Tables[0].DefaultView.Sort = "JobName";
            dgJobTitles.DataBind();

            // added by Sayed 4-8-2010
            ddlJobTitles.Items.Clear();
            ddlJobTitles.DataSource = dataView1;
            ddlJobTitles.DataTextField = "JobName";
            ddlJobTitles.DataValueField = "JobTitleID";
            ddlJobTitles.DataBind();
            //
            dgJobTitles.HorizontalAlign = HorizontalAlign.Left;
            if (dgJobTitles.Items.Count == 0)
            {
                return;
            }

            dgJobTitles.SelectedIndex = 0;
            LinkButton linkText = (LinkButton)dgJobTitles.Items[0].Cells[1].Controls[1];
            string DefRespText = linkText.Text;
            int JobID = Convert.ToInt32(dgJobTitles.Items[0].Cells[0].Text);
            LoadDefaultResp(JobID, DefRespText);
            //Mark the completed jobtitle as closed:
            foreach (DataGridItem gridItem in dgJobTitles.Items)
            {
                if (gridItem.Cells[4].Text == "False")
                {
                    gridItem.CssClass = "completetask";
                    ((LinkButton)gridItem.Cells[1].Controls[1]).Enabled = false;
                }
            }
            ///////////////////////////////////////////////
        }
        #endregion

        #region Load Responsibilites

        private void LoadDefaultResp(int jobID, string DefRespText)
        {
            dsResponsblities1.Clear();
            PassedJobID.Text = jobID.ToString();
            Navigation.BaseObject.SafeMerge(dsResponsblities1, ((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobResponsbilities(jobID));
            Joblbl.Text = DefRespText + " Responsibilities";
            ViewState["Response"] = dsResponsblities1;
            dgResponsiblity.DataBind();
            //Mark the completed responsibility as closed:
            MarkRespGridItems();
            ///////////////////////////////////////////////
            ///
            if (dgJobTitles.SelectedIndex == 0)
            {
                if (dgJobTitles.Items[0].Cells[4].Text == "False")
                {
                    NewRes.Visible = false;
                    btnCopyResponsibility.Visible = false;
                }
                else
                {
                    if (((Navigation.BaseObject)Page.Session["navigation"]).SecInfo.IsAdministrator)
                    {
                        NewRes.Visible = true;
                        btnCopyResponsibility.Visible = true;
                    }
                }
            }
            if (dgJobTitles.Items[dgJobTitles.SelectedIndex].Cells[4].Text == "False")
            {
                NewRes.Visible = false;
                btnCopyResponsibility.Visible = false;
            }
            else
            {
                if (((Navigation.BaseObject)Page.Session["navigation"]).SecInfo.IsAdministrator)
                {
                    NewRes.Visible = true;
                    btnCopyResponsibility.Visible = true;
                }
            }
        }

        protected void LoadResp(object sender, System.EventArgs e)
        {
            dsResponsblities1.Clear();
            DataGridItem itm = (DataGridItem)((LinkButton)sender).Parent.Parent;
            dgJobTitles.SelectedIndex = itm.ItemIndex;
            int JobID = Convert.ToInt32(itm.Cells[0].Text);
            PassedJobID.Text = JobID.ToString();
            string JobName = ((LinkButton)sender).Text;
            Joblbl.Text = JobName + " Responsibilities";
            dsResponsblities1.Merge(((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobResponsbilities(JobID));
            dgResponsiblity.DataBind();
            ViewState["Response"] = dsResponsblities1;
            dgResponsiblity.SelectedIndex = -1;
            HideControls();
            //Mark the completed responsibility as closed:
            MarkRespGridItems();
            ///////////////////////////////////////////////
            if (itm.Cells[4].Text == "False")
            {
                NewRes.Visible = false;
                btnCopyResponsibility.Visible = false;
            }
            else
            {
                if (((Navigation.BaseObject)Page.Session["navigation"]).SecInfo.IsAdministrator)
                {
                    NewRes.Visible = true;
                    btnCopyResponsibility.Visible = true;
                }
                else
                    btnCopyResponsibility.Visible = false;

            }
        }

        #endregion

        # region Controls Handler

        private void ShowControls(string HeaderMessage)
        {
            LblAddJob.Text = HeaderMessage;
            LblAddJob.Visible = true;
            NewJobTitle.Visible = true;
            NewJobTitledescrp.Visible = true;
            SaveJobTitle.Visible = true;
            Cancel.Visible = true;
            this.lblDescription.Visible = true;
            this.lblName.Visible = true;
        }

        private void HideControls()
        {
            NewJobTitle.Text = "";
            NewJobTitledescrp.Text = "";
            this.lblDescription.Visible = false;
            this.lblName.Visible = false;
            LblAddJob.Visible = false;
            NewJobTitle.Visible = false;
            NewJobTitledescrp.Visible = false;
            SaveJobTitle.Visible = false;
            Cancel.Visible = false;
            TextBoxPeriority.Text = "";
            TextBoxPeriority.Visible = false;
            LabelPeriority.Visible = false;
        }
        #endregion

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        ///		Required method for Designer support - do not modify
        ///		the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dsJobtitles1 = new TSN.ERP.SharedComponents.Data.dsJobtitles();
            this.dsResponsblities1 = new TSN.ERP.SharedComponents.Data.dsResponsblities();
            this.dataView1 = new System.Data.DataView();
            this.dsEmployee1 = new TSN.ERP.SharedComponents.Data.dsEmployee();
            ((System.ComponentModel.ISupportInitialize)(this.dsJobtitles1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsResponsblities1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmployee1)).BeginInit();
            this.dgJobTitles.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgJobTitles_PageIndexChanged);
            // 
            // dsJobtitles1
            // 
            this.dsJobtitles1.DataSetName = "dsJobtitles";
            this.dsJobtitles1.EnforceConstraints = false;
            this.dsJobtitles1.Locale = new System.Globalization.CultureInfo("ar-EG");
            // 
            // dsResponsblities1
            // 
            this.dsResponsblities1.DataSetName = "dsResponsblities";
            this.dsResponsblities1.EnforceConstraints = false;
            this.dsResponsblities1.Locale = new System.Globalization.CultureInfo("ar-EG");
            // 
            // dataView1
            // 
            this.dataView1.Sort = "JobName";
            this.dataView1.Table = this.dsJobtitles1.GEN_JobTitles;
            // 
            // dsEmployee1
            // 
            this.dsEmployee1.DataSetName = "dsEmployee";
            this.dsEmployee1.Locale = new System.Globalization.CultureInfo("ar-EG");
            ((System.ComponentModel.ISupportInitialize)(this.dsJobtitles1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsResponsblities1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmployee1)).EndInit();

        }
        #endregion

        #region Data Grid PageIndexChanged

        private void dgJobTitles_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            this.dgJobTitles.SelectedIndex = 0;
            this.dgJobTitles.CurrentPageIndex = e.NewPageIndex;
            LoadJobs();
        }
        #endregion

        #region Resposibility Click

        protected void NewRes_Click(object sender, System.EventArgs e)
        {
            TextBoxPeriority.Visible = true;
            LabelPeriority.Visible = true;
            Label1.Visible = false;
            NewJobTitle.Text = "";
            NewJobTitledescrp.Text = "";
            TextBoxPeriority.Text = "";
            ShowControls("Add New Responsibility");
        }


        protected void onRespClick(object sender, System.EventArgs e)
        {
            DataGridItem itm = (DataGridItem)((LinkButton)sender).Parent.Parent;
            dgResponsiblity.SelectedIndex = itm.ItemIndex;
        }

        #endregion


        #region Cancel Button

        protected void Cancel_Click(object sender, System.EventArgs e)
        {
            HideControls();
        }
        #endregion

        #region Delete Job Title

        protected void DeleteJob_Click(object sender, System.EventArgs e)
        {
            resetErrHandler();
            Label1.Visible = false;
            int rowCount = dgJobTitles.Items.Count;
            Navigation.BaseObject.SafeMerge(dsJobtitles1, ((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobtitles());
            int rowCountdown = dsJobtitles1.GEN_JobTitles.Count;
            //>>>>>
            int JobsSelected = 0;

            for (int i = rowCount - 1; i >= 0; i--)
            {
                CheckBox ch = (CheckBox)dgJobTitles.Items[i].Cells[2].Controls[1];
                if (ch.Checked)
                {
                    JobsSelected++;
                    //					string id = dgJobTitles.Items[i].Cells[ 0 ].Text ;
                    //					int rowId = dataView1.Find(id)
                    //>>
                    //					int rowIDToDelete = dsJobtitles1.GEN_JobTitles.FindByJobTitleID(int.Parse(dgJobTitles.Items[ i ].Cells[ 0 ].Text))["JobTitleID"];
                    //					if (rowIDToDelete == -1) // >> Bug fixing  
                    //					{
                    //						DeleteHandler();
                    //						return;
                    //					} 
                    //>>
                    if (dsJobtitles1.GEN_JobTitles.FindByJobTitleID(int.Parse(dgJobTitles.Items[i].Cells[0].Text))["JobTitleID"] == null) // >> Bug fixing  
                    {
                        DeleteHandler();
                        return;
                    }
                    dsJobtitles1.GEN_JobTitles.FindByJobTitleID(int.Parse(dgJobTitles.Items[i].Cells[0].Text)).Delete();



                    //					dataView1[rowId].Delete();
                    rowCountdown = rowCountdown - 1;
                }

            }
            //<<<<<
            if (JobsSelected == 0)
            {
                Label1.Text = "Please select a job title to delete";
                Label1.Visible = true;
                return;
            }

            if (((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.DeleteJobtitle(dsJobtitles1) <= 0)
            {
                //dsJobtitles1.RejectChanges();
                DeleteHandler();
                //				LoadJobs();
                return;
            }

            ReloadAfterdelete(rowCountdown);
            HideControls();
        }

        private void ReloadAfterdelete(int TotalRec)
        {
            int pagsize = dgJobTitles.PageSize;
            if (Math.IEEERemainder(TotalRec, pagsize) == 0)
            {
                if (dgJobTitles.CurrentPageIndex == 0 || dgJobTitles.CurrentPageIndex == 1)
                {
                    dgJobTitles.CurrentPageIndex = 0;

                }
                else
                {
                    dgJobTitles.CurrentPageIndex = dgJobTitles.CurrentPageIndex - 1;

                }
            }
            else
            {
                dgJobTitles.CurrentPageIndex = dgJobTitles.CurrentPageIndex;

            }
            LoadJobs();
        }

        private void DeleteHandler()
        {
            int rowCount = dgJobTitles.Items.Count;
            string msg = null;
            for (int i = rowCount - 1; i >= 0; i--)
            {
                CheckBox ch = (CheckBox)dgJobTitles.Items[i].Cells[2].Controls[1];
                LinkButton linkText = (LinkButton)dgJobTitles.Items[i].Cells[1].Controls[1];
                if (ch.Checked)
                {
                    msg = msg + linkText.Text + "</br>";
                }
            }
            if (msg != null)
            {
                //tblErr.Rows[0].Cells[1].Text = "<br><b>Some of The Following Job Title(s) wasn’t deleted because one of them assigned to another entity</b></br>" + "<br>" + msg;	   	
                tblErr.Rows[0].Cells[1].Text = "<br><b>You can not delete the selected job title </b></br><font size='3' color='red'>" + msg + "</font><br><b> because it has one or more responsibilities or assigned to some employee(s)</b></br>";
                tblErr.Visible = true;
            }
        }

        private void resetErrHandler()
        {
            tblErr.Visible = false;
        }


        #endregion

        #region Delete Responsibility

        protected void DeleteRespBtn_Click(object sender, System.EventArgs e)
        {
            Label1.Visible = false;
            dsResponsblities1.Clear();
            dsResponsblities1.Merge(((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobResponsbilities(Convert.ToInt32(PassedJobID.Text)));
            int CountBefore = dsResponsblities1.Tables[0].Rows.Count;
            int checkedcount = 0;
            int rowCount = dgResponsiblity.Items.Count;

            // set selected responsibilities as deleted
            for (int i = rowCount - 1; i >= 0; i--)
            {
                CheckBox ch = (CheckBox)dgResponsiblity.Items[i].Cells[3].Controls[1];
                if (ch.Checked)
                {
                    this.dsResponsblities1.Tables[0].Rows[i].Delete();
                    checkedcount++;
                }

            }
            if (checkedcount == 0)
            {
                Label1.Text = "Please select a responsibility to delete";
                Label1.Visible = true;
                return;
            }

            // delete responsibilities
            ((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.DeleteResponsbilities(dsResponsblities1);
            dsResponsblities1.Clear();

            // list Job Responsbilities after deletion
            dsResponsblities1.Merge(((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobResponsbilities(Convert.ToInt32(PassedJobID.Text)));
            dgResponsiblity.DataBind();
            MarkRespGridItems();
            HideControls();

            // check if there is any prorblem in the deletion operation 
            int CountAfter = dsResponsblities1.Tables[0].Rows.Count;
            if ((CountBefore > 0) && (CountAfter > 0) && (CountAfter == CountBefore) && (checkedcount > 0))
            {
                //if(CountAfter==CountBefore && checkedcount > 0)
                //{
                Label1.Visible = true;
                Label1.Text = "The selected responsibility cannot be deleted because there are tasks assigned to it.";
                //}
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "responsibility deleted successfully.";

            }

        }

        #endregion

        #region Edit Job Title

        protected void EditJob_Click(object sender, System.EventArgs e)
        {
            HideControls();
            Label1.Visible = false;
            int rowCount = dgJobTitles.Items.Count;
            int x = 0;
            for (int i = rowCount - 1; i >= 0; i--)
            {
                CheckBox ch = (CheckBox)dgJobTitles.Items[i].Cells[2].Controls[1];
                if (ch.Checked)
                {
                    x = x + 1;

                    if (x == 1)
                    {
                        int pagno = dgJobTitles.CurrentPageIndex;
                        int pagsize = dgJobTitles.PageSize;
                        ViewState["itemindex"] = i + (pagno * pagsize);
                        ViewState["JobTitleID"] = dgJobTitles.Items[i].Cells[0].Text;
                        LinkButton linkB = (LinkButton)dgJobTitles.Items[i].Cells[1].Controls[1];
                        NewJobTitle.Text = linkB.Text.Trim();
                        NewJobTitledescrp.Text = Server.HtmlDecode(dgJobTitles.Items[i].Cells[3].Text.Trim());
                        ShowControls("Edit Job Title");
                    }
                    else if (x > 1)
                    {
                        Response.Write("<script>alert('Please Select One Item Only To Edit')</script>");
                        HideControls();
                        NewJobTitle.Text = "";
                        return;
                    }

                    dgJobTitles.SelectedIndex = dgJobTitles.Items[i].ItemIndex;
                    LoadDefaultResp(int.Parse(dgJobTitles.SelectedItem.Cells[0].Text), ((LinkButton)dgJobTitles.SelectedItem.Cells[1].Controls[1]).Text);
                }
            }
            if (x == 0)
            {
                Label1.Text = "Please select a job title to edit";
                Label1.Visible = true;
                return;
            }
        }

        #endregion

        #region Edit Responsibility
        protected void EditRespBtn_Click(object sender, System.EventArgs e)
        {
            Label1.Visible = false;
            HideControls();

            int rowCount = dgResponsiblity.Items.Count;
            int x = 0;
            for (int i = rowCount - 1; i >= 0; i--)
            {
                CheckBox ch = (CheckBox)dgResponsiblity.Items[i].Cells[3].Controls[1];
                if (ch.Checked)
                {
                    x = x + 1;

                    if (x == 1)
                    {
                        dgResponsiblity.SelectedIndex = dgResponsiblity.Items[i].ItemIndex;

                        ViewState["itemindex"] = i;
                        LinkButton linkB = (LinkButton)dgResponsiblity.Items[i].Cells[2].Controls[1];
                        NewJobTitle.Text = linkB.Text.Trim();
                        dsResponsblities1 = (dsResponsblities)ViewState["Response"];
                        NewJobTitledescrp.Text = dsResponsblities1.GEN_Responsibilities[i].ResponsDesc.ToString().Trim();
                        TextBoxPeriority.Text = dsResponsblities1.GEN_Responsibilities[i].ResponsOrder.ToString();
                        ShowControls("Edit Job Responsiblity");
                        TextBoxPeriority.Visible = true;
                        LabelPeriority.Visible = true;
                    }
                    else
                    {
                        Response.Write("<script>alert('Please Select One Item Only To Edit')</script>");
                        HideControls();
                        NewJobTitle.Text = "";
                        return;
                    }
                }
            }
            if (x == 0)
            {
                Label1.Text = "Please select a responsibility to edit";
                Label1.Visible = true;
                return;
            }
        }

        #endregion

        # region New Job Click
        protected void NewJob_Click(object sender, System.EventArgs e)
        {
            NewJobTitle.Text = "";
            NewJobTitledescrp.Text = "";
            ShowControls("Add New Job Title");
            Label1.Visible = false;
        }

        # endregion

        #region Save Job Title

        //TSN.ERP.SharedComponents.Data.dsJobtitles
        /// <summary>
        /// the following method checks wheather the job title name which passed to it 
        /// is added so far or not
        /// </summary>
        /// <param name="ds">dataset contains all the items in the database</param>
        /// <param name="NewJobTitleName">the item to be added</param>
        /// <returns>booliean value </returns>
        public bool CheckJobTitleByName(TSN.ERP.SharedComponents.Data.dsJobtitles ds, string NewJobTitleName)
        {
            bool flag = true;
            foreach (DataRow dr in ds.Tables["GEN_JobTitles"].Rows)
            {
                flag = true;
                if (dr["JobName"].ToString().Trim().ToLower() == NewJobTitleName.Trim().ToLower())
                {
                    flag = false;
                    break;
                }
                else
                {
                    flag = true;
                }
            }
            return flag;
        }
        /// <summary>
        /// the following method just check if there is any item with the same job title in the database or not 
        /// </summary>
        /// <param name="ds">dataset contains all the items in the database</param>
        /// <param name="NewJobTitleName">job title to be updated</param>
        /// <param name="JobTitleID">id of the current title to be updated</param>
        /// <returns>booliean value</returns>
        public bool CheckJobTitleByNameAndID(TSN.ERP.SharedComponents.Data.dsJobtitles ds, string NewJobTitleName, int JobTitleID)
        {
            bool flag = true;
            foreach (DataRow dr in ds.Tables["GEN_JobTitles"].Rows)
            {
                flag = true;
                if (dr["JobName"].ToString().Trim().ToLower() == NewJobTitleName.Trim().ToLower() && int.Parse(dr["JobTitleID"].ToString().Trim()) != JobTitleID)
                {
                    flag = false;
                    break;
                }
                else
                {
                    flag = true;
                }
            }
            return flag;
        }
        public bool CheckResponsibilityByName(TSN.ERP.SharedComponents.Data.dsResponsblities ds, string NewResponsName, int JobTitleID)
        {
            bool flag = true;
            foreach (DataRow dr in ds.Tables["GEN_Responsibilities"].Rows)
            {
                flag = true;
                if (dr["ResponsName"].ToString().Trim().ToLower() == NewResponsName.Trim().ToLower() && int.Parse(dr["JobTitleID"].ToString().Trim()) == JobTitleID)
                {
                    flag = false;
                    break;
                }
                else
                {
                    flag = true;
                }
            }
            return flag;
        }
        public bool CheckResponsibilityByNameAndID(TSN.ERP.SharedComponents.Data.dsResponsblities ds, string NewResponsName, int JobTitleID, int ResponsID)
        {
            bool flag = true;
            foreach (DataRow dr in ds.Tables["GEN_Responsibilities"].Rows)
            {
                flag = true;
                if (dr["ResponsName"].ToString().Trim().ToLower() == NewResponsName.Trim().ToLower() && int.Parse(dr["JobTitleID"].ToString().Trim()) == JobTitleID && int.Parse(dr["ResponsID"].ToString().Trim()) != ResponsID)
                {
                    flag = false;
                    break;
                }
                else
                {
                    flag = true;
                }
            }
            return flag;
        }


        protected void SaveJobTitle_Click(object sender, System.EventArgs e)
        {
            if (Page.IsValid)
            {
                if (LblAddJob.Text == "Add New Job Title")
                {
                    // Add New Job Title
                    dsJobtitles.GEN_JobTitlesRow row = dsJobtitles1.GEN_JobTitles.NewGEN_JobTitlesRow();
                    Navigation.BaseObject.SafeMerge(dsJobtitles1, ((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobtitles());
                    row.JobName = NewJobTitle.Text.Trim();
                    row.JobDescription = NewJobTitledescrp.Text;
                    row.JobTitleOrder = 1;
                    row.IsActive = true;

                    bool Flage = CheckJobTitleByName(dsJobtitles1, NewJobTitle.Text);
                    if (Flage)
                    {
                        dsJobtitles1.GEN_JobTitles.AddGEN_JobTitlesRow(row);
                        ((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.AddJobtitles(dsJobtitles1);
                        LoadJobs();
                    }
                    else
                    {
                        Label1.Visible = true;
                        Label1.Text = "This Job Title added so far ,please try another name";
                    }
                }

                else if (LblAddJob.Text == "Edit Job Title")
                {
                    // Edit Job Title
                    Navigation.BaseObject.SafeMerge(dsJobtitles1, ((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobtitles());
                    int editIndex = (int)ViewState["itemindex"];
                    dsJobtitles.GEN_JobTitlesRow row = (dsJobtitles.GEN_JobTitlesRow)dataView1[editIndex].Row;
                    //					dsJobtitles.GEN_JobTitlesRow row = (dsJobtitles.GEN_JobTitlesRow)dsJobtitles1.GEN_JobTitles.Rows[editIndex];
                    row.JobName = NewJobTitle.Text.Trim();
                    row.JobDescription = NewJobTitledescrp.Text;
                    int SelectedJobID = int.Parse(ViewState["JobTitleID"].ToString());
                    //					int SelectedJobID = int.Parse(dataView1[editIndex].Row["JobTitleID"].ToString());
                    bool Flage = CheckJobTitleByNameAndID(dsJobtitles1, NewJobTitle.Text, SelectedJobID);
                    if (Flage)
                    {
                        ((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.EditJobtitle(dsJobtitles1);
                        LoadJobs();
                    }
                    else
                    {
                        Label1.Visible = true;
                        Label1.Text = "This Job Title added so far ,please try another name";
                    }
                }

                else if (LblAddJob.Text == "Add New Responsibility")
                {
                    // Add New Responsibility
                    dsResponsblities.GEN_ResponsibilitiesRow row = dsResponsblities1.GEN_Responsibilities.NewGEN_ResponsibilitiesRow();
                    dsResponsblities1.Merge(((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobResponsbilities(Convert.ToInt32(PassedJobID.Text)));
                    row.ResponsName = NewJobTitle.Text.Trim();
                    row.ResponsDesc = NewJobTitledescrp.Text.Trim();
                    if (TextBoxPeriority.Text.Trim() != "")
                        row.ResponsOrder = Convert.ToInt32(TextBoxPeriority.Text);
                    else
                        row.ResponsOrder = 1;

                    row.JobTitleID = Convert.ToInt32(PassedJobID.Text);
                    row.IsActive = true;
                    bool Flage = CheckResponsibilityByName(dsResponsblities1, NewJobTitle.Text, int.Parse(PassedJobID.Text));
                    if (Flage)
                    {
                        dsResponsblities1.GEN_Responsibilities.AddGEN_ResponsibilitiesRow(row);
                        ((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.AddResponsbilities(dsResponsblities1);

                        dsResponsblities1.Merge(((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobResponsbilities(Convert.ToInt32(PassedJobID.Text)));
                        ViewState["Response"] = dsResponsblities1;

                        dsResponsblities1.Clear();
                        dsResponsblities1.Merge(((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobResponsbilities(Convert.ToInt32(PassedJobID.Text)));
                        dgResponsiblity.DataBind();
                        //Mark the completed responsibility as closed:
                        MarkRespGridItems();
                        ///////////////////////////////////////////////
                    }
                    else
                    {
                        Label1.Visible = true;
                        Label1.Text = "This Responsibility added so far under the selected Job title ,please try another name";

                    }


                }

                else if (LblAddJob.Text == "Edit Job Responsiblity")
                {
                    // Edit Responsibility
                    //					dsResponsblities1 = ( dsResponsblities ) ViewState[ "Response" ];
                    dsResponsblities1.Merge(((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobResponsbilities(Convert.ToInt32(PassedJobID.Text)));

                    int editIndex = (int)ViewState["itemindex"];
                    dsResponsblities.GEN_ResponsibilitiesRow row = dsResponsblities1.GEN_Responsibilities[editIndex];
                    row.ResponsName = NewJobTitle.Text.Trim();
                    row.ResponsDesc = NewJobTitledescrp.Text.Trim();
                    row.IsActive = row.IsActive;
                    if (TextBoxPeriority.Text.Trim() != "")
                        row.ResponsOrder = Convert.ToInt32(TextBoxPeriority.Text);
                    else
                        row.ResponsOrder = 1;

                    int SelectedResponseID = int.Parse(dsResponsblities1.GEN_Responsibilities[editIndex]["ResponsID"].ToString());
                    bool Flage = CheckResponsibilityByNameAndID(dsResponsblities1, NewJobTitle.Text, int.Parse(PassedJobID.Text), SelectedResponseID);
                    if (Flage)
                    {
                        ((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.EditResponsbilities(dsResponsblities1);
                        dsResponsblities1.Clear();
                        dsResponsblities1.Merge(((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobResponsbilities(Convert.ToInt32(PassedJobID.Text)));
                        dgResponsiblity.DataBind();
                        //Mark the completed responsibility as closed:
                        MarkRespGridItems();
                        ///////////////////////////////////////////////
                    }
                    else
                    {
                        Label1.Visible = true;
                        Label1.Text = "This Responsibility added so far under the selected Job title ,please try another name";

                    }


                }
                // Re hide fildes
                HideControls();
            }
        }

        #endregion

        protected void OpenCloseResp_Click(object sender, System.EventArgs e)
        {
            Label1.Visible = false;
            dsResponsblities1.Clear();
            dsResponsblities1.Merge(((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobResponsbilities(Convert.ToInt32(PassedJobID.Text)));
            int checkedcount = 0;
            int rowCount = dgResponsiblity.Items.Count;

            dsResponsblities.GEN_ResponsibilitiesRow Row = dsResponsblities1.GEN_Responsibilities.NewGEN_ResponsibilitiesRow();
            for (int i = rowCount - 1; i >= 0; i--)
            {
                CheckBox ch = (CheckBox)dgResponsiblity.Items[i].Cells[3].Controls[1];
                if (ch.Checked)
                {
                    int RespOpenTasksCount = ((Navigation.BaseObject)Session["navigation"]).TaskWSObject.GetRespOpenTasksCount(int.Parse(dgResponsiblity.Items[i].Cells[0].Text));
                    if (RespOpenTasksCount > 0)
                    {
                        Label1.Text = "'" + ((LinkButton)dgResponsiblity.Items[i].Cells[2].Controls[1]).Text + "'" + " Responsibility has " + RespOpenTasksCount.ToString() + " open tasks, Close open tasks before closing its responsibility.";
                        Label1.Visible = true;
                        return;
                    }
                    //					this.dsResponsblities1.Tables[0].Rows[i]["IsActive"] = false;
                    Row = dsResponsblities1.GEN_Responsibilities.FindByResponsID(int.Parse(dgResponsiblity.Items[i].Cells[0].Text));
                    checkedcount++;
                    if (checkedcount > 1)
                        break;
                }

            }
            if (checkedcount == 0)
            {
                Label1.Text = "Please select a responsibility to close";
                Label1.Visible = true;
                return;
            }
            else if (checkedcount > 1)
            {
                Label1.Text = "Please select only one responsibility to open/close";
                Label1.Visible = true;
                return;
            }
            //Check if the corresponding job title is closed 
            dsJobtitles1.Clear();
            dsJobtitles1.Merge(((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobtitles());
            if (!dsJobtitles1.GEN_JobTitles.FindByJobTitleID(int.Parse(PassedJobID.Text)).IsActive && !Row.IsActive)
            {
                Label1.Text = "You must open the job title to open its responsibilities";
                Label1.Visible = true;
                return;
            }

            //			//If the IsActive value does not entered yet
            //			if(Row.IsIsActiveNull())
            //			{
            //				Row.IsActive = true;
            //			}
            //////////////////////////////////////////////
            //Change Status
            Row.IsActive = !Row.IsActive;
            ///////////////

            int updated = ((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.EditResponsbilities(dsResponsblities1);
            dsResponsblities1.Clear();

            // list Job Responsbilities after editing
            dsResponsblities1.Merge(((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobResponsbilities(Convert.ToInt32(PassedJobID.Text)));
            dgResponsiblity.DataBind();
            MarkRespGridItems();
            HideControls();
        }

        protected void OpenCloseJobtitle_Click(object sender, System.EventArgs e)
        {
            Label1.Visible = false;
            dsJobtitles1.Clear();
            dsJobtitles1.Merge(((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobtitles());
            int checkedcount = 0;
            int rowCount = dgJobTitles.Items.Count;
            dsJobtitles.GEN_JobTitlesRow Row = dsJobtitles1.GEN_JobTitles.NewGEN_JobTitlesRow();

            for (int i = rowCount - 1; i >= 0; i--)
            {
                CheckBox ch = (CheckBox)dgJobTitles.Items[i].Cells[2].Controls[1];
                if (ch.Checked)
                {
                    Row = dsJobtitles1.GEN_JobTitles.FindByJobTitleID(int.Parse(dgJobTitles.Items[i].Cells[0].Text));
                    checkedcount++;
                    if (checkedcount > 1)
                        break;
                }

            }
            if (checkedcount == 0)
            {
                Label1.Text = "Please select a job title to close";
                Label1.Visible = true;
                return;
            }
            else if (checkedcount > 1)
            {
                Label1.Text = "Please select only one job title to close";
                Label1.Visible = true;
                return;
            }

            if (Row.IsActive)
            {
                //Be assured that all responsibilities assigned the selected jobtitle are closed
                dsResponsblities1.Clear();
                dsResponsblities1.Merge(((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobResponsbilities(Row.JobTitleID));
                foreach (dsResponsblities.GEN_ResponsibilitiesRow row in dsResponsblities1.GEN_Responsibilities.Rows)
                {
                    if (/*row.IsIsActiveNull() || */row.IsActive)
                    {
                        Label1.Text = "To close a job title you must close its responsibilities first";
                        Label1.Visible = true;
                        return;
                    }
                }
                //////////////////////////////////////////////////////////////////////////////////////

                //Be assured that all users(employees) assigned to selected jobtitle are terminated
                dsEmployee1.Clear();

                dsEmployee1.Merge(((Navigation.BaseObject)Session["navigation"]).EmployeeWsObject.ListEmployeesDetailedData("JobTitleID=" + Row.JobTitleID + ""));
                foreach (dsEmployee.GEN_EmployeesRow row in dsEmployee1.GEN_Employees.Rows)
                {
                    if (row.EmployeeStatus == 1)
                    {
                        Label1.Text = "To close a job title, all employees having the selected job title must be terminated first";
                        Label1.Visible = true;
                        return;
                    }
                }
            }
            //////////////////////////////////////////////////////////////////////////////////
            //If the IsActive value does not entered yet
            //			if(Row.IsIsActiveNull())
            //			{
            //				Row.IsActive = true;
            //			}
            //////////////////////////////////////////////
            //Change Status
            Row.IsActive = !Row.IsActive;
            bool JobIsActive = Row.IsActive;
            ///////////////

            // delete responsibilities
            int updated = ((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.EditJobtitle(dsJobtitles1);
            dsJobtitles1.Clear();

            // list Jobtitles after editing
            dsJobtitles1.Merge(((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobtitles());
            dgJobTitles.DataBind();
            if (!JobIsActive)
            {
                NewRes.Visible = false;
                btnCopyResponsibility.Visible = false;
            }
            else
            {
                if (((Navigation.BaseObject)Page.Session["navigation"]).SecInfo.IsAdministrator)
                {
                    NewRes.Visible = true;
                    btnCopyResponsibility.Visible = true;
                }
            }
            //Mark the completed jobtitle as closed:
            foreach (DataGridItem gridItem in dgJobTitles.Items)
            {
                if (gridItem.Cells[4].Text == "False")
                {
                    gridItem.CssClass = "completetask";
                    ((LinkButton)gridItem.Cells[1].Controls[1]).Enabled = false;
                }
            }
            ///////////////////////////////////////////////
            HideControls();
        }


        private void MarkRespGridItems()
        {
            //Mark the completed responsibility as closed:
            foreach (DataGridItem gridItem in dgResponsiblity.Items)
            {
                if (gridItem.Cells[4].Text == "False")
                {
                    gridItem.CssClass = "completetask";
                    ((LinkButton)gridItem.Cells[2].Controls[1]).Enabled = false;
                }
            }
            ///////////////////////////////////////////////
        }
        protected void btnCopyResponsibility_Click(object sender, EventArgs e)
        {
            divPanel.Visible = true;
            ddlJobTitles_SelectedIndexChanged(null,null);
        }
        protected void ddlJobTitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            dsResponsblities1.Clear();
            int JobID = Convert.ToInt32(ddlJobTitles.SelectedValue);
            dsResponsblities1.Merge(((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobResponsbilities(JobID));
            ViewState["Response2"] = dsResponsblities1;
            dgResponsiblity2.DataBind();
            dgResponsiblity2.SelectedIndex = -1;
            HideControls();

            //Mark the completed responsibility as closed:
            foreach (DataGridItem gridItem in dgResponsiblity2.Items)
            {
                if (gridItem.Cells[4].Text == "False")
                {
                    gridItem.CssClass = "completetask";
                    ((LinkButton)gridItem.Cells[2].Controls[1]).Enabled = false;
                }
            }

        }
        protected void btnAddcopyResponsibilities_Click(object sender, EventArgs e)
        {


            ////// selected
            Label1.Visible = false;
            HideControls();

            int rowCount = dgResponsiblity2.Items.Count;
            int x = 0;
            dsResponsblities1.Merge(((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobResponsbilities(Convert.ToInt32(PassedJobID.Text)));
            for (int i = rowCount - 1; i >= 0; i--)
            {
                CheckBox ch = (CheckBox)dgResponsiblity2.Items[i].Cells[3].Controls[1];
                if (ch.Checked)
                {
                    x = x + 1;


                    LinkButton linkB = (LinkButton)dgResponsiblity2.Items[i].Cells[2].Controls[1];
                    bool Flage = CheckResponsibilityByName(dsResponsblities1, linkB.Text.Trim(), int.Parse(PassedJobID.Text));
                    if (Flage)
                    {
                        dsResponsblities.GEN_ResponsibilitiesRow row = dsResponsblities1.GEN_Responsibilities.NewGEN_ResponsibilitiesRow();
                        dsResponsblities2 = (dsResponsblities)ViewState["Response2"];
                        row.ResponsName = linkB.Text.Trim();
                        row.ResponsDesc = dsResponsblities2.GEN_Responsibilities[i].ResponsDesc.ToString().Trim();
                        row.ResponsOrder = dsResponsblities2.GEN_Responsibilities[i].ResponsOrder;
                        row.JobTitleID = Convert.ToInt32(PassedJobID.Text);
                        row.IsActive = dsResponsblities2.GEN_Responsibilities[i].IsActive;
                        dsResponsblities1.GEN_Responsibilities.AddGEN_ResponsibilitiesRow(row);

                    }

                }
            }
            if (x > 0)
            {
                ((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.AddResponsbilities(dsResponsblities1);
                dsResponsblities1.Clear();
                dsResponsblities1.Merge(((Navigation.BaseObject)Session["navigation"]).JobTiltesWsObject.ListJobResponsbilities(Convert.ToInt32(PassedJobID.Text)));
                dgResponsiblity.DataBind();
                //Mark the completed responsibility as closed:
                MarkRespGridItems();
                divPanel.Visible = false;
                
            }
            else if (x == 0)
            {
                //Label1.Text = "Please select a responsibility to edit";
                Response.Write("<script>alert('Please select a responsibility to copy')</script>");
                HideControls();
                //Label1.Visible = true;
                return;
            }
            
        }
        protected void btnCloseCopy_Click(object sender, EventArgs e)
        {
            divPanel.Visible = false;
        }
}
}




           



        





