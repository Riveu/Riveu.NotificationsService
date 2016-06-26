using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.Text;
using System.Web;

namespace Riveu.NotificationsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NotificationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select NotificationService.svc or NotificationService.svc.cs at the Solution Explorer and start debugging.
    public class NotificationService : INotificationService
    {
        public bool AuthenticateUser(string username, string password)
        {
            return new NotificationsDao().AuthenticateUser(username, password);
        }


        public IList GetNotifications(string username)
        {
            return new NotificationsDao().GetNotifications(username);
        }


        public void RegisterSubscriber(string username, string password, string Uri, string deviceType, string deviceId)
        {
            new NotificationsDao().RegisterSubscriber(username, password, Uri, deviceType, deviceId);
        }


        public void UnregisterSubscriber(string username, string password, string deviceType, string deviceId)
        {
            new NotificationsDao().UnregisterSubscriber(username, password, deviceType, deviceId);
        }


        public void SendNotification(string username, string password, string message)
        {
            new NotificationsDao().AddNotificationMessage(username, password, message);
            foreach (DataRow row in new NotificationsDao().GetSubscribers(username, password).Rows)
            {
                string type = row["DeviceType"].ToString();
                string uri = row["SubscriberURI"].ToString();
                switch (type)
                {
                    case "Win8":
                        SendWin8Notification(uri, message);
                        break;
                    case "WP8":
                        SendWP8Notification(uri, message);
                        break;
                    default:
                        break;
                }
            }
        }

        private void SendWin8Notification(string uri, string message)
        {
            string sid = "ms-app://s-1-15-2-1988233354-3138544214-1460355088-726677253-75672808-3563150183-867464937";
            string secret = "dzjyZmxccpMere3Tf1GhUuj0YWy2Yo3h";
            string body = String.Format("grant_type=client_credentials&client_id={0}&client_secret={1}&scope=notify.windows.com",HttpUtility.UrlEncode(sid),HttpUtility.UrlEncode(secret));
            string jsonString;
            string xml = "<toast><visual><binding template=\"ToastText01\"><text id=\"1\">" + message +"</text></binding></visual></toast>";
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                jsonString = client.UploadString("https://login.live.com/accesstoken.srf", body);
            }
            var oAuthToken = new OAuthToken();
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(jsonString)))
            {
                var ser = new DataContractJsonSerializer(typeof(OAuthToken));
                oAuthToken = (OAuthToken)ser.ReadObject(ms);
            }
            var accessToken = oAuthToken;
            byte[] contentInBytes = Encoding.UTF8.GetBytes(xml);

            HttpWebRequest request = HttpWebRequest.Create(uri) as HttpWebRequest;
            request.Method = "POST";
            request.Headers.Add("X-WNS-Type", "wns/toast");
            request.ContentType = "text/xml";
            request.Headers.Add("Authorization", String.Format("Bearer {0}", accessToken.AccessToken));

            using (Stream requestStream = request.GetRequestStream())
                requestStream.Write(contentInBytes, 0, contentInBytes.Length);

            using (HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse())
            {
                string result = webResponse.StatusCode.ToString();
            }
                
        }

        private void SendWP8Notification(string uri, string message)
        {


            HttpWebRequest sendNotificationRequest = (HttpWebRequest)WebRequest.Create(uri);

            // Create an HTTPWebRequest that posts the toast notification to the Microsoft Push Notification Service.
            // HTTP POST is the only method allowed to send the notification.
            sendNotificationRequest.Method = "POST";

            // The optional custom header X-MessageID uniquely identifies a notification message. 
            // If it is present, the same value is returned in the notification response. It must be a string that contains a UUID.
            // sendNotificationRequest.Headers.Add("X-MessageID", "<UUID>");

            // Create the toast message.
            string toastMessage = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
            "<wp:Notification xmlns:wp=\"WPNotification\">" +
               "<wp:Toast>" +
                    "<wp:Text1>Riveu</wp:Text1>" +
                    "<wp:Text2>" + message + "</wp:Text2>" +
                    "<wp:Param>/MainPage.xaml</wp:Param>" +
               "</wp:Toast> " +
            "</wp:Notification>";

            // Set the notification payload to send.
            byte[] notificationMessage = Encoding.Default.GetBytes(toastMessage);

            // Set the web request content length.
            sendNotificationRequest.ContentLength = notificationMessage.Length;
            sendNotificationRequest.ContentType = "text/xml";
            sendNotificationRequest.Headers.Add("X-WindowsPhone-Target", "toast");
            sendNotificationRequest.Headers.Add("X-NotificationClass", "2");


            using (Stream requestStream = sendNotificationRequest.GetRequestStream())
            {
                requestStream.Write(notificationMessage, 0, notificationMessage.Length);
            }

            // Send the notification and get the response.
            HttpWebResponse response = (HttpWebResponse)sendNotificationRequest.GetResponse();
        }

        public bool RegisterUser(string username, string password)
        {
            return new NotificationsDao().Register(username, password);
        }


        public bool VerifyUserAccountExists(string username)
        {
            return new NotificationsDao().CheckForUserAccount(username);
        }
    }
}
