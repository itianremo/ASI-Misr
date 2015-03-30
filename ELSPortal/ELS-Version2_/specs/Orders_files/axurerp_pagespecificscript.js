
var PageName = 'Orders';
var PageId = 'pbf3fad6d2e3f4fa594b5f8b82b090a89'
document.title = 'Orders';

if (top.location != self.location)
{
	if (parent.HandleMainFrameChanged) {
		parent.HandleMainFrameChanged();
	}
}

document.body.insertAdjacentHTML("afterBegin", "<div id='pd0u52NoteContainer' style='position:absolute;left:0;top:0;width:3000;z-index:500'></div>");
document.getElementById('pd0u52NoteContainer').style.visibility = document.getElementById('pd0u52').style.visibility;

document.body.insertAdjacentHTML("afterBegin", "<div id='pd1u52NoteContainer' style='position:absolute;left:0;top:0;width:3000;z-index:500'></div>");
document.getElementById('pd1u52NoteContainer').style.visibility = document.getElementById('pd1u52').style.visibility;

var currentStateu52 = document.getElementById("pd0u52")
function SetPanelVisibilityu52(visibility)
{
	document.getElementById("u52").style.visibility = visibility;
	if (visibility == "hidden") {

		document.getElementById("pd0u52").style.visibility = visibility;
		document.getElementById("pd0u52NoteContainer").style.visibility = visibility;
		document.getElementById("pd1u52").style.visibility = visibility;
		document.getElementById("pd1u52NoteContainer").style.visibility = visibility;
	}
	else {
		currentStateu52.style.visibility = visibility;
		document.getElementById(currentStateu52.id + "NoteContainer").style.visibility = visibility;
	}
}

function SetPanelStateu52(stateid)
{
	SetPanelVisibilityu52("hidden");
	document.getElementById("u52").style.visibility = "";
	currentStateu52 = document.getElementById(stateid);
	currentStateu52.style.visibility = "";
	document.getElementById(stateid + "NoteContainer").style.visibility = "";
}

var u7 = document.getElementById('u7');

var u9 = document.getElementById('u9');

var u49 = document.getElementById('u49');

var u48 = document.getElementById('u48');

var u47 = document.getElementById('u47');

var u46 = document.getElementById('u46');

var u45 = document.getElementById('u45');

var u44 = document.getElementById('u44');

var u43 = document.getElementById('u43');

var u42 = document.getElementById('u42');

var u41 = document.getElementById('u41');

var u40 = document.getElementById('u40');

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

	window.location.reload();

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

var u29 = document.getElementById('u29');

var u28 = document.getElementById('u28');

var u27 = document.getElementById('u27');

var u26 = document.getElementById('u26');

var u25 = document.getElementById('u25');

var u24 = document.getElementById('u24');

var u23 = document.getElementById('u23');

var u22 = document.getElementById('u22');

var u21 = document.getElementById('u21');

var u20 = document.getElementById('u20');

var u0 = document.getElementById('u0');

var u59 = document.getElementById('u59');

var u58 = document.getElementById('u58');

var u57 = document.getElementById('u57');

var u56 = document.getElementById('u56');

var u55 = document.getElementById('u55');

var u54 = document.getElementById('u54');

var u53 = document.getElementById('u53');

var u52 = document.getElementById('u52');

x = getAbsoluteLeft(u52) + (u52.offsetWidth) - 7;
y = getAbsoluteTop(u52) - 4;
document.body.insertAdjacentHTML("afterBegin", "<img src='Resources/note.gif' id='u52Note' style='cursor:help;position:absolute;z-index:500;left:" + x + ";top:" + y + "'>");

