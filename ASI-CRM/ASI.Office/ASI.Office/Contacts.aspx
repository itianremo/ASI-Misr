<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Contacts.aspx.cs"
	Theme="Red" MasterPageFile="~/MasterLayout.master" Inherits="Contacts" %>

<%@ MasterType VirtualPath="~/MasterLayout.master" %>
<%@ Register Src="Controls/AutoCompleteSearch.ascx" TagName="AutoCompleteSearch"
	TagPrefix="uc3" %>
<%@ Register Src="Controls/UserTabs.ascx" TagName="UserTabs" TagPrefix="uc2" %>
<%@ Register Src="Controls/TransToolBar.ascx" TagName="TransToolBar" TagPrefix="uc1" %>
<asp:Content ID="Head" runat="server" ContentPlaceHolderID="head">
	<script type="text/javascript" src="Scripts/Scripts.js"></script>
</asp:Content>
<asp:Content ID="Main" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
	<div class="header">
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate>
				<table border="0" cellpadding="0" cellspacing="0">
					<tr>
						<td>
							<asp:CheckBox ID="cbxEmailAll" runat="server" AutoPostBack="True" Text="All" OnCheckedChanged="cbxEmailAll_CheckedChanged"
								Width="114px" />
						</td>
						<td>
							<uc1:TransToolBar ID="ucTransToolBar" runat="server" />
						</td>
						<td>
							<asp:ImageButton ID="btnAdvancedSearch" AlternateText="Advanced Search" runat="server"
								ImageUrl="~/Images/AdvancedSearch-n.jpg" />
						</td>
						<td>
							<asp:ImageButton ID="btnReset" AlternateText="Reset" runat="server" OnClick="btnReset_Click"
								ImageUrl="~/Images/Reset-n.jpg" />
						</td>
						<td>
							<asp:ImageButton ID="btnTagAll" runat="server" ImageUrl="~/Images/Tag-n.jpg" OnClick="btnTagAll_Click" />
						</td>
						<td>
							<asp:DropDownList ID="ddlAction" runat="server" AutoPostBack="True" Height="30" CssClass="inputs"
								OnSelectedIndexChanged="ddlAction_SelectedIndexChanged" Width="80px">
								<asp:ListItem Selected="True" Value="0">Action</asp:ListItem>
								<asp:ListItem Value="1">Send Email</asp:ListItem>
								<asp:ListItem Value="2">Schedule Call</asp:ListItem>
							</asp:DropDownList>
						</td>
					</tr>
				</table>
				<ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server"
					CollapseControlID="btnAdvancedSearch" TargetControlID="pnlAdvancedSearch" ExpandControlID="btnAdvancedSearch"
					Collapsed="True" BehaviorID="CollapsiblePanelExtender1_b">
				</ajaxToolkit:CollapsiblePanelExtender>
				<asp:Panel ID="pnlAdvancedSearch" runat="server">
					<table border="1" bordercolor="white" cellspacing="0" cellpadding="0" style="width: 98%">
						<tr>
							<td colspan="3" align="left" background="Images/accountDetails_35.jpg" valign="top">
								<table cellpadding="0" cellspacing="0" style="width: 100%">
									<tr>
										<td style="width: 40%; white-space: nowrap;">
											<asp:UpdatePanel ID="UpdatePanel2" runat="server">
												<ContentTemplate>
													<uc3:AutoCompleteSearch ID="ucAutoCompleteSearch" runat="server" />
												</ContentTemplate>
											</asp:UpdatePanel>
										</td>
										<td style="width: 20%; white-space: nowrap;">
											<asp:UpdatePanel ID="UpdatePanel3" runat="server">
												<ContentTemplate>
													<asp:ImageButton ID="btnUnTagAll" runat="server" ImageUrl="~/Images/accountDetails_31.jpg"
														OnClick="btnUnTagAll_Click" Visible="False" />
												</ContentTemplate>
											</asp:UpdatePanel>
										</td>
										<td style="width: 12%; white-space: nowrap;">
											<asp:UpdatePanel ID="UpdatePanel5" runat="server">
												<ContentTemplate>
													<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="13px"
														ForeColor="White" Text="Filter"></asp:Label>
													<asp:DropDownList ID="ddlTaged" runat="server" CssClass="inputs" AutoPostBack="True"
														OnSelectedIndexChanged="ddlTaged_SelectedIndexChanged">
														<asp:ListItem>Tagged</asp:ListItem>
														<asp:ListItem>Un-Tagged</asp:ListItem>
														<asp:ListItem Selected="True">All</asp:ListItem>
													</asp:DropDownList>
												</ContentTemplate>
											</asp:UpdatePanel>
										</td>
										<td style="width: 28%; white-space: nowrap;">
											<asp:UpdatePanel ID="UpdatePanel6" runat="server">
												<ContentTemplate>
													<asp:Label ID="lblNotes" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="13px"
														ForeColor="White" Text="Notes"></asp:Label>
													<asp:DropDownList ID="ddlNotes" runat="server" CssClass="inputs" AutoPostBack="True"
														OnSelectedIndexChanged="ddlNotes_SelectedIndexChanged">
														<asp:ListItem Selected="True" Value="0">All</asp:ListItem>
														<asp:ListItem Value="1">With Notes</asp:ListItem>
														<asp:ListItem Value="2">No Notes</asp:ListItem>
													</asp:DropDownList>
												</ContentTemplate>
											</asp:UpdatePanel>
										</td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
				</asp:Panel>
			</ContentTemplate>
		</asp:UpdatePanel>
		<asp:Label ID="lblTransMsg" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="14px"
			ForeColor="#004000" Text="Transaction Saved Successfully" Visible="False"></asp:Label>
	</div>
	<div class="ui-layout-content">
		<asp:UpdatePanel ID="UpdatePanel4" runat="server">
			<ContentTemplate>
				<asp:GridView ID="gvContacts" runat="server" AutoGenerateColumns="False" Width="100%"
					UseAccessibleHeader="true" BorderColor="Maroon" BorderStyle="Solid" OnRowCreated="gvContacts_RowCreated"
					OnRowDataBound="gvContacts_RowDataBound" OnSorting="gvContacts_Sorting" AllowPaging="True"
					AllowSorting="True" DataKeyNames="ContactID" OnPageIndexChanging="gvContacts_PageIndexChanging"
					OnSelectedIndexChanged="gvContacts_SelectedIndexChanged" PageSize="25">
					<Columns>
						<asp:TemplateField>
							<ItemTemplate>
								<asp:CheckBox ID="CbEmail" runat="server" Checked='<%# Bind("Tag") %>' />
							</ItemTemplate>
							<HeaderStyle />
						</asp:TemplateField>
						<%--<asp:TemplateField SortExpression="Tag" HeaderText="Tag">
                        <EditItemTemplate>
                           <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Tag") %>' />
                        </EditItemTemplate>
                        <ItemTemplate>
                           <asp:CheckBox ID="chkboxTag" runat="server" Checked='<%# Bind("Tag") %>' />
                        </ItemTemplate>
                        <HeaderStyle Width="5%" />
                  </asp:TemplateField>--%>
						<asp:BoundField DataField="AccountName" HeaderText="Company/Agent" SortExpression="AccountName">
							<HeaderStyle />
							<ItemStyle HorizontalAlign="Left" />
						</asp:BoundField>
						<asp:BoundField HeaderText="Notes" DataFormatString="{0:d}" HtmlEncode="False" DataField="LastContactNoteDate"
							SortExpression="LastContactNoteDate">
							<HeaderStyle HorizontalAlign="Center" />
							<ItemStyle HorizontalAlign="Center" />
						</asp:BoundField>
						<asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName">
							<HeaderStyle />
							<ItemStyle HorizontalAlign="Left" />
						</asp:BoundField>
						<asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName">
							<HeaderStyle />
							<ItemStyle HorizontalAlign="Left" />
						</asp:BoundField>
						<asp:BoundField DataField="Phone" HeaderText="Telephone" SortExpression="Phone">
							<HeaderStyle />
							<ItemStyle HorizontalAlign="Right" />
						</asp:BoundField>
						<asp:BoundField DataField="Ext" HeaderText="Ext">
							<HeaderStyle />
							<ItemStyle HorizontalAlign="Right" />
						</asp:BoundField>
						<asp:BoundField DataField="TitleName" HeaderText="Title" SortExpression="TitleName">
							<HeaderStyle />
							<ItemStyle HorizontalAlign="Left" />
						</asp:BoundField>
						<asp:BoundField DataField="Fax" HeaderText="Fax" SortExpression="Fax">
							<HeaderStyle />
							<ItemStyle HorizontalAlign="Right" />
						</asp:BoundField>
						<asp:TemplateField HeaderText="Email" SortExpression="Email">
							<EditItemTemplate>
								<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
							</EditItemTemplate>
							<HeaderStyle />
							<ItemTemplate>
								<asp:HyperLink ID="lnkEmail" runat="server" NavigateUrl='<%# "mailto:"+DataBinder.Eval(Container.DataItem, "Email") %>'
									Text='<%# Bind("Email") %>'></asp:HyperLink>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Left" />
						</asp:TemplateField>
						<asp:BoundField DataField="IDStatus" HeaderText="IDStatus" />
						<asp:BoundField DataField="MiddleIntial" HeaderText="MiddleIntial" SortExpression="MiddleIntial"
							Visible="False" />
						<asp:BoundField DataField="ContactID" HeaderText="ContactID" SortExpression="ContactID"
							Visible="False" />
						<asp:BoundField DataField="Intial" HeaderText="Intial" SortExpression="Intial" Visible="False" />
						<asp:BoundField DataField="TitleID" HeaderText="TitleID" SortExpression="TitleID"
							Visible="False" />
						<asp:BoundField DataField="DepartmentID" HeaderText="DepartmentID" SortExpression="DepartmentID"
							Visible="False" />
						<asp:BoundField DataField="CellPhone" HeaderText="CellPhone" SortExpression="CellPhone"
							Visible="False" />
						<asp:BoundField DataField="AccountID" HeaderText="AccountID" SortExpression="AccountID"
							Visible="False" />
						<asp:BoundField DataField="EnteredbyID" HeaderText="EnteredbyID" SortExpression="EnteredbyID"
							Visible="False" />
						<asp:BoundField DataField="EnterDate" HeaderText="EnterDate" SortExpression="EnterDate"
							Visible="False" />
						<asp:BoundField DataField="EditByID" HeaderText="EditByID" SortExpression="EditByID"
							Visible="False" />
						<asp:BoundField DataField="EditeDate" HeaderText="EditeDate" SortExpression="EditeDate"
							Visible="False" />
						<asp:BoundField DataField="DepartmentName" HeaderText="DepartmentName" SortExpression="DepartmentName"
							Visible="False" />
						<asp:BoundField DataField="EnteredByName" HeaderText="EnteredByName" SortExpression="EnteredByName"
							Visible="False" />
						<asp:BoundField DataField="EditByName" HeaderText="EditByName" SortExpression="EditByName"
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
				<asp:ObjectDataSource ID="odsContacts" runat="server" SelectMethod="GetAllContacts"
					TypeName="Office.BLL.ContactsBLL" OldValuesParameterFormatString="original_{0}">
					<SelectParameters>
						<asp:SessionParameter DefaultValue="" Name="CurrentContact" SessionField="Contact"
							Type="Object" />
					</SelectParameters>
				</asp:ObjectDataSource>
			</ContentTemplate>
		</asp:UpdatePanel>
	</div>
	<div class="footer">
		<%--<asp:UpdatePanel ID="CA" runat="server">
			<ContentTemplate>
			</ContentTemplate>
		</asp:UpdatePanel>--%>
	</div>
</asp:Content>
<asp:Content ID="innerheader" ContentPlaceHolderID="InnerHeader" runat="server">

</asp:Content>
