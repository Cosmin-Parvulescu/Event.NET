using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectCL
{
    public class User
    {
        private Int32 id;
        private String username;
        private String password;
        private String firstname;
        private String lastname;
        private String email;
        private Int32 rating;

        public User()
        {
        }

        public User(Int32 id, String username, String firstname, String lastname, Int32 rating)
        {
            this.id = id;
            this.username = username;
            this.firstname = firstname;
            this.lastname = lastname;
            this.rating = rating;
        }
		
		public User(Int32 id, String username, String password, String firstname, String lastname, String email, Int32 rating)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.rating = rating;
        }

        public override String ToString()
        {
            return base.ToString();
        }

        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Username
        {
            get { return username; }
            set { username = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public String Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public String Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        public Int32 Rating
        {
            get { return rating; }
            set { rating = value; }
        }
    }
}
