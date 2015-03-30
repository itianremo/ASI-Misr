<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerSupport.aspx.cs"
	Inherits="CustomerSupport" Theme="Red" MasterPageFile="~/MasterLayout.master"
	Title="Customer Support" %>

<%@ MasterType VirtualPath="~/MasterLayout.master" %>
<asp:Content ID="Head" runat="server" ContentPlaceHolderID="head">
	<script type="text/javascript" src="Scripts/Scripts.js"></script>
</asp:Content>
<asp:Content ID="Main" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
	<div class="header">
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate>
				<table style="width: 100%; vertical-align: middle; height: 20px;">
					<tr valign="top" style="height: 20px;">
						<td valign="top" background="Images/Grid_4.jpg" width="100%" style="height: 20px;">
							<asp:LinkButton ID="lbtnRequestQuote" runat="server" OnClick="lbtnRequestQuote_Click"> Customer Support: ELS Request a Quote</asp:LinkButton>
						</td>
					</tr>
				</table>
			</ContentTemplate>
		</asp:UpdatePanel>
	</div>
	<div class="ui-layout-content">
		<asp:UpdatePanel ID="UpdatePanel4" runat="server">
			<ContentTemplate>
				<asp:GridView ID="gvCustomerSupport" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvWebinar_RowDataBound"
					Width="98%" BorderColor="Maroon" BorderStyle="Solid" AllowPaging="True" AllowSorting="True"
					PageSize="25" CellPadding="4" OnRowCreated="gvCustomerSupport_RowCreated">
					<Columns>
						<asp:BoundField DataField="id" HeaderText="ID">
							<HeaderStyle Width="1%" BorderColor="Black" />
							<ItemStyle Width="1%" HorizontalAlign="Left" BorderColor="Black" BackColor="White" />
						</asp:BoundField>
						<asp:BoundField DataField="FirstName" HeaderText="First Name">
							<HeaderStyle Width="15%" BorderColor="Black" />
							<ItemStyle Width="15%" HorizontalAlign="Left" BorderColor="Black" BackColor="White" />
						</asp:BoundField>
						<asp:BoundField DataField="LastName" HeaderText="Last Name">
							<HeaderStyle Width="20%" BorderColor="Black" />
							<ItemStyle Width="20%" HorizontalAlign="Left" BorderColor="Black" BackColor="White" />
						</asp:BoundField>
						<asp:BoundField DataField="email" HeaderText="Email">
							<HeaderStyle Width="15%" BorderColor="Black" />
							<ItemStyle Width="15%" HorizontalAlign="Left" BorderColor="Black" BackColor="White" />
						</asp:BoundField>
						<asp:BoundField DataField="CompanyName" HeaderText="Compnay">
							<HeaderStyle Width="15%" BorderColor="Black" />
							<ItemStyle Width="15%" HorizontalAlign="Left" BorderColor="Black" BackColor="White" />
						</asp:BoundField>
						<asp:BoundField DataField="country" HeaderText="Country">
							<HeaderStyle Width="15%" BorderColor="Black" />
							<ItemStyle Width="15%" HorizontalAlign="Left" BorderColor="Black" BackColor="White" />
						</asp:BoundField>
						<asp:BoundField DataField="industry" HeaderText="Industry">
							<HeaderStyle Width="15%" BorderColor="Black" />
							<ItemStyle Width="15%" HorizontalAlign="Left" BorderColor="Black" BackColor="White" />
						</asp:BoundField>
						<%--<asp:CheckBoxField DataField="Attend" HeaderText="Attend" SortExpression="Attend"  >
                                                                <ControlStyle BorderColor="Black" />
                                                                <HeaderStyle BackColor="DarkGray" BorderColor="Black" BorderWidth="1px" Wrap="False"
                                                                    Width="5%" />
                                                                <ItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" HorizontalAlign="Center"
                                                                    VerticalAlign="Middle" Wrap="False" Width="5%" />
                                                                
                                                            </asp:CheckBoxField>--%>
						<asp:TemplateField HeaderText="Details">
							<ItemTemplate>
								<asp:LinkButton ID="lbtnDetails" runat="server" Text="Details" OnClick="lbtnDetails_Click" />
							</ItemTemplate>
							<ControlStyle BorderColor="Black" />
							<HeaderStyle BackColor="DarkGray" BorderColor="Black" BorderWidth="1px" Wrap="False"
								Width="10%" />
							<ItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" HorizontalAlign="Center"
								VerticalAlign="Middle" Wrap="False" Width="10%" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Edit">
							<ItemTemplate>
								<asp:LinkButton ID="lbtnEdit" runat="server" Text="Edit" OnClick="lbtnEdit_Click" />
							</ItemTemplate>
							<ControlStyle BorderColor="Black" />
							<HeaderStyle BackColor="DarkGray" BorderColor="Black" BorderWidth="1px" Wrap="False"
								Width="5%" />
							<ItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" HorizontalAlign="Center"
								VerticalAlign="Middle" Wrap="False" Width="5%" />
						</asp:TemplateField>
					</Columns>
					<RowStyle CssClass="GridNormalRowsStyle" />
					<SelectedRowStyle CssClass="SelectedRowColor" />
					<HeaderStyle CssClass="GridHeaderBackStyle" Font-Bold="True" Font-Names="Tahoma"
						Font-Size="12px" ForeColor="White" />
					<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
						NextPageText="Next" PreviousPageText="Previous" />
					<PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Center" />
				</asp:GridView>
				<asp:Label ID="lblTransMsg" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="14px"
					ForeColor="#004000" Text="Transaction Saved Successfully" Visible="False"></asp:Label>
			</ContentTemplate>
		</asp:UpdatePanel>
	</div>
	<div class="footer">
		<asp:UpdatePanel ID="upd1" runat="server">
			<ContentTemplate>
				<table border='1' bordercolor='#FFFFFF' height="100%" width="90%" style="text-align: center;
					vertical-align: top;">
					<tr style="vertical-align: top;">
						<td dir="ltr" style="vertical-align: top;">
							&nbsp;
							<div id="divDetails" runat="server">
								<table border="0" style="height: 140px; width: 909px;">
									<tr>
										<td style="height: 26px; text-align: right">
											<asp:Label ID="lblID1" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="ID"></asp:Label>
										</td>
										<td style="height: 26px; text-align: left">
											&nbsp;<asp:TextBox ID="txtid" runat="server" Width="254px" ReadOnly="True"></asp:TextBox>
										</td>
										<td style="height: 26px; text-align: right">
											<asp:Label ID="Label14" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Phone"></asp:Label>
										</td>
										<td style="height: 26px; text-align: left">
											&nbsp;<asp:TextBox ID="txtphone" runat="server" Width="255px" ReadOnly="True"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<td style="text-align: right;">
											<asp:Label ID="lblFN" runat="server" CssClass="DarkfontStyle" Font-Bold="False" Text="First Name"></asp:Label>
										</td>
										<td style="text-align: left;">
											&nbsp;<asp:TextBox ID="txtfname" runat="server" Width="254px" ReadOnly="True"></asp:TextBox>
										</td>
										<td style="text-align: right;">
											<asp:Label ID="Label10" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Last Name"></asp:Label>
										</td>
										<td style="text-align: left;">
											&nbsp;<asp:TextBox ID="txtlname" runat="server" Width="254px" ReadOnly="True"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<td style="text-align: right;">
											<asp:Label ID="Label2" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="CompanyName"></asp:Label>
										</td>
										<td style="text-align: left;">
											&nbsp;<asp:TextBox ID="txtcompany" runat="server" Width="254px" ReadOnly="True"></asp:TextBox>
										</td>
										<td style="text-align: right;">
											<asp:Label ID="Label6" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Email"></asp:Label>&nbsp;
										</td>
										<td style="text-align: left;">
											&nbsp;<asp:TextBox ID="txtemail" runat="server" Width="255px" ReadOnly="True"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<td style="text-align: right; height: 26px;">
											<asp:Label ID="Label3" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Industry"></asp:Label>
										</td>
										<td style="text-align: left; height: 26px;">
											&nbsp;<asp:TextBox ID="txtwebsite" runat="server" Width="255px" ReadOnly="True"></asp:TextBox>
										</td>
										<td style="text-align: right; height: 26px;">
											<asp:Label ID="Label16" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Comment"></asp:Label>
										</td>
										<td style="text-align: left;" rowspan="2">
											&nbsp;<asp:TextBox ID="txtcomments" runat="server" TextMode="MultiLine" Width="255px"
												ReadOnly="True"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<td style="text-align: right; height: 22px;">
											<asp:Label ID="Label3000" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Country"></asp:Label>&nbsp;
										</td>
										<td style="text-align: left; height: 22px;">
											<asp:DropDownList ID="ddCountries" runat="server" Enabled="False">
												<asp:ListItem Value="us">United States</asp:ListItem>
												<asp:ListItem Value="ca">Canada</asp:ListItem>
											</asp:DropDownList>
										</td>
										<td style="text-align: right; height: 22px;">
											&nbsp;
										</td>
									</tr>
									<tr>
										<td style="text-align: right;">
											<asp:Label ID="Label3004" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Status"></asp:Label>
										</td>
										<td style="text-align: left;">
											<asp:Label ID="lblStatusValue" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Status"></asp:Label>
										</td>
										<td style="text-align: right;">
											&nbsp;
										</td>
										<td style="text-align: left;">
											&nbsp;
										</td>
									</tr>
									<tr>
										<td style="text-align: right;">
											<asp:Label ID="Label17" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Locate User in TSN Office" Visible="False"></asp:Label>
										</td>
										<td style="text-align: left;">
											<asp:LinkButton ID="lbToTSNOffice" runat="server" OnClick="lbToTSNOffice_Click" Visible="False">Click 
                                                    Here</asp:LinkButton>
										</td>
										<td style="text-align: right;">
											<asp:Label ID="Label3001" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Status" Visible="False"></asp:Label>
										</td>
										<td style="text-align: left;">
											<asp:RadioButton ID="rbtnActive" runat="server" GroupName="a" Text="Active" Visible="False" />
											&nbsp;<asp:RadioButton ID="rbtnNotActive" runat="server" GroupName="a" Text="Not Active"
												Visible="False" />
										</td>
									</tr>
									<tr>
										<td style="text-align: right; height: 26px;">
											&nbsp;
										</td>
										<td style="text-align: left; height: 26px;">
											<asp:CheckBox ID="chBoxSend" runat="server" Text="Send Email" />
										</td>
										<td style="text-align: right; height: 26px;">
											&nbsp;
										</td>
										<td style="text-align: left; height: 26px;">
											&nbsp;
										</td>
									</tr>
									<tr>
										<td class="style1" colspan="4" style="text-align: center">
											&nbsp;<asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
												Width="84px" Visible="False" />
										</td>
									</tr>
								</table>
							</div>
							<div id="divEdit" runat="server">
								<table>
									<tr>
										<td style="height: 26px; text-align: right">
											<asp:Label ID="Label3003" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Status"></asp:Label>
										</td>
										<td style="height: 26px; text-align: left">
											<asp:DropDownList ID="ddlStatus" runat="server">
												<asp:ListItem>Active</asp:ListItem>
												<asp:ListItem>Checked</asp:ListItem>
												<asp:ListItem>Close</asp:ListItem>
												<asp:ListItem>Delete</asp:ListItem>
											</asp:DropDownList>
											<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="84px" />
										</td>
										<td style="height: 26px; text-align: right">
											&nbsp;
										</td>
										<td style="height: 26px; text-align: left">
											&nbsp;
										</td>
									</tr>
									<tr>
										<td style="height: 26px; text-align: right">
											<asp:Label ID="Label3002" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Forward"></asp:Label>
										</td>
										<td style="height: 26px; text-align: left">
											<asp:DropDownList ID="ddlLoginUsers" runat="server">
											</asp:DropDownList>
											<asp:Button ID="btnForword" runat="server" OnClick="btnForword_Click" Text="Save"
												Width="84px" />
										</td>
										<td style="height: 26px; text-align: right">
											&nbsp;
										</td>
										<td style="height: 26px; text-align: left">
											&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										</td>
									</tr>
									<tr>
										<td style="text-align: center" class="style1" colspan="4">
											<asp:Label ID="lblResult" runat="server" Text="  "></asp:Label>
										</td>
									</tr>
								</table>
							</div>
						</td>
					</tr>
				</table>
			</ContentTemplate>
		</asp:UpdatePanel>
	</div>
</asp:Content>
