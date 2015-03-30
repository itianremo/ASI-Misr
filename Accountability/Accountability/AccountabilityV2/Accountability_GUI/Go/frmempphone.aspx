<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation" %>
<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.Go.frmEmpPhone" CodeFile="frmEmpPhone.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>frmEmpPhone</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <style type="text/css">.style2 { FONT-SIZE: 12px; FONT-FAMILY: Arial, Helvetica, sans-serif }
	.btn { BORDER-RIGHT: #000066 1px solid; BORDER-TOP: #000066 1px solid; FONT-SIZE: 10px; BORDER-LEFT: #000066 1px solid; COLOR: #000066; BORDER-BOTTOM: #000066 1px solid; FONT-FAMILY: Arial, Helvetica, sans-serif; BACKGROUND-COLOR: #ffffff; br: bold }
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
<body onload="load()">
    <form id="Form1" method="post" runat="server">
        <div align="center">
            <table style="width: 397px; height: 293px" cellspacing="5" cellpadding="5" width="397"
                border="0" class="FunctionBlock">
                <tr>
                    <td class="headertd" style="height: 25px">
                        Employee's contacts
                    </td>
                </tr>
                <tr>
                    <td >
                        <table style="border-collapse: collapse" bordercolor="#0066cc" cellspacing="0" cellpadding="0"
                            width="200" border="0">
                            <tr>
                                <td class="formslabels" style="height: 16px">
                                    <span class="formslabels">Code</span>
                                </td>
                                <td style="height: 16px">
                                    <asp:Label ID="lblCode" runat="server" Font-Size="Smaller" Font-Bold="True"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="formslabels">
                                    <span class="formslabels">Name</span>
                                </td>
                                <td>
                                    <asp:Label ID="lblName" runat="server" Font-Size="Smaller" Font-Bold="True"></asp:Label></td>
                            </tr>
                        </table>
                        <br>
                        <table style="width: 374px; height: 166px" width="374" align="center" border="0">
                            <tr>
                                <td class="formslabels" style="height: 23px" width="131">
                                    <div class="style2" align="right">
                                        <span class="formslabels">Area code </span>
                                    </div>
                                </td>
                                <td style="width: 95px; height: 23px" width="95">
                                    <asp:TextBox ID="txtArea" runat="server" MaxLength="3" CssClass="inputtext" Width="50px"></asp:TextBox><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator1" runat="server" BackColor="Transparent" ErrorMessage="*"
                                        ControlToValidate="txtArea"></asp:RequiredFieldValidator></td>
                                <td style="height: 23px" width="97">
                                    <asp:RegularExpressionValidator ID="Regularexpressionvalidator1" runat="server" Font-Size="XX-Small"
                                        ControlToValidate="txtCountry" ErrorMessage="Enter 2-3 digits only" ValidationExpression="\d{2,3}"></asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td class="formslabels" style="height: 7px">
                                    <div class="style2" align="right">
                                        <span class="formslabels">Country code </span>
                                    </div>
                                </td>
                                <td style="width: 95px; height: 7px">
                                    <asp:TextBox ID="txtCountry" runat="server" MaxLength="3" CssClass="inputtext" Width="50px"></asp:TextBox><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator2" runat="server" BackColor="Transparent" ErrorMessage="*"
                                        ControlToValidate="txtCountry"></asp:RequiredFieldValidator></td>
                                <td style="height: 7px">
                                    <asp:RegularExpressionValidator ID="revCountry" runat="server" Font-Size="XX-Small"
                                        ErrorMessage="Enter 2-3 digits only" ControlToValidate="txtCountry" ValidationExpression="\d{2,3}"></asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td class="formslabels" style="height: 1px">
                                    <div class="formslabels" align="right">
                                        <div align="right">
                                            Zone code
                                        </div>
                                    </div>
                                </td>
                                <td style="width: 95px; height: 1px">
                                    <asp:TextBox ID="txtZone" runat="server" MaxLength="3" CssClass="inputtext" Width="50px"></asp:TextBox><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator3" runat="server" BackColor="Transparent" ErrorMessage="*"
                                        ControlToValidate="txtZone"></asp:RequiredFieldValidator></td>
                                <td style="height: 1px">
                                    <asp:RegularExpressionValidator ID="revZoneCode" runat="server" Font-Size="XX-Small"
                                        ErrorMessage="Enter 2-3 digits only" ControlToValidate="txtZone" ValidationExpression="\d{2,3}"></asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td class="formslabels">
                                    <div class="formslabels" align="right">
                                        <div align="right">
                                            Number</div>
                                    </div>
                                </td>
                                <td style="width: 95px">
                                    <asp:TextBox ID="txtNumber" runat="server" MaxLength="7" CssClass="inputtext" Width="82px"></asp:TextBox><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator4" runat="server" BackColor="Transparent" ErrorMessage="*"
                                        ControlToValidate="txtNumber"></asp:RequiredFieldValidator></td>
                                <td>
                                    <asp:RegularExpressionValidator ID="revNumber" runat="server" Font-Size="XX-Small"
                                        ErrorMessage="Enter 5-7 digits only" ControlToValidate="txtNumber" ValidationExpression="\d{5,7}"></asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td class="formslabels">
                                    <div class="formslabels" align="right">
                                        <div align="right">
                                            Type</div>
                                    </div>
                                </td>
                                <td colspan="2">
                                    <asp:DropDownList ID="lstType" runat="server" CssClass="inputtext" Width="150px">
                                        <asp:ListItem Value="0">Business</asp:ListItem>
                                        <asp:ListItem Value="1">Business Fax</asp:ListItem>
                                        <asp:ListItem Value="2">Car</asp:ListItem>
                                        <asp:ListItem Value="3">Company</asp:ListItem>
                                        <asp:ListItem Value="4">Home</asp:ListItem>
                                        <asp:ListItem Value="5">Home Fax</asp:ListItem>
                                        <asp:ListItem Value="6">Mobile</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td class="formslabels" align="right">
                                    <div class="formslabels" align="right">
                                        <div align="right">
                                            Primary</div>
                                    </div>
                                </td>
                                <td class="formslabels" colspan="2">
                                    <asp:CheckBox ID="chkPrimary" runat="server"></asp:CheckBox></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:Label ID="lblMSG" runat="server" CssClass="RegularText" ForeColor="Red"></asp:Label>
            <br>
            <table width="100%" align="center" border="0">
                <tr align="center">
                    <td>
                        <cc1:SecButtons ID="btnAdd" runat="server" CssClass="stdSaveBtn" RuleID="5044" ToolTip="Save phone "
                            OnClick="btnAdd_Click"></cc1:SecButtons></td>
                </tr>
            </table>
            <asp:DataGrid ID="grdPhones" runat="server" Font-Size="Smaller" BackColor="White"
                OnDeleteCommand="OnDelete" DataSource="<%# dsPhonebook %>" DESIGNTIMEDRAGDROP="1200"
                BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical"
                Font-Names="Arial" AutoGenerateColumns="False">
                <SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
                <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                <ItemStyle CssClass="bsnormaltd"></ItemStyle>
                <HeaderStyle CssClass="whitetd"></HeaderStyle>
                <FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
                <Columns>
                    <asp:EditCommandColumn Visible="False" ButtonType="LinkButton" UpdateText="Update"
                        CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
                    <asp:BoundColumn DataField="PhoneBookID" SortExpression="PhoneBookID" HeaderText="PhoneBookID">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="AreaCode" HeaderText="Area"></asp:BoundColumn>
                    <asp:BoundColumn DataField="CountryCode" HeaderText="Country"></asp:BoundColumn>
                    <asp:BoundColumn DataField="PhoneZone" HeaderText="Zone"></asp:BoundColumn>
                    <asp:BoundColumn DataField="PhoneNumber" HeaderText="Number"></asp:BoundColumn>
                    <asp:BoundColumn DataField="PhoneType" SortExpression="PhoneType" HeaderText="Type">
                    </asp:BoundColumn>
                    <asp:TemplateColumn HeaderText="Primary">
                        <ItemTemplate>
                            <asp:Image ID="imgPrimary" runat="server"></asp:Image>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkEditPrimary" runat="server"></asp:CheckBox>
                        </EditItemTemplate>
                    </asp:TemplateColumn>
                    <asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
                    <asp:BoundColumn Visible="False" DataField="PrimaryPhoneBook" SortExpression="PrimaryPhoneBook"
                        HeaderText="PrimaryPhoneBook"></asp:BoundColumn>
                </Columns>
                <PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
            </asp:DataGrid>
            <p>
            </p>
        </div>
        <p align="center">
            <a href="javascript:prepareClose()" class="formslabels">Close</a>
    </form>
</body>
</html>
