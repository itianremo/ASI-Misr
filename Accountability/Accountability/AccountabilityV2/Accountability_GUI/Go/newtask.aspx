<%@ Page language="c#" Inherits="TSN.ERP.WebGUI.Go.NewTask" CodeFile="NewTask.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>NewTask</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Acc1.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<asp:PlaceHolder id="PlaceHolder1" runat="server"></asp:PlaceHolder></P>
			<P>&nbsp;&nbsp;&nbsp;&nbsp;
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" align="center" border="0">
					<TR>
						<TD vAlign="top" align="center">
							<asp:LinkButton id="LinkButton1" runat="server" Width="48px" CssClass="whitelabels" Font-Bold="True" Visible="False" onclick="LinkButton1_Click">Back</asp:LinkButton>&nbsp;
<asp:ImageButton id=ImageButton1 runat="server" ImageUrl="images/cancelbutton.gif" ToolTip="Back"></asp:ImageButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
					</TR>
				</TABLE>
			</P>
		</form>
		<script language="javascript" src="include/dlcalendar.js" type="text/javascript"></script>
		<script language="javascript" src="include/buttons.js" type="text/javascript"></script>
	</body>
</HTML>
