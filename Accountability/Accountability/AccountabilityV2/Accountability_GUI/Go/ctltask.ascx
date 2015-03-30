<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.Go.ctlTask" CodeFile="ctlTask.ascx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<link href="../Acc1.css" type="text/css" rel="stylesheet">
<style type="text/css">.style9 { FONT-SIZE: 10px; COLOR: #000066; FONT-FAMILY: Arial, Helvetica, sans-serif }
	.style12 { FONT-WEIGHT: bold; FONT-SIZE: 18px; COLOR: #003366; FONT-FAMILY: "Times New Roman", Times, serif }
	.btn { BORDER-RIGHT: #000066 1px solid; BORDER-TOP: #000066 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 10px; BORDER-LEFT: #000066 1px solid; COLOR: #000066; BORDER-BOTTOM: #000066 1px solid; FONT-FAMILY: Arial, Helvetica, sans-serif; BACKGROUND-COLOR: #ffffff }
</style>
<table width="600" border="0" align="center" cellpadding="5" cellspacing="5">
    <tr>
        <td class="headertd">
            Add/Edit&nbsp;Task
        </td>
    </tr>
    <tr>
        <td>
            <table width="600" border="0" align="center" id="Table1" class="FunctionBlock">
                <tr>
                    <td align="center" colspan="2">
                        <asp:Label ID="lblMsg" runat="server" Font-Size="11pt" Font-Names="Arial" ForeColor="Firebrick"
                            BackColor="#E0E0E0" CssClass="errmsg"></asp:Label>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 95px" align="left" width="95">
                        <asp:Label ID="lblProject" runat="server" Font-Size="9pt" Font-Names="Arial" ForeColor="White"
                            Font-Bold="True" CssClass="formslabels">Project :</asp:Label></td>
                    <td width="414" class="formslabels" align="left">
                        <asp:Label ID="lblProjectName" runat="server" Font-Size="10pt" Font-Names="Arial"
                            Font-Bold="True" CssClass="formslabels"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 95px" align="left">
                        <asp:Label ID="lblEmp" runat="server" Font-Size="9pt" Font-Names="Arial" ForeColor="White"
                            Font-Bold="True" CssClass="formslabels">Employee :</asp:Label></td>
                    <td class="formslabels" align="left">
                        <asp:Label ID="lblEmpName" runat="server" Font-Size="10pt" Font-Names="Arial" Font-Bold="True"
                            CssClass="formslabels"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 95px; height: 18px" align="left">
                        <asp:Label ID="lblResp" runat="server" Font-Size="9pt" Font-Names="Arial" ForeColor="White"
                            Font-Bold="True" CssClass="formslabels">Responsibility :</asp:Label></td>
                    <td style="height: 18px" class="formslabels" align="left">
                        <asp:Label ID="lblRespName" runat="server" Font-Size="10pt" Font-Names="Arial" Font-Bold="True"
                            CssClass="formslabels"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" colspan="2">
                        <table id="Table2" align="center">
                            <tr>
                                <td>
                                    <table id="Table3" style="border-collapse: collapse" bordercolor="#d4d0c8" cellspacing="2"
                                        cellpadding="0" width="100%" align="center" border="0">
                                        <tr>
                                            <td align="right" class="formslabels">
                                                <span class="formslabels">Task name </span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtName" runat="server" CssClass="inputtext" Width="300px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="formslabels">
                                                <span class="formslabels">Task description </span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDesc" runat="server" CssClass="inputtext" TextMode="MultiLine"
                                                    Width="300px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px" align="right" class="formslabels">
                                                <span class="formslabels">Planned</span></td>
                                            <td style="height: 15px">
                                                <asp:TextBox ID="txtPlanned" runat="server" CssClass="inputtext" Width="100px" MaxLength="5"></asp:TextBox>
                                                <asp:DropDownList ID="lstUnit" runat="server" CssClass="inputtext" Width="80px">
                                                    <asp:ListItem Value="10">Hours</asp:ListItem>
                                                    <asp:ListItem Value="20">Number</asp:ListItem>
                                                    <asp:ListItem Value="30">N/C</asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="formslabels">
                                                <span class="formslabels">Start date </span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtStartDate" runat="server" CssClass="inputtext"
                                                    Width="100px"></asp:TextBox>
                                                <dlcalendar click_element_id="imgCal1" input_element_id="_ctl0_txtStartDate" tool_tip="Click to choose a date"
                                                    firstday="Su"></dlcalendar>
                                                <img src="../go/images/dlcalendar_1.gif" alt="1" width="20" height="15" id="imgCal1"></td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="formslabels">
                                                <span class="formslabels">Due date </span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDueDate" runat="server" CssClass="inputtext"
                                                    Width="100px"></asp:TextBox>
                                                <dlcalendar click_element_id="imgCal2" input_element_id="_ctl0_txtDueDate" tool_tip="Click to choose a date"
                                                    firstday="Su"></dlcalendar>
                                                <img src="../go/images/dlcalendar_1.gif" alt="1" width="20" height="15" id="imgCal2"></td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="formslabels">
                                                <span class="formslabels">
                                                    <asp:Label ID="lblScore" CssClass="formslabels" runat="server" Visible="False">Score</asp:Label></span></td>
                                            <td>
                                                <asp:TextBox ID="txtScore" runat="server" CssClass="inputtext" Width="100px" Visible="False"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="formslabels" colspan="2">
                                                <asp:Button ID="btnSave" runat="server" CssClass="stdSaveBtn" ToolTip="Save Task"
                                                    OnClick="btnSave_Click"></asp:Button>
                                            </td>
                                        </tr>
                                    </table>
                                    <input type="text" style="visibility: hidden" id="txtClose" name="Text2" runat="server"
                                        size="0">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <br>
        </td>
    </tr>
</table>
