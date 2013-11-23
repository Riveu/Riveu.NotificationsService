using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Riveu.NotificationsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INotificationService" in both code and config file together.
    [ServiceContract]
    public interface INotificationService
    {
        [OperationContract]
        bool AuthenticateUser(string username, string password);
        
        [OperationContract]
        IList GetNotifications(string username);

        [OperationContract]
        void RegisterSubscriber(string username, string password, string Uri, string deviceType, string deviceId);

        [OperationContract]
        void UnregisterSubscriber(string username, string password, string deviceType, string deviceId);

        [OperationContract]
        void SendNotification(string username, string password, string message);

        [OperationContract]
        bool RegisterUser(string username, string password);

        [OperationContract]
        bool VerifyUserAccountExists(string username);
    }
}
