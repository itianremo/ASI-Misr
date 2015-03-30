
var PageName = 'Shopping Cart';
var PageId = 'p40fb3a0056bd4facb63cc3f2f0abf3b4'
document.title = 'Shopping Cart';

if (top.location != self.location)
{
	if (parent.HandleMainFrameChanged) {
		parent.HandleMainFrameChanged();
	}
}

var u39 = document.getElementById('u39');

var u38 = document.getElementById('u38');

var u9 = document.getElementById('u9');

var u36 = document.getElementById('u36');

var u3 = document.getElementById('u3');

var u34 = document.getElementById('u34');

var u33 = document.getElementById('u33');

var u32 = document.getElementById('u32');

var u31 = document.getElementById('u31');

x = getAbsoluteLeft(u31) + (u31.offsetWidth) - 7;
y = getAbsoluteTop(u31) - 4;
document.body.insertAdjacentHTML("afterBegin", "<img src='Resources/note.gif' id='u31Note' style='cursor:help;position:absolute;z-index:500;left:" + x + ";top:" + y + "'>");

var u31WFECurrent = '';
var u31Note = document.getElementById('u31Note');
if (bIE) u31Note.attachEvent("onclick", u31ToggleWorkflow);
else u31Note.addEventListener("click", u31ToggleWorkflow, true);
document.body.insertAdjacentHTML("afterBegin", 
"<!-- For each bubble on the page generate a div as follows --><div id='u31WF' style='cursor:move; font-family: arial; font-size: 14px; visibility:hidden; position:absolute;' onmousedown=\"StartDrag(event, this.id)\">\n<TABLE WIDTH=100% HEIGHT=100% BORDER=0 CELLPADDING=0 CELLSPACING=0><TR><TD WIDTH=10 HEIGHT=25 ALIGN=left VALIGN=top><IMG SRC='Resources/window_01.gif' WIDTH=10 HEIGHT=25></TD><TD STYLE=\"BACKGROUND-IMAGE:url('Resources/window_02.gif');background-repeat: repeat-x\" HEIGHT=25 ALIGN=left VALIGN=top><IMG SRC='Resources/window_02.gif' WIDTH=5 HEIGHT=25></TD><TD WIDTH=15 HEIGHT=25 ALIGN=left VALIGN=top><IMG SRC='Resources/window_04.gif' WIDTH=15 HEIGHT=25></TD></TR><TR><TD ID='u31WFHeight' STYLE=\"BACKGROUND-IMAGE:url('Resources/window_09.gif');background-repeat: repeat-y\"  WIDTH=10 ALIGN=left VALIGN=top><IMG SRC='Resources/window_05.gif' WIDTH=10 HEIGHT=5></TD><TD>&nbsp;</TD><TD STYLE=\"BACKGROUND-IMAGE:url('Resources/window_07.gif');background-repeat: repeat-y\" WIDTH=15 ALIGN=left VALIGN=top><IMG SRC='Resources/window_07.gif' WIDTH=15 HEIGHT=5></TD></TR><TR><TD WIDTH=10 HEIGHT=10 ALIGN=left VALIGN=top><IMG SRC='Resources/window_10.gif' WIDTH=10 HEIGHT=15></TD><TD STYLE=\"BACKGROUND-IMAGE:url('Resources/window_11.gif');background-repeat: repeat-x\"  HEIGHT=15 ALIGN=left VALIGN=top><IMG SRC='Resources/window_11.gif' WIDTH=5 HEIGHT=15></TD><TD WIDTH=15 HEIGHT=15 ALIGN=left VALIGN=top><IMG SRC='Resources/window_12.gif' WIDTH=15 HEIGHT=15></TD></TR></TABLE><!-- Title --><div id='u31WFLabel' style='cursor:move; position:absolute; z-index:1; width:270; height:15; overflow:hidden' onClick=\"ShowDescription('u31', 'u31base', u31WFECurrent); u31WFECurrent=''\"><strong>?</strong></div>\n<!-- Dialog outline and close button -->\n<img src='Resources/CloseButton.gif' height=13 width=13; id='u31WFClose' style='cursor:pointer; position:absolute;' onclick=\"HideElement('u31WF')\">\n<img src='Resources/window_12.gif' id='u31WFResize' style='position:absolute;z-index:5;cursor:nw-resize' onmousedown=\"SuppressBubble(event);StartResize(event, 'u31WF')\">\n<!-- Div that contains the Workflow Description Box -->\n<iframe frameborder=0 id='u31WFDesc' name='u31WFDesc' style='cursor:auto; border:1px solid #777777; position:absolute; background:white' onmousedown='SuppressBubble(event)'></iframe>\n</div>");
var u31WFD = document.getElementById('u31WFD');
document.body.insertAdjacentHTML("afterBegin", "<div id='u31based' style='z-index:1; visibility:hidden; position:absolute'></div><div id='u31base' style='z-index:1; visibility:hidden; position:absolute'></div>");
var u31based = document.getElementById('u31based');
function u31ToggleWorkflow(event)
{
	ToggleWorkflow(event,'u31', 300, 300, false);
}

