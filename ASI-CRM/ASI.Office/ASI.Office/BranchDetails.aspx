<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BranchDetails.aspx.cs" Inherits="BranchDetails"
	EnableEventValidation="false" ValidateRequest="false" Theme="Red" MasterPageFile="~/MasterLayout.master"
	Title="Branch Details" %>

<%@ MasterType VirtualPath="~/MasterLayout.master" %>
<%@ Register Src="Controls/AutoCompleteSearch.ascx" TagName="AutoCompleteSearch"
	TagPrefix="uc3" %>
<%@ Register Src="Controls/TransToolBar.ascx" TagName="TransToolBar" TagPrefix="uc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="Controls/Key.ascx" TagName="Key" TagPrefix="uc6" %>
<%@ Register Src="Controls/HistoryNC.ascx" TagName="HistoryNC" TagPrefix="uc7" %>
<%@ Register Src="Controls/Attachment.ascx" TagName="Attachment" TagPrefix="uc8" %>
<%@ Register Src="~/Controls/Contacts.ascx" TagName="Contacts" TagPrefix="ucC" %>
<asp:Content ID="Head" runat="server" ContentPlaceHolderID="head">
	<script language="javascript" src="Scripts/Scripts.js"></script>
	<script language="javascript">
		var wndHandle;
		function AttacheFile(BranchID) {
			wndHandle = window.open("AttachFile2.aspx?BranchID=" + BranchID, null, "alwaysraised=yes,left=20,top=250,resizable=no,scrollbars=no,status=yes,width=550,height=250", "")
		}

		function DownloadFile(AttachID) {
			wndHandle = window.open("DownloadFile.aspx?AttachID=" + AttachID, null, "alwaysraised=yes,left=1,top=1,resizable=no,scrollbars=no,status=yes,width=5,height=5", "")
			//        if (wndHandle && wndHandle.open) {
			//            wndHandle.close();
			//        }
		}
		function PageLoadedHandler() {
			var NewContact;
			NewContact = '<%=Session["NewContact"]%>';
			if (NewContact == 'True') {
				setTimeout(AddNewContactForAccount, 1);
			}
		}

	</script>
