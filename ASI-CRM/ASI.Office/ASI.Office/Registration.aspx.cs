using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using Stimulsoft.Report;
using System.IO;
using System.Text;

public partial class Registration : Office.BLL.RegistrationBLL
{
	string _sortExpression
	{
		get
		{
			if (ViewState["sortExp"] == null)
				return "";
			else
				return ViewState["sortExp"].ToString();
		}
		set { ViewState["sortExp"] = value; }

	}

	string _sortDirection
	{
		get
		{
			if (ViewState["sortDir"] == null)
				return "";
			else
				return ViewState["sortDir"].ToString();
		}
		set { ViewState["sortDir"] = value; }

	}
	protected void Page_Load(object sender, EventArgs e)
	{

		string CurrentPage = "Registration";
		//ucUserTabs.CurrentPage = CurrentPage;
		if (!Page.IsPostBack)
		{
			ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
			scriptManager.RegisterPostBackControl(this.btnExport);

			Office.BLL.MasterClass mc = new Office.BLL.MasterClass();
			//lblVersionInfo.Text = mc. GetVersionInfo();
			ViewState["attendWebinarDate"] = "";
			ViewState["schadualedWebinarDate"] = "";
			ViewState["sortDir"] = "DESC";
			ViewState["sortExp"] = "ID";
			DoBind();
			btnDelete.Enabled = false;
			btnUpdate.Visible = false;
			btnAdd.Enabled = true;
			mResetControls();

			//ViewState["SelectedDate"] = "";
			//txtStartFrom.Text = System.DateTime.Now.ToShortDateString();
			//ViewState["WebinarsWSURL"] = ConfigurationManager.AppSettings["SSSData.SSSData"].ToString();
			//ViewState["WebinarsWSUserName"] = ConfigurationManager.AppSettings["UserNameSSS"].ToString();
			//ViewState["WebinarsWSPassword"] = ConfigurationManager.AppSettings["PasswordSSS"].ToString();
			//bindGrid(false, "");
			//BindWebinars();
			//ViewState["Mode"] = "Add";

		}
		// 
	}
	public override void VerifyRenderingInServerForm(Control control)
	{
		//base.VerifyRenderingInServerForm(control);
	}
	protected void imgbtnSignOut_Click(object sender, ImageClickEventArgs e)
	{
		HttpContext.Current.Session.Clear();
		HttpContext.Current.Response.Redirect("login.aspx");
	}
	protected void ddlWebsitesWS_SelectedIndexChanged(object sender, EventArgs e)
	{
		// we will change this code to read from database according to selected site
        switch (ddlWebsitesWS.SelectedValue)
        {
            case "SSS WebSite":
                btnUpdate.Visible = true;
                break;
            case "ELS WebSite":
                btnUpdate.Visible = false;
                break;
            case "TSN WebSite":
                btnUpdate.Visible = false;
                break;
            default:
                break;
        }

		DoBind();
	}
	private void DoBind()
	{
		if (Request.QueryString["Email"] != null)
		{
			txtSearch.Text = Request.QueryString["Email"].ToString();
			mBindRegisterationGrid(txtSearch.Text, true);
			mSetRegistrationData(Request.QueryString["Email"]);
			ViewState["ApprovedStatus"] = false;
			ViewState["Mode"] = "Add";




		}
		else if (ddlSearchType.SelectedValue.ToString() != "All" && Request.QueryString["Email"] == null)
		{
			txtSearch.Text = "";
			mBindRegisterationGrid("", true);
			//mSetRegistrationData("");
			ViewState["ApprovedStatus"] = false;
			ViewState["Mode"] = "Add";

		}
		else
		{
			//mBindRegisterationGrid(); // no need for this one
			mBindRegisterationGrid("", _sortExpression, _sortDirection);
		}


	}
	protected void gvRegistration_SelectedIndexChanged(object sender, EventArgs e)
	{

	}
	protected void lbtnDetails_Click(object sender, EventArgs e)
	{
		// need revision
		//if (!TSNKey.Security.TSNOfficeSecuirty.CheckRule(153))
		//{
		//    cbApproved.Enabled = false;
		//}

		GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent;
		// string email = row.Cells[3].Text.Trim();
		string email = ((HyperLink)row.Cells[3].FindControl("hlEmail")).Text.ToString().Trim();

		// call new function from to get data from SSSAdmin web services by email 
		if (email != "")
		{
			mResetControls();
			ddlistUpdateWebinar.Visible = true;
			Label25.Visible = true;

			mSetRegistrationData(email);
			ViewState["Mode"] = "Edit";
			btnDelete.Enabled = true;
			btnAdd.Enabled = false;
			btnUpdate.Visible = true;
			BindUpdateWebinars();

			if (ViewState["schadualedWebinarDate"].ToString().Trim() != "")
			{
				ListItem item = ddlistUpdateWebinar.Items.FindByValue(ViewState["schadualedWebinarDate"].ToString());
				if (item != null)
				{
					ddlistUpdateWebinar.SelectedIndex = -1;
					item.Selected = true;

				}
			}


		}
		else
		{
			mResetControls();
		}
	}

