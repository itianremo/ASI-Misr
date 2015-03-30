/*
Author: Badrinath Chebbi
Date  : 03-01-02(mm-dd-yy)
Known Bugs: 
1. The script doesnot work on Netscape 4x browsers.
*/		
		//Detect Browser
    	var IE4 = (document.all && !document.getElementById) ? true : false;
        var NS4 = (document.layers) ? true : false;
        var IE5 = (document.all && document.getElementById) ? true : false;
        var N6 = (document.getElementById && !document.all) ? true : false;
		var fontarray = new Array(
	'Arial', 'Arial Black', 'Arial Rounded MT Bold', 
	'Book Antiqua', 'Bookman Old Style', 'Braggadocio', 
	'Britannic Bold','Brooklyn','Brush Script MT', 
	'Carleton', 'Century Gothic','Century Schoolbook','Charcoal','Chicago','CG Times','Colonna MT','Comic Sans MS','Coronet','Courier','Courier New','Cursive Elegant','DawnCastle','Desdemona','Donata','Erie','Expo','Footlight MT Light','Fritzquad','Garamond','Geneva','Georgia','GilbertUltraBold','Gill Sans Condensed Bold','GV Terminal','Haettenschweiler','Helvetica','Humanst521 Cn BT','Impact','Kino MT','Klang MT','Lansbury','Letter Gothic','Lincoln','Matura MT Script Capitals','Merlin','Micro','Minion Web','Modern','Monaco','Motor','Sonoma','Sonoma Italic','Swiss721 BlkEx BT','Times','Times New Roman','Verdana','Wide Latin'
	);	
	var fontstylearray = new Array('normal', 'italic', 'oblique' );
	var fontweightarray = new Array('bold', 'bolder', 'lighter','normal','100','200','300','400','500','600','700','800','900' );	
	var sizearray = new Array('x-small','small','medium','large','x-large','xx-large');
	var relativesizearray = new Array('Larger','Smaller');	
	var selectedfontsize;
	function onreloadfunc()
	{
//checked option is retained for the radio box from the previous page even if the page is refreshed so in the following routine checked option for the radio boxes are cleared and only first radio box is activated***************************************************************
var radioobj=document.getElementsByTagName("INPUT");
	for (i=0;i<=radioobj.length-1;i++)
	{
	if (radioobj[i].name=="radio")
	{
	radioobj[i].removeAttribute("checked");
document.getElementById("absoluteradio").setAttribute("checked","true");	
document.getElementById("absoluteradio").checked="true";
	}
	}
	}
	function init()
	{
	onreloadfunc();
	for (i=0;i<=document.getElementById("sizedivs").childNodes.length-1;i++)
	{
	if (document.getElementById("sizedivs").childNodes[i].nodeType=="1")
	{
	document.getElementById("sizedivs").childNodes[i].style.display="none";
	}
	}
	document.getElementById('absolutediv').style.display="";	
	document.getElementById('fontFamily').value=fontarray[54];
	document.getElementById('fontStyle').value=fontstylearray[1];	
	document.getElementById('fontWeight').value=fontweightarray[12];	
	document.getElementById('Times New Romanfont').style.backgroundColor="000066";			
	document.getElementById('Times New Romanfont').style.color="white";				
	document.getElementById('normalfontstyle').style.backgroundColor="000066";			
	document.getElementById('normalfontstyle').style.color="white";			
	document.getElementById('normalfontweight').style.backgroundColor="000066";			
	document.getElementById('normalfontweight').style.color="white";				
	document.getElementById('mediumfontsize').style.backgroundColor="000066";			
	document.getElementById('mediumfontsize').style.color="white";				
	document.getElementById('previewtext').style.fontFamily=fontarray[54];					
	document.getElementById('previewtext').style.fontStyle=fontstylearray[1];						
	document.getElementById('previewtext').style.fontSize="medium";	
	selectedfontsize=document.getElementById('previewtext').style.fontSize;
	document.getElementById('previewtext').style.fontWeight="normal";														
	}
	
	function showdiv(k)
	{
	//clear the selections from relative and absolute dropdowns when the respective div shows up for the first time*****************************************************************************
	for (t=0;t<=document.getElementById("tablerelativefontsize").rows.length-1;t++)
	{
	document.getElementById("tablerelativefontsize").rows[t].cells[0].style.backgroundColor="white";
	document.getElementById("tablerelativefontsize").rows[t].cells[0].style.color="black";
	}	
	for (s=0;s<=document.getElementById("tableabsolutefontsize").rows.length-1;s++)
	{
	document.getElementById("tableabsolutefontsize").rows[s].cells[0].style.backgroundColor="white";
	document.getElementById("tableabsolutefontsize").rows[s].cells[0].style.color="black";
	}	
//***********************************************************************************************	

	//Set the defaults back into the tags inside div which shows up after selecting length or percentage option*******************************************************************************
	document.getElementById("lengthselectbox").setAttribute("disabled","true");	
	document.getElementById("lengthinputbox").value="Enter the number";		
	document.getElementById("percentageinputbox").value="Enter the number";			
	document.getElementById("lengthselectbox").selectedIndex="0";		
	//*******************************************************************************************
	//Select a field by default******************************************************
	switch (k)
	{
	case "absolute" :
	document.getElementById('mediumfontsize').style.backgroundColor="000066";			
	document.getElementById('mediumfontsize').style.color="white";	
	document.getElementById('previewtext').style.fontSize="medium";								
	break
	case "relative" :
	document.getElementById('Largerrelativefontsize').style.backgroundColor="000066";			
	document.getElementById('Largerrelativefontsize').style.color="white";		
	document.getElementById('previewtext').style.fontSize="Larger";				
	break
	case "length" :
	//Dont do anything
	break
	case "percentage" :
	//Dont do anything
	break
	}
	//*********************************************************************************
	for (i=0;i<=document.getElementById("sizedivs").childNodes.length-1;i++)
	{
	if (document.getElementById("sizedivs").childNodes[i].nodeType=="1")
	{
	document.getElementById("sizedivs").childNodes[i].style.display="none";
	}
	}
	document.getElementById(k+"div").style.display="";
	}
	
	function validatenumber(o,v,evt)
	{
	//v=length or percentage value
		//If only Numeric key is pressed then no alert is displayed
		if (NS4 || N6)
		{
		  if ((evt.which>=48 && evt.which<=57) || evt.which==46)
		{
		document.getElementById("lengthselectbox").removeAttribute("disabled");
		var temp=document.getElementById(v+"selectbox").selectedIndex;
document.getElementById('previewtext').style.fontSize=o.value+document.getElementById(v+"selectbox").options[temp].value;
selectedfontsize=document.getElementById('previewtext').style.fontSize;
		}
		else
		{
		o.value=o.value.substring(o.value,o.value.length-1);
		alert("Enter only number here");
		}
		}
		if (IE4 || IE5)
		{
			  if ((window.event.keyCode>=48 && window.event.keyCode<=57) ||  window.event.keyCode==46)
		{
		document.getElementById("lengthselectbox").removeAttribute("disabled");		
		var temp=document.getElementById(v+"selectbox").selectedIndex;
document.getElementById('previewtext').style.fontSize=o.value+document.getElementById(v+"selectbox").options[temp].value;	
selectedfontsize=document.getElementById('previewtext').style.fontSize;		
		}
		else
		{
		o.value=o.value.substring(o.value,o.value.length-1);		
		alert("Enter only number here");
		}
	}
	}
	
	function set(obj,a)
	{
	switch (a) 
	{
	case "fontFamily" :
	document.getElementById("previewtext").style.fontFamily=obj.innerHTML
	break
	case "fontStyle" :
	document.getElementById("previewtext").style.fontStyle=obj.innerHTML
	break
	case "fontSize" :
	document.getElementById("previewtext").style.fontSize=obj.innerHTML
	selectedfontsize=document.getElementById('previewtext').style.fontSize
	break
	case "fontWeight" :
	document.getElementById("previewtext").style.fontWeight=obj.innerHTML
	break
	}
	
	// a is the property passed viz fontStyle,fontFamily etc
	for (i=0;i<=obj.parentNode.parentNode.rows.length-1;i++)
	{
	obj.parentNode.parentNode.rows[i].cells[0].style.backgroundColor="white";
	obj.parentNode.parentNode.rows[i].cells[0].style.color="black";	
	}
	obj.style.backgroundColor="000066";
	obj.style.color="white";	
	if (document.getElementById(a))
	{
	document.getElementById(a).value=obj.innerHTML;
	}
	document.getElementById("previewtext").a=obj.innerHTML;
	//create a variable to hold the value of fontsize selected. This variable will be used in sendvalue function to send the selected value back to the input box
	selectedfontsize=document.getElementById('previewtext').style.fontSize;
	}
	
	
	function sendvalue()
	{
	var tempvalue="font:"+document.getElementById("fontStyle").value+" "+"normal"+" "+document.getElementById("fontWeight").value+" "+selectedfontsize+" "+"normal"+" "+"\x22"+document.getElementById("fontFamily").value+"\x22";
	document.getElementById("maininputfield").value=tempvalue;
	document.getElementById("maindiv").style.display="none";
	}
