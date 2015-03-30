<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="BMDUsers, App_Web_bmdusers.aspx.cdcab7d2" title=":: 4A-Pharma BMD :: Users ::" maintainScrollPositionOnPostBack="true" %>

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
                BackImageUrl="~/Images/BG-1.jpg" AllowPaging="True">
                <PagerSettings FirstPageImageUrl="~/Images/home_n.jpg" FirstPageText="First" LastPageImageUrl="~/Images/End_n.jpg"
                    LastPageText="Last" NextPageImageUrl="~/Images/next_n.jpg"
                    NextPageText="Next" PreviousPageImageUrl="~/Images/previous_n.jpg" PreviousPageText="Previous">
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
                                                        <table style="width: 50%; height: 30px" id="tblsearch">
                                                            <tbody>
                                                                <tr align="center" width="50%">
                                                                    <td align="right">
                                                                        <asp:Label ID="Label3" runat="server" CssClass="MainfontStyle" Text="Search Users:"
                                                                            Width="118px"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtSearchName" runat="server" CssClass="inputs" Width="300px" OnTextChanged="txtSearchName_TextChanged"
                                                                            AutoPostBack="True">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" UseContextKey="True"
                                                                        TargetControlID="txtSearchName" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                                                                        FirstRowSelected="true" EnableCaching="true" DelimiterCharacters=";," CompletionSetCount="20"
                                                                        CompletionInterval="10" BehaviorID="autoCompleteBehavior1">
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
                                                                                            <asp:Label ID="lblName" runat="server" CssClass="MainfontStyle" Text="Account Name :"></asp:Label></td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtNewName" runat="server" CssClass="inputs" Text='<%# Bind("EmpName") %>'
                                                                                                Width="270px" ReadOnly="True"></asp:TextBox></td>
                                                                                        <td style="text-align: left">
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                                                ControlToValidate="txtNewName" Display="Dynamic" ErrorMessage="Name is required">*</asp:RequiredFieldValidator></td>
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
                                                                                            <asp:Label ID="lblUserName" runat="server" CssClass="MainfontStyle" Text="User Name :">
                                                                                            </asp:Label></td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtNewUserName" runat="server" CssClass="inputs" Text='<%# Bind("UserName") %>'
                                                                                                Width="270px" ReadOnly="True"></asp:TextBox></td>
                                                                                        <td style="text-align: left">
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                                                                ControlToValidate="txtNewUserName" Display="Dynamic" ErrorMessage="User Name is required">*</asp:RequiredFieldValidator></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            <asp:Label ID="lblAccessLevel" runat="server" CssClass="MainfontStyle" Text="Access Level :">
                                                                                            </asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="ddlAccessLevel" runat="server" CssClass="inputs" Width="275px"
                                                                                                AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="ddlAccessLevel_SelectedIndexChanged">
                                                                                                <asp:ListItem Value="SuperAdmin">Super Admin</asp:ListItem>
                                                                                                <asp:ListItem>Admin</asp:ListItem>
                                                                                                <asp:ListItem>Manager</asp:ListItem>
                                                                                                <asp:ListItem>SuperUser</asp:ListItem>
                                                                                                <asp:ListItem>User</asp:ListItem>
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
                                                                                                Display="Dynamic" ErrorMessage="Invalid National ID number" ValidationExpression="^0*[1-9]*[0-9]*$">*</asp:RegularExpressionValidator></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            <asp:Label ID="lblSupervisor" runat="server" CssClass="MainfontStyle" Text="Supervisor :">
                                                                                            </asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="ddlSupervisor" runat="server" CssClass="inputs" Width="275px" Enabled="False">
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
                                                    <asp:ObjectDataSource ID="odsUsersTitles" runat="server" TypeName="Pharma.BLL.ManageUsersBLL"
                                                        SelectMethod="SelectUsersTitles" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
                                                </td>
                                                <td rowspan="13">
                                                </td>
                                                <td align="left" rowspan="13" valign="top">
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
                                                                                                            <asp:Panel ID="pnlBriks" runat="server" Width="375px" Height="160px"
                                                                                                                ScrollBars="Auto" HorizontalAlign="Left">
                                                                                                                <asp:GridView ID="gvBricks" runat="server" DataKeyNames="BrickID" BorderWidth="1px"
                                                                                                                    BorderStyle="Solid" BorderColor="#999999" ForeColor="#333333" Width="95%"
                                                                                                                    AutoGenerateColumns="False" BackColor="White" CellPadding="1" GridLines="None"
                                                                                                                    OnRowDataBound="gvBricks_RowDataBound">
                                                                                                                    <FooterStyle BackColor="#EFF3FB" Font-Bold="True" ForeColor="White"></FooterStyle>
                                                                                                                    <RowStyle CssClass="GridNormalRowsStyle"></RowStyle>
                                                                                                                    <Columns>
                                                                                                                        <asp:BoundField DataField="BrickName" HeaderText="Brick">
                                                                                                                            <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Width="90%">
                                                                                                                            </HeaderStyle>
                                                                                                                            <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
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
                                                                                                                            <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid"></HeaderStyle>
                                                                                                                            <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                                                                                        </asp:TemplateField>
                                                                                                                    </Columns>
                                                                                                                    <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>
                                                                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                                                                                                                    <HeaderStyle CssClass="GridHeaderBackStyle" Font-Bold="True" ForeColor="Black"></HeaderStyle>
                                                                                                                    <EditRowStyle BackColor="#2461BF"></EditRowStyle>
                                                                                                                </asp:GridView>
                                                                                                            </asp:Panel>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td id="TDBrickExpireDate" runat="server"  visible="false" colspan="10" rowspan="1">
                                                                                                            <asp:Label ID="Label1" runat="server" CssClass="MainfontStyle" Text="Brick Expire date for this user:"></asp:Label></td>
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
                                                                </tbody>
                                                            </table>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" Visible="False">
                                                        <ContentTemplate>
                                                            <table style="width: 100%" class="tblStyle" cellspacing="0" cellpadding="0">
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
                                                                                    AutoGenerateColumns="False" BackColor="White" CellPadding="1" GridLines="None"
                                                                                    OnRowDataBound="gvAssignedUsers_RowDataBound">
                                                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>
                                                                                    <RowStyle CssClass="GridNormalRowsStyle"></RowStyle>
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="EmpName" HeaderText="User">
                                                                                            <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Width="90%">
                                                                                            </HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                                                        </asp:BoundField>
                                                                                        <asp:TemplateField HeaderText="Select">
                                                                                            <EditItemTemplate>
                                                                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                                                                            </EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:CheckBox ID="cbxUserSelected" runat="server" Checked='<%# Bind("Selected") %>'
                                                                                                    Enabled="False" />
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid"></HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>
                                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                                                                                    <HeaderStyle CssClass="GridHeaderBackStyle" Font-Bold="True" ForeColor="Black"></HeaderStyle>
                                                                                    <EditRowStyle BackColor="#2461BF"></EditRowStyle>
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
            <asp:Label ID="lblErrors" runat="server" CssClass="MainfontStyle" ForeColor="Red"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
