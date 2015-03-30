<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default8.aspx.cs" Inherits="ConfigData_Default8" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="SignOut" onclick="Button1_Click" /><br />
        <br />
        <b>GNR_GeneralCode</b>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="GID" 
            DataSourceID="odcGNR_GeneralCode" EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="GID" HeaderText="GID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="GID" />
                <asp:BoundField DataField="GeneralCode" HeaderText="GeneralCode" 
                    SortExpression="GeneralCode" />
                <asp:CheckBoxField DataField="Commited" HeaderText="Commited" 
                    SortExpression="Commited" />
                <asp:CheckBoxField DataField="Deleted" HeaderText="Deleted" 
                    SortExpression="Deleted" />
            </Columns>
        </asp:GridView>
        <br />
        <b>GNR_SubCode</b><asp:GridView ID="GridView2" runat="server" 
            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
            DataKeyNames="SID" DataSourceID="odcGNR_SubCode" EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="SID" HeaderText="SID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="SID" />
                <asp:BoundField DataField="SubCode" HeaderText="SubCode" 
                    SortExpression="SubCode" />
                <asp:BoundField DataField="GID" HeaderText="GID" SortExpression="GID" />
                <asp:CheckBoxField DataField="Commited" HeaderText="Commited" 
                    SortExpression="Commited" />
                <asp:CheckBoxField DataField="Deleted" HeaderText="Deleted" 
                    SortExpression="Deleted" />
            </Columns>
        </asp:GridView>

        <asp:ObjectDataSource ID="odcGNR_GeneralCode" runat="server" 
            DeleteMethod="Delete" InsertMethod="Insert" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="AllTablesTableAdapters.GNR_GeneralCodeTableAdapter" 
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_GID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="GeneralCode" Type="String" />
                <asp:Parameter Name="Commited" Type="Boolean" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="GeneralCode" Type="String" />
                <asp:Parameter Name="Commited" Type="Boolean" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
                <asp:Parameter Name="Original_GID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odcGNR_SubCode" runat="server" DeleteMethod="Delete" 
            InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetData" 
            TypeName="AllTablesTableAdapters.GNR_SubCodeTableAdapter" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_SID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="SubCode" Type="String" />
                <asp:Parameter Name="GID" Type="Int32" />
                <asp:Parameter Name="Commited" Type="Boolean" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="SubCode" Type="String" />
                <asp:Parameter Name="GID" Type="Int32" />
                <asp:Parameter Name="Commited" Type="Boolean" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
                <asp:Parameter Name="Original_SID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
