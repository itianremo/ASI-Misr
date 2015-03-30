<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RunReport.aspx.cs" Inherits="RunReport"
	Theme="Red" MasterPageFile="~/MasterLayout.master" %>

<%@ MasterType VirtualPath="~/MasterLayout.master" %>
<asp:Content ID="Head" runat="server" ContentPlaceHolderID="head">
	<title>Reports</title>
	<style type="text/css">
		body
		{
			scrollbar-base-color: #c2d7db;
		}
	</style>
	<script type="text/javascript" src="Scripts/Scripts.js"></script>
	<script type="text/javascript">
		var x = 45
		var y = 1

		function startClock() {
			x = x - y
			if (x == 44) {
				//CheckSession();
			}
			setTimeout("startClock()", 10000)
			if (x == 0) {
				window.close();

			}
		}

		function CheckSession() {
			document.getElementById("btnRefresh").click();
			setTimeout("CheckSession()", 1000)
		}

		function CloseThis() {
			window.open('', '_parent', ''); window.close();
			alert('s');
		}
	</script>
</asp:Content>
<asp:Content ID="Main" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
	<div class="header">
	</div>
	<div class="ui-layout-content">
		<table id="tbldesc" align="center" border="1" bordercolor="#000000" cellspacing="0"
			width="500" cellpadding="0">
			<tr>
				<td valign="top" background="Images/hbgNew.JPG">
					<table id="tblheader" border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
						<tr>
							<td>
								&nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Tahoma"
									Font-Size="13px" ForeColor="White" Text="Reports"></asp:Label>
							</td>
							<td>
							</td>
							<td align="right">
								<asp:ImageButton ID="imgbtnReportWriter" runat="server" ImageUrl="~/Images/ReportWriter-n.jpg"
									AlternateText="Go To Report Writer" />
							</td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td align="center" height="202px" valign="top">
					<rwg:FrozenGridView ID="gvReports" runat="server" AutoGenerateColumns="False" BackColor="White"
						BorderColor="#666666" BorderWidth="1px" CellPadding="0" DataKeyNames="ReportID,ReportType"
						OnRowCreated="gvReports_RowCreated" OnRowDataBound="gvReports_RowDataBound" Scrolling="Auto"
						Width="100%" EnableModelValidation="True" AllowSorting="True" OnSorting="gvReports_Sorting"
						ScrollHeight="" ScrollWidth="">
						<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
						<RowStyle BackColor="#E8EDF3" BorderColor="#666666" Font-Bold="False" />
						<SelectedRowStyle BackColor="#FF9966" Font-Bold="True" />
						<PagerStyle Font-Bold="True" HorizontalAlign="Center" />
						<HeaderStyle Font-Bold="True" Font-Names="Tahoma" Font-Size="12px" ForeColor="White"
							BackColor="Black" Height="25px" />
						<Columns>
							<asp:BoundField DataField="ReportID" HeaderText="ReportID" Visible="False" />
							<asp:TemplateField HeaderText="Report Name" SortExpression="ReportName">
								<EditItemTemplate>
									<asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ReportName") %>'></asp:TextBox>
								</EditItemTemplate>
								<ItemTemplate>
									<asp:Label ID="lblRepName" runat="server" Text='<%# Bind("ReportName") %>' ToolTip='<%# Bind("ReportDescription") %>'
										Font-Names="Arial" Font-Size="11px"></asp:Label>
								</ItemTemplate>
								<HeaderStyle Font-Bold="True" Font-Names="Arial" Font-Size="11px" Width="320px" />
								<ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Left" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Requested By" SortExpression="REP_RepRemarks">
								<EditItemTemplate>
									<asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("REP_Creator") %>'></asp:TextBox>
								</EditItemTemplate>
								<ItemTemplate>
									<asp:Label ID="lblReportCreator" runat="server" Text='<%# Bind("REP_Creator") %>'
										Font-Names="Arial" Font-Size="11px"></asp:Label>
								</ItemTemplate>
								<HeaderStyle Font-Bold="True" Font-Names="Arial" Font-Size="11px" Width="80px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Date" SortExpression="REP_RepDate">
								<ItemTemplate>
									<asp:Label ID="lblReportDate" runat="server" Text='<%# Eval("REP_RepDate","0:MM/dd/yyyy") %>'
										Font-Bold="False" Font-Names="Arial" Font-Size="11px"></asp:Label>
								</ItemTemplate>
								<HeaderStyle Font-Bold="True" Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center"
									VerticalAlign="Middle" Width="60px" />
								<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
							</asp:TemplateField>
							<asp:TemplateField>
								<EditItemTemplate>
									<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
								</EditItemTemplate>
								<ItemTemplate>
									<asp:HyperLink ID="lnkRun" runat="server" Font-Names="Tahoma" Font-Size="11px" NavigateUrl="#"
										Target="_blank" ToolTip="Run Report">Run</asp:HyperLink>
								</ItemTemplate>
								<HeaderStyle Width="40px" />
								<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
							</asp:TemplateField>
							<asp:BoundField DataField="ReportModule">
								<HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
								<ItemStyle Font-Bold="False" HorizontalAlign="Left" VerticalAlign="Middle" />
							</asp:BoundField>
						</Columns>
						<AlternatingRowStyle BackColor="#E0E0E0" />
					</rwg:FrozenGridView>
				</td>
			</tr>
		</table>
	</div>
	<div class="footer">
		<script>
			var scrollTop1;
			Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler1);
			Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler1);

			function BeginRequestHandler1(sender, args) {
				var elem = document.getElementById('__gvgvReports__div');
				if (elem != null)
					scrollTop1 = elem.scrollTop;
			}

			function EndRequestHandler1(sender, args) {
				var elem = document.getElementById('__gvgvReports__div');
				if (elem != null)
					elem.scrollTop = scrollTop1;

			}

		</script>
	</div>
</asp:Content>
