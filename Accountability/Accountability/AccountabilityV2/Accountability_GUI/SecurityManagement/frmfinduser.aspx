<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.SecurityManagement.frmFindUser" CodeFile="frmFindUser.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>frmFindRuleGroup</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../Acc1.css" type="text/css" rel="stylesheet">

    <script type="text/JavaScript">
		function closeWindow()
		{
			self.opener.document.forms[0].submit();
			window.close();	
		
		}
    </script>

</head>
<body>
    <form id="Form1" method="post" runat="server">
        <table id="Table2" style="z-index: 101; left: 16px; width: 320px; position: absolute;
            top: 16px; height: 344px" cellspacing="0" cellpadding="0" width="320" border="0" class="FunctionBlock">
            <tr>
                <td align="center">
                    <table id="Table3" cellspacing="0" cellpadding="0" width="100%" border="0" height="100%">
                        <tr>
                            <td>
                                <asp:Button ID="cbFind" runat="server" Text="Find" Width="46px" CssClass="slectedbutton"
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
                    <asp:Label ID="Label1" runat="server" Width="304px" CssClass="formslabels" Visible="False">This item does not exist, please try again</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DataGrid ID="dgRoles" runat="server" Width="100%" DataSource="<%# dvUsers %>"
                        DataMember="SEC_Userss" AutoGenerateColumns="False" PageSize="40" AllowPaging="True">
                        <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                        <ItemStyle CssClass="bsnormaltd"></ItemStyle>
                        <HeaderStyle CssClass="headertd"></HeaderStyle>
                        <Columns>
                            <asp:BoundColumn DataField="UserName" SortExpression="UserName" HeaderText="User Name">
                            </asp:BoundColumn>
                            <asp:TemplateColumn>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="ChkUserHdr" runat="server" OnCheckedChanged="chkUsersHeader_CheckedChanged"
                                        AutoPostBack="True"></asp:CheckBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbxSelect" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn Visible="False" DataField="UserID" SortExpression="UserID" HeaderText="UserID">
                            </asp:BoundColumn>
                        </Columns>
                        <PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="cbAdd" runat="server" Text="Add" CssClass="slectedbutton" OnClick="cbAdd_Click">
                    </asp:Button><input type="button" value="Close" onclick="closeWindow()" class="slectedbutton"></td>
            </tr>
        </table>
    </form>
</body>
</html>
