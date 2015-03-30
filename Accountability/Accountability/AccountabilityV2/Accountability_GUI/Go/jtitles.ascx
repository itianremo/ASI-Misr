<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.Go.JTitles" CodeFile="JTitles.ascx.cs" %>
<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation" %>
<link href="../Acc1.css" type="text/css" rel="stylesheet">
  <script language="javascript">
function closePanel()
		{
			//CloseEmailsWindow('close');
			//document.getElementById('divPanel').style.visibility="hidden";	
			toggleLayer('divPanel','none');
			UncheckAllMailCheckBoxes();
		}
		function toggleLayer(whichLayer,action1)
		{
   
			var elem, vis;
			if(document.getElementById) // this is the way the standards work
			elem = document.getElementById(whichLayer);
			else if(document.all) // this is the way old msie versions work
			elem = document.all[whichLayer];
			else if(document.layers) // this is the way nn4 works
			elem = document.layers[whichLayer];
			vis = elem.style;
		    vis.display=action1;
		}
		</script>
<table class="labelarea" id="Table3" cellspacing="0" cellpadding="0" width="100%"
    align="center" border="0">
</table>
<table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
        <td style="height: 47px" valign="top" align="left" colspan="2">
            <p align="center">
                <asp:Table ID="tblErr" Height="24px" runat="server" Width="453px" CellPadding="2"
                    BorderWidth="0px" CssClass="errtable" Visible="False" HorizontalAlign="Center"
                    Font-Size="9pt" Font-Names="Arial" CellSpacing="0" ForeColor="Red">
                    <asp:TableRow VerticalAlign="Top" runat="server">
                        <asp:TableCell BackColor="#FFFFC0" BorderColor="White" Text="&lt;img src=&quot;../go/images/alrt_l.gif&quot; /&gt;" runat="server"></asp:TableCell>
                        <asp:TableCell BackColor="#FFFFC0" runat="server"></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </p>
        </td>
    </tr>
    <tr>
        <td style="width: 596px">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 596px; height: 507px;" valign="top" align="center">
            <table id="Table6" style="width: 566px; height: 472px" cellspacing="0" cellpadding="10"
                width="566" border="0" class="FunctionBlock">
                <tr>
                    <td class="headertd" style="width: 562px">
                        Job titles
                    </td>
                </tr>
                <tr>
                    <td style="width: 562px">
                        <table id="Table7" height="250" cellpadding="5">
                            <tr>
                                <td valign="top">
                                    <div>
                                        <table cellspacing="0" class="whitetd">
                                            <tr>
                                                <td style="width: 23px; height: 20px">
                                                    ID</td>
                                                <td style="width: 428px; height: 20px">
                                                    Job Title</td>
                                                <td style="width: 55px; height: 20px">
                                                    Select</td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="overflow: auto; width: 512px; height: 300px">
                                        <asp:DataGrid ID="dgJobTitles" runat="server" Width="512px" CellPadding="2" BorderWidth="1px"
                                            BorderColor="White" AutoGenerateColumns="False" DataMember="GEN_JobTitles" DataSource="<%# dataView1 %>"
                                            BorderStyle="None" SelectedIndex="0" ShowHeader="False">
                                            <SelectedItemStyle Font-Bold="True" Wrap="False" HorizontalAlign="Left" ForeColor="White"
                                                CssClass="offday" VerticalAlign="Middle"></SelectedItemStyle>
                                            <EditItemStyle Wrap="False"></EditItemStyle>
                                            <AlternatingItemStyle Wrap="False" HorizontalAlign="Left" CssClass="bsalternativetd"
                                                VerticalAlign="Middle"></AlternatingItemStyle>
                                            <ItemStyle Wrap="False" HorizontalAlign="Left" CssClass="bsnormaltd" VerticalAlign="Middle">
                                            </ItemStyle>
                                            <HeaderStyle HorizontalAlign="Left" CssClass="headertd" VerticalAlign="Middle"></HeaderStyle>
                                            <Columns>
                                                <asp:BoundColumn DataField="JobTitleID" SortExpression="JobTitleID" HeaderText="ID">
                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                    <ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                    <FooterStyle Wrap="False"></FooterStyle>
                                                </asp:BoundColumn>
                                                <asp:TemplateColumn SortExpression="JobName" HeaderText="Job Title">
                                                    <HeaderStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" OnClick="LoadResp" runat="server" CssClass="gridLink"
                                                            CausesValidation="False" Text='<%# DataBinder.Eval(Container, "DataItem.JobName") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <FooterStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.JobName") %>'>
                                                        </asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn>
                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                    <ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                    <FooterStyle Wrap="False"></FooterStyle>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn Visible="False" DataField="JobDescription" SortExpression="JobDescription"
                                                    HeaderText="JobDescription">
                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                    <FooterStyle Wrap="False"></FooterStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn Visible="False" DataField="IsActive" SortExpression="IsActive" HeaderText="IsActive">
                                                </asp:BoundColumn>
                                            </Columns>
                                            <PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
                                        </asp:DataGrid></div>
                                </td>
                            </tr>
                            <tr>
                                <td valign="bottom" align="center" style="height: 36px">
                                    <cc1:SecButtons ID="NewJob" runat="server" CssClass="stdNewJobTitle" ToolTip="Add New Job Title"
                                        CausesValidation="False" RuleID="5012" OnClick="NewJob_Click"></cc1:SecButtons>&nbsp;<cc1:SecButtons
                                            ID="EditJob" runat="server" CssClass="stdEditbtn" ToolTip="Edit Selected Job title"
                                            CausesValidation="False" RuleID="5013" OnClick="EditJob_Click"></cc1:SecButtons>&nbsp;<cc1:SecButtons
                                                ID="DeleteJob" runat="server" CssClass="stdDeletebtn" ToolTip="Delete Selected Job Titles"
                                                CausesValidation="False" RuleID="5014" OnClick="DeleteJob_Click"></cc1:SecButtons>
                                    <cc1:SecButtons ID="OpenCloseJobtitle" runat="server" CssClass="stdCompletebtn" ToolTip="Open/Close JobTitle"
                                        CausesValidation="False" RuleID="100" OnClick="OpenCloseJobtitle_Click"></cc1:SecButtons></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
        <td style="height: 507px" valign="top" align="center">
            <table id="Table8" style="width: 589px; height: 480px" cellspacing="0" cellpadding="10"
                width="589" align="center" border="0" class="FunctionBlock">
                <tr>
                    <td class="headertd">
                        <asp:Label ID="Joblbl" Height="17px" runat="server" Width="300px"></asp:Label></td>
                </tr>
                <tr>
                    <td align="center">
                        <table id="Table9" style="width: 562px; height: 394px" height="394" cellpadding="5"
                            align="center">
                            <tr>
                                <td valign="top" align="center" style="height: 368px">
                                    <div style="width: 100%">
                                        <table style="height: 20px" cellspacing="0" width="100%" class="whitetd" >
                                            <tr>
                                                <td style="width: 10%; height: 20px">
                                                    Priority</td>
                                                <td style="width: 80%; height: 20px">
                                                    responsibility Name</td>
                                                <td style="width: 10%; height: 20px" align="left">
                                                    Select</td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="overflow: auto; height: 300px">
                                        <asp:DataGrid ID="dgResponsiblity" runat="server" Width="100%" CellPadding="2" BorderWidth="1px"
                                            BorderColor="White" AutoGenerateColumns="False" DataMember="GEN_Responsibilities"
                                            DataSource="<%# dsResponsblities1 %>" BorderStyle="None" SelectedIndex="0" ShowHeader="False">
                                            <SelectedItemStyle Font-Bold="True" ForeColor="White" CssClass="offday"></SelectedItemStyle>
                                            <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                                            <ItemStyle CssClass="bsnormaltd"></ItemStyle>
                                            <HeaderStyle CssClass="headertd"></HeaderStyle>
                                            <Columns>
                                                <asp:BoundColumn Visible="False" DataField="ResponsID" SortExpression="ResponsID"
                                                    HeaderText="ResponsID">
                                                    <ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="ResponsOrder" SortExpression="ResponsOrder" HeaderText="Priority">
                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                    <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" VerticalAlign="Middle">
                                                    </ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="Responsibility Name">
                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" Width="80%" VerticalAlign="Middle"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton2" OnClick="onRespClick" runat="server" Width="67px"
                                                            CssClass="gridLink" CausesValidation="False" Text='<%# DataBinder.Eval(Container, "DataItem.ResponsName")%>'>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ResponsName") %>'>
                                                        </asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Select">
                                                    <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" VerticalAlign="Middle">
                                                    </ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox2" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn Visible="False" DataField="IsActive" SortExpression="IsActive" HeaderText="IsActive">
                                                </asp:BoundColumn>
                                            </Columns>
                                            <PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
                                        </asp:DataGrid></div>
                                </td>
                            </tr>
                            <tr>
                                <td valign="bottom" align="center">
                                    &nbsp;<cc1:SecButtons ID="NewRes" runat="server" CssClass="stdNewResponsibility" ToolTip="Add New responsibility"
                                        CausesValidation="False" RuleID="5018" OnClick="NewRes_Click"></cc1:SecButtons>&nbsp;<cc1:SecButtons
                                            ID="EditRespBtn" runat="server" CssClass="stdeditbtn" ToolTip="Edit responsibility"
                                            CausesValidation="False" RuleID="5021" OnClick="EditRespBtn_Click"></cc1:SecButtons>&nbsp;<cc1:SecButtons
                                                ID="DeleteRespBtn" runat="server" CssClass="stdDeletebtn" ToolTip="Delete Selectedresponsibilities"
                                                CausesValidation="False" RuleID="5020" OnClick="DeleteRespBtn_Click"></cc1:SecButtons>
                                    <cc1:SecButtons ID="OpenCloseResp" runat="server" CssClass="stdCompletebtn" ToolTip="Open/Close responsibility"
                                        CausesValidation="False" RuleID="100" OnClick="OpenCloseResp_Click"></cc1:SecButtons>
                        <asp:Button ID="btnCopyResponsibility" runat="server" Text="Copy Resp." OnClick="btnCopyResponsibility_Click" CausesValidation="False" Height="27px" ToolTip="Copy Responsibilites from another Job Title" Width="80px" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
        <td align="center">
            <table id="TABLE5" style="width: 529px; height: 234px" height="234" cellspacing="0"
                cellpadding="3" width="529" align="center" border="0" runat="server">
                <tr>
                    <td style="width: 548px; height: 58px" align="center" colspan="3" height="58">
                        <p>
                            <asp:Label ID="Label1" runat="server" CssClass="formslabels" Visible="False">Label</asp:Label></p>
                        <p>
                            <asp:Label ID="LblAddJob" runat="server" CssClass="formslabels" Visible="False">Message</asp:Label></p>
                    </td>
                </tr>
                <tr valign="top">
                    <td class="formslabels" style="width: 132px; height: 28px;" align="right">
                        <asp:Label ID="lblName" runat="server" Visible="False">Name </asp:Label></td>
                    <td style="width: 22px; height: 28px;">
                        <p>
                            <asp:TextBox ID="NewJobTitle" runat="server" Width="264px" CssClass="inputtext" Visible="False"
                                MaxLength="50"></asp:TextBox></p>
                    </td>
                    <td style="width: 159px; height: 28px;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="errmsg"
                            Font-Size="Smaller" ControlToValidate="NewJobTitle" ErrorMessage="Required" BackColor="Transparent">Required</asp:RequiredFieldValidator></td>
                </tr>
                <tr valign="top">
                    <td class="formslabels" style="width: 132px; height: 88px" align="right">
                        &nbsp;
                        <asp:Label ID="lblDescription" runat="server" Visible="False">Description</asp:Label></td>
                    <td style="width: 22px; height: 88px">
                        <asp:TextBox ID="NewJobTitledescrp" runat="server" Width="263px" CssClass="inputtext"
                            Visible="False" TextMode="MultiLine" Columns="30" Rows="5"></asp:TextBox></td>
                    <td style="width: 159px; height: 88px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="formslabels" style="width: 132px; height: 20px" align="right">
                        <asp:Label ID="LabelPeriority" runat="server" Visible="False">Priority</asp:Label></td>
                    <td style="width: 22px; height: 20px">
                        <asp:TextBox ID="TextBoxPeriority" runat="server" Width="42px" CssClass="inputtext"
                            Visible="False" MaxLength="3"></asp:TextBox></td>
                    <td style="width: 159px; height: 20px">
                        <asp:RangeValidator ID="RangeValidator1" runat="server" Font-Size="Smaller" ControlToValidate="TextBoxPeriority"
                            ErrorMessage="Integers Only(1-100)" Type="Integer" MinimumValue="1" MaximumValue="100"></asp:RangeValidator></td>
                </tr>
                <tr>
                    <td style="width: 548px; height: 35px;" align="left" colspan="3">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                            ID="SaveJobTitle" runat="server" CssClass="stdSavebtn" Visible="False" ToolTip="Save"
                            OnClick="SaveJobTitle_Click"></asp:Button>
                        &nbsp;
                        <asp:Button ID="Cancel" runat="server" CssClass="stdCancelbtn" Visible="False" ToolTip="Cancel"
                            CausesValidation="False" OnClick="Cancel_Click"></asp:Button>
                        </td>
                </tr>
                
            </table>
            <asp:TextBox ID="PassedJobID" runat="server" Width="35px" Visible="False">Hidden JobID</asp:TextBox>
            <p>
            </p>
            <p>
                &nbsp;</p>
        </td>
    </tr>
    <tr>
                    <td align="center" colspan="1" style="width: 548px; height: 35px">
                      
                                            <div  id="divPanel" runat="server" style="width: auto; position: absolute; center: 22px; top: 399px;" align="center" class="FunctionBlock">
                                                <asp:Panel ID="Panel1" runat="server" Height="250" Width="500">
                                                    <table id="Table4" style="width: 500px; height: 250px; text-align: center" cellspacing="0"
                                                        cellpadding="0" width="500" align="center" border="0">
                                                        <tr>
                                                            <td align="center"  style="width: 500px; height: 30px">
                                                                <table id="Table10" cellspacing="0" cellpadding="0" border="0" style="width: 100%; height: 100%">
                                                                    <tr>
                                                                        <td style="width: 90px">
                                                                           Job title
                                                                        </td>
                                                                        <td style="width: 400px">
                                                                            <asp:DropDownList ID="ddlJobTitles" runat="server" Width="350px" AutoPostBack="True" OnSelectedIndexChanged="ddlJobTitles_SelectedIndexChanged">
                                                                            </asp:DropDownList></td>
                                                                        
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div style="overflow: auto; height: 150px">
                                                                
                                                                   <asp:DataGrid ID="dgResponsiblity2" runat="server" Width="100%" CellPadding="2" BorderWidth="1px"
                                            BorderColor="White" AutoGenerateColumns="False" DataMember="GEN_Responsibilities"
                                            DataSource="<%# dsResponsblities1 %>" BorderStyle="None" SelectedIndex="0" ShowHeader="False">
                                            <SelectedItemStyle Font-Bold="True" ForeColor="White" CssClass="offday"></SelectedItemStyle>
                                            <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                                            <ItemStyle CssClass="bsnormaltd"></ItemStyle>
                                            <HeaderStyle CssClass="headertd"></HeaderStyle>
                                            <Columns>
                                                <asp:BoundColumn Visible="False" DataField="ResponsID" SortExpression="ResponsID"
                                                    HeaderText="ResponsID">
                                                    <ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="ResponsOrder" SortExpression="ResponsOrder" HeaderText="Priority">
                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                    <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" VerticalAlign="Middle">
                                                    </ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="Responsibility Name">
                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" Width="80%" VerticalAlign="Middle"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton2" OnClick="onRespClick" runat="server" Width="67px"
                                                            CssClass="gridLink" CausesValidation="False" Text='<%# DataBinder.Eval(Container, "DataItem.ResponsName")%>'>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ResponsName") %>'>
                                                        </asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Select">
                                                    <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" VerticalAlign="Middle">
                                                    </ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox2" runat="server" Checked=true></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn Visible="False" DataField="IsActive" SortExpression="IsActive" HeaderText="IsActive">
                                                </asp:BoundColumn>
                                            </Columns>
                                            <PagerStyle CssClass="bsFootertd" Mode="NumericPages"></PagerStyle>
                                        </asp:DataGrid>
                                                                    
                                                                    </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 500px; height: 52px;" align="center">
                                                                <p>
                                                                    &nbsp;
                                                                    <asp:Button ID="btnAddcopyResponsibilities" runat="server" Text="Add Resposibilities" CssClass="slectedbutton" OnClick="btnAddcopyResponsibilities_Click" CausesValidation="False" ToolTip="Copy Selected Resposibilities from selected job title">
                                                                    </asp:Button>&nbsp;
                                                                    <asp:Button ID="btnCloseCopy" runat="server" Text="Close" CausesValidation="False" CssClass="slectedbutton" OnClick="btnCloseCopy_Click" ToolTip="Close" /></p>
                                                                <p>
                                                                    <asp:Label ID="lblCopyResponsibilities" runat="server" Visible="False" Width="304px" CssClass="formslabels"> please select Responsibilities</asp:Label></p>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </div>
                                        
                    </td>
                </tr>
</table>
