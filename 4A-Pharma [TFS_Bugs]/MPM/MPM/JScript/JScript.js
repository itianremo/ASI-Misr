// JScript File
window.onload = function()
{
   	    var b = document.documentElement.clientHeight;
		var f = document.getElementById('Footer').offsetHeight;
		var c = document.getElementById('container').offsetHeight;
	    if ((b-f) > c)
	    {
		    var height = b-f;
			
		    document.getElementById('container').style.height = height+'px' ;
	    }
}

window.onresize = function()
{
   	    var b = document.documentElement.clientHeight;
		var f = document.getElementById('Footer').offsetHeight;
		var c = document.getElementById('container').offsetHeight;
	    if ((b-f) > c)
	    {
		    var height = b-f;
		    document.getElementById('container').style.height = height+'px' ;
	    }
}


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
preloadimages("Images/Home-o.jpg",
              "Images/Home-n.jpg",
			  "Images/Products-o.jpg",
			  "Images/Products-n.jpg",
			  "Images/Physicians-o.jpg",
			  "Images/Physicians-n.jpg",
			  "Images/MedicalAccounts-o.jpg",
			  "Images/MedicalAccounts-n.jpg",
			  "Images/PrivateClinics-o.jpg",
			  "Images/PrivateClinics-n.jpg",
			  "Images/Pharmacies-o.jpg",
			  "Images/Pharmacies-n.jpg",
			  "Images/Users-o.jpg",
			  "Images/Users-n.jpg",
              "Images/add_o.jpg",
              "Images/Edit_o.jpg",
              "Images/Save_o.jpg",
              "Images/cancel-d.jpg",
              "Images/add_n.jpg",
              "Images/Edit_n.jpg",
              "Images/Save_n.jpg",
              "Images/cancel-n.jpg",
              "Images/Search_o.jpg",
              "Images/Search_n.jpg",
              "Images/Reset_o.jpg",
              "Images/Reset_n.jpg",
              "Images/Login-n.png",
              "Images/Login-d.png",
              "Images/Distributors-n.jpg",
              "Images/Distributors-o.jpg",
              "Images/Distributors-s.jpg",
              "Images/manage-applications-n.jpg",
              "Images/manage-applications-o.jpg",
              "Images/manage-applications-s.jpg",
              "Images/Queries-n.jpg",
              "Images/Queries-o.jpg",
              "Images/Queries-s.jpg",
              "Images/Transaction-n.jpg",
              "Images/Transaction-o.jpg",
              "Images/Transaction-s.jpg")


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
