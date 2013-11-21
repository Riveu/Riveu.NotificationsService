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
            //string xml = "<toast launch=""><visual lang="en-US"><binding template="ToastImageAndText01"><image id="1" src="World" /><text id="1">Hello</text></binding></visual></toast>";
            string xml = "<toast><visual><binding template=\"ToastText01\"><text id=\"1\">" + message +"</text></binding></visual></toast>";
            //new NotificationsDao().AddNotificationMessage("michaeldlesk", "Dl3skt3ch", xml);
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


        public bool RegisterUser(string username, string password)
        {
            return new NotificationsDao().Register(username, password);
        }
    }
}
