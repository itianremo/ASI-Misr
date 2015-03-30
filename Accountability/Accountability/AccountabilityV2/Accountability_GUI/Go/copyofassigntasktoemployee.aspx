<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation" %>

<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.Go.CopyofAssignTaskToEmployee" CodeFile="CopyofAssignTaskToEmployee.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>AssignTaskToEmployee</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Acc1.css" type="text/css" rel="stylesheet">

    <script language="javascript">
		 function Check_UnCheck(SenderCheckBox)
			{
				 var Elements = document.getElementsByTagName("input");				 
				 if(SenderCheckBox.checked == true)
				 {
						for(i=0; i<Elements.length; i++)
						{					
							if(IsCheckBox(Elements[i]) && IsMatch(Elements[i].id))
							{
								Elements[i].checked = false;
				   			}
						}
						SenderCheckBox.checked = true;
				 }
				 else
				 {
					for(i=0; i<Elements.length; i++)
						{					
							if(IsCheckBox(Elements[i]) && IsMatch(Elements[i].id))
							{
								Elements[i].checked = false;
				   			}
						}
					SenderCheckBox.checked = false;
				 }
			}
		var pattern = '^dgEmpResTasks';
		function IsMatch(id)
		{
			var regularExpression = new RegExp(pattern);
			if(id.match(regularExpression))
				return true;
			else
				return false;
		}
		function IsCheckBox(chk)
		{
			if(chk.type == 'checkbox')
				return true;
			else
				return false;
		}
    </script>

