<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="index, App_Web_index.aspx.cdcab7d2" title=":: 4A-Pharma BMD :: Home ::" maintainScrollPositionOnPostBack="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="Controls/TransButtons.ascx" TagName="TransButtons" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tbody>
                    <tr>
                        <td align="center" colspan="3" rowspan="3">
                            <table height="140" cellspacing="0" cellpadding="0" width="100%" class="tblSearchStyle">
                                <tbody>
                                    <tr>
                                        <td align="center">
                                            <table id="tblFilters" cellspacing="0" cellpadding="0" runat="server">
                                                <tbody>
                                                    <tr id="SharedFilter" runat="server">
                                                        <td colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="text-align: right; width: 100px; height: 28px;">
                                                                        <asp:Label ID="lblSearch" runat="server" CssClass="MainfontStyle" Text="Search For:"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left; height: 28px;">
                                                                        <asp:DropDownList ID="ddlSearchby" runat="server" CssClass="inputs" AutoPostBack="True"
                                                                            OnSelectedIndexChanged="ddlSearchby_SelectedIndexChanged" Width="150px">
                                                                            <asp:ListItem Value="Physicians">Physicians </asp:ListItem>
                                                                            <asp:ListItem Value="Products">Products</asp:ListItem>
                                                                            <asp:ListItem Value="MedicalAccounts">Medical Accounts</asp:ListItem>
                                                                            <asp:ListItem Value="PrivateClinics">Private Clinics</asp:ListItem>
                                                                            <asp:ListItem Value="Pharmacies">Pharmacies</asp:ListItem>
                                                                            <asp:ListItem Value="Distributors">Distributors</asp:ListItem>
                                                                            <asp:ListItem Value="Users">Users</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="text-align: left; height: 28px;" colspan="2">
                                                                        <asp:TextBox ID="txtSearchName" runat="server" CssClass="inputs" Width="300px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr id="Physicians" runat="server">
                                                        <td align="center" colspan="4">
                                                            <!-- Physician Filter Controls Table -->
                                                            <table width="100%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td align="right" width="100">
                                                                            <asp:Label ID="lblAKA" runat="server" CssClass="MainfontStyle" Text="AKA:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtAKA" runat="server" CssClass="inputs" Width="145px"></asp:TextBox></td>
                                                                        <td align="right" width="100">
                                                                            <asp:Label ID="lblTitle" runat="server" CssClass="MainfontStyle" Text="Title:"></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:DropDownList ID="ddlTitile" runat="server" CssClass="inputs" Width="150px" AppendDataBoundItems="True"
                                                                                DataValueField="SID" DataTextField="SubCode" DataSourceID="odsTitles">
                                                                                <asp:ListItem Value="-1">All</asp:ListItem>
                                                                            </asp:DropDownList><asp:ObjectDataSource ID="odsTitles" runat="server" TypeName="Pharma.BLL.LookupsBLL"
                                                                                SelectMethod="GetSCodeByGCode" OldValuesParameterFormatString="original_{0}">
                                                                                <SelectParameters>
                                                                                    <asp:Parameter DefaultValue="PhysicianTitles" Name="GeneralCode" Type="String" />
                                                                                </SelectParameters>
                                                                            </asp:ObjectDataSource>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblSpeciality" runat="server" CssClass="MainfontStyle" Text="Speciality:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:DropDownList ID="ddlSpeciality" runat="server" CssClass="inputs" Width="150px"
                                                                                AppendDataBoundItems="True" DataValueField="SID" DataTextField="SubCode" DataSourceID="odsSpeciality">
                                                                                <asp:ListItem Value="-1">All</asp:ListItem>
                                                                            </asp:DropDownList><asp:ObjectDataSource ID="odsSpeciality" runat="server" TypeName="Pharma.BLL.LookupsBLL"
                                                                                SelectMethod="GetSCodeByGCode" OldValuesParameterFormatString="original_{0}">
                                                                                <SelectParameters>
                                                                                    <asp:Parameter DefaultValue="PhysicianSpecialities" Name="GeneralCode" Type="String" />
                                                                                </SelectParameters>
                                                                            </asp:ObjectDataSource>
                                                                        </td>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblScoreRange" runat="server" CssClass="MainfontStyle" Text="Score Range:"></asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:DropDownList ID="ddlScoreRange" runat="server" CssClass="inputs" Width="150px">
                                                                                <asp:ListItem Value="-1">All</asp:ListItem>
                                                                                <asp:ListItem Value="91-101">91 to 100</asp:ListItem>
                                                                                <asp:ListItem Value="81-91">81 to 90</asp:ListItem>
                                                                                <asp:ListItem Value="71-81">71 to 80</asp:ListItem>
                                                                                <asp:ListItem Value="61-71">61 to 70</asp:ListItem>
                                                                                <asp:ListItem Value="51-61">51 to 60</asp:ListItem>
                                                                                <asp:ListItem Value="41-51">41 to 50 </asp:ListItem>
                                                                                <asp:ListItem Value="31-41">31 to 40</asp:ListItem>
                                                                                <asp:ListItem Value="21-31">21 to 30</asp:ListItem>
                                                                                <asp:ListItem Value="11-21">11 to 20</asp:ListItem>
                                                                                <asp:ListItem Value="01-11">0 to 10</asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="4">
                                                                            &nbsp;<asp:Label ID="Label1" runat="server" CssClass="MainfontStyle" Text="Own a Private Clinic:"></asp:Label>
                                                                            <asp:RadioButtonList ID="rblOwnsClinic" runat="server" CssClass="MainfontStyle" RepeatLayout="Flow"
                                                                                RepeatDirection="Horizontal">
                                                                                <asp:ListItem Selected="True" Value="-1">All</asp:ListItem>
                                                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                                <asp:ListItem Value="0">No</asp:ListItem>
                                                                            </asp:RadioButtonList></td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr id="Products" runat="server" visible="false">
                                                        <td align="center" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="text-align: right;" width="100">
                                                                        <asp:Label ID="Label3" runat="server" CssClass="MainfontStyle" Text="Form:"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left" colspan="3">
                                                                        <asp:DropDownList ID="ddlForm" runat="server" CssClass="inputs" AppendDataBoundItems="True"
                                                                            DataValueField="SID" DataTextField="SubCode" DataSourceID="odsProductForms" Width="150px">
                                                                            <asp:ListItem Value="-1">All</asp:ListItem>
                                                                        </asp:DropDownList><asp:ObjectDataSource ID="odsProductForms" runat="server" TypeName="Pharma.BLL.LookupsBLL"
                                                                            SelectMethod="GetSCodeByGCode" OldValuesParameterFormatString="original_{0}">
                                                                            <SelectParameters>
                                                                                <asp:Parameter DefaultValue="ProductsForms" Name="GeneralCode" Type="String" />
                                                                            </SelectParameters>
                                                                        </asp:ObjectDataSource>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr id="MedicalAccounts" runat="server" visible="false">
                                                        <td style="height: 16px" align="center" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="text-align: right;" width="100">
                                                                        <asp:Label ID="Label4" runat="server" CssClass="MainfontStyle" Text="SubOrdination:"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left;">
                                                                        <asp:DropDownList ID="ddlSubOrdination" runat="server" CssClass="inputs" Width="150px"
                                                                            AppendDataBoundItems="True" DataValueField="SID" DataTextField="SubCode" DataSourceID="odsSubOrdination">
                                                                            <asp:ListItem Value="-1">All</asp:ListItem>
                                                                        </asp:DropDownList><asp:ObjectDataSource ID="odsSubOrdination" runat="server" TypeName="Pharma.BLL.LookupsBLL"
                                                                            SelectMethod="GetSCodeByGCode" OldValuesParameterFormatString="original_{0}">
                                                                            <SelectParameters>
                                                                                <asp:Parameter DefaultValue="Subordination" Name="GeneralCode" Type="String" />
                                                                            </SelectParameters>
                                                                        </asp:ObjectDataSource>
                                                                    </td>
                                                                    <td style="text-align: right;">
                                                                        <asp:Label ID="Label5" runat="server" CssClass="MainfontStyle" Text="Gov.:"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left;">
                                                                        <asp:DropDownList ID="ddlGov" runat="server" CssClass="inputs" AutoPostBack="True"
                                                                            Width="150px" AppendDataBoundItems="True" DataValueField="SID" DataTextField="SubCode"
                                                                            DataSourceID="odsGov">
                                                                            <asp:ListItem Value="-1">All</asp:ListItem>
                                                                        </asp:DropDownList><asp:ObjectDataSource ID="odsGov" runat="server" TypeName="Pharma.BLL.LookupsBLL"
                                                                            SelectMethod="GetSCodeByGCode" OldValuesParameterFormatString="original_{0}">
                                                                            <SelectParameters>
                                                                                <asp:Parameter DefaultValue="Gov" Name="GeneralCode" Type="String" />
                                                                            </SelectParameters>
                                                                        </asp:ObjectDataSource>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: right;" width="100">
                                                                        <asp:Label ID="Label6" runat="server" CssClass="MainfontStyle" Text="City:"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left;">
                                                                        <asp:DropDownList ID="ddlCity" runat="server" CssClass="inputs" Width="150px" DataValueField="CityID"
                                                                            DataTextField="City" DataSourceID="odsCity" OnDataBound="ddlCity_DataBound">
                                                                            <asp:ListItem Value="-1">All</asp:ListItem>
                                                                        </asp:DropDownList><asp:ObjectDataSource ID="odsCity" runat="server" TypeName="Pharma.BLL.LookupsBLL"
                                                                            SelectMethod="GetCitiesByGov" OldValuesParameterFormatString="original_{0}">
                                                                            <SelectParameters>
                                                                                <asp:ControlParameter ControlID="ddlGov" DefaultValue="-1" Name="GovID" PropertyName="SelectedValue"
                                                                                    Type="Int32" />
                                                                            </SelectParameters>
                                                                        </asp:ObjectDataSource>
                                                                    </td>
                                                                    <td style="text-align: right;">
                                                                        <asp:Label ID="Label7" runat="server" CssClass="MainfontStyle" Text="Brick:"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left;">
                                                                        <asp:DropDownList ID="ddlBrick" runat="server" CssClass="inputs" Width="150px" AppendDataBoundItems="True"
                                                                            DataValueField="BrickID" DataTextField="BrickName" DataSourceID="odsBrick">
                                                                            <asp:ListItem Value="-1">All</asp:ListItem>
                                                                        </asp:DropDownList><asp:ObjectDataSource ID="odsBrick" runat="server" TypeName="Pharma.BLL.LookupsBLL"
                                                                            SelectMethod="SelectBricks" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr id="PrivateClinics" runat="server" visible="false">
                                                        <td style="height: 19px" align="left" colspan="4">
                                                            <table>
                                                                <tr>
                                                                    <td style="text-align: right;" width="100">
                                                                        <asp:Label ID="Label8" runat="server" CssClass="MainfontStyle" Text="Physician: "></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left;">
                                                                        <asp:TextBox ID="txtPhysicianPC" runat="server" CssClass="inputs" Width="250px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="text-align: right;">
                                                                        <asp:Label ID="Label9" runat="server" CssClass="MainfontStyle" Text="Gov.:"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left;">
                                                                        <asp:DropDownList ID="ddlGovPC" runat="server" CssClass="inputs" AutoPostBack="True"
                                                                            Width="150px" AppendDataBoundItems="True" DataValueField="SID" DataTextField="SubCode"
                                                                            DataSourceID="odsGovPC">
                                                                            <asp:ListItem Value="-1">All</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:ObjectDataSource ID="odsGovPC" runat="server" TypeName="Pharma.BLL.LookupsBLL"
                                                                            SelectMethod="GetSCodeByGCode" OldValuesParameterFormatString="original_{0}">
                                                                            <SelectParameters>
                                                                                <asp:Parameter DefaultValue="Gov" Name="GeneralCode" Type="String" />
                                                                            </SelectParameters>
                                                                        </asp:ObjectDataSource>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: right;" width="100">
                                                                        <asp:Label ID="Label10" runat="server" CssClass="MainfontStyle" Text="City:"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left;">
                                                                        <asp:DropDownList ID="ddlCityPC" runat="server" CssClass="inputs" Width="150px" DataValueField="CityID"
                                                                            DataTextField="City" DataSourceID="odsCityPC" OnDataBound="ddlCityPC_DataBound">
                                                                            <asp:ListItem Value="-1">All</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:ObjectDataSource ID="odsCityPC" runat="server" TypeName="Pharma.BLL.LookupsBLL"
                                                                            SelectMethod="GetCitiesByGov" OldValuesParameterFormatString="original_{0}">
                                                                            <SelectParameters>
                                                                                <asp:ControlParameter ControlID="ddlGovPC" DefaultValue="-1" Name="GovID" PropertyName="SelectedValue"
                                                                                    Type="Int32" />
                                                                            </SelectParameters>
                                                                        </asp:ObjectDataSource>
                                                                    </td>
                                                                    <td style="text-align: right;">
                                                                        <asp:Label ID="Label11" runat="server" CssClass="MainfontStyle" Text="Brick:"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left;">
                                                                        <asp:DropDownList ID="ddlBrickPC" runat="server" CssClass="inputs" Width="150px"
                                                                            AppendDataBoundItems="True" DataValueField="BrickID" DataTextField="BrickName"
                                                                            DataSourceID="odsBrickPC">
                                                                            <asp:ListItem Value="-1">All</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:ObjectDataSource ID="odsBrickPC" runat="server" TypeName="Pharma.BLL.LookupsBLL"
                                                                            SelectMethod="SelectBricks" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr id="Pharmacies" runat="server" visible="false">
                                                        <td align="left" colspan="4">
                                                            <table>
                                                                <tr>
                                                                    <td style="text-align: right;" width="100">
                                                                        <asp:Label ID="Label12" runat="server" CssClass="MainfontStyle" Text="Pharmacist: "></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left;">
                                                                        <asp:TextBox ID="txtPharmacistPharmacy" runat="server" CssClass="inputs" Width="250px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="text-align: right;">
                                                                        <asp:Label ID="Label13" runat="server" CssClass="MainfontStyle" Text="Gov.:"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left;">
                                                                        <asp:DropDownList ID="ddlGovPharmacy" runat="server" CssClass="inputs" AutoPostBack="True"
                                                                            Width="150px" AppendDataBoundItems="True" DataValueField="SID" DataTextField="SubCode"
                                                                            DataSourceID="odsGovPharmacy">
                                                                            <asp:ListItem Value="-1">All</asp:ListItem>
                                                                        </asp:DropDownList><asp:ObjectDataSource ID="odsGovPharmacy" runat="server" TypeName="Pharma.BLL.LookupsBLL"
                                                                            SelectMethod="GetSCodeByGCode" OldValuesParameterFormatString="original_{0}">
                                                                            <SelectParameters>
                                                                                <asp:Parameter DefaultValue="Gov" Name="GeneralCode" Type="String" />
                                                                            </SelectParameters>
                                                                        </asp:ObjectDataSource>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: right;" width="100">
                                                                        <asp:Label ID="Label14" runat="server" CssClass="MainfontStyle" Text="City:"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left;">
                                                                        <asp:DropDownList ID="ddlCityPharmacy" runat="server" CssClass="inputs" Width="150px"
                                                                            DataValueField="CityID" DataTextField="City" DataSourceID="odsCityPharmacy" OnDataBound="ddlCityPharmacy_DataBound">
                                                                            <asp:ListItem Value="-1">All</asp:ListItem>
                                                                        </asp:DropDownList><asp:ObjectDataSource ID="odsCityPharmacy" runat="server" TypeName="Pharma.BLL.LookupsBLL"
                                                                            SelectMethod="GetCitiesByGov" OldValuesParameterFormatString="original_{0}">
                                                                            <SelectParameters>
                                                                                <asp:ControlParameter ControlID="ddlGovPharmacy" DefaultValue="-1" Name="GovID" PropertyName="SelectedValue"
                                                                                    Type="Int32" />
                                                                            </SelectParameters>
                                                                        </asp:ObjectDataSource>
                                                                    </td>
                                                                    <td style="text-align: right;">
                                                                        <asp:Label ID="Label15" runat="server" CssClass="MainfontStyle" Text="Brick:"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left;">
                                                                        <asp:DropDownList ID="ddlBrickPharmacy" runat="server" CssClass="inputs" Width="150px"
                                                                            AppendDataBoundItems="True" DataValueField="BrickID" DataTextField="BrickName"
                                                                            DataSourceID="odsBrickPharmacy">
                                                                            <asp:ListItem Value="-1">All</asp:ListItem>
                                                                        </asp:DropDownList><asp:ObjectDataSource ID="odsBrickPharmacy" runat="server" TypeName="Pharma.BLL.LookupsBLL"
                                                                            SelectMethod="SelectBricks" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr id="Distributors" runat="server" visible="false">
                                                        <td align="center" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="right" width="100">
                                                                        <asp:Label ID="lblBranches" runat="server" CssClass="MainfontStyle" Text="Branch:"></asp:Label></td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtBranches" runat="server" CssClass="inputs" Width="145px"></asp:TextBox></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr id="Users" runat="server" visible="false">
                                                        <td style="height: 70px" align="left" colspan="4">
                                                            <table>
                                                                <tr>
                                                                    <td style="text-align: right;" width="100">
                                                                        <asp:Label ID="Label16" runat="server" CssClass="MainfontStyle" Text="Employee ID: "></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left;">
                                                                        <asp:TextBox ID="txtEmployeeID" runat="server" CssClass="inputs" Width="250px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="text-align: right;">
                                                                        &nbsp;</td>
                                                                    <td style="text-align: left;">
                                                                        &nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: right;" width="100">
                                                                        <asp:Label ID="Label18" runat="server" CssClass="MainfontStyle" Text="Brick:"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left;">
                                                                        <asp:DropDownList ID="ddlBrickUser" runat="server" CssClass="inputs" Width="150px"
                                                                            AppendDataBoundItems="True" DataValueField="BrickID" DataTextField="BrickName"
                                                                            DataSourceID="odsBrickPC">
                                                                            <asp:ListItem Value="-1">All</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="text-align: right;">
                                                                        <asp:Label ID="Label17" runat="server" CssClass="MainfontStyle" Text="Title:"></asp:Label>&nbsp;</td>
                                                                    <td style="text-align: left;">
                                                                        &nbsp;<asp:DropDownList ID="ddlEmpTitles" runat="server" CssClass="inputs" Width="150px"
                                                                            AppendDataBoundItems="True" DataValueField="SID" DataTextField="SubCode" DataSourceID="odsEmpTitles">
                                                                            <asp:ListItem Value="-1">All</asp:ListItem>
                                                                        </asp:DropDownList><asp:ObjectDataSource ID="odsEmpTitles" runat="server" TypeName="Pharma.BLL.LookupsBLL"
                                                                            SelectMethod="GetSCodeByGCode" OldValuesParameterFormatString="original_{0}">
                                                                            <SelectParameters>
                                                                                <asp:Parameter DefaultValue="EmployeeTitles" Name="GeneralCode" Type="String" />
                                                                            </SelectParameters>
                                                                        </asp:ObjectDataSource>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 21px" align="center" colspan="4">
                                                            <asp:ImageButton ID="imgbtnApply" OnClick="btnApply_Click" runat="server" ImageUrl="~/Images/Search_n.jpg"
                                                                AlternateText="Search"></asp:ImageButton>&nbsp;
                                                            <asp:ImageButton ID="imgbtnReset" OnClick="imgbtnReset_Click" runat="server" ImageUrl="~/Images/Reset-n.jpg"
                                                                AlternateText="Reset"></asp:ImageButton></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <br />
                            <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Height="600px" Width="100%">
                            <asp:GridView ID="gvSearchResult" runat="server" Width="98%" OnRowDataBound="gvSearchResult_RowDataBound"
                                OnSorting="gvSearchResult_Sorting" EmptyDataText="No data found..." CellPadding="3"
                                AllowPaging="True" AllowSorting="True" BorderColor="#999999" BorderStyle="Solid"
                                BorderWidth="1px" PageSize="25" OnPageIndexChanging="gvSearchResult_PageIndexChanging"
                                BackColor="White" EnableViewState="False">
                                <RowStyle CssClass="GridNormalRowsStyle"></RowStyle>
                                <PagerStyle HorizontalAlign="Center" BackColor="White" CssClass="PagerfontStyle" VerticalAlign="Middle"></PagerStyle>
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                                <HeaderStyle Font-Bold="True" ForeColor="Black" CssClass="GridHeaderBackStyle"></HeaderStyle>
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                            </asp:GridView>
                                </asp:Panel>
                            <asp:ObjectDataSource ID="odsUsers" runat="server" TypeName="Pharma.BLL.ManageUsersBLL"
                                SelectMethod="SelectFileteredEmployees" OldValuesParameterFormatString="original_{0}"
                                OnSelected="odsUsers_Selected">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtSearchName" Name="empName" PropertyName="Text"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="txtEmployeeID" Name="empID" PropertyName="Text"
                                        Type="Int32" DefaultValue="-1" />
                                    <asp:ControlParameter ControlID="ddlEmpTitles" Name="titleID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                    <asp:ControlParameter ControlID="ddlBrickUser" DefaultValue="-1" Name="brickID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsDistributers" runat="server" TypeName="Pharma.BLL.DistributorsBLL"
                                SelectMethod="GetFilteredDistributors" OldValuesParameterFormatString="original_{0}"
                                OnSelected="odsDistributers_Selected">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtSearchName" Name="DistributorName" PropertyName="Text"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="txtBranches" Name="BranchName" PropertyName="Text"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsPharmacies" runat="server" TypeName="Pharma.BLL.PharmaciesBLL"
                                SelectMethod="SelectFilteredPharmacies" OldValuesParameterFormatString="original_{0}"
                                OnSelected="odsPharmacies_Selected">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtSearchName" Name="pharmacyName" PropertyName="Text"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="txtPharmacistPharmacy" Name="pharmacistName" PropertyName="Text"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="ddlGovPharmacy" Name="GovID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                    <asp:ControlParameter ControlID="ddlCityPharmacy" Name="CityID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                    <asp:ControlParameter ControlID="ddlBrickPharmacy" Name="BrickID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsPrivateClinics" runat="server" TypeName="Pharma.BLL.PrivateClinicsBLL"
                                SelectMethod="SelectFilteredPrivateClinics" OldValuesParameterFormatString="original_{0}"
                                OnSelected="odsPrivateClinics_Selected">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtSearchName" DefaultValue="" Name="privateClinicName"
                                        PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="txtPhysicianPC" Name="PhysicianName" PropertyName="Text"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="ddlGovPC" DefaultValue="-1" Name="GovID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                    <asp:ControlParameter ControlID="ddlCityPC" DefaultValue="-1" Name="CityID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                    <asp:ControlParameter ControlID="ddlBrickPC" DefaultValue="-1" Name="BrickID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsMedicalAccounts" runat="server" TypeName="Pharma.BLL.MedicalAccountsBLL"
                                SelectMethod="SelectFilteredMedAccounts" OldValuesParameterFormatString="original_{0}"
                                OnSelected="odsMedicalAccounts_Selected">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtSearchName" DefaultValue="" Name="medAccName"
                                        PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="ddlSubOrdination" DefaultValue="-1" Name="subOrdinationID"
                                        PropertyName="SelectedValue" Type="Int32" />
                                    <asp:ControlParameter ControlID="ddlGov" DefaultValue="-1" Name="GovID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                    <asp:ControlParameter ControlID="ddlCity" DefaultValue="-1" Name="CityID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                    <asp:ControlParameter ControlID="ddlBrick" DefaultValue="-1" Name="BrickID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsProducts" runat="server" TypeName="Pharma.BLL.ProductsBLL"
                                SelectMethod="SelectFilteredProducts" OldValuesParameterFormatString="original_{0}"
                                OnSelected="odsProducts_Selected">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtSearchName" Name="productName" PropertyName="Text"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="ddlForm" DefaultValue="-1" Name="formID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsPhysicians" runat="server" TypeName="Pharma.BLL.PhysiciansBLL"
                                SelectMethod="SelectFilteredPhysicians" OldValuesParameterFormatString="original_{0}"
                                OnSelected="odsPhysicians_Selected">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtSearchName" Name="physicianName" PropertyName="Text"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="txtAKA" Name="AKA" PropertyName="Text" Type="String"
                                        DefaultValue="" />
                                    <asp:ControlParameter ControlID="ddlTitile" DefaultValue="-1" Name="titleID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                    <asp:ControlParameter ControlID="ddlSpeciality" DefaultValue="-1" Name="specialityID"
                                        PropertyName="SelectedValue" Type="Int32" />
                                    <asp:ControlParameter ControlID="rblOwnsClinic" DefaultValue="-1" Name="privateClinic"
                                        PropertyName="SelectedValue" Type="String" />
                                    <asp:ControlParameter ControlID="ddlScoreRange" DefaultValue="-1" Name="Score" PropertyName="SelectedValue"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
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
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" UseContextKey="True"
                TargetControlID="txtSearchName" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                FirstRowSelected="true" EnableCaching="true" DelimiterCharacters=";," CompletionSetCount="20"
                CompletionInterval="10" BehaviorID="autoCompleteBehavior1">
            </cc1:AutoCompleteExtender>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" UseContextKey="True"
                TargetControlID="txtPhysicianPC" ServiceMethod="GetSecondaryCompletionList" MinimumPrefixLength="1"
                FirstRowSelected="true" EnableCaching="true" DelimiterCharacters=";," CompletionSetCount="20"
                CompletionInterval="10" BehaviorID="autoCompleteBehavior4">
            </cc1:AutoCompleteExtender>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server" UseContextKey="True"
                TargetControlID="txtPharmacistPharmacy" ServiceMethod="GetThirdCompletionList"
                MinimumPrefixLength="1" FirstRowSelected="true" EnableCaching="true" DelimiterCharacters=";,"
                CompletionSetCount="20" CompletionInterval="10" BehaviorID="autoCompleteBehavior5">
            </cc1:AutoCompleteExtender>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender6" runat="server" UseContextKey="True"
                TargetControlID="txtEmployeeID" ServiceMethod="GetForthCompletionList" MinimumPrefixLength="1"
                FirstRowSelected="true" EnableCaching="true" DelimiterCharacters=";," CompletionSetCount="20"
                CompletionInterval="10" BehaviorID="autoCompleteBehavior6">
            </cc1:AutoCompleteExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
