<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.Go.MFGAdmins" CodeFile="MFGAdmins.ascx.cs" %>
<link href="../Acc1.css" type="text/css" rel="stylesheet">
<p>
</p>
<table id="Table2" style="width: 716px; height: 312px" cellspacing="1" cellpadding="1"
    width="716" align="center" border="0">
    <tr>
        <td class="headertd" style="height:23px;">
            MFG Admins</td>
    </tr>
    <tr>
        <td>
            <table id="TABLE5" style="width: 709px; height: 224px" height="224" cellspacing="0"
                cellpadding="3" width="709" align="center" border="0" runat="server" class="FunctionBlock">
                <tr>
                    <td class="formslabels" style="width: 154px; height: 22px" align="right" colspan="2"
                        height="22">
                    </td>
                    <td style="width: 548px; height: 22px" align="left" height="22">
                        <asp:Label ID="LabelMsg" runat="server" Visible="False" ForeColor="Red" Font-Size="10pt"></asp:Label></td>
                </tr>
                <tr>
                    <td class="formslabels" style="width: 154px; height: 20px" align="right" colspan="2"
                        height="20">
                        <asp:Label ID="LabelMFG" runat="server" Visible="False" CssClass="formslabels">TSN Employees</asp:Label></td>
                    <td style="width: 548px; height: 20px" align="left" height="20">
                        <asp:DropDownList ID="DropDownListTSNEmp" runat="server" Visible="False" AutoPostBack="True"
                            DataSource="<%# dsEmployee1 %>" DataTextField="Fullname" DataValueField="UserID"
                            CssClass="inputtext" OnSelectedIndexChanged="DropDownListTSNEmp_SelectedIndexChanged">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="formslabels" style="width: 154px; height: 31px" align="right" colspan="2"
                        height="31">
                        &nbsp;TSN MFG Admins</td>
                    <td style="width: 548px; height: 31px" align="left" height="31">
                        <asp:DropDownList ID="DropDownListMFGAdmins" runat="server" AutoPostBack="True" DataSource="<%# dataSetMFGAdmins %>"
                            DataTextField="Fullname" DataValueField="MFGUserID" CssClass="inputtext" OnSelectedIndexChanged="DropDownListMFGAdmins_SelectedIndexChanged">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="formslabels" style="width: 154px; height: 27px" align="right" colspan="2"
                        height="27">
                        <p align="right">
                            MFG Admin Name</p>
                    </td>
                    <td style="width: 548px; height: 27px" align="left" height="27">
                        <p>
                            <asp:TextBox ID="TextBoxMFGName" runat="server" CssClass="inputtext" Width="280px"></asp:TextBox></p>
                    </td>
                </tr>
                <tr>
                    <td class="formslabels" style="width: 154px; height: 151px" align="right" colspan="2"
                        height="151">
                    </td>
                    <td style="width: 548px; height: 151px" valign="bottom" align="left">
                        <table id="Table1" style="width: 368px; height: 126px" cellspacing="1" cellpadding="1"
                            width="368" border="0">
                            <tr>
                                <td class="formslabels">
                                    <p align="center">
                                        MFG&nbsp;Employees</p>
                                </td>
                                <td>
                                </td>
                                <td class="formslabels">
                                    <p align="center">
                                        TSN Employees</p>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:ListBox ID="ListBoxMFGEmp" runat="server" CssClass="inputtext" Width="163px"
                                        SelectionMode="Multiple" Height="83px"></asp:ListBox></td>
                                <td align="center">
                                    <asp:Button ID="ButtonIn" runat="server" Width="16px" Text="<" OnClick="ButtonIn_Click">
                                    </asp:Button><asp:Button ID="ButtonOut" runat="server" Text=">" OnClick="ButtonOut_Click">
                                    </asp:Button></td>
                                <td align="left">
                                    <asp:ListBox ID="ListBoxTSNEmp" runat="server" DataSource="<%# dsEmployee1 %>" DataTextField="Fullname"
                                        DataValueField="ContactID" CssClass="inputtext" Width="163px" SelectionMode="Multiple"
                                        Height="83px"></asp:ListBox></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <p align="center">
                &nbsp;</p>
            <p align="center">
                <asp:Button ID="ButtonSave" runat="server" CssClass="slectedbutton" Width="48px"
                    Text="Save" ToolTip="Save MFG Admin Data" OnClick="ButtonSave_Click"></asp:Button>&nbsp;
                &nbsp;
                <asp:Button ID="Delete" runat="server" CssClass="slectedbutton" Width="57px" Text="Delete"
                    ToolTip="Delete MFG Admin" OnClick="Delete_Click"></asp:Button>&nbsp;&nbsp;
                <asp:Button ID="ButtonNew" runat="server" CssClass="slectedbutton" Width="56px" Text="New"
                    ToolTip="New MFG Admin" OnClick="ButtonNew_Click"></asp:Button></p>
        </td>
    </tr>
</table>
<p align="center">
    &nbsp;</p>
