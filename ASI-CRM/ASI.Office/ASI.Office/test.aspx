<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript">
        function AddEdit_Note() {
            document.getElementById('btnAddEditNotes').click();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
    <script type="text/javascript">
        // Get a PageRequestManager reference.
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        // Hook the _initializeRequest event and add our own handler.
        prm.add_initializeRequest(InitializeRequest);

        function InitializeRequest(sender, args) {
            // Check to be sure this async postback is actually 
            //   requesting the file download.
            if (sender._postBackSettings.sourceElement.id == "Button1") {
                // Create an IFRAME.
                var iframe = document.createElement("iframe");

                // Point the IFRAME to GenerateFile.
                iframe.src = "GenerateRegisterationReport.aspx";

                // This makes the IFRAME invisible to the user.
                iframe.style.display = "none";

                // Add the IFRAME to the page.  This will trigger
                //   a request to GenerateFile now.
                document.body.appendChild(iframe);
            }
        }
    </script>
    
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
    <ContentTemplate>
    <asp:Button ID="Button1" runat="server"
                Text="AddEditNotes" OnClick="btnAddEditNotes_Click" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Button ID="btnAddEditNotes" runat="server" Height="0px" 
                Text="AddEditNotes" Width="0px" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" ScrollBars="Auto"
        Height="350px" Width="850px" CssClass="">
        <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="">
            <HeaderTemplate>
                a
            </HeaderTemplate>
            <ContentTemplate>
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtUserNoteDate" runat="server" Width="110px"></asp:TextBox>
                        <img id="imgNoteDate" runat="server" src="Images/Calender.gif" style="vertical-align: middle"
                            class="HandOverCursor" alt="Pick a Date" />
                        <img id="imgAddEditNotes" runat="server" src="Images/addorEditnotes.gif" onmouseover="src='Images/addorEditnotes_over.png'"
                            onmouseout="src='Images/addorEditnotes.gif'" class="HandOverCursor" alt="Add or Edit Notes"
                            style="vertical-align: middle" onclick="AddEdit_Note();" />
                        <cc1:CalendarExtender ID="CalendarExtender31" runat="server" PopupButtonID="imgNoteDate"
                            TargetControlID="txtUserNoteDate" BehaviorID="CalendarExtender31">
                        </cc1:CalendarExtender>
                        <cc1:PopupControlExtender ID="PopupControlExtender1" runat="server" Position="Bottom"
                            OffsetX="-350" OffsetY="-200" TargetControlID="imgAddEditNotes" PopupControlID="UpdatePanel3">
                        </cc1:PopupControlExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Width="110px"></asp:TextBox>
                                <img id="img1" runat="server" src="Images/Calender.gif" style="vertical-align: middle"
                                    class="HandOverCursor" alt="Pick a Date" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="img1"
                                    TargetControlID="TextBox1" BehaviorID="CalendarExtender1">
                                </cc1:CalendarExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
    </ContentTemplate>
                </asp:UpdatePanel>
    </form>
</body>
</html>
