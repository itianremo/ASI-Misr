<%@ Page language="c#" Inherits="TSN.ERP.WebGUI.Navigation.ErrorPage" CodeFile="ErrorPage.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ErrorPage</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="Acc1.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 536px; POSITION: absolute; TOP: 8px; HEIGHT: 204px"
				cellSpacing="0" cellPadding="0" width="536" border="0" class="whitetd" align="left">
				<TR>
					<TD style="HEIGHT: 7px"></TD>
					<TD style="HEIGHT: 7px" align="center" class="headertd">GO Strategic Error Page</TD>
					<TD style="HEIGHT: 7px"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						<asp:Panel id="pError" runat="server" Height="56px" CssClass="errtable">
							<TABLE class="errtable" id="Table2" cellSpacing="0" cellPadding="2" width="453" bgColor="#ffffc0"
								runat="server">
								<TR>
									<TD class="errtable" style="WIDTH: 43px" bgColor="#ffffc0">
										<P>
											<asp:Image id="Image1" runat="server" BackColor="#ffffc0" ImageUrl="go/images/alrt_l.gif"></asp:Image></P>
									</TD>
									<TD>
										<P>
											<asp:Label id="lblAccess" runat="server" CssClass="errrtable" BackColor="#ffffc0" Font-Bold="True">Access Violation at: </asp:Label></P>
										<P>
											<asp:Label id="lblServer" runat="server" BackColor="#ffffc0" Font-Bold="True">GO Strategic Server Error at:  </asp:Label></P>
									</TD>
								</TR>
							</TABLE>
						</asp:Panel></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						<asp:table CellSpacing="0" CellPadding="2" Visible="False" HorizontalAlign="Center" Font-Size="9pt"
							Font-Names="Arial" BorderWidth="0px" id="tblSessionExpr" runat="server" CssClass="errtable"
							Width="453px" Font-Bold="True">
							<asp:TableRow VerticalAlign="Top">
								<asp:TableCell BackColor="#FFFFC0" BorderColor="White" Text="&lt;img src=&quot;go/images/alrt_l.gif&quot; /&gt;"></asp:TableCell>
								<asp:TableCell BackColor="#FFFFC0" Text="
									&lt;p class=&quot;MsoNormal&quot;&gt;Your Session has expired due to security reasons, please try to log in again&lt;/p&gt;
									
								"></asp:TableCell>
							</asp:TableRow>
						</asp:table></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>This issue may be resolved by logging to the system again&nbsp;&nbsp;
						<asp:Button id="cbLogin" runat="server" Text="Log in" onclick="cbLogin_Click"></asp:Button></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
