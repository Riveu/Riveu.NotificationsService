using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Riveu.NotificationsService
{
    public partial class NotificationsManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null || Session["Password"] == null)
            {
                Response.Redirect("Notifications.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    BindGrid();
                }
            }
        }

        private void BindGrid()
        {
            NotificationsDao dao = new NotificationsDao();
            var notifications = dao.GetNotifications(Session["Username"].ToString());
            notificationsRadGrid.DataSource = notifications;
            notificationsRadGrid.DataBind();
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Notifications.aspx");
        }
    }
}