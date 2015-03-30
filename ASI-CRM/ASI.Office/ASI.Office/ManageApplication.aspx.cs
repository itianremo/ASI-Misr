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
using Office.DAL;

public partial class ManageApplication : Office.BLL.ManageApplicationBLL
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Hide messages lables
        lblBusSecMsg.Visible = false;
        lblStatusMsg.Visible = false;
        lblDeptMsg.Visible = false;
        lblTitleMsg.Visible = false;
        lblWebsitesServiceMsg.Visible = false;
        //Add effects to controls
        if (!IsPostBack)
        {
				//lblVersionInfo.Text = GetVersionInfo();
            string[] ButtonsNames = new string[5];
            ButtonsNames[0] = "Status";
            ButtonsNames[1] = "Title";
            ButtonsNames[2] = "Dept";
            ButtonsNames[3] = "BusSec";
            ButtonsNames[4] = "WebsitesService";
            for (int i = 0; i < ButtonsNames.Length; i++)
            {
                SetButtonEffects(ButtonsNames[i]);
            }
        }
        //Add events to user tabs control
		  //utManageApp.CurrentPage = "ManageApplication";
		  //utManageApp.btnAccountListsEvent += new EventHandler(utManageApp_btnAccountListsEvent);
		  //utManageApp.btnAccountsEvent += new EventHandler(utManageApp_btnAccountsEvent);
		  //utManageApp.btnContactListsEvent += new EventHandler(utManageApp_btnContactListsEvent);
		  //utManageApp.btnContantsEvent += new EventHandler(utManageApp_btnContantsEvent);
       
    }

    #region ---------------General Page Functions------------------
   
    //User Tab Control
    void utManageApp_btnContantsEvent(object sender, EventArgs e)
    {
        Response.Redirect("Contacts.aspx");
    }
    void utManageApp_btnContactListsEvent(object sender, EventArgs e)
    {
        Response.Redirect("ContactLists.aspx");
    }
    void utManageApp_btnAccountsEvent(object sender, EventArgs e)
    {
        Response.Redirect("Accounts.aspx");
    }
    void utManageApp_btnAccountListsEvent(object sender, EventArgs e)
    {
        Response.Redirect("AccountLists.aspx");
    }
   
    //Add,Edit,Save and cancel effects
    private void SetButtonEffects(string PartialButtonName)
    {
        string AddCtrlName = "btnAddNew" + PartialButtonName;
        string EditCtrlName = "btnEdit" + PartialButtonName;
        string SaveCtrlName = "btnSave" + PartialButtonName;
        string CancelCtrlName = "btnCancel" + PartialButtonName;
        /////Button Add New
        ((ImageButton)this.FindControl(AddCtrlName)).Attributes.Add("onmouseover", "this.src='Images/add2.jpg'");
        ((ImageButton)this.FindControl(AddCtrlName)).Attributes.Add("onmouseout", "this.src='Images/add1.jpg'");
        ((ImageButton)this.FindControl(AddCtrlName)).Attributes.Add("onmousedown", "this.src='Images/add3.jpg'");
        /////Button Edit
        ((ImageButton)this.FindControl(EditCtrlName)).Attributes.Add("onmouseover", "this.src='Images/edit2.jpg'");
        ((ImageButton)this.FindControl(EditCtrlName)).Attributes.Add("onmouseout", "this.src='Images/edit1.jpg'");
        ((ImageButton)this.FindControl(EditCtrlName)).Attributes.Add("onmousedown", "this.src='Images/edit3.jpg'");
        /////Button Save
        ((ImageButton)this.FindControl(SaveCtrlName)).Attributes.Add("onmouseover", "this.src='Images/save2.jpg'");
        ((ImageButton)this.FindControl(SaveCtrlName)).Attributes.Add("onmouseout", "this.src='Images/save1.jpg'");
        ((ImageButton)this.FindControl(SaveCtrlName)).Attributes.Add("onmousedown", "this.src='Images/save3.jpg'");
        /////Button Cancel
        ((ImageButton)this.FindControl(CancelCtrlName)).Attributes.Add("onmouseover", "this.src='Images/cancel2.jpg'");
        ((ImageButton)this.FindControl(CancelCtrlName)).Attributes.Add("onmouseout", "this.src='Images/cancel1.jpg'");
        ((ImageButton)this.FindControl(CancelCtrlName)).Attributes.Add("onmousedown", "this.src='Images/cancel3.jpg'");
    }

    //Validate Text box to prevent saving when textbox is empty
    private bool ValidateData(TextBox txtNewRecord)
    {
        bool Valid = true;
        if (txtNewRecord.Text.Trim() == "")
            Valid = false;
        else
            Valid = true;
        return Valid;
    }

    #endregion   

    #region -----------Manage Business Sector Controls------------

    //ListBox Selected Change
    protected void lbBusSec_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtSelectedbuSec.Text = lbBusSec.SelectedItem.Text;
        txtBusSecID.Text = lbBusSec.SelectedItem.Value;
    }
    
    //Add New - Button Event
    protected void btnAddNewBusSec_Click(object sender, ImageClickEventArgs e)
    {
        AddNewBusSecButtonEvent();
    }
    //Add New - Button Function
    private void AddNewBusSecButtonEvent()
    {
        txtlblNewBusSec.Visible = true;
        txtSelectedbuSec.Visible = false;
        txtlblNewBusSec.Text = "";
        txtSelectedbuSec.Text = "";
        txtBusSecID.Text = "";
        lblNewBusSec.Visible = true;
        lblSelectedBusSec.Visible = false;
        btnAddNewBusSec.Visible = false;
        btnEditBusSec.Visible = false;
        btnSaveBusSec.Visible = true;
        btnCancelBusSec.Visible = true;
        txtSelectedbuSec.ReadOnly = true;
        lbBusSec.SelectedIndex = -1;
    }

    //Edit - Button Event
    protected void btnEditBusSec_Click(object sender, ImageClickEventArgs e)
    {
        EditBusSecButtonEvent();
    }
    //Edit - Button Function
    private void EditBusSecButtonEvent()
    {
        if (lbBusSec.SelectedIndex != -1)
        {
            txtlblNewBusSec.Visible = false;
            txtSelectedbuSec.Visible = true;
            txtlblNewBusSec.Text = "";
            lblNewBusSec.Visible = false;
            lblSelectedBusSec.Visible = true;
            btnAddNewBusSec.Visible = false;
            btnEditBusSec.Visible = false;
            btnSaveBusSec.Visible = true;
            btnCancelBusSec.Visible = true;
            txtSelectedbuSec.ReadOnly = false;
        }
        else
        {
            lblBusSecMsg.Visible = true;
            lblBusSecMsg.Text = "No items selected to be edited";
        }
    }

    //Save - Button Event
    protected void btnSaveBusSec_Click(object sender, ImageClickEventArgs e)
    {
        SaveBusSecButtonEvent();
    }
    //Save - Button Function
    private void SaveBusSecButtonEvent()
    {
        if (lblNewBusSec.Visible)
        {
            if (ValidateData(txtlblNewBusSec))
                AddNewBusinessSector();
            else
            {
                lblBusSecMsg.Text = "Please enter the new business sector name";
                lblBusSecMsg.Visible = true;
            }
        }
        else
        {
            if (ValidateData(txtSelectedbuSec)) 
                UpdateSelectedBusinessSector();
            else
            {
                lblBusSecMsg.Text = "Please enter the business sector name";
                lblBusSecMsg.Visible = true;
            }
        }
    }

    //Cancel - Button Event
    protected void btnCancelBusSec_Click(object sender, ImageClickEventArgs e)
    {
        CancelBusSecButtonEvent();
    }
    //Cancel - Button Function
    private void CancelBusSecButtonEvent()
    {
        txtlblNewBusSec.Visible = false;
        txtSelectedbuSec.Visible = true;
        txtlblNewBusSec.Text = "";
        txtSelectedbuSec.Text = "";
        txtBusSecID.Text = "";
        lblNewBusSec.Visible = false;
        lblSelectedBusSec.Visible = true;
        btnAddNewBusSec.Visible = true;
        btnEditBusSec.Visible = true;
        btnSaveBusSec.Visible = false;
        btnCancelBusSec.Visible = false;
        txtSelectedbuSec.ReadOnly = true;
        txtSelectedbuSec.ReadOnly = true;
        lbBusSec.SelectedIndex = -1;
    }

    //Add New Function
    private void AddNewBusinessSector()
    {
        MainSubCode NewBusSec = new MainSubCode();
        MainGeneralCode SelectedGCode = new MainGeneralCode();
        SelectedGCode.GeneralCode = "BusinessSector";
        NewBusSec.GeneralID = SelectedGCode.GetGeneralCodeID();
        NewBusSec.SubCode = txtlblNewBusSec.Text;
        if (NewBusSec.CheckSCodeExistance() == false)
        {
            NewBusSec.AddNewMainSubCode();
            lblBusSecMsg.Text = "Added Successfully";
            lbBusSec.DataBind();
            btnAddNewBusSec.Visible = true;
            btnEditBusSec.Visible = true;
            btnSaveBusSec.Visible = false;
            btnCancelBusSec.Visible = false;
            lblSelectedBusSec.Visible = true;
            txtSelectedbuSec.Visible = true;
            lblNewBusSec.Visible = false;
            txtlblNewBusSec.Visible = false;
            txtSelectedbuSec.ReadOnly = true;
        }
        else
            lblBusSecMsg.Text = "This name exists before";
        lblBusSecMsg.Visible = true;

    }
    //Update Function
    private void UpdateSelectedBusinessSector()
    {
        MainSubCode CurrentBusSec = new MainSubCode();
        CurrentBusSec.SubID = int.Parse(txtBusSecID.Text);
        CurrentBusSec.SubCode = txtSelectedbuSec.Text;
        MainGeneralCode SelectedGCode = new MainGeneralCode();
        SelectedGCode.GeneralCode = "BusinessSector";
        CurrentBusSec.GeneralID = SelectedGCode.GetGeneralCodeID();
        if (lbBusSec.SelectedItem.Text.ToLower() != txtSelectedbuSec.Text.ToLower())
        {
            if (CurrentBusSec.CheckSCodeExistance() == false)
            {
                CurrentBusSec.UpdateMainSubCode();
                lblBusSecMsg.Text = "Updated Successfully";
                lbBusSec.DataBind();
                btnAddNewBusSec.Visible = true;
                btnEditBusSec.Visible = true;
                btnSaveBusSec.Visible = false;
                btnCancelBusSec.Visible = false;
                lblSelectedBusSec.Visible = true;
                txtSelectedbuSec.Visible = true;
                txtSelectedbuSec.Text = "";
                lblNewBusSec.Visible = false;
                txtlblNewBusSec.Visible = false;
                txtSelectedbuSec.ReadOnly = true;
            }
            else
                lblBusSecMsg.Text = "This name exists before";
        }
        else
        {
            CurrentBusSec.UpdateMainSubCode();
            lblBusSecMsg.Text = "Updated Successfully";
            lbBusSec.DataBind();
            btnAddNewBusSec.Visible = true;
            btnEditBusSec.Visible = true;
            btnSaveBusSec.Visible = false;
            btnCancelBusSec.Visible = false;
            lblSelectedBusSec.Visible = true;
            txtSelectedbuSec.Visible = true;
            lblNewBusSec.Visible = false;
            txtlblNewBusSec.Visible = false;
            txtSelectedbuSec.ReadOnly = true;
        }
        lblBusSecMsg.Visible = true;
    }

    protected void imgbtnSignOut_Click(object sender, ImageClickEventArgs e)
    {
        SignOut();
    }

    #endregion

    #region --------------Manage ID / Status Controls--------------

    //ListBox Selected Change
    protected void lbStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtStatusID.Text = lbStatus.SelectedItem.Value;
        txtSelectedStatus.Text = lbStatus.SelectedItem.Text;
    }

    //Add New - Button Event
    protected void btnAddNewStatus_Click(object sender, ImageClickEventArgs e)
    {
        AddNewStatusButtonEvent();
    }
    //Add New - Button Function
    private void AddNewStatusButtonEvent()
    {
        lbStatus.SelectedIndex = -1;
        txtStatusID.Text = "";
        txtSelectedStatus.Text = "";
        txtNewStatus.Text = "";
        lblSelectedStatus.Visible = false;
        lblNewStatus.Visible = true;
        txtSelectedStatus.Visible = false;
        txtNewStatus.Visible = true;
        btnCancelStatus.Visible = true;
        btnSaveStatus.Visible = true;
        btnAddNewStatus.Visible = false;
        btnEditStatus.Visible = false;
    }

    //Edit - Button Event
    protected void btnEditStatus_Click(object sender, ImageClickEventArgs e)
    {
        EditStatusButtonEvent();
    }
    //Edit - Button Function
    private void EditStatusButtonEvent()
    {
        if (lbStatus.SelectedIndex != -1)
        {
            txtNewStatus.Text = "";
            lblSelectedStatus.Visible = true;
            lblNewStatus.Visible = false;
            txtSelectedStatus.Visible = true;
            txtNewStatus.Visible = false;
            btnCancelStatus.Visible = true;
            btnSaveStatus.Visible = true;
            btnAddNewStatus.Visible = false;
            btnEditStatus.Visible = false;
            txtSelectedStatus.ReadOnly = false;
        }
        else
        {
            lblStatusMsg.Visible = true;
            lblStatusMsg.Text = "No items selected to be edited";
        }
    }

    //Save - Button Event
    protected void btnSaveStatus_Click(object sender, ImageClickEventArgs e)
    {
        SaveStatusButtonEvent();
    }
    //Save - Button Function
    private void SaveStatusButtonEvent()
    {
        if (lblNewStatus.Visible)
        {
            if (ValidateData(txtNewStatus))
                AddNewStatus();
            else
            {
                lblStatusMsg.Text = "Please enter the new status name";
                lblStatusMsg.Visible = true;
            }
        }
        else
        {
            if(ValidateData(txtSelectedStatus))
                UpdateSelectedtatus();
            else
            {
                lblStatusMsg.Text = "Please enter the status name";
                lblStatusMsg.Visible = true;
            }
        }
    }

    //Cancel - Button Event
    protected void btnCancelStatus_Click(object sender, ImageClickEventArgs e)
    {
        CancelStatusButtonEvent();
    }
    //Cancel - Button Function
    private void CancelStatusButtonEvent()
    {
        lbStatus.SelectedIndex = -1;
        txtStatusID.Text = "";
        txtSelectedStatus.Text = "";
        txtNewStatus.Text = "";
        lblSelectedStatus.Visible = true;
        lblNewStatus.Visible = false;
        txtSelectedStatus.Visible = true;
        txtNewStatus.Visible = false;
        btnCancelStatus.Visible = false;
        btnSaveStatus.Visible = false;
        btnAddNewStatus.Visible = true;
        btnEditStatus.Visible = true;
        txtSelectedStatus.ReadOnly = true;
    }

    //Add New Function
    private void AddNewStatus()
    {
        MainSubCode NewStatus = new MainSubCode();
        MainGeneralCode SelectedGCode = new MainGeneralCode();
        SelectedGCode.GeneralCode = "Status";
        NewStatus.GeneralID = SelectedGCode.GetGeneralCodeID();
        NewStatus.SubCode = txtNewStatus.Text;
        if (NewStatus.CheckSCodeExistance() == false)
        {
            NewStatus.AddNewMainSubCode();
            lblStatusMsg.Text = "Added Successfully";
            lbStatus.DataBind();
            btnAddNewStatus.Visible = true;
            btnEditStatus.Visible = true;
            lblSelectedStatus.Visible = true;
            txtSelectedStatus.Visible = true;
            btnCancelStatus.Visible = false;
            btnSaveStatus.Visible = false;
            lblNewStatus.Visible = false;
            txtNewStatus.Visible = false;
            txtSelectedStatus.ReadOnly = true;
        }
        else
            lblStatusMsg.Text = "This name exists before";
        lblStatusMsg.Visible = true;
    }
    //Update Function
    private void UpdateSelectedtatus()
    {
        MainSubCode CurrentStatus = new MainSubCode();
        MainGeneralCode SelectedGCode = new MainGeneralCode();
        SelectedGCode.GeneralCode = "Status";
        CurrentStatus.GeneralID = SelectedGCode.GetGeneralCodeID();
        CurrentStatus.SubID = int.Parse(txtStatusID.Text);
        CurrentStatus.SubCode = txtSelectedStatus.Text;
        if (CurrentStatus.CheckSCodeExistance() == false)
        {
            CurrentStatus.UpdateMainSubCode();
            lblStatusMsg.Text = "Updated Successfully";
            lbStatus.DataBind();
            btnAddNewStatus.Visible = true;
            btnEditStatus.Visible = true;
            lblSelectedStatus.Visible = true;
            txtSelectedStatus.Visible = true;
            txtSelectedStatus.Text = "";
            btnCancelStatus.Visible = false;
            btnSaveStatus.Visible = false;
            lblNewStatus.Visible = false;
            txtNewStatus.Visible = false;
            txtSelectedStatus.ReadOnly = true;
        }
        else
            lblStatusMsg.Text = "This name exists before";
        lblStatusMsg.Visible = true;
    }

    #endregion

    #region --------------Manage Department Controls-------------

    //ListBox Selected Change
    protected void lbDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtDeptID.Text = lbDept.SelectedItem.Value;
        txtSelectedDept.Text = lbDept.SelectedItem.Text;
    }

    //Add New - Button Event
    protected void btnAddNewDept_Click(object sender, ImageClickEventArgs e)
    {
        AddNewDeptButtonEvent();
    }
    //Add New - Button Function
    private void AddNewDeptButtonEvent()
    {
        lbDept.SelectedIndex = -1;
        txtDeptID.Text = "";
        txtSelectedDept.Text = "";
        txtNewDept.Text = "";
        lblSelectedDept.Visible = false;
        lblNewDept.Visible = true;
        txtSelectedDept.Visible = false;
        txtNewDept.Visible = true;
        btnCancelDept.Visible = true;
        btnSaveDept.Visible = true;
        btnAddNewDept.Visible = false;
        btnEditDept.Visible = false;
    }

    //Edit - Button Event
    protected void btnEditDept_Click(object sender, ImageClickEventArgs e)
    {
        EditDeptButtonEvent();
    }
    //Edit - Button Function
    private void EditDeptButtonEvent()
    {
        if (lbDept.SelectedIndex != -1)
        {
            txtNewDept.Text = "";
            lblSelectedDept.Visible = true;
            lblNewDept.Visible = false;
            txtSelectedDept.Visible = true;
            txtNewDept.Visible = false;
            btnCancelDept.Visible = true;
            btnSaveDept.Visible = true;
            btnAddNewDept.Visible = false;
            btnEditDept.Visible = false;
            txtSelectedDept.ReadOnly = false;
        }
        else
        {
            lblDeptMsg.Visible = true;
            lblDeptMsg.Text = "No items selected to be edited";
        }
    }

    //Save - Button Event
    protected void btnSaveDept_Click(object sender, ImageClickEventArgs e)
    {
        SaveDepButtonEvent();
    }
    //Save - Button Function
    private void SaveDepButtonEvent()
    {
        if (lblNewDept.Visible)
        {
            if (ValidateData(txtNewDept)) 
                AddNewDepartment();
            else
            {
                lblDeptMsg.Text = "Please enter the new department name";
                lblDeptMsg.Visible = true;
            }
        }
        else
        {
            if(ValidateData(txtSelectedDept))
                UpdateSelectedDepartment();
            else
            {
                lblDeptMsg.Text = "Please enter the department name";
                lblDeptMsg.Visible = true;
            }
        }
    }

    //Cancel - Button Event
    protected void btnCancelDept_Click(object sender, ImageClickEventArgs e)
    {
        CancelDeptButtonEvent();
    }
    //Cancel - Button Function
    private void CancelDeptButtonEvent()
    {
        lbDept.SelectedIndex = -1;
        txtDeptID.Text = "";
        txtSelectedDept.Text = "";
        txtNewDept.Text = "";
        lblSelectedDept.Visible = true;
        lblNewDept.Visible = false;
        txtSelectedDept.Visible = true;
        txtNewDept.Visible = false;
        btnCancelDept.Visible = false;
        btnSaveDept.Visible = false;
        btnAddNewDept.Visible = true;
        btnEditDept.Visible = true;
        txtSelectedDept.ReadOnly = true;
    }

    //Add New Function
    private void AddNewDepartment()
    {
        MainSubCode NewDept = new MainSubCode();
        MainGeneralCode SelectedGCode = new MainGeneralCode();
        SelectedGCode.GeneralCode = "Department";
        NewDept.GeneralID = SelectedGCode.GetGeneralCodeID();
        NewDept.SubCode = txtNewDept.Text;
        if (NewDept.CheckSCodeExistance() == false)
        {
            NewDept.AddNewMainSubCode();
            lblDeptMsg.Text = "Added Successfully";
            lbDept.DataBind();
            CancelDeptButtonEvent();
            //lbDept.SelectedIndex = -1;
            //btnAddNewStatus.Visible = true;
            //btnEditDept.Visible = true;
            //lblSelectedDept.Visible = true;
            //txtSelectedDept.Visible = true;
            //btnCancelDept.Visible = false;
            //btnSaveDept.Visible = false;
            //lblNewDept.Visible = false;
            //txtNewDept.Visible = false;
            //txtSelectedDept.ReadOnly = true;
        }
        else
            lblDeptMsg.Text = "This name exists before";
        lblDeptMsg.Visible = true;
    }
    //Update Function
    private void UpdateSelectedDepartment()
    {
        MainSubCode CurrentDept = new MainSubCode();
        MainGeneralCode SelectedGCode = new MainGeneralCode();
        SelectedGCode.GeneralCode = "Department";
        CurrentDept.GeneralID = SelectedGCode.GetGeneralCodeID();
        CurrentDept.SubID = int.Parse(txtDeptID.Text);
        CurrentDept.SubCode = txtSelectedDept.Text;
        if (CurrentDept.CheckSCodeExistance() == false)
        {
            CurrentDept.UpdateMainSubCode();
            lblDeptMsg.Text = "Updated Successfully";
            lbDept.DataBind();
            btnAddNewDept.Visible = true;
            btnEditDept.Visible = true;
            lblSelectedDept.Visible = true;
            txtSelectedDept.Visible = true;
            txtSelectedDept.Text = "";
            btnCancelDept.Visible = false;
            btnSaveDept.Visible = false;
            lblNewDept.Visible = false;
            txtNewDept.Visible = false;
            txtSelectedDept.ReadOnly = true;
        }
        else
            lblDeptMsg.Text = "This name exists before";
        lblDeptMsg.Visible = true;
    }

    #endregion

    #region ------------------Manage Title Controls----------------

    //ListBox Selected Change
    protected void lbTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtTitleID.Text = lbTitle.SelectedItem.Value;
        txtSelectedTitle.Text = lbTitle.SelectedItem.Text;
    }

    //Add New - Button Event
    protected void btnAddNewTitle_Click(object sender, ImageClickEventArgs e)
    {
        AddNewTitleButtonEvent();
    }
    //Add New - Button Function
    private void AddNewTitleButtonEvent()
    {
        lbTitle.SelectedIndex = -1;
        txtTitleID.Text = "";
        txtSelectedTitle.Text = "";
        txtNewTitle.Text = "";
        lblSelectedTitle.Visible = false;
        lblNewTitle.Visible = true;
        txtSelectedTitle.Visible = false;
        txtNewTitle.Visible = true;
        btnCancelTitle.Visible = true;
        btnSaveTitle.Visible = true;
        btnAddNewTitle.Visible = false;
        btnEditTitle.Visible = false;
    }

    //Edit - Button Event
    protected void btnEditTitle_Click(object sender, ImageClickEventArgs e)
    {
        EditTitleButtonEvent();
    }
    //Edit - Button Function
    private void EditTitleButtonEvent()
    {
        if (lbTitle.SelectedIndex != -1)
        {
            txtNewTitle.Text = "";
            lblSelectedTitle.Visible = true;
            lblNewTitle.Visible = false;
            txtSelectedTitle.Visible = true;
            txtNewTitle.Visible = false;
            btnCancelTitle.Visible = true;
            btnSaveTitle.Visible = true;
            btnAddNewTitle.Visible = false;
            btnEditTitle.Visible = false;
            txtSelectedTitle.ReadOnly = false;
        }
        else
        {
            lblTitleMsg.Visible = true;
            lblTitleMsg.Text = "No items selected to be edited";
        }
    }

    //Save - Button Event
    protected void btnSaveTitle_Click(object sender, ImageClickEventArgs e)
    {
        SaveTitleButtonEvent();
    }
    //Save - Button Function
    private void SaveTitleButtonEvent()
    {
        if (lblNewTitle.Visible)
        {
            if (ValidateData(txtNewTitle))
                AddNewTitle();
            else
            {
                lblTitleMsg.Text = "Please enter the new title name";
                lblTitleMsg.Visible = true;
            }
        }
        else
        {
            if (ValidateData(txtSelectedTitle))
                UpdateSelectedTitle();
             else
            {
                lblTitleMsg.Text = "Please enter the title name";
                lblTitleMsg.Visible = true;
            }
        }
    }

    //Cancel - Button Event
    protected void btnCancelTitle_Click(object sender, ImageClickEventArgs e)
    {
        CancelTitleButtonEvent();
    }
    //Cancel - Button Function
    private void CancelTitleButtonEvent()
    {
        lbTitle.SelectedIndex = -1;
        txtTitleID.Text = "";
        txtSelectedTitle.Text = "";
        txtNewTitle.Text = "";
        lblSelectedTitle.Visible = true;
        lblNewTitle.Visible = false;
        txtSelectedTitle.Visible = true;
        txtNewTitle.Visible = false;
        btnCancelTitle.Visible = false;
        btnSaveTitle.Visible = false;
        btnAddNewTitle.Visible = true;
        btnEditTitle.Visible = true;
        txtSelectedTitle.ReadOnly = true;
    }

    //Add New Function
    private void AddNewTitle()
    {
        MainSubCode NewTitle = new MainSubCode();
        MainGeneralCode SelectedGCode = new MainGeneralCode();
        SelectedGCode.GeneralCode = "Title";
        NewTitle.GeneralID = SelectedGCode.GetGeneralCodeID();
        NewTitle.SubCode = txtNewTitle.Text;
        if (NewTitle.CheckSCodeExistance() == false)
        {
            NewTitle.AddNewMainSubCode();
            lblTitleMsg.Text = "Added Successfully";
            lbTitle.DataBind();
            lbTitle.SelectedIndex = -1;
            btnAddNewTitle.Visible = true;
            btnEditTitle.Visible = true;
            lblSelectedTitle.Visible = true;
            txtSelectedTitle.Visible = true;
            btnCancelTitle.Visible = false;
            btnSaveTitle.Visible = false;
            lblNewTitle.Visible = false;
            txtNewTitle.Visible = false;
            txtSelectedTitle.ReadOnly = true;
        }
        else
            lblTitleMsg.Text = "This name exists before";
        lblTitleMsg.Visible = true;
    }
    //Update Function
    private void UpdateSelectedTitle()
    {
        MainSubCode CurrentTitle = new MainSubCode();
        MainGeneralCode SelectedGCode = new MainGeneralCode();
        SelectedGCode.GeneralCode = "Title";
        CurrentTitle.GeneralID = SelectedGCode.GetGeneralCodeID();
        CurrentTitle.SubID = int.Parse(txtTitleID.Text);
        CurrentTitle.SubCode = txtSelectedTitle.Text;
        if (CurrentTitle.CheckSCodeExistance() == false)
        {
            CurrentTitle.UpdateMainSubCode();
            lblTitleMsg.Text = "Updated Successfully";
            lbTitle.DataBind();
            btnAddNewTitle.Visible = true;
            btnEditTitle.Visible = true;
            lblSelectedTitle.Visible = true;
            txtSelectedTitle.Visible = true;
            txtSelectedTitle.Text = "";
            btnCancelTitle.Visible = false;
            btnSaveTitle.Visible = false;
            lblNewTitle.Visible = false;
            txtNewTitle.Visible = false;
            txtSelectedTitle.ReadOnly = true;
        }
        else
            lblTitleMsg.Text = "This name exists before";
        lblTitleMsg.Visible = true;
    }

    #endregion

    #region ------------------Manage WebsitesService Controls----------------

    //ListBox Selected Change
    protected void lbWebsitesService_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtWebsitesServiceID.Text = lbWebsitesService.SelectedItem.Value;
        string WSName, WSURL, WSUsername;
        GetWebsitesService(Convert.ToInt32(lbWebsitesService.SelectedValue), out WSName, out WSURL, out WSUsername);
        txtSelectedWebsitesService.Text = lbWebsitesService.SelectedItem.Text;
        txtSelectedURL.Text = WSURL;
        txtSelectedUsername.Text = WSUsername;
    }

    //Add New - Button Event
    protected void btnAddNewWebsitesService_Click(object sender, ImageClickEventArgs e)
    {
        AddNewWebsitesServiceButtonEvent();
    }
    //Add New - Button Function
    private void AddNewWebsitesServiceButtonEvent()
    {
        lbWebsitesService.SelectedIndex = -1;
        txtWebsitesServiceID.Text = "";

        txtSelectedWebsitesService.Text = "";
        txtNewWebsitesService.Text = "";
        txtSelectedWebsitesService.Visible = false;
        txtNewWebsitesService.Visible = true;
        //---//

        txtSelectedURL.Text = "";
        txtNewURL.Text = "";
        txtSelectedURL.Visible = false;
        txtNewURL.Visible = true;
        //---//

        txtSelectedUsername.Text = "";
        txtNewUsername.Text = "";
        txtSelectedUsername.Visible = false;
        txtNewUsername.Visible = true;
        //---//

        txtSelectedPassword.Text = "";
        txtNewPassword.Text = "";
        txtSelectedPassword.Visible = false;
        txtNewPassword.Visible = true;
        txtSelectedPassword2.Text = "";
        txtNewPassword2.Text = "";
        txtSelectedPassword2.Visible = false;
        txtNewPassword2.Visible = true;
        //---//

        btnCancelWebsitesService.Visible = true;
        btnSaveWebsitesService.Visible = true;
        btnSaveWebsitesService.ValidationGroup = "vgSaveNewWebsitesService";
        btnAddNewWebsitesService.Visible = false;
        btnEditWebsitesService.Visible = false;
    }

    //Edit - Button Event
    protected void btnEditWebsitesService_Click(object sender, ImageClickEventArgs e)
    {
        EditWebsitesServiceButtonEvent();
    }
    //Edit - Button Function
    private void EditWebsitesServiceButtonEvent()
    {
        if (lbWebsitesService.SelectedIndex != -1)
        {
            string WSName, WSURL, WSUsername;
            GetWebsitesService(Convert.ToInt32(lbWebsitesService.SelectedValue), out WSName, out WSURL, out WSUsername);
            lblSelectedWebsitesService.Visible = true;
            txtSelectedWebsitesService.Text = WSName;
            txtSelectedWebsitesService.Visible = true;
            txtSelectedWebsitesService.ReadOnly = false;
            txtNewWebsitesService.Text = "";
            txtNewWebsitesService.Visible = false;

            lblSelectedURL.Visible = true;
            txtSelectedURL.Text = WSURL;
            txtSelectedURL.Visible = true;
            txtSelectedURL.ReadOnly = false;
            txtNewURL.Text = "";
            txtNewURL.Visible = false;

            lblSelectedUsername.Visible = true;
            txtSelectedUsername.Text = WSUsername;
            txtSelectedUsername.Visible = true;
            txtSelectedUsername.ReadOnly = false;
            txtNewUsername.Text = "";
            txtNewUsername.Visible = false;

            lblSelectedPassword.Visible = true;
            txtSelectedPassword.Visible = true;
            txtSelectedPassword2.Visible = true;
            txtSelectedPassword.ReadOnly = false;
            txtSelectedPassword2.ReadOnly = false;
            txtNewPassword.Text = "";
            txtNewPassword2.Text = "";
            txtNewPassword.Visible = false;
            txtNewPassword2.Visible = false;

            btnCancelWebsitesService.Visible = true;
            btnSaveWebsitesService.Visible = true;
            btnSaveWebsitesService.ValidationGroup = "vgSaveWebsitesService";
            btnAddNewWebsitesService.Visible = false;
            btnEditWebsitesService.Visible = false;
        }
        else
        {
            lblWebsitesServiceMsg.Visible = true;
            lblWebsitesServiceMsg.Text = "No item selected to be edited";
        }
    }

    //Save - Button Event
    protected void btnSaveWebsitesService_Click(object sender, ImageClickEventArgs e)
    {
        SaveWebsitesServiceButtonEvent();
    }
    //Save - Button Function
    private void SaveWebsitesServiceButtonEvent()
    {
        if (lbWebsitesService.SelectedIndex == -1)
        {
            if (ValidateData(txtNewWebsitesService))
                AddNewWebsitesService();
            else
            {
                lblWebsitesServiceMsg.Text = "Please enter the new WebsitesService name";
                lblWebsitesServiceMsg.Visible = true;
            }
        }
        else
        {
            if (ValidateData(txtSelectedWebsitesService))
                UpdateSelectedWebsitesService();
            else
            {
                lblWebsitesServiceMsg.Text = "Please enter the WebsitesService name";
                lblWebsitesServiceMsg.Visible = true;
            }
        }
    }

    //Cancel - Button Event
    protected void btnCancelWebsitesService_Click(object sender, ImageClickEventArgs e)
    {
        CancelWebsitesServiceButtonEvent();
    }
    //Cancel - Button Function
    private void CancelWebsitesServiceButtonEvent()
    {
        lbWebsitesService.SelectedIndex = -1;

        txtWebsitesServiceID.Text = "";
        
        lblSelectedWebsitesService.Visible = true;
        txtSelectedWebsitesService.Text = "";
        txtSelectedWebsitesService.Visible = true;
        txtSelectedWebsitesService.ReadOnly = true;
        txtNewWebsitesService.Text = "";
        txtNewWebsitesService.Visible = false;

        lblSelectedURL.Visible = true;
        txtSelectedURL.Text = "";
        txtSelectedURL.Visible = true;
        txtSelectedURL.ReadOnly = true;
        txtNewURL.Text = "";
        txtNewURL.Visible = false;

        lblSelectedUsername.Visible = true;
        txtSelectedUsername.Text = "";
        txtSelectedUsername.Visible = true;
        txtSelectedUsername.ReadOnly = true;
        txtNewUsername.Text = "";
        txtNewUsername.Visible = false;

        lblSelectedPassword.Visible = true;
        txtSelectedPassword.Text = "";
        txtSelectedPassword.Visible = true;
        txtSelectedPassword.ReadOnly = true;
        txtNewPassword.Text = "";
        txtNewPassword.Visible = false;
        txtSelectedPassword2.Text = "";
        txtSelectedPassword2.Visible = true;
        txtSelectedPassword2.ReadOnly = true;
        txtNewPassword2.Text = "";
        txtNewPassword2.Visible = false;

        btnCancelWebsitesService.Visible = false;
        btnSaveWebsitesService.Visible = false;
        btnAddNewWebsitesService.Visible = true;
        btnEditWebsitesService.Visible = true;
    }

    //Add New Function
    private void AddNewWebsitesService()
    {
        WebsitesServices NewWebsitesService = new WebsitesServices();
        NewWebsitesService.WSName = txtNewWebsitesService.Text;
        NewWebsitesService.WSURL = txtNewURL.Text;
        NewWebsitesService.WSUsername = txtNewUsername.Text;
        NewWebsitesService.WSPassword = txtSelectedPassword.Text;

        if (NewWebsitesService.CheckWSNameExistance() == false)
        {
            NewWebsitesService.AddNewWebsitesService();
            lblWebsitesServiceMsg.Text = "Added Successfully";
            lbWebsitesService.DataBind();
            lbWebsitesService.SelectedIndex = -1;
            btnAddNewWebsitesService.Visible = true;
            btnEditWebsitesService.Visible = true;
            
            btnCancelWebsitesService.Visible = false;
            btnSaveWebsitesService.Visible = false;

            lblSelectedWebsitesService.Visible = true;
            txtSelectedWebsitesService.Visible = true;
            txtNewWebsitesService.Visible = false;
            txtSelectedWebsitesService.ReadOnly = true;

            lblSelectedURL.Visible = true;
            txtSelectedURL.Visible = true;
            txtNewURL.Visible = false;
            txtSelectedURL.ReadOnly = true;

            lblSelectedUsername.Visible = true;
            txtSelectedUsername.Visible = true;
            txtNewUsername.Visible = false;
            txtSelectedUsername.ReadOnly = true;

            lblSelectedPassword.Visible = true;
            txtSelectedPassword.Visible = true;
            txtNewPassword.Visible = false;
            txtSelectedPassword.ReadOnly = true;
            txtSelectedPassword2.Visible = true;
            txtNewPassword2.Visible = false;
            txtSelectedPassword2.ReadOnly = true;
        }
        else
            lblWebsitesServiceMsg.Text = "This name exists before";
        lblWebsitesServiceMsg.Visible = true;
    }
    //Update Function
    private void UpdateSelectedWebsitesService()
    {
        WebsitesServices CurrentWebsitesService = new WebsitesServices();
        CurrentWebsitesService.WSID = int.Parse(txtWebsitesServiceID.Text);
        CurrentWebsitesService.WSName = txtSelectedWebsitesService.Text;
        CurrentWebsitesService.WSURL = txtSelectedURL.Text;
        CurrentWebsitesService.WSUsername = txtSelectedUsername.Text;
        CurrentWebsitesService.WSPassword = txtSelectedPassword.Text;

        if (CurrentWebsitesService.CheckUpdatedWSNameExistance() == false)
        {
            CurrentWebsitesService.UpdateWebsitesService();
            lblWebsitesServiceMsg.Text = "Updated Successfully";
            lbWebsitesService.DataBind();

            lbWebsitesService.SelectedIndex = -1;

            txtWebsitesServiceID.Text = "";

            lblSelectedWebsitesService.Visible = true;
            txtSelectedWebsitesService.Text = "";
            txtSelectedWebsitesService.Visible = true;
            txtSelectedWebsitesService.ReadOnly = true;
            txtNewWebsitesService.Text = "";
            txtNewWebsitesService.Visible = false;

            lblSelectedURL.Visible = true;
            txtSelectedURL.Text = "";
            txtSelectedURL.Visible = true;
            txtSelectedURL.ReadOnly = true;
            txtNewURL.Text = "";
            txtNewURL.Visible = false;

            lblSelectedUsername.Visible = true;
            txtSelectedUsername.Text = "";
            txtSelectedUsername.Visible = true;
            txtSelectedUsername.ReadOnly = true;
            txtNewUsername.Text = "";
            txtNewUsername.Visible = false;

            lblSelectedPassword.Visible = true;
            txtSelectedPassword.Text = "";
            txtSelectedPassword.Visible = true;
            txtSelectedPassword.ReadOnly = true;
            txtNewPassword.Text = "";
            txtNewPassword.Visible = false;
            txtSelectedPassword2.Text = "";
            txtSelectedPassword2.Visible = true;
            txtSelectedPassword2.ReadOnly = true;
            txtNewPassword2.Text = "";
            txtNewPassword2.Visible = false;

            btnCancelWebsitesService.Visible = false;
            btnSaveWebsitesService.Visible = false;
            btnAddNewWebsitesService.Visible = true;
            btnEditWebsitesService.Visible = true;
            //btnAddNewWebsitesService.Visible = true;
            //btnEditWebsitesService.Visible = true;

            //btnCancelWebsitesService.Visible = false;
            //btnSaveWebsitesService.Visible = false;

            //lblSelectedWebsitesService.Visible = true;
            //txtSelectedWebsitesService.Visible = true;
            //txtNewWebsitesService.Visible = false;
            //txtSelectedWebsitesService.ReadOnly = true;

            //lblSelectedURL.Visible = true;
            //txtSelectedURL.Visible = true;
            //txtNewURL.Visible = false;
            //txtSelectedURL.ReadOnly = true;

            //lblSelectedUsername.Visible = true;
            //txtSelectedUsername.Visible = true;
            //txtNewUsername.Visible = false;
            //txtSelectedUsername.ReadOnly = true;

            //lblSelectedPassword.Visible = true;
            //txtSelectedPassword.Visible = true;
            //txtNewPassword.Visible = false;
            //txtSelectedPassword.ReadOnly = true;
            //txtSelectedPassword2.Visible = true;
            //txtNewPassword2.Visible = false;
            //txtSelectedPassword2.ReadOnly = true;
        }
        else
            lblWebsitesServiceMsg.Text = "This name exists before";
        lblWebsitesServiceMsg.Visible = true;
    }

    #endregion

    //protected void ibtnManageTitle1_Click(object sender, ImageClickEventArgs e)
    //{
    //    ibtnManageTitle1.Visible = false;
    //    ibtnManageTitle2.Visible = true;
    //}
    //protected void ibtnManageTitle2_Click(object sender, ImageClickEventArgs e)
    //{
    //    ibtnManageTitle1.Visible = true;
    //    ibtnManageTitle2.Visible = false;
    //}
}
