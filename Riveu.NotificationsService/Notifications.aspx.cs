using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Riveu.NotificationsService
{
    public partial class Notifications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if(Session["Username"] != null && Session["Password"] != null)
                {
                    Response.Redirect("NotificationsManagement.aspx");
                }
            }
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            if (new NotificationsDao().AuthenticateUser(loginUsernameTextBox.Text, loginPasswordTextBox.Text))
            {
                Session["Username"] = loginUsernameTextBox.Text;
                Session["Password"] = loginPasswordTextBox.Text;
                Response.Redirect("NotificationsManagement.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "LoginFailed", "$( \"#dialog-message\" ).dialog({modal: true,buttons: {Ok: function() {$( this ).dialog( \"close\" );}}});", true);
            }
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            string username = registerUsernameTextbox.Text;
            string password = registerPasswordTextbox.Text;

            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
            {
                if (new NotificationsDao().CheckForUserAccount(username))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "LoginFailed", "$( \"#dialog-message2\" ).dialog({modal: true,buttons: {Ok: function() {$( this ).dialog( \"close\" );}}});", true);
                }
                else
                {
                    if(new NotificationsDao().Register(username, password))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "LoginFailed", "$( \"#dialog-message5\" ).dialog({modal: true,buttons: {Ok: function() {$( this ).dialog( \"close\" );}}});", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "LoginFailed", "$( \"#dialog-message4\" ).dialog({modal: true,buttons: {Ok: function() {$( this ).dialog( \"close\" );}}});", true);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "LoginFailed", "$( \"#dialog-message3\" ).dialog({modal: true,buttons: {Ok: function() {$( this ).dialog( \"close\" );}}});", true);
            }

        }
    }
}