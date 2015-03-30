<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
    CodeFile="Pharmacies.aspx.cs" Inherits="Pharmacies" Title=":: MPM - BMD :: Pharmacies ::" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="Controls/TransButtons.ascx" TagName="TransButtons" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:FormView ID="frmViewPharmacies" runat="server" OnPageIndexChanging="frmViewPharmacies_PageIndexChanging"
                DataKeyNames="PharmacyID" AllowPaging="True" BackImageUrl="~/Images/BG-1.jpg"
                BorderColor="DarkGray" BorderStyle="Solid" BorderWidth="1px" Width="100%" OnDataBound="frmViewPharmacies_DataBound">
                <PagerSettings FirstPageText="First" LastPageText="Last"
                    NextPageImageUrl="~/Images/next_n.jpg" NextPageText="Next" PreviousPageImageUrl="~/Images/previous_n.jpg"
                    PreviousPageText="Previous" Mode="NumericFirstLast">
                </PagerSettings>
                <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="PagerfontStyle"></PagerStyle>
                <ItemTemplate>
                    <table width="100%">
                        <tr>
                            <td align="center" colspan="3" rowspan="3">
                                <table style="width: 100%">
                                    <tr>
                                        <td align="center" colspan="3" rowspan="1">
                                            <table id="tblsearch" class="tblStyle" style="z-index: 1; position:relative; width: 100%; height: 30px;">
                                                <tbody>
                                                    <tr align="center" width="50%">
                                                        <td align="right" style="width: 40%">
                                                            <asp:Label ID="lblSearch" runat="server" CssClass="MainfontStyle" Text="Search Pharmacies:"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtSearchName" runat="server" AutoPostBack="True" CssClass="inputs"
                                                                OnTextChanged="txtSearchName_TextChanged" Width="300px"></asp:TextBox></td>
                                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" UseContextKey="True"
                                                                    TargetControlID="txtSearchName" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                                                                    FirstRowSelected="true" EnableCaching="true" DelimiterCharacters=";," CompletionSetCount="20"
                                                                    CompletionInterval="10" BehaviorID="autoCompleteBehavior1">
                                                        </cc1:AutoCompleteExtender>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" rowspan="1" style="width: 45%" valign="top">
                                        </td>
                                        <td rowspan="1" style="width: 5%">
                                        </td>
                                        <td rowspan="1" style="width: 50%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td rowspan="13" valign="top" align="left">
                                            <table cellspacing="0" cellpadding="0" width="450">
                                                <tbody>
                                                    <tr>
                                                        <td colspan="3" rowspan="3">
                                                            <table width="100%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td align="right" width="30%">
                                                                            <asp:Label ID="lblName" runat="server" CssClass="MainfontStyle" Text="Pharmacy Name :"></asp:Label></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtPharmacyName" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                Text='<%# Bind("Name") %>' Width="270px"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPharmacyName"
                                                                                Display="Dynamic" ErrorMessage="Pharmacy name is required">*</asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtPharmacyName"
                                                                                Display="Dynamic" ErrorMessage="Invalid Spelling" ValidationExpression="^([a-zA-Z]{1})([_\\'\,\.\-\ a-zA-Z0-9])*">*</asp:RegularExpressionValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblPharmacistName" runat="server" CssClass="MainfontStyle" Text="Pharmacist Name :"></asp:Label></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtPharmacistName" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                Text='<%# Bind("PharmacistName") %>' Width="270px"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPharmacistName"
                                                                                Display="Dynamic" ErrorMessage="Pharmacist name is required">*</asp:RequiredFieldValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblGov" runat="server" CssClass="MainfontStyle" Text="Gov:"></asp:Label></td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlGov" runat="server" CssClass="inputs" Width="275px" OnDataBound="ddlGov_DataBound"
                                                                                Enabled="False" OnSelectedIndexChanged="ddlGov_SelectedIndexChanged" DataValueField="SID"
                                                                                DataTextField="SubCode" DataSourceID="odsGov" SelectedValue='<%# Bind("GovID") %>'
                                                                                AutoPostBack="True">
                                                                            </asp:DropDownList><asp:TextBox ID="txtGov" runat="server" Text='<%# Bind("GovID") %>'
                                                                                Visible="False" Width="15px"></asp:TextBox></td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblCity" runat="server" CssClass="MainfontStyle" Text="City:"></asp:Label></td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlCity" runat="server" CssClass="inputs" Width="275px" Enabled="False"
                                                                                DataValueField="CityID" DataTextField="City">
                                                                            </asp:DropDownList><asp:TextBox ID="txtCity" runat="server" Text='<%# Bind("CityID") %>'
                                                                                Visible="False" Width="15px"></asp:TextBox></td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblArea" runat="server" CssClass="MainfontStyle" Text="Area:"></asp:Label></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtArea" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("Area") %>'
                                                                                Width="270px"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtArea"
                                                                                Display="Dynamic" ErrorMessage="Area is required">*</asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtArea"
                                                                                Display="Dynamic" ErrorMessage="Invalid Spelling" ValidationExpression="^([a-zA-Z]{1})([_\\'\,\.\-\ a-zA-Z0-9])*">*</asp:RegularExpressionValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblAddress" runat="server" CssClass="MainfontStyle" Text="Address: "></asp:Label></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("Address") %>'
                                                                                Width="270px"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAddress"
                                                                                Display="Dynamic" ErrorMessage="Address is required">*</asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtAddress"
                                                                                Display="Dynamic" ErrorMessage="Invalid Spelling" ValidationExpression="^([a-zA-Z]{1})([_\\'\,\.\-\ a-zA-Z0-9])*">*</asp:RegularExpressionValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblBrick" runat="server" CssClass="MainfontStyle" Text="Brick :"></asp:Label></td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlBrick" runat="server" CssClass="inputs" Width="275px" Enabled="False"
                                                                                DataValueField="BrickID" DataTextField="BrickName" DataSourceID="odsBrick">
                                                                            </asp:DropDownList><asp:TextBox ID="txtBrickID" runat="server" Text='<%# Bind("BrickID") %>'
                                                                                Visible="False" Width="15px"></asp:TextBox></td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblPhone" runat="server" CssClass="MainfontStyle" Text="Primary  Phone :"></asp:Label></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtPhone1" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("Phone1") %>'
                                                                                Width="270px"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtPhone1"
                                                                                Display="Dynamic" ErrorMessage="Invalid Spelling" ValidationExpression="^([a-zA-Z0-9]{1})([_\\'\,\.\-\ a-zA-Z0-9])*">*</asp:RegularExpressionValidator></td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblPhone2" runat="server" CssClass="MainfontStyle" Text="Secondary Phone :"></asp:Label></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtPhone2" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("Phone2") %>'
                                                                                Width="270px"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtPhone2"
                                                                                Display="Dynamic" ErrorMessage="Invalid Spelling" ValidationExpression="^([a-zA-Z0-9]{1})([_\\'\,\.\-\ a-zA-Z0-9])*">*</asp:RegularExpressionValidator></td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblMobile" runat="server" CssClass="MainfontStyle" Text="Mobile :"></asp:Label></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtMobile" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("Mobile") %>'
                                                                                Width="270px"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtMobile"
                                                                                Display="Dynamic" ErrorMessage="Invalid Spelling" ValidationExpression="^([a-zA-Z0-9]{1})([_\\'\,\.\-\ a-zA-Z0-9])*">*</asp:RegularExpressionValidator></td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblPostalCode" runat="server" CssClass="MainfontStyle" Text="Postal Code :"></asp:Label></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtPostalCode" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                Text='<%# Bind("PostalCode") %>' Width="270px"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtPostalCode"
                                                                                Display="Dynamic" ErrorMessage="Invalid Spelling" ValidationExpression="^([a-zA-Z0-9]{1})([_\\'\,\.\-\ a-zA-Z0-9])*">*</asp:RegularExpressionValidator></td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" align="right">
                                                                            <asp:Label ID="lblComment" runat="server" CssClass="MainfontStyle" Text="Comments :"></asp:Label></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtComment" runat="server" CssClass="inputs" Height="60px" ReadOnly="True"
                                                                                Text='<%# Bind("Comment") %>' TextMode="MultiLine" Width="270px"></asp:TextBox></td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td valign="middle">
                                                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="StyleValidationSummary" />
                                                                            </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                        </td>
                                                                        <td>
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
                                            <asp:ObjectDataSource ID="odsBrick" runat="server" OldValuesParameterFormatString="original_{0}"
                                                SelectMethod="SelectBricks" TypeName="Pharma.BMD.BLL.LookupsBLL"></asp:ObjectDataSource>
                                            <asp:ObjectDataSource ID="odsGov" runat="server" OldValuesParameterFormatString="original_{0}"
                                                SelectMethod="GetSCodeByGCode" TypeName="Pharma.BMD.BLL.LookupsBLL">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="Gov" Name="GeneralCode" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td rowspan="13">
                                        </td>
                                        <td rowspan="13" align="left">
                                            <table style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td colspan="3" rowspan="2">
                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" class="tblStyle">
                                                                <tbody>
                                                                    <tr>
                                                                        <td colspan="3" rowspan="3">
                                                                            <table style="width: 100%">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td valign="top" align="left" colspan="8" rowspan="1">
                                                                                            <asp:Label ID="lblRxAccounts" runat="server" CssClass="MainfontStyle" Text="Rx Resources - Accounts"></asp:Label></td>
                                                                                        <td valign="top" align="left" colspan="2" rowspan="1">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" colspan="10" rowspan="1">
                                                                                            <asp:Panel ID="pnlMedicalAccounts" runat="server" Width="100%" ScrollBars="Auto"
                                                                                                        Height="160px" HorizontalAlign="Left">
                                                                                                <asp:GridView ID="gvMedicalAccounts" runat="server" DataKeyNames="MedicalAccountID" BackColor="White" OnRowDataBound="gvMedicalAccounts_RowDataBound"
                                                                                                            AutoGenerateColumns="False" Width="95%" EmptyDataText="No Data Found" BorderWidth="1px" BorderStyle="Solid"
                                                                                                            BorderColor="#999999">
                                                                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                                                    <RowStyle CssClass="GridNormalRowsStyle" />
                                                                                                    <Columns>
                                                                                                        <asp:BoundField DataField="Name" HeaderText="Medical Accounts" SortExpression="Name">
                                                                                                            <HeaderStyle HorizontalAlign="Center" Width="90%" />
                                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                                        </asp:BoundField>
                                                                                                        <asp:TemplateField HeaderText="Select">
                                                                                                            <EditItemTemplate>
                                                                                                                <asp:CheckBox ID="cbxEditMedicalAcc" runat="server" Checked='<%# Bind("Selected") %>' />
                                                                                                            </EditItemTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:CheckBox ID="cbxSelectMedicalAcc" runat="server" Checked='<%# Bind("Selected") %>'
                                                                                                                            Enabled="False" />
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                                                                    <HeaderStyle CssClass="GridHeaderBackStyle" Font-Bold="True" ForeColor="Black"  />
                                                                                                    <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                    <EmptyDataTemplate>
                                                                                                        <asp:Label ID="lblNoMedical" runat="server" CssClass="StyleNoData" Font-Bold="True"
                                                                                                            Text="No Medical Accounts Assigned"></asp:Label>
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
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" class="tblStyle">
                                                                <tbody>
                                                                    <tr>
                                                                        <td colspan="3" rowspan="3">
                                                                            <table style="width: 100%">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td valign="top" align="left" colspan="8" rowspan="1">
                                                                                            <asp:Label ID="lblRxRes" runat="server" CssClass="MainfontStyle" Text="Rx Resources - Physcians"></asp:Label></td>
                                                                                        <td valign="top" align="left" colspan="2" rowspan="1">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" colspan="10" rowspan="1">
                                                                                            <asp:Panel ID="pnlPhyscians" runat="server" Width="100%" ScrollBars="Auto" Height="160px"
                                                                                                        HorizontalAlign="Left">
                                                                                                <asp:GridView ID="gvPhyscians" runat="server" BorderWidth="1px" BorderStyle="Solid"
                                                                                                            BorderColor="#999999" DataKeyNames="PhysicianID" BackColor="White" OnRowDataBound="gvPhyscians_RowDataBound"
                                                                                                            AutoGenerateColumns="False" Width="95%" EmptyDataText="No Data Found">
                                                                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                                                    <RowStyle CssClass="GridNormalRowsStyle" />
                                                                                                    <Columns>
                                                                                                        <asp:BoundField DataField="PhysicianName" HeaderText="Physician Name" SortExpression="PhysicianName">
                                                                                                            <HeaderStyle HorizontalAlign="Center" Width="90%" />
                                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                                        </asp:BoundField>
                                                                                                        <asp:TemplateField HeaderText="Select">
                                                                                                            <EditItemTemplate>
                                                                                                                <asp:CheckBox ID="cbxEditPhyscians" runat="server" Checked='<%# Bind("Selected") %>' />
                                                                                                            </EditItemTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:CheckBox ID="cbxSelectPhyscians" runat="server" Checked='<%# Bind("Selected") %>'
                                                                                                                            Enabled="False" />
                                                                                                            </ItemTemplate>
                                                                                                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                                                                    <HeaderStyle CssClass="GridHeaderBackStyle" Font-Bold="True" ForeColor="Black" />
                                                                                                    <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                    <EmptyDataTemplate>
                                                                                                        <asp:Label ID="lblNoPhyscians" runat="server" CssClass="StyleNoData" Font-Bold="True"
                                                                                                            Text="No Physcians Assigned"></asp:Label>
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
                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" class="tblStyle">
                                                                <tbody>
                                                                    <tr>
                                                                        <td colspan="3" rowspan="3">
                                                                            <table style="width: 100%">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td valign="top" align="left" colspan="8" rowspan="1">
                                                                                            <asp:Label ID="lblDistributors" runat="server" CssClass="MainfontStyle" Text="Distributors"></asp:Label></td>
                                                                                        <td valign="top" align="left" colspan="2" rowspan="1">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" colspan="10" rowspan="1">
                                                                                            <asp:Panel ID="pnlDistributor" runat="server" Width="100%" ScrollBars="Auto" Height="160px"
                                                                                                        HorizontalAlign="Left">
                                                                                                <asp:GridView ID="gvDistributors" runat="server" BorderWidth="1px" BorderStyle="Solid"
                                                                                                            BorderColor="#999999" DataKeyNames="DistributorID" BackColor="White" OnRowDataBound="gvDistributors_RowDataBound"
                                                                                                            AutoGenerateColumns="False" Width="95%" EmptyDataText="No Data Found">
                                                                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                                                    <RowStyle CssClass="GridNormalRowsStyle" />
                                                                                                    <Columns>
                                                                                                        <asp:BoundField DataField="Name" HeaderText="Distributor Name" SortExpression="Name">
                                                                                                            <HeaderStyle HorizontalAlign="Center" Width="90%" />
                                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                                        </asp:BoundField>
                                                                                                        <asp:TemplateField HeaderText="Select">
                                                                                                            <EditItemTemplate>
                                                                                                                <asp:CheckBox ID="cbxEditDistributor" runat="server" Checked='<%# Bind("Selected") %>' />
                                                                                                            </EditItemTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:CheckBox ID="cbxSelectDistributor" runat="server" Checked='<%# Bind("Selected") %>'
                                                                                                                            Enabled="False" />
                                                                                                            </ItemTemplate>
                                                                                                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                                                                    <HeaderStyle CssClass="GridHeaderBackStyle" Font-Bold="True" ForeColor="Black" />
                                                                                                    <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                    <EmptyDataTemplate>
                                                                                                        <asp:Label ID="lblNoDistributors" runat="server" CssClass="StyleNoData" Font-Bold="True"
                                                                                                            Text="No Distributors Assigned"></asp:Label>
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
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
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
                                        <td rowspan="1" valign="top">
                                        </td>
                                        <td rowspan="1">
                                        </td>
                                        <td rowspan="1">
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
                </ItemTemplate>
                <RowStyle HorizontalAlign="Center" />
                <EmptyDataTemplate>
                    <table width="100%">
                        <tr>
                            <td align="center" colspan="3" rowspan="3">
                                <table style="width: 100%">
                                    <tr>
                                        <td align="center" colspan="3" rowspan="1">
                                            <table id="Table1" class="tblStyle" style="width: 100%; height: 30px;">
                                                <tbody>
                                                    <tr align="center" width="50%">
                                                        <td align="right" style="width: 40%">
                                                            <asp:Label ID="lblSearch" runat="server" CssClass="MainfontStyle" Text="Search Pharmacies:"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtSearchName" runat="server" AutoPostBack="True" CssClass="inputs"
                                                                OnTextChanged="txtSearchName_TextChanged" Width="300px"></asp:TextBox></td>
                                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" UseContextKey="True"
                                                                    TargetControlID="txtSearchName" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                                                                    FirstRowSelected="true" EnableCaching="true" DelimiterCharacters=";," CompletionSetCount="20"
                                                                    CompletionInterval="10" BehaviorID="autoCompleteBehavior1">
                                                        </cc1:AutoCompleteExtender>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" rowspan="1" style="width: 45%" valign="top">
                                        </td>
                                        <td rowspan="1" style="width: 5%">
                                        </td>
                                        <td rowspan="1" style="width: 50%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td rowspan="13" valign="top" align="left">
                                            <table cellspacing="0" cellpadding="0" width="450">
                                                <tbody>
                                                    <tr>
                                                        <td colspan="3" rowspan="3">
                                                            <table width="100%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td align="right" width="30%">
                                                                            <asp:Label ID="lblName" runat="server" CssClass="MainfontStyle" Text="Pharmacy Name :"></asp:Label></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtPharmacyName" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                Text='<%# Bind("Name") %>' Width="270px"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPharmacyName"
                                                                                Display="Dynamic" ErrorMessage="Pharmacy name is required">*</asp:RequiredFieldValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblPharmacistName" runat="server" CssClass="MainfontStyle" Text="Pharmacist Name :"></asp:Label></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtPharmacistName" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                Text='<%# Bind("PharmacistName") %>' Width="270px"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPharmacistName"
                                                                                Display="Dynamic" ErrorMessage="Pharmacist name is required">*</asp:RequiredFieldValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblGov" runat="server" CssClass="MainfontStyle" Text="Gov:"></asp:Label></td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlGov" runat="server" CssClass="inputs" Width="275px" OnDataBound="ddlGov_DataBound"
                                                                                Enabled="False" OnSelectedIndexChanged="ddlGov_SelectedIndexChanged" DataValueField="SID"
                                                                                DataTextField="SubCode" DataSourceID="odsGov" SelectedValue='<%# Bind("GovID") %>'
                                                                                AutoPostBack="True">
                                                                            </asp:DropDownList><asp:TextBox ID="txtGov" runat="server" Text='<%# Bind("GovID") %>'
                                                                                Visible="False" Width="15px"></asp:TextBox></td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblCity" runat="server" CssClass="MainfontStyle" Text="City:"></asp:Label></td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlCity" runat="server" CssClass="inputs" Width="275px" Enabled="False"
                                                                                DataValueField="CityID" DataTextField="City">
                                                                            </asp:DropDownList><asp:TextBox ID="txtCity" runat="server" Text='<%# Bind("CityID") %>'
                                                                                Visible="False" Width="15px"></asp:TextBox></td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblArea" runat="server" CssClass="MainfontStyle" Text="Area:"></asp:Label></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtArea" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("Area") %>'
                                                                                Width="270px"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtArea"
                                                                                Display="Dynamic" ErrorMessage="Area is required">*</asp:RequiredFieldValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblAddress" runat="server" CssClass="MainfontStyle" Text="Address: "></asp:Label></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("Address") %>'
                                                                                Width="270px"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAddress"
                                                                                Display="Dynamic" ErrorMessage="Address is required">*</asp:RequiredFieldValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblBrick" runat="server" CssClass="MainfontStyle" Text="Brick :"></asp:Label></td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlBrick" runat="server" CssClass="inputs" Width="275px" Enabled="False"
                                                                                DataValueField="BrickID" DataTextField="BrickName" DataSourceID="odsBrick">
                                                                            </asp:DropDownList><asp:TextBox ID="txtBrickID" runat="server" Text='<%# Bind("BrickID") %>'
                                                                                Visible="False" Width="15px"></asp:TextBox></td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblPhone" runat="server" CssClass="MainfontStyle" Text="Primary  Phone :"></asp:Label></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtPhone1" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("Phone1") %>'
                                                                                Width="270px"></asp:TextBox></td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblPhone2" runat="server" CssClass="MainfontStyle" Text="Secondary Phone :"></asp:Label></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtPhone2" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("Phone2") %>'
                                                                                Width="270px"></asp:TextBox></td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblMobile" runat="server" CssClass="MainfontStyle" Text="Mobile :"></asp:Label></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtMobile" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("Mobile") %>'
                                                                                Width="270px"></asp:TextBox></td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblPostalCode" runat="server" CssClass="MainfontStyle" Text="Postal Code :"></asp:Label></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtPostalCode" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                Text='<%# Bind("PostalCode") %>' Width="270px"></asp:TextBox></td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" align="right">
                                                                            <asp:Label ID="lblComment" runat="server" CssClass="MainfontStyle" Text="Comments :"></asp:Label></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtComment" runat="server" CssClass="inputs" Height="60px" ReadOnly="True"
                                                                                Text='<%# Bind("Comment") %>' TextMode="MultiLine" Width="270px"></asp:TextBox></td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td valign="middle">
                                                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="StyleValidationSummary" />
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                        </td>
                                                                        <td>
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
                                            <asp:ObjectDataSource ID="odsBrick" runat="server" OldValuesParameterFormatString="original_{0}"
                                                SelectMethod="SelectBricks" TypeName="Pharma.BMD.BLL.LookupsBLL"></asp:ObjectDataSource>
                                            <asp:ObjectDataSource ID="odsGov" runat="server" OldValuesParameterFormatString="original_{0}"
                                                SelectMethod="GetSCodeByGCode" TypeName="Pharma.BMD.BLL.LookupsBLL">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="Gov" Name="GeneralCode" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td rowspan="13">
                                        </td>
                                        <td rowspan="13" align="left">
                                            <table style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td colspan="3" rowspan="2">
                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" class="tblStyle">
                                                                <tbody>
                                                                    <tr>
                                                                        <td colspan="3" rowspan="3">
                                                                            <table style="width: 100%">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td valign="top" align="left" colspan="8" rowspan="1">
                                                                                            <asp:Label ID="lblRxAccounts" runat="server" CssClass="MainfontStyle" Text="Rx Resources - Accounts"></asp:Label></td>
                                                                                        <td valign="top" align="left" colspan="2" rowspan="1">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" colspan="10" rowspan="1">
                                                                                            <asp:Panel ID="pnlMedicalAccounts" runat="server" Width="100%" ScrollBars="Auto"
                                                                                                        Height="160px" HorizontalAlign="Left">
                                                                                                <asp:GridView ID="gvMedicalAccounts" runat="server" BorderWidth="1px" BorderStyle="Solid"
                                                                                                            BorderColor="#999999" DataKeyNames="MedicalAccountID" BackColor="White" OnRowDataBound="gvMedicalAccounts_RowDataBound"
                                                                                                            AutoGenerateColumns="False" Width="95%">
                                                                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                                                    <RowStyle CssClass="GridNormalRowsStyle" />
                                                                                                    <Columns>
                                                                                                        <asp:BoundField DataField="Name" HeaderText="Medical Accounts" SortExpression="Name">
                                                                                                            <HeaderStyle HorizontalAlign="Center" Width="90%" />
                                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                                        </asp:BoundField>
                                                                                                        <asp:TemplateField HeaderText="Select">
                                                                                                            <EditItemTemplate>
                                                                                                                <asp:CheckBox ID="cbxEditMedicalAcc" runat="server" Checked='<%# Bind("Selected") %>' />
                                                                                                            </EditItemTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:CheckBox ID="cbxSelectMedicalAcc" runat="server" Checked='<%# Bind("Selected") %>'
                                                                                                                            Enabled="False" />
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                                                                    <HeaderStyle CssClass="GridHeaderBackStyle" Font-Bold="True" ForeColor="Black" />
                                                                                                    <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                    <EmptyDataTemplate>
                                                                                                        <asp:Label ID="lblNoMedical" runat="server" Font-Bold="True" Text="No Medical Accounts Assigned" CssClass="StyleNoData"></asp:Label>
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
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" class="tblStyle">
                                                                <tbody>
                                                                    <tr>
                                                                        <td colspan="3" rowspan="3">
                                                                            <table style="width: 100%">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td valign="top" align="left" colspan="8" rowspan="1">
                                                                                            <asp:Label ID="lblRxRes" runat="server" CssClass="MainfontStyle" Text="Rx Resources - Physcians"></asp:Label></td>
                                                                                        <td valign="top" align="left" colspan="2" rowspan="1">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" colspan="10" rowspan="1">
                                                                                            <asp:Panel ID="pnlPhyscians" runat="server" Width="100%" ScrollBars="Auto" Height="160px"
                                                                                                        HorizontalAlign="Left">
                                                                                                <asp:GridView ID="gvPhyscians" runat="server" BorderWidth="1px" BorderStyle="Solid"
                                                                                                            BorderColor="#999999" DataKeyNames="PhysicianID" BackColor="White" OnRowDataBound="gvPhyscians_RowDataBound"
                                                                                                            AutoGenerateColumns="False" Width="95%">
                                                                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                                                    <RowStyle CssClass="GridNormalRowsStyle" />
                                                                                                    <Columns>
                                                                                                        <asp:BoundField DataField="PhysicianName" HeaderText="Physician Name" SortExpression="PhysicianName">
                                                                                                            <HeaderStyle HorizontalAlign="Center" Width="90%" />
                                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                                        </asp:BoundField>
                                                                                                        <asp:TemplateField HeaderText="Select">
                                                                                                            <EditItemTemplate>
                                                                                                                <asp:CheckBox ID="cbxEditPhyscians" runat="server" Checked='<%# Bind("Selected") %>' />
                                                                                                            </EditItemTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:CheckBox ID="cbxSelectPhyscians" runat="server" Checked='<%# Bind("Selected") %>'
                                                                                                                            Enabled="False" />
                                                                                                            </ItemTemplate>
                                                                                                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                                                                    <HeaderStyle CssClass="GridHeaderBackStyle" Font-Bold="True" ForeColor="Black" />
                                                                                                    <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                    <EmptyDataTemplate>
                                                                                                        <asp:Label ID="lblNoPhyscians" runat="server" Font-Bold="True" Text="No Physcians Assigned" CssClass="StyleNoData"></asp:Label>
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
                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" class="tblStyle">
                                                                <tbody>
                                                                    <tr>
                                                                        <td colspan="3" rowspan="3">
                                                                            <table style="width: 100%">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td valign="top" align="left" colspan="8" rowspan="1">
                                                                                            <asp:Label ID="lblDistributors" runat="server" CssClass="MainfontStyle" Text="Distributors"></asp:Label></td>
                                                                                        <td valign="top" align="left" colspan="2" rowspan="1">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" colspan="10" rowspan="1">
                                                                                            <asp:Panel ID="pnlDistributor" runat="server" Width="100%" ScrollBars="Auto" Height="160px"
                                                                                                        HorizontalAlign="Left">
                                                                                                <asp:GridView ID="gvDistributors" runat="server" BorderWidth="1px" BorderStyle="Solid"
                                                                                                            BorderColor="#999999" DataKeyNames="DistributorID" BackColor="White" OnRowDataBound="gvDistributors_RowDataBound"
                                                                                                            AutoGenerateColumns="False" Width="95%">
                                                                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                                                    <RowStyle CssClass="GridNormalRowsStyle" />
                                                                                                    <Columns>
                                                                                                        <asp:BoundField DataField="Name" HeaderText="Distributor Name" SortExpression="Name">
                                                                                                            <HeaderStyle HorizontalAlign="Center" Width="90%" />
                                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                                        </asp:BoundField>
                                                                                                        <asp:TemplateField HeaderText="Select">
                                                                                                            <EditItemTemplate>
                                                                                                                <asp:CheckBox ID="cbxEditDistributor" runat="server" Checked='<%# Bind("Selected") %>' />
                                                                                                            </EditItemTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:CheckBox ID="cbxSelectDistributor" runat="server" Checked='<%# Bind("Selected") %>'
                                                                                                                            Enabled="False" />
                                                                                                            </ItemTemplate>
                                                                                                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                                                                    <HeaderStyle CssClass="GridHeaderBackStyle" Font-Bold="True" ForeColor="Black" />
                                                                                                    <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                    <EmptyDataTemplate>
                                                                                                        <asp:Label ID="lblNoDistributors" runat="server" Font-Bold="True" Text="No Distributors Assigned" CssClass="StyleNoData"></asp:Label>
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
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
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
                                        <td rowspan="1" valign="top">
                                        </td>
                                        <td rowspan="1">
                                        </td>
                                        <td rowspan="1">
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
                </EmptyDataTemplate>
            </asp:FormView>
                                                    <asp:Label ID="lblNoDataMsg" runat="server" CssClass="MainfontStyle"></asp:Label><asp:Label ID="lblDupName" runat="server" Font-Names="Arial" Font-Size="12px" ForeColor="Red"
                                                                                Text="Duplicated name" Visible="False"></asp:Label><br /><asp:Label
                                                        ID="lblmsg" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                                        ForeColor="#004000" Text='Your request for adding new Pharmacy is in "Pending" phase until Acceptance from your Manager'
                                                        Visible="False"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">
    var scrollTop;
    var scrollTop1;
    var scrollTop2;
  
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler1);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler1);

    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler2);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler2);

      function BeginRequestHandler(sender, args) 
        {
          var elem = document.getElementById('ctl00_ContentPlaceHolder1_frmViewPharmacies_pnlMedicalAccounts');
              if(elem!= null)
              scrollTop=elem.scrollTop;
        }

      function EndRequestHandler(sender, args)
       {
       var elem = document.getElementById('ctl00_ContentPlaceHolder1_frmViewPharmacies_pnlMedicalAccounts');
            if(elem!= null)
           elem.scrollTop = scrollTop;
  
      }  
      
      ///
      function BeginRequestHandler1(sender, args) 
        {
          var elem = document.getElementById('ctl00_ContentPlaceHolder1_frmViewPharmacies_pnlPhyscians');
              if(elem!= null)
              scrollTop1=elem.scrollTop;
        }

      function EndRequestHandler1(sender, args)
       {
          var elem = document.getElementById('ctl00_ContentPlaceHolder1_frmViewPharmacies_pnlPhyscians');
            if(elem!= null)
            elem.scrollTop = scrollTop1;
  
      }  
      ///
      function BeginRequestHandler2(sender, args) 
        {
          var elem = document.getElementById('ctl00_ContentPlaceHolder1_frmViewPharmacies_pnlDistributor');
              if(elem!= null)
              scrollTop2=elem.scrollTop;
        }

      function EndRequestHandler2(sender, args)
       {
          var elem = document.getElementById('ctl00_ContentPlaceHolder1_frmViewPharmacies_pnlDistributor');
            if(elem!= null)
            elem.scrollTop = scrollTop2;
  
      }  
      
      
       
         
  
    
    </script>

    <asp:ObjectDataSource ID="odsPharmacies" runat="server" EnablePaging="True" OldValuesParameterFormatString="original_{0}"
        SelectCountMethod="MaxRowCount" SelectMethod="SelectPharmacies" TypeName="Pharma.BMD.BLL.PharmaciesBLL">
        <SelectParameters>
            <asp:Parameter DefaultValue="" Name="startRowIndex" Type="Int32" />
            <asp:Parameter DefaultValue="1" Name="maximumRows" Type="Int32" />
            <asp:SessionParameter DefaultValue="" Name="ShowAll" SessionField="ShowAll" />
        </SelectParameters>
    </asp:ObjectDataSource>

</asp:Content>
