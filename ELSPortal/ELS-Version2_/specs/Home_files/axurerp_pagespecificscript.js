
var PageName = 'Home';
var PageId = 'pc00bf023e99b4e799663b976ac79d527'
document.title = 'Home';

if (top.location != self.location)
{
	if (parent.HandleMainFrameChanged) {
		parent.HandleMainFrameChanged();
	}
}

document.body.insertAdjacentHTML("afterBegin", "<div id='pd0u52NoteContainer' style='position:absolute;left:0;top:0;width:3000;z-index:500'></div>");
document.getElementById('pd0u52NoteContainer').style.visibility = document.getElementById('pd0u52').style.visibility;

var currentStateu52 = document.getElementById("pd0u52")
function SetPanelVisibilityu52(visibility)
{
	document.getElementById("u52").style.visibility = visibility;
	if (visibility == "hidden") {

		document.getElementById("pd0u52").style.visibility = visibility;
		document.getElementById("pd0u52NoteContainer").style.visibility = visibility;
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

var u39 = document.getElementById('u39');

u39.style.cursor = 'pointer';
if (bIE) u39.attachEvent("onclick", Clicku39);
else u39.addEventListener("click", Clicku39, true);
function Clicku39(e)
{

if (true) {

	self.location.href="Add License.html" + GetQuerystring();

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

u9.style.cursor = 'pointer';
if (bIE) u9.attachEvent("onclick", Clicku9);
else u9.addEventListener("click", Clicku9, true);
function Clicku9(e)
{

if (true) {

	self.location.href="Docs And Videos.html" + GetQuerystring();

}

}

var u27 = document.getElementById('u27');

var u26 = document.getElementById('u26');

var u25 = document.getElementById('u25');

var u24 = document.getElementById('u24');

var u23 = document.getElementById('u23');

var u22 = document.getElementById('u22');

var u21 = document.getElementById('u21');

var u20 = document.getElementById('u20');

var u68 = document.getElementById('u68');

x = getAbsoluteLeft(u68) + (u68.offsetWidth) - 7;
y = getAbsoluteTop(u68) - 4;
document.body.insertAdjacentHTML("afterBegin", "<img src='Resources/note.gif' id='u68Note' style='cursor:help;position:absolute;z-index:500;left:" + x + ";top:" + y + "'>");

var u68WFECurrent = '';
var u68Note = document.getElementById('u68Note');
if (bIE) u68Note.attachEvent("onclick", u68ToggleWorkflow);
else u68Note.addEventListener("click", u68ToggleWorkflow, true);
document.body.insertAdjacentHTML("afterBegin", 
"<!-- For each bubble on the page generate a div as follows --><div id='u68WF' style='cursor:move; font-family: arial; font-size: 14px; visibility:hidden; position:absolute;' onmousedown=\"StartDrag(event, this.id)\">\n<TABLE WIDTH=100% HEIGHT=100% BORDER=0 CELLPADDING=0 CELLSPACING=0><TR><TD WIDTH=10 HEIGHT=25 ALIGN=left VALIGN=top><IMG SRC='Resources/window_01.gif' WIDTH=10 HEIGHT=25></TD><TD STYLE=\"BACKGROUND-IMAGE:url('Resources/window_02.gif');background-repeat: repeat-x\" HEIGHT=25 ALIGN=left VALIGN=top><IMG SRC='Resources/window_02.gif' WIDTH=5 HEIGHT=25></TD><TD WIDTH=15 HEIGHT=25 ALIGN=left VALIGN=top><IMG SRC='Resources/window_04.gif' WIDTH=15 HEIGHT=25></TD></TR><TR><TD ID='u68WFHeight' STYLE=\"BACKGROUND-IMAGE:url('Resources/window_09.gif');background-repeat: repeat-y\"  WIDTH=10 ALIGN=left VALIGN=top><IMG SRC='Resources/window_05.gif' WIDTH=10 HEIGHT=5></TD><TD>&nbsp;</TD><TD STYLE=\"BACKGROUND-IMAGE:url('Resources/window_07.gif');background-repeat: repeat-y\" WIDTH=15 ALIGN=left VALIGN=top><IMG SRC='Resources/window_07.gif' WIDTH=15 HEIGHT=5></TD></TR><TR><TD WIDTH=10 HEIGHT=10 ALIGN=left VALIGN=top><IMG SRC='Resources/window_10.gif' WIDTH=10 HEIGHT=15></TD><TD STYLE=\"BACKGROUND-IMAGE:url('Resources/window_11.gif');background-repeat: repeat-x\"  HEIGHT=15 ALIGN=left VALIGN=top><IMG SRC='Resources/window_11.gif' WIDTH=5 HEIGHT=15></TD><TD WIDTH=15 HEIGHT=15 ALIGN=left VALIGN=top><IMG SRC='Resources/window_12.gif' WIDTH=15 HEIGHT=15></TD></TR></TABLE><!-- Title --><div id='u68WFLabel' style='cursor:move; position:absolute; z-index:1; width:270; height:15; overflow:hidden' onClick=\"ShowDescription('u68', 'u68base', u68WFECurrent); u68WFECurrent=''\"><strong>?</strong></div>\n<!-- Dialog outline and close button -->\n<img src='Resources/CloseButton.gif' height=13 width=13; id='u68WFClose' style='cursor:pointer; position:absolute;' onclick=\"HideElement('u68WF')\">\n<img src='Resources/window_12.gif' id='u68WFResize' style='position:absolute;z-index:5;cursor:nw-resize' onmousedown=\"SuppressBubble(event);StartResize(event, 'u68WF')\">\n<!-- Div that contains the Workflow Description Box -->\n<iframe frameborder=0 id='u68WFDesc' name='u68WFDesc' style='cursor:auto; border:1px solid #777777; position:absolute; background:white' onmousedown='SuppressBubble(event)'></iframe>\n</div>");
var u68WFD = document.getElementById('u68WFD');
document.body.insertAdjacentHTML("afterBegin", "<div id='u68based' style='z-index:1; visibility:hidden; position:absolute'></div><div id='u68base' style='z-index:1; visibility:hidden; position:absolute'></div>");
var u68based = document.getElementById('u68based');
function u68ToggleWorkflow(event)
{
	ToggleWorkflow(event,'u68', 300, 300, false);
}

u68based.insertAdjacentHTML("beforeEnd", "<div style='cursor:move; font-family: arial; font-size: 14px;'><STRONG>Specification:</STRONG> will redirect user to the cloud page, and send the licenseTypeID<BR><BR></div>");


u68.style.cursor = 'pointer';
if (bIE) u68.attachEvent("onclick", Clicku68);
else u68.addEventListener("click", Clicku68, true);
function Clicku68(e)
{

if (true) {

	self.location.href="Cloud.html" + GetQuerystring();

}

}

var u67 = document.getElementById('u67');

x = getAbsoluteLeft(u67) + (u67.offsetWidth) - 7;
y = getAbsoluteTop(u67) - 4;
document.body.insertAdjacentHTML("afterBegin", "<img src='Resources/note.gif' id='u67Note' style='cursor:help;position:absolute;z-index:500;left:" + x + ";top:" + y + "'>");

var u67WFECurrent = '';
var u67Note = document.getElementById('u67Note');
if (bIE) u67Note.attachEvent("onclick", u67ToggleWorkflow);
else u67Note.addEventListener("click", u67ToggleWorkflow, true);
document.body.insertAdjacentHTML("afterBegin", 
"<!-- For each bubble on the page generate a div as follows --><div id='u67WF' style='cursor:move; font-family: arial; font-size: 14px; visibility:hidden; position:absolute;' onmousedown=\"StartDrag(event, this.id)\">\n<TABLE WIDTH=100% HEIGHT=100% BORDER=0 CELLPADDING=0 CELLSPACING=0><TR><TD WIDTH=10 HEIGHT=25 ALIGN=left VALIGN=top><IMG SRC='Resources/window_01.gif' WIDTH=10 HEIGHT=25></TD><TD STYLE=\"BACKGROUND-IMAGE:url('Resources/window_02.gif');background-repeat: repeat-x\" HEIGHT=25 ALIGN=left VALIGN=top><IMG SRC='Resources/window_02.gif' WIDTH=5 HEIGHT=25></TD><TD WIDTH=15 HEIGHT=25 ALIGN=left VALIGN=top><IMG SRC='Resources/window_04.gif' WIDTH=15 HEIGHT=25></TD></TR><TR><TD ID='u67WFHeight' STYLE=\"BACKGROUND-IMAGE:url('Resources/window_09.gif');background-repeat: repeat-y\"  WIDTH=10 ALIGN=left VALIGN=top><IMG SRC='Resources/window_05.gif' WIDTH=10 HEIGHT=5></TD><TD>&nbsp;</TD><TD STYLE=\"BACKGROUND-IMAGE:url('Resources/window_07.gif');background-repeat: repeat-y\" WIDTH=15 ALIGN=left VALIGN=top><IMG SRC='Resources/window_07.gif' WIDTH=15 HEIGHT=5></TD></TR><TR><TD WIDTH=10 HEIGHT=10 ALIGN=left VALIGN=top><IMG SRC='Resources/window_10.gif' WIDTH=10 HEIGHT=15></TD><TD STYLE=\"BACKGROUND-IMAGE:url('Resources/window_11.gif');background-repeat: repeat-x\"  HEIGHT=15 ALIGN=left VALIGN=top><IMG SRC='Resources/window_11.gif' WIDTH=5 HEIGHT=15></TD><TD WIDTH=15 HEIGHT=15 ALIGN=left VALIGN=top><IMG SRC='Resources/window_12.gif' WIDTH=15 HEIGHT=15></TD></TR></TABLE><!-- Title --><div id='u67WFLabel' style='cursor:move; position:absolute; z-index:1; width:270; height:15; overflow:hidden' onClick=\"ShowDescription('u67', 'u67base', u67WFECurrent); u67WFECurrent=''\"><strong>?</strong></div>\n<!-- Dialog outline and close button -->\n<img src='Resources/CloseButton.gif' height=13 width=13; id='u67WFClose' style='cursor:pointer; position:absolute;' onclick=\"HideElement('u67WF')\">\n<img src='Resources/window_12.gif' id='u67WFResize' style='position:absolute;z-index:5;cursor:nw-resize' onmousedown=\"SuppressBubble(event);StartResize(event, 'u67WF')\">\n<!-- Div that contains the Workflow Description Box -->\n<iframe frameborder=0 id='u67WFDesc' name='u67WFDesc' style='cursor:auto; border:1px solid #777777; position:absolute; background:white' onmousedown='SuppressBubble(event)'></iframe>\n</div>");
var u67WFD = document.getElementById('u67WFD');
document.body.insertAdjacentHTML("afterBegin", "<div id='u67based' style='z-index:1; visibility:hidden; position:absolute'></div><div id='u67base' style='z-index:1; visibility:hidden; position:absolute'></div>");
var u67based = document.getElementById('u67based');
function u67ToggleWorkflow(event)
{
	ToggleWorkflow(event,'u67', 300, 300, false);
}

u67based.insertAdjacentHTML("beforeEnd", "<div style='cursor:move; font-family: arial; font-size: 14px;'><STRONG>Specification:</STRONG> if there are download files linked to this type, site should show the download link<BR><BR></div>");


u67.style.cursor = 'pointer';
if (bIE) u67.attachEvent("onclick", Clicku67);
else u67.addEventListener("click", Clicku67, true);
function Clicku67(e)
{

if (true) {

	self.location.href="Download.html" + GetQuerystring();

}

}

var u66 = document.getElementById('u66');

u66.style.cursor = 'pointer';
if (bIE) u66.attachEvent("onclick", Clicku66);
else u66.addEventListener("click", Clicku66, true);
function Clicku66(e)
{

if (true) {

	SetPanelVisibilityu52("hidden");

}

}

var u6 = document.getElementById('u6');

var u64 = document.getElementById('u64');

var u63 = document.getElementById('u63');

var u62 = document.getElementById('u62');

var u61 = document.getElementById('u61');

var u60 = document.getElementById('u60');

var u59 = document.getElementById('u59');

var u65 = document.getElementById('u65');

var u19 = document.getElementById('u19');

var u18 = document.getElementById('u18');

var u17 = document.getElementById('u17');

u17.style.cursor = 'pointer';
if (bIE) u17.attachEvent("onclick", Clicku17);
else u17.addEventListener("click", Clicku17, true);
function Clicku17(e)
{

if (true) {

	self.location.href="Orders.html" + GetQuerystring();

}

}

var u16 = document.getElementById('u16');

var u15 = document.getElementById('u15');

u15.style.cursor = 'pointer';
if (bIE) u15.attachEvent("onclick", Clicku15);
else u15.addEventListener("click", Clicku15, true);
function Clicku15(e)
{

if (true) {

	self.location.href="Cloud.html" + GetQuerystring();

}

}

var u14 = document.getElementById('u14');

var u13 = document.getElementById('u13');

u13.style.cursor = 'pointer';
if (bIE) u13.attachEvent("onclick", Clicku13);
else u13.addEventListener("click", Clicku13, true);
function Clicku13(e)
{

if (true) {

	self.location.href="Download.html" + GetQuerystring();

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

	self.location.href="Shopping Cart.html" + GetQuerystring();

}

}

var u10 = document.getElementById('u10');

var u2 = document.getElementById('u2');

var u45 = document.getElementById('u45');

var u0 = document.getElementById('u0');

var u57 = document.getElementById('u57');

var u56 = document.getElementById('u56');

var u5 = document.getElementById('u5');

u5.style.cursor = 'pointer';
if (bIE) u5.attachEvent("onclick", Clicku5);
else u5.addEventListener("click", Clicku5, true);
function Clicku5(e)
{

if (true) {

	self.location.href="Home.html" + GetQuerystring();

	window.location.reload();

}

}

var u54 = document.getElementById('u54');

var u53 = document.getElementById('u53');

var u52 = document.getElementById('u52');

var u8 = document.getElementById('u8');

var u50 = document.getElementById('u50');

var u1 = document.getElementById('u1');

var u49 = document.getElementById('u49');

u49.style.cursor = 'pointer';
if (bIE) u49.attachEvent("onclick", Clicku49);
else u49.addEventListener("click", Clicku49, true);
function Clicku49(e)
{

if (true) {

	self.location.href="Add License.html" + GetQuerystring();

}

}

var u48 = document.getElementById('u48');

var u47 = document.getElementById('u47');

var u46 = document.getElementById('u46');

var u4 = document.getElementById('u4');

var u44 = document.getElementById('u44');

var u43 = document.getElementById('u43');

var u42 = document.getElementById('u42');

var u41 = document.getElementById('u41');

u41.style.cursor = 'pointer';
if (bIE) u41.attachEvent("onclick", Clicku41);
else u41.addEventListener("click", Clicku41, true);
function Clicku41(e)
{

if (true) {

	self.location.href="Download.html" + GetQuerystring();

}

}

var u40 = document.getElementById('u40');

var u58 = document.getElementById('u58');

var u55 = document.getElementById('u55');

var u51 = document.getElementById('u51');

u51.style.cursor = 'pointer';
if (bIE) u51.attachEvent("onclick", Clicku51);
else u51.addEventListener("click", Clicku51, true);
function Clicku51(e)
{

if (true) {

	SetPanelVisibilityu52("");

}

}

var u28 = document.getElementById('u28');

var u7 = document.getElementById('u7');

u7.style.cursor = 'pointer';
if (bIE) u7.attachEvent("onclick", Clicku7);
else u7.addEventListener("click", Clicku7, true);
function Clicku7(e)
{

if (true) {

	self.location.href="My Product.html" + GetQuerystring();

}

}

if (window.OnLoad) OnLoad();
