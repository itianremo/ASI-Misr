<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.SecurityManagement.ManageUserGroups"
    CodeFile="ManageUserGroups.ascx.cs" %>
<link href="../Acc1.css" type="text/css" rel="stylesheet">

<script type="text/JavaScript">
function openWindow(url)
{
	//alert( document.getElementById('_ctl0_openerBox').value );
	//document.getElementById('_ctl0_openerBox').value = 2; 
	
	if ( wndHandle && wndHandle.open && wndHandle.closed)
		wndHandle.close();
	wndHandle=open('','window','width=450,height=500,top=0,left=200,status=yes,scrollbars=yes');
	wndHandle.location.href = url;
	if (wndHandle.opener == null) wndHandle.opener = self;		
	
}

</script>

<asp:Panel ID="Panel1" Width="100%" runat="server">
    <table id="Table2" style="width: 916px; height: 150px" height="150"
        cellspacing="1" cellpadding="1" align="center" border="0">
        <tr>
            <td class="whitetd" style="width: 443px">
                <table id="Table4" height="100%" cellspacing="1" cellpadding="1" width="100%" align="left"
                    border="0" class="FunctionBlock">
                    <tr>
                        <td class="headertd" align="center" style="height: 23px">
                            User Groups</td>
                    </tr>
                    <tr>
                        <td style="height: 104px" valign="top" align="center">
                            <div align="left">
                                <table style="width: 100%" cellspacing="0" border="0">
                                    <tr class="whitetd">
                                        <td style="width: 345px">
                                            User Group Name</td>
                                        <td>
                                            Select</td>
                                    </tr>
                                </table>
                            </div>
                            <div style="overflow: auto; height: 600px" align="center">
                                <asp:DataGrid ID="dgUserGroupName" Width="100%" runat="server" ShowHeader="False"
                                    AutoGenerateColumns="False" DataMember="SEC_UsersGroups" DataSource="<%# dataSetGroups1 %>"
                                    SelectedIndex="0">
                                    <SelectedItemStyle CssClass="offday"></SelectedItemStyle>
                                    <EditItemStyle HorizontalAlign="left"></EditItemStyle>
                                    <AlternatingItemStyle  CssClass="bsalternativetd"></AlternatingItemStyle>
                                    <ItemStyle  CssClass="bsnormaltd"></ItemStyle>
                                    <HeaderStyle  CssClass="headertd"></HeaderStyle>
                                    <FooterStyle HorizontalAlign="Center"></FooterStyle>
                                    <Columns>
                                        <asp:BoundColumn Visible="False" DataField="UserGroupID" HeaderText="UserGroupID"></asp:BoundColumn>
                                        <asp:TemplateColumn SortExpression="UserGroupName" HeaderText="User Group Name">
                                            <HeaderStyle Width="80%"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" OnClick="BindDataGroupsUsers" runat="server" CssClass="gridLink"
                                                    Text='<%# DataBinder.Eval(Container, "DataItem.UserGroupName")%>'>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UserGroupName") %>'>
                                                </asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn Visible="False" DataField="UserGroupType" HeaderText="UserGroupType">
                                        </asp:BoundColumn>
                                        <asp:TemplateColumn HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                    </Columns>
                                    <PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
                                </asp:DataGrid></div>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 6px" align="center">
                            <asp:Button ID="btnDeleteUserGroups" Width="159px" runat="server" CssClass="slectedbutton"
                                Text="Delete User Group" OnClick="btnDeleteUserGroups_Click"></asp:Button>
                            <asp:Button ID="btnNewUserGroup" Width="159px" runat="server" CssClass="slectedbutton"
                                Text="New User Group" OnClick="btnNewUserGroup_Click"></asp:Button></td>
                    </tr>
                    <tr>
                        <td style="height: 9px" align="center">
                            <asp:TextBox ID="txtAddGroup" runat="server" Visible="False"></asp:TextBox>
                            <asp:Button ID="btnAddGroup" runat="server" CssClass="slectedbutton" Text="Add Group"
                                Visible="False" OnClick="btnAddGroup_Click"></asp:Button>&nbsp;
                            <asp:Button ID="btnCancel" runat="server" CssClass="slectedbutton" Text="Cancel"
                                Visible="False" OnClick="btnCancel_Click"></asp:Button></td>
                    </tr>
                    <tr>
                        <td style="height: 1px" align="center">
                            <asp:Label ID="lblRequired" runat="server" Visible="False" ForeColor="Red" Font-Size="10pt">Enter user group name</asp:Label></td>
                    </tr>
                    <tr>
                        <td align="center">
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 1px" valign="top">
            </td>
            <td class="whitetd" valign="top">
                <table id="Table3" cellspacing="1" cellpadding="1" width="100%" align="center" border="0" class="FunctionBlock">
                    <tr>
                        <td class="headertd" align="center" style="height: 23px">
                            Users</td>
                    </tr>
                    <tr>
                        <td valign="top" align="center">
                            <div align="left">
                                <table style="width: 100%" cellspacing="0" border="0">
                                    <tr class="whitetd">
                                        <td width="75%">
                                            User Name</td>
                                        <td width="25%">
                                            Select</td>
                                    </tr>
                                </table>
                            </div>
                            <div style="overflow: auto; height: 300px" align="center">
                                <asp:DataGrid ID="dgUsers" Width="100%" runat="server" ShowHeader="False" AutoGenerateColumns="False"
                                    DataMember="SEC_Users" DataSource="<%# dataSetUser1 %>">
                                    <SelectedItemStyle CssClass="offday"></SelectedItemStyle>
                                    <EditItemStyle HorizontalAlign="Center"></EditItemStyle>
                                    <AlternatingItemStyle  CssClass="bsalternativetd"></AlternatingItemStyle>
                                    <ItemStyle  CssClass="bsnormaltd"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Center" CssClass="headertd"></HeaderStyle>
                                    <FooterStyle HorizontalAlign="Center"></FooterStyle>
                                    <Columns>
                                        <asp:BoundColumn Visible="False" DataField="UserID" SortExpression="UserID" HeaderText="UserID">
                                        </asp:BoundColumn>
                                        <asp:TemplateColumn HeaderText="User Name">
                                            <HeaderStyle Width="75%"></HeaderStyle>
                                            <ItemStyle  Width="75%"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UserName") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UserName") %>'>
                                                </asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn Visible="False" DataField="WinUser" SortExpression="WinUser" HeaderText="WinUser">
                                        </asp:BoundColumn>
                                        <asp:TemplateColumn HeaderText="Select">
                                            <HeaderStyle Width="25%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="25%"></ItemStyle>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkUsersHdr" runat="server" AutoPostBack="True" OnCheckedChanged="chkUsersHeader_CheckedChanged">
                                                </asp:CheckBox>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="SelectUser" runat="server"></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                    </Columns>
                                    <PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
                                </asp:DataGrid></div>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="center">
                            <asp:Button ID="btnRemoveUser" Width="105px" runat="server" CssClass="slectedbutton"
                                Text="Remove User" OnClick="btnRemoveUser_Click"></asp:Button>&nbsp;
                            <input class="slectedbutton" id="btnAddUser" onclick="openWindow('../SecurityManagement/frmFindUser.aspx?GroupID=<%=userGroupID%>')"
                                type="button" value="Add User" name="btnAddUser">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="center">
                        </td>
                    </tr>
                    <tr>
                        <td class="headertd" align="center" style="height: 23px">
                            User Group Roles</td>
                    </tr>
                    <tr>
                        <td valign="top" align="center">
                            <div align="left">
                                <table style="width: 100%" cellspacing="0" border="0">
                                    <tr class="whitetd">
                                        <td width="75%">
                                            Role Name</td>
                                        <td width="25%">
                                            Select</td>
                                    </tr>
                                </table>
                            </div>
                            <div style="overflow: auto; height: 300px" align="center">
                                <asp:DataGrid ID="dgRoleGroups" Width="100%" runat="server" ShowHeader="False" AutoGenerateColumns="False"
                                    DataMember="SEC_RuleGroup" DataSource="<%# dataSetRuleGroup1 %>">
                                    <SelectedItemStyle CssClass="offday"></SelectedItemStyle>
                                    <EditItemStyle HorizontalAlign="Center"></EditItemStyle>
                                    <AlternatingItemStyle  CssClass="bsalternativetd"></AlternatingItemStyle>
                                    <ItemStyle  CssClass="bsnormaltd"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Center" CssClass="headertd"></HeaderStyle>
                                    <FooterStyle HorizontalAlign="Center"></FooterStyle>
                                    <Columns>
                                        <asp:BoundColumn Visible="False" DataField="RuleGroupID" SortExpression="RuleGroupID"
                                            HeaderText="RuleGroupID"></asp:BoundColumn>
                                        <asp:TemplateColumn HeaderText="Role Name">
                                            <HeaderStyle Width="75%"></HeaderStyle>
                                            <ItemStyle  Width="75%" VerticalAlign="Middle"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RuleGroupName") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RuleGroupName") %>'>
                                                </asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Select">
                                            <HeaderStyle Width="25%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="25%"></ItemStyle>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkRolesHdr" runat="server" Checked="False" AutoPostBack="True"
                                                    OnCheckedChanged="chkRolesHeader_CheckedChanged"></asp:CheckBox>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="SelectRole" runat="server"></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                    </Columns>
                                    <PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
                                </asp:DataGrid></div>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="center">
                            <asp:Button ID="btnRemoveRole" Width="105px" runat="server" CssClass="slectedbutton"
                                Text="Remove Role" OnClick="btnRemoveRole_Click"></asp:Button>&nbsp;
                            <input class="slectedbutton" id="btnAddRole" onclick="openWindow('../SecurityManagement/frmFindRuleGroup.aspx?GroupID=<%=userGroupID%>'),CheckRoleGroupGrid()"
                                type="button" value="Add Role" name="btnAddRole"></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Panel>

