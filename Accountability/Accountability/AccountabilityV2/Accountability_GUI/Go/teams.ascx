<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.Go.Teams1" CodeFile="Teams.ascx.cs" %>
<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation" %>
<link href="../Acc1.css" type="text/css" rel="stylesheet">
<asp:Panel ID="Panel1" dir="ltr" DESIGNTIMEDRAGDROP="25" Height="528px" runat="server">
    <table style="border-collapse: collapse" bordercolor="#003366" height="100%" cellspacing="0"
        cellpadding="0" width="100%" align="center" border="1">
        <tr>
            <td valign="top" width="50%" height="10%">
                <table height="100%" cellspacing="5" cellpadding="5" width="100%" border="0">
                    <tr class="headertd">
                        <td style="height: 8px">
                            Teams</td>
                    </tr>
                    <tr>
                        <td class="whitetd" valign="top" height="100%">
                            <table id="Table6" height="100%" cellspacing="1" cellpadding="1" width="95%" border="0"
                                class="FunctionBlock">
                                <tr>
                                    <td id="tdTeams" style="height: 494px" align="center" height="494">
                                        <div style="overflow: auto; width: 549px; height: 85.27%" onload="SetHeight();">
                                            <asp:DataGrid ID="dgTeams" runat="server" BorderColor="White" Width="100%" AutoGenerateColumns="False"
                                                DataMember="GEN_Teams" DataSource="<%# dsTeams1 %>" BorderStyle="None" BorderWidth="1px"
                                                CellPadding="2">
                                                <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                                                <ItemStyle CssClass="bsnormaltd"></ItemStyle>
                                                <HeaderStyle Font-Bold="True" CssClass="whitetd"></HeaderStyle>
                                                <Columns>
                                                    <asp:TemplateColumn HeaderText="Team Name">
                                                        <HeaderStyle Width="90%"></HeaderStyle>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" OnClick="LoadTeamById" runat="server" CssClass="gridLink"
                                                                CausesValidation="False" Width="158px" Text='<%# DataBinder.Eval(Container, "DataItem.TeamName")%>'>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TeamName") %>'>
                                                            </asp:TextBox>
                                                        </EditItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:BoundColumn Visible="False" DataField="TeamID" SortExpression="TeamID" HeaderText="TeamID">
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn Visible="False" DataField="projectID" SortExpression="projectID"
                                                        HeaderText="projectID"></asp:BoundColumn>
                                                    <asp:BoundColumn Visible="False" DataField="TeamLeader" SortExpression="TeamLeader"
                                                        HeaderText="TeamLeader"></asp:BoundColumn>
                                                    <asp:BoundColumn Visible="False" DataField="TeamDesc" SortExpression="TeamDesc" HeaderText="TeamDesc">
                                                    </asp:BoundColumn>
                                                    <asp:TemplateColumn HeaderText="Select">
                                                        <HeaderStyle Width="10%"></HeaderStyle>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="CheckBox2" runat="server"></asp:CheckBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </Columns>
                                                <PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
                                            </asp:DataGrid></div>
                                        <br />
                                        <asp:Label ID="lblTeams" runat="server" CssClass="formslabels" ForeColor="Red" Visible="False">Select team to delete...</asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <cc1:SecButtons ID="btnNewTeam" runat="server" ToolTip="Create New Team" CausesValidation="False"
                                            RuleID="5091" CssClass="stdNewTeam" OnClick="btnNewTeam_Click"></cc1:SecButtons>&nbsp;
                                        <cc1:SecButtons ID="btnRemoveTeam" runat="server" ToolTip="Delete Selected Teams" CausesValidation="False"
                                            RuleID="5093" CssClass="stdDeleteTeam" OnClick="btnRemoveTeam_Click"></cc1:SecButtons></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <table height="100%" cellspacing="0" cellpadding="0" width="100%" align="center"
                    border="0">
                    <tr>
                        <td height="10%">
                            <table cellspacing="5" cellpadding="5" width="100%" border="0">
                                <tr>
                                    <td class="headertd">
                                        Edit Team
                                    </td>
                                </tr>
                                <tr>
                                    <td class="whitetd">
                                        <table cellspacing="0" cellpadding="2" width="100%" border="0" class="FunctionBlock">
                                            <tr>
                                                <td class="formslabels" align="right">
                                                    * Team</td>
                                                <td>
                                                    <span>
                                                        <asp:TextBox ID="txtTeamName" runat="server" CssClass="inputtext"></asp:TextBox></span></td>
                                                <td class="formslabels" style="height: 8px">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="errmsg"
                                                        ForeColor=" " BackColor="Transparent" ErrorMessage="Required" ControlToValidate="txtTeamName">Required</asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td class="formslabels" style="height: 8px" align="right">
                                                    * Leader</td>
                                                <td class="formslabels" style="height: 8px">
                                                    <span>
                                                        <asp:DropDownList ID="drpLeaderName" runat="server" DataMember="GEN_Employees" DataSource="<%# dsEmployee2 %>"
                                                            CssClass="inputtext" DataTextField="Fullname" DataValueField="ContactID" OnDataBinding="drpLeaderName_DataBinding">
                                                        </asp:DropDownList>
                                                        <img onclick="controlName ='drpLeaderName'; openEmpWnd()" alt="Find Employee"
                                                            src="../Go/images/Buttons/Find_n.jpg" style="height:23px;width:23px;vertical-align:bottom;" />
                                                    </span>
                                                </td>
                                                <td class="formslabels" style="height: 8px">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="errmsg"
                                                        ForeColor=" " BackColor="Transparent" ErrorMessage="Required" ControlToValidate="drpLeaderName">Required</asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td class="formslabels" align="right">
                                                    Description</td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="txtDescription" runat="server" CssClass="inputtext" TextMode="MultiLine"
                                                        Rows="5" Columns="30" OnLoad="txtDescription_Load"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="height: 34px">
                                                    <cc1:SecButtons ID="btnSaveDiscription" runat="server" ToolTip="Update Team" RuleID="5092"
                                                        CssClass="stdSaveBtn" OnClick="btnSaveDiscription_Click"></cc1:SecButtons></td>
                                            </tr>
                                        </table>
                                        <asp:Label ID="Label2" runat="server" CssClass="formslabels"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="90%">
                            <table height="100%" cellspacing="5" cellpadding="5" width="100%" border="0">
                                <tr>
                                    <td class="headertd" style="height: 13px">
                                        <font size="2">Team Members</font></td>
                                </tr>
                                <tr>
                                    <td class="whitetd" valign="top" height="100%">
                                        <table id="Table2" cellspacing="1" cellpadding="1" width="100%" border="0" class="FunctionBlock">
                                            <tr>
                                                <td style="height: 292px">
                                                </td>
                                                <td id="tdTeamsMembers" style="height: 292px" valign="top" align="left" height="292">
                                                    <div style="overflow: auto; height: 150px" onload="SetHeight();">
                                                        <asp:DataGrid ID="dgTeamMembers" runat="server" BorderColor="White" Width="100%"
                                                            AutoGenerateColumns="False" DataMember="GEN_Employees" DataSource="<%# dsEmployee1 %>"
                                                            BorderStyle="None" BorderWidth="1px" CellPadding="2">
                                                            <SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99"></SelectedItemStyle>
                                                            <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                                                            <ItemStyle CssClass="bsnormaltd"></ItemStyle>
                                                            <HeaderStyle Font-Bold="True" CssClass="whitetd"></HeaderStyle>
                                                            <Columns>
                                                                <asp:BoundColumn DataField="Fullname" SortExpression="Fullname" HeaderText="Employee Name">
                                                                    <HeaderStyle Width="95%"></HeaderStyle>
                                                                </asp:BoundColumn>
                                                                <asp:TemplateColumn HeaderText="Select">
                                                                    <HeaderStyle Width="5%"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:BoundColumn Visible="False" DataField="EmployeeStatus" SortExpression="EmployeeStatus"
                                                                    HeaderText="EmployeeStatus"></asp:BoundColumn>
                                                            </Columns>
                                                            <PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
                                                        </asp:DataGrid></div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 32px">
                                                </td>
                                                <td align="center" style="height: 32px">
                                                    <cc1:SecButtons ID="btnAddEmployee" runat="server" ToolTip="Add Employee To The Team"
                                                        CausesValidation="False" RuleID="5097" CssClass="stdAddBtn" OnClick="btnAddEmployee_Click">
                                                    </cc1:SecButtons>&nbsp;&nbsp;
                                                    <cc1:SecButtons ID="btnRemoveEmployee" runat="server" ToolTip="Remove Selected Employees"
                                                        CausesValidation="False" RuleID="5098" CssClass="stdRemovebtn" OnClick="btnRemoveEmployee_Click">
                                                    </cc1:SecButtons></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="Panel2" Height="124px" runat="server" Visible="False">
    <table cellspacing="5" cellpadding="5" width="486" align="center" border="0" class="FunctionBlock">
        <tr>
            <td class="headertd">
                Create new team
            </td>
        </tr>
        <tr>
            <td class="whitetd" style="height: 20px">
                <table id="Table3" cellspacing="1" cellpadding="1" width="457" border="0" class="FunctionBlock">
                    <tr>
                        <td style="height: 24px" align="right">
                            <font size="2">* Team Name</font></td>
                        <td style="height: 24px" align="left">
                            <asp:TextBox ID="txtNewTeamName" runat="server" CssClass="inputtext" Width="255px"></asp:TextBox></td>
                        <td style="height: 24px" align="left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="errmsg"
                                ForeColor=" " BackColor="Transparent" ErrorMessage="Required" ControlToValidate="txtNewTeamName">Required</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr style="font-size: 10pt">
                        <td align="right">
                            <font size="2">* Team Leader</font></td>
                        <td align="left">
                            <asp:DropDownList ID="drpNewTeamLeader" runat="server" DataMember="GEN_Employees"
                                DataSource="<%# dsEmployee2 %>" CssClass="inputtext" DataTextField="Fullname"
                                DataValueField="ContactID" Width="256px" OnDataBinding="drpNewTeamLeader_DataBinding">
                            </asp:DropDownList>
                            <img onclick="controlName ='drpNewTeamLeader';openEmpWnd()" alt="Find Employee" src="../Go/images/Buttons/Find_n.jpg" style="height:23px;width:23px;vertical-align:bottom;" /></td>
                        <td align="left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="errmsg"
                                ForeColor=" " BackColor="Transparent" ErrorMessage="Required" ControlToValidate="drpNewTeamLeader">Required</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td valign="top" align="right">
                            <font size="2">Description</font></td>
                        <td align="left" colspan="2">
                            <asp:TextBox ID="txtNewTeamDesc" runat="server" CssClass="inputtext" TextMode="MultiLine"
                                Width="257px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                        <td align="center" colspan="2">
                            <asp:Button ID="NewTeam" runat="server" ToolTip="Create Team" CssClass="stdSavebtn"
                                OnClick="NewTeam_Click"></asp:Button>&nbsp;
                            <asp:Button ID="btnCancel" runat="server" ToolTip="Cancel" CausesValidation="False"
                                CssClass="stdCancelbtn" OnClick="btnCancel_Click"></asp:Button></td>
                    </tr>
                </table>
                <asp:Label ID="Label1" runat="server" CssClass="formslabels"></asp:Label></td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="Panel3" runat="server" Visible="False" Height="600px">
    <table cellspacing="5" cellpadding="5" align="center" border="0" style="width: 361px"  Height="600px">
        <%-- <tr>
            <td class="headertd" style="text-align: left;">
                Add employees to team
            </td>
        </tr>
        <tr style="height:13px;">
            <td class="headertd" style="text-align: left;height:13px;">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" ForeColor="white" RepeatDirection="Horizontal"
                    Font-Bold="False" Font-Names="Tahoma" Font-Size="12px" Font-Underline="True" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatLayout="Flow">
                    <asp:ListItem>First Name</asp:ListItem>
                    <asp:ListItem>Last Name</asp:ListItem>
                </asp:RadioButtonList>&nbsp;
            </td>
        </tr>--%>
        <tr>
            <td class="headertd" style="text-align: left; width: 395px;">
                Add employees to team Sort:<asp:RadioButtonList ID="RadioButtonList1" runat="server"
                    ForeColor="white" RepeatDirection="Horizontal" Font-Bold="False" Font-Names="Tahoma"
                    Font-Size="12px" Font-Underline="True" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                    RepeatLayout="Flow" Width="154px">
                    <asp:ListItem>First Name</asp:ListItem>
                    <asp:ListItem>Last Name</asp:ListItem>
                </asp:RadioButtonList>
                <asp:CheckBox ID="chkSortOrder" runat="server" Text="Desc" ToolTip="Select sord order (if checked the sort order is descending)"
                    AutoPostBack="True" OnCheckedChanged="RadioButtonList1_SelectedIndexChanged" /></td>
        </tr>
        <tr valign=top style="vertical-align:top">
            <td class="whitetd" style="width: 395px; vertical-align:top">
                <table id="Table4" cellspacing="1" cellpadding="1" border="0" designtimedragdrop="863"
                    class="FunctionBlock"  style="vertical-align:top">
                    <tr style="vertical-align:top">
                        <td align="right" style="vertical-align:top">
                            <div  style="overflow: scroll; height: 500px;vertical-align:top" >
                                <asp:DataGrid  ID="dgEmployeeList" runat="server" Height="500px" AutoGenerateColumns="False"
                                    DataMember="GEN_Employees" DataSource="<%# dsEmployee2 %>" BorderStyle="None"
                                    BorderWidth="1px" CellPadding="4" Visible="False" Width="296px"   HorizontalAlign="Center" VerticalAlign="Top">
                                    <SelectedItemStyle Font-Bold="True"></SelectedItemStyle>
                                    <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                                    <ItemStyle CssClass="bsnormaltd"></ItemStyle>
                                    <HeaderStyle Font-Bold="True" CssClass="whitetd"></HeaderStyle>
                                    <Columns>
                                        <asp:BoundColumn Visible="False" DataField="ContactID" SortExpression="ContactID"
                                            HeaderText="ContactID">
                                            <HeaderStyle Width="90%"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Fullname" SortExpression="Fullname" HeaderText="Full Name">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:TemplateColumn HeaderText="Select">
                                            <HeaderStyle Width="10%"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox3" runat="server"></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                    </Columns>
                                    <PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
                                </asp:DataGrid></div>
                        </td>
                    </tr>
                    <tr style="vertical-align:top">
                        <td align="center" style="vertical-align:top">
                            <asp:Button ID="btnAddEmp" runat="server" ToolTip="Add Employee" CausesValidation="False"
                                CssClass="stdNewBtn" OnClick="btnAddEmp_Click"></asp:Button>&nbsp;&nbsp;
                            <asp:Button ID="btnCancelAddEmp" runat="server" ToolTip="Back" CausesValidation="False"
                                CssClass="stdcancelbtn" OnClick="btnCancelAddEmp_Click"></asp:Button></td>
                    </tr>
                </table>
                <asp:Label ID="lblAdded" runat="server" ForeColor="Black" Width="296px" Font-Bold="True"></asp:Label></td>
        </tr>
    </table>
</asp:Panel>

<script language="javascript">
function SetHeight()
{
	if(screen.height == 1024)
		{
			document.getElementById('tdTeams').height = 650;
			document.getElementById('tdTeamsMembers').height = 450;
		}
	else if(screen.height == 768)
		{
			document.getElementById('tdTeams').height = 440;
			document.getElementById('tdTeamsMembers').height = 200;
		}
}
</script>

