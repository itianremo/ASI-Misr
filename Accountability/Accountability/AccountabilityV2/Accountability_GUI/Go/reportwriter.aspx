<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reportwriter.aspx.cs" Inherits="test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../Acc1.css" type="text/css" rel="stylesheet"/>

<script type="text/JavaScript">

function openWindow(url)
{
	if ( wndHandle && wndHandle.open && wndHandle.closed)
		wndHandle.close();
	wndHandle=open('','window','width=450,height=500,top=0,left=200,status=yes,scrollbars=yes');
	wndHandle.location.href = url;
	if (wndHandle.opener == null) wndHandle.opener = self;		
}
</script>

</head>
<body dir="ltr">
    <form id="form1" runat="server">
  
        <table id="Table1" style="height: 248px; width: 570px;" cellspacing="0" cellpadding="5"
    align="center" border="0" class="FunctionBlock">
    <tr>
        <td class="formslabels" valign=middle style=" width:429px; height:27px;">
             &nbsp; &nbsp; &nbsp;Reports </td> <td class="formslabels" valign=middle style=" width:141px; height:27px;" dir="rtl">
            <asp:HyperLink ID="LinkButton1" Target="_blank" runat="server"   ToolTip="Go To Report Writer">
            <img  alt='Go To Report Writer' 
                                                width='141px' height='27px'  border=0  
                                               src="images/ReportWriter-n.jpg"
                                                onmouseover="this.src='images/ReportWriter-o.jpg'" 
                                                onmouseout="this.src='images/ReportWriter-n.jpg'"  onmousedown="this.src='images/ReportWriter-s.jpg'"  /></asp:HyperLink></td>
    </tr>
    <tr>
        <td style="width: 100%" align="center" colspan=2>
            <%--<div style="width: 40%; text-align: center;">
                <table style="width: 100%; height: 24px">
                    <tr class="whitetd">
                        <td style="width: 85%; height: 20px;">
                            Report Name</td>
                        <td style="width: 15%; height: 20px;">
                        </td>
                    </tr>
                </table>
            </div>--%>
         
             <div style="width: 100%; height: 550px">
            <rwg:FrozenGridView  ID="dgReports" CellPadding="3" BorderColor="White" PageSize="20" Width="100%" Height="620px" Scrolling="Auto" 
                    AutoGenerateColumns="False" runat="server" OnSelectedIndexChanged="dgReports_SelectedIndexChanged" HorizontalAlign="Center" OnRowDataBound="dgReports_RowDataBound" DataKeyNames="ReportID,ReportType" >
                    <SelectedRowStyle CssClass="orangetd"></SelectedRowStyle>
                    <AlternatingRowStyle CssClass="bsalternativetd"></AlternatingRowStyle>
                    <RowStyle CssClass="bsnormaltd"></RowStyle>
                    <HeaderStyle CssClass="whitetd"></HeaderStyle>
                     <Columns>
                         <asp:TemplateField HeaderText="Report ID" SortExpression="ReportID" Visible="False">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ReportID") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="lblRepID" runat="server" Text='<%# Bind("ReportID") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Report Name">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("ReportName") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label1" ToolTip='<%# Bind("REP_RepDescription") %>' runat="server" Text='<%# Bind("ReportName") %>'></asp:Label>
                             </ItemTemplate>
                             <ItemStyle HorizontalAlign="Left" Width="50%" />
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="ReportType" Visible="False">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ReportType") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="lblRepType" runat="server"  Text='<%# Bind("ReportType") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                          <asp:TemplateField HeaderText=" Requested By">
                             <EditItemTemplate>
                                 <asp:TextBox ID="txtREP_Creator" runat="server" Text='<%# Bind("REP_RepRemarks") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="lblREP_Creator"  runat="server" Text='<%# Bind("REP_RepRemarks") %>'></asp:Label>
                             </ItemTemplate>
                             <ItemStyle HorizontalAlign="Left" Width="30%" />
                         </asp:TemplateField>
                         
                         <%--<asp:TemplateField HeaderText="By">
                             <EditItemTemplate>
                                 <asp:TextBox ID="txtREP_Creator" runat="server" Text='<%# Bind("REP_Creator") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="lblREP_Creator"  runat="server" Text='<%# Bind("REP_Creator") %>'></asp:Label>
                             </ItemTemplate>
                             <ItemStyle HorizontalAlign="Left" Width="25%" />
                         </asp:TemplateField>--%>
                         
                         
                          <asp:TemplateField HeaderText="Date">
                             <EditItemTemplate>
                                 <asp:TextBox ID="txtREP_RepDate" runat="server" Text='<%# Bind("REP_RepDate") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="lblREP_RepDate"  runat="server" Text='<%# Bind("REP_RepDate") %>'></asp:Label>
                             </ItemTemplate>
                             <ItemStyle HorizontalAlign="Left" Width="10%" />
                         </asp:TemplateField>
                          
                         
                         <asp:TemplateField ShowHeader="False">
                             <ItemTemplate>
                                 <asp:HyperLink ID="HlnkRun" runat="server"  Target="_blank"
                                     Text="Run"></asp:HyperLink>
                             </ItemTemplate>
                             <ItemStyle Width="10%" />
                         </asp:TemplateField>
                        <asp:BoundField DataField="REP_Module" >
                            <ItemStyle Width="100%" HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                   <%-- <PagerStyle   CssClass="bsFootertd"  ></PagerStyle>--%>
                </rwg:FrozenGridView>
                <%--<asp:DataGrid ID="dgReports" CellPadding="2" BorderColor="White" PageSize="20" Width="100%" 
                    AutoGenerateColumns="False" runat="server" OnSelectedIndexChanged="dgReports_SelectedIndexChanged" HorizontalAlign="Center">
                    <SelectedItemStyle CssClass="orangetd"></SelectedItemStyle>
                    <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                    <ItemStyle CssClass="bsnormaltd"></ItemStyle>
                    <HeaderStyle CssClass="whitetd"></HeaderStyle>
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="ReportID" SortExpression="FileID" HeaderText="Report ID">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ReportName" HeaderText="Report Name">
                            <ItemStyle Width="85%" HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn Visible="False" DataField="ReportType" HeaderText="ReportType"></asp:BoundColumn>
                        <asp:ButtonColumn Text="Run" CommandName="Select">
                            <ItemStyle Width="15%"></ItemStyle>
                        </asp:ButtonColumn>
                    </Columns>
                    <PagerStyle Position="TopAndBottom" CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
                </asp:DataGrid>--%>
            </div>
        </td>
    </tr>
    <%--<tr>
        <td valign="baseline" align="center" class="formslabels"  colspan=2>
            <asp:HyperLink ID="LinkButton1" Target="_blank" runat="server"  ForeColor="White" ToolTip="Go To Report Writer">Go To Report Writer</asp:HyperLink></td>
    </tr>--%>
</table>
    </form>
</body>
</html>
