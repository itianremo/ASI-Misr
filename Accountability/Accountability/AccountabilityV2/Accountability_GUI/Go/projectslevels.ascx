<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls, Version=1.0.2.226, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.Go.ProjectsLevels" CodeFile="ProjectsLevels.ascx.cs" %>
<link href="../Acc1.css" type="text/css" rel="stylesheet">
<table class="labelarea" id="Table3" cellspacing="0" cellpadding="0" width="100%"
    align="center" border="0">
</table>
<table id="Table5" style="width: 1083px; height: 684px" cellspacing="0" cellpadding="0"
    width="1083" align="center" border="0">
    <tr>
        <td>
            <table id="Table1" cellspacing="1" cellpadding="1" width="694" align="center" border="0">
                <tr>
                    <td>
                    </td>
                    <td class="errtable" align="center">
                        <asp:Table ID="tblErr" CellSpacing="0" Font-Names="Arial" Font-Size="9pt" HorizontalAlign="Center"
                            Visible="False" CellPadding="2" BorderWidth="0px" CssClass="errtable" Width="453px"
                            runat="server" ForeColor="Red">
                            <asp:TableRow VerticalAlign="Top" runat="server">
                                <asp:TableCell BackColor="#FFFFC0" BorderColor="White" Text="&lt;img src=&quot;../go/images/alrt_l.gif&quot; /&gt;"
                                    runat="server"></asp:TableCell>
                                <asp:TableCell BackColor="#FFFFC0" runat="server">
									<p class="MsoNormal">Project wasn’t deleted, it seems that some problem faces the 
										deletion operation
									</p>
									<p class="MsoNormal">
										<o:p>&nbsp;</o:p></p>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </td>
                </tr>
                <tr>
                    <td valign="top" rowspan="3">
                        <table id="Table8" style="width: 278px; height: 534px" cellspacing="5" cellpadding="5"
                            width="278" border="0">
                            <tr>
                                <td class="headertd">
                                    Projects hierarchy</td>
                            </tr>
                            <tr>
                                <td class="FunctionBlock">
                                    &nbsp;<table id="Table6" cellspacing="1" cellpadding="1" width="240" border="0">
                                        <tr>
                                            <td style="height: 495px" valign="top" height="495">
                                                <p>
                                                </p>
                                                <div style="overflow: auto; width: 250px; height: 99.85%">
                                                    <iewc:TreeView ID="TreeView1" runat="server" SystemImagesPath="/webctrl_client/1_0/treeimages/"></iewc:TreeView>
                                                </div>
                                                <p>
                                                </p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <cc1:SecButtons ID="btnSelectNode" CssClass="slectedbutton" Width="145px" runat="server"
                                                    RuleID="0" CausesValidation="False" Text="Get Element" OnClick="btnSelectNode_Click">
                                                </cc1:SecButtons></td>
                                        </tr>
                                    </table>
                                    <input id="hdnFlage" style="width: 71px; height: 22px" type="hidden" size="6" runat="server">
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top" height="100%">
                        <table id="Table9" height="100%" cellspacing="0" cellpadding="0" width="200" border="0">
                            <tr>
                                <td>
                                    <table id="koko" style="width: 440px; height: 246px" height="246" cellspacing="5"
                                        cellpadding="5" width="440" border="0">
                                        <tr>
                                            <td class="headertd" style="height: 26px">
                                                <asp:Label ID="Label1" runat="server"></asp:Label>&nbsp;Details</td>
                                        </tr>
                                        <tr>
                                            <td class="whitetd">
                                                <table id="Table2" cellspacing="1" cellpadding="1" width="398" border="0" class="FunctionBlock">
                                                    <tr>
                                                        <td class="formslabels" style="height: 15px" valign="top" align="right" width="89">
                                                            <font class="formslabels" size="2">Parent </font>
                                                        </td>
                                                        <td style="height: 15px" valign="top" align="left" width="160">
                                                            <asp:DropDownList ID="DropDownListAllPrjLevels" CssClass="inputtext" runat="server"
                                                                Height="20px" DataValueField="ProjectElementID" DataTextField="ProjectElementName"
                                                                DataSource="<%# dsProjectsLevels1 %>">
                                                            </asp:DropDownList></td>
                                                        <td style="height: 15px" valign="top" align="left" width="139">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formslabels" valign="top" align="right">
                                                            <font class="formslabels" size="2">* Name<%--</STRONG>--%></font></td>
                                                        <td valign="top" align="right">
                                                            <p align="left">
                                                                <asp:TextBox ID="txtElementName" CssClass="inputtext" Width="190px" runat="server"
                                                                    MaxLength="20"></asp:TextBox><font size="2"></font></p>
                                                        </td>
                                                        <td valign="top" align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="errmsg" runat="server"
                                                                ControlToValidate="txtElementName" ErrorMessage="Required" BackColor="Transparent"
                                                                ForeColor="Brown">Required</asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formslabels" style="height: 83px" valign="top" align="right">
                                                            <p>
                                                                <font class="formslabels" size="2">Description</font>
                                                            </p>
                                                        </td>
                                                        <td style="height: 83px" valign="top" align="right" colspan="2">
                                                            <p align="left">
                                                                <asp:TextBox ID="txtElementDescription" CssClass="inputtext" Width="190px" runat="server"
                                                                    Rows="5" TextMode="MultiLine" Height="90px"></asp:TextBox></p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="bottom" colspan="4" height="30">
                                                            <p align="center">
                                                                <cc1:SecButtons ID="ButtonNewLevel" CssClass="stdNewbtn" runat="server" RuleID="0"
                                                                    CausesValidation="False" ToolTip="New Projects Level" OnClick="ButtonNewLevel_Click">
                                                                </cc1:SecButtons><cc1:SecButtons ID="ButtonAddLevel" Visible="False" CssClass="stdSavebtn"
                                                                    runat="server" RuleID="0" ToolTip="Add" OnClick="ButtonAddLevel_Click"></cc1:SecButtons>
                                                                <cc1:SecButtons ID="ButtonUpdateLevel" Visible="False" CssClass="stdsavebtn" runat="server"
                                                                    RuleID="0" ToolTip="Update" OnClick="ButtonUpdateLevel_Click"></cc1:SecButtons>
                                                                <cc1:SecButtons ID="btnDelete" CssClass="stdDeletebtn" runat="server" RuleID="0"
                                                                    CausesValidation="False" ToolTip="Delete" OnClick="btnDelete_Click"></cc1:SecButtons></p>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <input id="hdnUpdateFlage" style="width: 93px; height: 22px" type="hidden" size="10"
                                                    runat="server">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" height="100%">
                                    <table id="TABLE7" style="width: 381px; height: 250px" height="250" cellspacing="5"
                                        cellpadding="5" width="381" border="0" runat="server">
                                        <tr>
                                            <td class="headertd">
                                                <asp:Label ID="Label2" runat="server"></asp:Label>&nbsp;Assigned Projects</td>
                                        </tr>
                                        <tr>
                                            <td class="whitetd" height="100%">
                                                <table id="Table4" height="100%" cellspacing="1" cellpadding="1" width="393" align="center"
                                                    border="0" class="FunctionBlock">
                                                    <tr>
                                                        <td style="height: 18px" valign="bottom">
                                                            <p align="center">
                                                                <asp:DropDownList ID="DropDownListProjects" CssClass="inputtext" runat="server">
                                                                </asp:DropDownList></p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 258px">
                                                            <div>
                                                                <table style="width: 408px" cellspacing="0" border="0">
                                                                    <tr class="headertd">
                                                                        <td style="width: 359px; height: 20px">
                                                                            Project Name</td>
                                                                        <td style="width: 28px; height: 20px">
                                                                            Select</td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <div style="overflow: auto; width: 411px; height: 184px">
                                                                <asp:DataGrid ID="dgProjects" Width="408px" runat="server" DataSource="<%# dsProjects1 %>"
                                                                    ShowHeader="False" DataMember="GEN_Projects" AutoGenerateColumns="False">
                                                                    <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                                                                    <ItemStyle CssClass="bsnormaltd"></ItemStyle>
                                                                    <HeaderStyle CssClass="headertd"></HeaderStyle>
                                                                    <Columns>
                                                                        <asp:BoundColumn Visible="False" DataField="projectID" SortExpression="projectID"
                                                                            HeaderText="projectID"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="ProjectName" SortExpression="ProjectName" HeaderText="Project Name">
                                                                            <HeaderStyle Width="80%"></HeaderStyle>
                                                                        </asp:BoundColumn>
                                                                        <asp:TemplateColumn>
                                                                            <HeaderStyle Width="20px"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                    <PagerStyle CssClass="bsFootertd"></PagerStyle>
                                                                </asp:DataGrid></div>
                                                            <p>
                                                            </p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <p align="center">
                                                                <cc1:SecButtons ID="AddProjectToElm" CssClass="stdAddProject" runat="server" RuleID="0"
                                                                    CausesValidation="False" ToolTip="Add Selected Project" OnClick="AddProjectToElm_Click">
                                                                </cc1:SecButtons>&nbsp;
                                                                <cc1:SecButtons ID="ButtonRmvPrjFrmElm" CssClass="stdRemoveProject" runat="server"
                                                                    RuleID="0" CausesValidation="False" ToolTip="Remove Selected Project" OnClick="ButtonRmvPrjFrmElm_Click">
                                                                </cc1:SecButtons></p>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <div align="center">
            </div>
        </td>
    </tr>
</table>
