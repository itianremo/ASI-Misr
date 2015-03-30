using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Office.DAL;
using System.Collections;
using System.Web.UI.WebControls.WebParts;
using System.Threading.Tasks;
using System.Security.Permissions;


public partial class Home : Office.BLL.HomeBLL
{
	protected void Page_Load(object sender, EventArgs e)
	{
		
		CheckUserSession();
		
		if (!IsPostBack)
		{
			//lblVersionInfo.Text = GetVersionInfo();
			//if (wpOpenTasks != null)
			//   if (wpOpenTasks.WebParts.Count > 0)
			//      wpOpenTasks.WebParts[0].Title = "My Open Tasks";
			//if (wpCalls != null)
			//   if (wpCalls.WebParts.Count > 0)
			//      wpCalls.WebParts[0].Title = "My Calls";
			//if (wpTopAccounts != null)
			//   if (wpTopAccounts.WebParts.Count > 0)
			//      wpTopAccounts.WebParts[0].Title = "Top Accounts";
			//if (wpCS != null)
			//   if (wpCS.WebParts.Count > 0)
			//      wpCS.WebParts[0].Title = "Customer Support";

			//ViewState["ASIURL"] = ConfigurationManager.AppSettings["ELSData.DataService"].ToString();
			//ViewState["ASIWSUserName"] = ConfigurationManager.AppSettings["UserNameELS"].ToString();
			//ViewState["ASIWSPassword"] = ConfigurationManager.AppSettings["PasswordELS"].ToString();
		}

		string CurrentPage = "Home";
		//////
		//ucUserTabs.CurrentPage = CurrentPage;
		//ucUserTabs.btnAccountsEvent += new EventHandler(ucUserTabs_btnAccountsEvent);
		//ucUserTabs.btnAccountListsEvent += new EventHandler(ucUserTabs_btnAccountListsEvent);
		//ucUserTabs.btnContantsEvent += new EventHandler(ucUserTabs_btnContantsEvent);
		//ucUserTabs.btnContactListsEvent += new EventHandler(ucUserTabs_btnContactListsEvent);
		//ucUserTabs.btnBranchesEvent += new EventHandler(ucUserTabs_btnBranchesEvent);
		//ucUserTabs.btnBranchesDetailsEvent += new EventHandler(ucUserTabs_btnBranchesDetailsEvent);
		//ucUserTabs.btnCallsEvent += new EventHandler(ucUserTabs_btnCallsEvent);
		//ucUserTabs.btnManageApplicationEvent += new EventHandler(ucUserTabs_btnManageApplicationEvent);
		////////

		//imgbtnSignOut.Attributes.Add("onmouseover", "this.src='Images/CloseBut_pressed.jpg'");
		//imgbtnSignOut.Attributes.Add("onmouseout", "this.src='Images/CloseBut_normal.jpg'");

		//display.Attributes.Add("onmouseover", "this.src='Images/Display-o.jpg'");
		//display.Attributes.Add("onmouseout", "this.src='Images/Display-n.jpg'");

		//Catalog.Attributes.Add("onmouseover", "this.src='Images/Catalog-o.jpg'");
		//Catalog.Attributes.Add("onmouseout", "this.src='Images/Catalog-n.jpg'");

		//Design.Attributes.Add("onmouseover", "this.src='Images/Design-o.jpg'");
		//Design.Attributes.Add("onmouseout", "this.src='Images/Design-n.jpg'");
	}

	private void ucUserTabs_btnAccountsEvent(object sender, EventArgs e)
	{
		Response.Redirect("Accounts.aspx");
	}

	private void ucUserTabs_btnAccountListsEvent(object sender, EventArgs e)
	{
		Response.Redirect("AccountLists.aspx");
	}

	private void ucUserTabs_btnContantsEvent(object sender, EventArgs e)
	{
		Response.Redirect("Contacts.aspx");
	}

	private void ucUserTabs_btnContactListsEvent(object sender, EventArgs e)
	{
		Response.Redirect("ContactLists.aspx");
	}

	private void ucUserTabs_btnBranchesEvent(object sender, EventArgs e)
	{
		Response.Redirect("Branches.aspx");
	}

	private void ucUserTabs_btnBranchesDetailsEvent(object sender, EventArgs e)
	{
		Response.Redirect("BranchDetails.aspx");
	}

	private void ucUserTabs_btnCallsEvent(object sender, EventArgs e)
	{
		Response.Redirect("CallsManagement.aspx");
	}

	private void ucUserTabs_btnManageApplicationEvent(object sender, EventArgs e)
	{
		Response.Redirect("ManageApplication.aspx");
	}

	protected void imgbtnSignOut_Click(object sender, ImageClickEventArgs e)
	{
		SignOut();
	}

