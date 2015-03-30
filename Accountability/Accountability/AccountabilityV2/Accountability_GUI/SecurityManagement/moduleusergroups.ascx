<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls, Version=1.0.2.226, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.SecurityManagement.ModuleUserGroups" CodeFile="ModuleUserGroups.ascx.cs" %>
<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation" %>
<LINK href="../Acc1.css" type="text/css" rel="stylesheet">
<P>&nbsp;</P>
<TABLE cellSpacing="1" cellPadding="1" width="880" border="0" id="Table1" style="WIDTH: 880px; HEIGHT: 93px"
	align="center">
	<TR>
		<TD style="WIDTH: 162px" colSpan="2"><STRONG><FONT size="2">&nbsp; Module Users Groups</FONT></STRONG></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 162px"></TD>
		<TD></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 162px"><STRONG><FONT size="2">&nbsp; View By</FONT></STRONG></TD>
		<TD>
			<asp:RadioButtonList id="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Width="297px"
				AutoPostBack="True" onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
				<asp:ListItem Value="0" Selected="True">User Groups</asp:ListItem>
				<asp:ListItem Value="1">Rule Groups</asp:ListItem>
			</asp:RadioButtonList></TD>
	</TR>
</TABLE>
<asp:Panel id="Panel1" runat="server">
	<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</P>
	<P>
		<TABLE id="Table2" style="WIDTH: 879px; HEIGHT: 101px" cellSpacing="1" cellPadding="1"
			width="879" align="center" border="0">
			<TR>
				<TD style="HEIGHT: 22px"><STRONG><FONT size="2">&nbsp; All Users Groups In Module</FONT></STRONG></TD>
				<TD style="HEIGHT: 22px"><STRONG><FONT size="2">All Rules Groups In Module</FONT></STRONG></TD>
			</TR>
			<TR>
				<TD>&nbsp;
					<iewc:TreeView id="TreeViewUserGroup1" runat="server"></iewc:TreeView></TD>
				<TD>
					<iewc:TreeView id="TreeViewRuleGroup1" runat="server" SelectedStyle="soso:1;"></iewc:TreeView></TD>
			</TR>
			<TR>
				<TD>&nbsp;
					<cc1:SecButtons id="ButtonRemoveRuleGrFromUsrGr" Width="156px" runat="server" CssClass="slectedbutton"
						Text="Remove Rule Group" onclick="ButtonRemoveRuleGrFromUsrGr_Click"></cc1:SecButtons></TD>
				<TD>
					<cc1:SecButtons id="ButtonAddRuleGrToUsrGr" Width="228px" runat="server" CssClass="slectedbutton"
						Text="Add Rule Group To User Group" onclick="ButtonAddRuleGrToUsrGr_Click"></cc1:SecButtons></TD>
			</TR>
		</TABLE>
	</P>
</asp:Panel>
<P>&nbsp;</P>
<asp:Panel id="Panel2" runat="server" Visible="False" Width="853px">
	<TABLE id="Table3" style="WIDTH: 891px; HEIGHT: 101px" cellSpacing="1" cellPadding="1"
		width="891" align="center" border="0">
		<TR>
			<TD style="HEIGHT: 21px"><STRONG><FONT size="2">&nbsp; All Rules Groups In Module</FONT></STRONG></TD>
			<TD style="HEIGHT: 21px"><STRONG><FONT size="2">All Users Groups</FONT></STRONG></TD>
		</TR>
		<TR>
			<TD>&nbsp;
				<iewc:TreeView id="TreeViewRuleGroup2" runat="server"></iewc:TreeView></TD>
			<TD>
				<iewc:TreeView id="TreeViewUserGroup2" runat="server"></iewc:TreeView></TD>
		</TR>
		<TR>
			<TD>&nbsp;
				<cc1:SecButtons id="ButtonRemoveUserGrFromRuleGr" Width="166px" runat="server" CssClass="slectedbutton"
					Text="Remove User Group" onclick="ButtonRemoveUserGrFromRuleGr_Click"></cc1:SecButtons></TD>
			<TD>
				<cc1:SecButtons id="ButtonAddUserGrToRuleGr" Width="222px" runat="server" CssClass="slectedbutton"
					Text="Add User Group To Rule Group" onclick="ButtonAddUserGrToRuleGr_Click"></cc1:SecButtons></TD>
		</TR>
	</TABLE>
</asp:Panel>
