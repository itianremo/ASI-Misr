<%@ Page language="c#" Inherits="TSN.ERP.WebGUI.Navigation.ContentPage" CodeFile="ContentPage.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ContentPage</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<%--<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />--%>
		<script language="javascript">
		var controlName=-1;
		var employeeID=-1;
		var wndHandle;  // a handle to the opened [pop-up] window. 
		function closeChildWnd()
		{
			if (wndHandle && wndHandle.open)
				wndHandle.close();
		}
		function openEmpWnd(control)   
		{
		window.open("../go/frmPopup.aspx?type=findemp",	"dispwin",
		'resizable=no,scrollbars=yes,menubar=no,height=600,width=800,top=30,left=100');
		}
		function openEmpWnd2(control)   
		{
		window.open("../go/frmPopup.aspx?type=findemp&page=projectlist",	"dispwin",
		'resizable=no,scrollbars=yes,menubar=no,height=600,width=800,top=30,left=100');
		}
		function selectEmp()
		{
			var j=0;
			if (employeeID != -1)
				{		
					for ( j=0;j<= document.getElementById("_ctl0_" + controlName).length-1;j++)
						{
							if (document.getElementById("_ctl0_" + controlName).options[j].value == employeeID)
								{
									document.getElementById( "_ctl0_" + controlName).selectedIndex = j;
									break;
								}
						}
				}
		}
		    
		    if(window.history.forward(1) != null)
			 window.history.forward(1);

		</script>
		<LINK href="../Acc1.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onFocus="selectEmp()" onUnload="closeChildWnd()">
		<form id="Form1" method="post" runat="server">
			<asp:PlaceHolder id="PlaceHolder1" runat="server"></asp:PlaceHolder>
		</form>
		<script language="javascript" type="text/javascript" src="../go/include/dlcalendar.js"></script>
		<script language="javascript" type="text/javascript" src="../go/include/buttons.js"></script>
	</body>
</HTML>
