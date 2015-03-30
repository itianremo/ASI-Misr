<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls, Version=1.0.2.226, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.SecurityManagement.ModuleRulesGroup" CodeFile="ModuleRulesGroup.ascx.cs" %>
<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation" %>
<LINK href="../Acc1.css" type="text/css" rel="stylesheet">
<P align="center"></P>
<P align="left">
	<TABLE id="Table2" style="WIDTH: 712px; HEIGHT: 604px" cellSpacing="4" cellPadding="0"
		width="712" align="center" border="0">
		<TR>
			<TD class="headertd" style="WIDTH: 283px; HEIGHT: 18px"><STRONG><FONT size="2">Module Roles 
						Entities</FONT></STRONG></TD>
			<TD class="headertd" style="HEIGHT: 18px"><STRONG><FONT size="2">&nbsp;Role Group </FONT>
				</STRONG>
			</TD>
		</TR>
		<TR>
			<TD style="WIDTH: 283px"></TD>
			<TD></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 283px" vAlign="top">
				<P>
					<TABLE id="Table3" style="WIDTH: 253px; HEIGHT: 612px" cellSpacing="0" cellPadding="0"
						width="253" border="0">
						<TR>
							<TD class="formslabels" style="HEIGHT: 78px" vAlign="top">
								<P>Entities
									<asp:dropdownlist id=DropDownListEntities runat="server" CssClass="inputtext" AutoPostBack="True" DataTextField="EntityName" DataValueField="EntityID" DataMember="SEC_Entities" DataSource="<%# dataSetEntities1 %>" onselectedindexchanged="DropDownListEntities_SelectedIndexChanged">
									</asp:dropdownlist></P>
								<P>Entities Items
									<asp:dropdownlist id="DropDownListEntitiesItems" runat="server" CssClass="inputtext" AutoPostBack="True" onselectedindexchanged="DropDownListEntitiesItems_SelectedIndexChanged"></asp:dropdownlist></P>
								<P><asp:datagrid id=DataGridRlEnt runat="server" DataMember="SEC_RuleEntity" DataSource="<%# dataSetRuleEntity1 %>" AutoGenerateColumns="False" PageSize="20" >
										<AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
										<ItemStyle CssClass="bsnormaltd"></ItemStyle>
										<HeaderStyle CssClass="headertd"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn>
												<ItemTemplate>
													<asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="RuleEntityID" SortExpression="RuleEntityID" HeaderText="RoleEntityID"></asp:BoundColumn>
											<asp:BoundColumn DataField="RuleEntityDescription" SortExpression="RuleEntityDescription" HeaderText="Rule Entity"></asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></P>
								<P><asp:button id="ButtonSelect" runat="server" Text="select" CssClass="slectedbutton" onclick="ButtonSelect_Click"></asp:button></P>
							</TD>
						</TR>
					</TABLE>
				</P>
				<P>&nbsp;</P>
			</TD>
			<TD vAlign="top">
				<TABLE id="Table1" style="WIDTH: 445px; HEIGHT: 288px" cellSpacing="1" cellPadding="1"
					width="445" border="0">
					<TR>
						<TD class="formslabels" style="WIDTH: 147px; HEIGHT: 16px">Role Group Name</TD>
						<TD style="HEIGHT: 16px">
							<P><asp:dropdownlist id=dlpRuleGroups runat="server" Width="216px" CssClass="inputtext" AutoPostBack="True" DataTextField="RuleGroupName" DataValueField="RuleGroupID" DataMember="SEC_RuleGroup" DataSource="<%# dataSetRuleGroup1 %>" onselectedindexchanged="dlpRuleGroups_SelectedIndexChanged">
								</asp:dropdownlist><cc1:secbuttons id="btnNew" runat="server" Text="New" CssClass="slectedbutton" onclick="btnNew_Click"></cc1:secbuttons><asp:textbox id="TextBoxGroupName" runat="server" Width="216px"></asp:textbox></P>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 147px; HEIGHT: 21px"><FONT size="2"></FONT></TD>
						<TD class="formslabels" style="HEIGHT: 21px">Role List</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 147px; HEIGHT: 171px"></TD>
						<TD style="HEIGHT: 171px">
							<P><asp:listbox id="ListBoxEntities" runat="server" Width="304px" CssClass="textarea" Height="190px"
									SelectionMode="Multiple"></asp:listbox></P>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 147px"></TD>
						<TD>
							<P><cc1:secbuttons id="Button3" runat="server" Width="98px" Text="Remove" CssClass="slectedbutton" onclick="ButtonOut_Click"></cc1:secbuttons></P>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 147px"></TD>
						<TD><cc1:secbuttons id="AddButton" runat="server" Width="98px" Text="Save" CssClass="slectedbutton" onclick="AddButton_Click"></cc1:secbuttons>&nbsp;
							<cc1:secbuttons id="btnCancel" CssClass="slectedbutton" runat="server" Text="Cancel" Width="98px" onclick="btnCancel_Click"></cc1:secbuttons></TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
	</TABLE>
</P>
