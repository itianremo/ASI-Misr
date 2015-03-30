<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Theme="Red"
	Inherits="ASILogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>ASI Office Login</title>
	<link rel="SHORTCUT ICON" href="Images/favicon.ico" />
	<script type="text/javascript" src="Scripts/Scripts.js"></script>
	<script type="text/javascript" src="Scripts/jquery-1.8.2.min.js"></script>
	<script type="text/javascript">
		$(window).resize(function () {
			$('.floater2').css({
				position: 'absolute',
				left: ($(window).width() - $('.floater2').outerWidth()) / 2,
				top: ($(window).height() - $('.floater2').outerHeight()) / 2
			});
		});
		// To initially run the function:
		$(window).resize();

	</script>
</head>
<body dir="ltr" bgcolor="#dfdfdf" onload="placeFocus();">
	<form id="form1" runat="server">
	<div id="floater">
		<asp:Login ID="CRMLogin" CssClass="centered" runat="server" DestinationPageUrl="~/Home.aspx"
			DisplayRememberMe="False" InstructionText="ASI" LoginButtonImageUrl="~/Images/sign_normal.png"
			OnAuthenticate="CRMLogin_Authenticate" OnLoggingIn="CRMLogin_LoggingIn" Width="490"
			Height="300" BorderPadding="0">
			<LayoutTemplate>
				<table class="centered" style="border-collapse: collapse; border-spacing: 0; padding: 0;">
					<tr>
						<td style="vertical-align: bottom;">
							<table style="width: 100%; table-layout: fixed; height: 273; padding: 0; border-spacing: 0;">
								<colgroup>
									<col style="" />
									<col style="width: 140px;" />
								</colgroup>
								<tr>
									<td align="right">
										<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
									</td>
									<td>
										<asp:TextBox ID="UserName" runat="server" CssClass="inputs"></asp:TextBox>
										<asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
											ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="CRMLogin">*</asp:RequiredFieldValidator>
									</td>
								</tr>
								<tr>
									<td style="text-align: right;">
										<asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
									</td>
									<td>
										<asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="inputs"></asp:TextBox>
										<asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
											ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="CRMLogin">*</asp:RequiredFieldValidator>
									</td>
								</tr>
								<tr>
									<td style="text-align: center;">
										<asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
									</td>
									<td>
										<asp:LinkButton ID="LoginButton" runat="server" CssClass="SignIn" CommandName="Login"
											ValidationGroup="CRMLogin" />
									</td>
								</tr>
								<tr>
									<td colspan="2" style="height: 20;">
										&nbsp;
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr style="height: 27px; line-height: 27px; background: #000;">
						<td>
							<asp:Label ID="InstructionText" runat="server" ForeColor="White">ASI Office v1.0 Build #75 Sept-13-2011</asp:Label>
							<div style="float: right;">
								<asp:Label ID="Label1" runat="server" ForeColor="White" Text="© 2008 ASI E | All Rights Reserved" />
							</div>
						</td>
					</tr>
				</table>
			</LayoutTemplate>
		</asp:Login>
		<%--<br />
		<br />
		<br />
		<br />
		<br />
		<br />
		<br />
		<br />
		<table id="Table2" align="center" cellpadding="0" cellspacing="0" background="Images/loginbg.jpg"
			style="width: 490px; height: 290px">
			<tr>
				<td align="center" height="20">
				</td>
			</tr>
			<tr>
				<td>
					<div align="center">
						<table id="Table1" align="center" border="0" cellpadding="0" cellspacing="0" style="width: 423px;
							height: 157px">
							<tr>
								<td style="width: 104px">
								</td>
								<td style="width: 758px">
								</td>
								<td style="width: 132px">
								</td>
							</tr>
							<tr>
								<td style="width: 104px; height: 129px">
								</td>
								<td valign="bottom">
									<asp:Label ID="lblLoginError" runat="server" Font-Bold="True" ForeColor="White" Visible="False"
										Font-Names="Tahoma" Font-Size="12px"></asp:Label>
								</td>
								<td style="width: 132px; height: 129px">
								</td>
							</tr>
							<tr>
								<td style="width: 104px;">
								</td>
								<td style="width: 758px;" align="right">
									<asp:Label ID="lblUserName" runat="server" CssClass="UserLoginStyle">User Name</asp:Label>
								</td>
								<td align="right" style="width: 132px;">
									<asp:TextBox ID="txtUserName" runat="server" MaxLength="50" CssClass="inputs" TabIndex="1"></asp:TextBox><asp:TextBox
										ID="txtUserEmail" runat="server" CssClass="inputs" MaxLength="50" TabIndex="1"
										Visible="False"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td style="width: 104px">
								</td>
								<td align="right" style="width: 758px">
									<asp:Label ID="lblPassword" runat="server" CssClass="UserLoginStyle">Password</asp:Label>
								</td>
								<td align="right" style="width: 132px">
									<asp:TextBox ID="txtPassword" runat="server" MaxLength="20" TextMode="Password" CssClass="inputs"
										TabIndex="2"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td style="width: 104px">
								</td>
								<td style="width: 758px;">
								</td>
								<td style="width: 132px" align="center">
									<asp:LinkButton ID="lnkForgotPassword" runat="server" CssClass="UserForgotPWDStyle"
										OnClick="lnkForgotPassword_Click">Forgot Password?</asp:LinkButton><br />
									<asp:ImageButton ID="imgbtnSendPassword" runat="server" ImageUrl="~/Images/send_normal.gif"
										OnClick="imgbtnSendPassword_Click" Visible="False" />
								</td>
							</tr>
							<tr>
								<td valign="bottom" style="width: 104px; height: 30px;">
								</td>
								<td style="width: 758px; height: 30px;">
								</td>
								<td align="right" style="height: 30px" valign="bottom">
									<asp:ImageButton ID="btnLogin" runat="server" ImageUrl="~/Images/sign_normal.png"
										OnClick="btnLogin_Click" AlternateText="Sign In" TabIndex="3" /><asp:LinkButton ID="lnkbtnLogin"
											runat="server" CssClass="UserForgotPWDStyle" OnClick="lnkbtnLogin_Click" Visible="False">Login</asp:LinkButton>
								</td>
							</tr>
						</table>
					</div>
				</td>
			</tr>
			<tr>
				<td valign="middle" bgcolor="#000000">
					<table style="width: 100%;">
						<tr>
							<td>
								<asp:Label ID="lblVersionInfo" runat="server" BackColor="Transparent" BorderColor="Transparent"
									Font-Bold="True" CssClass="DarkfontStyle" Font-Names="Tahoma" ForeColor="White">ASI Office v1.0 Build #75 Sept-13-2011</asp:Label>
							</td>
							<td>
							</td>
							<td align="right">
								<asp:Label ID="Label1" runat="server" BackColor="Transparent" BorderColor="Transparent"
									CssClass="DarkfontStyle" Font-Names="Tahoma" ForeColor="White" Text="© 2008 ASI E | All Rights Reserved"></asp:Label>
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>--%>
	</div>
	</form>
</body>
</html>
