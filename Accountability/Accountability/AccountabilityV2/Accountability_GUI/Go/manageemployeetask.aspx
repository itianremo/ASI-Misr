<%@ Page language="c#" Inherits="TSN.ERP.WebGUI.Go.ManageEmployeeTask" CodeFile="ManageEmployeeTask.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ManageEmployeeTask</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Acc1.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<FORM id="Form1" method="post" runat="server">
			<asp:panel id="Panel1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
				Height="488px">
				<TABLE id="Table1" style="WIDTH: 688px; HEIGHT: 294px" cellSpacing="1" cellPadding="1"
					width="688" border="0">
					<TR>
						<TD class="headertd" style="WIDTH: 384px; HEIGHT: 10px">Assign Project's Tasks To 
							Employee's Responsibilities</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 384px; HEIGHT: 1px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 384px; HEIGHT: 21px" vAlign="top" align="left">
							<asp:Label id="lblEmp" runat="server" CssClass="formslabels">Employee Name:</asp:Label>&nbsp;
							<asp:Label id="lblEmpName" runat="server" CssClass="formslabels">Employee Name</asp:Label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 384px; HEIGHT: 3px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 384px; HEIGHT: 1px" vAlign="top" align="left">
							<asp:Label id="lblEmpRes" runat="server" CssClass="formslabels">Employee Responsibilities & Tasks</asp:Label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 384px; HEIGHT: 95px" vAlign="top" align="left">
							<asp:DataGrid id=dgEmpResTasks runat="server" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSource="<%# dvEmpAccSheet %>" DataMember="EmpAccSheet" AutoGenerateColumns="False" Width="384px">
								<SelectedItemStyle Font-Bold="True"></SelectedItemStyle>
								<AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
								<ItemStyle CssClass="bsnormaltd"></ItemStyle>
								<HeaderStyle Font-Bold="True" CssClass="headertd"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="Taskpriority" SortExpression="Taskpriority" HeaderText="Priority">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="taskname" SortExpression="taskname" HeaderText="Responsibility">
										<HeaderStyle Width="95%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Select">
										<ItemTemplate>
											<asp:CheckBox id="CheckBox1" runat="server" Visible="False"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="StrongID" SortExpression="StrongID" HeaderText="StrongID"></asp:BoundColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Left" CssClass="gridpager" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 384px; HEIGHT: 4px" vAlign="top" align="left"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 384px; HEIGHT: 25px" vAlign="top" align="left">
							<asp:Button id="btnCompleteTask" runat="server" CssClass="slectedbutton" Width="90px" Text="Complete" onclick="btnCompleteTask_Click"></asp:Button>&nbsp;
							<asp:Button id="btnRemoveTask" runat="server" CssClass="slectedbutton" Width="83px" Text="Remove" onclick="btnRemoveTask_Click"></asp:Button>&nbsp;
							<asp:Button id="btnCancel" runat="server" CssClass="slectedbutton" Width="74px" Text="Cancel" onclick="btnCancel_Click"></asp:Button></TD>
					</TR>
				</TABLE>
			</asp:panel></FORM>
	</body>
</HTML>
