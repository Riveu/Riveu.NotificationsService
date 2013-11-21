using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Riveu.NotificationsService
{
    public partial class Support : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGrid();
            }
            if (Session["SupportUsername"] != null && Session["SupportPassword"] != null)
            {
                
            }
            else
            {
                Response.Redirect("SupportLogin.aspx");
            }
        }

        private void PopulateGrid()
        {
            supportTicketsRadGrid.DataSource = new SupportTicketsDao().GetTickets();
            supportTicketsRadGrid.DataBind();
        }

        protected void supportTicketsRadGrid_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            string ticketId = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["SupportTicketID"].ToString();
            SupportTicketsDao dao = new SupportTicketsDao();
            if (dao.AuthenticateTicketModifier(Session["SupportUsername"].ToString(),ticketId))
            {
                dao.DeleteSupportTicket(ticketId);
            }
            PopulateGrid();
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("SupportLogin.aspx");
        }

        protected void supportTicketsRadGrid_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            supportTicketsRadGrid.DataSource = new SupportTicketsDao().GetTickets();
        }

        protected void supportTicketsRadGrid_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);
            string ticketId = (userControl.FindControl("ticketIDTextBox") as TextBox).Text;
            string description = (userControl.FindControl("descriptionTextBox") as TextBox).Text;
            string project = (userControl.FindControl("projectDropDown") as RadDropDownList).SelectedText;
            string reporter = (userControl.FindControl("updateReporterTextBox") as TextBox).Text;
            string reportedDate = (userControl.FindControl("updateReportedDateTextBox") as TextBox).Text;
            string status = (userControl.FindControl("updateStatusTextBox") as TextBox).Text;
            string statusDate = (userControl.FindControl("statusDateTextBox") as TextBox).Text;
            string statusComments = (userControl.FindControl("updateStatusComments") as TextBox).Text;
            string updater = (userControl.FindControl("updaterTextBox") as TextBox).Text;
            new SupportTicketsDao().UpdateSupportTicket(ticketId, project, description, reporter, reportedDate, status, statusDate, statusComments, updater);
        }

        protected void supportTicketsRadGrid_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);
            string ticketId = (userControl.FindControl("ticketIDTextBox") as TextBox).Text;
            string description = (userControl.FindControl("descriptionTextBox") as TextBox).Text;
            string project = (userControl.FindControl("projectDropDown") as RadDropDownList).SelectedText;
            string reporter = (userControl.FindControl("insertReporterTextBox") as TextBox).Text;
            string reportedDate = (userControl.FindControl("insertReportedDateTextBox") as TextBox).Text;
            string status = (userControl.FindControl("insertStatusTextBox") as TextBox).Text;
            string statusDate = (userControl.FindControl("statusDateTextBox") as TextBox).Text;
            string statusComments = (userControl.FindControl("insertStatusComments") as TextBox).Text;
            new SupportTicketsDao().AddSupportTicket(Session["SupportUsername"].ToString(), Session["SupportPassword"].ToString(), project, description, reporter, status, statusComments, statusDate, reportedDate);
            
        }
    }
}