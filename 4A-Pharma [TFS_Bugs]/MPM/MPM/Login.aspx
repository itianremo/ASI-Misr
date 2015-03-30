<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="PharmaLogin" Title="MPMS Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>MPM - Login</title>
    <link rel="SHORTCUT ICON" href="Images/MPMicon.ico">
     <LINK href="Styles/MainStyleSheet.css" type="text/css" rel="stylesheet">
     <script language=javascript>
        function placeFocus()
        {
            if (document.forms.length > 0)
            {
              for (i = 0; i < document.forms[0].length; i++)
                {
                if ((document.forms[0].elements[i].type == "text"))
                {
                document.forms[0].elements[i].focus();
                break;
                }
               }
              }
        }
     </script>
</head>
<body dir="ltr" bgcolor="#dfdfdf" onload="placeFocus();">
    <form id="form1" runat="server" >


<div style="width: 100%;" align="center">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <table id="tbllogin" align="center" background="Images/MPMSLoginScreen1.jpg" cellpadding="0"
        cellspacing="0" style="width: 493px; height: 450px">
        <tr>
            <td align="center" height="20">
            </td>
        </tr>
        <tr>
            <td align="center">
                <div align="center">
                    <table id="Table1" align="center" border="0" cellpadding="0" cellspacing="0" style="width: 423px;
                        height: 157px">
                        <tr>
                            <td style="width: 132px">
                            </td>
                            <td style="width: 132px">
                            </td>
                            <td style="width: 132px">
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 130px">
                            </td>
                            <td valign="bottom">
                                &nbsp;</td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td height="30">
                            </td>
                            <td align="right" valign="top">
                                <asp:label id="lblUserName" runat="server" cssclass="LoginfontStyle">Username:</asp:label>
                            </td>
                            <td align="left" valign="top">
                                <asp:textbox id="txtUsername" runat="server" cssclass="inputs" maxlength="50" tabindex="1"></asp:textbox>
            <asp:requiredfieldvalidator id="rfvUserName" runat="server" controltovalidate="txtUsername"
                display="Dynamic" errormessage="Username is required" validationgroup="vgLogin" CssClass="StyleValidationSummary"></asp:requiredfieldvalidator>
                            </td>
                        </tr>
                        <tr>
                            <td height="30">
                            </td>
                            <td align="right" valign="top">
                                <asp:label id="lblPassword" runat="server" cssclass="LoginfontStyle">Password:</asp:label>
                            </td>
                            <td align="left" valign="top">
                                <asp:textbox id="txtPassword" runat="server" cssclass="inputs" maxlength="20" tabindex="2"
                                    textmode="Password"></asp:textbox>
            <asp:requiredfieldvalidator id="rfvPassword" runat="server" controltovalidate="txtPassword"
                display="Dynamic" errormessage="Password is required" validationgroup="vgLogin" CssClass="StyleValidationSummary"></asp:requiredfieldvalidator>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td align="center">
                            </td>
                        </tr>
                        <tr>
                            <td valign="bottom">
                            </td>
                            <td>
                            </td>
                            <td align="center">
                                <asp:imagebutton id="imgbtnLogin" runat="server" alternatetext="Login" imageurl="~/Images/Login-n.png"
                                    onclick="imgbtnLogin_Click" tabindex="3" ValidationGroup="vgLogin"></asp:imagebutton>&nbsp;
                            </td>
                        </tr>
                       <%-- <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td align="center">
                                <asp:Login ID="Login1" runat="server" TitleText="" DestinationPageUrl="~/index.aspx" LoginButtonImageUrl="~/Images/Login-n.png" LoginButtonType="Image" RememberMeSet="True" DisplayRememberMe="False" FailureAction="RedirectToLoginPage" OnLoggedIn="Login1_LoggedIn" >
                                    <TextBoxStyle CssClass="inputs" />
                                    <LabelStyle CssClass="LoginfontStyle" Wrap="False" HorizontalAlign="Right" VerticalAlign="Top" />
                                    <FailureTextStyle Wrap="False" />
                                </asp:Login>
                            </td>
                        </tr>--%>
                    </table>
                </div>
                                <asp:label id="lblMsg" runat="server" font-bold="True" font-names="Tahoma"
                                    font-size="12px" forecolor="Red"></asp:label></td>
        </tr>
        <tr>
            <td valign="top" align="center">
                <asp:Label ID="lblASICopyright" runat="server" CssClass="MainfontStyle" Font-Bold="False"
                    Text="V1 Build 40,  2010 ASI E, LLC © | All Rights Reserved."></asp:Label></td>
        </tr>
    </table>
</div>
 
 </form>
</body>
</html>

