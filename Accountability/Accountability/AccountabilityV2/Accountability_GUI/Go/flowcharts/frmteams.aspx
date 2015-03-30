<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.Go.flowcharts.frmTeams" CodeFile="frmTeams.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>frmTeams</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <style type="text/css">
		.Border { BORDER-RIGHT: #003366 1px solid; BORDER-TOP: #003366 1px solid; BORDER-LEFT: #003366 1px solid; BORDER-BOTTOM: #003366 1px solid }
		.style4 { COLOR: #ff0000 }
		</style>
    <link href="styles.css" rel="stylesheet" type="text/css">
    <link href="../../Acc1.css" type="text/css" rel="stylesheet">
    <style type="text/css">
	    .style5 { COLOR: #ff6600 }
		</style>
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" class="FunctionBlock">
            <tr>
                <td align="left">
                    <table cellspacing="0" cellpadding="0" width="100%" align="left" border="0">
                        <tr>
                            <td align="center">
                                <table class="Border" cellspacing="4" cellpadding="4" width="100%" border="0">
                                    <tr>
                                        <td colspan="2" class="blue">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td>
                                                        <span class="partLabel">Part 2 :</span> <span class="parttitle">Teams chart </span>
                                                    </td>
                                                    <td align="right">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="43%" valign="top">
                                            <p class="formslables">
                                                Choose teams</p>
                                            <p>
                                                <asp:ListBox DataSource="<%# dsTeams %>" DataTextField="TeamName" DataValueField="TeamID"
                                                    Height="250px" ID="lstTeams" runat="server" SelectionMode="Multiple" Width="200px">
                                                </asp:ListBox>
                                            </p>
                                            <p>
                                                <asp:CheckBox ID="chkSelectAll" runat="server" Text="Select all" AutoPostBack="True"
                                                    OnCheckedChanged="chkSelectAll_CheckedChanged"></asp:CheckBox>
                                                <br>
                                            </p>
                                        </td>
                                        <td width="57%" valign="top">
                                            <span class="formslables">Chart parameters :</span><br>
                                            <table cellspacing="0" cellpadding="10" width="100%" border="0">
                                                <tr>
                                                    <td colspan="2">
                                                        &nbsp;
                                                        <asp:CheckBox ID="chkEmpName" Text="Show employee name" runat="server" AutoPostBack="True"
                                                            OnCheckedChanged="chkEmpName_CheckedChanged"></asp:CheckBox></td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        &nbsp;</td>
                                                    <td>
                                                        <asp:CheckBox ID="chkEmpDept" Text="Show employee's department" runat="server" EnableViewState="False"
                                                            Enabled="False"></asp:CheckBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        <asp:CheckBox ID="chkEmpCode" Text="Show employee's codes" runat="server" EnableViewState="False"
                                                            Enabled="False"></asp:CheckBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        <asp:CheckBox ID="chkEmpTitle" runat="server" Text="Show employee's title" EnableViewState="False"
                                                            Enabled="False"></asp:CheckBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        <asp:CheckBox ID="chkEmpPhoto" runat="server" Text="Show employee's photo" EnableViewState="False"
                                                            Enabled="False"></asp:CheckBox></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        &nbsp;
                                                        <asp:CheckBox ID="chkTeamEmpNo" Text="Show number of employees in each team" runat="server">
                                                        </asp:CheckBox></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        &nbsp;
                                                        <asp:CheckBox ID="chkTeamLeader" Text="Show team leader" runat="server"></asp:CheckBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Label ID="Label1" runat="server" CssClass="formslabels" ForeColor="Red" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;
                                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="slectedbutton" OnClick="btnBack_Click">
                                </asp:Button>
                                <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="slectedbutton" OnClick="btnNext_Click">
                                </asp:Button></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        &nbsp;
    </form>
</body>
</html>
