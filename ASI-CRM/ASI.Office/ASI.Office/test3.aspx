<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test3.aspx.cs" Inherits="test3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="Controls/DueDiligance.ascx" tagname="DueDiligance" tagprefix="uc3" %>
<%@ Register src="Controls/Menu.ascx" tagname="Menu" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
     <title>Accounts</title>
     <LINK href="Styles/MainStyle.css" type="text/css" rel="stylesheet">
     <LINK REL="SHORTCUT ICON" HREF="Images/favicon.ico">
    
    <script type="text/javascript" language="javascript">

        function uploadError(sender, args) {
            document.getElementById('lblStatus').innerText = args.get_fileName(), "<span style='color:red;'>" + args.get_errorMessage() + "</span>";
        }

        function StartUpload(sender, args) {
            document.getElementById('lblStatus').innerText = 'Uploading Started.';
        }

        function UploadComplete(sender, args) {
            var filename = args.get_fileName();
            var contentType = args.get_contentType();
            var text = "Size of " + filename + " is " + args.get_length() + " bytes";
            if (contentType.length > 0) {
                text += " and content type is '" + contentType + "'.";
            }
            document.getElementById('lblStatus').innerText = text;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm1" runat="server" />
         
   <%-- <asp:Menu ID="Menu1" runat="server" BackColor="#E3EAEB"  
       DynamicHorizontalOffset="2" Font-Names="Arial" ForeColor="#284E98"
                        Orientation="Horizontal"  StaticSubMenuIndent="10px" MaximumDynamicDisplayLevels="5">
                        <StaticMenuItemStyle HorizontalPadding="0px" VerticalPadding="0px" />
                        <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
                        <DynamicMenuStyle BackColor="#B5C7DE" />
                        <StaticSelectedStyle BackColor="#507CD1" />
                        <DynamicSelectedStyle BackColor="#507CD1" />
                        <DynamicMenuItemStyle HorizontalPadding="0px" VerticalPadding="0px" />
                        <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
        <Items>
         <asp:MenuItem  ImageUrl="~/Images/Home-n.jpg"  NavigateUrl="~/Home.aspx"> </asp:MenuItem>
            <asp:MenuItem ImageUrl="~/Images/accountDetails_09.jpg"
                NavigateUrl="~/Accounts.aspx" ToolTip="Accounts" >
                <asp:MenuItem ImageUrl="~/Images/accountDetails_11.jpg"  NavigateUrl="~/AccountLists.aspx" ToolTip="Account Details" ></asp:MenuItem>
              
                
            </asp:MenuItem>
            <asp:MenuItem Text="" Value="" ImageUrl="~/Images/accountDetails_13.jpg" NavigateUrl="~/Contacts.aspx">
                <asp:MenuItem ImageUrl="~/Images/accountDetails_15.jpg"  NavigateUrl="~/ContactLists.aspx" ToolTip="Contact Details" ></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/Images/Email-n.jpg" ToolTip="Email" NavigateUrl="~/EmailTemplate.aspx"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/Images/Calls-n.jpg" ToolTip="Calls" NavigateUrl="~/CallsManagement.aspx"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/Images/Webinars-n.jpg" ToolTip="Webinars" NavigateUrl="~/Webinars.aspx"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/Images/support-n.jpg"  ToolTip="Customer Support" NavigateUrl="~/CustomerSupport.aspx"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/Images/Registration-n.jpg" ToolTip="Registration" NavigateUrl="~/Registration.aspx"></asp:MenuItem>
             <asp:MenuItem ImageUrl="~/Images/Manage1.JPG" ToolTip="Manage Application" NavigateUrl="~/ManageApplication.aspx"></asp:MenuItem>
              
        </Items>
       
    </asp:Menu>--%>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <select ID="ddlCreditCheck" name="ddlCreditCheck"  runat="server">
                                <option value="SelectOne">Select one</option>
                                <option value="EmailForm">Email Form </option>
                                <option value="UploadForm">Upload Form</option>
                                <option value="Preview">Preview </option>
                                </select>
    <div id=Div1 runat=server>  
    
   
        <uc1:Menu ID="Menu1" runat="server" />
    
   
     </div> 
      </ContentTemplate>
    </asp:UpdatePanel>   

   
        
    <%--<uc3:DueDiligance ID="DueDiligance1" runat="server" />--%>

   
        
    </form>
</body>
</html>
