
var ModalDialogWindow;
var ModalDialogInterval;
var ModalDialog = new Object;
var buttonclicked ='';
ModalDialog.value = '';
ModalDialog.eventhandler = '';
 

function ModalDialogMaintainFocus()
{
  try
  {
    if (ModalDialogWindow.closed)
     {
      // ModalDialogWindow.focus(); 
        window.clearInterval(ModalDialogInterval);
        eval(ModalDialog.eventhandler);       
        return;
     }
     else
     {
     	if(window.opener.closed)
		{
			ModalDialogWindow.close();
		}
		
      //window.clearInterval(ModalDialogInterval);
      //ModalDialogRemoveWatch();
      else
      {
      ModalDialogWindow.focus();
      }
     // window.focus("one");
 
     
     }
    //ModalDialogWindow.focus(); 
  }
  catch (everything) {   }
}
        
 function ModalDialogRemoveWatch()
 {
    ModalDialog.value = '';
    ModalDialog.eventhandler = '';
 }
        
 function ModalDialogShow(Title,BodyText,Buttons,EventHandler)
 {

   ModalDialogRemoveWatch();
   ModalDialog.eventhandler = EventHandler;

    var args ='status=0,menubar=0,resizable=0,width=400,height=125,left=450,top=400';   

   ModalDialogWindow=window.open("","one",args); 
   ModalDialogWindow.document.open(); 
   ModalDialogWindow.document.write('<html>');
   ModalDialogWindow.document.write('<head>');
   ModalDialogWindow.document.write('<LINK href="../go/alertStyle.css" type="text/css" rel="stylesheet">');
   ModalDialogWindow.document.write('<title>' + Title + '</title>');
   ModalDialogWindow.document.write('<script' + ' language=JavaScript>');
   ModalDialogWindow.document.write('window.name = "one";');
   ModalDialogWindow.document.write('var buttonclicked="";');
   ModalDialogWindow.document.write('function CloseForm(Response,x) ');
   ModalDialogWindow.document.write('{ ');
   ModalDialogWindow.document.write(' window.opener.document.getElementById("modalreturn1").value = Response;window.opener.parent.Content.popupIsDisplayed = false; ');
   //Next line is added by Hamdy to prevent the appearance of 2 msg "ok,cancel" and "yes,no,cancel"
   ModalDialogWindow.document.write(' window.opener.parent.Content.popupIsDisplayed = false; ');
   //End
   ModalDialogWindow.document.write(' window.opener.ModalDialog.value = Response; ');
   ModalDialogWindow.document.write(' window.close(); ');
   ModalDialogWindow.document.write(' window.opener.DisplaySaveMessage(x); ');
   ModalDialogWindow.document.write('} ');
   ////// to close the pop-up window when use firfox and close the parent page////////
   ModalDialogWindow.document.write('function MExit() ');
   ModalDialogWindow.document.write('{window.close(self);} ');
   ModalDialogWindow.document.write('window.opener.parent.onunload = MExit;');
  ///////////////

   ModalDialogWindow.document.write('</script' + '>');        
   ModalDialogWindow.document.write('</head>');   
   ModalDialogWindow.document.write('<body onblur="window.focus(\'one\')"; bgcolor=#ECE9D8>');
   ModalDialogWindow.document.write('<table border=0 width="100%" align=center cellspacing=0 cellpadding=2>');
   ModalDialogWindow.document.write('<tr><td align=center colspan=3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>');
   ModalDialogWindow.document.write('<tr><td>&nbsp;&nbsp;&nbsp;&nbsp;</td><td align=center><img src=../go/images/Question.bmp></td><td align=left>Unsaved data will be lost..Do you want to save?</td></tr>');
   ModalDialogWindow.document.write('<tr><td></td><td align=center colspan=2>' + Buttons + '</td></tr>');
   ModalDialogWindow.document.write('</body>');
   ModalDialogWindow.document.write('</html>'); 
   ModalDialogWindow.document.close();
   ModalDialogWindow.focus(); 
   ModalDialogInterval = window.setInterval("ModalDialogMaintainFocus()",50);
   
   //window.setInterval("CloseMe()",10);
}	
  function YesNoCancel(BodyText,EventHandler,x)
  {

     var Buttons=''; 
     if( x == "1" )
     {
		Buttons = '<input type=button value=Yes onclick=CloseForm("Yes","1"),buttonclicked="Yes"; class=slectedbutton >  ';
		Buttons += '<input type=button value=No onclick=CloseForm("No","1"),buttonclicked="no"; class=slectedbutton >  ';
		Buttons += '<input type=button value=Cancel onclick=CloseForm("Cancel","1"),buttonclicked="cancel"; class=slectedbutton >   ';
	}
     
     else if( x == "2" )
     {
		Buttons = '<input type=button value=Yes onclick=CloseForm("Yes","2"),buttonclicked="Yes"; class=slectedbutton >  ';
		Buttons += '<input type=button value=No onclick=CloseForm("No","2"),buttonclicked="no"; class=slectedbutton >  ';
		Buttons += '<input type=button value=Cancel onclick=CloseForm("Cancel","2"),buttonclicked="cancel"; class=slectedbutton >   ';
	}
     
     ModalDialogShow("Dialog",BodyText,Buttons,EventHandler);
     
     
  }
 function YesNoCancelReturnMethod()
 {
   document.getElementById('modalreturn1').value = ModalDialog.value;
   ModalDialogRemoveWatch();
 }

 
 
