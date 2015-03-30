<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test2.aspx.cs" Inherits="Test2" %>

<%@ Register src="Controls/Attachment.ascx" tagname="Attachment" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <script type="text/javascript" language="javascript">

           function uploadError(sender, args) {
               document.getElementById('lblStatus').innerText = args.get_fileName(), "<span style='color:red;'>" + args.get_errorMessage() + "</span>";
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
           }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
    
    </div>
    
    
    <uc1:Attachment ID="Attachment1" runat="server" />
     <asp:Label ID="Throbber" runat="server" Style="display: none"> <img src="Images/indicator.gif" align="absmiddle" alt="loading" /></asp:Label>
        <asp:TabContainer ID="TabContainer1" runat="server" />
    <asp:TabContainer ID="TabContainer2" runat="server" />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" 
        Enabled="True" TargetControlID="TextBox1">
    </asp:CalendarExtender>
        <br />
        <br />
        <asp:Label ID="lblStatus" runat="server" Style="font-family: Arial; font-size: small;"></asp:Label>
    
    </form>
</body>
</html>
