<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.SecurityManagement.ctlSessionStatus" CodeFile="ctlSessionStatus.ascx.cs" %>
<P>
	<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="300" border="0">
		<TR>
			<TD>
				<asp:Label id="Label4" runat="server">Token</asp:Label></TD>
			<TD>
				<asp:Label id="lblToken" runat="server"></asp:Label></TD>
			<TD></TD>
		</TR>
		<TR>
			<TD><asp:Label id="Label1" runat="server">Exception</asp:Label></TD>
			<TD>
				<asp:Label id="lblException" runat="server"></asp:Label></TD>
			<TD></TD>
		</TR>
		<TR>
			<TD><asp:Label id="Label2" runat="server">Access Violation</asp:Label></TD>
			<TD>
				<asp:Label id="lblAccessViolation" runat="server"></asp:Label></TD>
			<TD></TD>
		</TR>
	</TABLE>
</P>
