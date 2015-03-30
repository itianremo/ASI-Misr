<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Page language="c#" Inherits="TSN.ERP.WebGUI.Go.frmNotes" ValidateRequest="false" CodeFile="frmNotes.aspx.cs" %>
<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Notes</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style type="text/css">.style2 { FONT-SIZE: 12px; FONT-FAMILY: Arial, Helvetica, sans-serif }
	.btn { BORDER-RIGHT: #000066 1px solid; BORDER-TOP: #000066 1px solid; FONT-SIZE: 10px; BORDER-LEFT: #000066 1px solid; COLOR: #000066; BORDER-BOTTOM: #000066 1px solid; FONT-FAMILY: Arial, Helvetica, sans-serif; BACKGROUND-COLOR: #ffffff; br: bold }
		</style>
		<LINK href="../Acc1.css" type="text/css" rel="stylesheet">
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
		function closeNotes()
		{
			window.close();
		}
		function LoadNotes()
		{
			if(firstLoad)
			{
				var val = window.opener.document.getElementById("txtHiddenNotes").value;
				//alert(val);
				//val = val.replace(/123!321/g,"<").replace(/123!!!321/g,'>')
				FTB_API['FreeTextBox1'].SetHtml(val);
			}
			firstLoad=false;
			
		}
		function SaveNoteInAcc()
		{
		   document.getElementById('wait').style.visibility = "visible";
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
			// added by sayed
			window.opener.saveSheet(1);
			//
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
		 //  alert("You got out");
		    document.getElementById('wait').style.visibility = "visible";
			window.opener.IsNotesPopupOpened=false;
			// added by sayed 01/09/2008
			//window.opener.saveSheet(1);
			//window.opener.isFocused = false;
			//refresh or reload accountability sheet
			window.opener.location.reload(true);
			window.opener.refreshForm();
			// end of adding
			
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
			firstLoad=false;
			window.open("frmFindEmail.aspx?mailButton="+mailButton+"","Emails","scrollbars=yes,status=yes,height=800,width=600,top=30,left=100");							
				
		}
		</script>
	</HEAD>
	<body onblur="OutOfNotesWindow();" onbeforeunload="NotesClosed();" onfocus="LoadNotes();">
		<form id="Form1" method="post" runat="server">
			<div align="center">
				<table style="WIDTH: 750px; HEIGHT: 100%" align="center">
					<tr>
						<td class="headertd" style="HEIGHT: 25px">Notes
						</td>
					</tr>
					<tr>
						<td class="whitetd" width="80%" valign="top">
							<!--- our div----->
							<div id="divEmail" align="center"><asp:label id="lblNote" runat="server" Visible="False" ForeColor="Red"></asp:label>
								<table style="TEXT-ALIGN: center">
									<TBODY style="TEXT-ALIGN: center" vAlign="top">
										<tr>
											<td style="WIDTH: 10%" rowSpan="3">&nbsp;
												<asp:button id="btnSendMail" runat="server" Text="Send" Height="80px" Width="66px" Enabled="False" onclick="btnSendMail_Click"></asp:button></td>
											<td style="WIDTH: 9.11%; HEIGHT: 27px; TEXT-ALIGN: right"><asp:label id="lblFrom" runat="server" Font-Size="X-Small">From...</asp:label></td>
											<td style="WIDTH: 80%; HEIGHT: 27px; TEXT-ALIGN: left"><asp:textbox id="txtFrom" runat="server" Width="500px" ReadOnly="True"></asp:textbox></td>
										</tr>
										<tr>
											<td style="WIDTH: 9.11%; TEXT-ALIGN: right"><INPUT id="btnTo" style="WIDTH: 53px; HEIGHT: 24px" onclick="openEmail('btnTo');" type="button"
													value="To..."></td>
											<td style="WIDTH: 80%; TEXT-ALIGN: left"><asp:textbox id="txtTo" runat="server" Width="500px"></asp:textbox></td>
										</tr>
										<tr>
											<td style="WIDTH: 9.11%; TEXT-ALIGN: right"><INPUT id="btnCC" style="WIDTH: 53px; HEIGHT: 24px" onclick="openEmail('btnCC');" type="button"
													value="CC..." name="Button1"></td>
											<td style="WIDTH: 80%; TEXT-ALIGN: left"><asp:textbox id="txtCC" runat="server" Width="500px"></asp:textbox></td>
										</tr>
										<tr>
											<td style="WIDTH: 10%">&nbsp;<INPUT id="btnCancelNote" style="WIDTH: 64px; HEIGHT: 24px" onclick="closeNotes();" type="button"
													value="Cancel">
											</td>
											<td style="WIDTH: 9.11%; TEXT-ALIGN: right"><INPUT id="btnBCC" style="WIDTH: 53px; HEIGHT: 24px" onclick="openEmail('btnBCC');" type="button"
													value="BCC..." name="Button2"></td>
											<td style="WIDTH: 80%; TEXT-ALIGN: left"><asp:textbox id="txtBCC" runat="server" Width="500px"></asp:textbox></td>
										</tr>
										<tr>
											<td style="WIDTH: 10%; HEIGHT: 25px">&nbsp;<INPUT id="btnSaveNote" style="WIDTH: 64px; HEIGHT: 24px" onclick="SaveNoteInAcc();" type="button"
													value="Save">
											</td>
											<td style="WIDTH: 9.11%; HEIGHT: 25px; TEXT-ALIGN: right"><asp:label id="lblSubject" runat="server" Font-Size="X-Small">Subject...</asp:label></td>
											<td style="WIDTH: 80%; HEIGHT: 25px; TEXT-ALIGN: left"><asp:textbox id="txtSubject" runat="server" Width="500px"></asp:textbox></td>
										</tr>
										<TR>
											<TD style="WIDTH: 10%; HEIGHT: 25px"></TD>
											<TD style="WIDTH: 9.11%; HEIGHT: 25px; TEXT-ALIGN: right"></TD>
											<TD style="WIDTH: 80%; HEIGHT: 25px; TEXT-ALIGN: center"><div id="wait" style="VISIBILITY: hidden" align="center"><font face="Arial, Helvetica, sans-serif" color="#003366" size="1">Please 
								wait</font><br>
							<IMG height="7" alt="1" src="images/loading.gif" width="78">
						</div></TD>
										</TR>
										<TR>
											<td colSpan="3"><ftb:freetextbox id="FreeTextBox1" runat="server" Height="580px" Width="550px" ToolbarLayout="FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline|JustifyLeft,JustifyCenter,JustifyRight|BulletedList,NumberedList,Print"
													EnableHtmlMode="False" Focus="True" ButtonImagesLocation="ExternalFile" JavaScriptLocation="ExternalFile"
													ToolbarImagesLocation="ExternalFile" SupportFolder="aspnet_client/FreeTextBox/"></ftb:freetextbox></td>
										</TR>
									</TBODY>
								</table>
							</div>
						</td>
					</tr>
				</table>
				<br>
				<table width="100%" align="center" border="0">
					<tr align="center">
						<td></td>
					</tr>
				</table>
				<P></P>
			</div>
			<p align="center">
		</form>
		</P>
	</body>
</HTML>