	private void mSetRegistrationData(string email)
	{
		DataRow drData = mGetRegistrationDataByEmail(email);
		if (drData != null)
		{

			txtID.Text = drData["ID"].ToString();
			txtFirstName.Text = drData["FirstName"].ToString();
			txtLastName.Text = drData["LastName"].ToString();
			txtAddress.Text = drData["Address"].ToString();
			txtAddress2.Text = drData["Address2"].ToString();
			txtCity.Text = drData["City"].ToString();
			txtState.Text = drData["State"].ToString();
			txtCountry.Text = drData["Country"].ToString();
			txtPhone.Text = drData["Phone"].ToString();
			txtFax.Text = drData["Fax"].ToString();
			txtWebsite.Text = drData["Website"].ToString();
			txtEmail.Text = drData["Email"].ToString();
			//txtPwd.Text = drData["Pwd"].ToString();
			txtRegDate.Text = drData["RegDate"].ToString();
			txtCompanyName.Text = drData["CompanyName"].ToString();
			txtZipCode.Text = drData["ZipCode"].ToString();
			txtWebinarDate.Text = ViewState["attendWebinarDate"].ToString();

			try
			{
				cbSSS.Checked = Convert.ToBoolean(drData["SSS"]);
			}
			catch
			{
				cbSSS.Checked = false;
			}
			try
			{
				cbLGD.Checked = Convert.ToBoolean(drData["LGD"]);
			}

			catch
			{
				cbLGD.Checked = false;
			}

			try
			{
				cbLDG.Checked = Convert.ToBoolean(drData["LDG"]);
			}

			catch
			{
				cbLDG.Checked = false;
			}

			try
			{
				cbApproved.Checked = Convert.ToBoolean(drData["Approved"]);
				ViewState["ApprovedStatus"] = cbApproved.Checked;
			}

			catch
			{
				cbApproved.Checked = false;
			}


			try
			{
				cbCkeckList.Checked = Convert.ToBoolean(drData["CkeckList"]);
			}
			catch
			{
				cbApproved.Checked = false;
			}

			if (drData["visible"] == DBNull.Value)
			{
				chBoxVisible.Checked = true;
			}
			else
			{

				try
				{
					chBoxVisible.Checked = Convert.ToBoolean(drData["visible"]);
				}
				catch (Exception ex)
				{

					chBoxVisible.Checked = false;
				}

			}

			try
			{
				cbAgrement.Checked = Convert.ToBoolean(drData["Agreement"]);
			}
			catch
			{
				cbAgrement.Checked = false;
			}

			try
			{
				txtApprovedBy.Text = drData["ApprovedBy"].ToString();
				txtApprovedDate.Text = drData["ApprovedDate"].ToString();
				txtCheckListBy.Text = drData["UpdateBy"].ToString();

				//if (txtApprovedBy.Text.Trim()!="")
				// {
				lblApprovedBy.Visible = true;
				txtApprovedBy.Visible = true;
				txtApprovedDate.Visible = true;
				txtCheckListBy.Visible = true;
				//}




			}
			catch
			{
				lblApprovedBy.Visible = false;
				txtApprovedBy.Visible = false;
				txtCheckListBy.Visible = false;
				txtApprovedDate.Visible = false;

			}



		}
		else
		{
			mResetControls();

		}

	}

	private void mResetControls()
	{
		txtID.Text = "";
		txtFirstName.Text = "";
		txtLastName.Text = "";
		txtAddress.Text = "";
		txtAddress2.Text = "";
		txtCity.Text = "";
		txtState.Text = "";
		txtCountry.Text = "";
		txtPhone.Text = "";
		txtFax.Text = "";
		txtWebsite.Text = "";
		txtEmail.Text = "";

		txtRegDate.Text = System.DateTime.Now.ToShortDateString();
		txtCompanyName.Text = "";
		txtZipCode.Text = "";
		cbSSS.Checked = false;
		cbLGD.Checked = false;
		cbLDG.Checked = false;
		cbApproved.Checked = false;
		cbApproved.Checked = false;
		cbAgrement.Checked = false;

		lblPassword.Visible = false;
		txtPassword.Visible = false;
		txtWebinarDate.Text = "";

	}

