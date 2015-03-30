<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.Go.DaysOff" CodeFile="DaysOff.ascx.cs" %>
<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation" %>
<link href="../Acc1.css" type="text/css" rel="stylesheet">
<table id="Table2" align="center" cellspacing="0" cellpadding="0" width="1063" border="0">
    <tr>
        <td align="center">
            <table cellspacing="5" cellpadding="5" width="200" border="0" class="FunctionBlock">
                <tr>
                    <td class="headertd">
                        All Days Off</td>
                </tr>
                <tr>
                    <td>
                        <table id="Table4" style="width: 352px; height: 216px" cellspacing="5" cellpadding="5"
                            width="352" border="0">
                            <tr>
                                <td>
                                    <p>
                                        <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" Width="329px"
                                            DataSource="<%# dsTasks1 %>" DataMember="GEN_Tasks" BorderColor="White" CellPadding="2"
                                            BorderStyle="None" OnSelectedIndexChanged="ButtonClick">
                                            <SelectedItemStyle CssClass="offday"></SelectedItemStyle>
                                            <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                                            <ItemStyle CssClass="bsnormaltd"></ItemStyle>
                                            <HeaderStyle CssClass="whitetd"></HeaderStyle>
                                            <Columns>
                                                <asp:TemplateColumn>
                                                    <HeaderTemplate>
                                                        Day-Off Type
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" OnClick="ButtonClick" runat="server" CssClass="gridLink"
                                                            CausesValidation="False" Text='<%# DataBinder.Eval(Container, "DataItem.TaskName")%>'>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="TaskDesc" HeaderText="Description"></asp:BoundColumn>
                                                <asp:BoundColumn Visible="False" DataField="TaskID" HeaderText="Task ID"></asp:BoundColumn>
                                                <asp:TemplateColumn>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox1" Width="20px" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                            </Columns>
                                            <PagerStyle CssClass="bsFootertd"></PagerStyle>
                                        </asp:DataGrid></p>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="height: 40px">
                                    <cc1:SecButtons ID="ButtonNew" runat="server" CssClass="stdNewBtn" RuleID="5121"
                                        ToolTip="New Days off Task" OnClick="ButtonNew_Click"></cc1:SecButtons>&nbsp;
                                    <cc1:SecButtons ID="ButtonDelete" runat="server" CssClass="stdDeleteBtn" RuleID="5081"
                                        ToolTip="Delete Selected Day Off" OnClick="ButtonDelete_Click"></cc1:SecButtons></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            &nbsp;</td>
        <td valign="top" align="left">
            &nbsp;
            <p>
                <asp:Panel ID="Panel1" runat="server" Visible="False">
                    <table id="Table1" style="width: 354px; height: 115px" cellspacing="1" cellpadding="1"
                        width="354" align="left" border="0" class="FunctionBlock">
                        <tr>
                            <td class="formslabels" style="width: 79px" align="right" width="79">
                                <font class="formslabels" size="2">Type</font></td>
                            <td width="183">
                                <asp:TextBox ID="TextBoxType" Width="179px" runat="server" CssClass="inputtext"></asp:TextBox><font
                                    size="2"></font></td>
                        </tr>
                        <tr>
                            <td class="formslabels" style="width: 79px; height: 61px" align="right">
                                <font class="formslabels" size="2">Description</font></td>
                            <td>
                                <asp:TextBox ID="TextBoxDesc" runat="server" CssClass="inputtext" TextMode="MultiLine"
                                    Height="53px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 79px">
                            </td>
                            <td>
                                <cc1:SecButtons ID="ButtonAddDayyOff" runat="server" ToolTip="Add" RuleID="5121"
                                    CssClass="stdSaveBtn" OnClick="ButtonAddDayyOff_Click"></cc1:SecButtons>&nbsp;
                                <cc1:SecButtons ID="ButtonUpdateDayyOff" runat="server" ToolTip="Update" RuleID="5080"
                                    CssClass="stdSavebtn" OnClick="ButtonUpdateDayyOff_Click"></cc1:SecButtons>&nbsp;
                                <asp:Button ID="ButtonCancel" runat="server" ToolTip="Cancel" CssClass="stdCancelBtn"
                                    OnClick="ButtonCancel_Click"></asp:Button></td>
                        </tr>
                    </table>
                </asp:Panel>
            </p>
        </td>
    </tr>
</table>
