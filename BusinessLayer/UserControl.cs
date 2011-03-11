using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using DataAccessLayer;

namespace BusinessLayer
{
    class UserControl
    {
        private Regex userRegex = new Regex("^[a-zA-Z][a-zA-Z0-9]*$");
        private Regex passwordRegex = new Regex("[a-zA-Z0-9]*$");

        public int RegisterUser(String username, String password)
        {
            // Need DAL here
            if(Validate(username, password) == 0)
            {
                if (DataAccess.Instance.AddUser(username, password) == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            return 1;
        }

        public int LogIn(String username, String password)
        {
            // Need DAL here
            if (Validate(username, password) == 0)
            {
                if (DataAccess.Instance.LogIn(username, password) == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            return 1;
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
