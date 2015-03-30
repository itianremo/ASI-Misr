
var PageName = 'My Product';
var PageId = 'pff3f778cf2d34a96983be79087601eb6'
document.title = 'My Product';

if (top.location != self.location)
{
	if (parent.HandleMainFrameChanged) {
		parent.HandleMainFrameChanged();
	}
}

var u39 = document.getElementById('u39');

u39.style.cursor = 'pointer';
if (bIE) u39.attachEvent("onclick", Clicku39);
else u39.addEventListener("click", Clicku39, true);
function Clicku39(e)
{

if (true) {

	self.location.href="Download.html" + GetQuerystring();

}

}

var u38 = document.getElementById('u38');

var u37 = document.getElementById('u37');

var u36 = document.getElementById('u36');

var u3 = document.getElementById('u3');

var u34 = document.getElementById('u34');

var u33 = document.getElementById('u33');

var u32 = document.getElementById('u32');

var u31 = document.getElementById('u31');

var u30 = document.getElementById('u30');

var u35 = document.getElementById('u35');

var u29 = document.getElementById('u29');

var u9 = document.getElementById('u9');

var u27 = document.getElementById('u27');

var u26 = document.getElementById('u26');

var u25 = document.getElementById('u25');

var u24 = document.getElementById('u24');

var u23 = document.getElementById('u23');

var u22 = document.getElementById('u22');

var u21 = document.getElementById('u21');

var u20 = document.getElementById('u20');

var u6 = document.getElementById('u6');

u6.style.cursor = 'pointer';
if (bIE) u6.attachEvent("onclick", Clicku6);
else u6.addEventListener("click", Clicku6, true);
function Clicku6(e)
{

if (true) {

	self.location.href="Docs And Videos.html" + GetQuerystring();

}

}

var u19 = document.getElementById('u19');

var u18 = document.getElementById('u18');

var u17 = document.getElementById('u17');

var u16 = document.getElementById('u16');

var u15 = document.getElementById('u15');

var u14 = document.getElementById('u14');

u14.style.cursor = 'pointer';
if (bIE) u14.attachEvent("onclick", Clicku14);
else u14.addEventListener("click", Clicku14, true);
function Clicku14(e)
{

if (true) {

	self.location.href="Orders.html" + GetQuerystring();

}

}

var u13 = document.getElementById('u13');

var u12 = document.getElementById('u12');

u12.style.cursor = 'pointer';
if (bIE) u12.attachEvent("onclick", Clicku12);
else u12.addEventListener("click", Clicku12, true);
function Clicku12(e)
{

if (true) {

	self.location.href="Cloud.html" + GetQuerystring();

}

}

var u11 = document.getElementById('u11');

var u10 = document.getElementById('u10');

u10.style.cursor = 'pointer';
if (bIE) u10.attachEvent("onclick", Clicku10);
else u10.addEventListener("click", Clicku10, true);
function Clicku10(e)
{

if (true) {

	self.location.href="Download.html" + GetQuerystring();

}

}

var u2 = document.getElementById('u2');

u2.style.cursor = 'pointer';
if (bIE) u2.attachEvent("onclick", Clicku2);
else u2.addEventListener("click", Clicku2, true);
function Clicku2(e)
{

if (true) {

	self.location.href="Home.html" + GetQuerystring();

}

}

var u45 = document.getElementById('u45');

var u0 = document.getElementById('u0');

var u5 = document.getElementById('u5');

var u8 = document.getElementById('u8');

u8.style.cursor = 'pointer';
if (bIE) u8.attachEvent("onclick", Clicku8);
else u8.addEventListener("click", Clicku8, true);
function Clicku8(e)
{

if (true) {

	self.location.href="Shopping Cart.html" + GetQuerystring();

}

}

var u1 = document.getElementById('u1');

var u48 = document.getElementById('u48');

var u47 = document.getElementById('u47');

u47.style.cursor = 'pointer';
if (bIE) u47.attachEvent("onclick", Clicku47);
else u47.addEventListener("click", Clicku47, true);
function Clicku47(e)
{

if (true) {

	self.location.href="Add License.html" + GetQuerystring();

}

}

var u46 = document.getElementById('u46');

x = getAbsoluteLeft(u46) + (u46.offsetWidth) - 7;
y = getAbsoluteTop(u46) - 4;
document.body.insertAdjacentHTML("afterBegin", "<img src='Resources/note.gif' id='u46Note' style='cursor:help;position:absolute;z-index:500;left:" + x + ";top:" + y + "'>");

