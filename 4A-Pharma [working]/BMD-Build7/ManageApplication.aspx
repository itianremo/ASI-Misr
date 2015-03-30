<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="ManageApplication, App_Web_manageapplication.aspx.cdcab7d2" title=":: 4A-Pharma BMD :: Manage Application ::" maintainScrollPositionOnPostBack="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="Controls/TransButtons.ascx" TagName="TransButtons" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%">
                <tbody>
                    <tr>
                        <td>
                            <cc1:Accordion ID="MyAccordion" runat="server" SelectedIndex="-1" HeaderCssClass="accordionHeader"
                                HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent"
                                FadeTransitions="true" FramesPerSecond="40" TransitionDuration="250" AutoSize="None"
                                RequireOpenedPane="false" SuppressHeaderPostbacks="true">
                                <Panes>
                                    <cc1:AccordionPane ID="AccordionPaneProducts" runat="server">
                                        <Header>
                                            <u>Products</u></Header>
                                        <Content>
                                            <asp:Panel ID="pnlProductsForms" runat="server" ScrollBars="auto" Height="400px"
                                                Width="100%">
                                                <table cellspacing="0" cellpadding="5" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td width="27%">
                                                            </td>
                                                            <td class="MainfontStyle" align="left">
                                                                Products Forms :</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td align="left">
                                                                <%--                                        <asp:Literal ID="lblProductsForms" runat="server" CssClass="MainfontStyle" Text=""></asp:Literal>
