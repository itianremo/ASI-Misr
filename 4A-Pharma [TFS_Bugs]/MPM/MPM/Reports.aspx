<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="Reports.aspx.cs" Inherits="Reports" EnableEventValidation="false" Title=":: MPM - BMD :: Queries ::"
    MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="Controls/TransButtons.ascx" TagName="TransButtons" TagPrefix="uc2" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
    <table id="tblContent" width="100%">
        <tbody>
            <tr>
                <td align="center">
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table style="width: 600px" id="Table1" class="tblStyle">
                        <tbody>
                            <tr>
                                <td style="height: 221px" align="center" colspan="4">
                                    <asp:Panel ID="pnlReportsList" runat="server" Width="100%" HorizontalAlign="Left"
                                        ScrollBars="Auto" Height="200px">
                                        <asp:GridView ID="gvReports" runat="server" DataKeyNames="REP_RepID" Width="95%"
                                            BorderWidth="1px" CellPadding="3" BackColor="White" BorderColor="#999999" BorderStyle="Solid"
                                            PageSize="20" AutoGenerateColumns="False" OnRowDataBound="gvReports_RowDataBound" HorizontalAlign="Center">
                                            <Columns>
                                                <asp:BoundField DataField="REP_RepID" HeaderText="ReportID" Visible="False" />
                                                <asp:TemplateField HeaderText="Report Name">

                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hplReports" runat="server" Target="_blank" Text='<%# Bind("REP_RepName") %>'></asp:HyperLink>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="GridHeaderBackStyle" ForeColor="Black"></HeaderStyle>
                                            <RowStyle CssClass="GridNormalRowsStyle" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                            <SelectedRowStyle CssClass="AltRowStyle" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 25px" align="center" colspan="4">
                                    <asp:HyperLink ID="lnkReportWriter" runat="server" Target="_blank" Font-Bold="True"
                                        Font-Names="Tahoma" Font-Size="13px" ForeColor="Blue">Go To Report Writer</asp:HyperLink>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">
    var scrollTop;
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
      function BeginRequestHandler(sender, args) 
        {
          var elem = document.getElementById('ctl00_ContentPlaceHolder1_pnlReportsList');
              if(elem!= null)
              scrollTop=elem.scrollTop;
        }

      function EndRequestHandler(sender, args)
       {
       var elem = document.getElementById('ctl00_ContentPlaceHolder1_pnlReportsList');
            if(elem!= null)
           elem.scrollTop = scrollTop;
  
      }  
    </script>

</asp:Content>
