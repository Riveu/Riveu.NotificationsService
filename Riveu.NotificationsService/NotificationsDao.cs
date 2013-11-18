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
        private string connectionString = "Data Source=.; Initial Catalog=Notifications; Integrated Security=SSPI";

        public bool AuthenticateUser(string username, string password)
        {
            bool authenticated = false;
                SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
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
    }
}