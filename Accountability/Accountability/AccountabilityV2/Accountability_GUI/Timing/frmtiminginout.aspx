<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.frmTimingInOut" CodeFile="frmTimingInOut.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>frmTimingInOut</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Acc1.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <br>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <div align="center">
            &nbsp;
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
                                <td class="headertd" style="text-align: left;width:100%;">
                                    Time Card Status</td>
                            </tr>
                            <tr>
                                <td>
                                    <div id="divInOut" runat="server" style="text-align: center;">
                                        <table id="Table44" cellspacing="5" cellpadding="5" border="0" width="100%">
                                            <tr>
                                                <td class="formslabels" align="right">
                                                    Welcome:
                                                </td>
                                                <td class="formslabels">
                                                    <asp:Label ID="lblWelcome" runat="server" Font-Bold="True"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="formslabels" align="right">
                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True">Current Status:</asp:Label>
                                                </td>
                                                <td class="formslabels">
                                                    <asp:Label ID="lblStatus" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formslabels" align="right">
                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True">Location:</asp:Label>
                                                </td>
                                                <td class="formslabels">
                                                    <asp:DropDownList ID="ddLocation" runat="server">
                                                        <asp:ListItem Value="6">TDC</asp:ListItem>
                                                        <asp:ListItem Value="2">Home</asp:ListItem>
                                                        <asp:ListItem Value="3">On The Road</asp:ListItem>
                                                        <asp:ListItem Value="4">Raleigh</asp:ListItem>
                                                        <asp:ListItem Value="5">Las Vegas</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <%--  <tr>
                                                <td class="formslabels" style="width: 30%;" valign="top" colspan="3">
                                                    <table id="Table3" height="20" cellspacing="1" cellpadding="1" width="100%" border="0">
                                                        <tr>
                                                            <td class="formslabels" width="75">
                                                                <asp:Label ID="Label3" runat="server" Width="130px" Font-Bold="True">Current Status:</asp:Label></td>
                                                            <td class="formslabels">
                                                                <asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="formslabels" align="right" width="75">
                                                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Width="63px">Location:</asp:Label></td>
                                                            <td class="formslabels" align="left">
                                                                <asp:DropDownList ID="ddLocation" runat="server">
                                                                    <asp:ListItem Value="6">TDC</asp:ListItem>
                                                                    <asp:ListItem Value="2">Home</asp:ListItem>
                                                                    <asp:ListItem Value="3">On The Road</asp:ListItem>
                                                                    <asp:ListItem Value="4">Raleigh</asp:ListItem>
                                                                    <asp:ListItem Value="5">Las Vegas</asp:ListItem>
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td align="right" class="formslabels">
                                                    <asp:Label ID="label19" runat="server" Font-Bold="True">Total Check In Time: </asp:Label></td>
                                                <td class="formslabels">
                                                    <asp:Label ID="lblTotalCheckInTime" runat="server"></asp:Label>
                                                    Hours</td>
                                            </tr>
                                            <tr>
                                                <td class="formslabels" align="center" colspan="2">
                                                    <%--<asp:Button ID="btnCheckIn" runat="server" Width="88px" Text="Check In" OnClick="btnCheckIn_Click">
                                                                </asp:Button>--%>
                                                    <asp:ImageButton ID="btnCheckIn" runat="server" OnClick="btnCheckIn_Click" ImageUrl="~/Go/images/Buttons/CheckIn_n.jpg"
                                                        onmouseover="this.src='../Go/images/Buttons/CheckIn_o.jpg'" onmousedown="this.src='../Go/images/Buttons/CheckIn_s.jpg'"
                                                        onmouseout="this.src='../Go/images/Buttons/CheckIn_n.jpg'" CausesValidation="False" ToolTip="Check In" /><%--</td>--%>
                                                    <%--<td class="formslabels" width="50%">
                                                                <%--<asp:Button ID="btnCheckOut" runat="server" Text="Check Out" OnClick="btnCheckOut_Click">
                                                                </asp:Button>--%>
                                                    <asp:ImageButton ID="btnCheckOut" runat="server" OnClick="btnCheckOut_Click" ImageUrl="~/Go/images/Buttons/CheckOut_n.jpg"
                                                        onmouseover="this.src='../Go/images/Buttons/CheckOut_o.jpg'" onmousedown="this.src='../Go/images/Buttons/CheckOut_s.jpg'"
                                                        onmouseout="this.src='../Go/images/Buttons/CheckOut_n.jpg'" ToolTip="Check Out" /></td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="divConfirm" runat="server">
                                        <table id="Table4" cellspacing="5" cellpadding="5" width="300" border="0">
                                            <tr>
                                                <td class="formslabels" style="width: 30%; height: 25px" colspan="3">
                                                    <asp:Label ID="Label1" runat="server" Width="312px" Font-Bold="True"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="formslabels" style="width: 30%; height: 72px" colspan="3">
                                                    <table id="Table5" height="20" cellspacing="1" cellpadding="1" width="100%" border="0">
                                                        <tr>
                                                            <td class="formslabels" valign="top">
                                                                &nbsp;
                                                                <asp:Label ID="lblConfirmMessage" runat="server" Width="312px" Font-Bold="True">message</asp:Label></td>
                                                            <td valign="top" align="right" width="43">
                                                                <img src="../go/images/alrt_l.gif"></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formslabels" style="width: 30%; height: 25px" align="center" colspan="3">
                                                    <%--<asp:Button ID="btnYes" runat="server" Width="56px" Text="Yes" OnClick="btnYes_Click">
                                                    </asp:Button>--%>
                                                    <asp:ImageButton ID="btnYes" runat="server" OnClick="btnYes_Click" ImageUrl="~/Go/images/Buttons/Yes_n.jpg"
                                                        onmouseover="this.src='../Go/images/Buttons/Yes_o.jpg'" onmousedown="this.src='../Go/images/Buttons/Yes_s.jpg'"
                                                        onmouseout="this.src='../Go/images/Buttons/Yes_n.jpg'" ToolTip="Yes" />
                                                    <%--<asp:Button ID="btnNo" runat="server" Width="56px" Text="No" OnClick="btnNo_Click">
                                                    </asp:Button>--%>
                                                    <asp:ImageButton ID="btnNo" runat="server" OnClick="btnNo_Click" ImageUrl="~/Go/images/Buttons/No_n.jpg"
                                                        onmouseover="this.src='../Go/images/Buttons/No_o.jpg'" onmousedown="this.src='../Go/images/Buttons/No_s.jpg'"
                                                        onmouseout="this.src='../Go/images/Buttons/No_n.jpg'" ToolTip="No" /></td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div runat="server">
                                        <asp:DataGrid ID="dgTiming" runat="server" Width="100%" DataKeyField="CHECKTYPE"
                                            AutoGenerateColumns="False">
                                            <FooterStyle CssClass="bsFootertd"></FooterStyle>
                                            <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                                            <ItemStyle CssClass="bsnormaltd"></ItemStyle>
                                            <HeaderStyle CssClass="whitetd"></HeaderStyle>
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="Time">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTime" runat="server" Text='<%# Convert.ToDateTime(Eval("CheckTime")).ToString("MM/dd/yyyy hh:mm tt") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtTimeEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CheckTime") %>'>
                                                        </asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Action">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlGridAction" runat="server" Enabled="False">
                                                            <asp:ListItem Value="I">Check In</asp:ListItem>
                                                            <asp:ListItem Value="O">Check Out</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:Label ID="lblAction" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CheckType") %>'
                                                            Visible="False">
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="dllGridActionEdit" runat="server">
                                                            <asp:ListItem Value="I">Check In</asp:ListItem>
                                                            <asp:ListItem Value="O">Check Out</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Location">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlLocationI" runat="server" Width="106px" Enabled="False"
                                                            Height="22px">
                                                            <asp:ListItem Value="6">TDC</asp:ListItem>
                                                            <asp:ListItem Value="2">Home</asp:ListItem>
                                                            <asp:ListItem Value="3">On The Road</asp:ListItem>
                                                            <asp:ListItem Value="4">Raleigh</asp:ListItem>
                                                            <asp:ListItem Value="5">Las Vegas</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:Label ID="lblLocation" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.location") %>'
                                                            Visible="False">
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                            </Columns>
                                            <PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
                                        </asp:DataGrid></div>
                                    <div runat="server">
                                        &nbsp;</div>
                                    <div id="DivConsimpate" runat="server">
                                    </div>
                                    <div id="admin" align="left" runat="server">
                                        Welcome Administrator.
                                        <br>
                                        <br>
                                        To make check in and check out you should select an&nbsp;employee from Accountability
                                        sheet screen.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                    <table id="Tablexxx" cellspacing="5" cellpadding="5" width="300" align="center" border="0">
                                        <tr>
                                            <td style="height: 23px" align="center">
                                            </td>
                                        </tr>
                                    </table>
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
