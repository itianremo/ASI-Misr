<%@ Page language="c#" Inherits="TSN.ERP.WebGUI.Go.frmFindEmail" CodeFile="frmFindEmail.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Find Email</title> 
		<!--<base target="_self">-->
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style type="text/css">.style2 { FONT-SIZE: 12px; FONT-FAMILY: Arial, Helvetica, sans-serif }
		</style>
		<LINK href="../Acc1.css" type="text/css" rel="stylesheet">
		<script>
		var mailButton;
		//var txtTo,txtCC,txtBCC;		
		function closeWindow()
		{
			//getEmails();
			window.close();
		}
		function saveEmails2(Emails, mailButton)
		{
			//var mailBtn = window.opener.document.mailButton
			//alert(mailBtn);
			if(mailButton == "btnTo")
			{
				window.opener.document.getElementById("txtTo").value = Emails;
			}
			else if(mailButton == "btnCC")
			{
				window.opener.document.getElementById("txtCC").value = Emails;
			}
			else if(mailButton == "btnBCC")
			{
				window.opener.document.getElementById("txtBCC").value = Emails;
			}
			window.close();
		}
		function saveEmailsOld()
		{
			var Emails = getEmails();
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
				var toValue = txtTo;
				if(toValue == '')
				{
					txtTo = Emails;
				}
				else
				{
					txtTo += ";"+Emails;
				}
				window.returnValue = txtTo;
			}
			else if(mailButton == "btnCC")
			{
				var CCValue = txtCC;
				if(CCValue == '')
				{
					txtCC = Emails;
				}			
				else
				{
					txtCC += ";"+Emails;
				}
				window.returnValue = txtCC;				
			}
			else if(mailButton == "btnBCC")
			{
				var BCCValue = txtBCC;
				if(BCCValue == '')				
				{
					txtBCC = Emails;
				}
				else
				{
					txtBCC += ";"+Emails;
				}
				window.returnValue = txtBCC;
			}
			window.close();
		}
		function saveEmails()
		{			
			var Emails = getEmails();
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
				var toValue = window.opener.document.getElementById("txtTo").value;
				if(toValue == '')
				{
					window.opener.document.getElementById("txtTo").value = Emails;				
				}
				else
				{
					window.opener.document.getElementById("txtTo").value += ";"+Emails;
				}
			}
			else if(mailButton == "btnCC")
			{
				var CCValue = window.opener.document.getElementById("txtCC").value;
				if(CCValue == '')
				{
					window.opener.document.getElementById("txtCC").value = Emails;
				}			
				else
				{
					window.opener.document.getElementById("txtCC").value += ";"+Emails;
				}			
			}
			else if(mailButton == "btnBCC")
			{
				var BCCValue = window.opener.document.getElementById("txtBCC").value;
				if(BCCValue == '')				
				{
					window.opener.document.getElementById("txtBCC").value = Emails;
				}
				else
				{
					window.opener.document.getElementById("txtBCC").value += ";"+Emails;
				}
			}
			window.close();
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
		function OutOfEmailsWindow()
		{
			//window.focus();
		}
		</script>
	</HEAD>
	<body onblur="OutOfEmailsWindow();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" style="Z-INDEX: 101; LEFT: 16px; WIDTH: 320px; POSITION: absolute; TOP: 8px; HEIGHT: 344px"
				cellSpacing="0" cellPadding="0" width="320" align="center" border="0" class="FunctionBlock">
				<TR>
					<TD style="WIDTH: 321px" align="center">
						<TABLE id="Table3" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0" >
							<TR>
								<TD><asp:button id="cbFind" runat="server" Text="Find" Width="46px" CssClass="slectedbutton" onclick="cbFind_Click"></asp:button></TD>
								<TD style="WIDTH: 213px"><asp:textbox id="tbFilter" runat="server" Width="194px"></asp:textbox></TD>
								<TD><asp:linkbutton id="lbShowAll" runat="server" CssClass="headerFont" onclick="lbShowAll_Click">Show All</asp:linkbutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 320px"><asp:datagrid id="dgEmails" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="40"
							AllowPaging="True">
							<FooterStyle CssClass="bsFootertd"></FooterStyle>
							<AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
							<ItemStyle CssClass="bsnormaltd"></ItemStyle>
							<HeaderStyle CssClass="whitetd"></HeaderStyle>
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
						<P><asp:button id="cbAdd" runat="server" Text="Add Emails" CssClass="slectedbutton" Visible="False" onclick="cbAdd_Click"></asp:button><INPUT class="slectedbutton" id="btnAddEmails" style="WIDTH: 48px; HEIGHT: 19px" onclick="saveEmails();"
								type="button" value="Add" name="btnAddEmails"> <INPUT class="slectedbutton" id="btnClose" onclick="closeWindow()" type="button" value="Close"
								name="btnClose"></P>
						<P><asp:label id="Label1" runat="server" Width="304px" CssClass="formslabels" Visible="False">This item does not exist, please try again</asp:label></P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
