<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default6.aspx.cs" Inherits="ConfigData_Default6" %>

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
        <b>BMD_Transactions</b><br />
        <asp:GridView ID="GridView21" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="TransID" 
            DataSourceID="odcBMD_Transactions" EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="TransID" HeaderText="TransID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="TransID">
                <ControlStyle Width="30px" />
                <FooterStyle Width="30px" />
                <HeaderStyle Width="30px" />
                <ItemStyle Width="30px" />
                </asp:BoundField>
                <asp:BoundField DataField="TransRequestDate" HeaderText="TransRequestDate" 
                    SortExpression="TransRequestDate" />
                <asp:BoundField DataField="TransRequestByEmpID" 
                    HeaderText="TransRequestByEmpID" SortExpression="TransRequestByEmpID" />
                <asp:BoundField DataField="TransType" HeaderText="TransType" 
                    SortExpression="TransType" />
                <asp:BoundField DataField="TransModule" HeaderText="TransModule" 
                    SortExpression="TransModule" />
                <asp:BoundField DataField="TransModuleRefID" HeaderText="TransModuleRefID" 
                    SortExpression="TransModuleRefID" />
                <asp:BoundField DataField="TransModuleNewID" HeaderText="TransModuleNewID" 
                    SortExpression="TransModuleNewID" />
                <asp:BoundField DataField="TransStatus" HeaderText="TransStatus" 
                    SortExpression="TransStatus" />
                <asp:BoundField DataField="TransCommitDate" HeaderText="TransCommitDate" 
                    SortExpression="TransCommitDate" />
                <asp:BoundField DataField="TransCommitByEmpID" HeaderText="TransCommitByEmpID" 
                    SortExpression="TransCommitByEmpID" />
            </Columns>
        </asp:GridView>
        <br />
        <b>DB_Version</b><br />
        <asp:GridView ID="GridView22" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="VersionID" 
            DataSourceID="odcDB_Version" EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="VersionID" HeaderText="VersionID" ReadOnly="True" 
                    SortExpression="VersionID" />
                <asp:BoundField DataField="VersionName" HeaderText="VersionName" 
                    SortExpression="VersionName" />
                <asp:BoundField DataField="Comment" HeaderText="Comment" 
                    SortExpression="Comment" />
            </Columns>
        </asp:GridView>
        <br />
        <b>FMT_Plan</b><asp:GridView ID="GridView23" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="PlanID" 
            DataSourceID="odcFMT_Plan" EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="PlanID" HeaderText="PlanID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="PlanID" />
                <asp:BoundField DataField="PlanDate" HeaderText="PlanDate" 
                    SortExpression="PlanDate" />
                <asp:BoundField DataField="EmpID" HeaderText="EmpID" SortExpression="EmpID" />
                <asp:BoundField DataField="Commit" HeaderText="Commit" 
                    SortExpression="Commit" />
                <asp:BoundField DataField="CommitDate" HeaderText="CommitDate" 
                    SortExpression="CommitDate" />
                <asp:BoundField DataField="CommitBy" HeaderText="CommitBy" 
                    SortExpression="CommitBy" />
                <asp:BoundField DataField="StartPoint" HeaderText="StartPoint" 
                    SortExpression="StartPoint" />
                <asp:BoundField DataField="StartTime" HeaderText="StartTime" 
                    SortExpression="StartTime" />
                <asp:CheckBoxField DataField="Deleted" HeaderText="Deleted" 
                    SortExpression="Deleted" />
                <asp:BoundField DataField="RequestDate" HeaderText="RequestDate" 
                    SortExpression="RequestDate" />
                <asp:BoundField DataField="StartPointPM" HeaderText="StartPointPM" 
                    SortExpression="StartPointPM" />
                <asp:BoundField DataField="StartTimePM" HeaderText="StartTimePM" 
                    SortExpression="StartTimePM" />
            </Columns>
        </asp:GridView>
        <br />
        <b>FMT_PlanModules</b><asp:GridView ID="GridView24" runat="server" 
            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
            DataKeyNames="ModuleID" DataSourceID="odcFMT_PlanModules" 
            EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="ModuleID" HeaderText="ModuleID" 
                    InsertVisible="False" ReadOnly="True" SortExpression="ModuleID" />
                <asp:BoundField DataField="ModuleType" HeaderText="ModuleType" 
                    SortExpression="ModuleType" />
                <asp:CheckBoxField DataField="IsVisitModule" HeaderText="IsVisitModule" 
                    SortExpression="IsVisitModule" />
            </Columns>
        </asp:GridView>
        <br />
        <b>FMT_PlanSubModules</b><asp:GridView ID="GridView25" runat="server" 
            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
            DataKeyNames="SubModuleID" DataSourceID="odcFMT_PlanSubModules" 
            EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="SubModuleID" HeaderText="SubModuleID" 
                    InsertVisible="False" ReadOnly="True" SortExpression="SubModuleID" />
                <asp:BoundField DataField="VisitID" HeaderText="VisitID" 
                    SortExpression="VisitID" />
                <asp:BoundField DataField="ModuleID" HeaderText="ModuleID" 
                    SortExpression="ModuleID" />
                <asp:BoundField DataField="SubModuleRefID" HeaderText="SubModuleRefID" 
                    SortExpression="SubModuleRefID" />
            </Columns>
        </asp:GridView>

        <asp:ObjectDataSource ID="odcBMD_Transactions" runat="server" 
            DeleteMethod="Delete" InsertMethod="Insert" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="AllTablesTableAdapters.BMD_TransactionsTableAdapter" 
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_TransID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="TransRequestDate" Type="DateTime" />
                <asp:Parameter Name="TransRequestByEmpID" Type="Int32" />
                <asp:Parameter Name="TransType" Type="Int32" />
                <asp:Parameter Name="TransModule" Type="String" />
                <asp:Parameter Name="TransModuleRefID" Type="Int32" />
                <asp:Parameter Name="TransModuleNewID" Type="Int32" />
                <asp:Parameter Name="TransStatus" Type="Int32" />
                <asp:Parameter Name="TransCommitDate" Type="DateTime" />
                <asp:Parameter Name="TransCommitByEmpID" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="TransRequestDate" Type="DateTime" />
                <asp:Parameter Name="TransRequestByEmpID" Type="Int32" />
                <asp:Parameter Name="TransType" Type="Int32" />
                <asp:Parameter Name="TransModule" Type="String" />
                <asp:Parameter Name="TransModuleRefID" Type="Int32" />
                <asp:Parameter Name="TransModuleNewID" Type="Int32" />
                <asp:Parameter Name="TransStatus" Type="Int32" />
                <asp:Parameter Name="TransCommitDate" Type="DateTime" />
                <asp:Parameter Name="TransCommitByEmpID" Type="Int32" />
                <asp:Parameter Name="Original_TransID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odcDB_Version" runat="server" DeleteMethod="Delete" 
            InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetData" TypeName="AllTablesTableAdapters.DB_VersionTableAdapter" 
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_VersionID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="VersionID" Type="Int32" />
                <asp:Parameter Name="VersionName" Type="String" />
                <asp:Parameter Name="Comment" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="VersionID" Type="Int32" />
                <asp:Parameter Name="VersionName" Type="String" />
                <asp:Parameter Name="Comment" Type="String" />
                <asp:Parameter Name="Original_VersionID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odcFMT_PlanModules" runat="server" 
            DeleteMethod="Delete" InsertMethod="Insert" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="AllTablesTableAdapters.FMT_PlanModulesTableAdapter" 
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_ModuleID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ModuleType" Type="String" />
                <asp:Parameter Name="IsVisitModule" Type="Boolean" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="ModuleType" Type="String" />
                <asp:Parameter Name="IsVisitModule" Type="Boolean" />
                <asp:Parameter Name="Original_ModuleID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odcFMT_PlanSubModules" runat="server" 
            DeleteMethod="Delete" InsertMethod="Insert" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="AllTablesTableAdapters.FMT_PlanSubModulesTableAdapter" 
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_SubModuleID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="VisitID" Type="Int32" />
                <asp:Parameter Name="ModuleID" Type="Int32" />
                <asp:Parameter Name="SubModuleRefID" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="VisitID" Type="Int32" />
                <asp:Parameter Name="ModuleID" Type="Int32" />
                <asp:Parameter Name="SubModuleRefID" Type="Int32" />
                <asp:Parameter Name="Original_SubModuleID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odcFMT_Plan" runat="server" DeleteMethod="Delete" 
            InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetData" TypeName="AllTablesTableAdapters.FMT_PlanTableAdapter" 
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_PlanID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="PlanDate" Type="DateTime" />
                <asp:Parameter Name="EmpID" Type="Int32" />
                <asp:Parameter Name="Commit" Type="Int32" />
                <asp:Parameter Name="CommitDate" Type="DateTime" />
                <asp:Parameter Name="CommitBy" Type="Int32" />
                <asp:Parameter Name="StartPoint" Type="String" />
                <asp:Parameter Name="StartTime" Type="DateTime" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
                <asp:Parameter Name="RequestDate" Type="DateTime" />
                <asp:Parameter Name="StartPointPM" Type="String" />
                <asp:Parameter Name="StartTimePM" Type="DateTime" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="PlanDate" Type="DateTime" />
                <asp:Parameter Name="EmpID" Type="Int32" />
                <asp:Parameter Name="Commit" Type="Int32" />
                <asp:Parameter Name="CommitDate" Type="DateTime" />
                <asp:Parameter Name="CommitBy" Type="Int32" />
                <asp:Parameter Name="StartPoint" Type="String" />
                <asp:Parameter Name="StartTime" Type="DateTime" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
                <asp:Parameter Name="RequestDate" Type="DateTime" />
                <asp:Parameter Name="StartPointPM" Type="String" />
                <asp:Parameter Name="StartTimePM" Type="DateTime" />
                <asp:Parameter Name="Original_PlanID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
