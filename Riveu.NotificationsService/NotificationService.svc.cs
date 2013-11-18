using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

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


        public System.Collections.ArrayList GetNotifications(string username)
        {
            return new NotificationsDao().GetNotifications(username);
        }
    }
}
