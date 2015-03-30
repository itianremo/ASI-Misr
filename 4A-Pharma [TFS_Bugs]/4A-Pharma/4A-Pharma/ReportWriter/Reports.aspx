<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="Reports.aspx.cs" Inherits="Reports" EnableEventValidation="false" Title=":: 4A-Pharma BMD :: Reports ::"
    MaintainScrollPositionOnPostback="true" %>
<%@ Register Src="../Controls/TransButtons.ascx" TagName="TransButtons" TagPrefix="uc2" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<script language="javascript">
    function DownLoadReport(ReportID)
    {
        var iframe = document.createElement("iframe");
        iframe.src = "GenerateFile.aspx?ReportID=" + ReportID;
        iframe.style.display = "none";
        document.body.appendChild(iframe); 
    }
</script>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
<TABLE id="tblContent" width="100%"><TBODY><TR><TD align=center><TABLE style="WIDTH: 600px" id="tblAddReport" class="tblStyle"><TBODY><TR><TD style="HEIGHT: 25px" align=left background="../Images/TableHead-BG.jpg" colSpan=4><asp:Label id="lblReport" runat="server" CssClass="MainfontStyle" Text="Create New Report :: Step One ::"></asp:Label></TD></TR><TR><TD style="WIDTH: 180px; HEIGHT: 50px" align=right><asp:Label id="Label1" runat="server" CssClass="MainfontStyle" Text="Report Name: "></asp:Label></TD><TD align=left colSpan=3><asp:TextBox id="txtCreateReportName" runat="server" CssClass="inputs" ValidationGroup="CreateReport" Width="200px"></asp:TextBox>&nbsp;<asp:Button id="btnCreateReport" onclick="btnCreateReport_Click" runat="server" CssClass="button" Text="Continue" ValidationGroup="CreateReport"></asp:Button></TD></TR><TR><TD align=center colSpan=4><asp:Label id="lblVReportName" runat="server" Text="Report Name is required to continue" Font-Bold="False" ForeColor="Red" Visible="False" Font-Size="12px" Font-Names="Arial"></asp:Label></TD></TR></TBODY></TABLE></TD></TR><TR><TD align=center><TABLE style="WIDTH: 600px" id="Table1" class="tblStyle"><TBODY><TR><TD style="HEIGHT: 25px" align=left background="../Images/TableHead-BG.jpg" colSpan=4><asp:Label id="lblReports" runat="server" CssClass="MainfontStyle" Text="Reports List"></asp:Label></TD></TR><TR><TD style="HEIGHT: 221px" align=left colSpan=4><asp:Panel id="pnlReportsList" runat="server" Width="100%" Height="200px" ScrollBars="Auto" HorizontalAlign="Left"><asp:GridView id="GridView_1" runat="server" BorderWidth="1px" CellPadding="3" Width="95%" AutoGenerateColumns="False" DataKeyNames="REP_RepID" DataSourceID="SqlDataSourceReports" OnSelectedIndexChanged="GridView_1_SelectedIndexChanged" OnRowCreated="GridView_1_RowCreated" OnRowDataBound="GridView_1_RowDataBound" BorderStyle="Solid" BorderColor="#999999" BackColor="White">
                                    <Columns>
                                        <asp:BoundField DataField="REP_RepName" HeaderText="Report Name" SortExpression="REP_RepName">
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="REP_RepDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Creation Date"
                                            HtmlEncode="False" SortExpression="REP_RepDate">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Modify Query" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnModify" runat="server" CausesValidation="False" OnClick="lnkbtnModify_Click">Modify Query</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnDelete" runat="server" CausesValidation="False" OnClick="lnkbtnDelete_Click">Delete</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Design">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDownload" runat="server" CausesValidation="False" OnClientClick='<%# Eval("REP_RepID", "DownLoadReport({0})") %>'>Download</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("REP_RepID", "~/ReportWriter/ReportRunViewer.aspx?id={0}") %>'
                                                    Target="_blank" Text="Run"></asp:HyperLink>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeaderBackStyle" ForeColor="Black"></HeaderStyle>
                                    <RowStyle CssClass="GridNormalRowsStyle" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                            <SelectedRowStyle CssClass="AltRowStyle" />
                                </asp:GridView> </asp:Panel> </TD></TR><TR><TD style="HEIGHT: 25px" align=center colSpan=4></TD></TR></TBODY></TABLE></TD></TR><TR><TD align=center><asp:Table id="tblErr" runat="server" CssClass="errorTable" Width="600px" Visible="False" Font-Names="Arial" HorizontalAlign="Center" CellSpacing="0" CellPadding="2" BorderWidth="0px">
                            <asp:TableRow ID="TableRow1" runat="server" VerticalAlign="Top">
                                <asp:TableCell ID="TableCell1" runat="server" BackColor="#FFFFC0" BorderColor="White" Text="&lt;img src=../images/alrt.gif /&gt;"></asp:TableCell>
                                <asp:TableCell ID="TableCell2" runat="server" BackColor="#FFFFC0"></asp:TableCell>
                            </asp:TableRow>
                        </asp:Table> </TD></TR><TR><TD align=center><TABLE style="WIDTH: 600px" id="tblReportDetailsContaner" class="tblStyle"><TBODY><TR><TD style="HEIGHT: 25px" align=left background="../Images/TableHead-BG.jpg" colSpan=4><asp:Label id="lblReportDetails" runat="server" CssClass="MainfontStyle" Text="Selected Report Details"></asp:Label></TD></TR><TR><TD colSpan=4 rowSpan=3><TABLE id="tblReportDetails" cellSpacing=2 cellPadding=2 width="100%"><TBODY><TR><TD align=right>&nbsp;<asp:Label id="lblReportName" runat="server" CssClass="MainfontStyle" Text="Report Name:"></asp:Label></TD><TD align=left><asp:TextBox id="TextBoxName" runat="server" CssClass="inputs" Width="250px" MaxLength="60"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Report name is required" ControlToValidate="TextBoxName">*</asp:RequiredFieldValidator></TD></TR><TR><TD vAlign=top align=right><asp:Label id="lblDescription" runat="server" CssClass="MainfontStyle" Text="Description:"></asp:Label></TD><TD align=left><asp:TextBox id="TextBoxDesc" runat="server" CssClass="inputs" Width="250px" MaxLength="500" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD align=right><asp:Label id="lblFile" runat="server" CssClass="MainfontStyle" Text="Upload Report Design:"></asp:Label> </TD><TD align=left><asp:FileUpload id="FileUpload2" runat="server" CssClass="inputs" Width="252px"></asp:FileUpload></TD></TR></TBODY></TABLE></TD></TR><TR></TR><TR></TR><TR><TD align=center colSpan=4 rowSpan=1><asp:Button id="ButtonSaveReprt" onclick="ButtonSaveReprt_Click" runat="server" CssClass="button" Text="Save" Width="60px">
                            </asp:Button></TD></TR><TR><TD style="HEIGHT: 25px" align=center colSpan=4 rowSpan=1><asp:HyperLink id="hplAccessRights" runat="server" NavigateUrl="~/ReportWriter/ReportSecurity.aspx" CssClass="MainfontStyle" Visible="False">Reports Access Rights</asp:HyperLink></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE><asp:SqlDataSource id="SqlDataSourceReports" runat="server" SelectCommandType="StoredProcedure" SelectCommand="sp_ViewReports_NEW" DeleteCommand="DELETE FROM REP_Reports WHERE (REP_RepID = @REP_RepID)" ConnectionString="<%$ ConnectionStrings:PharmaConnectionString %>">
                <DeleteParameters>
                    <asp:Parameter Name="REP_RepID" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtREP_Project" DefaultValue="2" Name="REP_Project"
                        PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="txtIsAdmin" DefaultValue="0" Name="IsAdmin" PropertyName="Text"
                        Type="Int32" />
                    <asp:ControlParameter ControlID="txtContactID" DefaultValue="1" Name="ContactID"
                        PropertyName="Text" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource> <asp:SqlDataSource id="SqlDataSource1" runat="server" SelectCommandType="StoredProcedure" SelectCommand="sp_ViewReports_NEW" DeleteCommand="DELETE FROM REP_Reports WHERE (REP_RepID = @REP_RepID)" ConnectionString="<%$ ConnectionStrings:PharmaConnectionString %>" OnDeleted="SqlDataSource1_Deleted" OnDeleting="SqlDataSource1_Deleting" ProviderName="<%$ ConnectionStrings:PharmaConnectionString.ProviderName %>">
                <DeleteParameters>
                    <asp:ControlParameter ControlID="GridView1" Name="REP_RepID" PropertyName="SelectedValue" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtREP_Project" DefaultValue="2" Name="REP_Project"
                        PropertyName="Text" Size="50" Type="String" />
                    <asp:ControlParameter ControlID="txtIsAdmin" DefaultValue="0" Name="IsAdmin" PropertyName="Text"
                        Type="Int32" />
                    <asp:ControlParameter ControlID="txtContactID" DefaultValue="1" Name="ContactID"
                        PropertyName="Text" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource> <asp:SqlDataSource id="SqlDataSource2" runat="server" SelectCommandType="StoredProcedure" SelectCommand="sp_ViewReports_NEW" DeleteCommand="DELETE FROM REP_Reports WHERE (REP_RepID = @REP_RepID)" ConnectionString="<%$ ConnectionStrings:PharmaConnectionString %>">
                <DeleteParameters>
                    <asp:Parameter Name="REP_RepID" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtREP_Project" DefaultValue="2" Name="REP_Project"
                        PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="txtIsAdmin" DefaultValue="0" Name="IsAdmin" PropertyName="Text"
                        Type="Int32" />
                    <asp:ControlParameter ControlID="txtContactID" DefaultValue="1" Name="ContactID"
                        PropertyName="Text" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource> <asp:SqlDataSource id="SqlDataSource4" runat="server"></asp:SqlDataSource> <asp:TextBox id="txtIsAdmin" runat="server" Width="0px" Visible="False">
            </asp:TextBox> <asp:TextBox id="txtREP_Project" runat="server" Width="0px" Visible="False">
            </asp:TextBox> <asp:TextBox id="txtContactID" runat="server" Width="0px" Visible="False">
            </asp:TextBox> 
</ContentTemplate>
        <triggers>
<asp:PostBackTrigger ControlID="ButtonSaveReprt"></asp:PostBackTrigger>
</triggers>
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
