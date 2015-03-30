<%@ Page language="c#" Inherits="TSN.ERP.WebGUI.Navigation.UserModules" CodeFile="UserModules.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Acc1.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<br>
			<br>
			<br>
			<br>
			<br>
			<asp:Label id="Label1" style="Z-INDEX: 101; LEFT: 296px; POSITION: absolute; TOP: 80px" runat="server"
				Visible="False" ForeColor="Red" Font-Bold="True" Font-Names="Tahoma" Font-Size="Larger">You do not have any assigned roles , please contact your system manager</asp:Label>
			<br>
			<br>
			<br>
			<TABLE id="Table1" cellSpacing="5" cellPadding="5" width="300" align="center" border="0"
				runat="server">
				<TR>
					<TD class="headertd" align="center">Modules
					</TD>
				</TR>
				<TR align="center">
					<TD class="whitetd" align="center"><asp:datagrid id="DataGrid1" runat="server" GridLines="None" AutoGenerateColumns="False" HorizontalAlign="Center">
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
							<Columns>
								<asp:TemplateColumn>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="ID1" onclick="GridOnClick" runat="server" CssClass="gridLink">
											<%# DataBinder.Eval(Container, "DataItem.ModName") %>
										</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="ModID">
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
			<TABLE id="Table2" cellSpacing="5" cellPadding="5" width="300" align="center" border="0"
				runat="server">
				<TR>
					<TD class="headertd" align="center">User Actions</TD>
				</TR>
				<tr>
					<td align="center" class="whitetd">
						<P>
							<asp:LinkButton id="cbChangePass" runat="server" CssClass="gridLink" onclick="cbChangePass_Click">Change Password</asp:LinkButton></P>
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
