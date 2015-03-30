<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportRunViewer.aspx.cs" Inherits="Reporting_ReportRunViewer" Title="Report Run" %>

<%@ Register Assembly="Stimulsoft.Report.Web" Namespace="Stimulsoft.Report.Web" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:stiwebviewer id="StiWebViewer1" runat="server" height="80%" width="80%"></cc1:stiwebviewer>
    
    </div>
    </form>
</body>
</html>
