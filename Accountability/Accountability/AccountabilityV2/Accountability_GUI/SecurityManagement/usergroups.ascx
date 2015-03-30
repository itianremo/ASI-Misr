<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation" %>
<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.Security_Management.UserGroups" CodeFile="UserGroups.ascx.cs" %>
<LINK href="../Acc1.css" type="text/css" rel="stylesheet">
<P align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</P>
<P align="left">
	<TABLE id="Table2" style="WIDTH: 566px; HEIGHT: 133px" cellSpacing="0" cellPadding="0"
		width="566" border="0" align="center">
		<TR>
			<TD style="WIDTH: 239px; HEIGHT: 21px"><FONT size="2">All user Groups</FONT>&nbsp;&nbsp;
				<asp:DropDownList id=DropDownListUsrGroups CssClass="textlist" AutoPostBack="True" DataValueField="UserGroupID" DataTextField="UserGroupName" DataSource="<%# dataSetGroups1 %>" runat="server" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
				</asp:DropDownList></TD>
			<TD style="WIDTH: 25px; HEIGHT: 21px" colSpan="2">
				<asp:LinkButton id="LinkButton1" runat="server" Width="190px" onclick="LinkButton1_Click">Add new user group</asp:LinkButton></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 239px; HEIGHT: 21px"></TD>
			<TD style="WIDTH: 25px; HEIGHT: 21px" colSpan="2"></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 239px; HEIGHT: 21px"><FONT size="2">User Group Name</FONT></TD>
			<TD style="WIDTH: 25px; HEIGHT: 21px" colSpan="2">
				<asp:TextBox id="TextBoxGroupName" runat="server" CssClass="inputtext"></asp:TextBox></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 239px; HEIGHT: 18px"></TD>
			<TD style="WIDTH: 30px; HEIGHT: 18px"></TD>
			<TD style="HEIGHT: 18px"></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 239px"><FONT size="2">Users</FONT></TD>
			<TD style="WIDTH: 30px">
				<P>&nbsp;</P>
			</TD>
			<TD><FONT size="2">New Group Users</FONT></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 239px; HEIGHT: 70px">
				<asp:ListBox id="ListBoxUsers" runat="server" SelectionMode="Multiple" Width="231px" CssClass="textarea"></asp:ListBox></TD>
			<TD style="WIDTH: 30px; HEIGHT: 70px">
				<P>
					<asp:Button id="ButtonIn" runat="server" Text=">" CssClass="slectedbutton" Width="25px" onclick="ButtonIn_Click"></asp:Button></P>
				<P>
					<asp:Button id="ButtonOut" runat="server" Text="<" CssClass="slectedbutton" Width="25px" onclick="ButtonOut_Click"></asp:Button></P>
			</TD>
			<TD style="HEIGHT: 70px">
				<asp:ListBox id="ListBoxUserGroups" runat="server" SelectionMode="Multiple" Width="242px" CssClass="textarea"></asp:ListBox></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 239px; HEIGHT: 7px">
				<cc1:SecButtons id="AddButton" runat="server" Text="Add " Width="59px" Visible="False" CssClass="slectedbutton" onclick="AddButton_Click"></cc1:SecButtons>
				<cc1:SecButtons id="ButtonUpdate" runat="server" Text="Update" CssClass="slectedbutton" onclick="ButtonUpdate_Click"></cc1:SecButtons></TD>
			<TD style="WIDTH: 30px; HEIGHT: 7px"></TD>
			<TD style="HEIGHT: 7px"></TD>
		</TR>
	</TABLE>
</P>
<P align="left">&nbsp;</P>
