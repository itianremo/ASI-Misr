<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateReport.aspx.cs" Inherits="CreateReport"
    Title="Create Report" ValidateRequest="false" MasterPageFile="~/MasterPage.master" %>

<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
<%--<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta name="vs_snapToGrid" content="True" />
    <title>Report View</title>
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <link href="../Styles/MainStyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" runat="server">--%>
        <div style="height: 645px; width: 1200px;" dir="ltr">
            <table id="TableLabelbar" style="width: 100%; margin-top: 0px;">
                <tr style="margin-top: 0px;">
                    <td style="width: 100%; margin-top: 0px;">
                        &nbsp;</td>
                </tr>
            </table>
            <asp:Table ID="tblErr" runat="server" BorderWidth="0px" CellPadding="2" CellSpacing="0"
                CssClass="errorTable" Font-Names="Arial" Font-Size="9pt" HorizontalAlign="Center"
                Visible="False" Width="453px">
                <asp:TableRow ID="TableRow1" runat="server" VerticalAlign="Top">
                    <asp:TableCell ID="TableCell1" runat="server" BackColor="#FFFFC0" BorderColor="White"
                        Text="&lt;img src=../images/alrt.gif /&gt;"></asp:TableCell>
                    <asp:TableCell ID="TableCell2" runat="server" BackColor="#FFFFC0"></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <table id="TableData" cellpadding="2" cellspacing="2" style="width: 80%; text-align: left">
                <tbody>
                    <tr>
                        <th align="right" colspan="2" style="border-top-width: 1px; border-left-width: 1px;
                            border-left-color: navy; border-bottom-width: 1px; border-bottom-color: navy;
                            border-top-color: navy; height: 20px; text-align: left; border-right-width: 1px;
                            border-right-color: navy">
                            Report General Details
                        </th>
                    </tr>
                    <tr>
                        <td align="left" style="text-align: left; width: 25%;">
                            Report Name
                        </td>
                        <td style="width: 150px;" colspan="1" dir="ltr" align="left" valign="middle">
                            <table border="1" cellspacing="5" frame="void">
                                <tr align="left">
                                    <td style="width: 150px; border: 0px;">
                                        <asp:TextBox ID="txtReportName" runat="server" MaxLength="60" Width="302px" Height="20px"></asp:TextBox>
                                    </td>
                                    <td style="border: 0px;">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtReportName"
                                            ErrorMessage="*" SetFocusOnError="True">*</asp:RequiredFieldValidator>&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div align="center" style="width: 600px;">
                                <asp:Button ID="btnNext" runat="server" OnClick="ButtonSaveReprt_Click" Text="Next"
                                    Height="28px" Width="74px" />
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        </asp:content>
<%--</form>
</body>
</html>--%>
