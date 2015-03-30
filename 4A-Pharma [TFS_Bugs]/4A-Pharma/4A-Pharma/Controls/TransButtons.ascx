<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TransButtons.ascx.cs"
    Inherits="TransButtons" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table cellspacing="0">
            <tr>
                <td valign="middle">
                    <asp:ImageButton ID="btnAdd" AlternateText="Add New" runat="server" OnClick="btnAdd_Click"
                        ImageUrl="~/Images/add_n.jpg" CausesValidation="False" />
                </td>
                <td id="SpacerbtnAdd" runat="server" valign="middle" visible="false">
                    <font color="#dfdfdf">&nbsp;</font>
                </td>
                <td valign="middle">
                    <asp:ImageButton ID="btnEdit" AlternateText="Edit" runat="server" ImageUrl="~/Images/Edit_n.jpg"
                        OnClick="btnEdit_Click" CausesValidation="False" />
                </td>
                <td id="SpacerbtnEdit" runat="server" valign="middle" visible="false">
                    <font color="#dfdfdf">&nbsp;</font>
                </td>
                <td valign="middle">
                    <asp:ImageButton ID="btnSave" AlternateText="Save" runat="server" ImageUrl="~/Images/save_n.jpg"
                        OnClick="btnSave_Click" Visible="False" />
                </td>
                <td id="SpacerbtnSave" runat="server" valign="middle" visible="false">
                    <font color="#dfdfdf">&nbsp;</font>
                </td>
                <td valign="top">
                    <asp:ImageButton ID="btnCancel" AlternateText="Cancel" runat="server" ImageUrl="~/Images/Cancel-n.jpg"
                        OnClick="btnCancel_Click" Visible="False" CausesValidation="False" />
                        </td>
                <td id="SpacerbtnCancel" runat="server" valign="middle" visible="false">
                    <font color="#dfdfdf">&nbsp;</font>
                </td>
                <td valign="top">
                    <asp:ImageButton ID="btnDelete" AlternateText="Delete" runat="server" ImageUrl="~/Images/delete_n.jpg"
                        CausesValidation="False" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete this Record ?')" /></td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
