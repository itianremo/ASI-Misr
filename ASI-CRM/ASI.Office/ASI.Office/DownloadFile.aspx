<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DownloadFile.aspx.cs" Inherits="DownloadFile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  
 <script language="javascript" type="text/javascript"> 
function closeWindow() { 
//uncomment to open a new window and close this parent window without warning 
//var newwin=window.open("popUp.htm",'popup',''); 
if(navigator.appName=="Microsoft Internet Explorer") { 
this.focus();self.opener = this;self.close(); } 
else { window.open('','_parent',''); window.close(); } 
} 
</script> 

 
</head>
<body onfocus="closeWindow();" onload="closeWindow();" onmousemove="closeWindow();">

    <form id="form1"  runat="server">
    
    <div id="PopupDiv" style="z-index: 2; left: 42%; top: 45%; position: absolute; height: 40px;
                                width: auto;">
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="1">
                                    <ProgressTemplate>
                                        <span>
                                            <img src="images/loading.gif" /></span>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
    <div>
    
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </cc1:ToolkitScriptManager>
    
<asp:GridView ID="gvAttachments" runat="server" AutoGenerateColumns="False" 
                                                                        
    ForeColor="Black" AllowPaging="False" AllowSorting="False" BorderColor="Black"
                                                                        
    BorderWidth="1px"  Width="100%"  onrowdatabound="gvAttachments_RowDataBound" >
                                                                        <Columns>
                                                                        <asp:BoundField DataField="AttachmentID"  HeaderText="AttachmentID"
                                                                                >
                                                                                <ControlStyle BorderColor="Black" />
                                                                                <HeaderStyle BackColor="DarkGray" BorderColor="Black" BorderWidth="1px" Wrap="False" />
                                                                                <ItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" HorizontalAlign="Left"
                                                                                    VerticalAlign="Middle" Wrap="False" />
                                                                            </asp:BoundField>
                                                                            
                                                                            <asp:BoundField DataField="FileName" HeaderText="FileName" SortExpression="FileName">
                                                                                <ControlStyle BorderColor="Black" />
                                                                                <HeaderStyle BackColor="DarkGray" BorderColor="Black" BorderWidth="1px" Wrap="False" />
                                                                                <ItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" HorizontalAlign="Left"
                                                                                    VerticalAlign="Middle" Wrap="False" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="EnterDate" DataFormatString="{0:d}" HeaderText="Date"
                                                                                SortExpression="EnterDate">
                                                                                <ControlStyle BorderColor="Black" />
                                                                                <HeaderStyle BackColor="DarkGray" BorderColor="Black" BorderWidth="1px" Wrap="False" />
                                                                                <ItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" HorizontalAlign="Left"
                                                                                    VerticalAlign="Middle" Wrap="False" />
                                                                            </asp:BoundField>
                                                                             <asp:BoundField DataField="EnterByName"  HeaderText="Sale Person"
                                                                                SortExpression="EnterByName">
                                                                                <ControlStyle BorderColor="Black" />
                                                                                <HeaderStyle BackColor="DarkGray" BorderColor="Black" BorderWidth="1px" Wrap="False" />
                                                                                <ItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" HorizontalAlign="Left"
                                                                                    VerticalAlign="Middle" Wrap="False" />
                                                                            </asp:BoundField>
                                                                            
                                                                            <asp:TemplateField HeaderText="Link">
                                                                         <ItemTemplate>
                                                                           <asp:ImageButton ID="imgbtnDownload" runat="server" 
                                                                                 ImageUrl="~/images/DownloadIcons2.gif" onclick="imgbtnDownload_Click"
                                                                           />
                                        
                                                                          </ItemTemplate>
                                                                     <ItemStyle width="50px" horizontalAlign="center" />
                                                                     </asp:TemplateField>
                                                                     
                                                                        </Columns>
                                                                       <RowStyle CssClass="GridNormalRowsStyle" />
                                <SelectedRowStyle CssClass="SelectedRowColor" />
                                <HeaderStyle CssClass="GridHeaderBackStyle" Font-Bold="True" Font-Names="Tahoma" Font-Size="12px" ForeColor="White" />
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                    NextPageText="Next" PreviousPageText="Previous" />
                                <PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Center" />
                                                                    </asp:GridView>
<asp:ObjectDataSource ID="odsAttachments" runat="server" 
    OldValuesParameterFormatString="original_{0}" 
    SelectMethod="SelectAllAttachments" TypeName="Office.BLL.AttachmentsBLL">
    <SelectParameters>
        <asp:SessionParameter Name="CurrentAttchment" SessionField="CurrentAttachments" 
            Type="Object" />
    </SelectParameters>
</asp:ObjectDataSource>

    </div>
    </form>
</body>
</html>
