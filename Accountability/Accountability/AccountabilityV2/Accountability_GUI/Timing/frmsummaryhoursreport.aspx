<%@ Page language="c#" Inherits="TSN.ERP.WebGUI.frmSummaryHoursReport" CodeFile="frmSummaryHoursReport.aspx.cs" %>
<HTML>
	<HEAD>
		<title>frmDayDetailsReport</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Acc1.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<div align="center">
				<TABLE id="Table1" height="800" cellSpacing="1" cellPadding="1" width="300" align="center"
					border="0">
					<TR height="20">
						<TD colSpan="3"></TD>
					</TR>
					<TR vAlign="top">
						<TD vAlign="top" colSpan="3">
							<TABLE id="Table2" cellSpacing="5" cellPadding="5" width="520" border="0">
								<TR>
									<TD class="headertd">Summary&nbsp;Hours Screen</TD>
								</TR>
								<TR>
									<TD class="whitetd">
										<TABLE id="Table4" cellSpacing="5" cellPadding="5" width="300" border="0">
											<TR>
												<TD class="formslabels" style="WIDTH: 30%; HEIGHT: 25px" colSpan="3"></TD>
											</TR>
											<TR>
												<TD class="formslabels" style="WIDTH: 30%; HEIGHT: 25px" colSpan="3">
													<TABLE id="Table3" style="WIDTH: 632px; HEIGHT: 80px" borderColor="#003300" cellSpacing="1"
														cellPadding="1" width="632" align="center" border="0">
														<TR>
															<TD style="WIDTH: 501px" vAlign="top" align="center" width="600" colSpan="4">
																<TABLE id="Table5" style="WIDTH: 580px; HEIGHT: 95px" cellSpacing="1" cellPadding="1" width="580"
																	border="0" runat="server">
																	<TR>
																		<TD style="WIDTH: 200px; HEIGHT: 46px" vAlign="top" align="right">
																			<asp:label id="lblDay" runat="server" Font-Size="10pt">Start Week Date</asp:label></TD>
																		<TD style="WIDTH: 146px; HEIGHT: 46px" vAlign="top"><IMG id="imgCal1" alt="Pick a Date" src="../go/images/dlcalendar_1.gif">
																			<asp:TextBox id="TextBoxFrom" runat="server" Width="99px" CssClass="inputtext"></asp:TextBox><DLCALENDAR tool_tip="Pick a Date" click_element_id="imgCal1" input_element_id="TextBoxFrom"
																				firstday="Su"></DLCALENDAR></TD>
																		<TD style="HEIGHT: 46px">
																			<asp:RadioButtonList id="rbtnWeeks" runat="server" Width="168px" RepeatDirection="Horizontal" AutoPostBack="True"
																				Height="12px">
																				<asp:ListItem Value="1" Selected="True">1 week</asp:ListItem>
																				<asp:ListItem Value="2"> 2 weeks</asp:ListItem>
																			</asp:RadioButtonList></TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 200px; HEIGHT: 46px" align="right" valign="top">
																			<asp:RadioButtonList id="RadioButtonListEmp" runat="server" Width="168px" RepeatDirection="Horizontal"
																				AutoPostBack="True" onselectedindexchanged="RadioButtonListEmp_SelectedIndexChanged">
																				<asp:ListItem Value="1" Selected="True">Employee</asp:ListItem>
																				<asp:ListItem Value="2">All</asp:ListItem>
																			</asp:RadioButtonList></TD>
																		<TD style="WIDTH: 146px; HEIGHT: 46px" valign="top">
																			<asp:DropDownList id="DropDownListEmp" runat="server" Width="225px" Enabled="False" DataValueField="ContactID"
																				DataTextField="Fullname"></asp:DropDownList></TD>
																		<TD style="HEIGHT: 46px"></TD>
																	</TR>
																</TABLE> <!--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-->
																<asp:Button id="btnGetReport" runat="server" Text="Get Report" onclick="btnGetReport_Click"></asp:Button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD class="formslabels" style="WIDTH: 30%; HEIGHT: 25px" colSpan="3"><div id="divReport" runat="server">&nbsp;</div>
												</TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 23px" colSpan="3">
													<DIV style="TEXT-ALIGN: center">&nbsp;</DIV>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
				<asp:RadioButtonList id="RadioButtonList1" runat="server" Width="168px" RepeatDirection="Horizontal"
					AutoPostBack="True">
					<asp:ListItem Value="1" Selected="True">1 week</asp:ListItem>
					<asp:ListItem Value="2"> 2 weeks</asp:ListItem>
				</asp:RadioButtonList>
			</div>
		</form>
		<script language="javascript" src="../go/include/dlcalendar.js" type="text/javascript"></script>
		<span class="style7">
			<script language="javascript" src="../go/include/buttons.js" type="text/javascript"></script>
		</span>
	</body>
</HTML>
