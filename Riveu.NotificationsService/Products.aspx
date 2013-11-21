<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Riveu.NotificationsService.Products" %>
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
    
        
	<form method="post" runat="server">
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
                <br /><br /><br />

                <div id="accordion" style="width:75%">
                  <h3>Products</h3>
                  <div>All of our products are currently in the development and test phase. The following have either been submitted to the App Stores or are already on the App Stores.<ul style="text-align:left"><li>Notifications - Windows 8 Client</li></ul></div>
                  <h3>Notifications</h3>
                  <div>Our notifications service is our flagship offering. It allows push notifications to mobile devices and our API allows for easy integration into any service, such as SickBeard, CouchPotato, Headphones, etc. We currently have the premier Windows 8 notification service and are currently looking to get it implemented into other systems. We have submitted the Windows 8 client to the Microsoft App Store. We are also working on a Windows 8.1 client, as well as a Windows Phone 8 Client, both to be release soon after the Windows 8 client gets approved by Microsoft.</div>
                  <h3>Notifications - Supporting Scripts</h3>
                  <div>We are currently working on some scripts to streamline the implementation of our notifications system into other applications and services. As those scripts are completed and tested, they will be available here.</div>
                </div>
                <script>
                    $(document).ready(
                        function () {
                            $("#accordion").accordion({ heightStyle: "content" });
                        });
                </script>
                </center>
         </div>
	</form>
</body>
</html>
