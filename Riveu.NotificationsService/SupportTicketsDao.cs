using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Riveu.NotificationsService
{
    public class SupportTicketsDao
    {
        private string connectionString = "Data Source=riveu.db.11468214.hostedresource.com; Initial Catalog=riveu; User ID=riveu; Password=P@ssw0rd";
        public bool AuthenticateUser(string username, string password)
        {
            bool authenticated = false;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                password = Utilities.GetMD5Hash(password);
                string sql = "SELECT COUNT(UserID) FROM SUPPORT_USERS WHERE Username='" + username + "' AND Password='" + password + "' AND IsDeleted=0";
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
        public bool Register(string username, string password)
        {
            bool created = false;
            if (!CheckForUserAccount(username))
            {
                password = Utilities.GetMD5Hash(password);
                string sql = "INSERT INTO SUPPORT_USERS (Username,Password,IsDeleted) VALUES('" + username + "','" + password + "',0);";
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

        public bool CheckForUserAccount(string username)
        {
            bool present = false;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                string sql = "SELECT COUNT(UserID) FROM SUPPORT_USERS WHERE Username='" + username + "' AND IsDeleted=0";
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

        public void AddSupportTicket(string username, string password, string project, string description, string reporter, string status, string statusComments, string statusDate, string reportedDate)
        {
            if (AuthenticateUser(username, password))
            {
                password = Utilities.GetMD5Hash(password);
                string sql = "INSERT INTO SUPPORT_TICKETS (Description,Project,ReporterID,ReportedDate,Status,StatusDate,StatusComments,UpdaterID,IsDeleted) VALUES('" + description.Replace("'", "''") + "','" + project + "',(SELECT UserID FROM SUPPORT_USERS WHERE Username='" + username + "' AND Password='" + password + "' AND IsDeleted=0),'" + reportedDate + "','" + status + "','" + statusDate + "','" + statusComments + "',(SELECT UserID FROM SUPPORT_USERS WHERE Username='" + username + "' AND Password='" + password + "' AND IsDeleted=0),0)";
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
        }

        public DataTable GetTickets()
        {
            DataTable dataTable = new DataTable();
            string sql = "SELECT SupportTicketID,Description,Project,(SELECT Username FROM SUPPORT_USERS WHERE UserID = ReporterID) as 'Reporter',ReportedDate,Status,StatusDate,StatusComments,(SELECT Username FROM SUPPORT_USERS WHERE UserID = UpdaterID) as 'Updater' FROM SUPPORT_TICKETS WHERE IsDeleted=0";
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                new SqlDataAdapter(sql, conn).Fill(dataTable);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return dataTable;
        }

        public bool AuthenticateTicketModifier(string username, string ticketID)
        {
            bool authenticated = false;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                string sql = "SELECT COUNT(SupportTicketID) FROM SUPPORT_TICKETS WHERE IsDeleted=0 AND SupportTicketID = '" + ticketID + "' AND (ReporterID=(SELECT UserID FROM SUPPORT_USERS WHERE Username='" + username + "' and IsDeleted=0) OR ((SELECT COUNT(UserID) FROM SUPPORT_USERS WHERE Username='" + username + "' AND IsStaff=1 AND IsDeleted=0)=1))";
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

        public void DeleteSupportTicket(string ticketID)
        {
            string sql = "UPDATE SUPPORT_TICKETS SET IsDeleted=1 WHERE SupportTicketID='" + ticketID + "' AND IsDeleted=0;";
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

        public void UpdateSupportTicket(string ticketID, string project, string description, string reporter, string reportedDate, string status, string statusDate, string statusComments, string updater)
        {
            string sql = "UPDATE SUPPORT_TICKETS SET Project='" + project + "',Description='" + description + "',ReporterID=(SELECT UserID FROM SUPPORT_USERS WHERE Username='" + reporter + "' AND IsDeleted=0),ReportedDate='" + reportedDate + "',Status='" + status + "',StatusDate='" + statusDate + "',StatusComments='" + statusComments + "',UpdaterID=(SELECT UserID FROM SUPPORT_USERS WHERE Username='" + updater + "' AND IsDeleted=0) WHERE SupportTicketID='" + ticketID + "' AND IsDeleted=0;";
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
    }
}