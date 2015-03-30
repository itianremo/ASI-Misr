<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation" %>
<%@ Register TagPrefix="cc2" Namespace="TSN.ERP.WebGUI.Navigation2" %>
<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.Go.ProjectsList" CodeFile="ProjectsList.ascx.cs" %>
<link href="../Acc1.css" type="text/css" rel="stylesheet">
<meta content="False" name="vs_snapToGrid" />

<script language="javascript">
function setEntityIDSession( id )
{
	alert( id );
	ProjectsList.settingEntityID(id).value;
}
</script>

<table border="0" cellpadding="0" cellspacing="0" class="ToolBar" width="100%" style="margin: 0px;">
    <tr>
        <td style="width: 121px">
            <asp:RadioButtonList ID="rblActiveProjects" runat="server" AutoPostBack="True" Font-Bold="False"
                Font-Size="X-Small" RepeatDirection="Horizontal" RepeatLayout="Flow" OnSelectedIndexChanged="rblActiveProjects_SelectedIndexChanged" ToolTip="Project Status">
                <asp:ListItem Selected="True" Value="1">Active</asp:ListItem>
                <asp:ListItem Value="0">All</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            <cc2:SecImageButtons ID="btnNew" runat="server" RuleID="5001" CausesValidation="False"
                ToolTip="Add New Project" OnClick="btnNew_Click" ImageUrl="~/Go/images/Buttons/AddProject_n.jpg"
                onmouseover="this.src='../Go/images/Buttons/AddProject_o.jpg'" onmouseout="this.src='../Go/images/Buttons/AddProject_n.jpg'"
                onmousedown="this.src='../Go/images/Buttons/AddProject_s.jpg'"></cc2:SecImageButtons>
            <cc2:SecImageButtons ID="btnDelete" runat="server" RuleID="1006" CausesValidation="False"
                ToolTip="Delete selected projects" OnClick="btnDelete_Click" ImageUrl="~/Go/images/Buttons/DeleteProject_n.jpg"
                onmouseover="this.src='../Go/images/Buttons/DeleteProject_o.jpg'" onmouseout="this.src='../Go/images/Buttons/DeleteProject_n.jpg'"
                onmousedown="this.src='../Go/images/Buttons/DeleteProject_s.jpg'"></cc2:SecImageButtons>
        </td>
    </tr>
