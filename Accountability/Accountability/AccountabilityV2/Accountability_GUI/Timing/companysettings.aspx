<%@ Page language="c#" Inherits="TSN.ERP.WebGUI.Go.CompanySettings" CodeFile="CompanySettings.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TSN Timing Settings</title>
		<LINK href="http://localhost/AccGui/Acc1.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="#95a9bf">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="1063" align="center" border="0">
				<TR>
					<TD align="center">
						<table style="WIDTH: 520px; HEIGHT: 380px" cellSpacing="5" cellPadding="5" width="520"
							border="0">
							<tr>
								<td class="headertd">Company Timing Settings</td>
							</tr>
							<tr>
								<td class="whitetd">
									<table id="Table4" style="WIDTH: 513px; HEIGHT: 311px" cellSpacing="5" cellPadding="5"
										width="513" border="0">
										<TBODY>
											<tr>
												<td class="formslabels" style="WIDTH: 30%; HEIGHT: 25px"><asp:label id="Label1" runat="server">Mail Server</asp:label></td>
												<td style="WIDTH: 35%; HEIGHT: 25px"><asp:textbox id="txtMailServer" tabIndex="1" runat="server" CssClass="inputtext" Width="152px"></asp:textbox></td>
												<td style="WIDTH: 35%; HEIGHT: 25px"><asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" Font-Size="X-Small" ControlToValidate="txtMailServer"
														ErrorMessage="RequiredFieldValidator">Required</asp:requiredfieldvalidator></td>
											</tr>
											<tr>
												<td class="formslabels" style="WIDTH: 30%; HEIGHT: 1px"><asp:label id="Label2" runat="server">Month Start</asp:label></td>
												<td style="WIDTH: 35%; HEIGHT: 1px"><asp:textbox id="txtMonthStart" tabIndex="2" runat="server" CssClass="inputtext" Width="56px"></asp:textbox></td>
												<TD style="WIDTH: 35%; HEIGHT: 1px">
													<P><asp:rangevalidator id="RangeValidator1" runat="server" Font-Size="X-Small" ControlToValidate="txtMonthStart"
															ErrorMessage="RangeValidator" Type="Integer" MaximumValue="31" MinimumValue="1"> Must be 1-31 </asp:rangevalidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" Font-Size="X-Small" ControlToValidate="txtMonthStart"
															ErrorMessage="RequiredFieldValidator">Required</asp:requiredfieldvalidator></P>
												</TD>
											</tr>
											<tr>
												<td class="formslabels" style="WIDTH: 30%; HEIGHT: 29px"><asp:label id="Label3" runat="server">Month End</asp:label></td>
												<td style="WIDTH: 35%; HEIGHT: 29px"><asp:textbox id="txtMonthEnd" tabIndex="3" runat="server" CssClass="inputtext" Width="56px"></asp:textbox></td>
												<TD style="WIDTH: 35%; HEIGHT: 29px">
													<P><asp:rangevalidator id="RangeValidator2" runat="server" Font-Size="X-Small" ControlToValidate="txtMonthEnd"
															ErrorMessage="RangeValidator" Type="Integer" MaximumValue="31" MinimumValue="1"> Must be 1-31 </asp:rangevalidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" Font-Size="X-Small" ControlToValidate="txtMonthEnd"
															ErrorMessage="RequiredFieldValidator">Required</asp:requiredfieldvalidator></P>
												</TD>
											</tr>
											<tr>
												<td class="formslabels" style="WIDTH: 30%; HEIGHT: 10px"><asp:label id="Label4" runat="server">Max. Hours/Day</asp:label></td>
												<td style="WIDTH: 35%; HEIGHT: 10px"><asp:textbox id="txtMaxHoursPerDay" tabIndex="4" runat="server" CssClass="inputtext" Width="56px"></asp:textbox></td>
												<TD style="WIDTH: 35%; HEIGHT: 10px"><asp:rangevalidator id="RangeValidator3" runat="server" Font-Size="X-Small" ControlToValidate="txtMaxHoursPerDay"
														ErrorMessage="RangeValidator" Type="Double" MaximumValue="24" MinimumValue="0"> Must be between 0 and 24</asp:rangevalidator><asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" Font-Size="X-Small" ControlToValidate="txtMaxHoursPerDay"
														ErrorMessage="RequiredFieldValidator">Required</asp:requiredfieldvalidator></TD>
											</tr>
											<TR>
												<TD class="formslabels" style="WIDTH: 30%; HEIGHT: 2px"><asp:label id="Label5" runat="server">Max. Hours/Week</asp:label></TD>
												<TD style="WIDTH: 35%; HEIGHT: 2px"><asp:textbox id="txtMaxHoursPerWeek" tabIndex="5" runat="server" CssClass="inputtext" Width="56px"></asp:textbox></TD>
												<TD style="WIDTH: 35%; HEIGHT: 2px"><asp:rangevalidator id="RangeValidator4" runat="server" Font-Size="X-Small" ControlToValidate="txtMaxHoursPerWeek"
														ErrorMessage="RangeValidator" Type="Double" MaximumValue="168" MinimumValue="1"> Must be between 0 and 168</asp:rangevalidator><asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" Font-Size="X-Small" ControlToValidate="txtMaxHoursPerWeek"
														ErrorMessage="RequiredFieldValidator">Required</asp:requiredfieldvalidator></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 23px" colSpan="3">
													<DIV style="TEXT-ALIGN: center"><asp:button id="btnUpdate" runat="server" Text="Update" onclick="btnUpdate_Click"></asp:button></DIV>
												</TD>
											</TR>
											<TR>
												<TD colSpan="3">
													<DIV style="TEXT-ALIGN: center"><asp:label id="lblNote" runat="server" ForeColor="Red" Visible="False">Label</asp:label></DIV>
												</TD>
											</TR>
										</TBODY>
									</table>
								</td>
							</tr>
						</table>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
