<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Redirect.aspx.cs" Inherits="Redirect" Title=":: Starting Module Selector ::" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>MPMS Login</title>
    <link rel="SHORTCUT ICON" href="favicon.ico">
    <LINK href="Styles/MainStyleSheet.css" type="text/css" rel="stylesheet">
</head>
<body dir="ltr" bgcolor="#dfdfdf">
    <form id="form1" runat="server" >

<div style="width: 100%;" align="center">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <table id="tbllogin" align="center" background="Images/MainLogin.png" cellpadding="0"
        cellspacing="0" style="width: 493px; height: 450px">
        <tr>
            <td align="center" height="20">
            </td>
        </tr>
        <tr>
            <td>
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
                                </td>
                            <td align="left" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td height="30">
                            <asp:imagebutton id="btnFMT" runat="server" alternatetext="Login" imageurl="~/Images/FMTmodule-n.png"
                                tabindex="3" ValidationGroup="vgLogin" PostBackUrl="~/FMT/FMTPlanning.aspx"/>
                            </td>
                            <td align="right" valign="top">
                            </td>
                            <td align="center" valign="top">
                            <asp:imagebutton id="btnBMD" runat="server" alternatetext="Login" imageurl="~/Images/BMDmodule-n.png"
                                tabindex="3" ValidationGroup="vgLogin" PostBackUrl="~/index.aspx"/>
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
                                &nbsp;</td>
                        </tr>
                      
                    </table>
                </div>
                                </td>
        </tr>
        <tr>
            <td valign="top" align="center">
                </td>
        </tr>
    </table>
</div>
 
 </form>
</body>
</html>