	private void mDeleteRegisterationData(string ID)
	{
		SSSData.SSSData sdata = new SSSData.SSSData();
		SSSData.AuthHeader ss = new SSSData.AuthHeader();
		ss.Password = ConfigurationManager.AppSettings["PasswordSSS"].ToString();
		ss.Username = ConfigurationManager.AppSettings["UserNameSSS"].ToString();

		// must be deleted to work in USA// mglil
		//System.Net.IWebProxy proxy = new System.Net.WebProxy("http://ISA1:8080", true);
		//proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
		//sdata.Proxy = proxy;

		// 

		sdata.AuthHeaderValue = ss;
		if (sdata.DeleteMember(ID))
		{
			btnDelete.Enabled = false;
			btnAdd.Enabled = true;
			btnUpdate.Visible = false;
			Label25.Visible = false;
			mResetControls();
		}

	}
	DataRow mGetRegistrationDataByEmail(string vsEmail)
	{
		SSSData.SSSData sdata = new SSSData.SSSData();
		SSSData.AuthHeader ss = new SSSData.AuthHeader();
		ss.Password = ConfigurationManager.AppSettings["PasswordSSS"].ToString();
		ss.Username = ConfigurationManager.AppSettings["UserNameSSS"].ToString();

		// must be deleted to work in USA// mglil
		//System.Net.IWebProxy proxy = new System.Net.WebProxy("http://ISA1:8080", true);
		//proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
		//sdata.Proxy = proxy;

		// 

		sdata.AuthHeaderValue = ss;

		try
		{
			object AttednWebinarDate = sdata.CheckWebinarAttendDate(vsEmail);
			object schadualWebinar = sdata.GetSchadualWebinar(vsEmail);
			if (AttednWebinarDate != null)
			{
				ViewState["attendWebinarDate"] = AttednWebinarDate.ToString();

			}
			else
			{
				ViewState["attendWebinarDate"] = "";
			}

			if (schadualWebinar != null)
			{
				ViewState["schadualedWebinarDate"] = schadualWebinar.ToString();
			}
			else
			{
				ViewState["schadualedWebinarDate"] = "";
			}
		}
		catch (Exception ex)
		{

			string x = "mglil to delete the exception after sss published";
		}



		DataTable dt = sdata.GetAllMembers();


		DataColumn CkeckListCol = new DataColumn("CkeckList");
		CkeckListCol.DataType = typeof(Boolean);
		CkeckListCol.ReadOnly = false;
		CkeckListCol.DefaultValue = 0;

		DataColumn AgrementCol = new DataColumn("Agrement");
		AgrementCol.DataType = typeof(Boolean);
		AgrementCol.ReadOnly = false;
		AgrementCol.DefaultValue = 0;


		DataColumn UpdateByCol = new DataColumn("UpdateBy");
		UpdateByCol.DataType = typeof(string);
		UpdateByCol.ReadOnly = false;
		UpdateByCol.DefaultValue = "";
		UpdateByCol.AllowDBNull = true;

		DataColumn updateDateCol = new DataColumn("updateDate");
		updateDateCol.DataType = typeof(DateTime);
		updateDateCol.ReadOnly = false;
		updateDateCol.DefaultValue = System.DateTime.Now;
		updateDateCol.AllowDBNull = true;


		DataColumn VisibleCol = new DataColumn("visible");
		AgrementCol.DataType = typeof(Boolean);
		AgrementCol.ReadOnly = false;
		AgrementCol.DefaultValue = 0;


		//updateDate


		dt.Columns.Add(CkeckListCol);
		dt.Columns.Add(AgrementCol);
		dt.Columns.Add(UpdateByCol);
		dt.Columns.Add(updateDateCol);
		dt.Columns.Add(VisibleCol);

		//dt.Columns.Add("CkeckList", typeof(Boolean), "0");
		//dt.Columns.Add("Agrement", typeof(Boolean), "0");


		dt.AcceptChanges();
		DataRow DREmailReg;
		foreach (DataRow dr in dt.Rows)
		{
			DREmailReg = mGetRegisterationByEmail(dr["Email"].ToString().Trim());
			if (DREmailReg != null)
			{
				dr["CkeckList"] = DREmailReg["CheckList"];
				dr["Agrement"] = DREmailReg["Agrement"];

				dr["UpdateBy"] = DREmailReg["UpdateBy"];
				dr["updateDate"] = DREmailReg["updateDate"];
				object oj = DREmailReg["Visible"];
				try
				{
					bool ii = Convert.ToBoolean(oj);
				}
				catch (Exception ex)
				{

					string xx = ex.Message;
				}
				dr["visible"] = DREmailReg["Visible"];

			}

		}
		dt.AcceptChanges();

		DataTable dFiltered = dt.Clone();
		DataRow[] dRowUpdates = dt.Select("Email Like'%" + vsEmail.Trim() + "%'");
		//DataRow[] dRowUpdates = dt.Select("Email Like'%" + txtSearch.Text.Trim() + "%' and CkeckList=False ");

		foreach (DataRow dr in dRowUpdates)
			dFiltered.ImportRow(dr);

		if (dFiltered.Rows.Count > 0)
			return dFiltered.Rows[0];
		else return null;
	}
	public static ArrayList getNewWebinars()
	{
		ArrayList DateList = new ArrayList();
		DateTime date1 = DateTime.Parse("04/12/2011");
		DateTime todayDate = System.DateTime.Now;
		//int no = DateTime.Compare(todayDate, date1);
		int no = todayDate.Subtract(date1).Days;
		int reminder = no / 14;
		date1 = date1.AddDays(14 + (reminder * 14));
		DateList.Add(string.Format("Tuesday, {0} @ 01:00 PM", date1.ToShortDateString()));
		DateList.Add(string.Format("Tuesday, {0} @ 01:00 PM", date1.AddDays(14).ToShortDateString()));
		DateList.Add(string.Format("Tuesday, {0} @ 01:00 PM", date1.AddDays(28).ToShortDateString()));
		return DateList;

	}

