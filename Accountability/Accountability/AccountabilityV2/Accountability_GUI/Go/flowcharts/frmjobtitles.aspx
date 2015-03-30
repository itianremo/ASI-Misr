<%@ Page language="c#" Inherits="TSN.ERP.WebGUI.Go.flowcharts.frmJobTitles" CodeFile="frmJobTitles.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>frmJobTitles</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style type="text/css">
		.Border { BORDER-RIGHT: #003366 1px solid; BORDER-TOP: #003366 1px solid; BORDER-LEFT: #003366 1px solid; BORDER-BOTTOM: #003366 1px solid }
		.style4 { COLOR: #ff0000 }
		</style>
		<LINK href="styles.css" type="text/css" rel="stylesheet">
		<LINK href="../../Acc1.css" type="text/css" rel="stylesheet">
		<style type="text/css">
.style5 { COLOR: #ff6600 }
		</style>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" class="FunctionBlock">
				<tr>
					<td align="left">
						<table cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
							<tr>
								<td style="HEIGHT: 399px" align="center">
									<table cellSpacing="4" cellPadding="4" width="100%" border="0">
										<tr>
											<td colspan="2" class="blue"><table width="100%" border="0" cellspacing="0" cellpadding="0">
													<tr>
														<td><span class="partLabel">Part 2 :</span><span class="parttitle"> Job titles chart </span>
														</td>
														<td align="right">&nbsp;</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td width="43%" vAlign="top" ><span class="formslables">Select 
													root company element</span><br>
												<div style="width:100%;height:330px;overflow:scroll;">
												<asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
												</div>
												<P></P>
											</td>
											<td width="57%" vAlign="top" ><span class="formslables">Chart 
													parameters :</span><br>
												<table cellSpacing="0" cellPadding="10" width="100%" border="0">
													<tr>
														<td colspan="2">&nbsp;
															<asp:CheckBox ID="chkEmpName" runat="server" AutoPostBack="True" Text="Show employee name" oncheckedchanged="chkEmpName_CheckedChanged"></asp:CheckBox></td>
													</tr>
													<tr>
														<td width="10%">&nbsp;</td>
														<td><asp:CheckBox ID="chkEmpDept" runat="server" Text="Show employee's department" Enabled="False"></asp:CheckBox></td>
													</tr>
													<tr>
														<td>&nbsp;</td>
														<td><asp:CheckBox ID="chkEmpCode" runat="server" Text="Show employee's codes" Enabled="False"></asp:CheckBox></td>
													</tr>
													<tr>
														<td>&nbsp;</td>
														<td><asp:CheckBox ID="chkEmpPhoto" runat="server" Text="Show employee's photo" Enabled="False"></asp:CheckBox></td>
													</tr>
													<tr>
														<td colspan="2">&nbsp;
															<asp:checkbox id="chkEmpNo" runat="server" Text="Show number of employees in selected department"></asp:checkbox></td>
													</tr>
													<tr>
														<td colspan="2">&nbsp;
															<asp:checkbox id="chkDeptManager" runat="server" Text="Show department manager"></asp:checkbox></td>
													</tr>
													<tr>
														<td colspan="2">&nbsp;
															<asp:checkbox id="chkJobEmpNo" runat="server" Text="Show number of employees occupying each job."></asp:checkbox></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
									<asp:Label id="lblMSG" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Bold="True"></asp:Label>
								</td>
							</tr>
							<tr>
								<td align="right">&nbsp;
									<asp:button id="btnBack" runat="server" Text="Back" Width="60px" DESIGNTIMEDRAGDROP="79" CssClass="slectedbutton" onclick="btnBack_Click"></asp:button>&nbsp;<asp:button id="btnNext" runat="server" Text="Next" Width="60px" CssClass="slectedbutton" onclick="btnNext_Click"></asp:button></td>
							</tr>
						</table>
						<P></P>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