u31based.insertAdjacentHTML("beforeEnd", "<div style='cursor:move; font-family: arial; font-size: 14px;'><STRONG>Specification:</STRONG> user can change the number of license, system will modify the total after user click update<BR><BR></div>");


var u30 = document.getElementById('u30');

var u35 = document.getElementById('u35');

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

var u72 = document.getElementById('u72');

var u71 = document.getElementById('u71');

var u70 = document.getElementById('u70');

var u69 = document.getElementById('u69');

var u68 = document.getElementById('u68');

var u67 = document.getElementById('u67');

var u66 = document.getElementById('u66');

var u6 = document.getElementById('u6');

var u64 = document.getElementById('u64');

var u63 = document.getElementById('u63');

var u62 = document.getElementById('u62');

var u61 = document.getElementById('u61');

var u60 = document.getElementById('u60');

u60.style.cursor = 'pointer';
if (bIE) u60.attachEvent("onclick", Clicku60);
else u60.addEventListener("click", Clicku60, true);
function Clicku60(e)
{

if (true) {

	self.location.href="Orders.html" + GetQuerystring();

}

}

var u59 = document.getElementById('u59');

var u65 = document.getElementById('u65');

var u19 = document.getElementById('u19');

var u18 = document.getElementById('u18');

var u17 = document.getElementById('u17');

var u16 = document.getElementById('u16');

var u15 = document.getElementById('u15');

var u14 = document.getElementById('u14');

var u13 = document.getElementById('u13');

var u12 = document.getElementById('u12');

var u11 = document.getElementById('u11');

var u10 = document.getElementById('u10');

var u75 = document.getElementById('u75');

var u74 = document.getElementById('u74');

var u73 = document.getElementById('u73');

var u2 = document.getElementById('u2');

var u37 = document.getElementById('u37');

var u45 = document.getElementById('u45');

var u0 = document.getElementById('u0');

var u57 = document.getElementById('u57');

var u56 = document.getElementById('u56');

u56.style.cursor = 'pointer';
if (bIE) u56.attachEvent("onclick", Clicku56);
else u56.addEventListener("click", Clicku56, true);
function Clicku56(e)
{

if (true) {

	self.location.href="Download.html" + GetQuerystring();

}

}

var u5 = document.getElementById('u5');

var u54 = document.getElementById('u54');

u54.style.cursor = 'pointer';
if (bIE) u54.attachEvent("onclick", Clicku54);
else u54.addEventListener("click", Clicku54, true);
function Clicku54(e)
{

if (true) {

	self.location.href="Shopping Cart.html" + GetQuerystring();

	window.location.reload();

}

}

var u53 = document.getElementById('u53');

