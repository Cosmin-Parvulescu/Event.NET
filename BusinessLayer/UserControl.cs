using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ObjectCL;

using DataAccessLayer;

namespace BusinessLayer
{
    class UserControl
    {
        private Regex userRegex = new Regex("^[a-zA-Z][a-zA-Z0-9]*$");
        private Regex passwordRegex = new Regex("[a-zA-Z0-9]*$");

        public bool RegisterUser(User us)
        {
            return DataAccess.Instance.AddUser(us);                              
        }

        public bool LogIn(User us)
        {
           return DataAccess.Instance.LogIn(us);
          
        }

        
        public bool Update(User user)
        {
          return DataAccess.Instance.UpdateUser(user); 
           
        }

        public User GetUser(String username)
        {

            return DataAccess.Instance.GetUser(username);
            
        }

        public List<User> GetUsers(Event ev, Byte b) {

            return DataAccess.Instance.GetUsers(ev,b);      
           
        }

        public bool UserExists(User us)
        {

            return DataAccess.Instance.UserExists(us);      
          
        }



        /// <summary>
        /// Checks for proper username and password input
        /// </summary>
        /// <param name="username">Allows dashes, underscore, lowercase letters, uppercase letters and numbers [must start with letter]</param>
        /// <param name="password">Allows same as username but with additional characters</param>
        /// <returns>0 - pass | 1 - fail</returns>
        private int Validate(String username, String password)
        {
            if (userRegex.IsMatch(username) && passwordRegex.IsMatch(password))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
