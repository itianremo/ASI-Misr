<%@ Reference Control="~/go/accountability.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="Stimulsoft.Report.Web" Assembly="Stimulsoft.Report.Web, Version=2007.1.0.0, Culture=neutral, PublicKeyToken=ebe6666cba19647a" %>

<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.Go.ReportViewer" CodeFile="frmReportViewer.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>ReportViewer</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Acc1.css" type="text/css" rel="stylesheet">
</head>
<body dir="ltr" style="color: Black;">
    <form id="Form1" method="post" runat="server">
        <p align=center>
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server" BorderWidth="1px" BorderColor="White" Height="100px"
                Visible="False" HorizontalAlign="Center">
                <table id="Table1" style="width: 632px; height: 80px" cellspacing="1" cellpadding="1"
                    width="632" align="center" border="0" class="FunctionBlock">
                    <tr>
                        <td style="width: 4px; height: 24px;" valign="top" align="center" width="4">
                            <strong>From</strong></td>
                        <td style="width: 171px; height: 24px;" valign="top" align="center">
                            <img id="imgCal1" alt="Pick a Date" src="../go/images/dlcalendar_1.gif">
                            <asp:TextBox ID="TextBoxFrom" runat="server" Width="99px" CssClass="inputtext"></asp:TextBox>&nbsp;<dlcalendar
                                tool_tip="Pick a Date" click_element_id="imgCal1" input_element_id="TextBoxFrom"
                                firstday="Su"></dlcalendar></td>
                        <td style="width: 1px; height: 24px;" valign="top" align="center" width="1">
                            <strong>To</strong></td>
                        <td valign="top" align="center" width="194" style="height: 24px">
                            <img id="imgCal2" alt="Pick a Date" src="../go/images/dlcalendar_1.gif">
                            <asp:TextBox ID="TextBoxTo" runat="server" Width="99px" CssClass="inputtext"></asp:TextBox>&nbsp;<dlcalendar
                                tool_tip="Pick a Date" click_element_id="imgCal2" input_element_id="TextBoxTo"
                                firstday="Su"></dlcalendar>&nbsp;</td>
                        <td style="width: 519px; height: 24px;" align="center">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 4px" valign="top" width="4">
                        </td>
                        <td style="width: 171px" valign="top" width="171">
                        </td>
                        <td style="width: 1px" valign="top" width="1">
                        </td>
                        <td style="width: 194px" valign="top" width="194">
                        </td>
                        <td style="width: 519px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 501px" valign="top" align="center" width="501" colspan="4">
                            <table id="Table2" style="width: 515px; height: 64px" cellspacing="1" cellpadding="1"
                                width="515" border="0" runat="server">
                                <tr>
                                    <td style="width: 171px; height: 46px" align="center" class="formslabels">
                                        <asp:RadioButtonList ID="RadioButtonListEmp" runat="server" Width="168px" RepeatDirection="Horizontal"
                                            AutoPostBack="True" OnSelectedIndexChanged="RadioButtonListEmp_SelectedIndexChanged" ForeColor="White">
                                            <asp:ListItem Value="1" Selected="True">Employee</asp:ListItem>
                                            <asp:ListItem Value="2">Teams</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                    <td style="width: 146px; height: 46px">
                                        <asp:DropDownList ID="DropDownListTeams" runat="server" Width="262px" AutoPostBack="True"
                                            Enabled="False" DataSource="<%# dsTeams1 %>" DataValueField="TeamID" DataTextField="TeamName"
                                            OnSelectedIndexChanged="DropDownListTeams_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                    <td style="height: 46px">
                                        <asp:DropDownList ID="DropDownListEmp" runat="server" Width="225px" Enabled="False"
                                            DataSource="<%# dsEmployee1 %>" DataValueField="ContactID" DataTextField="Fullname">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 171px" class="formslabels">
                                        <asp:RadioButtonList ID="RadioButtonListNotes" runat="server" Width="165px" RepeatDirection="Horizontal" ForeColor="White">
                                            <asp:ListItem Value="1" Selected="True">Notes</asp:ListItem>
                                            <asp:ListItem Value="2">No Notes</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                    <td style="width: 146px">
                                    </td>
                                    <td align="center">
                                    </td>
                                </tr>
                            </table>
                            <!--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-->
                            <%--<asp:Button ID="ButtonTskSumm" runat="server" Text="Get Report" OnClick="ButtonTskSumm_Click">
                            </asp:Button>--%>
                            <asp:ImageButton ID="ButtonTskSumm" runat="server" OnClick="ButtonTskSumm_Click" ImageUrl="~/Go/images/Buttons/GetReport_n.jpg" /></td>
                        <td style="width: 519px" bordercolor="buttonface">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" style="width: 501px" valign="top" width="501">
                        </td>
                        <td bordercolor="buttonface" style="width: 519px">
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </p>
        <div align="center" class="FunctionBlock">
            <cc2:StiWebViewer ID="StiWebViewer1" runat="server" ViewMode="WholeReport" PrintDestination="Direct"
                UseCache="True" ToolBarBackColor="White"></cc2:StiWebViewer>
        </div>
    </form>

    <script language="javascript" src="../go/include/dlcalendar.js" type="text/javascript"></script>

</body>
</html>
