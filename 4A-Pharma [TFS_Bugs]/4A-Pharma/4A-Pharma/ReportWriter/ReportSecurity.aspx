<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportSecurity.aspx.cs" Inherits="ReportModification"
    MasterPageFile="~/MasterPage.master" Title="Access Rights" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="divAll" runat="server" style="height: 100%; width: 100%" align="center">
        <div align="center" style="width: 100%">
            <asp:UpdatePanel id="up1"  runat="server">
        <ContentTemplate>
            <table id="TableData" width="100%" align="center">
                <tbody style="width: 100%">
                    <tr>
                        <td style="text-align: left;">
                            <table>
                                <tr style="visibility:hidden;">
                                    <td style="width: 23px; height: 26px; text-align: left" valign="top" align="right">
                                        Application</td>
                                    <td style="width: 43px; height: 26px; text-align: left" valign="top">
                                        <asp:Label ID="lblApplicationName" runat="server" Text="Label"></asp:Label>
                                        <asp:DropDownList ID="ddlApplications" runat="server" Width="176px" Visible="False"
                                            OnInit="ddlApplications_Init">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 23px; height: 26px; text-align: left" valign="top" align="right">
                                        Report</td>
                                    <td style="width: 43px; height: 26px; text-align: left" valign="top">
                                        <asp:DropDownList ID="ddlReports" runat="server" Width="174px" OnSelectedIndexChanged="ddlReports_SelectedIndexChanged"
                                            AutoPostBack="True" DataValueField="REP_RepID" DataTextField="REP_RepName" DataSourceID="SqlDataSource2">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" SelectCommand="SELECT [REP_RepID], [REP_RepName] FROM [REP_Reports] WHERE ([REP_Project] = @REP_Project)"
                                            ConnectionString="<%$ ConnectionStrings:PharmaConnectionString %>">
                                            <SelectParameters>
                                                <asp:SessionParameter Name="REP_Project" SessionField="VsApplicationID" Type="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 23px; height: 26px; text-align: left" valign="top" align="right">
                                        Type</td>
                                    <td style="width: 43px; height: 26px; text-align: left" valign="top">
                                        <asp:DropDownList ID="ddlSecurityType" runat="server" Width="172px" OnSelectedIndexChanged="ddlSecurityType_SelectedIndexChanged"
                                            AutoPostBack="True" DataValueField="REP_TypeID" DataTextField="REP_Type" DataSourceID="SqlDataSource1">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="SELECT [REP_TypeID], [REP_Type] FROM [REP_ReportTypes]"
                                            ConnectionString="<%$ ConnectionStrings:PharmaConnectionString %>"></asp:SqlDataSource>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center;" valign="top">
                            Report Access Rights
                            <div id="DivReportRights" runat="server" style="overflow: auto; height: 400px; width: 100%;">
                                <asp:GridView ID="GridView1" DataKeyNames="UserID" runat="server" Width="96%" AutoGenerateColumns="False">
                                    <FooterStyle BackColor="#EFF3FB" Font-Bold="True" ForeColor="White" />
                                    <RowStyle CssClass="GridNormalRowsStyle" />
                                    <PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle Font-Bold="True" ForeColor="Black" CssClass="GridHeaderBackStyle" />
                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                    <Columns>
                                        <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" Visible="False" />
                                        <asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="UserName">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="View" SortExpression="View">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk1" runat="server" Checked='<%# Bind("View") %>'></asp:CheckBox>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Modify" SortExpression="Modify">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk2" runat="server" Checked='<%# Bind("Modify") %>'></asp:CheckBox>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                        <td style="text-align: center;" valign="top">
                            Application Access Rights
                            <div style="overflow: auto; width: 100%; height: 400px" dir="ltr" id="divGridView2"
                                runat="server">
                                <asp:GridView ID="GridView2" DataKeyNames="UserID" runat="server" Width="96%" AutoGenerateColumns="False">
                                    <FooterStyle BackColor="#EFF3FB" Font-Bold="True" ForeColor="White" />
                                    <RowStyle CssClass="GridNormalRowsStyle" />
                                    <PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle Font-Bold="True" ForeColor="Black" CssClass="GridHeaderBackStyle" />
                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                    <Columns>
                                        <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" Visible="False" />
                                        <asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="UserName">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Create New Report" SortExpression="Create New Report">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk1" runat="server" Checked='<%# Bind("CreateNewReport") %>'></asp:CheckBox>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center;" valign="top">
                            <div id="divSaveReport" runat="server" style="width: 100%" align="center">
                                <asp:Button ID="ButtonSaveReprt" OnClick="ButtonSaveReprt_Click" runat="server" Height="25"
                                    Width="76px" Text="Save"></asp:Button>
                            </div>
                        </td>
                        <td style="text-align: center;" valign="top">
                            <div style="width: 100%" id="divSaveButton" align="center">
                                <asp:Button ID="btnSaveGeneralRules" OnClick="btnSaveGeneralRules_Click" runat="server"
                                    Text="Save" Width="67px"></asp:Button>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            </ContentTemplate>
    </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
