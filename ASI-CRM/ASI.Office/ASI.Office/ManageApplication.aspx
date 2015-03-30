<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageApplication.aspx.cs"
	Inherits="ManageApplication" Theme="Red" MasterPageFile="~/MasterLayout.master"
	Title="Manage Application" %>

<%@ MasterType VirtualPath="~/MasterLayout.master" %>
<%@ Register Src="Controls/TransToolBar.ascx" TagName="TransToolBar" TagPrefix="uc2" %>
<asp:Content ID="Head" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Main" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
	<div class="header">
	</div>
	<div class="ui-layout-content">
		<asp:UpdatePanel ID="UpdatePanel9" runat="server">
			<ContentTemplate>
				<table cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td background="Images/accountDetails_35.jpg" width="100%">
							<asp:Panel ID="pnlExpandBusSec" runat="server" Width="100%">
								<asp:LinkButton ID="lbtnBusSec" runat="server" Font-Names="Tahoma" Font-Size="Large"
									ForeColor="White" Width="95%">Manage Business Sector</asp:LinkButton>
								<asp:ImageButton ID="ibtnManageBusSec" runat="server" Height="26px" Width="14px" /></asp:Panel>
						</td>
					</tr>
					<tr>
						<td align="center">
							<asp:Panel ID="pnlBusSec" runat="server" Height="90%" Width="100%" BorderColor="#990033">
								<table cellpadding="0" cellspacing="0" style="width: 100%">
									<tr>
										<td align="left" bgcolor="#000000" colspan="3" width="100%">
											<asp:UpdatePanel ID="UpdatePanel4" runat="server">
												<ContentTemplate>
													<table cellpadding="0" cellspacing="0" style="width: 1px">
														<tr>
															<td style="height: 31px">
																<asp:ImageButton ID="btnAddNewBusSec" runat="server" ImageUrl="~/Images/add1.jpg"
																	OnClick="btnAddNewBusSec_Click" />
															</td>
															<td style="height: 31px">
																<asp:ImageButton ID="btnEditBusSec" runat="server" ImageUrl="~/Images/edit1.jpg"
																	OnClick="btnEditBusSec_Click" />
															</td>
															<td style="height: 31px">
																<asp:ImageButton ID="btnSaveBusSec" runat="server" ImageUrl="~/Images/save1.jpg"
																	OnClick="btnSaveBusSec_Click" Visible="False" />
															</td>
															<td style="height: 31px">
																<asp:ImageButton ID="btnCancelBusSec" runat="server" ImageUrl="~/Images/cancel1.jpg"
																	OnClick="btnCancelBusSec_Click" Visible="False" />
															</td>
														</tr>
													</table>
												</ContentTemplate>
											</asp:UpdatePanel>
										</td>
									</tr>
									<tr>
										<td style="height: 438px">
										</td>
										<td style="width: 1201px; height: 438px;" valign="top">
											<asp:UpdatePanel ID="UpdatePanel1" runat="server">
												<ContentTemplate>
													<table cellpadding="0" cellspacing="0" width="100%">
														<tr>
															<td align="center">
																<asp:ListBox ID="lbBusSec" runat="server" Height="216px" Width="511px" AutoPostBack="True"
																	DataSourceID="odsBusinessSector" DataTextField="SubCode" DataValueField="SubID"
																	OnSelectedIndexChanged="lbBusSec_SelectedIndexChanged" CssClass="inputs"></asp:ListBox>
																<asp:ObjectDataSource ID="odsBusinessSector" runat="server" OldValuesParameterFormatString="original_{0}"
																	SelectMethod="GetSubCodeList" TypeName="Office.BLL.ManageApplicationBLL">
																	<SelectParameters>
																		<asp:Parameter DefaultValue="BusinessSector" Name="CurrentGCode" Type="String" />
																	</SelectParameters>
																</asp:ObjectDataSource>
															</td>
														</tr>
														<tr>
															<td align="center">
																<asp:Label ID="lblBusSecMsg" runat="server" Visible="False" CssClass="MainfontStyle"
																	ForeColor="Red"></asp:Label>
															</td>
														</tr>
														<tr>
															<td style="height: 19px">
																<table cellpadding="0" cellspacing="0" height="1">
																	<tr>
																		<td align="right" valign="middle">
																			<asp:Label ID="lblSelectedBusSec" runat="server" Text="Selected Business Sector"
																				CssClass="MainfontStyle"></asp:Label>
																			<asp:Label ID="lblNewBusSec" runat="server" Text="New Business Sector" Visible="False"
																				CssClass="MainfontStyle"></asp:Label>&nbsp;
																		</td>
																		<td align="left" valign="top">
																			<asp:TextBox ID="txtSelectedbuSec" runat="server" ReadOnly="True" Width="303px" CssClass="inputs"></asp:TextBox>
																			<asp:TextBox ID="txtlblNewBusSec" runat="server" Visible="False" Width="303px" CssClass="inputs"></asp:TextBox>&nbsp;
																		</td>
																	</tr>
																	<tr>
																		<td align="center" colspan="2" style="height: 1px">
																			<asp:TextBox ID="txtBusSecID" runat="server" Visible="False" Width="13px"></asp:TextBox>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
													</table>
												</ContentTemplate>
											</asp:UpdatePanel>
										</td>
									</tr>
								</table>
							</asp:Panel>
							<ajaxToolkit:collapsiblepanelextender id="cpeBusSec" runat="server" targetcontrolid="pnlBusSec"
								collapsedsize="0" expandedsize="300" collapsed="True" expandcontrolid="pnlExpandBusSec"
								collapsecontrolid="pnlExpandBusSec" autocollapse="False" autoexpand="False" scrollcontents="False"
								textlabelid="Label1" collapsedtext="Show Details..." expandedtext="Hide Details"
								imagecontrolid="ibtnManageBusSec" expandedimage="~/Images/Expand1.jpg" collapsedimage="~/Images/Collapse1.jpg"
								expanddirection="Vertical" />
						</td>
					</tr>
				</table>
			</ContentTemplate>
		</asp:UpdatePanel>
		<asp:UpdatePanel ID="UpdatePanel10" runat="server">
			<ContentTemplate>
				<table cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td align="left" background="Images/accountDetails_35.jpg" style="height: 20px">
							<asp:Panel ID="pnlExpandStatus" runat="server" Width="100%">
								<asp:LinkButton ID="lbtnStatus" runat="server" Font-Names="Tahoma" Font-Size="Large"
									ForeColor="White" Width="95%">Manage Status</asp:LinkButton>
								<asp:ImageButton ID="ibtnManageStatus" runat="server" Height="26px" Width="14px" /></asp:Panel>
						</td>
					</tr>
					<tr>
						<td align="center" valign="top">
							<asp:Panel ID="pnlStatus" runat="server" Height="90%" Width="100%" BorderColor="#990033">
								<table cellpadding="0" cellspacing="0" style="width: 100%">
									<tr>
										<td align="left" bgcolor="#000000" colspan="3" width="100%">
											<asp:UpdatePanel ID="UpdatePanel6" runat="server">
												<ContentTemplate>
													<table cellpadding="0" cellspacing="0" style="width: 9px">
														<tr>
															<td>
																<asp:ImageButton ID="btnAddNewStatus" runat="server" ImageUrl="~/Images/add1.jpg"
																	OnClick="btnAddNewStatus_Click" />
															</td>
															<td>
																<asp:ImageButton ID="btnEditStatus" runat="server" Height="27px" ImageUrl="~/Images/edit1.jpg"
																	OnClick="btnEditStatus_Click" />
															</td>
															<td>
																<asp:ImageButton ID="btnSaveStatus" runat="server" ImageUrl="~/Images/save1.jpg"
																	OnClick="btnSaveStatus_Click" Visible="False" />
															</td>
															<td>
																<asp:ImageButton ID="btnCancelStatus" runat="server" ImageUrl="~/Images/cancel1.jpg"
																	OnClick="btnCancelStatus_Click" Visible="False" />
															</td>
														</tr>
													</table>
												</ContentTemplate>
											</asp:UpdatePanel>
										</td>
									</tr>
									<tr>
										<td>
											<asp:UpdatePanel ID="UpdatePanel2" runat="server">
												<ContentTemplate>
													<table cellpadding="0" cellspacing="0" width="100%">
														<tr>
															<td>
																<asp:ListBox ID="lbStatus" runat="server" AutoPostBack="True" DataSourceID="odsStatus"
																	DataTextField="SubCode" DataValueField="SubID" Height="216px" OnSelectedIndexChanged="lbStatus_SelectedIndexChanged"
																	Width="511px" CssClass="inputs"></asp:ListBox>
																<asp:ObjectDataSource ID="odsStatus" runat="server" OldValuesParameterFormatString="original_{0}"
																	SelectMethod="GetSubCodeList" TypeName="Office.BLL.ManageApplicationBLL">
																	<SelectParameters>
																		<asp:Parameter DefaultValue="Status" Name="CurrentGCode" Type="String" />
																	</SelectParameters>
																</asp:ObjectDataSource>
															</td>
														</tr>
														<tr>
															<td>
																<asp:Label ID="lblStatusMsg" runat="server" Visible="False" CssClass="MainfontStyle"
																	ForeColor="Red"></asp:Label>
															</td>
														</tr>
														<tr>
															<td>
																<table cellpadding="0" cellspacing="0" style="width: 510px">
																	<tr>
																		<td align="right" valign="middle">
																			<asp:Label ID="lblSelectedStatus" runat="server" Text="Selected ID/Status" CssClass="MainfontStyle"></asp:Label>&nbsp;
																			<asp:Label ID="lblNewStatus" runat="server" Text="New ID/Status" Visible="False"
																				CssClass="MainfontStyle"></asp:Label>&nbsp;
																		</td>
																		<td align="left" valign="top">
																			<asp:TextBox ID="txtSelectedStatus" runat="server" Width="371px" ReadOnly="True"
																				CssClass="inputs"></asp:TextBox>
																			<asp:TextBox ID="txtNewStatus" runat="server" Visible="False" Width="371px" CssClass="inputs"></asp:TextBox>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
														<tr>
															<td>
																<asp:TextBox ID="txtStatusID" runat="server" Width="15px" Visible="False"></asp:TextBox>
															</td>
														</tr>
													</table>
												</ContentTemplate>
											</asp:UpdatePanel>
										</td>
									</tr>
								</table>
							</asp:Panel>
							<ajaxToolkit:collapsiblepanelextender id="cpeStatus" runat="server" targetcontrolid="pnlStatus"
								collapsedsize="0" expandedsize="300" collapsed="True" expandcontrolid="pnlExpandStatus"
								collapsecontrolid="pnlExpandStatus" autocollapse="False" autoexpand="False" scrollcontents="False"
								textlabelid="Label1" collapsedtext="Show Details..." expandedtext="Hide Details"
								imagecontrolid="ibtnManageStatus" expandedimage="~/Images/Expand1.jpg" collapsedimage="~/Images/Collapse1.jpg"
								expanddirection="Vertical" />
						</td>
					</tr>
				</table>
			</ContentTemplate>
		</asp:UpdatePanel>
		<asp:UpdatePanel ID="UpdatePanel11" runat="server">
			<ContentTemplate>
				<table cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td align="left" background="Images/accountDetails_35.jpg" width="100%">
							<asp:Panel ID="pnlExpandDept" runat="server" Width="100%">
								<asp:LinkButton ID="lbtnDept" runat="server" ForeColor="White" Font-Names="Tahoma"
									Font-Size="Large" Width="95%">Manage Departments</asp:LinkButton>
								<asp:ImageButton ID="ibtnManageDept" runat="server" Height="26px" Width="14px" /></asp:Panel>
						</td>
					</tr>
					<tr>
						<td align="center">
							<asp:Panel ID="pnlDept" runat="server" Height="90%" Width="100%" BorderColor="#990033">
								<table cellpadding="0" cellspacing="0" style="width: 100%">
									<tr>
										<td align="left" bgcolor="#000000" colspan="3" width="100%">
											<asp:UpdatePanel ID="UpdatePanel5" runat="server">
												<ContentTemplate>
													<table cellpadding="0" cellspacing="0" style="width: 1px">
														<tr>
															<td style="height: 27px">
																<asp:ImageButton ID="btnAddNewDept" runat="server" ImageUrl="~/Images/add1.jpg" OnClick="btnAddNewDept_Click" />
															</td>
															<td style="height: 27px">
																<asp:ImageButton ID="btnEditDept" runat="server" ImageUrl="~/Images/edit1.jpg" OnClick="btnEditDept_Click" />
															</td>
															<td style="height: 27px">
																<asp:ImageButton ID="btnSaveDept" runat="server" ImageUrl="~/Images/save1.jpg" OnClick="btnSaveDept_Click"
																	Visible="False" />
															</td>
															<td style="width: 117px; height: 27px">
																<asp:ImageButton ID="btnCancelDept" runat="server" ImageUrl="~/Images/cancel1.jpg"
																	OnClick="btnCancelDept_Click" Visible="False" />
															</td>
														</tr>
													</table>
												</ContentTemplate>
											</asp:UpdatePanel>
										</td>
									</tr>
									<tr>
										<td>
											<br />
											<asp:UpdatePanel ID="UpdatePanel3" runat="server">
												<ContentTemplate>
													<table cellpadding="0" cellspacing="0" width="100%">
														<tr>
															<td>
																<asp:ListBox ID="lbDept" runat="server" AutoPostBack="True" DataSourceID="odsDepartments"
																	DataTextField="SubCode" DataValueField="SubID" Height="216px" OnSelectedIndexChanged="lbDept_SelectedIndexChanged"
																	Width="520px" CssClass="inputs"></asp:ListBox>
																<asp:ObjectDataSource ID="odsDepartments" runat="server" OldValuesParameterFormatString="original_{0}"
																	SelectMethod="GetSubCodeList" TypeName="Office.BLL.ManageApplicationBLL">
																	<SelectParameters>
																		<asp:Parameter DefaultValue="Department" Name="CurrentGCode" Type="String" />
																	</SelectParameters>
																</asp:ObjectDataSource>
															</td>
														</tr>
														<tr>
															<td>
																<asp:Label ID="lblDeptMsg" runat="server" Visible="False" CssClass="MainfontStyle"
																	ForeColor="Red"></asp:Label>
															</td>
														</tr>
														<tr>
															<td>
																<table cellpadding="0" cellspacing="0" style="width: 511px">
																	<tr>
																		<td align="right" style="width: 147px" valign="middle">
																			<asp:Label ID="lblSelectedDept" runat="server" Height="19px" Text="Selected Department"
																				CssClass="MainfontStyle"></asp:Label>&nbsp;
																			<asp:Label ID="lblNewDept" runat="server" Text="New Department" Visible="False" CssClass="MainfontStyle"></asp:Label>&nbsp;
																		</td>
																		<td align="left" valign="middle">
																			<asp:TextBox ID="txtSelectedDept" runat="server" Width="358px" ReadOnly="True" CssClass="inputs"></asp:TextBox>
																			<asp:TextBox ID="txtNewDept" runat="server" Visible="False" Width="358px" CssClass="inputs"></asp:TextBox>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
														<tr>
															<td>
																<asp:TextBox ID="txtDeptID" runat="server" Visible="False" Width="25px"></asp:TextBox>
															</td>
														</tr>
													</table>
												</ContentTemplate>
											</asp:UpdatePanel>
										</td>
									</tr>
								</table>
							</asp:Panel>
							<ajaxToolkit:collapsiblepanelextender id="cpeDept" runat="server" targetcontrolid="pnlDept"
								collapsedsize="0" expandedsize="300" collapsed="True" expandcontrolid="pnlExpandDept"
								collapsecontrolid="pnlExpandDept" autocollapse="False" autoexpand="False" scrollcontents="False"
								textlabelid="Label1" collapsedtext="Show Details..." expandedtext="Hide Details"
								imagecontrolid="ibtnManageDept" expandedimage="~/Images/Expand1.jpg" collapsedimage="~/Images/Collapse1.jpg"
								expanddirection="Vertical" />
						</td>
					</tr>
				</table>
			</ContentTemplate>
		</asp:UpdatePanel>
		<asp:UpdatePanel ID="UpdatePanel12" runat="server">
			<ContentTemplate>
				<table cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td align="left" background="Images/accountDetails_35.jpg" width="100%" valign="top">
							<asp:Panel ID="pnlExpandTitle" runat="server" Width="100%">
								<asp:LinkButton ID="lbtnTitle" runat="server" Font-Names="Tahoma" Font-Size="Large"
									ForeColor="White" Width="95%">Manage Title</asp:LinkButton>
								<asp:ImageButton ID="ibtnManageTitle" runat="server" Height="26px" Width="14px" /></asp:Panel>
						</td>
					</tr>
					<tr>
						<td align="center">
							<asp:Panel ID="pnlTitle" runat="server" Height="90%" Width="100%" BorderColor="#990033">
								<table cellpadding="0" cellspacing="0" style="width: 100%">
									<tr>
										<td align="left" bgcolor="#000000" colspan="3" width="100%">
											<asp:UpdatePanel ID="UpdatePanel8" runat="server">
												<ContentTemplate>
													<table cellpadding="0" cellspacing="0" style="width: 41px">
														<tr>
															<td>
																<asp:ImageButton ID="btnAddNewTitle" runat="server" ImageUrl="~/Images/Add1.jpg"
																	OnClick="btnAddNewTitle_Click" />
															</td>
															<td>
																<asp:ImageButton ID="btnEditTitle" runat="server" ImageUrl="~/Images/edit1.jpg" OnClick="btnEditTitle_Click" />
															</td>
															<td>
																<asp:ImageButton ID="btnSaveTitle" runat="server" ImageUrl="~/Images/save1.jpg" OnClick="btnSaveTitle_Click"
																	Visible="False" />
															</td>
															<td>
																<asp:ImageButton ID="btnCancelTitle" runat="server" ImageUrl="~/Images/cancel1.jpg"
																	OnClick="btnCancelTitle_Click" Visible="False" />
															</td>
														</tr>
													</table>
												</ContentTemplate>
											</asp:UpdatePanel>
										</td>
									</tr>
									<tr>
										<td>
											<br />
											<asp:UpdatePanel ID="UpdatePanel7" runat="server">
												<ContentTemplate>
													<table cellpadding="0" cellspacing="0" width="100%">
														<tr>
															<td>
																<asp:ListBox ID="lbTitle" runat="server" DataSourceID="odsTitle" DataTextField="SubCode"
																	DataValueField="SubID" Height="216px" Width="511px" AutoPostBack="True" OnSelectedIndexChanged="lbTitle_SelectedIndexChanged"
																	CssClass="inputs"></asp:ListBox>
																<asp:ObjectDataSource ID="odsTitle" runat="server" OldValuesParameterFormatString="original_{0}"
																	SelectMethod="GetSubCodeList" TypeName="Office.BLL.ManageApplicationBLL">
																	<SelectParameters>
																		<asp:Parameter DefaultValue="Title" Name="CurrentGCode" Type="String" />
																	</SelectParameters>
																</asp:ObjectDataSource>
															</td>
														</tr>
														<tr>
															<td>
																<asp:Label ID="lblTitleMsg" runat="server" Visible="False" CssClass="MainfontStyle"
																	ForeColor="Red"></asp:Label>
															</td>
														</tr>
														<tr>
															<td>
																<table style="width: 511px" cellpadding="0" cellspacing="0">
																	<tr>
																		<td align="right" valign="middle">
																			<asp:Label ID="lblSelectedTitle" runat="server" Text="Selected Title" CssClass="MainfontStyle"></asp:Label>&nbsp;
																			<asp:Label ID="lblNewTitle" runat="server" Text="New Title" Visible="False" CssClass="MainfontStyle"></asp:Label>&nbsp;
																		</td>
																		<td align="left" style="width: 413px" valign="middle">
																			<asp:TextBox ID="txtSelectedTitle" runat="server" ReadOnly="True" Width="402px" CssClass="inputs"></asp:TextBox>
																			<asp:TextBox ID="txtNewTitle" runat="server" Visible="False" Width="402px" CssClass="inputs"></asp:TextBox>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
														<tr>
															<td>
																<asp:TextBox ID="txtTitleID" runat="server" Visible="False" Width="21px"></asp:TextBox>
															</td>
														</tr>
													</table>
												</ContentTemplate>
											</asp:UpdatePanel>
										</td>
									</tr>
								</table>
							</asp:Panel>
							<ajaxToolkit:collapsiblepanelextender id="cpeTitles" runat="server" targetcontrolid="pnlTitle"
								collapsedsize="0" expandedsize="300" collapsed="True" expandcontrolid="pnlExpandTitle"
								collapsecontrolid="pnlExpandTitle" autocollapse="False" autoexpand="False" scrollcontents="False"
								textlabelid="Label1" collapsedtext="Show Details..." expandedtext="Hide Details"
								imagecontrolid="ibtnManageTitle" expandedimage="~/Images/Expand1.jpg" collapsedimage="~/Images/Collapse1.jpg"
								expanddirection="Vertical" />
						</td>
					</tr>
				</table>
			</ContentTemplate>
		</asp:UpdatePanel>
		<asp:UpdatePanel ID="UpdatePanel13" runat="server">
			<ContentTemplate>
				<table cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td align="left" background="Images/accountDetails_35.jpg" width="100%" valign="top">
							<asp:Panel ID="pnlExpandWebsitesService" runat="server" Width="100%">
								<asp:LinkButton ID="lbtnWebsitesService" runat="server" Font-Names="Tahoma" Font-Size="Large"
									ForeColor="White" Width="95%">Manage WebsitesService</asp:LinkButton>
								<asp:ImageButton ID="ibtnManageWebsitesService" runat="server" Height="26px" Width="14px" /></asp:Panel>
						</td>
					</tr>
					<tr>
						<td align="center">
							<asp:Panel ID="pnlWebsitesService" runat="server" Height="90%" Width="100%" BorderColor="#990033">
								<table cellpadding="0" cellspacing="0" style="width: 100%">
									<tr>
										<td align="left" bgcolor="#000000" colspan="3" width="100%">
											<asp:UpdatePanel ID="UpdatePanel14" runat="server">
												<ContentTemplate>
													<table cellpadding="0" cellspacing="0" style="width: 41px">
														<tr>
															<td>
																<asp:ImageButton ID="btnAddNewWebsitesService" runat="server" ImageUrl="~/Images/Add1.jpg"
																	OnClick="btnAddNewWebsitesService_Click" />
															</td>
															<td>
																<asp:ImageButton ID="btnEditWebsitesService" runat="server" ImageUrl="~/Images/edit1.jpg"
																	OnClick="btnEditWebsitesService_Click" />
															</td>
															<td>
																<asp:ImageButton ID="btnSaveWebsitesService" runat="server" ImageUrl="~/Images/save1.jpg"
																	OnClick="btnSaveWebsitesService_Click" Visible="False" ValidationGroup="vgSaveWebsitesService" />
															</td>
															<td>
																<asp:ImageButton ID="btnCancelWebsitesService" runat="server" ImageUrl="~/Images/cancel1.jpg"
																	OnClick="btnCancelWebsitesService_Click" Visible="False" />
															</td>
														</tr>
													</table>
												</ContentTemplate>
											</asp:UpdatePanel>
										</td>
									</tr>
									<tr>
										<td>
											<br />
											<asp:UpdatePanel ID="UpdatePanel15" runat="server">
												<ContentTemplate>
													<table cellpadding="0" cellspacing="0" width="100%">
														<tr>
															<td>
																<asp:ListBox ID="lbWebsitesService" runat="server" DataSourceID="odsWebsitesService"
																	DataTextField="WSName" DataValueField="WSID" Height="216px" Width="511px" AutoPostBack="True"
																	OnSelectedIndexChanged="lbWebsitesService_SelectedIndexChanged" CssClass="inputs">
																</asp:ListBox>
																<asp:ObjectDataSource ID="odsWebsitesService" runat="server" OldValuesParameterFormatString="{0}"
																	SelectMethod="GetWebsitesServicesList" TypeName="Office.BLL.ManageApplicationBLL">
																</asp:ObjectDataSource>
															</td>
														</tr>
														<tr>
															<td>
																<asp:Label ID="lblWebsitesServiceMsg" runat="server" Visible="False" CssClass="MainfontStyle"
																	ForeColor="Red"></asp:Label>
															</td>
														</tr>
														<tr>
															<td>
																<table style="width: 531px" cellpadding="0" cellspacing="0">
																	<tr>
																		<td align="right" rowspan="1" valign="middle">
																			<asp:Label ID="lblSelectedWebsitesService" runat="server" Text="Website" CssClass="MainfontStyle"></asp:Label>&nbsp;
																		</td>
																		<td align="left" rowspan="1" style="width: 413px" valign="middle">
																			<asp:TextBox ID="txtSelectedWebsitesService" runat="server" ReadOnly="True" Width="402px"
																				CssClass="inputs"></asp:TextBox>
																			<asp:RequiredFieldValidator ID="RequiredFieldValidatorSelectedWebsitesService" runat="server"
																				ErrorMessage="*" ControlToValidate="txtSelectedWebsitesService" Display="Dynamic"
																				ValidationGroup="vgSaveWebsitesService"></asp:RequiredFieldValidator>
																			<asp:TextBox ID="txtNewWebsitesService" runat="server" Visible="False" Width="402px"
																				CssClass="inputs"></asp:TextBox>
																			<asp:RequiredFieldValidator ID="RequiredFieldValidatortxtNewWebsitesService" runat="server"
																				ErrorMessage="*" ControlToValidate="txtNewWebsitesService" Display="Dynamic" ValidationGroup="vgSaveNewWebsitesService"></asp:RequiredFieldValidator>
																		</td>
																	</tr>
																	<tr>
																		<td align="right" rowspan="1" valign="middle">
																			<asp:Label ID="lblSelectedURL" runat="server" Text="URL" CssClass="MainfontStyle"></asp:Label>&nbsp;
																		</td>
																		<td align="left" rowspan="1" style="width: 413px" valign="middle">
																			<asp:TextBox ID="txtSelectedURL" runat="server" ReadOnly="True" Width="402px" CssClass="inputs"></asp:TextBox>
																			<asp:RequiredFieldValidator ID="RequiredFieldValidatortxtSelectedURL" runat="server"
																				ErrorMessage="*" ControlToValidate="txtSelectedURL" Display="Dynamic" ValidationGroup="vgSaveWebsitesService"></asp:RequiredFieldValidator>
																			<asp:RegularExpressionValidator ID="RegularExpressionValidatorSelectedURL" runat="server"
																				ErrorMessage="write like: http://www.domain/" Display="Dynamic" ValidationGroup="vgSaveWebsitesService"
																				ControlToValidate="txtSelectedURL" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
																			<asp:TextBox ID="txtNewURL" runat="server" Visible="False" Width="402px" CssClass="inputs"></asp:TextBox>
																			<asp:RequiredFieldValidator ID="RequiredFieldValidatortxtNewURL" runat="server" ErrorMessage="*"
																				ControlToValidate="txtNewURL" Display="Dynamic" ValidationGroup="vgSaveNewWebsitesService"></asp:RequiredFieldValidator>
																			<asp:RegularExpressionValidator ID="RegularExpressionValidatorNewURL" runat="server"
																				ErrorMessage="Invalid URL: write like http://www.domain/" Display="Dynamic" ValidationGroup="vgSaveNewWebsitesService"
																				ControlToValidate="txtNewURL" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
																		</td>
																	</tr>
																	<tr>
																		<td align="right" rowspan="1" valign="middle">
																			<asp:Label ID="lblSelectedUsername" runat="server" Text="Username" CssClass="MainfontStyle"></asp:Label>&nbsp;
																		</td>
																		<td align="left" rowspan="1" style="width: 413px" valign="middle">
																			<asp:TextBox ID="txtSelectedUsername" runat="server" ReadOnly="True" Width="402px"
																				CssClass="inputs"></asp:TextBox>
																			<asp:RequiredFieldValidator ID="RequiredFieldValidatortxtSelectedUsername" runat="server"
																				ErrorMessage="*" ControlToValidate="txtSelectedUsername" Display="Dynamic" ValidationGroup="vgSaveWebsitesService"></asp:RequiredFieldValidator>
																			<asp:TextBox ID="txtNewUsername" runat="server" Visible="False" Width="402px" CssClass="inputs"></asp:TextBox>
																			<asp:RequiredFieldValidator ID="RequiredFieldValidatortxtNewUsername" runat="server"
																				ErrorMessage="*" ControlToValidate="txtNewUsername" Display="Dynamic" ValidationGroup="vgSaveNewWebsitesService"></asp:RequiredFieldValidator>
																		</td>
																	</tr>
																	<tr>
																		<td align="right" rowspan="1" valign="top">
																			<asp:Label ID="lblSelectedPassword" runat="server" Text="Password" CssClass="MainfontStyle"></asp:Label>&nbsp;
																		</td>
																		<td align="left" rowspan="1" style="width: 413px" valign="top" colspan="2">
																			<asp:TextBox ID="txtSelectedPassword" runat="server" ReadOnly="True" Width="402px"
																				CssClass="inputs" TextMode="Password"></asp:TextBox>
																			<asp:RequiredFieldValidator ID="RequiredFieldValidatortxtSelectedPassword" runat="server"
																				ErrorMessage="*" ControlToValidate="txtSelectedPassword" Display="Dynamic" ValidationGroup="vgSaveWebsitesService"></asp:RequiredFieldValidator>
																			<asp:TextBox ID="txtNewPassword" runat="server" Visible="False" Width="402px" CssClass="inputs"
																				TextMode="Password"></asp:TextBox>
																			<asp:RequiredFieldValidator ID="RequiredFieldValidatortxtNewPassword" runat="server"
																				ErrorMessage="*" ControlToValidate="txtNewPassword" Display="Dynamic" ValidationGroup="vgSaveNewWebsitesService"></asp:RequiredFieldValidator>
																		</td>
																	</tr>
																	<tr>
																		<td align="right" rowspan="1" valign="top" width="150px">
																			<asp:Label ID="lblSelectedPassword2" runat="server" Text="Confirm Password" CssClass="MainfontStyle"></asp:Label>&nbsp;
																		</td>
																		<td align="left" rowspan="1" style="width: 413px" valign="top" colspan="2">
																			<asp:TextBox ID="txtSelectedPassword2" runat="server" ReadOnly="True" Width="402px"
																				CssClass="inputs" TextMode="Password"></asp:TextBox>
																			<asp:RequiredFieldValidator ID="RequiredFieldValidatortxtSelectedPassword2" runat="server"
																				ErrorMessage="*" ControlToValidate="txtSelectedPassword2" Display="Dynamic" ValidationGroup="vgSaveWebsitesService"></asp:RequiredFieldValidator>
																			<asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="password and confirm password not match"
																				ControlToCompare="txtSelectedPassword" ControlToValidate="txtSelectedPassword2"
																				Display="Dynamic" ValidationGroup="vgSaveWebsitesService"></asp:CompareValidator>
																			<asp:TextBox ID="txtNewPassword2" runat="server" Visible="False" Width="402px" CssClass="inputs"
																				TextMode="Password"></asp:TextBox>
																			<asp:RequiredFieldValidator ID="RequiredFieldValidatortxtNewPassword2" runat="server"
																				ErrorMessage="*" ControlToValidate="txtNewPassword2" Display="Dynamic" ValidationGroup="vgSaveNewWebsitesService"></asp:RequiredFieldValidator>
																			<asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="password and confirm password not match"
																				ControlToCompare="txtNewPassword" ControlToValidate="txtNewPassword2" Display="Dynamic"
																				ValidationGroup="vgSaveNewWebsitesService"></asp:CompareValidator>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
														<tr>
															<td>
																<asp:TextBox ID="txtWebsitesServiceID" runat="server" Visible="False" Width="21px"></asp:TextBox>
															</td>
														</tr>
													</table>
												</ContentTemplate>
											</asp:UpdatePanel>
										</td>
									</tr>
								</table>
							</asp:Panel>
							<ajaxToolkit:collapsiblepanelextender id="cpeWebsitesServices" runat="server" targetcontrolid="pnlWebsitesService"
								collapsedsize="0" expandedsize="500" collapsed="True" expandcontrolid="pnlExpandWebsitesService"
								collapsecontrolid="pnlExpandWebsitesService" autocollapse="False" autoexpand="False"
								scrollcontents="False" textlabelid="Label1" collapsedtext="Show Details..." expandedtext="Hide Details"
								imagecontrolid="ibtnManageWebsitesService" expandedimage="~/Images/Expand1.jpg"
								collapsedimage="~/Images/Collapse1.jpg" expanddirection="Vertical" />
						</td>
					</tr>
				</table>
			</ContentTemplate>
		</asp:UpdatePanel>
	</div>
	<div class="footer">
	</div>
</asp:Content>
