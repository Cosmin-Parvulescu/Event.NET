using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ObjectCL;

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
        //private String conString = "Data Source=localhost;Initial Catalog=eventdotnet;User Id=whatever;Password=;";
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

        public bool UserExists(User user)
        {
            String username = user.Username;
            SqlCommand query = new SqlCommand("SELECT username FROM [Member] WHERE username = '" + username + "'", con);
            SqlDataReader reader = query.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }
        }

        public bool AddUser(User user)
        {

            ////  SqlCommand query = new SqlCommand("INSERT INTO [Member] (username, password,firstName,lastName,rating) VALUES ('" + user.Username + "', '" + user.Password + "','" + user.FirstName + "', '" + user.LastName + "','" + user.Rating + "')", con);
            //if (true)
            //{ //(query.ExecuteNonQuery() != 1)
            throw new NotImplementedException();
            //    throw new Exception("Error Adding the user: " + user.Username + " to the database");
            //}
        }


        public bool LogIn(User user)
        {
            if (!UserExists(user))
            {
               
                throw new Exception("User doesn´t exist in the database");
            }
            else
            {
                SqlCommand query = new SqlCommand("SELECT username, password FROM [Member] WHERE username = '" + user.Username + "'", con);
                SqlDataReader reader = query.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (user.Password == reader["password"].ToString())
                        {
                            reader.Close();
                            return true;
                        }
                        else

                        {
                            reader.Close();
                            throw new Exception("Password doesn´t match");
                        }
                    }
                }
                else {
                    reader.Close();
                    throw new Exception("User doesn´t exist in the database");
                }
                reader.Close();
                return false;
            }
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
            //SqlCommand query = new SqlCommand("UPDATE [Member] SET username`='" + user.Username + "',password='"+user.Password+"',firstName='"+user.Firstname+"',lastName='"+user.Lastname+"',rating='"+user.Rating+"'", con);
            //int resultNo = query.ExecuteNonQuery();

            //if (!UserExists(user)) //(query.ExecuteNonQuery() == 1)
            //{
            //    throw new Exception("User does not exist");
            //}
            //else
            //{
            //    if (resultNo == 1)
            //    {
            //    }
            //    else if (resultNo == 0)
            //    {
            //        throw new Exception("No rows affected in the database");
            //    }
            //    else
            //    {
            //        throw new Exception("Multiple rows affected in the database");
            //    }
            //}
        }

        public User GetUser(String username)
        {
            SqlCommand query = new SqlCommand("SELECT * FROM [Member] WHERE username = '" + username + "'", con);
            SqlDataReader reader = query.ExecuteReader();
            User user = new User();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    
                    user.Username = reader["username"].ToString();
                    user.Password = reader["password"].ToString();
                    user.Firstname = reader["firstName"].ToString();
                    user.Email = reader["email"].ToString();
                    user.Lastname = reader["lastName"].ToString();
                    user.Rating = Convert.ToInt32(reader["rating"].ToString());
                    
                }
            }
            else
            {
                reader.Close();
                throw new Exception("Error Getting the user: " + username + " to the database");
            }
            reader.Close();
            return user;
        }

        public List<User> GetUsers(Event e, byte flag)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Parses date strings from SQL format to regular format
        /// </summary>
        /// <param name="date">mm/dd/yyyy [...]</param>
        /// <returns>yyyy-mm-dd</returns>
        private String ParseDate(String date)
        {
            String[] split = date.Split(new char[] { '/', ' ' });
            return split[2] + "-" + split[0] + "-" + split[1];
        }

        /// <summary>
        /// Parses time strings from SQL format to regular format
        /// </summary>
        /// <param name="date">hh:mm:ss.[...]</param>
        /// <returns>hh:mm</returns>
        private String ParseTime(String date)
        {
            String[] split = date.Split(new char[] { ':', '.' });
            return split[0] + ":" + split[1];
        }

        /// <summary>
        /// Adds an event into the database, this event should have 
        /// all the details filled and the ID = 0
        /// </summary>
        /// <param name="e">Instance of the event with the ID = 0</param>
        /// <returns>0 - success | other - failure</returns>
        public bool AddEvent(Event e)
        {
            int eventId = 0;
            bool added = true;

            if (e.Id == 0)
            {
                SqlCommand query = new SqlCommand();
                query.Connection = con;
                SqlDataReader reader = null;

                // Add main event
                query.CommandText = "INSERT INTO [Event] (eidmember, name, voteenddate, type) VALUES (" + e.Admin.Id + ", '" + e.Name + "', '2012-12-21 00:00:00', ";
                if (!e.Visibility) query.CommandText += 0 + ")";
                else query.CommandText += 1 + ")";

                if (query.ExecuteNonQuery() != 1)
                {
                    added = false;
                    throw new Exception("Something happened in the INSERT query [EVENT]");
                }

                // Get the newly generated ID
                query.CommandText = "SELECT MAX(idevent) AS id FROM [Event]";
                reader = query.ExecuteReader();
                reader.Read();
                eventId = Convert.ToInt32(reader["id"].ToString());
                reader.Close();

                // Add locations
                foreach (Location l in e.Locations)
                {
                    query.CommandText = "INSERT INTO [Location] (locationplace, country, city, address) VALUES ('" + l.LocationPlace + "', '" + l.Country + "', '" + l.City + "', '" + l.Address + "')";
                    if (query.ExecuteNonQuery() != 1)
                    {
                        added = false;
                        throw new Exception("Something happened in the INSERT query[LOCATION]");
                    }

                    query.CommandText = "SELECT MAX(idlocation) AS id FROM [Location]";
                    reader = query.ExecuteReader();
                    reader.Read();
                    int locationId = Convert.ToInt32(reader["id"].ToString());
                    reader.Close();

                    query.CommandText = "INSERT INTO [LocationOptions] (eidevent, eidlocation) VALUES (" + eventId + ", " + locationId + ")";
                    if (query.ExecuteNonQuery() != 1)
                    {
                        added = false;
                        throw new Exception("Something happened in the INSERT query[LOCATIONOPTIONS]");
                    }
                }

                // Add dateoptions
                foreach (String s in e.Dates)
                {
                    query.CommandText = "INSERT INTO [DateOptions] (eidevent, date) VALUES (" + eventId + ", '" + s + "')";

                    if (query.ExecuteNonQuery() != 1)
                    {
                        added = false;
                        throw new Exception("Something happened in the INSERT query[DATEOPTIONS]");
                    }
                }

                // Add timeoptions
                foreach (String s in e.Times)
                {
                    query.CommandText = "INSERT INTO [TimeOptions] (eidevent, time) VALUES (" + eventId + ", ";

                    // Just check if the string is smaller than hh:mm:ss so we can add the latter if necessary
                    if (s.Length == 5)
                        query.CommandText += "'" + s + ":00')";
                    else
                        query.CommandText += "'" + s + "')";

                    if (query.ExecuteNonQuery() != 1)
                    {
                        added = false;
                        throw new Exception("Something happened in the INSERT query[TIMEOPTIONS]");
                    }
                }

                return added;
            }
            else
            {
                throw new Exception("Event ID not set to 0");
            }
        }

        /// <summary>
        /// Check if a specific event exists
        /// </summary>
        /// <param name="e">Instance of Event with the ID set</param>
        /// <returns>0 - exists | other - doesn't exist</returns>
        public bool EventExists(Event e)
        {
            SqlCommand query = null;
            SqlDataReader reader = null;

            try
            {
                query = new SqlCommand("SELECT * FROM Event WHERE idevent = " + e.Id, con);
                reader = query.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Updates the event in the database
        /// </summary>
        /// <param name="e">This instance of event should be completely filled</param>
        /// <returns></returns>
        public bool UpdateEvent(Event e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all the dates related to a specific event
        /// </summary>
        /// <param name="e">The instance of event. ID is mandatory and different than 0</param>
        /// <returns>A list of strings representing dates ["yyyy-mm-dd"]... at least 1 I guess</returns>
        private List<String> GetDates(Event e)
        {
            List<String> dates = new List<String>();

            SqlCommand query = null;
            SqlDataReader reader = null;

            query = new SqlCommand("SELECT * FROM DateOptions WHERE eidevent = " + e.Id, con);
            reader = query.ExecuteReader();

            while (reader.Read())
            {
                String tempDate = ParseDate(reader["DATE"].ToString());
                dates.Add(tempDate);
            }

            reader.Close();

            return dates;
        }

        /// <summary>
        /// Gets all the times related to a specific event
        /// </summary>
        /// <param name="e">The instance of event. ID is mandatory and different than 0</param>
        /// <returns>A list of strings representing times ["hh:mm"]... at least 1 I guess</returns>
        private List<String> GetTimes(Event e)
        {
            List<String> times = new List<String>();

            SqlCommand query = null;
            SqlDataReader reader = null;

            query = new SqlCommand("SELECT * FROM TimeOptions WHERE eidevent = " + e.Id, con);
            reader = query.ExecuteReader();

            while (reader.Read())
            {
                String tempTime = ParseTime(reader["TIME"].ToString());
                times.Add(tempTime);
            }

            reader.Close();

            return times;
        }

        /// <summary>
        /// Get all the suggested locations for a specific event
        /// </summary>
        /// <param name="e">The instance of event. ID is mandatory and different than 0</param>
        /// <returns>A list of locations... at least 1 I guess</returns>
        private List<Location> GetLocations(Event e)
        {
            List<Location> locations = new List<Location>();

            SqlCommand query = null;
            SqlDataReader reader = null;

            query = new SqlCommand("SELECT * FROM location WHERE idlocation IN ( SELECT eidlocation FROM locationoptions WHERE eidevent = " + e.Id + ")", con);
            reader = query.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Location tempLocation = new Location();
                    tempLocation.LocationPlace = reader["locationplace"].ToString();
                    tempLocation.Country = reader["country"].ToString();
                    tempLocation.City = reader["city"].ToString();
                    tempLocation.Address = reader["address"].ToString();

                    locations.Add(tempLocation);
                    Console.WriteLine(tempLocation.LocationPlace + ", " + tempLocation.Country + ", " + tempLocation.City + ", " + tempLocation.Address);
                }
            }

            reader.Close();

            return locations;
        }

        /// <summary>
        /// Get the User admin for a specific event
        /// </summary>
        /// <param name="e">The instance of event. ID is mandatory and different than 0</param>
        /// <returns>A new user with the details of the event admin</returns>
        private User GetAdmin(Event e)
        {
            SqlCommand query = null;
            SqlDataReader reader = null;

            try
            {
                query = new SqlCommand("SELECT * FROM Member WHERE idmember = (SELECT eidmember FROM Event WHERE idevent = " + e.Id + ");", con);
                reader = query.ExecuteReader();

                if (reader.Read())
                {
                    User tempUser = new User();

                    // Usefull stuff
                    tempUser.Id = Convert.ToInt32(reader["idmember"].ToString());
                    tempUser.Rating = Convert.ToInt32(reader["rating"].ToString());
                    tempUser.Username = reader["username"].ToString();
                    tempUser.Firstname = reader["firstname"].ToString();
                    tempUser.Lastname = reader["lastname"].ToString();

                    // Useless stuff
                    tempUser.Password = "";
                    tempUser.Email = "";

                    reader.Close();

                    return tempUser;
                }
                else
                {
                    throw new Exception("Could not read from the database");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Returns a list of events dependent on the flag
        /// </summary>
        /// <param name="u">Instance of User with at least a name or ID set</param>
        /// <param name="flag">1 - Created BY u | 2 - u IS attending | 3 - u IS invited</param>
        /// <returns></returns>
        public List<Event> GetEvents(User u, byte flag)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a specific Event based on the ID
        /// </summary>
        /// <param name="e">Instance of Event with ID set</param>
        /// <returns></returns>
        public Event GetEvent(int id)
        {
            // Need the ID as a starting point for the other functions
            Event tempEvent = new Event(id, "", null, null, null, null, false);

            SqlCommand query = null;
            SqlDataReader reader = null;

            if (EventExists(tempEvent))
            {
                try
                {
                    query = new SqlCommand("SELECT * FROM Event WHERE idevent = " + id, con);
                    reader = query.ExecuteReader();
                }
                catch (Exception e)
                {
                    throw e;
                }

                if (reader.Read())
                {
                    tempEvent.Name = reader["name"].ToString();
                    if (reader["type"].ToString().Equals("1")) tempEvent.Visibility = true; else tempEvent.Visibility = false;

                    // Trust me, this close has to be here :x
                    reader.Close();

                    tempEvent.Locations = GetLocations(tempEvent);
                    tempEvent.Times = GetTimes(tempEvent);
                    tempEvent.Dates = GetDates(tempEvent);
                    tempEvent.Admin = GetAdmin(tempEvent);

                    return tempEvent;
                }
                else
                {
                    throw new Exception("Could not read from the database");
                }
            }
            else
            {
                throw new Exception("Event with ID[" + id + "] does not exist");
            }
        }

        public bool DeleteEvent(Event ev)
        {
            throw new NotImplementedException();
        }

        //Votes table: 1=Location 2=Date 3=Time
        public bool LocationVoted(User us, Event ev) {
            bool res;
            SqlCommand query = new SqlCommand("SELECT * FROM [Votes] WHERE eidevent = '" + ev.Id + "' and eidmember='"+us.Id+"' and type='1'", con);
            SqlDataReader reader = query.ExecuteReader();
            res = reader.HasRows;
            reader.Close();
            return res;            
        }
        public bool DateVoted(User us, Event ev)
        {
            bool res;
            SqlCommand query = new SqlCommand("SELECT * FROM [Votes] WHERE eidevent = '" + ev.Id + "' and eidmember='" + us.Id + "' and type='2'", con);
            SqlDataReader reader = query.ExecuteReader();
            res = reader.HasRows;
            reader.Close();
            return res;
        }
        public bool TimeVoted(User us, Event ev)
        {
            bool res;
            SqlCommand query = new SqlCommand("SELECT * FROM [Votes] WHERE eidevent = '" + ev.Id + "' and eidmember='" + us.Id + "' and type='3'", con);
            SqlDataReader reader = query.ExecuteReader();
            res = reader.HasRows;
            reader.Close();
            return res;
        }
        public bool VoteLocation(User us, Event ev) {
            SqlCommand query = null;
            query = new SqlCommand("INSERT INTO Votes Values (" + ev.Id + "," + us.Id + ",1)", con);
            query.ExecuteNonQuery();
            return true;
        
        }
    }
}