var u52WFECurrent = '';
var u52Note = document.getElementById('u52Note');
if (bIE) u52Note.attachEvent("onclick", u52ToggleWorkflow);
else u52Note.addEventListener("click", u52ToggleWorkflow, true);
document.body.insertAdjacentHTML("afterBegin", 
"<!-- For each bubble on the page generate a div as follows --><div id='u52WF' style='cursor:move; font-family: arial; font-size: 14px; visibility:hidden; position:absolute;' onmousedown=\"StartDrag(event, this.id)\">\n<TABLE WIDTH=100% HEIGHT=100% BORDER=0 CELLPADDING=0 CELLSPACING=0><TR><TD WIDTH=10 HEIGHT=25 ALIGN=left VALIGN=top><IMG SRC='Resources/window_01.gif' WIDTH=10 HEIGHT=25></TD><TD STYLE=\"BACKGROUND-IMAGE:url('Resources/window_02.gif');background-repeat: repeat-x\" HEIGHT=25 ALIGN=left VALIGN=top><IMG SRC='Resources/window_02.gif' WIDTH=5 HEIGHT=25></TD><TD WIDTH=15 HEIGHT=25 ALIGN=left VALIGN=top><IMG SRC='Resources/window_04.gif' WIDTH=15 HEIGHT=25></TD></TR><TR><TD ID='u52WFHeight' STYLE=\"BACKGROUND-IMAGE:url('Resources/window_09.gif');background-repeat: repeat-y\"  WIDTH=10 ALIGN=left VALIGN=top><IMG SRC='Resources/window_05.gif' WIDTH=10 HEIGHT=5></TD><TD>&nbsp;</TD><TD STYLE=\"BACKGROUND-IMAGE:url('Resources/window_07.gif');background-repeat: repeat-y\" WIDTH=15 ALIGN=left VALIGN=top><IMG SRC='Resources/window_07.gif' WIDTH=15 HEIGHT=5></TD></TR><TR><TD WIDTH=10 HEIGHT=10 ALIGN=left VALIGN=top><IMG SRC='Resources/window_10.gif' WIDTH=10 HEIGHT=15></TD><TD STYLE=\"BACKGROUND-IMAGE:url('Resources/window_11.gif');background-repeat: repeat-x\"  HEIGHT=15 ALIGN=left VALIGN=top><IMG SRC='Resources/window_11.gif' WIDTH=5 HEIGHT=15></TD><TD WIDTH=15 HEIGHT=15 ALIGN=left VALIGN=top><IMG SRC='Resources/window_12.gif' WIDTH=15 HEIGHT=15></TD></TR></TABLE><!-- Title --><div id='u52WFLabel' style='cursor:move; position:absolute; z-index:1; width:270; height:15; overflow:hidden' onClick=\"ShowDescription('u52', 'u52base', u52WFECurrent); u52WFECurrent=''\"><strong>?</strong></div>\n<!-- Dialog outline and close button -->\n<img src='Resources/CloseButton.gif' height=13 width=13; id='u52WFClose' style='cursor:pointer; position:absolute;' onclick=\"HideElement('u52WF')\">\n<img src='Resources/window_12.gif' id='u52WFResize' style='position:absolute;z-index:5;cursor:nw-resize' onmousedown=\"SuppressBubble(event);StartResize(event, 'u52WF')\">\n<!-- Div that contains the Workflow Description Box -->\n<iframe frameborder=0 id='u52WFDesc' name='u52WFDesc' style='cursor:auto; border:1px solid #777777; position:absolute; background:white' onmousedown='SuppressBubble(event)'></iframe>\n</div>");
var u52WFD = document.getElementById('u52WFD');
document.body.insertAdjacentHTML("afterBegin", "<div id='u52based' style='z-index:1; visibility:hidden; position:absolute'></div><div id='u52base' style='z-index:1; visibility:hidden; position:absolute'></div>");
var u52based = document.getElementById('u52based');
function u52ToggleWorkflow(event)
{
	ToggleWorkflow(event,'u52', 300, 300, false);
}

u52based.insertAdjacentHTML("beforeEnd", "<div style='cursor:move; font-family: arial; font-size: 14px;'><STRONG>Specification:</STRONG> invisable panel, apear when user click&nbsp; details, it will show details for each order<BR><BR></div>");


var u51 = document.getElementById('u51');

u51.style.cursor = 'pointer';
if (bIE) u51.attachEvent("onclick", Clicku51);
else u51.addEventListener("click", Clicku51, true);
function Clicku51(e)
{

if (true) {

	SetPanelStateu52("pd1u52");

}

}

var u50 = document.getElementById('u50');

var u69 = document.getElementById('u69');

var u68 = document.getElementById('u68');

var u67 = document.getElementById('u67');

var u66 = document.getElementById('u66');

var u65 = document.getElementById('u65');

var u64 = document.getElementById('u64');

var u63 = document.getElementById('u63');

var u62 = document.getElementById('u62');

var u61 = document.getElementById('u61');

var u60 = document.getElementById('u60');

var u4 = document.getElementById('u4');

u4.style.cursor = 'pointer';
if (bIE) u4.attachEvent("onclick", Clicku4);
else u4.addEventListener("click", Clicku4, true);
function Clicku4(e)
{

if (true) {

	self.location.href="My Product.html" + GetQuerystring();

}

}

var u38 = document.getElementById('u38');

var u37 = document.getElementById('u37');

var u36 = document.getElementById('u36');

var u35 = document.getElementById('u35');

var u34 = document.getElementById('u34');

var u33 = document.getElementById('u33');

var u32 = document.getElementById('u32');

var u31 = document.getElementById('u31');

var u30 = document.getElementById('u30');

var u1 = document.getElementById('u1');

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

var u79 = document.getElementById('u79');

var u78 = document.getElementById('u78');

var u77 = document.getElementById('u77');

var u76 = document.getElementById('u76');

var u75 = document.getElementById('u75');

var u74 = document.getElementById('u74');

var u73 = document.getElementById('u73');

var u72 = document.getElementById('u72');

var u71 = document.getElementById('u71');

var u70 = document.getElementById('u70');

var u5 = document.getElementById('u5');

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

var u3 = document.getElementById('u3');

var u39 = document.getElementById('u39');

if (window.OnLoad) OnLoad();