var u46WFECurrent = '';
var u46Note = document.getElementById('u46Note');
if (bIE) u46Note.attachEvent("onclick", u46ToggleWorkflow);
else u46Note.addEventListener("click", u46ToggleWorkflow, true);
document.body.insertAdjacentHTML("afterBegin", 
"<!-- For each bubble on the page generate a div as follows --><div id='u46WF' style='cursor:move; font-family: arial; font-size: 14px; visibility:hidden; position:absolute;' onmousedown=\"StartDrag(event, this.id)\">\n<TABLE WIDTH=100% HEIGHT=100% BORDER=0 CELLPADDING=0 CELLSPACING=0><TR><TD WIDTH=10 HEIGHT=25 ALIGN=left VALIGN=top><IMG SRC='Resources/window_01.gif' WIDTH=10 HEIGHT=25></TD><TD STYLE=\"BACKGROUND-IMAGE:url('Resources/window_02.gif');background-repeat: repeat-x\" HEIGHT=25 ALIGN=left VALIGN=top><IMG SRC='Resources/window_02.gif' WIDTH=5 HEIGHT=25></TD><TD WIDTH=15 HEIGHT=25 ALIGN=left VALIGN=top><IMG SRC='Resources/window_04.gif' WIDTH=15 HEIGHT=25></TD></TR><TR><TD ID='u46WFHeight' STYLE=\"BACKGROUND-IMAGE:url('Resources/window_09.gif');background-repeat: repeat-y\"  WIDTH=10 ALIGN=left VALIGN=top><IMG SRC='Resources/window_05.gif' WIDTH=10 HEIGHT=5></TD><TD>&nbsp;</TD><TD STYLE=\"BACKGROUND-IMAGE:url('Resources/window_07.gif');background-repeat: repeat-y\" WIDTH=15 ALIGN=left VALIGN=top><IMG SRC='Resources/window_07.gif' WIDTH=15 HEIGHT=5></TD></TR><TR><TD WIDTH=10 HEIGHT=10 ALIGN=left VALIGN=top><IMG SRC='Resources/window_10.gif' WIDTH=10 HEIGHT=15></TD><TD STYLE=\"BACKGROUND-IMAGE:url('Resources/window_11.gif');background-repeat: repeat-x\"  HEIGHT=15 ALIGN=left VALIGN=top><IMG SRC='Resources/window_11.gif' WIDTH=5 HEIGHT=15></TD><TD WIDTH=15 HEIGHT=15 ALIGN=left VALIGN=top><IMG SRC='Resources/window_12.gif' WIDTH=15 HEIGHT=15></TD></TR></TABLE><!-- Title --><div id='u46WFLabel' style='cursor:move; position:absolute; z-index:1; width:270; height:15; overflow:hidden' onClick=\"ShowDescription('u46', 'u46base', u46WFECurrent); u46WFECurrent=''\"><strong>?</strong></div>\n<!-- Dialog outline and close button -->\n<img src='Resources/CloseButton.gif' height=13 width=13; id='u46WFClose' style='cursor:pointer; position:absolute;' onclick=\"HideElement('u46WF')\">\n<img src='Resources/window_12.gif' id='u46WFResize' style='position:absolute;z-index:5;cursor:nw-resize' onmousedown=\"SuppressBubble(event);StartResize(event, 'u46WF')\">\n<!-- Div that contains the Workflow Description Box -->\n<iframe frameborder=0 id='u46WFDesc' name='u46WFDesc' style='cursor:auto; border:1px solid #777777; position:absolute; background:white' onmousedown='SuppressBubble(event)'></iframe>\n</div>");
var u46WFD = document.getElementById('u46WFD');
document.body.insertAdjacentHTML("afterBegin", "<div id='u46based' style='z-index:1; visibility:hidden; position:absolute'></div><div id='u46base' style='z-index:1; visibility:hidden; position:absolute'></div>");
var u46based = document.getElementById('u46based');
function u46ToggleWorkflow(event)
{
	ToggleWorkflow(event,'u46', 300, 300, false);
}

u46based.insertAdjacentHTML("beforeEnd", "<div style='cursor:move; font-family: arial; font-size: 14px;'><STRONG>Specification:</STRONG> it will linke to renew page, where user will be able to renew<BR><BR></div>");


var u4 = document.getElementById('u4');

u4.style.cursor = 'pointer';
if (bIE) u4.attachEvent("onclick", Clicku4);
else u4.addEventListener("click", Clicku4, true);
function Clicku4(e)
{

if (true) {

	self.location.href="My Product.html" + GetQuerystring();

	window.location.reload();

}

}

var u44 = document.getElementById('u44');

var u43 = document.getElementById('u43');

x = getAbsoluteLeft(u43) + (u43.offsetWidth) - 7;
y = getAbsoluteTop(u43) - 4;
document.body.insertAdjacentHTML("afterBegin", "<img src='Resources/note.gif' id='u43Note' style='cursor:help;position:absolute;z-index:500;left:" + x + ";top:" + y + "'>");

