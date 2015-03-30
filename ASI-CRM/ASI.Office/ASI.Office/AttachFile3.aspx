<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttachFile3.aspx.cs" Inherits="AttachFile3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>AttachFile</title>
    <script type="text/javascript" language="javascript">
        function btnCancel_onclick() {

            window.close();

        }
        function closeAttach() {
            var addr = window.location.href;
            // alert(addr);
            // addr.split("?")[1].split('&')[1].split("=")[1];
            var textToFind = 'processing';
            var dd;
            var IsCredit = addr.split("?")[1].split('&')[1].split("=")[1]
            if (IsCredit == 'credit') {
                dd = window.opener.parent.frmAccountLists['TabContainer1_TabPanel7_DueDiligance1_ddlCreditCheckStatus'];
            }
            else {
                textToFind = 'recieved';
                dd = window.opener.parent.frmAccountLists['TabContainer1_TabPanel7_DueDiligance1_ddlMasterStatus'];
            }

            //alert(dd1.options[1].text+' dd1');
            //var dd = window.opener.parent.getElementById('TabContainer1_TabPanel7_DueDiligance1_ddlCreditCheckStatus');
            for (var i = 0; i < dd.options.length; i++) {
                if (dd.options[i].text === textToFind) {
                    dd.selectedIndex = i;
                    break;
                }
            }


            //		    window.opener.parent.Form1['TabContainer1_TabPanel7_DueDiligance1_ddlCreditCheckStatus'].value = 'sent';
            //		    window.opener.parent.Form1['TabContainer1_TabPanel7_DueDiligance1_ddlMasterStatus'].value = 'sent';
            //       
            window.close();
        }


        function clearContents() {
            document.getElementById("<% = FileUpload1.ClientID%>").value = "";
            closeAttach();
        }

        function ResetContents() {
            document.getElementById("<% = FileUpload1.ClientID%>").value = "";
            //           
        }


        function PageLoadedHandler() {
            setTimeout(ResetContents, 0);
        }
    </script>
    <style type="text/css">
        .button
        {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" style="background-color: white">
        <div style="font-weight: bold; font-size: 12px; color: white; font-family: Tahoma;">
            <div style="vertical-align: bottom; width: 300px; background-color: black;">
                <asp:Button ID="AddAttachment" runat="server" CssClass="button" Text="Add Attachment"
                    OnClick="AddAttachment_Click" OnClientClick="ResetContents()" />
                <input class="button" style="width: 63px; height: 21px" onclick="btnCancel_onclick()"
                    type="button" value="Back" id="Button1" /></div>
        </div>
        <%-- add controls here--%>
        <table id="TableData1" cellpadding="2" cellspacing="2" style="width: 300px; text-align: center;">
            <tbody>
                <tr>
                    <th align="right" colspan="2" style="text-align: left; font-family: tahoma, Verdana, Arial;
                        color: #000000; padding: 0px; border: 0px solid #000000; height: 30px;">
                        &nbsp;
                    </th>
                </tr>
                <tr>
                    <td align="right" style="height: 21px" valign="top">
                        File
                    </td>
                    <td align="left" style="width: 256px; height: 21px">
                        <div>
                            <asp:Label ID="Throbber" runat="server" Style="display: none">
            <img src="Images/indicator.gif" align="absmiddle" alt="loading" />
                            </asp:Label>
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <br />
                            <asp:Label ID="lblStatus" runat="server" Style="font-family: Arial; font-size: small;"></asp:Label>
                        </div>
                    </td>
                </tr>
                <%--<tr >
                                    <td align="left" style="height: 18px" valign="top">
                                        Description
                                    </td>
                                    <td align="left" style="width: 176px; height: 18px">
                                        
                                                <asp:TextBox ID="txtDescription" runat="server" Height="50px" 
                                                    TextMode="MultiLine" Width="452px"></asp:TextBox>
                                            
                                    </td>
                                </tr>--%>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
