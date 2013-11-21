<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NotificationsManagement.aspx.cs" Inherits="Riveu.NotificationsService.NotificationsManagement" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="scripts/jquery-1.9.1.js"></script>
    <script src="scripts/jquery-ui-1.10.3.custom.js"></script>
    <link href="css/excite-bike/jquery-ui-1.10.3.custom.css" rel="stylesheet" />
    <style>

        div.RadMenu .rmRootGroup .rmLast   { float: right; } 
div.RadMenu .rmGroup     .rmLast   { float: none;  }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        <telerik:RadFormDecorator ID="RadFormDecorator1" DecoratedControls="All"  runat="server" />
        <div style="width:100%;">
            <div style="margin-left:5px; margin-bottom:10px; margin-top:10px">
                <asp:HyperLink runat="server" NavigateUrl="~/Default.aspx" ForeColor="OrangeRed" Font-Underline="false" Font-Names="Lucida Handwriting" Font-Size="XX-Large">Riveu Software</asp:HyperLink>
            </div>
             <telerik:RadMenu CssClass="RadMenu" runat="server" Skin="WebBlue" Width="100%">
                 <Items>
                     <telerik:RadMenuItem Text="Contact Us" NavigateUrl="ContactUs.aspx" OuterCssClass="rmLast" />
                     <telerik:RadMenuItem Text="Support" NavigateUrl="Support.aspx" OuterCssClass="rmLast" />
                     <telerik:RadMenuItem Text="Notifications" NavigateUrl="Notifications.aspx" OuterCssClass="rmLast" />
                     <telerik:RadMenuItem Text="Products" NavigateUrl="Products.aspx" OuterCssClass="rmLast" />
                     <telerik:RadMenuItem Text="Home" OuterCssClass="rmLast" NavigateUrl="Default.aspx" />
                 </Items>
             </telerik:RadMenu>
            <br style="clear: both" />
            <center>
                <br /><div style="float:right"><asp:LinkButton Text="Logout" runat="server" ID="logoutButton" OnClick="logoutButton_Click" /></div><br /><br />
                <telerik:RadGrid runat="server" ID="notificationsRadGrid"></telerik:RadGrid>
            </center>
         </div>
    </form>
</body>
</html>
