<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="MedicalAccounts, App_Web_medicalaccounts.aspx.cdcab7d2" title=":: 4A-Pharma BMD :: Medical Accounts ::" maintainScrollPositionOnPostBack="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="Controls/TransButtons.ascx" TagName="TransButtons" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td align="center" colspan="3" rowspan="3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:FormView ID="frmViewMedicalAccounts" runat="server" BorderColor="DarkGray" BorderStyle="Solid"
                            BorderWidth="1px" BackImageUrl="~/Images/BG-1.jpg" OnPageIndexChanging="frmViewMedicalAccounts_PageIndexChanging"
                            DataKeyNames="MedicalAccountID" AllowPaging="True" Width="100%" OnDataBound="frmViewMedicalAccounts_DataBound">
                            <PagerSettings FirstPageImageUrl="~/Images/home_n.jpg" FirstPageText="First" LastPageImageUrl="~/Images/End_n.jpg"
                                LastPageText="Last" NextPageImageUrl="~/Images/next_n.jpg"
                                NextPageText="Next" PreviousPageImageUrl="~/Images/previous_n.jpg" PreviousPageText="Previous">
                            </PagerSettings>
                            <ItemTemplate>
                                <table style="width: 100%">
                                    <tbody>
                                        <tr>
                                            <td colspan="3" rowspan="1" valign="top" align="center">
                                                        <table id="tblsearch" class="tblStyle" style="width: 100%; height: 30px">
                                                            <tbody>
                                                                <tr align="center" width="50%">
                                                                    <td align="right" style="width: 40%">
                                                                        <asp:Label ID="lblSearch" runat="server" CssClass="MainfontStyle" Text="Search Medical Accounts:"></asp:Label></td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtSearchName" runat="server" AutoPostBack="True" CssClass="inputs"
                                                                            OnTextChanged="txtSearchName_TextChanged" Width="300px"></asp:TextBox>
                                                                    </td>
                                                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" BehaviorID="autoCompleteBehavior1"
                                                                        CompletionInterval="10" CompletionSetCount="20" DelimiterCharacters=";," EnableCaching="true"
                                                                        FirstRowSelected="true" MinimumPrefixLength="1" ServiceMethod="GetCompletionList"
                                                                        TargetControlID="txtSearchName" UseContextKey="True">
                                                                    </cc1:AutoCompleteExtender>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" width="45%" rowspan="1">
                                            </td>
                                            <td width="5%" rowspan="1">
                                            </td>
                                            <td width="50%" rowspan="1">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" rowspan="13">
                                                <table cellspacing="0" cellpadding="0" width="450">
                                                    <tbody>
                                                        <tr>
                                                            <td colspan="3" rowspan="3">
                                                                <table width="100%">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblName" runat="server" CssClass="MainfontStyle" Text="Name :"></asp:Label></td>
                                                                            <td align="left">
                                                                                <asp:TextBox ID="txtName" runat="server" CssClass="inputs" Text='<%# Bind("Name") %>'
                                                                                    ReadOnly="True" Width="270px"></asp:TextBox>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name is required"
                                                                                    Display="Dynamic" ControlToValidate="txtName">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblSubordination" runat="server" CssClass="MainfontStyle" Text="Subordination :"></asp:Label></td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="ddlSubordination" runat="server" CssClass="inputs" Width="275px"
                                                                                    Enabled="False" DataValueField="SID" DataTextField="SubCode" DataSourceID="odsSubordination">
                                                                                </asp:DropDownList><asp:TextBox ID="txtSubordination" runat="server" Text='<%# Bind("SubordinationID") %>'
                                                                                    Width="15px" Visible="False"></asp:TextBox></td>
                                                                            <td style="text-align: left">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblGov" runat="server" CssClass="MainfontStyle" Text="Gov:"></asp:Label></td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="ddlGov" runat="server" CssClass="inputs" Width="275px" Enabled="False"
                                                                                    DataValueField="SID" DataTextField="SubCode" DataSourceID="odsGov" SelectedValue='<%# Bind("GovID") %>'
                                                                                    OnSelectedIndexChanged="ddlGov_SelectedIndexChanged" OnDataBound="ddlGov_DataBound"
                                                                                    AutoPostBack="True">
                                                                                </asp:DropDownList><asp:TextBox ID="txtGov" runat="server" Text='<%# Bind("GovID") %>'
                                                                                    Width="15px" Visible="False"></asp:TextBox></td>
                                                                            <td style="text-align: left">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblCity" runat="server" CssClass="MainfontStyle" Text="City:"></asp:Label></td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="ddlCity" runat="server" CssClass="inputs" Width="275px" Enabled="False"
                                                                                    DataValueField="CityID" DataTextField="City">
                                                                                </asp:DropDownList><asp:TextBox ID="txtCity" runat="server" Text='<%# Bind("CityID") %>'
                                                                                    Width="15px" Visible="False"></asp:TextBox></td>
                                                                            <td style="text-align: left">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblArea" runat="server" CssClass="MainfontStyle" Text="Area:"></asp:Label></td>
                                                                            <td align="left">
                                                                                <asp:TextBox ID="txtArea" runat="server" CssClass="inputs" Text='<%# Bind("Area") %>'
                                                                                    ReadOnly="True" Width="270px"></asp:TextBox></td>
                                                                            <td style="text-align: left">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Area is required"
                                                                                    Display="Dynamic" ControlToValidate="txtArea">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblAddress" runat="server" CssClass="MainfontStyle" Text="Address: "></asp:Label></td>
                                                                            <td align="left">
                                                                                <asp:TextBox ID="txtAddress" runat="server" CssClass="inputs" Text='<%# Bind("Name") %>'
                                                                                    ReadOnly="True" Width="270px"></asp:TextBox></td>
                                                                            <td style="text-align: left">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Address is required"
                                                                                    Display="Dynamic" ControlToValidate="txtAddress">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblBrick" runat="server" CssClass="MainfontStyle" Text="Brick :"></asp:Label></td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="ddlBrick" runat="server" CssClass="inputs" Width="275px" Enabled="False"
                                                                                    DataValueField="BrickID" DataTextField="BrickName" DataSourceID="odsBrick">
                                                                                </asp:DropDownList><asp:TextBox ID="txtBrickID" runat="server" Text='<%# Bind("BrickID") %>'
                                                                                    Width="15px" Visible="False"></asp:TextBox></td>
                                                                            <td style="text-align: left">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblPhone" runat="server" CssClass="MainfontStyle" Text="Phone:"></asp:Label></td>
                                                                            <td align="left">
                                                                                <asp:TextBox ID="txtPhone1" runat="server" CssClass="inputs" Text='<%# Bind("Phone") %>'
                                                                                    ReadOnly="True" Width="270px"></asp:TextBox></td>
                                                                            <td style="text-align: left">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblMobile" runat="server" CssClass="MainfontStyle" Text="Mobile:"></asp:Label></td>
                                                                            <td align="left">
                                                                                <asp:TextBox ID="txtMobile" runat="server" CssClass="inputs" Text='<%# Bind("Mobile") %>'
                                                                                    ReadOnly="True" Width="270px"></asp:TextBox></td>
                                                                            <td style="text-align: left">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblPostalCode" runat="server" CssClass="MainfontStyle" Text="Postal Code :"></asp:Label></td>
                                                                            <td align="left">
                                                                                <asp:TextBox ID="txtPostalCode" runat="server" CssClass="inputs" Text='<%# Bind("PostalCode") %>'
                                                                                    ReadOnly="True" Width="270px"></asp:TextBox></td>
                                                                            <td style="text-align: left">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblICU" runat="server" CssClass="MainfontStyle" Text="ICU :"></asp:Label></td>
                                                                            <td align="left">
                                                                                <asp:TextBox ID="txtICU" runat="server" CssClass="inputs" Text='<%# Bind("ICUNO") %>'
                                                                                    ReadOnly="True" Width="270px"></asp:TextBox>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Invalid ISU NO"
                                                                                    Display="Dynamic" ControlToValidate="txtICU" ValidationExpression="^0*[1-9]*[0-9]*$">*</asp:RegularExpressionValidator>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtICU"
                                                                                    Display="Dynamic" ErrorMessage="ICU is required">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblComment" runat="server" CssClass="MainfontStyle" Text="Served Pts./ Month:"></asp:Label></td>
                                                                            <td align="left">
                                                                                <asp:TextBox ID="txtNoOfServed" runat="server" CssClass="inputs" Text='<%# Bind("No_Medically_Served_Pts") %>'
                                                                                    ReadOnly="True" Width="270px"></asp:TextBox>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="Invalid medically served pts/month"
                                                                                    Display="Dynamic" ControlToValidate="txtNoOfServed" ValidationExpression="^0*[1-9]*[0-9]*$">*</asp:RegularExpressionValidator>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtNoOfServed"
                                                                                    Display="Dynamic" ErrorMessage="Served Pts./ Month is required">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td align="center">
                                                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="StyleValidationSummary" />
                                                                            </td>
                                                                            <td style="text-align: left">
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
                                                <asp:ObjectDataSource ID="odsSubordination" runat="server" TypeName="Pharma.BLL.LookupsBLL"
                                                    SelectMethod="GetSCodeByGCode" OldValuesParameterFormatString="original_{0}">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="Subordination" Name="GeneralCode" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                                <asp:ObjectDataSource ID="odsGov" runat="server" TypeName="Pharma.BLL.LookupsBLL"
                                                    SelectMethod="GetSCodeByGCode" OldValuesParameterFormatString="original_{0}">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="Gov" Name="GeneralCode" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                                <asp:ObjectDataSource ID="odsBrick" runat="server" TypeName="Pharma.BLL.LookupsBLL"
                                                    SelectMethod="SelectBricks" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
                                            </td>
                                            <td rowspan="13">
                                            </td>
                                            <td rowspan="13">
                                               
                                                        <table>
                                                            <tbody>
                                                                <tr>
                                                                    <td style="height: 97px" colspan="3" rowspan="2">
                                                                        <table style="width: 500px" cellspacing="0" cellpadding="0" class="tblStyle">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td valign="middle" colspan="3" rowspan="3">
                                                                                        <table width="100%">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td align="left" colspan="8" rowspan="1">
                                                                                                        <asp:Label ID="lblMedicalService" runat="server" CssClass="MainfontStyle" Text="Medical Service Financial Limits :"></asp:Label></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="height: 45px" align="right" colspan="1" rowspan="3">
                                                                                                        <asp:Label ID="lblRX" runat="server" CssClass="MainfontStyle" Text="RX :"></asp:Label></td>
                                                                                                    <td style="height: 45px" align="left" colspan="1" rowspan="3">
                                                                                                        <asp:TextBox ID="txtRXFinancialLimits" runat="server" CssClass="inputs" Text='<%# Bind("RX_Financial_Limits") %>'
                                                                                                            ReadOnly="True" Width="100px"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid daily RX"
                                                                                                            Display="Dynamic" ControlToValidate="txtRXFinancialLimits" ValidationExpression="^\d+(\.\d*)?$">*</asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                                                                                ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtRXFinancialLimits"
                                                                                                                Display="Dynamic" ErrorMessage="RX: Day is required">*</asp:RequiredFieldValidator></td>
                                                                                                    <td style="height: 45px" align="right" colspan="1" rowspan="3">
                                                                                                        <asp:Label ID="lblMonthly" runat="server" CssClass="MainfontStyle" Text="Monthly :"></asp:Label></td>
                                                                                                    <td style="height: 45px" align="left" colspan="1" rowspan="3">
                                                                                                        <asp:TextBox ID="txtRXFinancialLimitsMonthly" runat="server" CssClass="inputs" Text='<%# Bind("Monthly_Financial_Limits") %>'
                                                                                                            ReadOnly="True" Width="100px"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid monthly RX"
                                                                                                            Display="Dynamic" ControlToValidate="txtRXFinancialLimitsMonthly" ValidationExpression="^\d+(\.\d*)?$">*</asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                                                                                ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtRXFinancialLimitsMonthly"
                                                                                                                Display="Dynamic" ErrorMessage="RX: Monthly is required">*</asp:RequiredFieldValidator></td>
                                                                                                    <td style="width: 52px; height: 45px" align="right" colspan="1" rowspan="3">
                                                                                                        <asp:Label ID="lblAnnual" runat="server" CssClass="MainfontStyle" Text="Annual :"></asp:Label></td>
                                                                                                    <td style="height: 45px" align="left" colspan="3" rowspan="3">
                                                                                                        <asp:TextBox ID="txtRXFinancialLimitsAnnual" runat="server" CssClass="inputs" Text='<%# Bind("Annual_Financial_Limits") %>'
                                                                                                            ReadOnly="True" Width="100px"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid annuel RX"
                                                                                                            Display="Dynamic" ControlToValidate="txtRXFinancialLimitsAnnual" ValidationExpression="^\d+(\.\d*)?$">*</asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                                                                                ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtRXFinancialLimitsAnnual"
                                                                                                                Display="Dynamic" ErrorMessage="RX: Annual is required">*</asp:RequiredFieldValidator></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                </tr>
                                                                                                <tr>
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
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="3">
                                                                        <table style="width: 500px" cellspacing="0" cellpadding="0" class="tblStyle">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td colspan="3" rowspan="3">
                                                                                        <table width="100%">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td valign="top" align="left" colspan="8" rowspan="1">
                                                                                                        <asp:Label ID="lblDrugDelivery" runat="server" CssClass="MainfontStyle" Text="Drug Delivery:"></asp:Label></td>
                                                                                                    <td valign="top" align="left" colspan="2" rowspan="1" height="25">
                                                                                                        <asp:CheckBox ID="cbxInternalPharmacy" runat="server" CssClass="MainfontStyle" Text="Internal Pharmacy"
                                                                                                            Enabled="False" Checked='<%# Bind("Drug_Delivery_Internal") %>'></asp:CheckBox>
                                                                                                        <asp:CheckBox ID="cbxExternalPharmacy" runat="server" CssClass="MainfontStyle" Text="External Pharmacy"
                                                                                                            Enabled="False" Checked='<%# Bind("Drug_Delivery_External") %>'></asp:CheckBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" colspan="10" rowspan="1">
                                                                                                        <asp:Panel ID="pnlgvPharmacies" runat="server" Height="250px" ScrollBars="Auto" Width="100%" HorizontalAlign="Left">
                                                                                                            <asp:GridView ID="gvPharmacies" runat="server" Width="95%" AutoGenerateColumns="False"
                                                                                                                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                                                                                                CellPadding="0" DataKeyNames="PharmacyID" OnRowDataBound="gvPharmacies_RowDataBound">
                                                                                                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                                                                <Columns>
                                                                                                                    <asp:BoundField DataField="Name" HeaderText="Pharmacy Name" SortExpression="Name">
                                                                                                                        <HeaderStyle HorizontalAlign="Center" Width="90%" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                                                    </asp:BoundField>
                                                                                                                    <asp:TemplateField HeaderText="Select">
                                                                                                                        <EditItemTemplate>
                                                                                                                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Selected") %>' />
                                                                                                                        </EditItemTemplate>
                                                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                                                        <HeaderStyle Width="10%" />
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:CheckBox ID="cbxSelectPharmacy" runat="server" Checked='<%# Bind("Selected") %>'
                                                                                                                                Enabled="false" />
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                </Columns>
                                                                                                                <RowStyle CssClass="GridNormalRowsStyle" />
                                                                                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                                                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                                                                                <HeaderStyle Font-Bold="True" ForeColor="Black" CssClass="GridHeaderBackStyle" />
                                                                                                                <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                                <EmptyDataTemplate>
                                                                                                                    <asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                                                                                                        ForeColor="Red" Text="No Data Found" Visible="False"></asp:Label>
                                                                                                                </EmptyDataTemplate>
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
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="3">
                                                                        <table style="width: 500px" cellspacing="0" cellpadding="0" class="tblStyle">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td colspan="3" rowspan="3">
                                                                                        <table width="100%">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td style="width: 95px" colspan="1" rowspan="3">
                                                                                                        <asp:Label ID="Label2" runat="server" CssClass="MainfontStyle" Text="Drug Purchase :"></asp:Label></td>
                                                                                                    <td align="left" colspan="7" rowspan="3">
                                                                                                        <asp:CheckBox ID="cbxDirectOrders" runat="server" CssClass="MainfontStyle" Text="Direct Orders"
                                                                                                            Enabled="False" Checked='<%# Bind("Drug_Purchase_Direct_Orders") %>'></asp:CheckBox>&nbsp;<asp:CheckBox
                                                                                                                ID="cbxTender" runat="server" CssClass="MainfontStyle" Text="Tender" Enabled="False"
                                                                                                                Checked='<%# Bind("Drug_Purchase_Tender") %>'></asp:CheckBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                </tr>
                                                                                                <tr>
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
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="3">
                                                                        <table style="width: 500px" cellspacing="0" cellpadding="0" class="tblStyle">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td colspan="3" rowspan="3">
                                                                                        <table width="100%">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td align="left" colspan="15" rowspan="3">
                                                                                                        <asp:Label ID="Label1" runat="server" CssClass="MainfontStyle" Text="Total Pharmacy Feedback :"></asp:Label></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" rowspan="1">
                                                                                                    </td>
                                                                                                    <td colspan="7" rowspan="1">
                                                                                                        <asp:Label ID="Label3" runat="server" CssClass="MainfontStyle" Text="Total General No. Of Rx./"></asp:Label></td>
                                                                                                    <td style="width: 31px" colspan="1" rowspan="1">
                                                                                                        <asp:Label ID="Label4" runat="server" CssClass="MainfontStyle" Text="Day"></asp:Label></td>
                                                                                                    <td colspan="1" rowspan="1">
                                                                                                        <asp:TextBox ID="txtTotalGenRXDay" runat="server" CssClass="inputs" Text='<%# Bind("Total_RX_General_No_Day") %>'
                                                                                                            ReadOnly="True" Width="25px"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Invalid total general number of RX/day"
                                                                                                            Display="Dynamic" ControlToValidate="txtTotalGenRXDay" ValidationExpression="^0*[1-9]*[0-9]*$">*</asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                                                                                ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtTotalGenRXDay"
                                                                                                                Display="Dynamic" ErrorMessage="Total RX: Day is required">*</asp:RequiredFieldValidator></td>
                                                                                                    <td colspan="1" rowspan="1">
                                                                                                        <asp:Label ID="Label5" runat="server" CssClass="MainfontStyle" Text="Week: "></asp:Label></td>
                                                                                                    <td colspan="1" rowspan="1">
                                                                                                        <asp:TextBox ID="txtTotalGenRXWeek" runat="server" CssClass="inputs" Text='<%# Bind("Total_RX_General_No_Week") %>'
                                                                                                            ReadOnly="True" Width="25px"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Invalid total general number of RX/week"
                                                                                                            Display="Dynamic" ControlToValidate="txtTotalGenRXWeek" ValidationExpression="^0*[1-9]*[0-9]*$">*</asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                                                                                ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtTotalGenRXWeek"
                                                                                                                Display="Dynamic" ErrorMessage="Total RX: Week is required">*</asp:RequiredFieldValidator></td>
                                                                                                    <td colspan="1" rowspan="1">
                                                                                                        <asp:Label ID="Label6" runat="server" CssClass="MainfontStyle" Text="Month: "></asp:Label></td>
                                                                                                    <td colspan="1" rowspan="1">
                                                                                                        <asp:TextBox ID="txtTotalGenRXMonth" runat="server" CssClass="inputs" Text='<%# Bind("Total_RX_General_No_Month") %>'
                                                                                                            ReadOnly="True" Width="25px"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Invalid total general number of RX/month"
                                                                                                            Display="Dynamic" ControlToValidate="txtTotalGenRXMonth" ValidationExpression="^0*[1-9]*[0-9]*$">*</asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                                                                                ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtTotalGenRXMonth"
                                                                                                                Display="Dynamic" ErrorMessage="Total RX: Month is required">*</asp:RequiredFieldValidator></td>
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
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="3">
                                                                        <table style="width: 500px" cellspacing="0" cellpadding="0" class="tblStyle">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td colspan="3" rowspan="3">
                                                                                        <table width="100%">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td align="left" colspan="15" rowspan="3">
                                                                                                        <asp:Label ID="Label7" runat="server" CssClass="MainfontStyle" Text="Product Feedback:"></asp:Label></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="height: 60px" align="center" colspan="15" rowspan="1">
                                                                                                        <asp:Label ID="Label12" runat="server" CssClass="MainfontStyle" Text="Product:"></asp:Label>
                                                                                                        <asp:DropDownList ID="ddlProductsList" runat="server" CssClass="inputs" DataValueField="ProductID"
                                                                                                            DataTextField="ProductName" DataSourceID="odsProductsList" OnSelectedIndexChanged="ddlProductsList_SelectedIndexChanged"
                                                                                                            AutoPostBack="True">
                                                                                                        </asp:DropDownList><asp:ObjectDataSource ID="odsProductsList" runat="server" TypeName="Pharma.BLL.ProductsBLL"
                                                                                                            SelectMethod="GetProductsList" OldValuesParameterFormatString="original_{0}">
                                                                                                        </asp:ObjectDataSource>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="center" colspan="15" rowspan="1">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="right" colspan="9" rowspan="1">
                                                                                                        <asp:Label ID="Label8" runat="server" CssClass="MainfontStyle" Text="Product Group Total  Rx Average No. /"></asp:Label></td>
                                                                                                    <td colspan="1" rowspan="1">
                                                                                                        <asp:Label ID="Label9" runat="server" CssClass="MainfontStyle" Text="Day"></asp:Label></td>
                                                                                                    <td colspan="1" rowspan="1">
                                                                                                        <asp:TextBox ID="txtProductGroupTotalRXDay" runat="server" CssClass="inputs" Width="25px"
                                                                                                            ReadOnly="True">0</asp:TextBox><asp:RangeValidator ID="RangeValidator2" runat="server" Type="Integer" MinimumValue="0" MaximumValue="99999"
                                                                                                                ErrorMessage="*" Display="Dynamic" ControlToValidate="txtProductGroupTotalRXDay"></asp:RangeValidator><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidator2" runat="server"
                                                                                                                    ErrorMessage="Product Group Total Rx: Day is required" Display="Dynamic" ControlToValidate="txtProductGroupTotalRXDay">*</asp:RequiredFieldValidator></td>
                                                                                                    <td colspan="1" rowspan="1">
                                                                                                        <asp:Label ID="Label10" runat="server" CssClass="MainfontStyle" Text="Week: "></asp:Label></td>
                                                                                                    <td colspan="1" rowspan="1">
                                                                                                        <asp:TextBox ID="txtProductGroupTotalRXWeek" runat="server" CssClass="inputs" Width="25px"
                                                                                                            ReadOnly="True">0</asp:TextBox><asp:RangeValidator ID="RangeValidator5" runat="server" Type="Integer" MinimumValue="0" MaximumValue="99999"
                                                                                                                ErrorMessage="*" Display="Dynamic" ControlToValidate="txtProductGroupTotalRXWeek"></asp:RangeValidator><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidator5" runat="server"
                                                                                                                    ErrorMessage="Product Group Total Rx: Week is required" Display="Dynamic" ControlToValidate="txtProductGroupTotalRXWeek">*</asp:RequiredFieldValidator></td>
                                                                                                    <td colspan="1" rowspan="1">
                                                                                                        <asp:Label ID="Label11" runat="server" CssClass="MainfontStyle" Text="Month: "></asp:Label></td>
                                                                                                    <td colspan="1" rowspan="1">
                                                                                                        <asp:TextBox ID="txtProductGroupTotalRXMonth" runat="server" CssClass="inputs" Width="25px"
                                                                                                            ReadOnly="True">0</asp:TextBox><asp:RangeValidator ID="RangeValidator8" runat="server" Type="Integer" MinimumValue="0" MaximumValue="99999"
                                                                                                                ErrorMessage="*" Display="Dynamic" ControlToValidate="txtProductGroupTotalRXMonth"></asp:RangeValidator><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidator8" runat="server"
                                                                                                                    ErrorMessage="Product Group Total Rx: Month is required" Display="Dynamic" ControlToValidate="txtProductGroupTotalRXMonth">*</asp:RequiredFieldValidator></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="right" colspan="9" rowspan="1">
                                                                                                        <asp:Label ID="Label13" runat="server" CssClass="MainfontStyle" Text="Product Competitors Total Rx Average No./"></asp:Label></td>
                                                                                                    <td colspan="1" rowspan="1">
                                                                                                        <asp:Label ID="Label15" runat="server" CssClass="MainfontStyle" Text="Day"></asp:Label></td>
                                                                                                    <td colspan="1" rowspan="1">
                                                                                                        <asp:TextBox ID="txtProductGroupCompRXDay" runat="server" CssClass="inputs" Width="25px"
                                                                                                            ReadOnly="True">0</asp:TextBox><asp:RangeValidator ID="RangeValidator3" runat="server" Type="Integer" MinimumValue="0" MaximumValue="99999"
                                                                                                                ErrorMessage="*" Display="Dynamic" ControlToValidate="txtProductGroupCompRXDay"></asp:RangeValidator><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidator3" runat="server"
                                                                                                                    ErrorMessage="Product Competitors Average  Rx: Day is required" Display="Dynamic" ControlToValidate="txtProductGroupCompRXDay">*</asp:RequiredFieldValidator></td>
                                                                                                    <td colspan="1" rowspan="1">
                                                                                                        <asp:Label ID="Label17" runat="server" CssClass="MainfontStyle" Text="Week: "></asp:Label></td>
                                                                                                    <td colspan="1" rowspan="1">
                                                                                                        <asp:TextBox ID="txtProductGroupCompRXWeek" runat="server" CssClass="inputs" Width="25px"
                                                                                                            ReadOnly="True">0</asp:TextBox><asp:RangeValidator ID="RangeValidator6" runat="server" Type="Integer" MinimumValue="0" MaximumValue="99999"
                                                                                                                ErrorMessage="*" Display="Dynamic" ControlToValidate="txtProductGroupCompRXWeek"></asp:RangeValidator><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidator6" runat="server"
                                                                                                                    ErrorMessage="Product Competitors Average  Rx: Week is required" Display="Dynamic" ControlToValidate="txtProductGroupCompRXWeek">*</asp:RequiredFieldValidator></td>
                                                                                                    <td colspan="1" rowspan="1">
                                                                                                        <asp:Label ID="Label19" runat="server" CssClass="MainfontStyle" Text="Month: "></asp:Label></td>
                                                                                                    <td colspan="1" rowspan="1">
                                                                                                        <asp:TextBox ID="txtProductGroupCompRXMonth" runat="server" CssClass="inputs" Width="25px"
                                                                                                            ReadOnly="True">0</asp:TextBox><asp:RangeValidator ID="RangeValidator9" runat="server" Type="Integer" MinimumValue="0" MaximumValue="99999"
                                                                                                                ErrorMessage="*" Display="Dynamic" ControlToValidate="txtProductGroupCompRXMonth"></asp:RangeValidator><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidator9" runat="server"
                                                                                                                    ErrorMessage="Product Competitors Average  Rx: Month is required" Display="Dynamic" ControlToValidate="txtProductGroupCompRXMonth">*</asp:RequiredFieldValidator></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="right" colspan="9" rowspan="1">
                                                                                                        <asp:Label ID="Label14" runat="server" CssClass="MainfontStyle" Text="Product Total  Rx Average No. /"></asp:Label></td>
                                                                                                    <td colspan="1" rowspan="1">
                                                                                                        <asp:Label ID="Label16" runat="server" CssClass="MainfontStyle" Text="Day"></asp:Label></td>
                                                                                                    <td colspan="1" rowspan="1">
                                                                                                        <asp:TextBox ID="txtProductTotalRXAvgDay" runat="server" CssClass="inputs" Width="25px"
                                                                                                            ReadOnly="True">0</asp:TextBox><asp:RangeValidator ID="RangeValidator4" runat="server" Type="Integer" MinimumValue="0" MaximumValue="99999"
                                                                                                                ErrorMessage="*" Display="Dynamic" ControlToValidate="txtProductTotalRXAvgDay"></asp:RangeValidator><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidator4" runat="server"
                                                                                                                    ErrorMessage="Product Total Rx: Day is required" Display="Dynamic" ControlToValidate="txtProductTotalRXAvgDay">*</asp:RequiredFieldValidator></td>
                                                                                                    <td colspan="1" rowspan="1">
                                                                                                        <asp:Label ID="Label18" runat="server" CssClass="MainfontStyle" Text="Week: "></asp:Label></td>
                                                                                                    <td colspan="1" rowspan="1">
                                                                                                        <asp:TextBox ID="txtProductTotalRXAvgWeek" runat="server" CssClass="inputs" Width="25px"
                                                                                                            ReadOnly="True">0</asp:TextBox><asp:RangeValidator ID="RangeValidator7" runat="server" Type="Integer" MinimumValue="0" MaximumValue="99999"
                                                                                                                ErrorMessage="*" Display="Dynamic" ControlToValidate="txtProductTotalRXAvgWeek"></asp:RangeValidator><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidator7" runat="server"
                                                                                                                    ErrorMessage="Product Total Rx: Week is required" Display="Dynamic" ControlToValidate="txtProductTotalRXAvgWeek">*</asp:RequiredFieldValidator></td>
                                                                                                    <td colspan="1" rowspan="1">
                                                                                                        <asp:Label ID="Label20" runat="server" CssClass="MainfontStyle" Text="Month: "></asp:Label></td>
                                                                                                    <td colspan="1" rowspan="1">
                                                                                                        <asp:TextBox ID="txtProductTotalRXAvgMonth" runat="server" CssClass="inputs" Width="25px"
                                                                                                            ReadOnly="True">0</asp:TextBox><asp:RangeValidator ID="RangeValidator10" runat="server" Type="Integer" MinimumValue="0" MaximumValue="99999"
                                                                                                                ErrorMessage="*" Display="Dynamic" ControlToValidate="txtProductTotalRXAvgMonth"></asp:RangeValidator><asp:RequiredFieldValidator
                                                                                                                    ID="RequiredFieldValidator10" runat="server"
                                                                                                                    ErrorMessage="Product Total Rx: Month is required" Display="Dynamic" ControlToValidate="txtProductTotalRXAvgMonth">*</asp:RequiredFieldValidator></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="15" rowspan="1" align="center">
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
                                        </tr>
                                        <tr>
                                        </tr>
                                        <tr>
                                        </tr>
                                        <tr>
                                        </tr>
                                        <tr>
                                        </tr>
                                        <tr>
                                        </tr>
                                        <tr>
                                        </tr>
                                        <tr>
                                        </tr>
                                        <tr>
                                        </tr>
                                        <tr>
                                        </tr>
                                        <tr>
                                            <td valign="top" colspan="3" rowspan="1" align="center">
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </ItemTemplate>
                            <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="PagerfontStyle" />
                            <RowStyle HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                <table style="width: 100%">
                                    <tbody>
                                        <tr>
                                            <td colspan="3" rowspan="1" valign="top" align="center">
                                                <table id="Table1" class="tblStyle" style="width: 100%; height: 30px">
                                                    <tbody>
                                                        <tr align="center" width="50%">
                                                            <td align="right" style="width: 40%">
                                                                <asp:Label ID="lblSearch" runat="server" CssClass="MainfontStyle" Text="Search Medical Accounts:"></asp:Label></td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtSearchName" runat="server" AutoPostBack="True" CssClass="inputs"
                                                                    OnTextChanged="txtSearchName_TextChanged" Width="300px"></asp:TextBox>
                                                            </td>
                                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" BehaviorID="autoCompleteBehavior1"
                                                                        CompletionInterval="10" CompletionSetCount="20" DelimiterCharacters=";," EnableCaching="true"
                                                                        FirstRowSelected="true" MinimumPrefixLength="1" ServiceMethod="GetCompletionList"
                                                                        TargetControlID="txtSearchName" UseContextKey="True">
                                                            </cc1:AutoCompleteExtender>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" width="45%" rowspan="1">
                                            </td>
                                            <td width="5%" rowspan="1">
                                            </td>
                                            <td width="50%" rowspan="1">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" rowspan="13">
                                                <table cellspacing="0" cellpadding="0" width="450">
                                                    <tbody>
                                                        <tr>
                                                            <td colspan="3" rowspan="3">
                                                                <table width="100%">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblName" runat="server" CssClass="MainfontStyle" Text="Name :"></asp:Label></td>
                                                                            <td align="left">
                                                                                <asp:TextBox ID="txtName" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("Name") %>'
                                                                                    Width="270px"></asp:TextBox>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                                                                    Display="Dynamic" ErrorMessage="Name is required">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblSubordination" runat="server" CssClass="MainfontStyle" Text="Subordination :"></asp:Label></td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="ddlSubordination" runat="server" CssClass="inputs" Width="275px"
                                                                                    Enabled="False" DataValueField="SID" DataTextField="SubCode" DataSourceID="odsSubordination">
                                                                                </asp:DropDownList><asp:TextBox ID="txtSubordination" runat="server" Text='<%# Bind("SubordinationID") %>'
                                                                                    Visible="False" Width="15px"></asp:TextBox></td>
                                                                            <td style="text-align: left">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblGov" runat="server" CssClass="MainfontStyle" Text="Gov:"></asp:Label></td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="ddlGov" runat="server" CssClass="inputs" Width="275px" Enabled="False"
                                                                                    DataValueField="SID" DataTextField="SubCode" DataSourceID="odsGov" SelectedValue='<%# Bind("GovID") %>'
                                                                                    OnSelectedIndexChanged="ddlGov_SelectedIndexChanged" OnDataBound="ddlGov_DataBound"
                                                                                    AutoPostBack="True">
                                                                                </asp:DropDownList><asp:TextBox ID="txtGov" runat="server" Text='<%# Bind("GovID") %>'
                                                                                    Visible="False" Width="15px"></asp:TextBox></td>
                                                                            <td style="text-align: left">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblCity" runat="server" CssClass="MainfontStyle" Text="City:"></asp:Label></td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="ddlCity" runat="server" CssClass="inputs" Width="275px" Enabled="False"
                                                                                    DataValueField="CityID" DataTextField="City">
                                                                                </asp:DropDownList><asp:TextBox ID="txtCity" runat="server" Text='<%# Bind("CityID") %>'
                                                                                    Visible="False" Width="15px"></asp:TextBox></td>
                                                                            <td style="text-align: left">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblArea" runat="server" CssClass="MainfontStyle" Text="Area:"></asp:Label></td>
                                                                            <td align="left">
                                                                                <asp:TextBox ID="txtArea" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("Area") %>'
                                                                                    Width="270px"></asp:TextBox></td>
                                                                            <td style="text-align: left">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtArea"
                                                                                    Display="Dynamic" ErrorMessage="Area is required">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblAddress" runat="server" CssClass="MainfontStyle" Text="Address: "></asp:Label></td>
                                                                            <td align="left">
                                                                                <asp:TextBox ID="txtAddress" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("Name") %>'
                                                                                    Width="270px"></asp:TextBox></td>
                                                                            <td style="text-align: left">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtAddress"
                                                                                    Display="Dynamic" ErrorMessage="Address is required">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblBrick" runat="server" CssClass="MainfontStyle" Text="Brick :"></asp:Label></td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="ddlBrick" runat="server" CssClass="inputs" Width="275px" Enabled="False"
                                                                                    DataValueField="BrickID" DataTextField="BrickName" DataSourceID="odsBrick">
                                                                                </asp:DropDownList><asp:TextBox ID="txtBrickID" runat="server" Text='<%# Bind("BrickID") %>'
                                                                                    Visible="False" Width="15px"></asp:TextBox></td>
                                                                            <td style="text-align: left">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblPhone" runat="server" CssClass="MainfontStyle" Text="Phone:"></asp:Label></td>
                                                                            <td align="left">
                                                                                <asp:TextBox ID="txtPhone1" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("Phone") %>'
                                                                                    Width="270px"></asp:TextBox></td>
                                                                            <td style="text-align: left">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblMobile" runat="server" CssClass="MainfontStyle" Text="Mobile:"></asp:Label></td>
                                                                            <td align="left">
                                                                                <asp:TextBox ID="txtMobile" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("Mobile") %>'
                                                                                    Width="270px"></asp:TextBox></td>
                                                                            <td style="text-align: left">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblPostalCode" runat="server" CssClass="MainfontStyle" Text="Postal Code :"></asp:Label></td>
                                                                            <td align="left">
                                                                                <asp:TextBox ID="txtPostalCode" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                    Text='<%# Bind("PostalCode") %>' Width="270px"></asp:TextBox></td>
                                                                            <td style="text-align: left">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblICU" runat="server" CssClass="MainfontStyle" Text="ICU :"></asp:Label></td>
                                                                            <td align="left">
                                                                                <asp:TextBox ID="txtICU" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("ICUNO") %>'
                                                                                    Width="270px"></asp:TextBox>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtICU"
                                                                                    Display="Dynamic" ErrorMessage="Invali ISU NO" ValidationExpression="^0*[1-9]*[0-9]*$">*</asp:RegularExpressionValidator>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtICU"
                                                                                    Display="Dynamic" ErrorMessage="ICU is required">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblComment" runat="server" CssClass="MainfontStyle" Text="Served Pts./ Month:"></asp:Label></td>
                                                                            <td align="left">
                                                                                <asp:TextBox ID="txtNoOfServed" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                    Text='<%# Bind("No_Medically_Served_Pts") %>' Width="270px"></asp:TextBox>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtNoOfServed"
                                                                                    Display="Dynamic" ErrorMessage="Invalid medically served pts/month" ValidationExpression="^0*[1-9]*[0-9]*$">*</asp:RegularExpressionValidator>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtNoOfServed"
                                                                                    Display="Dynamic" ErrorMessage="Served Pts./ Month is required">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td align="center">
                                                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="StyleValidationSummary" />
                                                                            </td>
                                                                            <td style="text-align: left">
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
                                                <asp:ObjectDataSource ID="odsSubordination" runat="server" TypeName="Pharma.BLL.LookupsBLL"
                                                    SelectMethod="GetSCodeByGCode" OldValuesParameterFormatString="original_{0}">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="Subordination" Name="GeneralCode" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                                <asp:ObjectDataSource ID="odsGov" runat="server" TypeName="Pharma.BLL.LookupsBLL"
                                                    SelectMethod="GetSCodeByGCode" OldValuesParameterFormatString="original_{0}">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="Gov" Name="GeneralCode" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                                <asp:ObjectDataSource ID="odsBrick" runat="server" TypeName="Pharma.BLL.LookupsBLL"
                                                    SelectMethod="SelectBricks" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
                                            </td>
                                            <td rowspan="13">
                                            </td>
                                            <td rowspan="13">
                                                <table>
                                                    <tbody>
                                                        <tr>
                                                            <td style="height: 97px" colspan="3" rowspan="2">
                                                                <table style="width: 500px" cellspacing="0" cellpadding="0" class="tblStyle">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td valign="middle" colspan="3" rowspan="3">
                                                                                <table width="100%">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td align="left" colspan="8" rowspan="1">
                                                                                                <asp:Label ID="lblMedicalService" runat="server" CssClass="MainfontStyle" Text="Medical Service Financial Limits :"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height: 45px" align="right" colspan="1" rowspan="3">
                                                                                                <asp:Label ID="lblRX" runat="server" CssClass="MainfontStyle" Text="RX :"></asp:Label></td>
                                                                                            <td style="height: 45px" align="left" colspan="1" rowspan="3">
                                                                                                <asp:TextBox ID="txtRXFinancialLimits" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                                    Text='<%# Bind("RX_Financial_Limits") %>' Width="100px"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtRXFinancialLimits"
                                                                                                    Display="Dynamic" ErrorMessage="Invalid daily RX" ValidationExpression="^\d+(\.\d*)?$">*</asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                                                                        ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtRXFinancialLimits"
                                                                                                        Display="Dynamic" ErrorMessage="RX: Day is required">*</asp:RequiredFieldValidator></td>
                                                                                            <td style="height: 45px" align="right" colspan="1" rowspan="3">
                                                                                                <asp:Label ID="lblMonthly" runat="server" CssClass="MainfontStyle" Text="Monthly :"></asp:Label></td>
                                                                                            <td style="height: 45px" align="left" colspan="1" rowspan="3">
                                                                                                <asp:TextBox ID="txtRXFinancialLimitsMonthly" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                                    Text='<%# Bind("Monthly_Financial_Limits") %>' Width="100px"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtRXFinancialLimitsMonthly"
                                                                                                    Display="Dynamic" ErrorMessage="Invalid monthly RX" ValidationExpression="^\d+(\.\d*)?$">*</asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                                                                        ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtRXFinancialLimitsMonthly"
                                                                                                        Display="Dynamic" ErrorMessage="RX: Monthly is required">*</asp:RequiredFieldValidator></td>
                                                                                            <td style="width: 52px; height: 45px" align="right" colspan="1" rowspan="3">
                                                                                                <asp:Label ID="lblAnnual" runat="server" CssClass="MainfontStyle" Text="Annual :"></asp:Label></td>
                                                                                            <td style="height: 45px" align="left" colspan="3" rowspan="3">
                                                                                                <asp:TextBox ID="txtRXFinancialLimitsAnnual" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                                    Text='<%# Bind("Annual_Financial_Limits") %>' Width="100px"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtRXFinancialLimitsAnnual"
                                                                                                    Display="Dynamic" ErrorMessage="Invalid annuel RX" ValidationExpression="^\d+(\.\d*)?$">*</asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                                                                        ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtRXFinancialLimitsAnnual"
                                                                                                        Display="Dynamic" ErrorMessage="RX: Annual is required">*</asp:RequiredFieldValidator></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                        </tr>
                                                                                        <tr>
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
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <table style="width: 500px" cellspacing="0" cellpadding="0" class="tblStyle">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td colspan="3" rowspan="3">
                                                                                <table width="100%">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td valign="top" align="left" colspan="8" rowspan="1">
                                                                                                <asp:Label ID="lblDrugDelivery" runat="server" CssClass="MainfontStyle" Text="Drug Delivery:"></asp:Label></td>
                                                                                            <td valign="top" align="left" colspan="2" rowspan="1" height="25">
                                                                                                <asp:CheckBox ID="cbxInternalPharmacy" runat="server" Checked='<%# Bind("Drug_Delivery_Internal") %>'
                                                                                                    CssClass="MainfontStyle" Enabled="False" Text="Internal Pharmacy" />
                                                                                                <asp:CheckBox ID="cbxExternalPharmacy" runat="server" Checked='<%# Bind("Drug_Delivery_External") %>'
                                                                                                    CssClass="MainfontStyle" Enabled="False" Text="External Pharmacy" /></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" colspan="10" rowspan="1">
                                                                                                <asp:Panel ID="pnlgvPharmacies" runat="server" Height="250px" ScrollBars="Auto" Width="100%" HorizontalAlign="Left">
                                                                                                    <asp:GridView ID="gvPharmacies" runat="server" Width="95%" AutoGenerateColumns="False"
                                                                                                                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                                                                                                CellPadding="0" DataKeyNames="PharmacyID" OnRowDataBound="gvPharmacies_RowDataBound">
                                                                                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                                                        <Columns>
                                                                                                            <asp:BoundField DataField="Name" HeaderText="Pharmacy Name" SortExpression="Name">
                                                                                                                <HeaderStyle HorizontalAlign="Center" Width="90%" />
                                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                                            </asp:BoundField>
                                                                                                            <asp:TemplateField HeaderText="Select">
                                                                                                                <EditItemTemplate>
                                                                                                                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Selected") %>' />
                                                                                                                </EditItemTemplate>
                                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                                                <HeaderStyle Width="10%" />
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:CheckBox ID="cbxSelectPharmacy" runat="server" Checked='<%# Bind("Selected") %>'
                                                                                                                                Enabled="false" />
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                        </Columns>
                                                                                                        <RowStyle CssClass="GridNormalRowsStyle" />
                                                                                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                                                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                                                                        <HeaderStyle Font-Bold="True" ForeColor="Black" CssClass="GridHeaderBackStyle" />
                                                                                                        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                        <EmptyDataTemplate>
                                                                                                            <asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                                                                                                ForeColor="Red" Text="No Data Found" Visible="False"></asp:Label>
                                                                                                        </EmptyDataTemplate>
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
                                                                    </tbody>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <table style="width: 500px" cellspacing="0" cellpadding="0" class="tblStyle">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td colspan="3" rowspan="3">
                                                                                <table width="100%">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 95px" colspan="1" rowspan="3">
                                                                                                <asp:Label ID="Label2" runat="server" CssClass="MainfontStyle" Text="Drug Purchase :"></asp:Label></td>
                                                                                            <td align="left" colspan="7" rowspan="3">
                                                                                                <asp:CheckBox ID="cbxDirectOrders" runat="server" Checked='<%# Bind("Drug_Purchase_Direct_Orders") %>'
                                                                                                    CssClass="MainfontStyle" Enabled="False" Text="Direct Orders" />&nbsp;<asp:CheckBox
                                                                                                        ID="cbxTender" runat="server" Checked='<%# Bind("Drug_Purchase_Tender") %>' CssClass="MainfontStyle"
                                                                                                        Enabled="False" Text="Tender" /></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                        </tr>
                                                                                        <tr>
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
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <table style="width: 500px" cellspacing="0" cellpadding="0" class="tblStyle">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td colspan="3" rowspan="3">
                                                                                <table width="100%">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td align="left" colspan="15" rowspan="3">
                                                                                                <asp:Label ID="Label1" runat="server" CssClass="MainfontStyle" Text="Total Pharmacy Feedback :"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                        </tr>
                                                                                        <tr>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2" rowspan="1">
                                                                                            </td>
                                                                                            <td colspan="7" rowspan="1">
                                                                                                <asp:Label ID="Label3" runat="server" CssClass="MainfontStyle" Text="Total General No. Of Rx./"></asp:Label></td>
                                                                                            <td style="width: 31px" colspan="1" rowspan="1">
                                                                                                <asp:Label ID="Label4" runat="server" CssClass="MainfontStyle" Text="Day"></asp:Label></td>
                                                                                            <td colspan="1" rowspan="1">
                                                                                                <asp:TextBox ID="txtTotalGenRXDay" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                                    Text='<%# Bind("Total_RX_General_No_Day") %>' Width="25px"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtTotalGenRXDay"
                                                                                                    Display="Dynamic" ErrorMessage="Invalid total general number of RX/day" ValidationExpression="^0*[1-9]*[0-9]*$">*</asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                                                                        ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtTotalGenRXDay"
                                                                                                        Display="Dynamic" ErrorMessage="Total RX: Day is required">*</asp:RequiredFieldValidator></td>
                                                                                            <td colspan="1" rowspan="1">
                                                                                                <asp:Label ID="Label5" runat="server" CssClass="MainfontStyle" Text="Week: "></asp:Label></td>
                                                                                            <td colspan="1" rowspan="1">
                                                                                                <asp:TextBox ID="txtTotalGenRXWeek" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                                    Text='<%# Bind("Total_RX_General_No_Week") %>' Width="25px"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtTotalGenRXWeek"
                                                                                                    Display="Dynamic" ErrorMessage="Invalid total general number of RX/week" ValidationExpression="^0*[1-9]*[0-9]*$">*</asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                                                                        ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtTotalGenRXWeek"
                                                                                                        Display="Dynamic" ErrorMessage="Total RX: Week is required">*</asp:RequiredFieldValidator></td>
                                                                                            <td colspan="1" rowspan="1">
                                                                                                <asp:Label ID="Label6" runat="server" CssClass="MainfontStyle" Text="Month: "></asp:Label></td>
                                                                                            <td colspan="1" rowspan="1">
                                                                                                <asp:TextBox ID="txtTotalGenRXMonth" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                                    Text='<%# Bind("Total_RX_General_No_Month") %>' Width="25px"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtTotalGenRXMonth"
                                                                                                    Display="Dynamic" ErrorMessage="Invalid total general number of RX/month" ValidationExpression="^0*[1-9]*[0-9]*$">*</asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                                                                        ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtTotalGenRXMonth"
                                                                                                        Display="Dynamic" ErrorMessage="Total RX: Month is required">*</asp:RequiredFieldValidator></td>
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
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <table style="width: 500px" cellspacing="0" cellpadding="0" class="tblStyle">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td colspan="3" rowspan="3">
                                                                                <table width="100%">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td align="left" colspan="15" rowspan="3">
                                                                                                <asp:Label ID="Label7" runat="server" CssClass="MainfontStyle" Text="Product Feedback:"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                        </tr>
                                                                                        <tr>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height: 67px" align="center" colspan="15" rowspan="1">
                                                                                                <asp:Label ID="Label12" runat="server" CssClass="MainfontStyle" Text="Product:"></asp:Label>
                                                                                                <asp:DropDownList ID="ddlProductsList" runat="server" CssClass="inputs" DataValueField="ProductID"
                                                                                                            DataTextField="ProductName" DataSourceID="odsProductsList" OnSelectedIndexChanged="ddlProductsList_SelectedIndexChanged"
                                                                                                            AutoPostBack="True">
                                                                                                </asp:DropDownList><asp:ObjectDataSource ID="odsProductsList" runat="server" TypeName="Pharma.BLL.ProductsBLL"
                                                                                                            SelectMethod="GetProductsList" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="center" colspan="15" rowspan="1">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right" colspan="9" rowspan="1">
                                                                                                <asp:Label ID="Label8" runat="server" CssClass="MainfontStyle" Text="Product Group Total  Rx Average No. /"></asp:Label></td>
                                                                                            <td colspan="1" rowspan="1">
                                                                                                <asp:Label ID="Label9" runat="server" CssClass="MainfontStyle" Text="Day"></asp:Label></td>
                                                                                            <td colspan="1" rowspan="1">
                                                                                                <asp:TextBox ID="txtProductGroupTotalRXDay" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                                    Width="25px">0</asp:TextBox><asp:RangeValidator ID="RangeValidator2" runat="server"
                                                                                                        ControlToValidate="txtProductGroupTotalRXDay" Display="Dynamic" ErrorMessage="*"
                                                                                                        MaximumValue="99999" MinimumValue="0" Type="Integer"></asp:RangeValidator><asp:RequiredFieldValidator
                                                                                                            ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtProductGroupTotalRXDay"
                                                                                                            Display="Dynamic" ErrorMessage="Product Group Total Rx: Day is required">*</asp:RequiredFieldValidator></td>
                                                                                            <td colspan="1" rowspan="1">
                                                                                                <asp:Label ID="Label10" runat="server" CssClass="MainfontStyle" Text="Week: "></asp:Label></td>
                                                                                            <td colspan="1" rowspan="1">
                                                                                                <asp:TextBox ID="txtProductGroupTotalRXWeek" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                                    Width="25px">0</asp:TextBox><asp:RangeValidator ID="RangeValidator5" runat="server"
                                                                                                        ControlToValidate="txtProductGroupTotalRXWeek" Display="Dynamic" ErrorMessage="*"
                                                                                                        MaximumValue="99999" MinimumValue="0" Type="Integer"></asp:RangeValidator><asp:RequiredFieldValidator
                                                                                                            ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtProductGroupTotalRXWeek"
                                                                                                            Display="Dynamic" ErrorMessage="Product Group Total Rx: Week is required">*</asp:RequiredFieldValidator></td>
                                                                                            <td colspan="1" rowspan="1">
                                                                                                <asp:Label ID="Label11" runat="server" CssClass="MainfontStyle" Text="Month: "></asp:Label></td>
                                                                                            <td colspan="1" rowspan="1">
                                                                                                <asp:TextBox ID="txtProductGroupTotalRXMonth" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                                    Width="25px">0</asp:TextBox><asp:RangeValidator ID="RangeValidator8" runat="server"
                                                                                                        ControlToValidate="txtProductGroupTotalRXMonth" Display="Dynamic" ErrorMessage="*"
                                                                                                        MaximumValue="99999" MinimumValue="0" Type="Integer"></asp:RangeValidator><asp:RequiredFieldValidator
                                                                                                            ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtProductGroupTotalRXMonth"
                                                                                                            Display="Dynamic" ErrorMessage="Product Group Total Rx: Month is required">*</asp:RequiredFieldValidator></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right" colspan="9" rowspan="1">
                                                                                                <asp:Label ID="Label13" runat="server" CssClass="MainfontStyle" Text="Product Competitors Total Rx Average No./"></asp:Label></td>
                                                                                            <td colspan="1" rowspan="1">
                                                                                                <asp:Label ID="Label15" runat="server" CssClass="MainfontStyle" Text="Day"></asp:Label></td>
                                                                                            <td colspan="1" rowspan="1">
                                                                                                <asp:TextBox ID="txtProductGroupCompRXDay" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                                    Width="25px">0</asp:TextBox><asp:RangeValidator ID="RangeValidator3" runat="server"
                                                                                                        ControlToValidate="txtProductGroupCompRXDay" Display="Dynamic" ErrorMessage="*"
                                                                                                        MaximumValue="99999" MinimumValue="0" Type="Integer"></asp:RangeValidator><asp:RequiredFieldValidator
                                                                                                            ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtProductGroupCompRXDay"
                                                                                                            Display="Dynamic" ErrorMessage="Product Competitors Average  Rx: Day is required">*</asp:RequiredFieldValidator></td>
                                                                                            <td colspan="1" rowspan="1">
                                                                                                <asp:Label ID="Label17" runat="server" CssClass="MainfontStyle" Text="Week: "></asp:Label></td>
                                                                                            <td colspan="1" rowspan="1">
                                                                                                <asp:TextBox ID="txtProductGroupCompRXWeek" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                                    Width="25px">0</asp:TextBox><asp:RangeValidator ID="RangeValidator6" runat="server"
                                                                                                        ControlToValidate="txtProductGroupCompRXWeek" Display="Dynamic" ErrorMessage="*"
                                                                                                        MaximumValue="99999" MinimumValue="0" Type="Integer"></asp:RangeValidator><asp:RequiredFieldValidator
                                                                                                            ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtProductGroupCompRXWeek"
                                                                                                            Display="Dynamic" ErrorMessage="Product Competitors Average  Rx: Week is required">*</asp:RequiredFieldValidator></td>
                                                                                            <td colspan="1" rowspan="1">
                                                                                                <asp:Label ID="Label19" runat="server" CssClass="MainfontStyle" Text="Month: "></asp:Label></td>
                                                                                            <td colspan="1" rowspan="1">
                                                                                                <asp:TextBox ID="txtProductGroupCompRXMonth" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                                    Width="25px">0</asp:TextBox><asp:RangeValidator ID="RangeValidator9" runat="server"
                                                                                                        ControlToValidate="txtProductGroupCompRXMonth" Display="Dynamic" ErrorMessage="*"
                                                                                                        MaximumValue="99999" MinimumValue="0" Type="Integer"></asp:RangeValidator><asp:RequiredFieldValidator
                                                                                                            ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtProductGroupCompRXMonth"
                                                                                                            Display="Dynamic" ErrorMessage="Product Competitors Average  Rx: Month is required">*</asp:RequiredFieldValidator></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right" colspan="9" rowspan="1">
                                                                                                <asp:Label ID="Label14" runat="server" CssClass="MainfontStyle" Text="Product Total  Rx Average No. /"></asp:Label></td>
                                                                                            <td colspan="1" rowspan="1">
                                                                                                <asp:Label ID="Label16" runat="server" CssClass="MainfontStyle" Text="Day"></asp:Label></td>
                                                                                            <td colspan="1" rowspan="1">
                                                                                                <asp:TextBox ID="txtProductTotalRXAvgDay" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                                    Width="25px">0</asp:TextBox><asp:RangeValidator ID="RangeValidator4" runat="server"
                                                                                                        ControlToValidate="txtProductTotalRXAvgDay" Display="Dynamic" ErrorMessage="*"
                                                                                                        MaximumValue="99999" MinimumValue="0" Type="Integer"></asp:RangeValidator><asp:RequiredFieldValidator
                                                                                                            ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtProductTotalRXAvgDay"
                                                                                                            Display="Dynamic" ErrorMessage="Product Total Rx: Day is required">*</asp:RequiredFieldValidator></td>
                                                                                            <td colspan="1" rowspan="1">
                                                                                                <asp:Label ID="Label18" runat="server" CssClass="MainfontStyle" Text="Week: "></asp:Label></td>
                                                                                            <td colspan="1" rowspan="1">
                                                                                                <asp:TextBox ID="txtProductTotalRXAvgWeek" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                                    Width="25px">0</asp:TextBox><asp:RangeValidator ID="RangeValidator7" runat="server"
                                                                                                        ControlToValidate="txtProductTotalRXAvgWeek" Display="Dynamic" ErrorMessage="*"
                                                                                                        MaximumValue="99999" MinimumValue="0" Type="Integer"></asp:RangeValidator><asp:RequiredFieldValidator
                                                                                                            ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtProductTotalRXAvgWeek"
                                                                                                            Display="Dynamic" ErrorMessage="Product Total Rx: Week is required">*</asp:RequiredFieldValidator></td>
                                                                                            <td colspan="1" rowspan="1">
                                                                                                <asp:Label ID="Label20" runat="server" CssClass="MainfontStyle" Text="Month: "></asp:Label></td>
                                                                                            <td colspan="1" rowspan="1">
                                                                                                <asp:TextBox ID="txtProductTotalRXAvgMonth" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                                    Width="25px">0</asp:TextBox><asp:RangeValidator ID="RangeValidator10" runat="server"
                                                                                                        ControlToValidate="txtProductTotalRXAvgMonth" Display="Dynamic" ErrorMessage="*"
                                                                                                        MaximumValue="99999" MinimumValue="0" Type="Integer"></asp:RangeValidator><asp:RequiredFieldValidator
                                                                                                            ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtProductTotalRXAvgMonth"
                                                                                                            Display="Dynamic" ErrorMessage="Product Total Rx: Month is required">*</asp:RequiredFieldValidator></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="15" rowspan="1" align="center">
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
                                        </tr>
                                        <tr>
                                        </tr>
                                        <tr>
                                        </tr>
                                        <tr>
                                        </tr>
                                        <tr>
                                        </tr>
                                        <tr>
                                        </tr>
                                        <tr>
                                        </tr>
                                        <tr>
                                        </tr>
                                        <tr>
                                        </tr>
                                        <tr>
                                        </tr>
                                        <tr>
                                            <td valign="top" colspan="3" rowspan="1" align="center">
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </EmptyDataTemplate>
                        </asp:FormView>
                                                        <asp:Label ID="lblNoDataMsg" runat="server" CssClass="MainfontStyle"></asp:Label><br /><asp:Label
                                                            ID="lblmsg" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                                            ForeColor="#004000" Text='Your request for adding new Medical Accounts is in "Pending" phase until Acceptance from your Manager'
                                                            Visible="False"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                &nbsp;
            </td>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
    </table>

    <script type="text/javascript">

         
   var scrollTop;
  
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);


       function BeginRequestHandler(sender, args) 
        {
          var elem = document.getElementById('ctl00_ContentPlaceHolder1_frmViewMedicalAccounts_pnlgvPharmacies');
              if(elem!= null)
              scrollTop=elem.scrollTop;
        }

      function EndRequestHandler(sender, args)
       {
       var elem = document.getElementById('ctl00_ContentPlaceHolder1_frmViewMedicalAccounts_pnlgvPharmacies');
            if(elem!= null)
           elem.scrollTop = scrollTop;
  
      }   
    
    
    </script>

</asp:Content>
