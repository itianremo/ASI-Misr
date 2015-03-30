<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.Go.ctlEmployeeMain" CodeFile="ctlEmployeeMain.ascx.cs" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation2" %>
<head runat="server">
    <link href="../Acc1.css" type="text/css" rel="stylesheet" />
</head>
    <script language="javascript" src="accMethods.js" type="text/javascript"></script>
<style type="text/css">.btn {
	BORDER-RIGHT: #000066 1px solid; BORDER-TOP: #000066 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 10px; BORDER-LEFT: #000066 1px solid; COLOR: #000066; BORDER-BOTTOM: #000066 1px solid; FONT-FAMILY: Arial, Helvetica, sans-serif; BACKGROUND-COLOR: #ffffff
}
.errtable {
	BORDER-RIGHT: #cccc00 1px solid; BORDER-TOP: #cccc00 1px solid; BORDER-LEFT: #cccc00 1px solid; BORDER-BOTTOM: #cccc00 1px solid
}
.trBorder {
	BORDER-RIGHT: #003366 1px solid; BORDER-TOP: #003366 1px solid; BORDER-LEFT: #003366 1px solid; BORDER-BOTTOM: #003366 1px solid
}
.blueText {
	FONT-SIZE: xx-small; COLOR: #003366; FONT-FAMILY: Arial, Helvetica, sans-serif
}
.btn1 {
	BORDER-RIGHT: #000066 1px solid; BORDER-TOP: #000066 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 12px; BORDER-LEFT: #000066 1px solid; COLOR: #000066; BORDER-BOTTOM: #000066 1px solid; FONT-FAMILY: Arial, Helvetica, sans-serif; BACKGROUND-COLOR: #ffffff
}
.style17 {
	FONT-SIZE: 10px; COLOR: #003366
}
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

function openWindow1(url)
{
	if ( wndHandle && wndHandle.open && wndHandle.closed)
		wndHandle.close();
	wndHandle=open('','window','width=1000,height=700,top=0,left=200,status=yes,scrollbars=yes');
	wndHandle.location.href = url;
	if (wndHandle.opener == null) wndHandle.opener = self;		
}

function changeImg()
{
	document.getElementById('imgEmp').src = document.getElementById('_ctl0_fileEmp').value;
}
function changeImgHR()
{
	document.getElementById('imgEmpHR').src = document.getElementById('_ctl0_fileEmpHR').value;
}
//-->

window.onload = function(){
var strCook = document.cookie;
if(strCook.indexOf("!~")!=0){
var intS = strCook.indexOf("!~");
var intE = strCook.indexOf("~!");
var strPos = strCook.substring(intS+2,intE);
document.getElementById("grdWithScroll").scrollTop = strPos;
}
}
function SetDivPosition(){
var intY = document.getElementById("grdWithScroll").scrollTop;
document.title = intY;
document.cookie = "yPos=!~" + intY + "~!";
}
</script>

