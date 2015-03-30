<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.ctlFlowChartsDetails" CodeFile="ctlFlowChartsDetails.ascx.cs" %>
<%@ Register Assembly="NetDiagram" Namespace="MindFusion.Diagramming.WebForms" TagPrefix="ndiag" %>

<LINK href="../Acc1.css" type="text/css" rel="stylesheet">
<link href="../go/flowcharts/styles.css" rel="stylesheet" type="text/css">
<style type="text/css">
.style2 { FONT-WEIGHT: bold; COLOR: #ff9900 }
</style>
<table width="100%" border="0" cellspacing="4" cellpadding="4">
	<tr>
		<td bgcolor="#ffffff" class="blue style2">Chart Details ...
		</td>
	</tr>
	<tr>
		<td>&nbsp;
			 <asp:Image id="imgChart" runat="server" ImageUrl="flowcharts/ImageGen.aspx"></asp:Image></td>
	</tr>
	<tr>
		<td>&nbsp;
			<asp:Button id="btnBack" runat="server" Text="Back" CssClass="slectedbutton" onclick="btnBack_Click"></asp:Button>
			<asp:Button id="btnExport" runat="server" Text="Export" Visible="False" CssClass="slectedbutton" ></asp:Button></td>
	</tr>
</table>