var u52 = document.getElementById('u52');

u52.style.cursor = 'pointer';
if (bIE) u52.attachEvent("onclick", Clicku52);
else u52.addEventListener("click", Clicku52, true);
function Clicku52(e)
{

if (true) {

	self.location.href="Docs And Videos.html" + GetQuerystring();

}

}

var u8 = document.getElementById('u8');

var u50 = document.getElementById('u50');

u50.style.cursor = 'pointer';
if (bIE) u50.attachEvent("onclick", Clicku50);
else u50.addEventListener("click", Clicku50, true);
function Clicku50(e)
{

if (true) {

	self.location.href="My Product.html" + GetQuerystring();

}

}

var u1 = document.getElementById('u1');

var u49 = document.getElementById('u49');

var u48 = document.getElementById('u48');

u48.style.cursor = 'pointer';
if (bIE) u48.attachEvent("onclick", Clicku48);
else u48.addEventListener("click", Clicku48, true);
function Clicku48(e)
{

if (true) {

	self.location.href="Home.html" + GetQuerystring();

}

}

var u47 = document.getElementById('u47');

var u46 = document.getElementById('u46');

var u4 = document.getElementById('u4');

var u44 = document.getElementById('u44');

x = getAbsoluteLeft(u44) + (u44.offsetWidth) - 7;
y = getAbsoluteTop(u44) - 4;
document.body.insertAdjacentHTML("afterBegin", "<img src='Resources/note.gif' id='u44Note' style='cursor:help;position:absolute;z-index:500;left:" + x + ";top:" + y + "'>");

var u44WFECurrent = '';
var u44Note = document.getElementById('u44Note');
if (bIE) u44Note.attachEvent("onclick", u44ToggleWorkflow);
else u44Note.addEventListener("click", u44ToggleWorkflow, true);
document.body.insertAdjacentHTML("afterBegin", 
"<!-- For each bubble on the page generate a div as follows --><div id='u44WF' style='cursor:move; font-family: arial; font-size: 14px; visibility:hidden; position:absolute;' onmousedown=\"StartDrag(event, this.id)\">\n<TABLE WIDTH=100% HEIGHT=100% BORDER=0 CELLPADDING=0 CELLSPACING=0><TR><TD WIDTH=10 HEIGHT=25 ALIGN=left VALIGN=top><IMG SRC='Resources/window_01.gif' WIDTH=10 HEIGHT=25></TD><TD STYLE=\"BACKGROUND-IMAGE:url('Resources/window_02.gif');background-repeat: repeat-x\" HEIGHT=25 ALIGN=left VALIGN=top><IMG SRC='Resources/window_02.gif' WIDTH=5 HEIGHT=25></TD><TD WIDTH=15 HEIGHT=25 ALIGN=left VALIGN=top><IMG SRC='Resources/window_04.gif' WIDTH=15 HEIGHT=25></TD></TR><TR><TD ID='u44WFHeight' STYLE=\"BACKGROUND-IMAGE:url('Resources/window_09.gif');background-repeat: repeat-y\"  WIDTH=10 ALIGN=left VALIGN=top><IMG SRC='Resources/window_05.gif' WIDTH=10 HEIGHT=5></TD><TD>&nbsp;</TD><TD STYLE=\"BACKGROUND-IMAGE:url('Resources/window_07.gif');background-repeat: repeat-y\" WIDTH=15 ALIGN=left VALIGN=top><IMG SRC='Resources/window_07.gif' WIDTH=15 HEIGHT=5></TD></TR><TR><TD WIDTH=10 HEIGHT=10 ALIGN=left VALIGN=top><IMG SRC='Resources/window_10.gif' WIDTH=10 HEIGHT=15></TD><TD STYLE=\"BACKGROUND-IMAGE:url('Resources/window_11.gif');background-repeat: repeat-x\"  HEIGHT=15 ALIGN=left VALIGN=top><IMG SRC='Resources/window_11.gif' WIDTH=5 HEIGHT=15></TD><TD WIDTH=15 HEIGHT=15 ALIGN=left VALIGN=top><IMG SRC='Resources/window_12.gif' WIDTH=15 HEIGHT=15></TD></TR></TABLE><!-- Title --><div id='u44WFLabel' style='cursor:move; position:absolute; z-index:1; width:270; height:15; overflow:hidden' onClick=\"ShowDescription('u44', 'u44base', u44WFECurrent); u44WFECurrent=''\"><strong>?</strong></div>\n<!-- Dialog outline and close button -->\n<img src='Resources/CloseButton.gif' height=13 width=13; id='u44WFClose' style='cursor:pointer; position:absolute;' onclick=\"HideElement('u44WF')\">\n<img src='Resources/window_12.gif' id='u44WFResize' style='position:absolute;z-index:5;cursor:nw-resize' onmousedown=\"SuppressBubble(event);StartResize(event, 'u44WF')\">\n<!-- Div that contains the Workflow Description Box -->\n<iframe frameborder=0 id='u44WFDesc' name='u44WFDesc' style='cursor:auto; border:1px solid #777777; position:absolute; background:white' onmousedown='SuppressBubble(event)'></iframe>\n</div>");
var u44WFD = document.getElementById('u44WFD');
document.body.insertAdjacentHTML("afterBegin", "<div id='u44based' style='z-index:1; visibility:hidden; position:absolute'></div><div id='u44base' style='z-index:1; visibility:hidden; position:absolute'></div>");
var u44based = document.getElementById('u44based');
function u44ToggleWorkflow(event)
{
	ToggleWorkflow(event,'u44', 300, 300, false);
}

