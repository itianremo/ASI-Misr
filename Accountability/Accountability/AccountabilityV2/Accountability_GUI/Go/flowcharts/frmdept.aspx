<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.Go.flowcharts.frmDeptHierarchy" CodeFile="frmDept.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>frmDeptHierarchy</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <style type="text/css">
		.Border { BORDER-RIGHT: #003366 1px solid; BORDER-TOP: #003366 1px solid; BORDER-LEFT: #003366 1px solid; BORDER-BOTTOM: #003366 1px solid }
		</style>
    <link href="styles.css" type="text/css" rel="stylesheet">
    <link href="../../Acc1.css" type="text/css" rel="stylesheet">
    <style type="text/css">
		.style5 { COLOR: #ff6600 }
		</style>
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" class="FunctionBlockTable">
        <tr style="height:3px;">
                            <td style="height:3px;" align="left"> &nbsp;&nbsp;&nbsp;</td>
                        </tr>
              <tr>
                            <td align="left"> &nbsp;&nbsp;<asp:Button ID="btnBack" runat="server" Text="Back" CssClass="slectedbutton" OnClick="btnBack_Click">
                                </asp:Button>&nbsp;
                                <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="slectedbutton" OnClick="btnNext_Click">
                                </asp:Button>&nbsp;</td>
                        </tr>
            <tr>
                <td align="left">
                    <table cellspacing="0" cellpadding="0" width="100%" align="left" border="0">
                        <tr>
                            <td align="center" style="height: 457px">
                                <table class="Border" cellspacing="4" cellpadding="4" width="100%" border="0">
                                    <tr>
                                        <td class="blue" colspan="2">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td>
                                                        <span class="partLabel">Part 2 :</span> <span class="parttitle">Department hierarchy
                                                            chart</span></td>
                                                    <td align="right">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="43%" style="height: 373px">
                                            <span class="formslabels"><span>Select root company element </span></span>
                                            <br>
                                            <div style="width: 100%; height: 330px; overflow: scroll;color:White">
                                                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                            </div>
                                        </td>
                                        <td valign="top" width="57%" style="height: 373px">
                                            <span class="formslabelsBlack">Chart parameters :</span>
                                            <br>
                                            <table cellspacing="0" cellpadding="10" width="100%" border="0">
                                                <tr>
                                                    <td colspan="2">
                                                        &nbsp;
                                                        <asp:CheckBox  ID="chkEmpName" runat="server" AutoPostBack="True" Text="Show employees"
                                                            OnCheckedChanged="chkEmpName_CheckedChanged" CssClass="formslabelsBlack"></asp:CheckBox></td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        &nbsp;</td>
                                                    <td width="90%">
                                                        <asp:CheckBox ID="chkEmpCode" runat="server" Text="Show employee's codes" Enabled="False" CssClass="formslabelsBlack">
                                                        </asp:CheckBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        <asp:CheckBox ID="chkEmpJob" runat="server" Text="Show employee's title" Enabled="False"
                                                            AutoPostBack="True" OnCheckedChanged="chkEmpJob_CheckedChanged" CssClass="formslabelsBlack"></asp:CheckBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        <asp:CheckBox ID="chkEmpPhoto" runat="server" Text="Show employee's photo" Enabled="False" CssClass="formslabelsBlack">
                                                        </asp:CheckBox></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        &nbsp;
                                                        <asp:CheckBox ID="chkEmpNo" runat="server" Text="Show number of employees in each department" CssClass="formslabelsBlack" >
                                                        </asp:CheckBox></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        &nbsp;
                                                        <asp:CheckBox ID="chkDeptManager" runat="server" Text="Show department manager" CssClass="formslabelsBlack"></asp:CheckBox></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height: 40px">
                                                        &nbsp;
                                                        <asp:CheckBox ID="chkGrpByEmpTitles" runat="server" AutoPostBack="True" Text="Group by employees' titles."
                                                            OnCheckedChanged="chkGrpByEmpTitles_CheckedChanged" CssClass="formslabelsBlack"></asp:CheckBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        <asp:CheckBox ID="chkJobEmpNo" runat="server" Text="Show number of employees occupying each job."
                                                            Enabled="False" CssClass="formslabelsBlack"></asp:CheckBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Label ID="lblMSG" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                &nbsp;
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
