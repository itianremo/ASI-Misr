<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default7.aspx.cs" Inherits="ConfigData_Default7" %>

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
        <b>FMT_VisitItems</b><asp:GridView ID="GridView1" runat="server" 
            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
            DataKeyNames="VisitItemID" DataSourceID="odcFMT_VisitItems" 
            EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="VisitItemID" HeaderText="VisitItemID" 
                    InsertVisible="False" ReadOnly="True" SortExpression="VisitItemID" />
                <asp:BoundField DataField="VisitID" HeaderText="VisitID" 
                    SortExpression="VisitID" />
                <asp:BoundField DataField="ItemCodeID" HeaderText="ItemCodeID" 
                    SortExpression="ItemCodeID" />
                <asp:BoundField DataField="ItemTypeID" HeaderText="ItemTypeID" 
                    SortExpression="ItemTypeID" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" 
                    SortExpression="Quantity" />
            </Columns>
        </asp:GridView>
        <br />
        <b>FMT_Visits</b>
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="VisitID" 
            DataSourceID="odcFMT_Visits" EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="VisitID" HeaderText="VisitID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="VisitID" />
                <asp:BoundField DataField="PlanID" HeaderText="PlanID" 
                    SortExpression="PlanID" />
                <asp:BoundField DataField="ModuleID" HeaderText="ModuleID" 
                    SortExpression="ModuleID" />
                <asp:BoundField DataField="ModuleRefID" HeaderText="ModuleRefID" 
                    SortExpression="ModuleRefID" />
                <asp:BoundField DataField="VisitFeedBack" HeaderText="VisitFeedBack" 
                    SortExpression="VisitFeedBack" />
                <asp:CheckBoxField DataField="IsVisited" HeaderText="IsVisited" 
                    SortExpression="IsVisited" />
                <asp:BoundField DataField="VisitTypeID" HeaderText="VisitTypeID" 
                    SortExpression="VisitTypeID" />
                <asp:CheckBoxField DataField="PM" HeaderText="PM" SortExpression="PM" />
                <asp:BoundField DataField="OtherDetails" HeaderText="OtherDetails" 
                    SortExpression="OtherDetails" />
                <asp:CheckBoxField DataField="Deleted" HeaderText="Deleted" 
                    SortExpression="Deleted" />
                <asp:CheckBoxField DataField="IsPlanned" HeaderText="IsPlanned" 
                    SortExpression="IsPlanned" />
                <asp:CheckBoxField DataField="DoubleVisit" HeaderText="DoubleVisit" 
                    SortExpression="DoubleVisit" />
            </Columns>
        </asp:GridView>

        <asp:ObjectDataSource ID="odcFMT_VisitItems" runat="server" 
            DeleteMethod="Delete" InsertMethod="Insert" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="AllTablesTableAdapters.FMT_VisitItemsTableAdapter" 
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_VisitItemID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="VisitID" Type="Int32" />
                <asp:Parameter Name="ItemCodeID" Type="Int32" />
                <asp:Parameter Name="ItemTypeID" Type="Int32" />
                <asp:Parameter Name="Quantity" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="VisitID" Type="Int32" />
                <asp:Parameter Name="ItemCodeID" Type="Int32" />
                <asp:Parameter Name="ItemTypeID" Type="Int32" />
                <asp:Parameter Name="Quantity" Type="Int32" />
                <asp:Parameter Name="Original_VisitItemID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odcFMT_Visits" runat="server" DeleteMethod="Delete" 
            InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetData" TypeName="AllTablesTableAdapters.FMT_VisitsTableAdapter" 
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_VisitID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="PlanID" Type="Int32" />
                <asp:Parameter Name="ModuleID" Type="Int32" />
                <asp:Parameter Name="ModuleRefID" Type="Int32" />
                <asp:Parameter Name="VisitFeedBack" Type="String" />
                <asp:Parameter Name="IsVisited" Type="Boolean" />
                <asp:Parameter Name="VisitTypeID" Type="Int32" />
                <asp:Parameter Name="PM" Type="Boolean" />
                <asp:Parameter Name="OtherDetails" Type="String" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
                <asp:Parameter Name="IsPlanned" Type="Boolean" />
                <asp:Parameter Name="DoubleVisit" Type="Boolean" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="PlanID" Type="Int32" />
                <asp:Parameter Name="ModuleID" Type="Int32" />
                <asp:Parameter Name="ModuleRefID" Type="Int32" />
                <asp:Parameter Name="VisitFeedBack" Type="String" />
                <asp:Parameter Name="IsVisited" Type="Boolean" />
                <asp:Parameter Name="VisitTypeID" Type="Int32" />
                <asp:Parameter Name="PM" Type="Boolean" />
                <asp:Parameter Name="OtherDetails" Type="String" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
                <asp:Parameter Name="IsPlanned" Type="Boolean" />
                <asp:Parameter Name="DoubleVisit" Type="Boolean" />
                <asp:Parameter Name="Original_VisitID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
