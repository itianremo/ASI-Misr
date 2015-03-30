
var PageName = 'PayPal';
var PageId = 'p51aa46c69dbc471aa00de0d848741962'
document.title = 'PayPal';

if (top.location != self.location)
{
	if (parent.HandleMainFrameChanged) {
		parent.HandleMainFrameChanged();
	}
}

var u0 = document.getElementById('u0');

if (window.OnLoad) OnLoad();
