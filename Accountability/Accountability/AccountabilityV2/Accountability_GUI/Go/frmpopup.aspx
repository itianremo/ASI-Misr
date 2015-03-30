<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.Go.frmPopup" EnableSessionState="true"
    CodeFile="frmPopup.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>

<%--<title>frmPopup</title>--%>
    <title>|</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">

    <script language="javascript" src="accMethods.js"></script>

    <link href="../Acc1.css" type="text/css" rel="stylesheet">

    <script language="javascript">
	function CloseWnd()
	{
		try
			{
				if(document.getElementById('txt1').value == 1) 
					window.close();
			}
		catch(objectError)
			{
				
			}	
		try
			{
				if (document.getElementById('_ctl0_txtClose').value == 1)  
					window.close();
			}
		catch(objectError)
			{
				
			}	
		
	}
    </script>

</head>
<body onload="CloseWnd()" onunload="opener.isFocused = false;">
    <form id="Form1" method="post" runat="server">
        <asp:PlaceHolder ID="hldTask" runat="server"></asp:PlaceHolder>
        <table cellspacing="0" cellpadding="0" width="600" align="center" border="0">
            <tr>
                <td align="center">
                    &nbsp;
                    <asp:Label ID="lblMsg" runat="server" ForeColor="#C00000" Font-Bold="True"></asp:Label><asp:Panel
                        ID="pnlCloseTask" runat="server" Visible="False">
                        <table id="Table1" cellspacing="2" cellpadding="2" width="100%" border="1">
                            <tr>
                                <td class="headertd" colspan="3" height=23>
                                    Complete Assignment
                                </td>
                            </tr>
                            <tr>
                                <td class="whitetd" colspan="3">
                                    <table cellspacing="0" cellpadding="2" width="100%" border="0" class="FunctionBlock">
                                        <tr>
                                            <td class="formslabels" style="width: 147px" align="right">
                                                Complete/Open task
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTask" runat="server" ReadOnly="True" Width="400px"></asp:TextBox>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="formslabels" style="width: 147px" align="right">
                                                Comment</td>
                                            <td>
                                                <asp:TextBox ID="txtComment" runat="server" Width="400px" Rows="4" TextMode="MultiLine"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtComment"
                                                    ErrorMessage="Required"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:Button ID="btnOk" runat="server" Width="80px" Text="Ok" OnClick="btnOk_Click"></asp:Button>&nbsp;
                                                <label>
                                                    <input onclick="window.close();" type="button" value="Cancel" name="Button" width="80px">
                                                </label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <label>
                            <input id="txt1" style="visibility: hidden" type="text" name="textfield" runat="server">
                        </label>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </form>

    <script language="javascript" src="include/dlcalendar.js" type="text/javascript"></script>

    <script language="javascript" src="include/buttons.js" type="text/javascript"></script>

</body>
</html>
