<%@ Page language="c#" Inherits="TSN.ERP.WebGUI.Timing.OldfrmTimingInOut" CodeFile="OldfrmTimingInOut.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>frmTimingInOut</title>
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
									<TD class="headertd">Timing Status</TD>
								</TR>
								<TR>
									<TD class="whitetd">
										<div id="divInOut" runat="server">
											<TABLE id="Table4" cellSpacing="5" cellPadding="5" width="300" border="0">
												<TR>
													<TD class="formslabels" style="WIDTH: 30%; HEIGHT: 25px" colSpan="3"><asp:label id="lblWelcome" runat="server" Font-Bold="True" Width="312px">Welcome : Employee</asp:label></TD>
												</TR>
												<TR>
													<TD class="formslabels" style="WIDTH: 30%; HEIGHT: 25px" vAlign="top" colSpan="3">
														<TABLE id="Table3" height="20" cellSpacing="1" cellPadding="1" width="100%" border="0">
															<TR>
																<TD class="formslabels" width="75"><asp:label id="Label3" runat="server" Font-Bold="True" Width="130px">Current Status:</asp:label></TD>
																<TD class="formslabels"><asp:label id="lblStatus" runat="server">Status</asp:label></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR>
													<TD class="formslabels" style="WIDTH: 30%; HEIGHT: 25px" colSpan="3"><asp:button id="btnCheckIn" runat="server" Text="Check In" onclick="btnCheckIn_Click"></asp:button></TD>
												</TR>
												<TR>
													<TD class="formslabels" style="WIDTH: 30%; HEIGHT: 25px" colSpan="3"><asp:button id="btnCheckInfromLunch" runat="server" Text="Check In from Lunch" onclick="btnCheckInfromLunch_Click"></asp:button></TD>
												</TR>
												<TR>
													<TD class="formslabels" style="WIDTH: 30%; HEIGHT: 35px" colSpan="3"><asp:button id="btnCheckOutforLunch" runat="server" Text="Check Out for Lunch" onclick="btnCheckOutforLunch_Click"></asp:button></TD>
												</TR>
												<TR>
													<TD class="formslabels" style="WIDTH: 30%; HEIGHT: 25px" colSpan="3"><asp:button id="btnCheckOut" runat="server" Text="Check Out" onclick="btnCheckOut_Click"></asp:button></TD>
												</TR>
												<TR>
													<TD colSpan="3">&nbsp;</TD>
												</TR>
											</TABLE>
										</div>
										<div id="divConfirm" runat="server">
											<TABLE id="Table4" cellSpacing="5" cellPadding="5" width="300" border="0">
												<TR>
													<TD class="formslabels" style="WIDTH: 30%; HEIGHT: 25px" colSpan="3"><asp:label id="Label1" runat="server" Font-Bold="True" Width="312px"></asp:label></TD>
												</TR>
												<TR>
													<TD class="formslabels" style="WIDTH: 30%; HEIGHT: 25px" colSpan="3">
														<TABLE id="Table5" height="20" cellSpacing="1" cellPadding="1" width="100%" border="0">
															<TR>
																<TD class="formslabels" vAlign="top">&nbsp;
																	<asp:label id="lblConfirmMessage" runat="server" Font-Bold="True" Width="312px">message</asp:label></TD>
																<td vAlign="top" align="right" width="43"><IMG src="../go/images/alrt_l.gif"></td>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR>
													<TD class="formslabels" style="WIDTH: 30%; HEIGHT: 25px" colSpan="3"></TD>
												</TR>
												<TR>
													<TD class="formslabels" style="WIDTH: 30%; HEIGHT: 25px" align="center" colSpan="3"><asp:button id="btnYes" runat="server" Width="56px" Text="Yes" onclick="btnYes_Click"></asp:button><asp:button id="btnNo" runat="server" Width="56px" Text="No" onclick="btnNo_Click"></asp:button></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 23px" colSpan="3">
														<DIV style="TEXT-ALIGN: center">&nbsp;</DIV>
													</TD>
												</TR>
											</TABLE>
										</div>
										<div id="DivConsimpate" runat="server">
											<TABLE id="Table4" cellSpacing="5" cellPadding="5" width="300" border="0">
												<TR>
													<TD class="formslabels" style="WIDTH: 30%; HEIGHT: 25px" colSpan="3"><asp:label id="Label2" runat="server" Font-Bold="True" Width="312px"> Compensate check in time</asp:label></TD>
												</TR>
												<TR>
													<TD class="formslabels" style="WIDTH: 30%; HEIGHT: 25px" colSpan="3"></TD>
												</TR>
												<TR>
													<TD class="formslabels" style="WIDTH: 30%; HEIGHT: 25px" colSpan="3">
														<TABLE id="Table5" height="20" cellSpacing="1" cellPadding="1" width="100%" border="0">
															<TR>
																<TD class="formslabels" width="130"><asp:label id="Label5" runat="server" Font-Bold="True" Width="130px">Current Time :</asp:label></TD>
																<TD class="formslabels" align="left"><asp:label id="lblCurrentTime" runat="server" Font-Bold="True" Width="88px">08:30 am</asp:label></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR>
													<TD class="formslabels" style="WIDTH: 30%; HEIGHT: 25px" colSpan="3">Compensate 
														time&nbsp;
														<asp:dropdownlist id="ddlCompensate" runat="server" Width="48px">
															<asp:ListItem Value="0" Selected="True">0</asp:ListItem>
															<asp:ListItem Value="1">1</asp:ListItem>
															<asp:ListItem Value="2">2</asp:ListItem>
															<asp:ListItem Value="3">3</asp:ListItem>
															<asp:ListItem Value="4">4</asp:ListItem>
															<asp:ListItem Value="5">5</asp:ListItem>
															<asp:ListItem Value="6">6</asp:ListItem>
															<asp:ListItem Value="7">7</asp:ListItem>
															<asp:ListItem Value="8">8</asp:ListItem>
															<asp:ListItem Value="9">9</asp:ListItem>
															<asp:ListItem Value="10">10</asp:ListItem>
															<asp:ListItem Value="11">11</asp:ListItem>
															<asp:ListItem Value="12">12</asp:ListItem>
															<asp:ListItem Value="13">13</asp:ListItem>
															<asp:ListItem Value="14">14</asp:ListItem>
															<asp:ListItem Value="15">15</asp:ListItem>
														</asp:dropdownlist>&nbsp;Min.</TD>
												</TR>
												<TR>
													<TD class="formslabels" style="WIDTH: 30%; HEIGHT: 25px" colSpan="3"></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 23px" colSpan="3">
														<DIV style="TEXT-ALIGN: center"><asp:button id="btnOKCompensate" runat="server" Width="56px" Text="OK" onclick="btnOKCompensate_Click"></asp:button></DIV>
													</TD>
												</TR>
											</TABLE>
										</div>
										<div align="left" id="admin" runat="server">Welcome Administrator.
											<br>
											<br>
											To make check in and check out you shoud select employee from Accountability 
											sheet 
											screen.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</div>
		</form>
	</body>
</HTML>
