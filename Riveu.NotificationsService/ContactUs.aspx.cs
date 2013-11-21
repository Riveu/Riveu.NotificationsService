using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Riveu.NotificationsService
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(nameTextBox.Text) && !String.IsNullOrEmpty(emailTextBox.Text) && !String.IsNullOrEmpty(subjectTextBox.Text) && !String.IsNullOrEmpty(messageTextBox.Text))
            {
                try
                {
                    string messageBody = String.Format("Name: {0}<br />Email: {1}<br />Subject: {2}<br />Message: {3}", nameTextBox.Text, emailTextBox.Text, subjectTextBox.Text, messageTextBox.Text);
                    MailMessage mailMessage = new MailMessage("info@riveu.com", "info@riveu.com", "Message From Riveu.com Website", messageBody);
                    mailMessage.IsBodyHtml = true;
                    SmtpClient smtpClient = new SmtpClient("smtpout.secureserver.net");
                    NetworkCredential credentials = new NetworkCredential("info@riveu.com", "stonecold");
                    smtpClient.Credentials = credentials;
                    smtpClient.Send(mailMessage);
                    nameTextBox.Text = String.Empty;
                    emailTextBox.Text = String.Empty;
                    subjectTextBox.Text = String.Empty;
                    messageTextBox.Text = String.Empty;
                    ScriptManager.RegisterStartupScript(this, GetType(), "MessageSuccess", "$( \"#dialog-message3\" ).dialog({modal: true,buttons: {Ok: function() {$( this ).dialog( \"close\" );}}});", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "MessageFailed", "$( \"#dialog-message2\" ).dialog({modal: true,buttons: {Ok: function() {$( this ).dialog( \"close\" );}}});", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ValidationFailed", "$( \"#dialog-message\" ).dialog({modal: true,buttons: {Ok: function() {$( this ).dialog( \"close\" );}}});", true);
            }
        }
    }
}