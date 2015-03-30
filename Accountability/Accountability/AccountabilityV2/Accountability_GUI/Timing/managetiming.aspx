<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation" %>
<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<%@ Page Language="c#" Inherits="TSN.ERP.WebGUI.Timing.ManageTiming" EnableSessionState="True"
    CodeFile="ManageTiming.aspx.cs" ValidateRequest="false" Async="true" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns:o="urn:schemas-microsoft-com:office:office">
<head runat="server">
    <title>Manage Timing</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <style type="text/css">.style2 { FONT-SIZE: 12px; FONT-FAMILY: Arial, Helvetica, sans-serif }
	.btn { BORDER-RIGHT: #000066 1px solid; BORDER-TOP: #000066 1px solid; FONT-SIZE: 10px; BORDER-LEFT: #000066 1px solid; COLOR: #000066; BORDER-BOTTOM: #000066 1px solid; FONT-FAMILY: Arial, Helvetica, sans-serif; BACKGROUND-COLOR: #ffffff; br: bold }
		</style>
    <link href="../Acc1.css" type="text/css" rel="stylesheet">

    <script>
		function HI()
		{
			//alert('hi');
			document.getElementById("Button1").click();
//			toggleLayer('divPanel','none');
		}
		
		var oTbl;
		var mailButton;
		var firstLoad=true;
		function openEmail(vmailButton)
		{										
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
				var toValue =document.getElementById("txtboxTo").value;
				//alert('btnTo '+toValue+'');
				if(toValue == '')
				{
					document.getElementById("txtboxTo").value = Emails;
					//toggleLayer('divPanel','none');				
				}
				else
				{
					document.getElementById("txtboxTo").value += ";"+Emails;
					//alert('toooooo '+toValue+';'+Emails);
						
				}
			}
			else if(mailButton == "btnCC")
			{
				var CCValue = document.getElementById("txtboxCC").value;
				if(CCValue == '')
				{
					document.getElementById("txtboxCC").value = Emails;
				}			
				else
				{
					document.getElementById("txtboxCC").value += ";"+Emails;
				}			
			}
			else if(mailButton == "btnBCC")
			{
				var BCCValue = document.getElementById("txtboxBCC").value;
				if(BCCValue == '')				
				{
					document.getElementById("txtboxBCC").value = Emails;
				}
				else
				{
					document.getElementById("txtboxBCC").value += ";"+Emails;
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
				var chk = grid.rows[i].cells[2].children[0];
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
			try
			{
			vis = elem.style;
		// alert(action1+'');
			// if the style.display value is blank we try to figure it out here
		    
		// if(vis.display==''&&elem.offsetWidth!=undefined&&elem.offsetHeight!=undefined)
		// vis.display = (elem.offsetWidth!=0&&elem.offsetHeight!=0)?'block':'none';
		  
			//vis.display = (vis.display==''||vis.display=='block')?'none':'block';
			vis.display=action1;
			}	
			catch(err)
			{
			}			
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
				if(!emailValue.startsWith(searchValue))
				{
				//alert(i);
					grid.deleteRow(i);
					//alert(grid.rows.length);
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
			try
			{
			vis = elem.style;
		// alert(action1+'');
			// if the style.display value is blank we try to figure it out here
		    
		// if(vis.display==''&&elem.offsetWidth!=undefined&&elem.offsetHeight!=undefined)
		// vis.display = (elem.offsetWidth!=0&&elem.offsetHeight!=0)?'block':'none';
		  
			//vis.display = (vis.display==''||vis.display=='block')?'none':'block';
			vis.display=action1;
			}
			catch(err)
			{
			}	
		}
		String.prototype.startsWith = function(str) 
		{
			return (this.match("^"+str)==str)
		}
		String.prototype.endsWith = function(str)
		{
			return (this.match(str+"$")==str)
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
		try{			
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
			}
			catch(err)
			{
			var errTxt= err;
			}
			//document.body.appendChild(oTbl);
			//alert(oTbl.rows.length);
		}
    </script>

    <script language="JavaScript" src="spell.js" type="text/javascript"></script>

</head>
<body dir="ltr" onload="toggleLayer('divPanel','none');drawGrid(document.getElementById('dgEmails'));">
    <form id="Form1" method="post" runat="server">
        <div align="center">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
        <div align="center">
        <table align=center border=0 width=100%>
        <tr align=center >
        <td>&nbsp;</td>
        <td valign=top align=right width="50%">&nbsp;
            <table class="FunctionBlock" width="100%" align=center>
                <tr>
                    <td class="whitetd" style="height: 25px" colspan="5">
                        Employee Information</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label5" runat="server">Employee</asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlEmployees" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEmployees_SelectedIndexChanged"
                            CssClass="inputtext">
                        </asp:DropDownList></td>
                    <td align="right">
                        <asp:Label ID="lblEmployeeNumber" runat="server" Text="Employee Number"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtEmployeeNumber" runat="server" Width="83px" CssClass="inputtext" ReadOnly="True"></asp:TextBox></td>
                    <td>
                        <asp:DropDownList ID="ddlExempt" runat="server" Width="103px" CssClass="inputtext" Enabled="False">
                            <asp:ListItem Value="0">Non Exempt</asp:ListItem>
                            <asp:ListItem Value="1">Exempt</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblDepartment" runat="server" Text="Department"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtDepartment" runat="server" CssClass="inputtext" ReadOnly="True"></asp:TextBox></td>
                    <td align="right">
                        <asp:Label ID="lblManager" runat="server" Text="Manager"></asp:Label></td>
                    <td colspan="2">
                        <asp:TextBox ID="txtManager" runat="server" Width="201px" CssClass="inputtext" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label6" runat="server">Date</asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtDate" runat="server" ToolTip="Click to choose a date" CssClass="inputtext"
                            Width="82px"></asp:TextBox>
                        <img id="imgCal" height="15" alt="Pick a Date" src="../go/images/dlcalendar_1.gif"
                            width="20" name="imgCal" runat="server" />
                        <cc2:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="imgCal"
                            TargetControlID="txtDate" FirstDayOfWeek="Sunday" OnClientDateSelectionChanged="HI"
                            PopupPosition="Right" CssClass="MyCalendar">
                        </cc2:CalendarExtender>
                        
                         <%-- <span>
                        <input class="inputtext" id="txtDate2" type="text"  onchange="bindTimingEmpData(document.getElementById('txtDate2').value);"
                                            size="10" value="11/22/2005" name="txtDate2" style="border-left-color: black;
                                            border-bottom-color: black; color: black; border-top-style: solid; border-top-color: black;
                                            border-right-style: solid; border-left-style: solid; border-right-color: black;
                                            border-bottom-style: solid">
                                    </span>
                                    <dlcalendar firstday="Su" click_element_id="imgCal2" input_element_id="txtDate2" tool_tip="Click to choose a date">
                                  <IMG id="imgCal2" height="15" alt="Pick a Date" src="../go/images/dlcalendar_1.gif" width="20" name="imgCal2"/>--%>
                    </td>
                    <%--                    <td>
                       <dlcalendar callfunction_onselection="HI" firstday="Su" click_element_id="imgCal"
                            input_element_id="txtDate" tool_tip="Click to choose a date">                   
                        <img id="imgCal" height="15" alt="Pick a Date" src="../go/images/dlcalendar_1.gif"
                            width="20" name="imgCal" runat="server" />
                      
                    </td>--%>
                    <td align="right">
                        <asp:Label ID="lblDay" runat="server" Text="Day"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtDay" runat="server" Width="85px" CssClass="inputtext" ReadOnly="True"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="lblShift" runat="server" Text="Shift"></asp:Label>
                        <asp:DropDownList ID="ddlShift" runat="server" CssClass="inputtext" DataTextField="ShiftName"
                            DataValueField="ShiftID" Enabled="False">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="center" colspan="5">
                        Total Check In Time:
                        <asp:Label ID="lblTotalCheckInTime" runat="server"></asp:Label>
                        Hours</td>
                </tr>
            </table>
            <table align="center" class="FunctionBlock" width="100%">
                <tr>
                    <td class="whitetd" style="height: 25px">
                        Time Card Edit</td>
                </tr>
                <tr>
                    <td valign="top" width="80%" style="height: 218px">
                        <!--- our div----->
                        <div id="divEmail" align="center">
                            <table style="text-align: center" width="100%">
                                <tbody style="text-align: center" valign="top">
                                    <tr>
                                        <td style="width: 80%; height: 26px; text-align: left">
                                            <%--<asp:Button ID="tnAddRecord" runat="server" Text="Add Record" OnClick="tnAddRecord_Click">
                                            </asp:Button>--%>
                                            <asp:ImageButton ID="tnAddRecord" runat="server" OnClick="tnAddRecord_Click" ImageUrl="~/Go/images/Buttons/newAddRecord_n.jpg"
                                                onmouseover="this.src='../Go/images/Buttons/newAddRecord_o.jpg'" onmousedown="this.src='../Go/images/Buttons/newAddRecord_s.jpg'"
                                                onmouseout="this.src='../Go/images/Buttons/newAddRecord_n.jpg'" ToolTip="Add new Record" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 80%; text-align: left; height: 171px;">
                                            <asp:DataGrid ID="dgTiming" runat="server" DataKeyField="CHECKTYPE" Width="100%"
                                                AutoGenerateColumns="False" DESIGNTIMEDRAGDROP="1187">
                                                <FooterStyle CssClass="bsFootertd"></FooterStyle>
                                                <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                                                <ItemStyle CssClass="bsnormaltd"></ItemStyle>
                                                <HeaderStyle CssClass="whitetd"></HeaderStyle>
                                                <Columns>
                                                    <asp:TemplateColumn HeaderText="Location">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddlLocationI" runat="server" Width="103px" Enabled="False"
                                                                Height="22px" Font-Size="11px">
                                                                <asp:ListItem Value="6">TDC</asp:ListItem>
                                                                <asp:ListItem Value="2">Home</asp:ListItem>
                                                                <asp:ListItem Value="3">On The Road</asp:ListItem>
                                                                <asp:ListItem Value="4">Raleigh</asp:ListItem>
                                                                <asp:ListItem Value="5">Las Vegas</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Label ID="lblLocationI" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.location") %>'
                                                                Visible="False">
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="ddlLocationE" runat="server" Width="105px" Height="22px" Font-Size="11px">
                                                                <asp:ListItem Value="6">TDC</asp:ListItem>
                                                                <asp:ListItem Value="2">Home</asp:ListItem>
                                                                <asp:ListItem Value="3">On The Road</asp:ListItem>
                                                                <asp:ListItem Value="4">Raleigh</asp:ListItem>
                                                                <asp:ListItem Value="5">Las Vegas</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Label ID="lblLocationE" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.location") %>'
                                                                Visible="False">
                                                            </asp:Label>
                                                        </EditItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Status">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddlGridAction" runat="server" Enabled="False" Font-Size="11px">
                                                                <asp:ListItem Value="I">Check In</asp:ListItem>
                                                                <asp:ListItem Value="O">Check Out</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Label ID="lblAction" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CheckType") %>'
                                                                Visible="False">
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="dllGridActionEdit" runat="server" Font-Size="11px">
                                                                <asp:ListItem Value="I">Check In</asp:ListItem>
                                                                <asp:ListItem Value="O">Check Out</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Time">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTime" runat="server" Text='<%# Convert.ToDateTime(Eval("orgCHECKTIME")).ToString("hh:mm tt") %>'></asp:Label>
                                                            <asp:Label ID="lblTimeOriginal" runat="server" Text='<%# Eval("orgCHECKTIME") %>'
                                                                Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <%--<asp:TextBox ID="txtTimeEdit" runat="server" Text='<%# Convert.ToDateTime(Eval("orgCHECKTIME")).ToString("hh:mm tt") %>'
                                                                Font-Size="11px" Width="55px"></asp:TextBox>--%>
                                                            <asp:TextBox ID="txtTimeEdit" runat="server" Text='<%# Convert.ToDateTime(Eval("orgCHECKTIME")).ToString("hh:mm tt") %>' Font-Size="11px"
                                                                Width="120px"></asp:TextBox>
                                                            <asp:Label ID="lblTimeOriginalEdit" runat="server" Text='<%# Eval("orgCHECKTIME") %>'
                                                                Visible="false"></asp:Label>
                                                        </EditItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Modified By">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblModifiedBy" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EditBy") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Date">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblModifyDateEdit" runat="server" Text='<%# Convert.ToDateTime(Eval("CheckTime")).ToString("MM/dd/yyyy") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblModifyDate" runat="server" Text='<%# Convert.ToDateTime(Eval("CheckTime")).ToString("MM/dd/yyyy") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="Edit Note" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEditNote" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EditNote") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:EditCommandColumn UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
                                                    <asp:TemplateColumn>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" Text="Delete" CommandName="Delete"
                                                                CausesValidation="false"></asp:LinkButton>
                                                            <asp:Label ID="lblSerial" runat="server" Visible="False">0</asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </Columns>
                                                <PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
                                            </asp:DataGrid></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
             <table align="center" width="100px">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblNote" runat="server" Visible="False" CssClass="formslabels" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
            </td>
            <td valign=top >&nbsp;
           
            <asp:Panel ID="Panel1" runat="server" Width="100%" Visible="False" CssClass="FunctionBlock">
                <table width="100%">
                    <tr>
                        <td class="whitetd" style="height: 25px"  >
                            Time Card Add</td>
                    </tr>
                </table>
                <table id="Table1" class="FunctionBlock" align=center >
                    <tr>
                        <td style="height: 25px">
                            <asp:Label ID="Label2" runat="server">Time</asp:Label></td>
                        <td style="width: 159px; height: 25px">
                            <asp:TextBox ID="txtAddTime" runat="server" CssClass="inputtext"></asp:TextBox></td>
                        <td style="height: 25px">
                            <asp:DropDownList ID="ddlAMPM" runat="server" CssClass="inputtext">
                                <asp:ListItem Value="AM">AM</asp:ListItem>
                                <asp:ListItem Value="PM">PM</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server">Action</asp:Label></td>
                        <td style="width: 159px">
                            <asp:DropDownList ID="ddlAddAction" runat="server" CssClass="inputtext">
                                <asp:ListItem Value="I">Check In</asp:ListItem>
                                <asp:ListItem Value="O">Check Out</asp:ListItem>
                            </asp:DropDownList></td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblLocation" runat="server">Location</asp:Label></td>
                        <td style="width: 159px">
                            <asp:DropDownList ID="ddLocation" runat="server" CssClass="inputtext">
                                <asp:ListItem Value="6">TDC</asp:ListItem>
                                <asp:ListItem Value="2">Home</asp:ListItem>
                                <asp:ListItem Value="3">On The Road</asp:ListItem>
                                <asp:ListItem Value="4">Raleigh</asp:ListItem>
                                <asp:ListItem Value="5">Las Vegas</asp:ListItem>
                            </asp:DropDownList></td>
                        <td>
                        </td>
                    </tr>
                    </table>
            </asp:Panel>
            <asp:Panel ID="pnlReason" runat="server" Width="100%" Visible="False">
                <table class="FunctionBlock" width="100%">
                    <tr>
                        <td class="whitetd" style="height: 25px" colspan="2">
                            Reason</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Panel ID="pnlEmail" runat="server" Width="100%">
                                <table width="100%" border="1" bordercolor="white">
                                    <tr>
                                        <td width="10%" align="right" style="height: 159px">
                                            <asp:ImageButton ID="imgbtnSend" runat="server" AlternateText="Send Email" ImageUrl="~/Go/images/Buttons/newSend_n.jpg"
                                                OnClick="imgbtnSend_Click" onmouseover="this.src='../Go/images/Buttons/newSend_o.jpg'"
                                                onmousedown="this.src='../Go/images/Buttons/newSend_s.jpg'" onmouseout="this.src='../Go/images/Buttons/newSend_n.jpg'" ToolTip="Send Email" />
                                            <asp:ImageButton ID="imgbtnCancelSend" runat="server" AlternateText="Cancel Sending Email"
                                                ImageUrl="~/Go/images/Buttons/newcancel_n.jpg" OnClick="imgbtnCancelSend_Click"
                                                onmouseover="this.src='../Go/images/Buttons/newcancel_o.jpg'" onmousedown="this.src='../Go/images/Buttons/newcancel_s.jpg'"
                                                onmouseout="this.src='../Go/images/Buttons/newcancel_n.jpg'" ToolTip="Cancel" />
                                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Go/images/Buttons/newSave_btn_n.jpg"
                                                OnClick="ImageButton2_Click" Visible="False" onmouseover="this.src='../Go/images/Buttons/newSave_btn_o.jpg'"
                                                onmousedown="this.src='../Go/images/Buttons/newSave_btn_s.jpg'" onmouseout="this.src='../Go/images/Buttons/newSave_btn_n.jpg'" ToolTip="Save Data">
                                            </asp:ImageButton></td>
                                        <td colspan="2" width="90%" style="height: 159px">
                                            <table id="tblEmail" runat="server" width="100%">
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                                                        <asp:Label ID="lblSendingMethod" runat="server" Font-Size="Small">Sending Method : </asp:Label><asp:RadioButtonList
                                                                                            ID="rblSendingMethod" runat="Server" AutoPostBack="True" OnSelectedIndexChanged="rblSendingMethod_SelectedIndexChanged"
                                                                                            RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                                            <asp:ListItem Selected="True" Value="0">Internal</asp:ListItem>
                                                                                            <asp:ListItem Value="1">External</asp:ListItem>
                                                                                        </asp:RadioButtonList></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <div id="divPanel" runat="server" style="width: auto; position: absolute" align="center" class="FunctionBlock">
                                                            <asp:Panel ID="Panel2" runat="server" Height="344" Width="500">
                                                                <table id="Table2" style="width: 500px; height: 344px; text-align: center" cellspacing="0"
                                                                    cellpadding="0" width="500" align="center" border="0">
                                                                    <tr>
                                                                        <td align="center" style="width: 502px">
                                                                            <table id="Table3" height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                <tr>
                                                                                    <td style="width: 51px">
                                                                                        <input class="slectedbutton" id="btnRemove" style="width: 46px" onclick="RemoveFromGrid();"
                                                                                            type="button" value="Find" title="Find Email">
                                                                                        <!--<asp:button id="cbFind" runat="server" Width="46px" CssClass="slectedbutton" Text="Find"></asp:button>-->
                                                                                    </td>
                                                                                    <td style="width: 250px">
                                                                                        <asp:TextBox ID="tbFilter" runat="server" Width="194px"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <a class="headerFont" style="cursor: hand; color: blue; text-decoration: underline"
                                                                                            onclick="ShowAll(1);">Show All</a>&nbsp;&nbsp;<!--<asp:linkbutton id="lbShowAll" runat="server" CssClass="headerFont">Show All</asp:linkbutton>-->
                                                                                        <!--<INPUT id="btnRemove2" style="WIDTH: 72px; HEIGHT: 24px" onclick="RemoveFromGrid();" type="button" value="btnRemove"> 
																										<INPUT id="btnShowAll2" style="WIDTH: 72px; HEIGHT: 24px" onclick="ShowAll();" type="button" value="btnShowAll" name="Button1">-->
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 318px; width: 502px;">
                                                                            <div style="overflow: auto; height: 300px">
                                                                                <asp:DataGrid ID="dgEmails" runat="server" Width="100%" DESIGNTIMEDRAGDROP="1187"
                                                                                    PageSize="10" AutoGenerateColumns="False">
                                                                                    <FooterStyle CssClass="bsFootertd"></FooterStyle>
                                                                                    <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                                                                                    <ItemStyle CssClass="bsnormaltd"></ItemStyle>
                                                                                    <HeaderStyle CssClass="headertd"></HeaderStyle>
                                                                                    <Columns>
                                                                                        <asp:BoundColumn DataField="Fullname" SortExpression="Fullname" HeaderText="Full Name">
                                                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                                        </asp:BoundColumn>
                                                                                        <asp:BoundColumn DataField="ContactEmail" SortExpression="ContactEmail" HeaderText="ContactEmail">
                                                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                                        </asp:BoundColumn>
                                                                                        <asp:TemplateColumn HeaderText="Select">
                                                                                            <ItemTemplate>
                                                                                                <asp:CheckBox ID="cbxSelect" runat="server"></asp:CheckBox>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateColumn>
                                                                                    </Columns>
                                                                                    <PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
                                                                                </asp:DataGrid></div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 502px" align="center">
                                                                            <p>
                                                                                <input class="slectedbutton" id="btnAddEmails" style="width: 48px; height: 19px"
                                                                                    onclick="saveEmails();" type="button" value="Add" name="btnAddEmails" title="Add Selected Emails">
                                                                                <input class="slectedbutton" id="btnClose" onclick="closePanel()" type="button" value="Close"
                                                                                    name="btnClose" title="Close window"></p>
                                                                            <p>
                                                                                <asp:Label ID="Label3" runat="server" Visible="False" Width="304px" CssClass="formslabels">This item does not exist, please try again</asp:Label></p>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="10%">
                                                        <asp:Label ID="lblFrom" runat="server" CssClass="formslabels">From...</asp:Label></td>
                                                    <td align="left" width="90%">
                                                        <asp:TextBox ID="txtboxEmailFrom" runat="server" CssClass="inputs" Width="98%"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="10%" style="height: 22px" class="formslabels">
                                                        <input id="btnTo" style="width: 53px; height: 24px" onclick="openEmail('btnTo');"
                                                            type="button" value="To..."></td>
                                                    <td align="left" width="90%" style="height: 22px">
                                                        <asp:TextBox ID="txtboxTo" runat="server" CssClass="inputs" Width="98%"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="formslabels">
                                                        <input id="btnCC" style="width: 53px; height: 24px" onclick="openEmail('btnCC');"
                                                            type="button" value="CC..." name="Button1"></td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtboxCC" runat="server" CssClass="inputs" Width="98%"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="formslabels">
                                                        <input id="btnBCC" style="width: 53px; height: 24px" onclick="openEmail('btnBCC');"
                                                            type="button" value="BCC..." name="Button2"></td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtboxBCC" runat="server" CssClass="inputs" Width="98%"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="height: 26px">
                                                        <asp:Label ID="lblSubject" runat="server" CssClass="formslabels">Subject...</asp:Label></td>
                                                    <td align="left" style="height: 26px">
                                                        <asp:TextBox ID="txtboxSubject" runat="server" CssClass="inputs" Width="98%"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                            <asp:Label ID="lblEmailConfirm" runat="server" Font-Bold="False" Font-Names="Tahoma"
                                                Font-Size="12px" ForeColor="Red" Visible="False">Email Sent Successfully</asp:Label></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td valign="bottom" width="10%">
                            <asp:ImageButton ID="ibtnEmail" runat="server" ImageUrl="~/Go/images/Buttons/E.Mail_n.jpg"
                                OnClick="ibtnEmail_Click" onmouseover="this.src='../Go/images/Buttons/E.Mail_o.jpg'"
                                onmousedown="this.src='../Go/images/Buttons/E.Mail_s.jpg'" onmouseout="this.src='../Go/images/Buttons/E.Mail_n.jpg'"
                                Visible="False" ToolTip="Email" />
                        </td>
                        <td rowspan="2">
                            <ftb:FreeTextBox ID="FreeTextBox1" runat="server" ButtonImagesLocation="ExternalFile"
                                EnableHtmlMode="False" EnableToolbars="True" Focus="False" JavaScriptLocation="ExternalFile"
                                PasteMode="Default" SupportFolder="../Go/aspnet_client/FreeTextBox/" ToolbarImagesLocation="ExternalFile"
                                ToolbarLayout="FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline|JustifyLeft,JustifyCenter,JustifyRight|BulletedList,NumberedList,Print"
                                ButtonWidth="17" Height="150px" Width="100%">
                            </ftb:FreeTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">
                            <asp:ImageButton ID="ibtnZoomIn" runat="server" ImageUrl="~/Go/images/Buttons/ZoomIn_n.jpg"
                                OnClick="ibtnZoomIn_Click" ToolTip="Zoom In" onmouseover="this.src='../Go/images/Buttons/ZoomIn_o.jpg'"
                                onmousedown="this.src='../Go/images/Buttons/ZoomIn_s.jpg'" onmouseout="this.src='../Go/images/Buttons/ZoomIn_n.jpg'" />
                            <asp:ImageButton ID="ibtnZoomOut" runat="server" ImageUrl="~/Go/images/Buttons/ZoomOut_n.jpg"
                                OnClick="ibtnZoomOut_Click" ToolTip="Zoom Out" onmouseover="this.src='../Go/images/Buttons/ZoomOut_o.jpg'"
                                onmousedown="this.src='../Go/images/Buttons/ZoomOut_s.jpg'" onmouseout="this.src='../Go/images/Buttons/ZoomOut_n.jpg'" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            
            <table width="100%" align="center" border="0">
                <tr align="center">
                    <td style="height: 26px">
                        <asp:Button ID="Button1" Style="display: none" runat="server" Text="Button" OnClick="Button1_Click">
                        </asp:Button></td>
                </tr>
            </table>
            </td>
            </tr>
            </table>
        </div>
    </form>
    <%--<script language="javascript" src="../go/include/dlcalendar.js" type="text/javascript"></script>--%>
</body>
</html>
