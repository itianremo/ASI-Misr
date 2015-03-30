<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration"
	EnableEventValidation="false" Theme="Red" MasterPageFile="~/MasterLayout.master"
	Title="Registeration" %>

<%@ MasterType VirtualPath="~/MasterLayout.master" %>
<asp:Content ID="Head" runat="server" ContentPlaceHolderID="head">
	<script language="javascript" src="Scripts/Scripts.js"></script>
	<script type="text/javascript">
		// Get a PageRequestManager reference.
		var prm = Sys.WebForms.PageRequestManager.getInstance();

		// Hook the _initializeRequest event and add our own handler.

		/* Hided By Hamdy> This is no need for this sbecause we use alternate way to export*/

		//prm.add_initializeRequest(InitializeRequest);

		//			function InitializeRequest(sender, args) {
		//				// Check to be sure this async postback is actually 
		//				//   requesting the file download.
		//				if (sender._postBackSettings.sourceElement.id == "btnExport") {
		//					// Create an IFRAME.
		//					var iframe = document.createElement("iframe");

		//					// Point the IFRAME to GenerateFile.
		//					iframe.src = "GenerateRegisterationReport.aspx";

		//					// This makes the IFRAME invisible to the user.
		//					iframe.style.display = "none";

		//					// Add the IFRAME to the page.  This will trigger
		//					//   a request to GenerateFile now.
		//					document.body.appendChild(iframe);
		//				}
		//			}

	</script>
