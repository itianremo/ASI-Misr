<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.Go.addNewProject" CodeFile="addNewProject.ascx.cs" %>
<LINK href="../Acc1.css" type="text/css" rel="stylesheet">
<DIV style="WIDTH: 712px; POSITION: relative; HEIGHT: 751px"
	id="DIV1" runat="server" align="left">
	<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 680px; POSITION: absolute; TOP: 8px; HEIGHT: 456px"
		cellSpacing="1" cellPadding="1" width="680" border="1">
		<TR>
			<TD style="HEIGHT: 156px" vAlign="top" align="left">
				<TABLE id="Table2" style="WIDTH: 584px; HEIGHT: 99px" cellSpacing="1" cellPadding="1" width="584"
					border="0">
					<TR>
						<TD style="HEIGHT: 16px" class="formslabels">Project Name</TD>
						<TD style="HEIGHT: 16px">
							<asp:TextBox id="txtProjectName" runat="server" Width="263px" CssClass="inputtext"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD class="formslabels">Project Manager</TD>
						<TD>
							<asp:DropDownList id="drpManagerList" runat="server" Width="263px" DataSource="<%# dataView1 %>" DataTextField="JobTitleID" CssClass="inputtext">
							</asp:DropDownList></TD>
					</TR>
					<TR>
						<TD class="formslabels">Delivery Date</TD>
						<TD>
							<asp:TextBox id="txtDeliverDate" runat="server" Width="150px" CssClass="inputtext">1/1/2005</asp:TextBox>&nbsp;</TD>
					</TR>
					<TR>
						<TD class="formslabels">Critical Date</TD>
						<TD>
							<asp:TextBox id="txtCriticalDate" runat="server" Width="150px" CssClass="inputtext">1/1/2006</asp:TextBox></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD align="left">
							<asp:Button id="btnSaveProject" runat="server" Width="61px" Text="Save" CssClass="slectedbutton" onclick="btnSaveProject_Click"></asp:Button>&nbsp;
							<asp:Button id="btnCancel" runat="server" Text="Cancel" CssClass="slectedbutton" onclick="btnCancel_Click"></asp:Button>&nbsp;&nbsp;</TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
		<TR>
			<TD style="HEIGHT: 177px" vAlign="top" align="left">
				<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="300" border="0">
					<TR>
						<TD>Projects Tasks</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 131px">
							<asp:DataGrid id="DataGrid1" runat="server" Width="288px" BorderStyle="None" BorderWidth="1px"
								CellPadding="4">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle CssClass="gridalternativeitem"></AlternatingItemStyle>
								<ItemStyle CssClass="griditem"></ItemStyle>
								<HeaderStyle Font-Bold="True" CssClass="headertd"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid></TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:Button id="btnNewTask" runat="server" Text="New Task" CssClass="slectedbutton"></asp:Button>&nbsp;
							<asp:Button id="btnEditTask" runat="server" Text="Edit Task" CssClass="slectedbutton"></asp:Button>&nbsp;
							<asp:Button id="btnDeleteTask" runat="server" Width="80px" Text="Delete Task" CssClass="slectedbutton"></asp:Button></TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
		<TR>
			<TD>
				<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="300" border="0">
					<TR>
						<TD vAlign="top" align="left">Assigned Employees To This Project</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 167px" vAlign="top" align="left">
							<asp:DataGrid id="DataGrid2" runat="server" Width="288px" BorderStyle="None" BorderWidth="1px"
								CellPadding="4">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle CssClass="gridalternativeitem"></AlternatingItemStyle>
								<ItemStyle CssClass="griditem"></ItemStyle>
								<HeaderStyle Font-Bold="True" CssClass="headertd"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center">
							<asp:Button id="btnAddEmp" runat="server" Width="80px" Text="Add" CssClass="slectedbutton"></asp:Button>&nbsp;
							<asp:Button id="btnRemoveEmp" runat="server" Width="72px" Text="Remove" CssClass="slectedbutton"></asp:Button></TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
		<TR>
			<TD></TD>
		</TR>
	</TABLE>
</DIV>
