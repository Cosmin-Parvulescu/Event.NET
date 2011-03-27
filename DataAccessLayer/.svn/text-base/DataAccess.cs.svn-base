using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DataAccess
    {
        private static DataAccess instance;
        public static DataAccess Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataAccess();
                }
                return instance;
            }
        }

        private String conString = "Data Source=.\\SQLEXPRESS;Initial Catalog=EventDotNet;User Id=whatever;Password=;";
        private SqlConnection con;

        private DataAccess()
        {
            con = new SqlConnection(conString);
            try
            {
                con.Open();
            }
            catch
            {
                throw;
            }
        }

        public int UserExists(String value)
        {
            SqlCommand query = new SqlCommand("SELECT username FROM [User] WHERE username = '" + value + "'", con);
            SqlDataReader reader = query.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Close();
                return 0;
            }
            else
            {
                reader.Close();
                return 1;
            }
        }

        public int AddUser(String username, String password)
        {
            SqlCommand query = new SqlCommand("INSERT INTO [User] (username, password) VALUES ('" + username + "', '" + password + "')", con);

            if (query.ExecuteNonQuery() == 1)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public int AddEvent(String eventName, String eventLocation, String eventDate, String eventAdmin)
        {
            int adminID = 0;
            SqlCommand query = new SqlCommand("SELECT idUser FROM [User] WHERE username = '" + eventAdmin + "'", con);
            SqlDataReader reader = query.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    adminID = Convert.ToInt32(reader["idUser"].ToString());
                    break;
                }
            }
            reader.Close();

            query.CommandText = "INSERT INTO [Event] (name, location, eventdate, eIDuser) VALUES ('" + eventName + "', '" + eventLocation + "', '" + eventDate + "', " + adminID + ")";

                if (query.ExecuteNonQuery() == 1)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
        }

        public int LogIn(String username, String password)
        {
            SqlCommand query = new SqlCommand("SELECT username, password FROM [User] WHERE username = '" + username + "'", con);
            SqlDataReader reader = query.ExecuteReader();

            bool found = false;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (password == reader["password"].ToString())
                    {
                        found = true;
                        break;
                    }
                }
            }

            if (found)
            {
                reader.Close();
                return 0;
            }
            else
            {
                reader.Close();
                return 1;
            }
        }
    }
}
