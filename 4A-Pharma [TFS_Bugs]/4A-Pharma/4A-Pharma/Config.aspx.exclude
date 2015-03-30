<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Config.aspx.cs" Inherits="Config" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script language=javascript>
        function placeFocus()
        {
            if (document.forms.length > 0)
            {
                for (i = 0; i < document.forms[0].length; i++)
                {
                    if ((document.forms[0].elements[i].name == "txtUsername"))
                    {
                        document.forms[0].elements[i].focus();
                        break;
                    }
                }
            }
        }
     </script>
</head>
<body onload="placeFocus();">
    <form id="form1" runat="server">
    <div>
        <table align="center" style="width: 80%">
            <tr>
                <td style="width: 100px">
                </td>
                <td align="center" style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td align="center" style="text-align: center;"><asp:Panel ID="pnlConf" runat="server" Width="500px" Visible="False">
                    <table id="Table2" align="center" border="0" cellpadding="0" cellspacing="0" style="width: 423px;
                            height: 157px">
                        <tr>
                            <td align="right" valign="top">
                                <asp:Label ID="Label1" runat="server" CssClass="LoginfontStyle">Username:</asp:Label>
                            </td>
                            <td align="left" valign="top">
                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername"
                                    CssClass="StyleValidationSummary" Display="Dynamic" ErrorMessage="Username is required"
                                    ValidationGroup="vgLogin"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                                <asp:Label ID="Label2" runat="server" CssClass="LoginfontStyle">Password:</asp:Label>
                            </td>
                            <td align="left" valign="top">
                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                                    CssClass="StyleValidationSummary" Display="Dynamic" ErrorMessage="Password is required"
                                    ValidationGroup="vgLogin"></asp:RequiredFieldValidator>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="center">
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="center">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="12px"
                        ForeColor="Red"></asp:Label></asp:Panel>
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td align="center" style="text-align: center;">
                    <asp:Panel ID="pnlLogin" runat="server" Width="500px">
                        <table id="Table1" align="center" border="0" cellpadding="0" cellspacing="0" style="width: 423px;
                            height: 157px">
                            <tr>
                                <td align="right" valign="top">
                                    <asp:Label ID="lblUserName" runat="server" CssClass="LoginfontStyle">Username:</asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtUsername" runat="server" CssClass="inputs" MaxLength="50" TabIndex="1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUsername"
                                        CssClass="StyleValidationSummary" Display="Dynamic" ErrorMessage="Username is required"
                                        ValidationGroup="vgLogin"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <asp:Label ID="lblPassword" runat="server" CssClass="LoginfontStyle">Password:</asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="inputs" MaxLength="20" TabIndex="2"
                                        TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                                        CssClass="StyleValidationSummary" Display="Dynamic" ErrorMessage="Password is required"
                                        ValidationGroup="vgLogin"></asp:RequiredFieldValidator>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="center">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="center">
                                    <asp:ImageButton ID="imgbtnLogin" runat="server" AlternateText="Login" ImageUrl="~/Images/Login-n.png"
                                        OnClick="imgbtnLogin_Click" TabIndex="3" ValidationGroup="vgLogin" />&nbsp;
                                </td>
                            </tr>
                        </table>
                        <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="12px"
                            ForeColor="Red"></asp:Label></asp:Panel>
                </td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
