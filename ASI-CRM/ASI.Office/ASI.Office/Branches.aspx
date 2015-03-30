<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Branches.aspx.cs" EnableEventValidation="false"
	Inherits="Branches" Theme="Red" MasterPageFile="~/MasterLayout.master" Title="Branches" %>

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
				<uc1:TransToolBar ID="ucTransToolBar" runat="server" />
			</ContentTemplate>
		</asp:UpdatePanel>
		<asp:UpdatePanel ID="UpdatePanel2" runat="server">
			<ContentTemplate>
				<uc3:AutoCompleteSearch ID="ucAutoCompleteSearch" runat="server" />
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
	</div>
	<div class="ui-layout-content">
		<asp:UpdatePanel ID="UpdatePanel4" runat="server">
			<ContentTemplate>
				<asp:GridView ID="gvBranches" runat="server" AutoGenerateColumns="False" Width="98%"
					BorderColor="Maroon" BorderStyle="Solid" AllowPaging="True" AllowSorting="True"
					DataKeyNames="BranchID" OnPageIndexChanging="gvBranches_PageIndexChanging" OnRowCreated="gvBranches_RowCreated"
					OnSelectedIndexChanged="gvBranches_SelectedIndexChanged" PageSize="25" OnRowDataBound="gvBranches_RowDataBound"
					OnSorting="gvBranches_Sorting" CellPadding="4">
					<Columns>
						<asp:BoundField DataField="BranchName" HeaderText="Branch Name" SortExpression="BranchName">
							<HeaderStyle Width="25%" HorizontalAlign="Center" />
							<ItemStyle HorizontalAlign="Left" />
						</asp:BoundField>
						<asp:BoundField DataField="IDStatus" HeaderText="Status" SortExpression="IDStatus">
							<HeaderStyle HorizontalAlign="Center" Width="9%" />
						</asp:BoundField>
						<asp:BoundField HeaderText="Notes" DataFormatString="{0:d}" HtmlEncode="False" DataField="LastBranchNoteDate"
							SortExpression="LastBranchNoteDate">
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
						<asp:BoundField DataField="BussinessSectorName" HeaderText="Business_Sector" SortExpression="BussinessSectorName">
							<ItemStyle HorizontalAlign="Left" />
							<HeaderStyle Width="12%" HorizontalAlign="Center" />
						</asp:BoundField>
						<asp:BoundField DataField="CountryName" HeaderText="Country" SortExpression="CountryName">
							<ItemStyle HorizontalAlign="Left" />
							<HeaderStyle Width="8%" HorizontalAlign="Center" />
						</asp:BoundField>
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
						<asp:BoundField DataField="BussinessSectorName" HeaderText="BusSector" SortExpression="BussinessSectorName"
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
				<asp:ObjectDataSource ID="odsBranches" runat="server" SelectMethod="SelectBranches"
					TypeName="Office.BLL.BranchesPageBLL">
					<SelectParameters>
						<asp:SessionParameter Name="CurrentBranch" SessionField="Branch" Type="Object" />
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