	private bool EditMember(string firstname, string lastname, string address, string address2, string city, string state, string country, string company, string phone, string fax, string website, string email, DateTime regDate, bool sss, bool lgd, bool ldg, bool approved, string zipcode, bool checkListValue, bool agreementValue, string ID)
	{
		SSSData.SSSData sdata = new SSSData.SSSData();
		SSSData.AuthHeader ss = new SSSData.AuthHeader();
		ss.Password = ConfigurationManager.AppSettings["PasswordSSS"].ToString();
		ss.Username = ConfigurationManager.AppSettings["UserNameSSS"].ToString();
		// must be deleted to work in USA //mglil
		//System.Net.IWebProxy proxy = new System.Net.WebProxy("http://ISA1:8080", true);
		//proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
		//sdata.Proxy = proxy;

		// 

		sdata.AuthHeaderValue = ss;
		bool result = false;
		try
		{
			int _ID = int.Parse(ID);
			result = sdata.EditMember(firstname, lastname, address, address2, city, state, country, company, phone, fax, website, email, regDate, sss, lgd, ldg, approved, zipcode, _ID);
			sdata.UpdateAgreement(email, agreementValue);
			bool approvedStatus = Convert.ToBoolean(ViewState["ApprovedStatus"]);

			if (ViewState["schadualedWebinarDate"].ToString().Trim() != "")
			{
				if (ddlistUpdateWebinar.SelectedValue.ToString().Trim() != ViewState["schadualedWebinarDate"].ToString().Trim())
				{
					sdata.updateSchadualWebinar(email, ddlistUpdateWebinar.SelectedValue.ToString());
				}

			}

			if (approved == true && approvedStatus == false)
			{
				pnlConfirmation.Visible = true;
				DDListWebinars.DataSource = getNewWebinars();
				DDListWebinars.DataBind();
			}
		}
		catch (Exception Ex)
		{

			//ExceptionManager.AddException("registeration.aspx", "EditMemeber", Ex.Message);
			string msg = Ex.Message;

		}

		if (result == true)
		{
			try
			{
				//HelperFunctions hf = new HelperFunctions();
				//hf.mUpdateRegisteration(email,checkListValue, agreementValue);//new web agreement
				mUpdateRegisteration(email, checkListValue, false, chBoxVisible.Checked);
			}
			catch (Exception ex)
			{
				//ExceptionManager.AddException("Registration.aspx", "EditMember", ex.Message);
				string msg = ex.Message;
			}
		}

		return result;




	}

	private bool AddMember(string firstname, string lastname, string address, string address2, string city, string state, string country, string company, string phone, string fax, string website, string email, DateTime regDate, bool sss, bool lgd, bool ldg, bool approved, string zipcode, bool checkListValue, bool agreementValue, string password)
	{
        //SSSData.SSSData sdata = new SSSData.SSSData();
        //SSSData.AuthHeader ss = new SSSData.AuthHeader();
        //ss.Password = ConfigurationManager.AppSettings["PasswordSSS"].ToString();
        //ss.Username = ConfigurationManager.AppSettings["UserNameSSS"].ToString();
		// must be deleted to work in USA //mglil
		//System.Net.IWebProxy proxy = new System.Net.WebProxy("http://ISA1:8080", true);
		//proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
		//sdata.Proxy = proxy;

		// 

		//sdata.AuthHeaderValue = ss;
		bool result = false;
		try
		{
			// int _ID = int.Parse(ID);
            switch (ddlWebsitesWS.SelectedValue)
            {
                case "SSS WebSite":
                    result = new SSSDataHelper().AddMember(firstname, lastname, address, address2, city, state, country, company, phone, fax, website, email, regDate, sss, lgd, ldg, approved, zipcode, checkListValue, agreementValue, password);
                    break;
                case "ELS WebSite":
                    //dt = new ELSDataHelper().GetData();
                    break;
                case "TSN WebSite":
                    result = new SSSDataHelper().AddMember(firstname, lastname, address, address2, city, state, country, company, phone, fax, website, email, regDate, sss, lgd, ldg, approved, zipcode, checkListValue, agreementValue, password);
                    break;
                default:
                    result = new SSSDataHelper().AddMember(firstname, lastname, address, address2, city, state, country, company, phone, fax, website, email, regDate, sss, lgd, ldg, approved, zipcode, checkListValue, agreementValue, password);
                    break;
            }

            
			if (approved == true)
			{
				pnlConfirmation.Visible = true;
				DDListWebinars.DataSource = GetWebinars(System.DateTime.Now);
				DDListWebinars.DataBind();

			}
		}
		catch (Exception Ex)
		{
			// ExceptionManager.AddException("registeration.aspx", "AddMemeber", Ex.Message);
			string msg = Ex.Message;
		}

		if (result == true)
		{
			try
			{
				mUpdateRegisteration(email, checkListValue, false, chBoxVisible.Checked);
			}
			catch (Exception ex)
			{
				//ExceptionManager.AddException("Registration.aspx", "EditMember", ex.Message);
				string msg = ex.Message;
			}
		}

		return result;




	}

