<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls, Version=1.0.2.226, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>

<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.Navigation.HelpDetails" CodeFile="HelpDetails.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>HelpDetails</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">

    <script language="javascript" src="treeview.js" type="text/javascript"></script>

    <script>
		
    </script>

    <link href="CSSHelp.css" type="text/css" rel="stylesheet">
    <link href="..\Acc1.css" type="text/css" rel="stylesheet">
</head>
<body >
    <form id="Form1" method="post" runat="server">
        <table id="Table1" height="100%" cellspacing="1" cellpadding="1" align="center" border="0"
            width="100%" class="FunctionBlock">
            <tr>
                <td style="width: 247px" valign="middle" width="247" colspan="2" height="33" class="headertd">
                    <p align="left">
                        Accountability Help</p>
                </td>
            </tr>
            <tr>
                <td valign="top" width="40%" colspan="1" height="100%" class="FunctionBlock">
                    <table id="Table3" height="100%" cellspacing="0" cellpadding="1" width="100%" border="0" class="FunctionBlock">
                        <tr>
                            <td valign="top" align="left" colspan="3" height="100%">
                                <p>
                                    &nbsp;</p>
                                <div id="testTable" runat="server" style="color:#000000;">
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top" align="left" width="55%" bgcolor="#ffffff" class="helpmaintd">
                    <table id="Table4" height="100%" cellspacing="0" cellpadding="0" width="100%" class="functionblock">
                        <tr>
                            <td valign="top">
                                <br>
                                <br>
                                <h4>
                                    &nbsp;&nbsp;<asp:Label ID="LabelTitle" runat="server"></asp:Label></h4>
                                <br>
                                <div id="div1" runat="server">
                                    &nbsp;&nbsp;
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="center">
                                <div id="imgDiv">
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
