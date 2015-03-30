<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default1.aspx.cs" Inherits="ConfigData_Default1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="SignOut" onclick="Button1_Click" /><br />
        <b>Aspnet_Roles</b><asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" 
            DataKeyNames="ApplicationId,LoweredRoleName" DataSourceID="odcAspnet_Roles" 
            EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="ApplicationId" HeaderText="ApplicationId" 
                    ReadOnly="True" SortExpression="ApplicationId" />
                <asp:BoundField DataField="RoleId" HeaderText="RoleId" 
                    SortExpression="RoleId" />
                <asp:BoundField DataField="RoleName" HeaderText="RoleName" 
                    SortExpression="RoleName" />
                <asp:BoundField DataField="LoweredRoleName" HeaderText="LoweredRoleName" 
                    ReadOnly="True" SortExpression="LoweredRoleName" />
                <asp:BoundField DataField="Description" HeaderText="Description" 
                    SortExpression="Description" />
            </Columns>
        </asp:GridView>
        <br />
        <b>Aspnet_Users</b><asp:GridView ID="GridView2" runat="server" 
            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
            DataKeyNames="ApplicationId,LoweredUserName" DataSourceID="odcAspnet_Users" 
            EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="ApplicationId" HeaderText="ApplicationId" 
                    ReadOnly="True" SortExpression="ApplicationId" />
                <asp:BoundField DataField="UserId" HeaderText="UserId" 
                    SortExpression="UserId" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" 
                    SortExpression="UserName" />
                <asp:BoundField DataField="LoweredUserName" HeaderText="LoweredUserName" 
                    ReadOnly="True" SortExpression="LoweredUserName" />
                <asp:BoundField DataField="MobileAlias" HeaderText="MobileAlias" 
                    SortExpression="MobileAlias" />
                <asp:CheckBoxField DataField="IsAnonymous" HeaderText="IsAnonymous" 
                    SortExpression="IsAnonymous" />
                <asp:BoundField DataField="LastActivityDate" HeaderText="LastActivityDate" 
                    SortExpression="LastActivityDate" />
            </Columns>
        </asp:GridView>
        <br />
        <b>Aspnet_UsersInRoles</b><asp:GridView ID="GridView3" runat="server" 
            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
            DataKeyNames="UserId,RoleId" DataSourceID="odcAspnet_UsersInRoles" 
            EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="UserId" HeaderText="UserId" ReadOnly="True" 
                    SortExpression="UserId" />
                <asp:BoundField DataField="RoleId" HeaderText="RoleId" ReadOnly="True" 
                    SortExpression="RoleId" />
            </Columns>
        </asp:GridView>
        <br />
        <b>BMD_Bricks</b><asp:GridView ID="GridView4" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="BrickID" 
            DataSourceID="odcBMD_Bricks" EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="BrickID" HeaderText="BrickID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="BrickID" />
                <asp:BoundField DataField="BrickName" HeaderText="BrickName" 
                    SortExpression="BrickName" />
                <asp:CheckBoxField DataField="Commited" HeaderText="Commited" 
                    SortExpression="Commited" />
                <asp:CheckBoxField DataField="Deleted" HeaderText="Deleted" 
                    SortExpression="Deleted" />
                <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" 
                    SortExpression="CreatedDate" />
                <asp:BoundField DataField="ModifiedDate" HeaderText="ModifiedDate" 
                    SortExpression="ModifiedDate" />
            </Columns>
        </asp:GridView>

        <asp:ObjectDataSource ID="odcAspnet_Roles" runat="server" DeleteMethod="Delete" 
                    InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
                    SelectMethod="GetData" 
                    TypeName="AllTablesTableAdapters.aspnet_RolesTableAdapter" 
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter DbType="Guid" Name="Original_ApplicationId" />
                        <asp:Parameter Name="Original_LoweredRoleName" Type="String" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter DbType="Guid" Name="ApplicationId" />
                        <asp:Parameter DbType="Guid" Name="RoleId" />
                        <asp:Parameter Name="RoleName" Type="String" />
                        <asp:Parameter Name="LoweredRoleName" Type="String" />
                        <asp:Parameter Name="Description" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter DbType="Guid" Name="ApplicationId" />
                        <asp:Parameter DbType="Guid" Name="RoleId" />
                        <asp:Parameter Name="RoleName" Type="String" />
                        <asp:Parameter Name="LoweredRoleName" Type="String" />
                        <asp:Parameter Name="Description" Type="String" />
                        <asp:Parameter DbType="Guid" Name="Original_ApplicationId" />
                        <asp:Parameter Name="Original_LoweredRoleName" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odcAspnet_UsersInRoles" runat="server" 
                    DeleteMethod="Delete" InsertMethod="Insert" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                    TypeName="AllTablesTableAdapters.aspnet_UsersInRolesTableAdapter" 
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter DbType="Guid" Name="Original_UserId" />
                        <asp:Parameter DbType="Guid" Name="Original_RoleId" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter DbType="Guid" Name="UserId" />
                        <asp:Parameter DbType="Guid" Name="RoleId" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter DbType="Guid" Name="Original_UserId" />
                        <asp:Parameter DbType="Guid" Name="Original_RoleId" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odcAspnet_Users" runat="server" DeleteMethod="Delete" 
                    InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
                    SelectMethod="GetData" 
                    TypeName="AllTablesTableAdapters.aspnet_UsersTableAdapter" 
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter DbType="Guid" Name="Original_ApplicationId" />
                        <asp:Parameter Name="Original_LoweredUserName" Type="String" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter DbType="Guid" Name="ApplicationId" />
                        <asp:Parameter DbType="Guid" Name="UserId" />
                        <asp:Parameter Name="UserName" Type="String" />
                        <asp:Parameter Name="LoweredUserName" Type="String" />
                        <asp:Parameter Name="MobileAlias" Type="String" />
                        <asp:Parameter Name="IsAnonymous" Type="Boolean" />
                        <asp:Parameter Name="LastActivityDate" Type="DateTime" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter DbType="Guid" Name="ApplicationId" />
                        <asp:Parameter DbType="Guid" Name="UserId" />
                        <asp:Parameter Name="UserName" Type="String" />
                        <asp:Parameter Name="LoweredUserName" Type="String" />
                        <asp:Parameter Name="MobileAlias" Type="String" />
                        <asp:Parameter Name="IsAnonymous" Type="Boolean" />
                        <asp:Parameter Name="LastActivityDate" Type="DateTime" />
                        <asp:Parameter DbType="Guid" Name="Original_ApplicationId" />
                        <asp:Parameter Name="Original_LoweredUserName" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odcBMD_Bricks" runat="server" 
            DeleteMethod="Delete" InsertMethod="Insert" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="AllTablesTableAdapters.BMD_BricksTableAdapter" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_BrickID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="BrickName" Type="String" />
                        <asp:Parameter Name="Commited" Type="Boolean" />
                        <asp:Parameter Name="Deleted" Type="Boolean" />
                        <asp:Parameter Name="CreatedDate" Type="DateTime" />
                        <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="BrickName" Type="String" />
                        <asp:Parameter Name="Commited" Type="Boolean" />
                        <asp:Parameter Name="Deleted" Type="Boolean" />
                        <asp:Parameter Name="CreatedDate" Type="DateTime" />
                        <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                        <asp:Parameter Name="Original_BrickID" Type="Int32" />
                    </UpdateParameters>
        </asp:ObjectDataSource>
        <br />
    </div>
    </form>
</body>
</html>
