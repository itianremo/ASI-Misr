<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ConfigData_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="SignOut" onclick="Button1_Click" /><br />

        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/ConfigData/Default1.aspx">Aspnet_Roles|Aspnet_Users|Aspnet_UsersInRoles|BMD_Bricks</asp:HyperLink>
                
        <br />
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server" 
            NavigateUrl="~/ConfigData/Default2.aspx">BMD_Distributors|BMD_Distributor_Branches|BMD_Employees</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink3" runat="server" 
            NavigateUrl="~/ConfigData/Default3.aspx">BMD_MedicalAccounts|BMD_Pharmacies|BMD_Physicians|BMD_PhysicianScore</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink4" runat="server" 
            NavigateUrl="~/ConfigData/Default4.aspx">BMD_PrivateClinics|BMD_ProductFeedback|BMD_Products</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink5" runat="server" 
            NavigateUrl="~/ConfigData/Default5.aspx">BMD_Rel_Bricks_Branches|BMD_Rel_Govs_Cities|BMD_Rel_Pharmacy_Distributors|BMD_Rel_Pharmacy_MedicalAccounts|BMD_Rel_Pharmacy_Physcians|BMD_Rel_Physicians_MedicalAccounts</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink6" runat="server" 
            NavigateUrl="~/ConfigData/Default6.aspx">BMD_Transactions|DB_Version|FMT_Plan|FMT_PlanModules|FMT_PlanSubModules</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink7" runat="server" 
            NavigateUrl="~/ConfigData/Default7.aspx">FMT_VisitItems|FMT_Visits</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink8" runat="server" 
            NavigateUrl="~/ConfigData/Default8.aspx">GNR_GeneralCode|GNR_SubCode</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink9" runat="server" 
            NavigateUrl="~/ConfigData/Default9.aspx">SQL</asp:HyperLink>
        <br />
    </div>
    </form>
</body>
</html>
