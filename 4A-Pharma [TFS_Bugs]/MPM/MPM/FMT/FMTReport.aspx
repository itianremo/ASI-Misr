<%@ Page Language="C#" MasterPageFile="~/FMT/FMTMasterPage.master" AutoEventWireup="true" CodeFile="FMTReport.aspx.cs" Inherits="FMT_FMTReport" 
EnableEventValidation="false" culture="ar-EG" uiCulture="ar-EG" Title=":: 4A-Pharma FMT :: M.R. Plan Feedback::" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../Controls/TransButtons.ascx" TagName="TransButtons" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript">

    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
    
    function EndRequestHandler(sender, args)
    {
        SetGvMMBackgroundColor();
        SetGvProductsBackgroundColor()
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
                <td align="center" colspan="3" rowspan="3">
                   
                </td>
            </tr>
            <tr>
            </tr>
            <tr>
            </tr>
            <tr>
                <td id="TDWeekContent" align="center" colspan="3" rowspan="1">
                    <table cellpadding="0" cellspacing="0" class="tblStyle" style="width: 100%">
                        <tbody>
                            <tr>
                                <td colspan="3" rowspan="3">
                                    <table align="left" id="tblWeeKContent" background="../Images/BG-1.jpg" class="tblStyle" width="100%">
                                        <tbody>
                                            <tr>
                                                <td align="left" background="../Images/TableHead-BG.jpg" colspan="11" rowspan="1"
                                                    style="height: 20px" width="90%">
                                                    <asp:Label ID="lblPlanFeedback" runat="server" CssClass="MainfontStyle" Font-Size="18px"
                                                        Text="Plan Feedback"></asp:Label></td>
                                                <td align="center" background="../Images/TableHead-BG.jpg" colspan="1" rowspan="1"
                                                    style="height: 20px">
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                        <ContentTemplate>
                                                    <asp:HyperLink ID="lnkPrint" runat="server" CssClass="MainfontStyle" Target="_blank" ToolTip="Print FMT Report">Print Report</asp:HyperLink>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="12" dir="ltr" rowspan="1" height="671" valign="top">
                                                    <asp:UpdatePanel ID="upnlWeekContent" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                                        <table id="tblVisitsContent" runat="server" width="98%">
                                                                            <tr id="Tr1">
                                                                                <td colspan="3" rowspan="3" id="Td1">
                                                                                    <table id="Table4" width="100%">
                                                                                        <tr>
                                                                                            <td colspan="3" align="center" valign="middle">
                                                                    <asp:Label ID="lblVDate" runat="server" CssClass="MainfontStyle" Text="Day of Visit:"></asp:Label>
                                                                    <asp:TextBox ID="txtPlanDate" runat="server" CssClass="inputs"
                                                    Width="175px" AutoPostBack="True" OnTextChanged="txtPlanDate_TextChanged"></asp:TextBox>
                                                <asp:ImageButton ID="imgPlanDate" runat="server" AlternateText="Pick a date"
                                                        CssClass="HandOverCursor" ImageUrl="~/Images/Calender.gif"
                                                        Width="25px" CausesValidation="False" /></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="3" height="5" align="center" valign="middle">
                                                   <asp:Label ID="lblName" runat="server" CssClass="FMT-TitleFontStyle" Text="Name:" Font-Bold="True"></asp:Label>
                                                            <asp:Label ID="lblMRName" runat="server" CssClass="FMT-TitleFontStyle" Text="Mohammed Fawzi" Font-Bold="True"></asp:Label>
                                                                <asp:Label ID="lblTitle" runat="server" CssClass="FMT-TitleFontStyle" Text="Title:" Font-Bold="True"></asp:Label>
                                                            <asp:Label ID="lblMRTitle" runat="server" CssClass="FMT-TitleFontStyle" Text="Proffesor" Font-Bold="True"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="center" colspan="3" height="5" valign="middle">
                                                                                                <div id="PopupDiv" style="z-index: 10; left: 42%; width: auto; position: absolute;
                                                                                                    top: 45%; height: 40px">
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
                                                                                            <td colspan="3">
                                                                                                <table id="tblSunVisits" runat="server" class="tblStyle" width="100%">
                                                                                                    <tr>
                                                                                                        <td background="../Images/TableHead-BG.jpg" colspan="3" align="left">
                                                                                                            <asp:LinkButton ID="lnkbtnSunVisits" runat="server" CausesValidation="False" CssClass="FMTLinkFontStyle" OnClick="lnkbtnSunVisits_Click">LinkButton</asp:LinkButton></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="3">
                                                                                                            <asp:GridView ID="gvSunVisits" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                                                                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                                                                                                CellPadding="3" DataKeyNames="VisitID,ModuleRefID,PM,IsPlanned" EmptyDataText="No Data Found"
                                                                                                                Width="100%" OnRowDataBound="gvSunVisits_RowDataBound">
                                                                                                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                                                                <EmptyDataRowStyle Height="90%" HorizontalAlign="Center" VerticalAlign="Middle" Width="98%" />
                                                                                                                <Columns>
                                                                                                                    <asp:TemplateField HeaderText="Dest. Name">
                                                                                                                        <EditItemTemplate>
                                                                                                                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ModuleName") %>'></asp:TextBox>
                                                                                                                        </EditItemTemplate>
                                                                                                                        <HeaderStyle Width="25%" />
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:HyperLink ID="lnkModuleNameRef" runat="server" Target="_blank" Text='<%# Bind("ModuleName") %>'></asp:HyperLink>
                                                                                                                            <asp:Label ID="lblOtherModule" runat="server" CssClass="MainfontStyle" Text='<%# Bind("OtherDetails") %>'
                                                                                                                                Visible="False"></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:BoundField DataField="ModuleType" HeaderText="Dest. Type">
                                                                                                                        <HeaderStyle Width="10%" />
                                                                                                                    </asp:BoundField>
                                                                                                                    <asp:TemplateField HeaderText="Visited">
                                                                                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                                        <HeaderStyle Width="10%" />
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:RadioButtonList ID="rblIsVisited" runat="server" RepeatDirection="Horizontal" SelectedValue='<%# Bind("IsVisited") %>'>
                                                                                                                                <asp:ListItem Value="True">Yes</asp:ListItem>
                                                                                                                                <asp:ListItem Value="False">No</asp:ListItem>
                                                                                                                            </asp:RadioButtonList>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="FeedBack">
                                                                                                                        <EditItemTemplate>
                                                                                                                            &nbsp;
                                                                                                                        </EditItemTemplate>
                                                                                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:TextBox ID="txtFeedBack" runat="server" CssClass="inputs" Width="98%" Text='<%# Bind("VisitFeedBack") %>'></asp:TextBox>
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
                                                                                            <td colspan="3"><table id="tblMonVisits" runat="server" class="tblStyle" width="100%">
                                                                                                <tr>
                                                                                                    <td background="../Images/TableHead-BG.jpg" colspan="3" align="left">
                                                                                                        <asp:LinkButton ID="lnkbtnMonVisits" runat="server" CausesValidation="False" CssClass="FMTLinkFontStyle" OnClick="lnkbtnMonVisits_Click">LinkButton</asp:LinkButton></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="3"><asp:GridView ID="gvMonVisits" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                                                                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                                                                                                CellPadding="3" DataKeyNames="VisitID,ModuleRefID,PM,IsPlanned" EmptyDataText="No Data Found"
                                                                                                                Width="100%" OnRowDataBound="gvMonVisits_RowDataBound">
                                                                                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                                                        <EmptyDataRowStyle Height="90%" HorizontalAlign="Center" VerticalAlign="Middle" Width="98%" />
                                                                                                        <Columns>
                                                                                                            <asp:TemplateField HeaderText="Dest. Name">
                                                                                                                <EditItemTemplate>
                                                                                                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ModuleName") %>'></asp:TextBox>
                                                                                                                </EditItemTemplate>
                                                                                                                <HeaderStyle Width="25%" />
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:HyperLink ID="lnkModuleNameRef" runat="server" Target="_blank" Text='<%# Bind("ModuleName") %>'></asp:HyperLink>
                                                                                                                    <asp:Label ID="lblOtherModule" runat="server" CssClass="MainfontStyle" Text='<%# Bind("OtherDetails") %>'
                                                                                                                        Visible="False"></asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:BoundField DataField="ModuleType" HeaderText="Dest. Type">
                                                                                                                <HeaderStyle Width="10%" />
                                                                                                            </asp:BoundField>
                                                                                                            <asp:TemplateField HeaderText="Visited">
                                                                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                                <HeaderStyle Width="10%" />
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:RadioButtonList ID="rblIsVisited" runat="server" RepeatDirection="Horizontal" SelectedValue='<%# Bind("IsVisited") %>'>
                                                                                                                        <asp:ListItem Value="True">Yes</asp:ListItem>
                                                                                                                        <asp:ListItem Value="False">No</asp:ListItem>
                                                                                                                    </asp:RadioButtonList>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText="FeedBack">
                                                                                                                <EditItemTemplate>
                                                                                                                    &nbsp;
                                                                                                                </EditItemTemplate>
                                                                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:TextBox ID="txtFeedBack" runat="server" CssClass="inputs" Text='<%# Bind("VisitFeedBack") %>'
                                                                                                                        Width="98%"></asp:TextBox>
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
                                                                                            <td colspan="3">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="3">
                                                                                                <table id="tblTueVisits" runat="server" class="tblStyle" width="100%">
                                                                                                    <tr>
                                                                                                        <td background="../Images/TableHead-BG.jpg" colspan="3" align="left">
                                                                                                            <asp:LinkButton ID="lnkbtnTueVisits" runat="server" CausesValidation="False" CssClass="FMTLinkFontStyle" OnClick="lnkbtnTueVisits_Click">LinkButton</asp:LinkButton></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="3"><asp:GridView ID="gvTueVisits" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                                                                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                                                                                                CellPadding="3" DataKeyNames="VisitID,ModuleRefID,PM,IsPlanned" EmptyDataText="No Data Found"
                                                                                                                Width="100%" OnRowDataBound="gvTueVisits_RowDataBound">
                                                                                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                                                            <EmptyDataRowStyle Height="90%" HorizontalAlign="Center" VerticalAlign="Middle" Width="98%" />
                                                                                                            <Columns>
                                                                                                                <asp:TemplateField HeaderText="Dest. Name">
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ModuleName") %>'></asp:TextBox>
                                                                                                                    </EditItemTemplate>
                                                                                                                    <HeaderStyle Width="25%" />
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:HyperLink ID="lnkModuleNameRef" runat="server" Target="_blank" Text='<%# Bind("ModuleName") %>'></asp:HyperLink>
                                                                                                                        <asp:Label ID="lblOtherModule" runat="server" CssClass="MainfontStyle" Text='<%# Bind("OtherDetails") %>'
                                                                                                                            Visible="False"></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:BoundField DataField="ModuleType" HeaderText="Dest. Type">
                                                                                                                    <HeaderStyle Width="10%" />
                                                                                                                </asp:BoundField>
                                                                                                                <asp:TemplateField HeaderText="Visited">
                                                                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                                    <HeaderStyle Width="10%" />
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:RadioButtonList ID="rblIsVisited" runat="server" RepeatDirection="Horizontal" SelectedValue='<%# Bind("IsVisited") %>'>
                                                                                                                            <asp:ListItem Value="True">Yes</asp:ListItem>
                                                                                                                            <asp:ListItem Value="False">No</asp:ListItem>
                                                                                                                        </asp:RadioButtonList>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="FeedBack">
                                                                                                                    <EditItemTemplate>
                                                                                                                        &nbsp;
                                                                                                                    </EditItemTemplate>
                                                                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:TextBox ID="txtFeedBack" runat="server" CssClass="inputs" Text='<%# Bind("VisitFeedBack") %>'
                                                                                                                            Width="98%"></asp:TextBox>
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
                                                                                            <td colspan="3">
                                                                                                <table id="tblWedVisits" runat="server" class="tblStyle" width="100%">
                                                                                                    <tr>
                                                                                                        <td background="../Images/TableHead-BG.jpg" colspan="3" align="left">
                                                                                                            <asp:LinkButton ID="lnkbtnWedVisits" runat="server" CausesValidation="False" CssClass="FMTLinkFontStyle" OnClick="lnkbtnWedVisits_Click">LinkButton</asp:LinkButton></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="3"><asp:GridView ID="gvWedVisits" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                                                                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                                                                                                CellPadding="3" DataKeyNames="VisitID,ModuleRefID,PM,IsPlanned" EmptyDataText="No Data Found"
                                                                                                                Width="100%" OnRowDataBound="gvWedVisits_RowDataBound">
                                                                                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                                                            <EmptyDataRowStyle Height="90%" HorizontalAlign="Center" VerticalAlign="Middle" Width="98%" />
                                                                                                            <Columns>
                                                                                                                <asp:TemplateField HeaderText="Dest. Name">
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ModuleName") %>'></asp:TextBox>
                                                                                                                    </EditItemTemplate>
                                                                                                                    <HeaderStyle Width="25%" />
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:HyperLink ID="lnkModuleNameRef" runat="server" Target="_blank" Text='<%# Bind("ModuleName") %>'></asp:HyperLink>
                                                                                                                        <asp:Label ID="lblOtherModule" runat="server" CssClass="MainfontStyle" Text='<%# Bind("OtherDetails") %>'
                                                                                                                            Visible="False"></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:BoundField DataField="ModuleType" HeaderText="Dest. Type">
                                                                                                                    <HeaderStyle Width="10%" />
                                                                                                                </asp:BoundField>
                                                                                                                <asp:TemplateField HeaderText="Visited">
                                                                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                                    <HeaderStyle Width="10%" />
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:RadioButtonList ID="rblIsVisited" runat="server" RepeatDirection="Horizontal" SelectedValue='<%# Bind("IsVisited") %>'>
                                                                                                                            <asp:ListItem Value="True">Yes</asp:ListItem>
                                                                                                                            <asp:ListItem Value="False">No</asp:ListItem>
                                                                                                                        </asp:RadioButtonList>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="FeedBack">
                                                                                                                    <EditItemTemplate>
                                                                                                                        &nbsp;
                                                                                                                    </EditItemTemplate>
                                                                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:TextBox ID="txtFeedBack" runat="server" CssClass="inputs" Text='<%# Bind("VisitFeedBack") %>'
                                                                                                                            Width="98%"></asp:TextBox>
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
                                                                                            <td colspan="3">
                                                                                                <table id="tblThurVisits" runat="server" class="tblStyle" width="100%">
                                                                                                    <tr>
                                                                                                        <td background="../Images/TableHead-BG.jpg" colspan="3" align="left">
                                                                                                            <asp:LinkButton ID="lnkbtnThurVisits" runat="server" CausesValidation="False" CssClass="FMTLinkFontStyle" OnClick="lnkbtnThurVisits_Click">LinkButton</asp:LinkButton></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="3"><asp:GridView ID="gvThurVisits" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                                                                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                                                                                                CellPadding="3" DataKeyNames="VisitID,ModuleRefID,PM,IsPlanned" EmptyDataText="No Data Found"
                                                                                                                Width="100%" OnRowDataBound="gvThurVisits_RowDataBound">
                                                                                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                                                            <EmptyDataRowStyle Height="90%" HorizontalAlign="Center" VerticalAlign="Middle" Width="98%" />
                                                                                                            <Columns>
                                                                                                                <asp:TemplateField HeaderText="Dest. Name">
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ModuleName") %>'></asp:TextBox>
                                                                                                                    </EditItemTemplate>
                                                                                                                    <HeaderStyle Width="25%" />
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:HyperLink ID="lnkModuleNameRef" runat="server" Target="_blank" Text='<%# Bind("ModuleName") %>'></asp:HyperLink>
                                                                                                                        <asp:Label ID="lblOtherModule" runat="server" CssClass="MainfontStyle" Text='<%# Bind("OtherDetails") %>'
                                                                                                                            Visible="False"></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:BoundField DataField="ModuleType" HeaderText="Dest. Type">
                                                                                                                    <HeaderStyle Width="10%" />
                                                                                                                </asp:BoundField>
                                                                                                                <asp:TemplateField HeaderText="Visited">
                                                                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                                    <HeaderStyle Width="10%" />
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:RadioButtonList ID="rblIsVisited" runat="server" RepeatDirection="Horizontal" SelectedValue='<%# Bind("IsVisited") %>'>
                                                                                                                            <asp:ListItem Value="True">Yes</asp:ListItem>
                                                                                                                            <asp:ListItem Value="False">No</asp:ListItem>
                                                                                                                        </asp:RadioButtonList>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="FeedBack">
                                                                                                                    <EditItemTemplate>
                                                                                                                        &nbsp;
                                                                                                                    </EditItemTemplate>
                                                                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:TextBox ID="txtFeedBack" runat="server" CssClass="inputs" Text='<%# Bind("VisitFeedBack") %>'
                                                                                                                            Width="98%"></asp:TextBox>
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
                                                                                            <td colspan="3">
                                                                                                <table id="tblFriVisits" runat="server" class="tblStyle" width="100%">
                                                                                                    <tr>
                                                                                                        <td background="../Images/TableHead-BG.jpg" colspan="3" align="left">
                                                                                                            <asp:LinkButton ID="lnkbtnFriVisits" runat="server" CausesValidation="False" CssClass="FMTLinkFontStyle" OnClick="lnkbtnFriVisits_Click">LinkButton</asp:LinkButton></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="3"><asp:GridView ID="gvFriVisits" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                                                                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                                                                                                CellPadding="3" DataKeyNames="VisitID,ModuleRefID,PM,IsPlanned" EmptyDataText="No Data Found"
                                                                                                                Width="100%" OnRowDataBound="gvFriVisits_RowDataBound">
                                                                                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                                                            <EmptyDataRowStyle Height="90%" HorizontalAlign="Center" VerticalAlign="Middle" Width="98%" />
                                                                                                            <Columns>
                                                                                                                <asp:TemplateField HeaderText="Dest. Name">
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ModuleName") %>'></asp:TextBox>
                                                                                                                    </EditItemTemplate>
                                                                                                                    <HeaderStyle Width="25%" />
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:HyperLink ID="lnkModuleNameRef" runat="server" Target="_blank" Text='<%# Bind("ModuleName") %>'></asp:HyperLink>
                                                                                                                        <asp:Label ID="lblOtherModule" runat="server" CssClass="MainfontStyle" Text='<%# Bind("OtherDetails") %>'
                                                                                                                            Visible="False"></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:BoundField DataField="ModuleType" HeaderText="Dest. Type">
                                                                                                                    <HeaderStyle Width="10%" />
                                                                                                                </asp:BoundField>
                                                                                                                <asp:TemplateField HeaderText="Visited">
                                                                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                                    <HeaderStyle Width="10%" />
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:RadioButtonList ID="rblIsVisited" runat="server" RepeatDirection="Horizontal" SelectedValue='<%# Bind("IsVisited") %>'>
                                                                                                                            <asp:ListItem Value="True">Yes</asp:ListItem>
                                                                                                                            <asp:ListItem Value="False">No</asp:ListItem>
                                                                                                                        </asp:RadioButtonList>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="FeedBack">
                                                                                                                    <EditItemTemplate>
                                                                                                                        &nbsp;
                                                                                                                    </EditItemTemplate>
                                                                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:TextBox ID="txtFeedBack" runat="server" CssClass="inputs" Text='<%# Bind("VisitFeedBack") %>'
                                                                                                                            Width="98%"></asp:TextBox>
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
                                                                                            <td colspan="3">
                                                                                                <table id="tblSatVisits" runat="server" class="tblStyle" width="100%">
                                                                                                    <tr>
                                                                                                        <td background="../Images/TableHead-BG.jpg" colspan="3" align="left">
                                                                                                            <asp:LinkButton ID="lnkbtnSatVisits" runat="server" CausesValidation="False" CssClass="FMTLinkFontStyle" OnClick="lnkbtnSatVisits_Click">LinkButton</asp:LinkButton></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="3"><asp:GridView ID="gvSatVisits" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                                                                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                                                                                                CellPadding="3" DataKeyNames="VisitID,ModuleRefID,PM,IsPlanned" EmptyDataText="No Data Found"
                                                                                                                Width="100%" OnRowDataBound="gvSatVisits_RowDataBound">
                                                                                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                                                            <EmptyDataRowStyle Height="90%" HorizontalAlign="Center" VerticalAlign="Middle" Width="98%" />
                                                                                                            <Columns>
                                                                                                                <asp:TemplateField HeaderText="Dest. Name">
                                                                                                                    <EditItemTemplate>
                                                                                                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ModuleName") %>'></asp:TextBox>
                                                                                                                    </EditItemTemplate>
                                                                                                                    <HeaderStyle Width="25%" />
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:HyperLink ID="lnkModuleNameRef" runat="server" Target="_blank" Text='<%# Bind("ModuleName") %>'></asp:HyperLink>
                                                                                                                        <asp:Label ID="lblOtherModule" runat="server" CssClass="MainfontStyle" Text='<%# Bind("OtherDetails") %>'
                                                                                                                            Visible="False"></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:BoundField DataField="ModuleType" HeaderText="Dest. Type">
                                                                                                                    <HeaderStyle Width="10%" />
                                                                                                                </asp:BoundField>
                                                                                                                <asp:TemplateField HeaderText="Visited">
                                                                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                                    <HeaderStyle Width="10%" />
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:RadioButtonList ID="rblIsVisited" runat="server" RepeatDirection="Horizontal" SelectedValue='<%# Bind("IsVisited") %>'>
                                                                                                                            <asp:ListItem Value="True">Yes</asp:ListItem>
                                                                                                                            <asp:ListItem Value="False">No</asp:ListItem>
                                                                                                                        </asp:RadioButtonList>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="FeedBack">
                                                                                                                    <EditItemTemplate>
                                                                                                                        &nbsp;
                                                                                                                    </EditItemTemplate>
                                                                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:TextBox ID="txtFeedBack" runat="server" CssClass="inputs" Text='<%# Bind("VisitFeedBack") %>'
                                                                                                                            Width="98%"></asp:TextBox>
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
                                                                                            <td colspan="3">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="3" align="center" valign="middle">
                                                                                                &nbsp;<asp:ImageButton ID="btnSaveFeedBack" runat="server" AlternateText="Save FeedBack"
                                                                                                    CausesValidation="False" ImageUrl="~/Images/save_n.jpg" OnClick="btnSaveFeedBack_Click" Visible="False" /></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="center" colspan="3" valign="middle">
                                                                                                <asp:Label ID="lblfeedbackmsg" runat="server" Font-Bold="True" Font-Names="Arial"
                                                                                                Font-Size="13px" ForeColor="Green" Text="Visit Feedback Saved..." Visible="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="center" colspan="3" valign="middle">
                                                                                                <asp:Label ID="lblNoPlans" runat="server" CssClass="StyleNoData" Font-Bold="True"
                                                                                                    Font-Size="16px" Text="No approved plans found for this date..." Visible="False"></asp:Label></td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="Tr2">
                                                                            </tr>
                                                                            <tr id="Tr3">
                                                                            </tr>
                                                                        </table>
                                                <cc1:CalendarExtender ID="calextExpireDate" runat="server" PopupButtonID="imgPlanDate"
                                                    TargetControlID="txtPlanDate" Format="dd/MM/yyyy">
                                                </cc1:CalendarExtender>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ucTransButtons" EventName="btnSaveEvent" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="12" rowspan="1">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="12" rowspan="1">
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                    <table id="tblPlanFields" runat="server" background="../Images/BG-1.jpg" class="tblStyle" width="100%">
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
                                                            <td align="center" colspan="3" rowspan="6" valign="top">
                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                    <ContentTemplate>
                                                                        <table id="tblLeftCont" class="tblStyle" height="300" width="450">
                                                                            <tr>
                                                                                <td align="right" colspan="3" rowspan="3" valign="top">
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
                                                                                                <asp:Label ID="lblDayType" runat="server" CssClass="MainfontStyle" Text="Day Type"></asp:Label></td>
                                                                                            <td align="left">
                                                                                                <asp:DropDownList ID="ddlDayType" runat="server" AutoPostBack="True" CssClass="inputs"
                                                                                                    OnSelectedIndexChanged="ddlDayType_SelectedIndexChanged" Width="200px">
                                                                                                </asp:DropDownList></td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right">
                                                                                                <asp:Label ID="lblAddVDate" runat="server" CssClass="MainfontStyle" Text="Insert Plan In:"></asp:Label></td>
                                                                                            <td align="left"><asp:DropDownList ID="ddlPlanDate" runat="server" CssClass="inputs"
                                                                                                    Enabled="False" OnSelectedIndexChanged="ddlAddItem_SelectedIndexChanged" Width="200px">
                                                                                            </asp:DropDownList></td>
                                                                                            <td align="left">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right">
                                                                                                <asp:Label ID="lblSP" runat="server" CssClass="MainfontStyle" Text="Starting Point:"></asp:Label></td>
                                                                                            <td align="left">
                                                                                                <asp:TextBox ID="txtSP" runat="server" CssClass="inputs" MaxLength="100" ReadOnly="True"
                                                                                                    Width="195px"></asp:TextBox></td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right">
                                                                                                <asp:Label ID="lblST" runat="server" CssClass="MainfontStyle" Text="Starting Time:"></asp:Label></td>
                                                                                            <td align="left">
                                                                                                <asp:DropDownList ID="ddlHour" runat="server" CssClass="inputs" Enabled="False" Width="100px">
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
                                                                                                </asp:DropDownList><asp:DropDownList ID="ddlMinute" runat="server" CssClass="inputs"
                                                                                                    Enabled="False" Width="100px">
                                                                                                    <asp:ListItem Selected="True" Value="00">00</asp:ListItem>
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
                                                                                                </asp:DropDownList></td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right">
                                                                                                <asp:Label ID="lblAdd" runat="server" CssClass="MainfontStyle" Text="Add:"></asp:Label></td>
                                                                                            <td align="left">
                                                                                                <asp:DropDownList ID="ddlAddItem" runat="server" AutoPostBack="True" CssClass="inputs"
                                                                                                    Enabled="False" OnSelectedIndexChanged="ddlAddItem_SelectedIndexChanged" Width="200px">
                                                                                                </asp:DropDownList></td>
                                                                                            <td align="left">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right">
                                                                                                <asp:Label ID="lblEntityName" runat="server" CssClass="MainfontStyle" Text="Name:"
                                                                                                    Visible="False"></asp:Label></td>
                                                                                            <td align="left">
                                                                                                <asp:DropDownList ID="ddlAddRel" runat="server" AutoPostBack="True" CssClass="inputs"
                                                                                                    DataTextField="EntityName" DataValueField="EntityID" OnDataBound="ddlAddRel_DataBound"
                                                                                                    OnSelectedIndexChanged="ddlAddRel_SelectedIndexChanged" Visible="False" Width="200px">
                                                                                                </asp:DropDownList></td>
                                                                                            <td align="left">
                                                                                                <asp:RequiredFieldValidator ID="rfvddlAddRel" runat="server" ControlToValidate="ddlAddRel"
                                                                                                    Display="Dynamic" Enabled="False" ErrorMessage="Module name is required">*</asp:RequiredFieldValidator></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right">
                                                                                                <asp:Label ID="lblSubEntityName" runat="server" CssClass="MainfontStyle" Text="SubName:"
                                                                                                    Visible="False"></asp:Label></td>
                                                                                            <td align="left"><%--OnDataBound="lbProducts_DataBound"--%>
                                                                                                <asp:ListBox ID="lbSubModule" runat="server" CssClass="inputs" 
                                                                                                    SelectionMode="Multiple" Visible="False" Width="200px"></asp:ListBox></td>
                                                                                            <td align="left">
                                                                                                <asp:RequiredFieldValidator ID="rfvlbSubModule" runat="server" ControlToValidate="lbSubModule"
                                                                                                    Display="Dynamic" Enabled="False" ErrorMessage="Subname is required">*</asp:RequiredFieldValidator></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right">
                                                                                                <asp:Label ID="lblMentionOther" runat="server" CssClass="MainfontStyle" Text="Mention Other:"
                                                                                                    Visible="False"></asp:Label></td>
                                                                                            <td align="left">
                                                                                                <asp:TextBox ID="txtOthers" runat="server" CssClass="inputs" MaxLength="200" Visible="False"
                                                                                                    Width="195px"></asp:TextBox></td>
                                                                                            <td align="left">
                                                                                                <asp:RequiredFieldValidator ID="rfvtxtOthers" runat="server" ControlToValidate="txtOthers"
                                                                                                    Display="Dynamic" Enabled="False" ErrorMessage="Mention other is required">*</asp:RequiredFieldValidator></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right">
                                                                                                <asp:Label ID="Label7" runat="server" CssClass="MainfontStyle" Text="Shift Visit:"></asp:Label></td>
                                                                                            <td align="left">
                                                                                                <asp:RadioButtonList ID="rblVisitShift" runat="server" CssClass="MainfontStyle" Enabled="False"
                                                                                                    RepeatDirection="Horizontal">
                                                                                                    <asp:ListItem Value="0">AM</asp:ListItem>
                                                                                                    <asp:ListItem Selected="True" Value="1">PM</asp:ListItem>
                                                                                                </asp:RadioButtonList></td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right">
                                                                                                <asp:Label ID="lblDoubleVisit" runat="server" CssClass="MainfontStyle" Text="Double Visit:"></asp:Label></td>
                                                                                            <td align="left">
                                                                                                <asp:RadioButtonList ID="rblDoubleVisit" runat="server" CssClass="MainfontStyle"
                                                                                                    Enabled="False" RepeatDirection="Horizontal">
                                                                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                                                    <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                                                                                </asp:RadioButtonList></td>
                                                                                            <td>
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
                                                                        <asp:ObjectDataSource ID="odsSubMainItem" runat="server"></asp:ObjectDataSource>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                                &nbsp;
                                                            </td>
                                                            <td rowspan="6">
                                                            </td>
                                                            <td align="left" colspan="2" rowspan="6" valign="top">
                                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                    <ContentTemplate>
                                                                        <table id="tbtContR" class="tblStyle" height="300" width="370">
                                                                            <tr>
                                                                                <td align="left" colspan="3" rowspan="3" valign="top">
                                                                                    <table id="tblInnrR" width="100%">
                                                                                        <tr>
                                                                                            <td align="left" background="../Images/TableHead-BG.jpg" colspan="2" height="20"
                                                                                                valign="top">
                                                                                                <asp:Label ID="Label5" runat="server" CssClass="MainfontStyle" Text="Plan Scope"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td height="10">
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right">
                                                                                                <asp:Label ID="lblvisit" runat="server" CssClass="MainfontStyle" Text="Visit Type:"></asp:Label></td>
                                                                                            <td>
                                                                                                <asp:DropDownList ID="ddlVType" runat="server" CssClass="inputs" DataSourceID="odsVisitType"
                                                                                                    DataTextField="SubCode" DataValueField="SID" Enabled="False" Width="220px">
                                                                                                </asp:DropDownList></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td height="5">
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right" valign="middle">
                                                                                                <asp:Label ID="lblProducts" runat="server" CssClass="MainfontStyle" Text="Products:"></asp:Label></td>
                                                                                            <td valign="middle">
                                                                                                <asp:Panel ID="pnlProducts" runat="server" Height="160px" HorizontalAlign="Left"
                                                                                                    ScrollBars="Vertical" Width="100%">
                                                                                                    <asp:GridView ID="gvProducts" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                                                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="ProductID"
                                                                                                        DataSourceID="odsProducts" EmptyDataText="No Data Found" Enabled="False" OnDataBound="gvProducts_DataBound"
                                                                                                        OnRowDataBound="gvProducts_RowDataBound" PageSize="5" Width="200px">
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
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td height="5">
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right">
                                                                                                <asp:Label ID="lblMarktMat" runat="server" CssClass="MainfontStyle" Text="Marketing Materials:"></asp:Label></td>
                                                                                            <td align="left" valign="middle">
                                                                                                <asp:GridView ID="gvMM" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                                                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="SID"
                                                                                                    DataSourceID="odsMarketingMaterial" EmptyDataText="No Data Found" Enabled="False"
                                                                                                    OnDataBound="gvMM_DataBound" OnRowDataBound="gvMM_RowDataBound" Width="220px">
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
                                                                                                                <asp:TextBox ID="txtQuantity" runat="server" CssClass="inputs" onBlur="AdjustOne(this)"
                                                                                                                    Width="40px">0</asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                                                                                                        runat="server" ControlToValidate="txtQuantity" Display="Dynamic" ErrorMessage="Marketing materials is required">*</asp:RequiredFieldValidator>
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
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                            </td>
                                                                                            <td>
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
                                                            <td align="center" colspan="6" valign="middle">
                                                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:ValidationSummary ID="vsPlanEntry" runat="server" Font-Bold="True" Font-Names="Arial"
                                                                            Font-Size="12px" />
                                                                        <asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="13px"
                                                                            ForeColor="Green" Text="lblmsg" Visible="False"></asp:Label>
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
                                                            <td align="center" colspan="6" valign="middle">
                                                                <uc1:transbuttons id="ucTransButtons" runat="server"></uc1:transbuttons>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="txtPlanDate" EventName="TextChanged" />
                                                            <asp:AsyncPostBackTrigger ControlID="btnSaveFeedBack" EventName="Click" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
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
                            <tr>
                                <td align="left" colspan="3" rowspan="1" valign="top">
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

