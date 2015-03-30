<%@ Register TagPrefix="uc1" TagName="ModuleUserGroups" Src="ModuleUserGroups.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserGroups" Src="UserGroups.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ModuleRulesGroup" Src="ModuleRulesGroup.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ModuleRulesTree" Src="ModuleRulesTree.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RulesGroups" Src="RulesGroups.ascx" %>
<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.SecurityManagement.ManageSecControls" CodeFile="ManageSecControls.ascx.cs" %>
<%@ Register TagPrefix="uc1" TagName="Users" Src="Users.ascx" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls, Version=1.0.2.226, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<LINK href="../Acc1.css" type="text/css" rel="stylesheet">
<p>&nbsp;</p>
<TABLE class="labelarea" id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center"
	border="0" DESIGNTIMEDRAGDROP="44">
	<TR>
		<TD align="center">Accounts</TD>
	</TR>
</TABLE>
<TABLE id="Table1" style="WIDTH: 786px; HEIGHT: 93px" cellSpacing="0" cellPadding="0" width="786"
	border="0" align="center">
	<TR>
		<TD style="HEIGHT: 58px">
			<P>&nbsp;</P>
			<P>
			</P>
			<P>
				<iewc:TabStrip id="TabStrip2" TabSelectedStyle="background-color:#cccccc;color:#000000;" TabHoverStyle="background-color:#777777"
					TabDefaultStyle="background-color:#999999;font-family:verdana;font-weight:bold;font-size:8pt;color:#ffffff;width:79;height:21;text-align:center;"
					Width="784px" runat="server" AutoPostBack="True" Height="31px" onselectedindexchange="TabStrip2_SelectedIndexChange">
					<iewc:Tab Text="Users"></iewc:Tab>
					<iewc:Tab Text="Users Groups"></iewc:Tab>
					<iewc:Tab Text="Advanced"></iewc:Tab>
				</iewc:TabStrip></P>
		</TD>
	</TR>
	<TR>
		<TD bgColor="#cccccc" style="HEIGHT: 158px" align="center">
			<asp:Panel id="Panel1" runat="server" Width="785px">&nbsp; 
<uc1:Users id="Users1" runat="server"></uc1:Users></asp:Panel>
			<asp:Panel id="Panel2" runat="server" Visible="False">&nbsp; 
<uc1:UserGroups id="UserGroups2" runat="server"></uc1:UserGroups>
			</asp:Panel>
			<asp:Panel id="Panel5" runat="server" Visible="False" Height="32px">
				<asp:RadioButtonList id="RadioButtonList1" AutoPostBack="True" runat="server" Width="527px" RepeatDirection="Horizontal"
					Font-Size="X-Small" onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
					<asp:ListItem Value="1">Manage module user groups X rule groups</asp:ListItem>
					<asp:ListItem Value="2">Manage module rule groups</asp:ListItem>
				</asp:RadioButtonList>
			</asp:Panel>
			<asp:Panel id="Panel4" runat="server" Visible="False">&nbsp;&nbsp; 
<uc1:ModuleRulesGroup id="ModuleRulesGroup1" runat="server"></uc1:ModuleRulesGroup>
			</asp:Panel>
			<asp:Panel id="Panel3" runat="server" Visible="False">&nbsp;&nbsp; 
<uc1:ModuleUserGroups id="ModuleUserGroups1" runat="server"></uc1:ModuleUserGroups>
			</asp:Panel></TD>
	</TR>
</TABLE>
