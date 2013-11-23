<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="Riveu.NotificationsService.ContactUs" %>
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
                <h3>Contact Us</h3>
                <div id="accordion" style="width:75%">
                  <asp:Table runat="server">
                      <asp:TableRow>
                          <asp:TableCell VerticalAlign="Top" HorizontalAlign="Left">
                              Name:
                          </asp:TableCell>
                          <asp:TableCell>
                              <asp:TextBox ID="nameTextBox" Width="400" runat="server" />
                          </asp:TableCell>
                      </asp:TableRow>
                      <asp:TableRow>
                          <asp:TableCell>
                              Email:
                          </asp:TableCell>
                          <asp:TableCell VerticalAlign="Top" HorizontalAlign="Left">
                              <asp:TextBox ID="emailTextBox" Width="400" runat="server" />
                          </asp:TableCell>
                      </asp:TableRow>
                      <asp:TableRow>
                          <asp:TableCell VerticalAlign="Top" HorizontalAlign="Left">
                              Subject:
                          </asp:TableCell>
                          <asp:TableCell>
                              <asp:TextBox ID="subjectTextBox" Width="400" runat="server" />
                          </asp:TableCell>
                      </asp:TableRow>
                      <asp:TableRow>
                          <asp:TableCell VerticalAlign="Top" HorizontalAlign="Left">
                              Message:
                          </asp:TableCell>
                          <asp:TableCell>
                              <asp:TextBox ID="messageTextBox" TextMode="MultiLine" Height="300" Width="400" runat="server" />
                          </asp:TableCell>
                      </asp:TableRow>
                      <asp:TableRow>
                          <asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
                              <asp:Button ID="submitButton" Text="Submit" OnClick="submitButton_Click" runat="server" />
                          </asp:TableCell>
                      </asp:TableRow>
                  </asp:Table>
                  <div id="dialog-message" title="Validation Failure">
                    <p>
                    <span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 50px 0;"></span>
                    All fields are required. Please ensure all fields are populated.
                    </p>
                  </div>
                  <div id="dialog-message2" title="Message Failure">
                    <p>
                    <span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 50px 0;"></span>
                    Your message could not be sent. Please try again.
                    </p>
                  </div>
                  <div id="dialog-message3" title="Message Sent">
                    <p>
                    <span class="ui-icon ui-icon-check" style="float: left; margin: 0 7px 50px 0;"></span>
                    Thank You. Your message has been sent successfully.
                    </p>
                  </div>
                </center>
            <script>
                $(document).ready(
                    function () {
                        $("#dialog-message").dialog({ autoOpen: false });
                        $("#dialog-message2").dialog({ autoOpen: false });
                        $("#dialog-message3").dialog({ autoOpen: false });
                        $("#submitButton").button();
                    });
                </script>
         </div>
	</form>
</body>
</html>
