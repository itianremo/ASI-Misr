<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AccountLists.aspx.cs" Theme="Red"
	MasterPageFile="~/MasterLayout.master" Inherits="AccountLists" EnableEventValidation="false"
	ValidateRequest="false" Title="Account Details" %>

<%@ MasterType VirtualPath="~/MasterLayout.master" %>
<%@ Register Src="Controls/AutoCompleteSearch.ascx" TagName="AutoCompleteSearch"
	TagPrefix="uc3" %>
<%@ Register Src="Controls/TransToolBar.ascx" TagName="TransToolBar" TagPrefix="uc2" %>
<%@ Register Src="Controls/BranchesGrid.ascx" TagName="BranchesGrid" TagPrefix="uc4" %>
<%@ Register Src="Controls/BranchForm.ascx" TagName="BranchForm" TagPrefix="uc5" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="Controls/HistoryNC.ascx" TagName="HistoryNC" TagPrefix="uc7" %>
<%@ Register Src="Controls/Attachment.ascx" TagName="Attachment" TagPrefix="uc8" %>
<%@ Register Src="Controls/Key.ascx" TagName="Key" TagPrefix="uc6" %>
<%@ Register Src="~/Controls/Contacts.ascx" TagName="Contacts" TagPrefix="ucC" %>
<%@ Register Src="~/Controls/SubCompaniesGrid.ascx" TagName="SubAccounts" TagPrefix="uc9" %>
<%@ Register Src="Controls/DueDiligance.ascx" TagName="DueDiligance" TagPrefix="uc10" %>
<asp:Content ID="Head" runat="server" ContentPlaceHolderID="head">
	<script type="text/javascript" src="Scripts/Scripts.js"></script>	
	<style>
		.wordwrap
		{
			white-space: normal;
		}
	</style>
	<script type="text/javascript">

		var wndHandle;
		function AttacheFile(AccountID) {
			wndHandle = window.open("AttachFile2.aspx?AccountID=" + AccountID, null, "alwaysraised=yes,left=20,top=250,resizable=no,scrollbars=no,status=yes,width=550,height=250", "")
		}

		function DownloadFile(AttachID) {
			wndHandle = window.open("DownloadFile.aspx?AttachID=" + AttachID, null, "alwaysraised=yes,left=1,top=1,resizable=no,scrollbars=no,status=yes,width=5,height=5", "")
			//        if (wndHandle && wndHandle.open) {
			//            wndHandle.close();
			//        }
		}

		function EmailForm(SelectedValue, AccountID, DueDil_ID) {

			alert(SelectedValue);
			// wndHandle = window.open("EmailForm.aspx?AccountID=" + AccountID + ",DueDil_ID=" + DueDil_ID, null, "alwaysraised=yes,left=20,top=250,resizable=no,scrollbars=no,status=yes,width=550,height=250", "")
		}
		//    function fireEvent(element, event) {
		//        if (document.createEventObject) {
		//            // dispatch for IE
		//            var evt = document.createEventObject();
		//            return element.fireEvent('on' + event, evt)
		//        }
		//        else {
		//            // dispatch for firefox + others
		//            var evt = document.createEvent("HTMLEvents");
		//            evt.initEvent(event, true, true); // event type,bubbling,cancelable
		//            return !element.dispatchEvent(evt);
		//        }
		//    }
		function Duediligence(MasterOrCredit, dropdown, AccountID, DueDil_ID) {
			// alert(dropdown +' '+AccountID + "," + DueDil_ID);
			var myindex = dropdown.selectedIndex;
			var SelectedValue = dropdown.options[myindex].value;
			var emailto = document.getElementById('frmViewAccountDetails$txtEmailEdit').value;

			// alert(emailto +' , ' + MasterOrCredit + ' , ' + SelectedValue + ', ' + AccountID + "," + DueDil_ID);
			if (SelectedValue != "SelectOne") {
				if (SelectedValue == "EmailForm")
					wndHandle = window.open("EmailForm.aspx?emailto=" + emailto + "&MasterOrCredit=" + MasterOrCredit + "&AccountID=" + AccountID + "&DueDil_ID=" + DueDil_ID, null, "alwaysraised=yes,left=20,top=250,resizable=no,scrollbars=yes,status=yes,width=550,height=650", "")
				else if (SelectedValue == "UploadForm")
					wndHandle = window.open("AttachFile3.aspx?MasterOrCredit=" + MasterOrCredit + "&AccountID=" + AccountID + "&DueDil_ID=" + DueDil_ID, null, "alwaysraised=yes,left=20,top=250,resizable=no,scrollbars=no,status=yes,width=330,height=120", "")
				else if (SelectedValue == "Preview")
					wndHandle = window.open("Preview.aspx?MasterOrCredit=" + MasterOrCredit + "&AccountID=" + AccountID + "&DueDil_ID=" + DueDil_ID, null, "alwaysraised=yes,left=1,top=1,resizable=no,scrollbars=no,status=yes,width=1,height=1", "")
				else SelectedValue = null;
			}

			/*   var isFound = false;

			for (var i = 0; i < elementRef.options.length; i++) {
			if (elementRef.options[i].value == valueToSetTo) {
			elementRef.options[i].selected = true;
			isFound = true;
			}
			}

			if (isFound == false)
			elementRef.options[0].selected = true;
			*/
		}



		//    function uploadError(sender, args) {
		//        document.getElementById('lblStatus').innerText = args.get_fileName(), "<span style='color:red;'>" + args.get_errorMessage() + "</span>";
		//    }

		//    function StartUpload(sender, args) {
		//        document.getElementById('lblStatus').innerText = 'Uploading Started.';
		//    }

		//    function UploadComplete(sender, args) {
		//        var filename = args.get_fileName();
		//        var contentType = args.get_contentType();
		//        var text = "Size of " + filename + " is " + args.get_length() + " bytes";
		//        if (contentType.length > 0) {
		//            text += " and content type is '" + contentType + "'.";
		//        }
		//        document.getElementById('lblStatus').innerText = text;
		//    }





		function SubmitContactNoteResult(source, eventArgs) {
			//alert(document.getElementById('ucAutoCompleteSearch$txtBoxSearch').value);
			if (document.getElementById('TabContainer1$TabPanel1$txtSearchContact').value != '') {
				document.getElementById('TabContainer1$TabPanel1$btnSearchNoteContact').click();
			}
		}

		function PageLoadedHandler() {
			var NewAccount;
			NewAccount = '<%=Session["NewAccount"]%>';
			if (NewAccount == 'True') {
				setTimeout(DisableTab, 1);
			}
		}

		function EnableTabsTriger() {
			setTimeout(EnableTabsElapsed, 5);
		}

		function EnableTabsElapsed() {
			document.getElementById('btnEnableEnsure').click();
		}
		//    function closeChildWnd() {
		//        // if(win && win.open && !win.closed) win.close();
		//        //win.close();

		//        if (wndHandle && wndHandle.open) {
		//            wndHandle.close();
		//        }
		//    }
		function window_onload() {
			PageLoadedHandler();
		}

		function window_onunload() {
			closeChildWnd();
		}

	</script>
	<script type="text/javascript" for="window" event="onload">
    <!--
    return window_onload()
    // -->
	</script>
	<script type="text/javascript" for="window" event="onunload">
    <!--
    return window_onunload()
    // -->
	</script>
