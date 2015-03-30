<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.SecurityManagement.frmFindRuleGroup"
    CodeFile="frmFindRuleGroup.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Role Group</title>
    <meta name="vs_snapToGrid" content="False">
    <meta name="vs_showGrid" content="False">
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
    <link href="../Acc1.css" type="text/css" rel="stylesheet">

    <script type="text/JavaScript">
		function closeWindow()
		{
			
			//window.opener.location.reload( true );
			//window.opener.location= self.opener.location.href+"?role=1";
			//window.opener.location = "../navigation/ContentPage.aspx?bc=1";
			//window.opener.location.reload( true );
			//self.opener.document.getElementById('openerBox').value = 1; 
			self.opener.document.forms[0].submit();
			window.close();	
		}
    </script>

</head>
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <table id="Table2" style="z-index: 101; left: 16px; width: 320px; position: absolute;
            top: 8px; height: 344px" cellspacing="0" cellpadding="0" width="320" border="0">
            <tr>
                <td align="center">
                    <table id="Table3" height="100%" cellspacing="0" cellpadding="0" width="100%" border="0" class="FunctionBlock">
                        <tr>
                            <td>
                                <asp:Button ID="cbFind" runat="server" CssClass="slectedbutton" Width="46px" Text="Find"
                                    OnClick="cbFind_Click"></asp:Button></td>
                            <td>
                                <asp:TextBox ID="tbFilter" runat="server" Width="194px"></asp:TextBox></td>
                            <td>
                                <asp:LinkButton ID="lbShowAll" runat="server" CssClass="headerFont" OnClick="lbShowAll_Click">Show All</asp:LinkButton></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DataGrid ID="dgRoles" runat="server" Width="100%" AllowPaging="True" PageSize="40"
                        AutoGenerateColumns="False" DataMember="SEC_RuleGroup" DataSource="<%# dvRoles %>"
                        Height="100%">
                        <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                        <ItemStyle CssClass="bsnormaltd"></ItemStyle>
                        <HeaderStyle CssClass="headertd"></HeaderStyle>
                        <FooterStyle CssClass="bsFootertd"></FooterStyle>
                        <Columns>
                            <asp:BoundColumn DataField="RuleGroupName" SortExpression="RuleGroupName" HeaderText="Roles">
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Select">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="ChkRolesHdr" runat="server" OnCheckedChanged="chkRolesHeader_CheckedChanged"
                                        AutoPostBack="True"></asp:CheckBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbxSelect" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn Visible="False" DataField="RuleGroupID" SortExpression="RuleGroupID"
                                HeaderText="RuleGroupID"></asp:BoundColumn>
                        </Columns>
                        <PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid></td>
            </tr>
            <tr>
                <td>
                    <p>
                        <asp:Button ID="cbAdd" runat="server" CssClass="slectedbutton" Text="Add" OnClick="cbAdd_Click">
                        </asp:Button>
                        <input type="button" value="Close" onclick="closeWindow()" class="slectedbutton"
                            id="Button1" name="Button1" runat="server"></p>
                    <p>
                        <asp:Label ID="Label1" runat="server" CssClass="formslabels" Width="304px" Visible="False">This item does not exist, please try again</asp:Label></p>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
