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
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public partial class BMDUsers : Pharma.BMD.BLL.ManageUsersBLL
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Master.ToString() != "ASP.blankmasterpage_master")
        {
            InitiateEventsHandlers();
        }
        else
        {
            frmViewUsers.PagerSettings.Visible = false;
        }
        
        if (!IsPostBack)
        {
            int ID = -1;
            //Get the page that contains the ID passed in the query string
            if (!String.IsNullOrEmpty(CurrentQueryStringsValues.ID))
            {
                int.TryParse(CurrentQueryStringsValues.ID, out ID);
                frmViewUsers.PageIndex = GetCertainPageByID(ID, !String.IsNullOrEmpty(CurrentQueryStringsValues.TransType));
                BindUsersView(!String.IsNullOrEmpty(CurrentQueryStringsValues.TransType));

            }
            else
            {
                BindUsersView(false);
            }

            if (frmViewUsers.DataItemCount > 0)
            {
                if (CurrentQueryStringsValues.TransModule.Length == 0)
                    LoadAccountData(ID > -1);
                else
                {
                    int oldRefID = -1;
                    if (CurrentQueryStringsValues.TransType == "Add")
                        oldRefID = ID;
                    else
                        int.TryParse(CurrentQueryStringsValues.oldRefID, out oldRefID);
                    LoadAccountData(ID > -1, CurrentQueryStringsValues.TransModule, oldRefID);
                }
            }
        }
        lblErrors.Text = "";
    }

    private void InitiateEventsHandlers()
    {
        TransButtons ucTransButtons = (TransButtons)Master.FindControl("ucTransButtons");
        ucTransButtons.btnAddEvent += new EventHandler(ucTransButtons_btnAddEvent);
        ucTransButtons.btnEditEvent += new EventHandler(ucTransButtons_btnEditEvent);
        ucTransButtons.btnCancelEvent += new EventHandler(ucTransButtons_btnCancelEvent);
        ucTransButtons.btnSaveEvent += new EventHandler(ucTransButtons_btnSaveEvent);
        ucTransButtons.btnDeleteEvent += new EventHandler(ucTransButtons_btnDeleteEvent);
    }

    private void AdjustTransferMRs(bool Enable)
    {
        if (Enable)
        {
            if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin && ddlAccessLevel.Items[3].Selected)
            {
                if (Roles.GetUsersInRole("SuperUser").Length > 1)
                {
                    ((Button)frmViewUsers.FindControl("btnUnassignAllUsers")).Visible = true;
                    ((DropDownList)frmViewUsers.FindControl("ddlNewSupervisor")).Visible = true;
                    ((DropDownList)frmViewUsers.FindControl("ddlNewSupervisor")).DataSource = SelectAdmins(txtNewUserName.Text);
                    ((DropDownList)frmViewUsers.FindControl("ddlNewSupervisor")).DataBind();
                    if (((DropDownList)frmViewUsers.FindControl("ddlNewSupervisor")).Items.Count > 0)
                        ((DropDownList)frmViewUsers.FindControl("ddlNewSupervisor")).SelectedIndex = 0;
                }
            }
        }
        else
        {
            ((Button)frmViewUsers.FindControl("btnUnassignAllUsers")).Visible = false;
            ((DropDownList)frmViewUsers.FindControl("ddlNewSupervisor")).Visible = false;
        }
    }

    private void LoadAccountData(bool ShowAll, string TransModule, int RefID)
    {
        bool Found = false;
        string[] Infos = TransModule.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        string SelectedUser = "";
        string SelectedUserRole = "";
        string SelectedUserAdmin = "";
        int i;

        for (i = 0; i < Infos.Length; i++)
        {
            if (Infos[i] == "1" || Infos[i] == "8")
            {
                switch (Infos[i + 2])
                {
                    case "SuperAdmin":
                        SelectedUser = Infos[i + 1];
                        SelectedUserRole = "SuperAdmin";
                        Found = true;
                        break;
                    case "Admin":
                        SelectedUser = Infos[i + 1];
                        SelectedUserRole = "Admin";
                        Found = true;
                        break;
                    case "Manager":
                        SelectedUser = Infos[i + 1];
                        SelectedUserRole = "Manager";
                        Found = true;
                        break;
                    case "SuperUser":
                        SelectedUser = Infos[i + 1];
                        SelectedUserRole = "SuperUser";
                        Found = true;
                        break;
                    case "User":
                        SelectedUser = Infos[i + 1];
                        SelectedUserRole = "User";
                        Found = true;
                        break;
                    default:
                        i += 2;
                        break;
                }
                if (Found)
                    break;
            }
        }

        if (SelectedUserRole == "User")
        {
            SelectedUserAdmin = Infos[i + 5];
        }

        LoadAccessLevels(SelectedUser, SelectedUserRole);
        LoadSupervisors(SelectedUser, SelectedUserRole, SelectedUserAdmin);
        AdjustTransferMRs(false);

        if (Found)
        {
            if (SelectedUserRole == "User")
            {
                LoadUsersBricks(RefID/*int.Parse(frmViewUsers.DataKey["EmpID"].ToString())*/, ShowAll, true);
                ((UpdatePanel)frmViewUsers.FindControl("UpdatePanel2")).Visible = true;
            }
            else if (SelectedUserRole == "SuperUser")
            {
                //LoadAssignedUsers(SelectedUser);
                //((UpdatePanel)frmViewUsers.FindControl("UpdatePanel3")).Visible = true;
                LoadUsersBricks(RefID/*int.Parse(frmViewUsers.DataKey["EmpID"].ToString())*/, true, true);
                ((UpdatePanel)frmViewUsers.FindControl("UpdatePanel2")).Visible = true;
                AdjustTransferMRs(false);
            }
        }
        else
        {
            if (Roles.IsUserInRole(txtNewUserName.Text, "User"))
            {
                LoadUsersBricks(RefID/*int.Parse(frmViewUsers.DataKey["EmpID"].ToString())*/, ShowAll, true);
                ((UpdatePanel)frmViewUsers.FindControl("UpdatePanel2")).Visible = true;
            }
            else if (Roles.IsUserInRole(txtNewUserName.Text, "SuperUser"))
            {
                //LoadAssignedUsers(txtNewUserName.Text);
                //((UpdatePanel)frmViewUsers.FindControl("UpdatePanel3")).Visible = true;
                LoadUsersBricks(RefID/*int.Parse(frmViewUsers.DataKey["EmpID"].ToString())*/, false, true);
                ((UpdatePanel)frmViewUsers.FindControl("UpdatePanel2")).Visible = true;
                AdjustTransferMRs(false);
            }
        }

        AdjustDropDownListsSelection();
        AdjustTransButtons(false);
    }

    private void LoadAccountData(bool ShowAll)
    {
        LoadAccessLevels(txtNewUserName.Text);
        LoadSupervisors(txtNewUserName.Text);
        AdjustTransferMRs(false);

        if (Roles.IsUserInRole(txtNewUserName.Text, "User"))
        {
            LoadUsersBricks(int.Parse(frmViewUsers.DataKey["EmpID"].ToString()), ShowAll, true);
            ((UpdatePanel)frmViewUsers.FindControl("UpdatePanel2")).Visible = true;
        }
        else if (Roles.IsUserInRole(txtNewUserName.Text, "SuperUser"))
        {
            //LoadAssignedUsers(txtNewUserName.Text);
            //((UpdatePanel)frmViewUsers.FindControl("UpdatePanel3")).Visible = true;
            LoadUsersBricks(int.Parse(frmViewUsers.DataKey["EmpID"].ToString()), false, true);
            ((UpdatePanel)frmViewUsers.FindControl("UpdatePanel2")).Visible = true;
            AdjustTransferMRs(false);
        }

        AdjustDropDownListsSelection();
        AdjustTransButtons(false);
    }

    private void LoadAccountData()
    {
        LoadAccessLevels(txtNewUserName.Text);
        LoadSupervisors(txtNewUserName.Text);
        AdjustTransferMRs(false);

        if (Roles.IsUserInRole(txtNewUserName.Text, "User"))
        {
            LoadUsersBricks(int.Parse(frmViewUsers.DataKey["EmpID"].ToString()), false, true);
            ((UpdatePanel)frmViewUsers.FindControl("UpdatePanel2")).Visible = true;
        }
        else if (Roles.IsUserInRole(txtNewUserName.Text, "SuperUser"))
        {
            //LoadAssignedUsers(txtNewUserName.Text);
            //((UpdatePanel)frmViewUsers.FindControl("UpdatePanel3")).Visible = true;
            LoadUsersBricks(int.Parse(frmViewUsers.DataKey["EmpID"].ToString()), false, true);
            ((UpdatePanel)frmViewUsers.FindControl("UpdatePanel2")).Visible = true;
            AdjustTransferMRs(false);
        }

        AdjustDropDownListsSelection();
        AdjustTransButtons(false);
    }

    private void LoadAssignedUsers(string AdminName)
    {
        ViewState["gvUsers"] = SelectEmployeesByAdminToSuperAdmin(AdminName);
        gvAssignedUsers.DataSource = ViewState["gvUsers"];
        gvAssignedUsers.DataBind();
    }
    private void BindUsersView(bool ShowAll)
    {
        Session["ShowAll"] = ShowAll;
        frmViewUsers.DataSource = odsUsers;
        frmViewUsers.DataBind();
    }
    private void LoadUsersBricks(int EmpID, bool ShowAll, bool Select)
    {
        ViewState["gvBricks"] = SelectUsersBricks(EmpID, ShowAll, Select);
        gvBricks.DataSource = ViewState["gvBricks"];
        gvBricks.DataBind();
        txtExpireDate.Attributes.Add("ReadOnly", "ReadOnly");
    }

    protected void frmViewUsers_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {
        frmViewUsers.PageIndex = e.NewPageIndex;
        BindUsersView(false);
        LoadAccountData();
    }

    private void AdjustDropDownListsSelection()
    {
        ((DropDownList)frmViewUsers.FindControl("ddlNewTitle")).SelectedValue = ((TextBox)frmViewUsers.FindControl("txtNewTitle")).Text;

    }
    private void LoadAccessLevels(string SelectedUser, string SelectedUserRole)
    {
        bool Found = false;
        ddlAccessLevel.SelectedIndex = -1;
        // SuperAdmin
        ddlAccessLevel.Items[0].Enabled = true;
        ddlAccessLevel.Items[1].Enabled = true;
        ddlAccessLevel.Items[2].Enabled = true;
        ddlAccessLevel.Items[3].Enabled = true;
        ddlAccessLevel.Items[4].Enabled = true;

        switch (SelectedUserRole)
        {
            case "SuperAdmin":
                ddlAccessLevel.Items[0].Selected = true;
                Found = true;
                break;
            case "Admin":
                ddlAccessLevel.Items[1].Selected = true;
                Found = true;
                break;
            case "Manager":
                ddlAccessLevel.Items[2].Selected = true;
                Found = true;
                break;
            case "SuperUser":
                ddlAccessLevel.Items[3].Selected = true;
                Found = true;
                break;
            case "User":
                ddlAccessLevel.Items[4].Selected = true;
                Found = true;
                break;
            default:
                break;
        }

        if (!Found)
        {
            ArrayList SelectedUserRoles = new ArrayList();
            SelectedUserRoles.AddRange(Roles.GetRolesForUser(SelectedUser));

            if (SelectedUserRoles.Contains("SuperAdmin"))
                ddlAccessLevel.Items[0].Selected = true;
            else if (SelectedUserRoles.Contains("Admin"))
                ddlAccessLevel.Items[1].Selected = true;
            else if (SelectedUserRoles.Contains("Manager"))
                ddlAccessLevel.Items[2].Selected = true;
            else if (SelectedUserRoles.Contains("SuperUser"))
                ddlAccessLevel.Items[3].Selected = true;
            else if (SelectedUserRoles.Contains("User"))
                ddlAccessLevel.Items[4].Selected = true;
        }
    }
    private void LoadAccessLevels(string SelectedUser)
    {
        ddlAccessLevel.SelectedIndex = -1;
        // SuperAdmin
        ddlAccessLevel.Items[0].Enabled = true;
        ddlAccessLevel.Items[1].Enabled = true;
        ddlAccessLevel.Items[2].Enabled = true;
        ddlAccessLevel.Items[3].Enabled = true;
        ddlAccessLevel.Items[4].Enabled = true;
        
        ArrayList SelectedUserRoles = new ArrayList();
        SelectedUserRoles.AddRange(Roles.GetRolesForUser(SelectedUser));

        if (SelectedUserRoles.Contains("SuperAdmin"))
            ddlAccessLevel.Items[0].Selected = true;
        else if (SelectedUserRoles.Contains("Admin"))
            ddlAccessLevel.Items[1].Selected = true;
        else if (SelectedUserRoles.Contains("Manager"))
            ddlAccessLevel.Items[2].Selected = true;
        else if (SelectedUserRoles.Contains("SuperUser"))
            ddlAccessLevel.Items[3].Selected = true;
        else if (SelectedUserRoles.Contains("User"))
            ddlAccessLevel.Items[4].Selected = true;
   
    }
    private void LoadSupervisors(string SelectedUser, string SelectedUserRole, string SelectedUserAdmin)
    {
        bool Found = false;
        ddlSupervisor.Items.Clear();
        ddlSupervisor.Visible = true;
        lblSupervisor.Visible = true;
        // SuperAdmin
        if (ddlAccessLevel.SelectedValue == "User")
        {
            ddlSupervisor.DataSource = SelectAdmins();
            ddlSupervisor.DataTextField = "EmpName";
            ddlSupervisor.DataValueField = "EmpID";
            ddlSupervisor.DataBind();

            if (SelectedUserRole == "User")
            {
                ddlSupervisor.SelectedValue = SelectEmpIDByUserName(SelectedUserAdmin, true).ToString();
                Found = true;
            }

            if (!Found)
            {
                if (Roles.IsUserInRole(SelectedUser, "User"))
                    ddlSupervisor.SelectedValue = SelectEmpIDByUserName(SelectedUserAdmin, true).ToString();
            }
        }
        else
        {
            ddlSupervisor.Visible = false;
            lblSupervisor.Visible = false;
        }
    }
    private void LoadSupervisors(string SelectedUser)
    {
        ddlSupervisor.Items.Clear();
        ddlSupervisor.Visible = true;
        lblSupervisor.Visible = true;
        // SuperAdmin
        if (ddlAccessLevel.SelectedValue == "User")
        {
            ddlSupervisor.DataSource = SelectAdmins();
            ddlSupervisor.DataTextField = "EmpName";
            ddlSupervisor.DataValueField = "EmpID";
            ddlSupervisor.DataBind();
            if (Roles.IsUserInRole(SelectedUser, "User"))
                ddlSupervisor.SelectedValue = GetAdminEmpIDForUser(SelectedUser);
        }
        else
        {
            ddlSupervisor.Visible = false;
            lblSupervisor.Visible = false;
        }
    }


    #region Page Controls Handler


    private void AdjustTransButtons(bool Flag)
    {
        if (this.Master.ToString() != "ASP.blankmasterpage_master")
        {
            TransButtons ucTransButtons = (TransButtons)Master.FindControl("ucTransButtons");
            ((ImageButton)ucTransButtons.FindControl("btnCancel")).Visible = Flag;
            ((ImageButton)ucTransButtons.FindControl("btnSave")).Visible = Flag;
            ((ImageButton)ucTransButtons.FindControl("btnAdd")).Visible = !Flag;
            ((ImageButton)ucTransButtons.FindControl("btnEdit")).Visible = !Flag;
        }
    }

    private void ResetFormtxtboxes()
    {
        ((TextBox)frmViewUsers.FindControl("txtNewEmployeeName")).Text = "";
        ((TextBox)frmViewUsers.FindControl("txtNewUserName")).Text = "";
        ((TextBox)frmViewUsers.FindControl("txtNewComment")).Text = "";
        ((TextBox)frmViewUsers.FindControl("txtNationalID")).Text = "";
        ((TextBox)frmViewUsers.FindControl("txtAddress")).Text = "";
        ((TextBox)frmViewUsers.FindControl("txtMobile")).Text = "";
        ((TextBox)frmViewUsers.FindControl("txtEmail")).Text = "";
        ((TextBox)frmViewUsers.FindControl("txtHomeTel")).Text = "";
        ((CheckBox)frmViewUsers.FindControl("cbxNewActive")).Checked = false;


    }

    protected void AdjustReadOnlyFormStatus(bool Flag)
    {
        ((TextBox)frmViewUsers.FindControl("txtNewEmployeeName")).ReadOnly = Flag;
        ((TextBox)frmViewUsers.FindControl("txtNationalID")).ReadOnly = Flag;
        ((TextBox)frmViewUsers.FindControl("txtNewUserName")).ReadOnly = ViewState["SaveMode"].ToString() == "Edit";
        ((TextBox)frmViewUsers.FindControl("txtNewComment")).ReadOnly = Flag;
        ((TextBox)frmViewUsers.FindControl("txtAddress")).ReadOnly = Flag;
        ((TextBox)frmViewUsers.FindControl("txtMobile")).ReadOnly = Flag;
        ((TextBox)frmViewUsers.FindControl("txtEmail")).ReadOnly = Flag;
        ((TextBox)frmViewUsers.FindControl("txtHomeTel")).ReadOnly = Flag;
        ((DropDownList)frmViewUsers.FindControl("ddlNewTitle")).Enabled = !Flag;
        ((DropDownList)frmViewUsers.FindControl("ddlAccessLevel")).Enabled = !Flag;
        ((DropDownList)frmViewUsers.FindControl("ddlSupervisor")).Enabled = !Flag;
        ((CheckBox)frmViewUsers.FindControl("cbxNewActive")).Enabled = !Flag;

        ((Label)frmViewUsers.FindControl("lblPassword")).Visible = (!Flag && txtNewUserName.Text == Session["User"].ToString()) || (!Flag && ViewState["SaveMode"].ToString() == "Add");
        ((Label)frmViewUsers.FindControl("lblConfirmPassword")).Visible = (!Flag && txtNewUserName.Text == Session["User"].ToString()) || (!Flag && ViewState["SaveMode"].ToString() == "Add");
        ((TextBox)frmViewUsers.FindControl("txtNewPassword1")).Visible = (!Flag && txtNewUserName.Text == Session["User"].ToString()) || (!Flag && ViewState["SaveMode"].ToString() == "Add");
        ((TextBox)frmViewUsers.FindControl("txtNewPassword2")).Visible = (!Flag && txtNewUserName.Text == Session["User"].ToString()) || (!Flag && ViewState["SaveMode"].ToString() == "Add");

        ((Label)frmViewUsers.FindControl("lblResetPassword")).Visible = ViewState["SaveMode"].ToString() == "Edit" && !Flag;
        ((CheckBox)frmViewUsers.FindControl("chkResetPassword")).Visible = ViewState["SaveMode"].ToString() == "Edit" && !Flag;
    }

    private void EnableGridview(GridView GridviewName, bool Flag, bool Reset, bool NewEntry)
    {
        foreach (GridViewRow row in GridviewName.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                ((CheckBox)row.Cells[1].Controls[1]).Enabled = Flag;
                //If the grid view is Assigned Users and the check box is checked, disable the check box
                if (GridviewName.ID == "gvAssignedUsers")
                {
                    ((CheckBox)row.Cells[1].Controls[1]).Enabled = !(((CheckBox)row.Cells[1].Controls[1]).Checked && ViewState["SaveMode"].ToString() == "Edit");
                }
                if (Reset)
                {
                    ((CheckBox)row.Cells[1].Controls[1]).Checked = Reset;
                }
                if (NewEntry)
                {
                    row.BackColor = System.Drawing.Color.Transparent;
                    ((CheckBox)row.Cells[1].Controls[1]).Checked = Reset;
                }
            }
        }

    }

   
    #endregion


    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        string[] Names = new string[0];
        string ErrMsg = "";
        BMDUsers currentPage = new BMDUsers();
        Names = currentPage.GetAllEntitiesNames("Employees", prefixText, out ErrMsg);
        return Names;
    }
    protected void txtSearchName_TextChanged(object sender, EventArgs e)
    {
        string EmpName = ((TextBox)frmViewUsers.FindControl("txtSearchName")).Text;
        frmViewUsers.PageIndex = GetCertainPageByName(EmpName, false);
        BindUsersView(false);
        LoadAccountData();
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList2(string prefixText, int count, string contextKey)
    {
        string[] Names = new string[0];
        string ErrMsg = "";
        BMDUsers currentPage = new BMDUsers();
        Names = currentPage.GetAllEntitiesNames("Users", prefixText, out ErrMsg);
        return Names;
    }
    protected void txtSearchUserName_TextChanged(object sender, EventArgs e)
    {
        string UserName = ((TextBox)frmViewUsers.FindControl("txtSearchUserName")).Text;
        frmViewUsers.PageIndex = GetCertainPageByUserName(UserName, false);
        BindUsersView(false);
        LoadAccountData();
    }

    #region Buttons Transactions Events

    protected void ucTransButtons_btnEditEvent(object sender, EventArgs e)
    {
        ViewState["SaveMode"] = "Edit";
        AdjustReadOnlyFormStatus(false);
        AdjustTransButtons(true);
        EnableGridview(gvBricks, true, false, false);
        EnableGridview(gvAssignedUsers, true, false, false);
        AdjustTransferMRs(true);
        lblPassword.Text = "Old Password:";
        lblConfirmPassword.Text = " New Password:";
        //
        if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
        {
            if (gvBricks.SelectedRow != null)
            {
                rblExpireDate.Enabled = true;
                imgExpireDate.Enabled = true;
                imgExpireDate.AlternateText = "Pick a date";
                (((CheckBox)gvBricks.SelectedRow.FindControl("cbxBrickSelected")).Enabled) = false;
            }
        }
    }
    protected void ucTransButtons_btnAddEvent(object sender, EventArgs e)
    {
        ViewState["SaveMode"] = "Add";
        AdjustReadOnlyFormStatus(false);
        AdjustTransButtons(true);
        ResetFormtxtboxes();
        EnableGridview(gvBricks, true, false, true);
        EnableGridview(gvAssignedUsers, true, false, true);
        ddlAccessLevel_SelectedIndexChanged(null, null);
        ((Button)frmViewUsers.FindControl("btnUnassignAllUsers")).Visible = false;
        ((DropDownList)frmViewUsers.FindControl("ddlNewSupervisor")).Visible = false;

        lblPassword.Text = "Password:";
        lblConfirmPassword.Text = " Confirm Password:";
    }
    protected void ucTransButtons_btnCancelEvent(object sender, EventArgs e)
    {
        BindUsersView(false);
        LoadAccountData();
        //
        AdjustReadOnlyFormStatus(true);
        AdjustDropDownListsSelection();
        AdjustTransButtons(false);

        AdjustTransferMRs(false);
    }
    protected void ucTransButtons_btnSaveEvent(object sender, EventArgs e)
    {
        int EmpID = (int.Parse(frmViewUsers.DataKey["EmpID"].ToString()));
        string txtUserName = ((TextBox)frmViewUsers.FindControl("txtNewUserName")).Text;
        string txtEmployeeName = ((TextBox)frmViewUsers.FindControl("txtNewEmployeeName")).Text;
        Regex rx = new Regex("^(?!((?i)user|superuser|manager|admin|superadmin)$)", RegexOptions.Compiled);
        if (!rx.IsMatch(txtUserName) || !rx.IsMatch(txtEmployeeName))
        {
            lblErrors.Text = "\"" + (rx.IsMatch(txtUserName)? txtEmployeeName : txtUserName) + "\" is Reserved Word.<br/>";
            return;
        }
        string txtComment = ((TextBox)frmViewUsers.FindControl("txtNewComment")).Text;
        decimal NationalID = decimal.Parse(((TextBox)frmViewUsers.FindControl("txtNationalID")).Text);
        string txtAddress = ((TextBox)frmViewUsers.FindControl("txtAddress")).Text;
        string txtMobile = ((TextBox)frmViewUsers.FindControl("txtMobile")).Text;
        string txtEmail = ((TextBox)frmViewUsers.FindControl("txtEmail")).Text;
        string txtHomeTel = ((TextBox)frmViewUsers.FindControl("txtHomeTel")).Text;
        //
        int TitleID = int.Parse(((DropDownList)frmViewUsers.FindControl("ddlNewTitle")).SelectedValue);
        string txtAccessLevel = ((DropDownList)frmViewUsers.FindControl("ddlAccessLevel")).SelectedValue;
        int SuperVisorID = -1;
        string txtSupervisorName = "";
        if (((DropDownList)frmViewUsers.FindControl("ddlSupervisor")).Visible)
        {
            SuperVisorID = int.Parse(((DropDownList)frmViewUsers.FindControl("ddlSupervisor")).SelectedValue);
            txtSupervisorName = ((DropDownList)frmViewUsers.FindControl("ddlSupervisor")).SelectedItem.Text;
        }

        bool IsActive = ((CheckBox)frmViewUsers.FindControl("cbxNewActive")).Checked;
        if (ViewState["SaveMode"].ToString() == "Add")
        {
            if (String.IsNullOrEmpty(txtNewPassword1.Text.Trim()))
            {
                lblErrors.Text = "Password can't be empty.<br/>";
                return;
            }

            if (txtNewPassword1.Text.Trim() != txtNewPassword2.Text.Trim())
            {
                lblErrors.Text = "Password doesn't match.<br/>";
                return;
            }

            if (txtNewPassword1.Text.Trim().Length < 2)
            {
                lblErrors.Text = "Password length must be more than 2 chars.<br/>";
                return;
            }

            StringBuilder str = new StringBuilder(" 6 ");
            if (CurrentUserInfo.UserRole == UsersRoles.Admin)
            {
                // Create Membership
                str.Append(txtUserName);
                str.Append(" ");
                str.Append(txtNewPassword1.Text);

                // Add Roles
                str.Append(" 1 ");
                str.Append(txtUserName);
                str.Append(" ");
                str.Append(txtAccessLevel);

                if (txtAccessLevel == "SuperUser")
                {
                    str.Append(" 0 ");
                    str.Append(txtUserName);

                    str.Append(" 1 ");
                    str.Append(txtUserName);
                    str.Append(" ");
                    str.Append(txtUserName);
                }
                if (txtAccessLevel == "User")
                {
                    str.Append(" 1 ");
                    str.Append(txtUserName);
                    str.Append(" ");
                    str.Append(SelectUserNameByEmpName(txtSupervisorName, false));
                }
            }

            int NewEmpID = 0;
            int Result = AddUser(txtUserName, txtEmployeeName, TitleID, IsActive, NationalID, txtAddress,
                txtMobile, txtEmail, txtHomeTel, txtComment, str.ToString(), out NewEmpID);

            if (Result == -1)
            {
                // Error
                lblErrors.Text = "Failed to perform this operation... National ID already exists in the database !";
            }
            else if (Result == 0)
            {
                // Error
                lblErrors.Text = "Failed to perform this operation... User Name already exists in the database !";
            }
            else if (Result == 1)
            {
                // Added //

                // Add membership
                Membership.CreateUser(txtUserName, txtNewPassword1.Text);
                // Add roles
                Roles.AddUserToRole(txtUserName, txtAccessLevel);
                if (txtAccessLevel == "SuperUser")
                {
                    Roles.CreateRole(txtUserName);
                    Roles.AddUserToRole(txtUserName, txtUserName);
                }
                if (txtAccessLevel == "User")
                {
                    Roles.AddUserToRole(txtUserName, SelectUserNameByEmpName(txtSupervisorName, false));
                }

                // Update the Rest Ttansactions for Assigned Users and Users Bricks //
                SaveChangedValues(NewEmpID, txtAccessLevel, "SaveAdminUsers", GetChangedValues("Add", ((DataTable)ViewState["gvUsers"]), "Selected", gvAssignedUsers, "cbxUserSelected", 1));
                SaveChangedValues(NewEmpID, txtAccessLevel, "SaveUserBricks", GetChangedValues("Add", ((DataTable)ViewState["gvBricks"]), "Selected", gvBricks, "cbxBrickSelected", 1));

                // Reload Data //
                frmViewUsers.PageIndex = GetCertainPageByID(NewEmpID, false);
                BindUsersView(false);
                LoadAccountData();
            }
            else if (Result == 2)
            {
                // Added Requested // Pending Request
                // Update the Rest Ttansactions for Assigned Users and Users Bricks //
                SaveChangedValues(NewEmpID, txtAccessLevel, "SaveAdminUsers", GetChangedValues("Add", ((DataTable)ViewState["gvUsers"]), "Selected", gvAssignedUsers, "cbxUserSelected", 1));
                SaveChangedValues(NewEmpID, txtAccessLevel, "SaveUserBricks", GetChangedValues("Add", ((DataTable)ViewState["gvBricks"]), "Selected", gvBricks, "cbxBrickSelected", 1));
                lblErrors.Text = "Your request for adding new employee is in Pending phase until Acceptance from your Manager";
            }

        }
        else if (ViewState["SaveMode"].ToString() == "Edit")
        {
            StringBuilder str = new StringBuilder();
            if (CurrentUserInfo.UserRole == UsersRoles.Admin)
            {
                string MembershipAndRolesInfo = "";
                string retValue = RequestUpdateUserPermissions(txtUserName, txtAccessLevel, txtSupervisorName, out MembershipAndRolesInfo);
                if (!String.IsNullOrEmpty(retValue))
                {
                    lblErrors.Text = retValue;
                    return;
                }
                str.Append(MembershipAndRolesInfo);

                //Reset Password
                if (chkResetPassword.Checked)
                {
                    str.Append(" 5 ");
                    str.Append(txtUserName);
                }
                //Change Password
                if (!String.IsNullOrEmpty(txtNewPassword1.Text.Trim())/* && !String.IsNullOrEmpty(txtNewPassword2.Text.Trim())*/)
                {
                    if (txtNewPassword1.Text.Trim() != txtNewPassword2.Text.Trim())
                    {
                        lblErrors.Text = "Password doesn't match.<br/>";
                        return;
                    }

                    if (txtNewPassword1.Text.Trim().Length < 2)
                    {
                        lblErrors.Text = "Password length must be more than 2 chars.<br/>";
                        return;
                    }

                    str.Append(" 4 ");
                    str.Append(txtUserName);
                    str.Append(" ");
                    str.Append(txtNewPassword1.Text);
                    str.Append(" ");
                    str.Append(txtNewPassword2.Text);
                }
                //else if ((String.IsNullOrEmpty(txtNewPassword1.Text.Trim()) && !String.IsNullOrEmpty(txtNewPassword2.Text.Trim())) || (!String.IsNullOrEmpty(txtNewPassword1.Text.Trim()) && String.IsNullOrEmpty(txtNewPassword2.Text.Trim())))
                //{
                //    lblErrors.Text = "Can't update password.<br/>";
                //    return;
                //}
            }
            string Msg = "";
            int result = UpdateUser(EmpID, txtUserName, txtEmployeeName, TitleID, IsActive, NationalID, txtAddress,
                txtMobile, txtEmail, txtHomeTel, txtComment, str.ToString(), out Msg);
            if (result == 0)
            {
                // Failed
                lblErrors.Text = (Msg.Length > 0) ? Msg : "Failed to Edit";
            }
            if (result == 1)
            {
                // Updated //
                string retValue = UpdateUserPermissions(txtUserName, txtAccessLevel, txtSupervisorName);
                if (!String.IsNullOrEmpty(retValue))
                {
                    lblErrors.Text = retValue;
                    return;
                }
                //Reset Password
                if (chkResetPassword.Checked)
                {
                    MembershipUser usr = Membership.GetUser(txtUserName);
                    string autoGeneratedPassword = usr.ResetPassword();
                    usr.ChangePassword(autoGeneratedPassword, "123456");
                }
                //Change Password
                if (!String.IsNullOrEmpty(txtNewPassword1.Text.Trim()) && !String.IsNullOrEmpty(txtNewPassword2.Text.Trim()))
                {
                    MembershipUser msu = Membership.GetUser(txtUserName);

                    if (msu.ChangePassword(txtNewPassword1.Text, txtNewPassword2.Text))
                        lblErrors.Text = "Password updated successfully!<br/>";
                    else
                    {
                        lblErrors.Text = "Can't update password.<br/>";
                        return;
                    }
                }
                else if ((String.IsNullOrEmpty(txtNewPassword1.Text.Trim()) && !String.IsNullOrEmpty(txtNewPassword2.Text.Trim())) || (!String.IsNullOrEmpty(txtNewPassword1.Text.Trim()) && String.IsNullOrEmpty(txtNewPassword2.Text.Trim())))
                {
                    lblErrors.Text = "Can't update password.<br/>";
                    return;
                }
                // Update the Rest of Transaction for Assigned Users and Users Bricks //
                //SaveChangedValues(EmpID, "SaveAdminUsers", GetChangedValues("Edit", ((DataTable)ViewState["gvUsers"]), "Selected", gvAssignedUsers, "cbxUserSelected", 1));
                SaveChangedValues(EmpID, txtAccessLevel, "SaveUserBricks", GetChangedValues("Edit", ((DataTable)ViewState["gvBricks"]), "Selected", gvBricks, "cbxBrickSelected", 1));
                // Update if selected brick expire date is edited // 
                SaveBrickExpireDate();
                // Reload Data //
                BindUsersView(false);
                LoadAccountData();
            }
            else if (result == 2)
            {
                // Updated Requested // Pending Request
                // Update the Rest Ttansactions for Assigned Users and Users Bricks //
                //SaveChangedValues(EmpID, "SaveAdminUsers", GetChangedValues("Edit", ((DataTable)ViewState["gvUsers"]), "Selected", gvAssignedUsers, "cbxUserSelected", 1));
                SaveChangedValues(EmpID, txtAccessLevel, "SaveUserBricks", GetChangedValues("Edit", ((DataTable)ViewState["gvBricks"]), "Selected", gvBricks, "cbxBrickSelected", 1));
                // Reload Data //
                BindUsersView(false);
                LoadAccountData();
                lblErrors.Text = "Your request for Updating employee is in Pending phase until Acceptance from your Manager";
            }
        }

        AdjustTransButtons(false);
        AdjustReadOnlyFormStatus(true);
        AdjustTransferMRs(false);
    }
    protected void ucTransButtons_btnDeleteEvent(object sender, EventArgs e)
    {

        int EmpID = (int.Parse(frmViewUsers.DataKey["EmpID"].ToString()));
        string UserName = ((TextBox)frmViewUsers.FindControl("txtNewUserName")).Text;
        string AccessLevel = ((DropDownList)frmViewUsers.FindControl("ddlAccessLevel")).SelectedValue;
        string SupervisorName = "";
        if (((DropDownList)frmViewUsers.FindControl("ddlSupervisor")).Visible)
            SupervisorName = ((DropDownList)frmViewUsers.FindControl("ddlSupervisor")).SelectedItem.Text;

        if (UserName == AuthenticateUser())
        {
            lblErrors.Text = "Can't change current user permissions";
            return;
        }

        string SelectedUserRole = "";
        if (!Roles.IsUserInRole(UserName, "SuperUser") && !Roles.IsUserInRole(UserName, "User"))
            SelectedUserRole = Roles.GetRolesForUser(UserName)[0];
        else
        {
            if (Roles.IsUserInRole(UserName, "SuperUser"))
                SelectedUserRole = "SuperUser";
            else
            {
                if (IsEmpHasBricks(EmpID))
                {
                    lblErrors.Text = "You must first unassign all bricks belong to this user.";
                    return;
                }
                SelectedUserRole = "User";
            }
        }

        StringBuilder str = new StringBuilder();
        if (CurrentUserInfo.UserRole == UsersRoles.Admin)
        {
            if (SelectedUserRole != "SuperUser" && SelectedUserRole != "User")
            {
                str.Append(" 2 ");
                str.Append(UserName);
                str.Append(" ");
                str.Append(SelectedUserRole);
            }
            else
            {
                if (SelectedUserRole == "SuperUser")
                {
                    // A change already has occured
                    if (Roles.GetUsersInRole("SuperUser").Length > 1)
                    {
                        if (Roles.GetUsersInRole(UserName).Length == 1)
                        {
                            str.Append(" 2 ");
                            str.Append(UserName);
                            str.Append(" ");
                            str.Append(UserName);

                            str.Append(" 3 ");
                            str.Append(UserName);

                            str.Append(" 2 ");
                            str.Append(UserName);
                            str.Append(" SuperUser");
                        }
                        else
                        {
                            lblErrors.Text = "You must first unassign all users belong to this admin and assign them to another admin.";
                            return;
                        }
                    }
                    else
                    {
                        lblErrors.Text = "At least one superuser must exist.";
                        return;
                    }
                }
                else
                {
                    // Normal User
                    // A change already has occured
                    if (IsEmpHasBricks(EmpID))
                    {
                        lblErrors.Text = "You must first unassign all bricks belong to this user.";
                        return;
                    }
                    else
                    {
                        str.Append(" 2 ");
                        str.Append(UserName);
                        str.Append(" ");
                        str.Append(GetAdminRoleNameForUser(UserName));

                        str.Append(" 2 ");
                        str.Append(UserName);
                        str.Append(" User");
                    }
                }
            }

            str.Append(" 7 ");
            str.Append(UserName);
        }
        else
        {
            if (SelectedUserRole != "SuperUser" && SelectedUserRole != "User")
            {
                Roles.RemoveUserFromRole(UserName, SelectedUserRole);
            }
            else
            {
                if (SelectedUserRole == "SuperUser")
                {
                    // A change already has occured
                    if (Roles.GetUsersInRole("SuperUser").Length > 1)
                    {
                        if (Roles.GetUsersInRole(UserName).Length == 1)
                        {
                            Roles.RemoveUserFromRole(UserName, UserName);
                            Roles.DeleteRole(UserName);
                            Roles.RemoveUserFromRole(UserName, "SuperUser");
                        }
                        else
                        {
                            lblErrors.Text = "You must first unassign all users belong to this admin and assign them to another admin.";
                            return;
                        }
                    }
                    else
                    {
                        lblErrors.Text = "At least one superuser must exist.";
                        return;
                    }
                }
                else
                {
                    // Normal User
                    // A change already has occured
                    Roles.RemoveUserFromRole(UserName, GetAdminRoleNameForUser(UserName));
                    Roles.RemoveUserFromRole(UserName, "User");
                }
            }

            Membership.DeleteUser(UserName);
        }

        int result = DeleteUser(EmpID, str.ToString());
        if (result == 0)
        {
            // Failed
            lblErrors.Text = "Failed to delete";
        }
        else if (result == 1)
        {
            // Direct Delete //
            //// Reload Data after record is deleted//
            if (frmViewUsers.PageIndex > 1)
                frmViewUsers.PageIndex--;

            BindUsersView(false);
            LoadAccountData();
        }
        else
        {
            // Delete Requested // Pending Request
            BindUsersView(false);
            LoadAccountData();
            lblErrors.Text = "Your request for Delete employee is in Pending phase until Acceptance from your Manager";
        }

    }

    private string UpdateUserPermissions(string UserName, string AccessLevel, string Supervisor)
    {
        //if (UserName == CurrentUserInfo.UserName)
        //    return "Can't change current user permissions";

        string SelectedUserRole;
        if (!Roles.IsUserInRole(UserName, "SuperUser") && !Roles.IsUserInRole(UserName, "User"))
            SelectedUserRole = Roles.GetRolesForUser(UserName)[0];
        else
        {
            if (Roles.IsUserInRole(UserName, "SuperUser"))
                SelectedUserRole = "SuperUser";
            else
                SelectedUserRole = "User";
        }

        if (SelectedUserRole != "SuperUser" && SelectedUserRole != "User")
        {
            // SuperAdmin
            if (AccessLevel != SelectedUserRole)
            {
                // A change already has occured
                if (UserName == CurrentUserInfo.UserName)
                    return "Can't change current user permissions";

                Roles.RemoveUserFromRole(UserName, SelectedUserRole);
                Roles.AddUserToRole(UserName, AccessLevel);

                if (AccessLevel == "SuperUser")
                {
                    Roles.CreateRole(UserName);
                    Roles.AddUserToRole(UserName, UserName);
                }
                else if (AccessLevel == "User")
                {
                    Roles.AddUserToRole(UserName, SelectUserNameByEmpName(Supervisor, false));
                }
            }
        }
        else
        {
            if (SelectedUserRole == "SuperUser")
            {
                // Admin
                if (AccessLevel != "SuperUser")
                {
                    // A change already has occured
                    if (UserName == CurrentUserInfo.UserName)
                        return "Can't change current user permissions";

                    if (Roles.GetUsersInRole("SuperUser").Length > 1)
                    {
                        if (AccessLevel != "User")
                        {
                            if (Roles.GetUsersInRole(UserName).Length == 1)
                            {
                                Roles.RemoveUserFromRole(UserName, UserName);
                                Roles.DeleteRole(UserName);
                                Roles.RemoveUserFromRole(UserName, "SuperUser");
                                //
                                Roles.AddUserToRole(UserName, AccessLevel);
                            }
                            else
                            {
                                return "You must first unassign all users belong to this admin and assign them to another admin.";
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(Supervisor))
                            {
                                string[] usersUnderDowngradedAdmin = Roles.GetUsersInRole(UserName);//I got them to transfer them to the admin of their admin
                                Roles.RemoveUsersFromRole(usersUnderDowngradedAdmin, UserName);
                                Roles.DeleteRole(UserName);
                                Roles.RemoveUserFromRole(UserName, "SuperUser");
                                //
                                Roles.AddUserToRole(UserName, "User");
                                Roles.AddUsersToRole(usersUnderDowngradedAdmin, SelectUserNameByEmpName(Supervisor, false));
                            }
                        }

                    }
                    else
                        return "At least one super user must exist.";
                }
            }
            else
            {
                // Normal User
                if (AccessLevel != "User")
                {
                    // A change already has occured
                    if (UserName == CurrentUserInfo.UserName)
                        return "Can't change current user permissions";

                    if (IsEmpHasBricks(int.Parse(frmViewUsers.DataKey["EmpID"].ToString())))
                    {
                        return "You must first unassign all bricks belong to this user.";
                    }
                    else
                    {
                        Roles.RemoveUserFromRole(UserName, GetAdminRoleNameForUser(UserName));
                        Roles.RemoveUserFromRole(UserName, "User");
                        if (AccessLevel != "SuperUser")
                        {
                            Roles.AddUserToRole(UserName, AccessLevel);
                        }
                        else
                        {
                            Roles.AddUserToRole(UserName, "SuperUser");
                            Roles.CreateRole(UserName);
                            Roles.AddUserToRole(UserName, UserName);
                        }
                    }
                }
                else
                {
                    if (Supervisor != GetAdminEmpNameForUser(UserName))
                    {
                        // Change user's supervisor
                        if (UserName == CurrentUserInfo.UserName)
                            return "Can't change current user permissions";

                        DeAssignAllBricksFromUser(int.Parse(frmViewUsers.DataKey["EmpID"].ToString()));
                        Roles.RemoveUserFromRole(UserName, GetAdminRoleNameForUser(UserName));
                        Roles.AddUserToRole(UserName, SelectUserNameByEmpName(Supervisor, false));
                    }
                }
            }
        }

        return "";
    }
    private string RequestUpdateUserPermissions(string UserName, string AccessLevel, string Supervisor, out string MembershipAndRolesInfo)
    {
        MembershipAndRolesInfo = "";

        //if (UserName == CurrentUserInfo.UserName)
        //    return "Can't change current user permissions";

        StringBuilder str = new StringBuilder();

        string SelectedUserRole;
        if (!Roles.IsUserInRole(UserName, "SuperUser") && !Roles.IsUserInRole(UserName, "User"))
            SelectedUserRole = Roles.GetRolesForUser(UserName)[0];
        else
        {
            if (Roles.IsUserInRole(UserName, "SuperUser"))
                SelectedUserRole = "SuperUser";
            else
                SelectedUserRole = "User";
        }

        if (SelectedUserRole != "SuperUser" && SelectedUserRole != "User")
        {
            // SuperAdmin
            if (AccessLevel != SelectedUserRole)
            {
                // A change already has occured
                if (UserName == CurrentUserInfo.UserName)
                    return "Can't change current user permissions";
                str.Append(" 2 ");
                str.Append(UserName);
                str.Append(" ");
                str.Append(SelectedUserRole);
                
                str.Append(" 1 ");
                str.Append(UserName);
                str.Append(" ");
                str.Append(AccessLevel);

                if (AccessLevel == "SuperUser")
                {
                    str.Append(" 0 ");
                    str.Append(UserName);
                    
                    str.Append(" 1 ");
                    str.Append(UserName);
                    str.Append(" ");
                    str.Append(UserName);
                }
                else if (AccessLevel == "User")
                {
                    str.Append(" 1 ");
                    str.Append(UserName);
                    str.Append(" ");
                    str.Append(SelectUserNameByEmpName(Supervisor, false));
                }
            }
            else
            {
                str.Append(" 8 ");
                str.Append(UserName);
                str.Append(" ");
                str.Append(SelectedUserRole);
            }
        }
        else
        {
            if (SelectedUserRole == "SuperUser")
            {
                // Admin
                if (AccessLevel != "SuperUser")
                {
                    // A change already has occured
                    if (UserName == CurrentUserInfo.UserName)
                        return "Can't change current user permissions";

                    if (Roles.GetUsersInRole("SuperUser").Length > 1)
                    {
                        if (AccessLevel != "User")
                        {
                            if (Roles.GetUsersInRole(UserName).Length == 1)
                            {
                                str.Append(" 2 ");
                                str.Append(UserName);
                                str.Append(" ");
                                str.Append(UserName);
                                
                                str.Append(" 3 ");
                                str.Append(UserName);
                                
                                str.Append(" 2 ");
                                str.Append(UserName);
                                str.Append(" SuperUser");
                                //
                                str.Append(" 1 ");
                                str.Append(UserName);
                                str.Append(" ");
                                str.Append(AccessLevel);
                            }
                            else
                            {
                                return "You must first unassign all users belong to this admin and assign them to another admin.";
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(Supervisor))
                            {
                                string[] usersUnderDowngradedAdmin = Roles.GetUsersInRole(UserName);//I got them to transfer them to the admin of their admin
                                foreach (string userUnderDowngradedAdmin in usersUnderDowngradedAdmin)
                                {
                                    str.Append(" 2 ");
                                    str.Append(userUnderDowngradedAdmin);
                                    str.Append(" ");
                                    str.Append(UserName);
                                }
                                
                                str.Append(" 3 ");
                                str.Append(UserName);
                                
                                str.Append(" 2 ");
                                str.Append(UserName);
                                str.Append(" SuperUser");
                                //
                                str.Append(" 1 ");
                                str.Append(UserName);
                                str.Append(" User");

                                foreach (string userUnderDowngradedAdmin in usersUnderDowngradedAdmin)
                                {
                                    str.Append(" 1 ");
                                    str.Append(userUnderDowngradedAdmin);
                                    str.Append(" ");
                                    str.Append(SelectUserNameByEmpName(Supervisor, false));
                                }
                            }
                        }

                    }
                    else
                        return "At least one super user must exist.";
                }
                else
                {
                    str.Append(" 8 ");
                    str.Append(UserName);
                    str.Append(" ");
                    str.Append(SelectedUserRole);
                }
            }
            else
            {
                // Normal User
                if (AccessLevel != "User")
                {
                    // A change already has occured
                    if (UserName == CurrentUserInfo.UserName)
                        return "Can't change current user permissions";

                    if (IsEmpHasBricks((int)int.Parse(frmViewUsers.DataKey["EmpID"].ToString())))
                    {
                        return "You must first unassign all bricks belong to this user.";
                    }
                    else
                    {
                        str.Append(" 2 ");
                        str.Append(UserName);
                        str.Append(" ");
                        str.Append(GetAdminRoleNameForUser(UserName));

                        str.Append(" 2 ");
                        str.Append(UserName);
                        str.Append(" User");

                        if (AccessLevel != "SuperUser")
                        {
                            str.Append(" 1 ");
                            str.Append(UserName);
                            str.Append(" ");
                            str.Append(AccessLevel);
                        }
                        else
                        {
                            str.Append(" 1 ");
                            str.Append(UserName);
                            str.Append(" SuperUser");

                            str.Append(" 0 ");
                            str.Append(UserName);

                            str.Append(" 1 ");
                            str.Append(UserName);
                            str.Append(" ");
                            str.Append(UserName);
                        }
                    }
                }
                else
                {
                    str.Append(" 8 ");
                    str.Append(UserName);
                    str.Append(" User");

                    if (Supervisor != GetAdminEmpNameForUser(UserName))
                    {
                        // Change user's supervisor
                        str.Append(" 2 ");
                        str.Append(UserName);
                        str.Append(" ");
                        str.Append(GetAdminRoleNameForUser(UserName));

                        str.Append(" 1 ");
                        str.Append(UserName);
                        str.Append(" ");
                        str.Append(SelectUserNameByEmpName(Supervisor, false));
                    }
                    else
                    {
                        str.Append(" 8 ");
                        str.Append(UserName);
                        str.Append(" ");
                        str.Append(Supervisor);
                    }
                }
            }
        }

        MembershipAndRolesInfo = str.ToString();
        return "";
    }
    private DataTable GetChangedValues(string SaveMode, DataTable dtOriginalData, string OrgColumnName, 
        GridView GridViewName, string CheckBoxName, int CheckBoxNameCellLocation)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("CurrentID"));
        dt.Columns.Add(new DataColumn("CurrentcbxStatus"));

        switch (SaveMode)
        {
            case "Add":
                for (int i = 0; i < GridViewName.Rows.Count; i++)
                {
                    if (GridViewName.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        string CurrentID = GridViewName.DataKeys[i].Values[1].ToString();
                        if (GridViewName.ID == "gvAssignedUsers")//If the gridview is assigned users add username instead of EmpID
                            CurrentID = GridViewName.DataKeys[i].Values[1].ToString();
                        bool CurrentcbxStatus = ((CheckBox)(GridViewName.Rows[i].Cells[CheckBoxNameCellLocation].FindControl(CheckBoxName))).Checked;
                        if (CurrentcbxStatus)
                        {
                            DataRow row = dt.NewRow();
                            row["CurrentID"] = CurrentID.ToString();
                            row["CurrentcbxStatus"] = CurrentcbxStatus.ToString();
                            dt.Rows.Add(row);
                        }
                    }
                }
                break;


            case "Edit":
                for (int i = 0; i < GridViewName.Rows.Count; i++)
                {
                    if (GridViewName.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        //int CurrentID = int.Parse(GridViewName.DataKeys[i].Values[0].ToString());

                        string CurrentID = GridViewName.DataKeys[i].Values[1].ToString();                        

                        string OriginalID = dtOriginalData.Rows[i][0].ToString();
                        if (GridViewName.ID == "gvAssignedUsers")//If the gridview is assigned users add username instead of EmpID
                        {
                            CurrentID = GridViewName.DataKeys[i].Values[1].ToString();
                            OriginalID = dtOriginalData.Rows[i][2].ToString();
                        }
                        if (CurrentID == OriginalID)
                        {
                            bool CurrentcbxStatus = ((CheckBox)(GridViewName.Rows[i].Cells[CheckBoxNameCellLocation].FindControl(CheckBoxName))).Checked;
                            bool OriginalStatus = bool.Parse(dtOriginalData.Rows[i][OrgColumnName].ToString());
                            if (CurrentcbxStatus != OriginalStatus)
                            {
                                DataRow row = dt.NewRow();
                                row["CurrentID"] = CurrentID.ToString();
                                row["CurrentcbxStatus"] = CurrentcbxStatus.ToString();
                                dt.Rows.Add(row);
                            }
                        }
                    }
                }
                break;
        }
        return dt;
    }
    private void SaveChangedValues(int EmpID, string EmpLevel, string SaveMethod, DataTable dt)
    {

        switch (SaveMethod)
        {
            case "SaveAdminUsers":
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string UserName = dt.Rows[i]["CurrentID"].ToString();
                    bool Status = bool.Parse(dt.Rows[i]["CurrentcbxStatus"].ToString());

                    if (Status)
                    {
                        //AssignPharmacyToMedicalAccount(EmpID, ID);
                        DeAssignAllBricksFromUser(SelectEmpIDByUserName(UserName, false));
                        string[] currentUserRoles = Roles.GetRolesForUser(UserName);
                        Roles.RemoveUserFromRoles(UserName, currentUserRoles);
                        Roles.AddUserToRole(UserName, txtNewUserName.Text);
                        Roles.AddUserToRole(UserName, "User");
                    }
                    //There is no need to remove user from his admin rule as he will be transfered to new admin when updating new admin
                    //else
                    //{
                    //    //UnAssignPharmacyToMedicalAccount(EmpID, ID);
                    //    Roles.RemoveUserFromRole(UserName, txtNewUserName.Text);
                    //}

                }
                break;

            case "SaveUserBricks":
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int ID = int.Parse(dt.Rows[i]["CurrentID"].ToString());
                    bool Status = bool.Parse(dt.Rows[i]["CurrentcbxStatus"].ToString());

                    if (Status)
                    {
                        AssignBrickToUser(ID, EmpID);
                    }
                    else
                    {
                        if (EmpLevel == "SuperUser")
                            DeAssignBrickFromSuperUser(ID, EmpID);
                        else
                            DeAssignBrickFromUser(ID, EmpID);
                    }

                }
                break;

        }
    }
    #endregion

    protected void gvBricks_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (((CheckBox)e.Row.FindControl("cbxBrickSelected")).Checked)
            {
                e.Row.CssClass = "GridhighlightedRowsStyle";
                if (String.IsNullOrEmpty(CurrentQueryStringsValues.ID))
                {
                    if (ddlAccessLevel.SelectedValue == "User")
                    {
                        e.Row.Cells[0].Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                        e.Row.Cells[0].Attributes["onmouseout"] = "this.style.textDecoration='none';";
                        e.Row.Cells[0].Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvBricks, "Select$" + e.Row.RowIndex);
                    }
                }
            }
        }
    }
    protected void gvProducs_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (((CheckBox)e.Row.FindControl("cbxProductSelected")).Checked)
            {
                e.Row.CssClass = "GridhighlightedRowsStyle";
            }
        }
    }
    protected void gvAssignedUsers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (((CheckBox)e.Row.FindControl("cbxUserSelected")).Checked)
            {
                e.Row.CssClass = "GridhighlightedRowsStyle";
                ((CheckBox)e.Row.Cells[1].Controls[1]).Enabled = false;
            }
        }
    }
    
    protected void frmViewUsers_DataBound(object sender, EventArgs e)
    {
        if (this.Master.ToString() == "ASP.blankmasterpage_master")
        {
            ((Label)frmViewUsers.FindControl("lblSearch")).Enabled = false;
            ((TextBox)frmViewUsers.FindControl("txtSearchName")).Enabled = false;
        }
    }

    protected void ddlAccessLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAccessLevel.SelectedValue == "User")
        {
            //Show Bricks and Products gridviews which is in UpdatePanel2 and hide Assigned Users gridview which is in UpdatePanel1
            ((UpdatePanel)frmViewUsers.FindControl("UpdatePanel2")).Visible = true;
            ((UpdatePanel)frmViewUsers.FindControl("UpdatePanel3")).Visible = false;

            //Make Bricks and Products gridviews ready for adding or updating
            //if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
            //{
            LoadSupervisors(txtNewUserName.Text);
            LoadUsersBricks(int.Parse(ddlSupervisor.SelectedValue), false, false);
            EnableGridview(gvBricks, true, false, false);
            //}

            //Remove list item from supervisors list when current list item is equal to current user name
            ddlSupervisor.Items.Remove(ddlSupervisor.Items.FindByText(txtNewEmployeeName.Text));
        }
        else if (ddlAccessLevel.SelectedValue == "SuperUser")
        {
            ddlSupervisor.Visible = false;
            lblSupervisor.Visible = false;
            //LoadAssignedUsers(txtNewUserName.Text);
            LoadUsersBricks(-1, false, true);
            //Hide Bricks and Products gridviews which is in UpdatePanel2 and show Assigned Users gridview which is in UpdatePanel1
            ((UpdatePanel)frmViewUsers.FindControl("UpdatePanel2")).Visible = true;
            ((UpdatePanel)frmViewUsers.FindControl("UpdatePanel3")).Visible = false;

            //Make assigned users gridview ready for adding or updating
            //if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
            //{
                //EnableGridview(gvAssignedUsers, true, false, false);
                EnableGridview(gvBricks, true, false, false);
            //}
        }
        else
        {
            if (CurrentUserInfo.UserRole != UsersRoles.SuperAdmin)
            {
                ddlAccessLevel.Items[0].Enabled = false;
                //if(ddlAccessLevel.SelectedValue == "SuperAdmin")
                //{
                //    ddlAccessLevel.Items[0].SelectedValue == "Admin";

                //}
            }
            ddlSupervisor.Visible = false;
            lblSupervisor.Visible = false;
            //Hide Bricks and Products gridviews which is in UpdatePanel2 and hide Assigned Users gridview which is in UpdatePanel1
            ((UpdatePanel)frmViewUsers.FindControl("UpdatePanel2")).Visible = false;
            ((UpdatePanel)frmViewUsers.FindControl("UpdatePanel3")).Visible = false;
        }
    }

    protected void ddlSupervisor_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadUsersBricks(int.Parse(ddlSupervisor.SelectedValue), false, false);
        EnableGridview(gvBricks, true, false, false);
    }
    //
    protected void chkResetPassword_CheckedChanged(object sender, EventArgs e)
    {
        if (chkResetPassword.Checked)
        {
            ((Label)frmViewUsers.FindControl("lblPassword")).Visible = false;
            ((Label)frmViewUsers.FindControl("lblConfirmPassword")).Visible = false; 
            ((TextBox)frmViewUsers.FindControl("txtNewPassword1")).Visible = false;
            ((TextBox)frmViewUsers.FindControl("txtNewPassword2")).Visible = false;
        }
        else
        {
            bool Flag = txtNewUserName.Text == Session["User"].ToString() || ViewState["SaveMode"].ToString() == "Add";
            ((Label)frmViewUsers.FindControl("lblPassword")).Visible = Flag;
            ((Label)frmViewUsers.FindControl("lblConfirmPassword")).Visible = Flag;
            ((TextBox)frmViewUsers.FindControl("txtNewPassword1")).Visible = Flag;
            ((TextBox)frmViewUsers.FindControl("txtNewPassword2")).Visible = Flag;
        }        
    }
    private void SaveBrickExpireDate() 
    {
        if (rblExpireDate.Enabled) 
        {
            int SelectedEmpID = int.Parse(gvBricks.DataKeys[gvBricks.SelectedIndex].Values["EmpID"].ToString());
            int SelectedBrickID = int.Parse(gvBricks.DataKeys[gvBricks.SelectedIndex].Values["BrickID"].ToString());

            if (rblExpireDate.SelectedValue == "0")
            {
                // Save Never Expire date [Null] for selected brick [SelectedBrickID]//
                UpdateExpireDate(SelectedEmpID, SelectedBrickID, null);
            }
            else if (rblExpireDate.SelectedValue == "1")
            {
                if (txtExpireDate.Text != "" &&  Convert.ToString(ViewState["ExpireDateState"]) == "Changed")
                {
                    // Save [Expiredate] from txtExpireDate.Text for selected brick [SelectedBrickID];
                    UpdateExpireDate(SelectedEmpID, SelectedBrickID, Convert.ToDateTime(txtExpireDate.Text));
                    ViewState["ExpireDateState"] = null;
                }
            }
        }
    }
    protected void gvBricks_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow CurrentRow = ((System.Web.UI.WebControls.GridView)sender).SelectedRow;
        if (((CheckBox)CurrentRow.FindControl("cbxBrickSelected")).Checked)
        {
            TDBrickExpireDate.Visible = true;
            txtExpireDate.Text = Convert.ToString(((System.Web.UI.WebControls.GridView)sender).SelectedDataKey["ExpireDate"].ToString());
            if (txtExpireDate.Text != "")
            {
                rblExpireDate.SelectedValue = "1";
                txtExpireDate.Visible = true;
                imgExpireDate.Visible = true;
                txtExpireDate.Text = Convert.ToDateTime(((System.Web.UI.WebControls.GridView)sender).SelectedDataKey["ExpireDate"].ToString()).ToShortDateString();

            }
            else 
            { 
                rblExpireDate.SelectedValue = "0";
                txtExpireDate.Visible = false;
                imgExpireDate.Visible = false;
            }
        }
        else
        {
            TDBrickExpireDate.Visible = false;
        }
        
    }

    protected void rblExpireDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblExpireDate.SelectedValue == "0")
        {
            txtExpireDate.Visible = false;
            imgExpireDate.Visible = false;
        }
        else if (rblExpireDate.SelectedValue == "1")
        {
            txtExpireDate.Visible = true;
            imgExpireDate.Visible = true;
        }
    }

    protected void txtExpireDate_TextChanged(object sender, EventArgs e)
    {
        ViewState["ExpireDateState"] = "Changed";
    }

    protected void btnUnassignAllUsers_Click(object sender, EventArgs e)
    {
        try
        {
            string UserName = ((TextBox)frmViewUsers.FindControl("txtNewUserName")).Text;
            string NewSupervisor = SelectUserNameByEmpName(((DropDownList)frmViewUsers.FindControl("ddlNewSupervisor")).SelectedItem.Text.ToLower(), false);
            string[] MRs = Roles.GetUsersInRole(UserName);
            DeAssignAllBrickFromSuperUser(int.Parse(frmViewUsers.DataKey["EmpID"].ToString()));
            Roles.RemoveUsersFromRole(MRs, UserName);
            Roles.AddUserToRole(UserName, UserName);
            Roles.AddUsersToRole(MRs, NewSupervisor);
            Roles.RemoveUserFromRole(UserName, NewSupervisor);
            lblErrors.Text = "All users were de-assigned successfully!";
        }
        catch
        {
            lblErrors.Text = "Failed to unassign all users.";
        }
    }

}
