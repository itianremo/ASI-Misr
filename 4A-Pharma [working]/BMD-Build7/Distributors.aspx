<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" enableeventvalidation="false" inherits="Distributors, App_Web_distributors.aspx.cdcab7d2" title=":: 4A-Pharma BMD :: Distributors ::" maintainScrollPositionOnPostBack="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="Controls/TransButtons.ascx" TagName="TransButtons" TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td align="center" colspan="3" rowspan="3">
                <table width="50%">
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:FormView ID="frmViewDistributors" runat="server" AllowPaging="True" DataKeyNames="DistributorID"
                                        OnPageIndexChanging="frmViewDistributors_PageIndexChanging" BackImageUrl="~/Images/BG-1.jpg"
                                        BorderColor="DarkGray" BorderStyle="Solid" BorderWidth="1px" Width="800px" Height="520px" OnDataBound="frmViewDistributors_DataBound">
                                        <PagerSettings FirstPageText="First" LastPageText="Last"
                                            NextPageImageUrl="~/Images/next_n.jpg" NextPageText="Next" PreviousPageImageUrl="~/Images/previous_n.jpg"
                                            PreviousPageText="Previous" FirstPageImageUrl="~/Images/home_n.jpg" LastPageImageUrl="~/Images/End_n.jpg">
                                        </PagerSettings>
                                        <ItemTemplate>
                                            <table cellspacing="0" cellpadding="0" width="100%">
                                                <tbody>
                                                    <tr>
                                                        <td colspan="3" rowspan="3">
                                                            <table width="100%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td colspan="4">
                                    <table id="tblsearch" class="tblStyle" style="width: 100%; height: 30px">
                                        <tbody>
                                            <tr align="center" width="50%">
                                                <td align="right" style="width: 40%">
                                                    <asp:Label ID="lblSearch" runat="server" CssClass="MainfontStyle" Text="Search Distributors:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtSearchName" runat="server" AutoPostBack="True" CssClass="inputs"
                                                        OnTextChanged="txtSearchName_TextChanged" Width="300px"></asp:TextBox></td>
                                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" BehaviorID="autoCompleteBehavior1"
                                                    CompletionInterval="10" CompletionSetCount="20" DelimiterCharacters=";," EnableCaching="true"
                                                    FirstRowSelected="true" MinimumPrefixLength="1" ServiceMethod="GetCompletionList"
                                                    TargetControlID="txtSearchName" UseContextKey="True">
                                                </cc1:AutoCompleteExtender>
                                            </tr>
                                        </tbody>
                                    </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" colspan="2" style="width: 60%; height: 30px;">
                                                                            <asp:Label ID="lblDistributorsName" runat="server" CssClass="MainfontStyle" Text="Distributor Name:"></asp:Label>
                                                                            <asp:TextBox ID="txtDistributorName" runat="server" CssClass="inputs" Text='<%# Bind("Name") %>'
                                                                                Width="200px" ReadOnly="True"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                                                ControlToValidate="txtDistributorName" ErrorMessage="Distributor name is required">*</asp:RequiredFieldValidator></td>
                                                                        <td style="width: 2%">
                                                                            </td>
                                                                        <td style="width: 38%">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" colspan="2" valign="top">
                                                                            <asp:UpdatePanel ID="upnlAddBranch" runat="server" Visible="true" >
                                                                                <ContentTemplate>
                                                                                                            <table id="tblAddBranch" style="width: 450px" class="tblStyle">
                                                                                                                <tr>
                                                                                                                    <td align="left" background="Images/TableHead-BG.jpg" colspan="4" style="height: 25px">
                                                                                                                        <asp:Label ID="Label1" runat="server" CssClass="MainfontStyle" Text="Add New Branch"></asp:Label></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="left">
                                                                                                                        <asp:Label ID="lblBranchName" runat="server" CssClass="MainfontStyle" Text="Branch Name"></asp:Label></td>
                                                                                                                    <td align="left" colspan="2">
                                                                                                                        <asp:Label ID="lblBranchAddress" runat="server" CssClass="MainfontStyle" Text="Branch Address"></asp:Label></td>
                                                                                                                    <td align="left" colspan="1">
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="left" valign="top">
                                                                                                                                <asp:TextBox ID="txtNewBranchName" runat="server" CssClass="inputs"
                                                                                                                                    Width="150px"></asp:TextBox><br />
                                                                                                                        <asp:Label ID="lblVBranchName" runat="server" Font-Names="Arial" Font-Size="12px"
                                                                                                                            ForeColor="Red" Text="Name is required" Visible="False" Font-Bold="False"></asp:Label><asp:Label ID="lblDupName" runat="server" Font-Names="Arial" Font-Size="12px" ForeColor="Red"
                                                                                                                            Text="Duplicated name" Visible="False"></asp:Label></td>
                                                                                                                    <td align="left" colspan="2" valign="top">
                                                                                                                                <asp:TextBox ID="txtNewBranchAddress" runat="server" CssClass="inputs" Width="150px"></asp:TextBox><br />
                                                                                                                        <asp:Label ID="lblVBranchAddress" runat="server" Font-Names="Arial" Font-Size="12px"
                                                                                                                            ForeColor="Red" Text="Address is required" Visible="False"></asp:Label></td>
                                                                                                                    <td align="left" colspan="1" valign="top">
                                                                                                                                <asp:Button ID="btnNewBranch" runat="server" CssClass="button" Text="Add Branch" OnClick="btnNewBranch_Click" /></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="center" colspan="3">
                                                                                                                    </td>
                                                                                                                    <td align="center" colspan="1">
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td align="left" rowspan="2" valign="top">
                                                                            <asp:UpdatePanel ID="upnlBricks" runat="server" Visible="False">
                                                                                <ContentTemplate>
                                                                            <table cellpadding="0" cellspacing="0" class="tblStyle" style="width: 320px">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td colspan="3" rowspan="3">
                                                                                            <table style="width: 100%">
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td align="left" colspan="10" rowspan="1" style="height: 25px" background="Images/TableHead-BG.jpg">
                                                                                                            <asp:Label ID="lblRxAccounts" runat="server" CssClass="MainfontStyle" Text="Assigned Bricks For The Selected Branch"></asp:Label></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="center" colspan="10" rowspan="1">
                                                                                                            <asp:Panel ID="pnlBricks" runat="server" Height="344px" HorizontalAlign="Left" ScrollBars="Auto"
                                                                                                                Width="100%">
                                                                                                                <asp:GridView ID="gvBricks" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                                                                                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" DataKeyNames="BrickID"
                                                                                                                    OnRowDataBound="gvBricks_RowDataBound" Width="95%">
                                                                                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                                                                    <Columns>
                                                                                                                        <asp:BoundField DataField="BrickName" HeaderText="BrickName">
                                                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                                                            <HeaderStyle HorizontalAlign="Center" Width="90%" />
                                                                                                                        </asp:BoundField>
                                                                                                                        <asp:TemplateField HeaderText="Select">
                                                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:CheckBox ID="cbxSelectBrick" runat="server" Checked='<%# Bind("Selected") %>'
                                                                                                                                    Enabled="False" />
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                    </Columns>
                                                                                                                    <RowStyle CssClass="GridNormalRowsStyle" />
                                                                                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                                                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                                                                                    <HeaderStyle CssClass="GridHeaderBackStyle" Font-Bold="True" ForeColor="Black" />
                                                                                                                </asp:GridView>
                                                                                                            </asp:Panel>
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
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" colspan="2" valign="top">
                                                                            <asp:UpdatePanel ID="upnlBranches" runat="server" Visible="False">
                                                                                <ContentTemplate>
                                                                            <table cellpadding="0" cellspacing="0" class="tblStyle" style="width: 450px">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td colspan="3" rowspan="3">
                                                                                            <table style="width: 100%">
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td align="left" colspan="10" rowspan="1" style="height: 25px" background="Images/TableHead-BG.jpg">
                                                                                                            <asp:Label ID="lblRxRes" runat="server" CssClass="MainfontStyle" Text="Distributor's Branches"></asp:Label></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="center" colspan="10" rowspan="1">
                                                                                                            <asp:Panel ID="pnlBranches" runat="server" Height="250px" HorizontalAlign="Left"
                                                                                                                ScrollBars="Auto" Width="100%"><asp:GridView ID="gvBranches" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                                                                                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" DataKeyNames="BranchID" Width="95%" CellPadding="3" OnRowCreated="gvBranches_RowCreated" OnSelectedIndexChanging="gvBranches_SelectedIndexChanging">
                                                                                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                                                                    <Columns>
                                                                                                                        <asp:TemplateField HeaderText="Branch Name">
                                                                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                                                                            <HeaderStyle HorizontalAlign="Left" Width="40%" />
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="lblBranchName" runat="server" Text='<%# Bind("BranchName") %>'></asp:Label><asp:TextBox
                                                                                                                                    ID="txtBranchName" runat="server" CssClass="inputs" Text='<%# Bind("BranchName") %>'
                                                                                                                                    Visible="False" Width="90%"></asp:TextBox>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:TemplateField HeaderText="Branch Address">
                                                                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="lblBranchAddress" runat="server" Text='<%# Bind("BranchAddress") %>'></asp:Label>
                                                                                                                                <asp:TextBox ID="txtBranchAddress" runat="server" CssClass="inputs" Text='<%# Bind("BranchAddress") %>'
                                                                                                                                    Visible="False" Width="90%"></asp:TextBox>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:TemplateField>
                                                                                                                    </Columns>
                                                                                                                    <RowStyle CssClass="GridNormalRowsStyle" />
                                                                                                                    <SelectedRowStyle BackColor="#BCC9B7" Font-Bold="True" ForeColor="White" />
                                                                                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                                                                                    <HeaderStyle CssClass="GridHeaderBackStyle" Font-Bold="True" ForeColor="Black" />
                                                                                                                </asp:GridView>
                                                                                                            </asp:Panel>
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
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" colspan="2">
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr><tr>
                                                                        <td align="center" colspan="4">
                                                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="StyleValidationSummary">
                                                                            </asp:ValidationSummary>
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
                                        </ItemTemplate>
                                        <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="PagerfontStyle" />
                                        <RowStyle VerticalAlign="Top" />
                                        <EmptyDataRowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <EmptyDataTemplate>
                                            <table cellspacing="0" cellpadding="0" width="100%">
                                                <tbody>
                                                    <tr>
                                                        <td colspan="3" rowspan="3">
                                                            <table width="100%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <table id="Table1" class="tblStyle" style="width: 100%; height: 30px">
                                                                                <tbody>
                                                                                    <tr align="center" width="50%">
                                                                                        <td align="right" style="width: 40%">
                                                                                            <asp:Label ID="lblSearch" runat="server" CssClass="MainfontStyle" Text="Search Distributors:"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:TextBox ID="txtSearchName" runat="server" AutoPostBack="True" CssClass="inputs"
                                                                                                OnTextChanged="txtSearchName_TextChanged" Width="300px"></asp:TextBox></td>
                                                                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" BehaviorID="autoCompleteBehavior1"
                                                    CompletionInterval="10" CompletionSetCount="20" DelimiterCharacters=";," EnableCaching="true"
                                                    FirstRowSelected="true" MinimumPrefixLength="1" ServiceMethod="GetCompletionList"
                                                    TargetControlID="txtSearchName" UseContextKey="True">
                                                                                        </cc1:AutoCompleteExtender>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" colspan="2" style="width: 60%; height: 30px;">
                                                                            <asp:Label ID="lblDistributorsName" runat="server" CssClass="MainfontStyle" Text="Distributor Name:"></asp:Label>
                                                                            <asp:TextBox ID="txtDistributorName" runat="server" CssClass="inputs" ReadOnly="True"
                                                                                Text='<%# Bind("Name") %>' Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDistributorName"
                                                                                Display="Dynamic" ErrorMessage="Distributor name is required">*</asp:RequiredFieldValidator></td>
                                                                        <td style="width: 2%">
                                                                        </td>
                                                                        <td style="width: 38%">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" colspan="2" valign="top">
                                                                            &nbsp;</td>
                                                                        <td>
                                                                        </td>
                                                                        <td align="left" rowspan="2" valign="top">
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" colspan="2" valign="top">
                                                                            &nbsp;</td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" colspan="2">
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="4">
                                                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="StyleValidationSummary" />
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
                                        </EmptyDataTemplate>
                                    </asp:FormView>
                                    <asp:Label ID="lblNoDataMsg" runat="server" CssClass="MainfontStyle"></asp:Label><br /><asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                ForeColor="#004000" Text='Your request for adding new Distributor is in "Pending" phase until Acceptance from your Manager'
                                Visible="False"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
    </table>
    <script type="text/javascript">
    var scrollTop;
    var scrollTop1;
    var scrollTop2;
  
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler1);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler1);


      function BeginRequestHandler(sender, args) 
        {
          var elem = document.getElementById('ctl00_ContentPlaceHolder1_frmViewDistributors_pnlBranches');
              if(elem!= null)
              scrollTop=elem.scrollTop;
        }

      function EndRequestHandler(sender, args)
       {
       var elem = document.getElementById('ctl00_ContentPlaceHolder1_frmViewDistributors_pnlBranches');
            if(elem!= null)
           elem.scrollTop = scrollTop;
  
      }  
      
      ///
      function BeginRequestHandler1(sender, args) 
        {
          var elem = document.getElementById('ctl00_ContentPlaceHolder1_frmViewDistributors_pnlBricks');
              if(elem!= null)
              scrollTop1=elem.scrollTop;
        }

      function EndRequestHandler1(sender, args)
       {
          var elem = document.getElementById('ctl00_ContentPlaceHolder1_frmViewDistributors_pnlBricks');
            if(elem!= null)
            elem.scrollTop = scrollTop1;
  
      }  
    
    </script>
</asp:Content>

