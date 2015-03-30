<%@ Page language="c#" Inherits="TSN.ERP.WebGUI.Timing.SpecialTiming" CodeFile="SpecialTiming.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SpecialTiming</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="http://localhost/AccGui/Acc1.css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" align="center" cellSpacing="0" cellPadding="0" width="1063" border="0">
				<TR>
					<TD align="center">
						<table cellSpacing="5" cellPadding="5" width="200" border="0">
							<tr>
								<td class="headertd">Special Timing</td>
							</tr>
							<tr>
								<td class="whitetd">
									<table id="Table4" style="WIDTH: 352px; HEIGHT: 216px" cellSpacing="5" cellPadding="5"
										width="352" border="0">
										<tr>
											<td>
												<p><asp:datagrid id=dgSpecialTime runat="server" AutoGenerateColumns="False" Width="412px" DataSource="<%# dsTiming_SpecialTime1 %>" DataMember="Timing_SpecialTime" BorderColor="White" CellPadding="2" BorderStyle="None" ShowFooter="True">
														<SelectedItemStyle CssClass="offday"></SelectedItemStyle>
														<AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
														<ItemStyle CssClass="bsnormaltd"></ItemStyle>
														<HeaderStyle CssClass="headertd"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn HeaderText="Serial">
																<ItemTemplate>
																	<asp:Label id=Label2 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Serial") %>'>
																	</asp:Label>
																</ItemTemplate>
																<EditItemTemplate>
																	<asp:TextBox id=TextBox1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Serial") %>'>
																	</asp:TextBox>
																</EditItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Start Date">
																<ItemTemplate>
																	<asp:Label id=Label3 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.StartDate", "{0:d}") %>'>
																	</asp:Label>
																</ItemTemplate>
																<FooterTemplate>
																	<asp:TextBox id=txtStartDateFooter runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.StartDate", "{0:d}") %>'>
																	</asp:TextBox>
																</FooterTemplate>
																<EditItemTemplate>
																	<asp:TextBox id=txtStartDateEdit runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.StartDate", "{0:d}") %>'>
																	</asp:TextBox>
																</EditItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="End Date">
																<ItemTemplate>
																	<asp:Label id=Label4 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EndDate", "{0:d}") %>'>
																	</asp:Label>
																</ItemTemplate>
																<FooterTemplate>
																	<asp:TextBox id=txtEndDateFooter runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EndDate", "{0:d}") %>'>
																	</asp:TextBox>
																</FooterTemplate>
																<EditItemTemplate>
																	<asp:TextBox id=txtEndDateEdit runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EndDate", "{0:d}") %>'>
																	</asp:TextBox>
																</EditItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Hour Equal To">
																<ItemTemplate>
																	<asp:Label id=Label1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.HourEqual") %>'>
																	</asp:Label>
																</ItemTemplate>
																<FooterTemplate>
																	<asp:TextBox id=txtHourFooter runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.HourEqual") %>'>
																	</asp:TextBox>
																</FooterTemplate>
																<EditItemTemplate>
																	<asp:TextBox id=txtHourEdit runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.HourEqual") %>'>
																	</asp:TextBox>
																</EditItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Edit">
																<ItemTemplate>
																	<asp:LinkButton id="LinkButton1" runat="server" Text="Edit" CausesValidation="false" CommandName="Edit"></asp:LinkButton>
																</ItemTemplate>
																<FooterTemplate>
																	<asp:LinkButton id="btnAdd" runat="server" Text="Update" CommandName="Add">Add</asp:LinkButton>
																</FooterTemplate>
																<EditItemTemplate>
																	<asp:LinkButton id="LinkButton3" runat="server" Text="Update" CommandName="Update"></asp:LinkButton>&nbsp;
																	<asp:LinkButton id="LinkButton2" runat="server" Text="Cancel" CausesValidation="false" CommandName="Cancel"></asp:LinkButton>
																</EditItemTemplate>
															</asp:TemplateColumn>
															<asp:ButtonColumn Text="Delete" HeaderText="Delete" CommandName="Delete"></asp:ButtonColumn>
														</Columns>
														<PagerStyle CssClass="bsFootertd"></PagerStyle>
													</asp:datagrid></p>
											</td>
										</tr>
										<tr>
											<td align="center">
												<asp:Label id="lblNote" runat="server" Width="574px" ForeColor="Red"></asp:Label>&nbsp;</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						&nbsp;</TD>
					<TD vAlign="top" align="left">&nbsp;
						<P>&nbsp;</P>
					</TD>
				</TR>
			</TABLE>
		</form>
		<script language="javascript" src="../go/include/dlcalendar.js" type="text/javascript"></script>
		<span class="style7">
			<script language="javascript" src="../go/include/buttons.js" type="text/javascript"></script>
		</span>
	</body>
</HTML>