</table>
<asp:Panel ID="pnlProjectList" runat="server" Style="background: #C2CCD8">
    <table id="Table1" cellspacing="5" cellpadding="10" width="666" align="center" border="0">
        <tr>
            <td class="errtable" align="center">
                <asp:Table ID="tblErr" runat="server" HorizontalAlign="Center" Font-Size="9pt" Font-Names="Arial"
                    CellSpacing="0" Visible="False" CssClass="errtable" BorderWidth="0px" CellPadding="2"
                    ForeColor="Red">
                    <asp:TableRow VerticalAlign="Top" runat="server">
                        <asp:TableCell BackColor="#FFFFC0" BorderColor="White" Text="&lt;img src=&quot;../go/images/alrt_l.gif&quot; /&gt;"
                            runat="server"></asp:TableCell>
                        <asp:TableCell BackColor="#FFFFC0" Text="
							&lt;p class=&quot;MsoNormal&quot;&gt;Project wasn’t deleted, this maybe caused by one of the 
								following reasons:&lt;/p&gt;
							&lt;ul style='margin-top:0cm' type=&quot;disc&quot;&gt;
								&lt;li class=&quot;MsoNormal&quot; style='mso-list:l0 level1 lfo1;tab-stops:list 36.0pt'&gt;
									Project might have tasks added to it
								&lt;/li&gt;
								&lt;li class=&quot;MsoNormal&quot; style='mso-list:l0 level1 lfo1;tab-stops:list 36.0pt'&gt;
									Project might have Employees added to it&lt;/li&gt;
							&lt;/ul&gt;
							&lt;p class=&quot;MsoNormal&quot;&gt;
								&lt;o:p&gt;&amp;nbsp;&lt;/o:p&gt;&lt;/p&gt;
						" runat="server"></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </td>
        </tr>
        <tr>
            <td class="headertd" align="center">
                Projects</td>
        </tr>
        <tr>
            <td class="FunctionBlock" valign="top" height="100%">
                <div align="left">
                    <table style="width: 100%" cellspacing="0" border="0" class="whitetd">
                        <tr>
                            <td style="width: 7%; height: 15px;" valign="middle" align="center">
                                Select
                            </td>
                            <td style="width: 39%; height: 15px;" valign="middle" align="center">
                                Project
                            </td>
                            <td style="width: 11%; height: 15px;" valign="middle" align="center">
                                Delivery
                            </td>
                            <td style="width: 11%; height: 15px;" valign="middle" align="center">
                                Complete
                            </td>
                            <td style="width: 32%; height: 15px;" valign="middle" align="center">
                                Parent
                            </td>
                            
                            <%--<td style="width: 4%; height: 15px;" valign="middle" align="center">
                                ID
                            </td>--%>
                        </tr>
                    </table>
                </div>
                <div style="overflow: auto; width: 100%; height: 508px" align="left">
                    <asp:DataGrid ID="dgProjectList" runat="server" BorderWidth="1px" CellPadding="2" 
                        BorderColor="Black" DataSource="<%# dsProjects1 %>" DataMember="GEN_Projects"
                        AutoGenerateColumns="False" BorderStyle="Solid" Width="100%" ShowHeader="False">
                        <FooterStyle CssClass="bsFootertd"></FooterStyle>
                        <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                        <ItemStyle CssClass="bsnormaltd"></ItemStyle>
                        <HeaderStyle CssClass="headertd"></HeaderStyle>
                        <Columns>
                           <asp:TemplateColumn HeaderText="Select">
                                <HeaderStyle Width="7%"></HeaderStyle>
                                <ItemStyle Wrap="False" HorizontalAlign="Center" Width="7%" VerticalAlign="Middle"
                                    BorderColor="Black"></ItemStyle>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" Width="20px"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Project">
                                <HeaderStyle Width="39%"></HeaderStyle>
                                <ItemStyle Wrap="False" HorizontalAlign="Left" Width="39%" VerticalAlign="Middle"
                                    BorderColor="Black"></ItemStyle>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" OnClick="LoadProjectByID" runat="server" CssClass="gridLink"
                                        Width="76px" CausesValidation="False" Text='<%# DataBinder.Eval(Container, "DataItem.ProjectName")%>'
                                        CommandName="Select">
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="ProjectTargetDate" SortExpression="ProjectTargetDate"
                                HeaderText="Delivery" DataFormatString="{0:d}">
                                <HeaderStyle Width="11%"></HeaderStyle>
                                <ItemStyle Wrap="False" HorizontalAlign="Center" Width="11%" VerticalAlign="Middle"
                                    BorderColor="Black"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ProjectCompleteDate" SortExpression="ProjectCompleteDate"
                                HeaderText="Complete" DataFormatString="{0:d}">
                                <HeaderStyle Width="11%"></HeaderStyle>
                                <ItemStyle Wrap="False" HorizontalAlign="Center" Width="11%" VerticalAlign="Middle"
                                    BorderColor="Black"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Parent">
                                <HeaderStyle Width="28%"></HeaderStyle>
                                <ItemStyle Wrap="False" HorizontalAlign="Left" Width="32%" VerticalAlign="Middle"
                                    BorderColor="Black"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" ForeColor="Black"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            
                            <asp:BoundColumn Visible="False" DataField="ProjectParentID" SortExpression="ProjectParentID"
                                HeaderText="ProjectParentID">
                                <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle" BorderColor="Black">
                                </ItemStyle>
                            </asp:BoundColumn>
                             <asp:BoundColumn Visible="False" DataField="projectID" SortExpression="projectID"  HeaderText="ID">
                                <HeaderStyle Width="4%"></HeaderStyle>
                                <ItemStyle Wrap="False"  HorizontalAlign="Left" Width="4%" VerticalAlign="Middle"
                                    BorderColor="Black"></ItemStyle>
                            </asp:BoundColumn>
                        </Columns>
                        <PagerStyle HorizontalAlign="Left" CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid></div>
            </td>
        </tr>
        <tr>
            <td style="height: 38px">
            </td>
        </tr>
        <tr>
            <td align="center" dir="ltr">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" style="height: 39px">
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="pnlNewProject" runat="server" Visible="False" Style="background: #C2CCD8">
    <table style="border-collapse: collapse" height="95%" cellspacing="0" cellpadding="0"
        width="100%" align="center" border="0">
        <tr>
            <td style="height: 269px" colspan="2">
                <table cellspacing="5" cellpadding="5" width="100%" border="0">
                    <tr>
                        <td class="headertd">
                            <strong><font class="headerFont" color="#ffffff" size="2">Project Details</font></strong></td>
                    </tr>
                    <tr>
                        <td class="whitetd" align="left">
                            <table id="Table2" cellspacing="1" cellpadding="1" width="100%" border="0" runat="server"
                                class="FunctionBlock">
                                <tr>
                                    <td width="135">
                                    </td>
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formslabels" align="right">
                                        Project Name</td>
                                    <td style="width: 429px" width="429">
                                        <asp:TextBox ID="txtProjectName" runat="server" CssClass="inputtext" Width="437px"
                                            MaxLength="60"></asp:TextBox></td>
                                    <td width="280">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formslabels" style="height: 18px" align="right">
                                        Project Manager</td>
                                    <td style="width: 429px; height: 18px">
                                        <asp:DropDownList ID="drpManagerList" runat="server" CssClass="inputtext" DataSource="<%# dataView1 %>"
                                            Width="263px" DataTextField="Fullname" DataValueField="ContactID">
                                        </asp:DropDownList>
                                        <img id="IMG2" onclick="controlName ='drpManagerList'; openEmpWnd2()" alt="Find Employee"
                                            src="images/Buttons/Find_n.jpg" runat="server" class="stdFindBtn" style="vertical-align: top;
                                            height: 23px;" width="21" />
                                    </td>
                                    <td style="height: 18px">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formslabels" align="right">
                                        Delivery Date</td>
                                    <td style="width: 429px">
                                        <asp:TextBox ID="txtDeliverDate" runat="server" CssClass="inputtext" Width="150px"></asp:TextBox>&nbsp;
                                        <dlcalendar tool_tip="Pick a Date" click_element_id="imgCal1" input_element_id="_ctl0_txtDeliverDate"
                                            firstday="Su"></dlcalendar>
                                        <img id="imgCal1" alt="Pick a Date" src="../go/images/dlcalendar_1.gif" />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formslabels" align="right">
                                        Critical Date</td>
                                    <td style="width: 429px">
                                        <asp:TextBox ID="txtCriticalDate" runat="server" CssClass="inputtext" Width="150px"></asp:TextBox>&nbsp;
                                        <dlcalendar tool_tip="Pick a Date" click_element_id="imgCal2" input_element_id="_ctl0_txtCriticalDate"
                                            firstday="Su"></dlcalendar>
                                        <img id="imgCal2" alt="Pick a Date" src="../go/images/dlcalendar_1.gif" />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3" style="height: 28px">
                                        <cc1:SecButtons ID="ButtonAddProject" runat="server" CssClass="stdSavebtn" RuleID="5001"
                                            CausesValidation="False" ToolTip="Add New Project" OnClick="ButtonAddProject_Click">
                                        </cc1:SecButtons>&nbsp;
                                        <cc1:SecButtons ID="ButtonUpdateProject" runat="server" CssClass="stdSavebtn" RuleID="1004"
                                            CausesValidation="False" ToolTip="Update Project Data" OnClick="ButtonUpdateProject_Click">
                                        </cc1:SecButtons>&nbsp;
                                        <cc1:SecButtons ID="btnCompleteProject" runat="server" CssClass="stdCompletebtn"
                                            RuleID="1009" CausesValidation="False" ToolTip="Complete Project" OnClick="btnCompleteProject_Click">
                                        </cc1:SecButtons>&nbsp;
                                        <asp:Button ID="btnCancel" runat="server" CssClass="stdCancelbtn" CausesValidation="False"
                                            ToolTip="Back" OnClick="btnCancel_Click"></asp:Button></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtCurrentDate" runat="server" Visible="False"></asp:TextBox></td>
                                </tr>
                            </table>
                            <asp:Label ID="lblMSG" runat="server" CssClass="formslabels"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top" width="50%" height="100%">
                <asp:Panel ID="pnlTasks" runat="server" Visible="true" Height="504px">
                    <table style="width: 619px; height: 512px" height="512" cellspacing="5" cellpadding="5"
                        width="619" border="0">
                        <tr>
                            <td class="headertd">
                                <font color="#ffffff" size="2"><strong class="headerFont">Projects Tasks</strong></font></td>
                        </tr>
                        <tr>
                            <td class="whitetd" valign="top" height="100%">
                                <table id="Table3" style="width: 596px; height: 456px" cellspacing="1" cellpadding="1"
                                    width="596" border="0" runat="server" class="FunctionBlock">
                                    <tr style="width: 100%">
                                        <td id="tdProjectTasks" style="width: 100%; height: 393px" colspan="2">
                                            <div style="width: 100%">
                                                <table cellspacing="0" width="100%" border="0" class="whitetd">
                                                    <tr>
                                                        <%--<td style="width: 8%" valign="middle" align="center">ID</td>--%>
                                                        <td style="width: 70%" valign="middle" align="center">
                                                            Task</td>
                                                        <td style="width: 15%" valign="middle" align="center">
                                                            Status</td>
                                                        <td style="width: 10%" valign="middle" align="center">
                                                            Select</td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div style="overflow: auto; width: 100%; height: 208px">
                                                <asp:DataGrid ID="dgProjectTasks" runat="server" Visible="False" BorderWidth="1px"
                                                    CellPadding="1" BorderColor="White" DataSource="<%# dsTasks1 %>" DataMember="GEN_Tasks"
                                                    AutoGenerateColumns="False" BorderStyle="None" Width="100%" ShowHeader="False" OnItemDataBound="dgProjectTasks_ItemDataBound">
                                                    <SelectedItemStyle HorizontalAlign="Left" CssClass="orangetd" VerticalAlign="Middle">
                                                    </SelectedItemStyle>
                                                    <EditItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></EditItemStyle>
                                                    <AlternatingItemStyle HorizontalAlign="Left" CssClass="bsalternativetd" VerticalAlign="Middle">
                                                    </AlternatingItemStyle>
                                                    <ItemStyle HorizontalAlign="Left" CssClass="bsnormaltd" VerticalAlign="Middle"></ItemStyle>
                                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" CssClass="headertd" VerticalAlign="Middle">
                                                    </HeaderStyle>
                                                    <Columns>
                                                        <asp:BoundColumn DataField="TaskID" SortExpression="TaskID" HeaderText="ID">
                                                            <HeaderStyle HorizontalAlign="Left" Width="8%" VerticalAlign="Middle"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="8%"></ItemStyle>
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="8%"></FooterStyle>
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="TaskName" SortExpression="TaskName" HeaderText="Task">
                                                            <HeaderStyle HorizontalAlign="Left" Width="71%" VerticalAlign="Middle"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="71%"></ItemStyle>
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="71%"></FooterStyle>
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn Visible="False" DataField="TaskCreatBy" SortExpression="TaskCreatBy"
                                                            HeaderText="By">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn Visible="False" DataField="TaskStatus" SortExpression="TaskStatus"
                                                            HeaderText="Task Status">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn HeaderText="Status">
                                                            <HeaderStyle HorizontalAlign="Left" Width="15%" VerticalAlign="Middle"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15%"></ItemStyle>
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="15%"></FooterStyle>
                                                        </asp:BoundColumn>
                                                        <asp:TemplateColumn HeaderText="Select">
                                                            <HeaderStyle HorizontalAlign="Left" Width="10%" VerticalAlign="Middle"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="SelectTask" runat="server" Width="2px"></asp:CheckBox>
                                                            </ItemTemplate>
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%"></FooterStyle>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                    <PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
                                                </asp:DataGrid></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <cc1:SecButtons ID="ButtonCmpTsk" runat="server" CssClass="stdCompleteBtn" RuleID="5086"
                                                CausesValidation="False" ToolTip="Complete" OnClick="btnCompleteTask_Click"></cc1:SecButtons>&nbsp;
                                            <cc1:SecButtons ID="SecButtonsNewTsk" runat="server" CssClass="stdNewBtn" RuleID="1003"
                                                CausesValidation="False" ToolTip="New Task" OnClick="btnNewTask_Click"></cc1:SecButtons>&nbsp;
                                            <cc1:SecButtons ID="SecButtonsEditTsk" runat="server" CssClass="stdEditbtn" RuleID="5080"
                                                CausesValidation="False" ToolTip="Edit Task" OnClick="btnEditTask_Click"></cc1:SecButtons>&nbsp;
                                            <cc1:SecButtons ID="SecButtonsDeleteTsk" runat="server" CssClass="stdDeleteBtn" RuleID="5081"
                                                CausesValidation="False" ToolTip="Delete Task" OnClick="btnDeleteTask_Click"></cc1:SecButtons></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td valign="top" width="50%" height="100%">
                <asp:Panel ID="pnlEmp" runat="server" Visible="true">
                    <table height="100%" cellspacing="5" cellpadding="5" width="100%" border="0">
                        <tr>
                            <td class="headertd">
                                <font color="#ffffff" size="2"><strong class="headerFont">Project Employees</strong></font></td>
                        </tr>
                        <tr>
                            <td class="whitetd" valign="top" height="100%">
                                <table id="Table4" cellspacing="1" cellpadding="1" width="100%" border="0" runat="server"
                                    class="FunctionBlock">
                                    <tr>
                                        <td valign="top" align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" align="left">
                                            <asp:Label ID="lblAssignEmp" runat="server" CssClass="formslabels">Assign Employee To This Project </asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 25px" valign="top" align="left">
                                            <p>
                                                <asp:DropDownList ID="drpEmployeesList" runat="server" CssClass="inputtext" DataSource="<%# dataView1 %>"
                                                    Width="240px" DataTextField="Fullname" DataValueField="ContactID">
                                                </asp:DropDownList>
                                                <img id="IMG1" onclick="controlName ='drpEmployeesList'; openEmpWnd2()" height="26"
                                                    width="26" alt="Find Employee" src="images/Buttons/Find_n.jpg" runat="server"
                                                    style="vertical-align: bottom;" />
                                                <cc1:SecButtons ID="SecButtAddEmpToPrj" runat="server" CssClass="stdaddbtn" RuleID="1010"
                                                    CausesValidation="False" ToolTip="Add selected Employee to project" OnClick="btnAddEmp_Click">
                                                </cc1:SecButtons>
                                                <cc1:SecButtons ID="btnRemoveEmp" runat="server" CssClass="stdRemovebtn" RuleID="1011"
                                                    CausesValidation="False" ToolTip="Remove Employee from project" OnClick="btnRemoveEmp_Click">
                                                </cc1:SecButtons></p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 25px" valign="top" align="left">
                                            <asp:Label ID="lblmsgAssaign" runat="server" CssClass="formslabels"></asp:Label></td>
                                    </tr>
                                    <tr style="width: 100%">
                                        <td id="tdAssTasks" style="width: 100%" valign="top" align="center" height="345">
                                            <div>
                                                <table style="width: 100%" cellspacing="0" border="0" class="whitetd">
                                                    <tr>
                                                        <td style="width: 8%; height: 15px;" valign="middle" align="center">
                                                            Code</td>
                                                        <td style="width: 41%; height: 15px;" valign="middle" align="center">
                                                            Name</td>
                                                        <td style="width: 41%; height: 15px;" valign="middle" align="center">
                                                            Job Title</td>
                                                        <td style="width: 10%; height: 15px;" valign="middle" align="center">
                                                            Select</td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div style="overflow: auto; width: 100%; height: 250px">
                                                <asp:DataGrid ID="dgAssignedEmp" runat="server" Visible="False" BorderWidth="1px"
                                                    CellPadding="2" BorderColor="White" DataSource="<%# dsEmployee1 %>" DataMember="GEN_Employees"
                                                    AutoGenerateColumns="False" BorderStyle="None" Width="100%" ShowHeader="False" OnItemDataBound="dgAssignedEmp_ItemDataBound">
                                                    <SelectedItemStyle Font-Bold="True"></SelectedItemStyle>
                                                    <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                                                    <ItemStyle CssClass="bsnormaltd"></ItemStyle>
                                                    <HeaderStyle Font-Bold="True" CssClass="headertd"></HeaderStyle>
                                                    <Columns>
                                                        <asp:BoundColumn DataField="EmpCode" SortExpression="EmpCode" HeaderText="Code">
                                                            <HeaderStyle Width="8%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="8%" VerticalAlign="Middle"></ItemStyle>
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Fullname" SortExpression="Fullname" HeaderText="Name">
                                                            <HeaderStyle Width="41%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="41%" VerticalAlign="Middle"></ItemStyle>
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="JobTitleID" SortExpression="JobTitleID" HeaderText="Job Name">
                                                            <HeaderStyle Width="41%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="41%" VerticalAlign="Middle"></ItemStyle>
                                                        </asp:BoundColumn>
                                                        <asp:TemplateColumn HeaderText="Select">
                                                            <HeaderStyle Width="10%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="10%" VerticalAlign="Middle"></ItemStyle>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="chkHeader" runat="server" AutoPostBack="True" OnCheckedChanged="chkHeader_CheckedChanged">
                                                                </asp:CheckBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="SelectEmployee" runat="server"></asp:CheckBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:BoundColumn Visible="False" DataField="ContactID" SortExpression="ContactID"
                                                            HeaderText="ContactID"></asp:BoundColumn>
                                                        <asp:BoundColumn Visible="False" DataField="JobTitleID" SortExpression="JobTitleID"
                                                            HeaderText="JobTitleID"></asp:BoundColumn>
                                                        <asp:BoundColumn Visible="False" DataField="EmployeeStatus" SortExpression="EmployeeStatus"
                                                            HeaderText="EmployeeStatus"></asp:BoundColumn>
                                                    </Columns>
                                                    <PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
                                                </asp:DataGrid></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 25px" valign="middle" align="center">
                                            <asp:Button ID="btnAssignTaskToEmp" runat="server" CssClass="slectedbutton" Width="172px"
                                                CausesValidation="False" Text="Manage Employee Tasks" OnClick="btnAssignTaskToEmp_Click">
                                            </asp:Button>&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" align="left">
                                            &nbsp;&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Panel>
<%--</TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>--%>

<script language="javascript" type="text/javascript">
if(screen.height == 1024)
	{
	//document.getElementById('_ctl0_tdProjectTasks').height = 440;
	//document.getElementById('_ctl0_tdAssTasks').height = 385;
	}
else if(screen.height == 768)
	{
	//document.getElementById('_ctl0_tdProjectTasks').height = 200;
	//document.getElementById('_ctl0_tdAssTasks').height = 145;
	}
</script>

