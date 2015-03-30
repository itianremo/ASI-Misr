<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.MasterForm" CodeFile="MasterForm.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head runat=server>
    <title>Accountability</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <%--<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />--%>
      
    <link rel="SHORTCUT ICON" href="Go/images/Go_Triangle_Logo.ico">

    <script language="javascript" src="Go\accMethods.js"></script>
<%-- <script language="javascript">
    
     var Browser = {  Version: function() 
    {    var version = 0; 
    // we assume a sane browser  
      if (navigator.appVersion.indexOf("MSIE") != -1) 
           // bah, IE again, lets downgrade version number {<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />; }
              version = parseFloat(navigator.appVersion.split("MSIE")[1]); 
              return version;  }}
             // if (Browser.Version() != 8)alert(Browser.Version()+"");
             SetIEVersion(Browser.Version());
             
               </script>--%>
    <script language="javascript">
    
			if (this.name!='fullscreen')
			{ 
			 //window.open('MasterForm.aspx','Accountability','fullscreen=no, width=1280,height=1024,resizable=yes,top=0,left=0');
			
			} 
			if(window.history.forward(1) != null)
			 window.history.forward(1);
			 // close pop-up window if exists
			 function closeff()
			 {
				window.open('logout.aspx?Exit=true');
				
			 }
       

    </script>

</head>
<frameset border="1" framespacing="0" rows="99,*,26" frameborder="no">	    
		<frame Name="Top" src="Navigation/Top.aspx" noResize scrolling="no" frameborder="no">				
		<frame Name="Content" src="Navigation/ContentPage.aspx" noResize scrolling="yes">
		<frame Name="Bottom" src="Navigation/Bottom.aspx" noResize scrolling="no" frameborder="no">		
		<noframes>
		</noframes>
	</frameset>
</html>
