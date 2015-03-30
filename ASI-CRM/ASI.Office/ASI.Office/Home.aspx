<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Theme="Red"
	MasterPageFile="~/MasterLayout.master" Inherits="Home" %>

<%@ MasterType VirtualPath="~/MasterLayout.master" %>
<%@ Register Src="~/controls/opentasks.ascx" TagPrefix="uc" TagName="OpenTasks" %>
<%@ Register Src="~/controls/topaccounts.ascx" TagPrefix="uc" TagName="TopAccounts" %>
<%@ Register Src="~/controls/mycalls.ascx" TagPrefix="uc" TagName="MyCalls" %>
<%@ Register Src="~/controls/customersupports.ascx" TagPrefix="uc" TagName="CustomerSupports" %>
<%@ Register Src="Controls/AutoCompleteSearch.ascx" TagName="AutoCompleteSearch"
	TagPrefix="uc3" %>
<%@ Register Src="Controls/UserTabs.ascx" TagName="UserTabs" TagPrefix="uc2" %>
<%@ Register Src="Controls/TransToolBar.ascx" TagName="TransToolBar" TagPrefix="uc1" %>
<asp:Content ID="Head" runat="server" ContentPlaceHolderID="head">
	<script type="text/javascript" src="Scripts/Scripts.js"></script>
