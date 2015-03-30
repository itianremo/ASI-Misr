
var PageName = 'Redirect page';
var PageId = 'p22c57c1ca061401faa3006b2d489cf3d'
document.title = 'Redirect page';

if (top.location != self.location)
{
	if (parent.HandleMainFrameChanged) {
		parent.HandleMainFrameChanged();
	}
}

var u7 = document.getElementById('u7');

u7.style.cursor = 'pointer';
if (bIE) u7.attachEvent("onclick", Clicku7);
else u7.addEventListener("click", Clicku7, true);
function Clicku7(e)
{

if (true) {

	self.location.href="Docs And Videos.html" + GetQuerystring();

}

}

var u24 = document.getElementById('u24');

var u1 = document.getElementById('u1');

var u2 = document.getElementById('u2');

var u29 = document.getElementById('u29');

var u28 = document.getElementById('u28');

var u27 = document.getElementById('u27');

var u26 = document.getElementById('u26');

var u25 = document.getElementById('u25');

var u5 = document.getElementById('u5');

u5.style.cursor = 'pointer';
if (bIE) u5.attachEvent("onclick", Clicku5);
else u5.addEventListener("click", Clicku5, true);
function Clicku5(e)
{

if (true) {

	self.location.href="My Product.html" + GetQuerystring();

}

}

var u9 = document.getElementById('u9');

u9.style.cursor = 'pointer';
if (bIE) u9.attachEvent("onclick", Clicku9);
else u9.addEventListener("click", Clicku9, true);
function Clicku9(e)
{

if (true) {

	self.location.href="Shopping Cart.html" + GetQuerystring();

}

}

var u19 = document.getElementById('u19');

var u8 = document.getElementById('u8');

var u6 = document.getElementById('u6');

var u16 = document.getElementById('u16');

var u15 = document.getElementById('u15');

u15.style.cursor = 'pointer';
if (bIE) u15.attachEvent("onclick", Clicku15);
else u15.addEventListener("click", Clicku15, true);
function Clicku15(e)
{

if (true) {

	self.location.href="Orders.html" + GetQuerystring();

}

}

var u0 = document.getElementById('u0');

var u13 = document.getElementById('u13');

u13.style.cursor = 'pointer';
if (bIE) u13.attachEvent("onclick", Clicku13);
else u13.addEventListener("click", Clicku13, true);
function Clicku13(e)
{

if (true) {

	self.location.href="Cloud.html" + GetQuerystring();

}

}

var u12 = document.getElementById('u12');

var u11 = document.getElementById('u11');

u11.style.cursor = 'pointer';
if (bIE) u11.attachEvent("onclick", Clicku11);
else u11.addEventListener("click", Clicku11, true);
function Clicku11(e)
{

if (true) {

	self.location.href="Download.html" + GetQuerystring();

}

}

var u10 = document.getElementById('u10');

var u14 = document.getElementById('u14');

var u18 = document.getElementById('u18');

var u17 = document.getElementById('u17');

var u23 = document.getElementById('u23');

var u22 = document.getElementById('u22');

var u21 = document.getElementById('u21');

var u20 = document.getElementById('u20');

var u4 = document.getElementById('u4');

var u3 = document.getElementById('u3');

u3.style.cursor = 'pointer';
if (bIE) u3.attachEvent("onclick", Clicku3);
else u3.addEventListener("click", Clicku3, true);
function Clicku3(e)
{

if (true) {

	self.location.href="Home.html" + GetQuerystring();

}

}

if (window.OnLoad) OnLoad();
