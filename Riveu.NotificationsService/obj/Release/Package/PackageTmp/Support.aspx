<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Support.aspx.cs" Inherits="Riveu.NotificationsService.Support" %>
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

                <div id="tabs" style="width:100%">
                    <div style="float:right;margin-right:25px;margin-top:10px"><asp:LinkButton ID="logoutButton" runat="server" Text="Logout" OnClick="logoutButton_Click" /></div>
                  <ul>
                    <li><a href="#supportickets">Support Tickets</a></li>
                  </ul>
                  <div id="supportickets">
                      <telerik:RadGrid ID="supportTicketsRadGrid" MasterTableView-NoMasterRecordsText="There are no support tickets" runat="server" OnNeedDataSource="supportTicketsRadGrid_NeedDataSource" OnUpdateCommand="supportTicketsRadGrid_UpdateCommand" OnInsertCommand="supportTicketsRadGrid_InsertCommand" OnDeleteCommand="supportTicketsRadGrid_DeleteCommand" ShowStatusBar="true">
                          <MasterTableView DataKeyNames="SupportTicketID" EditMode="EditForms" AutoGenerateColumns="false" CommandItemDisplay="Top" AllowFilteringByColumn="true" AllowSorting="true" AllowPaging="true" PageSize="30">
                              <Columns>
                                  <telerik:GridEditCommandColumn UniqueName="EditColumn" />
                                  <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="Delete" CommandName="Delete" />
                                  <telerik:GridBoundColumn DataType="System.Int32" ReadOnly="true" AllowSorting="true" AllowFiltering="true" DataField="SupportTicketID" HeaderText="Ticket ID" />
                                  <telerik:GridBoundColumn DataType="System.String" ReadOnly="false" AllowSorting="true" AllowFiltering="true" DataField="Project" HeaderText="Project" />
                                  <telerik:GridBoundColumn DataType="System.String" ReadOnly="false" AllowSorting="true" AllowFiltering="true" DataField="Description" HeaderText="Description" />
                                  <telerik:GridBoundColumn DataType="System.String" ReadOnly="true" AllowSorting="true" AllowFiltering="true" DataField="Reporter" HeaderText="Reported By" />
                                  <telerik:GridBoundColumn DataType="System.DateTime" ReadOnly="true" AllowSorting="true" AllowFiltering="true" DataField="ReportedDate" HeaderText="Reported Date" />
                                  <telerik:GridBoundColumn DataType="System.String" ReadOnly="false" AllowSorting="true" AllowFiltering="true" DataField="Status" HeaderText="Status" />
                                  <telerik:GridBoundColumn DataType="System.DateTime" ReadOnly="true" AllowSorting="true" AllowFiltering="true" DataField="StatusDate" HeaderText="Status Date" />
                                  <telerik:GridBoundColumn DataType="System.String" ReadOnly="false" AllowSorting="true" AllowFiltering="true" DataField="StatusComments" HeaderText="Status Comments" />
                                  <telerik:GridBoundColumn DataType="System.String" ReadOnly="true" AllowSorting="true" AllowFiltering="true" DataField="Updater" HeaderText="Updated By" />
                              </Columns>
                              <EditFormSettings UserControlName="SupportTicketEditUserControl.ascx" EditFormType="WebUserControl">
                                  <EditColumn UniqueName="EditCommandColumn1" />
                              </EditFormSettings>
                          </MasterTableView>
                      </telerik:RadGrid>
                  </div>
                </div>
                <div id="dialog-message" title="Support Ticket Reported">
                    <p>
                    <span class="ui-icon ui-icon-check" style="float: left; margin: 0 7px 50px 0;"></span>
                    Thank You. A new support ticket has been created.
                    </p>
                </div>
                <div id="dialog-message2" title="Required Fields Missing">
                    <p>
                    <span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 50px 0;"></span>
                    All fields are required. Please verify and re-submit.
                    </p>
                </div>
                <script>
                    $(document).ready(
                        function () {
                            $("#tabs").tabs({ active: 0 });
                            $("#submitButton").button();
                            $("#dialog-message").dialog({ autoOpen: false });
                            $("#dialog-message2").dialog({ autoOpen: false });
                        });
                </script>
                </center>
         </div>
    </form>
</body>
</html>