	public ArrayList GetWebinars(DateTime StartDate)
	{
		if (HttpContext.Current.Session["DateList"] == null)
		{
			setWebinars(StartDate);
		}
		ArrayList DateListtemp = (ArrayList)HttpContext.Current.Session["DateList"];
		ArrayList DateList = new ArrayList();
		string dateStr = "";
		string dateStrOrg = "";
		DateTime datevl;

		for (int i = 0; i < DateListtemp.Count; i++)
		{
			dateStr = DateListtemp[i].ToString();
			dateStrOrg = dateStr;
			dateStr = dateStr.Replace("Tuesday,", "");
			dateStr = dateStr.Replace("Thursday,", "");
			dateStr = dateStr.Replace("@ 01:00 PM", "");
			dateStr = dateStr.Replace("@1:00 PM", "");
			dateStr = dateStr.Replace("@ 1:00 PM", "");
			if (dateStr.Trim().Length > 0)
			{
				datevl = Convert.ToDateTime(dateStr.Trim());
				if (datevl > StartDate)
					DateList.Add(dateStrOrg);
			}
		}

		return DateList;

	}

	public void setWebinars(DateTime StartDate)
	{
		DateTime todayDate = StartDate;
		ArrayList DateList = new ArrayList();
		DataView dv = null;
		string dateStr;
		string dateStrorg;
		DateTime datevl;
		DataTable dtWS;
		DataTable dt = new DataTable();
		dt.Columns.Add("dateStr", typeof(string));
		dt.Columns.Add("dateDDT", typeof(DateTime));
		if (HttpContext.Current.Session["webinars"] != null)
		{
			dv = (DataView)HttpContext.Current.Session["webinars"];

		}
		else
		{
			//SSSData.SSSData sdata = new SSSData.SSSData();
			//SSSData.AuthHeader ss = new SSSData.AuthHeader();
			//sdata.Url = ViewState["WebinarsWSURL"].ToString();
			//ss.Password = ViewState["WebinarsWSPassword"].ToString();
			//ss.Username = ViewState["WebinarsWSUserName"].ToString();
			//sdata.AuthHeaderValue = ss;
			dtWS = new SSSDataHelper().GetWebinarData();//sdata.GetAllWebinarRegistrations();
			dv = dtWS.DefaultView;

		}

		dv.Sort = "Webinardata asc";

		for (int i = 0; i < dv.Table.Rows.Count; i++)
		{
			dateStr = dv.Table.Rows[i]["Webinardata"].ToString();
			dateStrorg = dateStr;
			dateStr = dateStr.Replace("Tuesday,", "");
			dateStr = dateStr.Replace("Thursday,", "");
			dateStr = dateStr.Replace("@ 01:00 PM", "");
			dateStr = dateStr.Replace("@1:00 PM", "");
			dateStr = dateStr.Replace("@ 1:00 PM", "");



			if (dateStr.Trim().Length > 0)
			{
				datevl = Convert.ToDateTime(dateStr.Trim());
				// if (datevl > StartDate)                     

				dt.Rows.Add(dateStrorg, datevl);





			}

		}




		dv = null;
		//dv= dt.DefaultView.ToTable(true, "dateStr").DefaultView;

		dv = dt.DefaultView;
		dv.Sort = "dateDDT";

		DataView dv2 = dv.ToTable(true, "dateStr").DefaultView;

		for (int y = 0; y < dv2.Table.Rows.Count; y++)
		{
			DateList.Add(dv2.Table.Rows[y][0].ToString());
		}

		HttpContext.Current.Session["DateList"] = DateList;
	}

	protected void btnUpdate_Click(object sender, EventArgs e)
	{
		// call UpDate Registeration Data in web services

		if (ViewState["Mode"].ToString() == "Add")
		{
			AddMember(txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtAddress2.Text, txtCity.Text, txtState.Text, txtCountry.Text, txtCompanyName.Text, txtPhone.Text, txtFax.Text, txtWebsite.Text, txtEmail.Text, Convert.ToDateTime(txtRegDate.Text), cbSSS.Checked, cbLGD.Checked, cbLDG.Checked, cbApproved.Checked, txtZipCode.Text, cbCkeckList.Checked, cbAgrement.Checked, txtPassword.Text);
		}
		else
		{
			EditMember(txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtAddress2.Text, txtCity.Text, txtState.Text, txtCountry.Text, txtCompanyName.Text, txtPhone.Text, txtFax.Text, txtWebsite.Text, txtEmail.Text, Convert.ToDateTime(txtRegDate.Text), cbSSS.Checked, cbLGD.Checked, cbLDG.Checked, cbApproved.Checked, txtZipCode.Text, cbCkeckList.Checked, cbAgrement.Checked, txtID.Text);
		}

		//new SSSDataHelper().RefreshData();
		mBindRegisterationGrid(txtSearch.Text, false);

		//mBindRegisterationGrid();



	}
	# region create a table from dataview
	/// <summary>
	/// Convert given dataview to datatable
	/// </summary>
	/// <param name="obDataView"></param>
	/// <returns></returns>
	public static DataTable CreateTable(DataView obDataView)
	{
		if (null == obDataView)
		{
			throw new ArgumentNullException
				 ("DataView", "Invalid DataView object specified");
		}

		DataTable obNewDt = obDataView.Table.Clone();
		int idx = 0;
		string[] strColNames = new string[obNewDt.Columns.Count];
		foreach (DataColumn col in obNewDt.Columns)
		{
			strColNames[idx++] = col.ColumnName;
		}

		IEnumerator viewEnumerator = obDataView.GetEnumerator();
		while (viewEnumerator.MoveNext())
		{
			DataRowView drv = (DataRowView)viewEnumerator.Current;
			DataRow dr = obNewDt.NewRow();
			try
			{
				foreach (string strName in strColNames)
				{
					dr[strName] = drv[strName];
				}
			}
			catch (Exception ex)
			{

			}
			obNewDt.Rows.Add(dr);
		}

		return obNewDt;
	}
	#endregion
	protected void btnSearch_Click(object sender, EventArgs e)
	{
		mBindRegisterationGrid(txtSearch.Text, true);
		divDetails.Visible = gvRegistration.Rows.Count > 0;
	}
	private void mBindRegisterationGrid()
	{
		mBindRegisterationGrid("", false);
	}

