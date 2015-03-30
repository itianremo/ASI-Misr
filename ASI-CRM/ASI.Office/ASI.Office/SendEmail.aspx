<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendEmail.aspx.cs" Inherits="SendEmail"
	Theme="Red" MasterPageFile="~/MasterLayout.master" EnableEventValidation="false"
	ValidateRequest="false" %>

<%@ MasterType VirtualPath="~/MasterLayout.master" %>
<%@ Register Src="Controls/AutoCompleteSearch.ascx" TagName="AutoCompleteSearch"
	TagPrefix="uc3" %>
<%@ Register Src="Controls/TransToolBar.ascx" TagName="TransToolBar" TagPrefix="uc1" %>
<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<asp:Content ID="Head" runat="server" ContentPlaceHolderID="head">
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
		.style3
		{
			width: 100px;
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
	</div>
	<div class="ui-layout-content">
		<asp:UpdatePanel ID="up" runat="server">
			<ContentTemplate>
				<asp:Panel ID="upSendEmail" runat="server">
					<table class="style2">
						<tr>
							<td valign="top">
								<table align="center" bordercolor="#FFFFFF" border="1">
									<tbody>
										<tr class="style1">
											<td class="style1" height="22px" width="50px" colspan="2">
												<table class="style3">
													<tr>
														<td>
															<asp:ImageButton ID="btnSend1" runat="server" AlternateText="Send" ImageUrl="~/Images/send-n.jpg"
																OnClick="btnSend1_Click" />
														</td>
														<td>
															<asp:ImageButton ID="btnCancel1" runat="server" AlternateText="Cancel" ImageUrl="~/Images/Cancel1.jpg"
																OnClick="btnCancel1_Click" />
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr class="style1">
											<td class="style1" height="22px" width="50px">
												Template:
											</td>
											<td class="style1" height="22px">
												<asp:DropDownList ID="ddlTemplate" runat="server" CssClass="inputs" Width="327px"
													AutoPostBack="True" OnSelectedIndexChanged="ddlTemplate_SelectedIndexChanged"
													Height="24px">
												</asp:DropDownList>
											</td>
										</tr>
										<tr class="style1" height="22px">
											<td class="style1" width="50px">
												From:
											</td>
											<td class="style1">
												<asp:TextBox ID="txtFrom" runat="server" CssClass="inputs" Width="437px"></asp:TextBox>
											</td>
										</tr>
										<tr class="style1" height="22px">
											<td class="style1" width="50px">
												To:
											</td>
											<td class="style1">
												<asp:TextBox ID="txtTo" runat="server" CssClass="inputs" Width="437px" Height="17px"
													ReadOnly="true"></asp:TextBox>
												<%--<asp:RegularExpressionValidator ID="revTo" runat="server" 
                                                            ControlToValidate="txtTo" Display="Dynamic" ErrorMessage="*" 
                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                            ValidationGroup="vgSend"></asp:RegularExpressionValidator>--%>
											</td>
										</tr>
										<tr class="style1" height="22px">
											<td class="style1" width="50px">
												CC:
											</td>
											<td class="style1">
												<asp:TextBox ID="txtCC" runat="server" CssClass="inputs" Width="437px" Height="17px"></asp:TextBox>
											</td>
										</tr>
										<tr class="style1" height="22px">
											<td class="style1" width="50px">
												Subject:
											</td>
											<td class="style1">
												<asp:TextBox ID="txtSubject" runat="server" CssClass="inputs" Width="437px" Height="17px"></asp:TextBox>
											</td>
										</tr>
										<tr class="style1">
											<td class="style1" colspan="2">
												<ftb:FreeTextBox ID="txtBody" runat="server" BreakMode="LineBreak" ButtonImagesLocation="ExternalFile"
													ButtonWidth="19" EnableHtmlMode="False" Focus="True" Height="280px" JavaScriptLocation="ExternalFile"
													SupportFolder="aspnet_client/FreeTextBox/" ToolbarImagesLocation="ExternalFile"
													ToolbarLayout="FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline|JustifyLeft,JustifyCenter,JustifyRight|BulletedList,NumberedList,Print"
													Width="550px">
												</ftb:FreeTextBox>
											</td>
										</tr>
										<tr class="style1" style="visibility: hidden">
											<td class="style1" height="22px">
												Attachment:
											</td>
											<td class="style1" height="22px" style="padding-left: 12px;">
											</td>
										</tr>
										<tr class="style1">
											<td class="style1" height="22px">
												<asp:ImageButton ID="btnSend2" runat="server" AlternateText="Send" ImageUrl="~/Images/send-n.jpg"
													OnClick="btnSend2_Click" ValidationGroup="vgSend" />
											</td>
											<td class="style1" height="22px">
												<asp:ImageButton ID="btnCancel2" runat="server" AlternateText="Cancel" ImageUrl="~/Images/Cancel1.jpg"
													OnClick="btnCancel2_Click" />
											</td>
										</tr>
									</tbody>
								</table>
							</td>
						</tr>
					</table>
				</asp:Panel>
				<asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="14px"
					ForeColor="#004000"></asp:Label>
			</ContentTemplate>
		</asp:UpdatePanel>
	</div>
	<div class="footer">
	</div>
</asp:Content>
