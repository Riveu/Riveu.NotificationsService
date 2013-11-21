using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Riveu.NotificationsService
{
    public partial class API : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["CMD"] != null)
            {
                switch (Request.QueryString["CMD"])
                {
                    case "SEND_NOTIFICATION":
                        SendNotification();
                        break;
                    default:
                        break;
                }
            }
        }

        private void SendNotification()
        {
            string username = Request.QueryString["Username"].ToString();
            string password = Request.QueryString["Password"].ToString();
            string message = Request.QueryString["Message"].ToString();
            message = Uri.UnescapeDataString(message);
            NotificationService service = new NotificationService();
            if (service.AuthenticateUser(username, password))
            {
                service.SendNotification(username, password, message);
            }
        }
    }
}