</asp:Content>
<asp:Content ID="Main" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
	<div class="header">
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate>
				<table style="width: 100%; vertical-align: middle; height: 20px;">
					<%--<tr valign="top" style="height: 20px;">
												<td valign="top" background="Images/Grid_4.jpg" width="100%" style="height: 20px;">
												</td>
											</tr>--%>
					<tr style="height: 20px;" valign="middle">
						<td background="Images/Grid_4.jpg" style="height: 20px;" valign="middle" width="100%">
							&nbsp;
							<asp:DropDownList ID="ddlWebsitesWS" runat="server" Width="166px" OnSelectedIndexChanged="ddlWebsitesWS_SelectedIndexChanged"
								AutoPostBack="True">
								<asp:ListItem Selected="True">SSS WebSite</asp:ListItem>
								<asp:ListItem>ELS WebSite</asp:ListItem>
								<asp:ListItem>TSN WebSite</asp:ListItem>
							</asp:DropDownList>
							&nbsp;&nbsp;
							<asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add New" Width="84px"
								CausesValidation="False" />
							&nbsp;&nbsp;<asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="Export to Excel"
								CausesValidation="False" />
							<asp:Button ID="btnClearCache" runat="server" OnClick="btnClearCache_Click" Text="ClearCache"
								CausesValidation="False" />
							&nbsp;&nbsp;<asp:Label ID="lblSearch" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
								Text="Search"></asp:Label>
							<asp:TextBox ID="txtSearch" runat="server" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
							<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search"
								CausesValidation="false" />
							<asp:DropDownList ID="ddlSearchType" runat="server" Width="131px">
								<asp:ListItem>All</asp:ListItem>
								<asp:ListItem>Approved</asp:ListItem>
								<asp:ListItem Value="NotApproved">Not Approved</asp:ListItem>
								<asp:ListItem>CheckList</asp:ListItem>
								<asp:ListItem Value="NoCheckList">No CheckList</asp:ListItem>
								<asp:ListItem Value="Hidden">Hidden</asp:ListItem>
							</asp:DropDownList>
						</td>
					</tr>
				</table>
			</ContentTemplate>
		</asp:UpdatePanel>
	</div>
	<div class="ui-layout-content">
		<asp:UpdatePanel ID="UpdatePanel4" runat="server">
			<ContentTemplate>
				<asp:GridView ID="gvRegistration" runat="server" AutoGenerateColumns="False" Width="98%"
					BorderColor="Maroon" BorderStyle="Solid" AllowPaging="True" OnSelectedIndexChanged="gvRegistration_SelectedIndexChanged"
					OnSelectedIndexChanging="gvRegistration_SelectedIndexChanging" OnPageIndexChanging="gvRegistration_PageIndexChanging"
					OnSorting="gvRegistration_Sorting" AllowSorting="True" PageSize="15" CellPadding="4">
					<Columns>
						<asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName">
							<HeaderStyle Width="15%" BorderColor="Black" />
							<ItemStyle Width="15%" HorizontalAlign="Left" BorderColor="Black" BackColor="White" />
						</asp:BoundField>
						<asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName">
							<HeaderStyle Width="20%" BorderColor="Black" />
							<ItemStyle Width="20%" HorizontalAlign="Left" BorderColor="Black" BackColor="White" />
						</asp:BoundField>
						<asp:BoundField DataField="CompanyName" HeaderText="Compnay Name" SortExpression="CompanyName">
							<HeaderStyle Width="15%" BorderColor="Black" />
							<ItemStyle Width="15%" HorizontalAlign="Left" BorderColor="Black" BackColor="White" />
						</asp:BoundField>
						<asp:TemplateField HeaderText="Email" SortExpression="Email">
							<ItemTemplate>
								<asp:HyperLink ID="hlEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Email") %>'
									NavigateUrl='<%# "Users.aspx?Email="+DataBinder.Eval(Container.DataItem, "Email") %>'></asp:HyperLink>
							</ItemTemplate>
							<HeaderStyle BorderColor="Black" />
							<ItemStyle CssClass="GridNumberColumnStyle" Width="20%" HorizontalAlign="Left" BorderColor="Black" />
						</asp:TemplateField>
						<asp:BoundField DataField="RegDate" HeaderText="RegDate" DataFormatString="{0:d}"
							SortExpression="RegDate">
							<HeaderStyle Width="15%" BorderColor="Black" />
							<ItemStyle Width="15%" HorizontalAlign="Left" BorderColor="Black" BackColor="White" />
						</asp:BoundField>
						<asp:CheckBoxField DataField="SSS" HeaderText="SSS">
							<ControlStyle BorderColor="Black" />
							<HeaderStyle BackColor="DarkGray" BorderColor="Black" BorderWidth="1px" Wrap="False"
								Width="5%" />
							<ItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" HorizontalAlign="Center"
								VerticalAlign="Middle" Wrap="False" Width="5%" />
						</asp:CheckBoxField>
						<asp:CheckBoxField DataField="LGD" HeaderText="LGD">
							<ControlStyle BorderColor="Black" />
							<HeaderStyle BackColor="DarkGray" BorderColor="Black" BorderWidth="1px" Wrap="False"
								Width="5%" />
							<ItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" HorizontalAlign="Center"
								VerticalAlign="Middle" Wrap="False" Width="5%" />
						</asp:CheckBoxField>
						<asp:CheckBoxField DataField="LDG" HeaderText="LDG">
							<ControlStyle BorderColor="Black" />
							<HeaderStyle BackColor="DarkGray" BorderColor="Black" BorderWidth="1px" Wrap="False"
								Width="5%" />
							<ItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" HorizontalAlign="Center"
								VerticalAlign="Middle" Wrap="False" Width="5%" />
						</asp:CheckBoxField>
						<asp:CheckBoxField DataField="Approved" HeaderText="Approved">
							<ControlStyle BorderColor="Black" />
							<HeaderStyle BackColor="DarkGray" BorderColor="Black" BorderWidth="1px" Wrap="False"
								Width="5%" />
							<ItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" HorizontalAlign="Center"
								VerticalAlign="Middle" Wrap="False" Width="5%" />
						</asp:CheckBoxField>
						<asp:CheckBoxField DataField="Agreement" HeaderText="Agreement">
							<ControlStyle BorderColor="Black" />
							<HeaderStyle BackColor="DarkGray" BorderColor="Black" BorderWidth="1px" Wrap="False"
								Width="5%" />
							<ItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" HorizontalAlign="Center"
								VerticalAlign="Middle" Wrap="False" Width="5%" />
						</asp:CheckBoxField>
						<asp:CheckBoxField DataField="CkeckList" HeaderText="CkeckList">
							<ControlStyle BorderColor="Black" />
							<HeaderStyle BackColor="DarkGray" BorderColor="Black" BorderWidth="1px" Wrap="False"
								Width="5%" />
							<ItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" HorizontalAlign="Center"
								VerticalAlign="Middle" Wrap="False" Width="5%" />
						</asp:CheckBoxField>
						<asp:TemplateField HeaderText="Details">
							<ItemTemplate>
								<asp:LinkButton ID="lbtnDetails" runat="server" Text="Details" OnClick="lbtnDetails_Click"
									CausesValidation="false" />
							</ItemTemplate>
							<ControlStyle BorderColor="Black" />
							<HeaderStyle BackColor="DarkGray" BorderColor="Black" BorderWidth="1px" Wrap="False"
								Width="10%" />
							<ItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" HorizontalAlign="Center"
								VerticalAlign="Middle" Wrap="False" Width="10%" />
						</asp:TemplateField>
						<%--<asp:TemplateField HeaderText="Survey"  >
                                                         <ItemTemplate>
                                                        <asp:HyperLink ID="hl2Email" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SurveyCount") %>'
                                                            NavigateUrl='<%# "SurveyDetails.aspx?Email="+DataBinder.Eval(Container.DataItem, "Email") %>' Target="_blank"></asp:HyperLink>
                                                       </ItemTemplate>
                                                       <HeaderStyle BorderColor="Black" />
                                                       <ItemStyle CssClass="GridNumberColumnStyle" Width="20%" HorizontalAlign="Left" BorderColor="Black" />
                                                    </asp:TemplateField>  --%>
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
	<asp:ObjectDataSource ID="ODS_ELSData" runat="server" SelectMethod="getAllContact"
		TypeName="ELSData.DataService"></asp:ObjectDataSource>
	<asp:ObjectDataSource ID="ODS" runat="server" SelectMethod="GetAllMembers" TypeName="SSSData.SSSData"
		InsertMethod="AddMember" UpdateMethod="EditMember">
		<InsertParameters>
			<asp:Parameter Name="firstname" Type="String" />
			<asp:Parameter Name="lastname" Type="String" />
			<asp:Parameter Name="address" Type="String" />
			<asp:Parameter Name="address2" Type="String" />
			<asp:Parameter Name="city" Type="String" />
			<asp:Parameter Name="state" Type="String" />
			<asp:Parameter Name="country" Type="String" />
			<asp:Parameter Name="company" Type="String" />
			<asp:Parameter Name="phone" Type="String" />
			<asp:Parameter Name="fax" Type="String" />
			<asp:Parameter Name="website" Type="String" />
			<asp:Parameter Name="email" Type="String" />
			<asp:Parameter Name="password" Type="String" />
			<asp:Parameter Name="sss" Type="Boolean" />
			<asp:Parameter Name="lgd" Type="Boolean" />
			<asp:Parameter Name="ldg" Type="Boolean" />
			<asp:Parameter Name="zipcode" Type="String" />
			<asp:Parameter Name="regDate" Type="DateTime" />
			<asp:Parameter Name="approved" Type="Boolean" />
		</InsertParameters>
		<UpdateParameters>
			<asp:Parameter Name="firstname" Type="String" />
			<asp:Parameter Name="lastname" Type="String" />
			<asp:Parameter Name="address" Type="String" />
			<asp:Parameter Name="address2" Type="String" />
			<asp:Parameter Name="city" Type="String" />
			<asp:Parameter Name="state" Type="String" />
			<asp:Parameter Name="country" Type="String" />
			<asp:Parameter Name="company" Type="String" />
			<asp:Parameter Name="phone" Type="String" />
			<asp:Parameter Name="fax" Type="String" />
			<asp:Parameter Name="website" Type="String" />
			<asp:Parameter Name="email" Type="String" />
			<asp:Parameter Name="regDate" Type="DateTime" />
			<asp:Parameter Name="sss" Type="Boolean" />
			<asp:Parameter Name="lgd" Type="Boolean" />
			<asp:Parameter Name="ldg" Type="Boolean" />
			<asp:Parameter Name="approved" Type="Boolean" />
			<asp:Parameter Name="zipcode" Type="String" />
			<asp:Parameter Name="ID" Type="Int32" />
		</UpdateParameters>
	</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="getAllContact"
		TypeName="ELSData.DataService"></asp:ObjectDataSource>
