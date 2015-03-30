<%@ Page language="c#" Inherits="TSN.ERP.WebGUI.Go.flowcharts.frmProjects" CodeFile="frmProjects.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>frmProjects</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="styles.css" type="text/css" rel="stylesheet">
		<LINK href="../../Acc1.css" type="text/css" rel="stylesheet">
		<style type="text/css">
.style1 { COLOR: #ff6600 }
		</style>
	</HEAD>
	<body dir="ltr">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" class="FunctionBlock">
				<TR>
					<TD align="left">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
							<TR>
								<TD style="HEIGHT: 430px" align="center">
									<TABLE class="blueBorder" id="Table3" cellSpacing="4" cellPadding="4" width="100%" border="0">
										<tr>
											<td colspan="2" class="blue"><table width="100%" border="0" cellspacing="0" cellpadding="0">
													<tr>
														<td><span class="partLabel">Part 2 :</span><span class="parttitle"> Projects chart</span></td>
														<td align="right">&nbsp;</td>
													</tr>
												</table>
											</td>
										</tr>
										<TR>
											<TD width="43%" vAlign="top" >
												<P class="formslables">Choose Projects</P>
												<P><asp:listbox DataSource="<%# dsProjects %>" DataTextField="ProjectName" DataValueField="projectID" Height="250px" id=lstProjects runat="server" SelectionMode="Multiple" Width="200px">
													</asp:listbox>
												</P>
												<P><asp:checkbox id="chkSelectAll" runat="server" Text="Select all" AutoPostBack="True" oncheckedchanged="chkSelectAll_CheckedChanged"></asp:checkbox><BR>
												</P>
											</TD>
											<TD width="57%" vAlign="top" ><span class="formslables">Chart 
													parameters :</span><br>
												<TABLE id="Table4" cellSpacing="0" cellPadding="10" width="100%" border="0">
													<TR>
														<TD colspan="2">&nbsp;
															<asp:checkbox id="chkEmpName" runat="server" Text="Show employee name" AutoPostBack="True" oncheckedchanged="chkEmpName_CheckedChanged"></asp:checkbox></TD>
													</TR>
													<TR>
														<TD width="10%">&nbsp;</TD>
														<TD><asp:CheckBox ID="chkEmpDept" runat="server" Text="Show employee's department" Enabled="False"></asp:CheckBox></TD>
													</TR>
													<TR>
														<TD>&nbsp;</TD>
														<TD><asp:CheckBox ID="chkEmpTitle" runat="server" Text="Show employee's title" Enabled="False"></asp:CheckBox></TD>
													</TR>
													<TR>
														<TD>&nbsp;</TD>
														<TD><asp:CheckBox ID="chkEmpCode" runat="server" Text="Show employee's codes" Enabled="False"></asp:CheckBox></TD>
													</TR>
													<TR>
														<TD>&nbsp;</TD>
														<TD><asp:CheckBox ID="chkEmpPhoto" runat="server" Text="Show employee's photo" Enabled="False"></asp:CheckBox></TD>
													</TR>
													<TR>
														<TD colspan="2">&nbsp;
															<asp:checkbox id="chkProjectEmpNo" runat="server" Text="Show number of employees in each project"></asp:checkbox></TD>
													</TR>
													<TR>
														<TD colspan="2">&nbsp;
															<asp:checkbox id="chkProjectManager" runat="server" Text="Show project manager"></asp:checkbox></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
									<asp:Label id="Label1" runat="server" CssClass="formslabels" ForeColor="Red" Visible="False">Label</asp:Label>
								</TD>
							</TR>
							<TR>
								<TD align="right">&nbsp;
									<asp:button id="btnBack" runat="server" Width="60px" Text="Back" DESIGNTIMEDRAGDROP="79" CssClass="slectedbutton" onclick="btnBack_Click"></asp:button>&nbsp;
									<asp:button id="btnNext" runat="server" Width="60px" Text="Next" CssClass="slectedbutton" onclick="btnNext_Click"></asp:button></TD>
							</TR>
						</TABLE>
						<P></P>
					</TD>
				</TR>
			</TABLE>
		</FORM>
	</body>
</HTML>
