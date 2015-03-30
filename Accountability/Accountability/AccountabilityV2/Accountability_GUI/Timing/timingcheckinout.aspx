<%@ Page language="c#" Inherits="TSN.ERP.WebGUI.Timing.TimingCheckInOut" CodeFile="TimingCheckInOut.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TimingCheckInOut</title>
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
					border="1">
					<TR>
						<TD colSpan="3">
							<TABLE id="Table2" cellSpacing="5" cellPadding="5" width="520" border="0">
								<TR>
									<TD class="headertd">Timing</TD>
								</TR>
								<TR>
									<TD class="whitetd">
										<TABLE id="Table4" cellSpacing="5" cellPadding="5" width="300" border="0">
											<TR>
												<TD class="formslabels" style="WIDTH: 30%; HEIGHT: 25px"></TD>
												<TD style="WIDTH: 35%; HEIGHT: 25px"></TD>
												<TD style="WIDTH: 35%; HEIGHT: 25px"></TD>
											</TR>
											<TR>
												<TD class="formslabels" style="WIDTH: 30%; HEIGHT: 1px" colSpan="3"><TABLE id="Table3" height="300" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD>
																<asp:Button id="btnCheckIn" runat="server" Text="Check In" onclick="btnCheckIn_Click"></asp:Button></TD>
															<TD>
																<asp:Button id="btnCheckOut" runat="server" Text="Check Out"></asp:Button></TD>
															<TD></TD>
														</TR>
														<TR>
															<TD>
																<asp:Label id="lblBreak" runat="server">Break</asp:Label></TD>
															<TD>
																<asp:TextBox id="txtBreak" tabIndex="4" runat="server" Width="56px" CssClass="inputtext"></asp:TextBox></TD>
															<TD>
																<asp:RangeValidator id="RangeValidator3" runat="server" ErrorMessage="RangeValidator" ControlToValidate="txtBreak"
																	Font-Size="X-Small" MinimumValue="0" MaximumValue="24" Type="Double" Width="97px"> Must be more than 0</asp:RangeValidator></TD>
														</TR>
														<TR>
															<TD colSpan="3" align="center">
																<asp:RadioButtonList id="rbtnStatus" runat="server" Width="280px" Height="212px">
																	<asp:ListItem Value="1" Selected="True">Paid</asp:ListItem>
																	<asp:ListItem Value="2">Ping</asp:ListItem>
																	<asp:ListItem Value="3">GYM</asp:ListItem>
																	<asp:ListItem Value="4">Self Learning</asp:ListItem>
																	<asp:ListItem Value="0">Other</asp:ListItem>
																</asp:RadioButtonList></TD>
														</TR>
														<TR>
															<TD></TD>
															<TD></TD>
															<TD></TD>
														</TR>
													</TABLE>
													<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
													</P>
												</TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 23px" colSpan="3">
													<DIV style="TEXT-ALIGN: center">&nbsp;</DIV>
												</TD>
											</TR>
											<TR>
												<TD colSpan="3">
													<DIV style="TEXT-ALIGN: center">&nbsp;</DIV>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD></TD>
						<TD></TD>
					</TR>
				</TABLE>
			</div>
		</form>
	</body>
</HTML>
