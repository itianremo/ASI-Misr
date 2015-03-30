<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default5.aspx.cs" Inherits="ConfigData_Default5" %>

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
        <b>BMD_Rel_Bricks_Branches</b><asp:GridView ID="GridView15" runat="server" 
            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
            DataKeyNames="RxID" DataSourceID="odcBMD_Rel_Bricks_Branches" 
            EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="RxID" HeaderText="RxID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="RxID" />
                <asp:BoundField DataField="BranchID" HeaderText="BranchID" 
                    SortExpression="BranchID" />
                <asp:BoundField DataField="BrickID" HeaderText="BrickID" 
                    SortExpression="BrickID" />
                <asp:BoundField DataField="Commited" HeaderText="Commited" 
                    SortExpression="Commited" />
                <asp:CheckBoxField DataField="Deleted" HeaderText="Deleted" 
                    SortExpression="Deleted" />
            </Columns>
        </asp:GridView>
        <br />
        <b>BMD_Rel_Govs_Cities</b><asp:GridView ID="GridView16" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="RxID" 
            DataSourceID="odcBMD_Rel_Govs_Cities" EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="RxID" HeaderText="RxID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="RxID" />
                <asp:BoundField DataField="GovID" HeaderText="GovID" SortExpression="GovID" />
                <asp:BoundField DataField="CityID" HeaderText="CityID" 
                    SortExpression="CityID" />
                <asp:CheckBoxField DataField="Commited" HeaderText="Commited" 
                    SortExpression="Commited" />
                <asp:CheckBoxField DataField="Deleted" HeaderText="Deleted" 
                    SortExpression="Deleted" />
            </Columns>
        </asp:GridView>
        <br />
        <b>BMD_Rel_Pharmacy_Distributors</b>
        <asp:GridView ID="GridView17" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="RxID" DataSourceID="odcBMD_Rel_Pharmacy_Distributors" 
            EnableModelValidation="True" AllowPaging="True" AllowSorting="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="RxID" HeaderText="RxID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="RxID" />
                <asp:BoundField DataField="PharmacyID" HeaderText="PharmacyID" 
                    SortExpression="PharmacyID" />
                <asp:BoundField DataField="DistributorID" HeaderText="DistributorID" 
                    SortExpression="DistributorID" />
                <asp:BoundField DataField="Commited" HeaderText="Commited" 
                    SortExpression="Commited" />
                <asp:CheckBoxField DataField="Deleted" HeaderText="Deleted" 
                    SortExpression="Deleted" />
            </Columns>
        </asp:GridView>
        <br />
        <b>BMD_Rel_Pharmacy_MedicalAccounts</b><asp:GridView ID="GridView18" 
            runat="server" AllowPaging="True" AllowSorting="True" 
            AutoGenerateColumns="False" DataKeyNames="RxID" 
            DataSourceID="odcBMD_Rel_Pharmacy_MedicalAccounts" EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="RxID" HeaderText="RxID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="RxID" />
                <asp:BoundField DataField="PharmacyID" HeaderText="PharmacyID" 
                    SortExpression="PharmacyID" />
                <asp:BoundField DataField="MedicalAccountID" HeaderText="MedicalAccountID" 
                    SortExpression="MedicalAccountID" />
                <asp:BoundField DataField="Commited" HeaderText="Commited" 
                    SortExpression="Commited" />
            </Columns>
        </asp:GridView>
        <br />
        <b>BMD_Rel_Pharmacy_Physcians</b><asp:GridView ID="GridView19" runat="server" 
            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
            DataKeyNames="RxID" DataSourceID="odcBMD_Rel_Pharmacy_Physcians" 
            EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="RxID" HeaderText="RxID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="RxID" />
                <asp:BoundField DataField="PharmacyID" HeaderText="PharmacyID" 
                    SortExpression="PharmacyID" />
                <asp:BoundField DataField="PhysicianID" HeaderText="PhysicianID" 
                    SortExpression="PhysicianID" />
                <asp:BoundField DataField="Commited" HeaderText="Commited" 
                    SortExpression="Commited" />
            </Columns>
        </asp:GridView>
        <br />
        <b>BMD_Rel_Physicians_MedicalAccounts</b><asp:GridView ID="GridView20" 
            runat="server" AllowPaging="True" AllowSorting="True" 
            AutoGenerateColumns="False" DataKeyNames="RxID" 
            DataSourceID="odcBMD_Rel_Physicians_MedicalAccounts" 
            EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="RxID" HeaderText="RxID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="RxID" />
                <asp:BoundField DataField="PhysicianID" HeaderText="PhysicianID" 
                    SortExpression="PhysicianID" />
                <asp:BoundField DataField="MedicalAccountID" HeaderText="MedicalAccountID" 
                    SortExpression="MedicalAccountID" />
                <asp:CheckBoxField DataField="PrescribingCapable" 
                    HeaderText="PrescribingCapable" SortExpression="PrescribingCapable" />
                <asp:CheckBoxField DataField="Internal" HeaderText="Internal" 
                    SortExpression="Internal" />
                <asp:CheckBoxField DataField="Consultant" HeaderText="Consultant" 
                    SortExpression="Consultant" />
                <asp:BoundField DataField="Commited" HeaderText="Commited" 
                    SortExpression="Commited" />
            </Columns>
        </asp:GridView>

        <asp:ObjectDataSource ID="odcBMD_Rel_Bricks_Branches" runat="server" 
            DeleteMethod="Delete" InsertMethod="Insert" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="AllTablesTableAdapters.BMD_Rel_Bricks_BranchesTableAdapter" 
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_RxID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="BranchID" Type="Int32" />
                <asp:Parameter Name="BrickID" Type="Int32" />
                <asp:Parameter Name="Commited" Type="Int32" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="BranchID" Type="Int32" />
                <asp:Parameter Name="BrickID" Type="Int32" />
                <asp:Parameter Name="Commited" Type="Int32" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
                <asp:Parameter Name="Original_RxID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odcBMD_Rel_Govs_Cities" runat="server" 
            DeleteMethod="Delete" InsertMethod="Insert" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="AllTablesTableAdapters.BMD_Rel_Govs_CitiesTableAdapter" 
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_RxID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="GovID" Type="Int32" />
                <asp:Parameter Name="CityID" Type="Int32" />
                <asp:Parameter Name="Commited" Type="Boolean" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="GovID" Type="Int32" />
                <asp:Parameter Name="CityID" Type="Int32" />
                <asp:Parameter Name="Commited" Type="Boolean" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
                <asp:Parameter Name="Original_RxID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odcBMD_Rel_Pharmacy_Distributors" runat="server" 
            DeleteMethod="Delete" InsertMethod="Insert" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="AllTablesTableAdapters.BMD_Rel_Pharmacy_DistributorsTableAdapter" 
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_RxID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="PharmacyID" Type="Int32" />
                <asp:Parameter Name="DistributorID" Type="Int32" />
                <asp:Parameter Name="Commited" Type="Int32" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="PharmacyID" Type="Int32" />
                <asp:Parameter Name="DistributorID" Type="Int32" />
                <asp:Parameter Name="Commited" Type="Int32" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
                <asp:Parameter Name="Original_RxID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odcBMD_Rel_Pharmacy_MedicalAccounts" runat="server" 
            DeleteMethod="Delete" InsertMethod="Insert" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="AllTablesTableAdapters.BMD_Rel_Pharmacy_MedicalAccountsTableAdapter" 
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_RxID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="PharmacyID" Type="Int32" />
                <asp:Parameter Name="MedicalAccountID" Type="Int32" />
                <asp:Parameter Name="Commited" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="PharmacyID" Type="Int32" />
                <asp:Parameter Name="MedicalAccountID" Type="Int32" />
                <asp:Parameter Name="Commited" Type="Int32" />
                <asp:Parameter Name="Original_RxID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odcBMD_Rel_Pharmacy_Physcians" runat="server" 
            DeleteMethod="Delete" InsertMethod="Insert" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="AllTablesTableAdapters.BMD_Rel_Pharmacy_PhysciansTableAdapter" 
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_RxID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="PharmacyID" Type="Int32" />
                <asp:Parameter Name="PhysicianID" Type="Int32" />
                <asp:Parameter Name="Commited" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="PharmacyID" Type="Int32" />
                <asp:Parameter Name="PhysicianID" Type="Int32" />
                <asp:Parameter Name="Commited" Type="Int32" />
                <asp:Parameter Name="Original_RxID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odcBMD_Rel_Physicians_MedicalAccounts" runat="server" 
            DeleteMethod="Delete" InsertMethod="Insert" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="AllTablesTableAdapters.BMD_Rel_Physicians_MedicalAccountsTableAdapter" 
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_RxID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="PhysicianID" Type="Int32" />
                <asp:Parameter Name="MedicalAccountID" Type="Int32" />
                <asp:Parameter Name="PrescribingCapable" Type="Boolean" />
                <asp:Parameter Name="Internal" Type="Boolean" />
                <asp:Parameter Name="Consultant" Type="Boolean" />
                <asp:Parameter Name="Commited" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="PhysicianID" Type="Int32" />
                <asp:Parameter Name="MedicalAccountID" Type="Int32" />
                <asp:Parameter Name="PrescribingCapable" Type="Boolean" />
                <asp:Parameter Name="Internal" Type="Boolean" />
                <asp:Parameter Name="Consultant" Type="Boolean" />
                <asp:Parameter Name="Commited" Type="Int32" />
                <asp:Parameter Name="Original_RxID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
