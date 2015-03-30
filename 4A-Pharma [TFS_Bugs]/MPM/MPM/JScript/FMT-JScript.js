// JScript File
//window.onload = function()
//{
//   	    var b = document.documentElement.clientHeight;
//		var f = document.getElementById('Footer').offsetHeight;
//		var c = document.getElementById('container').offsetHeight;
//	    if ((b-f) > c)
//	    {
//		    var height = b-f;
//			
//		    document.getElementById('container').style.height = height+'px' ;
//	    }
//}

//window.onresize = function()
//{
//   	    var b = document.documentElement.clientHeight;
//		var f = document.getElementById('Footer').offsetHeight;
//		var c = document.getElementById('container').offsetHeight;
//	    if ((b-f) > c)
//	    {
//		    var height = b-f;
//		    document.getElementById('container').style.height = height+'px' ;
//	    }

//}

var myimages=new Array();
function preloadimages()
{
	for (i=0;i<preloadimages.arguments.length;i++)
	{
		myimages[i]=new Image()
		myimages[i].src=preloadimages.arguments[i]
	}
}
//Enter path of images to be preloaded inside parenthesis. Extend list as desired.
preloadimages("../Images/Planning-n.jpg",
              "../Images/Planning-o.jpg",
              "../Images/Reporting-n.jpg",
              "../Images/Reporting-o.jpg")

function placeFocus()
{
if (document.forms.length > 0)
{
  for (i = 0; i < document.forms[0].length; i++)
    {
    if ((document.forms[0].elements[i].type == "text"))
    {
    document.forms[0].elements[i].focus();
    break;
    }
   }
  }
}

function Startup() {    
    if(PageStartupFunction != null){
        PageStartupFunction();
    }
}
