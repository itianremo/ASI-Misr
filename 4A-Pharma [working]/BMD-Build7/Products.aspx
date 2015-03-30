<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Products, App_Web_products.aspx.cdcab7d2" title=":: 4A-Pharma BMD :: Products ::" maintainScrollPositionOnPostBack="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="Controls/TransButtons.ascx" TagName="TransButtons" TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td align="center" colspan="3" rowspan="3">
                <table width="50%">
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <table id="tblsearch" class="tblStyle" style="width: 505px; height: 30px">
                                        <tbody>
                                            <tr align="center" width="50%">
                                                <td align="right">
                                                    <asp:Label ID="lblSearch" runat="server" CssClass="MainfontStyle" Text="Search Products:"></asp:Label></td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtSearchName" runat="server" AutoPostBack="True" CssClass="inputs"
                                                        OnTextChanged="txtSearchName_TextChanged" Width="300px"></asp:TextBox></td>
                                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" BehaviorID="autoCompleteBehavior1"
                                                    CompletionInterval="10" CompletionSetCount="20" DelimiterCharacters=";," EnableCaching="true"
                                                    FirstRowSelected="true" MinimumPrefixLength="1" ServiceMethod="GetCompletionList"
                                                    TargetControlID="txtSearchName" UseContextKey="True">
                                                </cc1:AutoCompleteExtender>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <asp:Label ID="lblNoDataMsg" runat="server" CssClass="MainfontStyle"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:FormView ID="frmViewProducts" runat="server" AllowPaging="True" DataKeyNames="ProductID"
                                        OnPageIndexChanging="frmViewProducts_PageIndexChanging" BackImageUrl="~/Images/BG-1.jpg"
                                        BorderColor="DarkGray" BorderStyle="Solid" BorderWidth="1px">
                                        <PagerSettings FirstPageText="First" LastPageText="Last"
                                            NextPageImageUrl="~/Images/next_n.jpg" NextPageText="Next" PreviousPageImageUrl="~/Images/previous_n.jpg"
                                            PreviousPageText="Previous" FirstPageImageUrl="~/Images/home_n.jpg" LastPageImageUrl="~/Images/End_n.jpg">
                                        </PagerSettings>
                                        <ItemTemplate>
                                            <table cellspacing="0" cellpadding="0" width="500">
                                                <tbody>
                                                    <tr>
                                                        <td colspan="3" rowspan="3">
                                                            <table width="100%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td align="center" colspan="3">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" width="25%">
                                                                            <asp:Label ID="lblProductName" runat="server" CssClass="MainfontStyle" Text="Product Name:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtProductName" runat="server" CssClass="inputs" Text='<%# Bind("ProductName") %>'
                                                                                Width="270px" ReadOnly="True"></asp:TextBox></td>
                                                                        <td align="left">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                                                ControlToValidate="txtProductName" ErrorMessage="Product name is required">*</asp:RequiredFieldValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblForm" runat="server" CssClass="MainfontStyle" Text="Form:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:DropDownList ID="ddlProductsForms" runat="server" CssClass="inputs" Width="275px"
                                                                                DataSourceID="odsProducts" DataTextField="SubCode" DataValueField="SID" Enabled="False">
                                                                            </asp:DropDownList><asp:TextBox ID="txtProductsForms" runat="server" Text='<%# Bind("FormID") %>'
                                                                                Width="15px" Visible="False"></asp:TextBox></td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" align="right">
                                                                            <asp:Label ID="lblComposition" runat="server" CssClass="MainfontStyle" Text="Composition:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtComposition" runat="server" CssClass="inputs" Text='<%# Bind("Composition") %>'
                                                                                Width="270px" ReadOnly="True" Height="86px" TextMode="MultiLine"></asp:TextBox></td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" align="right">
                                                                            <asp:Label ID="lblIndications" runat="server" CssClass="MainfontStyle" Text="Indications:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtIndications" runat="server" CssClass="inputs" Text='<%# Bind("Indications") %>'
                                                                                Width="270px" ReadOnly="True" Height="86px" TextMode="MultiLine"></asp:TextBox></td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblDosage" runat="server" CssClass="MainfontStyle" Text="Dosage:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtDosage" runat="server" CssClass="inputs" Text='<%# Bind("Dosage") %>'
                                                                                Width="270px" ReadOnly="True"></asp:TextBox></td>
                                                                        <td align="left">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                                                                ControlToValidate="txtDosage" ErrorMessage="Dosage is required">*</asp:RequiredFieldValidator>&nbsp;<asp:RegularExpressionValidator
                                                                                    ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ControlToValidate="txtDosage"
                                                                                    ErrorMessage="Invalid dosage" ValidationExpression="\d{1,3}">*</asp:RegularExpressionValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblPackSizes" runat="server" CssClass="MainfontStyle" Text="Pack Sizes:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtPackSize" runat="server" CssClass="inputs" Text='<%# Bind("PackSizes") %>'
                                                                                Width="270px" ReadOnly="True"></asp:TextBox></td>
                                                                        <td align="left">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                                                                ControlToValidate="txtPackSize" ErrorMessage="Pack Size is required">*</asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                                                                                ControlToValidate="txtPackSize" ErrorMessage="Invalid Pack size" ValidationExpression="\d{1,3}">*</asp:RegularExpressionValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblPrice" runat="server" CssClass="MainfontStyle" Text="Price:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtPrice" runat="server" CssClass="inputs" Text='<%# Bind("Price") %>'
                                                                                Width="270px" ReadOnly="True"></asp:TextBox></td>
                                                                        <td align="left">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                                                                ControlToValidate="txtPrice" ErrorMessage="Price is required">*</asp:RequiredFieldValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="StyleValidationSummary">
                                                                            </asp:ValidationSummary>
                                                                        </td>
                                                                        <td align="left">
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
                                                </tbody>
                                            </table>
                                        </ItemTemplate>
                                        <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="PagerfontStyle" />
                                        <EmptyDataTemplate>
                                            <table cellspacing="0" cellpadding="0" width="500">
                                                <tbody>
                                                    <tr>
                                                        <td colspan="3" rowspan="3">
                                                            <table width="100%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td align="center" colspan="3">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" width="25%">
                                                                            <asp:Label ID="lblProductName" runat="server" CssClass="MainfontStyle" Text="Product Name:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtProductName" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                Text='<%# Bind("ProductName") %>' Width="270px"></asp:TextBox></td>
                                                                        <td align="left">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProductName"
                                                                                Display="Dynamic" ErrorMessage="Product name is required">*</asp:RequiredFieldValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblForm" runat="server" CssClass="MainfontStyle" Text="Form:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:DropDownList ID="ddlProductsForms" runat="server" CssClass="inputs" Width="275px"
                                                                                DataSourceID="odsProducts" DataTextField="SubCode" DataValueField="SID" Enabled="False">
                                                                            </asp:DropDownList><asp:TextBox ID="txtProductsForms" runat="server" Text='<%# Bind("FormID") %>'
                                                                                Visible="False" Width="15px"></asp:TextBox></td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" align="right">
                                                                            <asp:Label ID="lblComposition" runat="server" CssClass="MainfontStyle" Text="Composition:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtComposition" runat="server" CssClass="inputs" Height="86px" ReadOnly="True"
                                                                                Text='<%# Bind("Composition") %>' TextMode="MultiLine" Width="270px"></asp:TextBox></td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" align="right">
                                                                            <asp:Label ID="lblIndications" runat="server" CssClass="MainfontStyle" Text="Indications:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtIndications" runat="server" CssClass="inputs" Height="86px" ReadOnly="True"
                                                                                Text='<%# Bind("Indications") %>' TextMode="MultiLine" Width="270px"></asp:TextBox></td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblDosage" runat="server" CssClass="MainfontStyle" Text="Dosage:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtDosage" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("Dosage") %>'
                                                                                Width="270px"></asp:TextBox></td>
                                                                        <td align="left">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDosage"
                                                                                Display="Dynamic" ErrorMessage="Dosage is required">*</asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDosage"
                                                                                Display="Dynamic" ErrorMessage="Invalid dosage" ValidationExpression="\d{1,3}">*</asp:RegularExpressionValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblPackSizes" runat="server" CssClass="MainfontStyle" Text="Pack Sizes:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtPackSize" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("PackSizes") %>'
                                                                                Width="270px"></asp:TextBox></td>
                                                                        <td align="left">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPackSize"
                                                                                Display="Dynamic" ErrorMessage="Pack Size is required">*</asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPackSize"
                                                                                Display="Dynamic" ErrorMessage="Invalid Pack size" ValidationExpression="\d{1,3}">*</asp:RegularExpressionValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblPrice" runat="server" CssClass="MainfontStyle" Text="Price:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtPrice" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("Price") %>'
                                                                                Width="270px"></asp:TextBox></td>
                                                                        <td align="left">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPrice"
                                                                                Display="Dynamic" ErrorMessage="Price is required">*</asp:RequiredFieldValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="StyleValidationSummary" />
                                                                        </td>
                                                                        <td align="left">
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
                                                </tbody>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:FormView>
                            <asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                ForeColor="#004000" Text='Your request for adding new product is in "Pending" phase until Acceptance from your Manager'
                                Visible="False"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:ObjectDataSource ID="odsProducts" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="GetSCodeByGCode" TypeName="Pharma.BLL.LookupsBLL">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="ProductsForms" Name="GeneralCode" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
    </table>
</asp:Content>
