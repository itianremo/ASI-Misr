<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.Go.frmManagersNotes" ValidateRequest="false"
    CodeFile="frmManagersNotes.aspx.cs" %>

<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Notes</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <style type="text/css">.style2 { FONT-SIZE: 12px; FONT-FAMILY: Arial, Helvetica, sans-serif }
	.btn { BORDER-RIGHT: #000066 1px solid; BORDER-TOP: #000066 1px solid; FONT-SIZE: 10px; BORDER-LEFT: #000066 1px solid; COLOR: #000066; BORDER-BOTTOM: #000066 1px solid; FONT-FAMILY: Arial, Helvetica, sans-serif; BACKGROUND-COLOR: #ffffff; br: bold }
		</style>
    <link href="../Acc1.css" type="text/css" rel="stylesheet">

    <script language="javascript" src="accMethods.js"></script>

    <script language="javascript">
		//function load()
		//{
		//	document.getElementById('lblCode').innerHTML = opener.document.getElementById('_ctl0_txtCode').value;	
		//	document.getElementById('lblName').innerHTML = opener.document.getElementById('_ctl0_txtFName').value
		//							+ ' ' + opener.document.getElementById('_ctl0_txtLName').value;	
		//}
		//function prepareClose()
		//{
		//	window.close();
		//}
		var firstLoad=true;
		var newWindow;
		function closeNotes()
		{
			window.close();
		}
		function LoadNotes()
		{
			//if(firstLoad)
			//{
			//	var val = window.opener.document.getElementById("txtHiddenNotes").value;
			//	//alert(val);
			//	//val = val.replace(/123!321/g,"<").replace(/123!!!321/g,'>')
			//	FTB_API['FreeTextBox1'].SetHtml(val);
			//}
		}
		function SaveNoteInAcc()
		{
			//window.opener.document.getElementById("txtNote").value=val;
			//window.opener.document.getElementById("FreeTextBox1").value=val;//

			//window.opener.document.getElementById("txtNote").innerHTML=val;

			//window.opener.changemynote(val);
			//window.opener.document.forms[0].FTB_API['FreeTextBox1'].SetHtml('blah'); 
			//window.opener.SetFCK(val);
			var val = FTB_API['FreeTextBox1'].GetHtml();
			window.opener.setFreeTextBoxData(val);
			window.opener.saveNote();
			window.opener.ModifyDatagrid();
			closeNotes();
		}
		function OutOfNotesWindow()
		{
			//alert("You got out");
			//firstLoad=false;
			//window.focus();
		}
		function NotesClosed()
		{
			window.opener.IsNotesPopupOpened=false;
			// added by sayed 01/09/2008
			//window.opener.saveSheet(1);
			window.opener.location.reload(true);
			window.opener.refreshForm();
			//
		}
		function openEmail(mailButton)
		{
			////window.open("frmFindEmail.aspx?mailButton="+mailButton+"","Emails","scrollbars=yes,status=yes,height=800,width=600,top=30,left=100");	
			//var txtTo = document.getElementById('txtTo').value;
			//var txtCC = document.getElementById('txtCC').value;
			//var txtBCC = document.getElementById('txtBCC').value;
			//
			//var retVal = window.showModalDialog("frmFindEmail.aspx?mailButton="+mailButton+"&txtTo="+txtTo+"&txtCC="+txtCC+"&txtBCC="+txtBCC+"","Emails","scrollbars=yes,status=yes,height=800,width=600,top=30,left=100");	
			//if(retVal != null)
			//{
			//	if(mailButton == 'btnTo')
			//		document.getElementById('txtTo').value=retVal;
			//	else if(mailButton == 'btnCC')
			//		document.getElementById('txtCC').value=retVal; 
			//	else if(mailButton == 'btnBCC')
			//		document.getElementById('txtBCC').value=retVal;  
			//}
			window.open("frmFindEmail.aspx?mailButton="+mailButton+"","Emails","scrollbars=yes,status=yes,height=800,width=600,top=30,left=100");							
				
		}
    </script>

</head>
<body onblur="OutOfNotesWindow();" onfocus="LoadNotes();" onmouseout="OutOfNotesWindow();"
    onbeforeunload="NotesClosed();">
    <form id="Form1" method="post" runat="server">
        <div align="center">
            <table style="width: 750px; height: 100%" align="center">
                <tr>
                    <td class="headertd" style="height: 25px">
                        Managers Weekly Report
                    </td>
                </tr>
                <tr>
                    <td class="whitetd" width="80%" valign="top">
                        <!--- our div----->
                        <div id="divEmail" align="center" style="vertical-align: top">
                            <asp:Label ID="lblNote" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                            <table style="text-align: center">
                                <tbody style="text-align: center" valign="top">
                                    <tr>
                                        <td style="width: 10%" rowspan="3" align="left">
                                            &nbsp;
                                            <asp:Button ID="btnSendMail" runat="server" Text="Send" Height="80px" Width="66px"
                                                Enabled="False" OnClick="btnSendMail_Click"></asp:Button></td>
                                        <td style="width: 9.11%; height: 27px; text-align: right">
                                            <asp:Label ID="lblFrom" runat="server" Font-Size="X-Small">From...</asp:Label></td>
                                        <td style="width: 80%; height: 27px; text-align: left">
                                            <asp:TextBox ID="txtFrom" runat="server" Width="500px" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 9.11%; text-align: right">
                                            <input id="btnTo" style="width: 53px; height: 24px" onclick="openEmail('btnTo');"
                                                type="button" value="To..."></td>
                                        <td style="width: 80%; text-align: left">
                                            <asp:TextBox ID="txtTo" runat="server" Width="500px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 9.11%; text-align: right">
                                            <input id="btnCC" style="width: 53px; height: 24px" onclick="openEmail('btnCC');"
                                                type="button" value="CC..." name="Button1"></td>
                                        <td style="width: 80%; text-align: left">
                                            <asp:TextBox ID="txtCC" runat="server" Width="500px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 10%" align="right">
                                            &nbsp;<input id="btnCancelNote" style="width: 65px; height: 24px" onclick="closeNotes();"
                                                type="button" value="Cancel"/>
                                        </td>
                                        <td style="width: 9.11%; text-align: right">
                                            <input id="btnBCC" style="width: 53px; height: 24px" onclick="openEmail('btnBCC');"
                                                type="button" value="BCC..." name="Button2"/></td>
                                        <td style="width: 80%; text-align: left">
                                            <asp:TextBox ID="txtBCC" runat="server" Width="500px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 10%" align="left">
                                            &nbsp;
                                            <asp:Button ID="btnSaveManagerNote" runat="server" Width="65px" Text="Save" OnClick="btnSaveManagerNote_Click">
                                            </asp:Button>
                                        </td>
                                        <td style="width: 9.11%; text-align: right">
                                            <asp:Label ID="lblSubject" runat="server" Font-Size="X-Small">Subject...</asp:Label></td>
                                        <td style="width: 80%; text-align: left">
                                            <asp:TextBox ID="txtSubject" runat="server" Width="500px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <ftb:FreeTextBox ID="FreeTextBox1" runat="server" Height="580px" Width="550px" ToolbarLayout="FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline|JustifyLeft,JustifyCenter,JustifyRight|BulletedList,NumberedList,Print"
                                                EnableHtmlMode="False" Focus="True" ButtonImagesLocation="ExternalFile" JavaScriptLocation="ExternalFile"
                                                ToolbarImagesLocation="ExternalFile" SupportFolder="aspnet_client/FreeTextBox/">
                                            </ftb:FreeTextBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
            <br />
            <table width="100%" align="center" border="0">
                <tr align="center">
                    <td>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