<script>
function CheckRoleGroupGrid()
{
	var index = 2;
	var cbRoleGroup = document.getElementById("_ctl0_dgRoleGroups__ctl"+index+"_SelectRole");	
	while(cbRoleGroup!=null)
	{

			if(cbRoleGroup.checked)
			{
				document.getElementById("_ctl0_dgRoleGroups__ctl"+index+"_SelectRole").checked = false;
			}
		index++;
		cbRoleGroup = document.getElementById("_ctl0_dgRoleGroups__ctl"+index+"_SelectRole");	
	}
}
////////////////////////////////////////////////////////////////
function Checkusersfordelete()
{
	var index = 2;
	var count = 0;			
	var cbUsers= document.getElementById("_ctl0_dgUsers__ctl"+index+"_SelectUser");	
	while(cbUsers!=null)
	{

			if(cbUsers.checked)
			{
				count++;
			}
		index++;
			 cbUsers= document.getElementById("_ctl0_dgUsers__ctl"+index+"_SelectUser");	
	}
	if(count==0)
	{
		alert("Please select user name to delete");
	}	
}
///////////////////////////////////////////////////////////
function Checkusergroupsfordelete()
{
	var index = 2;
	var count = 0;			
	var cbUsers= document.getElementById("_ctl0_dgUserGroupName__ctl"+index+"_CheckBox1");	
	while(cbUsers!=null)
	{
    
			if(cbUsers.checked==true)
			{
				count++;
			}
		index++;
			 cbUsers= document.getElementById("_ctl0_dgUserGroupName__ctl"+index+"_CheckBox1");	
	}
	if(count==0)
	{
		alert("Please select user group to delete");
	}	
}

</script>