</head>
<body>
    <form id="Form1" method="post" runat="server">
        <asp:Panel ID="Panel1" runat="server" Height="488px">
            <p>
                &nbsp;</p>
            <table id="Table1" style="width: 688px; height: 448px" cellspacing="1" cellpadding="1"
                width="688" align="center" border="0">
                <tr class="headertd">
                    <td class="formslabels" align="center" height=23>
                        Managing Assignments for Employee(s)
                    </td>
                </tr>
                <tr>
                    <td class="formslabels" align="center">
                        <table id="Table4" cellspacing="1" cellpadding="1" width="70%" align="center"
                            border="0" class="FunctionBlock">
                            <tr>
                                <td class="headertd" height=23>
                                    Employee(s)&nbsp;Assigned&nbsp;with Same Job Title</td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:DataGrid ID="dgEmployees" runat="server" AutoGenerateColumns="False" Width="384px">
                                        <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                                        <ItemStyle HorizontalAlign="Center" CssClass="bsnormaltd"></ItemStyle>
                                        <HeaderStyle CssClass="whitetd"></HeaderStyle>
                                        <Columns>
                                            <asp:BoundColumn DataField="Name" HeaderText="Employee Name"></asp:BoundColumn>
                                            <asp:BoundColumn Visible="False" DataField="ID" HeaderText="EmpCode"></asp:BoundColumn>
                                        </Columns>
                                    </asp:DataGrid></td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 384px; height: 1px" valign="top" align="left">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 384px; height: 292px" valign="top" align="left">
                        <table class="FunctionBlock" id="Table2" style="width: 686px; height: 252px" cellspacing="1"
                            cellpadding="1" width="686" border="0">
                            <tr>
                                <td class="headertd" style="height: 23px">
                                    Employee Responsibilities &amp; Tasks
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:DataGrid ID="dgEmpResTasks" runat="server" AutoGenerateColumns="False" Width="384px"
                                        DataKeyField="RecoredType" DataMember="EmpAccSheet" DataSource="<%# dvEmpAccSheet %>"
                                        CellPadding="4" BorderWidth="1px" BorderStyle="None">
                                        <SelectedItemStyle Font-Bold="True"></SelectedItemStyle>
                                        <ItemStyle Font-Names="sans-serif" CssClass="bsnormaltd"></ItemStyle>
                                        <HeaderStyle Font-Bold="True" CssClass="whitetd"></HeaderStyle>
                                        <Columns>
                                            <asp:BoundColumn DataField="Taskpriority" SortExpression="Taskpriority" HeaderText="Priority">
                                                <HeaderStyle Width="5%"></HeaderStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="taskname" SortExpression="taskname" HeaderText="Responsibility">
                                                <HeaderStyle Width="95%"></HeaderStyle>
                                            </asp:BoundColumn>
                                            <asp:TemplateColumn HeaderText="Select">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" Visible="true" onclick="Check_UnCheck(this)">
                                                    </asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:BoundColumn Visible="False" DataField="StrongID" SortExpression="StrongID" HeaderText="StrongID">
                                            </asp:BoundColumn>
                                            <asp:BoundColumn Visible="False" DataField="RecoredType" SortExpression="RecoredType"
                                                HeaderText="RecoredType"></asp:BoundColumn>
                                            <asp:BoundColumn Visible="False" DataField="AssStatus" SortExpression="AssStatus"
                                                HeaderText="AssStatus"></asp:BoundColumn>
                                        </Columns>
                                        <PagerStyle HorizontalAlign="Left" Mode="NumericPages"></PagerStyle>
                                        <AlternatingItemStyle CssClass="bsalternativetd" />
                                    </asp:DataGrid></td>
                            </tr>
                            <tr>
                                <td align=center>
                                    <cc1:SecButtons ID="btnCompleteTask" runat="server" ToolTip="Complete Task" CssClass="stdCompletebtn"
                                        OnClick="btnCompleteTask_Click"></cc1:SecButtons>&nbsp;
                                    <cc1:SecButtons ID="btnRemoveTask" runat="server" ToolTip="Close/ Delete Task" CssClass="stdDeleteBtn"
                                        OnClick="btnRemoveTask_Click"></cc1:SecButtons>&nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 384px; height: 264px" valign="top" align="left">
                        <table class="FunctionBlock" id="Table3" style="width: 689px; height: 244px" cellspacing="1"
                            cellpadding="1" width="689" border="0">
                            <tr>
                                <td class="headertd" height=23>
                                    Project Tasks</td>
                            </tr>
                            <tr>
                                <td align="center" >
                                    <asp:DataGrid ID="dgProjectTasks" runat="server" AutoGenerateColumns="False" Width="384px"
                                        DataMember="GEN_Tasks" DataSource="<%# dsTasks1 %>" CellPadding="4" BorderWidth="1px"
                                        BorderStyle="None" OnItemDataBound="dgProjectTasks_ItemDataBound">
                                        <SelectedItemStyle Font-Bold="True"></SelectedItemStyle>
                                        <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                                        <ItemStyle CssClass="bsnormaltd"></ItemStyle>
                                        <HeaderStyle Font-Bold="True" CssClass="whitetd"></HeaderStyle>
                                        <Columns>
                                            <asp:BoundColumn DataField="TaskID" SortExpression="TaskID" HeaderText="ID">
                                                <HeaderStyle Width="15%"></HeaderStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="TaskName" SortExpression="TaskName" HeaderText="Task">
                                                <HeaderStyle Width="75%"></HeaderStyle>
                                            </asp:BoundColumn>
                                            <asp:TemplateColumn Visible="False" HeaderText="By">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TaskCreatBy") %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TaskCreatBy") %>'>
                                                    </asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Select">
                                                <HeaderStyle Width="10%"></HeaderStyle>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkHeader" runat="server" AutoPostBack="True" OnCheckedChanged="chkHeader_CheckedChanged">
                                                    </asp:CheckBox>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="SelectTask" runat="server"></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:BoundColumn Visible="False" DataField="TaskStatus" SortExpression="TaskStatus"
                                                HeaderText="TaskStatus"></asp:BoundColumn>
                                        </Columns>
                                        <PagerStyle HorizontalAlign="Left" Mode="NumericPages"></PagerStyle>
                                    </asp:DataGrid></td>
                            </tr>
                            <tr>
                                <td style="height: 21px" align=center>
                                    <cc1:SecButtons ID="btnAssign" runat="server" Width="195px" CssClass="slectedbutton"
                                        Text="Assign Task To Employee" OnClick="btnAssign_Click"></cc1:SecButtons>&nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnCancel" runat="server" ToolTip="Back" CssClass="stdCancelBtn"
                            OnClick="btnCancel_Click"></asp:Button></td>
                </tr>
            </table>
        </asp:Panel>
        &nbsp;</form>
</body>
</html>
