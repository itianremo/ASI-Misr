<%@ Control Language="c#" Inherits="TSN.ERP.WebGUI.Go.ElementsDetails" CodeFile="ElementsDetails.ascx.cs" %>
<%@ Register TagPrefix="cc1" Namespace="TSN.ERP.WebGUI.Navigation" %>
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
                    <td class="errtable" align="center" colspan=2>
                        <asp:Table ID="tblErr" runat="server" Width="453px" CssClass="errtable" BorderWidth="0px"
                            CellPadding="2" Visible="False" HorizontalAlign="Center" Font-Size="9pt" Font-Names="Arial"
                            CellSpacing="0" ForeColor="Red">
                            <asp:TableRow VerticalAlign="Top" runat="server">
                                <asp:TableCell BackColor="#FFFFC0" BorderColor="White" Text="&lt;img src=&quot;../go/images/alrt_l.gif&quot; /&gt;" runat="server"></asp:TableCell>
                                <asp:TableCell BackColor="#FFFFC0" runat="server">
									<p class="MsoNormal">Department wasn’t deleted, this maybe caused by one of the 
										following reasons:</p>
									<ul style='margin-top:0cm' type="disc">
										<li class="MsoNormal" style='mso-list:l0 level1 lfo1;tab-stops:list 36.0pt'>
											Department might have Employees assigned to it.
										</li>
										<li class="MsoNormal" style='mso-list:l0 level1 lfo1;tab-stops:list 36.0pt'>
											Department might have job titles assigned to it</li>
									</ul>
									<p class="MsoNormal">
										<o:p>&nbsp;</o:p></p>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </td>
                </tr>
                <tr>
                    <td valign="top" rowspan="3">
                        <table style="width: 278px; height: 644px" cellspacing="5" cellpadding="5" width="278"
                            border="0" class="FunctionBlockTable">
                            <tr>
                                <td class="headertd">
                                                Department hierarchy
                                </td>
                                </tr>
                            <tr>
                                <td style="height:20px" class="headertd"><cc1:SecButtons ID="btnSelectNode" runat="server" Width="145px" CssClass="slectedbutton"
                                                    Text="Get Element" CausesValidation="False" RuleID="5029" OnClick="btnSelectNode_Click" ToolTip="Get information about selected department">
                                                </cc1:SecButtons>
                                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table id="Table6" cellspacing="1" cellpadding="1" width="240" border="0">
                                        <tr>
                                            <td style="height: 501px" valign="top" height="501">
                                                <p>
                                                </p>
                                                <div style="overflow: auto; width: 250px; height: 100.14%;color:White">
                                                    <!--<div align="center" style="vertical-align:top; overflow:auto; Height=100%;  ">-->
                                                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                                </div>
                                                <p>
                                                </p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top" height="100%">
                        <table height="100%" cellspacing="0" cellpadding="0" width="200" border="0">
                            <tr>
                                <td>
                                    <table id="koko" style="width: 475px; height: 330px"  cellspacing="5"
                                        cellpadding="5" width="475" border="0" class="FunctionBlockTable">
                                        <tr>
                                            <td class="headertd" style="height: 26px">
                                               <asp:Label ID="Label1" runat="server"></asp:Label>&nbsp;Details</td>
                                        </tr>
                                        <tr>
                                            <td class="headertd" style="height: 20px">
                                                 <cc1:SecButtons
                                                                        ID="ButtonAddComElm" runat="server" CssClass="stdSavebtn" Visible="False" RuleID="5031"
                                                                        ToolTip="Add" OnClick="ButtonAddComElm_Click"></cc1:SecButtons><cc1:SecButtons ID="ButtonUpdateComElm" runat="server" CssClass="stdsavebtn" Visible="False"
                                                                    RuleID="5032" ToolTip="Update" OnClick="ButtonUpdateComElm_Click"></cc1:SecButtons><cc1:SecButtons ID="btnDelete" runat="server" CssClass="stdDeletebtn" CausesValidation="False"
                                                                    RuleID="5033" ToolTip="Delete" OnClick="btnDelete_Click"></cc1:SecButtons><cc1:SecButtons ID="Button4" runat="server" CssClass="stdNewbtn" CausesValidation="False"
                                                                    RuleID="5031" ToolTip="New Division" OnClick="Button4_Click"></cc1:SecButtons></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table id="Table2" cellspacing="1" cellpadding="1" width="398" border="0">
                                                    <tr>
                                                        <td class="formslabels">
                                                            <font class="formslabelsBlack" size="2">Parent</font>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownListAllCompElm" runat="server" Width="210px" CssClass="inputtextControlB"
                                                                DataSource="<%# dsCompanyElements %>" DataTextField="CEName" DataValueField="CompElmentID"
                                                                Height="20px">
                                                            </asp:DropDownList></td>
                                                        <td style="height: 12px" valign="top" align="left" width="139">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formslabels">
                                                            <font class="formslabelsBlack" size="2">*Name</font>
                                                        </td>
                                                        <td>
                                                            <p align="left">
                                                                <asp:TextBox ID="txtElementName" runat="server" Width="210px" CssClass="inputtextControlB"
                                                                    MaxLength="40" OnTextChanged="txtElementName_TextChanged"></asp:TextBox></p>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="errmsg"
                                                                ForeColor="Brown" BackColor="Transparent" ErrorMessage="Required" ControlToValidate="txtElementName">Required</asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formslabels">
                                                            <font class="formslabelsBlack">Manager</font>
                                                        </td>
                                                        <td>
                                                            <p align="left">
                                                                <asp:DropDownList ID="dlpManager" runat="server" Width="210px" CssClass="inputtextControlB"
                                                                    DataSource="<%# dsEmployee1 %>" DataTextField="Fullname" DataValueField="ContactID"
                                                                    DataMember="GEN_Employees">
                                                                </asp:DropDownList></p>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formslabelsBlack">
                                                            Level</td>
                                                        <td>
                                                            <p align="left">
                                                                <asp:DropDownList ID="DropDownListLevel" runat="server" Width="210px" CssClass="inputtextControlB"
                                                                    DataSource="<%# dsCompanyElementLevels %>" DataTextField="CELName" DataValueField="CEL_ID">
                                                                </asp:DropDownList></p>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formslabelsBlack">
                                                            <p>
                                                                <font class="formslabelsBlack">Description</font>
                                                            </p>
                                                        </td>
                                                        <td>
                                                            <p align="left">
                                                                <asp:TextBox ID="txtElementDescription" runat="server" Width="210px" 
                                                                    TextMode="MultiLine" Rows="5" Height="90px"></asp:TextBox></p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="bottom" colspan="4" height="30">
                                                            <p align="center">
                                                                &nbsp; &nbsp;
                                                            </p>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" height="100%">
                                    <table id="TABLE7" style="width: 475px; height: 204px" height="204" cellspacing="5"
                                        cellpadding="5" width="412" border="0" runat="server" class="FunctionBlockTable">
                                         <tr>
                                            <td class="headertd">
                                            <asp:Label ID="Label2" runat="server"></asp:Label>&nbsp;Assigned Job Titles</td>
                                            </tr>
                                        <tr>
                                            <td class="headertd" style="height:20px">
                                                                <cc1:SecButtons ID="AddJobTileToComElm" runat="server" CssClass="stdAddbtn" CausesValidation="False"
                                                                    RuleID="5023" ToolTip="Add Selected Job Title" OnClick="AddJobTileToComElm_Click">
                                                                </cc1:SecButtons><cc1:SecButtons ID="ButtonRemoveJobTitle" runat="server" CssClass="stdRemovebtn"
                                                                    CausesValidation="False" RuleID="5024" ToolTip="Remove Selected Job Title" OnClick="ButtonRemoveJobTitle_Click">
                                                                </cc1:SecButtons></td>
                                        </tr>
                                        <tr>
                                            <td height="100%">
                                                <table id="Table4" height="100%" cellspacing="1" cellpadding="1" width="393" align="center"
                                                    border="0">
                                                    <tr>
                                                        <td style="height: 22px" valign="bottom">
                                                            <p align="center">
                                                                <asp:DropDownList ID="DropDownListJobTitles" runat="server" CssClass="inputtext"
                                                                    DataTextField="JobName" DataValueField="JobTitleID">
                                                                </asp:DropDownList></p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="100%">
                                                            <div>
                                                                <table style="width: 408px; height: 24px" cellspacing="0" border="0">
                                                                    <tr class="whitetd">
                                                                        <td style="width: 293px; height: 20px">
                                                                            Job Title</td>
                                                                        <td style="width: 55px; height: 20px">
                                                                            Select</td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <div style="overflow: auto; height: 100px">
                                                                <asp:DataGrid ID="dgJobTitles" runat="server" Width="100%" DataSource="<%# dvJobTitles %>"
                                                                    DESIGNTIMEDRAGDROP="675" ShowHeader="False" DataKeyField="JobTitleID" AutoGenerateColumns="False"
                                                                    OnSelectedIndexChanged="dgJobTitles_SelectedIndexChanged">
                                                                    <AlternatingItemStyle CssClass="bsalternativetd"></AlternatingItemStyle>
                                                                    <ItemStyle CssClass="bsnormaltd"></ItemStyle>
                                                                    <HeaderStyle CssClass="headertd"></HeaderStyle>
                                                                    <Columns>
                                                                        <asp:BoundColumn Visible="False" DataField="JobTitleOrder" SortExpression="JobTitleOrder"
                                                                            HeaderText="Job Order"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="JobName" SortExpression="JobName" HeaderText="Job Title">
                                                                        </asp:BoundColumn>
                                                                        <asp:TemplateColumn>
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
                                                                &nbsp;
                                                            </p>
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