u44based.insertAdjacentHTML("beforeEnd", "<div style='cursor:move; font-family: arial; font-size: 14px;'><STRONG>Specification:</STRONG> when user click on it, system display a delete confirmation message, if you user confirm, system should delete this record<BR><BR></div>");


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

u43based.insertAdjacentHTML("beforeEnd", "<div style='cursor:move; font-family: arial; font-size: 14px;'><STRONG>Specification:</STRONG> update the row total and overall total<BR><BR></div>");


var u42 = document.getElementById('u42');

x = getAbsoluteLeft(u42) + (u42.offsetWidth) - 7;
y = getAbsoluteTop(u42) - 4;
document.body.insertAdjacentHTML("afterBegin", "<img src='Resources/note.gif' id='u42Note' style='cursor:help;position:absolute;z-index:500;left:" + x + ";top:" + y + "'>");

var u42WFECurrent = '';
var u42Note = document.getElementById('u42Note');
if (bIE) u42Note.attachEvent("onclick", u42ToggleWorkflow);
else u42Note.addEventListener("click", u42ToggleWorkflow, true);
document.body.insertAdjacentHTML("afterBegin", 
"<!-- For each bubble on the page generate a div as follows --><div id='u42WF' style='cursor:move; font-family: arial; font-size: 14px; visibility:hidden; position:absolute;' onmousedown=\"StartDrag(event, this.id)\">\n<TABLE WIDTH=100% HEIGHT=100% BORDER=0 CELLPADDING=0 CELLSPACING=0><TR><TD WIDTH=10 HEIGHT=25 ALIGN=left VALIGN=top><IMG SRC='Resources/window_01.gif' WIDTH=10 HEIGHT=25></TD><TD STYLE=\"BACKGROUND-IMAGE:url('Resources/window_02.gif');background-repeat: repeat-x\" HEIGHT=25 ALIGN=left VALIGN=top><IMG SRC='Resources/window_02.gif' WIDTH=5 HEIGHT=25></TD><TD WIDTH=15 HEIGHT=25 ALIGN=left VALIGN=top><IMG SRC='Resources/window_04.gif' WIDTH=15 HEIGHT=25></TD></TR><TR><TD ID='u42WFHeight' STYLE=\"BACKGROUND-IMAGE:url('Resources/window_09.gif');background-repeat: repeat-y\"  WIDTH=10 ALIGN=left VALIGN=top><IMG SRC='Resources/window_05.gif' WIDTH=10 HEIGHT=5></TD><TD>&nbsp;</TD><TD STYLE=\"BACKGROUND-IMAGE:url('Resources/window_07.gif');background-repeat: repeat-y\" WIDTH=15 ALIGN=left VALIGN=top><IMG SRC='Resources/window_07.gif' WIDTH=15 HEIGHT=5></TD></TR><TR><TD WIDTH=10 HEIGHT=10 ALIGN=left VALIGN=top><IMG SRC='Resources/window_10.gif' WIDTH=10 HEIGHT=15></TD><TD STYLE=\"BACKGROUND-IMAGE:url('Resources/window_11.gif');background-repeat: repeat-x\"  HEIGHT=15 ALIGN=left VALIGN=top><IMG SRC='Resources/window_11.gif' WIDTH=5 HEIGHT=15></TD><TD WIDTH=15 HEIGHT=15 ALIGN=left VALIGN=top><IMG SRC='Resources/window_12.gif' WIDTH=15 HEIGHT=15></TD></TR></TABLE><!-- Title --><div id='u42WFLabel' style='cursor:move; position:absolute; z-index:1; width:270; height:15; overflow:hidden' onClick=\"ShowDescription('u42', 'u42base', u42WFECurrent); u42WFECurrent=''\"><strong>?</strong></div>\n<!-- Dialog outline and close button -->\n<img src='Resources/CloseButton.gif' height=13 width=13; id='u42WFClose' style='cursor:pointer; position:absolute;' onclick=\"HideElement('u42WF')\">\n<img src='Resources/window_12.gif' id='u42WFResize' style='position:absolute;z-index:5;cursor:nw-resize' onmousedown=\"SuppressBubble(event);StartResize(event, 'u42WF')\">\n<!-- Div that contains the Workflow Description Box -->\n<iframe frameborder=0 id='u42WFDesc' name='u42WFDesc' style='cursor:auto; border:1px solid #777777; position:absolute; background:white' onmousedown='SuppressBubble(event)'></iframe>\n</div>");
var u42WFD = document.getElementById('u42WFD');
document.body.insertAdjacentHTML("afterBegin", "<div id='u42based' style='z-index:1; visibility:hidden; position:absolute'></div><div id='u42base' style='z-index:1; visibility:hidden; position:absolute'></div>");
var u42based = document.getElementById('u42based');
function u42ToggleWorkflow(event)
{
	ToggleWorkflow(event,'u42', 300, 300, false);
}

u42based.insertAdjacentHTML("beforeEnd", "<div style='cursor:move; font-family: arial; font-size: 14px;'><STRONG>Specification:</STRONG> redirect user to paypal, if user click on it and he had a discount but forgot to click apply, system should apply the discount copoun, system also should recalculate the total to be sure it's right<BR><BR></div>");


u42.style.cursor = 'pointer';
if (bIE) u42.attachEvent("onclick", Clicku42);
else u42.addEventListener("click", Clicku42, true);
function Clicku42(e)
{

if (true) {

	self.location.href="Redirect page.html" + GetQuerystring();

}

}

var u41 = document.getElementById('u41');

var u40 = document.getElementById('u40');

var u58 = document.getElementById('u58');

u58.style.cursor = 'pointer';
if (bIE) u58.attachEvent("onclick", Clicku58);
else u58.addEventListener("click", Clicku58, true);
function Clicku58(e)
{

if (true) {

	self.location.href="Cloud.html" + GetQuerystring();

}

}

var u55 = document.getElementById('u55');

var u51 = document.getElementById('u51');

var u7 = document.getElementById('u7');

if (window.OnLoad) OnLoad();
