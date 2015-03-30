<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageData.aspx.cs" Inherits="ManageData" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table align="center" border="0" cellpadding="0" cellspacing="0" width="874">
        <tr>
            <td align="right" class="header_txt_gray">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                <span class="header_txt_gray"></span>
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="868">
                    <tr>
                        <td valign="top" width="12" style="height: 38px">
                            </td>
                        <td style="height: 38px">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="right" background="../images/bg_tb1_2.gif" class="header_txt_gray">
                                        ≈œ«—… ﬁ«⁄œ… «·»Ì«‰« &nbsp;</td>
                                    <td valign="top" width="16">
                                        </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top" width="12" style="height: 38px">
                            </td>
                    </tr>
                    <tr>
                        <td background="../images/a1.jpg" width="12">
                        </td>
                        <td align="right" class="main" valign="top">
                            <table class="Standard" align="center">
                                <tr>
                                    <td style="height: 200px;">
                                    </td>
                                    <td style="height: 200px; text-align: center;" align="center">
                                        <asp:Button ID="btnGetDB" runat="server" CssClass="Button" OnClick="btnGetDB_Click"
                                            Text="«Ã‹·‹‹‹‹‹»" Width="120px" /></td>
                                    <td style="height: 200px;" align="center"><asp:CheckBox id="cbxBackupOnMis" runat="server" Text="Save to misserver" /></td>
                                </tr>
                                <tr>
                                    <td style="height: 200px">
                                    </td>
                                    <td align="center" style="height: 200px; text-align: center"><asp:Button ID="btnSetDB" runat="server" CssClass="Button" OnClick="btnSetDB_Click"
                                            Text="—›‹‹‹‹‹⁄" Width="120px" /></td>
                                    <td style="height: 200px" align="center">
                                        <asp:CheckBox id="cbxKillAllConns" runat="server" Text="ﬁÿ⁄ «·« ’«·«  ⁄‰ ﬁ«⁄œ… «·»Ì«‰« ">
                                        </asp:CheckBox></td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="center" style="text-align: center">
                                        <asp:Label ID="lblMsg" runat="server"></asp:Label></td>
                                    <td align="center">
                                        <asp:TextBox ID="txtConnName" runat="server"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                        <td background="../images/a2.jpg" width="12">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="12">
                            </td>
                        <td background="../images/ab1.jpg" valign="top">
                        </td>
                        <td valign="top" width="12">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

