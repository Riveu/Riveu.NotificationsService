<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Riveu.NotificationsService.Default" %>

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
                <asp:HyperLink NavigateUrl="~/Default.aspx" runat="server"><asp:Image ImageUrl="Images/WebSiteLogo.png" runat="server" /></asp:HyperLink>
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
                  <h3>Who Are We?</h3>
                  <div>Riveu is a private software company that designs, develops, tests, and releases applications directly to end users. Our vision to provide the best software to consumers on a wide array of platforms.</div>
                  <h3>What We Offer</h3>
                  <div>Our primary focus is on Windows 8 and Windows Phone development for the direct end-user; however, we can also develop for any other mobile device.</div>
                  <h3>How Are We Different?</h3>
                  <div>We are full time developers that are creating applications in our down-time. We create our applications to help out the software community. We focus on the direct end-user, not distributing to retail establishments or large organizations.</div>
                  <h3>Notifications System</h3>
                  <div>Our notifications service is our flagship offering. It allows push notifications to mobile devices and our API allows for easy integration into any service, such as SickBeard, CouchPotato, Headphones, etc. We currently have the premier Windows 8 notification service and are currently looking to get it implemented into other systems.</div>
                </div>
                <script>
                    $(document).ready(
                        function () {
                            $("#accordion").accordion({ heightStyle:"content"});
                        });
                </script>
                </center>
         </div>
	</form>
</body>
</html>
