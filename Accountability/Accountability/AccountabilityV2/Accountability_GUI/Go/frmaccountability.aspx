<%@ Reference Page="~/go/frmpopup.aspx" %>
<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.Go.frmAccountability" EnableSessionState="true"
    CodeFile="frmAccountability.aspx.cs" %>

<%--<%@ Register TagPrefix="fckeditorv2" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>--%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns:o="urn:schemas-microsoft-com:office:office">
<head>
    <title>frmAccountability</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <style type="text/css">
        .style4 
        { 
        FONT-WEIGHT: bold; 
        FONT-SIZE: xx-small; 
        COLOR: #003366; 
        FONT-FAMILY: Arial, Helvetica, sans-serif 
        }
	    .style7 
	    { 
        COLOR: #fdd68c ;
	    }
	    TD 
        { 
        FONT-SIZE: 11px; 
        COLOR: #003366; 
        FONT-FAMILY: Arial, Helvetica, sans-serif 
        }
	    .blueBtn 
	    { 
	    BORDER-RIGHT: #000066 1px solid; 
	    BORDER-TOP: #000066 1px solid; 
	    BORDER-LEFT: #000066 1px solid; 
	    BORDER-BOTTOM: #000066 1px solid; 
	    BACKGROUND-COLOR: #8dc0dc; 
	    }
	    .whiteBtn  
	    { 
	    BORDER-RIGHT: #cccccc 1px solid; 
	    BORDER-TOP: #cccccc 1px solid; 
	    BORDER-LEFT: #cccccc 1px solid; 
	    BORDER-BOTTOM: #cccccc 1px solid 
	    }
	    .greenBtn 
	    { 
	    BORDER-RIGHT: #006600 1px solid; 
	    BORDER-TOP: #006600 1px solid; 
	    BORDER-LEFT: #006600 1px solid; 
	    BORDER-BOTTOM: #006600 1px solid; 
	    BACKGROUND-COLOR: #aefbb8 }
	    .style9 
	    { 
	    FONT-WEIGHT: bold; 
	    FONT-SIZE: x-small; 
	    COLOR: #003366; 
	    FONT-FAMILY: Arial, Helvetica, sans-serif 
	    }
	    .btn 
	    { 
	    BORDER-RIGHT: #000066 1px solid; 
	    BORDER-TOP: #000066 1px solid; 
	    FONT-WEIGHT: bold; 
	    FONT-SIZE: 12px; 
	    BORDER-LEFT: #000066 1px solid; 
	    COLOR: #000066; 
	    BORDER-BOTTOM: #000066 1px solid; 
	    FONT-FAMILY: Arial, Helvetica, sans-serif; 
	    HEIGHT: 15px; 
	    BACKGROUND-COLOR: #ffffff 
	    }
	    .blueBorder 
	    { 
	    BORDER-RIGHT: #003366 1px solid; 
	    BORDER-TOP: #003366 1px solid; 
	    BORDER-LEFT: #003366 1px solid; 
	    BORDER-BOTTOM: #003366 1px solid 
	    }
	    BODY 
	    { 
	    BACKGROUND-COLOR: #ffffff 
	    }
	    .style18 
	    { 
	    COLOR: #003366 
	    }
	    .style19 
	    {
	     FONT-WEIGHT: bold; 
	     COLOR: #003366
	     }
	    .style21 
	    { 
	    FONT-WEIGHT: bold; 
	    COLOR: #ff0000 
	    }
		</style>
    <link href="../Acc1.css" type="text/css" rel="stylesheet" />

    <script type="text/JavaScript">
        if(window.history.forward(1) != null)
        {
			 window.history.forward(1);
        }
        <!--
        var wndHandle;  // a handle to the opened [pop-up] window. 
        function MM_openBrWindow(theURL,winName,features) { //v2.0
        //closeChildWnd();
        window.open(theURL,winName,features);
        DisableNotes(); 
        //alert(theURL);
        }
        // close pop-up window if exists
        function closeChildWnd()
        {
            if (wndHandle && wndHandle.open)
	            wndHandle.close();
            DisplayMessage();
        }
        function RemoveSpace(s)
        {
	        var strSpace= s.replace(/&nbsp;/g,"");
	        return strSpace;
        }		
        -->
    </script>

    <script language="javascript" src="accMethods.js" type="text/javascript"></script>

    <script language="JavaScript" src="spell.js" type="text/javascript"></script>

</head>
<body onkeydown="onKeyDownHandler()" onfocus="refreshForm();" onload="initPage()"
    onunload="closeChildWnd()" dir="ltr" style="background: #C2CCD8">
    <form id="Form1" method="post" runat="server">
        <table width="100%" align="center" border="0">
        </table>
        <label>
        </label>
        <table cellspacing="0" cellpadding="0" width="100%">
            <tr class="ToolBar">
                <td valign="top" style="width: 290px">
                    <img title="Previous employee" onclick="prevEmp()" alt="Previous employee" src="images/PageTopToolbar/Previous_n.jpg"
                    border="0" onmouseover="this.src='images/PageTopToolbar/Previous_o.jpg'" onmouseout="this.src='images/PageTopToolbar/Previous_n.jpg'"
                    onmousedown="this.src='images/PageTopToolbar/Previous_s.jpg'" />
                    <img title="Next employee" onclick="nextEmp()" alt="Next employee" src="images/PageTopToolbar/Next_n.jpg"
                    border="0" onmouseover="this.src='images/PageTopToolbar/Next_o.jpg'" onmouseout="this.src='images/PageTopToolbar/Next_n.jpg'"
                    onmousedown="this.src='images/PageTopToolbar/Next_s.jpg'" id="IMG1" />
                    <img title="Find employee" onclick="openEmpWnd()" alt="Find employee" src="images/PageTopToolbar/FindEmployee_n.jpg"
                    border="0" onmouseover="this.src='images/PageTopToolbar/FindEmployee_o.jpg'"
                    onmouseout="this.src='images/PageTopToolbar/FindEmployee_n.jpg'" onmousedown="this.src='images/PageTopToolbar/FindEmployee_s.jpg'" /><%--  <img title="Weekly total hours reported" onclick="openReportViewer(2);" alt="Weekly total hours reported"
                        src="images/PageTopToolbar/ReportsIcon_n.jpg" border="0" />
                    <img id="btnPrint" title="Weekly accountability report" style="visibility: hidden"
                        onclick="openReportViewer(1);" alt="Weekly accountability report" src="images/PageTopToolbar/print_n.jpg"
                        border="0" name="btnPrint" />
                    <img id="btnGetTaskSumm" title="Task summary report" onclick="openReportViewer(3);"
                        alt="Task summary report" src="images/PageTopToolbar/task_summary_n.jpg" border="0"
                        name="btnGetTaskSumm" />--%><img id="btnSave" title="Save sheet" style="visibility: hidden" onclick="saveSheet(1);"
                        alt="Save sheet" src="images/PageTopToolbar/SavePage_n.jpg" border="0" name="btnSave"
                        onmouseover="this.src='images/PageTopToolbar/SavePage_o.jpg'" onmouseout="this.src='images/PageTopToolbar/SavePage_n.jpg'"
                        onmousedown="this.src='images/PageTopToolbar/SavePage_s.jpg'" /><%-- <img id="btnDelete" title="Delete selected task" style="visibility: hidden" onclick="deleteAssignment();"
                        alt="Delete selected task" src="images/PageTopToolbar/delete_n.jpg" border="0"
                        name="btnDelete" />
                    <img id="btnCompleteTask" title="Set selected task as closed/open" style="visibility: hidden"
                        onclick="completeAssignment();" alt="Set selected task as closed/open" src="images/PageTopToolbar/Set_selected_Task_n.jpg"
                        border="0" name="btnCompleteTask" />
                    <img id="btnViewAssAcc" title="Total hours for selected task" style="visibility: hidden"
                        onclick="MM_openBrWindow('frmAssignments.aspx?assignID=' + selectedAssID + '&amp;assignName=' +RemoveSpace(document.getElementById('divTask' + selectedIndex).innerHTML),'','width=600,height=500,toolbar=yes,location=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes')"
                        alt="Total hours for selected task" src="images/PageTopToolbar/Total-hours_n.jpg"
                        border="0" name="btnViewAssAcc" />--%>
                </td>
                <td valign="top" style="width: 298px">
                    <table style="vertical-align: top;">
                        <tr>
                            <td valign="middle" style="width: 23px">
                                <input id="chkOffDays" onclick="DisplayMessage(),bindEmpInfo(document.getElementById('lstEmployee').options[document.getElementById('lstEmployee').selectedIndex].value);"
                                    type="checkbox" name="chkOffDays" title="View Days Off" />
                            </td>
                            <td valign="middle">
                                <asp:Label ID="Label2" runat="server" Text="View Days Off" ForeColor="Black" Width="80px" ToolTip="View Days Off"></asp:Label>
                            </td>
                            <td style="width: 20px;">
                            </td>
                            <td valign="middle">
                                <asp:Label ID="Label3" runat="server" Text="View Mode" ForeColor="Black" Width="60px" ToolTip="View Mode"></asp:Label>
                            </td>
                            <td valign="middle">
                                <select class="inputtext" id="lstViewMode" onchange="DisplayMessage(),viewMode =  document.getElementById('lstViewMode').value;bindEmpInfo(document.getElementById('lstEmployee').options[document.getElementById('lstEmployee').selectedIndex].value);"
                                    name="lstViewMode" style="border-right: blue thin solid; table-layout: fixed;
                                    border-top: blue thin solid; border-left: blue thin solid; border-bottom: blue thin solid;
                                    border-collapse: collapse; background-color: transparent">
                                    <option value="10" selected>General</option>
                                    <option value="30">Project</option>
                                    <option value="40">Tasks Only</option>
                                </select>
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top">
                <table style="vertical-align: top;" border=0 cellpadding=0 cellspacing=0>
                        <tr>
                            <td valign="top">
                    <img id="btnDelete" title="Delete selected task" style="visibility: hidden" onclick="deleteAssignment();"
                        alt="Delete selected task" src="images/PageTopToolbar/Delete_Task_n.jpg" border="0"
                        name="btnDelete" onmouseover="this.src='images/PageTopToolbar/Delete_Task_o.jpg'"
                        onmouseout="this.src='images/PageTopToolbar/Delete_Task_n.jpg'" onmousedown="this.src='images/PageTopToolbar/Delete_Task_s.jpg'" />
                        </td><td valign="top">
                    <img id="btnCompleteTask" title="Set selected task as closed/open" style="visibility: hidden"
                    onclick="completeAssignment();" alt="Set selected task as closed/open" src="images/PageTopToolbar/Complete_n.jpg"
                    border="0" name="btnCompleteTask" onmouseover="this.src='images/PageTopToolbar/Complete_o.jpg'"
                    onmouseout="this.src='images/PageTopToolbar/Complete_n.jpg'" onmousedown="this.src='images/PageTopToolbar/Complete_s.jpg'" />
                    </td><td valign="top">
                    <img id="btnViewAssAcc" title="Total hours for selected task" style="visibility: hidden"
                    onclick="MM_openBrWindow('frmAssignments.aspx?assignID=' + selectedAssID + '&amp;assignName=' +RemoveSpace(document.getElementById('divTask' + selectedIndex).innerHTML),'','width=600,height=500,toolbar=yes,location=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes')"
                    alt="Total hours for selected task" src="images/PageTopToolbar/Total_Hours_n.jpg"
                    border="0" name="btnViewAssAcc" onmouseover="this.src='images/PageTopToolbar/Total_Hours_o.jpg'"
                    onmouseout="this.src='images/PageTopToolbar/Total_Hours_n.jpg'" onmousedown="this.src='images/PageTopToolbar/Total_Hours_s.jpg'" />
                    </td><td valign="top">
                    <img id="btnMgrsWeeklyReport" onclick="OpenManagerNotes();" src="images/PageTopToolbar/WeeklyReport_n.jpg"
                    name="Button1" alt="Weekly Notes" onmouseover="this.src='images/PageTopToolbar/WeeklyReport_o.jpg'"
                    onmouseout="this.src='images/PageTopToolbar/WeeklyReport_n.jpg'" onmousedown="this.src='images/PageTopToolbar/WeeklyReport_s.jpg'" />
                    </td>
                    </tr>
                    </table>
                </td>
                <td valign="top" style="width: 8%;">
                    <div id="wait" style="visibility: hidden; vertical-align: top;" align="center">
                        <font face="Arial, Helvetica, sans-serif" color="#FFFFFF" size="1">Please wait</font><br/>
                        <img height="7" alt="1" src="images/loading.gif" width="78">
                    </div>
                </td>
            </tr>
            <%--            <tr>
                <td colspan="11" hieght="5" valign="top" style="height: 14px">
                </td>
            </tr>--%>
        </table>
        <table id="SecondToolbarForLaterUse" style="display: none;" cellspacing="0" cellpadding="0"
            width="100%">
            <tr class="ToolBar">
                <td valign="top" style="width: 300px">
                    <img title="Weekly total hours reported" onclick="openReportViewer(2);" alt="Weekly total hours reported"
                        src="images/PageTopToolbar/ReportsIcon_n.jpg" border="0" />
                    <img id="btnPrint" title="Weekly accountability report" style="visibility: hidden"
                        onclick="openReportViewer(1);" alt="Weekly accountability report" src="images/PageTopToolbar/print_n.jpg"
                        border="0" name="btnPrint" />
                    <img id="btnGetTaskSumm" title="Task summary report" onclick="openReportViewer(3);"
                        alt="Task summary report" src="images/PageTopToolbar/task_summary_n.jpg" border="0"
                        name="btnGetTaskSumm" />
                </td>
            </tr>
        </table>
        <table cellspacing="0" cellpadding="10" width="100%" align="center" class="FunctionBlockEmp">
            <tr>
                <td>
                    <table onmousemove="clearForm()" cellspacing="0" cellpadding="0" width="100%" align="center"
                        border="0">
                        <tbody>
                            <!-- Row1 -->
                            <tr height="25">
                                <td style="width: 117px; font-weight: normal; color: black;" align="right" width="117">
                                    <span class="formslabels" style="color: black; font-weight: normal;">Employee &nbsp;</span></td>
                                <td width="40%">
                                    <table width="100%">
                                        <tr>
                                            <td style="height: 24px">
                                                <select class="inputtext" id="lstEmployee" style="width: 312px; color: black; border-right: black 1px solid;
                                                    border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid;"
                                                    onchange="DisplayMessage(),bindEmpInfo(document.getElementById('lstEmployee').options[document.getElementById('lstEmployee').selectedIndex].value);"
                                                    name="lstEmployee">
                                                    <option value="-1" selected></option>
                                                </select>
                                                <asp:DropDownList ID="ddlFilterEmployees" runat="server">
                                                    <asp:ListItem Value="2">All</asp:ListItem>
                                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                                    <asp:ListItem Value="0">Inactive</asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td align="right" style="height: 24px">
                                                <asp:Label ID="Label1" runat="server" CssClass="formslabels" Font-Bold="False" ForeColor="Black"
                                                    Visible="False">Note</asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td rowspan="7" dir="ltr" id="ftbTD">
                                    <table style="width: 100%; height: 100%;">
                                        <tr>
                                            <td valign="top" align="right">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <img id="imgEditNotes" disabled onclick="OpenNotes();" alt="Email" src="images/Buttons/E.Mail_n.jpg"
                                                                onmouseover="this.src='images/Buttons/E.Mail_o.jpg'" onmouseout="this.src='images/Buttons/E.Mail_n.jpg'"
                                                                onmousedown="this.src='images/Buttons/E.Mail_s.jpg'" />
                                                                
                                                                
                                                        </td>
                                                    </tr>
                                                          <tr>
                                                        <td>
                                                        <img id="imgZoomIn" disabled onclick="OpenNotes();" runat="server" src="images/Buttons/ZoomIn_n.jpg" alt="Zoom In"
                                                                 onmouseover="this.src='images/Buttons/ZoomIn_o.jpg'" onmouseout="this.src='images/Buttons/ZoomIn_n.jpg'"
                                                                onmousedown="this.src='images/Buttons/ZoomIn_s.jpg'" style="display: inline;" />
                                                                
                                                            <%--<img id="imgZoomIn" runat="server" src="images/Buttons/ZoomIn_n.jpg" alt="Zoom In"
                                                                onclick="ZoomIn();" onmouseover="this.src='images/Buttons/ZoomIn_o.jpg'" onmouseout="this.src='images/Buttons/ZoomIn_n.jpg'"
                                                                onmousedown="this.src='images/Buttons/ZoomIn_s.jpg'" style="display: inline;" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <img id="imgZoomOut" runat="server" src="images/Buttons/ZoomOut_n.jpg" alt="Zoom Out"
                                                                onclick="ZoomOut();" onmouseover="this.src='images/Buttons/ZoomOut_o.jpg'" onmouseout="this.src='images/Buttons/ZoomOut_n.jpg'"
                                                                onmousedown="this.src='images/Buttons/ZoomOut_s.jpg'" style="display: none;" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <%--<asp:Literal ID="ltrBR1" runat="server" Text="<br />"></asp:Literal>--%>
                                                <%--<asp:Literal ID="ltrBR2" runat="server" Text="<br />"></asp:Literal>--%>
                                            </td>
                                            <td valign="top" align="left">
                                                <ftb:FreeTextBox ID="FreeTextBox1" runat="server" Width="100%" ClientSideTextChanged="saveNote"
                                                    PasteMode="Default" SupportFolder="aspnet_client/FreeTextBox/" ToolbarImagesLocation="ExternalFile"
                                                    JavaScriptLocation="ExternalFile" ButtonImagesLocation="ExternalFile" Focus="False"
                                                    EnableHtmlMode="False" ToolbarLayout="FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline|JustifyLeft,JustifyCenter,JustifyRight|BulletedList,NumberedList,Print"
                                                    Height="100%" ButtonWidth="16" EnableToolbars="True" BreakMode="LineBreak" ButtonOverImage="False">
                                                </ftb:FreeTextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <textarea class="textarea" id="txtNote" style="display: none; width: 18.85%; height: 16px"
                                        disabled onclick="isSheetInEditMode = false;" name="txtNote" rows="1" cols="11"
                                        onchange="saveNote(),checknotelength();" runat="server"></textarea>
                                </td>
                            </tr>
                            <!-- Row2 -->
                            <tr height="25">
                                <td class="formslabels" align="right" style="width: 117px; color: black; font-weight: normal;">
                                    Job title &nbsp;</td>
                                <td width="40%">
                                    <input class="inputtext" id="txtJob" readonly type="text" name="txtJob" width="10%"
                                        style="border-left-color: black; border-bottom-color: black; color: black; border-top-style: solid;
                                        border-top-color: black; border-right-style: solid; border-left-style: solid;
                                        border-right-color: black; border-bottom-style: solid; width: 320px;" />
                                    <%--                        <table width="100%">
                                        <tr>
                                            <td style="height: 29px">
                                            </td>
                                            <td style="height: 29px">
                                                &nbsp;</td>
                                            <td align="right" style="height: 29px">
                                              
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>--%>
                                </td>
                            </tr>
                            <!-- Row3 -->
                            <tr height="25">
                                <td class="formslabels" style="width: 117px; color: black; font-weight: normal;"
                                    align="right" width="117">
                                    Department &nbsp;</td>
                                <td width="40%" style="height: 25px">
                                    <span class="style9">
                                        <input class="inputtext" id="txtDept" readonly type="text" name="txtDept" width="10%"
                                            style="border-left-color: black; border-bottom-color: black; color: black; border-top-style: solid;
                                            border-top-color: black; border-right-style: solid; border-left-style: solid;
                                            border-right-color: black; border-bottom-style: solid; width: 320px;" />
                                    </span>
                                </td>
                            </tr>
                            <!-- Row4 -->
                            <tr height="25">
                                <td class="formslabels" style="height: 25px; color: black; font-weight: normal;"
                                    align="right" width="117">
                                    Calendar &nbsp;</td>
                                <td align="left" width="40%" style="height: 25px; font-weight: normal; color: black;">
                                    <span>
                                        <input class="inputtext" id="txtDate" type="text" onchange="DateClicked=true;bindEmpInfo(document.getElementById('lstEmployee').options[document.getElementById('lstEmployee').selectedIndex].value);"
                                            size="10" value="11/22/2005" name="txtDate" style="border-left-color: black;
                                            border-bottom-color: black; color: black; border-top-style: solid; border-top-color: black;
                                            border-right-style: solid; border-left-style: solid; border-right-color: black;
                                            border-bottom-style: solid">
                                    </span>
                                    <dlcalendar firstday="Su" click_element_id="imgCal" input_element_id="txtDate" tool_tip="Click to choose a date">
                                  <IMG id="imgCal" height="15" alt="Pick a Date" src="../go/images/dlcalendar_1.gif" width="20" name="imgCal"/>
                                </td>
                            </tr>
                            <!-- Row5 -->
                            <!-- Row6 -->
                            <tr>
                                <td style="width: 117px; height: 22px; color: black;" align="right">
                                    <span class="formslabels" style="color: black">
                                        <div id="divResp" style="visibility: hidden; font-weight: normal; color: black;">
                                            Responsibility&nbsp;
                                        </div>
                                    </span>
                                </td>
                                <td style="height: 22px">
                                    <input class="bluetd" id="txtResp" style="visibility: hidden; border: solid 1 #000000;"
                                        readonly type="text" size="50" name="txtResp" />
                                </td>
                            </tr>
                            <!-- Row7 -->
                            <tr>
                                <td style="width: 117px; height: 22px; color: black; font-weight: normal;" align="right">
                                    <span class="formslabels">
                                        <div id="divProject" style="visibility: hidden; font-weight: normal; color: black;">
                                            Project&nbsp;
                                        </div>
                                    </span>
                                </td>
                                <td align="left" style="height: 22px">
                                    <input class="greentd" id="txtProject" style="visibility: hidden; border: solid 1 #000000;"
                                        readonly type="text" size="50" name="txtProject" />
                                </td>
                            </tr>
                            <!-- Row8 -->
                            <tr>
                                <td style="width: 117px; height: 22px; color: black; font-weight: normal;" align="right">
                                    <span class="formslabels">
                                        <div id="divTask" style="visibility: hidden; font-weight: normal; color: black;">
                                            Task&nbsp;
                                        </div>
                                    </span>
                                </td>
                                <td style="height: 6px">
                                    <input class="normattasktd" id="txtTask" style="visibility: hidden; border: solid 1 #000000;"
                                        readonly type="text" name="txtTask" size="50" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </table>
        <table cellspacing="0" cellpadding="0" width="100%" align="center">
            <tr>
                <td>
                    <div id="legend" style="visibility: hidden">
                        <table bordercolor="#003366" cellspacing="0" cellpadding="0" width="100%" align="center"
                            border="1">
                            <tr>
                                <td align="right" width="120" style="height: 18px">
                                    <span class="style18">&nbsp;<strong>Hour based task</strong>&nbsp; </span>
                                </td>
                                <td class="normaltask style18" width="50" bgcolor="#ffffff" style="height: 18px">
                                    &nbsp;</td>
                                <td align="right" width="120" style="height: 18px">
                                    <span class="style19">Count based task&nbsp; </span>
                                </td>
                                <td class="counttask style18" width="50" bgcolor="#ffffaa" style="height: 18px">
                                    &nbsp;</td>
                                <td align="right" width="120" style="height: 18px">
                                    <span class="style19">&nbsp;Complete&nbsp; </span>
                                </td>
                                <td class="completetask style18" width="50" bgcolor="#dfbfdf" style="height: 18px">
                                    &nbsp;</td>
                                <td align="right" width="120" style="height: 18px">
                                    <span class="style18"><strong>&nbsp;&nbsp;N/C Task&nbsp; </strong></span>
                                </td>
                                <td class="nctask" width="50" bgcolor="#ff0000" style="height: 18px">
                                    <span class="style21">##</span></td>
                                <td align="right" width="120" style="height: 18px">
                                    <span class="style19">Responsibility&nbsp; </span>
                                </td>
                                <td class="resp style18" bgcolor="#8dc0dc" style="width: 50px; height: 18px">
                                    &nbsp;</td>
                                <td align="right" width="120" style="height: 18px">
                                    <span class="style18"><strong>&nbsp;&nbsp;Project&nbsp; </strong></span>
                                </td>
                                <td class="project style18" width="50" bgcolor="#aefbbb" style="height: 18px">
                                    &nbsp;</td>
                                <td align="right" width="120" style="height: 18px">
                                    <span class="style18"><strong>Day Off&nbsp; </strong></span>
                                </td>
                                <td class="offday" width="50" style="height: 18px">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="height: 44px">
                    <div id="headerDiv" style="float: left; visibility: hidden; overflow: visible; height: 44px">
                    </div>
                </td>
            </tr>
            <tr>
                <td id="tdSheet" class="FunctionBlock">
                    <%--<div id="sheet" style="BORDER-RIGHT: #ffffff 1px dashed; BORDER-TOP: #ffffff 1px dashed; OVERFLOW: scroll; BORDER-LEFT: #ffffff 1px dashed; BORDER-BOTTOM: #ffffff 1px dashed;"></div>--%>
                    <div id="sheet" style="overflow: scroll; height: 100%;">
                    </div>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td valign="top" style="width: 2%;">
                    <label>
                    </label>
                    <asp:Label ID="LabelToken" runat="server" Visible="False" Width="17px">..</asp:Label><select
                        id="lstJob" style="visibility: hidden" name="lstJob" runat="server"></select>
                    <select id="lstDept" style="visibility: hidden; width: 7px;" name="lstDept" runat="server">
                    </select>
                    <input id="txtHiddenNotes" type="hidden" style="width: 11px" /><input id="txtHiddenWeeklyNotes" type="hidden" style="width: 11px" /><input id="DayNameAndDate" type="hidden" style="width: 11px" /></td>
            </tr>
        </table>
    </form>

    <script language="javascript" src="../go/include/dlcalendar.js" type="text/javascript"></script>

    <span class="style7">

        <script language="javascript" src="../go/include/buttons.js" type="text/javascript"></script>

    </span>
</body>
</html>
