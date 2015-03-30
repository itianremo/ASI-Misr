<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="BMDUsers.aspx.cs" Inherits="BMDUsers" Title=":: MPM - BMD :: Users ::" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="Controls/TransButtons.ascx" TagName="TransButtons" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
    var scrollTop;
    var scrollTop1;
    var scrollTop2;
  
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler1);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler1);

    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler2);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler2);

      function BeginRequestHandler(sender, args) 
        {
          var elem = document.getElementById('ctl00_ContentPlaceHolder1_frmViewUsers_pnlBriks');
              if(elem!= null)
              scrollTop=elem.scrollTop;
        }

      function EndRequestHandler(sender, args)
       {
       var elem = document.getElementById('ctl00_ContentPlaceHolder1_frmViewUsers_pnlBriks');
            if(elem!= null)
           elem.scrollTop = scrollTop;
  
      }  
      
      ///
      function BeginRequestHandler1(sender, args) 
        {
          var elem = document.getElementById('ctl00_ContentPlaceHolder1_frmViewUsers_Panel1');
              if(elem!= null)
              scrollTop1=elem.scrollTop;
        }

      function EndRequestHandler1(sender, args)
       {
          var elem = document.getElementById('ctl00_ContentPlaceHolder1_frmViewUsers_Panel1');
            if(elem!= null)
            elem.scrollTop = scrollTop1;
  
      }  
      ///
      function BeginRequestHandler2(sender, args) 
        {
          var elem = document.getElementById('ctl00_ContentPlaceHolder1_frmViewUsers_pnlAssignedUsers');
              if(elem!= null)
              scrollTop2=elem.scrollTop;
        }

      function EndRequestHandler2(sender, args)
       {
          var elem = document.getElementById('ctl00_ContentPlaceHolder1_frmViewUsers_pnlAssignedUsers');
            if(elem!= null)
            elem.scrollTop = scrollTop2;
  
      }  
    
    </script>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <asp:FormView ID="frmViewUsers" runat="server" OnPageIndexChanging="frmViewUsers_PageIndexChanging"
                DataKeyNames="EmpID,TitleID" BorderWidth="1px" BorderStyle="Solid" BorderColor="DarkGray"
                BackImageUrl="~/Images/BG-1.jpg" AllowPaging="True" OnDataBound="frmViewUsers_DataBound" Width="100%" EmptyDataText="No Data Found">
                <PagerSettings FirstPageText="First"
                    LastPageText="Last" NextPageImageUrl="~/Images/next_n.jpg"
                    NextPageText="Next" PreviousPageImageUrl="~/Images/previous_n.jpg" PreviousPageText="Previous" Mode="NumericFirstLast">
                </PagerSettings>
                <ItemTemplate>
                    <table width="100%">
                        <tbody>
                            <tr>
                                <td align="center" colspan="3" rowspan="3">
                                    <table style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td align="center" colspan="3" rowspan="1">
                                                    <div class="tblStyle">
                                                        <table style="z-index: 1; position:relative; width: 50%; height: 30px" id="tblsearch">
                                                            <tbody>
                                                                <tr align="center" width="50%">
                                                                    <td align="right">
                                                                        <asp:Label ID="lblSearchby" runat="server" CssClass="MainfontStyle" Text="Search By //" Width="80px"></asp:Label>
                                                                    </td>
                                                                    <td align="right">
                                                                        <asp:Label ID="lblSearch" runat="server" CssClass="MainfontStyle" Text="Employee Name:" Width="110px"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtSearchName" runat="server" CssClass="inputs" Width="250px" OnTextChanged="txtSearchName_TextChanged"
                                                                            AutoPostBack="True">
                                                                        </asp:TextBox></td>
                                                                    <td align="right">
                                                                        <asp:Label ID="lblSearchbyUN" runat="server" CssClass="MainfontStyle" Text="Username:" Width="80px"></asp:Label></td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtSearchUserName" runat="server" AutoPostBack="True" CssClass="inputs"
                                                                            OnTextChanged="txtSearchUserName_TextChanged" Width="250px"></asp:TextBox></td>
                                                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" UseContextKey="True"
                                                                        TargetControlID="txtSearchName" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                                                                        FirstRowSelected="true" EnableCaching="true" DelimiterCharacters=";," CompletionSetCount="20"
                                                                        CompletionInterval="10" BehaviorID="autoCompleteBehavior1">
                                                                    </cc1:AutoCompleteExtender>
                                                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" UseContextKey="True"
                                                                        TargetControlID="txtSearchUserName" ServiceMethod="GetCompletionList2" MinimumPrefixLength="1"
                                                                        FirstRowSelected="true" EnableCaching="true" DelimiterCharacters=";," CompletionSetCount="20"
                                                                        CompletionInterval="10" BehaviorID="autoCompleteBehavior2">
                                                                    </cc1:AutoCompleteExtender>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 40%" valign="top" align="left" rowspan="1">
                                                </td>
                                                <td width="5%" rowspan="1">
                                                </td>
                                                <td width="55%" rowspan="1">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" align="left" rowspan="13">

                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                            <table cellspacing="0" cellpadding="0" width="450">
                                                                <tbody>
                                                                    <tr>
                                                                        <td colspan="3" rowspan="3">
                                                                            <table width="100%">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td align="right" width="30%">
                                                                                            <asp:Label ID="lblName" runat="server" CssClass="MainfontStyle" Text="Username :"></asp:Label></td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtNewUserName" runat="server" CssClass="inputs" Text='<%# Bind("UserName") %>'
                                                                                                Width="270px" ReadOnly="True"></asp:TextBox></td>
                                                                                        <td style="text-align: left">
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                                                ControlToValidate="txtNewUserName" Display="Dynamic" ErrorMessage="Username is required">*</asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtNewUserName"
                                                                                                Display="Dynamic" ErrorMessage="Invalid Username" ValidationExpression="^([a-zA-Z]{1})([a-zA-Z0-9])*$">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            <asp:Label ID="lblTitle" runat="server" CssClass="MainfontStyle" Text="Title :"></asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="ddlNewTitle" runat="server" CssClass="inputs" Width="275px" DataSourceID="odsUsersTitles" DataTextField="SubCode" DataValueField="SID"
                                                                                                Enabled="False">
                                                                                            </asp:DropDownList><asp:TextBox ID="txtNewTitle" runat="server" Text='<%# Bind("TitleID") %>'
                                                                                                Width="15px" Visible="False"></asp:TextBox></td>
                                                                                        <td style="text-align: left">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            <asp:Label ID="lblUserName" runat="server" CssClass="MainfontStyle" Text="Employee Name :"></asp:Label></td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtNewEmployeeName" runat="server" CssClass="inputs" Text='<%# Bind("EmpName") %>'
                                                                                                Width="270px" ReadOnly="True"></asp:TextBox></td>
                                                                                        <td style="text-align: left">
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                                                                ControlToValidate="txtNewEmployeeName" Display="Dynamic" ErrorMessage="Employee Name is required">*</asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtNewEmployeeName"
                                                                                                Display="Dynamic" ErrorMessage="Invalid Employee Name" ValidationExpression="^([a-zA-Z]{1})([\'\,\.\-\ a-zA-Z0-9])*">*</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            <asp:Label ID="lblAccessLevel" runat="server" CssClass="MainfontStyle" Text="Access Level :">
                                                                                            </asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="ddlAccessLevel" runat="server" CssClass="inputs" Width="275px"
                                                                                                AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="ddlAccessLevel_SelectedIndexChanged">
                                                                                                <asp:ListItem Value="SuperAdmin">CEO</asp:ListItem>
                                                                                                <asp:ListItem Value="Admin">HR Manager</asp:ListItem>
                                                                                                <asp:ListItem Value="Manager">Managers</asp:ListItem>
                                                                                                <asp:ListItem Value="SuperUser">Supervisors</asp:ListItem>
                                                                                                <asp:ListItem Value="User">Medical Reps</asp:ListItem>
                                                                                            </asp:DropDownList><asp:TextBox ID="txtAccessLevel" runat="server" Width="15px" Visible="False"></asp:TextBox></td>
                                                                                        <td>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            <asp:Label ID="Label2" runat="server" CssClass="MainfontStyle" Text="National ID:"></asp:Label></td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtNationalID" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                                Text='<%# Bind("NID") %>' Width="270px"></asp:TextBox></td>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNationalID"
                                                                                                Display="Dynamic" ErrorMessage="National ID number is required">*</asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtNationalID"
                                                                                                Display="Dynamic" ErrorMessage="Invalid National ID number" ValidationExpression="^0*[1-9]*([0-9]{0,12})*$">*</asp:RegularExpressionValidator></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            <asp:Label ID="lblAddress" runat="server" CssClass="MainfontStyle" Text="Address:"></asp:Label></td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="inputs" ReadOnly="True" Width="270px" Text='<%# Bind("Address") %>'></asp:TextBox></td>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAddress"
                                                                                                Display="Dynamic" ErrorMessage="Address is required">*</asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtAddress"
                                                                                                Display="Dynamic" ErrorMessage="Invalid Spelling" ValidationExpression="^([a-zA-Z0-9]{1})([_\\'\,\.\-\ a-zA-Z0-9])*">*</asp:RegularExpressionValidator></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            <asp:Label ID="lblMobile" runat="server" CssClass="MainfontStyle" Text="Mobile:"></asp:Label></td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtMobile" runat="server" CssClass="inputs" ReadOnly="True" Width="270px" Text='<%# Bind("Mobile") %>'></asp:TextBox></td>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtMobile"
                                                                                                Display="Dynamic" ErrorMessage="Mobile is required">*</asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtMobile"
                                                                                                Display="Dynamic" ErrorMessage="Invalid Spelling" ValidationExpression="^([a-zA-Z0-9]{1})([_\\'\,\.\-\ a-zA-Z0-9])*">*</asp:RegularExpressionValidator></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            <asp:Label ID="lblEmail" runat="server" CssClass="MainfontStyle" Text="Email:"></asp:Label></td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="inputs" ReadOnly="True" Width="270px" Text='<%# Bind("Email") %>'></asp:TextBox></td>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEmail"
                                                                                                Display="Dynamic" ErrorMessage="Email is required">*</asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                                                                                Display="Dynamic" ErrorMessage="Invalid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            <asp:Label ID="lblHomeTel" runat="server" CssClass="MainfontStyle" Text="Home Tel:"></asp:Label></td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtHomeTel" runat="server" CssClass="inputs" ReadOnly="True" Width="270px" Text='<%# Bind("HomeTel") %>'></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtHomeTel"
                                                                                                Display="Dynamic" ErrorMessage="Invalid Spelling" ValidationExpression="^([a-zA-Z0-9]{1})([_\\'\,\.\-\ a-zA-Z0-9])*">*</asp:RegularExpressionValidator></td>
                                                                                        <td>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            <asp:Label ID="lblSupervisor" runat="server" CssClass="MainfontStyle" Text="Supervisor :">
                                                                                            </asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="ddlSupervisor" runat="server" CssClass="inputs" Width="275px" Enabled="False" AutoPostBack="True" OnSelectedIndexChanged="ddlSupervisor_SelectedIndexChanged">
                                                                                            </asp:DropDownList><asp:TextBox ID="txtSupervisor" runat="server" Width="15px" Visible="False"></asp:TextBox></td>
                                                                                        <td>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            <asp:Label ID="lblIsActive" runat="server" CssClass="MainfontStyle" Text="Is Active :">
                                                                                            </asp:Label></td>
                                                                                        <td>
                                                                                            <asp:CheckBox ID="cbxNewActive" runat="server" CssClass="inputs"
                                                                                                Enabled="False" Checked='<%# Bind("Active") %>'></asp:CheckBox></td>
                                                                                        <td>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="height: 60px" valign="top" align="right">
                                                                                            <asp:Label ID="lblComment" runat="server" CssClass="MainfontStyle" Text="Comments :">
                                                                                            </asp:Label></td>
                                                                                        <td style="height: 60px">
                                                                                            <asp:TextBox ID="txtNewComment" runat="server" Text='<%# Bind("Comment") %>' Width="270px" ReadOnly="True" Height="50px" Rows="5" TextMode="MultiLine"></asp:TextBox></td>
                                                                                        <td style="height: 60px">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td valign="top" align="right">
                                                                                            <asp:Label ID="lblPassword" runat="server" CssClass="MainfontStyle" Text="Password : "
                                                                                                Visible="False">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtNewPassword1" runat="server" CssClass="inputs" Width="270px"
                                                                                                Visible="False" TextMode="Password"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td valign="top" align="right">
                                                                                            <asp:Label ID="lblConfirmPassword" runat="server" CssClass="MainfontStyle" Text="Confirm Password :"
                                                                                                Visible="False"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtNewPassword2" runat="server" CssClass="inputs" Width="270px"
                                                                                                Visible="False" TextMode="Password"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="height: 21px" valign="top" align="right">
                                                                                            <asp:Label ID="lblResetPassword" runat="server" CssClass="MainfontStyle" Text="Reset Password :"
                                                                                                Visible="False"></asp:Label>
                                                                                        </td>
                                                                                        <td style="height: 21px">
                                                                                            <asp:CheckBox ID="chkResetPassword" runat="server" AutoPostBack="True" Visible="False" OnCheckedChanged="chkResetPassword_CheckedChanged"></asp:CheckBox>
                                                                                        </td>
                                                                                        <td style="height: 21px">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                        <td valign="middle">
                                                                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server">
                                                                                            </asp:ValidationSummary>
                                                                                        </td>
                                                                                        <td>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2">
                                                                                        </td>
                                                                                        <td>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                    </tr>
                                                                    <tr>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                      </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <asp:ObjectDataSource ID="odsUsersTitles" runat="server" TypeName="Pharma.BMD.BLL.ManageUsersBLL"
                                                        SelectMethod="SelectUsersTitles" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
                                                </td>
                                                <td rowspan="13">
                                                </td>
                                                <td align="center" rowspan="13" valign="top" style="text-align: center">
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" Visible="False">
                                                        <ContentTemplate>
                                                            <table style="width: 370px" class="tblStyle" cellspacing="0" cellpadding="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td colspan="3" rowspan="3">
                                                                            <table style="width: 100%">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td valign="top" align="left" colspan="8" rowspan="1">
                                                                                            <asp:Label ID="lblAssignedUsers" runat="server" CssClass="MainfontStyle" Text="Assigned Accounts to Current Supervisor"></asp:Label></td>
                                                                                        <td valign="top" align="left" colspan="2" rowspan="1">
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                            <asp:Panel ID="pnlAssignedUsers" runat="server" Width="375px"
                                                                                Height="160px" ScrollBars="Auto" HorizontalAlign="Left">
                                                                                <asp:GridView ID="gvAssignedUsers" runat="server" DataKeyNames="EmpID,UserName" BorderWidth="1px"
                                                                                    BorderStyle="Solid" BorderColor="#999999" Width="95%"
                                                                                    AutoGenerateColumns="False" BackColor="White" CellPadding="1"
                                                                                    OnRowDataBound="gvAssignedUsers_RowDataBound" EmptyDataText="No Data Found">
                                                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>
                                                                                    <RowStyle CssClass="GridNormalRowsStyle"></RowStyle>
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="EmpName" HeaderText="User">
                                                                                            <HeaderStyle HorizontalAlign="Center" Width="90%">
                                                                                            </HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                        </asp:BoundField>
                                                                                        <asp:TemplateField HeaderText="Select">
                                                                                            <EditItemTemplate>
                                                                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                                                                            </EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:CheckBox ID="cbxUserSelected" runat="server" Checked='<%# Bind("Selected") %>'
                                                                                                    Enabled="False" />
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>
                                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                                                                                    <HeaderStyle CssClass="GridHeaderBackStyle" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center"></HeaderStyle>
                                                                                    <EditRowStyle BackColor="#2461BF"></EditRowStyle>
                                                                                    <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                    <EmptyDataTemplate>
                                                                                        <asp:Label ID="lblNoData" runat="server" CssClass="StyleNoData" Font-Bold="True"
                                                                                            Text="No Records."></asp:Label>
                                                                                    </EmptyDataTemplate>
                                                                                </asp:GridView>
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                    </tr>
                                                                    <tr>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="False">
                                                        <ContentTemplate>
                                                            <table>
                                                                <tbody>
                                                                    <tr>
                                                                        <td colspan="3">
                                                                            <table style="width: 370px" class="tblStyle" cellspacing="0" cellpadding="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td colspan="3" rowspan="3">
                                                                                            <table style="width: 100%">
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td valign="top" align="left" colspan="8" rowspan="1">
                                                                                                            <asp:Label ID="lblBriks" runat="server" CssClass="MainfontStyle" Text="Assigned Bricks "></asp:Label></td>
                                                                                                        <td valign="top" align="left" colspan="2" rowspan="1">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="10" rowspan="1">
                                                                                                            <asp:Panel ID="pnlBriks" runat="server" Width="375px" Height="190px"
                                                                                                                ScrollBars="Auto" HorizontalAlign="Left">
                                                                                                                <asp:GridView ID="gvBricks" runat="server" DataKeyNames="EmpID,BrickID,ExpireDate" BorderWidth="1px"
                                                                                                                    BorderStyle="Solid" BorderColor="#999999" Width="95%"
                                                                                                                    AutoGenerateColumns="False" BackColor="White" CellPadding="1"
                                                                                                                    OnRowDataBound="gvBricks_RowDataBound" EmptyDataText="No Data Found" OnSelectedIndexChanged="gvBricks_SelectedIndexChanged">
                                                                                                                    <FooterStyle BackColor="#EFF3FB" Font-Bold="True" ForeColor="White"></FooterStyle>
                                                                                                                    <RowStyle CssClass="GridNormalRowsStyle"></RowStyle>
                                                                                                                    <Columns>
                                                                                                                        <asp:BoundField DataField="BrickName" HeaderText="Brick">
                                                                                                                            <HeaderStyle HorizontalAlign="Center" Width="90%">
                                                                                                                            </HeaderStyle>
                                                                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                                                        </asp:BoundField>
                                                                                                                        <asp:TemplateField HeaderText="Select">
                                                                                                                            <EditItemTemplate>
                                                                                                                                <asp:CheckBox ID="cbxEditBrickSelected" runat="server" Checked='<%# Bind("Selected") %>' />
                                                                                                                            </EditItemTemplate>
                                                                                                                            <FooterTemplate>
                                                                                                                                <asp:CheckBox ID="cbxNewBrickSelected" runat="server" />
                                                                                                                            </FooterTemplate>
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:CheckBox ID="cbxBrickSelected" runat="server" Checked='<%# Bind("Selected") %>'
                                                                                                                                    Enabled="False" />
                                                                                                                            </ItemTemplate>
                                                                                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                                                        </asp:TemplateField>
                                                                                                                    </Columns>
                                                                                                                    <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>
                                                                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                                                                                                                    <HeaderStyle CssClass="GridHeaderBackStyle" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center"></HeaderStyle>
                                                                                                                    <EditRowStyle BackColor="#2461BF"></EditRowStyle>
                                                                                                                    <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                                    <EmptyDataTemplate>
                                                                                                                        <asp:Label ID="lblNoData" runat="server" CssClass="StyleNoData" Font-Bold="True"
                                                                                                                            Text="No Records."></asp:Label>
                                                                                                                    </EmptyDataTemplate>
                                                                                                                </asp:GridView>
                                                                                                            </asp:Panel>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="center" colspan="10" rowspan="1">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td id="TDBrickExpireDate" runat="server"  visible="false" colspan="10" rowspan="1" style="border-right: #a9a9a9 1px solid; border-top: #a9a9a9 1px solid; border-left: #a9a9a9 1px solid; border-bottom: #a9a9a9 1px solid">
                                                                                                            <table id="Table2" width="100%">
                                                                                                                <tr>
                                                                                                                    <td align="left" background="Images/TableHead-BG.jpg" colspan="2" height="25">
                                                                                                            <asp:Label ID="lblExpireDate" runat="server" CssClass="MainfontStyle" Text="Expire date for this brick"></asp:Label></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="center" colspan="2" valign="middle">
                                                                                                                        <asp:RadioButtonList ID="rblExpireDate" runat="server" RepeatDirection="Horizontal" CssClass="MainfontStyle" OnSelectedIndexChanged="rblExpireDate_SelectedIndexChanged" AutoPostBack="True" Enabled="False">
                                                                                                                            <asp:ListItem Selected="True" Value="0">Never Expire</asp:ListItem>
                                                                                                                            <asp:ListItem Value="1">Expire Date</asp:ListItem>
                                                                                                                        </asp:RadioButtonList></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="right" width="60%">
                                                                                                                        <asp:TextBox ID="txtExpireDate" runat="server" CssClass="inputs" Width="100px" Visible="False" OnTextChanged="txtExpireDate_TextChanged"></asp:TextBox></td>
                                                                                                                    <td align="left" width="40%">
                                                                                                                        
                                                                                                                        <asp:ImageButton ID="imgExpireDate" runat="server" AlternateText="Click on Edit in order to activate this button"
                                                                                                                            CssClass="HandOverCursor" ImageUrl="~/Images/Calender.gif" Visible="False" Width="25px" Enabled="False" /></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td colspan="2">
                                                                                                                        <cc1:CalendarExtender ID="calextExpireDate" runat="server" PopupButtonID="imgExpireDate" TargetControlID="txtExpireDate">
                                                                                                                        </cc1:CalendarExtender>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </tbody>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                    </tr>
                                                                                    <tr>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3" height="10">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3">
                                                    <asp:DropDownList ID="ddlNewSupervisor" runat="server" CssClass="inputs" Width="375px" AutoPostBack="True" AppendDataBoundItems="True" DataTextField="EmpName" DataValueField="EmpID" Visible="False">
                                                    </asp:DropDownList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3">
                                                    <asp:Button ID="btnUnassignAllUsers" runat="server" CssClass="button" Text="Move all supervisor's (MRs) to Selected Supervisor"
                                                        Visible="False" OnClick="btnUnassignAllUsers_Click" OnClientClick="return confirm('Are you sure you want to unassign all users from this supervisor?')" Width="375px" /></td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    </td>
                                            </tr>
                                            <tr>
                                            </tr>
                                            <tr>
                                            </tr>
                                            <tr>
                                            </tr>
                                            <tr>
                                            </tr>
                                            <tr>
                                            </tr>
                                            <tr>
                                            </tr>
                                            <tr>
                                            </tr>
                                            <tr>
                                            </tr>
                                            <tr>
                                            </tr>
                                            <tr>
                                            </tr>
                                            <tr>
                                            </tr>
                                            <tr>
                                            </tr>
                                            <tr>
                                                <td valign="top" rowspan="1">
                                                </td>
                                                <td rowspan="1">
                                                </td>
                                                <td rowspan="1">
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                            </tr>
                            <tr>
                            </tr>
                        </tbody>
                    </table>
                </ItemTemplate>
                <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="PagerfontStyle"></PagerStyle>
            </asp:FormView>
            <asp:Label ID="lblErrors" runat="server" CssClass="MainfontStyle" ForeColor="Red"></asp:Label><asp:ObjectDataSource
                ID="odsUsers" runat="server" EnablePaging="True" OldValuesParameterFormatString="original_{0}"
                SelectCountMethod="MaxRowCount" SelectMethod="SelectAllUsers" TypeName="Pharma.BMD.BLL.ManageUsersBLL">
                <SelectParameters>
                    <asp:Parameter DefaultValue="" Name="startRowIndex" Type="Int32" />
                    <asp:Parameter DefaultValue="1" Name="maximumRows" Type="Int32" />
                    <asp:SessionParameter DefaultValue="" Name="ShowAll" SessionField="ShowAll" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
