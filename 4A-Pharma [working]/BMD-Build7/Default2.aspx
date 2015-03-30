<%@ page language="C#" autoeventwireup="true" inherits="Default2, App_Web_default2.aspx.cdcab7d2" maintainScrollPositionOnPostBack="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:DropDownList ID="ddlChartType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlChartType_SelectedIndexChanged">
        <asp:ListItem >Area2D</asp:ListItem>
        <asp:ListItem >Bar2D</asp:ListItem>
        <asp:ListItem >Line2D</asp:ListItem>
    </asp:DropDownList>
    <div runat="server" id="divScoresChart">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></div>
    </form>
</body>
</html>
