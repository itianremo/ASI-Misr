<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.Go.Regional" CodeFile="Regional.ascx.cs" %>
<link href="../Acc1.css" type="text/css" rel="stylesheet">
<p align="center">
    <asp:Table ID="tblErr" runat="server" CssClass="errtable" Visible="False" HorizontalAlign="Center"
        Font-Size="9pt" Font-Names="Arial" CellSpacing="0" CellPadding="2" BorderWidth="0px" ForeColor="Red">
        <asp:TableRow VerticalAlign="Top" runat="server">
            <asp:TableCell BackColor="#FFFFC0" BorderColor="White" Text="&lt;img src=&quot;../go/images/alrt_l.gif&quot; /&gt;" runat="server"></asp:TableCell>
            <asp:TableCell BackColor="#FFFFC0" runat="server"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</p>
<asp:Panel ID="Panel1" Width="100%" runat="server">
    <table id="Table1" style="width: 414px; height: 100px" cellspacing="1" cellpadding="1"
        width="414" align="center" border="0" class="FunctionBlock">
        <tr>
            <td align="right">
                <font face="Verdana" size="2"><strong class="formslabels">Country</strong></font></td>
            <td align="center">
                <asp:DropDownList ID="lstCountries" CssClass="inputtext" runat="server" DataSource="<%# dsCountry1 %>"
                    DataTextField="CountryName" DataValueField="CountryID" AutoPostBack="True" OnSelectedIndexChanged="lstCountries_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td style="width: 40px" align="center">
                <asp:ImageButton ID="btnDeleteCountry" runat="server" AlternateText="Delete Selected Country"
                    ImageUrl="images/standardDelete.gif"></asp:ImageButton></td>
            <td style="width: 32px" align="left">
                <asp:ImageButton ID="btnAddCountry" title="Add new country" runat="server" AlternateText="Add New Country"
                    ImageUrl="images/standardsave.gif" ToolTip="Add new country"></asp:ImageButton></td>
            <td>
                <asp:TextBox ID="txtCountry" runat="server" MaxLength="35"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 82px; height: 31px" align="right">
                <strong><font class="formslabels" face="Verdana" size="2">State</font></strong></td>
            <td align="center">
                <asp:DropDownList ID="lstStates" Visible="False" CssClass="inputtext" runat="server"
                    DataSource="<%# dsState1 %>" DataTextField="StateName" DataValueField="StateCode"
                    AutoPostBack="True" OnSelectedIndexChanged="lstStates_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td style="width: 40px" align="center">
                <asp:ImageButton ID="btnDeleteState" runat="server" AlternateText="Delete Selected State"
                    ImageUrl="images/standardDelete.gif"></asp:ImageButton></td>
            <td style="width: 32px" align="left">
                <asp:ImageButton ID="btnAddState" title="Add new state" Visible="False" runat="server"
                    AlternateText="Add New State" ImageUrl="images/standardsave.gif" ToolTip="Add new state">
                </asp:ImageButton></td>
            <td style="height: 31px">
                <asp:TextBox ID="txtState" Visible="False" runat="server" MaxLength="35"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 82px" align="right">
                <font face="Verdana" size="2"><strong class="formslabels">City</strong></font></td>
            <td align="center">
                <asp:DropDownList ID="lstCities" Visible="False" CssClass="inputtext" runat="server"
                    DataSource="<%# dsCity1 %>" DataTextField="CityName" DataValueField="CityID"
                    AutoPostBack="True" OnSelectedIndexChanged="lstCities_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td style="width: 40px" align="center">
                <asp:ImageButton ID="btnDeleteCity" runat="server" AlternateText="Delete Selected City"
                    ImageUrl="images/standardDelete.gif"></asp:ImageButton></td>
            <td style="width: 32px" align="left">
                <asp:ImageButton ID="btnAddCity" title="Add new city" Visible="False" runat="server"
                    AlternateText="Add New City" ImageUrl="images/standardsave.gif" ToolTip="Add new city">
                </asp:ImageButton></td>
            <td>
                <asp:TextBox ID="txtCity" Visible="False" runat="server" MaxLength="35"></asp:TextBox></td>
        </tr>
    </table>
    <p>
        &nbsp;</p>
    <p align="center">
        <asp:Label ID="lblConfirm" Visible="False" CssClass="formslabels" runat="server">lblConfirm</asp:Label></p>
</asp:Panel>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<table id="Table2" width="353" align="center" border="0" style="width: 353px; height: 21px">
    <tr>
        <td align="center" colspan="3">
            <asp:Label ID="lblWarning" Font-Names="Arial" Font-Size="9pt" CssClass="formslabels"
                runat="server" Width="320px">Note:Please add/select country,state then city.</asp:Label></td>
    </tr>
</table>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<p>
    &nbsp;</p>