--%>
                                                                <asp:GridView ID="gvForms" runat="server" Width="400px" AllowSorting="True" AllowPaging="True"
                                                                    DataSourceID="odsProductForms" BackColor="White" BorderWidth="1px" BorderStyle="Solid"
                                                                    BorderColor="#999999" ShowFooter="True" DataKeyNames="SID" CellPadding="1" AutoGenerateColumns="False">
                                                                    <FooterStyle BackColor="#EFF3FB" Font-Bold="True" ForeColor="White"></FooterStyle>
                                                                    <RowStyle CssClass="GridNormalRowsStyle"></RowStyle>
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="From" SortExpression="SubCode">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="TextBox1" runat="server" CssClass="inputs" Text='<%# Bind("SubCode") %>'></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*"
                                                                                    ControlToValidate="TextBox1" ErrorMessage="Form name can't be null"></asp:RequiredFieldValidator>
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:TextBox ID="txtForm" runat="server" CssClass="inputs"></asp:TextBox>
                                                                            </FooterTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("SubCode") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle BorderWidth="1px" BorderStyle="Solid"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ShowHeader="False">
                                                                            <EditItemTemplate>
                                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                                                                    Text="Update"></asp:LinkButton>
                                                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                    Text="Cancel"></asp:LinkButton>
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Button ID="btnAddForm" runat="server" Text="Add" CssClass="button" OnClick="btnAddForm_Click" />
                                                                            </FooterTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                                    Text="Edit"></asp:LinkButton>&nbsp;
                                                                                <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                                                                                    Text="Delete" OnClientClick="return confirm('Are you sure you want to delete selected product from?')"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <FooterStyle HorizontalAlign="Center"></FooterStyle>
                                                                            <HeaderStyle BorderWidth="1px" BorderStyle="Solid"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPagerStyle"></PagerStyle>
                                                                    <EmptyDataTemplate>
                                                                        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="SID"
                                                                            DataSourceID="odsProductForms" Height="50px" Width="125px" DefaultMode="Insert"
                                                                            BorderColor="#999999" BorderStyle="Solid" OnItemInserted="DetailsView1_ItemInserted">
                                                                            <Fields>
                                                                                <asp:BoundField DataField="SubCode" HeaderText="SubCode" SortExpression="SubCode" />
                                                                                <asp:CommandField ShowInsertButton="True" CancelText="" />
                                                                            </Fields>
                                                                        </asp:DetailsView>
                                                                    </EmptyDataTemplate>
                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                                                                    <HeaderStyle CssClass="GridHeaderBackStyle" Font-Bold="True" ForeColor="Black"></HeaderStyle>
                                                                    <AlternatingRowStyle CssClass="AltRowStyle"></AlternatingRowStyle>
                                                                </asp:GridView>
                                                                <asp:ObjectDataSource ID="odsProductForms" runat="server" OnInserting="odsProductForms_Inserting"
                                                                    OnUpdated="odsProductForms_Updated" UpdateMethod="UpdateSCode" TypeName="Pharma.BLL.LookupsBLL"
                                                                    SelectMethod="GetSCodeByGCode" InsertMethod="AddSCodeToGCode" DeleteMethod="DeleteSCode">
                                                                    <DeleteParameters>
                                                                        <asp:Parameter Name="SID" Type="Int32"></asp:Parameter>
                                                                    </DeleteParameters>
                                                                    <UpdateParameters>
                                                                        <asp:Parameter Name="SID" Type="Int32"></asp:Parameter>
                                                                        <asp:Parameter Name="SubCode" Type="String"></asp:Parameter>
                                                                    </UpdateParameters>
                                                                    <SelectParameters>
                                                                        <asp:Parameter DefaultValue="ProductsForms" Name="GeneralCode" Type="String" />
                                                                    </SelectParameters>
                                                                    <InsertParameters>
                                                                        <asp:Parameter Name="GeneralCode" Type="String"></asp:Parameter>
                                                                        <asp:Parameter Name="SubCode" Type="String"></asp:Parameter>
                                                                    </InsertParameters>
                                                                </asp:ObjectDataSource>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:Panel>
                                        </Content>
                                    </cc1:AccordionPane>
                                    <cc1:AccordionPane ID="AccordionPanePhysicians" runat="server">
                                        <Header>
                                            <u>Physicians</u></Header>
                                        <Content>
                                            <asp:Panel ID="pnlPhysicians" runat="server" Height="400px" ScrollBars="Auto" Width="100%">
                                                <center>
                                                    <table border="0" cellpadding="5" cellspacing="0">
                                                        <tr>
                                                            <td style="" align="left">
                                                                <p class="MainfontStyle">
                                                                    <asp:Label ID="lblPhysicians" runat="server" CssClass="MainfontStyle" Text="Titles :"></asp:Label></p>
                                                            </td>
                                                            <td style="" align="left">
                                                                <p class="MainfontStyle">
                                                                    <asp:Label ID="lblPhysiciansSpecialities" runat="server" CssClass="MainfontStyle"
                                                                        Text="Specialities :"></asp:Label></p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="vertical-align: top;" align="center">
                                                                <asp:GridView ID="gvPhysiciansTitles" runat="server" AutoGenerateColumns="False"
                                                                    CellPadding="1" DataKeyNames="SID" ShowFooter="True" BorderColor="#999999" BorderStyle="Solid"
                                                                    BorderWidth="1px" BackColor="White" Width="400" DataSourceID="odsPhysiciansTitles"
                                                                    AllowPaging="True" AllowSorting="True">
                                                                    <FooterStyle BackColor="#EFF3FB" Font-Bold="True" ForeColor="White" />
                                                                    <RowStyle CssClass="GridNormalRowsStyle" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Title" SortExpression="SubCode" ItemStyle-HorizontalAlign="Left">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="TextBox1" runat="server" CssClass="inputs" Text='<%# Bind("SubCode") %>'></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*"
                                                                                    ControlToValidate="TextBox1" ErrorMessage="Physician title can't be null"></asp:RequiredFieldValidator>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("SubCode") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:TextBox ID="txtPhysicianTitle" runat="server" CssClass="inputs"></asp:TextBox>
                                                                            </FooterTemplate>
                                                                            <HeaderStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                            <ItemStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ShowHeader="False" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                            <EditItemTemplate>
                                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                                                                    Text="Update"></asp:LinkButton>
                                                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                    Text="Cancel"></asp:LinkButton>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                                    Text="Edit"></asp:LinkButton>&nbsp;
                                                                                <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                                                                                    Text="Delete" OnClientClick="return confirm('Are you sure you want to delete selected title?')"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Button ID="btnAddForm" runat="server" Text="Add" CssClass="button" OnClick="btnAddPhysicianTitle_Click" />
                                                                            </FooterTemplate>
                                                                            <HeaderStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                            <ItemStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <asp:DetailsView ID="DetailsViewPhysiciansTitles" runat="server" AutoGenerateRows="False"
                                                                            DataKeyNames="SID" DataSourceID="odsPhysiciansTitles" Height="50px" Width="125px"
                                                                            DefaultMode="Insert" BorderColor="#999999" BorderStyle="Solid" OnItemInserted="DetailsViewPhysiciansTitles_ItemInserted">
                                                                            <Fields>
                                                                                <asp:BoundField DataField="SubCode" HeaderText="SubCode" SortExpression="SubCode" />
                                                                                <asp:CommandField ShowInsertButton="True" CancelText="" />
                                                                            </Fields>
                                                                        </asp:DetailsView>
                                                                    </EmptyDataTemplate>
                                                                    <PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Center" />
                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                    <HeaderStyle Font-Bold="True" ForeColor="Black" CssClass="GridHeaderBackStyle" />
                                                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                                                </asp:GridView>
                                                                <asp:ObjectDataSource ID="odsPhysiciansTitles" runat="server" InsertMethod="AddSCodeToGCode"
                                                                    SelectMethod="GetSCodeByGCode" TypeName="Pharma.BLL.LookupsBLL" UpdateMethod="UpdateSCode"
                                                                    OnUpdated="odsPhysicianTitles_Updated" OnInserting="odsPhysicianTitles_Inserting"
                                                                    DeleteMethod="DeleteSCode">
                                                                    <DeleteParameters>
                                                                        <asp:Parameter Name="SID" Type="Int32"></asp:Parameter>
                                                                    </DeleteParameters>
                                                                    <UpdateParameters>
                                                                        <asp:Parameter Name="SID" Type="Int32" />
                                                                        <asp:Parameter Name="SubCode" Type="String" />
                                                                    </UpdateParameters>
                                                                    <SelectParameters>
                                                                        <asp:Parameter DefaultValue="PhysicianTitles" Name="GeneralCode" Type="String" />
                                                                    </SelectParameters>
                                                                    <InsertParameters>
                                                                        <asp:Parameter Name="GeneralCode" Type="String" />
                                                                        <asp:Parameter Name="SubCode" Type="String" />
                                                                    </InsertParameters>
                                                                </asp:ObjectDataSource>
                                                            </td>
                                                            <td align="center">
                                                                <asp:GridView ID="gvPhysicianSpecialities" runat="server" AutoGenerateColumns="False"
                                                                    CellPadding="1" DataKeyNames="SID" ShowFooter="True" BorderColor="#999999" BorderStyle="Solid"
                                                                    BorderWidth="1px" BackColor="White" Width="400" DataSourceID="odsPhysicianSpecialities"
                                                                    AllowPaging="True" AllowSorting="True">
                                                                    <FooterStyle BackColor="#EFF3FB" Font-Bold="True" ForeColor="White" />
                                                                    <RowStyle CssClass="GridNormalRowsStyle" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Speciality" SortExpression="SubCode" ItemStyle-HorizontalAlign="Left">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="TextBox1" runat="server" CssClass="inputs" Text='<%# Bind("SubCode") %>'></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*"
                                                                                    ControlToValidate="TextBox1" ErrorMessage="Physician speciality can't be null"></asp:RequiredFieldValidator>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("SubCode") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:TextBox ID="txtPhysicianSpeciality" runat="server" CssClass="inputs"></asp:TextBox>
                                                                            </FooterTemplate>
                                                                            <HeaderStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                            <ItemStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ShowHeader="False" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                            <EditItemTemplate>
                                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                                                                    Text="Update"></asp:LinkButton>
                                                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                    Text="Cancel"></asp:LinkButton>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                                    Text="Edit"></asp:LinkButton>
                                                                                &nbsp;
                                                                                <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                                                                                    Text="Delete" OnClientClick="return confirm('Are you sure you want to delete selected speciality?')"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Button ID="btnAddForm" runat="server" Text="Add" CssClass="button" OnClick="btnAddPhysicianSpeciality_Click" />
                                                                            </FooterTemplate>
                                                                            <HeaderStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                            <ItemStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <asp:DetailsView ID="DetailsViewPhysicianSpecialities" runat="server" AutoGenerateRows="False"
                                                                            DataKeyNames="SID" DataSourceID="odsPhysicianSpecialities" Height="50px" Width="125px"
                                                                            DefaultMode="Insert" BorderColor="#999999" BorderStyle="Solid" OnItemInserted="DetailsViewPhysicianSpecialities_ItemInserted">
                                                                            <Fields>
                                                                                <asp:BoundField DataField="SubCode" HeaderText="SubCode" SortExpression="SubCode" />
                                                                                <asp:CommandField ShowInsertButton="True" CancelText="" />
                                                                            </Fields>
                                                                        </asp:DetailsView>
                                                                    </EmptyDataTemplate>
                                                                    <PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Center" />
                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                    <HeaderStyle Font-Bold="True" ForeColor="Black" CssClass="GridHeaderBackStyle" />
                                                                    <AlternatingRowStyle CssClass="AltRowStyle" />
                                                                </asp:GridView>
                                                                <asp:ObjectDataSource ID="odsPhysicianSpecialities" runat="server" InsertMethod="AddSCodeToGCode"
                                                                    SelectMethod="GetSCodeByGCode" TypeName="Pharma.BLL.LookupsBLL" UpdateMethod="UpdateSCode"
                                                                    OnUpdated="odsPhysicianSpecialities_Updated" OnInserting="odsPhysicianSpecialities_Inserting"
                                                                    DeleteMethod="DeleteSCode">
                                                                    <DeleteParameters>
                                                                        <asp:Parameter Name="SID" Type="Int32"></asp:Parameter>
                                                                    </DeleteParameters>
                                                                    <UpdateParameters>
                                                                        <asp:Parameter Name="SID" Type="Int32" />
                                                                        <asp:Parameter Name="SubCode" Type="String" />
                                                                    </UpdateParameters>
                                                                    <SelectParameters>
                                                                        <asp:Parameter DefaultValue="PhysicianSpecialities" Name="GeneralCode" Type="String" />
                                                                    </SelectParameters>
                                                                    <InsertParameters>
                                                                        <asp:Parameter Name="GeneralCode" Type="String" />
                                                                        <asp:Parameter Name="SubCode" Type="String" />
                                                                    </InsertParameters>
                                                                </asp:ObjectDataSource>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </center>
                                            </asp:Panel>
                                        </Content>
                                    </cc1:AccordionPane>
                                    <cc1:AccordionPane ID="AccordionPaneMedicalAccounts" runat="server">
                                        <Header>
                                            <u>Medical Accounts</u></Header>
                                        <Content>
                                            <asp:Panel ID="pnlMedicalAccounts" runat="server" Width="100%" Height="400px" ScrollBars="Auto">
                                                <table border="0" cellpadding="5" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="27%">
                                                        </td>
                                                        <td class="MainfontStyle" align="left">
                                                            Subordination :</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left">
                                                            <%--                                        <asp:Label ID="lblSubordination" runat="server" CssClass="MainfontStyle" Text="Subordination :"></asp:Label>
