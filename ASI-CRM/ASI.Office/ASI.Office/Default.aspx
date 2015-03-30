<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:WebPartManager ID="WebPartManager1" runat="server">
            <Personalization Enabled="False" />
        </asp:WebPartManager>
        <asp:WebPartZone ID="WebPartZone1" runat="server" HeaderText="Zone 1" PartTitleStyle-CssClass="TitleBar" PartChromeType="TitleOnly">
            <ZoneTemplate>
                <asp:Button ID="Button1" runat="server" Text="Button" />
            </ZoneTemplate>
        </asp:WebPartZone>
        <asp:ConnectionsZone ID="ConnectionsZone1" runat="server" BackColor="#F7F6F3" BorderColor="#CCCCCC"
            BorderWidth="1px" Font-Names="Verdana" Padding="6">
            <FooterStyle BackColor="#E2DED6" HorizontalAlign="Right" />
            <VerbStyle Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" />
            <InstructionTextStyle Font-Size="0.8em" ForeColor="#333333" />
            <EditUIStyle Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" />
            <LabelStyle Font-Size="0.8em" ForeColor="#333333" />
            <HeaderStyle BackColor="#E2DED6" Font-Bold="True" Font-Size="0.8em" ForeColor="#333333" />
            <HeaderVerbStyle Font-Bold="False" Font-Size="0.8em" Font-Underline="False" ForeColor="#333333" />
        </asp:ConnectionsZone>
    </div>
    </form>
</body>
</html>
