<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminPage.aspx.cs" Inherits="AdminPage" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Main Page</title>
</head>
<body bottommargin="0" leftmargin="0" rightmargin="0" topmargin="0">
    <form id="form1" runat="server">
        <table height="95%" width="95%">
            <tr>
                <td align="center" style="height: 110px" valign="middle">
                </td>
            </tr>
            <tr>
                <td align="center" valign="middle" style="height: 84px">
<TABLE borderColor=#006600 cellSpacing=0 cellPadding=0 border=1><TR><TD>
<TABLE style="WIDTH: 201px">
    <TR>
    <TD align=left bgcolor="green">
    <asp:Label id="lblCurrentServer" runat="server" Text="Current Server Name" Width="143px" 
        BackColor="Green" BorderWidth="1px" Font-Names="Tahoma" Font-Size="11pt" ForeColor="Yellow"></asp:Label>
    </TD>
    <TD align=left><asp:TextBox id="txtCurrentServer" runat="server" ReadOnly="True"></asp:TextBox></TD>
    <TD align=left bgcolor="green"><asp:Label id="lblNewServerName" runat="server" Text="New Server Name" 
        Width="139px" BackColor="Green" BorderWidth="1px" Font-Names="Tahoma" Font-Size="11pt" 
        ForeColor="Yellow"></asp:Label></TD>
    <TD align=left><asp:TextBox id="txtNewServerName" runat="server"></asp:TextBox></TD></TR>
    <tr><td  colspan="4"><div style="border-right: lightgrey thin solid; border-top: lightgrey thin solid; border-left: lightgrey thin solid; border-bottom: lightgrey thin solid"></div></td></tr>
    <TR><TD align=left bgcolor="green"><asp:Label id="lblCurrentURL" runat="server" Text="Current Site URL" 
        Width="139px" BackColor="Green" BorderWidth="1px" Font-Names="Tahoma" Font-Size="11pt" 
        ForeColor="Yellow"></asp:Label></TD>
    <TD align=left colSpan=3><asp:TextBox id="txtCurrentURL" runat="server" Width="455px" 
        ReadOnly="True"></asp:TextBox></TD></TR>
    <TR><TD align=left bgcolor="green"><asp:Label id="lblNewURL" runat="server" Text="New Site URL" 
        Width="139px" BackColor="Green" BorderWidth="1px" Font-Names="Tahoma" Font-Size="11pt" 
        ForeColor="Yellow"></asp:Label></TD>
    <TD align=left colSpan=3><asp:TextBox id="txtNewURL" runat="server" Width="455px"></asp:TextBox></TD></TR>
    <tr><td  colspan="4"><div style="border-right: lightgrey thin solid; border-top: lightgrey thin solid; border-left: lightgrey thin solid; border-bottom: lightgrey thin solid"></div></td></tr>
    <tr>
        <td align="left" bgcolor="green">
            <asp:Label ID="Label1" runat="server" BackColor="Green" BorderWidth="1px" Font-Names="Tahoma"
                Font-Size="11pt" ForeColor="Yellow" Text="Current Help URL" Width="139px"></asp:Label></td>
        <td align="left" colspan="3">
            <asp:TextBox ID="txtCurrentHelp" runat="server" ReadOnly="True" Width="455px"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="left" bgcolor="green">
            <asp:Label ID="Label2" runat="server" BackColor="Green" BorderWidth="1px" Font-Names="Tahoma"
                Font-Size="11pt" ForeColor="Yellow" Text="New Help URL" Width="139px"></asp:Label></td>
        <td align="left" colspan="3">
            <asp:TextBox ID="txtNewHelp" runat="server" Width="455px"></asp:TextBox></td>
    </tr>
    <tr><td  colspan="4"><div style="border-right: lightgrey thin solid; border-top: lightgrey thin solid; border-left: lightgrey thin solid; border-bottom: lightgrey thin solid"></div></td></tr>
    <tr>
        <td align="left" bgcolor="green">
            <asp:Label ID="lblCurrentFoxConn" runat="server" BackColor="Green" BorderWidth="1px" Font-Names="Tahoma"
                Font-Size="11pt" ForeColor="Yellow" Text="Current FoxPro Connection String" Width="139px"></asp:Label></td>
        <td align="left" colspan="3">
            <asp:TextBox ID="txtCurrentFoxConn" runat="server" Width="455px" ReadOnly="True"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="left" bgcolor="green">
            <asp:Label ID="lblNewFoxConn" runat="server" BackColor="Green" BorderWidth="1px" Font-Names="Tahoma"
                Font-Size="11pt" ForeColor="Yellow" Text="New FoxPro Connection String" Width="139px"></asp:Label></td>
        <td align="left" colspan="3">
            <asp:TextBox ID="txtNewFoxConn" runat="server" Width="455px"></asp:TextBox></td>
    </tr>
    <tr><td  colspan="4"><div style="border-right: lightgrey thin solid; border-top: lightgrey thin solid; border-left: lightgrey thin solid; border-bottom: lightgrey thin solid"></div></td></tr>
    <tr>
        <td align="left" bgcolor="green">
            <asp:Label ID="lblCurrentAUUAUpdateLoc" runat="server" BackColor="Green" BorderWidth="1px" Font-Names="Tahoma"
                Font-Size="11pt" ForeColor="Yellow" Text="Current AUUA Update Location" Width="139px"></asp:Label></td>
        <td align="left" colspan="3">
            <asp:TextBox ID="txtCurrentAUUAUpdateLoc" runat="server" Width="455px" ReadOnly="True"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="left" bgcolor="green">
            <asp:Label ID="lblNewAUUAUpdateLoc" runat="server" BackColor="Green" BorderWidth="1px" Font-Names="Tahoma"
                Font-Size="11pt" ForeColor="Yellow" Text="New AUUA Update Location" Width="139px"></asp:Label></td>
        <td align="left" colspan="3">
            <asp:TextBox ID="txtNewAUUAUpdateLoc" runat="server" Width="455px"></asp:TextBox></td>
    </tr>
    <tr><td  colspan="4"><div style="border-right: lightgrey thin solid; border-top: lightgrey thin solid; border-left: lightgrey thin solid; border-bottom: lightgrey thin solid"></div></td></tr>
    <tr>
        <td align="left" bgcolor="green">
            <asp:Label ID="lblCurrentANPUpdateLoc" runat="server" BackColor="Green" BorderWidth="1px" Font-Names="Tahoma"
                Font-Size="11pt" ForeColor="Yellow" Text="Current ANP Update Location" Width="139px"></asp:Label></td>
        <td align="left" colspan="3">
            <asp:TextBox ID="txtCurrentANPUpdateLoc" runat="server" Width="455px" ReadOnly="True"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="left" bgcolor="green">
            <asp:Label ID="lblNewANPUpdateLoc" runat="server" BackColor="Green" BorderWidth="1px" Font-Names="Tahoma"
                Font-Size="11pt" ForeColor="Yellow" Text="New ANP Update Location" Width="139px"></asp:Label></td>
        <td align="left" colspan="3">
            <asp:TextBox ID="txtNewANPUpdateLoc" runat="server" Width="455px"></asp:TextBox></td>
    </tr>
    <tr><td  colspan="4"><div style="border-right: lightgrey thin solid; border-top: lightgrey thin solid; border-left: lightgrey thin solid; border-bottom: lightgrey thin solid"></div></td></tr>
    <TR>
    <TD align=left bgcolor="green"><asp:Label id="lblCurrentFoxProUN" runat="server" Text="Current FoxPro User Name" Width="143px" 
        BackColor="Green" BorderWidth="1px" Font-Names="Tahoma" Font-Size="11pt" ForeColor="Yellow"></asp:Label></TD>
    <TD align=left><asp:TextBox id="txtCurrentFoxProUN" runat="server" ReadOnly="True"></asp:TextBox></TD>
    <TD align=left bgcolor="green"><asp:Label id="lblNewFoxProUN" runat="server" Text="New FoxPro User Name" Width="139px" 
        BackColor="Green" BorderWidth="1px" Font-Names="Tahoma" Font-Size="11pt" ForeColor="Yellow"></asp:Label></TD>
    <TD align=left><asp:TextBox id="txtNewFoxProUN" runat="server"></asp:TextBox></TD>
    </TR>
    <tr><td  colspan="4"><div style="border-right: lightgrey thin solid; border-top: lightgrey thin solid; border-left: lightgrey thin solid; border-bottom: lightgrey thin solid"></div></td></tr>
    
    <TR>
    <TD align=left bgcolor="green"><asp:Label id="lblNewFoxProPW" runat="server" Text="New FoxPro User Password" Width="143px" 
        BackColor="Green" BorderWidth="1px" Font-Names="Tahoma" Font-Size="11pt" ForeColor="Yellow"></asp:Label></TD>
    <TD align=left><asp:TextBox id="txtNewFoxProPW" runat="server" TextMode="Password" Width="148px"></asp:TextBox></TD>
    <TD align=left bgcolor="green"><asp:Label id="lblConfFoxProPW" runat="server" Text="Confirm New FoxPro User Password" Width="139px" 
        BackColor="Green" BorderWidth="1px" Font-Names="Tahoma" Font-Size="11pt" ForeColor="Yellow"></asp:Label></TD>
    <TD align=left><asp:TextBox id="txtConfFoxProPW" runat="server" TextMode="Password" Width="148px"></asp:TextBox></TD>
    </TR>
    <tr><td  colspan="4"><div style="border-right: lightgrey thin solid; border-top: lightgrey thin solid; border-left: lightgrey thin solid; border-bottom: lightgrey thin solid"></div></td></tr>
    <TR><TD colSpan=4 bgcolor="green"><asp:Label id="lblPassState" runat="server" ForeColor="Yellow"></asp:Label></TD></TR>
    <tr><td  colspan="4"><div style="border-right: lightgrey thin solid; border-top: lightgrey thin solid; border-left: lightgrey thin solid; border-bottom: lightgrey thin solid"></div></td></tr>
    <TR><TD colSpan=4><asp:Button id="btnChange" runat="server" Text="Change Settings" OnClick="btnChange_Click" BorderWidth="1px"></asp:Button></TD></TR><TR><TD colSpan=4 bgcolor="green"><asp:Label id="lblMessage" runat="server" ForeColor="Yellow"></asp:Label></TD></TR></TABLE></TD></TR></TABLE>
                </td>
            </tr>
            <tr>
                <td align="center" height="200" valign="middle">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
