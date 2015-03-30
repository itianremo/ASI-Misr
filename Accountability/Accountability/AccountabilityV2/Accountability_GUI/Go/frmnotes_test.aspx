<%--<%@ Reference Page="~/go/test.aspx" %>--%>
<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation" %>

<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.Go.frmNotes_test" ValidateRequest="false"
    CodeFile="frmNotes_test.aspx.cs" Async="true" %>

<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Notes</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <style type="text/css">
    .style2 { FONT-SIZE: 12px; FONT-FAMILY: Arial, Helvetica, sans-serif }
	.btn { BORDER-RIGHT: #000066 1px solid; BORDER-TOP: #000066 1px solid; FONT-SIZE: 10px; BORDER-LEFT: #000066 1px solid; COLOR: #000066; BORDER-BOTTOM: #000066 1px solid; FONT-FAMILY: Arial, Helvetica, sans-serif; BACKGROUND-COLOR: #ffffff; br: bold }
		</style>
    <link href="../Acc1.css" type="text/css" rel="stylesheet">

    <script language="javascript" src="accMethods.js"></script>
     <script language="JavaScript" src="spell.js" type="text/javascript"></script>

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
		var oTbl;
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
			firstLoad=false;
			
		}
		function SaveNoteInAcc()
		{
			//document.getElementById('wait').style.visibility = "visible";
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
			//window.opener.saveSheet(1);
			//
			closeNotes();
		}
		var skipcycle = false;
		function OutOfNotesWindow()
		{
			//alert("You got out");
			firstLoad=false;
			//window.focus();
			if (!skipcycle)
			{
				//window.focus(); 
			}
			mytimer = setTimeout('OutOfNotesWindow()', 100);
		}
		var ShouldSave=false;
		function NotesClosed()
		{
			//  alert("You got out");
		    //document.getElementById('wait').style.visibility = "visible";
			window.opener.IsNotesPopupOpened=false;
			////////////////////if(ShouldSave)//If user clicked on Save or Send (ShouldSave = true)save the sheet else ignore saving the sheet
			////////////////////{
			if(ShouldSave)//If user clicked on Save or Send (ShouldSave = true)save the sheet else ignore saving the sheet
			{
				window.opener.saveSheet(1);
			}
			////////////////////}
			//window.opener.isFocused = false;
			//refresh or reload accountability sheet
			////////////////////window.opener.location.reload(true);
			////////////////////window.opener.refreshForm();
			// end of adding
			
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
			firstLoad=false;
			mailButton=vmailButton;
			ShowAll(1);
			toggleLayer('divPanel','block');
			//displayEmails(vmailButton);
								
				
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
				//alert('btnTo '+toValue+'');
				if(toValue == '')
				{
					document.getElementById("txtTo").value = Emails;
					//toggleLayer('divPanel','none');				
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
			toggleLayer('divPanel','none');
			UncheckAllMailCheckBoxes();
			
			//document.getElementById('divPanel').style.display="inline";	
			//document.getElementById('divPanel').style.visibility = "hidden";
			//closePanel();
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
			for(i = 1; i < len; i++) 
			{   
				var chk = grid.rows[i].cells[0].children[0];
				if(chk.type=='checkbox' && chk.checked)
				{
					//alert(grid.rows[i].cells[1].innerHTML); 
					if(Emails == '')
					{
						Emails += grid.rows[i].cells[2].innerHTML;
					}
					else
					{
						Emails += ";"+grid.rows[i].cells[2].innerHTML;
					}
				}
			} 
			//alert(Emails);
			return Emails;
		}
		function closePanel()
		{
			//CloseEmailsWindow('close');
			//document.getElementById('divPanel').style.visibility="hidden";	
			toggleLayer('divPanel','none');
			UncheckAllMailCheckBoxes();
		}
		
		function UncheckAllMailCheckBoxes()
		{
			var grid = document.getElementById('dgEmails');
			var len = grid.rows.length; 		     
		     var Emails='';
			// touch each row, retrieve cell 1 innerHTML 
			for(i = 1; i < len-1; i++) 
			{   
				var chk = grid.rows[i].cells[0].children[0];
				if(chk.type=='checkbox' && chk.checked)
				{
					chk.checked=false;
				}
			} 
		}
		
		
		function toggleLayer(whichLayer,action1)
		{
   
			var elem, vis;
			if(document.getElementById) // this is the way the standards work
			elem = document.getElementById(whichLayer);
			else if(document.all) // this is the way old msie versions work
			elem = document.all[whichLayer];
			else if(document.layers) // this is the way nn4 works
			elem = document.layers[whichLayer];
			vis = elem.style;
		// alert(action1+'');
			// if the style.display value is blank we try to figure it out here
		    
		// if(vis.display==''&&elem.offsetWidth!=undefined&&elem.offsetHeight!=undefined)
		// vis.display = (elem.offsetWidth!=0&&elem.offsetHeight!=0)?'block':'none';
		  
			//vis.display = (vis.display==''||vis.display=='block')?'none':'block';
			vis.display=action1;
		}
   		String.prototype.startsWith = function(str) 
		{
			return (this.match("^"+str)==str)
		}
		String.prototype.endsWith = function(str)
		{
			return (this.match(str+"$")==str)
		}
		function RemoveFromGrid()
		{		
			ShowAll(0);//This is to fill the grid with all email then fitering it 	
			var grid = document.getElementById('dgEmails');			
			//alert(grid.rows.length);
			//backupGrid=grid;
			var len = grid.rows.length; 
			var searchValue=document.getElementById('tbFilter').value;			
			//document.getElementById('tbFilter').value = searchValue;//Write the search criteria again in the filter textbox
			//alert(searchValue);		     
			for(i = len-1; i >= 1; i--) 
			{   
				var emailValue = grid.rows[i].cells[1].innerHTML;
				//alert(emailValue);
				if(!emailValue.toUpperCase().startsWith(searchValue.toUpperCase()))

				{
				//alert(i);
					grid.deleteRow(i);
					//alert(grid.rows.length);
				}								
			} 
		}
		function ShowAll(flag)
		{
			//alert(backupGrid.rows.length);
			//document.getElementById('dgEmails') = backupGrid;
			//drawGrid(document.getElementById('dgEmails'));
			
			//alert('Before Delete'+grid.rows.length);
			//First Delete All Rows
			var grid = document.getElementById('dgEmails');			
			var len = grid.rows.length; 	     
			for(i = len-1; i >= 1; i--) 
			{   
				grid.deleteRow(i);
			}		
			//alert('After Delete'+grid.rows.length);
			/////////////////////////
			//Second Add All Rows
			var tblLength=oTbl.rows.length;
			//alert(tblLength);
			//alert(oTbl.rows[0].cells[0].innerHTML);
			for(i=0;i<tblLength;i++)
			{
				var  oTR= grid.insertRow(i+1);				
				if(i%2==0)
				{
					oTR.className="bsnormaltd";
				}
				else
				{
					oTR.className="bsalternativetd";
				}
				
				var  oTD0= oTR.insertCell(0);
				oTD0.style.textAlign="left";      
				//oTD0.InnerHTML=oTbl.rows[i].cells[0].innerHTML;
				var  oTD1= oTR.insertCell(1);
				oTD1.style.textAlign="left";      
				//oTD1.InnerHTML=oTbl.rows[i].cells[1].innerHTML;
				var  oTD2= oTR.insertCell(2);  
				oTD2.style.textAlign="center";    
				//oTD2.InnerHTML=oTbl.rows[i].cells[2].innerHTML;
				
				grid.rows[i+1].cells[0].innerHTML = oTbl.rows[i].cells[0].innerHTML;
				grid.rows[i+1].cells[1].innerHTML = oTbl.rows[i].cells[1].innerHTML;
				grid.rows[i+1].cells[2].innerHTML = oTbl.rows[i].cells[2].innerHTML;
				
				//alert(grid.rows[i+1].cells[0].innerHTML);
				//alert(grid.rows[i+1].cells[1].innerHTML);
				//alert(grid.rows[i+1].cells[2].innerHTML);
			}
			//alert('After Add'+grid.rows.length);					
			/////////////////////
			if(flag==1)
			document.getElementById('tbFilter').value = "";
		}
		function drawGrid(grid)
		{		
			oTbl=document.createElement("Table");	
			for(i=1;i<grid.rows.length;i++)
			{
				var  oTR= oTbl.insertRow(i-1);
				//oTR.className="bsnormaltd";
				
				var  oTD0= oTR.insertCell(0);      
				//oTD0.InnerHTML=grid.rows[i].cells[0].innerHTML;
				var  oTD1= oTR.insertCell(1);      
				//oTD1.InnerHTML=grid.rows[i].cells[1].innerHTML;
				var  oTD2= oTR.insertCell(2);      
				//oTD2.InnerHTML=grid.rows[i].cells[2].innerHTML;
				
				oTbl.rows[i-1].cells[0].innerHTML = grid.rows[i].cells[0].innerHTML;
				oTbl.rows[i-1].cells[1].innerHTML = grid.rows[i].cells[1].innerHTML;
				oTbl.rows[i-1].cells[2].innerHTML = grid.rows[i].cells[2].innerHTML;
				//if(i%2==0)
				//{
				//	oTbl.rows[i-1].className="bsnormaltd";
				//}
				//else
				//{
				//	oTbl.rows[i-1].className="bsalternativetd";
				//}
				
				//alert(oTbl.rows[i-1].cells[0].innerHTML);
				//alert(oTbl.rows[i-1].cells[1].innerHTML);
				//alert(oTbl.rows[i-1].cells[2].innerHTML);
			}
			//document.body.appendChild(oTbl);
			//alert(oTbl.rows.length);
		}
		function ShowHideEmailsGrid(action)
		{
				document.getElementById('divPanel').style.display=action;
		}
    </script>

</head>
<body onfocus="LoadNotes();" onbeforeunload="NotesClosed();" onload="toggleLayer('divPanel','none');drawGrid(document.getElementById('dgEmails'));mytimer = setTimeout('OutOfNotesWindow()', 100);">
    <form id="Form1" method="post" runat="server">
        <div align="center">
            <table align="center" style="width: 750px; height: 100%" class="FunctionBlock">
                <tr>
                    <td class="headertd" style="height: 25px">
                        Notes
                    </td>
                </tr>
                <tr>
                    <td valign="top" width="80%">
                        <!--- our div----->
                        <div id="divEmail" align="center">
                            <asp:Label ID="lblNote" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                            <table style="text-align: center">
                                <tbody style="text-align: center" valign="top">
                                    <tr>
                                        <td style="width: 10%">
                                        </td>
                                        <td style="width: 9.11%; height: 27px; text-align: right">
                                        </td>
                                        <td style="width: 80%; height: 27px; text-align: left">
                                            &nbsp;<asp:Label ID="Label2" runat="server" Font-Size="Small">Sending Method : </asp:Label>
                                            <asp:RadioButtonList ID="rblSendingMethod" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblSendingMethod_SelectedIndexChanged"
                                                RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                <asp:ListItem Selected="True" Value="0">Internal</asp:ListItem>
                                                <asp:ListItem Value="1">External</asp:ListItem>
                                            </asp:RadioButtonList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 10%; height: 27px;">
                                        </td>
                                        <td style="width: 9.11%; height: 27px; text-align: right">
                                            &nbsp;</td>
                                        <td style="width: 80%; height: 27px; text-align: left">
                                            <div id="divPanel" style="width: auto; position: absolute; left: 22px; top: 399px;" align="center" class="FunctionBlock">
                                                <asp:Panel ID="Panel1" runat="server" Height="344" Width="500">
                                                    <table id="Table2" style="width: 500px; height: 344px; text-align: center" cellspacing="0"
                                                        cellpadding="0" width="500" align="center" border="0">
                                                        <tr>
                                                            <td align="center" width="500">
                                                                <table id="Table3" height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                    <tr>
                                                                        <td style="width: 51px">
                                                                            <input class="slectedbutton" id="btnRemove" style="width: 46px" onclick="RemoveFromGrid();"
                                                                                type="button" value="Find">
                                                                            <!--<asp:button id="cbFind" runat="server" Width="46px" CssClass="slectedbutton" Text="Find"></asp:button>-->
                                                                        </td>
                                                                        <td style="width: 202px">
                                                                            <asp:TextBox ID="tbFilter" runat="server" Width="194px"></asp:TextBox></td>
                                                                        <td>
                                                                            <a class="headerFont" style="cursor: hand; color: blue; text-decoration: underline"
                                                                                onclick="ShowAll(1);">Show All</a>
                                                                            <!--<asp:linkbutton id="lbShowAll" runat="server" CssClass="headerFont">Show All</asp:linkbutton>-->
                                                                            <!--<INPUT id="btnRemove2" style="WIDTH: 72px; HEIGHT: 24px" onclick="RemoveFromGrid();" type="button" value="btnRemove"> 
																										<INPUT id="btnShowAll2" style="WIDTH: 72px; HEIGHT: 24px" onclick="ShowAll();" type="button" value="btnShowAll" name="Button1">-->
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div style="overflow: auto; height: 300px">
                                                                    <asp:DataGrid ID="dgEmails" runat="server" Width="100%" DESIGNTIMEDRAGDROP="1187"
                                                                        PageSize="10" AutoGenerateColumns="False">
                                                                        <FooterStyle CssClass="bsFootertd"></FooterStyle>
                                                                        <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                                                                        <ItemStyle CssClass="bsnormaltd"></ItemStyle>
                                                                        <HeaderStyle CssClass="whitetd"></HeaderStyle>
                                                                        <Columns>
                                                                        <asp:TemplateColumn HeaderText="Select">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="cbxSelect" runat="server"></asp:CheckBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                            <asp:BoundColumn DataField="Fullname" SortExpression="Fullname" HeaderText="Full Name">
                                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                            </asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="ContactEmail" SortExpression="ContactEmail" HeaderText="ContactEmail">
                                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                            </asp:BoundColumn>
                                                                            
                                                                        </Columns>
                                                                        <PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
                                                                    </asp:DataGrid></div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 500px" align="center">
                                                                <p>
                                                                    &nbsp;
                                                                    <asp:Button ID="cbAdd" runat="server" Visible="False" Text="Add Emails" CssClass="slectedbutton">
                                                                    </asp:Button><input class="slectedbutton" id="btnAddEmails" style="width: 48px; height: 19px"
                                                                        onclick="saveEmails();" type="button" value="Add" name="btnAddEmails">
                                                                    <input class="slectedbutton" id="btnClose" onclick="closePanel()" type="button" value="Close"
                                                                        name="btnClose"></p>
                                                                <p>
                                                                    <asp:Label ID="Label1" runat="server" Visible="False" Width="304px" CssClass="formslabels">This item does not exist, please try again</asp:Label></p>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 10%; height: 83px" rowspan="4" valign="bottom">
                                            &nbsp;
                                            <!--<asp:button id="btnSendMail" runat="server" Text="Send" Width="66px" Enabled="False" Height="80px"></asp:button>-->
                                            <asp:ImageButton ID="imgSendMail" runat="server" ImageUrl="images/Send_n.jpg" OnClick="btnSendMail_Click"></asp:ImageButton>
                                        </td>
                                        <td style="width: 9.11%; height: 27px; text-align: right">
                                            <asp:Label ID="lblFrom" runat="server" Font-Size="X-Small">From...</asp:Label></td>
                                        <td style="width: 80%; height: 27px; text-align: left">
                                            <asp:TextBox ID="txtFrom" runat="server" Width="500px" ReadOnly="True" onfocus="skipcycle=true"
                                                onblur="skipcycle=false"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 9.11%; height: 27px; text-align: right">
                                        </td>
                                        <td style="width: 80%; height: 27px; text-align: left">
                                            <asp:CheckBox ID="cbSendMeAcopy" runat="server" Font-Size="Small" Text="Send me a copy" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 9.11%; text-align: right">
                                            <input id="btnTo" style="width: 53px; height: 24px" onclick="openEmail('btnTo');"
                                                type="button" value="To..."></td>
                                        <td style="width: 80%; text-align: left">
                                            <asp:TextBox ID="txtTo" runat="server" Width="500px" onfocus="skipcycle=true" onblur="skipcycle=false"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 9.11%; height: 26px; text-align: right">
                                            <input id="btnCC" style="width: 53px; height: 24px" onclick="openEmail('btnCC');"
                                                type="button" value="CC..." name="Button1"></td>
                                        <td style="width: 80%; height: 26px; text-align: left">
                                            <asp:TextBox ID="txtCC" runat="server" Width="500px" onfocus="skipcycle=true" onblur="skipcycle=false"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 10%">
                                            &nbsp;
                                            <!--<INPUT id="btnCancelNote" style="WIDTH: 64px; HEIGHT: 24px" onclick="ShouldSave=false;closeNotes();" type="button" value="Cancel">-->
                                            <img onmousedown="src='images/Cancel_s.jpg'" id="imgCancelNote" onmouseover="src='images/Cancel_o.jpg'"
                                                onclick="ShouldSave=false;closeNotes();" onmouseout="src='images/Cancel_n.jpg'"
                                                alt="Cancel" src="images/Cancel_n.jpg">
                                        </td>
                                        <td style="width: 9.11%; text-align: right">
                                            <input id="btnBCC" style="width: 53px; height: 24px" onclick="openEmail('btnBCC');"
                                                type="button" value="BCC..." name="Button2"></td>
                                        <td style="width: 80%; text-align: left">
                                            <asp:TextBox ID="txtBCC" runat="server" Width="500px" onfocus="skipcycle=true" onblur="skipcycle=false"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 10%; height: 25px">
                                            &nbsp;
                                            <!--<INPUT id="btnSaveNote" style="WIDTH: 64px; HEIGHT: 24px" onclick="ShouldSave=true;SaveNoteInAcc();" type="button" value="Save">-->
                                            <img onmousedown="src='images/Save_s.jpg'" id="imgSaveNote" onmouseover="src='images/Save_o.jpg'"
                                                onclick="ShouldSave=true;SaveNoteInAcc();" onmouseout="src='images/Save_n.jpg'"
                                                alt="Save" src="images/Save_n.jpg">
                                        </td>
                                        <td style="width: 9.11%; height: 25px; text-align: right">
                                            <asp:Label ID="lblSubject" runat="server" Font-Size="X-Small">Subject...</asp:Label></td>
                                        <td style="width: 80%; height: 25px; text-align: left">
                                            <asp:TextBox ID="txtSubject" runat="server" Width="500px" onfocus="skipcycle=true"
                                                onblur="skipcycle=false"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 10%; height: 25px">
                                        </td>
                                        <td style="width: 9.11%; height: 25px; text-align: right">
                                        </td>
                                        <td style="width: 80%; height: 25px; text-align: center">
                                            <div id="wait" style="visibility: hidden" align="center">
                                                <font face="Arial, Helvetica, sans-serif" color="#003366" size="1">Please wait</font><br>
                                                <img height="7" alt="1" src="images/loading.gif" width="78">
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <ftb:FreeTextBox ID="FreeTextBox1" runat="server" Width="550px" Height="500px" ToolbarLayout="FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline|JustifyLeft,JustifyCenter,JustifyRight|BulletedList,NumberedList,Print"
                                                EnableHtmlMode="False" Focus="True" ButtonImagesLocation="ExternalFile" JavaScriptLocation="ExternalFile"
                                                ToolbarImagesLocation="ExternalFile" SupportFolder="aspnet_client/FreeTextBox/" ButtonWidth="19" BreakMode="LineBreak">
                                            </ftb:FreeTextBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="whitetd" valign="top" width="80%">
                    </td>
                </tr>
            </table>
            <br>
            <table width="100%" align="center" border="0">
                <tr align="center">
                    <td>
                    </td>
                </tr>
            </table>
            <p>
            </p>
        </div>
        <p align="center">
    </form>
</body>
</html>
