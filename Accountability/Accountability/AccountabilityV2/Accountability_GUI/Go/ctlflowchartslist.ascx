<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.Go.ctlFlowChartsList" CodeFile="ctlFlowChartsList.ascx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<LINK href="../Acc1.css" type="text/css" rel="stylesheet">
<P>
	<TABLE id="Table1" cellSpacing="0" cellPadding="5" width="45%" align="center" border="5"
		height="100%" class="FunctionBlock">
		<TR>
			<TD class="headertd" style="WIDTH: 633px" colspan="3">Organization Charts
			</TD>
		</TR>
		<TR>
			<TD height="100%" align="center" colspan="3" vAlign="top">
				<P>
				</P>
				<div align="center">
					<asp:DataGrid id="dgFlowCharts" runat="server" DataSource="<%# dsOrgnizationCharts1 %>" DataMember="GEN_OrgnizationCharts" AutoGenerateColumns="False" Width="469px" BorderColor="White" CellPadding="2">
						<AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
						<ItemStyle CssClass="bsnormaltd"></ItemStyle>
						<HeaderStyle CssClass="whitetd"></HeaderStyle>
						<Columns>
							<asp:BoundColumn DataField="FileID" SortExpression="FileID" HeaderText="ID" Visible="False"></asp:BoundColumn>
							<asp:BoundColumn ItemStyle-Width="300" DataField="OChartDesc" SortExpression="OChartDesc" HeaderText="Chart Name">
							<ItemStyle HorizontalAlign="Left" />
							</asp:BoundColumn>
							<asp:TemplateColumn>
								<ItemTemplate>
									<%--<asp:ImageButton id="cbView" runat="server" ToolTip="View Chart" ImageUrl="..\go\images\\view.gif"></asp:ImageButton>--%>
									<asp:ImageButton id="cbView" runat="server" ToolTip="View Chart" ImageUrl="~/Go/images/Buttons/ViewChart_n.jpg"></asp:ImageButton>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn>
								<ItemTemplate>
									<%--<asp:ImageButton id="imgEdit" runat="server" ToolTip="Edit Chart" ImageUrl="images/edit.gif"></asp:ImageButton>--%>
									<asp:ImageButton id="imgEdit" runat="server" ToolTip="Edit Chart" ImageUrl="~/Go/images/Buttons/EditChart_n.jpg"></asp:ImageButton>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn>
								<ItemTemplate>
									<%--<asp:ImageButton id="imgDelete" runat="server" ToolTip="Delete Chart" ImageUrl="images/delete.gif"></asp:ImageButton>--%>
									<asp:ImageButton id="imgDelete" runat="server" ToolTip="Delete Chart" ImageUrl="~/Go/images/Buttons/DeletChart_n.jpg"></asp:ImageButton>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn>
								<ItemTemplate>
									
									<asp:ImageButton id="imgDownload" runat="server" ToolTip="Download file" ImageUrl="~/Go/images/Buttons/Download_n.jpg"></asp:ImageButton>
								</ItemTemplate>
							</asp:TemplateColumn>
							
							<asp:BoundColumn Visible="False" DataField="OChartType" SortExpression="OChartType" HeaderText="OChartType"></asp:BoundColumn>
						</Columns>
					</asp:DataGrid>
				</div>
				<P></P>
			</TD>
		</TR>
		<TR>
			<TD></TD>
			<TD></TD>
			<TD></TD>
		</TR>
	</TABLE>
</P>
<P>&nbsp;</P>