<table id="Table1" width="100%" align="center" border="0" style="vertical-align: top;
    margin: 0px; background: #C2CCD8;">
    <tr>
        <td dir="ltr" style="vertical-align: top;">
            <%--            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>--%>
            <table border="0" cellpadding="0" cellspacing="0" class="ToolBar" width="100%">
                <tr>
                    <td style="height: 34px">
                        <cc1:SecImageButtons ID="btnUpdate" runat="server" ToolTip="Update Employee" RuleID="5004"
                            OnClick="btnUpdate_New_Click" ImageUrl="~/Go/images/Buttons/UpdateEmployee_n.jpg"
                            onmouseover="this.src='../Go/images/Buttons/UpdateEmployee_o.jpg'" onmousedown="this.src='../Go/images/Buttons/UpdateEmployee_s.jpg'"
                            onmouseout="this.src='../Go/images/Buttons/UpdateEmployee_n.jpg'" Visible="False" TabIndex="1">
                        </cc1:SecImageButtons>
                        <cc1:SecImageButtons ID="btnNew" runat="server" ToolTip="Add New Employee" RuleID="5003"
                            OnClick="btnNew_Click" ImageUrl="~/Go/images/Buttons/AddEmployee_n.jpg" onmouseover="this.src='../Go/images/Buttons/AddEmployee_o.jpg'"
                            onmouseout="this.src='../Go/images/Buttons/AddEmployee_n.jpg'" onmousedown="this.src='../Go/images/Buttons/AddEmployee_s.jpg'">
                        </cc1:SecImageButtons>&nbsp;
                        <asp:ImageButton ID="btnClear" runat="server" OnClick="btnClear_Click" ImageUrl="~/Go/images/Buttons/Reset_n.jpg"
                            onmouseover="this.src='../Go/images/Buttons/Reset_o.jpg'" onmouseout="this.src='../Go/images/Buttons/Reset_n.jpg'"
                            onmousedown="this.src='../Go/images/Buttons/Reset_s.jpg'" ToolTip="Clear All Fields"></asp:ImageButton>
                        <asp:RadioButtonList ID="radStatus" Font-Names="Tahoma" Font-Size="12px" runat="server"
                            RepeatDirection="Horizontal" ForeColor="Black" RepeatLayout="Flow" Font-Bold="False"
                            Height="29px" Font-Overline="False" ToolTip="Employee Status">
                            <asp:ListItem Value="0">All</asp:ListItem>
                            <asp:ListItem Value="1" Selected="True">Active</asp:ListItem>
                            <asp:ListItem Value="2">Terminated</asp:ListItem>
                        </asp:RadioButtonList>
                        <cc1:SecImageButtons ID="btnFind" runat="server" ToolTip="Find Employee" RuleID="5017"
                            OnClick="btnFind_Click" ImageUrl="~/Go/images/Buttons/FindEmployee_n.jpg" onmouseover="this.src='../Go/images/Buttons/FindEmployee_o.jpg'"
                            onmouseout="this.src='../Go/images/Buttons/FindEmployee_n.jpg'" onmousedown="this.src='../Go/images/Buttons/FindEmployee_s.jpg'">
                        </cc1:SecImageButtons>
                        <img id="imgChangePassword" alt="Change Password" src="../Go/images/PageTopToolbar/Change_Password_n.jpg"
                            onclick="window.location='../SecurityManagement/frmChangePass.aspx?ChangePassword=yes'"
                            onmouseover="this.src='../Go/images/PageTopToolbar/Change_Password_o.jpg'" onmouseout="this.src='../Go/images/PageTopToolbar/Change_Password_n.jpg'"
                            onmousedown="this.src='../Go/images/PageTopToolbar/Change_Password_s.jpg'"  />
                    </td>
                </tr>
            </table>
            <asp:Table ID="tblErr" BorderWidth="0px" CellPadding="2" CellSpacing="0" Font-Names="Arial"
                Font-Size="9pt" runat="server" Visible="False" Width="453px" HorizontalAlign="Center"
                ForeColor="Red">
                <asp:TableRow ID="TableRow1" VerticalAlign="Top" runat="server">
                    <asp:TableCell ID="TableCell1" BackColor="#FFFFC0" BorderColor="White" Text="&lt;img src=&quot;../go/images/alrt_l.gif&quot; /&gt;"
                        runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell2" BackColor="#FFFFC0" runat="server"></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <table id="Table2" cellspacing="0" cellpadding="0" width="700" align="center">
                <tr>
                    <td class="headertd" valign="middle" align="center" colspan="3" style="height: 20px">
                        Employee's Information
                    </td>
                </tr>
                <tr valign=top>
                    <td valign=top>
                        <table id="Table3" cellspacing="3" cellpadding="1" width="700" align="center" border="0"
                            class="FunctionBlock">
                            <tr>
                                <td style="width: 85px" nowrap align="right" width="85">
                                    <span class="formslabels">Code </span>
                                </td>
                                <td align="left" colspan="5">
                                    <asp:TextBox class="blueText" ID="txtCode" CssClass="inputtext" runat="server" Width="130px"
                                        MaxLength="6"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:RangeValidator ID="rvEmployeeCode" Font-Size="XX-Small" runat="server" Display="Dynamic"
                                        Type="Integer" MinimumValue="1" MaximumValue="999999" ErrorMessage="Enter digits only"
                                        ControlToValidate="txtCode"></asp:RangeValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 85px" align="right">
                                    <asp:Label class="formslabels" ID="Label4" CssClass="formslabels" Font-Names="Arial"
                                        Font-Size="9pt" runat="server">Name</asp:Label></td>
                                <td colspan="5" height="20">
                                    <table id="Table4" cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td style="height: 22px">
                                                <asp:TextBox class="blueText" ID="txtFName" CssClass="inputtext" runat="server" Width="130px"
                                                    MaxLength="70" DESIGNTIMEDRAGDROP="20"></asp:TextBox>&nbsp;
                                                <asp:TextBox class="blueText" ID="txtMName" CssClass="inputtext" runat="server" Width="130px"
                                                    MaxLength="70"></asp:TextBox>&nbsp;
                                                <asp:TextBox class="blueText" ID="txtLName" CssClass="inputtext" runat="server" Width="130px"
                                                    MaxLength="70"></asp:TextBox></td>
                                            <td align="right" style="height: 22px">
                                                <%--<asp:LinkButton ID="lnkShowPhoto" Font-Names="Arial" Font-Size="7pt" runat="server"
                                                    Enabled="False" OnClick="lnkShowPhoto_Click" ForeColor="White"> Photo
                                                </asp:LinkButton>--%>
                                                <asp:ImageButton ID="lnkShowPhoto" runat="server" OnClick="lnkShowPhoto_Click" Enabled="False"
                                                    ImageUrl="~/Go/images/Buttons/photo_n.jpg" onmouseover="this.src='../Go/images/Buttons/photo_o.jpg'"
                                                    onmouseout="this.src='../Go/images/Buttons/photo_n.jpg'" onmousedown="this.src='../Go/images/Buttons/photo_s.jpg'" ToolTip="Photo" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 85px; height: 35px" align="right">
                                    <asp:Label ID="Label3" CssClass="formslabels" Font-Names="Arial" Font-Size="9pt"
                                        runat="server">Department</asp:Label></td>
                                <td style="height: 35px; width: 111px;">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList class="blueText" ID="lstCompElements" CssClass="inputtext" runat="server"
                                                        Width="220px" DataSource="<%# dsCompElements %>" DataValueField="CompElmentID"
                                                        DataTextField="CEName" OnDataBinding="lstCompElements_DataBinding">
                                                    </asp:DropDownList></td>
                                                <td nowrap align="right">
                                                    <asp:Label ID="Label1" CssClass="formslabels" Font-Names="Arial" Font-Size="9pt"
                                                        runat="server">Job Title</asp:Label></td>
                                                <td>
                                                    <asp:DropDownList class="blueText" ID="lstJobTitles" CssClass="inputtext" runat="server"
                                                        Width="200px" DataSource="<%# dsJobTitles %>" DataValueField="JobTitleID" DataTextField="JobName"
                                                        OnDataBinding="lstJobTitles_DataBinding">
                                                    </asp:DropDownList><asp:TextBox class="blueText" ID="txtJobTitleName" CssClass="inputtext"
                                                        runat="server" Visible="False" Width="130px" MaxLength="70"></asp:TextBox></td>
                                                <td>
                                                    <img id="lnkJobTitle" title="New job title" onclick="openWindow1('../go/frmEmpJobtitle.aspx')"
                                                        alt="New job title" src="images/PageTopToolbar/New_JobTitle_n.jpg" border="0"
                                                        name="lnkJobs" runat="server" onmouseover="this.src='../Go/images/PageTopToolbar/New_JobTitle_o.jpg'"
                                                        onmousedown="this.src='../Go/images/PageTopToolbar/New_JobTitle_s.jpg'" onmouseout="this.src='../Go/images/PageTopToolbar/New_JobTitle_n.jpg'" />
                                                </td>
                                            </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 85px" align="right" height="18">
                                    <asp:Label ID="Label2" CssClass="formslabels" Font-Names="Arial" Font-Size="9pt"
                                        runat="server">UserName</asp:Label></td>
                                <td align="left" colspan="5">
                                    <asp:DropDownList class="blueText" ID="lstUserName" CssClass="inputtext" runat="server"
                                        DataSource="<%# dsUser %>" DataValueField="UserID" DataTextField="UserName" OnDataBinding="lstUserName_DataBinding">
                                    </asp:DropDownList>&nbsp;
                                    <asp:DropDownList ID="lstUnassignedUsers" CssClass="inputtext" runat="server" Visible="False"
                                        DataSource="<%# dsUnassignedUsers %>" DataValueField="UserID" DataTextField="UserName">
                                    </asp:DropDownList>
                                    <asp:Label ID="lblNewUserName" runat="server" CssClass="formslabels" Text="UserName" Visible="False"></asp:Label>
                                    <asp:TextBox ID="txtNewUserName" runat="server" CssClass="inputtext" Width="130px" Visible="False"></asp:TextBox>
                                    <asp:Label ID="lblNewPassword" runat="server" CssClass="formslabels" Text="Password" Visible="False"></asp:Label>
                                    <asp:TextBox ID="txtNewPassword" runat="server" CssClass="inputtext" Width="130px" TextMode="Password" Visible="False"></asp:TextBox></td>
                            </tr>
                            <tr id="divHiringDate" runat="server">
                                <td align="right">
                                    <asp:Label ID="lblStatus" CssClass="formslabels" Font-Names="Arial" Font-Size="9pt"
                                        runat="server">Status</asp:Label>
                                </td>
                                <td colspan="5">
                                    <asp:RadioButtonList ID="rblEmpStatus" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" CssClass="formslabels">
                                        <asp:ListItem Value="1">Active</asp:ListItem>
                                        <asp:ListItem Value="0">Terminated</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr id="divHiringDate2" runat="server">
                                <td align="right">
                                    <asp:Label ID="Label6" CssClass="formslabels" Font-Names="Arial" Font-Size="9pt"
                                        runat="server">Hiring Date</asp:Label>
                                </td>
                                <td align="left" style="vertical-align: middle;" colspan="5">
                                    <table>
                                        <tr>
                                            <td dir="ltr">
                                                <asp:TextBox class="inputtext" ID="txtHDate" CssClass="inputtext" runat="server"
                                                    Width="112px"></asp:TextBox>
                                                <dlcalendar tool_tip="Click to choose a date" click_element_id="imgCal2" input_element_id="_ctl0_txtHDate"
                                                    firstday="Su">
                                    <img id="imgCal2" height="15" alt="Pick a Date" src="../go/images/dlcalendar_1.gif"
                                                        width="20" name="imgCal2" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Label ID="Label7" CssClass="formslabels" Font-Names="Arial" Font-Size="9pt"
                                                    runat="server">Termination Date</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox class="inputtext" ID="txtTDate" CssClass="inputtext" runat="server"
                                                    Width="112px"></asp:TextBox>
                                                <dlcalendar tool_tip="Click to choose a date" click_element_id="imgCal3" input_element_id="_ctl0_txtTDate"
                                                    firstday="Su">
                                                    <img id="imgCal3" height="15" alt="Pick a Date" src="../go/images/dlcalendar_1.gif"
                                                        width="20" name="imgCal3" runat="server">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 85px; height: 66px;" align="right">
                                    <asp:Label ID="lblAddress" CssClass="formslabels" Font-Names="Arial" Font-Size="9pt"
                                        runat="server">Address(es)</asp:Label></td>
                                <td style="width: 111px; height: 66px;" dir="ltr">
                                    <table style="width: 496px;">
                                        <tr>
                                            <td style="width: 103px;">
                                                <asp:Label ID="lblCountry" CssClass="smalllabels" runat="server" Font-Names="Tahoma"
                                                    Font-Size="X-Small" Height="11px" Width="62px">Country</asp:Label></td>
                                            <td style="width: 63px;">
                                                <asp:Label ID="lblState" CssClass="smalllabels" runat="server" Font-Names="Tahoma"
                                                    Font-Size="X-Small">State</asp:Label></td>
                                            <td style="width: 102px;">
                                                <asp:Label ID="lblCity" CssClass="smalllabels" runat="server" Font-Names="Tahoma"
                                                    Font-Size="X-Small">City</asp:Label></td>
                                            <td style="width: 53px;">
                                                <asp:Label ID="lblZIP" CssClass="smalllabels" runat="server" Font-Names="Tahoma"
                                                    Font-Size="X-Small">ZIP</asp:Label></td>
                                            <td valign="middle">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 103px">
                                                <asp:TextBox class="blueText" ID="txtCountry" CssClass="inputtext" runat="server"
                                                    Width="120px" ReadOnly="True"></asp:TextBox></td>
                                            <td style="width: 63px">
                                                <asp:TextBox class="blueText" ID="txtState" CssClass="inputtext" runat="server" Width="104px"
                                                    ReadOnly="True"></asp:TextBox></td>
                                            <td style="width: 102px">
                                                <asp:TextBox class="blueText" ID="txtCity" CssClass="inputtext" runat="server" Width="100px"
                                                    ReadOnly="True"></asp:TextBox></td>
                                            <td style="width: 53px">
                                                <asp:TextBox class="blueText" ID="txtZIP" CssClass="inputtext" runat="server" Width="64px"
                                                    ReadOnly="True"></asp:TextBox></td>
                                            <td>
                                                <a href="#">
                                                    <img id="lnkAddress" onclick="openWindow('../go/frmEmpAddress.aspx')" alt="New address"
                                                        src="images/Buttons/NewAddress_n.jpg" border="0" name="lnkAddress" runat="server"
                                                        style="vertical-align: bottom;" onmouseover="this.src='../Go/images/Buttons/NewAddress_o.jpg'"
                                                        onmouseout="this.src='../Go/images/Buttons/NewAddress_n.jpg'" onmousedown="this.src='../Go/images/Buttons/NewAddress_s.jpg'" />
                                                </a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 85px" align="right" rowspan="2">
                                </td>
                                <td valign="top" align="left" colspan="5" style="height: 15px">
                                    <asp:Label ID="lblAddressLine" CssClass="smalllabels" runat="server">Address</asp:Label></td>
                            </tr>
                            <tr>
                                <td valign="top" align="left" colspan="5">
                                    <asp:TextBox class="blueText" ID="txtAddress" CssClass="inputtext" runat="server"
                                        Width="232px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 85px;" align="right">
                                    <asp:Label ID="lblPhone" CssClass="formslabels" Font-Names="Arial" Font-Size="9pt"
                                        runat="server">Phone(s)</asp:Label></td>
                                <td valign="bottom" align="left" colspan="5">
                                    <asp:TextBox class="blueText" ID="txtPhone" CssClass="inputtext" runat="server" Width="228px"
                                        ReadOnly="True"></asp:TextBox><a href="#">
                                            <img id="lnkPhone" onclick="openWindow('../go/frmEmpPhone.aspx')" alt="New phone contact"
                                                src="images/buttons/phone_n.jpg" border="0" name="lnkPhone" runat="server" style="vertical-align: bottom;
                                                width: 22px; height: 22px;"></a></td>
                            </tr>
                            <tr>
                                <td style="width: 85px; height: 24px;" align="right">
                                    <asp:Label ID="lblEmail" CssClass="formslabels" Font-Names="Arial" Font-Size="9pt"
                                        runat="server">External</asp:Label></td>
                                <td valign="bottom" align="left" colspan="5" style="height: 24px">
                                    <asp:TextBox class="blueText" ID="txtEmail" CssClass="inputtext" runat="server" Width="228px"
                                        ReadOnly="True"></asp:TextBox>&nbsp;<a href="#"><img id="lnkEmail" onclick="openWindow('../go/frmEmpEmail.aspx')"
                                            alt="New email contact" src="images/buttons/new-e.mail_n.jpg" border="0" name="lnkPhone"
                                            runat="server" style="height: 22px; height: 22px; vertical-align: bottom;"></a></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 85px; height: 24px">
                                    <asp:Label ID="lblEmailInternal" runat="server" CssClass="formslabels" Font-Names="Arial" Font-Size="9pt">Internal</asp:Label></td>
                                <td align="left" colspan="5" style="height: 24px" valign="bottom">
                                    <asp:TextBox ID="txtEmailInternal" runat="server" class="blueText" CssClass="inputtext" ReadOnly="True"
                                        Width="228px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6" height="24">
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="FunctionBlock">
                        <asp:Panel ID="pnlPhoto" runat="server" Visible="False">
                            <table cellspacing="0" cellpadding="0" width="200" border="0">
                                <tr>
                                    <td align="center" style="width: 200px">
                                        <img class="blueBorder" id="imgEmp" alt="" src=""  name="imgEmp"
                                            runat="server"></td>
                                </tr>
                                <tr>
                                    <td align="center" style="width: 200px">
                                        <input id="fileEmp" type="file" onchange="changeImg()" name="file" runat="server"
                                            style="background-color: white" class="inputtext"></td>
                                </tr>
                                <tr>
                                <td style="width: 200px">
                                 <input id="hdnResetImage" style="width: 94px; height: 22px" type="hidden" size="10"
                                runat="server">
                            <asp:Button ID="btnDeletePic" CssClass="slectedbutton" runat="server" Width="91px"
                                Text="Reset photo" OnClick="btnDeletePic_Click" ToolTip="Reset photo"></asp:Button>
                                </td>
                                </tr>
                            </table>
                           
                            <br />
                            <br />
                            <hr style="border:border-width=100%; width: 100%; position: absolute;"/>
                            <br />&nbsp;
                            <asp:Label ID="lblDownloadOriginalPhoto" CssClass="formslabels" Font-Names="Arial" Font-Size="9pt"
                                        runat="server">Original Photo</asp:Label>
                           
                            <br />
                            
                            
                            <asp:LinkButton ID="btnDownload" runat="server" Font-Size="Small" Font-Underline="True"
                                ForeColor="White" OnClick="btnDownload_Click" Width="191px" ToolTip="Download original photo">Download Original photo</asp:LinkButton><br />
                               <br /> 
                                
                                <table cellspacing="0" cellpadding="0" width="200" border="0">
                                <tr>
                                   <td align="center">
                                        <img class="blueBorder" id="imgEmpHR" alt="" src=""  name="imgEmpHR"
                                            runat="server" visible="false"></td>
                                </tr>
                                <tr>
                                    <td align="center" style="height: 22px">
                                        <input id="fileEmpHR" type="file" onchange="changeImgHR()" name="fileHR" runat="server"
                                            style="background-color: white" class="inputtext1"></td>
                                </tr>
                                <tr>
                                <td>
                                 <input id="hdnResetImageHR" style="width: 94px; height: 22px" type="hidden" size="10"
                                runat="server">
                            <asp:Button ID="btnDeletePicHR" CssClass="slectedbutton" runat="server" Width="91px"
                                Text="Reset photo" OnClick="btnDeletePicHR_Click" ToolTip="Reset photo"></asp:Button>
                                </td>
                                </tr>
                            </table>
                            
                                
                                
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <br>
            <table id="Table6" cellspacing="0" cellpadding="0" width="100%" align="center" border="0"
                class="FunctionBlock" style="background: #C2CCD8;" visible="false">
                <tr>
                    <td>
                        <table id="Table7" width="759" align="center" border="0">
                            <tr>
                                <td align="center">
                                    <p>
                                        &nbsp; &nbsp;&nbsp;<cc1:SecImageButtons ID="btnTerminate" CssClass="slectedbutton"
                                            runat="server" Width="90px" Enabled="False" Text="Activate" RuleID="5004" OnClick="btnTerminate_Click"
                                            Visible="False"></cc1:SecImageButtons>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        &nbsp;&nbsp;
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
                    <table id="Table8" style="width: 100%" cellspacing="0" border="0" class="whitetd">
                        <tr>
                            <td style="width: 5%" valign="middle" align="center">
                            </td>
                            <td style="width: 5%" valign="middle" align="center">
                                Active</td>
                            <td style="width: 5%" valign="middle" align="center">
                                Code
                            </td>
                            <td style="width: 30%" valign="middle" align="center">
                                Name
                            </td>
                            <td style="width: 25%" valign="middle" align="center">
                                Department
                            </td>
                            <td style="width: 25%" valign="middle" align="center">
                                Profession
                            </td>
                            <td style="width: 5%" valign="middle" align="center">
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="grdWithScroll" style="overflow: auto; width: 100%; height: 290px" onscroll="SetDivPosition()"
                    class="FunctionBlock">
                    <asp:DataGrid ID="grdEmployees" CellPadding="2" Font-Names="Arial" Font-Size="Smaller"
                        runat="server" Width="100%" ShowHeader="False" AutoGenerateColumns="False" OnSelectedIndexChanged="OnSelect"
                        PageSize="8" OnDeleteCommand="OnDelete" AllowSorting="True" BorderColor="White">
                        <SelectedItemStyle CssClass="offday"></SelectedItemStyle>
                        <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                        <ItemStyle CssClass="bsnormaltd"></ItemStyle>
                        <HeaderStyle CssClass="headertd"></HeaderStyle>
                        <Columns>
                            <asp:ButtonColumn Text="View" CommandName="Select">
                                <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                <ItemStyle Font-Size="Smaller" HorizontalAlign="Center" ForeColor="#333399" Width="5%"
                                    VerticalAlign="Middle" BorderColor="#000000"></ItemStyle>
                            </asp:ButtonColumn>
                            <asp:BoundColumn Visible="False" DataField="ContactID">
                                <ItemStyle HorizontalAlign="Center" BorderColor="#000000"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Active">
                                <HeaderStyle Width="5%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="5%" VerticalAlign="Middle" BorderColor="#000000">
                                </ItemStyle>
                                <ItemTemplate>
                                    <asp:Image ID="imgActive" runat="server"></asp:Image>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="EmpCode" SortExpression="EmpCode" HeaderText="Code">
                                <HeaderStyle ForeColor="White" Width="5%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="5%" VerticalAlign="Middle" BorderColor="#000000">
                                </ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="FirstName" SortExpression="FirstName" HeaderText="Name">
                                <HeaderStyle ForeColor="White" Width="30%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left" Width="30%" VerticalAlign="Middle" BorderColor="#000000">
                                </ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="FirstName"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="MiddleName"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="LastNAme"></asp:BoundColumn>
                            <asp:BoundColumn DataField="CompElmentID" SortExpression="CompElmentID" HeaderText="Department">
                                <HeaderStyle ForeColor="White" Width="25%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left" Width="25%" VerticalAlign="Middle" BorderColor="#000000">
                                </ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="JobTitleID" SortExpression="JobTitleID" HeaderText="Profession">
                                <HeaderStyle ForeColor="White" Width="25%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left" Width="25%" VerticalAlign="Middle" BorderColor="#000000">
                                </ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="UserID" SortExpression="UserID" HeaderText="User ID">
                                <HeaderStyle ForeColor="White"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:ButtonColumn Text="Delete" CommandName="Delete">
                                <HeaderStyle Width="5%"></HeaderStyle>
                                <ItemStyle Font-Size="Smaller" Font-Names="Arial" ForeColor="#CC0000" Width="5%"
                                    BorderColor="#000000"></ItemStyle>
                            </asp:ButtonColumn>
                            <asp:BoundColumn Visible="False" DataField="employeeStatus" HeaderText="status"></asp:BoundColumn>
                        </Columns>
                        <PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid></div>
                <br>
            </div>
            <table align="center">
                <tbody>
                    <tr>
                        <td valign="bottom" bordercolor="#00ff99" align="center" class="FunctionBlock">
                            <asp:Panel ID="pnlWeeklySheet" runat="server" Visible="False">
                                <center>
                                    <fieldset style="width: 283px; height: 111px" align="center">
                                        <legend style="font-weight: bold; font-size: 14px; color: white; font-variant: normal">
                                            Weekly sheet for selected employee </legend>
                                        <table cellspacing="5" cellpadding="5" width="100" align="center" border="0">
                                            <tr>
                                                <td class="formslabels">
                                                    Date
                                                </td>
                                                <td valign="middle">
                                                    <%-- &nbsp;
                                                    <asp:TextBox ID="txtDate" runat="server" class="inputtext" Style="width: 84px; height: 22px"></asp:TextBox>&nbsp;<cc2:CalendarExtender
                                                        ID="CalendarExtender1" runat="server"
                                                        PopupButtonID="txtDate" PopupPosition="Right"
                                                        TargetControlID="txtDate" BehaviorID="CalendarExtender1" Enabled="True">
                                                    </cc2:CalendarExtender>--%>
                                                    <input class="inputtext" id="txtDate" style="width: 84px; height: 17px" type="text"
                                                        size="8" name="txtDate" runat="server">
                                                </td>
                                                <dlcalendar tool_tip="Pick a Date" click_element_id="imgCal" input_element_id="_ctl0_txtDate"
                                                    firstday="Su">
                                                <td valign="middle">
                                                    &nbsp;<img id="imgCal" height="15" alt="Pick a Date" src="../go/images/dlcalendar_1.gif"
                                                        width="20" name="imgCal"></td>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</tr>
                                            <tr>
                                                <td align="center" colspan="3">
                                                    <cc1:SecImageButtons ID="btnTotalSheet" CssClass="slectedbutton" runat="server" Text="Ok"
                                                        RuleID="5004" OnClick="btnTotalSheet_Click" AlternateText="OK" ImageUrl="~/Go/images/Buttons/ok_n.jpg"
                                                        onmouseover="this.src='../Go/images/Buttons/ok_o.jpg'" onmouseout="this.src='../Go/images/Buttons/ok_n.jpg'"
                                                        onmousedown="this.src='../Go/images/Buttons/ok_s.jpg'"></cc1:SecImageButtons></td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </center>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                    </tr>
                </tbody>
            </table>
            <%--<script language="javascript"></script>--%>

            <script language="javascript" src="include/dlcalendar.js" type="text/javascript"></script>

        </td>
    </tr>
</table>