--%>
                                                            <asp:GridView ID="gvSubordination" runat="server" AutoGenerateColumns="False" CellPadding="1"
                                                                DataKeyNames="SID" ShowFooter="True" BorderColor="#999999" BorderStyle="Solid"
                                                                BorderWidth="1px" BackColor="White" Width="400" DataSourceID="odsSubordination"
                                                                AllowPaging="True" AllowSorting="True">
                                                                <FooterStyle BackColor="#EFF3FB" Font-Bold="True" ForeColor="White" />
                                                                <RowStyle CssClass="GridNormalRowsStyle" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Subordination" SortExpression="SubCode" ItemStyle-HorizontalAlign="Left">
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="inputs" Text='<%# Bind("SubCode") %>'></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*"
                                                                                ControlToValidate="TextBox1" ErrorMessage="Subordination name can't be null"></asp:RequiredFieldValidator>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("SubCode") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:TextBox ID="txtSubordination" runat="server" CssClass="inputs"></asp:TextBox>
                                                                        </FooterTemplate>
                                                                        <HeaderStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                        <ItemStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ShowHeader="False" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <EditItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                                                                Text="Update"></asp:LinkButton>
                                                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                Text="Cancel"></asp:LinkButton>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                                Text="Edit"></asp:LinkButton>
                                                                            &nbsp;
                                                                            <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                                                                                Text="Delete" OnClientClick="return confirm('Are you sure you want to delete selected subordination?')"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Button ID="btnAddForm" runat="server" Text="Add" CssClass="button" OnClick="btnAddSubordination_Click" />
                                                                        </FooterTemplate>
                                                                        <HeaderStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                        <ItemStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <asp:DetailsView ID="DetailsViewSubrdination" runat="server" AutoGenerateRows="False"
                                                                        DataKeyNames="SID" DataSourceID="odsSubordination" Height="50px" Width="125px"
                                                                        DefaultMode="Insert" BorderColor="#999999" BorderStyle="Solid" OnItemInserted="DetailsViewSubordination_ItemInserted">
                                                                        <Fields>
                                                                            <asp:BoundField DataField="SubCode" HeaderText="SubCode" SortExpression="SubCode" />
                                                                            <asp:CommandField ShowInsertButton="True" CancelText="" />
                                                                        </Fields>
                                                                    </asp:DetailsView>
                                                                </EmptyDataTemplate>
                                                                <PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Center" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                <HeaderStyle Font-Bold="True" ForeColor="Black" CssClass="GridHeaderBackStyle" />
                                                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                                            </asp:GridView>
                                                            <asp:ObjectDataSource ID="odsSubordination" runat="server" InsertMethod="AddSCodeToGCode"
                                                                SelectMethod="GetSCodeByGCode" TypeName="Pharma.BLL.LookupsBLL" UpdateMethod="UpdateSCode"
                                                                OnUpdated="odsSubordination_Updated" OnInserting="odsSubordination_Inserting"
                                                                DeleteMethod="DeleteSCode">
                                                                <DeleteParameters>
                                                                    <asp:Parameter Name="SID" Type="Int32"></asp:Parameter>
                                                                </DeleteParameters>
                                                                <UpdateParameters>
                                                                    <asp:Parameter Name="SID" Type="Int32" />
                                                                    <asp:Parameter Name="SubCode" Type="String" />
                                                                </UpdateParameters>
                                                                <SelectParameters>
                                                                    <asp:Parameter DefaultValue="Subordination" Name="GeneralCode" Type="String" />
                                                                </SelectParameters>
                                                                <InsertParameters>
                                                                    <asp:Parameter Name="GeneralCode" Type="String" />
                                                                    <asp:Parameter Name="SubCode" Type="String" />
                                                                </InsertParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </Content>
                                    </cc1:AccordionPane>
                                    <cc1:AccordionPane ID="AccordionPaneBricks" runat="server">
                                        <Header>
                                            <u>Bricks</u></Header>
                                        <Content>
                                            <asp:Panel ID="pnkBricks" runat="server" Height="400px" ScrollBars="Auto" Width="100%">
                                                <table border="0" cellpadding="5" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="27%">
                                                        </td>
                                                        <td class="MainfontStyle" align="left">
                                                            Bricks :</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left">
                                                            <%--                                        <asp:Label ID="lblBricks" runat="server" CssClass="MainfontStyle" Text="Bricks :"></asp:Label>
