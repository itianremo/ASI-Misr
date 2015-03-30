<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.Go.EmployeeMainSearch" CodeFile="EmployeeMainSearch.ascx.cs" %>
<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation" %>
<link href="../Acc1.css" type="text/css" rel="stylesheet">
<style type="text/css">.btn { BORDER-RIGHT: #000066 1px solid; BORDER-TOP: #000066 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 10px; BORDER-LEFT: #000066 1px solid; COLOR: #000066; BORDER-BOTTOM: #000066 1px solid; FONT-FAMILY: Arial, Helvetica, sans-serif; BACKGROUND-COLOR: #ffffff }
	.errtable { BORDER-RIGHT: #cccc00 1px solid; BORDER-TOP: #cccc00 1px solid; BORDER-LEFT: #cccc00 1px solid; BORDER-BOTTOM: #cccc00 1px solid }
	.trBorder { BORDER-RIGHT: #003366 1px solid; BORDER-TOP: #003366 1px solid; BORDER-LEFT: #003366 1px solid; BORDER-BOTTOM: #003366 1px solid }
	.blueText { FONT-SIZE: xx-small; COLOR: #003366; FONT-FAMILY: Arial, Helvetica, sans-serif }
	.btn1 { BORDER-RIGHT: #000066 1px solid; BORDER-TOP: #000066 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 12px; BORDER-LEFT: #000066 1px solid; COLOR: #000066; BORDER-BOTTOM: #000066 1px solid; FONT-FAMILY: Arial, Helvetica, sans-serif; BACKGROUND-COLOR: #ffffff }
	.style17 { FONT-SIZE: 10px; COLOR: #003366 }
</style>

<script type="text/JavaScript">
<!--
function openWindow(url)
{
	if ( wndHandle && wndHandle.open && wndHandle.closed)
		wndHandle.close();
	wndHandle=open('','window','width=450,height=500,top=0,left=200,status=yes,scrollbars=yes');
	wndHandle.location.href = url;
	if (wndHandle.opener == null) wndHandle.opener = self;		
}
function changeImg()
{
	document.getElementById('imgEmp').src = document.getElementById('_ctl0_fileEmp').value;
}
//-->
</script>

<table width="100%" align="center" border="0">
    <tr>
        <td style="height: 848px">
            <asp:Table ID="tblErr" BorderWidth="0px" CellPadding="2" CellSpacing="0" CssClass="errtable"
                Font-Names="Arial" Font-Size="9pt" runat="server" Visible="False" Width="453px"
                HorizontalAlign="Center">
                <asp:TableRow VerticalAlign="Top">
                    <asp:TableCell BackColor="#FFFFC0" BorderColor="White" Text="&lt;img src=&quot;../go/images/alrt_l.gif&quot; /&gt;"></asp:TableCell>
                    <asp:TableCell BackColor="#FFFFC0"></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <table cellspacing="0" cellpadding="0" width="600" align="center" class="FunctionBlock">
                <tr>
                    <td class="headertd" valign="middle" align="center" colspan="3" style="height: 23px">
                        Employee's Information
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellspacing="3" cellpadding="1" width="600" align="center"
                            border="0">
                            <tr>
                                <td nowrap align="right" width="136">
                                    <span class="formslabels">Employee number </span>
                                </td>
                                <td align="left" colspan="5">
                                    <asp:TextBox class="blueText" ID="txtCode" CssClass="inputtext" runat="server" Width="130px"
                                        MaxLength="6"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:RangeValidator ID="rvEmployeeCode" runat="server" Font-Size="XX-Small" ControlToValidate="txtCode"
                                        ErrorMessage="Enter digits only" MaximumValue="999999" MinimumValue="1" Type="Integer"
                                        Display="Dynamic"></asp:RangeValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label class="formslabels" ID="Label4" CssClass="formslabels" Font-Names="Arial"
                                        Font-Size="9pt" runat="server">Name</asp:Label></td>
                                <td colspan="5" height="20">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td>
                                                <asp:TextBox class="blueText" ID="txtFName" CssClass="inputtext" runat="server" Width="130px"
                                                    DESIGNTIMEDRAGDROP="20"></asp:TextBox>&nbsp;
                                                <asp:TextBox class="blueText" ID="txtMName" CssClass="inputtext" runat="server" Width="130px"></asp:TextBox>&nbsp;
                                                <asp:TextBox class="blueText" ID="txtLName" CssClass="inputtext" runat="server" Width="130px"></asp:TextBox></td>
                                            <td align="right">
                                                <asp:LinkButton ID="lnkShowPhoto" Font-Names="Arial" Font-Size="7pt" runat="server"
                                                    Enabled="False"> Photo
                                                </asp:LinkButton></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label3" CssClass="formslabels" Font-Names="Arial" Font-Size="9pt"
                                        runat="server">Department</asp:Label></td>
                                <td align="left" colspan="5">
                                    <table cellspacing="0" cellpadding="0" width="480" border="0">
                                        <tr>
                                            <td align="left" width="200">
                                                <asp:DropDownList class="blueText" ID="lstCompElements" CssClass="inputtext" runat="server"
                                                    Width="200px" DataSource="<%# dsCompElements %>" DataValueField="CompElmentID"
                                                    DataTextField="CEName">
                                                </asp:DropDownList></td>
                                            <td width="66">
                                                <div align="right">
                                                    <span class="formslabels">Job title</span>
                                                </div>
                                            </td>
                                            <td width="214">
                                                <asp:DropDownList class="blueText" ID="lstJobTitles" CssClass="inputtext" runat="server"
                                                    Width="200px" DataSource="<%# dsJobTitles %>" DataValueField="JobTitleID" DataTextField="JobName">
                                                </asp:DropDownList></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" height="18">
                                    <asp:Label ID="Label2" CssClass="formslabels" Font-Names="Arial" Font-Size="9pt"
                                        runat="server" Visible="False">User Name</asp:Label></td>
                                <td align="left" colspan="5">
                                    <asp:DropDownList class="blueText" ID="lstUserName" CssClass="inputtext" runat="server"
                                        DataSource="<%# dsUser %>" DataValueField="UserID" DataTextField="UserName" Visible="False">
                                    </asp:DropDownList>&nbsp;
                                    <asp:DropDownList ID="lstUnassignedUsers" CssClass="inputtext" runat="server" Visible="False"
                                        DataSource="<%# dsUnassignedUsers %>" DataValueField="UserID" DataTextField="UserName">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td valign="bottom" align="right" rowspan="2" style="height: 47px">
                                    <asp:Label ID="lblAddress" CssClass="formslabels" Font-Names="Arial" Font-Size="9pt"
                                        runat="server">Address(es)</asp:Label></td>
                                <td style="height: 21px" valign="bottom" align="left" width="10">
                                    <asp:Label ID="lblCountry" CssClass="smalllabels" runat="server">Country</asp:Label></td>
                                <td valign="bottom" align="left" width="10">
                                    <asp:Label ID="lblState" CssClass="smalllabels" runat="server">State</asp:Label></td>
                                <td style="height: 21px" valign="bottom" align="left" width="10">
                                    <asp:Label ID="lblCity" CssClass="smalllabels" runat="server">City</asp:Label></td>
                                <td style="height: 21px" valign="bottom" align="left">
                                    <asp:Label ID="lblZIP" CssClass="smalllabels" runat="server">ZIP</asp:Label></td>
                                <td valign="bottom" align="left" width="30%" rowspan="2" style="height: 47px">
                                    <a href="#">
                                        <img id="lnkAddress" onclick="openWindow('../go/frmEmpAddress.aspx')" alt="New address"
                                            src="../go/images/home1.png" border="0" name="lnkAddress" runat="server"></a></td>
                            </tr>
                            <tr>
                                <td valign="bottom" align="left" style="height: 23px">
                                    <asp:TextBox class="blueText" ID="txtCountry" CssClass="inputtext" runat="server"
                                        Width="112px" ReadOnly="True"></asp:TextBox></td>
                                <td style="width: 78px; height: 23px" valign="bottom" align="left" width="104">
                                    <asp:TextBox class="blueText" ID="txtState" CssClass="inputtext" runat="server" Width="80px"
                                        ReadOnly="True"></asp:TextBox></td>
                                <td valign="bottom" align="left" width="10" style="height: 23px">
                                    <asp:TextBox class="blueText" ID="txtCity" CssClass="inputtext" runat="server" Width="100px"
                                        ReadOnly="True"></asp:TextBox></td>
                                <td valign="bottom" align="left" width="10" style="height: 23px">
                                    <asp:TextBox class="blueText" ID="txtZIP" CssClass="inputtext" runat="server" Width="50px"
                                        ReadOnly="True"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" rowspan="2">
                                </td>
                                <td valign="top" align="left" colspan="5">
                                    <asp:Label ID="lblAddressLine" CssClass="smalllabels" runat="server">Address</asp:Label></td>
                            </tr>
                            <tr>
                                <td valign="top" align="left" colspan="5">
                                    <asp:TextBox class="blueText" ID="txtAddress" CssClass="inputtext" runat="server"
                                        Width="232px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 24px">
                                    <asp:Label ID="lblPhone" CssClass="formslabels" Font-Names="Arial" Font-Size="9pt"
                                        runat="server">Phone(s)</asp:Label></td>
                                <td valign="bottom" align="left" colspan="5" style="height: 24px">
                                    <asp:TextBox class="blueText" ID="txtPhone" CssClass="inputtext" runat="server" Width="112px"
                                        ReadOnly="True"></asp:TextBox><a href="#"><img id="lnkPhone" onclick="openWindow('../go/frmEmpPhone.aspx')"
                                            alt="New phone contact" src="../go/images/phone.png" border="0" name="lnkPhone"
                                            runat="server"></a></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6" height="24">
                                    <asp:RadioButtonList ID="radStatus" Font-Names="Arial" Font-Size="XX-Small" runat="server"
                                        RepeatDirection="Horizontal" Visible="False">
                                        <asp:ListItem Value="0">All</asp:ListItem>
                                        <asp:ListItem Value="1" Selected="True">Active</asp:ListItem>
                                        <asp:ListItem Value="2">Inactive</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <asp:Panel ID="pnlPhoto" runat="server" Visible="False">
                            <table cellspacing="0" cellpadding="0" width="200" border="0">
                                <tr>
                                    <td align="center">
                                        <img class="blueBorder" id="imgEmp" height="134" alt="" src="" width="100" name="imgEmp"
                                            runat="server"></td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <input id="fileEmp" type="file" onchange="changeImg()" name="file" runat="server"></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <br>
            <table cellspacing="0" cellpadding="0" width="100%" align="center"
                border="0" class="FunctionBlock">
                <tr>
                    <td >
                        <table width="759" align="center" border="0">
                            <tr>
                                <td align="center">
                                    <p>
                                        <cc1:SecButtons ID="btnUpdate" CssClass="stdEditbtn" runat="server" Visible="False"
                                            ToolTip="Update Employee" RuleID="5004" OnClick="btnUpdate_Click"></cc1:SecButtons><cc1:SecButtons
                                                ID="btnNew" CssClass="stdNewBtn" runat="server" ToolTip="Add New Employee" RuleID="5003"
                                                OnClick="btnNew_Click"></cc1:SecButtons><cc1:SecButtons ID="btnFind" CssClass="stdFindBtn"
                                                    runat="server" ToolTip="Find Employee" RuleID="5017" OnClick="btnFind_Click"></cc1:SecButtons>&nbsp;&nbsp;&nbsp;<asp:Button
                                                        ID="btnClear" CssClass="slectedbutton" runat="server" Width="60px" Text="Reset"
                                                        Visible="False" OnClick="btnClear_Click"></asp:Button>&nbsp;<cc1:SecButtons ID="btnTerminate"
                                                            CssClass="slectedbutton" runat="server" Width="90px" Enabled="False" RuleID="5004"
                                                            Text="Activate" OnClick="btnTerminate_Click"></cc1:SecButtons>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </p>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <div align="center" class="FunctionBlock">
                <asp:Label ID="lblRsltCount" Font-Names="Arial" Font-Size="10pt" runat="server" Font-Bold="True"
                    ForeColor="Black"></asp:Label>
                <div align="left">
                    <table style="width: 100%" cellspacing="0" border="0" id="Table8">
                        <tr class="whitetd">
                            <td style="width: 6%" valign="middle" align="center">
                            </td>
                            <td style="width: 6%" valign="middle" align="center">
                                Active</td>
                            <td style="width: 6%" valign="middle" align="center">
                                Code</td>
                            <td style="width: 34%" valign="middle" align="center">
                                Name</td>
                            <td style="width: 24%" valign="middle" align="center">
                                Department</td>
                            <td style="width: 24%" valign="middle" align="center">
                                Profession</td>
                        </tr>
                    </table>
                </div>
                <div style="overflow: auto; width: 100%; height: 290px">
                    <asp:DataGrid ID="grdEmployees" CellPadding="2" Font-Names="Arial" Font-Size="Smaller"
                        runat="server" Width="100%" AutoGenerateColumns="False" OnSelectedIndexChanged="OnSelect"
                        PageSize="8" OnDeleteCommand="OnDelete" AllowSorting="True" BorderColor="White"
                        ShowHeader="False">
                        <SelectedItemStyle CssClass="offday"></SelectedItemStyle>
                        <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                        <ItemStyle CssClass="bsnormaltd"></ItemStyle>
                        <HeaderStyle CssClass="headertd"></HeaderStyle>
                        <Columns>
                            <asp:ButtonColumn Text="View" CommandName="Select">
                                <HeaderStyle HorizontalAlign="Left" Width="6%" VerticalAlign="Middle"></HeaderStyle>
                                <ItemStyle Font-Size="Smaller" HorizontalAlign="Center" ForeColor="#333399" Width="6%"
                                    VerticalAlign="Middle"></ItemStyle>
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
                            </asp:ButtonColumn>
                            <asp:BoundColumn Visible="False" DataField="ContactID">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Active">
                                <HeaderStyle Width="6%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="6%" VerticalAlign="Middle"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Image ID="imgActive" runat="server"></asp:Image>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="EmpCode" SortExpression="EmpCode" HeaderText="Code">
                                <HeaderStyle ForeColor="White" Width="6%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="6%" VerticalAlign="Middle"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="FirstName" SortExpression="FirstName" HeaderText="Name">
                                <HeaderStyle ForeColor="White" Width="34%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left" Width="34%" VerticalAlign="Middle"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="FirstName"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="MiddleName"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="LastNAme"></asp:BoundColumn>
                            <asp:BoundColumn DataField="CompElmentID" SortExpression="CompElmentID" HeaderText="Department">
                                <HeaderStyle ForeColor="White" Width="24%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left" Width="24%" VerticalAlign="Middle"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="JobTitleID" SortExpression="JobTitleID" HeaderText="Profession">
                                <HeaderStyle ForeColor="White" Width="24%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left" Width="24%" VerticalAlign="Middle"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="UserID" SortExpression="UserID" HeaderText="User ID">
                                <HeaderStyle ForeColor="White"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:ButtonColumn Visible="False" Text="Delete" CommandName="Delete">
                                <ItemStyle Font-Size="Smaller" Font-Names="Arial" ForeColor="#CC0000"></ItemStyle>
                            </asp:ButtonColumn>
                            <asp:BoundColumn Visible="False" DataField="employeeStatus" HeaderText="status"></asp:BoundColumn>
                        </Columns>
                        <PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>
                </div>
                    <fieldset style="width: 283px; height: 111px" align="center" class="FunctionBlock">
                        <legend style="font-weight: bold; font-size: 14px; color: white; font-variant: normal">
                            Weekly sheet for shown employees </legend>
                        <table cellspacing="5" cellpadding="5" width="100" align="center" border="0">
                            <tr>
                                <td class="formslabels">
                                    Date
                                </td>
                                <td valign="middle">
                                    &nbsp;
                                    <input class="inputtext" id="txtDate" style="width: 84px; height: 22px" type="text"
                                        size="8" name="txtDate" runat="server">&nbsp;</td>
                                <dlcalendar input_element_id="_ctl0_txtDate" click_element_id="imgCal" tool_tip="Pick a Date">
                                <td valign="middle">
                                    <img id="imgCal" height="15" alt="Pick a Date" src="../go/images/dlcalendar_1.gif"
                                        width="20" name="imgCal">
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    &nbsp;
                                    <cc1:SecButtons ID="btnTotalSheet" Width="100px" runat="server" CssClass="slectedbutton"
                                        RuleID="5004" Text="Ok" OnClick="btnTotalSheet_Click"></cc1:SecButtons></td>
                            </tr>
                        </table>
                    </fieldset>
                <br>
            </div>
        </td>
    </tr>
    <tr>
        <td valign="bottom" bordercolor="#00ff99" align="center">
            <asp:Panel ID="pnlWeeklySheet" runat="server" Visible="False">
                <center>
                    &nbsp;</center>
            </asp:Panel>
        </td>
    </tr>
    <tr>
    </tr>
</table>

<script language="javascript">
</script>

