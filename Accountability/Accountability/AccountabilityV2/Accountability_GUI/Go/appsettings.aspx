<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation" %>
<%@ Page language="c#" Inherits="TSN.ERP.WebGUI.Go.AppSettings" ValidateRequest="false" CodeFile="AppSettings.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Application Settings</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style type="text/css">.style2 { FONT-SIZE: 12px; FONT-FAMILY: Arial, Helvetica, sans-serif }
	.btn { BORDER-RIGHT: #000066 1px solid; BORDER-TOP: #000066 1px solid; FONT-SIZE: 10px; BORDER-LEFT: #000066 1px solid; COLOR: #000066; BORDER-BOTTOM: #000066 1px solid; FONT-FAMILY: Arial, Helvetica, sans-serif; BACKGROUND-COLOR: #ffffff; br: bold }
		</style>
		<LINK href="../Acc1.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<div align="center">
			</div>
			<DIV align="center">&nbsp;</DIV>
			<DIV align="center">&nbsp;</DIV>
			<DIV align="center">
				<table style="WIDTH: 750px; HEIGHT: 28.24%" align="center">
					<tr>
						<td class="headertd" style="HEIGHT: 25px">Mail Settings
						</td>
					</tr>
					<tr>
						<td class="whitetd" width="80%" valign="top">
							<!--- our div----->
							<div id="divEmail" align="center"><asp:label id="lblNote" runat="server" Visible="False" ForeColor="Red"></asp:label>
								<table style="TEXT-ALIGN: center">
									<TBODY style="TEXT-ALIGN: center" vAlign="top">
										<tr>
											<td style="WIDTH: 12.12%; HEIGHT: 27px; TEXT-ALIGN: right">
												<asp:label id="lblFrom" runat="server" Font-Size="X-Small">Server Name</asp:label></td>
											<td style="WIDTH: 80%; HEIGHT: 27px; TEXT-ALIGN: left"><asp:textbox id="txtServerName" runat="server" Width="500px"></asp:textbox></td>
										</tr>
										<tr>
											<td style="WIDTH: 12.12%; TEXT-ALIGN: right">
												<asp:label id="Label1" runat="server" Font-Size="X-Small">SMTP Server</asp:label></td>
											<td style="WIDTH: 80%; TEXT-ALIGN: left"><asp:textbox id="txtSMTPServer" runat="server" Width="500px"></asp:textbox></td>
										</tr>
										<tr>
											<td style="WIDTH: 12.12%; TEXT-ALIGN: right">
												<asp:label id="Label2" runat="server" Font-Size="X-Small">SMTP Port</asp:label></td>
											<td style="WIDTH: 80%; TEXT-ALIGN: left"><asp:textbox id="txtSMTPPort" runat="server" Width="500px"></asp:textbox></td>
										</tr>
										<tr>
											<td style="WIDTH: 12.12%; TEXT-ALIGN: right">
												<asp:label id="Label3" runat="server" Font-Size="X-Small">User Name</asp:label></td>
											<td style="WIDTH: 80%; TEXT-ALIGN: left"><asp:textbox id="txtUserName" runat="server" Width="500px"></asp:textbox></td>
										</tr>
										<tr>
											<td style="WIDTH: 12.12%; HEIGHT: 25px; TEXT-ALIGN: right">
												<asp:label id="Label4" runat="server" Font-Size="X-Small">Password</asp:label></td>
											<td style="WIDTH: 80%; HEIGHT: 25px; TEXT-ALIGN: left"><asp:textbox id="txtPassword" runat="server" Width="500px"></asp:textbox></td>
										</tr>
										<TR>
											<TD style="WIDTH: 12.12%; HEIGHT: 25px; TEXT-ALIGN: right"></TD>
											<TD style="WIDTH: 80%; HEIGHT: 25px; TEXT-ALIGN: center"><asp:Button id="btnSaveMailSettings" runat="server" Width="65px" Text="Save" onclick="btnSaveMailSettings_Click"></asp:Button>
											</TD>
										</TR>
									</TBODY>
								</table>
							</div>
						</td>
					</tr>
				</table>
				<br>
				<table width="100%" align="center" border="0">
					<tr align="center">
						<td></td>
					</tr>
				</table>
				<P></P>
			</DIV>
			<p align="center">
		</form>
		</P>
	</body>
</HTML>