--%>
                                                            <asp:GridView ID="gvBricks" runat="server" AllowPaging="True" AllowSorting="True"
                                                                AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid"
                                                                BorderWidth="1px" CellPadding="1" DataKeyNames="BrickID" DataSourceID="odsBricks"
                                                                ShowFooter="True" Width="400">
                                                                <FooterStyle BackColor="#EFF3FB" Font-Bold="True" ForeColor="White" />
                                                                <RowStyle CssClass="GridNormalRowsStyle" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Name" SortExpression="BrickName" ItemStyle-HorizontalAlign="Left">
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="inputs" Text='<%# Bind("BrickName") %>'></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*"
                                                                                ControlToValidate="TextBox1" ErrorMessage="Brick name can't be null"></asp:RequiredFieldValidator>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("BrickName") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:TextBox ID="txtBrick" runat="server" CssClass="inputs"></asp:TextBox>
                                                                        </FooterTemplate>
                                                                        <HeaderStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                        <ItemStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ShowHeader="False" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <EditItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                                                                Text="Update"></asp:LinkButton>
                                                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                Text="Cancel"></asp:LinkButton>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                                Text="Edit"></asp:LinkButton>
                                                                            &nbsp;
                                                                            <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                                                                                Text="Delete" OnClientClick="return confirm('Are you sure you want to delete selected brick?')"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Button ID="btnAddBrick" runat="server" CssClass="button" OnClick="btnAddBrick_Click"
                                                                                Text="Add" />
                                                                        </FooterTemplate>
                                                                        <HeaderStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                        <ItemStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <asp:DetailsView ID="DetailsViewBricks" runat="server" AutoGenerateRows="False" BorderColor="#999999"
                                                                        BorderStyle="Solid" DataKeyNames="BrickID" DataSourceID="odsBricks" DefaultMode="Insert"
                                                                        Height="50px" OnItemInserted="DetailsViewBricks_ItemInserted" Width="125px">
                                                                        <Fields>
                                                                            <asp:BoundField DataField="BrickName" HeaderText="BrickName" SortExpression="BrickName" />
                                                                            <asp:CommandField CancelText="" ShowInsertButton="True" />
                                                                        </Fields>
                                                                    </asp:DetailsView>
                                                                </EmptyDataTemplate>
                                                                <PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Center" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                <HeaderStyle CssClass="GridHeaderBackStyle" Font-Bold="True" ForeColor="Black" />
                                                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                                            </asp:GridView>
                                                            <asp:ObjectDataSource ID="odsBricks" runat="server" InsertMethod="AddBrick" OnInserting="odsBricks_Inserting"
                                                                OnUpdated="odsBricks_Updated" SelectMethod="SelectBricks" TypeName="Pharma.BLL.LookupsBLL"
                                                                UpdateMethod="UpdateBrick" DeleteMethod="DeleteBrick">
                                                                <DeleteParameters>
                                                                    <asp:Parameter Name="BrickID" Type="Int32"></asp:Parameter>
                                                                </DeleteParameters>
                                                                <UpdateParameters>
                                                                    <asp:Parameter Name="BrickID" Type="Int32" />
                                                                    <asp:Parameter Name="BrickName" Type="String" />
                                                                </UpdateParameters>
                                                                <InsertParameters>
                                                                    <asp:Parameter Name="BrickName" Type="String" />
                                                                </InsertParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </Content>
                                    </cc1:AccordionPane>
                                    <cc1:AccordionPane ID="AccordionPaneEmployees" runat="server">
                                        <Header>
                                            <u>Employees</u></Header>
                                        <Content>
                                            <asp:Panel ID="pnlEmployees" runat="server" Width="100%" Height="400px" ScrollBars="Auto">
                                                <table border="0" cellpadding="5" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="27%">
                                                        </td>
                                                        <td class="MainfontStyle" align="left">
                                                            Employees Titles :</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left">
                                                            <%--                                        <asp:Label ID="lblEmployeesTitles" runat="server" CssClass="MainfontStyle" Text="Employees Titles :"></asp:Label>
