<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation" %>
<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.Security_Management.RulesGroups" CodeFile="RulesGroups.ascx.cs" %>
<LINK href="../Acc1.css" type="text/css" rel="stylesheet">
<P align="left"><STRONG></STRONG>&nbsp;</P>
<P align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</P>
<P align="left">
	<TABLE id="Table1" style="WIDTH: 580px; HEIGHT: 124px" cellSpacing="1" cellPadding="1"
		width="580" border="0">
		<TR>
			<TD colSpan="3"><STRONG>Add Rule Group</STRONG></TD>
		</TR>
		<TR>
			<TD><asp:label id="Label1" runat="server">Rule Group Name</asp:label>
				<asp:textbox id="TextBoxGroupName" runat="server" CssClass="inputtext"></asp:textbox></TD>
			<TD style="WIDTH: 21px; HEIGHT: 21px"></TD>
			<TD></TD>
		</TR>
		<TR>
			<TD></TD>
			<TD style="WIDTH: 21px; HEIGHT: 21px"></TD>
			<TD></TD>
		</TR>
		<TR>
			<TD>Rules Entities</TD>
			<TD style="WIDTH: 21px; HEIGHT: 21px"></TD>
			<TD>Rule Group Entites&nbsp;</TD>
		</TR>
		<TR>
			<TD style="WIDTH: 268px"><asp:listbox id="ListBoxRulesEntities" runat="server" SelectionMode="Multiple" Width="242px"
					CssClass="textarea"></asp:listbox></TD>
			<TD style="WIDTH: 21px">
				<P><asp:button id="ButtonIn" runat="server" Text=">" Width="23px" CssClass="slectedbutton" onclick="ButtonIn_Click"></asp:button></P>
				<P><asp:button id="ButtonOut" runat="server" Text="<" Width="22px" CssClass="slectedbutton" onclick="ButtonOut_Click"></asp:button></P>
			</TD>
			<TD><asp:listbox id="ListBoxRuleGroups" runat="server" SelectionMode="Multiple" Width="252px" CssClass="textarea"></asp:listbox></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 268px"><cc1:SecButtons id="ButtonAdd" runat="server" Text="Add" CssClass="slectedbutton" onclick="AddButton_Click"></cc1:SecButtons>
				<cc1:SecButtons id="ButtonUpdate" runat="server" Text="Update" Visible="False" CssClass="slectedbutton" onclick="ButtonUpdate_Click"></cc1:SecButtons></TD>
			<TD style="WIDTH: 21px"></TD>
			<TD></TD>
		</TR>
	</TABLE>
</P>
<P align="left">&nbsp;</P>
