<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation" %>
<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.SecurityManagement.ModuleRulesGroup2"
    CodeFile="ModuleRulesGroup2.ascx.cs" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls, Version=1.0.2.226, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<link href="../Acc1.css" type="text/css" rel="stylesheet">
<p align="center">
</p>
<p align="left">
    <table id="Table2" cellspacing="4" cellpadding="0" align="center" border="0" style="width: 376px;
        height: 394px">
        <tr>
            <td class="headertd" align="center" style="height:23px;">
                <strong><font size="2">Module Roles Entities</font></strong></td>
        </tr>
        <tr>
            <td valign="top">
                <table id="Table1" cellspacing="1" cellpadding="1" width="100%" border="0" class="FunctionBlock">
                    <tr>
                        <td valign="top" colspan="2" height="20">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" height="30" class="formslabels" style="width: 108px; height: 30px">
                            Entities
                        </td>
                        <td valign="top" height="30" style="height: 30px">
                            <p>
                                <asp:DropDownList ID="DropDownListEntities" runat="server" CssClass="inputtext" AutoPostBack="True"
                                    DataTextField="EntityName" DataValueField="EntityID" DataMember="SEC_Entities"
                                    DataSource="<%# dataSetEntities1 %>" OnSelectedIndexChanged="DropDownListEntities_SelectedIndexChanged">
                                </asp:DropDownList></p>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" height="30" class="formslabels" style="width: 108px">
                            Entities Items</td>
                        <td valign="top" height="30" style="height: 30px">
                            <p>
                                <asp:DropDownList ID="DropDownListEntitiesItems" runat="server" CssClass="inputtext"
                                    AutoPostBack="True" OnSelectedIndexChanged="DropDownListEntitiesItems_SelectedIndexChanged">
                                </asp:DropDownList></p>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="20%" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="20%" colspan="2" height="40">
                            <p>
                                <asp:Button ID="ButtonSelect" runat="server" CssClass="slectedbutton" Text="Add Access Right"
                                    Width="125px" OnClick="ButtonSelect_Click"></asp:Button>&nbsp;<input onclick="closeWindow()"
                                        type="button" value="Close" class="slectedbutton"></p>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="left" colspan="2" height="175">
                            <p>
                                <asp:DataGrid ID="DataGridRlEnt" runat="server" DataMember="SEC_RuleEntity" DataSource="<%# dataSetRuleEntity1 %>"
                                    PageSize="20" AutoGenerateColumns="False">
                                    <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                                    <ItemStyle CssClass="bsnormaltd"></ItemStyle>
                                    <HeaderStyle CssClass="headertd"></HeaderStyle>
                                    <Columns>
                                        <asp:BoundColumn Visible="False" DataField="RuleEntityID" SortExpression="RuleEntityID"
                                            HeaderText="RuleEntityID"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="RuleEntityDescription" SortExpression="RuleEntityDescription"
                                            HeaderText="Role Entity"></asp:BoundColumn>
                                        <asp:TemplateColumn>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                    </Columns>
                                    <PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
                                </asp:DataGrid></p>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 283px" valign="top">
                <p>
                    &nbsp;</p>
            </td>
        </tr>
    </table>
</p>
