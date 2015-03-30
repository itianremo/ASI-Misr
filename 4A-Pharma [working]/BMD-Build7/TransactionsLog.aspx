<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="TransactionsLog, App_Web_transactionslog.aspx.cdcab7d2" title=":: 4A-Pharma BMD :: Transactions Log ::" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="Controls/TransButtons.ascx" TagName="TransButtons" TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="upnlBranches" runat="server" Visible="True">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" class="tblStyle" style="width: 100%">
                <tbody>
                    <tr>
                        <td colspan="3" rowspan="3">
                            <table style="width: 100%">
                                <tbody>
                                    <tr>
                                        <td align="left" background="Images/TableHead-BG.jpg" colspan="10" rowspan="1" style="height: 25px">
                                            <asp:Label ID="lbltransLog" runat="server" CssClass="MainfontStyle" Text="Transactions Log"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="10" rowspan="1">
                                            <asp:Panel ID="pnlTransLog" runat="server" Height="650px" HorizontalAlign="Left"
                                                ScrollBars="Auto" Width="100%">
                                                <asp:GridView ID="gvTransLog" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="TransID,TransModuleRefID,TransModuleNewID,TransStatus"
                                                    Width="95%" AllowSorting="True" OnRowDataBound="gvTransLog_RowDataBound" OnSorting="gvTransLog_Sorting">
                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Trans. Request By" DataField="EmpName" SortExpression="EmpName" />
                                                        <asp:BoundField HeaderText="Trans. Date" DataField="TransRequestDate" SortExpression="TransRequestDate" />
                                                        <asp:BoundField HeaderText="Trans. Type" DataField="TransactionType" SortExpression="TransactionType" />
                                                        <asp:TemplateField HeaderText="Trans. Module" SortExpression="TransModule">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="lnkModule" runat="server"
                                                                    Target="_blank" Text='<%# DataBinder.Eval(Container.DataItem, "TransModule") %>'></asp:HyperLink>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Transaction Commands ">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:RadioButtonList ID="rbList" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Selected="True" Value="0">Pending</asp:ListItem>
                                                                    <asp:ListItem Value="1">Accept</asp:ListItem>
                                                                    <asp:ListItem Value="2">Reject</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <asp:Label ID="lblAccepted" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="13px"
                                                                    ForeColor="Green" Text="Accepted" Visible="False"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <RowStyle CssClass="GridNormalRowsStyle" />
                                                    <SelectedRowStyle BackColor="#BCC9B7" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                    <HeaderStyle CssClass="GridHeaderBackStyle" Font-Bold="True" ForeColor="Black" />
                                                    <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                        <td colspan="3" rowspan="1" height="40" align="center">
                            <asp:Button ID="btnCommitTrans" runat="server" CssClass="button" Text="Commit Transactions" OnClick="btnCommitTrans_Click" /></td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

