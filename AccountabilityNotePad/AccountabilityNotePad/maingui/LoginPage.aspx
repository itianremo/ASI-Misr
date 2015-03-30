<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Login Page</title>
</head>
<body style="vertical-align: middle; text-align: center" bottommargin="0" leftmargin="0" rightmargin="0" topmargin="0">
    <form id="form1" runat="server">
        <table height="95%" width="95%">
            <tr>
                <td align="center" valign="middle" width="100%" style="height: 270px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" style="height: 30%" valign="middle" width="100%">
                    <table border="1" bordercolor="green" cellpadding="0" cellspacing="0">
                        <tr>
                            <td valign=middle align=center>
                                <table style="width: 205px">
                                    <tr>
                                        <td align="left" bgcolor="green" style="width: 10px">
                                            <asp:Label ID="Label1" runat="server" BackColor="Green" BorderColor="Yellow" BorderWidth="1px"
                                                Font-Names="Tahoma" ForeColor="Yellow" Text="User Name" Width="96px" Font-Size="11pt"></asp:Label></td>
                                        <td align="left">
                                            <asp:TextBox ID="txtUserName" runat="server" Width="197px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td align="left" bgcolor="green" style="width: 10px">
                                            <asp:Label ID="Label2" runat="server" BackColor="Green" BorderColor="Yellow" BorderWidth="1px"
                                                Font-Names="Tahoma" ForeColor="Yellow" Text="Password" Width="79px" Font-Size="11pt"></asp:Label></td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="197px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="btnLogin" runat="server" BorderWidth="1px" Font-Names="Verdana" OnClick="btnLogin_Click"
                                                Text="Login" Width="89px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="green" colspan="2">
                                            <asp:Label ID="lblErrMsg" runat="server" BackColor="Green" BorderWidth="1px" Font-Names="Tahoma"
                                                ForeColor="DarkGray" Font-Size="11pt"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="center" bgcolor="green" colspan="2">
                                            <asp:Label ID="Label3" runat="server" BackColor="Green" BorderColor="White" BorderWidth="1px"
                                                Font-Names="Tahoma" ForeColor="Yellow" Text="Accountability Admin. Site    Version 1.0    Build 6.0"
                                                Width="415px" Font-Size="11pt"></asp:Label></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" height="33%" style="height: 270px" valign="middle" width="100%">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
