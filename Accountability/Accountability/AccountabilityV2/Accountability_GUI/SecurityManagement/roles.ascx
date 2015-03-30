<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.SecurityManagement.Roles" CodeFile="Roles.ascx.cs" %>
<link href="../Acc1.css" type="text/css" rel="stylesheet">

<script type="text/JavaScript">
function openWindow(url)
{
	if ( document.getElementById( '_ctl0_selectedRole'  ).value == "" )
	{	
	  alert( "please select a role first" )
	  return	
	}
	if ( wndHandle && wndHandle.open && wndHandle.closed)
		wndHandle.close();
	wndHandle=open('','window','width=450,height=500,top=0,left=200,status=yes,scrollbars=yes');
	wndHandle.location.href = url;
	if (wndHandle.opener == null) wndHandle.opener = self;		
}

function test()
{
	alert("hiii") ;
}
</script>

<table class="whitetd" id="Table1" style="width: 916px; height: 150px" height="150"
    cellspacing="1" cellpadding="1" align="center" border="0">
    <tr>
        <td class="headertd" style="width: 438px; height: 23px" valign="top" width="438">
            <p align="center">
                Roles</p>
        </td>
        <td class="headertd" style="height: 23px" valign="top" width="50%">
            <p align="center">
                Role Details</p>
        </td>
    </tr>
    <tr>
        <td style="width: 439px" valign="top" width="439" colspan="1">
            <table id="Table2" cellspacing="1" cellpadding="1" width="100%" border="0" class="FunctionBlock">
                <tr>
                    <td>
                        <div align="center" style="overflow: auto; height: 500px">
                            <asp:DataGrid ID="dgRulesGroup" Width="100%" AutoGenerateColumns="False" DataSource="<%# dvRulesGroup %>"
                                runat="server">
                                <SelectedItemStyle CssClass="offday"></SelectedItemStyle>
                                <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                                <ItemStyle CssClass="bsnormaltd"></ItemStyle>
                                <HeaderStyle CssClass="whitetd"></HeaderStyle>
                                <Columns>
                                    <asp:BoundColumn DataField="RuleGroupID" SortExpression="RuleGroupID" HeaderText="Role ID">
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Role Name">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkRoleName" runat="server" CssClass="gridLink" Text='<%# DataBinder.Eval(Container, "DataItem.RuleGroupName") %>'
                                                CommandName="GetRoleDetails">
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle CssClass="bsFootertd"></PagerStyle>
                            </asp:DataGrid>
                        </div>
                    </td>
                </tr>
            </table>
        </td>
        <td valign="top" width="50%">
            <table id="Table3" height="100%" cellspacing="1" cellpadding="1"
                width="100%" border="0" class="FunctionBlock">
                <tr>
                    <td class="formslabels" style="width: 84px; height: 20px" valign="top" width="84">
                    </td>
                    <td style="height: 20px" valign="top">
                    </td>
                </tr>
                <tr>
                    <td class="formslabels" style="width: 84px" valign="top">
                        Role Name</td>
                    <td valign="top">
                        <asp:TextBox ID="txtRoleName" Width="342px" runat="server" CssClass="inputtext" Enabled="False"
                            MaxLength="50"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="height: 50px" valign="top" align="center" colspan="3">
                        <asp:Button ID="btnNew" runat="server" CssClass="slectedbutton" Text="New" OnClick="btnNew_Click">
                        </asp:Button>&nbsp;&nbsp;
                        <asp:Button ID="btnSave" runat="server" CssClass="slectedbutton" Text="Save" Visible="False"
                            OnClick="btnSave_Click"></asp:Button>&nbsp;&nbsp;
                        <asp:Button ID="btnDelete" runat="server" CssClass="slectedbutton" Text="Delete"
                            Visible="False" OnClick="btnDelete_Click"></asp:Button></td>
                </tr>
                <tr>
                    <td class="headertd" style="height: 23px" valign="top" align="center" colspan="3">
                        Role Access Rights</td>
                </tr>
                <tr>
                    <td style="height: 26px" valign="top" align="center" colspan="3">
                        &nbsp;&nbsp;&nbsp;
                        <input class="slectedbutton" id="btnAddEnt" onclick="openWindow('../SecurityManagement/ViewRlGrps.aspx') "
                            type="button" value="Add Access" runat="server" name="btnAddEnt">
                        <asp:Button ID="ButtonRemoveAccess" Width="115px" runat="server" CssClass="slectedbutton"
                            Text="Remove Access" OnClick="Button1_Click"></asp:Button></td>
                </tr>
                <tr>
                    <td valign="top" colspan="3" style="height: 100%">
                        <asp:ListBox ID="lbRuleEntities" DataSource="<%# dvRuleEntity %>" runat="server"
                            CssClass="textarea" SelectionMode="Multiple" DataValueField="RuleEntityID" DataTextField="RuleEntityDescription"
                            Width="100%" Height="100%" Rows="20"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<input id="selectedRole" style="visibility: hidden" type="text" size="6" runat="server"
    name="selectedRole">
