<%@ Page language="c#" Inherits="TSN.ERP.WebGUI.Go.frmEmpJobtitle" CodeFile="frmEmpJobtitle.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>frmEmpJobtitle</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Acc1.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function prepareClose()
		{
			window.close();
		}
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<br>
			<TABLE id="Table1" cellSpacing="0" cellPadding="10" width="416" align="center" border="0" class="FunctionBlock">
				<TR>
					<TD class="headertd" valign=baseline>Employee's Job Title &nbsp;&nbsp;
							<asp:Button id="BtnSave" runat="server" CssClass="stdSavebtn" onclick="BtnSave_Click"></asp:Button>
							<img width=50 onmousedown="src='images/Buttons/close2_s.jpg'" id="imgCancelNote" onmouseover="src='images/Buttons/close2_o.jpg'" onclick="javascript:prepareClose()"  onmouseout="src='images/Buttons/close2_n.jpg'" alt="Cancel" src="images/Buttons/Close2_n.jpg" style="height: 21px"></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table3" style="WIDTH: 461px; HEIGHT: 67px" width="461" align="center" border="0">
							<TR>
								<TD class="formslabels" style="WIDTH: 126px; height: 23px;" width="126" align=right>Code :&nbsp;&nbsp;</TD>
								<TD style="HEIGHT: 23px" ><asp:label id="lblCode" runat="server" CssClass="formslabels">lblCode</asp:label></TD>
							</TR>
							<TR>
								<TD class="formslabels" style="WIDTH: 126px" width="126" align=right>Name :&nbsp;&nbsp;</TD>
								<TD style="HEIGHT: 23px" ><asp:label id="lblName" runat="server" CssClass="formslabels">lblName</asp:label></TD>
							</TR>
							<TR>
								<TD class="formslabels" style="WIDTH: 126px; HEIGHT: 22px" width="126">
									<DIV align="right"><SPAN class="formslabels"  >Current Job Title :&nbsp;&nbsp;</SPAN></DIV>
								</TD>
								<TD style="HEIGHT: 22px" ><asp:label id="lblCurrentJobTitle" runat="server" Width="240px" CssClass="formslabels"></asp:label></TD>
							</TR>
							<TR>
								<TD class="formslabels" style="WIDTH: 126px; HEIGHT: 7px">
									<DIV align="right"><SPAN class="formslabels" >New Job Title :&nbsp;&nbsp;</SPAN></DIV>
								</TD>
								<TD style="HEIGHT: 7px"><asp:dropdownlist id=lstJobs runat="server" CssClass="inputtext" Width="192px" DataValueField="JobTitleID" DataTextField="JobName" DataSource="<%# dsJobtitles1 %>" AutoPostBack="True" ondatabinding="lstJobs_DataBinding" onselectedindexchanged="lstJobs_SelectedIndexChanged">
									</asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<p align="center">
				<table>
					<tr>
						<td align="center">
                            &nbsp;</td>
					</tr>
					<tr>
						<td align="center">
							<asp:datagrid id="grdTasks" runat="server"
								Width="896px" PageSize="3" AutoGenerateColumns="False" Font-Names="Arial" Font-Size="Smaller" DataSource="<%# dsAccountabilitySheet1 %>" HorizontalAlign="Center" BorderStyle="Solid" CellPadding="5" CellSpacing="1">
								<SelectedItemStyle CssClass="offday" BorderStyle="Solid" BorderWidth="1px"></SelectedItemStyle>
								<AlternatingItemStyle CssClass="bsalternativetd" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px"></AlternatingItemStyle>
								<ItemStyle CssClass="bsnormaltd" BorderColor="Black" BorderStyle=Solid BorderWidth="2px"></ItemStyle>
								<HeaderStyle CssClass="whitetd" BorderColor="Black" BorderWidth="1px"></HeaderStyle>
								<Columns>
								<asp:TemplateColumn HeaderText="Responsibility">
										<ItemTemplate>
											<asp:DropDownList id=DropDownListNewResp runat="server" Width="496px" DataSource="<%# dsResponsblities1 %>" DataTextField="ResponsName" DataValueField="ResponsID" BackColor="#00C0C0">
												<asp:ListItem Value="-1" Selected="True">Select Responsibility</asp:ListItem>
											</asp:DropDownList>
										</ItemTemplate>
									</asp:TemplateColumn>
									
									<asp:BoundColumn Visible="False" DataField="ParentProjectID" SortExpression="ParentProjectID"></asp:BoundColumn>
									<asp:TemplateColumn SortExpression="ParentProjectID" HeaderText="Project"></asp:TemplateColumn>
									<asp:BoundColumn DataField="taskname" SortExpression="taskname" HeaderText="Task">
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Complete">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemTemplate>
											<asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="StrongID" SortExpression="StrongID" HeaderText="StrongID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="AssStatus" SortExpression="AssStatus" HeaderText="AssStatus"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="descReponse" SortExpression="AssStatus" HeaderText="OldResponsibility"></asp:BoundColumn>
								</Columns>
								<PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
							</asp:datagrid>
						</td>
					</tr>
					<tr>
						<td align="center">
							<%--<A href="javascript:prepareClose()" class="formslabels">Close</A>--%>
						</td>
					</tr>
				</table>
			</p>
		</form>
	</body>
</HTML>
