<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.Navigation.Bottom" CodeFile="Bottom.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <style type="text/css">
    .style1 {font-weight: bold}
</style>
    <link href="../Acc1.css" type="text/css" rel="stylesheet">

    <script src="../Go/JsAlert.js"></script>
    <%--<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />--%>

</head>
<body onunload="CallLogOut();" dir="ltr">
    <form id="Form1" method="post" runat="server">
        <table width="100%" align="center" cellpadding="0" cellspacing="0" class="bgbottomlinks">
            <tr class="formslabels">
                <td style="text-align: left; width: 25%;">
                    &nbsp; &nbsp;&nbsp;
                    Logged in:
                    <asp:Label ID="lblLoggedUser" runat="server"></asp:Label></td>
                <td style="text-align: center; width: 25%;">
                    <asp:Label ID="lblBuild" runat="server"></asp:Label></td>
                <td style="text-align: center; width: 25%;">
                    <asp:Label ID="lblRightsReserved" runat="server">© 2009 ASI | All Rights Reserved</asp:Label></td>
                <td style="text-align: right; width: 25%;">
                    <asp:Label ID="lblDate" runat="server"></asp:Label>
                    &nbsp; &nbsp;
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
