<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmailTemplate.aspx.cs" ValidateRequest="false"
	EnableEventValidation="false" Inherits="EmailTemplate" Theme="Red" MasterPageFile="~/MasterLayout.master"
	Title="Email Template" %>

<%@ MasterType VirtualPath="~/MasterLayout.master" %>
<asp:Content ID="Head" runat="server" ContentPlaceHolderID="head">
	<script language="javascript" src="Scripts/Scripts.js"></script>
</asp:Content>
<asp:Content ID="Main" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
	<div class="header">
	</div>
	<div class="ui-layout-content">
		<table bordercolor="#FFFFFF" border="1" style="width: 60%">
			<thead style="text-align: center;">
				<tr>
					<td colspan="4" class="MainfontStyle">
						&nbsp;
					</td>
				</tr>
			</thead>
			<tbody style="text-align: center; width: 100%;">
				<tr style="width: 100%;">
					<td style="text-align: center;" colspan="4">
						<asp:GridView ID="dgTemplates" runat="server" AutoGenerateColumns="False" DataKeyNames="TemplateID"
							BorderColor="Maroon" BorderStyle="Solid" OnRowDataBound="GridView1_RowDataBound"
							OnRowCreated="dgTemplates_RowCreated" OnSelectedIndexChanged="dgTemplates_SelectedIndexChanged"
							BackColor="Transparent" Width="100%" AllowPaging="True" AllowSorting="False" OnPageIndexChanged="dgTemplates_PageIndexChanged"
							EnableModelValidation="True">
							<Columns>
								<asp:BoundField DataField="TemplateID" HeaderText="TemplateID" ReadOnly="True" SortExpression="TemplateID">
									<ControlStyle BorderColor="Black" />
									<HeaderStyle BackColor="DarkGray" BorderColor="Black" BorderWidth="1px" Wrap="False" />
									<ItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" HorizontalAlign="Left"
										VerticalAlign="Middle" Wrap="False" />
								</asp:BoundField>
								<asp:BoundField DataField="TemplateName" HeaderText="Template Name" SortExpression="TemplateName">
									<ControlStyle BorderColor="Black" />
									<HeaderStyle BackColor="DarkGray" BorderColor="Black" BorderWidth="1px" Wrap="False"
										Width="80%" />
									<ItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" HorizontalAlign="Left"
										VerticalAlign="Middle" Wrap="False" />
								</asp:BoundField>
								<%-- <asp:BoundField DataField="TemplateContent" HeaderText="Content" SortExpression="TemplateContent">
                                            <ControlStyle BorderColor="Black" />
                                            <HeaderStyle BackColor="DarkGray" BorderColor="Black" BorderWidth="1px" Wrap="False" />
                                            <ItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" HorizontalAlign="Left"
                                                VerticalAlign="Middle" Wrap="False" />
                                        </asp:BoundField>--%>
								<asp:TemplateField HeaderText="Edit">
									<ItemTemplate>
										<asp:ImageButton ID="ibtn" runat="server" ImageUrl="~/Images/Edit1.jpg" OnClick="ImgEditTemplate_Click"
											CausesValidation="False" />
									</ItemTemplate>
									<ControlStyle BorderColor="Black" />
									<HeaderStyle BackColor="DarkGray" BorderColor="Black" BorderWidth="1px" Wrap="False"
										Width="10%" />
									<ItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" HorizontalAlign="Center"
										VerticalAlign="Middle" Wrap="False" Width="10%" />
								</asp:TemplateField>
								<asp:TemplateField HeaderText="Delete">
									<ItemTemplate>
										<asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="~/Images/Delete1.jpg" OnClick="ImgDelete_Click"
											CausesValidation="False" />
									</ItemTemplate>
									<ControlStyle BorderColor="Black" />
									<HeaderStyle BackColor="DarkGray" BorderColor="Black" BorderWidth="1px" Wrap="False"
										Width="10%" />
									<ItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" HorizontalAlign="Center"
										VerticalAlign="Middle" Wrap="False" Width="10%" />
								</asp:TemplateField>
							</Columns>
							<SelectedRowStyle CssClass="SelectedRowColor" />
							<HeaderStyle CssClass="GridHeaderBackStyle" Font-Bold="True" Font-Names="Tahoma"
								Font-Size="12px" ForeColor="White" />
							<PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous"
								Mode="NumericFirstLast" />
							<RowStyle CssClass="GridNormalRowsStyle" />
							<PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Center" />
						</asp:GridView>
					</td>
				</tr>
				<tr>
					<td colspan="4">
						<table border="0" style="background-color: White; width: 100%" align="left">
							<tr>
								<td style="height: 20px;" align="right" colspan="2">
									<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
										SelectMethod="SelectAllEmailTemplate" TypeName="Office.BLL.EmailTemplateBLL">
										<SelectParameters>
											<asp:SessionParameter Name="CurrentTemplate" SessionField="CurrentTemplate" Type="Object" />
										</SelectParameters>
									</asp:ObjectDataSource>
								</td>
							</tr>
							<tr>
								<td style="text-align: left;" colspan="2">
									<table>
										<tr>
											<td style="height: 20px;" valign="top">
												<asp:ImageButton ID="imgSaveTemplate" runat="server" ImageUrl="~/Images/save1.jpg"
													OnClick="imgSaveTemplate_Click" ValidationGroup="vgSave" />
											</td>
											<td style="height: 20px;" valign="top">
												<asp:ImageButton ID="imgNewTemplate" runat="server" ImageUrl="~/Images/New-n.jpg"
													OnClick="imgNewTemplate_Click" CausesValidation="False" />
											</td>
											<td style="height: 20px;" valign="top">
												<asp:ImageButton ID="imgCancel" runat="server" ImageUrl="~/Images/Cancel1.jpg" OnClick="imgCancel_Click"
													CausesValidation="False" />
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td style="height: 20px; width: 50px;" align="right">
									<asp:Label ID="lblTemplateName" runat="server" Text="Default" Width="50px" CssClass="MainfontStyle"></asp:Label>
								</td>
								<td style="height: 20px; text-align: left;">
									<asp:CheckBox ID="cbDefault" runat="server" />
								</td>
							</tr>
							<tr>
								<td style="height: 20px; width: 50px;" align="right">
									<asp:Label ID="Label2" runat="server" Text="Title" Width="50px" CssClass="MainfontStyle"></asp:Label>
								</td>
								<td style="height: 20px; text-align: left;">
									<asp:TextBox ID="txtTemplateName" runat="server" Width="400px" CssClass="txtinputs"></asp:TextBox>
									<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTemplateName"
										ErrorMessage="Title not valid" ValidationGroup="vgSave"></asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td style="height: 20px; width: 50px;" align="right">
									<asp:Label ID="Label3" runat="server" Text="Subject" Width="50px" CssClass="MainfontStyle"></asp:Label>
								</td>
								<td style="height: 20px; text-align: left;">
									<asp:TextBox ID="txtSubject" runat="server" Width="400px" CssClass="txtinputs"></asp:TextBox>
									<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSubject"
										ErrorMessage="Subject not valid" ValidationGroup="vgSave"></asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td style="height: 20px; width: 50px;" valign="top" align="right">
									<asp:Label ID="Label5" runat="server" Text="Content" Width="50px" CssClass="MainfontStyle"></asp:Label>
								</td>
								<td style="height: 20px; text-align: left; vertical-align: top">
									<ftb:freetextbox id="FreeTextBox1" runat="server" height="280px" width="550px" toolbarlayout="FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline|JustifyLeft,JustifyCenter,JustifyRight|BulletedList,NumberedList,Print"
										enablehtmlmode="False" focus="True" buttonimageslocation="ExternalFile" javascriptlocation="ExternalFile"
										toolbarimageslocation="ExternalFile" supportfolder="aspnet_client/FreeTextBox/"
										buttonwidth="19" breakmode="LineBreak">
                                                                    </ftb:freetextbox>
									<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="FreeTextBox1"
										ErrorMessage="Content not valid" ValidationGroup="vgSave"></asp:RequiredFieldValidator>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colspan="4">
						<asp:Label ID="lblNote" runat="server" ForeColor="Red" Visible="False"></asp:Label>
					</td>
				</tr>
			</tbody>
		</table>
	</div>
	<div class="footer">
	</div>
</asp:Content>