var u43WFECurrent = '';
var u43Note = document.getElementById('u43Note');
if (bIE) u43Note.attachEvent("onclick", u43ToggleWorkflow);
else u43Note.addEventListener("click", u43ToggleWorkflow, true);
document.body.insertAdjacentHTML("afterBegin", 
"<!-- For each bubble on the page generate a div as follows --><div id='u43WF' style='cursor:move; font-family: arial; font-size: 14px; visibility:hidden; position:absolute;' onmousedown=\"StartDrag(event, this.id)\">\n<TABLE WIDTH=100% HEIGHT=100% BORDER=0 CELLPADDING=0 CELLSPACING=0><TR><TD WIDTH=10 HEIGHT=25 ALIGN=left VALIGN=top><IMG SRC='Resources/window_01.gif' WIDTH=10 HEIGHT=25></TD><TD STYLE=\"BACKGROUND-IMAGE:url('Resources/window_02.gif');background-repeat: repeat-x\" HEIGHT=25 ALIGN=left VALIGN=top><IMG SRC='Resources/window_02.gif' WIDTH=5 HEIGHT=25></TD><TD WIDTH=15 HEIGHT=25 ALIGN=left VALIGN=top><IMG SRC='Resources/window_04.gif' WIDTH=15 HEIGHT=25></TD></TR><TR><TD ID='u43WFHeight' STYLE=\"BACKGROUND-IMAGE:url('Resources/window_09.gif');background-repeat: repeat-y\"  WIDTH=10 ALIGN=left VALIGN=top><IMG SRC='Resources/window_05.gif' WIDTH=10 HEIGHT=5></TD><TD>&nbsp;</TD><TD STYLE=\"BACKGROUND-IMAGE:url('Resources/window_07.gif');background-repeat: repeat-y\" WIDTH=15 ALIGN=left VALIGN=top><IMG SRC='Resources/window_07.gif' WIDTH=15 HEIGHT=5></TD></TR><TR><TD WIDTH=10 HEIGHT=10 ALIGN=left VALIGN=top><IMG SRC='Resources/window_10.gif' WIDTH=10 HEIGHT=15></TD><TD STYLE=\"BACKGROUND-IMAGE:url('Resources/window_11.gif');background-repeat: repeat-x\"  HEIGHT=15 ALIGN=left VALIGN=top><IMG SRC='Resources/window_11.gif' WIDTH=5 HEIGHT=15></TD><TD WIDTH=15 HEIGHT=15 ALIGN=left VALIGN=top><IMG SRC='Resources/window_12.gif' WIDTH=15 HEIGHT=15></TD></TR></TABLE><!-- Title --><div id='u43WFLabel' style='cursor:move; position:absolute; z-index:1; width:270; height:15; overflow:hidden' onClick=\"ShowDescription('u43', 'u43base', u43WFECurrent); u43WFECurrent=''\"><strong>?</strong></div>\n<!-- Dialog outline and close button -->\n<img src='Resources/CloseButton.gif' height=13 width=13; id='u43WFClose' style='cursor:pointer; position:absolute;' onclick=\"HideElement('u43WF')\">\n<img src='Resources/window_12.gif' id='u43WFResize' style='position:absolute;z-index:5;cursor:nw-resize' onmousedown=\"SuppressBubble(event);StartResize(event, 'u43WF')\">\n<!-- Div that contains the Workflow Description Box -->\n<iframe frameborder=0 id='u43WFDesc' name='u43WFDesc' style='cursor:auto; border:1px solid #777777; position:absolute; background:white' onmousedown='SuppressBubble(event)'></iframe>\n</div>");
var u43WFD = document.getElementById('u43WFD');
document.body.insertAdjacentHTML("afterBegin", "<div id='u43based' style='z-index:1; visibility:hidden; position:absolute'></div><div id='u43base' style='z-index:1; visibility:hidden; position:absolute'></div>");
var u43based = document.getElementById('u43based');
function u43ToggleWorkflow(event)
{
	ToggleWorkflow(event,'u43', 300, 300, false);
}

u43based.insertAdjacentHTML("beforeEnd", "<div style='cursor:move; font-family: arial; font-size: 14px;'><STRONG>Specification:</STRONG> System will dispaly the expire data in balck as long as it's active, when the license expire system will display the date in Red<BR><BR></div>");


var u42 = document.getElementById('u42');

var u41 = document.getElementById('u41');

var u40 = document.getElementById('u40');

var u28 = document.getElementById('u28');

var u7 = document.getElementById('u7');

if (window.OnLoad) OnLoad();
