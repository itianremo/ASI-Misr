<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmConfigurationf.aspx.cs" Inherits="Go_frmConfigurationf" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<link href="../Acc1.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id="Table1" align="center" border="0" cellpadding="1" cellspacing="1" height="800"
            width="300">
            <tr height="20">
                <td colspan="3" style="width: 472px">
                </td>
            </tr>
            <tr valign="top">
                <td colspan="3" style="width: 472px" valign="top">
                    <table id="Table2" border="0" cellpadding="5" cellspacing="5" class="FunctionBlock"
                        width="520">
                        <tr>
                            <td class="headertd" style="text-align: left">
                                Configuration setting</td>
                        </tr>
                        <tr>
                            <td>
                                <div id="divInOut" runat="server" style="text-align: center">
                                    <table id="Table4" border="0" cellpadding="5" cellspacing="5" width="300">
                                        <tr>
                                            <td align="right" class="formslabels">
                                                Key:</td>
                                            <td align="left">
                                                &nbsp;<asp:DropDownList ID="ddlkeys" runat="server" 
                                                    Width="388px" AutoPostBack="True" OnSelectedIndexChanged="ddlkeys_SelectedIndexChanged">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="formslabels" colspan="2">
                                                &nbsp;&nbsp;</td>
                                        </tr>
                                        <tr>
                                        <td align="right" class="formslabels">
                                                Value:</td>
                                            <td align="right" class="formslabels" >
                                                <asp:TextBox ID="txtKey" runat="server" Height="42px" Width="411px"></asp:TextBox>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="formslabels" colspan="2">
                                                <%--<asp:Button ID="btnCheckIn" runat="server" Text="Check In" OnClick="btnCheckIn_Click">
                                                    </asp:Button>--%>
                                                <asp:ImageButton ID="btnUpdateKeyValue" runat="server" ImageUrl="~/Go/images/Buttons/newSave_btn_n.jpg" onmouseover="this.src='../Go/images/Buttons/newSave_btn_o.jpg'"
                                                onmousedown="this.src='../Go/images/Buttons/newSave_btn_s.jpg'" onmouseout="this.src='../Go/images/Buttons/newSave_btn_n.jpg'" OnClick="btnUpdateKeyValue_Click" />&nbsp;<%--<asp:Button ID="btnCheckOut" runat="server" Text="Check Out" OnClick="btnCheckOut_Click">
                                                    </asp:Button>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="formslabels" colspan="2">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="divConfirm" runat="server">
                                    &nbsp;</div>
                                <div id="DivConsimpate" runat="server">
                                </div>
                                <div id="admin" runat="server" align="left">
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
