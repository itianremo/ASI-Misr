<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" Title="Change Password" %>
<%@ Register Src="Controls/TransButtons.ascx" TagName="TransButtons" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center">
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <table>
            <tr>
                <td align="right">
                    <asp:Label ID="lblPassword" runat="server" CssClass="MainfontStyle" Text="Old Password:"></asp:Label></td>
                <td align="left">
                    <asp:TextBox ID="txtOldPassword" runat="server" CssClass="inputs" TextMode="Password"
                        Width="200px"></asp:TextBox></td>
                <td align="left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPassword"
                        Display="Dynamic" ErrorMessage="*" CssClass="StyleValidationSummary">Old Password required</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label1" runat="server" CssClass="MainfontStyle" Text="New Password:"></asp:Label></td>
                <td align="left">
                    <asp:TextBox ID="txtNewPassword1" runat="server" CssClass="inputs" TextMode="Password"
                        Width="200px"></asp:TextBox></td>
                <td align="left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassword1"
                        Display="Dynamic" ErrorMessage="*" CssClass="StyleValidationSummary">New Password required</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label2" runat="server" CssClass="MainfontStyle" Text="Confirm Password:"></asp:Label></td>
                <td align="left">
                    <asp:TextBox ID="txtNewPassword2" runat="server" CssClass="inputs" TextMode="Password"
                        Width="200px"></asp:TextBox></td>
                <td align="left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNewPassword2"
                        Display="Dynamic" ErrorMessage="*" CssClass="StyleValidationSummary">Confirm Password required</asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassword1"
                        ControlToValidate="txtNewPassword2" Display="Dynamic" ErrorMessage="Passwords Not matched...!" CssClass="StyleValidationSummary"></asp:CompareValidator></td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="center">
                    <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Images/save_n.jpg" OnClick="btnSave_Click"
                        ToolTip="Save Changes" /></td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="center">
                    <asp:Label ID="lblMsg" runat="server" CssClass="StyleValidationSummary" ForeColor="Red"></asp:Label></td>
                <td>
                </td>
            </tr>
        </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        &nbsp;</div>
</asp:Content>

