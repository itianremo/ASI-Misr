<%@ Reference Control="~/go/accountability.ascx" %>

<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.Go.frmRWViewer" CodeFile="frmRWViewer.aspx.cs" %>

<%@ Register TagPrefix="cc2" Namespace="Stimulsoft.Report.Web" Assembly="Stimulsoft.Report.Web, Version=2007.1.0.0, Culture=neutral, PublicKeyToken=ebe6666cba19647a" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>ReportViewer</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../Acc1.css" type="text/css" rel="stylesheet">
</head>
<body dir="ltr" style="color: Black;">
    <form id="Form1" method="post" runat="server">
        <table id="TableHeader" style="width: 100%">
            <tr>
                <td style="height: 60px" width="100%" bgcolor="#dfebf3">
                 <table id="TableLayout" width=100% height= 82px; >
         <tr height=56>
            <td style="height: 82px; width:100%;" dir="ltr" >
            <table width="100%" border="0" cellpadding="0" style="height=82px" cellspacing="0" bgcolor="c3d9a9"  id="Toptable">
                                <tr>
                                    <td class="logobar_BG" >
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td  width="77" height="82" rowspan="2" valign="top" >
                                                    
                                                        <img src="../go/images/NewRWLogo.JPG" width="100" height="82" />
                                                </td>
                                                <td width="900" height="22">
                                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="lblPageTitle"
                                                            runat="server" Text="Report Run" CssClass="AppTitle"></asp:Label></td>
                                                <td valign="middle" width="40" align="right" height="22">
                                                    </td>
                                                <td valign="middle" width="60" align="right" height="22">
                                                    <table border="0" cellpadding="0" cellspacing="5" align="right" style="height=22">
                                                        <tr>
                                                            <td width="28">
                                                                &nbsp;</td>
                                                            <td width="28">
                                                                <img ID="ibtnLogOff" runat="server" src="~/Go/images/Close_n.jpg"
                                                                    Width="28" Height="17" class="HandOverCursor" onclick="javascript:window.open('','_parent',''); window.close()" /></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr  >
                                                <td colspan="3" align="left"  valign=middle>
                                                     <table  cellspacing="0" cellpadding="0" width=100%  style="vertical-align:middle">
                                                        <tr style="height: 36px; width:100%" valign=middle>
                                                            
                                                               <td style="height: 36px;width:150px;vertical-align:bottom"> <img ID="Img1" runat="server" src="../Go/images/Back_n.jpg"
                                                                    Width="150" Height="36" class="HandOverCursor" onclick="javascript: var origWin = window.opener ;if (origWin != null) {origWin.focus() ;}window.close();return false;"/>
                                                                </td><td>&nbsp;</td>
                                                         
                                                        </tr>
                                                    </table>
                                                 </td>
                                            </tr>
                                        </table>
                                        </td>
                                </tr>
                                
                            </table>
            
            </td>
        </tr>
        </table>
                    <%--<p>
                        <img style="width: 223px" height="56" alt="Report Archiving..." src="images/Report Writer.gif">
                        <span style="font-size: 10pt; color: black">&nbsp;</span>
                    </p>--%>
                </td>
            </tr>
        </table>
          
        <%--        <p align="left">--%>
        <asp:Panel ID="Panel1" runat="server" Height="160px">
            <table id="Tbl1" style="width: 544px; height: 168px" cellspacing="2" cellpadding="2"
                align="center" border="0" class="FunctionBlock">
               
                <tr>
                    <th class="headertd" style="border-top-width: 1px; border-left-width: 1px; border-left-color: navy;
                        border-bottom-width: 1px; border-bottom-color: navy; border-top-color: navy;
                        height: 11px; text-align: left; border-right-width: 1px; border-right-color: navy"
                        align="right" colspan="3">
                        Report Parameters</th>
                </tr>
                <tr>
                    <td class="formslabels" align="left">
                        From&nbsp;
                        <asp:TextBox ID="TextBoxFrom" runat="server" Width="99px" CssClass="inputtext"></asp:TextBox>&nbsp;
                       
                        <dlcalendar
                            firstday="Su" input_element_id="TextBoxFrom" click_element_id="imgCal1" tool_tip="Pick a Date"></dlcalendar><img
                                id="imgCal1" alt="Pick a Date" src="../go/images/dlcalendar_1.gif" name="imgCal"/></td>
                    <td class="formslabels" align="left">
                        To
                        <asp:TextBox ID="TextBoxTo" runat="server" Width="99px" CssClass="inputtext"></asp:TextBox>&nbsp;<dlcalendar
                            firstday="Su" input_element_id="TextBoxTo" click_element_id="imgCal2" tool_tip="Pick a Date"></dlcalendar><img
                                id="imgCal2" alt="Pick a Date" src="../go/images/dlcalendar_1.gif"/></td>
                    <td align="left">
                    </td>
                </tr>
                <tr>
                    <td style="width: 225px; height: 97px; text-align: left" valign="top" align="right">
                        <asp:RadioButtonList ID="RadioButtonListEmp" runat="server" Height="40px" Width="88px"
                            CssClass="formslabels" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonListEmp_SelectedIndexChanged">
                            <asp:ListItem Value="2">Teams</asp:ListItem>
                            <asp:ListItem Value="1" Selected="True">Employee</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RadioButtonList ID="RadioButtonListNotes" runat="server" Width="165px" CssClass="formslabels"
                            RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Selected="True">Notes</asp:ListItem>
                            <asp:ListItem Value="2">No Notes</asp:ListItem>
                        </asp:RadioButtonList></td>
                    <td style="width: 163px; height: 97px" valign="top" align="left">
                        <asp:DropDownList ID="DropDownListTeams" runat="server" Height="152px" CssClass="inputtext"
                            AutoPostBack="True" DataTextField="TeamName" DataValueField="TeamID" DataSource="<%# dsTeams1 %>"
                            Enabled="False" OnSelectedIndexChanged="DropDownListTeams_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="DrpDwnTskEmplyees" runat="server" CssClass="inputtext">
                        </asp:DropDownList></td>
                    <td style="width: 176px; height: 97px" valign="top" align="left">
                        <asp:DropDownList ID="DropDownListEmp" runat="server" CssClass="inputtext" DataTextField="Fullname"
                            DataValueField="ContactID" DataSource="<%# dsEmployee1 %>" Enabled="False">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="text-align: center" colspan="3">
                        <%--<asp:Button ID="ButtonTskSumm" runat="server" Text="Get Report" OnClick="ButtonTskSumm_Click">
                            </asp:Button>--%>
                        <asp:ImageButton ID="ButtonTskSumm" runat="server" OnClick="ButtonTskSumm_Click"
                            ImageUrl="~/Go/images/Buttons/GetReport_n.jpg" />
                    </td>
                    <%--  <td style="width: 163px; height: 44px" valign="top" align="left">
                        </td>
                        <td style="width: 176px; height: 44px" valign="top" align="left">
                        </td>--%>
                </tr>
            </table>
        </asp:Panel>
        <%--        </p>--%>
        <%--        <p align="left">--%>
        <asp:Panel ID="Panel2" runat="server" Height="56px">
            <table id="Tbl" cellspacing="1" cellpadding="1" width="300" align="center" border="0"
                class="FunctionBlock">
                <tr>
                    <td class="headertd" style="height: 24px" colspan="2">
                        Report Parameters</td>
                </tr>
                <tr>
                    <td class="formslabels" style="height: 24px">
                        <asp:Label ID="Label1" runat="server">Employee</asp:Label></td>
                    <td style="height: 24px">
                        <asp:DropDownList ID="DrpDwnMnagedEmp" runat="server" CssClass="inputtext">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="formslabels" style="height: 23px">
                        <asp:Label ID="Label2" runat="server">Date</asp:Label></td>
                    <td style="height: 23px">
                        <asp:TextBox ID="TextBoxCalender" runat="server" Width="84px" CssClass="inputtext"></asp:TextBox>&nbsp;<dlcalendar
                            firstday="Su" input_element_id="TextBoxCalender" click_element_id="imgCal3" tool_tip="Pick a Date"></dlcalendar><img
                                id="imgCal3" alt="Pick a Date" src="../go/images/dlcalendar_1.gif"></td>
                </tr>
                <tr>
                    <td class="formslabels">
                        <asp:Label ID="Label3" runat="server">View Mode</asp:Label></td>
                    <td>
                        <select class="inputtext" id="lstViewMode" onchange="viewMode =  document.getElementById('lstViewMode').value;bindEmpInfo(document.getElementById('lstEmployee').options[document.getElementById('lstEmployee').selectedIndex].value);"
                            name="lstViewMode" runat="server">
                            <option value="10" selected>General</option>
                            <option value="30">Project</option>
                            <option value="40">Tasks Only</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td class="formslabels">
                        <asp:Label ID="Label4" runat="server">View Days Off</asp:Label></td>
                    <td>
                        <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox></td>
                </tr>
                <tr>
                    <td class="formslabels">
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center;" colspan="2">
                        <%--<asp:Button ID="ButtonGetRep" runat="server" Text="Get Report" OnClick="ButtonGetRep_Click">
                            </asp:Button>--%>
                        <asp:ImageButton ID="ButtonGetRep" runat="server" OnClick="ButtonGetRep_Click" ImageUrl="~/Go/images/Buttons/GetReport_n.jpg" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--        </p>--%>
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
    <span class="style7">

        <script language="javascript" src="../go/include/buttons.js" type="text/javascript"></script>

    </span>

</body>
</html>
