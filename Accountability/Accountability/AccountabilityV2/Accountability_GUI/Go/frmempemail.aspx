<%@ Page language="c#" Inherits="TSN.ERP.WebGUI.Go.frmEmpEmail" CodeFile="frmEmpEmail.aspx.cs" %>
<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>frmEmpPhone</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style type="text/css">.style2 { FONT-SIZE: 12px; FONT-FAMILY: Arial, Helvetica, sans-serif }
	.btn { BORDER-RIGHT: #000066 1px solid; BORDER-TOP: #000066 1px solid; FONT-SIZE: 10px; BORDER-LEFT: #000066 1px solid; COLOR: #000066; BORDER-BOTTOM: #000066 1px solid; FONT-FAMILY: Arial, Helvetica, sans-serif; BACKGROUND-COLOR: #ffffff; br: bold }
	</style>
		<LINK href="../Acc1.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function load()
		{
			document.getElementById('lblCode').innerHTML = opener.document.getElementById('_ctl0_txtCode').value;	
			document.getElementById('lblName').innerHTML = opener.document.getElementById('_ctl0_txtFName').value
									+ ' ' + opener.document.getElementById('_ctl0_txtLName').value;	
		}
		function prepareClose()
		{
			window.close();
		}
		</script>
</HEAD>
	<body onload="load()">
		<form id="Form1" method="post" runat="server">
			<div align="center">
				<table style="WIDTH: 397px; HEIGHT: 293px" cellSpacing="5" cellPadding="5" width="397"
					border="0" class="FunctionBlock">
					<tr>
						<td class="headertd">Employee's contacts
						</td>
					</tr>
					<tr>
						<td >
							<table style="BORDER-COLLAPSE: collapse" borderColor="#0066cc" cellSpacing="0" cellPadding="0"
								width="200" border="0">
								<tr>
									<td class="formslabels" style="height: 16px"><span class="formslabels">Code</span>
									</td>
									<td style="height: 16px"><asp:label id="lblCode" runat="server" Font-Bold="True" Font-Size="Smaller"></asp:label></td>
								</tr>
								<tr>
									<td class="formslabels" style="height: 16px"><span class="formslabels">Name</span>
									</td>
									<td style="height: 16px"><asp:label id="lblName" runat="server" Font-Bold="True" Font-Size="Smaller"></asp:label></td>
								</tr>
							</table>
							<br>
							<table style="WIDTH: 374px; HEIGHT: 28px" width="374" align="center" border="0">
								<tr>
									<td class="formslabels" style="HEIGHT: 25px" width="131">
										<div class="style2" align="right"><span class="formslabels">Email</span></div>
									</td>
									<td style="WIDTH: 137px; HEIGHT: 25px" width="137"><asp:textbox id="txtEmail" runat="server"></asp:textbox></td>
									<td style="HEIGHT: 25px" width="97"><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter Valid Email Address"
											ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:regularexpressionvalidator></td>
								</tr>
								<tr>
									<td class="formslabels" style="HEIGHT: 7px">
										<div class="style2" align="right"><span class="formslabels">Email Type</span></div>
									</td>
									<td style="WIDTH: 137px; HEIGHT: 7px"><asp:dropdownlist id="ddlEmailType" runat="server" Width="150px" CssClass="inputtext">
											<asp:ListItem Value="0">Internal</asp:ListItem>
											<asp:ListItem Value="1">External</asp:ListItem>
											<asp:ListItem Value="2">Private</asp:ListItem>
										</asp:dropdownlist></td>
									<td style="HEIGHT: 7px"></td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
				<asp:label id="lblMSG" runat="server" ForeColor="Red" CssClass="RegularText"></asp:label><br>
				<table width="100%" align="center" border="0">
					<tr align="center">
						<td><cc1:secbuttons id="btnAdd" runat="server" CssClass="stdSaveBtn" ToolTip="Save email" RuleID="5044" onclick="btnAdd_Click"></cc1:secbuttons></td>
					</tr>
				</table>
				<asp:datagrid id=grdEmails runat="server" Font-Size="Smaller" Width="392px" BackColor="White" AutoGenerateColumns="False" Font-Names="Arial" GridLines="Vertical" CellPadding="3" BorderWidth="1px" BorderStyle="None" BorderColor="#999999" DESIGNTIMEDRAGDROP="1200" DataSource="<%# dsEmail1 %>" OnDeleteCommand="OnDelete">
					<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
					<AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
					<ItemStyle CssClass="bsnormaltd"></ItemStyle>
					<HeaderStyle CssClass="whitetd"></HeaderStyle>
					<Columns>
						<asp:BoundColumn DataField="EmailID" SortExpression="EmailID" HeaderText="Contact Email ID" Visible="False"></asp:BoundColumn>
						<asp:BoundColumn DataField="ContactEmail" SortExpression="ContactEmail" HeaderText="Contact Email"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="Email Type"></asp:TemplateColumn>
						<asp:BoundColumn DataField="EmailType" SortExpression="EmailType" HeaderText="Email Type" Visible="False"></asp:BoundColumn>
						<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
					</Columns>
					<PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
				</asp:datagrid>
				<P></P>
			</div>
			<p align="center"><A class="formslabels" href="javascript:prepareClose()">Close</A>
		</form>
	</body>
</HTML>
