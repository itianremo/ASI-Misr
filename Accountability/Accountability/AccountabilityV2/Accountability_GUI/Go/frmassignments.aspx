<%@ Page language="c#" Inherits="TSN.ERP.WebGUI.Assignments" CodeFile="frmAssignments.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Assignments</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Acc1.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 119; LEFT: 8px; WIDTH: 472px; TOP: 24px; HEIGHT: 300px;text-align:center;"
				cellSpacing="1" cellPadding="1" width="472" border="0" align=center class="FunctionBlock">
				<TR>
					<TD colSpan="2">
						<asp:Label id="lblWarning" runat="server" Width="472px" Font-Size="X-Small" ForeColor="Red"
							Font-Bold="True">Note: Negative sign(-) means more than one transaction on the same cell</asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 342px" align="right">
						<asp:Label id="lblTaskName" runat="server" CssClass="formslabels">Task name </asp:Label></TD>
					<TD style="width: 323px">
						<asp:TextBox id="txtAssignmentName" runat="server" CssClass="inputtext" Width="320px" ReadOnly="True"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 342px" align="right">
						<asp:Label id="lblTaskDesription" runat="server" CssClass="formslabels">Task Description</asp:Label></TD>
					<TD style="width: 323px">
						<asp:TextBox id="txtAssignementDescription" runat="server" Width="320px" Rows="5" TextMode="MultiLine"
							CssClass="inputtext" ReadOnly="True"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 342px" align="right">
						<asp:Label id="lblFromDate" runat="server" CssClass="formslabels">From</asp:Label></TD>
					<TD style="width: 323px" align="left">
						<asp:TextBox id="txtFromDate" runat="server" Width="112px" CssClass="inputtext" ReadOnly="True"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 342px; height: 24px;" align="right">
						<asp:Label id="lblToDate" runat="server" CssClass="formslabels">To</asp:Label></TD>
					<TD style="width: 323px; height: 24px;" align="left">
						<asp:TextBox id="txtToDate" runat="server" Width="112px" CssClass="inputtext" ReadOnly="True"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 342px; height: 24px;" align="right">
						<asp:Label id="txtTotalUnits" runat="server" CssClass="formslabels">Total Units</asp:Label></TD>
					<TD style="width: 323px; height: 24px;" align="left">
						<asp:TextBox id="txtTotalsUnits" runat="server" Width="112px" CssClass="inputtext" ReadOnly="True"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 342px" align="right">
						<asp:Label id="lblEsitamtes" runat="server" CssClass="formslabels">Planned</asp:Label></TD>
					<TD style="width: 323px" align="left">
						<asp:TextBox id="txtEstimates" runat="server" Width="112px" CssClass="inputtext" ReadOnly="True"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 342px" align="right">
						<asp:Label id="lblDueDate" runat="server" CssClass="formslabels">Due Date</asp:Label></TD>
					<TD style="width: 323px" align="left">
						<asp:TextBox id="txtDueDate" runat="server" Width="112px" CssClass="inputtext" ReadOnly="True"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 342px; height: 24px;" align="right">
						<asp:Label id="lblCompleted" runat="server" CssClass="formslabels">Completed</asp:Label></TD>
					<TD style="width: 323px; height: 24px" align="left">
						<asp:TextBox id="txtCompleted" runat="server" Width="112px" CssClass="inputtext" ReadOnly="True"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 342px"></TD>
					<TD style="width: 323px"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 342px; height: 310px;" align="center" colSpan="2">
						<DIV style="WIDTH: 400px">
							<TABLE style="WIDTH: 100%" cellSpacing="0" border="0">
								<TR class="whitetd">
									<TD>Date
									</TD>
									<TD>Units
									</TD>
								</TR>
							</TABLE>
							<div style=" OVERFLOW: auto; WIDTH: 400px; HEIGHT: 250px">
								<asp:DataGrid id=dgAssignments runat="server" Width="100%" DataSource="<%# dvAssignments %>" AutoGenerateColumns="False" DataKeyField="AssignmentD" ShowHeader="False">
									<AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
									<ItemStyle CssClass="bsnormaltd"></ItemStyle>
									<HeaderStyle CssClass="headertd"></HeaderStyle>
									<Columns>
										<asp:BoundColumn DataField="AccountabilityDate" SortExpression="AccountabilityDate" ReadOnly="True"
											HeaderText="Date" DataFormatString="{0:d}"></asp:BoundColumn>
										<asp:BoundColumn DataField="AccountabilityValue" SortExpression="AccountabilityValue" ReadOnly="True"
											HeaderText="Units"></asp:BoundColumn>
									</Columns>
								</asp:DataGrid>
							</div>
						</DIV>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
