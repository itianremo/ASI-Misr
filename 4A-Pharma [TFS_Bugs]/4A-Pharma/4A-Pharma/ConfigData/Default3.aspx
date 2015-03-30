<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="ConfigData_Default3" %>

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
        <b>BMD_MedicalAccounts</b><asp:GridView ID="GridView8" runat="server" 
            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
            DataKeyNames="MedicalAccountID" DataSourceID="odcBMD_MedicalAccounts" 
            EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="MedicalAccountID" HeaderText="MedicalAccountID" 
                    InsertVisible="False" ReadOnly="True" SortExpression="MedicalAccountID" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="BrickID" HeaderText="BrickID" 
                    SortExpression="BrickID" />
                <asp:BoundField DataField="SubordinationID" HeaderText="SubordinationID" 
                    SortExpression="SubordinationID" />
                <asp:BoundField DataField="GovID" HeaderText="GovID" SortExpression="GovID" />
                <asp:BoundField DataField="CityID" HeaderText="CityID" 
                    SortExpression="CityID" />
                <asp:BoundField DataField="Area" HeaderText="Area" SortExpression="Area" />
                <asp:BoundField DataField="Address" HeaderText="Address" 
                    SortExpression="Address" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                <asp:BoundField DataField="Mobile" HeaderText="Mobile" 
                    SortExpression="Mobile" />
                <asp:BoundField DataField="PostalCode" HeaderText="PostalCode" 
                    SortExpression="PostalCode" />
                <asp:BoundField DataField="ICUNO" HeaderText="ICUNO" SortExpression="ICUNO" />
                <asp:BoundField DataField="No_Medically_Served_Pts" 
                    HeaderText="No_Medically_Served_Pts" SortExpression="No_Medically_Served_Pts" />
                <asp:BoundField DataField="RX_Financial_Limits" 
                    HeaderText="RX_Financial_Limits" SortExpression="RX_Financial_Limits" />
                <asp:BoundField DataField="Monthly_Financial_Limits" 
                    HeaderText="Monthly_Financial_Limits" 
                    SortExpression="Monthly_Financial_Limits" />
                <asp:BoundField DataField="Annual_Financial_Limits" 
                    HeaderText="Annual_Financial_Limits" SortExpression="Annual_Financial_Limits" />
                <asp:CheckBoxField DataField="Drug_Delivery_Internal" 
                    HeaderText="Drug_Delivery_Internal" SortExpression="Drug_Delivery_Internal" />
                <asp:CheckBoxField DataField="Drug_Delivery_External" 
                    HeaderText="Drug_Delivery_External" SortExpression="Drug_Delivery_External" />
                <asp:CheckBoxField DataField="Drug_Purchase_Direct_Orders" 
                    HeaderText="Drug_Purchase_Direct_Orders" 
                    SortExpression="Drug_Purchase_Direct_Orders" />
                <asp:CheckBoxField DataField="Drug_Purchase_Tender" 
                    HeaderText="Drug_Purchase_Tender" SortExpression="Drug_Purchase_Tender" />
                <asp:BoundField DataField="Total_RX_General_No_Day" 
                    HeaderText="Total_RX_General_No_Day" SortExpression="Total_RX_General_No_Day" />
                <asp:BoundField DataField="Total_RX_General_No_Week" 
                    HeaderText="Total_RX_General_No_Week" 
                    SortExpression="Total_RX_General_No_Week" />
                <asp:BoundField DataField="Total_RX_General_No_Month" 
                    HeaderText="Total_RX_General_No_Month" 
                    SortExpression="Total_RX_General_No_Month" />
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
        <br />
        <b>BMD_Pharmacies</b><asp:GridView ID="GridView9" runat="server" 
            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
            DataKeyNames="PharmacyID" DataSourceID="odcBMD_Pharmacies" 
            EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="PharmacyID" HeaderText="PharmacyID" 
                    InsertVisible="False" ReadOnly="True" SortExpression="PharmacyID" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="BrickID" HeaderText="BrickID" 
                    SortExpression="BrickID" />
                <asp:BoundField DataField="PharmacistName" HeaderText="PharmacistName" 
                    SortExpression="PharmacistName" />
                <asp:BoundField DataField="GovID" HeaderText="GovID" SortExpression="GovID" />
                <asp:BoundField DataField="CityID" HeaderText="CityID" 
                    SortExpression="CityID" />
                <asp:BoundField DataField="Area" HeaderText="Area" SortExpression="Area" />
                <asp:BoundField DataField="Address" HeaderText="Address" 
                    SortExpression="Address" />
                <asp:BoundField DataField="Phone1" HeaderText="Phone1" 
                    SortExpression="Phone1" />
                <asp:BoundField DataField="Phone2" HeaderText="Phone2" 
                    SortExpression="Phone2" />
                <asp:BoundField DataField="Mobile" HeaderText="Mobile" 
                    SortExpression="Mobile" />
                <asp:BoundField DataField="PostalCode" HeaderText="PostalCode" 
                    SortExpression="PostalCode" />
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
            </Columns>
        </asp:GridView>
        <br />
        <b>BMD_Physicians</b><asp:GridView ID="GridView10" runat="server" 
            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
            DataKeyNames="PhysicianID" DataSourceID="odcBMD_Physicians" 
            EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="PhysicianID" HeaderText="PhysicianID" 
                    InsertVisible="False" ReadOnly="True" SortExpression="PhysicianID" />
                <asp:BoundField DataField="PhysicianName" HeaderText="PhysicianName" 
                    SortExpression="PhysicianName" />
                <asp:BoundField DataField="AKA" HeaderText="AKA" SortExpression="AKA" />
                <asp:BoundField DataField="TitleID" HeaderText="TitleID" 
                    SortExpression="TitleID" />
                <asp:BoundField DataField="SpecialityID" HeaderText="SpecialityID" 
                    SortExpression="SpecialityID" />
                <asp:CheckBoxField DataField="PrivateClinic" HeaderText="PrivateClinic" 
                    SortExpression="PrivateClinic" />
                <asp:BoundField DataField="Mobile" HeaderText="Mobile" 
                    SortExpression="Mobile" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="PostalCode" HeaderText="PostalCode" 
                    SortExpression="PostalCode" />
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
            </Columns>
        </asp:GridView>
        <br />
        <b>BMD_PhysicianScore</b><asp:GridView ID="GridView11" runat="server" 
            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
            DataKeyNames="ScoreID" DataSourceID="odcBMD_PhysicianScore" 
            EnableModelValidation="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="ScoreID" HeaderText="ScoreID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="ScoreID" />
                <asp:BoundField DataField="PhysicianID" HeaderText="PhysicianID" 
                    SortExpression="PhysicianID" />
                <asp:BoundField DataField="Potential" HeaderText="Potential" 
                    SortExpression="Potential" />
                <asp:BoundField DataField="Grade" HeaderText="Grade" SortExpression="Grade" />
                <asp:BoundField DataField="Inference" HeaderText="Inference" 
                    SortExpression="Inference" />
                <asp:BoundField DataField="Additional" HeaderText="Additional" 
                    SortExpression="Additional" />
                <asp:BoundField DataField="ScoreDate" HeaderText="ScoreDate" 
                    SortExpression="ScoreDate" />
                <asp:BoundField DataField="StrScoreDate" HeaderText="StrScoreDate" 
                    SortExpression="StrScoreDate" />
                <asp:BoundField DataField="Total" HeaderText="Total" ReadOnly="True" 
                    SortExpression="Total" />
                <asp:CheckBoxField DataField="Commited" HeaderText="Commited" 
                    SortExpression="Commited" />
                <asp:CheckBoxField DataField="Deleted" HeaderText="Deleted" 
                    SortExpression="Deleted" />
            </Columns>
        </asp:GridView>

        <asp:ObjectDataSource ID="odcBMD_MedicalAccounts" runat="server" 
            DeleteMethod="Delete" InsertMethod="Insert" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="AllTablesTableAdapters.BMD_MedicalAccountsTableAdapter" 
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_MedicalAccountID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="BrickID" Type="Int32" />
                <asp:Parameter Name="SubordinationID" Type="Int32" />
                <asp:Parameter Name="GovID" Type="Int32" />
                <asp:Parameter Name="CityID" Type="Int32" />
                <asp:Parameter Name="Area" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="Phone" Type="String" />
                <asp:Parameter Name="Mobile" Type="String" />
                <asp:Parameter Name="PostalCode" Type="String" />
                <asp:Parameter Name="ICUNO" Type="Int32" />
                <asp:Parameter Name="No_Medically_Served_Pts" Type="Int32" />
                <asp:Parameter Name="RX_Financial_Limits" Type="Decimal" />
                <asp:Parameter Name="Monthly_Financial_Limits" Type="Decimal" />
                <asp:Parameter Name="Annual_Financial_Limits" Type="Decimal" />
                <asp:Parameter Name="Drug_Delivery_Internal" Type="Boolean" />
                <asp:Parameter Name="Drug_Delivery_External" Type="Boolean" />
                <asp:Parameter Name="Drug_Purchase_Direct_Orders" Type="Boolean" />
                <asp:Parameter Name="Drug_Purchase_Tender" Type="Boolean" />
                <asp:Parameter Name="Total_RX_General_No_Day" Type="Int32" />
                <asp:Parameter Name="Total_RX_General_No_Week" Type="Int32" />
                <asp:Parameter Name="Total_RX_General_No_Month" Type="Int32" />
                <asp:Parameter Name="Commited" Type="Boolean" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
                <asp:Parameter Name="CreatedDate" Type="DateTime" />
                <asp:Parameter Name="ModifiedDate" Type="DateTime" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="BrickID" Type="Int32" />
                <asp:Parameter Name="SubordinationID" Type="Int32" />
                <asp:Parameter Name="GovID" Type="Int32" />
                <asp:Parameter Name="CityID" Type="Int32" />
                <asp:Parameter Name="Area" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="Phone" Type="String" />
                <asp:Parameter Name="Mobile" Type="String" />
                <asp:Parameter Name="PostalCode" Type="String" />
                <asp:Parameter Name="ICUNO" Type="Int32" />
                <asp:Parameter Name="No_Medically_Served_Pts" Type="Int32" />
                <asp:Parameter Name="RX_Financial_Limits" Type="Decimal" />
                <asp:Parameter Name="Monthly_Financial_Limits" Type="Decimal" />
                <asp:Parameter Name="Annual_Financial_Limits" Type="Decimal" />
                <asp:Parameter Name="Drug_Delivery_Internal" Type="Boolean" />
                <asp:Parameter Name="Drug_Delivery_External" Type="Boolean" />
                <asp:Parameter Name="Drug_Purchase_Direct_Orders" Type="Boolean" />
                <asp:Parameter Name="Drug_Purchase_Tender" Type="Boolean" />
                <asp:Parameter Name="Total_RX_General_No_Day" Type="Int32" />
                <asp:Parameter Name="Total_RX_General_No_Week" Type="Int32" />
                <asp:Parameter Name="Total_RX_General_No_Month" Type="Int32" />
                <asp:Parameter Name="Commited" Type="Boolean" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
                <asp:Parameter Name="CreatedDate" Type="DateTime" />
                <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                <asp:Parameter Name="Original_MedicalAccountID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odcBMD_Pharmacies" runat="server" 
            DeleteMethod="Delete" InsertMethod="Insert" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="AllTablesTableAdapters.BMD_PharmaciesTableAdapter" 
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_PharmacyID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="BrickID" Type="Int32" />
                <asp:Parameter Name="PharmacistName" Type="String" />
                <asp:Parameter Name="GovID" Type="Int32" />
                <asp:Parameter Name="CityID" Type="Int32" />
                <asp:Parameter Name="Area" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="Phone1" Type="String" />
                <asp:Parameter Name="Phone2" Type="String" />
                <asp:Parameter Name="Mobile" Type="String" />
                <asp:Parameter Name="PostalCode" Type="String" />
                <asp:Parameter Name="Comment" Type="String" />
                <asp:Parameter Name="Commited" Type="Boolean" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
                <asp:Parameter Name="CreatedDate" Type="DateTime" />
                <asp:Parameter Name="ModifiedDate" Type="DateTime" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="BrickID" Type="Int32" />
                <asp:Parameter Name="PharmacistName" Type="String" />
                <asp:Parameter Name="GovID" Type="Int32" />
                <asp:Parameter Name="CityID" Type="Int32" />
                <asp:Parameter Name="Area" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="Phone1" Type="String" />
                <asp:Parameter Name="Phone2" Type="String" />
                <asp:Parameter Name="Mobile" Type="String" />
                <asp:Parameter Name="PostalCode" Type="String" />
                <asp:Parameter Name="Comment" Type="String" />
                <asp:Parameter Name="Commited" Type="Boolean" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
                <asp:Parameter Name="CreatedDate" Type="DateTime" />
                <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                <asp:Parameter Name="Original_PharmacyID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odcBMD_PhysicianScore" runat="server" 
            DeleteMethod="Delete" InsertMethod="Insert" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="AllTablesTableAdapters.BMD_PhysicianScoreTableAdapter" 
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_ScoreID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="PhysicianID" Type="Int32" />
                <asp:Parameter Name="Potential" Type="Decimal" />
                <asp:Parameter Name="Grade" Type="Decimal" />
                <asp:Parameter Name="Inference" Type="Decimal" />
                <asp:Parameter Name="Additional" Type="Decimal" />
                <asp:Parameter Name="ScoreDate" Type="DateTime" />
                <asp:Parameter Name="StrScoreDate" Type="String" />
                <asp:Parameter Name="Commited" Type="Boolean" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="PhysicianID" Type="Int32" />
                <asp:Parameter Name="Potential" Type="Decimal" />
                <asp:Parameter Name="Grade" Type="Decimal" />
                <asp:Parameter Name="Inference" Type="Decimal" />
                <asp:Parameter Name="Additional" Type="Decimal" />
                <asp:Parameter Name="ScoreDate" Type="DateTime" />
                <asp:Parameter Name="StrScoreDate" Type="String" />
                <asp:Parameter Name="Commited" Type="Boolean" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
                <asp:Parameter Name="Original_ScoreID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odcBMD_Physicians" runat="server" 
            DeleteMethod="Delete" InsertMethod="Insert" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="AllTablesTableAdapters.BMD_PhysiciansTableAdapter" 
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_PhysicianID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="PhysicianName" Type="String" />
                <asp:Parameter Name="AKA" Type="String" />
                <asp:Parameter Name="TitleID" Type="Int32" />
                <asp:Parameter Name="SpecialityID" Type="Int32" />
                <asp:Parameter Name="PrivateClinic" Type="Boolean" />
                <asp:Parameter Name="Mobile" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="PostalCode" Type="String" />
                <asp:Parameter Name="Comment" Type="String" />
                <asp:Parameter Name="Commited" Type="Boolean" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
                <asp:Parameter Name="CreatedDate" Type="DateTime" />
                <asp:Parameter Name="ModifiedDate" Type="DateTime" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="PhysicianName" Type="String" />
                <asp:Parameter Name="AKA" Type="String" />
                <asp:Parameter Name="TitleID" Type="Int32" />
                <asp:Parameter Name="SpecialityID" Type="Int32" />
                <asp:Parameter Name="PrivateClinic" Type="Boolean" />
                <asp:Parameter Name="Mobile" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="PostalCode" Type="String" />
                <asp:Parameter Name="Comment" Type="String" />
                <asp:Parameter Name="Commited" Type="Boolean" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
                <asp:Parameter Name="CreatedDate" Type="DateTime" />
                <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                <asp:Parameter Name="Original_PhysicianID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
