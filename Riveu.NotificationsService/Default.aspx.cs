using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Riveu.NotificationsService
{
    public partial class Default : System.Web.UI.Page
    {
        NotificationService notificationService = new NotificationService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loginDiv.Visible = true;
                registerDiv.Visible = false;
                loggedInDiv.Visible = false;
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (notificationService.AuthenticateUser(usernameTextbox.Text, passwordTextbox.Text))
            {
                loggedInDiv.Visible = true;
                loginDiv.Visible = false;
                registerDiv.Visible = false;
                ArrayList tmpData = new ArrayList();
                radGrid.DataSource = notificationService.GetNotifications(usernameTextbox.Text);
                radGrid.DataBind();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "AuthenticationFailure", "<script>alert('Invalid Credentials');</script>");
            }
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            loginDiv.Visible = false;
            registerDiv.Visible = true;
            loggedInDiv.Visible = false;
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Default.aspx");
        }
    }
}