	protected void display_Click(object sender, ImageClickEventArgs e)
	{
		try
		{
			WebPartManager1.DisplayMode = WebPartManager.BrowseDisplayMode;
		}
		catch (Exception ex) { string msg = ex.Message; }

	}
	protected void Catalog_Click(object sender, ImageClickEventArgs e)
	{
		try
		{
			WebPartManager1.DisplayMode = WebPartManager.CatalogDisplayMode;
		}
		catch (Exception ex) { string msg = ex.Message; }
	}protected void BtnResetLayout_Click(object sender, EventArgs e)
	{

	}
	protected void Edit_Click(object sender, EventArgs e)
	{
		WebPartManager1.DisplayMode = WebPartManager.EditDisplayMode;
	}
	protected void Design_Click(object sender, ImageClickEventArgs e)
	{
		try
		{
			WebPartManager1.DisplayMode = WebPartManager.DesignDisplayMode;
		}
		catch (Exception ex) { string msg = ex.Message; }
	}
	//#region [Manage WebPart Zone]
	//// Use a field to reference the current WebPartManager control. 
	//WebPartManager _manager;
	////protected void Page_Init(object sender, EventArgs e)
	////{
	////   Page.InitComplete += new EventHandler(InitComplete);
	////}
	//protected void Page_InitComplete(object sender, EventArgs e)
	//{
	//   //_manager = WebPartManager.GetCurrentWebPartManager(Page);
	//   //String browseModeName = WebPartManager.BrowseDisplayMode.Name;
	//   //// Fill the drop-down list with the names of supported display modes. 
	//   //foreach (WebPartDisplayMode mode in
	//   //_manager.SupportedDisplayModes)
	//   //{
	//   //   String modeName = mode.Name;
	//   //   // Make sure a mode is enabled before adding it. 
	//   //   if (mode.IsEnabled(_manager))
	//   //   {
	//   //      ListItem item = new ListItem(modeName, modeName);
	//   //      DisplayModeDropdown.Items.Add(item);
	//   //      //DisplayModeDropdown.Items.Add(item);
	//   //   }
	//   //}
	//   //// If Shared scope is allowed for this user, display the 
	//   //// scope-switching UI and select the appropriate radio 
	//   //// button for the current user scope. 
	//   //if (_manager.Personalization.CanEnterSharedScope)
	//   //{
	//   //   Panel2.Visible = true;
	//   //   if (_manager.Personalization.Scope ==
	//   //   PersonalizationScope.User)
	//   //      RadioButton1.Checked = true;
	//   //   else
	//   //      RadioButton2.Checked = true;
	//   //}
	//}
	////protected void InitComplete(object sender, System.EventArgs e)
	////{
	////   _manager = WebPartManager.GetCurrentWebPartManager(Page);
	////   String browseModeName = WebPartManager.BrowseDisplayMode.Name;
	////   // Fill the drop-down list with the names of supported display modes. 
	////   foreach (WebPartDisplayMode mode in
	////   _manager.SupportedDisplayModes)
	////   {
	////      String modeName = mode.Name;
	////      // Make sure a mode is enabled before adding it. 
	////      if (mode.IsEnabled(_manager))
	////      {
	////         ListItem item = new ListItem(modeName, modeName);
	////         DisplayModeDropdown.Items.Add(item);
	////      }
	////   }
	////   // If Shared scope is allowed for this user, display the 
	////   // scope-switching UI and select the appropriate radio 
	////   // button for the current user scope. 
	////   if (_manager.Personalization.CanEnterSharedScope)
	////   {
	////      Panel2.Visible = true;
	////      if (_manager.Personalization.Scope ==
	////      PersonalizationScope.User)
	////         RadioButton1.Checked = true;
	////      else
	////         RadioButton2.Checked = true;
	////   }
	////}

	//// Change the page to the selected display mode. 
	//protected void DisplayModeDropdown_SelectedIndexChanged(object sender, EventArgs e)
	//{
	//   String selectedMode = DisplayModeDropdown.SelectedValue;
	//   WebPartDisplayMode mode =
	//       _manager.SupportedDisplayModes[selectedMode];
	//   if (mode != null)
	//      _manager.DisplayMode = mode;
	//}
	//// Set the selected item equal to the current display mode. 
	//protected void Page_PreRender(object sender, EventArgs e)
	//{
	//   ListItemCollection items = DisplayModeDropdown.Items;
	//   int selectedIndex =
	//   items.IndexOf(items.FindByText(_manager.DisplayMode.Name));
	//   DisplayModeDropdown.SelectedIndex = selectedIndex;
	//}
	//// Reset all of a user's personalization data for the page. 
	//protected void LinkButton1_Click(object sender, EventArgs e)
	//{
	//   _manager.Personalization.ResetPersonalizationState();
	//}
	//// If not in User personalization scope, toggle into it. 
	//protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
	//{
	//   if (_manager.Personalization.Scope == PersonalizationScope.Shared)
	//      _manager.Personalization.ToggleScope();
	//}

	//// If not in Shared scope, and if user has permission, toggle 
	//// the scope. 
	//protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
	//{
	//   if (_manager.Personalization.CanEnterSharedScope &&
	//       _manager.Personalization.Scope == PersonalizationScope.User)
	//      _manager.Personalization.ToggleScope();
	//}

	//#endregion
	//protected void DisplayModeDropdown_Load(object sender, EventArgs e)
	//{
	//   _manager = WebPartManager.GetCurrentWebPartManager(Page);
	//   String browseModeName = WebPartManager.BrowseDisplayMode.Name;
	//   // Fill the drop-down list with the names of supported display modes. 
	//   foreach (WebPartDisplayMode mode in
	//   _manager.SupportedDisplayModes)
	//   {
	//      String modeName = mode.Name;
	//      // Make sure a mode is enabled before adding it. 
	//      if (mode.IsEnabled(_manager))
	//      {
	//         ListItem item = new ListItem(modeName, modeName);
	//         DisplayModeDropdown.Items.Add(item);
	//         //DisplayModeDropdown.Items.Add(item);
	//      }
	//   }
	//   // If Shared scope is allowed for this user, display the 
	//   // scope-switching UI and select the appropriate radio 
	//   // button for the current user scope. 
	//   if (_manager.Personalization.CanEnterSharedScope)
	//   {
	//      Panel2.Visible = true;
	//      if (_manager.Personalization.Scope ==
	//      PersonalizationScope.User)
	//         RadioButton1.Checked = true;
	//      else
	//         RadioButton2.Checked = true;
	//   }
	//}

	
}