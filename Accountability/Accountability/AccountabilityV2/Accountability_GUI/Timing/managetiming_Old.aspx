<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation" %>

<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.Timing.ManageTiming_Old" EnableSessionState="True"
    CodeFile="ManageTiming_Old.aspx.cs" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns:o="urn:schemas-microsoft-com:office:office">
<head runat="server">
    <title>Manage Timing</title>
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

</head>
<body dir="ltr">
    <form id="Form1" method="post" runat="server">
        <div align="center">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
        <div align="center">
            <table class="FunctionBlock" width="50%">
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server">Employee</asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlEmployees" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEmployees_SelectedIndexChanged">
                        </asp:DropDownList></td>
                    <td>
                        <asp:Label ID="lblEmployeeNumber" runat="server" Text="Employee Number"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtEmployeeNumber" runat="server" Width="83px"></asp:TextBox></td>
                    <td>
                        <asp:DropDownList ID="ddlExemp" runat="server">
                            <asp:ListItem Value="0">Non Exempt</asp:ListItem>
                            <asp:ListItem Value="1">Exempt</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDepartment" runat="server" Text="Department"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="lblManager" runat="server" Text="Manager"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlManager" runat="server">
                        </asp:DropDownList></td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="height: 62px">
                        <asp:Label ID="Label6" runat="server">Date</asp:Label></td>
                    <td style="height: 62px">
                        <asp:TextBox ID="txtDate" runat="server" ToolTip="Click to choose a date"></asp:TextBox>
                        <cc2:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="txtDate"
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
                    <td style="height: 62px">
                        <asp:Label ID="lblDay" runat="server" Text="Day"></asp:Label></td>
                    <td style="height: 62px">
                        <asp:TextBox ID="txtDay" runat="server" Width="85px"></asp:TextBox></td>
                    <td style="height: 62px">
                        <asp:Label ID="lblShift" runat="server" Text="Shift"></asp:Label>
                        <asp:DropDownList ID="ddlShift" runat="server">
                        </asp:DropDownList></td>
                </tr>
            </table>
            &nbsp;&nbsp;<table align="center" class="FunctionBlock" width="50%">
                <tr>
                    <td class="headertd" style="height: 25px">
                        Time Card Edit</td>
                </tr>
                <tr>
                    <td valign="top" width="80%">
                        <!--- our div----->
                        <div id="divEmail" align="center">
                            <table style="text-align: center" width="100%">
                                <tbody style="text-align: center" valign="top">
                                    <tr>
                                        <td style="width: 80%; height: 26px; text-align: left">
                                            <asp:Button ID="tnAddRecord" runat="server" Text="Add Record" OnClick="tnAddRecord_Click">
                                            </asp:Button></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 80%; text-align: left; height: 171px;">
                                            <asp:DataGrid ID="dgTiming" runat="server" DataKeyField="CHECKTYPE" Width="100%"
                                                AutoGenerateColumns="False" DESIGNTIMEDRAGDROP="1187">
                                                <FooterStyle CssClass="bsFootertd"></FooterStyle>
                                                <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                                                <ItemStyle CssClass="bsnormaltd"></ItemStyle>
                                                <HeaderStyle CssClass="whitetd"></HeaderStyle>
                                                <Columns>
                                                    <asp:TemplateColumn HeaderText="Time">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTime" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.orgCHECKTIME") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtTimeEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.orgCHECKTIME") %>'>
                                                            </asp:TextBox>
                                                        </EditItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Action">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddlGridAction" runat="server" Enabled="False">
                                                                <asp:ListItem Value="I">Check In</asp:ListItem>
                                                                <asp:ListItem Value="O">Check Out</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Label ID="lblAction" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CheckType") %>'
                                                                Visible="False">
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="dllGridActionEdit" runat="server">
                                                                <asp:ListItem Value="I">Check In</asp:ListItem>
                                                                <asp:ListItem Value="O">Check Out</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Location">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddlLocationI" runat="server" Width="103px" Enabled="False"
                                                                Height="22px">
                                                                <asp:ListItem Value="6">TDC</asp:ListItem>
                                                                <asp:ListItem Value="2">Home</asp:ListItem>
                                                                <asp:ListItem Value="3">On The Road</asp:ListItem>
                                                                <asp:ListItem Value="4">Raleigh</asp:ListItem>
                                                                <asp:ListItem Value="5">Las Vegas</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Label ID="lblLocationI" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.location") %>'
                                                                Visible="False">
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="ddlLocationE" runat="server" Width="105px" Height="22px">
                                                                <asp:ListItem Value="6">TDC</asp:ListItem>
                                                                <asp:ListItem Value="2">Home</asp:ListItem>
                                                                <asp:ListItem Value="3">On The Road</asp:ListItem>
                                                                <asp:ListItem Value="4">Raleigh</asp:ListItem>
                                                                <asp:ListItem Value="5">Las Vegas</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Label ID="lblLocationE" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.location") %>'
                                                                Visible="False">
                                                            </asp:Label>
                                                        </EditItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel"
                                                        EditText="Edit"></asp:EditCommandColumn>
                                                    <asp:TemplateColumn>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" Text="Delete" CommandName="Delete"
                                                                CausesValidation="false"></asp:LinkButton>
                                                            <asp:Label ID="lblSerial" runat="server" Visible="False">0</asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </Columns>
                                                <PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
                                            </asp:DataGrid></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
            <table align="center" width="50%">
                <tr>
                    <td>
                        <asp:Label ID="lblNote" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="Panel1" runat="server" Width="50%" Visible="False">
                <table id="Table1" class="FunctionBlock">
                    <tr>
                        <td style="height: 25px">
                            <asp:Label ID="Label2" runat="server">Time</asp:Label></td>
                        <td style="width: 159px; height: 25px">
                            <asp:TextBox ID="txtAddTime" runat="server"></asp:TextBox></td>
                        <td style="height: 25px">
                            <asp:DropDownList ID="ddlAMPM" runat="server">
                                <asp:ListItem Value="AM">AM</asp:ListItem>
                                <asp:ListItem Value="PM">PM</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server">Action</asp:Label></td>
                        <td style="width: 159px">
                            <asp:DropDownList ID="ddlAddAction" runat="server">
                                <asp:ListItem Value="I">Check In</asp:ListItem>
                                <asp:ListItem Value="O">Check Out</asp:ListItem>
                            </asp:DropDownList></td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblLocation" runat="server">Location</asp:Label></td>
                        <td style="width: 159px">
                            <asp:DropDownList ID="ddLocation" runat="server">
                                <asp:ListItem Value="6">TDC</asp:ListItem>
                                <asp:ListItem Value="2">Home</asp:ListItem>
                                <asp:ListItem Value="3">On The Road</asp:ListItem>
                                <asp:ListItem Value="4">Raleigh</asp:ListItem>
                                <asp:ListItem Value="5">Las Vegas</asp:ListItem>
                            </asp:DropDownList></td>
                        <td>
                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="../Go/images/imgsave.gif">
                            </asp:ImageButton></td>
                    </tr>
                </table>
            </asp:Panel>
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
