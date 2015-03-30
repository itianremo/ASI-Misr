<%@ Register TagPrefix="uc1" TagName="UC_Top" Src="UC_Top.ascx" %>

<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.Navigation.Top" CodeFile="Top.aspx.cs" %>

<%@ Register TagPrefix="uc1" TagName="UC_Left" Src="UC_Left.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <%--<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />--%>
    <style type="text/css">
    .style1 {font-weight: bold}
    </style>
    <link href="../Acc1.css" type="text/css" rel="stylesheet">

    <script src="../Go/JsAlert.js"></script>

    <script language="javascript">			
var url="";				
function DisplaySaveMessage( x )
{
	if ( (x == "2" && parent.Content.isModified != true) && (x == "2" && parent.Content.NoteFlage!=true ) )
	{
		window.parent.location.href = url;	
	}				
	if( parent.Content.isModified )
	{	
		//YesNoCancel('','YesNoCancelReturnMethod()')
		var answer = document.getElementById('modalreturn1').value;
		//var answer = confirm("Unsaved data will be lost .. Do you want to save")	
		if (answer == "Yes" ) 
		{ 
			parent.Content.saveSheet(); 
			document.getElementById('modalreturn1').value = "";
			
			if( x == "1" )
				document.getElementById('ButtonAccSave').click(); 
			else if( x == "2" )
				 window.parent.location.href = url;	
			return true; 
		}
		else if (answer == "No" ) 
		{	
			document.getElementById('modalreturn1').value = "";
			if( x == "1" )
    				document.getElementById('ButtonAccSave').click(); 
    			else if( x == "2" )
    				 window.parent.location.href = url;	    				 
    				 //Added by Hamdy Ahmed on 06_11_2007
    				 parent.Content.isModified = false;
    				 ////////////////////////////////////
    				 return true;					
		}
		else if (answer == "Cancel" )
		{
			document.getElementById('modalreturn1').value = "";
			return false;   	
		}
		//Call popup
		else
		{				
			parent.Content.popupIsDisplayed = true;					
			document.getElementById('modalreturn1').value = "";
			YesNoCancel('','YesNoCancelReturnMethod()',x);			
			return true;   	
		}				
		/*
		if (answer) 
		{ 
    			parent.Content.saveSheet(); 
    			return true; 
		}
		else
			return false;   	
		  */			
		}
	    // check notes modified 
	    if(parent.Content.currentDay!=-1 && parent.Content.NoteFlage==true)
	    {
		    /*answer2 = confirm("!! Unsaved notes will be lost .. Do you want to save it");if(answer2){parent.Content.saveSheet();}else{return false;}*/	   		
		    answer2 = document.getElementById('modalreturn1').value;		
		    if (answer2 == "Yes" ) 
		    { 
			    parent.Content.saveSheet(); 
			    document.getElementById('modalreturn1').value = "";    			
			    if( x == "1" )
				    document.getElementById('ButtonAccSave').click(); 
			    else if( x == "2" )
				     window.parent.location.href = url;	
			    return true; 
		    }
		    else if (answer2 == "No" ) 
		    {	
			    document.getElementById('modalreturn1').value = "";
			    if( x == "1" )
    	            document.getElementById('ButtonAccSave').click(); 
    			else if( x == "2" )
				     window.parent.location.href = url;    				 
				     //Added by Hamdy Ahme don 06_11_2007
				     parent.Content.isModified = false;
				     ////////////////////////////////////
    				 return true;     			
		    }
		    else if (answer2 == "Cancel" )
		    {
			    document.getElementById('modalreturn1').value = "";
			    return false;   	
		    }
		    else
		    {
			    document.getElementById('modalreturn1').value = "";
			    YesNoCancel('','YesNoCancelReturnMethod()',x);
			    return true;   	
		    }
	}
	
	
}
		
		/////////////////////////////////////////////////////
		function changeLink( x )
		{
////////////////////			for ( i = 0 ; i <  document.anchors.length ; i++ )
////////////////////			{
////////////////////				var s = document.anchors[ i ].id 
////////////////////				var t = s.match('Func');
////////////////////				if ( t == 'Func' )
////////////////////				{
////////////////////					document.getElementById( s ).style.color = "#3d3d3d" 	
////////////////////					//This is to change the image of the link from selected state to normal state
////////////////////                    var oldSrc = document.getElementById( s ).children[0].getAttribute('src');
////////////////////                    var newSrc = oldSrc.replace('_s.gif','_n.jpg');
////////////////////                    document.getElementById( s ).children[0].setAttribute('src',newSrc);
////////////////////                    /////////////////////////////////////////////////////////////////////////////
////////////////////				}
////////////////////			}  	
////////////////////			document.getElementById(x).style.color = "#993300" 
////////////////////			//This is to change the image of the link from normal state to selected state
////////////////////			var oldSrc = document.getElementById( x ).children[0].getAttribute('src');
////////////////////            var newSrc = oldSrc.replace('_n.jpg','_s.gif');
////////////////////            document.getElementById( x ).children[0].setAttribute('src',newSrc);	
////////////////////            ////////////////////////////////////////////////////////////////////////////////
            var screenName = document.getElementById(x).getAttribute('title');	            
            document.getElementById('lblScreenName').innerHTML = screenName;
		}
		
		var wndHandle; 
		function openWindow()
		{
		  
		 // window.open('','window','width=750,height=500,top=0,left=200,status=yes,scrollbars=yes');
			
		  if ( wndHandle && wndHandle.open && wndHandle.closed)
		    wndHandle.close();
		  wndHandle=open('','window','width=750,height=500,top=0,left=200,status=yes,scrollbars=yes,resizable=yes');
		  wndHandle.location.href = "HelpDetails.aspx";
		  if (wndHandle.opener == null) 
		   wndHandle.opener = self;		
		}
		if(window.history.forward(1) != null)
			 window.history.forward(1);
			 
		 function CallLogOut()
		 {
		 var checkClosed = false;
			if(window.parent.location == null)
			{
				checkClosed= true;
			}
			Top.LogOut(checkClosed);
		 }
		 function closePage()
		 {
		    window.parent.close();
		 }

		
    </script>

