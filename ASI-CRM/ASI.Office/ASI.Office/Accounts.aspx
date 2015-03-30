<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Accounts.aspx.cs"
	Inherits="Accounts" Theme="Red" MasterPageFile="~/MasterLayout.master" Title="Accounts" %>

<%@ MasterType VirtualPath="~/MasterLayout.master" %>
<%@ Register Src="Controls/AutoCompleteSearch.ascx" TagName="AutoCompleteSearch"
	TagPrefix="uc3" %>
<%@ Register Src="Controls/TransToolBar.ascx" TagName="TransToolBar" TagPrefix="uc1" %>
<asp:Content ID="Head" runat="server" ContentPlaceHolderID="head">
	<script type="text/javascript" src="Scripts/Scripts.js"></script>
</asp:Content>
<asp:Content ID="Main" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
	<div class="header">
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate>
				<table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
					<tr align="left" style="width: 95%; height: 30px;">
						<td bgcolor="#000000" style="width: 5%">
						</td>
						<td valign="top" align="right" style="width: 10%; white-space: nowrap; padding-bottom: 5px;">
							<uc1:TransToolBar ID="ucTransToolBar" runat="server" />
						</td>
						<td valign="top" align="left" style="text-align: left; width: 5%; white-space: nowrap;">
							<asp:ImageButton ID="btnAdvancedSearch" AlternateText="Advanced Search" runat="server"
								ImageUrl="~/Images/AdvancedSearch-n.jpg" />
						</td>
						<td valign="top" align="left" style="text-align: left; width: 5%; white-space: nowrap;">
							<asp:ImageButton ID="btnReset" AlternateText="Reset" runat="server" OnClick="btnReset_Click"
								ImageUrl="~/Images/Reset-n.jpg" />
						</td>
						<td valign="top" align="left" style="text-align: left; width: 5%; white-space: nowrap;">
							<asp:ImageButton ID="btnTag" AlternateText="Tag" runat="server" OnClick="btnTag_Click"
								ImageUrl="~/Images/Tag-n.jpg" />
						</td>
						<td align="left" style="text-align: left;">
							<asp:DropDownList ID="ddlAction" runat="server" AutoPostBack="True" CssClass="inputs"
								OnSelectedIndexChanged="ddlAction_SelectedIndexChanged" Width="80px">
								<asp:ListItem Selected="True" Value="0">Action</asp:ListItem>
								<asp:ListItem Value="1">Send Email</asp:ListItem>
							</asp:DropDownList>
						</td>
						<td style="text-align: right">
							<asp:UpdatePanel ID="UpdatePanel2" runat="server">
								<ContentTemplate>
									<uc3:AutoCompleteSearch ID="ucAutoCompleteSearch" runat="server" />
								</ContentTemplate>
							</asp:UpdatePanel>
						</td>
					</tr>
					<tr>
						<td colspan="7">
							<ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server"
								CollapseControlID="btnAdvancedSearch" TargetControlID="pnlAdvancedSearch" ExpandControlID="btnAdvancedSearch"
								Collapsed="True" BehaviorID="CollapsiblePanelExtender1_b">
							</ajaxToolkit:CollapsiblePanelExtender>
							<asp:Panel ID="pnlAdvancedSearch" runat="server">
								<table border="1" bordercolor="white" cellspacing="0" cellpadding="0" style="width: 100%">
									<tr>
										<td style="text-align: left; background-image: url(Images/accountDetails_35.jpg);
											vertical-align: middle; height: 32px; margin: 1px; padding-left: 5px;">
											<asp:UpdatePanel ID="UpdatePanel5" runat="server">
												<ContentTemplate>
													<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="13px"
														ForeColor="White" Text="Filter"></asp:Label>
													<asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" CssClass="inputs"
														TabIndex="5" Width="100px" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
														<asp:ListItem>Status</asp:ListItem>
													</asp:DropDownList>
													&nbsp;<asp:DropDownList ID="ddlBusSector" runat="server" AutoPostBack="True" CssClass="inputs"
														Width="210px" OnSelectedIndexChanged="ddlBusSector_SelectedIndexChanged">
														<asp:ListItem Selected="True">BusSector</asp:ListItem>
													</asp:DropDownList>
													<asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" CssClass="inputs"
														Width="200px" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" OnDataBound="ddlCountry_DataBound">
														<asp:ListItem Selected="True">Country</asp:ListItem>
													</asp:DropDownList>
													<asp:DropDownList ID="ddlState" runat="server" CssClass="inputs" Width="150px" Enabled="False"
														AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
														<asp:ListItem Selected="True">State</asp:ListItem>
													</asp:DropDownList>
													<asp:DropDownList ID="ddlNotes" runat="server" AutoPostBack="True" CssClass="inputs"
														Width="80px" OnSelectedIndexChanged="ddlNotes_SelectedIndexChanged">
														<asp:ListItem Selected="True" Value="0">All</asp:ListItem>
														<asp:ListItem Value="1">With Notes</asp:ListItem>
														<asp:ListItem Value="2">No Notes</asp:ListItem>
													</asp:DropDownList>
												</ContentTemplate>
											</asp:UpdatePanel>
										</td>
									</tr>
								</table>
							</asp:Panel>
						</td>
					</tr>
				</table>
			</ContentTemplate>
		</asp:UpdatePanel>
	</div>
	<div class="ui-layout-content">
		<asp:UpdatePanel ID="UpdatePanel4" runat="server">
			<ContentTemplate>
				<asp:GridView ID="gvAccounts" runat="server" AutoGenerateColumns="False" Width="98%"
					BorderColor="Maroon" BorderStyle="Solid" AllowPaging="True" AllowSorting="True"
					DataKeyNames="AccountID,Email" OnPageIndexChanging="gvAccounts_PageIndexChanging"
					OnRowCreated="gvAccounts_RowCreated" OnSelectedIndexChanged="gvAccounts_SelectedIndexChanged"
					PageSize="25" OnRowDataBound="gvAccounts_RowDataBound" OnSorting="gvAccounts_Sorting"
					CellPadding="4">
					<Columns>
						<asp:TemplateField HeaderText="Select">
							<ItemTemplate>
								<asp:CheckBox ID="CbEmail" runat="server" ToolTip='<%# Eval("AccountID").ToString() %>'
									Checked='<%# Eval("Tag") %>' OnCheckedChanged="chkboxTag_CheckedChanged" AutoPostBack="True" />
							</ItemTemplate>
							<HeaderTemplate>
								<asp:UpdatePanel ID="CA" runat="server">
									<ContentTemplate>
										<asp:CheckBox ID="cbxEmailAll" runat="server" AutoPostBack="True" Text="All" OnCheckedChanged="cbxEmailAll_CheckedChanged"
											Width="50px" />
									</ContentTemplate>
								</asp:UpdatePanel>
							</HeaderTemplate>
							<HeaderStyle Width="5%" />
						</asp:TemplateField>
						<asp:BoundField DataField="AccountName" HeaderText="Company/Agency" SortExpression="AccountName">
							<HeaderStyle Width="25%" HorizontalAlign="Center" />
							<ItemStyle HorizontalAlign="Left" />
						</asp:BoundField>
						<asp:BoundField DataField="StatusName" HeaderText="Status" SortExpression="StatusName">
							<HeaderStyle HorizontalAlign="Center" Width="9%" />
						</asp:BoundField>
						<asp:BoundField HeaderText="Notes" DataFormatString="{0:d}" HtmlEncode="False" DataField="LastAccountNoteDate"
							SortExpression="LastAccountNoteDate">
							<HeaderStyle Width="7%" HorizontalAlign="Center" />
							<ItemStyle HorizontalAlign="Center" />
						</asp:BoundField>
						<asp:BoundField DataField="City" HeaderText="City" SortExpression="City">
							<HeaderStyle Width="7%" HorizontalAlign="Center" />
							<ItemStyle HorizontalAlign="Left" />
						</asp:BoundField>
						<asp:BoundField DataField="State" HeaderText="State" SortExpression="State">
							<HeaderStyle Width="8%" HorizontalAlign="Center" />
							<ItemStyle HorizontalAlign="Left" />
						</asp:BoundField>
						<asp:BoundField DataField="Phone" HeaderText="Telephone">
							<HeaderStyle Width="7%" HorizontalAlign="Center" />
							<ItemStyle HorizontalAlign="Right" />
						</asp:BoundField>
						<asp:BoundField DataField="Fax" HeaderText="Fax" Visible="False">
							<HeaderStyle Width="10%" />
							<ItemStyle HorizontalAlign="Right" />
						</asp:BoundField>
						<asp:BoundField DataField="BusinessSectorName" HeaderText="Business_Sector" SortExpression="BusinessSectorName">
							<ItemStyle HorizontalAlign="Left" />
							<HeaderStyle Width="12%" HorizontalAlign="Center" />
						</asp:BoundField>
						<asp:BoundField DataField="CountryName" HeaderText="Country" SortExpression="CountryName">
							<ItemStyle HorizontalAlign="Left" />
							<HeaderStyle Width="8%" HorizontalAlign="Center" />
						</asp:BoundField>
						<asp:TemplateField HeaderText="Web">
							<EditItemTemplate>
								<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WebSite") %>'></asp:TextBox>
							</EditItemTemplate>
							<HeaderStyle Width="17%" HorizontalAlign="Center" />
							<ItemTemplate>
								&nbsp;<asp:HyperLink ID="lnkWebSite" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "WebSite") %>'
									Target="_blank" Text='<%# Bind("WebSite") %>'></asp:HyperLink>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Left" />
						</asp:TemplateField>
						<asp:BoundField DataField="CountryID" HeaderText="CountryID" SortExpression="CountryID"
							Visible="False">
							<HeaderStyle Width="10%" />
						</asp:BoundField>
						<asp:BoundField DataField="AccoutnManagerAssignedDate" HeaderText="AccoutnManagerAssignedDate"
							SortExpression="AccoutnManagerAssignedDate" Visible="False" />
						<asp:BoundField DataField="EditByName" HeaderText="EditByName" SortExpression="EditByName"
							Visible="False" />
						<asp:BoundField DataField="EnterDate" HeaderText="EnterDate" SortExpression="EnterDate"
							Visible="False" />
						<asp:BoundField DataField="Street2" HeaderText="Street2" SortExpression="Street2"
							Visible="False" />
						<asp:BoundField DataField="Street1" HeaderText="Street1" SortExpression="Street1"
							Visible="False" />
						<asp:BoundField DataField="AccountID" HeaderText="AccountID" SortExpression="AccountID"
							Visible="False" />
						<asp:BoundField DataField="AccountManagerEditByID" HeaderText="AccountManagerEditByID"
							SortExpression="AccountManagerEditByID" Visible="False" />
						<asp:BoundField DataField="EnterByID" HeaderText="EnterByID" SortExpression="EnterByID"
							Visible="False" />
						<asp:BoundField DataField="AccountManagerName" HeaderText="AccountManagerName" SortExpression="AccountManagerName"
							Visible="False" />
						<asp:BoundField DataField="AccountManagerEditDate" HeaderText="AccountManagerEditDate"
							SortExpression="AccountManagerEditDate" Visible="False" />
						<asp:BoundField DataField="ReferedBy" HeaderText="ReferedBy" SortExpression="ReferedBy"
							Visible="False" />
						<asp:BoundField DataField="ZipCode" HeaderText="ZipCode" SortExpression="ZipCode"
							Visible="False" />
						<asp:BoundField DataField="IDStatus" HeaderText="IDStatus" SortExpression="IDStatus"
							Visible="False" />
						<asp:BoundField DataField="AccountManagerID" HeaderText="AccountManagerID" SortExpression="AccountManagerID"
							Visible="False" />
						<asp:BoundField DataField="BusSector" HeaderText="BusSector" SortExpression="BusSector"
							Visible="False" />
						<asp:BoundField DataField="TypeID" HeaderText="TypeID" SortExpression="TypeID" Visible="False" />
						<asp:BoundField DataField="EnteredByName" HeaderText="EnteredByName" SortExpression="EnteredByName"
							Visible="False" />
						<asp:BoundField DataField="AccountManagerEditByName" HeaderText="AccountManagerEditByName"
							SortExpression="AccountManagerEditByName" Visible="False" />
						<asp:BoundField DataField="EditByID" HeaderText="EditByID" SortExpression="EditByID"
							Visible="False" />
						<asp:BoundField DataField="EditDate" HeaderText="EditDate" SortExpression="EditDate"
							Visible="False" />
						<asp:BoundField DataField="StatusName" HeaderText="StatusName" SortExpression="StatusName"
							Visible="False" />
					</Columns>
					<RowStyle CssClass="GridNormalRowsStyle" />
					<SelectedRowStyle CssClass="SelectedRowColor" />
					<HeaderStyle CssClass="GridHeaderBackStyle" Font-Bold="True" Font-Names="Tahoma"
						Font-Size="12px" ForeColor="White" />
					<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
						NextPageText="Next" PreviousPageText="Previous" />
					<PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Center" />
				</asp:GridView>
				<asp:ObjectDataSource ID="odsAccounts" runat="server" SelectMethod="SelectAccounts"
					TypeName="Office.BLL.AccountsBLL">
					<SelectParameters>
						<asp:SessionParameter Name="CurrentAccount" SessionField="Account" Type="Object" />
					</SelectParameters>
				</asp:ObjectDataSource>
				<asp:Label ID="lblTransMsg" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="14px"
					ForeColor="#004000" Text="Transaction Saved Successfully" Visible="False"></asp:Label>
			</ContentTemplate>
		</asp:UpdatePanel>
	</div>
	<div class="footer">
	</div>
</asp:Content>
