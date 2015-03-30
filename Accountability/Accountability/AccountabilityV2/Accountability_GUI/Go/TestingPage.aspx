<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestingPage.aspx.cs" Inherits="Go_TestingPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script language="JavaScript" type="text/javascript">
    //Image zoom in/out script- by javascriptkit.com
    //Visit JavaScript Kit (http://www.javascriptkit.com) for script
    //Credit must stay intact for use

    var zoomfactor=0.05 //Enter factor (0.05=5%)

    function zoomhelper(){
    if (parseInt(whatcache.style.width)>10&&parseInt(whatcache.style.height)>10){
    whatcache.style.width=parseInt(whatcache.style.width)+parseInt(whatcache.style.width)*zoomfactor*prefix
    whatcache.style.height=parseInt(whatcache.style.height)+parseInt(whatcache.style.height)*zoomfactor*prefix
    }
    }

    function zoom(originalW, originalH, what, state){
    if (!document.all&&!document.getElementById)
    return
    whatcache=eval("document.images."+what)
    prefix=(state=="in")? 1 : -1
    if (whatcache.style.width==""||state=="restore"){
    whatcache.style.width=originalW+"px"
    whatcache.style.height=originalH+"px"
    if (state=="restore")
    return
    }
    else{
    zoomhelper()
    }
    beginzoom=setInterval("zoomhelper()",100)
    }

    function clearzoom(){
    if (window.beginzoom)
    clearInterval(beginzoom)
    }
    </script>

    <style type="text/css">
    #imgbox 
    {
        vertical-align : middle;
        position : absolute;
        border: 1px solid #999;
        background : #FFFFFF; 
        filter: Alpha(Opacity=100);
        visibility : hidden;
        height : 200px;
        width : 200px;
        z-index : 50;
        overflow : hidden;
        text-align : center;
    }
    .FunctionBlock {
	font-family: tahoma;
	font-size: 11px;
	color: #FFFFFF;
	text-decoration: none;
	background-color: #28578E;
	background-image: url(c://Blocks_gradient.gif);
	background-repeat: repeat-x;
	background-position: top;
	border: thin solid #FFFFFF;
	}
    </style>

    <script type="text/javascript" language="javascript">
        function getElementLeft(elm) 
        {
            var x = 0;
            //set x to elm’s offsetLeft
            x = elm.offsetLeft;
            //set elm to its offsetParent
            elm = elm.offsetParent;
            //use while loop to check if elm is null
            // if not then add current elm’s offsetLeft to x
            //offsetTop to y and set elm to its offsetParent
            while(elm != null)
            {
                x = parseInt(x) + parseInt(elm.offsetLeft);
                elm = elm.offsetParent;
            }
            return x;
        }
        function getElementTop(elm) 
        {
            var y = 0;
            //set x to elm’s offsetLeft
            y = elm.offsetTop;
            //set elm to its offsetParent
            elm = elm.offsetParent;
            //use while loop to check if elm is null
            // if not then add current elm’s offsetLeft to x
            //offsetTop to y and set elm to its offsetParent
            while(elm != null)
            {
                y = parseInt(y) + parseInt(elm.offsetTop);
                elm = elm.offsetParent;
            }
            return y;
        }
        function Large(obj)
        {
            var imgbox=document.getElementById("imgbox");
            imgbox.style.visibility='visible';
            var img = document.createElement("img");
            img.src=obj.src;
            img.style.width='200px';
            img.style.height='200px';
            
            if(img.addEventListener){
                img.addEventListener('mouseout',Out,false);
            } else {
                img.attachEvent('onmouseout',Out);
            }             
            imgbox.innerHTML='';
            imgbox.appendChild(img);
            imgbox.style.left=(getElementLeft(obj)-0) +'px';
            imgbox.style.top=(getElementTop(obj)-0) + 'px';
        }
        function Out()
        {
            document.getElementById("imgbox").style.visibility='hidden';
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="100%">
            <tr>
                <td>
                    <img id="s" src="images/SubLinks/Time Card Edit_n.jpg" />
                    <img id="Img4" src="images/SubLinks/Time Card Status_n.jpg" />
                    <img id="Img5" src="images/SubLinks/Time Card Status_o.jpg" />
                    <img id="Img6" src="images/SubLinks/Time Card Status_s.jpg" /></td>
            </tr>
            <tr style="background-image: url(c:/imagePS.jpg); color: #FFFFFF; text-align: center;">
                <td style="height: 21px">
                    Hamdy Ahmed
                </td>
            </tr>
        </table>
        <!-- CHANGE 99 to your image width, 100 to image height, and "myimage" to your image's name-->
        <a href="#" onmouseover="zoom(99,100,'myimage','in')" onmouseout="clearzoom()">Zoom
            In</a> | <a href="#" onmouseover="zoom(99,100,'myimage','restore')">Normal</a>
        | <a href="#" onmouseover="zoom(120,60,'myimage','out')" onmouseout="clearzoom()">Zoom
            Out</a>
        <div style="position: relative; width: 99; height: 100">
            <div style="position: absolute">
                <img name="myimage" src="images/dummy.bmp" />
            </div>
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div>
            <img id='img1' src='images/dummy.bmp' onmouseover="Large(this)" />
            <img id='img2' src='images/accountabilityV20_login_bg.jpg' onmouseover="Large(this)"
                width="100px" height="134px" />
            <img id='img3' src='images/ACC login2 copy.jpg' onmouseover="Large(this)" width="100px"
                height="134px" />
            <div id="imgbox">
            </div>
        </div>
        <br />
        <br />
        <br />
        <br />
        <div>
            <table style="background-color: #C1CDDA; width: 100%; background-image: url(c://grad.gif);
                background-repeat: repeat-x; height: 214px;">
                <tr>
                    <td style="height: 47px">
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <br />
        <div style="width: 100%;">
            <table style="width: 100%; background-image: url(c://header.gif); background-repeat: repeat-x;
                background-position: top;">
                <tr>
                    <td style="height: 30px">
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <br />
        <div style="width: 100%;">
            <table style="width: 100%; background-image: url(c://footer.gif); background-repeat: repeat-x;
                background-position: top;">
                <tr>
                    <td style="height: 14px">
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <br />
        <%--<div style="width: 100%; height: 200px;">--%>
        <table class="FunctionBlock" style="height: 47px; width: 100%;">
            <tr>
                <td class="FunctionBlock" style="height: 293px">
                </td>
            </tr>
        </table>
        <%--</div>--%>
        <br />
        <br />
        <br />
        <br />
        <br />
        <div style="width: 800px; height: 600px;">
            <table style="width: 100%; height: 100%;">
                <tr style="width: 100%; height: 100%;">
                    <td style="background-image: url(c://sunset.png); width: 100%; height: 100%;">
                    </td>
                </tr>
            </table>
            Hamdy Ahmed
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div style="width: 800px; height: 600px;">
            <table style="width: 100%; height: 100%;" border="0">
                <tr>
                    <td style="background-image: url(c://RoundedSlice1.png); background-repeat: no-repeat;
                        width: 24px; height: 24px;">
                    </td>
                    <td style="width: 752px; height: 24px; background-color: #e63f3f;">
                    </td>
                    <td style="background-image: url(c://RoundedSlice2.png); background-repeat: no-repeat;
                        width: 24px; height: 24px;">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="width: 752px; height: 552px; background-color: #e63f3f;">
                    </td>
                </tr>
                <tr>
                    <td style="background-image: url(c://RoundedSlice3.png); background-repeat: no-repeat;
                        width: 24px; height: 24px;">
                    </td>
                    <td style="width: 752px; height: 24px; background-color: #e63f3f;">
                    </td>
                    <td style="background-image: url(c://RoundedSlice4.png); background-repeat: no-repeat;
                        width: 24px; height: 24px;">
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
