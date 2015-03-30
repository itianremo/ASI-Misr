<%@ Page Language="C#" AutoEventWireup="true" CodeFile="html.aspx.cs" Inherits="html" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    function xx(){
 window.open('test2.aspx','','toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,left=0px, top=0px,width=1024, height=768');
var windowObject = window.self;
windowObject.opener = window.self;
windowObject.close();
// window.close();

 }
    </script>
</head>
<body >
    <form id="form1" runat="server">
    <div>
        <input id="Submit1" onclick="xx();" type="submit" value="submit" /></div>
    </form>
</body>
</html>