--%>
                                                            <asp:GridView ID="gvEmployeesTitles" runat="server" AutoGenerateColumns="False" CellPadding="1"
                                                                DataKeyNames="SID" ShowFooter="True" BorderColor="#999999" BorderStyle="Solid"
                                                                BorderWidth="1px" BackColor="White" Width="400" DataSourceID="odsEmployeesTitles"
                                                                AllowPaging="True" AllowSorting="True">
                                                                <FooterStyle BackColor="#EFF3FB" Font-Bold="True" ForeColor="White" />
                                                                <RowStyle CssClass="GridNormalRowsStyle" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Title" SortExpression="SubCode" ItemStyle-HorizontalAlign="Left">
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="inputs" Text='<%# Bind("SubCode") %>'></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*"
                                                                                ControlToValidate="TextBox1" ErrorMessage="Title can't be null"></asp:RequiredFieldValidator>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("SubCode") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:TextBox ID="txtEmployeesTitles" runat="server" CssClass="inputs"></asp:TextBox>
                                                                        </FooterTemplate>
                                                                        <HeaderStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                        <ItemStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ShowHeader="False" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <EditItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                                                                Text="Update"></asp:LinkButton>
                                                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                Text="Cancel"></asp:LinkButton>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                                Text="Edit"></asp:LinkButton>
                                                                            &nbsp;
                                                                            <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                                                                                Text="Delete" OnClientClick="return confirm('Are you sure you want to delete selected title?')"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Button ID="btnAddForm" runat="server" Text="Add" CssClass="button" OnClick="btnAddEmployeesTitles_Click" />
                                                                        </FooterTemplate>
                                                                        <HeaderStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                        <ItemStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <asp:DetailsView ID="DetailsViewEmployeesTitles" runat="server" AutoGenerateRows="False"
                                                                        DataKeyNames="SID" DataSourceID="odsEmployeesTitles" Height="50px" Width="125px"
                                                                        DefaultMode="Insert" BorderColor="#999999" BorderStyle="Solid" OnItemInserted="DetailsViewEmployeesTitles_ItemInserted">
                                                                        <Fields>
                                                                            <asp:BoundField DataField="SubCode" HeaderText="SubCode" SortExpression="SubCode" />
                                                                            <asp:CommandField ShowInsertButton="True" CancelText="" />
                                                                        </Fields>
                                                                    </asp:DetailsView>
                                                                </EmptyDataTemplate>
                                                                <PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Center" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                <HeaderStyle Font-Bold="True" ForeColor="Black" CssClass="GridHeaderBackStyle" />
                                                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                                            </asp:GridView>
                                                            <asp:ObjectDataSource ID="odsEmployeesTitles" runat="server" InsertMethod="AddSCodeToGCode"
                                                                SelectMethod="GetSCodeByGCode" TypeName="Pharma.BLL.LookupsBLL" UpdateMethod="UpdateSCode"
                                                                OnUpdated="odsEmployeesTitles_Updated" OnInserting="odsEmployeesTitles_Inserting"
                                                                DeleteMethod="DeleteSCode">
                                                                <DeleteParameters>
                                                                    <asp:Parameter Name="SID" Type="Int32"></asp:Parameter>
                                                                </DeleteParameters>
                                                                <UpdateParameters>
                                                                    <asp:Parameter Name="SID" Type="Int32" />
                                                                    <asp:Parameter Name="SubCode" Type="String" />
                                                                </UpdateParameters>
                                                                <SelectParameters>
                                                                    <asp:Parameter DefaultValue="EmployeeTitles" Name="GeneralCode" Type="String" />
                                                                </SelectParameters>
                                                                <InsertParameters>
                                                                    <asp:Parameter Name="GeneralCode" Type="String" />
                                                                    <asp:Parameter Name="SubCode" Type="String" />
                                                                </InsertParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </Content>
                                    </cc1:AccordionPane>
                                    <cc1:AccordionPane ID="AccordionPane1" runat="server">
                                        <Header>
                                            <u>Governorates & Cities</u></Header>
                                        <Content>
                                            <asp:Panel ID="pnlGovCities" runat="server" Height="400px" ScrollBars="Auto">
                                                <table border="0" cellpadding="5" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="27%">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left">
                                                            <table style="width: 80%;">
                                                                <tr>
                                                                    <td class="MainfontStyle" align="left">
                                                                        <asp:Label ID="lblGovs" runat="server" CssClass="MainfontStyle" Text="Governorates:"></asp:Label>
                                                                    </td>
                                                                    <td class="MainfontStyle" align="left">
                                                                        <asp:Label ID="lblCity" runat="server" CssClass="MainfontStyle" Text="Governorates Cities:"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="vertical-align: top;">
                                                                        <asp:GridView ID="gvGovs" runat="server" AutoGenerateColumns="False" CellPadding="1"
                                                                            DataKeyNames="SID,SubCode" ShowFooter="True" BorderColor="#999999" BorderStyle="Solid"
                                                                            BorderWidth="1px" BackColor="White" Width="100%" DataSourceID="odsGovs" AllowPaging="True"
                                                                            AllowSorting="True" OnSelectedIndexChanged="gvGovs_SelectedIndexChanged">
                                                                            <FooterStyle BackColor="#EFF3FB" Font-Bold="True" ForeColor="White" />
                                                                            <RowStyle CssClass="GridNormalRowsStyle" />
                                                                            <Columns>
                                                                                <asp:CommandField SelectText="Show Cities" ShowSelectButton="True" ItemStyle-HorizontalAlign="Center">
                                                                                    <HeaderStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                                    <ItemStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                                </asp:CommandField>
                                                                                <asp:TemplateField HeaderText="Name" SortExpression="SubCode" ItemStyle-HorizontalAlign="Left">
                                                                                    <EditItemTemplate>
                                                                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="inputs" Text='<%# Bind("SubCode") %>'></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*"
                                                                                            ControlToValidate="TextBox1" ErrorMessage="Governorate name can't be null"></asp:RequiredFieldValidator>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("SubCode") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:TextBox ID="txtGov" runat="server" CssClass="inputs"></asp:TextBox>
                                                                                    </FooterTemplate>
                                                                                    <HeaderStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                                    <ItemStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ShowHeader="False" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                    <EditItemTemplate>
                                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                                                                            Text="Update"></asp:LinkButton>
                                                                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                            Text="Cancel"></asp:LinkButton>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                                            Text="Edit"></asp:LinkButton>
                                                                                        &nbsp;
                                                                                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                                                                                            Text="Delete" OnClientClick="return confirm('Are you sure you want to delete selected governorate?')"></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:Button ID="btnAddGov" runat="server" Text="Add" CssClass="button" OnClick="btnAddGov_Click" />
                                                                                    </FooterTemplate>
                                                                                    <HeaderStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                                    <ItemStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <EmptyDataTemplate>
                                                                                <asp:DetailsView ID="DetailsViewGovs" runat="server" AutoGenerateRows="False" DataKeyNames="SID"
                                                                                    DataSourceID="odsGovs" Height="50px" Width="125px" DefaultMode="Insert" BorderColor="#999999"
                                                                                    BorderStyle="Solid" OnItemInserted="DetailsViewGovs_ItemInserted">
                                                                                    <Fields>
                                                                                        <asp:BoundField DataField="SubCode" HeaderText="SubCode" SortExpression="SubCode" />
                                                                                        <asp:CommandField ShowInsertButton="True" CancelText="" />
                                                                                    </Fields>
                                                                                </asp:DetailsView>
                                                                            </EmptyDataTemplate>
                                                                            <PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Center" />
                                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                            <HeaderStyle Font-Bold="True" ForeColor="Black" CssClass="GridHeaderBackStyle" />
                                                                            <AlternatingRowStyle CssClass="AltRowStyle" />
                                                                        </asp:GridView>
                                                                        <asp:ObjectDataSource ID="odsGovs" runat="server" InsertMethod="AddSCodeToGCode"
                                                                            SelectMethod="GetSCodeByGCode" TypeName="Pharma.BLL.LookupsBLL" UpdateMethod="UpdateSCode"
                                                                            OnUpdated="odsGovs_Updated" OnInserting="odsGovs_Inserting" DeleteMethod="DeleteSCode"
                                                                            OnDeleting="odsGovs_Deleting">
                                                                            <DeleteParameters>
                                                                                <asp:Parameter Name="SID" Type="Int32"></asp:Parameter>
                                                                            </DeleteParameters>
                                                                            <UpdateParameters>
                                                                                <asp:Parameter Name="SID" Type="Int32" />
                                                                                <asp:Parameter Name="SubCode" Type="String" />
                                                                            </UpdateParameters>
                                                                            <SelectParameters>
                                                                                <asp:Parameter DefaultValue="Gov" Name="GeneralCode" Type="String" />
                                                                            </SelectParameters>
                                                                            <InsertParameters>
                                                                                <asp:Parameter Name="GeneralCode" Type="String" />
                                                                                <asp:Parameter Name="SubCode" Type="String" />
                                                                            </InsertParameters>
                                                                        </asp:ObjectDataSource>
                                                                    </td>
                                                                    <td style="vertical-align: top;">
                                                                        <div style="margin-left: 27%;">
                                                                            <asp:GridView ID="gvCities" runat="server" Width="100%" BorderStyle="Solid" BorderColor="#999999"
                                                                                DataSourceID="odsCities" DataKeyNames="CityID" AllowSorting="True" AllowPaging="True"
                                                                                BackColor="White" BorderWidth="1px" ShowFooter="True" CellPadding="1" AutoGenerateColumns="False">
                                                                                <FooterStyle BackColor="#EFF3FB" Font-Bold="True" ForeColor="White" />
                                                                                <RowStyle CssClass="GridNormalRowsStyle" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Name" SortExpression="City" ItemStyle-HorizontalAlign="Left">
                                                                                        <EditItemTemplate>
                                                                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="inputs" Text='<%# Bind("City") %>'></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*"
                                                                                                ControlToValidate="TextBox1" ErrorMessage="City name can't be null"></asp:RequiredFieldValidator>
                                                                                        </EditItemTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:TextBox ID="txtCity" runat="server" CssClass="inputs"></asp:TextBox>
                                                                                        </FooterTemplate>
                                                                                        <HeaderStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                                        <ItemStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Wrap="false" ShowHeader="False" FooterStyle-HorizontalAlign="Center"
                                                                                        ItemStyle-HorizontalAlign="Center">
                                                                                        <EditItemTemplate>
                                                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                                                                                Text="Update"></asp:LinkButton>
                                                                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                                Text="Cancel"></asp:LinkButton>
                                                                                        </EditItemTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                                                Text="Edit"></asp:LinkButton>
                                                                                            &nbsp;
                                                                                            <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                                                                                                Text="Delete" OnClientClick="return confirm('Are you sure you want to delete selected city?')"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:Button ID="btnAddCity" runat="server" Text="Add" CssClass="button" OnClick="btnAddCity_Click" />
                                                                                        </FooterTemplate>
                                                                                        <HeaderStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                                        <ItemStyle BorderStyle="Solid" BorderWidth="1px" />
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    <asp:DetailsView ID="DetailsViewCities" runat="server" AutoGenerateRows="False" DataKeyNames="CityID"
                                                                                        DataSourceID="odsCities" Height="50px" Width="125px" DefaultMode="Insert" BorderColor="#999999"
                                                                                        BorderStyle="Solid" OnItemInserting="DetailsViewCities_ItemInserting">
                                                                                        <Fields>
                                                                                            <asp:TemplateField HeaderText="City" SortExpression="City">
                                                                                                <EditItemTemplate>
                                                                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("City") %>'></asp:TextBox>
                                                                                                </EditItemTemplate>
                                                                                                <InsertItemTemplate>
                                                                                                    <asp:TextBox ID="txtInsertCity" runat="server" Text='<%# Bind("City") %>'></asp:TextBox>
                                                                                                </InsertItemTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:CommandField ShowInsertButton="True" CancelText="" />
                                                                                        </Fields>
                                                                                    </asp:DetailsView>
                                                                                </EmptyDataTemplate>
                                                                                <PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Center" />
                                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                                <HeaderStyle Font-Bold="True" ForeColor="Black" CssClass="GridHeaderBackStyle" />
                                                                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                                                            </asp:GridView>
                                                                            <asp:ObjectDataSource ID="odsCities" runat="server" InsertMethod="AddSCodeToGCode"
                                                                                SelectMethod="GetCitiesByGov" TypeName="Pharma.BLL.LookupsBLL" UpdateMethod="UpdateSCode"
                                                                                OnUpdated="odsCities_Updated" OnInserting="odsCities_Inserting" OnInserted="odsCities_Inserted"
                                                                                OnUpdating="odsCities_Updating" DeleteMethod="DeleteSCode" OnDeleting="odsCities_Deleting"
                                                                                OnDeleted="odsCities_Deleted">
                                                                                <DeleteParameters>
                                                                                    <asp:Parameter Name="SID" Type="Int32"></asp:Parameter>
                                                                                </DeleteParameters>
                                                                                <UpdateParameters>
                                                                                    <asp:Parameter Name="SID" Type="Int32" />
                                                                                    <asp:Parameter Name="SubCode" Type="String" />
                                                                                </UpdateParameters>
                                                                                <SelectParameters>
                                                                                    <asp:ControlParameter ControlID="gvGovs" DefaultValue="-1" Name="GovID" PropertyName="SelectedValue"
                                                                                        Type="Int32" />
                                                                                </SelectParameters>
                                                                                <InsertParameters>
                                                                                    <asp:Parameter Name="GeneralCode" Type="String" />
                                                                                    <asp:Parameter Name="SubCode" Type="String" />
                                                                                </InsertParameters>
                                                                            </asp:ObjectDataSource>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </Content>
                                    </cc1:AccordionPane>
                                </Panes>
                            </cc1:Accordion>
                        </td>
                    </tr>
                </tbody>
            </table>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label><br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server"></asp:ValidationSummary>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
