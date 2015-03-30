
<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.Go.frmRWViewer" CodeFile="frmRWViewerChart.aspx.cs" %>

<%@ Register TagPrefix="cc2" Namespace="Stimulsoft.Report.Web" Assembly="Stimulsoft.Report.Web, Version=2007.1.0.0, Culture=neutral, PublicKeyToken=ebe6666cba19647a" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>PreViewChart</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Acc1.css" type="text/css" rel="stylesheet">
</head>
<body dir="ltr" style="color: Black;">
    <form id="Form1" name=PreViewChart method="post" runat="server">
        <%--<table id="TableHeader" style="width: 300%">
            <tr>
                <td style="height: 10px" width="100%" bgcolor="#dfebf3">
                    <p>
                        <img style="width: 223px" height="56" alt="Report Archiving..." src="images/Report Writer.gif">
                        <span style="font-size: 10pt; color: black">&nbsp;</span>
                    </p>
                </td>
            </tr>
        </table>--%>
        <div align=center>
         <asp:Panel ID="Panel1" runat="server" Height="160px">
         <table id="Tbl1"  border=0 width=400 height=100 cellpadding=0 cellspacing=0 class="FunctionBlock">
            <tr>
                <td style="height: 20px"   align=right class="formslabels">
                    <asp:Label ID="Label1" class="formslabels" runat="server" Text="Width"></asp:Label>&nbsp;&nbsp;
                </td>
                <td style="height: 20px; width: 250px;"   class="formslabels">
                    <asp:TextBox ID="txtWidth" runat="server" CssClass="inputtext" Width="161px">8.27</asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 20px"   align=right class="formslabels">
                    <asp:Label ID="Label2" class="formslabels" runat="server" Text="Height"></asp:Label>&nbsp;&nbsp;</td>
                <td style="height: 20px; "   class="formslabels">
                    <asp:TextBox ID="txtHeight" CssClass="inputtext" runat="server" Width="161px">11.69</asp:TextBox>&nbsp;</td>
            </tr>
            <tr>
                <td  class="formslabels" style="height: 20px"   align=right>
                    <asp:Label ID="Label3" class="formslabels" runat="server" Text="Type"></asp:Label>&nbsp;&nbsp;</td>
                <td style="height: 20px; "   class="formslabels">
                    <asp:RadioButton ID="rbPortrait" runat="server" Checked="True" GroupName="A" Text="Portrait" /><asp:RadioButton
                        ID="rbLandscape" runat="server" GroupName="A" Text="Landscape" /></td>
            </tr>
            <tr>
                <td style="height: 20px"   class="formslabels">
                    </td>
                <td style="height: 20px;"   class="formslabels">
                     &nbsp;</td>
            </tr>
            <tr>
                <td colspan=2 style="height: 20px"   align=center class="formslabels">
                    <asp:Button ID="btnRunReport" runat="server" Text="Modify Chart Size" OnClick="btnRunReport_Click" Width="119px" /></td>
               
            </tr>
             <tr>
                 <td align="center"  colspan="2" style="height: 20px" class="formslabels">
                     <asp:Label ID="lblError" runat="server"  ForeColor="Red"></asp:Label></td>
             </tr>
        </table>
        </asp:Panel>
        </div>
       
        <div align="center" class="FunctionBlock">
            <cc2:StiWebViewer ID="StiWebViewer1" runat="server" ToolBarBackColor="White" PrintDestination="Direct"
                UseCache="True" ViewMode="WholeReport"></cc2:StiWebViewer>
        </div>
        <p align="center">
            &nbsp;</p>
        <p align="center">
            &nbsp;</p>
    </form>

    <script language="javascript" src="../go/include/dlcalendar.js" type="text/javascript"></script>

</body>
</html>
