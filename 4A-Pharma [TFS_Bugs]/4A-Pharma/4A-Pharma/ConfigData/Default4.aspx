<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default4.aspx.cs" Inherits="ConfigData_Default4" %>

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
                <b>BMD_PrivateClinics</b><asp:GridView ID="GridView12" runat="server" 
                    AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                    DataKeyNames="PrivateClinicID" DataSourceID="odcBMD_PrivateClinics" 
                    EnableModelValidation="True">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                            ShowSelectButton="True" />
                        <asp:BoundField DataField="PrivateClinicID" HeaderText="PrivateClinicID" 
                            InsertVisible="False" ReadOnly="True" SortExpression="PrivateClinicID" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="BrickID" HeaderText="BrickID" 
                            SortExpression="BrickID" />
                        <asp:BoundField DataField="PhysicianID" HeaderText="PhysicianID" 
                            SortExpression="PhysicianID" />
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
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
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
                <b>BMD_ProductFeedback</b><asp:GridView ID="GridView13" runat="server" 
                    AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                    DataKeyNames="ProductFeedbackID" DataSourceID="odcBMD_ProductFeedback" 
                    EnableModelValidation="True">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                            ShowSelectButton="True" />
                        <asp:BoundField DataField="ProductFeedbackID" HeaderText="ProductFeedbackID" 
                            InsertVisible="False" ReadOnly="True" SortExpression="ProductFeedbackID" />
                        <asp:BoundField DataField="ProductID" HeaderText="ProductID" 
                            SortExpression="ProductID" />
                        <asp:BoundField DataField="MedicalAccountID" HeaderText="MedicalAccountID" 
                            SortExpression="MedicalAccountID" />
                        <asp:BoundField DataField="Group_Total_Average_day" 
                            HeaderText="Group_Total_Average_day" SortExpression="Group_Total_Average_day" />
                        <asp:BoundField DataField="Group_Total_Average_Week" 
                            HeaderText="Group_Total_Average_Week" 
                            SortExpression="Group_Total_Average_Week" />
                        <asp:BoundField DataField="Group_Total_Average_Month" 
                            HeaderText="Group_Total_Average_Month" 
                            SortExpression="Group_Total_Average_Month" />
                        <asp:BoundField DataField="Product_Competitors_Average_Day" 
                            HeaderText="Product_Competitors_Average_Day" 
                            SortExpression="Product_Competitors_Average_Day" />
                        <asp:BoundField DataField="Product_Competitors_Average_Week" 
                            HeaderText="Product_Competitors_Average_Week" 
                            SortExpression="Product_Competitors_Average_Week" />
                        <asp:BoundField DataField="Product_Competitors_Average_Month" 
                            HeaderText="Product_Competitors_Average_Month" 
                            SortExpression="Product_Competitors_Average_Month" />
                        <asp:BoundField DataField="Product_Total_Day" HeaderText="Product_Total_Day" 
                            SortExpression="Product_Total_Day" />
                        <asp:BoundField DataField="Product_Total_Week" HeaderText="Product_Total_Week" 
                            SortExpression="Product_Total_Week" />
                        <asp:BoundField DataField="Product_Total_Month" 
                            HeaderText="Product_Total_Month" SortExpression="Product_Total_Month" />
                        <asp:BoundField DataField="Commited" HeaderText="Commited" 
                            SortExpression="Commited" />
                    </Columns>
                </asp:GridView>
                <br />
                <b>BMD_Products</b><asp:GridView ID="GridView14" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ProductID" 
                    DataSourceID="odcBMD_Products" EnableModelValidation="True">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                            ShowSelectButton="True" />
                        <asp:BoundField DataField="ProductID" HeaderText="ProductID" 
                            InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
                        <asp:BoundField DataField="ProductName" HeaderText="ProductName" 
                            SortExpression="ProductName" />
                        <asp:BoundField DataField="FormID" HeaderText="FormID" 
                            SortExpression="FormID" />
                        <asp:BoundField DataField="Composition" HeaderText="Composition" 
                            SortExpression="Composition" />
                        <asp:BoundField DataField="Indications" HeaderText="Indications" 
                            SortExpression="Indications" />
                        <asp:BoundField DataField="Dosage" HeaderText="Dosage" 
                            SortExpression="Dosage" />
                        <asp:BoundField DataField="PackSizes" HeaderText="PackSizes" 
                            SortExpression="PackSizes" />
                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                        <asp:BoundField DataField="DosageUnit" HeaderText="DosageUnit" 
                            SortExpression="DosageUnit" />
                        <asp:BoundField DataField="PackSizesUnit" HeaderText="PackSizesUnit" 
                            SortExpression="PackSizesUnit" />
                        <asp:BoundField DataField="CID" HeaderText="CID" SortExpression="CID" />
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

                <asp:ObjectDataSource ID="odcBMD_PrivateClinics" runat="server" 
                    DeleteMethod="Delete" InsertMethod="Insert" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                    TypeName="AllTablesTableAdapters.BMD_PrivateClinicsTableAdapter" 
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_PrivateClinicID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="BrickID" Type="Int32" />
                        <asp:Parameter Name="PhysicianID" Type="Int32" />
                        <asp:Parameter Name="GovID" Type="Int32" />
                        <asp:Parameter Name="CityID" Type="Int32" />
                        <asp:Parameter Name="Area" Type="String" />
                        <asp:Parameter Name="Address" Type="String" />
                        <asp:Parameter Name="Phone1" Type="String" />
                        <asp:Parameter Name="Phone2" Type="String" />
                        <asp:Parameter Name="Mobile" Type="String" />
                        <asp:Parameter Name="PostalCode" Type="String" />
                        <asp:Parameter Name="Email" Type="String" />
                        <asp:Parameter Name="Comment" Type="String" />
                        <asp:Parameter Name="Commited" Type="Boolean" />
                        <asp:Parameter Name="Deleted" Type="Boolean" />
                        <asp:Parameter Name="CreatedDate" Type="DateTime" />
                        <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="BrickID" Type="Int32" />
                        <asp:Parameter Name="PhysicianID" Type="Int32" />
                        <asp:Parameter Name="GovID" Type="Int32" />
                        <asp:Parameter Name="CityID" Type="Int32" />
                        <asp:Parameter Name="Area" Type="String" />
                        <asp:Parameter Name="Address" Type="String" />
                        <asp:Parameter Name="Phone1" Type="String" />
                        <asp:Parameter Name="Phone2" Type="String" />
                        <asp:Parameter Name="Mobile" Type="String" />
                        <asp:Parameter Name="PostalCode" Type="String" />
                        <asp:Parameter Name="Email" Type="String" />
                        <asp:Parameter Name="Comment" Type="String" />
                        <asp:Parameter Name="Commited" Type="Boolean" />
                        <asp:Parameter Name="Deleted" Type="Boolean" />
                        <asp:Parameter Name="CreatedDate" Type="DateTime" />
                        <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                        <asp:Parameter Name="Original_PrivateClinicID" Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odcBMD_ProductFeedback" runat="server" 
                    DeleteMethod="Delete" InsertMethod="Insert" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                    TypeName="AllTablesTableAdapters.BMD_ProductFeedbackTableAdapter" 
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_ProductFeedbackID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="ProductID" Type="Int32" />
                        <asp:Parameter Name="MedicalAccountID" Type="Int32" />
                        <asp:Parameter Name="Group_Total_Average_day" Type="Int32" />
                        <asp:Parameter Name="Group_Total_Average_Week" Type="Int32" />
                        <asp:Parameter Name="Group_Total_Average_Month" Type="Int32" />
                        <asp:Parameter Name="Product_Competitors_Average_Day" Type="Int32" />
                        <asp:Parameter Name="Product_Competitors_Average_Week" Type="Int32" />
                        <asp:Parameter Name="Product_Competitors_Average_Month" Type="Int32" />
                        <asp:Parameter Name="Product_Total_Day" Type="Int32" />
                        <asp:Parameter Name="Product_Total_Week" Type="Int32" />
                        <asp:Parameter Name="Product_Total_Month" Type="Int32" />
                        <asp:Parameter Name="Commited" Type="Int32" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="ProductID" Type="Int32" />
                        <asp:Parameter Name="MedicalAccountID" Type="Int32" />
                        <asp:Parameter Name="Group_Total_Average_day" Type="Int32" />
                        <asp:Parameter Name="Group_Total_Average_Week" Type="Int32" />
                        <asp:Parameter Name="Group_Total_Average_Month" Type="Int32" />
                        <asp:Parameter Name="Product_Competitors_Average_Day" Type="Int32" />
                        <asp:Parameter Name="Product_Competitors_Average_Week" Type="Int32" />
                        <asp:Parameter Name="Product_Competitors_Average_Month" Type="Int32" />
                        <asp:Parameter Name="Product_Total_Day" Type="Int32" />
                        <asp:Parameter Name="Product_Total_Week" Type="Int32" />
                        <asp:Parameter Name="Product_Total_Month" Type="Int32" />
                        <asp:Parameter Name="Commited" Type="Int32" />
                        <asp:Parameter Name="Original_ProductFeedbackID" Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odcBMD_Products" runat="server" DeleteMethod="Delete" 
                    InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
                    SelectMethod="GetData" 
                    TypeName="AllTablesTableAdapters.BMD_ProductsTableAdapter" 
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_ProductID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="ProductName" Type="String" />
                        <asp:Parameter Name="FormID" Type="Int32" />
                        <asp:Parameter Name="Composition" Type="String" />
                        <asp:Parameter Name="Indications" Type="String" />
                        <asp:Parameter Name="Dosage" Type="Int32" />
                        <asp:Parameter Name="PackSizes" Type="Int32" />
                        <asp:Parameter Name="Price" Type="Decimal" />
                        <asp:Parameter Name="DosageUnit" Type="Int32" />
                        <asp:Parameter Name="PackSizesUnit" Type="Int32" />
                        <asp:Parameter Name="CID" Type="Int32" />
                        <asp:Parameter Name="Commited" Type="Boolean" />
                        <asp:Parameter Name="Deleted" Type="Boolean" />
                        <asp:Parameter Name="CreatedDate" Type="DateTime" />
                        <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="ProductName" Type="String" />
                        <asp:Parameter Name="FormID" Type="Int32" />
                        <asp:Parameter Name="Composition" Type="String" />
                        <asp:Parameter Name="Indications" Type="String" />
                        <asp:Parameter Name="Dosage" Type="Int32" />
                        <asp:Parameter Name="PackSizes" Type="Int32" />
                        <asp:Parameter Name="Price" Type="Decimal" />
                        <asp:Parameter Name="DosageUnit" Type="Int32" />
                        <asp:Parameter Name="PackSizesUnit" Type="Int32" />
                        <asp:Parameter Name="CID" Type="Int32" />
                        <asp:Parameter Name="Commited" Type="Boolean" />
                        <asp:Parameter Name="Deleted" Type="Boolean" />
                        <asp:Parameter Name="CreatedDate" Type="DateTime" />
                        <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                        <asp:Parameter Name="Original_ProductID" Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