	protected void mBindRegisterationGrid(string SearchExpresson, bool restControl)
	{

		DataTable dFiltered = mBindRegisterationGrid(SearchExpresson, restControl, true);
		gvRegistration.DataSource = null;
		gvRegistration.DataBind();
		gvRegistration.DataSource = dFiltered;
		gvRegistration.DataBind();
	}
	protected void mBindRegisterationGrid(string SearchExpresson, string sortExpression, string sortDirection)
	{

		DataTable dFiltered = mBindRegisterationGrid(SearchExpresson, true, true);

		string sortDir = " asc";
		if (ViewState["sortDir"] == null)
		{
			ViewState["sortDir"] = " asc";

		}
		else
		{
			string x = ViewState["sortDir"].ToString();
			string y = ViewState["sortExp"].ToString();
			string z = sortExpression;
			if (ViewState["sortDir"].ToString() == " asc" && ViewState["sortExp"].ToString() == sortExpression)
			{
				sortDir = " desc";
				ViewState["sortDir"] = " desc";

			}
			else if (ViewState["sortDir"].ToString() == " desc" && ViewState["sortExp"].ToString() == sortExpression)
			{
				sortDir = " asc";
				ViewState["sortDir"] = " asc";

			}




		}
		if (sortExpression.Trim() != "")
		{
			ViewState["sortExp"] = sortExpression;
		}


		DataView dv = dFiltered.DefaultView;
		if (sortExpression.Trim() != "")
		{
			dv.Sort = sortExpression + sortDir;
		}


		gvRegistration.DataSource = dv;
		gvRegistration.DataBind();
	}
	protected DataTable mBindRegisterationGrid(string SearchExpresson, bool resetControl, bool getExportData)
	{
		if (resetControl)
		{
			mResetControls();
		}

		DataTable dt;


		//if (ViewState["WebinarsWSURL"] == null || ViewState["WebinarsWSURL"].ToString().Length == 0)
		//{
		//    dt = new SSSDataHelper().GetData();
		//}
		//else
		//{
		switch (ddlWebsitesWS.SelectedValue)
		{
			case "SSS WebSite":
				dt = new SSSDataHelper().GetData();
				break;
			case "ELS WebSite":
				dt = new ELSDataHelper().GetData();
				break;
			case "TSN WebSite":
				dt = new SSSDataHelper().GetData();
				break;
			default:
				dt = new SSSDataHelper().GetData();
				break;
		}
		//}


		// must be deleted to work in USA //mglil
		//System.Net.IWebProxy proxy = new System.Net.WebProxy("http://ISA1:8080", true);
		//proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
		//sdata.Proxy = proxy;

		// 

		//DataTable dt = sdata.GetAllMembers();
		///

		string vsSearchInddl = ddlSearchType.SelectedValue.ToString();
		string vsSearch;

		if (vsSearchInddl == "Approved")
			//vsSearch = "and Approved=True and visible<>False";//mglil
			vsSearch = "and Approved=True ";
		else if (vsSearchInddl == "NotApproved")
			vsSearch = "and Approved=False ";
		else if (vsSearchInddl == "All")
			vsSearch = "and 1=1";
		else if (vsSearchInddl == "CheckList")
			vsSearch = "and CkeckList=True ";
		else if (vsSearchInddl == "NoCheckList")
			vsSearch = "and CkeckList=False ";
		else if (vsSearchInddl == "Hidden")
			vsSearch = "and visible=False ";
		else vsSearch = "";

		DataTable dFiltered = dt.Clone();
		string selectSt = " (Email Like'%" + txtSearch.Text.Trim() + "%' or FirstName Like'%" + txtSearch.Text.Trim() + "%' or LastName Like'%" + txtSearch.Text.Trim() + "%')  " + vsSearch;
		//DataRow[] dRowUpdates = dt.Select(" (Email Like'%" + txtSearch.Text.Trim() + "%' or FirstName Like'%" + txtSearch.Text.Trim() + "%' or LastName Like'%" + txtSearch.Text.Trim() + "%')  " + vsSearch);
		////DataRow[] dRowUpdates = dt.Select("Email Like'%" + txtSearch.Text.Trim() + "%' and CkeckList=False ");

		DataView dataView = dt.DefaultView;
		dataView.RowFilter = " (Email Like'%" + txtSearch.Text.Trim() + "%' or FirstName Like'%" + txtSearch.Text.Trim() + "%' or LastName Like'%" + txtSearch.Text.Trim() + "%')  " + vsSearch;
		dFiltered = dataView.ToTable();

		DataColumn CkeckListCol = new DataColumn("CkeckList");
		CkeckListCol.DataType = typeof(Boolean);
		CkeckListCol.ReadOnly = false;
		CkeckListCol.DefaultValue = 0;

		DataColumn AgrementCol = new DataColumn("Agrement");
		AgrementCol.DataType = typeof(Boolean);
		AgrementCol.ReadOnly = false;
		AgrementCol.DefaultValue = 0;


		DataColumn UpdateByCol = new DataColumn("UpdateBy");
		UpdateByCol.DataType = typeof(string);
		UpdateByCol.ReadOnly = false;
		UpdateByCol.DefaultValue = "";
		UpdateByCol.AllowDBNull = true;

		DataColumn updateDateCol = new DataColumn("updateDate");
		updateDateCol.DataType = typeof(DateTime);
		updateDateCol.ReadOnly = false;
		updateDateCol.DefaultValue = System.DateTime.Now;
		updateDateCol.AllowDBNull = true;

        DataColumn regDateCol = new DataColumn("regDate");
        regDateCol.DataType = typeof(DateTime);
        regDateCol.ReadOnly = false;
        regDateCol.DefaultValue = System.DateTime.Now;
        regDateCol.AllowDBNull = true;


		DataColumn VisibleCol = new DataColumn("visible");
		AgrementCol.DataType = typeof(Boolean);
		AgrementCol.ReadOnly = false;
		AgrementCol.DefaultValue = 0;


		//updateDate

		if (!dFiltered.Columns.Contains("CkeckList"))
			dFiltered.Columns.Add(CkeckListCol);
		if (!dFiltered.Columns.Contains("Agrement"))
			dFiltered.Columns.Add(AgrementCol);
		if (!dFiltered.Columns.Contains("UpdateBy"))
			dFiltered.Columns.Add(UpdateByCol);
		if (!dFiltered.Columns.Contains("updateDate"))
			dFiltered.Columns.Add(updateDateCol);
        if (!dFiltered.Columns.Contains("regDate"))
            dFiltered.Columns.Add(regDateCol);
		if (!dFiltered.Columns.Contains("visible"))
			dFiltered.Columns.Add(VisibleCol);

		////
		//dt.Columns.Add("CkeckList", typeof(Boolean), "0");
		//dt.Columns.Add("Agrement", typeof(Boolean), "0");
		//dt.AcceptChanges();
		///
		DataRow DREmailReg;

		foreach (DataRow dr in dFiltered.Rows)
		{

			DREmailReg = mGetRegisterationByEmail(dr["Email"].ToString());
			if (DREmailReg != null)
			{
				dr["CkeckList"] = DREmailReg["CheckList"];
				dr["Agrement"] = DREmailReg["Agrement"];
				dr["UpdateBy"] = DREmailReg["UpdateBy"];
				dr["updateDate"] = DREmailReg["updateDate"];
				dr["visible"] = DREmailReg["Visible"];
			}

		}
		dFiltered.AcceptChanges();


		DataTable FinalTable = dFiltered.Clone();
		foreach (DataRow dr in dFiltered.Rows)
		{


			if (dr["visible"].ToString().Trim() != "")
			{
				if (vsSearchInddl == "Hidden")
				{
					FinalTable.ImportRow(dr);
				}
				else
				{
					if (dr["visible"].ToString() == "True")
					{
						FinalTable.ImportRow(dr);
					}
				}
			}
			else
			{
				FinalTable.ImportRow(dr);
			}

		}

		return FinalTable;

	}
	protected void btnClearCache_Click(object sender, EventArgs e)
	{
		Cache.Remove("MembersDataTable");
	}
	protected void btnDelete_Click(object sender, EventArgs e)
	{
		mDeleteRegisterationData(txtID.Text);
		new SSSDataHelper().RefreshData();
		mBindRegisterationGrid("", true);
	}
	//protected void btnSave_Click(object sender, EventArgs e)
	//{
	//    //mEditeRegisterationData(txtID.Text,txtFirstName.Text,txtLastName.Text,txtAddress.Text,txtAddress2.Text, txtCity.Text, txtState.Text,txtCountry.Text,txtPhone.Text,txtFax.Text,txtWebsite.Text ,txtEmail.Text,txtPwd.Text,txtRegDate.Text,txtCompanyName.Text,txtZipCode.Text,cbSSS.Checked,cbLGD.Checked,cbLDG.Checked,cbApproved.Checked,cbApproved.Checked,cbAgrement.Checked)
	//    mBindRegisterationGrid();
	//}
	protected void btnAdd_Click(object sender, EventArgs e)
	{
		mResetControls();
		ViewState["Mode"] = "Add";
		txtPassword.Visible = true;
		lblPassword.Visible = true;
		ddlistUpdateWebinar.Visible = false;
		Label25.Visible = false;
		btnDelete.Enabled = false;
		btnAdd.Enabled = false;
		btnUpdate.Visible = true;

	}
	protected void btnOk_Click(object sender, EventArgs e)
	{
		SSSData.SSSData sdata = new SSSData.SSSData();
		SSSData.AuthHeader ss = new SSSData.AuthHeader();
		ss.Password = ConfigurationManager.AppSettings["PasswordSSS"].ToString();
		ss.Username = ConfigurationManager.AppSettings["UserNameSSS"].ToString();
		// must be deleted to work in USA //mglil
		//System.Net.IWebProxy proxy = new System.Net.WebProxy("http://ISA1:8080", true);
		//proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
		//sdata.Proxy = proxy;

		// 

		sdata.AuthHeaderValue = ss;
		bool result = false;
		try
		{
			result = sdata.EditApprovedBy(txtEmail.Text, User.Identity.Name, System.DateTime.Now, true, DDListWebinars.SelectedValue.ToString());

			new SSSDataHelper().RefreshData();
		}
		catch (Exception ex)
		{
			// ExceptionManager.AddException("registeration.aspx", "btnOk_Click", ex.Message);
			string msg = ex.Message;
		}
		pnlConfirmation.Visible = false;

	}
	protected void btnNoRegist_Click(object sender, EventArgs e)
	{

		SSSData.SSSData sdata = new SSSData.SSSData();
		SSSData.AuthHeader ss = new SSSData.AuthHeader();
		ss.Password = ConfigurationManager.AppSettings["PasswordSSS"].ToString();
		ss.Username = ConfigurationManager.AppSettings["UserNameSSS"].ToString();
		// must be deleted to work in USA //mglil
		//System.Net.IWebProxy proxy = new System.Net.WebProxy("http://ISA1:8080", true);
		//proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
		//sdata.Proxy = proxy;

		// 
		sdata.AuthHeaderValue = ss;
		bool result = false;
		try
		{
			sdata.EditApprovedBy(txtEmail.Text, User.Identity.Name, System.DateTime.Now, true, "");
		}
		catch (Exception ex)
		{
			//  ExceptionManager.AddException("registeration.aspx", "btnOk_Click", ex.Message);
			string msg = ex.Message;
		}
		pnlConfirmation.Visible = false;

	}
	protected void btnCancel_Click(object sender, EventArgs e)
	{
		pnlConfirmation.Visible = false;
	}
	protected void gvRegistration_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
	{

	}
	protected void gvRegistration_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		gvRegistration.PageIndex = e.NewPageIndex;

