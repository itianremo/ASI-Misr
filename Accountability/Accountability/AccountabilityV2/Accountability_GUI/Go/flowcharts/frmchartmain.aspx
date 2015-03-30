<%@ Page language="c#" Inherits="TSN.ERP.WebGUI.Go.flowcharts.WebForm1" CodeFile="frmChartMain.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style type="text/css">.style2 { FONT-WEIGHT: bold; FONT-SIZE: 36px; COLOR: #006699 }
	.style3 { FONT-SIZE: 12px; COLOR: #003366 }
	.Border { BORDER-RIGHT: #003366 1px solid; BORDER-TOP: #003366 1px solid; BORDER-LEFT: #003366 1px solid; BORDER-BOTTOM: #003366 1px solid }
	.style4 { COLOR: #ff0000 }
		</style>
		<link href="styles.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td class="Border" bgColor="#eaeaea">
						<div class="topbanner" align="center">Chart Generator
						</div>
					</td>
				</tr>
				<tr>
					<td align="left">
						<p><strong><br>
								<span class="style4">Part 1</span> : What do you want to do? </strong>
							<table cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
								<tr>
									<td>
										<table class="Border" cellSpacing="0" cellPadding="10" width="100%" border="0">
											<tr>
												<td><asp:radiobutton id="optNewChart" runat="server" Text="New Chart" Font-Bold="True" GroupName="optGrpCharts"
														Checked="True"></asp:radiobutton><BR>
													<span class="style3">Select this option to begin&nbsp;creating&nbsp; a new chart.</span></td>
											</tr>
										</table>
										<br>
										<TABLE class="Border" id="Table1" cellSpacing="0" cellPadding="10" width="100%" border="0">
											<TR>
												<TD><asp:radiobutton id="optUpdateChart" runat="server" Text="Update, delete or view existing chart"
														Font-Bold="True" GroupName="optGrpCharts"></asp:radiobutton><BR>
													<SPAN class="style3">Select this option to update, delete or&nbsp;just view 
														existing chart.</SPAN></TD>
											</TR>
										</TABLE>
										<br>
									</td>
								</tr>
								<tr>
									<td align="right"><br>
										<INPUT name="Button" type="button" onClick="window.close();" value="Close">
										<asp:button Enabled="False" id="btnBack" runat="server" Text="Back" onclick="btnBack_Click"></asp:button>&nbsp;
										<asp:button id="btnNext" runat="server" Text="Next" onclick="btnNext_Click"></asp:button>
										&nbsp;</td>
								</tr>
							</table>
						</p>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