</div>
	<div class="footer">
		<asp:UpdatePanel ID="upd1" runat="server">
			<ContentTemplate>
				<div id="divDetails" runat="server">
					<table border='1' bordercolor='#FFFFFF' height="100%" width="90%" style="text-align: center;
						vertical-align: top;">
						<tr style="vertical-align: top;">
							<td dir="ltr" style="vertical-align: top;">
								<table border="0" style="height: 140px; width: 909px;">
									<tr>
										<td style="text-align: right;">
											<asp:Label ID="lblFN" runat="server" CssClass="DarkfontStyle" Font-Bold="False" Text="First Name"></asp:Label>
										</td>
										<td style="text-align: left;">
											&nbsp;<asp:TextBox ID="txtFirstName" runat="server" Width="256px"></asp:TextBox>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName"
												ErrorMessage="*"></asp:RequiredFieldValidator>
										</td>
										<td style="text-align: right;">
											<asp:Label ID="Label10lastname" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Last Name"></asp:Label>
										</td>
										<td style="text-align: left;" colspan="3">
											&nbsp;<asp:TextBox ID="txtLastName" runat="server" Width="254px"></asp:TextBox>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName"
												ErrorMessage="*"></asp:RequiredFieldValidator>
										</td>
									</tr>
									<tr>
										<td style="text-align: right;">
											<asp:Label ID="Label22id" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="ID"></asp:Label>&nbsp;
										</td>
										<td style="text-align: left;">
											&nbsp;<asp:TextBox ID="txtID" runat="server" ReadOnly="True" Width="255px"></asp:TextBox>
										</td>
										<td style="text-align: right;">
											<asp:Label ID="Label6email" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="email"></asp:Label>&nbsp;
										</td>
										<td colspan="3" style="text-align: left;">
											&nbsp;<asp:TextBox ID="txtEmail" runat="server" Width="255px"></asp:TextBox>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail"
												ErrorMessage="*"></asp:RequiredFieldValidator>
										</td>
									</tr>
									<tr>
										<td style="text-align: right; height: 26px;">
											<asp:Label ID="Label2RegDate" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Reg Date"></asp:Label>
										</td>
										<td style="text-align: left; height: 26px;">
											&nbsp;<asp:TextBox ID="txtRegDate" runat="server" Width="255px"></asp:TextBox>
										</td>
										<td style="text-align: right; height: 26px;">
											<asp:Label ID="Label14country" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Country"></asp:Label>&nbsp;&nbsp;
										</td>
										<td colspan="3" style="text-align: left; height: 26px;">
											&nbsp;<asp:TextBox ID="txtCountry" runat="server" Width="255px"></asp:TextBox>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCountry"
												ErrorMessage="*"></asp:RequiredFieldValidator>
										</td>
									</tr>
									<tr>
										<td style="text-align: right; height: 26px;">
											<asp:Label ID="Label13company" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Company"></asp:Label>
										</td>
										<td style="text-align: left; height: 26px;">
											&nbsp;<asp:TextBox ID="txtCompanyName" runat="server" Width="256px"></asp:TextBox>
										</td>
										<td style="text-align: right; height: 26px;">
											<asp:Label ID="Label12" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="City"></asp:Label>&nbsp;
										</td>
										<td colspan="3" style="text-align: left; height: 26px;">
											&nbsp;<asp:TextBox ID="txtCity" runat="server" Width="255px"></asp:TextBox>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCity"
												ErrorMessage="*"></asp:RequiredFieldValidator>
										</td>
									</tr>
									<tr>
										<td style="text-align: right; height: 26px;">
											<asp:Label ID="Label15" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Submitted Time"></asp:Label>
										</td>
										<td style="text-align: left; height: 26px;">
											&nbsp;<asp:TextBox ID="TextBox3" runat="server" Width="254px"></asp:TextBox>
										</td>
										<td style="text-align: right; height: 26px;">
											<asp:Label ID="Label16" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Fax"></asp:Label>&nbsp;
										</td>
										<td colspan="3" style="text-align: left; height: 26px;">
											&nbsp;<asp:TextBox ID="txtFax" runat="server" Width="256px"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<td style="text-align: right; height: 26px;">
											<asp:Label ID="Label17" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Website"></asp:Label>
										</td>
										<td style="text-align: left; height: 26px;">
											&nbsp;<asp:TextBox ID="txtWebsite" runat="server" Width="255px"></asp:TextBox>
										</td>
										<td style="text-align: right; height: 26px;">
											<asp:Label ID="Label18" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Phone"></asp:Label>&nbsp;
										</td>
										<td style="text-align: left; height: 26px;">
											&nbsp;<asp:TextBox ID="txtPhone" runat="server" Width="255px"></asp:TextBox>
										</td>
										<td style="text-align: right; height: 26px;">
											&nbsp;
										</td>
										<td style="text-align: left; height: 26px;">
											&nbsp;
										</td>
									</tr>
									<tr>
										<td style="text-align: right; height: 22px;">
											<asp:Label ID="Label19" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="State"></asp:Label>&nbsp;
										</td>
										<td style="text-align: left; height: 22px;">
											&nbsp;<asp:TextBox ID="txtState" runat="server" Width="255px"></asp:TextBox>
										</td>
										<td style="text-align: right; height: 22px;">
											<asp:Label ID="Label20" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="ZipCode"></asp:Label>&nbsp;
										</td>
										<td colspan="3" style="text-align: left; height: 22px;">
											&nbsp;<asp:TextBox ID="txtZipCode" runat="server" Width="255px"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<td style="text-align: right;">
											<asp:Label ID="Label2" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Industry"></asp:Label>
										</td>
										<td style="text-align: left;">
											&nbsp;<asp:TextBox ID="txtIndustry" runat="server" Width="255px"></asp:TextBox>
										</td>
										<td style="text-align: right;">
											<asp:Label ID="Label25" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Scheduled Webinar"></asp:Label>
										</td>
										<td style="text-align: left;">
											&nbsp;<asp:DropDownList ID="ddlistUpdateWebinar" runat="server" AutoPostBack="True"
												Width="259px">
											</asp:DropDownList>
										</td>
										<td style="text-align: right;">
											&nbsp;
										</td>
										<td style="text-align: left;">
											&nbsp;
										</td>
									</tr>
									<tr>
										<td style="text-align: right; height: 26px;">
											<asp:Label ID="Label23" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Address 1"></asp:Label>&nbsp;
										</td>
										<td style="text-align: left; height: 26px;">
											&nbsp;<asp:TextBox ID="txtAddress" runat="server" Width="255px" TextMode="MultiLine"></asp:TextBox>
										</td>
										<td style="text-align: right; height: 26px;">
											<asp:Label ID="Label24" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Address 2"></asp:Label>&nbsp;
										</td>
										<td colspan="3" style="text-align: left; height: 26px;">
											&nbsp;<asp:TextBox ID="txtAddress2" runat="server" Width="255px" TextMode="MultiLine"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<td style="text-align: right; height: 22px;">
											<asp:Label ID="Label3SSS" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="SSS"></asp:Label>
										</td>
										<td style="text-align: left; height: 22px;">
											<asp:CheckBox ID="cbSSS" runat="server" Text="" />
										</td>
										<td style="text-align: right; height: 22px;">
											<asp:Label ID="Label9" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Agreement"></asp:Label>&nbsp;
										</td>
										<td style="text-align: left; height: 22px;">
											<asp:CheckBox ID="cbAgrement" runat="server" Text=" " />
										</td>
										<td style="text-align: right; height: 22px;">
											&nbsp;
										</td>
										<td style="text-align: left; height: 22px;">
											&nbsp;
										</td>
									</tr>
									<tr>
										<td style="text-align: right; height: 22px;">
											<asp:Label ID="Label3LGD" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="LGD"></asp:Label>
										</td>
										<td style="text-align: left; height: 22px;">
											<asp:CheckBox ID="cbLGD" runat="server" Text="" />
										</td>
										<td style="text-align: right; height: 22px;">
											<asp:Label ID="Label8" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Check List"></asp:Label>
										</td>
										<td colspan="3" style="text-align: left; height: 22px;">
											<asp:CheckBox ID="cbCkeckList" runat="server" Text=" " />
											&nbsp;<asp:TextBox ID="txtCheckListBy" runat="server" Visible="false"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<td style="text-align: right; height: 22px;">
											<asp:Label ID="Label7" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="LDG"></asp:Label>
										</td>
										<td style="text-align: left; height: 22px;">
											<asp:CheckBox ID="cbLDG" runat="server" Text="" />
										</td>
										<td style="text-align: right; height: 22px;">
											<asp:Label ID="Label11" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Approved"></asp:Label>
											&nbsp;
										</td>
										<td colspan="3" style="text-align: left; height: 22px;">
											<asp:CheckBox ID="cbApproved" runat="server" Text=" " />
											&nbsp;<br />
										</td>
									</tr>
									<tr>
										<td style="text-align: right;">
											<asp:Label ID="lblattendwebinar" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Attend Webinar:"></asp:Label>
										</td>
										<td style="text-align: left;">
											<asp:TextBox ID="txtWebinarDate" runat="server" Width="225px"></asp:TextBox>
										</td>
										<td style="text-align: right;">
											<asp:Label ID="lblApprovedBy" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Approved By" Visible="false"></asp:Label>
										</td>
										<td align="left">
											<asp:TextBox ID="txtApprovedBy" runat="server" Visible="false"></asp:TextBox>
											<asp:TextBox ID="txtApprovedDate" runat="server" Visible="false"></asp:TextBox>
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
											<asp:Label ID="lblPassword" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Password" Visible="false"></asp:Label>
										</td>
										<td style="text-align: left;">
											<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Visible="false"></asp:TextBox>
										</td>
										<td style="text-align: right;">
											<asp:Label ID="Label5" runat="server" CssClass="DarkfontStyle" Font-Bold="False"
												Text="Visible"></asp:Label>
										</td>
										<td align="left">
											<asp:CheckBox ID="chBoxVisible" runat="server" Text=" " />
										</td>
										<td style="text-align: right;">
											&nbsp;
										</td>
										<td style="text-align: left;">
											&nbsp;
										</td>
									</tr>
									<tr>
										<td style="text-align: center;" colspan="6" align="center">
											<asp:Button ID="btnUpdate" runat="server" Text="Save" Width="101px" OnClick="btnUpdate_Click" />
											&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
											<asp:Button ID="btnDelete" runat="server" OnClientClick="javascript:return confirm('You are about to delete the selected Member. continue...?')"
												OnClick="btnDelete_Click" Text="Delete" Width="87px" CausesValidation="False" />
										</td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
				</div>
				<div id="pnlConfirmation" runat="server" style="z-index: 2; left: 38%; top: 18%;
					position: absolute; width: 500; background-color: Yellow;" visible="false">
					<table>
						<tr>
							<td>
								Send Email Notification, and register for webinar
							</td>
						</tr>
						<tr>
							<td>
								<asp:DropDownList ID="DDListWebinars" runat="server">
								</asp:DropDownList>
							</td>
						</tr>
						<tr>
							<td>
								<asp:Button ID="btnOk" runat="server" Text="Ok" OnClick="btnOk_Click" CausesValidation="False" />
								<asp:Button ID="btnNoReg" runat="server" Text="No Registration" OnClick="btnNoRegist_Click"
									CausesValidation="False" />
								<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
									CausesValidation="False" />
							</td>
						</tr>
						<tr>
							<td>
								<p>
								</p>
								<br />
								<p>
								</p>
							</td>
						</tr>
					</table>
				</div>
			</ContentTemplate>
		</asp:UpdatePanel>
	</div>
</asp:Content>
	