</head>
<body onunload="CallLogOut();">
    <form id="Form1" method="post" runat="server">
        <table width="100%" align="center" cellpadding="0" cellspacing="0" class="toptd">
            <tr>
                <td width="100" height="63" rowspan="2" valign="top" class="Accountabiltylabel">
                    <img src="../Go/images/NewLogo.GIF" width="100" height="63" class="style1" />
                </td>
                <td valign="top">
                    <table width="100%">
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblScreenName" runat="server" CssClass="formslabels"></asp:Label></td>
                            <td align="right">
                                <%--<strong>Home &nbsp;&nbsp;&nbsp;Change Password&nbsp;&nbsp;&nbsp; Log off</strong>&nbsp;&nbsp;&nbsp;
                    <img src="../Go/images/logoff.gif" width="19" height="20" hspace="2" vspace="3" align="absmiddle" />
                    <img src="../Go/images/home.gif" width="21" height="20" hspace="2" vspace="3" align="absmiddle" />
                    <img src="../Go/images/help.gif" width="21" height="20" hspace="2" vspace="3" align="absmiddle" />--%>
                                <%-- <asp:HyperLink ID="HyperLink1" onclick="url='../UserModules.aspx?home=yes',DisplaySaveMessage('2' )"
                                    runat="server" CssClass="unselectedsublinks" ForeColor="White">Home </asp:HyperLink>
                                |
                                <asp:HyperLink ID="HyperLink2" onclick="url='../SecurityManagement/frmChangePass.aspx?ChangePassword=yes',DisplaySaveMessage('2' )"
                                    runat="server" CssClass="unselectedsublinks" ForeColor="White">Change Password </asp:HyperLink>
                                |
                                <asp:HyperLink ID="HyperLink3" onclick="url='../index.aspx?logoff=logoff',DisplaySaveMessage('2' )"
                                    runat="server" CssClass="unselectedsublinks" ForeColor="White">Log off</asp:HyperLink>--%>
                                <%-- <img src="../Go/images/home_new.gif" width="21" height="20" hspace="2" vspace="3" align="absmiddle"
                        onclick="url='../UserModules.aspx?home=yes',DisplaySaveMessage('2' )" alt="Home" />
                    <img src="../Go/images/logoff.gif" width="19" height="20" hspace="2" vspace="3" align="absmiddle"
                        onclick="url='../SecurityManagement/frmChangePass.aspx?ChangePassword=yes',DisplaySaveMessage('2' )" />--%>
                                <img src="../Go/images/PageTopToolbar/help_n.jpg" hspace="2" vspace="3" align="absmiddle"
                                    alt="Help" onclick="openWindow()" style="cursor: hand;" />
                                <img src="../Go/images/PageTopToolbar/close_n.jpg" hspace="2" vspace="3" align="absmiddle"
                                    alt="Log off" onclick="url='../index.aspx?logoff=logoff',DisplaySaveMessage('2' )"
                                    style="cursor: hand;" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="bgtoplinks" colspan="2" style="height: 27px">
                    <!---->
                    <table cellpadding="0" cellspacing="0">
                        <tr id="TD1" runat="server">
                        </tr>
                    </table>
                    </td>
            </tr>
        </table>
        <table width="100%" id="tblSubLinks" runat="server">
            <tr>
                <td id="TD2" runat="server" class="bgsublinks">
                </td>
            </tr>
        </table>
        <asp:Button ID="ButtonAccSave" runat="server" Text="Button" CssClass="invisableButton"
            OnClick="ButtonAccSave_Click"></asp:Button>
        <input id="modalreturn1" style="z-index: 101; left: 0px; position: absolute; top: 152px"
            type="hidden" />
    </form>
</body>
</html>
