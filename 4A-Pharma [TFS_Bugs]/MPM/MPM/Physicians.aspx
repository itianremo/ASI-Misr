<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Physicians.aspx.cs" Inherits="Physicians" Title=":: MPM - BMD :: Physicians ::" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="Controls/TransButtons.ascx" TagName="TransButtons" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:FormView ID="frmViewPhysicians" runat="server" OnDataBound="frmViewPhysicians_DataBound"
                Height="800px" Width="100%" BorderWidth="1px" BorderStyle="Solid" BorderColor="DarkGray"
                BackImageUrl="~/Images/BG-1.jpg" AllowPaging="True" DataKeyNames="PhysicianID"
                OnPageIndexChanging="frmViewPhysicians_PageIndexChanging">
                <PagerSettings FirstPageText="First" LastPageText="Last" NextPageImageUrl="~/Images/next_n.jpg"
                    NextPageText="Next" PreviousPageImageUrl="~/Images/previous_n.jpg" PreviousPageText="Previous"
                    Mode="NumericFirstLast"></PagerSettings>
                <RowStyle VerticalAlign="Top"></RowStyle>
                <ItemTemplate>
                    <table width="100%">
                        <tbody>
                            <tr>
                                <td align="center" colspan="3" rowspan="3">
                                    <table style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td valign="top" align="center" colspan="3" rowspan="1">
                                                    <table style="z-index: 1; position: relative; width: 100%; height: 30px" id="tblsearch"
                                                        class="tblStyle">
                                                        <tbody>
                                                            <tr align="center" width="50%">
                                                                <td style="width: 40%" align="right">
                                                                    <asp:Label ID="lblSearch" runat="server" CssClass="MainfontStyle" Text="Search Physicians:"></asp:Label></td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtSearchName" runat="server" CssClass="inputs" Width="300px" OnTextChanged="txtSearchName_TextChanged"
                                                                        AutoPostBack="True"></asp:TextBox>
                                                                </td>
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
                                                <td align="left" rowspan="1">
                                                </td>
                                                <td style="width: 10px" rowspan="1">
                                                </td>
                                                <td rowspan="1">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" align="left" rowspan="13">
                                                    <table cellspacing="0" cellpadding="0" width="450">
                                                        <tbody>
                                                            <tr>
                                                                <td colspan="3" rowspan="3">
                                                                    <table width="100%">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <asp:Label ID="lblName" runat="server" CssClass="MainfontStyle" Text="Physician Name :"></asp:Label></td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtPhysicianName" runat="server" CssClass="inputs" Width="270px"
                                                                                        Text='<%# Bind("PhysicianName") %>' ReadOnly="True"></asp:TextBox></td>
                                                                                <td align="left">
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                                                        ControlToValidate="txtPhysicianName" ErrorMessage="Physician name is required">*</asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPhysicianName"
                                                                                        Display="Dynamic" ErrorMessage="Invalid Spelling" ValidationExpression="^([a-zA-Z]{1})([_\\'\,\.\-\ a-zA-Z0-9])*">*</asp:RegularExpressionValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <asp:Label ID="lblPharmacistName" runat="server" CssClass="MainfontStyle" Text="AKA :"></asp:Label></td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtAKA" runat="server" CssClass="inputs" Width="270px" Text='<%# Bind("AKA") %>'
                                                                                        ReadOnly="True"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtAKA"
                                                                                        Display="Dynamic" ErrorMessage="Invalid Spelling" ValidationExpression="^([a-zA-Z]{1})([_\\'\,\.\-\ a-zA-Z0-9])*">*</asp:RegularExpressionValidator></td>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <asp:Label ID="lblGov" runat="server" CssClass="MainfontStyle" Text="Title :"></asp:Label></td>
                                                                                <td align="left">
                                                                                    <asp:DropDownList ID="ddlTitle" runat="server" CssClass="inputs" Width="275px" SelectedValue='<%# Eval("TitleID") %>'
                                                                                        DataValueField="SID" DataTextField="SubCode" DataSourceID="odsPhysicianTitles"
                                                                                        Enabled="False">
                                                                                    </asp:DropDownList><asp:TextBox ID="txtTitle" runat="server" Width="15px" Visible="False"
                                                                                        Text='<%# Bind("TitleID") %>'></asp:TextBox></td>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <asp:Label ID="lblCity" runat="server" CssClass="MainfontStyle" Text="Speciality :"></asp:Label></td>
                                                                                <td align="left">
                                                                                    <asp:DropDownList ID="ddlSpeciality" runat="server" CssClass="inputs" Width="275px"
                                                                                        SelectedValue='<%# Eval("SpecialityID") %>' DataValueField="SID" DataTextField="SubCode"
                                                                                        DataSourceID="odsPhysicianSpecialitities" Enabled="False">
                                                                                    </asp:DropDownList><asp:TextBox ID="txtSpeciality" runat="server" Width="15px" Visible="False"
                                                                                        Text='<%# Bind("SpecialityID") %>'></asp:TextBox></td>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <asp:Label ID="Label5" runat="server" CssClass="MainfontStyle" Text="Brick :"></asp:Label>
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:DropDownList ID="ddlBrick" runat="server" CssClass="inputs" Width="275px" DataValueField="BrickID"
                                                                                        DataTextField="BrickName" DataSourceID="odsBrick" Enabled="False">
                                                                                    </asp:DropDownList>
                                                                                    <asp:TextBox ID="txtBrick" runat="server" Text='<%# Bind("BrickID") %>' Width="15px"
                                                                                        Visible="False"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <asp:Label ID="lblArea" runat="server" CssClass="MainfontStyle" Text="Owns a Private Clinic :"></asp:Label></td>
                                                                                <td align="left">
                                                                                    <asp:CheckBox ID="chkOwnPrivateClinic" runat="server" Enabled="False" Checked='<%# Bind("PrivateClinic") %>'>
                                                                                    </asp:CheckBox></td>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <asp:Label ID="lblAddress" runat="server" CssClass="MainfontStyle" Text="Mobile : "></asp:Label></td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtMobile" runat="server" CssClass="inputs" Width="270px" Text='<%# Bind("Mobile") %>'
                                                                                        ReadOnly="True"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtMobile"
                                                                                        Display="Dynamic" ErrorMessage="Invalid Spelling" ValidationExpression="^([a-zA-Z0-9]{1})([_\\'\,\.\-\ a-zA-Z0-9])*">*</asp:RegularExpressionValidator></td>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <asp:Label ID="lblBrick" runat="server" CssClass="MainfontStyle" Text="E-mail :"></asp:Label></td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="inputs" Width="270px" Text='<%# Bind("Email") %>'
                                                                                        ReadOnly="True"></asp:TextBox></td>
                                                                                <td align="left">
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                                                                                        ControlToValidate="txtEmail" ErrorMessage="Invalid e-mail address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <asp:Label ID="lblPhone" runat="server" CssClass="MainfontStyle" Text="Postal Code :"></asp:Label></td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtPostalCode" runat="server" CssClass="inputs" Width="270px" Text='<%# Bind("PostalCode") %>'
                                                                                        ReadOnly="True"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtPostalCode"
                                                                                        Display="Dynamic" ErrorMessage="Invalid Spelling" ValidationExpression="^([a-zA-Z0-9]{1})([_\\'\,\.\-\ a-zA-Z0-9])*">*</asp:RegularExpressionValidator></td>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top" align="right">
                                                                                    <asp:Label ID="lblPhone2" runat="server" CssClass="MainfontStyle" Text="Comment :"></asp:Label></td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtComment" runat="server" CssClass="inputs" Height="60px" Width="270px"
                                                                                        Text='<%# Bind("Comment") %>' ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td>
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
                                                    <asp:ObjectDataSource ID="odsPhysicianTitles" runat="server" TypeName="Pharma.BMD.BLL.LookupsBLL"
                                                        SelectMethod="GetSCodeByGCode" OldValuesParameterFormatString="original_{0}">
                                                        <SelectParameters>
                                                            <asp:Parameter DefaultValue="PhysicianTitles" Name="GeneralCode" Type="String" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                    <asp:ObjectDataSource ID="odsBrick" runat="server" 
                                                        OldValuesParameterFormatString="original_{0}" SelectMethod="SelectBricks" 
                                                        TypeName="Pharma.BMD.BLL.LookupsBLL"></asp:ObjectDataSource>
                                                    <asp:ObjectDataSource ID="odsPhysicianSpecialitities" runat="server" TypeName="Pharma.BMD.BLL.LookupsBLL"
                                                        SelectMethod="GetSCodeByGCode" OldValuesParameterFormatString="original_{0}">
                                                        <SelectParameters>
                                                            <asp:Parameter DefaultValue="PhysicianSpecialities" Name="GeneralCode" Type="String" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                </td>
                                                <td style="width: 50px" rowspan="13">
                                                </td>
                                                <td align="left" rowspan="13">
                                                    <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>--%>
                                                    <table width="100%">
                                                        <tbody>
                                                            <tr>
                                                                <td style="height: 254px" valign="top" colspan="3" rowspan="2">
                                                                    <table class="tblStyle" cellspacing="0" cellpadding="0" width="100%">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td colspan="3" rowspan="1">
                                                                                    <table id="tblScore" runat="server" width="100%">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td style="height: 21px" valign="top" align="left" colspan="8" rowspan="1">
                                                                                                    <asp:Label ID="lblScore" runat="server" CssClass="MainfontStyle" Text="Scoring System :"></asp:Label></td>
                                                                                                <td style="height: 21px" valign="top" align="left" colspan="2" rowspan="1">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center" colspan="10" rowspan="1">
                                                                                                    <asp:Panel ID="pnlPhysciansScores" runat="server" Height="150px" Width="100%" ScrollBars="Auto"
                                                                                                        HorizontalAlign="Left">
                                                                                                        <asp:GridView ID="gvScores" runat="server" Width="95%" BorderWidth="1px" BorderStyle="Solid"
                                                                                                            BorderColor="#999999" DataKeyNames="ScoreID,PhysicianID" OnRowDeleting="gvScores_RowDeleting"
                                                                                                            BackColor="White" ShowFooter="True" GridLines="None" OnRowUpdating="gvScores_RowUpdating"
                                                                                                            OnRowEditing="gvScores_RowEditing" OnRowCancelingEdit="gvScores_RowCancelingEdit"
                                                                                                            CellPadding="1" AutoGenerateColumns="False" OnRowCreated="gvScores_RowCreated"
                                                                                                            OnDataBound="gvScores_DataBound">
                                                                                                            <FooterStyle BackColor="#EFF3FB" Font-Bold="True" ForeColor="White"></FooterStyle>
                                                                                                            <HeaderStyle CssClass="GridHeaderBackStyle" Font-Bold="True" ForeColor="Black"></HeaderStyle>
                                                                                                            <AlternatingRowStyle CssClass="AltRowStyle"></AlternatingRowStyle>
                                                                                                            <Columns>
                                                                                                                <asp:TemplateField HeaderText="Date">
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:Label ID="lblEditScoreDate" runat="server" Text='<%# Bind("strScoreDate") %>'
                                                                                                                            Width="35px"></asp:Label>
                                                                                                                    </EditItemTemplate>
                                                                                                                    <ControlStyle Width="100px" />
                                                                                                                    <FooterTemplate>
                                                                                                                        <asp:TextBox ID="txtScoreDate" runat="server" CssClass="inputs" Enabled="False" Visible="true"
                                                                                                                            Width="75px"></asp:TextBox><%--'<%# CurrentUserInfo.IsAdminRank %>'--%>
                                                                                                                    </FooterTemplate>
                                                                                                                    <ItemStyle Width="100px" />
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblScoreDate" runat="server" Text='<%# Bind("strScoreDate") %>' Width="35px"></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="P [30]">
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:TextBox ID="txtPotential" runat="server" CssClass="inputs" Text='<%# Bind("Potential") %>'
                                                                                                                            Width="35px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvPotential" runat="server"
                                                                                                                                ControlToValidate="txtPotential" Display="Dynamic" ErrorMessage="*" ValidationGroup="vgEditScores"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                                                                                    ID="rvPotential" runat="server" ControlToValidate="txtPotential" Display="Dynamic"
                                                                                                                                    ErrorMessage="*" MaximumValue="30.00" MinimumValue="00.00" Type="Double" ValidationGroup="vgEditScores"></asp:RangeValidator>
                                                                                                                    </EditItemTemplate>
                                                                                                                    <FooterTemplate>
                                                                                                                        <asp:TextBox ID="txtNewPotential" runat="server" CssClass="inputs" Visible="true"
                                                                                                                            Width="35px"></asp:TextBox><%--'<%# CurrentUserInfo.IsAdminRank %>'--%>
                                                                                                                        <asp:RequiredFieldValidator ID="rfvNewPotential" runat="server" ControlToValidate="txtNewPotential"
                                                                                                                            Display="Dynamic" ErrorMessage="*" ValidationGroup="vgNewScores"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                                                                                ID="rvNewPotential" runat="server" ControlToValidate="txtNewPotential" Display="Dynamic"
                                                                                                                                ErrorMessage="*" MaximumValue="30.00" MinimumValue="00.00" Type="Double" ValidationGroup="vgNewScores"></asp:RangeValidator>
                                                                                                                    </FooterTemplate>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblPotential" runat="server" Text='<%# Bind("Potential") %>' Width="35px"></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="G [40]">
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:TextBox ID="txtGrade" runat="server" CssClass="inputs" Text='<%# Bind("Grade") %>'
                                                                                                                            Width="35px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvGrade" runat="server"
                                                                                                                                ControlToValidate="txtGrade" Display="Dynamic" ErrorMessage="*" ValidationGroup="vgEditScores"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                                                                                    ID="rvGrade" runat="server" ControlToValidate="txtGrade" Display="Dynamic" ErrorMessage="*"
                                                                                                                                    MaximumValue="40.00" MinimumValue="00.00" Type="Double" ValidationGroup="vgEditScores"></asp:RangeValidator>
                                                                                                                    </EditItemTemplate>
                                                                                                                    <FooterTemplate>
                                                                                                                        <asp:TextBox ID="txtNewGrade" runat="server" CssClass="inputs" Visible="true" Width="35px"></asp:TextBox><%--'<%# CurrentUserInfo.IsAdminRank %>'--%>
                                                                                                                        <asp:RequiredFieldValidator ID="rfvNewGrade" runat="server" ControlToValidate="txtNewGrade"
                                                                                                                            Display="Dynamic" ErrorMessage="*" ValidationGroup="vgNewScores"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                                                                                ID="rvNewGrade" runat="server" ControlToValidate="txtNewGrade" Display="Dynamic"
                                                                                                                                ErrorMessage="*" MaximumValue="40.00" MinimumValue="00.00" Type="Double" ValidationGroup="vgNewScores"></asp:RangeValidator>
                                                                                                                    </FooterTemplate>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblGrade" runat="server" Text='<%# Bind("Grade") %>' Width="35px"></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="I [10]">
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:TextBox ID="txtInference" runat="server" CssClass="inputs" Text='<%# Bind("Inference") %>'
                                                                                                                            Width="35px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvInference" runat="server"
                                                                                                                                ControlToValidate="txtInference" Display="Dynamic" ErrorMessage="*" ValidationGroup="vgEditScores"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                                                                                    ID="rvInference" runat="server" ControlToValidate="txtInference" Display="Dynamic"
                                                                                                                                    ErrorMessage="*" MaximumValue="10.00" MinimumValue="00.00" Type="Double" ValidationGroup="vgEditScores"></asp:RangeValidator>
                                                                                                                    </EditItemTemplate>
                                                                                                                    <FooterTemplate>
                                                                                                                        <asp:TextBox ID="txtNewInference" runat="server" CssClass="inputs" Visible="true"
                                                                                                                            Width="35px"><%--'<%# CurrentUserInfo.IsAdminRank %>'--%>
                                                                                                                        </asp:TextBox><asp:RequiredFieldValidator ID="rfvNewInference" runat="server" ControlToValidate="txtNewInference"
                                                                                                                            Display="Dynamic" ErrorMessage="*" ValidationGroup="vgNewScores"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                                                                                ID="rvNewInference" runat="server" ControlToValidate="txtNewInference" Display="Dynamic"
                                                                                                                                ErrorMessage="*" MaximumValue="10.00" MinimumValue="00.00" Type="Double" ValidationGroup="vgNewScores"></asp:RangeValidator>
                                                                                                                    </FooterTemplate>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblInference" runat="server" Text='<%# Bind("Inference") %>' Width="35px"></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Add [20]">
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:TextBox ID="txtAdditional" runat="server" CssClass="inputs" Text='<%# Bind("Additional") %>'
                                                                                                                            Width="35px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvAdditional" runat="server"
                                                                                                                                ControlToValidate="txtAdditional" Display="Dynamic" ErrorMessage="*" ValidationGroup="vgEditScores"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                                                                                    ID="rvAdditional" runat="server" ControlToValidate="txtAdditional" Display="Dynamic"
                                                                                                                                    ErrorMessage="*" MaximumValue="20.00" MinimumValue="00.00" Type="Double" ValidationGroup="vgEditScores"></asp:RangeValidator>
                                                                                                                    </EditItemTemplate>
                                                                                                                    <FooterTemplate>
                                                                                                                        <asp:TextBox ID="txtNewAdditional" runat="server" CssClass="inputs" Visible="true"
                                                                                                                            Width="35px">0</asp:TextBox><asp:RequiredFieldValidator ID="rfvNewAdditional" runat="server"
                                                                                                                                ControlToValidate="txtNewAdditional" Display="Dynamic" ErrorMessage="*" ValidationGroup="vgNewScores"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                                                                                    ID="rvNewAdditional" runat="server" ControlToValidate="txtNewAdditional" Display="Dynamic"
                                                                                                                                    ErrorMessage="*" MaximumValue="20.00" MinimumValue="00.00" Type="Double" ValidationGroup="vgNewScores"></asp:RangeValidator>
                                                                                                                    </FooterTemplate>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblAdditional" runat="server" Text='<%# Bind("Additional") %>' Width="35px"></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Total">
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:Label ID="lblEditTotal" runat="server" Text='<%# Bind("Total") %>' Width="35px"></asp:Label>
                                                                                                                    </EditItemTemplate>
                                                                                                                    <FooterTemplate>
                                                                                                                        -
                                                                                                                    </FooterTemplate>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblTotal" runat="server" Text='<%# Bind("Total") %>' Width="35px"></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField ShowHeader="False">
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" Text="Update"
                                                                                                                            ValidationGroup="vgEditScores"></asp:LinkButton>
                                                                                                                        <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                                                            Text="Cancel"></asp:LinkButton>
                                                                                                                    </EditItemTemplate>
                                                                                                                    <FooterTemplate>
                                                                                                                        <asp:Button ID="btnAddScores" runat="server" Text="Add" ValidationGroup="vgNewScores"
                                                                                                                            OnClick="btnAddScores_Click" CssClass="button" Visible="true" /><%--'<%# CurrentUserInfo.IsAdminRank %>'--%>
                                                                                                                    </FooterTemplate>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                                                                                                            Text="Edit" Visible="true"></asp:LinkButton><%--'<%# CurrentUserInfo.IsAdminRank %>'--%>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField ShowHeader="False">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:LinkButton ID="lnkbtnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                                                                                                            OnClientClick="return confirm('Are you sure you want to delete this Score?');"
                                                                                                                            Text="Delete" Visible="true"></asp:LinkButton><%--'<%# CurrentUserInfo.IsAdminRank %>'--%>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                            </Columns>
                                                                                                            <RowStyle CssClass="GridNormalRowsStyle" />
                                                                                                            <EmptyDataTemplate>
                                                                                                                <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="100%" BorderStyle="Solid"
                                                                                                                    BorderColor="#999999" DataKeyNames="ScoreID,PhysicianID" DefaultMode="Insert"
                                                                                                                    AutoGenerateRows="False" OnItemInserting="btnAddScores_Click">
                                                                                                                    <Fields>
                                                                                                                        <asp:TemplateField HeaderText="P:">
                                                                                                                            <InsertItemTemplate>
                                                                                                                                <asp:TextBox ID="txtboxInsertP" runat="server" Text='0' ValidationGroup="vgInsertP"></asp:TextBox>
                                                                                                                                <asp:RequiredFieldValidator ID="rfvPotential" runat="server" ControlToValidate="txtboxInsertP"
                                                                                                                                    Display="Dynamic" ErrorMessage="*" ValidationGroup="vgInsertP"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                                                                                        ID="rvPotential" runat="server" ControlToValidate="txtboxInsertP" Display="Dynamic"
                                                                                                                                        ErrorMessage="*" MaximumValue="30.00" MinimumValue="00.00" Type="Double" ValidationGroup="vgInsertP"></asp:RangeValidator>
                                                                                                                            </InsertItemTemplate>
                                                                                                                            <ControlStyle CssClass="inputs" />
                                                                                                                            <HeaderStyle CssClass="MainfontStyle" HorizontalAlign="Right" />
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("P") %>'></asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:TemplateField HeaderText="G:">
                                                                                                                            <EditItemTemplate>
                                                                                                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("G") %>'></asp:TextBox>
                                                                                                                            </EditItemTemplate>
                                                                                                                            <InsertItemTemplate>
                                                                                                                                <asp:TextBox ID="txtboxInsertG" runat="server" Text='0'></asp:TextBox>
                                                                                                                                <asp:RequiredFieldValidator ID="rfvGrade" runat="server" ControlToValidate="txtboxInsertG"
                                                                                                                                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                                                                                        ID="rvGrade" runat="server" ControlToValidate="txtboxInsertG" Display="Dynamic"
                                                                                                                                        ErrorMessage="*" MaximumValue="40.00" MinimumValue="00.00" Type="Double"></asp:RangeValidator>
                                                                                                                            </InsertItemTemplate>
                                                                                                                            <ControlStyle CssClass="inputs" />
                                                                                                                            <HeaderStyle CssClass="MainfontStyle" HorizontalAlign="Right" />
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("G") %>'></asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:TemplateField HeaderText="I:">
                                                                                                                            <EditItemTemplate>
                                                                                                                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("I") %>'></asp:TextBox>
                                                                                                                            </EditItemTemplate>
                                                                                                                            <InsertItemTemplate>
                                                                                                                                <asp:TextBox ID="txtboxInsertI" runat="server" Text='0'></asp:TextBox>
                                                                                                                                <asp:RequiredFieldValidator ID="rfvInference" runat="server" ControlToValidate="txtboxInsertI"
                                                                                                                                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                                                                                        ID="rvInference" runat="server" ControlToValidate="txtboxInsertI" Display="Dynamic"
                                                                                                                                        ErrorMessage="*" MaximumValue="10.00" MinimumValue="00.00" Type="Double"></asp:RangeValidator>
                                                                                                                            </InsertItemTemplate>
                                                                                                                            <ControlStyle CssClass="inputs" />
                                                                                                                            <HeaderStyle CssClass="MainfontStyle" HorizontalAlign="Right" />
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("I") %>'></asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:TemplateField HeaderText="Add:">
                                                                                                                            <EditItemTemplate>
                                                                                                                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Add") %>'></asp:TextBox>
                                                                                                                            </EditItemTemplate>
                                                                                                                            <InsertItemTemplate>
                                                                                                                                <asp:TextBox ID="txtboxInsertAdd" runat="server" Text="0"></asp:TextBox>
                                                                                                                                <asp:RequiredFieldValidator ID="rfvAdditional" runat="server" ControlToValidate="txtboxInsertAdd"
                                                                                                                                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                                                                                        ID="rvAdditional" runat="server" ControlToValidate="txtboxInsertAdd" Display="Dynamic"
                                                                                                                                        ErrorMessage="*" MaximumValue="20.00" MinimumValue="00.00" Type="Double"></asp:RangeValidator>
                                                                                                                            </InsertItemTemplate>
                                                                                                                            <ControlStyle CssClass="inputs" />
                                                                                                                            <HeaderStyle CssClass="MainfontStyle" HorizontalAlign="Right" />
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Add") %>'></asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:CommandField ShowInsertButton="True" CancelText="">
                                                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                                                        </asp:CommandField>
                                                                                                                    </Fields>
                                                                                                                </asp:DetailsView>
                                                                                                            </EmptyDataTemplate>
                                                                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                                                                        </asp:GridView>
                                                                                                    </asp:Panel>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center" colspan="10" rowspan="1">
                                                                                                    <asp:DropDownList ID="ddlChartType" runat="server" CssClass="inputs" Width="100%"
                                                                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlChartType_SelectedIndexChanged">
                                                                                                        <asp:ListItem>Line2D</asp:ListItem>
                                                                                                        <asp:ListItem>Area2D</asp:ListItem>
                                                                                                        <asp:ListItem>Bar2D</asp:ListItem>
                                                                                                    </asp:DropDownList>
                                                                                                    <div id="divScoresChart" runat="server">
                                                                                                        &nbsp;</div>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" colspan="3" rowspan="3">
                                                                                    <table width="100%">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td valign="top" align="left" colspan="8" rowspan="1">
                                                                                                    <asp:Label ID="lblRxAccounts" runat="server" CssClass="MainfontStyle" Text="Medical Accounts :"></asp:Label>
                                                                                                    <asp:TextBox ID="txtAISearchMA" runat="server" CssClass="inputs" Width="100%" Visible="False">Search</asp:TextBox></td>
                                                                                                <td valign="top" align="left" colspan="2" rowspan="1">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center" colspan="10" rowspan="1">
                                                                                                    <asp:Panel ID="pnlMedicalAccounts" runat="server" Height="150px" Width="100%" ScrollBars="Auto"
                                                                                                        HorizontalAlign="Left">
                                                                                                        <asp:GridView ID="gvMedicalAccounts" runat="server" Width="95%" BorderWidth="1px"
                                                                                                            BorderStyle="Solid" BorderColor="#999999" DataKeyNames="MedicalAccountID" BackColor="White"
                                                                                                            CellPadding="1" AutoGenerateColumns="False" OnRowDataBound="gvMedicalAccounts_RowDataBound"
                                                                                                            AllowSorting="True">
                                                                                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                                                            <Columns>
                                                                                                                <asp:TemplateField HeaderText="Medical Account">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Prescribing Capable">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:CheckBox ID="CheckBox1" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem,"PrescribingCapable")) %>' BackColor='<%# System.Drawing.ColorTranslator.FromHtml(Eval("PrescribingCapableColor").ToString()) %>' />
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Internal">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:CheckBox ID="CheckBox2" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem,"Internal")) %>' BackColor='<%# System.Drawing.ColorTranslator.FromHtml(Eval("InternalColor").ToString()) %>' />
                                                                                                                        <%--<asp:Label ID="InternalChanges" Text="*" runat="server" BackColor="LightYellow" />--%>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Consultant">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:CheckBox ID="CheckBox3" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem,"Consultant")) %>' BackColor='<%# System.Drawing.ColorTranslator.FromHtml(Eval("ConsultantColor").ToString()) %>' />
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                            </Columns>
                                                                                                            <RowStyle CssClass="GridNormalRowsStyle" />
                                                                                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                                                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                                                                            <HeaderStyle Font-Bold="True" ForeColor="Black" CssClass="GridHeaderBackStyle" />
                                                                                                            <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                            <EmptyDataTemplate>
                                                                                                                <asp:Label ID="lblNoMedicalAccounts" runat="server" CssClass="StyleNoData" Font-Bold="True"
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
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <%--                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
--%>
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
                                                <td valign="top" align="center" colspan="1" rowspan="1">
                                                    &nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="StyleValidationSummary">
                                                    </asp:ValidationSummary>
                                                </td>
                                                <td rowspan="1">
                                                </td>
                                                <td rowspan="1">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" rowspan="1">
                                                    <asp:Label ID="lblErrors" runat="server" CssClass="StyleValidationSummary" ForeColor="Red"></asp:Label></td>
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
                                <td align="center" colspan="3" rowspan="1">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </ItemTemplate>
                <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="PagerfontStyle">
                </PagerStyle>
                <EmptyDataTemplate>
                    <table width="100%">
                        <tbody>
                            <tr>
                                <td align="center" colspan="3" rowspan="3">
                                    <table style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td valign="top" align="center" colspan="3" rowspan="1">
                                                    <table style="width: 100%; height: 30px" id="Table1" class="tblStyle">
                                                        <tbody>
                                                            <tr align="center" width="50%">
                                                                <td style="width: 40%" align="right">
                                                                    <asp:Label ID="lblSearch" runat="server" CssClass="MainfontStyle" Text="Search Physicians:"></asp:Label></td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtSearchName" runat="server" AutoPostBack="True" CssClass="inputs"
                                                                        OnTextChanged="txtSearchName_TextChanged" Width="300px"></asp:TextBox>
                                                                </td>
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
                                                <td align="left" rowspan="1">
                                                </td>
                                                <td style="width: 50px" rowspan="1">
                                                </td>
                                                <td rowspan="1">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" align="left" rowspan="13">
                                                    <table cellspacing="0" cellpadding="0" width="450">
                                                        <tbody>
                                                            <tr>
                                                                <td colspan="3" rowspan="3">
                                                                    <table width="100%">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <asp:Label ID="lblName" runat="server" CssClass="MainfontStyle" Text="Physician Name :"></asp:Label></td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtPhysicianName" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                        Text='<%# Bind("PhysicianName") %>' Width="270px"></asp:TextBox></td>
                                                                                <td align="left">
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPhysicianName"
                                                                                        Display="Dynamic" ErrorMessage="Physician name is required">*</asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPhysicianName"
                                                                                        Display="Dynamic" ErrorMessage="Invalid Spelling" ValidationExpression="^([a-zA-Z]{1})([_\\'\,\.\-\ a-zA-Z0-9])*">*</asp:RegularExpressionValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <asp:Label ID="lblPharmacistName" runat="server" CssClass="MainfontStyle" Text="AKA :"></asp:Label></td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtAKA" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("AKA") %>'
                                                                                        Width="270px"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtAKA"
                                                                                        Display="Dynamic" ErrorMessage="Invalid Spelling" ValidationExpression="^([a-zA-Z]{1})([_\\'\,\.\-\ a-zA-Z0-9])*">*</asp:RegularExpressionValidator></td>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <asp:Label ID="lblGov" runat="server" CssClass="MainfontStyle" Text="Title :"></asp:Label></td>
                                                                                <td align="left">
                                                                                    <asp:DropDownList ID="ddlTitle" runat="server" CssClass="inputs" Width="275px"
                                                                                        DataValueField="SID" DataTextField="SubCode" DataSourceID="odsPhysicianTitles"
                                                                                        Enabled="False">
                                                                                    </asp:DropDownList><asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("TitleID") %>'
                                                                                        Visible="False" Width="15px"></asp:TextBox></td>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <asp:Label ID="lblCity" runat="server" CssClass="MainfontStyle" Text="Speciality :"></asp:Label></td>
                                                                                <td align="left">
                                                                                    <asp:DropDownList ID="ddlSpeciality" runat="server" CssClass="inputs" Width="275px"
                                                                                        DataValueField="SID" DataTextField="SubCode"
                                                                                        DataSourceID="odsPhysicianSpecialitities" Enabled="False">
                                                                                    </asp:DropDownList><asp:TextBox ID="txtSpeciality" runat="server" Text='<%# Bind("SpecialityID") %>'
                                                                                        Visible="False" Width="15px"></asp:TextBox></td>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <asp:Label ID="lblArea" runat="server" CssClass="MainfontStyle" Text="Owns a Private Clinic :"></asp:Label></td>
                                                                                <td align="left">
                                                                                    <asp:CheckBox ID="chkOwnPrivateClinic" runat="server" Checked='<%# Bind("PrivateClinic") %>'
                                                                                        Enabled="False" /></td>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <asp:Label ID="lblAddress" runat="server" CssClass="MainfontStyle" Text="Mobile : "></asp:Label></td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtMobile" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("Mobile") %>'
                                                                                        Width="270px"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtMobile"
                                                                                        Display="Dynamic" ErrorMessage="Invalid Spelling" ValidationExpression="^([a-zA-Z0-9]{1})([_\\'\,\.\-\ a-zA-Z0-9])*">*</asp:RegularExpressionValidator></td>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <asp:Label ID="lblBrick" runat="server" CssClass="MainfontStyle" Text="E-mail :"></asp:Label></td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="inputs" ReadOnly="True" Text='<%# Bind("Email") %>'
                                                                                        Width="270px"></asp:TextBox></td>
                                                                                <td align="left">
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                                                                        Display="Dynamic" ErrorMessage="Invalid e-mail address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    <asp:Label ID="lblPhone" runat="server" CssClass="MainfontStyle" Text="Postal Code :"></asp:Label></td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtPostalCode" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                        Text='<%# Bind("PostalCode") %>' Width="270px"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtPostalCode"
                                                                                        Display="Dynamic" ErrorMessage="Invalid Spelling" ValidationExpression="^([a-zA-Z0-9]{1})([_\\'\,\.\-\ a-zA-Z0-9])*">*</asp:RegularExpressionValidator></td>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top" align="right">
                                                                                    <asp:Label ID="lblPhone2" runat="server" CssClass="MainfontStyle" Text="Comment :"></asp:Label></td>
                                                                                <td align="left">
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
                                                    <asp:ObjectDataSource ID="odsPhysicianTitles" runat="server" TypeName="Pharma.BMD.BLL.LookupsBLL"
                                                        SelectMethod="GetSCodeByGCode" OldValuesParameterFormatString="original_{0}">
                                                        <SelectParameters>
                                                            <asp:Parameter DefaultValue="PhysicianTitles" Name="GeneralCode" Type="String" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                    <asp:ObjectDataSource ID="odsPhysicianSpecialitities" runat="server" TypeName="Pharma.BMD.BLL.LookupsBLL"
                                                        SelectMethod="GetSCodeByGCode" OldValuesParameterFormatString="original_{0}">
                                                        <SelectParameters>
                                                            <asp:Parameter DefaultValue="PhysicianSpecialities" Name="GeneralCode" Type="String" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                </td>
                                                <td style="width: 50px" rowspan="13">
                                                </td>
                                                <td align="left" rowspan="13">
                                                    <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>--%>
                                                    <table>
                                                        <tbody>
                                                            <tr>
                                                                <td style="height: 254px" valign="top" colspan="3" rowspan="2">
                                                                    <table class="tblStyle" cellspacing="0" cellpadding="0" width="100%">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td colspan="3" rowspan="1">
                                                                                    <table id="tblScore" runat="server" width="100%">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td style="height: 21px" valign="top" align="left" colspan="8" rowspan="1">
                                                                                                    <asp:Label ID="lblScore" runat="server" CssClass="MainfontStyle" Text="Scoring System :"></asp:Label></td>
                                                                                                <td style="height: 21px" valign="top" align="left" colspan="2" rowspan="1">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center" colspan="10" rowspan="1">
                                                                                                    <asp:Panel ID="pnlPhysciansScores" runat="server" Height="150px" Width="100%" ScrollBars="Auto"
                                                                                                        HorizontalAlign="Left">
                                                                                                        <asp:GridView ID="gvScores" runat="server" Width="95%" BorderWidth="1px" BorderStyle="Solid"
                                                                                                            BorderColor="#999999" DataKeyNames="ScoreID,PhysicianID" OnRowDeleting="gvScores_RowDeleting"
                                                                                                            BackColor="White" ShowFooter="True" GridLines="None" OnRowUpdating="gvScores_RowUpdating"
                                                                                                            OnRowEditing="gvScores_RowEditing" OnRowCancelingEdit="gvScores_RowCancelingEdit"
                                                                                                            CellPadding="1" AutoGenerateColumns="False" OnRowCreated="gvScores_RowCreated"
                                                                                                            OnDataBound="gvScores_DataBound">
                                                                                                            <FooterStyle BackColor="#EFF3FB" Font-Bold="True" ForeColor="White" />
                                                                                                            <Columns>
                                                                                                                <asp:TemplateField HeaderText="Date">
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:Label ID="lblEditScoreDate" runat="server" Text='<%# Bind("strScoreDate") %>'
                                                                                                                            Width="35px"></asp:Label>
                                                                                                                    </EditItemTemplate>
                                                                                                                    <ControlStyle Width="100px" />
                                                                                                                    <FooterTemplate>
                                                                                                                        <asp:TextBox ID="txtScoreDate" runat="server" CssClass="inputs" Enabled="False" Visible="true"
                                                                                                                            Width="75px"></asp:TextBox><%--'<%# CurrentUserInfo.IsAdminRank %>'--%>
                                                                                                                    </FooterTemplate>
                                                                                                                    <ItemStyle Width="100px" />
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblScoreDate" runat="server" Text='<%# Bind("strScoreDate") %>' Width="35px"></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="P [30]">
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:TextBox ID="txtPotential" runat="server" CssClass="inputs" Text='<%# Bind("Potential") %>'
                                                                                                                            Width="35px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvPotential" runat="server"
                                                                                                                                ControlToValidate="txtPotential" Display="Dynamic" ErrorMessage="*" ValidationGroup="vgEditScores"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                                                                                    ID="rvPotential" runat="server" ControlToValidate="txtPotential" Display="Dynamic"
                                                                                                                                    ErrorMessage="*" MaximumValue="30.00" MinimumValue="00.00" Type="Double" ValidationGroup="vgEditScores"></asp:RangeValidator>
                                                                                                                    </EditItemTemplate>
                                                                                                                    <FooterTemplate>
                                                                                                                        <asp:TextBox ID="txtNewPotential" runat="server" CssClass="inputs" Visible="true"
                                                                                                                            Width="35px"></asp:TextBox><%--'<%# CurrentUserInfo.IsAdminRank %>'--%>
                                                                                                                        <asp:RequiredFieldValidator ID="rfvNewPotential" runat="server" ControlToValidate="txtNewPotential"
                                                                                                                            Display="Dynamic" ErrorMessage="*" ValidationGroup="vgNewScores"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                                                                                ID="rvNewPotential" runat="server" ControlToValidate="txtNewPotential" Display="Dynamic"
                                                                                                                                ErrorMessage="*" MaximumValue="30.00" MinimumValue="00.00" Type="Double" ValidationGroup="vgNewScores"></asp:RangeValidator>
                                                                                                                    </FooterTemplate>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblPotential" runat="server" Text='<%# Bind("Potential") %>' Width="35px"></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="G [40]">
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:TextBox ID="txtGrade" runat="server" CssClass="inputs" Text='<%# Bind("Grade") %>'
                                                                                                                            Width="35px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvGrade" runat="server"
                                                                                                                                ControlToValidate="txtGrade" Display="Dynamic" ErrorMessage="*" ValidationGroup="vgEditScores"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                                                                                    ID="rvGrade" runat="server" ControlToValidate="txtGrade" Display="Dynamic" ErrorMessage="*"
                                                                                                                                    MaximumValue="40.00" MinimumValue="00.00" Type="Double" ValidationGroup="vgEditScores"></asp:RangeValidator>
                                                                                                                    </EditItemTemplate>
                                                                                                                    <FooterTemplate>
                                                                                                                        <asp:TextBox ID="txtNewGrade" runat="server" CssClass="inputs" Visible="true" Width="35px"></asp:TextBox><%--'<%# CurrentUserInfo.IsAdminRank %>'--%>
                                                                                                                        <asp:RequiredFieldValidator ID="rfvNewGrade" runat="server" ControlToValidate="txtNewGrade"
                                                                                                                            Display="Dynamic" ErrorMessage="*" ValidationGroup="vgNewScores"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                                                                                ID="rvNewGrade" runat="server" ControlToValidate="txtNewGrade" Display="Dynamic"
                                                                                                                                ErrorMessage="*" MaximumValue="40.00" MinimumValue="00.00" Type="Double" ValidationGroup="vgNewScores"></asp:RangeValidator>
                                                                                                                    </FooterTemplate>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblGrade" runat="server" Text='<%# Bind("Grade") %>' Width="35px"></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="I [10]">
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:TextBox ID="txtInference" runat="server" CssClass="inputs" Text='<%# Bind("Inference") %>'
                                                                                                                            Width="35px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvInference" runat="server"
                                                                                                                                ControlToValidate="txtInference" Display="Dynamic" ErrorMessage="*" ValidationGroup="vgEditScores"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                                                                                    ID="rvInference" runat="server" ControlToValidate="txtInference" Display="Dynamic"
                                                                                                                                    ErrorMessage="*" MaximumValue="10.00" MinimumValue="00.00" Type="Double" ValidationGroup="vgEditScores"></asp:RangeValidator>
                                                                                                                    </EditItemTemplate>
                                                                                                                    <FooterTemplate>
                                                                                                                        <asp:TextBox ID="txtNewInference" runat="server" CssClass="inputs" Visible="true"
                                                                                                                            Width="35px"><%--'<%# CurrentUserInfo.IsAdminRank %>'--%>
                                                                                                                        </asp:TextBox><asp:RequiredFieldValidator ID="rfvNewInference" runat="server" ControlToValidate="txtNewInference"
                                                                                                                            Display="Dynamic" ErrorMessage="*" ValidationGroup="vgNewScores"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                                                                                ID="rvNewInference" runat="server" ControlToValidate="txtNewInference" Display="Dynamic"
                                                                                                                                ErrorMessage="*" MaximumValue="10.00" MinimumValue="00.00" Type="Double" ValidationGroup="vgNewScores"></asp:RangeValidator>
                                                                                                                    </FooterTemplate>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblInference" runat="server" Text='<%# Bind("Inference") %>' Width="35px"></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Add [20]">
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:TextBox ID="txtAdditional" runat="server" CssClass="inputs" Text='<%# Bind("Additional") %>'
                                                                                                                            Width="35px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvAdditional" runat="server"
                                                                                                                                ControlToValidate="txtAdditional" Display="Dynamic" ErrorMessage="*" ValidationGroup="vgEditScores"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                                                                                    ID="rvAdditional" runat="server" ControlToValidate="txtAdditional" Display="Dynamic"
                                                                                                                                    ErrorMessage="*" MaximumValue="20.00" MinimumValue="00.00" Type="Double" ValidationGroup="vgEditScores"></asp:RangeValidator>
                                                                                                                    </EditItemTemplate>
                                                                                                                    <FooterTemplate>
                                                                                                                        <asp:TextBox ID="txtNewAdditional" runat="server" CssClass="inputs" Visible="true"
                                                                                                                            Width="35px">0</asp:TextBox><asp:RequiredFieldValidator ID="rfvNewAdditional" runat="server"
                                                                                                                                ControlToValidate="txtNewAdditional" Display="Dynamic" ErrorMessage="*" ValidationGroup="vgNewScores"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                                                                                    ID="rvNewAdditional" runat="server" ControlToValidate="txtNewAdditional" Display="Dynamic"
                                                                                                                                    ErrorMessage="*" MaximumValue="20.00" MinimumValue="00.00" Type="Double" ValidationGroup="vgNewScores"></asp:RangeValidator>
                                                                                                                    </FooterTemplate>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblAdditional" runat="server" Text='<%# Bind("Additional") %>' Width="35px"></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Total">
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:Label ID="lblEditTotal" runat="server" Text='<%# Bind("Total") %>' Width="35px"></asp:Label>
                                                                                                                    </EditItemTemplate>
                                                                                                                    <FooterTemplate>
                                                                                                                        -
                                                                                                                    </FooterTemplate>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblTotal" runat="server" Text='<%# Bind("Total") %>' Width="35px"></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField ShowHeader="False">
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" Text="Update"
                                                                                                                            ValidationGroup="vgEditScores"></asp:LinkButton>
                                                                                                                        <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                                                            Text="Cancel"></asp:LinkButton>
                                                                                                                    </EditItemTemplate>
                                                                                                                    <FooterTemplate>
                                                                                                                        <asp:Button ID="btnAddScores" runat="server" Text="Add" ValidationGroup="vgNewScores"
                                                                                                                            OnClick="btnAddScores_Click" CssClass="button" Visible="true" /><%--'<%# CurrentUserInfo.IsAdminRank %>'--%>
                                                                                                                    </FooterTemplate>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                                                                                                            Text="Edit" Visible="true"></asp:LinkButton><%--'<%# CurrentUserInfo.IsAdminRank %>'--%>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField ShowHeader="False">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:LinkButton ID="lnkbtnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                                                                                                            OnClientClick="return confirm('Are you sure you want to delete this Score?');"
                                                                                                                            Text="Delete" Visible="true"></asp:LinkButton><%--'<%# CurrentUserInfo.IsAdminRank %>'--%>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                            </Columns>
                                                                                                            <RowStyle CssClass="GridNormalRowsStyle" />
                                                                                                            <EmptyDataTemplate>
                                                                                                                <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="100%" BorderStyle="Solid"
                                                                                                                    BorderColor="#999999" DataKeyNames="ScoreID,PhysicianID" DefaultMode="Insert"
                                                                                                                    AutoGenerateRows="False" OnItemInserting="btnAddScores_Click">
                                                                                                                    <Fields>
                                                                                                                        <asp:TemplateField HeaderText="P:">
                                                                                                                            <InsertItemTemplate>
                                                                                                                                <asp:TextBox ID="txtboxInsertP" runat="server" Text='0' ValidationGroup="vgInsertP"></asp:TextBox>
                                                                                                                                <asp:RequiredFieldValidator ID="rfvPotential" runat="server" ControlToValidate="txtboxInsertP"
                                                                                                                                    Display="Dynamic" ErrorMessage="*" ValidationGroup="vgInsertP"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                                                                                        ID="rvPotential" runat="server" ControlToValidate="txtboxInsertP" Display="Dynamic"
                                                                                                                                        ErrorMessage="*" MaximumValue="30.00" MinimumValue="00.00" Type="Double" ValidationGroup="vgInsertP"></asp:RangeValidator>
                                                                                                                            </InsertItemTemplate>
                                                                                                                            <ControlStyle CssClass="inputs" />
                                                                                                                            <HeaderStyle CssClass="MainfontStyle" HorizontalAlign="Right" />
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("P") %>'></asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:TemplateField HeaderText="G:">
                                                                                                                            <EditItemTemplate>
                                                                                                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("G") %>'></asp:TextBox>
                                                                                                                            </EditItemTemplate>
                                                                                                                            <InsertItemTemplate>
                                                                                                                                <asp:TextBox ID="txtboxInsertG" runat="server" Text='0'></asp:TextBox>
                                                                                                                                <asp:RequiredFieldValidator ID="rfvGrade" runat="server" ControlToValidate="txtboxInsertG"
                                                                                                                                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                                                                                        ID="rvGrade" runat="server" ControlToValidate="txtboxInsertG" Display="Dynamic"
                                                                                                                                        ErrorMessage="*" MaximumValue="40.00" MinimumValue="00.00" Type="Double"></asp:RangeValidator>
                                                                                                                            </InsertItemTemplate>
                                                                                                                            <ControlStyle CssClass="inputs" />
                                                                                                                            <HeaderStyle CssClass="MainfontStyle" HorizontalAlign="Right" />
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("G") %>'></asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:TemplateField HeaderText="I:">
                                                                                                                            <EditItemTemplate>
                                                                                                                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("I") %>'></asp:TextBox>
                                                                                                                            </EditItemTemplate>
                                                                                                                            <InsertItemTemplate>
                                                                                                                                <asp:TextBox ID="txtboxInsertI" runat="server" Text='0'></asp:TextBox>
                                                                                                                                <asp:RequiredFieldValidator ID="rfvInference" runat="server" ControlToValidate="txtboxInsertI"
                                                                                                                                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                                                                                        ID="rvInference" runat="server" ControlToValidate="txtboxInsertI" Display="Dynamic"
                                                                                                                                        ErrorMessage="*" MaximumValue="10.00" MinimumValue="00.00" Type="Double"></asp:RangeValidator>
                                                                                                                            </InsertItemTemplate>
                                                                                                                            <ControlStyle CssClass="inputs" />
                                                                                                                            <HeaderStyle CssClass="MainfontStyle" HorizontalAlign="Right" />
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("I") %>'></asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:TemplateField HeaderText="Add:">
                                                                                                                            <EditItemTemplate>
                                                                                                                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Add") %>'></asp:TextBox>
                                                                                                                            </EditItemTemplate>
                                                                                                                            <InsertItemTemplate>
                                                                                                                                <asp:TextBox ID="txtboxInsertAdd" runat="server" Text="0"></asp:TextBox>
                                                                                                                                <asp:RequiredFieldValidator ID="rfvAdditional" runat="server" ControlToValidate="txtboxInsertAdd"
                                                                                                                                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RangeValidator
                                                                                                                                        ID="rvAdditional" runat="server" ControlToValidate="txtboxInsertAdd" Display="Dynamic"
                                                                                                                                        ErrorMessage="*" MaximumValue="20.00" MinimumValue="00.00" Type="Double"></asp:RangeValidator>
                                                                                                                            </InsertItemTemplate>
                                                                                                                            <ControlStyle CssClass="inputs" />
                                                                                                                            <HeaderStyle CssClass="MainfontStyle" HorizontalAlign="Right" />
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Add") %>'></asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:CommandField ShowInsertButton="True" CancelText="">
                                                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                                                        </asp:CommandField>
                                                                                                                    </Fields>
                                                                                                                </asp:DetailsView>
                                                                                                            </EmptyDataTemplate>
                                                                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                                                                            <HeaderStyle CssClass="GridHeaderBackStyle" Font-Bold="True" ForeColor="Black" />
                                                                                                            <AlternatingRowStyle CssClass="AltRowStyle" />
                                                                                                        </asp:GridView>
                                                                                                    </asp:Panel>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center" colspan="10" rowspan="1">
                                                                                                    <asp:DropDownList ID="ddlChartType" runat="server" CssClass="inputs" Width="100%"
                                                                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlChartType_SelectedIndexChanged"
                                                                                                        Visible="False">
                                                                                                        <asp:ListItem>Line2D</asp:ListItem>
                                                                                                        <asp:ListItem>Area2D</asp:ListItem>
                                                                                                        <asp:ListItem>Bar2D</asp:ListItem>
                                                                                                    </asp:DropDownList>
                                                                                                    <div id="divScoresChart" runat="server">
                                                                                                        &nbsp;</div>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" colspan="3" rowspan="3">
                                                                                    <table width="100%">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td valign="top" align="left" colspan="8" rowspan="1">
                                                                                                    <asp:Label ID="lblRxAccounts" runat="server" CssClass="MainfontStyle" Text="Medical Accounts :"></asp:Label></td>
                                                                                                <td valign="top" align="left" colspan="2" rowspan="1">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center" colspan="10" rowspan="1">
                                                                                                    <asp:Panel ID="pnlMedicalAccounts" runat="server" Height="150px" Width="100%" ScrollBars="Auto"
                                                                                                        HorizontalAlign="Left">
                                                                                                        <asp:GridView ID="gvMedicalAccounts" runat="server" Width="95%" BorderWidth="1px"
                                                                                                            BorderStyle="Solid" BorderColor="#999999" DataKeyNames="MedicalAccountID" BackColor="White"
                                                                                                            CellPadding="1" AutoGenerateColumns="False" OnRowDataBound="gvMedicalAccounts_RowDataBound"
                                                                                                            AllowSorting="True">
                                                                                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                                                            <Columns>
                                                                                                                <asp:TemplateField HeaderText="Medical Account">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Prescribing Capable">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:CheckBox ID="CheckBox1" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem,"PrescribingCapable")) %>' />
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Internal">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:CheckBox ID="CheckBox2" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem,"Internal")) %>' />
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Consultant">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:CheckBox ID="CheckBox3" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem,"Consultant")) %>' />
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                            </Columns>
                                                                                                            <RowStyle CssClass="GridNormalRowsStyle" />
                                                                                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                                                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                                                                            <HeaderStyle Font-Bold="True" ForeColor="Black" CssClass="GridHeaderBackStyle" />
                                                                                                            <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                            <EmptyDataTemplate>
                                                                                                                <asp:Label ID="lblEmptyNoMedicalAccounts" runat="server" CssClass="StyleNoData" Font-Bold="True"
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
                                                <td valign="top" align="center" colspan="1" rowspan="1">
                                                    &nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="StyleValidationSummary" />
                                                </td>
                                                <td rowspan="1">
                                                </td>
                                                <td rowspan="1">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" rowspan="1">
                                                    <asp:Label ID="lblErrors" runat="server" CssClass="StyleValidationSummary" ForeColor="Red"></asp:Label></td>
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
                                <td align="center" colspan="3" rowspan="1">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </EmptyDataTemplate>
                <EmptyDataRowStyle VerticalAlign="Top" />
            </asp:FormView>
            <asp:Label ID="lblNoDataMsg" runat="server" CssClass="MainfontStyle"></asp:Label><br />
            <asp:Label ID="lblmsg" runat="server" Visible="False" Text='Your request for adding new Physician is in "Pending" phase until Acceptance from your Manager'
                ForeColor="#004000" Font-Size="12px" Font-Names="Arial" Font-Bold="True"></asp:Label>
            <asp:ObjectDataSource ID="odsPhysicians" runat="server" EnablePaging="True" OldValuesParameterFormatString="original_{0}"
                SelectCountMethod="MaxRowCount" SelectMethod="SelectPhysicians" TypeName="Pharma.BMD.BLL.PhysiciansBLL">
                <SelectParameters>
                    <asp:Parameter DefaultValue="" Name="startRowIndex" Type="Int32" />
                    <asp:Parameter DefaultValue="1" Name="maximumRows" Type="Int32" />
                    <asp:SessionParameter DefaultValue="" Name="ShowAll" SessionField="ShowAll" />
                </SelectParameters>
            </asp:ObjectDataSource>
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


      function BeginRequestHandler(sender, args) 
        {
          var elem = document.getElementById('ctl00_ContentPlaceHolder1_frmViewPhysicians_pnlPhysciansScores');
              if(elem!= null)
              scrollTop=elem.scrollTop;
        }

      function EndRequestHandler(sender, args)
       {
       var elem = document.getElementById('ctl00_ContentPlaceHolder1_frmViewPhysicians_pnlPhysciansScores');
            if(elem!= null)
           elem.scrollTop = scrollTop;
  
      }  
      
      ///
      function BeginRequestHandler1(sender, args) 
        {
          var elem = document.getElementById('ctl00_ContentPlaceHolder1_frmViewPhysicians_pnlMedicalAccounts');
              if(elem!= null)
              scrollTop1=elem.scrollTop;
        }

      function EndRequestHandler1(sender, args)
       {
          var elem = document.getElementById('ctl00_ContentPlaceHolder1_frmViewPhysicians_pnlMedicalAccounts');
            if(elem!= null)
            elem.scrollTop = scrollTop1;
  
      }  
    
    </script>

</asp:Content>