</asp:Content>
<asp:Content ID="Main" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
	<div class="header" style="height: 29px; background-color: rgb(0, 0, 0);">
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr>
				<td style="padding-left:5%; width: 0px;">
					<uc2:TransToolBar ID="ucTransToolBar" runat="server"  />
				</td>
				<td>
					<asp:UpdatePanel ID="UpdatePanel5" runat="server">
						<ContentTemplate>
							&nbsp;<asp:ImageButton ID="imgbtnPrevious" runat="server" ImageUrl="~/Images/LeftArrow_n.gif"
								OnClick="imgbtnPrevious_Click" AlternateText="Previous Account" /><asp:ImageButton
									ID="imgbtnNext" runat="server" ImageUrl="~/Images/RightArrow_n.gif" OnClick="imgbtnNext_Click"
									AlternateText="Next Account" />
						</ContentTemplate>
					</asp:UpdatePanel>
				</td>
				<td>
					<asp:UpdatePanel ID="UpdatePanel2" runat="server">
						<ContentTemplate>
							<uc3:AutoCompleteSearch ID="ucAutoCompleteSearch" runat="server" />
						</ContentTemplate>
					</asp:UpdatePanel>
				</td>
			</tr>
		</table>
	</div>
	<div class="ui-layout-content" style="margin: 0 auto; width: 90%;">
		<asp:UpdatePanel ID="UpdatePanel4" runat="server">
			<ContentTemplate>
				<asp:FormView ID="frmViewAccountDetails" runat="server" AllowPaging="True" BorderColor="Gray"
					BorderWidth="1px" OnPageIndexChanging="frmViewAccountDetails_PageIndexChanging"
					DataKeyNames="AccountID" OnDataBound="frmViewAccountDetails_DataBound" BackColor="White">
					<PagerSettings Mode="NextPrevious" FirstPageText="First" LastPageText="Last" NextPageText="Next"
						PreviousPageText="Previous" NextPageImageUrl="~/Images/Right-arrow.gif" PreviousPageImageUrl="~/Images/Left-Arrow.gif"
						Visible="False" />
					<ItemTemplate>
						<table border="0" style="height: 1px">
							<tr>
								<td align="right" style="width: 130px; height: 14px;">
									&nbsp;<asp:Label ID="lblCompany" runat="server" CssClass="MainfontStyle" Text="Company/Agency"></asp:Label>
								</td>
								<td align="left" style="width: 210px;">
									<asp:TextBox ID="txtboxAccountName" runat="server" CssClass="txtinputs" Text='<%# Bind("AccountName") %>'
										ReadOnly="True" BackColor="#FFFF80"></asp:TextBox><asp:Label ID="lblErrSymAccName"
											runat="server" CssClass="MainfontStyle" Font-Bold="True" ForeColor="Red" Text="*"
											Visible="False"></asp:Label>
								</td>
								<td align="right" style="width: 80px; height: 14px;">
									<asp:Label ID="lblStreet1" runat="server" CssClass="MainfontStyle" Text="Street 1"></asp:Label>
								</td>
								<td align="left" style="width: 210px; height: 14px;">
									<asp:TextBox ID="txtboxStreet1" runat="server" CssClass="txtinputs" Text='<%# Bind("Street1") %>'
										ReadOnly="True" TabIndex="7"></asp:TextBox>
								</td>
								<td align="right" style="height: 14px;">
									<asp:Label ID="lblAccountNo" runat="server" CssClass="MainfontStyle" Text="Company No"></asp:Label>
								</td>
								<td align="left" style="height: 14px;">
									<asp:TextBox ID="txtAccountNo" runat="server" CssClass="txtinputs" Text='<%# Eval("AccountID") %>'
										ReadOnly="True" TabIndex="8"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td align="right" style="width: 130px;">
									<asp:Label ID="lblBusSec" runat="server" CssClass="MainfontStyle" Text="Business Sector"></asp:Label>
								</td>
								<td align="left" style="width: 210px; height: 6px">
									<asp:DropDownList ID="ddlBusSector" runat="server" DataSourceID="odsBusSector" DataTextField="SubCode"
										DataValueField="SubID" CssClass="inputs" Width="205px" Enabled="False" TabIndex="1">
									</asp:DropDownList>
									<asp:TextBox ID="txtBusSector" runat="server" Text='<%# Bind("BusSector") %>' Visible="False"
										Width="32px" CssClass="txtinputs"></asp:TextBox>
								</td>
								<td align="right" style="width: 80px;">
									<asp:Label ID="lblStreet2" runat="server" CssClass="MainfontStyle" Text="Street 2"></asp:Label>
								</td>
								<td align="left" style="width: 210px; height: 6px">
									<asp:TextBox ID="txtboxStreet2" runat="server" CssClass="txtinputs" Text='<%# Bind("Street2") %>'
										ReadOnly="True" TabIndex="8"></asp:TextBox>
								</td>
								<td align="right" style="height: 14px;">
									<asp:Label ID="Label6" runat="server" CssClass="MainfontStyle" Text="Parent"></asp:Label>
								</td>
								<td align="left" style="height: 14px;">
									<asp:DropDownList ID="ddlParent" runat="server" DataSourceID="odsParents" DataTextField="AccountName"
										DataValueField="AccountID" CssClass="inputs" Width="205px" Enabled="False" OnDataBinding="ddlParent_DataBinding"
										OnDataBound="ddlParent_DataBound" AppendDataBoundItems="True">
									</asp:DropDownList>
								</td>
							</tr>
							<tr>
								<td align="right" style="width: 130px;">
									<asp:Label ID="lblPhone" runat="server" CssClass="MainfontStyle" Text="Telephone"></asp:Label>
								</td>
								<td align="left" style="width: 210px; height: 6px">
									<asp:TextBox ID="txtboxPhone" runat="server" CssClass="txtinputs" Text='<%# Bind("phone") %>'
										BackColor="#FFFF80" ReadOnly="True" TabIndex="2"></asp:TextBox><asp:Label ID="lblErrSymPhone"
											runat="server" CssClass="MainfontStyle" Font-Bold="True" ForeColor="Red" Text="*"
											Visible="False"></asp:Label>
								</td>
								<td align="right" style="width: 80px;">
									<asp:Label ID="lblCity" runat="server" CssClass="MainfontStyle" Text="City"></asp:Label>
								</td>
								<td align="left" style="width: 210px; height: 6px">
									<asp:TextBox ID="txtboxCity" runat="server" CssClass="txtinputs" Text='<%# Bind("City") %>'
										ReadOnly="True" TabIndex="9"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td align="right" style="width: 130px;">
									<asp:Label ID="lblFax" runat="server" CssClass="MainfontStyle" Text="Fax"></asp:Label>
								</td>
								<td align="left" style="width: 210px; height: 6px">
									<asp:TextBox ID="txtboxFax" runat="server" CssClass="txtinputs" Text='<%# Bind("Fax") %>'
										ReadOnly="True" TabIndex="3"></asp:TextBox>
									<asp:Label ID="lblErrSymFax" runat="server" CssClass="MainfontStyle" Font-Bold="True"
										ForeColor="Red" Text="*" Visible="False"></asp:Label>
								</td>
								<td align="right" style="width: 80px;">
									<asp:Label ID="lblZipCode" runat="server" CssClass="MainfontStyle" Text="Zip Code"></asp:Label>
								</td>
								<td align="left" style="width: 210px; height: 6px">
									<asp:TextBox ID="txtboxZipCode" runat="server" CssClass="txtinputs" Text='<%# Bind("ZipCode") %>'
										ReadOnly="True" BackColor="#FFFF80" TabIndex="10"></asp:TextBox><asp:Label ID="lblErrSymZipCode"
											runat="server" CssClass="MainfontStyle" Font-Bold="True" ForeColor="Red" Text="*"
											Visible="False"></asp:Label>
									<asp:Label ID="lblErrSymZip" runat="server" CssClass="MainfontStyle" Font-Bold="True"
										ForeColor="Red" Text="*" Visible="False"></asp:Label>
								</td>
							</tr>
							<tr>
								<td align="right" style="width: 130px; height: 21px;">
									<asp:Label ID="lblStatus" runat="server" CssClass="MainfontStyle" Text="Status"></asp:Label>
								</td>
								<td align="left" style="width: 210px; height: 21px;">
									<asp:DropDownList ID="ddlStatus" runat="server" DataSourceID="odsStatus" DataTextField="SubCode"
										DataValueField="SubID" CssClass="inputs" Width="205px" Enabled="False" TabIndex="5">
									</asp:DropDownList>
									<asp:TextBox ID="txtAccID" runat="server" CssClass="txtinputs" ReadOnly="True" Text='<%# Bind("AccountID") %>'
										Visible="False" Width="30px"></asp:TextBox>
								</td>
								<td align="right" style="width: 80px; height: 21px;">
									<asp:Label ID="lblAccountCountry" runat="server" CssClass="MainfontStyle" Text="Country"></asp:Label>
								</td>
								<td align="left" style="width: 210px; height: 21px;">
									<asp:DropDownList ID="ddlCountry" runat="server" DataSourceID="odsCountries" DataTextField="SubCode"
										DataValueField="SubID" CssClass="inputs" Width="205px" Enabled="False" AutoPostBack="True"
										OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" TabIndex="11">
									</asp:DropDownList>
									<asp:TextBox ID="txtCountryID" runat="server" CssClass="txtinputs" ReadOnly="True"
										Text='<%# Bind("CountryID") %>' Visible="False" Width="30px"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td align="right" height="1" style="width: 130px">
									<asp:Label ID="lblReferredBy" runat="server" CssClass="MainfontStyle" Text="Referred By"></asp:Label>
								</td>
								<td align="left" height="1" style="width: 210px" valign="top">
									<asp:TextBox ID="txtboxRefBy" runat="server" CssClass="txtinputs" Text='<%# Bind("ReferedBy") %>'
										ReadOnly="True" TabIndex="6"></asp:TextBox><asp:TextBox ID="txtStatus" runat="server"
											Text='<%# Bind("IDStatus") %>' Visible="False" Width="30px" CssClass="txtinputs"></asp:TextBox>
								</td>
								<td align="right" height="1" style="width: 80px">
									<asp:Label ID="lblState" runat="server" CssClass="MainfontStyle" Text="State"></asp:Label>
								</td>
								<td align="left" height="1" style="width: 210px">
									<asp:DropDownList ID="ddlState" runat="server" DataSourceID="odsStates" DataTextField="SubCode"
										DataValueField="SubCode" CssClass="inputs" Width="205px" Enabled="False" TabIndex="12">
									</asp:DropDownList>
									<asp:TextBox ID="txtState" runat="server" CssClass="txtinputs" ReadOnly="True" TabIndex="13"
										Text='<%# Bind("State") %>'></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td align="right" style="width: 130px; height: 8px;">
									<asp:Label ID="lblWebSite" runat="server" CssClass="MainfontStyle" Text="Web Site"></asp:Label>
								</td>
								<td align="left" style="width: 210px; height: 8px;">
									<asp:TextBox ID="txtboxWebsite" runat="server" CssClass="txtinputs" Text='<%# Bind("WebSite") %>'
										ReadOnly="True" TabIndex="4"></asp:TextBox><asp:Label ID="lblErrSymWebSite" runat="server"
											CssClass="MainfontStyle" Font-Bold="True" ForeColor="Red" Text="*" Visible="False"></asp:Label>
								</td>
								<td align="right" style="width: 80px; height: 8px;">
									<asp:Label ID="lblProfile" runat="server" CssClass="MainfontStyle" Text="Profile"></asp:Label>
								</td>
								<td align="left" style="width: 210px;" rowspan="2">
									<asp:TextBox ID="txtProfile" runat="server" CssClass="txtinputs" Height="34px" ReadOnly="True"
										TabIndex="13" Text='<%# Bind("Profile") %>' TextMode="MultiLine" Width="200px"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td align="right" style="width: 130px; height: 8px">
								</td>
								<td align="left" style="width: 210px; height: 8px">
									&nbsp;<asp:HyperLink ID="hlWebSite" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "WebSite") %>'
										Target="_blank" Text='<%# Bind("WebSite") %>' Font-Names="Arial" Font-Size="12px"></asp:HyperLink>
								</td>
								<td align="right" style="width: 80px; height: 8px">
								</td>
							</tr>
							<tr>
								<td align="right" style="height: 0px" valign="top">
									<asp:Label ID="Label24" runat="server" CssClass="MainfontStyle" Font-Bold="True"
										Text="E-mail"></asp:Label>
								</td>
								<td colspan="1" align="left" style="height: 0px" valign="top">
									<asp:TextBox ID="txtEmailEdit" Text='<%# Bind("Email") %>' runat="server" CssClass="inputs"
										ReadOnly="True" Width="200px"></asp:TextBox>
									<asp:Label ID="lblEmailSym" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small"
										ForeColor="Red" Visible="False">*</asp:Label><br />
									<asp:HyperLink ID="hlEmail" runat="server" NavigateUrl='<%# "mailto:"+DataBinder.Eval(Container.DataItem, "Email") %>'
										Text='<%# Bind("Email") %>'></asp:HyperLink>
								</td>
								<td align="right" style="width: 80px; height: 8px;">
									<asp:Label ID="Label2" runat="server" CssClass="MainfontStyle" Text="Top Account"></asp:Label>
								</td>
								<td align="left" style="width: 120px; height: 8px;">
									<asp:CheckBox ID="cbxTop" runat="server" Enabled="false" Checked='<%# Bind("TopAccount") %>' />
								</td>
							</tr>
							<tr>
								<td align="center" colspan="4" height="1">
									<table cellpadding="0" cellspacing="0" style="width: 139px">
										<tr>
											<td height="1" style="width: 139px">
												<asp:Label ID="lblErrValidAccName" runat="server" CssClass="MainfontStyle" ForeColor="Red"
													Visible="False"></asp:Label>
											</td>
										</tr>
										<tr>
											<td height="1" style="width: 139px">
												<asp:Label ID="lblErrValidPhone" runat="server" CssClass="MainfontStyle" ForeColor="Red"
													Visible="False"></asp:Label>
											</td>
										</tr>
										<tr>
											<td style="width: 139px; height: 1px;">
												<asp:Label ID="lblErrValidZipCode" runat="server" CssClass="MainfontStyle" ForeColor="Red"
													Visible="False"></asp:Label>
											</td>
										</tr>
										<tr>
											<td height="1" style="width: 139px">
												<asp:Label ID="lblErrValidWebSite" runat="server" CssClass="MainfontStyle" ForeColor="Red"
													Visible="False"></asp:Label>
											</td>
										</tr>
										<tr>
											<td height="1" style="width: 139px">
												<asp:Label ID="lblErrValidEmail" runat="server" CssClass="MainfontStyle" ForeColor="Red"
													Visible="False"></asp:Label>
											</td>
										</tr>
										<tr>
											<td height="1" style="width: 139px">
												<asp:Label ID="lblErrValidPhoneNo" runat="server" CssClass="MainfontStyle" ForeColor="Red"
													Visible="False"></asp:Label>
											</td>
										</tr>
										<tr>
											<td height="1" style="width: 139px">
												<asp:Label ID="lblErrValidZipNo" runat="server" CssClass="MainfontStyle" ForeColor="Red"
													Visible="False"></asp:Label>
											</td>
										</tr>
										<tr>
											<td height="1" style="width: 139px">
												<asp:Label ID="lblErrValidFax" runat="server" CssClass="MainfontStyle" ForeColor="Red"
													Visible="False"></asp:Label>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<table border="1" bordercolor="white" cellpadding="0" cellspacing="0" style="width: 70%">
							<tr>
								<td align="left" background="Images/accountDetails_35.jpg" colspan="3" valign="middle"
									style="height: 30px">
									<table cellpadding="0" cellspacing="0" style="width: 826px">
										<tr>
											<td style="width: 130px; height: 19px;" align="right">
												<asp:Label ID="lblAccountMan" runat="server" CssClass="WhitefontStyle" Text="Account Manager"></asp:Label>
											</td>
											<td style="width: 161px; height: 19px;">
												<asp:UpdatePanel ID="UpdatePanel3" runat="server">
													<ContentTemplate>
														<asp:DropDownList ID="ddlAccountMan" runat="server" CssClass="listbox" Width="154px"
															DataSourceID="odsAccMngr" DataTextField="UserName" DataValueField="UserID" OnSelectedIndexChanged="ddlAccountMan_SelectedIndexChanged"
															OnDataBound="ddlAccountMan_DataBound" Enabled="False" AutoPostBack="True">
														</asp:DropDownList>
													</ContentTemplate>
												</asp:UpdatePanel>
												<asp:TextBox ID="txtAccMngr" runat="server" CssClass="inputs" Text='<%# Bind("AccountManagerID") %>'
													Width="32px" Visible="False"></asp:TextBox>
											</td>
											<td style="width: 60px; height: 19px;" align="right">
												<asp:Label ID="lblDate" runat="server" CssClass="WhitefontStyle" Text="Date"></asp:Label>
											</td>
											<td style="width: 84px; height: 19px;">
												<asp:TextBox ID="txtboxCurrentDate" runat="server" CssClass="inputs" ReadOnly="True"
													Width="97px" Text='<%# Bind("AccountManagerAssignedDate") %>'></asp:TextBox>
											</td>
											<td align="right" style="width: 70px; height: 19px;">
												<asp:Label ID="lblEditedby" runat="server" CssClass="WhitefontStyle" Text="Edited By"></asp:Label>
											</td>
											<td style="width: 103px; height: 19px;">
												<asp:TextBox ID="txtboxEditby" runat="server" CssClass="inputs" ReadOnly="True" Width="97px"
													Text='<%# Bind("AccountManagerEditByName") %>'></asp:TextBox>
											</td>
											<td align="right" style="width: 35px; height: 19px;">
												<asp:Label ID="lblDate2" runat="server" CssClass="WhitefontStyle" Text="Date"></asp:Label>
											</td>
											<td style="width: 103px; height: 19px;">
												<asp:TextBox ID="txtboxCurrentDate2" runat="server" CssClass="inputs" ReadOnly="True"
													Width="97px" Text='<%# Bind("AccountManagerEditDate") %>'></asp:TextBox>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</ItemTemplate>
				</asp:FormView>
				<asp:ObjectDataSource ID="odsAccountsDetails" runat="server" SelectMethod="SelectAccounts"
					TypeName="Office.BLL.AccountListsBLL" DataObjectTypeName="System.Web.UI.WebControls.GridView"
					OldValuesParameterFormatString="original_{0}">
					<SelectParameters>
						<asp:SessionParameter Name="CurrentAccount" SessionField="Account" Type="Object" />
					</SelectParameters>
				</asp:ObjectDataSource>
				<asp:ObjectDataSource ID="odsCountries" runat="server" OldValuesParameterFormatString="original_{0}"
					SelectMethod="GetSubCodeList" TypeName="Office.BLL.AccountListsBLL">
					<SelectParameters>
						<asp:Parameter DefaultValue="Country" Name="CurrentGCode" Type="String" />
					</SelectParameters>
				</asp:ObjectDataSource>
				<asp:ObjectDataSource ID="odsBusSector" runat="server" OldValuesParameterFormatString="original_{0}"
					SelectMethod="GetSubCodeList" TypeName="Office.BLL.AccountListsBLL">
					<SelectParameters>
						<asp:Parameter DefaultValue="BusinessSector" Name="CurrentGCode" Type="String" />
					</SelectParameters>
				</asp:ObjectDataSource>
				<asp:ObjectDataSource ID="odsStatus" runat="server" OldValuesParameterFormatString="original_{0}"
					SelectMethod="GetSubCodeList" TypeName="Office.BLL.AccountListsBLL">
					<SelectParameters>
						<asp:Parameter DefaultValue="Status" Name="CurrentGCode" Type="String" />
					</SelectParameters>
				</asp:ObjectDataSource>
				<asp:ObjectDataSource ID="odsAccMngr" runat="server" OldValuesParameterFormatString="original_{0}"
					SelectMethod="GetAccountManagers" TypeName="Office.BLL.AccountListsBLL"></asp:ObjectDataSource>
				<asp:ObjectDataSource ID="odsStates" runat="server" OldValuesParameterFormatString="original_{0}"
					SelectMethod="GetSubCodeList" TypeName="Office.BLL.AccountListsBLL">
					<SelectParameters>
						<asp:Parameter DefaultValue="state" Name="CurrentGCode" Type="String" />
					</SelectParameters>
				</asp:ObjectDataSource>
				<asp:ObjectDataSource ID="odsParents" runat="server" OldValuesParameterFormatString="original_{0}"
					SelectMethod="GetAccountList" TypeName="Office.BLL.ContactListsBLL">
					<SelectParameters>
						<asp:Parameter Name="BusSector" Type="String" DefaultValue="All" />
					</SelectParameters>
				</asp:ObjectDataSource>
				<asp:Label ID="lblEmptyResults" runat="server" Font-Bold="False" Font-Names="Tahoma"
					Font-Size="Large" ForeColor="Blue" Text="No results found"></asp:Label>
				<br />
				<asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
				<asp:Button ID="btnAddEditNotes" runat="server" Height="0px" OnClick="btnAddEditNotes_Click"
					Text="AddEditNotes" Width="0px" />&nbsp;
			</ContentTemplate>
		</asp:UpdatePanel>
		<div id="divTabs" align="left" style="width: 90%">
			<asp:Panel ID="Panel1" runat="server" Width="100%">
				<ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" ScrollBars="Auto"
					Height="350px" Width="100%" CssClass="">
					<ajaxToolkit:TabPanel ID="TabPanel5" runat="server" Width="100%">
						<HeaderTemplate>
							<asp:UpdatePanel ID="UpdatePanelHistory" runat="server">
								<ContentTemplate>
									<asp:ImageButton ID="imgbtnHistory" runat="server" AlternateText="History" ImageUrl="~/Images/History-n.png"
										OnClick="imgbtnHistory_Click" />
								</ContentTemplate>
							</asp:UpdatePanel>
						</HeaderTemplate>
						<ContentTemplate>
							<div align="center" style="background-color: White;">
								<asp:UpdatePanel ID="UpdatePanel14" runat="server">
									<ContentTemplate>
										<div align="center" style="font-weight: bold; font-size: 12px; font-family: Tahoma;">
											<asp:UpdatePanel ID="UpdatePanel15" runat="server">
												<ContentTemplate>
													<div align="center" style="text-align: center">
														<!-- from here -->
														<uc7:HistoryNC ID="HistoryNC1" runat="server" />
													</div>
												</ContentTemplate>
											</asp:UpdatePanel>
										</div>
									</ContentTemplate>
								</asp:UpdatePanel>
							</div>
						</ContentTemplate>
					</ajaxToolkit:TabPanel>
					<ajaxToolkit:TabPanel ID="TabPanel1" runat="server" Width="100%">
						<HeaderTemplate>
							<asp:UpdatePanel ID="UpdatePanel7" runat="server">
								<ContentTemplate>
									<asp:ImageButton ID="imgNotesTab" runat="server" ImageUrl="~/Images/notes_normal.png"
										AlternateText="Notes" OnClick="imgNotesTab_Click" />
								</ContentTemplate>
							</asp:UpdatePanel>
						</HeaderTemplate>
						<ContentTemplate>
							<div align="center" style="background-color: White;">
								<div style="font-weight: bold; font-size: 12px; color: white; font-family: Tahoma;">
									<div style="vertical-align: bottom; width: 100%; background-color: black">
										Filter Date:
										<asp:TextBox ID="txtCalender" runat="server" AutoPostBack="True" CssClass="inputs"
											OnTextChanged="txtCalender_TextChanged" Width="80px" />
										<img id="imgCalender" runat="server" alt="Pick a Date" class="HandOverCursor" src="Images/Calender.gif"
											style="vertical-align: middle" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										&nbsp;
										<img id="imgAddEditNotes" runat="server" alt="Add or Edit Notes" class="HandOverCursor"
											onclick="AddEdit_Note();src='Images/addorEditnotes_selected.png';" onmouseout="src='Images/addorEditnotes.gif'"
											onmouseover="src='Images/addorEditnotes_over.png'" src="Images/addorEditnotes.gif"
											style="vertical-align: middle" />
										&nbsp;&nbsp;
										<hr />
										Search Note:
										<asp:TextBox ID="txtSearchNote" runat="server" CssClass="inputs" />
										<img id="imgSearchNote" runat="server" alt="Search Notes" class="HandOverCursor"
											onclick="Search_Notes();src='Images/accountDetails_select_26.jpg';" onmouseout="src='Images/accountDetails_26.jpg'"
											onmouseover="src='Images/accountDetails_over_26.jpg'" src="Images/accountDetails_26.jpg"
											style="vertical-align: middle" />
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
										<asp:Button ID="btnSearchNote" runat="server" Height="0px" OnClick="btnSearchNote_Click"
											Text="Search" Width="0px" />
										&nbsp; Filter Contact:
										<asp:TextBox ID="txtSearchContact" runat="server" CssClass="inputs" />
										<img id="imgSearchNoteContact" runat="server" alt="Search Notes by Contact" class="HandOverCursor"
											onclick="Search_Notes_Contact();src='Images/accountDetails_select_26.jpg';" onmouseout="src='Images/accountDetails_26.jpg'"
											onmouseover="src='Images/accountDetails_over_26.jpg'" src="Images/accountDetails_26.jpg"
											style="vertical-align: middle" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:Button ID="btnSearchNoteContact" runat="server" Height="0px" OnClick="btnSearchNoteContact_Click"
											Text="Search" Width="0px" />
										<ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender11" runat="server" BehaviorID="autoCompleteBehavior11"
											CompletionInterval="10" CompletionSetCount="20" DelimiterCharacters=";," FirstRowSelected="True"
											MinimumPrefixLength="1" OnClientItemSelected="SubmitContactNoteResult" ServiceMethod="GetContactList"
											TargetControlID="txtSearchContact" UseContextKey="True" Enabled="True" ServicePath="">
										</ajaxToolkit:AutoCompleteExtender>
									</div>
									<div style="overflow: hidden; width: 100%; height: 5px">
									</div>
									<asp:UpdatePanel ID="UpdatePanel3" runat="server">
										<ContentTemplate>
											<div align="center" style="background-color: #dfdfdf; border-right: black thin solid;
												border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid;
												height: 400px;">
												<div align="center" style="width: 652px; background-color: black; color: White; height: 20px;">
													<strong style="font-weight: bold; font-size: 12px; color: white; font-family: Tahoma">
														Note Entry and Edit</strong></div>
												<div style="width: 300px;">
													<img id="Img4" alt="Add New Note" class="HandOverCursor" onclick="Add_Note();" onmouseout="src='Images/add.jpg'"
														onmouseover="src='Images/orange_mouseover_29.gif'" src="Images/add.jpg" /><img id="Img5"
															alt="Save Note" class="HandOverCursor" onclick="Save_Note();" onmouseout="src='Images/save.jpg'"
															onmouseover="src='Images/orange_mouseover_11.gif'" src="Images/save.jpg" /><img id="Img6"
																alt="Cancel" class="HandOverCursor" onclick="Cancel_Note();" onmouseout="src='Images/cancel_normal.png'"
																onmouseover="src='Images/cancel_selected.gif'" src="Images/cancel_normal.png" /></div>
												<div align="center">
													<div style="width: 652px">
														<div align="right" style="height: 23px; width: 100px; float: left; font-weight: bold;
															font-size: 12px; color: black; font-family: Tahoma;">
															<asp:Label ID="lblEnteredDate" runat="server" Visible="false" Text="Entered:"></asp:Label>&#160;</div>
														<div style="width: 110px; float: left;">
															<asp:TextBox ID="txtEnteredDate" runat="server" CssClass="inputs" ReadOnly="True"
																Width="100%" Visible="false"></asp:TextBox></div>
														<div align="right" style="height: 23px; width: 100px; float: left; font-weight: bold;
															font-size: 12px; color: black; font-family: Tahoma;">
															<asp:Label ID="lblEnteredTime" runat="server" Visible="false" Text="Time:"></asp:Label>&#160;</div>
														<div style="width: 110px; float: left;">
															<asp:TextBox ID="txtEnteredTime" runat="server" CssClass="inputs" ReadOnly="True"
																Width="100%" Visible="false"></asp:TextBox></div>
														<div align="right" style="height: 23px; width: 100px; float: left; font-weight: bold;
															font-size: 12px; color: black; font-family: Tahoma;">
															<asp:Label ID="lblEnteredBy" runat="server" Visible="false" Text="By:"></asp:Label>&#160;</div>
														<div style="width: 110px; float: left;">
															<asp:TextBox ID="txtEnteredBy" runat="server" CssClass="inputs" ReadOnly="True" Width="100%"
																Visible="false"></asp:TextBox></div>
													</div>
													<div style="width: 652px">
														<div align="right" style="height: 23px; width: 100px; float: left; font-weight: bold;
															font-size: 12px; color: black; font-family: Tahoma;">
															<asp:Label ID="lblEditDate" runat="server" Text="Edit:" Visible="false"></asp:Label>&#160;</div>
														<div style="width: 110px; float: left;">
															<asp:TextBox ID="txtEditDate" runat="server" CssClass="inputs" ReadOnly="True" Width="100%"
																Visible="false"></asp:TextBox></div>
														<div align="right" style="height: 23px; width: 100px; float: left; font-weight: bold;
															font-size: 12px; color: black; font-family: Tahoma;">
															<asp:Label ID="lblEditTime" runat="server" Text="Time:" Visible="false"></asp:Label>&#160;</div>
														<div style="width: 110px; float: left;">
															<asp:TextBox ID="txtEditTime" runat="server" CssClass="inputs" ReadOnly="True" Width="100%"
																Visible="false"></asp:TextBox></div>
														<div align="right" style="height: 23px; width: 100px; float: left; font-weight: bold;
															font-size: 12px; color: black; font-family: Tahoma;">
															<asp:Label ID="lblEditBy" runat="server" Text="By:" Visible="false"></asp:Label>&#160;</div>
														<div style="width: 110px; float: left;">
															<asp:TextBox ID="txtEditBy" runat="server" CssClass="inputs" ReadOnly="True" Width="100%"
																Visible="false"></asp:TextBox></div>
													</div>
													<div align="center" style="width: 652px">
														<div style="width: 652px">
															&#160; &#160; &#160; &#160; &#160;<asp:Label ID="lblContact" runat="server" ForeColor="Black"
																Text="Contact:" Visible="false"></asp:Label><asp:TextBox ID="txtContact" runat="server"
																	CssClass="inputs" ReadOnly="True" Width="110px" Visible="false"></asp:TextBox></div>
														<div style="width: 652px">
															<table cellpadding="0" cellspacing="0" style="color: black; width: 429px;">
																<tr>
																	<td align="right" style="width: 89px; height: 18px">
																		<asp:Label ID="Label3" runat="server" Text="Note Date:" Width="75px"></asp:Label>
																	</td>
																	<td align="left" style="width: 27px; height: 18px">
																		<asp:TextBox ID="txtUserNoteDate" runat="server" Width="110px"></asp:TextBox>
																	</td>
																	<td align="left" style="width: 95px; height: 18px">
																		<img id="imgNoteDate" runat="server" alt="Pick a Date" class="HandOverCursor" src="Images/Calender.gif"
																			style="vertical-align: middle" />
																	</td>
																	<td>
																		<asp:Label ID="Label5" runat="server" Text="Note Time:" Width="70px"></asp:Label>
																	</td>
																	<td align="left" style="height: 18px">
																		<asp:TextBox ID="txtHours" runat="server" Width="20px"></asp:TextBox>:<asp:TextBox
																			ID="txtMin" runat="server" Width="20px"></asp:TextBox>
																	</td>
																	<td align="left" style="width: 84px; height: 18px">
																		<asp:DropDownList ID="ddlTime" runat="server">
																			<asp:ListItem Selected="True">AM</asp:ListItem>
																			<asp:ListItem>PM</asp:ListItem>
																		</asp:DropDownList>
																	</td>
																</tr>
															</table>
															&#160;&#160;</div>
														<asp:Button ID="btnNew" runat="server" Height="0px" OnClick="btnNew_Click" Text="New"
															UseSubmitBehavior="False" Width="0px" /><asp:Button ID="btnEdit" runat="server" Height="0px"
																Text="Edit" UseSubmitBehavior="False" Width="0px" /><asp:Button ID="btnSave" runat="server"
																	Height="0px" OnClick="btnSave_Click" Text="Save" UseSubmitBehavior="False" Width="0px" />&#160;
														<asp:Button ID="btnCancel" runat="server" Height="0px" OnClick="btnCancel_Click"
															Text="Cancel" UseSubmitBehavior="False" Width="0px" /><asp:RangeValidator ID="RangeValidator1"
																runat="server" ControlToValidate="txtHours" ErrorMessage="Hours value must be (1~12)"
																MaximumValue="12" MinimumValue="1" SetFocusOnError="True" Type="Integer"></asp:RangeValidator><asp:RangeValidator
																	ID="RangeValidator2" runat="server" ControlToValidate="txtMin" ErrorMessage="Minutes value must be (0~59)"
																	MaximumValue="59" MinimumValue="0" SetFocusOnError="True" Type="Integer"></asp:RangeValidator></div>
													<div align="center" style="width: 652px">
														<FCKeditorV2:FCKeditor ID="txtNote" runat="server" BasePath="fckeditor/" Height="220px"
															ToolbarSet="MyToolbar" Width="600px">
														</FCKeditorV2:FCKeditor>
														<%--<FTB:FreeTextBox id="txtNote" runat="Server" BackColor="223, 223, 223" ButtonSet="Office2000" 
                                                                        GutterBackColor="213, 213, 213" ToolbarBackColor="223, 223, 223" ToolbarBackgroundImage="True" 
                                                                        UseToolbarBackGroundImage="True" Height="150px" Width="500px" />--%></div>
												</div>
											</div>
											<ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="imgNoteDate"
												TargetControlID="txtUserNoteDate">
											</ajaxToolkit:CalendarExtender>
											<ajaxToolkit:NumericUpDownExtender ID="NumericUpDownExtender1" runat="server" Maximum="12"
												Minimum="1" RefValues="" ServiceDownMethod="" ServiceUpMethod="" TargetButtonDownID=""
												TargetButtonUpID="" TargetControlID="txtHours" Width="45" />
											<ajaxToolkit:NumericUpDownExtender ID="NumericUpDownExtender2" runat="server" Maximum="59"
												Minimum="0" RefValues="" ServiceDownMethod="" ServiceUpMethod="" TargetButtonDownID=""
												TargetButtonUpID="" TargetControlID="txtMin" Width="45" />
											<asp:HiddenField ID="hdnNote" runat="server" />
										</ContentTemplate>
									</asp:UpdatePanel>
									<ajaxToolkit:PopupControlExtender ID="PopupControlExtender1" runat="server" OffsetX="-350"
										OffsetY="-200" PopupControlID="UpdatePanel3" Position="Bottom" TargetControlID="imgAddEditNotes"
										DynamicServicePath="" Enabled="True" ExtenderControlID="">
									</ajaxToolkit:PopupControlExtender>
									<ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="imgCalender"
										PopupPosition="BottomRight" TargetControlID="txtCalender" Enabled="True">
									</ajaxToolkit:CalendarExtender>
								</div>
								<asp:UpdatePanel ID="upNote" runat="server">
									<ContentTemplate>
										<asp:GridView ID="gvNotes" runat="server" AllowPaging="True" AllowSorting="True"
											AutoGenerateColumns="False" CellPadding="4" DataKeyNames="NID" ForeColor="#333333"
											GridLines="None" OnPageIndexChanging="gvNotes_PageIndexChanging" OnRowCreated="gvNotes_RowCreated"
											OnRowDataBound="gvNotes_RowDataBound" OnRowDeleting="gvNotes_RowDeleting" OnSelectedIndexChanged="gvNotes_SelectedIndexChanged"
											OnSorting="gvNotes_Sorting" PageSize="20" Width="100%">
											<PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
											<FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
											<RowStyle BackColor="White" CssClass="GridNormalRowsStyle" ForeColor="#333333" HorizontalAlign="Left" />
											<Columns>
												<asp:BoundField DataField="NoteDateStr" HeaderText="Date" NullDisplayText=" " SortExpression="UserEnterDate">
													<HeaderStyle Width="40px" />
												</asp:BoundField>
												<asp:BoundField DataField="NoteTimeStr" HeaderText="Time" NullDisplayText=" ">
													<ItemStyle Wrap="False" />
													<HeaderStyle Width="80px" Wrap="False" />
												</asp:BoundField>
												<asp:TemplateField HeaderText="Regarding">
													<ItemTemplate>
														<div style="width: 400px;">
															<asp:Label ID="Label1" runat="server" Text='<%# Bind("Notes") %>'></asp:Label></div>
													</ItemTemplate>
													<ItemStyle Width="400px" Wrap="True" />
												</asp:TemplateField>
												<asp:BoundField DataField="EditByName" HeaderText="Edited By" NullDisplayText=" ">
													<HeaderStyle Wrap="False" />
												</asp:BoundField>
												<asp:BoundField DataField="EditDateStr" HeaderText="Edit Date" NullDisplayText=" ">
													<HeaderStyle Width="58px" />
												</asp:BoundField>
												<asp:BoundField DataField="BranchName" HeaderText="Branch" NullDisplayText=" ">
													<HeaderStyle Width="40px" />
												</asp:BoundField>
												<asp:BoundField DataField="ContactFirstName" HeaderText="Contact" NullDisplayText=" ">
													<HeaderStyle Width="40px" />
												</asp:BoundField>
												<asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True">
													<HeaderStyle Width="40px" />
												</asp:CommandField>
											</Columns>
											<PagerStyle BackColor="#FFCC66" CssClass="GridPagerStyle" ForeColor="#333333" HorizontalAlign="Center" />
											<SelectedRowStyle BackColor="#FFCC66" CssClass="SelectedRowColor" Font-Bold="True" />
											<HeaderStyle BackColor="#990000" CssClass="GridHeaderBackStyle" Font-Bold="True"
												Font-Names="Tahoma" Font-Size="12px" ForeColor="White" Height="20px" />
										</asp:GridView>
										<asp:ObjectDataSource ID="odsNotes" runat="server" OldValuesParameterFormatString="original_{0}"
											SelectMethod="GetContactNotes" TypeName="Office.BLL.AccountListsBLL">
											<SelectParameters>
												<asp:SessionParameter Name="CurrentNote" SessionField="CurrentNote" Type="Object" />
											</SelectParameters>
										</asp:ObjectDataSource>
									</ContentTemplate>
								</asp:UpdatePanel>
							</div>
						</ContentTemplate>
					</ajaxToolkit:TabPanel>
					<ajaxToolkit:TabPanel ID="TabPanel2" runat="server" Width="100%">
						<HeaderTemplate>
							<asp:UpdatePanel ID="UpdatePanel8" runat="server">
								<ContentTemplate>
									<asp:ImageButton ID="imgContactsTab" runat="server" ImageUrl="~/Images/contacts_normal.png"
										AlternateText="Contacts" OnClick="imgContactsTab_Click" />
								</ContentTemplate>
							</asp:UpdatePanel>
						</HeaderTemplate>
						<ContentTemplate>
							<div align="center" style="background-color: white">
								<asp:UpdatePanel ID="upContact" runat="server">
									<ContentTemplate>
										<%--<div style="font-weight: bold; font-size: 12px; color: white; font-family: Tahoma;">
                                                    <div style="vertical-align: bottom; width: 96%; background-color: black;">
                                                        <asp:Button ID="btnAddContact" runat="server" CssClass="button" OnClick="btnAddContact_Click"
                                                            Text="Add Contact" /></div>
                                                </div>
                                                <asp:GridView ID="gvContacts" runat="server" AllowPaging="True" AllowSorting="True"
                                                    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ContactID" GridLines="None"
                                                    OnRowCreated="gvContacts_RowCreated" OnSelectedIndexChanged="gvContacts_SelectedIndexChanged"
                                                    OnSorting="gvContacts_Sorting" PageSize="20" Width="800px">
                                                    <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                                                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="White" CssClass="GridNormalRowsStyle" ForeColor="#333333" HorizontalAlign="Left" />
                                                    <Columns>
                                                        <asp:BoundField DataField="FirstName" HeaderText="FirstName" NullDisplayText=" "
                                                            SortExpression="FirstName" />
                                                        <asp:BoundField DataField="LastName" HeaderText="LastName" NullDisplayText=" " />
                                                        <asp:BoundField DataField="Phone" HeaderText="Phone" NullDisplayText=" " SortExpression="Phone" />
                                                        <asp:BoundField DataField="Ext" HeaderText="Ext" NullDisplayText=" " />
                                                        <asp:BoundField DataField="TitleName" HeaderText="Title" NullDisplayText=" " SortExpression="TitleName" />
                                                        <asp:BoundField DataField="Email" HeaderText="Email" NullDisplayText=" " />
                                                        <asp:BoundField DataField="EditByName" HeaderText="Edited By" NullDisplayText=" " />
                                                    </Columns>
                                                    <PagerStyle BackColor="#FFCC66" CssClass="GridPagerStyle" ForeColor="#333333" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#33CCCC" CssClass="SelectedRowColor" Font-Bold="True"
                                                        ForeColor="Black" />
                                                    <HeaderStyle BackColor="#990000" CssClass="GridHeaderBackStyle" Font-Bold="True"
                                                        Font-Names="Tahoma" Font-Size="12px" ForeColor="White" Height="20px" />
                                                </asp:GridView>
                                                <asp:ObjectDataSource ID="odsContacts" runat="server" OldValuesParameterFormatString="original_{0}"
                                                    SelectMethod="GetAccountContacts" TypeName="Office.BLL.AccountListsBLL">
                                                    <SelectParameters>
                                                        <asp:SessionParameter Name="CurrentContact" SessionField="CurrentContact" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>--%>
										<ucC:Contacts ID="Contacts1" runat="server" />
									</ContentTemplate>
								</asp:UpdatePanel>
							</div>
						</ContentTemplate>
					</ajaxToolkit:TabPanel>
					<ajaxToolkit:TabPanel ID="TabPanel3" runat="server" Width="100%">
						<HeaderTemplate>
							<asp:UpdatePanel ID="UpdatePanelSubCompanies" runat="server">
								<ContentTemplate>
									<asp:ImageButton ID="imgbtnSubCompanies" runat="server" AlternateText="Sub Companies"
										ImageUrl="~/Images/SubCompanies-n.png" OnClick="imgSubCompaniesTab_Click" />
								</ContentTemplate>
							</asp:UpdatePanel>
						</HeaderTemplate>
						<ContentTemplate>
							<div align="center" style="background-color: White;">
								<asp:UpdatePanel ID="upSubCompanies" runat="server">
									<ContentTemplate>
										<div align="center" style="font-weight: bold; font-size: 12px; font-family: Tahoma;">
											<asp:UpdatePanel ID="UpdatePanel10" runat="server">
												<ContentTemplate>
													<div align="center" style="text-align: center">
														<%--Call popup--%>
														<%--<asp:Button ID="btnNewSubCompany1" runat="server" Height="0" Text="Add SubCompany"
                                                                    Width="0" />
                                                                <img id="img1" runat="server" alt="Add SubCompany" class="HandOverCursor" onclick="Add_SubCompany();src='Images/AddSubCompany_selected.jpg';"
                                                                    onmouseout="src='Images/AddSubCompany.jpg'" onmouseover="src='Images/AddSubCompany_over.jpg'"
                                                                    src="Images/AddSubCompany.jpg" style="vertical-align: middle" />
                                                                <asp:Button ID="btnNewSubCompany" runat="server" Height="0px" OnClick="btnNewSubCompany_Click"
                                                                        Text="Add SubCompany" Width="0" />--%>
														<asp:ImageButton ID="btnNewSubCompany" runat="server" AlternateText="Add SubCompany"
															ImageUrl="~/Images/AddSubCompany_n.png" OnClick="btnNewSubCompany_Click" />
														<%--popup--%>
														<ajaxToolkit:ModalPopupExtender ID="mdlPopup" runat="server" BackgroundCssClass="modalBackground"
															CancelControlID="imgBtnCancel" DropShadow="false" PopupControlID="pnlSubCompany"
															TargetControlID="imgBtnNew">
														</ajaxToolkit:ModalPopupExtender>
														<!-- from here - Buttons: New, Save and Cancel -->
														<asp:Panel ID="pnlSubCompany" runat="server" CssClass="modalPopup" Style="display: none">
															<div>
																<asp:ImageButton ID="imgBtnNew" runat="server" ImageUrl="~/Images/add.jpg" Width="0px" />
																<asp:ImageButton ID="imgBtnSave" runat="server" ImageUrl="~/Images/save.jpg" OnClick="imgBtnSave_Click" />
																<asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/Images/cancel_normal.png" /></div>
															<asp:UpdatePanel ID="upSubCompany1" runat="server" UpdateMode="Conditional">
																<ContentTemplate>
																	<table border="0" cellpadding="0" cellspacing="0">
																		<tr height="30px">
																			<td>
																				<asp:Label ID="lblCompanyName" runat="server" CssClass="MainfontStyle" Text="Company Name"></asp:Label><br />
																			</td>
																			<td>
																				<asp:DropDownList ID="ddlCompanyName" runat="server" Width="205px" CssClass="inputs"
																					DataTextField="AccountName" DataValueField="AccountID">
																				</asp:DropDownList>
																				<asp:ObjectDataSource ID="odsAccountNames" runat="server" OldValuesParameterFormatString="original_{0}"
																					SelectMethod="GetSubAccountsNamesList" TypeName="Office.BLL.AccountListsBLL">
																					<SelectParameters>
																						<asp:Parameter DefaultValue="False" Name="All" Type="Boolean" />
																					</SelectParameters>
																				</asp:ObjectDataSource>
																			</td>
																		</tr>
																		<tr height="30px">
																			<td>
																				<asp:Label ID="LabelParent" runat="server" CssClass="MainfontStyle" Text="Parent Name"></asp:Label><br />
																			</td>
																			<td>
																				<asp:DropDownList ID="ddlParent" runat="server" Width="205px" CssClass="inputs" DataTextField="AccountName"
																					DataValueField="AccountID" DataSourceID="odsParentsNames">
																				</asp:DropDownList>
																				<asp:ObjectDataSource ID="odsParentsNames" runat="server" OldValuesParameterFormatString="original_{0}"
																					SelectMethod="GetSubAccountsNamesList" TypeName="Office.BLL.AccountListsBLL">
																					<SelectParameters>
																						<asp:Parameter DefaultValue="True" Name="All" Type="Boolean" />
																					</SelectParameters>
																				</asp:ObjectDataSource>
																			</td>
																		</tr>
																		<tr height="30px">
																			<td>
																				<asp:Label ID="LabelType" runat="server" CssClass="MainfontStyle" Text="Type"></asp:Label><br />
																			</td>
																			<td>
																				<asp:DropDownList ID="ddlHirarchyType" runat="server" Width="205px" CssClass="inputs"
																					DataTextField="SubCode" DataValueField="SubID" DataSourceID="odsHirarchyType">
																				</asp:DropDownList>
																				<asp:ObjectDataSource ID="odsHirarchyType" runat="server" OldValuesParameterFormatString="original_{0}"
																					SelectMethod="GetSubCodeList" TypeName="Office.BLL.AccountListsBLL">
																					<SelectParameters>
																						<asp:Parameter DefaultValue="HierarchyType" Name="CurrentGCode" Type="String" />
																					</SelectParameters>
																				</asp:ObjectDataSource>
																			</td>
																		</tr>
																		<tr>
																			<td>
																			</td>
																			<td>
																			</td>
																		</tr>
																	</table>
																</ContentTemplate>
															</asp:UpdatePanel>
														</asp:Panel>
													</div>
												</ContentTemplate>
											</asp:UpdatePanel>
										</div>
										<uc9:SubAccounts ID="SubAccounts1" runat="server"></uc9:SubAccounts>
									</ContentTemplate>
								</asp:UpdatePanel>
							</div>
						</ContentTemplate>
					</ajaxToolkit:TabPanel>
					<ajaxToolkit:TabPanel ID="TabPanel4" runat="server" Width="100%">
						<HeaderTemplate>
							<asp:UpdatePanel ID="UpdatePanelKeySoftware" runat="server">
								<ContentTemplate>
									<asp:ImageButton ID="imgbtnKeySoftware" runat="server" AlternateText="Keys" ImageUrl="~/Images/Keys-n.png"
										OnClick="imgbtnKeySoftware_Click" />
								</ContentTemplate>
							</asp:UpdatePanel>
						</HeaderTemplate>
						<ContentTemplate>
							<div align="center" style="background-color: White;">
								<asp:UpdatePanel ID="UpdatePanel11" runat="server">
									<ContentTemplate>
										<div align="center" style="font-weight: bold; font-size: 12px; font-family: Tahoma;">
											<uc6:Key ID="Key1" runat="server" />
										</div>
									</ContentTemplate>
								</asp:UpdatePanel>
							</div>
						</ContentTemplate>
					</ajaxToolkit:TabPanel>
					<ajaxToolkit:TabPanel ID="TabPanel6" runat="server" Width="100%">
						<HeaderTemplate>
							<asp:UpdatePanel ID="UpdatePanel6" runat="server">
								<ContentTemplate>
									<asp:ImageButton ID="imgbtnAttachments" runat="server" AlternateText="Attachments"
										ImageUrl="~/Images/Attachments-n.png" OnClick="imgbtnAttachments_Click" />
								</ContentTemplate>
							</asp:UpdatePanel>
						</HeaderTemplate>
						<ContentTemplate>
							<div align="center" style="background-color: White;">
								<div align="center" style="font-weight: bold; font-size: 12px; font-family: Tahoma;">
									<asp:UpdatePanel ID="UpdatePanel17" runat="server">
										<ContentTemplate>
											<div align="left" style="text-align: center">
												<uc8:Attachment ID="Attachment1" runat="server" />
											</div>
										</ContentTemplate>
									</asp:UpdatePanel>
								</div>
							</div>
						</ContentTemplate>
					</ajaxToolkit:TabPanel>
					<ajaxToolkit:TabPanel ID="TabPanel7" runat="server" Width="100%">
						<HeaderTemplate>
							<asp:UpdatePanel ID="UpdatePanel9" runat="server">
								<ContentTemplate>
									<asp:ImageButton ID="imgbtnDuediligence" runat="server" AlternateText="Due Diligence"
										ImageUrl="~/Images/DueDiligence-n.png" OnClick="imgbtnDuediligence_Click" />
								</ContentTemplate>
							</asp:UpdatePanel>
						</HeaderTemplate>
						<ContentTemplate>
							<div align="center" style="background-color: White;">
								<div align="center" style="font-weight: bold; font-size: 12px; font-family: Tahoma;">
									<asp:UpdatePanel ID="UpdatePanel12" runat="server">
										<ContentTemplate>
											<div align="left" style="text-align: center">
												<uc10:DueDiligance ID="DueDiligance1" runat="server" />
											</div>
										</ContentTemplate>
									</asp:UpdatePanel>
								</div>
							</div>
						</ContentTemplate>
					</ajaxToolkit:TabPanel>
				</ajaxToolkit:TabContainer>
			</asp:Panel>
		</div>
		<div>
			<asp:Label ID="Throbber" runat="server" Style="display: none"> <img src="Images/indicator.gif" align="middle" alt="loading" /></asp:Label>
			<br />
			<br />
			<asp:Label ID="lblStatus" runat="server" Style="font-family: Arial; font-size: small;"></asp:Label>
		</div>
	</div>
	<div class="footer">
	</div>
</asp:Content>
