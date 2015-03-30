<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttachFile.aspx.cs" Inherits="AttachFile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>AttachFile</title>

    <script type="text/javascript" language="javascript">
        function btnCancel_onclick() {
           
            window.close();
//            if (window.opener && !window.opener.closed) 
//            {
//               
//                opener.PostBack("AttachToTask");
//            }
        }

        function uploadError(sender, args) {
            document.getElementById('lblStatus').innerText = args.get_fileName(), "<span style='color:red;'>" + args.get_errorMessage() + "</span>";
            //clearContents();
        }

        function StartUpload(sender, args) {
            document.getElementById('lblStatus').innerText = 'Uploading Started.';
        }

        function UploadComplete(sender, args) {
            var filename = args.get_fileName();
            var contentType = args.get_contentType();
            var text = "Size of " + filename + " is " + args.get_length() + " bytes";
            if (contentType.length > 0) {
                text += " and content type is '" + contentType + "'.";
            }
            document.getElementById('lblStatus').innerText = text;
            //clearContents();
        }

        function clearContents() {
            var span = $get("<%=AsyncFileUpload1.ClientID%>");
            var txts = span.getElementsByTagName("input");
            for (var i = 0; i < txts.length; i++) {
                if (txts[i].type == "text") {
                    txts[i].value = "File Uploaded Successfully";
                }
            }

//            var AsyncFileUpload = $get("<%=AsyncFileUpload1.ClientID%>");
//            var txts = AsyncFileUpload.getElementsByTagName("input");
//            for (var i = 0; i < txts.length; i++) {
//                if (txts[i].type == "text") {
//                    txts[i].value = "";
//                    txts[i].style.backgroundColor = "white";
//                }
//            }
//            document.getElementById('lblStatus').innerText = '';
            //document.getElementById(("<%=txtDescription.ClientID%>").value = '';
            //document.getElementById('txtDescription').value = '';
            //window.close();
        }

        function ResetContents() {
            var span = $get("<%=AsyncFileUpload1.ClientID%>");
            var txts = span.getElementsByTagName("input");
            for (var i = 0; i < txts.length; i++) {
                if (txts[i].type == "text") {
                    txts[i].value = "";
                }
            }
        }
        //window.onload = clearContents;

        function PageLoadedHandler() {
            setTimeout(ResetContents, 0);
        }
    </script>

    <style type="text/css">
        .button
        {}
    </style>

</head>

<body onload="PageLoadedHandler()">
    <form id="form1" runat="server"  >
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </cc1:ToolkitScriptManager>
       <div align="center" style="background-color: white">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate><div 
                                                    style="font-weight: bold; font-size: 12px; color: white; font-family: Tahoma;"><div 
                                                    style="vertical-align: bottom; width: 550px; background-color: black;">
                                                   <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                    </asp:ScriptManager>--%>
                                                    <asp:Button  ID="AddAttachment" runat="server" CssClass="button" Text="Add Attachment" onclick="AddAttachment_Click"  OnClientClick="ResetContents()" />

                                                          <input class="button" style="width: 63px; height: 21px" onclick="btnCancel_onclick()"
                        type="button" value="Back" id="Button1" /></div></div>
 </ContentTemplate>
                                            </asp:UpdatePanel>



<%-- add controls here--%>
  <table id="TableData1"  cellpadding="2" cellspacing="2" style="width: 400px; text-align: center;">
                            <tbody>
                                <tr>
                                    <th align="right" colspan="2" style="text-align: left;font-family: tahoma, Verdana, Arial;color: #000000;padding: 0px;border: 0px solid #000000; height: 30px;">
                                        &nbsp;</th>
                                </tr>
                                                                
                                <tr>
                                    <td align="left" style="height: 21px" valign="top">
                                        File
                                    </td>
                                    <td align="left" style="width: 176px;  height: 21px">
                                      <%--  <asp:FileUpload ID="FileUpload1" runat="server" />--%>
                                       <%-- onuploadedcomplete="AsyncFileUpload1_UploadedComplete"--%> 
                                      <div>
    
        <cc1:AsyncFileUpload ID="AsyncFileUpload1" Width="400px" runat="server" 
        OnClientUploadError="uploadError"  
        OnClientUploadStarted="StartUpload" 
        OnClientUploadComplete="UploadComplete"
        CompleteBackColor="Lime" UploaderStyle="Modern" 
        ErrorBackColor="Red"  
        ThrobberID="Throbber"  
         onuploadedcomplete="AsyncFileUpload1_UploadedComplete"
        UploadingBackColor="#66CCFF" />
        
        <asp:Label ID="Throbber" runat="server" Style="display: none">
            <img src="Images/indicator.gif" align="absmiddle" alt="loading" />
        </asp:Label>
                                          <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        
        <asp:Label ID="lblStatus" runat="server" Style="font-family: Arial; font-size: small;"></asp:Label>
    </div>
                                    </td>
                                </tr>
                                <tr >
                                    <td align="left" style="height: 18px" valign="top">
                                        Description
                                    </td>
                                    <td align="left" style="width: 176px; height: 18px">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtDescription" runat="server" Height="50px" 
                                                    TextMode="MultiLine" Width="452px"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                
                            </tbody>
                        </table>


                                                        

                                        </div>
    </form>
</body>
</html>
