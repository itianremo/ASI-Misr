<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.Go.MFGAccountability" CodeFile="MFGAccountability.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns:o="urn:schemas-microsoft-com:office:office">
<head>
    <title>MFG Accountability</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <link href="../Acc1.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <br>
        <table id="Table1" style="height: 120px" cellspacing="0" cellpadding="10" width="100%"
            align="left" border="0" runat="server" class="FunctionBlock">
            <tr>
                <td align="center" width="100%">
                    <table id="Table3" style="width: 461px; height: 67px" width="461" align="left" border="0">
                        <tr>
                            <td class="formslabels" style="width: 126px; height: 24px;text-align:right" width="126">
                                <asp:Label ID="LabelEmp" runat="server" CssClass="formslabels">Employee</asp:Label></td>
                            <td style="height: 24px" width="242">
                                <asp:DropDownList ID="lstEmp" runat="server" CssClass="inputtext" AutoPostBack="True"
                                    Width="192px" OnSelectedIndexChanged="lstEmp_SelectedIndexChanged">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="formslabels" style="width: 126px; height: 23px;text-align:right" width="126">
                                Calendar</td>
                            <td style="height: 23px" width="242">
                                <asp:TextBox ID="TextBoxFrom" runat="server" CssClass="inputtext" Width="72px" ></asp:TextBox>
                                <dlcalendar tool_tip="Pick a Date" click_element_id="imgCal1" input_element_id="TextBoxFrom"
                                    firstday="Su"></dlcalendar>
                                <img id="imgCal1" alt="Pick a Date" src="images/dlcalendar_1.gif" name="imgCal1">
                            </td>
                        </tr>
                        <tr>
                            <td class="formslabels" style="width: 126px; height: 6px;text-align:right" width="126">
                                <div >
                                    <span >Show</span></div>
                            </td>
                            <td style="height: 6px" width="242">
                                <asp:DropDownList ID="DropdownlistDate" runat="server" CssClass="inputtext" AutoPostBack="True"
                                    Width="192px" OnSelectedIndexChanged="DropdownlistDate_SelectedIndexChanged">
                                    <asp:ListItem Value="0">Today</asp:ListItem>
                                    <asp:ListItem Value="1">Whole Week</asp:ListItem>
                                    <asp:ListItem Value="Sunday">Sunday</asp:ListItem>
                                    <asp:ListItem Value="Monday">Monday</asp:ListItem>
                                    <asp:ListItem Value="Tuesday">Tuesday</asp:ListItem>
                                    <asp:ListItem Value="Wednesday">Wednesday</asp:ListItem>
                                    <asp:ListItem Value="Thursday">Thursday</asp:ListItem>
                                    <asp:ListItem Value="Friday">Friday</asp:ListItem>
                                    <asp:ListItem Value="Saturday">Saturday</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:Button ID="Button1" Style="z-index: 101; left: 32px; position: absolute; top: 448px"
            runat="server" CssClass="invisableButton" Width="62px" Text="Button" Visible="False"
            OnClick="Button1_Click"></asp:Button>
        <table id="Table4" style="z-index: 102; left: 0px; margin-left: 0px; position: absolute;
            top: 224px" cellspacing="1" cellpadding="1" width="100%" border="0">
            <tr>
                <td style="height: 21px" class="FunctionBlock">
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    <!--<dlcalendar firstday="Su" click_element_id="imgCal" input_element_id="txtDate" tool_tip="Click to choose a date">
							<IMG id="imgCal" height="15" alt="Pick a Date" src="images/dlcalendar_1.gif" width="20"
								name="imgCal">-->
                </td>
            </tr>
        </table>
        <asp:Label ID="Label1" Style="z-index: 103; left: 464px; position: absolute; top: 176px"
            runat="server" Visible="False" Font-Names="Arial" Font-Size="Medium" ForeColor="DarkRed"> Sorry there are no MFG employees</asp:Label>
    </form>

    <script language="javascript" src="include/dlcalendar.js" type="text/javascript"></script>

    <span class="style7">

        <script language="javascript" src="include/buttons.js" type="text/javascript"></script>

    </span>
</body>
</html>
