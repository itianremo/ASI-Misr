<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Query.aspx.cs" Inherits="QueryTestForm"
    EnableSessionState="True" Trace="False" Title=":: 4A-Pharma BMD :: Report Creation ::" MasterPageFile="~/MasterPage.master" %>
<%@ Register Assembly="Korzh.WebControls" Namespace="Korzh.WebControls.XControls"
    TagPrefix="kwx" %>
<%@ Register Assembly="Korzh.EasyQuery.WebControls" Namespace="Korzh.EasyQuery.WebControls"
    TagPrefix="keqwc" %>
<%@ Register Src="../Controls/TransButtons.ascx" TagName="TransButtons" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="ErrorLabel" runat="server" Text="______" Font-Bold="True" ForeColor="Red"
        Visible="False" meta:resourcekey="ErrorLabelResource1" Font-Names="Arial" Font-Size="12px"></asp:Label>
    <table border="0" cellpadding="0" cellspacing="5" width="100%" id="table17" style="text-align: left;">
        <tbody>
            <tr>
                <td valign="top" class="tdBorders">
                    <table border="0" cellpadding="0" cellspacing="0" id="table18" style="height: 100%;
                        width: 100%;" align="center">
                        <tbody>
                            <tr>
                                <td style="height: 25px" dir="ltr" background="../Images/TableHead-BG.jpg">
                                    <asp:Label ID="lblQuerydefinition" runat="server" CssClass="MainfontStyle" Text="Query Definition"></asp:Label></td>
                            </tr>
                            <tr>
                                <td bgcolor="#ffffff">
                                    <table border="0" width="100%" id="table19" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td valign="top" dir="ltr">
                                                    <div class="title2" runat="server" id="DivColumns">
                                                        <asp:Label ID="lblResultcolumns" runat="server" CssClass="MainfontStyle" Text="Result columns:"></asp:Label>&nbsp;</div>
                                                    <keqwc:QueryColumnsPanel ID="QueryColumnsPanel1" runat="server" Height="300px" Width="99%"
                                                        BorderStyle="Solid" ShowHeaders="True" CssClass="bodytext" Appearance-ElementCssClass=""
                                                        Appearance-RowCssClass="" BorderColor="DarkGray" BorderWidth="1px" meta:resourcekey="QueryColumnsPanel1Resource1"
                                                        ScrollBars="Auto" Appearance-ScriptMenuStyle-ItemWidth="220">
                                                    </keqwc:QueryColumnsPanel>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <br />
                                    <table border="0" width="100%" id="table22" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td dir="ltr">
                                                    <div class="title2">
                                                        <asp:Label ID="lblQueryconditions" runat="server" CssClass="MainfontStyle" Text="Query Conditions"></asp:Label>&nbsp;</div>
                                                    <keqwc:QueryPanel ID="QueryPanel1" runat="server" Height="300px" Width="99%" BorderWidth="1px"
                                                        ScrollBars="Auto" OnSqlExecute="QueryPanel1_SqlExecute" CssClass="bodytext" OnListRequest="QueryPanel1_ListRequest"
                                                        OnCreateValueElement="QueryPanel1_CreateValueElement" Appearance-ElementCssClass=""
                                                        Appearance-RowCssClass="" Appearance-ScriptMenuStyle-ItemWidth="220" BorderColor="DarkGray"
                                                        BorderStyle="Solid" meta:resourcekey="QueryPanel1Resource1">
                                                    </keqwc:QueryPanel>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td valign="top" class="tdBorders">
                    <div id="divSql" runat="server" visible="true">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;"
                            id="table24">
                            <tbody>
                                <tr>
                                    <td style="height: 25px" background="../Images/TableHead-BG.jpg">
                                        <asp:Label ID="lblSQL" runat="server" CssClass="MainfontStyle" Text="Generated SQL"></asp:Label></td>
                                </tr>
                                <tr style="width: 100%; height: 100%;">
                                    <td bgcolor="#ffffff" valign="top">
                                    <asp:TextBox id="SqlTextBox" runat="server" meta:resourcekey="SqlTextBoxResource1" Width="98%" Height="657px" TextMode="MultiLine" CssClass="inputs"></asp:TextBox></tr>
                            </tbody>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td valign="top" style="" class="tdBorders">
                    <table border="0" cellpadding="0" cellspacing="0" id="table29" style="width: 100%">
                        <tbody>
                            <tr>
                                <td style="height: 25px" background="../Images/TableHead-BG.jpg">
                                    <asp:Label ID="lblPreview" runat="server" CssClass="MainfontStyle" Text="Preview Data"></asp:Label></td>
                            </tr>
                            <tr id="trResultView" runat="server">
                                <td valign="top">
                                    <table border="0" width="100%" id="table30" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td valign="top" dir="ltr">
                                                    <asp:Panel ID="Panel1" runat="server" Height="280px" ScrollBars="Auto" meta:resourcekey="Panel1Resource2"
                                                        Width="100%" BackColor="White">
                                                        <asp:GridView ID="ResultGrid" runat="server" BackColor="White" BorderColor="DarkGray"
                                                            BorderStyle="Solid" DataSourceID="SqlResultDS"
                                                            meta:resourcekey="ResultGridResource1" Width="97%" BorderWidth="1px" CellPadding="2">
                                                            <RowStyle CssClass="GridNormalRowsStyle" />
                                                            <HeaderStyle CssClass="GridHeaderBackStyle" />
                                                            <AlternatingRowStyle CssClass="AltRowStyle" />
                                                        </asp:GridView>
                                                    <asp:Label ID="ResultLabel" runat="server" Text="Label" Visible="False" Font-Bold="False" Height="4px" Width="15px" meta:resourcekey="ResultLabelResource1" CssClass="StyleValidationSummary"></asp:Label></asp:Panel>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td valign="top" class="tdBorders" width="350">
                        <table border="0" cellpadding="0" cellspacing="0" id="Table2" style="width: 100%">
                            <tr>
                                <td style="height: 25px" background="../Images/TableHead-BG.jpg">
                                    <asp:Label ID="lblQueryText" runat="server" CssClass="MainfontStyle" Text="Query Text"></asp:Label></td>
                            </tr>
                            <tr>
                                <td bgcolor="#ffffff" class="tdBorders" valign="top" height="280">
                                    <asp:Literal ID="Literal1" runat="server" meta:resourcekey="Literal1Resource1"></asp:Literal></td>
                            </tr>
                        </table>
                </td>
            </tr>
            <tr>
                <td align="center" bgcolor="#ffffff" colspan="2" valign="middle" class="tdBorders" style="height: 40px">
                                                <asp:Button ID="UpdateResultBtn" runat="server" OnClick="UpdateResultBtn_Click" Text="Preview"
                                                    Width="80px" CssClass="button" />
                                                <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" Width="80px" CssClass="button" />
                                                <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Text="Save"
                                                    Width="80px" CssClass="button" /></td>
            </tr>
        </tbody>
    </table>
    <asp:SqlDataSource ID="SqlResultDS" runat="server" ConnectionString="<%$ ConnectionStrings:PharmaConnectionString %>"
        ProviderName="<%$ ConnectionStrings:PharmaConnectionString.ProviderName %>"></asp:SqlDataSource>
</asp:Content>
