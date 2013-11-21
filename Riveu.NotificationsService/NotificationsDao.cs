using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Riveu.NotificationsService
{
    public class NotificationsDao
    {
        private string connectionString = "Data Source=riveu.db.11468214.hostedresource.com; Initial Catalog=riveu; User ID=riveu; Password=P@ssw0rd";
        //private string connectionString = "Data Source=.; Initial Catalog=Notifications; Integrated Security=SSPI";

        public bool AuthenticateUser(string username, string password)
        {
            bool authenticated = false;
                SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                password = Utilities.GetMD5Hash(password);
                string sql = "SELECT COUNT(UserID) FROM NOTIFICATION_USERS WHERE Username='" + username + "' AND Password='" + password + "' AND IsDeleted=0";
                object result = new SqlCommand(sql, conn).ExecuteScalar();
                if (Convert.ToInt32(result) == 1)
                {
                    authenticated = true;
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return authenticated;
        }

        public ArrayList GetNotifications(string username)
        {
            ArrayList notificationList = new ArrayList();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                string sql = "SELECT Message FROM NOTIFICATION_MESSAGES WHERE UserID IN (SELECT UserID FROM NOTIFICATION_USERS WHERE Username='" + username + "' AND IsDeleted=0) AND IsDeleted=0";
                SqlDataReader dataReader = new SqlCommand(sql, conn).ExecuteReader();
                while (dataReader.Read())
                {
                    notificationList.Add(dataReader[0]);
                }
                notificationList.Reverse();
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return notificationList;
        }

        public bool CheckForUserAccount(string username)
        {
            bool present = false;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                string sql = "SELECT COUNT(UserID) FROM NOTIFICATION_USERS WHERE Username='" + username + "' AND IsDeleted=0";
                object result = new SqlCommand(sql, conn).ExecuteScalar();
                if (Convert.ToInt32(result) == 1)
                {
                    present = true;
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return present;
        }

        public bool Register(string username, string password)
        {
            bool created = false;
            if (!CheckForUserAccount(username))
            {
                //insert
                password = Utilities.GetMD5Hash(password);
                string sql = "INSERT INTO NOTIFICATION_USERS (Username,Password,IsDeleted) VALUES('" + username + "','" + password + "',0);";
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    new SqlCommand(sql, conn).ExecuteNonQuery();
                    created = true;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            return created;
        }

        public void RegisterSubscriber(string username, string password, string Uri, string deviceType, string deviceId)
        {
            password = Utilities.GetMD5Hash(password);
            string sql = "IF EXISTS(SELECT SubscriberID FROM NOTIFICATION_SUBSCRIBERS WHERE DeviceName='" + deviceId + "' AND DeviceType='" + deviceType + "' AND IsDeleted=0 AND USERID IN (SELECT UserID FROM NOTIFICATION_USERS WHERE Username='" + username + "' AND Password='" + password + "' AND IsDeleted=0)) UPDATE NOTIFICATION_SUBSCRIBERS SET SubscriberURI='" + Uri + "' WHERE DeviceName='" + deviceId + "' AND DeviceType='" + deviceType + "' AND IsDeleted=0 AND USERID IN (SELECT UserID FROM NOTIFICATION_USERS WHERE Username='" + username + "' AND Password='" + password + "' AND IsDeleted=0) ELSE INSERT INTO NOTIFICATION_SUBSCRIBERS (UserID,DeviceName,DeviceType,SubscriberURI,IsDeleted) VALUES((SELECT UserID FROM NOTIFICATION_USERS WHERE Username='" + username + "' AND Password='" + password + "' AND IsDeleted=0),'" + deviceId + "','" + deviceType + "','" + Uri + "',0)";
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                new SqlCommand(sql, conn).ExecuteNonQuery();
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public void UnregisterSubscriber(string username, string password, string deviceType, string deviceId)
        {
            password = Utilities.GetMD5Hash(password);
            string sql = "UPDATE NOTIFICATION_SUBSCRIBERS SET IsDeleted=1 WHERE DeviceName='" + deviceId + "' AND DeviceType='" + deviceType + "' AND UserID IN (SELECT UserID FROM NOTIFICATION_USERS WHERE Username='" + username + "' AND Password='" + password + "' AND IsDeleted=0)";
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                new SqlCommand(sql, conn).ExecuteNonQuery();
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public void AddNotificationMessage(string username, string password, string message)
        {
            password = Utilities.GetMD5Hash(password);
            string sql = "INSERT INTO NOTIFICATION_MESSAGES (UserID,Message,IsDeleted) VALUES((SELECT UserID FROM NOTIFICATION_USERS WHERE Username='" + username + "' AND Password='" + password + "' AND IsDeleted=0),'" + message + "',0);";
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                new SqlCommand(sql, conn).ExecuteNonQuery();
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public DataTable GetSubscribers(string username, string password)
        {
            DataTable result = new DataTable();
            password = Utilities.GetMD5Hash(password);
            string sql = "SELECT SubscriberURI,DeviceType FROM NOTIFICATION_SUBSCRIBERS WHERE UserID IN (SELECT UserID FROM NOTIFICATION_USERS WHERE Username='" + username + "' AND Password='" + password + "' AND IsDeleted=0) AND IsDeleted=0";
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                new SqlDataAdapter(sql, conn).Fill(result);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return result;
        }
    }


}