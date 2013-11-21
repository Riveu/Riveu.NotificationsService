<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SupportTicketEditUserControl.ascx.cs" Inherits="Riveu.NotificationsService.SupportTicketEditUserControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Table runat="server">
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label Text="Ticket ID" Visible='<%# !(DataItem is Telerik.Web.UI.GridInsertionObject) %>' runat="server" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="ticketIDTextBox" Width="300" Enabled="false" Text='<%# DataBinder.Eval( Container, "DataItem.SupportTicketID") %>' Visible='<%# !(DataItem is Telerik.Web.UI.GridInsertionObject) %>' runat="server" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell Width="150px">
            Project
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadDropDownList ID="projectDropDown" Width="300" runat="server">
                <Items>
                    <telerik:DropDownListItem Text="---" />
                    <telerik:DropDownListItem Text="Notifications - Windows 8 Client" Selected="false" />
                    <telerik:DropDownListItem Text="Notifications Service" Selected="false" />
                    <telerik:DropDownListItem Text="Other" Selected="false" />
                </Items>
            </telerik:RadDropDownList>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            Description
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="descriptionTextBox" TextMode="MultiLine" Text='<%# DataBinder.Eval( Container, "DataItem.Description") %>' Height="200" Width="300" runat="server" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            Reported By
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="updateReporterTextBox" Width="300" Enabled="false" Text='<%# DataBinder.Eval( Container, "DataItem.Reporter") %>' runat="server" Visible='<%# !(DataItem is Telerik.Web.UI.GridInsertionObject) %>' />
            <asp:TextBox ID="insertReporterTextBox" Width="300" Enabled="false" Text='<%# Session["SupportUsername"].ToString() %>' runat="server" Visible='<%# (DataItem is Telerik.Web.UI.GridInsertionObject) %>' />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            Reported Date
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="updateReportedDateTextBox" Width="300" Enabled="false" Text='<%# DataBinder.Eval( Container, "DataItem.ReportedDate") %>' runat="server" Visible='<%# !(DataItem is Telerik.Web.UI.GridInsertionObject) %>' />
            <asp:TextBox ID="insertReportedDateTextBox" Width="300" Enabled="false" Text='<%# DateTime.Now.ToString() %>' runat="server" Visible='<%# (DataItem is Telerik.Web.UI.GridInsertionObject) %>' />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            Status
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="updateStatusTextBox" Width="300" Enabled="true" Text='<%# DataBinder.Eval( Container, "DataItem.Status") %>' runat="server" Visible='<%# !(DataItem is Telerik.Web.UI.GridInsertionObject) %>' />
            <asp:TextBox ID="insertStatusTextBox" Width="300" Enabled="true" Text="Open" runat="server"  Visible='<%# (DataItem is Telerik.Web.UI.GridInsertionObject) %>' />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            Status Date
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="statusDateTextBox" Width="300" Enabled="false" Text='<%# DateTime.Now.ToString() %>' runat="server" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            Status Comments
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="updateStatusComments" Height="200" Width="300" TextMode="MultiLine" Enabled="true" Text='<%# DataBinder.Eval( Container, "DataItem.StatusComments") %>' runat="server" Visible='<%# !(DataItem is Telerik.Web.UI.GridInsertionObject) %>' />
            <asp:TextBox ID="insertStatusComments" Height="200" Width="300" TextMode="MultiLine" Enabled="true" Text="Initial Creation" runat="server"  Visible='<%# (DataItem is Telerik.Web.UI.GridInsertionObject) %>' />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            Updated By
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="updaterTextBox" Width="300" Enabled="false" Text='<%# Session["SupportUsername"].ToString() %>' runat="server" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
            <asp:Button ID="btnUpdate" Text="Update Ticket" CommandName="Update" Visible='<%# !(DataItem is Telerik.Web.UI.GridInsertionObject) %>' runat="server" />
            <asp:Button ID="btnInsert" Text="Create Ticket" runat="server" CommandName="PerformInsert" Visible='<%#(DataItem is Telerik.Web.UI.GridInsertionObject) %>' />
            &nbsp;
            <asp:Button ID="btnCancel" Text="Cancel" runat="server" CausesValidation="false" CommandName="Cancel" />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>