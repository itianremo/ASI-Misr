<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Preview.aspx.cs" Inherits="Preview" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  
 <script language="javascript" type="text/javascript"> 
function closeWindow() { 
if(navigator.appName=="Microsoft Internet Explorer") { 
this.focus();self.opener = this;self.close(); } 
else { window.open('','_parent',''); window.close(); } 
} 
</script> 

 
</head>
<body onfocus="closeWindow();" onload="closeWindow();" onmousemove="closeWindow();">

    <form id="form1"  runat="server">
    
    <div id="PopupDiv" style="z-index: 2; left: 42%; top: 45%; position: absolute; height: 40px;
                                width: auto;">
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="1">
                                    <ProgressTemplate>
                                        <span>
                                            <img src="images/loading.gif" /></span>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
    <div>
    
    </div>
    </form>
</body>
</html>
