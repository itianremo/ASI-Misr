<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.Index" CodeFile="Index.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Accountability</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <%--<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />--%>
    <link rel="SHORTCUT ICON" href="Go/images/Go_Triangle_Logo.ico">
<script language="javascript" src="Go/accMethods.js"></script>
<%--<script language="javascript">
    
     var Browser = {  Version: function() 
    {    var version = 999; 
    // we assume a sane browser  
      if (navigator.appVersion.indexOf("MSIE") != -1) 
           // bah, IE again, lets downgrade version number {<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />; }
              version = parseFloat(navigator.appVersion.split("MSIE")[1]); 
              return version;  }}
             // if (Browser.Version() != 8)alert(Browser.Version()+"");
             SetIEVersion(Browser.Version());
             
               </script>--%>
    <script language="javascript">
    
		function _initPage()
		{
			 document.getElementById('TextBoxUserName').focus();
		}
    </script>

    <style type="text/css">
#Form1 #tblGeneral { BORDER-RIGHT: #ffffff 1px solid; BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid; BORDER-BOTTOM: #ffffff 1px solid }
		</style>
</head>
<body bgcolor="#2387C3" onload="_initPage();" >
    <form id="Form1" method="post" runat="server">
        <br/>
        <%--background="Go/images/accountabilityV20_login_bg.jpg"--%>
        <table runat="server" width="782" border="0" align="center" style="width: 782px; height: 601px; background-image:url('Go\images\accountabilityV20_login_bg3.GIF')"
             id="tblGeneral" cellspacing="0"
            cellpadding="0">
            <tr>
                <td style="width: 363px; height: 100px">
                    &nbsp;</td>
                <td style="width: 1px; height: 100px">
                    <%--<p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                    <p>
                    </p>--%>
                </td>
                <td style="width: 381px; height: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 363px; height: 23px">
                </td>
                <td style="width: 1px; height: 23px">
                    <p>
                        &nbsp;</p>
                </td>
                <td style="width: 381px; height: 23px" align="center">
                </td>
            </tr>
            
            
            
            <tr>
                <td style="width: 363px; height: 100px">
                </td>
                <td style="width: 1px; height: 100px">
                    <p>
                        &nbsp;</p>
                </td>
                <td style="width: 381px; height: 100px" align="center">
                    </td>
            </tr>
             
             
             <tr>
                <td style="width: 745px; height: 100px" colspan=3>
                
                <table  border=0>
                <tr>
                <td style="width: 21px; height: 100px">
                </td>
                <td style="width: 643px; height: 100px; text-align:center; vertical-align:top">
                <asp:Label ID="lblCompany" runat="server" Font-Names="Arial" Font-Size="16pt" ForeColor="White">The Steel Network</asp:Label>
                </td>
                <td style="width: 81px; height: 100px" align="center">
                    </td>
            </tr></table>
            
            
                </td>
               
            </tr>
            
            
         
            <%--  <tr>
                <td style="width: 244px" valign="top" align="center" height="10">
                </td>
                <td style="width: 364px" valign="top" align="center" colspan="3" height="10">
                </td>
            </tr>--%>
            
            
            
               <tr valign=top>
                <td style="width: 282px; height: 147px;" valign="bottom" align="left">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                <td style="width: 1px; height: 147px;">
                </td>
                <td style="width: 500px; height: 147px;" valign="top">
                    <table id="tblMain" width="400" border="0" align="left" cellspacing="0" style="width: 361px; vertical-align:top;
                        height: 112px">
                          <tbody>
                            <tr>
                                <td style="width: 20px; height: 7px" valign="middle" align="right">
                                </td>
                                <td style="width: 380px; height: 7px" valign="middle" align="left" colspan="2">
                                    <asp:Label ID="Label3" runat="server" BorderColor="Transparent" ForeColor="White"
                                        Font-Bold="True" Font-Size="10pt" Font-Names="Agency FB" Visible="False" Width="370px">Please check your username and password</asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 100px; height: 7px" align="right" valign="bottom">
                                    <asp:Label ID="Label1" runat="server" Font-Names="Agency FB" Font-Size="12pt" Font-Bold="True"
                                        ForeColor="White" BorderColor="Transparent" Width="120px" ToolTip="User ID">User ID  &nbsp; </asp:Label></td>
                                <td style="width: 2740px; height: 7px" valign="bottom">
                                    <asp:TextBox ID="TextBoxUserName" runat="server" BorderStyle="Solid" BackColor="White"
                                        BorderColor="LightSlateGray" ForeColor="Black" Font-Names="Arial" Width="125px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Font-Size="10pt"
                                        ControlToValidate="TextBoxUserName" ErrorMessage="Required"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 100px; height: 7px" align="right" valign="top">
                                    <asp:Label ID="Label2" runat="server" Font-Names="Agency FB" Font-Size="12pt" Font-Bold="True"
                                        ForeColor="White" BackColor="Transparent" Width="120px" ToolTip="Password">Password</asp:Label></td>
                                <td style="width: 270px; height: 7px" valign="top">
                                    <asp:TextBox ID="TextBoxPassword" runat="server" MaxLength="20" TextMode="Password"
                                        BorderStyle="Solid" BackColor="White" BorderColor="LightSlateGray" Width="125px"
                                        ForeColor="Black" Font-Names="Arial"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Font-Size="10pt"
                                        ControlToValidate="TextBoxPassword" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <%--<asp:Button ID="ButtonLogin" runat="server" Width="75px" CssClass="slectedbutton"
                                        Text="Login" OnClick="Login_Click"></asp:Button>--%>
                                    <asp:ImageButton  ID="ButtonLogin" runat="server" CssClass="slectedbutton"
                                        OnClick="Login_Click" ImageUrl="~/Go/images/Buttons/accountabilityV20_login_bg.jpg" ToolTip="Login"/></td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            
            
            
            
            
            <%--<tr>
                <td style="width: 363px; height: 200px">
                </td>
                <td style="width: 1px; height: 200px">
                    <p>
                        &nbsp;</p>
                </td>
                <td style="width: 381px; height: 200px" align="center">
                    sa</td>
            </tr>--%>
         
            <tr>
                <td style="height: 20px;" valign="top" align="left" colspan="3">
                   <%-- &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label4" runat="server" ForeColor="White" Font-Size="10pt" Font-Names="Arial"
                        Width="344px">GOA2  Build #26</asp:Label> <asp:Label ID="lblCompanyName" runat="server" Width="358px" Font-Names="Arial" Font-Size="10pt"
                        ForeColor="White"> TSNR</asp:Label>&nbsp; &nbsp;&nbsp;--%>
                        <table id="Table1" width="100%" border="0" align="center" cellspacing="0" height=20>
                        <tbody>
                            <tr>
                            <td style="text-align: left; width: 25%;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblBuild" runat="server" ForeColor="White" Font-Size="10pt" Font-Names="Arial"></asp:Label>
                                <asp:Label ID="lblAccess" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="White"></asp:Label></td>
                <td style="text-align: center; width: 25%;">
                    <asp:Label ID="lblRightsReserved" runat="server" ForeColor="White" Font-Size="10pt" Font-Names="Arial">� 2009 ASI | All Rights Reserved</asp:Label></td>
                <td style="text-align: right; width: 25%;">
                    <asp:Label ID="lblDate" runat="server" ForeColor="White" Font-Size="10pt" Font-Names="Arial"></asp:Label>
                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                            </tr>
                            </tbody>
                            </table>
                            </td>
            </tr>
        </table>
        <p>
        </p>
    </form>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</body>
</html>