</asp:Content>
<asp:Content ID="Main" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
	<div class="header">
		<asp:UpdatePanel ID="UpdatePanel188" runat="server">
			<ContentTemplate>
				<uc1:TransToolBar ID="ucTransToolBar" runat="server" />
				<asp:ImageButton ID="imgbtnPrevious" runat="server" AlternateText="Previous Contact"
					ImageUrl="~/Images/LeftArrow_n.gif" OnClick="imgbtnPrevious_Click" /><asp:ImageButton
						ID="imgbtnNext" runat="server" AlternateText="Next Contact" ImageUrl="~/Images/RightArrow_n.gif"
						OnClick="imgbtnNext_Click" />
			</ContentTemplate>
		</asp:UpdatePanel>
		<asp:UpdatePanel ID="UpdatePanel2" runat="server">
			<ContentTemplate>
				<uc3:AutoCompleteSearch ID="ucAutoCompleteSearch" runat="server" />
			</ContentTemplate>
		</asp:UpdatePanel>
	</div>
	<div class="ui-layout-content">
	<table>
				<tr>
					<td rowspan="2" valign="top" style="width: 326px" align="left" colspan="">
						<asp:UpdatePanel ID="UpdatePanel5" runat="server">
							<ContentTemplate>
								<asp:Panel ID="pnlAccount" runat="server" Width="320px">
									<table border="1" bordercolor="#660000" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
										style="width: 320px; height: 460px">
										<tr>
											<td colspan="3" valign="top" align="center" style="width: 319px">
												<table cellpadding="0" cellspacing="0" style="width: 100%">
													<tr>
														<td background="Images/accountDetails_35.jpg" colspan="3" style="height: 25px">
															<asp:Label ID="Label2" runat="server" CssClass="MainfontStyle" Font-Bold="True" Font-Size="13px"
																Text="Company /Agency" ForeColor="White"></asp:Label>
														</td>
													</tr>
												</table>
												<table style="width: 100%">
													<tr>
														<td align="center" colspan="1" valign="top">
															<asp:UpdatePanel ID="UpdatePanel6" runat="server">
																<ContentTemplate>
																	&nbsp;<table style="width: 96px; border-right: darkgray thin solid; border-top: darkgray thin solid;
																		border-left: darkgray thin solid; border-bottom: darkgray thin solid;">
																		<tr>
																			<td colspan="2">
																				<asp:DropDownList ID="dllCompanyName" runat="server" Width="205px" CssClass="inputs"
																					AutoPostBack="True" DataTextField="AccountName" DataValueField="AccountID" OnDataBound="dllCompanyName_DataBound"
																					OnSelectedIndexChanged="dllCompanyName_SelectedIndexChanged" DataSourceID="odsAccountNames"
																					Enabled="False" AppendDataBoundItems="true" OnDataBinding="dllCompanyName_DataBinding">
																				</asp:DropDownList>
																			</td>
																			<td style="width: 260px">
																				<asp:ImageButton ID="ibtnAddNewAcc" runat="server" ImageUrl="~/Images/add.jpg" OnClick="ibtnAddNewAcc_Click"
																					ToolTip="Add new account" />
																			</td>
																		</tr>
																		<tr>
																			<td colspan="3">
																				<asp:Label ID="lblBS" runat="server" CssClass="MainfontStyle" Font-Bold="True" Text="Select Business Sector"
																					AssociatedControlID="ddlBusSector"></asp:Label><br />
																				<asp:DropDownList ID="ddlBusSector" runat="server" DataSourceID="odsBusSector" DataTextField="SubCode"
																					DataValueField="SubID" CssClass="inputs" Width="205px" Enabled="False" TabIndex="1">
																				</asp:DropDownList>
																			</td>
																		</tr>
																		<tr>
																			<td colspan="3">
																				<asp:Button ID="btnNewAccount" runat="server" Text="New" OnClick="btnNewAccount_Click"
																					CssClass="button" Visible="False" /><asp:Label ID="lblSelectedBS" runat="server"
																						ForeColor="White" Height="0px" Text="All" Width="0px"></asp:Label>
																			</td>
																		</tr>
																	</table>
																</ContentTemplate>
															</asp:UpdatePanel>
															<asp:FormView ID="frmViewAccounts" runat="server">
																<ItemTemplate>
																	<table>
																		<tr>
																			<td align="right" style="height: 21px; width: 50px">
																				<asp:Label ID="Label9" runat="server" CssClass="MainfontStyle" Font-Bold="True" Text="Business Sector"></asp:Label>
																			</td>
																			<td colspan="2" style="height: 21px">
																				<asp:TextBox ID="txtBusSector" runat="server" Width="200px" CssClass="inputs" Text='<%# Bind("BusinessSectorName") %>'
																					ReadOnly="True"></asp:TextBox>
																				<asp:HiddenField ID="BusSecID" runat="server" Value='<%# Bind("BusSector") %>' Visible="false" />
																			</td>
																		</tr>
																		<tr>
																			<td align="right" style="height: 21px; width: 50px">
																				<asp:Label ID="Label10" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																					Text="Phone"></asp:Label>
																			</td>
																			<td colspan="2">
																				<asp:TextBox ID="txtPhone" runat="server" Width="200px" CssClass="inputs" Text='<%# Bind("Phone") %>'
																					ReadOnly="True"></asp:TextBox>
																			</td>
																		</tr>
																		<tr>
																			<td align="right" style="height: 21px; width: 50px">
																				<asp:Label ID="Label11" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																					Text="Street 1"></asp:Label>
																			</td>
																			<td colspan="2">
																				<asp:TextBox ID="txtStreet1" runat="server" Width="200px" CssClass="inputs" Text='<%# Bind("Street1") %>'
																					ReadOnly="True"></asp:TextBox>
																			</td>
																		</tr>
																		<tr>
																			<td align="right" style="height: 21px; width: 50px">
																				<asp:Label ID="Label12" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																					Text="Street 2"></asp:Label>
																			</td>
																			<td colspan="2">
																				<asp:TextBox ID="txtStreet2" runat="server" Width="200px" CssClass="inputs" Text='<%# Bind("Street2") %>'
																					ReadOnly="True"></asp:TextBox>
																			</td>
																		</tr>
																		<tr>
																			<td align="right" style="height: 21px; width: 50px">
																				<asp:Label ID="Label13" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																					Text="City"></asp:Label>
																			</td>
																			<td colspan="2">
																				<asp:TextBox ID="txtCity" runat="server" Width="200px" CssClass="inputs" Text='<%# Bind("City") %>'
																					ReadOnly="True"></asp:TextBox>
																			</td>
																		</tr>
																		<tr>
																			<td align="right" style="height: 21px; width: 50px">
																				<asp:Label ID="Label14" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																					Text="State"></asp:Label>
																			</td>
																			<td colspan="2">
																				<asp:TextBox ID="txtState" runat="server" Width="200px" CssClass="inputs" Text='<%# Bind("State") %>'
																					ReadOnly="True"></asp:TextBox>
																			</td>
																		</tr>
																		<tr>
																			<td align="right" style="height: 21px; width: 50px">
																				<asp:Label ID="Label15" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																					Text="Zip Code"></asp:Label>
																			</td>
																			<td colspan="2">
																				<asp:TextBox ID="txtZipCode" runat="server" Width="200px" CssClass="inputs" Text='<%# Bind("ZipCode") %>'
																					ReadOnly="True"></asp:TextBox>
																			</td>
																		</tr>
																		<tr>
																			<td align="right" style="height: 21px; width: 50px">
																				<asp:Label ID="Label16" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																					Text="Country"></asp:Label>
																			</td>
																			<td colspan="2">
																				<asp:TextBox ID="txtCountry" runat="server" Width="200px" CssClass="inputs" Text='<%# Bind("CountryName") %>'
																					ReadOnly="True"></asp:TextBox>
																			</td>
																		</tr>
																		<tr>
																			<td align="right" style="height: 21px; width: 50px">
																				<asp:Label ID="Label17" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																					Text="Web Site"></asp:Label>
																			</td>
																			<td colspan="2" align="left">
																				<asp:HyperLink ID="txtWebSite" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "WebSite") %>'
																					Target="_blank" Text='<%# Bind("WebSite") %>'></asp:HyperLink>
																			</td>
																		</tr>
																		<tr>
																			<td align="right" style="height: 21px; width: 50px">
																				<asp:Label ID="Label18" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																					Text="Account Manager"></asp:Label>
																			</td>
																			<td colspan="2">
																				<asp:TextBox ID="txtAccountManager" runat="server" Width="200px" CssClass="inputs"
																					Text='<%# Bind("AccountManagerName") %>' ReadOnly="True"></asp:TextBox>
																			</td>
																		</tr>
																		<tr>
																			<td align="right" style="height: 21px; width: 50px">
																				<asp:Label ID="lblMainContact" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																					Text="Main Contact"></asp:Label>
																			</td>
																			<td align="left" colspan="2">
																				<asp:CheckBox ID="chboxMainContact" runat="server" Text=" " Enabled="false" />
																			</td>
																		</tr>
																	</table>
																</ItemTemplate>
															</asp:FormView>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</asp:Panel>
								<asp:ObjectDataSource ID="odsBranches" runat="server" OldValuesParameterFormatString="original_{0}"
									SelectMethod="GetBranches" TypeName="Office.BLL.BranchesBLL" ConvertNullToDBNull="True">
									<SelectParameters>
										<asp:ControlParameter Type="Int32" Name="AccountID" ControlID="dllCompanyName" PropertyName="SelectedValue" />
									</SelectParameters>
								</asp:ObjectDataSource>
								<asp:ObjectDataSource ID="odsAccounts" runat="server" OldValuesParameterFormatString="original_{0}"
									SelectMethod="SelectAccounts" TypeName="Office.BLL.AccountListsBLL">
									<SelectParameters>
										<asp:SessionParameter Name="CurrentAccount" SessionField="CurrentAccount" Type="Object" />
									</SelectParameters>
								</asp:ObjectDataSource>
								<asp:ObjectDataSource ID="odsAccountNames" runat="server" OldValuesParameterFormatString="original_{0}"
									SelectMethod="GetAccountList" TypeName="Office.BLL.ContactListsBLL">
									<SelectParameters>
										<asp:ControlParameter ControlID="lblSelectedBS" DefaultValue="All" Name="BusSector"
											PropertyName="Text" Type="String" />
									</SelectParameters>
								</asp:ObjectDataSource>
								<asp:ObjectDataSource ID="odsBusSectorNames" runat="server" OldValuesParameterFormatString="original_{0}"
									SelectMethod="GetAllBusSectorList" TypeName="Office.BLL.ContactListsBLL"></asp:ObjectDataSource>
							</ContentTemplate>
						</asp:UpdatePanel>
						<asp:ObjectDataSource ID="odsBusSector" runat="server" OldValuesParameterFormatString="original_{0}"
							SelectMethod="GetSubCodeList" TypeName="Office.BLL.AccountListsBLL">
							<SelectParameters>
								<asp:Parameter DefaultValue="BusinessSector" Name="CurrentGCode" Type="String" />
							</SelectParameters>
						</asp:ObjectDataSource>
						<br />
					</td>
					<td style="width: 350px" align="left" valign="top" colspan="2">
						<asp:UpdatePanel ID="UpdatePanel4" runat="server">
							<ContentTemplate>
								<table cellpadding="0" cellspacing="0" style="width: 107px">
									<tr>
										<td style="width: 343px;">
											<asp:FormView ID="frmViewBranchDetails" runat="server" AllowPaging="True" DataKeyNames="BranchID"
												Height="371px" OnPageIndexChanging="frmViewBranchDetails_PageIndexChanging">
												<ItemTemplate>
													<table border="1" bordercolor="#660000" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
														style="width: 340px;">
														<tr>
															<td colspan="2">
																<table cellpadding="0" cellspacing="0" style="width: 100%">
																	<tr>
																		<td align="center" background="Images/accountDetails_35.jpg" colspan="3" rowspan="3"
																			style="height: 25px">
																			<asp:Label ID="lblBarnches" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																				Font-Size="13px" ForeColor="White" Text="Branches"></asp:Label>
																		</td>
																	</tr>
																	<tr>
																	</tr>
																	<tr>
																	</tr>
																</table>
																<table>
																	<tr>
																		<td align="right" style="width: 152px; height: 14px;">
																			<asp:Label ID="lblBranch" runat="server" CssClass="MainfontStyle" Text="Branch Name"></asp:Label>
																			<asp:HiddenField ID="HiddenBranchID" runat="server" Value='<%# Bind("BranchID") %>'
																				Visible="false" />
																			<asp:HiddenField ID="HiddenAccountID" runat="server" Value='<%# Bind("AccountID") %>'
																				Visible="false" />
																			<%--<asp:TextBox runat="server" ID="HiddenBranchID" Text='<%# Bind("BranchID") %>' Width="0" Height="0" />--%>
																		</td>
																		<td align="left" style="width: 244px;">
																			<asp:TextBox ID="txtboxBranchName" runat="server" BackColor="#FFFF80" CssClass="txtinputs"
																				Text='<%# Bind("BranchName") %>' Enabled="False"></asp:TextBox>
																			<asp:Label ID="lblErrSymAccName" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																				ForeColor="Red" Text="*" Visible="False"></asp:Label>
																		</td>
																	</tr>
																	<tr>
																		<td align="right" style="width: 152px;">
																			<asp:Label ID="lblPhone" runat="server" CssClass="MainfontStyle" Text="Telephone"></asp:Label>
																		</td>
																		<td align="left" style="width: 244px; height: 6px">
																			<asp:TextBox ID="txtboxPhone" runat="server" BackColor="#FFFF80" CssClass="txtinputs"
																				TabIndex="2" Text='<%# Bind("phone") %>' Enabled="False"></asp:TextBox>
																			<asp:Label ID="lblErrSymPhone" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																				ForeColor="Red" Text="*" Visible="False"></asp:Label>
																		</td>
																	</tr>
																	<tr>
																		<td align="right" style="width: 152px;">
																			<asp:Label ID="lblFax" runat="server" CssClass="MainfontStyle" Text="Fax"></asp:Label>
																		</td>
																		<td align="left" style="width: 244px; height: 6px">
																			<asp:TextBox ID="txtboxFax" runat="server" CssClass="txtinputs" TabIndex="3" Text='<%# Bind("Fax") %>'
																				Enabled="False"></asp:TextBox>
																			<br />
																			<asp:Label ID="lblErrValidFax" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																				ForeColor="Red" Text="*" Visible="False"></asp:Label>
																		</td>
																	</tr>
																	<tr>
																		<td align="right" style="width: 120px; height: 14px;">
																			<asp:Label ID="lblStreet1" runat="server" CssClass="MainfontStyle" Text="Street 1"></asp:Label>
																		</td>
																		<td align="left" style="width: 244px; height: 14px;">
																			<asp:TextBox ID="txtboxStreet1" runat="server" CssClass="txtinputs" TabIndex="7"
																				Text='<%# Bind("Street1") %>' Enabled="False"></asp:TextBox>
																		</td>
																	</tr>
																	<tr>
																		<td align="right" style="width: 120px;">
																			<asp:Label ID="lblStreet2" runat="server" CssClass="MainfontStyle" Text="Street 2"></asp:Label>
																		</td>
																		<td align="left" style="width: 244px; height: 6px">
																			<asp:TextBox ID="txtboxStreet2" runat="server" CssClass="txtinputs" TabIndex="8"
																				Text='<%# Bind("Street2") %>' Enabled="False"></asp:TextBox>
																		</td>
																	</tr>
																	<tr>
																		<td align="right" style="width: 120px;">
																			<asp:Label ID="lblCity" runat="server" CssClass="MainfontStyle" Text="City"></asp:Label>
																		</td>
																		<td align="left" style="width: 244px; height: 6px">
																			<asp:TextBox ID="txtboxCity" runat="server" CssClass="txtinputs" TabIndex="9" Text='<%# Bind("City") %>'
																				Enabled="False"></asp:TextBox>
																		</td>
																	</tr>
																	<tr>
																		<td align="right" style="width: 120px;">
																			<asp:Label ID="lblZipCode" runat="server" CssClass="MainfontStyle" Text="Zip Code"></asp:Label>
																		</td>
																		<td align="left" style="width: 244px; height: 6px">
																			<asp:TextBox ID="txtboxZipCode" runat="server" BackColor="#FFFF80" CssClass="txtinputs"
																				TabIndex="10" Text='<%# Bind("ZipCode") %>' Enabled="False"></asp:TextBox>
																			<br />
																			<asp:Label ID="lblErrSymZipCode" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																				ForeColor="Red" Text="*" Visible="False"></asp:Label>
																		</td>
																	</tr>
																	<tr>
																		<td align="right" style="width: 152px;">
																			<asp:Label ID="lblAccountCountry" runat="server" CssClass="MainfontStyle" Text="Country"></asp:Label>
																		</td>
																		<td align="left" style="width: 244px; height: 21px;">
																			<asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" CssClass="inputs"
																				DataSourceID="odsCountries" DataTextField="SubCode" DataValueField="SubID" Enabled="False"
																				Width="200px" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" TabIndex="11">
																			</asp:DropDownList>
																			<asp:TextBox ID="txtCountryID" runat="server" CssClass="txtinputs" Text='<%# Bind("CountryID") %>'
																				Visible="False"></asp:TextBox>
																		</td>
																	</tr>
																	<tr>
																		<td align="right" style="width: 152px;">
																			<asp:Label ID="lblState" runat="server" CssClass="MainfontStyle" Text="State"></asp:Label>
																		</td>
																		<td align="left" style="width: 244px; height: 8px;">
																			<asp:DropDownList ID="ddlState" runat="server" CssClass="inputs" DataSourceID="odsStates"
																				DataTextField="SubCode" DataValueField="SubCode" TabIndex="12" Visible="False"
																				Enabled="False">
																			</asp:DropDownList>
																			<asp:TextBox ID="txtState" runat="server" CssClass="txtinputs" TabIndex="13" Text='<%# Bind("State") %>'
																				Visible="true" Enabled="False"></asp:TextBox>
																		</td>
																	</tr>
																	<tr>
																		<td align="right" style="width: 152px;">
																			<asp:Label ID="lblWebSite" runat="server" CssClass="MainfontStyle" Text="Web Site"></asp:Label>
																		</td>
																		<td align="left" style="width: 244px; height: 6px">
																			<asp:TextBox ID="txtboxWebsite" runat="server" CssClass="txtinputs" TabIndex="4"
																				Text='<%# Bind("WebSite") %>' Enabled="False"></asp:TextBox>
																			<br />
																			<asp:Label ID="lblErrSymWebSite" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																				ForeColor="Red" Text="*" Visible="False"></asp:Label>
																		</td>
																	</tr>
																	<tr>
																		<td align="right" style="width: 152px; height: 21px;">
																			<asp:Label ID="lblReferredBy" runat="server" CssClass="MainfontStyle" Text="Referred By"></asp:Label>
																		</td>
																		<td align="left" style="width: 244px; height: 21px;">
																			<asp:TextBox ID="txtboxRefBy" runat="server" CssClass="txtinputs" TabIndex="6" Text='<%# Bind("ReferedBy") %>'
																				Enabled="False"></asp:TextBox>
																			<asp:TextBox ID="txtStatus" runat="server" CssClass="txtinputs" Text='<%# Bind("IDStatus") %>'
																				Visible="False" Width="30px" Enabled="False"></asp:TextBox>
																		</td>
																	</tr>
																	<tr>
																		<td align="right" style="width: 152px; height: 8px;">
																			<asp:Label ID="lblHeadquarter" runat="server" CssClass="MainfontStyle" Text="Headquarter"></asp:Label>
																		</td>
																		<td align="left" style="width: 244px; height: 8px;" valign="top">
																			<asp:CheckBox ID="chBoxHeadQ" Checked='<%# Bind("MainOffice") %>' runat="server"
																				Text=" " Enabled="False" />
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
													</table>
												</ItemTemplate>
												<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPrevious" NextPageImageUrl="~/Images/Right-arrow.gif"
													NextPageText="Next" PreviousPageImageUrl="~/Images/Left-Arrow.gif" PreviousPageText="Previous"
													Visible="false" />
												<InsertItemTemplate>
													<table border="0">
														<tr>
															<td align="right" style="width: 152px; height: 14px;">
																&nbsp;<asp:Label ID="lblBranch" runat="server" CssClass="MainfontStyle" Text="Branch Name"></asp:Label>
																<asp:HiddenField ID="HiddenBranchID" runat="server" Value='<%# Bind("BranchID") %>'
																	Visible="false" />
																<asp:HiddenField ID="HiddenAccountID" runat="server" Value='<%# Bind("AccountID") %>'
																	Visible="false" />
																<%--<asp:TextBox runat="server" ID="HiddenBranchID" Text='<%# Bind("BranchID") %>' Width="0" Height="0" />--%>
															</td>
															<td align="left" style="width: 244px;">
																<asp:TextBox ID="txtboxBranchName" runat="server" BackColor="#FFFF80" CssClass="txtinputs"
																	Text='<%# Bind("BranchName") %>'></asp:TextBox>
																<asp:Label ID="lblErrSymAccName" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																	ForeColor="Red" Text="*" Visible="False"></asp:Label>
															</td>
														</tr>
														<tr>
															<td align="right" style="width: 152px; height: 14px;">
																<asp:Label ID="lblStreet1" runat="server" CssClass="MainfontStyle" Text="Street 1"></asp:Label>
															</td>
															<td align="left" style="width: 244px; height: 14px;">
																<asp:TextBox ID="txtboxStreet1" runat="server" CssClass="txtinputs" TabIndex="7"
																	Text='<%# Bind("Street1") %>'></asp:TextBox>
															</td>
														</tr>
														<tr>
															<td align="right" style="width: 152px;">
																<asp:Label ID="lblPhone" runat="server" CssClass="MainfontStyle" Text="Telephone"></asp:Label>
															</td>
															<td align="left" style="width: 244px; height: 6px">
																<asp:TextBox ID="txtboxPhone" runat="server" BackColor="#FFFF80" CssClass="txtinputs"
																	TabIndex="2" Text='<%# Bind("phone") %>'></asp:TextBox>
																<asp:Label ID="lblErrSymPhone" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																	ForeColor="Red" Text="*" Visible="False"></asp:Label>
															</td>
														</tr>
														<tr>
															<td align="right" style="width: 152px; height: 14px;">
																<asp:Label ID="lblStreet2" runat="server" CssClass="MainfontStyle" Text="Street 2"></asp:Label>
															</td>
															<td align="left" style="width: 244px; height: 6px">
																<asp:TextBox ID="txtboxStreet2" runat="server" CssClass="txtinputs" TabIndex="8"
																	Text='<%# Bind("Street2") %>'></asp:TextBox>
															</td>
														</tr>
														<tr>
															<td align="right" style="width: 152px;">
																<asp:Label ID="lblFax" runat="server" CssClass="MainfontStyle" Text="Fax"></asp:Label>
															</td>
															<td align="left" style="width: 244px; height: 6px">
																<asp:TextBox ID="txtboxFax" runat="server" CssClass="txtinputs" TabIndex="3" Text='<%# Bind("Fax") %>'></asp:TextBox>
																<asp:Label ID="lblErrValidFax" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																	ForeColor="Red" Text="*" Visible="False"></asp:Label>
															</td>
														</tr>
														<tr>
															<td align="right" style="width: 152px; height: 14px;">
																<asp:Label ID="lblCity" runat="server" CssClass="MainfontStyle" Text="City"></asp:Label>
															</td>
															<td align="left" style="width: 244px; height: 6px">
																<asp:TextBox ID="txtboxCity" runat="server" CssClass="txtinputs" TabIndex="9" Text='<%# Bind("City") %>'></asp:TextBox>
															</td>
														</tr>
														<tr>
															<td align="right" style="width: 152px;">
																<asp:Label ID="lblWebSite" runat="server" CssClass="MainfontStyle" Text="Web Site"></asp:Label>
															</td>
															<td align="left" style="width: 244px; height: 6px">
																<asp:TextBox ID="txtboxWebsite" runat="server" CssClass="txtinputs" TabIndex="4"
																	Text='<%# Bind("WebSite") %>'></asp:TextBox>
																<asp:Label ID="lblErrSymWebSite" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																	ForeColor="Red" Text="*" Visible="False"></asp:Label>
															</td>
														</tr>
														<tr>
															<td align="right" style="width: 152px; height: 14px;">
																<asp:Label ID="lblZipCode" runat="server" CssClass="MainfontStyle" Text="Zip Code"></asp:Label>
															</td>
															<td align="left" style="width: 244px; height: 6px">
																<asp:TextBox ID="txtboxZipCode" runat="server" BackColor="#FFFF80" CssClass="txtinputs"
																	TabIndex="10" Text='<%# Bind("ZipCode") %>'></asp:TextBox>
																<asp:Label ID="lblErrSymZipCode" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																	ForeColor="Red" Text="*" Visible="False"></asp:Label>
															</td>
														</tr>
														<tr>
															<td align="right" style="width: 152px; height: 21px;">
																<asp:Label ID="lblReferredBy" runat="server" CssClass="MainfontStyle" Text="Referred By"></asp:Label>
															</td>
															<td align="left" style="width: 244px; height: 21px;">
																<asp:TextBox ID="txtboxRefBy" runat="server" CssClass="txtinputs" TabIndex="6" Text='<%# Bind("ReferedBy") %>'></asp:TextBox>
																<asp:TextBox ID="txtStatus" runat="server" CssClass="txtinputs" Text='<%# Bind("IDStatus") %>'
																	Visible="False" Width="30px"></asp:TextBox>
															</td>
														</tr>
														<tr>
															<td align="right" style="width: 120px; height: 21px;">
																<asp:Label ID="lblAccountCountry" runat="server" CssClass="MainfontStyle" Text="Country"></asp:Label>
															</td>
															<td align="left" style="width: 244px; height: 21px;">
																<asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" CssClass="inputs"
																	DataSourceID="odsCountries" DataTextField="SubCode" DataValueField="SubID" Enabled="true"
																	OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" TabIndex="11" Width="200px">
																</asp:DropDownList>
																<asp:TextBox ID="txtCountryID" runat="server" CssClass="txtinputs" Text='<%# Bind("CountryID") %>'
																	Visible="False" Width="30px"></asp:TextBox>
															</td>
														</tr>
														<tr>
															<td align="right" style="width: 152px; height: 8px;">
																<asp:Label ID="lblHeadquarter" runat="server" CssClass="MainfontStyle" Text="Headquarter"></asp:Label>
															</td>
															<td align="left" style="width: 244px; height: 8px;" valign="top">
																<asp:CheckBox ID="chBoxHeadQ" Checked='<%# Bind("MainOffice") %>' runat="server"
																	Text=" " />
															</td>
														</tr>
														<tr>
															<td align="right" style="width: 120px; height: 8px;" valign="top">
																<asp:Label ID="lblState" runat="server" CssClass="MainfontStyle" Text="State"></asp:Label>
															</td>
															<td align="left" style="width: 244px; height: 8px;">
																<asp:DropDownList ID="ddlState" runat="server" CssClass="inputs" DataSourceID="odsStates"
																	DataTextField="SubCode" DataValueField="SubCode" TabIndex="12" Visible="False"
																	Width="205px">
																</asp:DropDownList>
																<asp:TextBox ID="txtState" runat="server" CssClass="txtinputs" TabIndex="13" Text='<%# Bind("State") %>'
																	Visible="true" Width="200px"></asp:TextBox>
															</td>
														</tr>
													</table>
												</InsertItemTemplate>
											</asp:FormView>
											<asp:ObjectDataSource ID="odsStates" runat="server" OldValuesParameterFormatString="original_{0}"
												SelectMethod="GetSubCodeList" TypeName="Office.BLL.ContactListsBLL">
												<SelectParameters>
													<asp:Parameter DefaultValue="state" Name="CurrentGCode" Type="String" />
												</SelectParameters>
											</asp:ObjectDataSource>
											<asp:ObjectDataSource ID="odsCountries" runat="server" OldValuesParameterFormatString="original_{0}"
												SelectMethod="GetSubCodeList" TypeName="Office.BLL.ContactListsBLL">
												<SelectParameters>
													<asp:Parameter DefaultValue="Country" Name="CurrentGCode" Type="String" />
												</SelectParameters>
											</asp:ObjectDataSource>
											<asp:ObjectDataSource ID="odsBranchDetails" runat="server" DataObjectTypeName="System.Web.UI.WebControls.GridView"
												OldValuesParameterFormatString="original_{0}" OnSelecting="odsBranchDetails_Selecting"
												SelectMethod="GetBranchByID" TypeName="Office.BLL.BranchesBLL"></asp:ObjectDataSource>
											<asp:ObjectDataSource ID="odsBranchDetails0" runat="server" SelectMethod="SelectBranches"
												TypeName="Office.BLL.BranchesPageBLL" OldValuesParameterFormatString="original_{0}">
												<SelectParameters>
													<asp:SessionParameter Name="CurrentBranch" SessionField="Branch" Type="Object" />
												</SelectParameters>
											</asp:ObjectDataSource>
											<asp:Label ID="lblAddUserMsg" runat="server" Font-Bold="True" Font-Names="Tahoma"
												Font-Size="Small" ForeColor="Blue" Visible="False"></asp:Label>
										</td>
									</tr>
									<tr>
										<td align="center" style="width: 343px;">
											<asp:Label ID="lblEmptyResults" runat="server" Font-Bold="True" Font-Names="Tahoma"
												Font-Size="Large" ForeColor="Blue" Text="No results found" Width="152px" Visible="False"></asp:Label>
										</td>
									</tr>
								</table>
								<asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
								<asp:Button ID="btnAddEditNotes" runat="server" Height="0px" OnClick="btnAddEditNotes_Click"
									Text="AddEditNotes" Width="0px" />
							</ContentTemplate>
						</asp:UpdatePanel>
					</td>
				</tr>
				<tr>
					<td align="left" colspan="2" valign="top">
						<asp:Label ID="lblResult" runat="server"></asp:Label>
					</td>
				</tr>
			</table>
	</div>
	<div class="footer">
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate>
				<div id="divTabs" runat="server" align="left" style="width: 850px">
					<ajaxToolkit:TabContainer id="TabContainer1" runat="server" activetabindex="0" scrollbars="Auto"
						height="350px" width="850px" cssclass="" onactivetabchanged="TabContainer1_ActiveTabChanged">
                            <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="">
                                <HeaderTemplate>
                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                        <ContentTemplate>
                                            <asp:ImageButton ID="imgNotesTab" runat="server" ImageUrl="~/Images/notes_normal.png"
                                                OnClick="imgNotesTab_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </HeaderTemplate>
                       
                                <ContentTemplate>
                                    <div align="center" style="background-color: White">
                                        <div style="font-weight: bold; font-size: 12px; color: white; font-family: Tahoma">
                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                <ContentTemplate>
                                                    <div style="width: 100%; background-color: black; vertical-align: bottom;">
                                                        Filter Date:
                                                        <asp:TextBox ID="txtCalender" runat="server" Width="80px" OnTextChanged="txtCalender_TextChanged"
                                                            CssClass="inputs" AutoPostBack="True"></asp:TextBox>
                                                        <img id="imgCalender" runat="server" src="Images/Calender.gif" style="vertical-align: middle"
                                                            class="HandOverCursor" alt="Pick a date" />
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="imgCalender"
                                                            TargetControlID="txtCalender" PopupPosition="BottomRight" BehaviorID="CalendarExtender1">
                                                        </ajaxToolkit:CalendarExtender>
                                                        <img id="imgAddEditNotes" runat="server" src="Images/addorEditnotes.gif" onclick="AddEdit_Note();"
                                                            onmouseover="src='Images/addorEditnotes_over.png'" onmouseout="src='Images/addorEditnotes.gif'"
                                                            class="HandOverCursor" alt="Add or Edit Notes" style="vertical-align: middle" />&nbsp;
                                                        <ajaxToolkit:PopupControlExtender ID="PopupControlExtender1" runat="server" Position="Bottom"
                                                            OffsetX="-350" OffsetY="-200" TargetControlID="imgAddEditNotes" PopupControlID="pnlNote" BehaviorID="PopupControlExtender12">
                                                        </ajaxToolkit:PopupControlExtender>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <div style="overflow: hidden; width: 96%; height: 5px">
                                            </div>
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <asp:Panel ID="pnlNote" runat="server">
                                                    <div align="center" style="background-color: #dfdfdf; border-right: black thin solid;
                                                        border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid;">
                                                        <div align="center" style="width: 652px; background-color: black; overflow: hidden;
                                                            height: 20px;">
                                                            <strong style="font-weight: bold; font-size: 12px; color: white; font-family: Tahoma">
                                                                Note Entry and Edit</strong>
                                                        </div>
                                                        <div style="width: 300px;">
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <img id="Img2" src="Images/add.jpg" onclick="Add_Note();" onmouseover="src='Images/orange_mouseover_29.gif'"
                                                                onmouseout="src='Images/add.jpg'" class="HandOverCursor" alt="Add New Note" />
                                                            <!-- <img id="Img2" src="Images/edit.jpg" visible="false" onmouseover="src='Images/orange_mouseover_31.gif'" onmouseout="src='Images/edit.jpg'" class="HandOverCursor" alt="Update Note" /> -->
                                                            <img id="Img5" src="Images/save.jpg" onclick="Save_Note();" onmouseover="src='Images/orange_mouseover_11.gif'"
                                                                onmouseout="src='Images/save.jpg'" class="HandOverCursor" alt="Save Note" />
                                                            <img id="Img6" src="Images/cancel_normal.png" onclick="Cancel_Note();" onmouseover="src='Images/cancel_selected.gif'"
                                                                onmouseout="src='Images/cancel_normal.png'" class="HandOverCursor" alt="Cancel" />
                                                        </div>
                                                        <div align="center">
                                                            <div style="width: 652px">
                                                                <div style="height: 23px; width: 100px; float: left; font-weight: bold; font-size: 12px;
                                                                    color: black; font-family: Tahoma;" align="right">
                                                                    <asp:Label ID="lblEnteredDate" runat="server" Text="Entered:" Visible="false"></asp:Label>&nbsp;</div>
                                                                <div style="width: 110px; float: left;">
                                                                    <asp:TextBox ID="txtEnteredDate" runat="server" Width="100%" Visible="false" ReadOnly="True" CssClass="inputs"></asp:TextBox></div>
                                                                <div style="height: 23px; width: 100px; float: left; font-weight: bold; font-size: 12px;
                                                                    color: black; font-family: Tahoma;" align="right">
                                                                    <asp:Label ID="lblEnteredTime" runat="server" Text="Time:" Visible="false"></asp:Label>&nbsp;</div>
                                                                <div style="width: 110px; float: left;">
                                                                    <asp:TextBox ID="txtEnteredTime" runat="server" Width="100%" Visible="false" ReadOnly="True" CssClass="inputs"></asp:TextBox></div>
                                                                <div style="height: 23px; width: 100px; float: left; font-weight: bold; font-size: 12px;
                                                                    color: black; font-family: Tahoma;" align="right">
                                                                    <asp:Label ID="lblEnteredBy" runat="server" Text="By:" Visible="false"></asp:Label>&nbsp;</div>
                                                                <div style="width: 110px; float: left;">
                                                                    <asp:TextBox ID="txtEnteredBy" runat="server" Width="100%" Visible="false" ReadOnly="True" CssClass="inputs"></asp:TextBox></div>
                                                            </div>
                                                            <div style="width: 652px">
                                                                <div style="height: 23px; width: 100px; float: left; font-weight: bold; font-size: 12px;
                                                                    color: black; font-family: Tahoma;" align="right">
                                                                    <asp:Label ID="lblEditDate" runat="server" Text="Edit:" Visible="false"></asp:Label>&nbsp;</div>
                                                                <div style="width: 110px; float: left;">
                                                                    <asp:TextBox ID="txtEditDate" runat="server" Width="100%" Visible="false" ReadOnly="True" CssClass="inputs"></asp:TextBox></div>
                                                                <div style="height: 23px; width: 100px; float: left; font-weight: bold; font-size: 12px;
                                                                    color: black; font-family: Tahoma;" align="right">
                                                                    <asp:Label ID="lblEditTime" runat="server" Text="Time:" Visible="false"></asp:Label>&nbsp;</div>
                                                                <div style="width: 110px; float: left;">
                                                                    <asp:TextBox ID="txtEditTime" runat="server" Width="100%" Visible="false" ReadOnly="True" CssClass="inputs"></asp:TextBox></div>
                                                                <div style="height: 23px; width: 100px; float: left; font-weight: bold; font-size: 12px;
                                                                    color: black; font-family: Tahoma;" align="right">
                                                                    <asp:Label ID="lblEditBy" runat="server" Text="By:" Visible="false"></asp:Label>&nbsp;</div>
                                                                <div style="width: 110px; float: left;">
                                                                    <asp:TextBox ID="txtEditBy" runat="server" Width="100%" Visible="false" ReadOnly="True" CssClass="inputs"></asp:TextBox></div>
                                                            </div>
                                                            <div style="width: 652px" align="center">
                                                                <div style="width: 652px">
                                                                     &#160; &#160; &#160; &#160; &#160;<asp:Label ID="lblContact" runat="server" Text="Contact:"
                                                                        ForeColor="Black" Visible="false"></asp:Label>
                                                                    <asp:TextBox ID="txtContact" runat="server" Width="110px" ReadOnly="True" CssClass="inputs" Visible="false"></asp:TextBox></div>
                                                                <div style="width: 652px">
                                                                    <table style="color: black; width: 429px;" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td align="right" style="width: 89px; height: 18px">
                                                                                <asp:Label ID="Label4" runat="server" Text="Note Date:" Width="75px"></asp:Label>
                                                                            </td>
                                                                            <td align="left" style="width: 27px; height: 18px">
                                                                                <asp:TextBox ID="txtUserNoteDate" runat="server" Width="110px"></asp:TextBox>
                                                                            </td>
                                                                            <td style="width: 95px; height: 18px" align="left">
                                                                                <img id="imgNoteDate" runat="server" src="Images/Calender.gif" style="vertical-align: middle"
                                                                                    class="HandOverCursor" alt="Pick a Date" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label5" runat="server" Text="Note Time:" Width="70px"></asp:Label>
                                                                            </td>
                                                                            <td style="height: 18px" align="left">
                                                                                <asp:TextBox ID="txtHours" runat="server" Width="20px"></asp:TextBox>:<asp:TextBox
                                                                                    ID="txtMin" runat="server" Width="20px"></asp:TextBox>
                                                                            </td>
                                                                            <td style="width: 84px; height: 18px" align="left">
                                                                                <asp:DropDownList ID="ddlTime" runat="server">
                                                                                    <asp:ListItem Selected="True">AM</asp:ListItem>
                                                                                    <asp:ListItem>PM</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender52" runat="server" PopupButtonID="imgNoteDate"
                                                                        TargetControlID="txtUserNoteDate" BehaviorID="CalendarExtender521">
                                                                    </ajaxToolkit:CalendarExtender>
                                                                    &#160;&#160;
                                                                </div>
                                                                <asp:Button ID="btnNew" runat="server" Text="New" UseSubmitBehavior="False" OnClick="btnNew_Click"
                                                                    Height="0px" Width="0px" />
                                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" UseSubmitBehavior="False" Height="0px"
                                                                    Width="0px" />
                                                                <asp:Button ID="btnSave" runat="server" Text="Save" UseSubmitBehavior="False" OnClick="btnSave_Click"
                                                                    Height="0px" Width="0px" />&nbsp;
                                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                                                                    UseSubmitBehavior="False" Height="0px" Width="0px" />
                                                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtHours"
                                                                    ErrorMessage="Hours value must be (1~12)" MaximumValue="12" MinimumValue="1"
                                                                    Type="Integer" SetFocusOnError="True"></asp:RangeValidator>
                                                                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtMin"
                                                                    ErrorMessage="Minutes value must be (0~59)" MaximumValue="59" MinimumValue="0"
                                                                    Type="Integer" SetFocusOnError="True"></asp:RangeValidator>
                                                            </div>
                                                            <div style="width: 652px" align="center">
                                                                <%--<FTB:FreeTextBox id="txtNote" runat="Server" BackColor="223, 223, 223" ButtonSet="Office2000" GutterBackColor="213, 213, 213" ToolbarBackColor="223, 223, 223" ToolbarBackgroundImage="True" UseToolbarBackGroundImage="True" Height="150px" Width="500px" />--%>
                                                                <FCKeditorV2:FCKeditor ID="txtNote" runat="server" BasePath="fckeditor/" ToolbarSet="MyToolbar"
                                                                    Height="150px" Width="500px">
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                </FCKeditorV2:FCKeditor>
                                                                <%--<asp:TextBox ID="txtNote" runat="server" Rows="7" TextMode="MultiLine" Width="500px" CssClass="inputs"></asp:TextBox>--%>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <ajaxToolkit:NumericUpDownExtender ID="NumericUpDownExtender1" runat="server" TargetControlID="txtHours"
                                                        Width="45" RefValues="" ServiceDownMethod="" ServiceUpMethod="" TargetButtonDownID=""
                                                        TargetButtonUpID="" Minimum="1" Maximum="12" />
                                                    <ajaxToolkit:NumericUpDownExtender ID="NumericUpDownExtender2" runat="server" TargetControlID="txtMin"
                                                        Width="45" RefValues="" ServiceDownMethod="" ServiceUpMethod="" TargetButtonDownID=""
                                                        TargetButtonUpID="" Minimum="0" Maximum="59" />
                                                    <asp:HiddenField ID="hdnNote" runat="server" />
                                                    </asp:Panel>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="gvNotes" runat="server" AllowPaging="True" AllowSorting="True"
                                                    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="NID" ForeColor="#333333"
                                                    GridLines="None" OnPageIndexChanging="gvNotes_PageIndexChanging" OnRowCreated="gvNotes_RowCreated"
                                                    OnRowDataBound="gvNotes_RowDataBound" OnSelectedIndexChanged="gvNotes_SelectedIndexChanged"
                                                    OnSorting="gvNotes_Sorting" PageSize="20" Width="1000px" OnRowDeleting="gvNotes_RowDeleting">
                                                    <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                                                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="White" CssClass="GridNormalRowsStyle" ForeColor="#333333" HorizontalAlign="Left" />
                                                    <Columns>
                                                        <asp:BoundField DataField="NoteDateStr" HeaderText="Date" SortExpression="NoteDate"
                                                            NullDisplayText=" ">
                                                            <HeaderStyle Width="7%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="NoteTimeStr" HeaderText="Time" NullDisplayText=" ">
                                                            <HeaderStyle Width="8%" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Regarding">
                                                            <ItemTemplate>
                                                                <div style="width: 500px; word-wrap: break-word;">
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Notes") %>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="500px" />
                                                            <ItemStyle Width="500px" Wrap="True" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="EditByName" HeaderText="Edited By" NullDisplayText=" ">
                                                            <HeaderStyle Width="10%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="EditDateStr" HeaderText="Edit Date" NullDisplayText=" ">
                                                            <HeaderStyle Width="7%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ContactFirstName" HeaderText="Contact" NullDisplayText=" ">
                                                            <HeaderStyle Width="8%" />
                                                        </asp:BoundField>
                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True">
                                                            <HeaderStyle Width="5%" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:CommandField>
                                                    </Columns>
                                                    <PagerStyle BackColor="#FFCC66" CssClass="GridPagerStyle" ForeColor="#333333" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#FFCC66" CssClass="SelectedRowColor" Font-Bold="True" />
                                                    <HeaderStyle BackColor="#990000" CssClass="GridHeaderBackStyle" Font-Bold="True"
                                                        Font-Names="Tahoma" Font-Size="12px" ForeColor="White" Height="20px" />
                                                </asp:GridView>
                                                <asp:ObjectDataSource ID="odsNotes" runat="server" OldValuesParameterFormatString="original_{0}"
                                                    SelectMethod="GetContactNotes" TypeName="Office.BLL.ContactListsBLL">
                                                    <SelectParameters>
                                                        <asp:SessionParameter Name="CurrentNote" SessionField="CurrentNote" Type="Object" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" Width="100%">
                                <HeaderTemplate>
                                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                        <ContentTemplate>
                                            <asp:ImageButton ID="imgContactsTab" runat="server" ImageUrl="~/Images/contacts_normal.png"
                                                OnClick="imgContactsTab_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <div align="center" style="background-color: white">
                                        <asp:UpdatePanel ID="upContact" runat="server">
                                            <ContentTemplate>
                                                <ucC:Contacts ID="Contacts1" runat="server" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <%--  added by Sayed Moawad 19/7/2011--%>
                            <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" Width="100%">
                                <HeaderTemplate>
                                    <asp:UpdatePanel ID="UpdatePanelKeySoftware" runat="server">
                                        <ContentTemplate>
                                            <asp:ImageButton ID="imgbtnKeySoftware" runat="server" AlternateText="Key" ImageUrl="~/Images/Keys-n.png"
                                                OnClick="imgbtnKeySoftware_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <div align="center" style="background-color: White;">
                                        <asp:UpdatePanel ID="UpdatePanel11_" runat="server">
                                            <ContentTemplate>
                                                <div align="center" style="font-weight: bold; font-size: 12px; font-family: Tahoma;">
                                                    <asp:UpdatePanel ID="UpdatePanel12_" runat="server">
                                                        <ContentTemplate>
                                                            <div align="center" style="text-align: center">
                                                                <!-- from here -->
                                                                <asp:Panel ID="pnlKeySoftware" runat="server" CssClass="modalPopup" Style="display: none">
                                                                    <asp:UpdatePanel ID="UpdatePanel11__" runat="server" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <%--<uc5:BranchForm 
                                                                                                                 ID="BranchForm2" runat="server" />--%>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </asp:Panel>
                                                                <uc6:Key ID="Key1" runat="server" />
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanel5" runat="server" Width="100%">
                                <HeaderTemplate>
                                    <asp:UpdatePanel ID="UpdatePanelHistory" runat="server">
                                        <ContentTemplate>
                                            <asp:ImageButton ID="imgbtnHistory" runat="server" AlternateText="Key" ImageUrl="~/Images/History-n.png"
                                                OnClick="imgbtnHistory_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <div align="center" style="background-color: White;">
                                        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                            <ContentTemplate>
                                                <div align="center" style="font-weight: bold; font-size: 12px; font-family: Tahoma;">
                                                    <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                        <ContentTemplate>
                                                            <div align="center" style="text-align: center">
                                                                <!-- from here -->
                                                                <%--<asp:Panel ID="Panel2" 
                                                                                                     runat="server" CssClass="modalPopup" Style="display: none"></asp:Panel>--%><uc7:HistoryNC
                                                                                                         ID="HistoryNC1" runat="server" />
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanel6" runat="server" Width="100%">
                                <HeaderTemplate>
                                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                        <ContentTemplate>
                                            <asp:ImageButton ID="imgbtnAttachments" runat="server" AlternateText="Attachments"
                                                ImageUrl="~/Images/Attachments-n.png" OnClick="imgbtnAttachments_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <div align="center" style="background-color: White;">
                                        <%-- <asp:UpdatePanel ID="UpdatePanel16" runat="server"><ContentTemplate>--%><div
                                            align="center" style="font-weight: bold; font-size: 12px; font-family: Tahoma;">
                                            <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                                <ContentTemplate>
                                                    <div align="center" style="text-align: center">
                                                        <!-- from here -->
                                                        <%--<asp:Panel ID="Panel2" 
                                                                                                     runat="server" CssClass="modalPopup" Style="display: none"></asp:Panel>--%>
                                                        <uc8:Attachment ID="Attachment1" runat="server" />
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <%-- </ContentTemplate>
                                                                                     </asp:UpdatePanel>--%>
                                    </div>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                        </ajaxToolkit:tabcontainer>
				</div>
			</ContentTemplate>
		</asp:UpdatePanel>
	</div>
</asp:Content>

			