<%@ Page language="c#" Inherits="TSN.ERP.WebGUI.Go.flowcharts.frmViewChart" CodeFile="frmViewChart.aspx.cs" %>
<%@ Register Assembly="NetDiagram" Namespace="MindFusion.Diagramming.WebForms" TagPrefix="ndiag" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>frmViewChart</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="styles.css" type="text/css" rel="stylesheet">
		<LINK href="../../Acc1.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function TableDeleteConfirmation()
        {
           return confirm("Are you sure you want to delete this Employee?");
            
        }
        function ArrowDeleteConfirmation()
        {
           return confirm("Are you sure you want to delete this Arrow?");
            
        }
        </script>
		<style type="text/css">
.style3 { COLOR: #ff6600 }
.style4 { COLOR: #ffffff }
		</style>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="10" cellspacing="0" class="FunctionBlock">
				<tr>
					<td align="left"> &nbsp;&nbsp;<asp:button id="btnBack" runat="server" CssClass="btn" Text="Back" Width="60px" onclick="btnBack_Click"></asp:button>&nbsp;
						<asp:Button id="btnSave" runat="server" CssClass="btn" Text="Save" onclick="btnSave_Click"></asp:Button>&nbsp;
						<asp:Button id="btnExport" runat="server" CssClass="btn" Text="Export" Visible="False" onclick="btnExport_Click"></asp:Button></td>
				</tr>
				<tr>
					<td class="blue"><STRONG><SPAN class="style3">Part 4 </SPAN>: <span class="style4">View 
								chart ... </span></STRONG>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label CssClass="inputtext" id="lblMsg" runat="server" Visible="False" Width="200px">Saved ...</asp:Label>
						<BR>				 
						   <ndiag:FlowChart ID="fcChart"  runat="server" SelHandleSize="10" MeasureUnit="Inch"
            Height="500" Width="1000" ArrowIntermSize="20" TableDeletingScript="TableDeleteConfirmation" ArrowDeletingScript="ArrowDeleteConfirmation" ArrowEndsMovable="true" ArrowStyle="Polyline" arro    />
            <asp:Image CssClass="imgborder" ID="imgChart" ImageUrl="ImageGen.aspx" runat="server" Visible="false"
            ></asp:Image>
            <br />
						</td>
				</tr>
				<tr>
					<td align="left">&nbsp;&nbsp;
						</td>
				</tr>
			</table>
			
			
		</form>
	</body>
</HTML>
