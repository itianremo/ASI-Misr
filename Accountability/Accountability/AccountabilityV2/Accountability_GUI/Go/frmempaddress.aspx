<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.Go.frmEmpAdress" CodeFile="frmEmpAddress.aspx.cs"
    Theme="Theme1" EnableTheming="true" %>

<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>EmployeeAdresses</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <style type="text/css">.style5 { FONT-SIZE: 12px }
	.style6 { FONT-WEIGHT: bold; FONT-SIZE: 18px; COLOR: #003366; FONT-FAMILY: "Times New Roman", Times, serif }
	.btn { BORDER-RIGHT: #000066 1px solid; BORDER-TOP: #000066 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 10px; BORDER-LEFT: #000066 1px solid; COLOR: #000066; BORDER-BOTTOM: #000066 1px solid; FONT-FAMILY: Arial, Helvetica, sans-serif; BACKGROUND-COLOR: #ffffff }
		</style>
    <link href="../Acc1.css" type="text/css" rel="stylesheet">

    <script language="javascript">
		function load()
		{
			document.getElementById('lblCode').innerHTML = opener.document.getElementById('_ctl0_txtCode').value;	
			document.getElementById('lblName').innerHTML = opener.document.getElementById('_ctl0_txtFName').value
									+ ' ' + opener.document.getElementById('_ctl0_txtLName').value;	
		}
		function prepareClose()
		{
			window.close();
		}
    </script>

</head>
<body dir="ltr" onload="load()">
    <form id="Form1" method="post" runat="server">
        <div align="center">
            <asp:Table ID="tblErr" runat="server" Visible="False" ForeColor="Red">
                <asp:TableRow ForeColor="Red">
                    <asp:TableCell BackColor="White" CssClass="inputtext" ForeColor="Red"></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br>
            <table width="391" border="0" cellspacing="0" cellpadding="10" class="FunctionBlock">
                <tr>
                    <td class="headertd">
                        Employee's addresses
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table style="border-collapse: collapse" bordercolor="#0066cc" cellspacing="0" cellpadding="0"
                            width="200" border="0">
                            <tr>
                                <td class="formslabels" style="height: 13px">
                                    <span class="formslabels">Code</span>
                                </td>
                                <td style="height: 13px">
                                    <asp:Label ID="lblCode" runat="server" CssClass="formslabels">lblCode</asp:Label></td>
                            </tr>
                            <tr>
                                <td class="formslabels">
                                    <span class="formslabels">Name</span>
                                </td>
                                <td>
                                    <asp:Label ID="lblName" runat="server" CssClass="formslabels">lblName</asp:Label></td>
                            </tr>
                        </table>
                        <br>
                        <table width="354" border="0" align="center" style="width: 336px; height: 106px">
                            <tr>
                                <td width="102" class="formslabels">
                                    <div align="right">
                                        <span class="formslabels">Country</span></div>
                                </td>
                                <td style="height: 23px" width="242">
                                    <asp:DropDownList AutoPostBack="True" CssClass="inputtext" DataSource="<%# dsCountry %>"
                                        DataTextField="CountryName" DataValueField="CountryID" ID="lstCountries" runat="server"
                                        Width="150px" OnSelectedIndexChanged="lstCountries_SelectedIndexChanged">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="height: 7px" class="formslabels">
                                    <div align="right">
                                        <span class="formslabels">State</span></div>
                                </td>
                                <td style="height: 7px">
                                    <asp:DropDownList AutoPostBack="True" CssClass="inputtext" DataSource="<%# dsState %>"
                                        DataTextField="StateName" DataValueField="StateCode" ID="lstStates" runat="server"
                                        Width="150px" OnSelectedIndexChanged="lstStates_SelectedIndexChanged">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="height: 4px" class="formslabels">
                                    <div align="right">
                                        <span class="formslabels">City</span></div>
                                </td>
                                <td style="height: 4px">
                                    <asp:DropDownList CssClass="inputtext" DataSource="<%# dsCity %>" DataTextField="CityName"
                                        DataValueField="CityID" ID="lstCities" runat="server" Width="150px">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td class="formslabels">
                                    <div align="right">
                                        <span class="formslabels">ZIP Code </span>
                                    </div>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="inputtext" ID="txtZIP" runat="server" Width="117px" MaxLength="5"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvZipCode" runat="server" ErrorMessage="*" ControlToValidate="txtZIP"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="rvZipCode" runat="server" ErrorMessage="Enter digits only"
                                        ControlToValidate="txtZIP" Type="Integer" MinimumValue="1" MaximumValue="99999"
                                        Font-Size="XX-Small"></asp:RangeValidator></td>
                            </tr>
                            <tr>
                                <td class="formslabels">
                                    <div class="formslabels" align="right">
                                        <div align="right">
                                            Address</div>
                                    </div>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="inputtext" ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="formslabels" align="center">
                                    <div align="right">
                                        <asp:Label ID="Label1" runat="server" CssClass="formslabels">Primary</asp:Label></div>
                                </td>
                                <td class="formslabels">
                                    <asp:CheckBox ID="chkPrimary" runat="server"></asp:CheckBox></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <br>
            <asp:Label ID="lblMSG" runat="server" CssClass="RegularText"></asp:Label>
            <br>
            <table width="100%" align="center" border="0">
                <tr align="center">
                    <td>
                        <cc1:SecButtons ID="btnSave" runat="server" CssClass="stdSavebtn" RuleID="5048" ToolTip="Save Address to Address List"
                            OnClick="btnSave_Click"></cc1:SecButtons></td>
                </tr>
            </table>
            <asp:DataGrid ID="grdAddresses" runat="server" Font-Size="Smaller" Font-Names="Arial"
                AutoGenerateColumns="False" PageSize="3" OnDeleteCommand="OnDelete" Width="100%">
                <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                <ItemStyle CssClass="bsnormaltd"></ItemStyle>
                <SelectedItemStyle CssClass="offday"></SelectedItemStyle>
                <PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
                <HeaderStyle CssClass="whitetd"></HeaderStyle>
                <Columns>
                    <asp:BoundColumn Visible="False" DataField="addressID" HeaderText="addressID"></asp:BoundColumn>
                    <asp:BoundColumn DataField="CountryName" HeaderText="Country"></asp:BoundColumn>
                    <asp:BoundColumn DataField="stateName" HeaderText="State"></asp:BoundColumn>
                    <asp:BoundColumn DataField="cityName" HeaderText="City"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Zipcode" HeaderText="ZIP"></asp:BoundColumn>
                    <asp:BoundColumn DataField="addressline" HeaderText="Address"></asp:BoundColumn>
                    <asp:TemplateColumn HeaderText="Primary">
                        <ItemTemplate>
                            <asp:Image ID="imgPrimary" runat="server"></asp:Image>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn Visible="False" DataField="primaryAddress" HeaderText="Primary"></asp:BoundColumn>
                    <asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
                </Columns>
            </asp:DataGrid>
        </div>
        <p align="center">
            <a href="javascript:prepareClose()" class="formslabels">Close</a></p>
    </form>
    <p>
    </p>
</body>
</html>
