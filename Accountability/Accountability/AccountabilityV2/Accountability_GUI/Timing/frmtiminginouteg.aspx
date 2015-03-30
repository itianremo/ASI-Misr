<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.Timing.FrmTimingInOutEG" CodeFile="FrmTimingInOutEG.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>FrmTimingInOutEG</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Acc1.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <div align="center">
            <table id="Table1" height="800" cellspacing="1" cellpadding="1" width="300" align="center"
                border="0">
                <tr height="20">
                    <td colspan="3">
                    </td>
                </tr>
                <tr valign="top">
                    <td valign="top" colspan="3">
                        <table id="Table2" cellspacing="5" cellpadding="5" width="520" border="0" class="FunctionBlock">
                            <tr>
                                <td class="headertd" style="text-align: left;">
                                    Timing Status</td>
                            </tr>
                            <tr>
                                <td>
                                    <div id="divInOut" runat="server" style="text-align: center;">
                                        <table id="Table4" cellspacing="5" cellpadding="5" width="300" border="0">
                                            <tr>
                                                <td class="formslabels" align="right">
                                                    Welcome:</td>
                                                <td align="left">
                                                    <asp:Label ID="lblWelcome" runat="server" Font-Size="X-Small" ></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formslabels" align="right">
                                                    <asp:Label ID="Label3" runat="server" >Current Status:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblStatus" runat="server" Font-Size="X-Small">Status</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="formslabels">
                                                    Total Check In Time:
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblTotalCheckInTime" runat="server" Font-Size="X-Small"></asp:Label>
                                                    
                                                    <asp:Label ID="Label1" runat="server" Font-Size="X-Small">Hours</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formslabels" align="center" colspan="2">
                                                    <%--<asp:Button ID="btnCheckIn" runat="server" Text="Check In" OnClick="btnCheckIn_Click">
                                                    </asp:Button>--%>
                                                    <asp:ImageButton ID="btnCheckIn" runat="server" OnClick="btnCheckIn_Click" ImageUrl="~/Go/images/Buttons/CheckIn_n.jpg"
                                                        onmouseover="this.src='../Go/images/Buttons/CheckIn_o.jpg'" onmousedown="this.src='../Go/images/Buttons/CheckIn_s.jpg'"
                                                        onmouseout="this.src='../Go/images/Buttons/CheckIn_n.jpg'" ToolTip="Check In" />
                                                    <%--<asp:Button ID="btnCheckOut" runat="server" Text="Check Out" OnClick="btnCheckOut_Click">
                                                    </asp:Button>--%>
                                                    <asp:ImageButton ID="btnCheckOut" runat="server" OnClick="btnCheckOut_Click" ImageUrl="~/Go/images/Buttons/CheckOut_n.jpg"
                                                        onmouseover="this.src='../Go/images/Buttons/CheckOut_o.jpg'" onmousedown="this.src='../Go/images/Buttons/CheckOut_s.jpg'"
                                                        onmouseout="this.src='../Go/images/Buttons/CheckOut_n.jpg'" ToolTip="Check Out" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formslabels" align="center" colspan="2">
                                                    <asp:DataGrid ID="dgTiming" runat="server" AutoGenerateColumns="False" Width="100%">
                                                        <FooterStyle CssClass="bsFootertd" />
                                                        <AlternatingItemStyle CssClass="bsalternativetd" />
                                                        <ItemStyle CssClass="bsnormaltd" />
                                                        <HeaderStyle CssClass="whitetd" />
                                                        <Columns>
                                                            <asp:TemplateColumn HeaderText="Check In">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCheckIn" runat="server" Text='<%# Convert.ToDateTime(Eval("CheckIn")).ToString("hh:mm:ss tt") %>'>
                                                                    </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Check Out">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCheckOut" runat="server" Text='<%# Eval("CheckOut")==DBNull.Value?"":Convert.ToDateTime(Eval("CheckOut")).ToString("hh:mm:ss tt") %>'>
                                                                    </asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                        </Columns>
                                                        <PagerStyle CssClass="bsFootertd" Mode="NumericPages" />
                                                    </asp:DataGrid></td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="divConfirm" runat="server">
                                        &nbsp;</div>
                                    <div id="DivConsimpate" runat="server">
                                    </div>
                                    <div id="admin" align="left" runat="server">
                                        Welcome Administrator.
                                        <br>
                                        <br>
                                        To make check in and check out you shoud select employee from Accountability sheet
                                        screen.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
