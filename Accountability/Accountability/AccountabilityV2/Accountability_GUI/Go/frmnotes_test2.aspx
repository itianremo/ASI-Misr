<%@ Reference Page="~/go/frmnotes_test.aspx" %>
<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Page language="c#" Inherits="TSN.ERP.WebGUI.Go.frmNotes_test2" ValidateRequest="false" CodeFile="frmNotes_test2.aspx.cs" %>
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
		var mailButton;
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
		}
		function openEmail(vmailButton)
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
			
			
			
			
			
			//window.open("frmFindEmail.aspx?mailButton="+mailButton+"","Emails","scrollbars=yes,status=yes,height=800,width=600,top=30,left=100");
	
			//document.getElementById('divPanel').style.display="inline";
			//document.getElementById('divPanel').style.visibility = "visible";
			
			////////////////////mailButton=vmailButton;			
			////////////////////displayEmails(vmailButton);
			
			//---------------------------------------------------------
			mailButton=vmailButton;
			document.getElementById('divPanel').style.display="inline";
			//---------------------------------------------------------
								
				
		}
		function saveEmails()
		{			
			var Emails = getEmails();
			//alert(Emails+'');
			if(Emails == "DataGridIsNull")
			{
				alert('No emails!!!')
				return;
			}
			if(Emails == '' || Emails == null)
			{
				alert('You must select at least one email address');
				return;
			}
			//var mailBtn = window.opener.document.mailButton
			//alert(mailBtn);
			if(mailButton == "btnTo")
			{
				var toValue =document.getElementById("txtTo").value;
				//alert('btnTo: '+toValue+'');
				if(toValue == '')
				{
					document.getElementById("txtTo").value = Emails;				
				}
				else
				{
					document.getElementById("txtTo").value += ";"+Emails;
					//alert('toooooo '+toValue+';'+Emails);
				}
			}
			else if(mailButton == "btnCC")
			{
				var CCValue = document.getElementById("txtCC").value;
				if(CCValue == '')
				{
					document.getElementById("txtCC").value = Emails;
				}			
				else
				{
					document.getElementById("txtCC").value += ";"+Emails;
				}			
			}
			else if(mailButton == "btnBCC")
			{
				var BCCValue = document.getElementById("txtBCC").value;
				if(BCCValue == '')				
				{
					document.getElementById("txtBCC").value = Emails;
				}
				else
				{
					document.getElementById("txtBCC").value += ";"+Emails;
				}
			}
			
			//document.getElementById('divPanel').style.display="inline";	
			//document.getElementById('divPanel').style.visibility = "hidden";
			closePanel();
			
			//Uncheck All Mail CheckBoxes
			UncheckAllMailCheckBoxes();
			/////////////////////////////
		}
		function UncheckAllMailCheckBoxes()
		{
			var grid = document.getElementById('dgEmails');
			var len = grid.rows.length; 		     
		     var Emails='';
			// touch each row, retrieve cell 1 innerHTML 
			for(i = 1; i < len-1; i++) 
			{   
				var chk = grid.rows[i].cells[2].children[0];
				if(chk.type=='checkbox' && chk.checked)
				{
					chk.checked=false;
				}
			} 
		}
		function getEmails() 
		{ 
			// get datagrid by rendered table name 
			var grid = document.getElementById('dgEmails');
			if(grid == null)
				return 'DataGridIsNull';
			var len = grid.rows.length; 
		     
		     var Emails='';
			// touch each row, retrieve cell 1 innerHTML 
			for(i = 1; i < len-1; i++) 
			{   
				var chk = grid.rows[i].cells[2].children[0];
				if(chk.type=='checkbox' && chk.checked)
				{
					//alert(grid.rows[i].cells[1].innerHTML); 
					if(Emails == '')
					{
						Emails += grid.rows[i].cells[1].innerHTML;
					}
					else
					{
						Emails += ";"+grid.rows[i].cells[1].innerHTML;
					}
				}
			} 
			//alert(Emails);
			return Emails;
		}
		function closePanel()
		{
			
			//document.getElementById('divPanel').style.visibility="hidden";	
			//document.getElementById('divPanel').style.display="none";	
			
			////////////////CloseEmailsWindow('close');
			//---------------------------------------------------------				
			document.getElementById('divPanel').style.display="none";
			UncheckAllMailCheckBoxes();
			//---------------------------------------------------------
		}
		</script>
	</HEAD>
	<body onblur="OutOfNotesWindow();" onfocus="LoadNotes();" onunload="NotesClosed();">
		<form id="Form1" method="post" runat="server">
			<div align="center">
				<table style="WIDTH: 750px; HEIGHT: 100%" align="center" bordercolor="#ff0033" border="3">
					<tr>
						<td class="headertd" style="HEIGHT: 25px">Notes Test2
						</td>
					</tr>
					<tr>
						<td class="whitetd" vAlign="top" width="80%">
							<!--- our div----->
							<div id="divEmail" align="center">
								<asp:label id="lblNote" runat="server" ForeColor="Red" Visible="False"></asp:label>
								<table style="TEXT-ALIGN: center" bordercolor="#00ff00" border="3">
									<TBODY style="TEXT-ALIGN: center" vAlign="top">
										<TR>
											<!--
											<TD style="WIDTH: 10%"></TD>
											<TD style="WIDTH: 9.11%; HEIGHT: 27px; TEXT-ALIGN: right"></TD>
											-->
											<TD style="WIDTH: 80%; TEXT-ALIGN: center" valign="top" colspan="3">
												<div id="divPanel" style="DISPLAY: none; OVERFLOW: auto; WIDTH: 100%; HEIGHT: 350px"
													align="center">
													<!--
													<asp:panel id="Panel1" runat="server" Width="500" Height="344" BackColor="#C8D3E1">
													-->
													<TABLE id="Table2" style="WIDTH: 100%; HEIGHT: 344px; TEXT-ALIGN: center" borderColor="#000099"
														cellSpacing="0" cellPadding="0" width="320" align="center" border="3">
														<TR>
															<TD align="center" width="321">
																<TABLE id="Table3" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD>
																			<asp:button id="cbFind" runat="server" Width="46px" CssClass="slectedbutton" Text="Find" onclick="cbFind_Click"></asp:button></TD>
																		<TD style="WIDTH: 213px">
																			<asp:textbox id="tbFilter" runat="server" Width="194px"></asp:textbox></TD>
																		<TD>
																			<asp:linkbutton id="lbShowAll" runat="server" CssClass="headerFont" onclick="lbShowAll_Click">Show All</asp:linkbutton></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD align="center">
																<asp:datagrid id="dgEmails" runat="server" Height="100%" Width="100%" AutoGenerateColumns="False"
																	PageSize="10" DESIGNTIMEDRAGDROP="1187">
																	<FooterStyle CssClass="bsFootertd"></FooterStyle>
																	<AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
																	<ItemStyle CssClass="bsnormaltd"></ItemStyle>
																	<HeaderStyle CssClass="headertd"></HeaderStyle>
																	<Columns>
																		<asp:BoundColumn DataField="Fullname" SortExpression="Fullname" HeaderText="Full Name"></asp:BoundColumn>
																		<asp:BoundColumn DataField="ContactEmail" SortExpression="ContactEmail" HeaderText="ContactEmail"></asp:BoundColumn>
																		<asp:TemplateColumn HeaderText="Select">
																			<ItemTemplate>
																				<asp:CheckBox id="cbxSelect" runat="server"></asp:CheckBox>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																	</Columns>
																	<PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
																</asp:datagrid></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 320px">
																<p>
																	<asp:button id="cbAdd" runat="server" Visible="False" CssClass="slectedbutton" Text="Add Emails" onclick="cbAdd_Click"></asp:button>
																	<INPUT class="slectedbutton" id="btnAddEmails" style="WIDTH: 48px; HEIGHT: 19px" onclick="saveEmails();"
																		type="button" value="Add" name="btnAddEmails"> <INPUT class="slectedbutton" id="btnClose" onclick="closePanel()" type="button" value="Close"
																		name="btnClose">
																</p>
																<p>
																	<asp:label id="Label1" runat="server" Visible="False" Width="304px" CssClass="formslabels">This item does not exist, please try again</asp:label>
																</p>
															</TD>
														</TR>
													</TABLE>
													<!--
													</asp:panel>
													-->
												</div>
											</TD>
										</TR>
										<tr>
											<td style="WIDTH: 10%; HEIGHT: 81px" rowSpan="3">&nbsp;
												<asp:button id="btnSendMail" runat="server" Width="66px" Height="80px" Text="Send" Enabled="False" onclick="btnSendMail_Click"></asp:button></td>
											<td style="WIDTH: 9.11%; HEIGHT: 27px; TEXT-ALIGN: right"><asp:label id="lblFrom" runat="server" Font-Size="X-Small">From...</asp:label></td>
											<td style="WIDTH: 80%; HEIGHT: 27px; TEXT-ALIGN: left"><asp:textbox id="txtFrom" runat="server" Width="500px" ReadOnly="True"></asp:textbox></td>
										</tr>
										<tr>
											<td style="WIDTH: 9.11%; TEXT-ALIGN: right"><INPUT id="btnTo" style="WIDTH: 53px; HEIGHT: 24px" onclick="openEmail('btnTo');" type="button"
													value="To..."></td>
											<td style="WIDTH: 80%; TEXT-ALIGN: left"><asp:textbox id="txtTo" runat="server" Width="500px"></asp:textbox></td>
										</tr>
										<tr>
											<td style="WIDTH: 9.11%; HEIGHT: 24px; TEXT-ALIGN: right"><INPUT id="btnCC" style="WIDTH: 53px; HEIGHT: 24px" onclick="openEmail('btnCC');" type="button"
													value="CC..." name="Button1"></td>
											<td style="WIDTH: 80%; HEIGHT: 24px; TEXT-ALIGN: left"><asp:textbox id="txtCC" runat="server" Width="500px"></asp:textbox></td>
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
											<td colSpan="3">
												<ftb:freetextbox id="FreeTextBox1" runat="server" Width="550px" Height="500px" SupportFolder="aspnet_client/FreeTextBox/"
													ToolbarImagesLocation="ExternalFile" JavaScriptLocation="ExternalFile" ButtonImagesLocation="ExternalFile"
													Focus="True" EnableHtmlMode="False" ToolbarLayout="FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline|JustifyLeft,JustifyCenter,JustifyRight|BulletedList,NumberedList,Print"></ftb:freetextbox>
											</td>
										</TR>
									</TBODY>
								</table>
							</div>
						</td>
					</tr>
					<TR>
						<TD class="whitetd" vAlign="top" width="80%"></TD>
					</TR>
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
