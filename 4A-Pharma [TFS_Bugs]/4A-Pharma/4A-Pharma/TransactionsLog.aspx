<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TransactionsLog.aspx.cs" Inherits="TransactionsLog" Title=":: 4A-Pharma BMD :: Transactions Log ::" %>
<%@ Register Src="Controls/TransButtons.ascx" TagName="TransButtons" TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
</script> 

    <asp:UpdatePanel ID="upnlBranches" runat="server" Visible="True">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" class="tblStyle" style="width: 100%">
                <tbody>
                    <tr>
                        <td colspan="3" rowspan="3">
                            <table style="width: 100%">
                                <tbody>
                                    <tr>
                                        <td align="center" background="Images/TableHead-BG.jpg" colspan="10" rowspan="1" style="height: 25px">
                                            <asp:Label ID="lbltransLog" runat="server" CssClass="MainfontStyle" Text="Transactions Log"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="10" rowspan="1">
                                            <asp:Panel ID="pnlTransLog" runat="server" Height="650px" HorizontalAlign="Left"
                                                ScrollBars="Auto" Width="100%">
                                                <asp:GridView ID="gvTransLog" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="TransID,TransModuleRefID,TransModuleNewID,TransStatus"
                                                    Width="98%" AllowSorting="True" OnRowDataBound="gvTransLog_RowDataBound" OnSorting="gvTransLog_Sorting" AllowPaging="True" PageSize="100" OnPageIndexChanging="gvTransLog_PageIndexChanging" EmptyDataText="No Transactions Found...">
                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Trans. Request By" DataField="EmpName" SortExpression="EmpName" />
                                                        <asp:TemplateField HeaderText="Trans. Date" SortExpression="TransRequestDate">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTransRequestDate" runat="server" Text='<%#((DateTime)Eval("TransRequestDate")).AddHours(int.Parse(System.Configuration.ConfigurationManager.AppSettings["TimeZoneUTCPlus"].ToString().Trim())) %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Trans. Type" DataField="TransactionType" SortExpression="TransType" />
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
                                                    <PagerStyle BackColor="#E0E0E0" HorizontalAlign="Center" CssClass="PagerfontStyle" VerticalAlign="Middle" />
                                                    <HeaderStyle CssClass="GridHeaderBackStyle" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                                                    <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                                </asp:GridView>
            <asp:ObjectDataSource ID="odsTransactions" runat="server" EnablePaging="True" OldValuesParameterFormatString="original_{0}"
                SelectCountMethod="MaxRowCount" SelectMethod="GetTransactions" TypeName="Pharma.BMD.BLL.TransactionLogBLL">
                <SelectParameters>
                    <asp:Parameter DefaultValue="" Name="startRowIndex" Type="Int32" />
                    <asp:ControlParameter ControlID="gvTransLog" DefaultValue="25" Name="maximumRows"
                        PropertyName="PageSize" Type="Int32" />
                    <asp:SessionParameter DefaultValue="" Name="OrderBy" SessionField="OrderBY" />
                    <asp:SessionParameter Name="OrderByDirection" SessionField="OrderByDirection" />
                </SelectParameters>
            </asp:ObjectDataSource>
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
                        <td colspan="3" rowspan="1" height="40" align="center" style="height: 30px" background="Images/TableHead-BG.jpg">
                            <asp:Button ID="btnCommitTrans" runat="server" CssClass="button" Text="Commit Transactions" OnClick="btnCommitTrans_Click" /></td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

