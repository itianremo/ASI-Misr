<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="ConfigData_Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <asp:Button ID="Button1" runat="server" Text="SignOut" onclick="Button1_Click" /><br />
        <b>BMD_Distributors</b><asp:GridView ID="GridView5" runat="server" 
            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
            DataKeyNames="DistributorID" DataSourceID="odcBMD_Distributors" 
            EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="DistributorID" HeaderText="DistributorID" 
                    InsertVisible="False" ReadOnly="True" SortExpression="DistributorID" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:CheckBoxField DataField="Commited" HeaderText="Commited" 
                    SortExpression="Commited" />
                <asp:CheckBoxField DataField="Deleted" HeaderText="Deleted" 
                    SortExpression="Deleted" />
            </Columns>
        </asp:GridView>
        <br />
        <b>BMD_Distributor_Branches</b><asp:GridView ID="GridView6" runat="server" 
            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
            DataKeyNames="BranchID" DataSourceID="odcBMD_Distributor_Branches" 
            EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="BranchID" HeaderText="BranchID" 
                    InsertVisible="False" ReadOnly="True" SortExpression="BranchID" />
                <asp:BoundField DataField="DistributorID" HeaderText="DistributorID" 
                    SortExpression="DistributorID" />
                <asp:BoundField DataField="BranchName" HeaderText="BranchName" 
                    SortExpression="BranchName" />
                <asp:BoundField DataField="BranchAddress" HeaderText="BranchAddress" 
                    SortExpression="BranchAddress" />
                <asp:BoundField DataField="Commited" HeaderText="Commited" 
                    SortExpression="Commited" />
                <asp:CheckBoxField DataField="Deleted" HeaderText="Deleted" 
                    SortExpression="Deleted" />
                <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" 
                    SortExpression="CreatedDate" />
                <asp:BoundField DataField="ModifiedDate" HeaderText="ModifiedDate" 
                    SortExpression="ModifiedDate" />
            </Columns>
        </asp:GridView>
        <br />
        <b>BMD_Employees</b><asp:GridView ID="GridView7" runat="server" 
            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
            DataKeyNames="EmpID" DataSourceID="odcBMD_Employees" 
            EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="EmpID" HeaderText="EmpID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="EmpID" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" 
                    SortExpression="UserName" />
                <asp:BoundField DataField="EmpName" HeaderText="EmpName" 
                    SortExpression="EmpName" />
                <asp:BoundField DataField="LoweredEmpName" HeaderText="LoweredEmpName" 
                    SortExpression="LoweredEmpName" />
                <asp:BoundField DataField="TitleID" HeaderText="TitleID" 
                    SortExpression="TitleID" />
                <asp:CheckBoxField DataField="Active" HeaderText="Active" 
                    SortExpression="Active" />
                <asp:BoundField DataField="NID" HeaderText="NID" SortExpression="NID" />
                <asp:BoundField DataField="Comment" HeaderText="Comment" 
                    SortExpression="Comment" />
                <asp:CheckBoxField DataField="Commited" HeaderText="Commited" 
                    SortExpression="Commited" />
                <asp:CheckBoxField DataField="Deleted" HeaderText="Deleted" 
                    SortExpression="Deleted" />
                <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" 
                    SortExpression="CreatedDate" />
                <asp:BoundField DataField="ModifiedDate" HeaderText="ModifiedDate" 
                    SortExpression="ModifiedDate" />
                <asp:BoundField DataField="Address" HeaderText="Address" 
                    SortExpression="Address" />
                <asp:BoundField DataField="Mobile" HeaderText="Mobile" 
                    SortExpression="Mobile" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="HomeTel" HeaderText="HomeTel" 
                    SortExpression="HomeTel" />
            </Columns>
        </asp:GridView>

        <asp:ObjectDataSource ID="odcBMD_Distributor_Branches" runat="server" 
            DeleteMethod="Delete" InsertMethod="Insert" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="AllTablesTableAdapters.BMD_Distributor_BranchesTableAdapter" 
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_BranchID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="DistributorID" Type="Int32" />
                <asp:Parameter Name="BranchName" Type="String" />
                <asp:Parameter Name="BranchAddress" Type="String" />
                <asp:Parameter Name="Commited" Type="Int32" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
                <asp:Parameter Name="CreatedDate" Type="DateTime" />
                <asp:Parameter Name="ModifiedDate" Type="DateTime" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="DistributorID" Type="Int32" />
                <asp:Parameter Name="BranchName" Type="String" />
                <asp:Parameter Name="BranchAddress" Type="String" />
                <asp:Parameter Name="Commited" Type="Int32" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
                <asp:Parameter Name="CreatedDate" Type="DateTime" />
                <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                <asp:Parameter Name="Original_BranchID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odcBMD_Distributors" runat="server" 
            DeleteMethod="Delete" InsertMethod="Insert" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="AllTablesTableAdapters.BMD_DistributorsTableAdapter" 
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_DistributorID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Commited" Type="Boolean" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Commited" Type="Boolean" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
                <asp:Parameter Name="Original_DistributorID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odcBMD_Employees" runat="server" 
            DeleteMethod="Delete" InsertMethod="Insert" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="AllTablesTableAdapters.BMD_EmployeesTableAdapter" 
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_EmpID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="UserName" Type="String" />
                <asp:Parameter Name="EmpName" Type="String" />
                <asp:Parameter Name="LoweredEmpName" Type="String" />
                <asp:Parameter Name="TitleID" Type="Int32" />
                <asp:Parameter Name="Active" Type="Boolean" />
                <asp:Parameter Name="NID" Type="Decimal" />
                <asp:Parameter Name="Comment" Type="String" />
                <asp:Parameter Name="Commited" Type="Boolean" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
                <asp:Parameter Name="CreatedDate" Type="DateTime" />
                <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="Mobile" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="HomeTel" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="UserName" Type="String" />
                <asp:Parameter Name="EmpName" Type="String" />
                <asp:Parameter Name="LoweredEmpName" Type="String" />
                <asp:Parameter Name="TitleID" Type="Int32" />
                <asp:Parameter Name="Active" Type="Boolean" />
                <asp:Parameter Name="NID" Type="Decimal" />
                <asp:Parameter Name="Comment" Type="String" />
                <asp:Parameter Name="Commited" Type="Boolean" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
                <asp:Parameter Name="CreatedDate" Type="DateTime" />
                <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="Mobile" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="HomeTel" Type="String" />
                <asp:Parameter Name="Original_EmpID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
