using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Riveu.NotificationsService
{
    public partial class SupportLogin : System.Web.UI.Page
    {
        SupportTicketsDao dao = new SupportTicketsDao();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            string username = loginUsernameTextBox.Text;
            string password = loginPasswordTextBox.Text;
            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
            {
                if (dao.AuthenticateUser(username, password))
                {
                    Session["SupportUsername"] = username;
                    Session["SupportPassword"] = password;
                    Response.Redirect("Support.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "MessageSuccess", "$( \"#dialog-message5\" ).dialog({modal: true,buttons: {Ok: function() {$( this ).dialog( \"close\" );}}});", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "MessageSuccess", "$( \"#dialog-message3\" ).dialog({modal: true,buttons: {Ok: function() {$( this ).dialog( \"close\" );}}});", true);
            }
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            string username = registerUsernameTextBox.Text;
            string password = registerPasswordTextBox.Text;

            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
            {
                if (!dao.CheckForUserAccount(username))
                {
                    if (dao.Register(username, password))
                    {
                        //success
                        ScriptManager.RegisterStartupScript(this, GetType(), "MessageSuccess", "$( \"#dialog-message\" ).dialog({modal: true,buttons: {Ok: function() {$( this ).dialog( \"close\" );}}});", true);
                        Session["SupportUsername"] = username;
                        Session["SupportPassword"] = password;
                        Response.Redirect("Support.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "MessageSuccess", "$( \"#dialog-message4\" ).dialog({modal: true,buttons: {Ok: function() {$( this ).dialog( \"close\" );}}});", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "MessageSuccess", "$( \"#dialog-message2\" ).dialog({modal: true,buttons: {Ok: function() {$( this ).dialog( \"close\" );}}});", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "MessageSuccess", "$( \"#dialog-message3\" ).dialog({modal: true,buttons: {Ok: function() {$( this ).dialog( \"close\" );}}});", true);
            }
        }
    }
}