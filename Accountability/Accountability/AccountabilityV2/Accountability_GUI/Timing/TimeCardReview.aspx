<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation" %>
<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.Timing.TimeCardReview" EnableSessionState="True"
    CodeFile="TimeCardReview.aspx.cs" ValidateRequest="false" Async="true" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns:o="urn:schemas-microsoft-com:office:office">
<head runat="server">
    <title>Time Card Edit Egypt</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <style type="text/css">.style2 { FONT-SIZE: 12px; FONT-FAMILY: Arial, Helvetica, sans-serif }
	.btn { BORDER-RIGHT: #000066 1px solid; BORDER-TOP: #000066 1px solid; FONT-SIZE: 10px; BORDER-LEFT: #000066 1px solid; COLOR: #000066; BORDER-BOTTOM: #000066 1px solid; FONT-FAMILY: Arial, Helvetica, sans-serif; BACKGROUND-COLOR: #ffffff; br: bold }
		</style>
    <link href="../Acc1.css" type="text/css" rel="stylesheet">

    <script>
		function HI()
		{
			//alert('hi');
			document.getElementById("Button1").click();
		}		
    </script>

    <script language="JavaScript" src="spell.js" type="text/javascript"></script>

</head>
<body dir="ltr" onload="toggleLayer('divPanel','none');drawGrid(document.getElementById('dgEmails'));">
    <form id="Form1" method="post" runat="server">
        <div align="center">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
        <div align="center">
            <table class="FunctionBlock" width="50%">
                <tr>
                    <td class="whitetd" style="height: 25px" colspan="5">
                        Employee Information</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label5" runat="server">Employee</asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlEmployees" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEmployees_SelectedIndexChanged"
                            CssClass="inputtext">
                        </asp:DropDownList></td>
                    <td align="right">
                        <asp:Label ID="lblEmployeeNumber" runat="server" Text="Employee Number"></asp:Label></td>
                    <td colspan="2">
                        <asp:TextBox ID="txtEmployeeNumber" runat="server" Width="83px" CssClass="inputtext"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblDepartment" runat="server" Text="Department"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtDepartment" runat="server" CssClass="inputtext" Width="201px"></asp:TextBox></td>
                    <td align="right">
                        <asp:Label ID="lblManager" runat="server" Text="Manager"></asp:Label></td>
                    <td colspan="2">
                        <asp:TextBox ID="txtManager" runat="server" Width="201px" CssClass="inputtext"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label6" runat="server">Date</asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtDate" runat="server" ToolTip="Click to choose a date" CssClass="inputtext"
                            Width="82px"></asp:TextBox>
                        <img id="imgCal" height="15" alt="Pick a Date" src="../go/images/dlcalendar_1.gif"
                            width="20" name="imgCal" runat="server" />
                        <cc2:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="imgCal"
                            TargetControlID="txtDate" FirstDayOfWeek="Sunday" OnClientDateSelectionChanged="HI"
                            PopupPosition="Right" CssClass="MyCalendar">
                        </cc2:CalendarExtender>
                    </td>
                    <%--                    <td>
                       <dlcalendar callfunction_onselection="HI" firstday="Su" click_element_id="imgCal"
                            input_element_id="txtDate" tool_tip="Click to choose a date">                   
                        <img id="imgCal" height="15" alt="Pick a Date" src="../go/images/dlcalendar_1.gif"
                            width="20" name="imgCal" runat="server" />
                      
                    </td>--%>
                    <td align="right">
                        <asp:Label ID="lblDay" runat="server" Text="Day"></asp:Label></td>
                    <td colspan="2">
                        <asp:TextBox ID="txtDay" runat="server" Width="85px" CssClass="inputtext"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="center" colspan="5">
                        Total Check In Time:
                        <asp:Label ID="lblTotalCheckInTime" runat="server"></asp:Label>
                        Hours</td>
                </tr>
                <tr>
                    <td class="whitetd" style="height: 25px" colspan="5">
                        Time Card Review</td>
                </tr>
                <tr>
                    <td align="center" colspan="5">
                <asp:DataGrid ID="dgTiming" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" Width="60%">
                    <FooterStyle CssClass="bsFootertd" />
                    <AlternatingItemStyle CssClass="bsalternativetd" />
                    <ItemStyle CssClass="bsnormaltd" />
                    <HeaderStyle CssClass="whitetd" />
                    <Columns>
                        <asp:TemplateColumn HeaderText="Check In">
                            <ItemTemplate>
                                <asp:Label ID="lblCheckIn" runat="server" Text='<%# Convert.ToDateTime(Eval("CheckIn")).ToString("hh:mm:ss tt") %>'>
                                                                    </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Check Out">
                            <ItemTemplate>
                                <asp:Label ID="lblCheckOut" runat="server" Text='<%# Eval("CheckOut")==DBNull.Value?"":Convert.ToDateTime(Eval("CheckOut")).ToString("hh:mm:ss tt") %>'>
                                                                    </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                    <PagerStyle CssClass="bsFootertd" Mode="NumericPages" />
                </asp:DataGrid></td>
                </tr>
            </table>
            <table align="center" width="50%">
                <tr>
                    <td align="center" style="height: 21px">
                        <asp:Label ID="lblNote" runat="server" Visible="False" CssClass="formslabels" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
            <%--<asp:Panel ID="pnlReason" runat="server" Width="50%" Visible="False">--%>
                <%--</asp:Panel>--%>
            <table width="100%" align="center" border="0">
                <tr align="center">
                    <td style="height: 26px">
                        <asp:Button ID="Button1" Style="display: none" runat="server" Text="Button" OnClick="Button1_Click">
                        </asp:Button></td>
                </tr>
            </table>
        </div>
    </form>
    <%--<script language="javascript" src="../go/include/dlcalendar.js" type="text/javascript"></script>--%>
</body>
</html>
