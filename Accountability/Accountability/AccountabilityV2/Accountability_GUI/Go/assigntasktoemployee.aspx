<%@ Page language="c#" Inherits="TSN.ERP.WebGUI.Go.AssignTaskToEmployee" CodeFile="AssignTaskToEmployee.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AssignTaskToEmployee</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Acc1.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel1" runat="server" Height="488px">
				<TABLE id="Table1" style="WIDTH: 688px; HEIGHT: 448px" cellSpacing="1" cellPadding="1"
					width="688" border="0">
					<TR>
						<TD class="formslabels" style="WIDTH: 384px; HEIGHT: 10px">
							<asp:Label id="lblTitle" runat="server">Assign Project's Tasks To Employee's Responsibilities</asp:Label></TD>
						<TD style="HEIGHT: 10px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 384px; HEIGHT: 8px"></TD>
						<TD style="HEIGHT: 8px"></TD>
					</TR>
					<TR>
						<TD class="formslabels" style="WIDTH: 384px; HEIGHT: 43px" vAlign="top" align="left">
							<asp:Label id="lblEmp" runat="server">Employee Name:</asp:Label>&nbsp;
							<asp:Label id="lblEmpName" runat="server">Employee Name</asp:Label></TD>
						<TD style="HEIGHT: 43px" vAlign="top" align="left"></TD>
					</TR>
					<TR>
						<TD class="formslabels" style="WIDTH: 384px; HEIGHT: 3px">
							<asp:Label id="lblEmpRes" runat="server">Employee Responsibilities & Tasks</asp:Label></TD>
						<TD style="HEIGHT: 3px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 384px; HEIGHT: 1px" vAlign="top" align="left"></TD>
						<TD style="HEIGHT: 1px" vAlign="top" align="left"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 384px; HEIGHT: 159px" vAlign="top" align="left">
							<asp:DataGrid id=dgEmpResTasks runat="server" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" Width="384px" DataSource="<%# dvEmpAccSheet %>" DataMember="EmpAccSheet" AutoGenerateColumns="False">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle CssClass="gridalternativeitem"></AlternatingItemStyle>
								<ItemStyle CssClass="griditem"></ItemStyle>
								<HeaderStyle Font-Bold="True" CssClass="headertd"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
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
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid></TD>
						<TD style="HEIGHT: 159px" vAlign="top" align="left"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 384px; HEIGHT: 9px" vAlign="top" align="left">
							<asp:Label id="lblProjectTasks" runat="server">Project Tasks :</asp:Label></TD>
						<TD style="HEIGHT: 9px" vAlign="top" align="left"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 384px; HEIGHT: 2px" vAlign="top" align="left">
							<asp:DataGrid id=dgProjectTasks runat="server" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" Width="384px" DataSource="<%# dsTasks1 %>" DataMember="GEN_Tasks" AutoGenerateColumns="False" onselectedindexchanged="dgProjectTasks_SelectedIndexChanged">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle CssClass="gridalternativeitem"></AlternatingItemStyle>
								<ItemStyle CssClass="griditem"></ItemStyle>
								<HeaderStyle Font-Bold="True" CssClass="headertd"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<Columns>
									<asp:BoundColumn DataField="TaskID" SortExpression="TaskID" HeaderText="ID">
										<HeaderStyle Width="5px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TaskName" SortExpression="TaskName" HeaderText="Task">
										<HeaderStyle Width="200px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TaskCreatBy" SortExpression="TaskCreatBy" HeaderText="By"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Select">
										<HeaderStyle Width="5px"></HeaderStyle>
										<ItemTemplate>
											<asp:CheckBox id="SelectTask" runat="server" Width="2px"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid></TD>
						<TD style="HEIGHT: 2px" vAlign="top" align="left"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 384px" vAlign="top" align="left"></TD>
						<TD vAlign="top" align="left"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 384px" vAlign="top" align="right">
							<asp:Button id="btnAssign" runat="server" Width="80px" CssClass="slectedbutton" Text="Assign" onclick="btnAssign_Click"></asp:Button>&nbsp;
							<asp:Button id="btnCancel" runat="server" Width="74px" CssClass="slectedbutton" Text="Cancel" onclick="btnCancel_Click"></asp:Button></TD>
						<TD vAlign="top" align="left"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 384px" vAlign="top" align="left"></TD>
						<TD vAlign="top" align="left"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 384px" vAlign="top" align="left"></TD>
						<TD vAlign="top" align="left"></TD>
					</TR>
				</TABLE>
			</asp:panel>&nbsp;</form>
	</body>
</HTML>
