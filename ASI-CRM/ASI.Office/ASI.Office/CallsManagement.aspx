<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CallsManagement.aspx.cs"
	Inherits="CallsManagement" EnableEventValidation="false" Theme="Red" MasterPageFile="~/MasterLayout.master"
	Title="Calls Management" %>

<%@ MasterType VirtualPath="~/MasterLayout.master" %>
<%@ Register Src="Controls/AutoCompleteSearch.ascx" TagName="AutoCompleteSearch"
	TagPrefix="uc3" %>
<%@ Register Src="Controls/TransToolBar.ascx" TagName="TransToolBar" TagPrefix="uc1" %>
<asp:Content ID="Head" runat="server" ContentPlaceHolderID="head">
	<script type="javascript" src="Scripts/Scripts.js"></script>
	<style type="text/css">
		.style1
		{
			height: 22px;
			text-align: left;
		}
		
		.style1 td
		{
			text-align: left;
		}
		
		.style1 tr
		{
			text-align: left;
		}
		.style2
		{
			width: 100%;
		}
	</style>
</asp:Content>
<asp:Content ID="Main" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
	<div class="header">
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate>
				<uc1:TransToolBar ID="ucTransToolBar" runat="server" />
			</ContentTemplate>
		</asp:UpdatePanel>
		<br />
		<asp:Panel ID="pnlSearch" runat="server">
			<table cellpadding="0" cellspacing="0" style="width: 100%">
				<tr>
					<td style="width: 30%; white-space: nowrap;">
						<asp:UpdatePanel ID="UpdatePanel2" runat="server">
							<ContentTemplate>
								<uc3:AutoCompleteSearch ID="ucAutoCompleteSearch" runat="server" />
							</ContentTemplate>
						</asp:UpdatePanel>
					</td>
					<td style="width: 1%; white-space: nowrap;" align="center">
						&nbsp;
					</td>
					<td style="width: 60%; white-space: nowrap;" colspan="2" align="left">
						<asp:UpdatePanel ID="UpdatePanel5" runat="server">
							<ContentTemplate>
								<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="13px"
									ForeColor="White" Text="Note Date:"></asp:Label>
								<asp:TextBox ID="txtCallDate" runat="server" CssClass="inputs" Width="110px" AutoPostBack="True"
									OnTextChanged="txtCallDate_TextChanged"></asp:TextBox>
								<img id="imgCallDate" runat="server" src="Images/Calender.gif" style="vertical-align: middle"
									class="HandOverCursor" alt="Pick a Date" />
								<ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="imgCallDate"
									TargetControlID="txtCallDate">
								</ajaxToolkit:CalendarExtender>
								<asp:Button ID="btnSearchAll" runat="server" Text="Search All" OnClick="btnSearchAll_Click" />
							</ContentTemplate>
						</asp:UpdatePanel>
					</td>
				</tr>
			</table>
		</asp:Panel>
	</div>
	<div class="ui-layout-content">
		<asp:UpdatePanel ID="up" runat="server">
			<ContentTemplate>
				<asp:Panel ID="upCallsgv" runat="server">
					<asp:GridView ID="gvCalls" runat="server" AutoGenerateColumns="False" Width="98%"
						BorderColor="Maroon" BorderStyle="Solid" AllowPaging="True" AllowSorting="True"
						DataKeyNames="CallID, ContactID, AccountID" OnPageIndexChanging="gvCalls_PageIndexChanging"
						OnRowCreated="gvCalls_RowCreated" OnSelectedIndexChanged="gvCalls_SelectedIndexChanged"
						PageSize="25" OnRowDataBound="gvCalls_RowDataBound" OnSorting="gvCalls_Sorting"
						CellPadding="4" ShowHeaderWhenEmpty="true">
						<Columns>
							<asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject">
								<HeaderStyle HorizontalAlign="Center" />
								<ItemStyle HorizontalAlign="Left" />
							</asp:BoundField>
							<asp:BoundField DataField="ContactFirstName" HeaderText="Contact" SortExpression="ContactFirstName">
								<HeaderStyle HorizontalAlign="Center" Width="9%" />
								<ItemStyle HorizontalAlign="Center" />
							</asp:BoundField>
							<asp:BoundField DataField="ContactLastName" HeaderText="Last Name" NullDisplayText=""
								SortExpression="ContactLastName">
								<ItemStyle HorizontalAlign="Left" />
							</asp:BoundField>
							<asp:BoundField DataField="StatusName" HeaderText="Status" SortExpression="StatusName">
								<HeaderStyle HorizontalAlign="Center" />
								<ItemStyle HorizontalAlign="Center" />
							</asp:BoundField>
							<asp:BoundField DataField="StartDate" DataFormatString="{0:d}" HeaderText="Date"
								SortExpression="StartDate">
								<HeaderStyle HorizontalAlign="Center" />
								<ItemStyle HorizontalAlign="Left" />
							</asp:BoundField>
							<asp:BoundField HeaderText="Notes" HtmlEncode="False" DataField="Notes" SortExpression="Notes">
								<HeaderStyle HorizontalAlign="Center" />
								<ItemStyle HorizontalAlign="Center" />
							</asp:BoundField>
						</Columns>
						<RowStyle CssClass="GridNormalRowsStyle" />
						<SelectedRowStyle CssClass="SelectedRowColor" />
						<HeaderStyle CssClass="GridHeaderBackStyle" Font-Bold="True" Font-Names="Tahoma"
							Font-Size="12px" ForeColor="White" />
						<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
							NextPageText="Next" PreviousPageText="Previous" />
						<PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Center" />
					</asp:GridView>
					<asp:ObjectDataSource ID="odsCalls" runat="server" SelectMethod="SelectCalls" TypeName="Office.BLL.CallsBLL">
						<SelectParameters>
							<asp:SessionParameter Name="CurrentCall" SessionField="Call" Type="Object" />
						</SelectParameters>
					</asp:ObjectDataSource>
					<asp:Label ID="lblTransMsg" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="14px"
						ForeColor="#004000" Text="Transaction Saved Successfully" Visible="False"></asp:Label>
				</asp:Panel>
				<asp:Panel ID="upAddEditCall" runat="server" Visible="false">
					<table class="style2">
						<tr>
							<td valign="top">
								<table align="center" border="1">
									<tbody>
										<tr class="style1">
											<td class="style1" height="22px">
												Subject:
											</td>
											<td class="style1" height="22px" style="padding-left: 12px;">
												<asp:TextBox ID="txtSubject" CssClass="inputs" runat="server" Width="180px"></asp:TextBox>
											</td>
										</tr>
										<tr class="style1" height="22px">
											<td class="style1">
												Related to:
											</td>
											<td class="style1">
												<asp:UpdatePanel ID="UpdatePanel3" runat="server">
													<ContentTemplate>
														<uc3:AutoCompleteSearch ID="acsRelatedTo" runat="server" />
														<%--<asp:TextBox ID="txtRelatedTo" runat="server"></asp:TextBox>--%>
														<asp:HiddenField ID="hdnContactID" runat="server" />
													</ContentTemplate>
												</asp:UpdatePanel>
											</td>
										</tr>
										<tr class="style1">
											<td class="style1" height="22px">
												Date:
											</td>
											<td class="style1" height="22px" style="padding-left: 12px;">
												<asp:TextBox ID="txtDate" runat="server" CssClass="inputs" Width="180px"></asp:TextBox>
												<img id="imgDate" runat="server" src="Images/Calender.gif" style="vertical-align: middle"
													class="HandOverCursor" alt="Pick a Date" />
												<ajaxToolkit:CalendarExtender ID="txtDate_CalendarExtender" runat="server" PopupButtonID="imgDate"
													PopupPosition="BottomRight" TargetControlID="txtDate">
												</ajaxToolkit:CalendarExtender>
											</td>
										</tr>
										<tr class="style1">
											<td class="style1" height="22px">
												Status:
											</td>
											<td class="style1" height="22px" style="padding-left: 12px;">
												<asp:DropDownList ID="ddlStatus" runat="server" CssClass="inputs" DataTextField="SubCode"
													DataValueField="SubID" Width="180px">
												</asp:DropDownList>
											</td>
										</tr>
										<tr class="style1">
											<td class="style1" height="22px">
												Reschedule:
											</td>
											<td class="style1" height="22px" style="padding-left: 12px;">
												<asp:Button ID="btnReschedule" runat="server" CssClass="HandOverCursor" Text="Reschedule"
													Width="180px" />
												<%--<img id="imgReschedule" runat="server" src="Images/Calender.gif" style="vertical-align: middle"
                                                            class="HandOverCursor" alt="Pick a Date" />--%>
												<ajaxToolkit:CalendarExtender ID="txtDate_CalendarExtender2" runat="server" PopupButtonID="btnReschedule"
													TargetControlID="txtDate">
												</ajaxToolkit:CalendarExtender>
											</td>
										</tr>
										<tr class="style1">
											<td class="style1">
												Note:
											</td>
											<td class="style1" style="padding-left: 12px;">
												<asp:TextBox ID="txtNote" runat="server" CssClass="inputs" Rows="5" TextMode="MultiLine"
													Width="180px"></asp:TextBox>
											</td>
										</tr>
									</tbody>
								</table>
							</td>
							<td width="923px">
								<asp:UpdatePanel ID="UpdatePanel6" runat="server">
									<ContentTemplate>
										<asp:ObjectDataSource ID="odsContacts" runat="server" OldValuesParameterFormatString="original_{0}"
											SelectMethod="GetAllContacts" TypeName="Office.BLL.ContactsBLL">
											<SelectParameters>
												<asp:SessionParameter DefaultValue="" Name="CurrentContact" SessionField="CallContact"
													Type="Object" />
											</SelectParameters>
										</asp:ObjectDataSource>
										<asp:GridView ID="gvContacts" runat="server" AutoGenerateColumns="False" BorderColor="Maroon"
											BorderStyle="Solid" CellPadding="4" DataKeyNames="ContactID" EnableModelValidation="True"
											PageSize="15" AllowPaging="True" OnPageIndexChanging="gvContacts_PageIndexChanging"
											OnSelectedIndexChanged="gvContacts_SelectedIndexChanged">
											<Columns>
												<asp:BoundField DataField="AccountName" HeaderText="Company" />
												<asp:BoundField DataField="FirstName" HeaderText="First Name" />
												<asp:BoundField DataField="LastName" HeaderText="Last Name" />
												<asp:BoundField DataField="Phone" HeaderText="Telephone" />
												<asp:BoundField DataField="TitleName" HeaderText="Title" />
												<asp:BoundField DataField="Email" HeaderText="Email" />
												<asp:CommandField ShowSelectButton="True" />
												<%-- <asp:TemplateField HeaderText="Select">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lbtnDetails" runat="server" Text="Details"  
                                                                    OnClick="lbtnDetails_Click" CausesValidation="False" />
                                                            </ItemTemplate>
                                                            <ControlStyle BorderColor="Black" />
                                                            <HeaderStyle BackColor="DarkGray" BorderColor="Black" BorderWidth="1px" Wrap="False"
                                                                Width="10%" />
                                                            <ItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" HorizontalAlign="Center"
                                                                VerticalAlign="Middle" Wrap="False" Width="10%" />
                                                        </asp:TemplateField>--%>
											</Columns>
											<HeaderStyle CssClass="GridHeaderBackStyle" Font-Names="Tahoma" Font-Size="12px"
												ForeColor="White" />
											<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
												NextPageText="Next" PreviousPageText="Previous" />
											<PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Center" />
											<RowStyle CssClass="GridNormalRowsStyle" />
											<SelectedRowStyle CssClass="SelectedRowColor" />
										</asp:GridView>
									</ContentTemplate>
								</asp:UpdatePanel>
							</td>
						</tr>
					</table>
				</asp:Panel>
				<asp:UpdatePanel ID="UpdatePanel4" runat="server">
					<ContentTemplate>
						<asp:Label ID="lblAddEdit" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="14px"
							ForeColor="#004000" Text=""></asp:Label>
					</ContentTemplate>
				</asp:UpdatePanel>
			</ContentTemplate>
		</asp:UpdatePanel>
	</div>
	<div class="footer">
	</div>
</asp:Content>
