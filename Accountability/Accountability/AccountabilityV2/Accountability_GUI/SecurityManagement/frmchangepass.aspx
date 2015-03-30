<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.SecurityManagement.frmChangePass"
    CodeFile="frmChangePass.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>frmChangePass</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../Acc1.css" type="text/css" rel="stylesheet">
</head>
<body style="text-align: center;">
    <form id="Form1" method="post" runat="server">
        <br />
        <br />
        <table id="Table1" style="z-index: 101; left: 16px; width: 528px; top: 24px; height: 194px;
            text-align: center;" cellspacing="1" cellpadding="1" width="528" border="0" class="FunctionBlock">
            <tr>
                <td class="headertd" colspan="3">
                    Change Password</td>
            </tr>
            <tr>
                <td style="width: 206px" class="formslabels" align="right">
                    <asp:Label ID="Label1" runat="server">Old Password</asp:Label></td>
                <td>
                    <asp:TextBox ID="tbOldPass" runat="server" TextMode="Password"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbOldPass"
                        ErrorMessage="Old password required"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 206px" class="formslabels" align="right">
                    <asp:Label ID="Label2" runat="server">New Password</asp:Label></td>
                <td>
                    <asp:TextBox ID="tbNewPass" runat="server" TextMode="Password"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbNewPass"
                        ErrorMessage="New password required"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 206px" class="formslabels" align="right">
                    <asp:Label ID="Label3" runat="server">Confirm New Password</asp:Label></td>
                <td>
                    <asp:TextBox ID="tbConfirm" runat="server" TextMode="Password"></asp:TextBox></td>
                <td>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Passwords do not match"
                        ControlToCompare="tbNewPass" ControlToValidate="tbConfirm" Font-Size="10pt" Width="148px"></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbConfirm"
                        ErrorMessage="Confirm password required"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 206px; height: 18px">
                </td>
                <td style="height: 18px">
                    &nbsp;
                    <asp:Button ID="cbOK" runat="server" Text="Ok" Width="70px" CssClass="slectedbutton"
                        OnClick="cbOK_Click" Height="20px" Font-Underline="True"></asp:Button>&nbsp;&nbsp;
                    <asp:HyperLink ID="HyperLink2" runat="server" Width="70px" CssClass="slectedbutton"
                        NavigateUrl="../Navigation/ContentPage.aspx?uc=Go/ctlEmployeeMain.ascx" Height="20px">Cancel</asp:HyperLink></td>
                <td style="height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 206px" align="left">
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 206px">
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" Width="40px" Font-Size="12px" NavigateUrl="../UserModules.aspx?home=yes" Font-Bold="True" ForeColor="White" Visible="False">Home</asp:HyperLink>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
