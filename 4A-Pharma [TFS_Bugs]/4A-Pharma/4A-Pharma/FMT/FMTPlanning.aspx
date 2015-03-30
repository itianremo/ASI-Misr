<%@ Page Language="C#" MasterPageFile="~/FMT/FMTMasterPage.master" EnableEventValidation="false"
	Culture="ar-EG" AutoEventWireup="true" CodeFile="FMTPlanning.aspx.cs" Inherits="FMTPlanning"
	Title=":: 4A-Pharma FMT :: M.R. Weekly Plan ::" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../Controls/TransButtons.ascx" TagName="TransButtons" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

	<script language="javascript">
	var scrollTop;
	Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
	Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

	function BeginRequestHandler(sender, args) 
	{
	   var elem = document.getElementById('ctl00_ContentPlaceHolder1_tabcontWeekVisits_body');
		   if(elem!= null)
		   scrollTop=elem.scrollTop;
	}

	function EndRequestHandler(sender, args)
	{

	    var updateProgress = $get('<%= UpdateProgress1.ClientID %>');
	    var dynamicLayout = '<%= UpdateProgress1.DynamicLayout.ToString().ToLower() %>';

	    if (dynamicLayout) {
	        updateProgress.style.display = "none";
	    }
	    else {
	        updateProgress.style.visibility = "hidden";
	    }

	   var elem = document.getElementById('ctl00_ContentPlaceHolder1_tabcontWeekVisits_body');
		   if(elem!= null)
		   elem.scrollTop = scrollTop;

		SetGvMMBackgroundColor();
		SetGvProductsBackgroundColor();

	}   
	
	function HandleTabChangedClick()
	 {
		document.getElementById('ctl00_ContentPlaceHolder1_btnctlTabChangedEvent').click();
	 }
	
	//----------------------------------------------------------------------------//
	function ConfirmDelete()
	{
	var inputs = document.getElementById('aspnetForm').getElementsByTagName('input');
	var isChecked = false 
	for( var i = 0; i < inputs.length; i++) 
	{ 
		if(inputs[i].type == 'checkbox' && inputs[i].checked) 
		{ 
			   if(! inputs[i].id.startsWith('ctl00_ContentPlaceHolder1_gvMM') && ! inputs[i].id.startsWith('ctl00_ContentPlaceHolder1_gvProducts'))
				  isChecked = true;
		} 
	} 
 
	if(isChecked) 
		{ 
		//at least one checkbox checked 
		return confirm('Are you sure you want to Delete the selected Visits?');
		} 
		else
		{
		alert("Select at least one record before click on delete...!");
		return false; 
		}
	//---------------------------------------------------------------------------//
	}
	
	function SelectOne(invoker) {
		var IsChecked = invoker.checked;   
		if(IsChecked)
		{
			//invoker.parentElement.parentElement.style.backgroundColor='#BCC9B7'; 
			var gvInputs = invoker.parentElement.parentElement.getElementsByTagName("input");
			
			for (i=0;i<gvInputs.length;i++)
			{
				if (gvInputs[i].type == "text") 
				{
					if (gvInputs[i].value == 0)
						gvInputs[i].value = 1
				}
			}
		}
		else
		{
			//invoker.parentElement.parentElement.style.backgroundColor='#ffffff'; 
			var gvInputs = invoker.parentElement.parentElement.getElementsByTagName("input");
			for (i=0;i<gvInputs.length;i++)
			{
				if (gvInputs[i].type == "text") 
				{
					gvInputs[i].value = 0
				}
			}
		}   
	}
	
	function AdjustOne(invoker) {
		var IsChecked = true;   
		if(invoker.value == '0' || invoker.value == '')
			IsChecked = false;   

		//invoker.parentElement.parentElement.style.backgroundColor='#BCC9B7'; 
		var gvInputs = invoker.parentElement.parentElement.getElementsByTagName("input");
		
		for (i=0;i<gvInputs.length;i++)
		{
			if (gvInputs[i].type == "checkbox") 
			{
				if(IsChecked)
				{
					gvInputs[i].checked = true
					invoker.parentElement.parentElement.style.background='#BCC9B7'
				}
				else
				{
					gvInputs[i].checked = false
					invoker.parentElement.parentElement.style.background='#ffffff'
				}
			}
		}
	}
	
	function PageStartupFunction() {
		SetGvMMBackgroundColor();
		SetGvProductsBackgroundColor();
	}
	
	function SetGvMMBackgroundColor() {
		var gv = document.getElementById("ctl00_ContentPlaceHolder1_gvMM");
		var gvInputs = gv.getElementsByTagName("input");
		
		for (i=0;i<gvInputs.length;i++){
			if (gvInputs[i].type == "checkbox"){
				//alert(gvInputs[i].parentElement.parentElement.tagName.startsWith('TR'))
				if(gvInputs[i].checked){
					if(gvInputs[i].parentElement.parentElement.tagName.startsWith('TR')){
						gvInputs[i].parentElement.parentElement.style.background='#BCC9B7'
					}
					else{
						gvInputs[i].parentElement.parentElement.parentElement.style.background='#BCC9B7'
					}
				}
				else{
					if(gvInputs[i].parentElement.parentElement.tagName.startsWith('TR')){
						gvInputs[i].parentElement.parentElement.style.background='#ffffff'
					}
					else{
						gvInputs[i].parentElement.parentElement.parentElement.style.background='#ffffff'
					}
				}
			}
		}
	}
	
	function SetGvProductsBackgroundColor() {
		var gv = document.getElementById("ctl00_ContentPlaceHolder1_gvProducts");
		var gvInputs = gv.getElementsByTagName("input");
		
		for (i=0;i<gvInputs.length;i++){
			if (gvInputs[i].type == "checkbox"){
				//alert(gvInputs[i].parentElement.parentElement.tagName.startsWith('TR'))
				if(gvInputs[i].checked){
					if(gvInputs[i].parentElement.parentElement.tagName.startsWith('TR')){
						gvInputs[i].parentElement.parentElement.style.background='#BCC9B7'
					}
					else{
						gvInputs[i].parentElement.parentElement.parentElement.style.background='#BCC9B7'
					}
				}
				else{
					if(gvInputs[i].parentElement.parentElement.tagName.startsWith('TR')){
						gvInputs[i].parentElement.parentElement.style.background='#ffffff'
					}
					else{
						gvInputs[i].parentElement.parentElement.parentElement.style.background='#ffffff'
					}
				}
			}
		}
	}
	</script>

	<table width="100%">
		<tbody>
			<tr>
				<td align="center" colspan="3">
					<table id="tblPlanManager" cellpadding="0" cellspacing="0" runat="server" class="tblStyle"
						width="100%">
						<tr>
							<td align="center" valign="top">
								<table width="100%" id="tblPlanFields" background="../Images/BG-1.jpg" class="tblStyle">
									<tr>
										<td align="left" background="../Images/TableHead-BG.jpg" colspan="6" height="15">
											<asp:Label ID="lblPlanEntry" runat="server" CssClass="MainfontStyle" Font-Size="18px"
												Text="Plan Organizer"></asp:Label></td>
									</tr>
									<tr>
										<td colspan="3" height="15">
										</td>
										<td width="1%">
										</td>
										<td colspan="2">
										</td>
									</tr>
									<tr>
										<td align="center" colspan="3" valign="top">
											<asp:UpdatePanel ID="UpdatePanel1" runat="server">
												<ContentTemplate>
													<table id="tblLeftCont" class="tblStyle" width="450" height="300">
														<tr>
															<td colspan="3" align="right" valign="top">
																<table id="tblInnerContL" width="100%">
																	<tr>
																		<td align="left" background="../Images/TableHead-BG.jpg" colspan="3" height="20">
																			<asp:Label ID="Label4" runat="server" CssClass="MainfontStyle" Text="Plan Items"></asp:Label></td>
																	</tr>
																	<tr>
																		<td height="10" width="40%">
																		</td>
																		<td>
																		</td>
																		<td width="20%">
																		</td>
																	</tr>
																	<tr>
																		<td align="right">
																			<asp:Label ID="Label6" runat="server" CssClass="MainfontStyle" Text="MR. List:"></asp:Label></td>
																		<td align="left">
																			<asp:DropDownList ID="ddlMRList" runat="server" CssClass="inputs" Width="200px" OnSelectedIndexChanged="ddlMRList_SelectedIndexChanged"
																				AutoPostBack="True">
																			</asp:DropDownList></td>
																		<td>
																		</td>
																	</tr>
																	<tr>
																		<td align="right">
																			<asp:Label ID="lblVDate" runat="server" CssClass="MainfontStyle" Text="Day of Visit:"></asp:Label></td>
																		<td align="left">
																			<asp:TextBox ID="txtPlanDate" runat="server" CssClass="inputs" Width="195px" OnTextChanged="txtPlanDate_TextChanged"
																				AutoPostBack="True"></asp:TextBox></td>
																		<td align="left">
																			<asp:ImageButton ID="imgPlanDate" runat="server" AlternateText="Pick a date" CssClass="HandOverCursor"
																				ImageUrl="~/Images/Calender.gif" Width="25px" CausesValidation="False" /></td>
																	</tr>
																	<tr>
																		<td align="right">
																			<asp:Label ID="lblSP" runat="server" CssClass="MainfontStyle" Text="Starting Point:"></asp:Label></td>
																		<td align="left">
																			<asp:TextBox ID="txtSP" runat="server" CssClass="inputs" Width="195px" ReadOnly="True"
																				MaxLength="100"></asp:TextBox></td>
																		<td>
																		</td>
																	</tr>
																	<tr>
																		<td align="right">
																			<asp:Label ID="lblST" runat="server" CssClass="MainfontStyle" Text="Starting Time:"></asp:Label></td>
																		<td align="left">
																			<asp:DropDownList ID="ddlHour" runat="server" Width="78px" Enabled="False" CssClass="inputs">
																				<asp:ListItem>1</asp:ListItem>
																				<asp:ListItem>2</asp:ListItem>
																				<asp:ListItem>3</asp:ListItem>
																				<asp:ListItem>4</asp:ListItem>
																				<asp:ListItem>5</asp:ListItem>
																				<asp:ListItem>6</asp:ListItem>
																				<asp:ListItem>7</asp:ListItem>
																				<asp:ListItem>8</asp:ListItem>
																				<asp:ListItem>9</asp:ListItem>
																				<asp:ListItem>10</asp:ListItem>
																				<asp:ListItem>11</asp:ListItem>
																				<asp:ListItem Selected="True" Value="12">12</asp:ListItem>
																			</asp:DropDownList><asp:DropDownList ID="ddlMinute" runat="server" Width="78px"
																				Enabled="False" CssClass="inputs">
																				<asp:ListItem Value="00" Selected="True">00</asp:ListItem>
																				<asp:ListItem>05</asp:ListItem>
																				<asp:ListItem>10</asp:ListItem>
																				<asp:ListItem>15</asp:ListItem>
																				<asp:ListItem>20</asp:ListItem>
																				<asp:ListItem>25</asp:ListItem>
																				<asp:ListItem>30</asp:ListItem>
																				<asp:ListItem>35</asp:ListItem>
																				<asp:ListItem>40</asp:ListItem>
																				<asp:ListItem>45</asp:ListItem>
																				<asp:ListItem>50</asp:ListItem>
																				<asp:ListItem>55</asp:ListItem>
																			</asp:DropDownList>
																			<asp:DropDownList ID="ddlDuration" runat="server" Width="40px" CssClass="inputs">
																				<asp:ListItem Value="Õ" Selected="True">Õ</asp:ListItem>
																				<asp:ListItem>ã</asp:ListItem>
																			</asp:DropDownList></td>
																		<td>
																		</td>
																	</tr>
																	<tr>
																		<td align="right">
																			<asp:Label ID="lblAdd" runat="server" CssClass="MainfontStyle" Text="Add:"></asp:Label></td>
																		<td align="left">
																			<asp:DropDownList ID="ddlAddItem" runat="server" AutoPostBack="True" CssClass="inputs"
																				Width="200px" OnSelectedIndexChanged="ddlAddItem_SelectedIndexChanged" Enabled="False">
																			</asp:DropDownList></td>
																		<td align="left">
																		</td>
																	</tr>
																	<tr>
																		<td align="right">
																			<asp:Label ID="lblEntityName" runat="server" CssClass="MainfontStyle" Text="Name:"
																				Visible="False"></asp:Label></td>
																		<td align="left">
																			<asp:DropDownList ID="ddlAddRel" runat="server" CssClass="inputs" Width="200px" Visible="False"
																				DataTextField="EntityName" DataValueField="EntityID" OnDataBound="ddlAddRel_DataBound"
																				AutoPostBack="True" OnSelectedIndexChanged="ddlAddRel_SelectedIndexChanged">
																			</asp:DropDownList></td>
																		<td align="left">
																			<asp:RequiredFieldValidator ID="rfvddlAddRel" runat="server" ControlToValidate="ddlAddRel"
																				Display="Dynamic" ErrorMessage="Module name is required" Enabled="False">*</asp:RequiredFieldValidator></td>
																	</tr>
																	<tr>
																		<td align="right">
																			<asp:Label ID="lblSubEntityName" runat="server" CssClass="MainfontStyle" Text="SubName:"
																				Visible="False"></asp:Label></td>
																		<td align="left"><%--OnDataBound="lbProducts_DataBound"--%>
																			<asp:ListBox ID="lbSubModule" runat="server" Width="200px" SelectionMode="Multiple"
																				 CssClass="inputs" Visible="False"></asp:ListBox></td>
																		<td align="left">
																			<asp:RequiredFieldValidator ID="rfvlbSubModule" runat="server" ControlToValidate="lbSubModule"
																				Display="Dynamic" ErrorMessage="Subname is required" Enabled="False">*</asp:RequiredFieldValidator></td>
																	</tr>
																	<tr>
																		<td align="right">
																			<asp:Label ID="lblMentionOther" runat="server" CssClass="MainfontStyle" Text="Mention Other:"
																				Visible="False"></asp:Label></td>
																		<td align="left">
																			<asp:TextBox ID="txtOthers" runat="server" CssClass="inputs" Width="195px" Visible="False"
																				MaxLength="200"></asp:TextBox></td>
																		<td align="left">
																			<asp:RequiredFieldValidator ID="rfvtxtOthers" runat="server" ControlToValidate="txtOthers"
																				Display="Dynamic" ErrorMessage="Mention other is required" Enabled="False">*</asp:RequiredFieldValidator></td>
																	</tr>
																	<tr>
																		<td align="right">
																			<asp:Label ID="Label7" runat="server" CssClass="MainfontStyle" Text="Shift Visit:"></asp:Label></td>
																		<td align="left">
																			<asp:RadioButtonList ID="rblVisitShift" runat="server" CssClass="MainfontStyle" RepeatDirection="Horizontal"
																				Enabled="False">
																				<asp:ListItem Value="0">AM</asp:ListItem>
																				<asp:ListItem Value="1" Selected="True">PM</asp:ListItem>
																			</asp:RadioButtonList></td>
																		<td>
																		</td>
																	</tr>
																	<tr>
																		<td align="right">
																			<asp:Label ID="lblDoubleVisit" runat="server" CssClass="MainfontStyle" Text="Double Visit:"></asp:Label></td>
																		<td align="left">
																			<asp:RadioButtonList ID="rblDoubleVisit" runat="server" CssClass="MainfontStyle"
																				RepeatDirection="Horizontal" Enabled="False">
																				<asp:ListItem Value="1">Yes</asp:ListItem>
																				<asp:ListItem Selected="True" Value="0">No</asp:ListItem>
																			</asp:RadioButtonList></td>
																		<td>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
													</table>
													<cc1:CalendarExtender ID="calextExpireDate" runat="server" PopupButtonID="imgPlanDate"
														TargetControlID="txtPlanDate" Format="dd/MM/yyyy" FirstDayOfWeek="Saturday">
													</cc1:CalendarExtender>
													<asp:ObjectDataSource ID="odsSubMainItem" runat="server"></asp:ObjectDataSource>
												</ContentTemplate>
											</asp:UpdatePanel>
											&nbsp;
										</td>
										<td>
										</td>
										<td align="left" valign="top" colspan="2">
											<asp:UpdatePanel ID="UpdatePanel4" runat="server">
												<ContentTemplate>
													<table id="tbtContR" class="tblStyle" width="370" height="300">
														<tr>
															<td colspan="3" align="left" valign="top">
																<table id="tblInnrR" width="100%">
																	<tr>
																		<td align="left" background="../Images/TableHead-BG.jpg" colspan="3" height="20"
																			valign="top">
																			<asp:Label ID="Label5" runat="server" CssClass="MainfontStyle" Text="Plan Scope"></asp:Label></td>
																	</tr>
																	<tr>
																		<td height="10">
																		</td>
																		<td>
																		</td>
																		<td>
																		</td>
																	</tr>
																	<tr>
																		<td align="right">
																			<asp:Label ID="lblvisit" runat="server" CssClass="MainfontStyle" Text="Visit Type:"></asp:Label></td>
																		<td>
																			<asp:DropDownList ID="ddlVType" runat="server" CssClass="inputs" Width="220px" DataSourceID="odsVisitType"
																				DataTextField="SubCode" DataValueField="SID" Enabled="False">
																			</asp:DropDownList></td>
																		<td>
																		</td>
																	</tr>
																	<tr>
																		<td height="5">
																		</td>
																		<td>
																		</td>
																		<td>
																		</td>
																	</tr>
																	<tr>
																		<td align="right" valign="middle">
																			<asp:Label ID="lblProducts" runat="server" CssClass="MainfontStyle" Text="Products:"></asp:Label></td>
																		<td valign="middle">
																			<%--<asp:ListBox ID="lbProducts" runat="server" Width="200px" SelectionMode="Multiple" DataSourceID="odsProducts" DataTextField="ProductName" DataValueField="ProductID" OnDataBound="lbProducts_DataBound" CssClass="inputs" Enabled="False"></asp:ListBox>--%>
																			<asp:Panel ID="pnlProducts" runat="server" Height="160px" HorizontalAlign="Left"
																				ScrollBars="Vertical" Width="100%">
																				<asp:GridView ID="gvProducts" AllowSorting="True" BorderColor="#999999" BorderStyle="Solid"
																					BorderWidth="1px" CellPadding="3" EmptyDataText="No Data Found" runat="server"
																					Width="200px" AutoGenerateColumns="False" DataKeyNames="ProductID" DataSourceID="odsProducts"
																					OnDataBound="gvProducts_DataBound" Enabled="False" OnRowDataBound="gvProducts_RowDataBound"
																					PageSize="5">
																					<FooterStyle BackColor="White" ForeColor="#000066" />
																					<RowStyle CssClass="GridNormalRowsStyle" />
																					<EmptyDataRowStyle Height="90%" HorizontalAlign="Center" VerticalAlign="Middle" Width="98%" />
																					<Columns>
																						<asp:TemplateField HeaderText="Select">
																							<ItemTemplate>
																								<asp:CheckBox ID="cbxSelect" runat="server" OnClick="SelectOne(this)" />
																							</ItemTemplate>
																							<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
																							<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
																						</asp:TemplateField>
																						<asp:BoundField DataField="ProductName" HeaderText="Product" />
																						<asp:TemplateField HeaderText="Quantity">
																							<ItemTemplate>
																								<asp:TextBox ID="txtQuantity" runat="server" CssClass="inputs" onBlur="AdjustOne(this)"
																									Width="40px">0</asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
																										runat="server" ControlToValidate="txtQuantity" Display="Dynamic" ErrorMessage="Marketing materials is required">*</asp:RequiredFieldValidator>
																								<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtQuantity"
																									Display="Dynamic" ErrorMessage="Marketing materials range from 0 to 99999" MaximumValue="99999"
																									MinimumValue="0" Type="Integer">*</asp:RangeValidator>
																							</ItemTemplate>
																						</asp:TemplateField>
																					</Columns>
																					<PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
																					<EmptyDataTemplate>
																						<asp:Label ID="lblNoDataFoundAM" runat="server" CssClass="StyleNoData" Font-Bold="True"
																							Text="No Data Found..."></asp:Label>
																					</EmptyDataTemplate>
																					<SelectedRowStyle Font-Bold="True" ForeColor="Black" />
																					<HeaderStyle CssClass="FMTGridHeaderBackStyle" Font-Bold="True" HorizontalAlign="Center"
																						VerticalAlign="Middle" />
																				</asp:GridView>
																			</asp:Panel>
																		</td>
																		<td valign="middle"></td>
																	</tr>
																	<tr>
																		<td height="5">
																		</td>
																		<td>
																		</td>
																		<td>
																		</td>
																	</tr>
																	<tr>
																		<td align="right">
																			<asp:Label ID="lblMarktMat" runat="server" CssClass="MainfontStyle" Text="Marketing Materials:"></asp:Label></td>
																		<td align="left" valign="middle">
																			<asp:GridView ID="gvMM" AllowSorting="True" BorderColor="#999999" BorderStyle="Solid"
																				BorderWidth="1px" CellPadding="3" EmptyDataText="No Data Found" runat="server"
																				Width="220px" AutoGenerateColumns="False" DataKeyNames="SID" DataSourceID="odsMarketingMaterial"
																				OnDataBound="gvMM_DataBound" Enabled="False" OnRowDataBound="gvMM_RowDataBound">
																				<FooterStyle BackColor="White" ForeColor="#000066" />
																				<EmptyDataRowStyle Height="90%" HorizontalAlign="Center" VerticalAlign="Middle" Width="98%" />
																				<Columns>
																					<asp:TemplateField HeaderText="Select">
																						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
																						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
																						<ItemTemplate>
																							<asp:CheckBox ID="cbxSelect" runat="server" OnClick="SelectOne(this)" />
																						</ItemTemplate>
																					</asp:TemplateField>
																					<asp:BoundField DataField="SubCode" HeaderText="Name" />
																					<asp:TemplateField HeaderText="Quantity">
																						<ItemTemplate>
																							<asp:TextBox ID="txtQuantity" runat="server" CssClass="inputs" Width="40px" onBlur="AdjustOne(this)">0</asp:TextBox><asp:RequiredFieldValidator
																								ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtQuantity" Display="Dynamic"
																								ErrorMessage="Marketing materials is required">*</asp:RequiredFieldValidator>
																							<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtQuantity"
																								Display="Dynamic" ErrorMessage="Marketing materials range from 0 to 99999" MaximumValue="99999"
																								MinimumValue="0" Type="Integer">*</asp:RangeValidator>
																						</ItemTemplate>
																					</asp:TemplateField>
																				</Columns>
																				<RowStyle CssClass="GridNormalRowsStyle" />
																				<EmptyDataTemplate>
																					<asp:Label ID="lblNoDataFoundAM" runat="server" CssClass="StyleNoData" Font-Bold="True"
																						Text="No Data Found..."></asp:Label>
																				</EmptyDataTemplate>
																				<SelectedRowStyle Font-Bold="True" ForeColor="Black" />
																				<PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
																				<HeaderStyle CssClass="FMTGridHeaderBackStyle" Font-Bold="True" HorizontalAlign="Center"
																					VerticalAlign="Middle" />
																			</asp:GridView>
																		</td>
																		<td align="left" valign="middle">
																		</td>
																	</tr>
																	<tr>
																		<td>
																		</td>
																		<td>
																		</td>
																		<td>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
													</table>
												</ContentTemplate>
											</asp:UpdatePanel>
											<asp:ObjectDataSource ID="odsProducts" runat="server" OldValuesParameterFormatString="original_{0}"
												SelectMethod="GetProductsList" TypeName="Pharma.BMD.BLL.ProductsBLL"></asp:ObjectDataSource>
											<asp:ObjectDataSource ID="odsVisitType" runat="server" SelectMethod="GetSCodeByGCode"
												TypeName="Pharma.BMD.BLL.LookupsBLL">
												<SelectParameters>
													<asp:Parameter DefaultValue="VisitTypes" Name="GeneralCode" />
												</SelectParameters>
											</asp:ObjectDataSource>
											<asp:ObjectDataSource ID="odsMarketingMaterial" runat="server" SelectMethod="GetSCodeByGCode"
												TypeName="Pharma.BMD.BLL.LookupsBLL">
												<SelectParameters>
													<asp:Parameter DefaultValue="MarketingMaterials" Name="GeneralCode" />
												</SelectParameters>
											</asp:ObjectDataSource>
										</td>
									</tr>
									<tr>
										<td colspan="6" align="center" valign="middle">
											<asp:UpdatePanel ID="UpdatePanel5" runat="server">
												<ContentTemplate>
													<asp:ValidationSummary ID="vsPlanEntry" runat="server" Font-Bold="True" Font-Names="Arial"
														Font-Size="12px" />
													<asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="13px"
														ForeColor="Green" Visible="False"></asp:Label>
												</ContentTemplate>
											</asp:UpdatePanel>
										</td>
									</tr>
									<tr>
										<td colspan="3">
										</td>
										<td>
										</td>
										<td colspan="2">
										</td>
									</tr>
									<tr>
										<td colspan="6" align="center" valign="middle">
											<uc1:TransButtons ID="ucTransButtons" runat="server" />
										</td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td colspan="3">
					<div id="PopupDiv" style="z-index: 10; left: 42%; top: 45%; position: absolute; height: 40px;
						width: auto;">
						<asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="1">
							<ProgressTemplate>
								<span>
									<img src="../Images/loading.gif" /></span>
							</ProgressTemplate>
						</asp:UpdateProgress>
					</div>
				</td>
			</tr>
			<tr>
				<td id="TDWeekContent" align="center" colspan="3" rowspan="1">
					<table cellpadding="0" cellspacing="0" class="tblStyle" style="width: 100%">
						<tbody>
							<tr>
								<td colspan="3">
									<table style="width: 100%" align="left" id="tblWeeKContent" background="../Images/BG-1.jpg"
										class="tblStyle">
										<tbody>
											<tr>
												<td align="left" background="../Images/TableHead-BG.jpg" colspan="10" rowspan="1"
													style="height: 20px" width="85%">
													<asp:UpdatePanel ID="UpdatePanel7" runat="server">
														<ContentTemplate>
															<asp:Label ID="lblPlanSummary" runat="server" CssClass="MainfontStyle" Font-Size="18px"
																Text="Plan Summary"></asp:Label><asp:Label ID="lblPlanStatus" runat="server" Font-Bold="False"
																	Font-Names="Arial" Font-Size="18px" ForeColor="Maroon" Text="[Plan Status]"></asp:Label>
														</ContentTemplate>
													</asp:UpdatePanel>
												</td>
												<td align="center" background="../Images/TableHead-BG.jpg" colspan="1" rowspan="1"
													style="height: 20px">
													<asp:LinkButton ID="lnkbtnMaxWin" runat="server" CssClass="MainfontStyle" OnClick="lnkbtnMaxWin_Click"
														CausesValidation="False">Max</asp:LinkButton></td>
											</tr>
											<tr>
												<td align="center" colspan="11" rowspan="1" valign="middle">
													<asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
														<ContentTemplate>
															<asp:Label ID="lblName" runat="server" CssClass="FMT-TitleFontStyle" Text="Name:"
																Font-Bold="True"></asp:Label>
															<asp:Label ID="lblMRName" runat="server" CssClass="FMT-TitleFontStyle" Text="Mohammed Fawzi"
																Font-Bold="True"></asp:Label>
															<asp:Label ID="lblTitle" runat="server" CssClass="FMT-TitleFontStyle" Text="Title:"
																Font-Bold="True"></asp:Label>
															<asp:Label ID="lblMRTitle" runat="server" CssClass="FMT-TitleFontStyle" Text="Proffesor"
																Font-Bold="True"></asp:Label>
														</ContentTemplate>
														<Triggers>
															<asp:AsyncPostBackTrigger ControlID="ddlMRList" EventName="SelectedIndexChanged" />
														</Triggers>
													</asp:UpdatePanel>
												</td>
											</tr>
											<tr>
												<td colspan="11" rowspan="1">
												</td>
											</tr>
											<tr>
												<td align="left" colspan="11" rowspan="1" dir="ltr">
													<asp:UpdatePanel ID="upnlWeekContent" runat="server" UpdateMode="Conditional">
														<ContentTemplate>
															<cc1:TabContainer ID="tabcontWeekVisits" runat="server" ActiveTabIndex="0" ScrollBars="Auto"
																Height="550px" OnClientActiveTabChanged="HandleTabChangedClick">
																<cc1:TabPanel ID="tbSat" runat="server" HeaderText="tbSat">
																	<ContentTemplate>
																		<table id="tblVisitsContent" runat="server" width="98%">
																			<tr runat="server">
																				<td colspan="3" runat="server">
																					<table id="Table4" width="100%">
																						<tr>
																							<td colspan="3">
																								<asp:Label ID="lbldaySP" runat="server" CssClass="MainfontStyle" Text="Starting Point:"></asp:Label>
																								<asp:TextBox ID="txtdaySP" runat="server" CssClass="inputs" Width="160px" MaxLength="50"></asp:TextBox>&nbsp;
																								<asp:Label ID="lbldayST" runat="server" CssClass="MainfontStyle" Text="Starting Time:"></asp:Label>
																								<asp:DropDownList ID="ddlDaySTHour" runat="server" Width="78px" 
																									CssClass="inputs" AutoPostBack="True" 
																									onselectedindexchanged="ddlDaySTHour_SelectedIndexChanged">
																									<asp:ListItem>--</asp:ListItem>
																									<asp:ListItem>1</asp:ListItem>
																									<asp:ListItem>2</asp:ListItem>
																									<asp:ListItem>3</asp:ListItem>
																									<asp:ListItem>4</asp:ListItem>
																									<asp:ListItem>5</asp:ListItem>
																									<asp:ListItem>6</asp:ListItem>
																									<asp:ListItem>7</asp:ListItem>
																									<asp:ListItem>8</asp:ListItem>
																									<asp:ListItem>9</asp:ListItem>
																									<asp:ListItem>10</asp:ListItem>
																									<asp:ListItem>11</asp:ListItem>
																									<asp:ListItem>12</asp:ListItem>
																								</asp:DropDownList>
																								<asp:DropDownList ID="ddlDaySTMin" runat="server" Width="78px" CssClass="inputs">
																									<asp:ListItem>00</asp:ListItem>
																									<asp:ListItem>05</asp:ListItem>
																									<asp:ListItem>10</asp:ListItem>
																									<asp:ListItem>15</asp:ListItem>
																									<asp:ListItem>20</asp:ListItem>
																									<asp:ListItem>25</asp:ListItem>
																									<asp:ListItem>30</asp:ListItem>
																									<asp:ListItem>35</asp:ListItem>
																									<asp:ListItem>40</asp:ListItem>
																									<asp:ListItem>45</asp:ListItem>
																									<asp:ListItem>50</asp:ListItem>
																									<asp:ListItem>55</asp:ListItem>
																									<asp:ListItem>--</asp:ListItem>
																								</asp:DropDownList>
																								<asp:DropDownList ID="ddlDaySTDuration" runat="server" Width="40px" CssClass="inputs">
																									<asp:ListItem Value="Õ" Selected="True">Õ</asp:ListItem>
																									<asp:ListItem>ã</asp:ListItem>
																								</asp:DropDownList>
																								<asp:Button ID="btnUpdateSP" runat="server" OnClick="btnUpdateSP_Click" Text="Update" ToolTip="Update Starting Point and Time"
																										Visible="False" CssClass="inputs" ValidationGroup="vgdaySTPM"/></td>
																						</tr>
																						<tr>
																							<td colspan="3" height="5" align="center">
																							</td>
																						</tr>
																						<tr>
																							<td colspan="3">
																								<table class="tblStyle" id="Table1" width="100%">
																									<tr>
																										<td background="../Images/TableHead-BG.jpg" colspan="3">
																											<asp:Label ID="lblAMShift" runat="server" CssClass="MainfontStyle" Text="AM Shift Visits"></asp:Label></td>
																									</tr>
																									<tr>
																										<td colspan="3">
																											<asp:GridView AllowSorting="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid"
																												BorderWidth="1px" CellPadding="3" EmptyDataText="No Data Found" ID="gvDayPlanVisitsAM"
																												runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="VisitID,ModuleRefID"
																												OnRowDataBound="gvDayPlanVisitsAM_RowDataBound" EnableViewState="False" 
																												EnableModelValidation="True">
																												<FooterStyle BackColor="White" ForeColor="#000066" />
																												<EmptyDataRowStyle Height="90%" HorizontalAlign="Center" VerticalAlign="Middle" Width="98%" />
																												<RowStyle CssClass="GridNormalRowsStyle" />
																												<EmptyDataTemplate>
																													<asp:Label ID="lblNoDataFoundAM" runat="server" CssClass="StyleNoData" Font-Bold="True"
																														Text="No Data Found..."></asp:Label>
																												</EmptyDataTemplate>
																												<SelectedRowStyle BackColor="#BCC9B7" Font-Bold="True" ForeColor="White" />
																												<PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
																												<HeaderStyle CssClass="FMTGridHeaderBackStyle" Font-Bold="True" HorizontalAlign="Center"
																													VerticalAlign="Middle" />
																												<Columns>
																													<asp:TemplateField HeaderText="Dest. Name">
																														<EditItemTemplate>
																															<asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ModuleName") %>'></asp:TextBox>
																														</EditItemTemplate>
																														<ItemTemplate>
																															<asp:HyperLink ID="lnkModuleNameRef" runat="server" Text='<%# Bind("ModuleName") %>'
																																Target="_blank"></asp:HyperLink>
																															<asp:Label ID="lblOtherModule" runat="server" CssClass="MainfontStyle" Text='<%# Bind("OtherDetails") %>'
																																Visible="False"></asp:Label>
																														</ItemTemplate>
																													</asp:TemplateField>
																													<asp:BoundField HeaderText="Dest. Type" DataField="ModuleType" />
																													<asp:BoundField HeaderText="Brick Name" DataField="BrickName" />
																													<asp:BoundField HeaderText="Visit Type" DataField="VisitTypeName" />
																													<asp:TemplateField HeaderText="Product List">
																														<EditItemTemplate>
																															<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
																														</EditItemTemplate>
																														<ItemTemplate>
																															<asp:DropDownList ID="ddlvProducts" runat="server" CssClass="inputs" Width="150px"
																																DataTextField="VisitItemName" DataValueField="ItemCodeID" Visible="False">
																																<asp:ListItem></asp:ListItem>
																																<asp:ListItem></asp:ListItem>
																																<asp:ListItem></asp:ListItem>
																																<asp:ListItem></asp:ListItem>
																																<asp:ListItem></asp:ListItem>
																															</asp:DropDownList>
																														</ItemTemplate>
																														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
																													</asp:TemplateField>
																													<asp:TemplateField HeaderText="Marketing Materials">
																														<EditItemTemplate>
																															<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
																														</EditItemTemplate>
																														<ItemTemplate>
																															<asp:DropDownList ID="ddlvMM" runat="server" CssClass="inputs" Width="150px" DataTextField="VisitItemName"
																																DataValueField="ItemCodeID" Visible="False">
																																<asp:ListItem></asp:ListItem>
																																<asp:ListItem></asp:ListItem>
																																<asp:ListItem></asp:ListItem>
																																<asp:ListItem></asp:ListItem>
																																<asp:ListItem></asp:ListItem>
																															</asp:DropDownList>
																														</ItemTemplate>
																														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
																													</asp:TemplateField>
																													<asp:TemplateField HeaderText="Visit List">
																														<EditItemTemplate>
																															<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
																														</EditItemTemplate>
																														<ItemTemplate>
																															<asp:DropDownList ID="ddlvEntity" runat="server" CssClass="inputs" Width="150px"
																																DataTextField="SubModuleName" DataValueField="SubModuleRefID" Visible="False">
																																<asp:ListItem></asp:ListItem>
																																<asp:ListItem></asp:ListItem>
																																<asp:ListItem></asp:ListItem>
																																<asp:ListItem></asp:ListItem>
																																<asp:ListItem></asp:ListItem>
																															</asp:DropDownList>
																														</ItemTemplate>
																														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
																													</asp:TemplateField>
																													<asp:TemplateField HeaderText="Delete" ShowHeader="False">
																														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
																														<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
																														<ItemTemplate>
																															<asp:CheckBox ID="cbxDelete" runat="server" />
																														</ItemTemplate>
																													</asp:TemplateField>
																												</Columns>
																											</asp:GridView>
																										</td>
																									</tr>
																								</table>
																							</td>
																						</tr>
																						<tr>
																							<td colspan="3">
																								<asp:Label ID="lbldaySPPM" runat="server" CssClass="MainfontStyle" Text="Starting Point:"></asp:Label>
																								<asp:TextBox ID="txtdaySPPM" runat="server" CssClass="inputs" Width="160px" MaxLength="50"></asp:TextBox>&nbsp;
																								<asp:Label ID="lbldaySTPM" runat="server" CssClass="MainfontStyle" Text="Starting Time:"></asp:Label>
																								<asp:DropDownList ID="ddlDaySTHourPM" runat="server" Width="78px" 
																									CssClass="inputs" AutoPostBack="True" 
																									onselectedindexchanged="ddlDaySTHourPM_SelectedIndexChanged">
																									<asp:ListItem>--</asp:ListItem>
																									<asp:ListItem>1</asp:ListItem>
																									<asp:ListItem>2</asp:ListItem>
																									<asp:ListItem>3</asp:ListItem>
																									<asp:ListItem>4</asp:ListItem>
																									<asp:ListItem>5</asp:ListItem>
																									<asp:ListItem>6</asp:ListItem>
																									<asp:ListItem>7</asp:ListItem>
																									<asp:ListItem>8</asp:ListItem>
																									<asp:ListItem>9</asp:ListItem>
																									<asp:ListItem>10</asp:ListItem>
																									<asp:ListItem>11</asp:ListItem>
																									<asp:ListItem>12</asp:ListItem>
																								</asp:DropDownList>
																								<asp:DropDownList ID="ddlDaySTMinPM" runat="server" Width="78px" CssClass="inputs">
																									<asp:ListItem>00</asp:ListItem>
																									<asp:ListItem>05</asp:ListItem>
																									<asp:ListItem>10</asp:ListItem>
																									<asp:ListItem>15</asp:ListItem>
																									<asp:ListItem>20</asp:ListItem>
																									<asp:ListItem>25</asp:ListItem>
																									<asp:ListItem>30</asp:ListItem>
																									<asp:ListItem>35</asp:ListItem>
																									<asp:ListItem>40</asp:ListItem>
																									<asp:ListItem>45</asp:ListItem>
																									<asp:ListItem>50</asp:ListItem>
																									<asp:ListItem>55</asp:ListItem>
																									<asp:ListItem>--</asp:ListItem>
																								</asp:DropDownList>
																								<asp:DropDownList ID="ddlDaySTDurationPM" runat="server" Width="40px" CssClass="inputs">
																									<asp:ListItem Value="ã" Selected="True">ã</asp:ListItem>
																									<asp:ListItem>Õ</asp:ListItem>
																								</asp:DropDownList>
																								<asp:Button ID="btnUpdateSPPM" runat="server" OnClick="btnUpdateSPPM_Click" Text="Update" ToolTip="Update Starting Point and Time"
																										Visible="False" CssClass="inputs" ValidationGroup="vgdaySTPM" /></td>
																						</tr>
																						<tr>
																							<td colspan="3" height="5" align="center">
																							</td>
																						</tr>
																						<tr>
																							<td colspan="3">
																								<table class="tblStyle" id="Table2" width="100%">
																									<tr>
																										<td background="../Images/TableHead-BG.jpg" colspan="3">
																											<asp:Label ID="lblPMShift" runat="server" CssClass="MainfontStyle" Text="PM Shift Visits"></asp:Label></td>
																									</tr>
																									<tr>
																										<td colspan="3">
																											<asp:GridView AllowSorting="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid"
																												BorderWidth="1px" CellPadding="3" EmptyDataText="No Data Found" ID="gvDayPlanVisitsPM"
																												runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="VisitID,ModuleRefID"
																												OnRowDataBound="gvDayPlanVisitsPM_RowDataBound" EnableViewState="False" 
																												EnableModelValidation="True">
																												<FooterStyle BackColor="White" ForeColor="#000066" />
																												<EmptyDataRowStyle Height="90%" HorizontalAlign="Center" VerticalAlign="Middle" Width="98%" />
																												<Columns>
																													<asp:TemplateField HeaderText="Dest. Name">
																														<EditItemTemplate>
																															<asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ModuleName") %>'></asp:TextBox>
																														</EditItemTemplate>
																														<ItemTemplate>
																															<asp:HyperLink ID="lnkModuleNameRef" runat="server" Target="_blank" Text='<%# Bind("ModuleName") %>'></asp:HyperLink><asp:Label
																																ID="lblOtherModule" runat="server" CssClass="MainfontStyle" Text='<%# Bind("OtherDetails") %>'
																																Visible="False"></asp:Label>
																														</ItemTemplate>
																													</asp:TemplateField>
																													<asp:BoundField HeaderText="Dest. Type" DataField="ModuleType" />
																													<asp:BoundField HeaderText="Brick Name" DataField="BrickName" />
																													<asp:BoundField HeaderText="Visit Type" DataField="VisitTypeName" />
																													<asp:TemplateField HeaderText="Product List">
																														<EditItemTemplate>
																															<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
																														</EditItemTemplate>
																														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
																														<ItemTemplate>
																															<asp:DropDownList ID="ddlvProducts" runat="server" CssClass="inputs" Width="150px"
																																DataTextField="VisitItemName" DataValueField="ItemCodeID" Visible="False">
																																<asp:ListItem></asp:ListItem>
																																<asp:ListItem></asp:ListItem>
																																<asp:ListItem></asp:ListItem>
																																<asp:ListItem></asp:ListItem>
																																<asp:ListItem></asp:ListItem>
																															</asp:DropDownList>
																														</ItemTemplate>
																													</asp:TemplateField>
																													<asp:TemplateField HeaderText="Marketing Materials">
																														<EditItemTemplate>
																															<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
																														</EditItemTemplate>
																														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
																														<ItemTemplate>
																															<asp:DropDownList ID="ddlvMM" runat="server" CssClass="inputs" Width="150px" DataTextField="VisitItemName"
																																DataValueField="ItemCodeID" Visible="False">
																																<asp:ListItem></asp:ListItem>
																																<asp:ListItem></asp:ListItem>
																																<asp:ListItem></asp:ListItem>
																																<asp:ListItem></asp:ListItem>
																																<asp:ListItem></asp:ListItem>
																															</asp:DropDownList>
																														</ItemTemplate>
																													</asp:TemplateField>
																													<asp:TemplateField HeaderText="Visit List">
																														<EditItemTemplate>
																															<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
																														</EditItemTemplate>
																														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
																														<ItemTemplate>
																															<asp:DropDownList ID="ddlvEntity" runat="server" CssClass="inputs" Width="150px"
																																DataTextField="SubModuleName" DataValueField="SubModuleRefID" Visible="False">
																																<asp:ListItem></asp:ListItem>
																																<asp:ListItem></asp:ListItem>
																																<asp:ListItem></asp:ListItem>
																																<asp:ListItem></asp:ListItem>
																																<asp:ListItem></asp:ListItem>
																															</asp:DropDownList>
																														</ItemTemplate>
																													</asp:TemplateField>
																													<asp:TemplateField HeaderText="Delete" ShowHeader="False">
																														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
																														<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
																														<ItemTemplate>
																															<asp:CheckBox ID="cbxDelete" runat="server" />
																														</ItemTemplate>
																													</asp:TemplateField>
																												</Columns>
																												<RowStyle CssClass="GridNormalRowsStyle" />
																												<EmptyDataTemplate>
																													<asp:Label ID="lblNoDataFoundAM" runat="server" CssClass="StyleNoData" Font-Bold="True"
																														Text="No Data Found..."></asp:Label>
																												</EmptyDataTemplate>
																												<SelectedRowStyle BackColor="#BCC9B7" Font-Bold="True" ForeColor="White" />
																												<PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
																												<HeaderStyle CssClass="FMTGridHeaderBackStyle" Font-Bold="True" HorizontalAlign="Center"
																													VerticalAlign="Middle" />
																											</asp:GridView>
																										</td>
																									</tr>
																								</table>
																							</td>
																						</tr>
																						<tr>
																							<td colspan="3">
																							</td>
																						</tr>
																						<tr>
																							<td colspan="3" align="center" valign="middle">
																								<asp:ImageButton ID="btnDelete" runat="server" AlternateText="Delete Selected Visits"
																									ImageUrl="~/Images/delete_n.jpg" OnClick="btnDelete_Click" Visible="False" CausesValidation="False"
																									OnClientClick="return ConfirmDelete()" /></td>
																						</tr>
																					</table>
																				</td>
																			</tr>
																		</table>
																	</ContentTemplate>
																	<HeaderTemplate>
																		<asp:Label ID="lblSat" runat="server" CssClass="MainfontStyle" Text=":: Sat ::"></asp:Label>
																	</HeaderTemplate>
																</cc1:TabPanel>
                                                                <cc1:TabPanel ID="tbSun" runat="server" HeaderText="tbSun">
																	<HeaderTemplate>
																		<asp:Label ID="lblSun" runat="server" CssClass="MainfontStyle" Text=":: Sun ::"></asp:Label>
																	</HeaderTemplate>
																</cc1:TabPanel>
																<cc1:TabPanel ID="tbMon" runat="server" HeaderText="tbMon">
																	<HeaderTemplate>
																		<asp:Label ID="lblMon" runat="server" CssClass="MainfontStyle" Text=":: Mon ::"></asp:Label>
																	</HeaderTemplate>
																</cc1:TabPanel>
																<cc1:TabPanel ID="tbTue" runat="server" HeaderText="tbTue">
																	<HeaderTemplate>
																		<asp:Label ID="lblTue" runat="server" CssClass="MainfontStyle" Text=":: Tue ::"></asp:Label>
																	</HeaderTemplate>
																</cc1:TabPanel>
																<cc1:TabPanel ID="tbWed" runat="server" HeaderText="tbWed">
																	<HeaderTemplate>
																		<asp:Label ID="lblWed" runat="server" CssClass="MainfontStyle" Text=":: Wed ::"></asp:Label>
																	</HeaderTemplate>
																</cc1:TabPanel>
																<cc1:TabPanel ID="tbThur" runat="server" HeaderText="tbThur">
																	<HeaderTemplate>
																		<asp:Label ID="lblThur" runat="server" CssClass="MainfontStyle" Text=":: Thur ::"></asp:Label>
																	</HeaderTemplate>
																</cc1:TabPanel>
																<cc1:TabPanel ID="tbFri" runat="server" HeaderText="tbFri">
																	<HeaderTemplate>
																		<asp:Label ID="lblFri" runat="server" CssClass="MainfontStyle" Text=":: Fri ::"></asp:Label>
																	</HeaderTemplate>
																</cc1:TabPanel>
															</cc1:TabContainer>
															<asp:Button ID="btnctlTabChangedEvent" runat="server" Text="btnctlTabChangedEvent"
																OnClick="btnctlTabChangedEvent_Click" CssClass="hiddenbutton" CausesValidation="False" />
														</ContentTemplate>
														<Triggers>
															<asp:AsyncPostBackTrigger ControlID="btnctlTabChangedEvent" EventName="Click" />
															<asp:AsyncPostBackTrigger ControlID="txtPlanDate" EventName="TextChanged" />
															<asp:AsyncPostBackTrigger ControlID="ddlMRList" EventName="SelectedIndexChanged" />
															<asp:AsyncPostBackTrigger ControlID="ucTransButtons" EventName="btnSaveEvent" />
															<asp:AsyncPostBackTrigger ControlID="btnCommit" EventName="Click" />
														</Triggers>
													</asp:UpdatePanel>
												</td>
											</tr>
											<tr>
												<td colspan="11" rowspan="1">
												</td>
											</tr>
											<tr>
												<td colspan="11" rowspan="1">
												</td>
											</tr>
											<tr>
												<td align="center" colspan="11" rowspan="1">
													<table width="100%" id="tblBricksStatistics" class="tblStyle">
														<tr>
															<td align="left" background="../Images/TableHead-BG.jpg" colspan="4" rowspan="1"
																valign="top">
																<asp:Label ID="lblStatistics" runat="server" CssClass="MainfontStyle" Text="Plan (Statistics /  Approval)"></asp:Label></td>
														</tr>
														<tr>
															<td align="left" valign="top">
																<asp:UpdatePanel ID="UpdatePanel8" runat="server">
																	<ContentTemplate>
																		<table id="tblBrickSummary" runat="server" class="tblStyle" width="100%" height="110">
																			<tr>
																				<td colspan="3">
																					<table id="tblinnertblBrickSummary" width="100%">
																						<tr>
																							<td>
																							</td>
																							<td>
																							</td>
																						</tr>
																						<tr>
																							<td align="right">
																								<asp:Label ID="lblListOfBricks" runat="server" CssClass="MainfontStyle" Font-Bold="False">List of all the bricks that belong to the MR :</asp:Label></td>
																							<td align="left">
																								<asp:DropDownList ID="ddlAllUserBricks" runat="server" Width="160px" CssClass="inputs"
																									OnDataBound="ddlAllUserBricks_DataBound">
																								</asp:DropDownList></td>
																						</tr>
																						<tr>
																							<td align="right">
																								<asp:Label ID="Label1" runat="server" CssClass="MainfontStyle" Font-Bold="False">List of bricks that will be covered throgh the plan :</asp:Label></td>
																							<td align="left">
																								<asp:DropDownList ID="ddlPlanUserBricks" runat="server" Width="160px" CssClass="inputs"
																									OnDataBound="ddlPlanUserBricks_DataBound">
																								</asp:DropDownList></td>
																						</tr>
																						<tr>
																							<td align="right">
																								<asp:Label ID="Label2" runat="server" CssClass="MainfontStyle" Font-Bold="False">Number of bricks to be covered :</asp:Label></td>
																							<td align="left">
																								<asp:Label ID="lblPlanBricksNo" runat="server" CssClass="MainfontStyle" Text="PlanBricksNo"></asp:Label></td>
																						</tr>
																						<tr>
																							<td align="right">
																								<asp:Label ID="Label3" runat="server" CssClass="MainfontStyle" Font-Bold="False">Total Number of bricks that Belong to the MR :</asp:Label></td>
																							<td align="left">
																								<asp:Label ID="lblTotalBricksNo" runat="server" CssClass="MainfontStyle" Text="TotalBricksNo"></asp:Label></td>
																						</tr>
																					</table>
																				</td>
																			</tr>
																		</table>
																	</ContentTemplate>
																</asp:UpdatePanel>
															</td>
															<td align="left" rowspan="2" width="1%">
															</td>
															<td colspan="2" align="center" valign="top">
																<asp:UpdatePanel ID="upnlApproveWeekPlan" runat="server">
																	<ContentTemplate>
																		<table id="tblApprovalManager" runat="server" class="tblStyle" width="100%" height="110">
																			<tr>
																				<td colspan="3">
																					<table id="tblinnerApproval" width="100%">
																						<tr>
																							<td>
																							</td>
																							<td>
																							</td>
																							<td>
																							</td>
																						</tr>
																						<tr>
																							<td align="center" colspan="3">
																								<asp:Label ID="lblApprove" runat="server" CssClass="MainfontStyle" Text="Week Plan Status"></asp:Label></td>
																						</tr>
																						<tr>
																							<td align="center" colspan="3">
																								<asp:RadioButtonList ID="rbApproveWeekPlan" runat="server" CssClass="MainfontStyle"
																									RepeatDirection="Horizontal">
																									<asp:ListItem Value="0" Selected="True">Pending</asp:ListItem>
																									<asp:ListItem Value="1">Approve</asp:ListItem>
																									<asp:ListItem Value="2">Reject</asp:ListItem>
																								</asp:RadioButtonList></td>
																						</tr>
																						<tr>
																							<td align="center" colspan="3">
																								<asp:Button ID="btnCommit" runat="server" CssClass="button" Text="Commit" Width="120px"
																									OnClick="btnCommit_Click" CausesValidation="False" /></td>
																						</tr>
																						<tr>
																							<td>
																							</td>
																							<td>
																							</td>
																							<td>
																							</td>
																						</tr>
																					</table>
																				</td>
																			</tr>
																		</table>
																	</ContentTemplate>
																</asp:UpdatePanel>
															</td>
														</tr>
														<tr>
															<td width="60%">
															</td>
															<td colspan="2">
															</td>
														</tr>
													</table>
												</td>
											</tr>
											<tr>
												<td align="center" colspan="11" rowspan="1">
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
							<tr>
								<td align="left" colspan="3" valign="top">
								</td>
							</tr>
						</tbody>
					</table>
				</td>
			</tr>
			<tr>
				<td align="center" colspan="3" rowspan="1">
				</td>
			</tr>
		</tbody>
	</table>
</asp:Content>
