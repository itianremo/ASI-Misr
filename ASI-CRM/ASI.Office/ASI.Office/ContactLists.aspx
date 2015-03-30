<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContactLists.aspx.cs" Inherits="ContactLists"
	EnableEventValidation="false" ValidateRequest="false" Theme="Red" MasterPageFile="~/MasterLayout.master"
	Title="Contact Details" %>

<%@ MasterType VirtualPath="~/MasterLayout.master" %>
<%@ Register Src="Controls/AutoCompleteSearch.ascx" TagName="AutoCompleteSearch"
	TagPrefix="uc3" %>
<%@ Register Src="Controls/TransToolBar.ascx" TagName="TransToolBar" TagPrefix="uc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="Controls/Key.ascx" TagName="Key" TagPrefix="uc6" %>
<%@ Register Src="Controls/HistoryNC.ascx" TagName="HistoryNC" TagPrefix="uc7" %>
<%@ Register Src="Controls/Attachment.ascx" TagName="Attachment" TagPrefix="uc8" %>
<%@ Register Src="Controls/Calls.ascx" TagName="Calls" TagPrefix="uc9" %>
<asp:Content ID="Head" runat="server" ContentPlaceHolderID="head">
	<script type="text/javascript" src="Scripts/Scripts.js"></script>
	<script type="text/javascript">
		var wndHandle;
		function AttacheFile(ContactID) {
			wndHandle = window.open("AttachFile2.aspx?ContactID=" + ContactID, null, "alwaysraised=yes,left=20,top=250,resizable=no,scrollbars=no,status=yes,width=550,height=250", "")
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
		<uc1:TransToolBar ID="ucTransToolBar" runat="server" />
		<asp:UpdatePanel ID="UpdatePanel10" runat="server">
			<ContentTemplate>
				&nbsp;<asp:ImageButton ID="imgbtnPrevious" runat="server" AlternateText="Previous Contact"
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
																			<asp:DropDownList ID="ddlBusSector" runat="server" Width="230px" CssClass="inputs"
																				AutoPostBack="True" OnSelectedIndexChanged="ddlBusSector_SelectedIndexChanged"
																				Enabled="False">
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
																			<asp:Label ID="lblBranch" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																				Text="Branch"></asp:Label>
																		</td>
																		<td colspan="2" style="height: 21px">
																			<asp:DropDownList ID="dllBranchName" runat="server" Width="205px" CssClass="inputs"
																				DataTextField="BranchName" DataValueField="BranchID" Enabled="False" AppendDataBoundItems="true"
																				OnDataBinding="dllBranchName_DataBinding" DataSourceID="odsBranches" OnDataBound="dllBranchName_DataBound">
																			</asp:DropDownList>
																			<%--<asp:DropDownList ID="dllBranchName" runat="server" Width="205px" Enabled="False"
                                                                                CssClass="inputs" DataTextField="BranchName" DataValueField="BranchID"
                                                                                DataSourceID="odsBranches" OnDataBound="dllBranchName_DataBound">
                                                                            </asp:DropDownList>--%>
																		</td>
																	</tr>
																	<tr>
																		<td align="right" style="height: 21px; width: 50px">
																			<asp:Label ID="Label9" runat="server" CssClass="MainfontStyle" Font-Bold="True" Text="Business Sector"></asp:Label>
																		</td>
																		<td colspan="2" style="height: 21px">
																			<asp:TextBox ID="txtBusSector" runat="server" Width="200px" CssClass="inputs" Text='<%# Bind("BusinessSectorName") %>'
																				ReadOnly="True"></asp:TextBox>
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
								SelectMethod="SelectAccount" TypeName="Office.BLL.ContactListsBLL">
								<SelectParameters>
									<asp:SessionParameter Name="CurrentAccount" SessionField="SingleAccount" Type="Object" />
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
					<br />
				</td>
				<td style="width: 350px" align="left" valign="top">
					<asp:UpdatePanel ID="UpdatePanel4" runat="server">
						<ContentTemplate>
							<table cellpadding="0" cellspacing="0" style="width: 107px">
								<tr>
									<td style="width: 343px;">
										<asp:FormView ID="frmViewContacts" runat="server" AllowPaging="True" OnPageIndexChanging="frmViewContacts_PageIndexChanging"
											DataKeyNames="ContactID">
											<ItemTemplate>
												<table border="1" bordercolor="#660000" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
													style="width: 340px; height: 353px">
													<tr>
														<td colspan="3" rowspan="3" valign="top">
															<table cellpadding="0" cellspacing="0" style="width: 100%">
																<tr>
																	<td background="Images/accountDetails_35.jpg" colspan="3" rowspan="3" style="height: 25px"
																		align="center">
																		<asp:Label ID="lblContact" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																			Font-Size="13px" Text="Contact" ForeColor="White"></asp:Label>
																	</td>
																</tr>
																<tr>
																</tr>
																<tr>
																</tr>
															</table>
															<table>
																<tr>
																	<td colspan="3">
																		<asp:HiddenField ID="txtBrID" runat="server" Value='<%# Bind("BranchID") %>' />
																		<asp:HiddenField ID="txtAccID" runat="server" Value='<%# Bind("AccountID") %>' />
																		<asp:HiddenField ID="txtContID" runat="server" Value='<%# Bind("ContactID") %>' />
																		<%--<asp:TextBox ID="txtBrID" runat="server" CssClass="inputs" Text='<%# Bind("BranchID") %>'
                                                                                        Visible="False" Width="42px"></asp:TextBox>
                                                                                    <asp:TextBox ID="txtAccID" runat="server" CssClass="inputs" Text='<%# Bind("AccountID") %>'
                                                                                        Visible="False" Width="42px"></asp:TextBox>
                                                                                    <asp:TextBox ID="txtContID" runat="server" CssClass="inputs" Text='<%# Bind("ContactID") %>'
                                                                                        Visible="False" Width="42px"></asp:TextBox>--%>
																	</td>
																</tr>
																<tr>
																	<td colspan="3" style="height: 22px">
																		<asp:TextBox ID="txtSalutaion" runat="server" Width="30px" CssClass="inputs" Text='<%# Bind("Intial") %>'
																			ReadOnly="True"></asp:TextBox>
																		<asp:TextBox ID="txtFirstName" runat="server" Width="100px" CssClass="inputs" Text='<%# Bind("FirstName") %>'
																			ReadOnly="True"></asp:TextBox>
																		<asp:Label ID="lblFNSym" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small"
																			ForeColor="Red" Visible="False">*</asp:Label>
																		<asp:TextBox ID="txtMI" runat="server" Width="30px" CssClass="inputs" Text='<%# Bind("MiddleIntial") %>'
																			ReadOnly="True"></asp:TextBox>
																		<asp:TextBox ID="txtLastName" runat="server" Width="100px" CssClass="inputs" Text='<%# Bind("LastName") %>'
																			ReadOnly="True"></asp:TextBox>
																		<asp:Label ID="lblLNSym" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small"
																			ForeColor="Red" Visible="False">*</asp:Label>
																	</td>
																</tr>
																<tr>
																	<td align="right">
																		<asp:Label ID="lblTitle" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																			Text="Title"></asp:Label>
																	</td>
																	<td colspan="2" align="left">
																		<asp:DropDownList ID="ddlTitle" runat="server" Width="215px" CssClass="inputs" DataSourceID="odsTitle"
																			DataTextField="SubCode" DataValueField="SubID" OnSelectedIndexChanged="ddlTitle_SelectedIndexChanged"
																			Enabled="False" AutoPostBack="True">
																		</asp:DropDownList>
																		<asp:TextBox ID="txtTitle" runat="server" CssClass="inputs" Text='<%# Bind("TitleID") %>'
																			Width="5px" Visible="False"></asp:TextBox>
																	</td>
																</tr>
																<tr>
																	<td align="right">
																		<asp:Label ID="lblDepartment" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																			Text="Department"></asp:Label>
																	</td>
																	<td colspan="2" align="left">
																		<asp:DropDownList ID="ddlDepartments" runat="server" Width="215px" CssClass="inputs"
																			DataSourceID="odsDepartment" DataTextField="SubCode" DataValueField="SubID" OnSelectedIndexChanged="ddlDepartments_SelectedIndexChanged"
																			Enabled="False" AutoPostBack="True">
																		</asp:DropDownList>
																		<asp:HiddenField ID="txtDepartment" runat="server" Value='<%# Bind("DepartmentID") %>' />
																		<%--<asp:TextBox ID="txtDepartment" runat="server" CssClass="inputs" Text='<%# Bind("DepartmentID") %>'
                                                                                            Width="5px" Visible="False"></asp:TextBox>--%>
																	</td>
																</tr>
																<tr>
																	<td align="right">
																		<asp:Label ID="lblPhone" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																			Text="Phone"></asp:Label>
																	</td>
																	<td colspan="2" align="left">
																		<asp:TextBox ID="txtPhone" runat="server" Width="135px" CssClass="inputs" Text='<%# Bind("Phone") %>'
																			ReadOnly="True"></asp:TextBox>
																		<asp:Label ID="lblPhoneSym" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small"
																			ForeColor="Red" Visible="False">*</asp:Label>
																		<asp:Label ID="Label25" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																			Text="Ext:"></asp:Label>
																		<asp:TextBox ID="txtExt" runat="server" Width="42px" CssClass="inputs" Text='<%# Bind("Ext") %>'
																			ReadOnly="True"></asp:TextBox>
																	</td>
																</tr>
																<tr>
																	<td align="right">
																		<asp:Label ID="lblCellPhone" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																			Text="Cell Phone"></asp:Label>
																	</td>
																	<td colspan="2" align="left">
																		<asp:TextBox ID="txtCellPhone" runat="server" Width="210px" CssClass="inputs" Text='<%# Bind("CellPhone") %>'
																			ReadOnly="True"></asp:TextBox>
																		<asp:Label ID="lblCellPhoneSym" runat="server" Font-Bold="True" Font-Names="Tahoma"
																			Font-Size="Small" ForeColor="Red" Visible="False">*</asp:Label>
																	</td>
																</tr>
																<tr>
																	<td align="right">
																		<asp:Label ID="lblFax" runat="server" CssClass="MainfontStyle" Font-Bold="True" Text="Fax"></asp:Label>
																	</td>
																	<td colspan="2" align="left">
																		<asp:TextBox ID="txtFax" runat="server" Width="210px" CssClass="inputs" Text='<%# Bind("Fax") %>'
																			ReadOnly="True"></asp:TextBox>
																		<asp:Label ID="lblFaxSym" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small"
																			ForeColor="Red" Visible="False">*</asp:Label>
																	</td>
																</tr>
																<tr>
																	<td align="right" style="height: 0px" valign="top">
																		<asp:Label ID="Label24" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																			Text="E-mail"></asp:Label>
																	</td>
																	<td colspan="2" align="left" style="height: 0px">
																		<asp:HyperLink ID="txtEmail" runat="server" NavigateUrl='<%# "mailto:"+DataBinder.Eval(Container.DataItem, "Email") %>'
																			Text='<%# Bind("Email") %>'></asp:HyperLink>
																		<asp:TextBox ID="txtEmailEdit" runat="server" CssClass="inputs" ReadOnly="True" Width="210px"></asp:TextBox>
																		<asp:Label ID="lblEmailSym" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small"
																			ForeColor="Red" Visible="False">*</asp:Label>
																	</td>
																</tr>
																<tr>
																	<td align="right">
																		<asp:Label ID="lblCountry" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																			Text="Country"></asp:Label>
																	</td>
																	<td align="left" colspan="2">
																		<asp:DropDownList ID="ddlCountry" runat="server" Width="215px" CssClass="inputs"
																			DataSourceID="odsCountries" DataTextField="SubCode" DataValueField="SubID" Enabled="False"
																			AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
																		</asp:DropDownList>
																		<asp:TextBox ID="txtCountryID" runat="server" CssClass="inputs" Text='<%# Bind("CountryID") %>'
																			Visible="False" Width="5px"></asp:TextBox>
																	</td>
																</tr>
																<tr>
																	<td align="right" valign="top" style="height: 0px">
																		<asp:Label ID="lblState" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																			Text="State"></asp:Label>
																	</td>
																	<td align="left" colspan="2" style="height: 0px">
																		<asp:DropDownList ID="ddlState" runat="server" Width="215px" CssClass="inputs" DataSourceID="odsStates"
																			DataTextField="SubCode" DataValueField="SubCode" Enabled="False" Visible="False">
																		</asp:DropDownList>
																		<asp:TextBox ID="txtState" runat="server" CssClass="inputs" Text='<%# Bind("State") %>'
																			Visible="False" Width="210px" ReadOnly="True"></asp:TextBox>
																	</td>
																</tr>
																<tr>
																	<td align="right" style="height: 0px">
																		<asp:Label ID="lblProbabilty" runat="server" CssClass="MainfontStyle" Font-Bold="True"
																			Text="Probability"></asp:Label>
																	</td>
																	<td colspan="2" align="left">
																		<asp:TextBox ID="txtProbabilty" runat="server" Width="200px" CssClass="inputs" Text='<%# Bind("Probability") %>'
																			ReadOnly="True"></asp:TextBox><span class="MainfontStyle">%</span>
																		<asp:Label ID="lblProbabiltySym" runat="server" Font-Bold="True" Font-Names="Tahoma"
																			Font-Size="Small" ForeColor="Red" Visible="False">*</asp:Label>
																	</td>
																</tr>
															</table>
														</td>
													</tr>
													<tr>
													</tr>
													<tr>
													</tr>
												</table>
												<asp:Label ID="lblFNError" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small"
													ForeColor="Red" Visible="False" CssClass="errorItem"></asp:Label>
												<asp:Label ID="lblLNError" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small"
													ForeColor="Red" Visible="False" CssClass="errorItem"></asp:Label>
												<asp:Label ID="lblEmailError" runat="server" Font-Bold="True" Font-Names="Tahoma"
													Font-Size="Small" ForeColor="Red" Visible="False" CssClass="errorItem"></asp:Label>
												<asp:Label ID="lblPhoneError" runat="server" Font-Bold="True" Font-Names="Tahoma"
													Font-Size="Small" ForeColor="Red" Visible="False" CssClass="errorItem"></asp:Label>
												<asp:Label ID="lblCellPhoneError" runat="server" Font-Bold="True" Font-Names="Tahoma"
													Font-Size="Small" ForeColor="Red" Visible="False" CssClass="errorItem"></asp:Label>
												<asp:Label ID="lblFaxError" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small"
													ForeColor="Red" Visible="False" CssClass="errorItem"></asp:Label>
												<asp:Label ID="lblProbabiltyError" runat="server" Font-Bold="True" Font-Names="Tahoma"
													Font-Size="Small" ForeColor="Red" Visible="False" CssClass="errorItem"></asp:Label>
											</ItemTemplate>
											<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPrevious" NextPageImageUrl="~/Images/Right-arrow.gif"
												NextPageText="Next" PreviousPageImageUrl="~/Images/Left-Arrow.gif" PreviousPageText="Previous"
												Visible="False" />
										</asp:FormView>
										<asp:ObjectDataSource ID="odsCountries" runat="server" OldValuesParameterFormatString="original_{0}"
											SelectMethod="GetSubCodeList" TypeName="Office.BLL.ContactListsBLL">
											<SelectParameters>
												<asp:Parameter DefaultValue="Country" Name="CurrentGCode" Type="String" />
											</SelectParameters>
										</asp:ObjectDataSource>
										<asp:ObjectDataSource ID="odsStates" runat="server" OldValuesParameterFormatString="original_{0}"
											SelectMethod="GetSubCodeList" TypeName="Office.BLL.ContactListsBLL">
											<SelectParameters>
												<asp:Parameter DefaultValue="state" Name="CurrentGCode" Type="String" />
											</SelectParameters>
										</asp:ObjectDataSource>
										<asp:ObjectDataSource ID="odsDepartment" runat="server" OldValuesParameterFormatString="original_{0}"
											SelectMethod="GetSubCodeList" TypeName="Office.BLL.ContactListsBLL">
											<SelectParameters>
												<asp:Parameter DefaultValue="Department" Name="CurrentGCode" Type="String" />
											</SelectParameters>
										</asp:ObjectDataSource>
										<asp:ObjectDataSource ID="odsTitle" runat="server" OldValuesParameterFormatString="original_{0}"
											SelectMethod="GetSubCodeList" TypeName="Office.BLL.ContactListsBLL">
											<SelectParameters>
												<asp:Parameter DefaultValue="Title" Name="CurrentGCode" Type="String" />
											</SelectParameters>
										</asp:ObjectDataSource>
										<asp:ObjectDataSource ID="odsContacts" runat="server" OldValuesParameterFormatString="original_{0}"
											SelectMethod="GetAllContacts" TypeName="Office.BLL.ContactListsBLL">
											<SelectParameters>
												<asp:SessionParameter Name="CurrentContact" SessionField="Contact" Type="Object" />
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
						</ContentTemplate>
					</asp:UpdatePanel>
				</td>
				<td colspan="1" valign="top" style="width: 330px" align="right">
					<asp:UpdatePanel ID="UpdatePanel7" runat="server">
						<ContentTemplate>
							<asp:Panel ID="pnlCntMisc" runat="server" Width="320px">
								<table border="1" bordercolor="#660000" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
									style="width: 320px; height: 353px">
									<tr>
										<td colspan="3" valign="top" align="center">
											<table cellpadding="0" cellspacing="0" style="width: 100%">
												<tr>
													<td background="Images/accountDetails_35.jpg" colspan="3" style="height: 25px" align="center">
														<asp:Label ID="lblMiscellaneous" runat="server" CssClass="MainfontStyle" Font-Bold="True"
															Font-Size="13px" Text="Miscellaneous" ForeColor="White"></asp:Label>
													</td>
												</tr>
											</table>
											<table>
												<tr>
													<td colspan="3" style="height: 21px">
														<asp:TextBox ID="txtMID" runat="server" CssClass="inputs" Text='<%# Bind("IDStatus") %>'
															Visible="False" Width="35px"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<td align="right">
														<asp:Label ID="lblStatus" runat="server" CssClass="MainfontStyle" Font-Bold="True"
															Text="ID/Status"></asp:Label>
													</td>
													<td colspan="2" align="left" style="width: 198px">
														<asp:DropDownList ID="ddlIDStatus" runat="server" Width="198px" CssClass="inputs"
															DataSourceID="odsIDStatus" DataTextField="SubCode" DataValueField="SubID" OnDataBound="ddlIDStatus_DataBound"
															OnSelectedIndexChanged="ddlIDStatus_SelectedIndexChanged" Enabled="False" AutoPostBack="True">
														</asp:DropDownList>
														<asp:TextBox ID="txtStatus" runat="server" CssClass="inputs" Text='<%# Bind("IDStatus") %>'
															Visible="False" Width="5px"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<td align="right">
														<asp:Label ID="lblBirthday" runat="server" CssClass="MainfontStyle" Font-Bold="True"
															Text="Birthday"></asp:Label>
													</td>
													<td colspan="2" align="left" style="width: 198px">
														<asp:TextBox ID="txtBirthday" runat="server" Width="165px" CssClass="inputs" Text='<%# Bind("Birthday") %>'
															AutoPostBack="True" ReadOnly="True"></asp:TextBox>
														<asp:ImageButton ID="imCalendar" runat="server" ImageUrl="~/Images/Calender.gif"
															CssClass="HandOverCursor" Width="25px" AlternateText="Pick a date" Enabled="False" />
													</td>
												</tr>
												<tr>
													<td align="right">
														<asp:Label ID="lblSpouse" runat="server" CssClass="MainfontStyle" Font-Bold="True"
															Text="Spouse"></asp:Label>
													</td>
													<td colspan="2" align="left" style="width: 198px">
														<asp:TextBox ID="txtSpouse" runat="server" Width="198px" CssClass="inputs" Text='<%# Bind("Spouse") %>'
															ReadOnly="True"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<td align="right">
														<asp:Label ID="lblReferredBy" runat="server" CssClass="MainfontStyle" Font-Bold="True"
															Text="Referred By"></asp:Label>
													</td>
													<td colspan="2" align="left" style="width: 198px">
														<asp:TextBox ID="txtRefferedBy" runat="server" CssClass="inputs" Text='<%# Bind("ReferredBy") %>'
															Width="198px" ReadOnly="True"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<td align="right" valign="top">
														<asp:Label ID="lblMiscNotes" runat="server" CssClass="MainfontStyle" Font-Bold="True"
															Text="Notes"></asp:Label>
													</td>
													<td align="left" colspan="2" style="width: 198px">
														<asp:TextBox ID="txtMiscNotes" runat="server" CssClass="inputs" Height="80px" Text='<%# Bind("Note") %>'
															Width="198px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
													</td>
												</tr>
											</table>
											<ajaxToolkit:calendarextender id="ceBirthday" runat="server" popupbuttonid="imCalendar" targetcontrolid="txtBirthday"
												popupposition="BottomRight">
															</ajaxToolkit:calendarextender>
										</td>
									</tr>
								</table>
							</asp:Panel>
							<asp:Label ID="lblAddMisc" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small"
								ForeColor="Blue" Visible="False"></asp:Label><asp:ObjectDataSource ID="odsIDStatus"
									runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetSubCodeList"
									TypeName="Office.BLL.ContactListsBLL">
									<SelectParameters>
										<asp:Parameter DefaultValue="Status" Name="CurrentGCode" Type="String" />
									</SelectParameters>
								</asp:ObjectDataSource>
						</ContentTemplate>
					</asp:UpdatePanel>
				</td>
			</tr>
			<tr>
				<td align="left" colspan="2" valign="top">
					<asp:UpdatePanel ID="UpdatePanel8" runat="server">
						<ContentTemplate>
							<asp:Panel ID="pnlResults" runat="server" Height="80px" Width="100%">
								<table border="1" bordercolor="#660000" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
									style="width: 100%; height: 80px">
									<tr>
										<td align="center">
											<table style="width: 130px">
												<tr>
													<td align="right">
														<asp:Label ID="lblLasrResult" runat="server" CssClass="MainfontStyle" Font-Bold="True"
															Text="Last Results" Width="80px"></asp:Label>
													</td>
													<td>
														<asp:DropDownList ID="ddlLastResults" runat="server" Width="175px" CssClass="inputs"
															DataSourceID="odsLastResult" DataTextField="SubCode" DataValueField="SubID" OnDataBound="ddlLastResults_DataBound"
															OnSelectedIndexChanged="ddlLastResults_SelectedIndexChanged" Enabled="False" AutoPostBack="True">
														</asp:DropDownList>
													</td>
													<td align="right">
														<asp:Label ID="Label20" runat="server" CssClass="MainfontStyle" Font-Bold="True"
															Text="Last Edit By" Width="90px"></asp:Label>
													</td>
													<td>
														<asp:TextBox ID="txtLastEditBy" runat="server" Width="95px" CssClass="inputs" ReadOnly="True"></asp:TextBox>
													</td>
													<td align="right" style="width: 83px">
														<asp:Label ID="Label19" runat="server" CssClass="MainfontStyle" Font-Bold="True"
															Text="Date"></asp:Label>
													</td>
													<td>
														<asp:TextBox ID="txtDate" runat="server" Width="95px" CssClass="inputs" ReadOnly="True"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<td align="right">
														<asp:Label ID="Label21" runat="server" CssClass="MainfontStyle" Font-Bold="True"
															Text="Last Reach" Width="80px"></asp:Label>
													</td>
													<td>
														<asp:TextBox ID="txtLastReach" runat="server" CssClass="inputs" Width="170px" ReadOnly="True"></asp:TextBox>
													</td>
													<td align="right">
														<asp:Label ID="Label22" runat="server" CssClass="MainfontStyle" Font-Bold="True"
															Text="Last Attempt" Width="80px"></asp:Label>
													</td>
													<td>
														<asp:TextBox ID="txtLastAttempt" runat="server" CssClass="inputs" Width="95px" ReadOnly="True"></asp:TextBox>
													</td>
													<td align="right" style="width: 83px">
														<asp:Label ID="Label23" runat="server" CssClass="MainfontStyle" Font-Bold="True"
															Text="Last Meeting" Width="80px"></asp:Label>
													</td>
													<td>
														<asp:TextBox ID="txtLastMeet" runat="server" CssClass="inputs" ReadOnly="True" Width="95px"></asp:TextBox>
													</td>
												</tr>
											</table>
											<asp:ObjectDataSource ID="odsLastResult" runat="server" OldValuesParameterFormatString="original_{0}"
												SelectMethod="GetSubCodeList" TypeName="Office.BLL.ContactListsBLL">
												<SelectParameters>
													<asp:Parameter DefaultValue="ConnectionType" Name="CurrentGCode" Type="String" />
												</SelectParameters>
											</asp:ObjectDataSource>
											<asp:Label ID="lblAddResultMsg" runat="server" Font-Bold="True" Font-Names="Tahoma"
												Font-Size="Small" ForeColor="Blue" Visible="False"></asp:Label>
										</td>
									</tr>
								</table>
							</asp:Panel>
							<asp:Button ID="btnAddEditNotes" runat="server" OnClick="btnAddEditNotes_Click" Text="Add or Edit Notes"
								UseSubmitBehavior="False" Height="0px" Width="0px" />
						</ContentTemplate>
					</asp:UpdatePanel>
				</td>
			</tr>
		</table>
	</div>
	<div class="footer">
		<div id="divTabs" runat="server" align="left" style="width: 100%">
			<ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" ScrollBars="Auto"
				Height="350px" Width="100%" CssClass="" OnActiveTabChanged="TabContainer1_ActiveTabChanged">
				<ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="">
					<HeaderTemplate>
						<asp:UpdatePanel ID="UpdatePanel9" runat="server">
							<ContentTemplate>
								<asp:ImageButton ID="imgNotesTab" runat="server" AlternateText="Notes" ImageUrl="~/Images/notes_normal.png"
									OnClick="imgNotesTab_Click" />
							</ContentTemplate>
						</asp:UpdatePanel>
					</HeaderTemplate>
					<ContentTemplate>
						<div align="center" style="background-color: White">
							<div style="font-weight: bold; font-size: 12px; color: white; font-family: Tahoma">
								<div style="width: 100%; background-color: black; vertical-align: bottom;">
									Filter Date:
									<asp:TextBox ID="txtCalender" runat="server" Width="80px" OnTextChanged="txtCalender_TextChanged"
										CssClass="inputs" AutoPostBack="True"></asp:TextBox>
									<img id="imgCalender" runat="server" src="Images/Calender.gif" style="vertical-align: middle"
										class="HandOverCursor" alt="Pick a date" />
									&nbsp;
									<img id="imgAddEditNotes" runat="server" alt="Add or Edit Notes" class="HandOverCursor"
										onclick="AddEdit_Note();" onmouseout="src='Images/addorEditnotes.gif'" onmouseover="src='Images/addorEditnotes_over.png'"
										src="Images/addorEditnotes.gif" style="vertical-align: middle"></img>&nbsp;</img>&nbsp;
								</div>
								<div style="overflow: hidden; width: 96%; height: 5px">
								</div>
								<asp:UpdatePanel ID="UpdatePanel3" runat="server">
									<ContentTemplate>
										<div align="center" style="background-color: #dfdfdf; border-right: black thin solid;
											border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid;">
											<div align="center" style="width: 652px; background-color: black; overflow: hidden;
												height: 20px;">
												<strong style="font-weight: bold; font-size: 12px; color: white; font-family: Tahoma">
													Note Entry and Edit</strong>
											</div>
											<div style="width: 300px;">
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
														<asp:TextBox ID="txtEnteredDate" runat="server" Width="100%" ReadOnly="True" CssClass="inputs"
															Visible="false"></asp:TextBox></div>
													<div style="height: 23px; width: 100px; float: left; font-weight: bold; font-size: 12px;
														color: black; font-family: Tahoma;" align="right">
														<asp:Label ID="lblEnteredTime" runat="server" Text="Time:" Visible="false"></asp:Label>&nbsp;</div>
													<div style="width: 110px; float: left;">
														<asp:TextBox ID="txtEnteredTime" runat="server" Width="100%" ReadOnly="True" CssClass="inputs"
															Visible="false"></asp:TextBox></div>
													<div style="height: 23px; width: 100px; float: left; font-weight: bold; font-size: 12px;
														color: black; font-family: Tahoma;" align="right">
														<asp:Label ID="lblEnteredBy" runat="server" Text="By:" Visible="false"></asp:Label>&nbsp;</div>
													<div style="width: 110px; float: left;">
														<asp:TextBox ID="txtEnteredBy" runat="server" Width="100%" Visible="false" ReadOnly="True"
															CssClass="inputs"></asp:TextBox></div>
												</div>
												<div style="width: 652px">
													<div style="height: 23px; width: 100px; float: left; font-weight: bold; font-size: 12px;
														color: black; font-family: Tahoma;" align="right">
														<asp:Label ID="lblEditDate" runat="server" Text="Edit:" Visible="false"></asp:Label>&nbsp;</div>
													<div style="width: 110px; float: left;">
														<asp:TextBox ID="txtEditDate" runat="server" Width="100%" Visible="false" ReadOnly="True"
															CssClass="inputs"></asp:TextBox></div>
													<div style="height: 23px; width: 100px; float: left; font-weight: bold; font-size: 12px;
														color: black; font-family: Tahoma;" align="right">
														<asp:Label ID="lblEditTime" runat="server" Text="Time:" Visible="false"></asp:Label>&nbsp;</div>
													<div style="width: 110px; float: left;">
														<asp:TextBox ID="txtEditTime" runat="server" Width="100%" Visible="false" ReadOnly="True"
															CssClass="inputs"></asp:TextBox></div>
													<div style="height: 23px; width: 100px; float: left; font-weight: bold; font-size: 12px;
														color: black; font-family: Tahoma;" align="right">
														<asp:Label ID="lblEditBy" runat="server" Text="By:" Visible="false"></asp:Label>&nbsp;</div>
													<div style="width: 110px; float: left;">
														<asp:TextBox ID="txtEditBy" runat="server" Width="100%" Visible="false" ReadOnly="True"
															CssClass="inputs"></asp:TextBox></div>
												</div>
												<div style="width: 652px" align="center">
													<div style="width: 652px">
														&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="lblContact" runat="server" Text="Contact:"
															ForeColor="Black" Visible="false"></asp:Label>
														<asp:TextBox ID="txtContact" runat="server" Width="110px" Visible="false" ReadOnly="True"
															CssClass="inputs"></asp:TextBox></div>
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
														&nbsp;
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
														ErrorMessage="Hours value must be (1~12)" MaximumValue="12" MinimumValue="1" Type="Integer"
														SetFocusOnError="True"></asp:RangeValidator>
													<asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtMin"
														ErrorMessage="Minutes value must be (0~59)" MaximumValue="59" MinimumValue="0"
														Type="Integer" SetFocusOnError="True"></asp:RangeValidator>
												</div>
												<div style="width: 652px" align="center">
													<%--<FTB:FreeTextBox id="txtNote" runat="Server" BackColor="223, 223, 223" ButtonSet="Office2000" GutterBackColor="213, 213, 213" ToolbarBackColor="223, 223, 223" ToolbarBackgroundImage="True" UseToolbarBackGroundImage="True" Height="150px" Width="500px" />--%>
													<FCKeditorV2:FCKeditor ID="txtNote" runat="server" BasePath="fckeditor/" ToolbarSet="MyToolbar"
														Height="150px" Width="500px">
													</FCKeditorV2:FCKeditor>
													<%--<asp:TextBox ID="txtNote" runat="server" Rows="7" TextMode="MultiLine" Width="500px" CssClass="inputs"></asp:TextBox>--%>
												</div>
											</div>
										</div>
										<ajaxToolkit:calendarextender id="CalendarExtender3" runat="server" popupbuttonid="imgNoteDate"
											targetcontrolid="txtUserNoteDate">
																	</ajaxToolkit:calendarextender>
										<ajaxToolkit:numericupdownextender id="NumericUpDownExtender1" runat="server" targetcontrolid="txtHours"
											width="45" refvalues="" servicedownmethod="" serviceupmethod="" targetbuttondownid=""
											targetbuttonupid="" minimum="1" maximum="12" />
										<ajaxToolkit:numericupdownextender id="NumericUpDownExtender2" runat="server" targetcontrolid="txtMin"
											width="45" refvalues="" servicedownmethod="" serviceupmethod="" targetbuttondownid=""
											targetbuttonupid="" minimum="0" maximum="59" />
										<asp:HiddenField ID="hdnNote" runat="server" />
									</ContentTemplate>
								</asp:UpdatePanel>
								&nbsp;&nbsp;
								<ajaxToolkit:popupcontrolextender id="PopupControlExtender1" runat="server" position="Bottom"
									offsetx="-350" offsety="-200" targetcontrolid="imgAddEditNotes" popupcontrolid="UpdatePanel3"
									dynamicservicepath="" enabled="True" extendercontrolid="">
															</ajaxToolkit:popupcontrolextender>
								<ajaxToolkit:calendarextender id="CalendarExtender1" runat="server" popupbuttonid="imgCalender"
									targetcontrolid="txtCalender" popupposition="BottomRight" enabled="True">
															</ajaxToolkit:calendarextender>
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
											<asp:BoundField DataField="NoteDateStr" HeaderText="Date" SortExpression="UserEnterDate"
												NullDisplayText=" ">
												<HeaderStyle Width="7%" />
											</asp:BoundField>
											<asp:BoundField DataField="NoteTimeStr" HeaderText="Time" NullDisplayText=" ">
												<HeaderStyle Width="7%" />
											</asp:BoundField>
											<asp:TemplateField HeaderText="Regarding">
												<ItemTemplate>
													<div style="width: 670px; word-wrap: break-word;">
														<asp:Label ID="Label1" runat="server" Text='<%# Bind("Notes") %>'></asp:Label>
													</div>
												</ItemTemplate>
												<HeaderStyle Width="670px" />
												<ItemStyle Width="670px" Wrap="True" />
											</asp:TemplateField>
											<asp:BoundField DataField="EditByName" HeaderText="Edited By" NullDisplayText=" ">
												<HeaderStyle Width="7%" />
											</asp:BoundField>
											<asp:BoundField DataField="EditDateStr" HeaderText="Edit Date" NullDisplayText=" ">
												<HeaderStyle Width="7%" />
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
								<asp:ImageButton ID="imgbtnHistory" runat="server" AlternateText="History" ImageUrl="~/Images/History-n.png"
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
						<div align="left" style="background-color: White;">
							<%-- <asp:UpdatePanel ID="UpdatePanel16" runat="server"><ContentTemplate>--%><div
								align="center" style="font-weight: bold; font-size: 12px; font-family: Tahoma;">
								<asp:UpdatePanel ID="UpdatePanel17" runat="server">
									<ContentTemplate>
										<div align="left" style="text-align: center">
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
				<ajaxToolkit:TabPanel ID="TabPanel2" runat="server" Width="100%">
					<HeaderTemplate>
						<asp:UpdatePanel ID="UpdatePanel11" runat="server">
							<ContentTemplate>
								<asp:ImageButton ID="imgbtnCalls" runat="server" AlternateText="Calls" ImageUrl="~/Images/CallManagement-n.png"
									OnClick="imgbtnCalls_Click" />
							</ContentTemplate>
						</asp:UpdatePanel>
					</HeaderTemplate>
					<ContentTemplate>
						<div align="center" style="background-color: White;">
							<asp:UpdatePanel ID="UpdatePanel16" runat="server">
								<ContentTemplate>
									<div align="center" style="font-weight: bold; font-size: 12px; font-family: Tahoma;">
										<asp:UpdatePanel ID="UpdatePanel18" runat="server">
											<ContentTemplate>
												<div align="center" style="text-align: center">
													<uc9:Calls ID="CallsCnt" runat="server" />
												</div>
											</ContentTemplate>
										</asp:UpdatePanel>
									</div>
								</ContentTemplate>
							</asp:UpdatePanel>
						</div>
					</ContentTemplate>
				</ajaxToolkit:TabPanel>
			</ajaxToolkit:TabContainer>
		</div>
	</div>
</asp:Content>