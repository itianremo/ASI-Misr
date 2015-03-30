<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.Go.flowcharts.frmColors" CodeFile="frmColors.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>frmColors</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
     <link href="../../Acc1.css" type="text/css" rel="stylesheet">
    
    <style type="text/css">
		.Border { BORDER-RIGHT: #003366 1px solid; BORDER-TOP: #003366 1px solid; BORDER-LEFT: #003366 1px solid; BORDER-BOTTOM: #003366 1px solid }
		.style5 { FONT-WEIGHT: bold; COLOR: #003366 }
		</style>
   

    <script language="javascript" src="color_conv.js"></script>

    <script type="text/JavaScript">
		

var elemName="";
var fontIndex=-1;
var fontarray = new Array(
	'Arial', 'Arial Black', 'Arial Rounded MT Bold', 
	'Book Antiqua', 'Bookman Old Style', 'Braggadocio', 
	'Britannic Bold','Brooklyn','Brush Script MT', 
	'Carleton', 'Century Gothic','Century Schoolbook','Charcoal','Chicago','CG Times','Colonna MT','Comic Sans MS','Coronet','Courier','Courier New','Cursive Elegant','DawnCastle','Desdemona','Donata','Erie','Expo','Footlight MT Light','Fritzquad','Garamond','Geneva','Georgia','GilbertUltraBold','Gill Sans Condensed Bold','GV Terminal','Haettenschweiler','Helvetica','Humanst521 Cn BT','Impact','Kino MT','Klang MT','Lansbury','Letter Gothic','Lincoln','Matura MT Script Capitals','Merlin','Micro','Minion Web','Modern','Monaco','Motor','Sonoma','Sonoma Italic','Swiss721 BlkEx BT','Times','Times New Roman','Verdana','Wide Latin'
	);	
function MM_openBrWindow(ss)
{
if(document.getElementById(ss).name=='txtArrow')
{
elemName = 'txtArrow';
}
else if(document.getElementById(ss).name=='txtDeptBrdr')
{
elemName = 'txtDeptBrdr';
}
else if(document.getElementById(ss).name=='txtDeptBack')
{
elemName = 'txtDeptBack';
}
else if(document.getElementById(ss).name=='txtDeptName')
{
elemName = 'txtDeptName';
}
else if(document.getElementById(ss).name=='txtDeptEmpNo')
{
elemName = 'txtDeptEmpNo';
}
else if(document.getElementById(ss).name=='txtDeptManager')
{
elemName = 'txtDeptManager';
}
else if(document.getElementById(ss).name=='txtJobBack')
{
elemName = 'txtJobBack';
}
else if(document.getElementById(ss).name=='txtJobBrdr')
{
elemName = 'txtJobBrdr';
}
else if(document.getElementById(ss).name=='txtJobName')
{
elemName = 'txtJobName';
}
else if(document.getElementById(ss).name=='txtJobEmpNo')
{
elemName = 'txtJobEmpNo';
}
else if(document.getElementById(ss).name=='txtTeamBack')
{
elemName = 'txtTeamBack';
}
else if(document.getElementById(ss).name=='txtTeamBrdr')
{
elemName = 'txtTeamBrdr';
}
else if(document.getElementById(ss).name=='txtTeamName')
{
elemName = 'txtTeamName';
}
else if(document.getElementById(ss).name=='txtTeamEmpNo')
{
elemName = 'txtTeamEmpNo';
}
else if(document.getElementById(ss).name=='txtTeamLeader')
{
elemName = 'txtTeamLeader';
}
else if(document.getElementById(ss).name=='txtProjectBack')
{
elemName = 'txtProjectBack';
}
else if(document.getElementById(ss).name=='txtProjectBrdr')
{
elemName = 'txtProjectBrdr';
}
else if(document.getElementById(ss).name=='txtProjectName')
{
elemName = 'txtProjectName';
}
else if(document.getElementById(ss).name=='txtProjectEmpNo')
{
elemName = 'txtProjectEmpNo';
}
else if(document.getElementById(ss).name=='txtProjectManager')
{
elemName = 'txtProjectManager';
}
else if(document.getElementById(ss).name=='txtEmpBack')
{
elemName = 'txtEmpBack';
}
else if(document.getElementById(ss).name=='txtEmpBrdr')
{
elemName = 'txtEmpBrdr';
}
else if(document.getElementById(ss).name=='txtEmpName')
{
elemName = 'txtEmpName';
}
else if(document.getElementById(ss).name=='txtEmpDept')
{
elemName = 'txtEmpDept';
}
else if(document.getElementById(ss).name=='txtEmpTitle')
{
elemName = 'txtEmpTitle';
}
else if(document.getElementById(ss).name=='txtEmpCode')
{
elemName = 'txtEmpCode';
}
else if(document.getElementById(ss).name=='txtEmpProject')
{
elemName = 'txtEmpProject';
}
else if(document.getElementById(ss).name=='txtEmpTeams')
{
elemName = 'txtEmpTeams';
}

fnShowChooseColorDlg(document.getElementById(ss).value,"");

}
//function MM_openBrWindow(theURL,winName,features) 
//{ //v2.0
 // window.open(theURL,winName,features);
  
//}

function OnChangeColor(color)
{
	document.getElementById(elemName).style.backgroundColor = color;
	document.getElementById(elemName).value = color;
	document.getElementById(elemName).text = color;
	document.getElementById(elemName).style.color = color;
	
}
function OnChangeFont(fontFamily,fontSize)
{
	document.getElementById("txtFamiliy" + fontIndex).value = fontFamily;
	document.getElementById("txtSize" + fontIndex).value = fontSize;
}
function enable_disable_buttons()
{

var item;
var elem = document.getElementById("Form1").elements;
for(i=0;i<elem.length; i++)
{
	//alert(elem.length);
	if(elem[i].type=="button")
	{
		item = document.getElementById(elem[i].id);
		if(item.disabled==true)
		{
			//item.className = "btn1";
		} 
		else
		{
			item.className = "btn";
		}
	}
 }
}

//-->3
    </script>

    <link href="styles.css" type="text/css" rel="stylesheet">
    <style type="text/css">
		.style7 { FONT-SIZE: 16px; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
		.style8 { FONT-SIZE: 12px }
		</style>
</head>
<body onload="enable_disable_buttons();" dir="ltr">
    <form id="Form1" method="post" runat="server">
        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
         <tr>
                                        <td align="left"> &nbsp;&nbsp;<asp:Button ID="btnBack" runat="server" Text="Back" CssClass="slectedbutton" OnClick="btnBack_Click">
                                            </asp:Button>
                                            <asp:Button ID="btnView" runat="server" Text="View" CssClass="slectedbutton" OnClick="btnView_Click">
                                            </asp:Button></td>
                                    </tr>
            <tr>
                <td class="blue" bgcolor="#eaeaea">
                    <span class="style7"><span class="partLabel">Part 3 </span></span><span class="parttitle">
                        : Colors and layout</span>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td class="style5" align="right">
                                <table width="100%" border="0" cellspacing="0" cellpadding="10">
                                <tr height=2px>
                                <td height=2px align=center>
                                 
                                    <asp:Label ID="lblNote" runat="server"  CssClass="inputtext"  Visible="False" Width="344px"></asp:Label></td>
                                </tr>
                                   
                                    <tr>
                                        <td>
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0" class="FunctionBlock">
                                                <tr>
                                                    <td colspan="3" class="headertd" style="text-align:left;height:23px;">
                                                        <span class="formslabels">Layout</span></td>
                                                </tr>
                                                <tr>
                                                    <td class="formslabels" width="203" style="width: 203px;text-align:right; height: 22px;">
                                                        Tree layout type
                                                    </td>
                                                    <td width="38%" style="height: 22px">
                                                        &nbsp;<asp:DropDownList ID="lstLayoutType" runat="server" CssClass="inputtext" Width="150px">
                                                            <asp:ListItem Value="1">Border aligned</asp:ListItem>
                                                            <asp:ListItem Value="2" Selected="True">Centeralized</asp:ListItem>
                                                            <asp:ListItem Value="3">Radial</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                    <td width="45%" style="height: 22px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="formslabels" style="width: 203px; height: 27px;text-align:right">
                                                        Tree Direction
                                                    </td>
                                                    <td style="height: 27px">
                                                        &nbsp;<asp:DropDownList ID="lstTreeDir" runat="server" CssClass="inputtext" Width="150px">
                                                            <asp:ListItem Value="1" Selected="True">Bottom to top</asp:ListItem>
                                                            <asp:ListItem Value="2">Top to bottom</asp:ListItem>
                                                            <asp:ListItem Value="3">Left to right</asp:ListItem>
                                                            <asp:ListItem Value="4">Right to left</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                    <td style="height: 27px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="formslabels" style="width: 203px;text-align:right">
                                                        Arrow Type
                                                    </td>
                                                    <td>
                                                        &nbsp;<asp:DropDownList ID="lstArrowType" runat="server" CssClass="inputtext" Width="150px">
                                                            <asp:ListItem Value="1">Horizontal</asp:ListItem>
                                                            <asp:ListItem Value="2" Selected="True">Vertical</asp:ListItem>
                                                            <asp:ListItem Value="3">Rounded</asp:ListItem>
                                                            <asp:ListItem Value="4">Straight</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table cellspacing="0" cellpadding="0" width="100%"
                                                align="center" border="0" class="FunctionBlock">
                                                <tr>
                                                    <td class="headertd" style="text-align:left;height:23px;">
                                                        <span class="formslabels">General</span></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td class="formslabels" style="text-align:right;">
                                                                    Arrow
                                                                </td>
                                                                <td width="45%">
                                                                    &nbsp;
                                                                    <fieldset style="width: 192px; height: 59px;border:solid 1 #FFFFFF">
                                                                        <legend style="color: #ffffff">Color </legend>
                                                                        <table cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <input id="txtArrow" style="color: #000000; background-color: #000000" readonly type="text"
                                                                                        size="6" value="000000" name="textfield3" runat="server">
                                                                                </td>
                                                                                <td>
                                                                                    <input id="btnArrow" onclick="MM_openBrWindow('txtArrow');elemName='txtArrow'" type="button"
                                                                                        value="Select color" name="Button27" runat="server">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </fieldset>
                                                                </td>
                                                                <td width="45%">
                                                                    &nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlDept" runat="server">
                                                <table  cellspacing="0" cellpadding="0" width="100%"
                                                    align="center" border="0" class="FunctionBlock">
                                                    <tr>
                                                        <td class="headertd" style="text-align:left;height:23px;">
                                                            <span class="style5"><span class="formslabels">Department</span>
                                                                <label>
                                                                </label>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <br>
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td class="formslabels" style="text-align:right;">
                                                                        Background</td>
                                                                    <td width="45%">
                                                                        &nbsp;
                                                                        <fieldset style="width: 200px; height: 59px;border:solid 1 #FFFFFF">
                                                                            <legend style="color: #FFFFFF">Color </legend>
                                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <input id="txtDeptBack" style="color: #ffffff; background-color: #ffffff" readonly
                                                                                            type="text" size="6" value="FFFFFF" name="textfield4" runat="server">
                                                                                    </td>
                                                                                    <td>
                                                                                        <input id="btnDeptBack" disabled onclick="MM_openBrWindow('txtDeptBack');elemName='txtDeptBack'"
                                                                                            type="button" value="Select color" name="Button2" runat="server">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                    <td width="45%">
                                                                        &nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="formslabels" style="text-align:right;">
                                                                        Border
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                        <fieldset style="width: 200px; height: 59px;border:solid 1 #FFFFFF">
                                                                            <legend style="color: #FFFFFF">Color </legend>
                                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <input id="txtDeptBrdr" style="color: #ffffff; background-color: #ffffff" readonly
                                                                                            type="text" size="6" value="FFFFFF" name="textfield5" runat="server">
                                                                                    </td>
                                                                                    <td>
                                                                                        <input id="btnDeptBrdr" disabled onclick="MM_openBrWindow('txtDeptBrdr');elemName='txtDeptBrdr'"
                                                                                            type="button" value="Select color" name="Button3" runat="server">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                    <td width="111">
                                                                        &nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="formslabels" style="text-align:right;">
                                                                        Department name
                                                                    </td>
                                                                    <td style="height: 58px">
                                                                        &nbsp;
                                                                        <fieldset style="width: 200px; height: 59px;border:solid 1 #FFFFFF">
                                                                            <legend style="color: #FFFFFF">Color </legend>
                                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <input id="txtDeptName" style="color: #FF0000; background-color: #FF0000" readonly
                                                                                            type="text" size="6" value="FF0000" name="textfield6" runat="server">
                                                                                    </td>
                                                                                    <td>
                                                                                        <input id="btnDeptName" disabled onclick="MM_openBrWindow('txtDeptName');elemName='txtDeptName'"
                                                                                            type="button" value="Select color" name="Button4" runat="server">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                    <td style="height: 58px">
                                                                        <fieldset style="width: 336px; height: 57px;border:solid 1 #FFFFFF">
                                                                            <legend style="color: #FFFFFF">Font </legend>
                                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td style="height: 22px">
                                                                                        <span class="smalllables" style="color:#FFFFFF;">Family</span>
                                                                                    </td>
                                                                                    <td style="height: 22px">
                                                                                        <label>
                                                                                            &nbsp;
                                                                                            <asp:DropDownList ID="lstDeptFont" runat="server" Enabled="False">
                                                                                            </asp:DropDownList></label></td>
                                                                                    <td style="height: 22px">
                                                                                        <span class="smalllables" style="color:#FFFFFF;">Size</span>
                                                                                    </td>
                                                                                    <td style="height: 22px">
                                                                                    </td>
                                                                                    <td style="height: 22px">
                                                                                        <asp:DropDownList ID="lstDeptFontSize" runat="server" Enabled="False">
                                                                                            <asp:ListItem Value="6">6</asp:ListItem>
                                                                                            <asp:ListItem Value="7">7</asp:ListItem>
                                                                                            <asp:ListItem Value="8" Selected="True">8</asp:ListItem>
                                                                                            <asp:ListItem Value="9">9</asp:ListItem>
                                                                                            <asp:ListItem Value="10">10</asp:ListItem>
                                                                                            <asp:ListItem Value="11" >11</asp:ListItem>
                                                                                            <asp:ListItem Value="12">12</asp:ListItem>
                                                                                            <asp:ListItem Value="13">13</asp:ListItem>
                                                                                            <asp:ListItem Value="14">14</asp:ListItem>
                                                                                            <asp:ListItem Value="15">15</asp:ListItem>
                                                                                            <asp:ListItem Value="16">16</asp:ListItem>
                                                                                            <asp:ListItem Value="17">17</asp:ListItem>
                                                                                            <asp:ListItem Value="18">18</asp:ListItem>
                                                                                            <asp:ListItem Value="19">19</asp:ListItem>
                                                                                            <asp:ListItem Value="20">20</asp:ListItem>
                                                                                            <asp:ListItem Value="21">21</asp:ListItem>
                                                                                            <asp:ListItem Value="22">22</asp:ListItem>
                                                                                            <asp:ListItem Value="23">23</asp:ListItem>
                                                                                        </asp:DropDownList>&nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="formslabels" style="text-align:right;">
                                                                        # of employees
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                        <fieldset style="width: 200px; height: 59px;border:solid 1 #FFFFFF">
                                                                            <legend style="color: #FFFFFF">Color </legend>
                                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <input id="txtDeptEmpNo" style="color: #000000; background-color: #000000" readonly
                                                                                            type="text" size="6" value="000000" name="textfield7" runat="server">
                                                                                    </td>
                                                                                    <td>
                                                                                        <input id="btnDeptEmpNo" disabled onclick="MM_openBrWindow('txtDeptEmpNo');elemName='txtDeptEmpNo'"
                                                                                            type="button" value="Select color" name="Button5" runat="server">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="formslabels" style="text-align:right;">
                                                                        Department manager
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                        <fieldset style="width: 200px; height: 59px;border:solid 1 #FFFFFF;">
                                                                            <legend style="color: #ffffff">Color </legend>
                                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <input id="txtDeptManager" style="color: #000000; background-color: #000000" readonly
                                                                                            type="text" size="6" value="000000" name="textfield8" runat="server">
                                                                                    </td>
                                                                                    <td>
                                                                                        <input id="btnDeptManager" disabled onclick="MM_openBrWindow('txtDeptManager');elemName='txtDeptManager'"
                                                                                            type="button" value="Select color" name="Button6" runat="server">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlTitle" runat="server">
                                                <table  cellspacing="0" cellpadding="0" width="100%"
                                                    border="0" class="FunctionBlock">
                                                    <tr>
                                                        <td class="headertd" style="text-align:left;height:23px;">
                                                            <span class="formslabels">Job titles </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td class="formslabels" style="text-align:right;">
                                                                        Background
                                                                    </td>
                                                                    <td width="45%">
                                                                        &nbsp;
                                                                        <fieldset style="width: 208px; height: 59px;border:solid 1 #FFFFFF;">
                                                                            <legend style="color: #FFFFFF">Color </legend>
                                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <input id="txtJobBack" style="color: #ffffff; background-color: #ffffff" readonly
                                                                                            type="text" size="6" value="FFFFFF" name="textfield9" runat="server">
                                                                                    </td>
                                                                                    <td>
                                                                                        <input id="btnJobBack" disabled onclick="MM_openBrWindow('txtJobBack');elemName='txtJobBack'"
                                                                                            type="button" value="Select color" name="Button7" runat="server">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                    <td width="45%">
                                                                        &nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="formslabels" style="text-align:right;">
                                                                        Border
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                        <fieldset style="width: 208px; height: 59px;border:solid 1 #FFFFFF">
                                                                            <legend style="color: #FFFFFF">Color </legend>
                                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <input id="txtJobBrdr" style="color: #ffffff; background-color: #ffffff" readonly
                                                                                            type="text" size="6" value="FFFFFF" name="textfield10" runat="server">
                                                                                    </td>
                                                                                    <td>
                                                                                        <input id="btnJobBrdr" disabled onclick="MM_openBrWindow('txtJobBrdr');elemName='txtJobBrdr'"
                                                                                            type="button" value="Select color" name="Button8" runat="server">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="formslabels" style="text-align:right;">
                                                                        Title name
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                        <fieldset style="width: 208px; height: 59px;border:solid 1 #FFFFFF">
                                                                            <legend style="color: #FFFFFF">Color </legend>
                                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <input id="txtJobName" style="color: #000000; background-color: #000000" readonly
                                                                                            type="text" size="6" value="3333CC" name="textfield11" runat="server">
                                                                                    </td>
                                                                                    <td>
                                                                                        <input id="btnJobName" disabled onclick="MM_openBrWindow('txtJobName');elemName='txtJobName'"
                                                                                            type="button" value="Select color" name="Button9" runat="server">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                    <td>
                                                                        <fieldset style="width: 320px; height: 57px;border:solid 1 #FFFFFF;">
                                                                            <legend style="color: #FFFFFF">Font </legend>
                                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <span class="smalllables" style="color:#FFFFFF;">Family</span>
                                                                                    </td>
                                                                                    <td>
                                                                                        <label>
                                                                                            &nbsp;
                                                                                            <asp:DropDownList ID="lstTitleFont" runat="server" Enabled="False">
                                                                                            </asp:DropDownList></label></td>
                                                                                    <td>
                                                                                        <span class="smalllables" style="color:#FFFFFF;">Size</span>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="lstTitleFontSize" runat="server" Enabled="False">
                                                                                            <asp:ListItem Value="6">6</asp:ListItem>
                                                                                            <asp:ListItem Value="7">7</asp:ListItem>
                                                                                            <asp:ListItem Value="8" Selected="True">8</asp:ListItem>
                                                                                            <asp:ListItem Value="9">9</asp:ListItem>
                                                                                            <asp:ListItem Value="10">10</asp:ListItem>
                                                                                            <asp:ListItem Value="11" >11</asp:ListItem>
                                                                                            <asp:ListItem Value="12">12</asp:ListItem>
                                                                                            <asp:ListItem Value="13">13</asp:ListItem>
                                                                                            <asp:ListItem Value="14">14</asp:ListItem>
                                                                                            <asp:ListItem Value="15">15</asp:ListItem>
                                                                                            <asp:ListItem Value="16">16</asp:ListItem>
                                                                                            <asp:ListItem Value="17">17</asp:ListItem>
                                                                                            <asp:ListItem Value="18">18</asp:ListItem>
                                                                                            <asp:ListItem Value="19">19</asp:ListItem>
                                                                                            <asp:ListItem Value="20">20</asp:ListItem>
                                                                                            <asp:ListItem Value="21">21</asp:ListItem>
                                                                                            <asp:ListItem Value="22">22</asp:ListItem>
                                                                                            <asp:ListItem Value="23">23</asp:ListItem>
                                                                                        </asp:DropDownList>&nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="formslabels" style="text-align:right;">
                                                                        # of employees
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                        <fieldset style="width: 208px; height: 59px;border:solid 1 #FFFFFF;">
                                                                            <legend style="color: #FFFFFF">Color </legend>
                                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <input id="txtJobEmpNo" style="color: #000000; background-color: #000000" readonly
                                                                                            type="text" size="6" value="345" name="textfield12" runat="server">
                                                                                    </td>
                                                                                    <td>
                                                                                        <input id="btnJobEmpNo" disabled onclick="MM_openBrWindow('txtJobEmpNo');elemName='txtJobEmpNo'"
                                                                                            type="button" value="Select color" name="Button10" runat="server">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlTeam" runat="server">
                                                <table cellspacing="0" cellpadding="0" width="100%"
                                                     border="0" class="FunctionBlock">
                                                    <tr>
                                                        <td class="headertd" style="text-align:left;height:23px;">
                                                            <span class="formslabels">Teams</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0" class="FunctionBlock">
                                                                <tr>
                                                                    <td class="formslabels" style="text-align:right;">
                                                                        Background
                                                                    </td>
                                                                    <td width="45%" style="height: 59px">
                                                                        <label>
                                                                        </label>
                                                                        &nbsp;
                                                                        <fieldset style="width: 208px; height: 59px;border:solid 1 #FFFFFF;">
                                                                            <legend style="color: #FFFFFF">Color </legend>
                                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <input id="txtTeamBack" style="color: #ffffff; background-color: #ffffff" readonly
                                                                                            type="text" size="6" value="FFFFFF" name="textfield13" runat="server">
                                                                                    </td>
                                                                                    <td>
                                                                                        <input id="btnTeamBack" disabled onclick="MM_openBrWindow('txtTeamBack');elemName='txtTeamBack'"
                                                                                            type="button" value="Select color" name="Button11" runat="server">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                    <td width="45%" style="height: 59px">
                                                                        &nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="formslabels" style="text-align:right;">
                                                                        Border
                                                                    </td>
                                                                    <td style="height: 59px">
                                                                        &nbsp;
                                                                        <fieldset style="width: 208px; height: 59px;border:solid 1 #FFFFFF;">
                                                                            <legend style="color: #FFFFFF">Color </legend>
                                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <input id="txtTeamBrdr" style="color: #ffffff; background-color: #ffffff" readonly
                                                                                            type="text" size="6" value="FFFFFF" name="textfield14" runat="server">
                                                                                    </td>
                                                                                    <td>
                                                                                        <input id="btnTeamBrdr" disabled onclick="MM_openBrWindow('txtTeamBrdr');elemName='txtTeamBrdr'"
                                                                                            type="button" value="Select color" name="Button12" runat="server">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                    <td style="height: 59px">
                                                                        &nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="formslabels" style="text-align:right;">
                                                                        Team name
                                                                    </td>
                                                                    <td style="height: 73px">
                                                                        &nbsp;
                                                                        <fieldset style="width: 208px; height: 59px;border:solid 1 #FFFFFF;">
                                                                            <legend style="color: #FFFFFF">Color </legend>
                                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <input id="txtTeamName" style="color: #000000; background-color: #000000" readonly
                                                                                            type="text" size="6" value="000000" name="textfield15" runat="server">
                                                                                    </td>
                                                                                    <td>
                                                                                        <input id="btnTeamName" disabled onclick="MM_openBrWindow('txtTeamName');elemName='txtTeamName'"
                                                                                            type="button" value="Select color" name="Button13" runat="server">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                    <td style="height: 73px">
                                                                        <fieldset style="width: 304px; height: 57px;border:solid 1 #FFFFFF;">
                                                                            <legend style="color: #FFFFFF">Font </legend>
                                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <span class="smalllables" style="color:#FFFFFF;">Family</span>
                                                                                    </td>
                                                                                    <td>
                                                                                        <label>
                                                                                            &nbsp;
                                                                                            <asp:DropDownList ID="lstTeamFont" runat="server" Enabled="False">
                                                                                            </asp:DropDownList></label></td>
                                                                                    <td>
                                                                                        <span class="smalllables" style="color:#FFFFFF;">Size</span>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="lstTeamFontSize" runat="server" Enabled="False">
                                                                                            <asp:ListItem Value="6">6</asp:ListItem>
                                                                                            <asp:ListItem Value="7">7</asp:ListItem>
                                                                                            <asp:ListItem Value="8" Selected="True">8</asp:ListItem>
                                                                                            <asp:ListItem Value="9">9</asp:ListItem>
                                                                                            <asp:ListItem Value="10">10</asp:ListItem>
                                                                                            <asp:ListItem Value="11">11</asp:ListItem>
                                                                                            <asp:ListItem Value="12">12</asp:ListItem>
                                                                                            <asp:ListItem Value="13">13</asp:ListItem>
                                                                                            <asp:ListItem Value="14">14</asp:ListItem>
                                                                                            <asp:ListItem Value="15">15</asp:ListItem>
                                                                                            <asp:ListItem Value="16">16</asp:ListItem>
                                                                                            <asp:ListItem Value="17">17</asp:ListItem>
                                                                                            <asp:ListItem Value="18">18</asp:ListItem>
                                                                                            <asp:ListItem Value="19">19</asp:ListItem>
                                                                                            <asp:ListItem Value="20">20</asp:ListItem>
                                                                                            <asp:ListItem Value="21">21</asp:ListItem>
                                                                                            <asp:ListItem Value="22">22</asp:ListItem>
                                                                                            <asp:ListItem Value="23">23</asp:ListItem>
                                                                                        </asp:DropDownList>&nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="formslabels" style="text-align:right;">
                                                                        # of employees
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                        <fieldset style="width: 208px; height: 59px;border:solid 1 #FFFFFF;">
                                                                            <legend style="color: #FFFFFF">Color </legend>
                                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <input id="txtTeamEmpNo" style="color: #000000; background-color: #000000" readonly
                                                                                            type="text" size="6" value="000000" name="textfield16" runat="server">
                                                                                    </td>
                                                                                    <td>
                                                                                        <input id="btnTeamEmpNo" disabled onclick="MM_openBrWindow('txtTeamEmpNo');elemName='txtTeamEmpNo'"
                                                                                            type="button" value="Select color" name="Button14" runat="server">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="formslabels" style="text-align:right;">
                                                                        Team leader
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                        <fieldset style="width: 208px; height: 59px;border:solid 1 #FFFFFF;">
                                                                            <legend style="color: #FFFFFF">Color </legend>
                                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <input id="txtTeamLeader" style="color: #000000; background-color: #000000" readonly
                                                                                            type="text" size="6" value="000000" name="textfield17" runat="server">
                                                                                    </td>
                                                                                    <td>
                                                                                        <input id="btnTeamLeader" disabled onclick="MM_openBrWindow('txtTeamLeader');elemName='txtTeamLeader'"
                                                                                            type="button" value="Select color" name="Button15" runat="server">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlProject" runat="server">
                                                <table cellspacing="0" cellpadding="0" width="100%"
                                                    border="0" class="FunctionBlock">
                                                    <tr>
                                                        <td class="headertd" style="text-align:left;height:23px;">
                                                            <span class="formslabels">Projects</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0" >
                                                                <tr>
                                                                    <td class="formslabels" style="text-align:right;">
                                                                        Background
                                                                    </td>
                                                                    <td width="45%">
                                                                        <label>
                                                                        </label>
                                                                        &nbsp;
                                                                        <fieldset style="width: 216px; height: 59px;border:solid 1 #FFFFFF;">
                                                                            <legend style="color: #FFFFFF">Color </legend>
                                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <input id="txtProjectBack" style="color: #ffffff; background-color: #ffffff" readonly
                                                                                            type="text" size="6" value="FFFFFF" name="textfield18" runat="server">
                                                                                    </td>
                                                                                    <td>
                                                                                        <input id="btnProjectBack" disabled onclick="MM_openBrWindow('txtProjectBack');elemName='txtProjectBack'"
                                                                                            type="button" value="Select color" name="Button16" runat="server">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                    <td width="45%">
                                                                        &nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="formslabels" style="text-align:right;">
                                                                        Border
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                        <fieldset style="width: 216px; height: 59px;border:solid 1 #FFFFFF;">
                                                                            <legend style="color: #FFFFFF">Color </legend>
                                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <input id="txtProjectBrdr" style="color: #ffffff; background-color: #ffffff" readonly
                                                                                            type="text" size="6" value="FFFFFF" name="textfield19" runat="server">
                                                                                    </td>
                                                                                    <td>
                                                                                        <input id="btnProjectBrdr" disabled onclick="MM_openBrWindow('txtProjectBrdr');elemName='txtProjectBrdr'"
                                                                                            type="button" value="Select color" name="Button17" runat="server">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="formslabels" style="text-align:right;">
                                                                        Project name
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                        <fieldset style="width: 216px; height: 59px;border:solid 1 #FFFFFF;">
                                                                            <legend style="color: #FFFFFF">Color </legend>
                                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <input id="txtProjectName" style="color: #000000; background-color: #000000" readonly
                                                                                            type="text" size="6" value="000000" name="textfield20" runat="server">
                                                                                    </td>
                                                                                    <td>
                                                                                        <input id="btnProjectName" disabled onclick="MM_openBrWindow('txtProjectName');elemName='txtProjectName'"
                                                                                            type="button" value="Select color" name="Button18" runat="server">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                    <td>
                                                                        <fieldset style="width: 304px; height: 57px;border:solid 1 #FFFFFF;">
                                                                            <legend style="color: #FFFFFF">Font </legend>
                                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <span class="smalllables" style="color:#FFFFFF;">Family</span>
                                                                                    </td>
                                                                                    <td>
                                                                                        <label>
                                                                                            &nbsp;
                                                                                            <asp:DropDownList ID="lstProjectFont" runat="server" Enabled="False">
                                                                                            </asp:DropDownList></label></td>
                                                                                    <td>
                                                                                        <span class="smalllables" style="color:#FFFFFF;">Size</span>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="lstProjectFontSize" runat="server" Enabled="False">
                                                                                            <asp:ListItem Value="6">6</asp:ListItem>
                                                                                            <asp:ListItem Value="7">7</asp:ListItem>
                                                                                            <asp:ListItem Value="8" Selected="True">8</asp:ListItem>
                                                                                            <asp:ListItem Value="9">9</asp:ListItem>
                                                                                            <asp:ListItem Value="10">10</asp:ListItem>
                                                                                            <asp:ListItem Value="11">11</asp:ListItem>
                                                                                            <asp:ListItem Value="12">12</asp:ListItem>
                                                                                            <asp:ListItem Value="13">13</asp:ListItem>
                                                                                            <asp:ListItem Value="14">14</asp:ListItem>
                                                                                            <asp:ListItem Value="15">15</asp:ListItem>
                                                                                            <asp:ListItem Value="16">16</asp:ListItem>
                                                                                            <asp:ListItem Value="17">17</asp:ListItem>
                                                                                            <asp:ListItem Value="18">18</asp:ListItem>
                                                                                            <asp:ListItem Value="19">19</asp:ListItem>
                                                                                            <asp:ListItem Value="20">20</asp:ListItem>
                                                                                            <asp:ListItem Value="21">21</asp:ListItem>
                                                                                            <asp:ListItem Value="22">22</asp:ListItem>
                                                                                            <asp:ListItem Value="23">23</asp:ListItem>
                                                                                        </asp:DropDownList>&nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="formslabels" style="text-align:right;">
                                                                        # of employees
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                        <fieldset style="width: 216px; height: 59px;border:solid 1 #FFFFFF;">
                                                                            <legend style="color: #FFFFFF">Color </legend>
                                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <input id="txtProjectEmpNo" style="color: #000000; background-color: #000000" readonly
                                                                                            type="text" size="6" value="000000" name="textfield21" runat="server">
                                                                                    </td>
                                                                                    <td>
                                                                                        <input id="btnProjectEmpNo" disabled onclick="MM_openBrWindow('txtProjectEmpNo');elemName='txtProjectEmpNo'"
                                                                                            type="button" value="Select color" name="Button19" runat="server">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="formslabels" style="text-align:right;">
                                                                        Project manager
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                        <fieldset style="width: 216px; height: 59px;border:solid 1 #FFFFFF;">
                                                                            <legend style="color: #FFFFFF">Color </legend>
                                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <input id="txtProjectManager" style="color: #000000; background-color: #000000" readonly
                                                                                            type="text" size="6" value="000000" name="textfield24" runat="server">
                                                                                    </td>
                                                                                    <td>
                                                                                        <input id="btnProjectManager" disabled onclick="MM_openBrWindow('txtProjectManager');elemName='txtProjectManager'"
                                                                                            type="button" value="Select color" name="Button20" runat="server">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlEmp" runat="server" dir="ltr">
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0" class="FunctionBlock">
                                                    <tr>
                                                        <td class="headertd" style="text-align:left;height:23px;" colspan="4">
                                                            <span class="formslabels">Employee</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formslabels" style="text-align:right;">
                                                            Background
                                                        </td>
                                                        <td width="45%">
                                                            <label>
                                                            </label>
                                                            &nbsp;
                                                            <fieldset style="width: 224px; height: 59px;border:solid 1 #FFFFFF;">
                                                                <legend style="color: #FFFFFF">Color </legend>
                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                    <tr>
                                                                        <td>
                                                                            <input id="txtEmpBack" style="color: #ffffff; background-color: #ffffff" readonly
                                                                                type="text" size="6" value="FFFFFF" name="textfield25" runat="server">
                                                                        </td>
                                                                        <td>
                                                                            <input id="btnEmpBack" disabled onclick="MM_openBrWindow('txtEmpBack');elemName='txtEmpBack'"
                                                                                type="button" value="Select color" name="Button21" runat="server">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </fieldset>
                                                        </td>
                                                        <td width="45%">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formslabels" style="text-align:right; height: 59px;">
                                                            Border
                                                        </td>
                                                        <td style="height: 59px">
                                                            &nbsp;
                                                            <fieldset style="width: 224px; height: 59px;border:solid 1 #FFFFFF;">
                                                                <legend style="color: #FFFFFF">Color </legend>
                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                    <tr>
                                                                        <td>
                                                                            <input id="txtEmpBrdr" style="color: #ffffff; background-color: #ffffff" readonly
                                                                                type="text" size="6" value="FFFFFF" name="textfield26" runat="server">
                                                                        </td>
                                                                        <td>
                                                                            <input id="btnEmpBrdr" disabled onclick="MM_openBrWindow('txtEmpBrdr');elemName='txtEmpBrdr'"
                                                                                type="button" value="Select color" name="Button212" runat="server">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </fieldset>
                                                        </td>
                                                        <td style="height: 59px">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formslabels" style="text-align:right; height: 61px;">
                                                            name
                                                        </td>
                                                        <td style="height: 61px">
                                                            &nbsp;
                                                            <fieldset style="width: 224px; height: 59px;border:solid 1 #FFFFFF;">
                                                                <legend style="color: #FFFFFF">Color </legend>
                                                                <table cellspacing="0" cellpadding="0" border="0" style="border:solid 1 #FFFFFF;">
                                                                    <tr>
                                                                        <td>
                                                                            <input id="txtEmpName" style="color: #000000; background-color: #000000" readonly
                                                                                type="text" size="6" value="000000" name="textfield27" runat="server">
                                                                        </td>
                                                                        <td>
                                                                            <input id="btnEmpName" disabled onclick="MM_openBrWindow('txtEmpName');elemName='txtEmpName'"
                                                                                type="button" value="Select color" name="Button22" runat="server">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </fieldset>
                                                        </td>
                                                        <td style="height: 61px">
                                                            <fieldset style="width: 312px; height: 57px;border:solid 1 #FFFFFF;" >
                                                                <legend style="color: #FFFFFF">Font </legend>
                                                                <table cellspacing="0" cellpadding="0" border="0" style="border:solid 1 #FFFFFF">
                                                                    <tr>
                                                                        <td style="height: 22px">
                                                                            <span class="smalllables" style="color:#FFFFFF;">Family</span>
                                                                        </td>
                                                                        <td style="height: 22px">
                                                                            <label>
                                                                                &nbsp;
                                                                                <asp:DropDownList ID="lstEmpFont" runat="server" Enabled="False">
                                                                                </asp:DropDownList></label></td>
                                                                        <td style="width: 22px; height: 22px;">
                                                                            <span class="smalllables" style="color:#FFFFFF;">Size</span>
                                                                        </td>
                                                                        <td style="height: 22px">
                                                                        </td>
                                                                        <td style="height: 22px">
                                                                            <asp:DropDownList ID="lstEmpFontSize" runat="server" Enabled="False">
                                                                                <asp:ListItem Value="6">6</asp:ListItem>
                                                                                <asp:ListItem Value="7">7</asp:ListItem>
                                                                                <asp:ListItem Value="8" Selected="True">8</asp:ListItem>
                                                                                <asp:ListItem Value="9">9</asp:ListItem>
                                                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                                                <asp:ListItem Value="11">11</asp:ListItem>
                                                                                <asp:ListItem Value="12">12</asp:ListItem>
                                                                                <asp:ListItem Value="13">13</asp:ListItem>
                                                                                <asp:ListItem Value="14">14</asp:ListItem>
                                                                                <asp:ListItem Value="15">15</asp:ListItem>
                                                                                <asp:ListItem Value="16">16</asp:ListItem>
                                                                                <asp:ListItem Value="17">17</asp:ListItem>
                                                                                <asp:ListItem Value="18">18</asp:ListItem>
                                                                                <asp:ListItem Value="19">19</asp:ListItem>
                                                                                <asp:ListItem Value="20">20</asp:ListItem>
                                                                                <asp:ListItem Value="21">21</asp:ListItem>
                                                                                <asp:ListItem Value="22">22</asp:ListItem>
                                                                                <asp:ListItem Value="23">23</asp:ListItem>
                                                                            </asp:DropDownList>&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </fieldset>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formslabels" style="text-align:right;">
                                                            Department
                                                        </td>
                                                        <td style="height: 59px">
                                                            &nbsp;
                                                            <fieldset style="width: 224px; height: 59px;border:solid 1 #FFFFFF;">
                                                                <legend style="color: #FFFFFF">Color </legend>
                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                    <tr>
                                                                        <td>
                                                                            <input id="txtEmpDept" style="color: #000000; background-color: #000000" readonly
                                                                                type="text" size="6" value="000000" name="textfield28" runat="server">
                                                                        </td>
                                                                        <td>
                                                                            <input id="btnEmpDept" disabled onclick="MM_openBrWindow('txtEmpDept');elemName='txtEmpDept'"
                                                                                type="button" value="Select color" name="Button23" runat="server">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </fieldset>
                                                        </td>
                                                        <td style="height: 59px">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formslabels" style="text-align:right;">
                                                            Title
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                            <fieldset style="width: 224px; height: 59px;border:solid 1 #FFFFFF;">
                                                                <legend style="color: #FFFFFF">Color </legend>
                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                    <tr>
                                                                        <td>
                                                                            <input id="txtEmpTitle" style="color: #000000; background-color: #000000" readonly
                                                                                type="text" size="6" value="000000" name="textfield" runat="server">
                                                                        </td>
                                                                        <td>
                                                                            <input id="btnEmpJob" disabled onclick="MM_openBrWindow('txtEmpTitle');elemName='txtEmpTitle'"
                                                                                type="button" value="Select color" name="Button24" runat="server">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </fieldset>
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formslabels" style="text-align:right;">
                                                            Code
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                            <fieldset style="width: 224px; height: 59px;border:solid 1 #FFFFFF;">
                                                                <legend style="color: #FFFFFF">Color </legend>
                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                    <tr>
                                                                        <td>
                                                                            <input id="txtEmpCode" style="color: #000000; background-color: #000000" readonly
                                                                                type="text" size="6" value="000000" name="textfield2" runat="server">
                                                                        </td>
                                                                        <td>
                                                                            <input id="btnEmpCode" disabled onclick="MM_openBrWindow('txtEmpCode');elemName='txtEmpCode'"
                                                                                type="button" value="Select color" name="Button242" runat="server">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </fieldset>
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formslabels" style="text-align:right;">
                                                            Projects
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                            <fieldset style="width: 224px; height: 59px;border:solid 1 #FFFFFF;">
                                                                <legend style="color: #FFFFFF">Color </legend>
                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                    <tr>
                                                                        <td>
                                                                            <input id="txtEmpProject" style="color: #000000; background-color: #000000" readonly
                                                                                type="text" size="6" value="000000" name="textfield30" runat="server">
                                                                        </td>
                                                                        <td>
                                                                            <input id="btnEmpProjects" disabled onclick="MM_openBrWindow('txtEmpProject');elemName='txtEmpProject'"
                                                                                type="button" value="Select color" name="Button25" runat="server">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </fieldset>
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formslabels" style="text-align:right;">
                                                            Teams
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                            <fieldset style="width: 224px; height: 59px;border:solid 1 #FFFFFF;">
                                                                <legend style="color: #FFFFFF">Color </legend>
                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                    <tr>
                                                                        <td>
                                                                            <input id="txtEmpTeams" style="color: #000000; background-color: #000000" readonly
                                                                                type="text" size="6" value="000000" name="textfield29" runat="server">
                                                                        </td>
                                                                        <td>
                                                                            <input id="btnEmpTeams" disabled onclick="MM_openBrWindow('txtEmpTeams');elemName='txtEmpTeams'"
                                                                                type="button" value="Select color" name="Button26" runat="server">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </fieldset>
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                           </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
