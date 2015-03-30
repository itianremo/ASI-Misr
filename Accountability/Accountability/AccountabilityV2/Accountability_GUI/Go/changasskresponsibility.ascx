<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.Go.ChangAsskResponsibility" CodeFile="ChangAsskResponsibility.ascx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<link href="../Acc1.css" type="text/css" rel="stylesheet">
<style type="text/css">.style9 { FONT-SIZE: 10px; COLOR: #000066; FONT-FAMILY: Arial, Helvetica, sans-serif }
	.style12 { FONT-WEIGHT: bold; FONT-SIZE: 18px; COLOR: #003366; FONT-FAMILY: "Times New Roman", Times, serif }
	.btn { BORDER-RIGHT: #000066 1px solid; BORDER-TOP: #000066 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 10px; BORDER-LEFT: #000066 1px solid; COLOR: #000066; BORDER-BOTTOM: #000066 1px solid; FONT-FAMILY: Arial, Helvetica, sans-serif; BACKGROUND-COLOR: #ffffff }
</style>
&nbsp;
<table width="600" border="0" align="center" cellpadding="5" cellspacing="5" style="height: 247px">
    <tr>
        <td class="headertd" height="23">
            Change Assignment Responsibility
        </td>
    </tr>
    <tr>
        <td class="FunctionBlock">
            <table border="0" align="center" id="Table1" style="width: 624px; height: 145px">
                <tr>
                    <td align="center" colspan="2" style="height: 20px">
                        <asp:Label ID="lblMsg" runat="server" Font-Size="11pt" Font-Names="Arial" ForeColor="Firebrick"
                            BackColor="#E0E0E0" CssClass="errmsg"></asp:Label>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblEmp" runat="server" Font-Size="9pt" Font-Names="Arial" ForeColor="White"
                            Font-Bold="True" CssClass="formslabels">Employee :</asp:Label></td>
                    <td class="formslabels" style="height: 14px">
                        <asp:Label ID="lblEmpName" runat="server" Font-Size="10pt" Font-Names="Arial" Font-Bold="True"
                            CssClass="formslabels"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblResp" runat="server" Font-Size="9pt" Font-Names="Arial" ForeColor="White"
                            Font-Bold="True" CssClass="formslabels">Old Responsibility :</asp:Label></td>
                    <td style="height: 8px" class="formslabels">
                        <asp:Label ID="lblRespName" runat="server" Font-Size="10pt" Font-Names="Arial" Font-Bold="True"
                            CssClass="formslabels"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 227px" align="right">
                        <asp:Label ID="Label1" CssClass="formslabels" ForeColor="White" Font-Names="Arial"
                            Font-Size="9pt" runat="server" Font-Bold="True">New Responsibility :</asp:Label></td>
                    <td class="formslabels" style="height: 8px">
                        <asp:DropDownList ID="DrpDwnResp" runat="server" DataSource="<%# dsResponsblities1 %>"
                            DataTextField="ResponsName" DataValueField="ResponsID" CssClass="inputtext">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="right">
                        <span class="formslabels">Task name</span></td>
                    <td class="formslabels" style="height: 24px">
                        <asp:TextBox ID="txtName" CssClass="inputtext" runat="server" ReadOnly="True" Width="300px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" colspan="2">
                        <input type="text" style="visibility: hidden" id="txtClose" name="Text2" runat="server"
                            size="0">
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnSave" CssClass="stdSaveBtn" runat="server" ToolTip="Save Task"
                            OnClick="ChangeAssignmentResponsibility"></asp:Button>
                    </td>
                </tr>
            </table>
            <br>
        </td>
    </tr>
</table>
