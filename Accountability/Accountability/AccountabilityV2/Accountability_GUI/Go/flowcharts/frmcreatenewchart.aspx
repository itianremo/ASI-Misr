<%@ Page language="c#" Inherits="TSN.ERP.WebGUI.Go.flowcharts.frmCreateNewChart" CodeFile="frmCreateNewChart.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>frmCreateNewChart</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<style type="text/css">
.Border { BORDER-RIGHT: #003366 1px solid; BORDER-TOP: #003366 1px solid; BORDER-LEFT: #003366 1px solid; BORDER-BOTTOM: #003366 1px solid }
.style3 { FONT-SIZE: 12px; COLOR: #003366 }
.style4 { COLOR: #ff0000 }
		</style>
		<link href="styles.css" rel="stylesheet" type="text/css">
		<LINK href="../../Acc1.css" type="text/css" rel="stylesheet">
		<style type="text/css">
.style5 { COLOR: #ff6600 }
.style6 { COLOR: #ffffff }
		</style>
	</HEAD>
	<body dir="ltr">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
			<tr>
					<td align="left"> &nbsp;&nbsp;<asp:Button id="btnNext" runat="server" Text="Next" Width="60px" CssClass="slectedbutton" onclick="btnNext_Click"></asp:Button>&nbsp;
					</td>
				</tr>
				<tr>
					<td align="center" style="HEIGHT: 283px">
						<table width="100%" border="0" cellpadding="4" cellspacing="4" class="FunctionBlock">
							<tr>
								<td><span class="partLabel"><strong>Part 1 :</strong></span><strong> </strong>
									<strong >Create new chart </strong>
								</td>
							</tr>
							<tr>
								<td><span class="formslabels">Chart name</span>
									<asp:TextBox CssClass="inputtext" id="txtChartName" runat="server" MaxLength="30"></asp:TextBox>&nbsp;
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtChartName"></asp:RequiredFieldValidator>&nbsp;
									<asp:Label id="lblMSG" runat="server" Visible="False" ForeColor="Red" Font-Size="XX-Small"
										Font-Bold="True"></asp:Label></td>
							</tr>
							<tr>
								<td>
									<asp:RadioButton id="optDept" runat="server" Text="Departments Hierarchy" Checked="True" GroupName="optGrpTypes"></asp:RadioButton>
									<BR>
									<span class="formslabels">View the hierarchy of departments and divisions inside the 
										company . </span>
								</td>
							</tr>
							<tr>
								<td>
									<asp:RadioButton id="optJob" runat="server" Text="Job titles" GroupName="optGrpTypes"></asp:RadioButton>
									<BR>
									<span class="formslabels">View titles and roles inside the company as well as employees 
										occupying each title.&nbsp;&nbsp; </span>
								</td>
							</tr>
							<tr>
								<td>
									<asp:RadioButton id="optTeam" runat="server" Text="Teams" GroupName="optGrpTypes"></asp:RadioButton>
									<BR>
									<span class="formslabels">View teams and team-members for the whole company. </span>
								</td>
							</tr>
							<tr>
								<td>
									<asp:RadioButton id="optProject" runat="server" Text="Projects" GroupName="optGrpTypes"></asp:RadioButton>
									<BR>
									<span class="formslabels">View company projects as well as employees participate in 
										these projects. </span>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td align="left"><br>
						&nbsp;
						
						<P></P>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