		mBindRegisterationGrid(txtSearch.Text, _sortExpression, _sortDirection);
	}
	protected void txtSearch_TextChanged(object sender, EventArgs e)
	{

	}

	private void BindUpdateWebinars()
	{
		DateTime startdate = Convert.ToDateTime("05/18/2010");
		ArrayList list = GetWebinars(startdate);
		ddlistUpdateWebinar.DataSource = list;
		ddlistUpdateWebinar.DataBind();
	}
	protected void btnExport_Click(object sender, EventArgs e)
	{
		//Turn off the view state
		this.EnableViewState = false;
		//Remove the charset from the Content-Type header
		Response.Charset = String.Empty;




		HttpContext.Current.Response.Clear();
		HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=Members.xls");
		HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
		StringWriter stringWriter = new StringWriter();
		HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWriter);

		StringBuilder sbResponseString = new StringBuilder();

		DataTable dt = mBindRegisterationGrid(txtSearch.Text, true, true);
		dt.Columns.Remove("Address");
		dt.Columns.Remove("Address2");
		dt.Columns.Remove("City");
		dt.Columns.Remove("State");
		dt.Columns.Remove("Country");
		dt.Columns.Remove("Phone");
		dt.Columns.Remove("Fax");
		dt.Columns.Remove("Website");
		dt.Columns.Remove("Pwd");
		dt.Columns.Remove("SSS");
		dt.Columns.Remove("LGD");
		dt.Columns.Remove("LDG");
		dt.Columns.Remove("Approved");
		dt.Columns.Remove("ZipCode");
		dt.Columns.Remove("ApprovedBy");
		dt.Columns.Remove("ApprovedDate");
		dt.Columns.Remove("Agreement");
		dt.Columns.Remove("SurveyCount");
		dt.Columns.Remove("CkeckList");
		dt.Columns.Remove("Agrement");
		dt.Columns.Remove("UpdateBy");
		dt.Columns.Remove("updateDate");
		dt.Columns.Remove("visible");

		DataGrid dg = new DataGrid();
		dg.HeaderStyle.BackColor = System.Drawing.Color.DarkRed;
		dg.HeaderStyle.Font.Bold = true;
		dg.HeaderStyle.ForeColor = System.Drawing.Color.White;
		dg.DataSource = dt;
		dg.DataBind();
		dg.RenderControl(htmlWrite);
		//sbResponseString.Append(stringWriter);

		htmlWrite.AddStyleAttribute(System.Web.UI.HtmlTextWriterStyle.FontWeight, "bold");


		sbResponseString.Append("<html xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\"> <head><meta http-equiv=\"Content-Type\" content=\"text/html;charset=windows-1252\"><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>" + "Sheet1" + "</x:Name><x:WorksheetOptions><x:Panes></x:Panes></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head> <body>");
		sbResponseString.Append(stringWriter + "<table width='800' height='100' align='center' style='text-align:center'");
		sbResponseString.Append("</table></body></html>");
		HttpContext.Current.Response.Write(sbResponseString.ToString());
		HttpContext.Current.Response.End();
	}
	protected void gvRegistration_Sorting(object sender, GridViewSortEventArgs e)
	{
		mBindRegisterationGrid(txtSearch.Text, e.SortExpression, e.SortDirection.ToString());
	}










}