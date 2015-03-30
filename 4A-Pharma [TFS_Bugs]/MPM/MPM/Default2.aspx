<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript">
    function test(v)
    {
    
    };

    function SelectAll() {
        var gv = document.getElementById("GridView1");
        var gvInputs = gv.getElementsByTagName("input");
        var firstChkbx = -1
        var color
        
        for (i=0;i<gvInputs.length;i++)
        {
            if (gvInputs[i].type == "checkbox") 
            {
                if(firstChkbx == -1)
                {
                    firstChkbx = gvInputs[i].checked
                    if(gvInputs[i].checked)
                    {
                        color = '#ffffff'
                    }
                    else
                    {
                        color = '#cccccc'
                    }
                }
                gvInputs[i].checked = !(firstChkbx)
                gvInputs[i].parentElement.parentElement.style.backgroundColor=color; 
            }
        }
    }  
    
    function SelectOne(invoker) {
        var IsChecked = invoker.checked;   
        if(IsChecked)
        {
            //invoker.parentElement.parentElement.style.backgroundColor='#BCC9B7'; 
            var gvInputs = invoker.parentElement.parentElement.getElementsByTagName("input");
            for (i=0;i<gvInputs.length;i++)
            {
                if (gvInputs[i].type == "text") 
                {
                    if (gvInputs[i].value == 0)
                        gvInputs[i].value = 1
                }
            }
        }
        else
        {
            //invoker.parentElement.parentElement.style.backgroundColor='#BCC9B7'; 
            var gvInputs = invoker.parentElement.parentElement.getElementsByTagName("input");
            for (i=0;i<gvInputs.length;i++)
            {
                if (gvInputs[i].type == "text") 
                {
                    gvInputs[i].value = 0
                }
            }
        }   
    }
    
    function SetGridView1BackgroundColor() {
    
        var gv = document.getElementById("GridView1");
        var gvInputs = gv.getElementsByTagName("input");
        alert('f')
        for (i=0;i<gvInputs.length;i++){
            if (gvInputs[i].type == "checkbox"){
                if(gvInputs[i].checked){
                    gvInputs[i].parentElement.parentElement.style.background='#BCC9B7'
                }
                else{
                    gvInputs[i].parentElement.parentElement.style.background='#ffffff'
                }
            }
        }
    }
    </script>
</head>
<body onload="SetGridView1BackgroundColor()">
    <form id="form1" runat="server">
    <asp:DropDownList ID="ddlChartType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlChartType_SelectedIndexChanged">
        <asp:ListItem >Area2D</asp:ListItem>
        <asp:ListItem >Bar2D</asp:ListItem>
        <asp:ListItem >Line2D</asp:ListItem>
    </asp:DropDownList><asp:CheckBox ID="CheckBox1" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div runat="server" id="divScoresChart">
        <asp:LinkButton id="LinkButton1" runat="server" onClientClick="window.open('Default2.aspx');" OnClick="LinkButton1_Click">Open Window</asp:LinkButton>
        <asp:Button ID="Button1" runat="server" OnClientClick="test('r')" OnClick="Button1_Click" Text="Button" CausesValidation="False" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
        <br />
        <br />
        
    </div>
    
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>&nbsp;
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1"
            ErrorMessage="*" ValidationExpression="^(?!((?i)user|superuser|manager|admin|superadmin)$)" EnableClientScript="False"></asp:RegularExpressionValidator>
        <asp:Button ID="Button2" runat="server" Text="Button" CausesValidation="False" OnClick="Button2_Click" />
        <asp:Label ID="Label2" runat="server"></asp:Label>&nbsp;<br />
        <br />
        
        &nbsp;
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <table id="tblBrickSummary" width="100%">
            <tr>
                <td colspan="3" rowspan="3">
                    here<table id="tblinnertblBrickSummary" width="100%">
                        <tr>
                            <td>1 22</td>
                            <td>
                                22222
                            </td>
                            <td>
                                333333
                            </td>
                        </tr>
                        <tr>
                            <td>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="BrickID"
            DataSourceID="ObjectDataSource1" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="BrickID" HeaderText="BrickID" InsertVisible="False" ReadOnly="True"
                    SortExpression="BrickID" />
                <asp:BoundField DataField="BrickName" HeaderText="BrickName" SortExpression="BrickName" />
                <asp:TemplateField HeaderText="Commited" SortExpression="Commited">
                    <EditItemTemplate>
                        <asp:CheckBox ID="cbx" runat="server" Checked='<%# Bind("Commited") %>' />
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="lblCommited" runat="server" Text="Commited" OnClick="SelectAll()"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbxitem" runat="server" Checked='<%# Bind("Commited") %>' OnClick="SelectOne(this)" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:TextBox ID="txt" runat="server">0</asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
            </tr>
            <tr>
            </tr>
        </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetData" TypeName="dsBricksTableAdapters.daBricks">
            <SelectParameters>
                <asp:Parameter DefaultValue="false" Name="ShowAll" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
