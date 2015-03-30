<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PrivateClinics.aspx.cs" Inherits="PrivateClinics" Title=":: 4A-Pharma BMD :: Private Clinics ::" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="Controls/TransButtons.ascx" TagName="TransButtons" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td align="center" colspan="3" rowspan="3">
                <table>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                        <table id="tblsearch" class="tblStyle" style="width: 505px; height: 30px">
                                            <tbody>
                                                <tr>
                                                    <td style="text-align: right">
                                                        <asp:Label ID="lblSearch" runat="server" CssClass="MainfontStyle" Text="Search Private Clinics:"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left">
                                                        <asp:TextBox ID="txtSearchName" runat="server" CssClass="inputs" Width="300px" AutoPostBack="True"
                                                            OnTextChanged="txtSearchName_TextChanged"></asp:TextBox>
                                                    </td>
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
                                    <asp:FormView ID="frmViewPrivateClinics" runat="server" OnPageIndexChanging="frmViewPrivateClinics_PageIndexChanging"
                                        DataKeyNames="PrivateClinicID" AllowPaging="True" BackImageUrl="~/Images/BG-1.jpg"
                                        BorderColor="DarkGray" BorderStyle="Solid" BorderWidth="1px">
                                        <PagerSettings FirstPageText="First" LastPageText="Last"
                                            NextPageImageUrl="~/Images/next_n.jpg" NextPageText="Next" PreviousPageImageUrl="~/Images/previous_n.jpg"
                                            PreviousPageText="Previous" Mode="NumericFirstLast">
                                        </PagerSettings>
                                        <ItemTemplate>
                                            <table cellspacing="0" cellpadding="0" width="500">
                                                <tbody>
                                                    <tr>
                                                        <td colspan="3" rowspan="3">
                                                            <table width="100%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td align="right" width="30%">
                                                                            <asp:Label ID="lblClinicName" runat="server" CssClass="MainfontStyle" Text="Clinic Name"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtClinicName" runat="server" CssClass="inputs" Text='<%# Bind("Name") %>'
                                                                                Width="270px" ReadOnly="True"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Clinic name is required"
                                                                                Display="Dynamic" ControlToValidate="txtClinicName">*</asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtClinicName"
                                                                                Display="Dynamic" ErrorMessage="Invalid Spelling" ValidationExpression="^([^~`!@#$%\^&\*\(\)\-+=\\\|\}\]\{\['&quot;:?.>,</]{1})([^~`!@#$%\^&\*\(\)+=\|\}\]\{\[&quot;:?></])*">*</asp:RegularExpressionValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblPhysician" runat="server" CssClass="MainfontStyle" Text="Physician:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:DropDownList ID="ddlPhysician" runat="server" CssClass="inputs" Width="275px"
                                                                                DataValueField="PhysicianID" DataTextField="PhysicianName" DataSourceID="odsPhysicians"
                                                                                Enabled="False">
                                                                            </asp:DropDownList><asp:TextBox ID="txtPhysician" runat="server" Text='<%# Bind("PhysicianID") %>'
                                                                                Width="15px" Visible="False"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblGov" runat="server" CssClass="MainfontStyle" Text="Gov:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:DropDownList ID="ddlGov" runat="server" CssClass="inputs" Width="275px" DataValueField="SID"
                                                                                DataTextField="SubCode" DataSourceID="odsGov" Enabled="False" SelectedValue='<%# Bind("GovID") %>'
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
                                                                            <asp:DropDownList ID="ddlCity" runat="server" CssClass="inputs" Width="275px" DataValueField="CityID"
                                                                                DataTextField="City" Enabled="False">
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
                                                                                Width="270px" ReadOnly="True"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Area is required"
                                                                                Display="Dynamic" ControlToValidate="txtArea">*</asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtArea"
                                                                                Display="Dynamic" ErrorMessage="Invalid Spelling" ValidationExpression="^([^~`!@#$%\^&\*\(\)\-+=\\\|\}\]\{\['&quot;:?.>,</]{1})([^~`!@#$%\^&\*\(\)+=\|\}\]\{\[&quot;:?></])*">*</asp:RegularExpressionValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblAddress" runat="server" CssClass="MainfontStyle" Text="Address: "></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="inputs" Text='<%# Bind("Address") %>'
                                                                                Width="270px" ReadOnly="True"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Address is required"
                                                                                Display="Dynamic" ControlToValidate="txtAddress">*</asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAddress"
                                                                                Display="Dynamic" ErrorMessage="Invalid Spelling" ValidationExpression="^([^~`!@#$%\^&\*\(\)\-+=\\\|\}\]\{\['&quot;:?.>,</]{1})([^~`!@#$%\^&\*\(\)+=\|\}\]\{\[&quot;:?></])*">*</asp:RegularExpressionValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblBrick" runat="server" CssClass="MainfontStyle" Text="Brick :"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:DropDownList ID="ddlBrick" runat="server" CssClass="inputs" Width="275px" DataValueField="BrickID"
                                                                                DataTextField="BrickName" DataSourceID="odsBrick" Enabled="False">
                                                                            </asp:DropDownList><asp:TextBox ID="txtBrickID" runat="server" Text='<%# Bind("BrickID") %>'
                                                                                Width="15px" Visible="False"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblPhone" runat="server" CssClass="MainfontStyle" Text="Phone 1:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtPhone1" runat="server" CssClass="inputs" Text='<%# Bind("Phone1") %>'
                                                                                Width="270px" ReadOnly="True"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtPhone1"
                                                                                Display="Dynamic" ErrorMessage="Invalid Spelling" ValidationExpression="^([^~`!@#$%\^&\*\(\)\-+=\\\|\}\]\{\['&quot;:?.>,</]{1})([^~`!@#$%\^&\*\(\)+=\|\}\]\{\[&quot;:?></])*">*</asp:RegularExpressionValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblPhone2" runat="server" CssClass="MainfontStyle" Text="Phone 2:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtPhone2" runat="server" CssClass="inputs" Text='<%# Bind("Phone2") %>'
                                                                                Width="270px" ReadOnly="True"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtPhone2"
                                                                                Display="Dynamic" ErrorMessage="Invalid Spelling" ValidationExpression="^([^~`!@#$%\^&\*\(\)\-+=\\\|\}\]\{\['&quot;:?.>,</]{1})([^~`!@#$%\^&\*\(\)+=\|\}\]\{\[&quot;:?></])*">*</asp:RegularExpressionValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblMobile" runat="server" CssClass="MainfontStyle" Text="Mobile:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtMobile" runat="server" CssClass="inputs" Text='<%# Bind("Mobile") %>'
                                                                                Width="270px" ReadOnly="True"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtMobile"
                                                                                Display="Dynamic" ErrorMessage="Invalid Spelling" ValidationExpression="^([^~`!@#$%\^&\*\(\)\-+=\\\|\}\]\{\['&quot;:?.>,</]{1})([^~`!@#$%\^&\*\(\)+=\|\}\]\{\[&quot;:?></])*">*</asp:RegularExpressionValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblPostalCode" runat="server" CssClass="MainfontStyle" Text="Postal Code :"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtPostalCode" runat="server" CssClass="inputs" Text='<%# Bind("PostalCode") %>'
                                                                                Width="270px" ReadOnly="True"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtPostalCode"
                                                                                Display="Dynamic" ErrorMessage="Invalid Spelling" ValidationExpression="^([^~`!@#$%\^&\*\(\)\-+=\\\|\}\]\{\['&quot;:?.>,</]{1})([^~`!@#$%\^&\*\(\)+=\|\}\]\{\[&quot;:?></])*">*</asp:RegularExpressionValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblEmail" runat="server" CssClass="MainfontStyle" Text="E-mail :"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="inputs" Text='<%# Bind("Email") %>'
                                                                                Width="270px" ReadOnly="True"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                            <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" ControlToValidate="txtEmail"
                                                                                Display="Dynamic" ErrorMessage="Invalid e-mail address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" align="right">
                                                                            <asp:Label ID="lblComment" runat="server" CssClass="MainfontStyle" Text="Comment:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtComment" runat="server" CssClass="inputs" Text='<%# Bind("Comment") %>'
                                                                                Width="270px" ReadOnly="True" TextMode="MultiLine" Height="86px"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                        </td>
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
                                                                        <td align="left">
                                                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="StyleValidationSummary"></asp:ValidationSummary>
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
                                                                        <td align="right" width="30%">
                                                                            <asp:Label ID="lblClinicName" runat="server" CssClass="MainfontStyle" Text="Clinic Name"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtClinicName" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                Text='<%# Bind("Name") %>' Width="270px"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtClinicName"
                                                                                Display="Dynamic" ErrorMessage="Clinic name is required">*</asp:RequiredFieldValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblPhysician" runat="server" CssClass="MainfontStyle" Text="Physician:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:DropDownList ID="ddlPhysician" runat="server" CssClass="inputs" Width="275px"
                                                                                DataValueField="PhysicianID" DataTextField="PhysicianName" DataSourceID="odsPhysicians"
                                                                                Enabled="False">
                                                                            </asp:DropDownList><asp:TextBox ID="txtPhysician" runat="server" Text='<%# Bind("PhysicianID") %>'
                                                                                Visible="False" Width="15px"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblGov" runat="server" CssClass="MainfontStyle" Text="Gov:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:DropDownList ID="ddlGov" runat="server" CssClass="inputs" Width="275px" DataValueField="SID"
                                                                                DataTextField="SubCode" DataSourceID="odsGov" Enabled="False" SelectedValue='<%# Bind("GovID") %>'
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
                                                                            <asp:DropDownList ID="ddlCity" runat="server" CssClass="inputs" Width="275px" DataValueField="CityID"
                                                                                DataTextField="City" Enabled="False">
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
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtArea"
                                                                                Display="Dynamic" ErrorMessage="Area is required">*</asp:RequiredFieldValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblAddress" runat="server" CssClass="MainfontStyle" Text="Address: "></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("Address") %>'
                                                                                Width="270px"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAddress"
                                                                                Display="Dynamic" ErrorMessage="Address is required">*</asp:RequiredFieldValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblBrick" runat="server" CssClass="MainfontStyle" Text="Brick :"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:DropDownList ID="ddlBrick" runat="server" CssClass="inputs" Width="275px" DataValueField="BrickID"
                                                                                DataTextField="BrickName" DataSourceID="odsBrick" Enabled="False">
                                                                            </asp:DropDownList><asp:TextBox ID="txtBrickID" runat="server" Text='<%# Bind("BrickID") %>'
                                                                                Visible="False" Width="15px"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblPhone" runat="server" CssClass="MainfontStyle" Text="Phone 1:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtPhone1" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("Phone1") %>'
                                                                                Width="270px"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblPhone2" runat="server" CssClass="MainfontStyle" Text="Phone 2:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtPhone2" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("Phone2") %>'
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
                                                                            <asp:Label ID="lblEmail" runat="server" CssClass="MainfontStyle" Text="E-mail :"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("Email") %>'
                                                                                Width="270px"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                            <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" ControlToValidate="txtEmail"
                                                                                Display="Dynamic" ErrorMessage="Invalid e-mail address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" align="right">
                                                                            <asp:Label ID="lblComment" runat="server" CssClass="MainfontStyle" Text="Comment:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtComment" runat="server" CssClass="inputs" Height="86px" ReadOnly="True"
                                                                                Text='<%# Bind("Comment") %>' TextMode="MultiLine" Width="270px"></asp:TextBox></td>
                                                                        <td style="text-align: left">
                                                                        </td>
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
                                                                        <td align="left">
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
                                        </EmptyDataTemplate>
                                    </asp:FormView>
                                    <asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                        ForeColor="#004000" Text='Your request for adding new Private Clinic is in "Pending" phase until Acceptance from your Manager'
                                        Visible="False"></asp:Label>
                                                                            <asp:Label ID="lblDupName" runat="server" Font-Names="Arial" Font-Size="12px" ForeColor="Red"
                                                                                Text="Duplicated name" Visible="False"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
                <asp:ObjectDataSource ID="odsBrick" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="SelectBricks" TypeName="Pharma.BMD.BLL.LookupsBLL"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsGov" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetSCodeByGCode" TypeName="Pharma.BMD.BLL.LookupsBLL">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="Gov" Name="GeneralCode" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsPhysicians" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetPhysicianNameList" TypeName="Pharma.BMD.BLL.PhysiciansBLL"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsPrivateClinics" runat="server" EnablePaging="True"
                    OldValuesParameterFormatString="original_{0}" SelectCountMethod="MaxRowCount"
                    SelectMethod="SelectPrivateClinics" TypeName="Pharma.BMD.BLL.PrivateClinicsBLL">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="" Name="startRowIndex" Type="Int32" />
                        <asp:Parameter DefaultValue="1" Name="maximumRows" Type="Int32" />
                        <asp:SessionParameter DefaultValue="" Name="ShowAll" SessionField="ShowAll" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
    </table>
</asp:Content>
