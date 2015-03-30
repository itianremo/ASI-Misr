<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Webinars.aspx.cs" MasterPageFile="~/MasterLayout.master"
	Theme="Red" Inherits="Webinars" %>

<%@ MasterType VirtualPath="~/MasterLayout.master" %>
<asp:Content ID="Head" runat="server" ContentPlaceHolderID="head">
	<script type="text/javascript" src="Scripts/Scripts.js"></script>
</asp:Content>
<asp:Content ID="Main" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
	<div class="header">
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate>
				<table style="width: 100%; vertical-align: middle; height: 30px; line-height:30px;">
					<tr style="height: 30px; vertical-align:middle;">
						<td>
							<asp:DropDownList ID="ddlWebsitesWS" runat="server" Width="166px" OnSelectedIndexChanged="ddlWebsitesWS_SelectedIndexChanged"
								AutoPostBack="True">
								<asp:ListItem Selected="True">SSS WebSite</asp:ListItem>
								<asp:ListItem>ELS WebSite</asp:ListItem>
								<asp:ListItem>TSN WebSite</asp:ListItem>
							</asp:DropDownList>
						</td>					
						<td>
							<asp:Button ID="btnNew" runat="server" OnClick="btnNew_Click" Text="Add New" Width="84px"
								CausesValidation="False" />
							&nbsp;&nbsp;&nbsp;
							<asp:DropDownList ID="DDListWebinars" runat="server" AutoPostBack="True"
								OnSelectedIndexChanged="DDListWebinars_SelectedIndexChanged">
							</asp:DropDownList>
							&nbsp; &nbsp;
							<asp:Label ID="Label21" runat="server" Text="Start From:"></asp:Label>
							<asp:TextBox ID="txtStartFrom" runat="server" AutoPostBack="true"></asp:TextBox>
							<asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
							<asp:Label ID="lblSearch" runat="server" Text="Search:"></asp:Label>
							<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
							<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Go" CausesValidation="False" />
						</td>
					</tr>
				</table>
			</ContentTemplate>
		</asp:UpdatePanel>
	</div>
	<div class="ui-layout-content">
		<asp:UpdatePanel ID="UpdatePanel4" runat="server">
			<ContentTemplate>
				<asp:GridView ID="gvWebinar" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvWebinar_RowDataBound"
					Width="100%" BorderColor="Maroon" BorderStyle="Solid" AllowPaging="True" AllowSorting="True"
					PageSize="10" CellPadding="1" CssClass="FixedLayout">
					<Columns>
						<asp:BoundField DataField="fname" HeaderText="First Name">
							<HeaderStyle Width="15%" BorderColor="Black" />
							<ItemStyle Width="15%" HorizontalAlign="Left" BorderColor="Black" BackColor="White" />
						</asp:BoundField>
						<asp:BoundField DataField="lname" HeaderText="Last Name">
							<HeaderStyle Width="20%" BorderColor="Black" />
							<ItemStyle Width="20%" HorizontalAlign="Left" BorderColor="Black" BackColor="White" />
						</asp:BoundField>
						<asp:BoundField DataField="email" HeaderText="Email">
							<HeaderStyle Width="15%" BorderColor="Black" />
							<ItemStyle Width="15%" HorizontalAlign="Left" BorderColor="Black" BackColor="White" />
						</asp:BoundField>
						<asp:BoundField DataField="company" HeaderText="Compnay">
							<HeaderStyle Width="15%" BorderColor="Black" />
							<ItemStyle Width="15%" HorizontalAlign="Left" BorderColor="Black" BackColor="White" />
						</asp:BoundField>
						<asp:BoundField DataField="country" HeaderText="Country">
							<HeaderStyle Width="15%" BorderColor="Black" />
							<ItemStyle Width="15%" HorizontalAlign="Left" BorderColor="Black" BackColor="White" />
						</asp:BoundField>
						<asp:CheckBoxField DataField="Attend" HeaderText="Attend" SortExpression="Attend">
							<ControlStyle BorderColor="Black" />
							<HeaderStyle  BorderWidth="1px" Wrap="False"
								Width="5%" />
							<ItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" HorizontalAlign="Center"
								VerticalAlign="Middle" Wrap="False" Width="5%" />
						</asp:CheckBoxField>
						<asp:TemplateField HeaderText="Details">
							<ItemTemplate>
								<asp:LinkButton ID="lbtnDetails" runat="server" Text="Details" OnClick="lbtnDetails_Click"
									CausesValidation="False" />
							</ItemTemplate>
							<ControlStyle BorderColor="Black" />
							<HeaderStyle  BorderWidth="1px" Wrap="False"
								Width="10%" />
							<ItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" HorizontalAlign="Center"
								VerticalAlign="Middle" Wrap="False" Width="10%" />
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
				<table border='1' bordercolor='#FFFFFF' width="100%" style="text-align: center;
					vertical-align: top;">
					<tr style="vertical-align: top;">
						<td dir="ltr" style="vertical-align: top;">
							<table border="0" style="width: 100%;">
								<tr>
									<td style="text-align: right">
										<asp:Label ID="lblID1" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
											Text="ID"></asp:Label>
									</td>
									<td style="text-align: left">
										&nbsp;<asp:TextBox ID="txtid" runat="server" Width="254px"></asp:TextBox>
									</td>
									<td style="text-align: right">
										<asp:Label ID="Label14" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
											Text="Phone"></asp:Label>
									</td>
									<td style="text-align: left">
										&nbsp;<asp:TextBox ID="txtphone" runat="server" Width="255px"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td style="text-align: right;">
										<asp:Label ID="lblFN" runat="server" CssClass="DarkfontStyle" Font-Bold="False" Text="First Name"></asp:Label>
									</td>
									<td style="text-align: left;">
										&nbsp;<asp:TextBox ID="txtfname" runat="server" Width="254px"></asp:TextBox>
										<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfname"
											ErrorMessage="*"></asp:RequiredFieldValidator>
									</td>
									<td style="text-align: right;">
										<asp:Label ID="Label10" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
											Text="Last Name"></asp:Label>
									</td>
									<td style="text-align: left;">
										&nbsp;<asp:TextBox ID="txtlname" runat="server" Width="254px"></asp:TextBox>
										<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtlname"
											ErrorMessage="*"></asp:RequiredFieldValidator>
									</td>
								</tr>
								<tr>
									<td style="text-align: right;">
										<asp:Label ID="Label2" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
											Text="Company"></asp:Label>
									</td>
									<td style="text-align: left;">
										&nbsp;<asp:TextBox ID="txtcompany" runat="server" Width="254px"></asp:TextBox>
									</td>
									<td style="text-align: right;">
										<asp:Label ID="Label6" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
											Text="email"></asp:Label>&nbsp;
									</td>
									<td style="text-align: left;">
										&nbsp;<asp:TextBox ID="txtemail" runat="server" Width="255px"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td style="text-align: right;">
										<asp:Label ID="Label3" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
											Text="Website"></asp:Label>
									</td>
									<td style="text-align: left;">
										&nbsp;<asp:TextBox ID="txtwebsite" runat="server" Width="255px"></asp:TextBox>
									</td>
									<td style="text-align: right;">
										<asp:Label ID="Label16" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
											Text="Note"></asp:Label>
									</td>
									<td style="text-align: left;" rowspan="2">
										<asp:TextBox ID="txtcomments" runat="server" TextMode="MultiLine" Width="255px"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td style="text-align: right;">
										<asp:Label ID="Label3000" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
											Text="Country"></asp:Label>&nbsp;
									</td>
									<td style="text-align: left;">
										<asp:DropDownList ID="ddCountries" runat="server">
											<asp:ListItem Value="us">United States</asp:ListItem>
											<asp:ListItem Value="ca">Canada</asp:ListItem>
										</asp:DropDownList>
									</td>
									<td style="text-align: right;">
										&nbsp;
									</td>
								</tr>
								<tr>
									<td style="text-align: right;">
										<asp:Label ID="lblLocateUserTSNOffice" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
											Text="Locate User in TSN Office"></asp:Label>
									</td>
									<td style="text-align: left;">
										<asp:LinkButton ID="lbToTSNOffice" runat="server" OnClick="lbToTSNOffice_Click">Click 
                                                    Here</asp:LinkButton>
									</td>
									<td style="text-align: right;">
										<asp:Label ID="Label18" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
											Text="Webinar Date"></asp:Label>
									</td>
									<td style="text-align: left;">
										<asp:DropDownList ID="ddlistUpdateWebinar" runat="server" AutoPostBack="True">
										</asp:DropDownList>
									</td>
								</tr>
								<tr>
									<td style="text-align: right;">
										<asp:Label ID="lblLocateUserRegistration" runat="server" CssClass="DarkfontStyle"
											Font-Bold="False" Text="Locate User in Registration"></asp:Label>
									</td>
									<td style="text-align: left;">
										<asp:LinkButton ID="lbToRegistration" runat="server" OnClick="lbToRegistration_Click">Click Here</asp:LinkButton>
									</td>
									<td style="text-align: right;">
										&nbsp;
									</td>
									<td style="text-align: left;">
										<asp:CheckBox ID="chBoxSend" runat="server" Text="Send Email" />
										&nbsp;<asp:CheckBox ID="chBoxAttend" runat="server" Text="Attend" />
									</td>
								</tr>
								<tr>
									<td style="text-align: center" class="style1" colspan="4">
										<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="84px" />
										&nbsp;<asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
											Width="84px" CausesValidation="False" />
										&nbsp;<asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" OnClientClick="javascript:return confirm('You are about to delete the selected Member. continue...?')"
											Text="Delete" Width="87px" CausesValidation="False" />
									</td>
								</tr>
								<tr>
									<td style=" text-align: right">
										&nbsp;
									</td>
									<td style="text-align: left" colspan="3">
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:Label ID="lblEmailError" runat="server" ForeColor="Red"></asp:Label>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
			</ContentTemplate>
		</asp:UpdatePanel>
	</div>
</asp:Content>
