<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation" %>
<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.SecurityManagement.Users" CodeFile="Users.ascx.cs" %>
<link href="../Acc1.css" type="text/css" rel="stylesheet">
<p>
    <div align="center">
        <asp:Panel ID="Panel4" dir="ltr" Height="254px" runat="server" Width="619px">
            <p>
            </p>
            <p>
                &nbsp;</p>
            <p>
                <table id="Table1" style="width: 300px; height: 187px" cellspacing="1" cellpadding="1"
                    width="300" border="0" class="FunctionBlock">
                    <tr>
                        <td class="whitetd">
                            User Accounts</td>
                    </tr>
                    <tr>
                        <td >
                            <table id="Table2" style="width: 607px; height: 180px" cellspacing="0" cellpadding="0"
                                width="607" align="center" border="0">
                                <tr>
                                    <td class="formslabels" style="width: 287px" align="right">
                                        <font class="formslabels" size="2">All Users</font>&nbsp;</td>
                                    <td style="width: 148px; height: 22px" align="left" colspan="2">
                                        <p>
                                            &nbsp;
                                            <asp:DropDownList ID="DropDownListUsers" runat="server" CssClass="textlist" AutoPostBack="True"
                                                OnSelectedIndexChanged="DropDownListUsers_SelectedIndexChanged">
                                            </asp:DropDownList></p>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 287px">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formslabels" style="width: 287px; height: 35px" align="right">
                                        <font class="formslabels" size="2">User Name </font>
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:TextBox ID="TextBoxUserName" runat="server" CssClass="inputtext" MaxLength="15"></asp:TextBox><font
                                            size="2"></font></td>
                                </tr>
                                <tr>
                                    <td class="formslabels" style="width: 287px; height: 35px" align="right">
                                        <font class="formslabels" size="2">Password </font>
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="inputtext" MaxLength="20"
                                            TextMode="Password"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="formslabels" style="width: 287px; height: 12px" align="right">
                                        <font class="formslabels" size="2">Confirm Password </font>
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:TextBox ID="TextBoxConfirm" runat="server" CssClass="inputtext" MaxLength="20"
                                            TextMode="Password"></asp:TextBox>&nbsp;
                                        <asp:CompareValidator ID="CompareValidator1" Width="189px" runat="server" ControlToValidate="TextBoxConfirm"
                                            ControlToCompare="TextBoxPassword" ErrorMessage="passwords are not equal" Font-Size="10pt"></asp:CompareValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 287px">
                                    </td>
                                    <td style="width: 430px" colspan="2">
                                        <font class="formslabels" size="2">
                                            <asp:CheckBox ID="CheckAdmin" runat="server" Text="Administrator"></asp:CheckBox></font></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 17px" colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Button ID="btnNewUser" runat="server" CssClass="slectedbutton" Text="New User"
                                            OnClick="btnNewUser_Click"></asp:Button>
                                        <cc1:SecButtons ID="ButtonAddUser" runat="server" CssClass="slectedbutton" Text="Add"
                                            Visible="False" OnClick="ButtonAddUser_Click"></cc1:SecButtons>
                                        <cc1:SecButtons ID="ButtonUpdateUser" runat="server" CssClass="slectedbutton" Text="Update"
                                            Visible="False" OnClick="ButtonUpdateUser_Click"></cc1:SecButtons></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lblMSG" runat="server" Visible="False"></asp:Label>
        </asp:Panel>
    </div>
    <p>
    </p>
