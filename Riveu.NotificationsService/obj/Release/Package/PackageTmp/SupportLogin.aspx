<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupportLogin.aspx.cs" Inherits="Riveu.NotificationsService.SupportLogin" %>
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
                <br /><br /><br />

                <div id="tabs" style="width:500px">
                  <ul>
                    <li><a href="#login">Login</a></li>
                    <li><a href="#register">Register</a></li>
                  </ul>
                  <div id="login">
                      <asp:Table runat="server">
                          <asp:TableRow>
                              <asp:TableCell HorizontalAlign="Right">
                                  Username:
                              </asp:TableCell>
                              <asp:TableCell>
                                  <asp:TextBox ID="loginUsernameTextBox" runat="server" />
                              </asp:TableCell>
                          </asp:TableRow>
                          <asp:TableRow>
                              <asp:TableCell HorizontalAlign="Right">
                                  Password:
                              </asp:TableCell>
                              <asp:TableCell>
                                  <asp:TextBox TextMode="Password" ID="loginPasswordTextBox" runat="server" />
                              </asp:TableCell>
                          </asp:TableRow>
                          <asp:TableRow>
                              <asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
                                  <asp:Button ID="loginButton" Text="Login" runat="server" OnClick="loginButton_Click" />
                              </asp:TableCell>
                          </asp:TableRow>
                      </asp:Table>
                  </div>
                  <div id="register">
                      <asp:Table runat="server">
                          <asp:TableRow>
                              <asp:TableCell HorizontalAlign="Right">
                                  Username:
                              </asp:TableCell>
                              <asp:TableCell>
                                  <asp:TextBox ID="registerUsernameTextBox" runat="server" />
                              </asp:TableCell>
                          </asp:TableRow>
                          <asp:TableRow>
                              <asp:TableCell HorizontalAlign="Right">
                                  Password:
                              </asp:TableCell>
                              <asp:TableCell>
                                  <asp:TextBox TextMode="Password" ID="registerPasswordTextBox" runat="server" />
                              </asp:TableCell>
                          </asp:TableRow>
                          <asp:TableRow>
                              <asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
                                  <asp:Button ID="registerButton" Text="Submit" runat="server" OnClick="registerButton_Click" />
                              </asp:TableCell>
                          </asp:TableRow>
                      </asp:Table>
                  </div>
                </div>
                <div id="dialog-message" title="Registration Successful">
                    <p>
                    <span class="ui-icon ui-icon-check" style="float: left; margin: 0 7px 50px 0;"></span>
                    Registration succesful.
                    </p>
                </div>
                <div id="dialog-message2" title="Duplicate Account">
                    <p>
                    <span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 50px 0;"></span>
                    Username already exists. Please try another one.
                    </p>
                </div>
                <div id="dialog-message3" title="Missing Credentials">
                    <p>
                    <span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 50px 0;"></span>
                    Please supply both a username and password.
                    </p>
                </div>
                <div id="dialog-message4" title="Error">
                    <p>
                    <span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 50px 0;"></span>
                    Unable to create account. Please try again.
                    </p>
                </div>
                <div id="dialog-message5" title="Invalid Credentials">
                    <p>
                    <span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 50px 0;"></span>
                    Invalid credentials. Please verify and try again.
                    </p>
                </div>
                <script>
                    $(document).ready(
                        function () {
                            $("#tabs").tabs({ active: 0 });
                            $("#loginButton").button();
                            $("#registerButton").button();
                            $("#dialog-message").dialog({ autoOpen: false });
                            $("#dialog-message2").dialog({ autoOpen: false });
                            $("#dialog-message3").dialog({ autoOpen: false });
                            $("#dialog-message4").dialog({ autoOpen: false });
                            $("#dialog-message5").dialog({ autoOpen: false });
                        });
                </script>
                </center>
         </div>
    </form>
</body>
</html>
