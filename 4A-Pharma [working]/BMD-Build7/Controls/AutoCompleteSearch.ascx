<%@ control language="C#" autoeventwireup="true" inherits="Controls_Search, App_Web_autocompletesearch.ascx.cc671b29" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script language="javascript">
function SubmitResult(source, eventArgs)
{
    if(document.getElementById('ucAutoCompleteSearch$txtBoxSearch').value != '')
    {
        document.getElementById('ucAutoCompleteSearch$btnSearch').click();
    }
}
</script>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<table cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:TextBox ID="txtBoxSearch" runat="server" CssClass="inputs" Width="250px"></asp:TextBox>&nbsp;
            </td>
        <td>
            <asp:ImageButton ID="btnSearch" runat="server" AlternateText="Search" ImageUrl="~/Images/Search_n.jpg"
                OnClick="btnSearch_Click" />
        </td>
    </tr>
</table>

<cc1:autocompleteextender id="AutoCompleteExtender1" runat="server" behaviorid="autoCompleteBehavior1"
    completioninterval="10" completionsetcount="20" delimitercharacters=";," enablecaching="true"
    firstrowselected="true" minimumprefixlength="1" onclientitemselected="SubmitResult"
    servicemethod="GetCompletionList" targetcontrolid="txtBoxSearch" usecontextkey="True">
</cc1:autocompleteextender>
    </ContentTemplate>
</asp:UpdatePanel>