</asp:Content>
<asp:Content ID="Main" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
	<asp:ScriptManagerProxy runat="server" ID="_ScriptManagerProxy" />
	<asp:WebPartManager ID="WebPartManager1" runat="server" />
	<div>
		<asp:ImageButton ID="display" AlternateText="display" runat="server" OnClick="display_Click"
			ImageUrl="~/Images/Display-n.jpg" />
		<asp:ImageButton ID="Catalog" AlternateText="Catalog" runat="server" OnClick="Catalog_Click"
			ImageUrl="~/Images/Catalog-n.jpg" />
		<asp:ImageButton ID="Design" AlternateText="Design" runat="server" OnClick="Design_Click"
			ImageUrl="~/Images/Design-n.jpg" />
		<asp:ImageButton Text="Edit Mode" ID="Edit" runat="server" OnClick="Edit_Click" ImageUrl="~/Images/Edit-n.jpg" />
		<asp:Button Text="Reset Layout" runat="server" ID="BtnResetLayout" Height="26px"
			OnClick="BtnResetLayout_Click" Visible="False" />
	</div>
	<table border="0" cellpadding="0" cellspacing="0" id="ZoneWapper">
		<tr>
			<td class="PartZone">
				<asp:WebPartZone ID="LeftZonePart" runat="server" BorderColor="#CCCCCC" Font-Names="Verdana"
					Padding="6" EmptyZoneTextStyle-Width="100%">
					<ZoneTemplate>
					</ZoneTemplate>
					<MenuLabelHoverStyle ForeColor="#E2DED6"></MenuLabelHoverStyle>
					<MenuLabelStyle ForeColor="White"></MenuLabelStyle>
					<MenuPopupStyle BackColor="#5D7B9D" BorderColor="#CCCCCC" BorderWidth="1px" Font-Names="Verdana"
						Font-Size="0.6em" />
					<MenuVerbHoverStyle BackColor="#F7F6F3" BorderColor="#CCCCCC" BorderWidth="1px" BorderStyle="Solid"
						ForeColor="#333333"></MenuVerbHoverStyle>
					<MenuVerbStyle BorderColor="#5D7B9D" BorderWidth="1px" BorderStyle="Solid" ForeColor="White">
					</MenuVerbStyle>
					<TitleBarVerbStyle Font-Size="0.6em" Font-Underline="False" ForeColor="White"></TitleBarVerbStyle>
					<EmptyZoneTextStyle Font-Size="0.8em" />
					<HeaderStyle HorizontalAlign="Center" Font-Size="0.7em" ForeColor="#CCCCCC"></HeaderStyle>
					<PartChromeStyle BackColor="#F7F6F3" BorderColor="#E2DED6" Font-Names="Verdana" ForeColor="White" />
					<PartStyle Font-Size="0.8em" ForeColor="#333333" />
					<PartTitleStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.8em" ForeColor="White" />
				</asp:WebPartZone>
			</td>
			<td class="PartZone">
				<asp:WebPartZone ID="RightZonePart" runat="server" BorderColor="#CCCCCC" Font-Names="Verdana"
					Padding="6" EmptyZoneTextStyle-Width="100%">
					<ZoneTemplate>
					</ZoneTemplate>
					<MenuLabelHoverStyle ForeColor="#E2DED6"></MenuLabelHoverStyle>
					<MenuLabelStyle ForeColor="White"></MenuLabelStyle>
					<MenuPopupStyle BackColor="#5D7B9D" BorderColor="#CCCCCC" BorderWidth="1px" Font-Names="Verdana"
						Font-Size="0.6em" />
					<MenuVerbHoverStyle BackColor="#F7F6F3" BorderColor="#CCCCCC" BorderWidth="1px" BorderStyle="Solid"
						ForeColor="#333333"></MenuVerbHoverStyle>
					<MenuVerbStyle BorderColor="#5D7B9D" BorderWidth="1px" BorderStyle="Solid" ForeColor="White">
					</MenuVerbStyle>
					<TitleBarVerbStyle Font-Size="0.6em" Font-Underline="False" ForeColor="White"></TitleBarVerbStyle>
					<EmptyZoneTextStyle Font-Size="0.8em"></EmptyZoneTextStyle>
					<HeaderStyle HorizontalAlign="Center" Font-Size="0.7em" ForeColor="#CCCCCC"></HeaderStyle>
					<PartChromeStyle BackColor="#F7F6F3" BorderColor="#E2DED6" Font-Names="Verdana" ForeColor="White">
					</PartChromeStyle>
					<PartStyle Font-Size="0.8em" ForeColor="#333333"></PartStyle>
					<PartTitleStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.8em" ForeColor="White">
					</PartTitleStyle>
				</asp:WebPartZone>
			</td>
		</tr>
	</table>
	<div style="clear: both;">
		<asp:CatalogZone ID="CatalogZone1" runat="server" BackColor="#F7F6F3" BorderColor="#CCCCCC"
			BorderWidth="1px" Font-Names="Verdana" Padding="6" HeaderText="Add Web Parts">
			<ZoneTemplate>
				<asp:DeclarativeCatalogPart ID="DeclarativeCatalogPart1" runat="server">
					<WebPartsTemplate>
						<div style="text-align: left;">
							<uc:CustomerSupports runat="server" ID="ucCustomerSupports" Title="Customer Supports" />
							<uc:MyCalls runat="server" ID="ucMyCalls" Title="My Calls" />
							<uc:OpenTasks runat="server" ID="ucOpenTasks" Title="Open Tasks" />
							<uc:TopAccounts runat="server" ID="ucTopAccounts" Title="Top Accounts" />
						</div>
					</WebPartsTemplate>
				</asp:DeclarativeCatalogPart>
			</ZoneTemplate>
			<PartLinkStyle Font-Size="0.8em" />
			<PartTitleStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.8em" ForeColor="White" />
			<EditUIStyle Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" />
			<PartStyle BorderColor="#F7F6F3" BorderWidth="5px" />
			<HeaderVerbStyle Font-Bold="False" Font-Size="0.8em" Font-Underline="False" ForeColor="#333333" />
			<PartChromeStyle BorderColor="#E2DED6" BorderStyle="Solid" BorderWidth="1px" />
			<EmptyZoneTextStyle Font-Size="0.8em" ForeColor="#333333" />
			<SelectedPartLinkStyle Font-Size="0.8em" />
			<VerbStyle Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" />
			<LabelStyle Font-Size="0.8em" ForeColor="#333333" />
			<FooterStyle BackColor="#E2DED6" HorizontalAlign="Right" />
			<HeaderStyle BackColor="#E2DED6" Font-Bold="True" Font-Size="0.8em" ForeColor="#333333" />
			<InstructionTextStyle Font-Size="0.8em" ForeColor="#333333" />
		</asp:CatalogZone>
		<asp:EditorZone ID="EditorZone1" runat="server">
			<ZoneTemplate>
				<asp:AppearanceEditorPart ID="AppearanceEditorPart1" runat="server" />
				<asp:LayoutEditorPart ID="LayoutEditorPart1" runat="server" />
				<asp:BehaviorEditorPart ID="BehaviorEditor" runat="server" />
			</ZoneTemplate>
			<PartStyle HorizontalAlign="Left" />
		</asp:EditorZone>
	</div>
</asp:Content>
