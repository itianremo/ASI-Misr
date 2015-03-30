<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls, Version=1.0.2.226, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.SecurityManagement.ModuleRulesGroup1" CodeFile="Copy of ModuleRulesGroup.ascx.cs" %>
<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation" %>
<LINK href="../Acc1.css" type="text/css" rel="stylesheet">
<P align="center">
</P>
<P align="left">
	<TABLE id="Table2" style="WIDTH: 724px; HEIGHT: 286px" cellSpacing="0" cellPadding="0"
		width="724" border="0" align="center">
		<TR>
			<TD style="WIDTH: 334px; HEIGHT: 16px"><STRONG><FONT size="2">Module Rules Entities</FONT></STRONG></TD>
			<TD style="HEIGHT: 16px"><STRONG><FONT size="2">New Rule Group </FONT></STRONG>
			</TD>
		</TR>
		<TR>
			<TD style="WIDTH: 334px"></TD>
			<TD></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 334px">
				<P>
					<TABLE id="Table3" style="WIDTH: 300px; HEIGHT: 103px" cellSpacing="0" cellPadding="0"
						width="300" border="0">
						<TR>
							<TD>
								<P>
									<iewc:treeview id="TreeView11" Width="335px" runat="server"></iewc:treeview></P>
							</TD>
						</TR>
						<TR>
							<TD>
								<P>
									<cc1:SecButtons id="Button1" runat="server" CssClass="slectedbutton" Text="select" onclick="Button1_Click"></cc1:SecButtons></P>
							</TD>
						</TR>
					</TABLE>
				</P>
				<P>&nbsp;</P>
			</TD>
			<TD>
				<P>&nbsp;</P>
				<TABLE id="Table1" style="WIDTH: 384px; HEIGHT: 274px" cellSpacing="1" cellPadding="1"
					width="384" border="0">
					<TR>
						<TD style="WIDTH: 68px; HEIGHT: 16px">
							<asp:label id="Label1" runat="server">Rule Group Name</asp:label></TD>
						<TD style="HEIGHT: 16px">
							<P>
								<asp:DropDownList id="dlpRuleGroups" runat="server" DataSource="<%# dataSetRuleGroup1 %>" DataMember="SEC_RuleGroup" DataValueField="RuleGroupID" DataTextField="RuleGroupName" AutoPostBack="True" Width="216px" onselectedindexchanged="dlpRuleGroups_SelectedIndexChanged">
								</asp:DropDownList>
								<cc1:SecButtons id="btnNew" runat="server" Text="New" CssClass="slectedbutton" onclick="btnNew_Click"></cc1:SecButtons>
								<asp:TextBox id="TextBoxGroupName" runat="server" Width="216px"></asp:TextBox></P>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 68px; HEIGHT: 21px"><FONT size="2"></FONT></TD>
						<TD style="HEIGHT: 21px">Rule List</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 68px; HEIGHT: 171px"></TD>
						<TD style="HEIGHT: 171px">
							<P><asp:listbox id="ListBoxEntities" runat="server" SelectionMode="Multiple" CssClass="textarea"
									Width="304px" Height="190px"></asp:listbox></P>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 68px"></TD>
						<TD>
							<P><cc1:SecButtons id="Button3" runat="server" Text="Remove" CssClass="slectedbutton" onclick="ButtonOut_Click"></cc1:SecButtons></P>
						</TD>
					</TR>
				</TABLE>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<cc1:SecButtons id="AddButton" runat="server" Text="Save" CssClass="slectedbutton" Width="98px" onclick="AddButton_Click"></cc1:SecButtons>
			</TD>
		</TR>
	</TABLE>
</P>
